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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportVisualTopo))
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.chkVTopoImportIncompatibleSet = New System.Windows.Forms.CheckBox()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCaveName = New System.Windows.Forms.TextBox()
        Me.chkVTopoImportSetAsBranch = New System.Windows.Forms.CheckBox()
        Me.lblCaveName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        Me.txtPrefix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.tipDefault.SetToolTip(Me.txtPrefix, resources.GetString("txtPrefix.ToolTip"))
        '
        'lblPrefix
        '
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'chkVTopoImportIncompatibleSet
        '
        resources.ApplyResources(Me.chkVTopoImportIncompatibleSet, "chkVTopoImportIncompatibleSet")
        Me.chkVTopoImportIncompatibleSet.Name = "chkVTopoImportIncompatibleSet"
        Me.tipDefault.SetToolTip(Me.chkVTopoImportIncompatibleSet, resources.GetString("chkVTopoImportIncompatibleSet.ToolTip"))
        Me.chkVTopoImportIncompatibleSet.UseVisualStyleBackColor = True
        '
        'txtFilename
        '
        Me.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtFilename, resources.GetString("txtFilename.ToolTip"))
        '
        'lblFilename
        '
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtCaveName
        '
        Me.txtCaveName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.Name = "txtCaveName"
        Me.tipDefault.SetToolTip(Me.txtCaveName, resources.GetString("txtCaveName.ToolTip"))
        '
        'chkVTopoImportSetAsBranch
        '
        resources.ApplyResources(Me.chkVTopoImportSetAsBranch, "chkVTopoImportSetAsBranch")
        Me.chkVTopoImportSetAsBranch.Name = "chkVTopoImportSetAsBranch"
        Me.chkVTopoImportSetAsBranch.UseVisualStyleBackColor = True
        '
        'lblCaveName
        '
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportVisualTopo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents chkVTopoImportIncompatibleSet As System.Windows.Forms.CheckBox
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkVTopoImportSetAsBranch As System.Windows.Forms.CheckBox
    Friend WithEvents txtCaveName As System.Windows.Forms.TextBox
    Friend WithEvents lblCaveName As System.Windows.Forms.Label
End Class
