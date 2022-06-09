Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

friend Class frmSVGImportOptions
    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private oOptions As cSurveyPC.cSurvey.Design.Items.cItemGeneric.cItemGenericOptions
    Private oClipart As cDrawClipArt

    Private bDisableEvent As Boolean

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, ByVal options As cSurveyPC.cSurvey.Design.Items.cItemGeneric.cItemGenericOptions, ByVal Clipart As cDrawClipArt)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        oOptions = options
        oClipart = Clipart

        bDisableEvent = True
        txtSVGPathMaxLen.Value = options.MaxPathLen
        txtSVGScale.Value = options.Scale
        cboSVGLineType.SelectedIndex = options.LineType
        chkSVGAutodivide.Checked = options.Divide
        bDisableEvent = False

        Call pPreviewDraw()
    End Sub

    Private Sub pPreviewDraw()
        If Not bDisableEvent Then
            Try
                Dim sWidth As Single = picPreview.Width * 0.9
                Dim sHeight As Single = picPreview.Height * 0.9

                Dim oImage As Bitmap = New Bitmap(CInt(sWidth), CInt(sHeight))
                Dim oGraphics As Graphics = Graphics.FromImage(oImage)
                oGraphics.CompositingQuality = CompositingQuality.HighQuality
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias
                oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic

                Dim oRect As RectangleF = oClipart.GetBounds
                'Call oRect.Inflate(-1, -1)
                Dim sDX As Single = oRect.Width / sWidth
                Dim sDY As Single = oRect.Height / sHeight
                Dim sD As Single = 1 / If(sDX > sDY, sDX, sDY)

                Dim oMatrix As Matrix = New Matrix
                If sD <> 1 Then
                    Call oMatrix.Scale(sD, sD, MatrixOrder.Append)
                End If
                Call oMatrix.Translate((sWidth - (oRect.Width * sD)) / 2, (sHeight - (oRect.Height * sD)) / 2, MatrixOrder.Append)

                Dim oForePen As Pen = New Pen(Color.Black, cSurvey.cEditPaintObjects.FilettoPenWidth)
                Dim oForeBrush As SolidBrush = New SolidBrush(Color.Black)
                Dim oBackbrush As SolidBrush = New SolidBrush(Color.White)
                For Each oDrawPath As cDrawPath In oClipart.Paths
                    Dim oClipartPath As GraphicsPath = oDrawPath.Path.Clone
                    If oClipartPath.PathPoints.Count > txtSVGPathMaxLen.Value Then
                        oForePen.Color = Color.Red
                        oBackbrush.Color = Color.Red
                    Else
                        oForePen.Color = Color.Black
                        oBackbrush.Color = Color.Black
                    End If
                    Call oClipartPath.Transform(oMatrix)
                    Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                    If sFill <> "none" Then
                        Dim oColor As Color = Color.Transparent
                        Try
                            oColor = ColorTranslator.FromHtml(sFill)
                        Catch
                        End Try
                        If oColor.ToArgb = Color.White.ToArgb Then
                            Call oGraphics.FillPath(oBackbrush, oClipartPath)
                        Else
                            Call oGraphics.FillPath(oForeBrush, oClipartPath)
                        End If
                    End If
                    Call oGraphics.DrawPath(oForePen, oClipartPath)
                Next

                picPreview.Image = oImage

                Dim sScale As Single = txtSVGScale.Value
                txtSize.Text = modnumbers.mathround(oRect.Width * sScale, 2) & " x " & modnumbers.mathround(oRect.Height * sScale, 2) & " m"
            Catch
            End Try
        End If
    End Sub

    Private Sub txtSVGPathMaxLen_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSVGPathMaxLen.ValueChanged
        Call pPreviewDraw()
    End Sub

    Private Sub txtSVGScale_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSVGScale.ValueChanged
        Call pPreviewDraw()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        oOptions.MaxPathLen = txtSVGPathMaxLen.Value
        oOptions.LineType = cboSVGLineType.SelectedIndex
        oOptions.Divide = chkSVGAutodivide.Checked
        oOptions.Scale = txtSVGScale.Value
    End Sub
End Class