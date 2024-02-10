Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Helper.Editor
Imports DevExpress.Office.Drawing
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cCalculate
        Public Class cCalculateDataItemError
            Inherits cCalculateDataItem

            Friend Sub New(ByVal [Date] As DateTime, ErrorMessage As String)
                MyBase.New([Date], CalculateDataItemTypeEnum.Error, ErrorMessage)
            End Sub

            Public ReadOnly Property ErrorMessage As String
                Get
                    Return MyBase.Value
                End Get
            End Property
        End Class

        Public Class cCalculateDataItem
            Public Enum CalculateDataItemTypeEnum
                Generic = 0
                RingAvarageError = 1
                RingDetails = 2
                OutputCoordinateSystem = 3
                MeridianConvergence = 4
                GeoMagDeclinationData = 5
                'DepthDetails = 6
                [Error] = 9
                [Warning] = 10
            End Enum

            Private oDate As DateTime
            Private iType As CalculateDataItemTypeEnum
            Private oValue As Object
            Private sText As String

            Public ReadOnly Property [Date] As DateTime
                Get
                    Return oDate
                End Get
            End Property

            Public ReadOnly Property Type As CalculateDataItemTypeEnum
                Get
                    Return iType
                End Get
            End Property

            Public ReadOnly Property Value As Object
                Get
                    Return oValue
                End Get
            End Property

            Public ReadOnly Property Text As String
                Get
                    Return sText
                End Get
            End Property

            Friend Sub New(ByVal [Date] As DateTime, ByVal Type As CalculateDataItemTypeEnum, ByVal Value As Object)
                oDate = [Date]
                iType = Type
                oValue = Value
            End Sub

            Friend Sub New(ByVal [Date] As DateTime, ByVal Type As CalculateDataItemTypeEnum, ByVal Text As String, Value As Object)
                oDate = [Date]
                iType = Type
                sText = Text
                oValue = Value
            End Sub
        End Class

        Private oSurvey As cSurvey
        Public Const CalculateVersion As Integer = 3

        Private oTPs As cTrigPoints

        Private oRs As cSurveyPC.cSurvey.Calculate.cRings
        Private oGMD As cSurveyPC.cSurvey.Calculate.cGeoMagDeclinationData
        Private oCalculateData As List(Of cCalculateDataItem)

        Private oSpeleometrics As Calculate.Plot.cSpeleometrics

        Friend Event OnArrangePriorityComplete(ByVal Sender As cCalculate, Args As EventArgs)
        Friend Event OnCalculateComplete(ByVal Sender As cCalculate, Args As EventArgs)

        Public Enum InvalidateEnum
            None = 0
            OnlyPlanSplay = &H1
            OnlyProfileSplay = &H2
            OnlySplay = &H3
            PartialCalculate = &H7
            FullCalculate = &HF
        End Enum

        Private bLoadedFromFile As Boolean

        Friend ReadOnly Property LoadedFromFile As Boolean
            Get
                Return bLoadedFromFile
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            oTPs = New cTrigPoints(oSurvey, Item.Item("ts"))
            'oSGs = New cSegments(oSurvey, Item.Item("sgs"))
            'oSGs = New cSegments(oSurvey)
            oRs = New cRings(oSurvey, Item.Item("rngs"))
            oGMD = New cGeoMagDeclinationData(oSurvey, Item.Item("mdd"))
            oCalculateData = New List(Of cCalculateDataItem)
            oSpeleometrics = New Plot.cSpeleometrics(oSurvey, Item.Item("sms"))

            bLoadedFromFile = True
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCalculate As XmlElement = Document.CreateElement("calculate")
            Call oTPs.SaveTo(File, Document, oXmlCalculate)
            'Call oSGs.SaveTo(File, Document, oXmlCalculate)
            Call oRs.SaveTo(File, Document, oXmlCalculate)
            Call oGMD.SaveTo(File, Document, oXmlCalculate)
            Call oSpeleometrics.SaveTo(File, Document, oXmlCalculate)
            Call Parent.AppendChild(oXmlCalculate)
            Return oXmlCalculate
        End Function

        Public ReadOnly Property Rings As cSurveyPC.cSurvey.Calculate.cRings
            Get
                Return oRs
            End Get
        End Property

        Public ReadOnly Property TrigPoints As cSurveyPC.cSurvey.Calculate.cTrigPoints
            Get
                Return oTPs
            End Get
        End Property

        Public ReadOnly Property GeoMagDeclinationData As cSurveyPC.cSurvey.Calculate.cGeoMagDeclinationData
            Get
                Return oGMD
            End Get
        End Property

        Friend Sub Clear()
            Call oRs.Clear()
            Call oTPs.Clear()
            'Call oSGs.Clear()
            Call oCalculateData.Clear()
        End Sub

        Public ReadOnly Property Speleometrics As Calculate.Plot.cSpeleometrics
            Get
                Return oSpeleometrics
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oTPs = New cTrigPoints(oSurvey)
            'oSGs = New cSegments(oSurvey)
            oRs = New cSurveyPC.cSurvey.Calculate.cRings(oSurvey)
            oGMD = New cSurveyPC.cSurvey.Calculate.cGeoMagDeclinationData(oSurvey)
            oCalculateData = New List(Of cCalculateDataItem)
            oSpeleometrics = New Calculate.Plot.cSpeleometrics(oSurvey)

            bLoadedFromFile = False
        End Sub

        'Private Function oSegmentComparer(ByVal Segment1 As cSegment, ByVal segment2 As cSegment) As Integer
        '    If Segment1.[From] < segment2.[From] Then Return -1
        '    If Segment1.[From] = segment2.[From] Then Return 0
        '    If Segment1.[From] > segment2.[From] Then Return 1
        'End Function

        '------------------------------------------------------------------------------------------------------------------
        'conservare per cancellare i capisaldi fittizzi che erano necessari nella versioni precedenti...
        Friend Const SurfaceElevationTrigpointName1 As String = "_elevation1"
        Friend Const SurfaceElevationTrigpointName2 As String = "_elevation2"

        Friend Const OrthoPhotoTrigpointName1 As String = "_orthophoto1"
        Friend Const OrthoPhotoTrigpointName2 As String = "_orthophoto2"

        Private Sub pOrthoPhotoTrigpointRemove()
            If oSurvey.TrigPoints.Contains(OrthoPhotoTrigpointName1) Then
                Call oSurvey.TrigPoints.Remove(OrthoPhotoTrigpointName1)
            End If
            If oSurvey.TrigPoints.Contains(OrthoPhotoTrigpointName2) Then
                Call oSurvey.TrigPoints.Remove(OrthoPhotoTrigpointName2)
            End If
        End Sub

        Private Sub pSurfaceElevationTrigpointRemove()
            If oSurvey.TrigPoints.Contains(SurfaceElevationTrigpointName1) Then
                Call oSurvey.TrigPoints.Remove(SurfaceElevationTrigpointName1)
            End If
            If oSurvey.TrigPoints.Contains(SurfaceElevationTrigpointName2) Then
                Call oSurvey.TrigPoints.Remove(SurfaceElevationTrigpointName2)
            End If
        End Sub
        '------------------------------------------------------------------------------------------------------------------

        'Private Sub pOrthoPhotoTrigpointCreateUpdate()
        '    If oSurvey.Properties.GPS.Enabled AndAlso oSurvey.Surface.OrthoPhotos.ShowIn3D Then
        '        Dim oOrthoPhoto As Surface.cOrthoPhoto = oSurvey.Surface.OrthoPhotos.Default
        '        Call pOrthoPhotoTrigpointRemove()
        '        Dim oTrigpoint As cSurveyPC.cSurvey.cTrigPoint
        '        oTrigpoint = oSurvey.TrigPoints.Add(OrthoPhotoTrigpointName1, 0, 0, 0, True)
        '        oTrigpoint.Entrance = cSurveyPC.cSurvey.cTrigPoint.EntranceTypeEnum.OutSide
        '        Call oTrigpoint.Coordinate.CopyFrom(oOrthoPhoto.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft))
        '        oTrigpoint.Coordinate.Altitude = 0

        '        oTrigpoint = oSurvey.TrigPoints.Add(OrthoPhotoTrigpointName2, 0, 0, 0, True)
        '        oTrigpoint.Entrance = cSurveyPC.cSurvey.cTrigPoint.EntranceTypeEnum.OutSide
        '        Call oTrigpoint.Coordinate.CopyFrom(oOrthoPhoto.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomRight))
        '        oTrigpoint.Coordinate.Altitude = 0
        '    Else
        '        Call pOrthoPhotoTrigpointRemove()
        '    End If
        'End Sub

        'Private Sub pSurfaceElevationTrigpointCreateUpdate()
        '    If oSurvey.Properties.GPS.Enabled AndAlso oSurvey.Surface.Elevations.ShowIn3D Then
        '        Dim oElevation As Surface.cElevation = oSurvey.Surface.Elevations.Default
        '        Call pSurfaceElevationTrigpointRemove()
        '        Dim oTrigpoint As cSurveyPC.cSurvey.cTrigPoint
        '        oTrigpoint = oSurvey.TrigPoints.Add(SurfaceElevationTrigpointName1, 0, 0, 0, True)
        '        oTrigpoint.Entrance = cSurveyPC.cSurvey.cTrigPoint.EntranceTypeEnum.OutSide
        '        Call oTrigpoint.Coordinate.CopyFrom(oElevation.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft))
        '        oTrigpoint.Coordinate.Altitude = oElevation.Data(0, 0)

        '        oTrigpoint = oSurvey.TrigPoints.Add(SurfaceElevationTrigpointName2, 0, 0, 0, True)
        '        oTrigpoint.Entrance = cSurveyPC.cSurvey.cTrigPoint.EntranceTypeEnum.OutSide
        '        Call oTrigpoint.Coordinate.CopyFrom(oElevation.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomRight))
        '        oTrigpoint.Coordinate.Altitude = oElevation.Data(oElevation.Rows - 1, oElevation.Columns - 1)
        '    Else
        '        Call pSurfaceElevationTrigpointRemove()
        '    End If
        'End Sub

        Private Sub pCalculateGeographics()
            Dim oGeoRef As cSurveyPC.cSurvey.cTrigPoint = oSurvey.TrigPoints.GetGPSBaseReferencePoint
            If Not oGeoRef Is Nothing Then
                If oTPs.Contains(oGeoRef.Name) Then
                    If Not oGeoRef.Coordinate.IsEmpty Then
                        Dim sFrom As String = oGeoRef.Name
                        Dim dlat As Decimal = oGeoRef.Coordinate.GetLatitude
                        Dim dLong As Decimal = oGeoRef.Coordinate.GetLongitude
                        Dim dAlt As Decimal = oGeoRef.Coordinate.GetAltitude
                        Threading.Tasks.Parallel.ForEach(Of cTrigPoint)(oTPs, Sub(oTrigpoint)
                                                                                  Dim dNewlat As Decimal
                                                                                  Dim dNewLong As Decimal
                                                                                  Dim dNewAlt As Decimal
                                                                                  Call modExport.CalculateCoordinatesFromTrigpoint(oSurvey, dlat, dLong, dAlt, sFrom, oTrigpoint.Name, dNewlat, dNewLong, dNewAlt)
                                                                                  Call oTrigpoint.SetCoordinate(dNewlat, dNewLong, dNewAlt)
                                                                              End Sub)
                    End If
                End If
            End If
        End Sub

        Friend Function CalculateDataFromDesigns(TrigPointsToElaborate As List(Of String), Optional ThreeDModelMode As cProperties.ThreeDModelModeEnum? = Nothing) As Boolean
            Dim iThreeDModelMode As cProperties.ThreeDModelModeEnum = If(ThreeDModelMode.HasValue, ThreeDModelMode.Value, oSurvey.Properties.ThreeDModelMode)
            If bDataFromDesignsInvalidated OrElse iLastThreeDModelMode <> iThreeDModelMode Then
                Dim iTrigPointsCount As Integer = TrigPointsToElaborate.Count
                Dim iSegmentsCount As Integer = oSurvey.Segments.GetValidSegments.Count
                If iTrigPointsCount > 1 AndAlso iSegmentsCount > 0 Then
                    Dim sVThreshold As Single = 80
                    '---------------------------------------------------------------------------------------------------------
                    If iThreeDModelMode = cProperties.ThreeDModelModeEnum.Oversample Then
                        'calcolo i subdata per i segmenti...
                        Dim sMinDistance As Single = oSurvey.Properties.ThreeDOversamplingFactor   'minimun details in meters...
                        Dim sFrom As String
                        Dim sTo As String

                        Dim oPlanOptions As cOptionsDesign = oSurvey.Options("_design.plan")
                        Dim oProfileOptions As cOptionsDesign = oSurvey.Options("_design.profile")

                        Using oPlanCache As modDesignLRUD.cLRFromDesignCache = New modDesignLRUD.cLRFromDesignCache(oSurvey, oSurvey.Plan, oPlanOptions)
                            Using oProfileCache As modDesignLRUD.cUDFromDesignCache = New modDesignLRUD.cUDFromDesignCache(oSurvey, oSurvey.Profile, oProfileOptions)

                                Call oSurvey.RaiseOnProgressEvent("3dsubdata", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("calculate.progressbegin4"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageImport Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                                Dim iSegmentIndex As Integer = 0
                                Dim iSegmentCount As Integer = oSurvey.Segments.Count
                                For Each oSegment As cSegment In oSurvey.Segments
                                    Call oSegment.Data.SubDatas.Clear()

                                    iSegmentIndex += 1
                                    If iSegmentIndex Mod 20 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dsubdata", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("calculate.progress4"), iSegmentIndex / iSegmentCount)
                                    If oSegment.IsValid And Not oSegment.Splay Then
                                        If oSegment.Surface Then
                                            'per superficie e splay carico la battute senza subdata e senza LRUD...
                                            sFrom = oSegment.Data.Data.From
                                            sTo = oSegment.Data.Data.To
                                            Call oSegment.Data.SubDatas.Add(sFrom, sTo, oSegment.Data.Data.Distance)
                                            If Not TrigPointsToElaborate.Contains(sFrom) Then Call TrigPointsToElaborate.Add(sFrom)
                                            If Not TrigPointsToElaborate.Contains(sTo) Then Call TrigPointsToElaborate.Add(sTo)
                                        Else
                                            Dim oPlanFromPoint As PointF = oSegment.Data.Plan.FromPoint
                                            Dim oPlanToPoint As PointF = oSegment.Data.Plan.ToPoint
                                            Dim oProfileFromPoint As PointF = oSegment.Data.Profile.FromPoint
                                            Dim oProfileToPoint As PointF = oSegment.Data.Profile.ToPoint

                                            Dim oLastPlanSubPoint As PointF = oPlanFromPoint
                                            Dim oLastProfileSubPoint As PointF = oProfileFromPoint
                                            Dim oPlanSubPoint As PointF = oPlanToPoint
                                            Dim oProfileSubPoint As PointF = oProfileToPoint

                                            sFrom = oSegment.Data.Data.From
                                            sTo = oSegment.Data.Data.To
                                            If Not TrigPointsToElaborate.Contains(sFrom) Then Call TrigPointsToElaborate.Add(sFrom)
                                            If Not TrigPointsToElaborate.Contains(sTo) Then Call TrigPointsToElaborate.Add(sTo)

                                            Dim dFromBearingLeft As Decimal = oSegment.Data.Plan.FromBearingLeft
                                            Dim dFromBearingRight As Decimal = oSegment.Data.Plan.FromBearingRight
                                            Dim dToBearingLeft As Decimal = oSegment.Data.Plan.ToBearingLeft
                                            Dim dToBearingRight As Decimal = oSegment.Data.Plan.ToBearingRight

                                            Dim oSegmentSubData As cSurveyPC.cSurvey.Calculate.Plot.cSubData = oSegment.Data.SubDatas.Add(sFrom, sTo, oSegment.Data.Data.Distance, dFromBearingLeft, dFromBearingRight, dToBearingLeft, dToBearingRight)

                                            Dim oFromLR As SizeF = modDesignLRUD.GetLRFromDesign(oSurvey, oPlanCache, oSegment, oSegmentSubData.Plan, oLastPlanSubPoint, GetDesignStationEnum.From)
                                            Dim oToLR As SizeF = modDesignLRUD.GetLRFromDesign(oSurvey, oPlanCache, oSegment, oSegmentSubData.Plan, oPlanSubPoint, GetDesignStationEnum.To)
                                            Dim oFromUD As SizeF = modDesignLRUD.GetUDFromDesign(oSurvey, oProfileCache, oSegment, oSegmentSubData.Profile, oLastProfileSubPoint, GetDesignStationEnum.From)
                                            Dim oToUD As SizeF = modDesignLRUD.GetUDFromDesign(oSurvey, oProfileCache, oSegment, oSegmentSubData.Profile, oProfileSubPoint, GetDesignStationEnum.To)
                                            Call oSegmentSubData.SetLRUD(oFromLR.Width, oFromLR.Height, oFromUD.Width, oFromUD.Height, oToLR.Width, oToLR.Height, oToUD.Width, oToUD.Height)

                                            'uniformo i dati per evitare glitch...
                                            Call oSegment.Data.UniformSubDataLRUD(oSurvey.Properties.ThreeDNormalizationFactor)
                                        End If
                                    End If
                                Next
                            End Using
                        End Using
                        Call oSurvey.RaiseOnProgressEvent("3dsubdata", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
                    ElseIf iThreeDModelMode = cProperties.ThreeDModelModeEnum.AdvancedOversample Then
                        'calcolo i subdata per i segmenti...
                        Dim sMinDistance As Single = oSurvey.Properties.ThreeDOversamplingFactor   'indica il dettaglio minimo (in metri)...ora fisso, poi sarà regolabile
                        Dim sStep As Single
                        'Dim sFactor As Single
                        Dim sDistance As Single
                        Dim sTotDistance As Single
                        Dim sFrom As String
                        Dim sTo As String
                        Dim iSubIndex As Integer
                        Dim iSubCount As Integer
                        Dim sLastStation As String

                        Dim oPlanOptions As cOptionsDesign = oSurvey.Options("_design.plan")
                        Dim oProfileOptions As cOptionsDesign = oSurvey.Options("_design.profile")

                        Using oPlanCache As modDesignLRUD.cLRFromDesignCache = New modDesignLRUD.cLRFromDesignCache(oSurvey, oSurvey.Plan, oPlanOptions)
                            Using oProfileCache As modDesignLRUD.cUDFromDesignCache = New modDesignLRUD.cUDFromDesignCache(oSurvey, oSurvey.Profile, oProfileOptions)

                                Call oSurvey.RaiseOnProgressEvent("3dsubdata", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("calculate.progressbegin4"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageImport Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowProgressWindow)

                                Dim iSegmentIndex As Integer = 0
                                Dim iSegmentCount As Integer = oSurvey.Segments.Count
                                For Each oSegment As cSegment In oSurvey.Segments
                                    Call oSegment.Data.SubDatas.Clear()

                                    iSegmentIndex += 1
                                    If iSegmentIndex Mod 20 = 0 Then Call oSurvey.RaiseOnProgressEvent("3dsubdata", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("calculate.progress4"), iSegmentIndex / iSegmentCount)
                                    If oSegment.IsValid AndAlso Not oSegment.Splay Then
                                        If oSegment.Surface Then
                                            'for surface and splay I add shot as is
                                            sFrom = oSegment.Data.Data.From
                                            sTo = oSegment.Data.Data.To
                                            Call oSegment.Data.SubDatas.Add(sFrom, sTo, oSegment.Data.Data.Distance)
                                            If Not TrigPointsToElaborate.Contains(sFrom) Then Call TrigPointsToElaborate.Add(sFrom)
                                            If Not TrigPointsToElaborate.Contains(sTo) Then Call TrigPointsToElaborate.Add(sTo)
                                        Else
                                            Dim bSubData As Boolean
                                            Dim oSession As cSession = oSegment.GetSession
                                            If oSession Is Nothing Then
                                                bSubData = False
                                            Else
                                                bSubData = oSession.DataFormat = cSegment.DataFormatEnum.Normal
                                            End If

                                            sTotDistance = oSegment.Data.Data.Distance
                                            If sTotDistance <= sMinDistance OrElse Not bSubData Then
                                                'per le battute con lunghezza 0 faccio uguale...non possono essere divise in subdata...
                                                Dim oPlanFromPoint As PointF = oSegment.Data.Plan.FromPoint
                                                Dim oPlanToPoint As PointF = oSegment.Data.Plan.ToPoint
                                                Dim oProfileFromPoint As PointF = oSegment.Data.Profile.FromPoint
                                                Dim oProfileToPoint As PointF = oSegment.Data.Profile.ToPoint
                                                Dim oLastPlanSubPoint As PointF = oPlanFromPoint
                                                Dim oLastProfileSubPoint As PointF = oProfileFromPoint
                                                Dim oPlanSubPoint As PointF = oPlanToPoint
                                                Dim oProfileSubPoint As PointF = oProfileToPoint

                                                sFrom = oSegment.Data.Data.From
                                                sTo = oSegment.Data.Data.To
                                                If Not TrigPointsToElaborate.Contains(sFrom) Then Call TrigPointsToElaborate.Add(sFrom)
                                                If Not TrigPointsToElaborate.Contains(sTo) Then Call TrigPointsToElaborate.Add(sTo)

                                                Dim dFromBearingLeft As Decimal = oSegment.Data.Plan.FromBearingLeft
                                                Dim dFromBearingRight As Decimal = oSegment.Data.Plan.FromBearingRight
                                                Dim dToBearingLeft As Decimal = oSegment.Data.Plan.ToBearingLeft
                                                Dim dToBearingRight As Decimal = oSegment.Data.Plan.ToBearingRight

                                                Dim oSegmentSubData As cSurveyPC.cSurvey.Calculate.Plot.cSubData = oSegment.Data.SubDatas.Add(sFrom, sTo, oSegment.Data.Data.Distance, dFromBearingLeft, dFromBearingRight, dToBearingLeft, dToBearingRight)

                                                Dim oFromLR As SizeF = modDesignLRUD.GetLRFromDesign(oSurvey, oPlanCache, oSegment, oSegmentSubData.Plan, oLastPlanSubPoint, GetDesignStationEnum.From)
                                                Dim oToLR As SizeF = modDesignLRUD.GetLRFromDesign(oSurvey, oPlanCache, oSegment, oSegmentSubData.Plan, oPlanSubPoint, GetDesignStationEnum.To)
                                                Dim oFromUD As SizeF = modDesignLRUD.GetUDFromDesign(oSurvey, oProfileCache, oSegment, oSegmentSubData.Profile, oLastProfileSubPoint, GetDesignStationEnum.From)
                                                Dim oToUD As SizeF = modDesignLRUD.GetUDFromDesign(oSurvey, oProfileCache, oSegment, oSegmentSubData.Profile, oProfileSubPoint, GetDesignStationEnum.To)
                                                Call oSegmentSubData.SetLRUD(oFromLR.Width, oFromLR.Height, oFromUD.Width, oFromUD.Height, oToLR.Width, oToLR.Height, oToUD.Width, oToUD.Height)

                                                'uniformo i dati per evitare glitch...
                                                Call oSegment.Data.UniformSubDataLRUD(oSurvey.Properties.ThreeDNormalizationFactor)
                                            Else
                                                Dim oPlanFromPoint As PointF = oSegment.Data.Plan.FromPoint
                                                Dim oPlanToPoint As PointF = oSegment.Data.Plan.ToPoint
                                                Dim oProfileFromPoint As PointF = oSegment.Data.Profile.FromPoint
                                                Dim oProfileToPoint As PointF = oSegment.Data.Profile.ToPoint
                                                Dim oSegmentSubData As cSurveyPC.cSurvey.Calculate.Plot.cSubData
                                                Dim oLastPlanSubPoint As PointF = oPlanFromPoint
                                                Dim oLastProfileSubPoint As PointF = oProfileFromPoint
                                                Dim oPlanSubPoint As PointF
                                                Dim oProfileSubPoint As PointF

                                                sStep = sMinDistance
                                                iSubCount = oSegment.Data.Data.Distance / sStep

                                                sLastStation = ""
                                                sDistance = sStep
                                                For iSubIndex = 1 To iSubCount
                                                    Dim dFromBearingLeft As Decimal
                                                    Dim dFromBearingRight As Decimal
                                                    Dim dToBearingLeft As Decimal
                                                    Dim dToBearingRight As Decimal

                                                    If iSubIndex = 1 Then
                                                        sFrom = oSegment.Data.Data.From
                                                        dFromBearingLeft = oSegment.Data.Plan.FromBearingLeft
                                                        dFromBearingRight = oSegment.Data.Plan.FromBearingRight
                                                    Else
                                                        sFrom = sLastStation
                                                        If oSegment.Data.Data.Reversed Then
                                                            dFromBearingLeft = oSegment.Data.Data.Bearing + 90
                                                            dFromBearingRight = oSegment.Data.Data.Bearing - 90
                                                        Else
                                                            dFromBearingLeft = oSegment.Data.Data.Bearing - 90
                                                            dFromBearingRight = oSegment.Data.Data.Bearing + 90
                                                        End If
                                                    End If
                                                    If iSubIndex = iSubCount Then
                                                        sTo = oSegment.Data.Data.To
                                                        dToBearingLeft = oSegment.Data.Plan.ToBearingLeft
                                                        dToBearingRight = oSegment.Data.Plan.ToBearingRight
                                                    Else
                                                        sTo = oSegment.Data.Data.From & "-" & iSubIndex & "-" & oSegment.Data.Data.To
                                                        If oSegment.Data.Data.Reversed Then
                                                            dToBearingLeft = oSegment.Data.Data.Bearing + 90
                                                            dToBearingRight = oSegment.Data.Data.Bearing - 90
                                                        Else
                                                            dToBearingLeft = oSegment.Data.Data.Bearing - 90
                                                            dToBearingRight = oSegment.Data.Data.Bearing + 90
                                                        End If
                                                    End If
                                                    If Not TrigPointsToElaborate.Contains(sFrom) Then Call TrigPointsToElaborate.Add(sFrom)
                                                    If Not TrigPointsToElaborate.Contains(sTo) Then Call TrigPointsToElaborate.Add(sTo)
                                                    sLastStation = sTo

                                                    oPlanSubPoint = modPaint.PointOnLineByPercentage(oPlanFromPoint, oPlanToPoint, sDistance / sTotDistance)
                                                    oProfileSubPoint = modPaint.PointOnLineByPercentage(oProfileFromPoint, oProfileToPoint, sDistance / sTotDistance)
                                                    oSegmentSubData = oSegment.Data.SubDatas.Add(sFrom, sTo, sStep, oLastPlanSubPoint, oPlanSubPoint, oLastProfileSubPoint, oProfileSubPoint, dFromBearingLeft, dFromBearingRight, dToBearingLeft, dToBearingRight)

                                                    Dim oFromLR As SizeF = modDesignLRUD.GetLRFromDesign(oSurvey, oPlanCache, oSegment, oSegmentSubData.Plan, oLastPlanSubPoint, GetDesignStationEnum.From)
                                                    Dim oToLR As SizeF = modDesignLRUD.GetLRFromDesign(oSurvey, oPlanCache, oSegment, oSegmentSubData.Plan, oPlanSubPoint, GetDesignStationEnum.To)
                                                    Dim oFromUD As SizeF = modDesignLRUD.GetUDFromDesign(oSurvey, oProfileCache, oSegment, oSegmentSubData.Profile, oLastProfileSubPoint, GetDesignStationEnum.From)
                                                    Dim oToUD As SizeF = modDesignLRUD.GetUDFromDesign(oSurvey, oProfileCache, oSegment, oSegmentSubData.Profile, oProfileSubPoint, GetDesignStationEnum.To)
                                                    Call oSegmentSubData.SetLRUD(oFromLR.Width, oFromLR.Height, oFromUD.Width, oFromUD.Height, oToLR.Width, oToLR.Height, oToUD.Width, oToUD.Height)

                                                    oLastPlanSubPoint = oPlanSubPoint
                                                    oLastProfileSubPoint = oProfileSubPoint
                                                    sDistance += sStep
                                                Next
                                                'uniform data preventing glitch...
                                                Call oSegment.Data.UniformSubDataLRUD(oSurvey.Properties.ThreeDNormalizationFactor)
                                            End If
                                        End If
                                    End If
                                Next
                            End Using
                        End Using
                        Call oSurvey.RaiseOnProgressEvent("3dsubdata", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, modMain.GetLocalizedString("calculate.progressend4"), 0)
                    End If
                    bDataFromDesignsInvalidated = False
                    iLastThreeDModelMode = iThreeDModelMode
                    Return True
                Else
                    bDataFromDesignsInvalidated = False
                    iLastThreeDModelMode = iThreeDModelMode
                    Return False
                End If
            Else
                'update the stations lists with subdatas
                If iThreeDModelMode > cProperties.ThreeDModelModeEnum.Simple Then
                    For Each oSegment As cSegment In oSurvey.Segments
                        If oSegment.IsValid AndAlso Not oSegment.Splay Then
                            For Each oSubData As Plot.cSubData In oSegment.Data.SubDatas
                                If Not TrigPointsToElaborate.Contains(oSubData.From) Then Call TrigPointsToElaborate.Add(oSubData.From)
                                If Not TrigPointsToElaborate.Contains(oSubData.To) Then Call TrigPointsToElaborate.Add(oSubData.To)
                            Next
                        End If
                    Next
                End If
                Return True
            End If
        End Function

        Private bDataFromDesignsInvalidated As Boolean
        Private iLastThreeDModelMode As cProperties.ThreeDModelModeEnum

        Friend Sub ResetChanges()
            Call oSurvey.Plan.Plot.ResetChanges()
            Call oSurvey.Profile.Plot.ResetChanges()
        End Sub

        Friend Function Calculate(Optional ByVal PerformWarping As Boolean = True) As cActionResult
            Try
                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate started")

                Call oCalculateData.Clear()

                If oSurvey.Invalidated = InvalidateEnum.OnlyPlanSplay Then
                    Call oSurvey.Plan.Plot.CalculateSplay()
                ElseIf oSurvey.Invalidated = InvalidateEnum.OnlyProfileSplay Then
                    Call oSurvey.Profile.Plot.CalculateSplay()
                ElseIf oSurvey.Invalidated = InvalidateEnum.OnlySplay Then
                    Call oSurvey.Plan.Plot.CalculateSplay()
                    Call oSurvey.Profile.Plot.CalculateSplay()
                Else
                    Call oSurvey.TrigPoints.Rebind()

                    Dim oOrigin As cSurveyPC.cSurvey.cTrigPoint = oSurvey.TrigPoints.GetOrigin
                    If oOrigin Is Nothing Then
                        Return New cActionResult(False, "calculate", GetLocalizedString("calculate.textpart1"))
                    Else
                        If oSurvey.Properties.GPS.Enabled Then
                            If oSurvey.Properties.GPS.RefPointOnOrigin Then
                                If oOrigin.Coordinate.IsEmpty OrElse oOrigin.Coordinate.IsInError Then
                                    Return New cActionResult(False, "calculate", String.Format(GetLocalizedString("calculate.textpart12"), oOrigin.Name))
                                End If
                            Else
                                Dim oGPSTrigpoint As cSurveyPC.cSurvey.cTrigPoint = oSurvey.TrigPoints(oSurvey.Properties.GPS.CustomRefPoint)
                                If IsNothing(oGPSTrigpoint) Then
                                    Return New cActionResult(False, "calculate", String.Format(GetLocalizedString("calculate.textpart13"), oSurvey.Properties.GPS.CustomRefPoint))
                                Else
                                    If oGPSTrigpoint.Coordinate.IsEmpty OrElse oGPSTrigpoint.Coordinate.IsInError Then
                                        Return New cActionResult(False, "calculate", String.Format(GetLocalizedString("calculate.textpart12"), oSurvey.Properties.GPS.CustomRefPoint))
                                    End If
                                End If
                            End If
                        End If
                        Call oSurvey.RaiseOnProgressEvent("calculate", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("calculate.progressbegin1"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate)

                        Call pSurfaceElevationTrigpointRemove()
                        Call pOrthoPhotoTrigpointRemove()

                        Dim oSegmentsColl As List(Of cSegment) = oSurvey.Segments.GetSurveySegments.ToSegments
                        If oSurvey.Properties.CalculateVersion > 2 Then
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Check sessions")
                            Dim oInvalidSegments As List(Of cSegment) = oSegmentsColl.Where(Function(oSegment) Not oSegment.IsEquate AndAlso Not oSegment.Virtual AndAlso oSegment.Session = "").ToList
                            If oInvalidSegments.Count > 0 Then
                                'Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.Error, GetLocalizedString("calculate.textpart14"), oInvalidSegments))
                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, GetLocalizedString("calculate.textpart14"))
                                Throw New cCalculateMissingSessionException(modMain.GetLocalizedString("calculate.textpart14"), oInvalidSegments)
                            End If
                        Else
                            'have to warn user that some shot are without date
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, GetLocalizedString("calculate.textpart14"))
                        End If

                        Dim oOriginItem As cTrigPointCalculateItem = New cTrigPointCalculateItem(oOrigin.Name, 1)
                        Dim oGroups As cSegmentGroupCollection = pFillSegments(oSegmentsColl)
                        Call oGroups.Validate(True)

                        Select Case oSurvey.Invalidated
                            Case InvalidateEnum.FullCalculate
                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Trigpoint calculate")
                                Dim oOrphanStations As List(Of String) = pTrigPointsCalculate(oOrigin.Name, oSegmentsColl)
                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Prepare data")
                                Call pCalculatePrepareData(oOriginItem, oGroups)
                                If oOrphanStations.Count > 0 Then
                                    'If oOrphanStations.Count > 25 Then oOrphanStations = oOrphanStations.Take(25).ToList
                                    Dim oOrphanSegments As List(Of cSegment) = New List(Of cSegment)
                                    Call oOrphanStations.ForEach(Sub(sStation) oOrphanSegments.AddRange(oSurvey.Segments.GetTrigpointSegments(sStation).Cast(Of cSegment)))
                                    oOrphanSegments = oOrphanSegments.Distinct().ToList
                                    Throw New cCalculateOrphanShotsException(String.Format(GetLocalizedString("calculate.textpart16"), String.Join(", ", oOrphanStations)), oOrphanSegments)
                                End If
                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Therion run and get back results")
                                Call pCalculateSegments(oOriginItem, oGroups)
                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Geographics adjustments")
                                Call pCalculateGeographics()
                            Case InvalidateEnum.PartialCalculate
                                Call pCalculateDAndSideMeasures(oOriginItem, oGroups)
                        End Select

                        Dim bPerformWarping As Boolean
                        If oSurvey.Invalidated <= InvalidateEnum.PartialCalculate Then
                            bPerformWarping = False
                        Else
                            bPerformWarping = PerformWarping
                        End If

                        'if warping is in pause and calculate is right...reactivate it
                        If oSurvey.Properties.DesignWarpingState = cSurvey.DesignWarpingStateEnum.Paused Then oSurvey.Properties.DesignWarpingState = cSurvey.DesignWarpingStateEnum.Active

                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate plan centerline data")
                        Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("calculate.progress1"), 0)
                        Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("calculate.progressbegin2"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate)
                        Call oSurvey.Plan.Plot.Calculate(oSegmentsColl, bPerformWarping)
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate plan splay data")
                        Call oSurvey.Plan.Plot.CalculateSplay()
                        Call oSurvey.RaiseOnProgressEvent("calculate.plot.plan", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("calculate.progressend2"), 0)

                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate profile centerline data")
                        Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, GetLocalizedString("calculate.progress1"), 0.5)
                        Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, GetLocalizedString("calculate.progressbegin3"), 0, cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageCalculate)
                        Call oSurvey.Profile.Plot.Calculate(oSegmentsColl, bPerformWarping)
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate profile splay data")
                        Call oSurvey.Profile.Plot.CalculateSplay()
                        Call oSurvey.RaiseOnProgressEvent("calculate.plot.profile", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("calculate.progressend3"), 0)
                    End If

                    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate speleometrics")
                    Call oSpeleometrics.Calculate()

                    bDataFromDesignsInvalidated = True

                    Call oSurvey.RaiseOnProgressEvent("calculate", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, GetLocalizedString("calculate.progressend1"), 0)
                End If

                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Calculate completed")
                RaiseEvent OnCalculateComplete(Me, New EventArgs)
                Return New cActionResult()
            Catch exMissingSession As cCalculateMissingSessionException
                'managed exception
                Call oSurvey.RaiseOnProgressEvent("calculate", cSurvey.OnProgressEventArgs.ProgressActionEnum.Reset, GetLocalizedString("calculate.progressend1"), 0)
                oSurvey.Properties.DesignWarpingState = cSurvey.DesignWarpingStateEnum.Paused
                Call oSurvey.RaiseOnErrorLogEvent("Calculate completed with error", exMissingSession)
                RaiseEvent OnCalculateComplete(Me, New EventArgs)
                Return New cActionResult(False, "calculate", exMissingSession)
            Catch exCalculation As cCalculateException
                'managed exception
                Call oSurvey.RaiseOnProgressEvent("calculate", cSurvey.OnProgressEventArgs.ProgressActionEnum.Reset, GetLocalizedString("calculate.progressend1"), 0)
                oSurvey.Properties.DesignWarpingState = cSurvey.DesignWarpingStateEnum.Paused
                Call oSurvey.RaiseOnErrorLogEvent("Calculate completed with error", exCalculation)
                RaiseEvent OnCalculateComplete(Me, New EventArgs)
                Return New cActionResult(False, "calculate", exCalculation)
            Catch ex As Exception
                'real unmanaged exception
                Call oSurvey.RaiseOnProgressEvent("calculate", cSurvey.OnProgressEventArgs.ProgressActionEnum.Reset, GetLocalizedString("calculate.progressend1"), 0)
                oSurvey.Properties.DesignWarpingState = cSurvey.DesignWarpingStateEnum.Paused
                Call oSurvey.RaiseOnErrorLogEvent("Calculate completed with error", ex)
                RaiseEvent OnCalculateComplete(Me, New EventArgs)
                Call My.Application.ManageUnhandledException(ex)
                Return New cActionResult(False, "calculate", ex)
            End Try
        End Function

        Private Sub pCompassPltImportFrom(ByVal Filename As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing)
            If My.Computer.FileSystem.FileExists(Filename) Then
                'Dim bLogVerbose As Boolean = My.Application.Settings.GetSetting("debug.log.verbose", False)
                Dim oProcessed As HashSet(Of String) = New HashSet(Of String)
                Using sr As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Filename)
                    Do Until sr.EndOfStream
                        Dim sPart As String() = sr.ReadLine.Trim.Split(vbTab)
                        'If bLogVerbose Then Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "plt line->" & String.Join("|", sPart))
                        Select Case sPart(0)
                            Case "D", "M"
                                'read feets and get back meters
                                'If bLogVerbose Then
                                '    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "sY->" & sPart(1))
                                '    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "sX->" & sPart(2))
                                '    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "sZ->" & sPart(3))
                                'End If
                                Dim sY As Decimal = modNumbers.MathRound(modNumbers.StringToDecimal(sPart(1)) * -0.3048D, 4)
                                Dim sX As Decimal = modNumbers.MathRound(modNumbers.StringToDecimal(sPart(2)) * 0.3048D, 4)
                                Dim sZ As Decimal = modNumbers.MathRound(modNumbers.StringToDecimal(sPart(3)) * -0.3048D, 4)
                                'set station location
                                Dim sTrigPoint As String = sPart(4).Substring(1)
                                sTrigPoint = DictionaryTranslate(Dictionary, sTrigPoint)
                                If oTPs.Contains(sTrigPoint) AndAlso Not oProcessed.Contains(sTrigPoint) Then
                                    'If bLogVerbose Then Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, sTrigPoint & " -> " & sX & ";" & sY & ";" & sZ)
                                    Dim oTp As Calculate.cTrigPoint = oTPs.Item(sTrigPoint)
                                    With oTp
                                        Call .MoveTo(sX, sY, sZ)
                                        If Not oProcessed.Contains(sTrigPoint) Then oProcessed.Add(sTrigPoint)
                                        If oSurvey.Properties.CalculateVersion > 2 Then
                                            Call pCompassImportFromProcessEquate(oProcessed, oTp, sX, sY, sZ)
                                            'For Each sEquateTrigPoint In .Connections.GetEquateShots
                                            '    If oTPs.Contains(sEquateTrigPoint) Then
                                            '        With oTPs.Item(sEquateTrigPoint)
                                            '            Call .MoveTo(sX, sY, sZ)

                                            '        End With
                                            '        'If Not oProcessed.Contains(sEquateTrigPoint) Then oProcessed.Add(sEquateTrigPoint)
                                            '    End If
                                            'Next
                                        End If
                                    End With
                                End If
                        End Select
                    Loop
                    Call sr.Close()
                End Using

                Dim oOrigin As cTrigPoint = oTPs(oSurvey.TrigPoints.GetOrigin)
                Dim sOffSetX As Decimal = -oOrigin.Point.X
                Dim sOffsetY As Decimal = -oOrigin.Point.Y
                Dim sOffsetZ As Decimal = -oOrigin.Point.Z

                Threading.Tasks.Parallel.ForEach(Of String)(oProcessed, Sub(sProcessed)
                                                                            Call oTPs(sProcessed).MoveBy(sOffSetX, sOffsetY, sOffsetZ)
                                                                        End Sub)

                'For Each sProcessed In oProcessed
                '    Call oTPs(sProcessed).MoveBy(sOffSetX, sOffsetY, sOffsetZ)
                'Next
            End If
        End Sub

        Private Sub pCompassImportFromProcessEquate(Processed As HashSet(Of String), TrigPoint As Calculate.cTrigPoint, X As Decimal, Y As Decimal, Z As Decimal)
            With TrigPoint
                For Each sEquateTrigPoint In .Connections.GetEquateShots
                    If oTPs.Contains(sEquateTrigPoint) AndAlso Not Processed.Contains(sEquateTrigPoint) Then
                        Dim oNextTp As Calculate.cTrigPoint = oTPs.Item(sEquateTrigPoint)
                        With oNextTp
                            Call .MoveTo(X, Y, Z)
                            If Not Processed.Contains(sEquateTrigPoint) Then Processed.Add(sEquateTrigPoint)
                            Call pCompassImportFromProcessEquate(Processed, oNextTp, X, Y, Z)
                        End With
                    End If
                Next
            End With
        End Sub

        Private Class cTrigPointCalculateItem
            Public From As String
            Public Sign As Decimal

            Public Sub New(ByVal [From] As String, ByVal [Sign] As String)
                Me.From = [From]
                Me.Sign = [Sign]
            End Sub
        End Class

        Private Shared Function pGetCaveBranchKey(Segment As cSegment)
            Return Segment.Cave & "/" & Segment.Branch
        End Function

        Public Class cCalculateSegmentsException
            Inherits cCalculateException

            Private oSegments As List(Of cSegment)

            Public ReadOnly Property Segments As List(Of cSegment)
                Get
                    Return oSegments
                End Get
            End Property

            Friend Sub New(Message As String, Segments As List(Of cSegment))
                Call MyBase.New(Message)
                oSegments = Segments
            End Sub
        End Class

        Public Class cCalculateMissingSessionException
            Inherits cCalculateSegmentsException

            Public Sub New(Message As String, Segments As List(Of cSegment))
                MyBase.New(Message, Segments)
            End Sub
        End Class


        Public MustInherit Class cCalculateException
            Inherits Exception

            Friend Sub New(Message As String)
                Call MyBase.New(Message)
            End Sub
        End Class

        Public Class cCalculateTherionException
            Inherits cCalculateException

            Friend Sub New(Message As String)
                Call MyBase.New(Message)
            End Sub
        End Class

        Public Class cCalculateTrigpointException
            Inherits cCalculateException

            Private oTrigpoint As cSurveyPC.cSurvey.cTrigPoint

            Public ReadOnly Property Trigpoint As cSurveyPC.cSurvey.cTrigPoint
                Get
                    Return oTrigpoint
                End Get
            End Property

            Friend Sub New(Message As String, Trigpoint As cSurveyPC.cSurvey.cTrigPoint)
                Call MyBase.New(Message)
                oTrigpoint = Trigpoint
            End Sub
        End Class

        Public Class cCalculateSegmentException
            Inherits cCalculateException

            Private oSegment As cSegment

            Public ReadOnly Property Segment As cSegment
                Get
                    Return oSegment
                End Get
            End Property

            Friend Sub New(Message As String, Segment As cSegment)
                Call MyBase.New(Message)
                oSegment = Segment
            End Sub
        End Class

        Public Class cCalculateGroupConnectionMissingException
            Inherits cCalculateException

            Private oGroup As cSegmentGroup

            Public ReadOnly Property Group As cSegmentGroup
                Get
                    Return oGroup
                End Get
            End Property

            Friend Sub New(Message As String, Group As cSegmentGroup)
                Call MyBase.New(Message)
                oGroup = Group
            End Sub
        End Class

        Public Class cCalculateExtendStartException
            Inherits cCalculateException

            Private sExtendStart As String

            Public ReadOnly Property ExtendStart As String
                Get
                    Return sExtendStart
                End Get
            End Property

            Friend Sub New(Text As String, ExtendStart As String)
                Call MyBase.New(Text)
                sExtendStart = ExtendStart
            End Sub
        End Class

        Public Class cCalculateTherionMissingException
            Inherits cCalculateException

            Friend Sub New(Text As String)
                Call MyBase.New(Text)
            End Sub
        End Class

        Public Class cCalculateOrphanShotsException
            Inherits cCalculateSegmentsException

            Public Sub New(Text As String, Segments As List(Of cSegment))
                MyBase.New(Text, Segments)
            End Sub
        End Class

        Public Class cCalculateTrigpointsException
            Inherits cCalculateException

            Private oTrigpoints As List(Of cSurveyPC.cSurvey.cTrigPoint)

            Public ReadOnly Property Trigpoints As List(Of cSurveyPC.cSurvey.cTrigPoint)
                Get
                    Return oTrigpoints
                End Get
            End Property

            Friend Sub New(Text As String, Trigpoints As List(Of cSurveyPC.cSurvey.cTrigPoint))
                Call MyBase.New(Text)
                oTrigpoints = Trigpoints
            End Sub
        End Class

        Public Class cCalculateOrphanStationsException
            Inherits cCalculateTrigpointsException

            Friend Sub New(Text As String, Trigpoints As List(Of cSurveyPC.cSurvey.cTrigPoint))
                Call MyBase.New(Text, Trigpoints)
            End Sub
        End Class

        Private Sub pCalculatePrepareData(ByVal Origin As cTrigPointCalculateItem, Groups As cSegmentGroupCollection)
            Dim oTrigPoints As List(Of cTrigPointCalculateItem) = New List(Of cTrigPointCalculateItem)

            Dim oNextTrigPoint As List(Of cTrigPointCalculateItem) = New List(Of cTrigPointCalculateItem)
            Dim oCalculatedSegments As List(Of cSegment) = New List(Of cSegment)
            Dim oCalculatedTrigpoints As Dictionary(Of String, cTrigPointPoint) = New Dictionary(Of String, cTrigPointPoint)(StringComparer.OrdinalIgnoreCase)

            Dim iLastCalculatedTrigpoints As Integer = oCalculatedTrigpoints.Count
            Dim oGroups As List(Of cSegmentGroup) = Groups.ToCalculateList(Origin.From, Integer.MinValue)
            Do Until oGroups.Count = 0
                Dim oGroup As cSegmentGroup = oGroups(0)
                Dim oSubSegmentColl As List(Of cSegment) = oGroup.GetSegments.Where(Function(oitem) oitem.IsValid AndAlso Not oitem.Splay).ToList
                Call oGroups.Remove(oGroup)

                If oSubSegmentColl.Count > 0 Then
                    Call oSubSegmentColl.Sort(Function(x As cSegment, y As cSegment)
                                                  Return x.Data.OrdinalPosition.CompareTo(y.Data.OrdinalPosition)
                                              End Function)

                    Dim sExtendStart As String = oGroup.ExtendStart.ToUpper
                    Call oTrigPoints.Clear()
                    If oSubSegmentColl.Where(Function(oitem) oitem.Data.Data.From = sExtendStart OrElse oitem.Data.Data.To = sExtendStart).Count > 0 Then
                        Call oTrigPoints.Insert(0, New cTrigPointCalculateItem(sExtendStart, 1))
                    Else
                        'Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.Error, String.Format(modMain.GetLocalizedString("calculate.textpart8"), sExtendStart), oSurvey.TrigPoints(sExtendStart)))
                        Throw New cCalculateExtendStartException(String.Format(modMain.GetLocalizedString("calculate.textpart8"), sExtendStart), sExtendStart)
                    End If

                    Do Until oTrigPoints.Count = 0 OrElse oSubSegmentColl.Count = 0
                        For Each oTrigPointCalculateItem As cTrigPointCalculateItem In oTrigPoints
                            Dim sFrom As String = oTrigPointCalculateItem.[From]
                            Dim sSign As Decimal = oTrigPointCalculateItem.Sign

                            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cSegment)(oSubSegmentColl, Sub(oSegment)
                                                                                                                 Dim bIgnore As Boolean = False
                                                                                                                 Dim bProcess As Boolean = False
                                                                                                                 If oSegment.Data.SourceData.From = sFrom Then
                                                                                                                     With oSurvey.TrigPoints(oSegment.Data.SourceData.From).Connections
                                                                                                                         If .Contains(oSegment.Data.SourceData.To) Then
                                                                                                                             bIgnore = .Get(oSegment.Data.SourceData.To)
                                                                                                                         End If
                                                                                                                     End With
                                                                                                                     bProcess = True
                                                                                                                 End If
                                                                                                                 If Not bProcess AndAlso oSegment.Data.SourceData.To = sFrom Then
                                                                                                                     With oSurvey.TrigPoints(oSegment.Data.SourceData.To).Connections
                                                                                                                         If .Contains(oSegment.Data.SourceData.From) Then
                                                                                                                             bIgnore = .Get(oSegment.Data.SourceData.From)
                                                                                                                         End If
                                                                                                                     End With
                                                                                                                     If Not bIgnore Then
                                                                                                                         Call oSegment.Data.ReverseData(oSegment)
                                                                                                                         bProcess = True
                                                                                                                     End If
                                                                                                                 End If
                                                                                                                 If bProcess Then

                                                                                                                     SyncLock oCalculatedTrigpoints
                                                                                                                         If Not oCalculatedTrigpoints.ContainsKey(oSegment.Data.Data.To) Then
                                                                                                                             Call oCalculatedTrigpoints.Add(oSegment.Data.Data.To, New cTrigPointPoint(0, 0, 0, 0))
                                                                                                                         End If
                                                                                                                     End SyncLock

                                                                                                                     If Not bIgnore Then
                                                                                                                         'add shot to processed collection
                                                                                                                         SyncLock oCalculatedSegments
                                                                                                                             Call oCalculatedSegments.Add(oSegment)
                                                                                                                         End SyncLock
                                                                                                                         If Not oSegment.Splay Then
                                                                                                                             'splay don't have next shot
                                                                                                                             SyncLock oNextTrigPoint
                                                                                                                                 Call oNextTrigPoint.Add(New cTrigPointCalculateItem(oSegment.Data.SourceData.To, 0))
                                                                                                                             End SyncLock
                                                                                                                         End If
                                                                                                                     End If
                                                                                                                 End If
                                                                                                             End Sub)

                            'For Each oSegment As cSegment In oSubSegmentColl
                            '    Dim bIgnore As Boolean = False
                            '    Dim bProcess As Boolean = False
                            '    If oSegment.Data.SourceData.From = sFrom Then
                            '        With oSurvey.TrigPoints(oSegment.Data.SourceData.From).Connections
                            '            If .Contains(oSegment.Data.SourceData.To) Then
                            '                bIgnore = .Get(oSegment.Data.SourceData.To)
                            '            End If
                            '        End With
                            '        bProcess = True
                            '    End If
                            '    If Not bProcess AndAlso oSegment.Data.SourceData.To = sFrom Then
                            '        With oSurvey.TrigPoints(oSegment.Data.SourceData.To).Connections
                            '            If .Contains(oSegment.Data.SourceData.From) Then
                            '                bIgnore = .Get(oSegment.Data.SourceData.From)
                            '            End If
                            '        End With
                            '        If Not bIgnore Then
                            '            Call oSegment.Data.ReverseData(oSegment)
                            '            bProcess = True
                            '        End If
                            '    End If
                            '    If bProcess Then
                            '        If Not oCalculatedTrigpoints.ContainsKey(oSegment.Data.Data.To) Then Call oCalculatedTrigpoints.Add(oSegment.Data.Data.To, New cTrigPointPoint(0, 0, 0, 0))
                            '        If Not bIgnore Then
                            '            'add shot to processed collection
                            '            Call oCalculatedSegments.Add(oSegment)
                            '            If Not oSegment.Splay Then
                            '                'splay don't have next shot
                            '                Call oNextTrigPoint.Add(New cTrigPointCalculateItem(oSegment.Data.SourceData.To, 0))
                            '            End If
                            '        End If
                            '    End If
                            'Next
                            oSubSegmentColl = oSubSegmentColl.Except(oCalculatedSegments).ToList
                            Call oCalculatedSegments.Clear()
                        Next
                        Call oTrigPoints.Clear()
                        Call oTrigPoints.AddRange(oNextTrigPoint)
                        Call oNextTrigPoint.Clear()

                        Call oSurvey.RaiseOnProgressEvent("calcprocsegments", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("calculate.textpart19"), (oGroup.Segments.Count - oSubSegmentColl.Count) / oGroup.Segments.Count)
                    Loop
                    Call oSurvey.RaiseOnProgressEvent("calcprocsegments", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

                    Dim oOrphanShots As List(Of cSegment) = oSubSegmentColl.Where(Function(oitem) Not oitem.IsEquate).ToList
                    If oOrphanShots.Count > 0 Then
                        Dim oOrphanStations As List(Of String) = New List(Of String)
                        Call oOrphanStations.AddRange(oOrphanShots.Select(Function(oitem) oitem.From).Where(Function(sStation) Not oCalculatedTrigpoints.ContainsKey(sStation)))
                        Call oOrphanStations.AddRange(oOrphanShots.Select(Function(oitem) oitem.To).Where(Function(sStation) Not oCalculatedTrigpoints.ContainsKey(sStation)))
                        If oOrphanStations.Count > 0 Then
                            'error...each loop have to add any station to oCalculatedTrigpoints, except for any equate connection this group to another...if not data are not correct...
                            'if orphan stations are more then 25 show only the first 25....
                            'If oOrphanStations.Count > 25 Then oOrphanStations = oOrphanStations.Take(25).ToList
                            Dim oRemainShots As List(Of cSegment) = oOrphanShots.Where(Function(oSegment) oOrphanStations.Contains(oSegment.From) OrElse oOrphanStations.Contains(oSegment.To)).ToList
                            Throw New cCalculateOrphanShotsException(String.Format(GetLocalizedString("calculate.textpart9"), sExtendStart), oRemainShots)
                        End If
                    End If
                End If
            Loop

            'set splay flag
            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cTrigPoint)(oSurvey.TrigPoints, Sub(oTrigpoint)
                                                                                                      Call oTrigpoint.Data.SetSplay(False)
                                                                                                  End Sub)
            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cTrigPoint)(oSurvey.TrigPoints.Where(Function(oTrigPoint) oTrigPoint.Name Like "*(*)"), Sub(oTrigpoint)
                                                                                                                                                              Call oTrigpoint.Data.SetSplay(True)
                                                                                                                                                          End Sub)

            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cSegment)(oSurvey.Segments.Cast(Of cSegment).Where(Function(oSegment) oSegment.Splay), Sub(oSegment)
                                                                                                                                                             Dim oTo As cSurveyPC.cSurvey.cTrigPoint = oSegment.GetToTrigPoint
                                                                                                                                                             If oTo.Connections.Count = 0 Then
                                                                                                                                                                 Call oTo.Data.SetSplay(True)
                                                                                                                                                             End If
                                                                                                                                                             Dim oFrom As cSurveyPC.cSurvey.cTrigPoint = oSegment.GetFromTrigPoint
                                                                                                                                                             If oFrom.Connections.Count = 0 Then
                                                                                                                                                                 Call oFrom.Data.SetSplay(True)
                                                                                                                                                             End If
                                                                                                                                                         End Sub)


            'Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cTrigPoint)(oSurvey.TrigPoints, Sub(oTrigpoint)
            '                                                                                          If oTrigpoint.Name Like "*(*)" Then
            '                                                                                              Call oTrigpoint.Data.SetSplay(True)
            '                                                                                          Else
            '                                                                                              If oTrigpoint.Connections.Count = 1 Then
            '                                                                                                  Dim oSegment As cSegment = oSurvey.Segments.Find(oTrigpoint.Name, oTrigpoint.Connections.First)
            '                                                                                                  If oSegment Is Nothing Then
            '                                                                                                      Call oTrigpoint.Data.SetSplay(False)
            '                                                                                                  Else
            '                                                                                                      Call oTrigpoint.Data.SetSplay(oSegment.Splay)
            '                                                                                                  End If
            '                                                                                              Else
            '                                                                                                  Call oTrigpoint.Data.SetSplay(False)
            '                                                                                              End If
            '                                                                                          End If
            '                                                                                      End Sub)

            'set calibration flag
            Dim oCalibrationSegments As cSegmentCollection = oSurvey.Segments.GetCalibrationSegments
            Threading.Tasks.Parallel.ForEach(Of cSurveyPC.cSurvey.cTrigPoint)(oCalibrationSegments.GetTrigPoints, Sub(oTrigpoint)
                                                                                                                      Dim bIsCalibration As Boolean = True
                                                                                                                      For Each oSegment As cSegment In oCalibrationSegments.Find(oTrigpoint.Name)
                                                                                                                          bIsCalibration = bIsCalibration And oSegment.Calibration
                                                                                                                          If Not bIsCalibration Then Exit For
                                                                                                                      Next
                                                                                                                      Call oTrigpoint.Data.SetCalibration(bIsCalibration)
                                                                                                                  End Sub)

        End Sub

        Private Class cTranslateErrorMessageResult
            Private sMessage As String
            Private iLine As Integer?

            Public ReadOnly Property Line As Integer?
                Get
                    Return iLine
                End Get
            End Property

            Public ReadOnly Property Message As String
                Get
                    Return sMessage
                End Get
            End Property

            Public Sub New(Message As String)
                sMessage = Message
            End Sub

            Public Sub New(Message As String, Line As Integer)
                sMessage = Message
                iLine = Line
            End Sub
        End Class
        Private Function pGetSegmentIDFromInputFileLine(Line As String) As String
            If Line.Contains("#s:") Then
                Dim iStart As Integer = Line.IndexOf("#s:") + 3
                Dim iEnd As Integer = Line.IndexOf(" ", iStart)
                If iEnd = -1 Then
                    Return Line.Substring(iStart)
                Else
                    Return Line.Substring(iStart, iEnd)
                End If
            Else
                Return ""
            End If
        End Function

        Private Function pTranslateErrorMessage(Message As String, Dictionary As Dictionary(Of String, String)) As cTranslateErrorMessageResult
            If Message.StartsWith("[") Then
                Dim sTranslatedMessage As String
                Dim sMessageParts() As String = Strings.Split(Message, "--")
                Dim iLine As Integer = sMessageParts(0).Replace("[", "").Replace("]", "")
                Dim sMessage As String = sMessageParts(1).Trim
                Select Case sMessage
                    Case "duplicated object name"
                        sTranslatedMessage = GetLocalizedString("calculate.textpart17")
                    Case "length reading is less than change in depth"
                        sTranslatedMessage = GetLocalizedString("calculate.textpart15")
                        'Case "[8]"
                        '    sTranslatedMessage = String.Format(GetLocalizedString("calculate.textpart11"), modExport.DictionaryTranslate(Dictionary, sMessageParts(2).Trim))
                    Case "bearing reading out of range"
                        sTranslatedMessage = String.Format(GetLocalizedString("calculate.textpart3"), sMessageParts(2).Trim)
                    Case "gradient reading out of range"
                        sTranslatedMessage = String.Format(GetLocalizedString("calculate.textpart4"), sMessageParts(2).Trim)
                    Case Else
                        sTranslatedMessage = sMessage
                End Select
                Return New cTranslateErrorMessageResult(sTranslatedMessage, iLine)
            Else
                If Message.StartsWith("can not connect") Then
                    Dim sTranslatedMessage As String
                    Dim sTrigpoint As String = Message.Replace("can not connect ", "").Replace(" to centerline network", "").Trim.Split("@")(0)
                    sTrigpoint = modExport.DictionaryTranslate(Dictionary, sTrigpoint)
                    sTranslatedMessage = String.Format(GetLocalizedString("calculate.textpart5"), sTrigpoint)
                    Return New cTranslateErrorMessageResult(sTranslatedMessage)
                ElseIf Message.StartsWith("shot between two equal station") Then
                    Dim sTranslatedMessage As String
                    Dim sTrigpoints As String() = Message.Replace("shot between two equal stations -- ", "").Replace(" and ", "|").Trim.Split("|").Select(Function(sTrigpoint) modExport.DictionaryTranslate(Dictionary, sTrigpoint.Split("@")(0))).ToArray
                    sTranslatedMessage = String.Format(GetLocalizedString("calculate.textpart18"), sTrigpoints(0), sTrigpoints(1))
                    Return New cTranslateErrorMessageResult(sTranslatedMessage)
                Else
                    Return New cTranslateErrorMessageResult(Message)
                End If
            End If
        End Function

        Private Sub pCalculateRingData(ByVal SegmentsColl As List(Of cSegment))
            If oRs.Count > 0 Then
                For Each oSegment As cSegment In SegmentsColl
                    Dim bIsInRing As Boolean = oRs.IsSegmentInRing(oSegment)
                    Call oSegment.Data.SetFlag(bIsInRing)
                Next
            End If
        End Sub

        Private Sub pCalculateDepthData(Trigpoint As cTrigPoints, Dictionary As IDictionary(Of String, String), Depth As Dictionary(Of String, Decimal))
            If Depth.Count > 0 Then
                Threading.Tasks.Parallel.ForEach(Of cTrigPoint)(TrigPoints, Sub(oTrigpoint)
                                                                                Dim sStation As String = If(Dictionary Is Nothing, oTrigpoint.Name, Dictionary(oTrigpoint.Name))
                                                                                If Depth.ContainsKey(sStation) Then
                                                                                    oTrigpoint.SetDepth(Depth(sStation))
                                                                                Else
                                                                                    oTrigpoint.SetDepth(Nothing)
                                                                                End If
                                                                            End Sub)
            End If
        End Sub

        Private Sub pCalculateDAndSideMeasures(ByVal Origin As cTrigPointCalculateItem, Groups As cSegmentGroupCollection)
            Dim oTrigPoints As List(Of cTrigPointCalculateItem) = New List(Of cTrigPointCalculateItem)

            Dim oNextTrigPoint As List(Of cTrigPointCalculateItem) = New List(Of cTrigPointCalculateItem)
            Dim oCalculatedSegments As List(Of cSegment) = New List(Of cSegment)

            Dim oRelocateTrigpoints As List(Of cRelocatePoint) = New List(Of cRelocatePoint)
            Dim oRelocateTrigpointsByGroup As Dictionary(Of String, List(Of String)) = New Dictionary(Of String, List(Of String))
            'Dim bRelocate As Boolean
            Dim iLeft As Integer
            Dim bMoreSegments As Boolean
            Dim iGroupIndex As Integer = 0
            Dim oGroups As List(Of cSegmentGroup) = Groups.ToCalculateList(Origin.From, Integer.MinValue)
            Do Until oGroups.Count = 0
                Dim oGroup As cSegmentGroup = oGroups(0)
                Dim oSubSegmentColl As List(Of cSegment) = oGroup.GetSegments   'also splay...
                Call oGroups.Remove(oGroup)

                If oSubSegmentColl.Count > 0 Then
                    bMoreSegments = True
                    Call oSubSegmentColl.Sort(Function(x As cSegment, y As cSegment)
                                                  Return x.Data.OrdinalPosition.CompareTo(y.Data.OrdinalPosition)
                                              End Function)

                    Dim sExtendStart As String = oGroup.ExtendStart.ToUpper

                    Call oTrigPoints.Clear()
                    Call oTrigPoints.Insert(0, New cTrigPointCalculateItem(sExtendStart, 1))
                    'bRelocate = True
                    Dim oCalculatedTrigpoints As Dictionary(Of String, cTrigPointPoint) = New Dictionary(Of String, cTrigPointPoint)(StringComparer.OrdinalIgnoreCase)
                    'If Not oCalculatedTrigpoints.ContainsKey(sExtendStart) Then
                    Call oCalculatedTrigpoints.Add(sExtendStart, New cTrigPointPoint(oTPs(sExtendStart).Point, iLeft))
                    'End If
                    'this is only for debug...have to be not relevant...
                    iLeft += 500
                    iGroupIndex += 1

                    Do Until oTrigPoints.Count = 0 OrElse oSubSegmentColl.Count = 0
                        For Each oTrigPointCalculateItem As cTrigPointCalculateItem In oTrigPoints
                            Dim sFrom As String = oTrigPointCalculateItem.[From]
                            Dim sSign As Decimal = oTrigPointCalculateItem.Sign

                            For Each oSegment As cSegment In oSubSegmentColl
                                If oSegment.Data.Data.From = sFrom Then
                                    Dim sTo As String = oSegment.Data.Data.To
                                    Dim bIgnore As Boolean = False

                                    Dim oFromTP As cTrigPoint = oTPs(sFrom)
                                    Dim oToTP As cTrigPoint = oTPs(sTo)
                                    Dim oFromPoint As cTrigPointPoint = oFromTP.Point
                                    Dim oToPoint As cTrigPointPoint = oToTP.Point

                                    Dim oFromEEPoint As cTrigPointPoint = oCalculatedTrigpoints(sFrom)

                                    Dim sNewSign As Decimal
                                    Dim bIsSplay As Boolean = oSegment.Splay

                                    If bIsSplay Then
                                        sNewSign = 1
                                    Else
                                        If oSurvey.TrigPoints.Contains(sFrom) Then
                                            If oSurvey.TrigPoints(sFrom).Connections.Contains(sTo) Then
                                                bIgnore = oSurvey.TrigPoints(sFrom).Connections.Get(sTo) 'AndAlso Not oSurvey.TrigPoints(sTo).Connections.Get(sFrom)
                                            End If
                                        End If
                                        sNewSign = If(oSegment.Data.Data.Direction = cSurvey.DirectionEnum.Left, -1, 1)
                                        If oSurvey.Properties.CalculateVersion > 0 Then
                                            sNewSign = sNewSign * If(oSegment.Data.Data.Reversed, -1, 1)
                                        End If
                                    End If

                                    Dim sD As Decimal = 0
                                    If Not oSegment.IsEquate Then
                                        If oSegment.Data.Data.Direction <> cSurvey.DirectionEnum.Vertical Then
                                            Dim oPlanFromPoint As PointD = oFromPoint.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                                            Dim oPlanToPoint As PointD = oToPoint.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                                            sD = modPaint.DistancePointToPoint(oPlanFromPoint, oPlanToPoint)
                                        End If
                                    End If
                                    Dim oToEEPoint As cTrigPointPoint = New cTrigPointPoint(oToPoint, oFromEEPoint.D + sD * sNewSign)
                                    If Not oCalculatedTrigpoints.ContainsKey(sTo) Then Call oCalculatedTrigpoints.Add(sTo, oToEEPoint)
                                    With oToTP
                                        Dim oPointToRelocate As cTrigPointPoint = .Connections.SetPoint(sFrom, oToEEPoint)
                                        Call oRelocateTrigpoints.Add(New cRelocatePoint(sTo, sFrom, oGroup, oPointToRelocate, bIsSplay))
                                        Call pAppendStationToGroup(oRelocateTrigpointsByGroup, sTo, oGroup)
                                    End With
                                    With oFromTP
                                        Dim oPointToRelocate As cTrigPointPoint = .Connections.SetPoint(sTo, oFromEEPoint)
                                        Call oRelocateTrigpoints.Add(New cRelocatePoint(sFrom, sTo, oGroup, oPointToRelocate, bIsSplay))
                                        Call pAppendStationToGroup(oRelocateTrigpointsByGroup, sFrom, oGroup)
                                    End With

                                    If Not bIgnore Then
                                        If oSegment.Splay Then
                                            'splay data are always at the end point...
                                            If oSegment.Data.Data.Reversed Then
                                                Call oFromTP.SideMeasure.AppendUpDown(sTo, oSegment.GetBaseUp, oSegment.GetBaseDown)
                                                Call oFromTP.SideMeasure.AppendLeftRight(sTo, oSegment.GetBaseLeft, oSegment.GetBaseRight, oSegment.GetSideMeasuresType)
                                            Else
                                                Call oToTP.SideMeasure.AppendUpDown(sFrom, oSegment.GetBaseUp, oSegment.GetBaseDown)
                                                Call oToTP.SideMeasure.AppendLeftRight(sFrom, oSegment.GetBaseLeft, oSegment.GetBaseRight, oSegment.GetSideMeasuresType)
                                            End If
                                        Else
                                            If oSegment.GetSideMeasuresReferTo = cSegment.SideMeasuresReferToEnum.StartPoint Then
                                                If oSegment.Data.Data.Reversed Then
                                                    Call oToTP.SideMeasure.AppendUpDown(sFrom, oSegment.GetBaseUp, oSegment.GetBaseDown)
                                                    Call oToTP.SideMeasure.AppendLeftRight(sFrom, oSegment.GetBaseLeft, oSegment.GetBaseRight, oSegment.GetSideMeasuresType)
                                                Else
                                                    Call oFromTP.SideMeasure.AppendUpDown(sTo, oSegment.GetBaseUp, oSegment.GetBaseDown)
                                                    Call oFromTP.SideMeasure.AppendLeftRight(sTo, oSegment.GetBaseLeft, oSegment.GetBaseRight, oSegment.GetSideMeasuresType)
                                                End If
                                            Else
                                                'end point...
                                                If oSegment.Data.Data.Reversed Then
                                                    Call oFromTP.SideMeasure.AppendUpDown(sTo, oSegment.GetBaseUp, oSegment.GetBaseDown)
                                                    Call oFromTP.SideMeasure.AppendLeftRight(sTo, oSegment.GetBaseLeft, oSegment.GetBaseRight, oSegment.GetSideMeasuresType)
                                                Else
                                                    Call oToTP.SideMeasure.AppendUpDown(sFrom, oSegment.GetBaseUp, oSegment.GetBaseDown)
                                                    Call oToTP.SideMeasure.AppendLeftRight(sFrom, oSegment.GetBaseLeft, oSegment.GetBaseRight, oSegment.GetSideMeasuresType)
                                                End If
                                            End If
                                        End If

                                        'add shot to processed collection
                                        Call oCalculatedSegments.Add(oSegment)
                                        If Not oSegment.Splay Then
                                            'splay don't have next shot
                                            Call oNextTrigPoint.Add(New cTrigPointCalculateItem(sTo, sNewSign))
                                        End If
                                    End If
                                End If
                            Next
                            oSubSegmentColl = oSubSegmentColl.Except(oCalculatedSegments).ToList
                            Call oCalculatedSegments.Clear()
                        Next
                        Call oTrigPoints.Clear()
                        Call oTrigPoints.AddRange(oNextTrigPoint)
                        Call oNextTrigPoint.Clear()

                        Call oSurvey.RaiseOnProgressEvent("calcdandsidemeasures", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("calculate.textpart20"), (oGroup.Segments.Count - oSubSegmentColl.Count) / oGroup.Segments.Count)
                    Loop
                End If
            Loop
            Call oSurvey.RaiseOnProgressEvent("calcdandsidemeasures", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            Dim oSegmentsColl As List(Of cSegment) = Groups.GetDistinctSegments.Where(Function(oitem) Not oitem.Splay).ToList

            Dim oRelocateTrigpointsIndex As List(Of cRelocatePoint) = pRelocateStationsCreateIndex(oRelocateTrigpointsByGroup, oRelocateTrigpoints)

            For Each oGroup As cSegmentGroup In Groups
                If Not IsNothing(oGroup.ParentConnection) Then
                    Dim bReverse As Boolean
                    Dim oParentSegment As cSegment = oSegmentsColl.Where(Function(oitem) oitem.Data.Group.Key <> oGroup.Key AndAlso ((oitem.Data.Data.From = oGroup.ParentConnection.Station AndAlso oitem.Data.Data.To = oGroup.ParentConnection.FromStation) OrElse (oitem.Data.Data.From = oGroup.ParentConnection.FromStation AndAlso oitem.Data.Data.To = oGroup.ParentConnection.Station))).FirstOrDefault()
                    If IsNothing(oParentSegment) Then
                        oParentSegment = oSegmentsColl.Where(Function(oitem) oitem.Data.Group.Key <> oGroup.Key AndAlso ((oitem.Data.Data.From = oGroup.Connection.Station AndAlso oitem.Data.Data.To = oGroup.Connection.FromStation) OrElse (oitem.Data.Data.From = oGroup.Connection.FromStation AndAlso oitem.Data.Data.To = oGroup.Connection.Station))).FirstOrDefault()
                        bReverse = True
                    End If
                    If IsNothing(oParentSegment) Then
                        'group is wrong...
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "Relocating " & oGroup.ExtendStart & " not possible: parent shot not found or in same group, fallback to autoconnection")
                    Else
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Relocating " & oGroup.ExtendStart & " on " & oGroup.ParentConnection.ToString & " to " & oGroup.Connection.ToString)
                        Dim oSourceGroup As cSegmentGroup = oParentSegment.Data.Group
                        Dim oSourcePoint As cTrigPointPoint = oTPs(oGroup.ParentConnection.Station).Connections(oGroup.ParentConnection.FromStation).GetPoint()
                        Dim oDestPoint As cTrigPointPoint = oTPs(oGroup.Connection.Station).Connections(oGroup.Connection.FromStation).GetPoint()
                        Dim dD As Decimal
                        If bReverse Then
                            dD = oDestPoint.D - oSourcePoint.D
                        Else
                            dD = oSourcePoint.D - oDestPoint.D
                        End If
                        Dim oPointToRelocate As List(Of cRelocatePoint) = oRelocateTrigpoints.Where(Function(oitem) oitem.Group.Key = oGroup.Key).ToList

                        Threading.Tasks.Parallel.ForEach(Of cRelocatePoint)(oPointToRelocate, Sub(oRelocateTrigpoint)
                                                                                                  If dD <> 0 Then Call oRelocateTrigpoint.Point.MoveBy(0, 0, 0, dD)
                                                                                                  Call oRelocateTrigpoint.ChangeGroup(oSourceGroup)
                                                                                              End Sub)
                    End If
                End If
            Next

            Dim oOriginTP As cTrigPointPoint

            If oRelocateTrigpoints.Count > 0 Then
                Call oTrigPoints.Clear()
                Call oTrigPoints.Add(Origin)

                Call oNextTrigPoint.Clear()
                Call oCalculatedSegments.Clear()
                Dim oCalculatedTrigpoints As Dictionary(Of String, cTrigPointPoint) = New Dictionary(Of String, cTrigPointPoint)(StringComparer.OrdinalIgnoreCase)
                'Call oCalculatedTrigpoints.Clear()

                oOriginTP = oTPs(Origin.From).GetPoints.FirstOrDefault() 'New cTrigPointPoint(0, 0, 0, 0)
                If IsNothing(oOriginTP) Then
                    oOriginTP = New cTrigPointPoint(0, 0, 0, 0)
                End If
                Call oCalculatedTrigpoints.Add(Origin.From, oOriginTP)

                Call pRelocateStations(New cConnectionDef(Origin.From, Origin.From), oOriginTP, oRelocateTrigpoints, oRelocateTrigpointsIndex)

                Dim iCount As Integer = oSegmentsColl.Count
                Do Until oTrigPoints.Count = 0 OrElse oSegmentsColl.Count = 0
                    For Each oTrigPointCalculateItem As cTrigPointCalculateItem In oTrigPoints
                        Dim sFrom As String = oTrigPointCalculateItem.[From]
                        Dim sSign As Decimal = oTrigPointCalculateItem.Sign
                        For Each oSegment As cSegment In oSegmentsColl
                            Dim sTo As String = ""
                            If oSegment.Data.Data.From = sFrom Then
                                sTo = oSegment.Data.Data.To
                            ElseIf oSegment.Data.Data.To = sFrom Then
                                sTo = oSegment.Data.Data.From
                            End If
                            If sTo <> "" Then
                                Dim bIgnore As Boolean = False
                                If oSurvey.TrigPoints.Contains(sFrom) Then
                                    If oSurvey.TrigPoints(sFrom).Connections.Contains(sTo) Then
                                        bIgnore = oSurvey.TrigPoints(sFrom).Connections.Get(sTo)
                                    End If
                                End If
                                If Not bIgnore Then
                                    'mark shot as processed
                                    Call oCalculatedSegments.Add(oSegment)
                                    'mark station as processed (in this case, if so, reset it)
                                    If oCalculatedTrigpoints.ContainsKey(sTo) Then oCalculatedTrigpoints.Remove(sTo)
                                    Dim oToTP As cTrigPointPoint = oTPs(sTo).Connections(sFrom).GetPoint
                                    Call oCalculatedTrigpoints.Add(sTo, oToTP)
                                    Call oNextTrigPoint.Add(New cTrigPointCalculateItem(sTo, 1))

                                    'autoconnection for group without connection's stations
                                    Call pRelocateStations(New cConnectionDef(sTo, sFrom), oToTP, oRelocateTrigpoints, oRelocateTrigpointsIndex)
                                End If
                            End If
                        Next
                        oSegmentsColl = oSegmentsColl.Except(oCalculatedSegments).ToList
                        Call oCalculatedSegments.Clear()
                    Next
                    Call oTrigPoints.Clear()
                    Call oTrigPoints.AddRange(oNextTrigPoint)
                    Call oNextTrigPoint.Clear()

                    Call oSurvey.RaiseOnProgressEvent("calcstationposition", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("calculate.textpart19"), (iCount - oSegmentsColl.Count) / iCount)
                Loop
            End If
            Call oSurvey.RaiseOnProgressEvent("calcprocsegments", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            'all have to be relocated to put origin to 0,0
            oOriginTP = oTPs(Origin.From).GetPoints.FirstOrDefault()
            If Not IsNothing(oOriginTP) Then
                Dim dD As Decimal = -1 * oOriginTP.D
                If dD <> 0 Then
                    Threading.Tasks.Parallel.ForEach(Of cTrigPoint)(oTPs, Sub(oTp)
                                                                              Call oTp.Connections.MoveBy(0, 0, 0, dD)
                                                                          End Sub)
                End If
            End If
        End Sub

        Private Sub pAppendStationToGroup(RelocateTrigpointsByGroup As Dictionary(Of String, List(Of String)), Station As String, Group As cSegmentGroup)
            If RelocateTrigpointsByGroup.ContainsKey(Station) Then
                Dim oGroups As List(Of String) = RelocateTrigpointsByGroup(Station)
                If Not oGroups.Contains(Group.Key) Then Call oGroups.Add(Group.Key)
            Else
                Dim oGroups As List(Of String) = New List(Of String)
                Call oGroups.Add(Group.Key)
                Call RelocateTrigpointsByGroup.Add(Station, oGroups)
            End If
        End Sub

        Private Function pRelocateStationsCreateIndex(ByRef RelocateTrigpointsByGroup As Dictionary(Of String, List(Of String)), ByRef RelocateTrigpoints As List(Of cRelocatePoint)) As List(Of cRelocatePoint)
            Dim oIndex As List(Of cRelocatePoint) = New List(Of cRelocatePoint)
            For Each sStation As String In RelocateTrigpointsByGroup.Keys
                If RelocateTrigpointsByGroup(sStation).Count > 1 Then
                    Call oIndex.AddRange(RelocateTrigpoints.Where(Function(oitem) oitem.Station = sStation))
                End If
            Next
            Return oIndex
        End Function

        Private Sub pRelocateStations(ConnectionDef As cConnectionDef, Station As cTrigPointPoint, ByRef RelocateTrigpoints As List(Of cRelocatePoint), ByRef RelocateTrigpointsIndex As List(Of cRelocatePoint))
            '0 create a collection with crelocatepoint with station included in more than 1 group and use this as collection for next steps

            '1 connectiondef should exist only in 1 group
            '2 find group for connectiondef = maingroup
            '3 locate other group with station from maingroup
            '4 find first point for same station of maingroup
            '5 relocate those groups and change point's group

            Dim oBaseStation As cRelocatePoint = RelocateTrigpointsIndex.FirstOrDefault(Function(oitem) oitem.Connection = ConnectionDef)
            If IsNothing(oBaseStation) Then
                'error..or normal?
            Else
                For Each oGroup As cSegmentGroup In RelocateTrigpoints.Where(Function(oitem) oitem.Group.Key <> oBaseStation.Group.Key AndAlso oitem.Station = oBaseStation.Station AndAlso oitem.Connection <> ConnectionDef).Select(Function(oitem) oitem.Group).ToList
                    'group with same station but not same group
                    Dim oPointToRelocate As List(Of cRelocatePoint) = RelocateTrigpoints.Where(Function(oitem) oitem.Group.Key = oGroup.Key).ToList
                    If oPointToRelocate.Count > 0 Then
                        'find same station in other group (I can use RelocateTrigpointsIndex for better search)
                        'Dim oSameStation As cRelocatePoint = oPointToRelocate.FirstOrDefault(Function(oitem) oitem.Station = oBaseStation.Station)
                        Dim oSameStationInAnotherGroup As cRelocatePoint = RelocateTrigpointsIndex.FirstOrDefault(Function(oitem) oitem.Group.Key = oGroup.Key AndAlso oitem.Station = oBaseStation.Station AndAlso oitem.Connection <> ConnectionDef)
                        If IsNothing(oSameStationInAnotherGroup) Then
                            'error?
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "Relocating " & oGroup.ExtendStart & " not possibile: no common station with other groups")
                        Else
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, "Autorelocating " & oGroup.ExtendStart & " on " & oBaseStation.Connection.ToString & " to " & oSameStationInAnotherGroup.Connection.ToString)
                            Dim dD As Decimal = oBaseStation.Point.D - oSameStationInAnotherGroup.Point.D
                            If dD = 0 Then
                                Threading.Tasks.Parallel.ForEach(Of cRelocatePoint)(oPointToRelocate, Sub(oRelocateTrigpoint)
                                                                                                          Call oRelocateTrigpoint.ChangeGroup(oBaseStation.Group)
                                                                                                      End Sub)
                            Else
                                Threading.Tasks.Parallel.ForEach(Of cRelocatePoint)(oPointToRelocate, Sub(oRelocateTrigpoint)
                                                                                                          Call oRelocateTrigpoint.Point.MoveBy(0, 0, 0, dD)
                                                                                                          Call oRelocateTrigpoint.ChangeGroup(oBaseStation.Group)
                                                                                                      End Sub)
                            End If
                        End If
                    End If
                Next
            End If
        End Sub

        Private Class cRelocatePoint
            Private oConnectioDef As cConnectionDef
            Private oGroup As cSegmentGroup
            Private oPoint As cTrigPointPoint
            Private bIsSplay As Boolean

            Public Overrides Function ToString() As String
                Return oConnectioDef.Station & "(<" & oConnectioDef.FromStation & ") [>" & oGroup.Key & "]"
            End Function

            Public ReadOnly Property IsSplay As Boolean
                Get
                    Return bIsSplay
                End Get
            End Property

            Public ReadOnly Property Connection As cConnectionDef
                Get
                    Return oConnectioDef
                End Get
            End Property

            Public ReadOnly Property Station As String
                Get
                    Return oConnectioDef.Station
                End Get
            End Property

            Public ReadOnly Property RelativeStation As String
                Get
                    Return oConnectioDef.FromStation
                End Get
            End Property

            Public ReadOnly Property Group As cSegmentGroup
                Get
                    Return oGroup
                End Get
            End Property

            Friend Sub ChangeGroup(NewGroup As cSegmentGroup)
                oGroup = NewGroup
            End Sub

            Public ReadOnly Property Point As cTrigPointPoint
                Get
                    Return oPoint
                End Get
            End Property

            Public Sub New(Station As String, RelativeStation As String, Group As cSegmentGroup, Point As cTrigPointPoint, IsSplay As Boolean)
                oConnectioDef = New cConnectionDef(Station, RelativeStation)
                oGroup = Group
                oPoint = Point
                bIsSplay = IsSplay
            End Sub
        End Class

        Private Sub pProcessOutputStringHandler(sendingProcess As Object, outLine As DataReceivedStringEventArgs)
            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, outLine.Data)
        End Sub

        Private Sub pCalculateSegments(ByVal Origin As cTrigPointCalculateItem, Groups As cSegmentGroupCollection)
            'Dim iInversionMode As cSurvey.InversioneModeEnum = oSurvey.Properties.InversionMode
            'Dim bReverseDirection As Boolean = iInversionMode = cSurvey.InversioneModeEnum.Absolute
            Dim oSegmentsColl As List(Of cSegment) = Groups.GetSegments
            Select Case oSurvey.Properties.CalculateType
                Case cSurvey.CalculateTypeEnum.Therion
                    'esporto un file th e un thconfig in temp
                    'eseguo therion per quel th con il corrispondente thconfig e faccio generare un plt
                    'letto il file plt 
                    'carico i dati del plt come nel calcolo manuale
                    Dim sThProcess As String = My.Application.Settings.GetSetting("therion.path", "")
                    If sThProcess = "" Then
                        Throw New cCalculateTherionMissingException(modMain.GetLocalizedString("calculate.textpart6"))
                        'Call Err.Raise(vbObjectError + 100, "survey.calculate", GetLocalizedString("calculate.textpart6"), Nothing, Nothing)
                    Else
                        Dim bThBackgroundProcess As Boolean = My.Application.Settings.GetSetting("therion.backgroundprocess", 1)
                        Dim bThDeleteTempFile As Boolean = My.Application.Settings.GetSetting("therion.deletetempfiles", 1)

                        Dim oDepth As Dictionary(Of String, Decimal)
                        Dim oFiles As List(Of String) = New List(Of String)

                        Dim sTempPath As String = My.Computer.FileSystem.SpecialDirectories.Temp

                        Dim sBaseName As String = "_therion" & If(modMain.bIsInDebug, "", "_" & Guid.NewGuid.ToString)

                        Dim sTempThInputFilename As String = IO.Path.Combine(sTempPath, sBaseName & "_input.th")
                        Call oFiles.Add(sTempThInputFilename)
                        Dim sTempThOutputFilename As String = IO.Path.Combine(sTempPath, sBaseName & "_output.plt")
                        Call oFiles.Add(sTempThOutputFilename)
                        Dim sTempThOutputPlanXVIFilename As String = IO.Path.Combine(sTempPath, sBaseName & "_output_plan.xvi")
                        Call oFiles.Add(sTempThOutputPlanXVIFilename)
                        Dim sTempThOutputProfileXVIFilename As String = IO.Path.Combine(sTempPath, sBaseName & "_output_profile.xvi")
                        Call oFiles.Add(sTempThOutputProfileXVIFilename)
                        Dim sTempConfigFilename As String = IO.Path.Combine(sTempPath, sBaseName & "_config.thconfig")
                        Call oFiles.Add(sTempConfigFilename)
                        Dim sTempThLogFilename As String = IO.Path.Combine(sTempPath, sBaseName & "_log.log")
                        Call oFiles.Add(sTempThLogFilename)
                        Dim sTempINIFilename As String = IO.Path.Combine(sTempPath, "therion.ini")
                        Call oFiles.Add(sTempINIFilename)

                        Call DeleteFiles(oFiles)

                        Dim oTrigPointsToElaborate As List(Of String) = oSurvey.TrigPoints.GetNames
                        Dim iTrigPointsCount As Integer = oTrigPointsToElaborate.Count
                        Dim iSegmentsCount As Integer = oSegmentsColl.Count

                        If iTrigPointsCount > 1 AndAlso iSegmentsCount > 0 Then
                            Dim oInputdictionary As Dictionary(Of String, String) = Nothing
                            Dim oOutputdictionary As Dictionary(Of String, String) = Nothing
                            'create 2 dictionary for save station names...
                            Dim bThTrigpointSafeName As Boolean = My.Application.Settings.GetSetting("therion.trigpointsafename", 1)
                            If bThTrigpointSafeName Then
                                'create an key exclusion collection with branch with "integer" names...
                                Dim oKeyToExclude As List(Of Integer) = oSurvey.Properties.CaveInfos.GetAllWithEmpty.Select(Function(oitem) oitem.Name).Where(Function(oitem)
                                                                                                                                                                  Dim bResult As Boolean
                                                                                                                                                                  Call Integer.TryParse(oitem, bResult)
                                                                                                                                                                  Return bResult
                                                                                                                                                              End Function).Select(Function(sitem) Integer.Parse(sitem)).Distinct.ToList
                                oInputdictionary = New Dictionary(Of String, String)
                                oOutputdictionary = New Dictionary(Of String, String)
                                Dim iIndex As Integer = 0
                                For Each sTrigPoint As String In oTrigPointsToElaborate
                                    Do While oKeyToExclude.Contains(iIndex)
                                        iIndex += 1
                                    Loop
                                    Call oInputdictionary.Add(sTrigPoint, iIndex)
                                    Call oOutputdictionary.Add(iIndex, sTrigPoint)
                                    iIndex += 1
                                Next
                            End If

                            Dim bThSegmentForceDirection As Boolean = My.Application.Settings.GetSetting("therion.segmentforcedirection", 1)
                            Dim bThSegmentForcePath As Boolean = My.Application.Settings.GetSetting("therion.segmentforcepath", 1)
                            Dim iThOptions As modExport.TherionExportOptionsEnum = modExport.TherionExportOptionsEnum.SegmentID Or If(bThSegmentForceDirection, modExport.TherionExportOptionsEnum.SegmentForceDirection, 0) Or If(bThSegmentForcePath, modExport.TherionExportOptionsEnum.SegmentForcePath, 0) Or TherionExportOptionsEnum.ExportSketch Or TherionExportOptionsEnum.CalculateSplay
                            Dim iLegacyCalculation As Integer
                            If oSurvey.SharedSettings.GetValue("legacycalculation1", "on") = "on" Then
                                iLegacyCalculation = 1
                                Dim oResult As cTherionCalculateResult = modExport.TherionThExportTo_Version1(oSurvey, sTempThInputFilename, oInputdictionary, iThOptions)
                                Call oFiles.AddRange(oResult.Files)
                                oDepth = oResult.Depth
                                Call oSurvey.SharedSettings.SetValue("legacycalculation1", "off")
                            Else
                                iLegacyCalculation = 0
                                Dim oResult As cTherionCalculateResult = modExport.TherionThExportTo(oSurvey, sTempThInputFilename, oInputdictionary, iThOptions)
                                Call oFiles.AddRange(oResult.Files)
                                oDepth = oResult.Depth
                                'oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.DepthDetails, oResult.Depth))
                            End If

                            'if present, report depth info to station
                            Call pCalculateDepthData(oTPs, oInputdictionary, oDepth)

                            Dim sExportCommand As String = ""
                            sExportCommand = sExportCommand & "export model -fmt compass -output " & Chr(34) & sTempThOutputFilename & Chr(34) & vbCrLf
                            sExportCommand = sExportCommand & "export map -proj plan -output " & Chr(34) & sTempThOutputPlanXVIFilename & Chr(34) & " -layout-sketches on" & vbCrLf
                            sExportCommand = sExportCommand & "export map -proj extended -output " & Chr(34) & sTempThOutputProfileXVIFilename & Chr(34) & " -layout-sketches on" & vbCrLf
                            Call modExport.TherionCreateConfig(oSurvey, sTempConfigFilename, sTempThInputFilename, sExportCommand)

                            Dim iExitCode As Integer = modMain.ExecuteProcess(sThProcess, Chr(34) & sTempConfigFilename & Chr(34) & " -l " & Chr(34) & sTempThLogFilename & Chr(34), bThBackgroundProcess, AddressOf pProcessOutputStringHandler)

                            Call oGMD.Clear()
                            Call oRs.Clear()

                            Dim oLogLines As List(Of String) = My.Computer.FileSystem.ReadAllText(sTempThLogFilename).Split({vbCrLf}, StringSplitOptions.None).ToList

                            Dim bLoopErrors As Boolean
                            Dim bGeoMagLines As Boolean
                            For Each sLogLine As String In oLogLines
                                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information Or cSurvey.LogEntryType.Important, sLogLine)

                                If sLogLine Like "meridian convergence *" Then
                                    Dim sValue As String = sLogLine.Substring(28)
                                    Dim dMeridianConvergence As Decimal = modNumbers.StringToDecimal(sValue)
                                    Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.MeridianConvergence, dMeridianConvergence))
                                    Call oGMD.SetMeridianConvergence(dMeridianConvergence)
                                End If

                                If bGeoMagLines Then
                                    If sLogLine Like "  ????.?.?  *" Then
                                        Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.GeoMagDeclinationData, sLogLine))
                                        Call oGMD.Append(sLogLine)
                                    Else
                                        bGeoMagLines = False
                                    End If
                                End If
                                If sLogLine Like "geomag declinations *" Then
                                    bGeoMagLines = True
                                End If

                                Dim oInputLines As List(Of String)
                                If sLogLine Like "* error -- *" Then
                                    'devo rilevare il file e il numero di riga...cosi posso riportare, se è una battuta, a quale battuta corrisponde l'errore
                                    Dim sErrorMessage As String = sLogLine.Substring(sLogLine.IndexOf(" error -- ") + 10)
                                    sErrorMessage = sErrorMessage.Replace(sTempThInputFilename, "").Trim
                                    Dim oTEM As cTranslateErrorMessageResult = pTranslateErrorMessage(sErrorMessage, oOutputdictionary)
                                    If oTEM.Line.HasValue Then
                                        If oInputLines Is Nothing Then oInputLines = My.Computer.FileSystem.ReadAllText(sTempThInputFilename).Split({vbCrLf}, StringSplitOptions.None).ToList
                                        Dim sSegmentID As String = pGetSegmentIDFromInputFileLine(oInputLines(oTEM.Line - 1))
                                        Dim oSegment As cSegment = If(oSurvey.Segments.Contains(sSegmentID), oSurvey.Segments.Item(sSegmentID), Nothing)
                                        If oSegment Is Nothing Then
                                            Throw New cCalculateTherionException(oTEM.Message)
                                        Else
                                            Throw New cCalculateSegmentException(oTEM.Message, oSegment)
                                        End If
                                        'Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.Error, oTEM.Message, oSegment))
                                    Else
                                        'Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.Error, oTEM.Message))
                                        Throw New cCalculateTherionException(oTEM.Message)
                                    End If
                                    If iExitCode <> 0 Then
                                        'other not managed therion exception...
                                        Throw New cCalculateTherionException(oTEM.Message)
                                    End If
                                End If
                                If sLogLine Like "average loop error:*" Then
                                    Dim sValue As String = sLogLine.Substring(19).Replace("%", "")
                                    Dim dAverageErrorPercent As Decimal = modNumbers.StringToDecimal(sValue)
                                    Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.RingAvarageError, dAverageErrorPercent))
                                    Call oRs.SetAverageErrorPercent(dAverageErrorPercent)
                                End If
                                If sLogLine Like "* loop errors *" Then
                                    bLoopErrors = Not bLoopErrors
                                End If
                                If bLoopErrors Then
                                    If Not (sLogLine.StartsWith("#") OrElse sLogLine.StartsWith("REL")) Then
                                        Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.RingDetails, sLogLine))
                                        Call oRs.Append(sLogLine, oOutputdictionary)
                                    End If
                                End If
                            Next

                            Call pCompassPltImportFrom(sTempThOutputFilename, oOutputdictionary)

                            'remove meridian convergence to keep north always up
                            If iLegacyCalculation = 0 Then Call oTPs.PlanRotate(-oGMD.MeridianConvergence)

                            Dim oTpOrigin As cTrigPoint = oTPs(oSurvey.TrigPoints.GetOrigin.Name)
                            For Each oTrigPoint As cSurveyPC.cSurvey.cTrigPoint In oSurvey.TrigPoints
                                Dim sName As String = oTrigPoint.Name
                                If oTPs.Contains(sName) Then
                                    With oTPs(sName).Point
                                        Call oTrigPoint.Data.MoveTo(.X, .Y, .Z)
                                    End With
                                Else
                                    With oTpOrigin.Point
                                        Call oTrigPoint.Data.MoveTo(.X, .Y, .Z)
                                    End With
                                End If
                            Next

                            'extract ring data
                            Call pCalculateRingData(oSegmentsColl)

                            'calculate side data and extended elevation
                            Call pCalculateDAndSideMeasures(Origin, Groups)

                            '----------------------------------------------------------------------------------------------------------------------------------------------------------------
                            'devo leggere le immagini nell'xvi,
                            'per ogni immagine devo andare a verificare quali stazioni sono comprese nell'immagine stessa
                            'e prendere quelle come riferimento

                            Try
                                Dim oPlanSketchReader As cSurveyPC.cSurvey.Design.cDesignSketchXVIReader = New cSurveyPC.cSurvey.Design.cDesignSketchXVIReader(oSurvey, sTempThOutputPlanXVIFilename, oOutputdictionary)
                                With oPlanSketchReader
                                    'devo determinare TRASLAZIONE e SCALA...
                                    Dim oCorrection As cDesignSketches.cCorrection = oSurvey.Sketches.GetCorrections(cIDesign.cDesignTypeEnum.Plan)

                                    Dim iSketchIndex As Integer = 0
                                    For Each oSketchReaderImage As cSurveyPC.cSurvey.Design.cDesignSketchXVIReader.cXVIImage In oPlanSketchReader.Images.Images
                                        Do
                                            With oSurvey.Sketches(iSketchIndex).Sketch
                                                If .Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                                                    If Not .Deleted AndAlso Not .MorphingDisabled Then
                                                        Call .Stations.Rebind()
                                                        If .Stations.HasValidStations Then
                                                            Dim oStations() As Items.cItemSketch.cStation = pGetSketchRefStation(oSurvey.Sketches(iSketchIndex).Sketch)
                                                            Dim oStation1 As PointF = oPlanSketchReader.Stations.Stations(oStations(0).Name).Location
                                                            Dim oStation2 As PointF = oPlanSketchReader.Stations.Stations(oStations(1).Name).Location

                                                            Dim oPaintStation1 As PointF = oTPs(oStations(0).Name).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                                                            Dim oPaintStation2 As PointF = oTPs(oStations(1).Name).Point.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)

                                                            Dim sDistanceX As Single = Math.Round(Math.Abs(oStation1.X - oStation2.X), 2)
                                                            Dim sPaintDistanceX As Single = Math.Round(Math.Abs(oPaintStation1.X - oPaintStation2.X), 2)
                                                            Dim sDistanceY As Single = Math.Round(Math.Abs(oStation1.Y - oStation2.Y), 2)
                                                            Dim sPaintDistanceY As Single = Math.Round(Math.Abs(oPaintStation1.Y - oPaintStation2.Y), 2)

                                                            Dim sScaleX As Single
                                                            Dim sScaleY As Single
                                                            Dim bUseScaleX As Boolean = False
                                                            Dim bUseScaleY As Boolean = False
                                                            If sPaintDistanceX = 0.0F Then
                                                                sScaleX = oCorrection.Scale
                                                                bUseScaleY = True
                                                            Else
                                                                sScaleX = (sDistanceX / sPaintDistanceX) * oCorrection.Scale
                                                            End If
                                                            If sPaintDistanceY = 0.0F Then
                                                                sScaleY = oCorrection.Scale
                                                                bUseScaleX = True
                                                            Else
                                                                sScaleY = (sDistanceY / sPaintDistanceY) * oCorrection.Scale
                                                            End If
                                                            If bUseScaleY Then
                                                                sScaleX = sScaleY
                                                            End If
                                                            If bUseScaleX Then
                                                                sScaleY = sScaleX
                                                            End If

                                                            Dim oScaledStation1 As PointF = New PointF(oStation1.X / sScaleX, oStation1.Y / sScaleY)
                                                            Dim sTranslateX As Single = oScaledStation1.X - oPaintStation1.X + oCorrection.Translation.X
                                                            Dim sTranslateY As Single = oScaledStation1.Y + oPaintStation1.Y + oCorrection.Translation.Y

                                                            '------------------------------------------------
                                                            .DesignImage = oSketchReaderImage.Image
                                                            Dim sScaledX As Single
                                                            Dim sScaledY As Single
                                                            .Points.BeginUpdate()
                                                            If .ManualAdjust Then
                                                                Dim oLocation As PointF = .Points(0).Point
                                                                Call .Points.Clear()
                                                                sScaledX = oLocation.X
                                                                sScaledY = oLocation.Y
                                                            Else
                                                                Call .Points.Clear()
                                                                sScaledX = ((oSketchReaderImage.Location.X / sScaleX) - sTranslateX)
                                                                sScaledY = -1 * ((oSketchReaderImage.Location.Y / sScaleY) - sTranslateY)
                                                            End If
                                                            Call .Points.AddFromPaintPoint(sScaledX, sScaledY)
                                                            Dim sScaledWidth As Single = (oSketchReaderImage.Image.Width / sScaleX)
                                                            Dim sScaledHeight As Single = (oSketchReaderImage.Image.Height / sScaleY)
                                                            Call .Points.AddFromPaintPoint(sScaledX + sScaledWidth, sScaledY + sScaledHeight)
                                                            .Points.EndUpdate()
                                                            Call .Caches.Invalidate()
                                                            Exit Do
                                                        End If
                                                    End If
                                                End If
                                            End With
                                            iSketchIndex += 1
                                        Loop
                                        iSketchIndex += 1
                                    Next
                                End With
                            Catch
                            End Try

                            Try
                                Dim oProfileSketchReader As cSurveyPC.cSurvey.Design.cDesignSketchXVIReader = New cSurveyPC.cSurvey.Design.cDesignSketchXVIReader(oSurvey, sTempThOutputProfileXVIFilename, oOutputdictionary)
                                With oProfileSketchReader
                                    'devo determinare TRANSLAZIONE e SCALA...
                                    Dim oCorrection As cDesignSketches.cCorrection = oSurvey.Sketches.GetCorrections(cIDesign.cDesignTypeEnum.Profile)

                                    Dim iSketchIndex As Integer = 0
                                    For Each oSketchReaderImage As cSurveyPC.cSurvey.Design.cDesignSketchXVIReader.cXVIImage In oProfileSketchReader.Images.Images
                                        Do
                                            With oSurvey.Sketches(iSketchIndex).Sketch
                                                If .Design.Type = cIDesign.cDesignTypeEnum.Profile Then
                                                    If Not .Deleted AndAlso Not .MorphingDisabled Then
                                                        Call .Stations.Rebind()
                                                        If .Stations.HasValidStations Then
                                                            Dim oStations() As Items.cItemSketch.cStation = pGetSketchRefStation(oSurvey.Sketches(iSketchIndex).Sketch)

                                                            Dim oStation1 As PointF = oProfileSketchReader.Stations.Stations(oStations(0).Name).Location
                                                            Dim oStation2 As PointF = oProfileSketchReader.Stations.Stations(oStations(1).Name).Location

                                                            Dim oPaintStation1 As PointF = oTPs(oStations(0).Name).Connections.First.GetPoint.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                                                            Dim oPaintStation2 As PointF = oTPs(oStations(1).Name).Connections.First.GetPoint.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)

                                                            Dim sDistanceX As Single = Math.Round(Math.Abs(oStation1.X - oStation2.X), 2)
                                                            Dim sPaintDistanceX As Single = Math.Round(Math.Abs(oPaintStation1.X - oPaintStation2.X), 2)
                                                            Dim sDistanceY As Single = Math.Round(Math.Abs(oStation1.Y - oStation2.Y), 2)
                                                            Dim sPaintDistanceY As Single = Math.Round(Math.Abs(oPaintStation1.Y - oPaintStation2.Y), 2)

                                                            Dim sScaleX As Single
                                                            Dim sScaleY As Single
                                                            Dim bUseScaleX As Boolean = False
                                                            Dim bUseScaleY As Boolean = False
                                                            If sPaintDistanceX = 0.0F Then
                                                                sScaleX = oCorrection.Scale
                                                                bUseScaleY = True
                                                            Else
                                                                sScaleX = (sDistanceX / sPaintDistanceX) * oCorrection.Scale
                                                            End If
                                                            If sPaintDistanceY = 0.0F Then
                                                                sScaleY = oCorrection.Scale
                                                                bUseScaleX = True
                                                            Else
                                                                sScaleY = (sDistanceY / sPaintDistanceY) * oCorrection.Scale
                                                            End If
                                                            If bUseScaleY Then
                                                                sScaleX = sScaleY
                                                            End If
                                                            If bUseScaleX Then
                                                                sScaleY = sScaleX
                                                            End If

                                                            Dim oScaledStation1 As PointF = New PointF(oStation1.X / sScaleX, oStation1.Y / sScaleY)
                                                            Dim sTranslateX As Single = oScaledStation1.X - oPaintStation1.X + oCorrection.Translation.X
                                                            Dim sTranslateY As Single = oScaledStation1.Y + oPaintStation1.Y + oCorrection.Translation.Y

                                                            '------------------------------------------------
                                                            .DesignImage = oSketchReaderImage.Image
                                                            Dim sScaledX As Single
                                                            Dim sScaledY As Single
                                                            .Points.BeginUpdate()
                                                            If .ManualAdjust Then
                                                                Dim oLocation As PointF = .Points(0).Point
                                                                Call .Points.Clear()
                                                                sScaledX = oLocation.X
                                                                sScaledY = oLocation.Y
                                                            Else
                                                                Call .Points.Clear()
                                                                sScaledX = ((oSketchReaderImage.Location.X / sScaleX) - sTranslateX)
                                                                sScaledY = -1 * ((oSketchReaderImage.Location.Y / sScaleY) - sTranslateY)
                                                                If Math.Abs(sScaledY) > 100000 Then
                                                                    sScaledY = 0
                                                                End If
                                                            End If
                                                            Call .Points.AddFromPaintPoint(sScaledX, sScaledY)
                                                            Dim sScaledWidth As Single = (oSketchReaderImage.Image.Width / sScaleX)
                                                            Dim sScaledHeight As Single = (oSketchReaderImage.Image.Height / sScaleY)
                                                            Call .Points.AddFromPaintPoint(sScaledX + sScaledWidth, sScaledY + sScaledHeight)
                                                            .Points.EndUpdate()
                                                            Call .Caches.Invalidate()
                                                            Exit Do
                                                        End If
                                                    End If
                                                End If
                                            End With
                                            iSketchIndex += 1
                                        Loop
                                        iSketchIndex += 1
                                    Next
                                End With
                            Catch
                            End Try
                            '----------------------------------------------------------------------------------------------------------------------------------------------------------------

                            If bThDeleteTempFile Then
                                Call DeleteFiles(oFiles)
                            End If
                        End If

                    End If
                Case cSurvey.CalculateTypeEnum.None

                Case cSurvey.CalculateTypeEnum.Internal

            End Select

            'faccio il calcolo contrario di distanza direzione inclinazione per l'eventuale warping...
            For Each oSegment As cSegment In oSegmentsColl 'oSurvey.Segments
                If oSegment.IsValid Then
                    If oSegment.IsSelfDefined OrElse oSegment.IsEquate Then
                        With oSegment.Data
                            Call .BackupData()
                            Call .SetData(0, 0, 0, cSurvey.DirectionEnum.Right)
                        End With
                    Else
                        Dim oFrom As cTrigPointPoint
                        Dim oTo As cTrigPointPoint

                        If oSegment.Data.SourceData.Reversed Then
                            oFrom = oTPs(oSegment.Data.SourceData.To).Connections(oSegment.Data.SourceData.From).GetPoint
                            oTo = oTPs(oSegment.Data.SourceData.From).Connections(oSegment.Data.SourceData.To).GetPoint
                        Else
                            oFrom = oTPs(oSegment.Data.SourceData.From).Connections(oSegment.Data.SourceData.To).GetPoint
                            oTo = oTPs(oSegment.Data.SourceData.To).Connections(oSegment.Data.SourceData.From).GetPoint
                        End If

                        Dim sDistance As Decimal = ((oFrom.X - oTo.X) ^ 2D + (oFrom.Y - oTo.Y) ^ 2D + (oFrom.Z - oTo.Z) ^ 2D) ^ 0.5D

                        Dim oFromPoint As PointD = oFrom.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                        Dim oToPoint As PointD = oTo.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)

                        'oFromPoint = oFrom.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)
                        'oToPoint = oTo.To2DPoint(cTrigPointPoint.ProjectionEnum.Perpendicular)

                        ''distance
                        'Dim sDistance As Decimal = modNumbers.MathRound(modPaint.DistancePointToPoint(oFromPoint, oToPoint), 3)

                        'inclination
                        Dim sInclination As Decimal = 0
                        If oFromPoint = oToPoint Then
                            sInclination = 0
                        Else
                            sInclination = modNumbers.MathRound(modPaint.GetAngleBetweenSegment(oFromPoint, New PointD(oFromPoint.X + 100, oFromPoint.Y), oFromPoint, oToPoint), 3)
                        End If

                        If oSurvey.Properties.CalculateVersion = 0 Then
                            If oSegment.Data.SourceData.Reversed Then
                                If Math.Abs(sInclination) <> 90 Then
                                    If sInclination < 0 Then
                                        sInclination = 180 + sInclination
                                    Else
                                        sInclination = 180 - sInclination
                                    End If
                                End If
                            End If
                        Else
                            sInclination = NormalizeInclination(sInclination)
                        End If

                        If oFromPoint.Y < oToPoint.Y Then
                            sInclination = -1 * sInclination
                        End If

                        'bearing...
                        oFromPoint = oFrom.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                        oToPoint = oTo.To2DPoint(cTrigPointPoint.ProjectionEnum.FromTop)
                        Dim sBearing As Decimal
                        If modPaint.DistancePointToPoint(oFromPoint, oToPoint) = 0 OrElse Math.Abs(sInclination) = 90 Then
                            'sBearing = 0 'is not correct...i have to take the original bearing of the shot but this data is only for warping and for 90 degree shot there are no differnce...but, have to be fixed here and in warping...
                            sBearing = oSegment.Data.SourceData.Bearing
                        Else
                            sBearing = modPaint.GetBearing(oFromPoint, oToPoint)
                        End If

                        With oSegment.Data
                            Call .BackupData()
                            Call .SetData(sDistance, sBearing, sInclination, oSegment.Direction)
                        End With
                    End If
                End If
            Next
        End Sub

        Private Function pGetSketchRefStation(Sketch As Items.cItemSketch) As Items.cItemSketch.cStation()
            Dim sDistance As Single
            Dim sMaxDistance As Single = Single.MinValue
            Dim oCurrentStations() As Items.cItemSketch.cStation
            For Each oStation1 As Items.cItemSketch.cStation In Sketch.Stations
                For Each oStation2 As Items.cItemSketch.cStation In Sketch.Stations
                    If Not oStation1 Is oStation2 Then
                        sDistance = Math.Abs(oStation1.Point.X - oStation2.Point.X) * Math.Abs(oStation1.Point.Y - oStation2.Point.Y)
                        If sDistance > sMaxDistance Then
                            sMaxDistance = sDistance
                            oCurrentStations = {oStation1, oStation2}
                        End If
                    End If
                Next
            Next
            Return oCurrentStations
        End Function

        Friend Function pTrigPointsCalculate(Origin As String, ByVal SegmentsColl As List(Of cSegment)) As List(Of String)
            'creating the graph of connections between stations...
            Call oTPs.Clear()
            For Each oSegment As cSegment In SegmentsColl
                Dim sFrom As String = oSegment.[From]
                Dim sTo As String = oSegment.[To]
                Dim oTP As cTrigPoint
                Dim bEquate As Boolean = oSegment.IsEquate
                '->
                oTP = oTPs.Append(sFrom)
                If bEquate AndAlso oSurvey.Properties.CalculateVersion > 2 Then
                    Call oTP.Connections.AppendAsEquate(sTo)
                Else
                    Call oTP.Connections.AppendAsShot(sTo, oSegment.Distance, oSegment.Splay)
                End If
                '<-
                oTP = oTPs.Append(sTo)
                If bEquate AndAlso oSurvey.Properties.CalculateVersion > 2 Then
                    Call oTP.Connections.AppendAsEquate(sFrom)
                Else
                    Call oTP.Connections.AppendAsShot(sFrom, oSegment.Distance, oSegment.Splay)
                End If
            Next
            'check connections...starting from origin all station have to be processed
            Dim oStationsToProcess As HashSet(Of String) = New HashSet(Of String)(oTPs.ToList.Select(Function(oitem) oitem.Name).ToList)
            Call oStationsToProcess.Remove(Origin)
            Call pTrigpointCalculateGraph(Origin, oStationsToProcess)
            'is this usefull? the next calculate step will raise the same exception with better information
            'If oStationsToProcess.Count > 0 Then
            '    Dim oStations As List(Of cSurveyPC.cSurvey.cTrigPoint) = oStationsToProcess.Select(Function(sStation) oSurvey.TrigPoints(sStation)).ToList
            '    Call oCalculateData.Add(New cCalculateDataItem(Now, cCalculateDataItem.CalculateDataItemTypeEnum.Error, GetLocalizedString("calculate.textpart9"), oStations))
            '    Throw New cCalculateOrphanStationsException(oStations)
            'End If
            Return oStationsToProcess.ToList
        End Function

        Private Sub pTrigpointCalculateGraph(Station As String, StationsToProcess As HashSet(Of String))
            For Each oConnection As cTrigPointConnection In oTPs(Station).Connections
                If StationsToProcess.Contains(oConnection.Name) Then
                    If Not oSurvey.TrigPoints(Station).Connections.Get(oConnection.Name) Then
                        Call StationsToProcess.Remove(oConnection.Name)
                        Call pTrigpointCalculateGraph(oConnection.Name, StationsToProcess)
                    End If
                End If
            Next
        End Sub

        Public ReadOnly Property CalculateData As List(Of cCalculateDataItem)
            Get
                Return oCalculateData
            End Get
        End Property

        'Public Sub ArrangePriority()
        '    Call pArrangePriority(oSurvey.Segments.Cast(Of cSegment).ToList())
        'End Sub

        'Private Sub pArrangePriority(Segments As List(Of cSegment))
        '    Dim oSegmentsToArrange As List(Of cSegment) = Segments.Where(Function(segment) segment.Priority = -1).ToList
        '    Dim iNewPriority As Integer = GetNewPriority(Segments)
        '            For Each oSegment As cSegment In oSegmentsToArrange
        '                Call oSegment.SetPriority(iNewPriority)
        '            Next
        '    'test for priority by cave and branch...could generate problem
        '    ' case: shots 1-2 2-3 for branch A, 3-4 for branch B, 4-5 for branch A
        '    ' with this code calculation of section (extented elevation) not work!
        '    'Dim oSegmentsToArrange As List(Of cSegment) = Segments.Where(Function(segment) segment.Priority = -1).ToList
        '    'For Each sCave As String In oSegmentsToArrange.Select(Function(segment) segment.Cave).Distinct
        '    '            Dim oCaveSegmentsToArrange As List(Of cSegment) = oSegmentsToArrange.Where(Function(segment) segment.Cave = sCave).ToList 
        '    '            If oCaveSegmentsToArrange.Count > 0 Then
        '    '                For Each sBranch As String In oCaveSegmentsToArrange.Select(Function(segment) segment.Branch).Distinct
        '    '                    Dim oBranchSegmentsToArrange As List(Of cSegment) = oCaveSegmentsToArrange.Where(Function(segment) segment.Branch = sBranch).ToList
        '    '                    If oBranchSegmentsToArrange.Count > 0 Then
        '    '                        Dim iNewPriority As Integer = GetNewPriority(Segments)
        '    '                        Call Debug.Print(sCave & "\" & sBranch & " priority:" & iNewPriority)
        '    '                        For Each oSegment As cSegment In oBranchSegmentsToArrange
        '    '                            Call oSegment.SetPriority(iNewPriority)
        '    '                        Next
        '    '                    End If
        '    '                Next
        '    '            End If
        '    '        Next
        '    RaiseEvent OnArrangePriorityComplete(Me, New EventArgs)
        'End Sub

        'Friend Function GetNewPriority(ByVal Segments As List(Of cSegment)) As Integer
        '    Return Segments.Max(Function(segment) segment.Priority) + 1
        'End Function

        Private Function pFillSegments(ByVal Segments As List(Of cSegment)) As cSegmentGroupCollection
            Dim lOrdinalPosition As Long = 0
            Dim sExtendStart As String = oSurvey.Properties.Origin
            Dim oGroups As cSegmentGroupCollection = New cSegmentGroupCollection
            Dim oEmptyGroup As cSegmentGroup = New cSegmentGroup(sExtendStart, Integer.MinValue, Nothing, Nothing)
            Call oGroups.Add(oEmptyGroup)
            For Each oSegment As cSegment In Segments
                Dim oCaveInfo As cICaveInfoBranches = oSurvey.Properties.GetCaveInfo(oSegment)
                If IsNothing(oCaveInfo) Then
                    Call oEmptyGroup.Append(oSegment)
                Else
                    Call oGroups.NewOrExist(oCaveInfo).Append(oSegment)
                End If
                oSegment.Data.OrdinalPosition = lOrdinalPosition
                lOrdinalPosition += 1
                If Not oSegment.Color = Color.Transparent Then
                    oSegment.Data.SegmentColor = oSegment.Color
                End If
                Call oSegment.Data.CloneData(oSegment)
                Call oSegment.Data.ResetWarpingFactor()
            Next
            For Each oGroup As cSegmentGroup In oGroups
                If Not ((Not oGroup.HaveParentConnection AndAlso Not oGroup.HaveConnection) OrElse (oGroup.HaveParentConnection AndAlso oGroup.HaveConnection)) Then
                    Throw New cCalculateGroupConnectionMissingException(String.Format(modMain.GetLocalizedString("calculate.textpart10"), oGroup.ToString), oGroup)
                End If
            Next
            Return oGroups
        End Function
    End Class
End Namespace

