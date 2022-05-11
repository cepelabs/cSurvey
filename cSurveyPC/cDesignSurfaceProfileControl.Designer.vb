<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesignSurfaceProfileControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignSurfaceProfileControl))
        Me.chkDesignSurfaceProfile = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.chkDesignSurfaceProfile.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkDesignSurfaceProfile
        '
        resources.ApplyResources(Me.chkDesignSurfaceProfile, "chkDesignSurfaceProfile")
        Me.chkDesignSurfaceProfile.Name = "chkDesignSurfaceProfile"
        Me.chkDesignSurfaceProfile.Properties.AutoWidth = True
        Me.chkDesignSurfaceProfile.Properties.Caption = resources.GetString("chkDesignSurfaceProfile.Properties.Caption")
        '
        'cDesignSurfaceProfileControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chkDesignSurfaceProfile)
        Me.Name = "cDesignSurfaceProfileControl"
        CType(Me.chkDesignSurfaceProfile.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDesignSurfaceProfile As DevExpress.XtraEditors.CheckEdit
End Class
