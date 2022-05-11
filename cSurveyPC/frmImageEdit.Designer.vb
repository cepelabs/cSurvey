<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImageEdit
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageEdit))
        Me.pnlPreview = New System.Windows.Forms.SplitContainer()
        Me.picPreview = New System.Windows.Forms.PictureBox()
        Me.mnuPreview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuPreviewSetTransparent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewTransparentThreshold11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewDeleteTransparent = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreviewStop = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.imlStations = New System.Windows.Forms.ImageList(Me.components)
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnLoadImage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRescale = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnRescale0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRescale1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRescale2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRescale3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRotate = New System.Windows.Forms.ToolStripButton()
        Me.btnFlip = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnFlipH = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFlipV = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnToGrayscale = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRubber = New System.Windows.Forms.ToolStripButton()
        Me.btnRubber0 = New System.Windows.Forms.ToolStripButton()
        Me.btnRubber1 = New System.Windows.Forms.ToolStripButton()
        Me.btnRubber2 = New System.Windows.Forms.ToolStripButton()
        Me.btnRubber3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnShowCutBorders = New System.Windows.Forms.ToolStripButton()
        Me.btnCut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.tipStandard = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pnlPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPreview.Panel2.SuspendLayout()
        Me.pnlPreview.SuspendLayout()
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuPreview.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPreview
        '
        resources.ApplyResources(Me.pnlPreview, "pnlPreview")
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Panel1Collapsed = True
        '
        'pnlPreview.Panel2
        '
        resources.ApplyResources(Me.pnlPreview.Panel2, "pnlPreview.Panel2")
        Me.pnlPreview.Panel2.BackColor = System.Drawing.SystemColors.ControlDark
        Me.pnlPreview.Panel2.Controls.Add(Me.picPreview)
        '
        'picPreview
        '
        Me.picPreview.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picPreview.ContextMenuStrip = Me.mnuPreview
        resources.ApplyResources(Me.picPreview, "picPreview")
        Me.picPreview.Name = "picPreview"
        Me.picPreview.TabStop = False
        '
        'mnuPreview
        '
        resources.ApplyResources(Me.mnuPreview, "mnuPreview")
        Me.mnuPreview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreviewSetTransparent, Me.mnuPreviewTransparentThreshold, Me.mnuPreviewDeleteTransparent, Me.mnuPreviewStop})
        Me.mnuPreview.Name = "mnuPreview"
        '
        'mnuPreviewSetTransparent
        '
        Me.mnuPreviewSetTransparent.Name = "mnuPreviewSetTransparent"
        resources.ApplyResources(Me.mnuPreviewSetTransparent, "mnuPreviewSetTransparent")
        '
        'mnuPreviewTransparentThreshold
        '
        Me.mnuPreviewTransparentThreshold.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPreviewTransparentThreshold1, Me.mnuPreviewTransparentThreshold2, Me.mnuPreviewTransparentThreshold3, Me.mnuPreviewTransparentThreshold4, Me.mnuPreviewTransparentThreshold5, Me.mnuPreviewTransparentThreshold6, Me.mnuPreviewTransparentThreshold7, Me.mnuPreviewTransparentThreshold8, Me.mnuPreviewTransparentThreshold9, Me.mnuPreviewTransparentThreshold10, Me.mnuPreviewTransparentThreshold11})
        Me.mnuPreviewTransparentThreshold.Name = "mnuPreviewTransparentThreshold"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold, "mnuPreviewTransparentThreshold")
        '
        'mnuPreviewTransparentThreshold1
        '
        Me.mnuPreviewTransparentThreshold1.Name = "mnuPreviewTransparentThreshold1"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold1, "mnuPreviewTransparentThreshold1")
        '
        'mnuPreviewTransparentThreshold2
        '
        Me.mnuPreviewTransparentThreshold2.Name = "mnuPreviewTransparentThreshold2"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold2, "mnuPreviewTransparentThreshold2")
        '
        'mnuPreviewTransparentThreshold3
        '
        Me.mnuPreviewTransparentThreshold3.Name = "mnuPreviewTransparentThreshold3"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold3, "mnuPreviewTransparentThreshold3")
        '
        'mnuPreviewTransparentThreshold4
        '
        Me.mnuPreviewTransparentThreshold4.Name = "mnuPreviewTransparentThreshold4"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold4, "mnuPreviewTransparentThreshold4")
        '
        'mnuPreviewTransparentThreshold5
        '
        Me.mnuPreviewTransparentThreshold5.Name = "mnuPreviewTransparentThreshold5"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold5, "mnuPreviewTransparentThreshold5")
        '
        'mnuPreviewTransparentThreshold6
        '
        Me.mnuPreviewTransparentThreshold6.Name = "mnuPreviewTransparentThreshold6"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold6, "mnuPreviewTransparentThreshold6")
        '
        'mnuPreviewTransparentThreshold7
        '
        Me.mnuPreviewTransparentThreshold7.Name = "mnuPreviewTransparentThreshold7"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold7, "mnuPreviewTransparentThreshold7")
        '
        'mnuPreviewTransparentThreshold8
        '
        Me.mnuPreviewTransparentThreshold8.Name = "mnuPreviewTransparentThreshold8"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold8, "mnuPreviewTransparentThreshold8")
        '
        'mnuPreviewTransparentThreshold9
        '
        Me.mnuPreviewTransparentThreshold9.Name = "mnuPreviewTransparentThreshold9"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold9, "mnuPreviewTransparentThreshold9")
        '
        'mnuPreviewTransparentThreshold10
        '
        Me.mnuPreviewTransparentThreshold10.Name = "mnuPreviewTransparentThreshold10"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold10, "mnuPreviewTransparentThreshold10")
        '
        'mnuPreviewTransparentThreshold11
        '
        Me.mnuPreviewTransparentThreshold11.Name = "mnuPreviewTransparentThreshold11"
        resources.ApplyResources(Me.mnuPreviewTransparentThreshold11, "mnuPreviewTransparentThreshold11")
        '
        'mnuPreviewDeleteTransparent
        '
        Me.mnuPreviewDeleteTransparent.Name = "mnuPreviewDeleteTransparent"
        resources.ApplyResources(Me.mnuPreviewDeleteTransparent, "mnuPreviewDeleteTransparent")
        '
        'mnuPreviewStop
        '
        Me.mnuPreviewStop.Image = Global.cSurveyPC.My.Resources.Resources.stop2
        Me.mnuPreviewStop.Name = "mnuPreviewStop"
        resources.ApplyResources(Me.mnuPreviewStop, "mnuPreviewStop")
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'imlStations
        '
        Me.imlStations.ImageStream = CType(resources.GetObject("imlStations.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlStations.TransparentColor = System.Drawing.Color.Transparent
        Me.imlStations.Images.SetKeyName(0, "pin")
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLoadImage, Me.ToolStripSeparator2, Me.btnUndo, Me.ToolStripSeparator4, Me.btnZoomIn, Me.btnZoomOut, Me.ToolStripSeparator3, Me.btnRescale, Me.btnRotate, Me.btnFlip, Me.ToolStripSeparator6, Me.btnToGrayscale, Me.ToolStripSeparator1, Me.btnRubber, Me.btnRubber0, Me.btnRubber1, Me.btnRubber2, Me.btnRubber3, Me.ToolStripSeparator5, Me.btnShowCutBorders, Me.btnCut, Me.ToolStripSeparator7, Me.btnStop})
        Me.tbMain.Name = "tbMain"
        '
        'btnLoadImage
        '
        Me.btnLoadImage.Image = Global.cSurveyPC.My.Resources.Resources.folder_picture
        resources.ApplyResources(Me.btnLoadImage, "btnLoadImage")
        Me.btnLoadImage.Name = "btnLoadImage"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUndo.Image = Global.cSurveyPC.My.Resources.Resources.arrow_undo
        resources.ApplyResources(Me.btnUndo, "btnUndo")
        Me.btnUndo.Name = "btnUndo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomIn.Image = Global.cSurveyPC.My.Resources.Resources.magnifier_zoom_in
        resources.ApplyResources(Me.btnZoomIn, "btnZoomIn")
        Me.btnZoomIn.Name = "btnZoomIn"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomOut.Image = Global.cSurveyPC.My.Resources.Resources.magnifier_zoom_out
        resources.ApplyResources(Me.btnZoomOut, "btnZoomOut")
        Me.btnZoomOut.Name = "btnZoomOut"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnRescale
        '
        Me.btnRescale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRescale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnRescale0, Me.btnRescale1, Me.btnRescale2, Me.btnRescale3})
        resources.ApplyResources(Me.btnRescale, "btnRescale")
        Me.btnRescale.Name = "btnRescale"
        '
        'btnRescale0
        '
        Me.btnRescale0.Name = "btnRescale0"
        resources.ApplyResources(Me.btnRescale0, "btnRescale0")
        '
        'btnRescale1
        '
        Me.btnRescale1.Name = "btnRescale1"
        resources.ApplyResources(Me.btnRescale1, "btnRescale1")
        '
        'btnRescale2
        '
        Me.btnRescale2.Name = "btnRescale2"
        resources.ApplyResources(Me.btnRescale2, "btnRescale2")
        '
        'btnRescale3
        '
        Me.btnRescale3.Name = "btnRescale3"
        resources.ApplyResources(Me.btnRescale3, "btnRescale3")
        '
        'btnRotate
        '
        Me.btnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnRotate, "btnRotate")
        Me.btnRotate.Name = "btnRotate"
        '
        'btnFlip
        '
        Me.btnFlip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnFlip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnFlipH, Me.btnFlipV})
        resources.ApplyResources(Me.btnFlip, "btnFlip")
        Me.btnFlip.Name = "btnFlip"
        '
        'btnFlipH
        '
        Me.btnFlipH.Name = "btnFlipH"
        resources.ApplyResources(Me.btnFlipH, "btnFlipH")
        '
        'btnFlipV
        '
        Me.btnFlipV.Name = "btnFlipV"
        resources.ApplyResources(Me.btnFlipV, "btnFlipV")
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'btnToGrayscale
        '
        Me.btnToGrayscale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnToGrayscale.Image = Global.cSurveyPC.My.Resources.Resources.convert_color_to_gray
        resources.ApplyResources(Me.btnToGrayscale, "btnToGrayscale")
        Me.btnToGrayscale.Name = "btnToGrayscale"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnRubber
        '
        Me.btnRubber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRubber.Image = Global.cSurveyPC.My.Resources.Resources.draw_eraser
        resources.ApplyResources(Me.btnRubber, "btnRubber")
        Me.btnRubber.Name = "btnRubber"
        '
        'btnRubber0
        '
        Me.btnRubber0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRubber0.Image = Global.cSurveyPC.My.Resources.Resources._0
        resources.ApplyResources(Me.btnRubber0, "btnRubber0")
        Me.btnRubber0.Name = "btnRubber0"
        '
        'btnRubber1
        '
        Me.btnRubber1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRubber1.Image = Global.cSurveyPC.My.Resources.Resources._1
        resources.ApplyResources(Me.btnRubber1, "btnRubber1")
        Me.btnRubber1.Name = "btnRubber1"
        '
        'btnRubber2
        '
        Me.btnRubber2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRubber2.Image = Global.cSurveyPC.My.Resources.Resources._2
        resources.ApplyResources(Me.btnRubber2, "btnRubber2")
        Me.btnRubber2.Name = "btnRubber2"
        '
        'btnRubber3
        '
        Me.btnRubber3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRubber3.Image = Global.cSurveyPC.My.Resources.Resources._3
        resources.ApplyResources(Me.btnRubber3, "btnRubber3")
        Me.btnRubber3.Name = "btnRubber3"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'btnShowCutBorders
        '
        Me.btnShowCutBorders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShowCutBorders.Image = Global.cSurveyPC.My.Resources.Resources.document_margins
        resources.ApplyResources(Me.btnShowCutBorders, "btnShowCutBorders")
        Me.btnShowCutBorders.Name = "btnShowCutBorders"
        '
        'btnCut
        '
        Me.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCut.Image = Global.cSurveyPC.My.Resources.Resources.transform_crop
        resources.ApplyResources(Me.btnCut, "btnCut")
        Me.btnCut.Name = "btnCut"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'btnStop
        '
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStop.Image = Global.cSurveyPC.My.Resources.Resources.stop2
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.Name = "btnStop"
        '
        'frmImageEdit
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.tbMain)
        Me.KeyPreview = True
        Me.Name = "frmImageEdit"
        Me.pnlPreview.Panel2.ResumeLayout(False)
        CType(Me.pnlPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPreview.ResumeLayout(False)
        CType(Me.picPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuPreview.ResumeLayout(False)
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents picPreview As System.Windows.Forms.PictureBox
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents imlStations As System.Windows.Forms.ImageList
    Friend WithEvents mnuPreview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents pnlPreview As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tipStandard As System.Windows.Forms.ToolTip
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRubber As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRubber1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRubber2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRubber0 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRubber3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLoadImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnToGrayscale As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPreviewSetTransparent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewDeleteTransparent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreviewTransparentThreshold11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnShowCutBorders As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRescale As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnRescale0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRescale1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRescale2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRescale3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRotate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFlip As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnFlipH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFlipV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuPreviewStop As System.Windows.Forms.ToolStripMenuItem
End Class
