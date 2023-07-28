Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters
Imports cSurveyPC.cSurvey.Surface
Imports System.Drawing.Imaging

Namespace cSurvey
    Public Class cSurface
        Implements IEnumerable

        Public Enum CoordinateSystemEnum
            WGS84 = 0
            UTMWGS84 = 1
        End Enum

        Private oSurvey As cSurvey
        Private WithEvents oElevations As cElevations
        Private WithEvents oOrthoPhotos As cOrthoPhotos
        Private WithEvents oWMSs As cWMSs

        Private oItems As Dictionary(Of String, cISurfaceItem)

        Friend Class OnSurfaceEventArgs
            Public Enum SurfaceEventSourceEnum
                Surface = 0
                Elevation = 1
                OrthoPhotos = 2
                WMSs = 3
            End Enum

            Private iSource As SurfaceEventSourceEnum

            Public ReadOnly Property Source As SurfaceEventSourceEnum
                Get
                    Return iSource
                End Get
            End Property

            Friend Sub New(ByVal Source As SurfaceEventSourceEnum)
                iSource = Source
            End Sub
        End Class

        Friend Event OnSurfaceChange(ByVal Sender As cSurface, ByVal e As OnSurfaceEventArgs)

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cISurfaceItem)()
            oElevations = New cElevations(oSurvey)
            oOrthoPhotos = New cOrthoPhotos(oSurvey)
            oWMSs = New cWMSs(oSurvey)
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal File As cFile, ByVal Surface As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cISurfaceItem)()
            Try
                If modXML.ChildElementExist(Surface, "elevations") Then
                    oElevations = New cElevations(oSurvey, File, Surface.Item("elevations"))
                Else
                    oElevations = New cElevations(oSurvey)
                End If
            Catch
                oElevations = New cElevations(oSurvey)
            End Try
            Try
                If modXML.ChildElementExist(Surface, "orthophotos") Then
                    oOrthoPhotos = New cOrthoPhotos(oSurvey, File, Surface.Item("orthophotos"))
                Else
                    oOrthoPhotos = New cOrthoPhotos(oSurvey)
                End If
            Catch
                oOrthoPhotos = New cOrthoPhotos(oSurvey)
            End Try
            Try
                If modXML.ChildElementExist(Surface, "wmss") Then
                    oWMSs = New cWMSs(oSurvey, File, Surface.Item("wmss"))
                Else
                    oWMSs = New cWMSs(oSurvey)
                End If
            Catch
                oWMSs = New cWMSs(oSurvey)
            End Try
            Call pRebindLocalCollection()
        End Sub

        Public Function IsEmpty() As Boolean
            Return oElevations.Count = 0 AndAlso oOrthoPhotos.Count = 0 AndAlso oWMSs.Count = 0
        End Function

        Private Sub pRebindLocalCollection()
            Call oItems.Clear()
            For Each oItem As cISurfaceItem In oOrthoPhotos
                If Not oItem.IsEmpty Then
                    Call oItems.Add(oItem.ID, oItem)
                End If
            Next
            For Each oItem As cISurfaceItem In oElevations
                If Not oItem.IsEmpty Then
                    Call oItems.Add(oItem.ID, oItem)
                End If
            Next
            For Each oItem As cISurfaceItem In oWMSs
                If Not oItem.IsEmpty Then
                    Call oItems.Add(oItem.ID, oItem)
                End If
            Next
        End Sub

        Friend Sub CopyFrom(Surface As cSurface)
            Call oElevations.CopyFrom(Surface.oElevations)
            Call oOrthoPhotos.CopyFrom(Surface.oOrthoPhotos)
            Call oWMSs.CopyFrom(Surface.oWMSs)
            Call pRebindLocalCollection()
            RaiseEvent OnSurfaceChange(Me, New OnSurfaceEventArgs(OnSurfaceEventArgs.SurfaceEventSourceEnum.Surface))
        End Sub

        Public ReadOnly Property Elevations As cElevations
            Get
                Return oElevations
            End Get
        End Property

        Public ReadOnly Property OrthoPhotos As cOrthoPhotos
            Get
                Return oOrthoPhotos
            End Get
        End Property

        Public ReadOnly Property WMSs As cWMSs
            Get
                Return oWMSs
            End Get
        End Property

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("surface")
            If oElevations.Count <> 0 Then Call oElevations.SaveTo(File, Document, oXmlItem)
            If oOrthoPhotos.Count <> 0 Then Call oOrthoPhotos.SaveTo(File, Document, oXmlItem)
            If oWMSs.Count <> 0 Then Call oWMSs.SaveTo(File, Document, oXmlItem)
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Friend Function CreateTherionSurfaceDataFile(OptionsName As String, BasePath As String, BaseFilename As String, Result As cTherionCalculateResult) As String
            Dim oOptions As Design.cOptionsTherion = oSurvey.Options(OptionsName)
            Dim sSurfaceBaseFilename As String = Path.GetFileNameWithoutExtension(BaseFilename) & "_surface.txt"
            Dim sSurfaceFilename = Path.Combine(BasePath, sSurfaceBaseFilename)
            Call Result.Files.Add(sSurfaceFilename)
            Using oSw As StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(sSurfaceFilename, False, System.Text.Encoding.ASCII)
                Call oSw.WriteLine("surface")
                Dim oOrthoPhoto As cOrthoPhoto = If(oOptions.SurfaceOptions.Orthophoto.ID = "", Nothing, Item(oOptions.SurfaceOptions.Orthophoto.ID))
                If Not oOrthoPhoto Is Nothing Then
                    If Not oOrthoPhoto.IsEmpty Then 'And oOrthoPhoto.ShowIn3D Then
                        If oOrthoPhoto.System = CoordinateSystemEnum.WGS84 Then
                            Call oSw.WriteLine("cs lat-long")
                        Else
                            Dim oWGS84UTM As modUTM.UTM = New modUTM.UTM(oOrthoPhoto.Coordinate)
                            Call oSw.WriteLine("cs utm" & oWGS84UTM.Zone & If(oWGS84UTM.Band < "N", "S", ""))
                        End If
                        Dim sBitmapBaseFilename As String = "_therion_" & Path.GetFileNameWithoutExtension(BaseFilename) & "_" & oOrthoPhoto.ID & ".jpg"
                        Dim sBitmapFilename As String = Path.Combine(BasePath, sBitmapBaseFilename)
                        Call Result.Files.Add(sBitmapFilename)

                        Call oOrthoPhoto.Photo.Save(sBitmapFilename, System.Drawing.Imaging.ImageFormat.Jpeg)

                        'Dim oEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                        'Dim oEncoderParameters As EncoderParameters = New EncoderParameters(1)
                        'oEncoderParameters.Param(0) = New EncoderParameter(oEncoder, 30&)
                        'Call oOrthoPhoto.Photo.Save(sBitmapFilename, modPaint.GetImageEncoder(ImageFormat.Jpeg), oEncoderParameters)

                        Dim oBL As cCoordinate = oOrthoPhoto.GetCoordinate(cOrthoPhoto.GetCoordinateCornerEnum.BottomLeft)
                        Dim oTR As cCoordinate = oOrthoPhoto.GetCoordinate(cOrthoPhoto.GetCoordinateCornerEnum.TopRight)
                        Dim sBLx As String
                        Dim sBLy As String
                        Dim sTRx As String
                        Dim sTRy As String
                        If oOrthoPhoto.System = CoordinateSystemEnum.WGS84 Then
                            Dim oWGS84BL As modUTM.WGS84 = New modUTM.WGS84(oBL)
                            Dim oWGS84TR As modUTM.WGS84 = New modUTM.WGS84(oTR)
                            sBLx = modText.FormatNumber(oWGS84BL.Latitude, "0.0000000")
                            sBLy = modText.FormatNumber(oWGS84BL.Longitude, "0.0000000")
                            sTRx = modText.FormatNumber(oWGS84TR.Latitude, "0.0000000")
                            sTRy = modText.FormatNumber(oWGS84TR.Longitude, "0.0000000")
                        Else
                            Dim oWGS84UTMBL As modUTM.UTM = New modUTM.UTM(oBL)
                            Dim oWGS84UTMTR As modUTM.UTM = New modUTM.UTM(oTR)
                            sBLx = modText.FormatNumber(oWGS84UTMBL.East, "0.0000000")
                            sBLy = modText.FormatNumber(oWGS84UTMBL.North, "0.0000000")
                            sTRx = modText.FormatNumber(oWGS84UTMTR.East, "0.0000000")
                            sTRy = modText.FormatNumber(oWGS84UTMTR.North, "0.0000000")
                        End If
                        Call oSw.WriteLine("bitmap " & sBitmapBaseFilename & " [0 0 " & sBLx & " " & sBLy & " " & oOrthoPhoto.Photo.Width & " " & oOrthoPhoto.Photo.Height & " " & sTRx & " " & sTRy & "]")
                    End If
                End If
                Dim oElevation As cElevation = If(oOptions.SurfaceOptions.Elevation.ID = "", Nothing, Item(oOptions.SurfaceOptions.Elevation.ID))
                If Not oElevation Is Nothing Then
                    If Not oElevation.IsEmpty Then 'And oElevation.ShowIn3D Then
                        If oElevation.System = CoordinateSystemEnum.WGS84 Then
                            Call oSw.WriteLine("cs lat-long")
                            Dim oWGS84 As modUTM.WGS84 = New modUTM.WGS84(oElevation.Coordinate)
                            Call oSw.WriteLine("grid " & modText.FormatNumber(oWGS84.Latitude, "0.0000000") & " " & modText.FormatNumber(oWGS84.Longitude, "0.0000000") & " " & modText.FormatNumber(oElevation.XSize, "0.000000000") & " " & modText.FormatNumber(oElevation.YSize, "0.000000000") & " " & oElevation.Columns & " " & oElevation.Rows)
                        Else
                            Dim oWGS84UTM As modUTM.UTM = New modUTM.UTM(oElevation.Coordinate)
                            Call oSw.WriteLine("cs utm" & oWGS84UTM.Zone & If(oWGS84UTM.Band < "N", "S", ""))
                            Call oSw.WriteLine("grid " & modText.FormatNumber(oWGS84UTM.East, "0.0000000") & " " & modText.FormatNumber(oWGS84UTM.North, "0.0000000") & " " & modText.FormatNumber(oElevation.XSize, "0.000000000") & " " & modText.FormatNumber(oElevation.YSize, "0.000000000") & " " & oElevation.Columns & " " & oElevation.Rows)
                        End If
                        For iRow As Integer = 0 To oElevation.Rows - 1
                            For iColumn As Integer = 0 To oElevation.Columns - 1
                                Dim sValue As Single = oElevation.Data(iRow, iColumn)
                                If sValue = cElevation.NoDataValue Then
                                    Call oSw.Write("0 ")
                                Else
                                    Call oSw.Write(modNumbers.NumberToString(sValue, "0") & " ")
                                End If
                            Next
                            Call oSw.WriteLine()
                        Next
                    End If
                End If
                Call oSw.WriteLine("endsurface")
                Call oSw.Flush()
                Call oSw.Close()
            End Using
            Return sSurfaceBaseFilename
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function Contains(Item As cISurfaceItem) As Boolean
            Return oItems.ContainsValue(Item)
        End Function

        Public Function Contains(ID As String) As Boolean
            Return oItems.ContainsKey(ID)
        End Function

        Default Public ReadOnly Property Item(ID As String) As cISurfaceItem
            Get
                If oItems.ContainsKey(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Private Sub oOrthoPhotos_OnChange(Sender As Object, Item As cSurfaceItemChanged) Handles oOrthoPhotos.OnChange
            Call pRebindLocalCollection()
            RaiseEvent OnSurfaceChange(Me, New OnSurfaceEventArgs(OnSurfaceEventArgs.SurfaceEventSourceEnum.OrthoPhotos))
        End Sub

        Private Sub oWMSs_OnChange(Sender As Object, Item As cSurfaceItemChanged) Handles oWMSs.OnChange
            Call pRebindLocalCollection()
            RaiseEvent OnSurfaceChange(Me, New OnSurfaceEventArgs(OnSurfaceEventArgs.SurfaceEventSourceEnum.WMSs))
        End Sub

        Private Sub oElevations_OnChange(Sender As Object, Item As cSurfaceItemChanged) Handles oElevations.OnChange
            Call pRebindLocalCollection()
            RaiseEvent OnSurfaceChange(Me, New OnSurfaceEventArgs(OnSurfaceEventArgs.SurfaceEventSourceEnum.Elevation))
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class

End Namespace