<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplay
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplay))
        Me.chkCrossSection = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlCrosssection = New DevExpress.XtraEditors.PanelControl()
        Me.chkPropCrossSectionShowOnlyCutSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPropCrossSectionSplayProjectionAngle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropCrossSectionSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkPropCrossSectionShowSplayBorder = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPropCrossSectionSplayLineStyle = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropCrossSectionSplayLineStyle = New System.Windows.Forms.ComboBox()
        Me.lblPropCrossSectionSplayMaxVariationAngle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropCrossSectionSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkPropCrossSectionSplayText = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPlan = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlPlan = New DevExpress.XtraEditors.PanelControl()
        Me.cboPropPlanSplayPlanProjectionType = New System.Windows.Forms.ComboBox()
        Me.lblPropPlanSplayInclinationRange = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropPlanSplayMaxVariationDelta = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayPlanDeltaZ = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropPlanSplayPlanProjectionType = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPlanSplayMaxVariationDelta = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropPlanSplayPlanDeltaZ = New DevExpress.XtraEditors.LabelControl()
        Me.pnlProfile = New DevExpress.XtraEditors.PanelControl()
        Me.txtPropProfileSplayNegInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayNegInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayNegInclinationRange = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropProfileSplayPosInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayPosInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayPosInclinationRange = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropProfileSplayProjectionAngle = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropProfileSplayMaxVariationAngle = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropProfileSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkProfile = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.tabMain = New DevExpress.XtraTab.XtraTabControl()
        Me.tabPlan = New DevExpress.XtraTab.XtraTabPage()
        Me.tabProfile = New DevExpress.XtraTab.XtraTabPage()
        Me.tabCrossSections = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.chkCrossSection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlCrosssection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCrosssection.SuspendLayout()
        CType(Me.chkPropCrossSectionShowOnlyCutSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropCrossSectionShowSplayBorder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropCrossSectionSplayText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPlan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPlan.SuspendLayout()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlProfile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProfile.SuspendLayout()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabPlan.SuspendLayout()
        Me.tabProfile.SuspendLayout()
        Me.tabCrossSections.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkCrossSection
        '
        resources.ApplyResources(Me.chkCrossSection, "chkCrossSection")
        Me.chkCrossSection.Name = "chkCrossSection"
        Me.chkCrossSection.Properties.AutoWidth = True
        Me.chkCrossSection.Properties.Caption = resources.GetString("chkCrossSection.Properties.Caption")
        '
        'pnlCrosssection
        '
        Me.pnlCrosssection.Controls.Add(Me.chkPropCrossSectionShowOnlyCutSplay)
        Me.pnlCrosssection.Controls.Add(Me.lblPropCrossSectionSplayProjectionAngle)
        Me.pnlCrosssection.Controls.Add(Me.txtPropCrossSectionSplayProjectionAngle)
        Me.pnlCrosssection.Controls.Add(Me.chkPropCrossSectionShowSplayBorder)
        Me.pnlCrosssection.Controls.Add(Me.lblPropCrossSectionSplayLineStyle)
        Me.pnlCrosssection.Controls.Add(Me.cboPropCrossSectionSplayLineStyle)
        Me.pnlCrosssection.Controls.Add(Me.lblPropCrossSectionSplayMaxVariationAngle)
        Me.pnlCrosssection.Controls.Add(Me.txtPropCrossSectionSplayMaxVariationAngle)
        Me.pnlCrosssection.Controls.Add(Me.chkPropCrossSectionSplayText)
        resources.ApplyResources(Me.pnlCrosssection, "pnlCrosssection")
        Me.pnlCrosssection.Name = "pnlCrosssection"
        '
        'chkPropCrossSectionShowOnlyCutSplay
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowOnlyCutSplay, "chkPropCrossSectionShowOnlyCutSplay")
        Me.chkPropCrossSectionShowOnlyCutSplay.Name = "chkPropCrossSectionShowOnlyCutSplay"
        Me.chkPropCrossSectionShowOnlyCutSplay.Properties.AutoWidth = True
        Me.chkPropCrossSectionShowOnlyCutSplay.Properties.Caption = resources.GetString("chkPropCrossSectionShowOnlyCutSplay.Properties.Caption")
        '
        'lblPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayProjectionAngle, "lblPropCrossSectionSplayProjectionAngle")
        Me.lblPropCrossSectionSplayProjectionAngle.Name = "lblPropCrossSectionSplayProjectionAngle"
        '
        'txtPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayProjectionAngle, "txtPropCrossSectionSplayProjectionAngle")
        Me.txtPropCrossSectionSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionSplayProjectionAngle.Name = "txtPropCrossSectionSplayProjectionAngle"
        '
        'chkPropCrossSectionShowSplayBorder
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowSplayBorder, "chkPropCrossSectionShowSplayBorder")
        Me.chkPropCrossSectionShowSplayBorder.Name = "chkPropCrossSectionShowSplayBorder"
        Me.chkPropCrossSectionShowSplayBorder.Properties.AutoWidth = True
        Me.chkPropCrossSectionShowSplayBorder.Properties.Caption = resources.GetString("chkPropCrossSectionShowSplayBorder.Properties.Caption")
        '
        'lblPropCrossSectionSplayLineStyle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayLineStyle, "lblPropCrossSectionSplayLineStyle")
        Me.lblPropCrossSectionSplayLineStyle.Name = "lblPropCrossSectionSplayLineStyle"
        '
        'cboPropCrossSectionSplayLineStyle
        '
        Me.cboPropCrossSectionSplayLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionSplayLineStyle, "cboPropCrossSectionSplayLineStyle")
        Me.cboPropCrossSectionSplayLineStyle.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionSplayLineStyle.Items"), resources.GetString("cboPropCrossSectionSplayLineStyle.Items1")})
        Me.cboPropCrossSectionSplayLineStyle.Name = "cboPropCrossSectionSplayLineStyle"
        '
        'lblPropCrossSectionSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayMaxVariationAngle, "lblPropCrossSectionSplayMaxVariationAngle")
        Me.lblPropCrossSectionSplayMaxVariationAngle.Name = "lblPropCrossSectionSplayMaxVariationAngle"
        '
        'txtPropCrossSectionSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayMaxVariationAngle, "txtPropCrossSectionSplayMaxVariationAngle")
        Me.txtPropCrossSectionSplayMaxVariationAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayMaxVariationAngle.Name = "txtPropCrossSectionSplayMaxVariationAngle"
        '
        'chkPropCrossSectionSplayText
        '
        resources.ApplyResources(Me.chkPropCrossSectionSplayText, "chkPropCrossSectionSplayText")
        Me.chkPropCrossSectionSplayText.Name = "chkPropCrossSectionSplayText"
        Me.chkPropCrossSectionSplayText.Properties.AutoWidth = True
        Me.chkPropCrossSectionSplayText.Properties.Caption = resources.GetString("chkPropCrossSectionSplayText.Properties.Caption")
        '
        'chkPlan
        '
        resources.ApplyResources(Me.chkPlan, "chkPlan")
        Me.chkPlan.Name = "chkPlan"
        Me.chkPlan.Properties.AutoWidth = True
        Me.chkPlan.Properties.Caption = resources.GetString("chkPlan.Properties.Caption")
        '
        'pnlPlan
        '
        Me.pnlPlan.Controls.Add(Me.cboPropPlanSplayPlanProjectionType)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayInclinationRange)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayMaxVariationDelta)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayInclinationRangeMax)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayPlanDeltaZ)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayInclinationRangeMin)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayPlanProjectionType)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayMaxVariationDelta)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayPlanDeltaZ)
        resources.ApplyResources(Me.pnlPlan, "pnlPlan")
        Me.pnlPlan.Name = "pnlPlan"
        '
        'cboPropPlanSplayPlanProjectionType
        '
        Me.cboPropPlanSplayPlanProjectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropPlanSplayPlanProjectionType, "cboPropPlanSplayPlanProjectionType")
        Me.cboPropPlanSplayPlanProjectionType.Items.AddRange(New Object() {resources.GetString("cboPropPlanSplayPlanProjectionType.Items"), resources.GetString("cboPropPlanSplayPlanProjectionType.Items1"), resources.GetString("cboPropPlanSplayPlanProjectionType.Items2")})
        Me.cboPropPlanSplayPlanProjectionType.Name = "cboPropPlanSplayPlanProjectionType"
        '
        'lblPropPlanSplayInclinationRange
        '
        Me.lblPropPlanSplayInclinationRange.Appearance.Font = CType(resources.GetObject("lblPropPlanSplayInclinationRange.Appearance.Font"), System.Drawing.Font)
        Me.lblPropPlanSplayInclinationRange.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropPlanSplayInclinationRange, "lblPropPlanSplayInclinationRange")
        Me.lblPropPlanSplayInclinationRange.Name = "lblPropPlanSplayInclinationRange"
        '
        'txtPropPlanSplayMaxVariationDelta
        '
        Me.txtPropPlanSplayMaxVariationDelta.DecimalPlaces = 1
        Me.txtPropPlanSplayMaxVariationDelta.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayMaxVariationDelta, "txtPropPlanSplayMaxVariationDelta")
        Me.txtPropPlanSplayMaxVariationDelta.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.txtPropPlanSplayMaxVariationDelta.Name = "txtPropPlanSplayMaxVariationDelta"
        '
        'txtPropPlanSplayInclinationRangeMax
        '
        Me.txtPropPlanSplayInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropPlanSplayInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayInclinationRangeMax, "txtPropPlanSplayInclinationRangeMax")
        Me.txtPropPlanSplayInclinationRangeMax.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropPlanSplayInclinationRangeMax.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropPlanSplayInclinationRangeMax.Name = "txtPropPlanSplayInclinationRangeMax"
        Me.txtPropPlanSplayInclinationRangeMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'txtPropPlanSplayPlanDeltaZ
        '
        Me.txtPropPlanSplayPlanDeltaZ.DecimalPlaces = 1
        Me.txtPropPlanSplayPlanDeltaZ.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayPlanDeltaZ, "txtPropPlanSplayPlanDeltaZ")
        Me.txtPropPlanSplayPlanDeltaZ.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPlanSplayPlanDeltaZ.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.txtPropPlanSplayPlanDeltaZ.Name = "txtPropPlanSplayPlanDeltaZ"
        '
        'txtPropPlanSplayInclinationRangeMin
        '
        Me.txtPropPlanSplayInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropPlanSplayInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayInclinationRangeMin, "txtPropPlanSplayInclinationRangeMin")
        Me.txtPropPlanSplayInclinationRangeMin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropPlanSplayInclinationRangeMin.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropPlanSplayInclinationRangeMin.Name = "txtPropPlanSplayInclinationRangeMin"
        Me.txtPropPlanSplayInclinationRangeMin.Value = New Decimal(New Integer() {90, 0, 0, -2147483648})
        '
        'lblPropPlanSplayPlanProjectionType
        '
        resources.ApplyResources(Me.lblPropPlanSplayPlanProjectionType, "lblPropPlanSplayPlanProjectionType")
        Me.lblPropPlanSplayPlanProjectionType.Name = "lblPropPlanSplayPlanProjectionType"
        '
        'lblPropPlanSplayMaxVariationDelta
        '
        resources.ApplyResources(Me.lblPropPlanSplayMaxVariationDelta, "lblPropPlanSplayMaxVariationDelta")
        Me.lblPropPlanSplayMaxVariationDelta.Name = "lblPropPlanSplayMaxVariationDelta"
        '
        'lblPropPlanSplayPlanDeltaZ
        '
        resources.ApplyResources(Me.lblPropPlanSplayPlanDeltaZ, "lblPropPlanSplayPlanDeltaZ")
        Me.lblPropPlanSplayPlanDeltaZ.Name = "lblPropPlanSplayPlanDeltaZ"
        '
        'pnlProfile
        '
        Me.pnlProfile.Controls.Add(Me.txtPropProfileSplayNegInclinationRangeMax)
        Me.pnlProfile.Controls.Add(Me.txtPropProfileSplayNegInclinationRangeMin)
        Me.pnlProfile.Controls.Add(Me.lblPropProfileSplayNegInclinationRange)
        Me.pnlProfile.Controls.Add(Me.txtPropProfileSplayPosInclinationRangeMax)
        Me.pnlProfile.Controls.Add(Me.txtPropProfileSplayPosInclinationRangeMin)
        Me.pnlProfile.Controls.Add(Me.lblPropProfileSplayPosInclinationRange)
        Me.pnlProfile.Controls.Add(Me.lblPropProfileSplayProjectionAngle)
        Me.pnlProfile.Controls.Add(Me.lblPropProfileSplayMaxVariationAngle)
        Me.pnlProfile.Controls.Add(Me.txtPropProfileSplayMaxVariationAngle)
        Me.pnlProfile.Controls.Add(Me.txtPropProfileSplayProjectionAngle)
        resources.ApplyResources(Me.pnlProfile, "pnlProfile")
        Me.pnlProfile.Name = "pnlProfile"
        '
        'txtPropProfileSplayNegInclinationRangeMax
        '
        Me.txtPropProfileSplayNegInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropProfileSplayNegInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayNegInclinationRangeMax, "txtPropProfileSplayNegInclinationRangeMax")
        Me.txtPropProfileSplayNegInclinationRangeMax.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPropProfileSplayNegInclinationRangeMax.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayNegInclinationRangeMax.Name = "txtPropProfileSplayNegInclinationRangeMax"
        '
        'txtPropProfileSplayNegInclinationRangeMin
        '
        Me.txtPropProfileSplayNegInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropProfileSplayNegInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayNegInclinationRangeMin, "txtPropProfileSplayNegInclinationRangeMin")
        Me.txtPropProfileSplayNegInclinationRangeMin.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPropProfileSplayNegInclinationRangeMin.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayNegInclinationRangeMin.Name = "txtPropProfileSplayNegInclinationRangeMin"
        Me.txtPropProfileSplayNegInclinationRangeMin.Value = New Decimal(New Integer() {90, 0, 0, -2147483648})
        '
        'lblPropProfileSplayNegInclinationRange
        '
        Me.lblPropProfileSplayNegInclinationRange.Appearance.Font = CType(resources.GetObject("lblPropProfileSplayNegInclinationRange.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileSplayNegInclinationRange.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileSplayNegInclinationRange, "lblPropProfileSplayNegInclinationRange")
        Me.lblPropProfileSplayNegInclinationRange.Name = "lblPropProfileSplayNegInclinationRange"
        '
        'txtPropProfileSplayPosInclinationRangeMax
        '
        Me.txtPropProfileSplayPosInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropProfileSplayPosInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayPosInclinationRangeMax, "txtPropProfileSplayPosInclinationRangeMax")
        Me.txtPropProfileSplayPosInclinationRangeMax.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayPosInclinationRangeMax.Name = "txtPropProfileSplayPosInclinationRangeMax"
        Me.txtPropProfileSplayPosInclinationRangeMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'txtPropProfileSplayPosInclinationRangeMin
        '
        Me.txtPropProfileSplayPosInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropProfileSplayPosInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayPosInclinationRangeMin, "txtPropProfileSplayPosInclinationRangeMin")
        Me.txtPropProfileSplayPosInclinationRangeMin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayPosInclinationRangeMin.Name = "txtPropProfileSplayPosInclinationRangeMin"
        '
        'lblPropProfileSplayPosInclinationRange
        '
        Me.lblPropProfileSplayPosInclinationRange.Appearance.Font = CType(resources.GetObject("lblPropProfileSplayPosInclinationRange.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileSplayPosInclinationRange.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileSplayPosInclinationRange, "lblPropProfileSplayPosInclinationRange")
        Me.lblPropProfileSplayPosInclinationRange.Name = "lblPropProfileSplayPosInclinationRange"
        '
        'lblPropProfileSplayProjectionAngle
        '
        resources.ApplyResources(Me.lblPropProfileSplayProjectionAngle, "lblPropProfileSplayProjectionAngle")
        Me.lblPropProfileSplayProjectionAngle.Name = "lblPropProfileSplayProjectionAngle"
        '
        'lblPropProfileSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.lblPropProfileSplayMaxVariationAngle, "lblPropProfileSplayMaxVariationAngle")
        Me.lblPropProfileSplayMaxVariationAngle.Name = "lblPropProfileSplayMaxVariationAngle"
        '
        'txtPropProfileSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.txtPropProfileSplayMaxVariationAngle, "txtPropProfileSplayMaxVariationAngle")
        Me.txtPropProfileSplayMaxVariationAngle.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.txtPropProfileSplayMaxVariationAngle.Name = "txtPropProfileSplayMaxVariationAngle"
        '
        'txtPropProfileSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropProfileSplayProjectionAngle, "txtPropProfileSplayProjectionAngle")
        Me.txtPropProfileSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayProjectionAngle.Name = "txtPropProfileSplayProjectionAngle"
        '
        'chkProfile
        '
        resources.ApplyResources(Me.chkProfile, "chkProfile")
        Me.chkProfile.Name = "chkProfile"
        Me.chkProfile.Properties.AutoWidth = True
        Me.chkProfile.Properties.Caption = resources.GetString("chkProfile.Properties.Caption")
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        '
        'tabMain
        '
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedTabPage = Me.tabPlan
        Me.tabMain.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabPlan, Me.tabProfile, Me.tabCrossSections})
        '
        'tabPlan
        '
        Me.tabPlan.Controls.Add(Me.chkPlan)
        Me.tabPlan.Controls.Add(Me.pnlPlan)
        Me.tabPlan.Name = "tabPlan"
        resources.ApplyResources(Me.tabPlan, "tabPlan")
        '
        'tabProfile
        '
        Me.tabProfile.Controls.Add(Me.pnlProfile)
        Me.tabProfile.Controls.Add(Me.chkProfile)
        Me.tabProfile.Name = "tabProfile"
        resources.ApplyResources(Me.tabProfile, "tabProfile")
        '
        'tabCrossSections
        '
        Me.tabCrossSections.Controls.Add(Me.chkCrossSection)
        Me.tabCrossSections.Controls.Add(Me.pnlCrosssection)
        Me.tabCrossSections.Name = "tabCrossSections"
        resources.ApplyResources(Me.tabCrossSections, "tabCrossSections")
        '
        'frmSplay
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.tabMain)
        Me.IconOptions.Icon = CType(resources.GetObject("frmSplay.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.replicatesplaydata
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplay"
        CType(Me.chkCrossSection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlCrosssection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCrosssection.ResumeLayout(False)
        Me.pnlCrosssection.PerformLayout()
        CType(Me.chkPropCrossSectionShowOnlyCutSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropCrossSectionShowSplayBorder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropCrossSectionSplayText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPlan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPlan.ResumeLayout(False)
        Me.pnlPlan.PerformLayout()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlProfile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabPlan.ResumeLayout(False)
        Me.tabPlan.PerformLayout()
        Me.tabProfile.ResumeLayout(False)
        Me.tabProfile.PerformLayout()
        Me.tabCrossSections.ResumeLayout(False)
        Me.tabCrossSections.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboPropPlanSplayPlanProjectionType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPropPlanSplayPlanDeltaZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropPlanSplayMaxVariationDelta As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropProfileSplayMaxVariationAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropProfileSplayProjectionAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropPlanSplayMaxVariationDelta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPlanSplayPlanDeltaZ As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropPlanSplayPlanProjectionType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPropCrossSectionSplayText As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtPropCrossSectionSplayMaxVariationAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboPropCrossSectionSplayLineStyle As System.Windows.Forms.ComboBox
    Friend WithEvents txtPropCrossSectionSplayProjectionAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkPropCrossSectionShowSplayBorder As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPropProfileSplayProjectionAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropProfileSplayMaxVariationAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionSplayProjectionAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionSplayMaxVariationAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionSplayLineStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropPlanSplayInclinationRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropPlanSplayInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropPlanSplayInclinationRangeMin As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropProfileSplayNegInclinationRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropProfileSplayPosInclinationRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPlan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlPlan As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlProfile As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkProfile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCrossSection As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlCrosssection As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPropCrossSectionShowOnlyCutSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tabMain As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabPlan As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabProfile As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents tabCrossSections As DevExpress.XtraTab.XtraTabPage
End Class
