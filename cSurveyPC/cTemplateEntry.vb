Imports System.IO

Friend Class cTemplateEntry
    Private oFile As FileInfo
    Private sName As String
    Private bDefault As Boolean

    Public ReadOnly Property [Default] As Boolean
        Get
            Return bDefault
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return sName
        End Get
    End Property

    Public ReadOnly Property File As FileInfo
        Get
            Return oFile
        End Get
    End Property

    Public Sub New(File As FileInfo)
        oFile = File
        sName = IO.Path.GetFileNameWithoutExtension(File.Name)
        If sName.Contains(".default") Then
            bDefault = True
            sName = sName.Replace(".default", "")
        End If
    End Sub
End Class