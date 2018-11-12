<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurveyGrade
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
        Me.cboDefGrade = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlV0 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboDefAccuracy = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.pnlV1 = New System.Windows.Forms.Panel()
        Me.lblV1Suffissi = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblV1SurveyGrade = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.pnlV0.SuspendLayout()
        Me.pnlV1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboDefGrade
        '
        Me.cboDefGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefGrade.FormattingEnabled = True
        Me.cboDefGrade.Items.AddRange(New Object() {"", "1"})
        Me.cboDefGrade.Location = New System.Drawing.Point(70, 12)
        Me.cboDefGrade.Name = "cboDefGrade"
        Me.cboDefGrade.Size = New System.Drawing.Size(83, 21)
        Me.cboDefGrade.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Versione:"
        '
        'pnlV0
        '
        Me.pnlV0.Controls.Add(Me.Label10)
        Me.pnlV0.Controls.Add(Me.cboDefAccuracy)
        Me.pnlV0.Controls.Add(Me.ComboBox1)
        Me.pnlV0.Location = New System.Drawing.Point(15, 39)
        Me.pnlV0.Name = "pnlV0"
        Me.pnlV0.Size = New System.Drawing.Size(522, 57)
        Me.pnlV0.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(3, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Grado/acc.:"
        '
        'cboDefAccuracy
        '
        Me.cboDefAccuracy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefAccuracy.FormattingEnabled = True
        Me.cboDefAccuracy.Items.AddRange(New Object() {"", "A", "B", "C", "D"})
        Me.cboDefAccuracy.Location = New System.Drawing.Point(162, 3)
        Me.cboDefAccuracy.Name = "cboDefAccuracy"
        Me.cboDefAccuracy.Size = New System.Drawing.Size(83, 21)
        Me.cboDefAccuracy.TabIndex = 9
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5", "6", "X"})
        Me.ComboBox1.Location = New System.Drawing.Point(73, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(83, 21)
        Me.ComboBox1.TabIndex = 8
        '
        'pnlV1
        '
        Me.pnlV1.Controls.Add(Me.lblV1Suffissi)
        Me.pnlV1.Controls.Add(Me.CheckedListBox1)
        Me.pnlV1.Controls.Add(Me.Label2)
        Me.pnlV1.Controls.Add(Me.lblV1SurveyGrade)
        Me.pnlV1.Controls.Add(Me.ComboBox2)
        Me.pnlV1.Controls.Add(Me.ComboBox3)
        Me.pnlV1.Location = New System.Drawing.Point(15, 116)
        Me.pnlV1.Name = "pnlV1"
        Me.pnlV1.Size = New System.Drawing.Size(556, 141)
        Me.pnlV1.TabIndex = 16
        '
        'lblV1Suffissi
        '
        Me.lblV1Suffissi.AutoSize = True
        Me.lblV1Suffissi.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblV1Suffissi.Location = New System.Drawing.Point(3, 30)
        Me.lblV1Suffissi.Name = "lblV1Suffissi"
        Me.lblV1Suffissi.Size = New System.Drawing.Size(94, 13)
        Me.lblV1Suffissi.TabIndex = 18
        Me.lblV1Suffissi.Text = "Suffissi aggiuntivi:"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckedListBox1.BackColor = System.Drawing.SystemColors.Control
        Me.CheckedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Items.AddRange(New Object() {"A - Non è stata effettuata alcuna operazione per aumentare l'accuratezza dei dati" &
                "", "B - Gli anelli sono stati chiusi e corretti.", "C - Sono state corrette le eventuali anomalie d'uso o strumentali.", "D - Sono stati applicate correzioni 'automatiche' agli strumenti", "E - I dati non sono stati trascritti manualmente ma scaricati in formato elettron" &
                "ico.", "F - Gli ingressi sono stati posizionati accuratamente"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(103, 30)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(438, 96)
        Me.CheckedListBox1.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(210, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Precisione disegno:"
        '
        'lblV1SurveyGrade
        '
        Me.lblV1SurveyGrade.AutoSize = True
        Me.lblV1SurveyGrade.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblV1SurveyGrade.Location = New System.Drawing.Point(3, 6)
        Me.lblV1SurveyGrade.Name = "lblV1SurveyGrade"
        Me.lblV1SurveyGrade.Size = New System.Drawing.Size(80, 13)
        Me.lblV1SurveyGrade.TabIndex = 15
        Me.lblV1SurveyGrade.Text = "Precisione dati:"
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"0", "1", "2", "3", "4"})
        Me.ComboBox2.Location = New System.Drawing.Point(315, 3)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(83, 21)
        Me.ComboBox2.TabIndex = 9
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"-1", "0", "1", "2", "3", "4", "5", "6", "X"})
        Me.ComboBox3.Location = New System.Drawing.Point(103, 3)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(83, 21)
        Me.ComboBox3.TabIndex = 8
        '
        'frmSurveyGrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(583, 319)
        Me.Controls.Add(Me.pnlV1)
        Me.Controls.Add(Me.pnlV0)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboDefGrade)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSurveyGrade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Grado/precisione del rilievo:"
        Me.pnlV0.ResumeLayout(False)
        Me.pnlV0.PerformLayout()
        Me.pnlV1.ResumeLayout(False)
        Me.pnlV1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboDefGrade As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlV0 As System.Windows.Forms.Panel
    Friend WithEvents cboDefAccuracy As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents pnlV1 As System.Windows.Forms.Panel
    Friend WithEvents lblV1Suffissi As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblV1SurveyGrade As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
End Class
