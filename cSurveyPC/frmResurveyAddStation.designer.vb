Imports DevExpress.XtraEditors

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResurveyAddStation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyAddStation))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblScaleUM = New DevExpress.XtraEditors.LabelControl()
        Me.lblPrevStation = New DevExpress.XtraEditors.LabelControl()
        Me.lblPosition = New DevExpress.XtraEditors.LabelControl()
        Me.txtPosition = New DevExpress.XtraEditors.TextEdit()
        Me.txtScaleSize = New DevExpress.XtraEditors.SpinEdit()
        Me.cboPrevStation = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboMovedStation = New DevExpress.XtraEditors.LookUpEdit()
        Me.cboNewStation = New DevExpress.XtraEditors.LookUpEdit()
        Me.optNewStation = New DevExpress.XtraEditors.CheckEdit()
        Me.optMovedStation = New DevExpress.XtraEditors.CheckEdit()
        Me.optFirstScale = New DevExpress.XtraEditors.CheckEdit()
        Me.optSecondScale = New DevExpress.XtraEditors.CheckEdit()
        Me.optNorthBegin = New DevExpress.XtraEditors.CheckEdit()
        Me.optNorthEnd = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPrevStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMovedStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboNewStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optNewStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optMovedStation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optFirstScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optSecondScale.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optNorthBegin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optNorthEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
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
        Me.txtPosition.Properties.ReadOnly = True
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
        'optNewStation
        '
        resources.ApplyResources(Me.optNewStation, "optNewStation")
        Me.optNewStation.Name = "optNewStation"
        Me.optNewStation.Properties.AutoWidth = True
        Me.optNewStation.Properties.Caption = resources.GetString("optNewStation1.Properties.Caption")
        Me.optNewStation.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.optNewStation.Properties.RadioGroupIndex = 1
        '
        'optMovedStation
        '
        resources.ApplyResources(Me.optMovedStation, "optMovedStation")
        Me.optMovedStation.Name = "optMovedStation"
        Me.optMovedStation.Properties.AutoWidth = True
        Me.optMovedStation.Properties.Caption = resources.GetString("optMovedStation1.Properties.Caption")
        Me.optMovedStation.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.optMovedStation.Properties.RadioGroupIndex = 1
        Me.optMovedStation.TabStop = False
        '
        'optFirstScale
        '
        resources.ApplyResources(Me.optFirstScale, "optFirstScale")
        Me.optFirstScale.Name = "optFirstScale"
        Me.optFirstScale.Properties.AutoWidth = True
        Me.optFirstScale.Properties.Caption = resources.GetString("optFirstScale1.Properties.Caption")
        Me.optFirstScale.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.optFirstScale.Properties.RadioGroupIndex = 1
        Me.optFirstScale.TabStop = False
        '
        'optSecondScale
        '
        resources.ApplyResources(Me.optSecondScale, "optSecondScale")
        Me.optSecondScale.Name = "optSecondScale"
        Me.optSecondScale.Properties.AutoWidth = True
        Me.optSecondScale.Properties.Caption = resources.GetString("optSecondScale1.Properties.Caption")
        Me.optSecondScale.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.optSecondScale.Properties.RadioGroupIndex = 1
        Me.optSecondScale.TabStop = False
        '
        'optNorthBegin
        '
        resources.ApplyResources(Me.optNorthBegin, "optNorthBegin")
        Me.optNorthBegin.Name = "optNorthBegin"
        Me.optNorthBegin.Properties.AutoWidth = True
        Me.optNorthBegin.Properties.Caption = resources.GetString("optNorthBegin1.Properties.Caption")
        Me.optNorthBegin.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.optNorthBegin.Properties.RadioGroupIndex = 1
        Me.optNorthBegin.TabStop = False
        '
        'optNorthEnd
        '
        resources.ApplyResources(Me.optNorthEnd, "optNorthEnd")
        Me.optNorthEnd.Name = "optNorthEnd"
        Me.optNorthEnd.Properties.AutoWidth = True
        Me.optNorthEnd.Properties.Caption = resources.GetString("optNorthEnd1.Properties.Caption")
        Me.optNorthEnd.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.optNorthEnd.Properties.RadioGroupIndex = 1
        Me.optNorthEnd.TabStop = False
        '
        'frmResurveyAddStation
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.optNorthEnd)
        Me.Controls.Add(Me.optNorthBegin)
        Me.Controls.Add(Me.optSecondScale)
        Me.Controls.Add(Me.optFirstScale)
        Me.Controls.Add(Me.optMovedStation)
        Me.Controls.Add(Me.optNewStation)
        Me.Controls.Add(Me.cboNewStation)
        Me.Controls.Add(Me.cboMovedStation)
        Me.Controls.Add(Me.cboPrevStation)
        Me.Controls.Add(Me.txtScaleSize)
        Me.Controls.Add(Me.txtPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.lblPrevStation)
        Me.Controls.Add(Me.lblScaleUM)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.deletetablecells
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyAddStation"
        CType(Me.txtPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScaleSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPrevStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMovedStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboNewStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optNewStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optMovedStation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optFirstScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optSecondScale.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optNorthBegin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optNorthEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblScaleUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPrevStation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtScaleSize As SpinEdit
    Friend WithEvents cboPrevStation As LookUpEdit
    Friend WithEvents cboMovedStation As LookUpEdit
    Friend WithEvents cboNewStation As LookUpEdit
    Friend WithEvents optNewStation As CheckEdit
    Friend WithEvents optMovedStation As CheckEdit
    Friend WithEvents optFirstScale As CheckEdit
    Friend WithEvents optSecondScale As CheckEdit
    Friend WithEvents optNorthBegin As CheckEdit
    Friend WithEvents optNorthEnd As CheckEdit
End Class
