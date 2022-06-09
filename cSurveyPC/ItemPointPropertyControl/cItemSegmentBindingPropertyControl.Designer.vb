<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemSegmentBindingPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemSegmentBindingPropertyControl))
        Me.txtPropSegmentBinded = New DevExpress.XtraEditors.TextEdit()
        Me.chkPropSegmentLocked = New DevExpress.XtraEditors.CheckButton()
        Me.lblPropBinding = New DevExpress.XtraEditors.LabelControl()
        Me.grdSegmentsBinded = New cSurveyPC.cSegmentsGrid()
        Me.btnPropObjectsRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPropObjectsSelect = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtPropSegmentBinded.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPropSegmentBinded
        '
        resources.ApplyResources(Me.txtPropSegmentBinded, "txtPropSegmentBinded")
        Me.txtPropSegmentBinded.Name = "txtPropSegmentBinded"
        Me.txtPropSegmentBinded.Properties.ReadOnly = True
        '
        'chkPropSegmentLocked
        '
        resources.ApplyResources(Me.chkPropSegmentLocked, "chkPropSegmentLocked")
        Me.chkPropSegmentLocked.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.chkPropSegmentLocked.ImageOptions.SvgImage = CType(resources.GetObject("chkPropSegmentLocked.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.chkPropSegmentLocked.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.chkPropSegmentLocked.Name = "chkPropSegmentLocked"
        '
        'lblPropBinding
        '
        resources.ApplyResources(Me.lblPropBinding, "lblPropBinding")
        Me.lblPropBinding.Name = "lblPropBinding"
        '
        'grdSegmentsBinded
        '
        resources.ApplyResources(Me.grdSegmentsBinded, "grdSegmentsBinded")
        Me.grdSegmentsBinded.Name = "grdSegmentsBinded"
        '
        'btnPropObjectsRefresh
        '
        resources.ApplyResources(Me.btnPropObjectsRefresh, "btnPropObjectsRefresh")
        Me.btnPropObjectsRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPropObjectsRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnPropObjectsRefresh.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPropObjectsRefresh.Name = "btnPropObjectsRefresh"
        '
        'btnPropObjectsSelect
        '
        resources.ApplyResources(Me.btnPropObjectsSelect, "btnPropObjectsSelect")
        Me.btnPropObjectsSelect.ImageOptions.Image = CType(resources.GetObject("btnPropObjectsSelect.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPropObjectsSelect.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPropObjectsSelect.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.btnPropObjectsSelect.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPropObjectsSelect.Name = "btnPropObjectsSelect"
        '
        'cItemSegmentBindingPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.btnPropObjectsSelect)
        Me.Controls.Add(Me.grdSegmentsBinded)
        Me.Controls.Add(Me.lblPropBinding)
        Me.Controls.Add(Me.txtPropSegmentBinded)
        Me.Controls.Add(Me.chkPropSegmentLocked)
        Me.Controls.Add(Me.btnPropObjectsRefresh)
        Me.Name = "cItemSegmentBindingPropertyControl"
        CType(Me.txtPropSegmentBinded.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPropSegmentBinded As DevExpress.XtraEditors.TextEdit
    Friend WithEvents chkPropSegmentLocked As DevExpress.XtraEditors.CheckButton
    Friend WithEvents lblPropBinding As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grdSegmentsBinded As cSegmentsGrid
    Friend WithEvents btnPropObjectsRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPropObjectsSelect As DevExpress.XtraEditors.SimpleButton
End Class
