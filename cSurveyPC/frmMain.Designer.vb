<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits cForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing Then
                If components IsNot Nothing Then components.Dispose()

                If oMultiSelBrush1 IsNot Nothing Then oMultiSelBrush1.Dispose()
                If oMultiSelBrush2 IsNot Nothing Then oMultiSelBrush2.Dispose()
                If oMultiSelBrush3 IsNot Nothing Then oMultiSelBrush3.Dispose()
                If oMultiSelPen1 IsNot Nothing Then oMultiSelPen1.Dispose()
                If oMultiSelPen2 IsNot Nothing Then oMultiSelPen2.Dispose()
                If oMultiSelPen3 IsNot Nothing Then oMultiSelPen3.Dispose()
                If oOpenHandCursor IsNot Nothing Then oOpenHandCursor.Dispose()
                If oClosedHandCursor IsNot Nothing Then oClosedHandCursor.Dispose()
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
    '<System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tsMain = New System.Windows.Forms.ToolStripContainer()
        Me.pnlConsole = New System.Windows.Forms.Panel()
        Me.rtfConsole = New System.Windows.Forms.RichTextBox()
        Me.pnlDesigner = New System.Windows.Forms.Panel()
        Me.pnl3D = New System.Windows.Forms.Panel()
        Me.h3D = New System.Windows.Forms.Integration.ElementHost()
        Me.pnlPopup = New System.Windows.Forms.Panel()
        Me.btnPopupClose = New System.Windows.Forms.Button()
        Me.lblPopupWarning = New System.Windows.Forms.Label()
        Me.picPopupWarning = New System.Windows.Forms.PictureBox()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.tbViews = New System.Windows.Forms.ToolStrip()
        Me.btnView_Plan = New System.Windows.Forms.ToolStripButton()
        Me.btnView_Profile = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnView_3D = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCursorMode = New System.Windows.Forms.ToolStripButton()
        Me.btnScrollMode = New System.Windows.Forms.ToolStripButton()
        Me.btnAltMode = New System.Windows.Forms.ToolStripButton()
        Me.btnMultiSelMode1 = New System.Windows.Forms.ToolStripButton()
        Me.btnMultiSelMode2 = New System.Windows.Forms.ToolStripButton()
        Me.btnSepSnapToPoint = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSnapToPointNone = New System.Windows.Forms.ToolStripButton()
        Me.btnSnapToPoint0 = New System.Windows.Forms.ToolStripButton()
        Me.btnSnapToPoint1 = New System.Windows.Forms.ToolStripButton()
        Me.btnSnapToPoint2 = New System.Windows.Forms.ToolStripButton()
        Me.btnSepMode = New System.Windows.Forms.ToolStripSeparator()
        Me.btnViewRulers = New System.Windows.Forms.ToolStripButton()
        Me.btnViewMetricGrid = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnViewMetricGrid0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewMetricGrid1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewMetricGrid2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewMetricGridSep = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEditDrawing = New System.Windows.Forms.ToolStripButton()
        Me.btnEditPointToPoint = New System.Windows.Forms.ToolStripButton()
        Me.btnEditSep = New System.Windows.Forms.ToolStripSeparator()
        Me.btnEndEdit = New System.Windows.Forms.ToolStripButton()
        Me.btn3DSep = New System.Windows.Forms.ToolStripSeparator()
        Me.btn3dViewTop = New System.Windows.Forms.ToolStripButton()
        Me.btn3dViewBottom = New System.Windows.Forms.ToolStripButton()
        Me.btn3dViewSN = New System.Windows.Forms.ToolStripButton()
        Me.btn3dViewNS = New System.Windows.Forms.ToolStripButton()
        Me.btn3dViewEO = New System.Windows.Forms.ToolStripButton()
        Me.btn3dViewOE = New System.Windows.Forms.ToolStripButton()
        Me.btn3DCameraSep = New System.Windows.Forms.ToolStripSeparator()
        Me.btn3DCameraType = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn3DCameraType1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn3DCameraType0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn3DCameraMode = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn3DCameraMode1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn3DCameraMode0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFilterSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnFilterEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnFilterFiltered = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnlData = New System.Windows.Forms.Panel()
        Me.spSegmentsAndTrigpoints = New System.Windows.Forms.SplitContainer()
        Me.spSegments = New System.Windows.Forms.SplitContainer()
        Me.grdSegments = New cSurveyPC.cGrid()
        Me.colSegmentSession = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCaveBranchColor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDirezione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInclinazione = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSinistra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDestra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBasso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInverted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSegmentNote = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colSegmentImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.mnuSegments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSegmentsAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsInsert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem76 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsReverse = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem47 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsMoveUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsMoveDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem22 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem23 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsPrefixTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsRenameTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsReplicateData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsManageLRUD = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem60 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsTrigPoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsTrigPointsFrom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentsTrigPointsTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem65 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem90 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem73 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlSegment = New System.Windows.Forms.Panel()
        Me.tabSegmentProperty = New System.Windows.Forms.TabControl()
        Me.tabSegmentPropertyMain = New System.Windows.Forms.TabPage()
        Me.chkSegmentCalibration = New System.Windows.Forms.CheckBox()
        Me.chkSegmentCutSplay = New System.Windows.Forms.CheckBox()
        Me.chkSegmentZSurvey = New System.Windows.Forms.CheckBox()
        Me.pnlSegmentSurfaceProfile = New System.Windows.Forms.Panel()
        Me.lblSegmentSurfaceProfile = New System.Windows.Forms.Label()
        Me.cboSegmentSurfaceProfileShow = New System.Windows.Forms.ComboBox()
        Me.lblSegmentSurfaceProfileShow = New System.Windows.Forms.Label()
        Me.chkSegmentVirtual = New System.Windows.Forms.CheckBox()
        Me.chkSegmentUnbindable = New System.Windows.Forms.CheckBox()
        Me.chkSegmentSurface = New System.Windows.Forms.CheckBox()
        Me.chkSegmentDuplicate = New System.Windows.Forms.CheckBox()
        Me.chkSegmentSplay = New System.Windows.Forms.CheckBox()
        Me.cboSegmentDirection = New System.Windows.Forms.ComboBox()
        Me.txtSegmentRight = New System.Windows.Forms.TextBox()
        Me.txtSegmentUp = New System.Windows.Forms.TextBox()
        Me.txtSegmentLeft = New System.Windows.Forms.TextBox()
        Me.chkSegmentExclude = New System.Windows.Forms.CheckBox()
        Me.txtSegmentBearing = New System.Windows.Forms.TextBox()
        Me.txtSegmentDown = New System.Windows.Forms.TextBox()
        Me.lblSegmentDx = New System.Windows.Forms.Label()
        Me.txtSegmentDistance = New System.Windows.Forms.TextBox()
        Me.lblSegmentTop = New System.Windows.Forms.Label()
        Me.lblSegmentDistance = New System.Windows.Forms.Label()
        Me.lblSegmentSx = New System.Windows.Forms.Label()
        Me.lblSegmentBearing = New System.Windows.Forms.Label()
        Me.lblSegmentBottom = New System.Windows.Forms.Label()
        Me.txtSegmentInclination = New System.Windows.Forms.TextBox()
        Me.lblSegmentInclination = New System.Windows.Forms.Label()
        Me.lblSegmentDirection = New System.Windows.Forms.Label()
        Me.chkSegmentInverted = New System.Windows.Forms.CheckBox()
        Me.tabSegmentPropertyData = New System.Windows.Forms.TabPage()
        Me.prpSegmentDataProperties = New System.Windows.Forms.PropertyGrid()
        Me.mnuSegmentsDataProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSegmentsDataPropertiesEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem91 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentsDataPropertiesDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabSegmentPropertyLayout = New System.Windows.Forms.TabPage()
        Me.cmdSegmentColorChange = New System.Windows.Forms.Button()
        Me.cmdSegmentColorReset = New System.Windows.Forms.Button()
        Me.picSegmentColor = New System.Windows.Forms.PictureBox()
        Me.lblSegmentColor = New System.Windows.Forms.Label()
        Me.tabSegmentPropertyNote = New System.Windows.Forms.TabPage()
        Me.txtSegmentNote = New System.Windows.Forms.TextBox()
        Me.tabSegmentPropertyImage = New System.Windows.Forms.TabPage()
        Me.tvSegmentAttachments = New BrightIdeasSoftware.ObjectListView()
        Me.colAttachmentIcon = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colAttachmentType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colAttachmentName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colAttachmentNote = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuAttachments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAttachmentsOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem84 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAttachmentsAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem66 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuAttachmentsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAttachmentsDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlSegmentFromAndTo = New System.Windows.Forms.Panel()
        Me.cboSegmentFrom = New System.Windows.Forms.ComboBox()
        Me.lblSegmentFrom = New System.Windows.Forms.Label()
        Me.cboSegmentTo = New System.Windows.Forms.ComboBox()
        Me.lblSegmentTo = New System.Windows.Forms.Label()
        Me.pnlSegmentCaveBranches = New System.Windows.Forms.Panel()
        Me.pnlSegmentCaveBranchesColor = New System.Windows.Forms.Panel()
        Me.cboSegmentCaveBranchList = New cSurveyPC.cCaveInfoBranchesCombobox()
        Me.lblSegmentCave = New System.Windows.Forms.Label()
        Me.lblSegmentBranch = New System.Windows.Forms.Label()
        Me.cboSegmentCaveList = New cSurveyPC.cCaveInfoCombobox()
        Me.pnlSegmentSession = New System.Windows.Forms.Panel()
        Me.pnlSegmentSessionColor = New System.Windows.Forms.Panel()
        Me.cboSessionList = New System.Windows.Forms.ComboBox()
        Me.lblSession = New System.Windows.Forms.Label()
        Me.spTrigPoints = New System.Windows.Forms.SplitContainer()
        Me.grdTrigPoints = New cSurveyPC.cGrid()
        Me.colTrigPoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colZ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGPS = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colNote = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colGeoLat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGeoLon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGeoAlt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuTrigPoints = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTrigPointsRebind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsRemoveOrphans = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem42 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrigPointsEntrance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsEntrance0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsEntrance1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsEntrance2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsEntrance3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsEntrance4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem43 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrigPointsPrefixTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigPointsRenameTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem52 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrigPointsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem102 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrigPointsExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlTrigPoint = New System.Windows.Forms.Panel()
        Me.tabTrigpointProperty = New System.Windows.Forms.TabControl()
        Me.tabTrigpointMain = New System.Windows.Forms.TabPage()
        Me.chkTrigpointZTurn = New System.Windows.Forms.CheckBox()
        Me.chkTrigpointIsInExploration = New System.Windows.Forms.CheckBox()
        Me.chkTrigpointShowEntrance = New System.Windows.Forms.CheckBox()
        Me.grdTrigPointAliases = New cSurveyPC.cGrid()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuAliases = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAliasesRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAliasesRemoveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboTrigPointType = New System.Windows.Forms.ComboBox()
        Me.chkTrigpointIsSpecial = New System.Windows.Forms.CheckBox()
        Me.lblTrigpointType = New System.Windows.Forms.Label()
        Me.cboTrigpointEntrance = New System.Windows.Forms.ComboBox()
        Me.lblTrigpointEntrance = New System.Windows.Forms.Label()
        Me.tabTrigpointPropertyData = New System.Windows.Forms.TabPage()
        Me.prpTrigpointDataProperties = New System.Windows.Forms.PropertyGrid()
        Me.mnuTrigpointDataProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTrigpointDataPropertiesEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrigpointDataPropertiesDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabTrigpointLayout = New System.Windows.Forms.TabPage()
        Me.chkTrigpointDrawTranslationsLine = New System.Windows.Forms.CheckBox()
        Me.lblTrigpointFontchar = New System.Windows.Forms.Label()
        Me.cmdTrigpointColorReset = New System.Windows.Forms.Button()
        Me.txtTrigPointLabelDistance = New System.Windows.Forms.NumericUpDown()
        Me.cboTrigPointLabelSymbol = New System.Windows.Forms.ComboBox()
        Me.picTrigpointFontColor = New System.Windows.Forms.PictureBox()
        Me.lblTrigPointSymbol = New System.Windows.Forms.Label()
        Me.lblTrigpointLabelDistance = New System.Windows.Forms.Label()
        Me.lblFontColor = New System.Windows.Forms.Label()
        Me.cboTrigPointLabelPosition = New System.Windows.Forms.ComboBox()
        Me.lblTrigpointLabelPosition = New System.Windows.Forms.Label()
        Me.chkTrigpointFontUnderline = New System.Windows.Forms.CheckBox()
        Me.cboTrigpointFontChar = New System.Windows.Forms.ComboBox()
        Me.chkTrigpointFontItalic = New System.Windows.Forms.CheckBox()
        Me.cboTrigpointFontSize = New System.Windows.Forms.ComboBox()
        Me.chkTrigpointFontBold = New System.Windows.Forms.CheckBox()
        Me.cmdTrigpointFontColor = New System.Windows.Forms.Button()
        Me.lblTextFontSize = New System.Windows.Forms.Label()
        Me.tabTrigpointConnections = New System.Windows.Forms.TabPage()
        Me.grdTrigpointConnections = New cSurveyPC.cGrid()
        Me.colConnectionsTrigPoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConnectionsIgnore = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tabTrigpointCoordinate = New System.Windows.Forms.TabPage()
        Me.btnTrigpointCoordinateClear = New System.Windows.Forms.Button()
        Me.lblTrigpointCoordinateFix = New System.Windows.Forms.Label()
        Me.cboTrigpointCoordinateFix = New System.Windows.Forms.ComboBox()
        Me.pnlTrigpointCoordinateWGS84 = New System.Windows.Forms.Panel()
        Me.txtTrigpointCoordinateLong = New System.Windows.Forms.TextBox()
        Me.txtTrigpointCoordinateLat = New System.Windows.Forms.TextBox()
        Me.lblTrigpointCoordinateLat = New System.Windows.Forms.Label()
        Me.lblTrigpointCoordinateLong = New System.Windows.Forms.Label()
        Me.lblTrigpointCoordinateFormat = New System.Windows.Forms.Label()
        Me.cboTrigpointCoordinateFormat = New System.Windows.Forms.ComboBox()
        Me.txtTrigpointCoordinateAlt = New System.Windows.Forms.TextBox()
        Me.lblTrigpointCoordinateAlt = New System.Windows.Forms.Label()
        Me.lblTrigpointCoordinateGeo = New System.Windows.Forms.Label()
        Me.cboTrigpointCoordinateGeo = New System.Windows.Forms.ComboBox()
        Me.pnlTrigpointCoordinateUTM = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTrigpointCoordinateBand = New System.Windows.Forms.ComboBox()
        Me.lblTrigpointCoordinateZone = New System.Windows.Forms.Label()
        Me.txtTrigpointCoordinateY = New System.Windows.Forms.TextBox()
        Me.cboTrigpointCoordinateZone = New System.Windows.Forms.ComboBox()
        Me.txtTrigpointCoordinateX = New System.Windows.Forms.TextBox()
        Me.lblTrigpointCoordinateY = New System.Windows.Forms.Label()
        Me.lblTrigpointCoordinateX = New System.Windows.Forms.Label()
        Me.tabTrigpointNote = New System.Windows.Forms.TabPage()
        Me.txtTrigpointNote = New System.Windows.Forms.TextBox()
        Me.pnlTrigpointName = New System.Windows.Forms.Panel()
        Me.lblTrigPointName = New System.Windows.Forms.Label()
        Me.txtTrigPointName = New System.Windows.Forms.TextBox()
        Me.tbSegmentsAndTrigpoints = New System.Windows.Forms.ToolStrip()
        Me.btnSegments = New System.Windows.Forms.ToolStripButton()
        Me.btnTrigPoints = New System.Windows.Forms.ToolStripButton()
        Me.btnSegmentsAndTrigPoints = New System.Windows.Forms.ToolStripButton()
        Me.btnSegmentAndTrigpointGridColorSep = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSegmentAndTrigpointGridColor = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnSegmentAndTrigpointGridColor3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSegmentAndTrigpointGridColor2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSegmentAndTrigpointGridColor1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem104 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSegmentAndTrigpointGridColor0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSegnentAndTrigpointSepFilter = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSegmentAndTrigpointFilterEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnSegmentAndTrigpointFiltered = New System.Windows.Forms.ToolStripButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.trkZoom = New System.Windows.Forms.TrackBar()
        Me.pnlObjectLayers = New System.Windows.Forms.Panel()
        Me.cmdLayerSync = New System.Windows.Forms.Button()
        Me.tvLayers2 = New BrightIdeasSoftware.TreeListView()
        Me.colLayersCaveBranchColor = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersType = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersHiddenInDesign = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersHiddenInPreview = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersPreview = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersCave = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLayersBranch = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuLayersAndItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLayersAndItemsExpand = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsExpandAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsCollapse = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsCollapseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem51 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsCurrentLevelShowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsCurrentLevelHideAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsShowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsHideAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem45 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsCurrentLevelDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem93 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsFilterEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsFiltered = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem62 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem38 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsSelectAllInCurrentLevel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayersAndItemsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem88 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem41 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersAndItemsRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.imlLayers = New System.Windows.Forms.ImageList(Me.components)
        Me.chkLayerFiltered = New System.Windows.Forms.CheckBox()
        Me.cmdLayerFilterEdit = New System.Windows.Forms.Button()
        Me.lbLayerItemTitle = New System.Windows.Forms.Label()
        Me.lbLayerItemCaption = New System.Windows.Forms.Label()
        Me.piclayerItemPreview = New System.Windows.Forms.PictureBox()
        Me.cmdLayerObjectSelect = New System.Windows.Forms.Button()
        Me.cmdLayerObjectProperty = New System.Windows.Forms.Button()
        Me.cmdLayerRefresh = New System.Windows.Forms.Button()
        Me.pnlProperties = New System.Windows.Forms.Panel()
        Me.tabObjectProp = New System.Windows.Forms.TabControl()
        Me.tabObjectPropDesign = New System.Windows.Forms.TabPage()
        Me.tblDesignProp = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlDesignSize = New System.Windows.Forms.Panel()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.txtDesignScaleHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.lblDesignScale = New System.Windows.Forms.Label()
        Me.txtDesignScaleWidth = New System.Windows.Forms.NumericUpDown()
        Me.cmdDesignFlipV = New System.Windows.Forms.Button()
        Me.cmdDesignFlipH = New System.Windows.Forms.Button()
        Me.txtDesignWidth = New System.Windows.Forms.TextBox()
        Me.txtDesignHeight = New System.Windows.Forms.TextBox()
        Me.lblDesignWidthUM = New System.Windows.Forms.Label()
        Me.lblDesignHeightUM = New System.Windows.Forms.Label()
        Me.lblDesignSize = New System.Windows.Forms.Label()
        Me.pnlDesignPosition = New System.Windows.Forms.Panel()
        Me.txtDesignLeft = New System.Windows.Forms.TextBox()
        Me.cmdDesignMoveRight = New System.Windows.Forms.Button()
        Me.cmdDesignMoveDown = New System.Windows.Forms.Button()
        Me.cmdDesignMoveLeft = New System.Windows.Forms.Button()
        Me.cmdDesignMoveTop = New System.Windows.Forms.Button()
        Me.txtDesignTop = New System.Windows.Forms.TextBox()
        Me.lblDesignLeftUM = New System.Windows.Forms.Label()
        Me.lblDesignTopUM = New System.Windows.Forms.Label()
        Me.lblDesignPosition = New System.Windows.Forms.Label()
        Me.pnlDesignRotation = New System.Windows.Forms.Panel()
        Me.chkDesignRotateCenterOnOrigin = New System.Windows.Forms.CheckBox()
        Me.cmdDesignRotateLeftByDegree = New System.Windows.Forms.Button()
        Me.cmdDesignRotateRightByDegree = New System.Windows.Forms.Button()
        Me.cmdDesignRotateRight = New System.Windows.Forms.Button()
        Me.cmdDesignRotateLeft = New System.Windows.Forms.Button()
        Me.txtDesignRotate = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.lblDesignRotation = New System.Windows.Forms.Label()
        Me.pnlDesignStyle = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkDesignUnselectedLevelDrawingMode2 = New System.Windows.Forms.CheckBox()
        Me.chkDesignUnselectedLevelDrawingMode1 = New System.Windows.Forms.CheckBox()
        Me.chkDesignUnselectedLevelDrawingMode0 = New System.Windows.Forms.CheckBox()
        Me.lblDesignUnselectedLevelDrawingMode = New System.Windows.Forms.Label()
        Me.chkDesignStyle2 = New System.Windows.Forms.CheckBox()
        Me.chkDesignStyle1 = New System.Windows.Forms.CheckBox()
        Me.chkDesignStyle0 = New System.Windows.Forms.CheckBox()
        Me.lblDesignStyle = New System.Windows.Forms.Label()
        Me.pnlDesignCombineColorMode = New System.Windows.Forms.Panel()
        Me.chkDesignCombineColorGray = New System.Windows.Forms.CheckBox()
        Me.cboDesignCombineColorMode = New System.Windows.Forms.ComboBox()
        Me.lblDesignCombineColorMode = New System.Windows.Forms.Label()
        Me.pnlDesignSnapToGrid = New System.Windows.Forms.Panel()
        Me.txtDesignSnapToGrid = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignSnapToGridUM = New System.Windows.Forms.Label()
        Me.lblDesignSnapToGrid0 = New System.Windows.Forms.Label()
        Me.chkDesignSnapToGrid = New System.Windows.Forms.CheckBox()
        Me.pnlDesignPlotContainer = New System.Windows.Forms.Panel()
        Me.chkDesignPlot = New System.Windows.Forms.CheckBox()
        Me.pnlDesignPlot = New System.Windows.Forms.Panel()
        Me.chkDesignPlotShowSplayMode = New System.Windows.Forms.CheckBox()
        Me.lvDesignPlotShowHLsDett = New System.Windows.Forms.ListView()
        Me.colNome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkDesignPlotColorGray = New System.Windows.Forms.CheckBox()
        Me.btnDesignRings = New System.Windows.Forms.Button()
        Me.cboDesignPlotSegmentsPaintStyle = New System.Windows.Forms.ComboBox()
        Me.chkDesignPlotShowHLs = New System.Windows.Forms.CheckBox()
        Me.cboDesignPlotColorMode = New System.Windows.Forms.ComboBox()
        Me.lblDesignPlotColorMode = New System.Windows.Forms.Label()
        Me.chkDesignPlotShowTrigpointText = New System.Windows.Forms.CheckBox()
        Me.btnDesignPlotSplay = New System.Windows.Forms.Button()
        Me.chkDesignPlotShowTrigpoint = New System.Windows.Forms.CheckBox()
        Me.btnDesignHighlights = New System.Windows.Forms.Button()
        Me.chkDesignPlotShowLRUD = New System.Windows.Forms.CheckBox()
        Me.chkDesignPlotShowSplayLabel = New System.Windows.Forms.CheckBox()
        Me.chkDesignPlotShowSegment = New System.Windows.Forms.CheckBox()
        Me.chkDesignPlotShowSplay = New System.Windows.Forms.CheckBox()
        Me.cboDesignPlotSplayStyle = New System.Windows.Forms.ComboBox()
        Me.pnlDesignSurfaceContainer = New System.Windows.Forms.Panel()
        Me.chkDesignSurface = New System.Windows.Forms.CheckBox()
        Me.cmdDesignSurfaceEdit = New System.Windows.Forms.Button()
        Me.pnlDesignSurface = New System.Windows.Forms.Panel()
        Me.cmdDesignSurfaceLayersEdit = New System.Windows.Forms.Button()
        Me.tvDesignSurfaceLayers = New System.Windows.Forms.TreeView()
        Me.mnuDesignSurfaceLayers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesignSurfaceEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem71 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignSurfaceLayersEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem99 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignSurfaceLayersShowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignSurfaceLayersHideAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdDesignSurfaceLayersDown = New System.Windows.Forms.Button()
        Me.cmdDesignSurfaceLayersUp = New System.Windows.Forms.Button()
        Me.pnlDesignSurfaceProfile = New System.Windows.Forms.Panel()
        Me.chkDesignSurfaceProfile = New System.Windows.Forms.CheckBox()
        Me.pnlDesignPrintOrExportAreaContainer = New System.Windows.Forms.Panel()
        Me.cDesignPrintOrExportArea = New cSurveyPC.cDesignPrintOrExportAreaControl()
        Me.cDesignLinkedSurveys = New cSurveyPC.cDesignLinkedSurveySelectorPropertyControl()
        Me.tabObjectPropMain = New System.Windows.Forms.TabPage()
        Me.tblObjectProp = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPropConvertTo = New System.Windows.Forms.Panel()
        Me.cmdPropConvertTo = New System.Windows.Forms.Button()
        Me.lvPropConvertTo = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imlGeneric = New System.Windows.Forms.ImageList(Me.components)
        Me.lblPropConvertTo = New System.Windows.Forms.Label()
        Me.pnlPropClipping = New System.Windows.Forms.Panel()
        Me.cboPropClipping = New System.Windows.Forms.ComboBox()
        Me.lblPropClipping = New System.Windows.Forms.Label()
        Me.pnlPropShape = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdPropShapeDivide = New System.Windows.Forms.Button()
        Me.cmdPropShapeCombine = New System.Windows.Forms.Button()
        Me.pnlPropShapeSequences = New System.Windows.Forms.Panel()
        Me.cmdPropShapeRevertAllSequences = New System.Windows.Forms.Button()
        Me.lblPropLinePointReductionUM = New System.Windows.Forms.Label()
        Me.lblPropLinePointReduction = New System.Windows.Forms.Label()
        Me.txtPropLinePointReductionFactor = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropLinePointReduction = New System.Windows.Forms.Button()
        Me.lblPropSequence = New System.Windows.Forms.Label()
        Me.cmdPropShapeReorderSequence = New System.Windows.Forms.Button()
        Me.cmdPropShapeCloseAllSequences = New System.Windows.Forms.Button()
        Me.cmdPropShapeCombineAllSequences = New System.Windows.Forms.Button()
        Me.pnlPropSign = New System.Windows.Forms.Panel()
        Me.cmdPropSignOtherOptions = New System.Windows.Forms.Button()
        Me.cboPropSign = New System.Windows.Forms.ComboBox()
        Me.lblPropSign = New System.Windows.Forms.Label()
        Me.cboPropSignSize = New System.Windows.Forms.ComboBox()
        Me.lblPropSignSize = New System.Windows.Forms.Label()
        Me.cboPropSignRotateMode = New System.Windows.Forms.ComboBox()
        Me.lblPropSignRotateMode = New System.Windows.Forms.Label()
        Me.pnlPropImage = New System.Windows.Forms.Panel()
        Me.cmdPropImageView = New System.Windows.Forms.Button()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtPropImageScaleFree = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropImageScale500 = New System.Windows.Forms.Button()
        Me.cmdPropImageScale250 = New System.Windows.Forms.Button()
        Me.cmdPropImageScale100 = New System.Windows.Forms.Button()
        Me.txtPropImageResolution = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cboPropImageResizeMode = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.picPropImage = New System.Windows.Forms.PictureBox()
        Me.cmdPropImageBrowse = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.pnlPropInfo = New System.Windows.Forms.Panel()
        Me.cboPropBindCrossSections = New System.Windows.Forms.ComboBox()
        Me.lblPropBindCrossSections = New System.Windows.Forms.Label()
        Me.pnlPropCaveBranches = New System.Windows.Forms.Panel()
        Me.pnlPropCaveBranchesColor = New System.Windows.Forms.Panel()
        Me.cmdPropSetCurrentCaveBranch = New System.Windows.Forms.Button()
        Me.cmdPropSetCaveBranch = New System.Windows.Forms.Button()
        Me.cboPropCaveBranchList = New cSurveyPC.cCaveInfoBranchesCombobox()
        Me.lblPropBranchList = New System.Windows.Forms.Label()
        Me.cboPropCaveList = New cSurveyPC.cCaveInfoCombobox()
        Me.lblPropCaveList = New System.Windows.Forms.Label()
        Me.txtPropPointType = New System.Windows.Forms.TextBox()
        Me.lblPropPointType = New System.Windows.Forms.Label()
        Me.cboPropBindDesignType = New System.Windows.Forms.ComboBox()
        Me.lblPropBindDesignType = New System.Windows.Forms.Label()
        Me.cmdPropParent = New System.Windows.Forms.Button()
        Me.cmdPropNext = New System.Windows.Forms.Button()
        Me.cmdPropPrev = New System.Windows.Forms.Button()
        Me.optPropObjectSequence = New System.Windows.Forms.RadioButton()
        Me.optPropObject = New System.Windows.Forms.RadioButton()
        Me.pnlPropPen = New System.Windows.Forms.Panel()
        Me.tblPropPen = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPropPenGeneric = New System.Windows.Forms.Panel()
        Me.cboPropPenPattern = New System.Windows.Forms.ComboBox()
        Me.lblPropPenPattern = New System.Windows.Forms.Label()
        Me.pnlPropPenCustom = New System.Windows.Forms.Panel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtPropPenDecorationScale = New System.Windows.Forms.NumericUpDown()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.cboPropPenStyle = New System.Windows.Forms.ComboBox()
        Me.txtPropPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPenDecorationSpacePercentage = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboPropPenDecorationAlignment = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmdPropPenColorBrowse = New System.Windows.Forms.Button()
        Me.picPropPenColor = New System.Windows.Forms.PictureBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.cboPropPenDecoration = New System.Windows.Forms.ComboBox()
        Me.pnlPropSize = New System.Windows.Forms.Panel()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtPropScaleHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtPropScaleWidth = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropFlipV = New System.Windows.Forms.Button()
        Me.cmdPropFlipH = New System.Windows.Forms.Button()
        Me.txtPropWidth = New System.Windows.Forms.TextBox()
        Me.txtPropHeight = New System.Windows.Forms.TextBox()
        Me.lblPropWidthUM = New System.Windows.Forms.Label()
        Me.lblPropHeightUM = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlPropPosition = New System.Windows.Forms.Panel()
        Me.pnlPropPositionSubPanel1 = New System.Windows.Forms.Panel()
        Me.chkPropLock = New System.Windows.Forms.CheckBox()
        Me.cmdPropBringOnTop = New System.Windows.Forms.Button()
        Me.cmdPropBringAhead = New System.Windows.Forms.Button()
        Me.cmdPropSendBehind = New System.Windows.Forms.Button()
        Me.cmdPropSendToBottom = New System.Windows.Forms.Button()
        Me.cmdPropMoveRight = New System.Windows.Forms.Button()
        Me.cmdPropMoveBottom = New System.Windows.Forms.Button()
        Me.cmdPropMoveLeft = New System.Windows.Forms.Button()
        Me.cmdPropMoveTop = New System.Windows.Forms.Button()
        Me.txtPropLeft = New System.Windows.Forms.TextBox()
        Me.txtPropTop = New System.Windows.Forms.TextBox()
        Me.lblPropLeftUM = New System.Windows.Forms.Label()
        Me.lblPropTopUM = New System.Windows.Forms.Label()
        Me.lblPropPosition = New System.Windows.Forms.Label()
        Me.pnlPropRotation = New System.Windows.Forms.Panel()
        Me.cmdPropRotateLeftByDegree = New System.Windows.Forms.Button()
        Me.cmdPropRotateRightByDegree = New System.Windows.Forms.Button()
        Me.cmdPropRotateRight = New System.Windows.Forms.Button()
        Me.cmdPropRotateLeft = New System.Windows.Forms.Button()
        Me.txtPropRotate = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.pnlPropLineType = New System.Windows.Forms.Panel()
        Me.chkPropLineType2 = New System.Windows.Forms.CheckBox()
        Me.chkPropLineType1 = New System.Windows.Forms.CheckBox()
        Me.chkPropLineType0 = New System.Windows.Forms.CheckBox()
        Me.lblPropLineType = New System.Windows.Forms.Label()
        Me.pnlPropBrush = New System.Windows.Forms.Panel()
        Me.tblPropBrush = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPropBrushGeneric = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboPropBrushPattern = New System.Windows.Forms.ComboBox()
        Me.cmdPropBrushReseed = New System.Windows.Forms.Button()
        Me.pnlPropBrushCustom = New System.Windows.Forms.Panel()
        Me.lblPropBrushClipartPosition = New System.Windows.Forms.Label()
        Me.cboPropBrushClipartPosition = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartImage = New System.Windows.Forms.Label()
        Me.lblPropBrushAlternativeBrushColor = New System.Windows.Forms.Label()
        Me.cmdPropBrushAlternativeBrushColor = New System.Windows.Forms.Button()
        Me.picPropBrushAlternativeBrushColor = New System.Windows.Forms.PictureBox()
        Me.lblpropbrushcolor = New System.Windows.Forms.Label()
        Me.lblPropBrushClipartAngle = New System.Windows.Forms.Label()
        Me.txtPropBrushClipartAngle = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropBrushColor = New System.Windows.Forms.Button()
        Me.picPropBrushColor = New System.Windows.Forms.PictureBox()
        Me.lblPropBrushClipartAngleMode = New System.Windows.Forms.Label()
        Me.cboPropBrushClipartAngleMode = New System.Windows.Forms.ComboBox()
        Me.picPropBrushClipartImage = New System.Windows.Forms.PictureBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cboPropBrushHatch = New System.Windows.Forms.ComboBox()
        Me.cmdPropBrushBrowseClipart = New System.Windows.Forms.Button()
        Me.lblPropBrushClipartZoomFactor = New System.Windows.Forms.Label()
        Me.txtPropBrushClipartZoomFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtPropBrushClipartDensity = New System.Windows.Forms.NumericUpDown()
        Me.lblPropBrushClipartDensity = New System.Windows.Forms.Label()
        Me.lblPropBrushPatternType = New System.Windows.Forms.Label()
        Me.cboPropBrushPatternType = New System.Windows.Forms.ComboBox()
        Me.cboPropBrushClipartCrop = New System.Windows.Forms.ComboBox()
        Me.lblPropBrushClipartCrop = New System.Windows.Forms.Label()
        Me.lblPropBrushPatternPen = New System.Windows.Forms.Label()
        Me.cboPropBrushPatternPen = New System.Windows.Forms.ComboBox()
        Me.pnlPropSegmentBinding = New System.Windows.Forms.Panel()
        Me.txtPropSegmentBinded = New System.Windows.Forms.TextBox()
        Me.cmdPropSegmentRebind = New System.Windows.Forms.Button()
        Me.chkPropSegmentLocked = New System.Windows.Forms.CheckBox()
        Me.lblPropBinding = New System.Windows.Forms.Label()
        Me.pnlPropSegmentsBinding = New System.Windows.Forms.Panel()
        Me.cmdPropSegmentsLock = New System.Windows.Forms.Button()
        Me.cmdPropSegmentsUnlock = New System.Windows.Forms.Button()
        Me.lvPropSegmentsBinded = New System.Windows.Forms.ListView()
        Me.colPropSegmentsBindedSegment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdPropSegmentsRebind = New System.Windows.Forms.Button()
        Me.chkPropSegmentsLocked = New System.Windows.Forms.CheckBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.pnlPropText = New System.Windows.Forms.Panel()
        Me.tblPropText = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPropTextFont = New System.Windows.Forms.Panel()
        Me.lblPropFontColor = New System.Windows.Forms.Label()
        Me.cmdPropFontColor = New System.Windows.Forms.Button()
        Me.picPropFontColor = New System.Windows.Forms.PictureBox()
        Me.chkPropTextFontUnderline = New System.Windows.Forms.CheckBox()
        Me.chkPropTextFontItalic = New System.Windows.Forms.CheckBox()
        Me.chkPropTextFontBold = New System.Windows.Forms.CheckBox()
        Me.cboPropTextFontChar = New System.Windows.Forms.ComboBox()
        Me.lblPropTextFontChar = New System.Windows.Forms.Label()
        Me.cboPropTextFontSize = New System.Windows.Forms.ComboBox()
        Me.lblPropTextFontSize = New System.Windows.Forms.Label()
        Me.pnlPropTextStyle = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optPropTextVAlignBottom = New System.Windows.Forms.RadioButton()
        Me.optPropTextVAlignTop = New System.Windows.Forms.RadioButton()
        Me.optPropTextVAlignCenter = New System.Windows.Forms.RadioButton()
        Me.optPropTextAlignRight = New System.Windows.Forms.RadioButton()
        Me.optPropTextAlignCenter = New System.Windows.Forms.RadioButton()
        Me.optPropTextAlignLeft = New System.Windows.Forms.RadioButton()
        Me.cboPropTextSize = New System.Windows.Forms.ComboBox()
        Me.lblPropTextSize = New System.Windows.Forms.Label()
        Me.lblPropText = New System.Windows.Forms.Label()
        Me.txtPropText = New System.Windows.Forms.TextBox()
        Me.lblPropTextStyle = New System.Windows.Forms.Label()
        Me.cboPropTextStyle = New System.Windows.Forms.ComboBox()
        Me.cboPropTextRotateMode = New System.Windows.Forms.ComboBox()
        Me.lblPropTextRotateMode = New System.Windows.Forms.Label()
        Me.pnlPropCrossSection = New System.Windows.Forms.Panel()
        Me.lblPropCrossSectionRefStation = New System.Windows.Forms.Label()
        Me.cboPropCrossSectionRefStation = New System.Windows.Forms.ComboBox()
        Me.cmdPropCrossSectionProfileMarker = New System.Windows.Forms.Button()
        Me.cmdPropCrossSectionPlanMarker = New System.Windows.Forms.Button()
        Me.chkPropCrossSectionProfileMarker = New System.Windows.Forms.CheckBox()
        Me.chkPropCrossSectionPlanMarker = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionCrossX = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionHeight = New System.Windows.Forms.NumericUpDown()
        Me.txtPropCrossSectionWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionCross = New System.Windows.Forms.Label()
        Me.cmdPropCrossSectionSegment = New System.Windows.Forms.Button()
        Me.txtPropCrossSectionSegment = New System.Windows.Forms.TextBox()
        Me.lblPropCrossSectionSegment = New System.Windows.Forms.Label()
        Me.cboPropProfileDirection = New System.Windows.Forms.ComboBox()
        Me.lblPropProfileBearing = New System.Windows.Forms.Label()
        Me.txtPropProfileTextDistance = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileTextDistance = New System.Windows.Forms.Label()
        Me.cboPropProfileTextPosition = New System.Windows.Forms.ComboBox()
        Me.lblPropProfileTextPosition = New System.Windows.Forms.Label()
        Me.pnlPropQuota = New System.Windows.Forms.Panel()
        Me.cboPropQuotaFormat = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaFormat = New System.Windows.Forms.Label()
        Me.lblPropQuotaTextPosition = New System.Windows.Forms.Label()
        Me.cboPropQuotaTextPosition = New System.Windows.Forms.ComboBox()
        Me.cmdPropQuotaOtherOptions = New System.Windows.Forms.Button()
        Me.cmdPropQuotaTrigpoint = New System.Windows.Forms.Button()
        Me.txtPropQuotaRelativeTrigpoint = New System.Windows.Forms.TextBox()
        Me.lblPropQuotaRelativeTrigpoint = New System.Windows.Forms.Label()
        Me.cboPropQuotaType = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaType = New System.Windows.Forms.Label()
        Me.cboPropQuotaValueType = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaValueType = New System.Windows.Forms.Label()
        Me.cboPropQuotaValue = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaValue = New System.Windows.Forms.Label()
        Me.cboPropQuotaAlign = New System.Windows.Forms.ComboBox()
        Me.lblPropQuotaAlign = New System.Windows.Forms.Label()
        Me.pnlPropSketch = New System.Windows.Forms.Panel()
        Me.cmdPropSketchView = New System.Windows.Forms.Button()
        Me.txtPropSketchResolution = New System.Windows.Forms.TextBox()
        Me.lblPropSketchResolution = New System.Windows.Forms.Label()
        Me.picPropSketch = New System.Windows.Forms.PictureBox()
        Me.chkPropSketchMorphingDisabled = New System.Windows.Forms.CheckBox()
        Me.chkPropSketchManualAdjust = New System.Windows.Forms.CheckBox()
        Me.lblPropSketchEdit = New System.Windows.Forms.Label()
        Me.cmdPropSketchEdit = New System.Windows.Forms.Button()
        Me.pnlPropMergeMode = New System.Windows.Forms.Panel()
        Me.cboPropMergeMode = New System.Windows.Forms.ComboBox()
        Me.lblPropMergeMode = New System.Windows.Forms.Label()
        Me.pnlPropTransparency = New System.Windows.Forms.Panel()
        Me.txtPropTransparency = New System.Windows.Forms.NumericUpDown()
        Me.lblPropTransparency = New System.Windows.Forms.Label()
        Me.pnlPropObjectsBinding = New System.Windows.Forms.Panel()
        Me.btnPropObjectsSelect = New System.Windows.Forms.Button()
        Me.btnPropObjectsRefresh = New System.Windows.Forms.Button()
        Me.lvPropObjectsBinded = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlPropPointsSequences = New System.Windows.Forms.Panel()
        Me.cmdPropPointsSequencesDivideAndJoin = New System.Windows.Forms.Button()
        Me.cmdPropPointsJoinAndConnect = New System.Windows.Forms.Button()
        Me.cmdPropPointsUnjoinAll = New System.Windows.Forms.Button()
        Me.cmdPropPointsUnjoin = New System.Windows.Forms.Button()
        Me.cmdPropPointsJoin = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdPropPointsSequencesDelete = New System.Windows.Forms.Button()
        Me.cmdPropPointsSequencesDivide = New System.Windows.Forms.Button()
        Me.cmdPropPointsSequencesRevert = New System.Windows.Forms.Button()
        Me.cmdPropPointsSequencesClose = New System.Windows.Forms.Button()
        Me.cmdPropPointsSequencesCombine = New System.Windows.Forms.Button()
        Me.pnlPropSequenceLineType = New System.Windows.Forms.Panel()
        Me.chkPropSequenceLineTypeP = New System.Windows.Forms.CheckBox()
        Me.chkPropSequenceLineType2 = New System.Windows.Forms.CheckBox()
        Me.chkPropSequenceLineType1 = New System.Windows.Forms.CheckBox()
        Me.chkPropSequenceLineType0 = New System.Windows.Forms.CheckBox()
        Me.lblPropSequenceLineType = New System.Windows.Forms.Label()
        Me.pnlPropProp = New System.Windows.Forms.Panel()
        Me.chkPropShowDataProperties = New System.Windows.Forms.CheckBox()
        Me.cboPropCategories = New System.Windows.Forms.ComboBox()
        Me.lblPropCategory = New System.Windows.Forms.Label()
        Me.pnlPropItems = New System.Windows.Forms.Panel()
        Me.lblPropItemsSpace = New System.Windows.Forms.Label()
        Me.cmdPropItemsVSpace = New System.Windows.Forms.Button()
        Me.cmdPropItemsHSpace = New System.Windows.Forms.Button()
        Me.lblPropItemsAlign = New System.Windows.Forms.Label()
        Me.cmdPropItemsHAlignCenter = New System.Windows.Forms.Button()
        Me.cmdPropItemsHAlignLeft = New System.Windows.Forms.Button()
        Me.cmdPropItemsVAlignTop = New System.Windows.Forms.Button()
        Me.cmdPropItemsHAlignRight = New System.Windows.Forms.Button()
        Me.cmdPropItemsVAlignMiddle = New System.Windows.Forms.Button()
        Me.cmdPropItemsVAlignBottom = New System.Windows.Forms.Button()
        Me.pnlPropPopup = New System.Windows.Forms.Panel()
        Me.btnPropWarningClose = New System.Windows.Forms.Button()
        Me.lblPropPopupWarning = New System.Windows.Forms.Label()
        Me.picPropPopupWarning = New System.Windows.Forms.PictureBox()
        Me.pnlPropProfileSplayBorder = New System.Windows.Forms.Panel()
        Me.txtPropProfileSplayNegInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayNegInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayNegInclinationRange = New System.Windows.Forms.Label()
        Me.txtPropProfileSplayPosInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropProfileSplayPosInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropProfileSplay = New System.Windows.Forms.Button()
        Me.lblPropProfileSplay = New System.Windows.Forms.Label()
        Me.txtPropProfileSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileSplayMaxVariationAngle = New System.Windows.Forms.Label()
        Me.lblPropProfileSplayProjectionAngle = New System.Windows.Forms.Label()
        Me.txtPropProfileSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.picPropProfileProjectionSchema = New System.Windows.Forms.PictureBox()
        Me.lblPropProfileSplayPosInclinationRange = New System.Windows.Forms.Label()
        Me.pnlPropPlanSplayBorder = New System.Windows.Forms.Panel()
        Me.lblPropPlanSplayInclinationRange = New System.Windows.Forms.Label()
        Me.txtPropPlanSplayInclinationRangeMax = New System.Windows.Forms.NumericUpDown()
        Me.txtPropPlanSplayInclinationRangeMin = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropPlanSplay = New System.Windows.Forms.Button()
        Me.lblPropPlanSplay = New System.Windows.Forms.Label()
        Me.lblPropPlanSplayPlanProjectionPlanType = New System.Windows.Forms.Label()
        Me.cboPropPlanSplayPlanProjectionType = New System.Windows.Forms.ComboBox()
        Me.txtPropPlanSplayPlanDeltaZ = New System.Windows.Forms.NumericUpDown()
        Me.lblPropPlanSplayPlanDeltaZ = New System.Windows.Forms.Label()
        Me.txtPropPlanSplayMaxVariationDelta = New System.Windows.Forms.NumericUpDown()
        Me.lblPropPlanSplayMaxVariationDelta = New System.Windows.Forms.Label()
        Me.picPropPlanProjectionSchema = New System.Windows.Forms.PictureBox()
        Me.pnlPropDataProperties = New System.Windows.Forms.Panel()
        Me.lblPropDesignDataProperties = New System.Windows.Forms.Label()
        Me.prpPropDesignDataProperties = New System.Windows.Forms.PropertyGrid()
        Me.mnuDesignDataProperties = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesignDataPropertiesEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignDataPropertiesDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlPropCrossSectionSplayBorder = New System.Windows.Forms.Panel()
        Me.txtPropCrossSectionSplayProjectionVerticalAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkPropCrossSectionShowOnlyCutSplay = New System.Windows.Forms.CheckBox()
        Me.cmdPropCrossSectionSplay = New System.Windows.Forms.Button()
        Me.chkPropCrossSectionSplayText = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionSplayMaxVariationAngle = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionSplayProjectionAngle = New System.Windows.Forms.Label()
        Me.cboPropCrossSectionSplayLineStyle = New System.Windows.Forms.ComboBox()
        Me.txtPropCrossSectionSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionSplayLineStyle = New System.Windows.Forms.Label()
        Me.picPropCrossSectionProjectionSchema = New System.Windows.Forms.PictureBox()
        Me.chkPropCrossSectionShowSplayBorder = New System.Windows.Forms.CheckBox()
        Me.pnlPropSegmentInfo = New System.Windows.Forms.Panel()
        Me.cmdPropSegmentGoto = New System.Windows.Forms.Button()
        Me.cmdPropSegmentEndShot = New System.Windows.Forms.Button()
        Me.cmdPropSegmentBeginShot = New System.Windows.Forms.Button()
        Me.cmdPropSegmentInvert = New System.Windows.Forms.Button()
        Me.lblPropSegment = New System.Windows.Forms.Label()
        Me.lvSegmentInfo = New System.Windows.Forms.ListView()
        Me.colSegmentInfoName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSegmentInfoValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuSegmentInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSegmentInfoCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentInfoCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem109 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSegmentInfoCopyValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSegmentInfoCopyAllValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSegmentSetCaveBranch = New System.Windows.Forms.Button()
        Me.cmdSegmentSetCurrentCaveBranch = New System.Windows.Forms.Button()
        Me.pnlPropTrigpointInfo = New cSurveyPC.cPanel()
        Me.cmdPropTrigpointGoto = New System.Windows.Forms.Button()
        Me.cmdPropTrigpointFix = New System.Windows.Forms.Button()
        Me.cmdPropTrigpointFixToMarker = New System.Windows.Forms.Button()
        Me.lblpropTrigpoint = New System.Windows.Forms.Label()
        Me.lvTrigpointInfo = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuTrigpointInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTrigpointInfoCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigpointInfoCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem108 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrigpointInfoCopyValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTrigpointInfoCopyAllValue = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlPropCrossSectionMarker = New System.Windows.Forms.Panel()
        Me.chkPropCrossSectionMarkerDeltaAngleEnabled = New System.Windows.Forms.CheckBox()
        Me.chkPropCrossSectionMarkerScaleEnabled = New System.Windows.Forms.CheckBox()
        Me.chkPropCrossSectionMarkerUH = New System.Windows.Forms.CheckBox()
        Me.chkPropCrossSectionMarkerDH = New System.Windows.Forms.CheckBox()
        Me.chkPropCrossSectionMarkerLW = New System.Windows.Forms.CheckBox()
        Me.chkPropCrossSectionMarkerRW = New System.Windows.Forms.CheckBox()
        Me.lblPropCrossSectionMarkerUH = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerDH = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerDH = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionMarkerDHUM = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerLW = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerRWUM = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerRW = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerLW = New System.Windows.Forms.NumericUpDown()
        Me.txtPropCrossSectionMarkerRW = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionMarkerLWUM = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerUH = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionMarkerUHUM = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerL = New System.Windows.Forms.Label()
        Me.cboPropCrossSectionMarkerLabelRotation = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.chkPropCrossSectionMarkerLabel = New System.Windows.Forms.CheckBox()
        Me.cboPropCrossSectionMarkerScale = New System.Windows.Forms.ComboBox()
        Me.cboPropCrossSectionMarkerDirection = New System.Windows.Forms.ComboBox()
        Me.lblPropCrossSectionMarkerScale = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerDirection = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerLabelDistance = New System.Windows.Forms.NumericUpDown()
        Me.cmdPropCrossSectionItem = New System.Windows.Forms.Button()
        Me.lblPropCrossSectionMarkerLabelDistance = New System.Windows.Forms.Label()
        Me.cmdPropCrossSectionMarkerUDFromDesign = New System.Windows.Forms.Button()
        Me.cboPropCrossSectionMarkerLabelPosition = New System.Windows.Forms.ComboBox()
        Me.lblPropCrossSectionMarkerLabelPosition = New System.Windows.Forms.Label()
        Me.cmdPropCrossSectionMarkerLRFromDesign = New System.Windows.Forms.Button()
        Me.lbltxtPropCrossSectionMarkerRUM = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerDeltaAngle = New System.Windows.Forms.NumericUpDown()
        Me.txtPropCrossSectionMarkerPosition = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionMarkerDeltaAngle = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerD = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerR = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerU = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerU = New System.Windows.Forms.NumericUpDown()
        Me.txtPropCrossSectionMarkerL = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionMarkerAlign = New System.Windows.Forms.Label()
        Me.txtPropCrossSectionMarkerR = New System.Windows.Forms.NumericUpDown()
        Me.cboPropCrossSectionMarkerPlanAlign = New System.Windows.Forms.ComboBox()
        Me.txtPropCrossSectionMarkerD = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionMarkerDUM = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerUUM = New System.Windows.Forms.Label()
        Me.lblPropCrossSectionMarkerLUM = New System.Windows.Forms.Label()
        Me.cboPropCrossSectionMarkerProfileAlign = New System.Windows.Forms.ComboBox()
        Me.pnlPropTrigpointsDistances = New System.Windows.Forms.Panel()
        Me.chkPropTrigpointDistancesSplays = New System.Windows.Forms.CheckBox()
        Me.lblPropTrigpointsDistances = New System.Windows.Forms.Label()
        Me.cmdPropTrigpointDistancesCalculate = New System.Windows.Forms.Button()
        Me.lvPropTrigpointDistances = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlPropVisibility = New System.Windows.Forms.Panel()
        Me.cboPropAffinity = New System.Windows.Forms.ComboBox()
        Me.lblPropAffinity = New System.Windows.Forms.Label()
        Me.chkPropVisibleByProfile = New System.Windows.Forms.Button()
        Me.chkPropVisibleByScale = New System.Windows.Forms.Button()
        Me.lblPropVisibleIn = New System.Windows.Forms.Label()
        Me.chkPropVisibleInDesign = New System.Windows.Forms.CheckBox()
        Me.chkPropVisibleInPreview = New System.Windows.Forms.CheckBox()
        Me.pnlPropAttachment = New System.Windows.Forms.Panel()
        Me.cmdPropAttachmentBrowse = New System.Windows.Forms.Button()
        Me.txtPropAttachmentName = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblPropAttachmentNote = New System.Windows.Forms.Label()
        Me.txtPropAttachmentNote = New System.Windows.Forms.TextBox()
        Me.picPropAttachmentPreview = New System.Windows.Forms.PictureBox()
        Me.cmdPropAttachmentOpen = New System.Windows.Forms.Button()
        Me.lblPropAttachment = New System.Windows.Forms.Label()
        Me.pnlPropLegend = New System.Windows.Forms.Panel()
        Me.cPropLegendItems = New cSurveyPC.cItemLegendPropertyControl()
        Me.pnlPropScale = New System.Windows.Forms.Panel()
        Me.cPropScaleItems = New cSurveyPC.cItemScalePropertyControl()
        Me.pnlPropCompass = New System.Windows.Forms.Panel()
        Me.cPropCompassItems = New cSurveyPC.cItemCompassPropertyControl()
        Me.cPropName = New cSurveyPC.cItemNamePropertyControl()
        Me.tabObjectProp3D = New System.Windows.Forms.TabPage()
        Me.tbl3DProp = New System.Windows.Forms.TableLayoutPanel()
        Me.c3DLinkedSurveys = New cSurveyPC.cDesignLinkedSurveySelectorPropertyControl()
        Me.pnl3DMain = New System.Windows.Forms.Panel()
        Me.txt3DSurfaceElevationAmp = New System.Windows.Forms.NumericUpDown()
        Me.lbl3DSurfaceElevationAmp = New System.Windows.Forms.Label()
        Me.pnl3DPlotContainer = New System.Windows.Forms.Panel()
        Me.chk3DPlotShowModel = New System.Windows.Forms.CheckBox()
        Me.chk3DPlot = New System.Windows.Forms.CheckBox()
        Me.pnl3dPlotModel = New System.Windows.Forms.Panel()
        Me.chk3dPlotModelExtendedElevation = New System.Windows.Forms.CheckBox()
        Me.chk3dModelColorGray = New System.Windows.Forms.CheckBox()
        Me.lbl3dPlotModelMode = New System.Windows.Forms.Label()
        Me.cbo3dPlotModelMode = New System.Windows.Forms.ComboBox()
        Me.cbo3dPlotModelColoringMode = New System.Windows.Forms.ComboBox()
        Me.lbl3dPlotModelColoringMode = New System.Windows.Forms.Label()
        Me.pnl3DPlot = New System.Windows.Forms.Panel()
        Me.chk3DPlotColorGray = New System.Windows.Forms.CheckBox()
        Me.chk3DPlotShowTrigpointText = New System.Windows.Forms.CheckBox()
        Me.cbo3dPlotColorMode = New System.Windows.Forms.ComboBox()
        Me.chk3DPlotShowTrigpoint = New System.Windows.Forms.CheckBox()
        Me.lbl3dPlotColorMode = New System.Windows.Forms.Label()
        Me.chk3DPlotShowSplay = New System.Windows.Forms.CheckBox()
        Me.chk3DPlotShowSplayLabel = New System.Windows.Forms.CheckBox()
        Me.chk3DPlotShowSegment = New System.Windows.Forms.CheckBox()
        Me.cbo3DPlotSplayStyle = New System.Windows.Forms.ComboBox()
        Me.chk3DPlotShowLRUD = New System.Windows.Forms.CheckBox()
        Me.cbo3DPlotSegmentsPaintStyle = New System.Windows.Forms.ComboBox()
        Me.pnl3DSurfaceContainer = New System.Windows.Forms.Panel()
        Me.chk3DSurface = New System.Windows.Forms.CheckBox()
        Me.cmd3dSurfaceEdit = New System.Windows.Forms.Button()
        Me.pnl3DSurface = New System.Windows.Forms.Panel()
        Me.txt3DSurfaceTransparency = New System.Windows.Forms.NumericUpDown()
        Me.tv3DSurfaceLayers = New System.Windows.Forms.TreeView()
        Me.lbl3dSurfaceTransparency = New System.Windows.Forms.Label()
        Me.cmd3DSurfaceLayersEdit = New System.Windows.Forms.Button()
        Me.cmd3DSurfaceLayersUp = New System.Windows.Forms.Button()
        Me.tv3DSurfaceElevationsLayers = New System.Windows.Forms.TreeView()
        Me.cmd3DSurfaceLayersDown = New System.Windows.Forms.Button()
        Me.tbWorkspaces = New System.Windows.Forms.ToolStrip()
        Me.btnWorkspaceData = New System.Windows.Forms.ToolStripButton()
        Me.btnWorkspaceDesign = New System.Windows.Forms.ToolStripButton()
        Me.btnWorkspaceAll = New System.Windows.Forms.ToolStripButton()
        Me.tbPens = New System.Windows.Forms.ToolStrip()
        Me.lblPensStyle = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenSmooting = New System.Windows.Forms.ToolStripButton()
        Me.cboPensSmooting = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator15 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenLine = New System.Windows.Forms.ToolStripButton()
        Me.btnPenSpline = New System.Windows.Forms.ToolStripButton()
        Me.btnPenBezier = New System.Windows.Forms.ToolStripButton()
        Me.tbLayers = New System.Windows.Forms.ToolStrip()
        Me.btnLayer_Base = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayer_Soil = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayer_Water = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayer_Rocks = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayer_TerrainLevel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayer_Borders = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayer_Signs = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnLayerManageLevels = New System.Windows.Forms.ToolStripButton()
        Me.tbDesign = New System.Windows.Forms.ToolStrip()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnSurveyNew = New System.Windows.Forms.ToolStripButton()
        Me.btnSurveyOpen = New System.Windows.Forms.ToolStripButton()
        Me.btnSurveySave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnExportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem49 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportTrack = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem50 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExportImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem101 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport3D = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSurface = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnViewer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnCut = New System.Windows.Forms.ToolStripButton()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.btnPaste = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSegmentAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnSegmentDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPlotCalculate = New System.Windows.Forms.ToolStripButton()
        Me.btnPlotRebind = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnPlotRebindRebind = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPlotRebindRemoveOrphans = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPlotInfoCave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.btnZooms = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnZoomsCenter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZooms10m = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnZooms50m = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnZooms100m = New System.Windows.Forms.ToolStripMenuItem()
        Me.MetriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem27 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomsToFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnZoomToFit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnProperty = New System.Windows.Forms.ToolStripButton()
        Me.tbView = New System.Windows.Forms.ToolStrip()
        Me.btnShowFieldData = New System.Windows.Forms.ToolStripButton()
        Me.btnShowObjectProp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboMainSessionList = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator18 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboMainCaveList = New System.Windows.Forms.ToolStripComboBox()
        Me.cboMainCaveBranchList = New System.Windows.Forms.ToolStripComboBox()
        Me.btnDesignHighlight = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnDesignHighlight0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesignHighlight1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem70 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDesignHighlightMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesignHighlightMode0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesignHighlightMode1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnDesignHighlightMode2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnDesignHighlightSegmentsAndTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboMainBindDesignType = New System.Windows.Forms.ToolStripComboBox()
        Me.cboMainBindCrossSections = New System.Windows.Forms.ToolStripComboBox()
        Me.btnObjectSetCaveBranch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnViewSplayShowMode = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btnViewSplayShowMode1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnViewSplayShowMode0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnObjectShowBindings = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnObjectProp = New System.Windows.Forms.ToolStripButton()
        Me.sbMain = New System.Windows.Forms.StatusStrip()
        Me.pnlStatusMasterSlave = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.pnlStatusCurrentRule = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusWMSOnLine = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusHistoryEnabled = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignWarpingState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignGeographicState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlStatusDesignSnapToGrid = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdCoordinateGetFromGPS = New System.Windows.Forms.Button()
        Me.lblCoordinateGeo = New System.Windows.Forms.Label()
        Me.lblCoordinateFormat = New System.Windows.Forms.Label()
        Me.lblCoordinateLong = New System.Windows.Forms.Label()
        Me.lblCoordinateLat = New System.Windows.Forms.Label()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileNewFromTemplate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileRollback = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem97 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileHistory = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileCleanUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem89 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileImportSurvey = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem58 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileImportTracks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem94 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileImportDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExportSurvey = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExportTrack = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExportImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem100 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExport3D = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem87 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileResurvey = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFile3D = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileTherion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFilePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem18 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileProp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSurface = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem48 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileAutoSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileRecent = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem74 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileHideInTray = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem29 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditSelectAllSep = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditSelectAllInCurrentLevelInDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditSelectAllInDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEditFindSep = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuEditFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBars = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBarsMain = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBarsView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBarsWorkspaces = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBarsLayer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBarsTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewBarsPens = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem63 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewBarsPen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem34 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewWorkspaces = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewWorkspacesData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewWorkspacesDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewWorkspacesAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem56 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewWorkspacesManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewFieldData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignArea = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewObjectProp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewGraphics = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphics0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphics1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphics2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewGraphicsRulers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphicsMetricGrid = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphicsMetricGrid0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphicsMetricGrid1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGraphicsMetricGrid2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem26 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewGraphicsShowAdvancedBrushes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignUnselectedLevelDrawingMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignUnselectedLevelDrawingMode0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignUnselectedLevelDrawingMode1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignUnselectedLevelDrawingMode2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem75 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewDesignStyle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignStyle0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignStyle1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewDesignStyle2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotSegments = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowAlso = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowAlso1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowAlso2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem85 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewPlotLRUD = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotLRUDHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem95 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewPlotShowStyle0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowStyle1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowStyle2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowStyle3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotSplay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotSplayHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem96 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewPlotSplayStyle0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotSplayStyle1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem57 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewPlotSplayText = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem28 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewPlotShowStation = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowStationText = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewPlotShowPointInformation = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewPlan = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewProfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView3D = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem33 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem103 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewScript = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem114 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewLinkedSurveys = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuViewConsole = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotRebind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotRemoveOrphans = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem44 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotGrades = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem77 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotCalculate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem35 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotInfoSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotInfoEntrance = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotInfoCave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotInfoRing = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotInfoOrientation = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotInfoDistances = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem67 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotPrefixTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotRenameTrigpoints = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotReplicateData = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPlotManageLRUD = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem98 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotSplayReplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem36 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotManageVisibility = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem32 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPlotDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignEndEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignObjectProp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem64 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignEditScaleRules = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem68 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignHighlight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignHighlight0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignHighlight1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem46 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignHighlightMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignHighlightMode0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignHighlightMode1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignHighlightMode2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignPlotRebindAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignPlotRemoveBindings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem39 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignPlotUnlockAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignPlotLockAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem40 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignPlotShowBindings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem37 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignDeleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem17 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayers1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLayers6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem55 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLayersManageLevels = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZoom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZoomZoomIn = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZoomZoomOut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem31 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuZoomZoomCenter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem30 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuZoomZoomToFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZoomZoomToSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuZoomZoomToFitCaveBranch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem25 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuZoomAutoZoomToFit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelpCheckUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem20 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuHelpInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignNone = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesignNoneInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem105 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignNonePaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignNonePasteSpecial = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignNonePasteSpecial0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem59 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignNonePasteSpecial1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignNonePasteSpecial2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignNonePasteSpecial3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem54 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignNoneItemUnder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem107 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem106 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignNoneProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignNoneRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItem = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesignItemInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBarInfo = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSignSaveInGallery = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem113 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSignExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemClipart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemClipartSaveInGallery = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem112 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemClipartExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentTrigpoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentTrigpointFrom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentTrigpointTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentInvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentDirection = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentDirection0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentDirection1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentDirection2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem83 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSegmentDirection3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentDirection4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentSetCoordinate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentSetCoordinateCP = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentSplay = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentSplayReplicate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentSplayBar1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSegmentSplayCreateBorder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSegmentSplayCreateBorderPanel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemGeneric = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemGenericCombine = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemGenericDivide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemGenericCombineAllSequences = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemGenericCloseAllSequences = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemGenericReorderSequence = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemGenericRevertAllSequences = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem92 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemGenericRestorePointPen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemGenericWiden = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem53 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemGenericReducePoint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemItemsCombine = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemItemsCombineGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem111 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemItemsCombineRockClipart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemItemsCombineConcretionClipart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem110 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemItemsCombineSignClipart = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemImageRescale = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageRescale90 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageRescale50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageResizeMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageResizeMode0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageResizeMode1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageRealSize = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageRealSizeImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemImageRealSize100 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageRealSize250 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageRealSize500 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem79 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemImageVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageVisibleShowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemImageVisibleHideAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem82 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemImageView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSketch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSketchEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem78 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSketchMorphing = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSketchMorphingDisabled = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem81 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSketchMorphingEnableAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSketchMorphingDisableAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem80 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSketchVisible = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSketchVisibleShowAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSketchVisibleHideAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem86 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSketchView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemLegend = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemLegendAddTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar0 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPasteSpecial = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPasteSpecialPen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPasteSpecialBrush = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemItemUnder = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemItemUnderItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemItemBar8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSendToBottom = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSendBehind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBringAhead = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBringOnTop = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemSendCopyTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSendCopyTo0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemSendCopyTo1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemChangeTo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemChangeTo4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem61 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemChangeTo1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemChangeTo2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemChangeTo3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemFlip = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemFlipH = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemFlipV = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemRotate = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemRotate15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemRotate45 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemRotate90 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemRotate180 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemRotate270 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPlotSetCaveBranch = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem69 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPlotBindSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem24 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPlotLockAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPlotUnlockAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemLock = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemProperty = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemHiddenInDesign = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemBar7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPoint = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDesignItemPointAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointSegmentBar = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPointSegmentDivide = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointSegmentDivideAndJoin = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointSegmentCombine = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointDeleteSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointCloseSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointRevertSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemAreaFromSequenceBar = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemAreaFromSequence = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemAreaFromSequencePanel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointConvertBar = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPointConvert = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointConvertToLines = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointConvertToSpline = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointConvertToBezier = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointNewFromSequenceBar = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPointNewFromSequence0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointNewFromSequence1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointPlotBar = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPointPlot = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDesignItemPointPlotLockSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPointPlotBindSegment = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDesignItemPointRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuMapDrop = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuMapDropImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMapDropSketch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMapDropPocketTopo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMapDropCaveExplorer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMapDropText = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMapDropAttachment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnnuTrayShowHide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem72 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTrayClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrAutosave = New System.Windows.Forms.Timer(Me.components)
        Me.imlNotify = New System.Windows.Forms.ImageList(Me.components)
        Me.tmrClipboard = New System.Windows.Forms.Timer(Me.components)
        Me.tmrMouseMove = New System.Windows.Forms.Timer(Me.components)
        Me.imlPopup = New System.Windows.Forms.ImageList(Me.components)
        Me.ntiMain = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.bwMain = New System.ComponentModel.BackgroundWorker()
        Me.tsMain.ContentPanel.SuspendLayout()
        Me.tsMain.TopToolStripPanel.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.pnlConsole.SuspendLayout()
        Me.pnlDesigner.SuspendLayout()
        Me.pnl3D.SuspendLayout()
        Me.pnlPopup.SuspendLayout()
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbViews.SuspendLayout()
        Me.pnlData.SuspendLayout()
        CType(Me.spSegmentsAndTrigpoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spSegmentsAndTrigpoints.Panel1.SuspendLayout()
        Me.spSegmentsAndTrigpoints.Panel2.SuspendLayout()
        Me.spSegmentsAndTrigpoints.SuspendLayout()
        CType(Me.spSegments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spSegments.Panel1.SuspendLayout()
        Me.spSegments.Panel2.SuspendLayout()
        Me.spSegments.SuspendLayout()
        CType(Me.grdSegments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSegments.SuspendLayout()
        Me.pnlSegment.SuspendLayout()
        Me.tabSegmentProperty.SuspendLayout()
        Me.tabSegmentPropertyMain.SuspendLayout()
        Me.pnlSegmentSurfaceProfile.SuspendLayout()
        Me.tabSegmentPropertyData.SuspendLayout()
        Me.mnuSegmentsDataProperties.SuspendLayout()
        Me.tabSegmentPropertyLayout.SuspendLayout()
        CType(Me.picSegmentColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSegmentPropertyNote.SuspendLayout()
        Me.tabSegmentPropertyImage.SuspendLayout()
        CType(Me.tvSegmentAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuAttachments.SuspendLayout()
        Me.pnlSegmentFromAndTo.SuspendLayout()
        Me.pnlSegmentCaveBranches.SuspendLayout()
        Me.pnlSegmentSession.SuspendLayout()
        CType(Me.spTrigPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.spTrigPoints.Panel1.SuspendLayout()
        Me.spTrigPoints.Panel2.SuspendLayout()
        Me.spTrigPoints.SuspendLayout()
        CType(Me.grdTrigPoints, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuTrigPoints.SuspendLayout()
        Me.pnlTrigPoint.SuspendLayout()
        Me.tabTrigpointProperty.SuspendLayout()
        Me.tabTrigpointMain.SuspendLayout()
        CType(Me.grdTrigPointAliases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuAliases.SuspendLayout()
        Me.tabTrigpointPropertyData.SuspendLayout()
        Me.mnuTrigpointDataProperties.SuspendLayout()
        Me.tabTrigpointLayout.SuspendLayout()
        CType(Me.txtTrigPointLabelDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picTrigpointFontColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTrigpointConnections.SuspendLayout()
        CType(Me.grdTrigpointConnections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTrigpointCoordinate.SuspendLayout()
        Me.pnlTrigpointCoordinateWGS84.SuspendLayout()
        Me.pnlTrigpointCoordinateUTM.SuspendLayout()
        Me.tabTrigpointNote.SuspendLayout()
        Me.pnlTrigpointName.SuspendLayout()
        Me.tbSegmentsAndTrigpoints.SuspendLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlObjectLayers.SuspendLayout()
        CType(Me.tvLayers2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuLayersAndItems.SuspendLayout()
        CType(Me.piclayerItemPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProperties.SuspendLayout()
        Me.tabObjectProp.SuspendLayout()
        Me.tabObjectPropDesign.SuspendLayout()
        Me.tblDesignProp.SuspendLayout()
        Me.pnlDesignSize.SuspendLayout()
        CType(Me.txtDesignScaleHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignScaleWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDesignPosition.SuspendLayout()
        Me.pnlDesignRotation.SuspendLayout()
        Me.pnlDesignStyle.SuspendLayout()
        Me.pnlDesignCombineColorMode.SuspendLayout()
        Me.pnlDesignSnapToGrid.SuspendLayout()
        CType(Me.txtDesignSnapToGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDesignPlotContainer.SuspendLayout()
        Me.pnlDesignPlot.SuspendLayout()
        Me.pnlDesignSurfaceContainer.SuspendLayout()
        Me.pnlDesignSurface.SuspendLayout()
        Me.mnuDesignSurfaceLayers.SuspendLayout()
        Me.pnlDesignSurfaceProfile.SuspendLayout()
        Me.pnlDesignPrintOrExportAreaContainer.SuspendLayout()
        Me.tabObjectPropMain.SuspendLayout()
        Me.tblObjectProp.SuspendLayout()
        Me.pnlPropConvertTo.SuspendLayout()
        Me.pnlPropClipping.SuspendLayout()
        Me.pnlPropShape.SuspendLayout()
        Me.pnlPropShapeSequences.SuspendLayout()
        CType(Me.txtPropLinePointReductionFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropSign.SuspendLayout()
        Me.pnlPropImage.SuspendLayout()
        CType(Me.txtPropImageScaleFree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropInfo.SuspendLayout()
        Me.pnlPropCaveBranches.SuspendLayout()
        Me.pnlPropPen.SuspendLayout()
        Me.tblPropPen.SuspendLayout()
        Me.pnlPropPenGeneric.SuspendLayout()
        Me.pnlPropPenCustom.SuspendLayout()
        CType(Me.txtPropPenDecorationScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPenDecorationSpacePercentage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropPenColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropSize.SuspendLayout()
        CType(Me.txtPropScaleHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropScaleWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropPosition.SuspendLayout()
        Me.pnlPropPositionSubPanel1.SuspendLayout()
        Me.pnlPropRotation.SuspendLayout()
        Me.pnlPropLineType.SuspendLayout()
        Me.pnlPropBrush.SuspendLayout()
        Me.tblPropBrush.SuspendLayout()
        Me.pnlPropBrushGeneric.SuspendLayout()
        Me.pnlPropBrushCustom.SuspendLayout()
        CType(Me.picPropBrushAlternativeBrushColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropBrushColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropBrushClipartImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartZoomFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropBrushClipartDensity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropSegmentBinding.SuspendLayout()
        Me.pnlPropSegmentsBinding.SuspendLayout()
        Me.pnlPropText.SuspendLayout()
        Me.tblPropText.SuspendLayout()
        Me.pnlPropTextFont.SuspendLayout()
        CType(Me.picPropFontColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropTextStyle.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlPropCrossSection.SuspendLayout()
        CType(Me.txtPropCrossSectionHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileTextDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropQuota.SuspendLayout()
        Me.pnlPropSketch.SuspendLayout()
        CType(Me.picPropSketch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropMergeMode.SuspendLayout()
        Me.pnlPropTransparency.SuspendLayout()
        CType(Me.txtPropTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropObjectsBinding.SuspendLayout()
        Me.pnlPropPointsSequences.SuspendLayout()
        Me.pnlPropSequenceLineType.SuspendLayout()
        Me.pnlPropProp.SuspendLayout()
        Me.pnlPropItems.SuspendLayout()
        Me.pnlPropPopup.SuspendLayout()
        CType(Me.picPropPopupWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropProfileSplayBorder.SuspendLayout()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropProfileProjectionSchema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropPlanSplayBorder.SuspendLayout()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropPlanProjectionSchema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropDataProperties.SuspendLayout()
        Me.mnuDesignDataProperties.SuspendLayout()
        Me.pnlPropCrossSectionSplayBorder.SuspendLayout()
        CType(Me.txtPropCrossSectionSplayProjectionVerticalAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPropCrossSectionProjectionSchema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropSegmentInfo.SuspendLayout()
        Me.mnuSegmentInfo.SuspendLayout()
        Me.pnlPropTrigpointInfo.SuspendLayout()
        Me.mnuTrigpointInfo.SuspendLayout()
        Me.pnlPropCrossSectionMarker.SuspendLayout()
        CType(Me.txtPropCrossSectionMarkerDH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerLW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerRW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerUH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerLabelDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerDeltaAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionMarkerD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropTrigpointsDistances.SuspendLayout()
        Me.pnlPropVisibility.SuspendLayout()
        Me.pnlPropAttachment.SuspendLayout()
        CType(Me.picPropAttachmentPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPropLegend.SuspendLayout()
        Me.pnlPropScale.SuspendLayout()
        Me.pnlPropCompass.SuspendLayout()
        Me.tabObjectProp3D.SuspendLayout()
        Me.tbl3DProp.SuspendLayout()
        Me.pnl3DMain.SuspendLayout()
        CType(Me.txt3DSurfaceElevationAmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl3DPlotContainer.SuspendLayout()
        Me.pnl3dPlotModel.SuspendLayout()
        Me.pnl3DPlot.SuspendLayout()
        Me.pnl3DSurfaceContainer.SuspendLayout()
        Me.pnl3DSurface.SuspendLayout()
        CType(Me.txt3DSurfaceTransparency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbWorkspaces.SuspendLayout()
        Me.tbPens.SuspendLayout()
        Me.tbLayers.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.sbMain.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.mnuDesignNone.SuspendLayout()
        Me.mnuDesignItem.SuspendLayout()
        Me.mnuDesignItemPoint.SuspendLayout()
        Me.mnuMapDrop.SuspendLayout()
        Me.mnuTray.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        '
        'tsMain.ContentPanel
        '
        Me.tsMain.ContentPanel.Controls.Add(Me.pnlConsole)
        Me.tsMain.ContentPanel.Controls.Add(Me.pnlDesigner)
        Me.tsMain.ContentPanel.Controls.Add(Me.pnlData)
        Me.tsMain.ContentPanel.Controls.Add(Me.trkZoom)
        Me.tsMain.ContentPanel.Controls.Add(Me.pnlObjectLayers)
        Me.tsMain.ContentPanel.Controls.Add(Me.pnlProperties)
        resources.ApplyResources(Me.tsMain.ContentPanel, "tsMain.ContentPanel")
        resources.ApplyResources(Me.tsMain, "tsMain")
        Me.tsMain.Name = "tsMain"
        '
        'tsMain.TopToolStripPanel
        '
        Me.tsMain.TopToolStripPanel.Controls.Add(Me.tbWorkspaces)
        Me.tsMain.TopToolStripPanel.Controls.Add(Me.tbPens)
        Me.tsMain.TopToolStripPanel.Controls.Add(Me.tbLayers)
        Me.tsMain.TopToolStripPanel.Controls.Add(Me.tbDesign)
        Me.tsMain.TopToolStripPanel.Controls.Add(Me.tbMain)
        Me.tsMain.TopToolStripPanel.Controls.Add(Me.tbView)
        '
        'pnlConsole
        '
        Me.pnlConsole.Controls.Add(Me.rtfConsole)
        resources.ApplyResources(Me.pnlConsole, "pnlConsole")
        Me.pnlConsole.Name = "pnlConsole"
        '
        'rtfConsole
        '
        Me.rtfConsole.BackColor = System.Drawing.Color.Black
        Me.rtfConsole.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.rtfConsole, "rtfConsole")
        Me.rtfConsole.ForeColor = System.Drawing.Color.White
        Me.rtfConsole.Name = "rtfConsole"
        Me.rtfConsole.ReadOnly = True
        '
        'pnlDesigner
        '
        Me.pnlDesigner.Controls.Add(Me.pnl3D)
        Me.pnlDesigner.Controls.Add(Me.pnlPopup)
        Me.pnlDesigner.Controls.Add(Me.picMap)
        Me.pnlDesigner.Controls.Add(Me.tbViews)
        resources.ApplyResources(Me.pnlDesigner, "pnlDesigner")
        Me.pnlDesigner.Name = "pnlDesigner"
        '
        'pnl3D
        '
        Me.pnl3D.BackColor = System.Drawing.SystemColors.Window
        Me.pnl3D.Controls.Add(Me.h3D)
        resources.ApplyResources(Me.pnl3D, "pnl3D")
        Me.pnl3D.Name = "pnl3D"
        '
        'h3D
        '
        Me.h3D.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.h3D, "h3D")
        Me.h3D.Name = "h3D"
        Me.h3D.Child = Nothing
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
        Me.btnPopupClose.Name = "btnPopupClose"
        Me.tipDefault.SetToolTip(Me.btnPopupClose, resources.GetString("btnPopupClose.ToolTip"))
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
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.picMap, "picMap")
        Me.picMap.Name = "picMap"
        Me.picMap.TabStop = False
        '
        'tbViews
        '
        Me.tbViews.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.tbViews, "tbViews")
        Me.tbViews.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbViews.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnView_Plan, Me.btnView_Profile, Me.ToolStripSeparator14, Me.btnView_3D, Me.ToolStripSeparator17, Me.btnCursorMode, Me.btnScrollMode, Me.btnAltMode, Me.btnMultiSelMode1, Me.btnMultiSelMode2, Me.btnSepSnapToPoint, Me.btnSnapToPointNone, Me.btnSnapToPoint0, Me.btnSnapToPoint1, Me.btnSnapToPoint2, Me.btnSepMode, Me.btnViewRulers, Me.btnViewMetricGrid, Me.btnViewMetricGridSep, Me.btnEditDrawing, Me.btnEditPointToPoint, Me.btnEditSep, Me.btnEndEdit, Me.btn3DSep, Me.btn3dViewTop, Me.btn3dViewBottom, Me.btn3dViewSN, Me.btn3dViewNS, Me.btn3dViewEO, Me.btn3dViewOE, Me.btn3DCameraSep, Me.btn3DCameraType, Me.btn3DCameraMode, Me.btnFilterSeparator, Me.btnFilterEdit, Me.btnFilterFiltered, Me.ToolStripSeparator16})
        Me.tbViews.Name = "tbViews"
        '
        'btnView_Plan
        '
        Me.btnView_Plan.Checked = True
        Me.btnView_Plan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnView_Plan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnView_Plan, "btnView_Plan")
        Me.btnView_Plan.Name = "btnView_Plan"
        '
        'btnView_Profile
        '
        Me.btnView_Profile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnView_Profile, "btnView_Profile")
        Me.btnView_Profile.Name = "btnView_Profile"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        resources.ApplyResources(Me.ToolStripSeparator14, "ToolStripSeparator14")
        '
        'btnView_3D
        '
        Me.btnView_3D.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnView_3D, "btnView_3D")
        Me.btnView_3D.Name = "btnView_3D"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        resources.ApplyResources(Me.ToolStripSeparator17, "ToolStripSeparator17")
        '
        'btnCursorMode
        '
        Me.btnCursorMode.Checked = True
        Me.btnCursorMode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnCursorMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnCursorMode, "btnCursorMode")
        Me.btnCursorMode.Name = "btnCursorMode"
        '
        'btnScrollMode
        '
        Me.btnScrollMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnScrollMode, "btnScrollMode")
        Me.btnScrollMode.Name = "btnScrollMode"
        '
        'btnAltMode
        '
        Me.btnAltMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnAltMode, "btnAltMode")
        Me.btnAltMode.Name = "btnAltMode"
        '
        'btnMultiSelMode1
        '
        Me.btnMultiSelMode1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnMultiSelMode1, "btnMultiSelMode1")
        Me.btnMultiSelMode1.Name = "btnMultiSelMode1"
        '
        'btnMultiSelMode2
        '
        Me.btnMultiSelMode2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnMultiSelMode2, "btnMultiSelMode2")
        Me.btnMultiSelMode2.Name = "btnMultiSelMode2"
        '
        'btnSepSnapToPoint
        '
        Me.btnSepSnapToPoint.Name = "btnSepSnapToPoint"
        resources.ApplyResources(Me.btnSepSnapToPoint, "btnSepSnapToPoint")
        '
        'btnSnapToPointNone
        '
        Me.btnSnapToPointNone.Checked = True
        Me.btnSnapToPointNone.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnSnapToPointNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSnapToPointNone, "btnSnapToPointNone")
        Me.btnSnapToPointNone.Name = "btnSnapToPointNone"
        '
        'btnSnapToPoint0
        '
        Me.btnSnapToPoint0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSnapToPoint0, "btnSnapToPoint0")
        Me.btnSnapToPoint0.Name = "btnSnapToPoint0"
        '
        'btnSnapToPoint1
        '
        Me.btnSnapToPoint1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSnapToPoint1, "btnSnapToPoint1")
        Me.btnSnapToPoint1.Name = "btnSnapToPoint1"
        '
        'btnSnapToPoint2
        '
        Me.btnSnapToPoint2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSnapToPoint2, "btnSnapToPoint2")
        Me.btnSnapToPoint2.Name = "btnSnapToPoint2"
        '
        'btnSepMode
        '
        Me.btnSepMode.Name = "btnSepMode"
        resources.ApplyResources(Me.btnSepMode, "btnSepMode")
        '
        'btnViewRulers
        '
        Me.btnViewRulers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnViewRulers, "btnViewRulers")
        Me.btnViewRulers.Name = "btnViewRulers"
        '
        'btnViewMetricGrid
        '
        Me.btnViewMetricGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewMetricGrid.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnViewMetricGrid0, Me.btnViewMetricGrid1, Me.btnViewMetricGrid2})
        resources.ApplyResources(Me.btnViewMetricGrid, "btnViewMetricGrid")
        Me.btnViewMetricGrid.Name = "btnViewMetricGrid"
        '
        'btnViewMetricGrid0
        '
        Me.btnViewMetricGrid0.Name = "btnViewMetricGrid0"
        resources.ApplyResources(Me.btnViewMetricGrid0, "btnViewMetricGrid0")
        '
        'btnViewMetricGrid1
        '
        Me.btnViewMetricGrid1.Name = "btnViewMetricGrid1"
        resources.ApplyResources(Me.btnViewMetricGrid1, "btnViewMetricGrid1")
        '
        'btnViewMetricGrid2
        '
        Me.btnViewMetricGrid2.Name = "btnViewMetricGrid2"
        resources.ApplyResources(Me.btnViewMetricGrid2, "btnViewMetricGrid2")
        '
        'btnViewMetricGridSep
        '
        Me.btnViewMetricGridSep.Name = "btnViewMetricGridSep"
        resources.ApplyResources(Me.btnViewMetricGridSep, "btnViewMetricGridSep")
        '
        'btnEditDrawing
        '
        Me.btnEditDrawing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnEditDrawing, "btnEditDrawing")
        Me.btnEditDrawing.Name = "btnEditDrawing"
        '
        'btnEditPointToPoint
        '
        Me.btnEditPointToPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnEditPointToPoint, "btnEditPointToPoint")
        Me.btnEditPointToPoint.Name = "btnEditPointToPoint"
        '
        'btnEditSep
        '
        Me.btnEditSep.Name = "btnEditSep"
        resources.ApplyResources(Me.btnEditSep, "btnEditSep")
        '
        'btnEndEdit
        '
        Me.btnEndEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnEndEdit, "btnEndEdit")
        Me.btnEndEdit.Name = "btnEndEdit"
        '
        'btn3DSep
        '
        Me.btn3DSep.Name = "btn3DSep"
        resources.ApplyResources(Me.btn3DSep, "btn3DSep")
        '
        'btn3dViewTop
        '
        Me.btn3dViewTop.BackColor = System.Drawing.Color.Blue
        Me.btn3dViewTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn3dViewTop.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.btn3dViewTop, "btn3dViewTop")
        Me.btn3dViewTop.Name = "btn3dViewTop"
        '
        'btn3dViewBottom
        '
        Me.btn3dViewBottom.BackColor = System.Drawing.Color.Blue
        Me.btn3dViewBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn3dViewBottom.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.btn3dViewBottom, "btn3dViewBottom")
        Me.btn3dViewBottom.Name = "btn3dViewBottom"
        '
        'btn3dViewSN
        '
        Me.btn3dViewSN.BackColor = System.Drawing.Color.Green
        Me.btn3dViewSN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn3dViewSN.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.btn3dViewSN, "btn3dViewSN")
        Me.btn3dViewSN.Name = "btn3dViewSN"
        '
        'btn3dViewNS
        '
        Me.btn3dViewNS.BackColor = System.Drawing.Color.Green
        Me.btn3dViewNS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn3dViewNS.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.btn3dViewNS, "btn3dViewNS")
        Me.btn3dViewNS.Name = "btn3dViewNS"
        '
        'btn3dViewEO
        '
        Me.btn3dViewEO.BackColor = System.Drawing.Color.Red
        Me.btn3dViewEO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn3dViewEO.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.btn3dViewEO, "btn3dViewEO")
        Me.btn3dViewEO.Name = "btn3dViewEO"
        '
        'btn3dViewOE
        '
        Me.btn3dViewOE.BackColor = System.Drawing.Color.Red
        Me.btn3dViewOE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btn3dViewOE.ForeColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.btn3dViewOE, "btn3dViewOE")
        Me.btn3dViewOE.Name = "btn3dViewOE"
        '
        'btn3DCameraSep
        '
        Me.btn3DCameraSep.Name = "btn3DCameraSep"
        resources.ApplyResources(Me.btn3DCameraSep, "btn3DCameraSep")
        '
        'btn3DCameraType
        '
        Me.btn3DCameraType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn3DCameraType.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn3DCameraType1, Me.btn3DCameraType0})
        resources.ApplyResources(Me.btn3DCameraType, "btn3DCameraType")
        Me.btn3DCameraType.Name = "btn3DCameraType"
        '
        'btn3DCameraType1
        '
        Me.btn3DCameraType1.Name = "btn3DCameraType1"
        resources.ApplyResources(Me.btn3DCameraType1, "btn3DCameraType1")
        '
        'btn3DCameraType0
        '
        Me.btn3DCameraType0.Name = "btn3DCameraType0"
        resources.ApplyResources(Me.btn3DCameraType0, "btn3DCameraType0")
        '
        'btn3DCameraMode
        '
        Me.btn3DCameraMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn3DCameraMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn3DCameraMode1, Me.btn3DCameraMode0})
        resources.ApplyResources(Me.btn3DCameraMode, "btn3DCameraMode")
        Me.btn3DCameraMode.Name = "btn3DCameraMode"
        '
        'btn3DCameraMode1
        '
        Me.btn3DCameraMode1.Name = "btn3DCameraMode1"
        resources.ApplyResources(Me.btn3DCameraMode1, "btn3DCameraMode1")
        '
        'btn3DCameraMode0
        '
        Me.btn3DCameraMode0.Name = "btn3DCameraMode0"
        resources.ApplyResources(Me.btn3DCameraMode0, "btn3DCameraMode0")
        '
        'btnFilterSeparator
        '
        Me.btnFilterSeparator.Name = "btnFilterSeparator"
        resources.ApplyResources(Me.btnFilterSeparator, "btnFilterSeparator")
        '
        'btnFilterEdit
        '
        Me.btnFilterEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnFilterEdit, "btnFilterEdit")
        Me.btnFilterEdit.Name = "btnFilterEdit"
        '
        'btnFilterFiltered
        '
        Me.btnFilterFiltered.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnFilterFiltered, "btnFilterFiltered")
        Me.btnFilterFiltered.Name = "btnFilterFiltered"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        resources.ApplyResources(Me.ToolStripSeparator16, "ToolStripSeparator16")
        '
        'pnlData
        '
        Me.pnlData.Controls.Add(Me.spSegmentsAndTrigpoints)
        Me.pnlData.Controls.Add(Me.tbSegmentsAndTrigpoints)
        Me.pnlData.Controls.Add(Me.Button1)
        resources.ApplyResources(Me.pnlData, "pnlData")
        Me.pnlData.Name = "pnlData"
        '
        'spSegmentsAndTrigpoints
        '
        resources.ApplyResources(Me.spSegmentsAndTrigpoints, "spSegmentsAndTrigpoints")
        Me.spSegmentsAndTrigpoints.Name = "spSegmentsAndTrigpoints"
        '
        'spSegmentsAndTrigpoints.Panel1
        '
        Me.spSegmentsAndTrigpoints.Panel1.Controls.Add(Me.spSegments)
        '
        'spSegmentsAndTrigpoints.Panel2
        '
        Me.spSegmentsAndTrigpoints.Panel2.Controls.Add(Me.spTrigPoints)
        '
        'spSegments
        '
        Me.spSegments.BackColor = System.Drawing.SystemColors.ControlLight
        resources.ApplyResources(Me.spSegments, "spSegments")
        Me.spSegments.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.spSegments.Name = "spSegments"
        '
        'spSegments.Panel1
        '
        Me.spSegments.Panel1.Controls.Add(Me.grdSegments)
        '
        'spSegments.Panel2
        '
        Me.spSegments.Panel2.Controls.Add(Me.pnlSegment)
        '
        'grdSegments
        '
        Me.grdSegments.AllowDrop = True
        Me.grdSegments.AllowUserToOrderColumns = True
        Me.grdSegments.AllowUserToResizeRows = False
        Me.grdSegments.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdSegments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSegments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSegmentSession, Me.colCaveBranchColor, Me.colFrom, Me.colTo, Me.colDist, Me.colDirezione, Me.colInclinazione, Me.colSinistra, Me.colDestra, Me.colAlto, Me.colBasso, Me.colInverted, Me.colExclude, Me.colSegmentNote, Me.colSegmentImage})
        Me.grdSegments.ContextMenuStrip = Me.mnuSegments
        resources.ApplyResources(Me.grdSegments, "grdSegments")
        Me.grdSegments.GridColor = System.Drawing.SystemColors.ControlLight
        Me.grdSegments.Name = "grdSegments"
        '
        'colSegmentSession
        '
        Me.colSegmentSession.Frozen = True
        resources.ApplyResources(Me.colSegmentSession, "colSegmentSession")
        Me.colSegmentSession.Name = "colSegmentSession"
        '
        'colCaveBranchColor
        '
        Me.colCaveBranchColor.Frozen = True
        resources.ApplyResources(Me.colCaveBranchColor, "colCaveBranchColor")
        Me.colCaveBranchColor.Name = "colCaveBranchColor"
        Me.colCaveBranchColor.ReadOnly = True
        '
        'colFrom
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info
        Me.colFrom.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colFrom, "colFrom")
        Me.colFrom.Name = "colFrom"
        Me.colFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colTo
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colTo.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.colTo, "colTo")
        Me.colTo.Name = "colTo"
        Me.colTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colDist
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.NullValue = "0"
        Me.colDist.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.colDist, "colDist")
        Me.colDist.Name = "colDist"
        Me.colDist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colDirezione
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.NullValue = "0"
        Me.colDirezione.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.colDirezione, "colDirezione")
        Me.colDirezione.Name = "colDirezione"
        Me.colDirezione.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colInclinazione
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.NullValue = "0"
        Me.colInclinazione.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.colInclinazione, "colInclinazione")
        Me.colInclinazione.Name = "colInclinazione"
        Me.colInclinazione.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSinistra
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.NullValue = "0"
        Me.colSinistra.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.colSinistra, "colSinistra")
        Me.colSinistra.Name = "colSinistra"
        Me.colSinistra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colDestra
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.NullValue = "0"
        Me.colDestra.DefaultCellStyle = DataGridViewCellStyle7
        resources.ApplyResources(Me.colDestra, "colDestra")
        Me.colDestra.Name = "colDestra"
        Me.colDestra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colAlto
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.NullValue = "0"
        Me.colAlto.DefaultCellStyle = DataGridViewCellStyle8
        resources.ApplyResources(Me.colAlto, "colAlto")
        Me.colAlto.Name = "colAlto"
        Me.colAlto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colBasso
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.NullValue = "0"
        Me.colBasso.DefaultCellStyle = DataGridViewCellStyle9
        resources.ApplyResources(Me.colBasso, "colBasso")
        Me.colBasso.Name = "colBasso"
        Me.colBasso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colInverted
        '
        resources.ApplyResources(Me.colInverted, "colInverted")
        Me.colInverted.Name = "colInverted"
        '
        'colExclude
        '
        resources.ApplyResources(Me.colExclude, "colExclude")
        Me.colExclude.Name = "colExclude"
        '
        'colSegmentNote
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colSegmentNote.DefaultCellStyle = DataGridViewCellStyle10
        resources.ApplyResources(Me.colSegmentNote, "colSegmentNote")
        Me.colSegmentNote.Name = "colSegmentNote"
        Me.colSegmentNote.ReadOnly = True
        '
        'colSegmentImage
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colSegmentImage.DefaultCellStyle = DataGridViewCellStyle11
        resources.ApplyResources(Me.colSegmentImage, "colSegmentImage")
        Me.colSegmentImage.Name = "colSegmentImage"
        Me.colSegmentImage.ReadOnly = True
        '
        'mnuSegments
        '
        resources.ApplyResources(Me.mnuSegments, "mnuSegments")
        Me.mnuSegments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSegmentsAdd, Me.mnuSegmentsInsert, Me.mnuSegmentsDelete, Me.ToolStripMenuItem76, Me.mnuSegmentsReverse, Me.ToolStripMenuItem47, Me.mnuSegmentsMoveUp, Me.mnuSegmentsMoveDown, Me.ToolStripMenuItem22, Me.mnuSegmentsCut, Me.mnuSegmentsCopy, Me.mnuSegmentsPaste, Me.ToolStripMenuItem23, Me.mnuSegmentsPrefixTrigpoints, Me.mnuSegmentsRenameTrigpoints, Me.mnuSegmentsReplicateData, Me.mnuSegmentsManageLRUD, Me.ToolStripMenuItem60, Me.mnuSegmentsTrigPoints, Me.ToolStripMenuItem65, Me.mnuSegmentsFind, Me.ToolStripMenuItem90, Me.mnuSegmentsExport, Me.ToolStripMenuItem73, Me.mnuSegmentsRefresh})
        Me.mnuSegments.Name = "mnuSegments"
        '
        'mnuSegmentsAdd
        '
        resources.ApplyResources(Me.mnuSegmentsAdd, "mnuSegmentsAdd")
        Me.mnuSegmentsAdd.Name = "mnuSegmentsAdd"
        '
        'mnuSegmentsInsert
        '
        Me.mnuSegmentsInsert.Name = "mnuSegmentsInsert"
        resources.ApplyResources(Me.mnuSegmentsInsert, "mnuSegmentsInsert")
        '
        'mnuSegmentsDelete
        '
        resources.ApplyResources(Me.mnuSegmentsDelete, "mnuSegmentsDelete")
        Me.mnuSegmentsDelete.Name = "mnuSegmentsDelete"
        '
        'ToolStripMenuItem76
        '
        Me.ToolStripMenuItem76.Name = "ToolStripMenuItem76"
        resources.ApplyResources(Me.ToolStripMenuItem76, "ToolStripMenuItem76")
        '
        'mnuSegmentsReverse
        '
        Me.mnuSegmentsReverse.Name = "mnuSegmentsReverse"
        resources.ApplyResources(Me.mnuSegmentsReverse, "mnuSegmentsReverse")
        '
        'ToolStripMenuItem47
        '
        Me.ToolStripMenuItem47.Name = "ToolStripMenuItem47"
        resources.ApplyResources(Me.ToolStripMenuItem47, "ToolStripMenuItem47")
        '
        'mnuSegmentsMoveUp
        '
        Me.mnuSegmentsMoveUp.Name = "mnuSegmentsMoveUp"
        resources.ApplyResources(Me.mnuSegmentsMoveUp, "mnuSegmentsMoveUp")
        '
        'mnuSegmentsMoveDown
        '
        Me.mnuSegmentsMoveDown.Name = "mnuSegmentsMoveDown"
        resources.ApplyResources(Me.mnuSegmentsMoveDown, "mnuSegmentsMoveDown")
        '
        'ToolStripMenuItem22
        '
        Me.ToolStripMenuItem22.Name = "ToolStripMenuItem22"
        resources.ApplyResources(Me.ToolStripMenuItem22, "ToolStripMenuItem22")
        '
        'mnuSegmentsCut
        '
        resources.ApplyResources(Me.mnuSegmentsCut, "mnuSegmentsCut")
        Me.mnuSegmentsCut.Name = "mnuSegmentsCut"
        '
        'mnuSegmentsCopy
        '
        resources.ApplyResources(Me.mnuSegmentsCopy, "mnuSegmentsCopy")
        Me.mnuSegmentsCopy.Name = "mnuSegmentsCopy"
        '
        'mnuSegmentsPaste
        '
        resources.ApplyResources(Me.mnuSegmentsPaste, "mnuSegmentsPaste")
        Me.mnuSegmentsPaste.Name = "mnuSegmentsPaste"
        '
        'ToolStripMenuItem23
        '
        Me.ToolStripMenuItem23.Name = "ToolStripMenuItem23"
        resources.ApplyResources(Me.ToolStripMenuItem23, "ToolStripMenuItem23")
        '
        'mnuSegmentsPrefixTrigpoints
        '
        resources.ApplyResources(Me.mnuSegmentsPrefixTrigpoints, "mnuSegmentsPrefixTrigpoints")
        Me.mnuSegmentsPrefixTrigpoints.Name = "mnuSegmentsPrefixTrigpoints"
        '
        'mnuSegmentsRenameTrigpoints
        '
        Me.mnuSegmentsRenameTrigpoints.Name = "mnuSegmentsRenameTrigpoints"
        resources.ApplyResources(Me.mnuSegmentsRenameTrigpoints, "mnuSegmentsRenameTrigpoints")
        '
        'mnuSegmentsReplicateData
        '
        Me.mnuSegmentsReplicateData.Name = "mnuSegmentsReplicateData"
        resources.ApplyResources(Me.mnuSegmentsReplicateData, "mnuSegmentsReplicateData")
        '
        'mnuSegmentsManageLRUD
        '
        Me.mnuSegmentsManageLRUD.Name = "mnuSegmentsManageLRUD"
        resources.ApplyResources(Me.mnuSegmentsManageLRUD, "mnuSegmentsManageLRUD")
        '
        'ToolStripMenuItem60
        '
        Me.ToolStripMenuItem60.Name = "ToolStripMenuItem60"
        resources.ApplyResources(Me.ToolStripMenuItem60, "ToolStripMenuItem60")
        '
        'mnuSegmentsTrigPoints
        '
        Me.mnuSegmentsTrigPoints.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSegmentsTrigPointsFrom, Me.mnuSegmentsTrigPointsTo})
        Me.mnuSegmentsTrigPoints.Name = "mnuSegmentsTrigPoints"
        resources.ApplyResources(Me.mnuSegmentsTrigPoints, "mnuSegmentsTrigPoints")
        '
        'mnuSegmentsTrigPointsFrom
        '
        Me.mnuSegmentsTrigPointsFrom.Name = "mnuSegmentsTrigPointsFrom"
        resources.ApplyResources(Me.mnuSegmentsTrigPointsFrom, "mnuSegmentsTrigPointsFrom")
        '
        'mnuSegmentsTrigPointsTo
        '
        Me.mnuSegmentsTrigPointsTo.Name = "mnuSegmentsTrigPointsTo"
        resources.ApplyResources(Me.mnuSegmentsTrigPointsTo, "mnuSegmentsTrigPointsTo")
        '
        'ToolStripMenuItem65
        '
        Me.ToolStripMenuItem65.Name = "ToolStripMenuItem65"
        resources.ApplyResources(Me.ToolStripMenuItem65, "ToolStripMenuItem65")
        '
        'mnuSegmentsFind
        '
        Me.mnuSegmentsFind.Name = "mnuSegmentsFind"
        resources.ApplyResources(Me.mnuSegmentsFind, "mnuSegmentsFind")
        '
        'ToolStripMenuItem90
        '
        Me.ToolStripMenuItem90.Name = "ToolStripMenuItem90"
        resources.ApplyResources(Me.ToolStripMenuItem90, "ToolStripMenuItem90")
        '
        'mnuSegmentsExport
        '
        Me.mnuSegmentsExport.Name = "mnuSegmentsExport"
        resources.ApplyResources(Me.mnuSegmentsExport, "mnuSegmentsExport")
        '
        'ToolStripMenuItem73
        '
        Me.ToolStripMenuItem73.Name = "ToolStripMenuItem73"
        resources.ApplyResources(Me.ToolStripMenuItem73, "ToolStripMenuItem73")
        '
        'mnuSegmentsRefresh
        '
        Me.mnuSegmentsRefresh.Name = "mnuSegmentsRefresh"
        resources.ApplyResources(Me.mnuSegmentsRefresh, "mnuSegmentsRefresh")
        '
        'pnlSegment
        '
        Me.pnlSegment.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSegment.Controls.Add(Me.tabSegmentProperty)
        Me.pnlSegment.Controls.Add(Me.pnlSegmentFromAndTo)
        Me.pnlSegment.Controls.Add(Me.pnlSegmentCaveBranches)
        Me.pnlSegment.Controls.Add(Me.pnlSegmentSession)
        resources.ApplyResources(Me.pnlSegment, "pnlSegment")
        Me.pnlSegment.Name = "pnlSegment"
        '
        'tabSegmentProperty
        '
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyMain)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyData)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyLayout)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyNote)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyImage)
        resources.ApplyResources(Me.tabSegmentProperty, "tabSegmentProperty")
        Me.tabSegmentProperty.ImageList = Me.iml
        Me.tabSegmentProperty.Name = "tabSegmentProperty"
        Me.tabSegmentProperty.SelectedIndex = 0
        '
        'tabSegmentPropertyMain
        '
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentCalibration)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentCutSplay)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentZSurvey)
        Me.tabSegmentPropertyMain.Controls.Add(Me.pnlSegmentSurfaceProfile)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentVirtual)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentUnbindable)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentSurface)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentDuplicate)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentSplay)
        Me.tabSegmentPropertyMain.Controls.Add(Me.cboSegmentDirection)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentRight)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentUp)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentLeft)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentExclude)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentBearing)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentDown)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentDx)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentDistance)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentTop)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentDistance)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentSx)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentBearing)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentBottom)
        Me.tabSegmentPropertyMain.Controls.Add(Me.txtSegmentInclination)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentInclination)
        Me.tabSegmentPropertyMain.Controls.Add(Me.lblSegmentDirection)
        Me.tabSegmentPropertyMain.Controls.Add(Me.chkSegmentInverted)
        resources.ApplyResources(Me.tabSegmentPropertyMain, "tabSegmentPropertyMain")
        Me.tabSegmentPropertyMain.Name = "tabSegmentPropertyMain"
        Me.tabSegmentPropertyMain.UseVisualStyleBackColor = True
        '
        'chkSegmentCalibration
        '
        resources.ApplyResources(Me.chkSegmentCalibration, "chkSegmentCalibration")
        Me.chkSegmentCalibration.Name = "chkSegmentCalibration"
        Me.tipDefault.SetToolTip(Me.chkSegmentCalibration, resources.GetString("chkSegmentCalibration.ToolTip"))
        Me.chkSegmentCalibration.UseVisualStyleBackColor = True
        '
        'chkSegmentCutSplay
        '
        resources.ApplyResources(Me.chkSegmentCutSplay, "chkSegmentCutSplay")
        Me.chkSegmentCutSplay.Name = "chkSegmentCutSplay"
        Me.tipDefault.SetToolTip(Me.chkSegmentCutSplay, resources.GetString("chkSegmentCutSplay.ToolTip"))
        Me.chkSegmentCutSplay.UseVisualStyleBackColor = True
        '
        'chkSegmentZSurvey
        '
        resources.ApplyResources(Me.chkSegmentZSurvey, "chkSegmentZSurvey")
        Me.chkSegmentZSurvey.Name = "chkSegmentZSurvey"
        Me.tipDefault.SetToolTip(Me.chkSegmentZSurvey, resources.GetString("chkSegmentZSurvey.ToolTip"))
        Me.chkSegmentZSurvey.UseVisualStyleBackColor = True
        '
        'pnlSegmentSurfaceProfile
        '
        Me.pnlSegmentSurfaceProfile.Controls.Add(Me.lblSegmentSurfaceProfile)
        Me.pnlSegmentSurfaceProfile.Controls.Add(Me.cboSegmentSurfaceProfileShow)
        Me.pnlSegmentSurfaceProfile.Controls.Add(Me.lblSegmentSurfaceProfileShow)
        resources.ApplyResources(Me.pnlSegmentSurfaceProfile, "pnlSegmentSurfaceProfile")
        Me.pnlSegmentSurfaceProfile.Name = "pnlSegmentSurfaceProfile"
        '
        'lblSegmentSurfaceProfile
        '
        resources.ApplyResources(Me.lblSegmentSurfaceProfile, "lblSegmentSurfaceProfile")
        Me.lblSegmentSurfaceProfile.Name = "lblSegmentSurfaceProfile"
        '
        'cboSegmentSurfaceProfileShow
        '
        Me.cboSegmentSurfaceProfileShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentSurfaceProfileShow.DropDownWidth = 320
        Me.cboSegmentSurfaceProfileShow.FormattingEnabled = True
        Me.cboSegmentSurfaceProfileShow.Items.AddRange(New Object() {resources.GetString("cboSegmentSurfaceProfileShow.Items"), resources.GetString("cboSegmentSurfaceProfileShow.Items1"), resources.GetString("cboSegmentSurfaceProfileShow.Items2")})
        resources.ApplyResources(Me.cboSegmentSurfaceProfileShow, "cboSegmentSurfaceProfileShow")
        Me.cboSegmentSurfaceProfileShow.Name = "cboSegmentSurfaceProfileShow"
        '
        'lblSegmentSurfaceProfileShow
        '
        resources.ApplyResources(Me.lblSegmentSurfaceProfileShow, "lblSegmentSurfaceProfileShow")
        Me.lblSegmentSurfaceProfileShow.Name = "lblSegmentSurfaceProfileShow"
        '
        'chkSegmentVirtual
        '
        resources.ApplyResources(Me.chkSegmentVirtual, "chkSegmentVirtual")
        Me.chkSegmentVirtual.Name = "chkSegmentVirtual"
        Me.chkSegmentVirtual.UseVisualStyleBackColor = True
        '
        'chkSegmentUnbindable
        '
        resources.ApplyResources(Me.chkSegmentUnbindable, "chkSegmentUnbindable")
        Me.chkSegmentUnbindable.Name = "chkSegmentUnbindable"
        Me.tipDefault.SetToolTip(Me.chkSegmentUnbindable, resources.GetString("chkSegmentUnbindable.ToolTip"))
        Me.chkSegmentUnbindable.UseVisualStyleBackColor = True
        '
        'chkSegmentSurface
        '
        resources.ApplyResources(Me.chkSegmentSurface, "chkSegmentSurface")
        Me.chkSegmentSurface.Name = "chkSegmentSurface"
        Me.tipDefault.SetToolTip(Me.chkSegmentSurface, resources.GetString("chkSegmentSurface.ToolTip"))
        Me.chkSegmentSurface.UseVisualStyleBackColor = True
        '
        'chkSegmentDuplicate
        '
        resources.ApplyResources(Me.chkSegmentDuplicate, "chkSegmentDuplicate")
        Me.chkSegmentDuplicate.Name = "chkSegmentDuplicate"
        Me.tipDefault.SetToolTip(Me.chkSegmentDuplicate, resources.GetString("chkSegmentDuplicate.ToolTip"))
        Me.chkSegmentDuplicate.UseVisualStyleBackColor = True
        '
        'chkSegmentSplay
        '
        resources.ApplyResources(Me.chkSegmentSplay, "chkSegmentSplay")
        Me.chkSegmentSplay.Name = "chkSegmentSplay"
        Me.tipDefault.SetToolTip(Me.chkSegmentSplay, resources.GetString("chkSegmentSplay.ToolTip"))
        Me.chkSegmentSplay.UseVisualStyleBackColor = True
        '
        'cboSegmentDirection
        '
        Me.cboSegmentDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentDirection.DropDownWidth = 320
        Me.cboSegmentDirection.FormattingEnabled = True
        Me.cboSegmentDirection.Items.AddRange(New Object() {resources.GetString("cboSegmentDirection.Items"), resources.GetString("cboSegmentDirection.Items1")})
        resources.ApplyResources(Me.cboSegmentDirection, "cboSegmentDirection")
        Me.cboSegmentDirection.Name = "cboSegmentDirection"
        Me.tipDefault.SetToolTip(Me.cboSegmentDirection, resources.GetString("cboSegmentDirection.ToolTip"))
        '
        'txtSegmentRight
        '
        resources.ApplyResources(Me.txtSegmentRight, "txtSegmentRight")
        Me.txtSegmentRight.Name = "txtSegmentRight"
        '
        'txtSegmentUp
        '
        resources.ApplyResources(Me.txtSegmentUp, "txtSegmentUp")
        Me.txtSegmentUp.Name = "txtSegmentUp"
        '
        'txtSegmentLeft
        '
        resources.ApplyResources(Me.txtSegmentLeft, "txtSegmentLeft")
        Me.txtSegmentLeft.Name = "txtSegmentLeft"
        '
        'chkSegmentExclude
        '
        resources.ApplyResources(Me.chkSegmentExclude, "chkSegmentExclude")
        Me.chkSegmentExclude.Name = "chkSegmentExclude"
        Me.chkSegmentExclude.UseVisualStyleBackColor = True
        '
        'txtSegmentBearing
        '
        resources.ApplyResources(Me.txtSegmentBearing, "txtSegmentBearing")
        Me.txtSegmentBearing.Name = "txtSegmentBearing"
        Me.tipDefault.SetToolTip(Me.txtSegmentBearing, resources.GetString("txtSegmentBearing.ToolTip"))
        '
        'txtSegmentDown
        '
        resources.ApplyResources(Me.txtSegmentDown, "txtSegmentDown")
        Me.txtSegmentDown.Name = "txtSegmentDown"
        '
        'lblSegmentDx
        '
        resources.ApplyResources(Me.lblSegmentDx, "lblSegmentDx")
        Me.lblSegmentDx.Name = "lblSegmentDx"
        '
        'txtSegmentDistance
        '
        resources.ApplyResources(Me.txtSegmentDistance, "txtSegmentDistance")
        Me.txtSegmentDistance.Name = "txtSegmentDistance"
        Me.tipDefault.SetToolTip(Me.txtSegmentDistance, resources.GetString("txtSegmentDistance.ToolTip"))
        '
        'lblSegmentTop
        '
        resources.ApplyResources(Me.lblSegmentTop, "lblSegmentTop")
        Me.lblSegmentTop.Name = "lblSegmentTop"
        '
        'lblSegmentDistance
        '
        resources.ApplyResources(Me.lblSegmentDistance, "lblSegmentDistance")
        Me.lblSegmentDistance.Name = "lblSegmentDistance"
        '
        'lblSegmentSx
        '
        resources.ApplyResources(Me.lblSegmentSx, "lblSegmentSx")
        Me.lblSegmentSx.Name = "lblSegmentSx"
        '
        'lblSegmentBearing
        '
        resources.ApplyResources(Me.lblSegmentBearing, "lblSegmentBearing")
        Me.lblSegmentBearing.Name = "lblSegmentBearing"
        '
        'lblSegmentBottom
        '
        resources.ApplyResources(Me.lblSegmentBottom, "lblSegmentBottom")
        Me.lblSegmentBottom.Name = "lblSegmentBottom"
        '
        'txtSegmentInclination
        '
        resources.ApplyResources(Me.txtSegmentInclination, "txtSegmentInclination")
        Me.txtSegmentInclination.Name = "txtSegmentInclination"
        Me.tipDefault.SetToolTip(Me.txtSegmentInclination, resources.GetString("txtSegmentInclination.ToolTip"))
        '
        'lblSegmentInclination
        '
        resources.ApplyResources(Me.lblSegmentInclination, "lblSegmentInclination")
        Me.lblSegmentInclination.Name = "lblSegmentInclination"
        '
        'lblSegmentDirection
        '
        resources.ApplyResources(Me.lblSegmentDirection, "lblSegmentDirection")
        Me.lblSegmentDirection.Name = "lblSegmentDirection"
        '
        'chkSegmentInverted
        '
        resources.ApplyResources(Me.chkSegmentInverted, "chkSegmentInverted")
        Me.chkSegmentInverted.Name = "chkSegmentInverted"
        '
        'tabSegmentPropertyData
        '
        Me.tabSegmentPropertyData.Controls.Add(Me.prpSegmentDataProperties)
        resources.ApplyResources(Me.tabSegmentPropertyData, "tabSegmentPropertyData")
        Me.tabSegmentPropertyData.Name = "tabSegmentPropertyData"
        Me.tabSegmentPropertyData.UseVisualStyleBackColor = True
        '
        'prpSegmentDataProperties
        '
        Me.prpSegmentDataProperties.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.prpSegmentDataProperties.CommandsVisibleIfAvailable = False
        Me.prpSegmentDataProperties.ContextMenuStrip = Me.mnuSegmentsDataProperties
        resources.ApplyResources(Me.prpSegmentDataProperties, "prpSegmentDataProperties")
        Me.prpSegmentDataProperties.LineColor = System.Drawing.SystemColors.ControlDark
        Me.prpSegmentDataProperties.Name = "prpSegmentDataProperties"
        Me.prpSegmentDataProperties.ToolbarVisible = False
        '
        'mnuSegmentsDataProperties
        '
        resources.ApplyResources(Me.mnuSegmentsDataProperties, "mnuSegmentsDataProperties")
        Me.mnuSegmentsDataProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSegmentsDataPropertiesEdit, Me.ToolStripMenuItem91, Me.mnuSegmentsDataPropertiesDelete})
        Me.mnuSegmentsDataProperties.Name = "mnuSegmentsDataFields"
        '
        'mnuSegmentsDataPropertiesEdit
        '
        Me.mnuSegmentsDataPropertiesEdit.Name = "mnuSegmentsDataPropertiesEdit"
        resources.ApplyResources(Me.mnuSegmentsDataPropertiesEdit, "mnuSegmentsDataPropertiesEdit")
        '
        'ToolStripMenuItem91
        '
        Me.ToolStripMenuItem91.Name = "ToolStripMenuItem91"
        resources.ApplyResources(Me.ToolStripMenuItem91, "ToolStripMenuItem91")
        '
        'mnuSegmentsDataPropertiesDelete
        '
        resources.ApplyResources(Me.mnuSegmentsDataPropertiesDelete, "mnuSegmentsDataPropertiesDelete")
        Me.mnuSegmentsDataPropertiesDelete.Name = "mnuSegmentsDataPropertiesDelete"
        '
        'tabSegmentPropertyLayout
        '
        Me.tabSegmentPropertyLayout.Controls.Add(Me.cmdSegmentColorChange)
        Me.tabSegmentPropertyLayout.Controls.Add(Me.cmdSegmentColorReset)
        Me.tabSegmentPropertyLayout.Controls.Add(Me.picSegmentColor)
        Me.tabSegmentPropertyLayout.Controls.Add(Me.lblSegmentColor)
        resources.ApplyResources(Me.tabSegmentPropertyLayout, "tabSegmentPropertyLayout")
        Me.tabSegmentPropertyLayout.Name = "tabSegmentPropertyLayout"
        Me.tabSegmentPropertyLayout.UseVisualStyleBackColor = True
        '
        'cmdSegmentColorChange
        '
        resources.ApplyResources(Me.cmdSegmentColorChange, "cmdSegmentColorChange")
        Me.cmdSegmentColorChange.Name = "cmdSegmentColorChange"
        Me.cmdSegmentColorChange.UseVisualStyleBackColor = True
        '
        'cmdSegmentColorReset
        '
        resources.ApplyResources(Me.cmdSegmentColorReset, "cmdSegmentColorReset")
        Me.cmdSegmentColorReset.Name = "cmdSegmentColorReset"
        Me.tipDefault.SetToolTip(Me.cmdSegmentColorReset, resources.GetString("cmdSegmentColorReset.ToolTip"))
        Me.cmdSegmentColorReset.UseVisualStyleBackColor = True
        '
        'picSegmentColor
        '
        resources.ApplyResources(Me.picSegmentColor, "picSegmentColor")
        Me.picSegmentColor.Name = "picSegmentColor"
        Me.picSegmentColor.TabStop = False
        '
        'lblSegmentColor
        '
        resources.ApplyResources(Me.lblSegmentColor, "lblSegmentColor")
        Me.lblSegmentColor.Name = "lblSegmentColor"
        '
        'tabSegmentPropertyNote
        '
        Me.tabSegmentPropertyNote.Controls.Add(Me.txtSegmentNote)
        resources.ApplyResources(Me.tabSegmentPropertyNote, "tabSegmentPropertyNote")
        Me.tabSegmentPropertyNote.Name = "tabSegmentPropertyNote"
        Me.tabSegmentPropertyNote.UseVisualStyleBackColor = True
        '
        'txtSegmentNote
        '
        resources.ApplyResources(Me.txtSegmentNote, "txtSegmentNote")
        Me.txtSegmentNote.Name = "txtSegmentNote"
        '
        'tabSegmentPropertyImage
        '
        Me.tabSegmentPropertyImage.Controls.Add(Me.tvSegmentAttachments)
        resources.ApplyResources(Me.tabSegmentPropertyImage, "tabSegmentPropertyImage")
        Me.tabSegmentPropertyImage.Name = "tabSegmentPropertyImage"
        Me.tabSegmentPropertyImage.UseVisualStyleBackColor = True
        '
        'tvSegmentAttachments
        '
        Me.tvSegmentAttachments.AllColumns.Add(Me.colAttachmentIcon)
        Me.tvSegmentAttachments.AllColumns.Add(Me.colAttachmentType)
        Me.tvSegmentAttachments.AllColumns.Add(Me.colAttachmentName)
        Me.tvSegmentAttachments.AllColumns.Add(Me.colAttachmentNote)
        Me.tvSegmentAttachments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvSegmentAttachments.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only
        Me.tvSegmentAttachments.CellEditUseWholeCell = False
        Me.tvSegmentAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colAttachmentIcon, Me.colAttachmentName, Me.colAttachmentNote})
        Me.tvSegmentAttachments.ContextMenuStrip = Me.mnuAttachments
        Me.tvSegmentAttachments.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.tvSegmentAttachments, "tvSegmentAttachments")
        Me.tvSegmentAttachments.FullRowSelect = True
        Me.tvSegmentAttachments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.tvSegmentAttachments.HideSelection = False
        Me.tvSegmentAttachments.MultiSelect = False
        Me.tvSegmentAttachments.Name = "tvSegmentAttachments"
        Me.tvSegmentAttachments.RowHeight = 32
        Me.tvSegmentAttachments.ShowGroups = False
        Me.tvSegmentAttachments.ShowImagesOnSubItems = True
        Me.tvSegmentAttachments.UseCompatibleStateImageBehavior = False
        Me.tvSegmentAttachments.View = System.Windows.Forms.View.Details
        Me.tvSegmentAttachments.VirtualMode = True
        '
        'colAttachmentIcon
        '
        Me.colAttachmentIcon.IsEditable = False
        Me.colAttachmentIcon.MaximumWidth = 36
        Me.colAttachmentIcon.MinimumWidth = 36
        resources.ApplyResources(Me.colAttachmentIcon, "colAttachmentIcon")
        '
        'colAttachmentType
        '
        resources.ApplyResources(Me.colAttachmentType, "colAttachmentType")
        Me.colAttachmentType.IsEditable = False
        Me.colAttachmentType.IsVisible = False
        '
        'colAttachmentName
        '
        resources.ApplyResources(Me.colAttachmentName, "colAttachmentName")
        Me.colAttachmentName.WordWrap = True
        '
        'colAttachmentNote
        '
        resources.ApplyResources(Me.colAttachmentNote, "colAttachmentNote")
        Me.colAttachmentNote.WordWrap = True
        '
        'mnuAttachments
        '
        resources.ApplyResources(Me.mnuAttachments, "mnuAttachments")
        Me.mnuAttachments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAttachmentsOpen, Me.ToolStripMenuItem84, Me.mnuAttachmentsAdd, Me.ToolStripMenuItem66, Me.mnuAttachmentsDelete, Me.mnuAttachmentsDeleteAll})
        Me.mnuAttachments.Name = "mnuSegmentAttachments"
        '
        'mnuAttachmentsOpen
        '
        Me.mnuAttachmentsOpen.Name = "mnuAttachmentsOpen"
        resources.ApplyResources(Me.mnuAttachmentsOpen, "mnuAttachmentsOpen")
        '
        'ToolStripMenuItem84
        '
        Me.ToolStripMenuItem84.Name = "ToolStripMenuItem84"
        resources.ApplyResources(Me.ToolStripMenuItem84, "ToolStripMenuItem84")
        '
        'mnuAttachmentsAdd
        '
        Me.mnuAttachmentsAdd.Name = "mnuAttachmentsAdd"
        resources.ApplyResources(Me.mnuAttachmentsAdd, "mnuAttachmentsAdd")
        '
        'ToolStripMenuItem66
        '
        Me.ToolStripMenuItem66.Name = "ToolStripMenuItem66"
        resources.ApplyResources(Me.ToolStripMenuItem66, "ToolStripMenuItem66")
        '
        'mnuAttachmentsDelete
        '
        Me.mnuAttachmentsDelete.Name = "mnuAttachmentsDelete"
        resources.ApplyResources(Me.mnuAttachmentsDelete, "mnuAttachmentsDelete")
        '
        'mnuAttachmentsDeleteAll
        '
        Me.mnuAttachmentsDeleteAll.Name = "mnuAttachmentsDeleteAll"
        resources.ApplyResources(Me.mnuAttachmentsDeleteAll, "mnuAttachmentsDeleteAll")
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "database.png")
        Me.iml.Images.SetKeyName(1, "paintbrush.png")
        Me.iml.Images.SetKeyName(2, "note.png")
        Me.iml.Images.SetKeyName(3, "calculator.png")
        Me.iml.Images.SetKeyName(4, "map.png")
        Me.iml.Images.SetKeyName(5, "font.png")
        Me.iml.Images.SetKeyName(6, "image.png")
        Me.iml.Images.SetKeyName(7, "link.png")
        Me.iml.Images.SetKeyName(8, "layer.png")
        Me.iml.Images.SetKeyName(9, "cross.png")
        Me.iml.Images.SetKeyName(10, "generic.png")
        Me.iml.Images.SetKeyName(11, "generic_error.png")
        Me.iml.Images.SetKeyName(12, "database_user.png")
        Me.iml.Images.SetKeyName(13, "layer_histogram.png")
        Me.iml.Images.SetKeyName(14, "layer_gps.png")
        Me.iml.Images.SetKeyName(15, "layer_wms.png")
        Me.iml.Images.SetKeyName(16, "layer_raster.png")
        Me.iml.Images.SetKeyName(17, "layer_vector.png")
        Me.iml.Images.SetKeyName(18, "layers.png")
        Me.iml.Images.SetKeyName(19, "page_white_wrench.png")
        Me.iml.Images.SetKeyName(20, "attach.png")
        '
        'pnlSegmentFromAndTo
        '
        Me.pnlSegmentFromAndTo.Controls.Add(Me.cboSegmentFrom)
        Me.pnlSegmentFromAndTo.Controls.Add(Me.lblSegmentFrom)
        Me.pnlSegmentFromAndTo.Controls.Add(Me.cboSegmentTo)
        Me.pnlSegmentFromAndTo.Controls.Add(Me.lblSegmentTo)
        resources.ApplyResources(Me.pnlSegmentFromAndTo, "pnlSegmentFromAndTo")
        Me.pnlSegmentFromAndTo.Name = "pnlSegmentFromAndTo"
        '
        'cboSegmentFrom
        '
        Me.cboSegmentFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSegmentFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentFrom.DropDownWidth = 180
        resources.ApplyResources(Me.cboSegmentFrom, "cboSegmentFrom")
        Me.cboSegmentFrom.Name = "cboSegmentFrom"
        Me.tipDefault.SetToolTip(Me.cboSegmentFrom, resources.GetString("cboSegmentFrom.ToolTip"))
        '
        'lblSegmentFrom
        '
        resources.ApplyResources(Me.lblSegmentFrom, "lblSegmentFrom")
        Me.lblSegmentFrom.Name = "lblSegmentFrom"
        '
        'cboSegmentTo
        '
        Me.cboSegmentTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSegmentTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentTo.DropDownWidth = 180
        resources.ApplyResources(Me.cboSegmentTo, "cboSegmentTo")
        Me.cboSegmentTo.Name = "cboSegmentTo"
        Me.tipDefault.SetToolTip(Me.cboSegmentTo, resources.GetString("cboSegmentTo.ToolTip"))
        '
        'lblSegmentTo
        '
        resources.ApplyResources(Me.lblSegmentTo, "lblSegmentTo")
        Me.lblSegmentTo.Name = "lblSegmentTo"
        '
        'pnlSegmentCaveBranches
        '
        Me.pnlSegmentCaveBranches.Controls.Add(Me.pnlSegmentCaveBranchesColor)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.cboSegmentCaveBranchList)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.lblSegmentCave)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.lblSegmentBranch)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.cboSegmentCaveList)
        resources.ApplyResources(Me.pnlSegmentCaveBranches, "pnlSegmentCaveBranches")
        Me.pnlSegmentCaveBranches.Name = "pnlSegmentCaveBranches"
        '
        'pnlSegmentCaveBranchesColor
        '
        resources.ApplyResources(Me.pnlSegmentCaveBranchesColor, "pnlSegmentCaveBranchesColor")
        Me.pnlSegmentCaveBranchesColor.Name = "pnlSegmentCaveBranchesColor"
        '
        'cboSegmentCaveBranchList
        '
        resources.ApplyResources(Me.cboSegmentCaveBranchList, "cboSegmentCaveBranchList")
        Me.cboSegmentCaveBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentCaveBranchList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSegmentCaveBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentCaveBranchList.DropDownWidth = 420
        Me.cboSegmentCaveBranchList.Name = "cboSegmentCaveBranchList"
        Me.cboSegmentCaveBranchList.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'lblSegmentCave
        '
        resources.ApplyResources(Me.lblSegmentCave, "lblSegmentCave")
        Me.lblSegmentCave.Name = "lblSegmentCave"
        '
        'lblSegmentBranch
        '
        resources.ApplyResources(Me.lblSegmentBranch, "lblSegmentBranch")
        Me.lblSegmentBranch.Name = "lblSegmentBranch"
        '
        'cboSegmentCaveList
        '
        resources.ApplyResources(Me.cboSegmentCaveList, "cboSegmentCaveList")
        Me.cboSegmentCaveList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentCaveList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSegmentCaveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentCaveList.DropDownWidth = 420
        Me.cboSegmentCaveList.Name = "cboSegmentCaveList"
        Me.cboSegmentCaveList.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'pnlSegmentSession
        '
        Me.pnlSegmentSession.Controls.Add(Me.pnlSegmentSessionColor)
        Me.pnlSegmentSession.Controls.Add(Me.cboSessionList)
        Me.pnlSegmentSession.Controls.Add(Me.lblSession)
        resources.ApplyResources(Me.pnlSegmentSession, "pnlSegmentSession")
        Me.pnlSegmentSession.Name = "pnlSegmentSession"
        '
        'pnlSegmentSessionColor
        '
        resources.ApplyResources(Me.pnlSegmentSessionColor, "pnlSegmentSessionColor")
        Me.pnlSegmentSessionColor.Name = "pnlSegmentSessionColor"
        '
        'cboSessionList
        '
        resources.ApplyResources(Me.cboSessionList, "cboSessionList")
        Me.cboSessionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSessionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSessionList.DropDownWidth = 420
        Me.cboSessionList.Name = "cboSessionList"
        '
        'lblSession
        '
        resources.ApplyResources(Me.lblSession, "lblSession")
        Me.lblSession.Name = "lblSession"
        '
        'spTrigPoints
        '
        Me.spTrigPoints.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.spTrigPoints, "spTrigPoints")
        Me.spTrigPoints.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.spTrigPoints.Name = "spTrigPoints"
        '
        'spTrigPoints.Panel1
        '
        Me.spTrigPoints.Panel1.Controls.Add(Me.grdTrigPoints)
        '
        'spTrigPoints.Panel2
        '
        Me.spTrigPoints.Panel2.Controls.Add(Me.pnlTrigPoint)
        '
        'grdTrigPoints
        '
        Me.grdTrigPoints.AllowUserToAddRows = False
        Me.grdTrigPoints.AllowUserToDeleteRows = False
        Me.grdTrigPoints.AllowUserToResizeRows = False
        Me.grdTrigPoints.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grdTrigPoints.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTrigPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTrigPoints.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTrigPoint, Me.colX, Me.colY, Me.colZ, Me.colGPS, Me.colNote, Me.colGeoLat, Me.colGeoLon, Me.colGeoAlt})
        Me.grdTrigPoints.ContextMenuStrip = Me.mnuTrigPoints
        resources.ApplyResources(Me.grdTrigPoints, "grdTrigPoints")
        Me.grdTrigPoints.GridColor = System.Drawing.SystemColors.ControlLight
        Me.grdTrigPoints.MultiSelect = False
        Me.grdTrigPoints.Name = "grdTrigPoints"
        '
        'colTrigPoint
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colTrigPoint.DefaultCellStyle = DataGridViewCellStyle12
        resources.ApplyResources(Me.colTrigPoint, "colTrigPoint")
        Me.colTrigPoint.Name = "colTrigPoint"
        Me.colTrigPoint.ReadOnly = True
        Me.colTrigPoint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colX
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N3"
        Me.colX.DefaultCellStyle = DataGridViewCellStyle13
        resources.ApplyResources(Me.colX, "colX")
        Me.colX.Name = "colX"
        Me.colX.ReadOnly = True
        Me.colX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colY
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N3"
        Me.colY.DefaultCellStyle = DataGridViewCellStyle14
        resources.ApplyResources(Me.colY, "colY")
        Me.colY.Name = "colY"
        Me.colY.ReadOnly = True
        Me.colY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colZ
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N3"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colZ.DefaultCellStyle = DataGridViewCellStyle15
        resources.ApplyResources(Me.colZ, "colZ")
        Me.colZ.Name = "colZ"
        Me.colZ.ReadOnly = True
        Me.colZ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colGPS
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colGPS.DefaultCellStyle = DataGridViewCellStyle16
        resources.ApplyResources(Me.colGPS, "colGPS")
        Me.colGPS.Name = "colGPS"
        Me.colGPS.ReadOnly = True
        '
        'colNote
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colNote.DefaultCellStyle = DataGridViewCellStyle17
        resources.ApplyResources(Me.colNote, "colNote")
        Me.colNote.Name = "colNote"
        Me.colNote.ReadOnly = True
        '
        'colGeoLat
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colGeoLat.DefaultCellStyle = DataGridViewCellStyle18
        resources.ApplyResources(Me.colGeoLat, "colGeoLat")
        Me.colGeoLat.Name = "colGeoLat"
        Me.colGeoLat.ReadOnly = True
        '
        'colGeoLon
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colGeoLon.DefaultCellStyle = DataGridViewCellStyle19
        resources.ApplyResources(Me.colGeoLon, "colGeoLon")
        Me.colGeoLon.Name = "colGeoLon"
        Me.colGeoLon.ReadOnly = True
        '
        'colGeoAlt
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colGeoAlt.DefaultCellStyle = DataGridViewCellStyle20
        resources.ApplyResources(Me.colGeoAlt, "colGeoAlt")
        Me.colGeoAlt.Name = "colGeoAlt"
        Me.colGeoAlt.ReadOnly = True
        '
        'mnuTrigPoints
        '
        resources.ApplyResources(Me.mnuTrigPoints, "mnuTrigPoints")
        Me.mnuTrigPoints.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrigPointsRebind, Me.mnuTrigPointsRemoveOrphans, Me.ToolStripMenuItem42, Me.mnuTrigPointsEntrance, Me.ToolStripMenuItem43, Me.mnuTrigPointsPrefixTrigpoints, Me.mnuTrigPointsRenameTrigpoints, Me.ToolStripMenuItem52, Me.mnuTrigPointsFind, Me.ToolStripMenuItem102, Me.mnuTrigPointsExport})
        Me.mnuTrigPoints.Name = "mnuTrigPoints"
        '
        'mnuTrigPointsRebind
        '
        Me.mnuTrigPointsRebind.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.mnuTrigPointsRebind, "mnuTrigPointsRebind")
        Me.mnuTrigPointsRebind.Name = "mnuTrigPointsRebind"
        '
        'mnuTrigPointsRemoveOrphans
        '
        Me.mnuTrigPointsRemoveOrphans.Name = "mnuTrigPointsRemoveOrphans"
        resources.ApplyResources(Me.mnuTrigPointsRemoveOrphans, "mnuTrigPointsRemoveOrphans")
        '
        'ToolStripMenuItem42
        '
        Me.ToolStripMenuItem42.Name = "ToolStripMenuItem42"
        resources.ApplyResources(Me.ToolStripMenuItem42, "ToolStripMenuItem42")
        '
        'mnuTrigPointsEntrance
        '
        Me.mnuTrigPointsEntrance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrigPointsEntrance0, Me.mnuTrigPointsEntrance1, Me.mnuTrigPointsEntrance2, Me.mnuTrigPointsEntrance3, Me.mnuTrigPointsEntrance4})
        Me.mnuTrigPointsEntrance.Name = "mnuTrigPointsEntrance"
        resources.ApplyResources(Me.mnuTrigPointsEntrance, "mnuTrigPointsEntrance")
        '
        'mnuTrigPointsEntrance0
        '
        Me.mnuTrigPointsEntrance0.Name = "mnuTrigPointsEntrance0"
        resources.ApplyResources(Me.mnuTrigPointsEntrance0, "mnuTrigPointsEntrance0")
        '
        'mnuTrigPointsEntrance1
        '
        Me.mnuTrigPointsEntrance1.Name = "mnuTrigPointsEntrance1"
        resources.ApplyResources(Me.mnuTrigPointsEntrance1, "mnuTrigPointsEntrance1")
        '
        'mnuTrigPointsEntrance2
        '
        Me.mnuTrigPointsEntrance2.Name = "mnuTrigPointsEntrance2"
        resources.ApplyResources(Me.mnuTrigPointsEntrance2, "mnuTrigPointsEntrance2")
        '
        'mnuTrigPointsEntrance3
        '
        Me.mnuTrigPointsEntrance3.Name = "mnuTrigPointsEntrance3"
        resources.ApplyResources(Me.mnuTrigPointsEntrance3, "mnuTrigPointsEntrance3")
        '
        'mnuTrigPointsEntrance4
        '
        Me.mnuTrigPointsEntrance4.Name = "mnuTrigPointsEntrance4"
        resources.ApplyResources(Me.mnuTrigPointsEntrance4, "mnuTrigPointsEntrance4")
        '
        'ToolStripMenuItem43
        '
        Me.ToolStripMenuItem43.Name = "ToolStripMenuItem43"
        resources.ApplyResources(Me.ToolStripMenuItem43, "ToolStripMenuItem43")
        '
        'mnuTrigPointsPrefixTrigpoints
        '
        Me.mnuTrigPointsPrefixTrigpoints.Name = "mnuTrigPointsPrefixTrigpoints"
        resources.ApplyResources(Me.mnuTrigPointsPrefixTrigpoints, "mnuTrigPointsPrefixTrigpoints")
        '
        'mnuTrigPointsRenameTrigpoints
        '
        Me.mnuTrigPointsRenameTrigpoints.Name = "mnuTrigPointsRenameTrigpoints"
        resources.ApplyResources(Me.mnuTrigPointsRenameTrigpoints, "mnuTrigPointsRenameTrigpoints")
        '
        'ToolStripMenuItem52
        '
        Me.ToolStripMenuItem52.Name = "ToolStripMenuItem52"
        resources.ApplyResources(Me.ToolStripMenuItem52, "ToolStripMenuItem52")
        '
        'mnuTrigPointsFind
        '
        Me.mnuTrigPointsFind.Name = "mnuTrigPointsFind"
        resources.ApplyResources(Me.mnuTrigPointsFind, "mnuTrigPointsFind")
        '
        'ToolStripMenuItem102
        '
        Me.ToolStripMenuItem102.Name = "ToolStripMenuItem102"
        resources.ApplyResources(Me.ToolStripMenuItem102, "ToolStripMenuItem102")
        '
        'mnuTrigPointsExport
        '
        Me.mnuTrigPointsExport.Name = "mnuTrigPointsExport"
        resources.ApplyResources(Me.mnuTrigPointsExport, "mnuTrigPointsExport")
        '
        'pnlTrigPoint
        '
        Me.pnlTrigPoint.Controls.Add(Me.tabTrigpointProperty)
        Me.pnlTrigPoint.Controls.Add(Me.pnlTrigpointName)
        resources.ApplyResources(Me.pnlTrigPoint, "pnlTrigPoint")
        Me.pnlTrigPoint.Name = "pnlTrigPoint"
        '
        'tabTrigpointProperty
        '
        Me.tabTrigpointProperty.Controls.Add(Me.tabTrigpointMain)
        Me.tabTrigpointProperty.Controls.Add(Me.tabTrigpointPropertyData)
        Me.tabTrigpointProperty.Controls.Add(Me.tabTrigpointLayout)
        Me.tabTrigpointProperty.Controls.Add(Me.tabTrigpointConnections)
        Me.tabTrigpointProperty.Controls.Add(Me.tabTrigpointCoordinate)
        Me.tabTrigpointProperty.Controls.Add(Me.tabTrigpointNote)
        resources.ApplyResources(Me.tabTrigpointProperty, "tabTrigpointProperty")
        Me.tabTrigpointProperty.ImageList = Me.iml
        Me.tabTrigpointProperty.Name = "tabTrigpointProperty"
        Me.tabTrigpointProperty.SelectedIndex = 0
        '
        'tabTrigpointMain
        '
        Me.tabTrigpointMain.Controls.Add(Me.chkTrigpointZTurn)
        Me.tabTrigpointMain.Controls.Add(Me.chkTrigpointIsInExploration)
        Me.tabTrigpointMain.Controls.Add(Me.chkTrigpointShowEntrance)
        Me.tabTrigpointMain.Controls.Add(Me.grdTrigPointAliases)
        Me.tabTrigpointMain.Controls.Add(Me.cboTrigPointType)
        Me.tabTrigpointMain.Controls.Add(Me.chkTrigpointIsSpecial)
        Me.tabTrigpointMain.Controls.Add(Me.lblTrigpointType)
        Me.tabTrigpointMain.Controls.Add(Me.cboTrigpointEntrance)
        Me.tabTrigpointMain.Controls.Add(Me.lblTrigpointEntrance)
        resources.ApplyResources(Me.tabTrigpointMain, "tabTrigpointMain")
        Me.tabTrigpointMain.Name = "tabTrigpointMain"
        Me.tabTrigpointMain.UseVisualStyleBackColor = True
        '
        'chkTrigpointZTurn
        '
        resources.ApplyResources(Me.chkTrigpointZTurn, "chkTrigpointZTurn")
        Me.chkTrigpointZTurn.Name = "chkTrigpointZTurn"
        Me.tipDefault.SetToolTip(Me.chkTrigpointZTurn, resources.GetString("chkTrigpointZTurn.ToolTip"))
        Me.chkTrigpointZTurn.UseVisualStyleBackColor = True
        '
        'chkTrigpointIsInExploration
        '
        resources.ApplyResources(Me.chkTrigpointIsInExploration, "chkTrigpointIsInExploration")
        Me.chkTrigpointIsInExploration.Name = "chkTrigpointIsInExploration"
        Me.tipDefault.SetToolTip(Me.chkTrigpointIsInExploration, resources.GetString("chkTrigpointIsInExploration.ToolTip"))
        Me.chkTrigpointIsInExploration.UseVisualStyleBackColor = True
        '
        'chkTrigpointShowEntrance
        '
        resources.ApplyResources(Me.chkTrigpointShowEntrance, "chkTrigpointShowEntrance")
        Me.chkTrigpointShowEntrance.Name = "chkTrigpointShowEntrance"
        Me.tipDefault.SetToolTip(Me.chkTrigpointShowEntrance, resources.GetString("chkTrigpointShowEntrance.ToolTip"))
        Me.chkTrigpointShowEntrance.UseVisualStyleBackColor = True
        '
        'grdTrigPointAliases
        '
        resources.ApplyResources(Me.grdTrigPointAliases, "grdTrigPointAliases")
        Me.grdTrigPointAliases.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdTrigPointAliases.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTrigPointAliases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTrigPointAliases.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3})
        Me.grdTrigPointAliases.ContextMenuStrip = Me.mnuAliases
        Me.grdTrigPointAliases.GridColor = System.Drawing.SystemColors.ControlLight
        Me.grdTrigPointAliases.MultiSelect = False
        Me.grdTrigPointAliases.Name = "grdTrigPointAliases"
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle21
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'mnuAliases
        '
        resources.ApplyResources(Me.mnuAliases, "mnuAliases")
        Me.mnuAliases.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAliasesRemove, Me.mnuAliasesRemoveAll})
        Me.mnuAliases.Name = "mnuAliases"
        '
        'mnuAliasesRemove
        '
        Me.mnuAliasesRemove.Name = "mnuAliasesRemove"
        resources.ApplyResources(Me.mnuAliasesRemove, "mnuAliasesRemove")
        '
        'mnuAliasesRemoveAll
        '
        Me.mnuAliasesRemoveAll.Name = "mnuAliasesRemoveAll"
        resources.ApplyResources(Me.mnuAliasesRemoveAll, "mnuAliasesRemoveAll")
        '
        'cboTrigPointType
        '
        Me.cboTrigPointType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigPointType, "cboTrigPointType")
        Me.cboTrigPointType.Items.AddRange(New Object() {resources.GetString("cboTrigPointType.Items"), resources.GetString("cboTrigPointType.Items1"), resources.GetString("cboTrigPointType.Items2"), resources.GetString("cboTrigPointType.Items3")})
        Me.cboTrigPointType.Name = "cboTrigPointType"
        Me.tipDefault.SetToolTip(Me.cboTrigPointType, resources.GetString("cboTrigPointType.ToolTip"))
        '
        'chkTrigpointIsSpecial
        '
        resources.ApplyResources(Me.chkTrigpointIsSpecial, "chkTrigpointIsSpecial")
        Me.chkTrigpointIsSpecial.Name = "chkTrigpointIsSpecial"
        Me.tipDefault.SetToolTip(Me.chkTrigpointIsSpecial, resources.GetString("chkTrigpointIsSpecial.ToolTip"))
        Me.chkTrigpointIsSpecial.UseVisualStyleBackColor = True
        '
        'lblTrigpointType
        '
        resources.ApplyResources(Me.lblTrigpointType, "lblTrigpointType")
        Me.lblTrigpointType.Name = "lblTrigpointType"
        '
        'cboTrigpointEntrance
        '
        Me.cboTrigpointEntrance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointEntrance, "cboTrigpointEntrance")
        Me.cboTrigpointEntrance.Items.AddRange(New Object() {resources.GetString("cboTrigpointEntrance.Items"), resources.GetString("cboTrigpointEntrance.Items1"), resources.GetString("cboTrigpointEntrance.Items2"), resources.GetString("cboTrigpointEntrance.Items3"), resources.GetString("cboTrigpointEntrance.Items4")})
        Me.cboTrigpointEntrance.Name = "cboTrigpointEntrance"
        Me.tipDefault.SetToolTip(Me.cboTrigpointEntrance, resources.GetString("cboTrigpointEntrance.ToolTip"))
        '
        'lblTrigpointEntrance
        '
        resources.ApplyResources(Me.lblTrigpointEntrance, "lblTrigpointEntrance")
        Me.lblTrigpointEntrance.Name = "lblTrigpointEntrance"
        '
        'tabTrigpointPropertyData
        '
        Me.tabTrigpointPropertyData.Controls.Add(Me.prpTrigpointDataProperties)
        resources.ApplyResources(Me.tabTrigpointPropertyData, "tabTrigpointPropertyData")
        Me.tabTrigpointPropertyData.Name = "tabTrigpointPropertyData"
        Me.tabTrigpointPropertyData.UseVisualStyleBackColor = True
        '
        'prpTrigpointDataProperties
        '
        Me.prpTrigpointDataProperties.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.prpTrigpointDataProperties.CommandsVisibleIfAvailable = False
        Me.prpTrigpointDataProperties.ContextMenuStrip = Me.mnuTrigpointDataProperties
        resources.ApplyResources(Me.prpTrigpointDataProperties, "prpTrigpointDataProperties")
        Me.prpTrigpointDataProperties.LineColor = System.Drawing.SystemColors.ControlDark
        Me.prpTrigpointDataProperties.Name = "prpTrigpointDataProperties"
        Me.prpTrigpointDataProperties.ToolbarVisible = False
        '
        'mnuTrigpointDataProperties
        '
        resources.ApplyResources(Me.mnuTrigpointDataProperties, "mnuTrigpointDataProperties")
        Me.mnuTrigpointDataProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrigpointDataPropertiesEdit, Me.ToolStripSeparator36, Me.mnuTrigpointDataPropertiesDelete})
        Me.mnuTrigpointDataProperties.Name = "mnuSegmentsDataFields"
        '
        'mnuTrigpointDataPropertiesEdit
        '
        Me.mnuTrigpointDataPropertiesEdit.Name = "mnuTrigpointDataPropertiesEdit"
        resources.ApplyResources(Me.mnuTrigpointDataPropertiesEdit, "mnuTrigpointDataPropertiesEdit")
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        resources.ApplyResources(Me.ToolStripSeparator36, "ToolStripSeparator36")
        '
        'mnuTrigpointDataPropertiesDelete
        '
        resources.ApplyResources(Me.mnuTrigpointDataPropertiesDelete, "mnuTrigpointDataPropertiesDelete")
        Me.mnuTrigpointDataPropertiesDelete.Name = "mnuTrigpointDataPropertiesDelete"
        '
        'tabTrigpointLayout
        '
        Me.tabTrigpointLayout.Controls.Add(Me.chkTrigpointDrawTranslationsLine)
        Me.tabTrigpointLayout.Controls.Add(Me.lblTrigpointFontchar)
        Me.tabTrigpointLayout.Controls.Add(Me.cmdTrigpointColorReset)
        Me.tabTrigpointLayout.Controls.Add(Me.txtTrigPointLabelDistance)
        Me.tabTrigpointLayout.Controls.Add(Me.cboTrigPointLabelSymbol)
        Me.tabTrigpointLayout.Controls.Add(Me.picTrigpointFontColor)
        Me.tabTrigpointLayout.Controls.Add(Me.lblTrigPointSymbol)
        Me.tabTrigpointLayout.Controls.Add(Me.lblTrigpointLabelDistance)
        Me.tabTrigpointLayout.Controls.Add(Me.lblFontColor)
        Me.tabTrigpointLayout.Controls.Add(Me.cboTrigPointLabelPosition)
        Me.tabTrigpointLayout.Controls.Add(Me.lblTrigpointLabelPosition)
        Me.tabTrigpointLayout.Controls.Add(Me.chkTrigpointFontUnderline)
        Me.tabTrigpointLayout.Controls.Add(Me.cboTrigpointFontChar)
        Me.tabTrigpointLayout.Controls.Add(Me.chkTrigpointFontItalic)
        Me.tabTrigpointLayout.Controls.Add(Me.cboTrigpointFontSize)
        Me.tabTrigpointLayout.Controls.Add(Me.chkTrigpointFontBold)
        Me.tabTrigpointLayout.Controls.Add(Me.cmdTrigpointFontColor)
        Me.tabTrigpointLayout.Controls.Add(Me.lblTextFontSize)
        resources.ApplyResources(Me.tabTrigpointLayout, "tabTrigpointLayout")
        Me.tabTrigpointLayout.Name = "tabTrigpointLayout"
        Me.tabTrigpointLayout.UseVisualStyleBackColor = True
        '
        'chkTrigpointDrawTranslationsLine
        '
        resources.ApplyResources(Me.chkTrigpointDrawTranslationsLine, "chkTrigpointDrawTranslationsLine")
        Me.chkTrigpointDrawTranslationsLine.Name = "chkTrigpointDrawTranslationsLine"
        Me.tipDefault.SetToolTip(Me.chkTrigpointDrawTranslationsLine, resources.GetString("chkTrigpointDrawTranslationsLine.ToolTip"))
        Me.chkTrigpointDrawTranslationsLine.UseVisualStyleBackColor = True
        '
        'lblTrigpointFontchar
        '
        resources.ApplyResources(Me.lblTrigpointFontchar, "lblTrigpointFontchar")
        Me.lblTrigpointFontchar.Name = "lblTrigpointFontchar"
        '
        'cmdTrigpointColorReset
        '
        resources.ApplyResources(Me.cmdTrigpointColorReset, "cmdTrigpointColorReset")
        Me.cmdTrigpointColorReset.Name = "cmdTrigpointColorReset"
        Me.tipDefault.SetToolTip(Me.cmdTrigpointColorReset, resources.GetString("cmdTrigpointColorReset.ToolTip"))
        Me.cmdTrigpointColorReset.UseVisualStyleBackColor = True
        '
        'txtTrigPointLabelDistance
        '
        resources.ApplyResources(Me.txtTrigPointLabelDistance, "txtTrigPointLabelDistance")
        Me.txtTrigPointLabelDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtTrigPointLabelDistance.Name = "txtTrigPointLabelDistance"
        Me.tipDefault.SetToolTip(Me.txtTrigPointLabelDistance, resources.GetString("txtTrigPointLabelDistance.ToolTip"))
        Me.txtTrigPointLabelDistance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboTrigPointLabelSymbol
        '
        Me.cboTrigPointLabelSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigPointLabelSymbol, "cboTrigPointLabelSymbol")
        Me.cboTrigPointLabelSymbol.Items.AddRange(New Object() {resources.GetString("cboTrigPointLabelSymbol.Items"), resources.GetString("cboTrigPointLabelSymbol.Items1"), resources.GetString("cboTrigPointLabelSymbol.Items2"), resources.GetString("cboTrigPointLabelSymbol.Items3"), resources.GetString("cboTrigPointLabelSymbol.Items4"), resources.GetString("cboTrigPointLabelSymbol.Items5"), resources.GetString("cboTrigPointLabelSymbol.Items6"), resources.GetString("cboTrigPointLabelSymbol.Items7"), resources.GetString("cboTrigPointLabelSymbol.Items8")})
        Me.cboTrigPointLabelSymbol.Name = "cboTrigPointLabelSymbol"
        Me.tipDefault.SetToolTip(Me.cboTrigPointLabelSymbol, resources.GetString("cboTrigPointLabelSymbol.ToolTip"))
        '
        'picTrigpointFontColor
        '
        resources.ApplyResources(Me.picTrigpointFontColor, "picTrigpointFontColor")
        Me.picTrigpointFontColor.Name = "picTrigpointFontColor"
        Me.picTrigpointFontColor.TabStop = False
        '
        'lblTrigPointSymbol
        '
        resources.ApplyResources(Me.lblTrigPointSymbol, "lblTrigPointSymbol")
        Me.lblTrigPointSymbol.Name = "lblTrigPointSymbol"
        Me.tipDefault.SetToolTip(Me.lblTrigPointSymbol, resources.GetString("lblTrigPointSymbol.ToolTip"))
        '
        'lblTrigpointLabelDistance
        '
        resources.ApplyResources(Me.lblTrigpointLabelDistance, "lblTrigpointLabelDistance")
        Me.lblTrigpointLabelDistance.Name = "lblTrigpointLabelDistance"
        Me.tipDefault.SetToolTip(Me.lblTrigpointLabelDistance, resources.GetString("lblTrigpointLabelDistance.ToolTip"))
        '
        'lblFontColor
        '
        resources.ApplyResources(Me.lblFontColor, "lblFontColor")
        Me.lblFontColor.Name = "lblFontColor"
        '
        'cboTrigPointLabelPosition
        '
        Me.cboTrigPointLabelPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigPointLabelPosition, "cboTrigPointLabelPosition")
        Me.cboTrigPointLabelPosition.Items.AddRange(New Object() {resources.GetString("cboTrigPointLabelPosition.Items"), resources.GetString("cboTrigPointLabelPosition.Items1"), resources.GetString("cboTrigPointLabelPosition.Items2"), resources.GetString("cboTrigPointLabelPosition.Items3"), resources.GetString("cboTrigPointLabelPosition.Items4"), resources.GetString("cboTrigPointLabelPosition.Items5"), resources.GetString("cboTrigPointLabelPosition.Items6"), resources.GetString("cboTrigPointLabelPosition.Items7"), resources.GetString("cboTrigPointLabelPosition.Items8")})
        Me.cboTrigPointLabelPosition.Name = "cboTrigPointLabelPosition"
        Me.tipDefault.SetToolTip(Me.cboTrigPointLabelPosition, resources.GetString("cboTrigPointLabelPosition.ToolTip"))
        '
        'lblTrigpointLabelPosition
        '
        resources.ApplyResources(Me.lblTrigpointLabelPosition, "lblTrigpointLabelPosition")
        Me.lblTrigpointLabelPosition.Name = "lblTrigpointLabelPosition"
        Me.tipDefault.SetToolTip(Me.lblTrigpointLabelPosition, resources.GetString("lblTrigpointLabelPosition.ToolTip"))
        '
        'chkTrigpointFontUnderline
        '
        resources.ApplyResources(Me.chkTrigpointFontUnderline, "chkTrigpointFontUnderline")
        Me.chkTrigpointFontUnderline.Name = "chkTrigpointFontUnderline"
        Me.chkTrigpointFontUnderline.UseVisualStyleBackColor = True
        '
        'cboTrigpointFontChar
        '
        Me.cboTrigpointFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointFontChar, "cboTrigpointFontChar")
        Me.cboTrigpointFontChar.FormattingEnabled = True
        Me.cboTrigpointFontChar.Name = "cboTrigpointFontChar"
        '
        'chkTrigpointFontItalic
        '
        resources.ApplyResources(Me.chkTrigpointFontItalic, "chkTrigpointFontItalic")
        Me.chkTrigpointFontItalic.Name = "chkTrigpointFontItalic"
        Me.chkTrigpointFontItalic.UseVisualStyleBackColor = True
        '
        'cboTrigpointFontSize
        '
        resources.ApplyResources(Me.cboTrigpointFontSize, "cboTrigpointFontSize")
        Me.cboTrigpointFontSize.FormattingEnabled = True
        Me.cboTrigpointFontSize.Items.AddRange(New Object() {resources.GetString("cboTrigpointFontSize.Items"), resources.GetString("cboTrigpointFontSize.Items1"), resources.GetString("cboTrigpointFontSize.Items2"), resources.GetString("cboTrigpointFontSize.Items3"), resources.GetString("cboTrigpointFontSize.Items4"), resources.GetString("cboTrigpointFontSize.Items5"), resources.GetString("cboTrigpointFontSize.Items6"), resources.GetString("cboTrigpointFontSize.Items7"), resources.GetString("cboTrigpointFontSize.Items8"), resources.GetString("cboTrigpointFontSize.Items9"), resources.GetString("cboTrigpointFontSize.Items10"), resources.GetString("cboTrigpointFontSize.Items11"), resources.GetString("cboTrigpointFontSize.Items12"), resources.GetString("cboTrigpointFontSize.Items13"), resources.GetString("cboTrigpointFontSize.Items14"), resources.GetString("cboTrigpointFontSize.Items15"), resources.GetString("cboTrigpointFontSize.Items16"), resources.GetString("cboTrigpointFontSize.Items17")})
        Me.cboTrigpointFontSize.Name = "cboTrigpointFontSize"
        '
        'chkTrigpointFontBold
        '
        resources.ApplyResources(Me.chkTrigpointFontBold, "chkTrigpointFontBold")
        Me.chkTrigpointFontBold.Name = "chkTrigpointFontBold"
        Me.chkTrigpointFontBold.UseVisualStyleBackColor = True
        '
        'cmdTrigpointFontColor
        '
        resources.ApplyResources(Me.cmdTrigpointFontColor, "cmdTrigpointFontColor")
        Me.cmdTrigpointFontColor.Name = "cmdTrigpointFontColor"
        Me.cmdTrigpointFontColor.UseVisualStyleBackColor = True
        '
        'lblTextFontSize
        '
        resources.ApplyResources(Me.lblTextFontSize, "lblTextFontSize")
        Me.lblTextFontSize.Name = "lblTextFontSize"
        '
        'tabTrigpointConnections
        '
        Me.tabTrigpointConnections.Controls.Add(Me.grdTrigpointConnections)
        resources.ApplyResources(Me.tabTrigpointConnections, "tabTrigpointConnections")
        Me.tabTrigpointConnections.Name = "tabTrigpointConnections"
        Me.tabTrigpointConnections.UseVisualStyleBackColor = True
        '
        'grdTrigpointConnections
        '
        Me.grdTrigpointConnections.AllowUserToAddRows = False
        Me.grdTrigpointConnections.AllowUserToDeleteRows = False
        Me.grdTrigpointConnections.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdTrigpointConnections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdTrigpointConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTrigpointConnections.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConnectionsTrigPoint, Me.colConnectionsIgnore})
        resources.ApplyResources(Me.grdTrigpointConnections, "grdTrigpointConnections")
        Me.grdTrigpointConnections.GridColor = System.Drawing.SystemColors.ControlLight
        Me.grdTrigpointConnections.MultiSelect = False
        Me.grdTrigpointConnections.Name = "grdTrigpointConnections"
        '
        'colConnectionsTrigPoint
        '
        resources.ApplyResources(Me.colConnectionsTrigPoint, "colConnectionsTrigPoint")
        Me.colConnectionsTrigPoint.Name = "colConnectionsTrigPoint"
        Me.colConnectionsTrigPoint.ReadOnly = True
        '
        'colConnectionsIgnore
        '
        resources.ApplyResources(Me.colConnectionsIgnore, "colConnectionsIgnore")
        Me.colConnectionsIgnore.Name = "colConnectionsIgnore"
        '
        'tabTrigpointCoordinate
        '
        Me.tabTrigpointCoordinate.AllowDrop = True
        Me.tabTrigpointCoordinate.Controls.Add(Me.btnTrigpointCoordinateClear)
        Me.tabTrigpointCoordinate.Controls.Add(Me.lblTrigpointCoordinateFix)
        Me.tabTrigpointCoordinate.Controls.Add(Me.cboTrigpointCoordinateFix)
        Me.tabTrigpointCoordinate.Controls.Add(Me.pnlTrigpointCoordinateWGS84)
        Me.tabTrigpointCoordinate.Controls.Add(Me.txtTrigpointCoordinateAlt)
        Me.tabTrigpointCoordinate.Controls.Add(Me.lblTrigpointCoordinateAlt)
        Me.tabTrigpointCoordinate.Controls.Add(Me.lblTrigpointCoordinateGeo)
        Me.tabTrigpointCoordinate.Controls.Add(Me.cboTrigpointCoordinateGeo)
        Me.tabTrigpointCoordinate.Controls.Add(Me.pnlTrigpointCoordinateUTM)
        resources.ApplyResources(Me.tabTrigpointCoordinate, "tabTrigpointCoordinate")
        Me.tabTrigpointCoordinate.Name = "tabTrigpointCoordinate"
        Me.tabTrigpointCoordinate.UseVisualStyleBackColor = True
        '
        'btnTrigpointCoordinateClear
        '
        resources.ApplyResources(Me.btnTrigpointCoordinateClear, "btnTrigpointCoordinateClear")
        Me.btnTrigpointCoordinateClear.Name = "btnTrigpointCoordinateClear"
        Me.tipDefault.SetToolTip(Me.btnTrigpointCoordinateClear, resources.GetString("btnTrigpointCoordinateClear.ToolTip"))
        Me.btnTrigpointCoordinateClear.UseVisualStyleBackColor = True
        '
        'lblTrigpointCoordinateFix
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateFix, "lblTrigpointCoordinateFix")
        Me.lblTrigpointCoordinateFix.Name = "lblTrigpointCoordinateFix"
        '
        'cboTrigpointCoordinateFix
        '
        Me.cboTrigpointCoordinateFix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointCoordinateFix, "cboTrigpointCoordinateFix")
        Me.cboTrigpointCoordinateFix.Items.AddRange(New Object() {resources.GetString("cboTrigpointCoordinateFix.Items"), resources.GetString("cboTrigpointCoordinateFix.Items1")})
        Me.cboTrigpointCoordinateFix.Name = "cboTrigpointCoordinateFix"
        Me.tipDefault.SetToolTip(Me.cboTrigpointCoordinateFix, resources.GetString("cboTrigpointCoordinateFix.ToolTip"))
        '
        'pnlTrigpointCoordinateWGS84
        '
        Me.pnlTrigpointCoordinateWGS84.Controls.Add(Me.txtTrigpointCoordinateLong)
        Me.pnlTrigpointCoordinateWGS84.Controls.Add(Me.txtTrigpointCoordinateLat)
        Me.pnlTrigpointCoordinateWGS84.Controls.Add(Me.lblTrigpointCoordinateLat)
        Me.pnlTrigpointCoordinateWGS84.Controls.Add(Me.lblTrigpointCoordinateLong)
        Me.pnlTrigpointCoordinateWGS84.Controls.Add(Me.lblTrigpointCoordinateFormat)
        Me.pnlTrigpointCoordinateWGS84.Controls.Add(Me.cboTrigpointCoordinateFormat)
        resources.ApplyResources(Me.pnlTrigpointCoordinateWGS84, "pnlTrigpointCoordinateWGS84")
        Me.pnlTrigpointCoordinateWGS84.Name = "pnlTrigpointCoordinateWGS84"
        '
        'txtTrigpointCoordinateLong
        '
        resources.ApplyResources(Me.txtTrigpointCoordinateLong, "txtTrigpointCoordinateLong")
        Me.txtTrigpointCoordinateLong.Name = "txtTrigpointCoordinateLong"
        '
        'txtTrigpointCoordinateLat
        '
        resources.ApplyResources(Me.txtTrigpointCoordinateLat, "txtTrigpointCoordinateLat")
        Me.txtTrigpointCoordinateLat.Name = "txtTrigpointCoordinateLat"
        Me.tipDefault.SetToolTip(Me.txtTrigpointCoordinateLat, resources.GetString("txtTrigpointCoordinateLat.ToolTip"))
        '
        'lblTrigpointCoordinateLat
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateLat, "lblTrigpointCoordinateLat")
        Me.lblTrigpointCoordinateLat.Name = "lblTrigpointCoordinateLat"
        '
        'lblTrigpointCoordinateLong
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateLong, "lblTrigpointCoordinateLong")
        Me.lblTrigpointCoordinateLong.Name = "lblTrigpointCoordinateLong"
        '
        'lblTrigpointCoordinateFormat
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateFormat, "lblTrigpointCoordinateFormat")
        Me.lblTrigpointCoordinateFormat.Name = "lblTrigpointCoordinateFormat"
        '
        'cboTrigpointCoordinateFormat
        '
        Me.cboTrigpointCoordinateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointCoordinateFormat, "cboTrigpointCoordinateFormat")
        Me.cboTrigpointCoordinateFormat.Items.AddRange(New Object() {resources.GetString("cboTrigpointCoordinateFormat.Items"), resources.GetString("cboTrigpointCoordinateFormat.Items1"), resources.GetString("cboTrigpointCoordinateFormat.Items2")})
        Me.cboTrigpointCoordinateFormat.Name = "cboTrigpointCoordinateFormat"
        Me.tipDefault.SetToolTip(Me.cboTrigpointCoordinateFormat, resources.GetString("cboTrigpointCoordinateFormat.ToolTip"))
        '
        'txtTrigpointCoordinateAlt
        '
        resources.ApplyResources(Me.txtTrigpointCoordinateAlt, "txtTrigpointCoordinateAlt")
        Me.txtTrigpointCoordinateAlt.Name = "txtTrigpointCoordinateAlt"
        Me.tipDefault.SetToolTip(Me.txtTrigpointCoordinateAlt, resources.GetString("txtTrigpointCoordinateAlt.ToolTip"))
        '
        'lblTrigpointCoordinateAlt
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateAlt, "lblTrigpointCoordinateAlt")
        Me.lblTrigpointCoordinateAlt.Name = "lblTrigpointCoordinateAlt"
        '
        'lblTrigpointCoordinateGeo
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateGeo, "lblTrigpointCoordinateGeo")
        Me.lblTrigpointCoordinateGeo.Name = "lblTrigpointCoordinateGeo"
        '
        'cboTrigpointCoordinateGeo
        '
        Me.cboTrigpointCoordinateGeo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointCoordinateGeo, "cboTrigpointCoordinateGeo")
        Me.cboTrigpointCoordinateGeo.Items.AddRange(New Object() {resources.GetString("cboTrigpointCoordinateGeo.Items"), resources.GetString("cboTrigpointCoordinateGeo.Items1")})
        Me.cboTrigpointCoordinateGeo.Name = "cboTrigpointCoordinateGeo"
        Me.tipDefault.SetToolTip(Me.cboTrigpointCoordinateGeo, resources.GetString("cboTrigpointCoordinateGeo.ToolTip"))
        '
        'pnlTrigpointCoordinateUTM
        '
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.Label5)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.cboTrigpointCoordinateBand)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.lblTrigpointCoordinateZone)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.txtTrigpointCoordinateY)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.cboTrigpointCoordinateZone)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.txtTrigpointCoordinateX)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.lblTrigpointCoordinateY)
        Me.pnlTrigpointCoordinateUTM.Controls.Add(Me.lblTrigpointCoordinateX)
        resources.ApplyResources(Me.pnlTrigpointCoordinateUTM, "pnlTrigpointCoordinateUTM")
        Me.pnlTrigpointCoordinateUTM.Name = "pnlTrigpointCoordinateUTM"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'cboTrigpointCoordinateBand
        '
        Me.cboTrigpointCoordinateBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointCoordinateBand, "cboTrigpointCoordinateBand")
        Me.cboTrigpointCoordinateBand.Name = "cboTrigpointCoordinateBand"
        '
        'lblTrigpointCoordinateZone
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateZone, "lblTrigpointCoordinateZone")
        Me.lblTrigpointCoordinateZone.Name = "lblTrigpointCoordinateZone"
        '
        'txtTrigpointCoordinateY
        '
        resources.ApplyResources(Me.txtTrigpointCoordinateY, "txtTrigpointCoordinateY")
        Me.txtTrigpointCoordinateY.Name = "txtTrigpointCoordinateY"
        Me.tipDefault.SetToolTip(Me.txtTrigpointCoordinateY, resources.GetString("txtTrigpointCoordinateY.ToolTip"))
        '
        'cboTrigpointCoordinateZone
        '
        Me.cboTrigpointCoordinateZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTrigpointCoordinateZone, "cboTrigpointCoordinateZone")
        Me.cboTrigpointCoordinateZone.Name = "cboTrigpointCoordinateZone"
        '
        'txtTrigpointCoordinateX
        '
        resources.ApplyResources(Me.txtTrigpointCoordinateX, "txtTrigpointCoordinateX")
        Me.txtTrigpointCoordinateX.Name = "txtTrigpointCoordinateX"
        Me.tipDefault.SetToolTip(Me.txtTrigpointCoordinateX, resources.GetString("txtTrigpointCoordinateX.ToolTip"))
        '
        'lblTrigpointCoordinateY
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateY, "lblTrigpointCoordinateY")
        Me.lblTrigpointCoordinateY.Name = "lblTrigpointCoordinateY"
        '
        'lblTrigpointCoordinateX
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateX, "lblTrigpointCoordinateX")
        Me.lblTrigpointCoordinateX.Name = "lblTrigpointCoordinateX"
        '
        'tabTrigpointNote
        '
        Me.tabTrigpointNote.Controls.Add(Me.txtTrigpointNote)
        resources.ApplyResources(Me.tabTrigpointNote, "tabTrigpointNote")
        Me.tabTrigpointNote.Name = "tabTrigpointNote"
        Me.tabTrigpointNote.UseVisualStyleBackColor = True
        '
        'txtTrigpointNote
        '
        resources.ApplyResources(Me.txtTrigpointNote, "txtTrigpointNote")
        Me.txtTrigpointNote.Name = "txtTrigpointNote"
        '
        'pnlTrigpointName
        '
        Me.pnlTrigpointName.Controls.Add(Me.lblTrigPointName)
        Me.pnlTrigpointName.Controls.Add(Me.txtTrigPointName)
        resources.ApplyResources(Me.pnlTrigpointName, "pnlTrigpointName")
        Me.pnlTrigpointName.Name = "pnlTrigpointName"
        '
        'lblTrigPointName
        '
        resources.ApplyResources(Me.lblTrigPointName, "lblTrigPointName")
        Me.lblTrigPointName.Name = "lblTrigPointName"
        '
        'txtTrigPointName
        '
        resources.ApplyResources(Me.txtTrigPointName, "txtTrigPointName")
        Me.txtTrigPointName.Name = "txtTrigPointName"
        Me.txtTrigPointName.ReadOnly = True
        '
        'tbSegmentsAndTrigpoints
        '
        Me.tbSegmentsAndTrigpoints.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.tbSegmentsAndTrigpoints, "tbSegmentsAndTrigpoints")
        Me.tbSegmentsAndTrigpoints.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbSegmentsAndTrigpoints.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSegments, Me.btnTrigPoints, Me.btnSegmentsAndTrigPoints, Me.btnSegmentAndTrigpointGridColorSep, Me.btnSegmentAndTrigpointGridColor, Me.btnSegnentAndTrigpointSepFilter, Me.btnSegmentAndTrigpointFilterEdit, Me.btnSegmentAndTrigpointFiltered})
        Me.tbSegmentsAndTrigpoints.Name = "tbSegmentsAndTrigpoints"
        '
        'btnSegments
        '
        Me.btnSegments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnSegments, "btnSegments")
        Me.btnSegments.Name = "btnSegments"
        '
        'btnTrigPoints
        '
        Me.btnTrigPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnTrigPoints, "btnTrigPoints")
        Me.btnTrigPoints.Name = "btnTrigPoints"
        '
        'btnSegmentsAndTrigPoints
        '
        Me.btnSegmentsAndTrigPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnSegmentsAndTrigPoints, "btnSegmentsAndTrigPoints")
        Me.btnSegmentsAndTrigPoints.Name = "btnSegmentsAndTrigPoints"
        '
        'btnSegmentAndTrigpointGridColorSep
        '
        Me.btnSegmentAndTrigpointGridColorSep.Name = "btnSegmentAndTrigpointGridColorSep"
        resources.ApplyResources(Me.btnSegmentAndTrigpointGridColorSep, "btnSegmentAndTrigpointGridColorSep")
        '
        'btnSegmentAndTrigpointGridColor
        '
        Me.btnSegmentAndTrigpointGridColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSegmentAndTrigpointGridColor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSegmentAndTrigpointGridColor3, Me.btnSegmentAndTrigpointGridColor2, Me.btnSegmentAndTrigpointGridColor1, Me.ToolStripMenuItem104, Me.btnSegmentAndTrigpointGridColor0})
        resources.ApplyResources(Me.btnSegmentAndTrigpointGridColor, "btnSegmentAndTrigpointGridColor")
        Me.btnSegmentAndTrigpointGridColor.Name = "btnSegmentAndTrigpointGridColor"
        '
        'btnSegmentAndTrigpointGridColor3
        '
        Me.btnSegmentAndTrigpointGridColor3.Name = "btnSegmentAndTrigpointGridColor3"
        resources.ApplyResources(Me.btnSegmentAndTrigpointGridColor3, "btnSegmentAndTrigpointGridColor3")
        '
        'btnSegmentAndTrigpointGridColor2
        '
        Me.btnSegmentAndTrigpointGridColor2.Name = "btnSegmentAndTrigpointGridColor2"
        resources.ApplyResources(Me.btnSegmentAndTrigpointGridColor2, "btnSegmentAndTrigpointGridColor2")
        '
        'btnSegmentAndTrigpointGridColor1
        '
        Me.btnSegmentAndTrigpointGridColor1.Name = "btnSegmentAndTrigpointGridColor1"
        resources.ApplyResources(Me.btnSegmentAndTrigpointGridColor1, "btnSegmentAndTrigpointGridColor1")
        '
        'ToolStripMenuItem104
        '
        Me.ToolStripMenuItem104.Name = "ToolStripMenuItem104"
        resources.ApplyResources(Me.ToolStripMenuItem104, "ToolStripMenuItem104")
        '
        'btnSegmentAndTrigpointGridColor0
        '
        Me.btnSegmentAndTrigpointGridColor0.Name = "btnSegmentAndTrigpointGridColor0"
        resources.ApplyResources(Me.btnSegmentAndTrigpointGridColor0, "btnSegmentAndTrigpointGridColor0")
        '
        'btnSegnentAndTrigpointSepFilter
        '
        Me.btnSegnentAndTrigpointSepFilter.Name = "btnSegnentAndTrigpointSepFilter"
        resources.ApplyResources(Me.btnSegnentAndTrigpointSepFilter, "btnSegnentAndTrigpointSepFilter")
        '
        'btnSegmentAndTrigpointFilterEdit
        '
        Me.btnSegmentAndTrigpointFilterEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSegmentAndTrigpointFilterEdit, "btnSegmentAndTrigpointFilterEdit")
        Me.btnSegmentAndTrigpointFilterEdit.Name = "btnSegmentAndTrigpointFilterEdit"
        '
        'btnSegmentAndTrigpointFiltered
        '
        Me.btnSegmentAndTrigpointFiltered.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSegmentAndTrigpointFiltered, "btnSegmentAndTrigpointFiltered")
        Me.btnSegmentAndTrigpointFiltered.Name = "btnSegmentAndTrigpointFiltered"
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'trkZoom
        '
        resources.ApplyResources(Me.trkZoom, "trkZoom")
        Me.trkZoom.LargeChange = 10
        Me.trkZoom.Maximum = 6000
        Me.trkZoom.Minimum = 2
        Me.trkZoom.Name = "trkZoom"
        Me.trkZoom.TickFrequency = 200
        Me.trkZoom.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trkZoom.Value = 20
        '
        'pnlObjectLayers
        '
        resources.ApplyResources(Me.pnlObjectLayers, "pnlObjectLayers")
        Me.pnlObjectLayers.BackColor = System.Drawing.SystemColors.Window
        Me.pnlObjectLayers.Controls.Add(Me.cmdLayerSync)
        Me.pnlObjectLayers.Controls.Add(Me.tvLayers2)
        Me.pnlObjectLayers.Controls.Add(Me.chkLayerFiltered)
        Me.pnlObjectLayers.Controls.Add(Me.cmdLayerFilterEdit)
        Me.pnlObjectLayers.Controls.Add(Me.lbLayerItemTitle)
        Me.pnlObjectLayers.Controls.Add(Me.lbLayerItemCaption)
        Me.pnlObjectLayers.Controls.Add(Me.piclayerItemPreview)
        Me.pnlObjectLayers.Controls.Add(Me.cmdLayerObjectSelect)
        Me.pnlObjectLayers.Controls.Add(Me.cmdLayerObjectProperty)
        Me.pnlObjectLayers.Controls.Add(Me.cmdLayerRefresh)
        Me.pnlObjectLayers.Name = "pnlObjectLayers"
        '
        'cmdLayerSync
        '
        resources.ApplyResources(Me.cmdLayerSync, "cmdLayerSync")
        Me.cmdLayerSync.Name = "cmdLayerSync"
        Me.tipDefault.SetToolTip(Me.cmdLayerSync, resources.GetString("cmdLayerSync.ToolTip"))
        Me.cmdLayerSync.UseVisualStyleBackColor = True
        '
        'tvLayers2
        '
        Me.tvLayers2.AllColumns.Add(Me.colLayersCaveBranchColor)
        Me.tvLayers2.AllColumns.Add(Me.colLayersType)
        Me.tvLayers2.AllColumns.Add(Me.colLayersHiddenInDesign)
        Me.tvLayers2.AllColumns.Add(Me.colLayersHiddenInPreview)
        Me.tvLayers2.AllColumns.Add(Me.colLayersPreview)
        Me.tvLayers2.AllColumns.Add(Me.colLayersName)
        Me.tvLayers2.AllColumns.Add(Me.colLayersCave)
        Me.tvLayers2.AllColumns.Add(Me.colLayersBranch)
        resources.ApplyResources(Me.tvLayers2, "tvLayers2")
        Me.tvLayers2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvLayers2.CellEditUseWholeCell = False
        Me.tvLayers2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLayersCaveBranchColor, Me.colLayersType, Me.colLayersHiddenInDesign, Me.colLayersHiddenInPreview, Me.colLayersPreview, Me.colLayersName, Me.colLayersCave, Me.colLayersBranch})
        Me.tvLayers2.ContextMenuStrip = Me.mnuLayersAndItems
        Me.tvLayers2.Cursor = System.Windows.Forms.Cursors.Default
        Me.tvLayers2.FullRowSelect = True
        Me.tvLayers2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.tvLayers2.HideSelection = False
        Me.tvLayers2.MultiSelect = False
        Me.tvLayers2.Name = "tvLayers2"
        Me.tvLayers2.ShowGroups = False
        Me.tvLayers2.ShowImagesOnSubItems = True
        Me.tvLayers2.SmallImageList = Me.imlLayers
        Me.tvLayers2.UseCompatibleStateImageBehavior = False
        Me.tvLayers2.UseSubItemCheckBoxes = True
        Me.tvLayers2.View = System.Windows.Forms.View.Details
        Me.tvLayers2.VirtualMode = True
        '
        'colLayersCaveBranchColor
        '
        Me.colLayersCaveBranchColor.IsEditable = False
        Me.colLayersCaveBranchColor.MaximumWidth = 8
        Me.colLayersCaveBranchColor.MinimumWidth = 8
        Me.colLayersCaveBranchColor.ShowTextInHeader = False
        Me.colLayersCaveBranchColor.Tag = "colLayersCaveBranchColor"
        resources.ApplyResources(Me.colLayersCaveBranchColor, "colLayersCaveBranchColor")
        '
        'colLayersType
        '
        Me.colLayersType.IsEditable = False
        Me.colLayersType.Tag = "colLayersType"
        resources.ApplyResources(Me.colLayersType, "colLayersType")
        '
        'colLayersHiddenInDesign
        '
        Me.colLayersHiddenInDesign.CheckBoxes = True
        Me.colLayersHiddenInDesign.MaximumWidth = 28
        Me.colLayersHiddenInDesign.MinimumWidth = 28
        Me.colLayersHiddenInDesign.ShowTextInHeader = False
        Me.colLayersHiddenInDesign.Tag = "colLayersHiddenInDesign"
        resources.ApplyResources(Me.colLayersHiddenInDesign, "colLayersHiddenInDesign")
        '
        'colLayersHiddenInPreview
        '
        Me.colLayersHiddenInPreview.CheckBoxes = True
        Me.colLayersHiddenInPreview.MaximumWidth = 28
        Me.colLayersHiddenInPreview.MinimumWidth = 28
        Me.colLayersHiddenInPreview.ShowTextInHeader = False
        Me.colLayersHiddenInPreview.Tag = "colLayersHiddenInPreview"
        resources.ApplyResources(Me.colLayersHiddenInPreview, "colLayersHiddenInPreview")
        '
        'colLayersPreview
        '
        Me.colLayersPreview.IsEditable = False
        Me.colLayersPreview.MaximumWidth = 28
        Me.colLayersPreview.MinimumWidth = 28
        Me.colLayersPreview.Tag = "colLayersPreview"
        resources.ApplyResources(Me.colLayersPreview, "colLayersPreview")
        '
        'colLayersName
        '
        Me.colLayersName.IsEditable = False
        Me.colLayersName.Tag = "colLayersName"
        resources.ApplyResources(Me.colLayersName, "colLayersName")
        '
        'colLayersCave
        '
        Me.colLayersCave.IsEditable = False
        Me.colLayersCave.Tag = "colLayersCave"
        resources.ApplyResources(Me.colLayersCave, "colLayersCave")
        '
        'colLayersBranch
        '
        Me.colLayersBranch.IsEditable = False
        Me.colLayersBranch.Tag = "colLayersBranch"
        resources.ApplyResources(Me.colLayersBranch, "colLayersBranch")
        '
        'mnuLayersAndItems
        '
        resources.ApplyResources(Me.mnuLayersAndItems, "mnuLayersAndItems")
        Me.mnuLayersAndItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLayersAndItemsExpand, Me.mnuLayersAndItemsExpandAll, Me.mnuLayersAndItemsCollapse, Me.mnuLayersAndItemsCollapseAll, Me.ToolStripMenuItem51, Me.mnuLayersAndItemsCurrentLevelShowAll, Me.mnuLayersAndItemsCurrentLevelHideAll, Me.mnuLayersAndItemsShowAll, Me.mnuLayersAndItemsHideAll, Me.ToolStripMenuItem45, Me.mnuLayersAndItemsDelete, Me.mnuLayersAndItemsCurrentLevelDeleteAll, Me.ToolStripMenuItem93, Me.mnuLayersAndItemsFilterEdit, Me.mnuLayersAndItemsFiltered, Me.ToolStripMenuItem62, Me.mnuLayersAndItemsProperty, Me.ToolStripMenuItem38, Me.mnuLayersAndItemsSelect, Me.mnuLayersAndItemsSelectAllInCurrentLevel, Me.mnuLayersAndItemsSelectAll, Me.ToolStripMenuItem88, Me.mnuLayersAndItemsVisible, Me.ToolStripMenuItem41, Me.mnuLayersAndItemsRefresh})
        Me.mnuLayersAndItems.Name = "ContextMenuStrip1"
        '
        'mnuLayersAndItemsExpand
        '
        Me.mnuLayersAndItemsExpand.Name = "mnuLayersAndItemsExpand"
        resources.ApplyResources(Me.mnuLayersAndItemsExpand, "mnuLayersAndItemsExpand")
        '
        'mnuLayersAndItemsExpandAll
        '
        Me.mnuLayersAndItemsExpandAll.Name = "mnuLayersAndItemsExpandAll"
        resources.ApplyResources(Me.mnuLayersAndItemsExpandAll, "mnuLayersAndItemsExpandAll")
        '
        'mnuLayersAndItemsCollapse
        '
        Me.mnuLayersAndItemsCollapse.Name = "mnuLayersAndItemsCollapse"
        resources.ApplyResources(Me.mnuLayersAndItemsCollapse, "mnuLayersAndItemsCollapse")
        '
        'mnuLayersAndItemsCollapseAll
        '
        Me.mnuLayersAndItemsCollapseAll.Name = "mnuLayersAndItemsCollapseAll"
        resources.ApplyResources(Me.mnuLayersAndItemsCollapseAll, "mnuLayersAndItemsCollapseAll")
        '
        'ToolStripMenuItem51
        '
        Me.ToolStripMenuItem51.Name = "ToolStripMenuItem51"
        resources.ApplyResources(Me.ToolStripMenuItem51, "ToolStripMenuItem51")
        '
        'mnuLayersAndItemsCurrentLevelShowAll
        '
        Me.mnuLayersAndItemsCurrentLevelShowAll.Name = "mnuLayersAndItemsCurrentLevelShowAll"
        resources.ApplyResources(Me.mnuLayersAndItemsCurrentLevelShowAll, "mnuLayersAndItemsCurrentLevelShowAll")
        '
        'mnuLayersAndItemsCurrentLevelHideAll
        '
        Me.mnuLayersAndItemsCurrentLevelHideAll.Name = "mnuLayersAndItemsCurrentLevelHideAll"
        resources.ApplyResources(Me.mnuLayersAndItemsCurrentLevelHideAll, "mnuLayersAndItemsCurrentLevelHideAll")
        '
        'mnuLayersAndItemsShowAll
        '
        Me.mnuLayersAndItemsShowAll.Name = "mnuLayersAndItemsShowAll"
        resources.ApplyResources(Me.mnuLayersAndItemsShowAll, "mnuLayersAndItemsShowAll")
        '
        'mnuLayersAndItemsHideAll
        '
        Me.mnuLayersAndItemsHideAll.Name = "mnuLayersAndItemsHideAll"
        resources.ApplyResources(Me.mnuLayersAndItemsHideAll, "mnuLayersAndItemsHideAll")
        '
        'ToolStripMenuItem45
        '
        Me.ToolStripMenuItem45.Name = "ToolStripMenuItem45"
        resources.ApplyResources(Me.ToolStripMenuItem45, "ToolStripMenuItem45")
        '
        'mnuLayersAndItemsDelete
        '
        resources.ApplyResources(Me.mnuLayersAndItemsDelete, "mnuLayersAndItemsDelete")
        Me.mnuLayersAndItemsDelete.Name = "mnuLayersAndItemsDelete"
        '
        'mnuLayersAndItemsCurrentLevelDeleteAll
        '
        Me.mnuLayersAndItemsCurrentLevelDeleteAll.Name = "mnuLayersAndItemsCurrentLevelDeleteAll"
        resources.ApplyResources(Me.mnuLayersAndItemsCurrentLevelDeleteAll, "mnuLayersAndItemsCurrentLevelDeleteAll")
        '
        'ToolStripMenuItem93
        '
        Me.ToolStripMenuItem93.Name = "ToolStripMenuItem93"
        resources.ApplyResources(Me.ToolStripMenuItem93, "ToolStripMenuItem93")
        '
        'mnuLayersAndItemsFilterEdit
        '
        resources.ApplyResources(Me.mnuLayersAndItemsFilterEdit, "mnuLayersAndItemsFilterEdit")
        Me.mnuLayersAndItemsFilterEdit.Name = "mnuLayersAndItemsFilterEdit"
        '
        'mnuLayersAndItemsFiltered
        '
        resources.ApplyResources(Me.mnuLayersAndItemsFiltered, "mnuLayersAndItemsFiltered")
        Me.mnuLayersAndItemsFiltered.Name = "mnuLayersAndItemsFiltered"
        '
        'ToolStripMenuItem62
        '
        Me.ToolStripMenuItem62.Name = "ToolStripMenuItem62"
        resources.ApplyResources(Me.ToolStripMenuItem62, "ToolStripMenuItem62")
        '
        'mnuLayersAndItemsProperty
        '
        resources.ApplyResources(Me.mnuLayersAndItemsProperty, "mnuLayersAndItemsProperty")
        Me.mnuLayersAndItemsProperty.Name = "mnuLayersAndItemsProperty"
        '
        'ToolStripMenuItem38
        '
        Me.ToolStripMenuItem38.Name = "ToolStripMenuItem38"
        resources.ApplyResources(Me.ToolStripMenuItem38, "ToolStripMenuItem38")
        '
        'mnuLayersAndItemsSelect
        '
        resources.ApplyResources(Me.mnuLayersAndItemsSelect, "mnuLayersAndItemsSelect")
        Me.mnuLayersAndItemsSelect.Name = "mnuLayersAndItemsSelect"
        '
        'mnuLayersAndItemsSelectAllInCurrentLevel
        '
        Me.mnuLayersAndItemsSelectAllInCurrentLevel.Name = "mnuLayersAndItemsSelectAllInCurrentLevel"
        resources.ApplyResources(Me.mnuLayersAndItemsSelectAllInCurrentLevel, "mnuLayersAndItemsSelectAllInCurrentLevel")
        '
        'mnuLayersAndItemsSelectAll
        '
        Me.mnuLayersAndItemsSelectAll.Name = "mnuLayersAndItemsSelectAll"
        resources.ApplyResources(Me.mnuLayersAndItemsSelectAll, "mnuLayersAndItemsSelectAll")
        '
        'ToolStripMenuItem88
        '
        Me.ToolStripMenuItem88.Name = "ToolStripMenuItem88"
        resources.ApplyResources(Me.ToolStripMenuItem88, "ToolStripMenuItem88")
        '
        'mnuLayersAndItemsVisible
        '
        Me.mnuLayersAndItemsVisible.Name = "mnuLayersAndItemsVisible"
        resources.ApplyResources(Me.mnuLayersAndItemsVisible, "mnuLayersAndItemsVisible")
        '
        'ToolStripMenuItem41
        '
        Me.ToolStripMenuItem41.Name = "ToolStripMenuItem41"
        resources.ApplyResources(Me.ToolStripMenuItem41, "ToolStripMenuItem41")
        '
        'mnuLayersAndItemsRefresh
        '
        Me.mnuLayersAndItemsRefresh.Name = "mnuLayersAndItemsRefresh"
        resources.ApplyResources(Me.mnuLayersAndItemsRefresh, "mnuLayersAndItemsRefresh")
        '
        'imlLayers
        '
        Me.imlLayers.ImageStream = CType(resources.GetObject("imlLayers.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlLayers.TransparentColor = System.Drawing.Color.Transparent
        Me.imlLayers.Images.SetKeyName(0, "layer")
        Me.imlLayers.Images.SetKeyName(1, "cross")
        Me.imlLayers.Images.SetKeyName(2, "generic")
        Me.imlLayers.Images.SetKeyName(3, "generic_error")
        Me.imlLayers.Images.SetKeyName(4, "print")
        Me.imlLayers.Images.SetKeyName(5, "edit")
        '
        'chkLayerFiltered
        '
        resources.ApplyResources(Me.chkLayerFiltered, "chkLayerFiltered")
        Me.chkLayerFiltered.Name = "chkLayerFiltered"
        Me.tipDefault.SetToolTip(Me.chkLayerFiltered, resources.GetString("chkLayerFiltered.ToolTip"))
        Me.chkLayerFiltered.UseVisualStyleBackColor = True
        '
        'cmdLayerFilterEdit
        '
        resources.ApplyResources(Me.cmdLayerFilterEdit, "cmdLayerFilterEdit")
        Me.cmdLayerFilterEdit.Name = "cmdLayerFilterEdit"
        Me.tipDefault.SetToolTip(Me.cmdLayerFilterEdit, resources.GetString("cmdLayerFilterEdit.ToolTip"))
        Me.cmdLayerFilterEdit.UseVisualStyleBackColor = True
        '
        'lbLayerItemTitle
        '
        resources.ApplyResources(Me.lbLayerItemTitle, "lbLayerItemTitle")
        Me.lbLayerItemTitle.Name = "lbLayerItemTitle"
        '
        'lbLayerItemCaption
        '
        resources.ApplyResources(Me.lbLayerItemCaption, "lbLayerItemCaption")
        Me.lbLayerItemCaption.Name = "lbLayerItemCaption"
        '
        'piclayerItemPreview
        '
        resources.ApplyResources(Me.piclayerItemPreview, "piclayerItemPreview")
        Me.piclayerItemPreview.Name = "piclayerItemPreview"
        Me.piclayerItemPreview.TabStop = False
        '
        'cmdLayerObjectSelect
        '
        resources.ApplyResources(Me.cmdLayerObjectSelect, "cmdLayerObjectSelect")
        Me.cmdLayerObjectSelect.Name = "cmdLayerObjectSelect"
        Me.tipDefault.SetToolTip(Me.cmdLayerObjectSelect, resources.GetString("cmdLayerObjectSelect.ToolTip"))
        Me.cmdLayerObjectSelect.UseVisualStyleBackColor = True
        '
        'cmdLayerObjectProperty
        '
        resources.ApplyResources(Me.cmdLayerObjectProperty, "cmdLayerObjectProperty")
        Me.cmdLayerObjectProperty.Name = "cmdLayerObjectProperty"
        Me.tipDefault.SetToolTip(Me.cmdLayerObjectProperty, resources.GetString("cmdLayerObjectProperty.ToolTip"))
        Me.cmdLayerObjectProperty.UseVisualStyleBackColor = True
        '
        'cmdLayerRefresh
        '
        resources.ApplyResources(Me.cmdLayerRefresh, "cmdLayerRefresh")
        Me.cmdLayerRefresh.Name = "cmdLayerRefresh"
        Me.tipDefault.SetToolTip(Me.cmdLayerRefresh, resources.GetString("cmdLayerRefresh.ToolTip"))
        Me.cmdLayerRefresh.UseVisualStyleBackColor = True
        '
        'pnlProperties
        '
        Me.pnlProperties.BackColor = System.Drawing.SystemColors.Window
        Me.pnlProperties.Controls.Add(Me.tabObjectProp)
        resources.ApplyResources(Me.pnlProperties, "pnlProperties")
        Me.pnlProperties.Name = "pnlProperties"
        '
        'tabObjectProp
        '
        Me.tabObjectProp.Controls.Add(Me.tabObjectPropDesign)
        Me.tabObjectProp.Controls.Add(Me.tabObjectPropMain)
        Me.tabObjectProp.Controls.Add(Me.tabObjectProp3D)
        resources.ApplyResources(Me.tabObjectProp, "tabObjectProp")
        Me.tabObjectProp.ImageList = Me.iml
        Me.tabObjectProp.Name = "tabObjectProp"
        Me.tabObjectProp.SelectedIndex = 0
        '
        'tabObjectPropDesign
        '
        Me.tabObjectPropDesign.Controls.Add(Me.tblDesignProp)
        resources.ApplyResources(Me.tabObjectPropDesign, "tabObjectPropDesign")
        Me.tabObjectPropDesign.Name = "tabObjectPropDesign"
        Me.tabObjectPropDesign.UseVisualStyleBackColor = True
        '
        'tblDesignProp
        '
        resources.ApplyResources(Me.tblDesignProp, "tblDesignProp")
        Me.tblDesignProp.Controls.Add(Me.pnlDesignSize, 0, 2)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignPosition, 0, 1)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignRotation, 0, 3)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignStyle, 0, 10)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignSnapToGrid, 0, 11)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignPlotContainer, 0, 8)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignSurfaceContainer, 0, 7)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignSurfaceProfile, 0, 9)
        Me.tblDesignProp.Controls.Add(Me.pnlDesignPrintOrExportAreaContainer, 0, 5)
        Me.tblDesignProp.Controls.Add(Me.cDesignLinkedSurveys, 0, 4)
        Me.tblDesignProp.Name = "tblDesignProp"
        '
        'pnlDesignSize
        '
        Me.pnlDesignSize.BackColor = System.Drawing.Color.Transparent
        Me.pnlDesignSize.Controls.Add(Me.Label65)
        Me.pnlDesignSize.Controls.Add(Me.txtDesignScaleHeight)
        Me.pnlDesignSize.Controls.Add(Me.Label66)
        Me.pnlDesignSize.Controls.Add(Me.lblDesignScale)
        Me.pnlDesignSize.Controls.Add(Me.txtDesignScaleWidth)
        Me.pnlDesignSize.Controls.Add(Me.cmdDesignFlipV)
        Me.pnlDesignSize.Controls.Add(Me.cmdDesignFlipH)
        Me.pnlDesignSize.Controls.Add(Me.txtDesignWidth)
        Me.pnlDesignSize.Controls.Add(Me.txtDesignHeight)
        Me.pnlDesignSize.Controls.Add(Me.lblDesignWidthUM)
        Me.pnlDesignSize.Controls.Add(Me.lblDesignHeightUM)
        Me.pnlDesignSize.Controls.Add(Me.lblDesignSize)
        resources.ApplyResources(Me.pnlDesignSize, "pnlDesignSize")
        Me.pnlDesignSize.Name = "pnlDesignSize"
        '
        'Label65
        '
        resources.ApplyResources(Me.Label65, "Label65")
        Me.Label65.Name = "Label65"
        '
        'txtDesignScaleHeight
        '
        resources.ApplyResources(Me.txtDesignScaleHeight, "txtDesignScaleHeight")
        Me.txtDesignScaleHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtDesignScaleHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDesignScaleHeight.Name = "txtDesignScaleHeight"
        Me.tipDefault.SetToolTip(Me.txtDesignScaleHeight, resources.GetString("txtDesignScaleHeight.ToolTip"))
        Me.txtDesignScaleHeight.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label66
        '
        resources.ApplyResources(Me.Label66, "Label66")
        Me.Label66.Name = "Label66"
        '
        'lblDesignScale
        '
        resources.ApplyResources(Me.lblDesignScale, "lblDesignScale")
        Me.lblDesignScale.Name = "lblDesignScale"
        '
        'txtDesignScaleWidth
        '
        resources.ApplyResources(Me.txtDesignScaleWidth, "txtDesignScaleWidth")
        Me.txtDesignScaleWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtDesignScaleWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtDesignScaleWidth.Name = "txtDesignScaleWidth"
        Me.tipDefault.SetToolTip(Me.txtDesignScaleWidth, resources.GetString("txtDesignScaleWidth.ToolTip"))
        Me.txtDesignScaleWidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cmdDesignFlipV
        '
        resources.ApplyResources(Me.cmdDesignFlipV, "cmdDesignFlipV")
        Me.cmdDesignFlipV.Name = "cmdDesignFlipV"
        Me.tipDefault.SetToolTip(Me.cmdDesignFlipV, resources.GetString("cmdDesignFlipV.ToolTip"))
        Me.cmdDesignFlipV.UseVisualStyleBackColor = True
        '
        'cmdDesignFlipH
        '
        resources.ApplyResources(Me.cmdDesignFlipH, "cmdDesignFlipH")
        Me.cmdDesignFlipH.Name = "cmdDesignFlipH"
        Me.tipDefault.SetToolTip(Me.cmdDesignFlipH, resources.GetString("cmdDesignFlipH.ToolTip"))
        Me.cmdDesignFlipH.UseVisualStyleBackColor = True
        '
        'txtDesignWidth
        '
        resources.ApplyResources(Me.txtDesignWidth, "txtDesignWidth")
        Me.txtDesignWidth.Name = "txtDesignWidth"
        Me.tipDefault.SetToolTip(Me.txtDesignWidth, resources.GetString("txtDesignWidth.ToolTip"))
        '
        'txtDesignHeight
        '
        resources.ApplyResources(Me.txtDesignHeight, "txtDesignHeight")
        Me.txtDesignHeight.Name = "txtDesignHeight"
        Me.tipDefault.SetToolTip(Me.txtDesignHeight, resources.GetString("txtDesignHeight.ToolTip"))
        '
        'lblDesignWidthUM
        '
        resources.ApplyResources(Me.lblDesignWidthUM, "lblDesignWidthUM")
        Me.lblDesignWidthUM.Name = "lblDesignWidthUM"
        '
        'lblDesignHeightUM
        '
        resources.ApplyResources(Me.lblDesignHeightUM, "lblDesignHeightUM")
        Me.lblDesignHeightUM.Name = "lblDesignHeightUM"
        '
        'lblDesignSize
        '
        resources.ApplyResources(Me.lblDesignSize, "lblDesignSize")
        Me.lblDesignSize.Name = "lblDesignSize"
        '
        'pnlDesignPosition
        '
        resources.ApplyResources(Me.pnlDesignPosition, "pnlDesignPosition")
        Me.pnlDesignPosition.BackColor = System.Drawing.Color.Transparent
        Me.pnlDesignPosition.Controls.Add(Me.txtDesignLeft)
        Me.pnlDesignPosition.Controls.Add(Me.cmdDesignMoveRight)
        Me.pnlDesignPosition.Controls.Add(Me.cmdDesignMoveDown)
        Me.pnlDesignPosition.Controls.Add(Me.cmdDesignMoveLeft)
        Me.pnlDesignPosition.Controls.Add(Me.cmdDesignMoveTop)
        Me.pnlDesignPosition.Controls.Add(Me.txtDesignTop)
        Me.pnlDesignPosition.Controls.Add(Me.lblDesignLeftUM)
        Me.pnlDesignPosition.Controls.Add(Me.lblDesignTopUM)
        Me.pnlDesignPosition.Controls.Add(Me.lblDesignPosition)
        Me.pnlDesignPosition.Name = "pnlDesignPosition"
        '
        'txtDesignLeft
        '
        resources.ApplyResources(Me.txtDesignLeft, "txtDesignLeft")
        Me.txtDesignLeft.Name = "txtDesignLeft"
        Me.tipDefault.SetToolTip(Me.txtDesignLeft, resources.GetString("txtDesignLeft.ToolTip"))
        '
        'cmdDesignMoveRight
        '
        resources.ApplyResources(Me.cmdDesignMoveRight, "cmdDesignMoveRight")
        Me.cmdDesignMoveRight.Name = "cmdDesignMoveRight"
        Me.tipDefault.SetToolTip(Me.cmdDesignMoveRight, resources.GetString("cmdDesignMoveRight.ToolTip"))
        Me.cmdDesignMoveRight.UseVisualStyleBackColor = True
        '
        'cmdDesignMoveDown
        '
        resources.ApplyResources(Me.cmdDesignMoveDown, "cmdDesignMoveDown")
        Me.cmdDesignMoveDown.Name = "cmdDesignMoveDown"
        Me.tipDefault.SetToolTip(Me.cmdDesignMoveDown, resources.GetString("cmdDesignMoveDown.ToolTip"))
        Me.cmdDesignMoveDown.UseVisualStyleBackColor = True
        '
        'cmdDesignMoveLeft
        '
        resources.ApplyResources(Me.cmdDesignMoveLeft, "cmdDesignMoveLeft")
        Me.cmdDesignMoveLeft.Name = "cmdDesignMoveLeft"
        Me.tipDefault.SetToolTip(Me.cmdDesignMoveLeft, resources.GetString("cmdDesignMoveLeft.ToolTip"))
        Me.cmdDesignMoveLeft.UseVisualStyleBackColor = True
        '
        'cmdDesignMoveTop
        '
        resources.ApplyResources(Me.cmdDesignMoveTop, "cmdDesignMoveTop")
        Me.cmdDesignMoveTop.Name = "cmdDesignMoveTop"
        Me.tipDefault.SetToolTip(Me.cmdDesignMoveTop, resources.GetString("cmdDesignMoveTop.ToolTip"))
        Me.cmdDesignMoveTop.UseVisualStyleBackColor = True
        '
        'txtDesignTop
        '
        resources.ApplyResources(Me.txtDesignTop, "txtDesignTop")
        Me.txtDesignTop.Name = "txtDesignTop"
        Me.tipDefault.SetToolTip(Me.txtDesignTop, resources.GetString("txtDesignTop.ToolTip"))
        '
        'lblDesignLeftUM
        '
        resources.ApplyResources(Me.lblDesignLeftUM, "lblDesignLeftUM")
        Me.lblDesignLeftUM.Name = "lblDesignLeftUM"
        '
        'lblDesignTopUM
        '
        resources.ApplyResources(Me.lblDesignTopUM, "lblDesignTopUM")
        Me.lblDesignTopUM.Name = "lblDesignTopUM"
        '
        'lblDesignPosition
        '
        resources.ApplyResources(Me.lblDesignPosition, "lblDesignPosition")
        Me.lblDesignPosition.Name = "lblDesignPosition"
        '
        'pnlDesignRotation
        '
        Me.pnlDesignRotation.BackColor = System.Drawing.Color.Transparent
        Me.pnlDesignRotation.Controls.Add(Me.chkDesignRotateCenterOnOrigin)
        Me.pnlDesignRotation.Controls.Add(Me.cmdDesignRotateLeftByDegree)
        Me.pnlDesignRotation.Controls.Add(Me.cmdDesignRotateRightByDegree)
        Me.pnlDesignRotation.Controls.Add(Me.cmdDesignRotateRight)
        Me.pnlDesignRotation.Controls.Add(Me.cmdDesignRotateLeft)
        Me.pnlDesignRotation.Controls.Add(Me.txtDesignRotate)
        Me.pnlDesignRotation.Controls.Add(Me.Label74)
        Me.pnlDesignRotation.Controls.Add(Me.lblDesignRotation)
        resources.ApplyResources(Me.pnlDesignRotation, "pnlDesignRotation")
        Me.pnlDesignRotation.Name = "pnlDesignRotation"
        '
        'chkDesignRotateCenterOnOrigin
        '
        resources.ApplyResources(Me.chkDesignRotateCenterOnOrigin, "chkDesignRotateCenterOnOrigin")
        Me.chkDesignRotateCenterOnOrigin.Name = "chkDesignRotateCenterOnOrigin"
        Me.chkDesignRotateCenterOnOrigin.UseVisualStyleBackColor = True
        '
        'cmdDesignRotateLeftByDegree
        '
        resources.ApplyResources(Me.cmdDesignRotateLeftByDegree, "cmdDesignRotateLeftByDegree")
        Me.cmdDesignRotateLeftByDegree.Name = "cmdDesignRotateLeftByDegree"
        Me.tipDefault.SetToolTip(Me.cmdDesignRotateLeftByDegree, resources.GetString("cmdDesignRotateLeftByDegree.ToolTip"))
        Me.cmdDesignRotateLeftByDegree.UseVisualStyleBackColor = True
        '
        'cmdDesignRotateRightByDegree
        '
        resources.ApplyResources(Me.cmdDesignRotateRightByDegree, "cmdDesignRotateRightByDegree")
        Me.cmdDesignRotateRightByDegree.Name = "cmdDesignRotateRightByDegree"
        Me.tipDefault.SetToolTip(Me.cmdDesignRotateRightByDegree, resources.GetString("cmdDesignRotateRightByDegree.ToolTip"))
        Me.cmdDesignRotateRightByDegree.UseVisualStyleBackColor = True
        '
        'cmdDesignRotateRight
        '
        resources.ApplyResources(Me.cmdDesignRotateRight, "cmdDesignRotateRight")
        Me.cmdDesignRotateRight.Name = "cmdDesignRotateRight"
        Me.tipDefault.SetToolTip(Me.cmdDesignRotateRight, resources.GetString("cmdDesignRotateRight.ToolTip"))
        Me.cmdDesignRotateRight.UseVisualStyleBackColor = True
        '
        'cmdDesignRotateLeft
        '
        resources.ApplyResources(Me.cmdDesignRotateLeft, "cmdDesignRotateLeft")
        Me.cmdDesignRotateLeft.Name = "cmdDesignRotateLeft"
        Me.tipDefault.SetToolTip(Me.cmdDesignRotateLeft, resources.GetString("cmdDesignRotateLeft.ToolTip"))
        Me.cmdDesignRotateLeft.UseVisualStyleBackColor = True
        '
        'txtDesignRotate
        '
        resources.ApplyResources(Me.txtDesignRotate, "txtDesignRotate")
        Me.txtDesignRotate.Name = "txtDesignRotate"
        Me.tipDefault.SetToolTip(Me.txtDesignRotate, resources.GetString("txtDesignRotate.ToolTip"))
        '
        'Label74
        '
        resources.ApplyResources(Me.Label74, "Label74")
        Me.Label74.Name = "Label74"
        '
        'lblDesignRotation
        '
        resources.ApplyResources(Me.lblDesignRotation, "lblDesignRotation")
        Me.lblDesignRotation.Name = "lblDesignRotation"
        '
        'pnlDesignStyle
        '
        Me.pnlDesignStyle.BackColor = System.Drawing.Color.Transparent
        Me.pnlDesignStyle.Controls.Add(Me.Label6)
        Me.pnlDesignStyle.Controls.Add(Me.chkDesignUnselectedLevelDrawingMode2)
        Me.pnlDesignStyle.Controls.Add(Me.chkDesignUnselectedLevelDrawingMode1)
        Me.pnlDesignStyle.Controls.Add(Me.chkDesignUnselectedLevelDrawingMode0)
        Me.pnlDesignStyle.Controls.Add(Me.lblDesignUnselectedLevelDrawingMode)
        Me.pnlDesignStyle.Controls.Add(Me.chkDesignStyle2)
        Me.pnlDesignStyle.Controls.Add(Me.chkDesignStyle1)
        Me.pnlDesignStyle.Controls.Add(Me.chkDesignStyle0)
        Me.pnlDesignStyle.Controls.Add(Me.lblDesignStyle)
        Me.pnlDesignStyle.Controls.Add(Me.pnlDesignCombineColorMode)
        resources.ApplyResources(Me.pnlDesignStyle, "pnlDesignStyle")
        Me.pnlDesignStyle.Name = "pnlDesignStyle"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'chkDesignUnselectedLevelDrawingMode2
        '
        resources.ApplyResources(Me.chkDesignUnselectedLevelDrawingMode2, "chkDesignUnselectedLevelDrawingMode2")
        Me.chkDesignUnselectedLevelDrawingMode2.Name = "chkDesignUnselectedLevelDrawingMode2"
        Me.chkDesignUnselectedLevelDrawingMode2.UseVisualStyleBackColor = True
        '
        'chkDesignUnselectedLevelDrawingMode1
        '
        resources.ApplyResources(Me.chkDesignUnselectedLevelDrawingMode1, "chkDesignUnselectedLevelDrawingMode1")
        Me.chkDesignUnselectedLevelDrawingMode1.Name = "chkDesignUnselectedLevelDrawingMode1"
        Me.chkDesignUnselectedLevelDrawingMode1.UseVisualStyleBackColor = True
        '
        'chkDesignUnselectedLevelDrawingMode0
        '
        resources.ApplyResources(Me.chkDesignUnselectedLevelDrawingMode0, "chkDesignUnselectedLevelDrawingMode0")
        Me.chkDesignUnselectedLevelDrawingMode0.Name = "chkDesignUnselectedLevelDrawingMode0"
        Me.chkDesignUnselectedLevelDrawingMode0.UseVisualStyleBackColor = True
        '
        'lblDesignUnselectedLevelDrawingMode
        '
        resources.ApplyResources(Me.lblDesignUnselectedLevelDrawingMode, "lblDesignUnselectedLevelDrawingMode")
        Me.lblDesignUnselectedLevelDrawingMode.Name = "lblDesignUnselectedLevelDrawingMode"
        '
        'chkDesignStyle2
        '
        resources.ApplyResources(Me.chkDesignStyle2, "chkDesignStyle2")
        Me.chkDesignStyle2.Name = "chkDesignStyle2"
        Me.chkDesignStyle2.UseVisualStyleBackColor = True
        '
        'chkDesignStyle1
        '
        resources.ApplyResources(Me.chkDesignStyle1, "chkDesignStyle1")
        Me.chkDesignStyle1.Name = "chkDesignStyle1"
        Me.chkDesignStyle1.UseVisualStyleBackColor = True
        '
        'chkDesignStyle0
        '
        resources.ApplyResources(Me.chkDesignStyle0, "chkDesignStyle0")
        Me.chkDesignStyle0.Name = "chkDesignStyle0"
        Me.chkDesignStyle0.UseVisualStyleBackColor = True
        '
        'lblDesignStyle
        '
        resources.ApplyResources(Me.lblDesignStyle, "lblDesignStyle")
        Me.lblDesignStyle.Name = "lblDesignStyle"
        '
        'pnlDesignCombineColorMode
        '
        Me.pnlDesignCombineColorMode.Controls.Add(Me.chkDesignCombineColorGray)
        Me.pnlDesignCombineColorMode.Controls.Add(Me.cboDesignCombineColorMode)
        Me.pnlDesignCombineColorMode.Controls.Add(Me.lblDesignCombineColorMode)
        resources.ApplyResources(Me.pnlDesignCombineColorMode, "pnlDesignCombineColorMode")
        Me.pnlDesignCombineColorMode.Name = "pnlDesignCombineColorMode"
        '
        'chkDesignCombineColorGray
        '
        resources.ApplyResources(Me.chkDesignCombineColorGray, "chkDesignCombineColorGray")
        Me.chkDesignCombineColorGray.Name = "chkDesignCombineColorGray"
        '
        'cboDesignCombineColorMode
        '
        Me.cboDesignCombineColorMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboDesignCombineColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignCombineColorMode.Items.AddRange(New Object() {resources.GetString("cboDesignCombineColorMode.Items"), resources.GetString("cboDesignCombineColorMode.Items1"), resources.GetString("cboDesignCombineColorMode.Items2")})
        resources.ApplyResources(Me.cboDesignCombineColorMode, "cboDesignCombineColorMode")
        Me.cboDesignCombineColorMode.Name = "cboDesignCombineColorMode"
        '
        'lblDesignCombineColorMode
        '
        resources.ApplyResources(Me.lblDesignCombineColorMode, "lblDesignCombineColorMode")
        Me.lblDesignCombineColorMode.Name = "lblDesignCombineColorMode"
        '
        'pnlDesignSnapToGrid
        '
        Me.pnlDesignSnapToGrid.Controls.Add(Me.txtDesignSnapToGrid)
        Me.pnlDesignSnapToGrid.Controls.Add(Me.lblDesignSnapToGridUM)
        Me.pnlDesignSnapToGrid.Controls.Add(Me.lblDesignSnapToGrid0)
        Me.pnlDesignSnapToGrid.Controls.Add(Me.chkDesignSnapToGrid)
        resources.ApplyResources(Me.pnlDesignSnapToGrid, "pnlDesignSnapToGrid")
        Me.pnlDesignSnapToGrid.Name = "pnlDesignSnapToGrid"
        '
        'txtDesignSnapToGrid
        '
        Me.txtDesignSnapToGrid.DecimalPlaces = 1
        resources.ApplyResources(Me.txtDesignSnapToGrid, "txtDesignSnapToGrid")
        Me.txtDesignSnapToGrid.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        Me.txtDesignSnapToGrid.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtDesignSnapToGrid.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtDesignSnapToGrid.Name = "txtDesignSnapToGrid"
        Me.tipDefault.SetToolTip(Me.txtDesignSnapToGrid, resources.GetString("txtDesignSnapToGrid.ToolTip"))
        Me.txtDesignSnapToGrid.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'lblDesignSnapToGridUM
        '
        resources.ApplyResources(Me.lblDesignSnapToGridUM, "lblDesignSnapToGridUM")
        Me.lblDesignSnapToGridUM.Name = "lblDesignSnapToGridUM"
        '
        'lblDesignSnapToGrid0
        '
        resources.ApplyResources(Me.lblDesignSnapToGrid0, "lblDesignSnapToGrid0")
        Me.lblDesignSnapToGrid0.Name = "lblDesignSnapToGrid0"
        '
        'chkDesignSnapToGrid
        '
        resources.ApplyResources(Me.chkDesignSnapToGrid, "chkDesignSnapToGrid")
        Me.chkDesignSnapToGrid.Name = "chkDesignSnapToGrid"
        Me.chkDesignSnapToGrid.UseVisualStyleBackColor = True
        '
        'pnlDesignPlotContainer
        '
        resources.ApplyResources(Me.pnlDesignPlotContainer, "pnlDesignPlotContainer")
        Me.pnlDesignPlotContainer.Controls.Add(Me.chkDesignPlot)
        Me.pnlDesignPlotContainer.Controls.Add(Me.pnlDesignPlot)
        Me.pnlDesignPlotContainer.Name = "pnlDesignPlotContainer"
        '
        'chkDesignPlot
        '
        resources.ApplyResources(Me.chkDesignPlot, "chkDesignPlot")
        Me.chkDesignPlot.Name = "chkDesignPlot"
        Me.chkDesignPlot.UseVisualStyleBackColor = True
        '
        'pnlDesignPlot
        '
        resources.ApplyResources(Me.pnlDesignPlot, "pnlDesignPlot")
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplayMode)
        Me.pnlDesignPlot.Controls.Add(Me.lvDesignPlotShowHLsDett)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotColorGray)
        Me.pnlDesignPlot.Controls.Add(Me.btnDesignRings)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotSegmentsPaintStyle)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowHLs)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotColorMode)
        Me.pnlDesignPlot.Controls.Add(Me.lblDesignPlotColorMode)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowTrigpointText)
        Me.pnlDesignPlot.Controls.Add(Me.btnDesignPlotSplay)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowTrigpoint)
        Me.pnlDesignPlot.Controls.Add(Me.btnDesignHighlights)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowLRUD)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplayLabel)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegment)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplay)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotSplayStyle)
        Me.pnlDesignPlot.Name = "pnlDesignPlot"
        '
        'chkDesignPlotShowSplayMode
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplayMode, "chkDesignPlotShowSplayMode")
        Me.chkDesignPlotShowSplayMode.Name = "chkDesignPlotShowSplayMode"
        Me.chkDesignPlotShowSplayMode.UseVisualStyleBackColor = True
        '
        'lvDesignPlotShowHLsDett
        '
        resources.ApplyResources(Me.lvDesignPlotShowHLsDett, "lvDesignPlotShowHLsDett")
        Me.lvDesignPlotShowHLsDett.CheckBoxes = True
        Me.lvDesignPlotShowHLsDett.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNome})
        Me.lvDesignPlotShowHLsDett.FullRowSelect = True
        Me.lvDesignPlotShowHLsDett.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvDesignPlotShowHLsDett.HideSelection = False
        Me.lvDesignPlotShowHLsDett.Name = "lvDesignPlotShowHLsDett"
        Me.lvDesignPlotShowHLsDett.UseCompatibleStateImageBehavior = False
        Me.lvDesignPlotShowHLsDett.View = System.Windows.Forms.View.Details
        '
        'colNome
        '
        resources.ApplyResources(Me.colNome, "colNome")
        '
        'chkDesignPlotColorGray
        '
        resources.ApplyResources(Me.chkDesignPlotColorGray, "chkDesignPlotColorGray")
        Me.chkDesignPlotColorGray.Name = "chkDesignPlotColorGray"
        '
        'btnDesignRings
        '
        resources.ApplyResources(Me.btnDesignRings, "btnDesignRings")
        Me.btnDesignRings.Name = "btnDesignRings"
        Me.tipDefault.SetToolTip(Me.btnDesignRings, resources.GetString("btnDesignRings.ToolTip"))
        Me.btnDesignRings.UseVisualStyleBackColor = True
        '
        'cboDesignPlotSegmentsPaintStyle
        '
        Me.cboDesignPlotSegmentsPaintStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboDesignPlotSegmentsPaintStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignPlotSegmentsPaintStyle.DropDownWidth = 320
        resources.ApplyResources(Me.cboDesignPlotSegmentsPaintStyle, "cboDesignPlotSegmentsPaintStyle")
        Me.cboDesignPlotSegmentsPaintStyle.Items.AddRange(New Object() {resources.GetString("cboDesignPlotSegmentsPaintStyle.Items"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Items1"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Items2"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Items3")})
        Me.cboDesignPlotSegmentsPaintStyle.Name = "cboDesignPlotSegmentsPaintStyle"
        '
        'chkDesignPlotShowHLs
        '
        resources.ApplyResources(Me.chkDesignPlotShowHLs, "chkDesignPlotShowHLs")
        Me.chkDesignPlotShowHLs.Name = "chkDesignPlotShowHLs"
        Me.chkDesignPlotShowHLs.UseVisualStyleBackColor = True
        '
        'cboDesignPlotColorMode
        '
        Me.cboDesignPlotColorMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboDesignPlotColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignPlotColorMode.Items.AddRange(New Object() {resources.GetString("cboDesignPlotColorMode.Items"), resources.GetString("cboDesignPlotColorMode.Items1"), resources.GetString("cboDesignPlotColorMode.Items2")})
        resources.ApplyResources(Me.cboDesignPlotColorMode, "cboDesignPlotColorMode")
        Me.cboDesignPlotColorMode.Name = "cboDesignPlotColorMode"
        '
        'lblDesignPlotColorMode
        '
        resources.ApplyResources(Me.lblDesignPlotColorMode, "lblDesignPlotColorMode")
        Me.lblDesignPlotColorMode.Name = "lblDesignPlotColorMode"
        '
        'chkDesignPlotShowTrigpointText
        '
        resources.ApplyResources(Me.chkDesignPlotShowTrigpointText, "chkDesignPlotShowTrigpointText")
        Me.chkDesignPlotShowTrigpointText.Name = "chkDesignPlotShowTrigpointText"
        Me.chkDesignPlotShowTrigpointText.UseVisualStyleBackColor = True
        '
        'btnDesignPlotSplay
        '
        resources.ApplyResources(Me.btnDesignPlotSplay, "btnDesignPlotSplay")
        Me.btnDesignPlotSplay.Name = "btnDesignPlotSplay"
        Me.tipDefault.SetToolTip(Me.btnDesignPlotSplay, resources.GetString("btnDesignPlotSplay.ToolTip"))
        Me.btnDesignPlotSplay.UseVisualStyleBackColor = True
        '
        'chkDesignPlotShowTrigpoint
        '
        resources.ApplyResources(Me.chkDesignPlotShowTrigpoint, "chkDesignPlotShowTrigpoint")
        Me.chkDesignPlotShowTrigpoint.Name = "chkDesignPlotShowTrigpoint"
        Me.chkDesignPlotShowTrigpoint.UseVisualStyleBackColor = True
        '
        'btnDesignHighlights
        '
        resources.ApplyResources(Me.btnDesignHighlights, "btnDesignHighlights")
        Me.btnDesignHighlights.Name = "btnDesignHighlights"
        Me.tipDefault.SetToolTip(Me.btnDesignHighlights, resources.GetString("btnDesignHighlights.ToolTip"))
        Me.btnDesignHighlights.UseVisualStyleBackColor = True
        '
        'chkDesignPlotShowLRUD
        '
        resources.ApplyResources(Me.chkDesignPlotShowLRUD, "chkDesignPlotShowLRUD")
        Me.chkDesignPlotShowLRUD.Name = "chkDesignPlotShowLRUD"
        Me.chkDesignPlotShowLRUD.UseVisualStyleBackColor = True
        '
        'chkDesignPlotShowSplayLabel
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplayLabel, "chkDesignPlotShowSplayLabel")
        Me.chkDesignPlotShowSplayLabel.Name = "chkDesignPlotShowSplayLabel"
        Me.chkDesignPlotShowSplayLabel.UseVisualStyleBackColor = True
        '
        'chkDesignPlotShowSegment
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegment, "chkDesignPlotShowSegment")
        Me.chkDesignPlotShowSegment.Name = "chkDesignPlotShowSegment"
        Me.chkDesignPlotShowSegment.UseVisualStyleBackColor = True
        '
        'chkDesignPlotShowSplay
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplay, "chkDesignPlotShowSplay")
        Me.chkDesignPlotShowSplay.Name = "chkDesignPlotShowSplay"
        Me.chkDesignPlotShowSplay.UseVisualStyleBackColor = True
        '
        'cboDesignPlotSplayStyle
        '
        Me.cboDesignPlotSplayStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignPlotSplayStyle.DropDownWidth = 320
        resources.ApplyResources(Me.cboDesignPlotSplayStyle, "cboDesignPlotSplayStyle")
        Me.cboDesignPlotSplayStyle.Items.AddRange(New Object() {resources.GetString("cboDesignPlotSplayStyle.Items"), resources.GetString("cboDesignPlotSplayStyle.Items1"), resources.GetString("cboDesignPlotSplayStyle.Items2")})
        Me.cboDesignPlotSplayStyle.Name = "cboDesignPlotSplayStyle"
        '
        'pnlDesignSurfaceContainer
        '
        resources.ApplyResources(Me.pnlDesignSurfaceContainer, "pnlDesignSurfaceContainer")
        Me.pnlDesignSurfaceContainer.Controls.Add(Me.chkDesignSurface)
        Me.pnlDesignSurfaceContainer.Controls.Add(Me.cmdDesignSurfaceEdit)
        Me.pnlDesignSurfaceContainer.Controls.Add(Me.pnlDesignSurface)
        Me.pnlDesignSurfaceContainer.Name = "pnlDesignSurfaceContainer"
        '
        'chkDesignSurface
        '
        resources.ApplyResources(Me.chkDesignSurface, "chkDesignSurface")
        Me.chkDesignSurface.Name = "chkDesignSurface"
        Me.chkDesignSurface.UseVisualStyleBackColor = True
        '
        'cmdDesignSurfaceEdit
        '
        resources.ApplyResources(Me.cmdDesignSurfaceEdit, "cmdDesignSurfaceEdit")
        Me.cmdDesignSurfaceEdit.Name = "cmdDesignSurfaceEdit"
        Me.tipDefault.SetToolTip(Me.cmdDesignSurfaceEdit, resources.GetString("cmdDesignSurfaceEdit.ToolTip"))
        Me.cmdDesignSurfaceEdit.UseVisualStyleBackColor = True
        '
        'pnlDesignSurface
        '
        resources.ApplyResources(Me.pnlDesignSurface, "pnlDesignSurface")
        Me.pnlDesignSurface.Controls.Add(Me.cmdDesignSurfaceLayersEdit)
        Me.pnlDesignSurface.Controls.Add(Me.tvDesignSurfaceLayers)
        Me.pnlDesignSurface.Controls.Add(Me.cmdDesignSurfaceLayersDown)
        Me.pnlDesignSurface.Controls.Add(Me.cmdDesignSurfaceLayersUp)
        Me.pnlDesignSurface.Name = "pnlDesignSurface"
        '
        'cmdDesignSurfaceLayersEdit
        '
        resources.ApplyResources(Me.cmdDesignSurfaceLayersEdit, "cmdDesignSurfaceLayersEdit")
        Me.cmdDesignSurfaceLayersEdit.Name = "cmdDesignSurfaceLayersEdit"
        Me.tipDefault.SetToolTip(Me.cmdDesignSurfaceLayersEdit, resources.GetString("cmdDesignSurfaceLayersEdit.ToolTip"))
        Me.cmdDesignSurfaceLayersEdit.UseVisualStyleBackColor = True
        '
        'tvDesignSurfaceLayers
        '
        resources.ApplyResources(Me.tvDesignSurfaceLayers, "tvDesignSurfaceLayers")
        Me.tvDesignSurfaceLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvDesignSurfaceLayers.CheckBoxes = True
        Me.tvDesignSurfaceLayers.ContextMenuStrip = Me.mnuDesignSurfaceLayers
        Me.tvDesignSurfaceLayers.FullRowSelect = True
        Me.tvDesignSurfaceLayers.HideSelection = False
        Me.tvDesignSurfaceLayers.ImageList = Me.iml
        Me.tvDesignSurfaceLayers.Name = "tvDesignSurfaceLayers"
        '
        'mnuDesignSurfaceLayers
        '
        resources.ApplyResources(Me.mnuDesignSurfaceLayers, "mnuDesignSurfaceLayers")
        Me.mnuDesignSurfaceLayers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignSurfaceEdit, Me.ToolStripMenuItem71, Me.mnuDesignSurfaceLayersEdit, Me.ToolStripMenuItem99, Me.mnuDesignSurfaceLayersShowAll, Me.mnuDesignSurfaceLayersHideAll})
        Me.mnuDesignSurfaceLayers.Name = "mnuDesignSurfaceLayers"
        '
        'mnuDesignSurfaceEdit
        '
        resources.ApplyResources(Me.mnuDesignSurfaceEdit, "mnuDesignSurfaceEdit")
        Me.mnuDesignSurfaceEdit.Name = "mnuDesignSurfaceEdit"
        '
        'ToolStripMenuItem71
        '
        Me.ToolStripMenuItem71.Name = "ToolStripMenuItem71"
        resources.ApplyResources(Me.ToolStripMenuItem71, "ToolStripMenuItem71")
        '
        'mnuDesignSurfaceLayersEdit
        '
        resources.ApplyResources(Me.mnuDesignSurfaceLayersEdit, "mnuDesignSurfaceLayersEdit")
        Me.mnuDesignSurfaceLayersEdit.Name = "mnuDesignSurfaceLayersEdit"
        '
        'ToolStripMenuItem99
        '
        Me.ToolStripMenuItem99.Name = "ToolStripMenuItem99"
        resources.ApplyResources(Me.ToolStripMenuItem99, "ToolStripMenuItem99")
        '
        'mnuDesignSurfaceLayersShowAll
        '
        Me.mnuDesignSurfaceLayersShowAll.Name = "mnuDesignSurfaceLayersShowAll"
        resources.ApplyResources(Me.mnuDesignSurfaceLayersShowAll, "mnuDesignSurfaceLayersShowAll")
        '
        'mnuDesignSurfaceLayersHideAll
        '
        Me.mnuDesignSurfaceLayersHideAll.Name = "mnuDesignSurfaceLayersHideAll"
        resources.ApplyResources(Me.mnuDesignSurfaceLayersHideAll, "mnuDesignSurfaceLayersHideAll")
        '
        'cmdDesignSurfaceLayersDown
        '
        resources.ApplyResources(Me.cmdDesignSurfaceLayersDown, "cmdDesignSurfaceLayersDown")
        Me.cmdDesignSurfaceLayersDown.Name = "cmdDesignSurfaceLayersDown"
        Me.tipDefault.SetToolTip(Me.cmdDesignSurfaceLayersDown, resources.GetString("cmdDesignSurfaceLayersDown.ToolTip"))
        Me.cmdDesignSurfaceLayersDown.UseVisualStyleBackColor = True
        '
        'cmdDesignSurfaceLayersUp
        '
        resources.ApplyResources(Me.cmdDesignSurfaceLayersUp, "cmdDesignSurfaceLayersUp")
        Me.cmdDesignSurfaceLayersUp.Name = "cmdDesignSurfaceLayersUp"
        Me.tipDefault.SetToolTip(Me.cmdDesignSurfaceLayersUp, resources.GetString("cmdDesignSurfaceLayersUp.ToolTip"))
        Me.cmdDesignSurfaceLayersUp.UseVisualStyleBackColor = True
        '
        'pnlDesignSurfaceProfile
        '
        Me.pnlDesignSurfaceProfile.Controls.Add(Me.chkDesignSurfaceProfile)
        resources.ApplyResources(Me.pnlDesignSurfaceProfile, "pnlDesignSurfaceProfile")
        Me.pnlDesignSurfaceProfile.Name = "pnlDesignSurfaceProfile"
        '
        'chkDesignSurfaceProfile
        '
        resources.ApplyResources(Me.chkDesignSurfaceProfile, "chkDesignSurfaceProfile")
        Me.chkDesignSurfaceProfile.Name = "chkDesignSurfaceProfile"
        Me.chkDesignSurfaceProfile.UseVisualStyleBackColor = True
        '
        'pnlDesignPrintOrExportAreaContainer
        '
        Me.pnlDesignPrintOrExportAreaContainer.Controls.Add(Me.cDesignPrintOrExportArea)
        resources.ApplyResources(Me.pnlDesignPrintOrExportAreaContainer, "pnlDesignPrintOrExportAreaContainer")
        Me.pnlDesignPrintOrExportAreaContainer.Name = "pnlDesignPrintOrExportAreaContainer"
        '
        'cDesignPrintOrExportArea
        '
        resources.ApplyResources(Me.cDesignPrintOrExportArea, "cDesignPrintOrExportArea")
        Me.cDesignPrintOrExportArea.BackColor = System.Drawing.SystemColors.Window
        Me.cDesignPrintOrExportArea.Name = "cDesignPrintOrExportArea"
        '
        'cDesignLinkedSurveys
        '
        resources.ApplyResources(Me.cDesignLinkedSurveys, "cDesignLinkedSurveys")
        Me.cDesignLinkedSurveys.BackColor = System.Drawing.SystemColors.Window
        Me.cDesignLinkedSurveys.Name = "cDesignLinkedSurveys"
        '
        'tabObjectPropMain
        '
        Me.tabObjectPropMain.Controls.Add(Me.tblObjectProp)
        resources.ApplyResources(Me.tabObjectPropMain, "tabObjectPropMain")
        Me.tabObjectPropMain.Name = "tabObjectPropMain"
        Me.tabObjectPropMain.UseVisualStyleBackColor = True
        '
        'tblObjectProp
        '
        resources.ApplyResources(Me.tblObjectProp, "tblObjectProp")
        Me.tblObjectProp.Controls.Add(Me.pnlPropConvertTo, 0, 43)
        Me.tblObjectProp.Controls.Add(Me.pnlPropClipping, 0, 42)
        Me.tblObjectProp.Controls.Add(Me.pnlPropShape, 0, 15)
        Me.tblObjectProp.Controls.Add(Me.pnlPropShapeSequences, 0, 17)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSign, 0, 37)
        Me.tblObjectProp.Controls.Add(Me.pnlPropImage, 0, 26)
        Me.tblObjectProp.Controls.Add(Me.pnlPropInfo, 0, 1)
        Me.tblObjectProp.Controls.Add(Me.pnlPropPen, 0, 19)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSize, 0, 6)
        Me.tblObjectProp.Controls.Add(Me.pnlPropPosition, 0, 5)
        Me.tblObjectProp.Controls.Add(Me.pnlPropRotation, 0, 7)
        Me.tblObjectProp.Controls.Add(Me.pnlPropLineType, 0, 22)
        Me.tblObjectProp.Controls.Add(Me.pnlPropBrush, 0, 27)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSegmentBinding, 0, 38)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSegmentsBinding, 0, 39)
        Me.tblObjectProp.Controls.Add(Me.pnlPropText, 0, 28)
        Me.tblObjectProp.Controls.Add(Me.pnlPropCrossSection, 0, 29)
        Me.tblObjectProp.Controls.Add(Me.pnlPropQuota, 0, 36)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSketch, 0, 14)
        Me.tblObjectProp.Controls.Add(Me.pnlPropMergeMode, 0, 23)
        Me.tblObjectProp.Controls.Add(Me.pnlPropTransparency, 0, 18)
        Me.tblObjectProp.Controls.Add(Me.pnlPropObjectsBinding, 0, 41)
        Me.tblObjectProp.Controls.Add(Me.pnlPropPointsSequences, 0, 16)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSequenceLineType, 0, 21)
        Me.tblObjectProp.Controls.Add(Me.pnlPropProp, 0, 3)
        Me.tblObjectProp.Controls.Add(Me.pnlPropItems, 0, 8)
        Me.tblObjectProp.Controls.Add(Me.pnlPropPopup, 0, 0)
        Me.tblObjectProp.Controls.Add(Me.pnlPropProfileSplayBorder, 0, 34)
        Me.tblObjectProp.Controls.Add(Me.pnlPropPlanSplayBorder, 0, 33)
        Me.tblObjectProp.Controls.Add(Me.pnlPropDataProperties, 0, 4)
        Me.tblObjectProp.Controls.Add(Me.pnlPropCrossSectionSplayBorder, 0, 35)
        Me.tblObjectProp.Controls.Add(Me.pnlPropSegmentInfo, 0, 9)
        Me.tblObjectProp.Controls.Add(Me.pnlPropTrigpointInfo, 0, 10)
        Me.tblObjectProp.Controls.Add(Me.pnlPropCrossSectionMarker, 0, 32)
        Me.tblObjectProp.Controls.Add(Me.pnlPropTrigpointsDistances, 0, 45)
        Me.tblObjectProp.Controls.Add(Me.pnlPropVisibility, 0, 11)
        Me.tblObjectProp.Controls.Add(Me.pnlPropAttachment, 0, 25)
        Me.tblObjectProp.Controls.Add(Me.pnlPropLegend, 0, 24)
        Me.tblObjectProp.Controls.Add(Me.pnlPropScale, 0, 12)
        Me.tblObjectProp.Controls.Add(Me.pnlPropCompass, 0, 13)
        Me.tblObjectProp.Controls.Add(Me.cPropName, 0, 2)
        Me.tblObjectProp.Name = "tblObjectProp"
        '
        'pnlPropConvertTo
        '
        resources.ApplyResources(Me.pnlPropConvertTo, "pnlPropConvertTo")
        Me.pnlPropConvertTo.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropConvertTo.Controls.Add(Me.cmdPropConvertTo)
        Me.pnlPropConvertTo.Controls.Add(Me.lvPropConvertTo)
        Me.pnlPropConvertTo.Controls.Add(Me.lblPropConvertTo)
        Me.pnlPropConvertTo.Name = "pnlPropConvertTo"
        '
        'cmdPropConvertTo
        '
        resources.ApplyResources(Me.cmdPropConvertTo, "cmdPropConvertTo")
        Me.cmdPropConvertTo.Name = "cmdPropConvertTo"
        Me.tipDefault.SetToolTip(Me.cmdPropConvertTo, resources.GetString("cmdPropConvertTo.ToolTip"))
        Me.cmdPropConvertTo.UseVisualStyleBackColor = True
        '
        'lvPropConvertTo
        '
        resources.ApplyResources(Me.lvPropConvertTo, "lvPropConvertTo")
        Me.lvPropConvertTo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvPropConvertTo.FullRowSelect = True
        Me.lvPropConvertTo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvPropConvertTo.LargeImageList = Me.imlGeneric
        Me.lvPropConvertTo.MultiSelect = False
        Me.lvPropConvertTo.Name = "lvPropConvertTo"
        Me.lvPropConvertTo.SmallImageList = Me.imlGeneric
        Me.tipDefault.SetToolTip(Me.lvPropConvertTo, resources.GetString("lvPropConvertTo.ToolTip"))
        Me.lvPropConvertTo.UseCompatibleStateImageBehavior = False
        Me.lvPropConvertTo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        '
        'imlGeneric
        '
        Me.imlGeneric.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        resources.ApplyResources(Me.imlGeneric, "imlGeneric")
        Me.imlGeneric.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblPropConvertTo
        '
        resources.ApplyResources(Me.lblPropConvertTo, "lblPropConvertTo")
        Me.lblPropConvertTo.Name = "lblPropConvertTo"
        Me.tipDefault.SetToolTip(Me.lblPropConvertTo, resources.GetString("lblPropConvertTo.ToolTip"))
        '
        'pnlPropClipping
        '
        Me.pnlPropClipping.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropClipping.Controls.Add(Me.cboPropClipping)
        Me.pnlPropClipping.Controls.Add(Me.lblPropClipping)
        resources.ApplyResources(Me.pnlPropClipping, "pnlPropClipping")
        Me.pnlPropClipping.Name = "pnlPropClipping"
        '
        'cboPropClipping
        '
        Me.cboPropClipping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropClipping.FormattingEnabled = True
        Me.cboPropClipping.Items.AddRange(New Object() {resources.GetString("cboPropClipping.Items"), resources.GetString("cboPropClipping.Items1"), resources.GetString("cboPropClipping.Items2"), resources.GetString("cboPropClipping.Items3")})
        resources.ApplyResources(Me.cboPropClipping, "cboPropClipping")
        Me.cboPropClipping.Name = "cboPropClipping"
        Me.tipDefault.SetToolTip(Me.cboPropClipping, resources.GetString("cboPropClipping.ToolTip"))
        '
        'lblPropClipping
        '
        resources.ApplyResources(Me.lblPropClipping, "lblPropClipping")
        Me.lblPropClipping.Name = "lblPropClipping"
        Me.tipDefault.SetToolTip(Me.lblPropClipping, resources.GetString("lblPropClipping.ToolTip"))
        '
        'pnlPropShape
        '
        Me.pnlPropShape.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropShape.Controls.Add(Me.Label3)
        Me.pnlPropShape.Controls.Add(Me.cmdPropShapeDivide)
        Me.pnlPropShape.Controls.Add(Me.cmdPropShapeCombine)
        resources.ApplyResources(Me.pnlPropShape, "pnlPropShape")
        Me.pnlPropShape.Name = "pnlPropShape"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'cmdPropShapeDivide
        '
        resources.ApplyResources(Me.cmdPropShapeDivide, "cmdPropShapeDivide")
        Me.cmdPropShapeDivide.Name = "cmdPropShapeDivide"
        Me.tipDefault.SetToolTip(Me.cmdPropShapeDivide, resources.GetString("cmdPropShapeDivide.ToolTip"))
        Me.cmdPropShapeDivide.UseVisualStyleBackColor = True
        '
        'cmdPropShapeCombine
        '
        resources.ApplyResources(Me.cmdPropShapeCombine, "cmdPropShapeCombine")
        Me.cmdPropShapeCombine.Name = "cmdPropShapeCombine"
        Me.tipDefault.SetToolTip(Me.cmdPropShapeCombine, resources.GetString("cmdPropShapeCombine.ToolTip"))
        Me.cmdPropShapeCombine.UseVisualStyleBackColor = True
        '
        'pnlPropShapeSequences
        '
        Me.pnlPropShapeSequences.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropShapeSequences.Controls.Add(Me.cmdPropShapeRevertAllSequences)
        Me.pnlPropShapeSequences.Controls.Add(Me.lblPropLinePointReductionUM)
        Me.pnlPropShapeSequences.Controls.Add(Me.lblPropLinePointReduction)
        Me.pnlPropShapeSequences.Controls.Add(Me.txtPropLinePointReductionFactor)
        Me.pnlPropShapeSequences.Controls.Add(Me.cmdPropLinePointReduction)
        Me.pnlPropShapeSequences.Controls.Add(Me.lblPropSequence)
        Me.pnlPropShapeSequences.Controls.Add(Me.cmdPropShapeReorderSequence)
        Me.pnlPropShapeSequences.Controls.Add(Me.cmdPropShapeCloseAllSequences)
        Me.pnlPropShapeSequences.Controls.Add(Me.cmdPropShapeCombineAllSequences)
        resources.ApplyResources(Me.pnlPropShapeSequences, "pnlPropShapeSequences")
        Me.pnlPropShapeSequences.Name = "pnlPropShapeSequences"
        '
        'cmdPropShapeRevertAllSequences
        '
        resources.ApplyResources(Me.cmdPropShapeRevertAllSequences, "cmdPropShapeRevertAllSequences")
        Me.cmdPropShapeRevertAllSequences.Name = "cmdPropShapeRevertAllSequences"
        Me.tipDefault.SetToolTip(Me.cmdPropShapeRevertAllSequences, resources.GetString("cmdPropShapeRevertAllSequences.ToolTip"))
        Me.cmdPropShapeRevertAllSequences.UseVisualStyleBackColor = True
        '
        'lblPropLinePointReductionUM
        '
        resources.ApplyResources(Me.lblPropLinePointReductionUM, "lblPropLinePointReductionUM")
        Me.lblPropLinePointReductionUM.Name = "lblPropLinePointReductionUM"
        '
        'lblPropLinePointReduction
        '
        resources.ApplyResources(Me.lblPropLinePointReduction, "lblPropLinePointReduction")
        Me.lblPropLinePointReduction.Name = "lblPropLinePointReduction"
        '
        'txtPropLinePointReductionFactor
        '
        Me.txtPropLinePointReductionFactor.DecimalPlaces = 2
        Me.txtPropLinePointReductionFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropLinePointReductionFactor, "txtPropLinePointReductionFactor")
        Me.txtPropLinePointReductionFactor.Maximum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.txtPropLinePointReductionFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtPropLinePointReductionFactor.Name = "txtPropLinePointReductionFactor"
        Me.tipDefault.SetToolTip(Me.txtPropLinePointReductionFactor, resources.GetString("txtPropLinePointReductionFactor.ToolTip"))
        Me.txtPropLinePointReductionFactor.Value = New Decimal(New Integer() {10, 0, 0, 131072})
        '
        'cmdPropLinePointReduction
        '
        resources.ApplyResources(Me.cmdPropLinePointReduction, "cmdPropLinePointReduction")
        Me.cmdPropLinePointReduction.Name = "cmdPropLinePointReduction"
        Me.tipDefault.SetToolTip(Me.cmdPropLinePointReduction, resources.GetString("cmdPropLinePointReduction.ToolTip"))
        Me.cmdPropLinePointReduction.UseVisualStyleBackColor = True
        '
        'lblPropSequence
        '
        resources.ApplyResources(Me.lblPropSequence, "lblPropSequence")
        Me.lblPropSequence.Name = "lblPropSequence"
        '
        'cmdPropShapeReorderSequence
        '
        resources.ApplyResources(Me.cmdPropShapeReorderSequence, "cmdPropShapeReorderSequence")
        Me.cmdPropShapeReorderSequence.Name = "cmdPropShapeReorderSequence"
        Me.tipDefault.SetToolTip(Me.cmdPropShapeReorderSequence, resources.GetString("cmdPropShapeReorderSequence.ToolTip"))
        Me.cmdPropShapeReorderSequence.UseVisualStyleBackColor = True
        '
        'cmdPropShapeCloseAllSequences
        '
        resources.ApplyResources(Me.cmdPropShapeCloseAllSequences, "cmdPropShapeCloseAllSequences")
        Me.cmdPropShapeCloseAllSequences.Name = "cmdPropShapeCloseAllSequences"
        Me.tipDefault.SetToolTip(Me.cmdPropShapeCloseAllSequences, resources.GetString("cmdPropShapeCloseAllSequences.ToolTip"))
        Me.cmdPropShapeCloseAllSequences.UseVisualStyleBackColor = True
        '
        'cmdPropShapeCombineAllSequences
        '
        resources.ApplyResources(Me.cmdPropShapeCombineAllSequences, "cmdPropShapeCombineAllSequences")
        Me.cmdPropShapeCombineAllSequences.Name = "cmdPropShapeCombineAllSequences"
        Me.tipDefault.SetToolTip(Me.cmdPropShapeCombineAllSequences, resources.GetString("cmdPropShapeCombineAllSequences.ToolTip"))
        Me.cmdPropShapeCombineAllSequences.UseVisualStyleBackColor = True
        '
        'pnlPropSign
        '
        Me.pnlPropSign.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropSign.Controls.Add(Me.cmdPropSignOtherOptions)
        Me.pnlPropSign.Controls.Add(Me.cboPropSign)
        Me.pnlPropSign.Controls.Add(Me.lblPropSign)
        Me.pnlPropSign.Controls.Add(Me.cboPropSignSize)
        Me.pnlPropSign.Controls.Add(Me.lblPropSignSize)
        Me.pnlPropSign.Controls.Add(Me.cboPropSignRotateMode)
        Me.pnlPropSign.Controls.Add(Me.lblPropSignRotateMode)
        resources.ApplyResources(Me.pnlPropSign, "pnlPropSign")
        Me.pnlPropSign.Name = "pnlPropSign"
        '
        'cmdPropSignOtherOptions
        '
        resources.ApplyResources(Me.cmdPropSignOtherOptions, "cmdPropSignOtherOptions")
        Me.cmdPropSignOtherOptions.Name = "cmdPropSignOtherOptions"
        Me.tipDefault.SetToolTip(Me.cmdPropSignOtherOptions, resources.GetString("cmdPropSignOtherOptions.ToolTip"))
        Me.cmdPropSignOtherOptions.UseVisualStyleBackColor = True
        '
        'cboPropSign
        '
        resources.ApplyResources(Me.cboPropSign, "cboPropSign")
        Me.cboPropSign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropSign.Name = "cboPropSign"
        Me.tipDefault.SetToolTip(Me.cboPropSign, resources.GetString("cboPropSign.ToolTip"))
        '
        'lblPropSign
        '
        resources.ApplyResources(Me.lblPropSign, "lblPropSign")
        Me.lblPropSign.Name = "lblPropSign"
        '
        'cboPropSignSize
        '
        Me.cboPropSignSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropSignSize.FormattingEnabled = True
        Me.cboPropSignSize.Items.AddRange(New Object() {resources.GetString("cboPropSignSize.Items"), resources.GetString("cboPropSignSize.Items1"), resources.GetString("cboPropSignSize.Items2"), resources.GetString("cboPropSignSize.Items3"), resources.GetString("cboPropSignSize.Items4"), resources.GetString("cboPropSignSize.Items5"), resources.GetString("cboPropSignSize.Items6"), resources.GetString("cboPropSignSize.Items7"), resources.GetString("cboPropSignSize.Items8"), resources.GetString("cboPropSignSize.Items9"), resources.GetString("cboPropSignSize.Items10")})
        resources.ApplyResources(Me.cboPropSignSize, "cboPropSignSize")
        Me.cboPropSignSize.Name = "cboPropSignSize"
        Me.tipDefault.SetToolTip(Me.cboPropSignSize, resources.GetString("cboPropSignSize.ToolTip"))
        '
        'lblPropSignSize
        '
        resources.ApplyResources(Me.lblPropSignSize, "lblPropSignSize")
        Me.lblPropSignSize.Name = "lblPropSignSize"
        '
        'cboPropSignRotateMode
        '
        Me.cboPropSignRotateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropSignRotateMode.FormattingEnabled = True
        Me.cboPropSignRotateMode.Items.AddRange(New Object() {resources.GetString("cboPropSignRotateMode.Items"), resources.GetString("cboPropSignRotateMode.Items1")})
        resources.ApplyResources(Me.cboPropSignRotateMode, "cboPropSignRotateMode")
        Me.cboPropSignRotateMode.Name = "cboPropSignRotateMode"
        Me.tipDefault.SetToolTip(Me.cboPropSignRotateMode, resources.GetString("cboPropSignRotateMode.ToolTip"))
        '
        'lblPropSignRotateMode
        '
        resources.ApplyResources(Me.lblPropSignRotateMode, "lblPropSignRotateMode")
        Me.lblPropSignRotateMode.Name = "lblPropSignRotateMode"
        '
        'pnlPropImage
        '
        resources.ApplyResources(Me.pnlPropImage, "pnlPropImage")
        Me.pnlPropImage.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropImage.Controls.Add(Me.cmdPropImageView)
        Me.pnlPropImage.Controls.Add(Me.Label34)
        Me.pnlPropImage.Controls.Add(Me.txtPropImageScaleFree)
        Me.pnlPropImage.Controls.Add(Me.cmdPropImageScale500)
        Me.pnlPropImage.Controls.Add(Me.cmdPropImageScale250)
        Me.pnlPropImage.Controls.Add(Me.cmdPropImageScale100)
        Me.pnlPropImage.Controls.Add(Me.txtPropImageResolution)
        Me.pnlPropImage.Controls.Add(Me.Label33)
        Me.pnlPropImage.Controls.Add(Me.cboPropImageResizeMode)
        Me.pnlPropImage.Controls.Add(Me.Label16)
        Me.pnlPropImage.Controls.Add(Me.picPropImage)
        Me.pnlPropImage.Controls.Add(Me.cmdPropImageBrowse)
        Me.pnlPropImage.Controls.Add(Me.Label32)
        Me.pnlPropImage.Name = "pnlPropImage"
        '
        'cmdPropImageView
        '
        resources.ApplyResources(Me.cmdPropImageView, "cmdPropImageView")
        Me.cmdPropImageView.Name = "cmdPropImageView"
        Me.tipDefault.SetToolTip(Me.cmdPropImageView, resources.GetString("cmdPropImageView.ToolTip"))
        Me.cmdPropImageView.UseVisualStyleBackColor = True
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.Name = "Label34"
        '
        'txtPropImageScaleFree
        '
        resources.ApplyResources(Me.txtPropImageScaleFree, "txtPropImageScaleFree")
        Me.txtPropImageScaleFree.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropImageScaleFree.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropImageScaleFree.Name = "txtPropImageScaleFree"
        Me.tipDefault.SetToolTip(Me.txtPropImageScaleFree, resources.GetString("txtPropImageScaleFree.ToolTip"))
        Me.txtPropImageScaleFree.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cmdPropImageScale500
        '
        resources.ApplyResources(Me.cmdPropImageScale500, "cmdPropImageScale500")
        Me.cmdPropImageScale500.Name = "cmdPropImageScale500"
        Me.tipDefault.SetToolTip(Me.cmdPropImageScale500, resources.GetString("cmdPropImageScale500.ToolTip"))
        Me.cmdPropImageScale500.UseVisualStyleBackColor = True
        '
        'cmdPropImageScale250
        '
        resources.ApplyResources(Me.cmdPropImageScale250, "cmdPropImageScale250")
        Me.cmdPropImageScale250.Name = "cmdPropImageScale250"
        Me.tipDefault.SetToolTip(Me.cmdPropImageScale250, resources.GetString("cmdPropImageScale250.ToolTip"))
        Me.cmdPropImageScale250.UseVisualStyleBackColor = True
        '
        'cmdPropImageScale100
        '
        resources.ApplyResources(Me.cmdPropImageScale100, "cmdPropImageScale100")
        Me.cmdPropImageScale100.Name = "cmdPropImageScale100"
        Me.tipDefault.SetToolTip(Me.cmdPropImageScale100, resources.GetString("cmdPropImageScale100.ToolTip"))
        Me.cmdPropImageScale100.UseVisualStyleBackColor = True
        '
        'txtPropImageResolution
        '
        resources.ApplyResources(Me.txtPropImageResolution, "txtPropImageResolution")
        Me.txtPropImageResolution.Name = "txtPropImageResolution"
        Me.txtPropImageResolution.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtPropImageResolution, resources.GetString("txtPropImageResolution.ToolTip"))
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.Name = "Label33"
        '
        'cboPropImageResizeMode
        '
        Me.cboPropImageResizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropImageResizeMode.FormattingEnabled = True
        Me.cboPropImageResizeMode.Items.AddRange(New Object() {resources.GetString("cboPropImageResizeMode.Items"), resources.GetString("cboPropImageResizeMode.Items1")})
        resources.ApplyResources(Me.cboPropImageResizeMode, "cboPropImageResizeMode")
        Me.cboPropImageResizeMode.Name = "cboPropImageResizeMode"
        Me.tipDefault.SetToolTip(Me.cboPropImageResizeMode, resources.GetString("cboPropImageResizeMode.ToolTip"))
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'picPropImage
        '
        resources.ApplyResources(Me.picPropImage, "picPropImage")
        Me.picPropImage.Name = "picPropImage"
        Me.picPropImage.TabStop = False
        '
        'cmdPropImageBrowse
        '
        resources.ApplyResources(Me.cmdPropImageBrowse, "cmdPropImageBrowse")
        Me.cmdPropImageBrowse.Name = "cmdPropImageBrowse"
        Me.tipDefault.SetToolTip(Me.cmdPropImageBrowse, resources.GetString("cmdPropImageBrowse.ToolTip"))
        Me.cmdPropImageBrowse.UseVisualStyleBackColor = True
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'pnlPropInfo
        '
        resources.ApplyResources(Me.pnlPropInfo, "pnlPropInfo")
        Me.pnlPropInfo.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropInfo.Controls.Add(Me.cboPropBindCrossSections)
        Me.pnlPropInfo.Controls.Add(Me.lblPropBindCrossSections)
        Me.pnlPropInfo.Controls.Add(Me.pnlPropCaveBranches)
        Me.pnlPropInfo.Controls.Add(Me.txtPropPointType)
        Me.pnlPropInfo.Controls.Add(Me.lblPropPointType)
        Me.pnlPropInfo.Controls.Add(Me.cboPropBindDesignType)
        Me.pnlPropInfo.Controls.Add(Me.lblPropBindDesignType)
        Me.pnlPropInfo.Controls.Add(Me.cmdPropParent)
        Me.pnlPropInfo.Controls.Add(Me.cmdPropNext)
        Me.pnlPropInfo.Controls.Add(Me.cmdPropPrev)
        Me.pnlPropInfo.Controls.Add(Me.optPropObjectSequence)
        Me.pnlPropInfo.Controls.Add(Me.optPropObject)
        Me.pnlPropInfo.Name = "pnlPropInfo"
        '
        'cboPropBindCrossSections
        '
        resources.ApplyResources(Me.cboPropBindCrossSections, "cboPropBindCrossSections")
        Me.cboPropBindCrossSections.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropBindCrossSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBindCrossSections.DropDownWidth = 420
        Me.cboPropBindCrossSections.Name = "cboPropBindCrossSections"
        Me.tipDefault.SetToolTip(Me.cboPropBindCrossSections, resources.GetString("cboPropBindCrossSections.ToolTip"))
        '
        'lblPropBindCrossSections
        '
        resources.ApplyResources(Me.lblPropBindCrossSections, "lblPropBindCrossSections")
        Me.lblPropBindCrossSections.Name = "lblPropBindCrossSections"
        '
        'pnlPropCaveBranches
        '
        resources.ApplyResources(Me.pnlPropCaveBranches, "pnlPropCaveBranches")
        Me.pnlPropCaveBranches.Controls.Add(Me.pnlPropCaveBranchesColor)
        Me.pnlPropCaveBranches.Controls.Add(Me.cmdPropSetCurrentCaveBranch)
        Me.pnlPropCaveBranches.Controls.Add(Me.cmdPropSetCaveBranch)
        Me.pnlPropCaveBranches.Controls.Add(Me.cboPropCaveBranchList)
        Me.pnlPropCaveBranches.Controls.Add(Me.lblPropBranchList)
        Me.pnlPropCaveBranches.Controls.Add(Me.cboPropCaveList)
        Me.pnlPropCaveBranches.Controls.Add(Me.lblPropCaveList)
        Me.pnlPropCaveBranches.Name = "pnlPropCaveBranches"
        '
        'pnlPropCaveBranchesColor
        '
        resources.ApplyResources(Me.pnlPropCaveBranchesColor, "pnlPropCaveBranchesColor")
        Me.pnlPropCaveBranchesColor.Name = "pnlPropCaveBranchesColor"
        '
        'cmdPropSetCurrentCaveBranch
        '
        resources.ApplyResources(Me.cmdPropSetCurrentCaveBranch, "cmdPropSetCurrentCaveBranch")
        Me.cmdPropSetCurrentCaveBranch.Name = "cmdPropSetCurrentCaveBranch"
        Me.tipDefault.SetToolTip(Me.cmdPropSetCurrentCaveBranch, resources.GetString("cmdPropSetCurrentCaveBranch.ToolTip"))
        Me.cmdPropSetCurrentCaveBranch.UseVisualStyleBackColor = True
        '
        'cmdPropSetCaveBranch
        '
        resources.ApplyResources(Me.cmdPropSetCaveBranch, "cmdPropSetCaveBranch")
        Me.cmdPropSetCaveBranch.Name = "cmdPropSetCaveBranch"
        Me.tipDefault.SetToolTip(Me.cmdPropSetCaveBranch, resources.GetString("cmdPropSetCaveBranch.ToolTip"))
        Me.cmdPropSetCaveBranch.UseVisualStyleBackColor = True
        '
        'cboPropCaveBranchList
        '
        resources.ApplyResources(Me.cboPropCaveBranchList, "cboPropCaveBranchList")
        Me.cboPropCaveBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropCaveBranchList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropCaveBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropCaveBranchList.DropDownWidth = 420
        Me.cboPropCaveBranchList.Name = "cboPropCaveBranchList"
        Me.tipDefault.SetToolTip(Me.cboPropCaveBranchList, resources.GetString("cboPropCaveBranchList.ToolTip"))
        Me.cboPropCaveBranchList.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'lblPropBranchList
        '
        resources.ApplyResources(Me.lblPropBranchList, "lblPropBranchList")
        Me.lblPropBranchList.Name = "lblPropBranchList"
        '
        'cboPropCaveList
        '
        resources.ApplyResources(Me.cboPropCaveList, "cboPropCaveList")
        Me.cboPropCaveList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropCaveList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropCaveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropCaveList.DropDownWidth = 420
        Me.cboPropCaveList.Name = "cboPropCaveList"
        Me.tipDefault.SetToolTip(Me.cboPropCaveList, resources.GetString("cboPropCaveList.ToolTip"))
        Me.cboPropCaveList.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'lblPropCaveList
        '
        resources.ApplyResources(Me.lblPropCaveList, "lblPropCaveList")
        Me.lblPropCaveList.Name = "lblPropCaveList"
        '
        'txtPropPointType
        '
        resources.ApplyResources(Me.txtPropPointType, "txtPropPointType")
        Me.txtPropPointType.Name = "txtPropPointType"
        Me.txtPropPointType.ReadOnly = True
        '
        'lblPropPointType
        '
        resources.ApplyResources(Me.lblPropPointType, "lblPropPointType")
        Me.lblPropPointType.Name = "lblPropPointType"
        '
        'cboPropBindDesignType
        '
        resources.ApplyResources(Me.cboPropBindDesignType, "cboPropBindDesignType")
        Me.cboPropBindDesignType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropBindDesignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBindDesignType.DropDownWidth = 240
        Me.cboPropBindDesignType.Items.AddRange(New Object() {resources.GetString("cboPropBindDesignType.Items"), resources.GetString("cboPropBindDesignType.Items1")})
        Me.cboPropBindDesignType.Name = "cboPropBindDesignType"
        Me.tipDefault.SetToolTip(Me.cboPropBindDesignType, resources.GetString("cboPropBindDesignType.ToolTip"))
        '
        'lblPropBindDesignType
        '
        resources.ApplyResources(Me.lblPropBindDesignType, "lblPropBindDesignType")
        Me.lblPropBindDesignType.Name = "lblPropBindDesignType"
        '
        'cmdPropParent
        '
        resources.ApplyResources(Me.cmdPropParent, "cmdPropParent")
        Me.cmdPropParent.Name = "cmdPropParent"
        Me.tipDefault.SetToolTip(Me.cmdPropParent, resources.GetString("cmdPropParent.ToolTip"))
        Me.cmdPropParent.UseVisualStyleBackColor = True
        '
        'cmdPropNext
        '
        resources.ApplyResources(Me.cmdPropNext, "cmdPropNext")
        Me.cmdPropNext.Name = "cmdPropNext"
        Me.tipDefault.SetToolTip(Me.cmdPropNext, resources.GetString("cmdPropNext.ToolTip"))
        Me.cmdPropNext.UseVisualStyleBackColor = True
        '
        'cmdPropPrev
        '
        resources.ApplyResources(Me.cmdPropPrev, "cmdPropPrev")
        Me.cmdPropPrev.Name = "cmdPropPrev"
        Me.tipDefault.SetToolTip(Me.cmdPropPrev, resources.GetString("cmdPropPrev.ToolTip"))
        Me.cmdPropPrev.UseVisualStyleBackColor = True
        '
        'optPropObjectSequence
        '
        resources.ApplyResources(Me.optPropObjectSequence, "optPropObjectSequence")
        Me.optPropObjectSequence.Name = "optPropObjectSequence"
        Me.tipDefault.SetToolTip(Me.optPropObjectSequence, resources.GetString("optPropObjectSequence.ToolTip"))
        Me.optPropObjectSequence.UseVisualStyleBackColor = True
        '
        'optPropObject
        '
        resources.ApplyResources(Me.optPropObject, "optPropObject")
        Me.optPropObject.Checked = True
        Me.optPropObject.Name = "optPropObject"
        Me.optPropObject.TabStop = True
        Me.tipDefault.SetToolTip(Me.optPropObject, resources.GetString("optPropObject.ToolTip"))
        Me.optPropObject.UseVisualStyleBackColor = True
        '
        'pnlPropPen
        '
        resources.ApplyResources(Me.pnlPropPen, "pnlPropPen")
        Me.pnlPropPen.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropPen.Controls.Add(Me.tblPropPen)
        Me.pnlPropPen.Name = "pnlPropPen"
        '
        'tblPropPen
        '
        resources.ApplyResources(Me.tblPropPen, "tblPropPen")
        Me.tblPropPen.BackColor = System.Drawing.Color.Transparent
        Me.tblPropPen.Controls.Add(Me.pnlPropPenGeneric, 0, 0)
        Me.tblPropPen.Controls.Add(Me.pnlPropPenCustom, 0, 1)
        Me.tblPropPen.Name = "tblPropPen"
        '
        'pnlPropPenGeneric
        '
        resources.ApplyResources(Me.pnlPropPenGeneric, "pnlPropPenGeneric")
        Me.pnlPropPenGeneric.Controls.Add(Me.cboPropPenPattern)
        Me.pnlPropPenGeneric.Controls.Add(Me.lblPropPenPattern)
        Me.pnlPropPenGeneric.Name = "pnlPropPenGeneric"
        '
        'cboPropPenPattern
        '
        resources.ApplyResources(Me.cboPropPenPattern, "cboPropPenPattern")
        Me.cboPropPenPattern.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropPenPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropPenPattern.FormattingEnabled = True
        Me.cboPropPenPattern.Name = "cboPropPenPattern"
        Me.tipDefault.SetToolTip(Me.cboPropPenPattern, resources.GetString("cboPropPenPattern.ToolTip"))
        '
        'lblPropPenPattern
        '
        resources.ApplyResources(Me.lblPropPenPattern, "lblPropPenPattern")
        Me.lblPropPenPattern.Name = "lblPropPenPattern"
        '
        'pnlPropPenCustom
        '
        resources.ApplyResources(Me.pnlPropPenCustom, "pnlPropPenCustom")
        Me.pnlPropPenCustom.Controls.Add(Me.Label45)
        Me.pnlPropPenCustom.Controls.Add(Me.txtPropPenDecorationScale)
        Me.pnlPropPenCustom.Controls.Add(Me.Label46)
        Me.pnlPropPenCustom.Controls.Add(Me.cboPropPenStyle)
        Me.pnlPropPenCustom.Controls.Add(Me.txtPropPenWidth)
        Me.pnlPropPenCustom.Controls.Add(Me.txtPropPenDecorationSpacePercentage)
        Me.pnlPropPenCustom.Controls.Add(Me.Label20)
        Me.pnlPropPenCustom.Controls.Add(Me.cboPropPenDecorationAlignment)
        Me.pnlPropPenCustom.Controls.Add(Me.Label18)
        Me.pnlPropPenCustom.Controls.Add(Me.Label30)
        Me.pnlPropPenCustom.Controls.Add(Me.cmdPropPenColorBrowse)
        Me.pnlPropPenCustom.Controls.Add(Me.picPropPenColor)
        Me.pnlPropPenCustom.Controls.Add(Me.Label29)
        Me.pnlPropPenCustom.Controls.Add(Me.Label28)
        Me.pnlPropPenCustom.Controls.Add(Me.cboPropPenDecoration)
        Me.pnlPropPenCustom.Name = "pnlPropPenCustom"
        '
        'Label45
        '
        resources.ApplyResources(Me.Label45, "Label45")
        Me.Label45.Name = "Label45"
        '
        'txtPropPenDecorationScale
        '
        resources.ApplyResources(Me.txtPropPenDecorationScale, "txtPropPenDecorationScale")
        Me.txtPropPenDecorationScale.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPenDecorationScale.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropPenDecorationScale.Name = "txtPropPenDecorationScale"
        Me.tipDefault.SetToolTip(Me.txtPropPenDecorationScale, resources.GetString("txtPropPenDecorationScale.ToolTip"))
        Me.txtPropPenDecorationScale.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label46
        '
        resources.ApplyResources(Me.Label46, "Label46")
        Me.Label46.Name = "Label46"
        '
        'cboPropPenStyle
        '
        Me.cboPropPenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropPenStyle.FormattingEnabled = True
        Me.cboPropPenStyle.Items.AddRange(New Object() {resources.GetString("cboPropPenStyle.Items"), resources.GetString("cboPropPenStyle.Items1"), resources.GetString("cboPropPenStyle.Items2"), resources.GetString("cboPropPenStyle.Items3"), resources.GetString("cboPropPenStyle.Items4"), resources.GetString("cboPropPenStyle.Items5"), resources.GetString("cboPropPenStyle.Items6"), resources.GetString("cboPropPenStyle.Items7")})
        resources.ApplyResources(Me.cboPropPenStyle, "cboPropPenStyle")
        Me.cboPropPenStyle.Name = "cboPropPenStyle"
        Me.tipDefault.SetToolTip(Me.cboPropPenStyle, resources.GetString("cboPropPenStyle.ToolTip"))
        '
        'txtPropPenWidth
        '
        resources.ApplyResources(Me.txtPropPenWidth, "txtPropPenWidth")
        Me.txtPropPenWidth.Name = "txtPropPenWidth"
        Me.tipDefault.SetToolTip(Me.txtPropPenWidth, resources.GetString("txtPropPenWidth.ToolTip"))
        '
        'txtPropPenDecorationSpacePercentage
        '
        resources.ApplyResources(Me.txtPropPenDecorationSpacePercentage, "txtPropPenDecorationSpacePercentage")
        Me.txtPropPenDecorationSpacePercentage.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPenDecorationSpacePercentage.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.txtPropPenDecorationSpacePercentage.Name = "txtPropPenDecorationSpacePercentage"
        Me.tipDefault.SetToolTip(Me.txtPropPenDecorationSpacePercentage, resources.GetString("txtPropPenDecorationSpacePercentage.ToolTip"))
        Me.txtPropPenDecorationSpacePercentage.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'cboPropPenDecorationAlignment
        '
        Me.cboPropPenDecorationAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropPenDecorationAlignment.FormattingEnabled = True
        Me.cboPropPenDecorationAlignment.Items.AddRange(New Object() {resources.GetString("cboPropPenDecorationAlignment.Items"), resources.GetString("cboPropPenDecorationAlignment.Items1"), resources.GetString("cboPropPenDecorationAlignment.Items2")})
        resources.ApplyResources(Me.cboPropPenDecorationAlignment, "cboPropPenDecorationAlignment")
        Me.cboPropPenDecorationAlignment.Name = "cboPropPenDecorationAlignment"
        Me.tipDefault.SetToolTip(Me.cboPropPenDecorationAlignment, resources.GetString("cboPropPenDecorationAlignment.ToolTip"))
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.Name = "Label30"
        '
        'cmdPropPenColorBrowse
        '
        resources.ApplyResources(Me.cmdPropPenColorBrowse, "cmdPropPenColorBrowse")
        Me.cmdPropPenColorBrowse.Name = "cmdPropPenColorBrowse"
        Me.tipDefault.SetToolTip(Me.cmdPropPenColorBrowse, resources.GetString("cmdPropPenColorBrowse.ToolTip"))
        Me.cmdPropPenColorBrowse.UseVisualStyleBackColor = True
        '
        'picPropPenColor
        '
        resources.ApplyResources(Me.picPropPenColor, "picPropPenColor")
        Me.picPropPenColor.Name = "picPropPenColor"
        Me.picPropPenColor.TabStop = False
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'cboPropPenDecoration
        '
        Me.cboPropPenDecoration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropPenDecoration.FormattingEnabled = True
        Me.cboPropPenDecoration.Items.AddRange(New Object() {resources.GetString("cboPropPenDecoration.Items"), resources.GetString("cboPropPenDecoration.Items1"), resources.GetString("cboPropPenDecoration.Items2"), resources.GetString("cboPropPenDecoration.Items3"), resources.GetString("cboPropPenDecoration.Items4"), resources.GetString("cboPropPenDecoration.Items5"), resources.GetString("cboPropPenDecoration.Items6"), resources.GetString("cboPropPenDecoration.Items7"), resources.GetString("cboPropPenDecoration.Items8"), resources.GetString("cboPropPenDecoration.Items9")})
        resources.ApplyResources(Me.cboPropPenDecoration, "cboPropPenDecoration")
        Me.cboPropPenDecoration.Name = "cboPropPenDecoration"
        Me.tipDefault.SetToolTip(Me.cboPropPenDecoration, resources.GetString("cboPropPenDecoration.ToolTip"))
        '
        'pnlPropSize
        '
        Me.pnlPropSize.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropSize.Controls.Add(Me.Label26)
        Me.pnlPropSize.Controls.Add(Me.txtPropScaleHeight)
        Me.pnlPropSize.Controls.Add(Me.Label36)
        Me.pnlPropSize.Controls.Add(Me.Label35)
        Me.pnlPropSize.Controls.Add(Me.txtPropScaleWidth)
        Me.pnlPropSize.Controls.Add(Me.cmdPropFlipV)
        Me.pnlPropSize.Controls.Add(Me.cmdPropFlipH)
        Me.pnlPropSize.Controls.Add(Me.txtPropWidth)
        Me.pnlPropSize.Controls.Add(Me.txtPropHeight)
        Me.pnlPropSize.Controls.Add(Me.lblPropWidthUM)
        Me.pnlPropSize.Controls.Add(Me.lblPropHeightUM)
        Me.pnlPropSize.Controls.Add(Me.Label14)
        resources.ApplyResources(Me.pnlPropSize, "pnlPropSize")
        Me.pnlPropSize.Name = "pnlPropSize"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'txtPropScaleHeight
        '
        resources.ApplyResources(Me.txtPropScaleHeight, "txtPropScaleHeight")
        Me.txtPropScaleHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropScaleHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropScaleHeight.Name = "txtPropScaleHeight"
        Me.tipDefault.SetToolTip(Me.txtPropScaleHeight, resources.GetString("txtPropScaleHeight.ToolTip"))
        Me.txtPropScaleHeight.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label36
        '
        resources.ApplyResources(Me.Label36, "Label36")
        Me.Label36.Name = "Label36"
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.Name = "Label35"
        '
        'txtPropScaleWidth
        '
        resources.ApplyResources(Me.txtPropScaleWidth, "txtPropScaleWidth")
        Me.txtPropScaleWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropScaleWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropScaleWidth.Name = "txtPropScaleWidth"
        Me.tipDefault.SetToolTip(Me.txtPropScaleWidth, resources.GetString("txtPropScaleWidth.ToolTip"))
        Me.txtPropScaleWidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'cmdPropFlipV
        '
        resources.ApplyResources(Me.cmdPropFlipV, "cmdPropFlipV")
        Me.cmdPropFlipV.Name = "cmdPropFlipV"
        Me.tipDefault.SetToolTip(Me.cmdPropFlipV, resources.GetString("cmdPropFlipV.ToolTip"))
        Me.cmdPropFlipV.UseVisualStyleBackColor = True
        '
        'cmdPropFlipH
        '
        resources.ApplyResources(Me.cmdPropFlipH, "cmdPropFlipH")
        Me.cmdPropFlipH.Name = "cmdPropFlipH"
        Me.tipDefault.SetToolTip(Me.cmdPropFlipH, resources.GetString("cmdPropFlipH.ToolTip"))
        Me.cmdPropFlipH.UseVisualStyleBackColor = True
        '
        'txtPropWidth
        '
        resources.ApplyResources(Me.txtPropWidth, "txtPropWidth")
        Me.txtPropWidth.Name = "txtPropWidth"
        Me.tipDefault.SetToolTip(Me.txtPropWidth, resources.GetString("txtPropWidth.ToolTip"))
        '
        'txtPropHeight
        '
        resources.ApplyResources(Me.txtPropHeight, "txtPropHeight")
        Me.txtPropHeight.Name = "txtPropHeight"
        Me.tipDefault.SetToolTip(Me.txtPropHeight, resources.GetString("txtPropHeight.ToolTip"))
        '
        'lblPropWidthUM
        '
        resources.ApplyResources(Me.lblPropWidthUM, "lblPropWidthUM")
        Me.lblPropWidthUM.Name = "lblPropWidthUM"
        '
        'lblPropHeightUM
        '
        resources.ApplyResources(Me.lblPropHeightUM, "lblPropHeightUM")
        Me.lblPropHeightUM.Name = "lblPropHeightUM"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'pnlPropPosition
        '
        Me.pnlPropPosition.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropPosition.Controls.Add(Me.pnlPropPositionSubPanel1)
        Me.pnlPropPosition.Controls.Add(Me.cmdPropMoveRight)
        Me.pnlPropPosition.Controls.Add(Me.cmdPropMoveBottom)
        Me.pnlPropPosition.Controls.Add(Me.cmdPropMoveLeft)
        Me.pnlPropPosition.Controls.Add(Me.cmdPropMoveTop)
        Me.pnlPropPosition.Controls.Add(Me.txtPropLeft)
        Me.pnlPropPosition.Controls.Add(Me.txtPropTop)
        Me.pnlPropPosition.Controls.Add(Me.lblPropLeftUM)
        Me.pnlPropPosition.Controls.Add(Me.lblPropTopUM)
        Me.pnlPropPosition.Controls.Add(Me.lblPropPosition)
        resources.ApplyResources(Me.pnlPropPosition, "pnlPropPosition")
        Me.pnlPropPosition.Name = "pnlPropPosition"
        '
        'pnlPropPositionSubPanel1
        '
        Me.pnlPropPositionSubPanel1.Controls.Add(Me.chkPropLock)
        Me.pnlPropPositionSubPanel1.Controls.Add(Me.cmdPropBringOnTop)
        Me.pnlPropPositionSubPanel1.Controls.Add(Me.cmdPropBringAhead)
        Me.pnlPropPositionSubPanel1.Controls.Add(Me.cmdPropSendBehind)
        Me.pnlPropPositionSubPanel1.Controls.Add(Me.cmdPropSendToBottom)
        resources.ApplyResources(Me.pnlPropPositionSubPanel1, "pnlPropPositionSubPanel1")
        Me.pnlPropPositionSubPanel1.Name = "pnlPropPositionSubPanel1"
        '
        'chkPropLock
        '
        resources.ApplyResources(Me.chkPropLock, "chkPropLock")
        Me.chkPropLock.Name = "chkPropLock"
        Me.tipDefault.SetToolTip(Me.chkPropLock, resources.GetString("chkPropLock.ToolTip"))
        Me.chkPropLock.UseVisualStyleBackColor = True
        '
        'cmdPropBringOnTop
        '
        resources.ApplyResources(Me.cmdPropBringOnTop, "cmdPropBringOnTop")
        Me.cmdPropBringOnTop.Name = "cmdPropBringOnTop"
        Me.tipDefault.SetToolTip(Me.cmdPropBringOnTop, resources.GetString("cmdPropBringOnTop.ToolTip"))
        Me.cmdPropBringOnTop.UseVisualStyleBackColor = True
        '
        'cmdPropBringAhead
        '
        resources.ApplyResources(Me.cmdPropBringAhead, "cmdPropBringAhead")
        Me.cmdPropBringAhead.Name = "cmdPropBringAhead"
        Me.tipDefault.SetToolTip(Me.cmdPropBringAhead, resources.GetString("cmdPropBringAhead.ToolTip"))
        Me.cmdPropBringAhead.UseVisualStyleBackColor = True
        '
        'cmdPropSendBehind
        '
        resources.ApplyResources(Me.cmdPropSendBehind, "cmdPropSendBehind")
        Me.cmdPropSendBehind.Name = "cmdPropSendBehind"
        Me.tipDefault.SetToolTip(Me.cmdPropSendBehind, resources.GetString("cmdPropSendBehind.ToolTip"))
        Me.cmdPropSendBehind.UseVisualStyleBackColor = True
        '
        'cmdPropSendToBottom
        '
        resources.ApplyResources(Me.cmdPropSendToBottom, "cmdPropSendToBottom")
        Me.cmdPropSendToBottom.Name = "cmdPropSendToBottom"
        Me.tipDefault.SetToolTip(Me.cmdPropSendToBottom, resources.GetString("cmdPropSendToBottom.ToolTip"))
        Me.cmdPropSendToBottom.UseVisualStyleBackColor = True
        '
        'cmdPropMoveRight
        '
        resources.ApplyResources(Me.cmdPropMoveRight, "cmdPropMoveRight")
        Me.cmdPropMoveRight.Name = "cmdPropMoveRight"
        Me.tipDefault.SetToolTip(Me.cmdPropMoveRight, resources.GetString("cmdPropMoveRight.ToolTip"))
        Me.cmdPropMoveRight.UseVisualStyleBackColor = True
        '
        'cmdPropMoveBottom
        '
        resources.ApplyResources(Me.cmdPropMoveBottom, "cmdPropMoveBottom")
        Me.cmdPropMoveBottom.Name = "cmdPropMoveBottom"
        Me.tipDefault.SetToolTip(Me.cmdPropMoveBottom, resources.GetString("cmdPropMoveBottom.ToolTip"))
        Me.cmdPropMoveBottom.UseVisualStyleBackColor = True
        '
        'cmdPropMoveLeft
        '
        resources.ApplyResources(Me.cmdPropMoveLeft, "cmdPropMoveLeft")
        Me.cmdPropMoveLeft.Name = "cmdPropMoveLeft"
        Me.tipDefault.SetToolTip(Me.cmdPropMoveLeft, resources.GetString("cmdPropMoveLeft.ToolTip"))
        Me.cmdPropMoveLeft.UseVisualStyleBackColor = True
        '
        'cmdPropMoveTop
        '
        resources.ApplyResources(Me.cmdPropMoveTop, "cmdPropMoveTop")
        Me.cmdPropMoveTop.Name = "cmdPropMoveTop"
        Me.tipDefault.SetToolTip(Me.cmdPropMoveTop, resources.GetString("cmdPropMoveTop.ToolTip"))
        Me.cmdPropMoveTop.UseVisualStyleBackColor = True
        '
        'txtPropLeft
        '
        resources.ApplyResources(Me.txtPropLeft, "txtPropLeft")
        Me.txtPropLeft.Name = "txtPropLeft"
        Me.tipDefault.SetToolTip(Me.txtPropLeft, resources.GetString("txtPropLeft.ToolTip"))
        '
        'txtPropTop
        '
        resources.ApplyResources(Me.txtPropTop, "txtPropTop")
        Me.txtPropTop.Name = "txtPropTop"
        Me.tipDefault.SetToolTip(Me.txtPropTop, resources.GetString("txtPropTop.ToolTip"))
        '
        'lblPropLeftUM
        '
        resources.ApplyResources(Me.lblPropLeftUM, "lblPropLeftUM")
        Me.lblPropLeftUM.Name = "lblPropLeftUM"
        '
        'lblPropTopUM
        '
        resources.ApplyResources(Me.lblPropTopUM, "lblPropTopUM")
        Me.lblPropTopUM.Name = "lblPropTopUM"
        '
        'lblPropPosition
        '
        resources.ApplyResources(Me.lblPropPosition, "lblPropPosition")
        Me.lblPropPosition.Name = "lblPropPosition"
        '
        'pnlPropRotation
        '
        Me.pnlPropRotation.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropRotation.Controls.Add(Me.cmdPropRotateLeftByDegree)
        Me.pnlPropRotation.Controls.Add(Me.cmdPropRotateRightByDegree)
        Me.pnlPropRotation.Controls.Add(Me.cmdPropRotateRight)
        Me.pnlPropRotation.Controls.Add(Me.cmdPropRotateLeft)
        Me.pnlPropRotation.Controls.Add(Me.txtPropRotate)
        Me.pnlPropRotation.Controls.Add(Me.Label24)
        Me.pnlPropRotation.Controls.Add(Me.Label25)
        resources.ApplyResources(Me.pnlPropRotation, "pnlPropRotation")
        Me.pnlPropRotation.Name = "pnlPropRotation"
        '
        'cmdPropRotateLeftByDegree
        '
        resources.ApplyResources(Me.cmdPropRotateLeftByDegree, "cmdPropRotateLeftByDegree")
        Me.cmdPropRotateLeftByDegree.Name = "cmdPropRotateLeftByDegree"
        Me.tipDefault.SetToolTip(Me.cmdPropRotateLeftByDegree, resources.GetString("cmdPropRotateLeftByDegree.ToolTip"))
        Me.cmdPropRotateLeftByDegree.UseVisualStyleBackColor = True
        '
        'cmdPropRotateRightByDegree
        '
        resources.ApplyResources(Me.cmdPropRotateRightByDegree, "cmdPropRotateRightByDegree")
        Me.cmdPropRotateRightByDegree.Name = "cmdPropRotateRightByDegree"
        Me.tipDefault.SetToolTip(Me.cmdPropRotateRightByDegree, resources.GetString("cmdPropRotateRightByDegree.ToolTip"))
        Me.cmdPropRotateRightByDegree.UseVisualStyleBackColor = True
        '
        'cmdPropRotateRight
        '
        resources.ApplyResources(Me.cmdPropRotateRight, "cmdPropRotateRight")
        Me.cmdPropRotateRight.Name = "cmdPropRotateRight"
        Me.tipDefault.SetToolTip(Me.cmdPropRotateRight, resources.GetString("cmdPropRotateRight.ToolTip"))
        Me.cmdPropRotateRight.UseVisualStyleBackColor = True
        '
        'cmdPropRotateLeft
        '
        resources.ApplyResources(Me.cmdPropRotateLeft, "cmdPropRotateLeft")
        Me.cmdPropRotateLeft.Name = "cmdPropRotateLeft"
        Me.tipDefault.SetToolTip(Me.cmdPropRotateLeft, resources.GetString("cmdPropRotateLeft.ToolTip"))
        Me.cmdPropRotateLeft.UseVisualStyleBackColor = True
        '
        'txtPropRotate
        '
        resources.ApplyResources(Me.txtPropRotate, "txtPropRotate")
        Me.txtPropRotate.Name = "txtPropRotate"
        Me.tipDefault.SetToolTip(Me.txtPropRotate, resources.GetString("txtPropRotate.ToolTip"))
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'pnlPropLineType
        '
        resources.ApplyResources(Me.pnlPropLineType, "pnlPropLineType")
        Me.pnlPropLineType.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropLineType.Controls.Add(Me.chkPropLineType2)
        Me.pnlPropLineType.Controls.Add(Me.chkPropLineType1)
        Me.pnlPropLineType.Controls.Add(Me.chkPropLineType0)
        Me.pnlPropLineType.Controls.Add(Me.lblPropLineType)
        Me.pnlPropLineType.Name = "pnlPropLineType"
        '
        'chkPropLineType2
        '
        resources.ApplyResources(Me.chkPropLineType2, "chkPropLineType2")
        Me.chkPropLineType2.Name = "chkPropLineType2"
        Me.chkPropLineType2.UseVisualStyleBackColor = True
        '
        'chkPropLineType1
        '
        resources.ApplyResources(Me.chkPropLineType1, "chkPropLineType1")
        Me.chkPropLineType1.Name = "chkPropLineType1"
        Me.chkPropLineType1.UseVisualStyleBackColor = True
        '
        'chkPropLineType0
        '
        resources.ApplyResources(Me.chkPropLineType0, "chkPropLineType0")
        Me.chkPropLineType0.Name = "chkPropLineType0"
        Me.chkPropLineType0.UseVisualStyleBackColor = True
        '
        'lblPropLineType
        '
        resources.ApplyResources(Me.lblPropLineType, "lblPropLineType")
        Me.lblPropLineType.Name = "lblPropLineType"
        '
        'pnlPropBrush
        '
        resources.ApplyResources(Me.pnlPropBrush, "pnlPropBrush")
        Me.pnlPropBrush.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropBrush.Controls.Add(Me.tblPropBrush)
        Me.pnlPropBrush.Name = "pnlPropBrush"
        '
        'tblPropBrush
        '
        Me.tblPropBrush.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.tblPropBrush, "tblPropBrush")
        Me.tblPropBrush.Controls.Add(Me.pnlPropBrushGeneric, 0, 0)
        Me.tblPropBrush.Controls.Add(Me.pnlPropBrushCustom, 0, 1)
        Me.tblPropBrush.Name = "tblPropBrush"
        '
        'pnlPropBrushGeneric
        '
        resources.ApplyResources(Me.pnlPropBrushGeneric, "pnlPropBrushGeneric")
        Me.pnlPropBrushGeneric.Controls.Add(Me.Label22)
        Me.pnlPropBrushGeneric.Controls.Add(Me.cboPropBrushPattern)
        Me.pnlPropBrushGeneric.Controls.Add(Me.cmdPropBrushReseed)
        Me.pnlPropBrushGeneric.Name = "pnlPropBrushGeneric"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'cboPropBrushPattern
        '
        resources.ApplyResources(Me.cboPropBrushPattern, "cboPropBrushPattern")
        Me.cboPropBrushPattern.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropBrushPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPattern.FormattingEnabled = True
        Me.cboPropBrushPattern.Items.AddRange(New Object() {resources.GetString("cboPropBrushPattern.Items"), resources.GetString("cboPropBrushPattern.Items1"), resources.GetString("cboPropBrushPattern.Items2"), resources.GetString("cboPropBrushPattern.Items3")})
        Me.cboPropBrushPattern.Name = "cboPropBrushPattern"
        Me.tipDefault.SetToolTip(Me.cboPropBrushPattern, resources.GetString("cboPropBrushPattern.ToolTip"))
        '
        'cmdPropBrushReseed
        '
        resources.ApplyResources(Me.cmdPropBrushReseed, "cmdPropBrushReseed")
        Me.cmdPropBrushReseed.Name = "cmdPropBrushReseed"
        Me.tipDefault.SetToolTip(Me.cmdPropBrushReseed, resources.GetString("cmdPropBrushReseed.ToolTip"))
        Me.cmdPropBrushReseed.UseVisualStyleBackColor = True
        '
        'pnlPropBrushCustom
        '
        resources.ApplyResources(Me.pnlPropBrushCustom, "pnlPropBrushCustom")
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartPosition)
        Me.pnlPropBrushCustom.Controls.Add(Me.cboPropBrushClipartPosition)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartImage)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushAlternativeBrushColor)
        Me.pnlPropBrushCustom.Controls.Add(Me.cmdPropBrushAlternativeBrushColor)
        Me.pnlPropBrushCustom.Controls.Add(Me.picPropBrushAlternativeBrushColor)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblpropbrushcolor)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartAngle)
        Me.pnlPropBrushCustom.Controls.Add(Me.txtPropBrushClipartAngle)
        Me.pnlPropBrushCustom.Controls.Add(Me.cmdPropBrushColor)
        Me.pnlPropBrushCustom.Controls.Add(Me.picPropBrushColor)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartAngleMode)
        Me.pnlPropBrushCustom.Controls.Add(Me.cboPropBrushClipartAngleMode)
        Me.pnlPropBrushCustom.Controls.Add(Me.picPropBrushClipartImage)
        Me.pnlPropBrushCustom.Controls.Add(Me.Label31)
        Me.pnlPropBrushCustom.Controls.Add(Me.cboPropBrushHatch)
        Me.pnlPropBrushCustom.Controls.Add(Me.cmdPropBrushBrowseClipart)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartZoomFactor)
        Me.pnlPropBrushCustom.Controls.Add(Me.txtPropBrushClipartZoomFactor)
        Me.pnlPropBrushCustom.Controls.Add(Me.txtPropBrushClipartDensity)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartDensity)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushPatternType)
        Me.pnlPropBrushCustom.Controls.Add(Me.cboPropBrushPatternType)
        Me.pnlPropBrushCustom.Controls.Add(Me.cboPropBrushClipartCrop)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushClipartCrop)
        Me.pnlPropBrushCustom.Controls.Add(Me.lblPropBrushPatternPen)
        Me.pnlPropBrushCustom.Controls.Add(Me.cboPropBrushPatternPen)
        Me.pnlPropBrushCustom.Name = "pnlPropBrushCustom"
        '
        'lblPropBrushClipartPosition
        '
        resources.ApplyResources(Me.lblPropBrushClipartPosition, "lblPropBrushClipartPosition")
        Me.lblPropBrushClipartPosition.Name = "lblPropBrushClipartPosition"
        '
        'cboPropBrushClipartPosition
        '
        Me.cboPropBrushClipartPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartPosition.DropDownWidth = 120
        Me.cboPropBrushClipartPosition.FormattingEnabled = True
        Me.cboPropBrushClipartPosition.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartPosition.Items"), resources.GetString("cboPropBrushClipartPosition.Items1")})
        resources.ApplyResources(Me.cboPropBrushClipartPosition, "cboPropBrushClipartPosition")
        Me.cboPropBrushClipartPosition.Name = "cboPropBrushClipartPosition"
        Me.tipDefault.SetToolTip(Me.cboPropBrushClipartPosition, resources.GetString("cboPropBrushClipartPosition.ToolTip"))
        '
        'lblPropBrushClipartImage
        '
        resources.ApplyResources(Me.lblPropBrushClipartImage, "lblPropBrushClipartImage")
        Me.lblPropBrushClipartImage.Name = "lblPropBrushClipartImage"
        '
        'lblPropBrushAlternativeBrushColor
        '
        resources.ApplyResources(Me.lblPropBrushAlternativeBrushColor, "lblPropBrushAlternativeBrushColor")
        Me.lblPropBrushAlternativeBrushColor.Name = "lblPropBrushAlternativeBrushColor"
        '
        'cmdPropBrushAlternativeBrushColor
        '
        resources.ApplyResources(Me.cmdPropBrushAlternativeBrushColor, "cmdPropBrushAlternativeBrushColor")
        Me.cmdPropBrushAlternativeBrushColor.Name = "cmdPropBrushAlternativeBrushColor"
        Me.tipDefault.SetToolTip(Me.cmdPropBrushAlternativeBrushColor, resources.GetString("cmdPropBrushAlternativeBrushColor.ToolTip"))
        Me.cmdPropBrushAlternativeBrushColor.UseVisualStyleBackColor = True
        '
        'picPropBrushAlternativeBrushColor
        '
        resources.ApplyResources(Me.picPropBrushAlternativeBrushColor, "picPropBrushAlternativeBrushColor")
        Me.picPropBrushAlternativeBrushColor.Name = "picPropBrushAlternativeBrushColor"
        Me.picPropBrushAlternativeBrushColor.TabStop = False
        '
        'lblpropbrushcolor
        '
        resources.ApplyResources(Me.lblpropbrushcolor, "lblpropbrushcolor")
        Me.lblpropbrushcolor.Name = "lblpropbrushcolor"
        '
        'lblPropBrushClipartAngle
        '
        resources.ApplyResources(Me.lblPropBrushClipartAngle, "lblPropBrushClipartAngle")
        Me.lblPropBrushClipartAngle.Name = "lblPropBrushClipartAngle"
        '
        'txtPropBrushClipartAngle
        '
        resources.ApplyResources(Me.txtPropBrushClipartAngle, "txtPropBrushClipartAngle")
        Me.txtPropBrushClipartAngle.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
        Me.txtPropBrushClipartAngle.Name = "txtPropBrushClipartAngle"
        Me.tipDefault.SetToolTip(Me.txtPropBrushClipartAngle, resources.GetString("txtPropBrushClipartAngle.ToolTip"))
        '
        'cmdPropBrushColor
        '
        resources.ApplyResources(Me.cmdPropBrushColor, "cmdPropBrushColor")
        Me.cmdPropBrushColor.Name = "cmdPropBrushColor"
        Me.tipDefault.SetToolTip(Me.cmdPropBrushColor, resources.GetString("cmdPropBrushColor.ToolTip"))
        Me.cmdPropBrushColor.UseVisualStyleBackColor = True
        '
        'picPropBrushColor
        '
        resources.ApplyResources(Me.picPropBrushColor, "picPropBrushColor")
        Me.picPropBrushColor.Name = "picPropBrushColor"
        Me.picPropBrushColor.TabStop = False
        '
        'lblPropBrushClipartAngleMode
        '
        resources.ApplyResources(Me.lblPropBrushClipartAngleMode, "lblPropBrushClipartAngleMode")
        Me.lblPropBrushClipartAngleMode.Name = "lblPropBrushClipartAngleMode"
        '
        'cboPropBrushClipartAngleMode
        '
        Me.cboPropBrushClipartAngleMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartAngleMode.FormattingEnabled = True
        Me.cboPropBrushClipartAngleMode.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartAngleMode.Items"), resources.GetString("cboPropBrushClipartAngleMode.Items1")})
        resources.ApplyResources(Me.cboPropBrushClipartAngleMode, "cboPropBrushClipartAngleMode")
        Me.cboPropBrushClipartAngleMode.Name = "cboPropBrushClipartAngleMode"
        Me.tipDefault.SetToolTip(Me.cboPropBrushClipartAngleMode, resources.GetString("cboPropBrushClipartAngleMode.ToolTip"))
        '
        'picPropBrushClipartImage
        '
        resources.ApplyResources(Me.picPropBrushClipartImage, "picPropBrushClipartImage")
        Me.picPropBrushClipartImage.Name = "picPropBrushClipartImage"
        Me.picPropBrushClipartImage.TabStop = False
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.Name = "Label31"
        '
        'cboPropBrushHatch
        '
        Me.cboPropBrushHatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushHatch.FormattingEnabled = True
        Me.cboPropBrushHatch.Items.AddRange(New Object() {resources.GetString("cboPropBrushHatch.Items"), resources.GetString("cboPropBrushHatch.Items1"), resources.GetString("cboPropBrushHatch.Items2"), resources.GetString("cboPropBrushHatch.Items3"), resources.GetString("cboPropBrushHatch.Items4")})
        resources.ApplyResources(Me.cboPropBrushHatch, "cboPropBrushHatch")
        Me.cboPropBrushHatch.Name = "cboPropBrushHatch"
        Me.tipDefault.SetToolTip(Me.cboPropBrushHatch, resources.GetString("cboPropBrushHatch.ToolTip"))
        '
        'cmdPropBrushBrowseClipart
        '
        resources.ApplyResources(Me.cmdPropBrushBrowseClipart, "cmdPropBrushBrowseClipart")
        Me.cmdPropBrushBrowseClipart.Name = "cmdPropBrushBrowseClipart"
        Me.tipDefault.SetToolTip(Me.cmdPropBrushBrowseClipart, resources.GetString("cmdPropBrushBrowseClipart.ToolTip"))
        Me.cmdPropBrushBrowseClipart.UseVisualStyleBackColor = True
        '
        'lblPropBrushClipartZoomFactor
        '
        resources.ApplyResources(Me.lblPropBrushClipartZoomFactor, "lblPropBrushClipartZoomFactor")
        Me.lblPropBrushClipartZoomFactor.Name = "lblPropBrushClipartZoomFactor"
        '
        'txtPropBrushClipartZoomFactor
        '
        resources.ApplyResources(Me.txtPropBrushClipartZoomFactor, "txtPropBrushClipartZoomFactor")
        Me.txtPropBrushClipartZoomFactor.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropBrushClipartZoomFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropBrushClipartZoomFactor.Name = "txtPropBrushClipartZoomFactor"
        Me.tipDefault.SetToolTip(Me.txtPropBrushClipartZoomFactor, resources.GetString("txtPropBrushClipartZoomFactor.ToolTip"))
        Me.txtPropBrushClipartZoomFactor.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropBrushClipartDensity
        '
        resources.ApplyResources(Me.txtPropBrushClipartDensity, "txtPropBrushClipartDensity")
        Me.txtPropBrushClipartDensity.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropBrushClipartDensity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtPropBrushClipartDensity.Name = "txtPropBrushClipartDensity"
        Me.tipDefault.SetToolTip(Me.txtPropBrushClipartDensity, resources.GetString("txtPropBrushClipartDensity.ToolTip"))
        Me.txtPropBrushClipartDensity.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblPropBrushClipartDensity
        '
        resources.ApplyResources(Me.lblPropBrushClipartDensity, "lblPropBrushClipartDensity")
        Me.lblPropBrushClipartDensity.Name = "lblPropBrushClipartDensity"
        '
        'lblPropBrushPatternType
        '
        resources.ApplyResources(Me.lblPropBrushPatternType, "lblPropBrushPatternType")
        Me.lblPropBrushPatternType.Name = "lblPropBrushPatternType"
        '
        'cboPropBrushPatternType
        '
        Me.cboPropBrushPatternType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternType.FormattingEnabled = True
        Me.cboPropBrushPatternType.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternType.Items"), resources.GetString("cboPropBrushPatternType.Items1")})
        resources.ApplyResources(Me.cboPropBrushPatternType, "cboPropBrushPatternType")
        Me.cboPropBrushPatternType.Name = "cboPropBrushPatternType"
        Me.tipDefault.SetToolTip(Me.cboPropBrushPatternType, resources.GetString("cboPropBrushPatternType.ToolTip"))
        '
        'cboPropBrushClipartCrop
        '
        Me.cboPropBrushClipartCrop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushClipartCrop.FormattingEnabled = True
        Me.cboPropBrushClipartCrop.Items.AddRange(New Object() {resources.GetString("cboPropBrushClipartCrop.Items"), resources.GetString("cboPropBrushClipartCrop.Items1"), resources.GetString("cboPropBrushClipartCrop.Items2")})
        resources.ApplyResources(Me.cboPropBrushClipartCrop, "cboPropBrushClipartCrop")
        Me.cboPropBrushClipartCrop.Name = "cboPropBrushClipartCrop"
        Me.tipDefault.SetToolTip(Me.cboPropBrushClipartCrop, resources.GetString("cboPropBrushClipartCrop.ToolTip"))
        '
        'lblPropBrushClipartCrop
        '
        resources.ApplyResources(Me.lblPropBrushClipartCrop, "lblPropBrushClipartCrop")
        Me.lblPropBrushClipartCrop.Name = "lblPropBrushClipartCrop"
        '
        'lblPropBrushPatternPen
        '
        resources.ApplyResources(Me.lblPropBrushPatternPen, "lblPropBrushPatternPen")
        Me.lblPropBrushPatternPen.Name = "lblPropBrushPatternPen"
        '
        'cboPropBrushPatternPen
        '
        Me.cboPropBrushPatternPen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropBrushPatternPen.FormattingEnabled = True
        Me.cboPropBrushPatternPen.Items.AddRange(New Object() {resources.GetString("cboPropBrushPatternPen.Items"), resources.GetString("cboPropBrushPatternPen.Items1"), resources.GetString("cboPropBrushPatternPen.Items2"), resources.GetString("cboPropBrushPatternPen.Items3"), resources.GetString("cboPropBrushPatternPen.Items4")})
        resources.ApplyResources(Me.cboPropBrushPatternPen, "cboPropBrushPatternPen")
        Me.cboPropBrushPatternPen.Name = "cboPropBrushPatternPen"
        Me.tipDefault.SetToolTip(Me.cboPropBrushPatternPen, resources.GetString("cboPropBrushPatternPen.ToolTip"))
        '
        'pnlPropSegmentBinding
        '
        Me.pnlPropSegmentBinding.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropSegmentBinding.Controls.Add(Me.txtPropSegmentBinded)
        Me.pnlPropSegmentBinding.Controls.Add(Me.cmdPropSegmentRebind)
        Me.pnlPropSegmentBinding.Controls.Add(Me.chkPropSegmentLocked)
        Me.pnlPropSegmentBinding.Controls.Add(Me.lblPropBinding)
        resources.ApplyResources(Me.pnlPropSegmentBinding, "pnlPropSegmentBinding")
        Me.pnlPropSegmentBinding.Name = "pnlPropSegmentBinding"
        '
        'txtPropSegmentBinded
        '
        resources.ApplyResources(Me.txtPropSegmentBinded, "txtPropSegmentBinded")
        Me.txtPropSegmentBinded.Name = "txtPropSegmentBinded"
        Me.txtPropSegmentBinded.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtPropSegmentBinded, resources.GetString("txtPropSegmentBinded.ToolTip"))
        '
        'cmdPropSegmentRebind
        '
        resources.ApplyResources(Me.cmdPropSegmentRebind, "cmdPropSegmentRebind")
        Me.cmdPropSegmentRebind.Name = "cmdPropSegmentRebind"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentRebind, resources.GetString("cmdPropSegmentRebind.ToolTip"))
        Me.cmdPropSegmentRebind.UseVisualStyleBackColor = True
        '
        'chkPropSegmentLocked
        '
        resources.ApplyResources(Me.chkPropSegmentLocked, "chkPropSegmentLocked")
        Me.chkPropSegmentLocked.Checked = True
        Me.chkPropSegmentLocked.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPropSegmentLocked.Name = "chkPropSegmentLocked"
        Me.tipDefault.SetToolTip(Me.chkPropSegmentLocked, resources.GetString("chkPropSegmentLocked.ToolTip"))
        Me.chkPropSegmentLocked.UseVisualStyleBackColor = True
        '
        'lblPropBinding
        '
        resources.ApplyResources(Me.lblPropBinding, "lblPropBinding")
        Me.lblPropBinding.Name = "lblPropBinding"
        '
        'pnlPropSegmentsBinding
        '
        resources.ApplyResources(Me.pnlPropSegmentsBinding, "pnlPropSegmentsBinding")
        Me.pnlPropSegmentsBinding.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropSegmentsBinding.Controls.Add(Me.cmdPropSegmentsLock)
        Me.pnlPropSegmentsBinding.Controls.Add(Me.cmdPropSegmentsUnlock)
        Me.pnlPropSegmentsBinding.Controls.Add(Me.lvPropSegmentsBinded)
        Me.pnlPropSegmentsBinding.Controls.Add(Me.cmdPropSegmentsRebind)
        Me.pnlPropSegmentsBinding.Controls.Add(Me.chkPropSegmentsLocked)
        Me.pnlPropSegmentsBinding.Controls.Add(Me.Label41)
        Me.pnlPropSegmentsBinding.Name = "pnlPropSegmentsBinding"
        '
        'cmdPropSegmentsLock
        '
        resources.ApplyResources(Me.cmdPropSegmentsLock, "cmdPropSegmentsLock")
        Me.cmdPropSegmentsLock.Name = "cmdPropSegmentsLock"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentsLock, resources.GetString("cmdPropSegmentsLock.ToolTip"))
        Me.cmdPropSegmentsLock.UseVisualStyleBackColor = True
        '
        'cmdPropSegmentsUnlock
        '
        resources.ApplyResources(Me.cmdPropSegmentsUnlock, "cmdPropSegmentsUnlock")
        Me.cmdPropSegmentsUnlock.Name = "cmdPropSegmentsUnlock"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentsUnlock, resources.GetString("cmdPropSegmentsUnlock.ToolTip"))
        Me.cmdPropSegmentsUnlock.UseVisualStyleBackColor = True
        '
        'lvPropSegmentsBinded
        '
        resources.ApplyResources(Me.lvPropSegmentsBinded, "lvPropSegmentsBinded")
        Me.lvPropSegmentsBinded.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colPropSegmentsBindedSegment})
        Me.lvPropSegmentsBinded.FullRowSelect = True
        Me.lvPropSegmentsBinded.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvPropSegmentsBinded.Name = "lvPropSegmentsBinded"
        Me.tipDefault.SetToolTip(Me.lvPropSegmentsBinded, resources.GetString("lvPropSegmentsBinded.ToolTip"))
        Me.lvPropSegmentsBinded.UseCompatibleStateImageBehavior = False
        Me.lvPropSegmentsBinded.View = System.Windows.Forms.View.Details
        '
        'colPropSegmentsBindedSegment
        '
        resources.ApplyResources(Me.colPropSegmentsBindedSegment, "colPropSegmentsBindedSegment")
        '
        'cmdPropSegmentsRebind
        '
        resources.ApplyResources(Me.cmdPropSegmentsRebind, "cmdPropSegmentsRebind")
        Me.cmdPropSegmentsRebind.Name = "cmdPropSegmentsRebind"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentsRebind, resources.GetString("cmdPropSegmentsRebind.ToolTip"))
        Me.cmdPropSegmentsRebind.UseVisualStyleBackColor = True
        '
        'chkPropSegmentsLocked
        '
        resources.ApplyResources(Me.chkPropSegmentsLocked, "chkPropSegmentsLocked")
        Me.chkPropSegmentsLocked.Checked = True
        Me.chkPropSegmentsLocked.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.chkPropSegmentsLocked.Name = "chkPropSegmentsLocked"
        Me.tipDefault.SetToolTip(Me.chkPropSegmentsLocked, resources.GetString("chkPropSegmentsLocked.ToolTip"))
        Me.chkPropSegmentsLocked.UseVisualStyleBackColor = True
        '
        'Label41
        '
        resources.ApplyResources(Me.Label41, "Label41")
        Me.Label41.Name = "Label41"
        '
        'pnlPropText
        '
        resources.ApplyResources(Me.pnlPropText, "pnlPropText")
        Me.pnlPropText.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropText.Controls.Add(Me.tblPropText)
        Me.pnlPropText.Name = "pnlPropText"
        '
        'tblPropText
        '
        Me.tblPropText.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.tblPropText, "tblPropText")
        Me.tblPropText.Controls.Add(Me.pnlPropTextFont, 0, 1)
        Me.tblPropText.Controls.Add(Me.pnlPropTextStyle, 0, 0)
        Me.tblPropText.Name = "tblPropText"
        '
        'pnlPropTextFont
        '
        resources.ApplyResources(Me.pnlPropTextFont, "pnlPropTextFont")
        Me.pnlPropTextFont.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropTextFont.Controls.Add(Me.lblPropFontColor)
        Me.pnlPropTextFont.Controls.Add(Me.cmdPropFontColor)
        Me.pnlPropTextFont.Controls.Add(Me.picPropFontColor)
        Me.pnlPropTextFont.Controls.Add(Me.chkPropTextFontUnderline)
        Me.pnlPropTextFont.Controls.Add(Me.chkPropTextFontItalic)
        Me.pnlPropTextFont.Controls.Add(Me.chkPropTextFontBold)
        Me.pnlPropTextFont.Controls.Add(Me.cboPropTextFontChar)
        Me.pnlPropTextFont.Controls.Add(Me.lblPropTextFontChar)
        Me.pnlPropTextFont.Controls.Add(Me.cboPropTextFontSize)
        Me.pnlPropTextFont.Controls.Add(Me.lblPropTextFontSize)
        Me.pnlPropTextFont.Name = "pnlPropTextFont"
        '
        'lblPropFontColor
        '
        resources.ApplyResources(Me.lblPropFontColor, "lblPropFontColor")
        Me.lblPropFontColor.Name = "lblPropFontColor"
        '
        'cmdPropFontColor
        '
        resources.ApplyResources(Me.cmdPropFontColor, "cmdPropFontColor")
        Me.cmdPropFontColor.Name = "cmdPropFontColor"
        Me.tipDefault.SetToolTip(Me.cmdPropFontColor, resources.GetString("cmdPropFontColor.ToolTip"))
        Me.cmdPropFontColor.UseVisualStyleBackColor = True
        '
        'picPropFontColor
        '
        resources.ApplyResources(Me.picPropFontColor, "picPropFontColor")
        Me.picPropFontColor.Name = "picPropFontColor"
        Me.picPropFontColor.TabStop = False
        '
        'chkPropTextFontUnderline
        '
        resources.ApplyResources(Me.chkPropTextFontUnderline, "chkPropTextFontUnderline")
        Me.chkPropTextFontUnderline.Name = "chkPropTextFontUnderline"
        Me.tipDefault.SetToolTip(Me.chkPropTextFontUnderline, resources.GetString("chkPropTextFontUnderline.ToolTip"))
        Me.chkPropTextFontUnderline.UseVisualStyleBackColor = True
        '
        'chkPropTextFontItalic
        '
        resources.ApplyResources(Me.chkPropTextFontItalic, "chkPropTextFontItalic")
        Me.chkPropTextFontItalic.Name = "chkPropTextFontItalic"
        Me.tipDefault.SetToolTip(Me.chkPropTextFontItalic, resources.GetString("chkPropTextFontItalic.ToolTip"))
        Me.chkPropTextFontItalic.UseVisualStyleBackColor = True
        '
        'chkPropTextFontBold
        '
        resources.ApplyResources(Me.chkPropTextFontBold, "chkPropTextFontBold")
        Me.chkPropTextFontBold.Name = "chkPropTextFontBold"
        Me.tipDefault.SetToolTip(Me.chkPropTextFontBold, resources.GetString("chkPropTextFontBold.ToolTip"))
        Me.chkPropTextFontBold.UseVisualStyleBackColor = True
        '
        'cboPropTextFontChar
        '
        Me.cboPropTextFontChar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextFontChar.FormattingEnabled = True
        resources.ApplyResources(Me.cboPropTextFontChar, "cboPropTextFontChar")
        Me.cboPropTextFontChar.Name = "cboPropTextFontChar"
        Me.tipDefault.SetToolTip(Me.cboPropTextFontChar, resources.GetString("cboPropTextFontChar.ToolTip"))
        '
        'lblPropTextFontChar
        '
        resources.ApplyResources(Me.lblPropTextFontChar, "lblPropTextFontChar")
        Me.lblPropTextFontChar.Name = "lblPropTextFontChar"
        '
        'cboPropTextFontSize
        '
        Me.cboPropTextFontSize.FormattingEnabled = True
        Me.cboPropTextFontSize.Items.AddRange(New Object() {resources.GetString("cboPropTextFontSize.Items"), resources.GetString("cboPropTextFontSize.Items1"), resources.GetString("cboPropTextFontSize.Items2"), resources.GetString("cboPropTextFontSize.Items3"), resources.GetString("cboPropTextFontSize.Items4"), resources.GetString("cboPropTextFontSize.Items5"), resources.GetString("cboPropTextFontSize.Items6"), resources.GetString("cboPropTextFontSize.Items7"), resources.GetString("cboPropTextFontSize.Items8"), resources.GetString("cboPropTextFontSize.Items9"), resources.GetString("cboPropTextFontSize.Items10"), resources.GetString("cboPropTextFontSize.Items11"), resources.GetString("cboPropTextFontSize.Items12"), resources.GetString("cboPropTextFontSize.Items13"), resources.GetString("cboPropTextFontSize.Items14"), resources.GetString("cboPropTextFontSize.Items15"), resources.GetString("cboPropTextFontSize.Items16"), resources.GetString("cboPropTextFontSize.Items17")})
        resources.ApplyResources(Me.cboPropTextFontSize, "cboPropTextFontSize")
        Me.cboPropTextFontSize.Name = "cboPropTextFontSize"
        Me.tipDefault.SetToolTip(Me.cboPropTextFontSize, resources.GetString("cboPropTextFontSize.ToolTip"))
        '
        'lblPropTextFontSize
        '
        resources.ApplyResources(Me.lblPropTextFontSize, "lblPropTextFontSize")
        Me.lblPropTextFontSize.Name = "lblPropTextFontSize"
        '
        'pnlPropTextStyle
        '
        resources.ApplyResources(Me.pnlPropTextStyle, "pnlPropTextStyle")
        Me.pnlPropTextStyle.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropTextStyle.Controls.Add(Me.Panel1)
        Me.pnlPropTextStyle.Controls.Add(Me.optPropTextAlignRight)
        Me.pnlPropTextStyle.Controls.Add(Me.optPropTextAlignCenter)
        Me.pnlPropTextStyle.Controls.Add(Me.optPropTextAlignLeft)
        Me.pnlPropTextStyle.Controls.Add(Me.cboPropTextSize)
        Me.pnlPropTextStyle.Controls.Add(Me.lblPropTextSize)
        Me.pnlPropTextStyle.Controls.Add(Me.lblPropText)
        Me.pnlPropTextStyle.Controls.Add(Me.txtPropText)
        Me.pnlPropTextStyle.Controls.Add(Me.lblPropTextStyle)
        Me.pnlPropTextStyle.Controls.Add(Me.cboPropTextStyle)
        Me.pnlPropTextStyle.Controls.Add(Me.cboPropTextRotateMode)
        Me.pnlPropTextStyle.Controls.Add(Me.lblPropTextRotateMode)
        Me.pnlPropTextStyle.Name = "pnlPropTextStyle"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optPropTextVAlignBottom)
        Me.Panel1.Controls.Add(Me.optPropTextVAlignTop)
        Me.Panel1.Controls.Add(Me.optPropTextVAlignCenter)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'optPropTextVAlignBottom
        '
        resources.ApplyResources(Me.optPropTextVAlignBottom, "optPropTextVAlignBottom")
        Me.optPropTextVAlignBottom.Name = "optPropTextVAlignBottom"
        Me.tipDefault.SetToolTip(Me.optPropTextVAlignBottom, resources.GetString("optPropTextVAlignBottom.ToolTip"))
        Me.optPropTextVAlignBottom.UseVisualStyleBackColor = True
        '
        'optPropTextVAlignTop
        '
        resources.ApplyResources(Me.optPropTextVAlignTop, "optPropTextVAlignTop")
        Me.optPropTextVAlignTop.Name = "optPropTextVAlignTop"
        Me.tipDefault.SetToolTip(Me.optPropTextVAlignTop, resources.GetString("optPropTextVAlignTop.ToolTip"))
        Me.optPropTextVAlignTop.UseVisualStyleBackColor = True
        '
        'optPropTextVAlignCenter
        '
        resources.ApplyResources(Me.optPropTextVAlignCenter, "optPropTextVAlignCenter")
        Me.optPropTextVAlignCenter.Checked = True
        Me.optPropTextVAlignCenter.Name = "optPropTextVAlignCenter"
        Me.optPropTextVAlignCenter.TabStop = True
        Me.tipDefault.SetToolTip(Me.optPropTextVAlignCenter, resources.GetString("optPropTextVAlignCenter.ToolTip"))
        Me.optPropTextVAlignCenter.UseVisualStyleBackColor = True
        '
        'optPropTextAlignRight
        '
        resources.ApplyResources(Me.optPropTextAlignRight, "optPropTextAlignRight")
        Me.optPropTextAlignRight.Name = "optPropTextAlignRight"
        Me.tipDefault.SetToolTip(Me.optPropTextAlignRight, resources.GetString("optPropTextAlignRight.ToolTip"))
        Me.optPropTextAlignRight.UseVisualStyleBackColor = True
        '
        'optPropTextAlignCenter
        '
        resources.ApplyResources(Me.optPropTextAlignCenter, "optPropTextAlignCenter")
        Me.optPropTextAlignCenter.Checked = True
        Me.optPropTextAlignCenter.Name = "optPropTextAlignCenter"
        Me.optPropTextAlignCenter.TabStop = True
        Me.tipDefault.SetToolTip(Me.optPropTextAlignCenter, resources.GetString("optPropTextAlignCenter.ToolTip"))
        Me.optPropTextAlignCenter.UseVisualStyleBackColor = True
        '
        'optPropTextAlignLeft
        '
        resources.ApplyResources(Me.optPropTextAlignLeft, "optPropTextAlignLeft")
        Me.optPropTextAlignLeft.Name = "optPropTextAlignLeft"
        Me.tipDefault.SetToolTip(Me.optPropTextAlignLeft, resources.GetString("optPropTextAlignLeft.ToolTip"))
        Me.optPropTextAlignLeft.UseVisualStyleBackColor = True
        '
        'cboPropTextSize
        '
        Me.cboPropTextSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextSize.FormattingEnabled = True
        Me.cboPropTextSize.Items.AddRange(New Object() {resources.GetString("cboPropTextSize.Items"), resources.GetString("cboPropTextSize.Items1"), resources.GetString("cboPropTextSize.Items2"), resources.GetString("cboPropTextSize.Items3"), resources.GetString("cboPropTextSize.Items4"), resources.GetString("cboPropTextSize.Items5")})
        resources.ApplyResources(Me.cboPropTextSize, "cboPropTextSize")
        Me.cboPropTextSize.Name = "cboPropTextSize"
        Me.tipDefault.SetToolTip(Me.cboPropTextSize, resources.GetString("cboPropTextSize.ToolTip"))
        '
        'lblPropTextSize
        '
        resources.ApplyResources(Me.lblPropTextSize, "lblPropTextSize")
        Me.lblPropTextSize.Name = "lblPropTextSize"
        '
        'lblPropText
        '
        resources.ApplyResources(Me.lblPropText, "lblPropText")
        Me.lblPropText.Name = "lblPropText"
        '
        'txtPropText
        '
        resources.ApplyResources(Me.txtPropText, "txtPropText")
        Me.txtPropText.Name = "txtPropText"
        '
        'lblPropTextStyle
        '
        resources.ApplyResources(Me.lblPropTextStyle, "lblPropTextStyle")
        Me.lblPropTextStyle.Name = "lblPropTextStyle"
        '
        'cboPropTextStyle
        '
        resources.ApplyResources(Me.cboPropTextStyle, "cboPropTextStyle")
        Me.cboPropTextStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPropTextStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextStyle.FormattingEnabled = True
        Me.cboPropTextStyle.Items.AddRange(New Object() {resources.GetString("cboPropTextStyle.Items"), resources.GetString("cboPropTextStyle.Items1"), resources.GetString("cboPropTextStyle.Items2"), resources.GetString("cboPropTextStyle.Items3")})
        Me.cboPropTextStyle.Name = "cboPropTextStyle"
        Me.tipDefault.SetToolTip(Me.cboPropTextStyle, resources.GetString("cboPropTextStyle.ToolTip"))
        '
        'cboPropTextRotateMode
        '
        Me.cboPropTextRotateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropTextRotateMode.FormattingEnabled = True
        Me.cboPropTextRotateMode.Items.AddRange(New Object() {resources.GetString("cboPropTextRotateMode.Items"), resources.GetString("cboPropTextRotateMode.Items1")})
        resources.ApplyResources(Me.cboPropTextRotateMode, "cboPropTextRotateMode")
        Me.cboPropTextRotateMode.Name = "cboPropTextRotateMode"
        Me.tipDefault.SetToolTip(Me.cboPropTextRotateMode, resources.GetString("cboPropTextRotateMode.ToolTip"))
        '
        'lblPropTextRotateMode
        '
        resources.ApplyResources(Me.lblPropTextRotateMode, "lblPropTextRotateMode")
        Me.lblPropTextRotateMode.Name = "lblPropTextRotateMode"
        '
        'pnlPropCrossSection
        '
        Me.pnlPropCrossSection.BackColor = System.Drawing.Color.Transparent
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropCrossSectionRefStation)
        Me.pnlPropCrossSection.Controls.Add(Me.cboPropCrossSectionRefStation)
        Me.pnlPropCrossSection.Controls.Add(Me.cmdPropCrossSectionProfileMarker)
        Me.pnlPropCrossSection.Controls.Add(Me.cmdPropCrossSectionPlanMarker)
        Me.pnlPropCrossSection.Controls.Add(Me.chkPropCrossSectionProfileMarker)
        Me.pnlPropCrossSection.Controls.Add(Me.chkPropCrossSectionPlanMarker)
        Me.pnlPropCrossSection.Controls.Add(Me.Label7)
        Me.pnlPropCrossSection.Controls.Add(Me.Label9)
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropCrossSectionCrossX)
        Me.pnlPropCrossSection.Controls.Add(Me.txtPropCrossSectionHeight)
        Me.pnlPropCrossSection.Controls.Add(Me.txtPropCrossSectionWidth)
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropCrossSectionCross)
        Me.pnlPropCrossSection.Controls.Add(Me.cmdPropCrossSectionSegment)
        Me.pnlPropCrossSection.Controls.Add(Me.txtPropCrossSectionSegment)
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropCrossSectionSegment)
        Me.pnlPropCrossSection.Controls.Add(Me.cboPropProfileDirection)
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropProfileBearing)
        Me.pnlPropCrossSection.Controls.Add(Me.txtPropProfileTextDistance)
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropProfileTextDistance)
        Me.pnlPropCrossSection.Controls.Add(Me.cboPropProfileTextPosition)
        Me.pnlPropCrossSection.Controls.Add(Me.lblPropProfileTextPosition)
        resources.ApplyResources(Me.pnlPropCrossSection, "pnlPropCrossSection")
        Me.pnlPropCrossSection.Name = "pnlPropCrossSection"
        '
        'lblPropCrossSectionRefStation
        '
        resources.ApplyResources(Me.lblPropCrossSectionRefStation, "lblPropCrossSectionRefStation")
        Me.lblPropCrossSectionRefStation.Name = "lblPropCrossSectionRefStation"
        '
        'cboPropCrossSectionRefStation
        '
        Me.cboPropCrossSectionRefStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionRefStation, "cboPropCrossSectionRefStation")
        Me.cboPropCrossSectionRefStation.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionRefStation.Items"), resources.GetString("cboPropCrossSectionRefStation.Items1"), resources.GetString("cboPropCrossSectionRefStation.Items2")})
        Me.cboPropCrossSectionRefStation.Name = "cboPropCrossSectionRefStation"
        Me.tipDefault.SetToolTip(Me.cboPropCrossSectionRefStation, resources.GetString("cboPropCrossSectionRefStation.ToolTip"))
        '
        'cmdPropCrossSectionProfileMarker
        '
        resources.ApplyResources(Me.cmdPropCrossSectionProfileMarker, "cmdPropCrossSectionProfileMarker")
        Me.cmdPropCrossSectionProfileMarker.Name = "cmdPropCrossSectionProfileMarker"
        Me.cmdPropCrossSectionProfileMarker.UseVisualStyleBackColor = True
        '
        'cmdPropCrossSectionPlanMarker
        '
        resources.ApplyResources(Me.cmdPropCrossSectionPlanMarker, "cmdPropCrossSectionPlanMarker")
        Me.cmdPropCrossSectionPlanMarker.Name = "cmdPropCrossSectionPlanMarker"
        Me.cmdPropCrossSectionPlanMarker.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionProfileMarker
        '
        resources.ApplyResources(Me.chkPropCrossSectionProfileMarker, "chkPropCrossSectionProfileMarker")
        Me.chkPropCrossSectionProfileMarker.Name = "chkPropCrossSectionProfileMarker"
        Me.chkPropCrossSectionProfileMarker.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionPlanMarker
        '
        resources.ApplyResources(Me.chkPropCrossSectionPlanMarker, "chkPropCrossSectionPlanMarker")
        Me.chkPropCrossSectionPlanMarker.Name = "chkPropCrossSectionPlanMarker"
        Me.chkPropCrossSectionPlanMarker.UseVisualStyleBackColor = True
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'lblPropCrossSectionCrossX
        '
        resources.ApplyResources(Me.lblPropCrossSectionCrossX, "lblPropCrossSectionCrossX")
        Me.lblPropCrossSectionCrossX.Name = "lblPropCrossSectionCrossX"
        '
        'txtPropCrossSectionHeight
        '
        Me.txtPropCrossSectionHeight.DecimalPlaces = 2
        Me.txtPropCrossSectionHeight.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionHeight, "txtPropCrossSectionHeight")
        Me.txtPropCrossSectionHeight.Name = "txtPropCrossSectionHeight"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionHeight, resources.GetString("txtPropCrossSectionHeight.ToolTip"))
        Me.txtPropCrossSectionHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropCrossSectionWidth
        '
        Me.txtPropCrossSectionWidth.DecimalPlaces = 2
        Me.txtPropCrossSectionWidth.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionWidth, "txtPropCrossSectionWidth")
        Me.txtPropCrossSectionWidth.Name = "txtPropCrossSectionWidth"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionWidth, resources.GetString("txtPropCrossSectionWidth.ToolTip"))
        Me.txtPropCrossSectionWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionCross
        '
        resources.ApplyResources(Me.lblPropCrossSectionCross, "lblPropCrossSectionCross")
        Me.lblPropCrossSectionCross.Name = "lblPropCrossSectionCross"
        Me.tipDefault.SetToolTip(Me.lblPropCrossSectionCross, resources.GetString("lblPropCrossSectionCross.ToolTip"))
        '
        'cmdPropCrossSectionSegment
        '
        resources.ApplyResources(Me.cmdPropCrossSectionSegment, "cmdPropCrossSectionSegment")
        Me.cmdPropCrossSectionSegment.Name = "cmdPropCrossSectionSegment"
        Me.tipDefault.SetToolTip(Me.cmdPropCrossSectionSegment, resources.GetString("cmdPropCrossSectionSegment.ToolTip"))
        Me.cmdPropCrossSectionSegment.UseVisualStyleBackColor = True
        '
        'txtPropCrossSectionSegment
        '
        resources.ApplyResources(Me.txtPropCrossSectionSegment, "txtPropCrossSectionSegment")
        Me.txtPropCrossSectionSegment.Name = "txtPropCrossSectionSegment"
        Me.txtPropCrossSectionSegment.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionSegment, resources.GetString("txtPropCrossSectionSegment.ToolTip"))
        '
        'lblPropCrossSectionSegment
        '
        resources.ApplyResources(Me.lblPropCrossSectionSegment, "lblPropCrossSectionSegment")
        Me.lblPropCrossSectionSegment.Name = "lblPropCrossSectionSegment"
        '
        'cboPropProfileDirection
        '
        Me.cboPropProfileDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropProfileDirection, "cboPropProfileDirection")
        Me.cboPropProfileDirection.Items.AddRange(New Object() {resources.GetString("cboPropProfileDirection.Items"), resources.GetString("cboPropProfileDirection.Items1")})
        Me.cboPropProfileDirection.Name = "cboPropProfileDirection"
        Me.tipDefault.SetToolTip(Me.cboPropProfileDirection, resources.GetString("cboPropProfileDirection.ToolTip"))
        '
        'lblPropProfileBearing
        '
        resources.ApplyResources(Me.lblPropProfileBearing, "lblPropProfileBearing")
        Me.lblPropProfileBearing.Name = "lblPropProfileBearing"
        '
        'txtPropProfileTextDistance
        '
        Me.txtPropProfileTextDistance.DecimalPlaces = 2
        Me.txtPropProfileTextDistance.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropProfileTextDistance, "txtPropProfileTextDistance")
        Me.txtPropProfileTextDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtPropProfileTextDistance.Name = "txtPropProfileTextDistance"
        Me.tipDefault.SetToolTip(Me.txtPropProfileTextDistance, resources.GetString("txtPropProfileTextDistance.ToolTip"))
        Me.txtPropProfileTextDistance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropProfileTextDistance
        '
        resources.ApplyResources(Me.lblPropProfileTextDistance, "lblPropProfileTextDistance")
        Me.lblPropProfileTextDistance.Name = "lblPropProfileTextDistance"
        Me.tipDefault.SetToolTip(Me.lblPropProfileTextDistance, resources.GetString("lblPropProfileTextDistance.ToolTip"))
        '
        'cboPropProfileTextPosition
        '
        Me.cboPropProfileTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropProfileTextPosition, "cboPropProfileTextPosition")
        Me.cboPropProfileTextPosition.Items.AddRange(New Object() {resources.GetString("cboPropProfileTextPosition.Items"), resources.GetString("cboPropProfileTextPosition.Items1"), resources.GetString("cboPropProfileTextPosition.Items2"), resources.GetString("cboPropProfileTextPosition.Items3"), resources.GetString("cboPropProfileTextPosition.Items4"), resources.GetString("cboPropProfileTextPosition.Items5"), resources.GetString("cboPropProfileTextPosition.Items6"), resources.GetString("cboPropProfileTextPosition.Items7"), resources.GetString("cboPropProfileTextPosition.Items8")})
        Me.cboPropProfileTextPosition.Name = "cboPropProfileTextPosition"
        Me.tipDefault.SetToolTip(Me.cboPropProfileTextPosition, resources.GetString("cboPropProfileTextPosition.ToolTip"))
        '
        'lblPropProfileTextPosition
        '
        resources.ApplyResources(Me.lblPropProfileTextPosition, "lblPropProfileTextPosition")
        Me.lblPropProfileTextPosition.Name = "lblPropProfileTextPosition"
        '
        'pnlPropQuota
        '
        Me.pnlPropQuota.Controls.Add(Me.cboPropQuotaFormat)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaFormat)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaTextPosition)
        Me.pnlPropQuota.Controls.Add(Me.cboPropQuotaTextPosition)
        Me.pnlPropQuota.Controls.Add(Me.cmdPropQuotaOtherOptions)
        Me.pnlPropQuota.Controls.Add(Me.cmdPropQuotaTrigpoint)
        Me.pnlPropQuota.Controls.Add(Me.txtPropQuotaRelativeTrigpoint)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaRelativeTrigpoint)
        Me.pnlPropQuota.Controls.Add(Me.cboPropQuotaType)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaType)
        Me.pnlPropQuota.Controls.Add(Me.cboPropQuotaValueType)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaValueType)
        Me.pnlPropQuota.Controls.Add(Me.cboPropQuotaValue)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaValue)
        Me.pnlPropQuota.Controls.Add(Me.cboPropQuotaAlign)
        Me.pnlPropQuota.Controls.Add(Me.lblPropQuotaAlign)
        resources.ApplyResources(Me.pnlPropQuota, "pnlPropQuota")
        Me.pnlPropQuota.Name = "pnlPropQuota"
        '
        'cboPropQuotaFormat
        '
        Me.cboPropQuotaFormat.FormattingEnabled = True
        Me.cboPropQuotaFormat.Items.AddRange(New Object() {resources.GetString("cboPropQuotaFormat.Items"), resources.GetString("cboPropQuotaFormat.Items1"), resources.GetString("cboPropQuotaFormat.Items2"), resources.GetString("cboPropQuotaFormat.Items3")})
        resources.ApplyResources(Me.cboPropQuotaFormat, "cboPropQuotaFormat")
        Me.cboPropQuotaFormat.Name = "cboPropQuotaFormat"
        '
        'lblPropQuotaFormat
        '
        resources.ApplyResources(Me.lblPropQuotaFormat, "lblPropQuotaFormat")
        Me.lblPropQuotaFormat.Name = "lblPropQuotaFormat"
        '
        'lblPropQuotaTextPosition
        '
        resources.ApplyResources(Me.lblPropQuotaTextPosition, "lblPropQuotaTextPosition")
        Me.lblPropQuotaTextPosition.Name = "lblPropQuotaTextPosition"
        '
        'cboPropQuotaTextPosition
        '
        Me.cboPropQuotaTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaTextPosition.FormattingEnabled = True
        Me.cboPropQuotaTextPosition.Items.AddRange(New Object() {resources.GetString("cboPropQuotaTextPosition.Items"), resources.GetString("cboPropQuotaTextPosition.Items1")})
        resources.ApplyResources(Me.cboPropQuotaTextPosition, "cboPropQuotaTextPosition")
        Me.cboPropQuotaTextPosition.Name = "cboPropQuotaTextPosition"
        Me.tipDefault.SetToolTip(Me.cboPropQuotaTextPosition, resources.GetString("cboPropQuotaTextPosition.ToolTip"))
        '
        'cmdPropQuotaOtherOptions
        '
        resources.ApplyResources(Me.cmdPropQuotaOtherOptions, "cmdPropQuotaOtherOptions")
        Me.cmdPropQuotaOtherOptions.Name = "cmdPropQuotaOtherOptions"
        Me.tipDefault.SetToolTip(Me.cmdPropQuotaOtherOptions, resources.GetString("cmdPropQuotaOtherOptions.ToolTip"))
        Me.cmdPropQuotaOtherOptions.UseVisualStyleBackColor = True
        '
        'cmdPropQuotaTrigpoint
        '
        resources.ApplyResources(Me.cmdPropQuotaTrigpoint, "cmdPropQuotaTrigpoint")
        Me.cmdPropQuotaTrigpoint.Name = "cmdPropQuotaTrigpoint"
        Me.tipDefault.SetToolTip(Me.cmdPropQuotaTrigpoint, resources.GetString("cmdPropQuotaTrigpoint.ToolTip"))
        Me.cmdPropQuotaTrigpoint.UseVisualStyleBackColor = True
        '
        'txtPropQuotaRelativeTrigpoint
        '
        resources.ApplyResources(Me.txtPropQuotaRelativeTrigpoint, "txtPropQuotaRelativeTrigpoint")
        Me.txtPropQuotaRelativeTrigpoint.Name = "txtPropQuotaRelativeTrigpoint"
        Me.txtPropQuotaRelativeTrigpoint.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtPropQuotaRelativeTrigpoint, resources.GetString("txtPropQuotaRelativeTrigpoint.ToolTip"))
        '
        'lblPropQuotaRelativeTrigpoint
        '
        resources.ApplyResources(Me.lblPropQuotaRelativeTrigpoint, "lblPropQuotaRelativeTrigpoint")
        Me.lblPropQuotaRelativeTrigpoint.Name = "lblPropQuotaRelativeTrigpoint"
        '
        'cboPropQuotaType
        '
        Me.cboPropQuotaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaType.FormattingEnabled = True
        Me.cboPropQuotaType.Items.AddRange(New Object() {resources.GetString("cboPropQuotaType.Items"), resources.GetString("cboPropQuotaType.Items1"), resources.GetString("cboPropQuotaType.Items2"), resources.GetString("cboPropQuotaType.Items3"), resources.GetString("cboPropQuotaType.Items4"), resources.GetString("cboPropQuotaType.Items5"), resources.GetString("cboPropQuotaType.Items6"), resources.GetString("cboPropQuotaType.Items7")})
        resources.ApplyResources(Me.cboPropQuotaType, "cboPropQuotaType")
        Me.cboPropQuotaType.Name = "cboPropQuotaType"
        Me.tipDefault.SetToolTip(Me.cboPropQuotaType, resources.GetString("cboPropQuotaType.ToolTip"))
        '
        'lblPropQuotaType
        '
        resources.ApplyResources(Me.lblPropQuotaType, "lblPropQuotaType")
        Me.lblPropQuotaType.Name = "lblPropQuotaType"
        '
        'cboPropQuotaValueType
        '
        Me.cboPropQuotaValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaValueType.FormattingEnabled = True
        Me.cboPropQuotaValueType.Items.AddRange(New Object() {resources.GetString("cboPropQuotaValueType.Items"), resources.GetString("cboPropQuotaValueType.Items1"), resources.GetString("cboPropQuotaValueType.Items2"), resources.GetString("cboPropQuotaValueType.Items3")})
        resources.ApplyResources(Me.cboPropQuotaValueType, "cboPropQuotaValueType")
        Me.cboPropQuotaValueType.Name = "cboPropQuotaValueType"
        Me.tipDefault.SetToolTip(Me.cboPropQuotaValueType, resources.GetString("cboPropQuotaValueType.ToolTip"))
        '
        'lblPropQuotaValueType
        '
        resources.ApplyResources(Me.lblPropQuotaValueType, "lblPropQuotaValueType")
        Me.lblPropQuotaValueType.Name = "lblPropQuotaValueType"
        '
        'cboPropQuotaValue
        '
        Me.cboPropQuotaValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaValue.FormattingEnabled = True
        Me.cboPropQuotaValue.Items.AddRange(New Object() {resources.GetString("cboPropQuotaValue.Items"), resources.GetString("cboPropQuotaValue.Items1")})
        resources.ApplyResources(Me.cboPropQuotaValue, "cboPropQuotaValue")
        Me.cboPropQuotaValue.Name = "cboPropQuotaValue"
        Me.tipDefault.SetToolTip(Me.cboPropQuotaValue, resources.GetString("cboPropQuotaValue.ToolTip"))
        '
        'lblPropQuotaValue
        '
        resources.ApplyResources(Me.lblPropQuotaValue, "lblPropQuotaValue")
        Me.lblPropQuotaValue.Name = "lblPropQuotaValue"
        '
        'cboPropQuotaAlign
        '
        Me.cboPropQuotaAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropQuotaAlign.FormattingEnabled = True
        Me.cboPropQuotaAlign.Items.AddRange(New Object() {resources.GetString("cboPropQuotaAlign.Items"), resources.GetString("cboPropQuotaAlign.Items1"), resources.GetString("cboPropQuotaAlign.Items2")})
        resources.ApplyResources(Me.cboPropQuotaAlign, "cboPropQuotaAlign")
        Me.cboPropQuotaAlign.Name = "cboPropQuotaAlign"
        Me.tipDefault.SetToolTip(Me.cboPropQuotaAlign, resources.GetString("cboPropQuotaAlign.ToolTip"))
        '
        'lblPropQuotaAlign
        '
        resources.ApplyResources(Me.lblPropQuotaAlign, "lblPropQuotaAlign")
        Me.lblPropQuotaAlign.Name = "lblPropQuotaAlign"
        '
        'pnlPropSketch
        '
        Me.pnlPropSketch.Controls.Add(Me.cmdPropSketchView)
        Me.pnlPropSketch.Controls.Add(Me.txtPropSketchResolution)
        Me.pnlPropSketch.Controls.Add(Me.lblPropSketchResolution)
        Me.pnlPropSketch.Controls.Add(Me.picPropSketch)
        Me.pnlPropSketch.Controls.Add(Me.chkPropSketchMorphingDisabled)
        Me.pnlPropSketch.Controls.Add(Me.chkPropSketchManualAdjust)
        Me.pnlPropSketch.Controls.Add(Me.lblPropSketchEdit)
        Me.pnlPropSketch.Controls.Add(Me.cmdPropSketchEdit)
        resources.ApplyResources(Me.pnlPropSketch, "pnlPropSketch")
        Me.pnlPropSketch.Name = "pnlPropSketch"
        '
        'cmdPropSketchView
        '
        resources.ApplyResources(Me.cmdPropSketchView, "cmdPropSketchView")
        Me.cmdPropSketchView.Name = "cmdPropSketchView"
        Me.tipDefault.SetToolTip(Me.cmdPropSketchView, resources.GetString("cmdPropSketchView.ToolTip"))
        Me.cmdPropSketchView.UseVisualStyleBackColor = True
        '
        'txtPropSketchResolution
        '
        resources.ApplyResources(Me.txtPropSketchResolution, "txtPropSketchResolution")
        Me.txtPropSketchResolution.Name = "txtPropSketchResolution"
        Me.txtPropSketchResolution.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtPropSketchResolution, resources.GetString("txtPropSketchResolution.ToolTip"))
        '
        'lblPropSketchResolution
        '
        resources.ApplyResources(Me.lblPropSketchResolution, "lblPropSketchResolution")
        Me.lblPropSketchResolution.Name = "lblPropSketchResolution"
        '
        'picPropSketch
        '
        resources.ApplyResources(Me.picPropSketch, "picPropSketch")
        Me.picPropSketch.Name = "picPropSketch"
        Me.picPropSketch.TabStop = False
        '
        'chkPropSketchMorphingDisabled
        '
        resources.ApplyResources(Me.chkPropSketchMorphingDisabled, "chkPropSketchMorphingDisabled")
        Me.chkPropSketchMorphingDisabled.Name = "chkPropSketchMorphingDisabled"
        Me.chkPropSketchMorphingDisabled.UseVisualStyleBackColor = True
        '
        'chkPropSketchManualAdjust
        '
        resources.ApplyResources(Me.chkPropSketchManualAdjust, "chkPropSketchManualAdjust")
        Me.chkPropSketchManualAdjust.Name = "chkPropSketchManualAdjust"
        Me.chkPropSketchManualAdjust.UseVisualStyleBackColor = True
        '
        'lblPropSketchEdit
        '
        resources.ApplyResources(Me.lblPropSketchEdit, "lblPropSketchEdit")
        Me.lblPropSketchEdit.Name = "lblPropSketchEdit"
        '
        'cmdPropSketchEdit
        '
        resources.ApplyResources(Me.cmdPropSketchEdit, "cmdPropSketchEdit")
        Me.cmdPropSketchEdit.Name = "cmdPropSketchEdit"
        Me.tipDefault.SetToolTip(Me.cmdPropSketchEdit, resources.GetString("cmdPropSketchEdit.ToolTip"))
        Me.cmdPropSketchEdit.UseVisualStyleBackColor = True
        '
        'pnlPropMergeMode
        '
        Me.pnlPropMergeMode.Controls.Add(Me.cboPropMergeMode)
        Me.pnlPropMergeMode.Controls.Add(Me.lblPropMergeMode)
        resources.ApplyResources(Me.pnlPropMergeMode, "pnlPropMergeMode")
        Me.pnlPropMergeMode.Name = "pnlPropMergeMode"
        '
        'cboPropMergeMode
        '
        Me.cboPropMergeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropMergeMode.FormattingEnabled = True
        Me.cboPropMergeMode.Items.AddRange(New Object() {resources.GetString("cboPropMergeMode.Items"), resources.GetString("cboPropMergeMode.Items1")})
        resources.ApplyResources(Me.cboPropMergeMode, "cboPropMergeMode")
        Me.cboPropMergeMode.Name = "cboPropMergeMode"
        Me.tipDefault.SetToolTip(Me.cboPropMergeMode, resources.GetString("cboPropMergeMode.ToolTip"))
        '
        'lblPropMergeMode
        '
        resources.ApplyResources(Me.lblPropMergeMode, "lblPropMergeMode")
        Me.lblPropMergeMode.Name = "lblPropMergeMode"
        '
        'pnlPropTransparency
        '
        Me.pnlPropTransparency.Controls.Add(Me.txtPropTransparency)
        Me.pnlPropTransparency.Controls.Add(Me.lblPropTransparency)
        resources.ApplyResources(Me.pnlPropTransparency, "pnlPropTransparency")
        Me.pnlPropTransparency.Name = "pnlPropTransparency"
        '
        'txtPropTransparency
        '
        resources.ApplyResources(Me.txtPropTransparency, "txtPropTransparency")
        Me.txtPropTransparency.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txtPropTransparency.Name = "txtPropTransparency"
        Me.tipDefault.SetToolTip(Me.txtPropTransparency, resources.GetString("txtPropTransparency.ToolTip"))
        '
        'lblPropTransparency
        '
        resources.ApplyResources(Me.lblPropTransparency, "lblPropTransparency")
        Me.lblPropTransparency.Name = "lblPropTransparency"
        '
        'pnlPropObjectsBinding
        '
        resources.ApplyResources(Me.pnlPropObjectsBinding, "pnlPropObjectsBinding")
        Me.pnlPropObjectsBinding.Controls.Add(Me.btnPropObjectsSelect)
        Me.pnlPropObjectsBinding.Controls.Add(Me.btnPropObjectsRefresh)
        Me.pnlPropObjectsBinding.Controls.Add(Me.lvPropObjectsBinded)
        Me.pnlPropObjectsBinding.Controls.Add(Me.Label4)
        Me.pnlPropObjectsBinding.Name = "pnlPropObjectsBinding"
        '
        'btnPropObjectsSelect
        '
        resources.ApplyResources(Me.btnPropObjectsSelect, "btnPropObjectsSelect")
        Me.btnPropObjectsSelect.Name = "btnPropObjectsSelect"
        Me.tipDefault.SetToolTip(Me.btnPropObjectsSelect, resources.GetString("btnPropObjectsSelect.ToolTip"))
        Me.btnPropObjectsSelect.UseVisualStyleBackColor = True
        '
        'btnPropObjectsRefresh
        '
        resources.ApplyResources(Me.btnPropObjectsRefresh, "btnPropObjectsRefresh")
        Me.btnPropObjectsRefresh.Name = "btnPropObjectsRefresh"
        Me.tipDefault.SetToolTip(Me.btnPropObjectsRefresh, resources.GetString("btnPropObjectsRefresh.ToolTip"))
        Me.btnPropObjectsRefresh.UseVisualStyleBackColor = True
        '
        'lvPropObjectsBinded
        '
        resources.ApplyResources(Me.lvPropObjectsBinded, "lvPropObjectsBinded")
        Me.lvPropObjectsBinded.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lvPropObjectsBinded.FullRowSelect = True
        Me.lvPropObjectsBinded.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvPropObjectsBinded.Name = "lvPropObjectsBinded"
        Me.lvPropObjectsBinded.SmallImageList = Me.imlLayers
        Me.tipDefault.SetToolTip(Me.lvPropObjectsBinded, resources.GetString("lvPropObjectsBinded.ToolTip"))
        Me.lvPropObjectsBinded.UseCompatibleStateImageBehavior = False
        Me.lvPropObjectsBinded.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'pnlPropPointsSequences
        '
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsSequencesDivideAndJoin)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsJoinAndConnect)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsUnjoinAll)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsUnjoin)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsJoin)
        Me.pnlPropPointsSequences.Controls.Add(Me.Label10)
        Me.pnlPropPointsSequences.Controls.Add(Me.Label1)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsSequencesDelete)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsSequencesDivide)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsSequencesRevert)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsSequencesClose)
        Me.pnlPropPointsSequences.Controls.Add(Me.cmdPropPointsSequencesCombine)
        resources.ApplyResources(Me.pnlPropPointsSequences, "pnlPropPointsSequences")
        Me.pnlPropPointsSequences.Name = "pnlPropPointsSequences"
        '
        'cmdPropPointsSequencesDivideAndJoin
        '
        resources.ApplyResources(Me.cmdPropPointsSequencesDivideAndJoin, "cmdPropPointsSequencesDivideAndJoin")
        Me.cmdPropPointsSequencesDivideAndJoin.Name = "cmdPropPointsSequencesDivideAndJoin"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsSequencesDivideAndJoin, resources.GetString("cmdPropPointsSequencesDivideAndJoin.ToolTip"))
        Me.cmdPropPointsSequencesDivideAndJoin.UseVisualStyleBackColor = True
        '
        'cmdPropPointsJoinAndConnect
        '
        resources.ApplyResources(Me.cmdPropPointsJoinAndConnect, "cmdPropPointsJoinAndConnect")
        Me.cmdPropPointsJoinAndConnect.Name = "cmdPropPointsJoinAndConnect"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsJoinAndConnect, resources.GetString("cmdPropPointsJoinAndConnect.ToolTip"))
        Me.cmdPropPointsJoinAndConnect.UseVisualStyleBackColor = True
        '
        'cmdPropPointsUnjoinAll
        '
        resources.ApplyResources(Me.cmdPropPointsUnjoinAll, "cmdPropPointsUnjoinAll")
        Me.cmdPropPointsUnjoinAll.Name = "cmdPropPointsUnjoinAll"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsUnjoinAll, resources.GetString("cmdPropPointsUnjoinAll.ToolTip"))
        Me.cmdPropPointsUnjoinAll.UseVisualStyleBackColor = True
        '
        'cmdPropPointsUnjoin
        '
        resources.ApplyResources(Me.cmdPropPointsUnjoin, "cmdPropPointsUnjoin")
        Me.cmdPropPointsUnjoin.Name = "cmdPropPointsUnjoin"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsUnjoin, resources.GetString("cmdPropPointsUnjoin.ToolTip"))
        Me.cmdPropPointsUnjoin.UseVisualStyleBackColor = True
        '
        'cmdPropPointsJoin
        '
        resources.ApplyResources(Me.cmdPropPointsJoin, "cmdPropPointsJoin")
        Me.cmdPropPointsJoin.Name = "cmdPropPointsJoin"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsJoin, resources.GetString("cmdPropPointsJoin.ToolTip"))
        Me.cmdPropPointsJoin.UseVisualStyleBackColor = True
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cmdPropPointsSequencesDelete
        '
        resources.ApplyResources(Me.cmdPropPointsSequencesDelete, "cmdPropPointsSequencesDelete")
        Me.cmdPropPointsSequencesDelete.Name = "cmdPropPointsSequencesDelete"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsSequencesDelete, resources.GetString("cmdPropPointsSequencesDelete.ToolTip"))
        Me.cmdPropPointsSequencesDelete.UseVisualStyleBackColor = True
        '
        'cmdPropPointsSequencesDivide
        '
        resources.ApplyResources(Me.cmdPropPointsSequencesDivide, "cmdPropPointsSequencesDivide")
        Me.cmdPropPointsSequencesDivide.Name = "cmdPropPointsSequencesDivide"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsSequencesDivide, resources.GetString("cmdPropPointsSequencesDivide.ToolTip"))
        Me.cmdPropPointsSequencesDivide.UseVisualStyleBackColor = True
        '
        'cmdPropPointsSequencesRevert
        '
        resources.ApplyResources(Me.cmdPropPointsSequencesRevert, "cmdPropPointsSequencesRevert")
        Me.cmdPropPointsSequencesRevert.Name = "cmdPropPointsSequencesRevert"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsSequencesRevert, resources.GetString("cmdPropPointsSequencesRevert.ToolTip"))
        Me.cmdPropPointsSequencesRevert.UseVisualStyleBackColor = True
        '
        'cmdPropPointsSequencesClose
        '
        resources.ApplyResources(Me.cmdPropPointsSequencesClose, "cmdPropPointsSequencesClose")
        Me.cmdPropPointsSequencesClose.Name = "cmdPropPointsSequencesClose"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsSequencesClose, resources.GetString("cmdPropPointsSequencesClose.ToolTip"))
        Me.cmdPropPointsSequencesClose.UseVisualStyleBackColor = True
        '
        'cmdPropPointsSequencesCombine
        '
        resources.ApplyResources(Me.cmdPropPointsSequencesCombine, "cmdPropPointsSequencesCombine")
        Me.cmdPropPointsSequencesCombine.Name = "cmdPropPointsSequencesCombine"
        Me.tipDefault.SetToolTip(Me.cmdPropPointsSequencesCombine, resources.GetString("cmdPropPointsSequencesCombine.ToolTip"))
        Me.cmdPropPointsSequencesCombine.UseVisualStyleBackColor = True
        '
        'pnlPropSequenceLineType
        '
        resources.ApplyResources(Me.pnlPropSequenceLineType, "pnlPropSequenceLineType")
        Me.pnlPropSequenceLineType.Controls.Add(Me.chkPropSequenceLineTypeP)
        Me.pnlPropSequenceLineType.Controls.Add(Me.chkPropSequenceLineType2)
        Me.pnlPropSequenceLineType.Controls.Add(Me.chkPropSequenceLineType1)
        Me.pnlPropSequenceLineType.Controls.Add(Me.chkPropSequenceLineType0)
        Me.pnlPropSequenceLineType.Controls.Add(Me.lblPropSequenceLineType)
        Me.pnlPropSequenceLineType.Name = "pnlPropSequenceLineType"
        '
        'chkPropSequenceLineTypeP
        '
        resources.ApplyResources(Me.chkPropSequenceLineTypeP, "chkPropSequenceLineTypeP")
        Me.chkPropSequenceLineTypeP.Name = "chkPropSequenceLineTypeP"
        Me.tipDefault.SetToolTip(Me.chkPropSequenceLineTypeP, resources.GetString("chkPropSequenceLineTypeP.ToolTip"))
        Me.chkPropSequenceLineTypeP.UseVisualStyleBackColor = True
        '
        'chkPropSequenceLineType2
        '
        resources.ApplyResources(Me.chkPropSequenceLineType2, "chkPropSequenceLineType2")
        Me.chkPropSequenceLineType2.Name = "chkPropSequenceLineType2"
        Me.chkPropSequenceLineType2.UseVisualStyleBackColor = True
        '
        'chkPropSequenceLineType1
        '
        resources.ApplyResources(Me.chkPropSequenceLineType1, "chkPropSequenceLineType1")
        Me.chkPropSequenceLineType1.Name = "chkPropSequenceLineType1"
        Me.chkPropSequenceLineType1.UseVisualStyleBackColor = True
        '
        'chkPropSequenceLineType0
        '
        resources.ApplyResources(Me.chkPropSequenceLineType0, "chkPropSequenceLineType0")
        Me.chkPropSequenceLineType0.Name = "chkPropSequenceLineType0"
        Me.chkPropSequenceLineType0.UseVisualStyleBackColor = True
        '
        'lblPropSequenceLineType
        '
        resources.ApplyResources(Me.lblPropSequenceLineType, "lblPropSequenceLineType")
        Me.lblPropSequenceLineType.Name = "lblPropSequenceLineType"
        '
        'pnlPropProp
        '
        Me.pnlPropProp.Controls.Add(Me.chkPropShowDataProperties)
        Me.pnlPropProp.Controls.Add(Me.cboPropCategories)
        Me.pnlPropProp.Controls.Add(Me.lblPropCategory)
        resources.ApplyResources(Me.pnlPropProp, "pnlPropProp")
        Me.pnlPropProp.Name = "pnlPropProp"
        '
        'chkPropShowDataProperties
        '
        resources.ApplyResources(Me.chkPropShowDataProperties, "chkPropShowDataProperties")
        Me.chkPropShowDataProperties.Name = "chkPropShowDataProperties"
        Me.tipDefault.SetToolTip(Me.chkPropShowDataProperties, resources.GetString("chkPropShowDataProperties.ToolTip"))
        Me.chkPropShowDataProperties.UseVisualStyleBackColor = True
        '
        'cboPropCategories
        '
        resources.ApplyResources(Me.cboPropCategories, "cboPropCategories")
        Me.cboPropCategories.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboPropCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropCategories.Name = "cboPropCategories"
        Me.tipDefault.SetToolTip(Me.cboPropCategories, resources.GetString("cboPropCategories.ToolTip"))
        '
        'lblPropCategory
        '
        resources.ApplyResources(Me.lblPropCategory, "lblPropCategory")
        Me.lblPropCategory.Name = "lblPropCategory"
        '
        'pnlPropItems
        '
        Me.pnlPropItems.Controls.Add(Me.lblPropItemsSpace)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsVSpace)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsHSpace)
        Me.pnlPropItems.Controls.Add(Me.lblPropItemsAlign)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsHAlignCenter)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsHAlignLeft)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsVAlignTop)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsHAlignRight)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsVAlignMiddle)
        Me.pnlPropItems.Controls.Add(Me.cmdPropItemsVAlignBottom)
        resources.ApplyResources(Me.pnlPropItems, "pnlPropItems")
        Me.pnlPropItems.Name = "pnlPropItems"
        '
        'lblPropItemsSpace
        '
        resources.ApplyResources(Me.lblPropItemsSpace, "lblPropItemsSpace")
        Me.lblPropItemsSpace.Name = "lblPropItemsSpace"
        '
        'cmdPropItemsVSpace
        '
        resources.ApplyResources(Me.cmdPropItemsVSpace, "cmdPropItemsVSpace")
        Me.cmdPropItemsVSpace.Name = "cmdPropItemsVSpace"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsVSpace, resources.GetString("cmdPropItemsVSpace.ToolTip"))
        Me.cmdPropItemsVSpace.UseVisualStyleBackColor = True
        '
        'cmdPropItemsHSpace
        '
        resources.ApplyResources(Me.cmdPropItemsHSpace, "cmdPropItemsHSpace")
        Me.cmdPropItemsHSpace.Name = "cmdPropItemsHSpace"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsHSpace, resources.GetString("cmdPropItemsHSpace.ToolTip"))
        Me.cmdPropItemsHSpace.UseVisualStyleBackColor = True
        '
        'lblPropItemsAlign
        '
        resources.ApplyResources(Me.lblPropItemsAlign, "lblPropItemsAlign")
        Me.lblPropItemsAlign.Name = "lblPropItemsAlign"
        '
        'cmdPropItemsHAlignCenter
        '
        resources.ApplyResources(Me.cmdPropItemsHAlignCenter, "cmdPropItemsHAlignCenter")
        Me.cmdPropItemsHAlignCenter.Name = "cmdPropItemsHAlignCenter"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsHAlignCenter, resources.GetString("cmdPropItemsHAlignCenter.ToolTip"))
        Me.cmdPropItemsHAlignCenter.UseVisualStyleBackColor = True
        '
        'cmdPropItemsHAlignLeft
        '
        resources.ApplyResources(Me.cmdPropItemsHAlignLeft, "cmdPropItemsHAlignLeft")
        Me.cmdPropItemsHAlignLeft.Name = "cmdPropItemsHAlignLeft"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsHAlignLeft, resources.GetString("cmdPropItemsHAlignLeft.ToolTip"))
        Me.cmdPropItemsHAlignLeft.UseVisualStyleBackColor = True
        '
        'cmdPropItemsVAlignTop
        '
        resources.ApplyResources(Me.cmdPropItemsVAlignTop, "cmdPropItemsVAlignTop")
        Me.cmdPropItemsVAlignTop.Name = "cmdPropItemsVAlignTop"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsVAlignTop, resources.GetString("cmdPropItemsVAlignTop.ToolTip"))
        Me.cmdPropItemsVAlignTop.UseVisualStyleBackColor = True
        '
        'cmdPropItemsHAlignRight
        '
        resources.ApplyResources(Me.cmdPropItemsHAlignRight, "cmdPropItemsHAlignRight")
        Me.cmdPropItemsHAlignRight.Name = "cmdPropItemsHAlignRight"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsHAlignRight, resources.GetString("cmdPropItemsHAlignRight.ToolTip"))
        Me.cmdPropItemsHAlignRight.UseVisualStyleBackColor = True
        '
        'cmdPropItemsVAlignMiddle
        '
        resources.ApplyResources(Me.cmdPropItemsVAlignMiddle, "cmdPropItemsVAlignMiddle")
        Me.cmdPropItemsVAlignMiddle.Name = "cmdPropItemsVAlignMiddle"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsVAlignMiddle, resources.GetString("cmdPropItemsVAlignMiddle.ToolTip"))
        Me.cmdPropItemsVAlignMiddle.UseVisualStyleBackColor = True
        '
        'cmdPropItemsVAlignBottom
        '
        resources.ApplyResources(Me.cmdPropItemsVAlignBottom, "cmdPropItemsVAlignBottom")
        Me.cmdPropItemsVAlignBottom.Name = "cmdPropItemsVAlignBottom"
        Me.tipDefault.SetToolTip(Me.cmdPropItemsVAlignBottom, resources.GetString("cmdPropItemsVAlignBottom.ToolTip"))
        Me.cmdPropItemsVAlignBottom.UseVisualStyleBackColor = True
        '
        'pnlPropPopup
        '
        resources.ApplyResources(Me.pnlPropPopup, "pnlPropPopup")
        Me.pnlPropPopup.Controls.Add(Me.btnPropWarningClose)
        Me.pnlPropPopup.Controls.Add(Me.lblPropPopupWarning)
        Me.pnlPropPopup.Controls.Add(Me.picPropPopupWarning)
        Me.pnlPropPopup.Name = "pnlPropPopup"
        '
        'btnPropWarningClose
        '
        resources.ApplyResources(Me.btnPropWarningClose, "btnPropWarningClose")
        Me.btnPropWarningClose.BackColor = System.Drawing.Color.Transparent
        Me.btnPropWarningClose.FlatAppearance.BorderSize = 0
        Me.btnPropWarningClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPropWarningClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPropWarningClose.Name = "btnPropWarningClose"
        Me.tipDefault.SetToolTip(Me.btnPropWarningClose, resources.GetString("btnPropWarningClose.ToolTip"))
        Me.btnPropWarningClose.UseVisualStyleBackColor = False
        '
        'lblPropPopupWarning
        '
        resources.ApplyResources(Me.lblPropPopupWarning, "lblPropPopupWarning")
        Me.lblPropPopupWarning.Name = "lblPropPopupWarning"
        '
        'picPropPopupWarning
        '
        resources.ApplyResources(Me.picPropPopupWarning, "picPropPopupWarning")
        Me.picPropPopupWarning.Name = "picPropPopupWarning"
        Me.picPropPopupWarning.TabStop = False
        '
        'pnlPropProfileSplayBorder
        '
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.txtPropProfileSplayNegInclinationRangeMax)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.txtPropProfileSplayNegInclinationRangeMin)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.lblPropProfileSplayNegInclinationRange)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.txtPropProfileSplayPosInclinationRangeMax)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.txtPropProfileSplayPosInclinationRangeMin)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.cmdPropProfileSplay)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.lblPropProfileSplay)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.txtPropProfileSplayMaxVariationAngle)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.lblPropProfileSplayMaxVariationAngle)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.lblPropProfileSplayProjectionAngle)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.txtPropProfileSplayProjectionAngle)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.picPropProfileProjectionSchema)
        Me.pnlPropProfileSplayBorder.Controls.Add(Me.lblPropProfileSplayPosInclinationRange)
        resources.ApplyResources(Me.pnlPropProfileSplayBorder, "pnlPropProfileSplayBorder")
        Me.pnlPropProfileSplayBorder.Name = "pnlPropProfileSplayBorder"
        '
        'txtPropProfileSplayNegInclinationRangeMax
        '
        Me.txtPropProfileSplayNegInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropProfileSplayNegInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayNegInclinationRangeMax, "txtPropProfileSplayNegInclinationRangeMax")
        Me.txtPropProfileSplayNegInclinationRangeMax.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPropProfileSplayNegInclinationRangeMax.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayNegInclinationRangeMax.Name = "txtPropProfileSplayNegInclinationRangeMax"
        Me.tipDefault.SetToolTip(Me.txtPropProfileSplayNegInclinationRangeMax, resources.GetString("txtPropProfileSplayNegInclinationRangeMax.ToolTip"))
        '
        'txtPropProfileSplayNegInclinationRangeMin
        '
        Me.txtPropProfileSplayNegInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropProfileSplayNegInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayNegInclinationRangeMin, "txtPropProfileSplayNegInclinationRangeMin")
        Me.txtPropProfileSplayNegInclinationRangeMin.Maximum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtPropProfileSplayNegInclinationRangeMin.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayNegInclinationRangeMin.Name = "txtPropProfileSplayNegInclinationRangeMin"
        Me.tipDefault.SetToolTip(Me.txtPropProfileSplayNegInclinationRangeMin, resources.GetString("txtPropProfileSplayNegInclinationRangeMin.ToolTip"))
        Me.txtPropProfileSplayNegInclinationRangeMin.Value = New Decimal(New Integer() {90, 0, 0, -2147483648})
        '
        'lblPropProfileSplayNegInclinationRange
        '
        resources.ApplyResources(Me.lblPropProfileSplayNegInclinationRange, "lblPropProfileSplayNegInclinationRange")
        Me.lblPropProfileSplayNegInclinationRange.Name = "lblPropProfileSplayNegInclinationRange"
        Me.tipDefault.SetToolTip(Me.lblPropProfileSplayNegInclinationRange, resources.GetString("lblPropProfileSplayNegInclinationRange.ToolTip"))
        '
        'txtPropProfileSplayPosInclinationRangeMax
        '
        Me.txtPropProfileSplayPosInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropProfileSplayPosInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayPosInclinationRangeMax, "txtPropProfileSplayPosInclinationRangeMax")
        Me.txtPropProfileSplayPosInclinationRangeMax.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayPosInclinationRangeMax.Name = "txtPropProfileSplayPosInclinationRangeMax"
        Me.tipDefault.SetToolTip(Me.txtPropProfileSplayPosInclinationRangeMax, resources.GetString("txtPropProfileSplayPosInclinationRangeMax.ToolTip"))
        Me.txtPropProfileSplayPosInclinationRangeMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'txtPropProfileSplayPosInclinationRangeMin
        '
        Me.txtPropProfileSplayPosInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropProfileSplayPosInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropProfileSplayPosInclinationRangeMin, "txtPropProfileSplayPosInclinationRangeMin")
        Me.txtPropProfileSplayPosInclinationRangeMin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayPosInclinationRangeMin.Name = "txtPropProfileSplayPosInclinationRangeMin"
        Me.tipDefault.SetToolTip(Me.txtPropProfileSplayPosInclinationRangeMin, resources.GetString("txtPropProfileSplayPosInclinationRangeMin.ToolTip"))
        '
        'cmdPropProfileSplay
        '
        resources.ApplyResources(Me.cmdPropProfileSplay, "cmdPropProfileSplay")
        Me.cmdPropProfileSplay.Name = "cmdPropProfileSplay"
        Me.tipDefault.SetToolTip(Me.cmdPropProfileSplay, resources.GetString("cmdPropProfileSplay.ToolTip"))
        Me.cmdPropProfileSplay.UseVisualStyleBackColor = True
        '
        'lblPropProfileSplay
        '
        resources.ApplyResources(Me.lblPropProfileSplay, "lblPropProfileSplay")
        Me.lblPropProfileSplay.Name = "lblPropProfileSplay"
        '
        'txtPropProfileSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.txtPropProfileSplayMaxVariationAngle, "txtPropProfileSplayMaxVariationAngle")
        Me.txtPropProfileSplayMaxVariationAngle.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.txtPropProfileSplayMaxVariationAngle.Name = "txtPropProfileSplayMaxVariationAngle"
        Me.tipDefault.SetToolTip(Me.txtPropProfileSplayMaxVariationAngle, resources.GetString("txtPropProfileSplayMaxVariationAngle.ToolTip"))
        '
        'lblPropProfileSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.lblPropProfileSplayMaxVariationAngle, "lblPropProfileSplayMaxVariationAngle")
        Me.lblPropProfileSplayMaxVariationAngle.Name = "lblPropProfileSplayMaxVariationAngle"
        Me.tipDefault.SetToolTip(Me.lblPropProfileSplayMaxVariationAngle, resources.GetString("lblPropProfileSplayMaxVariationAngle.ToolTip"))
        '
        'lblPropProfileSplayProjectionAngle
        '
        resources.ApplyResources(Me.lblPropProfileSplayProjectionAngle, "lblPropProfileSplayProjectionAngle")
        Me.lblPropProfileSplayProjectionAngle.Name = "lblPropProfileSplayProjectionAngle"
        Me.tipDefault.SetToolTip(Me.lblPropProfileSplayProjectionAngle, resources.GetString("lblPropProfileSplayProjectionAngle.ToolTip"))
        '
        'txtPropProfileSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropProfileSplayProjectionAngle, "txtPropProfileSplayProjectionAngle")
        Me.txtPropProfileSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropProfileSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropProfileSplayProjectionAngle.Name = "txtPropProfileSplayProjectionAngle"
        Me.tipDefault.SetToolTip(Me.txtPropProfileSplayProjectionAngle, resources.GetString("txtPropProfileSplayProjectionAngle.ToolTip"))
        '
        'picPropProfileProjectionSchema
        '
        resources.ApplyResources(Me.picPropProfileProjectionSchema, "picPropProfileProjectionSchema")
        Me.picPropProfileProjectionSchema.Name = "picPropProfileProjectionSchema"
        Me.picPropProfileProjectionSchema.TabStop = False
        '
        'lblPropProfileSplayPosInclinationRange
        '
        resources.ApplyResources(Me.lblPropProfileSplayPosInclinationRange, "lblPropProfileSplayPosInclinationRange")
        Me.lblPropProfileSplayPosInclinationRange.Name = "lblPropProfileSplayPosInclinationRange"
        Me.tipDefault.SetToolTip(Me.lblPropProfileSplayPosInclinationRange, resources.GetString("lblPropProfileSplayPosInclinationRange.ToolTip"))
        '
        'pnlPropPlanSplayBorder
        '
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.lblPropPlanSplayInclinationRange)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.txtPropPlanSplayInclinationRangeMax)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.txtPropPlanSplayInclinationRangeMin)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.cmdPropPlanSplay)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.lblPropPlanSplay)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.lblPropPlanSplayPlanProjectionPlanType)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.cboPropPlanSplayPlanProjectionType)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.txtPropPlanSplayPlanDeltaZ)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.lblPropPlanSplayPlanDeltaZ)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.txtPropPlanSplayMaxVariationDelta)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.lblPropPlanSplayMaxVariationDelta)
        Me.pnlPropPlanSplayBorder.Controls.Add(Me.picPropPlanProjectionSchema)
        resources.ApplyResources(Me.pnlPropPlanSplayBorder, "pnlPropPlanSplayBorder")
        Me.pnlPropPlanSplayBorder.Name = "pnlPropPlanSplayBorder"
        '
        'lblPropPlanSplayInclinationRange
        '
        resources.ApplyResources(Me.lblPropPlanSplayInclinationRange, "lblPropPlanSplayInclinationRange")
        Me.lblPropPlanSplayInclinationRange.Name = "lblPropPlanSplayInclinationRange"
        Me.tipDefault.SetToolTip(Me.lblPropPlanSplayInclinationRange, resources.GetString("lblPropPlanSplayInclinationRange.ToolTip"))
        '
        'txtPropPlanSplayInclinationRangeMax
        '
        Me.txtPropPlanSplayInclinationRangeMax.DecimalPlaces = 1
        Me.txtPropPlanSplayInclinationRangeMax.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayInclinationRangeMax, "txtPropPlanSplayInclinationRangeMax")
        Me.txtPropPlanSplayInclinationRangeMax.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropPlanSplayInclinationRangeMax.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropPlanSplayInclinationRangeMax.Name = "txtPropPlanSplayInclinationRangeMax"
        Me.tipDefault.SetToolTip(Me.txtPropPlanSplayInclinationRangeMax, resources.GetString("txtPropPlanSplayInclinationRangeMax.ToolTip"))
        Me.txtPropPlanSplayInclinationRangeMax.Value = New Decimal(New Integer() {90, 0, 0, 0})
        '
        'txtPropPlanSplayInclinationRangeMin
        '
        Me.txtPropPlanSplayInclinationRangeMin.DecimalPlaces = 1
        Me.txtPropPlanSplayInclinationRangeMin.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayInclinationRangeMin, "txtPropPlanSplayInclinationRangeMin")
        Me.txtPropPlanSplayInclinationRangeMin.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropPlanSplayInclinationRangeMin.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropPlanSplayInclinationRangeMin.Name = "txtPropPlanSplayInclinationRangeMin"
        Me.tipDefault.SetToolTip(Me.txtPropPlanSplayInclinationRangeMin, resources.GetString("txtPropPlanSplayInclinationRangeMin.ToolTip"))
        Me.txtPropPlanSplayInclinationRangeMin.Value = New Decimal(New Integer() {90, 0, 0, -2147483648})
        '
        'cmdPropPlanSplay
        '
        resources.ApplyResources(Me.cmdPropPlanSplay, "cmdPropPlanSplay")
        Me.cmdPropPlanSplay.Name = "cmdPropPlanSplay"
        Me.tipDefault.SetToolTip(Me.cmdPropPlanSplay, resources.GetString("cmdPropPlanSplay.ToolTip"))
        Me.cmdPropPlanSplay.UseVisualStyleBackColor = True
        '
        'lblPropPlanSplay
        '
        resources.ApplyResources(Me.lblPropPlanSplay, "lblPropPlanSplay")
        Me.lblPropPlanSplay.Name = "lblPropPlanSplay"
        '
        'lblPropPlanSplayPlanProjectionPlanType
        '
        resources.ApplyResources(Me.lblPropPlanSplayPlanProjectionPlanType, "lblPropPlanSplayPlanProjectionPlanType")
        Me.lblPropPlanSplayPlanProjectionPlanType.Name = "lblPropPlanSplayPlanProjectionPlanType"
        Me.tipDefault.SetToolTip(Me.lblPropPlanSplayPlanProjectionPlanType, resources.GetString("lblPropPlanSplayPlanProjectionPlanType.ToolTip"))
        '
        'cboPropPlanSplayPlanProjectionType
        '
        Me.cboPropPlanSplayPlanProjectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropPlanSplayPlanProjectionType, "cboPropPlanSplayPlanProjectionType")
        Me.cboPropPlanSplayPlanProjectionType.Items.AddRange(New Object() {resources.GetString("cboPropPlanSplayPlanProjectionType.Items"), resources.GetString("cboPropPlanSplayPlanProjectionType.Items1"), resources.GetString("cboPropPlanSplayPlanProjectionType.Items2")})
        Me.cboPropPlanSplayPlanProjectionType.Name = "cboPropPlanSplayPlanProjectionType"
        Me.tipDefault.SetToolTip(Me.cboPropPlanSplayPlanProjectionType, resources.GetString("cboPropPlanSplayPlanProjectionType.ToolTip"))
        '
        'txtPropPlanSplayPlanDeltaZ
        '
        Me.txtPropPlanSplayPlanDeltaZ.DecimalPlaces = 1
        Me.txtPropPlanSplayPlanDeltaZ.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayPlanDeltaZ, "txtPropPlanSplayPlanDeltaZ")
        Me.txtPropPlanSplayPlanDeltaZ.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtPropPlanSplayPlanDeltaZ.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.txtPropPlanSplayPlanDeltaZ.Name = "txtPropPlanSplayPlanDeltaZ"
        Me.tipDefault.SetToolTip(Me.txtPropPlanSplayPlanDeltaZ, resources.GetString("txtPropPlanSplayPlanDeltaZ.ToolTip"))
        '
        'lblPropPlanSplayPlanDeltaZ
        '
        resources.ApplyResources(Me.lblPropPlanSplayPlanDeltaZ, "lblPropPlanSplayPlanDeltaZ")
        Me.lblPropPlanSplayPlanDeltaZ.Name = "lblPropPlanSplayPlanDeltaZ"
        Me.tipDefault.SetToolTip(Me.lblPropPlanSplayPlanDeltaZ, resources.GetString("lblPropPlanSplayPlanDeltaZ.ToolTip"))
        '
        'txtPropPlanSplayMaxVariationDelta
        '
        Me.txtPropPlanSplayMaxVariationDelta.DecimalPlaces = 1
        Me.txtPropPlanSplayMaxVariationDelta.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtPropPlanSplayMaxVariationDelta, "txtPropPlanSplayMaxVariationDelta")
        Me.txtPropPlanSplayMaxVariationDelta.Name = "txtPropPlanSplayMaxVariationDelta"
        Me.tipDefault.SetToolTip(Me.txtPropPlanSplayMaxVariationDelta, resources.GetString("txtPropPlanSplayMaxVariationDelta.ToolTip"))
        '
        'lblPropPlanSplayMaxVariationDelta
        '
        resources.ApplyResources(Me.lblPropPlanSplayMaxVariationDelta, "lblPropPlanSplayMaxVariationDelta")
        Me.lblPropPlanSplayMaxVariationDelta.Name = "lblPropPlanSplayMaxVariationDelta"
        Me.tipDefault.SetToolTip(Me.lblPropPlanSplayMaxVariationDelta, resources.GetString("lblPropPlanSplayMaxVariationDelta.ToolTip"))
        '
        'picPropPlanProjectionSchema
        '
        resources.ApplyResources(Me.picPropPlanProjectionSchema, "picPropPlanProjectionSchema")
        Me.picPropPlanProjectionSchema.Name = "picPropPlanProjectionSchema"
        Me.picPropPlanProjectionSchema.TabStop = False
        '
        'pnlPropDataProperties
        '
        resources.ApplyResources(Me.pnlPropDataProperties, "pnlPropDataProperties")
        Me.pnlPropDataProperties.Controls.Add(Me.lblPropDesignDataProperties)
        Me.pnlPropDataProperties.Controls.Add(Me.prpPropDesignDataProperties)
        Me.pnlPropDataProperties.Name = "pnlPropDataProperties"
        '
        'lblPropDesignDataProperties
        '
        resources.ApplyResources(Me.lblPropDesignDataProperties, "lblPropDesignDataProperties")
        Me.lblPropDesignDataProperties.Name = "lblPropDesignDataProperties"
        '
        'prpPropDesignDataProperties
        '
        resources.ApplyResources(Me.prpPropDesignDataProperties, "prpPropDesignDataProperties")
        Me.prpPropDesignDataProperties.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.prpPropDesignDataProperties.CommandsVisibleIfAvailable = False
        Me.prpPropDesignDataProperties.ContextMenuStrip = Me.mnuDesignDataProperties
        Me.prpPropDesignDataProperties.LineColor = System.Drawing.SystemColors.ControlDark
        Me.prpPropDesignDataProperties.Name = "prpPropDesignDataProperties"
        Me.prpPropDesignDataProperties.ToolbarVisible = False
        '
        'mnuDesignDataProperties
        '
        resources.ApplyResources(Me.mnuDesignDataProperties, "mnuDesignDataProperties")
        Me.mnuDesignDataProperties.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignDataPropertiesEdit, Me.ToolStripSeparator35, Me.mnuDesignDataPropertiesDelete})
        Me.mnuDesignDataProperties.Name = "mnuSegmentsDataFields"
        '
        'mnuDesignDataPropertiesEdit
        '
        Me.mnuDesignDataPropertiesEdit.Name = "mnuDesignDataPropertiesEdit"
        resources.ApplyResources(Me.mnuDesignDataPropertiesEdit, "mnuDesignDataPropertiesEdit")
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        resources.ApplyResources(Me.ToolStripSeparator35, "ToolStripSeparator35")
        '
        'mnuDesignDataPropertiesDelete
        '
        resources.ApplyResources(Me.mnuDesignDataPropertiesDelete, "mnuDesignDataPropertiesDelete")
        Me.mnuDesignDataPropertiesDelete.Name = "mnuDesignDataPropertiesDelete"
        '
        'pnlPropCrossSectionSplayBorder
        '
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.txtPropCrossSectionSplayProjectionVerticalAngle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.chkPropCrossSectionShowOnlyCutSplay)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.cmdPropCrossSectionSplay)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.chkPropCrossSectionSplayText)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.Label8)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.txtPropCrossSectionSplayMaxVariationAngle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.lblPropCrossSectionSplayMaxVariationAngle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.lblPropCrossSectionSplayProjectionAngle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.cboPropCrossSectionSplayLineStyle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.txtPropCrossSectionSplayProjectionAngle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.lblPropCrossSectionSplayLineStyle)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.picPropCrossSectionProjectionSchema)
        Me.pnlPropCrossSectionSplayBorder.Controls.Add(Me.chkPropCrossSectionShowSplayBorder)
        resources.ApplyResources(Me.pnlPropCrossSectionSplayBorder, "pnlPropCrossSectionSplayBorder")
        Me.pnlPropCrossSectionSplayBorder.Name = "pnlPropCrossSectionSplayBorder"
        '
        'txtPropCrossSectionSplayProjectionVerticalAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayProjectionVerticalAngle, "txtPropCrossSectionSplayProjectionVerticalAngle")
        Me.txtPropCrossSectionSplayProjectionVerticalAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayProjectionVerticalAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionSplayProjectionVerticalAngle.Name = "txtPropCrossSectionSplayProjectionVerticalAngle"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionSplayProjectionVerticalAngle, resources.GetString("txtPropCrossSectionSplayProjectionVerticalAngle.ToolTip"))
        '
        'chkPropCrossSectionShowOnlyCutSplay
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowOnlyCutSplay, "chkPropCrossSectionShowOnlyCutSplay")
        Me.chkPropCrossSectionShowOnlyCutSplay.Name = "chkPropCrossSectionShowOnlyCutSplay"
        Me.chkPropCrossSectionShowOnlyCutSplay.UseVisualStyleBackColor = True
        '
        'cmdPropCrossSectionSplay
        '
        resources.ApplyResources(Me.cmdPropCrossSectionSplay, "cmdPropCrossSectionSplay")
        Me.cmdPropCrossSectionSplay.Name = "cmdPropCrossSectionSplay"
        Me.tipDefault.SetToolTip(Me.cmdPropCrossSectionSplay, resources.GetString("cmdPropCrossSectionSplay.ToolTip"))
        Me.cmdPropCrossSectionSplay.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionSplayText
        '
        resources.ApplyResources(Me.chkPropCrossSectionSplayText, "chkPropCrossSectionSplayText")
        Me.chkPropCrossSectionSplayText.Name = "chkPropCrossSectionSplayText"
        Me.chkPropCrossSectionSplayText.UseVisualStyleBackColor = True
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'txtPropCrossSectionSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayMaxVariationAngle, "txtPropCrossSectionSplayMaxVariationAngle")
        Me.txtPropCrossSectionSplayMaxVariationAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayMaxVariationAngle.Name = "txtPropCrossSectionSplayMaxVariationAngle"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionSplayMaxVariationAngle, resources.GetString("txtPropCrossSectionSplayMaxVariationAngle.ToolTip"))
        '
        'lblPropCrossSectionSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayMaxVariationAngle, "lblPropCrossSectionSplayMaxVariationAngle")
        Me.lblPropCrossSectionSplayMaxVariationAngle.Name = "lblPropCrossSectionSplayMaxVariationAngle"
        Me.tipDefault.SetToolTip(Me.lblPropCrossSectionSplayMaxVariationAngle, resources.GetString("lblPropCrossSectionSplayMaxVariationAngle.ToolTip"))
        '
        'lblPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayProjectionAngle, "lblPropCrossSectionSplayProjectionAngle")
        Me.lblPropCrossSectionSplayProjectionAngle.Name = "lblPropCrossSectionSplayProjectionAngle"
        Me.tipDefault.SetToolTip(Me.lblPropCrossSectionSplayProjectionAngle, resources.GetString("lblPropCrossSectionSplayProjectionAngle.ToolTip"))
        '
        'cboPropCrossSectionSplayLineStyle
        '
        Me.cboPropCrossSectionSplayLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionSplayLineStyle, "cboPropCrossSectionSplayLineStyle")
        Me.cboPropCrossSectionSplayLineStyle.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionSplayLineStyle.Items"), resources.GetString("cboPropCrossSectionSplayLineStyle.Items1")})
        Me.cboPropCrossSectionSplayLineStyle.Name = "cboPropCrossSectionSplayLineStyle"
        '
        'txtPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayProjectionAngle, "txtPropCrossSectionSplayProjectionAngle")
        Me.txtPropCrossSectionSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionSplayProjectionAngle.Name = "txtPropCrossSectionSplayProjectionAngle"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionSplayProjectionAngle, resources.GetString("txtPropCrossSectionSplayProjectionAngle.ToolTip"))
        '
        'lblPropCrossSectionSplayLineStyle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayLineStyle, "lblPropCrossSectionSplayLineStyle")
        Me.lblPropCrossSectionSplayLineStyle.Name = "lblPropCrossSectionSplayLineStyle"
        Me.tipDefault.SetToolTip(Me.lblPropCrossSectionSplayLineStyle, resources.GetString("lblPropCrossSectionSplayLineStyle.ToolTip"))
        '
        'picPropCrossSectionProjectionSchema
        '
        resources.ApplyResources(Me.picPropCrossSectionProjectionSchema, "picPropCrossSectionProjectionSchema")
        Me.picPropCrossSectionProjectionSchema.Name = "picPropCrossSectionProjectionSchema"
        Me.picPropCrossSectionProjectionSchema.TabStop = False
        '
        'chkPropCrossSectionShowSplayBorder
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowSplayBorder, "chkPropCrossSectionShowSplayBorder")
        Me.chkPropCrossSectionShowSplayBorder.Name = "chkPropCrossSectionShowSplayBorder"
        Me.chkPropCrossSectionShowSplayBorder.UseVisualStyleBackColor = True
        '
        'pnlPropSegmentInfo
        '
        Me.pnlPropSegmentInfo.Controls.Add(Me.cmdPropSegmentGoto)
        Me.pnlPropSegmentInfo.Controls.Add(Me.cmdPropSegmentEndShot)
        Me.pnlPropSegmentInfo.Controls.Add(Me.cmdPropSegmentBeginShot)
        Me.pnlPropSegmentInfo.Controls.Add(Me.cmdPropSegmentInvert)
        Me.pnlPropSegmentInfo.Controls.Add(Me.lblPropSegment)
        Me.pnlPropSegmentInfo.Controls.Add(Me.lvSegmentInfo)
        Me.pnlPropSegmentInfo.Controls.Add(Me.cmdSegmentSetCaveBranch)
        Me.pnlPropSegmentInfo.Controls.Add(Me.cmdSegmentSetCurrentCaveBranch)
        resources.ApplyResources(Me.pnlPropSegmentInfo, "pnlPropSegmentInfo")
        Me.pnlPropSegmentInfo.Name = "pnlPropSegmentInfo"
        '
        'cmdPropSegmentGoto
        '
        resources.ApplyResources(Me.cmdPropSegmentGoto, "cmdPropSegmentGoto")
        Me.cmdPropSegmentGoto.Name = "cmdPropSegmentGoto"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentGoto, resources.GetString("cmdPropSegmentGoto.ToolTip"))
        Me.cmdPropSegmentGoto.UseVisualStyleBackColor = True
        '
        'cmdPropSegmentEndShot
        '
        resources.ApplyResources(Me.cmdPropSegmentEndShot, "cmdPropSegmentEndShot")
        Me.cmdPropSegmentEndShot.Name = "cmdPropSegmentEndShot"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentEndShot, resources.GetString("cmdPropSegmentEndShot.ToolTip"))
        Me.cmdPropSegmentEndShot.UseVisualStyleBackColor = True
        '
        'cmdPropSegmentBeginShot
        '
        resources.ApplyResources(Me.cmdPropSegmentBeginShot, "cmdPropSegmentBeginShot")
        Me.cmdPropSegmentBeginShot.Name = "cmdPropSegmentBeginShot"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentBeginShot, resources.GetString("cmdPropSegmentBeginShot.ToolTip"))
        Me.cmdPropSegmentBeginShot.UseVisualStyleBackColor = True
        '
        'cmdPropSegmentInvert
        '
        resources.ApplyResources(Me.cmdPropSegmentInvert, "cmdPropSegmentInvert")
        Me.cmdPropSegmentInvert.Name = "cmdPropSegmentInvert"
        Me.tipDefault.SetToolTip(Me.cmdPropSegmentInvert, resources.GetString("cmdPropSegmentInvert.ToolTip"))
        Me.cmdPropSegmentInvert.UseVisualStyleBackColor = True
        '
        'lblPropSegment
        '
        resources.ApplyResources(Me.lblPropSegment, "lblPropSegment")
        Me.lblPropSegment.Name = "lblPropSegment"
        '
        'lvSegmentInfo
        '
        resources.ApplyResources(Me.lvSegmentInfo, "lvSegmentInfo")
        Me.lvSegmentInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvSegmentInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSegmentInfoName, Me.colSegmentInfoValue})
        Me.lvSegmentInfo.ContextMenuStrip = Me.mnuSegmentInfo
        Me.lvSegmentInfo.FullRowSelect = True
        Me.lvSegmentInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvSegmentInfo.Name = "lvSegmentInfo"
        Me.lvSegmentInfo.SmallImageList = Me.iml
        Me.lvSegmentInfo.UseCompatibleStateImageBehavior = False
        Me.lvSegmentInfo.View = System.Windows.Forms.View.Details
        '
        'colSegmentInfoName
        '
        resources.ApplyResources(Me.colSegmentInfoName, "colSegmentInfoName")
        '
        'colSegmentInfoValue
        '
        resources.ApplyResources(Me.colSegmentInfoValue, "colSegmentInfoValue")
        '
        'mnuSegmentInfo
        '
        resources.ApplyResources(Me.mnuSegmentInfo, "mnuSegmentInfo")
        Me.mnuSegmentInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSegmentInfoCopy, Me.mnuSegmentInfoCopyAll, Me.ToolStripMenuItem109, Me.mnuSegmentInfoCopyValue, Me.mnuSegmentInfoCopyAllValue})
        Me.mnuSegmentInfo.Name = "mnuSegmentInfo"
        '
        'mnuSegmentInfoCopy
        '
        resources.ApplyResources(Me.mnuSegmentInfoCopy, "mnuSegmentInfoCopy")
        Me.mnuSegmentInfoCopy.Name = "mnuSegmentInfoCopy"
        '
        'mnuSegmentInfoCopyAll
        '
        Me.mnuSegmentInfoCopyAll.Name = "mnuSegmentInfoCopyAll"
        resources.ApplyResources(Me.mnuSegmentInfoCopyAll, "mnuSegmentInfoCopyAll")
        '
        'ToolStripMenuItem109
        '
        Me.ToolStripMenuItem109.Name = "ToolStripMenuItem109"
        resources.ApplyResources(Me.ToolStripMenuItem109, "ToolStripMenuItem109")
        '
        'mnuSegmentInfoCopyValue
        '
        Me.mnuSegmentInfoCopyValue.Name = "mnuSegmentInfoCopyValue"
        resources.ApplyResources(Me.mnuSegmentInfoCopyValue, "mnuSegmentInfoCopyValue")
        '
        'mnuSegmentInfoCopyAllValue
        '
        Me.mnuSegmentInfoCopyAllValue.Name = "mnuSegmentInfoCopyAllValue"
        resources.ApplyResources(Me.mnuSegmentInfoCopyAllValue, "mnuSegmentInfoCopyAllValue")
        '
        'cmdSegmentSetCaveBranch
        '
        resources.ApplyResources(Me.cmdSegmentSetCaveBranch, "cmdSegmentSetCaveBranch")
        Me.cmdSegmentSetCaveBranch.Name = "cmdSegmentSetCaveBranch"
        Me.tipDefault.SetToolTip(Me.cmdSegmentSetCaveBranch, resources.GetString("cmdSegmentSetCaveBranch.ToolTip"))
        Me.cmdSegmentSetCaveBranch.UseVisualStyleBackColor = True
        '
        'cmdSegmentSetCurrentCaveBranch
        '
        resources.ApplyResources(Me.cmdSegmentSetCurrentCaveBranch, "cmdSegmentSetCurrentCaveBranch")
        Me.cmdSegmentSetCurrentCaveBranch.Name = "cmdSegmentSetCurrentCaveBranch"
        Me.tipDefault.SetToolTip(Me.cmdSegmentSetCurrentCaveBranch, resources.GetString("cmdSegmentSetCurrentCaveBranch.ToolTip"))
        Me.cmdSegmentSetCurrentCaveBranch.UseVisualStyleBackColor = True
        '
        'pnlPropTrigpointInfo
        '
        Me.pnlPropTrigpointInfo.Controls.Add(Me.cmdPropTrigpointGoto)
        Me.pnlPropTrigpointInfo.Controls.Add(Me.cmdPropTrigpointFix)
        Me.pnlPropTrigpointInfo.Controls.Add(Me.cmdPropTrigpointFixToMarker)
        Me.pnlPropTrigpointInfo.Controls.Add(Me.lblpropTrigpoint)
        Me.pnlPropTrigpointInfo.Controls.Add(Me.lvTrigpointInfo)
        resources.ApplyResources(Me.pnlPropTrigpointInfo, "pnlPropTrigpointInfo")
        Me.pnlPropTrigpointInfo.Name = "pnlPropTrigpointInfo"
        '
        'cmdPropTrigpointGoto
        '
        resources.ApplyResources(Me.cmdPropTrigpointGoto, "cmdPropTrigpointGoto")
        Me.cmdPropTrigpointGoto.Name = "cmdPropTrigpointGoto"
        Me.tipDefault.SetToolTip(Me.cmdPropTrigpointGoto, resources.GetString("cmdPropTrigpointGoto.ToolTip"))
        Me.cmdPropTrigpointGoto.UseVisualStyleBackColor = True
        '
        'cmdPropTrigpointFix
        '
        resources.ApplyResources(Me.cmdPropTrigpointFix, "cmdPropTrigpointFix")
        Me.cmdPropTrigpointFix.Name = "cmdPropTrigpointFix"
        Me.tipDefault.SetToolTip(Me.cmdPropTrigpointFix, resources.GetString("cmdPropTrigpointFix.ToolTip"))
        Me.cmdPropTrigpointFix.UseVisualStyleBackColor = True
        '
        'cmdPropTrigpointFixToMarker
        '
        resources.ApplyResources(Me.cmdPropTrigpointFixToMarker, "cmdPropTrigpointFixToMarker")
        Me.cmdPropTrigpointFixToMarker.Name = "cmdPropTrigpointFixToMarker"
        Me.tipDefault.SetToolTip(Me.cmdPropTrigpointFixToMarker, resources.GetString("cmdPropTrigpointFixToMarker.ToolTip"))
        Me.cmdPropTrigpointFixToMarker.UseVisualStyleBackColor = True
        '
        'lblpropTrigpoint
        '
        resources.ApplyResources(Me.lblpropTrigpoint, "lblpropTrigpoint")
        Me.lblpropTrigpoint.Name = "lblpropTrigpoint"
        '
        'lvTrigpointInfo
        '
        resources.ApplyResources(Me.lvTrigpointInfo, "lvTrigpointInfo")
        Me.lvTrigpointInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvTrigpointInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvTrigpointInfo.ContextMenuStrip = Me.mnuTrigpointInfo
        Me.lvTrigpointInfo.FullRowSelect = True
        Me.lvTrigpointInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvTrigpointInfo.Name = "lvTrigpointInfo"
        Me.lvTrigpointInfo.SmallImageList = Me.iml
        Me.lvTrigpointInfo.UseCompatibleStateImageBehavior = False
        Me.lvTrigpointInfo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        resources.ApplyResources(Me.ColumnHeader3, "ColumnHeader3")
        '
        'ColumnHeader4
        '
        resources.ApplyResources(Me.ColumnHeader4, "ColumnHeader4")
        '
        'mnuTrigpointInfo
        '
        resources.ApplyResources(Me.mnuTrigpointInfo, "mnuTrigpointInfo")
        Me.mnuTrigpointInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTrigpointInfoCopy, Me.mnuTrigpointInfoCopyAll, Me.ToolStripMenuItem108, Me.mnuTrigpointInfoCopyValue, Me.mnuTrigpointInfoCopyAllValue})
        Me.mnuTrigpointInfo.Name = "mnuSegmentInfo"
        '
        'mnuTrigpointInfoCopy
        '
        resources.ApplyResources(Me.mnuTrigpointInfoCopy, "mnuTrigpointInfoCopy")
        Me.mnuTrigpointInfoCopy.Name = "mnuTrigpointInfoCopy"
        '
        'mnuTrigpointInfoCopyAll
        '
        Me.mnuTrigpointInfoCopyAll.Name = "mnuTrigpointInfoCopyAll"
        resources.ApplyResources(Me.mnuTrigpointInfoCopyAll, "mnuTrigpointInfoCopyAll")
        '
        'ToolStripMenuItem108
        '
        Me.ToolStripMenuItem108.Name = "ToolStripMenuItem108"
        resources.ApplyResources(Me.ToolStripMenuItem108, "ToolStripMenuItem108")
        '
        'mnuTrigpointInfoCopyValue
        '
        Me.mnuTrigpointInfoCopyValue.Name = "mnuTrigpointInfoCopyValue"
        resources.ApplyResources(Me.mnuTrigpointInfoCopyValue, "mnuTrigpointInfoCopyValue")
        '
        'mnuTrigpointInfoCopyAllValue
        '
        Me.mnuTrigpointInfoCopyAllValue.Name = "mnuTrigpointInfoCopyAllValue"
        resources.ApplyResources(Me.mnuTrigpointInfoCopyAllValue, "mnuTrigpointInfoCopyAllValue")
        '
        'pnlPropCrossSectionMarker
        '
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerDeltaAngleEnabled)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerScaleEnabled)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerUH)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerDH)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerLW)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerRW)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerUH)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerDH)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerDH)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerDHUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerLW)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerRWUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerRW)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerLW)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerRW)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerLWUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerUH)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerUHUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerL)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cboPropCrossSectionMarkerLabelRotation)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.Label15)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.chkPropCrossSectionMarkerLabel)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cboPropCrossSectionMarkerScale)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cboPropCrossSectionMarkerDirection)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerScale)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerDirection)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerLabelDistance)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cmdPropCrossSectionItem)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerLabelDistance)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cmdPropCrossSectionMarkerUDFromDesign)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cboPropCrossSectionMarkerLabelPosition)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerLabelPosition)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cmdPropCrossSectionMarkerLRFromDesign)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lbltxtPropCrossSectionMarkerRUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerDeltaAngle)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerPosition)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerDeltaAngle)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerD)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.Label11)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerR)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.Label12)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.Label13)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerU)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerU)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerL)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerAlign)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerR)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cboPropCrossSectionMarkerPlanAlign)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.txtPropCrossSectionMarkerD)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerDUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerUUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.lblPropCrossSectionMarkerLUM)
        Me.pnlPropCrossSectionMarker.Controls.Add(Me.cboPropCrossSectionMarkerProfileAlign)
        resources.ApplyResources(Me.pnlPropCrossSectionMarker, "pnlPropCrossSectionMarker")
        Me.pnlPropCrossSectionMarker.Name = "pnlPropCrossSectionMarker"
        '
        'chkPropCrossSectionMarkerDeltaAngleEnabled
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerDeltaAngleEnabled, "chkPropCrossSectionMarkerDeltaAngleEnabled")
        Me.chkPropCrossSectionMarkerDeltaAngleEnabled.Name = "chkPropCrossSectionMarkerDeltaAngleEnabled"
        Me.chkPropCrossSectionMarkerDeltaAngleEnabled.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionMarkerScaleEnabled
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerScaleEnabled, "chkPropCrossSectionMarkerScaleEnabled")
        Me.chkPropCrossSectionMarkerScaleEnabled.Name = "chkPropCrossSectionMarkerScaleEnabled"
        Me.chkPropCrossSectionMarkerScaleEnabled.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionMarkerUH
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerUH, "chkPropCrossSectionMarkerUH")
        Me.chkPropCrossSectionMarkerUH.Name = "chkPropCrossSectionMarkerUH"
        Me.tipDefault.SetToolTip(Me.chkPropCrossSectionMarkerUH, resources.GetString("chkPropCrossSectionMarkerUH.ToolTip"))
        Me.chkPropCrossSectionMarkerUH.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionMarkerDH
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerDH, "chkPropCrossSectionMarkerDH")
        Me.chkPropCrossSectionMarkerDH.Name = "chkPropCrossSectionMarkerDH"
        Me.tipDefault.SetToolTip(Me.chkPropCrossSectionMarkerDH, resources.GetString("chkPropCrossSectionMarkerDH.ToolTip"))
        Me.chkPropCrossSectionMarkerDH.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionMarkerLW
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerLW, "chkPropCrossSectionMarkerLW")
        Me.chkPropCrossSectionMarkerLW.Name = "chkPropCrossSectionMarkerLW"
        Me.tipDefault.SetToolTip(Me.chkPropCrossSectionMarkerLW, resources.GetString("chkPropCrossSectionMarkerLW.ToolTip"))
        Me.chkPropCrossSectionMarkerLW.UseVisualStyleBackColor = True
        '
        'chkPropCrossSectionMarkerRW
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerRW, "chkPropCrossSectionMarkerRW")
        Me.chkPropCrossSectionMarkerRW.Name = "chkPropCrossSectionMarkerRW"
        Me.tipDefault.SetToolTip(Me.chkPropCrossSectionMarkerRW, resources.GetString("chkPropCrossSectionMarkerRW.ToolTip"))
        Me.chkPropCrossSectionMarkerRW.UseVisualStyleBackColor = True
        '
        'lblPropCrossSectionMarkerUH
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerUH, "lblPropCrossSectionMarkerUH")
        Me.lblPropCrossSectionMarkerUH.Name = "lblPropCrossSectionMarkerUH"
        '
        'lblPropCrossSectionMarkerDH
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerDH, "lblPropCrossSectionMarkerDH")
        Me.lblPropCrossSectionMarkerDH.Name = "lblPropCrossSectionMarkerDH"
        '
        'txtPropCrossSectionMarkerDH
        '
        Me.txtPropCrossSectionMarkerDH.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerDH.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerDH, "txtPropCrossSectionMarkerDH")
        Me.txtPropCrossSectionMarkerDH.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerDH.Name = "txtPropCrossSectionMarkerDH"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionMarkerDH, resources.GetString("txtPropCrossSectionMarkerDH.ToolTip"))
        Me.txtPropCrossSectionMarkerDH.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionMarkerDHUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerDHUM, "lblPropCrossSectionMarkerDHUM")
        Me.lblPropCrossSectionMarkerDHUM.Name = "lblPropCrossSectionMarkerDHUM"
        '
        'lblPropCrossSectionMarkerLW
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerLW, "lblPropCrossSectionMarkerLW")
        Me.lblPropCrossSectionMarkerLW.Name = "lblPropCrossSectionMarkerLW"
        '
        'lblPropCrossSectionMarkerRWUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerRWUM, "lblPropCrossSectionMarkerRWUM")
        Me.lblPropCrossSectionMarkerRWUM.Name = "lblPropCrossSectionMarkerRWUM"
        '
        'lblPropCrossSectionMarkerRW
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerRW, "lblPropCrossSectionMarkerRW")
        Me.lblPropCrossSectionMarkerRW.Name = "lblPropCrossSectionMarkerRW"
        '
        'txtPropCrossSectionMarkerLW
        '
        Me.txtPropCrossSectionMarkerLW.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerLW.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerLW, "txtPropCrossSectionMarkerLW")
        Me.txtPropCrossSectionMarkerLW.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerLW.Name = "txtPropCrossSectionMarkerLW"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionMarkerLW, resources.GetString("txtPropCrossSectionMarkerLW.ToolTip"))
        Me.txtPropCrossSectionMarkerLW.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropCrossSectionMarkerRW
        '
        Me.txtPropCrossSectionMarkerRW.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerRW.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerRW, "txtPropCrossSectionMarkerRW")
        Me.txtPropCrossSectionMarkerRW.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerRW.Name = "txtPropCrossSectionMarkerRW"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionMarkerRW, resources.GetString("txtPropCrossSectionMarkerRW.ToolTip"))
        Me.txtPropCrossSectionMarkerRW.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionMarkerLWUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerLWUM, "lblPropCrossSectionMarkerLWUM")
        Me.lblPropCrossSectionMarkerLWUM.Name = "lblPropCrossSectionMarkerLWUM"
        '
        'txtPropCrossSectionMarkerUH
        '
        Me.txtPropCrossSectionMarkerUH.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerUH.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerUH, "txtPropCrossSectionMarkerUH")
        Me.txtPropCrossSectionMarkerUH.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerUH.Name = "txtPropCrossSectionMarkerUH"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionMarkerUH, resources.GetString("txtPropCrossSectionMarkerUH.ToolTip"))
        Me.txtPropCrossSectionMarkerUH.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionMarkerUHUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerUHUM, "lblPropCrossSectionMarkerUHUM")
        Me.lblPropCrossSectionMarkerUHUM.Name = "lblPropCrossSectionMarkerUHUM"
        '
        'lblPropCrossSectionMarkerL
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerL, "lblPropCrossSectionMarkerL")
        Me.lblPropCrossSectionMarkerL.Name = "lblPropCrossSectionMarkerL"
        '
        'cboPropCrossSectionMarkerLabelRotation
        '
        Me.cboPropCrossSectionMarkerLabelRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropCrossSectionMarkerLabelRotation.FormattingEnabled = True
        Me.cboPropCrossSectionMarkerLabelRotation.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionMarkerLabelRotation.Items"), resources.GetString("cboPropCrossSectionMarkerLabelRotation.Items1")})
        resources.ApplyResources(Me.cboPropCrossSectionMarkerLabelRotation, "cboPropCrossSectionMarkerLabelRotation")
        Me.cboPropCrossSectionMarkerLabelRotation.Name = "cboPropCrossSectionMarkerLabelRotation"
        Me.tipDefault.SetToolTip(Me.cboPropCrossSectionMarkerLabelRotation, resources.GetString("cboPropCrossSectionMarkerLabelRotation.ToolTip"))
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'chkPropCrossSectionMarkerLabel
        '
        resources.ApplyResources(Me.chkPropCrossSectionMarkerLabel, "chkPropCrossSectionMarkerLabel")
        Me.chkPropCrossSectionMarkerLabel.Name = "chkPropCrossSectionMarkerLabel"
        Me.chkPropCrossSectionMarkerLabel.UseVisualStyleBackColor = True
        '
        'cboPropCrossSectionMarkerScale
        '
        Me.cboPropCrossSectionMarkerScale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropCrossSectionMarkerScale.FormattingEnabled = True
        Me.cboPropCrossSectionMarkerScale.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionMarkerScale.Items"), resources.GetString("cboPropCrossSectionMarkerScale.Items1"), resources.GetString("cboPropCrossSectionMarkerScale.Items2"), resources.GetString("cboPropCrossSectionMarkerScale.Items3"), resources.GetString("cboPropCrossSectionMarkerScale.Items4"), resources.GetString("cboPropCrossSectionMarkerScale.Items5")})
        resources.ApplyResources(Me.cboPropCrossSectionMarkerScale, "cboPropCrossSectionMarkerScale")
        Me.cboPropCrossSectionMarkerScale.Name = "cboPropCrossSectionMarkerScale"
        Me.tipDefault.SetToolTip(Me.cboPropCrossSectionMarkerScale, resources.GetString("cboPropCrossSectionMarkerScale.ToolTip"))
        '
        'cboPropCrossSectionMarkerDirection
        '
        Me.cboPropCrossSectionMarkerDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionMarkerDirection, "cboPropCrossSectionMarkerDirection")
        Me.cboPropCrossSectionMarkerDirection.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionMarkerDirection.Items"), resources.GetString("cboPropCrossSectionMarkerDirection.Items1")})
        Me.cboPropCrossSectionMarkerDirection.Name = "cboPropCrossSectionMarkerDirection"
        Me.tipDefault.SetToolTip(Me.cboPropCrossSectionMarkerDirection, resources.GetString("cboPropCrossSectionMarkerDirection.ToolTip"))
        '
        'lblPropCrossSectionMarkerScale
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerScale, "lblPropCrossSectionMarkerScale")
        Me.lblPropCrossSectionMarkerScale.Name = "lblPropCrossSectionMarkerScale"
        '
        'lblPropCrossSectionMarkerDirection
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerDirection, "lblPropCrossSectionMarkerDirection")
        Me.lblPropCrossSectionMarkerDirection.Name = "lblPropCrossSectionMarkerDirection"
        '
        'txtPropCrossSectionMarkerLabelDistance
        '
        Me.txtPropCrossSectionMarkerLabelDistance.DecimalPlaces = 2
        Me.txtPropCrossSectionMarkerLabelDistance.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerLabelDistance, "txtPropCrossSectionMarkerLabelDistance")
        Me.txtPropCrossSectionMarkerLabelDistance.Name = "txtPropCrossSectionMarkerLabelDistance"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionMarkerLabelDistance, resources.GetString("txtPropCrossSectionMarkerLabelDistance.ToolTip"))
        '
        'cmdPropCrossSectionItem
        '
        resources.ApplyResources(Me.cmdPropCrossSectionItem, "cmdPropCrossSectionItem")
        Me.cmdPropCrossSectionItem.Name = "cmdPropCrossSectionItem"
        Me.tipDefault.SetToolTip(Me.cmdPropCrossSectionItem, resources.GetString("cmdPropCrossSectionItem.ToolTip"))
        Me.cmdPropCrossSectionItem.UseVisualStyleBackColor = True
        '
        'lblPropCrossSectionMarkerLabelDistance
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerLabelDistance, "lblPropCrossSectionMarkerLabelDistance")
        Me.lblPropCrossSectionMarkerLabelDistance.Name = "lblPropCrossSectionMarkerLabelDistance"
        Me.tipDefault.SetToolTip(Me.lblPropCrossSectionMarkerLabelDistance, resources.GetString("lblPropCrossSectionMarkerLabelDistance.ToolTip"))
        '
        'cmdPropCrossSectionMarkerUDFromDesign
        '
        resources.ApplyResources(Me.cmdPropCrossSectionMarkerUDFromDesign, "cmdPropCrossSectionMarkerUDFromDesign")
        Me.cmdPropCrossSectionMarkerUDFromDesign.Name = "cmdPropCrossSectionMarkerUDFromDesign"
        Me.tipDefault.SetToolTip(Me.cmdPropCrossSectionMarkerUDFromDesign, resources.GetString("cmdPropCrossSectionMarkerUDFromDesign.ToolTip"))
        Me.cmdPropCrossSectionMarkerUDFromDesign.UseVisualStyleBackColor = True
        '
        'cboPropCrossSectionMarkerLabelPosition
        '
        Me.cboPropCrossSectionMarkerLabelPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionMarkerLabelPosition, "cboPropCrossSectionMarkerLabelPosition")
        Me.cboPropCrossSectionMarkerLabelPosition.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionMarkerLabelPosition.Items"), resources.GetString("cboPropCrossSectionMarkerLabelPosition.Items1"), resources.GetString("cboPropCrossSectionMarkerLabelPosition.Items2")})
        Me.cboPropCrossSectionMarkerLabelPosition.Name = "cboPropCrossSectionMarkerLabelPosition"
        Me.tipDefault.SetToolTip(Me.cboPropCrossSectionMarkerLabelPosition, resources.GetString("cboPropCrossSectionMarkerLabelPosition.ToolTip"))
        '
        'lblPropCrossSectionMarkerLabelPosition
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerLabelPosition, "lblPropCrossSectionMarkerLabelPosition")
        Me.lblPropCrossSectionMarkerLabelPosition.Name = "lblPropCrossSectionMarkerLabelPosition"
        '
        'cmdPropCrossSectionMarkerLRFromDesign
        '
        resources.ApplyResources(Me.cmdPropCrossSectionMarkerLRFromDesign, "cmdPropCrossSectionMarkerLRFromDesign")
        Me.cmdPropCrossSectionMarkerLRFromDesign.Name = "cmdPropCrossSectionMarkerLRFromDesign"
        Me.tipDefault.SetToolTip(Me.cmdPropCrossSectionMarkerLRFromDesign, resources.GetString("cmdPropCrossSectionMarkerLRFromDesign.ToolTip"))
        Me.cmdPropCrossSectionMarkerLRFromDesign.UseVisualStyleBackColor = True
        '
        'lbltxtPropCrossSectionMarkerRUM
        '
        resources.ApplyResources(Me.lbltxtPropCrossSectionMarkerRUM, "lbltxtPropCrossSectionMarkerRUM")
        Me.lbltxtPropCrossSectionMarkerRUM.Name = "lbltxtPropCrossSectionMarkerRUM"
        '
        'txtPropCrossSectionMarkerDeltaAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionMarkerDeltaAngle, "txtPropCrossSectionMarkerDeltaAngle")
        Me.txtPropCrossSectionMarkerDeltaAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionMarkerDeltaAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionMarkerDeltaAngle.Name = "txtPropCrossSectionMarkerDeltaAngle"
        Me.tipDefault.SetToolTip(Me.txtPropCrossSectionMarkerDeltaAngle, resources.GetString("txtPropCrossSectionMarkerDeltaAngle.ToolTip"))
        '
        'txtPropCrossSectionMarkerPosition
        '
        resources.ApplyResources(Me.txtPropCrossSectionMarkerPosition, "txtPropCrossSectionMarkerPosition")
        Me.txtPropCrossSectionMarkerPosition.Name = "txtPropCrossSectionMarkerPosition"
        Me.txtPropCrossSectionMarkerPosition.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'lblPropCrossSectionMarkerDeltaAngle
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerDeltaAngle, "lblPropCrossSectionMarkerDeltaAngle")
        Me.lblPropCrossSectionMarkerDeltaAngle.Name = "lblPropCrossSectionMarkerDeltaAngle"
        '
        'lblPropCrossSectionMarkerD
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerD, "lblPropCrossSectionMarkerD")
        Me.lblPropCrossSectionMarkerD.Name = "lblPropCrossSectionMarkerD"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        Me.tipDefault.SetToolTip(Me.Label11, resources.GetString("Label11.ToolTip"))
        '
        'lblPropCrossSectionMarkerR
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerR, "lblPropCrossSectionMarkerR")
        Me.lblPropCrossSectionMarkerR.Name = "lblPropCrossSectionMarkerR"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'lblPropCrossSectionMarkerU
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerU, "lblPropCrossSectionMarkerU")
        Me.lblPropCrossSectionMarkerU.Name = "lblPropCrossSectionMarkerU"
        '
        'txtPropCrossSectionMarkerU
        '
        Me.txtPropCrossSectionMarkerU.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerU.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerU, "txtPropCrossSectionMarkerU")
        Me.txtPropCrossSectionMarkerU.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerU.Name = "txtPropCrossSectionMarkerU"
        Me.txtPropCrossSectionMarkerU.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropCrossSectionMarkerL
        '
        Me.txtPropCrossSectionMarkerL.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerL.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerL, "txtPropCrossSectionMarkerL")
        Me.txtPropCrossSectionMarkerL.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerL.Name = "txtPropCrossSectionMarkerL"
        Me.txtPropCrossSectionMarkerL.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionMarkerAlign
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerAlign, "lblPropCrossSectionMarkerAlign")
        Me.lblPropCrossSectionMarkerAlign.Name = "lblPropCrossSectionMarkerAlign"
        '
        'txtPropCrossSectionMarkerR
        '
        Me.txtPropCrossSectionMarkerR.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerR.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerR, "txtPropCrossSectionMarkerR")
        Me.txtPropCrossSectionMarkerR.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerR.Name = "txtPropCrossSectionMarkerR"
        Me.txtPropCrossSectionMarkerR.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cboPropCrossSectionMarkerPlanAlign
        '
        Me.cboPropCrossSectionMarkerPlanAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionMarkerPlanAlign, "cboPropCrossSectionMarkerPlanAlign")
        Me.cboPropCrossSectionMarkerPlanAlign.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionMarkerPlanAlign.Items"), resources.GetString("cboPropCrossSectionMarkerPlanAlign.Items1")})
        Me.cboPropCrossSectionMarkerPlanAlign.Name = "cboPropCrossSectionMarkerPlanAlign"
        '
        'txtPropCrossSectionMarkerD
        '
        Me.txtPropCrossSectionMarkerD.DecimalPlaces = 1
        Me.txtPropCrossSectionMarkerD.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionMarkerD, "txtPropCrossSectionMarkerD")
        Me.txtPropCrossSectionMarkerD.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.txtPropCrossSectionMarkerD.Name = "txtPropCrossSectionMarkerD"
        Me.txtPropCrossSectionMarkerD.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionMarkerDUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerDUM, "lblPropCrossSectionMarkerDUM")
        Me.lblPropCrossSectionMarkerDUM.Name = "lblPropCrossSectionMarkerDUM"
        '
        'lblPropCrossSectionMarkerUUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerUUM, "lblPropCrossSectionMarkerUUM")
        Me.lblPropCrossSectionMarkerUUM.Name = "lblPropCrossSectionMarkerUUM"
        '
        'lblPropCrossSectionMarkerLUM
        '
        resources.ApplyResources(Me.lblPropCrossSectionMarkerLUM, "lblPropCrossSectionMarkerLUM")
        Me.lblPropCrossSectionMarkerLUM.Name = "lblPropCrossSectionMarkerLUM"
        '
        'cboPropCrossSectionMarkerProfileAlign
        '
        Me.cboPropCrossSectionMarkerProfileAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionMarkerProfileAlign, "cboPropCrossSectionMarkerProfileAlign")
        Me.cboPropCrossSectionMarkerProfileAlign.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionMarkerProfileAlign.Items"), resources.GetString("cboPropCrossSectionMarkerProfileAlign.Items1")})
        Me.cboPropCrossSectionMarkerProfileAlign.Name = "cboPropCrossSectionMarkerProfileAlign"
        '
        'pnlPropTrigpointsDistances
        '
        resources.ApplyResources(Me.pnlPropTrigpointsDistances, "pnlPropTrigpointsDistances")
        Me.pnlPropTrigpointsDistances.Controls.Add(Me.chkPropTrigpointDistancesSplays)
        Me.pnlPropTrigpointsDistances.Controls.Add(Me.lblPropTrigpointsDistances)
        Me.pnlPropTrigpointsDistances.Controls.Add(Me.cmdPropTrigpointDistancesCalculate)
        Me.pnlPropTrigpointsDistances.Controls.Add(Me.lvPropTrigpointDistances)
        Me.pnlPropTrigpointsDistances.Name = "pnlPropTrigpointsDistances"
        '
        'chkPropTrigpointDistancesSplays
        '
        resources.ApplyResources(Me.chkPropTrigpointDistancesSplays, "chkPropTrigpointDistancesSplays")
        Me.chkPropTrigpointDistancesSplays.Name = "chkPropTrigpointDistancesSplays"
        Me.chkPropTrigpointDistancesSplays.UseVisualStyleBackColor = True
        '
        'lblPropTrigpointsDistances
        '
        resources.ApplyResources(Me.lblPropTrigpointsDistances, "lblPropTrigpointsDistances")
        Me.lblPropTrigpointsDistances.Name = "lblPropTrigpointsDistances"
        '
        'cmdPropTrigpointDistancesCalculate
        '
        resources.ApplyResources(Me.cmdPropTrigpointDistancesCalculate, "cmdPropTrigpointDistancesCalculate")
        Me.cmdPropTrigpointDistancesCalculate.Name = "cmdPropTrigpointDistancesCalculate"
        Me.tipDefault.SetToolTip(Me.cmdPropTrigpointDistancesCalculate, resources.GetString("cmdPropTrigpointDistancesCalculate.ToolTip"))
        Me.cmdPropTrigpointDistancesCalculate.UseVisualStyleBackColor = True
        '
        'lvPropTrigpointDistances
        '
        resources.ApplyResources(Me.lvPropTrigpointDistances, "lvPropTrigpointDistances")
        Me.lvPropTrigpointDistances.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colValue})
        Me.lvPropTrigpointDistances.FullRowSelect = True
        Me.lvPropTrigpointDistances.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvPropTrigpointDistances.Name = "lvPropTrigpointDistances"
        Me.lvPropTrigpointDistances.UseCompatibleStateImageBehavior = False
        Me.lvPropTrigpointDistances.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        '
        'colValue
        '
        resources.ApplyResources(Me.colValue, "colValue")
        '
        'pnlPropVisibility
        '
        Me.pnlPropVisibility.Controls.Add(Me.cboPropAffinity)
        Me.pnlPropVisibility.Controls.Add(Me.lblPropAffinity)
        Me.pnlPropVisibility.Controls.Add(Me.chkPropVisibleByProfile)
        Me.pnlPropVisibility.Controls.Add(Me.chkPropVisibleByScale)
        Me.pnlPropVisibility.Controls.Add(Me.lblPropVisibleIn)
        Me.pnlPropVisibility.Controls.Add(Me.chkPropVisibleInDesign)
        Me.pnlPropVisibility.Controls.Add(Me.chkPropVisibleInPreview)
        resources.ApplyResources(Me.pnlPropVisibility, "pnlPropVisibility")
        Me.pnlPropVisibility.Name = "pnlPropVisibility"
        '
        'cboPropAffinity
        '
        Me.cboPropAffinity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropAffinity.FormattingEnabled = True
        Me.cboPropAffinity.Items.AddRange(New Object() {resources.GetString("cboPropAffinity.Items"), resources.GetString("cboPropAffinity.Items1")})
        resources.ApplyResources(Me.cboPropAffinity, "cboPropAffinity")
        Me.cboPropAffinity.Name = "cboPropAffinity"
        '
        'lblPropAffinity
        '
        resources.ApplyResources(Me.lblPropAffinity, "lblPropAffinity")
        Me.lblPropAffinity.Name = "lblPropAffinity"
        '
        'chkPropVisibleByProfile
        '
        Me.chkPropVisibleByProfile.Image = Global.cSurveyPC.My.Resources.Resources.to_do_list
        resources.ApplyResources(Me.chkPropVisibleByProfile, "chkPropVisibleByProfile")
        Me.chkPropVisibleByProfile.Name = "chkPropVisibleByProfile"
        Me.tipDefault.SetToolTip(Me.chkPropVisibleByProfile, resources.GetString("chkPropVisibleByProfile.ToolTip"))
        Me.chkPropVisibleByProfile.UseVisualStyleBackColor = True
        '
        'chkPropVisibleByScale
        '
        Me.chkPropVisibleByScale.Image = Global.cSurveyPC.My.Resources.Resources.layers_map
        resources.ApplyResources(Me.chkPropVisibleByScale, "chkPropVisibleByScale")
        Me.chkPropVisibleByScale.Name = "chkPropVisibleByScale"
        Me.tipDefault.SetToolTip(Me.chkPropVisibleByScale, resources.GetString("chkPropVisibleByScale.ToolTip"))
        Me.chkPropVisibleByScale.UseVisualStyleBackColor = True
        '
        'lblPropVisibleIn
        '
        resources.ApplyResources(Me.lblPropVisibleIn, "lblPropVisibleIn")
        Me.lblPropVisibleIn.Name = "lblPropVisibleIn"
        '
        'chkPropVisibleInDesign
        '
        resources.ApplyResources(Me.chkPropVisibleInDesign, "chkPropVisibleInDesign")
        Me.chkPropVisibleInDesign.Name = "chkPropVisibleInDesign"
        Me.tipDefault.SetToolTip(Me.chkPropVisibleInDesign, resources.GetString("chkPropVisibleInDesign.ToolTip"))
        Me.chkPropVisibleInDesign.UseVisualStyleBackColor = True
        '
        'chkPropVisibleInPreview
        '
        resources.ApplyResources(Me.chkPropVisibleInPreview, "chkPropVisibleInPreview")
        Me.chkPropVisibleInPreview.Name = "chkPropVisibleInPreview"
        Me.tipDefault.SetToolTip(Me.chkPropVisibleInPreview, resources.GetString("chkPropVisibleInPreview.ToolTip"))
        Me.chkPropVisibleInPreview.UseVisualStyleBackColor = True
        '
        'pnlPropAttachment
        '
        resources.ApplyResources(Me.pnlPropAttachment, "pnlPropAttachment")
        Me.pnlPropAttachment.Controls.Add(Me.cmdPropAttachmentBrowse)
        Me.pnlPropAttachment.Controls.Add(Me.txtPropAttachmentName)
        Me.pnlPropAttachment.Controls.Add(Me.Label17)
        Me.pnlPropAttachment.Controls.Add(Me.lblPropAttachmentNote)
        Me.pnlPropAttachment.Controls.Add(Me.txtPropAttachmentNote)
        Me.pnlPropAttachment.Controls.Add(Me.picPropAttachmentPreview)
        Me.pnlPropAttachment.Controls.Add(Me.cmdPropAttachmentOpen)
        Me.pnlPropAttachment.Controls.Add(Me.lblPropAttachment)
        Me.pnlPropAttachment.Name = "pnlPropAttachment"
        '
        'cmdPropAttachmentBrowse
        '
        resources.ApplyResources(Me.cmdPropAttachmentBrowse, "cmdPropAttachmentBrowse")
        Me.cmdPropAttachmentBrowse.Name = "cmdPropAttachmentBrowse"
        Me.tipDefault.SetToolTip(Me.cmdPropAttachmentBrowse, resources.GetString("cmdPropAttachmentBrowse.ToolTip"))
        Me.cmdPropAttachmentBrowse.UseVisualStyleBackColor = True
        '
        'txtPropAttachmentName
        '
        resources.ApplyResources(Me.txtPropAttachmentName, "txtPropAttachmentName")
        Me.txtPropAttachmentName.Name = "txtPropAttachmentName"
        Me.tipDefault.SetToolTip(Me.txtPropAttachmentName, resources.GetString("txtPropAttachmentName.ToolTip"))
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'lblPropAttachmentNote
        '
        resources.ApplyResources(Me.lblPropAttachmentNote, "lblPropAttachmentNote")
        Me.lblPropAttachmentNote.Name = "lblPropAttachmentNote"
        '
        'txtPropAttachmentNote
        '
        resources.ApplyResources(Me.txtPropAttachmentNote, "txtPropAttachmentNote")
        Me.txtPropAttachmentNote.Name = "txtPropAttachmentNote"
        '
        'picPropAttachmentPreview
        '
        resources.ApplyResources(Me.picPropAttachmentPreview, "picPropAttachmentPreview")
        Me.picPropAttachmentPreview.Name = "picPropAttachmentPreview"
        Me.picPropAttachmentPreview.TabStop = False
        '
        'cmdPropAttachmentOpen
        '
        resources.ApplyResources(Me.cmdPropAttachmentOpen, "cmdPropAttachmentOpen")
        Me.cmdPropAttachmentOpen.Name = "cmdPropAttachmentOpen"
        Me.tipDefault.SetToolTip(Me.cmdPropAttachmentOpen, resources.GetString("cmdPropAttachmentOpen.ToolTip"))
        Me.cmdPropAttachmentOpen.UseVisualStyleBackColor = True
        '
        'lblPropAttachment
        '
        resources.ApplyResources(Me.lblPropAttachment, "lblPropAttachment")
        Me.lblPropAttachment.Name = "lblPropAttachment"
        '
        'pnlPropLegend
        '
        resources.ApplyResources(Me.pnlPropLegend, "pnlPropLegend")
        Me.pnlPropLegend.Controls.Add(Me.cPropLegendItems)
        Me.pnlPropLegend.Name = "pnlPropLegend"
        '
        'cPropLegendItems
        '
        resources.ApplyResources(Me.cPropLegendItems, "cPropLegendItems")
        Me.cPropLegendItems.BackColor = System.Drawing.SystemColors.Window
        Me.cPropLegendItems.Name = "cPropLegendItems"
        '
        'pnlPropScale
        '
        resources.ApplyResources(Me.pnlPropScale, "pnlPropScale")
        Me.pnlPropScale.Controls.Add(Me.cPropScaleItems)
        Me.pnlPropScale.Name = "pnlPropScale"
        '
        'cPropScaleItems
        '
        resources.ApplyResources(Me.cPropScaleItems, "cPropScaleItems")
        Me.cPropScaleItems.BackColor = System.Drawing.SystemColors.Window
        Me.cPropScaleItems.Name = "cPropScaleItems"
        '
        'pnlPropCompass
        '
        resources.ApplyResources(Me.pnlPropCompass, "pnlPropCompass")
        Me.pnlPropCompass.Controls.Add(Me.cPropCompassItems)
        Me.pnlPropCompass.Name = "pnlPropCompass"
        '
        'cPropCompassItems
        '
        resources.ApplyResources(Me.cPropCompassItems, "cPropCompassItems")
        Me.cPropCompassItems.BackColor = System.Drawing.SystemColors.Window
        Me.cPropCompassItems.Name = "cPropCompassItems"
        '
        'cPropName
        '
        resources.ApplyResources(Me.cPropName, "cPropName")
        Me.cPropName.BackColor = System.Drawing.SystemColors.Window
        Me.cPropName.Name = "cPropName"
        '
        'tabObjectProp3D
        '
        Me.tabObjectProp3D.Controls.Add(Me.tbl3DProp)
        resources.ApplyResources(Me.tabObjectProp3D, "tabObjectProp3D")
        Me.tabObjectProp3D.Name = "tabObjectProp3D"
        Me.tabObjectProp3D.UseVisualStyleBackColor = True
        '
        'tbl3DProp
        '
        resources.ApplyResources(Me.tbl3DProp, "tbl3DProp")
        Me.tbl3DProp.Controls.Add(Me.c3DLinkedSurveys, 0, 5)
        Me.tbl3DProp.Controls.Add(Me.pnl3DMain, 0, 1)
        Me.tbl3DProp.Controls.Add(Me.pnl3DPlotContainer, 0, 7)
        Me.tbl3DProp.Controls.Add(Me.pnl3DSurfaceContainer, 0, 6)
        Me.tbl3DProp.Name = "tbl3DProp"
        '
        'c3DLinkedSurveys
        '
        resources.ApplyResources(Me.c3DLinkedSurveys, "c3DLinkedSurveys")
        Me.c3DLinkedSurveys.BackColor = System.Drawing.SystemColors.Window
        Me.c3DLinkedSurveys.Name = "c3DLinkedSurveys"
        '
        'pnl3DMain
        '
        resources.ApplyResources(Me.pnl3DMain, "pnl3DMain")
        Me.pnl3DMain.BackColor = System.Drawing.Color.Transparent
        Me.pnl3DMain.Controls.Add(Me.txt3DSurfaceElevationAmp)
        Me.pnl3DMain.Controls.Add(Me.lbl3DSurfaceElevationAmp)
        Me.pnl3DMain.Name = "pnl3DMain"
        '
        'txt3DSurfaceElevationAmp
        '
        Me.txt3DSurfaceElevationAmp.DecimalPlaces = 1
        resources.ApplyResources(Me.txt3DSurfaceElevationAmp, "txt3DSurfaceElevationAmp")
        Me.txt3DSurfaceElevationAmp.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txt3DSurfaceElevationAmp.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txt3DSurfaceElevationAmp.Name = "txt3DSurfaceElevationAmp"
        Me.txt3DSurfaceElevationAmp.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lbl3DSurfaceElevationAmp
        '
        resources.ApplyResources(Me.lbl3DSurfaceElevationAmp, "lbl3DSurfaceElevationAmp")
        Me.lbl3DSurfaceElevationAmp.Name = "lbl3DSurfaceElevationAmp"
        '
        'pnl3DPlotContainer
        '
        resources.ApplyResources(Me.pnl3DPlotContainer, "pnl3DPlotContainer")
        Me.pnl3DPlotContainer.Controls.Add(Me.chk3DPlotShowModel)
        Me.pnl3DPlotContainer.Controls.Add(Me.chk3DPlot)
        Me.pnl3DPlotContainer.Controls.Add(Me.pnl3dPlotModel)
        Me.pnl3DPlotContainer.Controls.Add(Me.pnl3DPlot)
        Me.pnl3DPlotContainer.Name = "pnl3DPlotContainer"
        '
        'chk3DPlotShowModel
        '
        resources.ApplyResources(Me.chk3DPlotShowModel, "chk3DPlotShowModel")
        Me.chk3DPlotShowModel.Name = "chk3DPlotShowModel"
        Me.chk3DPlotShowModel.UseVisualStyleBackColor = True
        '
        'chk3DPlot
        '
        resources.ApplyResources(Me.chk3DPlot, "chk3DPlot")
        Me.chk3DPlot.Name = "chk3DPlot"
        Me.chk3DPlot.UseVisualStyleBackColor = True
        '
        'pnl3dPlotModel
        '
        resources.ApplyResources(Me.pnl3dPlotModel, "pnl3dPlotModel")
        Me.pnl3dPlotModel.Controls.Add(Me.chk3dPlotModelExtendedElevation)
        Me.pnl3dPlotModel.Controls.Add(Me.chk3dModelColorGray)
        Me.pnl3dPlotModel.Controls.Add(Me.lbl3dPlotModelMode)
        Me.pnl3dPlotModel.Controls.Add(Me.cbo3dPlotModelMode)
        Me.pnl3dPlotModel.Controls.Add(Me.cbo3dPlotModelColoringMode)
        Me.pnl3dPlotModel.Controls.Add(Me.lbl3dPlotModelColoringMode)
        Me.pnl3dPlotModel.Name = "pnl3dPlotModel"
        '
        'chk3dPlotModelExtendedElevation
        '
        resources.ApplyResources(Me.chk3dPlotModelExtendedElevation, "chk3dPlotModelExtendedElevation")
        Me.chk3dPlotModelExtendedElevation.Name = "chk3dPlotModelExtendedElevation"
        '
        'chk3dModelColorGray
        '
        resources.ApplyResources(Me.chk3dModelColorGray, "chk3dModelColorGray")
        Me.chk3dModelColorGray.Name = "chk3dModelColorGray"
        '
        'lbl3dPlotModelMode
        '
        resources.ApplyResources(Me.lbl3dPlotModelMode, "lbl3dPlotModelMode")
        Me.lbl3dPlotModelMode.Name = "lbl3dPlotModelMode"
        '
        'cbo3dPlotModelMode
        '
        Me.cbo3dPlotModelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3dPlotModelMode.DropDownWidth = 320
        resources.ApplyResources(Me.cbo3dPlotModelMode, "cbo3dPlotModelMode")
        Me.cbo3dPlotModelMode.Items.AddRange(New Object() {resources.GetString("cbo3dPlotModelMode.Items"), resources.GetString("cbo3dPlotModelMode.Items1"), resources.GetString("cbo3dPlotModelMode.Items2"), resources.GetString("cbo3dPlotModelMode.Items3")})
        Me.cbo3dPlotModelMode.Name = "cbo3dPlotModelMode"
        '
        'cbo3dPlotModelColoringMode
        '
        Me.cbo3dPlotModelColoringMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3dPlotModelColoringMode.DropDownWidth = 320
        resources.ApplyResources(Me.cbo3dPlotModelColoringMode, "cbo3dPlotModelColoringMode")
        Me.cbo3dPlotModelColoringMode.Items.AddRange(New Object() {resources.GetString("cbo3dPlotModelColoringMode.Items"), resources.GetString("cbo3dPlotModelColoringMode.Items1"), resources.GetString("cbo3dPlotModelColoringMode.Items2")})
        Me.cbo3dPlotModelColoringMode.Name = "cbo3dPlotModelColoringMode"
        '
        'lbl3dPlotModelColoringMode
        '
        resources.ApplyResources(Me.lbl3dPlotModelColoringMode, "lbl3dPlotModelColoringMode")
        Me.lbl3dPlotModelColoringMode.Name = "lbl3dPlotModelColoringMode"
        '
        'pnl3DPlot
        '
        resources.ApplyResources(Me.pnl3DPlot, "pnl3DPlot")
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotColorGray)
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotShowTrigpointText)
        Me.pnl3DPlot.Controls.Add(Me.cbo3dPlotColorMode)
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotShowTrigpoint)
        Me.pnl3DPlot.Controls.Add(Me.lbl3dPlotColorMode)
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotShowSplay)
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotShowSplayLabel)
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotShowSegment)
        Me.pnl3DPlot.Controls.Add(Me.cbo3DPlotSplayStyle)
        Me.pnl3DPlot.Controls.Add(Me.chk3DPlotShowLRUD)
        Me.pnl3DPlot.Controls.Add(Me.cbo3DPlotSegmentsPaintStyle)
        Me.pnl3DPlot.Name = "pnl3DPlot"
        '
        'chk3DPlotColorGray
        '
        resources.ApplyResources(Me.chk3DPlotColorGray, "chk3DPlotColorGray")
        Me.chk3DPlotColorGray.Name = "chk3DPlotColorGray"
        '
        'chk3DPlotShowTrigpointText
        '
        resources.ApplyResources(Me.chk3DPlotShowTrigpointText, "chk3DPlotShowTrigpointText")
        Me.chk3DPlotShowTrigpointText.Name = "chk3DPlotShowTrigpointText"
        Me.chk3DPlotShowTrigpointText.UseVisualStyleBackColor = True
        '
        'cbo3dPlotColorMode
        '
        Me.cbo3dPlotColorMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo3dPlotColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3dPlotColorMode.Items.AddRange(New Object() {resources.GetString("cbo3dPlotColorMode.Items"), resources.GetString("cbo3dPlotColorMode.Items1"), resources.GetString("cbo3dPlotColorMode.Items2")})
        resources.ApplyResources(Me.cbo3dPlotColorMode, "cbo3dPlotColorMode")
        Me.cbo3dPlotColorMode.Name = "cbo3dPlotColorMode"
        '
        'chk3DPlotShowTrigpoint
        '
        resources.ApplyResources(Me.chk3DPlotShowTrigpoint, "chk3DPlotShowTrigpoint")
        Me.chk3DPlotShowTrigpoint.Name = "chk3DPlotShowTrigpoint"
        Me.chk3DPlotShowTrigpoint.UseVisualStyleBackColor = True
        '
        'lbl3dPlotColorMode
        '
        resources.ApplyResources(Me.lbl3dPlotColorMode, "lbl3dPlotColorMode")
        Me.lbl3dPlotColorMode.Name = "lbl3dPlotColorMode"
        '
        'chk3DPlotShowSplay
        '
        resources.ApplyResources(Me.chk3DPlotShowSplay, "chk3DPlotShowSplay")
        Me.chk3DPlotShowSplay.Name = "chk3DPlotShowSplay"
        Me.chk3DPlotShowSplay.UseVisualStyleBackColor = True
        '
        'chk3DPlotShowSplayLabel
        '
        resources.ApplyResources(Me.chk3DPlotShowSplayLabel, "chk3DPlotShowSplayLabel")
        Me.chk3DPlotShowSplayLabel.Name = "chk3DPlotShowSplayLabel"
        Me.chk3DPlotShowSplayLabel.UseVisualStyleBackColor = True
        '
        'chk3DPlotShowSegment
        '
        resources.ApplyResources(Me.chk3DPlotShowSegment, "chk3DPlotShowSegment")
        Me.chk3DPlotShowSegment.Name = "chk3DPlotShowSegment"
        Me.chk3DPlotShowSegment.UseVisualStyleBackColor = True
        '
        'cbo3DPlotSplayStyle
        '
        Me.cbo3DPlotSplayStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3DPlotSplayStyle.DropDownWidth = 320
        resources.ApplyResources(Me.cbo3DPlotSplayStyle, "cbo3DPlotSplayStyle")
        Me.cbo3DPlotSplayStyle.Items.AddRange(New Object() {resources.GetString("cbo3DPlotSplayStyle.Items"), resources.GetString("cbo3DPlotSplayStyle.Items1"), resources.GetString("cbo3DPlotSplayStyle.Items2")})
        Me.cbo3DPlotSplayStyle.Name = "cbo3DPlotSplayStyle"
        '
        'chk3DPlotShowLRUD
        '
        resources.ApplyResources(Me.chk3DPlotShowLRUD, "chk3DPlotShowLRUD")
        Me.chk3DPlotShowLRUD.Name = "chk3DPlotShowLRUD"
        Me.chk3DPlotShowLRUD.UseVisualStyleBackColor = True
        '
        'cbo3DPlotSegmentsPaintStyle
        '
        Me.cbo3DPlotSegmentsPaintStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbo3DPlotSegmentsPaintStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo3DPlotSegmentsPaintStyle.DropDownWidth = 320
        resources.ApplyResources(Me.cbo3DPlotSegmentsPaintStyle, "cbo3DPlotSegmentsPaintStyle")
        Me.cbo3DPlotSegmentsPaintStyle.Items.AddRange(New Object() {resources.GetString("cbo3DPlotSegmentsPaintStyle.Items"), resources.GetString("cbo3DPlotSegmentsPaintStyle.Items1"), resources.GetString("cbo3DPlotSegmentsPaintStyle.Items2"), resources.GetString("cbo3DPlotSegmentsPaintStyle.Items3")})
        Me.cbo3DPlotSegmentsPaintStyle.Name = "cbo3DPlotSegmentsPaintStyle"
        '
        'pnl3DSurfaceContainer
        '
        resources.ApplyResources(Me.pnl3DSurfaceContainer, "pnl3DSurfaceContainer")
        Me.pnl3DSurfaceContainer.Controls.Add(Me.chk3DSurface)
        Me.pnl3DSurfaceContainer.Controls.Add(Me.cmd3dSurfaceEdit)
        Me.pnl3DSurfaceContainer.Controls.Add(Me.pnl3DSurface)
        Me.pnl3DSurfaceContainer.Name = "pnl3DSurfaceContainer"
        '
        'chk3DSurface
        '
        resources.ApplyResources(Me.chk3DSurface, "chk3DSurface")
        Me.chk3DSurface.Name = "chk3DSurface"
        Me.chk3DSurface.UseVisualStyleBackColor = True
        '
        'cmd3dSurfaceEdit
        '
        resources.ApplyResources(Me.cmd3dSurfaceEdit, "cmd3dSurfaceEdit")
        Me.cmd3dSurfaceEdit.Name = "cmd3dSurfaceEdit"
        Me.tipDefault.SetToolTip(Me.cmd3dSurfaceEdit, resources.GetString("cmd3dSurfaceEdit.ToolTip"))
        Me.cmd3dSurfaceEdit.UseVisualStyleBackColor = True
        '
        'pnl3DSurface
        '
        resources.ApplyResources(Me.pnl3DSurface, "pnl3DSurface")
        Me.pnl3DSurface.Controls.Add(Me.txt3DSurfaceTransparency)
        Me.pnl3DSurface.Controls.Add(Me.tv3DSurfaceLayers)
        Me.pnl3DSurface.Controls.Add(Me.lbl3dSurfaceTransparency)
        Me.pnl3DSurface.Controls.Add(Me.cmd3DSurfaceLayersEdit)
        Me.pnl3DSurface.Controls.Add(Me.cmd3DSurfaceLayersUp)
        Me.pnl3DSurface.Controls.Add(Me.tv3DSurfaceElevationsLayers)
        Me.pnl3DSurface.Controls.Add(Me.cmd3DSurfaceLayersDown)
        Me.pnl3DSurface.Name = "pnl3DSurface"
        '
        'txt3DSurfaceTransparency
        '
        resources.ApplyResources(Me.txt3DSurfaceTransparency, "txt3DSurfaceTransparency")
        Me.txt3DSurfaceTransparency.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.txt3DSurfaceTransparency.Name = "txt3DSurfaceTransparency"
        '
        'tv3DSurfaceLayers
        '
        resources.ApplyResources(Me.tv3DSurfaceLayers, "tv3DSurfaceLayers")
        Me.tv3DSurfaceLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tv3DSurfaceLayers.CheckBoxes = True
        Me.tv3DSurfaceLayers.FullRowSelect = True
        Me.tv3DSurfaceLayers.HideSelection = False
        Me.tv3DSurfaceLayers.ImageList = Me.iml
        Me.tv3DSurfaceLayers.Name = "tv3DSurfaceLayers"
        '
        'lbl3dSurfaceTransparency
        '
        resources.ApplyResources(Me.lbl3dSurfaceTransparency, "lbl3dSurfaceTransparency")
        Me.lbl3dSurfaceTransparency.Name = "lbl3dSurfaceTransparency"
        '
        'cmd3DSurfaceLayersEdit
        '
        resources.ApplyResources(Me.cmd3DSurfaceLayersEdit, "cmd3DSurfaceLayersEdit")
        Me.cmd3DSurfaceLayersEdit.Name = "cmd3DSurfaceLayersEdit"
        Me.tipDefault.SetToolTip(Me.cmd3DSurfaceLayersEdit, resources.GetString("cmd3DSurfaceLayersEdit.ToolTip"))
        Me.cmd3DSurfaceLayersEdit.UseVisualStyleBackColor = True
        '
        'cmd3DSurfaceLayersUp
        '
        resources.ApplyResources(Me.cmd3DSurfaceLayersUp, "cmd3DSurfaceLayersUp")
        Me.cmd3DSurfaceLayersUp.Name = "cmd3DSurfaceLayersUp"
        Me.tipDefault.SetToolTip(Me.cmd3DSurfaceLayersUp, resources.GetString("cmd3DSurfaceLayersUp.ToolTip"))
        Me.cmd3DSurfaceLayersUp.UseVisualStyleBackColor = True
        '
        'tv3DSurfaceElevationsLayers
        '
        resources.ApplyResources(Me.tv3DSurfaceElevationsLayers, "tv3DSurfaceElevationsLayers")
        Me.tv3DSurfaceElevationsLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tv3DSurfaceElevationsLayers.CheckBoxes = True
        Me.tv3DSurfaceElevationsLayers.FullRowSelect = True
        Me.tv3DSurfaceElevationsLayers.HideSelection = False
        Me.tv3DSurfaceElevationsLayers.ImageList = Me.iml
        Me.tv3DSurfaceElevationsLayers.Name = "tv3DSurfaceElevationsLayers"
        '
        'cmd3DSurfaceLayersDown
        '
        resources.ApplyResources(Me.cmd3DSurfaceLayersDown, "cmd3DSurfaceLayersDown")
        Me.cmd3DSurfaceLayersDown.Name = "cmd3DSurfaceLayersDown"
        Me.tipDefault.SetToolTip(Me.cmd3DSurfaceLayersDown, resources.GetString("cmd3DSurfaceLayersDown.ToolTip"))
        Me.cmd3DSurfaceLayersDown.UseVisualStyleBackColor = True
        '
        'tbWorkspaces
        '
        resources.ApplyResources(Me.tbWorkspaces, "tbWorkspaces")
        Me.tbWorkspaces.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnWorkspaceData, Me.btnWorkspaceDesign, Me.btnWorkspaceAll})
        Me.tbWorkspaces.Name = "tbWorkspaces"
        '
        'btnWorkspaceData
        '
        Me.btnWorkspaceData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnWorkspaceData, "btnWorkspaceData")
        Me.btnWorkspaceData.Name = "btnWorkspaceData"
        '
        'btnWorkspaceDesign
        '
        Me.btnWorkspaceDesign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnWorkspaceDesign, "btnWorkspaceDesign")
        Me.btnWorkspaceDesign.Name = "btnWorkspaceDesign"
        '
        'btnWorkspaceAll
        '
        Me.btnWorkspaceAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnWorkspaceAll, "btnWorkspaceAll")
        Me.btnWorkspaceAll.Name = "btnWorkspaceAll"
        '
        'tbPens
        '
        resources.ApplyResources(Me.tbPens, "tbPens")
        Me.tbPens.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPensStyle, Me.ToolStripSeparator29, Me.btnPenSmooting, Me.cboPensSmooting, Me.ToolStripSeparator15, Me.btnPenLine, Me.btnPenSpline, Me.btnPenBezier})
        Me.tbPens.Name = "tbPens"
        '
        'lblPensStyle
        '
        Me.lblPensStyle.Name = "lblPensStyle"
        resources.ApplyResources(Me.lblPensStyle, "lblPensStyle")
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        resources.ApplyResources(Me.ToolStripSeparator29, "ToolStripSeparator29")
        '
        'btnPenSmooting
        '
        Me.btnPenSmooting.Checked = True
        Me.btnPenSmooting.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnPenSmooting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPenSmooting, "btnPenSmooting")
        Me.btnPenSmooting.Name = "btnPenSmooting"
        '
        'cboPensSmooting
        '
        resources.ApplyResources(Me.cboPensSmooting, "cboPensSmooting")
        Me.cboPensSmooting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPensSmooting.DropDownWidth = 60
        Me.cboPensSmooting.Items.AddRange(New Object() {resources.GetString("cboPensSmooting.Items"), resources.GetString("cboPensSmooting.Items1"), resources.GetString("cboPensSmooting.Items2"), resources.GetString("cboPensSmooting.Items3"), resources.GetString("cboPensSmooting.Items4"), resources.GetString("cboPensSmooting.Items5"), resources.GetString("cboPensSmooting.Items6"), resources.GetString("cboPensSmooting.Items7"), resources.GetString("cboPensSmooting.Items8"), resources.GetString("cboPensSmooting.Items9"), resources.GetString("cboPensSmooting.Items10"), resources.GetString("cboPensSmooting.Items11"), resources.GetString("cboPensSmooting.Items12"), resources.GetString("cboPensSmooting.Items13"), resources.GetString("cboPensSmooting.Items14"), resources.GetString("cboPensSmooting.Items15")})
        Me.cboPensSmooting.Name = "cboPensSmooting"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        resources.ApplyResources(Me.ToolStripSeparator15, "ToolStripSeparator15")
        '
        'btnPenLine
        '
        Me.btnPenLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPenLine, "btnPenLine")
        Me.btnPenLine.Name = "btnPenLine"
        '
        'btnPenSpline
        '
        Me.btnPenSpline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPenSpline, "btnPenSpline")
        Me.btnPenSpline.Name = "btnPenSpline"
        '
        'btnPenBezier
        '
        Me.btnPenBezier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPenBezier, "btnPenBezier")
        Me.btnPenBezier.Name = "btnPenBezier"
        '
        'tbLayers
        '
        resources.ApplyResources(Me.tbLayers, "tbLayers")
        Me.tbLayers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLayer_Base, Me.ToolStripSeparator10, Me.btnLayer_Soil, Me.ToolStripSeparator21, Me.btnLayer_Water, Me.ToolStripSeparator22, Me.btnLayer_Rocks, Me.ToolStripSeparator23, Me.btnLayer_TerrainLevel, Me.ToolStripSeparator24, Me.btnLayer_Borders, Me.ToolStripSeparator25, Me.btnLayer_Signs, Me.ToolStripSeparator20, Me.btnLayerManageLevels})
        Me.tbLayers.Name = "tbLayers"
        '
        'btnLayer_Base
        '
        resources.ApplyResources(Me.btnLayer_Base, "btnLayer_Base")
        Me.btnLayer_Base.Name = "btnLayer_Base"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        resources.ApplyResources(Me.ToolStripSeparator10, "ToolStripSeparator10")
        '
        'btnLayer_Soil
        '
        resources.ApplyResources(Me.btnLayer_Soil, "btnLayer_Soil")
        Me.btnLayer_Soil.Name = "btnLayer_Soil"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        resources.ApplyResources(Me.ToolStripSeparator21, "ToolStripSeparator21")
        '
        'btnLayer_Water
        '
        resources.ApplyResources(Me.btnLayer_Water, "btnLayer_Water")
        Me.btnLayer_Water.Name = "btnLayer_Water"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        resources.ApplyResources(Me.ToolStripSeparator22, "ToolStripSeparator22")
        '
        'btnLayer_Rocks
        '
        resources.ApplyResources(Me.btnLayer_Rocks, "btnLayer_Rocks")
        Me.btnLayer_Rocks.Name = "btnLayer_Rocks"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        resources.ApplyResources(Me.ToolStripSeparator23, "ToolStripSeparator23")
        '
        'btnLayer_TerrainLevel
        '
        resources.ApplyResources(Me.btnLayer_TerrainLevel, "btnLayer_TerrainLevel")
        Me.btnLayer_TerrainLevel.Name = "btnLayer_TerrainLevel"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        resources.ApplyResources(Me.ToolStripSeparator24, "ToolStripSeparator24")
        '
        'btnLayer_Borders
        '
        resources.ApplyResources(Me.btnLayer_Borders, "btnLayer_Borders")
        Me.btnLayer_Borders.Name = "btnLayer_Borders"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        resources.ApplyResources(Me.ToolStripSeparator25, "ToolStripSeparator25")
        '
        'btnLayer_Signs
        '
        resources.ApplyResources(Me.btnLayer_Signs, "btnLayer_Signs")
        Me.btnLayer_Signs.Name = "btnLayer_Signs"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        resources.ApplyResources(Me.ToolStripSeparator20, "ToolStripSeparator20")
        '
        'btnLayerManageLevels
        '
        Me.btnLayerManageLevels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnLayerManageLevels, "btnLayerManageLevels")
        Me.btnLayerManageLevels.Name = "btnLayerManageLevels"
        '
        'tbDesign
        '
        resources.ApplyResources(Me.tbDesign, "tbDesign")
        Me.tbDesign.Name = "tbDesign"
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSurveyNew, Me.btnSurveyOpen, Me.btnSurveySave, Me.ToolStripSeparator1, Me.btnExport, Me.ToolStripSeparator19, Me.btnSurface, Me.ToolStripSeparator4, Me.btnPrint, Me.ToolStripSeparator13, Me.btnViewer, Me.ToolStripSeparator30, Me.btnUndo, Me.ToolStripSeparator12, Me.btnCut, Me.btnCopy, Me.btnPaste, Me.ToolStripSeparator7, Me.btnDelete, Me.ToolStripSeparator8, Me.btnSegmentAdd, Me.btnSegmentDelete, Me.ToolStripSeparator2, Me.btnPlotCalculate, Me.btnPlotRebind, Me.btnPlotInfoCave, Me.ToolStripSeparator3, Me.btnZoomIn, Me.btnZoomOut, Me.btnZooms, Me.btnZoomToFit, Me.ToolStripSeparator9, Me.btnProperty})
        Me.tbMain.Name = "tbMain"
        '
        'btnSurveyNew
        '
        Me.btnSurveyNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSurveyNew, "btnSurveyNew")
        Me.btnSurveyNew.Name = "btnSurveyNew"
        '
        'btnSurveyOpen
        '
        Me.btnSurveyOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSurveyOpen, "btnSurveyOpen")
        Me.btnSurveyOpen.Name = "btnSurveyOpen"
        '
        'btnSurveySave
        '
        Me.btnSurveySave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSurveySave, "btnSurveySave")
        Me.btnSurveySave.Name = "btnSurveySave"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnExport
        '
        Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnExportData, Me.ToolStripMenuItem49, Me.btnExportTrack, Me.ToolStripMenuItem50, Me.btnExportImage, Me.ToolStripMenuItem101, Me.btnExport3D})
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        '
        'btnExportData
        '
        Me.btnExportData.Name = "btnExportData"
        resources.ApplyResources(Me.btnExportData, "btnExportData")
        '
        'ToolStripMenuItem49
        '
        Me.ToolStripMenuItem49.Name = "ToolStripMenuItem49"
        resources.ApplyResources(Me.ToolStripMenuItem49, "ToolStripMenuItem49")
        '
        'btnExportTrack
        '
        Me.btnExportTrack.Name = "btnExportTrack"
        resources.ApplyResources(Me.btnExportTrack, "btnExportTrack")
        '
        'ToolStripMenuItem50
        '
        Me.ToolStripMenuItem50.Name = "ToolStripMenuItem50"
        resources.ApplyResources(Me.ToolStripMenuItem50, "ToolStripMenuItem50")
        '
        'btnExportImage
        '
        Me.btnExportImage.Name = "btnExportImage"
        resources.ApplyResources(Me.btnExportImage, "btnExportImage")
        '
        'ToolStripMenuItem101
        '
        Me.ToolStripMenuItem101.Name = "ToolStripMenuItem101"
        resources.ApplyResources(Me.ToolStripMenuItem101, "ToolStripMenuItem101")
        '
        'btnExport3D
        '
        Me.btnExport3D.Name = "btnExport3D"
        resources.ApplyResources(Me.btnExport3D, "btnExport3D")
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        resources.ApplyResources(Me.ToolStripSeparator19, "ToolStripSeparator19")
        '
        'btnSurface
        '
        Me.btnSurface.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSurface, "btnSurface")
        Me.btnSurface.Name = "btnSurface"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnPrint
        '
        Me.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPrint, "btnPrint")
        Me.btnPrint.Name = "btnPrint"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        resources.ApplyResources(Me.ToolStripSeparator13, "ToolStripSeparator13")
        '
        'btnViewer
        '
        Me.btnViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnViewer, "btnViewer")
        Me.btnViewer.Name = "btnViewer"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        resources.ApplyResources(Me.ToolStripSeparator30, "ToolStripSeparator30")
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnUndo, "btnUndo")
        Me.btnUndo.Name = "btnUndo"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        resources.ApplyResources(Me.ToolStripSeparator12, "ToolStripSeparator12")
        '
        'btnCut
        '
        Me.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnCut, "btnCut")
        Me.btnCut.Name = "btnCut"
        '
        'btnCopy
        '
        Me.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnCopy, "btnCopy")
        Me.btnCopy.Name = "btnCopy"
        '
        'btnPaste
        '
        Me.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPaste, "btnPaste")
        Me.btnPaste.Name = "btnPaste"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'btnDelete
        '
        Me.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        resources.ApplyResources(Me.ToolStripSeparator8, "ToolStripSeparator8")
        '
        'btnSegmentAdd
        '
        Me.btnSegmentAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSegmentAdd, "btnSegmentAdd")
        Me.btnSegmentAdd.Name = "btnSegmentAdd"
        '
        'btnSegmentDelete
        '
        Me.btnSegmentDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnSegmentDelete, "btnSegmentDelete")
        Me.btnSegmentDelete.Name = "btnSegmentDelete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnPlotCalculate
        '
        Me.btnPlotCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPlotCalculate, "btnPlotCalculate")
        Me.btnPlotCalculate.Name = "btnPlotCalculate"
        '
        'btnPlotRebind
        '
        Me.btnPlotRebind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPlotRebind.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPlotRebindRebind, Me.btnPlotRebindRemoveOrphans})
        resources.ApplyResources(Me.btnPlotRebind, "btnPlotRebind")
        Me.btnPlotRebind.Name = "btnPlotRebind"
        '
        'btnPlotRebindRebind
        '
        resources.ApplyResources(Me.btnPlotRebindRebind, "btnPlotRebindRebind")
        Me.btnPlotRebindRebind.Name = "btnPlotRebindRebind"
        '
        'btnPlotRebindRemoveOrphans
        '
        Me.btnPlotRebindRemoveOrphans.Name = "btnPlotRebindRemoveOrphans"
        resources.ApplyResources(Me.btnPlotRebindRemoveOrphans, "btnPlotRebindRemoveOrphans")
        '
        'btnPlotInfoCave
        '
        Me.btnPlotInfoCave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPlotInfoCave, "btnPlotInfoCave")
        Me.btnPlotInfoCave.Name = "btnPlotInfoCave"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnZoomIn, "btnZoomIn")
        Me.btnZoomIn.Name = "btnZoomIn"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnZoomOut, "btnZoomOut")
        Me.btnZoomOut.Name = "btnZoomOut"
        '
        'btnZooms
        '
        Me.btnZooms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZooms.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnZoomsCenter, Me.ToolStripMenuItem4, Me.btnZooms10m, Me.btnZooms50m, Me.btnZooms100m, Me.MetriToolStripMenuItem, Me.ToolStripMenuItem27, Me.btnZoomsToFit})
        resources.ApplyResources(Me.btnZooms, "btnZooms")
        Me.btnZooms.Name = "btnZooms"
        '
        'btnZoomsCenter
        '
        Me.btnZoomsCenter.Name = "btnZoomsCenter"
        resources.ApplyResources(Me.btnZoomsCenter, "btnZoomsCenter")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'btnZooms10m
        '
        resources.ApplyResources(Me.btnZooms10m, "btnZooms10m")
        Me.btnZooms10m.Name = "btnZooms10m"
        '
        'btnZooms50m
        '
        resources.ApplyResources(Me.btnZooms50m, "btnZooms50m")
        Me.btnZooms50m.Name = "btnZooms50m"
        '
        'btnZooms100m
        '
        resources.ApplyResources(Me.btnZooms100m, "btnZooms100m")
        Me.btnZooms100m.Name = "btnZooms100m"
        '
        'MetriToolStripMenuItem
        '
        resources.ApplyResources(Me.MetriToolStripMenuItem, "MetriToolStripMenuItem")
        Me.MetriToolStripMenuItem.Name = "MetriToolStripMenuItem"
        '
        'ToolStripMenuItem27
        '
        Me.ToolStripMenuItem27.Name = "ToolStripMenuItem27"
        resources.ApplyResources(Me.ToolStripMenuItem27, "ToolStripMenuItem27")
        '
        'btnZoomsToFit
        '
        resources.ApplyResources(Me.btnZoomsToFit, "btnZoomsToFit")
        Me.btnZoomsToFit.Name = "btnZoomsToFit"
        '
        'btnZoomToFit
        '
        Me.btnZoomToFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnZoomToFit, "btnZoomToFit")
        Me.btnZoomToFit.Name = "btnZoomToFit"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        resources.ApplyResources(Me.ToolStripSeparator9, "ToolStripSeparator9")
        '
        'btnProperty
        '
        Me.btnProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnProperty, "btnProperty")
        Me.btnProperty.Name = "btnProperty"
        '
        'tbView
        '
        resources.ApplyResources(Me.tbView, "tbView")
        Me.tbView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShowFieldData, Me.btnShowObjectProp, Me.ToolStripSeparator11, Me.cboMainSessionList, Me.ToolStripSeparator18, Me.cboMainCaveList, Me.cboMainCaveBranchList, Me.btnDesignHighlight, Me.cboMainBindDesignType, Me.cboMainBindCrossSections, Me.btnObjectSetCaveBranch, Me.ToolStripSeparator28, Me.btnViewSplayShowMode, Me.ToolStripSeparator33, Me.btnObjectShowBindings, Me.ToolStripSeparator31, Me.btnObjectProp})
        Me.tbView.Name = "tbView"
        '
        'btnShowFieldData
        '
        Me.btnShowFieldData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnShowFieldData, "btnShowFieldData")
        Me.btnShowFieldData.Name = "btnShowFieldData"
        '
        'btnShowObjectProp
        '
        Me.btnShowObjectProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnShowObjectProp, "btnShowObjectProp")
        Me.btnShowObjectProp.Name = "btnShowObjectProp"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        resources.ApplyResources(Me.ToolStripSeparator11, "ToolStripSeparator11")
        '
        'cboMainSessionList
        '
        Me.cboMainSessionList.DropDownWidth = 420
        resources.ApplyResources(Me.cboMainSessionList, "cboMainSessionList")
        Me.cboMainSessionList.Name = "cboMainSessionList"
        '
        'ToolStripSeparator18
        '
        Me.ToolStripSeparator18.Name = "ToolStripSeparator18"
        resources.ApplyResources(Me.ToolStripSeparator18, "ToolStripSeparator18")
        '
        'cboMainCaveList
        '
        Me.cboMainCaveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMainCaveList.DropDownWidth = 420
        resources.ApplyResources(Me.cboMainCaveList, "cboMainCaveList")
        Me.cboMainCaveList.Name = "cboMainCaveList"
        '
        'cboMainCaveBranchList
        '
        Me.cboMainCaveBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMainCaveBranchList.DropDownWidth = 420
        resources.ApplyResources(Me.cboMainCaveBranchList, "cboMainCaveBranchList")
        Me.cboMainCaveBranchList.Name = "cboMainCaveBranchList"
        Me.cboMainCaveBranchList.Sorted = True
        '
        'btnDesignHighlight
        '
        Me.btnDesignHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDesignHighlight.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDesignHighlight0, Me.btnDesignHighlight1, Me.ToolStripMenuItem70, Me.btnDesignHighlightMode, Me.ToolStripMenuItem19, Me.btnDesignHighlightSegmentsAndTrigpoints})
        resources.ApplyResources(Me.btnDesignHighlight, "btnDesignHighlight")
        Me.btnDesignHighlight.Name = "btnDesignHighlight"
        '
        'btnDesignHighlight0
        '
        Me.btnDesignHighlight0.Name = "btnDesignHighlight0"
        resources.ApplyResources(Me.btnDesignHighlight0, "btnDesignHighlight0")
        '
        'btnDesignHighlight1
        '
        Me.btnDesignHighlight1.Name = "btnDesignHighlight1"
        resources.ApplyResources(Me.btnDesignHighlight1, "btnDesignHighlight1")
        '
        'ToolStripMenuItem70
        '
        Me.ToolStripMenuItem70.Name = "ToolStripMenuItem70"
        resources.ApplyResources(Me.ToolStripMenuItem70, "ToolStripMenuItem70")
        '
        'btnDesignHighlightMode
        '
        Me.btnDesignHighlightMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDesignHighlightMode0, Me.btnDesignHighlightMode1, Me.btnDesignHighlightMode2})
        Me.btnDesignHighlightMode.Name = "btnDesignHighlightMode"
        resources.ApplyResources(Me.btnDesignHighlightMode, "btnDesignHighlightMode")
        '
        'btnDesignHighlightMode0
        '
        Me.btnDesignHighlightMode0.Name = "btnDesignHighlightMode0"
        resources.ApplyResources(Me.btnDesignHighlightMode0, "btnDesignHighlightMode0")
        '
        'btnDesignHighlightMode1
        '
        Me.btnDesignHighlightMode1.Name = "btnDesignHighlightMode1"
        resources.ApplyResources(Me.btnDesignHighlightMode1, "btnDesignHighlightMode1")
        '
        'btnDesignHighlightMode2
        '
        Me.btnDesignHighlightMode2.Name = "btnDesignHighlightMode2"
        resources.ApplyResources(Me.btnDesignHighlightMode2, "btnDesignHighlightMode2")
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        resources.ApplyResources(Me.ToolStripMenuItem19, "ToolStripMenuItem19")
        '
        'btnDesignHighlightSegmentsAndTrigpoints
        '
        Me.btnDesignHighlightSegmentsAndTrigpoints.Name = "btnDesignHighlightSegmentsAndTrigpoints"
        resources.ApplyResources(Me.btnDesignHighlightSegmentsAndTrigpoints, "btnDesignHighlightSegmentsAndTrigpoints")
        '
        'cboMainBindDesignType
        '
        Me.cboMainBindDesignType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMainBindDesignType.DropDownWidth = 240
        resources.ApplyResources(Me.cboMainBindDesignType, "cboMainBindDesignType")
        Me.cboMainBindDesignType.Items.AddRange(New Object() {resources.GetString("cboMainBindDesignType.Items"), resources.GetString("cboMainBindDesignType.Items1")})
        Me.cboMainBindDesignType.Name = "cboMainBindDesignType"
        '
        'cboMainBindCrossSections
        '
        Me.cboMainBindCrossSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMainBindCrossSections.DropDownWidth = 420
        resources.ApplyResources(Me.cboMainBindCrossSections, "cboMainBindCrossSections")
        Me.cboMainBindCrossSections.Name = "cboMainBindCrossSections"
        '
        'btnObjectSetCaveBranch
        '
        Me.btnObjectSetCaveBranch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnObjectSetCaveBranch, "btnObjectSetCaveBranch")
        Me.btnObjectSetCaveBranch.Name = "btnObjectSetCaveBranch"
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        resources.ApplyResources(Me.ToolStripSeparator28, "ToolStripSeparator28")
        '
        'btnViewSplayShowMode
        '
        Me.btnViewSplayShowMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewSplayShowMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnViewSplayShowMode1, Me.btnViewSplayShowMode0})
        resources.ApplyResources(Me.btnViewSplayShowMode, "btnViewSplayShowMode")
        Me.btnViewSplayShowMode.Name = "btnViewSplayShowMode"
        '
        'btnViewSplayShowMode1
        '
        Me.btnViewSplayShowMode1.Name = "btnViewSplayShowMode1"
        resources.ApplyResources(Me.btnViewSplayShowMode1, "btnViewSplayShowMode1")
        '
        'btnViewSplayShowMode0
        '
        Me.btnViewSplayShowMode0.Name = "btnViewSplayShowMode0"
        resources.ApplyResources(Me.btnViewSplayShowMode0, "btnViewSplayShowMode0")
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        resources.ApplyResources(Me.ToolStripSeparator33, "ToolStripSeparator33")
        '
        'btnObjectShowBindings
        '
        Me.btnObjectShowBindings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnObjectShowBindings, "btnObjectShowBindings")
        Me.btnObjectShowBindings.Name = "btnObjectShowBindings"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        resources.ApplyResources(Me.ToolStripSeparator31, "ToolStripSeparator31")
        '
        'btnObjectProp
        '
        Me.btnObjectProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnObjectProp, "btnObjectProp")
        Me.btnObjectProp.Name = "btnObjectProp"
        '
        'sbMain
        '
        resources.ApplyResources(Me.sbMain, "sbMain")
        Me.sbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pnlStatusMasterSlave, Me.pnlStatusText, Me.pnlStatusProgress, Me.pnlStatusCurrentRule, Me.pnlStatusWMSOnLine, Me.pnlStatusHistoryEnabled, Me.pnlStatusDesignWarpingState, Me.pnlStatusDesignGeographicState, Me.pnlStatusDesignInfo, Me.pnlStatusDesignZoom, Me.pnlStatusDesignSnapToGrid, Me.ToolStripStatusLabel2})
        Me.sbMain.Name = "sbMain"
        Me.sbMain.ShowItemToolTips = True
        '
        'pnlStatusMasterSlave
        '
        Me.pnlStatusMasterSlave.Name = "pnlStatusMasterSlave"
        resources.ApplyResources(Me.pnlStatusMasterSlave, "pnlStatusMasterSlave")
        '
        'pnlStatusText
        '
        resources.ApplyResources(Me.pnlStatusText, "pnlStatusText")
        Me.pnlStatusText.Name = "pnlStatusText"
        Me.pnlStatusText.Spring = True
        '
        'pnlStatusProgress
        '
        Me.pnlStatusProgress.Name = "pnlStatusProgress"
        resources.ApplyResources(Me.pnlStatusProgress, "pnlStatusProgress")
        '
        'pnlStatusCurrentRule
        '
        resources.ApplyResources(Me.pnlStatusCurrentRule, "pnlStatusCurrentRule")
        Me.pnlStatusCurrentRule.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.pnlStatusCurrentRule.DoubleClickEnabled = True
        Me.pnlStatusCurrentRule.Name = "pnlStatusCurrentRule"
        '
        'pnlStatusWMSOnLine
        '
        resources.ApplyResources(Me.pnlStatusWMSOnLine, "pnlStatusWMSOnLine")
        Me.pnlStatusWMSOnLine.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusWMSOnLine.DoubleClickEnabled = True
        Me.pnlStatusWMSOnLine.Name = "pnlStatusWMSOnLine"
        '
        'pnlStatusHistoryEnabled
        '
        resources.ApplyResources(Me.pnlStatusHistoryEnabled, "pnlStatusHistoryEnabled")
        Me.pnlStatusHistoryEnabled.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusHistoryEnabled.DoubleClickEnabled = True
        Me.pnlStatusHistoryEnabled.Name = "pnlStatusHistoryEnabled"
        '
        'pnlStatusDesignWarpingState
        '
        resources.ApplyResources(Me.pnlStatusDesignWarpingState, "pnlStatusDesignWarpingState")
        Me.pnlStatusDesignWarpingState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusDesignWarpingState.DoubleClickEnabled = True
        Me.pnlStatusDesignWarpingState.Name = "pnlStatusDesignWarpingState"
        '
        'pnlStatusDesignGeographicState
        '
        resources.ApplyResources(Me.pnlStatusDesignGeographicState, "pnlStatusDesignGeographicState")
        Me.pnlStatusDesignGeographicState.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusDesignGeographicState.DoubleClickEnabled = True
        Me.pnlStatusDesignGeographicState.Name = "pnlStatusDesignGeographicState"
        '
        'pnlStatusDesignInfo
        '
        resources.ApplyResources(Me.pnlStatusDesignInfo, "pnlStatusDesignInfo")
        Me.pnlStatusDesignInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusDesignInfo.Name = "pnlStatusDesignInfo"
        '
        'pnlStatusDesignZoom
        '
        resources.ApplyResources(Me.pnlStatusDesignZoom, "pnlStatusDesignZoom")
        Me.pnlStatusDesignZoom.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusDesignZoom.Name = "pnlStatusDesignZoom"
        '
        'pnlStatusDesignSnapToGrid
        '
        resources.ApplyResources(Me.pnlStatusDesignSnapToGrid, "pnlStatusDesignSnapToGrid")
        Me.pnlStatusDesignSnapToGrid.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.pnlStatusDesignSnapToGrid.Name = "pnlStatusDesignSnapToGrid"
        '
        'ToolStripStatusLabel2
        '
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cmdCoordinateGetFromGPS
        '
        resources.ApplyResources(Me.cmdCoordinateGetFromGPS, "cmdCoordinateGetFromGPS")
        Me.cmdCoordinateGetFromGPS.Name = "cmdCoordinateGetFromGPS"
        '
        'lblCoordinateGeo
        '
        resources.ApplyResources(Me.lblCoordinateGeo, "lblCoordinateGeo")
        Me.lblCoordinateGeo.Name = "lblCoordinateGeo"
        '
        'lblCoordinateFormat
        '
        resources.ApplyResources(Me.lblCoordinateFormat, "lblCoordinateFormat")
        Me.lblCoordinateFormat.Name = "lblCoordinateFormat"
        '
        'lblCoordinateLong
        '
        resources.ApplyResources(Me.lblCoordinateLong, "lblCoordinateLong")
        Me.lblCoordinateLong.Name = "lblCoordinateLong"
        '
        'lblCoordinateLat
        '
        resources.ApplyResources(Me.lblCoordinateLat, "lblCoordinateLat")
        Me.lblCoordinateLat.Name = "lblCoordinateLat"
        '
        'mnuMain
        '
        resources.ApplyResources(Me.mnuMain, "mnuMain")
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.mnuView, Me.mnuPlot, Me.mnuDesign, Me.mnuLayers, Me.mnuZoom, Me.mnuHelp})
        Me.mnuMain.Name = "mnuMain"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileNew, Me.mnuFileNewFromTemplate, Me.mnuFileOpen, Me.mnuFileRollback, Me.mnuFileSave, Me.mnuFileSaveAs, Me.ToolStripMenuItem97, Me.mnuFileHistory, Me.mnuFileCleanUp, Me.ToolStripMenuItem89, Me.mnuFileImport, Me.mnuFileExport, Me.ToolStripMenuItem87, Me.mnuFileResurvey, Me.ToolStripMenuItem1, Me.mnuFile3D, Me.mnuFileTherion, Me.ToolStripMenuItem2, Me.mnuFilePrint, Me.ToolStripMenuItem18, Me.mnuFileProp, Me.mnuFileSurface, Me.ToolStripMenuItem48, Me.mnuFileSettings, Me.mnuFileAutoSettings, Me.ToolStripMenuItem5, Me.mnuFileRecent, Me.ToolStripMenuItem74, Me.mnuFileHideInTray, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        '
        'mnuFileNew
        '
        resources.ApplyResources(Me.mnuFileNew, "mnuFileNew")
        Me.mnuFileNew.Name = "mnuFileNew"
        '
        'mnuFileNewFromTemplate
        '
        Me.mnuFileNewFromTemplate.Name = "mnuFileNewFromTemplate"
        resources.ApplyResources(Me.mnuFileNewFromTemplate, "mnuFileNewFromTemplate")
        '
        'mnuFileOpen
        '
        resources.ApplyResources(Me.mnuFileOpen, "mnuFileOpen")
        Me.mnuFileOpen.Name = "mnuFileOpen"
        '
        'mnuFileRollback
        '
        Me.mnuFileRollback.Name = "mnuFileRollback"
        resources.ApplyResources(Me.mnuFileRollback, "mnuFileRollback")
        '
        'mnuFileSave
        '
        resources.ApplyResources(Me.mnuFileSave, "mnuFileSave")
        Me.mnuFileSave.Name = "mnuFileSave"
        '
        'mnuFileSaveAs
        '
        Me.mnuFileSaveAs.Name = "mnuFileSaveAs"
        resources.ApplyResources(Me.mnuFileSaveAs, "mnuFileSaveAs")
        '
        'ToolStripMenuItem97
        '
        Me.ToolStripMenuItem97.Name = "ToolStripMenuItem97"
        resources.ApplyResources(Me.ToolStripMenuItem97, "ToolStripMenuItem97")
        '
        'mnuFileHistory
        '
        resources.ApplyResources(Me.mnuFileHistory, "mnuFileHistory")
        Me.mnuFileHistory.Name = "mnuFileHistory"
        '
        'mnuFileCleanUp
        '
        resources.ApplyResources(Me.mnuFileCleanUp, "mnuFileCleanUp")
        Me.mnuFileCleanUp.Name = "mnuFileCleanUp"
        '
        'ToolStripMenuItem89
        '
        Me.ToolStripMenuItem89.Name = "ToolStripMenuItem89"
        resources.ApplyResources(Me.ToolStripMenuItem89, "ToolStripMenuItem89")
        '
        'mnuFileImport
        '
        Me.mnuFileImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileImportSurvey, Me.ToolStripMenuItem58, Me.mnuFileImportTracks, Me.ToolStripMenuItem94, Me.mnuFileImportDesign})
        resources.ApplyResources(Me.mnuFileImport, "mnuFileImport")
        Me.mnuFileImport.Name = "mnuFileImport"
        '
        'mnuFileImportSurvey
        '
        Me.mnuFileImportSurvey.Name = "mnuFileImportSurvey"
        resources.ApplyResources(Me.mnuFileImportSurvey, "mnuFileImportSurvey")
        '
        'ToolStripMenuItem58
        '
        Me.ToolStripMenuItem58.Name = "ToolStripMenuItem58"
        resources.ApplyResources(Me.ToolStripMenuItem58, "ToolStripMenuItem58")
        '
        'mnuFileImportTracks
        '
        Me.mnuFileImportTracks.Name = "mnuFileImportTracks"
        resources.ApplyResources(Me.mnuFileImportTracks, "mnuFileImportTracks")
        '
        'ToolStripMenuItem94
        '
        Me.ToolStripMenuItem94.Name = "ToolStripMenuItem94"
        resources.ApplyResources(Me.ToolStripMenuItem94, "ToolStripMenuItem94")
        '
        'mnuFileImportDesign
        '
        Me.mnuFileImportDesign.Name = "mnuFileImportDesign"
        resources.ApplyResources(Me.mnuFileImportDesign, "mnuFileImportDesign")
        '
        'mnuFileExport
        '
        Me.mnuFileExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileExportSurvey, Me.ToolStripMenuItem16, Me.mnuFileExportTrack, Me.ToolStripMenuItem10, Me.mnuFileExportImage, Me.ToolStripMenuItem100, Me.mnuFileExport3D})
        resources.ApplyResources(Me.mnuFileExport, "mnuFileExport")
        Me.mnuFileExport.Name = "mnuFileExport"
        '
        'mnuFileExportSurvey
        '
        Me.mnuFileExportSurvey.Name = "mnuFileExportSurvey"
        resources.ApplyResources(Me.mnuFileExportSurvey, "mnuFileExportSurvey")
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        resources.ApplyResources(Me.ToolStripMenuItem16, "ToolStripMenuItem16")
        '
        'mnuFileExportTrack
        '
        Me.mnuFileExportTrack.Name = "mnuFileExportTrack"
        resources.ApplyResources(Me.mnuFileExportTrack, "mnuFileExportTrack")
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        resources.ApplyResources(Me.ToolStripMenuItem10, "ToolStripMenuItem10")
        '
        'mnuFileExportImage
        '
        Me.mnuFileExportImage.Name = "mnuFileExportImage"
        resources.ApplyResources(Me.mnuFileExportImage, "mnuFileExportImage")
        '
        'ToolStripMenuItem100
        '
        Me.ToolStripMenuItem100.Name = "ToolStripMenuItem100"
        resources.ApplyResources(Me.ToolStripMenuItem100, "ToolStripMenuItem100")
        '
        'mnuFileExport3D
        '
        Me.mnuFileExport3D.Name = "mnuFileExport3D"
        resources.ApplyResources(Me.mnuFileExport3D, "mnuFileExport3D")
        '
        'ToolStripMenuItem87
        '
        Me.ToolStripMenuItem87.Name = "ToolStripMenuItem87"
        resources.ApplyResources(Me.ToolStripMenuItem87, "ToolStripMenuItem87")
        '
        'mnuFileResurvey
        '
        Me.mnuFileResurvey.Name = "mnuFileResurvey"
        resources.ApplyResources(Me.mnuFileResurvey, "mnuFileResurvey")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuFile3D
        '
        resources.ApplyResources(Me.mnuFile3D, "mnuFile3D")
        Me.mnuFile3D.Name = "mnuFile3D"
        '
        'mnuFileTherion
        '
        Me.mnuFileTherion.Name = "mnuFileTherion"
        resources.ApplyResources(Me.mnuFileTherion, "mnuFileTherion")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuFilePrint
        '
        resources.ApplyResources(Me.mnuFilePrint, "mnuFilePrint")
        Me.mnuFilePrint.Name = "mnuFilePrint"
        '
        'ToolStripMenuItem18
        '
        Me.ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        resources.ApplyResources(Me.ToolStripMenuItem18, "ToolStripMenuItem18")
        '
        'mnuFileProp
        '
        resources.ApplyResources(Me.mnuFileProp, "mnuFileProp")
        Me.mnuFileProp.Name = "mnuFileProp"
        '
        'mnuFileSurface
        '
        resources.ApplyResources(Me.mnuFileSurface, "mnuFileSurface")
        Me.mnuFileSurface.Name = "mnuFileSurface"
        '
        'ToolStripMenuItem48
        '
        Me.ToolStripMenuItem48.Name = "ToolStripMenuItem48"
        resources.ApplyResources(Me.ToolStripMenuItem48, "ToolStripMenuItem48")
        '
        'mnuFileSettings
        '
        resources.ApplyResources(Me.mnuFileSettings, "mnuFileSettings")
        Me.mnuFileSettings.Name = "mnuFileSettings"
        '
        'mnuFileAutoSettings
        '
        Me.mnuFileAutoSettings.Name = "mnuFileAutoSettings"
        resources.ApplyResources(Me.mnuFileAutoSettings, "mnuFileAutoSettings")
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        resources.ApplyResources(Me.ToolStripMenuItem5, "ToolStripMenuItem5")
        '
        'mnuFileRecent
        '
        Me.mnuFileRecent.Name = "mnuFileRecent"
        resources.ApplyResources(Me.mnuFileRecent, "mnuFileRecent")
        '
        'ToolStripMenuItem74
        '
        Me.ToolStripMenuItem74.Name = "ToolStripMenuItem74"
        resources.ApplyResources(Me.ToolStripMenuItem74, "ToolStripMenuItem74")
        '
        'mnuFileHideInTray
        '
        Me.mnuFileHideInTray.Name = "mnuFileHideInTray"
        resources.ApplyResources(Me.mnuFileHideInTray, "mnuFileHideInTray")
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        resources.ApplyResources(Me.mnuFileExit, "mnuFileExit")
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEditUndo, Me.ToolStripMenuItem29, Me.mnuEditCut, Me.mnuEditCopy, Me.mnuEditPaste, Me.mnuEditDelete, Me.mnuEditSelectAllSep, Me.mnuEditSelectAllInCurrentLevelInDesign, Me.mnuEditSelectAllInDesign, Me.mnuEditSelectAll, Me.mnuEditFindSep, Me.mnuEditFind})
        Me.mnuEdit.Name = "mnuEdit"
        resources.ApplyResources(Me.mnuEdit, "mnuEdit")
        '
        'mnuEditUndo
        '
        resources.ApplyResources(Me.mnuEditUndo, "mnuEditUndo")
        Me.mnuEditUndo.Name = "mnuEditUndo"
        '
        'ToolStripMenuItem29
        '
        Me.ToolStripMenuItem29.Name = "ToolStripMenuItem29"
        resources.ApplyResources(Me.ToolStripMenuItem29, "ToolStripMenuItem29")
        '
        'mnuEditCut
        '
        resources.ApplyResources(Me.mnuEditCut, "mnuEditCut")
        Me.mnuEditCut.Name = "mnuEditCut"
        '
        'mnuEditCopy
        '
        resources.ApplyResources(Me.mnuEditCopy, "mnuEditCopy")
        Me.mnuEditCopy.Name = "mnuEditCopy"
        '
        'mnuEditPaste
        '
        resources.ApplyResources(Me.mnuEditPaste, "mnuEditPaste")
        Me.mnuEditPaste.Name = "mnuEditPaste"
        '
        'mnuEditDelete
        '
        resources.ApplyResources(Me.mnuEditDelete, "mnuEditDelete")
        Me.mnuEditDelete.Name = "mnuEditDelete"
        '
        'mnuEditSelectAllSep
        '
        Me.mnuEditSelectAllSep.Name = "mnuEditSelectAllSep"
        resources.ApplyResources(Me.mnuEditSelectAllSep, "mnuEditSelectAllSep")
        '
        'mnuEditSelectAllInCurrentLevelInDesign
        '
        Me.mnuEditSelectAllInCurrentLevelInDesign.Name = "mnuEditSelectAllInCurrentLevelInDesign"
        resources.ApplyResources(Me.mnuEditSelectAllInCurrentLevelInDesign, "mnuEditSelectAllInCurrentLevelInDesign")
        '
        'mnuEditSelectAllInDesign
        '
        Me.mnuEditSelectAllInDesign.Name = "mnuEditSelectAllInDesign"
        resources.ApplyResources(Me.mnuEditSelectAllInDesign, "mnuEditSelectAllInDesign")
        '
        'mnuEditSelectAll
        '
        Me.mnuEditSelectAll.Name = "mnuEditSelectAll"
        resources.ApplyResources(Me.mnuEditSelectAll, "mnuEditSelectAll")
        '
        'mnuEditFindSep
        '
        Me.mnuEditFindSep.Name = "mnuEditFindSep"
        resources.ApplyResources(Me.mnuEditFindSep, "mnuEditFindSep")
        '
        'mnuEditFind
        '
        Me.mnuEditFind.Name = "mnuEditFind"
        resources.ApplyResources(Me.mnuEditFind, "mnuEditFind")
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewBars, Me.ToolStripMenuItem34, Me.mnuViewWorkspaces, Me.mnuViewFieldData, Me.mnuViewDesignArea, Me.mnuViewObjectProp, Me.ToolStripMenuItem11, Me.mnuViewGraphics, Me.ToolStripMenuItem14, Me.mnuViewDesign, Me.mnuViewPlot, Me.ToolStripMenuItem7, Me.mnuViewPlan, Me.mnuViewProfile, Me.mnuView3D, Me.ToolStripMenuItem33, Me.mnuViewViewer, Me.ToolStripMenuItem103, Me.mnuViewScript, Me.ToolStripMenuItem114, Me.mnuViewLinkedSurveys, Me.ToolStripMenuItem6, Me.mnuViewConsole})
        Me.mnuView.Name = "mnuView"
        resources.ApplyResources(Me.mnuView, "mnuView")
        '
        'mnuViewBars
        '
        Me.mnuViewBars.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewBarsMain, Me.mnuViewBarsView, Me.mnuViewBarsWorkspaces, Me.mnuViewBarsLayer, Me.mnuViewBarsTools, Me.mnuViewBarsPens, Me.ToolStripMenuItem63, Me.mnuViewBarsPen})
        Me.mnuViewBars.Name = "mnuViewBars"
        resources.ApplyResources(Me.mnuViewBars, "mnuViewBars")
        '
        'mnuViewBarsMain
        '
        Me.mnuViewBarsMain.Name = "mnuViewBarsMain"
        resources.ApplyResources(Me.mnuViewBarsMain, "mnuViewBarsMain")
        '
        'mnuViewBarsView
        '
        Me.mnuViewBarsView.Name = "mnuViewBarsView"
        resources.ApplyResources(Me.mnuViewBarsView, "mnuViewBarsView")
        '
        'mnuViewBarsWorkspaces
        '
        Me.mnuViewBarsWorkspaces.Name = "mnuViewBarsWorkspaces"
        resources.ApplyResources(Me.mnuViewBarsWorkspaces, "mnuViewBarsWorkspaces")
        '
        'mnuViewBarsLayer
        '
        Me.mnuViewBarsLayer.Name = "mnuViewBarsLayer"
        resources.ApplyResources(Me.mnuViewBarsLayer, "mnuViewBarsLayer")
        '
        'mnuViewBarsTools
        '
        Me.mnuViewBarsTools.Name = "mnuViewBarsTools"
        resources.ApplyResources(Me.mnuViewBarsTools, "mnuViewBarsTools")
        '
        'mnuViewBarsPens
        '
        Me.mnuViewBarsPens.Name = "mnuViewBarsPens"
        resources.ApplyResources(Me.mnuViewBarsPens, "mnuViewBarsPens")
        '
        'ToolStripMenuItem63
        '
        Me.ToolStripMenuItem63.Name = "ToolStripMenuItem63"
        resources.ApplyResources(Me.ToolStripMenuItem63, "ToolStripMenuItem63")
        '
        'mnuViewBarsPen
        '
        Me.mnuViewBarsPen.Name = "mnuViewBarsPen"
        resources.ApplyResources(Me.mnuViewBarsPen, "mnuViewBarsPen")
        '
        'ToolStripMenuItem34
        '
        Me.ToolStripMenuItem34.Name = "ToolStripMenuItem34"
        resources.ApplyResources(Me.ToolStripMenuItem34, "ToolStripMenuItem34")
        '
        'mnuViewWorkspaces
        '
        Me.mnuViewWorkspaces.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewWorkspacesData, Me.mnuViewWorkspacesDesign, Me.mnuViewWorkspacesAll, Me.ToolStripMenuItem56, Me.mnuViewWorkspacesManage})
        Me.mnuViewWorkspaces.Name = "mnuViewWorkspaces"
        resources.ApplyResources(Me.mnuViewWorkspaces, "mnuViewWorkspaces")
        '
        'mnuViewWorkspacesData
        '
        Me.mnuViewWorkspacesData.Name = "mnuViewWorkspacesData"
        resources.ApplyResources(Me.mnuViewWorkspacesData, "mnuViewWorkspacesData")
        '
        'mnuViewWorkspacesDesign
        '
        Me.mnuViewWorkspacesDesign.Name = "mnuViewWorkspacesDesign"
        resources.ApplyResources(Me.mnuViewWorkspacesDesign, "mnuViewWorkspacesDesign")
        '
        'mnuViewWorkspacesAll
        '
        Me.mnuViewWorkspacesAll.Name = "mnuViewWorkspacesAll"
        resources.ApplyResources(Me.mnuViewWorkspacesAll, "mnuViewWorkspacesAll")
        '
        'ToolStripMenuItem56
        '
        Me.ToolStripMenuItem56.Name = "ToolStripMenuItem56"
        resources.ApplyResources(Me.ToolStripMenuItem56, "ToolStripMenuItem56")
        '
        'mnuViewWorkspacesManage
        '
        Me.mnuViewWorkspacesManage.Name = "mnuViewWorkspacesManage"
        resources.ApplyResources(Me.mnuViewWorkspacesManage, "mnuViewWorkspacesManage")
        '
        'mnuViewFieldData
        '
        resources.ApplyResources(Me.mnuViewFieldData, "mnuViewFieldData")
        Me.mnuViewFieldData.Name = "mnuViewFieldData"
        '
        'mnuViewDesignArea
        '
        resources.ApplyResources(Me.mnuViewDesignArea, "mnuViewDesignArea")
        Me.mnuViewDesignArea.Name = "mnuViewDesignArea"
        '
        'mnuViewObjectProp
        '
        resources.ApplyResources(Me.mnuViewObjectProp, "mnuViewObjectProp")
        Me.mnuViewObjectProp.Name = "mnuViewObjectProp"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        resources.ApplyResources(Me.ToolStripMenuItem11, "ToolStripMenuItem11")
        '
        'mnuViewGraphics
        '
        Me.mnuViewGraphics.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewGraphics0, Me.mnuViewGraphics1, Me.mnuViewGraphics2, Me.ToolStripMenuItem3, Me.mnuViewGraphicsRulers, Me.mnuViewGraphicsMetricGrid, Me.ToolStripMenuItem26, Me.mnuViewGraphicsShowAdvancedBrushes})
        Me.mnuViewGraphics.Name = "mnuViewGraphics"
        resources.ApplyResources(Me.mnuViewGraphics, "mnuViewGraphics")
        '
        'mnuViewGraphics0
        '
        Me.mnuViewGraphics0.Name = "mnuViewGraphics0"
        resources.ApplyResources(Me.mnuViewGraphics0, "mnuViewGraphics0")
        '
        'mnuViewGraphics1
        '
        Me.mnuViewGraphics1.Name = "mnuViewGraphics1"
        resources.ApplyResources(Me.mnuViewGraphics1, "mnuViewGraphics1")
        '
        'mnuViewGraphics2
        '
        Me.mnuViewGraphics2.Name = "mnuViewGraphics2"
        resources.ApplyResources(Me.mnuViewGraphics2, "mnuViewGraphics2")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuViewGraphicsRulers
        '
        resources.ApplyResources(Me.mnuViewGraphicsRulers, "mnuViewGraphicsRulers")
        Me.mnuViewGraphicsRulers.Name = "mnuViewGraphicsRulers"
        '
        'mnuViewGraphicsMetricGrid
        '
        Me.mnuViewGraphicsMetricGrid.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewGraphicsMetricGrid0, Me.mnuViewGraphicsMetricGrid1, Me.mnuViewGraphicsMetricGrid2})
        resources.ApplyResources(Me.mnuViewGraphicsMetricGrid, "mnuViewGraphicsMetricGrid")
        Me.mnuViewGraphicsMetricGrid.Name = "mnuViewGraphicsMetricGrid"
        '
        'mnuViewGraphicsMetricGrid0
        '
        Me.mnuViewGraphicsMetricGrid0.Name = "mnuViewGraphicsMetricGrid0"
        resources.ApplyResources(Me.mnuViewGraphicsMetricGrid0, "mnuViewGraphicsMetricGrid0")
        '
        'mnuViewGraphicsMetricGrid1
        '
        Me.mnuViewGraphicsMetricGrid1.Name = "mnuViewGraphicsMetricGrid1"
        resources.ApplyResources(Me.mnuViewGraphicsMetricGrid1, "mnuViewGraphicsMetricGrid1")
        '
        'mnuViewGraphicsMetricGrid2
        '
        Me.mnuViewGraphicsMetricGrid2.Name = "mnuViewGraphicsMetricGrid2"
        resources.ApplyResources(Me.mnuViewGraphicsMetricGrid2, "mnuViewGraphicsMetricGrid2")
        '
        'ToolStripMenuItem26
        '
        Me.ToolStripMenuItem26.Name = "ToolStripMenuItem26"
        resources.ApplyResources(Me.ToolStripMenuItem26, "ToolStripMenuItem26")
        '
        'mnuViewGraphicsShowAdvancedBrushes
        '
        Me.mnuViewGraphicsShowAdvancedBrushes.Name = "mnuViewGraphicsShowAdvancedBrushes"
        resources.ApplyResources(Me.mnuViewGraphicsShowAdvancedBrushes, "mnuViewGraphicsShowAdvancedBrushes")
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        resources.ApplyResources(Me.ToolStripMenuItem14, "ToolStripMenuItem14")
        '
        'mnuViewDesign
        '
        Me.mnuViewDesign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewDesignUnselectedLevelDrawingMode, Me.ToolStripMenuItem75, Me.mnuViewDesignStyle})
        Me.mnuViewDesign.Name = "mnuViewDesign"
        resources.ApplyResources(Me.mnuViewDesign, "mnuViewDesign")
        '
        'mnuViewDesignUnselectedLevelDrawingMode
        '
        Me.mnuViewDesignUnselectedLevelDrawingMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewDesignUnselectedLevelDrawingMode0, Me.mnuViewDesignUnselectedLevelDrawingMode1, Me.mnuViewDesignUnselectedLevelDrawingMode2})
        Me.mnuViewDesignUnselectedLevelDrawingMode.Name = "mnuViewDesignUnselectedLevelDrawingMode"
        resources.ApplyResources(Me.mnuViewDesignUnselectedLevelDrawingMode, "mnuViewDesignUnselectedLevelDrawingMode")
        '
        'mnuViewDesignUnselectedLevelDrawingMode0
        '
        Me.mnuViewDesignUnselectedLevelDrawingMode0.Name = "mnuViewDesignUnselectedLevelDrawingMode0"
        resources.ApplyResources(Me.mnuViewDesignUnselectedLevelDrawingMode0, "mnuViewDesignUnselectedLevelDrawingMode0")
        '
        'mnuViewDesignUnselectedLevelDrawingMode1
        '
        Me.mnuViewDesignUnselectedLevelDrawingMode1.Name = "mnuViewDesignUnselectedLevelDrawingMode1"
        resources.ApplyResources(Me.mnuViewDesignUnselectedLevelDrawingMode1, "mnuViewDesignUnselectedLevelDrawingMode1")
        '
        'mnuViewDesignUnselectedLevelDrawingMode2
        '
        Me.mnuViewDesignUnselectedLevelDrawingMode2.Name = "mnuViewDesignUnselectedLevelDrawingMode2"
        resources.ApplyResources(Me.mnuViewDesignUnselectedLevelDrawingMode2, "mnuViewDesignUnselectedLevelDrawingMode2")
        '
        'ToolStripMenuItem75
        '
        Me.ToolStripMenuItem75.Name = "ToolStripMenuItem75"
        resources.ApplyResources(Me.ToolStripMenuItem75, "ToolStripMenuItem75")
        '
        'mnuViewDesignStyle
        '
        Me.mnuViewDesignStyle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewDesignStyle0, Me.mnuViewDesignStyle1, Me.mnuViewDesignStyle2})
        Me.mnuViewDesignStyle.Name = "mnuViewDesignStyle"
        resources.ApplyResources(Me.mnuViewDesignStyle, "mnuViewDesignStyle")
        '
        'mnuViewDesignStyle0
        '
        Me.mnuViewDesignStyle0.Name = "mnuViewDesignStyle0"
        resources.ApplyResources(Me.mnuViewDesignStyle0, "mnuViewDesignStyle0")
        '
        'mnuViewDesignStyle1
        '
        Me.mnuViewDesignStyle1.Name = "mnuViewDesignStyle1"
        resources.ApplyResources(Me.mnuViewDesignStyle1, "mnuViewDesignStyle1")
        '
        'mnuViewDesignStyle2
        '
        Me.mnuViewDesignStyle2.Name = "mnuViewDesignStyle2"
        resources.ApplyResources(Me.mnuViewDesignStyle2, "mnuViewDesignStyle2")
        '
        'mnuViewPlot
        '
        Me.mnuViewPlot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewPlotSegments, Me.mnuViewPlotShowAlso, Me.ToolStripMenuItem85, Me.mnuViewPlotLRUD, Me.mnuViewPlotSplay, Me.ToolStripMenuItem28, Me.mnuViewPlotShowStation, Me.mnuViewPlotShowStationText, Me.mnuViewPlotShowPointInformation})
        Me.mnuViewPlot.Name = "mnuViewPlot"
        resources.ApplyResources(Me.mnuViewPlot, "mnuViewPlot")
        '
        'mnuViewPlotSegments
        '
        Me.mnuViewPlotSegments.Name = "mnuViewPlotSegments"
        resources.ApplyResources(Me.mnuViewPlotSegments, "mnuViewPlotSegments")
        '
        'mnuViewPlotShowAlso
        '
        Me.mnuViewPlotShowAlso.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewPlotShowAlso1, Me.mnuViewPlotShowAlso2})
        Me.mnuViewPlotShowAlso.Name = "mnuViewPlotShowAlso"
        resources.ApplyResources(Me.mnuViewPlotShowAlso, "mnuViewPlotShowAlso")
        '
        'mnuViewPlotShowAlso1
        '
        Me.mnuViewPlotShowAlso1.Name = "mnuViewPlotShowAlso1"
        resources.ApplyResources(Me.mnuViewPlotShowAlso1, "mnuViewPlotShowAlso1")
        '
        'mnuViewPlotShowAlso2
        '
        Me.mnuViewPlotShowAlso2.Name = "mnuViewPlotShowAlso2"
        resources.ApplyResources(Me.mnuViewPlotShowAlso2, "mnuViewPlotShowAlso2")
        '
        'ToolStripMenuItem85
        '
        Me.ToolStripMenuItem85.Name = "ToolStripMenuItem85"
        resources.ApplyResources(Me.ToolStripMenuItem85, "ToolStripMenuItem85")
        '
        'mnuViewPlotLRUD
        '
        Me.mnuViewPlotLRUD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewPlotLRUDHide, Me.ToolStripMenuItem95, Me.mnuViewPlotShowStyle0, Me.mnuViewPlotShowStyle1, Me.mnuViewPlotShowStyle2, Me.mnuViewPlotShowStyle3})
        Me.mnuViewPlotLRUD.Name = "mnuViewPlotLRUD"
        resources.ApplyResources(Me.mnuViewPlotLRUD, "mnuViewPlotLRUD")
        '
        'mnuViewPlotLRUDHide
        '
        Me.mnuViewPlotLRUDHide.Name = "mnuViewPlotLRUDHide"
        resources.ApplyResources(Me.mnuViewPlotLRUDHide, "mnuViewPlotLRUDHide")
        '
        'ToolStripMenuItem95
        '
        Me.ToolStripMenuItem95.Name = "ToolStripMenuItem95"
        resources.ApplyResources(Me.ToolStripMenuItem95, "ToolStripMenuItem95")
        '
        'mnuViewPlotShowStyle0
        '
        Me.mnuViewPlotShowStyle0.Name = "mnuViewPlotShowStyle0"
        resources.ApplyResources(Me.mnuViewPlotShowStyle0, "mnuViewPlotShowStyle0")
        '
        'mnuViewPlotShowStyle1
        '
        Me.mnuViewPlotShowStyle1.Name = "mnuViewPlotShowStyle1"
        resources.ApplyResources(Me.mnuViewPlotShowStyle1, "mnuViewPlotShowStyle1")
        '
        'mnuViewPlotShowStyle2
        '
        Me.mnuViewPlotShowStyle2.Name = "mnuViewPlotShowStyle2"
        resources.ApplyResources(Me.mnuViewPlotShowStyle2, "mnuViewPlotShowStyle2")
        '
        'mnuViewPlotShowStyle3
        '
        Me.mnuViewPlotShowStyle3.Name = "mnuViewPlotShowStyle3"
        resources.ApplyResources(Me.mnuViewPlotShowStyle3, "mnuViewPlotShowStyle3")
        '
        'mnuViewPlotSplay
        '
        Me.mnuViewPlotSplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewPlotSplayHide, Me.ToolStripMenuItem96, Me.mnuViewPlotSplayStyle0, Me.mnuViewPlotSplayStyle1, Me.ToolStripMenuItem57, Me.mnuViewPlotSplayText})
        Me.mnuViewPlotSplay.Name = "mnuViewPlotSplay"
        resources.ApplyResources(Me.mnuViewPlotSplay, "mnuViewPlotSplay")
        '
        'mnuViewPlotSplayHide
        '
        Me.mnuViewPlotSplayHide.Name = "mnuViewPlotSplayHide"
        resources.ApplyResources(Me.mnuViewPlotSplayHide, "mnuViewPlotSplayHide")
        '
        'ToolStripMenuItem96
        '
        Me.ToolStripMenuItem96.Name = "ToolStripMenuItem96"
        resources.ApplyResources(Me.ToolStripMenuItem96, "ToolStripMenuItem96")
        '
        'mnuViewPlotSplayStyle0
        '
        Me.mnuViewPlotSplayStyle0.Name = "mnuViewPlotSplayStyle0"
        resources.ApplyResources(Me.mnuViewPlotSplayStyle0, "mnuViewPlotSplayStyle0")
        '
        'mnuViewPlotSplayStyle1
        '
        Me.mnuViewPlotSplayStyle1.Name = "mnuViewPlotSplayStyle1"
        resources.ApplyResources(Me.mnuViewPlotSplayStyle1, "mnuViewPlotSplayStyle1")
        '
        'ToolStripMenuItem57
        '
        Me.ToolStripMenuItem57.Name = "ToolStripMenuItem57"
        resources.ApplyResources(Me.ToolStripMenuItem57, "ToolStripMenuItem57")
        '
        'mnuViewPlotSplayText
        '
        Me.mnuViewPlotSplayText.Name = "mnuViewPlotSplayText"
        resources.ApplyResources(Me.mnuViewPlotSplayText, "mnuViewPlotSplayText")
        '
        'ToolStripMenuItem28
        '
        Me.ToolStripMenuItem28.Name = "ToolStripMenuItem28"
        resources.ApplyResources(Me.ToolStripMenuItem28, "ToolStripMenuItem28")
        '
        'mnuViewPlotShowStation
        '
        Me.mnuViewPlotShowStation.Name = "mnuViewPlotShowStation"
        resources.ApplyResources(Me.mnuViewPlotShowStation, "mnuViewPlotShowStation")
        '
        'mnuViewPlotShowStationText
        '
        Me.mnuViewPlotShowStationText.Name = "mnuViewPlotShowStationText"
        resources.ApplyResources(Me.mnuViewPlotShowStationText, "mnuViewPlotShowStationText")
        '
        'mnuViewPlotShowPointInformation
        '
        Me.mnuViewPlotShowPointInformation.Name = "mnuViewPlotShowPointInformation"
        resources.ApplyResources(Me.mnuViewPlotShowPointInformation, "mnuViewPlotShowPointInformation")
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        resources.ApplyResources(Me.ToolStripMenuItem7, "ToolStripMenuItem7")
        '
        'mnuViewPlan
        '
        Me.mnuViewPlan.Name = "mnuViewPlan"
        resources.ApplyResources(Me.mnuViewPlan, "mnuViewPlan")
        '
        'mnuViewProfile
        '
        Me.mnuViewProfile.Name = "mnuViewProfile"
        resources.ApplyResources(Me.mnuViewProfile, "mnuViewProfile")
        '
        'mnuView3D
        '
        Me.mnuView3D.Name = "mnuView3D"
        resources.ApplyResources(Me.mnuView3D, "mnuView3D")
        '
        'ToolStripMenuItem33
        '
        Me.ToolStripMenuItem33.Name = "ToolStripMenuItem33"
        resources.ApplyResources(Me.ToolStripMenuItem33, "ToolStripMenuItem33")
        '
        'mnuViewViewer
        '
        resources.ApplyResources(Me.mnuViewViewer, "mnuViewViewer")
        Me.mnuViewViewer.Name = "mnuViewViewer"
        '
        'ToolStripMenuItem103
        '
        Me.ToolStripMenuItem103.Name = "ToolStripMenuItem103"
        resources.ApplyResources(Me.ToolStripMenuItem103, "ToolStripMenuItem103")
        '
        'mnuViewScript
        '
        resources.ApplyResources(Me.mnuViewScript, "mnuViewScript")
        Me.mnuViewScript.Name = "mnuViewScript"
        '
        'ToolStripMenuItem114
        '
        Me.ToolStripMenuItem114.Name = "ToolStripMenuItem114"
        resources.ApplyResources(Me.ToolStripMenuItem114, "ToolStripMenuItem114")
        '
        'mnuViewLinkedSurveys
        '
        Me.mnuViewLinkedSurveys.Image = Global.cSurveyPC.My.Resources.Resources.link_break
        Me.mnuViewLinkedSurveys.Name = "mnuViewLinkedSurveys"
        resources.ApplyResources(Me.mnuViewLinkedSurveys, "mnuViewLinkedSurveys")
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        resources.ApplyResources(Me.ToolStripMenuItem6, "ToolStripMenuItem6")
        '
        'mnuViewConsole
        '
        resources.ApplyResources(Me.mnuViewConsole, "mnuViewConsole")
        Me.mnuViewConsole.Name = "mnuViewConsole"
        '
        'mnuPlot
        '
        Me.mnuPlot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPlotRebind, Me.mnuPlotRemoveOrphans, Me.ToolStripMenuItem44, Me.mnuPlotGrades, Me.ToolStripMenuItem77, Me.mnuPlotCalculate, Me.ToolStripMenuItem35, Me.mnuPlotInfoSession, Me.mnuPlotInfoEntrance, Me.mnuPlotInfoCave, Me.mnuPlotInfoRing, Me.mnuPlotInfoOrientation, Me.mnuPlotInfoDistances, Me.ToolStripMenuItem67, Me.mnuPlotPrefixTrigpoints, Me.mnuPlotRenameTrigpoints, Me.mnuPlotReplicateData, Me.mnuPlotManageLRUD, Me.ToolStripMenuItem98, Me.mnuPlotSplayReplicate, Me.ToolStripMenuItem36, Me.mnuPlotManageVisibility, Me.ToolStripMenuItem32, Me.mnuPlotDeleteAll})
        Me.mnuPlot.Name = "mnuPlot"
        resources.ApplyResources(Me.mnuPlot, "mnuPlot")
        '
        'mnuPlotRebind
        '
        resources.ApplyResources(Me.mnuPlotRebind, "mnuPlotRebind")
        Me.mnuPlotRebind.Name = "mnuPlotRebind"
        '
        'mnuPlotRemoveOrphans
        '
        Me.mnuPlotRemoveOrphans.Name = "mnuPlotRemoveOrphans"
        resources.ApplyResources(Me.mnuPlotRemoveOrphans, "mnuPlotRemoveOrphans")
        '
        'ToolStripMenuItem44
        '
        Me.ToolStripMenuItem44.Name = "ToolStripMenuItem44"
        resources.ApplyResources(Me.ToolStripMenuItem44, "ToolStripMenuItem44")
        '
        'mnuPlotGrades
        '
        resources.ApplyResources(Me.mnuPlotGrades, "mnuPlotGrades")
        Me.mnuPlotGrades.Name = "mnuPlotGrades"
        '
        'ToolStripMenuItem77
        '
        Me.ToolStripMenuItem77.Name = "ToolStripMenuItem77"
        resources.ApplyResources(Me.ToolStripMenuItem77, "ToolStripMenuItem77")
        '
        'mnuPlotCalculate
        '
        resources.ApplyResources(Me.mnuPlotCalculate, "mnuPlotCalculate")
        Me.mnuPlotCalculate.Name = "mnuPlotCalculate"
        '
        'ToolStripMenuItem35
        '
        Me.ToolStripMenuItem35.Name = "ToolStripMenuItem35"
        resources.ApplyResources(Me.ToolStripMenuItem35, "ToolStripMenuItem35")
        '
        'mnuPlotInfoSession
        '
        resources.ApplyResources(Me.mnuPlotInfoSession, "mnuPlotInfoSession")
        Me.mnuPlotInfoSession.Name = "mnuPlotInfoSession"
        '
        'mnuPlotInfoEntrance
        '
        resources.ApplyResources(Me.mnuPlotInfoEntrance, "mnuPlotInfoEntrance")
        Me.mnuPlotInfoEntrance.Name = "mnuPlotInfoEntrance"
        '
        'mnuPlotInfoCave
        '
        resources.ApplyResources(Me.mnuPlotInfoCave, "mnuPlotInfoCave")
        Me.mnuPlotInfoCave.Name = "mnuPlotInfoCave"
        '
        'mnuPlotInfoRing
        '
        resources.ApplyResources(Me.mnuPlotInfoRing, "mnuPlotInfoRing")
        Me.mnuPlotInfoRing.Name = "mnuPlotInfoRing"
        '
        'mnuPlotInfoOrientation
        '
        resources.ApplyResources(Me.mnuPlotInfoOrientation, "mnuPlotInfoOrientation")
        Me.mnuPlotInfoOrientation.Name = "mnuPlotInfoOrientation"
        '
        'mnuPlotInfoDistances
        '
        resources.ApplyResources(Me.mnuPlotInfoDistances, "mnuPlotInfoDistances")
        Me.mnuPlotInfoDistances.Name = "mnuPlotInfoDistances"
        '
        'ToolStripMenuItem67
        '
        Me.ToolStripMenuItem67.Name = "ToolStripMenuItem67"
        resources.ApplyResources(Me.ToolStripMenuItem67, "ToolStripMenuItem67")
        '
        'mnuPlotPrefixTrigpoints
        '
        resources.ApplyResources(Me.mnuPlotPrefixTrigpoints, "mnuPlotPrefixTrigpoints")
        Me.mnuPlotPrefixTrigpoints.Name = "mnuPlotPrefixTrigpoints"
        '
        'mnuPlotRenameTrigpoints
        '
        Me.mnuPlotRenameTrigpoints.Name = "mnuPlotRenameTrigpoints"
        resources.ApplyResources(Me.mnuPlotRenameTrigpoints, "mnuPlotRenameTrigpoints")
        '
        'mnuPlotReplicateData
        '
        Me.mnuPlotReplicateData.Name = "mnuPlotReplicateData"
        resources.ApplyResources(Me.mnuPlotReplicateData, "mnuPlotReplicateData")
        '
        'mnuPlotManageLRUD
        '
        Me.mnuPlotManageLRUD.Name = "mnuPlotManageLRUD"
        resources.ApplyResources(Me.mnuPlotManageLRUD, "mnuPlotManageLRUD")
        '
        'ToolStripMenuItem98
        '
        Me.ToolStripMenuItem98.Name = "ToolStripMenuItem98"
        resources.ApplyResources(Me.ToolStripMenuItem98, "ToolStripMenuItem98")
        '
        'mnuPlotSplayReplicate
        '
        resources.ApplyResources(Me.mnuPlotSplayReplicate, "mnuPlotSplayReplicate")
        Me.mnuPlotSplayReplicate.Name = "mnuPlotSplayReplicate"
        '
        'ToolStripMenuItem36
        '
        Me.ToolStripMenuItem36.Name = "ToolStripMenuItem36"
        resources.ApplyResources(Me.ToolStripMenuItem36, "ToolStripMenuItem36")
        '
        'mnuPlotManageVisibility
        '
        resources.ApplyResources(Me.mnuPlotManageVisibility, "mnuPlotManageVisibility")
        Me.mnuPlotManageVisibility.Name = "mnuPlotManageVisibility"
        '
        'ToolStripMenuItem32
        '
        Me.ToolStripMenuItem32.Name = "ToolStripMenuItem32"
        resources.ApplyResources(Me.ToolStripMenuItem32, "ToolStripMenuItem32")
        '
        'mnuPlotDeleteAll
        '
        Me.mnuPlotDeleteAll.Name = "mnuPlotDeleteAll"
        resources.ApplyResources(Me.mnuPlotDeleteAll, "mnuPlotDeleteAll")
        '
        'mnuDesign
        '
        Me.mnuDesign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignAdd, Me.mnuDesignEndEdit, Me.mnuDesignObjectProp, Me.ToolStripMenuItem64, Me.mnuDesignEditScaleRules, Me.ToolStripMenuItem68, Me.mnuDesignHighlight, Me.mnuDesignPlot, Me.ToolStripMenuItem37, Me.mnuDesignDeleteAll})
        Me.mnuDesign.Name = "mnuDesign"
        resources.ApplyResources(Me.mnuDesign, "mnuDesign")
        '
        'mnuDesignAdd
        '
        Me.mnuDesignAdd.Name = "mnuDesignAdd"
        resources.ApplyResources(Me.mnuDesignAdd, "mnuDesignAdd")
        '
        'mnuDesignEndEdit
        '
        resources.ApplyResources(Me.mnuDesignEndEdit, "mnuDesignEndEdit")
        Me.mnuDesignEndEdit.Name = "mnuDesignEndEdit"
        '
        'mnuDesignObjectProp
        '
        resources.ApplyResources(Me.mnuDesignObjectProp, "mnuDesignObjectProp")
        Me.mnuDesignObjectProp.Name = "mnuDesignObjectProp"
        '
        'ToolStripMenuItem64
        '
        Me.ToolStripMenuItem64.Name = "ToolStripMenuItem64"
        resources.ApplyResources(Me.ToolStripMenuItem64, "ToolStripMenuItem64")
        '
        'mnuDesignEditScaleRules
        '
        resources.ApplyResources(Me.mnuDesignEditScaleRules, "mnuDesignEditScaleRules")
        Me.mnuDesignEditScaleRules.Name = "mnuDesignEditScaleRules"
        '
        'ToolStripMenuItem68
        '
        Me.ToolStripMenuItem68.Name = "ToolStripMenuItem68"
        resources.ApplyResources(Me.ToolStripMenuItem68, "ToolStripMenuItem68")
        '
        'mnuDesignHighlight
        '
        Me.mnuDesignHighlight.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignHighlight0, Me.mnuDesignHighlight1, Me.ToolStripMenuItem46, Me.mnuDesignHighlightMode})
        resources.ApplyResources(Me.mnuDesignHighlight, "mnuDesignHighlight")
        Me.mnuDesignHighlight.Name = "mnuDesignHighlight"
        '
        'mnuDesignHighlight0
        '
        Me.mnuDesignHighlight0.Name = "mnuDesignHighlight0"
        resources.ApplyResources(Me.mnuDesignHighlight0, "mnuDesignHighlight0")
        '
        'mnuDesignHighlight1
        '
        Me.mnuDesignHighlight1.Name = "mnuDesignHighlight1"
        resources.ApplyResources(Me.mnuDesignHighlight1, "mnuDesignHighlight1")
        '
        'ToolStripMenuItem46
        '
        Me.ToolStripMenuItem46.Name = "ToolStripMenuItem46"
        resources.ApplyResources(Me.ToolStripMenuItem46, "ToolStripMenuItem46")
        '
        'mnuDesignHighlightMode
        '
        Me.mnuDesignHighlightMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignHighlightMode0, Me.mnuDesignHighlightMode1, Me.mnuDesignHighlightMode2})
        Me.mnuDesignHighlightMode.Name = "mnuDesignHighlightMode"
        resources.ApplyResources(Me.mnuDesignHighlightMode, "mnuDesignHighlightMode")
        '
        'mnuDesignHighlightMode0
        '
        Me.mnuDesignHighlightMode0.Name = "mnuDesignHighlightMode0"
        resources.ApplyResources(Me.mnuDesignHighlightMode0, "mnuDesignHighlightMode0")
        '
        'mnuDesignHighlightMode1
        '
        Me.mnuDesignHighlightMode1.Name = "mnuDesignHighlightMode1"
        resources.ApplyResources(Me.mnuDesignHighlightMode1, "mnuDesignHighlightMode1")
        '
        'mnuDesignHighlightMode2
        '
        Me.mnuDesignHighlightMode2.Name = "mnuDesignHighlightMode2"
        resources.ApplyResources(Me.mnuDesignHighlightMode2, "mnuDesignHighlightMode2")
        '
        'mnuDesignPlot
        '
        Me.mnuDesignPlot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignPlotRebindAll, Me.mnuDesignPlotRemoveBindings, Me.ToolStripMenuItem39, Me.mnuDesignPlotUnlockAll, Me.mnuDesignPlotLockAll, Me.ToolStripMenuItem40, Me.mnuDesignPlotShowBindings})
        Me.mnuDesignPlot.Name = "mnuDesignPlot"
        resources.ApplyResources(Me.mnuDesignPlot, "mnuDesignPlot")
        '
        'mnuDesignPlotRebindAll
        '
        resources.ApplyResources(Me.mnuDesignPlotRebindAll, "mnuDesignPlotRebindAll")
        Me.mnuDesignPlotRebindAll.Name = "mnuDesignPlotRebindAll"
        '
        'mnuDesignPlotRemoveBindings
        '
        Me.mnuDesignPlotRemoveBindings.Name = "mnuDesignPlotRemoveBindings"
        resources.ApplyResources(Me.mnuDesignPlotRemoveBindings, "mnuDesignPlotRemoveBindings")
        '
        'ToolStripMenuItem39
        '
        Me.ToolStripMenuItem39.Name = "ToolStripMenuItem39"
        resources.ApplyResources(Me.ToolStripMenuItem39, "ToolStripMenuItem39")
        '
        'mnuDesignPlotUnlockAll
        '
        resources.ApplyResources(Me.mnuDesignPlotUnlockAll, "mnuDesignPlotUnlockAll")
        Me.mnuDesignPlotUnlockAll.Name = "mnuDesignPlotUnlockAll"
        '
        'mnuDesignPlotLockAll
        '
        resources.ApplyResources(Me.mnuDesignPlotLockAll, "mnuDesignPlotLockAll")
        Me.mnuDesignPlotLockAll.Name = "mnuDesignPlotLockAll"
        '
        'ToolStripMenuItem40
        '
        Me.ToolStripMenuItem40.Name = "ToolStripMenuItem40"
        resources.ApplyResources(Me.ToolStripMenuItem40, "ToolStripMenuItem40")
        '
        'mnuDesignPlotShowBindings
        '
        resources.ApplyResources(Me.mnuDesignPlotShowBindings, "mnuDesignPlotShowBindings")
        Me.mnuDesignPlotShowBindings.Name = "mnuDesignPlotShowBindings"
        '
        'ToolStripMenuItem37
        '
        Me.ToolStripMenuItem37.Name = "ToolStripMenuItem37"
        resources.ApplyResources(Me.ToolStripMenuItem37, "ToolStripMenuItem37")
        '
        'mnuDesignDeleteAll
        '
        Me.mnuDesignDeleteAll.Name = "mnuDesignDeleteAll"
        resources.ApplyResources(Me.mnuDesignDeleteAll, "mnuDesignDeleteAll")
        '
        'mnuLayers
        '
        Me.mnuLayers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLayers0, Me.ToolStripMenuItem17, Me.mnuLayers1, Me.mnuLayers2, Me.mnuLayers3, Me.mnuLayers4, Me.mnuLayers5, Me.mnuLayers6, Me.ToolStripMenuItem55, Me.mnuLayersManageLevels})
        Me.mnuLayers.Name = "mnuLayers"
        resources.ApplyResources(Me.mnuLayers, "mnuLayers")
        '
        'mnuLayers0
        '
        resources.ApplyResources(Me.mnuLayers0, "mnuLayers0")
        Me.mnuLayers0.Name = "mnuLayers0"
        '
        'ToolStripMenuItem17
        '
        Me.ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        resources.ApplyResources(Me.ToolStripMenuItem17, "ToolStripMenuItem17")
        '
        'mnuLayers1
        '
        resources.ApplyResources(Me.mnuLayers1, "mnuLayers1")
        Me.mnuLayers1.Name = "mnuLayers1"
        '
        'mnuLayers2
        '
        resources.ApplyResources(Me.mnuLayers2, "mnuLayers2")
        Me.mnuLayers2.Name = "mnuLayers2"
        '
        'mnuLayers3
        '
        resources.ApplyResources(Me.mnuLayers3, "mnuLayers3")
        Me.mnuLayers3.Name = "mnuLayers3"
        '
        'mnuLayers4
        '
        resources.ApplyResources(Me.mnuLayers4, "mnuLayers4")
        Me.mnuLayers4.Name = "mnuLayers4"
        '
        'mnuLayers5
        '
        resources.ApplyResources(Me.mnuLayers5, "mnuLayers5")
        Me.mnuLayers5.Name = "mnuLayers5"
        '
        'mnuLayers6
        '
        resources.ApplyResources(Me.mnuLayers6, "mnuLayers6")
        Me.mnuLayers6.Name = "mnuLayers6"
        '
        'ToolStripMenuItem55
        '
        Me.ToolStripMenuItem55.Name = "ToolStripMenuItem55"
        resources.ApplyResources(Me.ToolStripMenuItem55, "ToolStripMenuItem55")
        '
        'mnuLayersManageLevels
        '
        resources.ApplyResources(Me.mnuLayersManageLevels, "mnuLayersManageLevels")
        Me.mnuLayersManageLevels.Name = "mnuLayersManageLevels"
        '
        'mnuZoom
        '
        Me.mnuZoom.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuZoomZoomIn, Me.mnuZoomZoomOut, Me.ToolStripMenuItem31, Me.mnuZoomZoomCenter, Me.ToolStripMenuItem30, Me.mnuZoomZoomToFit, Me.mnuZoomZoomToSelection, Me.mnuZoomZoomToFitCaveBranch, Me.ToolStripMenuItem25, Me.mnuZoomAutoZoomToFit})
        Me.mnuZoom.Name = "mnuZoom"
        resources.ApplyResources(Me.mnuZoom, "mnuZoom")
        '
        'mnuZoomZoomIn
        '
        resources.ApplyResources(Me.mnuZoomZoomIn, "mnuZoomZoomIn")
        Me.mnuZoomZoomIn.Name = "mnuZoomZoomIn"
        '
        'mnuZoomZoomOut
        '
        resources.ApplyResources(Me.mnuZoomZoomOut, "mnuZoomZoomOut")
        Me.mnuZoomZoomOut.Name = "mnuZoomZoomOut"
        '
        'ToolStripMenuItem31
        '
        Me.ToolStripMenuItem31.Name = "ToolStripMenuItem31"
        resources.ApplyResources(Me.ToolStripMenuItem31, "ToolStripMenuItem31")
        '
        'mnuZoomZoomCenter
        '
        Me.mnuZoomZoomCenter.Name = "mnuZoomZoomCenter"
        resources.ApplyResources(Me.mnuZoomZoomCenter, "mnuZoomZoomCenter")
        '
        'ToolStripMenuItem30
        '
        Me.ToolStripMenuItem30.Name = "ToolStripMenuItem30"
        resources.ApplyResources(Me.ToolStripMenuItem30, "ToolStripMenuItem30")
        '
        'mnuZoomZoomToFit
        '
        resources.ApplyResources(Me.mnuZoomZoomToFit, "mnuZoomZoomToFit")
        Me.mnuZoomZoomToFit.Name = "mnuZoomZoomToFit"
        '
        'mnuZoomZoomToSelection
        '
        Me.mnuZoomZoomToSelection.Name = "mnuZoomZoomToSelection"
        resources.ApplyResources(Me.mnuZoomZoomToSelection, "mnuZoomZoomToSelection")
        '
        'mnuZoomZoomToFitCaveBranch
        '
        Me.mnuZoomZoomToFitCaveBranch.Name = "mnuZoomZoomToFitCaveBranch"
        resources.ApplyResources(Me.mnuZoomZoomToFitCaveBranch, "mnuZoomZoomToFitCaveBranch")
        '
        'ToolStripMenuItem25
        '
        Me.ToolStripMenuItem25.Name = "ToolStripMenuItem25"
        resources.ApplyResources(Me.ToolStripMenuItem25, "ToolStripMenuItem25")
        '
        'mnuZoomAutoZoomToFit
        '
        Me.mnuZoomAutoZoomToFit.Name = "mnuZoomAutoZoomToFit"
        resources.ApplyResources(Me.mnuZoomAutoZoomToFit, "mnuZoomAutoZoomToFit")
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHelpCheckUpdate, Me.ToolStripMenuItem20, Me.mnuHelpInfo})
        Me.mnuHelp.Name = "mnuHelp"
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        '
        'mnuHelpCheckUpdate
        '
        Me.mnuHelpCheckUpdate.Name = "mnuHelpCheckUpdate"
        resources.ApplyResources(Me.mnuHelpCheckUpdate, "mnuHelpCheckUpdate")
        '
        'ToolStripMenuItem20
        '
        Me.ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        resources.ApplyResources(Me.ToolStripMenuItem20, "ToolStripMenuItem20")
        '
        'mnuHelpInfo
        '
        Me.mnuHelpInfo.Name = "mnuHelpInfo"
        resources.ApplyResources(Me.mnuHelpInfo, "mnuHelpInfo")
        '
        'mnuDesignNone
        '
        resources.ApplyResources(Me.mnuDesignNone, "mnuDesignNone")
        Me.mnuDesignNone.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignNoneInfo, Me.ToolStripMenuItem105, Me.mnuDesignNonePaste, Me.mnuDesignNonePasteSpecial, Me.ToolStripMenuItem54, Me.mnuDesignNoneItemUnder, Me.ToolStripMenuItem106, Me.mnuDesignNoneProperty, Me.ToolStripMenuItem15, Me.mnuDesignNoneRefresh})
        Me.mnuDesignNone.Name = "mnuDesignNone"
        '
        'mnuDesignNoneInfo
        '
        resources.ApplyResources(Me.mnuDesignNoneInfo, "mnuDesignNoneInfo")
        Me.mnuDesignNoneInfo.Name = "mnuDesignNoneInfo"
        '
        'ToolStripMenuItem105
        '
        Me.ToolStripMenuItem105.Name = "ToolStripMenuItem105"
        resources.ApplyResources(Me.ToolStripMenuItem105, "ToolStripMenuItem105")
        '
        'mnuDesignNonePaste
        '
        resources.ApplyResources(Me.mnuDesignNonePaste, "mnuDesignNonePaste")
        Me.mnuDesignNonePaste.Name = "mnuDesignNonePaste"
        '
        'mnuDesignNonePasteSpecial
        '
        Me.mnuDesignNonePasteSpecial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignNonePasteSpecial0, Me.ToolStripMenuItem59, Me.mnuDesignNonePasteSpecial1, Me.mnuDesignNonePasteSpecial2, Me.mnuDesignNonePasteSpecial3})
        Me.mnuDesignNonePasteSpecial.Name = "mnuDesignNonePasteSpecial"
        resources.ApplyResources(Me.mnuDesignNonePasteSpecial, "mnuDesignNonePasteSpecial")
        '
        'mnuDesignNonePasteSpecial0
        '
        Me.mnuDesignNonePasteSpecial0.Name = "mnuDesignNonePasteSpecial0"
        resources.ApplyResources(Me.mnuDesignNonePasteSpecial0, "mnuDesignNonePasteSpecial0")
        '
        'ToolStripMenuItem59
        '
        Me.ToolStripMenuItem59.Name = "ToolStripMenuItem59"
        resources.ApplyResources(Me.ToolStripMenuItem59, "ToolStripMenuItem59")
        '
        'mnuDesignNonePasteSpecial1
        '
        Me.mnuDesignNonePasteSpecial1.Name = "mnuDesignNonePasteSpecial1"
        resources.ApplyResources(Me.mnuDesignNonePasteSpecial1, "mnuDesignNonePasteSpecial1")
        '
        'mnuDesignNonePasteSpecial2
        '
        Me.mnuDesignNonePasteSpecial2.Name = "mnuDesignNonePasteSpecial2"
        resources.ApplyResources(Me.mnuDesignNonePasteSpecial2, "mnuDesignNonePasteSpecial2")
        '
        'mnuDesignNonePasteSpecial3
        '
        Me.mnuDesignNonePasteSpecial3.Name = "mnuDesignNonePasteSpecial3"
        resources.ApplyResources(Me.mnuDesignNonePasteSpecial3, "mnuDesignNonePasteSpecial3")
        '
        'ToolStripMenuItem54
        '
        Me.ToolStripMenuItem54.Name = "ToolStripMenuItem54"
        resources.ApplyResources(Me.ToolStripMenuItem54, "ToolStripMenuItem54")
        '
        'mnuDesignNoneItemUnder
        '
        Me.mnuDesignNoneItemUnder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem107})
        Me.mnuDesignNoneItemUnder.Name = "mnuDesignNoneItemUnder"
        resources.ApplyResources(Me.mnuDesignNoneItemUnder, "mnuDesignNoneItemUnder")
        '
        'ToolStripMenuItem107
        '
        Me.ToolStripMenuItem107.Name = "ToolStripMenuItem107"
        resources.ApplyResources(Me.ToolStripMenuItem107, "ToolStripMenuItem107")
        '
        'ToolStripMenuItem106
        '
        Me.ToolStripMenuItem106.Name = "ToolStripMenuItem106"
        resources.ApplyResources(Me.ToolStripMenuItem106, "ToolStripMenuItem106")
        '
        'mnuDesignNoneProperty
        '
        resources.ApplyResources(Me.mnuDesignNoneProperty, "mnuDesignNoneProperty")
        Me.mnuDesignNoneProperty.Name = "mnuDesignNoneProperty"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        resources.ApplyResources(Me.ToolStripMenuItem15, "ToolStripMenuItem15")
        '
        'mnuDesignNoneRefresh
        '
        Me.mnuDesignNoneRefresh.Name = "mnuDesignNoneRefresh"
        resources.ApplyResources(Me.mnuDesignNoneRefresh, "mnuDesignNoneRefresh")
        '
        'mnuDesignItem
        '
        resources.ApplyResources(Me.mnuDesignItem, "mnuDesignItem")
        Me.mnuDesignItem.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemInfo, Me.mnuDesignItemBarInfo, Me.mnuDesignItemSign, Me.mnuDesignItemSegment, Me.mnuDesignItemClipart, Me.mnuDesignItemSegmentTrigpoint, Me.mnuDesignItemSegmentInvert, Me.mnuDesignItemSegmentDirection, Me.mnuDesignItemSegmentSetCoordinate, Me.mnuDesignItemSegmentSetCoordinateCP, Me.mnuDesignItemSegmentSplay, Me.mnuDesignItemGeneric, Me.mnuDesignItemItems, Me.mnuDesignItemImage, Me.mnuDesignItemSketch, Me.mnuDesignItemLegend, Me.mnuDesignItemBar0, Me.mnuDesignItemCut, Me.mnuDesignItemCopy, Me.mnuDesignItemPaste, Me.mnuDesignItemPasteSpecial, Me.mnuDesignItemDelete, Me.mnuDesignItemBar2, Me.mnuDesignItemItemUnder, Me.mnuDesignItemItemBar8, Me.mnuDesignItemSendToBottom, Me.mnuDesignItemSendBehind, Me.mnuDesignItemBringAhead, Me.mnuDesignItemBringOnTop, Me.mnuDesignItemBar3, Me.mnuDesignItemSendCopyTo, Me.mnuDesignItemBar8, Me.mnuDesignItemChangeTo, Me.mnuDesignItemFlip, Me.mnuDesignItemRotate, Me.mnuDesignItemBar4, Me.mnuDesignItemPlot, Me.mnuDesignItemBar5, Me.mnuDesignItemLock, Me.mnuDesignItemBar6, Me.mnuDesignItemProperty, Me.mnuDesignItemHiddenInDesign, Me.mnuDesignItemBar7, Me.mnuDesignItemRefresh})
        Me.mnuDesignItem.Name = "mnuDesignNone"
        '
        'mnuDesignItemInfo
        '
        resources.ApplyResources(Me.mnuDesignItemInfo, "mnuDesignItemInfo")
        Me.mnuDesignItemInfo.Name = "mnuDesignItemInfo"
        '
        'mnuDesignItemBarInfo
        '
        Me.mnuDesignItemBarInfo.Name = "mnuDesignItemBarInfo"
        resources.ApplyResources(Me.mnuDesignItemBarInfo, "mnuDesignItemBarInfo")
        '
        'mnuDesignItemSign
        '
        Me.mnuDesignItemSign.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSignSaveInGallery, Me.ToolStripMenuItem113, Me.mnuDesignItemSignExport})
        Me.mnuDesignItemSign.Name = "mnuDesignItemSign"
        resources.ApplyResources(Me.mnuDesignItemSign, "mnuDesignItemSign")
        '
        'mnuDesignItemSignSaveInGallery
        '
        Me.mnuDesignItemSignSaveInGallery.Name = "mnuDesignItemSignSaveInGallery"
        resources.ApplyResources(Me.mnuDesignItemSignSaveInGallery, "mnuDesignItemSignSaveInGallery")
        '
        'ToolStripMenuItem113
        '
        Me.ToolStripMenuItem113.Name = "ToolStripMenuItem113"
        resources.ApplyResources(Me.ToolStripMenuItem113, "ToolStripMenuItem113")
        '
        'mnuDesignItemSignExport
        '
        Me.mnuDesignItemSignExport.Name = "mnuDesignItemSignExport"
        resources.ApplyResources(Me.mnuDesignItemSignExport, "mnuDesignItemSignExport")
        '
        'mnuDesignItemSegment
        '
        Me.mnuDesignItemSegment.Name = "mnuDesignItemSegment"
        resources.ApplyResources(Me.mnuDesignItemSegment, "mnuDesignItemSegment")
        '
        'mnuDesignItemClipart
        '
        Me.mnuDesignItemClipart.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemClipartSaveInGallery, Me.ToolStripMenuItem112, Me.mnuDesignItemClipartExport})
        Me.mnuDesignItemClipart.Name = "mnuDesignItemClipart"
        resources.ApplyResources(Me.mnuDesignItemClipart, "mnuDesignItemClipart")
        '
        'mnuDesignItemClipartSaveInGallery
        '
        Me.mnuDesignItemClipartSaveInGallery.Name = "mnuDesignItemClipartSaveInGallery"
        resources.ApplyResources(Me.mnuDesignItemClipartSaveInGallery, "mnuDesignItemClipartSaveInGallery")
        '
        'ToolStripMenuItem112
        '
        Me.ToolStripMenuItem112.Name = "ToolStripMenuItem112"
        resources.ApplyResources(Me.ToolStripMenuItem112, "ToolStripMenuItem112")
        '
        'mnuDesignItemClipartExport
        '
        Me.mnuDesignItemClipartExport.Name = "mnuDesignItemClipartExport"
        resources.ApplyResources(Me.mnuDesignItemClipartExport, "mnuDesignItemClipartExport")
        '
        'mnuDesignItemSegmentTrigpoint
        '
        Me.mnuDesignItemSegmentTrigpoint.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSegmentTrigpointFrom, Me.mnuDesignItemSegmentTrigpointTo})
        Me.mnuDesignItemSegmentTrigpoint.Name = "mnuDesignItemSegmentTrigpoint"
        resources.ApplyResources(Me.mnuDesignItemSegmentTrigpoint, "mnuDesignItemSegmentTrigpoint")
        '
        'mnuDesignItemSegmentTrigpointFrom
        '
        Me.mnuDesignItemSegmentTrigpointFrom.Name = "mnuDesignItemSegmentTrigpointFrom"
        resources.ApplyResources(Me.mnuDesignItemSegmentTrigpointFrom, "mnuDesignItemSegmentTrigpointFrom")
        '
        'mnuDesignItemSegmentTrigpointTo
        '
        Me.mnuDesignItemSegmentTrigpointTo.Name = "mnuDesignItemSegmentTrigpointTo"
        resources.ApplyResources(Me.mnuDesignItemSegmentTrigpointTo, "mnuDesignItemSegmentTrigpointTo")
        '
        'mnuDesignItemSegmentInvert
        '
        Me.mnuDesignItemSegmentInvert.Name = "mnuDesignItemSegmentInvert"
        resources.ApplyResources(Me.mnuDesignItemSegmentInvert, "mnuDesignItemSegmentInvert")
        '
        'mnuDesignItemSegmentDirection
        '
        Me.mnuDesignItemSegmentDirection.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSegmentDirection0, Me.mnuDesignItemSegmentDirection1, Me.mnuDesignItemSegmentDirection2, Me.ToolStripMenuItem83, Me.mnuDesignItemSegmentDirection3, Me.mnuDesignItemSegmentDirection4})
        Me.mnuDesignItemSegmentDirection.Name = "mnuDesignItemSegmentDirection"
        resources.ApplyResources(Me.mnuDesignItemSegmentDirection, "mnuDesignItemSegmentDirection")
        '
        'mnuDesignItemSegmentDirection0
        '
        resources.ApplyResources(Me.mnuDesignItemSegmentDirection0, "mnuDesignItemSegmentDirection0")
        Me.mnuDesignItemSegmentDirection0.Name = "mnuDesignItemSegmentDirection0"
        '
        'mnuDesignItemSegmentDirection1
        '
        Me.mnuDesignItemSegmentDirection1.Name = "mnuDesignItemSegmentDirection1"
        resources.ApplyResources(Me.mnuDesignItemSegmentDirection1, "mnuDesignItemSegmentDirection1")
        '
        'mnuDesignItemSegmentDirection2
        '
        resources.ApplyResources(Me.mnuDesignItemSegmentDirection2, "mnuDesignItemSegmentDirection2")
        Me.mnuDesignItemSegmentDirection2.Name = "mnuDesignItemSegmentDirection2"
        '
        'ToolStripMenuItem83
        '
        Me.ToolStripMenuItem83.Name = "ToolStripMenuItem83"
        resources.ApplyResources(Me.ToolStripMenuItem83, "ToolStripMenuItem83")
        '
        'mnuDesignItemSegmentDirection3
        '
        Me.mnuDesignItemSegmentDirection3.Name = "mnuDesignItemSegmentDirection3"
        resources.ApplyResources(Me.mnuDesignItemSegmentDirection3, "mnuDesignItemSegmentDirection3")
        '
        'mnuDesignItemSegmentDirection4
        '
        Me.mnuDesignItemSegmentDirection4.Name = "mnuDesignItemSegmentDirection4"
        resources.ApplyResources(Me.mnuDesignItemSegmentDirection4, "mnuDesignItemSegmentDirection4")
        '
        'mnuDesignItemSegmentSetCoordinate
        '
        Me.mnuDesignItemSegmentSetCoordinate.Name = "mnuDesignItemSegmentSetCoordinate"
        resources.ApplyResources(Me.mnuDesignItemSegmentSetCoordinate, "mnuDesignItemSegmentSetCoordinate")
        '
        'mnuDesignItemSegmentSetCoordinateCP
        '
        Me.mnuDesignItemSegmentSetCoordinateCP.Name = "mnuDesignItemSegmentSetCoordinateCP"
        resources.ApplyResources(Me.mnuDesignItemSegmentSetCoordinateCP, "mnuDesignItemSegmentSetCoordinateCP")
        '
        'mnuDesignItemSegmentSplay
        '
        Me.mnuDesignItemSegmentSplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSegmentSplayReplicate, Me.mnuDesignItemSegmentSplayBar1, Me.mnuDesignItemSegmentSplayCreateBorder})
        Me.mnuDesignItemSegmentSplay.Name = "mnuDesignItemSegmentSplay"
        resources.ApplyResources(Me.mnuDesignItemSegmentSplay, "mnuDesignItemSegmentSplay")
        '
        'mnuDesignItemSegmentSplayReplicate
        '
        resources.ApplyResources(Me.mnuDesignItemSegmentSplayReplicate, "mnuDesignItemSegmentSplayReplicate")
        Me.mnuDesignItemSegmentSplayReplicate.Name = "mnuDesignItemSegmentSplayReplicate"
        '
        'mnuDesignItemSegmentSplayBar1
        '
        Me.mnuDesignItemSegmentSplayBar1.Name = "mnuDesignItemSegmentSplayBar1"
        resources.ApplyResources(Me.mnuDesignItemSegmentSplayBar1, "mnuDesignItemSegmentSplayBar1")
        '
        'mnuDesignItemSegmentSplayCreateBorder
        '
        Me.mnuDesignItemSegmentSplayCreateBorder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSegmentSplayCreateBorderPanel})
        Me.mnuDesignItemSegmentSplayCreateBorder.Name = "mnuDesignItemSegmentSplayCreateBorder"
        resources.ApplyResources(Me.mnuDesignItemSegmentSplayCreateBorder, "mnuDesignItemSegmentSplayCreateBorder")
        '
        'mnuDesignItemSegmentSplayCreateBorderPanel
        '
        Me.mnuDesignItemSegmentSplayCreateBorderPanel.Name = "mnuDesignItemSegmentSplayCreateBorderPanel"
        resources.ApplyResources(Me.mnuDesignItemSegmentSplayCreateBorderPanel, "mnuDesignItemSegmentSplayCreateBorderPanel")
        '
        'mnuDesignItemGeneric
        '
        Me.mnuDesignItemGeneric.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemGenericCombine, Me.mnuDesignItemGenericDivide, Me.ToolStripMenuItem12, Me.mnuDesignItemGenericCombineAllSequences, Me.mnuDesignItemGenericCloseAllSequences, Me.mnuDesignItemGenericReorderSequence, Me.mnuDesignItemGenericRevertAllSequences, Me.ToolStripMenuItem92, Me.mnuDesignItemGenericRestorePointPen, Me.ToolStripMenuItem8, Me.mnuDesignItemGenericWiden, Me.ToolStripMenuItem53, Me.mnuDesignItemGenericReducePoint})
        Me.mnuDesignItemGeneric.Name = "mnuDesignItemGeneric"
        resources.ApplyResources(Me.mnuDesignItemGeneric, "mnuDesignItemGeneric")
        '
        'mnuDesignItemGenericCombine
        '
        resources.ApplyResources(Me.mnuDesignItemGenericCombine, "mnuDesignItemGenericCombine")
        Me.mnuDesignItemGenericCombine.Name = "mnuDesignItemGenericCombine"
        '
        'mnuDesignItemGenericDivide
        '
        resources.ApplyResources(Me.mnuDesignItemGenericDivide, "mnuDesignItemGenericDivide")
        Me.mnuDesignItemGenericDivide.Name = "mnuDesignItemGenericDivide"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        resources.ApplyResources(Me.ToolStripMenuItem12, "ToolStripMenuItem12")
        '
        'mnuDesignItemGenericCombineAllSequences
        '
        Me.mnuDesignItemGenericCombineAllSequences.Name = "mnuDesignItemGenericCombineAllSequences"
        resources.ApplyResources(Me.mnuDesignItemGenericCombineAllSequences, "mnuDesignItemGenericCombineAllSequences")
        '
        'mnuDesignItemGenericCloseAllSequences
        '
        Me.mnuDesignItemGenericCloseAllSequences.Name = "mnuDesignItemGenericCloseAllSequences"
        resources.ApplyResources(Me.mnuDesignItemGenericCloseAllSequences, "mnuDesignItemGenericCloseAllSequences")
        '
        'mnuDesignItemGenericReorderSequence
        '
        resources.ApplyResources(Me.mnuDesignItemGenericReorderSequence, "mnuDesignItemGenericReorderSequence")
        Me.mnuDesignItemGenericReorderSequence.Name = "mnuDesignItemGenericReorderSequence"
        '
        'mnuDesignItemGenericRevertAllSequences
        '
        Me.mnuDesignItemGenericRevertAllSequences.Name = "mnuDesignItemGenericRevertAllSequences"
        resources.ApplyResources(Me.mnuDesignItemGenericRevertAllSequences, "mnuDesignItemGenericRevertAllSequences")
        '
        'ToolStripMenuItem92
        '
        Me.ToolStripMenuItem92.Name = "ToolStripMenuItem92"
        resources.ApplyResources(Me.ToolStripMenuItem92, "ToolStripMenuItem92")
        '
        'mnuDesignItemGenericRestorePointPen
        '
        Me.mnuDesignItemGenericRestorePointPen.Name = "mnuDesignItemGenericRestorePointPen"
        resources.ApplyResources(Me.mnuDesignItemGenericRestorePointPen, "mnuDesignItemGenericRestorePointPen")
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        '
        'mnuDesignItemGenericWiden
        '
        Me.mnuDesignItemGenericWiden.Name = "mnuDesignItemGenericWiden"
        resources.ApplyResources(Me.mnuDesignItemGenericWiden, "mnuDesignItemGenericWiden")
        '
        'ToolStripMenuItem53
        '
        Me.ToolStripMenuItem53.Name = "ToolStripMenuItem53"
        resources.ApplyResources(Me.ToolStripMenuItem53, "ToolStripMenuItem53")
        '
        'mnuDesignItemGenericReducePoint
        '
        resources.ApplyResources(Me.mnuDesignItemGenericReducePoint, "mnuDesignItemGenericReducePoint")
        Me.mnuDesignItemGenericReducePoint.Name = "mnuDesignItemGenericReducePoint"
        '
        'mnuDesignItemItems
        '
        Me.mnuDesignItemItems.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemItemsCombine, Me.mnuDesignItemItemsCombineGroup, Me.ToolStripMenuItem111, Me.mnuDesignItemItemsCombineRockClipart, Me.mnuDesignItemItemsCombineConcretionClipart, Me.ToolStripMenuItem110, Me.mnuDesignItemItemsCombineSignClipart})
        Me.mnuDesignItemItems.Name = "mnuDesignItemItems"
        resources.ApplyResources(Me.mnuDesignItemItems, "mnuDesignItemItems")
        '
        'mnuDesignItemItemsCombine
        '
        resources.ApplyResources(Me.mnuDesignItemItemsCombine, "mnuDesignItemItemsCombine")
        Me.mnuDesignItemItemsCombine.Name = "mnuDesignItemItemsCombine"
        '
        'mnuDesignItemItemsCombineGroup
        '
        Me.mnuDesignItemItemsCombineGroup.Name = "mnuDesignItemItemsCombineGroup"
        resources.ApplyResources(Me.mnuDesignItemItemsCombineGroup, "mnuDesignItemItemsCombineGroup")
        '
        'ToolStripMenuItem111
        '
        Me.ToolStripMenuItem111.Name = "ToolStripMenuItem111"
        resources.ApplyResources(Me.ToolStripMenuItem111, "ToolStripMenuItem111")
        '
        'mnuDesignItemItemsCombineRockClipart
        '
        Me.mnuDesignItemItemsCombineRockClipart.Name = "mnuDesignItemItemsCombineRockClipart"
        resources.ApplyResources(Me.mnuDesignItemItemsCombineRockClipart, "mnuDesignItemItemsCombineRockClipart")
        '
        'mnuDesignItemItemsCombineConcretionClipart
        '
        Me.mnuDesignItemItemsCombineConcretionClipart.Name = "mnuDesignItemItemsCombineConcretionClipart"
        resources.ApplyResources(Me.mnuDesignItemItemsCombineConcretionClipart, "mnuDesignItemItemsCombineConcretionClipart")
        '
        'ToolStripMenuItem110
        '
        Me.ToolStripMenuItem110.Name = "ToolStripMenuItem110"
        resources.ApplyResources(Me.ToolStripMenuItem110, "ToolStripMenuItem110")
        '
        'mnuDesignItemItemsCombineSignClipart
        '
        Me.mnuDesignItemItemsCombineSignClipart.Name = "mnuDesignItemItemsCombineSignClipart"
        resources.ApplyResources(Me.mnuDesignItemItemsCombineSignClipart, "mnuDesignItemItemsCombineSignClipart")
        '
        'mnuDesignItemImage
        '
        Me.mnuDesignItemImage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemImageChange, Me.ToolStripSeparator5, Me.mnuDesignItemImageRescale, Me.mnuDesignItemImageResizeMode, Me.mnuDesignItemImageRealSize, Me.ToolStripMenuItem79, Me.mnuDesignItemImageVisible, Me.ToolStripMenuItem82, Me.mnuDesignItemImageView})
        Me.mnuDesignItemImage.Name = "mnuDesignItemImage"
        resources.ApplyResources(Me.mnuDesignItemImage, "mnuDesignItemImage")
        '
        'mnuDesignItemImageChange
        '
        resources.ApplyResources(Me.mnuDesignItemImageChange, "mnuDesignItemImageChange")
        Me.mnuDesignItemImageChange.Name = "mnuDesignItemImageChange"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'mnuDesignItemImageRescale
        '
        Me.mnuDesignItemImageRescale.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemImageRescale90, Me.mnuDesignItemImageRescale50})
        Me.mnuDesignItemImageRescale.Name = "mnuDesignItemImageRescale"
        resources.ApplyResources(Me.mnuDesignItemImageRescale, "mnuDesignItemImageRescale")
        '
        'mnuDesignItemImageRescale90
        '
        Me.mnuDesignItemImageRescale90.Name = "mnuDesignItemImageRescale90"
        resources.ApplyResources(Me.mnuDesignItemImageRescale90, "mnuDesignItemImageRescale90")
        '
        'mnuDesignItemImageRescale50
        '
        Me.mnuDesignItemImageRescale50.Name = "mnuDesignItemImageRescale50"
        resources.ApplyResources(Me.mnuDesignItemImageRescale50, "mnuDesignItemImageRescale50")
        '
        'mnuDesignItemImageResizeMode
        '
        Me.mnuDesignItemImageResizeMode.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemImageResizeMode0, Me.mnuDesignItemImageResizeMode1})
        Me.mnuDesignItemImageResizeMode.Name = "mnuDesignItemImageResizeMode"
        resources.ApplyResources(Me.mnuDesignItemImageResizeMode, "mnuDesignItemImageResizeMode")
        '
        'mnuDesignItemImageResizeMode0
        '
        Me.mnuDesignItemImageResizeMode0.Name = "mnuDesignItemImageResizeMode0"
        resources.ApplyResources(Me.mnuDesignItemImageResizeMode0, "mnuDesignItemImageResizeMode0")
        '
        'mnuDesignItemImageResizeMode1
        '
        Me.mnuDesignItemImageResizeMode1.Name = "mnuDesignItemImageResizeMode1"
        resources.ApplyResources(Me.mnuDesignItemImageResizeMode1, "mnuDesignItemImageResizeMode1")
        '
        'mnuDesignItemImageRealSize
        '
        Me.mnuDesignItemImageRealSize.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemImageRealSizeImage, Me.ToolStripSeparator6, Me.mnuDesignItemImageRealSize100, Me.mnuDesignItemImageRealSize250, Me.mnuDesignItemImageRealSize500})
        Me.mnuDesignItemImageRealSize.Name = "mnuDesignItemImageRealSize"
        resources.ApplyResources(Me.mnuDesignItemImageRealSize, "mnuDesignItemImageRealSize")
        '
        'mnuDesignItemImageRealSizeImage
        '
        Me.mnuDesignItemImageRealSizeImage.Name = "mnuDesignItemImageRealSizeImage"
        resources.ApplyResources(Me.mnuDesignItemImageRealSizeImage, "mnuDesignItemImageRealSizeImage")
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'mnuDesignItemImageRealSize100
        '
        Me.mnuDesignItemImageRealSize100.Name = "mnuDesignItemImageRealSize100"
        resources.ApplyResources(Me.mnuDesignItemImageRealSize100, "mnuDesignItemImageRealSize100")
        '
        'mnuDesignItemImageRealSize250
        '
        Me.mnuDesignItemImageRealSize250.Name = "mnuDesignItemImageRealSize250"
        resources.ApplyResources(Me.mnuDesignItemImageRealSize250, "mnuDesignItemImageRealSize250")
        '
        'mnuDesignItemImageRealSize500
        '
        Me.mnuDesignItemImageRealSize500.Name = "mnuDesignItemImageRealSize500"
        resources.ApplyResources(Me.mnuDesignItemImageRealSize500, "mnuDesignItemImageRealSize500")
        '
        'ToolStripMenuItem79
        '
        Me.ToolStripMenuItem79.Name = "ToolStripMenuItem79"
        resources.ApplyResources(Me.ToolStripMenuItem79, "ToolStripMenuItem79")
        '
        'mnuDesignItemImageVisible
        '
        Me.mnuDesignItemImageVisible.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemImageVisibleShowAll, Me.mnuDesignItemImageVisibleHideAll})
        Me.mnuDesignItemImageVisible.Name = "mnuDesignItemImageVisible"
        resources.ApplyResources(Me.mnuDesignItemImageVisible, "mnuDesignItemImageVisible")
        '
        'mnuDesignItemImageVisibleShowAll
        '
        Me.mnuDesignItemImageVisibleShowAll.Name = "mnuDesignItemImageVisibleShowAll"
        resources.ApplyResources(Me.mnuDesignItemImageVisibleShowAll, "mnuDesignItemImageVisibleShowAll")
        '
        'mnuDesignItemImageVisibleHideAll
        '
        Me.mnuDesignItemImageVisibleHideAll.Name = "mnuDesignItemImageVisibleHideAll"
        resources.ApplyResources(Me.mnuDesignItemImageVisibleHideAll, "mnuDesignItemImageVisibleHideAll")
        '
        'ToolStripMenuItem82
        '
        Me.ToolStripMenuItem82.Name = "ToolStripMenuItem82"
        resources.ApplyResources(Me.ToolStripMenuItem82, "ToolStripMenuItem82")
        '
        'mnuDesignItemImageView
        '
        resources.ApplyResources(Me.mnuDesignItemImageView, "mnuDesignItemImageView")
        Me.mnuDesignItemImageView.Name = "mnuDesignItemImageView"
        '
        'mnuDesignItemSketch
        '
        Me.mnuDesignItemSketch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSketchEdit, Me.ToolStripMenuItem78, Me.mnuDesignItemSketchMorphing, Me.ToolStripMenuItem80, Me.mnuDesignItemSketchVisible, Me.ToolStripMenuItem86, Me.mnuDesignItemSketchView})
        Me.mnuDesignItemSketch.Name = "mnuDesignItemSketch"
        resources.ApplyResources(Me.mnuDesignItemSketch, "mnuDesignItemSketch")
        '
        'mnuDesignItemSketchEdit
        '
        resources.ApplyResources(Me.mnuDesignItemSketchEdit, "mnuDesignItemSketchEdit")
        Me.mnuDesignItemSketchEdit.Name = "mnuDesignItemSketchEdit"
        '
        'ToolStripMenuItem78
        '
        Me.ToolStripMenuItem78.Name = "ToolStripMenuItem78"
        resources.ApplyResources(Me.ToolStripMenuItem78, "ToolStripMenuItem78")
        '
        'mnuDesignItemSketchMorphing
        '
        Me.mnuDesignItemSketchMorphing.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSketchMorphingDisabled, Me.ToolStripMenuItem81, Me.mnuDesignItemSketchMorphingEnableAll, Me.mnuDesignItemSketchMorphingDisableAll})
        Me.mnuDesignItemSketchMorphing.Name = "mnuDesignItemSketchMorphing"
        resources.ApplyResources(Me.mnuDesignItemSketchMorphing, "mnuDesignItemSketchMorphing")
        '
        'mnuDesignItemSketchMorphingDisabled
        '
        Me.mnuDesignItemSketchMorphingDisabled.Name = "mnuDesignItemSketchMorphingDisabled"
        resources.ApplyResources(Me.mnuDesignItemSketchMorphingDisabled, "mnuDesignItemSketchMorphingDisabled")
        '
        'ToolStripMenuItem81
        '
        Me.ToolStripMenuItem81.Name = "ToolStripMenuItem81"
        resources.ApplyResources(Me.ToolStripMenuItem81, "ToolStripMenuItem81")
        '
        'mnuDesignItemSketchMorphingEnableAll
        '
        Me.mnuDesignItemSketchMorphingEnableAll.Name = "mnuDesignItemSketchMorphingEnableAll"
        resources.ApplyResources(Me.mnuDesignItemSketchMorphingEnableAll, "mnuDesignItemSketchMorphingEnableAll")
        '
        'mnuDesignItemSketchMorphingDisableAll
        '
        Me.mnuDesignItemSketchMorphingDisableAll.Name = "mnuDesignItemSketchMorphingDisableAll"
        resources.ApplyResources(Me.mnuDesignItemSketchMorphingDisableAll, "mnuDesignItemSketchMorphingDisableAll")
        '
        'ToolStripMenuItem80
        '
        Me.ToolStripMenuItem80.Name = "ToolStripMenuItem80"
        resources.ApplyResources(Me.ToolStripMenuItem80, "ToolStripMenuItem80")
        '
        'mnuDesignItemSketchVisible
        '
        Me.mnuDesignItemSketchVisible.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSketchVisibleShowAll, Me.mnuDesignItemSketchVisibleHideAll})
        Me.mnuDesignItemSketchVisible.Name = "mnuDesignItemSketchVisible"
        resources.ApplyResources(Me.mnuDesignItemSketchVisible, "mnuDesignItemSketchVisible")
        '
        'mnuDesignItemSketchVisibleShowAll
        '
        Me.mnuDesignItemSketchVisibleShowAll.Name = "mnuDesignItemSketchVisibleShowAll"
        resources.ApplyResources(Me.mnuDesignItemSketchVisibleShowAll, "mnuDesignItemSketchVisibleShowAll")
        '
        'mnuDesignItemSketchVisibleHideAll
        '
        Me.mnuDesignItemSketchVisibleHideAll.Name = "mnuDesignItemSketchVisibleHideAll"
        resources.ApplyResources(Me.mnuDesignItemSketchVisibleHideAll, "mnuDesignItemSketchVisibleHideAll")
        '
        'ToolStripMenuItem86
        '
        Me.ToolStripMenuItem86.Name = "ToolStripMenuItem86"
        resources.ApplyResources(Me.ToolStripMenuItem86, "ToolStripMenuItem86")
        '
        'mnuDesignItemSketchView
        '
        resources.ApplyResources(Me.mnuDesignItemSketchView, "mnuDesignItemSketchView")
        Me.mnuDesignItemSketchView.Name = "mnuDesignItemSketchView"
        '
        'mnuDesignItemLegend
        '
        Me.mnuDesignItemLegend.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemLegendAddTo})
        Me.mnuDesignItemLegend.Name = "mnuDesignItemLegend"
        resources.ApplyResources(Me.mnuDesignItemLegend, "mnuDesignItemLegend")
        '
        'mnuDesignItemLegendAddTo
        '
        Me.mnuDesignItemLegendAddTo.Name = "mnuDesignItemLegendAddTo"
        resources.ApplyResources(Me.mnuDesignItemLegendAddTo, "mnuDesignItemLegendAddTo")
        '
        'mnuDesignItemBar0
        '
        Me.mnuDesignItemBar0.Name = "mnuDesignItemBar0"
        resources.ApplyResources(Me.mnuDesignItemBar0, "mnuDesignItemBar0")
        '
        'mnuDesignItemCut
        '
        resources.ApplyResources(Me.mnuDesignItemCut, "mnuDesignItemCut")
        Me.mnuDesignItemCut.Name = "mnuDesignItemCut"
        '
        'mnuDesignItemCopy
        '
        resources.ApplyResources(Me.mnuDesignItemCopy, "mnuDesignItemCopy")
        Me.mnuDesignItemCopy.Name = "mnuDesignItemCopy"
        '
        'mnuDesignItemPaste
        '
        resources.ApplyResources(Me.mnuDesignItemPaste, "mnuDesignItemPaste")
        Me.mnuDesignItemPaste.Name = "mnuDesignItemPaste"
        '
        'mnuDesignItemPasteSpecial
        '
        Me.mnuDesignItemPasteSpecial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemPasteSpecialPen, Me.mnuDesignItemPasteSpecialBrush})
        resources.ApplyResources(Me.mnuDesignItemPasteSpecial, "mnuDesignItemPasteSpecial")
        Me.mnuDesignItemPasteSpecial.Name = "mnuDesignItemPasteSpecial"
        '
        'mnuDesignItemPasteSpecialPen
        '
        Me.mnuDesignItemPasteSpecialPen.Name = "mnuDesignItemPasteSpecialPen"
        resources.ApplyResources(Me.mnuDesignItemPasteSpecialPen, "mnuDesignItemPasteSpecialPen")
        '
        'mnuDesignItemPasteSpecialBrush
        '
        Me.mnuDesignItemPasteSpecialBrush.Name = "mnuDesignItemPasteSpecialBrush"
        resources.ApplyResources(Me.mnuDesignItemPasteSpecialBrush, "mnuDesignItemPasteSpecialBrush")
        '
        'mnuDesignItemDelete
        '
        resources.ApplyResources(Me.mnuDesignItemDelete, "mnuDesignItemDelete")
        Me.mnuDesignItemDelete.Name = "mnuDesignItemDelete"
        '
        'mnuDesignItemBar2
        '
        Me.mnuDesignItemBar2.Name = "mnuDesignItemBar2"
        resources.ApplyResources(Me.mnuDesignItemBar2, "mnuDesignItemBar2")
        '
        'mnuDesignItemItemUnder
        '
        Me.mnuDesignItemItemUnder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemItemUnderItems})
        Me.mnuDesignItemItemUnder.Name = "mnuDesignItemItemUnder"
        resources.ApplyResources(Me.mnuDesignItemItemUnder, "mnuDesignItemItemUnder")
        '
        'mnuDesignItemItemUnderItems
        '
        Me.mnuDesignItemItemUnderItems.Name = "mnuDesignItemItemUnderItems"
        resources.ApplyResources(Me.mnuDesignItemItemUnderItems, "mnuDesignItemItemUnderItems")
        '
        'mnuDesignItemItemBar8
        '
        Me.mnuDesignItemItemBar8.Name = "mnuDesignItemItemBar8"
        resources.ApplyResources(Me.mnuDesignItemItemBar8, "mnuDesignItemItemBar8")
        '
        'mnuDesignItemSendToBottom
        '
        resources.ApplyResources(Me.mnuDesignItemSendToBottom, "mnuDesignItemSendToBottom")
        Me.mnuDesignItemSendToBottom.Name = "mnuDesignItemSendToBottom"
        '
        'mnuDesignItemSendBehind
        '
        resources.ApplyResources(Me.mnuDesignItemSendBehind, "mnuDesignItemSendBehind")
        Me.mnuDesignItemSendBehind.Name = "mnuDesignItemSendBehind"
        '
        'mnuDesignItemBringAhead
        '
        resources.ApplyResources(Me.mnuDesignItemBringAhead, "mnuDesignItemBringAhead")
        Me.mnuDesignItemBringAhead.Name = "mnuDesignItemBringAhead"
        '
        'mnuDesignItemBringOnTop
        '
        resources.ApplyResources(Me.mnuDesignItemBringOnTop, "mnuDesignItemBringOnTop")
        Me.mnuDesignItemBringOnTop.Name = "mnuDesignItemBringOnTop"
        '
        'mnuDesignItemBar3
        '
        Me.mnuDesignItemBar3.Name = "mnuDesignItemBar3"
        resources.ApplyResources(Me.mnuDesignItemBar3, "mnuDesignItemBar3")
        '
        'mnuDesignItemSendCopyTo
        '
        Me.mnuDesignItemSendCopyTo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemSendCopyTo0, Me.mnuDesignItemSendCopyTo1})
        Me.mnuDesignItemSendCopyTo.Name = "mnuDesignItemSendCopyTo"
        resources.ApplyResources(Me.mnuDesignItemSendCopyTo, "mnuDesignItemSendCopyTo")
        '
        'mnuDesignItemSendCopyTo0
        '
        Me.mnuDesignItemSendCopyTo0.Name = "mnuDesignItemSendCopyTo0"
        resources.ApplyResources(Me.mnuDesignItemSendCopyTo0, "mnuDesignItemSendCopyTo0")
        '
        'mnuDesignItemSendCopyTo1
        '
        Me.mnuDesignItemSendCopyTo1.Name = "mnuDesignItemSendCopyTo1"
        resources.ApplyResources(Me.mnuDesignItemSendCopyTo1, "mnuDesignItemSendCopyTo1")
        '
        'mnuDesignItemBar8
        '
        Me.mnuDesignItemBar8.Name = "mnuDesignItemBar8"
        resources.ApplyResources(Me.mnuDesignItemBar8, "mnuDesignItemBar8")
        '
        'mnuDesignItemChangeTo
        '
        Me.mnuDesignItemChangeTo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemChangeTo4, Me.ToolStripMenuItem61, Me.mnuDesignItemChangeTo1, Me.mnuDesignItemChangeTo2, Me.ToolStripMenuItem13, Me.mnuDesignItemChangeTo3})
        Me.mnuDesignItemChangeTo.Name = "mnuDesignItemChangeTo"
        resources.ApplyResources(Me.mnuDesignItemChangeTo, "mnuDesignItemChangeTo")
        '
        'mnuDesignItemChangeTo4
        '
        Me.mnuDesignItemChangeTo4.Name = "mnuDesignItemChangeTo4"
        resources.ApplyResources(Me.mnuDesignItemChangeTo4, "mnuDesignItemChangeTo4")
        '
        'ToolStripMenuItem61
        '
        Me.ToolStripMenuItem61.Name = "ToolStripMenuItem61"
        resources.ApplyResources(Me.ToolStripMenuItem61, "ToolStripMenuItem61")
        '
        'mnuDesignItemChangeTo1
        '
        Me.mnuDesignItemChangeTo1.Name = "mnuDesignItemChangeTo1"
        resources.ApplyResources(Me.mnuDesignItemChangeTo1, "mnuDesignItemChangeTo1")
        '
        'mnuDesignItemChangeTo2
        '
        Me.mnuDesignItemChangeTo2.Name = "mnuDesignItemChangeTo2"
        resources.ApplyResources(Me.mnuDesignItemChangeTo2, "mnuDesignItemChangeTo2")
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        resources.ApplyResources(Me.ToolStripMenuItem13, "ToolStripMenuItem13")
        '
        'mnuDesignItemChangeTo3
        '
        Me.mnuDesignItemChangeTo3.Name = "mnuDesignItemChangeTo3"
        resources.ApplyResources(Me.mnuDesignItemChangeTo3, "mnuDesignItemChangeTo3")
        '
        'mnuDesignItemFlip
        '
        Me.mnuDesignItemFlip.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemFlipH, Me.mnuDesignItemFlipV})
        Me.mnuDesignItemFlip.Name = "mnuDesignItemFlip"
        resources.ApplyResources(Me.mnuDesignItemFlip, "mnuDesignItemFlip")
        '
        'mnuDesignItemFlipH
        '
        resources.ApplyResources(Me.mnuDesignItemFlipH, "mnuDesignItemFlipH")
        Me.mnuDesignItemFlipH.Name = "mnuDesignItemFlipH"
        '
        'mnuDesignItemFlipV
        '
        resources.ApplyResources(Me.mnuDesignItemFlipV, "mnuDesignItemFlipV")
        Me.mnuDesignItemFlipV.Name = "mnuDesignItemFlipV"
        '
        'mnuDesignItemRotate
        '
        Me.mnuDesignItemRotate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemRotate15, Me.mnuDesignItemRotate45, Me.mnuDesignItemRotate90, Me.mnuDesignItemRotate180, Me.mnuDesignItemRotate270})
        Me.mnuDesignItemRotate.Name = "mnuDesignItemRotate"
        resources.ApplyResources(Me.mnuDesignItemRotate, "mnuDesignItemRotate")
        '
        'mnuDesignItemRotate15
        '
        Me.mnuDesignItemRotate15.Name = "mnuDesignItemRotate15"
        resources.ApplyResources(Me.mnuDesignItemRotate15, "mnuDesignItemRotate15")
        '
        'mnuDesignItemRotate45
        '
        Me.mnuDesignItemRotate45.Name = "mnuDesignItemRotate45"
        resources.ApplyResources(Me.mnuDesignItemRotate45, "mnuDesignItemRotate45")
        '
        'mnuDesignItemRotate90
        '
        Me.mnuDesignItemRotate90.Name = "mnuDesignItemRotate90"
        resources.ApplyResources(Me.mnuDesignItemRotate90, "mnuDesignItemRotate90")
        '
        'mnuDesignItemRotate180
        '
        Me.mnuDesignItemRotate180.Name = "mnuDesignItemRotate180"
        resources.ApplyResources(Me.mnuDesignItemRotate180, "mnuDesignItemRotate180")
        '
        'mnuDesignItemRotate270
        '
        Me.mnuDesignItemRotate270.Name = "mnuDesignItemRotate270"
        resources.ApplyResources(Me.mnuDesignItemRotate270, "mnuDesignItemRotate270")
        '
        'mnuDesignItemBar4
        '
        Me.mnuDesignItemBar4.Name = "mnuDesignItemBar4"
        resources.ApplyResources(Me.mnuDesignItemBar4, "mnuDesignItemBar4")
        '
        'mnuDesignItemPlot
        '
        Me.mnuDesignItemPlot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemPlotSetCaveBranch, Me.ToolStripMenuItem69, Me.mnuDesignItemPlotBindSegment, Me.ToolStripMenuItem24, Me.mnuDesignItemPlotLockAll, Me.mnuDesignItemPlotUnlockAll})
        Me.mnuDesignItemPlot.Name = "mnuDesignItemPlot"
        resources.ApplyResources(Me.mnuDesignItemPlot, "mnuDesignItemPlot")
        '
        'mnuDesignItemPlotSetCaveBranch
        '
        resources.ApplyResources(Me.mnuDesignItemPlotSetCaveBranch, "mnuDesignItemPlotSetCaveBranch")
        Me.mnuDesignItemPlotSetCaveBranch.Name = "mnuDesignItemPlotSetCaveBranch"
        '
        'ToolStripMenuItem69
        '
        Me.ToolStripMenuItem69.Name = "ToolStripMenuItem69"
        resources.ApplyResources(Me.ToolStripMenuItem69, "ToolStripMenuItem69")
        '
        'mnuDesignItemPlotBindSegment
        '
        resources.ApplyResources(Me.mnuDesignItemPlotBindSegment, "mnuDesignItemPlotBindSegment")
        Me.mnuDesignItemPlotBindSegment.Name = "mnuDesignItemPlotBindSegment"
        '
        'ToolStripMenuItem24
        '
        Me.ToolStripMenuItem24.Name = "ToolStripMenuItem24"
        resources.ApplyResources(Me.ToolStripMenuItem24, "ToolStripMenuItem24")
        '
        'mnuDesignItemPlotLockAll
        '
        resources.ApplyResources(Me.mnuDesignItemPlotLockAll, "mnuDesignItemPlotLockAll")
        Me.mnuDesignItemPlotLockAll.Name = "mnuDesignItemPlotLockAll"
        '
        'mnuDesignItemPlotUnlockAll
        '
        resources.ApplyResources(Me.mnuDesignItemPlotUnlockAll, "mnuDesignItemPlotUnlockAll")
        Me.mnuDesignItemPlotUnlockAll.Name = "mnuDesignItemPlotUnlockAll"
        '
        'mnuDesignItemBar5
        '
        Me.mnuDesignItemBar5.Name = "mnuDesignItemBar5"
        resources.ApplyResources(Me.mnuDesignItemBar5, "mnuDesignItemBar5")
        '
        'mnuDesignItemLock
        '
        resources.ApplyResources(Me.mnuDesignItemLock, "mnuDesignItemLock")
        Me.mnuDesignItemLock.Name = "mnuDesignItemLock"
        '
        'mnuDesignItemBar6
        '
        Me.mnuDesignItemBar6.Name = "mnuDesignItemBar6"
        resources.ApplyResources(Me.mnuDesignItemBar6, "mnuDesignItemBar6")
        '
        'mnuDesignItemProperty
        '
        resources.ApplyResources(Me.mnuDesignItemProperty, "mnuDesignItemProperty")
        Me.mnuDesignItemProperty.Name = "mnuDesignItemProperty"
        '
        'mnuDesignItemHiddenInDesign
        '
        Me.mnuDesignItemHiddenInDesign.Name = "mnuDesignItemHiddenInDesign"
        resources.ApplyResources(Me.mnuDesignItemHiddenInDesign, "mnuDesignItemHiddenInDesign")
        '
        'mnuDesignItemBar7
        '
        Me.mnuDesignItemBar7.Name = "mnuDesignItemBar7"
        resources.ApplyResources(Me.mnuDesignItemBar7, "mnuDesignItemBar7")
        '
        'mnuDesignItemRefresh
        '
        Me.mnuDesignItemRefresh.Name = "mnuDesignItemRefresh"
        resources.ApplyResources(Me.mnuDesignItemRefresh, "mnuDesignItemRefresh")
        '
        'mnuDesignItemPoint
        '
        resources.ApplyResources(Me.mnuDesignItemPoint, "mnuDesignItemPoint")
        Me.mnuDesignItemPoint.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemPointAdd, Me.mnuDesignItemPointDelete, Me.mnuDesignItemPointSegmentBar, Me.mnuDesignItemPointSegmentDivide, Me.mnuDesignItemPointSegmentDivideAndJoin, Me.mnuDesignItemPointSegmentCombine, Me.mnuDesignItemPointDeleteSegment, Me.mnuDesignItemPointCloseSegment, Me.mnuDesignItemPointRevertSegment, Me.mnuDesignItemAreaFromSequenceBar, Me.mnuDesignItemAreaFromSequence, Me.mnuDesignItemPointConvertBar, Me.mnuDesignItemPointConvert, Me.mnuDesignItemPointNewFromSequenceBar, Me.mnuDesignItemPointNewFromSequence0, Me.mnuDesignItemPointNewFromSequence1, Me.mnuDesignItemPointPlotBar, Me.mnuDesignItemPointPlot, Me.ToolStripMenuItem9, Me.mnuDesignItemPointRefresh})
        Me.mnuDesignItemPoint.Name = "mnuDesignNone"
        '
        'mnuDesignItemPointAdd
        '
        resources.ApplyResources(Me.mnuDesignItemPointAdd, "mnuDesignItemPointAdd")
        Me.mnuDesignItemPointAdd.Name = "mnuDesignItemPointAdd"
        '
        'mnuDesignItemPointDelete
        '
        resources.ApplyResources(Me.mnuDesignItemPointDelete, "mnuDesignItemPointDelete")
        Me.mnuDesignItemPointDelete.Name = "mnuDesignItemPointDelete"
        '
        'mnuDesignItemPointSegmentBar
        '
        Me.mnuDesignItemPointSegmentBar.Name = "mnuDesignItemPointSegmentBar"
        resources.ApplyResources(Me.mnuDesignItemPointSegmentBar, "mnuDesignItemPointSegmentBar")
        '
        'mnuDesignItemPointSegmentDivide
        '
        Me.mnuDesignItemPointSegmentDivide.Name = "mnuDesignItemPointSegmentDivide"
        resources.ApplyResources(Me.mnuDesignItemPointSegmentDivide, "mnuDesignItemPointSegmentDivide")
        '
        'mnuDesignItemPointSegmentDivideAndJoin
        '
        resources.ApplyResources(Me.mnuDesignItemPointSegmentDivideAndJoin, "mnuDesignItemPointSegmentDivideAndJoin")
        Me.mnuDesignItemPointSegmentDivideAndJoin.Name = "mnuDesignItemPointSegmentDivideAndJoin"
        '
        'mnuDesignItemPointSegmentCombine
        '
        Me.mnuDesignItemPointSegmentCombine.Name = "mnuDesignItemPointSegmentCombine"
        resources.ApplyResources(Me.mnuDesignItemPointSegmentCombine, "mnuDesignItemPointSegmentCombine")
        '
        'mnuDesignItemPointDeleteSegment
        '
        resources.ApplyResources(Me.mnuDesignItemPointDeleteSegment, "mnuDesignItemPointDeleteSegment")
        Me.mnuDesignItemPointDeleteSegment.Name = "mnuDesignItemPointDeleteSegment"
        '
        'mnuDesignItemPointCloseSegment
        '
        Me.mnuDesignItemPointCloseSegment.Name = "mnuDesignItemPointCloseSegment"
        resources.ApplyResources(Me.mnuDesignItemPointCloseSegment, "mnuDesignItemPointCloseSegment")
        '
        'mnuDesignItemPointRevertSegment
        '
        Me.mnuDesignItemPointRevertSegment.Name = "mnuDesignItemPointRevertSegment"
        resources.ApplyResources(Me.mnuDesignItemPointRevertSegment, "mnuDesignItemPointRevertSegment")
        '
        'mnuDesignItemAreaFromSequenceBar
        '
        Me.mnuDesignItemAreaFromSequenceBar.Name = "mnuDesignItemAreaFromSequenceBar"
        resources.ApplyResources(Me.mnuDesignItemAreaFromSequenceBar, "mnuDesignItemAreaFromSequenceBar")
        '
        'mnuDesignItemAreaFromSequence
        '
        Me.mnuDesignItemAreaFromSequence.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemAreaFromSequencePanel})
        Me.mnuDesignItemAreaFromSequence.Name = "mnuDesignItemAreaFromSequence"
        resources.ApplyResources(Me.mnuDesignItemAreaFromSequence, "mnuDesignItemAreaFromSequence")
        '
        'mnuDesignItemAreaFromSequencePanel
        '
        Me.mnuDesignItemAreaFromSequencePanel.Name = "mnuDesignItemAreaFromSequencePanel"
        resources.ApplyResources(Me.mnuDesignItemAreaFromSequencePanel, "mnuDesignItemAreaFromSequencePanel")
        '
        'mnuDesignItemPointConvertBar
        '
        Me.mnuDesignItemPointConvertBar.Name = "mnuDesignItemPointConvertBar"
        resources.ApplyResources(Me.mnuDesignItemPointConvertBar, "mnuDesignItemPointConvertBar")
        '
        'mnuDesignItemPointConvert
        '
        Me.mnuDesignItemPointConvert.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemPointConvertToLines, Me.mnuDesignItemPointConvertToSpline, Me.mnuDesignItemPointConvertToBezier})
        Me.mnuDesignItemPointConvert.Name = "mnuDesignItemPointConvert"
        resources.ApplyResources(Me.mnuDesignItemPointConvert, "mnuDesignItemPointConvert")
        '
        'mnuDesignItemPointConvertToLines
        '
        Me.mnuDesignItemPointConvertToLines.Name = "mnuDesignItemPointConvertToLines"
        resources.ApplyResources(Me.mnuDesignItemPointConvertToLines, "mnuDesignItemPointConvertToLines")
        '
        'mnuDesignItemPointConvertToSpline
        '
        Me.mnuDesignItemPointConvertToSpline.Name = "mnuDesignItemPointConvertToSpline"
        resources.ApplyResources(Me.mnuDesignItemPointConvertToSpline, "mnuDesignItemPointConvertToSpline")
        '
        'mnuDesignItemPointConvertToBezier
        '
        Me.mnuDesignItemPointConvertToBezier.Name = "mnuDesignItemPointConvertToBezier"
        resources.ApplyResources(Me.mnuDesignItemPointConvertToBezier, "mnuDesignItemPointConvertToBezier")
        '
        'mnuDesignItemPointNewFromSequenceBar
        '
        Me.mnuDesignItemPointNewFromSequenceBar.Name = "mnuDesignItemPointNewFromSequenceBar"
        resources.ApplyResources(Me.mnuDesignItemPointNewFromSequenceBar, "mnuDesignItemPointNewFromSequenceBar")
        '
        'mnuDesignItemPointNewFromSequence0
        '
        Me.mnuDesignItemPointNewFromSequence0.Name = "mnuDesignItemPointNewFromSequence0"
        resources.ApplyResources(Me.mnuDesignItemPointNewFromSequence0, "mnuDesignItemPointNewFromSequence0")
        '
        'mnuDesignItemPointNewFromSequence1
        '
        Me.mnuDesignItemPointNewFromSequence1.Name = "mnuDesignItemPointNewFromSequence1"
        resources.ApplyResources(Me.mnuDesignItemPointNewFromSequence1, "mnuDesignItemPointNewFromSequence1")
        '
        'mnuDesignItemPointPlotBar
        '
        Me.mnuDesignItemPointPlotBar.Name = "mnuDesignItemPointPlotBar"
        resources.ApplyResources(Me.mnuDesignItemPointPlotBar, "mnuDesignItemPointPlotBar")
        '
        'mnuDesignItemPointPlot
        '
        Me.mnuDesignItemPointPlot.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDesignItemPointPlotLockSegment, Me.ToolStripMenuItem21, Me.mnuDesignItemPointPlotBindSegment})
        Me.mnuDesignItemPointPlot.Name = "mnuDesignItemPointPlot"
        resources.ApplyResources(Me.mnuDesignItemPointPlot, "mnuDesignItemPointPlot")
        '
        'mnuDesignItemPointPlotLockSegment
        '
        resources.ApplyResources(Me.mnuDesignItemPointPlotLockSegment, "mnuDesignItemPointPlotLockSegment")
        Me.mnuDesignItemPointPlotLockSegment.Name = "mnuDesignItemPointPlotLockSegment"
        '
        'ToolStripMenuItem21
        '
        Me.ToolStripMenuItem21.Name = "ToolStripMenuItem21"
        resources.ApplyResources(Me.ToolStripMenuItem21, "ToolStripMenuItem21")
        '
        'mnuDesignItemPointPlotBindSegment
        '
        resources.ApplyResources(Me.mnuDesignItemPointPlotBindSegment, "mnuDesignItemPointPlotBindSegment")
        Me.mnuDesignItemPointPlotBindSegment.Name = "mnuDesignItemPointPlotBindSegment"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        resources.ApplyResources(Me.ToolStripMenuItem9, "ToolStripMenuItem9")
        '
        'mnuDesignItemPointRefresh
        '
        Me.mnuDesignItemPointRefresh.Name = "mnuDesignItemPointRefresh"
        resources.ApplyResources(Me.mnuDesignItemPointRefresh, "mnuDesignItemPointRefresh")
        '
        'mnuMapDrop
        '
        resources.ApplyResources(Me.mnuMapDrop, "mnuMapDrop")
        Me.mnuMapDrop.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMapDropImage, Me.mnuMapDropSketch, Me.mnuMapDropPocketTopo, Me.mnuMapDropCaveExplorer, Me.mnuMapDropText, Me.mnuMapDropAttachment})
        Me.mnuMapDrop.Name = "mnuMapDrop"
        '
        'mnuMapDropImage
        '
        Me.mnuMapDropImage.Name = "mnuMapDropImage"
        resources.ApplyResources(Me.mnuMapDropImage, "mnuMapDropImage")
        '
        'mnuMapDropSketch
        '
        Me.mnuMapDropSketch.Name = "mnuMapDropSketch"
        resources.ApplyResources(Me.mnuMapDropSketch, "mnuMapDropSketch")
        '
        'mnuMapDropPocketTopo
        '
        Me.mnuMapDropPocketTopo.Name = "mnuMapDropPocketTopo"
        resources.ApplyResources(Me.mnuMapDropPocketTopo, "mnuMapDropPocketTopo")
        '
        'mnuMapDropCaveExplorer
        '
        Me.mnuMapDropCaveExplorer.Name = "mnuMapDropCaveExplorer"
        resources.ApplyResources(Me.mnuMapDropCaveExplorer, "mnuMapDropCaveExplorer")
        '
        'mnuMapDropText
        '
        Me.mnuMapDropText.Name = "mnuMapDropText"
        resources.ApplyResources(Me.mnuMapDropText, "mnuMapDropText")
        '
        'mnuMapDropAttachment
        '
        Me.mnuMapDropAttachment.Name = "mnuMapDropAttachment"
        resources.ApplyResources(Me.mnuMapDropAttachment, "mnuMapDropAttachment")
        '
        'mnuTray
        '
        resources.ApplyResources(Me.mnuTray, "mnuTray")
        Me.mnuTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnnuTrayShowHide, Me.ToolStripMenuItem72, Me.mnuTrayClose})
        Me.mnuTray.Name = "mnuTray"
        '
        'mnnuTrayShowHide
        '
        Me.mnnuTrayShowHide.Name = "mnnuTrayShowHide"
        resources.ApplyResources(Me.mnnuTrayShowHide, "mnnuTrayShowHide")
        '
        'ToolStripMenuItem72
        '
        Me.ToolStripMenuItem72.Name = "ToolStripMenuItem72"
        resources.ApplyResources(Me.ToolStripMenuItem72, "ToolStripMenuItem72")
        '
        'mnuTrayClose
        '
        Me.mnuTrayClose.Name = "mnuTrayClose"
        resources.ApplyResources(Me.mnuTrayClose, "mnuTrayClose")
        '
        'tmrAutosave
        '
        Me.tmrAutosave.Interval = 300000
        '
        'imlNotify
        '
        Me.imlNotify.ImageStream = CType(resources.GetObject("imlNotify.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlNotify.TransparentColor = System.Drawing.Color.Transparent
        Me.imlNotify.Images.SetKeyName(0, "warning")
        Me.imlNotify.Images.SetKeyName(1, "calculate")
        Me.imlNotify.Images.SetKeyName(2, "error")
        '
        'tmrClipboard
        '
        '
        'tmrMouseMove
        '
        Me.tmrMouseMove.Interval = 1
        '
        'imlPopup
        '
        Me.imlPopup.ImageStream = CType(resources.GetObject("imlPopup.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlPopup.TransparentColor = System.Drawing.Color.Transparent
        Me.imlPopup.Images.SetKeyName(0, "warning")
        Me.imlPopup.Images.SetKeyName(1, "calculate")
        Me.imlPopup.Images.SetKeyName(2, "error")
        '
        'ntiMain
        '
        Me.ntiMain.ContextMenuStrip = Me.mnuTray
        resources.ApplyResources(Me.ntiMain, "ntiMain")
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'bwMain
        '
        Me.bwMain.WorkerReportsProgress = True
        Me.bwMain.WorkerSupportsCancellation = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.sbMain)
        Me.Controls.Add(Me.mnuMain)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
        Me.tsMain.ContentPanel.ResumeLayout(False)
        Me.tsMain.TopToolStripPanel.ResumeLayout(False)
        Me.tsMain.TopToolStripPanel.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.pnlConsole.ResumeLayout(False)
        Me.pnlDesigner.ResumeLayout(False)
        Me.pnlDesigner.PerformLayout()
        Me.pnl3D.ResumeLayout(False)
        Me.pnlPopup.ResumeLayout(False)
        CType(Me.picPopupWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbViews.ResumeLayout(False)
        Me.tbViews.PerformLayout()
        Me.pnlData.ResumeLayout(False)
        Me.pnlData.PerformLayout()
        Me.spSegmentsAndTrigpoints.Panel1.ResumeLayout(False)
        Me.spSegmentsAndTrigpoints.Panel2.ResumeLayout(False)
        CType(Me.spSegmentsAndTrigpoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSegmentsAndTrigpoints.ResumeLayout(False)
        Me.spSegments.Panel1.ResumeLayout(False)
        Me.spSegments.Panel2.ResumeLayout(False)
        CType(Me.spSegments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spSegments.ResumeLayout(False)
        CType(Me.grdSegments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSegments.ResumeLayout(False)
        Me.pnlSegment.ResumeLayout(False)
        Me.tabSegmentProperty.ResumeLayout(False)
        Me.tabSegmentPropertyMain.ResumeLayout(False)
        Me.tabSegmentPropertyMain.PerformLayout()
        Me.pnlSegmentSurfaceProfile.ResumeLayout(False)
        Me.pnlSegmentSurfaceProfile.PerformLayout()
        Me.tabSegmentPropertyData.ResumeLayout(False)
        Me.mnuSegmentsDataProperties.ResumeLayout(False)
        Me.tabSegmentPropertyLayout.ResumeLayout(False)
        CType(Me.picSegmentColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSegmentPropertyNote.ResumeLayout(False)
        Me.tabSegmentPropertyNote.PerformLayout()
        Me.tabSegmentPropertyImage.ResumeLayout(False)
        CType(Me.tvSegmentAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuAttachments.ResumeLayout(False)
        Me.pnlSegmentFromAndTo.ResumeLayout(False)
        Me.pnlSegmentFromAndTo.PerformLayout()
        Me.pnlSegmentCaveBranches.ResumeLayout(False)
        Me.pnlSegmentCaveBranches.PerformLayout()
        Me.pnlSegmentSession.ResumeLayout(False)
        Me.spTrigPoints.Panel1.ResumeLayout(False)
        Me.spTrigPoints.Panel2.ResumeLayout(False)
        CType(Me.spTrigPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.spTrigPoints.ResumeLayout(False)
        CType(Me.grdTrigPoints, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuTrigPoints.ResumeLayout(False)
        Me.pnlTrigPoint.ResumeLayout(False)
        Me.tabTrigpointProperty.ResumeLayout(False)
        Me.tabTrigpointMain.ResumeLayout(False)
        Me.tabTrigpointMain.PerformLayout()
        CType(Me.grdTrigPointAliases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuAliases.ResumeLayout(False)
        Me.tabTrigpointPropertyData.ResumeLayout(False)
        Me.mnuTrigpointDataProperties.ResumeLayout(False)
        Me.tabTrigpointLayout.ResumeLayout(False)
        Me.tabTrigpointLayout.PerformLayout()
        CType(Me.txtTrigPointLabelDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picTrigpointFontColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTrigpointConnections.ResumeLayout(False)
        CType(Me.grdTrigpointConnections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTrigpointCoordinate.ResumeLayout(False)
        Me.tabTrigpointCoordinate.PerformLayout()
        Me.pnlTrigpointCoordinateWGS84.ResumeLayout(False)
        Me.pnlTrigpointCoordinateWGS84.PerformLayout()
        Me.pnlTrigpointCoordinateUTM.ResumeLayout(False)
        Me.pnlTrigpointCoordinateUTM.PerformLayout()
        Me.tabTrigpointNote.ResumeLayout(False)
        Me.tabTrigpointNote.PerformLayout()
        Me.pnlTrigpointName.ResumeLayout(False)
        Me.pnlTrigpointName.PerformLayout()
        Me.tbSegmentsAndTrigpoints.ResumeLayout(False)
        Me.tbSegmentsAndTrigpoints.PerformLayout()
        CType(Me.trkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlObjectLayers.ResumeLayout(False)
        CType(Me.tvLayers2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuLayersAndItems.ResumeLayout(False)
        CType(Me.piclayerItemPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProperties.ResumeLayout(False)
        Me.tabObjectProp.ResumeLayout(False)
        Me.tabObjectPropDesign.ResumeLayout(False)
        Me.tblDesignProp.ResumeLayout(False)
        Me.pnlDesignSize.ResumeLayout(False)
        Me.pnlDesignSize.PerformLayout()
        CType(Me.txtDesignScaleHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignScaleWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDesignPosition.ResumeLayout(False)
        Me.pnlDesignPosition.PerformLayout()
        Me.pnlDesignRotation.ResumeLayout(False)
        Me.pnlDesignRotation.PerformLayout()
        Me.pnlDesignStyle.ResumeLayout(False)
        Me.pnlDesignStyle.PerformLayout()
        Me.pnlDesignCombineColorMode.ResumeLayout(False)
        Me.pnlDesignCombineColorMode.PerformLayout()
        Me.pnlDesignSnapToGrid.ResumeLayout(False)
        Me.pnlDesignSnapToGrid.PerformLayout()
        CType(Me.txtDesignSnapToGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDesignPlotContainer.ResumeLayout(False)
        Me.pnlDesignPlotContainer.PerformLayout()
        Me.pnlDesignPlot.ResumeLayout(False)
        Me.pnlDesignPlot.PerformLayout()
        Me.pnlDesignSurfaceContainer.ResumeLayout(False)
        Me.pnlDesignSurfaceContainer.PerformLayout()
        Me.pnlDesignSurface.ResumeLayout(False)
        Me.mnuDesignSurfaceLayers.ResumeLayout(False)
        Me.pnlDesignSurfaceProfile.ResumeLayout(False)
        Me.pnlDesignSurfaceProfile.PerformLayout()
        Me.pnlDesignPrintOrExportAreaContainer.ResumeLayout(False)
        Me.tabObjectPropMain.ResumeLayout(False)
        Me.tblObjectProp.ResumeLayout(False)
        Me.pnlPropConvertTo.ResumeLayout(False)
        Me.pnlPropConvertTo.PerformLayout()
        Me.pnlPropClipping.ResumeLayout(False)
        Me.pnlPropClipping.PerformLayout()
        Me.pnlPropShape.ResumeLayout(False)
        Me.pnlPropShape.PerformLayout()
        Me.pnlPropShapeSequences.ResumeLayout(False)
        Me.pnlPropShapeSequences.PerformLayout()
        CType(Me.txtPropLinePointReductionFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropSign.ResumeLayout(False)
        Me.pnlPropSign.PerformLayout()
        Me.pnlPropImage.ResumeLayout(False)
        Me.pnlPropImage.PerformLayout()
        CType(Me.txtPropImageScaleFree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropInfo.ResumeLayout(False)
        Me.pnlPropInfo.PerformLayout()
        Me.pnlPropCaveBranches.ResumeLayout(False)
        Me.pnlPropPen.ResumeLayout(False)
        Me.tblPropPen.ResumeLayout(False)
        Me.pnlPropPenGeneric.ResumeLayout(False)
        Me.pnlPropPenGeneric.PerformLayout()
        Me.pnlPropPenCustom.ResumeLayout(False)
        Me.pnlPropPenCustom.PerformLayout()
        CType(Me.txtPropPenDecorationScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPenDecorationSpacePercentage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropPenColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropSize.ResumeLayout(False)
        Me.pnlPropSize.PerformLayout()
        CType(Me.txtPropScaleHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropScaleWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropPosition.ResumeLayout(False)
        Me.pnlPropPosition.PerformLayout()
        Me.pnlPropPositionSubPanel1.ResumeLayout(False)
        Me.pnlPropRotation.ResumeLayout(False)
        Me.pnlPropRotation.PerformLayout()
        Me.pnlPropLineType.ResumeLayout(False)
        Me.pnlPropLineType.PerformLayout()
        Me.pnlPropBrush.ResumeLayout(False)
        Me.tblPropBrush.ResumeLayout(False)
        Me.pnlPropBrushGeneric.ResumeLayout(False)
        Me.pnlPropBrushGeneric.PerformLayout()
        Me.pnlPropBrushCustom.ResumeLayout(False)
        Me.pnlPropBrushCustom.PerformLayout()
        CType(Me.picPropBrushAlternativeBrushColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropBrushColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropBrushClipartImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartZoomFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropBrushClipartDensity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropSegmentBinding.ResumeLayout(False)
        Me.pnlPropSegmentBinding.PerformLayout()
        Me.pnlPropSegmentsBinding.ResumeLayout(False)
        Me.pnlPropSegmentsBinding.PerformLayout()
        Me.pnlPropText.ResumeLayout(False)
        Me.tblPropText.ResumeLayout(False)
        Me.pnlPropTextFont.ResumeLayout(False)
        Me.pnlPropTextFont.PerformLayout()
        CType(Me.picPropFontColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropTextStyle.ResumeLayout(False)
        Me.pnlPropTextStyle.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlPropCrossSection.ResumeLayout(False)
        Me.pnlPropCrossSection.PerformLayout()
        CType(Me.txtPropCrossSectionHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileTextDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropQuota.ResumeLayout(False)
        Me.pnlPropQuota.PerformLayout()
        Me.pnlPropSketch.ResumeLayout(False)
        Me.pnlPropSketch.PerformLayout()
        CType(Me.picPropSketch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropMergeMode.ResumeLayout(False)
        Me.pnlPropMergeMode.PerformLayout()
        Me.pnlPropTransparency.ResumeLayout(False)
        Me.pnlPropTransparency.PerformLayout()
        CType(Me.txtPropTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropObjectsBinding.ResumeLayout(False)
        Me.pnlPropObjectsBinding.PerformLayout()
        Me.pnlPropPointsSequences.ResumeLayout(False)
        Me.pnlPropPointsSequences.PerformLayout()
        Me.pnlPropSequenceLineType.ResumeLayout(False)
        Me.pnlPropSequenceLineType.PerformLayout()
        Me.pnlPropProp.ResumeLayout(False)
        Me.pnlPropProp.PerformLayout()
        Me.pnlPropItems.ResumeLayout(False)
        Me.pnlPropItems.PerformLayout()
        Me.pnlPropPopup.ResumeLayout(False)
        CType(Me.picPropPopupWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropProfileSplayBorder.ResumeLayout(False)
        Me.pnlPropProfileSplayBorder.PerformLayout()
        CType(Me.txtPropProfileSplayNegInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayNegInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayPosInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropProfileProjectionSchema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropPlanSplayBorder.ResumeLayout(False)
        Me.pnlPropPlanSplayBorder.PerformLayout()
        CType(Me.txtPropPlanSplayInclinationRangeMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayInclinationRangeMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayPlanDeltaZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropPlanSplayMaxVariationDelta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropPlanProjectionSchema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropDataProperties.ResumeLayout(False)
        Me.pnlPropDataProperties.PerformLayout()
        Me.mnuDesignDataProperties.ResumeLayout(False)
        Me.pnlPropCrossSectionSplayBorder.ResumeLayout(False)
        Me.pnlPropCrossSectionSplayBorder.PerformLayout()
        CType(Me.txtPropCrossSectionSplayProjectionVerticalAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPropCrossSectionProjectionSchema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropSegmentInfo.ResumeLayout(False)
        Me.pnlPropSegmentInfo.PerformLayout()
        Me.mnuSegmentInfo.ResumeLayout(False)
        Me.pnlPropTrigpointInfo.ResumeLayout(False)
        Me.pnlPropTrigpointInfo.PerformLayout()
        Me.mnuTrigpointInfo.ResumeLayout(False)
        Me.pnlPropCrossSectionMarker.ResumeLayout(False)
        Me.pnlPropCrossSectionMarker.PerformLayout()
        CType(Me.txtPropCrossSectionMarkerDH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerLW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerRW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerUH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerLabelDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerDeltaAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionMarkerD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropTrigpointsDistances.ResumeLayout(False)
        Me.pnlPropTrigpointsDistances.PerformLayout()
        Me.pnlPropVisibility.ResumeLayout(False)
        Me.pnlPropVisibility.PerformLayout()
        Me.pnlPropAttachment.ResumeLayout(False)
        Me.pnlPropAttachment.PerformLayout()
        CType(Me.picPropAttachmentPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPropLegend.ResumeLayout(False)
        Me.pnlPropScale.ResumeLayout(False)
        Me.pnlPropCompass.ResumeLayout(False)
        Me.tabObjectProp3D.ResumeLayout(False)
        Me.tbl3DProp.ResumeLayout(False)
        Me.pnl3DMain.ResumeLayout(False)
        Me.pnl3DMain.PerformLayout()
        CType(Me.txt3DSurfaceElevationAmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl3DPlotContainer.ResumeLayout(False)
        Me.pnl3DPlotContainer.PerformLayout()
        Me.pnl3dPlotModel.ResumeLayout(False)
        Me.pnl3dPlotModel.PerformLayout()
        Me.pnl3DPlot.ResumeLayout(False)
        Me.pnl3DPlot.PerformLayout()
        Me.pnl3DSurfaceContainer.ResumeLayout(False)
        Me.pnl3DSurfaceContainer.PerformLayout()
        Me.pnl3DSurface.ResumeLayout(False)
        Me.pnl3DSurface.PerformLayout()
        CType(Me.txt3DSurfaceTransparency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbWorkspaces.ResumeLayout(False)
        Me.tbWorkspaces.PerformLayout()
        Me.tbPens.ResumeLayout(False)
        Me.tbPens.PerformLayout()
        Me.tbLayers.ResumeLayout(False)
        Me.tbLayers.PerformLayout()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.tbView.PerformLayout()
        Me.sbMain.ResumeLayout(False)
        Me.sbMain.PerformLayout()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.mnuDesignNone.ResumeLayout(False)
        Me.mnuDesignItem.ResumeLayout(False)
        Me.mnuDesignItemPoint.ResumeLayout(False)
        Me.mnuMapDrop.ResumeLayout(False)
        Me.mnuTray.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStripContainer
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents cboSegmentFrom As System.Windows.Forms.ComboBox
    Friend WithEvents cboSegmentTo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSegmentTo As System.Windows.Forms.Label
    Friend WithEvents lblSegmentFrom As System.Windows.Forms.Label
    Friend WithEvents txtSegmentDistance As System.Windows.Forms.TextBox
    Friend WithEvents txtSegmentInclination As System.Windows.Forms.TextBox
    Friend WithEvents chkSegmentInverted As System.Windows.Forms.CheckBox
    Friend WithEvents txtSegmentBearing As System.Windows.Forms.TextBox
    Friend WithEvents txtSegmentUp As System.Windows.Forms.TextBox
    Friend WithEvents txtSegmentRight As System.Windows.Forms.TextBox
    Friend WithEvents txtSegmentLeft As System.Windows.Forms.TextBox
    Friend WithEvents txtSegmentDown As System.Windows.Forms.TextBox
    Friend WithEvents lblSegmentDx As System.Windows.Forms.Label
    Friend WithEvents lblSegmentDistance As System.Windows.Forms.Label
    Friend WithEvents lblSegmentSx As System.Windows.Forms.Label
    Friend WithEvents lblSegmentInclination As System.Windows.Forms.Label
    Friend WithEvents lblSegmentBottom As System.Windows.Forms.Label
    Friend WithEvents lblSegmentBearing As System.Windows.Forms.Label
    Friend WithEvents lblSegmentTop As System.Windows.Forms.Label
    Friend WithEvents cmdSegmentColorReset As System.Windows.Forms.Button
    Friend WithEvents cmdSegmentColorChange As System.Windows.Forms.Button
    Friend WithEvents lblSegmentColor As System.Windows.Forms.Label
    Friend WithEvents picSegmentColor As System.Windows.Forms.PictureBox
    Friend WithEvents tabSegmentProperty As System.Windows.Forms.TabControl
    Friend WithEvents tabSegmentPropertyMain As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCoordinateGetFromGPS As System.Windows.Forms.Button
    Friend WithEvents lblCoordinateGeo As System.Windows.Forms.Label
    Friend WithEvents cboTrigpointCoordinateGeo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoordinateFormat As System.Windows.Forms.Label
    Friend WithEvents txtTrigpointCoordinateLong As System.Windows.Forms.TextBox
    Friend WithEvents txtTrigpointCoordinateLat As System.Windows.Forms.TextBox
    Friend WithEvents lblCoordinateLong As System.Windows.Forms.Label
    Friend WithEvents cboTrigpointCoordinateFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoordinateLat As System.Windows.Forms.Label
    Friend WithEvents lblTrigpointCoordinateGeo As System.Windows.Forms.Label
    Friend WithEvents lblTrigpointCoordinateFormat As System.Windows.Forms.Label
    Friend WithEvents lblTrigpointCoordinateLong As System.Windows.Forms.Label
    Friend WithEvents lblTrigpointCoordinateLat As System.Windows.Forms.Label
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents tabSegmentPropertyNote As System.Windows.Forms.TabPage
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileSaveAs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewProfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents trkZoom As System.Windows.Forms.TrackBar
    Friend WithEvents btnSurveyNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSurveyOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSurveySave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSegmentAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSegmentDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZooms As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnZoomsCenter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZooms10m As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnZooms50m As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnZooms100m As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSegmentNote As System.Windows.Forms.TextBox
    Friend WithEvents mnuFileProp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbLayers As System.Windows.Forms.ToolStrip
    Friend WithEvents tbDesign As System.Windows.Forms.ToolStrip
    Friend WithEvents btnLayer_Base As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnLayer_Soil As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLayer_Water As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLayer_Rocks As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLayer_TerrainLevel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLayer_Borders As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLayer_Signs As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDesignNone As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesignNoneRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItem As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesignItemDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPoint As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesignItemPointDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointSegmentBar As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPointSegmentDivide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointPlotBar As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPointRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picMap As System.Windows.Forms.PictureBox
    Friend WithEvents mnuDesignItemPointDeleteSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPointAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointSegmentCombine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemRotate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemRotate90 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemRotate180 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemRotate270 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSendToBottom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSendBehind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBringAhead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBringOnTop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointPlot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointPlotLockSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointPlotBindSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPlot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPlotLockAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPlotUnlockAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPlotBindSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSegmentsAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewPlot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotSegments As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewFieldData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemLock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemImageRescale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageRescale90 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageRescale50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageResizeMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageResizeMode0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageResizeMode1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar0 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemImageRealSize As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageRealSizeImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemImageRealSize100 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageRealSize250 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageRealSize500 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemGeneric As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemGenericCombine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemGenericDivide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemGenericReorderSequence As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemRotate15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemRotate45 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSegmentCaveList As cCaveInfoCombobox
    Friend WithEvents lblSegmentCave As System.Windows.Forms.Label
    Friend WithEvents mnuSegmentsReplicateData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewObjectProp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabObjectProp As System.Windows.Forms.TabControl
    Friend WithEvents tabObjectPropMain As System.Windows.Forms.TabPage
    Friend WithEvents pnlPropInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlPropSize As System.Windows.Forms.Panel
    Friend WithEvents txtPropWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtPropHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblPropWidthUM As System.Windows.Forms.Label
    Friend WithEvents lblPropHeightUM As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlPropPosition As System.Windows.Forms.Panel
    Friend WithEvents cmdPropMoveRight As System.Windows.Forms.Button
    Friend WithEvents cmdPropMoveBottom As System.Windows.Forms.Button
    Friend WithEvents cmdPropMoveLeft As System.Windows.Forms.Button
    Friend WithEvents cmdPropMoveTop As System.Windows.Forms.Button
    Friend WithEvents txtPropLeft As System.Windows.Forms.TextBox
    Friend WithEvents txtPropTop As System.Windows.Forms.TextBox
    Friend WithEvents lblPropLeftUM As System.Windows.Forms.Label
    Friend WithEvents lblPropTopUM As System.Windows.Forms.Label
    Friend WithEvents lblPropPosition As System.Windows.Forms.Label
    Friend WithEvents pnlPropPen As System.Windows.Forms.Panel
    Friend WithEvents cboPropPenPattern As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropPenPattern As System.Windows.Forms.Label
    Friend WithEvents cmdPropPenColorBrowse As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPropPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlPropBrush As System.Windows.Forms.Panel
    Friend WithEvents cboPropBrushPattern As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPropBrushColor As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblpropbrushcolor As System.Windows.Forms.Label
    Friend WithEvents picPropPenColor As System.Windows.Forms.PictureBox
    Friend WithEvents picPropBrushColor As System.Windows.Forms.PictureBox
    Friend WithEvents cboPropPenStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboPropPenDecoration As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboPropPenDecorationAlignment As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboPropBrushHatch As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmdPropBringAhead As System.Windows.Forms.Button
    Friend WithEvents cmdPropSendBehind As System.Windows.Forms.Button
    Friend WithEvents cmdPropSendToBottom As System.Windows.Forms.Button
    Friend WithEvents cmdPropBringOnTop As System.Windows.Forms.Button
    Friend WithEvents mnuDesignItemPointCloseSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemGenericCloseAllSequences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tblObjectProp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPropImage As System.Windows.Forms.Panel
    Friend WithEvents cboPropImageResizeMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents picPropImage As System.Windows.Forms.PictureBox
    Friend WithEvents cmdPropImageBrowse As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtPropImageResolution As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cmdPropImageScale500 As System.Windows.Forms.Button
    Friend WithEvents cmdPropImageScale250 As System.Windows.Forms.Button
    Friend WithEvents cmdPropImageScale100 As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtPropImageScaleFree As System.Windows.Forms.NumericUpDown
    Friend WithEvents mnuDesignNonePaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtPropScaleWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdPropFlipV As System.Windows.Forms.Button
    Friend WithEvents cmdPropFlipH As System.Windows.Forms.Button
    Friend WithEvents pnlPropRotation As System.Windows.Forms.Panel
    Friend WithEvents cmdPropRotateRight As System.Windows.Forms.Button
    Friend WithEvents cmdPropRotateLeft As System.Windows.Forms.Button
    Friend WithEvents txtPropRotate As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtPropScaleHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents mnuLayers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayers0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayers1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayers2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayers3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayers4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayers5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayers6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelpInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optPropObjectSequence As System.Windows.Forms.RadioButton
    Friend WithEvents optPropObject As System.Windows.Forms.RadioButton
    Friend WithEvents pnlPropLineType As System.Windows.Forms.Panel
    Friend WithEvents lblPropLineType As System.Windows.Forms.Label
    Friend WithEvents btnCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFilePrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tabSegmentPropertyImage As System.Windows.Forms.TabPage
    Friend WithEvents mnuSegmentsCut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegmentsDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnZoomToFit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuViewGraphics As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGraphics0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGraphics2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEditFindSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEditFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBars As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBarsMain As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBarsView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBarsLayer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewBarsTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboTrigpointEntrance As System.Windows.Forms.ComboBox
    Friend WithEvents lblTrigpointEntrance As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnProperty As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboPropCaveList As cCaveInfoCombobox
    Friend WithEvents lblPropCaveList As System.Windows.Forms.Label
    Friend WithEvents pnlPropSegmentBinding As System.Windows.Forms.Panel
    Friend WithEvents lblPropBinding As System.Windows.Forms.Label
    Friend WithEvents chkPropSegmentLocked As System.Windows.Forms.CheckBox
    Friend WithEvents cmdPropSegmentRebind As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPropSegmentBinded As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtPropPenDecorationSpacePercentage As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlPropSegmentsBinding As System.Windows.Forms.Panel
    Friend WithEvents lvPropSegmentsBinded As System.Windows.Forms.ListView
    Friend WithEvents colPropSegmentsBindedSegment As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdPropSegmentsRebind As System.Windows.Forms.Button
    Friend WithEvents chkPropSegmentsLocked As System.Windows.Forms.CheckBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents sbMain As System.Windows.Forms.StatusStrip
    Friend WithEvents pnlStatusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlStatusProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomsToFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents mnuDesignItemGenericCombineAllSequences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPropBrushClipartDensity As System.Windows.Forms.Label
    Friend WithEvents txtPropBrushClipartDensity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropBrushClipartZoomFactor As System.Windows.Forms.Label
    Friend WithEvents txtPropBrushClipartZoomFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdPropBrushReseed As System.Windows.Forms.Button
    Friend WithEvents cmdPropBrushBrowseClipart As System.Windows.Forms.Button
    Friend WithEvents lblPropBrushClipartImage As System.Windows.Forms.Label
    Friend WithEvents tblPropBrush As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPropBrushGeneric As System.Windows.Forms.Panel
    Friend WithEvents pnlPropBrushCustom As System.Windows.Forms.Panel
    Friend WithEvents picPropBrushClipartImage As System.Windows.Forms.PictureBox
    Friend WithEvents tblPropPen As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPropPenGeneric As System.Windows.Forms.Panel
    Friend WithEvents pnlPropPenCustom As System.Windows.Forms.Panel
    Friend WithEvents lblPropBrushClipartAngle As System.Windows.Forms.Label
    Friend WithEvents txtPropBrushClipartAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropBrushClipartAngleMode As System.Windows.Forms.Label
    Friend WithEvents cboPropBrushClipartAngleMode As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuEditUndo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuZoom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomZoomCenter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuZoomZoomToFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomZoomIn As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuZoomZoomOut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPropSign As System.Windows.Forms.Panel
    Friend WithEvents cboPropSignRotateMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropSignRotateMode As System.Windows.Forms.Label
    Friend WithEvents cboPropSignSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropSignSize As System.Windows.Forms.Label
    Friend WithEvents pnlPropTextFont As System.Windows.Forms.Panel
    Friend WithEvents cboPropTextFontChar As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropTextFontChar As System.Windows.Forms.Label
    Friend WithEvents cboPropTextFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropTextFontSize As System.Windows.Forms.Label
    Friend WithEvents cboPropTextRotateMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropTextRotateMode As System.Windows.Forms.Label
    Friend WithEvents chkPropTextFontBold As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropTextFontItalic As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropTextFontUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents tblPropText As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPropTextStyle As System.Windows.Forms.Panel
    Friend WithEvents lblPropTextStyle As System.Windows.Forms.Label
    Friend WithEvents cboPropTextStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropText As System.Windows.Forms.Label
    Friend WithEvents txtPropText As System.Windows.Forms.TextBox
    Friend WithEvents pnlPropText As System.Windows.Forms.Panel
    Friend WithEvents lblPropFontColor As System.Windows.Forms.Label
    Friend WithEvents cmdPropFontColor As System.Windows.Forms.Button
    Friend WithEvents picPropFontColor As System.Windows.Forms.PictureBox
    Friend WithEvents cmdPropNext As System.Windows.Forms.Button
    Friend WithEvents cmdPropPrev As System.Windows.Forms.Button
    Friend WithEvents mnuFileExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsRenameTrigpoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointRevertSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents txtPropPenDecorationScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents chkTrigpointIsSpecial As System.Windows.Forms.CheckBox
    Friend WithEvents chkSegmentExclude As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripMenuItem34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewPlotShowStationText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowPointInformation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotCalculate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPlotDeleteAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabObjectPropDesign As System.Windows.Forms.TabPage
    Friend WithEvents tblDesignProp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDesignSize As System.Windows.Forms.Panel
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txtDesignScaleHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents lblDesignScale As System.Windows.Forms.Label
    Friend WithEvents txtDesignScaleWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdDesignFlipV As System.Windows.Forms.Button
    Friend WithEvents cmdDesignFlipH As System.Windows.Forms.Button
    Friend WithEvents txtDesignWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtDesignHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblDesignWidthUM As System.Windows.Forms.Label
    Friend WithEvents lblDesignHeightUM As System.Windows.Forms.Label
    Friend WithEvents lblDesignSize As System.Windows.Forms.Label
    Friend WithEvents pnlDesignPosition As System.Windows.Forms.Panel
    Friend WithEvents cmdDesignMoveRight As System.Windows.Forms.Button
    Friend WithEvents cmdDesignMoveDown As System.Windows.Forms.Button
    Friend WithEvents cmdDesignMoveLeft As System.Windows.Forms.Button
    Friend WithEvents cmdDesignMoveTop As System.Windows.Forms.Button
    Friend WithEvents txtDesignLeft As System.Windows.Forms.TextBox
    Friend WithEvents txtDesignTop As System.Windows.Forms.TextBox
    Friend WithEvents lblDesignLeftUM As System.Windows.Forms.Label
    Friend WithEvents lblDesignTopUM As System.Windows.Forms.Label
    Friend WithEvents lblDesignPosition As System.Windows.Forms.Label
    Friend WithEvents pnlDesignRotation As System.Windows.Forms.Panel
    Friend WithEvents cmdDesignRotateRight As System.Windows.Forms.Button
    Friend WithEvents cmdDesignRotateLeft As System.Windows.Forms.Button
    Friend WithEvents txtDesignRotate As System.Windows.Forms.TextBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents lblDesignRotation As System.Windows.Forms.Label
    Friend WithEvents pnlStatusDesignInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPlotRenameTrigpoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotReplicateData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemChangeTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignPlot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignPlotRebindAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignPlotUnlockAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignPlotLockAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignPlotShowBindings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem37 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignDeleteAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSegmentCaveBranchList As cCaveInfoBranchesCombobox
    Friend WithEvents lblSegmentBranch As System.Windows.Forms.Label
    Friend WithEvents cboPropCaveBranchList As cCaveInfoBranchesCombobox
    Friend WithEvents lblPropBranchList As System.Windows.Forms.Label
    Friend WithEvents mnuDesignItemChangeTo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemChangeTo2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignPlotRemoveBindings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewGraphicsRulers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGraphicsMetricGrid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGraphics1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemGenericReducePoint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileExportImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTrigpointCoordinateAlt As System.Windows.Forms.TextBox
    Friend WithEvents lblTrigpointCoordinateAlt As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPropLinePointReduction As System.Windows.Forms.Button
    Friend WithEvents grdSegments As cSurveyPC.cGrid
    Friend WithEvents lblTrigpointLabelPosition As System.Windows.Forms.Label
    Friend WithEvents cboTrigPointLabelPosition As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripMenuItem25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuZoomAutoZoomToFit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPropSegmentsLock As System.Windows.Forms.Button
    Friend WithEvents cmdPropSegmentsUnlock As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grdTrigPoints As cSurveyPC.cGrid
    Friend WithEvents pnlTrigPoint As System.Windows.Forms.Panel
    Friend WithEvents txtTrigPointName As System.Windows.Forms.TextBox
    Friend WithEvents lblTrigPointName As System.Windows.Forms.Label
    Friend WithEvents tabTrigpointProperty As System.Windows.Forms.TabControl
    Friend WithEvents tabTrigpointCoordinate As System.Windows.Forms.TabPage
    Friend WithEvents tabTrigpointNote As System.Windows.Forms.TabPage
    Friend WithEvents txtTrigpointNote As System.Windows.Forms.TextBox
    Friend WithEvents tabTrigpointLayout As System.Windows.Forms.TabPage
    Friend WithEvents pnlSegment As System.Windows.Forms.Panel
    Friend WithEvents mnuTrigPoints As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTrigPointsRebind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrigPointsRemoveOrphans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem42 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTrigPointsEntrance As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrigPointsEntrance0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrigPointsEntrance1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrigPointsEntrance2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrigPointsEntrance3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem43 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTrigPointsRenameTrigpoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotRebind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem44 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPlotRemoveOrphans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spTrigPoints As System.Windows.Forms.SplitContainer
    Friend WithEvents spSegments As System.Windows.Forms.SplitContainer
    Friend WithEvents spSegmentsAndTrigpoints As System.Windows.Forms.SplitContainer
    Friend WithEvents tbSegmentsAndTrigpoints As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSegments As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnTrigPoints As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSegmentsAndTrigPoints As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSegmentsTrigPoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsTrigPointsFrom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsTrigPointsTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPlotCalculate As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPlotRebind As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnPlotRebindRebind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPlotRebindRemoveOrphans As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlObjectLayers As System.Windows.Forms.Panel
    Friend WithEvents cmdPropParent As System.Windows.Forms.Button
    Friend WithEvents mnuLayersAndItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuLayersAndItemsProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem38 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayersAndItemsVisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem41 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayersAndItemsRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsExpand As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsExpandAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem45 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignHighlight As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignHighlight0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem46 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignHighlight1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExportSurvey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileExportTrack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem48 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnExportData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem49 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportTrack As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem50 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExportImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTrigpointLabelDistance As System.Windows.Forms.Label
    Friend WithEvents cboTrigPointLabelSymbol As System.Windows.Forms.ComboBox
    Friend WithEvents lblTrigPointSymbol As System.Windows.Forms.Label
    Friend WithEvents txtTrigPointLabelDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents ToolStripMenuItem51 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayersAndItemsShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsHideAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsCurrentLevelShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsCurrentLevelHideAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSessionList As System.Windows.Forms.ComboBox
    Friend WithEvents lblSession As System.Windows.Forms.Label
    Friend WithEvents chkTrigpointShowEntrance As System.Windows.Forms.CheckBox
    Friend WithEvents mnuDesignItemProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem54 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignNoneProperty As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem55 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayersManageLevels As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropShapeSequences As System.Windows.Forms.Panel
    Friend WithEvents cmdPropShapeCloseAllSequences As System.Windows.Forms.Button
    Friend WithEvents cmdPropShapeCombineAllSequences As System.Windows.Forms.Button
    Friend WithEvents cmdPropShapeReorderSequence As System.Windows.Forms.Button
    Friend WithEvents pnlPropShape As System.Windows.Forms.Panel
    Friend WithEvents cmdPropShapeDivide As System.Windows.Forms.Button
    Friend WithEvents cmdPropShapeCombine As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPropSequence As System.Windows.Forms.Label
    Friend WithEvents mnuViewWorkspaces As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem56 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewWorkspacesManage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotLRUD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowStyle0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowStyle1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowStyle2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPropRotateLeftByDegree As System.Windows.Forms.Button
    Friend WithEvents cmdPropRotateRightByDegree As System.Windows.Forms.Button
    Friend WithEvents cboPropTextSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropTextSize As System.Windows.Forms.Label
    Friend WithEvents pnlPropClipping As System.Windows.Forms.Panel
    Friend WithEvents cboPropClipping As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropClipping As System.Windows.Forms.Label
    Friend WithEvents lblTrigpointFontchar As System.Windows.Forms.Label
    Friend WithEvents cmdTrigpointColorReset As System.Windows.Forms.Button
    Friend WithEvents picTrigpointFontColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblFontColor As System.Windows.Forms.Label
    Friend WithEvents chkTrigpointFontUnderline As System.Windows.Forms.CheckBox
    Friend WithEvents cboTrigpointFontChar As System.Windows.Forms.ComboBox
    Friend WithEvents chkTrigpointFontBold As System.Windows.Forms.CheckBox
    Friend WithEvents lblTextFontSize As System.Windows.Forms.Label
    Friend WithEvents cboTrigpointFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents chkTrigpointFontItalic As System.Windows.Forms.CheckBox
    Friend WithEvents cmdTrigpointFontColor As System.Windows.Forms.Button
    Friend WithEvents imlGeneric As System.Windows.Forms.ImageList
    Friend WithEvents imlLayers As System.Windows.Forms.ImageList
    Friend WithEvents mnuFileImportSurvey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem58 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileImportDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignNonePasteSpecial As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignNonePasteSpecial0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem59 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignNonePasteSpecial1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignNonePasteSpecial2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignNonePasteSpecial3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnLayerManageLevels As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewViewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemHiddenInDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropCrossSection As System.Windows.Forms.Panel
    Friend WithEvents txtPropProfileTextDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropProfileTextDistance As System.Windows.Forms.Label
    Friend WithEvents cboPropProfileTextPosition As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropProfileTextPosition As System.Windows.Forms.Label
    Friend WithEvents pnlStatusDesignGeographicState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboPropProfileDirection As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropProfileBearing As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem60 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayersAndItemsDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem62 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbPens As System.Windows.Forms.ToolStrip
    Friend WithEvents tbView As System.Windows.Forms.ToolStrip
    Friend WithEvents btnView_Plan As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnView_Profile As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnShowFieldData As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnShowObjectProp As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator18 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnCursorMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnScrollMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMultiSelMode1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMultiSelMode2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSepMode As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboMainCaveList As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboMainCaveBranchList As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents cboMainBindDesignType As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnDesignHighlight As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnDesignHighlight0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDesignHighlight1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboPropBindDesignType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropBindDesignType As System.Windows.Forms.Label
    Friend WithEvents txtPropCrossSectionSegment As System.Windows.Forms.TextBox
    Friend WithEvents lblPropCrossSectionSegment As System.Windows.Forms.Label
    Friend WithEvents cmdPropCrossSectionSegment As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem63 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewBarsPen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnObjectProp As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEndEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuLayersAndItemsCurrentLevelDeleteAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropQuota As System.Windows.Forms.Panel
    Friend WithEvents cboPropQuotaValueType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropQuotaValueType As System.Windows.Forms.Label
    Friend WithEvents cboPropQuotaValue As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropQuotaValue As System.Windows.Forms.Label
    Friend WithEvents cboPropQuotaAlign As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropQuotaAlign As System.Windows.Forms.Label
    Friend WithEvents cboPropQuotaType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropQuotaType As System.Windows.Forms.Label
    Friend WithEvents mnuSegmentsPrefixTrigpoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTrigPointsPrefixTrigpoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotPrefixTrigpoints As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrAutosave As System.Windows.Forms.Timer
    Friend WithEvents mnuDesignItemChangeTo4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem61 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewBarsPens As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFile3D As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSketch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSketchEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropSketch As System.Windows.Forms.Panel
    Friend WithEvents lblPropSketchEdit As System.Windows.Forms.Label
    Friend WithEvents cmdPropSketchEdit As System.Windows.Forms.Button
    Friend WithEvents mnuDesignAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignEndEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignObjectProp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem64 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenSmooting As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPensStyle As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboPensSmooting As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tabTrigpointMain As System.Windows.Forms.TabPage
    Friend WithEvents cboTrigPointType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTrigpointType As System.Windows.Forms.Label
    Friend WithEvents tabSegmentPropertyLayout As System.Windows.Forms.TabPage
    Friend WithEvents grdTrigPointAliases As cSurveyPC.cGrid
    Friend WithEvents mnuAliases As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuAliasesRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAliasesRemoveAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkTrigpointIsInExploration As System.Windows.Forms.CheckBox
    Friend WithEvents btnViewer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents imlNotify As System.Windows.Forms.ImageList
    Friend WithEvents tabTrigpointConnections As System.Windows.Forms.TabPage
    Friend WithEvents grdTrigpointConnections As cSurveyPC.cGrid
    Friend WithEvents ToolStripMenuItem52 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTrigPointsFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem65 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegmentsFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileTherion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rtfConsole As System.Windows.Forms.RichTextBox
    Friend WithEvents btnAltMode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tmrClipboard As System.Windows.Forms.Timer
    Friend WithEvents pnlDesignStyle As System.Windows.Forms.Panel
    Friend WithEvents lblDesignStyle As System.Windows.Forms.Label
    Friend WithEvents chkDesignStyle2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignStyle1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignStyle0 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdDesignRotateLeftByDegree As System.Windows.Forms.Button
    Friend WithEvents cmdDesignRotateRightByDegree As System.Windows.Forms.Button
    Friend WithEvents btnObjectSetCaveBranch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnObjectShowBindings As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkPropSketchManualAdjust As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropSketchMorphingDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents mnuPlotInfoCave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem67 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPlotInfoRing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotInfoOrientation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvSegmentInfo As System.Windows.Forms.ListView
    Friend WithEvents colSegmentInfoName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSegmentInfoValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents mnuSegmentInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSegmentInfoCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdLayerRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdLayerObjectProperty As System.Windows.Forms.Button
    Friend WithEvents cmdLayerObjectSelect As System.Windows.Forms.Button
    Friend WithEvents chkPropLock As System.Windows.Forms.CheckBox
    Friend WithEvents mnuDesignItemGenericRestorePointPen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignEditScaleRules As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem68 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileRollback As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPlotSetCaveBranch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem69 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPropSetCaveBranch As System.Windows.Forms.Button
    Friend WithEvents tmrMouseMove As System.Windows.Forms.Timer
    Friend WithEvents pnlStatusCurrentRule As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtPropSketchResolution As System.Windows.Forms.TextBox
    Friend WithEvents lblPropSketchResolution As System.Windows.Forms.Label
    Friend WithEvents picPropSketch As System.Windows.Forms.PictureBox
    Friend WithEvents mnuViewPlotShowStyle3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowStation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemFlip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemFlipH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemFlipV As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotInfoDistances As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropMergeMode As System.Windows.Forms.Panel
    Friend WithEvents cboPropMergeMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropMergeMode As System.Windows.Forms.Label
    Friend WithEvents lblSegmentDirection As System.Windows.Forms.Label
    Friend WithEvents cboSegmentDirection As System.Windows.Forms.ComboBox
    Friend WithEvents mnuViewGraphicsShowAdvancedBrushes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPropBrushAlternativeBrushColor As System.Windows.Forms.Label
    Friend WithEvents cmdPropBrushAlternativeBrushColor As System.Windows.Forms.Button
    Friend WithEvents picPropBrushAlternativeBrushColor As System.Windows.Forms.PictureBox
    Friend WithEvents mnuDesignItemSegmentTrigpoint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentTrigpointFrom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentTrigpointTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentInvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentDirection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentDirection0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentDirection1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentDirection2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem70 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDesignHighlightMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDesignHighlightMode0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDesignHighlightMode1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDesignHighlightMode2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileAutoSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotManageVisibility As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPlotInfoCave As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdPropQuotaTrigpoint As System.Windows.Forms.Button
    Friend WithEvents txtPropQuotaRelativeTrigpoint As System.Windows.Forms.TextBox
    Friend WithEvents lblPropQuotaRelativeTrigpoint As System.Windows.Forms.Label
    Friend WithEvents cmdPropQuotaOtherOptions As System.Windows.Forms.Button
    Friend WithEvents mnuTrigPointsEntrance4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colConnectionsTrigPoint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConnectionsIgnore As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmdSegmentSetCurrentCaveBranch As System.Windows.Forms.Button
    Friend WithEvents mnuSegmentInfoCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsInsert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem47 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegmentsMoveUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSegmentsMoveDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPopup As System.Windows.Forms.Panel
    Friend WithEvents lblPopupWarning As System.Windows.Forms.Label
    Friend WithEvents picPopupWarning As System.Windows.Forms.PictureBox
    Friend WithEvents btnPopupClose As System.Windows.Forms.Button
    Friend WithEvents imlPopup As System.Windows.Forms.ImageList
    Friend WithEvents mnuFileSurface As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignStyle0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignStyle1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignStyle2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSegmentSurface As System.Windows.Forms.CheckBox
    Friend WithEvents chkSegmentDuplicate As System.Windows.Forms.CheckBox
    Friend WithEvents chkSegmentSplay As System.Windows.Forms.CheckBox
    Friend WithEvents mnuMapDrop As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuMapDropImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMapDropSketch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemChangeTo3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntiMain As System.Windows.Forms.NotifyIcon
    Friend WithEvents mnuTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnnuTrayShowHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem72 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTrayClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileHideInTray As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem73 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegmentsRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileResurvey As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuFileRecent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem74 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPropTransparency As System.Windows.Forms.Panel
    Friend WithEvents txtPropTransparency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropTransparency As System.Windows.Forms.Label
    Friend WithEvents btnEditDrawing As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEditPointToPoint As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuPlotInfoSession As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignUnselectedLevelDrawingMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem75 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewDesignUnselectedLevelDrawingMode0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignUnselectedLevelDrawingMode1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewDesignUnselectedLevelDrawingMode2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPropProfileSplayProjectionAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropProfileSplayProjectionAngle As System.Windows.Forms.Label
    Friend WithEvents picPropProfileProjectionSchema As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripMenuItem76 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegmentsReverse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlotGrades As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem77 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPropImageView As System.Windows.Forms.Button
    Friend WithEvents cmdPropSketchView As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem79 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemImageView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem78 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemSketchView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem80 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemSketchMorphing As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSketchMorphingDisabled As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem81 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemSketchMorphingEnableAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSketchMorphingDisableAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageVisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageVisibleShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemImageVisibleHideAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem82 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemSketchVisible As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSketchVisibleShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSketchVisibleHideAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem86 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuZoomZoomToFitCaveBranch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPropBrushClipartCrop As System.Windows.Forms.Label
    Friend WithEvents cboPropBrushClipartCrop As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSegmentSetCaveBranch As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem83 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemSegmentDirection3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropObjectsBinding As System.Windows.Forms.Panel
    Friend WithEvents lvPropObjectsBinded As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPropObjectsRefresh As System.Windows.Forms.Button
    Friend WithEvents btnPropObjectsSelect As System.Windows.Forms.Button
    Friend WithEvents mnuZoomZoomToSelection As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointNewFromSequenceBar As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPointNewFromSequence0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointNewFromSequence1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlStatusDesignZoom As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuDesignItemSendCopyTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSendCopyTo0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSendCopyTo1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemBar8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPropPointsSequences As System.Windows.Forms.Panel
    Friend WithEvents pnlPropConvertTo As System.Windows.Forms.Panel
    Friend WithEvents cmdPropConvertTo As System.Windows.Forms.Button
    Friend WithEvents lvPropConvertTo As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPropConvertTo As System.Windows.Forms.Label
    Friend WithEvents cmdPropPointsSequencesDelete As System.Windows.Forms.Button
    Friend WithEvents cmdPropPointsSequencesDivide As System.Windows.Forms.Button
    Friend WithEvents cmdPropPointsSequencesRevert As System.Windows.Forms.Button
    Friend WithEvents cmdPropPointsSequencesClose As System.Windows.Forms.Button
    Friend WithEvents cmdPropPointsSequencesCombine As System.Windows.Forms.Button
    Friend WithEvents mnuDesignItemGenericWiden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem53 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewPlotShowAlso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowAlso1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotShowAlso2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem85 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPropSequenceLineType As System.Windows.Forms.Panel
    Friend WithEvents lblPropSequenceLineType As System.Windows.Forms.Label
    Friend WithEvents lblPropBrushPatternType As System.Windows.Forms.Label
    Friend WithEvents cboPropBrushPatternType As System.Windows.Forms.ComboBox
    Friend WithEvents cboPropBrushPatternPen As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropBrushPatternPen As System.Windows.Forms.Label
    Friend WithEvents chkDesignUnselectedLevelDrawingMode2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignUnselectedLevelDrawingMode1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignUnselectedLevelDrawingMode0 As System.Windows.Forms.CheckBox
    Friend WithEvents lblDesignUnselectedLevelDrawingMode As System.Windows.Forms.Label
    Friend WithEvents tbViews As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem87 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemSegmentDirection4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnEditSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPropProp As System.Windows.Forms.Panel
    Friend WithEvents cboPropCategories As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropCategory As System.Windows.Forms.Label
    Friend WithEvents optPropTextAlignRight As System.Windows.Forms.RadioButton
    Friend WithEvents optPropTextAlignCenter As System.Windows.Forms.RadioButton
    Friend WithEvents optPropTextAlignLeft As System.Windows.Forms.RadioButton
    Friend WithEvents optPropTextVAlignBottom As System.Windows.Forms.RadioButton
    Friend WithEvents optPropTextVAlignCenter As System.Windows.Forms.RadioButton
    Friend WithEvents optPropTextVAlignTop As System.Windows.Forms.RadioButton
    Friend WithEvents pnlStatusDesignSnapToGrid As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlDesignSnapToGrid As System.Windows.Forms.Panel
    Friend WithEvents txtDesignSnapToGrid As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDesignSnapToGridUM As System.Windows.Forms.Label
    Friend WithEvents lblDesignSnapToGrid0 As System.Windows.Forms.Label
    Friend WithEvents chkDesignSnapToGrid As System.Windows.Forms.CheckBox
    Friend WithEvents pnlPropItems As System.Windows.Forms.Panel
    Friend WithEvents lblPropItemsAlign As System.Windows.Forms.Label
    Friend WithEvents cmdPropItemsHAlignCenter As System.Windows.Forms.Button
    Friend WithEvents cmdPropItemsHAlignLeft As System.Windows.Forms.Button
    Friend WithEvents cmdPropItemsVAlignTop As System.Windows.Forms.Button
    Friend WithEvents cmdPropItemsHAlignRight As System.Windows.Forms.Button
    Friend WithEvents cmdPropItemsVAlignMiddle As System.Windows.Forms.Button
    Friend WithEvents cmdPropItemsVAlignBottom As System.Windows.Forms.Button
    Friend WithEvents lblPropItemsSpace As System.Windows.Forms.Label
    Friend WithEvents cmdPropItemsVSpace As System.Windows.Forms.Button
    Friend WithEvents cmdPropItemsHSpace As System.Windows.Forms.Button
    Friend WithEvents chkSegmentUnbindable As System.Windows.Forms.CheckBox
    Friend WithEvents pnlPropPopup As System.Windows.Forms.Panel
    Friend WithEvents btnPropWarningClose As System.Windows.Forms.Button
    Friend WithEvents lblPropPopupWarning As System.Windows.Forms.Label
    Friend WithEvents picPropPopupWarning As System.Windows.Forms.PictureBox
    Friend WithEvents piclayerItemPreview As System.Windows.Forms.PictureBox
    Friend WithEvents lbLayerItemCaption As System.Windows.Forms.Label
    Friend WithEvents lbLayerItemTitle As System.Windows.Forms.Label
    Friend WithEvents mnuLayersAndItemsSelectAllInCurrentLevel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem88 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileCleanUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem89 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEditSelectAllSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuEditSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointConvert As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointConvertBar As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignItemPointConvertToBezier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemPointConvertToLines As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtPropProfileSplayMaxVariationAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropProfileSplayMaxVariationAngle As System.Windows.Forms.Label
    Friend WithEvents pnlPropProfileSplayBorder As System.Windows.Forms.Panel
    Friend WithEvents mnuDesignItemItems As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemItemsCombine As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlTrigpointCoordinateUTM As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTrigpointCoordinateBand As System.Windows.Forms.ComboBox
    Friend WithEvents lblTrigpointCoordinateZone As System.Windows.Forms.Label
    Friend WithEvents txtTrigpointCoordinateY As System.Windows.Forms.TextBox
    Friend WithEvents cboTrigpointCoordinateZone As System.Windows.Forms.ComboBox
    Friend WithEvents txtTrigpointCoordinateX As System.Windows.Forms.TextBox
    Friend WithEvents lblTrigpointCoordinateY As System.Windows.Forms.Label
    Friend WithEvents lblTrigpointCoordinateX As System.Windows.Forms.Label
    Friend WithEvents pnlTrigpointCoordinateWGS84 As System.Windows.Forms.Panel
    Friend WithEvents pnlPropPlanSplayBorder As System.Windows.Forms.Panel
    Friend WithEvents txtPropPlanSplayMaxVariationDelta As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropPlanSplayMaxVariationDelta As System.Windows.Forms.Label
    Friend WithEvents picPropPlanProjectionSchema As System.Windows.Forms.PictureBox
    Friend WithEvents txtPropPlanSplayPlanDeltaZ As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropPlanSplayPlanDeltaZ As System.Windows.Forms.Label
    Friend WithEvents prpSegmentDataProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents tabSegmentPropertyData As System.Windows.Forms.TabPage
    Friend WithEvents mnuSegmentsDataProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSegmentsDataPropertiesEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem91 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSegmentsDataPropertiesDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPropDataProperties As System.Windows.Forms.Panel
    Friend WithEvents prpPropDesignDataProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents mnuDesignDataProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesignDataPropertiesEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignDataPropertiesDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkPropShowDataProperties As System.Windows.Forms.CheckBox
    Friend WithEvents tabTrigpointPropertyData As System.Windows.Forms.TabPage
    Friend WithEvents prpTrigpointDataProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents mnuTrigpointDataProperties As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTrigpointDataPropertiesEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTrigpointDataPropertiesDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPropDesignDataProperties As System.Windows.Forms.Label
    Friend WithEvents lblPropQuotaTextPosition As System.Windows.Forms.Label
    Friend WithEvents cboPropQuotaTextPosition As System.Windows.Forms.ComboBox
    Friend WithEvents mnuDesignItemGenericRevertAllSequences As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem92 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblPropLinePointReduction As System.Windows.Forms.Label
    Friend WithEvents txtPropLinePointReductionFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropLinePointReductionUM As System.Windows.Forms.Label
    Friend WithEvents cmdPropSetCurrentCaveBranch As System.Windows.Forms.Button
    Friend WithEvents chkPropVisibleInPreview As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropVisibleInDesign As System.Windows.Forms.CheckBox
    Friend WithEvents lblPropVisibleIn As System.Windows.Forms.Label
    Friend WithEvents cmdLayerFilterEdit As System.Windows.Forms.Button
    Friend WithEvents chkLayerFiltered As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripMenuItem93 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuLayersAndItemsFilterEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsFiltered As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditSelectAllInDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEditSelectAllInCurrentLevelInDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSegmentVirtual As System.Windows.Forms.CheckBox
    Friend WithEvents lblPropPlanSplayPlanProjectionPlanType As System.Windows.Forms.Label
    Friend WithEvents cboPropPlanSplayPlanProjectionType As System.Windows.Forms.ComboBox
    Friend WithEvents mnuFileImportTracks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem94 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkDesignRotateCenterOnOrigin As System.Windows.Forms.CheckBox
    Friend WithEvents txtPropPointType As System.Windows.Forms.TextBox
    Friend WithEvents lblPropPointType As System.Windows.Forms.Label
    Friend WithEvents pnlPropPositionSubPanel1 As System.Windows.Forms.Panel
    Friend WithEvents cboPropSign As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropSign As System.Windows.Forms.Label
    Friend WithEvents mnuViewPlotLRUDHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem95 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewPlotSplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotSplayHide As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem96 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewPlotSplayStyle0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewPlotSplayStyle1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewWorkspacesData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewWorkspacesDesign As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem57 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewPlotSplayText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblPropProfileSplay As System.Windows.Forms.Label
    Friend WithEvents lblPropPlanSplay As System.Windows.Forms.Label
    Friend WithEvents pnlPropCrossSectionSplayBorder As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPropCrossSectionSplayMaxVariationAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkPropCrossSectionShowSplayBorder As System.Windows.Forms.CheckBox
    Friend WithEvents lblPropCrossSectionSplayMaxVariationAngle As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionSplayProjectionAngle As System.Windows.Forms.Label
    Friend WithEvents cboPropCrossSectionSplayLineStyle As System.Windows.Forms.ComboBox
    Friend WithEvents txtPropCrossSectionSplayProjectionAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropCrossSectionSplayLineStyle As System.Windows.Forms.Label
    Friend WithEvents picPropCrossSectionProjectionSchema As System.Windows.Forms.PictureBox
    Friend WithEvents chkPropCrossSectionSplayText As System.Windows.Forms.CheckBox
    Friend WithEvents tbWorkspaces As System.Windows.Forms.ToolStrip
    Friend WithEvents btnWorkspaceData As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnWorkspaceDesign As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuViewBarsWorkspaces As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewWorkspacesAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnWorkspaceAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDesignItemSegmentSplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentSplayReplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPropCrossSectionSplay As System.Windows.Forms.Button
    Friend WithEvents cmdPropProfileSplay As System.Windows.Forms.Button
    Friend WithEvents cmdPropPlanSplay As System.Windows.Forms.Button
    Friend WithEvents mnuDesignHighlightMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignHighlightMode0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignHighlightMode1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignHighlightMode2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPropSignOtherOptions As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mnuDesignItemSegmentSetCoordinate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlDesignPlotContainer As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkDesignPlotShowSegment As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignPlotShowSplay As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignPlotShowLRUD As System.Windows.Forms.CheckBox
    Friend WithEvents cboDesignPlotSegmentsPaintStyle As System.Windows.Forms.ComboBox
    Friend WithEvents cboDesignPlotSplayStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chkDesignPlotShowTrigpoint As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignPlotShowTrigpointText As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignPlotShowSplayLabel As System.Windows.Forms.CheckBox
    Friend WithEvents mnuDesignItemSegment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionCrossX As System.Windows.Forms.Label
    Friend WithEvents txtPropCrossSectionHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPropCrossSectionWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropCrossSectionCross As System.Windows.Forms.Label
    Friend WithEvents mnuDesignItemPaste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlStatusDesignWarpingState As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cboPropQuotaFormat As System.Windows.Forms.ComboBox
    Friend WithEvents lblPropQuotaFormat As System.Windows.Forms.Label
    Friend WithEvents btnViewMetricGrid As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btnViewMetricGrid1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnViewMetricGrid2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnViewMetricGridSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuViewGraphicsMetricGrid0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGraphicsMetricGrid1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuViewGraphicsMetricGrid2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnViewMetricGrid0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblTrigpointCoordinateFix As System.Windows.Forms.Label
    Friend WithEvents cboTrigpointCoordinateFix As System.Windows.Forms.ComboBox
    Friend WithEvents mnuHelpCheckUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem98 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuPlotSplayReplicate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSurface As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDesignPlotSplay As System.Windows.Forms.Button
    Friend WithEvents cmdPropPointsJoin As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdPropPointsUnjoin As System.Windows.Forms.Button
    Friend WithEvents cmdPropPointsUnjoinAll As System.Windows.Forms.Button
    Friend WithEvents pnlStatusHistoryEnabled As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripMenuItem97 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileHistory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPropPointsJoinAndConnect As System.Windows.Forms.Button
    Friend WithEvents lblPropBrushClipartPosition As System.Windows.Forms.Label
    Friend WithEvents cboPropBrushClipartPosition As System.Windows.Forms.ComboBox
    Friend WithEvents cmdPropPointsSequencesDivideAndJoin As System.Windows.Forms.Button
    Friend WithEvents mnuDesignItemPointSegmentDivideAndJoin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMapDropPocketTopo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMapDropText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMapDropCaveExplorer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentSetCoordinateCP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTrigpointCoordinateClear As System.Windows.Forms.Button
    Friend WithEvents mnuViewScript As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlDesignSurfaceContainer As System.Windows.Forms.Panel
    Friend WithEvents tvDesignSurfaceLayers As System.Windows.Forms.TreeView
    Friend WithEvents mnuDesignSurfaceLayers As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuDesignSurfaceLayersEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdDesignSurfaceLayersDown As System.Windows.Forms.Button
    Friend WithEvents cmdDesignSurfaceLayersUp As System.Windows.Forms.Button
    Friend WithEvents cmdDesignSurfaceLayersEdit As System.Windows.Forms.Button
    Friend WithEvents cmdDesignSurfaceEdit As System.Windows.Forms.Button
    Friend WithEvents mnuDesignSurfaceEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem71 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents pnlPropSegmentInfo As System.Windows.Forms.Panel
    Friend WithEvents pnlPropTrigpointInfo As cSurveyPC.cPanel
    Friend WithEvents lvTrigpointInfo As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPropSegment As System.Windows.Forms.Label
    Friend WithEvents lblpropTrigpoint As System.Windows.Forms.Label
    Friend WithEvents cmdPropTrigpointFix As System.Windows.Forms.Button
    Friend WithEvents cmdPropTrigpointFixToMarker As System.Windows.Forms.Button
    Friend WithEvents cmdPropSegmentInvert As System.Windows.Forms.Button
    Friend WithEvents cmdPropSegmentEndShot As System.Windows.Forms.Button
    Friend WithEvents cmdPropSegmentBeginShot As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem99 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuDesignSurfaceLayersShowAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDesignSurfaceLayersHideAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnView_3D As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuView3D As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tabObjectProp3D As System.Windows.Forms.TabPage
    Friend WithEvents tbl3DProp As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnl3DMain As System.Windows.Forms.Panel
    Friend WithEvents pnl3DPlotContainer As System.Windows.Forms.Panel
    Friend WithEvents chk3DPlotShowSplayLabel As System.Windows.Forms.CheckBox
    Friend WithEvents chk3DPlotShowTrigpointText As System.Windows.Forms.CheckBox
    Friend WithEvents chk3DPlotShowTrigpoint As System.Windows.Forms.CheckBox
    Friend WithEvents cbo3DPlotSplayStyle As System.Windows.Forms.ComboBox
    Friend WithEvents cbo3DPlotSegmentsPaintStyle As System.Windows.Forms.ComboBox
    Friend WithEvents chk3DPlotShowSplay As System.Windows.Forms.CheckBox
    Friend WithEvents chk3DPlotShowLRUD As System.Windows.Forms.CheckBox
    Friend WithEvents chk3DPlotShowSegment As System.Windows.Forms.CheckBox
    Friend WithEvents pnl3DSurfaceContainer As System.Windows.Forms.Panel
    Friend WithEvents cmd3dSurfaceEdit As System.Windows.Forms.Button
    Friend WithEvents cmd3DSurfaceLayersDown As System.Windows.Forms.Button
    Friend WithEvents cmd3DSurfaceLayersUp As System.Windows.Forms.Button
    Friend WithEvents cmd3DSurfaceLayersEdit As System.Windows.Forms.Button
    Friend WithEvents tv3DSurfaceLayers As System.Windows.Forms.TreeView
    Friend WithEvents tv3DSurfaceElevationsLayers As System.Windows.Forms.TreeView
    Friend WithEvents chk3DSurface As System.Windows.Forms.CheckBox
    Friend WithEvents chk3DPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignPlot As System.Windows.Forms.CheckBox
    Friend WithEvents chkDesignSurface As System.Windows.Forms.CheckBox
    Friend WithEvents txt3DSurfaceElevationAmp As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl3DSurfaceElevationAmp As System.Windows.Forms.Label
    Friend WithEvents txt3DSurfaceTransparency As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbl3dSurfaceTransparency As System.Windows.Forms.Label
    Friend WithEvents pnl3D As System.Windows.Forms.Panel
    Friend WithEvents h3D As System.Windows.Forms.Integration.ElementHost
    Friend WithEvents btn3DSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn3dViewBottom As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn3dViewNS As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn3dViewOE As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn3dViewTop As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn3dViewSN As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn3dViewEO As System.Windows.Forms.ToolStripButton
    Friend WithEvents pnlDesignSurfaceProfile As System.Windows.Forms.Panel
    Friend WithEvents chkDesignSurfaceProfile As System.Windows.Forms.CheckBox
    Friend WithEvents lblSegmentSurfaceProfile As System.Windows.Forms.Label
    Friend WithEvents lblSegmentSurfaceProfileShow As System.Windows.Forms.Label
    Friend WithEvents cboSegmentSurfaceProfileShow As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSegmentSurfaceProfile As System.Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem100 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuFileExport3D As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem101 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExport3D As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlStatusWMSOnLine As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btn3DCameraSep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn3DCameraType As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn3DCameraType1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn3DCameraType0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn3DCameraMode As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents btn3DCameraMode1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn3DCameraMode0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPropShapeRevertAllSequences As System.Windows.Forms.Button
    Friend WithEvents chkDesignPlotShowHLs As System.Windows.Forms.CheckBox
    Friend WithEvents btnSegmentAndTrigpointFilterEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSegmentAndTrigpointFiltered As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSegnentAndTrigpointSepFilter As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFilterSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnFilterEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnFilterFiltered As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSegmentsManageLRUD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bwMain As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripMenuItem19 As ToolStripSeparator
    Friend WithEvents btnDesignHighlightSegmentsAndTrigpoints As ToolStripMenuItem
    Friend WithEvents btnDesignRings As Button
    Friend WithEvents lvDesignPlotShowHLsDett As System.Windows.Forms.ListView
    Friend WithEvents colNome As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnDesignHighlights As Button
    Friend WithEvents ToolStripMenuItem90 As ToolStripSeparator
    Friend WithEvents mnuSegmentsExport As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem102 As ToolStripSeparator
    Friend WithEvents mnuTrigPointsExport As ToolStripMenuItem
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPropCrossSectionMarkerPosition As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPropCrossSectionMarkerU As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents lblPropCrossSectionMarkerDUM As Label
    Friend WithEvents lbltxtPropCrossSectionMarkerRUM As Label
    Friend WithEvents lblPropCrossSectionMarkerLUM As Label
    Friend WithEvents lblPropCrossSectionMarkerUUM As Label
    Friend WithEvents txtPropCrossSectionMarkerD As NumericUpDown
    Friend WithEvents txtPropCrossSectionMarkerR As NumericUpDown
    Friend WithEvents txtPropCrossSectionMarkerL As NumericUpDown
    Friend WithEvents cboPropCrossSectionMarkerProfileAlign As ComboBox
    Friend WithEvents lblPropCrossSectionMarkerAlign As Label
    Friend WithEvents cboPropCrossSectionMarkerPlanAlign As ComboBox
    Friend WithEvents txtPropCrossSectionMarkerDeltaAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPropCrossSectionMarkerDeltaAngle As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionMarkerD As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionMarkerR As System.Windows.Forms.Label
    Friend WithEvents lblPropCrossSectionMarkerU As System.Windows.Forms.Label
    Friend WithEvents pnlPropCrossSectionMarker As Panel
    Friend WithEvents cmdPropCrossSectionMarkerUDFromDesign As Button
    Friend WithEvents cmdPropCrossSectionMarkerLRFromDesign As Button
    Friend WithEvents chkPropCrossSectionProfileMarker As CheckBox
    Friend WithEvents chkPropCrossSectionPlanMarker As CheckBox
    Friend WithEvents cmdPropCrossSectionItem As Button
    Friend WithEvents cboPropCrossSectionMarkerScale As ComboBox
    Friend WithEvents lblPropCrossSectionMarkerScale As Label
    Friend WithEvents txtPropCrossSectionMarkerLabelDistance As NumericUpDown
    Friend WithEvents lblPropCrossSectionMarkerLabelDistance As Label
    Friend WithEvents cboPropCrossSectionMarkerLabelPosition As ComboBox
    Friend WithEvents lblPropCrossSectionMarkerLabelPosition As Label
    Friend WithEvents chkPropCrossSectionMarkerLabel As CheckBox
    Friend WithEvents cboPropCrossSectionMarkerDirection As ComboBox
    Friend WithEvents lblPropCrossSectionMarkerDirection As Label
    Friend WithEvents cboPropCrossSectionMarkerLabelRotation As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmdPropCrossSectionProfileMarker As Button
    Friend WithEvents cmdPropCrossSectionPlanMarker As Button
    Friend WithEvents ToolStripMenuItem103 As ToolStripSeparator
    Friend WithEvents mnuPlotManageLRUD As ToolStripMenuItem
    Friend WithEvents pnlSegmentCaveBranches As Panel
    Friend WithEvents pnlSegmentCaveBranchesColor As Panel
    Friend WithEvents pnlSegmentSession As Panel
    Friend WithEvents pnlSegmentSessionColor As Panel
    Friend WithEvents btnSegmentAndTrigpointGridColor As ToolStripDropDownButton
    Friend WithEvents btnSegmentAndTrigpointGridColor1 As ToolStripMenuItem
    Friend WithEvents btnSegmentAndTrigpointGridColor0 As ToolStripMenuItem
    Friend WithEvents btnSegmentAndTrigpointGridColorSep As ToolStripSeparator
    Friend WithEvents btnSegmentAndTrigpointGridColor2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem104 As ToolStripSeparator
    Friend WithEvents mnuDesignItemPasteSpecial As ToolStripMenuItem
    Friend WithEvents mnuDesignItemPasteSpecialPen As ToolStripMenuItem
    Friend WithEvents mnuDesignItemPasteSpecialBrush As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator15 As ToolStripSeparator
    Friend WithEvents btnPenLine As ToolStripButton
    Friend WithEvents btnPenSpline As ToolStripButton
    Friend WithEvents btnPenBezier As ToolStripButton
    Friend WithEvents mnuDesignItemAreaFromSequence As ToolStripMenuItem
    Friend WithEvents mnuDesignItemAreaFromSequenceBar As ToolStripSeparator
    Friend WithEvents mnuDesignItemAreaFromSequencePanel As ToolStripMenuItem
    Friend WithEvents chkDesignCombineColorGray As CheckBox
    Friend WithEvents cboDesignCombineColorMode As ComboBox
    Friend WithEvents lblDesignCombineColorMode As Label
    Friend WithEvents pnlDesignCombineColorMode As Panel
    Friend WithEvents chkDesignPlotColorGray As CheckBox
    Friend WithEvents cboDesignPlotColorMode As ComboBox
    Friend WithEvents lblDesignPlotColorMode As Label
    Friend WithEvents chk3DPlotColorGray As CheckBox
    Friend WithEvents cbo3dPlotColorMode As ComboBox
    Friend WithEvents lbl3dPlotColorMode As Label
    Friend WithEvents chkTrigpointDrawTranslationsLine As CheckBox
    Friend WithEvents mnuDesignItemItemUnder As ToolStripMenuItem
    Friend WithEvents mnuDesignItemItemUnderItems As ToolStripMenuItem
    Friend WithEvents mnuDesignNoneInfo As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem105 As ToolStripSeparator
    Friend WithEvents mnuDesignItemInfo As ToolStripMenuItem
    Friend WithEvents mnuDesignItemBarInfo As ToolStripSeparator
    Friend WithEvents mnuDesignNoneItemUnder As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem107 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem106 As ToolStripSeparator
    Friend WithEvents mnuDesignItemItemBar8 As ToolStripSeparator
    Friend WithEvents pnlSegmentFromAndTo As Panel
    Friend WithEvents pnlTrigpointName As Panel
    Friend WithEvents mnuTrigpointInfo As ContextMenuStrip
    Friend WithEvents mnuTrigpointInfoCopy As ToolStripMenuItem
    Friend WithEvents mnuTrigpointInfoCopyAll As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem108 As ToolStripSeparator
    Friend WithEvents mnuTrigpointInfoCopyValue As ToolStripMenuItem
    Friend WithEvents mnuTrigpointInfoCopyAllValue As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem109 As ToolStripSeparator
    Friend WithEvents mnuSegmentInfoCopyValue As ToolStripMenuItem
    Friend WithEvents mnuSegmentInfoCopyAllValue As ToolStripMenuItem
    Friend WithEvents cmdPropTrigpointGoto As Button
    Friend WithEvents cmdPropSegmentGoto As Button
    Friend WithEvents mnuPlotInfoEntrance As ToolStripMenuItem
    Friend WithEvents pnlPropCaveBranches As Panel
    Friend WithEvents pnlPropCaveBranchesColor As Panel
    Friend WithEvents mnuDesignItemItemsCombineGroup As ToolStripMenuItem
    Friend WithEvents mnuDesignItemItemsCombineConcretionClipart As ToolStripMenuItem
    Friend WithEvents mnuDesignItemItemsCombineRockClipart As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem111 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem110 As ToolStripSeparator
    Friend WithEvents mnuDesignItemItemsCombineSignClipart As ToolStripMenuItem
    Friend WithEvents mnuDesignItemClipart As ToolStripMenuItem
    Friend WithEvents mnuDesignItemClipartSaveInGallery As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem112 As ToolStripSeparator
    Friend WithEvents mnuDesignItemClipartExport As ToolStripMenuItem
    Friend WithEvents mnuDesignItemSign As ToolStripMenuItem
    Friend WithEvents mnuDesignItemSignSaveInGallery As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem113 As ToolStripSeparator
    Friend WithEvents mnuDesignItemSignExport As ToolStripMenuItem
    Friend WithEvents chkSegmentZSurvey As CheckBox
    Friend WithEvents chkSegmentCutSplay As CheckBox
    Friend WithEvents lbl3dPlotModelColoringMode As Label
    Friend WithEvents cbo3dPlotModelColoringMode As ComboBox
    Friend WithEvents cbo3dPlotModelMode As ComboBox
    Friend WithEvents chk3DPlotShowModel As CheckBox
    Friend WithEvents chkTrigpointZTurn As CheckBox
    Friend WithEvents pnl3dPlotModel As Panel
    Friend WithEvents chk3dModelColorGray As CheckBox
    Friend WithEvents lbl3dPlotModelMode As Label
    Friend WithEvents pnl3DPlot As Panel
    Friend WithEvents pnl3DSurface As Panel
    Friend WithEvents pnlDesignPlot As Panel
    Friend WithEvents pnlDesignSurface As Panel
    Friend WithEvents mnuDesignItemSegmentSplayCreateBorder As ToolStripMenuItem
    Friend WithEvents mnuDesignItemSegmentSplayBar1 As ToolStripSeparator
    Friend WithEvents mnuDesignItemSegmentSplayCreateBorderPanel As ToolStripMenuItem
    Friend WithEvents txtPropPlanSplayInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropPlanSplayInclinationRange As Label
    Friend WithEvents txtPropPlanSplayInclinationRangeMax As NumericUpDown
    Friend WithEvents lblPropProfileSplayPosInclinationRange As Label
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayPosInclinationRangeMin As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMax As NumericUpDown
    Friend WithEvents txtPropProfileSplayNegInclinationRangeMin As NumericUpDown
    Friend WithEvents lblPropProfileSplayNegInclinationRange As Label
    Friend WithEvents ToolStripSeparator16 As ToolStripSeparator
    Friend WithEvents btnViewSplayShowMode As ToolStripDropDownButton
    Friend WithEvents btnViewSplayShowMode1 As ToolStripMenuItem
    Friend WithEvents btnViewSplayShowMode0 As ToolStripMenuItem
    Friend WithEvents chk3dPlotModelExtendedElevation As CheckBox
    Friend WithEvents chkPropCrossSectionShowOnlyCutSplay As CheckBox
    Friend WithEvents chkDesignPlotShowSplayMode As CheckBox
    Friend WithEvents lblPropCrossSectionMarkerUH As Label
    Friend WithEvents lblPropCrossSectionMarkerDH As Label
    Friend WithEvents txtPropCrossSectionMarkerDH As NumericUpDown
    Friend WithEvents lblPropCrossSectionMarkerDHUM As Label
    Friend WithEvents lblPropCrossSectionMarkerLW As Label
    Friend WithEvents lblPropCrossSectionMarkerRWUM As Label
    Friend WithEvents lblPropCrossSectionMarkerRW As Label
    Friend WithEvents txtPropCrossSectionMarkerLW As NumericUpDown
    Friend WithEvents txtPropCrossSectionMarkerRW As NumericUpDown
    Friend WithEvents lblPropCrossSectionMarkerLWUM As Label
    Friend WithEvents txtPropCrossSectionMarkerUH As NumericUpDown
    Friend WithEvents lblPropCrossSectionMarkerUHUM As Label
    Friend WithEvents lblPropCrossSectionMarkerL As Label
    Friend WithEvents chkPropCrossSectionMarkerUH As CheckBox
    Friend WithEvents chkPropCrossSectionMarkerDH As CheckBox
    Friend WithEvents chkPropCrossSectionMarkerLW As CheckBox
    Friend WithEvents chkPropCrossSectionMarkerRW As CheckBox
    Friend WithEvents pnlPropTrigpointsDistances As Panel
    Friend WithEvents lvPropTrigpointDistances As ListView
    Friend WithEvents colName As ColumnHeader
    Friend WithEvents colValue As ColumnHeader
    Friend WithEvents cmdPropTrigpointDistancesCalculate As Button
    Friend WithEvents lblPropTrigpointsDistances As Label
    Friend WithEvents chkPropTrigpointDistancesSplays As CheckBox
    Friend WithEvents btnViewRulers As ToolStripButton
    Friend WithEvents pnlPropVisibility As Panel
    Friend WithEvents cboPropCrossSectionRefStation As ComboBox
    Friend WithEvents lblPropCrossSectionRefStation As Label
    Friend WithEvents colTrigPoint As DataGridViewTextBoxColumn
    Friend WithEvents colX As DataGridViewTextBoxColumn
    Friend WithEvents colY As DataGridViewTextBoxColumn
    Friend WithEvents colZ As DataGridViewTextBoxColumn
    Friend WithEvents colGPS As DataGridViewImageColumn
    Friend WithEvents colNote As DataGridViewImageColumn
    Friend WithEvents colGeoLat As DataGridViewTextBoxColumn
    Friend WithEvents colGeoLon As DataGridViewTextBoxColumn
    Friend WithEvents colGeoAlt As DataGridViewTextBoxColumn
    Friend WithEvents tvLayers2 As BrightIdeasSoftware.TreeListView
    Friend WithEvents colLayersType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersCave As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersBranch As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersCaveBranchColor As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersHiddenInDesign As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersHiddenInPreview As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLayersPreview As BrightIdeasSoftware.OLVColumn
    Friend WithEvents cmdLayerSync As Button
    Friend WithEvents mnuLayersAndItemsCollapse As ToolStripMenuItem
    Friend WithEvents mnuLayersAndItemsCollapseAll As ToolStripMenuItem
    Friend WithEvents pnlConsole As Panel
    Friend WithEvents pnlDesigner As Panel
    Friend WithEvents pnlData As Panel
    Friend WithEvents pnlProperties As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripMenuItem6 As ToolStripSeparator
    Friend WithEvents mnuViewConsole As ToolStripMenuItem
    Friend WithEvents cboPropBindCrossSections As ComboBox
    Friend WithEvents lblPropBindCrossSections As Label
    Friend WithEvents cboMainBindCrossSections As ToolStripComboBox
    Friend WithEvents chkPropCrossSectionMarkerScaleEnabled As CheckBox
    Friend WithEvents chkPropCrossSectionMarkerDeltaAngleEnabled As CheckBox
    Friend WithEvents txtPropCrossSectionSplayProjectionVerticalAngle As NumericUpDown
    Friend WithEvents chkSegmentCalibration As CheckBox
    Friend WithEvents tvSegmentAttachments As BrightIdeasSoftware.ObjectListView
    Friend WithEvents colAttachmentIcon As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colAttachmentType As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colAttachmentName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colAttachmentNote As BrightIdeasSoftware.OLVColumn
    Friend WithEvents mnuAttachments As ContextMenuStrip
    Friend WithEvents mnuAttachmentsAdd As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem66 As ToolStripSeparator
    Friend WithEvents mnuAttachmentsDelete As ToolStripMenuItem
    Friend WithEvents mnuAttachmentsDeleteAll As ToolStripMenuItem
    Friend WithEvents mnuMapDropAttachment As ToolStripMenuItem
    Friend WithEvents pnlPropAttachment As Panel
    Friend WithEvents mnuAttachmentsOpen As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem84 As ToolStripSeparator
    Friend WithEvents picPropAttachmentPreview As PictureBox
    Friend WithEvents cmdPropAttachmentOpen As Button
    Friend WithEvents lblPropAttachment As Label
    Friend WithEvents cmdPropAttachmentBrowse As Button
    Friend WithEvents txtPropAttachmentName As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents lblPropAttachmentNote As Label
    Friend WithEvents txtPropAttachmentNote As TextBox
    Friend WithEvents ToolStripSeparator11 As ToolStripSeparator
    Friend WithEvents cboMainSessionList As ToolStripComboBox
    Friend WithEvents mnuFileNewFromTemplate As ToolStripMenuItem
    Friend WithEvents pnlStatusMasterSlave As ToolStripStatusLabel
    Friend WithEvents btnSepSnapToPoint As ToolStripSeparator
    Friend WithEvents btnSnapToPoint0 As ToolStripButton
    Friend WithEvents btnSnapToPoint1 As ToolStripButton
    Friend WithEvents btnSnapToPoint2 As ToolStripButton
    Friend WithEvents btnSnapToPointNone As ToolStripButton
    Friend WithEvents pnlPropLegend As Panel
    Friend WithEvents cPropLegendItems As cItemLegendPropertyControl
    Friend WithEvents mnuDesignItemLegend As ToolStripMenuItem
    Friend WithEvents mnuDesignItemLegendAddTo As ToolStripMenuItem
    Friend WithEvents chkPropVisibleByProfile As Button
    Friend WithEvents chkPropVisibleByScale As Button
    Friend WithEvents pnlDesignPrintOrExportAreaContainer As Panel
    Friend WithEvents lblPropAffinity As Label
    Friend WithEvents cboPropAffinity As ComboBox
    Friend WithEvents cDesignPrintOrExportArea As cDesignPrintOrExportAreaControl
    Friend WithEvents pnlPropScale As Panel
    Friend WithEvents cPropScaleItems As cItemScalePropertyControl
    Friend WithEvents pnlPropCompass As Panel
    Friend WithEvents cPropCompassItems As cItemCompassPropertyControl
    Friend WithEvents colSegmentSession As DataGridViewTextBoxColumn
    Friend WithEvents colCaveBranchColor As DataGridViewTextBoxColumn
    Friend WithEvents colFrom As DataGridViewTextBoxColumn
    Friend WithEvents colTo As DataGridViewTextBoxColumn
    Friend WithEvents colDist As DataGridViewTextBoxColumn
    Friend WithEvents colDirezione As DataGridViewTextBoxColumn
    Friend WithEvents colInclinazione As DataGridViewTextBoxColumn
    Friend WithEvents colSinistra As DataGridViewTextBoxColumn
    Friend WithEvents colDestra As DataGridViewTextBoxColumn
    Friend WithEvents colAlto As DataGridViewTextBoxColumn
    Friend WithEvents colBasso As DataGridViewTextBoxColumn
    Friend WithEvents colInverted As DataGridViewCheckBoxColumn
    Friend WithEvents colExclude As DataGridViewCheckBoxColumn
    Friend WithEvents colSegmentNote As DataGridViewImageColumn
    Friend WithEvents colSegmentImage As DataGridViewImageColumn
    Friend WithEvents mnuDesignItemPointConvertToSpline As ToolStripMenuItem
    Friend WithEvents chkPropSequenceLineType2 As CheckBox
    Friend WithEvents chkPropSequenceLineType1 As CheckBox
    Friend WithEvents chkPropSequenceLineType0 As CheckBox
    Friend WithEvents chkPropLineType2 As CheckBox
    Friend WithEvents chkPropLineType1 As CheckBox
    Friend WithEvents chkPropLineType0 As CheckBox
    Friend WithEvents chkPropSequenceLineTypeP As CheckBox
    Friend WithEvents btnSegmentAndTrigpointGridColor3 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem114 As ToolStripSeparator
    Friend WithEvents mnuViewLinkedSurveys As ToolStripMenuItem
    Friend WithEvents cDesignLinkedSurveys As cDesignLinkedSurveySelectorPropertyControl
    Friend WithEvents c3DLinkedSurveys As cDesignLinkedSurveySelectorPropertyControl
    Friend WithEvents cPropName As cItemNamePropertyControl
End Class
