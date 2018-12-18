Public Class frmResurveyOptions
    Private oOptions As cResurvey.cOptions

    Friend Sub New(Options As cResurvey.cOptions, [Readonly] As Boolean)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oOptions = New cResurvey.cOptions
        Call oOptions.CopyFrom(Options)

        cboCalculateMode.SelectedIndex = oOptions.CalculateMode
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
        'cmdOk.Enabled = Not [Readonly]
    End Sub

    Friend ReadOnly Property CurrentOptions As cResurvey.cOptions
        Get
            Return oOptions
        End Get
    End Property

    Private Sub cmdOk_Click(sender As Object, e As System.EventArgs) Handles cmdOk.Click
        oOptions.CalculateMode = cboCalculateMode.SelectedIndex
        oOptions.NordCorrection = txtNordCorrection.Value
        oOptions.SkipInvalidStation = chkSkipInvalidStation.Checked
        oOptions.UseDropForInclination = chkUseDropForInclination.Checked
        oOptions.PlanScaleType = cboPlanScaleType.SelectedIndex
        oOptions.DropScaleType = cboDropScaleType.SelectedIndex

        oOptions.CalculateLRUD = chkLRUDCalculate.Checked
        oOptions.LRUDBorderWidth = txtLRUDBorderWidth.Value
        oOptions.LRMaxValue = txtLRMaxValue.Value
        oOptions.UDMaxValue = txtUDMaxValue.Value
    End Sub

    Private Sub cboCalculateMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCalculateMode.SelectedIndexChanged
        chkUseDropForInclination.Enabled = cboCalculateMode.SelectedIndex = 0
    End Sub

    Private Sub chkUseDropForInclination_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseDropForInclination.CheckedChanged
        Dim bEnabled As Boolean = chkUseDropForInclination.Checked
        lblDropScaleType.Enabled = bEnabled
        cboDropScaleType.Enabled = bEnabled
    End Sub
End Class