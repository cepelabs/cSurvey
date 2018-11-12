<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cAreaFromSequence
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cAreaFromSequence))
        Me.cboLineType = New System.Windows.Forms.ComboBox()
        Me.lblLineType = New System.Windows.Forms.Label()
        Me.lblReductionFactor = New System.Windows.Forms.Label()
        Me.txtReductionFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblPointReductionUM = New System.Windows.Forms.Label()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.lvItemToCreate = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.imlGeneric = New System.Windows.Forms.ImageList(Me.components)
        Me.lblItemToCreate = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        CType(Me.txtReductionFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboLineType
        '
        resources.ApplyResources(Me.cboLineType, "cboLineType")
        Me.cboLineType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLineType.FormattingEnabled = True
        Me.cboLineType.Items.AddRange(New Object() {resources.GetString("cboLineType.Items"), resources.GetString("cboLineType.Items1")})
        Me.cboLineType.Name = "cboLineType"
        '
        'lblLineType
        '
        resources.ApplyResources(Me.lblLineType, "lblLineType")
        Me.lblLineType.Name = "lblLineType"
        '
        'lblReductionFactor
        '
        resources.ApplyResources(Me.lblReductionFactor, "lblReductionFactor")
        Me.lblReductionFactor.Name = "lblReductionFactor"
        '
        'txtReductionFactor
        '
        resources.ApplyResources(Me.txtReductionFactor, "txtReductionFactor")
        Me.txtReductionFactor.DecimalPlaces = 2
        Me.txtReductionFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtReductionFactor.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtReductionFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtReductionFactor.Name = "txtReductionFactor"
        Me.txtReductionFactor.Value = New Decimal(New Integer() {2, 0, 0, 131072})
        '
        'lblPointReductionUM
        '
        resources.ApplyResources(Me.lblPointReductionUM, "lblPointReductionUM")
        Me.lblPointReductionUM.Name = "lblPointReductionUM"
        '
        'cmdCreate
        '
        resources.ApplyResources(Me.cmdCreate, "cmdCreate")
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.UseVisualStyleBackColor = True
        '
        'lvItemToCreate
        '
        resources.ApplyResources(Me.lvItemToCreate, "lvItemToCreate")
        Me.lvItemToCreate.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvItemToCreate.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvItemToCreate.FullRowSelect = True
        Me.lvItemToCreate.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvItemToCreate.HoverSelection = True
        Me.lvItemToCreate.MultiSelect = False
        Me.lvItemToCreate.Name = "lvItemToCreate"
        Me.lvItemToCreate.SmallImageList = Me.imlGeneric
        Me.lvItemToCreate.UseCompatibleStateImageBehavior = False
        Me.lvItemToCreate.View = System.Windows.Forms.View.Details
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
        'lblItemToCreate
        '
        resources.ApplyResources(Me.lblItemToCreate, "lblItemToCreate")
        Me.lblItemToCreate.Name = "lblItemToCreate"
        '
        'txtWidth
        '
        resources.ApplyResources(Me.txtWidth, "txtWidth")
        Me.txtWidth.DecimalPlaces = 2
        Me.txtWidth.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtWidth.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Value = New Decimal(New Integer() {5, 0, 0, 65536})
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblWidth
        '
        resources.ApplyResources(Me.lblWidth, "lblWidth")
        Me.lblWidth.Name = "lblWidth"
        '
        'cAreaFromSequence
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.lblItemToCreate)
        Me.Controls.Add(Me.lvItemToCreate)
        Me.Controls.Add(Me.cmdCreate)
        Me.Controls.Add(Me.txtReductionFactor)
        Me.Controls.Add(Me.lblPointReductionUM)
        Me.Controls.Add(Me.lblReductionFactor)
        Me.Controls.Add(Me.cboLineType)
        Me.Controls.Add(Me.lblLineType)
        Me.Name = "cAreaFromSequence"
        CType(Me.txtReductionFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboLineType As ComboBox
    Friend WithEvents lblLineType As Label
    Friend WithEvents lblReductionFactor As Label
    Friend WithEvents txtReductionFactor As NumericUpDown
    Friend WithEvents lblPointReductionUM As Label
    Friend WithEvents cmdCreate As Button
    Friend WithEvents lvItemToCreate As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents lblItemToCreate As Label
    Friend WithEvents txtWidth As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents imlGeneric As ImageList
End Class
