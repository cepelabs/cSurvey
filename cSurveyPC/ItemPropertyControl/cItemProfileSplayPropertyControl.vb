﻿Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemProfileSplayPropertyControl
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows ReadOnly Property Item As cItemSegment
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItemSegment)
        MyBase.Rebind(Item)

        Try
            txtPropProfileSplayProjectionAngle.Value = Me.Item.ProfileSplayBorderProjectionAngle
            txtPropProfileSplayMaxVariationAngle.Value = Me.Item.ProfileSplayBorderMaxAngleVariation
            txtPropProfileSplayPosInclinationRangeMin.Value = Me.Item.ProfileSplayBorderPosInclinationRange.Width
            txtPropProfileSplayPosInclinationRangeMax.Value = Me.Item.ProfileSplayBorderPosInclinationRange.Height
            txtPropProfileSplayNegInclinationRangeMin.Value = Me.Item.ProfileSplayBorderNegInclinationRange.Width
            txtPropProfileSplayNegInclinationRangeMax.Value = Me.Item.ProfileSplayBorderNegInclinationRange.Height
        Catch
        End Try
        Call picPropProfileProjectionSchema.Invalidate()
    End Sub

    Private Sub txtPropProfileSplayProjectionAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileSplayProjectionAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "ProfileSplayBorderProjectionAngle")
            Me.Item.ProfileSplayBorderProjectionAngle = txtPropProfileSplayProjectionAngle.Value
            Call picPropProfileProjectionSchema.Invalidate()
            Call MyBase.PropertyChanged("ProfileSplayBorderProjectionAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropProfileSplayMaxVariationAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileSplayMaxVariationAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "ProfileSplayBorderMaxAngleVariation")
            Me.Item.ProfileSplayBorderMaxAngleVariation = txtPropProfileSplayMaxVariationAngle.Value
            Call picPropProfileProjectionSchema.Invalidate()
            Call MyBase.PropertyChanged("ProfileSplayBorderMaxAngleVariation")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropProfileSplayPosInclinationRangeMin_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileSplayPosInclinationRangeMin.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "ProfileSplayBorderPosInclinationRange")
            Me.Item.ProfileSplayBorderPosInclinationRange = New SizeF(txtPropProfileSplayPosInclinationRangeMin.Value, Me.Item.ProfileSplayBorderPosInclinationRange.Height)
            Call picPropProfileProjectionSchema.Invalidate()
            Call MyBase.PropertyChanged("ProfileSplayBorderPosInclinationRange")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropProfileSplayNegInclinationRangeMin_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileSplayNegInclinationRangeMin.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "ProfileSplayBorderNegInclinationRange")
            Me.Item.ProfileSplayBorderNegInclinationRange = New SizeF(txtPropProfileSplayNegInclinationRangeMin.Value, Me.Item.ProfileSplayBorderNegInclinationRange.Height)
            Call picPropProfileProjectionSchema.Invalidate()
            Call MyBase.PropertyChanged("ProfileSplayNegInclinationRangeMin")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropProfileSplayPosInclinationRangeMax_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileSplayPosInclinationRangeMax.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "ProfileSplayBorderPosInclinationRange")
            Me.Item.ProfileSplayBorderPosInclinationRange = New SizeF(Me.Item.ProfileSplayBorderPosInclinationRange.Width, txtPropProfileSplayPosInclinationRangeMax.Value)
            Call picPropProfileProjectionSchema.Invalidate()
            Call MyBase.PropertyChanged("ProfileSplayPosInclinationRangeMax")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropProfileSplayNegInclinationRangeMax_ValueChanged(sender As Object, e As EventArgs) Handles txtPropProfileSplayNegInclinationRangeMax.ValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo40"), "ProfileSplayBorderNegInclinationRange")
            Me.Item.ProfileSplayBorderNegInclinationRange = New SizeF(Me.Item.ProfileSplayBorderNegInclinationRange.Width, txtPropProfileSplayNegInclinationRangeMax.Value)
            Call picPropProfileProjectionSchema.Invalidate()
            Call MyBase.PropertyChanged("ProfileSplayNegInclinationRangeMax")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdPropProfileSplay_Click(sender As Object, e As EventArgs) Handles cmdPropProfileSplay.Click
        Call MyBase.DoCommand("splayreplicatedata", Item)
    End Sub

    Private Sub picPropProfileProjectionSchema_PaintEx(sender As Object, e As DevExpress.XtraGrid.PaintExEventArgs) Handles picPropProfileProjectionSchema.PaintEx
        Dim dBearing As Decimal = DirectCast(Me.Item, cItemSegment).Segment.Data.Data.Bearing
        Dim iAngle As Integer = Me.Item.ProfileSplayBorderProjectionAngle
        Dim iVariation As Integer = Me.Item.ProfileSplayBorderMaxAngleVariation

        e.Cache.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        e.Cache.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        e.Cache.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        Dim iProjectionAngle As Integer = dBearing + iAngle
        Dim oRect As Rectangle = e.ClipRectangle
        Call oRect.Inflate(-4, -4)

        If oRect.Width > 0 AndAlso oRect.Height > 0 Then
            Using oMatrix As DevExpress.Utils.Drawing.DirectXMatrix = New DevExpress.Utils.Drawing.DirectXMatrix
                Call oMatrix.RotateAt(dBearing, modPaint.GetCenterPoint(oRect))
                e.Cache.SetTransform(oMatrix)
                Using oPen As New Pen(Brushes.DimGray, 1)
                    e.Cache.DrawEllipse(oPen, oRect)
                    oPen.StartCap = Drawing2D.LineCap.Custom
                    oPen.CustomStartCap = New Drawing2D.AdjustableArrowCap(5, 5, True)
                    e.Cache.DrawLine(oPen, New Point(oRect.Left + oRect.Width \ 2, oRect.Top), New Point(oRect.Left + oRect.Width \ 2, oRect.Bottom))
                End Using
            End Using
            Using oMatrix As DevExpress.Utils.Drawing.DirectXMatrix = New DevExpress.Utils.Drawing.DirectXMatrix
                Call oMatrix.RotateAt(iProjectionAngle, modPaint.GetCenterPoint(oRect))
                e.Cache.SetTransform(oMatrix)
                Using oPen As New Pen(Color.FromArgb(180, Color.Red), 1)
                    oPen.StartCap = Drawing2D.LineCap.Custom
                    oPen.CustomStartCap = New Drawing2D.AdjustableArrowCap(5, 5, True)
                    e.Cache.DrawLine(oPen, New Point(oRect.Right, oRect.Top + oRect.Height \ 2), New Point(oRect.Left, oRect.Top + oRect.Height \ 2))
                End Using
                Using oPen As New Pen(Brushes.Gray, 2)
                    e.Cache.DrawLine(oPen, New Point(oRect.Left + oRect.Width \ 2, oRect.Top), New Point(oRect.Left + oRect.Width \ 2, oRect.Bottom))
                End Using
                Using oOtherLightBrush As Brush = New SolidBrush(Color.FromArgb(80, Color.Red))
                    If iVariation > 0 Then
                        Dim oRect1 As Rectangle = New Rectangle(oRect.Left, oRect.Top - oRect.Height \ 2, oRect.Width, oRect.Height)
                        Call e.Cache.FillPie(oOtherLightBrush, oRect1, 90 - iVariation, iVariation * 2)
                    End If
                    If iVariation > 0 Then
                        Dim oRect2 As Rectangle = New Rectangle(oRect.Left, oRect.Top + oRect.Height \ 2, oRect.Width, oRect.Height)
                        Call e.Cache.FillPie(oOtherLightBrush, oRect2, -90 - iVariation, iVariation * 2)
                    End If
                End Using
            End Using
        End If
    End Sub

End Class
