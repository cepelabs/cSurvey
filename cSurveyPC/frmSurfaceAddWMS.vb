Imports cSurveyPC.cSurvey.Surface

Public Class frmSurfaceAddWMS

    Public Sub SetLayer(Layer As String)
        Dim iIndex As Integer = 0
        For Each sLayer As String In Layer.Split(",")
            If Not lvLayers.Items.ContainsKey(sLayer) Then
                Dim oItem As ListViewItem = New ListViewItem
                oItem.Name = sLayer
                oItem.Text = sLayer
                Call oItem.SubItems.Add("-")
                Call oItem.SubItems.Add("-")
                oItem.Tag = New cWMSLayer(sLayer)
                Call lvLayers.Items.Add(oItem)
            End If
            lvLayers.Items(sLayer).Checked = True
            'Call lstLayer.Items.Add(sLayer)
            'Call lstLayer.SetItemChecked(iIndex, True)
            iIndex += 1
        Next
        Call pRefreshLayers()
    End Sub

    Public Function getoverridesrs() As String
        If cboSRSOverride.SelectedIndex = 0 Then
            Return ""
        Else
            Return cboSRSOverride.Text
        End If
    End Function

    Public Function GetLayer() As String
        Dim sLayers As String = ""
        For Each oItem As ListViewItem In lvLayers.CheckedItems
            'Dim oLayer As cWMSLayer = oItem.Tag
            Dim sLayer As String = oItem.Name
            If sLayers <> "" Then sLayers &= ","
            sLayers &= sLayer
        Next
        'For Each sLayer As String In lstLayer.CheckedItems
        '    If sLayers <> "" Then sLayers &= ","
        '    sLayers &= sLayer
        'Next
        Return sLayers
    End Function

    Private Sub pRefreshLayers()
        Cursor = Cursors.WaitCursor
        Dim oBackupList As List(Of String) = New List(Of String)
        For Each oItem As ListViewItem In lvLayers.CheckedItems
            Call oBackupList.Add(oItem.Name)
        Next
        Call lvLayers.Items.Clear()
        Dim sURL As String = txtURL.Text
        Dim oList As List(Of cWMSLayer) = New List(Of cWMSLayer)
        If modWMSManager.WMSDownloadLayerList(sURL, 1, oList) Then
            Dim iIndex As Integer = 0
            For Each oLayer As cWMSLayer In oList
                Dim sName As String = oLayer.Name

                Dim oItem As ListViewItem
                If lvLayers.Items.ContainsKey(sName) Then
                    oItem = lvLayers.Items(sName)
                Else
                    oItem = New ListViewItem()
                    Call lvLayers.Items.Add(oItem)
                End If
                oItem.Name = sName
                oItem.Text = sName
                If oBackupList.Contains(sName) Then
                    oItem.Checked = True
                End If
                Call oItem.SubItems.Add(String.Join(";", oLayer.SRS))
                Call oItem.SubItems.Add(String.Join(";", oLayer.ImageFormats))
                oItem.Tag = oLayer

                iIndex += 1
            Next
            If oBackupList.Count = 0 AndAlso lvLayers.Items.Count > 0 Then
                lvLayers.Items(0).Checked = True
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function pFormatURL(URL As String) As String
        'If URL.Contains("?") Then
        '    Return URL.Substring(0, URL.IndexOf("?"))
        'Else
        '    Return URL
        'End If
        If URL.Contains("?") Then
            Return URL
        Else
            Return URL & "?"
        End If
    End Function

    Private Sub btnLayerRefresh_Click(sender As Object, e As EventArgs) Handles btnLayerRefresh.Click
        Call pRefreshLayers()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If txtName.Text <> "" And txtURL.Text <> "" And lvLayers.CheckedItems.Count > 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            Call MsgBox(GetLocalizedString("surface.warning7"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
        End If
    End Sub

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        cboSRSOverride.SelectedIndex = 0
    End Sub

    Public Sub New(Name As String, URL As String, Layer As String, SRSOverride As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        txtName.Text = Name
        txtURL.Text = URL
        Call SetLayer(Layer)
        If SRSOverride <> "" Then
            cboSRSOverride.Text = SRSOverride
        Else
            cboSRSOverride.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtURL_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtURL.Validating
        Dim sURL As String = pFormatURL(txtURL.Text)
        If sURL <> txtURL.Text Then
            txtURL.Text = sURL
        End If
    End Sub

End Class