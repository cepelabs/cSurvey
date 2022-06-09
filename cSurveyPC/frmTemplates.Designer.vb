<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTemplates
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTemplates))
        Me.pnlBottom = New DevExpress.XtraEditors.PanelControl()
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.txtName = New DevExpress.XtraEditors.TextEdit()
        Me.lblName = New DevExpress.XtraEditors.LabelControl()
        Me.pnlName = New DevExpress.XtraEditors.PanelControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnTemplateDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTemplateSetAsDefault = New DevExpress.XtraBars.BarCheckItem()
        Me.chkTemplatesDefault = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.grdViewTemplates = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTemplatesName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTemplatesDefault = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdTemplates = New DevExpress.XtraGrid.GridControl()
        Me.mnuTemplates = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlName.SuspendLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTemplatesDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlBottom.Controls.Add(Me.cmdClose)
        Me.pnlBottom.Controls.Add(Me.cmdCancel)
        Me.pnlBottom.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.pnlBottom, "pnlBottom")
        Me.pnlBottom.Name = "pnlBottom"
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
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
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'pnlName
        '
        Me.pnlName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlName.Controls.Add(Me.txtName)
        Me.pnlName.Controls.Add(Me.lblName)
        resources.ApplyResources(Me.pnlName, "pnlName")
        Me.pnlName.Name = "pnlName"
        '
        'BarManager
        '
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnTemplateDelete, Me.btnTemplateSetAsDefault})
        Me.BarManager.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'btnTemplateDelete
        '
        resources.ApplyResources(Me.btnTemplateDelete, "btnTemplateDelete")
        Me.btnTemplateDelete.Id = 0
        Me.btnTemplateDelete.Name = "btnTemplateDelete"
        '
        'btnTemplateSetAsDefault
        '
        resources.ApplyResources(Me.btnTemplateSetAsDefault, "btnTemplateSetAsDefault")
        Me.btnTemplateSetAsDefault.Id = 1
        Me.btnTemplateSetAsDefault.Name = "btnTemplateSetAsDefault"
        '
        'chkTemplatesDefault
        '
        resources.ApplyResources(Me.chkTemplatesDefault, "chkTemplatesDefault")
        Me.chkTemplatesDefault.Name = "chkTemplatesDefault"
        '
        'grdViewTemplates
        '
        Me.grdViewTemplates.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTemplatesName, Me.colTemplatesDefault})
        Me.grdViewTemplates.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.grdViewTemplates.GridControl = Me.grdTemplates
        Me.grdViewTemplates.Name = "grdViewTemplates"
        Me.grdViewTemplates.OptionsCustomization.AllowGroup = False
        Me.grdViewTemplates.OptionsView.ShowGroupPanel = False
        Me.grdViewTemplates.OptionsView.ShowIndicator = False
        '
        'colTemplatesName
        '
        resources.ApplyResources(Me.colTemplatesName, "colTemplatesName")
        Me.colTemplatesName.FieldName = "Name"
        Me.colTemplatesName.Name = "colTemplatesName"
        Me.colTemplatesName.OptionsColumn.AllowEdit = False
        Me.colTemplatesName.OptionsColumn.ReadOnly = True
        '
        'colTemplatesDefault
        '
        resources.ApplyResources(Me.colTemplatesDefault, "colTemplatesDefault")
        Me.colTemplatesDefault.ColumnEdit = Me.chkTemplatesDefault
        Me.colTemplatesDefault.FieldName = "Default"
        Me.colTemplatesDefault.MaxWidth = 64
        Me.colTemplatesDefault.Name = "colTemplatesDefault"
        '
        'grdTemplates
        '
        Me.grdTemplates.AllowDrop = True
        resources.ApplyResources(Me.grdTemplates, "grdTemplates")
        Me.grdTemplates.MainView = Me.grdViewTemplates
        Me.grdTemplates.Name = "grdTemplates"
        Me.grdTemplates.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkTemplatesDefault})
        Me.grdTemplates.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewTemplates})
        '
        'mnuTemplates
        '
        Me.mnuTemplates.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnTemplateDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.btnTemplateSetAsDefault, True)})
        Me.mnuTemplates.Manager = Me.BarManager
        Me.mnuTemplates.Name = "mnuTemplates"
        '
        'frmTemplates
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.grdTemplates)
        Me.Controls.Add(Me.pnlName)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.ShowIcon = False
        Me.MinimizeBox = False
        Me.Name = "frmTemplates"
        CType(Me.pnlBottom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlName.ResumeLayout(False)
        Me.pnlName.PerformLayout()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTemplatesDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlBottom As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents pnlName As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents grdTemplates As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewTemplates As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTemplatesName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTemplatesDefault As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents chkTemplatesDefault As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents btnTemplateDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTemplateSetAsDefault As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents mnuTemplates As DevExpress.XtraBars.PopupMenu
End Class
