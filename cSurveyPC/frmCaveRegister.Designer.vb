<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveRegister
    Inherits cForm

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveRegister))
        Me.tbRegister = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnAddSingle = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddMulti = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDownload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnSaveAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUpload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDatabindShowHide = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSettings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.lvDatas = New System.Windows.Forms.ListView()
        Me.mnuDatas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDatasAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDatasDownload = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDatasDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlPopup = New System.Windows.Forms.Panel()
        Me.btnPopupClose = New System.Windows.Forms.Button()
        Me.lblPopupWarning = New System.Windows.Forms.Label()
        Me.picPopupWarning = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lvData = New System.Windows.Forms.ListView()
        Me.colDataName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDataValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imlData = New System.Windows.Forms.ImageList(Me.components)
        Me.bwLoaddata = New System.ComponentModel.BackgroundWorker()
        Me.tbRegister.SuspendLayout()
        Me.mnuDatas.SuspendLayout()
        Me.pnlPopup.SuspendLayout()
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbRegister
        '
        Me.tbRegister.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRegister.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbRegister.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator4, Me.btnDownload, Me.ToolStripSeparator1, Me.btnSave, Me.btnSaveAll, Me.ToolStripSeparator3, Me.btnUpload, Me.ToolStripSeparator2, Me.btnDelete, Me.ToolStripSeparator5, Me.btnDatabindShowHide, Me.ToolStripSeparator6, Me.btnSettings, Me.ToolStripSeparator7, Me.btnClose})
        Me.tbRegister.Location = New System.Drawing.Point(0, 0)
        Me.tbRegister.Name = "tbRegister"
        Me.tbRegister.Size = New System.Drawing.Size(670, 25)
        Me.tbRegister.TabIndex = 1
        Me.tbRegister.Text = "ToolStrip1"
        '
        'btnAdd
        '
        Me.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAdd.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddSingle, Me.btnAddMulti})
        Me.btnAdd.Enabled = False
        Me.btnAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(32, 22)
        Me.btnAdd.Text = "Aggiungi"
        '
        'btnAddSingle
        '
        Me.btnAddSingle.Name = "btnAddSingle"
        Me.btnAddSingle.Size = New System.Drawing.Size(203, 22)
        Me.btnAddSingle.Text = "Aggiungi scheda singola..."
        '
        'btnAddMulti
        '
        Me.btnAddMulti.Name = "btnAddMulti"
        Me.btnAddMulti.Size = New System.Drawing.Size(203, 22)
        Me.btnAddMulti.Text = "Aggiungi schede multiple..."
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnDownload
        '
        Me.btnDownload.Enabled = False
        Me.btnDownload.Image = Global.cSurveyPC.My.Resources.Resources.inbox_download
        Me.btnDownload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(74, 22)
        Me.btnDownload.Text = "Download"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnSave
        '
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Enabled = False
        Me.btnSave.Image = Global.cSurveyPC.My.Resources.Resources.disk
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(23, 22)
        Me.btnSave.Text = "Salva"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSaveAll.Enabled = False
        Me.btnSaveAll.Image = Global.cSurveyPC.My.Resources.Resources.disk_multiple
        Me.btnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(23, 22)
        Me.btnSaveAll.Text = "Salva tutti"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnUpload
        '
        Me.btnUpload.Enabled = False
        Me.btnUpload.Image = Global.cSurveyPC.My.Resources.Resources.inbox_upload
        Me.btnUpload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(126, 22)
        Me.btnUpload.Text = "Aggiorna dati on-line"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDelete.Enabled = False
        Me.btnDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(23, 22)
        Me.btnDelete.Text = "Elimina"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'btnDatabindShowHide
        '
        Me.btnDatabindShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDatabindShowHide.Enabled = False
        Me.btnDatabindShowHide.Image = Global.cSurveyPC.My.Resources.Resources.database
        Me.btnDatabindShowHide.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDatabindShowHide.Name = "btnDatabindShowHide"
        Me.btnDatabindShowHide.Size = New System.Drawing.Size(23, 22)
        Me.btnDatabindShowHide.Text = "Mostra/nascondi dati del rilievo corrente"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'btnSettings
        '
        Me.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSettings.Image = Global.cSurveyPC.My.Resources.Resources.network_clouds
        Me.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(23, 22)
        Me.btnSettings.Text = "Servizi"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'btnClose
        '
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnClose.Image = Global.cSurveyPC.My.Resources.Resources.folder_explorer
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 22)
        Me.btnClose.Text = "Chiudi"
        '
        'lvDatas
        '
        Me.lvDatas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvDatas.ContextMenuStrip = Me.mnuDatas
        Me.lvDatas.Dock = System.Windows.Forms.DockStyle.Top
        Me.lvDatas.HideSelection = False
        Me.lvDatas.LabelEdit = True
        Me.lvDatas.LargeImageList = Me.iml
        Me.lvDatas.Location = New System.Drawing.Point(0, 49)
        Me.lvDatas.MultiSelect = False
        Me.lvDatas.Name = "lvDatas"
        Me.lvDatas.ShowGroups = False
        Me.lvDatas.Size = New System.Drawing.Size(670, 75)
        Me.lvDatas.TabIndex = 18
        Me.lvDatas.TileSize = New System.Drawing.Size(64, 64)
        Me.lvDatas.UseCompatibleStateImageBehavior = False
        '
        'mnuDatas
        '
        Me.mnuDatas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuDatas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDatasAdd, Me.ToolStripMenuItem2, Me.mnuDatasDownload, Me.ToolStripMenuItem1, Me.mnuDatasDelete})
        Me.mnuDatas.Name = "mnuDatas"
        Me.mnuDatas.Size = New System.Drawing.Size(122, 82)
        '
        'mnuDatasAdd
        '
        Me.mnuDatasAdd.Image = Global.cSurveyPC.My.Resources.Resources.add
        Me.mnuDatasAdd.Name = "mnuDatasAdd"
        Me.mnuDatasAdd.Size = New System.Drawing.Size(121, 22)
        Me.mnuDatasAdd.Text = "Aggiungi"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(118, 6)
        '
        'mnuDatasDownload
        '
        Me.mnuDatasDownload.Image = Global.cSurveyPC.My.Resources.Resources.inbox_download
        Me.mnuDatasDownload.Name = "mnuDatasDownload"
        Me.mnuDatasDownload.Size = New System.Drawing.Size(121, 22)
        Me.mnuDatasDownload.Text = "Download"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(118, 6)
        '
        'mnuDatasDelete
        '
        Me.mnuDatasDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuDatasDelete.Name = "mnuDatasDelete"
        Me.mnuDatasDelete.Size = New System.Drawing.Size(121, 22)
        Me.mnuDatasDelete.Text = "Elimina"
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "form")
        '
        'pnlPopup
        '
        Me.pnlPopup.Controls.Add(Me.btnPopupClose)
        Me.pnlPopup.Controls.Add(Me.lblPopupWarning)
        Me.pnlPopup.Controls.Add(Me.picPopupWarning)
        Me.pnlPopup.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPopup.Location = New System.Drawing.Point(0, 25)
        Me.pnlPopup.Name = "pnlPopup"
        Me.pnlPopup.Size = New System.Drawing.Size(670, 24)
        Me.pnlPopup.TabIndex = 19
        Me.pnlPopup.Visible = False
        '
        'btnPopupClose
        '
        Me.btnPopupClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPopupClose.BackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatAppearance.BorderSize = 0
        Me.btnPopupClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPopupClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPopupClose.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.btnPopupClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPopupClose.Location = New System.Drawing.Point(646, 0)
        Me.btnPopupClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPopupClose.Name = "btnPopupClose"
        Me.btnPopupClose.Size = New System.Drawing.Size(24, 24)
        Me.btnPopupClose.TabIndex = 39
        Me.btnPopupClose.UseVisualStyleBackColor = False
        '
        'lblPopupWarning
        '
        Me.lblPopupWarning.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPopupWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPopupWarning.Location = New System.Drawing.Point(24, 4)
        Me.lblPopupWarning.Name = "lblPopupWarning"
        Me.lblPopupWarning.Size = New System.Drawing.Size(601, 16)
        Me.lblPopupWarning.TabIndex = 1
        '
        'picPopupWarning
        '
        Me.picPopupWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picPopupWarning.Location = New System.Drawing.Point(4, 4)
        Me.picPopupWarning.Name = "picPopupWarning"
        Me.picPopupWarning.Size = New System.Drawing.Size(16, 16)
        Me.picPopupWarning.TabIndex = 0
        Me.picPopupWarning.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 124)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.lvData)
        Me.SplitContainer1.Size = New System.Drawing.Size(670, 233)
        Me.SplitContainer1.SplitterDistance = 356
        Me.SplitContainer1.TabIndex = 20
        '
        'lvData
        '
        Me.lvData.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colDataName, Me.colDataValue})
        Me.lvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvData.FullRowSelect = True
        Me.lvData.Location = New System.Drawing.Point(0, 0)
        Me.lvData.Name = "lvData"
        Me.lvData.Size = New System.Drawing.Size(310, 233)
        Me.lvData.SmallImageList = Me.imlData
        Me.lvData.TabIndex = 0
        Me.lvData.UseCompatibleStateImageBehavior = False
        Me.lvData.View = System.Windows.Forms.View.Details
        '
        'colDataName
        '
        Me.colDataName.Text = "Dato"
        Me.colDataName.Width = 140
        '
        'colDataValue
        '
        Me.colDataValue.Text = "Valore"
        Me.colDataValue.Width = 140
        '
        'imlData
        '
        Me.imlData.ImageStream = CType(resources.GetObject("imlData.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlData.TransparentColor = System.Drawing.Color.Transparent
        Me.imlData.Images.SetKeyName(0, "database")
        Me.imlData.Images.SetKeyName(1, "bullet_database")
        Me.imlData.Images.SetKeyName(2, "folder")
        Me.imlData.Images.SetKeyName(3, "add")
        Me.imlData.Images.SetKeyName(4, "delete")
        '
        'bwLoaddata
        '
        Me.bwLoaddata.WorkerReportsProgress = True
        Me.bwLoaddata.WorkerSupportsCancellation = True
        '
        'frmCaveRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(670, 357)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lvDatas)
        Me.Controls.Add(Me.pnlPopup)
        Me.Controls.Add(Me.tbRegister)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCaveRegister"
        Me.Text = "Schede catastali"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tbRegister.ResumeLayout(False)
        Me.tbRegister.PerformLayout()
        Me.mnuDatas.ResumeLayout(False)
        Me.pnlPopup.ResumeLayout(False)
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbRegister As System.Windows.Forms.ToolStrip
    Friend WithEvents btnDownload As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUpload As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDatabindShowHide As System.Windows.Forms.ToolStripButton
    Friend WithEvents lvDatas As System.Windows.Forms.ListView
    Friend WithEvents pnlPopup As System.Windows.Forms.Panel
    Friend WithEvents btnPopupClose As System.Windows.Forms.Button
    Friend WithEvents lblPopupWarning As System.Windows.Forms.Label
    Friend WithEvents picPopupWarning As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lvData As System.Windows.Forms.ListView
    Friend WithEvents colDataName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDataValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents imlData As System.Windows.Forms.ImageList
    Friend WithEvents btnSaveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSettings As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDatas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDatasAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDatasDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDatasDownload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnAddSingle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddMulti As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bwLoaddata As System.ComponentModel.BackgroundWorker
End Class
