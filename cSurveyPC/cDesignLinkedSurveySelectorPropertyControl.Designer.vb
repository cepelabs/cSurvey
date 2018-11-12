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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cDesignLinkedSurveySelectorPropertyControl))
        Me.linkedSurveys = New cSurveyPC.cLinkedSurveySelectorControl()
        Me.chkDesignDrawLinkedSurveys = New System.Windows.Forms.CheckBox()
        Me.cmdDesignLinkedSurveys = New System.Windows.Forms.Button()
        Me.tipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'linkedSurveys
        '
        resources.ApplyResources(Me.linkedSurveys, "linkedSurveys")
        Me.linkedSurveys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.linkedSurveys.Name = "linkedSurveys"
        '
        'chkDesignDrawLinkedSurveys
        '
        resources.ApplyResources(Me.chkDesignDrawLinkedSurveys, "chkDesignDrawLinkedSurveys")
        Me.chkDesignDrawLinkedSurveys.Name = "chkDesignDrawLinkedSurveys"
        Me.chkDesignDrawLinkedSurveys.UseVisualStyleBackColor = True
        '
        'cmdDesignLinkedSurveys
        '
        resources.ApplyResources(Me.cmdDesignLinkedSurveys, "cmdDesignLinkedSurveys")
        Me.cmdDesignLinkedSurveys.Image = Global.cSurveyPC.My.Resources.Resources.link
        Me.cmdDesignLinkedSurveys.Name = "cmdDesignLinkedSurveys"
        Me.tipMain.SetToolTip(Me.cmdDesignLinkedSurveys, resources.GetString("cmdDesignLinkedSurveys.ToolTip"))
        Me.cmdDesignLinkedSurveys.UseVisualStyleBackColor = True
        '
        'cDesignLinkedSurveySelectorPropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdDesignLinkedSurveys)
        Me.Controls.Add(Me.chkDesignDrawLinkedSurveys)
        Me.Controls.Add(Me.linkedSurveys)
        Me.Name = "cDesignLinkedSurveySelectorPropertyControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents linkedSurveys As cLinkedSurveySelectorControl
    Friend WithEvents chkDesignDrawLinkedSurveys As CheckBox
    Friend WithEvents cmdDesignLinkedSurveys As Button
    Friend WithEvents tipMain As ToolTip
End Class
