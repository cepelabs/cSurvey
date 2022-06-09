<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConnectionDefBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnectionDefBrowser))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSegment = New DevExpress.XtraEditors.LabelControl()
        Me.cboTrigpoints = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colTrigpointStation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTrigpointFromStation = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.cboTrigpoints.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.CausesValidation = False
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'lblSegment
        '
        Me.lblSegment.Appearance.Font = CType(resources.GetObject("lblSegment.Appearance.Font"), System.Drawing.Font)
        Me.lblSegment.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblSegment, "lblSegment")
        Me.lblSegment.Name = "lblSegment"
        '
        'cboTrigpoints
        '
        resources.ApplyResources(Me.cboTrigpoints, "cboTrigpoints")
        Me.cboTrigpoints.Name = "cboTrigpoints"
        Me.cboTrigpoints.Properties.Appearance.Font = CType(resources.GetObject("cboTrigpoints.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboTrigpoints.Properties.Appearance.Options.UseFont = True
        Me.cboTrigpoints.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboTrigpoints.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboTrigpoints.Properties.NullText = resources.GetString("cboTrigpoints.Properties.NullText")
        Me.cboTrigpoints.Properties.PopupSizeable = False
        Me.cboTrigpoints.Properties.PopupView = Me.SearchLookUpEdit1View
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colTrigpointStation, Me.colTrigpointFromStation})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        Me.SearchLookUpEdit1View.OptionsView.ShowIndicator = False
        Me.SearchLookUpEdit1View.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colTrigpointStation, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colTrigpointStation
        '
        resources.ApplyResources(Me.colTrigpointStation, "colTrigpointStation")
        Me.colTrigpointStation.FieldName = "Station"
        Me.colTrigpointStation.Name = "colTrigpointStation"
        '
        'colTrigpointFromStation
        '
        resources.ApplyResources(Me.colTrigpointFromStation, "colTrigpointFromStation")
        Me.colTrigpointFromStation.FieldName = "FromStation"
        Me.colTrigpointFromStation.Name = "colTrigpointFromStation"
        '
        'frmConnectionDefBrowser
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblSegment)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboTrigpoints)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnectionDefBrowser"
        CType(Me.cboTrigpoints.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSegment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboTrigpoints As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colTrigpointStation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTrigpointFromStation As DevExpress.XtraGrid.Columns.GridColumn
End Class
