Imports System.IO

Public Class cModel3DHelper

    Public Shared Function GetMtlFilenames(Filename As String) As List(Of String)
        Dim oResults As List(Of String) = New List(Of String)
        Call oResults.Add(Filename)
        Dim sPath As String = IO.Path.GetDirectoryName(Filename)
        Using oFR As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Filename)
            Do Until oFR.EndOfStream
                Dim sLine As String = oFR.ReadLine.Trim
                If sLine.StartsWith("map_Kd ") Then
                    Dim sTempFilename As String = sLine.Substring(7)
                    If Not IO.Path.IsPathRooted(sTempFilename) Then
                        sTempFilename = IO.Path.Combine(sPath, sTempFilename)
                    End If
                    Call oResults.Add(sTempFilename)
                End If
            Loop
        End Using
        Return oResults
    End Function

    Public Shared Function GetObjFilenames(Filename As String) As List(Of String)
        Dim oResults As List(Of String) = New List(Of String)
        Call oResults.Add(Filename)
        Dim sPath As String = IO.Path.GetDirectoryName(Filename)
        Using oFR As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Filename)
            Do Until oFR.EndOfStream
                Dim sLine As String = oFR.ReadLine.Trim
                If sLine.StartsWith("mtllib ") Then
                    Dim sTempFilename As String = sLine.Substring(7)
                    If Not IO.Path.IsPathRooted(sTempFilename) Then
                        sTempFilename = IO.Path.Combine(sPath, sTempFilename)
                    End If
                    oResults.AddRange(GetMtlFilenames(sTempFilename))
                End If
            Loop
        End Using
        Return oResults
    End Function

End Class
