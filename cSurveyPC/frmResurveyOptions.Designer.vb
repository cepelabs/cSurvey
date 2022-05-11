<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResurveyOptions
    Inherits DevExpress.XtraEditors.XtraForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyOptions))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cboProfileType = New System.Windows.Forms.ComboBox()
        Me.lblProfileType = New System.Windows.Forms.Label()
        Me.cboDropScaleType = New System.Windows.Forms.ComboBox()
        Me.lblDropScaleType = New System.Windows.Forms.Label()
        Me.cboPlanScaleType = New System.Windows.Forms.ComboBox()
        Me.lblPlanScaleType = New System.Windows.Forms.Label()
        Me.chkUseDropForInclination = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSkipInvalidStation = New DevExpress.XtraEditors.CheckEdit()
        Me.lblNordCorrectionDegrees = New System.Windows.Forms.Label()
        Me.lblNordCorrection = New System.Windows.Forms.Label()
        Me.cboCalculateMode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkLRUDCalculate = New DevExpress.XtraEditors.CheckEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tabCalculation = New DevExpress.XtraTab.XtraTabPage()
        Me.cboShotDirection = New System.Windows.Forms.ComboBox()
        Me.lblShotDirection = New System.Windows.Forms.Label()
        Me.txtNordCorrection = New DevExpress.XtraEditors.SpinEdit()
        Me.tabLRUD = New DevExpress.XtraTab.XtraTabPage()
        Me.cboLRUDStation = New System.Windows.Forms.ComboBox()
        Me.lblLRUDStation = New System.Windows.Forms.Label()
        Me.frmLRUDFromImages = New DevExpress.XtraEditors.GroupControl()
        Me.txtUDMaxValue = New DevExpress.XtraEditors.SpinEdit()
        Me.txtLRMaxValue = New DevExpress.XtraEditors.SpinEdit()
        Me.txtLRUDBorderWidth = New DevExpress.XtraEditors.SpinEdit()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.chkUseDropForInclination.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSkipInvalidStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLRUDCalculate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.tabCalculation.SuspendLayout()
        CType(Me.txtNordCorrection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLRUD.SuspendLayout()
        CType(Me.frmLRUDFromImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmLRUDFromImages.SuspendLayout()
        CType(Me.txtUDMaxValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLRMaxValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLRUDBorderWidth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cboProfileType
        '
        Me.cboProfileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProfileType.FormattingEnabled = True
        Me.cboProfileType.Items.AddRange(New Object() {resources.GetString("cboProfileType.Items"), resources.GetString("cboProfileType.Items1")})
        resources.ApplyResources(Me.cboProfileType, "cboProfileType")
        Me.cboProfileType.Name = "cboProfileType"
        '
        'lblProfileType
        '
        resources.ApplyResources(Me.lblProfileType, "lblProfileType")
        Me.lblProfileType.Name = "lblProfileType"
        '
        'cboDropScaleType
        '
        Me.cboDropScaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboDropScaleType, "cboDropScaleType")
        Me.cboDropScaleType.FormattingEnabled = True
        Me.cboDropScaleType.Items.AddRange(New Object() {resources.GetString("cboDropScaleType.Items"), resources.GetString("cboDropScaleType.Items1"), resources.GetString("cboDropScaleType.Items2")})
        Me.cboDropScaleType.Name = "cboDropScaleType"
        '
        'lblDropScaleType
        '
        resources.ApplyResources(Me.lblDropScaleType, "lblDropScaleType")
        Me.lblDropScaleType.Name = "lblDropScaleType"
        '
        'cboPlanScaleType
        '
        Me.cboPlanScaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlanScaleType.FormattingEnabled = True
        Me.cboPlanScaleType.Items.AddRange(New Object() {resources.GetString("cboPlanScaleType.Items"), resources.GetString("cboPlanScaleType.Items1"), resources.GetString("cboPlanScaleType.Items2")})
        resources.ApplyResources(Me.cboPlanScaleType, "cboPlanScaleType")
        Me.cboPlanScaleType.Name = "cboPlanScaleType"
        '
        'lblPlanScaleType
        '
        resources.ApplyResources(Me.lblPlanScaleType, "lblPlanScaleType")
        Me.lblPlanScaleType.Name = "lblPlanScaleType"
        '
        'chkUseDropForInclination
        '
        resources.ApplyResources(Me.chkUseDropForInclination, "chkUseDropForInclination")
        Me.chkUseDropForInclination.Name = "chkUseDropForInclination"
        Me.chkUseDropForInclination.Properties.Caption = resources.GetString("chkUseDropForInclination.Properties.Caption")
        '
        'chkSkipInvalidStation
        '
        resources.ApplyResources(Me.chkSkipInvalidStation, "chkSkipInvalidStation")
        Me.chkSkipInvalidStation.Name = "chkSkipInvalidStation"
        Me.chkSkipInvalidStation.Properties.Caption = resources.GetString("chkSkipInvalidStation.Properties.Caption")
        '
        'lblNordCorrectionDegrees
        '
        resources.ApplyResources(Me.lblNordCorrectionDegrees, "lblNordCorrectionDegrees")
        Me.lblNordCorrectionDegrees.Name = "lblNordCorrectionDegrees"
        '
        'lblNordCorrection
        '
        resources.ApplyResources(Me.lblNordCorrection, "lblNordCorrection")
        Me.lblNordCorrection.Name = "lblNordCorrection"
        '
        'cboCalculateMode
        '
        Me.cboCalculateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalculateMode.FormattingEnabled = True
        Me.cboCalculateMode.Items.AddRange(New Object() {resources.GetString("cboCalculateMode.Items"), resources.GetString("cboCalculateMode.Items1")})
        resources.ApplyResources(Me.cboCalculateMode, "cboCalculateMode")
        Me.cboCalculateMode.Name = "cboCalculateMode"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'chkLRUDCalculate
        '
        resources.ApplyResources(Me.chkLRUDCalculate, "chkLRUDCalculate")
        Me.chkLRUDCalculate.Name = "chkLRUDCalculate"
        Me.chkLRUDCalculate.Properties.Caption = resources.GetString("chkLRUDCalculate.Properties.Caption")
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'XtraTabControl1
        '
        resources.ApplyResources(Me.XtraTabControl1, "XtraTabControl1")
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.tabCalculation
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabCalculation, Me.tabLRUD})
        '
        'tabCalculation
        '
        Me.tabCalculation.Controls.Add(Me.cboShotDirection)
        Me.tabCalculation.Controls.Add(Me.lblShotDirection)
        Me.tabCalculation.Controls.Add(Me.txtNordCorrection)
        Me.tabCalculation.Controls.Add(Me.cboProfileType)
        Me.tabCalculation.Controls.Add(Me.lblProfileType)
        Me.tabCalculation.Controls.Add(Me.cboCalculateMode)
        Me.tabCalculation.Controls.Add(Me.cboDropScaleType)
        Me.tabCalculation.Controls.Add(Me.Label1)
        Me.tabCalculation.Controls.Add(Me.lblDropScaleType)
        Me.tabCalculation.Controls.Add(Me.lblNordCorrection)
        Me.tabCalculation.Controls.Add(Me.cboPlanScaleType)
        Me.tabCalculation.Controls.Add(Me.lblPlanScaleType)
        Me.tabCalculation.Controls.Add(Me.lblNordCorrectionDegrees)
        Me.tabCalculation.Controls.Add(Me.chkUseDropForInclination)
        Me.tabCalculation.Controls.Add(Me.chkSkipInvalidStation)
        Me.tabCalculation.Name = "tabCalculation"
        resources.ApplyResources(Me.tabCalculation, "tabCalculation")
        '
        'cboShotDirection
        '
        Me.cboShotDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShotDirection.FormattingEnabled = True
        Me.cboShotDirection.Items.AddRange(New Object() {resources.GetString("cboShotDirection.Items")})
        resources.ApplyResources(Me.cboShotDirection, "cboShotDirection")
        Me.cboShotDirection.Name = "cboShotDirection"
        '
        'lblShotDirection
        '
        resources.ApplyResources(Me.lblShotDirection, "lblShotDirection")
        Me.lblShotDirection.Name = "lblShotDirection"
        '
        'txtNordCorrection
        '
        resources.ApplyResources(Me.txtNordCorrection, "txtNordCorrection")
        Me.txtNordCorrection.Name = "txtNordCorrection"
        Me.txtNordCorrection.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtNordCorrection.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtNordCorrection.Properties.DisplayFormat.FormatString = "N2"
        Me.txtNordCorrection.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNordCorrection.Properties.EditFormat.FormatString = "N2"
        Me.txtNordCorrection.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtNordCorrection.Properties.Mask.EditMask = resources.GetString("txtNordCorrection.Properties.Mask.EditMask")
        '
        'tabLRUD
        '
        Me.tabLRUD.Controls.Add(Me.cboLRUDStation)
        Me.tabLRUD.Controls.Add(Me.lblLRUDStation)
        Me.tabLRUD.Controls.Add(Me.frmLRUDFromImages)
        Me.tabLRUD.Name = "tabLRUD"
        resources.ApplyResources(Me.tabLRUD, "tabLRUD")
        '
        'cboLRUDStation
        '
        Me.cboLRUDStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLRUDStation.FormattingEnabled = True
        Me.cboLRUDStation.Items.AddRange(New Object() {resources.GetString("cboLRUDStation.Items"), resources.GetString("cboLRUDStation.Items1"), resources.GetString("cboLRUDStation.Items2")})
        resources.ApplyResources(Me.cboLRUDStation, "cboLRUDStation")
        Me.cboLRUDStation.Name = "cboLRUDStation"
        '
        'lblLRUDStation
        '
        resources.ApplyResources(Me.lblLRUDStation, "lblLRUDStation")
        Me.lblLRUDStation.Name = "lblLRUDStation"
        '
        'frmLRUDFromImages
        '
        Me.frmLRUDFromImages.Controls.Add(Me.txtUDMaxValue)
        Me.frmLRUDFromImages.Controls.Add(Me.txtLRMaxValue)
        Me.frmLRUDFromImages.Controls.Add(Me.txtLRUDBorderWidth)
        Me.frmLRUDFromImages.Controls.Add(Me.Label6)
        Me.frmLRUDFromImages.Controls.Add(Me.chkLRUDCalculate)
        Me.frmLRUDFromImages.Controls.Add(Me.Label3)
        Me.frmLRUDFromImages.Controls.Add(Me.Label7)
        Me.frmLRUDFromImages.Controls.Add(Me.Label4)
        Me.frmLRUDFromImages.Controls.Add(Me.Label2)
        Me.frmLRUDFromImages.Controls.Add(Me.Label5)
        resources.ApplyResources(Me.frmLRUDFromImages, "frmLRUDFromImages")
        Me.frmLRUDFromImages.Name = "frmLRUDFromImages"
        '
        'txtUDMaxValue
        '
        resources.ApplyResources(Me.txtUDMaxValue, "txtUDMaxValue")
        Me.txtUDMaxValue.Name = "txtUDMaxValue"
        Me.txtUDMaxValue.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtUDMaxValue.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtUDMaxValue.Properties.DisplayFormat.FormatString = "N1"
        Me.txtUDMaxValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtUDMaxValue.Properties.EditFormat.FormatString = "N0"
        Me.txtUDMaxValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtUDMaxValue.Properties.Mask.EditMask = resources.GetString("txtUDMaxValue.Properties.Mask.EditMask")
        '
        'txtLRMaxValue
        '
        resources.ApplyResources(Me.txtLRMaxValue, "txtLRMaxValue")
        Me.txtLRMaxValue.Name = "txtLRMaxValue"
        Me.txtLRMaxValue.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLRMaxValue.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtLRMaxValue.Properties.DisplayFormat.FormatString = "N1"
        Me.txtLRMaxValue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLRMaxValue.Properties.EditFormat.FormatString = "N0"
        Me.txtLRMaxValue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLRMaxValue.Properties.Mask.EditMask = resources.GetString("txtLRMaxValue.Properties.Mask.EditMask")
        '
        'txtLRUDBorderWidth
        '
        resources.ApplyResources(Me.txtLRUDBorderWidth, "txtLRUDBorderWidth")
        Me.txtLRUDBorderWidth.Name = "txtLRUDBorderWidth"
        Me.txtLRUDBorderWidth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLRUDBorderWidth.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtLRUDBorderWidth.Properties.DisplayFormat.FormatString = "N0"
        Me.txtLRUDBorderWidth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLRUDBorderWidth.Properties.EditFormat.FormatString = "N0"
        Me.txtLRUDBorderWidth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLRUDBorderWidth.Properties.IsFloatValue = False
        Me.txtLRUDBorderWidth.Properties.Mask.EditMask = resources.GetString("txtLRUDBorderWidth.Properties.Mask.EditMask")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.XtraTabControl1)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'frmResurveyOptions
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.IconOptions.Icon = CType(resources.GetObject("frmResurveyOptions.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.parameters
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyOptions"
        CType(Me.chkUseDropForInclination.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSkipInvalidStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLRUDCalculate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.tabCalculation.ResumeLayout(False)
        Me.tabCalculation.PerformLayout()
        CType(Me.txtNordCorrection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLRUD.ResumeLayout(False)
        Me.tabLRUD.PerformLayout()
        CType(Me.frmLRUDFromImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmLRUDFromImages.ResumeLayout(False)
        Me.frmLRUDFromImages.PerformLayout()
        CType(Me.txtUDMaxValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLRMaxValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLRUDBorderWidth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboCalculateMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNordCorrection As System.Windows.Forms.Label
    Friend WithEvents lblNordCorrectionDegrees As System.Windows.Forms.Label
    Friend WithEvents chkSkipInvalidStation As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkLRUDCalculate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkUseDropForInclination As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDropScaleType As ComboBox
    Friend WithEvents lblDropScaleType As Label
    Friend WithEvents cboPlanScaleType As ComboBox
    Friend WithEvents lblPlanScaleType As Label
    Friend WithEvents cboProfileType As ComboBox
    Friend WithEvents lblProfileType As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabCalculation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabLRUD As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents frmLRUDFromImages As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtNordCorrection As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtLRUDBorderWidth As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtUDMaxValue As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtLRMaxValue As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cboShotDirection As ComboBox
    Friend WithEvents lblShotDirection As Label
    Friend WithEvents cboLRUDStation As ComboBox
    Friend WithEvents lblLRUDStation As Label
End Class
