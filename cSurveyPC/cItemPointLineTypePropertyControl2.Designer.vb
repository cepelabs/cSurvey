<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemPointLineTypePropertyControl2
    Inherits cItemPointPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemPointLineTypePropertyControl2))
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkStyleSpline = New DevExpress.XtraEditors.CheckButton()
        Me.chkStyleStraightLine = New DevExpress.XtraEditors.CheckButton()
        Me.lblPropLineStyle = New DevExpress.XtraEditors.LabelControl()
        Me.chkStyleBezier = New DevExpress.XtraEditors.CheckButton()
        Me.chkStyleAsParent = New DevExpress.XtraEditors.CheckButton()
        Me.SuspendLayout()
        '
        'chkStyleSpline
        '
        Me.chkStyleSpline.GroupIndex = 1
        Me.chkStyleSpline.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkStyleSpline.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkStyleSpline.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.splines
        Me.chkStyleSpline.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkStyleSpline, "chkStyleSpline")
        Me.chkStyleSpline.Name = "chkStyleSpline"
        Me.chkStyleSpline.TabStop = False
        '
        'chkStyleStraightLine
        '
        Me.chkStyleStraightLine.GroupIndex = 1
        Me.chkStyleStraightLine.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkStyleStraightLine.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkStyleStraightLine.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.straightlines
        Me.chkStyleStraightLine.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkStyleStraightLine, "chkStyleStraightLine")
        Me.chkStyleStraightLine.Name = "chkStyleStraightLine"
        Me.chkStyleStraightLine.TabStop = False
        '
        'lblPropLineStyle
        '
        resources.ApplyResources(Me.lblPropLineStyle, "lblPropLineStyle")
        Me.lblPropLineStyle.Name = "lblPropLineStyle"
        '
        'chkStyleBezier
        '
        Me.chkStyleBezier.GroupIndex = 1
        Me.chkStyleBezier.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkStyleBezier.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkStyleBezier.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.beziers
        Me.chkStyleBezier.ImageOptions.SvgImageSize = New System.Drawing.Size(24, 24)
        resources.ApplyResources(Me.chkStyleBezier, "chkStyleBezier")
        Me.chkStyleBezier.Name = "chkStyleBezier"
        Me.chkStyleBezier.TabStop = False
        '
        'chkStyleAsParent
        '
        Me.chkStyleAsParent.GroupIndex = 1
        Me.chkStyleAsParent.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter
        Me.chkStyleAsParent.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkStyleAsParent.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.levelup
        Me.chkStyleAsParent.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.chkStyleAsParent, "chkStyleAsParent")
        Me.chkStyleAsParent.Name = "chkStyleAsParent"
        Me.chkStyleAsParent.TabStop = False
        '
        'cItemPointLineTypePropertyControl2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkStyleAsParent)
        Me.Controls.Add(Me.chkStyleBezier)
        Me.Controls.Add(Me.chkStyleSpline)
        Me.Controls.Add(Me.chkStyleStraightLine)
        Me.Controls.Add(Me.lblPropLineStyle)
        Me.Name = "cItemPointLineTypePropertyControl2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents chkStyleSpline As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkStyleStraightLine As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lblPropLineStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkStyleBezier As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkStyleAsParent As DevExpress.XtraEditors.CheckButton
End Class
