<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportcSurvey
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
        Me.GroupBox1.SuspendLayout()
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
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.lvCheck)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'lvCheck
        '
        resources.ApplyResources(Me.lvCheck, "lvCheck")
        Me.lvCheck.BackColor = System.Drawing.SystemColors.Control
        Me.lvCheck.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvCheck.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colText})
        Me.lvCheck.FullRowSelect = True
        Me.lvCheck.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvCheck.Name = "lvCheck"
        Me.lvCheck.SmallImageList = Me.iml
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
        '
        'chkcSurveyImportScaleRules
        '
        resources.ApplyResources(Me.chkcSurveyImportScaleRules, "chkcSurveyImportScaleRules")
        Me.chkcSurveyImportScaleRules.Name = "chkcSurveyImportScaleRules"
        Me.chkcSurveyImportScaleRules.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDesignProperties
        '
        resources.ApplyResources(Me.chkcSurveyImportDesignProperties, "chkcSurveyImportDesignProperties")
        Me.chkcSurveyImportDesignProperties.Name = "chkcSurveyImportDesignProperties"
        Me.chkcSurveyImportDesignProperties.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportSurface
        '
        resources.ApplyResources(Me.chkcSurveyImportSurface, "chkcSurveyImportSurface")
        Me.chkcSurveyImportSurface.Name = "chkcSurveyImportSurface"
        Me.chkcSurveyImportSurface.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportProfile
        '
        resources.ApplyResources(Me.chkcSurveyImportProfile, "chkcSurveyImportProfile")
        Me.chkcSurveyImportProfile.Name = "chkcSurveyImportProfile"
        Me.chkcSurveyImportProfile.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportPlan
        '
        resources.ApplyResources(Me.chkcSurveyImportPlan, "chkcSurveyImportPlan")
        Me.chkcSurveyImportPlan.Name = "chkcSurveyImportPlan"
        Me.chkcSurveyImportPlan.UseVisualStyleBackColor = True
        '
        'lblFilename
        '
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'chkcSurveyImportData
        '
        resources.ApplyResources(Me.chkcSurveyImportData, "chkcSurveyImportData")
        Me.chkcSurveyImportData.Name = "chkcSurveyImportData"
        Me.chkcSurveyImportData.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportGraphics
        '
        resources.ApplyResources(Me.chkcSurveyImportGraphics, "chkcSurveyImportGraphics")
        Me.chkcSurveyImportGraphics.Name = "chkcSurveyImportGraphics"
        Me.chkcSurveyImportGraphics.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportCaveBranchFromDesign
        '
        resources.ApplyResources(Me.chkcSurveyImportCaveBranchFromDesign, "chkcSurveyImportCaveBranchFromDesign")
        Me.chkcSurveyImportCaveBranchFromDesign.Name = "chkcSurveyImportCaveBranchFromDesign"
        Me.chkcSurveyImportCaveBranchFromDesign.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDuplicates
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicates, "chkcSurveyImportDuplicates")
        Me.chkcSurveyImportDuplicates.Name = "chkcSurveyImportDuplicates"
        Me.chkcSurveyImportDuplicates.UseVisualStyleBackColor = True
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
        Me.chkcSurveyImportDuplicatesOverwrite.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDuplicatesStations
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesStations, "chkcSurveyImportDuplicatesStations")
        Me.chkcSurveyImportDuplicatesStations.Name = "chkcSurveyImportDuplicatesStations"
        Me.chkcSurveyImportDuplicatesStations.UseVisualStyleBackColor = True
        '
        'chkImportAsBranchOf
        '
        resources.ApplyResources(Me.chkImportAsBranchOf, "chkImportAsBranchOf")
        Me.chkImportAsBranchOf.Name = "chkImportAsBranchOf"
        Me.chkImportAsBranchOf.UseVisualStyleBackColor = True
        '
        'cboImportAsBranchOfCave
        '
        Me.cboImportAsBranchOfCave.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboImportAsBranchOfCave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboImportAsBranchOfCave, "cboImportAsBranchOfCave")
        Me.cboImportAsBranchOfCave.FormattingEnabled = True
        Me.cboImportAsBranchOfCave.Name = "cboImportAsBranchOfCave"
        Me.cboImportAsBranchOfCave.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'cboImportAsBranchOfBranch
        '
        Me.cboImportAsBranchOfBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboImportAsBranchOfBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboImportAsBranchOfBranch, "cboImportAsBranchOfBranch")
        Me.cboImportAsBranchOfBranch.FormattingEnabled = True
        Me.cboImportAsBranchOfBranch.Name = "cboImportAsBranchOfBranch"
        Me.cboImportAsBranchOfBranch.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'chkcSurveyImportUpdateCaveBranchPriority
        '
        resources.ApplyResources(Me.chkcSurveyImportUpdateCaveBranchPriority, "chkcSurveyImportUpdateCaveBranchPriority")
        Me.chkcSurveyImportUpdateCaveBranchPriority.Name = "chkcSurveyImportUpdateCaveBranchPriority"
        Me.chkcSurveyImportUpdateCaveBranchPriority.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportCreateNewBranch
        '
        resources.ApplyResources(Me.chkcSurveyImportCreateNewBranch, "chkcSurveyImportCreateNewBranch")
        Me.chkcSurveyImportCreateNewBranch.Name = "chkcSurveyImportCreateNewBranch"
        Me.chkcSurveyImportCreateNewBranch.UseVisualStyleBackColor = True
        '
        'chkcSurveyImportDuplicatesOverwriteOnlyUsed
        '
        resources.ApplyResources(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed, "chkcSurveyImportDuplicatesOverwriteOnlyUsed")
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.Name = "chkcSurveyImportDuplicatesOverwriteOnlyUsed"
        Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed.UseVisualStyleBackColor = True
        '
        'chkcSurveyDisableOriginAsExtendstart
        '
        resources.ApplyResources(Me.chkcSurveyDisableOriginAsExtendstart, "chkcSurveyDisableOriginAsExtendstart")
        Me.chkcSurveyDisableOriginAsExtendstart.Name = "chkcSurveyDisableOriginAsExtendstart"
        Me.chkcSurveyDisableOriginAsExtendstart.UseVisualStyleBackColor = True
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
        'frmImportcSurvey
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblcSurveyImportWarpingMode)
        Me.Controls.Add(Me.cbocSurveyImportWarpingMode)
        Me.Controls.Add(Me.chkcSurveyDisableOriginAsExtendstart)
        Me.Controls.Add(Me.chkcSurveyImportDuplicatesOverwriteOnlyUsed)
        Me.Controls.Add(Me.chkcSurveyImportCreateNewBranch)
        Me.Controls.Add(Me.chkcSurveyImportUpdateCaveBranchPriority)
        Me.Controls.Add(Me.cboImportAsBranchOfBranch)
        Me.Controls.Add(Me.cboImportAsBranchOfCave)
        Me.Controls.Add(Me.chkImportAsBranchOf)
        Me.Controls.Add(Me.chkcSurveyImportDuplicatesStations)
        Me.Controls.Add(Me.chkcSurveyImportDuplicatesOverwrite)
        Me.Controls.Add(Me.lblcSurveyImportDuplicatesMode)
        Me.Controls.Add(Me.cbocSurveyImportDuplicatesMode)
        Me.Controls.Add(Me.chkcSurveyImportDuplicates)
        Me.Controls.Add(Me.chkcSurveyImportCaveBranchFromDesign)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkcSurveyImportScaleRules)
        Me.Controls.Add(Me.chkcSurveyImportDesignProperties)
        Me.Controls.Add(Me.chkcSurveyImportSurface)
        Me.Controls.Add(Me.chkcSurveyImportProfile)
        Me.Controls.Add(Me.chkcSurveyImportPlan)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.chkcSurveyImportData)
        Me.Controls.Add(Me.chkcSurveyImportGraphics)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportcSurvey"
        Me.GroupBox1.ResumeLayout(False)
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
End Class
