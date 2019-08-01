<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUndoManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUndoManager))
        Me.lvUndoStack = New System.Windows.Forms.ListView()
        Me.colUndoAction = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUndoDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUndoDateStamp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClean = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCancel = New System.Windows.Forms.ToolStripButton()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvUndoStack
        '
        Me.lvUndoStack.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colUndoAction, Me.colUndoDescription, Me.colUndoDateStamp})
        resources.ApplyResources(Me.lvUndoStack, "lvUndoStack")
        Me.lvUndoStack.FullRowSelect = True
        Me.lvUndoStack.HideSelection = False
        Me.lvUndoStack.MultiSelect = False
        Me.lvUndoStack.Name = "lvUndoStack"
        Me.lvUndoStack.SmallImageList = Me.iml
        Me.lvUndoStack.UseCompatibleStateImageBehavior = False
        Me.lvUndoStack.View = System.Windows.Forms.View.Details
        '
        'colUndoAction
        '
        resources.ApplyResources(Me.colUndoAction, "colUndoAction")
        '
        'colUndoDescription
        '
        resources.ApplyResources(Me.colUndoDescription, "colUndoDescription")
        '
        'colUndoDateStamp
        '
        resources.ApplyResources(Me.colUndoDateStamp, "colUndoDateStamp")
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "shape_square_edit.png")
        Me.iml.Images.SetKeyName(1, "shape_square_add.png")
        Me.iml.Images.SetKeyName(2, "shape_square_delete.png")
        Me.iml.Images.SetKeyName(3, "shape_square_go.png")
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnUndo, Me.ToolStripSeparator3, Me.btnClean, Me.ToolStripSeparator1, Me.btnCancel})
        Me.tbMain.Name = "tbMain"
        '
        'btnUndo
        '
        Me.btnUndo.Image = Global.cSurveyPC.My.Resources.Resources.arrow_undo
        resources.ApplyResources(Me.btnUndo, "btnUndo")
        Me.btnUndo.Name = "btnUndo"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnClean
        '
        Me.btnClean.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnClean, "btnClean")
        Me.btnClean.Name = "btnClean"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnCancel
        '
        Me.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        '
        'frmUndoManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lvUndoStack)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUndoManager"
        Me.ShowInTaskbar = False
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvUndoStack As System.Windows.Forms.ListView
    Friend WithEvents colUndoAction As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUndoDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents colUndoDateStamp As System.Windows.Forms.ColumnHeader
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClean As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCancel As System.Windows.Forms.ToolStripButton
End Class
