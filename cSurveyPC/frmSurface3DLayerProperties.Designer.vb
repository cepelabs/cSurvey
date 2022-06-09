<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurface3DLayerProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurface3DLayerProperties))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropTransparency = New DevExpress.XtraEditors.LabelControl()
        Me.trkTransparency = New DevExpress.XtraEditors.TrackBarControl()
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
        'frmSurface3DLayerProperties
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.trkTransparency)
        Me.Controls.Add(Me.lblPropTransparency)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSurface3DLayerProperties.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.soilmodeldata
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurface3DLayerProperties"
        CType(Me.trkTransparency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropTransparency As DevExpress.XtraEditors.LabelControl
    Friend WithEvents trkTransparency As DevExpress.XtraEditors.TrackBarControl
End Class
