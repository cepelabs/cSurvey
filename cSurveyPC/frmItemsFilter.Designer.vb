<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemsFilter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemsFilter))
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPropDesignDataProperties = New System.Windows.Forms.Label()
        Me.prpDataProperties = New System.Windows.Forms.PropertyGrid()
        Me.mnuDataProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesignDataPropertiesDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboCategories = New System.Windows.Forms.ComboBox()
        Me.lblPropCategory = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPropCave = New System.Windows.Forms.Label()
        Me.cboCaveBranchList = New System.Windows.Forms.ComboBox()
        Me.cboCaveList = New System.Windows.Forms.ComboBox()
        Me.tabUserProperties = New System.Windows.Forms.TabPage()
        Me.chkReversed = New System.Windows.Forms.CheckBox()
        Me.mnuDataProperties.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabUserProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
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
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'lblPropDesignDataProperties
        '
        resources.ApplyResources(Me.lblPropDesignDataProperties, "lblPropDesignDataProperties")
        Me.lblPropDesignDataProperties.Name = "lblPropDesignDataProperties"
        '
        'prpDataProperties
        '
        Me.prpDataProperties.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.prpDataProperties.CommandsVisibleIfAvailable = False
        Me.prpDataProperties.ContextMenuStrip = Me.mnuDataProperties
        resources.ApplyResources(Me.prpDataProperties, "prpDataProperties")
        Me.prpDataProperties.LineColor = System.Drawing.SystemColors.ControlDark
        Me.prpDataProperties.Name = "prpDataProperties"
        Me.prpDataProperties.ToolbarVisible = False
        '
        'mnuDataProperties
        '
        resources.ApplyResources(Me.mnuDataProperties, "mnuDataProperties")
        Me.mnuDataProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignDataPropertiesDelete})
        Me.mnuDataProperties.Name = "mnuSegmentsDataFields"
        '
        'mnuDesignDataPropertiesDelete
        '
        Me.mnuDesignDataPropertiesDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuDesignDataPropertiesDelete.Name = "mnuDesignDataPropertiesDelete"
        resources.ApplyResources(Me.mnuDesignDataPropertiesDelete, "mnuDesignDataPropertiesDelete")
        '
        'cboCategories
        '
        Me.cboCategories.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboCategories, "cboCategories")
        Me.cboCategories.Name = "cboCategories"
        '
        'lblPropCategory
        '
        resources.ApplyResources(Me.lblPropCategory, "lblPropCategory")
        Me.lblPropCategory.Name = "lblPropCategory"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.tabMain)
        Me.TabControl1.Controls.Add(Me.tabUserProperties)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.Label1)
        Me.tabMain.Controls.Add(Me.lblPropCave)
        Me.tabMain.Controls.Add(Me.cboCaveBranchList)
        Me.tabMain.Controls.Add(Me.cboCaveList)
        Me.tabMain.Controls.Add(Me.cboCategories)
        Me.tabMain.Controls.Add(Me.lblPropCategory)
        Me.tabMain.Controls.Add(Me.Label6)
        Me.tabMain.Controls.Add(Me.txtName)
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Name = "tabMain"
        Me.tabMain.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblPropCave
        '
        resources.ApplyResources(Me.lblPropCave, "lblPropCave")
        Me.lblPropCave.Name = "lblPropCave"
        '
        'cboCaveBranchList
        '
        resources.ApplyResources(Me.cboCaveBranchList, "cboCaveBranchList")
        Me.cboCaveBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCaveBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaveBranchList.DropDownWidth = 320
        Me.cboCaveBranchList.Name = "cboCaveBranchList"
        '
        'cboCaveList
        '
        resources.ApplyResources(Me.cboCaveList, "cboCaveList")
        Me.cboCaveList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCaveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaveList.DropDownWidth = 320
        Me.cboCaveList.Name = "cboCaveList"
        '
        'tabUserProperties
        '
        Me.tabUserProperties.Controls.Add(Me.prpDataProperties)
        Me.tabUserProperties.Controls.Add(Me.lblPropDesignDataProperties)
        resources.ApplyResources(Me.tabUserProperties, "tabUserProperties")
        Me.tabUserProperties.Name = "tabUserProperties"
        Me.tabUserProperties.UseVisualStyleBackColor = True
        '
        'chkReversed
        '
        resources.ApplyResources(Me.chkReversed, "chkReversed")
        Me.chkReversed.Name = "chkReversed"
        Me.chkReversed.UseVisualStyleBackColor = True
        '
        'frmItemsFilter
        '
        Me.AcceptButton = Me.cmdApply
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkReversed)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemsFilter"
        Me.mnuDataProperties.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.tabUserProperties.ResumeLayout(False)
        Me.tabUserProperties.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblPropDesignDataProperties As System.Windows.Forms.Label
    Friend WithEvents prpDataProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents cboCategories As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropCategory As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents mnuDataProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesignDataPropertiesDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkReversed As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPropCave As System.Windows.Forms.Label
    Friend WithEvents cboCaveBranchList As System.Windows.Forms.ComboBox
    Friend WithEvents cboCaveList As System.Windows.Forms.ComboBox
    Friend WithEvents tabUserProperties As System.Windows.Forms.TabPage
End Class
