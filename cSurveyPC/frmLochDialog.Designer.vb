<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLochDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLochDialog))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblElevationData = New System.Windows.Forms.Label()
        Me.cboElevationData = New System.Windows.Forms.ComboBox()
        Me.cboOrthophoto = New System.Windows.Forms.ComboBox()
        Me.lblOrthophoto = New System.Windows.Forms.Label()
        Me.chkDoNotShow = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.linkedSurveys = New cSurveyPC.cLinkedSurveySelectorControl()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
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
        'lblElevationData
        '
        resources.ApplyResources(Me.lblElevationData, "lblElevationData")
        Me.lblElevationData.Name = "lblElevationData"
        '
        'cboElevationData
        '
        resources.ApplyResources(Me.cboElevationData, "cboElevationData")
        Me.cboElevationData.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboElevationData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboElevationData.DropDownWidth = 320
        Me.cboElevationData.FormattingEnabled = True
        Me.cboElevationData.Name = "cboElevationData"
        '
        'cboOrthophoto
        '
        resources.ApplyResources(Me.cboOrthophoto, "cboOrthophoto")
        Me.cboOrthophoto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboOrthophoto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrthophoto.DropDownWidth = 320
        Me.cboOrthophoto.FormattingEnabled = True
        Me.cboOrthophoto.Name = "cboOrthophoto"
        '
        'lblOrthophoto
        '
        resources.ApplyResources(Me.lblOrthophoto, "lblOrthophoto")
        Me.lblOrthophoto.Name = "lblOrthophoto"
        '
        'chkDoNotShow
        '
        resources.ApplyResources(Me.chkDoNotShow, "chkDoNotShow")
        Me.chkDoNotShow.Name = "chkDoNotShow"
        Me.chkDoNotShow.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'lblDescription
        '
        resources.ApplyResources(Me.lblDescription, "lblDescription")
        Me.lblDescription.Name = "lblDescription"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cboElevationData)
        Me.TabPage1.Controls.Add(Me.lblElevationData)
        Me.TabPage1.Controls.Add(Me.lblOrthophoto)
        Me.TabPage1.Controls.Add(Me.cboOrthophoto)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.linkedSurveys)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'linkedSurveys
        '
        resources.ApplyResources(Me.linkedSurveys, "linkedSurveys")
        Me.linkedSurveys.Name = "linkedSurveys"
        '
        'frmLochDialog
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.chkDoNotShow)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLochDialog"
        Me.SaveAndRestoreSettings = True
        Me.ShowInTaskbar = False
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblElevationData As System.Windows.Forms.Label
    Friend WithEvents cboElevationData As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrthophoto As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrthophoto As System.Windows.Forms.Label
    Friend WithEvents chkDoNotShow As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents linkedSurveys As cLinkedSurveySelectorControl
End Class
