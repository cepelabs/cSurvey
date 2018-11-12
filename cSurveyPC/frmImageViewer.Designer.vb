<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImageViewer
    Inherits cDockContentWindow

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageViewer))
        Me.picImage = New System.Windows.Forms.PictureBox()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.cmdExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdZoomOriginalSize = New System.Windows.Forms.ToolStripButton()
        Me.cmdSizeToFit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRotateLeft = New System.Windows.Forms.ToolStripButton()
        Me.cmdRotateRight = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdFlipH = New System.Windows.Forms.ToolStripButton()
        Me.cmdShapeV = New System.Windows.Forms.ToolStripButton()
        Me.pnlContainer = New System.Windows.Forms.Panel()
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMain.SuspendLayout()
        Me.pnlContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'picImage
        '
        resources.ApplyResources(Me.picImage, "picImage")
        Me.picImage.Name = "picImage"
        Me.picImage.TabStop = False
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdExport, Me.ToolStripSeparator1, Me.cmdZoomOriginalSize, Me.cmdSizeToFit, Me.ToolStripSeparator3, Me.cmdRotateLeft, Me.cmdRotateRight, Me.ToolStripSeparator2, Me.cmdFlipH, Me.cmdShapeV})
        Me.tbMain.Name = "tbMain"
        '
        'cmdExport
        '
        Me.cmdExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdExport.Image = Global.cSurveyPC.My.Resources.Resources.save_as1
        resources.ApplyResources(Me.cmdExport, "cmdExport")
        Me.cmdExport.Name = "cmdExport"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'cmdZoomOriginalSize
        '
        Me.cmdZoomOriginalSize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdZoomOriginalSize.Image = Global.cSurveyPC.My.Resources.Resources.zoom_actual
        resources.ApplyResources(Me.cmdZoomOriginalSize, "cmdZoomOriginalSize")
        Me.cmdZoomOriginalSize.Name = "cmdZoomOriginalSize"
        '
        'cmdSizeToFit
        '
        Me.cmdSizeToFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdSizeToFit.Image = Global.cSurveyPC.My.Resources.Resources.zoom_fit
        resources.ApplyResources(Me.cmdSizeToFit, "cmdSizeToFit")
        Me.cmdSizeToFit.Name = "cmdSizeToFit"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'cmdRotateLeft
        '
        Me.cmdRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRotateLeft.Image = Global.cSurveyPC.My.Resources.Resources.shape_rotate_anticlockwise
        resources.ApplyResources(Me.cmdRotateLeft, "cmdRotateLeft")
        Me.cmdRotateLeft.Name = "cmdRotateLeft"
        '
        'cmdRotateRight
        '
        Me.cmdRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRotateRight.Image = Global.cSurveyPC.My.Resources.Resources.shape_rotate_clockwise
        resources.ApplyResources(Me.cmdRotateRight, "cmdRotateRight")
        Me.cmdRotateRight.Name = "cmdRotateRight"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'cmdFlipH
        '
        Me.cmdFlipH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdFlipH.Image = Global.cSurveyPC.My.Resources.Resources.shape_flip_horizontal
        resources.ApplyResources(Me.cmdFlipH, "cmdFlipH")
        Me.cmdFlipH.Name = "cmdFlipH"
        '
        'cmdShapeV
        '
        Me.cmdShapeV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdShapeV.Image = Global.cSurveyPC.My.Resources.Resources.shape_flip_vertical
        resources.ApplyResources(Me.cmdShapeV, "cmdShapeV")
        Me.cmdShapeV.Name = "cmdShapeV"
        '
        'pnlContainer
        '
        resources.ApplyResources(Me.pnlContainer, "pnlContainer")
        Me.pnlContainer.Controls.Add(Me.picImage)
        Me.pnlContainer.Name = "pnlContainer"
        '
        'frmImageViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmImageViewer"
        Me.ShowIcon = False
        Me.TopMost = True
        CType(Me.picImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.pnlContainer.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picImage As System.Windows.Forms.PictureBox
    Friend WithEvents tbMain As ToolStrip
    Friend WithEvents cmdExport As ToolStripButton
    Friend WithEvents pnlContainer As Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdRotateLeft As ToolStripButton
    Friend WithEvents cmdRotateRight As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdFlipH As ToolStripButton
    Friend WithEvents cmdShapeV As ToolStripButton
    Friend WithEvents cmdSizeToFit As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmdZoomOriginalSize As ToolStripButton
End Class
