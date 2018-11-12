Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class cRegion
    Implements IDisposable
    Private iMinImageSize As Integer = 10

    Private oRect As RectangleF
    Private oScaledRect As RectangleF
    Private sScale As Single
    Private oMatrix As Matrix

    'Private oGraphics As Graphics
    'Private oImage As Bitmap

    Private oBits As Byte(,)

    Public Event OnImageUpdated(Sender As cRegion, Args As EventArgs)

    Private Function pGetImageFromBitMatrix(Bits As Byte(,)) As Image
        Dim iWidth As Integer = Bits.GetLength(0)
        Dim iHeight As Integer = Bits.GetLength(1)
        Dim oImage As Bitmap = New Bitmap(iWidth, iHeight)
        For iX As Integer = 0 To iWidth - 1
            For iY As Integer = 0 To iHeight - 1
                If Bits(iX, iY) Then
                    Call oImage.SetPixel(iX, iY, Color.Black)
                End If
            Next
        Next
        Return oImage
    End Function

    Private Function pGetBitMatrixFromImage(Image As Bitmap) As Byte(,)
        Dim iWidth As Integer = Image.Width
        Dim iHeight As Integer = Image.Height
        Dim oBits As Byte(,) = pGetEmptyBitMatrix(iWidth, iHeight)
        For x As Integer = 0 To iWidth - 1
            For y As Integer = 0 To iHeight - 1
                If Image.GetPixel(x, y).ToArgb = 0 Then
                    oBits(x, y) = True
                End If
            Next
        Next
        Return oBits
    End Function

    Private Function pGetEmptyBitMatrix(Width As Integer, Height As Integer) As Byte(,)
        Dim oBits(Width, Height) As Byte
        Return oBits
    End Function

    Private Sub pMergeBitMatrix(Matrix1 As Byte(,), Matrix2 As Byte(,), X As Integer, Y As Integer)
        For iX As Integer = X To Matrix2.GetLength(0) - 1
            For iY As Integer = Y To Matrix2.GetLength(1) - 1
                Matrix1(iX, iY) = Matrix1(iX, iY) And Matrix2(iX - X, iY - Y)
            Next
        Next
    End Sub

    Private Function pIntersectBitMatrix(Matrix1 As Byte(,), Matrix2 As Byte(,), X As Integer, Y As Integer) As Boolean
        For iX As Integer = X To Matrix2.GetLength(0) - 1
            For iY As Integer = Y To Matrix2.GetLength(1) - 1
                If Matrix1(iX, iY) And Matrix2(iX - X, iY - Y) Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Public ReadOnly Property Image As Bitmap
        Get
            'Return oImage
            Return pgetimagefrombitmatrix(oBits)
        End Get
    End Property

    Private Function pGetPathImage(path As GraphicsPath, ByRef PathRect As Rectangle) As Image
        Dim oPath As GraphicsPath = path.Clone
        Call oPath.Transform(oMatrix)
        PathRect = Rectangle.Truncate(oPath.GetBounds)
        Dim iImageWidth As Integer = oScaledRect.Width
        Dim iImageHeight As Integer = oScaledRect.Height
        Dim oPathImage As Bitmap = New Bitmap(iImageWidth, iImageHeight)
        Dim oPathGraphics As Graphics = Graphics.FromImage(oPathImage)
        oPathGraphics.CompositingQuality = CompositingQuality.HighSpeed
        oPathGraphics.SmoothingMode = SmoothingMode.AntiAlias
        Call oPathGraphics.FillPath(Brushes.Black, oPath)
        Call oPath.Dispose()
        Call oPathGraphics.Dispose()
        Return oPathImage
    End Function

    Public Sub Add(Path As GraphicsPath)
        Dim oPathRect As Rectangle
        Dim oPathImage As Bitmap = pGetPathImage(Path, oPathRect)
        Dim oPathBits As Byte(,) = pGetBitMatrixFromImage(oPathImage)
        Call pMergeBitMatrix(oBits, oPathBits, oPathRect.X, oPathRect.Y)
        'Call oGraphics.FillPath(Brushes.Black, Path)
        'RaiseEvent OnImageUpdated(Me, New EventArgs)

        'Dim oPathRect As RectangleF = Path.GetBounds
        'Dim oScaledPathRect As RectangleF = New RectangleF(oPathRect.X * sScale, oPathRect.Y * sScale, oPathRect.Width * sScale, oPathRect.Height * sScale)
        'If oScaledRect.Contains(oScaledPathRect) Then
        '    Dim iImageWidth As Integer = oScaledRect.Width
        '    Dim iImageHeight As Integer = oScaledRect.Height
        '    If iImageWidth < iMinImageSize Then iImageWidth = iMinImageSize
        '    If iImageHeight < iMinImageSize Then iImageHeight = iMinImageSize
        '    Dim oPathImage As Bitmap = New Bitmap(iImageWidth, iImageHeight)
        '    Dim oPathGraphics As Graphics = Graphics.FromImage(oPathImage)
        '    oPathGraphics.CompositingQuality = CompositingQuality.HighSpeed
        '    oPathGraphics.SmoothingMode = SmoothingMode.AntiAlias
        '    Call oGraphics.Clear(Color.White)
        '    Dim oPath As GraphicsPath = Path.Clone
        '    Dim oMatrix As Matrix = New Matrix
        '    Call oMatrix.Translate(-oPathRect.X, -oPathRect.Y)
        '    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
        '    Call oPath.Transform(oMatrix)
        '    Call oPathGraphics.FillPath(Brushes.Black, oPath)
    End Sub

    Public Function Intersect(Path As GraphicsPath) As Boolean
        Dim oPathRect As Rectangle
        Dim oPathImage As Bitmap = pGetPathImage(Path, oPathRect)
        Dim oPathBits As Byte(,) = pGetBitMatrixFromImage(oPathImage)
        Return pIntersectBitMatrix(oBits, oPathBits, oPathRect.X, oPathRect.Y)

        'Dim oPathRect As RectangleF = Path.GetBounds
        'Dim oScaledPathRect As RectangleF = New RectangleF(oPathRect.X * sScale, oPathRect.Y * sScale, oPathRect.Width * sScale, oPathRect.Height * sScale)
        'If oScaledRect.Contains(oScaledPathRect) Then
        '    Dim iImageWidth As Integer = oScaledRect.Width
        '    Dim iImageHeight As Integer = oScaledRect.Height
        '    If iImageWidth < iMinImageSize Then iImageWidth = iMinImageSize
        '    If iImageHeight < iMinImageSize Then iImageHeight = iMinImageSize
        '    Dim oPathImage As Bitmap = New Bitmap(iImageWidth, iImageHeight)
        '    Dim oPathGraphics As Graphics = Graphics.FromImage(oImage)
        '    oPathGraphics.CompositingQuality = CompositingQuality.HighSpeed
        '    oPathGraphics.SmoothingMode = SmoothingMode.AntiAlias
        '    Call oGraphics.Clear(Color.White)
        '    Dim oPath As GraphicsPath = Path.Clone
        '    Dim oMatrix As Matrix = New Matrix
        '    Call oMatrix.Translate(-oPathRect.X, -oPathRect.Y)
        '    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
        '    Call oPath.Transform(oMatrix)
        '    Call oPathGraphics.FillPath(Brushes.Black, oPath)

        '    Dim iWhite As Integer = Color.White.ToArgb
        '    For x As Integer = 0 To oScaledPathRect.Width - 1
        '        For y As Integer = 0 To oScaledPathRect.Height - 1
        '            If oPathImage.GetPixel(x, y).ToArgb <> iWhite Then
        '                If oImage.GetPixel(oScaledPathRect.X - oScaledRect.X + x, oScaledPathRect.Y - oScaledRect.Y + y).ToArgb <> iWhite Then
        '                    Return True
        '                End If
        '            End If
        '        Next
        '    Next
        'Else
        '    Return False
        'End If

        'Dim oPathRect As RectangleF = Path.GetBounds
        'Dim oScaledPathRect As RectangleF = New RectangleF(oPathRect.X * sScale, oPathRect.Y * sScale, oPathRect.Width * sScale, oPathRect.Height * sScale)
        'If oScaledRect.Contains(oScaledPathRect) Then
        '    For x As Integer = 0 To oScaledPathRect.Width - 1
        '        For y As Integer = 0 To oScaledPathRect.Height - 1
        '            If oImage.GetPixel(oScaledPathRect.X - oScaledRect.X + x, oScaledPathRect.Y - oScaledRect.Y + y).ToArgb <> Color.White.ToArgb Then
        '                Return True
        '            End If
        '        Next
        '    Next
        '    Return False
        'Else
        '    Return True
        'End If
    End Function

    Public Sub New(Rectangle As RectangleF, Scale As Single)
        oRect = Rectangle
        sScale = Scale

        oMatrix = New Matrix
        Call oMatrix.Translate(-oRect.X, -oRect.Y)
        Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)

        oScaledRect = New Rectangle(oRect.X * sScale, oRect.Y * sScale, oRect.Width * sScale, oRect.Height * sScale)

        Dim iImageWidth As Integer = oScaledRect.Width
        Dim iImageHeight As Integer = oScaledRect.Height
        oBits = pGetEmptyBitMatrix(iImageWidth, iImageHeight)

        'If iImageWidth < iMinImageSize Then iImageWidth = iMinImageSize
        'If iImageHeight < iMinImageSize Then iImageHeight = iMinImageSize
        'oImage = New Bitmap(iImageWidth, iImageHeight)
        'oGraphics = Graphics.FromImage(oImage)
        'oGraphics.CompositingQuality = CompositingQuality.HighSpeed
        'oGraphics.SmoothingMode = SmoothingMode.AntiAlias
        'Call oGraphics.Clear(Color.White)

        RaiseEvent OnImageUpdated(Me, New EventArgs)
    End Sub

    Protected Overrides Sub Finalize()
        Call oMatrix.Dispose()
        'Call oImage.Dispose()
        'Call oGraphics.Dispose()
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Call oMatrix.Dispose()
        'Call oImage.Dispose()
        'Call oGraphics.Dispose()
    End Sub
End Class
