<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cProgressPanel
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.lblDetails = New DevExpress.XtraEditors.LabelControl()
        Me.lblTitle = New DevExpress.XtraEditors.LabelControl()
        Me.pb = New DevExpress.XtraEditors.ProgressBarControl()
        Me.picAction = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.pb.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDetails
        '
        Me.lblDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDetails.Appearance.Options.UseTextOptions = True
        Me.lblDetails.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.lblDetails.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.lblDetails.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDetails.Location = New System.Drawing.Point(4, 64)
        Me.lblDetails.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(388, 36)
        Me.lblDetails.TabIndex = 6
        Me.lblDetails.Text = "[Details]"
        '
        'lblTitle
        '
        Me.lblTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTitle.Appearance.Options.UseTextOptions = True
        Me.lblTitle.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblTitle.Location = New System.Drawing.Point(41, 2)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(351, 33)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "[Title]"
        '
        'pb
        '
        Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb.Location = New System.Drawing.Point(4, 40)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(388, 17)
        Me.pb.TabIndex = 4
        '
        'picAction
        '
        Me.picAction.Location = New System.Drawing.Point(4, 3)
        Me.picAction.Name = "picAction"
        Me.picAction.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picAction.Properties.Appearance.Options.UseBackColor = True
        Me.picAction.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picAction.Properties.NullText = " "
        Me.picAction.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picAction.Size = New System.Drawing.Size(32, 32)
        Me.picAction.TabIndex = 8
        '
        'cProgressPanel
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.picAction)
        Me.Name = "cProgressPanel"
        Me.Size = New System.Drawing.Size(397, 104)
        CType(Me.pb.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDetails As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pb As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents picAction As DevExpress.XtraEditors.PictureEdit
End Class
