Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cDesignCompass
        Inherits cDesignGeneric

        Private oSurvey As cSurvey

        Public Overrides Function GetBounds(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline) As RectangleF
            Select Case PaintOptions.CompassStyle
                Case cOptionsDesign.CompassStyleEnum.Simple
                    Dim iBorder As Integer = 4
                    Dim iRadius As Integer = 40
                    Dim iRadiusFactor As Integer = 5
                    Return New RectangleF(0, 0, iRadiusFactor * 2 + iBorder * 2, iRadius + iBorder * 2)
                Case cOptionsDesign.CompassStyleEnum.Advanced
                    Dim oClipart As cDrawClipArt = PaintOptions.CompassOptions.Clipart
                    Dim oMatrix As Matrix = New Matrix
                    Call oMatrix.Scale(PaintOptions.CompassOptions.ClipartZoomFactor, PaintOptions.CompassOptions.ClipartZoomFactor)
                    Dim oRect As RectangleF = oClipart.TransformPaths(oMatrix).GetBounds
                    Call oMatrix.Dispose()
                    Return oRect
            End Select
        End Function

        Public Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    Dim oItem As cDrawCacheItem
                    Select Case PaintOptions.CompassStyle
                        Case cOptionsDesign.CompassStyleEnum.Simple
                            oItem = oCache.AddBorder
                            Dim iBorder As Integer = 4
                            Dim iRadius As Integer = 40
                            Dim iRadiusFactor As Integer = 5
                            Dim iSize As Integer = iRadius * 2
                            Using oArrowPen As Pen = New Pen(Color.Black, cEditPaintObjects.FilettoPenWidth)
                                Using oArrowBrush As Brush = New SolidBrush(Color.Black)
                                    Dim iPosX As Integer = Location.X + iRadiusFactor + iBorder
                                    Dim iPosY As Integer = Location.Y
                                    Dim oPoints(3) As PointF
                                    oPoints(0) = New Point(iPosX, iPosY - iRadius)
                                    oPoints(1) = New Point(iPosX - iRadius / iRadiusFactor, iPosY + iRadius / iRadiusFactor)
                                    oPoints(2) = New Point(iPosX, iPosY)
                                    oPoints(3) = New Point(iPosX + iRadius / iRadiusFactor, iPosY + iRadius / iRadiusFactor)
                                    Call oItem.SetBrush(oArrowBrush)
                                    Call oItem.SetPen(oArrowPen)
                                    Call oItem.AddPolygon(oPoints)
                                    Using oSF As StringFormat = New StringFormat
                                        oSF.Alignment = StringAlignment.Center
                                        oSF.LineAlignment = StringAlignment.Center
                                        Call oItem.AddString("N", New Font("Tahoma", 12, FontStyle.Bold), New RectangleF(iPosX - iRadius, iPosY - iRadius - 16, iRadius * 2, 16), oSF)
                                    End Using
                                End Using
                            End Using
                        Case cOptionsDesign.CompassStyleEnum.Advanced
                            Using oPen As Pen = New Pen(PaintOptions.CompassOptions.Color, cEditPaintObjects.FilettoPenWidth)
                                Using oForeColorBrush As Brush = New SolidBrush(PaintOptions.CompassOptions.Color)
                                    Using oBackColorBrush As Brush = New SolidBrush(Color.White) 'PaintOptions.PageColor)
                                        Dim oClipart As cDrawClipArt = PaintOptions.CompassOptions.Clipart
                                        Using oMatrix As Matrix = New Matrix
                                            Call oMatrix.Translate(Location.X, Location.Y)
                                            Call oMatrix.Scale(PaintOptions.CompassOptions.ClipartZoomFactor, PaintOptions.CompassOptions.ClipartZoomFactor)
                                            Using oPaths As cDrawPaths = oClipart.TransformPaths(oMatrix)
                                                For Each oDrawPath As cDrawPath In oPaths
                                                    oItem = oCache.AddBorder
                                                    Using oPath As GraphicsPath = oDrawPath.Path '.Clone
                                                        Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                                                        If sFill <> "none" Then
                                                            Dim oColor As Color = Color.Transparent
                                                            Try
                                                                oColor = ColorTranslator.FromHtml(sFill)
                                                            Catch
                                                            End Try
                                                            If oColor.ToArgb = Color.White.ToArgb Then
                                                                Call oItem.SetBrush(oBackColorBrush)
                                                            Else
                                                                Call oItem.SetBrush(oForeColorBrush)
                                                            End If
                                                        End If
                                                        Call oItem.SetPen(oPen)
                                                        Call oItem.AddPath(oPath)
                                                    End Using
                                                Next
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                    End Select
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Function ToSvgItem(ByVal SVG As cSVGWriter, ByVal PaintOptions As cOptionsCenterline) As XmlElement
            Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions)
            Call oSVGItem.SetAttribute("id", MyBase.Name)
            Return oSVGItem
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cSVGWriter.SVGOptionsEnum) As XmlDocument
            Dim oSVG As cSVGWriter = modSVG.CreateSVG(Options)
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions))
            Return oSVG
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            Call MyBase.new(Survey, "compass")
            oSurvey = Survey
        End Sub

        Friend Class cParameters
        End Class

        Friend Overrides Sub Rebind(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal ViewArea As RectangleF, ByVal Parameters As Object)
            Call MyBase.Caches.Invalidate()
            Dim oCompassSize As SizeF = GetBounds(Graphics, PaintOptions).Size
            Select Case PaintOptions.CompassPosition
                Case cOptionsDesign.AlignmentEnum.TopLeft
                    MyBase.Location = New PointF(ViewArea.Left + 2, ViewArea.Top + 2)
                Case cOptionsDesign.AlignmentEnum.TopRight
                    MyBase.Location = New PointF(ViewArea.Right - 2 - oCompassSize.Width, ViewArea.Top + 2)
                Case cOptionsDesign.AlignmentEnum.BottomLeft
                    MyBase.Location = New PointF(ViewArea.Left + 2, ViewArea.Bottom - 2 - oCompassSize.Height)
                Case cOptionsDesign.AlignmentEnum.BottomRight
                    MyBase.Location = New PointF(ViewArea.Right - 2 - oCompassSize.Width, ViewArea.Bottom - 2 - oCompassSize.Height)
            End Select
            Call Render(Graphics, PaintOptions)
        End Sub
    End Class
End Namespace
