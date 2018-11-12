<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmJoinPointsPopup
    Inherits cDockContentWindow

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJoinPointsPopup))
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLink = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.lv = New System.Windows.Forms.ListView()
        Me.colXY = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colJoin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuLv = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLvSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvJoin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.tbMain.SuspendLayout()
        Me.mnuLv.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRemove, Me.ToolStripSeparator2, Me.btnLink, Me.ToolStripSeparator3, Me.btnCancel})
        Me.tbMain.Name = "tbMain"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.btnRemove.Name = "btnRemove"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnLink
        '
        resources.ApplyResources(Me.btnLink, "btnLink")
        Me.btnLink.Image = Global.cSurveyPC.My.Resources.Resources.arrow_in_red
        Me.btnLink.Name = "btnLink"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnCancel
        '
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        '
        'lv
        '
        Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colXY, Me.colJoin})
        Me.lv.ContextMenuStrip = Me.mnuLv
        resources.ApplyResources(Me.lv, "lv")
        Me.lv.FullRowSelect = True
        Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lv.HideSelection = False
        Me.lv.MultiSelect = False
        Me.lv.Name = "lv"
        Me.lv.SmallImageList = Me.iml
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'colXY
        '
        resources.ApplyResources(Me.colXY, "colXY")
        '
        'colJoin
        '
        resources.ApplyResources(Me.colJoin, "colJoin")
        '
        'mnuLv
        '
        resources.ApplyResources(Me.mnuLv, "mnuLv")
        Me.mnuLv.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLvSelect, Me.ToolStripMenuItem3, Me.mnuLvRemove, Me.ToolStripMenuItem2, Me.mnuLvJoin, Me.ToolStripMenuItem1, Me.mnuLvCancel})
        Me.mnuLv.Name = "mnuLv"
        '
        'mnuLvSelect
        '
        resources.ApplyResources(Me.mnuLvSelect, "mnuLvSelect")
        Me.mnuLvSelect.Name = "mnuLvSelect"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuLvRemove
        '
        resources.ApplyResources(Me.mnuLvRemove, "mnuLvRemove")
        Me.mnuLvRemove.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuLvRemove.Name = "mnuLvRemove"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuLvJoin
        '
        resources.ApplyResources(Me.mnuLvJoin, "mnuLvJoin")
        Me.mnuLvJoin.Image = Global.cSurveyPC.My.Resources.Resources.arrow_in_red
        Me.mnuLvJoin.Name = "mnuLvJoin"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuLvCancel
        '
        Me.mnuLvCancel.Name = "mnuLvCancel"
        resources.ApplyResources(Me.mnuLvCancel, "mnuLvCancel")
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "point")
        Me.iml.Images.SetKeyName(1, "joinedpoint")
        Me.iml.Images.SetKeyName(2, "beginpoint")
        '
        'frmJoinPointsPopup
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJoinPointsPopup"
        Me.ShowInTaskbar = False
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.mnuLv.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnLink As System.Windows.Forms.ToolStripButton
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents colXY As System.Windows.Forms.ColumnHeader
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuLv As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuLvJoin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLvCancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLvRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colJoin As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuLvSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
End Class
