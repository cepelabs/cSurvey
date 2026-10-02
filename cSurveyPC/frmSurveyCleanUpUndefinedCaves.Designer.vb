<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurveyCleanUpUndefinedCaves
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurveyCleanUpUndefinedCaves))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colOldCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOldBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNewCave1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdNewCave = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colNewBranch1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdNewBranch = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveBranchListName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCaveBranchListName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNewCave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNewBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveBranchListName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.EmbeddedNavigator.Margin = CType(resources.GetObject("GridControl1.EmbeddedNavigator.Margin"), System.Windows.Forms.Padding)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.grdNewCave, Me.grdNewBranch})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colOldCave, Me.colOldBranch, Me.colNewCave1, Me.colNewBranch1})
        Me.GridView1.DetailHeight = 437
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
        Me.GridView1.OptionsEditForm.PopupEditFormWidth = 1000
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colOldCave
        '
        resources.ApplyResources(Me.colOldCave, "colOldCave")
        Me.colOldCave.FieldName = "Cave"
        Me.colOldCave.MinWidth = 25
        Me.colOldCave.Name = "colOldCave"
        Me.colOldCave.OptionsColumn.AllowEdit = False
        Me.colOldCave.OptionsColumn.ReadOnly = True
        '
        'colOldBranch
        '
        resources.ApplyResources(Me.colOldBranch, "colOldBranch")
        Me.colOldBranch.FieldName = "Branch"
        Me.colOldBranch.MinWidth = 25
        Me.colOldBranch.Name = "colOldBranch"
        Me.colOldBranch.OptionsColumn.AllowEdit = False
        Me.colOldBranch.OptionsColumn.ReadOnly = True
        '
        'colNewCave1
        '
        resources.ApplyResources(Me.colNewCave1, "colNewCave1")
        Me.colNewCave1.ColumnEdit = Me.grdNewCave
        Me.colNewCave1.FieldName = "NewCave"
        Me.colNewCave1.MinWidth = 25
        Me.colNewCave1.Name = "colNewCave1"
        '
        'grdNewCave
        '
        Me.grdNewCave.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.grdNewCave, "grdNewCave")
        Me.grdNewCave.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("grdNewCave.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.grdNewCave.DisplayMember = "ToHTMLString"
        Me.grdNewCave.Name = "grdNewCave"
        Me.grdNewCave.PopupView = Me.RepositoryItemGridLookUpEdit1View
        Me.grdNewCave.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveListName})
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveListName})
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'colCaveListName
        '
        resources.ApplyResources(Me.colCaveListName, "colCaveListName")
        Me.colCaveListName.ColumnEdit = Me.txtCaveListName
        Me.colCaveListName.FieldName = "ToHTMLString"
        Me.colCaveListName.Name = "colCaveListName"
        '
        'txtCaveListName
        '
        Me.txtCaveListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtCaveListName, "txtCaveListName")
        Me.txtCaveListName.Name = "txtCaveListName"
        Me.txtCaveListName.ReadOnly = True
        '
        'colNewBranch1
        '
        resources.ApplyResources(Me.colNewBranch1, "colNewBranch1")
        Me.colNewBranch1.ColumnEdit = Me.grdNewBranch
        Me.colNewBranch1.FieldName = "NewBranch"
        Me.colNewBranch1.MinWidth = 25
        Me.colNewBranch1.Name = "colNewBranch1"
        '
        'grdNewBranch
        '
        Me.grdNewBranch.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.grdNewBranch, "grdNewBranch")
        Me.grdNewBranch.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("grdNewBranch.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.grdNewBranch.DisplayMember = "ToHTMLString"
        Me.grdNewBranch.Name = "grdNewBranch"
        Me.grdNewBranch.PopupView = Me.GridView2
        Me.grdNewBranch.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveBranchListName})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveBranchListName})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'colCaveBranchListName
        '
        resources.ApplyResources(Me.colCaveBranchListName, "colCaveBranchListName")
        Me.colCaveBranchListName.ColumnEdit = Me.txtCaveBranchListName
        Me.colCaveBranchListName.FieldName = "ToHTMLString"
        Me.colCaveBranchListName.Name = "colCaveBranchListName"
        '
        'txtCaveBranchListName
        '
        Me.txtCaveBranchListName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtCaveBranchListName, "txtCaveBranchListName")
        Me.txtCaveBranchListName.Name = "txtCaveBranchListName"
        Me.txtCaveBranchListName.ReadOnly = True
        '
        'frmSurveyCleanUpUndefinedCaves
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.GridControl1)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.swissknife
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurveyCleanUpUndefinedCaves"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNewCave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveListName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNewBranch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveBranchListName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colOldCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOldBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNewCave1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNewBranch1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdNewCave As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdNewBranch As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txtCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
