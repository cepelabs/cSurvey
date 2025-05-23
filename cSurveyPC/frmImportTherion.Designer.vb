<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportTherion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportTherion))
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.chkcSurveyImportCreateNewBranch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkImportAsBranchOf = New DevExpress.XtraEditors.CheckEdit()
        Me.cboImportAsBranchOfCave = New cSurveyPC.cCaveDropDown()
        Me.cboImportAsBranchOfBranch = New cSurveyPC.cCaveBranchDropDown()
        Me.chkProcessAllFiles = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLineOfComment = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkcSurveyImportCreateNewBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkImportAsBranchOf.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkProcessAllFiles.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLineOfComment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Properties.ReadOnly = True
        '
        'lblFilename
        '
        Me.lblFilename.Appearance.Font = CType(resources.GetObject("lblFilename.Appearance.Font"), System.Drawing.Font)
        Me.lblFilename.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
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
        'chkcSurveyImportCreateNewBranch
        '
        resources.ApplyResources(Me.chkcSurveyImportCreateNewBranch, "chkcSurveyImportCreateNewBranch")
        Me.chkcSurveyImportCreateNewBranch.Name = "chkcSurveyImportCreateNewBranch"
        Me.chkcSurveyImportCreateNewBranch.Properties.AutoWidth = True
        Me.chkcSurveyImportCreateNewBranch.Properties.Caption = resources.GetString("chkcSurveyImportCreateNewBranch.Properties.Caption")
        '
        'chkImportAsBranchOf
        '
        resources.ApplyResources(Me.chkImportAsBranchOf, "chkImportAsBranchOf")
        Me.chkImportAsBranchOf.Name = "chkImportAsBranchOf"
        Me.chkImportAsBranchOf.Properties.AutoWidth = True
        Me.chkImportAsBranchOf.Properties.Caption = resources.GetString("chkImportAsBranchOf.Properties.Caption")
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
        'chkProcessAllFiles
        '
        resources.ApplyResources(Me.chkProcessAllFiles, "chkProcessAllFiles")
        Me.chkProcessAllFiles.Name = "chkProcessAllFiles"
        Me.chkProcessAllFiles.Properties.AutoWidth = True
        Me.chkProcessAllFiles.Properties.Caption = resources.GetString("chkProcessAllFiles.Properties.Caption")
        '
        'chkLineOfComment
        '
        resources.ApplyResources(Me.chkLineOfComment, "chkLineOfComment")
        Me.chkLineOfComment.Name = "chkLineOfComment"
        Me.chkLineOfComment.Properties.AutoWidth = True
        Me.chkLineOfComment.Properties.Caption = resources.GetString("chkLineOfComment.Properties.Caption")
        '
        'frmImportTherion
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkLineOfComment)
        Me.Controls.Add(Me.chkProcessAllFiles)
        Me.Controls.Add(Me.chkcSurveyImportCreateNewBranch)
        Me.Controls.Add(Me.chkImportAsBranchOf)
        Me.Controls.Add(Me.cboImportAsBranchOfCave)
        Me.Controls.Add(Me.cboImportAsBranchOfBranch)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportTherion.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportTherion"
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkcSurveyImportCreateNewBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkImportAsBranchOf.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkProcessAllFiles.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLineOfComment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkcSurveyImportCreateNewBranch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkImportAsBranchOf As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboImportAsBranchOfCave As cCaveDropDown
    Friend WithEvents cboImportAsBranchOfBranch As cCaveBranchDropDown
    Friend WithEvents chkProcessAllFiles As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLineOfComment As DevExpress.XtraEditors.CheckEdit
End Class
