<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersZOrder
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersZOrder))
        Me.tvCaveInfos = New System.Windows.Forms.TreeView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.chkKeepCaveAndBranchGrouped = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdMoveUp = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMoveDown = New DevExpress.XtraEditors.SimpleButton()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.colCaveBranch = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        Me.txtCaveBranch = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colZOrder = New DevExpress.XtraTreeList.Columns.TreeListColumn()
        CType(Me.chkKeepCaveAndBranchGrouped.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveBranch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvCaveInfos
        '
        resources.ApplyResources(Me.tvCaveInfos, "tvCaveInfos")
        Me.tvCaveInfos.ImageList = Me.iml
        Me.tvCaveInfos.Name = "tvCaveInfos"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "cave")
        Me.iml.Images.SetKeyName(1, "branch")
        Me.iml.Images.SetKeyName(2, "deleted")
        '
        'chkKeepCaveAndBranchGrouped
        '
        resources.ApplyResources(Me.chkKeepCaveAndBranchGrouped, "chkKeepCaveAndBranchGrouped")
        Me.chkKeepCaveAndBranchGrouped.Name = "chkKeepCaveAndBranchGrouped"
        Me.chkKeepCaveAndBranchGrouped.Properties.Caption = resources.GetString("chkKeepCaveAndBranchGrouped.Properties.Caption")
        '
        'cmdMoveUp
        '
        resources.ApplyResources(Me.cmdMoveUp, "cmdMoveUp")
        Me.cmdMoveUp.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.moveup
        Me.cmdMoveUp.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        '
        'cmdMoveDown
        '
        resources.ApplyResources(Me.cmdMoveDown, "cmdMoveDown")
        Me.cmdMoveDown.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.movedown
        Me.cmdMoveDown.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        '
        'TreeList1
        '
        resources.ApplyResources(Me.TreeList1, "TreeList1")
        Me.TreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colCaveBranch, Me.colZOrder})
        Me.TreeList1.KeyFieldName = "Path"
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsBehavior.ReadOnly = True
        Me.TreeList1.OptionsCustomization.AllowSort = False
        Me.TreeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFullFocus
        Me.TreeList1.OptionsView.ShowButtons = False
        Me.TreeList1.OptionsView.ShowIndentAsRowStyle = True
        Me.TreeList1.OptionsView.ShowIndicator = False
        Me.TreeList1.ParentFieldName = "Parent"
        Me.TreeList1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtCaveBranch})
        '
        'colCaveBranch
        '
        resources.ApplyResources(Me.colCaveBranch, "colCaveBranch")
        Me.colCaveBranch.ColumnEdit = Me.txtCaveBranch
        Me.colCaveBranch.FieldName = "ToHTMLShortString"
        Me.colCaveBranch.Name = "colCaveBranch"
        Me.colCaveBranch.OptionsFilter.AllowFilter = False
        '
        'txtCaveBranch
        '
        Me.txtCaveBranch.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtCaveBranch, "txtCaveBranch")
        Me.txtCaveBranch.Name = "txtCaveBranch"
        '
        'colZOrder
        '
        resources.ApplyResources(Me.colZOrder, "colZOrder")
        Me.colZOrder.FieldName = "ZOrder"
        Me.colZOrder.Name = "colZOrder"
        Me.colZOrder.OptionsColumn.AllowEdit = False
        Me.colZOrder.OptionsColumn.FixedWidth = True
        Me.colZOrder.OptionsColumn.ReadOnly = True
        '
        'frmParametersZOrder
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TreeList1)
        Me.Controls.Add(Me.cmdMoveDown)
        Me.Controls.Add(Me.cmdMoveUp)
        Me.Controls.Add(Me.chkKeepCaveAndBranchGrouped)
        Me.Controls.Add(Me.tvCaveInfos)
        Me.Name = "frmParametersZOrder"
        CType(Me.chkKeepCaveAndBranchGrouped.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveBranch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tvCaveInfos As System.Windows.Forms.TreeView
    Friend WithEvents chkKeepCaveAndBranchGrouped As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents cmdMoveUp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMoveDown As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents colCaveBranch As DevExpress.XtraTreeList.Columns.TreeListColumn
    Friend WithEvents txtCaveBranch As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colZOrder As DevExpress.XtraTreeList.Columns.TreeListColumn
End Class
