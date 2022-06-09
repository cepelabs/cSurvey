Imports System.IO
Imports cSurveyPC.cSurvey
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraTreeList
Imports NAudio.Wave

Friend Class cDockAudioViewer
    Private WithEvents oWaveOutDevice As IWavePlayer
    Private oWaveStream As MediaFoundationReader
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private oList As List(Of cAttachmentsLink)

    Friend Class cGotoOWnerEventArgs
        Private oOwner As Object

        Public Sub New(Owner As Object)
            oOwner = Owner
        End Sub

        Public ReadOnly Property Owner() As Object
            Get
                Return oOwner
            End Get
        End Property
    End Class

    Friend Event OnGotoOwner(Sender As Object, Args As cGotoOWnerEventArgs)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oList = New List(Of cAttachmentsLink)

        Call pSurveySetupAttachments()
    End Sub

    Private Sub grdViewSegmentAttachments_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdViewSegmentAttachments.CustomUnboundColumnData
        If e.IsGetData Then
            If e.Column Is colSegmentAttachmentsImage Then
                e.Value = My.Resources.Electronics_Volume_colored
            End If
        End If
    End Sub

    Private Sub pSurveySetupAttachments()
        grdSegmentAttachments.BeginUpdate()
        grdSegmentAttachments.DataSource = oList
        grdSegmentAttachments.EndUpdate()
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        Call oList.Clear()

        btnPlay.Enabled = False
        btnStop.Enabled = False
        btnExport.Enabled = False
        btnGoToOwner.Enabled = False
    End Sub

    Private Sub pAttachment_OnCleanUp(Sender As Object, e As EventArgs)
        Dim oAttachment As cAttachmentsLink = Sender
        If grdViewSegmentAttachments.GetFocusedRow Is oAttachment Then
            Call [Stop]()
        End If
        Call oList.Remove(oAttachment)
        Call grdSegmentAttachments.RefreshDataSource()
    End Sub

    Public Sub Open(Attachment As cAttachmentsLink, PlayAfterOpen As Boolean)
        If oList.Contains(Attachment) Then
            RemoveHandler Attachment.OnCleanUp, AddressOf pAttachment_OnCleanUp
            Call oList.Remove(Attachment)
        End If
        Call oList.Insert(0, Attachment)
        AddHandler Attachment.OnCleanUp, AddressOf pAttachment_OnCleanUp

        Call grdSegmentAttachments.RefreshDataSource()
        Call grdViewSegmentAttachments.SetFocusedRow(Attachment)

        If PlayAfterOpen Then
            Call Play()
        End If
    End Sub

    Public Sub Play()
        Call pDispose()

        Dim oAttachment As cAttachmentsLink = grdViewSegmentAttachments.GetFocusedRow
        If Not oAttachment Is Nothing Then
            oWaveStream = New StreamMediaFoundationReader(New MemoryStream(oAttachment.Attachment.Data), Nothing)
            oWaveOutDevice = New WaveOut
            oWaveOutDevice.Init(oWaveStream)

            btnStop.Enabled = True
            btnPlay.Enabled = False
            Call oWaveOutDevice.Play()
        End If
    End Sub

    Public Sub [Stop]()
        If Not IsNothing(oWaveOutDevice) Then
            Call oWaveOutDevice.Stop()
        End If
        Call pDispose()

        btnStop.Enabled = False
        btnPlay.Enabled = Not IsNothing(grdViewSegmentAttachments.GetFocusedObject) AndAlso IsNothing(oWaveStream)
    End Sub

    Private Sub pDispose()
        If Not IsNothing(oWaveStream) Then
            Call oWaveStream.Dispose()
            oWaveStream = Nothing
        End If
        If Not IsNothing(oWaveOutDevice) Then
            Call oWaveOutDevice.Dispose()
            oWaveOutDevice = Nothing
        End If
    End Sub

    Private Sub grdViewSegmentAttachments_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdViewSegmentAttachments.PopupMenuShowing
        If e.HitInfo.InRowCell OrElse e.HitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.EmptyRow Then
            e.Allow = False
            Call mnuAudio.ShowPopup(grdSegmentAttachments.PointToScreen(e.Point))
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Dim oAttachment As cAttachmentsLink = grdViewSegmentAttachments.GetFocusedObject
        If Not oAttachment Is Nothing Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .Filter = GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                    .FilterIndex = 1
                    .FileName = oAttachment.Attachment.GetName
                    If .ShowDialog(Me) = DialogResult.OK Then
                        Call My.Computer.FileSystem.WriteAllBytes(.FileName, oAttachment.Attachment.Data, False)
                    End If
                End With
            End Using
        End If
    End Sub

    Private Sub btnStop_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnStop.ItemClick
        Call [Stop]()
    End Sub

    Private Sub btnPlay_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPlay.ItemClick
        Call Play()
    End Sub

    Private Sub btnGoToOwner_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnGoToOwner.ItemClick
        RaiseEvent OnGotoOwner(Me, New cGotoOWnerEventArgs(DirectCast(grdViewSegmentAttachments.GetFocusedObject, cAttachmentsLink).Owner))
    End Sub

    Private Sub grdViewSegmentAttachments_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles grdViewSegmentAttachments.FocusedRowChanged
        Dim bEnabled As Boolean = Not grdViewSegmentAttachments.GetFocusedObject Is Nothing
        btnPlay.Enabled = bEnabled AndAlso IsNothing(oWaveStream)
        btnExport.Enabled = bEnabled
        btnGoToOwner.Enabled = bEnabled
    End Sub

    Private Sub grdViewSegmentAttachments_DoubleClick(sender As Object, e As EventArgs) Handles grdViewSegmentAttachments.DoubleClick
        Dim oAttachment As cAttachmentsLink = grdViewSegmentAttachments.GetFocusedObject
        If Not IsNothing(oAttachment) Then
            Call [Stop]()
            Call Open(oAttachment, True)
        End If
    End Sub
End Class