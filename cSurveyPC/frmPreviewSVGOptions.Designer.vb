<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreviewSVGOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviewSVGOptions))
        Me.frmSVGOptions = New DevExpress.XtraEditors.GroupControl()
        Me.chkSVGReuseClipartPath = New DevExpress.XtraEditors.CheckEdit()
        Me.chkSVGUseStyle = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.frmSVGOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmSVGOptions.SuspendLayout()
        CType(Me.chkSVGReuseClipartPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSVGUseStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmSVGOptions
        '
        resources.ApplyResources(Me.frmSVGOptions, "frmSVGOptions")
        Me.frmSVGOptions.Controls.Add(Me.chkSVGUseStyle)
        Me.frmSVGOptions.Controls.Add(Me.chkSVGReuseClipartPath)
        Me.frmSVGOptions.Name = "frmSVGOptions"
        '
        'chkSVGReuseClipartPath
        '
        resources.ApplyResources(Me.chkSVGReuseClipartPath, "chkSVGReuseClipartPath")
        Me.chkSVGReuseClipartPath.Name = "chkSVGReuseClipartPath"
        Me.chkSVGReuseClipartPath.Properties.AutoWidth = True
        Me.chkSVGReuseClipartPath.Properties.Caption = resources.GetString("CheckEdit1.Properties.Caption1")
        '
        'chkSVGUseStyle
        '
        resources.ApplyResources(Me.chkSVGUseStyle, "chkSVGUseStyle")
        Me.chkSVGUseStyle.Name = "chkSVGUseStyle"
        Me.chkSVGUseStyle.Properties.AutoWidth = True
        Me.chkSVGUseStyle.Properties.Caption = resources.GetString("CheckEdit1.Properties.Caption")
        '
        'frmPreviewSVGOptions
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.frmSVGOptions)
        Me.Name = "frmPreviewSVGOptions"
        CType(Me.frmSVGOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmSVGOptions.ResumeLayout(False)
        Me.frmSVGOptions.PerformLayout()
        CType(Me.chkSVGReuseClipartPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSVGUseStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmSVGOptions As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkSVGUseStyle As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkSVGReuseClipartPath As DevExpress.XtraEditors.CheckEdit
End Class
