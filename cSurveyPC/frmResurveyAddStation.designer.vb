<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResurveyAddStation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyAddStation))
        Me.optNewStation = New System.Windows.Forms.RadioButton()
        Me.optMovedStation = New System.Windows.Forms.RadioButton()
        Me.cboMovedStation = New System.Windows.Forms.ComboBox()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.optFirstScale = New System.Windows.Forms.RadioButton()
        Me.optSecondScale = New System.Windows.Forms.RadioButton()
        Me.txtScaleSize = New System.Windows.Forms.NumericUpDown()
        Me.lblScaleUM = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboNewStation = New System.Windows.Forms.ComboBox()
        Me.cboPrevStation = New System.Windows.Forms.ComboBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtPosition = New System.Windows.Forms.TextBox()
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.txtScaleSize, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cboMovedStation
        '
        Me.cboMovedStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMovedStation.FormattingEnabled = True
        resources.ApplyResources(Me.cboMovedStation, "cboMovedStation")
        Me.cboMovedStation.Name = "cboMovedStation"
        Me.tipDefault.SetToolTip(Me.cboMovedStation, resources.GetString("cboMovedStation.ToolTip"))
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
        'txtScaleSize
        '
        resources.ApplyResources(Me.txtScaleSize, "txtScaleSize")
        Me.txtScaleSize.Name = "txtScaleSize"
        Me.tipDefault.SetToolTip(Me.txtScaleSize, resources.GetString("txtScaleSize.ToolTip"))
        '
        'lblScaleUM
        '
        resources.ApplyResources(Me.lblScaleUM, "lblScaleUM")
        Me.lblScaleUM.Name = "lblScaleUM"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'cboNewStation
        '
        Me.cboNewStation.FormattingEnabled = True
        resources.ApplyResources(Me.cboNewStation, "cboNewStation")
        Me.cboNewStation.Name = "cboNewStation"
        Me.tipDefault.SetToolTip(Me.cboNewStation, resources.GetString("cboNewStation.ToolTip"))
        '
        'cboPrevStation
        '
        Me.cboPrevStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrevStation.FormattingEnabled = True
        resources.ApplyResources(Me.cboPrevStation, "cboPrevStation")
        Me.cboPrevStation.Name = "cboPrevStation"
        Me.tipDefault.SetToolTip(Me.cboPrevStation, resources.GetString("cboPrevStation.ToolTip"))
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
        'frmResurveyAddStation
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.cboPrevStation)
        Me.Controls.Add(Me.cboNewStation)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblScaleUM)
        Me.Controls.Add(Me.txtScaleSize)
        Me.Controls.Add(Me.optSecondScale)
        Me.Controls.Add(Me.optFirstScale)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cboMovedStation)
        Me.Controls.Add(Me.optMovedStation)
        Me.Controls.Add(Me.optNewStation)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyAddStation"
        CType(Me.txtScaleSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents optNewStation As System.Windows.Forms.RadioButton
    Friend WithEvents optMovedStation As System.Windows.Forms.RadioButton
    Friend WithEvents cboMovedStation As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents optFirstScale As System.Windows.Forms.RadioButton
    Friend WithEvents optSecondScale As System.Windows.Forms.RadioButton
    Friend WithEvents txtScaleSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScaleUM As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboNewStation As System.Windows.Forms.ComboBox
    Friend WithEvents cboPrevStation As System.Windows.Forms.ComboBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents txtPosition As System.Windows.Forms.TextBox
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
End Class
