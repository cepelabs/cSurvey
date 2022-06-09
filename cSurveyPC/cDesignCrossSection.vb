Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Imports cSurveyPC.cSurvey.Calculate.Plot
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Design.Layers
Imports cSurveyPC.cSurvey.Calculate.Plot.cData

Namespace cSurvey.Design
    Public Class cDesignCrossSection
        Implements cISegment

        Private oSurvey As cSurvey

        Private sID As String

        Private oPlotData As cData
        Private iDesign As Integer = cIDesign.cDesignTypeEnum.Profile
        Private iCrossSection As Integer = -1
        Private oCrossSection As cItemCrossSection

        Private iPlanCrossSectionMarker As Integer = -1
        Private oPlanCrossSectionMarker As cItemPlanCrossSectionMarker
        Private iProfileCrossSectionMarker As Integer = -1
        Private oProfileCrossSectionMarker As cItemProfileCrossSectionMarker

        Public Function GetLocked() As Boolean Implements cISegment.GetLocked
            Dim oCaveInfo As cICaveInfoBranches = oCrossSection.GetCaveInfo
            If IsNothing(oCaveInfo) Then
                Return False
            Else
                Return oCaveInfo.GetLocked
            End If
        End Function

        Public Function GetCaveInfo() As cICaveInfoBranches Implements cISegment.GetCaveInfo
            Return oSurvey.Properties.GetCaveInfo(Me)
        End Function

        Public ReadOnly Property Index() As Integer
            Get
                Return oSurvey.CrossSections.IndexOf(Me)
            End Get
        End Property

        Friend Sub WarpItemsEx(ProfileWarpingFactor As cProfileWarpingFactor, Force As Boolean)
            If Not IsNothing(oCrossSection) Then
                If oCrossSection.Design.Type = cIDesign.cDesignTypeEnum.Profile AndAlso (ProfileWarpingFactor.IsChanged OrElse Force) Then
                    'creo 2 array, uno con i punti 'grotta' e uno con i punti grafici (che poi modificherò)
                    Dim oDesignPointArray As List(Of cPoint) = New List(Of cPoint)
                    Dim oPointArray As List(Of PointF) = New List(Of PointF)

                    For Each oLayer As cLayer In oCrossSection.Design.Layers
                        For Each oitem As cItem In oLayer.Items
                            If oitem.CanBeWarped AndAlso oitem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                                For Each oPoint As cPoint In oitem.Points
                                    If oPoint.BindedSegment Is Me Then
                                        Call oDesignPointArray.Add(oPoint)
                                        Call oPointArray.Add(New PointF(oPoint.X, oPoint.Y))
                                    End If
                                Next
                            End If
                        Next
                    Next

                    'se ho trovato almeno un punto da sottoporre a trasformazione...procedo...
                    If oDesignPointArray.Count > 0 Then
                        Dim oPoints() As PointF = oPointArray.ToArray

                        Using oMatrix As Matrix = New Matrix
                            Call oMatrix.Translate(-ProfileWarpingFactor.OldLocation.X, -ProfileWarpingFactor.OldLocation.Y, MatrixOrder.Append)
                            If ProfileWarpingFactor.OldAngle <> 0 Then
                                Call oMatrix.Rotate(ProfileWarpingFactor.OldAngle, MatrixOrder.Append)
                            End If
                            If ProfileWarpingFactor.DeltaSize <> 1 Then
                                Call oMatrix.Scale(ProfileWarpingFactor.DeltaSize, 1, MatrixOrder.Append)
                            End If
                            If ProfileWarpingFactor.NewAngle <> 0 Then
                                Call oMatrix.Rotate(-ProfileWarpingFactor.NewAngle, MatrixOrder.Append)
                            End If
                            Call oMatrix.Translate(ProfileWarpingFactor.NewLocation.X, ProfileWarpingFactor.NewLocation.Y, MatrixOrder.Append)
                            Call oMatrix.TransformPoints(oPoints)
                        End Using

                        Dim iDesignPointIndex As Integer = 0
                        For Each oDesignpoint As cPoint In oDesignPointArray
                            Call oDesignpoint.MoveTo(oPoints(iDesignPointIndex).X, oPoints(iDesignPointIndex).Y)
                            iDesignPointIndex += 1
                        Next
                    End If
                End If
            End If
        End Sub

        Friend Sub WarpItemsEx(PlanWarpingFactor As cPlanWarpingFactor, Force As Boolean)
            If Not IsNothing(oCrossSection) Then
                If oCrossSection.Design.Type = cIDesign.cDesignTypeEnum.Plan AndAlso (PlanWarpingFactor.IsChanged OrElse Force) Then
                    'creo 2 array, uno con i punti 'grotta' e uno con i punti grafici (che poi modificherò)
                    Dim oDesignPointArray As List(Of cPoint) = New List(Of cPoint)
                    Dim oPointArray As List(Of PointF) = New List(Of PointF)

                    For Each oLayer As cLayer In oCrossSection.Design.Layers
                        For Each oitem As cItem In oLayer.Items
                            If oitem.CanBeWarped AndAlso oitem.BindDesignType = cItem.BindDesignTypeEnum.CrossSections Then
                                For Each oPoint As cPoint In oitem.Points
                                    If oPoint.BindedSegment Is Me Then
                                        Call oDesignPointArray.Add(oPoint)
                                        Call oPointArray.Add(New PointF(oPoint.X, oPoint.Y))
                                    End If
                                Next
                            End If
                        Next
                    Next

                    'se ho trovato almeno un punto da sottoporre a trasformazione...procedo...
                    If oDesignPointArray.Count > 0 Then
                        Dim oPoints() As PointF = oPointArray.ToArray

                        Using oMatrix As Matrix = New Matrix
                            Call oMatrix.Translate(-PlanWarpingFactor.OldLocation.X, -PlanWarpingFactor.OldLocation.Y, MatrixOrder.Append)
                            If PlanWarpingFactor.OldAngle <> 0 Then
                                Call oMatrix.Rotate(PlanWarpingFactor.OldAngle, MatrixOrder.Append)
                            End If
                            If PlanWarpingFactor.DeltaSize <> 1 Then
                                Call oMatrix.Scale(PlanWarpingFactor.DeltaSize, 1, MatrixOrder.Append)
                            End If
                            If PlanWarpingFactor.NewAngle <> 0 Then
                                Call oMatrix.Rotate(-PlanWarpingFactor.NewAngle, MatrixOrder.Append)
                            End If
                            Call oMatrix.Translate(PlanWarpingFactor.NewLocation.X, PlanWarpingFactor.NewLocation.Y, MatrixOrder.Append)
                            Call oMatrix.TransformPoints(oPoints)
                        End Using

                        Dim iDesignPointIndex As Integer = 0
                        For Each oDesignpoint As cPoint In oDesignPointArray
                            Call oDesignpoint.MoveTo(oPoints(iDesignPointIndex).X, oPoints(iDesignPointIndex).Y)
                            iDesignPointIndex += 1
                        Next
                    End If
                End If
            End If
        End Sub

        Friend Sub WarpItems()
            If Not IsNothing(oCrossSection) Then
                If oCrossSection.Design.Type = cIDesign.cDesignTypeEnum.Profile Then
                    Call WarpItemsEx(Data.ProfileWarpingFactor, False)
                ElseIf oCrossSection.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                    Call WarpItemsEx(Data.PlanWarpingFactor, False)
                End If
            End If
        End Sub

        Public Function IsEquate() As Boolean Implements cISegment.IsEquate
            If IsNothing(oCrossSection) Then
                Return False
            Else
                If IsNothing(oCrossSection.Segment) Then
                    Return False
                Else
                    Return oCrossSection.Segment.IsEquate()
                End If
            End If
        End Function

        Public ReadOnly Property HaveMarkers As Boolean
            Get
                Return HavePlanMarker OrElse HaveProfileMarker
            End Get
        End Property

        Public ReadOnly Property HavePlanMarker As Boolean
            Get
                Return Not oPlanCrossSectionMarker Is Nothing
            End Get
        End Property

        Public ReadOnly Property HaveProfileMarker As Boolean
            Get
                Return Not oProfileCrossSectionMarker Is Nothing
            End Get
        End Property

        Public Sub DeleteProfileMarker()
            If Not oProfileCrossSectionMarker Is Nothing Then
                Call oSurvey.Profile.Layers.Item(cLayers.LayerTypeEnum.Signs).Items.Remove(oProfileCrossSectionMarker)
                oProfileCrossSectionMarker = Nothing
            End If
        End Sub

        Public Sub DeletePlanMarker()
            If Not oPlanCrossSectionMarker Is Nothing Then
                Call oSurvey.Plan.Layers.Item(cLayers.LayerTypeEnum.Signs).Items.Remove(oPlanCrossSectionMarker)
                oPlanCrossSectionMarker = Nothing
            End If
        End Sub

        Public Function CreatePlanMarker() As Boolean
            Dim oLayer As cLayerSigns = oSurvey.Plan.Layers.Item(cLayers.LayerTypeEnum.Signs)
            oPlanCrossSectionMarker = New cItemPlanCrossSectionMarker(oSurvey, oSurvey.Plan, oLayer, cIItem.cItemCategoryEnum.Sign, Me)
            Call oLayer.CreateCrossSectionMarker(oPlanCrossSectionMarker)
            Return True
        End Function

        Public Function CreateProfileMarker() As Boolean
            Dim oLayer As cLayerSigns = oSurvey.Profile.Layers.Item(cLayers.LayerTypeEnum.Signs)
            oProfileCrossSectionMarker = New cItemProfileCrossSectionMarker(oSurvey, oSurvey.Profile, oLayer, cIItem.cItemCategoryEnum.Sign, Me)
            Call oLayer.CreateCrossSectionMarker(oProfileCrossSectionMarker)
            Return True
        End Function

        Friend Sub AddPlanMarker(Item As cItemPlanCrossSectionMarker)
            Dim oLayer As cLayerSigns = oSurvey.Plan.Layers.Item(cLayers.LayerTypeEnum.Signs)
            Call oLayer.CreateCrossSectionMarker(Item)
            Call Item.RebindCrossSection(Me)
        End Sub

        Friend Sub AddProfileMarker(Item As cItemProfileCrossSectionMarker)
            Dim oLayer As cLayerSigns = oSurvey.Profile.Layers.Item(cLayers.LayerTypeEnum.Signs)
            Call oLayer.CreateCrossSectionMarker(Item)
            Call Item.RebindCrossSection(Me)
        End Sub

        Public ReadOnly Property PlanMarker As cItemPlanCrossSectionMarker
            Get
                Return oPlanCrossSectionMarker
            End Get
        End Property

        Public ReadOnly Property ProfileMarker As cItemProfileCrossSectionMarker
            Get
                Return oProfileCrossSectionMarker
            End Get
        End Property

        Public Function ToCSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegment.ToCSV
            Return oCrossSection.Segment.ToCSV(UseLocalFormat)
        End Function

        Public Function ToTSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegment.ToTSV
            Return oCrossSection.Segment.ToTSV(UseLocalFormat)
        End Function

        Public Function IsSelfDefined() As Boolean Implements cISegment.IsSelfDefined
            Return oCrossSection.Segment.IsSelfDefined
        End Function

        Public Function IsValid() As Boolean Implements cISegment.IsValid
            If IsNothing(oCrossSection) Then
                Return False
            Else
                If IsNothing(oCrossSection.Segment) Then
                    Return False
                Else
                    Return oCrossSection.Segment.IsValid()
                End If
            End If
        End Function

        Public Function IsBinded() As Boolean
            If IsNothing(oCrossSection) Then
                Return False
            Else
                For Each oItem As cSurveyPC.cSurvey.Design.cItem In oCrossSection.Design.GetAllItems
                    For Each opoint As cSurveyPC.cSurvey.Design.cPoint In oItem.Points
                        If opoint.BindedSegment Is Me Then
                            Return True
                        End If
                    Next
                Next
            End If
        End Function

        Public ReadOnly Property ID As String Implements cISegment.ID
            Get
                Return sID
            End Get
        End Property

        Public ReadOnly Property CrossSection As cItemCrossSection
            Get
                Return oCrossSection
            End Get
        End Property

        Friend ReadOnly Property Data As cData Implements cISegment.Data
            Get
                Return oPlotData
            End Get
        End Property

        Public Property From As String Implements cISegment.From
            Get
                Return oCrossSection.Segment.[From]
            End Get
            Set(ByVal value As String)
                oCrossSection.Segment.[From] = value
            End Set
        End Property

        Public Property Session As String Implements cISegment.Session
            Get
                Return oCrossSection.Segment.Session
            End Get
            Set(ByVal value As String)
                'nothing...is readonly
            End Set
        End Property

        Public Property [To] As String Implements cISegment.To
            Get
                Return oCrossSection.Segment.[To]
            End Get
            Set(ByVal value As String)
                oCrossSection.Segment.[To] = value
            End Set
        End Property

        Friend ReadOnly Property Type As cISegment.SegmentTypeEnum Implements cISegment.Type
            Get
                Return cISegment.SegmentTypeEnum.CrossSection
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal CrossSection As cItemCrossSection)
            oSurvey = Survey
            oCrossSection = CrossSection
            oPlotData = New Calculate.Plot.cData(oSurvey)
            If IsNothing(oCrossSection) Then
                sID = ""
            Else
                sID = Guid.NewGuid.ToString
                Call oCrossSection.RebindCrossSection(Me)
            End If

            iCrossSection = -1
            iPlanCrossSectionMarker = -1
            iProfileCrossSectionMarker = -1
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal CrossSection As XmlElement)
            oSurvey = Survey
            sID = CrossSection.GetAttribute("id")
            iDesign = modXML.GetAttributeValue(CrossSection, "design", cIDesign.cDesignTypeEnum.Profile)
            iCrossSection = CrossSection.GetAttribute("crosssection")
            If modXML.ChildElementExist(CrossSection, "data") Then
                oPlotData = New Calculate.Plot.cData(oSurvey, CrossSection.Item("data"))
            Else
                oPlotData = New Calculate.Plot.cData(oSurvey)
            End If
            iPlanCrossSectionMarker = modXML.GetAttributeValue(CrossSection, "planmarker", -1)
            iProfileCrossSectionMarker = modXML.GetAttributeValue(CrossSection, "profilemarker", -1)

            If modXML.ChildElementExist(CrossSection, "layers") Then
                'topodroid first file format (for legacy...no more supported)
                Dim oDesign As cDesign = Nothing
                If iDesign = cIDesign.cDesignTypeEnum.Profile Then
                    oDesign = oSurvey.Profile
                ElseIf iDesign = cIDesign.cDesignTypeEnum.Plan Then
                    oDesign = oSurvey.Plan
                End If
                oLayers = New cLayers(oSurvey, oDesign, File, CrossSection.Item("layers"))
            End If
        End Sub

        Private oLayers As cLayers

        Public ReadOnly Property Design As cDesign
            Get
                Return oCrossSection.Design
            End Get
        End Property

        Friend Sub RebindCrossSection()
            If iCrossSection <> -1 Then
                Dim oDesign As cDesign = Nothing
                If iDesign = cIDesign.cDesignTypeEnum.Profile Then
                    oDesign = oSurvey.Profile
                ElseIf iDesign = cIDesign.cDesignTypeEnum.Plan Then
                    oDesign = oSurvey.Plan
                End If
                oCrossSection = oDesign.Layers(cLayers.LayerTypeEnum.Signs).Items(iCrossSection)
                If Not IsNothing(oCrossSection) Then
                    Call oCrossSection.RebindCrossSection(Me)
                    iCrossSection = -1
                    iDesign = -1

                    If iPlanCrossSectionMarker <> -1 Then
                        oPlanCrossSectionMarker = oSurvey.Plan.Layers(cLayers.LayerTypeEnum.Signs).Items(iPlanCrossSectionMarker)
                        Call oPlanCrossSectionMarker.RebindCrossSection(Me)
                        iPlanCrossSectionMarker = -1
                    End If

                    If iProfileCrossSectionMarker <> -1 Then
                        oProfileCrossSectionMarker = oSurvey.Profile.Layers(cLayers.LayerTypeEnum.Signs).Items(iProfileCrossSectionMarker)
                        Call oProfileCrossSectionMarker.RebindCrossSection(Me)
                        iProfileCrossSectionMarker = -1
                    End If

                    If Not IsNothing(oLayers) Then
                        'translate and bind object the xsection design....
                        Dim oMoveBy As PointF = oCrossSection.Points(0).Point
                        For Each oLayer As cLayer In oLayers
                            For Each oItem As cItem In oLayer.GetAllItems
                                Call oItem.MoveBy(oMoveBy.X, oMoveBy.Y)
                                Call oItem.SetBindDesignType(cItem.BindDesignTypeEnum.CrossSections, Me, True)
                            Next
                        Next
                        'merge with main layers...
                        Call oDesign.Layers.MergeWith(oLayers)
                        oLayers = Nothing

                        Call oPlotData.Plan.ResetChange()
                        Call oPlotData.Profile.ResetChange()
                    End If
                End If
            End If
        End Sub

        Public Overrides Function ToString() As String
            If IsNothing(oCrossSection) Then
                Return ""
            Else
                If oCrossSection.Segment Is Nothing Then
                    Return "xs::>" & oCrossSection.Name
                Else
                    Return "xs::" & oCrossSection.Name & " sz::" & oCrossSection.Segment.From & ">" & oCrossSection.Segment.To
                End If
            End If
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            If Not IsNothing(oCrossSection) Then
                Dim oXmlCrossSection As XmlElement = Document.CreateElement("crosssection")
                Call oXmlCrossSection.SetAttribute("id", sID)
                If oCrossSection.Design.Type <> cIDesign.cDesignTypeEnum.Profile Then Call oXmlCrossSection.SetAttribute("design", oCrossSection.Design.Type.ToString("D"))
                Call oXmlCrossSection.SetAttribute("crosssection", oCrossSection.Design.Layers(cLayers.LayerTypeEnum.Signs).Items.IndexOf(oCrossSection))

                If Not oPlanCrossSectionMarker Is Nothing Then Call oXmlCrossSection.SetAttribute("planmarker", oSurvey.Plan.Layers(cLayers.LayerTypeEnum.Signs).Items.IndexOf(oPlanCrossSectionMarker))
                If Not oProfileCrossSectionMarker Is Nothing Then Call oXmlCrossSection.SetAttribute("profilemarker", oSurvey.Profile.Layers(cLayers.LayerTypeEnum.Signs).Items.IndexOf(oProfileCrossSectionMarker))

                Call oPlotData.SaveTo(File, Document, oXmlCrossSection)
                Call Parent.AppendChild(oXmlCrossSection)
                Return oXmlCrossSection
            End If
        End Function

        Public Function IsUnbindable() As Boolean Implements cISegment.IsUnbindable
            If IsNothing(oCrossSection) Then
                Return True
            Else
                If IsNothing(oCrossSection.Segment) Then
                    Return True
                Else
                    'not iherited from shot...correct?
                    Return False
                End If
            End If
        End Function

        '---------------------------------------------------------------------------------------------------
        'this property are needed for implementing cisegment...but use are deprecated
        Public Property Virtual() As Boolean Implements cISegment.Virtual
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nothing
            End Set
        End Property

        Public Property Splay() As Boolean Implements cISegment.Splay
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nothing
            End Set
        End Property

        Public Property Duplicate() As Boolean Implements cISegment.Duplicate
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nothing
            End Set
        End Property

        Public Property Calibration() As Boolean Implements cISegment.Calibration
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nothing
            End Set
        End Property

        Public Property Surface() As Boolean Implements cISegment.Surface
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nothing
            End Set
        End Property

        Public Property Exclude() As Boolean Implements cISegment.Exclude
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nothing
            End Set
        End Property
        '---------------------------------------------------------------------------------------------------

        Public ReadOnly Property Branch As String Implements cISegment.Branch
            Get
                Return oCrossSection.Branch
            End Get
        End Property

        Public ReadOnly Property Cave As String Implements cISegment.Cave
            Get
                Return oCrossSection.Cave
            End Get
        End Property
    End Class
End Namespace
