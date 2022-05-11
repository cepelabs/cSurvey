Imports System.Linq
Imports System.ComponentModel
Imports BrightIdeasSoftware
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

friend Class frmTexts
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Friend Class cFilenameRequestEventArgs
        Inherits EventArgs

        Public Property Filename As String
    End Class

    Friend Event OnFilenameRequest(sender As Object, e As cFilenameRequestEventArgs)

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
    End Sub

    Protected Overrides Function GetPersistString() As String
        Return "texts"
    End Function

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey

        Call grdTexts.BeginUpdate()
        grdTexts.DataSource = oSurvey.Texts.ToList
        Call grdTexts.EndUpdate()
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Dim oItem As cText = oSurvey.Texts.Add(oSurvey.Texts.GetUniqueName, "")
        Call grdTexts.DataSource.add(oItem)
        Call grdTexts.RefreshDataSource()
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        Call oSurvey.Texts.Remove(grdViewTexts.GetFocusedRow.name)
        Call grdViewTexts.DeleteSelectedRows()
    End Sub

    Private Sub grdViewTexts_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdViewTexts.FocusedRowChanged
        Dim bEnabled As Boolean = Not grdViewTexts.GetFocusedRow Is Nothing
        btnDelete.Enabled = bEnabled
    End Sub

    Private Sub grdViewTexts_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewTexts.PopupMenuShowing
        If e.HitInfo.InRowCell Then
            e.Allow = False
            Call mnuTexts.ShowPopup(grdTexts.PointToScreen(e.Point))
        End If
    End Sub
End Class