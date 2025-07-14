Imports System.ComponentModel
Imports System.Drawing
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design

Public Class cItemPointPropertyControl
    Implements cUIControlPropertyInteractions

    Private oPoint As cPoint

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If My.Application.CurrentLanguage = "it" Then
            If My.Application.ChangeDecimalKey AndAlso keyData = Keys.Decimal Then
                SendKeys.Send(",")
                Return True
            ElseIf My.Application.ChangePeriodKey AndAlso keyData = Keys.OemPeriod Then
                SendKeys.Send(",")
                Return True
            Else
                Return MyBase.ProcessCmdKey(msg, keyData)
            End If
        End If
    End Function
    Public Overridable ReadOnly Property Point As cPoint
        Get
            Return oPoint
        End Get
    End Property

    Public Overridable ReadOnly Property Item As cItem
        Get
            Return oPoint.Item
        End Get
    End Property

    Public Overridable Sub Rebind(Point As cPoint)
        oPoint = Point
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    Private oVisibleParent As cCollapsablePropertyControlContainer

    Public Sub SetVisibleParent(Control As cCollapsablePropertyControlContainer)
        oVisibleParent = Control
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
            If oVisibleParent IsNot Nothing Then oVisibleParent.Visible = bIsVisible
            MyBase.Visible = value
            If MyBase.Parent IsNot Nothing Then
                If TypeOf MyBase.Parent Is DevExpress.XtraLayout.LayoutControl Then
                    DirectCast(MyBase.Parent, DevExpress.XtraLayout.LayoutControl).GetItemByControl(Me).Visibility = If(bIsVisible, DevExpress.XtraLayout.Utils.LayoutVisibility.Always, DevExpress.XtraLayout.Utils.LayoutVisibility.Never)
                End If
            End If
        End Set
    End Property

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

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DisabledObjectProperty() As Boolean
        Get
            If oPoint Is Nothing Then
                Return True
            Else
                Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent)
                RaiseEvent OnGetFlags(Me, oArgs)
                Return oArgs.Value
            End If
        End Get
        Set(value As Boolean)
            If Not oPoint Is Nothing Then
                Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent, value)
                RaiseEvent OnSetFlags(Me, oArgs)
            End If
        End Set
    End Property

    Public Event OnGetFlags(Sender As Object, e As FlagEventArgs) Implements cUIControlPropertyInteractions.OnGetFlags
    Public Event OnSetFlags(Sender As Object, e As FlagEventArgs) Implements cUIControlPropertyInteractions.OnSetFlags

    Public Event OnDrawInvalidate(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnDrawInvalidate
    Public Event OnSurveyInvalidate(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnSurveyInvalidate
    Public Event OnObjectPropertyLoad(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnObjectPropertyLoad
    Public Event OnDoCommand(Sender As Object, e As DoCommandEventArgs) Implements cUIControlPropertyInteractions.OnDoCommand

    Public Event OnMapInvalidate(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnMapInvalidate
    Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cUIControlPropertyInteractions.OnPropertyChanged

    Public Event OnTakeUndoSnapshot(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnTakeUndoSnapshot
    Public Event OnCreateUndoSnapshot(Sender As Object, e As CreateUndoSnapshotEventArgs) Implements cUIControlPropertyInteractions.OnCreateUndoSnapshot
    Public Event OnBeginUndoSnapshot(Sender As Object, e As BeginUndoSnapshotEventArgs) Implements cUIControlPropertyInteractions.OnBeginUndoSnapshot
    Public Event OnCommitUndoSnapshot(Sender As Object, e As CommitUndoSnapshotEventArgs) Implements cUIControlPropertyInteractions.OnCommitUndoSnapshot
    Public Event OnCancelUndoSnapshot(Sender As Object, e As EventArgs) Implements cUIControlPropertyInteractions.OnCancelUndoSnapshot

    Public Sub CreateUndoSnapshot(Description As String, PropertyName As String)
        RaiseEvent OnCreateUndoSnapshot(Me, New CreateUndoSnapshotEventArgs(Description, PropertyName))
    End Sub

    Public Sub BeginUndoSnapshot(Description As String)
        RaiseEvent OnBeginUndoSnapshot(Me, New BeginUndoSnapshotEventArgs(Description))
    End Sub

    Public Sub CancelUndoSnapshot()
        RaiseEvent OnCancelUndoSnapshot(Me, EventArgs.Empty)
    End Sub

    Public Sub CommitUndoSnapshot(Optional SkipIfNotBeginned As Boolean = False)
        RaiseEvent OnCommitUndoSnapshot(Me, New CommitUndoSnapshotEventArgs(SkipIfNotBeginned))
    End Sub

    Public Sub TakeUndoSnapshot()
        RaiseEvent OnTakeUndoSnapshot(Me, EventArgs.Empty)
    End Sub

    Public Sub DrawInvalidate()
        RaiseEvent OnDrawInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub SurveyInvalidate()
        RaiseEvent OnSurveyInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub MapInvalidate() Implements cIUIInteractions.MapInvalidate
        RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub DoCommand(Command As String, ParamArray Args As Object())
        RaiseEvent OnDoCommand(Me, New DoCommandEventArgs(Command, Args))
    End Sub

    Public Sub ObjectPropertyLoad()
        RaiseEvent OnObjectPropertyLoad(Me, EventArgs.Empty)
    End Sub

    Public Sub PropertyChanged(Name As String) Implements cIUIInteractions.PropertyChanged
        RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
    End Sub
End Class
