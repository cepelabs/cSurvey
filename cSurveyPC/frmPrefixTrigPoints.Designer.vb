<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrefixTrigPoints
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrefixTrigPoints))
        Me.ListBox1 = New DevExpress.XtraEditors.ListBoxControl()
        Me.ListBox2 = New DevExpress.XtraEditors.ListBoxControl()
        Me.Button1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button2 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtPrefix = New DevExpress.XtraEditors.TextEdit()
        Me.lblPrefix = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdOk = New DevExpress.XtraEditors.SimpleButton()
        Me.Button3 = New DevExpress.XtraEditors.SimpleButton()
        Me.Button4 = New DevExpress.XtraEditors.SimpleButton()
        Me.chkShowSplay = New DevExpress.XtraEditors.CheckEdit()
        Me.optRemove = New DevExpress.XtraEditors.CheckButton()
        Me.optAdd = New DevExpress.XtraEditors.CheckButton()
        CType(Me.ListBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowSplay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.Appearance.Font = CType(resources.GetObject("ListBox1.Appearance.Font"), System.Drawing.Font)
        Me.ListBox1.Appearance.Options.UseFont = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.SortOrder = System.Windows.Forms.SortOrder.Ascending
        '
        'ListBox2
        '
        resources.ApplyResources(Me.ListBox2, "ListBox2")
        Me.ListBox2.Appearance.Font = CType(resources.GetObject("ListBox2.Appearance.Font"), System.Drawing.Font)
        Me.ListBox2.Appearance.Options.UseFont = True
        Me.ListBox2.ItemHeight = 14
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox2.SortOrder = System.Windows.Forms.SortOrder.Ascending
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        '
        'Button2
        '
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.Name = "Button2"
        '
        'txtPrefix
        '
        resources.ApplyResources(Me.txtPrefix, "txtPrefix")
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Properties.Appearance.Font = CType(resources.GetObject("txtPrefix.Properties.Appearance.Font"), System.Drawing.Font)
        Me.txtPrefix.Properties.Appearance.Options.UseFont = True
        Me.txtPrefix.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        '
        'lblPrefix
        '
        Me.lblPrefix.Appearance.Font = CType(resources.GetObject("lblPrefix.Appearance.Font"), System.Drawing.Font)
        Me.lblPrefix.Appearance.Options.UseFont = True
        resources.ApplyResources(Me.lblPrefix, "lblPrefix")
        Me.lblPrefix.Name = "lblPrefix"
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
        Me.cmdOk.Name = "cmdOk"
        '
        'Button3
        '
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        '
        'Button4
        '
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.Name = "Button4"
        '
        'chkShowSplay
        '
        resources.ApplyResources(Me.chkShowSplay, "chkShowSplay")
        Me.chkShowSplay.Name = "chkShowSplay"
        Me.chkShowSplay.Properties.Caption = resources.GetString("chkShowSplay.Properties.Caption")
        '
        'optRemove
        '
        Me.optRemove.GroupIndex = 1
        resources.ApplyResources(Me.optRemove, "optRemove")
        Me.optRemove.Name = "optRemove"
        Me.optRemove.TabStop = False
        '
        'optAdd
        '
        Me.optAdd.Checked = True
        Me.optAdd.GroupIndex = 1
        resources.ApplyResources(Me.optAdd, "optAdd")
        Me.optAdd.Name = "optAdd"
        '
        'frmPrefixTrigPoints
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtPrefix)
        Me.Controls.Add(Me.lblPrefix)
        Me.Controls.Add(Me.optRemove)
        Me.Controls.Add(Me.optAdd)
        Me.Controls.Add(Me.chkShowSplay)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ListBox1)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.addprefix
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrefixTrigPoints"
        CType(Me.ListBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrefix.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowSplay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents ListBox2 As DevExpress.XtraEditors.ListBoxControl
    Friend WithEvents Button1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtPrefix As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblPrefix As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOk As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Button4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chkShowSplay As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents optAdd As DevExpress.XtraEditors.CheckButton
    Friend WithEvents optRemove As DevExpress.XtraEditors.CheckButton
End Class
