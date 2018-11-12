<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextPopup
    Inherits cDockContentWindow

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTextPopup))
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnTextFromClipboard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.cboPropTextSize = New System.Windows.Forms.ComboBox()
        Me.lblPropTextSize = New System.Windows.Forms.Label()
        Me.lblPropTextStyle = New System.Windows.Forms.Label()
        Me.cboPropTextStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnTextFromClipboard, Me.ToolStripSeparator3, Me.btnAdd, Me.ToolStripSeparator1, Me.btnRemove, Me.ToolStripSeparator2, Me.btnRefresh})
        Me.tbMain.Name = "tbMain"
        '
        'btnTextFromClipboard
        '
        Me.btnTextFromClipboard.Image = Global.cSurveyPC.My.Resources.Resources.clipboard_sign
        resources.ApplyResources(Me.btnTextFromClipboard, "btnTextFromClipboard")
        Me.btnTextFromClipboard.Name = "btnTextFromClipboard"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.cSurveyPC.My.Resources.Resources.pencil_go
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnRemove
        '
        Me.btnRemove.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Name = "btnRefresh"
        '
        'txtText
        '
        resources.ApplyResources(Me.txtText, "txtText")
        Me.txtText.Name = "txtText"
        '
        'cboPropTextSize
        '
        Me.cboPropTextSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextSize.FormattingEnabled = True
        Me.cboPropTextSize.Items.AddRange(New Object() {resources.GetString("cboPropTextSize.Items"), resources.GetString("cboPropTextSize.Items1"), resources.GetString("cboPropTextSize.Items2"), resources.GetString("cboPropTextSize.Items3"), resources.GetString("cboPropTextSize.Items4"), resources.GetString("cboPropTextSize.Items5")})
        resources.ApplyResources(Me.cboPropTextSize, "cboPropTextSize")
        Me.cboPropTextSize.Name = "cboPropTextSize"
        '
        'lblPropTextSize
        '
        resources.ApplyResources(Me.lblPropTextSize, "lblPropTextSize")
        Me.lblPropTextSize.Name = "lblPropTextSize"
        '
        'lblPropTextStyle
        '
        resources.ApplyResources(Me.lblPropTextStyle, "lblPropTextStyle")
        Me.lblPropTextStyle.Name = "lblPropTextStyle"
        '
        'cboPropTextStyle
        '
        resources.ApplyResources(Me.cboPropTextStyle, "cboPropTextStyle")
        Me.cboPropTextStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropTextStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextStyle.FormattingEnabled = True
        Me.cboPropTextStyle.Items.AddRange(New Object() {resources.GetString("cboPropTextStyle.Items"), resources.GetString("cboPropTextStyle.Items1"), resources.GetString("cboPropTextStyle.Items2"), resources.GetString("cboPropTextStyle.Items3")})
        Me.cboPropTextStyle.Name = "cboPropTextStyle"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'frmTextPopup
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPropTextSize)
        Me.Controls.Add(Me.lblPropTextSize)
        Me.Controls.Add(Me.lblPropTextStyle)
        Me.Controls.Add(Me.cboPropTextStyle)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmTextPopup"
        Me.ShowInTaskbar = False
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnTextFromClipboard As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents cboPropTextSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropTextSize As System.Windows.Forms.Label
    Friend WithEvents lblPropTextStyle As System.Windows.Forms.Label
    Friend WithEvents cboPropTextStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
