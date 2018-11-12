Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters

Namespace cSurvey.Surface
    Public Class cElevations
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As List(Of cElevation)
        Private oDefault As cElevation

        Friend Event OnElevationsChange(ByVal Sender As cElevations, Item As cElevation)

        Public Sub Clear()
            Call oItems.Clear()
            oDefault = Nothing
        End Sub

        Public Function Contains(Elevation As cElevation) As Boolean
            Return oItems.Contains(Elevation)
        End Function

        Friend Function Contains(ID As String) As Boolean
            Return oItems.Select(Function(elevation) elevation.ID = ID).Count
        End Function

        Friend Sub New(Survey As cSurvey, ByVal File As Storage.cFile, ByVal Elevations As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cElevation)
            Dim sDefault As String = modXML.GetAttributeValue(Elevations, "default", "")
            For Each oXMLElevation In Elevations.ChildNodes
                Dim oElevation As cElevation = New cElevation(Survey, File, oXMLElevation)
                AddHandler oElevation.OnChange, AddressOf oElevation_onchange
                AddHandler oElevation.OnDefaultSet, AddressOf oElevation_ondefaultset
                AddHandler oElevation.OnDefaultGet, AddressOf oElevation_ondefaultget
                Call oItems.Add(oElevation)
                If oElevation.ID = sDefault Then
                    oDefault = oElevation
                End If
            Next
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

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

        Private Sub oElevation_ondefaultset(Sender As cElevation, Args As cElevation.cDefaultArgs)
            If Args.ID = "" Then
                oDefault = Nothing
            Else
                oDefault = Sender
            End If
        End Sub

        Private Sub oElevation_ondefaultget(Sender As cElevation, Args As cElevation.cDefaultArgs)
            If Not oDefault Is Nothing Then
                Args.ID = oDefault.ID
            End If
        End Sub

        Private Sub oElevation_onchange(Sender As cElevation)
            RaiseEvent OnElevationsChange(Me, Sender)
        End Sub

        Public Function Add(DataType As cElevation.ElevationDataTypeEnum, Filename As String, Options As cElevation.cElevationImportOptions) As cElevation
            Dim oElevation As cElevation = New cElevation(oSurvey)
            If oElevation.Import(DataType, Filename, Options) Then
                AddHandler oElevation.OnChange, AddressOf oElevation_onchange
                AddHandler oElevation.OnDefaultSet, AddressOf oElevation_ondefaultset
                AddHandler oElevation.OnDefaultGet, AddressOf oElevation_ondefaultget
                Call oItems.Add(oElevation)
                Return oElevation
            Else
                Return Nothing
            End If
        End Function

        Friend Function Add() As cElevation
            Dim oElevation As cElevation = New cElevation(oSurvey)
            AddHandler oElevation.OnChange, AddressOf oElevation_onchange
            AddHandler oElevation.OnDefaultSet, AddressOf oElevation_ondefaultset
            AddHandler oElevation.OnDefaultGet, AddressOf oElevation_ondefaultget
            Call oItems.Add(oElevation)
            Return oElevation
        End Function

        Public Sub Remove(Item As cElevation)
            Call oItems.Remove(Item)
            If Not oDefault Is Nothing Then If oDefault.ID = Item.ID Then oDefault = Nothing
            If oSurvey.Properties.SurfaceProfileElevation Is Item Then
                oSurvey.Properties.SurfaceProfileElevation = Nothing
            End If
            Call Item.Clear()
        End Sub

        Public Sub Remove(Index As Integer)
            Try
                Call Remove(oItems(Index))
            Catch ex As Exception
            End Try
        End Sub

        Public Property [Default] As cElevation
            Get
                Return oDefault
            End Get
            Set(value As cElevation)
                If oItems.Contains(value) Or value Is Nothing Then
                    oDefault = value
                End If
            End Set
        End Property

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cElevation)
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlElevations As XmlElement = Document.CreateElement("elevations")
            If Not oDefault Is Nothing Then
                Call oXmlElevations.SetAttribute("default", oDefault.ID)
            End If
            For Each oElevation As cElevation In oItems
                If Not oElevation.IsEmpty Then
                    Call oElevation.SaveTo(File, Document, oXmlElevations)
                End If
            Next
            Call Parent.AppendChild(oXmlElevations)
            Return oXmlElevations
        End Function

        Friend Sub CopyFrom(Elevations As cElevations)
            Call oItems.Clear()
            For Each oItem In Elevations.oItems
                Dim oElevation As cElevation = New cElevation(oSurvey)
                Call oElevation.CopyFrom(oItem)
                AddHandler oElevation.OnChange, AddressOf oElevation_onchange
                AddHandler oElevation.OnDefaultSet, AddressOf oElevation_ondefaultset
                AddHandler oElevation.OnDefaultGet, AddressOf oElevation_ondefaultget
                Call oItems.Add(oElevation)
            Next
            oDefault = Elevations.oDefault
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace