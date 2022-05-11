Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters

Namespace cSurvey.Surface
    Public Class cWMSs
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As List(Of cWMS)
        Private oDefault As cWMS

        Friend Event OnWMSsChange(ByVal Sender As cWMSs, Item As cWMS)

        Public Sub Clear()
            Call oItems.Clear()
            oDefault = Nothing
        End Sub

        Public Function Contains(WMS As cWMS) As Boolean
            Return oItems.Contains(WMS)
        End Function

        Friend Function Contains(ID As String) As Boolean
            Return oItems.Where(Function(wms) wms.ID = ID).Count > 0
        End Function

        Friend Sub New(Survey As cSurvey, ByVal File As cFile, ByVal WMSs As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cWMS)
            Dim sDefault As String = ""
            sDefault = modXML.GetAttributeValue(WMSs, "default", "")
            For Each oXMLWMS In WMSs.ChildNodes
                Dim oWMS As cWMS = New cWMS(Survey, File, oXMLWMS)
                If Not oWMS.URL = "" Then
                    AddHandler oWMS.OnChange, AddressOf oWMS_onchange
                    AddHandler oWMS.OnDefaultSet, AddressOf oWMS_ondefaultset
                    AddHandler oWMS.OnDefaultGet, AddressOf oWMS_ondefaultGet
                    Call oItems.Add(oWMS)
                    If oWMS.ID = sDefault Then
                        oDefault = oWMS
                    End If
                End If
            Next
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Private Sub oWMS_ondefaultset(Sender As cWMS, Args As cWMS.cDefaultArgs)
            If Args.ID = "" Then
                oDefault = Nothing
            Else
                oDefault = Sender
            End If
        End Sub

        Private Sub oWMS_ondefaultGet(Sender As cWMS, Args As cWMS.cDefaultArgs)
            If Not oDefault Is Nothing Then
                Args.ID = oDefault.ID
            End If
        End Sub

        Private Sub oWMS_onchange(Sender As cWMS)
            RaiseEvent OnWMSsChange(Me, Sender)
        End Sub

        Public Function Add(DataType As cWMS.WMSDataTypeEnum, Name As String, URL As String, Layer As String, SRSOverride As String, Options As cWMS.cWMSImportOptions) As cWMS
            Dim oWMS As cWMS = New cWMS(oSurvey)
            If oWMS.Import(DataType, Name, URL, Layer, SRSOverride, Options) Then
                AddHandler oWMS.OnChange, AddressOf oWMS_onchange
                AddHandler oWMS.OnDefaultSet, AddressOf oWMS_ondefaultset
                AddHandler oWMS.OnDefaultGet, AddressOf oWMS_ondefaultGet
                Call oItems.Add(oWMS)
                Return oWMS
            Else
                Return Nothing
            End If
        End Function

        Friend Function Add() As cWMS
            Dim oWMS As cWMS = New cWMS(oSurvey)
            AddHandler oWMS.OnChange, AddressOf oWMS_onchange
            AddHandler oWMS.OnDefaultSet, AddressOf oWMS_ondefaultset
            AddHandler oWMS.OnDefaultGet, AddressOf oWMS_ondefaultGet
            Call oItems.Add(oWMS)
            Return oWMS
        End Function

        Public Sub Remove(Item As cWMS)
            Call oItems.Remove(Item)
            If Not oDefault Is Nothing Then If Item.ID = oDefault.ID Then oDefault = Nothing
        End Sub

        Public Sub Remove(Index As Integer)
            Try
                Dim oItem As cWMS = oItems(Index)
                Call oItems.Remove(oItem)
            Catch ex As Exception
            End Try
        End Sub

        Public Function IsDefaultEmpty() As Boolean
            If Not oDefault Is Nothing Then
                Return oDefault.IsEmpty
            End If
        End Function

        'Public Function ShowIn3D() As Boolean
        '    If Not oDefault Is Nothing Then
        '        Return oDefault.ShowIn3D
        '    End If
        'End Function

        Public Property [Default] As cWMS
            Get
                Return oDefault
            End Get
            Set(value As cWMS)
                If oItems.Contains(value) Or value Is Nothing Then
                    oDefault = value
                End If
            End Set
        End Property

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cWMS)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlWMSs As XmlElement = Document.CreateElement("wmss")
            If Not oDefault Is Nothing Then
                Call oXmlWMSs.SetAttribute("default", oDefault.ID)
            End If
            For Each oWMS As cWMS In oItems
                Call oWMS.SaveTo(File, Document, oXmlWMSs)
            Next
            Call Parent.AppendChild(oXmlWMSs)
            Return oXmlWMSs
        End Function

        Friend Sub CopyFrom(WMSs As cWMSs)
            Call oItems.Clear()
            For Each oItem In WMSs.oItems
                Dim oWMS As cWMS = New cWMS(oSurvey)
                Call oWMS.CopyFrom(oItem)
                AddHandler oWMS.OnChange, AddressOf oWMS_onchange
                AddHandler oWMS.OnDefaultSet, AddressOf oWMS_ondefaultset
                AddHandler oWMS.OnDefaultGet, AddressOf oWMS_ondefaultGet
                Call oItems.Add(oWMS)
            Next
            oDefault = WMSs.oDefault
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
