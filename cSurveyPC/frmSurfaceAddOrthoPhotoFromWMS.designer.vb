<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurfaceAddOrthoPhotoFromWMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceAddOrthoPhotoFromWMS))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New DevExpress.XtraEditors.LabelControl()
        Me.lblPlotNoteTextColor = New DevExpress.XtraEditors.LabelControl()
        Me.Label8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtBackgroundColor = New cSurveyPC.cColorSelector()
        Me.txtRatio = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBackgroundColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRatio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'lblPlotNoteTextColor
        '
        Me.lblPlotNoteTextColor.Appearance.Font = CType(resources.GetObject("lblPlotNoteTextColor.Appearance.Font"), System.Drawing.Font)
        Me.lblPlotNoteTextColor.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPlotNoteTextColor, "lblPlotNoteTextColor")
        Me.lblPlotNoteTextColor.Name = "lblPlotNoteTextColor"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txtBackgroundColor
        '
        Me.txtBackgroundColor.DefaultColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.txtBackgroundColor, "txtBackgroundColor")
        Me.txtBackgroundColor.Name = "txtBackgroundColor"
        Me.txtBackgroundColor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtBackgroundColor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtBackgroundColor.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtBackgroundColor.Properties.ShowSystemColors = False
        Me.txtBackgroundColor.Properties.ShowWebColors = False
        '
        'txtRatio
        '
        resources.ApplyResources(Me.txtRatio, "txtRatio")
        Me.txtRatio.Name = "txtRatio"
        Me.txtRatio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtRatio.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtRatio.Properties.DisplayFormat.FormatString = "N0"
        Me.txtRatio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRatio.Properties.EditFormat.FormatString = "N0"
        Me.txtRatio.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRatio.Properties.IsFloatValue = False
        Me.txtRatio.Properties.MaskSettings.Set("mask", "N00")
        Me.txtRatio.Properties.MaxValue = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtRatio.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmSurfaceAddOrthoPhotoFromWMS
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtBackgroundColor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblPlotNoteTextColor)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtRatio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSurfaceAddOrthoPhotoFromWMS.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.map_raster
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceAddOrthoPhotoFromWMS"
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBackgroundColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRatio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPlotNoteTextColor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBackgroundColor As cColorSelector
    Friend WithEvents txtRatio As DevExpress.XtraEditors.SpinEdit
End Class
