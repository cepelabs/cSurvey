<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRenameTrigpoints
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRenameTrigpoints))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.lblOldTrigPoint = New DevExpress.XtraEditors.LabelControl()
        Me.lblNewTrigPoint = New DevExpress.XtraEditors.LabelControl()
        Me.txtNew = New DevExpress.XtraEditors.TextEdit()
        Me.cboOld = New cSurveyPC.cTrigpointDropDown()
        CType(Me.txtNew.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'lblOldTrigPoint
        '
        Me.lblOldTrigPoint.Appearance.Font = CType(resources.GetObject("lblOldTrigPoint.Appearance.Font"), System.Drawing.Font)
        Me.lblOldTrigPoint.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblOldTrigPoint, "lblOldTrigPoint")
        Me.lblOldTrigPoint.Name = "lblOldTrigPoint"
        '
        'lblNewTrigPoint
        '
        Me.lblNewTrigPoint.Appearance.Font = CType(resources.GetObject("lblNewTrigPoint.Appearance.Font"), System.Drawing.Font)
        Me.lblNewTrigPoint.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblNewTrigPoint, "lblNewTrigPoint")
        Me.lblNewTrigPoint.Name = "lblNewTrigPoint"
        '
        'txtNew
        '
        resources.ApplyResources(Me.txtNew, "txtNew")
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Properties.Appearance.Font = CType(resources.GetObject("txtNew.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtNew.Properties.Appearance.Options.UseFont = True
        '
        'cboOld
        '
        Me.cboOld.EditValue = Nothing
        resources.ApplyResources(Me.cboOld, "cboOld")
        Me.cboOld.Name = "cboOld"
        '
        'frmRenameTrigpoints
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cboOld)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.lblNewTrigPoint)
        Me.Controls.Add(Me.lblOldTrigPoint)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.renamequery
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRenameTrigpoints"
        CType(Me.txtNew.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblOldTrigPoint As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblNewTrigPoint As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNew As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboOld As cTrigpointDropDown
End Class
