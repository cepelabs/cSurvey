Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.ViewInfo

Friend Class cItemTransparencyPropertyControl2
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)
        If Item.TransparencyValue.HasValue Then
            trkTransparency.EditValue = Item.TransparencyValue.Value * 255.0F
            chkTransparencyNothing.Visible = False
            chkTransparencyNothing.Checked = False
        Else
            trkTransparency.EditValue = 255.0F
            trkTransparency.Visible = False
            chkTransparencyNothing.Visible = True
            chkTransparencyNothing.Checked = True
        End If
    End Sub

    Private Sub trkTransparency_EditValueChanged(sender As Object, e As EventArgs) Handles trkTransparency.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo38"), "Transparency")
            Item.Transparency = trkTransparency.EditValue / 255.0F
            Call MyBase.PropertyChanged("Transparency")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    'Private Sub trkTransparency_PaintEx(sender As Object, e As DevExpress.Utils.XtraPaintEventArgs) Handles trkTransparency.PaintEx
    '    If Item.TransparencyValue Is Nothing Then
    '        Dim trackBar = DirectCast(sender, TrackBarControl)
    '        Dim viewInfo = DirectCast(trackBar.GetViewInfo(), TrackBarViewInfo)
    '        Dim thumbRect As Rectangle = viewInfo.ThumbBounds
    '        If thumbRect.IsEmpty Then Return
    '        'e.Cache.DrawSvgImage(My.Resources.duplicatevalues, thumbRect, Nothing)
    '        chkTransparencyNothing.Location = New Point(thumbRect.X + thumbRect.Width / 2 - chkTransparencyNothing.Width / 2, thumbRect.Y + thumbRect.Height / 2 - chkTransparencyNothing.Height / 2)
    '        chkTransparencyNothing.BringToFront()
    '    Else
    '        Return
    '    End If
    'End Sub

    Private Sub chkTransparencyNothing_CheckedChanged(sender As Object, e As EventArgs) Handles chkTransparencyNothing.CheckedChanged
        If Not chkTransparencyNothing.Checked Then
            trkTransparency.EditValue = 0.0F
            trkTransparency.Visible = True
            chkTransparencyNothing.Visible = False
            chkTransparencyNothing.Checked = False
        End If
    End Sub
End Class
