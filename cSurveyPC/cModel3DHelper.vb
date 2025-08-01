﻿Imports System.IO

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

    Public Shared Sub ObjMaterialPathToRelative(ObjFilename As String, Path As String)
        Dim sTempObjFilename As String = IO.Path.Combine(IO.Path.GetDirectoryName(ObjFilename), Guid.NewGuid.ToString) & IO.Path.GetExtension(ObjFilename)
        Using oFR As StreamReader = My.Computer.FileSystem.OpenTextFileReader(ObjFilename, Text.Encoding.UTF8)
            Using oFW As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sTempObjFilename, False, Text.Encoding.UTF8)
                Do Until oFR.EndOfStream
                    Dim sLine As String = oFR.ReadLine.Trim
                    'mtllib ./C:\Users\devel\AppData\Local\Temp\4699efe5-9753-495a-a533-83f5de4b8b1e.mtl
                    If sLine.StartsWith("mtllib ") Then
                        Dim sTempFilename As String = sLine.Substring(7)
                        If sTempFilename.StartsWith("./") Then sTempFilename = sTempFilename.Replace("./", "")
                        If IO.Path.IsPathRooted(sTempFilename) Then
                            sTempFilename = modMain.MakeRelative(sTempFilename, Path)
                        End If
                        oFW.WriteLine("mtllib " & sTempFilename)
                    Else
                        oFW.WriteLine(sLine)
                    End If
                Loop
                Call oFW.Flush()
            End Using
        End Using
        IO.File.Delete(ObjFilename)
        IO.File.Move(sTempObjFilename, ObjFilename)
    End Sub

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
