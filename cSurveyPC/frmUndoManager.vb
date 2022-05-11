Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

friend Class frmUndoManager

    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private WithEvents oUndo As Helper.Editor.cUndo

    Friend Event OnUndoRequest(ByVal Sender As frmUndoManager, ByVal EventArgs As Object)

    Friend Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        lvUndoStack.Enabled = False
    End Sub

    Private Sub frmUndoManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            Visible = False
            e.Cancel = True
        End If
    End Sub

    Friend Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Tools As Helper.Editor.cEditTools)
        oSurvey = Survey
        oUndo = Tools.Undo

        lvUndoStack.Enabled = True

        Call lvUndoStack.Items.Clear()
        For Each oUndoItem As cUndoItem In oUndo
            Dim oItem As ListViewItem = New ListViewItem
            oItem.ImageIndex = oUndoItem.Action - 1
            oItem.Text = oUndoItem.Action
            Call oItem.SubItems.Add(oUndoItem.Description)
            Call oItem.SubItems.Add(oUndoItem.DateStamp)
            Call lvUndoStack.Items.Add(oItem)
        Next
        If lvUndoStack.Items.Count > 0 Then
            With lvUndoStack.Items(lvUndoStack.Items.Count - 1)
                .Selected = True
                .Focused = True
            End With
        End If
        btnUndo.Enabled = oUndo.IsUndoable
    End Sub

    Private Sub oUndo_OnCancel(Sender As Object, EventArgs As Helper.Editor.cUndo.cUndoEventArgs) Handles oUndo.OnCancel
        If lvUndoStack.Items.Count > 0 Then
            Call lvUndoStack.Items(lvUndoStack.Items.Count - 1).Remove()
        End If
        btnUndo.Enabled = lvUndoStack.Items.Count > 0
    End Sub

    Private Sub oUndo_OnPop(Sender As Object, EventArgs As Helper.Editor.cUndo.cUndoEventArgs) Handles oUndo.OnPop
        If lvUndoStack.Items.Count > 0 Then
            Call lvUndoStack.Items(lvUndoStack.Items.Count - 1).Remove()
        End If
        btnUndo.Enabled = lvUndoStack.Items.Count > 0
    End Sub

    Private Sub oUndo_OnPush(Sender As Object, EventArgs As Helper.Editor.cUndo.cUndoEventArgs) Handles oUndo.OnPush
        Dim oItem As ListViewItem = New ListViewItem
        oItem.ImageIndex = EventArgs.Item.Action - 1
        oItem.Text = EventArgs.Item.Action
        Call oItem.SubItems.Add(EventArgs.Item.Description)
        Call oItem.SubItems.Add(EventArgs.Item.DateStamp)
        Call lvUndoStack.Items.Add(oItem)
        oItem.Selected = True
        oItem.Focused = True
        Call oItem.EnsureVisible()

        btnUndo.Enabled = oUndo.IsUndoable
    End Sub

    Private Sub btnUndo_Click(sender As System.Object, e As System.EventArgs) Handles btnUndo.Click
        RaiseEvent OnUndoRequest(Me, Nothing)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Call Hide()
    End Sub
End Class