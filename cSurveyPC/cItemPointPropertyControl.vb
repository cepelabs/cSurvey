Imports System.ComponentModel
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design

Public Class cItemPointPropertyControl
    Implements cIUIInteractions

    Private oPoint As cPoint

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

    'Private Sub SetPoint(Point As cPoint)
    '    oPoint = Point
    'End Sub

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
    Public Event OnGetFlags(Sender As Object, e As FlagEventArgs)
    Public Event OnSetFlags(Sender As Object, e As FlagEventArgs)

    Public Event OnDrawInvalidate(Sender As Object, e As EventArgs)
    Public Event OnSurveyInvalidate(Sender As Object, e As EventArgs)
    Public Event OnObjectPropertyLoad(Sender As Object, e As EventArgs)
    Public Event OnTakeUndoSnapshot(Sender As Object, e As EventArgs)
    Public Event OnDoCommand(Sender As Object, e As DoCommandEventArgs)

    Public Event OnMapInvalidate(Sender As Object, e As EventArgs) Implements cIUIInteractions.OnMapInvalidate
    Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIInteractions.OnPropertyChanged

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
