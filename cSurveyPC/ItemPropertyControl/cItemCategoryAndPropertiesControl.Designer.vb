<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemCategoryAndPropertiesControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemCategoryAndPropertiesControl))
        Me.chkPropShowDataProperties = New DevExpress.XtraEditors.CheckButton()
        Me.cboPropCategories = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblPropCategory = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropDesignDataProperties = New DevExpress.XtraEditors.LabelControl()
        Me.prpPropDesignDataProperties = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        CType(Me.cboPropCategories.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.prpPropDesignDataProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkPropShowDataProperties
        '
        resources.ApplyResources(Me.chkPropShowDataProperties, "chkPropShowDataProperties")
        Me.chkPropShowDataProperties.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropShowDataProperties.ImageOptions.SvgImage = CType(resources.GetObject("chkPropShowDataProperties.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.chkPropShowDataProperties.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.chkPropShowDataProperties.Name = "chkPropShowDataProperties"
        '
        'cboPropCategories
        '
        resources.ApplyResources(Me.cboPropCategories, "cboPropCategories")
        Me.cboPropCategories.Name = "cboPropCategories"
        Me.cboPropCategories.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropCategories.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropCategories.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblPropCategory
        '
        Me.lblPropCategory.Appearance.Font = CType(resources.GetObject("lblPropCategory.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCategory.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCategory, "lblPropCategory")
        Me.lblPropCategory.Name = "lblPropCategory"
        '
        'lblPropDesignDataProperties
        '
        Me.lblPropDesignDataProperties.Appearance.Font = CType(resources.GetObject("lblPropDesignDataProperties.Appearance.Font"), System.Drawing.Font)
        Me.lblPropDesignDataProperties.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropDesignDataProperties, "lblPropDesignDataProperties")
        Me.lblPropDesignDataProperties.Name = "lblPropDesignDataProperties"
        '
        'prpPropDesignDataProperties
        '
        resources.ApplyResources(Me.prpPropDesignDataProperties, "prpPropDesignDataProperties")
        Me.prpPropDesignDataProperties.Cursor = System.Windows.Forms.Cursors.Default
        Me.prpPropDesignDataProperties.Name = "prpPropDesignDataProperties"
        Me.prpPropDesignDataProperties.OptionsMenu.EnableContextMenu = False
        Me.prpPropDesignDataProperties.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.[True]
        Me.prpPropDesignDataProperties.OptionsView.ShowRootLevelIndent = False
        '
        'cItemCategoryAndPropertiesControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.chkPropShowDataProperties)
        Me.Controls.Add(Me.cboPropCategories)
        Me.Controls.Add(Me.lblPropCategory)
        Me.Controls.Add(Me.lblPropDesignDataProperties)
        Me.Controls.Add(Me.prpPropDesignDataProperties)
        Me.Name = "cItemCategoryAndPropertiesControl"
        CType(Me.cboPropCategories.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.prpPropDesignDataProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropCaveBranchListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboPropCaveListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents chkPropShowDataProperties As DevExpress.XtraEditors.CheckButton
    Friend WithEvents cboPropCategories As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblPropCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropDesignDataProperties As DevExpress.XtraEditors.LabelControl
    Friend WithEvents prpPropDesignDataProperties As DevExpress.XtraVerticalGrid.PropertyGridControl
End Class
