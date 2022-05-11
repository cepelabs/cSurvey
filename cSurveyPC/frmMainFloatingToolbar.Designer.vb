<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainFloatingToolbar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainFloatingToolbar))
        Me.tbPen = New System.Windows.Forms.ToolStrip()
        Me.btnPenEndEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenContextMenu = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenAddPoint = New System.Windows.Forms.ToolStripButton()
        Me.btnPenDeletePoint = New System.Windows.Forms.ToolStripButton()
        Me.btnPenJoinPoint = New System.Windows.Forms.ToolStripButton()
        Me.btnPenJoinPointAndConnect = New System.Windows.Forms.ToolStripButton()
        Me.btnPenUnjoinPoint = New System.Windows.Forms.ToolStripButton()
        Me.btnPenPointSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenSegment = New System.Windows.Forms.ToolStripButton()
        Me.btnPenSegmentFrom = New System.Windows.Forms.ToolStripButton()
        Me.btnPenSegmentTo = New System.Windows.Forms.ToolStripButton()
        Me.btnPenTrigpoint = New System.Windows.Forms.ToolStripButton()
        Me.btnPenSegmentInvert = New System.Windows.Forms.ToolStripButton()
        Me.btnPenSegmentSetCurrentCaveBranch = New System.Windows.Forms.ToolStripButton()
        Me.btnPenSegmentSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenCut = New System.Windows.Forms.ToolStripButton()
        Me.btnPenCopy = New System.Windows.Forms.ToolStripButton()
        Me.btnPenPaste = New System.Windows.Forms.ToolStripButton()
        Me.btnPenCopyPasteSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnPenDeleteSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenSendToBottom = New System.Windows.Forms.ToolStripButton()
        Me.btnPenBringToTop = New System.Windows.Forms.ToolStripButton()
        Me.btnPenLock = New System.Windows.Forms.ToolStripButton()
        Me.btnPenZOrderSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPenObjectProp = New System.Windows.Forms.ToolStripButton()
        Me.tbPen.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbPen
        '
        resources.ApplyResources(Me.tbPen, "tbPen")
        Me.tbPen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPenEndEdit, Me.ToolStripSeparator4, Me.btnPenContextMenu, Me.ToolStripSeparator14, Me.btnPenAddPoint, Me.btnPenDeletePoint, Me.btnPenJoinPoint, Me.btnPenJoinPointAndConnect, Me.btnPenUnjoinPoint, Me.btnPenPointSeparator, Me.btnPenSegment, Me.btnPenSegmentFrom, Me.btnPenSegmentTo, Me.btnPenTrigpoint, Me.btnPenSegmentInvert, Me.btnPenSegmentSetCurrentCaveBranch, Me.btnPenSegmentSeparator, Me.btnPenCut, Me.btnPenCopy, Me.btnPenPaste, Me.btnPenCopyPasteSeparator, Me.btnPenDelete, Me.btnPenDeleteSeparator, Me.btnPenSendToBottom, Me.btnPenBringToTop, Me.btnPenLock, Me.btnPenZOrderSeparator, Me.btnPenObjectProp})
        Me.tbPen.Name = "tbPen"
        '
        'btnPenEndEdit
        '
        Me.btnPenEndEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnPenEndEdit, "btnPenEndEdit")
        Me.btnPenEndEdit.Image = Global.cSurveyPC.My.Resources.Resources.stop2
        Me.btnPenEndEdit.Name = "btnPenEndEdit"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnPenContextMenu
        '
        Me.btnPenContextMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenContextMenu.Image = Global.cSurveyPC.My.Resources.Resources.wrench
        resources.ApplyResources(Me.btnPenContextMenu, "btnPenContextMenu")
        Me.btnPenContextMenu.Name = "btnPenContextMenu"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        resources.ApplyResources(Me.ToolStripSeparator14, "ToolStripSeparator14")
        '
        'btnPenAddPoint
        '
        Me.btnPenAddPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenAddPoint.Image = Global.cSurveyPC.My.Resources.Resources.bullet_add
        resources.ApplyResources(Me.btnPenAddPoint, "btnPenAddPoint")
        Me.btnPenAddPoint.Name = "btnPenAddPoint"
        '
        'btnPenDeletePoint
        '
        Me.btnPenDeletePoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenDeletePoint.Image = Global.cSurveyPC.My.Resources.Resources.bullet_delete
        resources.ApplyResources(Me.btnPenDeletePoint, "btnPenDeletePoint")
        Me.btnPenDeletePoint.Name = "btnPenDeletePoint"
        '
        'btnPenJoinPoint
        '
        Me.btnPenJoinPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenJoinPoint.Image = Global.cSurveyPC.My.Resources.Resources.arrow_join
        resources.ApplyResources(Me.btnPenJoinPoint, "btnPenJoinPoint")
        Me.btnPenJoinPoint.Name = "btnPenJoinPoint"
        '
        'btnPenJoinPointAndConnect
        '
        Me.btnPenJoinPointAndConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenJoinPointAndConnect.Image = Global.cSurveyPC.My.Resources.Resources.arrow_join_red
        resources.ApplyResources(Me.btnPenJoinPointAndConnect, "btnPenJoinPointAndConnect")
        Me.btnPenJoinPointAndConnect.Name = "btnPenJoinPointAndConnect"
        '
        'btnPenUnjoinPoint
        '
        Me.btnPenUnjoinPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenUnjoinPoint.Image = Global.cSurveyPC.My.Resources.Resources.arrow_divide
        resources.ApplyResources(Me.btnPenUnjoinPoint, "btnPenUnjoinPoint")
        Me.btnPenUnjoinPoint.Name = "btnPenUnjoinPoint"
        '
        'btnPenPointSeparator
        '
        Me.btnPenPointSeparator.Name = "btnPenPointSeparator"
        resources.ApplyResources(Me.btnPenPointSeparator, "btnPenPointSeparator")
        '
        'btnPenSegment
        '
        Me.btnPenSegment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenSegment.Image = Global.cSurveyPC.My.Resources.Resources.table_select_row
        resources.ApplyResources(Me.btnPenSegment, "btnPenSegment")
        Me.btnPenSegment.Name = "btnPenSegment"
        '
        'btnPenSegmentFrom
        '
        Me.btnPenSegmentFrom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnPenSegmentFrom, "btnPenSegmentFrom")
        Me.btnPenSegmentFrom.Name = "btnPenSegmentFrom"
        '
        'btnPenSegmentTo
        '
        Me.btnPenSegmentTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnPenSegmentTo, "btnPenSegmentTo")
        Me.btnPenSegmentTo.Name = "btnPenSegmentTo"
        '
        'btnPenTrigpoint
        '
        Me.btnPenTrigpoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnPenTrigpoint, "btnPenTrigpoint")
        Me.btnPenTrigpoint.Name = "btnPenTrigpoint"
        '
        'btnPenSegmentInvert
        '
        Me.btnPenSegmentInvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenSegmentInvert.Image = Global.cSurveyPC.My.Resources.Resources.routing_turn_u
        resources.ApplyResources(Me.btnPenSegmentInvert, "btnPenSegmentInvert")
        Me.btnPenSegmentInvert.Name = "btnPenSegmentInvert"
        '
        'btnPenSegmentSetCurrentCaveBranch
        '
        Me.btnPenSegmentSetCurrentCaveBranch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenSegmentSetCurrentCaveBranch.Image = Global.cSurveyPC.My.Resources.Resources.wand
        resources.ApplyResources(Me.btnPenSegmentSetCurrentCaveBranch, "btnPenSegmentSetCurrentCaveBranch")
        Me.btnPenSegmentSetCurrentCaveBranch.Name = "btnPenSegmentSetCurrentCaveBranch"
        '
        'btnPenSegmentSeparator
        '
        Me.btnPenSegmentSeparator.Name = "btnPenSegmentSeparator"
        resources.ApplyResources(Me.btnPenSegmentSeparator, "btnPenSegmentSeparator")
        '
        'btnPenCut
        '
        Me.btnPenCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenCut.Image = Global.cSurveyPC.My.Resources.Resources.cut
        resources.ApplyResources(Me.btnPenCut, "btnPenCut")
        Me.btnPenCut.Name = "btnPenCut"
        '
        'btnPenCopy
        '
        Me.btnPenCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenCopy.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        resources.ApplyResources(Me.btnPenCopy, "btnPenCopy")
        Me.btnPenCopy.Name = "btnPenCopy"
        '
        'btnPenPaste
        '
        Me.btnPenPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenPaste.Image = Global.cSurveyPC.My.Resources.Resources.page_paste
        resources.ApplyResources(Me.btnPenPaste, "btnPenPaste")
        Me.btnPenPaste.Name = "btnPenPaste"
        '
        'btnPenCopyPasteSeparator
        '
        Me.btnPenCopyPasteSeparator.Name = "btnPenCopyPasteSeparator"
        resources.ApplyResources(Me.btnPenCopyPasteSeparator, "btnPenCopyPasteSeparator")
        '
        'btnPenDelete
        '
        Me.btnPenDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenDelete.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnPenDelete, "btnPenDelete")
        Me.btnPenDelete.Name = "btnPenDelete"
        '
        'btnPenDeleteSeparator
        '
        Me.btnPenDeleteSeparator.Name = "btnPenDeleteSeparator"
        resources.ApplyResources(Me.btnPenDeleteSeparator, "btnPenDeleteSeparator")
        '
        'btnPenSendToBottom
        '
        Me.btnPenSendToBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenSendToBottom.Image = Global.cSurveyPC.My.Resources.Resources.shape_move_back
        resources.ApplyResources(Me.btnPenSendToBottom, "btnPenSendToBottom")
        Me.btnPenSendToBottom.Name = "btnPenSendToBottom"
        '
        'btnPenBringToTop
        '
        Me.btnPenBringToTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenBringToTop.Image = Global.cSurveyPC.My.Resources.Resources.shape_move_front
        resources.ApplyResources(Me.btnPenBringToTop, "btnPenBringToTop")
        Me.btnPenBringToTop.Name = "btnPenBringToTop"
        '
        'btnPenLock
        '
        Me.btnPenLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenLock.Image = Global.cSurveyPC.My.Resources.Resources.shape_square_key
        resources.ApplyResources(Me.btnPenLock, "btnPenLock")
        Me.btnPenLock.Name = "btnPenLock"
        '
        'btnPenZOrderSeparator
        '
        Me.btnPenZOrderSeparator.Name = "btnPenZOrderSeparator"
        resources.ApplyResources(Me.btnPenZOrderSeparator, "btnPenZOrderSeparator")
        '
        'btnPenObjectProp
        '
        Me.btnPenObjectProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPenObjectProp.Image = Global.cSurveyPC.My.Resources.Resources.page_white_wrench
        resources.ApplyResources(Me.btnPenObjectProp, "btnPenObjectProp")
        Me.btnPenObjectProp.Name = "btnPenObjectProp"
        '
        'frmMainFloatingToolbar
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.tbPen)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMainFloatingToolbar"
        Me.Opacity = 0.5R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.tbPen.ResumeLayout(False)
        Me.tbPen.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbPen As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPenEndEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenContextMenu As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenAddPoint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenDeletePoint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenPointSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenSegment As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenTrigpoint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenSegmentTo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenSegmentInvert As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenSegmentSetCurrentCaveBranch As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenSegmentSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenCut As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenPaste As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenCopyPasteSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenDeleteSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenSendToBottom As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenBringToTop As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenLock As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenZOrderSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnPenObjectProp As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenJoinPoint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenUnjoinPoint As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenJoinPointAndConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPenSegmentFrom As System.Windows.Forms.ToolStripButton
End Class
