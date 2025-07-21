friend Class frmResurveyProperties
    Private oStations As cResurvey.cStations

    Private oStation As cResurvey.cStation

    Friend Class cResurveyPropertiesEventArgs
        Inherits EventArgs
        Private oStation As cResurvey.cStation

        Friend Sub New(station As cResurvey.cStation)
            oStation = station
        End Sub

        Public ReadOnly Property Station As cResurvey.cStation
            Get
                Return oStation
            End Get
        End Property
    End Class

    Friend Event OnApply(Sender As frmResurveyProperties, Args As cResurveyPropertiesEventArgs)
    'Friend Event OnSelectionChanged(Sender As frmResurveyProperties, Args As cResurveyPropertiesEventArgs)

    Friend Sub New(Stations As cResurvey.cStations, Station As cResurvey.cStation)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oStations = Stations

        'Call lstPlanConnectedTo.Items.Clear()
        'For Each oStation As cResurvey.cStation In oStations
        '    If oStation.Type = "" Or oStation.Type = "O" Then
        '        Call lstPlanConnectedTo.Items.Add(oStation.Name)
        '        Call lstProfileConnectedTo.Items.Add(oStation.Name)
        '    End If
        'Next

        Call tknPlan.Properties.Tokens.AddRange(oStations.ToList.Select(Function(oItem) New DevExpress.XtraEditors.TokenEditToken(oItem.Name, oItem)))
        Call tknProfile.Properties.Tokens.AddRange(oStations.ToList.Select(Function(oItem) New DevExpress.XtraEditors.TokenEditToken(oItem.Name, oItem)))

        pnlScale.Location = pnlNextStations.Location

        Call pLoadProperties(Station)
    End Sub

    Private Sub pLoadProperties(Station As cResurvey.cStation)
        oStation = Station

        txtName.Text = oStation.Name
        txtPlanPosition.Text = oStation.PlanPoint.X & ";" & oStation.PlanPoint.Y
        txtProfilePosition.Text = oStation.ProfilePoint.X & ";" & oStation.ProfilePoint.Y
        tknPlan.EditValue = Nothing
        tknProfile.EditValue = Nothing

        Select Case oStation.Type
            Case "NB"
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = False
                txtProfilePosition.Visible = False

                pnlNextStations.Visible = False
                pnlScale.Visible = False
            Case "NE"
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = False
                txtProfilePosition.Visible = False

                pnlNextStations.Visible = False
                pnlScale.Visible = False
            Case "SB"
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = False
                txtProfilePosition.Visible = False

                pnlNextStations.Visible = False
                pnlScale.Visible = False
            Case "DSB"
                lblPlanPosition.Visible = False
                txtPlanPosition.Visible = False
                lblProfilePosition.Visible = True
                txtProfilePosition.Visible = True

                pnlNextStations.Visible = False
                pnlScale.Visible = False
            Case "SE"
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = False
                txtProfilePosition.Visible = False

                pnlNextStations.Visible = False
                pnlScale.Visible = True

                txtScaleSize.Value = oStation.Scale
            Case "DSE"
                lblPlanPosition.Visible = False
                txtPlanPosition.Visible = False
                lblProfilePosition.Visible = True
                txtProfilePosition.Visible = True

                pnlNextStations.Visible = False
                pnlScale.Visible = True

                txtScaleSize.Value = oStation.Scale
            Case "¤PL"
                'plan splay
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = False
                txtProfilePosition.Visible = False

                pnlNextStations.Visible = False
                pnlScale.Visible = False

                txtProfilePosition.Visible = False
            Case "¤PR"
                'profile splay
                lblPlanPosition.Visible = False
                txtPlanPosition.Visible = False
                lblProfilePosition.Visible = True
                txtProfilePosition.Visible = True

                pnlNextStations.Visible = False
                pnlScale.Visible = False
            Case "¤"
                'user splay
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = True
                txtProfilePosition.Visible = True

                pnlNextStations.Visible = False
                pnlScale.Visible = False
            Case Else
                lblPlanPosition.Visible = True
                txtPlanPosition.Visible = True
                lblProfilePosition.Visible = True
                txtProfilePosition.Visible = True

                pnlNextStations.Visible = True
                pnlScale.Visible = False

                For Each oStation As cResurvey.cStation In oStations
                    If oStation.Type = "" Or oStation.Type = "O" Then
                        If Station.PlanConnectedTo.Contains(oStation.Name) Then tknPlan.SelectItem(oStation)
                        If Station.ProfileConnectedTo.Contains(oStation.Name) Then tknProfile.SelectItem(oStation)
                    End If
                Next
        End Select

        cmdPrev.Enabled = Not oStations.First Is oStation
        cmdNext.Enabled = Not oStations.Last Is oStation
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSaveProperties()
    End Sub

    Private Sub pSaveProperties()
        Select Case oStation.Type
            Case "SE", "DSE"
                oStation.Scale = txtScaleSize.Value
            Case Else
                Call oStation.PlanConnectedTo.Clear()
                Call tknPlan.SelectedItems.ToList.ForEach(Function(oitem) oStation.PlanConnectedTo.Add(oitem.Value.ToString))
                Call oStation.ProfileConnectedTo.Clear()
                Call tknProfile.SelectedItems.ToList.ForEach(Function(oitem) oStation.ProfileConnectedTo.Add(oitem.Value.ToString))
        End Select
    End Sub

    Private Sub cmdPropNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim iCurrentIndex As Integer = oStations.IndexOf(oStation)
        iCurrentIndex += 1
        If oStations.Count  > iCurrentIndex Then
            Dim oNewStation As cResurvey.cStation = oStations(iCurrentIndex)
            'RaiseEvent OnSelectionChanged(Me, New cResurveyPropertiesEventArgs(oNewStation))
            Call pLoadProperties(oNewStation)
        End If
    End Sub

    Private Sub cmdPropPrev_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrev.Click
        Dim iCurrentIndex As Integer = oStations.IndexOf(oStation)
        iCurrentIndex -= 1
        If iCurrentIndex >= 0 Then
            Dim oNewStation As cResurvey.cStation = oStations(iCurrentIndex)
            'RaiseEvent OnSelectionChanged(Me, New cResurveyPropertiesEventArgs(oNewStation))
            Call pLoadProperties(oNewStation)
        End If
    End Sub

    Private Sub cmdApply_Click(sender As System.Object, e As System.EventArgs) Handles cmdApply.Click
        Call pSaveProperties()
        RaiseEvent OnApply(Me, New cResurveyPropertiesEventArgs(oStation))
    End Sub

End Class