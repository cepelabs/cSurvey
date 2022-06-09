<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemClippingPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemClippingPropertyControl))
        Me.lblPropClipping = New DevExpress.XtraEditors.LabelControl()
        Me.chkClippingType0 = New DevExpress.XtraEditors.CheckButton()
        Me.chkClippingType3 = New DevExpress.XtraEditors.CheckButton()
        Me.chkClippingType2 = New DevExpress.XtraEditors.CheckButton()
        Me.chkClippingType1 = New DevExpress.XtraEditors.CheckButton()
        Me.SuspendLayout()
        '
        'lblPropClipping
        '
        resources.ApplyResources(Me.lblPropClipping, "lblPropClipping")
        Me.lblPropClipping.Name = "lblPropClipping"
        '
        'chkClippingType0
        '
        Me.chkClippingType0.GroupIndex = 1
        Me.chkClippingType0.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.chkClippingType0.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.levelup
        Me.chkClippingType0.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkClippingType0, "chkClippingType0")
        Me.chkClippingType0.Name = "chkClippingType0"
        Me.chkClippingType0.TabStop = False
        '
        'chkClippingType3
        '
        Me.chkClippingType3.GroupIndex = 1
        Me.chkClippingType3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.chkClippingType3.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.outside
        Me.chkClippingType3.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkClippingType3, "chkClippingType3")
        Me.chkClippingType3.Name = "chkClippingType3"
        Me.chkClippingType3.TabStop = False
        '
        'chkClippingType2
        '
        Me.chkClippingType2.GroupIndex = 1
        Me.chkClippingType2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.chkClippingType2.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.inside
        Me.chkClippingType2.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkClippingType2, "chkClippingType2")
        Me.chkClippingType2.Name = "chkClippingType2"
        Me.chkClippingType2.TabStop = False
        '
        'chkClippingType1
        '
        Me.chkClippingType1.GroupIndex = 1
        Me.chkClippingType1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.chkClippingType1.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.overlap
        Me.chkClippingType1.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkClippingType1, "chkClippingType1")
        Me.chkClippingType1.Name = "chkClippingType1"
        Me.chkClippingType1.TabStop = False
        '
        'cItemClippingPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.chkClippingType3)
        Me.Controls.Add(Me.chkClippingType2)
        Me.Controls.Add(Me.chkClippingType1)
        Me.Controls.Add(Me.lblPropClipping)
        Me.Controls.Add(Me.chkClippingType0)
        Me.Name = "cItemClippingPropertyControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropClipping As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkClippingType0 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkClippingType3 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkClippingType2 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkClippingType1 As DevExpress.XtraEditors.CheckButton
End Class
