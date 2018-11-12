Imports cSurveyPC.cSurvey.Design

'Public Interface cIPropertyControl(Of T)
'    Sub Rebind(Item As T)

'    Event OnMapInvalidate(Sender As Object, e As EventArgs)
'    Event OnObjectPropertyLoad(Sender As Object, e As EventArgs)
'    Event OnGetFlags(Sender As Object, e As FlagEventArgs)
'    Event OnSetFlags(Sender As Object, e As FlagEventArgs)
'End Interface

Public Class PropertyChangeEventArgs
    Inherits EventArgs

    Private sName As String

    Public ReadOnly Property Name As String
        Get
            Return sName
        End Get
    End Property

    Public Sub New(Name As String)
        sName = Name
    End Sub
End Class

Public Class DoCommandEventArgs
    Inherits EventArgs

    Private sCommand As String
    Private oArgs As Object()

    Public ReadOnly Property Command As String
        Get
            Return sCommand
        End Get
    End Property

    Public ReadOnly Property Args As Object()
        Get
            Return oArgs
        End Get
    End Property

    Public Sub New(Command As String, ParamArray Args As Object())
        scommand = Command
        oArgs = Args
    End Sub
End Class

Public Class FlagEventArgs
    Inherits EventArgs

    Public Enum Flags
        None = 0
        DisabledObjectPropertyEvent = 1
    End Enum

    Private iFlag As Flags
    Private bValue As Boolean

    Public Property Value As Boolean
        Get
            Return bValue
        End Get
        Set(value As Boolean)
            bValue = value
        End Set
    End Property

    Public ReadOnly Property Flag As Flags
        Get
            Return iFlag
        End Get
    End Property

    Public Sub New(Flag As Flags)
        iFlag = Flag
    End Sub

    Public Sub New(Flag As Flags, Value As Boolean)
        iFlag = Flag
        bValue = Value
    End Sub
End Class
