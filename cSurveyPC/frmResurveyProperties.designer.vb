<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResurveyProperties
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResurveyProperties))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtPlanPosition = New System.Windows.Forms.TextBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProfilePosition = New System.Windows.Forms.TextBox()
        Me.lblPlanPosition = New System.Windows.Forms.Label()
        Me.lblConnectedTo = New System.Windows.Forms.Label()
        Me.lblProfilePosition = New System.Windows.Forms.Label()
        Me.lblScaleUM = New System.Windows.Forms.Label()
        Me.txtScaleSize = New cNumericUpDown()
        Me.lblScaleSize = New System.Windows.Forms.Label()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.tpDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdPrev = New System.Windows.Forms.Button()
        Me.lstPlanConnectedTo = New System.Windows.Forms.CheckedListBox()
        Me.lstProfileConnectedTo = New System.Windows.Forms.CheckedListBox()
        Me.tabConnectedTo = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        CType(Me.txtScaleSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConnectedTo.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
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
        'txtPlanPosition
        '
        resources.ApplyResources(Me.txtPlanPosition, "txtPlanPosition")
        Me.txtPlanPosition.Name = "txtPlanPosition"
        Me.txtPlanPosition.ReadOnly = True
        '
        'lblPosition
        '
        resources.ApplyResources(Me.lblPosition, "lblPosition")
        Me.lblPosition.Name = "lblPosition"
        '
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtProfilePosition
        '
        resources.ApplyResources(Me.txtProfilePosition, "txtProfilePosition")
        Me.txtProfilePosition.Name = "txtProfilePosition"
        Me.txtProfilePosition.ReadOnly = True
        '
        'lblPlanPosition
        '
        resources.ApplyResources(Me.lblPlanPosition, "lblPlanPosition")
        Me.lblPlanPosition.Name = "lblPlanPosition"
        '
        'lblConnectedTo
        '
        resources.ApplyResources(Me.lblConnectedTo, "lblConnectedTo")
        Me.lblConnectedTo.Name = "lblConnectedTo"
        '
        'lblProfilePosition
        '
        resources.ApplyResources(Me.lblProfilePosition, "lblProfilePosition")
        Me.lblProfilePosition.Name = "lblProfilePosition"
        '
        'lblScaleUM
        '
        resources.ApplyResources(Me.lblScaleUM, "lblScaleUM")
        Me.lblScaleUM.Name = "lblScaleUM"
        '
        'txtScaleSize
        '
        Me.txtScaleSize.DecimalPlaces = 2
        resources.ApplyResources(Me.txtScaleSize, "txtScaleSize")
        Me.txtScaleSize.Name = "txtScaleSize"
        '
        'lblScaleSize
        '
        resources.ApplyResources(Me.lblScaleSize, "lblScaleSize")
        Me.lblScaleSize.Name = "lblScaleSize"
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        resources.ApplyResources(Me.cmdNext, "cmdNext")
        Me.cmdNext.Name = "cmdNext"
        Me.tpDefault.SetToolTip(Me.cmdNext, resources.GetString("cmdNext.ToolTip"))
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdPrev
        '
        resources.ApplyResources(Me.cmdPrev, "cmdPrev")
        Me.cmdPrev.Name = "cmdPrev"
        Me.tpDefault.SetToolTip(Me.cmdPrev, resources.GetString("cmdPrev.ToolTip"))
        Me.cmdPrev.UseVisualStyleBackColor = True
        '
        'lstPlanConnectedTo
        '
        resources.ApplyResources(Me.lstPlanConnectedTo, "lstPlanConnectedTo")
        Me.lstPlanConnectedTo.FormattingEnabled = True
        Me.lstPlanConnectedTo.MultiColumn = True
        Me.lstPlanConnectedTo.Name = "lstPlanConnectedTo"
        '
        'lstProfileConnectedTo
        '
        resources.ApplyResources(Me.lstProfileConnectedTo, "lstProfileConnectedTo")
        Me.lstProfileConnectedTo.FormattingEnabled = True
        Me.lstProfileConnectedTo.MultiColumn = True
        Me.lstProfileConnectedTo.Name = "lstProfileConnectedTo"
        '
        'tabConnectedTo
        '
        resources.ApplyResources(Me.tabConnectedTo, "tabConnectedTo")
        Me.tabConnectedTo.Controls.Add(Me.TabPage1)
        Me.tabConnectedTo.Controls.Add(Me.TabPage2)
        Me.tabConnectedTo.Name = "tabConnectedTo"
        Me.tabConnectedTo.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lstPlanConnectedTo)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstProfileConnectedTo)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmResurveyProperties
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdPrev)
        Me.Controls.Add(Me.lblScaleSize)
        Me.Controls.Add(Me.lblScaleUM)
        Me.Controls.Add(Me.txtScaleSize)
        Me.Controls.Add(Me.lblProfilePosition)
        Me.Controls.Add(Me.lblConnectedTo)
        Me.Controls.Add(Me.txtProfilePosition)
        Me.Controls.Add(Me.lblPlanPosition)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPlanPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.tabConnectedTo)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResurveyProperties"
        CType(Me.txtScaleSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConnectedTo.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtPlanPosition As System.Windows.Forms.TextBox
    Friend WithEvents lblPosition As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProfilePosition As System.Windows.Forms.TextBox
    Friend WithEvents lblPlanPosition As System.Windows.Forms.Label
    Friend WithEvents lblConnectedTo As System.Windows.Forms.Label
    Friend WithEvents lblProfilePosition As System.Windows.Forms.Label
    Friend WithEvents lblScaleUM As System.Windows.Forms.Label
    Friend WithEvents txtScaleSize As cNumericUpDown
    Friend WithEvents lblScaleSize As System.Windows.Forms.Label
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents tpDefault As System.Windows.Forms.ToolTip
    Friend WithEvents lstPlanConnectedTo As System.Windows.Forms.CheckedListBox
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdPrev As System.Windows.Forms.Button
    Friend WithEvents lstProfileConnectedTo As System.Windows.Forms.CheckedListBox
    Friend WithEvents tabConnectedTo As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
