Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

<Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", GetType(IDesigner))>
Public Class cPanelControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    'Private oVisibleParent As cCollapsablePropertyControlContainer

    'Public Sub SetVisibleParent(Control As cCollapsablePropertyControlContainer)
    '    oVisibleParent = Control
    'End Sub

    'Private bIsVisible As Boolean = True

    'Public ReadOnly Property IsVisible() As Boolean
    '    Get
    '        Return bIsVisible
    '    End Get
    'End Property

    'Public Shadows Property Visible As Boolean
    '    Get
    '        Return bIsVisible
    '    End Get
    '    Set(value As Boolean)
    '        bIsVisible = value
    '        If oVisibleParent IsNot Nothing Then oVisibleParent.Visible = bIsVisible
    '        MyBase.Visible = value
    '        If MyBase.Parent IsNot Nothing Then
    '            If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
    '                DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me).Visibility = If(bIsVisible, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
    '            End If
    '        End If
    '    End Set
    'End Property

    Public Shadows Property Height As Integer
        Get
            Return MyBase.Height
        End Get
        Set(value As Integer)
            If MyBase.Height <> value Then
                If MyBase.Height < value Then
                    If MyBase.Parent IsNot Nothing Then
                        If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
                            With DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me)
                                .ControlMaxSize = New Size(0, value)
                                .ControlMinSize = New Size(0, value)
                            End With
                        End If
                    End If
                Else
                    If MyBase.Parent IsNot Nothing Then
                        If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
                            With DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me)
                                .ControlMinSize = New Size(0, value)
                                .ControlMaxSize = New Size(0, value)
                            End With
                        End If
                    End If
                End If
                MyBase.Height = value
            End If
        End Set
    End Property

End Class
