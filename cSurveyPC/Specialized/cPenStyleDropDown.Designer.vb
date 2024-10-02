<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cPenStyleDropDown
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
        Me.cboPenStyle = New DevExpress.XtraEditors.ImageComboBoxEdit()
        Me.captioniml = New DevExpress.Utils.SvgImageCollection(Me.components)
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPenStyle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'cboPenStyle
        '
        Me.cboPenStyle.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboPenStyle.Location = New System.Drawing.Point(0, 0)
        Me.cboPenStyle.Name = "cboPenStyle"
        Me.cboPenStyle.Properties.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        Me.cboPenStyle.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboPenStyle.Properties.HtmlImages = Me.captioniml
        Me.cboPenStyle.Properties.SmallImages = Me.iml
        Me.cboPenStyle.Properties.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None
        Me.cboPenStyle.Size = New System.Drawing.Size(150, 34)
        Me.cboPenStyle.TabIndex = 201
        '
        'captioniml
        '
        Me.captioniml.Add("save", "save", GetType(cSurveyPC.My.Resources.Resources))
        Me.captioniml.Add("user", "user", GetType(cSurveyPC.My.Resources.Resources))
        Me.captioniml.Add("brushesandpens", "brushesandpens", GetType(cSurveyPC.My.Resources.Resources))
        '
        'cPenStyleDropDown
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboPenStyle)
        Me.Name = "cPenStyleDropDown"
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.iml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPenStyle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.captioniml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents iml As DevExpress.Utils.SvgImageCollection
    Friend WithEvents cboPenStyle As DevExpress.XtraEditors.ImageComboBoxEdit
    Friend WithEvents captioniml As DevExpress.Utils.SvgImageCollection
End Class
