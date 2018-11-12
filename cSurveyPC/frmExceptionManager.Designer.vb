<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExceptionManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExceptionManager))
        Me.rtfException = New System.Windows.Forms.RichTextBox()
        Me.cmdSaveAs = New System.Windows.Forms.Button()
        Me.cmdSaveAsAndExit = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSaveException = New System.Windows.Forms.Button()
        Me.cmdSendException = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdShowDetails = New System.Windows.Forms.Button()
        Me.lblException = New System.Windows.Forms.Label()
        Me.tmrAskToSendException = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'rtfException
        '
        resources.ApplyResources(Me.rtfException, "rtfException")
        Me.rtfException.DetectUrls = False
        Me.rtfException.HideSelection = False
        Me.rtfException.Name = "rtfException"
        Me.rtfException.ShortcutsEnabled = False
        '
        'cmdSaveAs
        '
        resources.ApplyResources(Me.cmdSaveAs, "cmdSaveAs")
        Me.cmdSaveAs.Image = Global.cSurveyPC.My.Resources.Resources.save_as
        Me.cmdSaveAs.Name = "cmdSaveAs"
        Me.cmdSaveAs.UseVisualStyleBackColor = True
        '
        'cmdSaveAsAndExit
        '
        resources.ApplyResources(Me.cmdSaveAsAndExit, "cmdSaveAsAndExit")
        Me.cmdSaveAsAndExit.Image = Global.cSurveyPC.My.Resources.Resources.save_as
        Me.cmdSaveAsAndExit.Name = "cmdSaveAsAndExit"
        Me.cmdSaveAsAndExit.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        resources.ApplyResources(Me.cmdExit, "cmdExit")
        Me.cmdExit.Image = Global.cSurveyPC.My.Resources.Resources.door_out
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cmdSaveException
        '
        resources.ApplyResources(Me.cmdSaveException, "cmdSaveException")
        Me.cmdSaveException.Image = Global.cSurveyPC.My.Resources.Resources.script_save
        Me.cmdSaveException.Name = "cmdSaveException"
        Me.cmdSaveException.UseVisualStyleBackColor = True
        '
        'cmdSendException
        '
        resources.ApplyResources(Me.cmdSendException, "cmdSendException")
        Me.cmdSendException.Image = Global.cSurveyPC.My.Resources.Resources.email_go
        Me.cmdSendException.Name = "cmdSendException"
        Me.cmdSendException.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Image = Global.cSurveyPC.My.Resources.Resources.script_go1
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdShowDetails
        '
        resources.ApplyResources(Me.cmdShowDetails, "cmdShowDetails")
        Me.cmdShowDetails.Name = "cmdShowDetails"
        Me.cmdShowDetails.UseVisualStyleBackColor = True
        '
        'lblException
        '
        resources.ApplyResources(Me.lblException, "lblException")
        Me.lblException.Name = "lblException"
        '
        'tmrAskToSendException
        '
        '
        'frmExceptionManager
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdClose
        Me.Controls.Add(Me.lblException)
        Me.Controls.Add(Me.cmdShowDetails)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdSendException)
        Me.Controls.Add(Me.cmdSaveException)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdSaveAsAndExit)
        Me.Controls.Add(Me.cmdSaveAs)
        Me.Controls.Add(Me.rtfException)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExceptionManager"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtfException As System.Windows.Forms.RichTextBox
    Friend WithEvents cmdSaveAs As System.Windows.Forms.Button
    Friend WithEvents cmdSaveAsAndExit As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSaveException As System.Windows.Forms.Button
    Friend WithEvents cmdSendException As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdShowDetails As System.Windows.Forms.Button
    Friend WithEvents lblException As System.Windows.Forms.Label
    Friend WithEvents tmrAskToSendException As System.Windows.Forms.Timer
End Class
