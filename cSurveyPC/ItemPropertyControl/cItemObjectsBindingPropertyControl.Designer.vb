<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemObjectsBindingPropertyControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemObjectsBindingPropertyControl))
        Me.btnPropObjectsSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPropObjectsRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropObjects = New DevExpress.XtraEditors.LabelControl()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.colTreeLayersType = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersCaveBranchColor = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersHiddenInPreview = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersHiddenInDesign = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersCave = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.colTreeLayersBranch = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.tvLayers = New DevExpress.XtraTreeList.TreeList()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tvLayers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPropObjectsSelect
        '
        resources.ApplyResources(Me.btnPropObjectsSelect, "btnPropObjectsSelect")
        Me.btnPropObjectsSelect.ImageOptions.Image = CType(resources.GetObject("btnPropObjectsSelect.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPropObjectsSelect.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPropObjectsSelect.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.btnPropObjectsSelect.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPropObjectsSelect.Name = "btnPropObjectsSelect"
        '
        'btnPropObjectsRefresh
        '
        resources.ApplyResources(Me.btnPropObjectsRefresh, "btnPropObjectsRefresh")
        Me.btnPropObjectsRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPropObjectsRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnPropObjectsRefresh.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPropObjectsRefresh.Name = "btnPropObjectsRefresh"
        '
        'lblPropObjects
        '
        resources.ApplyResources(Me.lblPropObjects, "lblPropObjects")
        Me.lblPropObjects.Name = "lblPropObjects"
        '
        'iml
        '
        Me.iml.Add("layer", CType(resources.GetObject("iml.layer"), DevExpress.Utils.Svg.SvgImage))
        Me.iml.Add("item", CType(resources.GetObject("iml.item"), DevExpress.Utils.Svg.SvgImage))
        '
        'colTreeLayersType
        '
        resources.ApplyResources(Me.colTreeLayersType, "colTreeLayersType")
        Me.colTreeLayersType.FieldName = "2"
        Me.colTreeLayersType.Name = "colTreeLayersType"
        Me.colTreeLayersType.OptionsColumn.AllowEdit = False
        Me.colTreeLayersType.OptionsColumn.ReadOnly = True
        Me.colTreeLayersType.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colTreeLayersCaveBranchColor
        '
        resources.ApplyResources(Me.colTreeLayersCaveBranchColor, "colTreeLayersCaveBranchColor")
        Me.colTreeLayersCaveBranchColor.FieldName = "1"
        Me.colTreeLayersCaveBranchColor.Name = "colTreeLayersCaveBranchColor"
        Me.colTreeLayersCaveBranchColor.OptionsColumn.AllowEdit = False
        Me.colTreeLayersCaveBranchColor.OptionsColumn.FixedWidth = True
        Me.colTreeLayersCaveBranchColor.OptionsColumn.ReadOnly = True
        Me.colTreeLayersCaveBranchColor.OptionsFilter.AllowAutoFilter = False
        Me.colTreeLayersCaveBranchColor.OptionsFilter.AllowFilter = False
        '
        'colTreeLayersHiddenInPreview
        '
        resources.ApplyResources(Me.colTreeLayersHiddenInPreview, "colTreeLayersHiddenInPreview")
        Me.colTreeLayersHiddenInPreview.FieldName = "3"
        Me.colTreeLayersHiddenInPreview.ImageOptions.Alignment = CType(resources.GetObject("colTreeLayersHiddenInPreview.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.colTreeLayersHiddenInPreview.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.printvisibility
        Me.colTreeLayersHiddenInPreview.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.CommonPalette
        Me.colTreeLayersHiddenInPreview.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.colTreeLayersHiddenInPreview.Name = "colTreeLayersHiddenInPreview"
        Me.colTreeLayersHiddenInPreview.OptionsColumn.FixedWidth = True
        Me.colTreeLayersHiddenInPreview.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[Boolean]
        '
        'colTreeLayersHiddenInDesign
        '
        resources.ApplyResources(Me.colTreeLayersHiddenInDesign, "colTreeLayersHiddenInDesign")
        Me.colTreeLayersHiddenInDesign.FieldName = "4"
        Me.colTreeLayersHiddenInDesign.ImageOptions.Alignment = CType(resources.GetObject("colTreeLayersHiddenInDesign.ImageOptions.Alignment"), System.Drawing.StringAlignment)
        Me.colTreeLayersHiddenInDesign.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.designervisibility
        Me.colTreeLayersHiddenInDesign.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.colTreeLayersHiddenInDesign.Name = "colTreeLayersHiddenInDesign"
        Me.colTreeLayersHiddenInDesign.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[Boolean]
        '
        'colTreeLayersName
        '
        resources.ApplyResources(Me.colTreeLayersName, "colTreeLayersName")
        Me.colTreeLayersName.FieldName = "5"
        Me.colTreeLayersName.Name = "colTreeLayersName"
        Me.colTreeLayersName.OptionsColumn.AllowEdit = False
        Me.colTreeLayersName.OptionsColumn.ReadOnly = True
        Me.colTreeLayersName.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colTreeLayersCave
        '
        resources.ApplyResources(Me.colTreeLayersCave, "colTreeLayersCave")
        Me.colTreeLayersCave.FieldName = "6"
        Me.colTreeLayersCave.Name = "colTreeLayersCave"
        Me.colTreeLayersCave.OptionsColumn.AllowEdit = False
        Me.colTreeLayersCave.OptionsColumn.ReadOnly = True
        Me.colTreeLayersCave.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'colTreeLayersBranch
        '
        resources.ApplyResources(Me.colTreeLayersBranch, "colTreeLayersBranch")
        Me.colTreeLayersBranch.FieldName = "7"
        Me.colTreeLayersBranch.Name = "colTreeLayersBranch"
        Me.colTreeLayersBranch.OptionsColumn.AllowEdit = False
        Me.colTreeLayersBranch.OptionsColumn.ReadOnly = True
        Me.colTreeLayersBranch.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.[String]
        '
        'tvLayers
        '
        resources.ApplyResources(Me.tvLayers, "tvLayers")
        Me.tvLayers.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colTreeLayersType, Me.colTreeLayersCaveBranchColor, Me.colTreeLayersHiddenInPreview, Me.colTreeLayersHiddenInDesign, Me.colTreeLayersName, Me.colTreeLayersCave, Me.colTreeLayersBranch})
        Me.tvLayers.MinWidth = 16
        Me.tvLayers.Name = "tvLayers"
        Me.tvLayers.OptionsBehavior.Editable = False
        Me.tvLayers.OptionsBehavior.PopulateServiceColumns = True
        Me.tvLayers.OptionsBehavior.ReadOnly = True
        Me.tvLayers.OptionsCustomization.AllowColumnMoving = False
        Me.tvLayers.OptionsView.AutoWidth = False
        Me.tvLayers.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.tvLayers.OptionsView.ShowHorzLines = False
        Me.tvLayers.OptionsView.ShowIndicator = False
        Me.tvLayers.OptionsView.ShowVertLines = False
        Me.tvLayers.SelectImageList = Me.iml
        '
        'cItemObjectsBindingPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.btnPropObjectsSelect)
        Me.Controls.Add(Me.btnPropObjectsRefresh)
        Me.Controls.Add(Me.lblPropObjects)
        Me.Controls.Add(Me.tvLayers)
        Me.Name = "cItemObjectsBindingPropertyControl"
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tvLayers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPropObjectsSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPropObjectsRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropObjects As DevExpress.XtraEditors.LabelControl
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents colTreeLayersType As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersCaveBranchColor As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersHiddenInPreview As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersHiddenInDesign As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersName As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersCave As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents colTreeLayersBranch As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents tvLayers As DevExpress.XtraTreeList.TreeList
End Class
