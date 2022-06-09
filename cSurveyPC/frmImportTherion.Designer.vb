<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportTherion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportTherion))
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCaveName = New DevExpress.XtraEditors.TextEdit()
        Me.lblCaveName = New DevExpress.XtraEditors.LabelControl()
        Me.chkTherionImportprofile = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionImportplan = New DevExpress.XtraEditors.CheckEdit()
        Me.chkTherionMergeAndReorderBorders = New DevExpress.XtraEditors.CheckEdit()
        Me.chktherionConvertBezierToSpline = New DevExpress.XtraEditors.CheckEdit()
        Me.lblTherionScaleFactor = New DevExpress.XtraEditors.LabelControl()
        Me.txtTherionScaleFactor = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionImportprofile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionImportplan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTherionMergeAndReorderBorders.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chktherionConvertBezierToSpline.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTherionScaleFactor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tipDefault.SetToolTip(Me.txtPrefix, resources.GetString("txtPrefix.ToolTip"))
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Properties.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtFilename, resources.GetString("txtFilename.ToolTip"))
        '
        'lblFilename
        '
        Me.lblFilename.Appearance.Font = CType(resources.GetObject("lblFilename.Appearance.Font"), System.Drawing.Font)
        Me.lblFilename.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
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
        'txtCaveName
        '
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.Name = "txtCaveName"
        Me.tipDefault.SetToolTip(Me.txtCaveName, resources.GetString("txtCaveName.ToolTip"))
        '
        'lblCaveName
        '
        Me.lblCaveName.Appearance.Font = CType(resources.GetObject("lblCaveName.Appearance.Font"), System.Drawing.Font)
        Me.lblCaveName.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'chkTherionImportprofile
        '
        resources.ApplyResources(Me.chkTherionImportprofile, "chkTherionImportprofile")
        Me.chkTherionImportprofile.Name = "chkTherionImportprofile"
        Me.chkTherionImportprofile.Properties.Caption = resources.GetString("chkTherionImportprofile.Properties.Caption")
        '
        'chkTherionImportplan
        '
        resources.ApplyResources(Me.chkTherionImportplan, "chkTherionImportplan")
        Me.chkTherionImportplan.Name = "chkTherionImportplan"
        Me.chkTherionImportplan.Properties.Caption = resources.GetString("chkTherionImportplan.Properties.Caption")
        '
        'chkTherionMergeAndReorderBorders
        '
        resources.ApplyResources(Me.chkTherionMergeAndReorderBorders, "chkTherionMergeAndReorderBorders")
        Me.chkTherionMergeAndReorderBorders.Name = "chkTherionMergeAndReorderBorders"
        Me.chkTherionMergeAndReorderBorders.Properties.Caption = resources.GetString("chkTherionMergeAndReorderBorders.Properties.Caption")
        '
        'chktherionConvertBezierToSpline
        '
        resources.ApplyResources(Me.chktherionConvertBezierToSpline, "chktherionConvertBezierToSpline")
        Me.chktherionConvertBezierToSpline.Name = "chktherionConvertBezierToSpline"
        Me.chktherionConvertBezierToSpline.Properties.Caption = resources.GetString("chktherionConvertBezierToSpline.Properties.Caption")
        '
        'lblTherionScaleFactor
        '
        resources.ApplyResources(Me.lblTherionScaleFactor, "lblTherionScaleFactor")
        Me.lblTherionScaleFactor.Name = "lblTherionScaleFactor"
        '
        'txtTherionScaleFactor
        '
        resources.ApplyResources(Me.txtTherionScaleFactor, "txtTherionScaleFactor")
        Me.txtTherionScaleFactor.Name = "txtTherionScaleFactor"
        Me.txtTherionScaleFactor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtTherionScaleFactor.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtTherionScaleFactor.Properties.DisplayFormat.FormatString = "N2"
        Me.txtTherionScaleFactor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTherionScaleFactor.Properties.EditFormat.FormatString = "N2"
        Me.txtTherionScaleFactor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTherionScaleFactor.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtTherionScaleFactor.Properties.MaxValue = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txtTherionScaleFactor.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'frmImportTherion
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtTherionScaleFactor)
        Me.Controls.Add(Me.lblTherionScaleFactor)
        Me.Controls.Add(Me.chktherionConvertBezierToSpline)
        Me.Controls.Add(Me.chkTherionMergeAndReorderBorders)
        Me.Controls.Add(Me.chkTherionImportprofile)
        Me.Controls.Add(Me.chkTherionImportplan)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportTherion.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportTherion"
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionImportprofile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionImportplan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTherionMergeAndReorderBorders.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chktherionConvertBezierToSpline.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTherionScaleFactor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtCaveName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCaveName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkTherionImportprofile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTherionImportplan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkTherionMergeAndReorderBorders As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chktherionConvertBezierToSpline As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblTherionScaleFactor As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTherionScaleFactor As DevExpress.XtraEditors.SpinEdit
End Class
