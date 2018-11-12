<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSegmentsReplicateInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSegmentsReplicateInfo))
        Me.chkCave = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.chkSession = New System.Windows.Forms.CheckBox()
        Me.chkRebind = New System.Windows.Forms.CheckBox()
        Me.cboCaveBranchList = New System.Windows.Forms.ComboBox()
        Me.cboCaveList = New System.Windows.Forms.ComboBox()
        Me.cboSessionList = New System.Windows.Forms.ComboBox()
        Me.chkFormula = New System.Windows.Forms.CheckBox()
        Me.cmdEditFormula = New System.Windows.Forms.Button()
        Me.cboReplicateTo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkDirection = New System.Windows.Forms.CheckBox()
        Me.cboDirection = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkCave
        '
        resources.ApplyResources(Me.chkCave, "chkCave")
        Me.chkCave.Name = "chkCave"
        Me.chkCave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'chkSession
        '
        resources.ApplyResources(Me.chkSession, "chkSession")
        Me.chkSession.Name = "chkSession"
        Me.chkSession.UseVisualStyleBackColor = True
        '
        'chkRebind
        '
        resources.ApplyResources(Me.chkRebind, "chkRebind")
        Me.chkRebind.Name = "chkRebind"
        Me.chkRebind.UseVisualStyleBackColor = True
        '
        'cboCaveBranchList
        '
        Me.cboCaveBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCaveBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaveBranchList.DropDownWidth = 320
        resources.ApplyResources(Me.cboCaveBranchList, "cboCaveBranchList")
        Me.cboCaveBranchList.Name = "cboCaveBranchList"
        '
        'cboCaveList
        '
        Me.cboCaveList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboCaveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaveList.DropDownWidth = 320
        resources.ApplyResources(Me.cboCaveList, "cboCaveList")
        Me.cboCaveList.Name = "cboCaveList"
        '
        'cboSessionList
        '
        Me.cboSessionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSessionList.DropDownWidth = 320
        resources.ApplyResources(Me.cboSessionList, "cboSessionList")
        Me.cboSessionList.Name = "cboSessionList"
        '
        'chkFormula
        '
        resources.ApplyResources(Me.chkFormula, "chkFormula")
        Me.chkFormula.Name = "chkFormula"
        Me.chkFormula.UseVisualStyleBackColor = True
        '
        'cmdEditFormula
        '
        resources.ApplyResources(Me.cmdEditFormula, "cmdEditFormula")
        Me.cmdEditFormula.Image = Global.cSurveyPC.My.Resources.Resources.edit_mathematics
        Me.cmdEditFormula.Name = "cmdEditFormula"
        Me.cmdEditFormula.UseVisualStyleBackColor = True
        '
        'cboReplicateTo
        '
        Me.cboReplicateTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReplicateTo.FormattingEnabled = True
        Me.cboReplicateTo.Items.AddRange(New Object() {resources.GetString("cboReplicateTo.Items"), resources.GetString("cboReplicateTo.Items1"), resources.GetString("cboReplicateTo.Items2"), resources.GetString("cboReplicateTo.Items3")})
        resources.ApplyResources(Me.cboReplicateTo, "cboReplicateTo")
        Me.cboReplicateTo.Name = "cboReplicateTo"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Name = "Label2"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cboReplicateTo)
        Me.Panel1.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'chkDirection
        '
        resources.ApplyResources(Me.chkDirection, "chkDirection")
        Me.chkDirection.Name = "chkDirection"
        Me.chkDirection.UseVisualStyleBackColor = True
        '
        'cboDirection
        '
        Me.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDirection.DropDownWidth = 320
        Me.cboDirection.FormattingEnabled = True
        Me.cboDirection.Items.AddRange(New Object() {resources.GetString("cboDirection.Items"), resources.GetString("cboDirection.Items1")})
        resources.ApplyResources(Me.cboDirection, "cboDirection")
        Me.cboDirection.Name = "cboDirection"
        '
        'frmSegmentsReplicateInfo
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cboDirection)
        Me.Controls.Add(Me.chkDirection)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdEditFormula)
        Me.Controls.Add(Me.chkFormula)
        Me.Controls.Add(Me.cboCaveBranchList)
        Me.Controls.Add(Me.cboCaveList)
        Me.Controls.Add(Me.cboSessionList)
        Me.Controls.Add(Me.chkRebind)
        Me.Controls.Add(Me.chkSession)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkCave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSegmentsReplicateInfo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkCave As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents chkSession As System.Windows.Forms.CheckBox
    Friend WithEvents chkRebind As System.Windows.Forms.CheckBox
    Friend WithEvents cboCaveBranchList As System.Windows.Forms.ComboBox
    Friend WithEvents cboCaveList As System.Windows.Forms.ComboBox
    Friend WithEvents cboSessionList As System.Windows.Forms.ComboBox
    Friend WithEvents chkFormula As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEditFormula As System.Windows.Forms.Button
    Friend WithEvents cboReplicateTo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkDirection As CheckBox
    Friend WithEvents cboDirection As ComboBox
End Class
