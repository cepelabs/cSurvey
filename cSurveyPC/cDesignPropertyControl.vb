Imports System.ComponentModel
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design

Public Class cDesignPropertyControl
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DisabledObjectProperty() As Boolean
        Get
            Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent)
            RaiseEvent OnGetFlags(Me, oArgs)
            Return oArgs.Value
        End Get
        Set(value As Boolean)
            Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent, value)
            RaiseEvent OnSetFlags(Me, oArgs)
        End Set
    End Property
    Public Event OnGetFlags(Sender As Object, e As FlagEventArgs)
    Public Event OnSetFlags(Sender As Object, e As FlagEventArgs)

    Public Event OnMapInvalidate(Sender As Object, e As EventArgs)
    Public Event OnDrawInvalidate(Sender As Object, e As EventArgs)
    Public Event OnSurveyInvalidate(Sender As Object, e As EventArgs)
    Public Event OnObjectPropertyLoad(Sender As Object, e As EventArgs)
    Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs)
    Public Event OnTakeUndoSnapshot(Sender As Object, e As EventArgs)
    Public Event OnDoCommand(Sender As Object, e As DoCommandEventArgs)

    Public Sub TakeUndoSnapshot()
        RaiseEvent OnTakeUndoSnapshot(Me, EventArgs.Empty)
    End Sub

    Public Sub DrawInvalidate()
        RaiseEvent OnDrawInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub SurveyInvalidate()
        RaiseEvent OnSurveyInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub MapInvalidate()
        RaiseEvent OnMapInvalidate(Me, EventArgs.Empty)
    End Sub

    Public Sub DoCommand(Command As String, ParamArray Args As Object())
        RaiseEvent OnDoCommand(Me, New DoCommandEventArgs(Command, Args))
    End Sub

    Public Sub ObjectPropertyLoad()
        RaiseEvent OnObjectPropertyLoad(Me, EventArgs.Empty)
    End Sub

    Public Sub PropertyChanged(Name As String)
        RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
    End Sub

    Public Overridable Sub Rebind(Design As cIDesign, Options As cOptions)
    End Sub
End Class
