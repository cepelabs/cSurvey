<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemSketchPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemSketchPropertyControl))
        Me.cmdPropSketchView = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPropSketchResolution = New DevExpress.XtraEditors.TextEdit()
        Me.lblPropSketchResolution = New DevExpress.XtraEditors.LabelControl()
        Me.chkPropSketchMorphingDisabled = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPropSketchManualAdjust = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPropSketchEdit = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropSketchEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.picPropSketch = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.txtPropSketchResolution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropSketchMorphingDisabled.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropSketchManualAdjust.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropSketch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPropSketchView
        '
        Me.cmdPropSketchView.ImageOptions.Image = CType(resources.GetObject("cmdPropSketchView.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdPropSketchView.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSketchView.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropSketchView.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropSketchView.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropSketchView, "cmdPropSketchView")
        Me.cmdPropSketchView.Name = "cmdPropSketchView"
        '
        'txtPropSketchResolution
        '
        resources.ApplyResources(Me.txtPropSketchResolution, "txtPropSketchResolution")
        Me.txtPropSketchResolution.Name = "txtPropSketchResolution"
        Me.txtPropSketchResolution.Properties.ReadOnly = True
        '
        'lblPropSketchResolution
        '
        resources.ApplyResources(Me.lblPropSketchResolution, "lblPropSketchResolution")
        Me.lblPropSketchResolution.Name = "lblPropSketchResolution"
        '
        'chkPropSketchMorphingDisabled
        '
        resources.ApplyResources(Me.chkPropSketchMorphingDisabled, "chkPropSketchMorphingDisabled")
        Me.chkPropSketchMorphingDisabled.Name = "chkPropSketchMorphingDisabled"
        Me.chkPropSketchMorphingDisabled.Properties.AutoWidth = True
        Me.chkPropSketchMorphingDisabled.Properties.Caption = resources.GetString("chkPropSketchMorphingDisabled.Properties.Caption")
        '
        'chkPropSketchManualAdjust
        '
        resources.ApplyResources(Me.chkPropSketchManualAdjust, "chkPropSketchManualAdjust")
        Me.chkPropSketchManualAdjust.Name = "chkPropSketchManualAdjust"
        Me.chkPropSketchManualAdjust.Properties.AutoWidth = True
        Me.chkPropSketchManualAdjust.Properties.Caption = resources.GetString("chkPropSketchManualAdjust.Properties.Caption")
        '
        'lblPropSketchEdit
        '
        resources.ApplyResources(Me.lblPropSketchEdit, "lblPropSketchEdit")
        Me.lblPropSketchEdit.Name = "lblPropSketchEdit"
        '
        'cmdPropSketchEdit
        '
        Me.cmdPropSketchEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSketchEdit.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropSketchEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropSketchEdit.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropSketchEdit, "cmdPropSketchEdit")
        Me.cmdPropSketchEdit.Name = "cmdPropSketchEdit"
        '
        'picPropSketch
        '
        resources.ApplyResources(Me.picPropSketch, "picPropSketch")
        Me.picPropSketch.Name = "picPropSketch"
        Me.picPropSketch.Properties.NullText = resources.GetString("picPropSketch.Properties.NullText")
        Me.picPropSketch.Properties.ReadOnly = True
        Me.picPropSketch.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropSketch.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'cItemSketchPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdPropSketchView)
        Me.Controls.Add(Me.txtPropSketchResolution)
        Me.Controls.Add(Me.lblPropSketchResolution)
        Me.Controls.Add(Me.chkPropSketchMorphingDisabled)
        Me.Controls.Add(Me.chkPropSketchManualAdjust)
        Me.Controls.Add(Me.lblPropSketchEdit)
        Me.Controls.Add(Me.cmdPropSketchEdit)
        Me.Controls.Add(Me.picPropSketch)
        Me.Name = "cItemSketchPropertyControl"
        CType(Me.txtPropSketchResolution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropSketchMorphingDisabled.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropSketchManualAdjust.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropSketch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPropSketchView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPropSketchResolution As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPropSketchResolution As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPropSketchMorphingDisabled As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPropSketchManualAdjust As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPropSketchEdit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropSketchEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picPropSketch As DevExpress.XtraEditors.PictureEdit
End Class
