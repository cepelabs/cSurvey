Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Helper.Editor

Public Class frmJoinPointsPopup

    Private oSurvey As cSurvey.cSurvey
    Private oTool As cEditDesignTools

    Friend Event OnPointLink(Sender As Object)
    Friend Event OnPointSelect(Sender As Object, Point As cPoint)

    Protected Overrides Function GetPersistString() As String
        Return "joinpointspopup"
    End Function

    Friend Function IsPointInList(Point As cPoint) As Boolean
        For Each oItem As ListViewItem In lv.Items
            If oItem.Tag Is Point Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Sub SelectPoint()
        If lv.SelectedItems.Count > 0 Then
            Dim oPoint As cPoint = lv.SelectedItems(0).Tag
            RaiseEvent OnPointSelect(Me, oPoint)
        End If
    End Sub

    Friend Function GetPointsCount()
        Return lv.Items.Count
    End Function

    Friend Sub JoinPoints()
        Call btnLink_Click(Nothing, Nothing)
    End Sub

    Friend Sub AppendPoint()
        If Not oTool.CurrentItemPoint Is Nothing Then
            Dim oPoint As cPoint = oTool.CurrentItemPoint
            If Not IsPointInList(oPoint) Then
                Dim oItem As ListViewItem = New ListViewItem(oPoint.X & " - " & oPoint.Y)
                If oPoint.IsJoined Then
                    oItem.ImageKey = "joinedpoint"
                    oItem.SubItems.Add(oPoint.PointsJoin.Count - 1)
                Else
                    oItem.ImageKey = "point"
                    oItem.SubItems.Add("")
                End If
                oItem.Tag = oPoint
                Call lv.Items.Add(oItem)
                oItem.Selected = True
                oItem.Focused = True
            End If
        End If
        btnLink.Enabled = lv.Items.Count > 1
        mnuLvRemove.Enabled = lv.SelectedItems.Count > 0
    End Sub

    Friend Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Tool As cEditDesignTools)
        Call lv.Items.Clear()
        oSurvey = Survey
        oTool = Tool

        Dim bEnabled As Boolean = Not oSurvey Is Nothing And Not oTool Is Nothing
        tbMain.Enabled = bEnabled
        lv.Enabled = bEnabled
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lv.SelectedItems.Count > 0 Then
            For Each oitem As ListViewItem In lv.SelectedItems
                Call lv.Items.Remove(oitem)
            Next
        End If
        btnLink.Enabled = lv.Items.Count > 1
        If lv.Items.Count = 0 Then
            Call Hide()
        End If
    End Sub

    Private Sub btnLink_Click(sender As Object, e As EventArgs) Handles btnLink.Click
        If Not lv.FocusedItem Is Nothing And lv.Items.Count > 1 Then
            Dim oMasterPoint As cPoint = lv.FocusedItem.Tag
            For Each oItem As ListViewItem In lv.Items
                Dim oPoint As cPoint = oItem.Tag
                Call oMasterPoint.Join(oPoint)
            Next
            Call lv.Items.Clear()
            RaiseEvent OnPointLink(Me)
            Call Hide()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call lv.Items.Clear()
        Call Hide()
    End Sub

    Private Sub mnuLvJoin_Click(sender As Object, e As EventArgs) Handles mnuLvJoin.Click
        Call btnLink_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuLvCancel_Click(sender As Object, e As EventArgs) Handles mnuLvCancel.Click
        Call btnCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub frmJoinPoints_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Visible = False
            e.Cancel = True
        End If
    End Sub

    Private Sub mnuLv_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuLv.Opening
        Dim bEnabled As Boolean = lv.SelectedItems.Count > 0
        mnuLvJoin.Enabled = lv.Items.Count > 1
        mnuLvSelect.Enabled = bEnabled
        mnuLvRemove.Enabled = bEnabled
    End Sub

    Private Sub lv_DoubleClick(sender As Object, e As EventArgs) Handles lv.DoubleClick
        Call SelectPoint()
    End Sub

    Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
        Dim bEnabled As Boolean = lv.SelectedItems.Count > 0
        btnRemove.Enabled = bEnabled
    End Sub

    Private Sub mnuLvRemove_Click(sender As Object, e As EventArgs) Handles mnuLvRemove.Click
        Call btnRemove_Click(Nothing, Nothing)
    End Sub

    Private Sub mnuLvSelect_Click(sender As Object, e As EventArgs) Handles mnuLvSelect.Click
        Call SelectPoint()
    End Sub
End Class