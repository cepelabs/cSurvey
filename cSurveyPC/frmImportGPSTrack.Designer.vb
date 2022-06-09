<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportGPSTrack
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportGPSTrack))
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkGPSImportWaypoint = New System.Windows.Forms.CheckBox()
        Me.cboGPSImportWaypointMode = New System.Windows.Forms.ComboBox()
        Me.chkGPSImportCreateCaveForWaypoint = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkGPSImportCreateStationLinks = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.ReadOnly = True
        Me.tipDefault.SetToolTip(Me.txtFilename, resources.GetString("txtFilename.ToolTip"))
        '
        'lblFilename
        '
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
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
        'chkGPSImportWaypoint
        '
        resources.ApplyResources(Me.chkGPSImportWaypoint, "chkGPSImportWaypoint")
        Me.chkGPSImportWaypoint.Name = "chkGPSImportWaypoint"
        Me.chkGPSImportWaypoint.UseVisualStyleBackColor = True
        '
        'cboGPSImportWaypointMode
        '
        resources.ApplyResources(Me.cboGPSImportWaypointMode, "cboGPSImportWaypointMode")
        Me.cboGPSImportWaypointMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGPSImportWaypointMode.DropDownWidth = 320
        Me.cboGPSImportWaypointMode.FormattingEnabled = True
        Me.cboGPSImportWaypointMode.Items.AddRange(New Object() {resources.GetString("cboGPSImportWaypointMode.Items"), resources.GetString("cboGPSImportWaypointMode.Items1")})
        Me.cboGPSImportWaypointMode.Name = "cboGPSImportWaypointMode"
        '
        'chkGPSImportCreateCaveForWaypoint
        '
        resources.ApplyResources(Me.chkGPSImportCreateCaveForWaypoint, "chkGPSImportCreateCaveForWaypoint")
        Me.chkGPSImportCreateCaveForWaypoint.Name = "chkGPSImportCreateCaveForWaypoint"
        Me.chkGPSImportCreateCaveForWaypoint.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'chkGPSImportCreateStationLinks
        '
        resources.ApplyResources(Me.chkGPSImportCreateStationLinks, "chkGPSImportCreateStationLinks")
        Me.chkGPSImportCreateStationLinks.Name = "chkGPSImportCreateStationLinks"
        Me.chkGPSImportCreateStationLinks.UseVisualStyleBackColor = True
        '
        'frmImportGPSTrack
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.chkGPSImportCreateStationLinks)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkGPSImportCreateCaveForWaypoint)
        Me.Controls.Add(Me.cboGPSImportWaypointMode)
        Me.Controls.Add(Me.chkGPSImportWaypoint)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportGPSTrack.IconOptions.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportGPSTrack"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents chkGPSImportWaypoint As System.Windows.Forms.CheckBox
    Friend WithEvents cboGPSImportWaypointMode As System.Windows.Forms.ComboBox
    Friend WithEvents chkGPSImportCreateCaveForWaypoint As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkGPSImportCreateStationLinks As System.Windows.Forms.CheckBox
End Class
