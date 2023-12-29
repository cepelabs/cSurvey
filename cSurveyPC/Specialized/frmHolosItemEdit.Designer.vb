<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHolosItemEdit
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHolosItemEdit))
        Me.h3D = New System.Windows.Forms.Integration.ElementHost()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
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
        resources.ApplyResources(Me.h3D, "h3D")
        Me.h3D.Name = "h3D"
        Me.h3D.Child = Nothing
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.cmdOk)
        Me.PanelControl1.Controls.Add(Me.cmdCancel)
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.Name = "PanelControl1"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'PanelControl2
        '
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
        resources.ApplyResources(Me.PanelControl2, "PanelControl2")
        Me.PanelControl2.Name = "PanelControl2"
        '
        'LabelControl4
        '
        resources.ApplyResources(Me.LabelControl4, "LabelControl4")
        Me.LabelControl4.Name = "LabelControl4"
        '
        'LabelControl3
        '
        resources.ApplyResources(Me.LabelControl3, "LabelControl3")
        Me.LabelControl3.Name = "LabelControl3"
        '
        'LabelControl2
        '
        resources.ApplyResources(Me.LabelControl2, "LabelControl2")
        Me.LabelControl2.Name = "LabelControl2"
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'lblStation2
        '
        resources.ApplyResources(Me.lblStation2, "lblStation2")
        Me.lblStation2.Name = "lblStation2"
        '
        'txtStation2
        '
        resources.ApplyResources(Me.txtStation2, "txtStation2")
        Me.txtStation2.Name = "txtStation2"
        Me.txtStation2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtStation2.Properties.ReadOnly = True
        Me.txtStation2.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblStation1
        '
        resources.ApplyResources(Me.lblStation1, "lblStation1")
        Me.lblStation1.Name = "lblStation1"
        '
        'txtStation1
        '
        resources.ApplyResources(Me.txtStation1, "txtStation1")
        Me.txtStation1.Name = "txtStation1"
        Me.txtStation1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtStation1.Properties.ReadOnly = True
        Me.txtStation1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'txt2
        '
        resources.ApplyResources(Me.txt2, "txt2")
        Me.txt2.Name = "txt2"
        Me.txt2.Properties.ReadOnly = True
        '
        'txt1
        '
        resources.ApplyResources(Me.txt1, "txt1")
        Me.txt1.Name = "txt1"
        Me.txt1.Properties.ReadOnly = True
        '
        'txtScale
        '
        resources.ApplyResources(Me.txtScale, "txtScale")
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScale.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScale.Properties.DisplayFormat.FormatString = "N2"
        Me.txtScale.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScale.Properties.EditFormat.FormatString = "N2"
        Me.txtScale.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScale.Properties.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtScale.Properties.MaxValue = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtScale.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'txtzrotate
        '
        resources.ApplyResources(Me.txtzrotate, "txtzrotate")
        Me.txtzrotate.Name = "txtzrotate"
        Me.txtzrotate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtzrotate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtzrotate.Properties.DisplayFormat.FormatString = "N2"
        Me.txtzrotate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtzrotate.Properties.EditFormat.FormatString = "N2"
        Me.txtzrotate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtzrotate.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        '
        'txtyrotate
        '
        resources.ApplyResources(Me.txtyrotate, "txtyrotate")
        Me.txtyrotate.Name = "txtyrotate"
        Me.txtyrotate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtyrotate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtyrotate.Properties.DisplayFormat.FormatString = "N2"
        Me.txtyrotate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtyrotate.Properties.EditFormat.FormatString = "N2"
        Me.txtyrotate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtyrotate.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        '
        'txtxrotate
        '
        resources.ApplyResources(Me.txtxrotate, "txtxrotate")
        Me.txtxrotate.Name = "txtxrotate"
        Me.txtxrotate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtxrotate.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtxrotate.Properties.DisplayFormat.FormatString = "N2"
        Me.txtxrotate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtxrotate.Properties.EditFormat.FormatString = "N2"
        Me.txtxrotate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtxrotate.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        '
        'zrotate
        '
        resources.ApplyResources(Me.zrotate, "zrotate")
        Me.zrotate.Name = "zrotate"
        Me.zrotate.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.zrotate.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.zrotate.Properties.LargeChange = 15
        Me.zrotate.Properties.Maximum = 360
        Me.zrotate.Properties.TickFrequency = 15
        '
        'xrotate
        '
        resources.ApplyResources(Me.xrotate, "xrotate")
        Me.xrotate.Name = "xrotate"
        Me.xrotate.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.xrotate.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.xrotate.Properties.LargeChange = 15
        Me.xrotate.Properties.Maximum = 360
        Me.xrotate.Properties.TickFrequency = 15
        '
        'yrotate
        '
        resources.ApplyResources(Me.yrotate, "yrotate")
        Me.yrotate.Name = "yrotate"
        Me.yrotate.Properties.LabelAppearance.Options.UseTextOptions = True
        Me.yrotate.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.yrotate.Properties.LargeChange = 15
        Me.yrotate.Properties.Maximum = 360
        Me.yrotate.Properties.TickFrequency = 15
        '
        'BarManager
        '
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.BarMain})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnSavePreset, Me.btnLoadPreset})
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
        resources.ApplyResources(Me.BarMain, "BarMain")
        '
        'btnLoadPreset
        '
        Me.btnLoadPreset.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnLoadPreset, "btnLoadPreset")
        Me.btnLoadPreset.Id = 14
        Me.btnLoadPreset.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.open
        Me.btnLoadPreset.Name = "btnLoadPreset"
        '
        'btnSavePreset
        '
        Me.btnSavePreset.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        resources.ApplyResources(Me.btnSavePreset, "btnSavePreset")
        Me.btnSavePreset.Id = 13
        Me.btnSavePreset.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.save
        Me.btnSavePreset.Name = "btnSavePreset"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'frmHolosItemEdit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.h3D)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.KeyPreview = True
        Me.Name = "frmHolosItemEdit"
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
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents BarMain As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnLoadPreset As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSavePreset As DevExpress.XtraBars.BarButtonItem
End Class
