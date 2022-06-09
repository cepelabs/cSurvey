<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemCaveBranchPropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemCaveBranchPropertyControl))
        Me.lblPropBranchList = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCaveList = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropCaveList = New cSurveyPC.cCaveDropDown()
        Me.cboPropCaveBranchList = New cSurveyPC.cCaveBranchDropDown()
        Me.lblPropBindCrossSections = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropBindDesignType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropBindDesignType = New DevExpress.XtraEditors.LabelControl()
        Me.pnlPropCaveBranchesColor = New DevExpress.XtraEditors.PanelControl()
        Me.pnlPropCaveBranches = New DevExpress.XtraEditors.PanelControl()
        Me.cmdPropSetCurrentCaveBranch = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropSetCaveBranch = New DevExpress.XtraEditors.SimpleButton()
        Me.cboPropBindCrossSections = New cSurveyPC.cCrossSectionDropDown()
        CType(Me.cboPropBindDesignType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPropCaveBranchesColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPropCaveBranches, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropCaveBranches.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPropBranchList
        '
        resources.ApplyResources(Me.lblPropBranchList, "lblPropBranchList")
        Me.lblPropBranchList.Name = "lblPropBranchList"
        '
        'lblPropCaveList
        '
        resources.ApplyResources(Me.lblPropCaveList, "lblPropCaveList")
        Me.lblPropCaveList.Name = "lblPropCaveList"
        '
        'cboPropCaveList
        '
        resources.ApplyResources(Me.cboPropCaveList, "cboPropCaveList")
        Me.cboPropCaveList.EditValue = Nothing
        Me.cboPropCaveList.Name = "cboPropCaveList"
        Me.cboPropCaveList.Workmode = cSurveyPC.cCaveDropDown.WorkmodeEnum.View
        '
        'cboPropCaveBranchList
        '
        resources.ApplyResources(Me.cboPropCaveBranchList, "cboPropCaveBranchList")
        Me.cboPropCaveBranchList.EditValue = Nothing
        Me.cboPropCaveBranchList.Name = "cboPropCaveBranchList"
        Me.cboPropCaveBranchList.Workmode = cSurveyPC.cCaveDropDown.WorkmodeEnum.View
        '
        'lblPropBindCrossSections
        '
        resources.ApplyResources(Me.lblPropBindCrossSections, "lblPropBindCrossSections")
        Me.lblPropBindCrossSections.Name = "lblPropBindCrossSections"
        '
        'cboPropBindDesignType
        '
        resources.ApplyResources(Me.cboPropBindDesignType, "cboPropBindDesignType")
        Me.cboPropBindDesignType.Name = "cboPropBindDesignType"
        Me.cboPropBindDesignType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropBindDesignType.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropBindDesignType.Properties.Items.AddRange(New Object() {resources.GetString("cboPropBindDesignType.Properties.Items"), resources.GetString("cboPropBindDesignType.Properties.Items1")})
        Me.cboPropBindDesignType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropBindDesignType
        '
        resources.ApplyResources(Me.lblPropBindDesignType, "lblPropBindDesignType")
        Me.lblPropBindDesignType.Name = "lblPropBindDesignType"
        '
        'pnlPropCaveBranchesColor
        '
        Me.pnlPropCaveBranchesColor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        resources.ApplyResources(Me.pnlPropCaveBranchesColor, "pnlPropCaveBranchesColor")
        Me.pnlPropCaveBranchesColor.Name = "pnlPropCaveBranchesColor"
        '
        'pnlPropCaveBranches
        '
        Me.pnlPropCaveBranches.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlPropCaveBranches.Controls.Add(Me.pnlPropCaveBranchesColor)
        Me.pnlPropCaveBranches.Controls.Add(Me.cmdPropSetCurrentCaveBranch)
        Me.pnlPropCaveBranches.Controls.Add(Me.cmdPropSetCaveBranch)
        Me.pnlPropCaveBranches.Controls.Add(Me.lblPropBranchList)
        Me.pnlPropCaveBranches.Controls.Add(Me.cboPropCaveBranchList)
        Me.pnlPropCaveBranches.Controls.Add(Me.lblPropCaveList)
        Me.pnlPropCaveBranches.Controls.Add(Me.cboPropCaveList)
        resources.ApplyResources(Me.pnlPropCaveBranches, "pnlPropCaveBranches")
        Me.pnlPropCaveBranches.Name = "pnlPropCaveBranches"
        '
        'cmdPropSetCurrentCaveBranch
        '
        resources.ApplyResources(Me.cmdPropSetCurrentCaveBranch, "cmdPropSetCurrentCaveBranch")
        Me.cmdPropSetCurrentCaveBranch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSetCurrentCaveBranch.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropSetCurrentCaveBranch.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropSetCurrentCaveBranch.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropSetCurrentCaveBranch.Name = "cmdPropSetCurrentCaveBranch"
        '
        'cmdPropSetCaveBranch
        '
        resources.ApplyResources(Me.cmdPropSetCaveBranch, "cmdPropSetCaveBranch")
        Me.cmdPropSetCaveBranch.ImageOptions.Image = CType(resources.GetObject("cmdPropSetCaveBranch.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdPropSetCaveBranch.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSetCaveBranch.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropSetCaveBranch.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropSetCaveBranch.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropSetCaveBranch.Name = "cmdPropSetCaveBranch"
        '
        'cboPropBindCrossSections
        '
        resources.ApplyResources(Me.cboPropBindCrossSections, "cboPropBindCrossSections")
        Me.cboPropBindCrossSections.EditValue = Nothing
        Me.cboPropBindCrossSections.Name = "cboPropBindCrossSections"
        Me.cboPropBindCrossSections.Workmode = cSurveyPC.cCrossSectionDropDown.WorkmodeEnum.View
        '
        'cItemCaveBranchPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboPropBindCrossSections)
        Me.Controls.Add(Me.lblPropBindCrossSections)
        Me.Controls.Add(Me.cboPropBindDesignType)
        Me.Controls.Add(Me.lblPropBindDesignType)
        Me.Controls.Add(Me.pnlPropCaveBranches)
        Me.Name = "cItemCaveBranchPropertyControl"
        CType(Me.cboPropBindDesignType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPropCaveBranchesColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPropCaveBranches, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropCaveBranches.ResumeLayout(False)
        Me.pnlPropCaveBranches.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropCaveBranchListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboPropCaveListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lblPropBranchList As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCaveList As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropCaveBranchList As cCaveBranchDropDown
    Friend WithEvents cboPropCaveList As cCaveDropDown
    Friend WithEvents lblPropBindCrossSections As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropBindDesignType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropBindDesignType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlPropCaveBranchesColor As DevExpress.XtraEditors.PanelControl
    Friend WithEvents pnlPropCaveBranches As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdPropSetCurrentCaveBranch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropSetCaveBranch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboPropBindCrossSections As cCrossSectionDropDown
End Class
