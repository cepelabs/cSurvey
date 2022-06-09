Imports System.ComponentModel
Imports System.IO

Friend Class cTemplates
    Inherits BindingList(Of cTemplateEntry)

    Private sTemplatesPath As String

    Public ReadOnly Property TemplatePath As String
        Get
            Return sTemplatesPath
        End Get
    End Property

    Public Function GetDefaultTemplate(Template As cTemplateEntry) As cTemplateEntry
        If Template Is Nothing Then
            Return Me.GetDefaultTemplate
        Else
            Return Template
        End If
    End Function

    Public Function GetDefaultTemplate() As cTemplateEntry
        Return MyBase.FirstOrDefault(Function(oItem) oItem.Default)
    End Function

    Private Function pCheckFolder() As Boolean
        Try
            If My.Computer.FileSystem.DirectoryExists(sTemplatesPath) Then
                Return True
            Else
                Call My.Computer.FileSystem.CreateDirectory(sTemplatesPath)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Friend Sub SetDefault(Template As cTemplateEntry, Value As Boolean)
        If Value Then
            Dim oTemplate As cTemplateEntry = MyBase.FirstOrDefault(Function(oitem) oitem.Default AndAlso Not oitem Is Template)
            If Not oTemplate Is Nothing Then Call SetDefault(oTemplate, False)

            Dim sOldFilename As String = Template.File.FullName
            Dim sNewFilename As String = IO.Path.GetFileNameWithoutExtension(Template.File.Name) & ".default" & IO.Path.GetExtension(Template.File.Name)
            Dim sNewFullFilename As String = IO.Path.Combine(Template.File.DirectoryName, sNewFilename)
            My.Computer.FileSystem.RenameFile(sOldFilename, sNewFilename)

            Call Template.Rebind(sNewFullFilename)

            'Dim oNewTemplate As cTemplateEntry = New cTemplateEntry(Me, New IO.FileInfo(sNewFullFilename))
            'Dim iIndex As Integer = MyBase.IndexOf(Template)
            'Call MyBase.Remove(Template)
            'Call MyBase.Insert(iIndex, oNewTemplate)
        Else
            Dim sOldFilename As String = Template.File.FullName
            Dim sNewFilename As String = IO.Path.GetFileNameWithoutExtension(Template.File.Name).Replace(".default", "") & IO.Path.GetExtension(Template.File.Name)
            Dim sNewFullFilename As String = IO.Path.Combine(Template.File.DirectoryName, sNewFilename)
            My.Computer.FileSystem.RenameFile(sOldFilename, sNewFilename)

            Call Template.Rebind(sNewFullFilename)

            'Dim oNewTemplate As cTemplateEntry = New cTemplateEntry(Me, New IO.FileInfo(sNewFullFilename))
            'Dim iIndex As Integer = MyBase.IndexOf(Template)
            'Call MyBase.Remove(Template)
            'Call MyBase.Insert(iIndex, oNewTemplate)
        End If
    End Sub

    Public Sub New(TemplatesPath As String)
        MyBase.New
        sTemplatesPath = TemplatesPath
        Call Refresh()
    End Sub

    Public Sub Refresh()
        If pCheckFolder() Then
            MyBase.Clear()
            Dim oIndex As HashSet(Of String) = New HashSet(Of String)(System.StringComparer.OrdinalIgnoreCase)
            For Each oFile As FileInfo In My.Computer.FileSystem.GetDirectoryInfo(sTemplatesPath).GetFiles("*.csz")
                If Not oIndex.Contains(oFile.Name) Then
                    Dim oTemplate As cTemplateEntry = New cTemplateEntry(Me, oFile)
                    Call MyBase.Add(oTemplate)
                    Call oIndex.Add(oFile.Name)
                End If
            Next
            For Each oFile As FileInfo In My.Computer.FileSystem.GetDirectoryInfo(sTemplatesPath).GetFiles("*.csx")
                If Not oIndex.Contains(oFile.Name) Then
                    Dim oTemplate As cTemplateEntry = New cTemplateEntry(Me, oFile)
                    Call MyBase.Add(oTemplate)
                    Call oIndex.Add(oFile.Name)
                End If
            Next
        End If
    End Sub
End Class

Friend Class cTemplateEntry
    Private oParent As cTemplates
    Private oFile As FileInfo
    Private sName As String
    Private bDefault As Boolean

    Public Property [Default] As Boolean
        Get
            Return bDefault
        End Get
        Set(value As Boolean)
            Call oParent.SetDefault(Me, value)
        End Set
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

    Friend Sub Rebind(Filename As String)
        Call Rebind(New FileInfo(Filename))
    End Sub

    Friend Sub Rebind(File As FileInfo)
        oFile = File
        sName = IO.Path.GetFileNameWithoutExtension(File.Name)
        If sName.Contains(".default") Then
            bDefault = True
            sName = sName.Replace(".default", "")
        Else
            bDefault = False
        End If
    End Sub

    Friend Sub New(Parent As cTemplates, Filename As String)
        oParent = Parent
        Call Rebind(Filename)
    End Sub

    Friend Sub New(Parent As cTemplates, File As FileInfo)
        oParent = Parent
        Call Rebind(File)
    End Sub
End Class