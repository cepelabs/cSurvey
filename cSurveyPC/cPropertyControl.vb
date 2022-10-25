Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.XtraPrinting.Native

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

Public Class CommitUndoSnapshotEventArgs
    Inherits EventArgs

    Private bSkipIfNotBeginned As Boolean

    Public ReadOnly Property SkipIfNotBeginned As Boolean
        Get
            Return bSkipIfNotBeginned
        End Get
    End Property

    Public Sub New(Optional SkipIfNotBeginned As Boolean = False)
        bSkipIfNotBeginned = SkipIfNotBeginned
    End Sub
End Class

Public Class BeginUndoSnapshotEventArgs
    Inherits EventArgs

    Private sDescription As String

    Public ReadOnly Property Description As String
        Get
            Return sDescription
        End Get
    End Property

    Public Sub New(Description As String)
        sDescription = Description
    End Sub
End Class

Public Class CreateUndoSnapshotEventArgs
    Inherits BeginUndoSnapshotEventArgs

    Private oBackupDelegate As cUndoItemBackupValueDelegate
    Private oRestoreDelegate As cUndoItemRestoreValueDelegate

    Private sPropertyName As String

    Public Function SnapshotType() As Integer
        If sPropertyName Is Nothing Then
            Return 1
        Else
            Return 0
        End If
    End Function

    Public Sub New(Description As String, BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate)
        MyBase.New(Description)
        oBackupDelegate = BackupDelegate
        oRestoreDelegate = RestoreDelegate
    End Sub

    Public ReadOnly Property RestoreDelegate As cUndoItemRestoreValueDelegate
        Get
            Return oRestoreDelegate
        End Get
    End Property

    Public ReadOnly Property BackupDelegate As cUndoItemBackupValueDelegate
        Get
            Return oBackupDelegate
        End Get
    End Property

    Public Sub New(Description As String, PropertyName As String)
        MyBase.New(Description)
        sPropertyName = PropertyName
    End Sub

    Public ReadOnly Property PropertyName As String
        Get
            Return sPropertyName
        End Get
    End Property
End Class

Public Interface cUIControlPropertyInteractions
    Inherits cIUIInteractions
    Event OnGetFlags(Sender As Object, e As FlagEventArgs)
    Event OnSetFlags(Sender As Object, e As FlagEventArgs)

    Event OnDrawInvalidate(Sender As Object, e As EventArgs)
    Event OnSurveyInvalidate(Sender As Object, e As EventArgs)
    Event OnObjectPropertyLoad(Sender As Object, e As EventArgs)
    Event OnDoCommand(Sender As Object, e As DoCommandEventArgs)

    Event OnTakeUndoSnapshot(Sender As Object, e As EventArgs)
    Event OnCreateUndoSnapshot(Sender As Object, e As CreateUndoSnapshotEventArgs)
    Event OnBeginUndoSnapshot(Sender As Object, e As BeginUndoSnapshotEventArgs)
    Event OnCommitUndoSnapshot(Sender As Object, e As CommitUndoSnapshotEventArgs)
    Event OnCancelUndoSnapshot(Sender As Object, e As EventArgs)
End Interface