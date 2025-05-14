Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMasterSlaveManager
    Inherits XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterSlaveManager))
        Me.cmdSetAsMaster = New System.Windows.Forms.Button()
        Me.cmdSetAsSlave = New System.Windows.Forms.Button()
        Me.tvCaveInfos = New System.Windows.Forms.TreeView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdJoin = New System.Windows.Forms.Button()
        Me.pnlSetAsMaster = New System.Windows.Forms.Panel()
        Me.pnlSetAsSlave = New System.Windows.Forms.Panel()
        Me.cmdLock = New System.Windows.Forms.Button()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.pnlJoin = New System.Windows.Forms.Panel()
        Me.pnlSetAsMaster.SuspendLayout()
        Me.pnlSetAsSlave.SuspendLayout()
        Me.pnlJoin.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSetAsMaster
        '
        Me.cmdSetAsMaster.Location = New System.Drawing.Point(12, 12)
        Me.cmdSetAsMaster.Name = "cmdSetAsMaster"
        Me.cmdSetAsMaster.Size = New System.Drawing.Size(160, 50)
        Me.cmdSetAsMaster.TabIndex = 0
        Me.cmdSetAsMaster.Text = "Set as master"
        Me.cmdSetAsMaster.UseVisualStyleBackColor = True
        '
        'cmdSetAsSlave
        '
        Me.cmdSetAsSlave.Location = New System.Drawing.Point(12, 153)
        Me.cmdSetAsSlave.Name = "cmdSetAsSlave"
        Me.cmdSetAsSlave.Size = New System.Drawing.Size(160, 50)
        Me.cmdSetAsSlave.TabIndex = 1
        Me.cmdSetAsSlave.Text = "Set as slave"
        Me.cmdSetAsSlave.UseVisualStyleBackColor = True
        '
        'tvCaveInfos
        '
        Me.tvCaveInfos.CheckBoxes = True
        Me.tvCaveInfos.ImageIndex = 0
        Me.tvCaveInfos.ImageList = Me.iml
        Me.tvCaveInfos.Location = New System.Drawing.Point(12, 7)
        Me.tvCaveInfos.Name = "tvCaveInfos"
        Me.tvCaveInfos.SelectedImageIndex = 0
        Me.tvCaveInfos.Size = New System.Drawing.Size(331, 131)
        Me.tvCaveInfos.TabIndex = 2
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "cave")
        Me.iml.Images.SetKeyName(1, "branch")
        Me.iml.Images.SetKeyName(2, "deleted")
        Me.iml.Images.SetKeyName(3, "hl")
        Me.iml.Images.SetKeyName(4, "session")
        '
        'cmdJoin
        '
        Me.cmdJoin.Location = New System.Drawing.Point(12, 4)
        Me.cmdJoin.Name = "cmdJoin"
        Me.cmdJoin.Size = New System.Drawing.Size(160, 50)
        Me.cmdJoin.TabIndex = 3
        Me.cmdJoin.Text = "Join"
        Me.cmdJoin.UseVisualStyleBackColor = True
        '
        'pnlSetAsMaster
        '
        Me.pnlSetAsMaster.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSetAsMaster.Controls.Add(Me.cmdSetAsMaster)
        Me.pnlSetAsMaster.Location = New System.Drawing.Point(0, 0)
        Me.pnlSetAsMaster.Name = "pnlSetAsMaster"
        Me.pnlSetAsMaster.Size = New System.Drawing.Size(782, 72)
        Me.pnlSetAsMaster.TabIndex = 4
        '
        'pnlSetAsSlave
        '
        Me.pnlSetAsSlave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSetAsSlave.Controls.Add(Me.cmdLock)
        Me.pnlSetAsSlave.Controls.Add(Me.PropertyGrid1)
        Me.pnlSetAsSlave.Controls.Add(Me.tvCaveInfos)
        Me.pnlSetAsSlave.Controls.Add(Me.cmdSetAsSlave)
        Me.pnlSetAsSlave.Location = New System.Drawing.Point(0, 73)
        Me.pnlSetAsSlave.Name = "pnlSetAsSlave"
        Me.pnlSetAsSlave.Size = New System.Drawing.Size(782, 213)
        Me.pnlSetAsSlave.TabIndex = 5
        '
        'cmdLock
        '
        Me.cmdLock.Location = New System.Drawing.Point(360, 7)
        Me.cmdLock.Name = "cmdLock"
        Me.cmdLock.Size = New System.Drawing.Size(61, 51)
        Me.cmdLock.TabIndex = 4
        Me.cmdLock.Text = "Button1"
        Me.cmdLock.UseVisualStyleBackColor = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.CommandsVisibleIfAvailable = False
        Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ControlDark
        Me.PropertyGrid1.Location = New System.Drawing.Point(437, 5)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(333, 190)
        Me.PropertyGrid1.TabIndex = 3
        Me.PropertyGrid1.ToolbarVisible = False
        '
        'pnlJoin
        '
        Me.pnlJoin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlJoin.Controls.Add(Me.cmdJoin)
        Me.pnlJoin.Location = New System.Drawing.Point(0, 288)
        Me.pnlJoin.Name = "pnlJoin"
        Me.pnlJoin.Size = New System.Drawing.Size(782, 73)
        Me.pnlJoin.TabIndex = 6
        '
        'frmMasterSlaveManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 397)
        Me.Controls.Add(Me.pnlSetAsMaster)
        Me.Controls.Add(Me.pnlSetAsSlave)
        Me.Controls.Add(Me.pnlJoin)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMasterSlaveManager"
        Me.Text = "frmMasterSlaveManager"
        Me.pnlSetAsMaster.ResumeLayout(False)
        Me.pnlSetAsSlave.ResumeLayout(False)
        Me.pnlJoin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdSetAsMaster As Button
    Friend WithEvents cmdSetAsSlave As Button
    Friend WithEvents tvCaveInfos As TreeView
    Friend WithEvents cmdJoin As Button
    Friend WithEvents pnlSetAsMaster As Panel
    Friend WithEvents pnlSetAsSlave As Panel
    Friend WithEvents pnlJoin As Panel
    Friend WithEvents iml As ImageList
    Friend WithEvents PropertyGrid1 As PropertyGrid
    Friend WithEvents cmdLock As Button
End Class
