<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemPointNavigatorPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemPointNavigatorPropertyControl))
        Me.txtPropPointType = New DevExpress.XtraEditors.TextEdit()
        Me.lblPropPointType = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropParent = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropNext = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropPrev = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtPropPointType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPropPointType
        '
        resources.ApplyResources(Me.txtPropPointType, "txtPropPointType")
        Me.txtPropPointType.Name = "txtPropPointType"
        Me.txtPropPointType.Properties.ReadOnly = True
        '
        'lblPropPointType
        '
        resources.ApplyResources(Me.lblPropPointType, "lblPropPointType")
        Me.lblPropPointType.Name = "lblPropPointType"
        '
        'cmdPropParent
        '
        resources.ApplyResources(Me.cmdPropParent, "cmdPropParent")
        Me.cmdPropParent.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropParent.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.levelup
        Me.cmdPropParent.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropParent.Name = "cmdPropParent"
        '
        'cmdPropNext
        '
        Me.cmdPropNext.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropNext.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropNext.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropNext.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropNext, "cmdPropNext")
        Me.cmdPropNext.Name = "cmdPropNext"
        '
        'cmdPropPrev
        '
        Me.cmdPropPrev.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropPrev.ImageOptions.SvgImage = CType(resources.GetObject("cmdPropPrev.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.cmdPropPrev.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropPrev, "cmdPropPrev")
        Me.cmdPropPrev.Name = "cmdPropPrev"
        '
        'cItemPointNavigatorPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtPropPointType)
        Me.Controls.Add(Me.lblPropPointType)
        Me.Controls.Add(Me.cmdPropParent)
        Me.Controls.Add(Me.cmdPropNext)
        Me.Controls.Add(Me.cmdPropPrev)
        Me.Name = "cItemPointNavigatorPropertyControl"
        CType(Me.txtPropPointType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropCaveBranchListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboPropCaveListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents txtPropPointType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPropPointType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropParent As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropNext As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropPrev As DevExpress.XtraEditors.SimpleButton
End Class
