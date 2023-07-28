Imports System.ComponentModel
Imports System.IO
Imports cSurveyPC.cSurvey

Friend Class frmClipartReplaceWith

    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    Private sPath As String

    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Path As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        sPath = Path
        Call pLoadGallery(sPath)
    End Sub

    Private Sub pLoadGallery(Path As String)
        Dim oItems As BindingList(Of cGalleryItem) = New BindingList(Of cGalleryItem)
        Dim fd As DirectoryInfo = New DirectoryInfo(Path)
        If fd.Exists Then
            For Each fl As FileInfo In fd.GetFiles("*.svg")
                If Not fl.Name Like "_*" Then
                    Try
                        Dim oItem As cGalleryItem = New cGalleryItem(fl)
                        Call oItems.Add(oItem)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
        GridControl1.DataSource = oItems
    End Sub

    Private Sub WinExplorerView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles WinExplorerView1.FocusedRowChanged
        cmdOk.Enabled = WinExplorerView1.GetFocusedRow IsNot Nothing
    End Sub

    Public ReadOnly Property SelectedItem As cGalleryItem
        Get
            Return WinExplorerView1.GetFocusedRow
        End Get
    End Property
End Class