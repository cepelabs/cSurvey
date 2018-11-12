<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgress))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.tblPanels = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDefault = New cSurveyPC.cProgressPanel()
        Me.tblPanels.SuspendLayout()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "default")
        Me.iml.Images.SetKeyName(1, "export")
        Me.iml.Images.SetKeyName(2, "open")
        Me.iml.Images.SetKeyName(3, "save")
        Me.iml.Images.SetKeyName(4, "calculate")
        Me.iml.Images.SetKeyName(5, "paint")
        Me.iml.Images.SetKeyName(6, "convert")
        Me.iml.Images.SetKeyName(7, "import")
        Me.iml.Images.SetKeyName(8, "download")
        Me.iml.Images.SetKeyName(9, "filter")
        Me.iml.Images.SetKeyName(10, "warping")
        Me.iml.Images.SetKeyName(11, "3d")
        '
        'tblPanels
        '
        Me.tblPanels.ColumnCount = 1
        Me.tblPanels.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPanels.Controls.Add(Me.pnlDefault, 0, 0)
        Me.tblPanels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPanels.Location = New System.Drawing.Point(0, 0)
        Me.tblPanels.Margin = New System.Windows.Forms.Padding(0)
        Me.tblPanels.Name = "tblPanels"
        Me.tblPanels.RowCount = 1
        Me.tblPanels.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tblPanels.Size = New System.Drawing.Size(412, 111)
        Me.tblPanels.TabIndex = 5
        '
        'pnlDefault
        '
        Me.pnlDefault.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDefault.Location = New System.Drawing.Point(3, 3)
        Me.pnlDefault.Name = "pnlDefault"
        Me.pnlDefault.Size = New System.Drawing.Size(406, 105)
        Me.pnlDefault.TabIndex = 4
        '
        'frmProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(412, 111)
        Me.Controls.Add(Me.tblPanels)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgress"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.tblPanels.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents pnlDefault As cSurveyPC.cProgressPanel
    Friend WithEvents tblPanels As System.Windows.Forms.TableLayoutPanel
End Class
