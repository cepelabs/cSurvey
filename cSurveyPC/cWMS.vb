Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Surface
    Public Class cWMSLayer
        Private sName As String
        Private oSRS As List(Of String)
        Private oImageFormats As List(Of String)

        Friend Sub New(Name As String)
            sName = Name
            oSRS = New List(Of String)
            oImageFormats = New List(Of String)
        End Sub

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Friend Sub AppendSRS(SRS As String)
            Dim sSRS As String = SRS.ToUpper
            If Not oSRS.Contains(sSRS) Then
                Call oSRS.Add(sSRS)
            End If
        End Sub

        Public Function IsSRSSupported(SRS As String) As Boolean
            Dim sSRS As String = SRS.ToUpper
            Return oSRS.Contains(sSRS)
        End Function

        Public ReadOnly Property SRS As List(Of String)
            Get
                Call oSRS.Sort()
                Return oSRS
            End Get
        End Property

        Public ReadOnly Property ImageFormats As List(Of String)
            Get
                Call oImageFormats.Sort()
                Return oImageFormats
            End Get
        End Property

        Friend Sub AppendSRS(SRSs As IEnumerable(Of String))
            For Each sSRS In SRSs
                Call AppendSRS(sSRS)
            Next
        End Sub

        Friend Sub AppendImageFormat(ImageFormats As IEnumerable(Of String))
            For Each sImageFormat In ImageFormats
                Call AppendImageFormat(sImageFormat)
            Next
        End Sub

        Friend Sub AppendImageFormat(ImageFormat As String)
            Dim sImageFormat As String = ImageFormat.ToLower
            If Not sImageFormat.StartsWith("image/") Then
                sImageFormat = "image/" & sImageFormat
            End If
            If Not oImageFormats.Contains(sImageFormat) Then
                Call oImageFormats.Add(sImageFormat)
            End If
        End Sub

        Public Function IsImageFormatsSupported(ImageFormat As String) As Boolean
            Dim sImageFormat As String = ImageFormat.ToUpper
            If Not sImageFormat.StartsWith("image/") Then
                sImageFormat = "image/" & sImageFormat
            End If
            Return oImageFormats.Contains(sImageFormat)
        End Function
    End Class

    Public Class cWMS
        Implements cISurfaceItem

        Private oSurvey As cSurvey

        Private sName As String
        Private sID As String

        Private sURL As String
        Private sLayer As String

        Private sSRSOverride As String

        Friend Event OnChange(ByVal Sender As cWMS)

        Friend Class cDefaultArgs
            Public ID As String

            Public Sub New()
                Me.ID = ""
            End Sub

            Public Sub New(ID As String)
                Me.ID = ID
            End Sub
        End Class

        Friend Event OnDefaultSet(ByVal Sender As cWMS, Args As cDefaultArgs)
        Friend Event OnDefaultGet(ByVal Sender As cWMS, Args As cDefaultArgs)

        Friend Sub New(Survey As cSurvey, ByVal File As Storage.cFile, ByVal WMS As XmlElement)
            oSurvey = Survey
            sName = modXML.GetAttributeValue(WMS, "name", "")
            sID = modXML.GetAttributeValue(WMS, "id")

            sURL = modXML.GetAttributeValue(WMS, "url")
            sLayer = modXML.GetAttributeValue(WMS, "layer")

            sSRSOverride = modXML.GetAttributeValue(WMS, "srsoverride", "")
        End Sub

        Public Property Layer As String
            Get
                Return sLayer
            End Get
            Set(value As String)
                If value <> sLayer Then
                    sLayer = value
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property URL As String
            Get
                Return sURL
            End Get
            Set(value As String)
                value = value.Trim
                If value.EndsWith("?") Then value = value.Substring(0, value.Length - 1)
                If value <> sURL Then
                    sURL = value
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Name As String Implements cISurfaceItem.Name
            Get
                Return sName
            End Get
            Set(value As String)
                If value <> sName Then
                    sName = value
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Friend Function GetImage(TLCorner As cCoordinate, BRCorner As cCoordinate, Ratio As Integer) As Image
            Dim oTL As modUTM.UTM = New modUTM.UTM(TLCorner)
            Dim oBR As modUTM.UTM = New modUTM.UTM(BRCorner)
            Dim iWidth As Integer = (oBR.East - oTL.East) / Ratio
            Dim iHeight As Integer = (oTL.North - oBR.North) / Ratio
            Dim sFilename As String = My.Computer.FileSystem.GetTempFileName()
            Dim iSystem As Integer = modWMSManager.GetSystemFromUTM(Me, oTL)
            Dim oImage As Image = modWMSManager.WMSLoadTile(oSurvey, sName, sFilename, modWMSManager.FormatURL(sURL, "LAYERS=" & sLayer & "&PROJECTION=EPSG%3A4326&FORMAT=image/png&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A%SYSTEM%&CRS=EPSG%3A%SYSTEM%&BBOX=%X1%,%Y1%,%X2%,%Y2%&WIDTH=%WIDTH%&HEIGHT=%HEIGHT%"), iSystem, oTL.East, oBR.North, oBR.East, oTL.North, iWidth, iHeight)
            Try : Call My.Computer.FileSystem.DeleteFile(sFilename) : Catch : End Try
            Return oImage
        End Function

        Friend Function GetImage(TLCorner As cCoordinate, BRCorner As cCoordinate, Ratio As Integer, Background As Color) As Image
            Dim oImage As Image = GetImage(TLCorner, BRCorner, Ratio)
            Dim oNewImage As Image = New Bitmap(oImage.Width, oImage.Height)
            Dim oGraphics As Graphics = Graphics.FromImage(oNewImage)
            Call oGraphics.Clear(Background)
            Call oGraphics.DrawImage(oImage, New Point(0, 0))
            Call oGraphics.Dispose()
            Call oImage.Dispose()
            Return oNewImage
        End Function

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("wms")
            Call oXmlItem.SetAttribute("name", sName)
            Call oXmlItem.SetAttribute("id", sID)

            Call oXmlItem.SetAttribute("url", sURL)
            Call oXmlItem.SetAttribute("layer", sLayer)

            If sSRSOverride <> "" Then Call oXmlItem.SetAttribute("srsoverride", sSRSOverride)

            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Property SRSOverride As String
            Get
                Return sSRSOverride
            End Get
            Set(Value As String)
                sSRSOverride = Value
            End Set
        End Property

        Public ReadOnly Property ID As String Implements cISurfaceItem.ID
            Get
                Return sID
            End Get
        End Property

        Friend Sub CopyFrom(WMS As cWMS)
            sID = WMS.sID
            sName = WMS.sName

            sURL = WMS.sURL
            sLayer = WMS.sLayer

            sSRSOverride = WMS.sSRSOverride
        End Sub

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString

            sURL = ""
            sLayer = ""

            sSRSOverride = ""
        End Sub

        Public Function IsEmpty() As Boolean Implements cISurfaceItem.IsEmpty
            Return sURL = "" And sLayer = ""
        End Function

        Public Sub Clear()
            sName = ""
            sURL = ""
            sLayer = ""
            sSRSOverride = ""
            RaiseEvent OnChange(Me)
        End Sub

        Public Enum WMSDataTypeEnum
            WMSDefaultType = 0
        End Enum

        Public Class cWMSImportOptions

        End Class

        Friend Function Import(DataType As WMSDataTypeEnum, Name As String, URL As String, Layer As String, SRSOverride As String, Options As cWMSImportOptions) As Boolean
            Dim bResult As Boolean
            Select Case DataType
                Case WMSDataTypeEnum.WMSDefaultType
                    sName = Name
                    sURL = URL
                    sLayer = Layer
                    sSRSOverride = SRSOverride
                    RaiseEvent OnChange(Me)
            End Select
            bResult = True
            Return bResult
        End Function

        Public Property [Default] As Boolean
            Get
                Dim oArgs As cDefaultArgs = New cDefaultArgs()
                RaiseEvent OnDefaultGet(Me, oArgs)
                Return sID = oArgs.ID
            End Get
            Set(value As Boolean)
                If value Then
                    Dim oArgs As cDefaultArgs = New cDefaultArgs(sID)
                    RaiseEvent OnDefaultSet(Me, oArgs)
                Else
                    Dim oArgs As cDefaultArgs = New cDefaultArgs()
                    RaiseEvent OnDefaultSet(Me, oArgs)
                End If
            End Set
        End Property
    End Class
End Namespace
