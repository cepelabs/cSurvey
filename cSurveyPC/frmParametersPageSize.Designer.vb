<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersPageSize
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersPageSize))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cboSize = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.SvgImageCollection = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.chkOrientationPortrait = New DevExpress.XtraEditors.CheckButton()
        Me.chkOrientationLandscape = New DevExpress.XtraEditors.CheckButton()
        Me.lblSize = New DevExpress.XtraEditors.LabelControl()
        Me.lblOrientation = New DevExpress.XtraEditors.LabelControl()
        CType(Me.cboSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SvgImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cboSize
        '
        resources.ApplyResources(Me.cboSize, "cboSize")
        Me.cboSize.Name = "cboSize"
        Me.cboSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSize.Properties.LargeImages = Me.SvgImageCollection
        Me.cboSize.Properties.SmallImages = Me.SvgImageCollection
        '
        'SvgImageCollection
        '
        Me.SvgImageCollection.ImageSize = New System.Drawing.Size(32, 32)
        Me.SvgImageCollection.Add("page1", "page1", GetType(cSurveyPC.My.Resources.Resources))
        '
        'chkOrientationPortrait
        '
        Me.chkOrientationPortrait.Checked = True
        Me.chkOrientationPortrait.GroupIndex = 1
        Me.chkOrientationPortrait.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.page1
        resources.ApplyResources(Me.chkOrientationPortrait, "chkOrientationPortrait")
        Me.chkOrientationPortrait.Name = "chkOrientationPortrait"
        '
        'chkOrientationLandscape
        '
        Me.chkOrientationLandscape.GroupIndex = 1
        Me.chkOrientationLandscape.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.landscape
        resources.ApplyResources(Me.chkOrientationLandscape, "chkOrientationLandscape")
        Me.chkOrientationLandscape.Name = "chkOrientationLandscape"
        Me.chkOrientationLandscape.TabStop = False
        '
        'lblSize
        '
        resources.ApplyResources(Me.lblSize, "lblSize")
        Me.lblSize.Name = "lblSize"
        '
        'lblOrientation
        '
        resources.ApplyResources(Me.lblOrientation, "lblOrientation")
        Me.lblOrientation.Name = "lblOrientation"
        '
        'frmParametersPageSize
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblOrientation)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.chkOrientationLandscape)
        Me.Controls.Add(Me.chkOrientationPortrait)
        Me.Controls.Add(Me.cboSize)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.size
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersPageSize"
        CType(Me.cboSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SvgImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cboSize As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents SvgImageCollection As DevExpress.Utils.SvgImageCollection
    Friend WithEvents chkOrientationPortrait As DevExpress.XtraEditors.CheckButton
    Friend WithEvents chkOrientationLandscape As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lblSize As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblOrientation As DevExpress.XtraEditors.LabelControl
End Class
