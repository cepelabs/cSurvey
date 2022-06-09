Imports System.ComponentModel
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraBars.Navigation

Public Class cCollapsablePropertyControlContainer
    Private iClientHeight As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(accordion, False)
    End Sub

    Private oVisibleSeparator As cCollapsablePropertySeparator

    Public Sub SetVisibleSeparator(Control As cCollapsablePropertySeparator)
        oVisibleSeparator = Control
        oVisibleSeparator.appendcontrol(Me)
    End Sub

    Private bIsVisible As Boolean = True

    Public ReadOnly Property IsVisible() As Boolean
        Get
            Return bIsVisible
        End Get
    End Property

    Public Shadows Property Visible As Boolean
        Get
            Return bIsVisible
        End Get
        Set(value As Boolean)
            bIsVisible = value
            If oVisibleSeparator IsNot Nothing Then oVisibleSeparator.UpdateVisibility
            MyBase.Visible = value
        End Set
    End Property

    Public Sub SetClientControl(Caption As String, Control As Control, Height As Integer)
        AccordionControlElement1.Text = Caption
        AccordionControlElement1.ContentContainer.Controls.Add(Control)
        Control.Dock = DockStyle.Fill
        iClientHeight = Height
        AccordionControlElement1.ContentContainer.Height = iClientHeight

        If TypeOf Control Is cItemPropertyControl Then
            Call DirectCast(Control, cItemPropertyControl).SetVisibleParent(Me)
        ElseIf TypeOf Control Is cItemPointPropertyControl Then
            Call DirectCast(Control, cItemPointPropertyControl).SetVisibleParent(Me)
        End If
    End Sub

    Public Property Caption As String
        Get
            Return AccordionControlElement1.Text
        End Get
        Set(value As String)
            AccordionControlElement1.Text = value
        End Set
    End Property

    Private Function pGetElementHeight()
        Try
            Dim viewInfo As AccordionControlViewInfo = TryCast(accordion.GetViewInfo(), AccordionControlViewInfo)
            Dim info = viewInfo.GetElementInfo(accordion.Elements(0))
            If info Is Nothing Then
                Return -1
            Else
                Return info.HeaderBounds.Height
            End If
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Sub cItemCollapsablePropertyControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Call pForceHeight()
    End Sub

    Public Property Expanded As Boolean
        Get
            Return AccordionControlElement1.Expanded
        End Get
        Set(value As Boolean)
            If AccordionControlElement1.Expanded <> value Then
                AccordionControlElement1.Expanded = value
            End If
        End Set
    End Property

    Public Event ExpandStateChanged As ExpandStateChangedEventHandler

    Private Sub accordion_ExpandStateChanged(sender As Object, e As DevExpress.XtraBars.Navigation.ExpandStateChangedEventArgs) Handles accordion.ExpandStateChanged
        Call pForceHeight()
        If AccordionControlElement1.Expanded Then
            AccordionControlElement1.ContextButtons(0).ImageOptionsCollection.ItemNormal.SvgImage = My.Resources.simpledown
        Else
            AccordionControlElement1.ContextButtons(0).ImageOptionsCollection.ItemNormal.SvgImage = My.Resources.simpleup
        End If
        RaiseEvent ExpandStateChanged(Me, e)
    End Sub

    Private Sub pForceHeight()
        Dim iElementHeight As Integer = pGetElementHeight()
        If iElementHeight > 0 Then
            accordion.BeginUpdate()
            If AccordionControlElement1.Expanded Then
                If Me.Height <> iClientHeight + iElementHeight Then
                    Me.Height = iClientHeight + iElementHeight
                End If
            Else
                If Me.Height <> iElementHeight Then
                    Me.Height = iElementHeight
                End If
            End If
            accordion.EndUpdate()
        End If
    End Sub

    Private Sub cCollapsablePropertyControlContainer_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            Call pForceHeight()
        End If
    End Sub

    Private Sub accordion_ContextButtonClick(sender As Object, e As DevExpress.Utils.ContextItemClickEventArgs) Handles accordion.ContextButtonClick
        If AccordionControlElement1.Expanded Then
            AccordionControlElement1.Expanded = False
        Else
            AccordionControlElement1.Expanded = True
        End If
    End Sub
End Class
