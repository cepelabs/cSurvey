<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cItemVisibilityPropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemVisibilityPropertyControl))
        Me.cboPropAffinity = New System.Windows.Forms.ComboBox()
        Me.lblPropAffinity = New System.Windows.Forms.Label()
        Me.chkPropVisibleByProfile = New System.Windows.Forms.Button()
        Me.chkPropVisibleByScale = New System.Windows.Forms.Button()
        Me.lblPropVisibleIn = New System.Windows.Forms.Label()
        Me.chkPropVisibleInDesign = New System.Windows.Forms.CheckBox()
        Me.chkPropVisibleInPreview = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cboPropAffinity
        '
        Me.cboPropAffinity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropAffinity.FormattingEnabled = True
        Me.cboPropAffinity.Items.AddRange(New Object() {resources.GetString("cboPropAffinity.Items"), resources.GetString("cboPropAffinity.Items1")})
        resources.ApplyResources(Me.cboPropAffinity, "cboPropAffinity")
        Me.cboPropAffinity.Name = "cboPropAffinity"
        '
        'lblPropAffinity
        '
        resources.ApplyResources(Me.lblPropAffinity, "lblPropAffinity")
        Me.lblPropAffinity.Name = "lblPropAffinity"
        '
        'chkPropVisibleByProfile
        '
        Me.chkPropVisibleByProfile.Image = Global.cSurveyPC.My.Resources.Resources.to_do_list
        resources.ApplyResources(Me.chkPropVisibleByProfile, "chkPropVisibleByProfile")
        Me.chkPropVisibleByProfile.Name = "chkPropVisibleByProfile"
        Me.chkPropVisibleByProfile.UseVisualStyleBackColor = True
        '
        'chkPropVisibleByScale
        '
        Me.chkPropVisibleByScale.Image = Global.cSurveyPC.My.Resources.Resources.layers_map
        resources.ApplyResources(Me.chkPropVisibleByScale, "chkPropVisibleByScale")
        Me.chkPropVisibleByScale.Name = "chkPropVisibleByScale"
        Me.chkPropVisibleByScale.UseVisualStyleBackColor = True
        '
        'lblPropVisibleIn
        '
        resources.ApplyResources(Me.lblPropVisibleIn, "lblPropVisibleIn")
        Me.lblPropVisibleIn.Name = "lblPropVisibleIn"
        '
        'chkPropVisibleInDesign
        '
        resources.ApplyResources(Me.chkPropVisibleInDesign, "chkPropVisibleInDesign")
        Me.chkPropVisibleInDesign.Name = "chkPropVisibleInDesign"
        Me.chkPropVisibleInDesign.UseVisualStyleBackColor = True
        '
        'chkPropVisibleInPreview
        '
        resources.ApplyResources(Me.chkPropVisibleInPreview, "chkPropVisibleInPreview")
        Me.chkPropVisibleInPreview.Name = "chkPropVisibleInPreview"
        Me.chkPropVisibleInPreview.UseVisualStyleBackColor = True
        '
        'cItemVisibilityPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cboPropAffinity)
        Me.Controls.Add(Me.lblPropAffinity)
        Me.Controls.Add(Me.chkPropVisibleByProfile)
        Me.Controls.Add(Me.chkPropVisibleByScale)
        Me.Controls.Add(Me.lblPropVisibleIn)
        Me.Controls.Add(Me.chkPropVisibleInDesign)
        Me.Controls.Add(Me.chkPropVisibleInPreview)
        Me.Name = "cItemVisibilityPropertyControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboPropAffinity As ComboBox
    Friend WithEvents lblPropAffinity As Label
    Friend WithEvents chkPropVisibleByProfile As Button
    Friend WithEvents chkPropVisibleByScale As Button
    Friend WithEvents lblPropVisibleIn As Label
    Friend WithEvents chkPropVisibleInDesign As CheckBox
    Friend WithEvents chkPropVisibleInPreview As CheckBox
End Class
