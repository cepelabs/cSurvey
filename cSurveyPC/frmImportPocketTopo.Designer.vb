<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportPocketTopo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportPocketTopo))
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.lblPrefix = New System.Windows.Forms.Label()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCaveName = New System.Windows.Forms.TextBox()
        Me.lblCaveName = New System.Windows.Forms.Label()
        Me.chkPocketTopoImportData = New System.Windows.Forms.CheckBox()
        Me.chkPocketTopoImportGraphics = New System.Windows.Forms.CheckBox()
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
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
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
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCaveName.Name = "txtCaveName"
        Me.tipDefault.SetToolTip(Me.txtCaveName, resources.GetString("txtCaveName.ToolTip"))
        '
        'lblCaveName
        '
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'chkPocketTopoImportData
        '
        resources.ApplyResources(Me.chkPocketTopoImportData, "chkPocketTopoImportData")
        Me.chkPocketTopoImportData.Name = "chkPocketTopoImportData"
        Me.chkPocketTopoImportData.UseVisualStyleBackColor = True
        '
        'chkPocketTopoImportGraphics
        '
        resources.ApplyResources(Me.chkPocketTopoImportGraphics, "chkPocketTopoImportGraphics")
        Me.chkPocketTopoImportGraphics.Name = "chkPocketTopoImportGraphics"
        Me.chkPocketTopoImportGraphics.UseVisualStyleBackColor = True
        '
        'frmImportPocketTopo
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkPocketTopoImportGraphics)
        Me.Controls.Add(Me.chkPocketTopoImportData)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportPocketTopo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As System.Windows.Forms.TextBox
    Friend WithEvents lblPrefix As System.Windows.Forms.Label
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtCaveName As System.Windows.Forms.TextBox
    Friend WithEvents lblCaveName As System.Windows.Forms.Label
    Friend WithEvents chkPocketTopoImportData As System.Windows.Forms.CheckBox
    Friend WithEvents chkPocketTopoImportGraphics As System.Windows.Forms.CheckBox
End Class
