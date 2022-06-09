Imports DevExpress.XtraBars.Navigation

friend Class frmResurveyOptions
    Private oOptions As cResurvey.cOptions

    Friend Sub New(Options As cResurvey.cOptions, [Readonly] As Boolean)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
        Call tabMain.BeginUpdate()
        tabMain.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        For Each oTabControl As DevExpress.XtraTab.XtraTabPage In tabMain.TabPages
            Dim oPanel As DevExpress.XtraEditors.PanelControl = New DevExpress.XtraEditors.PanelControl
            Me.Controls.Add(oPanel)
            oPanel.Name = "_" & oTabControl.Name
            oPanel.Size = oTabControl.ClientSize
            Dim oControls As List(Of Control) = New List(Of Control)
            For Each oControl As Control In oTabControl.Controls
                Call oControls.Add(oControl)
            Next
            For Each oControl As Control In oControls
                Try
                    oPanel.Controls.Add(oControl)
                Catch ex As Exception
                End Try
            Next
            oPanel.Tag = tabMain.TabPages.IndexOf(oTabControl)
            oPanel.Dock = DockStyle.Fill
            oPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            oPanel.Visible = False
        Next
        tabMain.Visible = False
        Call tabMain.EndUpdate()

        oOptions = New cResurvey.cOptions
        Call oOptions.CopyFrom(Options)

        cboCalculateMode.SelectedIndex = oOptions.CalculateMode
        cboProfileType.SelectedIndex = oOptions.ProfileType
        txtNordCorrection.Value = oOptions.NordCorrection
        cboCalculateMode.Enabled = Not [Readonly]
        chkSkipInvalidStation.Checked = oOptions.SkipInvalidStation
        chkUseDropForInclination.Checked = oOptions.UseDropForInclination
        cboPlanScaleType.SelectedIndex = oOptions.PlanScaleType
        cboDropScaleType.SelectedIndex = oOptions.DropScaleType

        chkLRUDCalculate.Checked = oOptions.CalculateLRUD
        txtLRUDBorderWidth.Value = oOptions.LRUDBorderWidth
        txtLRMaxValue.Value = oOptions.LRMaxValue
        txtUDMaxValue.Value = oOptions.UDMaxValue
        cboLRUDStation.SelectedIndex = oOptions.LRUDStation

        cboShotDirection.SelectedIndex = 0

        AddHandler Me.Shown, Sub(sender As Object, e As EventArgs)
                                 Call pSelectTabByIndex(0)
                             End Sub
    End Sub
    Private Function pSelectTabByIndex(TabIndex As Integer) As Boolean
        Try
            Dim sName As String = tabMain.TabPages(TabIndex).Name
            For Each oElement In AccordionControl1.GetElements
                If oElement.Tag IsNot Nothing AndAlso oElement.Tag.tolower = sName.ToLower Then
                    Call AccordionControl1.SelectElement(oElement)
                    Call AccordionControl1.MakeElementVisible(oElement)
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Friend ReadOnly Property CurrentOptions As cResurvey.cOptions
        Get
            Return oOptions
        End Get
    End Property

    Private Sub cmdOk_Click(sender As Object, e As System.EventArgs) Handles cmdOk.Click
        oOptions.CalculateMode = cboCalculateMode.SelectedIndex
        oOptions.ProfileType = cboProfileType.SelectedIndex
        oOptions.NordCorrection = txtNordCorrection.Value
        oOptions.SkipInvalidStation = chkSkipInvalidStation.Checked
        oOptions.UseDropForInclination = chkUseDropForInclination.Checked
        oOptions.PlanScaleType = cboPlanScaleType.SelectedIndex
        oOptions.DropScaleType = cboDropScaleType.SelectedIndex

        oOptions.CalculateLRUD = chkLRUDCalculate.Checked
        oOptions.LRUDBorderWidth = txtLRUDBorderWidth.Value
        oOptions.LRMaxValue = txtLRMaxValue.Value
        oOptions.UDMaxValue = txtUDMaxValue.Value
        oOptions.LRUDStation = cboLRUDStation.SelectedIndex
    End Sub

    Private Sub cboCalculateMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCalculateMode.SelectedIndexChanged
        Dim bEnabled As Boolean = cboCalculateMode.SelectedIndex = 0
        chkUseDropForInclination.Enabled = bEnabled
        bEnabled = bEnabled And chkUseDropForInclination.Checked
        lblProfileType.Enabled = bEnabled
        cboProfileType.Enabled = bEnabled
        lblDropScaleType.Enabled = bEnabled
        cboDropScaleType.Enabled = bEnabled
    End Sub

    Private Sub chkUseDropForInclination_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDropForInclination.CheckedChanged
        Dim bEnabled As Boolean = chkUseDropForInclination.Checked
        lblProfileType.Enabled = bEnabled
        cboProfileType.Enabled = bEnabled
        lblDropScaleType.Enabled = bEnabled
        cboDropScaleType.Enabled = bEnabled
    End Sub

    Private Sub cboLRUDStation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLRUDStation.SelectedIndexChanged
        frmLRUDFromImages.Enabled = cboLRUDStation.SelectedIndex > 0
    End Sub

    Private Sub AccordionControl1_SelectedElementChanged(sender As Object, e As DevExpress.XtraBars.Navigation.SelectedElementChangedEventArgs) Handles AccordionControl1.SelectedElementChanged
        Dim sControlName As String = "" & e.Element.Tag
        If sControlName <> "" Then
            If Controls.ContainsKey("_" & sControlName) Then
                Call Controls("_" & sControlName).BringToFront()
                Controls("_" & sControlName).Visible = True
            End If
        End If
    End Sub

End Class