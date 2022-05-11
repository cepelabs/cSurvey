<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSurfaceImportASCOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSurfaceImportASCOptions))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblTrigpointCoordinateGeo = New System.Windows.Forms.Label()
        Me.cboCoordinateSystem = New System.Windows.Forms.ComboBox()
        Me.frmUTM = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUTMBand = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboUTMZone = New System.Windows.Forms.ComboBox()
        Me.lblCheckWarning = New System.Windows.Forms.Label()
        Me.picCheckWarning = New System.Windows.Forms.PictureBox()
        Me.frmUTM.SuspendLayout()
        CType(Me.picCheckWarning, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblTrigpointCoordinateGeo
        '
        resources.ApplyResources(Me.lblTrigpointCoordinateGeo, "lblTrigpointCoordinateGeo")
        Me.lblTrigpointCoordinateGeo.Name = "lblTrigpointCoordinateGeo"
        '
        'cboCoordinateSystem
        '
        Me.cboCoordinateSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboCoordinateSystem, "cboCoordinateSystem")
        Me.cboCoordinateSystem.Items.AddRange(New Object() {resources.GetString("cboCoordinateSystem.Items"), resources.GetString("cboCoordinateSystem.Items1")})
        Me.cboCoordinateSystem.Name = "cboCoordinateSystem"
        '
        'frmUTM
        '
        Me.frmUTM.Controls.Add(Me.Label2)
        Me.frmUTM.Controls.Add(Me.cboUTMBand)
        Me.frmUTM.Controls.Add(Me.Label1)
        Me.frmUTM.Controls.Add(Me.cboUTMZone)
        resources.ApplyResources(Me.frmUTM, "frmUTM")
        Me.frmUTM.Name = "frmUTM"
        Me.frmUTM.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboUTMBand
        '
        Me.cboUTMBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboUTMBand, "cboUTMBand")
        Me.cboUTMBand.Name = "cboUTMBand"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboUTMZone
        '
        Me.cboUTMZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboUTMZone, "cboUTMZone")
        Me.cboUTMZone.Name = "cboUTMZone"
        '
        'lblCheckWarning
        '
        resources.ApplyResources(Me.lblCheckWarning, "lblCheckWarning")
        Me.lblCheckWarning.Name = "lblCheckWarning"
        '
        'picCheckWarning
        '
        resources.ApplyResources(Me.picCheckWarning, "picCheckWarning")
        Me.picCheckWarning.Image = Global.cSurveyPC.My.Resources.Resources.error3
        Me.picCheckWarning.Name = "picCheckWarning"
        Me.picCheckWarning.TabStop = False
        '
        'frmSurfaceImportASCOptions
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblCheckWarning)
        Me.Controls.Add(Me.picCheckWarning)
        Me.Controls.Add(Me.frmUTM)
        Me.Controls.Add(Me.lblTrigpointCoordinateGeo)
        Me.Controls.Add(Me.cboCoordinateSystem)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSurfaceImportASCOptions"
        Me.frmUTM.ResumeLayout(False)
        CType(Me.picCheckWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblTrigpointCoordinateGeo As System.Windows.Forms.Label
    Friend WithEvents cboCoordinateSystem As System.Windows.Forms.ComboBox
    Friend WithEvents frmUTM As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUTMBand As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboUTMZone As System.Windows.Forms.ComboBox
    Friend WithEvents lblCheckWarning As System.Windows.Forms.Label
    Friend WithEvents picCheckWarning As System.Windows.Forms.PictureBox
End Class
