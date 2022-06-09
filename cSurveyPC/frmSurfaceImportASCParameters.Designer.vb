<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurfaceImportASCOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceImportASCOptions))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lblTrigpointCoordinateGeo = New DevExpress.XtraEditors.LabelControl()
        Me.frmUTM = New DevExpress.XtraEditors.GroupControl()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboUTMZone = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboUTMBand = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblCheckWarning = New DevExpress.XtraEditors.LabelControl()
        Me.cboCoordinateSystem = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.frmUTM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmUTM.SuspendLayout()
        CType(Me.cboUTMZone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUTMBand.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCoordinateSystem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblTrigpointCoordinateGeo
        '
        Me.lblTrigpointCoordinateGeo.Appearance.Font = CType(resources.GetObject("lblTrigpointCoordinateGeo.Appearance.Font"), System.Drawing.Font)
        Me.lblTrigpointCoordinateGeo.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblTrigpointCoordinateGeo, "lblTrigpointCoordinateGeo")
        Me.lblTrigpointCoordinateGeo.Name = "lblTrigpointCoordinateGeo"
        '
        'frmUTM
        '
        Me.frmUTM.Controls.Add(Me.Label2)
        Me.frmUTM.Controls.Add(Me.Label1)
        Me.frmUTM.Controls.Add(Me.cboUTMZone)
        Me.frmUTM.Controls.Add(Me.cboUTMBand)
        resources.ApplyResources(Me.frmUTM, "frmUTM")
        Me.frmUTM.Name = "frmUTM"
        '
        'Label2
        '
        Me.Label2.Appearance.Font = CType(resources.GetObject("Label2.Appearance.Font"), System.Drawing.Font)
        Me.Label2.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        Me.Label1.Appearance.Font = CType(resources.GetObject("Label1.Appearance.Font"), System.Drawing.Font)
        Me.Label1.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboUTMZone
        '
        resources.ApplyResources(Me.cboUTMZone, "cboUTMZone")
        Me.cboUTMZone.Name = "cboUTMZone"
        Me.cboUTMZone.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboUTMZone.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboUTMZone.Properties.Items.AddRange(New Object() {resources.GetString("cboUTMZone.Properties.Items"), resources.GetString("cboUTMZone.Properties.Items1")})
        Me.cboUTMZone.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboUTMBand
        '
        resources.ApplyResources(Me.cboUTMBand, "cboUTMBand")
        Me.cboUTMBand.Name = "cboUTMBand"
        Me.cboUTMBand.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboUTMBand.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboUTMBand.Properties.Items.AddRange(New Object() {resources.GetString("cboUTMBand.Properties.Items"), resources.GetString("cboUTMBand.Properties.Items1")})
        Me.cboUTMBand.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblCheckWarning
        '
        Me.lblCheckWarning.AllowHtmlString = True
        resources.ApplyResources(Me.lblCheckWarning, "lblCheckWarning")
        Me.lblCheckWarning.Appearance.Options.UseTextOptions = True
        Me.lblCheckWarning.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblCheckWarning.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.lblCheckWarning.Name = "lblCheckWarning"
        '
        'cboCoordinateSystem
        '
        resources.ApplyResources(Me.cboCoordinateSystem, "cboCoordinateSystem")
        Me.cboCoordinateSystem.Name = "cboCoordinateSystem"
        Me.cboCoordinateSystem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboCoordinateSystem.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboCoordinateSystem.Properties.Items.AddRange(New Object() {resources.GetString("cboCoordinateSystem.Properties.Items"), resources.GetString("cboCoordinateSystem.Properties.Items1")})
        Me.cboCoordinateSystem.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'frmSurfaceImportASCOptions
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.frmUTM)
        Me.Controls.Add(Me.lblTrigpointCoordinateGeo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.lblCheckWarning)
        Me.Controls.Add(Me.cboCoordinateSystem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSurfaceImportASCOptions.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.soilmodeldata
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceImportASCOptions"
        CType(Me.frmUTM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmUTM.ResumeLayout(False)
        Me.frmUTM.PerformLayout()
        CType(Me.cboUTMZone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUTMBand.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCoordinateSystem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblTrigpointCoordinateGeo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents frmUTM As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCheckWarning As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboCoordinateSystem As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboUTMZone As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboUTMBand As DevExpress.XtraEditors.ComboBoxEdit
End Class
