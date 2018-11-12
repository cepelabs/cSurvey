<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cProgressPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.picAction = New System.Windows.Forms.PictureBox()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pb = New System.Windows.Forms.ProgressBar()
        CType(Me.picAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picAction
        '
        Me.picAction.Location = New System.Drawing.Point(8, 6)
        Me.picAction.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.picAction.Name = "picAction"
        Me.picAction.Size = New System.Drawing.Size(64, 64)
        Me.picAction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAction.TabIndex = 7
        Me.picAction.TabStop = False
        '
        'lblDetails
        '
        Me.lblDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails.Location = New System.Drawing.Point(8, 128)
        Me.lblDetails.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(776, 66)
        Me.lblDetails.TabIndex = 6
        Me.lblDetails.Text = "[Details]"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Location = New System.Drawing.Point(82, 4)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(702, 66)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "[Title]"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pb
        '
        Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb.Location = New System.Drawing.Point(8, 80)
        Me.pb.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(776, 34)
        Me.pb.TabIndex = 4
        '
        'cProgressPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(192.0!, 192.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.picAction)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pb)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "cProgressPanel"
        Me.Size = New System.Drawing.Size(794, 208)
        CType(Me.picAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picAction As System.Windows.Forms.PictureBox
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pb As System.Windows.Forms.ProgressBar

End Class
