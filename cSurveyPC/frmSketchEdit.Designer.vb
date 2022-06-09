<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSketchEdit
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSketchEdit))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.grdStations = New cSurveyPC.cTrigpointsGrid()
        Me.pnlPreview = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdOk = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnLoadImage = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUndo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRotate = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFlipH = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFlipV = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale = New DevExpress.XtraBars.BarSubItem()
        Me.btnRescale0 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale1 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale3 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnToGrayscale = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRubber = New DevExpress.XtraBars.BarCheckItem()
        Me.btnRubberSize = New DevExpress.XtraBars.BarEditItem()
        Me.pbRubberSize = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.btnCropStart = New DevExpress.XtraBars.BarCheckItem()
        Me.btnCrop = New DevExpress.XtraBars.BarButtonItem()
        Me.btnStop = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSetTransparent = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTransparency = New DevExpress.XtraBars.BarSubItem()
        Me.btnTransparentThreshold = New DevExpress.XtraBars.BarEditItem()
        Me.txtTransparentThreshold = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.btnDeleteTransparent = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnAddExtra = New DevExpress.XtraBars.BarButtonItem()
        Me.btnEditDistance = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemove = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRemoveAll = New DevExpress.XtraBars.BarButtonItem()
        Me.btnShowSplays = New DevExpress.XtraBars.BarCheckItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.imlStations = New System.Windows.Forms.ImageList(Me.components)
        Me.tipStandard = New System.Windows.Forms.ToolTip(Me.components)
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.mnuPreview = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.mnuStations = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel1.SuspendLayout()
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.Panel2.SuspendLayout()
        Me.SplitContainerControl1.SuspendLayout()
        Me.pnlPreview.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRubberSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransparentThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mnuStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        resources.ApplyResources(Me.SplitContainerControl1, "SplitContainerControl1")
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        '
        'SplitContainerControl1.Panel1
        '
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.grdStations)
        resources.ApplyResources(Me.SplitContainerControl1.Panel1, "SplitContainerControl1.Panel1")
        '
        'SplitContainerControl1.Panel2
        '
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.pnlPreview)
        resources.ApplyResources(Me.SplitContainerControl1.Panel2, "SplitContainerControl1.Panel2")
        Me.SplitContainerControl1.SplitterPosition = 163
        '
        'grdStations
        '
        resources.ApplyResources(Me.grdStations, "grdStations")
        Me.grdStations.Name = "grdStations"
        '
        'pnlPreview
        '
        Me.pnlPreview.Controls.Add(Me.picPreview)
        resources.ApplyResources(Me.pnlPreview, "pnlPreview")
        Me.pnlPreview.Name = "pnlPreview"
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.SystemColors.ControlDark
        resources.ApplyResources(Me.picPreview, "picPreview")
        Me.picPreview.Name = "picPreview"
        Me.picPreview.TabStop = False
        '
        'RibbonControl1
        '
        Me.RibbonControl1.CaptionBarItemLinks.Add(Me.cmdOk)
        Me.RibbonControl1.CaptionBarItemLinks.Add(Me.cmdCancel)
        Me.RibbonControl1.Categories.AddRange(New DevExpress.XtraBars.BarManagerCategory() {CType(resources.GetObject("RibbonControl1.Categories"), DevExpress.XtraBars.BarManagerCategory), CType(resources.GetObject("RibbonControl1.Categories1"), DevExpress.XtraBars.BarManagerCategory), CType(resources.GetObject("RibbonControl1.Categories2"), DevExpress.XtraBars.BarManagerCategory), CType(resources.GetObject("RibbonControl1.Categories3"), DevExpress.XtraBars.BarManagerCategory), CType(resources.GetObject("RibbonControl1.Categories4"), DevExpress.XtraBars.BarManagerCategory)})
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cmdOk, Me.cmdCancel, Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.btnLoadImage, Me.btnUndo, Me.btnRotate, Me.btnFlipH, Me.btnFlipV, Me.btnRescale, Me.btnRescale0, Me.btnRescale1, Me.btnRescale2, Me.btnRescale3, Me.btnToGrayscale, Me.btnRubber, Me.btnRubberSize, Me.btnCropStart, Me.btnCrop, Me.btnStop, Me.btnSetTransparent, Me.btnTransparency, Me.btnTransparentThreshold, Me.btnDeleteTransparent, Me.btnAdd, Me.btnAddExtra, Me.btnEditDistance, Me.btnRemove, Me.btnRemoveAll, Me.btnShowSplays})
        resources.ApplyResources(Me.RibbonControl1, "RibbonControl1")
        Me.RibbonControl1.MaxItemId = 29
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnLoadImage)
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.pbRubberSize, Me.txtTransparentThreshold})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.CategoryGuid = New System.Guid("21e7edf1-2613-4fab-88ec-e6168d3e5d24")
        Me.cmdOk.Id = 17
        Me.cmdOk.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_checkcircled
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.CategoryGuid = New System.Guid("21e7edf1-2613-4fab-88ec-e6168d3e5d24")
        Me.cmdCancel.Id = 18
        Me.cmdCancel.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.close
        Me.cmdCancel.Name = "cmdCancel"
        '
        'btnLoadImage
        '
        resources.ApplyResources(Me.btnLoadImage, "btnLoadImage")
        Me.btnLoadImage.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnLoadImage.Id = 1
        Me.btnLoadImage.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.imageimport
        Me.btnLoadImage.Name = "btnLoadImage"
        '
        'btnUndo
        '
        resources.ApplyResources(Me.btnUndo, "btnUndo")
        Me.btnUndo.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnUndo.Enabled = False
        Me.btnUndo.Id = 2
        Me.btnUndo.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.undo
        Me.btnUndo.Name = "btnUndo"
        '
        'btnRotate
        '
        resources.ApplyResources(Me.btnRotate, "btnRotate")
        Me.btnRotate.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnRotate.Id = 3
        Me.btnRotate.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.rotate_right901
        Me.btnRotate.Name = "btnRotate"
        Me.btnRotate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnFlipH
        '
        resources.ApplyResources(Me.btnFlipH, "btnFlipH")
        Me.btnFlipH.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnFlipH.Id = 4
        Me.btnFlipH.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.flipimage_horizontal
        Me.btnFlipH.Name = "btnFlipH"
        Me.btnFlipH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnFlipV
        '
        resources.ApplyResources(Me.btnFlipV, "btnFlipV")
        Me.btnFlipV.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnFlipV.Id = 5
        Me.btnFlipV.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.flipimage_vertical
        Me.btnFlipV.Name = "btnFlipV"
        Me.btnFlipV.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnRescale
        '
        resources.ApplyResources(Me.btnRescale, "btnRescale")
        Me.btnRescale.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnRescale.Id = 6
        Me.btnRescale.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.imagedownsize
        Me.btnRescale.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale0), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale1), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale2), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale3)})
        Me.btnRescale.Name = "btnRescale"
        Me.btnRescale.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnRescale0
        '
        resources.ApplyResources(Me.btnRescale0, "btnRescale0")
        Me.btnRescale0.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnRescale0.Id = 7
        Me.btnRescale0.Name = "btnRescale0"
        '
        'btnRescale1
        '
        resources.ApplyResources(Me.btnRescale1, "btnRescale1")
        Me.btnRescale1.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnRescale1.Id = 8
        Me.btnRescale1.Name = "btnRescale1"
        '
        'btnRescale2
        '
        resources.ApplyResources(Me.btnRescale2, "btnRescale2")
        Me.btnRescale2.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnRescale2.Id = 9
        Me.btnRescale2.Name = "btnRescale2"
        '
        'btnRescale3
        '
        resources.ApplyResources(Me.btnRescale3, "btnRescale3")
        Me.btnRescale3.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnRescale3.Id = 10
        Me.btnRescale3.Name = "btnRescale3"
        '
        'btnToGrayscale
        '
        resources.ApplyResources(Me.btnToGrayscale, "btnToGrayscale")
        Me.btnToGrayscale.CategoryGuid = New System.Guid("8ae0dc63-bfb4-4aa4-991b-02f9302016ce")
        Me.btnToGrayscale.Id = 11
        Me.btnToGrayscale.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.grayscale
        Me.btnToGrayscale.Name = "btnToGrayscale"
        Me.btnToGrayscale.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnRubber
        '
        resources.ApplyResources(Me.btnRubber, "btnRubber")
        Me.btnRubber.CategoryGuid = New System.Guid("743c2f3f-e5fa-4a37-a53a-3b39314f5e36")
        Me.btnRubber.Id = 12
        Me.btnRubber.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnRubber.Name = "btnRubber"
        '
        'btnRubberSize
        '
        resources.ApplyResources(Me.btnRubberSize, "btnRubberSize")
        Me.btnRubberSize.CategoryGuid = New System.Guid("743c2f3f-e5fa-4a37-a53a-3b39314f5e36")
        Me.btnRubberSize.Edit = Me.pbRubberSize
        Me.btnRubberSize.EditValue = "2"
        Me.btnRubberSize.Id = 13
        Me.btnRubberSize.Name = "btnRubberSize"
        Me.btnRubberSize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'pbRubberSize
        '
        Me.pbRubberSize.LabelAppearance.Options.UseTextOptions = True
        Me.pbRubberSize.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.pbRubberSize.LargeChange = 2
        Me.pbRubberSize.Minimum = 1
        Me.pbRubberSize.Name = "pbRubberSize"
        '
        'btnCropStart
        '
        resources.ApplyResources(Me.btnCropStart, "btnCropStart")
        Me.btnCropStart.CategoryGuid = New System.Guid("743c2f3f-e5fa-4a37-a53a-3b39314f5e36")
        Me.btnCropStart.Id = 14
        Me.btnCropStart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.crop2
        Me.btnCropStart.Name = "btnCropStart"
        '
        'btnCrop
        '
        resources.ApplyResources(Me.btnCrop, "btnCrop")
        Me.btnCrop.CategoryGuid = New System.Guid("743c2f3f-e5fa-4a37-a53a-3b39314f5e36")
        Me.btnCrop.Id = 15
        Me.btnCrop.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.crop1
        Me.btnCrop.Name = "btnCrop"
        Me.btnCrop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnStop
        '
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.CategoryGuid = New System.Guid("743c2f3f-e5fa-4a37-a53a-3b39314f5e36")
        Me.btnStop.Id = 16
        Me.btnStop.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._stop
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnSetTransparent
        '
        resources.ApplyResources(Me.btnSetTransparent, "btnSetTransparent")
        Me.btnSetTransparent.CategoryGuid = New System.Guid("b77fe5ff-16a3-4da1-a6db-fac54765b6bc")
        Me.btnSetTransparent.Id = 19
        Me.btnSetTransparent.Name = "btnSetTransparent"
        '
        'btnTransparency
        '
        resources.ApplyResources(Me.btnTransparency, "btnTransparency")
        Me.btnTransparency.CategoryGuid = New System.Guid("b77fe5ff-16a3-4da1-a6db-fac54765b6bc")
        Me.btnTransparency.Id = 20
        Me.btnTransparency.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSetTransparent), New DevExpress.XtraBars.LinkPersistInfo(Me.btnTransparentThreshold), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeleteTransparent, True)})
        Me.btnTransparency.Name = "btnTransparency"
        '
        'btnTransparentThreshold
        '
        resources.ApplyResources(Me.btnTransparentThreshold, "btnTransparentThreshold")
        Me.btnTransparentThreshold.CategoryGuid = New System.Guid("b77fe5ff-16a3-4da1-a6db-fac54765b6bc")
        Me.btnTransparentThreshold.Edit = Me.txtTransparentThreshold
        Me.btnTransparentThreshold.Id = 21
        Me.btnTransparentThreshold.Name = "btnTransparentThreshold"
        '
        'txtTransparentThreshold
        '
        Me.txtTransparentThreshold.LabelAppearance.Options.UseTextOptions = True
        Me.txtTransparentThreshold.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtTransparentThreshold.Maximum = 100
        Me.txtTransparentThreshold.Name = "txtTransparentThreshold"
        Me.txtTransparentThreshold.TickFrequency = 10
        '
        'btnDeleteTransparent
        '
        resources.ApplyResources(Me.btnDeleteTransparent, "btnDeleteTransparent")
        Me.btnDeleteTransparent.CategoryGuid = New System.Guid("b77fe5ff-16a3-4da1-a6db-fac54765b6bc")
        Me.btnDeleteTransparent.Id = 22
        Me.btnDeleteTransparent.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnDeleteTransparent.Name = "btnDeleteTransparent"
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.CategoryGuid = New System.Guid("84e2e039-9d9b-43f9-917e-d0208e034bff")
        Me.btnAdd.Id = 23
        Me.btnAdd.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.btnAdd.Name = "btnAdd"
        '
        'btnAddExtra
        '
        resources.ApplyResources(Me.btnAddExtra, "btnAddExtra")
        Me.btnAddExtra.CategoryGuid = New System.Guid("84e2e039-9d9b-43f9-917e-d0208e034bff")
        Me.btnAddExtra.Id = 24
        Me.btnAddExtra.Name = "btnAddExtra"
        '
        'btnEditDistance
        '
        resources.ApplyResources(Me.btnEditDistance, "btnEditDistance")
        Me.btnEditDistance.CategoryGuid = New System.Guid("84e2e039-9d9b-43f9-917e-d0208e034bff")
        Me.btnEditDistance.Id = 25
        Me.btnEditDistance.Name = "btnEditDistance"
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.CategoryGuid = New System.Guid("84e2e039-9d9b-43f9-917e-d0208e034bff")
        Me.btnRemove.Id = 26
        Me.btnRemove.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnRemove.Name = "btnRemove"
        '
        'btnRemoveAll
        '
        resources.ApplyResources(Me.btnRemoveAll, "btnRemoveAll")
        Me.btnRemoveAll.CategoryGuid = New System.Guid("84e2e039-9d9b-43f9-917e-d0208e034bff")
        Me.btnRemoveAll.Id = 27
        Me.btnRemoveAll.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnRemoveAll.Name = "btnRemoveAll"
        '
        'btnShowSplays
        '
        resources.ApplyResources(Me.btnShowSplays, "btnShowSplays")
        Me.btnShowSplays.Id = 28
        Me.btnShowSplays.Name = "btnShowSplays"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3})
        Me.RibbonPage1.Name = "RibbonPage1"
        resources.ApplyResources(Me.RibbonPage1, "RibbonPage1")
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnLoadImage)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnUndo, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnRotate, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnFlipH)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnFlipV)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnRescale)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnToGrayscale)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        resources.ApplyResources(Me.RibbonPageGroup1, "RibbonPageGroup1")
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnRubber)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnRubberSize)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnCropStart, True)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnCrop)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnStop, True)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        resources.ApplyResources(Me.RibbonPageGroup2, "RibbonPageGroup2")
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far
        Me.RibbonPageGroup3.ItemLinks.Add(Me.cmdOk)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.cmdCancel)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        resources.ApplyResources(Me.RibbonPageGroup3, "RibbonPageGroup3")
        '
        'imlStations
        '
        Me.imlStations.ImageStream = CType(resources.GetObject("imlStations.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlStations.TransparentColor = System.Drawing.Color.Transparent
        Me.imlStations.Images.SetKeyName(0, "pin")
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        resources.ApplyResources(Me.RibbonPage2, "RibbonPage2")
        '
        'mnuPreview
        '
        Me.mnuPreview.ItemLinks.Add(Me.btnAdd, True)
        Me.mnuPreview.ItemLinks.Add(Me.btnAddExtra, True)
        Me.mnuPreview.ItemLinks.Add(Me.btnEditDistance)
        Me.mnuPreview.ItemLinks.Add(Me.btnRemove, True)
        Me.mnuPreview.ItemLinks.Add(Me.btnRemoveAll)
        Me.mnuPreview.ItemLinks.Add(Me.btnTransparency, True)
        Me.mnuPreview.ItemLinks.Add(Me.btnStop, True)
        Me.mnuPreview.Name = "mnuPreview"
        Me.mnuPreview.Ribbon = Me.RibbonControl1
        '
        'mnuStations
        '
        Me.mnuStations.ItemLinks.Add(Me.btnShowSplays)
        Me.mnuStations.Name = "mnuStations"
        Me.mnuStations.Ribbon = Me.RibbonControl1
        '
        'frmSketchEdit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.item_sketch
        Me.KeyPreview = True
        Me.Name = "frmSketchEdit"
        Me.Ribbon = Me.RibbonControl1
        CType(Me.SplitContainerControl1.Panel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainerControl1.Panel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRubberSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransparentThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mnuStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents imlStations As System.Windows.Forms.ImageList
    Friend WithEvents tipStandard As System.Windows.Forms.ToolTip
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents btnLoadImage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUndo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRotate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFlipH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFlipV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnRescale0 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnToGrayscale As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRubber As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnRubberSize As DevExpress.XtraBars.BarEditItem
    Friend WithEvents pbRubberSize As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents btnCropStart As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnCrop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnStop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents cmdOk As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPreview As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnSetTransparent As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTransparency As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnTransparentThreshold As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtTransparentThreshold As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents btnDeleteTransparent As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnAddExtra As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnEditDistance As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRemoveAll As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents pnlPreview As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents grdStations As cTrigpointsGrid
    Friend WithEvents btnShowSplays As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents mnuStations As DevExpress.XtraBars.PopupMenu
End Class
