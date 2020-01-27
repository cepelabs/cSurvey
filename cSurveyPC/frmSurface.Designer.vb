<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSurface
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurface))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tabPhoto = New System.Windows.Forms.TabPage()
        Me.picOrthoPhotoPreview = New System.Windows.Forms.PictureBox()
        Me.mnuOrthophotosPreview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOrthophotoPreviewElevationFromOrthophoto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrthophotosPreviewInvertColors = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkOrthoPhotoDefault = New System.Windows.Forms.CheckBox()
        Me.txtOrthoPhotoInformation = New System.Windows.Forms.TextBox()
        Me.lvOrthoPhotos = New System.Windows.Forms.ListView()
        Me.mnuOrthophotos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuOrthophotosDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlOrthoPhotos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnOrthophotoAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOrthophotoDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnOrthophotoDeleteAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOrthophotoPreviewInvertColors = New System.Windows.Forms.ToolStripButton()
        Me.tabData = New System.Windows.Forms.TabPage()
        Me.picElevationsPreview = New System.Windows.Forms.PictureBox()
        Me.mnuElevationsPreview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuElevationsPreviewElevationOrthoPhotoFromWMS = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElevationsPreviewElevationOrthoPhotoFromWMSItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElevationsPreviewNewReduced = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElevationsPreviewNewReduced50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElevationsPreviewNewReduced33 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElevationsPreviewNewReduced25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuElevationsPreviewElevationSavePreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElevationsPreviewExportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuElevationsPreviewRemoveNODATA = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkElevationDefault = New System.Windows.Forms.CheckBox()
        Me.cboColorSchema = New System.Windows.Forms.ComboBox()
        Me.lblColorSchema = New System.Windows.Forms.Label()
        Me.txtElevationInformation = New System.Windows.Forms.TextBox()
        Me.lvElevations = New System.Windows.Forms.ListView()
        Me.mnuElevations = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuElevationsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlElevations = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.btnDataAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDataDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnDataDeleteAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnElevationsPreviewNewReduced = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnElevationsPreviewElevationSavePreview = New System.Windows.Forms.ToolStripButton()
        Me.btnElevationsPreviewExportData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnElevationsPreviewRemoveNODATA = New System.Windows.Forms.ToolStripButton()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabShape = New System.Windows.Forms.TabPage()
        Me.lvShapes = New System.Windows.Forms.ListView()
        Me.tabWMS = New System.Windows.Forms.TabPage()
        Me.lvWMSs = New System.Windows.Forms.ListView()
        Me.colWMSName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colWMSURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colWMSLayer = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuWMSs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuWMSsEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuWMSsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlWMS = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdWMSAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnWMSDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnWMSDeleteAll = New System.Windows.Forms.ToolStripButton()
        Me.pnlPopup = New System.Windows.Forms.Panel()
        Me.btnPopupClose = New System.Windows.Forms.Button()
        Me.lblPopupWarning = New System.Windows.Forms.Label()
        Me.picPopupWarning = New System.Windows.Forms.PictureBox()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.imlPopup = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.mnuOrthophotosPreviewNewReduced = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrthophotosPreviewNewReduced50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrthophotosPreviewNewReduced33 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOrthophotosPreviewNewReduced25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOrthophotosPreviewNewReduced = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tabPhoto.SuspendLayout()
        CType(Me.picOrthoPhotoPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuOrthophotosPreview.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.mnuOrthophotos.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tabData.SuspendLayout()
        CType(Me.picElevationsPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuElevationsPreview.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.mnuElevations.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.tabShape.SuspendLayout()
        Me.tabWMS.SuspendLayout()
        Me.mnuWMSs.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlPopup.SuspendLayout()
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'tabPhoto
        '
        Me.tabPhoto.Controls.Add(Me.picOrthoPhotoPreview)
        Me.tabPhoto.Controls.Add(Me.Panel2)
        Me.tabPhoto.Controls.Add(Me.lvOrthoPhotos)
        Me.tabPhoto.Controls.Add(Me.ToolStrip2)
        resources.ApplyResources(Me.tabPhoto, "tabPhoto")
        Me.tabPhoto.Name = "tabPhoto"
        Me.tabPhoto.UseVisualStyleBackColor = True
        '
        'picOrthoPhotoPreview
        '
        Me.picOrthoPhotoPreview.ContextMenuStrip = Me.mnuOrthophotosPreview
        resources.ApplyResources(Me.picOrthoPhotoPreview, "picOrthoPhotoPreview")
        Me.picOrthoPhotoPreview.Name = "picOrthoPhotoPreview"
        Me.picOrthoPhotoPreview.TabStop = False
        '
        'mnuOrthophotosPreview
        '
        resources.ApplyResources(Me.mnuOrthophotosPreview, "mnuOrthophotosPreview")
        Me.mnuOrthophotosPreview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOrthophotoPreviewElevationFromOrthophoto, Me.mnuOrthophotosPreviewNewReduced, Me.ToolStripMenuItem8, Me.mnuOrthophotosPreviewInvertColors})
        Me.mnuOrthophotosPreview.Name = "mnuElevationsPreview"
        '
        'mnuOrthophotoPreviewElevationFromOrthophoto
        '
        Me.mnuOrthophotoPreviewElevationFromOrthophoto.Name = "mnuOrthophotoPreviewElevationFromOrthophoto"
        resources.ApplyResources(Me.mnuOrthophotoPreviewElevationFromOrthophoto, "mnuOrthophotoPreviewElevationFromOrthophoto")
        '
        'mnuOrthophotosPreviewInvertColors
        '
        Me.mnuOrthophotosPreviewInvertColors.Image = Global.cSurveyPC.My.Resources.Resources.contrast
        Me.mnuOrthophotosPreviewInvertColors.Name = "mnuOrthophotosPreviewInvertColors"
        resources.ApplyResources(Me.mnuOrthophotosPreviewInvertColors, "mnuOrthophotosPreviewInvertColors")
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkOrthoPhotoDefault)
        Me.Panel2.Controls.Add(Me.txtOrthoPhotoInformation)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'chkOrthoPhotoDefault
        '
        resources.ApplyResources(Me.chkOrthoPhotoDefault, "chkOrthoPhotoDefault")
        Me.chkOrthoPhotoDefault.Name = "chkOrthoPhotoDefault"
        Me.chkOrthoPhotoDefault.UseVisualStyleBackColor = True
        '
        'txtOrthoPhotoInformation
        '
        resources.ApplyResources(Me.txtOrthoPhotoInformation, "txtOrthoPhotoInformation")
        Me.txtOrthoPhotoInformation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtOrthoPhotoInformation.Name = "txtOrthoPhotoInformation"
        '
        'lvOrthoPhotos
        '
        Me.lvOrthoPhotos.BackColor = System.Drawing.SystemColors.Control
        Me.lvOrthoPhotos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvOrthoPhotos.ContextMenuStrip = Me.mnuOrthophotos
        resources.ApplyResources(Me.lvOrthoPhotos, "lvOrthoPhotos")
        Me.lvOrthoPhotos.HideSelection = False
        Me.lvOrthoPhotos.LabelEdit = True
        Me.lvOrthoPhotos.LargeImageList = Me.imlOrthoPhotos
        Me.lvOrthoPhotos.MultiSelect = False
        Me.lvOrthoPhotos.Name = "lvOrthoPhotos"
        Me.lvOrthoPhotos.SmallImageList = Me.imlOrthoPhotos
        Me.lvOrthoPhotos.TileSize = New System.Drawing.Size(64, 64)
        Me.lvOrthoPhotos.UseCompatibleStateImageBehavior = False
        Me.lvOrthoPhotos.View = System.Windows.Forms.View.Tile
        '
        'mnuOrthophotos
        '
        resources.ApplyResources(Me.mnuOrthophotos, "mnuOrthophotos")
        Me.mnuOrthophotos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOrthophotosDelete})
        Me.mnuOrthophotos.Name = "mnuElevations"
        '
        'mnuOrthophotosDelete
        '
        Me.mnuOrthophotosDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuOrthophotosDelete.Name = "mnuOrthophotosDelete"
        resources.ApplyResources(Me.mnuOrthophotosDelete, "mnuOrthophotosDelete")
        '
        'imlOrthoPhotos
        '
        Me.imlOrthoPhotos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        resources.ApplyResources(Me.imlOrthoPhotos, "imlOrthoPhotos")
        Me.imlOrthoPhotos.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolStrip2
        '
        resources.ApplyResources(Me.ToolStrip2, "ToolStrip2")
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOrthophotoAdd, Me.ToolStripSeparator3, Me.btnOrthophotoDelete, Me.btnOrthophotoDeleteAll, Me.ToolStripSeparator5, Me.btnOrthophotosPreviewNewReduced, Me.ToolStripSeparator8, Me.btnOrthophotoPreviewInvertColors})
        Me.ToolStrip2.Name = "ToolStrip2"
        '
        'btnOrthophotoAdd
        '
        Me.btnOrthophotoAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnOrthophotoAdd, "btnOrthophotoAdd")
        Me.btnOrthophotoAdd.Name = "btnOrthophotoAdd"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnOrthophotoDelete
        '
        resources.ApplyResources(Me.btnOrthophotoDelete, "btnOrthophotoDelete")
        Me.btnOrthophotoDelete.Name = "btnOrthophotoDelete"
        '
        'btnOrthophotoDeleteAll
        '
        resources.ApplyResources(Me.btnOrthophotoDeleteAll, "btnOrthophotoDeleteAll")
        Me.btnOrthophotoDeleteAll.Name = "btnOrthophotoDeleteAll"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'btnOrthophotoPreviewInvertColors
        '
        Me.btnOrthophotoPreviewInvertColors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnOrthophotoPreviewInvertColors, "btnOrthophotoPreviewInvertColors")
        Me.btnOrthophotoPreviewInvertColors.Image = Global.cSurveyPC.My.Resources.Resources.contrast
        Me.btnOrthophotoPreviewInvertColors.Name = "btnOrthophotoPreviewInvertColors"
        '
        'tabData
        '
        Me.tabData.Controls.Add(Me.picElevationsPreview)
        Me.tabData.Controls.Add(Me.Panel3)
        Me.tabData.Controls.Add(Me.lvElevations)
        Me.tabData.Controls.Add(Me.ToolStrip3)
        resources.ApplyResources(Me.tabData, "tabData")
        Me.tabData.Name = "tabData"
        Me.tabData.UseVisualStyleBackColor = True
        '
        'picElevationsPreview
        '
        Me.picElevationsPreview.ContextMenuStrip = Me.mnuElevationsPreview
        resources.ApplyResources(Me.picElevationsPreview, "picElevationsPreview")
        Me.picElevationsPreview.Name = "picElevationsPreview"
        Me.picElevationsPreview.TabStop = False
        '
        'mnuElevationsPreview
        '
        resources.ApplyResources(Me.mnuElevationsPreview, "mnuElevationsPreview")
        Me.mnuElevationsPreview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuElevationsPreviewElevationOrthoPhotoFromWMS, Me.mnuElevationsPreviewNewReduced, Me.ToolStripMenuItem1, Me.mnuElevationsPreviewElevationSavePreview, Me.mnuElevationsPreviewExportData, Me.ToolStripMenuItem2, Me.mnuElevationsPreviewRemoveNODATA})
        Me.mnuElevationsPreview.Name = "mnuElevationsPreview"
        '
        'mnuElevationsPreviewElevationOrthoPhotoFromWMS
        '
        Me.mnuElevationsPreviewElevationOrthoPhotoFromWMS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuElevationsPreviewElevationOrthoPhotoFromWMSItem})
        Me.mnuElevationsPreviewElevationOrthoPhotoFromWMS.Name = "mnuElevationsPreviewElevationOrthoPhotoFromWMS"
        resources.ApplyResources(Me.mnuElevationsPreviewElevationOrthoPhotoFromWMS, "mnuElevationsPreviewElevationOrthoPhotoFromWMS")
        '
        'mnuElevationsPreviewElevationOrthoPhotoFromWMSItem
        '
        Me.mnuElevationsPreviewElevationOrthoPhotoFromWMSItem.Name = "mnuElevationsPreviewElevationOrthoPhotoFromWMSItem"
        resources.ApplyResources(Me.mnuElevationsPreviewElevationOrthoPhotoFromWMSItem, "mnuElevationsPreviewElevationOrthoPhotoFromWMSItem")
        '
        'mnuElevationsPreviewNewReduced
        '
        Me.mnuElevationsPreviewNewReduced.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuElevationsPreviewNewReduced50, Me.mnuElevationsPreviewNewReduced33, Me.mnuElevationsPreviewNewReduced25})
        Me.mnuElevationsPreviewNewReduced.Image = Global.cSurveyPC.My.Resources.Resources.resize_picture
        Me.mnuElevationsPreviewNewReduced.Name = "mnuElevationsPreviewNewReduced"
        resources.ApplyResources(Me.mnuElevationsPreviewNewReduced, "mnuElevationsPreviewNewReduced")
        '
        'mnuElevationsPreviewNewReduced50
        '
        Me.mnuElevationsPreviewNewReduced50.Name = "mnuElevationsPreviewNewReduced50"
        resources.ApplyResources(Me.mnuElevationsPreviewNewReduced50, "mnuElevationsPreviewNewReduced50")
        '
        'mnuElevationsPreviewNewReduced33
        '
        Me.mnuElevationsPreviewNewReduced33.Name = "mnuElevationsPreviewNewReduced33"
        resources.ApplyResources(Me.mnuElevationsPreviewNewReduced33, "mnuElevationsPreviewNewReduced33")
        '
        'mnuElevationsPreviewNewReduced25
        '
        Me.mnuElevationsPreviewNewReduced25.Name = "mnuElevationsPreviewNewReduced25"
        resources.ApplyResources(Me.mnuElevationsPreviewNewReduced25, "mnuElevationsPreviewNewReduced25")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuElevationsPreviewElevationSavePreview
        '
        Me.mnuElevationsPreviewElevationSavePreview.Image = Global.cSurveyPC.My.Resources.Resources.picture_save
        Me.mnuElevationsPreviewElevationSavePreview.Name = "mnuElevationsPreviewElevationSavePreview"
        resources.ApplyResources(Me.mnuElevationsPreviewElevationSavePreview, "mnuElevationsPreviewElevationSavePreview")
        '
        'mnuElevationsPreviewExportData
        '
        Me.mnuElevationsPreviewExportData.Image = Global.cSurveyPC.My.Resources.Resources.page_white_put
        Me.mnuElevationsPreviewExportData.Name = "mnuElevationsPreviewExportData"
        resources.ApplyResources(Me.mnuElevationsPreviewExportData, "mnuElevationsPreviewExportData")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuElevationsPreviewRemoveNODATA
        '
        Me.mnuElevationsPreviewRemoveNODATA.Name = "mnuElevationsPreviewRemoveNODATA"
        resources.ApplyResources(Me.mnuElevationsPreviewRemoveNODATA, "mnuElevationsPreviewRemoveNODATA")
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.chkElevationDefault)
        Me.Panel3.Controls.Add(Me.cboColorSchema)
        Me.Panel3.Controls.Add(Me.lblColorSchema)
        Me.Panel3.Controls.Add(Me.txtElevationInformation)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'chkElevationDefault
        '
        resources.ApplyResources(Me.chkElevationDefault, "chkElevationDefault")
        Me.chkElevationDefault.Name = "chkElevationDefault"
        Me.chkElevationDefault.UseVisualStyleBackColor = True
        '
        'cboColorSchema
        '
        resources.ApplyResources(Me.cboColorSchema, "cboColorSchema")
        Me.cboColorSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColorSchema.FormattingEnabled = True
        Me.cboColorSchema.Items.AddRange(New Object() {resources.GetString("cboColorSchema.Items"), resources.GetString("cboColorSchema.Items1")})
        Me.cboColorSchema.Name = "cboColorSchema"
        '
        'lblColorSchema
        '
        resources.ApplyResources(Me.lblColorSchema, "lblColorSchema")
        Me.lblColorSchema.Name = "lblColorSchema"
        '
        'txtElevationInformation
        '
        resources.ApplyResources(Me.txtElevationInformation, "txtElevationInformation")
        Me.txtElevationInformation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtElevationInformation.Name = "txtElevationInformation"
        '
        'lvElevations
        '
        Me.lvElevations.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lvElevations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvElevations.ContextMenuStrip = Me.mnuElevations
        resources.ApplyResources(Me.lvElevations, "lvElevations")
        Me.lvElevations.HideSelection = False
        Me.lvElevations.LabelEdit = True
        Me.lvElevations.LargeImageList = Me.imlElevations
        Me.lvElevations.MultiSelect = False
        Me.lvElevations.Name = "lvElevations"
        Me.lvElevations.SmallImageList = Me.imlElevations
        Me.lvElevations.TileSize = New System.Drawing.Size(64, 64)
        Me.lvElevations.UseCompatibleStateImageBehavior = False
        Me.lvElevations.View = System.Windows.Forms.View.Tile
        '
        'mnuElevations
        '
        resources.ApplyResources(Me.mnuElevations, "mnuElevations")
        Me.mnuElevations.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuElevationsDelete})
        Me.mnuElevations.Name = "mnuElevations"
        '
        'mnuElevationsDelete
        '
        Me.mnuElevationsDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuElevationsDelete.Name = "mnuElevationsDelete"
        resources.ApplyResources(Me.mnuElevationsDelete, "mnuElevationsDelete")
        '
        'imlElevations
        '
        Me.imlElevations.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        resources.ApplyResources(Me.imlElevations, "imlElevations")
        Me.imlElevations.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolStrip3
        '
        resources.ApplyResources(Me.ToolStrip3, "ToolStrip3")
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDataAdd, Me.ToolStripSeparator4, Me.btnDataDelete, Me.btnDataDeleteAll, Me.ToolStripSeparator1, Me.btnElevationsPreviewNewReduced, Me.ToolStripSeparator6, Me.btnElevationsPreviewElevationSavePreview, Me.btnElevationsPreviewExportData, Me.ToolStripSeparator7, Me.btnElevationsPreviewRemoveNODATA})
        Me.ToolStrip3.Name = "ToolStrip3"
        '
        'btnDataAdd
        '
        Me.btnDataAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.btnDataAdd, "btnDataAdd")
        Me.btnDataAdd.Name = "btnDataAdd"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnDataDelete
        '
        resources.ApplyResources(Me.btnDataDelete, "btnDataDelete")
        Me.btnDataDelete.Name = "btnDataDelete"
        '
        'btnDataDeleteAll
        '
        resources.ApplyResources(Me.btnDataDeleteAll, "btnDataDeleteAll")
        Me.btnDataDeleteAll.Name = "btnDataDeleteAll"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnElevationsPreviewNewReduced
        '
        Me.btnElevationsPreviewNewReduced.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnElevationsPreviewNewReduced, "btnElevationsPreviewNewReduced")
        Me.btnElevationsPreviewNewReduced.Image = Global.cSurveyPC.My.Resources.Resources.resize_picture
        Me.btnElevationsPreviewNewReduced.Name = "btnElevationsPreviewNewReduced"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'btnElevationsPreviewElevationSavePreview
        '
        Me.btnElevationsPreviewElevationSavePreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnElevationsPreviewElevationSavePreview, "btnElevationsPreviewElevationSavePreview")
        Me.btnElevationsPreviewElevationSavePreview.Image = Global.cSurveyPC.My.Resources.Resources.picture_save
        Me.btnElevationsPreviewElevationSavePreview.Name = "btnElevationsPreviewElevationSavePreview"
        '
        'btnElevationsPreviewExportData
        '
        Me.btnElevationsPreviewExportData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnElevationsPreviewExportData, "btnElevationsPreviewExportData")
        Me.btnElevationsPreviewExportData.Image = Global.cSurveyPC.My.Resources.Resources.page_white_put
        Me.btnElevationsPreviewExportData.Name = "btnElevationsPreviewExportData"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'btnElevationsPreviewRemoveNODATA
        '
        Me.btnElevationsPreviewRemoveNODATA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnElevationsPreviewRemoveNODATA, "btnElevationsPreviewRemoveNODATA")
        Me.btnElevationsPreviewRemoveNODATA.Name = "btnElevationsPreviewRemoveNODATA"
        '
        'tabMain
        '
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Controls.Add(Me.tabData)
        Me.tabMain.Controls.Add(Me.tabPhoto)
        Me.tabMain.Controls.Add(Me.tabShape)
        Me.tabMain.Controls.Add(Me.tabWMS)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        '
        'tabShape
        '
        Me.tabShape.Controls.Add(Me.lvShapes)
        resources.ApplyResources(Me.tabShape, "tabShape")
        Me.tabShape.Name = "tabShape"
        Me.tabShape.UseVisualStyleBackColor = True
        '
        'lvShapes
        '
        resources.ApplyResources(Me.lvShapes, "lvShapes")
        Me.lvShapes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvShapes.HideSelection = False
        Me.lvShapes.LabelEdit = True
        Me.lvShapes.LargeImageList = Me.imlOrthoPhotos
        Me.lvShapes.MultiSelect = False
        Me.lvShapes.Name = "lvShapes"
        Me.lvShapes.SmallImageList = Me.imlOrthoPhotos
        Me.lvShapes.TileSize = New System.Drawing.Size(64, 64)
        Me.lvShapes.UseCompatibleStateImageBehavior = False
        Me.lvShapes.View = System.Windows.Forms.View.Tile
        '
        'tabWMS
        '
        Me.tabWMS.Controls.Add(Me.lvWMSs)
        Me.tabWMS.Controls.Add(Me.ToolStrip1)
        resources.ApplyResources(Me.tabWMS, "tabWMS")
        Me.tabWMS.Name = "tabWMS"
        Me.tabWMS.UseVisualStyleBackColor = True
        '
        'lvWMSs
        '
        Me.lvWMSs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvWMSs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colWMSName, Me.colWMSURL, Me.colWMSLayer})
        Me.lvWMSs.ContextMenuStrip = Me.mnuWMSs
        resources.ApplyResources(Me.lvWMSs, "lvWMSs")
        Me.lvWMSs.FullRowSelect = True
        Me.lvWMSs.HideSelection = False
        Me.lvWMSs.LargeImageList = Me.imlOrthoPhotos
        Me.lvWMSs.MultiSelect = False
        Me.lvWMSs.Name = "lvWMSs"
        Me.lvWMSs.SmallImageList = Me.imlWMS
        Me.lvWMSs.TileSize = New System.Drawing.Size(64, 64)
        Me.lvWMSs.UseCompatibleStateImageBehavior = False
        Me.lvWMSs.View = System.Windows.Forms.View.Details
        '
        'colWMSName
        '
        resources.ApplyResources(Me.colWMSName, "colWMSName")
        '
        'colWMSURL
        '
        resources.ApplyResources(Me.colWMSURL, "colWMSURL")
        '
        'colWMSLayer
        '
        resources.ApplyResources(Me.colWMSLayer, "colWMSLayer")
        '
        'mnuWMSs
        '
        resources.ApplyResources(Me.mnuWMSs, "mnuWMSs")
        Me.mnuWMSs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuWMSsEdit, Me.ToolStripMenuItem3, Me.mnuWMSsDelete})
        Me.mnuWMSs.Name = "mnuWMSs"
        '
        'mnuWMSsEdit
        '
        Me.mnuWMSsEdit.Name = "mnuWMSsEdit"
        resources.ApplyResources(Me.mnuWMSsEdit, "mnuWMSsEdit")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuWMSsDelete
        '
        Me.mnuWMSsDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuWMSsDelete.Name = "mnuWMSsDelete"
        resources.ApplyResources(Me.mnuWMSsDelete, "mnuWMSsDelete")
        '
        'imlWMS
        '
        Me.imlWMS.ImageStream = CType(resources.GetObject("imlWMS.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlWMS.TransparentColor = System.Drawing.Color.Transparent
        Me.imlWMS.Images.SetKeyName(0, "layer_wms")
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdWMSAdd, Me.ToolStripSeparator2, Me.btnWMSDelete, Me.btnWMSDeleteAll})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'cmdWMSAdd
        '
        Me.cmdWMSAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        resources.ApplyResources(Me.cmdWMSAdd, "cmdWMSAdd")
        Me.cmdWMSAdd.Name = "cmdWMSAdd"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnWMSDelete
        '
        resources.ApplyResources(Me.btnWMSDelete, "btnWMSDelete")
        Me.btnWMSDelete.Name = "btnWMSDelete"
        '
        'btnWMSDeleteAll
        '
        resources.ApplyResources(Me.btnWMSDeleteAll, "btnWMSDeleteAll")
        Me.btnWMSDeleteAll.Name = "btnWMSDeleteAll"
        '
        'pnlPopup
        '
        Me.pnlPopup.Controls.Add(Me.btnPopupClose)
        Me.pnlPopup.Controls.Add(Me.lblPopupWarning)
        Me.pnlPopup.Controls.Add(Me.picPopupWarning)
        resources.ApplyResources(Me.pnlPopup, "pnlPopup")
        Me.pnlPopup.Name = "pnlPopup"
        '
        'btnPopupClose
        '
        resources.ApplyResources(Me.btnPopupClose, "btnPopupClose")
        Me.btnPopupClose.BackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatAppearance.BorderSize = 0
        Me.btnPopupClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.btnPopupClose.Name = "btnPopupClose"
        Me.btnPopupClose.UseVisualStyleBackColor = False
        '
        'lblPopupWarning
        '
        resources.ApplyResources(Me.lblPopupWarning, "lblPopupWarning")
        Me.lblPopupWarning.Name = "lblPopupWarning"
        '
        'picPopupWarning
        '
        resources.ApplyResources(Me.picPopupWarning, "picPopupWarning")
        Me.picPopupWarning.Name = "picPopupWarning"
        Me.picPopupWarning.TabStop = False
        '
        'imlPopup
        '
        Me.imlPopup.ImageStream = CType(resources.GetObject("imlPopup.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPopup.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPopup.Images.SetKeyName(0, "warning")
        Me.imlPopup.Images.SetKeyName(1, "calculate")
        Me.imlPopup.Images.SetKeyName(2, "error")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmdCancel)
        Me.Panel1.Controls.Add(Me.tabMain)
        Me.Panel1.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'mnuOrthophotosPreviewNewReduced
        '
        Me.mnuOrthophotosPreviewNewReduced.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOrthophotosPreviewNewReduced50, Me.mnuOrthophotosPreviewNewReduced33, Me.mnuOrthophotosPreviewNewReduced25})
        Me.mnuOrthophotosPreviewNewReduced.Image = Global.cSurveyPC.My.Resources.Resources.resize_picture
        Me.mnuOrthophotosPreviewNewReduced.Name = "mnuOrthophotosPreviewNewReduced"
        resources.ApplyResources(Me.mnuOrthophotosPreviewNewReduced, "mnuOrthophotosPreviewNewReduced")
        '
        'mnuOrthophotosPreviewNewReduced50
        '
        Me.mnuOrthophotosPreviewNewReduced50.Name = "mnuOrthophotosPreviewNewReduced50"
        resources.ApplyResources(Me.mnuOrthophotosPreviewNewReduced50, "mnuOrthophotosPreviewNewReduced50")
        '
        'mnuOrthophotosPreviewNewReduced33
        '
        Me.mnuOrthophotosPreviewNewReduced33.Name = "mnuOrthophotosPreviewNewReduced33"
        resources.ApplyResources(Me.mnuOrthophotosPreviewNewReduced33, "mnuOrthophotosPreviewNewReduced33")
        '
        'mnuOrthophotosPreviewNewReduced25
        '
        Me.mnuOrthophotosPreviewNewReduced25.Name = "mnuOrthophotosPreviewNewReduced25"
        resources.ApplyResources(Me.mnuOrthophotosPreviewNewReduced25, "mnuOrthophotosPreviewNewReduced25")
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        '
        'btnOrthophotosPreviewNewReduced
        '
        Me.btnOrthophotosPreviewNewReduced.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnOrthophotosPreviewNewReduced, "btnOrthophotosPreviewNewReduced")
        Me.btnOrthophotosPreviewNewReduced.Image = Global.cSurveyPC.My.Resources.Resources.resize_picture
        Me.btnOrthophotosPreviewNewReduced.Name = "btnOrthophotosPreviewNewReduced"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        '
        'frmSurface
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlPopup)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurface"
        Me.tabPhoto.ResumeLayout(False)
        Me.tabPhoto.PerformLayout()
        CType(Me.picOrthoPhotoPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuOrthophotosPreview.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.mnuOrthophotos.ResumeLayout(False)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tabData.ResumeLayout(False)
        Me.tabData.PerformLayout()
        CType(Me.picElevationsPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuElevationsPreview.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.mnuElevations.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.tabMain.ResumeLayout(False)
        Me.tabShape.ResumeLayout(False)
        Me.tabWMS.ResumeLayout(False)
        Me.tabWMS.PerformLayout()
        Me.mnuWMSs.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlPopup.ResumeLayout(False)
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tabPhoto As System.Windows.Forms.TabPage
    Friend WithEvents txtOrthoPhotoInformation As System.Windows.Forms.TextBox
    Friend WithEvents picOrthoPhotoPreview As System.Windows.Forms.PictureBox
    Friend WithEvents tabData As System.Windows.Forms.TabPage
    Friend WithEvents cboColorSchema As System.Windows.Forms.ComboBox
    Friend WithEvents lblColorSchema As System.Windows.Forms.Label
    Friend WithEvents picElevationsPreview As System.Windows.Forms.PictureBox
    Friend WithEvents txtElevationInformation As System.Windows.Forms.TextBox
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents lvOrthoPhotos As System.Windows.Forms.ListView
    Friend WithEvents imlOrthoPhotos As System.Windows.Forms.ImageList
    Friend WithEvents lvElevations As System.Windows.Forms.ListView
    Friend WithEvents imlElevations As System.Windows.Forms.ImageList
    Friend WithEvents chkElevationDefault As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrthoPhotoDefault As System.Windows.Forms.CheckBox
    Friend WithEvents mnuElevationsPreview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuElevationsPreviewElevationSavePreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuElevationsPreviewExportData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuElevationsPreviewRemoveNODATA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabShape As System.Windows.Forms.TabPage
    Friend WithEvents lvShapes As System.Windows.Forms.ListView
    Friend WithEvents pnlPopup As System.Windows.Forms.Panel
    Friend WithEvents btnPopupClose As System.Windows.Forms.Button
    Friend WithEvents lblPopupWarning As System.Windows.Forms.Label
    Friend WithEvents picPopupWarning As System.Windows.Forms.PictureBox
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents imlPopup As System.Windows.Forms.ImageList
    Friend WithEvents tabWMS As System.Windows.Forms.TabPage
    Friend WithEvents lvWMSs As System.Windows.Forms.ListView
    Friend WithEvents colWMSURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents colWMSLayer As System.Windows.Forms.ColumnHeader
    Friend WithEvents imlWMS As System.Windows.Forms.ImageList
    Friend WithEvents colWMSName As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuElevationsPreviewElevationOrthoPhotoFromWMS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuElevationsPreviewElevationOrthoPhotoFromWMSItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents mnuWMSs As ContextMenuStrip
    Friend WithEvents mnuWMSsEdit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents mnuWMSsDelete As ToolStripMenuItem
    Friend WithEvents mnuElevations As ContextMenuStrip
    Friend WithEvents mnuElevationsDelete As ToolStripMenuItem
    Friend WithEvents mnuOrthophotos As ContextMenuStrip
    Friend WithEvents mnuOrthophotosDelete As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents cmdWMSAdd As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnWMSDelete As ToolStripButton
    Friend WithEvents btnWMSDeleteAll As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnOrthophotoAdd As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnOrthophotoDelete As ToolStripButton
    Friend WithEvents btnOrthophotoDeleteAll As ToolStripButton
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents btnDataAdd As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btnDataDelete As ToolStripButton
    Friend WithEvents btnDataDeleteAll As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnElevationsPreviewElevationSavePreview As ToolStripButton
    Friend WithEvents btnElevationsPreviewExportData As ToolStripButton
    Friend WithEvents btnElevationsPreviewRemoveNODATA As ToolStripButton
    Friend WithEvents mnuOrthophotosPreview As ContextMenuStrip
    Friend WithEvents mnuOrthophotoPreviewElevationFromOrthophoto As ToolStripMenuItem
    Friend WithEvents mnuElevationsPreviewNewReduced As ToolStripMenuItem
    Friend WithEvents mnuOrthophotosPreviewInvertColors As ToolStripMenuItem
    Friend WithEvents mnuElevationsPreviewNewReduced50 As ToolStripMenuItem
    Friend WithEvents mnuElevationsPreviewNewReduced33 As ToolStripMenuItem
    Friend WithEvents mnuElevationsPreviewNewReduced25 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents btnOrthophotoPreviewInvertColors As ToolStripButton
    Friend WithEvents btnElevationsPreviewNewReduced As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents mnuOrthophotosPreviewNewReduced As ToolStripMenuItem
    Friend WithEvents mnuOrthophotosPreviewNewReduced50 As ToolStripMenuItem
    Friend WithEvents mnuOrthophotosPreviewNewReduced33 As ToolStripMenuItem
    Friend WithEvents mnuOrthophotosPreviewNewReduced25 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripSeparator
    Friend WithEvents btnOrthophotosPreviewNewReduced As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
End Class
