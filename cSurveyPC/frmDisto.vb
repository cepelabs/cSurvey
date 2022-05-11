friend Class frmDisto

    Friend Class cOnGetShotArgs
        Public Distance As Decimal
        Public Azimuth As Decimal
        Public Inclination As Decimal

        Friend Sub New(Distance As Decimal, Azimuth As Decimal, Inclination As Decimal)
            Me.Distance = Distance
            Me.Azimuth = Azimuth
            Me.Inclination = Inclination
        End Sub
    End Class

    Friend Event OnGetShot(Sender As frmDisto, e As cOnGetShotArgs)

    Private Sub pSettingsLoad()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
            Dim sComPort As String = oReg.GetValue("disto.lastcomport", "")
            If cboPort.Items.Contains(sComPort) Then cboPort.Text = sComPort
            'chkExportTrack.Checked = oReg.GetValue("data.export.visualtopo.track", "")
            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub

    Private Sub pSettingsSave()
        Try
            Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)
            Call oReg.SetValue("disto.lastcomport", cboPort.Text)
            Call oReg.Close()
            Call oReg.Dispose()
        Catch
        End Try
    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        If pIsConnected() Then
            Call pCloseComm()
        Else
            Call pOpenComm(cboPort.Text)
        End If
    End Sub

    Private Function pIsConnected() As Boolean
        Return SerialPort.IsOpen
    End Function

    Private Sub pOpenComm(Port As String)
        Try
            With SerialPort
                .PortName = Port
                .Open()
            End With
            cboPort.Enabled = False
            lblPort.Enabled = False
            Call pAppendText("Dispositivo collegato su " & Port)
        Catch ex As Exception
            Call pAppendText("Errore: " & ex.Message)
        End Try
    End Sub

    Private Sub pAppendText(Text As String)
        txtOutput.SelectionColor = txtOutput.ForeColor
        Call txtOutput.AppendText(Text & vbCrLf)
    End Sub

    Private Sub pAppendText(Text As String, Color As Color)
        txtOutput.SelectionColor = Color
        Call txtOutput.AppendText(Text & vbCrLf)
    End Sub

    Private Sub pCloseComm()
        Call SerialPort.Close()
        Call txtOutput.AppendText("Ricezione terminata" & vbCrLf)
        cboPort.Enabled = True
        lblPort.Enabled = True
    End Sub

    Private Sub pReceiveData()
        Dim sLine As String = ""
        Dim bInBuffer(7) As Byte
        Dim bOutBuffer(7) As Byte
        Dim iOldX, iOldY, iOldZ As Integer
        Dim bOldType As Byte
        Dim bType As Byte
        Dim iOp As Integer

        Dim iTryCount As Integer
        Dim iMaxTryCount As Integer = 10
        Do
            Try
                iTryCount += 1
                If SerialPort.BytesToRead > 0 Then
                    iTryCount = 0

                    SerialPort.Read(bInBuffer, 0, 8)
                    bType = bInBuffer(0)
                    iOp = bType And &H3F
                    If iOp < &H20 Then
                        'dati...
                        bOutBuffer(0) = bType And &H80 Or &H55
                        Call SerialPort.Write(bOutBuffer, 0, 1)
                        'Dim iX As Integer = CType(bInBuffer(1), Integer) + (bInBuffer(2) << 8)
                        'Dim iY As Integer = CType(bInBuffer(3), Integer) + (bInBuffer(4) << 8)
                        'Dim iZ As Integer = CType(bInBuffer(5), Integer) + (bInBuffer(6) << 8)
                        Dim iX As Integer = CType(bInBuffer(1), Integer) + (CType(bInBuffer(2), Integer) * 256)
                        Dim iY As Integer = CType(bInBuffer(3), Integer) + (CType(bInBuffer(4), Integer) * 256)
                        Dim iZ As Integer = CType(bInBuffer(5), Integer) + (CType(bInBuffer(6), Integer) * 256)
                        If (bType <> bOldType And iX <> iOldX And iY <> iOldY And iZ <> iOldZ) Then
                            If iOp = 1 Then
                                'survey data
                                Dim dDistance As Decimal = iX + ((bType And &H40) << 10)
                                'cm resolution above 100m
                                If (dDistance > 100000) Then dDistance = (dDistance - 90000) * 10
                                dDistance = dDistance / 1000
                                Dim dAzimuth As Decimal = modPaint.RadiansToDegree(iY) * Math.PI / 2 ^ 15
                                Dim dInclination As Decimal = modPaint.RadiansToDegree(iZ) * Math.PI / 2 ^ 15

                                dDistance = modNumbers.MathRound(dDistance, 3)
                                dAzimuth = modNumbers.MathRound(dAzimuth, 1)
                                dInclination = modNumbers.MathRound(dInclination, 1)
                                Call pAppendText("Shot: Distanza: " & dDistance & " - Azimuth: " & dAzimuth & "° - Inclinazione: " & dInclination & "°", Color.Red)
                                RaiseEvent OnGetShot(Me, New cOnGetShotArgs(dDistance, dAzimuth, dInclination))
                            End If
                            'ignore repeated packets
                            bOldType = bType
                            iOldX = iX
                            iOldY = iY
                            iOldZ = iZ
                        End If
                    End If
                End If
                'roll = input[7] << 8; // high bits of roll angle
                '} else if (op == 4) { // vector data
                'absG = x; // absolute value of G vector
                'absM = y; // absolute value of M vector
                'dip = z; // dip angle
                'roll += input[7]; // low bits of roll angle
                '} else if (op == 2) { // G calibration data
                'Gx = x; // acceleration x sensor
                'Gy = y; // acceleration y sensor
                'Gz = z; // acceleration z sensor
                '} else if (op == 3) { // M calibration data
                'Mx = x; // magnetic x sensor
                'My = y; // magnetic y sensor
                'Mz = z; // magnetic z sensor
                '}
                '// ignore unknown packets
                'oldType = type; oldX = x; oldY = y; oldZ = z;
                '}
                '}
            Catch
                Exit Do
            End Try
            Call Threading.Thread.Sleep(100)
        Loop Until iTryCount >= iMaxTryCount
    End Sub

    Private Sub SerialPort_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort.DataReceived
        Call pReceiveData()
    End Sub

    Private Sub frmDisto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call pSettingsSave()
    End Sub

    Private Sub frmDisto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each sPort As String In My.Computer.Ports.SerialPortNames
            Call cboPort.Items.Add(sPort)
        Next
    End Sub

    Private Sub SerialPort_ErrorReceived(sender As Object, e As IO.Ports.SerialErrorReceivedEventArgs) Handles SerialPort.ErrorReceived
        Call pAppendText("Errore di comuncazione", Color.Orange)
    End Sub

    Public Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()
        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Call pSettingsLoad()
    End Sub
End Class