<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockText
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockText))
        Me.txtText = New DevExpress.XtraEditors.MemoEdit()
        Me.lblTextSize = New DevExpress.XtraEditors.LabelControl()
        Me.lblTextStyle = New DevExpress.XtraEditors.LabelControl()
        Me.lblText = New DevExpress.XtraEditors.LabelControl()
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnTextFromClipboard = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.mainPanel = New DevExpress.XtraEditors.PanelControl()
        Me.cboPropTextSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboPropTextStyle = New cSurveyPC.cFontStyleDropDown()
        CType(Me.txtText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mainPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainPanel.SuspendLayout()
        CType(Me.cboPropTextSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtText
        '
        resources.ApplyResources(Me.txtText, "txtText")
        Me.txtText.Name = "txtText"
        '
        'lblTextSize
        '
        resources.ApplyResources(Me.lblTextSize, "lblTextSize")
        Me.lblTextSize.Name = "lblTextSize"
        '
        'lblTextStyle
        '
        resources.ApplyResources(Me.lblTextStyle, "lblTextStyle")
        Me.lblTextStyle.Name = "lblTextStyle"
        '
        'lblText
        '
        resources.ApplyResources(Me.lblText, "lblText")
        Me.lblText.Name = "lblText"
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnTextFromClipboard, Me.btnAdd})
        Me.BarManager.MaxItemId = 17
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnTextFromClipboard, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnAdd, True)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DisableClose = True
        Me.Bar1.OptionsBar.DisableCustomization = True
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        '
        'btnTextFromClipboard
        '
        resources.ApplyResources(Me.btnTextFromClipboard, "btnTextFromClipboard")
        Me.btnTextFromClipboard.Id = 15
        Me.btnTextFromClipboard.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.textfromclipboard
        Me.btnTextFromClipboard.Name = "btnTextFromClipboard"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Id = 16
        Me.btnAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.addfile
        Me.btnAdd.Name = "btnAdd"
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
        'mainPanel
        '
        Me.mainPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mainPanel.Controls.Add(Me.cboPropTextSize)
        Me.mainPanel.Controls.Add(Me.cboPropTextStyle)
        Me.mainPanel.Controls.Add(Me.lblText)
        Me.mainPanel.Controls.Add(Me.lblTextStyle)
        Me.mainPanel.Controls.Add(Me.txtText)
        Me.mainPanel.Controls.Add(Me.lblTextSize)
        resources.ApplyResources(Me.mainPanel, "mainPanel")
        Me.mainPanel.Name = "mainPanel"
        '
        'cboPropTextSize
        '
        resources.ApplyResources(Me.cboPropTextSize, "cboPropTextSize")
        Me.cboPropTextSize.Name = "cboPropTextSize"
        Me.cboPropTextSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropTextSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropTextSize.Properties.Items.AddRange(New Object() {resources.GetString("cboPropTextSize.Properties.Items"), resources.GetString("cboPropTextSize.Properties.Items1"), resources.GetString("cboPropTextSize.Properties.Items2"), resources.GetString("cboPropTextSize.Properties.Items3"), resources.GetString("cboPropTextSize.Properties.Items4"), resources.GetString("cboPropTextSize.Properties.Items5"), resources.GetString("cboPropTextSize.Properties.Items6"), resources.GetString("cboPropTextSize.Properties.Items7"), resources.GetString("cboPropTextSize.Properties.Items8"), resources.GetString("cboPropTextSize.Properties.Items9"), resources.GetString("cboPropTextSize.Properties.Items10"), resources.GetString("cboPropTextSize.Properties.Items11"), resources.GetString("cboPropTextSize.Properties.Items12"), resources.GetString("cboPropTextSize.Properties.Items13")})
        Me.cboPropTextSize.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboPropTextStyle
        '
        resources.ApplyResources(Me.cboPropTextStyle, "cboPropTextStyle")
        Me.cboPropTextStyle.EditValue = cSurveyPC.cSurvey.Design.cItemFont.FontTypeEnum.Generic
        Me.cboPropTextStyle.Name = "cboPropTextStyle"
        '
        'cDockText
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.mainPanel)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockText"
        CType(Me.txtText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mainPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainPanel.ResumeLayout(False)
        Me.mainPanel.PerformLayout()
        CType(Me.cboPropTextSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtText As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblText As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents btnTextFromClipboard As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mainPanel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblTextSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblTextStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropTextSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboPropTextStyle As cFontStyleDropDown
End Class
