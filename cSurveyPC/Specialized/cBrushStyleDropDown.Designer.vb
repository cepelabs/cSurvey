<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cBrushStyleDropDown
    Inherits System.Windows.Forms.UserControl

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
        Me.components = New System.ComponentModel.Container()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.iml = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.cboBrushStyle = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.captioniml = New DevExpress.Utils.SvgImageCollection(Me.components)
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBrushStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.captioniml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.ReadOnly = True
        '
        'iml
        '
        Me.iml.ImageSize = New System.Drawing.Size(32, 32)
        '
        'cboBrushStyle
        '
        Me.cboBrushStyle.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboBrushStyle.Location = New System.Drawing.Point(0, 0)
        Me.cboBrushStyle.Name = "cboBrushStyle"
        Me.cboBrushStyle.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboBrushStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.cboBrushStyle.Properties.HtmlImages = Me.captioniml
        Me.cboBrushStyle.Properties.SmallImages = Me.iml
        Me.cboBrushStyle.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.cboBrushStyle.Size = New System.Drawing.Size(150, 34)
        Me.cboBrushStyle.TabIndex = 201
        '
        'captioniml
        '
        Me.captioniml.Add("save", "save", GetType(cSurveyPC.My.Resources.Resources))
        Me.captioniml.Add("user", "user", GetType(cSurveyPC.My.Resources.Resources))
        Me.captioniml.Add("brushesandpens", "brushesandpens", GetType(cSurveyPC.My.Resources.Resources))
        '
        'cBrushStyleDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboBrushStyle)
        Me.Name = "cBrushStyleDropDown"
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBrushStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.captioniml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents cboBrushStyle As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents captioniml As DevExpress.Utils.SvgImageCollection
End Class
