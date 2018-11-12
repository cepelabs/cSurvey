Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Calculate
Imports System.Xml
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey.Calculate.Plot
    Public Class cSpeleometrics
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private oItems As Dictionary(Of String, cSpeleometric)

        Friend Sub Calculate()
            Call oItems.Clear()
            For Each oCave As cCaveInfo In oSurvey.Properties.CaveInfos.GetWithEmpty().Values
                Dim sCave As String = oCave.Name
                For Each oBranch As cCaveInfoBranch In oCave.Branches.GetAllBranchesWithEmpty(True).Values
                    Dim sBranch As String = oBranch.Path

                    Dim oOptions As cOptionsDesign = New cOptionsDesign(oSurvey, "_info")
                    oOptions.DrawSplay = False
                    oOptions.DrawSegmentsOptions = cOptions.DrawSegmentsOptionsEnum.None

                    Dim oSegments As cISegmentCollection
                    Dim oPlanBounds As RectangleF
                    Dim oProfileBounds As RectangleF

                    Dim bComplex As Boolean = sCave = ""
                    Dim bBranch As Boolean = False

                    If bComplex Then
                        oSegments = oSurvey.Segments.GetSurveySegments
                        oPlanBounds = oSurvey.Plan.Plot.GetBounds(oOptions)
                        oProfileBounds = oSurvey.Profile.Plot.GetBounds(oOptions)
                    Else
                        If sBranch <> "" Then
                            bBranch = True
                        End If
                        oSegments = oSurvey.Segments.GetCaveSegments(sCave, sBranch)
                        oPlanBounds = oSurvey.Plan.Plot.GetCaveBounds(oOptions, sCave, sBranch)
                        oProfileBounds = oSurvey.Profile.Plot.GetCaveBounds(oOptions, sCave, sBranch)
                    End If

                    Dim oTrigPoints As cITrigPointCollection = oSegments.GetTrigPoints
                    Try
                        Dim dTotMeasured As Single = 0
                        Dim dTotReal As Single = 0
                        Dim dTotPlan As Single = 0
                        Dim dDisPos As Single = Single.MaxValue
                        Dim dDisNeg As Single = Single.MinValue
                        'Dim dDisTot As Single
                        Dim iSegmentCount As Integer = 0
                        Dim iExcludedSegmentCount As Integer = 0
                        For Each oSegment As cSegment In oSegments
                            Dim dMeasuredDistance As Single = oSegment.GetBaseDistance
                            dTotMeasured += dMeasuredDistance
                            If oSegment.Exclude Then
                                iExcludedSegmentCount += 1
                            Else
                                Dim dRealDistance As Single = oSegment.Data.Data.Distance
                                Dim sPlanDistance As Single = oSegment.Data.Plan.GetProjectedDistance 'modPaint.DistancePointToPoint(oSegment.Data.Plan.FromPoint, oSegment.Data.Plan.ToPoint)
                                dTotReal += dRealDistance
                                dTotPlan += sPlanDistance
                                iSegmentCount += 1
                            End If
                        Next

                        'dDisTot = 0
                        dDisNeg = 0
                        dDisPos = 0
                        Try
                            'dDisTot = oProfileBounds.Height
                            dDisNeg = oProfileBounds.Bottom
                            dDisPos = oProfileBounds.Top
                        Catch ex As Exception
                        End Try


                        Dim oSpeleometric As cSpeleometric
                        If bBranch Then
                            oSpeleometric = New cSpeleometric(oSurvey, sCave, sBranch, dTotReal, dTotPlan, dTotMeasured, 0, iSegmentCount, iExcludedSegmentCount, 0, dDisNeg - dDisPos, "", Nothing)
                        Else
                            Dim oMainCaveEntrance As cSurveyPC.cSurvey.cTrigPoint
                            If bComplex Then
                                oMainCaveEntrance = oTrigPoints.GetFirstEntrance(cSurveyPC.cSurvey.cTrigPoint.EntranceTypeEnum.MainComplexEntrance)
                            Else
                                oMainCaveEntrance = oTrigPoints.GetFirstEntrance(cSurveyPC.cSurvey.cTrigPoint.EntranceTypeEnum.MainCaveEntrace)
                            End If
                            Dim sEntrance As String = ""
                            Dim oEntranceCoordinate As Calculate.cTrigPointCoordinate = Nothing
                            Dim dEntranceZ As Decimal
                            If Not oMainCaveEntrance Is Nothing Then
                                sEntrance = oMainCaveEntrance.Name
                                oEntranceCoordinate = oSurvey.Calculate.TrigPoints(sEntrance).Coordinate
                                dEntranceZ = oSurvey.Calculate.TrigPoints(sEntrance).Point.Z
                                dDisPos = dDisPos - dEntranceZ
                                dDisNeg = dDisNeg - dEntranceZ
                            End If
                            oSpeleometric = New cSpeleometric(oSurvey, sCave, sBranch, dTotReal, dTotPlan, dTotMeasured, 0, iSegmentCount, iExcludedSegmentCount, dDisPos, dDisNeg, sEntrance, oEntranceCoordinate)
                        End If

                        Dim sKey As String = pFormatKey(sCave, sBranch)
                        Call oItems.Add(sKey, oSpeleometric)
                    Catch
                    End Try
                Next
            Next
        End Sub

        Private Function pFormatKey(Cave As String, Branch As String) As String
            Return Cave & cCaveInfoBranches.sBranchSeparator & Branch
        End Function

        Friend Sub Clear()
            Call oItems.Clear()
        End Sub

        Friend Sub Append(Cave As String, Branch As String, Speleometric As cSpeleometric)
            Dim sKey As String = pFormatKey(Cave, Branch)
            If oItems.ContainsKey(sKey) Then
                Call oItems.Remove(sKey)
            End If
            Call oItems.Add(sKey, Speleometric)
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Cave As String, Branch As String) As cSpeleometric
            Get
                Dim sKey As String = pFormatKey(Cave, Branch)
                If oItems.ContainsKey(sKey) Then
                    Return oItems(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSpeleometrics As XmlElement = Document.CreateElement("sms")
            For Each oItem As cSpeleometric In oItems.Values
                Call oItem.SaveTo(File, Document, oXmlSpeleometrics)
            Next
            Call Parent.AppendChild(oXmlSpeleometrics)
            Return oXmlSpeleometrics
        End Function

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cSpeleometric)(StringComparer.CurrentCultureIgnoreCase)
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal Speleometrics As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cSpeleometric)(StringComparer.CurrentCultureIgnoreCase)
            For Each oXMLItem As XmlElement In Speleometrics.ChildNodes
                Dim oItem As cSpeleometric = New cSpeleometric(oSurvey, oXMLItem)
                Dim sKey As String = pFormatKey(oItem.Cave, oItem.Branch)
                Call oItems.Add(sKey, oItem)
            Next
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class
End Namespace