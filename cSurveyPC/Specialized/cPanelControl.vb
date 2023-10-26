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

    'Public Shadows Property Height As Integer
    '    Get
    '        Return MyBase.Height
    '    End Get
    '    Set(value As Integer)
    '        If MyBase.Height <> value Then
    '            If MyBase.Height < value Then
    '                If MyBase.Parent IsNot Nothing Then
    '                    If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
    '                        With DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me)
    '                            .ControlMaxSize = New Size(0, value)
    '                            .ControlMinSize = New Size(0, value)
    '                        End With
    '                    End If
    '                End If
    '            Else
    '                If MyBase.Parent IsNot Nothing Then
    '                    If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
    '                        With DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me)
    '                            .ControlMinSize = New Size(0, value)
    '                            .ControlMaxSize = New Size(0, value)
    '                        End With
    '                    End If
    '                End If
    '            End If
    '            MyBase.Height = value
    '        End If
    '    End Set
    'End Property

End Class
