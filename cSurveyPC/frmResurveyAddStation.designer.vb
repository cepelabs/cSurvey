Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResurveyAddStation
    Inherits XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyAddStation))
        Me.optNewStation = New System.Windows.Forms.RadioButton()
        Me.optMovedStation = New System.Windows.Forms.RadioButton()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.optFirstScale = New System.Windows.Forms.RadioButton()
        Me.optSecondScale = New System.Windows.Forms.RadioButton()
        Me.lblScaleUM = New System.Windows.Forms.Label()
        Me.lblPrevStation = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtScaleSize = New DevExpress.XtraEditors.SpinEdit()
        Me.cboPrevStation = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboMovedStation = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboNewStation = New DevExpress.XtraEditors.LookUpEdit()
        Me.optNorthBegin = New System.Windows.Forms.RadioButton()
        Me.optNorthEnd = New System.Windows.Forms.RadioButton()
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrevStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMovedStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNewStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'optNewStation
        '
        resources.ApplyResources(Me.optNewStation, "optNewStation")
        Me.optNewStation.Checked = True
        Me.optNewStation.Name = "optNewStation"
        Me.optNewStation.TabStop = True
        Me.optNewStation.UseVisualStyleBackColor = True
        '
        'optMovedStation
        '
        resources.ApplyResources(Me.optMovedStation, "optMovedStation")
        Me.optMovedStation.Name = "optMovedStation"
        Me.optMovedStation.UseVisualStyleBackColor = True
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
        'optFirstScale
        '
        resources.ApplyResources(Me.optFirstScale, "optFirstScale")
        Me.optFirstScale.Name = "optFirstScale"
        Me.optFirstScale.UseVisualStyleBackColor = True
        '
        'optSecondScale
        '
        resources.ApplyResources(Me.optSecondScale, "optSecondScale")
        Me.optSecondScale.Name = "optSecondScale"
        Me.optSecondScale.UseVisualStyleBackColor = True
        '
        'lblScaleUM
        '
        resources.ApplyResources(Me.lblScaleUM, "lblScaleUM")
        Me.lblScaleUM.Name = "lblScaleUM"
        '
        'lblPrevStation
        '
        resources.ApplyResources(Me.lblPrevStation, "lblPrevStation")
        Me.lblPrevStation.Name = "lblPrevStation"
        '
        'lblPosition
        '
        resources.ApplyResources(Me.lblPosition, "lblPosition")
        Me.lblPosition.Name = "lblPosition"
        '
        'txtPosition
        '
        resources.ApplyResources(Me.txtPosition, "txtPosition")
        Me.txtPosition.Name = "txtPosition"
        Me.txtPosition.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtPosition, resources.GetString("txtPosition.ToolTip"))
        '
        'txtScaleSize
        '
        resources.ApplyResources(Me.txtScaleSize, "txtScaleSize")
        Me.txtScaleSize.Name = "txtScaleSize"
        Me.txtScaleSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtScaleSize.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtScaleSize.Properties.DisplayFormat.FormatString = "N2"
        Me.txtScaleSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleSize.Properties.EditFormat.FormatString = "N2"
        Me.txtScaleSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtScaleSize.Properties.Mask.EditMask = resources.GetString("txtScaleSize.Properties.Mask.EditMask")
        Me.tipDefault.SetToolTip(Me.txtScaleSize, resources.GetString("txtScaleSize.ToolTip"))
        '
        'cboPrevStation
        '
        resources.ApplyResources(Me.cboPrevStation, "cboPrevStation")
        Me.cboPrevStation.Name = "cboPrevStation"
        Me.cboPrevStation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboPrevStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboPrevStation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboPrevStation.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cboPrevStation.Properties.Columns"), resources.GetString("cboPrevStation.Properties.Columns1"), CType(resources.GetObject("cboPrevStation.Properties.Columns2"), Integer), CType(resources.GetObject("cboPrevStation.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cboPrevStation.Properties.Columns4"), CType(resources.GetObject("cboPrevStation.Properties.Columns5"), Boolean), CType(resources.GetObject("cboPrevStation.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("cboPrevStation.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("cboPrevStation.Properties.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.cboPrevStation.Properties.DisplayMember = "Name"
        Me.cboPrevStation.Properties.NullText = resources.GetString("cboPrevStation.Properties.NullText")
        Me.cboPrevStation.Properties.ShowHeader = False
        Me.cboPrevStation.Properties.ValueMember = "Name"
        '
        'cboMovedStation
        '
        resources.ApplyResources(Me.cboMovedStation, "cboMovedStation")
        Me.cboMovedStation.Name = "cboMovedStation"
        Me.cboMovedStation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboMovedStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboMovedStation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboMovedStation.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cboMovedStation.Properties.Columns"), resources.GetString("cboMovedStation.Properties.Columns1"), CType(resources.GetObject("cboMovedStation.Properties.Columns2"), Integer), CType(resources.GetObject("cboMovedStation.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cboMovedStation.Properties.Columns4"), CType(resources.GetObject("cboMovedStation.Properties.Columns5"), Boolean), CType(resources.GetObject("cboMovedStation.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("cboMovedStation.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("cboMovedStation.Properties.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.cboMovedStation.Properties.DisplayMember = "Name"
        Me.cboMovedStation.Properties.NullText = resources.GetString("cboMovedStation.Properties.NullText")
        Me.cboMovedStation.Properties.ShowHeader = False
        Me.cboMovedStation.Properties.ValueMember = "Name"
        '
        'cboNewStation
        '
        resources.ApplyResources(Me.cboNewStation, "cboNewStation")
        Me.cboNewStation.Name = "cboNewStation"
        Me.cboNewStation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.cboNewStation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboNewStation.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboNewStation.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cboNewStation.Properties.Columns"), resources.GetString("cboNewStation.Properties.Columns1"), CType(resources.GetObject("cboNewStation.Properties.Columns2"), Integer), CType(resources.GetObject("cboNewStation.Properties.Columns3"), DevExpress.Utils.FormatType), resources.GetString("cboNewStation.Properties.Columns4"), CType(resources.GetObject("cboNewStation.Properties.Columns5"), Boolean), CType(resources.GetObject("cboNewStation.Properties.Columns6"), DevExpress.Utils.HorzAlignment), CType(resources.GetObject("cboNewStation.Properties.Columns7"), DevExpress.Data.ColumnSortOrder), CType(resources.GetObject("cboNewStation.Properties.Columns8"), DevExpress.Utils.DefaultBoolean))})
        Me.cboNewStation.Properties.DisplayMember = "Name"
        Me.cboNewStation.Properties.NullText = resources.GetString("cboNewStation.Properties.NullText")
        Me.cboNewStation.Properties.ShowHeader = False
        Me.cboNewStation.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cboNewStation.Properties.ValueMember = "Name"
        '
        'optNorthBegin
        '
        resources.ApplyResources(Me.optNorthBegin, "optNorthBegin")
        Me.optNorthBegin.Name = "optNorthBegin"
        Me.optNorthBegin.UseVisualStyleBackColor = True
        '
        'optNorthEnd
        '
        resources.ApplyResources(Me.optNorthEnd, "optNorthEnd")
        Me.optNorthEnd.Name = "optNorthEnd"
        Me.optNorthEnd.UseVisualStyleBackColor = True
        '
        'frmResurveyAddStation
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.optNorthEnd)
        Me.Controls.Add(Me.optNorthBegin)
        Me.Controls.Add(Me.cboNewStation)
        Me.Controls.Add(Me.cboMovedStation)
        Me.Controls.Add(Me.cboPrevStation)
        Me.Controls.Add(Me.txtScaleSize)
        Me.Controls.Add(Me.txtPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.lblPrevStation)
        Me.Controls.Add(Me.lblScaleUM)
        Me.Controls.Add(Me.optSecondScale)
        Me.Controls.Add(Me.optFirstScale)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.optMovedStation)
        Me.Controls.Add(Me.optNewStation)
        Me.IconOptions.Icon = CType(resources.GetObject("frmResurveyAddStation.IconOptions.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyAddStation"
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrevStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMovedStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNewStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optNewStation As System.Windows.Forms.RadioButton
    Friend WithEvents optMovedStation As System.Windows.Forms.RadioButton
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents optFirstScale As System.Windows.Forms.RadioButton
    Friend WithEvents optSecondScale As System.Windows.Forms.RadioButton
    Friend WithEvents lblScaleUM As System.Windows.Forms.Label
    Friend WithEvents lblPrevStation As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtScaleSize As SpinEdit
    Friend WithEvents cboPrevStation As LookUpEdit
    Friend WithEvents cboMovedStation As LookUpEdit
    Friend WithEvents cboNewStation As LookUpEdit
    Friend WithEvents optNorthBegin As RadioButton
    Friend WithEvents optNorthEnd As RadioButton
End Class
