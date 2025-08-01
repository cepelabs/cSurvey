﻿Imports System.Xml

Namespace cSurvey
    Public Class cConnectionDef
        Private sStation As String
        Private sFromStation As String

        Public ReadOnly Property Station As String
            Get
                Return sStation
            End Get
        End Property

        Public Shared Operator =(ByVal left As cConnectionDef, ByVal right As cConnectionDef) As Boolean
            If IsNothing(left) AndAlso Not IsNothing(right) Then
                Return False
            ElseIf Not IsNothing(left) AndAlso IsNothing(right) Then
                Return False
            ElseIf IsNothing(left) AndAlso IsNothing(right) Then
                Return True
            Else
                Return (left.Station = right.Station) AndAlso (left.FromStation = right.FromStation)
            End If
        End Operator

        Public Shared Operator <>(ByVal left As cConnectionDef, ByVal right As cConnectionDef) As Boolean
            If IsNothing(left) AndAlso Not IsNothing(right) Then
                Return True
            ElseIf Not IsNothing(left) AndAlso IsNothing(right) Then
                Return True
            ElseIf IsNothing(left) AndAlso IsNothing(right) Then
                Return False
            Else
                Return (left.Station <> right.Station) OrElse (left.FromStation <> right.FromStation)
            End If
        End Operator

        Public ReadOnly Property FromStation As String
            Get
                Return sFromStation
            End Get
        End Property

        Public Shared Function Parse(Text As String) As (Station As String, FromStation As String)
            If String.IsNullOrEmpty(Text) Then
                Return ("", "")
            Else
                Dim idxStart As Integer = Text.IndexOf("(<")
                Dim idxEnd As Integer = Text.LastIndexOf(")")
                If idxStart = -1 OrElse idxEnd = -1 OrElse idxEnd <= idxStart + 1 Then
                    'invalid format
                    Return ("", "")
                End If
                Dim sStation As String = Text.Substring(0, idxStart)
                Dim sFromStation As String = Text.Substring(idxStart + 2, idxEnd - idxStart - 2)
                Return (sStation.Trim(), sFromStation.Trim())
            End If
        End Function

        Public Overrides Function ToString() As String
            Return sStation & "(<" & sFromStation & ")"
        End Function

        Public Sub New(Text As String)
            Dim o = Parse(Text)
            sStation = o.Station
            sFromStation = o.FromStation
        End Sub

        Public Sub New(Station As String, FromStation As String)
            sStation = Station
            sFromStation = FromStation
        End Sub

        Friend Sub New(ByVal ConnectionDef As XmlElement)
            sStation = ConnectionDef.GetAttribute("s")
            sFromStation = ConnectionDef.GetAttribute("sf")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlConnectionDef As XmlElement = Document.CreateElement(Name)
            Call oXmlConnectionDef.SetAttribute("s", sStation)
            Call oXmlConnectionDef.SetAttribute("sf", sFromStation)
            Call Parent.AppendChild(oXmlConnectionDef)
            Return oXmlConnectionDef
        End Function
    End Class
End Namespace
