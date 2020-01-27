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
        Me.txtCaveBordersTransparency = New System.Windows.Forms.NumericUpDown()
        Me.chkExportUseCadastralIDInCaveNames = New System.Windows.Forms.CheckBox()
        Me.chkExportWaypoint = New System.Windows.Forms.CheckBox()
        Me.chkExportTrack = New System.Windows.Forms.CheckBox()
        Me.chkExportCaveBorders = New System.Windows.Forms.CheckBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlCaveBordersTransparency = New System.Windows.Forms.Panel()
        Me.lblCaveBordersTransparency = New System.Windows.Forms.Label()
        Me.chkExportLinkedSurveys = New System.Windows.Forms.CheckBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.linkedSurveys = New cSurveyPC.cLinkedSurveySelectorControl()
        CType(Me.txtCaveBordersTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnlCaveBordersTransparency.SuspendLayout()
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
        'txtCaveBordersTransparency
        '
        resources.ApplyResources(Me.txtCaveBordersTransparency, "txtCaveBordersTransparency")
        Me.txtCaveBordersTransparency.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtCaveBordersTransparency.Name = "txtCaveBordersTransparency"
        '
        'chkExportUseCadastralIDInCaveNames
        '
        resources.ApplyResources(Me.chkExportUseCadastralIDInCaveNames, "chkExportUseCadastralIDInCaveNames")
        Me.chkExportUseCadastralIDInCaveNames.Name = "chkExportUseCadastralIDInCaveNames"
        Me.tipDefault.SetToolTip(Me.chkExportUseCadastralIDInCaveNames, resources.GetString("chkExportUseCadastralIDInCaveNames.ToolTip"))
        Me.chkExportUseCadastralIDInCaveNames.UseVisualStyleBackColor = True
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
        Me.TabPage1.Controls.Add(Me.chkExportUseCadastralIDInCaveNames)
        Me.TabPage1.Controls.Add(Me.pnlCaveBordersTransparency)
        Me.TabPage1.Controls.Add(Me.chkExportLinkedSurveys)
        Me.TabPage1.Controls.Add(Me.chkExportWaypoint)
        Me.TabPage1.Controls.Add(Me.chkExportCaveBorders)
        Me.TabPage1.Controls.Add(Me.chkExportTrack)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'pnlCaveBordersTransparency
        '
        Me.pnlCaveBordersTransparency.Controls.Add(Me.txtCaveBordersTransparency)
        Me.pnlCaveBordersTransparency.Controls.Add(Me.lblCaveBordersTransparency)
        resources.ApplyResources(Me.pnlCaveBordersTransparency, "pnlCaveBordersTransparency")
        Me.pnlCaveBordersTransparency.Name = "pnlCaveBordersTransparency"
        '
        'lblCaveBordersTransparency
        '
        resources.ApplyResources(Me.lblCaveBordersTransparency, "lblCaveBordersTransparency")
        Me.lblCaveBordersTransparency.Name = "lblCaveBordersTransparency"
        '
        'chkExportLinkedSurveys
        '
        resources.ApplyResources(Me.chkExportLinkedSurveys, "chkExportLinkedSurveys")
        Me.chkExportLinkedSurveys.Checked = True
        Me.chkExportLinkedSurveys.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExportLinkedSurveys.Name = "chkExportLinkedSurveys"
        Me.chkExportLinkedSurveys.UseVisualStyleBackColor = True
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
        'frmExportGoogleKML
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportGoogleKML"
        CType(Me.txtCaveBordersTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.pnlCaveBordersTransparency.ResumeLayout(False)
        Me.pnlCaveBordersTransparency.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportWaypoint As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportTrack As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportCaveBorders As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents chkExportLinkedSurveys As CheckBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents linkedSurveys As cLinkedSurveySelectorControl
    Friend WithEvents pnlCaveBordersTransparency As Panel
    Friend WithEvents txtCaveBordersTransparency As NumericUpDown
    Friend WithEvents lblCaveBordersTransparency As Label
    Friend WithEvents chkExportUseCadastralIDInCaveNames As CheckBox
End Class
