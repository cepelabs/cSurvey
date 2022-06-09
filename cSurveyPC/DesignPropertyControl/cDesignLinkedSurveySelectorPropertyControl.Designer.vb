<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cDesignLinkedSurveySelectorPropertyControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignLinkedSurveySelectorPropertyControl))
        Me.linkedSurveys = New cSurveyPC.cLinkedSurveySelectorControl()
        Me.chkDesignDrawLinkedSurveys = New DevExpress.XtraEditors.CheckEdit()
        Me.cmdDesignLinkedSurveys = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.chkDesignDrawLinkedSurveys.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'linkedSurveys
        '
        resources.ApplyResources(Me.linkedSurveys, "linkedSurveys")
        Me.linkedSurveys.Name = "linkedSurveys"
        '
        'chkDesignDrawLinkedSurveys
        '
        resources.ApplyResources(Me.chkDesignDrawLinkedSurveys, "chkDesignDrawLinkedSurveys")
        Me.chkDesignDrawLinkedSurveys.Name = "chkDesignDrawLinkedSurveys"
        Me.chkDesignDrawLinkedSurveys.Properties.AutoWidth = True
        Me.chkDesignDrawLinkedSurveys.Properties.Caption = resources.GetString("chkDesignDrawLinkedSurveys.Properties.Caption")
        '
        'cmdDesignLinkedSurveys
        '
        resources.ApplyResources(Me.cmdDesignLinkedSurveys, "cmdDesignLinkedSurveys")
        Me.cmdDesignLinkedSurveys.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdDesignLinkedSurveys.ImageOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.link1
        Me.cmdDesignLinkedSurveys.ImageOptions.SvgImageSize = New System.Drawing.Size(16, 16)
        Me.cmdDesignLinkedSurveys.Name = "cmdDesignLinkedSurveys"
        '
        'cDesignLinkedSurveySelectorPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdDesignLinkedSurveys)
        Me.Controls.Add(Me.chkDesignDrawLinkedSurveys)
        Me.Controls.Add(Me.linkedSurveys)
        Me.Name = "cDesignLinkedSurveySelectorPropertyControl"
        CType(Me.chkDesignDrawLinkedSurveys.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents linkedSurveys As cLinkedSurveySelectorControl
    Friend WithEvents chkDesignDrawLinkedSurveys As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cmdDesignLinkedSurveys As DevExpress.XtraEditors.SimpleButton
End Class
