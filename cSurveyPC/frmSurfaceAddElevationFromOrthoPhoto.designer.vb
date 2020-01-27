<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurfaceAddElevationFromOrthoPhoto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceAddElevationFromOrthoPhoto))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.picHueColorTo = New System.Windows.Forms.PictureBox()
        Me.picHueColorFrom = New System.Windows.Forms.PictureBox()
        Me.btnHueRange = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnHueColorTo = New System.Windows.Forms.Button()
        Me.lblHueColorTo = New System.Windows.Forms.Label()
        Me.cboMode = New System.Windows.Forms.ComboBox()
        Me.btnHueColorFrom = New System.Windows.Forms.Button()
        Me.lblHueColorFrom = New System.Windows.Forms.Label()
        Me.txtHueAltFrom = New System.Windows.Forms.NumericUpDown()
        Me.txtHueAltTo = New System.Windows.Forms.NumericUpDown()
        Me.picHue = New System.Windows.Forms.Panel()
        Me.chkHueCounterclockwise = New System.Windows.Forms.CheckBox()
        Me.lblMode = New System.Windows.Forms.Label()
        CType(Me.picHueColorTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picHueColorFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHueAltFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHueAltTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picHue.SuspendLayout()
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
        'picHueColorTo
        '
        resources.ApplyResources(Me.picHueColorTo, "picHueColorTo")
        Me.picHueColorTo.Name = "picHueColorTo"
        Me.picHueColorTo.TabStop = False
        Me.tipDefault.SetToolTip(Me.picHueColorTo, resources.GetString("picHueColorTo.ToolTip"))
        '
        'picHueColorFrom
        '
        resources.ApplyResources(Me.picHueColorFrom, "picHueColorFrom")
        Me.picHueColorFrom.Name = "picHueColorFrom"
        Me.picHueColorFrom.TabStop = False
        Me.tipDefault.SetToolTip(Me.picHueColorFrom, resources.GetString("picHueColorFrom.ToolTip"))
        '
        'btnHueRange
        '
        Me.btnHueRange.Image = Global.cSurveyPC.My.Resources.Resources.contrast_increase
        resources.ApplyResources(Me.btnHueRange, "btnHueRange")
        Me.btnHueRange.Name = "btnHueRange"
        Me.tipDefault.SetToolTip(Me.btnHueRange, resources.GetString("btnHueRange.ToolTip"))
        Me.btnHueRange.UseVisualStyleBackColor = True
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'btnHueColorTo
        '
        resources.ApplyResources(Me.btnHueColorTo, "btnHueColorTo")
        Me.btnHueColorTo.Name = "btnHueColorTo"
        Me.btnHueColorTo.UseVisualStyleBackColor = True
        '
        'lblHueColorTo
        '
        resources.ApplyResources(Me.lblHueColorTo, "lblHueColorTo")
        Me.lblHueColorTo.Name = "lblHueColorTo"
        '
        'cboMode
        '
        Me.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMode.FormattingEnabled = True
        Me.cboMode.Items.AddRange(New Object() {resources.GetString("cboMode.Items")})
        resources.ApplyResources(Me.cboMode, "cboMode")
        Me.cboMode.Name = "cboMode"
        '
        'btnHueColorFrom
        '
        resources.ApplyResources(Me.btnHueColorFrom, "btnHueColorFrom")
        Me.btnHueColorFrom.Name = "btnHueColorFrom"
        Me.btnHueColorFrom.UseVisualStyleBackColor = True
        '
        'lblHueColorFrom
        '
        resources.ApplyResources(Me.lblHueColorFrom, "lblHueColorFrom")
        Me.lblHueColorFrom.Name = "lblHueColorFrom"
        '
        'txtHueAltFrom
        '
        resources.ApplyResources(Me.txtHueAltFrom, "txtHueAltFrom")
        Me.txtHueAltFrom.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtHueAltFrom.Minimum = New Decimal(New Integer() {14999, 0, 0, -2147483648})
        Me.txtHueAltFrom.Name = "txtHueAltFrom"
        Me.txtHueAltFrom.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtHueAltTo
        '
        resources.ApplyResources(Me.txtHueAltTo, "txtHueAltTo")
        Me.txtHueAltTo.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.txtHueAltTo.Minimum = New Decimal(New Integer() {14999, 0, 0, -2147483648})
        Me.txtHueAltTo.Name = "txtHueAltTo"
        Me.txtHueAltTo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'picHue
        '
        Me.picHue.Controls.Add(Me.btnHueRange)
        Me.picHue.Controls.Add(Me.chkHueCounterclockwise)
        Me.picHue.Controls.Add(Me.txtHueAltTo)
        Me.picHue.Controls.Add(Me.txtHueAltFrom)
        Me.picHue.Controls.Add(Me.btnHueColorFrom)
        Me.picHue.Controls.Add(Me.lblHueColorFrom)
        Me.picHue.Controls.Add(Me.picHueColorFrom)
        Me.picHue.Controls.Add(Me.picHueColorTo)
        Me.picHue.Controls.Add(Me.lblHueColorTo)
        Me.picHue.Controls.Add(Me.btnHueColorTo)
        resources.ApplyResources(Me.picHue, "picHue")
        Me.picHue.Name = "picHue"
        '
        'chkHueCounterclockwise
        '
        resources.ApplyResources(Me.chkHueCounterclockwise, "chkHueCounterclockwise")
        Me.chkHueCounterclockwise.Name = "chkHueCounterclockwise"
        Me.chkHueCounterclockwise.UseVisualStyleBackColor = True
        '
        'lblMode
        '
        resources.ApplyResources(Me.lblMode, "lblMode")
        Me.lblMode.Name = "lblMode"
        '
        'frmSurfaceAddElevationFromOrthoPhoto
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblMode)
        Me.Controls.Add(Me.cboMode)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.picHue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceAddElevationFromOrthoPhoto"
        CType(Me.picHueColorTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picHueColorFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHueAltFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHueAltTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picHue.ResumeLayout(False)
        Me.picHue.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnHueColorTo As System.Windows.Forms.Button
    Friend WithEvents lblHueColorTo As System.Windows.Forms.Label
    Friend WithEvents picHueColorTo As System.Windows.Forms.PictureBox
    Friend WithEvents cboMode As ComboBox
    Friend WithEvents btnHueColorFrom As Button
    Friend WithEvents lblHueColorFrom As Label
    Friend WithEvents picHueColorFrom As PictureBox
    Friend WithEvents txtHueAltFrom As NumericUpDown
    Friend WithEvents txtHueAltTo As NumericUpDown
    Friend WithEvents picHue As Panel
    Friend WithEvents chkHueCounterclockwise As CheckBox
    Friend WithEvents btnHueRange As Button
    Friend WithEvents lblMode As Label
End Class
