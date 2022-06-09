<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportVisualTopo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportVisualTopo))
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.chkVTopoImportIncompatibleSet = New DevExpress.XtraEditors.CheckEdit()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCaveName = New DevExpress.XtraEditors.TextEdit()
        Me.chkVTopoImportSetAsBranch = New DevExpress.XtraEditors.CheckEdit()
        Me.lblCaveName = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVTopoImportIncompatibleSet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkVTopoImportSetAsBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'chkVTopoImportIncompatibleSet
        '
        resources.ApplyResources(Me.chkVTopoImportIncompatibleSet, "chkVTopoImportIncompatibleSet")
        Me.chkVTopoImportIncompatibleSet.Name = "chkVTopoImportIncompatibleSet"
        Me.chkVTopoImportIncompatibleSet.Properties.Caption = resources.GetString("chkVTopoImportIncompatibleSet.Properties.Caption")
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Properties.ReadOnly = True
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
        '
        'chkVTopoImportSetAsBranch
        '
        resources.ApplyResources(Me.chkVTopoImportSetAsBranch, "chkVTopoImportSetAsBranch")
        Me.chkVTopoImportSetAsBranch.Name = "chkVTopoImportSetAsBranch"
        Me.chkVTopoImportSetAsBranch.Properties.Caption = resources.GetString("chkVTopoImportSetAsBranch.Properties.Caption")
        '
        'lblCaveName
        '
        Me.lblCaveName.Appearance.Font = CType(resources.GetObject("lblCaveName.Appearance.Font"), System.Drawing.Font)
        Me.lblCaveName.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'frmImportVisualTopo
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.chkVTopoImportSetAsBranch)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.chkVTopoImportIncompatibleSet)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportVisualTopo.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportVisualTopo"
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVTopoImportIncompatibleSet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkVTopoImportSetAsBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkVTopoImportIncompatibleSet As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkVTopoImportSetAsBranch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtCaveName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCaveName As DevExpress.XtraEditors.LabelControl
End Class
