<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoDistances
    Inherits cForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoDistances))
        Me.pnlSurveyRing = New System.Windows.Forms.Panel()
        Me.cmdFilter = New System.Windows.Forms.Button()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.txtMaxDistance = New System.Windows.Forms.TextBox()
        Me.lblMaxDistance = New System.Windows.Forms.Label()
        Me.lblDistanceMode = New System.Windows.Forms.Label()
        Me.cboDistanceMode = New System.Windows.Forms.ComboBox()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grdSurveyDistances = New cSurveyPC.cGrid()
        Me.mnuSurveyDistances = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSurveyDistancesCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSurveyDistancesCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSurveyDistancesExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSurveyDistancesRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.chkSplays = New System.Windows.Forms.CheckBox()
        Me.pnlSurveyRing.SuspendLayout()
        CType(Me.grdSurveyDistances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSurveyDistances.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSurveyRing
        '
        resources.ApplyResources(Me.pnlSurveyRing, "pnlSurveyRing")
        Me.pnlSurveyRing.Controls.Add(Me.chkSplays)
        Me.pnlSurveyRing.Controls.Add(Me.cmdFilter)
        Me.pnlSurveyRing.Controls.Add(Me.cmdRefresh)
        Me.pnlSurveyRing.Controls.Add(Me.txtMaxDistance)
        Me.pnlSurveyRing.Controls.Add(Me.lblMaxDistance)
        Me.pnlSurveyRing.Controls.Add(Me.lblDistanceMode)
        Me.pnlSurveyRing.Controls.Add(Me.cboDistanceMode)
        Me.pnlSurveyRing.Controls.Add(Me.txtFilter)
        Me.pnlSurveyRing.Controls.Add(Me.Label4)
        Me.pnlSurveyRing.Controls.Add(Me.grdSurveyDistances)
        Me.pnlSurveyRing.Name = "pnlSurveyRing"
        '
        'cmdFilter
        '
        Me.cmdFilter.Image = Global.cSurveyPC.My.Resources.Resources.to_do_list
        resources.ApplyResources(Me.cmdFilter, "cmdFilter")
        Me.cmdFilter.Name = "cmdFilter"
        Me.cmdFilter.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh_small
        resources.ApplyResources(Me.cmdRefresh, "cmdRefresh")
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'txtMaxDistance
        '
        resources.ApplyResources(Me.txtMaxDistance, "txtMaxDistance")
        Me.txtMaxDistance.BackColor = System.Drawing.SystemColors.Control
        Me.txtMaxDistance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMaxDistance.Name = "txtMaxDistance"
        '
        'lblMaxDistance
        '
        resources.ApplyResources(Me.lblMaxDistance, "lblMaxDistance")
        Me.lblMaxDistance.Name = "lblMaxDistance"
        '
        'lblDistanceMode
        '
        resources.ApplyResources(Me.lblDistanceMode, "lblDistanceMode")
        Me.lblDistanceMode.Name = "lblDistanceMode"
        '
        'cboDistanceMode
        '
        Me.cboDistanceMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistanceMode.FormattingEnabled = True
        Me.cboDistanceMode.Items.AddRange(New Object() {resources.GetString("cboDistanceMode.Items"), resources.GetString("cboDistanceMode.Items1"), resources.GetString("cboDistanceMode.Items2"), resources.GetString("cboDistanceMode.Items3"), resources.GetString("cboDistanceMode.Items4"), resources.GetString("cboDistanceMode.Items5"), resources.GetString("cboDistanceMode.Items6")})
        resources.ApplyResources(Me.cboDistanceMode, "cboDistanceMode")
        Me.cboDistanceMode.Name = "cboDistanceMode"
        '
        'txtFilter
        '
        Me.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.txtFilter, "txtFilter")
        Me.txtFilter.Name = "txtFilter"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'grdSurveyDistances
        '
        Me.grdSurveyDistances.AllowUserToAddRows = False
        Me.grdSurveyDistances.AllowUserToDeleteRows = False
        Me.grdSurveyDistances.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdSurveyDistances, "grdSurveyDistances")
        Me.grdSurveyDistances.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdSurveyDistances.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdSurveyDistances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSurveyDistances.ContextMenuStrip = Me.mnuSurveyDistances
        Me.grdSurveyDistances.Name = "grdSurveyDistances"
        Me.grdSurveyDistances.ReadOnly = True
        Me.grdSurveyDistances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grdSurveyDistances.ShowCellErrors = False
        Me.grdSurveyDistances.ShowEditingIcon = False
        Me.grdSurveyDistances.ShowRowErrors = False
        '
        'mnuSurveyDistances
        '
        resources.ApplyResources(Me.mnuSurveyDistances, "mnuSurveyDistances")
        Me.mnuSurveyDistances.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSurveyDistancesCopy, Me.mnuSurveyDistancesCopyAll, Me.ToolStripMenuItem1, Me.mnuSurveyDistancesExport, Me.ToolStripMenuItem2, Me.mnuSurveyDistancesRefresh})
        Me.mnuSurveyDistances.Name = "mnuSegmentInfo"
        '
        'mnuSurveyDistancesCopy
        '
        Me.mnuSurveyDistancesCopy.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        Me.mnuSurveyDistancesCopy.Name = "mnuSurveyDistancesCopy"
        resources.ApplyResources(Me.mnuSurveyDistancesCopy, "mnuSurveyDistancesCopy")
        '
        'mnuSurveyDistancesCopyAll
        '
        Me.mnuSurveyDistancesCopyAll.Name = "mnuSurveyDistancesCopyAll"
        resources.ApplyResources(Me.mnuSurveyDistancesCopyAll, "mnuSurveyDistancesCopyAll")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuSurveyDistancesExport
        '
        Me.mnuSurveyDistancesExport.Name = "mnuSurveyDistancesExport"
        resources.ApplyResources(Me.mnuSurveyDistancesExport, "mnuSurveyDistancesExport")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuSurveyDistancesRefresh
        '
        Me.mnuSurveyDistancesRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh_small
        Me.mnuSurveyDistancesRefresh.Name = "mnuSurveyDistancesRefresh"
        resources.ApplyResources(Me.mnuSurveyDistancesRefresh, "mnuSurveyDistancesRefresh")
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'chkSplays
        '
        resources.ApplyResources(Me.chkSplays, "chkSplays")
        Me.chkSplays.Name = "chkSplays"
        Me.chkSplays.UseVisualStyleBackColor = True
        '
        'frmInfoDistances
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlSurveyRing)
        Me.Controls.Add(Me.cmdClose)
        Me.MinimizeBox = False
        Me.Name = "frmInfoDistances"
        Me.pnlSurveyRing.ResumeLayout(False)
        Me.pnlSurveyRing.PerformLayout()
        CType(Me.grdSurveyDistances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSurveyDistances.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSurveyRing As System.Windows.Forms.Panel
    Friend WithEvents txtFilter As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdSurveyDistances As cSurveyPC.cGrid
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents lblDistanceMode As System.Windows.Forms.Label
    Friend WithEvents cboDistanceMode As System.Windows.Forms.ComboBox
    Friend WithEvents txtMaxDistance As System.Windows.Forms.TextBox
    Friend WithEvents lblMaxDistance As System.Windows.Forms.Label
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents mnuSurveyDistances As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSurveyDistancesCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSurveyDistancesCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSurveyDistancesRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdFilter As System.Windows.Forms.Button
    Friend WithEvents mnuSurveyDistancesExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkSplays As CheckBox
End Class
