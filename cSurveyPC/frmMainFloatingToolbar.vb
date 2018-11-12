Public Class frmMainFloatingToolbar
    Friend Class MainFloatingToolbarItemClickArgs
        Public ItemKey As String

        Public Sub New(ItemKey As String)
            Me.ItemKey = ItemKey
        End Sub
    End Class

    Friend Class MainFloatingToolbarItemBringFocusArgs
        Public Cancel As Boolean
    End Class

    Friend Event OnItemClick(sender As frmMainFloatingToolbar, Arg As MainFloatingToolbarItemClickArgs)
    Friend Event OnRestoreFocus(sender As frmMainFloatingToolbar)
    Friend Event OnBringFocus(sender As frmMainFloatingToolbar, Arg As MainFloatingToolbarItemBringFocusArgs)

    Private Sub tbPen_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbPen.ItemClicked
        RaiseEvent OnItemClick(Me, New MainFloatingToolbarItemClickArgs(e.ClickedItem.Name))
    End Sub

    Private Sub tbPen_MouseEnter(sender As Object, e As EventArgs) Handles tbPen.MouseEnter
        Dim oArg As MainFloatingToolbarItemBringFocusArgs = New MainFloatingToolbarItemBringFocusArgs()
        RaiseEvent OnBringFocus(Me, oArg)
        If Not oArg.Cancel Then Call Focus()
    End Sub

    Private Sub tbPen_MouseLeave(sender As Object, e As EventArgs) Handles tbPen.MouseLeave
        RaiseEvent OnRestoreFocus(Me)
    End Sub

    Private Sub tbPen_MouseMove(sender As Object, e As MouseEventArgs) Handles tbPen.MouseMove
        Call frmMainFloatingToolbar_MouseMove(sender, e)
    End Sub

    Private Sub tbPen_SizeChanged(sender As Object, e As EventArgs) Handles tbPen.SizeChanged
        If Me.Visible Then
            Size = tbPen.Size
        End If
    End Sub

    Private Sub tbPen_VisibleChanged(sender As Object, e As EventArgs) Handles tbPen.VisibleChanged
        If Me.Visible Then
            Size = tbPen.Size
        End If
    End Sub

    Private Sub frmMainFloatingToolbar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (e.CloseReason = CloseReason.UserClosing)
    End Sub

    Private Sub frmMainFloatingToolbar_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            Location = New Point(Location.X + e.X, Location.Y + e.Y)
            'Location = New Point(Location.X + e.X - oMousePoint.X, Location.Y + e.Y - oMousePoint.Y)
            'oMousePoint = e.Location
        End If
    End Sub

    Private sLastUsedPrefix As String = "btnLASTUSED_"

    Private Function pGetLastUsedButtonCount() As Integer
        Dim iCount As Integer = 0
        For Each oItem As ToolStripItem In tbPen.Items
            If oItem.Name.StartsWith(sLastUsedPrefix) Then
                iCount += 1
            End If
        Next
        Return iCount
    End Function

    Private Sub pDeleteFirstLastUsedButton()
        Dim oItem As ToolStripItem = Nothing
        For Each oItem In tbPen.Items
            If oItem.Name.StartsWith(sLastUsedPrefix) AndAlso Not (TypeOf oItem Is ToolStripSeparator) Then
                Exit For
            End If
        Next
        If Not IsNothing(oItem) Then
            tbPen.Items.Remove(oItem)
        End If
    End Sub

    'Public Sub HideAllButtons()
    '    For Each oItem As ToolStripItem In tbPen.Items
    '        oItem.Visible = False
    '    Next
    'End Sub

    Public Function AddLastUsedButton(Button As ToolStripItem, Click As EventHandler) As ToolStripButton
        If Not Button.Name.StartsWith(sLastUsedPrefix) Then
            Dim sLASTUSEDKey As String = sLastUsedPrefix & Button.Name
            If tbPen.Items.ContainsKey(sLASTUSEDKey) Then
                Return tbPen.Items(sLASTUSEDKey)
            Else
                Dim iCount As Integer = pGetLastUsedButtonCount()
                If iCount >= 10 Then
                    'delete firstbutton...
                    Call pDeleteFirstLastUsedButton()
                ElseIf iCount = 0 Then
                    Dim oButtonSep As ToolStripSeparator = New ToolStripSeparator
                    oButtonSep.Name = sLastUsedPrefix & "_sep"
                    tbPen.Items.Add(oButtonSep)
                End If
                Dim oButton As ToolStripButton = New ToolStripButton
                oButton.Image = Button.Image
                oButton.Text = Button.Text
                oButton.ToolTipText = Button.ToolTipText
                oButton.DisplayStyle = ToolStripItemDisplayStyle.Image
                oButton.Name = sLASTUSEDKey
                oButton.Tag = Button.Tag
                AddHandler oButton.Click, Click
                tbPen.Items.Add(oButton)
                Return oButton
            End If
        End If
    End Function
End Class