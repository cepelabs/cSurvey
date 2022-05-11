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
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExportUseCadastralIDInCaveNames = New DevExpress.XtraEditors.CheckEdit()
        Me.txtCaveBordersTransparency = New System.Windows.Forms.NumericUpDown()
        Me.chkExportWaypoint = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExportTrack = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExportCaveBorders = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlCaveBordersTransparency = New System.Windows.Forms.Panel()
        Me.lblCaveBordersTransparency = New System.Windows.Forms.Label()
        Me.chkExportLinkedSurveys = New DevExpress.XtraEditors.CheckEdit()
        Me.linkedSurveys = New cSurveyPC.cLinkedSurveySelectorControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        CType(Me.chkExportUseCadastralIDInCaveNames.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveBordersTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportWaypoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportTrack.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportCaveBorders.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCaveBordersTransparency.SuspendLayout()
        CType(Me.chkExportLinkedSurveys.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'chkExportUseCadastralIDInCaveNames
        '
        resources.ApplyResources(Me.chkExportUseCadastralIDInCaveNames, "chkExportUseCadastralIDInCaveNames")
        Me.chkExportUseCadastralIDInCaveNames.Name = "chkExportUseCadastralIDInCaveNames"
        Me.chkExportUseCadastralIDInCaveNames.Properties.AutoWidth = True
        Me.chkExportUseCadastralIDInCaveNames.Properties.Caption = resources.GetString("chkExportUseCadastralIDInCaveNames.Properties.Caption")
        Me.tipDefault.SetToolTip(Me.chkExportUseCadastralIDInCaveNames, resources.GetString("chkExportUseCadastralIDInCaveNames.ToolTip1"))
        '
        'txtCaveBordersTransparency
        '
        resources.ApplyResources(Me.txtCaveBordersTransparency, "txtCaveBordersTransparency")
        Me.txtCaveBordersTransparency.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtCaveBordersTransparency.Name = "txtCaveBordersTransparency"
        '
        'chkExportWaypoint
        '
        resources.ApplyResources(Me.chkExportWaypoint, "chkExportWaypoint")
        Me.chkExportWaypoint.Name = "chkExportWaypoint"
        Me.chkExportWaypoint.Properties.AutoWidth = True
        Me.chkExportWaypoint.Properties.Caption = resources.GetString("chkExportWaypoint.Properties.Caption")
        '
        'chkExportTrack
        '
        resources.ApplyResources(Me.chkExportTrack, "chkExportTrack")
        Me.chkExportTrack.Name = "chkExportTrack"
        Me.chkExportTrack.Properties.AutoWidth = True
        Me.chkExportTrack.Properties.Caption = resources.GetString("chkExportTrack.Properties.Caption")
        '
        'chkExportCaveBorders
        '
        resources.ApplyResources(Me.chkExportCaveBorders, "chkExportCaveBorders")
        Me.chkExportCaveBorders.Name = "chkExportCaveBorders"
        Me.chkExportCaveBorders.Properties.AutoWidth = True
        Me.chkExportCaveBorders.Properties.Caption = resources.GetString("chkExportCaveBorders.Properties.Caption")
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
        Me.chkExportLinkedSurveys.Name = "chkExportLinkedSurveys"
        Me.chkExportLinkedSurveys.Properties.AutoWidth = True
        Me.chkExportLinkedSurveys.Properties.Caption = resources.GetString("chkExportLinkedSurveys.Properties.Caption")
        '
        'linkedSurveys
        '
        resources.ApplyResources(Me.linkedSurveys, "linkedSurveys")
        Me.linkedSurveys.Name = "linkedSurveys"
        '
        'XtraTabControl1
        '
        resources.ApplyResources(Me.XtraTabControl1, "XtraTabControl1")
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.chkExportUseCadastralIDInCaveNames)
        Me.XtraTabPage1.Controls.Add(Me.chkExportWaypoint)
        Me.XtraTabPage1.Controls.Add(Me.pnlCaveBordersTransparency)
        Me.XtraTabPage1.Controls.Add(Me.chkExportTrack)
        Me.XtraTabPage1.Controls.Add(Me.chkExportLinkedSurveys)
        Me.XtraTabPage1.Controls.Add(Me.chkExportCaveBorders)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        resources.ApplyResources(Me.XtraTabPage1, "XtraTabPage1")
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.linkedSurveys)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        resources.ApplyResources(Me.XtraTabPage2, "XtraTabPage2")
        '
        'frmExportGoogleKML
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmExportGoogleKML.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportGoogleKML"
        CType(Me.chkExportUseCadastralIDInCaveNames.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveBordersTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportWaypoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportTrack.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportCaveBorders.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCaveBordersTransparency.ResumeLayout(False)
        Me.pnlCaveBordersTransparency.PerformLayout()
        CType(Me.chkExportLinkedSurveys.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage1.PerformLayout()
        Me.XtraTabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportWaypoint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportTrack As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportCaveBorders As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportLinkedSurveys As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents linkedSurveys As cLinkedSurveySelectorControl
    Friend WithEvents pnlCaveBordersTransparency As Panel
    Friend WithEvents txtCaveBordersTransparency As NumericUpDown
    Friend WithEvents lblCaveBordersTransparency As Label
    Friend WithEvents chkExportUseCadastralIDInCaveNames As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
End Class
