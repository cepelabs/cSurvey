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
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkExportCalculatedData = New System.Windows.Forms.CheckBox()
        Me.chkExportColor = New System.Windows.Forms.CheckBox()
        Me.chkExportNamedSplayStations = New System.Windows.Forms.CheckBox()
        Me.chkExportNamedSplayStationsData = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'chkExportCalculatedData
        '
        resources.ApplyResources(Me.chkExportCalculatedData, "chkExportCalculatedData")
        Me.chkExportCalculatedData.Name = "chkExportCalculatedData"
        Me.chkExportCalculatedData.UseVisualStyleBackColor = True
        '
        'chkExportColor
        '
        resources.ApplyResources(Me.chkExportColor, "chkExportColor")
        Me.chkExportColor.Name = "chkExportColor"
        Me.chkExportColor.UseVisualStyleBackColor = True
        '
        'chkExportNamedSplayStations
        '
        resources.ApplyResources(Me.chkExportNamedSplayStations, "chkExportNamedSplayStations")
        Me.chkExportNamedSplayStations.Name = "chkExportNamedSplayStations"
        Me.chkExportNamedSplayStations.UseVisualStyleBackColor = True
        '
        'chkExportNamedSplayStationsData
        '
        resources.ApplyResources(Me.chkExportNamedSplayStationsData, "chkExportNamedSplayStationsData")
        Me.chkExportNamedSplayStationsData.Name = "chkExportNamedSplayStationsData"
        Me.chkExportNamedSplayStationsData.UseVisualStyleBackColor = True
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportExcel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkExportCalculatedData As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportColor As System.Windows.Forms.CheckBox
    Friend WithEvents chkExportNamedSplayStations As CheckBox
    Friend WithEvents chkExportNamedSplayStationsData As CheckBox
End Class
