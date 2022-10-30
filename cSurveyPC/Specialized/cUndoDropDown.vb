Imports System.ComponentModel
Imports cSurveyPC.cSurvey.Helper.Editor

Public Class cUndoDropDown
    Public Class cUndoItemPlaceholder
        Private sText As String
        Private iArea As Integer

        Public ReadOnly Property Area As Integer
            Get
                Return iArea
            End Get
        End Property

        Public ReadOnly Property Text As String
            Get
                Return sText
            End Get
        End Property

        Public Sub New(Text As String, Area As cUndo.cAreaEnum)
            sText = Text
            Select Case Area
                Case cUndo.cAreaEnum.DesignPlan, cUndo.cAreaEnum.DesignProfile
                    iArea = 0
                Case Else
                    iArea = 1
            End Select
        End Sub
    End Class

    Public Sub Rebind(Undo As cSurvey.Helper.Editor.cUndo)
        Call tvUndoItems.BeginUpdate()
        Dim oUndoItems As BindingList(Of cUndoItemPlaceholder) = New BindingList(Of cUndoItemPlaceholder)
        For Each oUndo As cUndoItem In Undo
            Call oUndoItems.Add(New cUndoItemPlaceholder(oUndo.Description, oUndo.Area))
        Next
        tvUndoItems.DataSource = oUndoItems
        tvUndoItems.RefreshDataSource()
        Call tvUndoItems.EndUpdate()
    End Sub

    Private Sub tvUndoItems_MouseMove(sender As Object, e As MouseEventArgs) Handles tvUndoItems.MouseMove
        Dim oInfo = tvUndoItems.CalcHitInfo(e.Location)
        If oInfo.HitInfoType = DevExpress.XtraTreeList.HitInfoType.Cell Then
            Call tvUndoItems.BeginUpdate()
            Call tvUndoItems.ClearSelection()
            tvUndoItems.FocusedNode = oInfo.Node
            Call tvUndoItems.SelectNodes(0, oInfo.Node.Id)
            txtUndoInfo.Text = String.Format(modMain.GetLocalizedString("main.undotextinfo1"), oInfo.Node.Id + 1)
            Call tvUndoItems.EndUpdate()
            tvUndoItems.Focus()
        End If
    End Sub

    Public Class cUndoDropDownUndoEventArgs
        Inherits EventArgs

        Private iUndoActions As Integer

        Public ReadOnly Property UndoActions As Integer
            Get
                Return iUndoActions
            End Get
        End Property

        Public Sub New(UndoActions As Integer)
            iUndoActions = UndoActions
        End Sub
    End Class

    Public Event OnUndo(sender As Object, e As cUndoDropDownUndoEventArgs)

    Private Sub tvUndoItems_Click(sender As Object, e As EventArgs) Handles tvUndoItems.Click
        'Dim oInfo = tvUndoItems.CalcHitInfo(Cursor.Position)
        'If oInfo.HitInfoType = DevExpress.XtraTreeList.HitInfoType.Cell Then
        If tvUndoItems.FocusedNode IsNot Nothing Then
            RaiseEvent OnUndo(Me, New cUndoDropDownUndoEventArgs(tvUndoItems.FocusedNode.Id))
        End If
        'End If
    End Sub
End Class
