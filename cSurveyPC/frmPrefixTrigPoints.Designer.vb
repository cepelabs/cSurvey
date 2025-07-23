<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrefixTrigPoints
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrefixTrigPoints))
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button2 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.Button3 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button4 = New DevExpress.XtraEditors.SimpleButton()
        Me.chkShowSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.optRemove = New DevExpress.XtraEditors.CheckButton()
        Me.optAdd = New DevExpress.XtraEditors.CheckButton()
        Me.listbox1 = New DevExpress.XtraGrid.GridControl()
        Me.grdView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.col1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.listbox2 = New DevExpress.XtraGrid.GridControl()
        Me.grdView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.col2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.optReplace = New DevExpress.XtraEditors.CheckButton()
        Me.txtPrefixTo = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefixTo = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listbox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.listbox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefixTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.Appearance.Font = CType(resources.GetObject("txtPrefix.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPrefix.Properties.Appearance.Options.UseFont = True
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
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
        Me.cmdOk.Name = "cmdOk"
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        '
        'Button4
        '
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.Name = "Button4"
        '
        'chkShowSplay
        '
        resources.ApplyResources(Me.chkShowSplay, "chkShowSplay")
        Me.chkShowSplay.Name = "chkShowSplay"
        Me.chkShowSplay.Properties.Caption = resources.GetString("chkShowSplay.Properties.Caption")
        '
        'optRemove
        '
        resources.ApplyResources(Me.optRemove, "optRemove")
        Me.optRemove.GroupIndex = 1
        Me.optRemove.Name = "optRemove"
        Me.optRemove.TabStop = False
        '
        'optAdd
        '
        resources.ApplyResources(Me.optAdd, "optAdd")
        Me.optAdd.Checked = True
        Me.optAdd.GroupIndex = 1
        Me.optAdd.Name = "optAdd"
        '
        'listbox1
        '
        resources.ApplyResources(Me.listbox1, "listbox1")
        Me.listbox1.MainView = Me.grdView1
        Me.listbox1.Name = "listbox1"
        Me.listbox1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdView1})
        '
        'grdView1
        '
        Me.grdView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.col1})
        Me.grdView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.grdView1.GridControl = Me.listbox1
        Me.grdView1.Name = "grdView1"
        Me.grdView1.OptionsBehavior.Editable = False
        Me.grdView1.OptionsBehavior.ReadOnly = True
        Me.grdView1.OptionsCustomization.AllowGroup = False
        Me.grdView1.OptionsSelection.MultiSelect = True
        Me.grdView1.OptionsView.ShowColumnHeaders = False
        Me.grdView1.OptionsView.ShowGroupPanel = False
        Me.grdView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.col1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'col1
        '
        resources.ApplyResources(Me.col1, "col1")
        Me.col1.FieldName = "Name"
        Me.col1.Name = "col1"
        '
        'listbox2
        '
        resources.ApplyResources(Me.listbox2, "listbox2")
        Me.listbox2.MainView = Me.grdView2
        Me.listbox2.Name = "listbox2"
        Me.listbox2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdView2})
        '
        'grdView2
        '
        Me.grdView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.col2})
        Me.grdView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus
        Me.grdView2.GridControl = Me.listbox2
        Me.grdView2.Name = "grdView2"
        Me.grdView2.OptionsBehavior.Editable = False
        Me.grdView2.OptionsBehavior.ReadOnly = True
        Me.grdView2.OptionsCustomization.AllowGroup = False
        Me.grdView2.OptionsSelection.MultiSelect = True
        Me.grdView2.OptionsView.ShowColumnHeaders = False
        Me.grdView2.OptionsView.ShowGroupPanel = False
        Me.grdView2.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.col2, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'col2
        '
        resources.ApplyResources(Me.col2, "col2")
        Me.col2.FieldName = "Name"
        Me.col2.Name = "col2"
        '
        'optReplace
        '
        resources.ApplyResources(Me.optReplace, "optReplace")
        Me.optReplace.GroupIndex = 1
        Me.optReplace.Name = "optReplace"
        Me.optReplace.TabStop = False
        '
        'txtPrefixTo
        '
        resources.ApplyResources(Me.txtPrefixTo, "txtPrefixTo")
        Me.txtPrefixTo.Name = "txtPrefixTo"
        Me.txtPrefixTo.Properties.Appearance.Font = CType(resources.GetObject("txtPrefixTo.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPrefixTo.Properties.Appearance.Options.UseFont = True
        Me.txtPrefixTo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefixTo
        '
        Me.lblPrefixTo.Appearance.Font = CType(resources.GetObject("lblPrefixTo.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefixTo.Appearance.Options.UseFont = True
        Me.lblPrefixTo.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_arrow4right
        Me.lblPrefixTo.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.lblPrefixTo, "lblPrefixTo")
        Me.lblPrefixTo.Name = "lblPrefixTo"
        '
        'frmPrefixTrigPoints
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblPrefixTo)
        Me.Controls.Add(Me.txtPrefixTo)
        Me.Controls.Add(Me.optReplace)
        Me.Controls.Add(Me.listbox2)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.optRemove)
        Me.Controls.Add(Me.optAdd)
        Me.Controls.Add(Me.chkShowSplay)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.listbox1)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.addprefix
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrefixTrigPoints"
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listbox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.listbox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefixTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkShowSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents optAdd As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optRemove As DevExpress.XtraEditors.CheckButton
    Friend WithEvents listbox1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents col1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents listbox2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents col2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents optReplace As DevExpress.XtraEditors.CheckButton
    Friend WithEvents txtPrefixTo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefixTo As DevExpress.XtraEditors.LabelControl
End Class
