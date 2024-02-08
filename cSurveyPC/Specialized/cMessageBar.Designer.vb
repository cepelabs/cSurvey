<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cMessageBar
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cMessageBar))
        Me.btnPopupClose = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPopupWarning = New DevExpress.XtraEditors.LabelControl()
        Me.picPopupWarning = New DevExpress.XtraEditors.PictureEdit()
        Me.btnPopupCustom = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.picPopupWarning.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPopupClose
        '
        resources.ApplyResources(Me.btnPopupClose, "btnPopupClose")
        Me.btnPopupClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPopupClose.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearheaderandfooter
        Me.btnPopupClose.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPopupClose.Name = "btnPopupClose"
        Me.btnPopupClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.btnPopupClose.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        '
        'lblPopupWarning
        '
        Me.lblPopupWarning.AllowHtmlString = True
        resources.ApplyResources(Me.lblPopupWarning, "lblPopupWarning")
        Me.lblPopupWarning.Appearance.Options.UseTextOptions = True
        Me.lblPopupWarning.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter
        Me.lblPopupWarning.AutoEllipsis = True
        Me.lblPopupWarning.Name = "lblPopupWarning"
        '
        'picPopupWarning
        '
        resources.ApplyResources(Me.picPopupWarning, "picPopupWarning")
        Me.picPopupWarning.EditValue = Global.cSurveyPC.My.Resources.Resources.about
        Me.picPopupWarning.Name = "picPopupWarning"
        Me.picPopupWarning.Properties.AllowFocused = False
        Me.picPopupWarning.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picPopupWarning.Properties.Appearance.Options.UseBackColor = True
        Me.picPopupWarning.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picPopupWarning.Properties.NullText = resources.GetString("picPopupWarning.Properties.NullText")
        Me.picPopupWarning.Properties.ReadOnly = True
        Me.picPopupWarning.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picPopupWarning.Properties.ShowMenu = False
        Me.picPopupWarning.Properties.SvgImageSize = New System.Drawing.Size(16, 16)
        '
        'btnPopupCustom
        '
        resources.ApplyResources(Me.btnPopupCustom, "btnPopupCustom")
        Me.btnPopupCustom.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnPopupCustom.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPopupCustom.Name = "btnPopupCustom"
        Me.btnPopupCustom.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        '
        'cMessageBar
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.picPopupWarning)
        Me.Controls.Add(Me.btnPopupClose)
        Me.Controls.Add(Me.lblPopupWarning)
        Me.Controls.Add(Me.btnPopupCustom)
        Me.Name = "cMessageBar"
        CType(Me.picPopupWarning.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picPopupWarning As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents btnPopupClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPopupWarning As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnPopupCustom As DevExpress.XtraEditors.SimpleButton
End Class
