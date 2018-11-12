Imports System.ComponentModel

Namespace cSurvey
    Public Class cSegmentImages
        Implements IEnumerable

        Private oItems As BindingList(Of cSegmentImage)

        Public Function Add(Filename As String, [Date] As Date, Description As String, Note As String, Author As String) As cSegmentImage
            Dim oItem As cSegmentImage = New cSegmentImage(New Bitmap(Filename), [Date], Description, Note, Author)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Function Add(Image As Image, [Date] As Date, Description As String, Note As String, Author As String) As cSegmentImage
            Dim oItem As cSegmentImage = New cSegmentImage(Image, [Date], Description, Note, Author)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Sub Remove(Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Call oItems.RemoveAt(Index)
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Sub New()
            oItems = New BindingList(Of cSegmentImage)
        End Sub
    End Class
End Namespace
