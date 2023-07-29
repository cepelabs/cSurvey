<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.htmlMainInfo = New DevExpress.XtraEditors.HtmlContentControl()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.picLogo = New DevExpress.XtraEditors.PictureEdit()
        Me.TabNavigationPage2 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.htmlCopyright = New DevExpress.XtraEditors.HtmlContentControl()
        Me.TabNavigationPage3 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.htmlLicence = New DevExpress.XtraEditors.HtmlContentControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.lblInfo = New DevExpress.XtraEditors.LabelControl()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPage1.SuspendLayout()
        CType(Me.htmlMainInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLogo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNavigationPage2.SuspendLayout()
        CType(Me.htmlCopyright, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNavigationPage3.SuspendLayout()
        CType(Me.htmlLicence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPane1
        '
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage2)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage3)
        resources.ApplyResources(Me.TabPane1, "TabPane1")
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1, Me.TabNavigationPage2, Me.TabNavigationPage3})
        Me.TabPane1.RegularSize = New System.Drawing.Size(531, 495)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        '
        'TabNavigationPage1
        '
        resources.ApplyResources(Me.TabNavigationPage1, "TabNavigationPage1")
        Me.TabNavigationPage1.Controls.Add(Me.htmlMainInfo)
        Me.TabNavigationPage1.Controls.Add(Me.picLogo)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        '
        'htmlMainInfo
        '
        Me.htmlMainInfo.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.htmlMainInfo, "htmlMainInfo")
        Me.htmlMainInfo.HtmlImages = Me.ImageCollection1
        Me.htmlMainInfo.HtmlTemplate.Styles = resources.GetString("htmlMainInfo.HtmlTemplate.Styles")
        Me.htmlMainInfo.HtmlTemplate.Template = resources.GetString("htmlMainInfo.HtmlTemplate.Template")
        Me.htmlMainInfo.Name = "htmlMainInfo"
        '
        'ImageCollection1
        '
        resources.ApplyResources(Me.ImageCollection1, "ImageCollection1")
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "gsbusb.png")
        Me.ImageCollection1.Images.SetKeyName(1, "bolognaspeleologica.png")
        Me.ImageCollection1.Images.SetKeyName(2, "fsrer.png")
        '
        'picLogo
        '
        resources.ApplyResources(Me.picLogo, "picLogo")
        Me.picLogo.EditValue = Global.cSurveyPC.My.Resources.Resources.csurvey_2
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Properties.Appearance.Options.UseBackColor = True
        Me.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.picLogo.Properties.ReadOnly = True
        Me.picLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'TabNavigationPage2
        '
        resources.ApplyResources(Me.TabNavigationPage2, "TabNavigationPage2")
        Me.TabNavigationPage2.Controls.Add(Me.htmlCopyright)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.PageVisible = False
        '
        'htmlCopyright
        '
        Me.htmlCopyright.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.htmlCopyright, "htmlCopyright")
        Me.htmlCopyright.HtmlTemplate.Styles = resources.GetString("htmlCopyright.HtmlTemplate.Styles")
        Me.htmlCopyright.HtmlTemplate.Template = resources.GetString("htmlCopyright.HtmlTemplate.Template")
        Me.htmlCopyright.Name = "htmlCopyright"
        '
        'TabNavigationPage3
        '
        resources.ApplyResources(Me.TabNavigationPage3, "TabNavigationPage3")
        Me.TabNavigationPage3.Controls.Add(Me.htmlLicence)
        Me.TabNavigationPage3.Name = "TabNavigationPage3"
        '
        'htmlLicence
        '
        Me.htmlLicence.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.htmlLicence, "htmlLicence")
        Me.htmlLicence.HtmlTemplate.Styles = resources.GetString("htmlLicence.HtmlTemplate.Styles")
        Me.htmlLicence.HtmlTemplate.Template = resources.GetString("htmlLicence.HtmlTemplate.Template")
        Me.htmlLicence.Name = "htmlLicence"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.lblInfo)
        resources.ApplyResources(Me.PanelControl1, "PanelControl1")
        Me.PanelControl1.Name = "PanelControl1"
        '
        'lblInfo
        '
        Me.lblInfo.Appearance.Options.UseTextOptions = True
        Me.lblInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        resources.ApplyResources(Me.lblInfo, "lblInfo")
        Me.lblInfo.Name = "lblInfo"
        '
        'frmAbout
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TabPane1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.about
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPage1.ResumeLayout(False)
        CType(Me.htmlMainInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLogo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNavigationPage2.ResumeLayout(False)
        CType(Me.htmlCopyright, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNavigationPage3.ResumeLayout(False)
        CType(Me.htmlLicence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents picLogo As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblInfo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents htmlMainInfo As DevExpress.XtraEditors.HtmlContentControl
    Friend WithEvents htmlCopyright As DevExpress.XtraEditors.HtmlContentControl
    Friend WithEvents TabNavigationPage3 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents htmlLicence As DevExpress.XtraEditors.HtmlContentControl
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
End Class
