<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmExportExcel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportExcel))
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExportCalculatedData = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExportColor = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExportNamedSplayStations = New DevExpress.XtraEditors.CheckEdit()
        Me.chkExportNamedSplayStationsData = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkExportCalculatedData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportNamedSplayStations.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkExportNamedSplayStationsData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'chkExportCalculatedData
        '
        resources.ApplyResources(Me.chkExportCalculatedData, "chkExportCalculatedData")
        Me.chkExportCalculatedData.Name = "chkExportCalculatedData"
        Me.chkExportCalculatedData.Properties.AutoWidth = True
        Me.chkExportCalculatedData.Properties.Caption = resources.GetString("chkExportCalculatedData.Properties.Caption")
        '
        'chkExportColor
        '
        resources.ApplyResources(Me.chkExportColor, "chkExportColor")
        Me.chkExportColor.Name = "chkExportColor"
        Me.chkExportColor.Properties.AutoWidth = True
        Me.chkExportColor.Properties.Caption = resources.GetString("chkExportColor.Properties.Caption")
        '
        'chkExportNamedSplayStations
        '
        resources.ApplyResources(Me.chkExportNamedSplayStations, "chkExportNamedSplayStations")
        Me.chkExportNamedSplayStations.Name = "chkExportNamedSplayStations"
        Me.chkExportNamedSplayStations.Properties.AutoWidth = True
        Me.chkExportNamedSplayStations.Properties.Caption = resources.GetString("chkExportNamedSplayStations.Properties.Caption")
        '
        'chkExportNamedSplayStationsData
        '
        resources.ApplyResources(Me.chkExportNamedSplayStationsData, "chkExportNamedSplayStationsData")
        Me.chkExportNamedSplayStationsData.Name = "chkExportNamedSplayStationsData"
        Me.chkExportNamedSplayStationsData.Properties.AutoWidth = True
        Me.chkExportNamedSplayStationsData.Properties.Caption = resources.GetString("chkExportNamedSplayStationsData.Properties.Caption")
        '
        'frmExportExcel
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkExportNamedSplayStationsData)
        Me.Controls.Add(Me.chkExportNamedSplayStations)
        Me.Controls.Add(Me.chkExportColor)
        Me.Controls.Add(Me.chkExportCalculatedData)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.exportfile
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportExcel"
        CType(Me.chkExportCalculatedData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportNamedSplayStations.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkExportNamedSplayStationsData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportCalculatedData As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportColor As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportNamedSplayStations As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkExportNamedSplayStationsData As DevExpress.XtraEditors.CheckEdit
End Class
