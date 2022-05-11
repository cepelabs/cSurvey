<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResurveyProperties
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyProperties))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPlanPosition = New DevExpress.XtraEditors.TextEdit()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProfilePosition = New DevExpress.XtraEditors.TextEdit()
        Me.lblPlanPosition = New System.Windows.Forms.Label()
        Me.lblConnectedTo = New System.Windows.Forms.Label()
        Me.lblProfilePosition = New System.Windows.Forms.Label()
        Me.lblScaleUM = New System.Windows.Forms.Label()
        Me.lblScaleSize = New System.Windows.Forms.Label()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.tpDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdNext = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPrev = New DevExpress.XtraEditors.SimpleButton()
        Me.tknPlan = New DevExpress.XtraEditors.TokenEdit()
        Me.tknProfile = New DevExpress.XtraEditors.TokenEdit()
        Me.pnlNextStations = New System.Windows.Forms.Panel()
        Me.pnlScale = New System.Windows.Forms.Panel()
        Me.txtScaleSize = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtPlanPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProfilePosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tknPlan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tknProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNextStations.SuspendLayout()
        Me.pnlScale.SuspendLayout()
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'txtPlanPosition
        '
        resources.ApplyResources(Me.txtPlanPosition, "txtPlanPosition")
        Me.txtPlanPosition.Name = "txtPlanPosition"
        Me.txtPlanPosition.Properties.ReadOnly = True
        '
        'lblPosition
        '
        resources.ApplyResources(Me.lblPosition, "lblPosition")
        Me.lblPosition.Name = "lblPosition"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        Me.txtName.Properties.Appearance.Font = CType(resources.GetObject("txtName.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtName.Properties.Appearance.Options.UseFont = True
        Me.txtName.Properties.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtProfilePosition
        '
        resources.ApplyResources(Me.txtProfilePosition, "txtProfilePosition")
        Me.txtProfilePosition.Name = "txtProfilePosition"
        Me.txtProfilePosition.Properties.ReadOnly = True
        '
        'lblPlanPosition
        '
        resources.ApplyResources(Me.lblPlanPosition, "lblPlanPosition")
        Me.lblPlanPosition.Name = "lblPlanPosition"
        '
        'lblConnectedTo
        '
        resources.ApplyResources(Me.lblConnectedTo, "lblConnectedTo")
        Me.lblConnectedTo.Name = "lblConnectedTo"
        '
        'lblProfilePosition
        '
        resources.ApplyResources(Me.lblProfilePosition, "lblProfilePosition")
        Me.lblProfilePosition.Name = "lblProfilePosition"
        '
        'lblScaleUM
        '
        resources.ApplyResources(Me.lblScaleUM, "lblScaleUM")
        Me.lblScaleUM.Name = "lblScaleUM"
        '
        'lblScaleSize
        '
        resources.ApplyResources(Me.lblScaleSize, "lblScaleSize")
        Me.lblScaleSize.Name = "lblScaleSize"
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        '
        'cmdNext
        '
        resources.ApplyResources(Me.cmdNext, "cmdNext")
        Me.cmdNext.ImageOptions.SvgImage = CType(resources.GetObject("cmdNext.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdNext.ImageOptions.SvgImageSize = New System.Drawing.Size(18, 18)
        Me.cmdNext.Name = "cmdNext"
        Me.tpDefault.SetToolTip(Me.cmdNext, resources.GetString("cmdNext.ToolTip1"))
        '
        'cmdPrev
        '
        resources.ApplyResources(Me.cmdPrev, "cmdPrev")
        Me.cmdPrev.ImageOptions.SvgImage = CType(resources.GetObject("cmdPrev.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPrev.ImageOptions.SvgImageSize = New System.Drawing.Size(18, 18)
        Me.cmdPrev.Name = "cmdPrev"
        Me.tpDefault.SetToolTip(Me.cmdPrev, resources.GetString("cmdPrev.ToolTip1"))
        '
        'tknPlan
        '
        resources.ApplyResources(Me.tknPlan, "tknPlan")
        Me.tknPlan.Name = "tknPlan"
        Me.tknPlan.Properties.AutoHeightMode = DevExpress.XtraEditors.TokenEditAutoHeightMode.RestrictedExpand
        Me.tknPlan.Properties.MaxExpandLines = 2
        Me.tknPlan.Properties.Separators.AddRange(New String() {","})
        '
        'tknProfile
        '
        resources.ApplyResources(Me.tknProfile, "tknProfile")
        Me.tknProfile.Name = "tknProfile"
        Me.tknProfile.Properties.AutoHeightMode = DevExpress.XtraEditors.TokenEditAutoHeightMode.Expand
        Me.tknProfile.Properties.MaxExpandLines = 2
        Me.tknProfile.Properties.Separators.AddRange(New String() {","})
        '
        'pnlNextStations
        '
        Me.pnlNextStations.Controls.Add(Me.tknProfile)
        Me.pnlNextStations.Controls.Add(Me.tknPlan)
        Me.pnlNextStations.Controls.Add(Me.lblConnectedTo)
        resources.ApplyResources(Me.pnlNextStations, "pnlNextStations")
        Me.pnlNextStations.Name = "pnlNextStations"
        '
        'pnlScale
        '
        Me.pnlScale.Controls.Add(Me.txtScaleSize)
        Me.pnlScale.Controls.Add(Me.lblScaleUM)
        Me.pnlScale.Controls.Add(Me.lblScaleSize)
        resources.ApplyResources(Me.pnlScale, "pnlScale")
        Me.pnlScale.Name = "pnlScale"
        '
        'txtScaleSize
        '
        resources.ApplyResources(Me.txtScaleSize, "txtScaleSize")
        Me.txtScaleSize.Name = "txtScaleSize"
        Me.txtScaleSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleSize.Properties.DisplayFormat.FormatString = "N2"
        Me.txtScaleSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleSize.Properties.EditFormat.FormatString = "N2"
        Me.txtScaleSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleSize.Properties.Mask.EditMask = resources.GetString("txtScaleSize.Properties.Mask.EditMask")
        '
        'frmResurveyProperties
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.pnlScale)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.lblProfilePosition)
        Me.Controls.Add(Me.txtProfilePosition)
        Me.Controls.Add(Me.lblPlanPosition)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPlanPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.pnlNextStations)
        Me.IconOptions.Icon = CType(resources.GetObject("frmResurveyProperties.IconOptions.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyProperties"
        CType(Me.txtPlanPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProfilePosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tknPlan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tknProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNextStations.ResumeLayout(False)
        Me.pnlNextStations.PerformLayout()
        Me.pnlScale.ResumeLayout(False)
        Me.pnlScale.PerformLayout()
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPlanPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProfilePosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPlanPosition As System.Windows.Forms.Label
    Friend WithEvents lblConnectedTo As System.Windows.Forms.Label
    Friend WithEvents lblProfilePosition As System.Windows.Forms.Label
    Friend WithEvents lblScaleUM As System.Windows.Forms.Label
    Friend WithEvents lblScaleSize As System.Windows.Forms.Label
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tpDefault As System.Windows.Forms.ToolTip
    Friend WithEvents cmdNext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPrev As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tknPlan As DevExpress.XtraEditors.TokenEdit
    Friend WithEvents tknProfile As DevExpress.XtraEditors.TokenEdit
    Friend WithEvents pnlNextStations As Panel
    Friend WithEvents pnlScale As Panel
    Friend WithEvents txtScaleSize As DevExpress.XtraEditors.SpinEdit
End Class
