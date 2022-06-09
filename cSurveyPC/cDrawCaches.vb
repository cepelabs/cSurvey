Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Drawings
    Public Class cDrawCaches
        Implements IEnumerable

        Private oItems As Dictionary(Of cOptionsCenterline, cDrawCache)

        Friend Event OnInvalidate(Sender As cDrawCaches)

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Friend Sub New()
            oItems = New Dictionary(Of cOptionsCenterline, cDrawCache)
        End Sub

        Public Function IsEmpty() As Boolean
            Return oItems.Count = 0
        End Function

        Public Function Contains(Options As cOptionsCenterline) As Boolean
            Return oItems.ContainsKey(Options)
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetBounds(Options As cOptionsCenterline) As RectangleF
            If oItems.ContainsKey(Options) Then
                Return oItems(Options).GetBounds
            Else
                Return GetBounds
            End If
        End Function

        Public Function GetBounds() As RectangleF
            If oItems.Count = 0 Then
                Return New RectangleF
            Else
                Return oItems.Values.First.GetBounds
            End If
        End Function

        Default Public ReadOnly Property Item(Options As cOptionsCenterline) As cDrawCache
            Get
                If oItems.ContainsKey(Options) Then
                    Return oItems(Options)
                Else
                    Dim oCache As cDrawCache = New cDrawCache
                    Call oItems.Add(Options, oCache)
                    Return oCache
                End If
            End Get
        End Property

        Public Sub Invalidate(Optional Options As cOptionsCenterline = Nothing)
            If Options Is Nothing Then
                Call oItems.Clear()
            Else
                If oItems.ContainsKey(Options) Then
                    Call oItems.Remove(Options)
                End If
            End If
            RaiseEvent OnInvalidate(Me)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class
End Namespace
