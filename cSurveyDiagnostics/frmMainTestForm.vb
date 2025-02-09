Imports DevExpress.XtraEditors

Public Class frmMainTestForm
    Private Sub btnClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        Close()
    End Sub

    Private Sub frmMainTestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmMainTestForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Dim o As SimpleButton = New SimpleButton
        'Controls.Add(o)
    End Sub
End Class