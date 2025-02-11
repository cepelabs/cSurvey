<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportPocketTopo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportPocketTopo))
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.txtFilename = New DevExpress.XtraEditors.TextEdit()
        Me.lblFilename = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCaveName = New DevExpress.XtraEditors.TextEdit()
        Me.lblCaveName = New DevExpress.XtraEditors.LabelControl()
        Me.chkPocketTopoImportData = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPocketTopoImportGraphics = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPocketTopoImportGraphicsAsGeneric = New DevExpress.XtraEditors.CheckEdit()
        Me.cboFieldSet = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblFieldSet = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPocketTopoImportData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPocketTopoImportGraphics.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPocketTopoImportGraphicsAsGeneric.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFieldSet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
        '
        'txtFilename
        '
        resources.ApplyResources(Me.txtFilename, "txtFilename")
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Properties.ReadOnly = True
        '
        'lblFilename
        '
        Me.lblFilename.Appearance.Font = CType(resources.GetObject("lblFilename.Appearance.Font"), System.Drawing.Font)
        Me.lblFilename.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblFilename, "lblFilename")
        Me.lblFilename.Name = "lblFilename"
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        '
        'txtCaveName
        '
        resources.ApplyResources(Me.txtCaveName, "txtCaveName")
        Me.txtCaveName.Name = "txtCaveName"
        '
        'lblCaveName
        '
        Me.lblCaveName.Appearance.Font = CType(resources.GetObject("lblCaveName.Appearance.Font"), System.Drawing.Font)
        Me.lblCaveName.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblCaveName, "lblCaveName")
        Me.lblCaveName.Name = "lblCaveName"
        '
        'chkPocketTopoImportData
        '
        resources.ApplyResources(Me.chkPocketTopoImportData, "chkPocketTopoImportData")
        Me.chkPocketTopoImportData.Name = "chkPocketTopoImportData"
        Me.chkPocketTopoImportData.Properties.AutoWidth = True
        Me.chkPocketTopoImportData.Properties.Caption = resources.GetString("chkPocketTopoImportData.Properties.Caption")
        '
        'chkPocketTopoImportGraphics
        '
        resources.ApplyResources(Me.chkPocketTopoImportGraphics, "chkPocketTopoImportGraphics")
        Me.chkPocketTopoImportGraphics.Name = "chkPocketTopoImportGraphics"
        Me.chkPocketTopoImportGraphics.Properties.AutoWidth = True
        Me.chkPocketTopoImportGraphics.Properties.Caption = resources.GetString("chkPocketTopoImportGraphics.Properties.Caption")
        '
        'chkPocketTopoImportGraphicsAsGeneric
        '
        resources.ApplyResources(Me.chkPocketTopoImportGraphicsAsGeneric, "chkPocketTopoImportGraphicsAsGeneric")
        Me.chkPocketTopoImportGraphicsAsGeneric.Name = "chkPocketTopoImportGraphicsAsGeneric"
        Me.chkPocketTopoImportGraphicsAsGeneric.Properties.AutoWidth = True
        Me.chkPocketTopoImportGraphicsAsGeneric.Properties.Caption = resources.GetString("chkPocketTopoImportGraphicsAsGeneric.Properties.Caption")
        '
        'cboFieldSet
        '
        resources.ApplyResources(Me.cboFieldSet, "cboFieldSet")
        Me.cboFieldSet.Name = "cboFieldSet"
        Me.cboFieldSet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboFieldSet.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboFieldSet.Properties.Items.AddRange(New Object() {resources.GetString("cboFieldSet.Properties.Items"), resources.GetString("cboFieldSet.Properties.Items1")})
        Me.cboFieldSet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblFieldSet
        '
        Me.lblFieldSet.Appearance.Font = CType(resources.GetObject("lblFieldSet.Appearance.Font"), System.Drawing.Font)
        Me.lblFieldSet.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblFieldSet, "lblFieldSet")
        Me.lblFieldSet.Name = "lblFieldSet"
        '
        'frmImportPocketTopo
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.lblFieldSet)
        Me.Controls.Add(Me.cboFieldSet)
        Me.Controls.Add(Me.chkPocketTopoImportGraphicsAsGeneric)
        Me.Controls.Add(Me.chkPocketTopoImportGraphics)
        Me.Controls.Add(Me.chkPocketTopoImportData)
        Me.Controls.Add(Me.txtCaveName)
        Me.Controls.Add(Me.lblCaveName)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmImportPocketTopo.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.import
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportPocketTopo"
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFilename.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCaveName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPocketTopoImportData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPocketTopoImportGraphics.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPocketTopoImportGraphicsAsGeneric.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFieldSet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFilename As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblFilename As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCaveName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCaveName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPocketTopoImportData As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPocketTopoImportGraphics As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPocketTopoImportGraphicsAsGeneric As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboFieldSet As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblFieldSet As DevExpress.XtraEditors.LabelControl
End Class
