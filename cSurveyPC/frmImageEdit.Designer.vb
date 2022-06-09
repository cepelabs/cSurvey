<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImageEdit
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageEdit))
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.cmdok = New DevExpress.XtraBars.BarButtonItem()
        Me.cmdCancel = New DevExpress.XtraBars.BarButtonItem()
        Me.btnLoadImage = New DevExpress.XtraBars.BarButtonItem()
        Me.btnUndo = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRotate = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFlipH = New DevExpress.XtraBars.BarButtonItem()
        Me.btnFlipV = New DevExpress.XtraBars.BarButtonItem()
        Me.btnToGrayscale = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRubber = New DevExpress.XtraBars.BarCheckItem()
        Me.btnRubberSize = New DevExpress.XtraBars.BarEditItem()
        Me.pbRubberSize = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.btnStop = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCropStart = New DevExpress.XtraBars.BarCheckItem()
        Me.btnCrop = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale = New DevExpress.XtraBars.BarSubItem()
        Me.btnRescale0 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale1 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale2 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRescale3 = New DevExpress.XtraBars.BarButtonItem()
        Me.btnSetTransparent = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTransparentThreshold = New DevExpress.XtraBars.BarEditItem()
        Me.txtTransparentThreshold = New DevExpress.XtraEditors.Repository.RepositoryItemTrackBar()
        Me.btnDeleteTransparent = New DevExpress.XtraBars.BarButtonItem()
        Me.btnTransparency = New DevExpress.XtraBars.BarSubItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.pnlPreview = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.mnuPreview = New DevExpress.XtraBars.PopupMenu(Me.components)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbRubberSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransparentThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreview.SuspendLayout()
        CType(Me.mnuPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.RibbonControl1.CaptionBarItemLinks.Add(Me.cmdok)
        Me.RibbonControl1.CaptionBarItemLinks.Add(Me.cmdCancel)
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.cmdok, Me.cmdCancel, Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.btnLoadImage, Me.btnUndo, Me.btnRotate, Me.btnFlipH, Me.btnFlipV, Me.btnToGrayscale, Me.btnRubber, Me.btnRubberSize, Me.btnStop, Me.btnCropStart, Me.btnCrop, Me.btnRescale, Me.btnRescale0, Me.btnRescale1, Me.btnRescale2, Me.btnRescale3, Me.btnSetTransparent, Me.btnTransparentThreshold, Me.btnDeleteTransparent, Me.btnTransparency})
        resources.ApplyResources(Me.RibbonControl1, "RibbonControl1")
        Me.RibbonControl1.MaxItemId = 23
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.QuickToolbarItemLinks.Add(Me.btnLoadImage)
        Me.RibbonControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.pbRubberSize, Me.txtTransparentThreshold})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages
        '
        'cmdok
        '
        resources.ApplyResources(Me.cmdok, "cmdok")
        Me.cmdok.Id = 2
        Me.cmdok.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_checkcircled
        Me.cmdok.Name = "cmdok"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.Id = 3
        Me.cmdCancel.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.close
        Me.cmdCancel.Name = "cmdCancel"
        '
        'btnLoadImage
        '
        resources.ApplyResources(Me.btnLoadImage, "btnLoadImage")
        Me.btnLoadImage.Id = 1
        Me.btnLoadImage.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.imageimport
        Me.btnLoadImage.Name = "btnLoadImage"
        '
        'btnUndo
        '
        resources.ApplyResources(Me.btnUndo, "btnUndo")
        Me.btnUndo.Enabled = False
        Me.btnUndo.Id = 4
        Me.btnUndo.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.undo
        Me.btnUndo.Name = "btnUndo"
        '
        'btnRotate
        '
        resources.ApplyResources(Me.btnRotate, "btnRotate")
        Me.btnRotate.Id = 5
        Me.btnRotate.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.rotate_right901
        Me.btnRotate.Name = "btnRotate"
        Me.btnRotate.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnFlipH
        '
        resources.ApplyResources(Me.btnFlipH, "btnFlipH")
        Me.btnFlipH.Id = 6
        Me.btnFlipH.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.flipimage_horizontal
        Me.btnFlipH.Name = "btnFlipH"
        Me.btnFlipH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnFlipV
        '
        resources.ApplyResources(Me.btnFlipV, "btnFlipV")
        Me.btnFlipV.Id = 7
        Me.btnFlipV.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.flipimage_vertical
        Me.btnFlipV.Name = "btnFlipV"
        Me.btnFlipV.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnToGrayscale
        '
        resources.ApplyResources(Me.btnToGrayscale, "btnToGrayscale")
        Me.btnToGrayscale.Id = 8
        Me.btnToGrayscale.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.grayscale
        Me.btnToGrayscale.Name = "btnToGrayscale"
        Me.btnToGrayscale.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnRubber
        '
        resources.ApplyResources(Me.btnRubber, "btnRubber")
        Me.btnRubber.Id = 9
        Me.btnRubber.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.clearall
        Me.btnRubber.Name = "btnRubber"
        '
        'btnRubberSize
        '
        resources.ApplyResources(Me.btnRubberSize, "btnRubberSize")
        Me.btnRubberSize.Edit = Me.pbRubberSize
        Me.btnRubberSize.EditValue = "2"
        Me.btnRubberSize.Id = 10
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
        'btnStop
        '
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.Id = 11
        Me.btnStop.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._stop
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnCropStart
        '
        resources.ApplyResources(Me.btnCropStart, "btnCropStart")
        Me.btnCropStart.Id = 12
        Me.btnCropStart.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.crop2
        Me.btnCropStart.Name = "btnCropStart"
        '
        'btnCrop
        '
        resources.ApplyResources(Me.btnCrop, "btnCrop")
        Me.btnCrop.Id = 13
        Me.btnCrop.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.crop1
        Me.btnCrop.Name = "btnCrop"
        Me.btnCrop.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'btnRescale
        '
        resources.ApplyResources(Me.btnRescale, "btnRescale")
        Me.btnRescale.Id = 14
        Me.btnRescale.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.imagedownsize
        Me.btnRescale.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale0), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale1), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale2), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRescale3)})
        Me.btnRescale.Name = "btnRescale"
        Me.btnRescale.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText
        '
        'btnRescale0
        '
        resources.ApplyResources(Me.btnRescale0, "btnRescale0")
        Me.btnRescale0.Id = 15
        Me.btnRescale0.Name = "btnRescale0"
        '
        'btnRescale1
        '
        resources.ApplyResources(Me.btnRescale1, "btnRescale1")
        Me.btnRescale1.Id = 16
        Me.btnRescale1.Name = "btnRescale1"
        '
        'btnRescale2
        '
        resources.ApplyResources(Me.btnRescale2, "btnRescale2")
        Me.btnRescale2.Id = 17
        Me.btnRescale2.Name = "btnRescale2"
        '
        'btnRescale3
        '
        resources.ApplyResources(Me.btnRescale3, "btnRescale3")
        Me.btnRescale3.Id = 18
        Me.btnRescale3.Name = "btnRescale3"
        '
        'btnSetTransparent
        '
        resources.ApplyResources(Me.btnSetTransparent, "btnSetTransparent")
        Me.btnSetTransparent.Id = 19
        Me.btnSetTransparent.Name = "btnSetTransparent"
        '
        'btnTransparentThreshold
        '
        resources.ApplyResources(Me.btnTransparentThreshold, "btnTransparentThreshold")
        Me.btnTransparentThreshold.Edit = Me.txtTransparentThreshold
        Me.btnTransparentThreshold.Id = 20
        Me.btnTransparentThreshold.Name = "btnTransparentThreshold"
        '
        'txtTransparentThreshold
        '
        Me.txtTransparentThreshold.LabelAppearance.Options.UseTextOptions = True
        Me.txtTransparentThreshold.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtTransparentThreshold.LargeChange = 10
        Me.txtTransparentThreshold.Maximum = 100
        Me.txtTransparentThreshold.Name = "txtTransparentThreshold"
        Me.txtTransparentThreshold.TickFrequency = 10
        '
        'btnDeleteTransparent
        '
        resources.ApplyResources(Me.btnDeleteTransparent, "btnDeleteTransparent")
        Me.btnDeleteTransparent.Id = 21
        Me.btnDeleteTransparent.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.delete1
        Me.btnDeleteTransparent.Name = "btnDeleteTransparent"
        '
        'btnTransparency
        '
        resources.ApplyResources(Me.btnTransparency, "btnTransparency")
        Me.btnTransparency.Id = 22
        Me.btnTransparency.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSetTransparent), New DevExpress.XtraBars.LinkPersistInfo(Me.btnTransparentThreshold), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDeleteTransparent, True)})
        Me.btnTransparency.Name = "btnTransparency"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup3, Me.RibbonPageGroup2})
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
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnRubber)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnRubberSize)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnCropStart, True)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnCrop)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnStop, True)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        resources.ApplyResources(Me.RibbonPageGroup3, "RibbonPageGroup3")
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.Alignment = DevExpress.XtraBars.Ribbon.RibbonPageGroupAlignment.Far
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdok)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.cmdCancel)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        resources.ApplyResources(Me.RibbonPageGroup2, "RibbonPageGroup2")
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        resources.ApplyResources(Me.RibbonPage2, "RibbonPage2")
        '
        'pnlPreview
        '
        Me.pnlPreview.Controls.Add(Me.picPreview)
        resources.ApplyResources(Me.pnlPreview, "pnlPreview")
        Me.pnlPreview.Name = "pnlPreview"
        '
        'mnuPreview
        '
        Me.mnuPreview.ItemLinks.Add(Me.btnTransparency)
        Me.mnuPreview.ItemLinks.Add(Me.btnStop, True)
        Me.mnuPreview.Name = "mnuPreview"
        Me.mnuPreview.Ribbon = Me.RibbonControl1
        '
        'frmImageEdit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.RibbonControl1)
        Me.IconOptions.Icon = CType(resources.GetObject("frmImageEdit.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.item_image
        Me.KeyPreview = True
        Me.Name = "frmImageEdit"
        Me.Ribbon = Me.RibbonControl1
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbRubberSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransparentThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.mnuPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents btnLoadImage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdok As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmdCancel As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnUndo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRotate As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFlipH As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnFlipV As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnToGrayscale As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRubber As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnRubberSize As DevExpress.XtraBars.BarEditItem
    Friend WithEvents pbRubberSize As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents btnStop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCropStart As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents btnCrop As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btnRescale As DevExpress.XtraBars.BarSubItem
    Friend WithEvents btnRescale0 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRescale3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents pnlPreview As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents btnSetTransparent As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnTransparentThreshold As DevExpress.XtraBars.BarEditItem
    Friend WithEvents txtTransparentThreshold As DevExpress.XtraEditors.Repository.RepositoryItemTrackBar
    Friend WithEvents btnDeleteTransparent As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnuPreview As DevExpress.XtraBars.PopupMenu
    Friend WithEvents btnTransparency As DevExpress.XtraBars.BarSubItem
End Class
