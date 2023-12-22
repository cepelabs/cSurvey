Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cDesignInfoBox
        Inherits cDesignGeneric

        Private oSurvey As cSurvey

        Public Overrides Function GetBounds(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline) As RectangleF
            Dim sBoxWidth As Single
            Dim sBoxHeight As Single

            Dim sBoxDefaultWidth As Single
            If Graphics.PageUnit = GraphicsUnit.Pixel Then
                sBoxDefaultWidth = PaintOptions.InfoBoxOptions.Width
            Else
                sBoxDefaultWidth = PrinterUnitConvert.Convert(PaintOptions.InfoBoxOptions.Width, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch)
            End If

            Dim bBoxAutoSize As Boolean
            If sBoxDefaultWidth = 0 Then
                bBoxAutoSize = True
                sBoxDefaultWidth = Graphics.VisibleClipBounds.Width / 3
            End If

            Dim sID As String = oSurvey.Properties.ID.ToUpper
            Dim sName As String = oSurvey.Properties.Name.ToUpper
            Dim oTitleSF As StringFormat = New StringFormat
            oTitleSF.LineAlignment = StringAlignment.Center
            oTitleSF.FormatFlags = StringFormatFlags.NoWrap

            Dim oFont As Font = PaintOptions.InfoBoxOptions.TextFont.GetFont(PaintOptions)
            Dim oTitleFont1 As Font = PaintOptions.InfoBoxOptions.IDFont.GetFont(PaintOptions)
            Dim oTitleFont2 As Font = PaintOptions.InfoBoxOptions.TitleFont.GetFont(PaintOptions)

            Dim bIDVisible As Boolean = PaintOptions.InfoBoxOptions.IDVisible
            Dim bTitleVisible As Boolean = PaintOptions.InfoBoxOptions.TitleVisible
            Dim bTextVisible As Boolean = PaintOptions.InfoBoxOptions.TextVisible

            Dim oIDSize As SizeF
            If bIDVisible Then
                oIDSize = Graphics.MeasureString(sID, oTitleFont1)
            Else
                oIDSize = New SizeF(0, 0)
            End If
            Dim oTitleSize As SizeF
            If bTitleVisible Then
                oTitleSize = Graphics.MeasureString(sName, oTitleFont2)
            Else
                oTitleSize = New SizeF(0, 0)
            End If
            If bBoxAutoSize Then
                sBoxWidth = oIDSize.Width + oTitleSize.Width + 32
                If sBoxWidth < sBoxDefaultWidth Then sBoxWidth = sBoxDefaultWidth
            Else
                sBoxWidth = sBoxDefaultWidth
            End If
            sBoxHeight = IIf(oIDSize.Height > oTitleSize.Height, oIDSize.Height, oTitleSize.Height)
            sBoxHeight += 8

            Dim oSF As StringFormat = New StringFormat
            oSF.LineAlignment = StringAlignment.Near
            oSF.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap

            If bTextVisible Then
                Dim sInfo As String = oSurvey.Properties.GetFormattedInfoBoxText
                Dim oBoxTextSize As SizeF = Graphics.MeasureString(sInfo, oFont, sBoxWidth, oSF)
                sBoxHeight += sBoxHeight + oBoxTextSize.Height
            End If

            Call oSF.Dispose()

            Return New RectangleF(0, 0, sBoxWidth, sBoxHeight)
        End Function

        Public Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    Dim oItem As cDrawCacheItem

                    Dim oPreviewOptions As cOptionsCenterline = PaintOptions
                    Dim sBoxWidth As Single
                    Dim sBoxHeight As Single
                    'Dim iBoxDefaultWidth As Integer = PaintOptions.InfoBoxOptions.Width
                    Dim sBoxDefaultWidth As Single
                    If Graphics.PageUnit = GraphicsUnit.Pixel Then
                        sBoxDefaultWidth = PaintOptions.InfoBoxOptions.Width
                    Else
                        sBoxDefaultWidth = PrinterUnitConvert.Convert(PaintOptions.InfoBoxOptions.Width, PrinterUnit.TenthsOfAMillimeter, PrinterUnit.ThousandthsOfAnInch)
                    End If

                    Dim bBoxAutoSize As Boolean
                    If sBoxDefaultWidth = 0 Then
                        bBoxAutoSize = True
                        sBoxDefaultWidth = Graphics.VisibleClipBounds.Width / 3
                    End If

                    Dim sID As String = oSurvey.Properties.ID.ToUpper
                    Dim sName As String = oSurvey.Properties.Name.ToUpper
                    Using oTitleSF As StringFormat = New StringFormat
                        oTitleSF.LineAlignment = StringAlignment.Center
                        oTitleSF.FormatFlags = StringFormatFlags.NoWrap
                        Dim oFont As Font = oPreviewOptions.InfoBoxOptions.TextFont.GetFont(PaintOptions)
                        Using oBrush As SolidBrush = New SolidBrush(oPreviewOptions.InfoBoxOptions.TextFont.Color)

                            Dim bIDVisible As Boolean = PaintOptions.InfoBoxOptions.IDVisible
                            Dim bTitleVisible As Boolean = PaintOptions.InfoBoxOptions.TitleVisible
                            Dim bTextVisible As Boolean = PaintOptions.InfoBoxOptions.TextVisible

                            Dim oTitleFont1 As Font = oPreviewOptions.InfoBoxOptions.IDFont.GetFont(PaintOptions)
                            Using oTitleBrush1 As SolidBrush = New SolidBrush(oPreviewOptions.InfoBoxOptions.IDFont.Color)
                                Dim oTitleFont2 As Font = oPreviewOptions.InfoBoxOptions.TitleFont.GetFont(PaintOptions)
                                Using oTitleBrush2 As SolidBrush = New SolidBrush(oPreviewOptions.InfoBoxOptions.TitleFont.Color)

                                    Dim oIDSize As SizeF
                                    If bIDVisible Then
                                        oIDSize = Graphics.MeasureString(sID, oTitleFont1)
                                    Else
                                        oIDSize = New SizeF(0, 0)
                                    End If
                                    Dim oTitleSize As SizeF
                                    If bTitleVisible Then
                                        oTitleSize = Graphics.MeasureString(sName, oTitleFont2)
                                    Else
                                        oTitleSize = New SizeF(0, 0)
                                    End If
                                    If bBoxAutoSize Then
                                        sBoxWidth = oIDSize.Width + oTitleSize.Width + 32
                                        If sBoxWidth < sBoxDefaultWidth Then sBoxWidth = sBoxDefaultWidth
                                    Else
                                        sBoxWidth = sBoxDefaultWidth
                                    End If
                                    sBoxHeight = IIf(oIDSize.Height > oTitleSize.Height, oIDSize.Height, oTitleSize.Height)
                                    sBoxHeight += 8

                                    Dim oBoxBounds As RectangleF = New RectangleF(Location.X, Location.Y, sBoxWidth, sBoxHeight)
                                    Dim oTitleBounds As RectangleF = New RectangleF(Location.X, Location.Y, sBoxWidth, sBoxHeight)

                                    If bIDVisible Then
                                        Dim oTitleBounds1 As RectangleF = New RectangleF(Location.X, Location.Y, oIDSize.Width, sBoxHeight)
                                        oItem = .Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                        Call oItem.SetBrush(oTitleBrush1)
                                        Call oItem.AddString(sID, oTitleFont1, oTitleBounds1, oTitleSF)
                                    End If

                                    If bTitleVisible Then
                                        Dim oTitleBounds2 As RectangleF = New RectangleF(Location.X + IIf(bIDVisible, oIDSize.Width + 8, 0), Location.Y, oTitleSize.Width, sBoxHeight)
                                        oItem = .Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                        Call oItem.SetBrush(oTitleBrush2)
                                        Call oItem.AddString(sName, oTitleFont2, oTitleBounds2, oTitleSF)
                                    End If

                                    If bTextVisible Then
                                        Using oSF As StringFormat = New StringFormat
                                            oSF.LineAlignment = StringAlignment.Near
                                            Dim sInfo As String = oSurvey.Properties.GetFormattedInfoBoxText
                                            Dim oBoxTextSize As SizeF = Graphics.MeasureString(sInfo, oFont, sBoxWidth, oSF)
                                            Dim oBoxInfoBounds As RectangleF = New RectangleF(Location.X, Location.Y + sBoxHeight, sBoxWidth, oBoxTextSize.Height)
                                            oItem = .Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                            Call oItem.SetBrush(oBrush)
                                            Call oItem.AddString(sInfo, oFont, oBoxInfoBounds, oSF)
                                        End Using
                                    End If
                                End Using
                            End Using
                        End Using
                    End Using

                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            Call MyBase.new(Survey, "infobox")
            oSurvey = Survey
        End Sub

        Friend Class cParameters
        End Class

        Friend Overrides Sub Rebind(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal ViewArea As RectangleF, ByVal Parameters As Object)
            Call MyBase.Caches.Invalidate()
            Dim oBoxSize As SizeF = GetBounds(Graphics, PaintOptions).Size
            Select Case PaintOptions.BoxPosition
                Case cOptionsDesign.AlignmentEnum.TopLeft
                    MyBase.Location = New PointF(ViewArea.Left + 2, ViewArea.Top + 2)
                Case cOptionsDesign.AlignmentEnum.TopRight
                    MyBase.Location = New PointF(ViewArea.Right - 2 - oBoxSize.Width, ViewArea.Top + 2)
                Case cOptionsDesign.AlignmentEnum.BottomLeft
                    MyBase.Location = New PointF(ViewArea.Left + 2, ViewArea.Bottom - 2 - oBoxSize.Height)
                Case cOptionsDesign.AlignmentEnum.BottomRight
                    MyBase.Location = New PointF(ViewArea.Right - 2 - oBoxSize.Width, ViewArea.Bottom - 2 - oBoxSize.Height)
            End Select
            Call Render(Graphics, PaintOptions)
        End Sub
    End Class
End Namespace