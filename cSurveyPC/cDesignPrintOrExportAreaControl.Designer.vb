<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesignPrintOrExportAreaControl
    Inherits cDesignPropertyControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignPrintOrExportAreaControl))
        Me.pnlDesignPrintOrExportArea = New DevExpress.XtraEditors.PanelControl()
        Me.cboDesignPrintOrExportAreaProfile = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.cmdDesignBaseRule = New DevExpress.XtraEditors.SimpleButton()
        Me.lblDesignPrintOrExportAreaProfileDesignStyle = New DevExpress.XtraEditors.LabelControl()
        Me.cboDesignPrintOrExportAreaProfileDesignStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblDesignPrintOrExportAreaProfile = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignPrintOrExportArea = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.pnlDesignPrintOrExportArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDesignPrintOrExportArea.SuspendLayout()
        CType(Me.cboDesignPrintOrExportAreaProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPrintOrExportAreaProfileDesignStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPrintOrExportArea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDesignPrintOrExportArea
        '
        resources.ApplyResources(Me.pnlDesignPrintOrExportArea, "pnlDesignPrintOrExportArea")
        Me.pnlDesignPrintOrExportArea.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.cboDesignPrintOrExportAreaProfile)
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.cmdDesignBaseRule)
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.lblDesignPrintOrExportAreaProfileDesignStyle)
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.cboDesignPrintOrExportAreaProfileDesignStyle)
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.lblDesignPrintOrExportAreaProfile)
        Me.pnlDesignPrintOrExportArea.Name = "pnlDesignPrintOrExportArea"
        '
        'cboDesignPrintOrExportAreaProfile
        '
        resources.ApplyResources(Me.cboDesignPrintOrExportAreaProfile, "cboDesignPrintOrExportAreaProfile")
        Me.cboDesignPrintOrExportAreaProfile.Name = "cboDesignPrintOrExportAreaProfile"
        Me.cboDesignPrintOrExportAreaProfile.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPrintOrExportAreaProfile2.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPrintOrExportAreaProfile.Properties.SmallImages = Me.iml
        '
        'iml
        '
        Me.iml.Add("documentexport", "documentexport", GetType(cSurveyPC.My.Resources.Resources))
        Me.iml.Add("documentprint", "documentprint", GetType(cSurveyPC.My.Resources.Resources))
        '
        'cmdDesignBaseRule
        '
        resources.ApplyResources(Me.cmdDesignBaseRule, "cmdDesignBaseRule")
        Me.cmdDesignBaseRule.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdDesignBaseRule.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.profileview
        Me.cmdDesignBaseRule.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdDesignBaseRule.Name = "cmdDesignBaseRule"
        '
        'lblDesignPrintOrExportAreaProfileDesignStyle
        '
        resources.ApplyResources(Me.lblDesignPrintOrExportAreaProfileDesignStyle, "lblDesignPrintOrExportAreaProfileDesignStyle")
        Me.lblDesignPrintOrExportAreaProfileDesignStyle.Name = "lblDesignPrintOrExportAreaProfileDesignStyle"
        '
        'cboDesignPrintOrExportAreaProfileDesignStyle
        '
        resources.ApplyResources(Me.cboDesignPrintOrExportAreaProfileDesignStyle, "cboDesignPrintOrExportAreaProfileDesignStyle")
        Me.cboDesignPrintOrExportAreaProfileDesignStyle.Name = "cboDesignPrintOrExportAreaProfileDesignStyle"
        Me.cboDesignPrintOrExportAreaProfileDesignStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPrintOrExportAreaProfileDesignStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPrintOrExportAreaProfileDesignStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPrintOrExportAreaProfileDesignStyle.Properties.Items"), resources.GetString("cboDesignPrintOrExportAreaProfileDesignStyle.Properties.Items1")})
        Me.cboDesignPrintOrExportAreaProfileDesignStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblDesignPrintOrExportAreaProfile
        '
        resources.ApplyResources(Me.lblDesignPrintOrExportAreaProfile, "lblDesignPrintOrExportAreaProfile")
        Me.lblDesignPrintOrExportAreaProfile.Name = "lblDesignPrintOrExportAreaProfile"
        '
        'chkDesignPrintOrExportArea
        '
        resources.ApplyResources(Me.chkDesignPrintOrExportArea, "chkDesignPrintOrExportArea")
        Me.chkDesignPrintOrExportArea.Name = "chkDesignPrintOrExportArea"
        Me.chkDesignPrintOrExportArea.Properties.AutoWidth = True
        Me.chkDesignPrintOrExportArea.Properties.Caption = resources.GetString("chkDesignPrintOrExportArea.Properties.Caption")
        '
        'cDesignPrintOrExportAreaControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlDesignPrintOrExportArea)
        Me.Controls.Add(Me.chkDesignPrintOrExportArea)
        Me.Name = "cDesignPrintOrExportAreaControl"
        CType(Me.pnlDesignPrintOrExportArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDesignPrintOrExportArea.ResumeLayout(False)
        Me.pnlDesignPrintOrExportArea.PerformLayout()
        CType(Me.cboDesignPrintOrExportAreaProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPrintOrExportAreaProfileDesignStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPrintOrExportArea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlDesignPrintOrExportArea As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblDesignPrintOrExportAreaProfile As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkDesignPrintOrExportArea As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblDesignPrintOrExportAreaProfileDesignStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboDesignPrintOrExportAreaProfileDesignStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cmdDesignBaseRule As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboDesignPrintOrExportAreaProfile As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
End Class
