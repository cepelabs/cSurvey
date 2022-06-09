<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurfaceLayerProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceLayerProperties))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.frmScale = New DevExpress.XtraEditors.GroupControl()
        Me.txtMaxScale = New DevExpress.XtraEditors.SpinEdit()
        Me.txtMinScale = New DevExpress.XtraEditors.SpinEdit()
        Me.lblMaxScale = New DevExpress.XtraEditors.LabelControl()
        Me.lblMinScale = New DevExpress.XtraEditors.LabelControl()
        Me.chkMaxScale = New DevExpress.XtraEditors.CheckEdit()
        Me.chkMinScale = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPropTransparency = New DevExpress.XtraEditors.LabelControl()
        Me.trkTransparency = New DevExpress.XtraEditors.TrackBarControl()
        CType(Me.frmScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmScale.SuspendLayout()
        CType(Me.txtMaxScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMaxScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMinScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'frmScale
        '
        resources.ApplyResources(Me.frmScale, "frmScale")
        Me.frmScale.Controls.Add(Me.txtMaxScale)
        Me.frmScale.Controls.Add(Me.txtMinScale)
        Me.frmScale.Controls.Add(Me.lblMaxScale)
        Me.frmScale.Controls.Add(Me.lblMinScale)
        Me.frmScale.Controls.Add(Me.chkMaxScale)
        Me.frmScale.Controls.Add(Me.chkMinScale)
        Me.frmScale.Name = "frmScale"
        '
        'txtMaxScale
        '
        resources.ApplyResources(Me.txtMaxScale, "txtMaxScale")
        Me.txtMaxScale.Name = "txtMaxScale"
        Me.txtMaxScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtMaxScale.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtMaxScale.Properties.DisplayFormat.FormatString = "N0"
        Me.txtMaxScale.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtMaxScale.Properties.EditFormat.FormatString = "N0"
        Me.txtMaxScale.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtMaxScale.Properties.IsFloatValue = False
        Me.txtMaxScale.Properties.MaskSettings.Set("mask", "N00")
        Me.txtMaxScale.Properties.MaxValue = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtMaxScale.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtMinScale
        '
        resources.ApplyResources(Me.txtMinScale, "txtMinScale")
        Me.txtMinScale.Name = "txtMinScale"
        Me.txtMinScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtMinScale.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtMinScale.Properties.DisplayFormat.FormatString = "N0"
        Me.txtMinScale.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtMinScale.Properties.EditFormat.FormatString = "N0"
        Me.txtMinScale.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtMinScale.Properties.IsFloatValue = False
        Me.txtMinScale.Properties.MaskSettings.Set("mask", "N00")
        Me.txtMinScale.Properties.MaxValue = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtMinScale.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblMaxScale
        '
        resources.ApplyResources(Me.lblMaxScale, "lblMaxScale")
        Me.lblMaxScale.Name = "lblMaxScale"
        '
        'lblMinScale
        '
        resources.ApplyResources(Me.lblMinScale, "lblMinScale")
        Me.lblMinScale.Name = "lblMinScale"
        '
        'chkMaxScale
        '
        resources.ApplyResources(Me.chkMaxScale, "chkMaxScale")
        Me.chkMaxScale.Name = "chkMaxScale"
        Me.chkMaxScale.Properties.Caption = resources.GetString("chkMaxScale.Properties.Caption")
        '
        'chkMinScale
        '
        resources.ApplyResources(Me.chkMinScale, "chkMinScale")
        Me.chkMinScale.Name = "chkMinScale"
        Me.chkMinScale.Properties.Caption = resources.GetString("chkMinScale.Properties.Caption")
        '
        'lblPropTransparency
        '
        resources.ApplyResources(Me.lblPropTransparency, "lblPropTransparency")
        Me.lblPropTransparency.Name = "lblPropTransparency"
        '
        'trkTransparency
        '
        resources.ApplyResources(Me.trkTransparency, "trkTransparency")
        Me.trkTransparency.Name = "trkTransparency"
        Me.trkTransparency.Properties.AutoSize = False
        Me.trkTransparency.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.trkTransparency.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.trkTransparency.Properties.Maximum = 255
        Me.trkTransparency.Properties.TickFrequency = 15
        '
        'frmSurfaceLayerProperties
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblPropTransparency)
        Me.Controls.Add(Me.frmScale)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.trkTransparency)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSurfaceLayerProperties.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.soilmodeldata
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceLayerProperties"
        CType(Me.frmScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmScale.ResumeLayout(False)
        Me.frmScale.PerformLayout()
        CType(Me.txtMaxScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMaxScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMinScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents frmScale As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkMaxScale As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkMinScale As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPropTransparency As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMaxScale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblMinScale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents trkTransparency As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents txtMaxScale As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtMinScale As DevExpress.XtraEditors.SpinEdit
End Class
