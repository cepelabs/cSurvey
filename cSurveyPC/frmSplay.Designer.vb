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
        Me.TabMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.chkPlan = New System.Windows.Forms.CheckBox()
        Me.pnlPlan = New System.Windows.Forms.Panel()
        Me.cboPropPlanSplayPlanProjectionType = New System.Windows.Forms.ComboBox()
        Me.lblPropPlanSplayInclinationRange = New System.Windows.Forms.Label()
        Me.txtPropPlanSplayMaxVariationDelta = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayPlanDeltaZ = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropPlanSplayPlanProjectionType = New System.Windows.Forms.Label()
        Me.lblPropPlanSplayMaxVariationDelta = New System.Windows.Forms.Label()
        Me.lblPropPlanSplayPlanDeltaZ = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.pnlProfile = New System.Windows.Forms.Panel()
        Me.txtPropProfileSplayNegInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayNegInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayNegInclinationRange = New System.Windows.Forms.Label()
        Me.txtPropProfileSplayPosInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayPosInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayPosInclinationRange = New System.Windows.Forms.Label()
        Me.lblPropProfileSplayProjectionAngle = New System.Windows.Forms.Label()
        Me.lblPropProfileSplayMaxVariationAngle = New System.Windows.Forms.Label()
        Me.txtPropProfileSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkProfile = New System.Windows.Forms.CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkCrossSection = New System.Windows.Forms.CheckBox()
        Me.pnlCrosssection = New System.Windows.Forms.Panel()
        Me.chkPropCrossSectionShowOnlyCutSplay = New System.Windows.Forms.CheckBox()
        Me.lblPropCrossSectionSplayProjectionAngle = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionSplayText = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionShowSplayBorder = New System.Windows.Forms.Label()
        Me.chkPropCrossSectionShowSplayBorder = New System.Windows.Forms.CheckBox()
        Me.lblPropCrossSectionSplayLineStyle = New System.Windows.Forms.Label()
        Me.cboPropCrossSectionSplayLineStyle = New System.Windows.Forms.ComboBox()
        Me.lblPropCrossSectionSplayMaxVariationAngle = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkPropCrossSectionSplayText = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.TabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlPlan.SuspendLayout()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.pnlProfile.SuspendLayout()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.pnlCrosssection.SuspendLayout()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabMain
        '
        resources.ApplyResources(Me.TabMain, "TabMain")
        Me.TabMain.Controls.Add(Me.TabPage1)
        Me.TabMain.Controls.Add(Me.TabPage2)
        Me.TabMain.Controls.Add(Me.TabPage3)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkPlan)
        Me.TabPage1.Controls.Add(Me.pnlPlan)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkPlan
        '
        resources.ApplyResources(Me.chkPlan, "chkPlan")
        Me.chkPlan.Name = "chkPlan"
        Me.chkPlan.UseVisualStyleBackColor = True
        '
        'pnlPlan
        '
        resources.ApplyResources(Me.pnlPlan, "pnlPlan")
        Me.pnlPlan.Controls.Add(Me.cboPropPlanSplayPlanProjectionType)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayInclinationRange)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayMaxVariationDelta)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayInclinationRangeMax)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayPlanDeltaZ)
        Me.pnlPlan.Controls.Add(Me.txtPropPlanSplayInclinationRangeMin)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayPlanProjectionType)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayMaxVariationDelta)
        Me.pnlPlan.Controls.Add(Me.lblPropPlanSplayPlanDeltaZ)
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
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.pnlProfile)
        Me.TabPage2.Controls.Add(Me.chkProfile)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'pnlProfile
        '
        resources.ApplyResources(Me.pnlProfile, "pnlProfile")
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
        Me.chkProfile.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chkCrossSection)
        Me.TabPage3.Controls.Add(Me.pnlCrosssection)
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chkCrossSection
        '
        resources.ApplyResources(Me.chkCrossSection, "chkCrossSection")
        Me.chkCrossSection.Name = "chkCrossSection"
        Me.chkCrossSection.UseVisualStyleBackColor = True
        '
        'pnlCrosssection
        '
        Me.pnlCrosssection.Controls.Add(Me.chkPropCrossSectionShowOnlyCutSplay)
        Me.pnlCrosssection.Controls.Add(Me.lblPropCrossSectionSplayProjectionAngle)
        Me.pnlCrosssection.Controls.Add(Me.lblPropCrossSectionSplayText)
        Me.pnlCrosssection.Controls.Add(Me.txtPropCrossSectionSplayProjectionAngle)
        Me.pnlCrosssection.Controls.Add(Me.lblPropCrossSectionShowSplayBorder)
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
        Me.chkPropCrossSectionShowOnlyCutSplay.UseVisualStyleBackColor = True
        '
        'lblPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayProjectionAngle, "lblPropCrossSectionSplayProjectionAngle")
        Me.lblPropCrossSectionSplayProjectionAngle.Name = "lblPropCrossSectionSplayProjectionAngle"
        '
        'lblPropCrossSectionSplayText
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayText, "lblPropCrossSectionSplayText")
        Me.lblPropCrossSectionSplayText.Name = "lblPropCrossSectionSplayText"
        '
        'txtPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayProjectionAngle, "txtPropCrossSectionSplayProjectionAngle")
        Me.txtPropCrossSectionSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionSplayProjectionAngle.Name = "txtPropCrossSectionSplayProjectionAngle"
        '
        'lblPropCrossSectionShowSplayBorder
        '
        resources.ApplyResources(Me.lblPropCrossSectionShowSplayBorder, "lblPropCrossSectionShowSplayBorder")
        Me.lblPropCrossSectionShowSplayBorder.Name = "lblPropCrossSectionShowSplayBorder"
        '
        'chkPropCrossSectionShowSplayBorder
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowSplayBorder, "chkPropCrossSectionShowSplayBorder")
        Me.chkPropCrossSectionShowSplayBorder.Name = "chkPropCrossSectionShowSplayBorder"
        Me.chkPropCrossSectionShowSplayBorder.UseVisualStyleBackColor = True
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
        Me.chkPropCrossSectionSplayText.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'frmSplay
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.TabMain)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplay"
        Me.TabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.pnlPlan.ResumeLayout(False)
        Me.pnlPlan.PerformLayout()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.pnlProfile.ResumeLayout(False)
        Me.pnlProfile.PerformLayout()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.pnlCrosssection.ResumeLayout(False)
        Me.pnlCrosssection.PerformLayout()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents cboPropPlanSplayPlanProjectionType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPropPlanSplayPlanDeltaZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropPlanSplayMaxVariationDelta As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropProfileSplayMaxVariationAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropProfileSplayProjectionAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropPlanSplayMaxVariationDelta As System.Windows.Forms.Label
    Friend WithEvents lblPropPlanSplayPlanDeltaZ As System.Windows.Forms.Label
    Friend WithEvents lblPropPlanSplayPlanProjectionType As System.Windows.Forms.Label
    Friend WithEvents chkPropCrossSectionSplayText As System.Windows.Forms.CheckBox
    Friend WithEvents txtPropCrossSectionSplayMaxVariationAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboPropCrossSectionSplayLineStyle As System.Windows.Forms.ComboBox
    Friend WithEvents txtPropCrossSectionSplayProjectionAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkPropCrossSectionShowSplayBorder As System.Windows.Forms.CheckBox
    Friend WithEvents lblPropProfileSplayProjectionAngle As System.Windows.Forms.Label
    Friend WithEvents lblPropProfileSplayMaxVariationAngle As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionSplayProjectionAngle As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionSplayMaxVariationAngle As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionSplayLineStyle As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionSplayText As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionShowSplayBorder As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblPropPlanSplayInclinationRange As Label
    Friend WithEvents txtPropPlanSplayInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropPlanSplayInclinationRangeMin As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropProfileSplayNegInclinationRange As Label
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropProfileSplayPosInclinationRange As Label
    Friend WithEvents chkPlan As CheckBox
    Friend WithEvents pnlPlan As Panel
    Friend WithEvents pnlProfile As Panel
    Friend WithEvents chkProfile As CheckBox
    Friend WithEvents chkCrossSection As CheckBox
    Friend WithEvents pnlCrosssection As Panel
    Friend WithEvents cmdApply As Button
    Friend WithEvents chkPropCrossSectionShowOnlyCutSplay As CheckBox
End Class
