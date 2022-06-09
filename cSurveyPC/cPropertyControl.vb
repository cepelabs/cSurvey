Imports cSurveyPC.cSurvey.Design
Public Class KeyValueChangeEventArgs(Of N, V)
    Private oName As N
    Private oValue As V

    Public ReadOnly Property [Name] As N
        Get
            Return oName
        End Get
    End Property

    Public Property [Value] As V
        Get
            Return oValue
        End Get
        Set(value As V)
            oValue = value
        End Set
    End Property
    Public Sub New([Name] As N)
        oName = Name
    End Sub

    Public Sub New(Name As N, Value As V)
        oName = Name
        oValue = Value
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
        sCommand = Command
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
