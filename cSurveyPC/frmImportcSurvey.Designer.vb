﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvCheck = New System.Windows.Forms.ListView()
        Me.colText = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.chkcSurveyImportScaleRules = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportDesignProperties = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportSurface = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportProfile = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportPlan = New System.Windows.Forms.CheckBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.chkcSurveyImportData = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportGraphics = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportCaveBranchFromDesign = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportDuplicates = New System.Windows.Forms.CheckBox()
        Me.cbocSurveyImportDuplicatesMode = New System.Windows.Forms.ComboBox()
        Me.lblcSurveyImportDuplicatesMode = New System.Windows.Forms.Label()
        Me.chkcSurveyImportDuplicatesOverwrite = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportDuplicatesStations = New System.Windows.Forms.CheckBox()
        Me.chkImportAsBranchOf = New System.Windows.Forms.CheckBox()
        Me.cboImportAsBranchOfCave = New cSurveyPC.cCaveInfoCombobox()
        Me.cboImportAsBranchOfBranch = New cSurveyPC.cCaveInfoBranchesCombobox()
        Me.chkcSurveyImportUpdateCaveBranchPriority = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportCreateNewBranch = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed = New System.Windows.Forms.CheckBox()
        Me.chkcSurveyDisableOriginAsExtendstart = New System.Windows.Forms.CheckBox()
        Me.lblcSurveyImportWarpingMode = New System.Windows.Forms.Label()
        Me.cbocSurveyImportWarpingMode = New System.Windows.Forms.ComboBox()
        Me.chkcsurveyimportlinkedsurvey = New System.Windows.Forms.CheckBox()
        Me.pnlcSurveyImportData = New System.Windows.Forms.Panel()
        Me.pnlcSurveyImportGraphics = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.pnlcSurveyImportData.SuspendLayout()
        Me.pnlcSurveyImportGraphics.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtFilename, resources.GetString("txtFilename.ToolTip"))
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.tipDefault.SetToolTip(Me.cmdOk, resources.GetString("cmdOk.ToolTip"))
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.tipDefault.SetToolTip(Me.cmdCancel, resources.GetString("cmdCancel.ToolTip"))
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.lvCheck)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        Me.tipDefault.SetToolTip(Me.GroupBox1, resources.GetString("GroupBox1.ToolTip"))
        '
        'lvCheck
        '
        resources.ApplyResources(Me.lvCheck, "lvCheck")
        Me.lvCheck.BackColor = System.Drawing.SystemColors.Control
        Me.lvCheck.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvCheck.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colText})
        Me.lvCheck.FullRowSelect = True
        Me.lvCheck.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvCheck.HideSelection = False
        Me.lvCheck.Name = "lvCheck"
        Me.lvCheck.SmallImageList = Me.iml
        Me.tipDefault.SetToolTip(Me.lvCheck, resources.GetString("lvCheck.ToolTip"))
        Me.lvCheck.UseCompatibleStateImageBehavior = False
        Me.lvCheck.View = System.Windows.Forms.View.Details
        '
        'colText
        '
        resources.ApplyResources(Me.colText, "colText")
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
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportScaleRules, resources.GetString("chkcSurveyImportScaleRules.ToolTip"))
        Me.chkcSurveyImportScaleRules.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDesignProperties
        '
        resources.ApplyResources(Me.chkcSurveyImportDesignProperties, "chkcSurveyImportDesignProperties")
        Me.chkcSurveyImportDesignProperties.Name = "chkcSurveyImportDesignProperties"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportDesignProperties, resources.GetString("chkcSurveyImportDesignProperties.ToolTip"))
        Me.chkcSurveyImportDesignProperties.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportSurface
        '
        resources.ApplyResources(Me.chkcSurveyImportSurface, "chkcSurveyImportSurface")
        Me.chkcSurveyImportSurface.Name = "chkcSurveyImportSurface"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportSurface, resources.GetString("chkcSurveyImportSurface.ToolTip"))
        Me.chkcSurveyImportSurface.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportProfile
        '
        resources.ApplyResources(Me.chkcSurveyImportProfile, "chkcSurveyImportProfile")
        Me.chkcSurveyImportProfile.Name = "chkcSurveyImportProfile"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportProfile, resources.GetString("chkcSurveyImportProfile.ToolTip"))
        Me.chkcSurveyImportProfile.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportPlan
        '
        resources.ApplyResources(Me.chkcSurveyImportPlan, "chkcSurveyImportPlan")
        Me.chkcSurveyImportPlan.Name = "chkcSurveyImportPlan"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportPlan, resources.GetString("chkcSurveyImportPlan.ToolTip"))
        Me.chkcSurveyImportPlan.UseVisualStyleBackColor = True
        '
        'lblFilename
        '
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        Me.tipDefault.SetToolTip(Me.lblFilename, resources.GetString("lblFilename.ToolTip"))
        '
        'chkcSurveyImportData
        '
        resources.ApplyResources(Me.chkcSurveyImportData, "chkcSurveyImportData")
        Me.chkcSurveyImportData.Name = "chkcSurveyImportData"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportData, resources.GetString("chkcSurveyImportData.ToolTip"))
        Me.chkcSurveyImportData.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportGraphics
        '
        resources.ApplyResources(Me.chkcSurveyImportGraphics, "chkcSurveyImportGraphics")
        Me.chkcSurveyImportGraphics.Name = "chkcSurveyImportGraphics"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportGraphics, resources.GetString("chkcSurveyImportGraphics.ToolTip"))
        Me.chkcSurveyImportGraphics.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportCaveBranchFromDesign
        '
        resources.ApplyResources(Me.chkcSurveyImportCaveBranchFromDesign, "chkcSurveyImportCaveBranchFromDesign")
        Me.chkcSurveyImportCaveBranchFromDesign.Name = "chkcSurveyImportCaveBranchFromDesign"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportCaveBranchFromDesign, resources.GetString("chkcSurveyImportCaveBranchFromDesign.ToolTip"))
        Me.chkcSurveyImportCaveBranchFromDesign.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDuplicates
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicates, "chkcSurveyImportDuplicates")
        Me.chkcSurveyImportDuplicates.Name = "chkcSurveyImportDuplicates"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportDuplicates, resources.GetString("chkcSurveyImportDuplicates.ToolTip"))
        Me.chkcSurveyImportDuplicates.UseVisualStyleBackColor = True
        '
        'cbocSurveyImportDuplicatesMode
        '
        resources.ApplyResources(Me.cbocSurveyImportDuplicatesMode, "cbocSurveyImportDuplicatesMode")
        Me.cbocSurveyImportDuplicatesMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocSurveyImportDuplicatesMode.DropDownWidth = 320
        Me.cbocSurveyImportDuplicatesMode.FormattingEnabled = True
        Me.cbocSurveyImportDuplicatesMode.Items.AddRange(New Object() {resources.GetString("cbocSurveyImportDuplicatesMode.Items"), resources.GetString("cbocSurveyImportDuplicatesMode.Items1")})
        Me.cbocSurveyImportDuplicatesMode.Name = "cbocSurveyImportDuplicatesMode"
        Me.tipDefault.SetToolTip(Me.cbocSurveyImportDuplicatesMode, resources.GetString("cbocSurveyImportDuplicatesMode.ToolTip"))
        '
        'lblcSurveyImportDuplicatesMode
        '
        resources.ApplyResources(Me.lblcSurveyImportDuplicatesMode, "lblcSurveyImportDuplicatesMode")
        Me.lblcSurveyImportDuplicatesMode.Name = "lblcSurveyImportDuplicatesMode"
        Me.tipDefault.SetToolTip(Me.lblcSurveyImportDuplicatesMode, resources.GetString("lblcSurveyImportDuplicatesMode.ToolTip"))
        '
        'chkcSurveyImportDuplicatesOverwrite
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesOverwrite, "chkcSurveyImportDuplicatesOverwrite")
        Me.chkcSurveyImportDuplicatesOverwrite.Name = "chkcSurveyImportDuplicatesOverwrite"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportDuplicatesOverwrite, resources.GetString("chkcSurveyImportDuplicatesOverwrite.ToolTip"))
        Me.chkcSurveyImportDuplicatesOverwrite.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDuplicatesStations
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesStations, "chkcSurveyImportDuplicatesStations")
        Me.chkcSurveyImportDuplicatesStations.Name = "chkcSurveyImportDuplicatesStations"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportDuplicatesStations, resources.GetString("chkcSurveyImportDuplicatesStations.ToolTip"))
        Me.chkcSurveyImportDuplicatesStations.UseVisualStyleBackColor = True
        '
        'chkImportAsBranchOf
        '
        resources.ApplyResources(Me.chkImportAsBranchOf, "chkImportAsBranchOf")
        Me.chkImportAsBranchOf.Name = "chkImportAsBranchOf"
        Me.tipDefault.SetToolTip(Me.chkImportAsBranchOf, resources.GetString("chkImportAsBranchOf.ToolTip"))
        Me.chkImportAsBranchOf.UseVisualStyleBackColor = True
        '
        'cboImportAsBranchOfCave
        '
        resources.ApplyResources(Me.cboImportAsBranchOfCave, "cboImportAsBranchOfCave")
        Me.cboImportAsBranchOfCave.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboImportAsBranchOfCave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImportAsBranchOfCave.FormattingEnabled = True
        Me.cboImportAsBranchOfCave.Name = "cboImportAsBranchOfCave"
        Me.tipDefault.SetToolTip(Me.cboImportAsBranchOfCave, resources.GetString("cboImportAsBranchOfCave.ToolTip"))
        Me.cboImportAsBranchOfCave.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'cboImportAsBranchOfBranch
        '
        resources.ApplyResources(Me.cboImportAsBranchOfBranch, "cboImportAsBranchOfBranch")
        Me.cboImportAsBranchOfBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboImportAsBranchOfBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImportAsBranchOfBranch.FormattingEnabled = True
        Me.cboImportAsBranchOfBranch.Name = "cboImportAsBranchOfBranch"
        Me.tipDefault.SetToolTip(Me.cboImportAsBranchOfBranch, resources.GetString("cboImportAsBranchOfBranch.ToolTip"))
        Me.cboImportAsBranchOfBranch.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'chkcSurveyImportUpdateCaveBranchPriority
        '
        resources.ApplyResources(Me.chkcSurveyImportUpdateCaveBranchPriority, "chkcSurveyImportUpdateCaveBranchPriority")
        Me.chkcSurveyImportUpdateCaveBranchPriority.Name = "chkcSurveyImportUpdateCaveBranchPriority"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportUpdateCaveBranchPriority, resources.GetString("chkcSurveyImportUpdateCaveBranchPriority.ToolTip"))
        Me.chkcSurveyImportUpdateCaveBranchPriority.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportCreateNewBranch
        '
        resources.ApplyResources(Me.chkcSurveyImportCreateNewBranch, "chkcSurveyImportCreateNewBranch")
        Me.chkcSurveyImportCreateNewBranch.Name = "chkcSurveyImportCreateNewBranch"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportCreateNewBranch, resources.GetString("chkcSurveyImportCreateNewBranch.ToolTip"))
        Me.chkcSurveyImportCreateNewBranch.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDuplicatesOverwriteOnlyUsed
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed, "chkcSurveyImportDuplicatesOverwriteOnlyUsed")
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Name = "chkcSurveyImportDuplicatesOverwriteOnlyUsed"
        Me.tipDefault.SetToolTip(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed, resources.GetString("chkcSurveyImportDuplicatesOverwriteOnlyUsed.ToolTip"))
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.UseVisualStyleBackColor = True
        '
        'chkcSurveyDisableOriginAsExtendstart
        '
        resources.ApplyResources(Me.chkcSurveyDisableOriginAsExtendstart, "chkcSurveyDisableOriginAsExtendstart")
        Me.chkcSurveyDisableOriginAsExtendstart.Name = "chkcSurveyDisableOriginAsExtendstart"
        Me.tipDefault.SetToolTip(Me.chkcSurveyDisableOriginAsExtendstart, resources.GetString("chkcSurveyDisableOriginAsExtendstart.ToolTip"))
        Me.chkcSurveyDisableOriginAsExtendstart.UseVisualStyleBackColor = True
        '
        'lblcSurveyImportWarpingMode
        '
        resources.ApplyResources(Me.lblcSurveyImportWarpingMode, "lblcSurveyImportWarpingMode")
        Me.lblcSurveyImportWarpingMode.Name = "lblcSurveyImportWarpingMode"
        Me.tipDefault.SetToolTip(Me.lblcSurveyImportWarpingMode, resources.GetString("lblcSurveyImportWarpingMode.ToolTip"))
        '
        'cbocSurveyImportWarpingMode
        '
        resources.ApplyResources(Me.cbocSurveyImportWarpingMode, "cbocSurveyImportWarpingMode")
        Me.cbocSurveyImportWarpingMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocSurveyImportWarpingMode.DropDownWidth = 320
        Me.cbocSurveyImportWarpingMode.FormattingEnabled = True
        Me.cbocSurveyImportWarpingMode.Items.AddRange(New Object() {resources.GetString("cbocSurveyImportWarpingMode.Items"), resources.GetString("cbocSurveyImportWarpingMode.Items1"), resources.GetString("cbocSurveyImportWarpingMode.Items2")})
        Me.cbocSurveyImportWarpingMode.Name = "cbocSurveyImportWarpingMode"
        Me.tipDefault.SetToolTip(Me.cbocSurveyImportWarpingMode, resources.GetString("cbocSurveyImportWarpingMode.ToolTip"))
        '
        'chkcsurveyimportlinkedsurvey
        '
        resources.ApplyResources(Me.chkcsurveyimportlinkedsurvey, "chkcsurveyimportlinkedsurvey")
        Me.chkcsurveyimportlinkedsurvey.Name = "chkcsurveyimportlinkedsurvey"
        Me.tipDefault.SetToolTip(Me.chkcsurveyimportlinkedsurvey, resources.GetString("chkcsurveyimportlinkedsurvey.ToolTip"))
        Me.chkcsurveyimportlinkedsurvey.UseVisualStyleBackColor = True
        '
        'pnlcSurveyImportData
        '
        resources.ApplyResources(Me.pnlcSurveyImportData, "pnlcSurveyImportData")
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed)
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicatesOverwrite)
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicates)
        Me.pnlcSurveyImportData.Controls.Add(Me.cbocSurveyImportDuplicatesMode)
        Me.pnlcSurveyImportData.Controls.Add(Me.lblcSurveyImportDuplicatesMode)
        Me.pnlcSurveyImportData.Controls.Add(Me.chkcSurveyImportDuplicatesStations)
        Me.pnlcSurveyImportData.Name = "pnlcSurveyImportData"
        Me.tipDefault.SetToolTip(Me.pnlcSurveyImportData, resources.GetString("pnlcSurveyImportData.ToolTip"))
        '
        'pnlcSurveyImportGraphics
        '
        resources.ApplyResources(Me.pnlcSurveyImportGraphics, "pnlcSurveyImportGraphics")
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.chkcSurveyImportPlan)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.lblcSurveyImportWarpingMode)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.chkcSurveyImportCaveBranchFromDesign)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.cbocSurveyImportWarpingMode)
        Me.pnlcSurveyImportGraphics.Controls.Add(Me.chkcSurveyImportProfile)
        Me.pnlcSurveyImportGraphics.Name = "pnlcSurveyImportGraphics"
        Me.tipDefault.SetToolTip(Me.pnlcSurveyImportGraphics, resources.GetString("pnlcSurveyImportGraphics.ToolTip"))
        '
        'frmImportcSurvey
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.pnlcSurveyImportData)
        Me.Controls.Add(Me.chkcsurveyimportlinkedsurvey)
        Me.Controls.Add(Me.chkcSurveyDisableOriginAsExtendstart)
        Me.Controls.Add(Me.chkcSurveyImportCreateNewBranch)
        Me.Controls.Add(Me.chkcSurveyImportUpdateCaveBranchPriority)
        Me.Controls.Add(Me.cboImportAsBranchOfBranch)
        Me.Controls.Add(Me.cboImportAsBranchOfCave)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportcSurvey"
        Me.tipDefault.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlcSurveyImportData.ResumeLayout(False)
        Me.pnlcSurveyImportData.PerformLayout()
        Me.pnlcSurveyImportGraphics.ResumeLayout(False)
        Me.pnlcSurveyImportGraphics.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkcSurveyImportPlan As System.Windows.Forms.CheckBox
    Friend WithEvents chkcSurveyImportProfile As System.Windows.Forms.CheckBox
    Friend WithEvents chkcSurveyImportData As System.Windows.Forms.CheckBox
    Friend WithEvents chkcSurveyImportGraphics As System.Windows.Forms.CheckBox
    Friend WithEvents chkcSurveyImportSurface As System.Windows.Forms.CheckBox
    Friend WithEvents chkcSurveyImportDesignProperties As CheckBox
    Friend WithEvents chkcSurveyImportScaleRules As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lvCheck As ListView
    Friend WithEvents iml As ImageList
    Friend WithEvents colText As ColumnHeader
    Friend WithEvents chkcSurveyImportCaveBranchFromDesign As CheckBox
    Friend WithEvents chkcSurveyImportDuplicates As CheckBox
    Friend WithEvents cbocSurveyImportDuplicatesMode As ComboBox
    Friend WithEvents lblcSurveyImportDuplicatesMode As Label
    Friend WithEvents chkcSurveyImportDuplicatesOverwrite As CheckBox
    Friend WithEvents chkcSurveyImportDuplicatesStations As CheckBox
    Friend WithEvents chkImportAsBranchOf As CheckBox
    Friend WithEvents cboImportAsBranchOfCave As cCaveInfoCombobox
    Friend WithEvents cboImportAsBranchOfBranch As cCaveInfoBranchesCombobox
    Friend WithEvents chkcSurveyImportUpdateCaveBranchPriority As CheckBox
    Friend WithEvents chkcSurveyImportCreateNewBranch As CheckBox
    Friend WithEvents chkcSurveyImportDuplicatesOverwriteOnlyUsed As CheckBox
    Friend WithEvents chkcSurveyDisableOriginAsExtendstart As CheckBox
    Friend WithEvents lblcSurveyImportWarpingMode As Label
    Friend WithEvents cbocSurveyImportWarpingMode As ComboBox
    Friend WithEvents chkcsurveyimportlinkedsurvey As CheckBox
    Friend WithEvents pnlcSurveyImportData As Panel
    Friend WithEvents pnlcSurveyImportGraphics As Panel
End Class
