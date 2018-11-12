<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cSegmentProperties
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cSegmentProperties))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlSegment = New System.Windows.Forms.Panel()
        Me.pnlSegmentCaveBranches = New System.Windows.Forms.Panel()
        Me.pnlSegmentCaveBranchesColor = New System.Windows.Forms.Panel()
        Me.cboSegmentCaveBranchList = New System.Windows.Forms.ComboBox()
        Me.lblSegmentCave = New System.Windows.Forms.Label()
        Me.lblSegmentBranch = New System.Windows.Forms.Label()
        Me.cboSegmentCaveList = New System.Windows.Forms.ComboBox()
        Me.cboSegmentFrom = New System.Windows.Forms.ComboBox()
        Me.lblSegmentFrom = New System.Windows.Forms.Label()
        Me.tabSegmentProperty = New System.Windows.Forms.TabControl()
        Me.tabSegmentPropertyMain = New System.Windows.Forms.TabPage()
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
        Me.tabSegmentPropertyLayout = New System.Windows.Forms.TabPage()
        Me.cmdSegmentColorChange = New System.Windows.Forms.Button()
        Me.cmdSegmentColorReset = New System.Windows.Forms.Button()
        Me.picSegmentColor = New System.Windows.Forms.PictureBox()
        Me.lblSegmentColor = New System.Windows.Forms.Label()
        Me.tabSegmentPropertyNote = New System.Windows.Forms.TabPage()
        Me.txtSegmentNote = New System.Windows.Forms.TextBox()
        Me.tabSegmentPropertyImage = New System.Windows.Forms.TabPage()
        Me.cboSegmentTo = New System.Windows.Forms.ComboBox()
        Me.lblSegmentTo = New System.Windows.Forms.Label()
        Me.pnlSegmentSession = New System.Windows.Forms.Panel()
        Me.pnlSegmentSessionColor = New System.Windows.Forms.Panel()
        Me.cboSessionList = New System.Windows.Forms.ComboBox()
        Me.lblSession = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlSegment.SuspendLayout()
        Me.pnlSegmentCaveBranches.SuspendLayout()
        Me.tabSegmentProperty.SuspendLayout()
        Me.tabSegmentPropertyMain.SuspendLayout()
        Me.pnlSegmentSurfaceProfile.SuspendLayout()
        Me.tabSegmentPropertyData.SuspendLayout()
        Me.tabSegmentPropertyLayout.SuspendLayout()
        CType(Me.picSegmentColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSegmentPropertyNote.SuspendLayout()
        Me.pnlSegmentSession.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        '
        'pnlSegment
        '
        Me.pnlSegment.BackColor = System.Drawing.SystemColors.Control
        Me.pnlSegment.Controls.Add(Me.tabSegmentProperty)
        Me.pnlSegment.Controls.Add(Me.Panel1)
        Me.pnlSegment.Controls.Add(Me.pnlSegmentSession)
        Me.pnlSegment.Controls.Add(Me.pnlSegmentCaveBranches)
        Me.pnlSegment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSegment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSegment.Location = New System.Drawing.Point(0, 0)
        Me.pnlSegment.Name = "pnlSegment"
        Me.pnlSegment.Size = New System.Drawing.Size(502, 433)
        Me.pnlSegment.TabIndex = 14
        '
        'pnlSegmentCaveBranches
        '
        Me.pnlSegmentCaveBranches.Controls.Add(Me.pnlSegmentCaveBranchesColor)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.cboSegmentCaveBranchList)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.lblSegmentCave)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.lblSegmentBranch)
        Me.pnlSegmentCaveBranches.Controls.Add(Me.cboSegmentCaveList)
        Me.pnlSegmentCaveBranches.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSegmentCaveBranches.Location = New System.Drawing.Point(0, 0)
        Me.pnlSegmentCaveBranches.Name = "pnlSegmentCaveBranches"
        Me.pnlSegmentCaveBranches.Size = New System.Drawing.Size(502, 57)
        Me.pnlSegmentCaveBranches.TabIndex = 110
        '
        'pnlSegmentCaveBranchesColor
        '
        Me.pnlSegmentCaveBranchesColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSegmentCaveBranchesColor.Location = New System.Drawing.Point(0, 0)
        Me.pnlSegmentCaveBranchesColor.Name = "pnlSegmentCaveBranchesColor"
        Me.pnlSegmentCaveBranchesColor.Size = New System.Drawing.Size(16, 57)
        Me.pnlSegmentCaveBranchesColor.TabIndex = 110
        '
        'cboSegmentCaveBranchList
        '
        Me.cboSegmentCaveBranchList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSegmentCaveBranchList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentCaveBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentCaveBranchList.DropDownWidth = 255
        Me.cboSegmentCaveBranchList.Location = New System.Drawing.Point(73, 32)
        Me.cboSegmentCaveBranchList.Name = "cboSegmentCaveBranchList"
        Me.cboSegmentCaveBranchList.Size = New System.Drawing.Size(422, 21)
        Me.cboSegmentCaveBranchList.TabIndex = 2
        '
        'lblSegmentCave
        '
        Me.lblSegmentCave.AutoSize = True
        Me.lblSegmentCave.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentCave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentCave.Location = New System.Drawing.Point(22, 8)
        Me.lblSegmentCave.Name = "lblSegmentCave"
        Me.lblSegmentCave.Size = New System.Drawing.Size(42, 13)
        Me.lblSegmentCave.TabIndex = 0
        Me.lblSegmentCave.Text = "Grotta:"
        '
        'lblSegmentBranch
        '
        Me.lblSegmentBranch.AutoSize = True
        Me.lblSegmentBranch.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentBranch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentBranch.Location = New System.Drawing.Point(22, 35)
        Me.lblSegmentBranch.Name = "lblSegmentBranch"
        Me.lblSegmentBranch.Size = New System.Drawing.Size(38, 13)
        Me.lblSegmentBranch.TabIndex = 109
        Me.lblSegmentBranch.Text = "Ramo:"
        '
        'cboSegmentCaveList
        '
        Me.cboSegmentCaveList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSegmentCaveList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentCaveList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentCaveList.DropDownWidth = 255
        Me.cboSegmentCaveList.Location = New System.Drawing.Point(73, 5)
        Me.cboSegmentCaveList.Name = "cboSegmentCaveList"
        Me.cboSegmentCaveList.Size = New System.Drawing.Size(422, 21)
        Me.cboSegmentCaveList.TabIndex = 1
        '
        'cboSegmentFrom
        '
        Me.cboSegmentFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSegmentFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentFrom.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cboSegmentFrom.Location = New System.Drawing.Point(56, 8)
        Me.cboSegmentFrom.Name = "cboSegmentFrom"
        Me.cboSegmentFrom.Size = New System.Drawing.Size(65, 24)
        Me.cboSegmentFrom.TabIndex = 3
        '
        'lblSegmentFrom
        '
        Me.lblSegmentFrom.AutoSize = True
        Me.lblSegmentFrom.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentFrom.Location = New System.Drawing.Point(22, 13)
        Me.lblSegmentFrom.Name = "lblSegmentFrom"
        Me.lblSegmentFrom.Size = New System.Drawing.Size(24, 13)
        Me.lblSegmentFrom.TabIndex = 52
        Me.lblSegmentFrom.Text = "Da:"
        '
        'tabSegmentProperty
        '
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyMain)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyData)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyLayout)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyNote)
        Me.tabSegmentProperty.Controls.Add(Me.tabSegmentPropertyImage)
        Me.tabSegmentProperty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabSegmentProperty.ImageList = Me.iml
        Me.tabSegmentProperty.Location = New System.Drawing.Point(0, 139)
        Me.tabSegmentProperty.Name = "tabSegmentProperty"
        Me.tabSegmentProperty.SelectedIndex = 0
        Me.tabSegmentProperty.Size = New System.Drawing.Size(502, 294)
        Me.tabSegmentProperty.TabIndex = 12
        '
        'tabSegmentPropertyMain
        '
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
        Me.tabSegmentPropertyMain.ImageKey = "database.png"
        Me.tabSegmentPropertyMain.Location = New System.Drawing.Point(4, 24)
        Me.tabSegmentPropertyMain.Name = "tabSegmentPropertyMain"
        Me.tabSegmentPropertyMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSegmentPropertyMain.Size = New System.Drawing.Size(494, 266)
        Me.tabSegmentPropertyMain.TabIndex = 0
        Me.tabSegmentPropertyMain.Text = "Dati"
        Me.tabSegmentPropertyMain.UseVisualStyleBackColor = True
        '
        'pnlSegmentSurfaceProfile
        '
        Me.pnlSegmentSurfaceProfile.Controls.Add(Me.lblSegmentSurfaceProfile)
        Me.pnlSegmentSurfaceProfile.Controls.Add(Me.cboSegmentSurfaceProfileShow)
        Me.pnlSegmentSurfaceProfile.Controls.Add(Me.lblSegmentSurfaceProfileShow)
        Me.pnlSegmentSurfaceProfile.Location = New System.Drawing.Point(1, 271)
        Me.pnlSegmentSurfaceProfile.Name = "pnlSegmentSurfaceProfile"
        Me.pnlSegmentSurfaceProfile.Size = New System.Drawing.Size(228, 46)
        Me.pnlSegmentSurfaceProfile.TabIndex = 113
        '
        'lblSegmentSurfaceProfile
        '
        Me.lblSegmentSurfaceProfile.AutoSize = True
        Me.lblSegmentSurfaceProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentSurfaceProfile.Location = New System.Drawing.Point(0, 2)
        Me.lblSegmentSurfaceProfile.Name = "lblSegmentSurfaceProfile"
        Me.lblSegmentSurfaceProfile.Size = New System.Drawing.Size(115, 13)
        Me.lblSegmentSurfaceProfile.TabIndex = 112
        Me.lblSegmentSurfaceProfile.Text = "Profilo della superficie:"
        '
        'cboSegmentSurfaceProfileShow
        '
        Me.cboSegmentSurfaceProfileShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentSurfaceProfileShow.DropDownWidth = 320
        Me.cboSegmentSurfaceProfileShow.FormattingEnabled = True
        Me.cboSegmentSurfaceProfileShow.Items.AddRange(New Object() {"Predefinito", "Si", "No"})
        Me.cboSegmentSurfaceProfileShow.Location = New System.Drawing.Point(95, 21)
        Me.cboSegmentSurfaceProfileShow.Name = "cboSegmentSurfaceProfileShow"
        Me.cboSegmentSurfaceProfileShow.Size = New System.Drawing.Size(126, 21)
        Me.cboSegmentSurfaceProfileShow.TabIndex = 110
        '
        'lblSegmentSurfaceProfileShow
        '
        Me.lblSegmentSurfaceProfileShow.AutoSize = True
        Me.lblSegmentSurfaceProfileShow.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentSurfaceProfileShow.Location = New System.Drawing.Point(33, 25)
        Me.lblSegmentSurfaceProfileShow.Name = "lblSegmentSurfaceProfileShow"
        Me.lblSegmentSurfaceProfileShow.Size = New System.Drawing.Size(56, 13)
        Me.lblSegmentSurfaceProfileShow.TabIndex = 111
        Me.lblSegmentSurfaceProfileShow.Text = "Visualizza:"
        '
        'chkSegmentVirtual
        '
        Me.chkSegmentVirtual.AutoSize = True
        Me.chkSegmentVirtual.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentVirtual.Location = New System.Drawing.Point(3, 247)
        Me.chkSegmentVirtual.Name = "chkSegmentVirtual"
        Me.chkSegmentVirtual.Size = New System.Drawing.Size(62, 17)
        Me.chkSegmentVirtual.TabIndex = 100
        Me.chkSegmentVirtual.Text = "Virtuale"
        Me.chkSegmentVirtual.UseVisualStyleBackColor = True
        '
        'chkSegmentUnbindable
        '
        Me.chkSegmentUnbindable.AutoSize = True
        Me.chkSegmentUnbindable.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentUnbindable.Location = New System.Drawing.Point(3, 224)
        Me.chkSegmentUnbindable.Name = "chkSegmentUnbindable"
        Me.chkSegmentUnbindable.Size = New System.Drawing.Size(185, 17)
        Me.chkSegmentUnbindable.TabIndex = 99
        Me.chkSegmentUnbindable.Text = "Non collegabile agli oggetti grafici"
        Me.chkSegmentUnbindable.UseVisualStyleBackColor = True
        '
        'chkSegmentSurface
        '
        Me.chkSegmentSurface.AutoSize = True
        Me.chkSegmentSurface.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentSurface.Location = New System.Drawing.Point(14, 201)
        Me.chkSegmentSurface.Name = "chkSegmentSurface"
        Me.chkSegmentSurface.Size = New System.Drawing.Size(73, 17)
        Me.chkSegmentSurface.TabIndex = 12
        Me.chkSegmentSurface.Text = "Superficie"
        Me.chkSegmentSurface.UseVisualStyleBackColor = True
        '
        'chkSegmentDuplicate
        '
        Me.chkSegmentDuplicate.AutoSize = True
        Me.chkSegmentDuplicate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentDuplicate.Location = New System.Drawing.Point(14, 178)
        Me.chkSegmentDuplicate.Name = "chkSegmentDuplicate"
        Me.chkSegmentDuplicate.Size = New System.Drawing.Size(70, 17)
        Me.chkSegmentDuplicate.TabIndex = 11
        Me.chkSegmentDuplicate.Text = "Duplicato"
        Me.chkSegmentDuplicate.UseVisualStyleBackColor = True
        '
        'chkSegmentSplay
        '
        Me.chkSegmentSplay.AutoSize = True
        Me.chkSegmentSplay.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentSplay.Location = New System.Drawing.Point(14, 155)
        Me.chkSegmentSplay.Name = "chkSegmentSplay"
        Me.chkSegmentSplay.Size = New System.Drawing.Size(52, 17)
        Me.chkSegmentSplay.TabIndex = 10
        Me.chkSegmentSplay.Text = "Splay"
        Me.chkSegmentSplay.UseVisualStyleBackColor = True
        '
        'cboSegmentDirection
        '
        Me.cboSegmentDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentDirection.DropDownWidth = 320
        Me.cboSegmentDirection.FormattingEnabled = True
        Me.cboSegmentDirection.Items.AddRange(New Object() {"Destra", "Sinistra"})
        Me.cboSegmentDirection.Location = New System.Drawing.Point(95, 103)
        Me.cboSegmentDirection.Name = "cboSegmentDirection"
        Me.cboSegmentDirection.Size = New System.Drawing.Size(126, 21)
        Me.cboSegmentDirection.TabIndex = 8
        '
        'txtSegmentRight
        '
        Me.txtSegmentRight.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentRight.Location = New System.Drawing.Point(54, 70)
        Me.txtSegmentRight.Name = "txtSegmentRight"
        Me.txtSegmentRight.Size = New System.Drawing.Size(48, 20)
        Me.txtSegmentRight.TabIndex = 4
        Me.txtSegmentRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentRight.WordWrap = False
        '
        'txtSegmentUp
        '
        Me.txtSegmentUp.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentUp.Location = New System.Drawing.Point(122, 70)
        Me.txtSegmentUp.Name = "txtSegmentUp"
        Me.txtSegmentUp.Size = New System.Drawing.Size(48, 20)
        Me.txtSegmentUp.TabIndex = 5
        Me.txtSegmentUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentUp.WordWrap = False
        '
        'txtSegmentLeft
        '
        Me.txtSegmentLeft.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentLeft.Location = New System.Drawing.Point(3, 70)
        Me.txtSegmentLeft.Name = "txtSegmentLeft"
        Me.txtSegmentLeft.Size = New System.Drawing.Size(48, 20)
        Me.txtSegmentLeft.TabIndex = 3
        Me.txtSegmentLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentLeft.WordWrap = False
        '
        'chkSegmentExclude
        '
        Me.chkSegmentExclude.AutoSize = True
        Me.chkSegmentExclude.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentExclude.Location = New System.Drawing.Point(3, 132)
        Me.chkSegmentExclude.Name = "chkSegmentExclude"
        Me.chkSegmentExclude.Size = New System.Drawing.Size(185, 17)
        Me.chkSegmentExclude.TabIndex = 9
        Me.chkSegmentExclude.Text = "Escludi segmento dalle statistiche"
        Me.chkSegmentExclude.UseVisualStyleBackColor = True
        '
        'txtSegmentBearing
        '
        Me.txtSegmentBearing.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentBearing.Location = New System.Drawing.Point(77, 25)
        Me.txtSegmentBearing.Name = "txtSegmentBearing"
        Me.txtSegmentBearing.Size = New System.Drawing.Size(71, 20)
        Me.txtSegmentBearing.TabIndex = 1
        Me.txtSegmentBearing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentBearing.WordWrap = False
        '
        'txtSegmentDown
        '
        Me.txtSegmentDown.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentDown.Location = New System.Drawing.Point(173, 70)
        Me.txtSegmentDown.Name = "txtSegmentDown"
        Me.txtSegmentDown.Size = New System.Drawing.Size(48, 20)
        Me.txtSegmentDown.TabIndex = 6
        Me.txtSegmentDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentDown.WordWrap = False
        '
        'lblSegmentDx
        '
        Me.lblSegmentDx.AutoSize = True
        Me.lblSegmentDx.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentDx.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentDx.Location = New System.Drawing.Point(54, 51)
        Me.lblSegmentDx.Name = "lblSegmentDx"
        Me.lblSegmentDx.Size = New System.Drawing.Size(43, 13)
        Me.lblSegmentDx.TabIndex = 85
        Me.lblSegmentDx.Text = "Destra:"
        '
        'txtSegmentDistance
        '
        Me.txtSegmentDistance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentDistance.Location = New System.Drawing.Point(3, 25)
        Me.txtSegmentDistance.Name = "txtSegmentDistance"
        Me.txtSegmentDistance.Size = New System.Drawing.Size(71, 20)
        Me.txtSegmentDistance.TabIndex = 0
        Me.txtSegmentDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentDistance.WordWrap = False
        '
        'lblSegmentTop
        '
        Me.lblSegmentTop.AutoSize = True
        Me.lblSegmentTop.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentTop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentTop.Location = New System.Drawing.Point(122, 51)
        Me.lblSegmentTop.Name = "lblSegmentTop"
        Me.lblSegmentTop.Size = New System.Drawing.Size(30, 13)
        Me.lblSegmentTop.TabIndex = 91
        Me.lblSegmentTop.Text = "Alto:"
        '
        'lblSegmentDistance
        '
        Me.lblSegmentDistance.AutoSize = True
        Me.lblSegmentDistance.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentDistance.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentDistance.Location = New System.Drawing.Point(3, 6)
        Me.lblSegmentDistance.Name = "lblSegmentDistance"
        Me.lblSegmentDistance.Size = New System.Drawing.Size(52, 13)
        Me.lblSegmentDistance.TabIndex = 86
        Me.lblSegmentDistance.Text = "Distanza:"
        '
        'lblSegmentSx
        '
        Me.lblSegmentSx.AutoSize = True
        Me.lblSegmentSx.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentSx.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentSx.Location = New System.Drawing.Point(4, 51)
        Me.lblSegmentSx.Name = "lblSegmentSx"
        Me.lblSegmentSx.Size = New System.Drawing.Size(46, 13)
        Me.lblSegmentSx.TabIndex = 87
        Me.lblSegmentSx.Text = "Sinistra:"
        '
        'lblSegmentBearing
        '
        Me.lblSegmentBearing.AutoSize = True
        Me.lblSegmentBearing.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentBearing.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentBearing.Location = New System.Drawing.Point(77, 6)
        Me.lblSegmentBearing.Name = "lblSegmentBearing"
        Me.lblSegmentBearing.Size = New System.Drawing.Size(43, 13)
        Me.lblSegmentBearing.TabIndex = 90
        Me.lblSegmentBearing.Text = "Azimut:"
        '
        'lblSegmentBottom
        '
        Me.lblSegmentBottom.AutoSize = True
        Me.lblSegmentBottom.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentBottom.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentBottom.Location = New System.Drawing.Point(173, 51)
        Me.lblSegmentBottom.Name = "lblSegmentBottom"
        Me.lblSegmentBottom.Size = New System.Drawing.Size(39, 13)
        Me.lblSegmentBottom.TabIndex = 89
        Me.lblSegmentBottom.Text = "Basso:"
        '
        'txtSegmentInclination
        '
        Me.txtSegmentInclination.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.txtSegmentInclination.Location = New System.Drawing.Point(150, 25)
        Me.txtSegmentInclination.Name = "txtSegmentInclination"
        Me.txtSegmentInclination.Size = New System.Drawing.Size(71, 20)
        Me.txtSegmentInclination.TabIndex = 2
        Me.txtSegmentInclination.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSegmentInclination.WordWrap = False
        '
        'lblSegmentInclination
        '
        Me.lblSegmentInclination.AutoSize = True
        Me.lblSegmentInclination.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentInclination.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentInclination.Location = New System.Drawing.Point(150, 6)
        Me.lblSegmentInclination.Name = "lblSegmentInclination"
        Me.lblSegmentInclination.Size = New System.Drawing.Size(67, 13)
        Me.lblSegmentInclination.TabIndex = 88
        Me.lblSegmentInclination.Text = "Inclinazione:"
        '
        'lblSegmentDirection
        '
        Me.lblSegmentDirection.AutoSize = True
        Me.lblSegmentDirection.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentDirection.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentDirection.Location = New System.Drawing.Point(0, 105)
        Me.lblSegmentDirection.Name = "lblSegmentDirection"
        Me.lblSegmentDirection.Size = New System.Drawing.Size(89, 13)
        Me.lblSegmentDirection.TabIndex = 98
        Me.lblSegmentDirection.Text = "Verso di disegno:"
        '
        'chkSegmentInverted
        '
        Me.chkSegmentInverted.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.chkSegmentInverted.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkSegmentInverted.Location = New System.Drawing.Point(3, 104)
        Me.chkSegmentInverted.Name = "chkSegmentInverted"
        Me.chkSegmentInverted.Size = New System.Drawing.Size(218, 17)
        Me.chkSegmentInverted.TabIndex = 7
        Me.chkSegmentInverted.Text = "Inverti verso di disegno in sezione"
        '
        'tabSegmentPropertyData
        '
        Me.tabSegmentPropertyData.Controls.Add(Me.prpSegmentDataProperties)
        Me.tabSegmentPropertyData.ImageKey = "database_user.png"
        Me.tabSegmentPropertyData.Location = New System.Drawing.Point(4, 24)
        Me.tabSegmentPropertyData.Name = "tabSegmentPropertyData"
        Me.tabSegmentPropertyData.Size = New System.Drawing.Size(494, 266)
        Me.tabSegmentPropertyData.TabIndex = 8
        Me.tabSegmentPropertyData.Text = "Utente"
        Me.tabSegmentPropertyData.UseVisualStyleBackColor = True
        '
        'prpSegmentDataProperties
        '
        Me.prpSegmentDataProperties.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.prpSegmentDataProperties.CommandsVisibleIfAvailable = False
        Me.prpSegmentDataProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prpSegmentDataProperties.HelpVisible = False
        Me.prpSegmentDataProperties.Location = New System.Drawing.Point(0, 0)
        Me.prpSegmentDataProperties.Name = "prpSegmentDataProperties"
        Me.prpSegmentDataProperties.Size = New System.Drawing.Size(494, 266)
        Me.prpSegmentDataProperties.TabIndex = 0
        Me.prpSegmentDataProperties.ToolbarVisible = False
        '
        'tabSegmentPropertyLayout
        '
        Me.tabSegmentPropertyLayout.Controls.Add(Me.cmdSegmentColorChange)
        Me.tabSegmentPropertyLayout.Controls.Add(Me.cmdSegmentColorReset)
        Me.tabSegmentPropertyLayout.Controls.Add(Me.picSegmentColor)
        Me.tabSegmentPropertyLayout.Controls.Add(Me.lblSegmentColor)
        Me.tabSegmentPropertyLayout.ImageKey = "paintbrush.png"
        Me.tabSegmentPropertyLayout.Location = New System.Drawing.Point(4, 24)
        Me.tabSegmentPropertyLayout.Name = "tabSegmentPropertyLayout"
        Me.tabSegmentPropertyLayout.Size = New System.Drawing.Size(494, 266)
        Me.tabSegmentPropertyLayout.TabIndex = 7
        Me.tabSegmentPropertyLayout.Text = "Aspetto"
        Me.tabSegmentPropertyLayout.UseVisualStyleBackColor = True
        '
        'cmdSegmentColorChange
        '
        Me.cmdSegmentColorChange.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSegmentColorChange.Location = New System.Drawing.Point(95, 9)
        Me.cmdSegmentColorChange.Name = "cmdSegmentColorChange"
        Me.cmdSegmentColorChange.Size = New System.Drawing.Size(30, 21)
        Me.cmdSegmentColorChange.TabIndex = 98
        Me.cmdSegmentColorChange.Text = "..."
        Me.cmdSegmentColorChange.UseVisualStyleBackColor = True
        '
        'cmdSegmentColorReset
        '
        Me.cmdSegmentColorReset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdSegmentColorReset.Location = New System.Drawing.Point(131, 9)
        Me.cmdSegmentColorReset.Name = "cmdSegmentColorReset"
        Me.cmdSegmentColorReset.Size = New System.Drawing.Size(30, 21)
        Me.cmdSegmentColorReset.TabIndex = 99
        Me.cmdSegmentColorReset.Text = "Predefinito"
        Me.cmdSegmentColorReset.UseVisualStyleBackColor = True
        '
        'picSegmentColor
        '
        Me.picSegmentColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picSegmentColor.Location = New System.Drawing.Point(57, 9)
        Me.picSegmentColor.Name = "picSegmentColor"
        Me.picSegmentColor.Size = New System.Drawing.Size(32, 21)
        Me.picSegmentColor.TabIndex = 102
        Me.picSegmentColor.TabStop = False
        '
        'lblSegmentColor
        '
        Me.lblSegmentColor.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentColor.Location = New System.Drawing.Point(7, 13)
        Me.lblSegmentColor.Name = "lblSegmentColor"
        Me.lblSegmentColor.Size = New System.Drawing.Size(44, 17)
        Me.lblSegmentColor.TabIndex = 101
        Me.lblSegmentColor.Text = "Colore:"
        '
        'tabSegmentPropertyNote
        '
        Me.tabSegmentPropertyNote.Controls.Add(Me.txtSegmentNote)
        Me.tabSegmentPropertyNote.ImageKey = "note.png"
        Me.tabSegmentPropertyNote.Location = New System.Drawing.Point(4, 24)
        Me.tabSegmentPropertyNote.Name = "tabSegmentPropertyNote"
        Me.tabSegmentPropertyNote.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSegmentPropertyNote.Size = New System.Drawing.Size(494, 266)
        Me.tabSegmentPropertyNote.TabIndex = 3
        Me.tabSegmentPropertyNote.Text = "Note"
        Me.tabSegmentPropertyNote.UseVisualStyleBackColor = True
        '
        'txtSegmentNote
        '
        Me.txtSegmentNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSegmentNote.Location = New System.Drawing.Point(3, 3)
        Me.txtSegmentNote.Multiline = True
        Me.txtSegmentNote.Name = "txtSegmentNote"
        Me.txtSegmentNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSegmentNote.Size = New System.Drawing.Size(488, 260)
        Me.txtSegmentNote.TabIndex = 0
        Me.txtSegmentNote.WordWrap = False
        '
        'tabSegmentPropertyImage
        '
        Me.tabSegmentPropertyImage.ImageKey = "image.png"
        Me.tabSegmentPropertyImage.Location = New System.Drawing.Point(4, 24)
        Me.tabSegmentPropertyImage.Name = "tabSegmentPropertyImage"
        Me.tabSegmentPropertyImage.Size = New System.Drawing.Size(494, 255)
        Me.tabSegmentPropertyImage.TabIndex = 5
        Me.tabSegmentPropertyImage.Text = "Immagini"
        Me.tabSegmentPropertyImage.UseVisualStyleBackColor = True
        '
        'cboSegmentTo
        '
        Me.cboSegmentTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSegmentTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cboSegmentTo.Location = New System.Drawing.Point(159, 8)
        Me.cboSegmentTo.Name = "cboSegmentTo"
        Me.cboSegmentTo.Size = New System.Drawing.Size(65, 24)
        Me.cboSegmentTo.TabIndex = 4
        '
        'lblSegmentTo
        '
        Me.lblSegmentTo.AutoSize = True
        Me.lblSegmentTo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSegmentTo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSegmentTo.Location = New System.Drawing.Point(129, 13)
        Me.lblSegmentTo.Name = "lblSegmentTo"
        Me.lblSegmentTo.Size = New System.Drawing.Size(18, 13)
        Me.lblSegmentTo.TabIndex = 2
        Me.lblSegmentTo.Text = "A:"
        '
        'pnlSegmentSession
        '
        Me.pnlSegmentSession.Controls.Add(Me.pnlSegmentSessionColor)
        Me.pnlSegmentSession.Controls.Add(Me.cboSessionList)
        Me.pnlSegmentSession.Controls.Add(Me.lblSession)
        Me.pnlSegmentSession.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSegmentSession.Location = New System.Drawing.Point(0, 57)
        Me.pnlSegmentSession.Name = "pnlSegmentSession"
        Me.pnlSegmentSession.Size = New System.Drawing.Size(502, 44)
        Me.pnlSegmentSession.TabIndex = 111
        '
        'pnlSegmentSessionColor
        '
        Me.pnlSegmentSessionColor.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSegmentSessionColor.Location = New System.Drawing.Point(0, 0)
        Me.pnlSegmentSessionColor.Name = "pnlSegmentSessionColor"
        Me.pnlSegmentSessionColor.Size = New System.Drawing.Size(16, 44)
        Me.pnlSegmentSessionColor.TabIndex = 111
        '
        'cboSessionList
        '
        Me.cboSessionList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboSessionList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSessionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSessionList.DropDownWidth = 255
        Me.cboSessionList.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboSessionList.ItemHeight = 26
        Me.cboSessionList.Location = New System.Drawing.Point(73, 6)
        Me.cboSessionList.Name = "cboSessionList"
        Me.cboSessionList.Size = New System.Drawing.Size(422, 32)
        Me.cboSessionList.TabIndex = 0
        '
        'lblSession
        '
        Me.lblSession.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblSession.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSession.Location = New System.Drawing.Point(22, 9)
        Me.lblSession.Name = "lblSession"
        Me.lblSession.Size = New System.Drawing.Size(58, 17)
        Me.lblSession.TabIndex = 104
        Me.lblSession.Text = "Sessione:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboSegmentTo)
        Me.Panel1.Controls.Add(Me.lblSegmentTo)
        Me.Panel1.Controls.Add(Me.cboSegmentFrom)
        Me.Panel1.Controls.Add(Me.lblSegmentFrom)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 101)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(502, 38)
        Me.Panel1.TabIndex = 112
        '
        'cSegmentProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlSegment)
        Me.Name = "cSegmentProperties"
        Me.Size = New System.Drawing.Size(502, 433)
        Me.pnlSegment.ResumeLayout(False)
        Me.pnlSegmentCaveBranches.ResumeLayout(False)
        Me.pnlSegmentCaveBranches.PerformLayout()
        Me.tabSegmentProperty.ResumeLayout(False)
        Me.tabSegmentPropertyMain.ResumeLayout(False)
        Me.tabSegmentPropertyMain.PerformLayout()
        Me.pnlSegmentSurfaceProfile.ResumeLayout(False)
        Me.pnlSegmentSurfaceProfile.PerformLayout()
        Me.tabSegmentPropertyData.ResumeLayout(False)
        Me.tabSegmentPropertyLayout.ResumeLayout(False)
        CType(Me.picSegmentColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSegmentPropertyNote.ResumeLayout(False)
        Me.tabSegmentPropertyNote.PerformLayout()
        Me.pnlSegmentSession.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents iml As ImageList
    Friend WithEvents pnlSegment As Panel
    Friend WithEvents tabSegmentProperty As TabControl
    Friend WithEvents tabSegmentPropertyMain As TabPage
    Friend WithEvents pnlSegmentSurfaceProfile As Panel
    Friend WithEvents lblSegmentSurfaceProfile As Label
    Friend WithEvents cboSegmentSurfaceProfileShow As ComboBox
    Friend WithEvents lblSegmentSurfaceProfileShow As Label
    Friend WithEvents chkSegmentVirtual As CheckBox
    Friend WithEvents chkSegmentUnbindable As CheckBox
    Friend WithEvents chkSegmentSurface As CheckBox
    Friend WithEvents chkSegmentDuplicate As CheckBox
    Friend WithEvents chkSegmentSplay As CheckBox
    Friend WithEvents cboSegmentDirection As ComboBox
    Friend WithEvents txtSegmentRight As TextBox
    Friend WithEvents txtSegmentUp As TextBox
    Friend WithEvents txtSegmentLeft As TextBox
    Friend WithEvents chkSegmentExclude As CheckBox
    Friend WithEvents txtSegmentBearing As TextBox
    Friend WithEvents txtSegmentDown As TextBox
    Friend WithEvents lblSegmentDx As Label
    Friend WithEvents txtSegmentDistance As TextBox
    Friend WithEvents lblSegmentTop As Label
    Friend WithEvents lblSegmentDistance As Label
    Friend WithEvents lblSegmentSx As Label
    Friend WithEvents lblSegmentBearing As Label
    Friend WithEvents lblSegmentBottom As Label
    Friend WithEvents txtSegmentInclination As TextBox
    Friend WithEvents lblSegmentInclination As Label
    Friend WithEvents lblSegmentDirection As Label
    Friend WithEvents chkSegmentInverted As CheckBox
    Friend WithEvents tabSegmentPropertyData As TabPage
    Friend WithEvents prpSegmentDataProperties As PropertyGrid
    Friend WithEvents tabSegmentPropertyLayout As TabPage
    Friend WithEvents cmdSegmentColorChange As Button
    Friend WithEvents cmdSegmentColorReset As Button
    Friend WithEvents picSegmentColor As PictureBox
    Friend WithEvents lblSegmentColor As Label
    Friend WithEvents tabSegmentPropertyNote As TabPage
    Friend WithEvents txtSegmentNote As TextBox
    Friend WithEvents tabSegmentPropertyImage As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboSegmentTo As ComboBox
    Friend WithEvents lblSegmentTo As Label
    Friend WithEvents cboSegmentFrom As ComboBox
    Friend WithEvents lblSegmentFrom As Label
    Friend WithEvents pnlSegmentSession As Panel
    Friend WithEvents pnlSegmentSessionColor As Panel
    Friend WithEvents cboSessionList As ComboBox
    Friend WithEvents lblSession As Label
    Friend WithEvents pnlSegmentCaveBranches As Panel
    Friend WithEvents pnlSegmentCaveBranchesColor As Panel
    Friend WithEvents cboSegmentCaveBranchList As ComboBox
    Friend WithEvents lblSegmentCave As Label
    Friend WithEvents lblSegmentBranch As Label
    Friend WithEvents cboSegmentCaveList As ComboBox
End Class
