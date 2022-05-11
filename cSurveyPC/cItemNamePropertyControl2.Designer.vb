<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemNamePropertyControl2
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemNamePropertyControl2))
        Me.txtPropName = New DevExpress.XtraEditors.TextEdit()
        Me.lblPropName = New DevExpress.XtraEditors.LabelControl()
        Me.cmdItemNameRegen = New DevExpress.XtraEditors.SimpleButton()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.txtPropName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPropName
        '
        resources.ApplyResources(Me.txtPropName, "txtPropName")
        Me.txtPropName.Name = "txtPropName"
        '
        'lblPropName
        '
        resources.ApplyResources(Me.lblPropName, "lblPropName")
        Me.lblPropName.Name = "lblPropName"
        '
        'cmdItemNameRegen
        '
        resources.ApplyResources(Me.cmdItemNameRegen, "cmdItemNameRegen")
        Me.cmdItemNameRegen.ImageOptions.Image = Global.cSurveyPC.My.Resources.Resources.stamp_pattern
        Me.cmdItemNameRegen.ImageOptions.SvgImage = CType(resources.GetObject("cmdItemNameRegen.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdItemNameRegen.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdItemNameRegen.Name = "cmdItemNameRegen"
        Me.ToolTip.SetToolTip(Me.cmdItemNameRegen, resources.GetString("cmdItemNameRegen.ToolTip1"))
        '
        'cItemNamePropertyControl2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdItemNameRegen)
        Me.Controls.Add(Me.lblPropName)
        Me.Controls.Add(Me.txtPropName)
        Me.Name = "cItemNamePropertyControl2"
        CType(Me.txtPropName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPropName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPropName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdItemNameRegen As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ToolTip As ToolTip
End Class
