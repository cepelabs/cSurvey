<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemCrossSectionSplayPropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemCrossSectionSplayPropertyControl))
        Me.lblPropPlanSplay = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPropCrossSectionSplay = New DevExpress.XtraEditors.SimpleButton()
        Me.picPropCrossSectionProjectionSchema = New DevExpress.XtraEditors.PictureEdit()
        Me.txtPropCrossSectionSplayProjectionVerticalAngle = New System.Windows.Forms.NumericUpDown()
        Me.chkPropCrossSectionShowOnlyCutSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPropCrossSectionSplayText = New DevExpress.XtraEditors.CheckEdit()
        Me.txtPropCrossSectionSplayMaxVariationAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionSplayMaxVariationAngle = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCrossSectionSplayProjectionAngle = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropCrossSectionSplayLineStyle = New System.Windows.Forms.ComboBox()
        Me.txtPropCrossSectionSplayProjectionAngle = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionSplayLineStyle = New DevExpress.XtraEditors.LabelControl()
        Me.chkPropCrossSectionShowSplayBorder = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.picPropCrossSectionProjectionSchema.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayProjectionVerticalAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropCrossSectionShowOnlyCutSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropCrossSectionSplayText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropCrossSectionShowSplayBorder.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPropPlanSplay
        '
        resources.ApplyResources(Me.lblPropPlanSplay, "lblPropPlanSplay")
        Me.lblPropPlanSplay.Name = "lblPropPlanSplay"
        '
        'cmdPropCrossSectionSplay
        '
        resources.ApplyResources(Me.cmdPropCrossSectionSplay, "cmdPropCrossSectionSplay")
        Me.cmdPropCrossSectionSplay.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropCrossSectionSplay.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.replicatesplaydata
        Me.cmdPropCrossSectionSplay.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdPropCrossSectionSplay.Name = "cmdPropCrossSectionSplay"
        '
        'picPropCrossSectionProjectionSchema
        '
        resources.ApplyResources(Me.picPropCrossSectionProjectionSchema, "picPropCrossSectionProjectionSchema")
        Me.picPropCrossSectionProjectionSchema.Name = "picPropCrossSectionProjectionSchema"
        Me.picPropCrossSectionProjectionSchema.Properties.NullText = resources.GetString("picPropCrossSectionProjectionSchema.Properties.NullText")
        Me.picPropCrossSectionProjectionSchema.Properties.PictureInterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        Me.picPropCrossSectionProjectionSchema.Properties.ReadOnly = True
        Me.picPropCrossSectionProjectionSchema.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.[False]
        Me.picPropCrossSectionProjectionSchema.Properties.ShowMenu = False
        Me.picPropCrossSectionProjectionSchema.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        '
        'txtPropCrossSectionSplayProjectionVerticalAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayProjectionVerticalAngle, "txtPropCrossSectionSplayProjectionVerticalAngle")
        Me.txtPropCrossSectionSplayProjectionVerticalAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayProjectionVerticalAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionSplayProjectionVerticalAngle.Name = "txtPropCrossSectionSplayProjectionVerticalAngle"
        '
        'chkPropCrossSectionShowOnlyCutSplay
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowOnlyCutSplay, "chkPropCrossSectionShowOnlyCutSplay")
        Me.chkPropCrossSectionShowOnlyCutSplay.Name = "chkPropCrossSectionShowOnlyCutSplay"
        Me.chkPropCrossSectionShowOnlyCutSplay.Properties.AutoWidth = True
        Me.chkPropCrossSectionShowOnlyCutSplay.Properties.Caption = resources.GetString("chkPropCrossSectionShowOnlyCutSplay.Properties.Caption")
        '
        'chkPropCrossSectionSplayText
        '
        resources.ApplyResources(Me.chkPropCrossSectionSplayText, "chkPropCrossSectionSplayText")
        Me.chkPropCrossSectionSplayText.Name = "chkPropCrossSectionSplayText"
        Me.chkPropCrossSectionSplayText.Properties.AutoWidth = True
        Me.chkPropCrossSectionSplayText.Properties.Caption = resources.GetString("chkPropCrossSectionSplayText.Properties.Caption")
        '
        'txtPropCrossSectionSplayMaxVariationAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayMaxVariationAngle, "txtPropCrossSectionSplayMaxVariationAngle")
        Me.txtPropCrossSectionSplayMaxVariationAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayMaxVariationAngle.Name = "txtPropCrossSectionSplayMaxVariationAngle"
        '
        'lblPropCrossSectionSplayMaxVariationAngle
        '
        Me.lblPropCrossSectionSplayMaxVariationAngle.Appearance.Font = CType(resources.GetObject("lblPropCrossSectionSplayMaxVariationAngle.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCrossSectionSplayMaxVariationAngle.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCrossSectionSplayMaxVariationAngle, "lblPropCrossSectionSplayMaxVariationAngle")
        Me.lblPropCrossSectionSplayMaxVariationAngle.Name = "lblPropCrossSectionSplayMaxVariationAngle"
        '
        'lblPropCrossSectionSplayProjectionAngle
        '
        Me.lblPropCrossSectionSplayProjectionAngle.Appearance.Font = CType(resources.GetObject("lblPropCrossSectionSplayProjectionAngle.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCrossSectionSplayProjectionAngle.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCrossSectionSplayProjectionAngle, "lblPropCrossSectionSplayProjectionAngle")
        Me.lblPropCrossSectionSplayProjectionAngle.Name = "lblPropCrossSectionSplayProjectionAngle"
        '
        'cboPropCrossSectionSplayLineStyle
        '
        Me.cboPropCrossSectionSplayLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionSplayLineStyle, "cboPropCrossSectionSplayLineStyle")
        Me.cboPropCrossSectionSplayLineStyle.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionSplayLineStyle.Items"), resources.GetString("cboPropCrossSectionSplayLineStyle.Items1"), resources.GetString("cboPropCrossSectionSplayLineStyle.Items2")})
        Me.cboPropCrossSectionSplayLineStyle.Name = "cboPropCrossSectionSplayLineStyle"
        '
        'txtPropCrossSectionSplayProjectionAngle
        '
        resources.ApplyResources(Me.txtPropCrossSectionSplayProjectionAngle, "txtPropCrossSectionSplayProjectionAngle")
        Me.txtPropCrossSectionSplayProjectionAngle.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.txtPropCrossSectionSplayProjectionAngle.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.txtPropCrossSectionSplayProjectionAngle.Name = "txtPropCrossSectionSplayProjectionAngle"
        '
        'lblPropCrossSectionSplayLineStyle
        '
        resources.ApplyResources(Me.lblPropCrossSectionSplayLineStyle, "lblPropCrossSectionSplayLineStyle")
        Me.lblPropCrossSectionSplayLineStyle.Name = "lblPropCrossSectionSplayLineStyle"
        '
        'chkPropCrossSectionShowSplayBorder
        '
        resources.ApplyResources(Me.chkPropCrossSectionShowSplayBorder, "chkPropCrossSectionShowSplayBorder")
        Me.chkPropCrossSectionShowSplayBorder.Name = "chkPropCrossSectionShowSplayBorder"
        Me.chkPropCrossSectionShowSplayBorder.Properties.AutoWidth = True
        Me.chkPropCrossSectionShowSplayBorder.Properties.Caption = resources.GetString("chkPropCrossSectionShowSplayBorder.Properties.Caption")
        '
        'cItemCrossSectionSplayPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtPropCrossSectionSplayProjectionVerticalAngle)
        Me.Controls.Add(Me.chkPropCrossSectionShowOnlyCutSplay)
        Me.Controls.Add(Me.chkPropCrossSectionSplayText)
        Me.Controls.Add(Me.txtPropCrossSectionSplayMaxVariationAngle)
        Me.Controls.Add(Me.lblPropCrossSectionSplayMaxVariationAngle)
        Me.Controls.Add(Me.lblPropCrossSectionSplayProjectionAngle)
        Me.Controls.Add(Me.cboPropCrossSectionSplayLineStyle)
        Me.Controls.Add(Me.txtPropCrossSectionSplayProjectionAngle)
        Me.Controls.Add(Me.lblPropCrossSectionSplayLineStyle)
        Me.Controls.Add(Me.chkPropCrossSectionShowSplayBorder)
        Me.Controls.Add(Me.lblPropPlanSplay)
        Me.Controls.Add(Me.picPropCrossSectionProjectionSchema)
        Me.Controls.Add(Me.cmdPropCrossSectionSplay)
        Me.Name = "cItemCrossSectionSplayPropertyControl"
        CType(Me.picPropCrossSectionProjectionSchema.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayProjectionVerticalAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropCrossSectionShowOnlyCutSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropCrossSectionSplayText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayMaxVariationAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSplayProjectionAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropCrossSectionShowSplayBorder.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPropCaveBranchListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveBranchListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveBranchListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cboPropCaveListView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colPropCaveListName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtPropCaveListName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lblPropPlanSplay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPropCrossSectionSplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents picPropCrossSectionProjectionSchema As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtPropCrossSectionSplayProjectionVerticalAngle As NumericUpDown
    Friend WithEvents chkPropCrossSectionShowOnlyCutSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPropCrossSectionSplayText As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtPropCrossSectionSplayMaxVariationAngle As NumericUpDown
    Friend WithEvents lblPropCrossSectionSplayMaxVariationAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionSplayProjectionAngle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropCrossSectionSplayLineStyle As ComboBox
    Friend WithEvents txtPropCrossSectionSplayProjectionAngle As NumericUpDown
    Friend WithEvents lblPropCrossSectionSplayLineStyle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkPropCrossSectionShowSplayBorder As DevExpress.XtraEditors.CheckEdit
End Class
