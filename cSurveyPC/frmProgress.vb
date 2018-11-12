Public Class frmProgress
    Private Class TaskBag
        Public Index As Integer
        Public Begins As Integer

        Public Sub New(Index As Integer, Begins As Integer)
            Me.Index = Index
            Me.Begins = Begins
        End Sub
    End Class
    Private oTasks As Dictionary(Of String, TaskBag)

    Private iPanelHeight As Integer = 105

    Private Delegate Sub pBeginProgressDelegate(Task As String, ActionImage As String, Title As String, Show As Boolean)

    Public Sub BeginProgress(Task As String, ActionImage As String, Title As String, Show As Boolean)
        If InvokeRequired Then
            Dim oArgs(3) As Object
            oArgs(0) = Task
            oArgs(1) = ActionImage
            oArgs(2) = Title
            oArgs(3) = Show
            Call Me.BeginInvoke(New pBeginProgressDelegate(AddressOf BeginProgress), oArgs)
        Else
            Try
                Dim iRowIndex As Integer
                Dim oPanel As cProgressPanel
                If oTasks.ContainsKey(Task) Then
                    With oTasks(Task)
                        iRowIndex = .Index
                        .Begins += 1
                    End With
                    oPanel = tblPanels.Controls("pnl" & iRowIndex)
                Else
                    iRowIndex = tblPanels.RowCount
                    tblPanels.RowStyles.Add(New RowStyle(SizeType.AutoSize))
                    tblPanels.RowCount += 1
                    Call oTasks.Add(Task, New TaskBag(iRowIndex, 1))

                    oPanel = New cProgressPanel
                    oPanel.Name = "pnl" & iRowIndex
                End If

                With oPanel
                    .pb.Minimum = 0
                    .pb.Maximum = 100
                    Try
                        .picAction.Image = iml.Images(ActionImage)
                    Catch
                        .picAction.Image = iml.Images("default")
                    End Try
                    .lblTitle.Text = Title
                    If Show Then
                        Text = "cSurvey - " & Title
                    End If
                End With
                Dim oBound As Rectangle = ClientRectangle
                Dim iBordersHeight As Integer = Height - oBound.Height
                oPanel.Size = New Size(oBound.Size.Width, iPanelHeight)
                'aggiungo il panel
                Call tblPanels.Controls.Add(oPanel, 0, iRowIndex)
                ' ridimensiono la finestra
                Height = iBordersHeight + oTasks.Count * iPanelHeight
                If Show Then
                    Call Me.CenterToScreen()
                    Call Me.Show()
                End If
                Call Refresh()
            Catch
            End Try
        End If
    End Sub

    Private Delegate Sub pResetProgressDelegate()

    Public Sub ResetProgress()
        If InvokeRequired Then
            Call Me.BeginInvoke(New pResetProgressDelegate(AddressOf ResetProgress), Nothing)
        Else
            'non elimino niente perché elimino direttamente la form...
            Call Hide()
            Call Close()
            Call Dispose()
        End If
    End Sub

    Private Delegate Sub pEndProgressDelegate(Task As String)

    Public Function EndProgress(Task As String) As Boolean
        If InvokeRequired Then
            If Task = "" Then Task = "" & Threading.Thread.CurrentThread.Name
            Dim oArgs(0) As Object
            oArgs(0) = Task
            Call Me.BeginInvoke(New pEndProgressDelegate(AddressOf EndProgress), oArgs)
        Else
            Try
                If Task = "" Then Task = oTasks.Last.Key
                If oTasks.ContainsKey(Task) Then
                    Dim iIndex As Integer = oTasks(Task).Index
                    Dim iBegins As Integer = oTasks(Task).Begins
                    iBegins -= 1
                    oTasks(Task).Begins = iBegins
                    If iBegins <= 0 Then
                        Dim oPanel As cProgressPanel = tblPanels.Controls("pnl" & iIndex)
                        tblPanels.Controls.Remove(oPanel)
                        Call oTasks.Remove(Task)
                        If oTasks.Count > 0 Then
                            Height = Height - oPanel.Height
                            Call Refresh()
                            Return False
                        Else
                            Call Hide()
                            Call Close()
                            Call Dispose()
                            Return True
                        End If
                    End If
                Else
                    Call Hide()
                    Call Close()
                    Call Dispose()
                    Return True
                End If
            Catch
                Call Hide()
                Call Close()
                Call Dispose()
                Return True
            End Try
        End If
    End Function

    Private Delegate Sub pStatusProgressDelegate(Task As String, ByVal Percent As Single, ByVal Details As String)

    Public Sub StatusProgress(Task As String, ByVal Percent As Single, Optional ByVal Details As String = "")
        If InvokeRequired Then
            If Task = "" Then Task = "" & Threading.Thread.CurrentThread.Name
            Dim oArgs(2) As Object
            oArgs(0) = Task
            oArgs(1) = Percent
            oArgs(2) = Details
            Call Me.BeginInvoke(New pStatusProgressDelegate(AddressOf StatusProgress), oArgs)
        Else
            If Task = "" Then Task = oTasks.Last.Key
            If oTasks.ContainsKey(Task) Then
                Dim iIndex As Integer = oTasks(Task).Index
                Dim oPanel As cProgressPanel = tblPanels.Controls("pnl" & iIndex)
                With oPanel
                    .pb.Value = Percent * 100
                    .lblDetails.Text = Details & " " & Strings.Format(Percent, "percent")
                    .Refresh()
                End With
                Call Refresh()
            End If
        End If
    End Sub

    Private Sub frmProgress_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
        End If
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        iPanelHeight = iPanelHeight * DPIRatio
        oTasks = New Dictionary(Of String, TaskBag)
        Call tblPanels.Controls.Remove(pnlDefault)
        Height -= iPanelHeight
    End Sub
End Class