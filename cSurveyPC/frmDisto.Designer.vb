<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisto))
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.cboPort = New System.Windows.Forms.ComboBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtOutput = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'SerialPort
        '
        '
        'cmdConnect
        '
        resources.ApplyResources(Me.cmdConnect, "cmdConnect")
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'cboPort
        '
        Me.cboPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPort.FormattingEnabled = True
        resources.ApplyResources(Me.cboPort, "cboPort")
        Me.cboPort.Name = "cboPort"
        '
        'lblPort
        '
        resources.ApplyResources(Me.lblPort, "lblPort")
        Me.lblPort.Name = "lblPort"
        '
        'txtOutput
        '
        resources.ApplyResources(Me.txtOutput, "txtOutput")
        Me.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        '
        'frmDisto
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.cboPort)
        Me.Controls.Add(Me.cmdConnect)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmDisto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
    Friend WithEvents txtOutput As System.Windows.Forms.RichTextBox
End Class
