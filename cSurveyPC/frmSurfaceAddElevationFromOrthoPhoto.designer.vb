<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurfaceAddElevationFromOrthoPhoto
    Inherits cForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceAddElevationFromOrthoPhoto))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnHueRange = New DevExpress.XtraEditors.SimpleButton()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.lblHueColorTo = New DevExpress.XtraEditors.LabelControl()
        Me.lblHueColorFrom = New DevExpress.XtraEditors.LabelControl()
        Me.picHue = New DevExpress.XtraEditors.PanelControl()
        Me.txtHueAltFrom = New DevExpress.XtraEditors.SpinEdit()
        Me.txtHueColorTo = New cSurveyPC.cColorSelector()
        Me.chkHueCounterclockwise = New DevExpress.XtraEditors.CheckEdit()
        Me.txtHueColorFrom = New cSurveyPC.cColorSelector()
        Me.txtHueAltTo = New DevExpress.XtraEditors.SpinEdit()
        Me.lblMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboMode = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picHue.SuspendLayout()
        CType(Me.txtHueAltFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHueColorTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkHueCounterclockwise.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHueColorFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHueAltTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'btnHueRange
        '
        Me.btnHueRange.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.range
        resources.ApplyResources(Me.btnHueRange, "btnHueRange")
        Me.btnHueRange.Name = "btnHueRange"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'lblHueColorTo
        '
        Me.lblHueColorTo.Appearance.Font = CType(resources.GetObject("lblHueColorTo.Appearance.Font"), System.Drawing.Font)
        Me.lblHueColorTo.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblHueColorTo, "lblHueColorTo")
        Me.lblHueColorTo.Name = "lblHueColorTo"
        '
        'lblHueColorFrom
        '
        Me.lblHueColorFrom.Appearance.Font = CType(resources.GetObject("lblHueColorFrom.Appearance.Font"), System.Drawing.Font)
        Me.lblHueColorFrom.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblHueColorFrom, "lblHueColorFrom")
        Me.lblHueColorFrom.Name = "lblHueColorFrom"
        '
        'picHue
        '
        Me.picHue.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picHue.Controls.Add(Me.txtHueAltFrom)
        Me.picHue.Controls.Add(Me.txtHueColorTo)
        Me.picHue.Controls.Add(Me.btnHueRange)
        Me.picHue.Controls.Add(Me.chkHueCounterclockwise)
        Me.picHue.Controls.Add(Me.lblHueColorFrom)
        Me.picHue.Controls.Add(Me.lblHueColorTo)
        Me.picHue.Controls.Add(Me.txtHueColorFrom)
        Me.picHue.Controls.Add(Me.txtHueAltTo)
        resources.ApplyResources(Me.picHue, "picHue")
        Me.picHue.Name = "picHue"
        '
        'txtHueAltFrom
        '
        resources.ApplyResources(Me.txtHueAltFrom, "txtHueAltFrom")
        Me.txtHueAltFrom.Name = "txtHueAltFrom"
        Me.txtHueAltFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtHueAltFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtHueAltFrom.Properties.DisplayFormat.FormatString = "N0"
        Me.txtHueAltFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHueAltFrom.Properties.EditFormat.FormatString = "N0"
        Me.txtHueAltFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHueAltFrom.Properties.IsFloatValue = False
        Me.txtHueAltFrom.Properties.MaskSettings.Set("mask", "N00")
        Me.txtHueAltFrom.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtHueAltFrom.Properties.MinValue = New Decimal(New Integer() {14999, 0, 0, -2147483648})
        '
        'txtHueColorTo
        '
        Me.txtHueColorTo.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtHueColorTo, "txtHueColorTo")
        Me.txtHueColorTo.Name = "txtHueColorTo"
        Me.txtHueColorTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtHueColorTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtHueColorTo.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHueColorTo.Properties.ShowSystemColors = False
        Me.txtHueColorTo.Properties.ShowWebColors = False
        '
        'chkHueCounterclockwise
        '
        resources.ApplyResources(Me.chkHueCounterclockwise, "chkHueCounterclockwise")
        Me.chkHueCounterclockwise.Name = "chkHueCounterclockwise"
        Me.chkHueCounterclockwise.Properties.Caption = resources.GetString("chkHueCounterclockwise.Properties.Caption")
        '
        'txtHueColorFrom
        '
        Me.txtHueColorFrom.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtHueColorFrom, "txtHueColorFrom")
        Me.txtHueColorFrom.Name = "txtHueColorFrom"
        Me.txtHueColorFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtHueColorFrom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtHueColorFrom.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtHueColorFrom.Properties.ShowSystemColors = False
        Me.txtHueColorFrom.Properties.ShowWebColors = False
        '
        'txtHueAltTo
        '
        resources.ApplyResources(Me.txtHueAltTo, "txtHueAltTo")
        Me.txtHueAltTo.Name = "txtHueAltTo"
        Me.txtHueAltTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtHueAltTo.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtHueAltTo.Properties.DisplayFormat.FormatString = "N0"
        Me.txtHueAltTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHueAltTo.Properties.EditFormat.FormatString = "N0"
        Me.txtHueAltTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtHueAltTo.Properties.MaxValue = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtHueAltTo.Properties.MinValue = New Decimal(New Integer() {14999, 0, 0, -2147483648})
        '
        'lblMode
        '
        resources.ApplyResources(Me.lblMode, "lblMode")
        Me.lblMode.Name = "lblMode"
        '
        'cboMode
        '
        resources.ApplyResources(Me.cboMode, "cboMode")
        Me.cboMode.Name = "cboMode"
        Me.cboMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboMode.Properties.Items.AddRange(New Object() {resources.GetString("cboMode.Properties.Items")})
        Me.cboMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'frmSurfaceAddElevationFromOrthoPhoto
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.picHue)
        Me.Controls.Add(Me.cboMode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSurfaceAddElevationFromOrthoPhoto.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.soilmodeldata
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceAddElevationFromOrthoPhoto"
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picHue.ResumeLayout(False)
        Me.picHue.PerformLayout()
        CType(Me.txtHueAltFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHueColorTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkHueCounterclockwise.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHueColorFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHueAltTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblHueColorTo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblHueColorFrom As DevExpress.XtraEditors.LabelControl
    Friend WithEvents picHue As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkHueCounterclockwise As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnHueRange As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtHueColorTo As cColorSelector
    Friend WithEvents txtHueColorFrom As cColorSelector
    Friend WithEvents cboMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtHueAltFrom As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtHueAltTo As DevExpress.XtraEditors.SpinEdit
End Class
