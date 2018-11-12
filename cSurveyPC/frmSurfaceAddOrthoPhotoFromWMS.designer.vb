<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurfaceAddOrthoPhotoFromWMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceAddOrthoPhotoFromWMS))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.picBackgroundColor = New System.Windows.Forms.PictureBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdBackgroundColor = New System.Windows.Forms.Button()
        Me.lblPlotNoteTextColor = New System.Windows.Forms.Label()
        Me.txtRatio = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.picBackgroundColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
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
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'picBackgroundColor
        '
        resources.ApplyResources(Me.picBackgroundColor, "picBackgroundColor")
        Me.picBackgroundColor.Name = "picBackgroundColor"
        Me.picBackgroundColor.TabStop = False
        Me.tipDefault.SetToolTip(Me.picBackgroundColor, resources.GetString("picBackgroundColor.ToolTip"))
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'cmdBackgroundColor
        '
        resources.ApplyResources(Me.cmdBackgroundColor, "cmdBackgroundColor")
        Me.cmdBackgroundColor.Name = "cmdBackgroundColor"
        Me.cmdBackgroundColor.UseVisualStyleBackColor = True
        '
        'lblPlotNoteTextColor
        '
        resources.ApplyResources(Me.lblPlotNoteTextColor, "lblPlotNoteTextColor")
        Me.lblPlotNoteTextColor.Name = "lblPlotNoteTextColor"
        '
        'txtRatio
        '
        resources.ApplyResources(Me.txtRatio, "txtRatio")
        Me.txtRatio.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtRatio.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtRatio.Name = "txtRatio"
        Me.txtRatio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'frmSurfaceAddOrthoPhotoFromWMS
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdBackgroundColor)
        Me.Controls.Add(Me.lblPlotNoteTextColor)
        Me.Controls.Add(Me.picBackgroundColor)
        Me.Controls.Add(Me.txtRatio)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceAddOrthoPhotoFromWMS"
        CType(Me.picBackgroundColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRatio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdBackgroundColor As System.Windows.Forms.Button
    Friend WithEvents lblPlotNoteTextColor As System.Windows.Forms.Label
    Friend WithEvents picBackgroundColor As System.Windows.Forms.PictureBox
    Friend WithEvents txtRatio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
