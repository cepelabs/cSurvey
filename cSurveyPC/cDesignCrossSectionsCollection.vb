Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.ObjectModel

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Friend Class cDesignCrossSectionBaseCollection
        Inherits KeyedCollection(Of String, cDesignCrossSection)

        Protected Overrides Function GetKeyForItem(ByVal item As cDesignCrossSection) As String
            Return item.ID
        End Function
    End Class

    Public Class cDesignCrossSectionsCollection
        Implements IEnumerable
        Implements cIDesignCrossSectionsCollection

        Private oSurvey As cSurvey
        Private oItems As cDesignCrossSectionBaseCollection

        Friend Sub Append(ByVal CrossSection As cDesignCrossSection)
            Call oItems.Add(CrossSection)
        End Sub

        Public ReadOnly Property Count As Integer Implements cIDesignCrossSectionsCollection.Count
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cDesignCrossSection Implements cIDesignCrossSectionsCollection.Item
            Get
                Return oItems(Index)
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal ID As String) As cDesignCrossSection Implements cIDesignCrossSectionsCollection.Item
            Get
                Return oItems(ID)
            End Get
        End Property

        Public Function ToArray() As cDesignCrossSection() Implements cIDesignCrossSectionsCollection.ToArray
            Return oItems.ToArray
        End Function

        Public Function Contains(ByVal ID As String) As Boolean Implements cIDesignCrossSectionsCollection.Contains
            Try
                Dim oItem As cDesignCrossSection = oItems(ID)
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Function Contains(ByVal CrossSection As cDesignCrossSection) As Boolean Implements cIDesignCrossSectionsCollection.Contains
            Return oItems.Contains(CrossSection)
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cDesignCrossSectionBaseCollection
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function IndexOf(CrossSection As cDesignCrossSection) As Integer Implements cIDesignCrossSectionsCollection.IndexOf
            Return oItems.IndexOf(CrossSection)
        End Function

        Public Function IndexOf(ID As String) As Integer Implements cIDesignCrossSectionsCollection.IndexOf
            If oItems.Contains(ID) Then
                Dim oCrossSection As cDesignCrossSection = oItems(ID)
                Return oItems.IndexOf(oCrossSection)
            Else
                Return -1
            End If
        End Function
    End Class
End Namespace
