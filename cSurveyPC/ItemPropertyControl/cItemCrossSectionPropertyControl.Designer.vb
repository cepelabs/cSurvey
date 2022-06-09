<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemCrossSectionPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemCrossSectionPropertyControl))
        Me.lblPropCrossSectionRefStation = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropCrossSectionRefStation = New System.Windows.Forms.ComboBox()
        Me.cmdPropCrossSectionProfileMarker = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdPropCrossSectionPlanMarker = New DevExpress.XtraEditors.SimpleButton()
        Me.chkPropCrossSectionProfileMarker = New DevExpress.XtraEditors.CheckEdit()
        Me.chkPropCrossSectionPlanMarker = New DevExpress.XtraEditors.CheckEdit()
        Me.lblPropProfileReferences = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCrossSectionCrossH = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCrossSectionCrossW = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropCrossSectionHeight = New System.Windows.Forms.NumericUpDown()
        Me.txtPropCrossSectionWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPropCrossSectionCross = New DevExpress.XtraEditors.LabelControl()
        Me.lblPropCrossSectionSegment = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropProfileDirection = New System.Windows.Forms.ComboBox()
        Me.lblPropProfileBearing = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropProfileTextDistance = New System.Windows.Forms.NumericUpDown()
        Me.lblPropProfileTextDistance = New DevExpress.XtraEditors.LabelControl()
        Me.cboPropProfileTextPosition = New System.Windows.Forms.ComboBox()
        Me.lblPropProfileTextPosition = New DevExpress.XtraEditors.LabelControl()
        Me.txtPropCrossSectionSegment = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.chkPropCrossSectionProfileMarker.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPropCrossSectionPlanMarker.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropProfileTextDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPropCrossSectionSegment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPropCrossSectionRefStation
        '
        resources.ApplyResources(Me.lblPropCrossSectionRefStation, "lblPropCrossSectionRefStation")
        Me.lblPropCrossSectionRefStation.Name = "lblPropCrossSectionRefStation"
        '
        'cboPropCrossSectionRefStation
        '
        Me.cboPropCrossSectionRefStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropCrossSectionRefStation, "cboPropCrossSectionRefStation")
        Me.cboPropCrossSectionRefStation.Items.AddRange(New Object() {resources.GetString("cboPropCrossSectionRefStation.Items"), resources.GetString("cboPropCrossSectionRefStation.Items1"), resources.GetString("cboPropCrossSectionRefStation.Items2")})
        Me.cboPropCrossSectionRefStation.Name = "cboPropCrossSectionRefStation"
        '
        'cmdPropCrossSectionProfileMarker
        '
        Me.cmdPropCrossSectionProfileMarker.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropCrossSectionProfileMarker.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.cmdPropCrossSectionProfileMarker.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropCrossSectionProfileMarker, "cmdPropCrossSectionProfileMarker")
        Me.cmdPropCrossSectionProfileMarker.Name = "cmdPropCrossSectionProfileMarker"
        '
        'cmdPropCrossSectionPlanMarker
        '
        Me.cmdPropCrossSectionPlanMarker.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdPropCrossSectionPlanMarker.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources._select
        Me.cmdPropCrossSectionPlanMarker.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.cmdPropCrossSectionPlanMarker, "cmdPropCrossSectionPlanMarker")
        Me.cmdPropCrossSectionPlanMarker.Name = "cmdPropCrossSectionPlanMarker"
        '
        'chkPropCrossSectionProfileMarker
        '
        resources.ApplyResources(Me.chkPropCrossSectionProfileMarker, "chkPropCrossSectionProfileMarker")
        Me.chkPropCrossSectionProfileMarker.Name = "chkPropCrossSectionProfileMarker"
        Me.chkPropCrossSectionProfileMarker.Properties.Caption = resources.GetString("chkPropCrossSectionProfileMarker.Properties.Caption")
        Me.chkPropCrossSectionProfileMarker.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1
        Me.chkPropCrossSectionProfileMarker.Properties.GlyphAlignment = CType(resources.GetObject("chkPropCrossSectionProfileMarker.Properties.GlyphAlignment"), DevExpress.Utils.HorzAlignment)
        '
        'chkPropCrossSectionPlanMarker
        '
        resources.ApplyResources(Me.chkPropCrossSectionPlanMarker, "chkPropCrossSectionPlanMarker")
        Me.chkPropCrossSectionPlanMarker.Name = "chkPropCrossSectionPlanMarker"
        Me.chkPropCrossSectionPlanMarker.Properties.Caption = resources.GetString("chkPropCrossSectionPlanMarker.Properties.Caption")
        Me.chkPropCrossSectionPlanMarker.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgToggle1
        Me.chkPropCrossSectionPlanMarker.Properties.GlyphAlignment = CType(resources.GetObject("chkPropCrossSectionPlanMarker.Properties.GlyphAlignment"), DevExpress.Utils.HorzAlignment)
        '
        'lblPropProfileReferences
        '
        resources.ApplyResources(Me.lblPropProfileReferences, "lblPropProfileReferences")
        Me.lblPropProfileReferences.Name = "lblPropProfileReferences"
        '
        'lblPropCrossSectionCrossH
        '
        Me.lblPropCrossSectionCrossH.Appearance.Font = CType(resources.GetObject("lblPropCrossSectionCrossH.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCrossSectionCrossH.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCrossSectionCrossH, "lblPropCrossSectionCrossH")
        Me.lblPropCrossSectionCrossH.Name = "lblPropCrossSectionCrossH"
        '
        'lblPropCrossSectionCrossW
        '
        Me.lblPropCrossSectionCrossW.Appearance.Font = CType(resources.GetObject("lblPropCrossSectionCrossW.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCrossSectionCrossW.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCrossSectionCrossW, "lblPropCrossSectionCrossW")
        Me.lblPropCrossSectionCrossW.Name = "lblPropCrossSectionCrossW"
        '
        'txtPropCrossSectionHeight
        '
        Me.txtPropCrossSectionHeight.DecimalPlaces = 2
        Me.txtPropCrossSectionHeight.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionHeight, "txtPropCrossSectionHeight")
        Me.txtPropCrossSectionHeight.Name = "txtPropCrossSectionHeight"
        Me.txtPropCrossSectionHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtPropCrossSectionWidth
        '
        Me.txtPropCrossSectionWidth.DecimalPlaces = 2
        Me.txtPropCrossSectionWidth.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropCrossSectionWidth, "txtPropCrossSectionWidth")
        Me.txtPropCrossSectionWidth.Name = "txtPropCrossSectionWidth"
        Me.txtPropCrossSectionWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropCrossSectionCross
        '
        Me.lblPropCrossSectionCross.Appearance.Font = CType(resources.GetObject("lblPropCrossSectionCross.Appearance.Font"), System.Drawing.Font)
        Me.lblPropCrossSectionCross.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropCrossSectionCross, "lblPropCrossSectionCross")
        Me.lblPropCrossSectionCross.Name = "lblPropCrossSectionCross"
        '
        'lblPropCrossSectionSegment
        '
        resources.ApplyResources(Me.lblPropCrossSectionSegment, "lblPropCrossSectionSegment")
        Me.lblPropCrossSectionSegment.Name = "lblPropCrossSectionSegment"
        '
        'cboPropProfileDirection
        '
        Me.cboPropProfileDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropProfileDirection, "cboPropProfileDirection")
        Me.cboPropProfileDirection.Items.AddRange(New Object() {resources.GetString("cboPropProfileDirection.Items"), resources.GetString("cboPropProfileDirection.Items1")})
        Me.cboPropProfileDirection.Name = "cboPropProfileDirection"
        '
        'lblPropProfileBearing
        '
        resources.ApplyResources(Me.lblPropProfileBearing, "lblPropProfileBearing")
        Me.lblPropProfileBearing.Name = "lblPropProfileBearing"
        '
        'txtPropProfileTextDistance
        '
        Me.txtPropProfileTextDistance.DecimalPlaces = 2
        Me.txtPropProfileTextDistance.Increment = New Decimal(New Integer() {10, 0, 0, 131072})
        resources.ApplyResources(Me.txtPropProfileTextDistance, "txtPropProfileTextDistance")
        Me.txtPropProfileTextDistance.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.txtPropProfileTextDistance.Name = "txtPropProfileTextDistance"
        Me.txtPropProfileTextDistance.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblPropProfileTextDistance
        '
        Me.lblPropProfileTextDistance.Appearance.Font = CType(resources.GetObject("lblPropProfileTextDistance.Appearance.Font"), System.Drawing.Font)
        Me.lblPropProfileTextDistance.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPropProfileTextDistance, "lblPropProfileTextDistance")
        Me.lblPropProfileTextDistance.Name = "lblPropProfileTextDistance"
        '
        'cboPropProfileTextPosition
        '
        Me.cboPropProfileTextPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPropProfileTextPosition, "cboPropProfileTextPosition")
        Me.cboPropProfileTextPosition.Items.AddRange(New Object() {resources.GetString("cboPropProfileTextPosition.Items"), resources.GetString("cboPropProfileTextPosition.Items1"), resources.GetString("cboPropProfileTextPosition.Items2"), resources.GetString("cboPropProfileTextPosition.Items3"), resources.GetString("cboPropProfileTextPosition.Items4"), resources.GetString("cboPropProfileTextPosition.Items5"), resources.GetString("cboPropProfileTextPosition.Items6"), resources.GetString("cboPropProfileTextPosition.Items7"), resources.GetString("cboPropProfileTextPosition.Items8")})
        Me.cboPropProfileTextPosition.Name = "cboPropProfileTextPosition"
        '
        'lblPropProfileTextPosition
        '
        resources.ApplyResources(Me.lblPropProfileTextPosition, "lblPropProfileTextPosition")
        Me.lblPropProfileTextPosition.Name = "lblPropProfileTextPosition"
        '
        'txtPropCrossSectionSegment
        '
        resources.ApplyResources(Me.txtPropCrossSectionSegment, "txtPropCrossSectionSegment")
        Me.txtPropCrossSectionSegment.Name = "txtPropCrossSectionSegment"
        Me.txtPropCrossSectionSegment.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtPropCrossSectionSegment.Properties.ReadOnly = True
        Me.txtPropCrossSectionSegment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cItemCrossSectionPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.txtPropCrossSectionSegment)
        Me.Controls.Add(Me.lblPropCrossSectionRefStation)
        Me.Controls.Add(Me.cboPropCrossSectionRefStation)
        Me.Controls.Add(Me.cmdPropCrossSectionProfileMarker)
        Me.Controls.Add(Me.cmdPropCrossSectionPlanMarker)
        Me.Controls.Add(Me.chkPropCrossSectionProfileMarker)
        Me.Controls.Add(Me.chkPropCrossSectionPlanMarker)
        Me.Controls.Add(Me.lblPropProfileReferences)
        Me.Controls.Add(Me.lblPropCrossSectionCrossH)
        Me.Controls.Add(Me.lblPropCrossSectionCrossW)
        Me.Controls.Add(Me.txtPropCrossSectionHeight)
        Me.Controls.Add(Me.txtPropCrossSectionWidth)
        Me.Controls.Add(Me.lblPropCrossSectionCross)
        Me.Controls.Add(Me.lblPropCrossSectionSegment)
        Me.Controls.Add(Me.cboPropProfileDirection)
        Me.Controls.Add(Me.lblPropProfileBearing)
        Me.Controls.Add(Me.txtPropProfileTextDistance)
        Me.Controls.Add(Me.lblPropProfileTextDistance)
        Me.Controls.Add(Me.lblPropProfileTextPosition)
        Me.Controls.Add(Me.cboPropProfileTextPosition)
        Me.Name = "cItemCrossSectionPropertyControl"
        CType(Me.chkPropCrossSectionProfileMarker.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPropCrossSectionPlanMarker.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropProfileTextDistance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPropCrossSectionSegment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPropCrossSectionRefStation As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropCrossSectionRefStation As ComboBox
    Friend WithEvents cmdPropCrossSectionProfileMarker As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdPropCrossSectionPlanMarker As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkPropCrossSectionProfileMarker As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkPropCrossSectionPlanMarker As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblPropProfileReferences As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionCrossH As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionCrossW As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropCrossSectionHeight As NumericUpDown
    Friend WithEvents txtPropCrossSectionWidth As NumericUpDown
    Friend WithEvents lblPropCrossSectionCross As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblPropCrossSectionSegment As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropProfileDirection As ComboBox
    Friend WithEvents lblPropProfileBearing As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropProfileTextDistance As NumericUpDown
    Friend WithEvents lblPropProfileTextDistance As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboPropProfileTextPosition As ComboBox
    Friend WithEvents lblPropProfileTextPosition As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPropCrossSectionSegment As DevExpress.XtraEditors.ButtonEdit
End Class
