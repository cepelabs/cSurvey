Imports System.Xml
Imports cSurveyPC.cSurvey.Data

Namespace cSurvey.Data
    Public Class cDataTables
        Private oSegments As cDataFields
        Private oTrigpoints As cDataFields
        Private oDesignItems As cDataFields

        Public ReadOnly Property Segments As cDataFields
            Get
                Return oSegments
            End Get
        End Property

        Public ReadOnly Property Trigpoints As cDataFields
            Get
                Return oTrigpoints
            End Get
        End Property

        Public ReadOnly Property DesignItems As cDataFields
            Get
                Return oDesignItems
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSegments = New cDataFields(Survey, "segments")
            oTrigpoints = New cDataFields(Survey, "trigpoints")
            oDesignItems = New cDataFields(Survey, "designitems")
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            oSegments = New cDataFields(Survey, Item.Item("segments"))
            oTrigpoints = New cDataFields(Survey, Item.Item("trigpoints"))
            oDesignItems = New cDataFields(Survey, Item.Item("designitems"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLDataTables As XmlElement = Document.CreateElement("datatables")
            Call oSegments.SaveTo(File, Document, oXMLDataTables)
            Call oTrigpoints.SaveTo(File, Document, oXMLDataTables)
            Call oDesignItems.SaveTo(File, Document, oXMLDataTables)
            Call Parent.AppendChild(oXMLDataTables)
            Return oXMLDataTables
        End Function
    End Class
End Namespace
