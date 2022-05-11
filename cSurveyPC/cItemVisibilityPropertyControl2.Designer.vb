<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemVisibilityPropertyControl2
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemVisibilityPropertyControl2))
        Me.lblPropAffinity = New DevExpress.XtraEditors.LabelControl()
        Me.chkPropVisibleByProfile = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPropVisibleByScale = New DevExpress.XtraEditors.SimpleButton()
        Me.lblPropVisibleIn = New DevExpress.XtraEditors.LabelControl()
        Me.chkPropVisibleInDesign = New DevExpress.XtraEditors.CheckButton()
        Me.chkPropVisibleInPreview = New DevExpress.XtraEditors.CheckButton()
        Me.chkAffinityDesign = New DevExpress.XtraEditors.CheckButton()
        Me.chkAffinityExtra = New DevExpress.XtraEditors.CheckButton()
        Me.SuspendLayout()
        '
        'lblPropAffinity
        '
        resources.ApplyResources(Me.lblPropAffinity, "lblPropAffinity")
        Me.lblPropAffinity.Name = "lblPropAffinity"
        '
        'chkPropVisibleByProfile
        '
        Me.chkPropVisibleByProfile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropVisibleByProfile.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.preview
        Me.chkPropVisibleByProfile.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropVisibleByProfile, "chkPropVisibleByProfile")
        Me.chkPropVisibleByProfile.Name = "chkPropVisibleByProfile"
        '
        'chkPropVisibleByScale
        '
        Me.chkPropVisibleByScale.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.layers_map
        Me.chkPropVisibleByScale.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropVisibleByScale.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.icon_scale
        Me.chkPropVisibleByScale.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropVisibleByScale, "chkPropVisibleByScale")
        Me.chkPropVisibleByScale.Name = "chkPropVisibleByScale"
        '
        'lblPropVisibleIn
        '
        resources.ApplyResources(Me.lblPropVisibleIn, "lblPropVisibleIn")
        Me.lblPropVisibleIn.Name = "lblPropVisibleIn"
        '
        'chkPropVisibleInDesign
        '
        Me.chkPropVisibleInDesign.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropVisibleInDesign.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.designervisibility
        Me.chkPropVisibleInDesign.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropVisibleInDesign, "chkPropVisibleInDesign")
        Me.chkPropVisibleInDesign.Name = "chkPropVisibleInDesign"
        '
        'chkPropVisibleInPreview
        '
        Me.chkPropVisibleInPreview.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropVisibleInPreview.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.printvisibility
        Me.chkPropVisibleInPreview.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkPropVisibleInPreview, "chkPropVisibleInPreview")
        Me.chkPropVisibleInPreview.Name = "chkPropVisibleInPreview"
        '
        'chkAffinityDesign
        '
        Me.chkAffinityDesign.GroupIndex = 1
        Me.chkAffinityDesign.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkAffinityDesign.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkAffinityDesign.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.affinitydesign
        Me.chkAffinityDesign.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkAffinityDesign, "chkAffinityDesign")
        Me.chkAffinityDesign.Name = "chkAffinityDesign"
        Me.chkAffinityDesign.TabStop = False
        '
        'chkAffinityExtra
        '
        Me.chkAffinityExtra.GroupIndex = 1
        Me.chkAffinityExtra.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkAffinityExtra.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkAffinityExtra.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.affinityextra
        Me.chkAffinityExtra.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkAffinityExtra, "chkAffinityExtra")
        Me.chkAffinityExtra.Name = "chkAffinityExtra"
        Me.chkAffinityExtra.TabStop = False
        '
        'cItemVisibilityPropertyControl2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkAffinityExtra)
        Me.Controls.Add(Me.chkAffinityDesign)
        Me.Controls.Add(Me.lblPropAffinity)
        Me.Controls.Add(Me.chkPropVisibleByProfile)
        Me.Controls.Add(Me.chkPropVisibleByScale)
        Me.Controls.Add(Me.lblPropVisibleIn)
        Me.Controls.Add(Me.chkPropVisibleInDesign)
        Me.Controls.Add(Me.chkPropVisibleInPreview)
        Me.Name = "cItemVisibilityPropertyControl2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropAffinity As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPropVisibleByProfile As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPropVisibleByScale As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblPropVisibleIn As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPropVisibleInDesign As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkPropVisibleInPreview As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkAffinityDesign As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkAffinityExtra As DevExpress.XtraEditors.CheckButton
End Class
