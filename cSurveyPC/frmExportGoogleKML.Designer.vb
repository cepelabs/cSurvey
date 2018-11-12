<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportGoogleKML
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportGoogleKML))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExportWaypoint = New System.Windows.Forms.CheckBox()
        Me.chkExportTrack = New System.Windows.Forms.CheckBox()
        Me.chkExportCaveBorders = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
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
        'chkExportWaypoint
        '
        resources.ApplyResources(Me.chkExportWaypoint, "chkExportWaypoint")
        Me.chkExportWaypoint.Name = "chkExportWaypoint"
        Me.chkExportWaypoint.UseVisualStyleBackColor = True
        '
        'chkExportTrack
        '
        resources.ApplyResources(Me.chkExportTrack, "chkExportTrack")
        Me.chkExportTrack.Name = "chkExportTrack"
        Me.chkExportTrack.UseVisualStyleBackColor = True
        '
        'chkExportCaveBorders
        '
        resources.ApplyResources(Me.chkExportCaveBorders, "chkExportCaveBorders")
        Me.chkExportCaveBorders.Name = "chkExportCaveBorders"
        Me.chkExportCaveBorders.UseVisualStyleBackColor = True
        '
        'frmExportGoogleKML
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkExportCaveBorders)
        Me.Controls.Add(Me.chkExportTrack)
        Me.Controls.Add(Me.chkExportWaypoint)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportGoogleKML"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportWaypoint As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportTrack As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportCaveBorders As System.Windows.Forms.CheckBox
End Class
