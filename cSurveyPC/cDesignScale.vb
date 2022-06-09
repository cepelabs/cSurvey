Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cDesignScale
        Inherits cDesignGeneric

        Private oSurvey As cSurvey
        Private sZoom As Single

        Public Property Zoom As Single
            Get
                Return sZoom
            End Get
            Set(ByVal value As Single)
                sZoom = value
            End Set
        End Property

        Public Overrides Function GetBounds(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline) As RectangleF
            Select Case PaintOptions.ScaleStyle
                Case cOptionsDesign.ScaleStyleEnum.Simple
                    Dim iMeters As Integer = 10
                    Dim iSteps As Integer = 10
                    Return New RectangleF(0F, 0F, iMeters * sZoom, 24.0F)
                Case cOptionsDesign.ScaleStyleEnum.Advanced
                    Dim iMeters As Integer = PaintOptions.ScaleOptions.Meters
                    Dim iSteps As Integer = iMeters / PaintOptions.ScaleOptions.Steps
                    Dim istep As Integer = PaintOptions.ScaleOptions.Step

                    Dim oScaleFont As Font = PaintOptions.ScaleOptions.Font.GetFont(PaintOptions)
                    Using oScaleMeterFont As Font = New Font(oScaleFont.Name, oScaleFont.Size * 0.6F, FontStyle.Regular)

                        Dim sScaleValue As String = PaintOptions.ScaleOptions.Text
                        If Not PaintOptions.ScaleOptions.HideScaleValue Then
                            If sScaleValue <> "" Then sScaleValue = sScaleValue & " "
                            sScaleValue = sScaleValue & "1:" & modPaint.GetScaleFactor(Graphics, Zoom)
                        End If
                        If sScaleValue = "" Then sScaleValue = " "
                        Dim oScaleValueSize As SizeF = Graphics.MeasureString(sScaleValue, oScaleFont)
                        Dim oScaleMeterSize As SizeF = Graphics.MeasureString(iMeters, oScaleMeterFont)

                        Return New RectangleF(0, 0, iMeters * sZoom + oScaleMeterSize.Width * 2.0F, oScaleValueSize.Height + oScaleMeterSize.Height + oScaleValueSize.Height / 2.0F + 8.0F)
                    End Using
            End Select
        End Function

        Public Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated Then
                    Call .Clear()
                    Dim oItem As cDrawCacheItem
                    Select Case PaintOptions.ScaleStyle
                        Case cOptionsDesign.ScaleStyleEnum.Simple
                            Dim iMeters As Integer = 10
                            Dim iSteps As Integer = 10

                            Dim oScaleFont As Font = PaintOptions.ScaleOptions.Font.GetFont(PaintOptions)
                            Dim sScaleValue As String = iMeters & " m " & "1:" & modPaint.GetScaleFactor(Graphics, Zoom)
                            Dim oScaleValueSize As SizeF = Graphics.MeasureString(sScaleValue, oScaleFont)

                            Using oScalePen1 As Pen = New Pen(Color.Gray, cEditPaintObjects.FilettoPenWidth)
                                Using oScalePen2 As Pen = New Pen(Color.Black, cEditPaintObjects.FilettoPenWidth)
                                    Using oScalebrush As Brush = New SolidBrush(Color.Gray)

                                        Dim sScaleStepLeftX As Single = Location.X
                                        Dim sScaleLeftX As Single = Location.X
                                        Dim sScaleLeftY As Single = Location.Y
                                        Dim sScaleWidth As Single = iMeters * Zoom
                                        Dim sScaleStepWidth As Single = sScaleWidth / iSteps

                                        oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                        For iScaleStepIndex As Integer = 0 To iSteps - 1
                                            If iScaleStepIndex Mod 2 = 0 Then
                                                'Graphics.DrawLine(oScalePen1, sScaleStepLeftX, sScaleLeftY, sScaleStepLeftX + sScaleStepWidth, sScaleLeftY)
                                                Call oItem.SetPen(oScalePen1)
                                                Call oItem.AddLine(sScaleStepLeftX, sScaleLeftY, sScaleStepLeftX + sScaleStepWidth, sScaleLeftY)
                                            Else
                                                'Graphics.DrawLine(oScalePen2, sScaleStepLeftX, sScaleLeftY, sScaleStepLeftX + sScaleStepWidth, sScaleLeftY)
                                                Call oItem.SetPen(oScalePen2)
                                                Call oItem.AddLine(sScaleStepLeftX, sScaleLeftY, sScaleStepLeftX + sScaleStepWidth, sScaleLeftY)
                                            End If
                                            sScaleStepLeftX += sScaleStepWidth
                                        Next
                                        Dim sScaleRightX As Single = sScaleStepLeftX

                                        oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                        Call oItem.SetPen(oScalePen2)
                                        Call oItem.AddLine(sScaleLeftX, sScaleLeftY - 2, sScaleLeftX, sScaleLeftY + 2)
                                        Call oItem.AddLine(sScaleRightX, sScaleLeftY - 2, sScaleRightX, sScaleLeftY + 2)

                                        oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                        Call oItem.SetBrush(oScalebrush)
                                        Call oItem.AddString(sScaleValue, oScaleFont, New PointF(sScaleLeftX + (sScaleWidth / 2) - (oScaleValueSize.Width / 2), sScaleLeftY - 1 - oScaleValueSize.Height))

                                    End Using
                                End Using
                            End Using
                        Case cOptionsDesign.ScaleStyleEnum.Advanced
                            Dim iMeters As Integer = PaintOptions.ScaleOptions.Meters
                            Dim iSteps As Integer = iMeters / PaintOptions.ScaleOptions.Steps
                            Dim istep As Integer = PaintOptions.ScaleOptions.Step

                            Dim oScaleFont As Font = PaintOptions.ScaleOptions.Font.GetFont(PaintOptions)
                            Using oScaleMeterFont As Font = New Font(oScaleFont.Name, oScaleFont.Size * 0.6!, FontStyle.Regular)

                                Dim sScaleValue As String = PaintOptions.ScaleOptions.Text
                                If Not PaintOptions.ScaleOptions.HideScaleValue Then
                                    If sScaleValue <> "" Then sScaleValue = sScaleValue & " "
                                    sScaleValue = sScaleValue & "1:" & modPaint.GetScaleFactor(Graphics, Zoom)
                                End If
                                If sScaleValue = "" Then sScaleValue = " "
                                Dim oScaleValueSize As SizeF = Graphics.MeasureString(sScaleValue, oScaleFont)

                                Using oScalePen As Pen = New Pen(PaintOptions.ScaleOptions.Color, cEditPaintObjects.FilettoPenWidth)
                                    Using oScaleBrush1 As Brush = New SolidBrush(PaintOptions.ScaleOptions.Color)
                                        Using oScalebrush2 As Brush = New SolidBrush(Color.White)

                                            Dim sScaleStepLeftX As Single = Location.X
                                            Dim sScaleLeftX As Single = Location.X
                                            Dim sScaleLeftY As Single = Location.Y
                                            Dim sScaleWidth As Single = iMeters * Zoom
                                            Dim sScaleStepWidth As Single = sScaleWidth / iSteps
                                            Dim bFilled As Boolean = False
                                            Dim iMeter As Integer = 0
                                            Dim sMeter As String = ""
                                            Dim sScaleHeight As Single = oScaleValueSize.Height / 2
                                            Dim sHalfScaleHeight As Single = sScaleHeight / 2
                                            For iScaleStepIndex As Integer = 0 To iSteps - 1
                                                If iScaleStepIndex = 0 Then
                                                    Dim iScaleSubStepWidth As Single = sScaleWidth * istep / iMeters
                                                    For iSubScaleStepIndex = 0 To (iMeters / iSteps) - istep Step istep
                                                        oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)

                                                        bFilled = Not bFilled
                                                        If bFilled Then
                                                            'Graphics.FillRectangle(oScaleBrush1, sScaleStepLeftX, sScaleLeftY - sHalfScaleHeight, sScaleStepWidth, sScaleHeight)
                                                            Call oItem.SetBrush(oScaleBrush1)
                                                        Else
                                                            'Graphics.FillRectangle(oScalebrush2, sScaleStepLeftX, sScaleLeftY - sHalfScaleHeight, sScaleStepWidth, sScaleHeight)
                                                            Call oItem.SetBrush(oScalebrush2)
                                                        End If
                                                        Call oItem.SetPen(oScalePen)
                                                        Call oItem.AddRectangle(sScaleStepLeftX, sScaleLeftY - sHalfScaleHeight, iScaleSubStepWidth, sScaleHeight)
                                                        Call oItem.AddLine(sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight + 2)

                                                        'Graphics.DrawRectangle(oScalePen, sScaleStepLeftX, sScaleLeftY - sHalfScaleHeight, sScaleStepWidth, sScaleHeight)
                                                        'Graphics.DrawLine(oScalePen, sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight + 2)

                                                        oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                        sMeter = iMeter & "m"
                                                        Call oItem.SetBrush(oScaleBrush1)
                                                        Call oItem.AddString(sMeter, oScaleMeterFont, New PointF(sScaleStepLeftX, sScaleLeftY + sScaleHeight + 2))

                                                        iMeter = iMeter + istep
                                                        sScaleStepLeftX += iScaleSubStepWidth
                                                    Next
                                                    'iMeter = iMeter - 1
                                                    'Call Graphics.DrawString(iMeter, oScaleFont, oScaleBrush1, New PointF(sScaleStepLeftX, sScaleLeftY + 8 + 2))
                                                Else
                                                    oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)

                                                    bFilled = Not bFilled
                                                    If bFilled Then
                                                        Call oItem.SetBrush(oScaleBrush1)
                                                    Else
                                                        Call oItem.SetBrush(oScalebrush2)
                                                    End If
                                                    Call oItem.SetPen(oScalePen)
                                                    Call oItem.AddRectangle(sScaleStepLeftX, sScaleLeftY - sHalfScaleHeight, sScaleStepWidth, sScaleHeight)
                                                    Call oItem.AddLine(sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight)

                                                    oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                                    sMeter = iMeter & "m"
                                                    Call oItem.SetBrush(oScaleBrush1)
                                                    Call oItem.AddString(sMeter, oScaleMeterFont, New PointF(sScaleStepLeftX, sScaleLeftY + sScaleHeight + 2))

                                                    iMeter = iMeter + iMeters / iSteps
                                                    sScaleStepLeftX += sScaleStepWidth
                                                End If
                                            Next
                                            oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                            sMeter = iMeter & "m"
                                            Call oItem.SetBrush(oScaleBrush1)
                                            Call oItem.AddString(sMeter, oScaleMeterFont, New PointF(sScaleStepLeftX, sScaleLeftY + sScaleHeight + 2))

                                            Dim sScaleRightX As Single = sScaleStepLeftX
                                            oItem = oCache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                            Call oItem.SetPen(oScalePen)
                                            Call oItem.AddLine(sScaleStepLeftX, sScaleLeftY + sHalfScaleHeight, sScaleStepLeftX, sScaleLeftY + sScaleHeight)
                                            Call oItem.SetBrush(oScaleBrush1)
                                            Call oItem.AddString(sScaleValue, oScaleFont, New PointF(sScaleLeftX + (sScaleWidth / 2) - (oScaleValueSize.Width / 2), sScaleLeftY - sHalfScaleHeight - 2 - oScaleValueSize.Height))

                                        End Using
                                    End Using
                                End Using
                            End Using
                    End Select
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            Call MyBase.new(Survey, "scale")
            oSurvey = Survey
        End Sub

        Friend Class cParameters
            Public Zoom As Single

            Public Sub New(ByVal Zoom As Single)
                Me.Zoom = Zoom
            End Sub

            Public Sub New()
                Me.Zoom = 1
            End Sub
        End Class

        Friend Overrides Sub Rebind(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal ViewArea As RectangleF, ByVal Parameters As Object)
            Call MyBase.Caches.Invalidate()
            sZoom = Parameters.zoom
            Dim oScaleSize As SizeF = GetBounds(Graphics, PaintOptions).Size
            Select Case PaintOptions.ScalePosition
                Case cOptionsDesign.AlignmentEnum.TopLeft
                    MyBase.Location = New PointF(ViewArea.Left + 2, ViewArea.Top + 2)
                Case cOptionsDesign.AlignmentEnum.TopRight
                    MyBase.Location = New PointF(ViewArea.Right - 2 - oScaleSize.Width, ViewArea.Top + 2)
                Case cOptionsDesign.AlignmentEnum.BottomLeft
                    MyBase.Location = New PointF(ViewArea.Left + 2, ViewArea.Bottom - 2 - oScaleSize.Height)
                Case cOptionsDesign.AlignmentEnum.BottomRight
                    MyBase.Location = New PointF(ViewArea.Right - 2 - oScaleSize.Width, ViewArea.Bottom - 2 - oScaleSize.Height)
            End Select
            Call Render(Graphics, PaintOptions)
        End Sub
    End Class
End Namespace