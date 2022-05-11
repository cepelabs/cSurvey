Imports System.Xml
Imports System.IO
Imports System.Runtime.Serialization.Formatters
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Surface
    Public Class cElevation
        Implements cISurfaceItem

        Private oSurvey As cSurvey
        Public Const NoDataValue As Single = -99999

        Private iRows As Integer
        Private iColumns As Integer
        Private sXSize As Decimal
        Private sYSize As Decimal
        Private iSystem As cSurface.CoordinateSystemEnum
        Private WithEvents oCoordinate As cCoordinate
        Private oData As Single(,)

        Private oRange As SizeF
        Private bChanged As Boolean

        Private oImage As Image

        Friend Event OnChange(ByVal Sender As cElevation)

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

        Friend Event OnDefaultSet(ByVal Sender As cElevation, Args As cDefaultArgs)
        Friend Event OnDefaultGet(ByVal Sender As cElevation, Args As cDefaultArgs)

        Public Enum ColorSchemaEnum
            WhiteToBlack = 0
            BlackToWhite = 1
        End Enum

        Private iColorSchema As ColorSchemaEnum
        'Private bShowIn3D As Boolean

        Private sName As String
        Private sID As String

        Public Enum RemoveNodataModeEnum
            Antialias = 0
            ByNeighbour = 1
            ByAverage = 2
        End Enum

        Public Function Reduce(Percentage As Single) As cElevation
            Dim oRange As SizeF = GetHeightRange()
            Dim sRange As Decimal = oRange.Height - oRange.Width
            Dim oImage As Bitmap = GetImage(iColumns, iRows)
            Dim sFactor As Decimal = (100 / Percentage)
            Dim iNewRows As Integer = iRows / sFactor
            Dim iNewColumns As Integer = iColumns / sFactor
            Dim oData(iNewRows, iNewColumns) As Single
            Dim iProgressIndex As Integer = 0
            Dim iProgressCount As Integer = iNewRows * iNewColumns
            Dim sPseutoHeight As Single
            Call oSurvey.RaiseOnProgressEvent("elevation.reduceset", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin4"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
            Using oScaledImage As Bitmap = modPaint.ScaleImage(oImage, New Drawing.Size(iNewColumns, iNewRows), Color.White)
                For iNewRow As Integer = 0 To iNewRows - 1
                    For iNewColumn As Integer = 0 To iNewColumns - 1
                        iProgressIndex += 1
                        If iProgressIndex Mod 2000 = 0 Then Call oSurvey.RaiseOnProgressEvent("elevation.reduceset", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress4"), iProgressIndex / iProgressCount)
                        If iColorSchema = cElevation.ColorSchemaEnum.BlackToWhite Then
                            sPseutoHeight = (oScaledImage.GetPixel(iNewColumn, iNewRow).R / 255) * sRange + oRange.Width
                        Else
                            sPseutoHeight = ((255 - oScaledImage.GetPixel(iNewColumn, iNewRow).R) / 255) * sRange + oRange.Width
                        End If
                        oData(iNewRow, iNewColumn) = sPseutoHeight
                    Next
                Next
            End Using
            Call oSurvey.RaiseOnProgressEvent("elevation.reduceset", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend4"), 0)
            Return New cElevation(oSurvey, sName, GetCoordinate(cOrthoPhoto.GetCoordinateCornerEnum.BottomLeft), iNewRows, iNewColumns, sXSize * sFactor, sYSize * sFactor, iSystem, oData, iColorSchema)
        End Function

        Public Sub RemoveNodata(Optional RemoveNoDataMode As RemoveNodataModeEnum = RemoveNodataModeEnum.ByAverage)
            If Not IsEmpty() Then
                Dim iProgressIndex As Integer = 0
                Dim iProgressCount As Integer = iRows * iColumns
                Call oSurvey.RaiseOnProgressEvent("elevation.nodataremove", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin3"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
                Dim oRange As SizeF = GetHeightRange()
                If RemoveNoDataMode = RemoveNodataModeEnum.ByAverage Then
                    For iRow As Integer = 0 To iRows - 1
                        For iColumn As Integer = 0 To iColumns - 1
                            iProgressIndex += 1
                            If iProgressIndex Mod 1000 = 0 Then Call oSurvey.RaiseOnProgressEvent("elevation.nodataremove", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress3"), iProgressIndex / iProgressCount)

                            Dim sHeight As Single = oData(iRow, iColumn)
                            If sHeight = NoDataValue Then
                                Dim iIndex As Integer = 1
                                Dim iAvgCount As Integer = 0
                                Dim sAvgHeight As Single = 0
                                Do
                                    For iAvgRow As Integer = iRow - iIndex To iRow + iIndex
                                        For iAvgCol As Integer = iColumn - iIndex To iColumn + iIndex
                                            Dim sTmpHeight As Single
                                            If iAvgRow >= 0 And iAvgRow < iRows And iAvgCol > 0 And iAvgCol < iColumns Then
                                                sTmpHeight = oData(iAvgRow, iAvgCol)
                                            Else
                                                sTmpHeight = NoDataValue
                                            End If
                                            If sTmpHeight <> NoDataValue Then
                                                iAvgCount += 1
                                                sAvgHeight += sTmpHeight
                                            End If
                                        Next
                                    Next
                                    iIndex += 1
                                Loop While iAvgCount = 0 Or (iIndex > iRows And iIndex > iColumns)
                                If iAvgCount > 0 Then
                                    sHeight = sAvgHeight / iAvgCount
                                    oData(iRow, iColumn) = sHeight
                                End If
                            End If
                        Next
                    Next
                Else
                    Using oImage = New Bitmap(iColumns, iRows, Imaging.PixelFormat.Format24bppRgb)
                        Using oGr As Graphics = Graphics.FromImage(oImage)
                            Dim iGrayScale As Integer = 127
                            Call oGr.Clear(Color.FromArgb(255, iGrayScale, iGrayScale, iGrayScale))
                            oGr.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                            oGr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                            oGr.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

                            Using oBrush As SolidBrush = New SolidBrush(Color.White)

                                For iRow As Integer = 0 To iRows - 1
                                    For icolumn As Integer = 0 To iColumns - 1
                                        iProgressIndex += 1
                                        If iProgressIndex Mod 100 = 0 Then Call oSurvey.RaiseOnProgressEvent("elevation.nodataremove", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress3"), iProgressIndex / iProgressCount)

                                        Dim sHeight As Single = oData(iRow, icolumn)
                                        Dim oRect As RectangleF
                                        Select Case RemoveNoDataMode
                                            Case RemoveNodataModeEnum.Antialias
                                                oRect = New RectangleF(icolumn, iRow, 1, 1)
                                            Case RemoveNodataModeEnum.ByNeighbour
                                                oRect = New RectangleF(icolumn - 1, iRow - 1, 3, 3)
                                        End Select

                                        If sHeight = NoDataValue Then
                                            'oBrush.Color = Color.Transparent
                                        Else
                                            iGrayScale = 255 * ((sHeight - oRange.Width) / (oRange.Height - oRange.Width))
                                            oBrush.Color = Color.FromArgb(255, iGrayScale, iGrayScale, iGrayScale)
                                            Call oGr.FillRectangle(oBrush, oRect)
                                        End If

                                    Next
                                Next
                            End Using
                        End Using
                        For iRow As Integer = 0 To iRows - 1
                            For iColumn As Integer = 0 To iColumns - 1
                                Dim oColor As Color = oImage.GetPixel(iColumn, iRow)
                                Dim sHeight As Single = oColor.R
                                sHeight = Math.Round(((sHeight / 255) * (oRange.Height - oRange.Width)) + oRange.Width, 0, MidpointRounding.AwayFromZero)

                                If oData(iRow, iColumn) = NoDataValue Then
                                    oData(iRow, iColumn) = sHeight
                                End If
                            Next
                        Next
                    End Using
                End If

                Call pImagesClear
                bChanged = True
                Call oSurvey.RaiseOnProgressEvent("elevation.nodataremove", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend3"), 0)
                RaiseEvent OnChange(Me)
            End If
        End Sub

        Private Sub pImagesClear()
            For Each oImage As Image In oImagesCaches.Values
                Call oImage.Dispose()
            Next
            Call oImagesCaches.Clear()
        End Sub

        Public Function GetImage(Width As Integer, Height As Integer) As Image
            Return GetImage(New Size(Width, Height))
        End Function

        Public Function GetImage(Size As Size) As Image
            If oImagesCaches.ContainsKey(Size) Then
                Return oImagesCaches(Size)
            Else
                Dim oDefaultImage As Image
                Dim oDefaultSize As Size = New Size(iColumns, iRows)
                If oImagesCaches.ContainsKey(oDefaultSize) Then
                    oDefaultImage = oImagesCaches(oDefaultSize)
                Else
                    Try
                        If IsEmpty() Then
                            oDefaultImage = Nothing
                        Else
                            Dim oRange As SizeF = GetHeightRange()

                            oDefaultImage = New Bitmap(iColumns, iRows, Imaging.PixelFormat.Format24bppRgb)
                            Using oGr As Graphics = Graphics.FromImage(oDefaultImage)
                                Call oGr.Clear(Color.White)
                                oGr.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                                oGr.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                                Using oBrush As SolidBrush = New SolidBrush(Color.White)
                                    Dim iGrayScale As Integer
                                    For iRow As Integer = 0 To iRows - 1
                                        For icolumn As Integer = 0 To iColumns - 1
                                            Dim sHeight As Single = oData(iRow, icolumn)
                                            Dim oRect As RectangleF = New RectangleF(icolumn - 0.5, iRow - 0.5, 1, 1)
                                            If sHeight = NoDataValue Then
                                                oBrush.Color = Color.Transparent
                                            Else
                                                Select Case iColorSchema
                                                    Case ColorSchemaEnum.BlackToWhite
                                                        iGrayScale = 255 * ((sHeight - oRange.Width) / (oRange.Height - oRange.Width))
                                                    Case ColorSchemaEnum.WhiteToBlack
                                                        iGrayScale = 255 - (255 * ((sHeight - oRange.Width) / (oRange.Height - oRange.Width)))
                                                End Select
                                                oBrush.Color = Color.FromArgb(255, iGrayScale, iGrayScale, iGrayScale)
                                            End If
                                            Call oGr.FillRectangle(oBrush, oRect)
                                        Next
                                    Next
                                End Using
                            End Using
                        End If
                    Catch
                        oDefaultImage = Nothing
                    End Try
                    Call oImagesCaches.Add(oDefaultSize, oDefaultImage)
                End If
                If Size <> oDefaultSize Then
                    Dim oImage As Image = oDefaultImage
                    Dim oThumbImage As Image = New Bitmap(Size.Width, Size.Height)
                    Try
                        Using oGr As Graphics = Graphics.FromImage(oThumbImage)
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
                        End Using
                    Catch
                    End Try
                    Call oImagesCaches.Add(Size, oThumbImage)
                    Return oThumbImage
                Else
                    Return oDefaultImage
                End If
            End If
        End Function

        Public ReadOnly Property System As cSurface.CoordinateSystemEnum
            Get
                Return iSystem
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, Name As String, Coordinate As cCoordinate, Rows As Integer, Columns As Integer, XSize As Decimal, YSize As Decimal, System As cSurface.CoordinateSystemEnum, Data As Single(,), ColorSchema As ColorSchemaEnum)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            sName = Name
            oCoordinate = Coordinate
            iRows = Rows
            iColumns = Columns
            sXSize = XSize
            sYSize = YSize
            iSystem = System
            oData = Data
            oRange = GetHeightRange()
            iColorSchema = ColorSchema
            oImagesCaches = New Dictionary(Of Size, Image)
            bChanged = True
        End Sub

        Friend Sub CopyFrom(Elevation As cElevation)
            sID = Elevation.sID
            sName = Elevation.sName
            Call oCoordinate.CopyFrom(Elevation.Coordinate)
            iRows = Elevation.iRows
            iColumns = Elevation.iColumns
            sXSize = Elevation.sXSize
            sYSize = Elevation.sYSize
            iSystem = Elevation.iSystem
            oData = Elevation.oData
            oRange = Elevation.oRange
            bChanged = Elevation.bChanged
            oImage = Elevation.oImage
            'bImageChanged = Elevation.bImageChanged
            iColorSchema = Elevation.iColorSchema

            Call pImagesClear()
            For Each sKey As Size In Elevation.oImagesCaches.Keys
                Call oImagesCaches.Add(sKey, Elevation.oImagesCaches(sKey))
            Next
        End Sub

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey

            sID = Guid.NewGuid.ToString
            oCoordinate = New cCoordinate()

            sName = ""
            iRows = 0
            iColumns = 0
            sXSize = 0
            sYSize = 0
            iSystem = cSurface.CoordinateSystemEnum.UTMWGS84

            iColorSchema = ColorSchemaEnum.WhiteToBlack
            'bShowIn3D = True

            oImagesCaches = New Dictionary(Of Size, Image)

            bChanged = True
        End Sub

        Public Function IsEmpty() As Boolean Implements cISurfaceItem.IsEmpty
            Return iRows = 0 Or iColumns = 0
        End Function

        Public ReadOnly Property ID As String Implements cISurfaceItem.ID
            Get
                Return sID
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, ByVal File As cFile, ByVal Elevation As XmlElement)
            oSurvey = Survey
            sID = Elevation.GetAttribute("id")
            oCoordinate = New cCoordinate(Elevation.Item("coordinate"))
            sName = modXML.GetAttributeValue(Elevation, "name", "")
            iRows = modXML.GetAttributeValue(Elevation, "rows")
            iColumns = modXML.GetAttributeValue(Elevation, "columns")
            iSystem = modXML.GetAttributeValue(Elevation, "system", cSurface.CoordinateSystemEnum.UTMWGS84)
            sXSize = modNumbers.StringToDecimal(modXML.GetAttributeValue(Elevation, "xsize"))
            sYSize = modNumbers.StringToDecimal(modXML.GetAttributeValue(Elevation, "ysize"))
            Select Case File.FileFormat
                Case cFile.FileFormatEnum.CSX
                    Dim oms As IO.MemoryStream = New IO.MemoryStream(Convert.FromBase64String(Elevation.GetAttribute("data")))
                    Dim oFormatter As Binary.BinaryFormatter = New Binary.BinaryFormatter()
                    oData = oFormatter.Deserialize(oms)
                Case cFile.FileFormatEnum.CSZ
                    Dim sDataPath As String = Elevation.GetAttribute("data")
                    Dim oFormatter As Binary.BinaryFormatter = New Binary.BinaryFormatter()
                    oData = oFormatter.Deserialize(DirectCast(File.Data(sDataPath), Storage.cStorageItemFile).Stream)
            End Select
            iColorSchema = modXML.GetAttributeValue(Elevation, "colorschema", ColorSchemaEnum.WhiteToBlack)
            oImagesCaches = New Dictionary(Of Size, Image)
            bChanged = True
        End Sub

        Public Property ColorSchema As ColorSchemaEnum
            Get
                Return iColorSchema
            End Get
            Set(value As ColorSchemaEnum)
                If ColorSchema <> value Then
                    iColorSchema = value

                    Call oImagesCaches.Clear()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

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

        'Public Property ShowIn3D As Boolean
        '    Get
        '        Return bShowIn3D
        '    End Get
        '    Set(value As Boolean)
        '        bShowIn3D = value
        '    End Set
        'End Property

        Public Sub Clear()
            sName = ""
            iColumns = 0
            iRows = 0
            sXSize = 0
            sYSize = 0
            ReDim oData(0, 0)
            oRange = New SizeF(0, 0)
            oImage = Nothing
            bChanged = False
            RaiseEvent OnChange(Me)
        End Sub

        Default Public ReadOnly Property Data(Row As Integer, Column As Integer) As Single
            Get
                Try
                    Return oData(Row, Column)
                Catch
                    Return NoDataValue
                End Try
            End Get
        End Property

        Private Function pGetLinePartFromASCLine(Line As String, Separator As Char()) As Object()
            Dim oData(1) As Object
            Dim sRowItems() As String = Line.Split(Separator, StringSplitOptions.RemoveEmptyEntries)
            oData(0) = sRowItems(0)
            oData(1) = modNumbers.StringToDouble(sRowItems(1))
            Return oData
        End Function

        Public Enum ElevationDataTypeEnum
            ArcASCIIGrid = 0
            'XYZ = 1
        End Enum

        Public Class cElevationImportOptions
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

        Public Function Import(DataType As ElevationDataTypeEnum, Filename As String, Options As cElevationImportOptions) As Boolean
            Dim bResult As Boolean
            Select Case DataType
                'Case ElevationDataTypeEnum.XYZ
                '    Call oSurvey.RaiseOnProgressEvent("elevation.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
                '    Try
                '        Dim oSr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Filename)
                '        Dim oFileDatas As Dictionary(Of Decimal, Dictionary(Of Decimal, Decimal)) = New Dictionary(Of Decimal, Dictionary(Of Decimal, Decimal))
                '        Dim dMinX As Decimal = Decimal.MaxValue
                '        Dim dMaxX As Decimal = Decimal.MinValue
                '        Dim dMinY As Decimal = Decimal.MaxValue
                '        Dim dMaxY As Decimal = Decimal.MinValue
                '        Do Until oSr.EndOfStream
                '            Dim sLine As String = oSr.ReadLine.Trim
                '            Dim sLineData() As String = sLine.Split({","}, StringSplitOptions.RemoveEmptyEntries)

                '            Dim dX As Decimal = modNumbers.StringToDecimal(sLineData(0))
                '            Dim dY As Decimal = modNumbers.StringToDecimal(sLineData(1))
                '            Dim dZ As Decimal = modNumbers.StringToDecimal(sLineData(2))

                '            If dX > dMaxX Then dMaxX = dX
                '            If dY > dMaxY Then dMaxY = dY
                '            If dX < dMinX Then dMinX = dX
                '            If dY < dMinY Then dMinY = dY

                '            If oFileDatas.ContainsKey(dY) Then
                '                If oFileDatas(dY).ContainsKey(dX) Then
                '                    Dim dNewZ As Decimal = (oFileDatas(dY)(dX) + dZ) / 2
                '                    Call oFileDatas(dY).Add(dX, dNewZ)
                '                Else
                '                    Call oFileDatas(dY).Add(dX, dZ)
                '                End If
                '            Else
                '                Call oFileDatas.Add(dY, New Dictionary(Of Decimal, Decimal))
                '                Call oFileDatas(dY).Add(dX, dZ)
                '            End If
                '        Loop

                '        Select Case Options.System
                '            Case cElevationImportOptions.CoordinateSystemEnum.UTMWGS84
                '                Dim iUTMZone As Integer = Options.Parameters("utmzone")
                '                Dim sUTMBand As String = Options.Parameters("utmband")
                '                oCoordinate = New cCoordinate(dMinX, dMinY, sUTMBand, iUTMZone, 0D)
                '            Case cElevationImportOptions.CoordinateSystemEnum.WGS84
                '                oCoordinate = New cCoordinate(dMinX, dMinY, 0)
                '        End Select

                '        If iSystem = cSurface.CoordinateSystemEnum.WGS84 Then
                '            'proietto i dati...
                '            Call pConvertToUTM()
                '        End If
                '        bResult = True
                '    Catch ex As Exception
                '        Call MsgBox("Errore durante l'importazione dei dati altimetrici: " & ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Attenzione:")
                '        bResult = False
                '    End Try
                '    If "" & sName = "" Then sName = Path.GetFileName(Filename)
                '    Call oImagesCaches.Clear()
                '    bChanged = True
                '    Call oSurvey.RaiseOnProgressEvent("elevation.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend1"), 0)
                '    RaiseEvent OnChange(Me)
                Case ElevationDataTypeEnum.ArcASCIIGrid
                    'file ArcASCIIGrid...
                    Call oSurvey.RaiseOnProgressEvent("elevation.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
                    Try
                        Dim sNoDataValue As Single
                        Dim sSeparators As Char() = {" ", vbTab}
                        Dim oSr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Filename)
                        Dim iCurrentRow As Integer = 0
                        Dim iCurrentColumn As Integer = 0
                        Do Until oSr.EndOfStream
                            Dim sLine As String = oSr.ReadLine.Trim
                            If sLine <> "" Then
                                'If sSeparator = "" Then sSeparator = pGetFileSeparator(sLine)
                                If Char.IsDigit(sLine.Chars(0)) Or sLine.Chars(0) = "-" Or sLine.Chars(0) = "+" Then
                                    Call oSurvey.RaiseOnProgressEvent("elevation.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress1"), iCurrentRow / iRows)
                                    Dim sLineData() As String = sLine.Split(sSeparators, StringSplitOptions.RemoveEmptyEntries)
                                    For Each sLineDataItem As String In sLineData
                                        Dim sValue As Single = modNumbers.StringToSingle(sLineDataItem)
                                        If sValue = sNoDataValue Then
                                            oData(iCurrentRow, iCurrentColumn) = NoDataValue
                                        Else
                                            oData(iCurrentRow, iCurrentColumn) = sValue
                                        End If
                                        iCurrentColumn += 1
                                    Next
                                    iCurrentColumn = 0
                                    iCurrentRow += 1
                                Else
                                    Dim oRowData() As Object = pGetLinePartFromASCLine(sLine, sSeparators)
                                    Dim sXMeters As Decimal
                                    Dim sYMeters As Decimal
                                    Dim bXCentered As Boolean
                                    Dim bYCentered As Boolean
                                    Select Case oRowData(0).tolower
                                        Case "ncols"
                                            iColumns = oRowData(1)
                                        Case "nrows"
                                            iRows = oRowData(1)
                                        Case "xllcorner"
                                            sXMeters = oRowData(1)
                                        Case "yllcorner"
                                            sYMeters = oRowData(1)
                                        Case "xllcenter"
                                            bXCentered = True
                                            sXMeters = oRowData(1)
                                        Case "yllcenter"
                                            bYCentered = True
                                            sYMeters = oRowData(1)
                                        Case "cellsize"
                                            Select Case Options.System
                                                Case cElevationImportOptions.CoordinateSystemEnum.UTMWGS84
                                                    'meters...ok
                                                    iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
                                                    sXSize = oRowData(1)
                                                    sYSize = sXSize
                                                Case cElevationImportOptions.CoordinateSystemEnum.WGS84
                                                    'ops...this is an angle?
                                                    iSystem = cSurface.CoordinateSystemEnum.WGS84
                                                    sXSize = oRowData(1)
                                                    sYSize = sXSize
                                            End Select
                                        Case "nodata_value"
                                            sNoDataValue = oRowData(1)
                                    End Select
                                    If sXMeters <> 0 And sYMeters <> 0 Then
                                        Select Case Options.System
                                            Case cElevationImportOptions.CoordinateSystemEnum.UTMWGS84
                                                Dim iUTMZone As Integer = Options.Parameters("utmzone")
                                                Dim sUTMBand As String = Options.Parameters("utmband")
                                                If bXCentered Then sXMeters -= sXSize / 2   'always subtract? 
                                                If bYCentered Then sYMeters -= sYSize / 2
                                                oCoordinate = New cCoordinate(sXMeters, sYMeters, sUTMBand, iUTMZone, 0D)
                                            Case cElevationImportOptions.CoordinateSystemEnum.WGS84
                                                If bXCentered Then sXMeters -= sXSize / 2   'always subtract? 
                                                If bYCentered Then sYMeters -= sYSize / 2
                                                oCoordinate = New cCoordinate(sYMeters, sXMeters, 0)
                                        End Select
                                    End If
                                    If iRows <> 0 And iColumns <> 0 Then
                                        Dim oNewData(iRows - 1, iColumns - 1) As Single
                                        oData = oNewData
                                    End If
                                End If
                            End If
                        Loop
                        If iSystem = cSurface.CoordinateSystemEnum.WGS84 Then
                            'proietto i dati...
                            Call pConvertToUTM()
                        End If
                        bResult = True
                    Catch ex As Exception
                        Call MsgBox("Errore durante l'importazione dei dati altimetrici: " & ex.Message, MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Attenzione:")
                        bResult = False
                    End Try
                    If "" & sName = "" Then sName = Path.GetFileName(Filename)
                    Call pImagesClear()
                    bChanged = True
                    Call oSurvey.RaiseOnProgressEvent("elevation.import", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend1"), 0)
                    RaiseEvent OnChange(Me)
            End Select
            Return bResult
        End Function

        Private Sub pConvertToUTM()
            Call oSurvey.RaiseOnProgressEvent("elevation.import.converttoutm", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, modMain.GetLocalizedString("surface.progressbegin2"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
            Dim dStep As Decimal = 5

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
                    'Call oMatrix.Scale(1 / dStep, -1 / dStep, MatrixOrder.Append)
                    Call oPath.Transform(oMatrix)
                End Using
                'Dim dMeridianConvergence = modUTM.GetMeridianConvergence(oCoordinate)
                Using oImage As Bitmap = GetImage(iColumns, iRows)
                    Dim oNewRect As Rectangle = Rectangle.Truncate(oPath.GetBounds)
                    Dim iNewColumns As Integer = oNewRect.Width
                    Dim iNewRows As Integer = oNewRect.Height
                    Dim oNewImage As Bitmap = New Bitmap(iNewColumns, iNewRows)
                    Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                        Call oGraphics.Clear(Color.White)
                        oGraphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                        oGraphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

                        Using oMatrix = New Matrix
                            Call oMatrix.Translate(-oNewRect.X, -oNewRect.Y, MatrixOrder.Append)
                            Call oPath.Transform(oMatrix)
                        End Using
                        oPoints = {oPath.PathPoints(0), oPath.PathPoints(1), oPath.PathPoints(3)}
                        Call oGraphics.DrawImage(oImage.Clone, oPoints)

                        Dim oNewData(iNewRows - 1, iNewColumns - 1) As Single
                        For iRow = 0 To iNewRows - 1
                            If iRow Mod 10 = 0 Then Call oSurvey.RaiseOnProgressEvent("elevation.import.converttoutm", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("surface.progress2"), iRow / iNewRows, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageLoad)
                            For iCol = 0 To iNewColumns - 1
                                oNewData(iRow, iCol) = oRange.Height - (oRange.Height - oRange.Width) * oNewImage.GetPixel(iCol, iRow).R / 255
                            Next
                        Next
                        iColumns = iNewColumns
                        iRows = iNewRows
                        oData = oNewData

                        Dim oDestRect As RectangleF = oPath.GetBounds
                        Dim dDX As Decimal = oPath.PathPoints(3).X - oDestRect.Left
                        Dim dDY As Decimal = oPath.PathPoints(3).Y - oDestRect.Bottom
                        oCoordinate = New cCoordinate(oBLUTM.East - dDX * dStep, oBLUTM.North - dDY * dStep, oBLUTM.Band, oBLUTM.Zone, 0D)
                        iSystem = cSurface.CoordinateSystemEnum.UTMWGS84
                        sXSize = dStep
                        sYSize = dStep
                    End Using
                End Using
            End Using

            Call oSurvey.RaiseOnProgressEvent("elevation.import.converttoutm", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("surface.progressend2"), 1)
        End Sub

        Public Enum GetCoordinateCornerEnum
            TopLeft = 0
            TopRight = 1
            BottomLeft = 2
            BottomRight = 3
        End Enum

        Public Function GetCoordinate(Corner As GetCoordinateCornerEnum) As cCoordinate
            Dim dRows As Decimal = iRows
            Dim dColumns As Decimal = iColumns
            Select Case iSystem
                Case cSurface.CoordinateSystemEnum.WGS84
                    Select Case Corner
                        Case GetCoordinateCornerEnum.TopLeft
                            Return New cCoordinate(oCoordinate.GetLatitude + dRows * sYSize, oCoordinate.GetLongitude, 0)
                        Case GetCoordinateCornerEnum.TopRight
                            Return New cCoordinate(oCoordinate.GetLatitude + dRows * sYSize, oCoordinate.GetLongitude + dColumns * sXSize, 0)
                        Case GetCoordinateCornerEnum.BottomLeft
                            Return New cCoordinate(oCoordinate)
                        Case GetCoordinateCornerEnum.BottomRight
                            Return New cCoordinate(oCoordinate.GetLatitude, oCoordinate.GetLongitude + dColumns * sXSize, 0)
                    End Select
                Case cSurface.CoordinateSystemEnum.UTMWGS84
                    Select Case Corner
                        Case GetCoordinateCornerEnum.BottomLeft
                            Return New cCoordinate(oCoordinate)
                        Case GetCoordinateCornerEnum.BottomRight
                            Dim oTL As modUTM.UTM = New modUTM.UTM(oCoordinate)
                            oTL.East = oTL.East + dColumns * sXSize
                            Return New cCoordinate(oTL.East, oTL.North, oTL.Band, oTL.Zone, 0)
                        Case GetCoordinateCornerEnum.TopLeft
                            Dim oTL As modUTM.UTM = New modUTM.UTM(oCoordinate)
                            oTL.North = oTL.North + dRows * sYSize
                            Return New cCoordinate(oTL.East, oTL.North, oTL.Band, oTL.Zone, 0)
                        Case GetCoordinateCornerEnum.TopRight
                            Dim oTL As modUTM.UTM = New modUTM.UTM(oCoordinate)
                            oTL.East = oTL.East + dColumns * sXSize
                            oTL.North = oTL.North + dRows * sYSize
                            Return New cCoordinate(oTL.East, oTL.North, oTL.Band, oTL.Zone, 0)
                    End Select
            End Select
        End Function

        Public Function GetHeightRange() As SizeF
            If bChanged Then
                Try
                    Dim sMax As Single = Single.MinValue
                    Dim sMin As Single = Single.MaxValue
                    For iRow As Integer = 0 To iRows - 1
                        For icolumn As Integer = 0 To iColumns - 1
                            Dim sElevation As Single = oData(iRow, icolumn)
                            If sElevation <> NoDataValue Then
                                If sElevation > sMax Then sMax = sElevation
                                If sElevation < sMin Then sMin = sElevation
                            End If
                        Next
                    Next
                    oRange = New SizeF(sMin, sMax)
                Catch
                    oRange = New SizeF(0, 0)
                End Try
                bChanged = False
            End If
            Return oRange
        End Function

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

        'Friend Function GetTrigpoint() As cTrigPoint
        '    If oSurvey.TrigPoints.Contains(cSurveyPC.cSurvey.Calculate.cCalculate.SurfaceElevationTrigpointName1) Then
        '        Return oSurvey.TrigPoints(cSurveyPC.cSurvey.Calculate.cCalculate.SurfaceElevationTrigpointName1)
        '    Else
        '        Return Nothing
        '    End If
        'End Function

        'Friend Function GetTLTrigpoint() As cTrigPoint
        '    Return GetTrigpoint()
        'End Function

        'Friend Function GetBRTrigpoint() As cTrigPoint
        '    If oSurvey.TrigPoints.Contains(cSurveyPC.cSurvey.Calculate.cCalculate.SurfaceElevationTrigpointName2) Then
        '        Return oSurvey.TrigPoints(cSurveyPC.cSurvey.Calculate.cCalculate.SurfaceElevationTrigpointName2)
        '    Else
        '        Return Nothing
        '    End If
        'End Function

        Friend Function GetSurfaceDistance(Trigpoint As cTrigPoint) As Decimal
            Dim oBaseTrigpoint As cTrigPoint = oSurvey.TrigPoints.GetGPSBaseReferencePoint
            Dim dAltitude As Decimal = oBaseTrigpoint.Coordinate.GetAltitude
            Dim dElevation As Decimal = GetElevation(Trigpoint)
            Return dAltitude - dElevation
        End Function

        Friend Function GetElevation(Trigpoint As cTrigPoint) As Single
            Return GetElevation(Trigpoint.Data.X, Trigpoint.Data.Y)
        End Function

        Friend Function GetElevation(Point As PointF) As Single
            Return GetElevation(Point.X, Point.Y)
        End Function

        Friend Function GetElevation(X As Single, Y As Single) As Single
            Try
                Dim oTrigpoint As PointF = GetTLPoint()
                If oTrigpoint.IsEmpty Then
                    Return NoDataValue
                Else
                    'attenzione...dovrei restituire il valore ponderato in funzione della posizione del caposaldi e dei 4 punti altimetrici più vicini...
                    'per ora mi limito al punto altimetrico più vicino ma non è preciso...
                    'rivisto...aggiunto il valore ponderato...
                    Dim sBaseX As Decimal = oTrigpoint.X
                    Dim sBasey As Decimal = oTrigpoint.Y
                    Dim sDiffX As Decimal = X - sBaseX
                    Dim sDiffY As Decimal = Y - sBasey

                    Dim sRow As Decimal = sDiffY / sYSize
                    Dim sColumn As Decimal = sDiffX / sXSize
                    Dim iRow As Integer = Math.Truncate(sRow)
                    Dim iColumn As Integer = Math.Truncate(sColumn)
                    If (sRow >= 0 And sRow + 1 < oData.GetLength(0)) And (sColumn >= 0 And sColumn + 1 < oData.GetLength(1)) Then
                        If sRow = iRow And sColumn = iColumn Then
                            'il punto corrisponde ad un dato esatto
                            Return oData(iRow, iColumn)
                        Else
                            Dim oAlts As Single() = {oData(iRow, iColumn), oData(iRow, iColumn + 1), oData(iRow + 1, iColumn), oData(iRow + 1, iColumn + 1)}
                            Return modPaint.GetAltitude(oAlts, sXSize, sYSize, New PointF(sXSize * (sRow - iRow), sYSize * (sColumn - iColumn)))
                        End If
                    Else
                        Return NoDataValue
                    End If
                End If
            Catch ex As Exception
                Return NoDataValue
            End Try
        End Function

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

        Public ReadOnly Property Rows As Integer
            Get
                Return iRows
            End Get
        End Property

        Public ReadOnly Property Width As Single
            Get
                Return iColumns * sXSize
            End Get
        End Property

        Public ReadOnly Property Height As Single
            Get
                Return iRows * sYSize
            End Get
        End Property

        Public ReadOnly Property Columns As Integer
            Get
                Return iColumns
            End Get
        End Property

        Public ReadOnly Property Coordinate As cCoordinate
            Get
                Return oCoordinate
            End Get
        End Property

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("elevations")
            Call oXmlItem.SetAttribute("name", sName)
            Call oXmlItem.SetAttribute("id", sID)
            Call oCoordinate.SaveTo(File, Document, oXmlItem)
            Call oXmlItem.SetAttribute("rows", iRows)
            Call oXmlItem.SetAttribute("columns", iColumns)
            If iSystem <> cSurface.CoordinateSystemEnum.UTMWGS84 Then oXmlItem.SetAttribute("system", iSystem.ToString("D"))
            Call oXmlItem.SetAttribute("xsize", modNumbers.NumberToString(sXSize, "0.000000"))
            Call oXmlItem.SetAttribute("ysize", modNumbers.NumberToString(sYSize, "0.000000"))
            If Not (File.Options And cFile.FileOptionsEnum.DontSaveBinary) = cFile.FileOptionsEnum.DontSaveBinary Then
                Select Case File.FileFormat
                    Case cFile.FileFormatEnum.CSX
                        Using oMs As IO.MemoryStream = New IO.MemoryStream
                            Dim oFormatter As Binary.BinaryFormatter = New Binary.BinaryFormatter()
                            Call oFormatter.Serialize(oMs, oData)
                            Call oXmlItem.SetAttribute("data", Convert.ToBase64String(oMs.ToArray()))
                        End Using
                    Case cFile.FileFormatEnum.CSZ
                        Dim sDataPath As String = "_data\surface\" & sID & ".dat"
                        Dim oDataStorage As Storage.cStorageItemFile = File.Data.AddFile(sDataPath)
                        Dim oFormatter As Binary.BinaryFormatter = New Binary.BinaryFormatter()
                        Call oFormatter.Serialize(oDataStorage.Stream, oData)
                        Call oXmlItem.SetAttribute("data", sDataPath)
                End Select
            End If
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Private Sub oCoordinate_OnChange(Sender As cCoordinate) Handles oCoordinate.OnChange
            RaiseEvent OnChange(Me)
        End Sub
    End Class
End Namespace