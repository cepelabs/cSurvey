<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurfaceAddWMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceAddWMS))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLayerRefresh = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvLayers = New System.Windows.Forms.ListView()
        Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSRSs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImageFormats = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblSRSOverride = New System.Windows.Forms.Label()
        Me.cboSRSOverride = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'lblPosition
        '
        resources.ApplyResources(Me.lblPosition, "lblPosition")
        Me.lblPosition.Name = "lblPosition"
        '
        'btnLayerRefresh
        '
        resources.ApplyResources(Me.btnLayerRefresh, "btnLayerRefresh")
        Me.btnLayerRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        Me.btnLayerRefresh.Name = "btnLayerRefresh"
        Me.tipDefault.SetToolTip(Me.btnLayerRefresh, resources.GetString("btnLayerRefresh.ToolTip"))
        Me.btnLayerRefresh.UseVisualStyleBackColor = True
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'txtURL
        '
        resources.ApplyResources(Me.txtURL, "txtURL")
        Me.txtURL.Name = "txtURL"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lvLayers
        '
        resources.ApplyResources(Me.lvLayers, "lvLayers")
        Me.lvLayers.CheckBoxes = True
        Me.lvLayers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colSRSs, Me.colImageFormats})
        Me.lvLayers.FullRowSelect = True
        Me.lvLayers.HideSelection = False
        Me.lvLayers.Name = "lvLayers"
        Me.lvLayers.UseCompatibleStateImageBehavior = False
        Me.lvLayers.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        resources.ApplyResources(Me.colName, "colName")
        '
        'colSRSs
        '
        resources.ApplyResources(Me.colSRSs, "colSRSs")
        '
        'colImageFormats
        '
        resources.ApplyResources(Me.colImageFormats, "colImageFormats")
        '
        'lblSRSOverride
        '
        resources.ApplyResources(Me.lblSRSOverride, "lblSRSOverride")
        Me.lblSRSOverride.Name = "lblSRSOverride"
        '
        'cboSRSOverride
        '
        Me.cboSRSOverride.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSRSOverride.FormattingEnabled = True
        Me.cboSRSOverride.Items.AddRange(New Object() {resources.GetString("cboSRSOverride.Items"), resources.GetString("cboSRSOverride.Items1"), resources.GetString("cboSRSOverride.Items2")})
        resources.ApplyResources(Me.cboSRSOverride, "cboSRSOverride")
        Me.cboSRSOverride.Name = "cboSRSOverride"
        '
        'frmSurfaceAddWMS
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblSRSOverride)
        Me.Controls.Add(Me.btnLayerRefresh)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.lvLayers)
        Me.Controls.Add(Me.cboSRSOverride)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmSurfaceAddWMS.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.map_wms
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceAddWMS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLayerRefresh As System.Windows.Forms.Button
    Friend WithEvents lvLayers As ListView
    Friend WithEvents colName As ColumnHeader
    Friend WithEvents colSRSs As ColumnHeader
    Friend WithEvents colImageFormats As ColumnHeader
    Friend WithEvents lblSRSOverride As Label
    Friend WithEvents cboSRSOverride As ComboBox
End Class
