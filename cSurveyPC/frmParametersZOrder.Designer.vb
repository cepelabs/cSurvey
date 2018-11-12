<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersZOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersZOrder))
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.tvCaveInfos = New System.Windows.Forms.TreeView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.chkKeepCaveAndBranchGrouped = New System.Windows.Forms.CheckBox()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'tvCaveInfos
        '
        resources.ApplyResources(Me.tvCaveInfos, "tvCaveInfos")
        Me.tvCaveInfos.ImageList = Me.iml
        Me.tvCaveInfos.Name = "tvCaveInfos"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "cave")
        Me.iml.Images.SetKeyName(1, "branch")
        Me.iml.Images.SetKeyName(2, "deleted")
        '
        'chkKeepCaveAndBranchGrouped
        '
        resources.ApplyResources(Me.chkKeepCaveAndBranchGrouped, "chkKeepCaveAndBranchGrouped")
        Me.chkKeepCaveAndBranchGrouped.Name = "chkKeepCaveAndBranchGrouped"
        Me.chkKeepCaveAndBranchGrouped.UseVisualStyleBackColor = True
        '
        'cmdMoveUp
        '
        resources.ApplyResources(Me.cmdMoveUp, "cmdMoveUp")
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.UseVisualStyleBackColor = True
        '
        'cmdMoveDown
        '
        resources.ApplyResources(Me.cmdMoveDown, "cmdMoveDown")
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.UseVisualStyleBackColor = True
        '
        'frmParametersZOrder
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdMoveDown)
        Me.Controls.Add(Me.cmdMoveUp)
        Me.Controls.Add(Me.chkKeepCaveAndBranchGrouped)
        Me.Controls.Add(Me.tvCaveInfos)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersZOrder"
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents tvCaveInfos As System.Windows.Forms.TreeView
    Friend WithEvents chkKeepCaveAndBranchGrouped As System.Windows.Forms.CheckBox
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
End Class
