<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemImagePropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemImagePropertyControl))
        Me.cmdPropImageView = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropImageEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.picPropImage = New DevExpress.XtraEditors.PictureEdit()
        Me.lblPropImageResolution = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropImageResolution = New DevExpress.XtraEditors.TextEdit()
        Me.lblPropImageRotateAngle = New DevExpress.XtraEditors.LabelControl()
        Me.Label34 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropImageScale500 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropImageScale250 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropImageScale100 = New DevExpress.XtraEditors.SimpleButton()
        Me.cboPropImageResizeMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label16 = New DevExpress.XtraEditors.LabelControl()
        Me.Label32 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropImageScaleFree = New DevExpress.XtraEditors.SpinEdit()
        Me.txtPropImageRotateAngle = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.picPropImage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropImageResolution.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPropImageResizeMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropImageScaleFree.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropImageRotateAngle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPropImageView
        '
        Me.cmdPropImageView.ImageOptions.Image = CType(resources.GetObject("cmdPropImageView.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdPropImageView.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropImageView.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropImageView.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropImageView.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropImageView, "cmdPropImageView")
        Me.cmdPropImageView.Name = "cmdPropImageView"
        '
        'cmdPropImageEdit
        '
        Me.cmdPropImageEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropImageEdit.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropImageEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropImageEdit.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropImageEdit, "cmdPropImageEdit")
        Me.cmdPropImageEdit.Name = "cmdPropImageEdit"
        '
        'picPropImage
        '
        resources.ApplyResources(Me.picPropImage, "picPropImage")
        Me.picPropImage.Name = "picPropImage"
        Me.picPropImage.Properties.NullText = resources.GetString("picPropImage.Properties.NullText")
        Me.picPropImage.Properties.ReadOnly = True
        Me.picPropImage.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'lblPropImageResolution
        '
        resources.ApplyResources(Me.lblPropImageResolution, "lblPropImageResolution")
        Me.lblPropImageResolution.Name = "lblPropImageResolution"
        '
        'txtPropImageResolution
        '
        resources.ApplyResources(Me.txtPropImageResolution, "txtPropImageResolution")
        Me.txtPropImageResolution.Name = "txtPropImageResolution"
        Me.txtPropImageResolution.Properties.ReadOnly = True
        '
        'lblPropImageRotateAngle
        '
        resources.ApplyResources(Me.lblPropImageRotateAngle, "lblPropImageRotateAngle")
        Me.lblPropImageRotateAngle.Appearance.Font = CType(resources.GetObject("lblPropImageRotateAngle.Appearance.Font"), System.Drawing.Font)
        Me.lblPropImageRotateAngle.Appearance.Options.UseFont = True
        Me.lblPropImageRotateAngle.Name = "lblPropImageRotateAngle"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.Name = "Label34"
        '
        'cmdPropImageScale500
        '
        resources.ApplyResources(Me.cmdPropImageScale500, "cmdPropImageScale500")
        Me.cmdPropImageScale500.Name = "cmdPropImageScale500"
        '
        'cmdPropImageScale250
        '
        resources.ApplyResources(Me.cmdPropImageScale250, "cmdPropImageScale250")
        Me.cmdPropImageScale250.Name = "cmdPropImageScale250"
        '
        'cmdPropImageScale100
        '
        resources.ApplyResources(Me.cmdPropImageScale100, "cmdPropImageScale100")
        Me.cmdPropImageScale100.Name = "cmdPropImageScale100"
        '
        'cboPropImageResizeMode
        '
        resources.ApplyResources(Me.cboPropImageResizeMode, "cboPropImageResizeMode")
        Me.cboPropImageResizeMode.Name = "cboPropImageResizeMode"
        Me.cboPropImageResizeMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPropImageResizeMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPropImageResizeMode.Properties.Items.AddRange(New Object() {resources.GetString("cboPropImageResizeMode.Properties.Items"), resources.GetString("cboPropImageResizeMode.Properties.Items1")})
        Me.cboPropImageResizeMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'txtPropImageScaleFree
        '
        resources.ApplyResources(Me.txtPropImageScaleFree, "txtPropImageScaleFree")
        Me.txtPropImageScaleFree.Name = "txtPropImageScaleFree"
        Me.txtPropImageScaleFree.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropImageScaleFree.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropImageScaleFree.Properties.MaskSettings.Set("mask", "d")
        Me.txtPropImageScaleFree.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropImageScaleFree.Properties.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropImageRotateAngle
        '
        resources.ApplyResources(Me.txtPropImageRotateAngle, "txtPropImageRotateAngle")
        Me.txtPropImageRotateAngle.Name = "txtPropImageRotateAngle"
        Me.txtPropImageRotateAngle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtPropImageRotateAngle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtPropImageRotateAngle.Properties.DisplayFormat.FormatString = "N1"
        Me.txtPropImageRotateAngle.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropImageRotateAngle.Properties.EditFormat.FormatString = "N1"
        Me.txtPropImageRotateAngle.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPropImageRotateAngle.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.txtPropImageRotateAngle.Properties.MaskSettings.Set("mask", "N1")
        Me.txtPropImageRotateAngle.Properties.MaxValue = New Decimal(New Integer() {360, 0, 0, 0})
        Me.txtPropImageRotateAngle.Properties.MinValue = New Decimal(New Integer() {360, 0, 0, -2147483648})
        '
        'cItemImagePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtPropImageRotateAngle)
        Me.Controls.Add(Me.txtPropImageScaleFree)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.lblPropImageRotateAngle)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.cmdPropImageScale500)
        Me.Controls.Add(Me.cmdPropImageScale250)
        Me.Controls.Add(Me.cmdPropImageScale100)
        Me.Controls.Add(Me.cboPropImageResizeMode)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmdPropImageView)
        Me.Controls.Add(Me.txtPropImageResolution)
        Me.Controls.Add(Me.lblPropImageResolution)
        Me.Controls.Add(Me.cmdPropImageEdit)
        Me.Controls.Add(Me.picPropImage)
        Me.Name = "cItemImagePropertyControl"
        CType(Me.picPropImage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropImageResolution.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPropImageResizeMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropImageScaleFree.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropImageRotateAngle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPropImageView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropImageEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picPropImage As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblPropImageResolution As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropImageResolution As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPropImageRotateAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label34 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropImageScale500 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropImageScale250 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropImageScale100 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboPropImageResizeMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Label32 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropImageScaleFree As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents txtPropImageRotateAngle As DevExpress.XtraEditors.SpinEdit
End Class
