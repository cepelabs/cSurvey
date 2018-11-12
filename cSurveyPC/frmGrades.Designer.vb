<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrades
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGrades))
        Me.tbSessions = New System.Windows.Forms.ToolStrip()
        Me.btnAddSet = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteAll = New System.Windows.Forms.ToolStripButton()
        Me.tvGrades = New System.Windows.Forms.TreeView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.tabGrade = New System.Windows.Forms.TabControl()
        Me.tabGradeMain = New System.Windows.Forms.TabPage()
        Me.chkInclination = New System.Windows.Forms.CheckBox()
        Me.chkBearing = New System.Windows.Forms.CheckBox()
        Me.chkDistance = New System.Windows.Forms.CheckBox()
        Me.lblMeasureUnit = New System.Windows.Forms.Label()
        Me.txtInclination = New System.Windows.Forms.NumericUpDown()
        Me.txtBearing = New System.Windows.Forms.NumericUpDown()
        Me.txtDistance = New System.Windows.Forms.NumericUpDown()
        Me.lblValues = New System.Windows.Forms.Label()
        Me.cboInclinationType = New System.Windows.Forms.ComboBox()
        Me.cboBearingType = New System.Windows.Forms.ComboBox()
        Me.cboDistanceType = New System.Windows.Forms.ComboBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.tbSessions.SuspendLayout()
        Me.tabGrade.SuspendLayout()
        Me.tabGradeMain.SuspendLayout()
        CType(Me.txtInclination, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBearing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbSessions
        '
        resources.ApplyResources(Me.tbSessions, "tbSessions")
        Me.tbSessions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbSessions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddSet, Me.ToolStripSeparator2, Me.btnDelete, Me.btnDeleteAll})
        Me.tbSessions.Name = "tbSessions"
        '
        'btnAddSet
        '
        Me.btnAddSet.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnAddSet, "btnAddSet")
        Me.btnAddSet.Name = "btnAddSet"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnDelete
        '
        Me.btnDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnDeleteAll, "btnDeleteAll")
        Me.btnDeleteAll.Name = "btnDeleteAll"
        '
        'tvGrades
        '
        resources.ApplyResources(Me.tvGrades, "tvGrades")
        Me.tvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvGrades.HideSelection = False
        Me.tvGrades.ImageList = Me.iml
        Me.tvGrades.Name = "tvGrades"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "grade")
        Me.iml.Images.SetKeyName(1, "deleted")
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
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
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.Name = "txtDescription"
        '
        'lblDescription
        '
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'tabGrade
        '
        resources.ApplyResources(Me.tabGrade, "tabGrade")
        Me.tabGrade.Controls.Add(Me.tabGradeMain)
        Me.tabGrade.Name = "tabGrade"
        Me.tabGrade.SelectedIndex = 0
        '
        'tabGradeMain
        '
        Me.tabGradeMain.Controls.Add(Me.chkInclination)
        Me.tabGradeMain.Controls.Add(Me.chkBearing)
        Me.tabGradeMain.Controls.Add(Me.chkDistance)
        Me.tabGradeMain.Controls.Add(Me.lblMeasureUnit)
        Me.tabGradeMain.Controls.Add(Me.txtInclination)
        Me.tabGradeMain.Controls.Add(Me.txtBearing)
        Me.tabGradeMain.Controls.Add(Me.txtDistance)
        Me.tabGradeMain.Controls.Add(Me.lblValues)
        Me.tabGradeMain.Controls.Add(Me.cboInclinationType)
        Me.tabGradeMain.Controls.Add(Me.cboBearingType)
        Me.tabGradeMain.Controls.Add(Me.cboDistanceType)
        resources.ApplyResources(Me.tabGradeMain, "tabGradeMain")
        Me.tabGradeMain.Name = "tabGradeMain"
        Me.tabGradeMain.UseVisualStyleBackColor = True
        '
        'chkInclination
        '
        resources.ApplyResources(Me.chkInclination, "chkInclination")
        Me.chkInclination.Name = "chkInclination"
        Me.chkInclination.UseVisualStyleBackColor = True
        '
        'chkBearing
        '
        resources.ApplyResources(Me.chkBearing, "chkBearing")
        Me.chkBearing.Name = "chkBearing"
        Me.chkBearing.UseVisualStyleBackColor = True
        '
        'chkDistance
        '
        resources.ApplyResources(Me.chkDistance, "chkDistance")
        Me.chkDistance.Name = "chkDistance"
        Me.chkDistance.UseVisualStyleBackColor = True
        '
        'lblMeasureUnit
        '
        resources.ApplyResources(Me.lblMeasureUnit, "lblMeasureUnit")
        Me.lblMeasureUnit.Name = "lblMeasureUnit"
        '
        'txtInclination
        '
        Me.txtInclination.DecimalPlaces = 2
        resources.ApplyResources(Me.txtInclination, "txtInclination")
        Me.txtInclination.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtInclination.Name = "txtInclination"
        '
        'txtBearing
        '
        Me.txtBearing.DecimalPlaces = 2
        resources.ApplyResources(Me.txtBearing, "txtBearing")
        Me.txtBearing.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtBearing.Name = "txtBearing"
        '
        'txtDistance
        '
        Me.txtDistance.DecimalPlaces = 2
        resources.ApplyResources(Me.txtDistance, "txtDistance")
        Me.txtDistance.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtDistance.Name = "txtDistance"
        '
        'lblValues
        '
        resources.ApplyResources(Me.lblValues, "lblValues")
        Me.lblValues.Name = "lblValues"
        '
        'cboInclinationType
        '
        Me.cboInclinationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboInclinationType, "cboInclinationType")
        Me.cboInclinationType.Items.AddRange(New Object() {resources.GetString("cboInclinationType.Items"), resources.GetString("cboInclinationType.Items1")})
        Me.cboInclinationType.Name = "cboInclinationType"
        '
        'cboBearingType
        '
        Me.cboBearingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboBearingType, "cboBearingType")
        Me.cboBearingType.Items.AddRange(New Object() {resources.GetString("cboBearingType.Items"), resources.GetString("cboBearingType.Items1")})
        Me.cboBearingType.Name = "cboBearingType"
        '
        'cboDistanceType
        '
        Me.cboDistanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboDistanceType, "cboDistanceType")
        Me.cboDistanceType.Items.AddRange(New Object() {resources.GetString("cboDistanceType.Items"), resources.GetString("cboDistanceType.Items1"), resources.GetString("cboDistanceType.Items2")})
        Me.cboDistanceType.Name = "cboDistanceType"
        '
        'txtID
        '
        resources.ApplyResources(Me.txtID, "txtID")
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        '
        'lblID
        '
        resources.ApplyResources(Me.lblID, "lblID")
        Me.lblID.Name = "lblID"
        '
        'frmGrades
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.tabGrade)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.tbSessions)
        Me.Controls.Add(Me.tvGrades)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGrades"
        Me.tbSessions.ResumeLayout(False)
        Me.tbSessions.PerformLayout()
        Me.tabGrade.ResumeLayout(False)
        Me.tabGradeMain.ResumeLayout(False)
        Me.tabGradeMain.PerformLayout()
        CType(Me.txtInclination, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBearing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbSessions As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddSet As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents tvGrades As System.Windows.Forms.TreeView
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents tabGrade As System.Windows.Forms.TabControl
    Friend WithEvents tabGradeMain As System.Windows.Forms.TabPage
    Friend WithEvents cboInclinationType As System.Windows.Forms.ComboBox
    Friend WithEvents cboBearingType As System.Windows.Forms.ComboBox
    Friend WithEvents cboDistanceType As System.Windows.Forms.ComboBox
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblID As System.Windows.Forms.Label
    Friend WithEvents lblMeasureUnit As System.Windows.Forms.Label
    Friend WithEvents txtInclination As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtBearing As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblValues As System.Windows.Forms.Label
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents chkInclination As System.Windows.Forms.CheckBox
    Friend WithEvents chkBearing As System.Windows.Forms.CheckBox
    Friend WithEvents chkDistance As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteAll As System.Windows.Forms.ToolStripButton
End Class
