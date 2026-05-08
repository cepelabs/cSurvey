<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportcSurveyShotsDetails
    Inherits DevExpress.XtraEditors.XtraUserControl

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportcSurveyShotsDetails))
        Me.grpShots = New DevExpress.XtraEditors.GroupControl()
        Me.chkColor = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDataProperties = New DevExpress.XtraEditors.CheckEdit()
        Me.chkCaveBranch = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSession = New DevExpress.XtraEditors.CheckEdit()
        Me.chkNotes = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdEditOtherProperties = New DevExpress.XtraEditors.SimpleButton()
        Me.chkDirection = New DevExpress.XtraEditors.CheckEdit()
        Me.chkLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.chkInclination = New DevExpress.XtraEditors.CheckEdit()
        Me.chkBearing = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDistance = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.grpShots, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpShots.SuspendLayout()
        CType(Me.chkColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDataProperties.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCaveBranch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSession.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNotes.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDirection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkInclination.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkBearing.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDistance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpShots
        '
        resources.ApplyResources(Me.grpShots, "grpShots")
        Me.grpShots.Controls.Add(Me.chkColor)
        Me.grpShots.Controls.Add(Me.chkDataProperties)
        Me.grpShots.Controls.Add(Me.chkCaveBranch)
        Me.grpShots.Controls.Add(Me.chkSession)
        Me.grpShots.Controls.Add(Me.chkNotes)
        Me.grpShots.Controls.Add(Me.LabelControl1)
        Me.grpShots.Controls.Add(Me.cmdEditOtherProperties)
        Me.grpShots.Controls.Add(Me.chkDirection)
        Me.grpShots.Controls.Add(Me.chkLRUD)
        Me.grpShots.Controls.Add(Me.chkInclination)
        Me.grpShots.Controls.Add(Me.chkBearing)
        Me.grpShots.Controls.Add(Me.chkDistance)
        Me.grpShots.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText
        Me.grpShots.Name = "grpShots"
        '
        'chkColor
        '
        resources.ApplyResources(Me.chkColor, "chkColor")
        Me.chkColor.Name = "chkColor"
        Me.chkColor.Properties.AutoWidth = True
        Me.chkColor.Properties.Caption = resources.GetString("chkColor.Properties.Caption")
        '
        'chkDataProperties
        '
        resources.ApplyResources(Me.chkDataProperties, "chkDataProperties")
        Me.chkDataProperties.Name = "chkDataProperties"
        Me.chkDataProperties.Properties.AutoWidth = True
        Me.chkDataProperties.Properties.Caption = resources.GetString("chkDataProperties.Properties.Caption")
        '
        'chkCaveBranch
        '
        resources.ApplyResources(Me.chkCaveBranch, "chkCaveBranch")
        Me.chkCaveBranch.Name = "chkCaveBranch"
        Me.chkCaveBranch.Properties.AutoWidth = True
        Me.chkCaveBranch.Properties.Caption = resources.GetString("chkCaveBranch.Properties.Caption")
        '
        'chkSession
        '
        resources.ApplyResources(Me.chkSession, "chkSession")
        Me.chkSession.Name = "chkSession"
        Me.chkSession.Properties.AutoWidth = True
        Me.chkSession.Properties.Caption = resources.GetString("chkSession.Properties.Caption")
        '
        'chkNotes
        '
        resources.ApplyResources(Me.chkNotes, "chkNotes")
        Me.chkNotes.Name = "chkNotes"
        Me.chkNotes.Properties.AutoWidth = True
        Me.chkNotes.Properties.Caption = resources.GetString("chkNotes.Properties.Caption")
        '
        'LabelControl1
        '
        resources.ApplyResources(Me.LabelControl1, "LabelControl1")
        Me.LabelControl1.Name = "LabelControl1"
        '
        'cmdEditOtherProperties
        '
        Me.cmdEditOtherProperties.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdEditOtherProperties.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.edit
        Me.cmdEditOtherProperties.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdEditOtherProperties, "cmdEditOtherProperties")
        Me.cmdEditOtherProperties.Name = "cmdEditOtherProperties"
        '
        'chkDirection
        '
        resources.ApplyResources(Me.chkDirection, "chkDirection")
        Me.chkDirection.Name = "chkDirection"
        Me.chkDirection.Properties.AutoWidth = True
        Me.chkDirection.Properties.Caption = resources.GetString("chkDirection.Properties.Caption")
        '
        'chkLRUD
        '
        resources.ApplyResources(Me.chkLRUD, "chkLRUD")
        Me.chkLRUD.Name = "chkLRUD"
        Me.chkLRUD.Properties.AutoWidth = True
        Me.chkLRUD.Properties.Caption = resources.GetString("chkLRUD.Properties.Caption")
        '
        'chkInclination
        '
        resources.ApplyResources(Me.chkInclination, "chkInclination")
        Me.chkInclination.Name = "chkInclination"
        Me.chkInclination.Properties.AutoWidth = True
        Me.chkInclination.Properties.Caption = resources.GetString("chkInclination.Properties.Caption")
        '
        'chkBearing
        '
        resources.ApplyResources(Me.chkBearing, "chkBearing")
        Me.chkBearing.Name = "chkBearing"
        Me.chkBearing.Properties.AutoWidth = True
        Me.chkBearing.Properties.Caption = resources.GetString("chkBearing.Properties.Caption")
        '
        'chkDistance
        '
        resources.ApplyResources(Me.chkDistance, "chkDistance")
        Me.chkDistance.Name = "chkDistance"
        Me.chkDistance.Properties.AutoWidth = True
        Me.chkDistance.Properties.Caption = resources.GetString("chkDistance.Properties.Caption")
        '
        'frmImportcSurveyShotsDetails
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.grpShots)
        Me.Name = "frmImportcSurveyShotsDetails"
        CType(Me.grpShots, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpShots.ResumeLayout(False)
        Me.grpShots.PerformLayout()
        CType(Me.chkColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDataProperties.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCaveBranch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSession.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNotes.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDirection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkInclination.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkBearing.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDistance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpShots As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkBearing As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDistance As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkInclination As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDirection As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdEditOtherProperties As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkNotes As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkCaveBranch As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSession As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDataProperties As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkColor As DevExpress.XtraEditors.CheckEdit
End Class
