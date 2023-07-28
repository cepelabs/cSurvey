<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSegmentsReplicateInfo
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSegmentsReplicateInfo))
        Me.chkCave = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.chkSession = New DevExpress.XtraEditors.CheckEdit()
        Me.chkRebind = New DevExpress.XtraEditors.CheckEdit()
        Me.chkFormula = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdEditFormula = New DevExpress.XtraEditors.SimpleButton()
        Me.cboReplicateTo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.Panel1 = New DevExpress.XtraEditors.PanelControl()
        Me.chkDirection = New DevExpress.XtraEditors.CheckEdit()
        Me.svgImages = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.cboDirection = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.cboSessionList = New cSurveyPC.cSessionDropDown()
        Me.cboCaveList = New cSurveyPC.cCaveDropDown()
        Me.cboCaveBranchList = New cSurveyPC.cCaveBranchDropDown()
        Me.cmdEditOtherProperties = New DevExpress.XtraEditors.SimpleButton()
        Me.chkOtherProperties = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkCave.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSession.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRebind.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkFormula.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.chkDirection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.svgImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDirection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOtherProperties.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkCave
        '
        resources.ApplyResources(Me.chkCave, "chkCave")
        Me.chkCave.Name = "chkCave"
        Me.chkCave.Properties.AutoWidth = True
        Me.chkCave.Properties.Caption = resources.GetString("chkCave.Properties.Caption")
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
        'chkSession
        '
        resources.ApplyResources(Me.chkSession, "chkSession")
        Me.chkSession.Name = "chkSession"
        Me.chkSession.Properties.AutoWidth = True
        Me.chkSession.Properties.Caption = resources.GetString("chkSession.Properties.Caption")
        '
        'chkRebind
        '
        resources.ApplyResources(Me.chkRebind, "chkRebind")
        Me.chkRebind.Name = "chkRebind"
        Me.chkRebind.Properties.AutoWidth = True
        Me.chkRebind.Properties.Caption = resources.GetString("chkRebind.Properties.Caption")
        '
        'chkFormula
        '
        resources.ApplyResources(Me.chkFormula, "chkFormula")
        Me.chkFormula.Name = "chkFormula"
        Me.chkFormula.Properties.AutoWidth = True
        Me.chkFormula.Properties.Caption = resources.GetString("chkFormula.Properties.Caption")
        '
        'cmdEditFormula
        '
        Me.cmdEditFormula.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdEditFormula.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.script2
        Me.cmdEditFormula.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdEditFormula, "cmdEditFormula")
        Me.cmdEditFormula.Name = "cmdEditFormula"
        '
        'cboReplicateTo
        '
        resources.ApplyResources(Me.cboReplicateTo, "cboReplicateTo")
        Me.cboReplicateTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReplicateTo.FormattingEnabled = True
        Me.cboReplicateTo.Items.AddRange(New Object() {resources.GetString("cboReplicateTo.Items"), resources.GetString("cboReplicateTo.Items1"), resources.GetString("cboReplicateTo.Items2"), resources.GetString("cboReplicateTo.Items3")})
        Me.cboReplicateTo.Name = "cboReplicateTo"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Appearance.Options.UseBackColor = True
        Me.Label2.Name = "Label2"
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Panel1.Controls.Add(Me.cboReplicateTo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Name = "Panel1"
        '
        'chkDirection
        '
        resources.ApplyResources(Me.chkDirection, "chkDirection")
        Me.chkDirection.Name = "chkDirection"
        Me.chkDirection.Properties.AutoWidth = True
        Me.chkDirection.Properties.Caption = resources.GetString("chkDirection.Properties.Caption")
        '
        'svgImages
        '
        Me.svgImages.Add("station", CType(resources.GetObject("svgImages.station"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("prioritized", "prioritized", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("caveentrance", "caveentrance", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("outside", CType(resources.GetObject("svgImages.outside"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("bo_localization", "bo_localization", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("Actions_Question", "Actions_Question", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("note", CType(resources.GetObject("svgImages.note"), DevExpress.Utils.Svg.SvgImage))
        Me.svgImages.Add("attachment", "image://svgimages/pdf viewer/attachments.svg")
        Me.svgImages.Add("error2", "error2", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("Security_Lock", "Security_Lock", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("directionleft", "directionleft", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("directionright", "directionright", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("directionvertical", "directionvertical", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("security_visibility", "security_visibility", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("security_visibilityoff", "security_visibilityoff", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgImages.Add("levelup", "levelup", GetType(cSurveyPC.My.Resources.Resources))
        '
        'cboDirection
        '
        resources.ApplyResources(Me.cboDirection, "cboDirection")
        Me.cboDirection.Name = "cboDirection"
        Me.cboDirection.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDirection.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDirection.Properties.SmallImages = Me.svgImages
        '
        'cboSessionList
        '
        resources.ApplyResources(Me.cboSessionList, "cboSessionList")
        Me.cboSessionList.EditValue = Nothing
        Me.cboSessionList.Name = "cboSessionList"
        '
        'cboCaveList
        '
        resources.ApplyResources(Me.cboCaveList, "cboCaveList")
        Me.cboCaveList.EditValue = Nothing
        Me.cboCaveList.Name = "cboCaveList"
        Me.cboCaveList.Workmode = cSurveyPC.cCaveDropDown.WorkmodeEnum.View
        '
        'cboCaveBranchList
        '
        resources.ApplyResources(Me.cboCaveBranchList, "cboCaveBranchList")
        Me.cboCaveBranchList.EditValue = Nothing
        Me.cboCaveBranchList.Name = "cboCaveBranchList"
        Me.cboCaveBranchList.Workmode = cSurveyPC.cCaveDropDown.WorkmodeEnum.View
        '
        'cmdEditOtherProperties
        '
        Me.cmdEditOtherProperties.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdEditOtherProperties.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.cmdEditOtherProperties.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdEditOtherProperties, "cmdEditOtherProperties")
        Me.cmdEditOtherProperties.Name = "cmdEditOtherProperties"
        '
        'chkOtherProperties
        '
        resources.ApplyResources(Me.chkOtherProperties, "chkOtherProperties")
        Me.chkOtherProperties.Name = "chkOtherProperties"
        Me.chkOtherProperties.Properties.AutoWidth = True
        Me.chkOtherProperties.Properties.Caption = resources.GetString("CheckEdit1.Properties.Caption")
        '
        'frmSegmentsReplicateInfo
        '
        Me.AcceptButton = Me.cmdOk
        Me.Appearance.Options.UseFont = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkOtherProperties)
        Me.Controls.Add(Me.cmdEditOtherProperties)
        Me.Controls.Add(Me.chkDirection)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdEditFormula)
        Me.Controls.Add(Me.chkFormula)
        Me.Controls.Add(Me.chkRebind)
        Me.Controls.Add(Me.chkSession)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkCave)
        Me.Controls.Add(Me.cboDirection)
        Me.Controls.Add(Me.cboCaveBranchList)
        Me.Controls.Add(Me.cboCaveList)
        Me.Controls.Add(Me.cboSessionList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.Action_Copy_CellValue
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSegmentsReplicateInfo"
        CType(Me.chkCave.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSession.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRebind.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkFormula.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.chkDirection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.svgImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDirection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOtherProperties.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkCave As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkSession As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkRebind As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkFormula As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdEditFormula As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboReplicateTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Panel1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkDirection As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents svgImages As DevExpress.Utils.SvgImageCollection
    Friend WithEvents cboDirection As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents cboSessionList As cSessionDropDown
    Friend WithEvents cboCaveList As cCaveDropDown
    Friend WithEvents cboCaveBranchList As cCaveBranchDropDown
    Friend WithEvents cmdEditOtherProperties As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkOtherProperties As DevExpress.XtraEditors.CheckEdit
End Class
