﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesign3DModelControl
    Inherits cDesignPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesign3DModelControl))
        Me.chkDesignPlot = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlDesignPlot = New DevExpress.XtraEditors.PanelControl()
        Me.chkDesignPlotShowSegmentSurface = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSegmentDuplicate = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotColorGray = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignPlotSegmentsPaintStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboDesignPlotColorMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblDesignPlotColorMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkDesignPlotShowTrigpointText = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowTrigpoint = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowLRUD = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSplayLabel = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSegment = New DevExpress.XtraEditors.CheckEdit()
        Me.chkDesignPlotShowSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.cboDesignPlotSplayStyle = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.chkShowModel = New DevExpress.XtraEditors.CheckEdit()
        Me.pnlModel = New DevExpress.XtraEditors.PanelControl()
        Me.chk3dPlotModelExtendedElevation = New DevExpress.XtraEditors.CheckEdit()
        Me.chkModelColorGray = New DevExpress.XtraEditors.CheckEdit()
        Me.lbl3dPlotModelMode = New DevExpress.XtraEditors.LabelControl()
        Me.cboModelMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboModelColoringMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lbl3dPlotModelColoringMode = New DevExpress.XtraEditors.LabelControl()
        Me.chkShowChunks = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkDesignPlot.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlDesignPlot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDesignPlot.SuspendLayout()
        CType(Me.chkDesignPlotShowSegmentSurface.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSegmentDuplicate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotColorGray.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPlotSegmentsPaintStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPlotColorMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowTrigpointText.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowTrigpoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowLRUD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSplayLabel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSegment.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDesignPlotShowSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDesignPlotSplayStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowModel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlModel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlModel.SuspendLayout()
        CType(Me.chk3dPlotModelExtendedElevation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkModelColorGray.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModelMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModelColoringMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowChunks.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkDesignPlot
        '
        resources.ApplyResources(Me.chkDesignPlot, "chkDesignPlot")
        Me.chkDesignPlot.Name = "chkDesignPlot"
        Me.chkDesignPlot.Properties.AutoWidth = True
        Me.chkDesignPlot.Properties.Caption = resources.GetString("chkDesignPlot.Properties.Caption")
        '
        'pnlDesignPlot
        '
        resources.ApplyResources(Me.pnlDesignPlot, "pnlDesignPlot")
        Me.pnlDesignPlot.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegmentSurface)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegmentDuplicate)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotColorGray)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotSegmentsPaintStyle)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotColorMode)
        Me.pnlDesignPlot.Controls.Add(Me.lblDesignPlotColorMode)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowTrigpointText)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowTrigpoint)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowLRUD)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplayLabel)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSegment)
        Me.pnlDesignPlot.Controls.Add(Me.chkDesignPlotShowSplay)
        Me.pnlDesignPlot.Controls.Add(Me.cboDesignPlotSplayStyle)
        Me.pnlDesignPlot.Name = "pnlDesignPlot"
        '
        'chkDesignPlotShowSegmentSurface
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegmentSurface, "chkDesignPlotShowSegmentSurface")
        Me.chkDesignPlotShowSegmentSurface.Name = "chkDesignPlotShowSegmentSurface"
        Me.chkDesignPlotShowSegmentSurface.Properties.AutoWidth = True
        Me.chkDesignPlotShowSegmentSurface.Properties.Caption = resources.GetString("chkDesignPlotShowSegmentSurface.Properties.Caption")
        '
        'chkDesignPlotShowSegmentDuplicate
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegmentDuplicate, "chkDesignPlotShowSegmentDuplicate")
        Me.chkDesignPlotShowSegmentDuplicate.Name = "chkDesignPlotShowSegmentDuplicate"
        Me.chkDesignPlotShowSegmentDuplicate.Properties.AutoWidth = True
        Me.chkDesignPlotShowSegmentDuplicate.Properties.Caption = resources.GetString("chkDesignPlotShowSegmentDuplicate.Properties.Caption")
        '
        'chkDesignPlotColorGray
        '
        resources.ApplyResources(Me.chkDesignPlotColorGray, "chkDesignPlotColorGray")
        Me.chkDesignPlotColorGray.Name = "chkDesignPlotColorGray"
        Me.chkDesignPlotColorGray.Properties.Appearance.Font = CType(resources.GetObject("chkDesignPlotColorGray.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkDesignPlotColorGray.Properties.Appearance.Options.UseFont = True
        Me.chkDesignPlotColorGray.Properties.AutoWidth = True
        Me.chkDesignPlotColorGray.Properties.Caption = resources.GetString("chkDesignPlotColorGray.Properties.Caption")
        '
        'cboDesignPlotSegmentsPaintStyle
        '
        resources.ApplyResources(Me.cboDesignPlotSegmentsPaintStyle, "cboDesignPlotSegmentsPaintStyle")
        Me.cboDesignPlotSegmentsPaintStyle.Name = "cboDesignPlotSegmentsPaintStyle"
        Me.cboDesignPlotSegmentsPaintStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPlotSegmentsPaintStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPlotSegmentsPaintStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items1"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items2"), resources.GetString("cboDesignPlotSegmentsPaintStyle.Properties.Items3")})
        Me.cboDesignPlotSegmentsPaintStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboDesignPlotColorMode
        '
        resources.ApplyResources(Me.cboDesignPlotColorMode, "cboDesignPlotColorMode")
        Me.cboDesignPlotColorMode.Name = "cboDesignPlotColorMode"
        Me.cboDesignPlotColorMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPlotColorMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPlotColorMode.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPlotColorMode.Properties.Items"), resources.GetString("cboDesignPlotColorMode.Properties.Items1"), resources.GetString("cboDesignPlotColorMode.Properties.Items2")})
        Me.cboDesignPlotColorMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblDesignPlotColorMode
        '
        Me.lblDesignPlotColorMode.Appearance.Font = CType(resources.GetObject("lblDesignPlotColorMode.Appearance.Font"), System.Drawing.Font)
        Me.lblDesignPlotColorMode.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblDesignPlotColorMode, "lblDesignPlotColorMode")
        Me.lblDesignPlotColorMode.Name = "lblDesignPlotColorMode"
        '
        'chkDesignPlotShowTrigpointText
        '
        resources.ApplyResources(Me.chkDesignPlotShowTrigpointText, "chkDesignPlotShowTrigpointText")
        Me.chkDesignPlotShowTrigpointText.Name = "chkDesignPlotShowTrigpointText"
        Me.chkDesignPlotShowTrigpointText.Properties.AutoWidth = True
        Me.chkDesignPlotShowTrigpointText.Properties.Caption = resources.GetString("chkDesignPlotShowTrigpointText.Properties.Caption")
        '
        'chkDesignPlotShowTrigpoint
        '
        resources.ApplyResources(Me.chkDesignPlotShowTrigpoint, "chkDesignPlotShowTrigpoint")
        Me.chkDesignPlotShowTrigpoint.Name = "chkDesignPlotShowTrigpoint"
        Me.chkDesignPlotShowTrigpoint.Properties.AutoWidth = True
        Me.chkDesignPlotShowTrigpoint.Properties.Caption = resources.GetString("chkDesignPlotShowTrigpoint.Properties.Caption")
        '
        'chkDesignPlotShowLRUD
        '
        resources.ApplyResources(Me.chkDesignPlotShowLRUD, "chkDesignPlotShowLRUD")
        Me.chkDesignPlotShowLRUD.Name = "chkDesignPlotShowLRUD"
        Me.chkDesignPlotShowLRUD.Properties.AutoWidth = True
        Me.chkDesignPlotShowLRUD.Properties.Caption = resources.GetString("chkDesignPlotShowLRUD.Properties.Caption")
        '
        'chkDesignPlotShowSplayLabel
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplayLabel, "chkDesignPlotShowSplayLabel")
        Me.chkDesignPlotShowSplayLabel.Name = "chkDesignPlotShowSplayLabel"
        Me.chkDesignPlotShowSplayLabel.Properties.AutoWidth = True
        Me.chkDesignPlotShowSplayLabel.Properties.Caption = resources.GetString("chkDesignPlotShowSplayLabel.Properties.Caption")
        '
        'chkDesignPlotShowSegment
        '
        resources.ApplyResources(Me.chkDesignPlotShowSegment, "chkDesignPlotShowSegment")
        Me.chkDesignPlotShowSegment.Name = "chkDesignPlotShowSegment"
        Me.chkDesignPlotShowSegment.Properties.AutoWidth = True
        Me.chkDesignPlotShowSegment.Properties.Caption = resources.GetString("chkDesignPlotShowSegment.Properties.Caption")
        '
        'chkDesignPlotShowSplay
        '
        resources.ApplyResources(Me.chkDesignPlotShowSplay, "chkDesignPlotShowSplay")
        Me.chkDesignPlotShowSplay.Name = "chkDesignPlotShowSplay"
        Me.chkDesignPlotShowSplay.Properties.AutoWidth = True
        Me.chkDesignPlotShowSplay.Properties.Caption = resources.GetString("chkDesignPlotShowSplay.Properties.Caption")
        '
        'cboDesignPlotSplayStyle
        '
        resources.ApplyResources(Me.cboDesignPlotSplayStyle, "cboDesignPlotSplayStyle")
        Me.cboDesignPlotSplayStyle.Name = "cboDesignPlotSplayStyle"
        Me.cboDesignPlotSplayStyle.Properties.Appearance.Font = CType(resources.GetObject("cboDesignPlotSplayStyle.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboDesignPlotSplayStyle.Properties.Appearance.Options.UseFont = True
        Me.cboDesignPlotSplayStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboDesignPlotSplayStyle.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboDesignPlotSplayStyle.Properties.Items.AddRange(New Object() {resources.GetString("cboDesignPlotSplayStyle.Properties.Items"), resources.GetString("cboDesignPlotSplayStyle.Properties.Items1"), resources.GetString("cboDesignPlotSplayStyle.Properties.Items2")})
        Me.cboDesignPlotSplayStyle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'chkShowModel
        '
        resources.ApplyResources(Me.chkShowModel, "chkShowModel")
        Me.chkShowModel.Name = "chkShowModel"
        Me.chkShowModel.Properties.AutoWidth = True
        Me.chkShowModel.Properties.Caption = resources.GetString("chkShowModel.Properties.Caption")
        '
        'pnlModel
        '
        resources.ApplyResources(Me.pnlModel, "pnlModel")
        Me.pnlModel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pnlModel.Controls.Add(Me.chk3dPlotModelExtendedElevation)
        Me.pnlModel.Controls.Add(Me.chkModelColorGray)
        Me.pnlModel.Controls.Add(Me.lbl3dPlotModelMode)
        Me.pnlModel.Controls.Add(Me.cboModelMode)
        Me.pnlModel.Controls.Add(Me.cboModelColoringMode)
        Me.pnlModel.Controls.Add(Me.lbl3dPlotModelColoringMode)
        Me.pnlModel.Name = "pnlModel"
        '
        'chk3dPlotModelExtendedElevation
        '
        resources.ApplyResources(Me.chk3dPlotModelExtendedElevation, "chk3dPlotModelExtendedElevation")
        Me.chk3dPlotModelExtendedElevation.Name = "chk3dPlotModelExtendedElevation"
        Me.chk3dPlotModelExtendedElevation.Properties.Appearance.Font = CType(resources.GetObject("chk3dPlotModelExtendedElevation.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chk3dPlotModelExtendedElevation.Properties.Appearance.Options.UseFont = True
        Me.chk3dPlotModelExtendedElevation.Properties.AutoWidth = True
        Me.chk3dPlotModelExtendedElevation.Properties.Caption = resources.GetString("chk3dPlotModelExtendedElevation.Properties.Caption")
        '
        'chkModelColorGray
        '
        resources.ApplyResources(Me.chkModelColorGray, "chkModelColorGray")
        Me.chkModelColorGray.Name = "chkModelColorGray"
        Me.chkModelColorGray.Properties.Appearance.Font = CType(resources.GetObject("chkModelColorGray.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkModelColorGray.Properties.Appearance.Options.UseFont = True
        Me.chkModelColorGray.Properties.AutoWidth = True
        Me.chkModelColorGray.Properties.Caption = resources.GetString("chkModelColorGray.Properties.Caption")
        '
        'lbl3dPlotModelMode
        '
        Me.lbl3dPlotModelMode.Appearance.Font = CType(resources.GetObject("lbl3dPlotModelMode.Appearance.Font"), System.Drawing.Font)
        Me.lbl3dPlotModelMode.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lbl3dPlotModelMode, "lbl3dPlotModelMode")
        Me.lbl3dPlotModelMode.Name = "lbl3dPlotModelMode"
        '
        'cboModelMode
        '
        resources.ApplyResources(Me.cboModelMode, "cboModelMode")
        Me.cboModelMode.Name = "cboModelMode"
        Me.cboModelMode.Properties.Appearance.Font = CType(resources.GetObject("cboModelMode.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboModelMode.Properties.Appearance.Options.UseFont = True
        Me.cboModelMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboModelMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboModelMode.Properties.Items.AddRange(New Object() {resources.GetString("cboModelMode.Properties.Items"), resources.GetString("cboModelMode.Properties.Items1"), resources.GetString("cboModelMode.Properties.Items2"), resources.GetString("cboModelMode.Properties.Items3")})
        Me.cboModelMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'cboModelColoringMode
        '
        resources.ApplyResources(Me.cboModelColoringMode, "cboModelColoringMode")
        Me.cboModelColoringMode.Name = "cboModelColoringMode"
        Me.cboModelColoringMode.Properties.Appearance.Font = CType(resources.GetObject("cboModelColoringMode.Properties.Appearance.Font"), System.Drawing.Font)
        Me.cboModelColoringMode.Properties.Appearance.Options.UseFont = True
        Me.cboModelColoringMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboModelColoringMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboModelColoringMode.Properties.Items.AddRange(New Object() {resources.GetString("cboModelColoringMode.Properties.Items"), resources.GetString("cboModelColoringMode.Properties.Items1"), resources.GetString("cboModelColoringMode.Properties.Items2")})
        Me.cboModelColoringMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lbl3dPlotModelColoringMode
        '
        Me.lbl3dPlotModelColoringMode.Appearance.Font = CType(resources.GetObject("lbl3dPlotModelColoringMode.Appearance.Font"), System.Drawing.Font)
        Me.lbl3dPlotModelColoringMode.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lbl3dPlotModelColoringMode, "lbl3dPlotModelColoringMode")
        Me.lbl3dPlotModelColoringMode.Name = "lbl3dPlotModelColoringMode"
        '
        'chkShowChunks
        '
        resources.ApplyResources(Me.chkShowChunks, "chkShowChunks")
        Me.chkShowChunks.Name = "chkShowChunks"
        Me.chkShowChunks.Properties.AutoWidth = True
        Me.chkShowChunks.Properties.Caption = resources.GetString("chkShowChunks.Properties.Caption")
        '
        'cDesign3DModelControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.chkShowChunks)
        Me.Controls.Add(Me.pnlModel)
        Me.Controls.Add(Me.chkShowModel)
        Me.Controls.Add(Me.chkDesignPlot)
        Me.Controls.Add(Me.pnlDesignPlot)
        Me.Name = "cDesign3DModelControl"
        CType(Me.chkDesignPlot.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlDesignPlot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDesignPlot.ResumeLayout(False)
        Me.pnlDesignPlot.PerformLayout()
        CType(Me.chkDesignPlotShowSegmentSurface.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSegmentDuplicate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotColorGray.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPlotSegmentsPaintStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPlotColorMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowTrigpointText.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowTrigpoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowLRUD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSplayLabel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSegment.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDesignPlotShowSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDesignPlotSplayStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowModel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlModel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlModel.ResumeLayout(False)
        Me.pnlModel.PerformLayout()
        CType(Me.chk3dPlotModelExtendedElevation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkModelColorGray.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModelMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModelColoringMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowChunks.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDesignPlot As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlDesignPlot As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chkDesignPlotColorGray As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignPlotSegmentsPaintStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboDesignPlotColorMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblDesignPlotColorMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkDesignPlotShowTrigpointText As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowTrigpoint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowLRUD As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSplayLabel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSegment As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboDesignPlotSplayStyle As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents chkDesignPlotShowSegmentSurface As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkDesignPlotShowSegmentDuplicate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowModel As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlModel As DevExpress.XtraEditors.PanelControl
    Friend WithEvents chk3dPlotModelExtendedElevation As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkModelColorGray As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lbl3dPlotModelMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboModelMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboModelColoringMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lbl3dPlotModelColoringMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkShowChunks As DevExpress.XtraEditors.CheckEdit
End Class
