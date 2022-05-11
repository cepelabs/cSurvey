<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cElevationDropDown
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cElevationDropDown))
        Me.iml = New DevExpress.Utils.ImageCollection(Me.components)
        Me.cboElevationData = New DevExpress.XtraEditors.ImageComboBoxEdit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboElevationData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'iml
        '
        resources.ApplyResources(Me.iml, "iml")
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'cboElevationData
        '
        resources.ApplyResources(Me.cboElevationData, "cboElevationData")
        Me.cboElevationData.Name = "cboElevationData"
        Me.cboElevationData.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboElevationData.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboElevationData.Properties.LargeImages = Me.iml
        Me.cboElevationData.Properties.SmallImages = Me.iml
        '
        'cElevationDropDown
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboElevationData)
        Me.Name = "cElevationDropDown"
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboElevationData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents iml As DevExpress.Utils.ImageCollection
    Friend WithEvents cboElevationData As DevExpress.XtraEditors.ImageComboBoxEdit
End Class
