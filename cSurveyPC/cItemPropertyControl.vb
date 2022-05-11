Imports System.ComponentModel
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design

Public Class cItemPropertyControl
    Implements cIUIInteractions

    Private oItem As cItem

    Public Overridable ReadOnly Property Item As cItem
        Get
            Return oItem
        End Get
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DisabledObjectProperty() As Boolean
        Get
            If oItem Is Nothing Then
                Return True
            Else
                Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent)
                RaiseEvent OnGetFlags(Me, oArgs)
                Return oArgs.Value
            End If
        End Get
        Set(value As Boolean)
            If Not oItem Is Nothing Then
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

    Public Overridable Sub Rebind(Item As cItem)
        oItem = Item
    End Sub
End Class
