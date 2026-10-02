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
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDescription = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignPointReduction = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPointReductionUM = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignPointsCleanUp = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignCaveBranchCheck = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignClipart = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignSign = New DevExpress.XtraEditors.CheckEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblCheckWarning = New DevExpress.XtraEditors.LabelControl()
        Me.chkPlotSegments = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox1 = New DevExpress.XtraEditors.GroupControl()
        Me.chkSplayFlagsAndNames = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSplayNames = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupBox2 = New DevExpress.XtraEditors.GroupControl()
        Me.cboDesignContext = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtDesignPointReductionFactor = New DevExpress.XtraEditors.SpinEdit()
        Me.chkDesignRemoveInvalidItem = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignConnectToCheck = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkDesignPointReduction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPointsCleanUp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignCaveBranchCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignClipart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignSign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPlotSegments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.chkSplayFlagsAndNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSplayNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cboDesignContext.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignPointReductionFactor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignRemoveInvalidItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignConnectToCheck.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'lblDescription
        '
        Me.lblDescription.Appearance.Options.UseTextOptions = True
        Me.lblDescription.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'chkDesignPointReduction
        '
        resources.ApplyResources(Me.chkDesignPointReduction, "chkDesignPointReduction")
        Me.chkDesignPointReduction.Name = "chkDesignPointReduction"
        Me.chkDesignPointReduction.Properties.AutoWidth = True
        Me.chkDesignPointReduction.Properties.Caption = resources.GetString("chkDesignPointReduction.Properties.Caption")
        '
        'lblPointReductionUM
        '
        resources.ApplyResources(Me.lblPointReductionUM, "lblPointReductionUM")
        Me.lblPointReductionUM.Name = "lblPointReductionUM"
        '
        'chkDesignPointsCleanUp
        '
        resources.ApplyResources(Me.chkDesignPointsCleanUp, "chkDesignPointsCleanUp")
        Me.chkDesignPointsCleanUp.Name = "chkDesignPointsCleanUp"
        Me.chkDesignPointsCleanUp.Properties.AutoWidth = True
        Me.chkDesignPointsCleanUp.Properties.Caption = resources.GetString("chkDesignPointsCleanUp.Properties.Caption")
        '
        'chkDesignCaveBranchCheck
        '
        resources.ApplyResources(Me.chkDesignCaveBranchCheck, "chkDesignCaveBranchCheck")
        Me.chkDesignCaveBranchCheck.Name = "chkDesignCaveBranchCheck"
        Me.chkDesignCaveBranchCheck.Properties.AutoWidth = True
        Me.chkDesignCaveBranchCheck.Properties.Caption = resources.GetString("chkDesignCaveBranchCheck.Properties.Caption")
        '
        'chkDesignClipart
        '
        resources.ApplyResources(Me.chkDesignClipart, "chkDesignClipart")
        Me.chkDesignClipart.Name = "chkDesignClipart"
        Me.chkDesignClipart.Properties.AutoWidth = True
        Me.chkDesignClipart.Properties.Caption = resources.GetString("chkDesignClipart.Properties.Caption")
        '
        'chkDesignSign
        '
        resources.ApplyResources(Me.chkDesignSign, "chkDesignSign")
        Me.chkDesignSign.Name = "chkDesignSign"
        Me.chkDesignSign.Properties.AutoWidth = True
        Me.chkDesignSign.Properties.Caption = resources.GetString("chkDesignSign.Properties.Caption")
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblCheckWarning
        '
        Me.lblCheckWarning.AllowHtmlString = True
        resources.ApplyResources(Me.lblCheckWarning, "lblCheckWarning")
        Me.lblCheckWarning.Name = "lblCheckWarning"
        '
        'chkPlotSegments
        '
        resources.ApplyResources(Me.chkPlotSegments, "chkPlotSegments")
        Me.chkPlotSegments.Name = "chkPlotSegments"
        Me.chkPlotSegments.Properties.AutoWidth = True
        Me.chkPlotSegments.Properties.Caption = resources.GetString("chkPlotSegments.Properties.Caption")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSplayFlagsAndNames)
        Me.GroupBox1.Controls.Add(Me.chkSplayNames)
        Me.GroupBox1.Controls.Add(Me.chkPlotSegments)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        '
        'chkSplayFlagsAndNames
        '
        resources.ApplyResources(Me.chkSplayFlagsAndNames, "chkSplayFlagsAndNames")
        Me.chkSplayFlagsAndNames.Name = "chkSplayFlagsAndNames"
        Me.chkSplayFlagsAndNames.Properties.AutoWidth = True
        Me.chkSplayFlagsAndNames.Properties.Caption = resources.GetString("chkSplayFlagsAndNames.Properties.Caption")
        '
        'chkSplayNames
        '
        resources.ApplyResources(Me.chkSplayNames, "chkSplayNames")
        Me.chkSplayNames.Name = "chkSplayNames"
        Me.chkSplayNames.Properties.AutoWidth = True
        Me.chkSplayNames.Properties.Caption = resources.GetString("chkSplayNames.Properties.Caption")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboDesignContext)
        Me.GroupBox2.Controls.Add(Me.txtDesignPointReductionFactor)
        Me.GroupBox2.Controls.Add(Me.chkDesignRemoveInvalidItem)
        Me.GroupBox2.Controls.Add(Me.chkDesignConnectToCheck)
        Me.GroupBox2.Controls.Add(Me.chkDesignCaveBranchCheck)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkDesignPointReduction)
        Me.GroupBox2.Controls.Add(Me.lblPointReductionUM)
        Me.GroupBox2.Controls.Add(Me.chkDesignSign)
        Me.GroupBox2.Controls.Add(Me.chkDesignPointsCleanUp)
        Me.GroupBox2.Controls.Add(Me.chkDesignClipart)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        '
        'cboDesignContext
        '
        resources.ApplyResources(Me.cboDesignContext, "cboDesignContext")
        Me.cboDesignContext.Name = "cboDesignContext"
        Me.cboDesignContext.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignContext.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignContext.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignContext.Properties.Items"), resources.GetString("cboDesignContext.Properties.Items1"), resources.GetString("cboDesignContext.Properties.Items2")})
        Me.cboDesignContext.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'txtDesignPointReductionFactor
        '
        resources.ApplyResources(Me.txtDesignPointReductionFactor, "txtDesignPointReductionFactor")
        Me.txtDesignPointReductionFactor.Name = "txtDesignPointReductionFactor"
        Me.txtDesignPointReductionFactor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtDesignPointReductionFactor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtDesignPointReductionFactor.Properties.DisplayFormat.FormatString = "N2"
        Me.txtDesignPointReductionFactor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDesignPointReductionFactor.Properties.EditFormat.FormatString = "N2"
        Me.txtDesignPointReductionFactor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtDesignPointReductionFactor.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtDesignPointReductionFactor.Properties.MaxValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDesignPointReductionFactor.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'chkDesignRemoveInvalidItem
        '
        resources.ApplyResources(Me.chkDesignRemoveInvalidItem, "chkDesignRemoveInvalidItem")
        Me.chkDesignRemoveInvalidItem.Name = "chkDesignRemoveInvalidItem"
        Me.chkDesignRemoveInvalidItem.Properties.AutoWidth = True
        Me.chkDesignRemoveInvalidItem.Properties.Caption = resources.GetString("chkDesignRemoveInvalidItem.Properties.Caption")
        '
        'chkDesignConnectToCheck
        '
        resources.ApplyResources(Me.chkDesignConnectToCheck, "chkDesignConnectToCheck")
        Me.chkDesignConnectToCheck.Name = "chkDesignConnectToCheck"
        Me.chkDesignConnectToCheck.Properties.AutoWidth = True
        Me.chkDesignConnectToCheck.Properties.Caption = resources.GetString("chkDesignConnectToCheck.Properties.Caption")
        '
        'frmSurveyCleanUp
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCheckWarning)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.swissknife
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurveyCleanUp"
        CType(Me.chkDesignPointReduction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPointsCleanUp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignCaveBranchCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignClipart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignSign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPlotSegments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.chkSplayFlagsAndNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSplayNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cboDesignContext.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignPointReductionFactor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignRemoveInvalidItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignConnectToCheck.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblDescription As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkDesignPointReduction As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPointReductionUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkDesignPointsCleanUp As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignCaveBranchCheck As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignClipart As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignSign As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCheckWarning As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPlotSegments As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupBox1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupBox2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkDesignConnectToCheck As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSplayNames As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSplayFlagsAndNames As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignRemoveInvalidItem As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtDesignPointReductionFactor As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents cboDesignContext As DevExpress.XtraEditors.ComboBoxEdit
End Class
