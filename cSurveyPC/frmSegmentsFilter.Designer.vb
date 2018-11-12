<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSegmentsFilter
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
        Me.frmFilter = New System.Windows.Forms.GroupBox()
        Me.lblFilterWarning = New System.Windows.Forms.Label()
        Me.picFilterWarning = New System.Windows.Forms.PictureBox()
        Me.lblFilterA = New System.Windows.Forms.Label()
        Me.txtFilterTo = New System.Windows.Forms.TextBox()
        Me.lblFilterDa = New System.Windows.Forms.Label()
        Me.txtFilterFrom = New System.Windows.Forms.TextBox()
        Me.frmFilter.SuspendLayout()
        CType(Me.picFilterWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmFilter
        '
        Me.frmFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.frmFilter.Controls.Add(Me.lblFilterWarning)
        Me.frmFilter.Controls.Add(Me.picFilterWarning)
        Me.frmFilter.Controls.Add(Me.lblFilterA)
        Me.frmFilter.Controls.Add(Me.txtFilterTo)
        Me.frmFilter.Controls.Add(Me.lblFilterDa)
        Me.frmFilter.Controls.Add(Me.txtFilterFrom)
        Me.frmFilter.Enabled = False
        Me.frmFilter.Location = New System.Drawing.Point(108, 110)
        Me.frmFilter.Name = "frmFilter"
        Me.frmFilter.Size = New System.Drawing.Size(382, 102)
        Me.frmFilter.TabIndex = 8
        Me.frmFilter.TabStop = False
        Me.frmFilter.Text = "Criteri capisaldi:"
        '
        'lblFilterWarning
        '
        Me.lblFilterWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblFilterWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFilterWarning.Location = New System.Drawing.Point(45, 70)
        Me.lblFilterWarning.Name = "lblFilterWarning"
        Me.lblFilterWarning.Size = New System.Drawing.Size(317, 18)
        Me.lblFilterWarning.TabIndex = 109
        Me.lblFilterWarning.Text = "Attenzione: è possibile utilizzare i caratteri jolly"
        '
        'picFilterWarning
        '
        Me.picFilterWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picFilterWarning.Image = Global.cSurveyPC.My.Resources.Resources.information
        Me.picFilterWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picFilterWarning.Location = New System.Drawing.Point(21, 70)
        Me.picFilterWarning.Name = "picFilterWarning"
        Me.picFilterWarning.Size = New System.Drawing.Size(16, 16)
        Me.picFilterWarning.TabIndex = 108
        Me.picFilterWarning.TabStop = False
        '
        'lblFilterA
        '
        Me.lblFilterA.AutoSize = True
        Me.lblFilterA.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFilterA.Location = New System.Drawing.Point(178, 28)
        Me.lblFilterA.Name = "lblFilterA"
        Me.lblFilterA.Size = New System.Drawing.Size(17, 13)
        Me.lblFilterA.TabIndex = 10
        Me.lblFilterA.Text = "A:"
        '
        'txtFilterTo
        '
        Me.txtFilterTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilterTo.Location = New System.Drawing.Point(212, 25)
        Me.txtFilterTo.Name = "txtFilterTo"
        Me.txtFilterTo.Size = New System.Drawing.Size(85, 20)
        Me.txtFilterTo.TabIndex = 1
        '
        'lblFilterDa
        '
        Me.lblFilterDa.AutoSize = True
        Me.lblFilterDa.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFilterDa.Location = New System.Drawing.Point(20, 28)
        Me.lblFilterDa.Name = "lblFilterDa"
        Me.lblFilterDa.Size = New System.Drawing.Size(24, 13)
        Me.lblFilterDa.TabIndex = 8
        Me.lblFilterDa.Text = "Da:"
        '
        'txtFilterFrom
        '
        Me.txtFilterFrom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilterFrom.Location = New System.Drawing.Point(63, 25)
        Me.txtFilterFrom.Name = "txtFilterFrom"
        Me.txtFilterFrom.Size = New System.Drawing.Size(85, 20)
        Me.txtFilterFrom.TabIndex = 0
        '
        'frmSegmentsFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(599, 323)
        Me.Controls.Add(Me.frmFilter)
        Me.Name = "frmSegmentsFilter"
        Me.Text = "frmSegmentsFilter"
        Me.frmFilter.ResumeLayout(False)
        Me.frmFilter.PerformLayout()
        CType(Me.picFilterWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmFilter As System.Windows.Forms.GroupBox
    Friend WithEvents lblFilterWarning As System.Windows.Forms.Label
    Friend WithEvents picFilterWarning As System.Windows.Forms.PictureBox
    Friend WithEvents lblFilterA As System.Windows.Forms.Label
    Friend WithEvents txtFilterTo As System.Windows.Forms.TextBox
    Friend WithEvents lblFilterDa As System.Windows.Forms.Label
    Friend WithEvents txtFilterFrom As System.Windows.Forms.TextBox
End Class
