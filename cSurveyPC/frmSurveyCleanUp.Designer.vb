<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurveyCleanUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurveyCleanUp))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.chkDesignPointReduction = New System.Windows.Forms.CheckBox()
        Me.txtDesignPointReductionFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblPointReductionUM = New System.Windows.Forms.Label()
        Me.chkDesignPointsCleanUp = New System.Windows.Forms.CheckBox()
        Me.chkDesignCaveBranchCheck = New System.Windows.Forms.CheckBox()
        Me.chkDesignClipart = New System.Windows.Forms.CheckBox()
        Me.chkDesignSign = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDesignContext = New System.Windows.Forms.ComboBox()
        Me.lblCheckWarning = New System.Windows.Forms.Label()
        Me.picCheckWarning = New System.Windows.Forms.PictureBox()
        Me.chkPlotSegments = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkSplayFlagsAndNames = New System.Windows.Forms.CheckBox()
        Me.chkSplayNames = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkDesignRemoveInvalidItem = New System.Windows.Forms.CheckBox()
        Me.chkDesignConnectToCheck = New System.Windows.Forms.CheckBox()
        CType(Me.txtDesignPointReductionFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCheckWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        'lblDescription
        '
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'chkDesignPointReduction
        '
        resources.ApplyResources(Me.chkDesignPointReduction, "chkDesignPointReduction")
        Me.chkDesignPointReduction.Checked = True
        Me.chkDesignPointReduction.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignPointReduction.Name = "chkDesignPointReduction"
        Me.chkDesignPointReduction.UseVisualStyleBackColor = True
        '
        'txtDesignPointReductionFactor
        '
        Me.txtDesignPointReductionFactor.DecimalPlaces = 2
        resources.ApplyResources(Me.txtDesignPointReductionFactor, "txtDesignPointReductionFactor")
        Me.txtDesignPointReductionFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtDesignPointReductionFactor.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDesignPointReductionFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtDesignPointReductionFactor.Name = "txtDesignPointReductionFactor"
        Me.txtDesignPointReductionFactor.Value = New Decimal(New Integer() {2, 0, 0, 131072})
        '
        'lblPointReductionUM
        '
        resources.ApplyResources(Me.lblPointReductionUM, "lblPointReductionUM")
        Me.lblPointReductionUM.Name = "lblPointReductionUM"
        '
        'chkDesignPointsCleanUp
        '
        resources.ApplyResources(Me.chkDesignPointsCleanUp, "chkDesignPointsCleanUp")
        Me.chkDesignPointsCleanUp.Checked = True
        Me.chkDesignPointsCleanUp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignPointsCleanUp.Name = "chkDesignPointsCleanUp"
        Me.chkDesignPointsCleanUp.UseVisualStyleBackColor = True
        '
        'chkDesignCaveBranchCheck
        '
        resources.ApplyResources(Me.chkDesignCaveBranchCheck, "chkDesignCaveBranchCheck")
        Me.chkDesignCaveBranchCheck.Checked = True
        Me.chkDesignCaveBranchCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignCaveBranchCheck.Name = "chkDesignCaveBranchCheck"
        Me.chkDesignCaveBranchCheck.UseVisualStyleBackColor = True
        '
        'chkDesignClipart
        '
        resources.ApplyResources(Me.chkDesignClipart, "chkDesignClipart")
        Me.chkDesignClipart.Checked = True
        Me.chkDesignClipart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignClipart.Name = "chkDesignClipart"
        Me.chkDesignClipart.UseVisualStyleBackColor = True
        '
        'chkDesignSign
        '
        resources.ApplyResources(Me.chkDesignSign, "chkDesignSign")
        Me.chkDesignSign.Checked = True
        Me.chkDesignSign.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignSign.Name = "chkDesignSign"
        Me.chkDesignSign.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboDesignContext
        '
        Me.cboDesignContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignContext.FormattingEnabled = True
        Me.cboDesignContext.Items.AddRange(New Object() {resources.GetString("cboDesignContext.Items"), resources.GetString("cboDesignContext.Items1"), resources.GetString("cboDesignContext.Items2")})
        resources.ApplyResources(Me.cboDesignContext, "cboDesignContext")
        Me.cboDesignContext.Name = "cboDesignContext"
        '
        'lblCheckWarning
        '
        resources.ApplyResources(Me.lblCheckWarning, "lblCheckWarning")
        Me.lblCheckWarning.Name = "lblCheckWarning"
        '
        'picCheckWarning
        '
        resources.ApplyResources(Me.picCheckWarning, "picCheckWarning")
        Me.picCheckWarning.Image = Global.cSurveyPC.My.Resources.Resources.error3
        Me.picCheckWarning.Name = "picCheckWarning"
        Me.picCheckWarning.TabStop = False
        '
        'chkPlotSegments
        '
        resources.ApplyResources(Me.chkPlotSegments, "chkPlotSegments")
        Me.chkPlotSegments.Checked = True
        Me.chkPlotSegments.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPlotSegments.Name = "chkPlotSegments"
        Me.chkPlotSegments.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSplayFlagsAndNames)
        Me.GroupBox1.Controls.Add(Me.chkSplayNames)
        Me.GroupBox1.Controls.Add(Me.chkPlotSegments)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'chkSplayFlagsAndNames
        '
        resources.ApplyResources(Me.chkSplayFlagsAndNames, "chkSplayFlagsAndNames")
        Me.chkSplayFlagsAndNames.Checked = True
        Me.chkSplayFlagsAndNames.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSplayFlagsAndNames.Name = "chkSplayFlagsAndNames"
        Me.chkSplayFlagsAndNames.UseVisualStyleBackColor = True
        '
        'chkSplayNames
        '
        resources.ApplyResources(Me.chkSplayNames, "chkSplayNames")
        Me.chkSplayNames.Checked = True
        Me.chkSplayNames.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSplayNames.Name = "chkSplayNames"
        Me.chkSplayNames.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDesignRemoveInvalidItem)
        Me.GroupBox2.Controls.Add(Me.chkDesignConnectToCheck)
        Me.GroupBox2.Controls.Add(Me.chkDesignCaveBranchCheck)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkDesignPointReduction)
        Me.GroupBox2.Controls.Add(Me.txtDesignPointReductionFactor)
        Me.GroupBox2.Controls.Add(Me.lblPointReductionUM)
        Me.GroupBox2.Controls.Add(Me.chkDesignSign)
        Me.GroupBox2.Controls.Add(Me.chkDesignPointsCleanUp)
        Me.GroupBox2.Controls.Add(Me.chkDesignClipart)
        Me.GroupBox2.Controls.Add(Me.cboDesignContext)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'chkDesignRemoveInvalidItem
        '
        resources.ApplyResources(Me.chkDesignRemoveInvalidItem, "chkDesignRemoveInvalidItem")
        Me.chkDesignRemoveInvalidItem.Checked = True
        Me.chkDesignRemoveInvalidItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignRemoveInvalidItem.Name = "chkDesignRemoveInvalidItem"
        Me.chkDesignRemoveInvalidItem.UseVisualStyleBackColor = True
        '
        'chkDesignConnectToCheck
        '
        resources.ApplyResources(Me.chkDesignConnectToCheck, "chkDesignConnectToCheck")
        Me.chkDesignConnectToCheck.Checked = True
        Me.chkDesignConnectToCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDesignConnectToCheck.Name = "chkDesignConnectToCheck"
        Me.chkDesignConnectToCheck.UseVisualStyleBackColor = True
        '
        'frmSurveyCleanUp
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCheckWarning)
        Me.Controls.Add(Me.picCheckWarning)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurveyCleanUp"
        CType(Me.txtDesignPointReductionFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCheckWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents chkDesignPointReduction As System.Windows.Forms.CheckBox
    Friend WithEvents txtDesignPointReductionFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPointReductionUM As System.Windows.Forms.Label
    Friend WithEvents chkDesignPointsCleanUp As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignCaveBranchCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignClipart As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignSign As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDesignContext As System.Windows.Forms.ComboBox
    Friend WithEvents lblCheckWarning As System.Windows.Forms.Label
    Friend WithEvents picCheckWarning As System.Windows.Forms.PictureBox
    Friend WithEvents chkPlotSegments As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDesignConnectToCheck As System.Windows.Forms.CheckBox
    Friend WithEvents chkSplayNames As CheckBox
    Friend WithEvents chkSplayFlagsAndNames As CheckBox
    Friend WithEvents chkDesignRemoveInvalidItem As CheckBox
End Class
