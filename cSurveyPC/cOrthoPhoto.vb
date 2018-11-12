Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Surface
    Public Class cOrthoPhoto
        Implements cISurfaceItem

        Private oSurvey As cSurvey

        Private sName As String
        Private sID As String

        Private oPhoto As Image
        Private sXSize As Decimal
        Private sYSize As Decimal
        Private iSystem As cSurface.CoordinateSystemEnum

        Private WithEvents oCoordinate As cCoordinate

        Friend Event OnChange(ByVal Sender As cOrthoPhoto)

        Private oImagesCaches As Dictionary(Of Size, Image)

        Friend Class cDefaultArgs
            Public ID As String

            Public Sub New()
                Me.ID = ""
            End Sub

            Public Sub New(ID As String)
                Me.ID = ID
            End Sub
        End Class

        Friend Event OnDefaultSet(ByVal Sender As cOrthoPhoto, Args As cDefaultArgs)
        Friend Event OnDefaultGet(ByVal Sender As cOrthoPhoto, Args As cDefaultArgs)

        Friend Function GetTLPoint() As PointF
            Dim oOrigin As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.Properties.Origin).Coordinate
            Dim oPoint As Calculate.cTrigPointCoordinate = New Calculate.cTrigPointCoordinate(GetCoordinate(GetCoordinateCornerEnum.TopLeft))
            Dim oOriginUTM As modUTM.UTM = modUTM.WGS84ToUTM(oOrigin)
            Dim oPointUTM As modUTM.UTM = modUTM.WGS84ToUTM(oPoint)
            Return New PointF(oPointUTM.East - oOriginUTM.East, oOriginUTM.North - oPointUTM.North)
        End Function

        Friend Function GetBRPoint() As PointF
            Dim oOrigin As Calculate.cTrigPointCoordinate = oSurvey.Calculate.TrigPoints(oSurvey.Properties.Origin).Coordinate
            Dim oPoint As Calculate.cTrigPointCoordinate = New Calculate.cTrigPointCoordinate(GetCoordinate(GetCoordinateCornerEnum.BottomRight))
            Dim oOriginUTM As modUTM.UTM = modUTM.WGS84ToUTM(oOrigin)
            Dim oPointUTM As modUTM.UTM = modUTM.WGS84ToUTM(oPoint)
            Return New PointF(oPointUTM.East - oOriginUTM.East, oOriginUTM.North - oPointUTM.North)
        End Function

        Public Function GetImage(Size As Size) As Image
            If oImagesCaches.ContainsKey(Size) Then
                Return oImagesCaches(Size)
            Else
                Dim oImage As Image = oPhoto
                Dim oThumbImage As Image = New Bitmap(Size.Width, Size.Height)
                Using oGr As Graphics = Graphics.FromImage(oThumbImage)
                    oGr.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    oGr.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                    Dim iSrcWidth As Single = oImage.Width
                    Dim iSrcHeight As Single = oImage.Height
                    Dim iDestWidth As Single = oThumbImage.Width
                    Dim iDestHeight As Single = oThumbImage.Height
                    Dim sDeltaX As Single = iSrcWidth / iDestWidth
                    Dim sDeltaY As Single = iSrcHeight / iDestHeight
                    Dim sDelta As Single = IIf(sDeltaX > sDeltaY, sDeltaX, sDeltaY)
                    Dim iWidth As Single = iSrcWidth / sDelta
                    Dim iHeight As Single = iSrcHeight / sDelta
                    Dim oRect As RectangleF = New RectangleF((iDestWidth - iWidth) / 2, (iDestHeight - iHeight) / 2, iWidth, iHeight)
                    Call oGr.DrawImage(oImage, oRect)
                    Call oImagesCaches.Add(Size, oThumbImage)
                End Using
                Return oThumbImage
            End If
        End Function

        Public ReadOnly Property Width As Single
            Get
                Return oPhoto.Width * sXSize
            End Get
        End Property

        Public ReadOnly Property Height As Single
            Get
                Return oPhoto.Height * sYSize
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, ByVal File As Storage.cFile, ByVal OrthoPhoto As XmlElement)
            oSurvey = Survey
            sName = modXML.GetAttributeValue(OrthoPhoto, "name", "")
            sID = modXML.GetAttributeValue(OrthoPhoto, "id")
            oCoordinate = New cCoordinate(OrthoPhoto.Item("coordinate"))
            iSystem = modXML.GetAttributeValue(OrthoPhoto, "system", cSurface.CoordinateSystemEnum.UTMWGS84)
            sXSize = modNumbers.StringToSingle(modXML.GetAttributeValue(OrthoPhoto, "xsize", 0))
            sYSize = modNumbers.StringToSingle(modXML.GetAttributeValue(OrthoPhoto, "ysize", 0))
            Select Case File.FileFormat
                Case Storage.cFile.FileFormatEnum.CSX
                    Try
                        Dim oms As IO.MemoryStream = New IO.MemoryStream(Convert.FromBase64String(modXML.GetAttributeValue(OrthoPhoto, "photo")))
                        oPhoto = New Bitmap(oms)
                        'Call oms.Dispose()
                    Catch
                    End Try
                Case Storage.cFile.FileFormatEnum.CSZ
                    Try
                        Dim sDataPath As String = modXML.GetAttributeValue(OrthoPhoto, "photo")
                        oPhoto = New Bitmap(DirectCast(File.Data(sDataPath), Storage.cStorageItemFile).Stream)
                    Catch
                    End Try
            End Select
            oImagesCaches = New Dictionary(Of Size, Image)
        End Sub

        Public ReadOnly Property XSize As Decimal
            Get
                Return sXSize
            End Get
        End Property

        Public ReadOnly Property YSize As Decimal
            Get
                Return sYSize
            End Get
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

        Public Enum GetCoordinateCornerEnum
            TopLeft = 0
            TopRight = 1
            BottomLeft = 2
            BottomRight = 3
        End Enum

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("orthophoto")
            Call oXmlItem.SetAttribute("name", sName)
            Call oXmlItem.SetAttribute("id", sID)
            Call oCoordinate.SaveTo(File, Document, oXmlItem)
            If iSystem <> cSurface.CoordinateSystemEnum.UTMWGS84 Then Call oXmlItem.SetAttribute("system", iSystem.ToString("D"))
            Call oXmlItem.SetAttribute("xsize", modNumbers.NumberToString(sXSize, "0.000000"))
            Call oXmlItem.SetAttribute("ysize", modNumbers.NumberToString(sYSize, "0.000000"))
            Try
                If Not (File.Options And Storage.cFile.FileOptionsEnum.DontSaveBinary) = Storage.cFile.FileOptionsEnum.DontSaveBinary Then
                    Select Case File.FileFormat
                        Case Storage.cFile.FileFormatEnum.CSX
                            Dim oms As IO.MemoryStream = New IO.MemoryStream
                            Call oPhoto.Save(oms, Drawing.Imaging.ImageFormat.Jpeg)
                            Call oXmlItem.SetAttribute("photo", Convert.ToBase64String(oms.ToArray()))
                        Case Storage.cFile.FileFormatEnum.CSZ
                            Dim sDataPath As String = "_data\surface\orthophotos\" & sID & ".jpg"
                            Dim oDataStorage As Storage.cStorageItemFile = File.Data.AddFile(sDataPath)
                            Call oPhoto.Save(oDataStorage.Stream, Drawing.Imaging.ImageFormat.Jpeg)
                            Call oXmlItem.SetAttribute("photo", sDataPath)
                    End Select
                End If
            Catch
            End Try
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Function GetCoordinate(Corner As GetCoordinateCornerEnum) As cCoordinate
            Dim dWidth As Decimal = oPhoto.Width
            Dim dHeight As Decimal = oPhoto.Height
            Select Case iSystem
                Case cSurface.CoordinateSystemEnum.WGS84
                    Select Case Corner
                        Case GetCoordinateCornerEnum.TopLeft
                            Return New cCoordinate(oCoordinate)
                        Case GetCoordinateCornerEnum.TopRight
                            Return New cCoordinate(oCoordinate.GetLatitude, oCoordinate.GetLongitude + dWidth * sXSize, 0)
                        Case GetCoordinateCornerEnum.BottomLeft
                            Return New cCoordinate(oCoordinate.GetLatitude - dHeight * sYSize, oCoordinate.GetLongitude, 0)
                        Case GetCoordinateCornerEnum.BottomRight
                            Return New cCoordinate(oCoordinate.GetLatitude - dHeight * sYSize, oCoordinate.GetLongitude + dWidth * sXSize, 0)
                    End Select
                Case cSurface.CoordinateSystemEnum.UTMWGS84
                    Select Case Corner
                        Case GetCoordinateCornerEnum.TopLeft
                            Return New cCoordinate(oCoordinate)
                            'Return oTLCoordinate
                        Case GetCoordinateCornerEnum.TopRight
                            Dim oTL As modUTM.UTM = New modUTM.UTM(oCoordinate)
                            oTL.East = oTL.East + dWidth * sXSize
                            Return New cCoordinate(oTL.East, oTL.North, oTL.Band, oTL.Zone, 0)
                            'Return oTRCoordinate
                        Case GetCoordinateCornerEnum.BottomLeft
                            Dim oTL As modUTM.UTM = New modUTM.UTM(oCoordinate)
                            oTL.North = oTL.North - dHeight * sYSize
                            Return New cCoordinate(oTL.East, oTL.North, oTL.Band, oTL.Zone, 0)
                            'Return oBLCoordinate
                        Case GetCoordinateCornerEnum.BottomRight
                            Dim oTL As modUTM.UTM = New modUTM.UTM(oCoordinate)
                            oTL.East = oTL.East + dWidth * sXSize
                            oTL.North = oTL.North - dHeight * sYSize
                            Return New cCoordinate(oTL.East, oTL.North, oTL.Band, oTL.Zone, 0)
                            'Return oBRCoordinate
                    End Select
            End Select
        End Function

        Private Sub pConvertToUTM()
            Call oSurvey.RaiseOnProgressEvent("orthophoto.import.converttoutm", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin2"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)

            Dim dStep As Decimal = 1

            Dim oTL As cCoordinate = GetCoordinate(GetCoordinateCornerEnum.TopLeft)
            Dim oTR As cCoordinate = GetCoordinate(GetCoordinateCornerEnum.TopRight)
            Dim oBL As cCoordinate = GetCoordinate(GetCoordinateCornerEnum.BottomLeft)
            Dim oBR As cCoordinate = GetCoordinate(GetCoordinateCornerEnum.BottomRight)

            Dim oTLUTM As modUTM.UTM = modUTM.WGS84ToUTM(oTL)
            Dim oTRUTM As modUTM.UTM = modUTM.WGS84ToUTM(oTR)
            Dim oBLUTM As modUTM.UTM = modUTM.WGS84ToUTM(oBL)
            Dim oBRUTM As modUTM.UTM = modUTM.WGS84ToUTM(oBR)

            Using oPath As GraphicsPath = New GraphicsPath
                Dim oPoints() As PointF = {oTLUTM, oTRUTM, oBRUTM, oBLUTM}
                Call oPath.AddPolygon(oPoints)
                Using oMatrix As Matrix = New Matrix
                    Call oMatrix.Translate(-oTLUTM.East, -oTLUTM.North, MatrixOrder.Append)
                    Call oMatrix.Scale(1 / dStep, -1 / dStep, MatrixOrder.Append)
                    Call oPath.Transform(oMatrix)
                End Using

                Dim oNewRect As Rectangle = Rectangle.Truncate(oPath.GetBounds)
                Dim iNewWidth As Integer = oNewRect.Width
                Dim iNewHeight As Integer = oNewRect.Height
                Dim oNewImage As Bitmap = New Bitmap(iNewWidth, iNewHeight)
                Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                    Call oGraphics.Clear(Color.White)
                    oGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                    oGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                    Using oMatrix As Matrix = New Matrix
                        Call oMatrix.Translate(-oNewRect.X, -oNewRect.Y, MatrixOrder.Append)
                        Call oPath.Transform(oMatrix)
                    End Using

                    oPoints = {oPath.PathPoints(0), oPath.PathPoints(1), oPath.PathPoints(3)}
                    Call oGraphics.DrawImage(oPhoto.Clone, oPoints)

                    oPhoto = oNewImage

                    Dim oDestRect As RectangleF = oPath.GetBounds
                    Dim dDX As Decimal = oPath.PathPoints(0).X - oDestRect.Left
                    Dim dDY As Decimal = oPath.PathPoints(0).Y - oDestRect.Top
                    oCoordinate = New cCoordinate(oTLUTM.East - dDX * dStep, oTLUTM.North + dDY * dStep, oTLUTM.Band, oTLUTM.Zone, 0D)
                    iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
                    sXSize = dStep
                    sYSize = dStep

                End Using
            End Using

            Call oSurvey.RaiseOnProgressEvent("orthophoto.import.converttoutm", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend2"), 1)
        End Sub

        Public ReadOnly Property ID As String Implements cISurfaceItem.ID
            Get
                Return sID
            End Get
        End Property

        Public ReadOnly Property Photo As Image
            Get
                Return oPhoto
            End Get
        End Property

        Public ReadOnly Property System As cSurface.CoordinateSystemEnum
            Get
                Return iSystem
            End Get
        End Property

        Friend Sub CopyFrom(OrthoPhoto As cOrthoPhoto)
            sID = OrthoPhoto.sID
            sName = OrthoPhoto.sName
            Call oCoordinate.CopyFrom(OrthoPhoto.oCoordinate)
            oPhoto = OrthoPhoto.oPhoto.Clone
            iSystem = OrthoPhoto.iSystem
            sXSize = OrthoPhoto.sXSize
            sYSize = OrthoPhoto.sYSize
            Call oImagesCaches.Clear()
            For Each sKey As Size In OrthoPhoto.oImagesCaches.Keys
                Call oImagesCaches.Add(sKey, OrthoPhoto.oImagesCaches(sKey))
            Next
        End Sub

        Friend Sub New(Survey As cSurvey, Coordinate As cCoordinate, Image As Image, XSize As Single, YSize As Single)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            oCoordinate = New cCoordinate(Coordinate)
            iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
            oPhoto = Image.Clone
            sXSize = XSize
            sYSize = YSize
            oImagesCaches = New Dictionary(Of Size, Image)
        End Sub

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            oCoordinate = New cCoordinate()
            iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
            sXSize = 1
            sYSize = 1
            oImagesCaches = New Dictionary(Of Size, Image)
        End Sub

        Public Function IsEmpty() As Boolean Implements cISurfaceItem.IsEmpty
            Return oPhoto Is Nothing
        End Function

        Public Sub Clear()
            sName = ""
            oPhoto = Nothing
            iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
            sXSize = 0
            sYSize = 0
            RaiseEvent OnChange(Me)
        End Sub

        Public ReadOnly Property Coordinate As cCoordinate
            Get
                Return oCoordinate
            End Get
        End Property

        Public Enum OrthoPhotoDataTypeEnum
            RasterImageWithWorldFile = 0
        End Enum

        Public Class cOrthoPhotoImportOptions
            Public Enum CoordinateSystemEnum
                WGS84 = 0
                UTMWGS84 = 1
            End Enum

            Private iSystem As CoordinateSystemEnum
            Private oParameters As Dictionary(Of String, Object)

            Public Sub New(Optional CoordinateSystem As CoordinateSystemEnum = CoordinateSystemEnum.WGS84)
                iSystem = CoordinateSystem
                oParameters = New Dictionary(Of String, Object)
            End Sub

            Public Property System As CoordinateSystemEnum
                Get
                    Return iSystem
                End Get
                Set(value As CoordinateSystemEnum)
                    iSystem = value
                End Set
            End Property

            Public ReadOnly Property Parameters As Dictionary(Of String, Object)
                Get
                    Return oParameters
                End Get
            End Property
        End Class

        Private Function pGetWorldFileFromImageFilename(Filename As String) As String
            Dim sExt As String = Path.GetExtension(Filename)
            Dim sName As String = Path.GetFileNameWithoutExtension(Filename)
            Dim sWorldFiles(1) As String
            sWorldFiles(0) = Path.Combine(Path.GetDirectoryName(Filename), sName & sExt & "w")
            sWorldFiles(1) = Path.Combine(Path.GetDirectoryName(Filename), sName & "." & sExt.Substring(1, 1) & sExt.Substring(3, 1) & "w")
            For Each sWorldFile As String In sWorldFiles
                If My.Computer.FileSystem.FileExists(sWorldFile) Then
                    Return sWorldFile
                End If
            Next
            Return ""
        End Function

        Friend Function Import(DataType As OrthoPhotoDataTypeEnum, Filename As String, Options As cOrthoPhotoImportOptions) As Boolean
            Dim bResult As Boolean
            Select Case DataType
                Case OrthoPhotoDataTypeEnum.RasterImageWithWorldFile
                    'file ArcASCIIGrid...
                    Call oSurvey.RaiseOnProgressEvent("orthophoto.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
                    Try
                        Select Case Path.GetExtension(Filename).ToLower
                            Case ".jpg", ".png", ".tif"
                                oPhoto = New Bitmap(Filename)
                                Dim sWorldFiles As String = pGetWorldFileFromImageFilename(Filename)
                                If sWorldFiles = "" Then
                                    Call MsgBox(String.Format(modMain.GetLocalizedString("surface.warning2"), modMain.GetLocalizedString("surface.warning4")), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("surface.warningtitle"))
                                Else
                                    Dim sXMeters As Decimal
                                    Dim sYMeters As Decimal
                                    Using oWSt As StreamReader = My.Computer.FileSystem.OpenTextFileReader(sWorldFiles)
                                        sXSize = modNumbers.StringToDecimal(oWSt.ReadLine)
                                        Call oWSt.ReadLine()    'skip rotation lines
                                        Call oWSt.ReadLine()
                                        sYSize = Math.Abs(modNumbers.StringToDecimal(oWSt.ReadLine))
                                        sXMeters = modNumbers.StringToDecimal(oWSt.ReadLine)  'uppersx corner
                                        sYMeters = modNumbers.StringToDecimal(oWSt.ReadLine)
                                    End Using
                                    If sXMeters <> 0 And sYMeters <> 0 Then
                                        Select Case Options.System
                                            Case cOrthoPhotoImportOptions.CoordinateSystemEnum.UTMWGS84
                                                'meters...do nothing
                                                iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
                                                Dim iUTMZone As Integer = Options.Parameters("utmzone")
                                                Dim sUTMBand As String = Options.Parameters("utmband")
                                                oCoordinate = New cCoordinate(sXMeters, sYMeters, sUTMBand, iUTMZone, 0)
                                            Case cOrthoPhotoImportOptions.CoordinateSystemEnum.WGS84
                                                'angle...
                                                iSystem = cSurface.CoordinateSystemEnum.WGS84
                                                oCoordinate = New cCoordinate(sYMeters, sXMeters, 0)
                                        End Select
                                    End If
                                End If
                        End Select
                        If iSystem = cSurface.CoordinateSystemEnum.WGS84 Then
                            Call pConvertToUTM()
                        End If
                        bResult = True
                    Catch ex As Exception
                        Call MsgBox(String.Format(modMain.GetLocalizedString("surface.warning2"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, modMain.GetLocalizedString("surface.warningtitle"))
                        bResult = False
                    End Try
                    If "" & sName = "" Then sName = Path.GetFileName(Filename)
                    Call oImagesCaches.Clear()
                    Call oSurvey.RaiseOnProgressEvent("orthophoto.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend1"), 0)
                    RaiseEvent OnChange(Me)
            End Select
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
