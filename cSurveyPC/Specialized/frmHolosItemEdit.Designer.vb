<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHolosItemEdit
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.h3D = New System.Windows.Forms.Integration.ElementHost()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lblStation2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtStation2 = New DevExpress.XtraEditors.ButtonEdit()
        Me.lblStation1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtStation1 = New DevExpress.XtraEditors.ButtonEdit()
        Me.txt2 = New DevExpress.XtraEditors.TextEdit()
        Me.txt1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtScale = New DevExpress.XtraEditors.SpinEdit()
        Me.txtzrotate = New DevExpress.XtraEditors.SpinEdit()
        Me.txtyrotate = New DevExpress.XtraEditors.SpinEdit()
        Me.txtxrotate = New DevExpress.XtraEditors.SpinEdit()
        Me.zrotate = New DevExpress.XtraEditors.TrackBarControl()
        Me.xrotate = New DevExpress.XtraEditors.TrackBarControl()
        Me.yrotate = New DevExpress.XtraEditors.TrackBarControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarMain = New DevExpress.XtraBars.Bar()
        Me.btnLoadPreset = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSavePreset = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnLayerSync = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExpandAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCollapseAll = New DevExpress.XtraBars.BarButtonItem()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txtStation2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStation1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtzrotate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtyrotate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtxrotate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.zrotate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.zrotate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrotate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xrotate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.yrotate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.yrotate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'h3D
        '
        Me.h3D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.h3D.Location = New System.Drawing.Point(0, 28)
        Me.h3D.Name = "h3D"
        Me.h3D.Size = New System.Drawing.Size(567, 320)
        Me.h3D.TabIndex = 0
        Me.h3D.Child = Nothing
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cmdOk)
        Me.PanelControl1.Controls.Add(Me.cmdCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 348)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(886, 48)
        Me.PanelControl1.TabIndex = 1
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Location = New System.Drawing.Point(707, 11)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(80, 25)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(793, 11)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 25)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SimpleButton1)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.lblStation2)
        Me.PanelControl2.Controls.Add(Me.txtStation2)
        Me.PanelControl2.Controls.Add(Me.lblStation1)
        Me.PanelControl2.Controls.Add(Me.txtStation1)
        Me.PanelControl2.Controls.Add(Me.txt2)
        Me.PanelControl2.Controls.Add(Me.txt1)
        Me.PanelControl2.Controls.Add(Me.txtScale)
        Me.PanelControl2.Controls.Add(Me.txtzrotate)
        Me.PanelControl2.Controls.Add(Me.txtyrotate)
        Me.PanelControl2.Controls.Add(Me.txtxrotate)
        Me.PanelControl2.Controls.Add(Me.zrotate)
        Me.PanelControl2.Controls.Add(Me.xrotate)
        Me.PanelControl2.Controls.Add(Me.yrotate)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(567, 28)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(319, 320)
        Me.PanelControl2.TabIndex = 2
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(233, 170)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(42, 42)
        Me.SimpleButton1.TabIndex = 226
        Me.SimpleButton1.Text = "SimpleButton1"
        Me.SimpleButton1.Visible = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Enabled = False
        Me.LabelControl4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelControl4.Location = New System.Drawing.Point(5, 158)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl4.TabIndex = 225
        Me.LabelControl4.Text = "Scale:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Enabled = False
        Me.LabelControl3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelControl3.Location = New System.Drawing.Point(6, 111)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl3.TabIndex = 224
        Me.LabelControl3.Text = "Rotate Z:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Enabled = False
        Me.LabelControl2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelControl2.Location = New System.Drawing.Point(5, 56)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl2.TabIndex = 223
        Me.LabelControl2.Text = "Rotate Y:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Enabled = False
        Me.LabelControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelControl1.Location = New System.Drawing.Point(5, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl1.TabIndex = 222
        Me.LabelControl1.Text = "Rotate X:"
        '
        'lblStation2
        '
        Me.lblStation2.Enabled = False
        Me.lblStation2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStation2.Location = New System.Drawing.Point(6, 248)
        Me.lblStation2.Name = "lblStation2"
        Me.lblStation2.Size = New System.Drawing.Size(47, 13)
        Me.lblStation2.TabIndex = 220
        Me.lblStation2.Text = "Station 2:"
        '
        'txtStation2
        '
        Me.txtStation2.Location = New System.Drawing.Point(79, 245)
        Me.txtStation2.Name = "txtStation2"
        Me.txtStation2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtStation2.Properties.ReadOnly = True
        Me.txtStation2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtStation2.Size = New System.Drawing.Size(127, 20)
        Me.txtStation2.TabIndex = 9
        '
        'lblStation1
        '
        Me.lblStation1.Enabled = False
        Me.lblStation1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStation1.Location = New System.Drawing.Point(6, 196)
        Me.lblStation1.Name = "lblStation1"
        Me.lblStation1.Size = New System.Drawing.Size(47, 13)
        Me.lblStation1.TabIndex = 218
        Me.lblStation1.Text = "Station 1:"
        '
        'txtStation1
        '
        Me.txtStation1.Location = New System.Drawing.Point(79, 193)
        Me.txtStation1.Name = "txtStation1"
        Me.txtStation1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtStation1.Properties.ReadOnly = True
        Me.txtStation1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtStation1.Size = New System.Drawing.Size(127, 20)
        Me.txtStation1.TabIndex = 7
        '
        'txt2
        '
        Me.txt2.Location = New System.Drawing.Point(79, 271)
        Me.txt2.Name = "txt2"
        Me.txt2.Size = New System.Drawing.Size(197, 20)
        Me.txt2.TabIndex = 10
        '
        'txt1
        '
        Me.txt1.Location = New System.Drawing.Point(79, 219)
        Me.txt1.Name = "txt1"
        Me.txt1.Size = New System.Drawing.Size(197, 20)
        Me.txt1.TabIndex = 8
        '
        'txtScale
        '
        Me.txtScale.EditValue = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtScale.Location = New System.Drawing.Point(79, 155)
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtScale.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtScale.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtScale.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtScale.Size = New System.Drawing.Size(56, 20)
        Me.txtScale.TabIndex = 6
        '
        'txtzrotate
        '
        Me.txtzrotate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtzrotate.Location = New System.Drawing.Point(251, 104)
        Me.txtzrotate.Name = "txtzrotate"
        Me.txtzrotate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtzrotate.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        Me.txtzrotate.Size = New System.Drawing.Size(56, 20)
        Me.txtzrotate.TabIndex = 5
        '
        'txtyrotate
        '
        Me.txtyrotate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtyrotate.Location = New System.Drawing.Point(251, 53)
        Me.txtyrotate.Name = "txtyrotate"
        Me.txtyrotate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtyrotate.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        Me.txtyrotate.Size = New System.Drawing.Size(56, 20)
        Me.txtyrotate.TabIndex = 3
        '
        'txtxrotate
        '
        Me.txtxrotate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtxrotate.Location = New System.Drawing.Point(251, 2)
        Me.txtxrotate.Name = "txtxrotate"
        Me.txtxrotate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtxrotate.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        Me.txtxrotate.Size = New System.Drawing.Size(56, 20)
        Me.txtxrotate.TabIndex = 1
        '
        'zrotate
        '
        Me.zrotate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.zrotate.EditValue = Nothing
        Me.zrotate.Location = New System.Drawing.Point(79, 107)
        Me.zrotate.Name = "zrotate"
        Me.zrotate.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.zrotate.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.zrotate.Properties.LargeChange = 15
        Me.zrotate.Properties.Maximum = 360
        Me.zrotate.Properties.TickFrequency = 15
        Me.zrotate.Size = New System.Drawing.Size(166, 45)
        Me.zrotate.TabIndex = 4
        '
        'xrotate
        '
        Me.xrotate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xrotate.EditValue = Nothing
        Me.xrotate.Location = New System.Drawing.Point(79, 5)
        Me.xrotate.Name = "xrotate"
        Me.xrotate.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.xrotate.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xrotate.Properties.LargeChange = 15
        Me.xrotate.Properties.Maximum = 360
        Me.xrotate.Properties.TickFrequency = 15
        Me.xrotate.Size = New System.Drawing.Size(166, 45)
        Me.xrotate.TabIndex = 0
        '
        'yrotate
        '
        Me.yrotate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.yrotate.EditValue = Nothing
        Me.yrotate.Location = New System.Drawing.Point(79, 56)
        Me.yrotate.Name = "yrotate"
        Me.yrotate.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.yrotate.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.yrotate.Properties.LargeChange = 15
        Me.yrotate.Properties.Maximum = 360
        Me.yrotate.Properties.TickFrequency = 15
        Me.yrotate.Size = New System.Drawing.Size(166, 45)
        Me.yrotate.TabIndex = 2
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnLayerSync, Me.btnExpandAll, Me.btnCollapseAll, Me.btnSavePreset, Me.btnLoadPreset})
        Me.BarManager.MaxItemId = 15
        '
        'BarMain
        '
        Me.BarMain.BarName = "Tools"
        Me.BarMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.BarMain.DockCol = 0
        Me.BarMain.DockRow = 0
        Me.BarMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.BarMain.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnLoadPreset), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSavePreset)})
        Me.BarMain.OptionsBar.AllowQuickCustomization = False
        Me.BarMain.OptionsBar.DisableCustomization = True
        Me.BarMain.OptionsBar.DrawDragBorder = False
        Me.BarMain.OptionsBar.UseWholeRow = True
        Me.BarMain.Text = "Tools"
        '
        'btnLoadPreset
        '
        Me.btnLoadPreset.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnLoadPreset.Caption = "Load preset"
        Me.btnLoadPreset.Id = 14
        Me.btnLoadPreset.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.btnLoadPreset.Name = "btnLoadPreset"
        '
        'btnSavePreset
        '
        Me.btnSavePreset.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.btnSavePreset.Caption = "Save preset"
        Me.btnSavePreset.Id = 13
        Me.btnSavePreset.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.save
        Me.btnSavePreset.Name = "btnSavePreset"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlTop.Size = New System.Drawing.Size(886, 28)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 396)
        Me.barDockControlBottom.Manager = Me.BarManager
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlBottom.Size = New System.Drawing.Size(886, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 28)
        Me.barDockControlLeft.Manager = Me.BarManager
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 368)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(886, 28)
        Me.barDockControlRight.Manager = Me.BarManager
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(2)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 368)
        '
        'btnLayerSync
        '
        Me.btnLayerSync.Id = 6
        Me.btnLayerSync.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.productquickcomparisons
        Me.btnLayerSync.Name = "btnLayerSync"
        '
        'btnExpandAll
        '
        Me.btnExpandAll.Caption = "Expand all"
        Me.btnExpandAll.Id = 9
        Me.btnExpandAll.Name = "btnExpandAll"
        '
        'btnCollapseAll
        '
        Me.btnCollapseAll.Caption = "Collapse all"
        Me.btnCollapseAll.Id = 10
        Me.btnCollapseAll.Name = "btnCollapseAll"
        '
        'frmHolosItemEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 396)
        Me.Controls.Add(Me.h3D)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.Name = "frmHolosItemEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add chunk:"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txtStation2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStation1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtzrotate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtyrotate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtxrotate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.zrotate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.zrotate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrotate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xrotate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.yrotate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.yrotate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents h3D As Integration.ElementHost
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtxrotate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents zrotate As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents xrotate As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents yrotate As DevExpress.XtraEditors.TrackBarControl
    Friend WithEvents txtzrotate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtyrotate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtScale As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txt2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txt1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblStation1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtStation1 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents lblStation2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtStation2 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarMain As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnLayerSync As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExpandAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCollapseAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnLoadPreset As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSavePreset As DevExpress.XtraBars.BarButtonItem
End Class
