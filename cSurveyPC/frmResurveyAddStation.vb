Public Class frmResurveyAddStation
    Private oStations As Dictionary(Of String, cResurvey.cStation)
    Private iPlanOrProfile As Integer

    Private Sub optNewStation_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optNewStation.CheckedChanged
        Call pCheckChange()
    End Sub

    Private Sub pCheckChange()
        cboNewStation.Enabled = optNewStation.Checked
        If cboNewStation.Enabled Then
            Call cboNewStation.Focus()
        End If
        cboMovedStation.Enabled = optMovedStation.Checked
        cboPrevStation.Enabled = Not cboMovedStation.Enabled
        If cboMovedStation.Enabled Then
            Call cboMovedStation.Focus()
        End If
        txtScaleSize.Enabled = optSecondScale.Checked
        lblScaleUM.Enabled = txtScaleSize.Enabled
        If txtScaleSize.Enabled Then
            Call txtScaleSize.Focus()
        End If
    End Sub

    Friend Sub New(PlanOrProfile As Integer, Stations As Dictionary(Of String, cResurvey.cStation), PrevStation As String, Location As Point)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        iPlanOrProfile = PlanOrProfile

        PrevStation = PrevStation.Replace(">", "")

        oStations = Stations
        Call cboPrevStation.Items.Add("")
        For Each oStation As cResurvey.cStation In oStations.Values
            If Not oStation.Name.Contains(">") And (oStation.Type <> "SB" And oStation.Type <> "SE" And oStation.Type <> "DSB" And oStation.Type <> "DSE") Then
                Call cboPrevStation.Items.Add(oStation.Name)
                Call cboMovedStation.Items.Add(oStation.Name)
                If iPlanOrProfile = 0 Then
                    If oStation.PlanPoint.IsEmpty And oStation.Type <> "SB" And oStation.Type <> "SE" And oStation.Type <> "DSB" And oStation.Type <> "DSE" Then
                        Call cboNewStation.Items.Add(oStation.Name)
                    End If
                End If
                If iPlanOrProfile = 1 Then
                    If oStation.ProfilePoint.IsEmpty And oStation.Type <> "SB" And oStation.Type <> "SE" And oStation.Type <> "DSB" And oStation.Type <> "DSE" Then
                        Call cboNewStation.Items.Add(oStation.Name)
                    End If
                End If
            End If
        Next
        cboPrevStation.Text = PrevStation
        txtPosition.Text = "X=" & Location.X & ";" & "Y=" & Location.Y

        Call pCheckChange()
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        If optNewStation.Checked Then
            Dim sName As String = cboNewStation.Text.ToUpper.Trim
            If sName = "" Or sName.Contains("_") Or sName.Contains(">") Or sName.Contains(" ") Or sName.Contains("|") Or sName.Contains("!") Then
                Call MsgBox(GetLocalizedString("resurveyaddstation.warning1"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("resurveyaddstation.warningtitle"))
            Else
                If oStations.ContainsKey(sName) Then
                    Dim bOk As Boolean
                    If iPlanOrProfile = 0 Then
                        bOk = oStations(sName).PlanPoint.IsEmpty
                    Else
                        bOk = oStations(sName).ProfilePoint.IsEmpty
                    End If
                    If Not bOk Then
                        Call MsgBox(GetLocalizedString("resurveyaddstation.warning2"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("resurveyaddstation.warningtitle"))
                    Else
                        DialogResult = Windows.Forms.DialogResult.OK
                        Close()
                    End If
                Else
                    If sName.Contains(">") Then
                        Call MsgBox(GetLocalizedString("resurveyaddstation.warning3"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("resurveyaddstation.warningtitle"))
                    Else
                        DialogResult = Windows.Forms.DialogResult.OK
                        Close()
                    End If
                End If
            End If
        End If
            If optMovedStation.Checked Then
                Dim sName As String = cboMovedStation.Text.ToUpper.Trim
                If sName = "" Then
                Call MsgBox(GetLocalizedString("resurveyaddstation.warning4"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("resurveyaddstation.warningtitle"))
                Else
                    DialogResult = Windows.Forms.DialogResult.OK
                    Close()
                End If
            End If
            If optFirstScale.Checked Then
                DialogResult = Windows.Forms.DialogResult.OK
                Close()
            End If
            If optSecondScale.Checked Then
                Dim iScaleLen As Integer = txtScaleSize.Value
                If iScaleLen = 0 Then
                Call MsgBox(GetLocalizedString("resurveyaddstation.warning5"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("resurveyaddstation.warningtitle"))
                Else
                    DialogResult = Windows.Forms.DialogResult.OK
                    Close()
                End If
            End If
    End Sub

    Private Sub optSecondScale_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optSecondScale.CheckedChanged
        Call pCheckChange()
    End Sub

    Private Sub optFirstScale_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optFirstScale.CheckedChanged
        Call pCheckChange()
    End Sub

    Private Sub optMovedStation_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optMovedStation.CheckedChanged
        Call pCheckChange()
        If optMovedStation.Checked Then
            Try : cboMovedStation.Text = cboPrevStation.Text : Catch : End Try
        End If
    End Sub

    Private Sub cboPrevStation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPrevStation.SelectedIndexChanged
        Call pFindNext()
    End Sub

    Private Sub pFindNext()
        Dim sPrevText As String = cboPrevStation.Text

        Dim sNumber As String = ""
        Dim sPrefix As String = ""

        Dim iIndex As Integer = 0
        If iIndex < sPrevText.Length Then
            Do While Char.IsLetter(sPrevText.Chars(iIndex))
                sPrefix = sPrefix & sPrevText.Chars(iIndex)
                iIndex += 1
                If iIndex >= sPrevText.Length Then Exit Do
            Loop
        End If
        If iIndex < sPrevText.Length Then
            Do While Char.IsDigit(sPrevText.Chars(iIndex))
                sNumber = sNumber & sPrevText.Chars(iIndex)
                iIndex += 1
                If iIndex >= sPrevText.Length Then Exit Do
            Loop
        End If
        If iIndex = sPrevText.Length Then
            Dim sFormat As String = Strings.StrDup(sNumber.Length, "0")
            Dim iNumber As Integer
            Integer.TryParse(sNumber, iNumber)
            If iNumber = 0 Then
                cboNewStation.Text = ""
            Else
                iNumber += 1
                cboNewStation.Text = Strings.Format(iNumber, sFormat)
            End If
        Else
            cboNewStation.Text = ""
        End If
    End Sub
End Class