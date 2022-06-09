<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDockAudioViewer
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                Call pDispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDockAudioViewer))
        Me.BarManager = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnPlay = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStop = New DevExpress.XtraBars.BarButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnGoToOwner = New DevExpress.XtraBars.BarButtonItem()
        Me.mnuAudio = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.grdSegmentAttachments = New DevExpress.XtraGrid.GridControl()
        Me.grdViewSegmentAttachments = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSegmentAttachmentsImage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.picSegmentAttachmentsImage = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.colSegmentAttachmentsName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentAttachmentsNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtSegmentAttachmentsNote = New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit()
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuAudio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSegmentAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdViewSegmentAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSegmentAttachmentsImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSegmentAttachmentsNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager
        '
        Me.BarManager.AllowCustomization = False
        Me.BarManager.AllowQuickCustomization = False
        Me.BarManager.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager.DockControls.Add(Me.barDockControlTop)
        Me.BarManager.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager.DockControls.Add(Me.barDockControlRight)
        Me.BarManager.Form = Me
        Me.BarManager.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRefresh, Me.btnPlay, Me.btnStop, Me.btnExport, Me.btnGoToOwner})
        Me.BarManager.MaxItemId = 15
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPlay, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnStop), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport, True), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRefresh, True)})
        Me.Bar1.OptionsBar.AllowQuickCustomization = False
        Me.Bar1.OptionsBar.DisableClose = True
        Me.Bar1.OptionsBar.DisableCustomization = True
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.OptionsBar.UseWholeRow = True
        resources.ApplyResources(Me.Bar1, "Bar1")
        '
        'btnPlay
        '
        resources.ApplyResources(Me.btnPlay, "btnPlay")
        Me.btnPlay.Enabled = False
        Me.btnPlay.Id = 11
        Me.btnPlay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._next
        Me.btnPlay.Name = "btnPlay"
        '
        'btnStop
        '
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.Enabled = False
        Me.btnStop.Id = 12
        Me.btnStop.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.stop1
        Me.btnStop.Name = "btnStop"
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Enabled = False
        Me.btnExport.Id = 13
        Me.btnExport.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.saveas
        Me.btnExport.Name = "btnExport"
        '
        'btnRefresh
        '
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_refresh
        Me.btnRefresh.Name = "btnRefresh"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        resources.ApplyResources(Me.barDockControlTop, "barDockControlTop")
        Me.barDockControlTop.Manager = Me.BarManager
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        resources.ApplyResources(Me.barDockControlBottom, "barDockControlBottom")
        Me.barDockControlBottom.Manager = Me.BarManager
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        resources.ApplyResources(Me.barDockControlLeft, "barDockControlLeft")
        Me.barDockControlLeft.Manager = Me.BarManager
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        resources.ApplyResources(Me.barDockControlRight, "barDockControlRight")
        Me.barDockControlRight.Manager = Me.BarManager
        '
        'btnGoToOwner
        '
        Me.btnGoToOwner.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left
        resources.ApplyResources(Me.btnGoToOwner, "btnGoToOwner")
        Me.btnGoToOwner.Enabled = False
        Me.btnGoToOwner.Id = 14
        Me.btnGoToOwner.Name = "btnGoToOwner"
        Me.btnGoToOwner.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'mnuAudio
        '
        Me.mnuAudio.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnPlay), New DevExpress.XtraBars.LinkPersistInfo(Me.btnStop), New DevExpress.XtraBars.LinkPersistInfo(Me.btnGoToOwner, True)})
        Me.mnuAudio.Manager = Me.BarManager
        Me.mnuAudio.Name = "mnuAudio"
        '
        'grdSegmentAttachments
        '
        Me.grdSegmentAttachments.AllowDrop = True
        resources.ApplyResources(Me.grdSegmentAttachments, "grdSegmentAttachments")
        Me.grdSegmentAttachments.MainView = Me.grdViewSegmentAttachments
        Me.grdSegmentAttachments.Name = "grdSegmentAttachments"
        Me.grdSegmentAttachments.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.picSegmentAttachmentsImage, Me.txtSegmentAttachmentsNote})
        Me.grdSegmentAttachments.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.grdViewSegmentAttachments})
        '
        'grdViewSegmentAttachments
        '
        Me.grdViewSegmentAttachments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.grdViewSegmentAttachments.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSegmentAttachmentsImage, Me.colSegmentAttachmentsName, Me.colSegmentAttachmentsNote})
        Me.grdViewSegmentAttachments.GridControl = Me.grdSegmentAttachments
        Me.grdViewSegmentAttachments.Name = "grdViewSegmentAttachments"
        Me.grdViewSegmentAttachments.OptionsBehavior.Editable = False
        Me.grdViewSegmentAttachments.OptionsBehavior.ReadOnly = True
        Me.grdViewSegmentAttachments.OptionsView.ColumnAutoWidth = False
        Me.grdViewSegmentAttachments.OptionsView.RowAutoHeight = True
        Me.grdViewSegmentAttachments.OptionsView.ShowGroupPanel = False
        '
        'colSegmentAttachmentsImage
        '
        resources.ApplyResources(Me.colSegmentAttachmentsImage, "colSegmentAttachmentsImage")
        Me.colSegmentAttachmentsImage.ColumnEdit = Me.picSegmentAttachmentsImage
        Me.colSegmentAttachmentsImage.FieldName = "_Image"
        Me.colSegmentAttachmentsImage.MaxWidth = 32
        Me.colSegmentAttachmentsImage.MinWidth = 32
        Me.colSegmentAttachmentsImage.Name = "colSegmentAttachmentsImage"
        Me.colSegmentAttachmentsImage.OptionsColumn.AllowEdit = False
        Me.colSegmentAttachmentsImage.OptionsColumn.AllowSize = False
        Me.colSegmentAttachmentsImage.OptionsColumn.FixedWidth = True
        Me.colSegmentAttachmentsImage.OptionsColumn.ReadOnly = True
        Me.colSegmentAttachmentsImage.UnboundType = DevExpress.Data.UnboundColumnType.[Object]
        '
        'picSegmentAttachmentsImage
        '
        Me.picSegmentAttachmentsImage.Name = "picSegmentAttachmentsImage"
        Me.picSegmentAttachmentsImage.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'colSegmentAttachmentsName
        '
        resources.ApplyResources(Me.colSegmentAttachmentsName, "colSegmentAttachmentsName")
        Me.colSegmentAttachmentsName.FieldName = "Attachment.Name"
        Me.colSegmentAttachmentsName.Name = "colSegmentAttachmentsName"
        '
        'colSegmentAttachmentsNote
        '
        resources.ApplyResources(Me.colSegmentAttachmentsNote, "colSegmentAttachmentsNote")
        Me.colSegmentAttachmentsNote.ColumnEdit = Me.txtSegmentAttachmentsNote
        Me.colSegmentAttachmentsNote.FieldName = "Attachment.Note"
        Me.colSegmentAttachmentsNote.Name = "colSegmentAttachmentsNote"
        '
        'txtSegmentAttachmentsNote
        '
        Me.txtSegmentAttachmentsNote.Name = "txtSegmentAttachmentsNote"
        '
        'cDockAudioViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grdSegmentAttachments)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "cDockAudioViewer"
        CType(Me.BarManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuAudio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSegmentAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdViewSegmentAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSegmentAttachmentsImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSegmentAttachmentsNote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents btnPlay As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExport As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnGoToOwner As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuAudio As DevExpress.XtraBars.PopupMenu
    Friend WithEvents grdSegmentAttachments As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdViewSegmentAttachments As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSegmentAttachmentsImage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents picSegmentAttachmentsImage As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents colSegmentAttachmentsName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentAttachmentsNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtSegmentAttachmentsNote As DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
End Class
