Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cGPSOptions
        Public Enum GPSDataFormatEnum
            GoogleEarthImageOverlay = 0
        End Enum

        Private bExportData As Boolean
        Private iDataFormat As GPSDataFormatEnum

        Friend Function Clone() As cGPSOptions
            Return New cGPSOptions(Me)
        End Function

        Friend Sub CopyFrom(ByVal GPSOptions As cGPSOptions)
            bExportData = GPSOptions.ExportData
            iDataFormat = GPSOptions.DataFormat
        End Sub

        Friend Sub New(ByVal GPSOptions As cGPSOptions)
            Call CopyFrom(GPSOptions)
        End Sub

        Public Property ExportData As Boolean
            Get
                Return bExportData
            End Get
            Set(ByVal value As Boolean)
                bExportData = value
            End Set
        End Property

        Public Property DataFormat As GPSDataFormatEnum
            Get
                Return iDataFormat
            End Get
            Set(ByVal value As GPSDataFormatEnum)
                iDataFormat = value
            End Set
        End Property

        Friend Sub New()
            bExportData = False
            iDataFormat = GPSDataFormatEnum.GoogleEarthImageOverlay
        End Sub

        Friend Sub New(ByVal GPSOptions As XmlElement)
            bExportData = GPSOptions.GetAttribute("exportdata")
            iDataFormat = GPSOptions.GetAttribute("dataformat")
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            Dim oXMLGPSOptions As XmlElement = Document.CreateElement(Name)
            Call oXMLGPSOptions.SetAttribute("exportdata", IIf(bExportData, "1", "0"))
            Call oXMLGPSOptions.SetAttribute("dataformat", iDataFormat)
            Call Parent.AppendChild(oXMLGPSOptions)
            Return oXMLGPSOptions
        End Function
    End Class
End Namespace
