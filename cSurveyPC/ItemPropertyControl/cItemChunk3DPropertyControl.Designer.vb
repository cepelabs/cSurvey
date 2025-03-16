<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemChunk3DPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemChunk3DPropertyControl))
        Me.lblPropChunk = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropModelPreview = New DevExpress.XtraEditors.PanelControl()
        Me.cmdPropModelLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.h3D = New System.Windows.Forms.Integration.ElementHost()
        Me.cmdPropModelEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.grdChunkInfo = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.cmdPropModelPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmdPropModelPreview.SuspendLayout()
        CType(Me.grdChunkInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPropChunk
        '
        resources.ApplyResources(Me.lblPropChunk, "lblPropChunk")
        Me.lblPropChunk.Name = "lblPropChunk"
        '
        'cmdPropModelPreview
        '
        Me.cmdPropModelPreview.Controls.Add(Me.cmdPropModelLoad)
        Me.cmdPropModelPreview.Controls.Add(Me.h3D)
        resources.ApplyResources(Me.cmdPropModelPreview, "cmdPropModelPreview")
        Me.cmdPropModelPreview.Name = "cmdPropModelPreview"
        '
        'cmdPropModelLoad
        '
        Me.cmdPropModelLoad.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropModelLoad.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropModelLoad.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropModelLoad.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropModelLoad, "cmdPropModelLoad")
        Me.cmdPropModelLoad.Name = "cmdPropModelLoad"
        '
        'h3D
        '
        resources.ApplyResources(Me.h3D, "h3D")
        Me.h3D.Name = "h3D"
        Me.h3D.Child = Nothing
        '
        'cmdPropModelEdit
        '
        Me.cmdPropModelEdit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropModelEdit.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropModelEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropModelEdit.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropModelEdit, "cmdPropModelEdit")
        Me.cmdPropModelEdit.Name = "cmdPropModelEdit"
        '
        'grdChunkInfo
        '
        resources.ApplyResources(Me.grdChunkInfo, "grdChunkInfo")
        Me.grdChunkInfo.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdChunkInfo.Name = "grdChunkInfo"
        Me.grdChunkInfo.OptionsBehavior.AllowCollapseRows = False
        Me.grdChunkInfo.OptionsBehavior.ResizeRowValues = False
        Me.grdChunkInfo.OptionsFilter.AllowFilter = False
        Me.grdChunkInfo.OptionsLayout.StoreAppearance = True
        Me.grdChunkInfo.OptionsView.MinRowAutoHeight = 12
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.SimpleButton1.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.camera
        Me.SimpleButton1.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.SimpleButton1, "SimpleButton1")
        Me.SimpleButton1.Name = "SimpleButton1"
        '
        'cItemChunk3DPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.grdChunkInfo)
        Me.Controls.Add(Me.cmdPropModelEdit)
        Me.Controls.Add(Me.cmdPropModelPreview)
        Me.Controls.Add(Me.lblPropChunk)
        Me.Name = "cItemChunk3DPropertyControl"
        CType(Me.cmdPropModelPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmdPropModelPreview.ResumeLayout(False)
        CType(Me.grdChunkInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropChunk As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropModelPreview As DevExpress.XtraEditors.PanelControl
    Friend WithEvents cmdPropModelEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents h3D As Integration.ElementHost
    Friend WithEvents grdChunkInfo As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents cmdPropModelLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class
