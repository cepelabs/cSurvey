<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDistancesFilter
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDistancesFilter))
        Me.pnlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlLinkedSurveys = New DevExpress.XtraEditors.PanelControl()
        Me.lblSurveyInfoFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cboSurveyInfoFilename = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tmsFilters = New cSurveyPC.cTrigpointsMultiselector()
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        CType(Me.pnlLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLinkedSurveys.SuspendLayout()
        CType(Me.cboSurveyInfoFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBottom.Controls.Add(Me.cmdCancel)
        Me.pnlBottom.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.pnlBottom, "pnlBottom")
        Me.pnlBottom.Name = "pnlBottom"
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
        'pnlLinkedSurveys
        '
        Me.pnlLinkedSurveys.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlLinkedSurveys.Controls.Add(Me.lblSurveyInfoFilename)
        Me.pnlLinkedSurveys.Controls.Add(Me.cboSurveyInfoFilename)
        resources.ApplyResources(Me.pnlLinkedSurveys, "pnlLinkedSurveys")
        Me.pnlLinkedSurveys.Name = "pnlLinkedSurveys"
        '
        'lblSurveyInfoFilename
        '
        resources.ApplyResources(Me.lblSurveyInfoFilename, "lblSurveyInfoFilename")
        Me.lblSurveyInfoFilename.Name = "lblSurveyInfoFilename"
        '
        'cboSurveyInfoFilename
        '
        resources.ApplyResources(Me.cboSurveyInfoFilename, "cboSurveyInfoFilename")
        Me.cboSurveyInfoFilename.Name = "cboSurveyInfoFilename"
        Me.cboSurveyInfoFilename.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboSurveyInfoFilename.Properties.Appearance.Font = CType(resources.GetObject("cboSurveyInfoFilename.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboSurveyInfoFilename.Properties.Appearance.Options.UseFont = True
        Me.cboSurveyInfoFilename.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSurveyInfoFilename.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSurveyInfoFilename.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'tmsFilters
        '
        resources.ApplyResources(Me.tmsFilters, "tmsFilters")
        Me.tmsFilters.Name = "tmsFilters"
        '
        'frmDistancesFilter
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.tmsFilters)
        Me.Controls.Add(Me.pnlLinkedSurveys)
        Me.Controls.Add(Me.pnlBottom)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.distance_filter
        Me.MinimizeBox = False
        Me.Name = "frmDistancesFilter"
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.pnlLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLinkedSurveys.ResumeLayout(False)
        Me.pnlLinkedSurveys.PerformLayout()
        CType(Me.cboSurveyInfoFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tmsFilters As cTrigpointsMultiselector
    Friend WithEvents pnlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlLinkedSurveys As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblSurveyInfoFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSurveyInfoFilename As DevExpress.XtraEditors.ComboBoxEdit
End Class
