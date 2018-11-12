<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveRegisterAddMulti
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveRegisterAddMulti))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnNameRefresh = New System.Windows.Forms.Button()
        Me.cboSetting = New System.Windows.Forms.ComboBox()
        Me.lblService = New System.Windows.Forms.Label()
        Me.lvIDs = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuIDs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuIDsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIDsDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuIDsInvertSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuIDsCheckSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuIDs.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
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
        'lblPosition
        '
        resources.ApplyResources(Me.lblPosition, "lblPosition")
        Me.lblPosition.Name = "lblPosition"
        '
        'btnNameRefresh
        '
        resources.ApplyResources(Me.btnNameRefresh, "btnNameRefresh")
        Me.btnNameRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        Me.btnNameRefresh.Name = "btnNameRefresh"
        Me.tipDefault.SetToolTip(Me.btnNameRefresh, resources.GetString("btnNameRefresh.ToolTip"))
        Me.btnNameRefresh.UseVisualStyleBackColor = True
        '
        'cboSetting
        '
        Me.cboSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSetting.FormattingEnabled = True
        resources.ApplyResources(Me.cboSetting, "cboSetting")
        Me.cboSetting.Name = "cboSetting"
        '
        'lblService
        '
        resources.ApplyResources(Me.lblService, "lblService")
        Me.lblService.Name = "lblService"
        '
        'lvIDs
        '
        Me.lvIDs.CheckBoxes = True
        Me.lvIDs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colNome})
        Me.lvIDs.ContextMenuStrip = Me.mnuIDs
        Me.lvIDs.LabelEdit = True
        resources.ApplyResources(Me.lvIDs, "lvIDs")
        Me.lvIDs.Name = "lvIDs"
        Me.lvIDs.UseCompatibleStateImageBehavior = False
        Me.lvIDs.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        resources.ApplyResources(Me.colID, "colID")
        '
        'colNome
        '
        resources.ApplyResources(Me.colNome, "colNome")
        '
        'mnuIDs
        '
        resources.ApplyResources(Me.mnuIDs, "mnuIDs")
        Me.mnuIDs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuIDsSelectAll, Me.mnuIDsDeselectAll, Me.ToolStripMenuItem1, Me.mnuIDsInvertSelection, Me.ToolStripMenuItem2, Me.mnuIDsCheckSelected})
        Me.mnuIDs.Name = "mnuIDs"
        '
        'mnuIDsSelectAll
        '
        Me.mnuIDsSelectAll.Name = "mnuIDsSelectAll"
        resources.ApplyResources(Me.mnuIDsSelectAll, "mnuIDsSelectAll")
        '
        'mnuIDsDeselectAll
        '
        Me.mnuIDsDeselectAll.Name = "mnuIDsDeselectAll"
        resources.ApplyResources(Me.mnuIDsDeselectAll, "mnuIDsDeselectAll")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuIDsInvertSelection
        '
        Me.mnuIDsInvertSelection.Name = "mnuIDsInvertSelection"
        resources.ApplyResources(Me.mnuIDsInvertSelection, "mnuIDsInvertSelection")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuIDsCheckSelected
        '
        Me.mnuIDsCheckSelected.Name = "mnuIDsCheckSelected"
        resources.ApplyResources(Me.mnuIDsCheckSelected, "mnuIDsCheckSelected")
        '
        'frmCaveRegisterAddMulti
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.btnNameRefresh)
        Me.Controls.Add(Me.lvIDs)
        Me.Controls.Add(Me.cboSetting)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblService)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCaveRegisterAddMulti"
        Me.mnuIDs.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents cboSetting As System.Windows.Forms.ComboBox
    Friend WithEvents lblService As System.Windows.Forms.Label
    Friend WithEvents lvIDs As System.Windows.Forms.ListView
    Friend WithEvents btnNameRefresh As System.Windows.Forms.Button
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNome As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuIDs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuIDsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuIDsDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuIDsInvertSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuIDsCheckSelected As System.Windows.Forms.ToolStripMenuItem
End Class
