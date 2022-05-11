Imports System.ComponentModel
Imports cSurveyPC
Imports cSurveyPC.cSurvey.Design

Public Class cDesignPropertyControl
    Private oDesign As cDesign
    Private oOptions As cOptions

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property DisabledObjectProperty() As Boolean
        Get
            If oDesign Is Nothing Then
                Return True
            Else
                Dim oArgs As FlagEventArgs = New FlagEventArgs(FlagEventArgs.Flags.DisabledObjectPropertyEvent)
                RaiseEvent OnGetFlags(Me, oArgs)
                Return oArgs.Value
            End If
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

    Public Sub DrawInvalidate(EventArgs As EventArgs)
        RaiseEvent OnDrawInvalidate(Me, EventArgs)
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

    Public Overridable ReadOnly Property Options As cOptions
        Get
            Return oOptions
        End Get
    End Property

    Public Overridable ReadOnly Property Design As cIDesign
        Get
            Return oDesign
        End Get
    End Property

    Public Overridable Sub Rebind(Design As cIDesign, Options As cOptions)
        oDesign = Design
        oOptions = Options
    End Sub
End Class
