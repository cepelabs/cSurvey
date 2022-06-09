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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyProperties))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPlanPosition = New DevExpress.XtraEditors.TextEdit()
        Me.lblPosition = New DevExpress.XtraEditors.LabelControl()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.lblName = New DevExpress.XtraEditors.LabelControl()
        Me.txtProfilePosition = New DevExpress.XtraEditors.TextEdit()
        Me.lblPlanPosition = New DevExpress.XtraEditors.LabelControl()
        Me.lblConnectedTo = New DevExpress.XtraEditors.LabelControl()
        Me.lblProfilePosition = New DevExpress.XtraEditors.LabelControl()
        Me.lblScaleUM = New DevExpress.XtraEditors.LabelControl()
        Me.lblScaleSize = New DevExpress.XtraEditors.LabelControl()
        Me.cmdApply = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdNext = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPrev = New DevExpress.XtraEditors.SimpleButton()
        Me.tknPlan = New DevExpress.XtraEditors.TokenEdit()
        Me.tknProfile = New DevExpress.XtraEditors.TokenEdit()
        Me.pnlNextStations = New DevExpress.XtraEditors.PanelControl()
        Me.pnlScale = New DevExpress.XtraEditors.PanelControl()
        Me.txtScaleSize = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.txtPlanPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProfilePosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tknPlan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tknProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlNextStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNextStations.SuspendLayout()
        CType(Me.pnlScale, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
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
        '
        'cmdPrev
        '
        resources.ApplyResources(Me.cmdPrev, "cmdPrev")
        Me.cmdPrev.ImageOptions.SvgImage = CType(resources.GetObject("cmdPrev.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPrev.ImageOptions.SvgImageSize = New System.Drawing.Size(18, 18)
        Me.cmdPrev.Name = "cmdPrev"
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
        Me.pnlNextStations.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlNextStations.Controls.Add(Me.tknProfile)
        Me.pnlNextStations.Controls.Add(Me.tknPlan)
        Me.pnlNextStations.Controls.Add(Me.lblConnectedTo)
        resources.ApplyResources(Me.pnlNextStations, "pnlNextStations")
        Me.pnlNextStations.Name = "pnlNextStations"
        '
        'pnlScale
        '
        Me.pnlScale.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
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
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtPlanPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.pnlNextStations)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.properties
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyProperties"
        CType(Me.txtPlanPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProfilePosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tknPlan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tknProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlNextStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNextStations.ResumeLayout(False)
        Me.pnlNextStations.PerformLayout()
        CType(Me.pnlScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlScale.ResumeLayout(False)
        Me.pnlScale.PerformLayout()
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPlanPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProfilePosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPlanPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblConnectedTo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblProfilePosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblScaleUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblScaleSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdApply As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdNext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPrev As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tknPlan As DevExpress.XtraEditors.TokenEdit
    Friend WithEvents tknProfile As DevExpress.XtraEditors.TokenEdit
    Friend WithEvents pnlNextStations As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlScale As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtScaleSize As DevExpress.XtraEditors.SpinEdit
End Class
