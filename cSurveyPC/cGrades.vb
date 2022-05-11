Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey
    Friend Class cGradeBaseCollection
        Inherits KeyedCollection(Of String, cGrade)

        Protected Overrides Function GetKeyForItem(ByVal item As cGrade) As String
            Return item.ID
        End Function
    End Class

    Public Class cGrades
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As cGradeBaseCollection

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New cGradeBaseCollection
        End Sub

        Friend Function Add(ID As String, Description As String) As cGrade
            Dim oGrade As cGrade = New cGrade(oSurvey, ID, Description)
            Call oItems.Add(oGrade)
            Return oGrade
        End Function

        Friend Function Add(Description As String) As cGrade
            Dim oGrade As cGrade = New cGrade(oSurvey, Description)
            Call oItems.Add(oGrade)
            Return oGrade
        End Function

        Friend Function Add() As cGrade
            Dim oGrade As cGrade = New cGrade(oSurvey, "")
            Call oItems.Add(oGrade)
            Return oGrade
        End Function

        Default Public ReadOnly Property Item(Index As Integer) As cGrade
            Get
                If Index >= 0 And Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property
        Default Public ReadOnly Property Item(ByVal ID As String) As cGrade
            Get
                If oItems.Contains(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function Contains(ByVal Grade As cGrade) As Boolean
            Return oItems.Contains(Grade)
        End Function

        Public Function Contains(ID As String) As Boolean
            Return oItems.Contains(ID)
        End Function

        Public Sub Remove(ByVal Grade As cGrade)
            If oItems.Contains(Grade) Then
                Call oItems.Remove(Grade)
                If oSurvey.Properties.Grade = Grade.ID Then
                    oSurvey.Properties.Grade = ""
                End If
                For Each oSession As cSession In Grade.GetUsingSessions
                    oSession.Grade = ""
                Next
            End If
        End Sub

        Public Sub Remove(Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Call oItems.RemoveAt(Index)
            End If
        End Sub

        Public Sub Remove(ID As String)
            If oItems.Contains(ID) Then
                Dim oItem As cGrade = oItems(ID)
                Call oItems.Remove(ID)
                If oSurvey.Properties.Grade = ID Then
                    oSurvey.Properties.Grade = ""
                End If
                For Each oSession As cSession In oItem.GetUsingSessions
                    oSession.Grade = ""
                Next
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
            oSurvey.Properties.Grade = ""
            For Each oSession As cSession In oSurvey.Properties.Sessions
                oSession.Grade = ""
            Next
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlGrades As XmlElement = document.CreateElement("grades")
            For Each oGrade As cGrade In oItems
                Call oGrade.SaveTo(File, document, oXmlGrades)
            Next
            Call Parent.AppendChild(oXmlGrades)
            Return oXmlGrades
        End Function

        Public Function IndexOf(Grade As cGrade) As Integer
            Return oItems.IndexOf(Grade)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Grades As XmlElement)
            oSurvey = Survey
            oItems = New cGradeBaseCollection
            If Not Grades Is Nothing Then
                For Each oXmlGrade As XmlElement In Grades.ChildNodes
                    Dim oGrade As cGrade = New cGrade(oSurvey, oXmlGrade)
                    Call oItems.Add(oGrade)
                Next
            End If
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace