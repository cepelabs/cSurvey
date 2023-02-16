<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportcSurvey
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportcSurvey))
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New DevExpress.XtraEditors.GroupControl()
        Me.tvLog = New DevExpress.XtraTreeList.TreeList()
        Me.tvLogText = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tvLogImageName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.svgiml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.chkcSurveyImportScaleRules = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportDesignProperties = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportSurface = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportProfile = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportPlan = New DevExpress.XtraEditors.CheckEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.chkcSurveyImportData = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportGraphics = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportCaveBranchFromDesign = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportDuplicates = New DevExpress.XtraEditors.CheckEdit()
        Me.cbocSurveyImportDuplicatesMode = New System.Windows.Forms.ComboBox()
        Me.lblcSurveyImportDuplicatesMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkcSurveyImportDuplicatesOverwrite = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportDuplicatesStations = New DevExpress.XtraEditors.CheckEdit()
        Me.chkImportAsBranchOf = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportUpdateCaveBranchPriority = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportCreateNewBranch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed = New DevExpress.XtraEditors.CheckEdit()
        Me.chkcSurveyDisableOriginAsExtendstart = New DevExpress.XtraEditors.CheckEdit()
        Me.lblcSurveyImportWarpingMode = New DevExpress.XtraEditors.LabelControl()
        Me.cbocSurveyImportWarpingMode = New System.Windows.Forms.ComboBox()
        Me.chkcsurveyimportlinkedsurvey = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlcSurveyImportData = New DevExpress.XtraEditors.PanelControl()
        Me.pnlcSurveyImportGraphics = New DevExpress.XtraEditors.PanelControl()
        Me.chkcSurveyImportTexts = New DevExpress.XtraEditors.CheckEdit()
        Me.cboImportAsBranchOfCave = New cSurveyPC.cCaveDropDown()
        Me.cboImportAsBranchOfBranch = New cSurveyPC.cCaveBranchDropDown()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.svgiml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportScaleRules.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportDesignProperties.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportSurface.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportPlan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportGraphics.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportCaveBranchFromDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportDuplicates.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportDuplicatesOverwrite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportDuplicatesStations.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImportAsBranchOf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportUpdateCaveBranchPriority.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportCreateNewBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyDisableOriginAsExtendstart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcsurveyimportlinkedsurvey.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlcSurveyImportData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlcSurveyImportData.SuspendLayout()
        CType(Me.pnlcSurveyImportGraphics, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlcSurveyImportGraphics.SuspendLayout()
        CType(Me.chkcSurveyImportTexts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Properties.ReadOnly = True
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
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.tvLog)
        Me.GroupBox1.Name = "GroupBox1"
        '
        'tvLog
        '
        resources.ApplyResources(Me.tvLog, "tvLog")
        Me.tvLog.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.tvLogText, Me.tvLogImageName})
        Me.tvLog.Name = "tvLog"
        Me.tvLog.OptionsBehavior.Editable = False
        Me.tvLog.OptionsBehavior.ReadOnly = True
        Me.tvLog.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.tvLog.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvLog.OptionsView.ShowColumns = False
        Me.tvLog.OptionsView.ShowHorzLines = False
        Me.tvLog.OptionsView.ShowIndentAsRowStyle = True
        Me.tvLog.OptionsView.ShowIndicator = False
        Me.tvLog.OptionsView.ShowRoot = False
        Me.tvLog.OptionsView.ShowVertLines = False
        Me.tvLog.SelectImageList = Me.svgiml
        '
        'tvLogText
        '
        resources.ApplyResources(Me.tvLogText, "tvLogText")
        Me.tvLogText.FieldName = "Text"
        Me.tvLogText.Name = "tvLogText"
        '
        'tvLogImageName
        '
        resources.ApplyResources(Me.tvLogImageName, "tvLogImageName")
        Me.tvLogImageName.FieldName = "ImageName"
        Me.tvLogImageName.Name = "tvLogImageName"
        '
        'svgiml
        '
        Me.svgiml.Add("actions_checkcircled", "actions_checkcircled", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgiml.Add("warning", "warning", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgiml.Add("actions_deletecircled", "actions_deletecircled", GetType(cSurveyPC.My.Resources.Resources))
        Me.svgiml.Add("actions_database", "actions_database", GetType(cSurveyPC.My.Resources.Resources))
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "ok")
        Me.iml.Images.SetKeyName(1, "warning")
        Me.iml.Images.SetKeyName(2, "error")
        Me.iml.Images.SetKeyName(3, "topodroid")
        '
        'chkcSurveyImportScaleRules
        '
        resources.ApplyResources(Me.chkcSurveyImportScaleRules, "chkcSurveyImportScaleRules")
        Me.chkcSurveyImportScaleRules.Name = "chkcSurveyImportScaleRules"
        Me.chkcSurveyImportScaleRules.Properties.AutoWidth = True
        Me.chkcSurveyImportScaleRules.Properties.Caption = resources.GetString("chkcSurveyImportScaleRules.Properties.Caption")
        '
        'chkcSurveyImportDesignProperties
        '
        resources.ApplyResources(Me.chkcSurveyImportDesignProperties, "chkcSurveyImportDesignProperties")
        Me.chkcSurveyImportDesignProperties.Name = "chkcSurveyImportDesignProperties"
        Me.chkcSurveyImportDesignProperties.Properties.AutoWidth = True
        Me.chkcSurveyImportDesignProperties.Properties.Caption = resources.GetString("chkcSurveyImportDesignProperties.Properties.Caption")
        '
        'chkcSurveyImportSurface
        '
        resources.ApplyResources(Me.chkcSurveyImportSurface, "chkcSurveyImportSurface")
        Me.chkcSurveyImportSurface.Name = "chkcSurveyImportSurface"
        Me.chkcSurveyImportSurface.Properties.AutoWidth = True
        Me.chkcSurveyImportSurface.Properties.Caption = resources.GetString("chkcSurveyImportSurface.Properties.Caption")
        '
        'chkcSurveyImportProfile
        '
        resources.ApplyResources(Me.chkcSurveyImportProfile, "chkcSurveyImportProfile")
        Me.chkcSurveyImportProfile.Name = "chkcSurveyImportProfile"
        Me.chkcSurveyImportProfile.Properties.AutoWidth = True
        Me.chkcSurveyImportProfile.Properties.Caption = resources.GetString("chkcSurveyImportProfile.Properties.Caption")
        '
        'chkcSurveyImportPlan
        '
        resources.ApplyResources(Me.chkcSurveyImportPlan, "chkcSurveyImportPlan")
        Me.chkcSurveyImportPlan.Name = "chkcSurveyImportPlan"
        Me.chkcSurveyImportPlan.Properties.AutoWidth = True
        Me.chkcSurveyImportPlan.Properties.Caption = resources.GetString("chkcSurveyImportPlan.Properties.Caption")
        '
        'lblFilename
        '
        Me.lblFilename.Appearance.Font = CType(resources.GetObject("lblFilename.Appearance.Font"), System.Drawing.Font)
        Me.lblFilename.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'chkcSurveyImportData
        '
        resources.ApplyResources(Me.chkcSurveyImportData, "chkcSurveyImportData")
        Me.chkcSurveyImportData.Name = "chkcSurveyImportData"
        Me.chkcSurveyImportData.Properties.AutoWidth = True
        Me.chkcSurveyImportData.Properties.Caption = resources.GetString("chkcSurveyImportData.Properties.Caption")
        '
        'chkcSurveyImportGraphics
        '
        resources.ApplyResources(Me.chkcSurveyImportGraphics, "chkcSurveyImportGraphics")
        Me.chkcSurveyImportGraphics.Name = "chkcSurveyImportGraphics"
        Me.chkcSurveyImportGraphics.Properties.AutoWidth = True
        Me.chkcSurveyImportGraphics.Properties.Caption = resources.GetString("chkcSurveyImportGraphics.Properties.Caption")
        '
        'chkcSurveyImportCaveBranchFromDesign
        '
        resources.ApplyResources(Me.chkcSurveyImportCaveBranchFromDesign, "chkcSurveyImportCaveBranchFromDesign")
        Me.chkcSurveyImportCaveBranchFromDesign.Name = "chkcSurveyImportCaveBranchFromDesign"
        Me.chkcSurveyImportCaveBranchFromDesign.Properties.AutoWidth = True
        Me.chkcSurveyImportCaveBranchFromDesign.Properties.Caption = resources.GetString("chkcSurveyImportCaveBranchFromDesign.Properties.Caption")
        '
        'chkcSurveyImportDuplicates
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicates, "chkcSurveyImportDuplicates")
        Me.chkcSurveyImportDuplicates.Name = "chkcSurveyImportDuplicates"
        Me.chkcSurveyImportDuplicates.Properties.AutoWidth = True
        Me.chkcSurveyImportDuplicates.Properties.Caption = resources.GetString("chkcSurveyImportDuplicates.Properties.Caption")
        '
        'cbocSurveyImportDuplicatesMode
        '
        Me.cbocSurveyImportDuplicatesMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocSurveyImportDuplicatesMode.DropDownWidth = 320
        Me.cbocSurveyImportDuplicatesMode.FormattingEnabled = True
        Me.cbocSurveyImportDuplicatesMode.Items.AddRange(New Object() {resources.GetString("cbocSurveyImportDuplicatesMode.Items"), resources.GetString("cbocSurveyImportDuplicatesMode.Items1")})
        resources.ApplyResources(Me.cbocSurveyImportDuplicatesMode, "cbocSurveyImportDuplicatesMode")
        Me.cbocSurveyImportDuplicatesMode.Name = "cbocSurveyImportDuplicatesMode"
        '
        'lblcSurveyImportDuplicatesMode
        '
        resources.ApplyResources(Me.lblcSurveyImportDuplicatesMode, "lblcSurveyImportDuplicatesMode")
        Me.lblcSurveyImportDuplicatesMode.Name = "lblcSurveyImportDuplicatesMode"
        '
        'chkcSurveyImportDuplicatesOverwrite
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesOverwrite, "chkcSurveyImportDuplicatesOverwrite")
        Me.chkcSurveyImportDuplicatesOverwrite.Name = "chkcSurveyImportDuplicatesOverwrite"
        Me.chkcSurveyImportDuplicatesOverwrite.Properties.AutoWidth = True
        Me.chkcSurveyImportDuplicatesOverwrite.Properties.Caption = resources.GetString("chkcSurveyImportDuplicatesOverwrite.Properties.Caption")
        '
        'chkcSurveyImportDuplicatesStations
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesStations, "chkcSurveyImportDuplicatesStations")
        Me.chkcSurveyImportDuplicatesStations.Name = "chkcSurveyImportDuplicatesStations"
        Me.chkcSurveyImportDuplicatesStations.Properties.AutoWidth = True
        Me.chkcSurveyImportDuplicatesStations.Properties.Caption = resources.GetString("chkcSurveyImportDuplicatesStations.Properties.Caption")
        '
        'chkImportAsBranchOf
        '
        resources.ApplyResources(Me.chkImportAsBranchOf, "chkImportAsBranchOf")
        Me.chkImportAsBranchOf.Name = "chkImportAsBranchOf"
        Me.chkImportAsBranchOf.Properties.Caption = resources.GetString("chkImportAsBranchOf.Properties.Caption")
        '
        'chkcSurveyImportUpdateCaveBranchPriority
        '
        resources.ApplyResources(Me.chkcSurveyImportUpdateCaveBranchPriority, "chkcSurveyImportUpdateCaveBranchPriority")
        Me.chkcSurveyImportUpdateCaveBranchPriority.Name = "chkcSurveyImportUpdateCaveBranchPriority"
        Me.chkcSurveyImportUpdateCaveBranchPriority.Properties.AutoWidth = True
        Me.chkcSurveyImportUpdateCaveBranchPriority.Properties.Caption = resources.GetString("chkcSurveyImportUpdateCaveBranchPriority.Properties.Caption")
        '
        'chkcSurveyImportCreateNewBranch
        '
        resources.ApplyResources(Me.chkcSurveyImportCreateNewBranch, "chkcSurveyImportCreateNewBranch")
        Me.chkcSurveyImportCreateNewBranch.Name = "chkcSurveyImportCreateNewBranch"
        Me.chkcSurveyImportCreateNewBranch.Properties.AutoWidth = True
        Me.chkcSurveyImportCreateNewBranch.Properties.Caption = resources.GetString("chkcSurveyImportCreateNewBranch.Properties.Caption")
        '
        'chkcSurveyImportDuplicatesOverwriteOnlyUsed
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed, "chkcSurveyImportDuplicatesOverwriteOnlyUsed")
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Name = "chkcSurveyImportDuplicatesOverwriteOnlyUsed"
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Properties.AutoWidth = True
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Properties.Caption = resources.GetString("chkcSurveyImportDuplicatesOverwriteOnlyUsed.Properties.Caption")
        '
        'chkcSurveyDisableOriginAsExtendstart
        '
        resources.ApplyResources(Me.chkcSurveyDisableOriginAsExtendstart, "chkcSurveyDisableOriginAsExtendstart")
        Me.chkcSurveyDisableOriginAsExtendstart.Name = "chkcSurveyDisableOriginAsExtendstart"
        Me.chkcSurveyDisableOriginAsExtendstart.Properties.AutoWidth = True
        Me.chkcSurveyDisableOriginAsExtendstart.Properties.Caption = resources.GetString("chkcSurveyDisableOriginAsExtendstart.Properties.Caption")
        '
        'lblcSurveyImportWarpingMode
        '
        resources.ApplyResources(Me.lblcSurveyImportWarpingMode, "lblcSurveyImportWarpingMode")
        Me.lblcSurveyImportWarpingMode.Name = "lblcSurveyImportWarpingMode"
        '
        'cbocSurveyImportWarpingMode
        '
        Me.cbocSurveyImportWarpingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocSurveyImportWarpingMode.DropDownWidth = 320
        resources.ApplyResources(Me.cbocSurveyImportWarpingMode, "cbocSurveyImportWarpingMode")
        Me.cbocSurveyImportWarpingMode.FormattingEnabled = True
        Me.cbocSurveyImportWarpingMode.Items.AddRange(New Object() {resources.GetString("cbocSurveyImportWarpingMode.Items"), resources.GetString("cbocSurveyImportWarpingMode.Items1"), resources.GetString("cbocSurveyImportWarpingMode.Items2")})
        Me.cbocSurveyImportWarpingMode.Name = "cbocSurveyImportWarpingMode"
        '
        'chkcsurveyimportlinkedsurvey
        '
        resources.ApplyResources(Me.chkcsurveyimportlinkedsurvey, "chkcsurveyimportlinkedsurvey")
        Me.chkcsurveyimportlinkedsurvey.Name = "chkcsurveyimportlinkedsurvey"
        Me.chkcsurveyimportlinkedsurvey.Properties.AutoWidth = True
        Me.chkcsurveyimportlinkedsurvey.Properties.Caption = resources.GetString("chkcsurveyimportlinkedsurvey.Properties.Caption")
        '
        'pnlcSurveyImportData
        '
        Me.pnlcSurveyImportData.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed)
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicatesOverwrite)
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicates)
        Me.pnlcSurveyImportData.Controls.Add(Me.cbocSurveyImportDuplicatesMode)
        Me.pnlcSurveyImportData.Controls.Add(Me.lblcSurveyImportDuplicatesMode)
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicatesStations)
        resources.ApplyResources(Me.pnlcSurveyImportData, "pnlcSurveyImportData")
        Me.pnlcSurveyImportData.Name = "pnlcSurveyImportData"
        '
        'pnlcSurveyImportGraphics
        '
        Me.pnlcSurveyImportGraphics.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.chkcSurveyImportPlan)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.lblcSurveyImportWarpingMode)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.chkcSurveyImportCaveBranchFromDesign)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.cbocSurveyImportWarpingMode)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.chkcSurveyImportProfile)
        resources.ApplyResources(Me.pnlcSurveyImportGraphics, "pnlcSurveyImportGraphics")
        Me.pnlcSurveyImportGraphics.Name = "pnlcSurveyImportGraphics"
        '
        'chkcSurveyImportTexts
        '
        resources.ApplyResources(Me.chkcSurveyImportTexts, "chkcSurveyImportTexts")
        Me.chkcSurveyImportTexts.Name = "chkcSurveyImportTexts"
        Me.chkcSurveyImportTexts.Properties.AutoWidth = True
        Me.chkcSurveyImportTexts.Properties.Caption = resources.GetString("chkcSurveyImportTexts.Properties.Caption")
        '
        'cboImportAsBranchOfCave
        '
        Me.cboImportAsBranchOfCave.EditValue = Nothing
        resources.ApplyResources(Me.cboImportAsBranchOfCave, "cboImportAsBranchOfCave")
        Me.cboImportAsBranchOfCave.Name = "cboImportAsBranchOfCave"
        Me.cboImportAsBranchOfCave.Workmode = cSurveyPC.cCaveDropDown.WorkmodeEnum.View
        '
        'cboImportAsBranchOfBranch
        '
        Me.cboImportAsBranchOfBranch.EditValue = Nothing
        resources.ApplyResources(Me.cboImportAsBranchOfBranch, "cboImportAsBranchOfBranch")
        Me.cboImportAsBranchOfBranch.Name = "cboImportAsBranchOfBranch"
        Me.cboImportAsBranchOfBranch.Workmode = cSurveyPC.cCaveDropDown.WorkmodeEnum.View
        '
        'frmImportcSurvey
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkcSurveyImportTexts)
        Me.Controls.Add(Me.pnlcSurveyImportData)
        Me.Controls.Add(Me.chkcsurveyimportlinkedsurvey)
        Me.Controls.Add(Me.chkcSurveyDisableOriginAsExtendstart)
        Me.Controls.Add(Me.chkcSurveyImportCreateNewBranch)
        Me.Controls.Add(Me.chkcSurveyImportUpdateCaveBranchPriority)
        Me.Controls.Add(Me.chkImportAsBranchOf)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkcSurveyImportScaleRules)
        Me.Controls.Add(Me.chkcSurveyImportDesignProperties)
        Me.Controls.Add(Me.chkcSurveyImportSurface)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.chkcSurveyImportData)
        Me.Controls.Add(Me.chkcSurveyImportGraphics)
        Me.Controls.Add(Me.pnlcSurveyImportGraphics)
        Me.Controls.Add(Me.cboImportAsBranchOfCave)
        Me.Controls.Add(Me.cboImportAsBranchOfBranch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportcSurvey"
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tvLog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.svgiml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportScaleRules.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportDesignProperties.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportSurface.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportPlan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportGraphics.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportCaveBranchFromDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportDuplicates.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportDuplicatesOverwrite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportDuplicatesStations.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImportAsBranchOf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportUpdateCaveBranchPriority.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportCreateNewBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyDisableOriginAsExtendstart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcsurveyimportlinkedsurvey.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlcSurveyImportData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlcSurveyImportData.ResumeLayout(False)
        Me.pnlcSurveyImportData.PerformLayout()
        CType(Me.pnlcSurveyImportGraphics, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlcSurveyImportGraphics.ResumeLayout(False)
        Me.pnlcSurveyImportGraphics.PerformLayout()
        CType(Me.chkcSurveyImportTexts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkcSurveyImportPlan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportProfile As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportData As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportGraphics As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportSurface As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportDesignProperties As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportScaleRules As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupBox1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents iml As ImageList
    Friend WithEvents chkcSurveyImportCaveBranchFromDesign As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportDuplicates As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cbocSurveyImportDuplicatesMode As ComboBox
    Friend WithEvents lblcSurveyImportDuplicatesMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkcSurveyImportDuplicatesOverwrite As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportDuplicatesStations As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkImportAsBranchOf As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportUpdateCaveBranchPriority As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportCreateNewBranch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyImportDuplicatesOverwriteOnlyUsed As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkcSurveyDisableOriginAsExtendstart As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblcSurveyImportWarpingMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cbocSurveyImportWarpingMode As ComboBox
    Friend WithEvents chkcsurveyimportlinkedsurvey As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlcSurveyImportData As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlcSurveyImportGraphics As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkcSurveyImportTexts As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents tvLog As DevExpress.XtraTreeList.TreeList
    Friend WithEvents svgiml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents tvLogText As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents tvLogImageName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents cboImportAsBranchOfCave As cCaveDropDown
    Friend WithEvents cboImportAsBranchOfBranch As cCaveBranchDropDown
End Class
