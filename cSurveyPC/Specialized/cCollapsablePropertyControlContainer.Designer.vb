<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cCollapsablePropertyControlContainer
    Inherits DevExpress.XtraEditors.XtraUserControl

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cCollapsablePropertyControlContainer))
        Dim AccordionContextButton1 As DevExpress.XtraBars.Navigation.AccordionContextButton = New DevExpress.XtraBars.Navigation.AccordionContextButton()
        Dim AccordionContextButton2 As DevExpress.XtraBars.Navigation.AccordionContextButton = New DevExpress.XtraBars.Navigation.AccordionContextButton()
        Me.accordion = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.accordionContainer = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        CType(Me.accordion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.accordion.SuspendLayout()
        Me.SuspendLayout()
        '
        'accordion
        '
        Me.accordion.Controls.Add(Me.accordionContainer)
        resources.ApplyResources(Me.accordion, "accordion")
        Me.accordion.ElementPositionOnExpanding = DevExpress.XtraBars.Navigation.ElementPositionOnExpanding.Fixed
        Me.accordion.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.accordion.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple
        Me.accordion.Name = "accordion"
        Me.accordion.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden
        Me.accordion.ShowItemExpandButtons = False
        '
        'accordionContainer
        '
        Me.accordionContainer.Name = "accordionContainer"
        resources.ApplyResources(Me.accordionContainer, "accordionContainer")
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.ContentContainer = Me.accordionContainer
        AccordionContextButton1.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        AccordionContextButton1.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        AccordionContextButton1.Id = New System.Guid("4c6fc153-1b1f-4704-b828-ab6f660efcf3")
        AccordionContextButton1.ImageOptionsCollection.ItemNormal.SvgImage = Global.cSurveyPC.My.Resources.Resources.simpleup
        AccordionContextButton1.ImageOptionsCollection.ItemNormal.SvgImageSize = New System.Drawing.Size(16, 16)
        AccordionContextButton1.Name = "btnExpand"
        AccordionContextButton1.Padding = New System.Windows.Forms.Padding(2, 0, 4, 0)
        resources.ApplyResources(AccordionContextButton1, "AccordionContextButton1")
        AccordionContextButton1.Visibility = DevExpress.Utils.ContextItemVisibility.Visible
        AccordionContextButton2.AlignmentOptions.Panel = DevExpress.Utils.ContextItemPanel.Center
        AccordionContextButton2.AlignmentOptions.Position = DevExpress.Utils.ContextItemPosition.Far
        AccordionContextButton2.Id = New System.Guid("f6029b76-8091-4825-bcb1-646e2a32653e")
        AccordionContextButton2.ImageOptionsCollection.ItemNormal.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_fullscreen
        AccordionContextButton2.ImageOptionsCollection.ItemNormal.SvgImageSize = New System.Drawing.Size(16, 16)
        AccordionContextButton2.Name = "btnMaximize"
        AccordionContextButton2.Padding = New System.Windows.Forms.Padding(2, 0, 4, 0)
        resources.ApplyResources(AccordionContextButton2, "AccordionContextButton2")
        AccordionContextButton2.Visibility = DevExpress.Utils.ContextItemVisibility.Hidden
        Me.AccordionControlElement1.ContextButtons.Add(AccordionContextButton1)
        Me.AccordionControlElement1.ContextButtons.Add(AccordionContextButton2)
        Me.AccordionControlElement1.Expanded = True
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        resources.ApplyResources(Me.AccordionControlElement1, "AccordionControlElement1")
        '
        'cCollapsablePropertyControlContainer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.accordion)
        Me.Name = "cCollapsablePropertyControlContainer"
        CType(Me.accordion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.accordion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents accordion As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents accordionContainer As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
End Class
