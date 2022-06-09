<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemSegmentsBindingPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemSegmentsBindingPropertyControl))
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.cmdPropSegmentsLock = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropSegmentsRebind = New DevExpress.XtraEditors.SimpleButton()
        Me.Label41 = New DevExpress.XtraEditors.LabelControl()
        Me.grdSegmentsBinded = New cSurveyPC.cSegmentsGrid()
        Me.cmdPropSegmentsUnlock = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPropObjectsSelect = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPropObjectsRefresh = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.Add("layer", CType(resources.GetObject("iml.layer"), DevExpress.Utils.Svg.SvgImage))
        Me.iml.Add("item", CType(resources.GetObject("iml.item"), DevExpress.Utils.Svg.SvgImage))
        '
        'cmdPropSegmentsLock
        '
        resources.ApplyResources(Me.cmdPropSegmentsLock, "cmdPropSegmentsLock")
        Me.cmdPropSegmentsLock.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSegmentsLock.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.Security_Lock
        Me.cmdPropSegmentsLock.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropSegmentsLock.Name = "cmdPropSegmentsLock"
        '
        'cmdPropSegmentsRebind
        '
        resources.ApplyResources(Me.cmdPropSegmentsRebind, "cmdPropSegmentsRebind")
        Me.cmdPropSegmentsRebind.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSegmentsRebind.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.refreshbindings
        Me.cmdPropSegmentsRebind.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropSegmentsRebind.Name = "cmdPropSegmentsRebind"
        '
        'Label41
        '
        Me.Label41.AllowHtmlString = True
        resources.ApplyResources(Me.Label41, "Label41")
        Me.Label41.Name = "Label41"
        '
        'grdSegmentsBinded
        '
        resources.ApplyResources(Me.grdSegmentsBinded, "grdSegmentsBinded")
        Me.grdSegmentsBinded.Name = "grdSegmentsBinded"
        '
        'cmdPropSegmentsUnlock
        '
        resources.ApplyResources(Me.cmdPropSegmentsUnlock, "cmdPropSegmentsUnlock")
        Me.cmdPropSegmentsUnlock.ImageOptions.Image = CType(resources.GetObject("cmdPropSegmentsUnlock.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdPropSegmentsUnlock.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropSegmentsUnlock.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.Security_Unlock
        Me.cmdPropSegmentsUnlock.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropSegmentsUnlock.Name = "cmdPropSegmentsUnlock"
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
        'btnPropObjectsRefresh
        '
        resources.ApplyResources(Me.btnPropObjectsRefresh, "btnPropObjectsRefresh")
        Me.btnPropObjectsRefresh.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnPropObjectsRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnPropObjectsRefresh.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.btnPropObjectsRefresh.Name = "btnPropObjectsRefresh"
        '
        'cItemSegmentsBindingPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdPropSegmentsLock)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.cmdPropSegmentsRebind)
        Me.Controls.Add(Me.grdSegmentsBinded)
        Me.Controls.Add(Me.cmdPropSegmentsUnlock)
        Me.Controls.Add(Me.btnPropObjectsRefresh)
        Me.Controls.Add(Me.btnPropObjectsSelect)
        Me.Name = "cItemSegmentsBindingPropertyControl"
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents cmdPropSegmentsLock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropSegmentsUnlock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropSegmentsRebind As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label41 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grdSegmentsBinded As cSegmentsGrid
    Friend WithEvents btnPropObjectsSelect As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPropObjectsRefresh As DevExpress.XtraEditors.SimpleButton
End Class
