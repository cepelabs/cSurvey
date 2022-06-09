<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemMergeModeControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemMergeModeControl))
        Me.lblPropMergeMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkMergeMode0 = New DevExpress.XtraEditors.CheckButton()
        Me.chkMergeMode1 = New DevExpress.XtraEditors.CheckButton()
        Me.SuspendLayout()
        '
        'lblPropMergeMode
        '
        resources.ApplyResources(Me.lblPropMergeMode, "lblPropMergeMode")
        Me.lblPropMergeMode.Name = "lblPropMergeMode"
        '
        'chkMergeMode0
        '
        Me.chkMergeMode0.GroupIndex = 1
        Me.chkMergeMode0.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkMergeMode0.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkMergeMode0.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.chkMergeMode0.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkMergeMode0, "chkMergeMode0")
        Me.chkMergeMode0.Name = "chkMergeMode0"
        '
        'chkMergeMode1
        '
        Me.chkMergeMode1.GroupIndex = 1
        Me.chkMergeMode1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkMergeMode1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkMergeMode1.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_remove
        Me.chkMergeMode1.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkMergeMode1, "chkMergeMode1")
        Me.chkMergeMode1.Name = "chkMergeMode1"
        '
        'cItemMergeModeControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.lblPropMergeMode)
        Me.Controls.Add(Me.chkMergeMode0)
        Me.Controls.Add(Me.chkMergeMode1)
        Me.Name = "cItemMergeModeControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropMergeMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkMergeMode0 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkMergeMode1 As DevExpress.XtraEditors.CheckButton
End Class
