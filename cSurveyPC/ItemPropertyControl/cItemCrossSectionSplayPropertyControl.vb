Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemCrossSectionSplayPropertyControl
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows ReadOnly Property Item As cIItemCrossSectionSplayBorder
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cIItemCrossSectionSplayBorder)
        MyBase.Rebind(Item)

        Try
            chkPropCrossSectionShowSplayBorder.Checked = Me.Item.ShowSplayBorder
            chkPropCrossSectionShowOnlyCutSplay.Checked = Me.Item.ShowOnlyCutSplay
            chkPropCrossSectionSplayText.Checked = Me.Item.ShowSplayText
            Try
                txtPropCrossSectionSplayProjectionAngle.Value = Me.Item.SplayBorderProjectionAngle
                txtPropCrossSectionSplayProjectionVerticalAngle.Value = Me.Item.SplayBorderProjectionVerticalAngle
                txtPropCrossSectionSplayMaxVariationAngle.Value = Me.Item.SplayBorderMaxAngleVariation
                cboPropCrossSectionSplayLineStyle.SelectedIndex = Me.Item.SplayBorderLineStyle
            Catch
            End Try
        Catch
        End Try
        Call picPropCrossSectionProjectionSchema.Invalidate()
    End Sub

    Private Sub cmdPropProfileSplay_Click(sender As Object, e As EventArgs) Handles cmdPropCrossSectionSplay.Click
        Call MyBase.DoCommand("splayreplicatedata", Item)
    End Sub

    Private Sub picPropCrossSectionProjectionSchema_PaintEx(sender As Object, e As DevExpress.XtraGrid.PaintExEventArgs) Handles picPropCrossSectionProjectionSchema.PaintEx
        Dim dBearing As Decimal = DirectCast(Me.Item, cItemCrossSection).Segment.Data.Data.Bearing
        If DirectCast(Me.Item, cItemCrossSection).Direction = cIItemCrossSection.DirectionEnum.Inverted Then
            dBearing -= 180
        End If
        Dim iAngle As Integer = Me.Item.SplayBorderProjectionAngle
        Dim iVAngle As Integer = Me.Item.SplayBorderProjectionVerticalAngle
        Dim iVariation As Integer = Me.Item.SplayBorderMaxAngleVariation

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
                Using oPen As New Pen(Brushes.Gray, 2)
                    'e.Cache.DrawLine(oPen, New Point(oRect.Left + oRect.Width \ 2, oRect.Top), New Point(oRect.Left + oRect.Width \ 2, oRect.Bottom))
                    e.Cache.DrawLine(oPen, New Point(oRect.Left, oRect.Top + oRect.Height \ 2), New Point(oRect.Right, oRect.Top + oRect.Height \ 2))
                End Using
            End Using
            Using oMatrix As DevExpress.Utils.Drawing.DirectXMatrix = New DevExpress.Utils.Drawing.DirectXMatrix
                Call oMatrix.RotateAt(iProjectionAngle, modPaint.GetCenterPoint(oRect))
                e.Cache.SetTransform(oMatrix)
                Using oPen As New Pen(Color.FromArgb(180, Color.Red), 1)
                    oPen.StartCap = Drawing2D.LineCap.Custom
                    oPen.CustomStartCap = New Drawing2D.AdjustableArrowCap(5, 5, True)
                    e.Cache.DrawLine(oPen, New Point(oRect.Left + oRect.Width \ 2, oRect.Top), New Point(oRect.Left + oRect.Width \ 2, oRect.Bottom))
                End Using
                Using oOtherLightBrush As Brush = New SolidBrush(Color.FromArgb(80, Color.Red))
                    If iVariation > 0 Then
                        Dim oRect1 As Rectangle = New Rectangle(oRect.Left, oRect.Top, oRect.Width, oRect.Height)
                        'e.Cache.FillRectangle(Brushes.Yellow, oRect1)
                        Call e.Cache.FillPie(oOtherLightBrush, oRect1, 180 - iVariation, iVariation * 2)
                    End If
                    If iVariation > 0 Then
                        Dim oRect2 As Rectangle = New Rectangle(oRect.Left, oRect.Top, oRect.Width, oRect.Height)
                        'e.Cache.FillRectangle(Brushes.Yellow, oRect2)
                        Call e.Cache.FillPie(oOtherLightBrush, oRect2, 0 - iVariation, iVariation * 2)
                    End If
                End Using
            End Using
        End If
    End Sub

    Private Sub chkPropCrossSectionShowSplayBorder_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionShowSplayBorder.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Item.ShowSplayBorder = chkPropCrossSectionShowSplayBorder.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionShowSplayBorder")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionShowOnlyCutSplay_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionShowOnlyCutSplay.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Item.ShowOnlyCutSplay = chkPropCrossSectionShowOnlyCutSplay.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionShowOnlyCutSplay")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionSplayProjectionAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionSplayProjectionAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.SplayBorderProjectionAngle = txtPropCrossSectionSplayProjectionAngle.Value
            Call picPropCrossSectionProjectionSchema.Invalidate()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionSplayProjectionAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionSplayProjectionVerticalAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionSplayProjectionVerticalAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.SplayBorderProjectionVerticalAngle = txtPropCrossSectionSplayProjectionVerticalAngle.Value
            Call picPropCrossSectionProjectionSchema.Invalidate()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionSplayProjectionVerticalAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropCrossSectionSplayMaxVariationAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropCrossSectionSplayMaxVariationAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.SplayBorderMaxAngleVariation = txtPropCrossSectionSplayMaxVariationAngle.Value
            Call picPropCrossSectionProjectionSchema.Invalidate()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionSplayMaxVariationAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropCrossSectionSplayLineStyle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropCrossSectionSplayLineStyle.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Me.Item.SplayBorderLineStyle = cboPropCrossSectionSplayLineStyle.SelectedIndex
            Call picPropCrossSectionProjectionSchema.Invalidate()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionSplayLineStyle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropCrossSectionSplayText_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropCrossSectionSplayText.CheckedChanged
        If Not DisabledObjectProperty() Then
            Me.Item.ShowSplayText = chkPropCrossSectionSplayText.Checked
            Call picPropCrossSectionProjectionSchema.Invalidate()
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("CrossSectionSplayText")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
