<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cMessageCorner
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cMessageCorner))
        Me.picPopupWarning = New DevExpress.XtraEditors.PictureEdit()
        Me.pnlButton = New DevExpress.Utils.FlyoutPanel()
        Me.flyButton = New DevExpress.Utils.FlyoutPanelControl()
        Me.btnPopupCustom = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.picPopupWarning.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlButton.SuspendLayout()
        CType(Me.flyButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'picPopupWarning
        '
        Me.picPopupWarning.EditValue = Global.cSurveyPC.My.Resources.Resources.warning
        resources.ApplyResources(Me.picPopupWarning, "picPopupWarning")
        Me.picPopupWarning.Name = "picPopupWarning"
        Me.picPopupWarning.Properties.AllowFocused = False
        Me.picPopupWarning.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picPopupWarning.Properties.Appearance.Options.UseBackColor = True
        Me.picPopupWarning.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picPopupWarning.Properties.NullText = resources.GetString("picPopupWarning.Properties.NullText")
        Me.picPopupWarning.Properties.ReadOnly = True
        Me.picPopupWarning.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picPopupWarning.Properties.ShowMenu = False
        Me.picPopupWarning.Properties.SvgImageSize = New System.Drawing.Size(32, 32)
        '
        'pnlButton
        '
        Me.pnlButton.Controls.Add(Me.flyButton)
        resources.ApplyResources(Me.pnlButton, "pnlButton")
        Me.pnlButton.Name = "pnlButton"
        '
        'flyButton
        '
        Me.flyButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.flyButton.Controls.Add(Me.btnPopupCustom)
        resources.ApplyResources(Me.flyButton, "flyButton")
        Me.flyButton.FlyoutPanel = Me.pnlButton
        Me.flyButton.Name = "flyButton"
        '
        'btnPopupCustom
        '
        Me.btnPopupCustom.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.btnPopupCustom.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnPopupCustom.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.btnPopupCustom, "btnPopupCustom")
        Me.btnPopupCustom.Name = "btnPopupCustom"
        '
        'cMessageCorner
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.Appearance.Options.UseBackColor = True
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlButton)
        Me.Controls.Add(Me.picPopupWarning)
        Me.Name = "cMessageCorner"
        CType(Me.picPopupWarning.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlButton.ResumeLayout(False)
        CType(Me.flyButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picPopupWarning As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents pnlButton As DevExpress.Utils.FlyoutPanel
    Friend WithEvents flyButton As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents btnPopupCustom As DevExpress.XtraEditors.SimpleButton
End Class
