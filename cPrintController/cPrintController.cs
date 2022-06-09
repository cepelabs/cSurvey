using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

//credit to: DAVID
//http://anotherdeveloper.blogspot.com/2012/01/how-to-hide-net-printpreviewcontrols.html

namespace cPrintController
{
    public class PrintControllerNoStatusDialog : PrintController
    {
        private PrintDocument document;
        private int pageNumber;
        private PrintController underlyingController;


        public PrintControllerNoStatusDialog(PrintController underlyingController)
        {
            this.underlyingController = underlyingController;
        }


        public override void OnEndPage(PrintDocument document, PrintPageEventArgs e)
        {
            this.underlyingController.OnEndPage(document, e);

            this.pageNumber++;
            base.OnEndPage(document, e);
        }

        public override void OnEndPrint(PrintDocument document, PrintEventArgs e)
        {
            this.underlyingController.OnEndPrint(document, e);
            base.OnEndPrint(document, e);
        }

        public override Graphics OnStartPage(PrintDocument document, PrintPageEventArgs e)
        {
            base.OnStartPage(document, e);

            Graphics graphics = this.underlyingController.OnStartPage(document, e);

            return graphics;
        }

        public override void OnStartPrint(PrintDocument document, PrintEventArgs e)
        {
            base.OnStartPrint(document, e);

            this.document = document;
            this.pageNumber = 1;

            try
            {
                this.underlyingController.OnStartPrint(document, e);
            }
            catch
            {
                throw;
            }
        }

        public override bool IsPreview
        {
            get
            {
                return ((this.underlyingController != null) && this.underlyingController.IsPreview);
            }
        }


    }


    internal class NativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public class SCROLLINFO
        {
            public int cbSize;
            public int fMask;
            public int nMin;
            public int nMax;
            public int nPage;
            public int nPos;
            public int nTrackPos;

            public SCROLLINFO()
            {
                this.cbSize = Marshal.SizeOf(typeof(NativeMethods.SCROLLINFO));

            }
            public SCROLLINFO(int mask, int min, int max, int page, int pos)
            {
                this.cbSize = Marshal.SizeOf(typeof(NativeMethods.SCROLLINFO));
                this.fMask = mask;
                this.nMin = min;
                this.nMax = max;
                this.nPage = page;
                this.nPos = pos;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT(Rectangle r)
            {
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public static NativeMethods.RECT FromXYWH(int x, int y, int width, int height)
            {
                return new NativeMethods.RECT(x, y, x + width, y + height);
            }

            public Size Size
            {
                get
                {
                    return new Size(this.right - this.left, this.bottom - this.top);
                }
            }
        }


        internal static class Util
        {
            public static int HIWORD(int n)
            {
                return ((n >> 0x10) & 0xffff);
            }

            public static int HIWORD(IntPtr n)
            {
                return HIWORD((int)((long)n));
            }

            public static int LOWORD(int n)
            {
                return (n & 0xffff);
            }

            public static int LOWORD(IntPtr n)
            {
                return LOWORD((int)((long)n));
            }
        }

    }

    internal static class SafeNativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetScrollInfo(HandleRef hWnd, int fnBar, [In, Out] NativeMethods.SCROLLINFO si);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ScrollWindow(HandleRef hWnd, int nXAmount, int nYAmount, ref NativeMethods.RECT rectScrollRegion, ref NativeMethods.RECT rectClip);

    }

    internal static class UnsafeNativeMethods
    {
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(HandleRef hDC, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int SetScrollPos(HandleRef hWnd, int nBar, int nPos, bool bRedraw);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int SetScrollInfo(HandleRef hWnd, int fnBar, NativeMethods.SCROLLINFO si, bool redraw);

    }

    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch), DefaultProperty("Document")]
    public class PrintPreviewControl : Control
    {
        private bool antiAlias;
        private bool autoZoom = true;
        private const int border = 10;
        private int columns = 1;
        private const double DefaultZoom = 0.3;
        private PrintDocument document;
        private static readonly object EVENT_STARTPAGECHANGED = new object();
        private bool exceptionPrinting;
        private Size imageSize = Size.Empty;
        private Point lastOffset;
        private bool layoutOk;
        private PreviewPageInfo[] pageInfo;
        private bool pageInfoCalcPending;
        private Point position = new Point(0, 0);
        private int rows = 1;
        private Point screendpi = Point.Empty;
        private const int SCROLL_LINE = 5;
        private const int SCROLL_PAGE = 100;
        private int startPage;
        private Size virtualSize = new Size(1, 1);
        private double zoom = 0.3;

        public event EventHandler StartPageChanged
        {
            add
            {
                base.Events.AddHandler(EVENT_STARTPAGECHANGED, value);
            }
            remove
            {
                base.Events.RemoveHandler(EVENT_STARTPAGECHANGED, value);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public event EventHandler TextChanged
        {
            add
            {
                base.TextChanged += value;
            }
            remove
            {
                base.TextChanged -= value;
            }
        }

        // Methods
        public PrintPreviewControl()
        {
            this.ResetBackColor();
            this.ResetForeColor();
            base.Size = new Size(100, 100);
            base.SetStyle(ControlStyles.ResizeRedraw, false);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.Opaque, true);
        }

        private int AdjustScroll(Message m, int pos, int maxPos, bool horizontal)
        {
            switch (NativeMethods.Util.LOWORD(m.WParam))
            {
                case 0:
                    if (pos <= 5)
                    {
                        pos = 0;
                        return pos;
                    }
                    pos -= 5;
                    return pos;

                case 1:
                    if (pos >= (maxPos - 5))
                    {
                        pos = maxPos;
                        return pos;
                    }
                    pos += 5;
                    return pos;

                case 2:
                    if (pos <= 100)
                    {
                        pos = 0;
                        return pos;
                    }

                    pos -= 100;
                    return pos;

                case 3:
                    if (pos >= (maxPos - 100))
                    {
                        pos = maxPos;
                        return pos;
                    }

                    pos += 100;
                    return pos;

                case 4:
                case 5:
                    {
                        NativeMethods.SCROLLINFO si = new NativeMethods.SCROLLINFO
                        {
                            cbSize = Marshal.SizeOf(typeof(NativeMethods.SCROLLINFO)),
                            fMask = 0x10
                        };

                        int fnBar = horizontal ? 0 : 1;

                        if (!SafeNativeMethods.GetScrollInfo(new HandleRef(this, m.HWnd), fnBar, si))
                        {
                            pos = NativeMethods.Util.HIWORD(m.WParam);
                            return pos;
                        }

                        pos = si.nTrackPos;

                        return pos;
                    }
            }
            return pos;
        }

        private void CalculatePageInfo()
        {
            if (!this.pageInfoCalcPending)
            {
                this.pageInfoCalcPending = true;
                try
                {
                    if (this.pageInfo == null)
                    {
                        try
                        {
                            this.ComputePreview();
                        }
                        catch
                        {
                            this.exceptionPrinting = true;
                            throw;
                        }
                        finally
                        {
                            base.Invalidate();
                        }
                    }
                }
                finally
                {
                    this.pageInfoCalcPending = false;
                }
            }
        }

        private void ComputeLayout()
        {
            this.layoutOk = true;

            if (this.pageInfo.Length == 0)
            {
                base.ClientSize = base.Size;
            }
            else
            {
                Graphics wrapper = Graphics.FromHwndInternal(this.Handle);
                IntPtr hdc = wrapper.GetHdc();

                this.screendpi = new Point(UnsafeNativeMethods.GetDeviceCaps(new HandleRef(wrapper, hdc), 0x58), UnsafeNativeMethods.GetDeviceCaps(new HandleRef(wrapper, hdc), 90));

                wrapper.ReleaseHdcInternal(hdc);
                wrapper.Dispose();

                Size physicalSize = this.pageInfo[this.StartPage].PhysicalSize;
                Size size2 = new Size(PixelsToPhysical(new Point(base.Size), this.screendpi));

                if (this.autoZoom)
                {
                    double num = (size2.Width - (10 * (this.columns + 1))) / ((double)(this.columns * physicalSize.Width));
                    double num2 = (size2.Height - (10 * (this.rows + 1))) / ((double)(this.rows * physicalSize.Height));

                    this.zoom = Math.Min(num, num2);
                }

                this.imageSize = new Size((int)(this.zoom * physicalSize.Width), (int)(this.zoom * physicalSize.Height));

                int x = (this.imageSize.Width * this.columns) + (10 * (this.columns + 1));
                int y = (this.imageSize.Height * this.rows) + (10 * (this.rows + 1));

                this.SetVirtualSizeNoInvalidate(new Size(PhysicalToPixels(new Point(x, y), this.screendpi)));
            }
        }

        private void ComputePreview()
        {
            int startPage = this.StartPage;

            if (this.document == null)
            {
                this.pageInfo = new PreviewPageInfo[0];
            }
            else
            {
                new PrintingPermission(PrintingPermissionLevel.SafePrinting).Demand();

                PrintController printController = this.document.PrintController;
                PreviewPrintController underlyingController = new PreviewPrintController
                {
                    UseAntiAlias = this.UseAntiAlias
                };

                this.document.PrintController = new PrintControllerNoStatusDialog(underlyingController);
                this.document.Print();

                this.pageInfo = underlyingController.GetPreviewPageInfo();
                this.document.PrintController = printController;
            }

            if (startPage != this.StartPage)
            {
                this.OnStartPageChanged(EventArgs.Empty);
            }
        }

        private void InvalidateLayout()
        {
            this.layoutOk = false;
            base.Invalidate();
        }

        public void InvalidatePreview()
        {
            this.pageInfo = null;
            this.InvalidateLayout();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                if ((this.pageInfo == null) || (this.pageInfo.Length == 0))
                {
                    pevent.Graphics.FillRectangle(brush, base.ClientRectangle);

                    if ((this.pageInfo != null) || this.exceptionPrinting)
                    {
                        StringFormat format = new StringFormat
                        {
                            Alignment = TranslateAlignment(ContentAlignment.MiddleCenter),
                            LineAlignment = TranslateLineAlignment(ContentAlignment.MiddleCenter)
                        };

                        SolidBrush brush2 = new SolidBrush(this.ForeColor);

                        try
                        {
                            if (this.exceptionPrinting)
                            {
                                pevent.Graphics.DrawString("Document cannot be displayed.", this.Font, brush2, base.ClientRectangle, format);
                            }
                            else
                            {
                                pevent.Graphics.DrawString("Document does not contain any pages.", this.Font, brush2, base.ClientRectangle, format);
                            }

                            goto Label_04D7;
                        }
                        finally
                        {
                            brush2.Dispose();
                            format.Dispose();
                        }
                    }

                    base.BeginInvoke(new MethodInvoker(this.CalculatePageInfo));
                }
                else
                {
                    Point point2 = new Point();

                    if (!this.layoutOk)
                    {
                        this.ComputeLayout();
                    }

                    Size size = new Size(PixelsToPhysical(new Point(base.Size), this.screendpi));
                    Point point = new Point(this.VirtualSize);

                    point2 = new Point(Math.Max(0, (base.Size.Width - point.X) / 2), Math.Max(0, (base.Size.Height - point.Y) / 2));
                    point2.X = point2.X - this.Position.X;
                    point2.Y = point2.Y - this.Position.Y;

                    this.lastOffset = point2;

                    int num = PhysicalToPixels(10, this.screendpi.X);
                    int num2 = PhysicalToPixels(10, this.screendpi.Y);
                    Region clip = pevent.Graphics.Clip;
                    Rectangle[] rectangleArray = new Rectangle[this.rows * this.columns];
                    Point empty = Point.Empty;
                    int num3 = 0;

                    try
                    {
                        for (int j = 0; j < this.rows; j++)
                        {
                            empty.X = 0;
                            empty.Y = num3 * j;

                            for (int k = 0; k < this.columns; k++)
                            {
                                int index = (this.StartPage + k) + (j * this.columns);

                                if (index < this.pageInfo.Length)
                                {
                                    Size physicalSize = this.pageInfo[index].PhysicalSize;

                                    if (this.autoZoom)
                                    {
                                        double num7 = (size.Width - (10 * (this.columns + 1))) / ((double)(this.columns * physicalSize.Width));
                                        double num8 = (size.Height - (10 * (this.rows + 1))) / ((double)(this.rows * physicalSize.Height));
                                        this.zoom = Math.Min(num7, num8);
                                    }

                                    this.imageSize = new Size((int)(this.zoom * physicalSize.Width), (int)(this.zoom * physicalSize.Height));

                                    Point point4 = PhysicalToPixels(new Point(this.imageSize), this.screendpi);
                                    int x = (point2.X + (num * (k + 1))) + empty.X;
                                    int y = (point2.Y + (num2 * (j + 1))) + empty.Y;

                                    empty.X += point4.X;
                                    num3 = Math.Max(num3, point4.Y);
                                    rectangleArray[index - this.StartPage] = new Rectangle(x, y, point4.X, point4.Y);

                                    pevent.Graphics.ExcludeClip(rectangleArray[index - this.StartPage]);
                                }
                            }
                        }

                        pevent.Graphics.FillRectangle(brush, base.ClientRectangle);
                    }
                    finally
                    {
                        pevent.Graphics.Clip = clip;
                    }

                    for (int i = 0; i < rectangleArray.Length; i++)
                    {
                        if ((i + this.StartPage) < this.pageInfo.Length)
                        {
                            Rectangle rect = rectangleArray[i];
                            pevent.Graphics.DrawRectangle(Pens.Black, rect);
                            pevent.Graphics.FillRectangle(new SolidBrush(this.ForeColor), rect);

                            rect.Inflate(-1, -1);

                            if (this.pageInfo[i + this.StartPage].Image != null)
                            {
                                pevent.Graphics.DrawImage(this.pageInfo[i + this.StartPage].Image, rect);
                            }

                            rect.Width--;
                            rect.Height--;

                            pevent.Graphics.DrawRectangle(Pens.Black, rect);
                        }
                    }
                }
            }

        Label_04D7:
            base.OnPaint(pevent);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            this.InvalidateLayout();
            base.OnResize(eventargs);
        }

        protected virtual void OnStartPageChanged(EventArgs e)
        {
            EventHandler handler = base.Events[EVENT_STARTPAGECHANGED] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private static Point PhysicalToPixels(Point physical, Point dpi)
        {
            return new Point(PhysicalToPixels(physical.X, dpi.X), PhysicalToPixels(physical.Y, dpi.Y));
        }

        private static Size PhysicalToPixels(Size physicalSize, Point dpi)
        {
            return new Size(PhysicalToPixels(physicalSize.Width, dpi.X), PhysicalToPixels(physicalSize.Height, dpi.Y));
        }

        private static int PhysicalToPixels(int physicalSize, int dpi)
        {
            return (int)(((double)(physicalSize * dpi)) / 100.0);
        }

        private static Point PixelsToPhysical(Point pixels, Point dpi)
        {
            return new Point(PixelsToPhysical(pixels.X, dpi.X), PixelsToPhysical(pixels.Y, dpi.Y));
        }

        private static Size PixelsToPhysical(Size pixels, Point dpi)
        {
            return new Size(PixelsToPhysical(pixels.Width, dpi.X), PixelsToPhysical(pixels.Height, dpi.Y));
        }

        private static int PixelsToPhysical(int pixels, int dpi)
        {
            return (int)((pixels * 100.0) / ((double)dpi));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ResetBackColor()
        {
            this.BackColor = SystemColors.AppWorkspace;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ResetForeColor()
        {
            this.ForeColor = Color.White;
        }

        private void SetPositionNoInvalidate(Point value)
        {
            Point position = this.position;

            this.position = value;
            this.position.X = Math.Min(this.position.X, this.virtualSize.Width - base.Width);
            this.position.Y = Math.Min(this.position.Y, this.virtualSize.Height - base.Height);

            if (this.position.X < 0)
            {
                this.position.X = 0;
            }
            if (this.position.Y < 0)
            {
                this.position.Y = 0;
            }

            Rectangle clientRectangle = base.ClientRectangle;

            NativeMethods.RECT rectScrollRegion = NativeMethods.RECT.FromXYWH(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, clientRectangle.Height);
            SafeNativeMethods.ScrollWindow(new HandleRef(this, base.Handle), position.X - this.position.X, position.Y - this.position.Y, ref rectScrollRegion, ref rectScrollRegion);
            UnsafeNativeMethods.SetScrollPos(new HandleRef(this, base.Handle), 0, this.position.X, true);
            UnsafeNativeMethods.SetScrollPos(new HandleRef(this, base.Handle), 1, this.position.Y, true);
        }

        internal void SetVirtualSizeNoInvalidate(Size value)
        {
            this.virtualSize = value;
            this.SetPositionNoInvalidate(this.position);

            NativeMethods.SCROLLINFO si = new NativeMethods.SCROLLINFO
            {
                fMask = 3,
                nMin = 0,
                nMax = Math.Max(base.Height, this.virtualSize.Height) - 1,
                nPage = base.Height
            };

            UnsafeNativeMethods.SetScrollInfo(new HandleRef(this, base.Handle), 1, si, true);

            si.fMask = 3;
            si.nMin = 0;
            si.nMax = Math.Max(base.Width, this.virtualSize.Width) - 1;
            si.nPage = base.Width;

            UnsafeNativeMethods.SetScrollInfo(new HandleRef(this, base.Handle), 0, si, true);
        }

        private void WmHScroll(ref Message m)
        {
            if (m.LParam != IntPtr.Zero)
            {
                base.WndProc(ref m);
            }
            else
            {
                Point position = this.position;
                int x = position.X;
                int maxPos = Math.Max(base.Width, this.virtualSize.Width);
                position.X = this.AdjustScroll(m, x, maxPos, true);
                this.Position = position;
            }
        }

        private void WmKeyDown(ref Message msg)
        {
            Keys keys = ((Keys)((int)msg.WParam)) | Control.ModifierKeys;
            Point position = this.Position;
            int x = 0;
            int num2 = 0;
            switch ((keys & Keys.KeyCode))
            {
                case Keys.Prior:
                    if ((keys & ~Keys.KeyCode) != Keys.Control)
                    {
                        if (this.StartPage > 0)
                        {
                            this.StartPage--;
                        }
                        return;
                    }
                    x = position.X;
                    if (x <= 100)
                    {
                        x = 0;
                        break;
                    }
                    x -= 100;
                    break;

                case Keys.Next:
                    if ((keys & ~Keys.KeyCode) != Keys.Control)
                    {
                        if (this.StartPage < this.pageInfo.Length)
                        {
                            this.StartPage++;
                        }
                        return;
                    }
                    x = position.X;
                    num2 = Math.Max(base.Width, this.virtualSize.Width);
                    if (x >= (num2 - 100))
                    {
                        x = num2;
                    }
                    else
                    {
                        x += 100;
                    }
                    position.X = x;
                    this.Position = position;
                    return;

                case Keys.End:
                    if ((keys & ~Keys.KeyCode) == Keys.Control)
                    {
                        this.StartPage = this.pageInfo.Length;
                    }
                    return;

                case Keys.Home:
                    if ((keys & ~Keys.KeyCode) == Keys.Control)
                    {
                        this.StartPage = 0;
                    }
                    return;

                case Keys.Left:
                    x = position.X;
                    if (x <= 5)
                    {
                        x = 0;
                    }
                    else
                    {
                        x -= 5;
                    }
                    position.X = x;
                    this.Position = position;
                    return;

                case Keys.Up:
                    x = position.Y;
                    if (x <= 5)
                    {
                        x = 0;
                    }
                    else
                    {
                        x -= 5;
                    }
                    position.Y = x;
                    this.Position = position;
                    return;

                case Keys.Right:
                    x = position.X;
                    num2 = Math.Max(base.Width, this.virtualSize.Width);
                    if (x >= (num2 - 5))
                    {
                        x = num2;
                    }
                    else
                    {
                        x += 5;
                    }
                    position.X = x;
                    this.Position = position;
                    return;

                case Keys.Down:
                    x = position.Y;
                    num2 = Math.Max(base.Height, this.virtualSize.Height);
                    if (x >= (num2 - 5))
                    {
                        x = num2;
                    }
                    else
                    {
                        x += 5;
                    }
                    position.Y = x;
                    this.Position = position;
                    return;

                default:
                    return;
            }

            position.X = x;
            this.Position = position;
        }

        private void WmVScroll(ref Message m)
        {
            if (m.LParam != IntPtr.Zero)
            {
                base.WndProc(ref m);
            }
            else
            {
                Point position = this.Position;
                int y = position.Y;
                int maxPos = Math.Max(base.Height, this.virtualSize.Height);

                position.Y = this.AdjustScroll(m, y, maxPos, false);

                this.Position = position;
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x114:
                    this.WmHScroll(ref m);
                    return;

                case 0x115:
                    this.WmVScroll(ref m);
                    return;

                case 0x100:
                    this.WmKeyDown(ref m);
                    return;
            }
            base.WndProc(ref m);
        }

        [DefaultValue(true)]
        public bool AutoZoom
        {
            get
            {
                return this.autoZoom;
            }
            set
            {
                if (this.autoZoom != value)
                {
                    this.autoZoom = value;
                    this.InvalidateLayout();
                }
            }
        }

        [DefaultValue(1)]
        public int Columns
        {
            get
            {
                return this.columns;
            }
            set
            {
                if (value < 1)
                {
                    object[] args = new object[] { "Columns", value.ToString(CultureInfo.CurrentCulture), 1.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("Columns", String.Format("InvalidLowBoundArgument=Value of '{1}' is not valid for '{0}'. '{0}' must be greater than {2}.", args));
                }

                this.columns = value;
                this.InvalidateLayout();
            }
        }

        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.Style |= 0x100000;
                createParams.Style |= 0x200000;
                return createParams;
            }
        }

        [DefaultValue((string)null)]
        public PrintDocument Document
        {
            get
            {
                return this.document;
            }
            set
            {
                this.document = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        private Point Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.SetPositionNoInvalidate(value);
            }
        }

        [AmbientValue(2), Localizable(true)]
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                this.InvalidatePreview();
            }
        }

        [DefaultValue(1)]
        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                if (value < 1)
                {
                    object[] args = new object[] { "Rows", value.ToString(CultureInfo.CurrentCulture), 1.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("Rows", String.Format("InvalidLowBoundArgumentEx=Value of '{1}' is not valid for '{0}'. '{0}' must be greater than or equal to {2}.", args));
                }
                this.rows = value;
                this.InvalidateLayout();
            }
        }

        [DefaultValue(0)]
        public int StartPage
        {
            get
            {
                int startPage = this.startPage;

                if (this.pageInfo != null)
                {
                    startPage = Math.Min(startPage, this.pageInfo.Length - (this.rows * this.columns));
                }

                return Math.Max(startPage, 0);
            }
            set
            {
                if (value < 0)
                {
                    object[] args = new object[] { "StartPage", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("StartPage", String.Format("InvalidLowBoundArgumentEx=Value of '{1}' is not valid for '{0}'. '{0}' must be greater than or equal to {2}.", args));
                }

                int startPage = this.StartPage;
                this.startPage = value;

                if (startPage != this.startPage)
                {
                    this.InvalidateLayout();
                    this.OnStartPageChanged(EventArgs.Empty);
                }
            }
        }

        [Bindable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [DefaultValue(false)]
        public bool UseAntiAlias
        {
            get
            {
                return this.antiAlias;
            }
            set
            {
                this.antiAlias = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        private Size VirtualSize
        {
            get
            {
                return this.virtualSize;
            }
            set
            {
                this.SetVirtualSizeNoInvalidate(value);
                base.Invalidate();
            }
        }

        [DefaultValue((double)0.3)]
        public double Zoom
        {
            get
            {
                return this.zoom;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("PrintPreviewControlZoomNegative=Zoom must be 0 or greater. Negative values are not permitted.");
                }

                this.autoZoom = false;
                this.zoom = value;

                this.InvalidateLayout();
            }
        }


        private static ContentAlignment anyRight = ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight;
        private static ContentAlignment anyBottom = ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft;
        private static ContentAlignment anyCenter = ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter;
        private static ContentAlignment anyMiddle = ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft;


        internal static StringAlignment TranslateAlignment(ContentAlignment align)
        {
            if ((align & anyRight) != ((ContentAlignment)0))
            {
                return StringAlignment.Far;
            }

            if ((align & anyCenter) != ((ContentAlignment)0))
            {
                return StringAlignment.Center;
            }

            return StringAlignment.Near;
        }

        internal static StringAlignment TranslateLineAlignment(ContentAlignment align)
        {
            if ((align & anyBottom) != ((ContentAlignment)0))
            {
                return StringAlignment.Far;
            }

            if ((align & anyMiddle) != ((ContentAlignment)0))
            {
                return StringAlignment.Center;
            }

            return StringAlignment.Near;
        }


    }
}