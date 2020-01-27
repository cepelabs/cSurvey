Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters

Namespace cSurvey.Surface
    Public Class cOrthoPhotos
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As List(Of cOrthoPhoto)
        Private oDefault As cOrthoPhoto

        Friend Event OnOrthoPhotosChange(ByVal Sender As cOrthoPhotos, Item As cOrthoPhoto)

        Public Sub Clear()
            Call oItems.Clear()
            oDefault = Nothing
        End Sub

        Public Function Contains(OrthoPhoto As cOrthoPhoto) As Boolean
            Return oItems.Contains(OrthoPhoto)
        End Function

        Friend Function Contains(ID As String) As Boolean
            Return oItems.Select(Function(elevation) elevation.ID = ID).Count
        End Function

        Friend Sub New(Survey As cSurvey, ByVal File As Storage.cFile, ByVal OrthoPhotos As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cOrthoPhoto)
            Dim sDefault As String = ""
            sDefault = modXML.GetAttributeValue(OrthoPhotos, "default", "")
            For Each oXMLOrthoPhoto In OrthoPhotos.ChildNodes
                Dim oOrthophoto As cOrthoPhoto = New cOrthoPhoto(Survey, File, oXMLOrthoPhoto)
                If Not oOrthophoto.Photo Is Nothing Then
                    AddHandler oOrthophoto.OnChange, AddressOf oOrthophoto_onchange
                    AddHandler oOrthophoto.OnDefaultSet, AddressOf oOrthophoto_ondefaultset
                    AddHandler oOrthophoto.OnDefaultGet, AddressOf oOrthophoto_ondefaultGet
                    Call oItems.Add(oOrthophoto)
                    If oOrthophoto.ID = sDefault Then
                        oDefault = oOrthophoto
                    End If
                End If
            Next
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Private Sub oOrthophoto_ondefaultset(Sender As cOrthoPhoto, Args As cOrthoPhoto.cDefaultArgs)
            If Args.ID = "" Then
                oDefault = Nothing
            Else
                oDefault = Sender
            End If
        End Sub

        Private Sub oOrthophoto_ondefaultGet(Sender As cOrthoPhoto, Args As cOrthoPhoto.cDefaultArgs)
            If Not oDefault Is Nothing Then
                Args.ID = oDefault.ID
            End If
        End Sub

        Private Sub oOrthophoto_onchange(Sender As cOrthoPhoto)
            RaiseEvent OnOrthoPhotosChange(Me, Sender)
        End Sub

        Public Function Add(DataType As cOrthoPhoto.OrthoPhotoDataTypeEnum, Filename As String, Options As cOrthoPhoto.cOrthoPhotoImportOptions) As cOrthoPhoto
            Dim oOrthophoto As cOrthoPhoto = New cOrthoPhoto(oSurvey)
            If oOrthophoto.Import(DataType, Filename, Options) Then
                AddHandler oOrthophoto.OnChange, AddressOf oOrthophoto_onchange
                AddHandler oOrthophoto.OnDefaultSet, AddressOf oOrthophoto_ondefaultset
                AddHandler oOrthophoto.OnDefaultGet, AddressOf oOrthophoto_ondefaultGet
                Call oItems.Add(oOrthophoto)
                Return oOrthophoto
            Else
                Return Nothing
            End If
        End Function

        Friend Function Add(Image As Image, Name As String, Coordinate As cCoordinate, XSize As Single, YSize As Single) As cOrthoPhoto
            Dim oOrthophoto As cOrthoPhoto = New cOrthoPhoto(oSurvey, Name, Coordinate, Image, XSize, YSize)
            AddHandler oOrthophoto.OnChange, AddressOf oOrthophoto_onchange
            AddHandler oOrthophoto.OnDefaultSet, AddressOf oOrthophoto_ondefaultset
            AddHandler oOrthophoto.OnDefaultGet, AddressOf oOrthophoto_ondefaultGet
            Call oItems.Add(oOrthophoto)
            Return oOrthophoto
        End Function

        Friend Function Add() As cOrthoPhoto
            Dim oOrthophoto As cOrthoPhoto = New cOrthoPhoto(oSurvey)
            AddHandler oOrthophoto.OnChange, AddressOf oOrthophoto_onchange
            AddHandler oOrthophoto.OnDefaultSet, AddressOf oOrthophoto_ondefaultset
            AddHandler oOrthophoto.OnDefaultGet, AddressOf oOrthophoto_ondefaultGet
            Call oItems.Add(oOrthophoto)
            Return oOrthophoto
        End Function

        Public Sub Remove(Item As cOrthoPhoto)
            Call oItems.Remove(Item)
            If Not oDefault Is Nothing Then If Item.ID = oDefault.ID Then oDefault = Nothing
        End Sub

        Public Sub Remove(Index As Integer)
            Try
                Dim oItem As cOrthoPhoto = oItems(Index)
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

        Public Property [Default] As cOrthoPhoto
            Get
                Return oDefault
            End Get
            Set(value As cOrthoPhoto)
                If oItems.Contains(value) Or value Is Nothing Then
                    oDefault = value
                End If
            End Set
        End Property

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cOrthoPhoto)
        End Sub

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlOrthoPhotos As XmlElement = Document.CreateElement("orthophotos")
            If Not oDefault Is Nothing Then
                Call oXmlOrthoPhotos.SetAttribute("default", oDefault.ID)
            End If
            For Each oOrthophoto As cOrthoPhoto In oItems
                Call oOrthophoto.SaveTo(File, Document, oXmlOrthoPhotos)
            Next
            Call Parent.AppendChild(oXmlOrthoPhotos)
            Return oXmlOrthoPhotos
        End Function

        Friend Sub CopyFrom(OrthoPhotos As cOrthoPhotos)
            Call oItems.Clear()
            For Each oItem In OrthoPhotos.oItems
                Dim oOrthophoto As cOrthoPhoto = New cOrthoPhoto(oSurvey)
                Call oOrthophoto.CopyFrom(oItem)
                AddHandler oOrthophoto.OnChange, AddressOf oOrthophoto_onchange
                AddHandler oOrthophoto.OnDefaultSet, AddressOf oOrthophoto_ondefaultset
                AddHandler oOrthophoto.OnDefaultGet, AddressOf oOrthophoto_ondefaultGet
                Call oItems.Add(oOrthophoto)
            Next
            oDefault = OrthoPhotos.oDefault
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace