<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSegmentBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSegmentBrowser))
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.lblSegment = New DevExpress.XtraEditors.LabelControl()
        Me.grdSegmentsView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colSegmentFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSegmentTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cboSegments = New DevExpress.XtraEditors.SearchLookUpEdit()
        CType(Me.grdSegmentsView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSegments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'grdSegmentsView
        '
        Me.grdSegmentsView.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colSegmentFrom, Me.colSegmentTo})
        Me.grdSegmentsView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.grdSegmentsView.Name = "grdSegmentsView"
        Me.grdSegmentsView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.grdSegmentsView.OptionsView.ShowGroupPanel = False
        Me.grdSegmentsView.OptionsView.ShowIndicator = False
        Me.grdSegmentsView.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colSegmentFrom, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colSegmentFrom
        '
        resources.ApplyResources(Me.colSegmentFrom, "colSegmentFrom")
        Me.colSegmentFrom.FieldName = "From"
        Me.colSegmentFrom.Name = "colSegmentFrom"
        '
        'colSegmentTo
        '
        resources.ApplyResources(Me.colSegmentTo, "colSegmentTo")
        Me.colSegmentTo.FieldName = "To"
        Me.colSegmentTo.Name = "colSegmentTo"
        '
        'cboSegments
        '
        resources.ApplyResources(Me.cboSegments, "cboSegments")
        Me.cboSegments.Name = "cboSegments"
        Me.cboSegments.Properties.Appearance.Font = CType(resources.GetObject("cboSegments.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboSegments.Properties.Appearance.Options.UseFont = True
        Me.cboSegments.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboSegments.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboSegments.Properties.NullText = resources.GetString("cboSegments.Properties.NullText")
        Me.cboSegments.Properties.PopupSizeable = False
        Me.cboSegments.Properties.PopupView = Me.grdSegmentsView
        Me.cboSegments.Properties.ShowClearButton = False
        '
        'frmSegmentBrowser
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblSegment)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboSegments)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSegmentBrowser"
        CType(Me.grdSegmentsView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSegments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblSegment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents grdSegmentsView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colSegmentFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSegmentTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cboSegments As DevExpress.XtraEditors.SearchLookUpEdit
End Class
