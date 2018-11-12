<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cDesignPrintOrExportAreaControl
    Inherits cDesignPropertyControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignPrintOrExportAreaControl))
        Me.pnlDesignPrintOrExportArea = New System.Windows.Forms.Panel()
        Me.cboDesignPrintOrExportAreaProfile = New System.Windows.Forms.ComboBox()
        Me.lblDesignPrintOrExportAreaProfile = New System.Windows.Forms.Label()
        Me.chkDesignPrintOrExportArea = New System.Windows.Forms.CheckBox()
        Me.pnlDesignPrintOrExportArea.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDesignPrintOrExportArea
        '
        resources.ApplyResources(Me.pnlDesignPrintOrExportArea, "pnlDesignPrintOrExportArea")
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.cboDesignPrintOrExportAreaProfile)
        Me.pnlDesignPrintOrExportArea.Controls.Add(Me.lblDesignPrintOrExportAreaProfile)
        Me.pnlDesignPrintOrExportArea.Name = "pnlDesignPrintOrExportArea"
        '
        'cboDesignPrintOrExportAreaProfile
        '
        resources.ApplyResources(Me.cboDesignPrintOrExportAreaProfile, "cboDesignPrintOrExportAreaProfile")
        Me.cboDesignPrintOrExportAreaProfile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboDesignPrintOrExportAreaProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDesignPrintOrExportAreaProfile.FormattingEnabled = True
        Me.cboDesignPrintOrExportAreaProfile.Name = "cboDesignPrintOrExportAreaProfile"
        '
        'lblDesignPrintOrExportAreaProfile
        '
        resources.ApplyResources(Me.lblDesignPrintOrExportAreaProfile, "lblDesignPrintOrExportAreaProfile")
        Me.lblDesignPrintOrExportAreaProfile.Name = "lblDesignPrintOrExportAreaProfile"
        '
        'chkDesignPrintOrExportArea
        '
        resources.ApplyResources(Me.chkDesignPrintOrExportArea, "chkDesignPrintOrExportArea")
        Me.chkDesignPrintOrExportArea.Name = "chkDesignPrintOrExportArea"
        Me.chkDesignPrintOrExportArea.UseVisualStyleBackColor = True
        '
        'cDesignPrintOrExportAreaControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.pnlDesignPrintOrExportArea)
        Me.Controls.Add(Me.chkDesignPrintOrExportArea)
        Me.Name = "cDesignPrintOrExportAreaControl"
        Me.pnlDesignPrintOrExportArea.ResumeLayout(False)
        Me.pnlDesignPrintOrExportArea.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlDesignPrintOrExportArea As Panel
    Friend WithEvents cboDesignPrintOrExportAreaProfile As ComboBox
    Friend WithEvents lblDesignPrintOrExportAreaProfile As Label
    Friend WithEvents chkDesignPrintOrExportArea As CheckBox
End Class
