<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCaveRegisterAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCaveRegisterAdd))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnNameRefresh = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cboSetting = New System.Windows.Forms.ComboBox()
        Me.lblService = New System.Windows.Forms.Label()
        Me.cboID = New System.Windows.Forms.ComboBox()
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
        'btnNameRefresh
        '
        resources.ApplyResources(Me.btnNameRefresh, "btnNameRefresh")
        Me.btnNameRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        Me.btnNameRefresh.Name = "btnNameRefresh"
        Me.tipDefault.SetToolTip(Me.btnNameRefresh, resources.GetString("btnNameRefresh.ToolTip"))
        Me.btnNameRefresh.UseVisualStyleBackColor = True
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'cboSetting
        '
        Me.cboSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSetting.FormattingEnabled = True
        resources.ApplyResources(Me.cboSetting, "cboSetting")
        Me.cboSetting.Name = "cboSetting"
        '
        'lblService
        '
        resources.ApplyResources(Me.lblService, "lblService")
        Me.lblService.Name = "lblService"
        '
        'cboID
        '
        Me.cboID.FormattingEnabled = True
        resources.ApplyResources(Me.cboID, "cboID")
        Me.cboID.Name = "cboID"
        '
        'frmCaveRegisterAdd
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.btnNameRefresh)
        Me.Controls.Add(Me.cboID)
        Me.Controls.Add(Me.lblService)
        Me.Controls.Add(Me.cboSetting)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCaveRegisterAdd"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents cboSetting As System.Windows.Forms.ComboBox
    Friend WithEvents lblService As System.Windows.Forms.Label
    Friend WithEvents cboID As System.Windows.Forms.ComboBox
    Friend WithEvents btnNameRefresh As System.Windows.Forms.Button
End Class
