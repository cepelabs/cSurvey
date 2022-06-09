<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemQuotaPropertyControl
    Inherits cItemPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemQuotaPropertyControl))
        Me.cboPropQuotaFormat = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaFormat = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropQuotaTextPosition = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropQuotaTextPosition = New System.Windows.Forms.ComboBox()
        Me.cmdPropQuotaOtherOptions = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropQuotaRelativeTrigpoint = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropQuotaType = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaType = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropQuotaValueType = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaValueType = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropQuotaValue = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaValue = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropQuotaAlign = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaAlign = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropQuotaRelativeTrigpoint = New DevExpress.XtraEditors.ButtonEdit()
        Me.flyParameters = New DevExpress.Utils.FlyoutPanel()
        Me.pnlParameters = New DevExpress.Utils.FlyoutPanelControl()
        CType(Me.txtPropQuotaRelativeTrigpoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyParameters.SuspendLayout()
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPropQuotaFormat
        '
        Me.cboPropQuotaFormat.FormattingEnabled = True
        Me.cboPropQuotaFormat.Items.AddRange(New Object() {resources.GetString("cboPropQuotaFormat.Items"), resources.GetString("cboPropQuotaFormat.Items1"), resources.GetString("cboPropQuotaFormat.Items2"), resources.GetString("cboPropQuotaFormat.Items3")})
        resources.ApplyResources(Me.cboPropQuotaFormat, "cboPropQuotaFormat")
        Me.cboPropQuotaFormat.Name = "cboPropQuotaFormat"
        '
        'lblPropQuotaFormat
        '
        resources.ApplyResources(Me.lblPropQuotaFormat, "lblPropQuotaFormat")
        Me.lblPropQuotaFormat.Name = "lblPropQuotaFormat"
        '
        'lblPropQuotaTextPosition
        '
        resources.ApplyResources(Me.lblPropQuotaTextPosition, "lblPropQuotaTextPosition")
        Me.lblPropQuotaTextPosition.Name = "lblPropQuotaTextPosition"
        '
        'cboPropQuotaTextPosition
        '
        Me.cboPropQuotaTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaTextPosition.FormattingEnabled = True
        Me.cboPropQuotaTextPosition.Items.AddRange(New Object() {resources.GetString("cboPropQuotaTextPosition.Items"), resources.GetString("cboPropQuotaTextPosition.Items1")})
        resources.ApplyResources(Me.cboPropQuotaTextPosition, "cboPropQuotaTextPosition")
        Me.cboPropQuotaTextPosition.Name = "cboPropQuotaTextPosition"
        '
        'cmdPropQuotaOtherOptions
        '
        resources.ApplyResources(Me.cmdPropQuotaOtherOptions, "cmdPropQuotaOtherOptions")
        Me.cmdPropQuotaOtherOptions.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropQuotaOtherOptions.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.quota
        Me.cmdPropQuotaOtherOptions.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropQuotaOtherOptions.Name = "cmdPropQuotaOtherOptions"
        '
        'lblPropQuotaRelativeTrigpoint
        '
        resources.ApplyResources(Me.lblPropQuotaRelativeTrigpoint, "lblPropQuotaRelativeTrigpoint")
        Me.lblPropQuotaRelativeTrigpoint.Name = "lblPropQuotaRelativeTrigpoint"
        '
        'cboPropQuotaType
        '
        Me.cboPropQuotaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaType.FormattingEnabled = True
        Me.cboPropQuotaType.Items.AddRange(New Object() {resources.GetString("cboPropQuotaType.Items"), resources.GetString("cboPropQuotaType.Items1"), resources.GetString("cboPropQuotaType.Items2"), resources.GetString("cboPropQuotaType.Items3"), resources.GetString("cboPropQuotaType.Items4"), resources.GetString("cboPropQuotaType.Items5"), resources.GetString("cboPropQuotaType.Items6"), resources.GetString("cboPropQuotaType.Items7")})
        resources.ApplyResources(Me.cboPropQuotaType, "cboPropQuotaType")
        Me.cboPropQuotaType.Name = "cboPropQuotaType"
        '
        'lblPropQuotaType
        '
        resources.ApplyResources(Me.lblPropQuotaType, "lblPropQuotaType")
        Me.lblPropQuotaType.Name = "lblPropQuotaType"
        '
        'cboPropQuotaValueType
        '
        Me.cboPropQuotaValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaValueType.FormattingEnabled = True
        Me.cboPropQuotaValueType.Items.AddRange(New Object() {resources.GetString("cboPropQuotaValueType.Items"), resources.GetString("cboPropQuotaValueType.Items1"), resources.GetString("cboPropQuotaValueType.Items2"), resources.GetString("cboPropQuotaValueType.Items3")})
        resources.ApplyResources(Me.cboPropQuotaValueType, "cboPropQuotaValueType")
        Me.cboPropQuotaValueType.Name = "cboPropQuotaValueType"
        '
        'lblPropQuotaValueType
        '
        resources.ApplyResources(Me.lblPropQuotaValueType, "lblPropQuotaValueType")
        Me.lblPropQuotaValueType.Name = "lblPropQuotaValueType"
        '
        'cboPropQuotaValue
        '
        Me.cboPropQuotaValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaValue.FormattingEnabled = True
        Me.cboPropQuotaValue.Items.AddRange(New Object() {resources.GetString("cboPropQuotaValue.Items"), resources.GetString("cboPropQuotaValue.Items1")})
        resources.ApplyResources(Me.cboPropQuotaValue, "cboPropQuotaValue")
        Me.cboPropQuotaValue.Name = "cboPropQuotaValue"
        '
        'lblPropQuotaValue
        '
        resources.ApplyResources(Me.lblPropQuotaValue, "lblPropQuotaValue")
        Me.lblPropQuotaValue.Name = "lblPropQuotaValue"
        '
        'cboPropQuotaAlign
        '
        Me.cboPropQuotaAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaAlign.FormattingEnabled = True
        Me.cboPropQuotaAlign.Items.AddRange(New Object() {resources.GetString("cboPropQuotaAlign.Items"), resources.GetString("cboPropQuotaAlign.Items1"), resources.GetString("cboPropQuotaAlign.Items2")})
        resources.ApplyResources(Me.cboPropQuotaAlign, "cboPropQuotaAlign")
        Me.cboPropQuotaAlign.Name = "cboPropQuotaAlign"
        '
        'lblPropQuotaAlign
        '
        resources.ApplyResources(Me.lblPropQuotaAlign, "lblPropQuotaAlign")
        Me.lblPropQuotaAlign.Name = "lblPropQuotaAlign"
        '
        'txtPropQuotaRelativeTrigpoint
        '
        resources.ApplyResources(Me.txtPropQuotaRelativeTrigpoint, "txtPropQuotaRelativeTrigpoint")
        Me.txtPropQuotaRelativeTrigpoint.Name = "txtPropQuotaRelativeTrigpoint"
        Me.txtPropQuotaRelativeTrigpoint.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtPropQuotaRelativeTrigpoint.Properties.ReadOnly = True
        Me.txtPropQuotaRelativeTrigpoint.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'flyParameters
        '
        Me.flyParameters.Controls.Add(Me.pnlParameters)
        resources.ApplyResources(Me.flyParameters, "flyParameters")
        Me.flyParameters.Name = "flyParameters"
        '
        'pnlParameters
        '
        Me.pnlParameters.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.pnlParameters, "pnlParameters")
        Me.pnlParameters.FlyoutPanel = Me.flyParameters
        Me.pnlParameters.Name = "pnlParameters"
        '
        'cItemQuotaPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.flyParameters)
        Me.Controls.Add(Me.cboPropQuotaFormat)
        Me.Controls.Add(Me.lblPropQuotaFormat)
        Me.Controls.Add(Me.lblPropQuotaTextPosition)
        Me.Controls.Add(Me.cboPropQuotaTextPosition)
        Me.Controls.Add(Me.cmdPropQuotaOtherOptions)
        Me.Controls.Add(Me.lblPropQuotaRelativeTrigpoint)
        Me.Controls.Add(Me.lblPropQuotaType)
        Me.Controls.Add(Me.cboPropQuotaValueType)
        Me.Controls.Add(Me.lblPropQuotaValueType)
        Me.Controls.Add(Me.cboPropQuotaValue)
        Me.Controls.Add(Me.lblPropQuotaValue)
        Me.Controls.Add(Me.cboPropQuotaAlign)
        Me.Controls.Add(Me.lblPropQuotaAlign)
        Me.Controls.Add(Me.txtPropQuotaRelativeTrigpoint)
        Me.Controls.Add(Me.cboPropQuotaType)
        Me.Name = "cItemQuotaPropertyControl"
        CType(Me.txtPropQuotaRelativeTrigpoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.flyParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyParameters.ResumeLayout(False)
        CType(Me.pnlParameters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropQuotaFormat As ComboBox
    Friend WithEvents lblPropQuotaFormat As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropQuotaTextPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropQuotaTextPosition As ComboBox
    Friend WithEvents cmdPropQuotaOtherOptions As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropQuotaRelativeTrigpoint As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropQuotaType As ComboBox
    Friend WithEvents lblPropQuotaType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropQuotaValueType As ComboBox
    Friend WithEvents lblPropQuotaValueType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropQuotaValue As ComboBox
    Friend WithEvents lblPropQuotaValue As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropQuotaAlign As ComboBox
    Friend WithEvents lblPropQuotaAlign As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropQuotaRelativeTrigpoint As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents flyParameters As DevExpress.Utils.FlyoutPanel
    Friend WithEvents pnlParameters As DevExpress.Utils.FlyoutPanelControl
End Class
