<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewMargins
    Inherits DevExpress.XtraEditors.XtraUserControl

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviewMargins))
        Me.frmMargins = New DevExpress.XtraEditors.GroupControl()
        Me.Label2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtRight = New DevExpress.XtraEditors.SpinEdit()
        Me.Label3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtLeft = New DevExpress.XtraEditors.SpinEdit()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtBottom = New DevExpress.XtraEditors.SpinEdit()
        Me.lblTop = New DevExpress.XtraEditors.LabelControl()
        Me.txtTop = New DevExpress.XtraEditors.SpinEdit()
        CType(Me.frmMargins, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmMargins.SuspendLayout()
        CType(Me.txtRight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLeft.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBottom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTop.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmMargins
        '
        resources.ApplyResources(Me.frmMargins, "frmMargins")
        Me.frmMargins.Controls.Add(Me.Label2)
        Me.frmMargins.Controls.Add(Me.txtRight)
        Me.frmMargins.Controls.Add(Me.Label3)
        Me.frmMargins.Controls.Add(Me.txtLeft)
        Me.frmMargins.Controls.Add(Me.Label1)
        Me.frmMargins.Controls.Add(Me.txtBottom)
        Me.frmMargins.Controls.Add(Me.lblTop)
        Me.frmMargins.Controls.Add(Me.txtTop)
        Me.frmMargins.Name = "frmMargins"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtRight
        '
        resources.ApplyResources(Me.txtRight, "txtRight")
        Me.txtRight.Name = "txtRight"
        Me.txtRight.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtRight.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtRight.Properties.DisplayFormat.FormatString = "N0"
        Me.txtRight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRight.Properties.EditFormat.FormatString = "N0"
        Me.txtRight.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtRight.Properties.IsFloatValue = False
        Me.txtRight.Properties.MaskSettings.Set("mask", "N00")
        Me.txtRight.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("txtRight.Properties.UseMaskAsDisplayFormat"), Boolean)
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtLeft
        '
        resources.ApplyResources(Me.txtLeft, "txtLeft")
        Me.txtLeft.Name = "txtLeft"
        Me.txtLeft.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtLeft.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtLeft.Properties.DisplayFormat.FormatString = "N0"
        Me.txtLeft.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLeft.Properties.EditFormat.FormatString = "N0"
        Me.txtLeft.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLeft.Properties.IsFloatValue = False
        Me.txtLeft.Properties.MaskSettings.Set("mask", "N00")
        Me.txtLeft.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("txtLeft.Properties.UseMaskAsDisplayFormat"), Boolean)
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtBottom
        '
        resources.ApplyResources(Me.txtBottom, "txtBottom")
        Me.txtBottom.Name = "txtBottom"
        Me.txtBottom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtBottom.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtBottom.Properties.DisplayFormat.FormatString = "N0"
        Me.txtBottom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBottom.Properties.EditFormat.FormatString = "N0"
        Me.txtBottom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtBottom.Properties.IsFloatValue = False
        Me.txtBottom.Properties.MaskSettings.Set("mask", "N00")
        Me.txtBottom.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("txtBottom.Properties.UseMaskAsDisplayFormat"), Boolean)
        '
        'lblTop
        '
        resources.ApplyResources(Me.lblTop, "lblTop")
        Me.lblTop.Name = "lblTop"
        '
        'txtTop
        '
        resources.ApplyResources(Me.txtTop, "txtTop")
        Me.txtTop.Name = "txtTop"
        Me.txtTop.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtTop.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtTop.Properties.DisplayFormat.FormatString = "N0"
        Me.txtTop.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTop.Properties.EditFormat.FormatString = "N0"
        Me.txtTop.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTop.Properties.IsFloatValue = False
        Me.txtTop.Properties.MaskSettings.Set("mask", "N00")
        Me.txtTop.Properties.UseMaskAsDisplayFormat = CType(resources.GetObject("txtTop.Properties.UseMaskAsDisplayFormat"), Boolean)
        '
        'frmPreviewMargins
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.frmMargins)
        Me.Name = "frmPreviewMargins"
        CType(Me.frmMargins, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmMargins.ResumeLayout(False)
        Me.frmMargins.PerformLayout()
        CType(Me.txtRight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLeft.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBottom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTop.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmMargins As DevExpress.XtraEditors.GroupControl
    Friend WithEvents Label2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtRight As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtLeft As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBottom As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblTop As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTop As DevExpress.XtraEditors.SpinEdit
End Class
