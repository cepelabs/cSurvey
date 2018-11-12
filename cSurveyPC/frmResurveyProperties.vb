Public Class frmResurveyProperties
    Private oStations As Dictionary(Of String, cResurvey.cStation)
    Private oStationsList As List(Of cResurvey.cStation)

    Private oStation As cResurvey.cStation

    Friend Class cResurveyPropertiesEventArgs
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

    Friend Sub New(Stations As Dictionary(Of String, cResurvey.cStation), Station As cResurvey.cStation)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oStations = Stations
        oStationsList = New List(Of cResurvey.cStation)(oStations.Values)

        Call lstPlanConnectedTo.Items.Clear()
        For Each oStation As cResurvey.cStation In oStations.Values
            If oStation.Type = "" Or oStation.Type = "O" Then
                Call lstPlanConnectedTo.Items.Add(oStation.Name)
                Call lstProfileConnectedTo.Items.Add(oStation.Name)
            End If
        Next

        Call pLoadProperties(Station)
    End Sub

    Private Sub pLoadProperties(Station As cResurvey.cStation)
        oStation = Station

        txtName.Text = oStation.Name
        txtPlanPosition.Text = oStation.PlanPoint.X & ";" & oStation.PlanPoint.Y
        txtProfilePosition.Text = oStation.ProfilePoint.X & ";" & oStation.ProfilePoint.Y

        Select Case oStation.Type
            Case "SB", "DSB"
                lblConnectedTo.Visible = False
                tabConnectedTo.Visible = False

                lblScaleSize.Visible = False
                txtScaleSize.Visible = False
                lblScaleUM.Visible = False
            Case "SE", "DSE"
                lblConnectedTo.Visible = False
                tabConnectedTo.Visible = False

                lblScaleSize.Visible = True
                txtScaleSize.Visible = True
                lblScaleUM.Visible = True

                txtScaleSize.Value = oStation.Scale
            Case Else
                lblConnectedTo.Visible = True
                tabConnectedTo.Visible = True

                lblScaleSize.Visible = False
                txtScaleSize.Visible = False
                lblScaleUM.Visible = False

                Dim oPlanConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oStation.PlanConnectedTo)
                Dim oProfileConnectedTo As List(Of String) = cResurvey.cStation.GetConnectedToCollection(oStation.ProfileConnectedTo)
                For Each oStation As cResurvey.cStation In oStations.Values
                    If oStation.Type = "" Or oStation.Type = "O" Then
                        Call lstPlanConnectedTo.SetItemChecked(lstPlanConnectedTo.Items.IndexOf(oStation.Name), oPlanConnectedTo.Contains(oStation.Name))
                        Call lstProfileConnectedTo.SetItemChecked(lstProfileConnectedTo.Items.IndexOf(oStation.Name), oProfileConnectedTo.Contains(oStation.Name))
                    End If
                Next
        End Select

        cmdPrev.Enabled = Not oStationsList.First Is oStation
        cmdNext.Enabled = Not oStationsList.Last Is oStation
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call pSaveProperties()
    End Sub

    Private Sub pSaveProperties()
        Select Case oStation.Type
            Case "SE", "DSE"
                oStation.Scale = txtScaleSize.Value
            Case Else
                oStation.PlanConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(New List(Of String)(lstPlanConnectedTo.CheckedItems.Cast(Of String)))
                oStation.ProfileConnectedTo = cResurvey.cStation.SetConnectedToFromCollection(New List(Of String)(lstProfileConnectedTo.CheckedItems.Cast(Of String)))
                oStation.Row.Cells(4).Value = oStation.PlanConnectedTo
                oStation.Row.Cells(5).Value = oStation.ProfileConnectedTo
        End Select
    End Sub

    Private Sub cmdPropNext_Click(sender As System.Object, e As System.EventArgs) Handles cmdNext.Click
        Dim iCurrentIndex As Integer = oStationsList.IndexOf(oStation)
        If oStationsList.Count - 1 > iCurrentIndex Then
            Call pLoadProperties(oStationsList(iCurrentIndex + 1))
        End If
    End Sub

    Private Sub cmdPropPrev_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrev.Click
        Dim iCurrentIndex As Integer = oStationsList.IndexOf(oStation)
        If iCurrentIndex > 0 Then
            Call pLoadProperties(oStationsList(iCurrentIndex - 1))
        End If
    End Sub

    Private Sub cmdApply_Click(sender As System.Object, e As System.EventArgs) Handles cmdApply.Click
        Call pSaveProperties()
        RaiseEvent OnApply(Me, New cResurveyPropertiesEventArgs(oStation))
    End Sub
End Class