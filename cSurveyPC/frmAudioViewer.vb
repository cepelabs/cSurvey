Imports System.IO
Imports cSurveyPC.cSurvey
Imports NAudio.Wave

friend Class frmAudioViewer
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

    Protected Overrides Function GetPersistString() As String
        Return "audioviewer"
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oList = New List(Of cAttachmentsLink)

        Call pSurveySetupAttachments()

        Call tvAttachments.BeginUpdate()
        tvAttachments.VirtualMode = False
        tvAttachments.SetObjects(oList)
        Call tvAttachments.BuildList(True)
        Call tvAttachments.EndUpdate()
    End Sub

    Private Sub pSurveySetupAttachments()
        colAttachmentIcon.ImageGetter = Function(Value As Object)
                                            Return DirectCast(Value, cAttachmentsLink).Attachment.GetThumbnail
                                        End Function
        colAttachmentName.AspectGetter = Function(Value As Object)
                                             Return DirectCast(Value, cAttachmentsLink).Attachment.Name
                                         End Function
        colAttachmentName.AspectPutter = Sub(rowObject As Object, newValue As Object)
                                             DirectCast(rowObject, cAttachmentsLink).Attachment.Name = newValue
                                         End Sub
        colAttachmentNote.AspectGetter = Function(Value As Object)
                                             Return DirectCast(Value, cAttachmentsLink).Attachment.Note
                                         End Function
        colAttachmentOwner.AspectGetter = Function(Value As Object)
                                              Return DirectCast(Value, cAttachmentsLink).Owner.ToString
                                          End Function
        Call tvAttachments.RebuildColumns()
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        Call oList.Clear()
    End Sub

    Private Sub pAttachment_OnCleanUp(Sender As Object, e As EventArgs)
        Dim oAttachment As cAttachmentsLink = Sender
        If tvAttachments.SelectedObject Is oAttachment Then
            Call [Stop]()
            tvAttachments.SelectedObject = Nothing
        End If
        Call oList.Remove(Sender)
        Call tvAttachments.BuildList(True)
    End Sub

    Public Sub Open(Attachment As cAttachmentsLink, PlayAfterOpen As Boolean)
        If oList.Contains(Attachment) Then
            RemoveHandler Attachment.OnCleanUp, AddressOf pAttachment_OnCleanUp
            Call oList.Remove(Attachment)
        End If
        Call oList.Insert(0, Attachment)
        AddHandler Attachment.OnCleanUp, AddressOf pAttachment_OnCleanUp
        Call tvAttachments.BuildList(True)
        Call tvAttachments.SelectObject(Attachment)

        If PlayAfterOpen Then
            Call Play()
        End If
    End Sub

    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles cmdPlay.Click
        Call Play()
    End Sub

    Public Sub Play()
        Call pDispose()

        Dim oAttachment As cAttachmentsLink = tvAttachments.SelectedObject
        oWaveStream = New StreamMediaFoundationReader(New MemoryStream(oAttachment.Attachment.Data), Nothing)
        oWaveOutDevice = New WaveOut
        oWaveOutDevice.Init(oWaveStream)

        cmdStop.Enabled = True
        cmdPlay.Enabled = False
        Call oWaveOutDevice.Play()
    End Sub

    Private Sub cmdStop_Click(sender As Object, e As EventArgs) Handles cmdStop.Click
        Call [Stop]()
    End Sub

    Public Sub [Stop]()
        If Not IsNothing(oWaveOutDevice) Then
            Call oWaveOutDevice.Stop()
        End If
        Call pDispose()

        cmdStop.Enabled = False
        cmdPlay.Enabled = Not IsNothing(tvAttachments.SelectedObject) AndAlso IsNothing(oWaveStream)
    End Sub

    Private Sub frmAudioViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call pDispose()
    End Sub

    Private Sub tvSegmentAttachments_DoubleClick(sender As Object, e As EventArgs) Handles tvAttachments.DoubleClick
        Dim oAttachment As cAttachmentsLink = tvAttachments.SelectedObject
        If Not IsNothing(oAttachment) Then
            Call [Stop]()
            Call Open(oAttachment, True)
        End If
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

    Private Sub tvAttachments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tvAttachments.SelectedIndexChanged
        cmdPlay.Enabled = Not IsNothing(tvAttachments.SelectedObject) AndAlso IsNothing(oWaveStream)
        cmdExport.Enabled = Not IsNothing(tvAttachments.SelectedObject)
    End Sub

    Private Sub mnuAttachments_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuAttachments.Opening
        mnuAttachmentGotoOwner.Enabled = tvAttachments.SelectedObjects.Count > 0
    End Sub

    Private Sub mnuAttachmentGotoOwner_Click(sender As Object, e As EventArgs) Handles mnuAttachmentGotoOwner.Click
        RaiseEvent OnGotoOwner(Me, New cGotoOWnerEventArgs(DirectCast(tvAttachments.SelectedObject, cAttachmentsLink).Owner))
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Dim oAttachment As cAttachmentsLink = tvAttachments.SelectedObject
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
    End Sub
End Class