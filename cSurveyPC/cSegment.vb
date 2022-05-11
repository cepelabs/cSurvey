Imports System.ComponentModel
Imports System.Xml
Imports cSurveyPC.cSurvey.Calculate
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey
    Public Class cSegment
        Implements cISegment
        Implements cIItemPlanSplayBorder
        Implements cIItemProfileSplayBorder
        Implements cISurfaceProfile
        Implements Data.cIObjectDataProperties

        Private oSurvey As cSurvey

        Private sID As String

        Friend Structure cData
            Public Session As String
            Public Cave As String
            Public Branch As String

            Public [From] As String
            Public [To] As String

            Public Distance As Decimal
            Public Bearing As Decimal
            Public Inclination As Decimal

            Public Up As Decimal
            Public Down As Decimal
            Public Right As Decimal
            Public Left As Decimal

            Public Direction As cSurvey.DirectionEnum

            Public UnBindable As Boolean
            Public Exclude As Boolean
            Public Surface As Boolean
            Public Duplicate As Boolean
            Public Splay As Boolean
            Public Calibration As Boolean

            Public Cut As Boolean
            Public ZSurvey As Boolean

            Public Virtual As Boolean
        End Structure

        Private oTempData As cData
        Private oCurrentData As cData
        Private oOldData As cData

        Private sNote As String
        Private oColor As Color

        Private iPlanSplayBorderProjectionType As Design.Items.cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum
        Private sPlanSplayBorderProjectionDeltaZ As Single
        Private sPlanSplayBorderMaxDeltaVariation As Single
        Private oPlanSplayBorderInclinationRange As SizeF

        Private iProfileSplayBorderProjectionAngle As Integer
        Private sProfileSplayBorderMaxAngleVariation As Single
        Private oProfileSplayBorderPosInclinationRange As SizeF
        Private oProfileSplayBorderNegInclinationRange As SizeF

        Private oPlotData As Calculate.Plot.cData

        Private bChanged As Boolean
        Private iInvalidated As cCalculate.InvalidateEnum

        Private oDataProperties As Data.cDataProperties

        Private iSurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum

        Private oAttachments As cAttachmentsLinks

        Friend Event OnSplayChange(ByVal Sender As cSegment)
        Friend Event OnChange(ByVal Sender As cSegment)
        Friend Event OnReassigned(ByVal sender As cSegment)

        Friend Class cGetSplayNameEventArgs
            Inherits EventArgs

            Private sBaseName As String
            Private sSplayName As String

            Public ReadOnly Property Basename As String
                Get
                    Return sBaseName
                End Get
            End Property

            Public Property SplayName As String
                Get
                    Return sSplayName
                End Get
                Set(value As String)
                    sSplayName = value
                End Set
            End Property

            Public Sub New(Basename As String)
                sBaseName = Basename
            End Sub
        End Class

        Friend Event OnGetSplayName(Sender As cSegment, Args As cGetSplayNameEventArgs)

        Public Enum DistanceTypeEnum
            Meters = 0
            Feet = 1
            Yards = 2
        End Enum

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean

        Public Overridable Property HiddenInDesign As Boolean
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                If bHiddenInDesign <> value Then
                    bHiddenInDesign = value
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Overridable Property HiddenInPreview As Boolean
            Get
                Return bHiddenInPreview
            End Get
            Set(value As Boolean)
                If bHiddenInPreview <> value Then
                    bHiddenInPreview = value
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Function GetHash() As String
            If oTempData.From < oTempData.To Then
                Return oTempData.From & "->" & oTempData.To
            Else
                Return oTempData.To & "->" & oTempData.From
            End If
        End Function

        Public ReadOnly Property DataProperties As Data.cDataProperties Implements Data.cIObjectDataProperties.DataProperties
            Get
                Return oDataProperties
            End Get
        End Property

        Shared Function GetBearingSimbol(BearingType As BearingTypeEnum) As String
            Select Case BearingType
                Case BearingTypeEnum.DecimalDegree
                    Return "°"
                Case BearingTypeEnum.CentesimalDegree
                    Return "g"
            End Select
        End Function

        Shared Function GetInclinationSimbol(InclinationType As InclinationTypeEnum) As String
            Select Case InclinationType
                Case InclinationTypeEnum.DecimalDegree
                    Return "°"
                Case InclinationTypeEnum.CentesimalDegree
                    Return "g"
                Case InclinationTypeEnum.Percentage
                    Return "%"
            End Select
        End Function

        Shared Function GetDistanceSimbol(DistanceType As DistanceTypeEnum) As String
            Select Case DistanceType
                Case DistanceTypeEnum.Meters
                    Return "m"
                Case DistanceTypeEnum.Feet
                    Return "ft"
                Case DistanceTypeEnum.Yards
                    Return "yd"
            End Select
        End Function

        Public Function GetDataFormat() As DataFormatEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.DataFormat
            Else
                If oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                    Return oSurvey.Properties.Sessions(oCurrentData.Session).DataFormat
                Else
                    Return oSurvey.Properties.DataFormat
                End If
            End If
        End Function

        Public ReadOnly Property Attachments As cAttachmentsLinks
            Get
                Return oAttachments
            End Get
        End Property

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Property ProfileSplayBorderMaxAngleVariation As Single Implements cIItemProfileSplayBorder.SplayBorderMaxAngleVariation
            Get
                Return sProfileSplayBorderMaxAngleVariation
            End Get
            Set(value As Single)
                If sProfileSplayBorderMaxAngleVariation <> value Then
                    sProfileSplayBorderMaxAngleVariation = value
                    Call oSurvey.Profile.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyProfileSplay
                    bChanged = True
                    RaiseEvent OnSplayChange(Me)
                End If
            End Set
        End Property

        Public Property PlanSplayBorderInclinationRange As SizeF Implements cIItemPlanSplayBorder.SplayBorderInclinationRange
            Get
                Return oPlanSplayBorderInclinationRange
            End Get
            Set(value As SizeF)
                If oPlanSplayBorderInclinationRange <> value Then
                    oPlanSplayBorderInclinationRange = value
                    Call oSurvey.Plan.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyProfileSplay
                    bChanged = True
                    RaiseEvent OnSplayChange(Me)
                End If
            End Set
        End Property

        Public Property ProfileSplayBorderNegInclinationRange As SizeF Implements cIItemProfileSplayBorder.SplayBorderNegInclinationRange
            Get
                Return oProfileSplayBorderNegInclinationRange
            End Get
            Set(value As SizeF)
                If oProfileSplayBorderNegInclinationRange <> value Then
                    oProfileSplayBorderNegInclinationRange = value
                    Call oSurvey.Profile.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyProfileSplay
                    bChanged = True
                    RaiseEvent OnSplayChange(Me)
                End If
            End Set
        End Property

        Public Property ProfileSplayBorderPosInclinationRange As SizeF Implements cIItemProfileSplayBorder.SplayBorderPosInclinationRange
            Get
                Return oProfileSplayBorderPosInclinationRange
            End Get
            Set(value As SizeF)
                If oProfileSplayBorderPosInclinationRange <> value Then
                    oProfileSplayBorderPosInclinationRange = value
                    Call oSurvey.Profile.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyProfileSplay
                    bChanged = True
                    RaiseEvent OnSplayChange(Me)
                End If
            End Set
        End Property

        Public Property ProfileSplayBorderProjectionAngle As Integer Implements cIItemProfileSplayBorder.SplayBorderProjectionAngle
            Get
                Return iProfileSplayBorderProjectionAngle
            End Get
            Set(value As Integer)
                If iProfileSplayBorderProjectionAngle <> value Then
                    iProfileSplayBorderProjectionAngle = value
                    Call oSurvey.Profile.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyProfileSplay
                    bChanged = True
                    RaiseEvent OnSplayChange(Me)
                End If
            End Set
        End Property

        Public Property PlanSplayBorderProjectionDeltaZ As Single Implements cIItemPlanSplayBorder.SplayBorderProjectionDeltaZ
            Get
                Return sPlanSplayBorderProjectionDeltaZ
            End Get
            Set(value As Single)
                If sPlanSplayBorderProjectionDeltaZ <> value Then
                    sPlanSplayBorderProjectionDeltaZ = value
                    Call oSurvey.Plan.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyPlanSplay
                    RaiseEvent OnSplayChange(Me)
                    bChanged = True
                End If
            End Set
        End Property

        Public Property PlanSplayBorderMaxDeltaVariation As Single Implements cIItemPlanSplayBorder.SplayBorderMaxDeltaVariation
            Get
                Return sPlanSplayBorderMaxDeltaVariation
            End Get
            Set(value As Single)
                If sPlanSplayBorderMaxDeltaVariation <> value Then
                    sPlanSplayBorderMaxDeltaVariation = value
                    Call oSurvey.Plan.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyPlanSplay
                    RaiseEvent OnSplayChange(Me)
                    bChanged = True
                End If
            End Set
        End Property

        Public Enum DataFormatEnum
            Normal = 0      'tape/clino/compass
            Cartesian = 1
            Diving = 2      'sub: tape/depth/compass
            Cylpolar = 3    'simile al precedente ma spostamentoinpianta/depth/compass
        End Enum

        Public Enum DepthTypeEnum
            AbsoluteAtEnd = 0
            AbsoluteAtBegin = 1
            Difference = 2
        End Enum

        Public Enum MeasureDirectionEnum
            Direct = 0
            Inverted = 1
        End Enum

        Public Enum InclinationTypeEnum
            DecimalDegree = 0
            CentesimalDegree = 1
            Percentage = 2
        End Enum

        Public Enum BearingTypeEnum
            DecimalDegree = 0
            CentesimalDegree = 1
        End Enum

        Public Enum NordTypeEnum
            Magnetic = 0
            Geographic = 1
        End Enum

        Public Enum SideMeasuresTypeEnum
            PerpendicularToPrevious = &H0
            Bisection = &H1
            PerpendicularToNext = &H2
        End Enum

        Public Enum SideMeasuresReferToEnum
            StartPoint = &H1
            EndPoint = &H0
        End Enum

        Friend Sub New(ByVal Survey As cSurvey, Optional [From] As String = "", Optional [To] As String = "")
            oSurvey = Survey

            sID = Guid.NewGuid.ToString

            oCurrentData.Session = ""
            oCurrentData.Cave = ""
            oCurrentData.Branch = ""

            oCurrentData.From = ""
            oCurrentData.To = ""

            oCurrentData.Distance = 0
            oCurrentData.Inclination = 0
            oCurrentData.Bearing = 0
            oCurrentData.Up = 0
            oCurrentData.Down = 0
            oCurrentData.Right = 0
            oCurrentData.Left = 0
            oCurrentData.Direction = cSurvey.DirectionEnum.Right
            oCurrentData.Virtual = False

            oCurrentData.Exclude = False
            oCurrentData.Splay = False
            oCurrentData.Cut = False
            oCurrentData.ZSurvey = False
            oCurrentData.Duplicate = False
            oCurrentData.Surface = False
            oCurrentData.Calibration = False

            oCurrentData.UnBindable = False

            oColor = Drawing.Color.Transparent

            sNote = ""

            iPlanSplayBorderProjectionType = cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.All
            sPlanSplayBorderProjectionDeltaZ = 0
            sPlanSplayBorderMaxDeltaVariation = 1
            oPlanSplayBorderInclinationRange = modSegmentsTools.GetDefaultPlanSplayBorderInclinationRange

            iProfileSplayBorderProjectionAngle = 0
            sProfileSplayBorderMaxAngleVariation = 20
            oProfileSplayBorderPosInclinationRange = modSegmentsTools.GetDefaultProfileSplayBorderPosInclinationRange
            oProfileSplayBorderNegInclinationRange = modSegmentsTools.GetDefaultProfileSplayBorderNegInclinationRange

            iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Default

            oPlotData = New Calculate.Plot.cData(oSurvey)

            oAttachments = New cAttachmentsLinks(oSurvey, Me)

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Segments)

            oTempData = oCurrentData
            bChanged = False
        End Sub

        Public Function IsUnbindable() As Boolean Implements cISegment.IsUnbindable
            Return Calibration OrElse oTempData.UnBindable OrElse oTempData.Splay OrElse IsEquate() OrElse IsSelfDefined() OrElse Not IsValid()
        End Function

        Public Property Unbindable As Boolean
            Get
                Return oTempData.UnBindable
            End Get
            Set(value As Boolean)
                If oTempData.UnBindable <> value Then
                    oTempData.UnBindable = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return "Sg::" & oCurrentData.From & ">" & oCurrentData.To & If(oCurrentData.Splay, "¤", "") & If(oCurrentData.Calibration, "~", "")
        End Function

        Public ReadOnly Property Index() As Integer
            Get
                Return oSurvey.Segments.IndexOf(Me)
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Segment As cSegment)
            oSurvey = Survey

            sID = Guid.NewGuid.ToString ' Segment.sID 

            oCurrentData.Cave = Segment.Cave
            oCurrentData.Branch = Segment.Branch
            oCurrentData.Session = Segment.Session

            oCurrentData.From = Segment.[From]
            oCurrentData.To = Segment.[To]

            oCurrentData.Distance = Segment.Distance
            oCurrentData.Inclination = Segment.Inclination
            oCurrentData.Bearing = Segment.Bearing
            oCurrentData.Up = Segment.Up
            oCurrentData.Down = Segment.Down
            oCurrentData.Right = Segment.Right
            oCurrentData.Left = Segment.Left
            oCurrentData.Direction = Segment.Direction

            oCurrentData.Virtual = Segment.Virtual
            oCurrentData.Exclude = Segment.Exclude
            oCurrentData.Surface = Segment.Surface
            oCurrentData.Splay = Segment.Splay
            oCurrentData.Cut = Segment.Cut
            oCurrentData.ZSurvey = Segment.ZSurvey
            oCurrentData.Duplicate = Segment.Duplicate
            oCurrentData.Calibration = Segment.Calibration

            oCurrentData.UnBindable = Segment.Unbindable

            oColor = Segment.oColor

            sNote = Segment.sNote

            iPlanSplayBorderProjectionType = Segment.iPlanSplayBorderProjectionType
            sPlanSplayBorderMaxDeltaVariation = Segment.sPlanSplayBorderMaxDeltaVariation
            sPlanSplayBorderProjectionDeltaZ = Segment.sPlanSplayBorderProjectionDeltaZ
            oPlanSplayBorderInclinationRange = Segment.oPlanSplayBorderInclinationRange

            iProfileSplayBorderProjectionAngle = Segment.iProfileSplayBorderProjectionAngle
            sProfileSplayBorderMaxAngleVariation = Segment.sProfileSplayBorderMaxAngleVariation
            oProfileSplayBorderPosInclinationRange = Segment.oProfileSplayBorderPosInclinationRange
            oProfileSplayBorderNegInclinationRange = Segment.oProfileSplayBorderNegInclinationRange

            iSurfaceProfileShow = Segment.iSurfaceProfileShow

            bHiddenInDesign = Segment.bHiddenInDesign
            bHiddenInPreview = Segment.bHiddenInPreview

            oPlotData = New Calculate.Plot.cData(oSurvey)

            oAttachments = New cAttachmentsLinks(oSurvey, Me, Segment.oAttachments)

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Segments)
            Call oDataProperties.CopyFrom(Segment.oDataProperties)

            oTempData = oCurrentData
            bChanged = False
        End Sub

        Public Property Calibration() As Boolean Implements cISegment.Calibration
            Get
                Return oTempData.Calibration
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.Calibration Then
                    oTempData.Calibration = value
                    If oTempData.Calibration Then
                        oTempData.Exclude = True
                        oTempData.Cave = ""
                        oTempData.Branch = ""
                    End If
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Duplicate() As Boolean Implements cISegment.Duplicate
            Get
                Return oTempData.Duplicate
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.Duplicate Then
                    oTempData.Duplicate = value
                    If oTempData.Duplicate Then oTempData.Exclude = True
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Surface() As Boolean Implements cISegment.Surface
            Get
                Return oTempData.Surface
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.Surface Then
                    oTempData.Surface = value
                    If oTempData.Surface Then oTempData.Exclude = True
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Cut() As Boolean
            Get
                Return oTempData.Cut
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.Cut Then
                    oTempData.Cut = value
                    If oTempData.Cut Then
                        oTempData.Splay = True
                        oTempData.Exclude = True
                    End If
                    bChanged = True
                End If
            End Set
        End Property

        Public Property ZSurvey() As Boolean
            Get
                Return oTempData.ZSurvey
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.ZSurvey Then
                    oTempData.ZSurvey = value
                    If oTempData.ZSurvey Then
                        oTempData.Splay = False
                        oTempData.Cut = False
                        oTempData.Exclude = (oTempData.Splay Or oTempData.Surface Or oTempData.Duplicate)
                    End If
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Splay() As Boolean Implements cISegment.Splay
            Get
                Return oTempData.Splay
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.Splay Then
                    oTempData.Splay = value
                    If oTempData.Splay Then oTempData.Exclude = True
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Exclude() As Boolean Implements cISegment.Exclude
            Get
                Return oTempData.Exclude
            End Get
            Set(ByVal value As Boolean)
                If value <> oTempData.Exclude Then
                    oTempData.Exclude = value Or (oTempData.Splay Or oTempData.Surface Or oTempData.Duplicate)
                    bChanged = True
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Segment As XmlElement)
            oSurvey = Survey

            sID = modXML.GetAttributeValue(Segment, "id", "")
            If sID = "" Then sID = Guid.NewGuid.ToString

            oCurrentData.From = modXML.GetAttributeValue(Segment, "from", "")
            oCurrentData.To = modXML.GetAttributeValue(Segment, "to", "")

            oCurrentData.Distance = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "distance"))
            oCurrentData.Inclination = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "inclination"))
            oCurrentData.Bearing = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "bearing"))

            oCurrentData.Left = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "l", 0))
            oCurrentData.Right = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "r", 0))
            oCurrentData.Up = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "u", 0))
            oCurrentData.Down = modNumbers.StringToDecimal(modXML.GetAttributeValue(Segment, "d", 0))

            oCurrentData.Virtual = modXML.GetAttributeValue(Segment, "virtual", 0)

            If Segment.HasAttribute("inverted") Then
                'this is for legacy old csurvey file format using relative inversion (no more supported)
                oCurrentData.Direction = If(modXML.GetAttributeValue(Segment, "inverted"), cSurvey.DirectionEnum.Left, cSurvey.DirectionEnum.Right)
            Else
                oCurrentData.Direction = modXML.GetAttributeValue(Segment, "direction", cSurvey.DirectionEnum.Right.ToString("D"))
            End If
            'check direction (I don't remember why this have to be done...)
            If oCurrentData.Direction > cSurvey.DirectionEnum.Vertical Then oCurrentData.Direction = cSurvey.DirectionEnum.Right

            oCurrentData.Exclude = modXML.GetAttributeValue(Segment, "exclude")
            oCurrentData.Splay = modXML.GetAttributeValue(Segment, "splay")
            oCurrentData.Cut = modXML.GetAttributeValue(Segment, "cut")
            oCurrentData.ZSurvey = modXML.GetAttributeValue(Segment, "zsurvey")
            oCurrentData.Duplicate = modXML.GetAttributeValue(Segment, "duplicate")
            oCurrentData.Surface = modXML.GetAttributeValue(Segment, "surface")
            oCurrentData.Calibration = modXML.GetAttributeValue(Segment, "calibration")
            If Not oCurrentData.Splay AndAlso oCurrentData.Cut Then oCurrentData.Splay = True
            If Not oCurrentData.Exclude AndAlso (oCurrentData.Splay OrElse oCurrentData.Duplicate OrElse oCurrentData.Surface OrElse oCurrentData.Calibration) Then oCurrentData.Exclude = True

            oCurrentData.UnBindable = modXML.GetAttributeValue(Segment, "unbindable")

            oColor = modXML.GetAttributeColor(Segment, "color", Drawing.Color.Transparent)
            oCurrentData.Cave = modXML.GetAttributeValue(Segment, "cave", "")
            oCurrentData.Branch = modXML.GetAttributeValue(Segment, "branch", "")

            oCurrentData.Session = modXML.GetAttributeValue(Segment, "session", "")
            If oCurrentData.Session = "00010101_" Then oCurrentData.Session = ""

            'sName = modXML.GetAttributeValue(Segment, "name", "")
            sNote = modXML.GetAttributeValue(Segment, "note", "")

            iPlanSplayBorderProjectionType = modNumbers.StringToInteger(modXML.GetAttributeValue(Segment, "plansplayprojectiontype", Design.Items.cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.All))
            sPlanSplayBorderMaxDeltaVariation = modNumbers.StringToSingle(modXML.GetAttributeValue(Segment, "plansplaymaxdeltavariation", 1))
            sPlanSplayBorderProjectionDeltaZ = modNumbers.StringToSingle(modXML.GetAttributeValue(Segment, "plansplaydeltaz", 0))
            oPlanSplayBorderInclinationRange = modNumbers.StringToSizeF(modXML.GetAttributeValue(Segment, "plansplayborderinclinationrange", "-90;90"))

            iProfileSplayBorderProjectionAngle = modNumbers.StringToInteger(modXML.GetAttributeValue(Segment, "profilesplayborderprojectionangle", 0))
            sProfileSplayBorderMaxAngleVariation = modNumbers.StringToSingle(modXML.GetAttributeValue(Segment, "profilesplaybordermaxanglevariation", 20))
            oProfileSplayBorderPosInclinationRange = modNumbers.StringToSizeF(modXML.GetAttributeValue(Segment, "profilesplayborderposinclinationrange", "0;90"))
            oProfileSplayBorderNegInclinationRange = modNumbers.StringToSizeF(modXML.GetAttributeValue(Segment, "profilesplayborderneginclinationrange", "-90;0"))

            iSurfaceProfileShow = modNumbers.StringToInteger(modXML.GetAttributeValue(Segment, "surfaceprofileshow", 0))

            bHiddenInDesign = modXML.GetAttributeValue(Segment, "hiddenindesign")
            bHiddenInPreview = modXML.GetAttributeValue(Segment, "hiddeninpreview")

            If modXML.ChildElementExist(Segment, "data") Then
                oPlotData = New Calculate.Plot.cData(oSurvey, Segment.Item("data"))
            Else
                oPlotData = New Calculate.Plot.cData(oSurvey)
            End If

            If modXML.ChildElementExist(Segment, "attachments") Then
                oAttachments = New cAttachmentsLinks(oSurvey, Me, Segment.Item("attachments"))
            Else
                oAttachments = New cAttachmentsLinks(oSurvey, Me)
            End If

            If modXML.ChildElementExist(Segment, "datarow") Then
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Segments, Segment.Item("datarow"))
            Else
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.Segments)
            End If

            oTempData = oCurrentData
            oOldData = oCurrentData

            If oSurvey.Properties.CreatorID.ToLower = "topodroid" Then
                If Segment.HasAttribute("g") Then oDataProperties.SetValue("distox_g", modNumbers.StringToSingle(Segment.GetAttribute("g")))
                If Segment.HasAttribute("m") Then oDataProperties.SetValue("distox_m", modNumbers.StringToSingle(Segment.GetAttribute("m")))
                If Segment.HasAttribute("dip") Then oDataProperties.SetValue("distox_dip", modNumbers.StringToSingle(Segment.GetAttribute("dip")))
                If Segment.HasAttribute("distox") Then oDataProperties.SetValue("distox", Segment.GetAttribute("distox"))
            End If

            bChanged = False
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlSegment As XmlElement = Document.CreateElement("segment")

            Call oXmlSegment.SetAttribute("id", sID)

            Call oXmlSegment.SetAttribute("from", oCurrentData.From)
            Call oXmlSegment.SetAttribute("to", oCurrentData.To)
            Call oXmlSegment.SetAttribute("distance", modNumbers.NumberToString(oCurrentData.Distance))
            Call oXmlSegment.SetAttribute("inclination", modNumbers.NumberToString(oCurrentData.Inclination))
            Call oXmlSegment.SetAttribute("bearing", modNumbers.NumberToString(oCurrentData.Bearing))

            If oCurrentData.Left <> 0 Then Call oXmlSegment.SetAttribute("l", modNumbers.NumberToString(oCurrentData.Left))
            If oCurrentData.Right <> 0 Then Call oXmlSegment.SetAttribute("r", modNumbers.NumberToString(oCurrentData.Right))
            If oCurrentData.Up <> 0 Then Call oXmlSegment.SetAttribute("u", modNumbers.NumberToString(oCurrentData.Up))
            If oCurrentData.Down <> 0 Then Call oXmlSegment.SetAttribute("d", modNumbers.NumberToString(oCurrentData.Down))

            If oCurrentData.Virtual Then Call oXmlSegment.SetAttribute("virtual", "1")
            If oCurrentData.Direction <> cSurvey.DirectionEnum.Right Then Call oXmlSegment.SetAttribute("direction", oCurrentData.Direction.ToString("D"))

            If oCurrentData.Exclude Then Call oXmlSegment.SetAttribute("exclude", "1")
            If oCurrentData.Splay Then Call oXmlSegment.SetAttribute("splay", "1")
            If oCurrentData.Cut Then Call oXmlSegment.SetAttribute("cut", "1")
            If oCurrentData.ZSurvey Then Call oXmlSegment.SetAttribute("zsurvey", "1")
            If oCurrentData.Surface Then Call oXmlSegment.SetAttribute("surface", "1")
            If oCurrentData.Duplicate Then Call oXmlSegment.SetAttribute("duplicate", "1")
            If oCurrentData.Calibration Then Call oXmlSegment.SetAttribute("calibration", "1")

            If oCurrentData.UnBindable Then Call oXmlSegment.SetAttribute("unbindable", "1")

            If oColor <> Drawing.Color.Transparent And Not oColor.IsEmpty Then
                Call oXmlSegment.SetAttribute("color", oColor.ToArgb)
            End If

            If oCurrentData.Cave <> "" Then Call oXmlSegment.SetAttribute("cave", oCurrentData.Cave)
            If oCurrentData.Branch <> "" Then Call oXmlSegment.SetAttribute("branch", oCurrentData.Branch)
            If oCurrentData.Session <> "" Then Call oXmlSegment.SetAttribute("session", oCurrentData.Session)

            If sNote <> "" Then Call oXmlSegment.SetAttribute("note", sNote)

            If iPlanSplayBorderProjectionType <> Design.Items.cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.All Then Call oXmlSegment.SetAttribute("plansplayprojectiontype", iPlanSplayBorderProjectionType)
            If sPlanSplayBorderProjectionDeltaZ <> 0 Then Call oXmlSegment.SetAttribute("plansplaydeltaz", modNumbers.NumberToString(sPlanSplayBorderProjectionDeltaZ, "0.0"))
            If sPlanSplayBorderMaxDeltaVariation <> 1.0F Then Call oXmlSegment.SetAttribute("plansplaymaxdeltavariation", modNumbers.NumberToString(sPlanSplayBorderMaxDeltaVariation, "0.0"))
            If Not oPlanSplayBorderInclinationRange <> modSegmentsTools.GetDefaultPlanSplayBorderInclinationRange Then Call oXmlSegment.SetAttribute("plansplayborderinclinationrange", modNumbers.SizeFToString(oPlanSplayBorderInclinationRange, "0.0"))

            If iProfileSplayBorderProjectionAngle <> 0 Then Call oXmlSegment.SetAttribute("profilesplayborderprojectionangle", iProfileSplayBorderProjectionAngle)
            If sProfileSplayBorderMaxAngleVariation <> 20 Then Call oXmlSegment.SetAttribute("profilesplaybordermaxanglevariation", modNumbers.NumberToString(sProfileSplayBorderMaxAngleVariation))
            If Not oProfileSplayBorderPosInclinationRange <> modSegmentsTools.GetDefaultProfileSplayBorderPosInclinationRange Then Call oXmlSegment.SetAttribute("profilesplayborderposinclinationrange", modNumbers.SizeFToString(oProfileSplayBorderPosInclinationRange, "0.0"))
            If Not oProfileSplayBorderNegInclinationRange <> modSegmentsTools.GetDefaultProfileSplayBorderNegInclinationRange Then Call oXmlSegment.SetAttribute("profilesplayborderneginclinationrange", modNumbers.SizeFToString(oProfileSplayBorderNegInclinationRange, "0.0"))

            If iSurfaceProfileShow <> cISurfaceProfile.SurfaceProfileShowEnum.Default Then Call oXmlSegment.SetAttribute("surfaceprofileshow", iSurfaceProfileShow.ToString("D"))

            If bHiddenInDesign Then Call oXmlSegment.SetAttribute("hiddenindesign", "1")
            If bHiddenInPreview Then Call oXmlSegment.SetAttribute("hiddeninpreview", "1")

            Call oPlotData.SaveTo(File, Document, oXmlSegment)

            Call oAttachments.SaveTo(File, Document, oXmlSegment)

            If oDataProperties.Count <> 0 Then Call oDataProperties.SaveTo(File, Document, oXmlSegment, Options)

            Call Parent.AppendChild(oXmlSegment)

            Return oXmlSegment
        End Function

        Friend ReadOnly Property Data() As Calculate.Plot.cData Implements cISegment.Data
            Get
                Return oPlotData
            End Get
        End Property

        Friend Sub RenameCave(ByVal Cave As String)
            oCurrentData.Cave = Cave
            oTempData.Cave = Cave
        End Sub

        Friend Sub RenameCave(ByVal Cave As String, ByVal Branch As String)
            oCurrentData.Cave = Cave
            oTempData.Cave = Cave
            oCurrentData.Branch = Branch
            oTempData.Branch = Branch
        End Sub

        Friend Sub RenameSession(ByVal Session As String)
            oCurrentData.Session = Session
            oTempData.Session = Session
        End Sub

        Public Overridable Sub SetSession(ByVal ID As String)
            If IsNothing(ID) Then ID = ""
            If oTempData.Session <> ID AndAlso Not oTempData.Virtual Then
                oTempData.Session = ID
                bChanged = True
            End If
        End Sub

        Public Overridable Sub SetSession(ByVal Session As cSession)
            If IsNothing(Session) Then
                Call SetSession("")
            Else
                Call SetSession(Session.ID)
            End If
        End Sub

        Public ReadOnly Property Session As String Implements cISegment.Session
            Get
                Return oTempData.Session
            End Get
        End Property

        Private Sub pRebind()
            For Each oItem As Design.cItem In oSurvey.Plan.GetAllItems
                If oItem.IsBindedTo(Me) Then
                    Call oItem.BindSegments()
                End If
            Next
            For Each oItem As Design.cItem In oSurvey.Profile.GetAllItems
                If oItem.IsBindedTo(Me) Then
                    Call oItem.BindSegments()
                End If
            Next
        End Sub

        Public Overridable Sub SetCave(ByVal Cave As cCaveInfo, Optional ByVal Branch As cCaveInfoBranch = Nothing)
            If Cave Is Nothing Then
                Call SetCave("")
            Else
                Call SetCave(Cave.Name, If(Branch Is Nothing, "", Branch.Path))
            End If
        End Sub

        Public Overridable Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "")
            If ((Cave <> oTempData.Cave) OrElse (Branch <> oTempData.Branch)) AndAlso Not oTempData.Calibration Then
                oTempData.Cave = Cave
                oTempData.Branch = Branch
                bChanged = True
            End If
        End Sub

        Public Function GetLocked() As Boolean Implements cISegment.GetLocked
            Dim oCaveInfo As cICaveInfoBranches = GetCaveInfo()
            If IsNothing(oCaveInfo) Then
                Return False
            Else
                Return oCaveInfo.GetLocked
            End If
        End Function

        Public Function GetSession() As cSession
            Return oSurvey.Properties.Sessions.getsession(Me)
        End Function

        Public Function GetCaveInfo() As cICaveInfoBranches
            Return oSurvey.Properties.GetCaveInfo(Me)
        End Function

        Public ReadOnly Property Cave() As String Implements cISegment.Cave
            Get
                Return oTempData.Cave
            End Get
        End Property

        Public ReadOnly Property Branch() As String Implements cISegment.Branch
            Get
                Return oTempData.Branch
            End Get
        End Property

        Public Property Note() As String
            Get
                Return sNote
            End Get
            Set(ByVal value As String)
                If sNote <> value Then
                    sNote = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If oColor <> value Then
                    oColor = value
                    bChanged = True
                End If
            End Set
        End Property

        Friend Sub RenameFrom(ByVal NewName As String)
            oTempData.From = NewName
            oCurrentData.From = oTempData.From
            oOldData.From = oTempData.From
            Call oPlotData.RenameFrom(oTempData.From)

            If oSurvey.Properties.SplayMode = cSurvey.SplayModeEnum.Automatic Then
                If (oTempData.To = "" And oTempData.[From] <> "") Or (oTempData.To Like "*(*)" And Not (oTempData.From Like "*(*)")) Then
                    Dim oArgs As cGetSplayNameEventArgs = New cGetSplayNameEventArgs(oTempData.From)
                    RaiseEvent OnGetSplayName(Me, oArgs)
                    Dim sNewName As String = oArgs.SplayName
                    'Call oSurvey.TrigPoints.RenameTrigPoint(oTempData.To, sNewName)
                    oTempData.To = sNewName
                    oCurrentData.To = oTempData.To
                    oOldData.To = oTempData.To
                    Call oPlotData.RenameTo(oTempData.To)

                    Splay = True
                    Call Save()
                End If
            End If
        End Sub

        Friend Sub RenameTo(ByVal NewName As String)
            oTempData.To = NewName
            oCurrentData.To = oTempData.To
            oOldData.To = oTempData.To
            Call oPlotData.RenameTo(oTempData.To)

            If oSurvey.Properties.SplayMode = cSurvey.SplayModeEnum.Automatic Then
                If (oTempData.To <> "" And oTempData.[From] = "") Or (Not (oTempData.To Like "*(*)") And oTempData.From Like "*(*)") Then
                    Dim oArgs As cGetSplayNameEventArgs = New cGetSplayNameEventArgs(oTempData.To)
                    RaiseEvent OnGetSplayName(Me, oArgs)
                    Dim sNewName As String = oArgs.SplayName
                    'Call oSurvey.TrigPoints.RenameTrigPoint(oTempData.From, sNewName)
                    oTempData.From = sNewName
                    oCurrentData.From = oTempData.From
                    oOldData.From = oTempData.From

                    Call oPlotData.RenameFrom(oTempData.From)

                    Splay = True
                    Call Save()
                End If
            End If
        End Sub

        Public Function IsEquate() As Boolean Implements cISegment.IsEquate
            Return oCurrentData.Distance = 0 AndAlso oCurrentData.Bearing = 0 AndAlso oCurrentData.Inclination = 0 AndAlso not oCurrentData.Virtual 
        End Function

        Public Function IsSelfDefined() As Boolean Implements cISegment.IsSelfDefined
            Return oCurrentData.[To] = oCurrentData.[From]
        End Function

        Public Function IsValid() As Boolean Implements cISegment.IsValid
            Return ("" & oCurrentData.[To]) <> "" And ("" & oCurrentData.[From]) <> ""
        End Function

        Public Function IsPlanBinded() As Boolean
            For Each oItem As cSurveyPC.cSurvey.Design.cItem In oSurvey.Plan.GetAllItems
                For Each opoint As cSurveyPC.cSurvey.Design.cPoint In oItem.Points
                    If opoint.BindedSegment Is Me Then
                        Return True
                    End If
                Next
            Next
        End Function

        Public Function IsProfileBinded() As Boolean
            For Each oItem As cSurveyPC.cSurvey.Design.cItem In oSurvey.Profile.GetAllItems
                For Each opoint As cSurveyPC.cSurvey.Design.cPoint In oItem.Points
                    If opoint.BindedSegment Is Me Then
                        Return True
                    End If
                Next
            Next
        End Function

        Public Function IsOrigin() As Boolean
            If oSurvey.Properties.Origin = "" Then
                Return False
            Else
                Return oSurvey.Properties.Origin = oCurrentData.[From] Or oSurvey.Properties.Origin = oCurrentData.[To]
            End If
        End Function

        Public Function IsBinded() As Boolean
            Return IsPlanBinded() Or IsProfileBinded()
        End Function

        Public Sub Cancel()
            oTempData = oCurrentData
            bChanged = False
        End Sub

        <Flags> Public Enum SaveOptionsEnum
            None = 0
            EventRaisingDisable = &H1
            CaveBranchSplayAutoAssignmentDisable = &H100
        End Enum

        <Description("For special use only")> Friend Sub SetDirection(Direction As cSurvey.DirectionEnum)
            oTempData.Direction = Direction
            oCurrentData.Direction = Direction
            bChanged = True
        End Sub

        Public Sub Save(Optional RebindItem As Boolean = False, Optional Options As SaveOptionsEnum = SaveOptionsEnum.None)
            If bChanged Then
                oOldData = oCurrentData

                If oSurvey.Properties.SplayMode = cSurvey.SplayModeEnum.Automatic Then
                    If (oTempData.To = "" And oTempData.[From] <> "") Or (oTempData.To Like "*(*)" And Not (oTempData.From Like "*(*)") And oTempData.From <> oCurrentData.From) Then
                        Dim oArgs As cGetSplayNameEventArgs = New cGetSplayNameEventArgs(oTempData.From)
                        RaiseEvent OnGetSplayName(Me, oArgs)
                        oTempData.To = oArgs.SplayName
                        oTempData.Exclude = True
                        oTempData.Splay = True
                    ElseIf (oTempData.To <> "" And oTempData.[From] = "") Or (Not (oTempData.To Like "*(*)") And oTempData.From Like "*(*)" And oTempData.To <> oCurrentData.To) Then
                        Dim oArgs As cGetSplayNameEventArgs = New cGetSplayNameEventArgs(oTempData.To)
                        RaiseEvent OnGetSplayName(Me, oArgs)
                        oTempData.From = oArgs.SplayName
                        oTempData.Exclude = True
                        oTempData.Splay = True
                    End If
                Else
                    'in manual check if shot is a splay...if this check if the name in like *(*) and rename it if not ok
                    If oTempData.Splay Then
                        If (oTempData.To Like "*(*)" And Not (oTempData.From Like "*(*)")) AndAlso Not oTempData.To Like oTempData.From & "(*)" Then
                            Dim oArgs As cGetSplayNameEventArgs = New cGetSplayNameEventArgs(oTempData.From)
                            RaiseEvent OnGetSplayName(Me, oArgs)
                            oTempData.To = oArgs.SplayName
                        ElseIf (oTempData.From Like "*(*)" And Not (oTempData.To Like "*(*)")) AndAlso Not oTempData.From Like oTempData.To & "(*)" Then
                            Dim oArgs As cGetSplayNameEventArgs = New cGetSplayNameEventArgs(oTempData.To)
                            RaiseEvent OnGetSplayName(Me, oArgs)
                            oTempData.From = oArgs.SplayName
                        End If
                    End If
                End If

                'if direction is changed...check if profile is binded and, if so, cancel the direction change..
                If Not oTempData.Splay Then
                    If oCurrentData.Direction <> oTempData.Direction Then
                        If IsProfileBinded() Then
                            oTempData.Direction = oCurrentData.Direction
                        End If
                    End If
                End If

                Dim bPerformSegmentRebind As Boolean = RebindItem OrElse oCurrentData.Splay <> oTempData.Splay OrElse oCurrentData.UnBindable <> oTempData.UnBindable OrElse oCurrentData.Cave <> oTempData.Cave OrElse oCurrentData.Branch <> oTempData.Branch

                oCurrentData = oTempData

                If oOldData.From <> oCurrentData.From Then
                    Call oPlotData.RenameFrom(oCurrentData.From)
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                End If
                If oOldData.To <> oCurrentData.To Then
                    Call oPlotData.RenameTo(oCurrentData.To)
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                End If

                Dim bCaveOrBranchChanged As Boolean
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Session <> oCurrentData.Session Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Cave <> oCurrentData.Cave Then
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                    bCaveOrBranchChanged = True
                End If
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Branch <> oCurrentData.Branch Then
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                    bCaveOrBranchChanged = True
                End If

                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Direction <> oCurrentData.Direction Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate

                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Distance <> oCurrentData.Distance Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Inclination <> oCurrentData.Inclination Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Bearing <> oCurrentData.Bearing Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate

                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Up <> oCurrentData.Up Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.PartialCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Down <> oCurrentData.Down Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.PartialCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Right <> oCurrentData.Right Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.PartialCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Left <> oCurrentData.Left Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.PartialCalculate

                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Exclude <> oCurrentData.Exclude Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Surface <> oCurrentData.Surface Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Duplicate <> oCurrentData.Duplicate Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Splay <> oCurrentData.Splay Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Cut <> oCurrentData.Cut Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.UnBindable <> oCurrentData.UnBindable Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.PartialCalculate
                If iInvalidated = cCalculate.InvalidateEnum.None And oOldData.Virtual <> oCurrentData.Virtual Then iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.FullCalculate

                If (Options And SaveOptionsEnum.CaveBranchSplayAutoAssignmentDisable) = 0 AndAlso bCaveOrBranchChanged AndAlso Not oCurrentData.Splay Then
                    Call pReassignSplay(oCurrentData.From, oCurrentData.To)
                    Call pReassignSplay(oCurrentData.From)
                    Call pReassignSplay(oCurrentData.To)
                End If

                If (Options And SaveOptionsEnum.EventRaisingDisable) = 0 Then RaiseEvent OnChange(Me)
                Call ResetChange()

                If bPerformSegmentRebind Then
                    Call pRebind()
                End If
            End If
        End Sub

        Private Sub pReassignSplay([From] As String, [To] As String)
            Dim oSegments As List(Of cSegment) = oSurvey.Segments.Where(Function(oitem) Not oitem Is Me AndAlso ((oitem.From = [From] AndAlso oitem.To = [To]) OrElse (oitem.From = [To] AndAlso oitem.To = [From]))).Cast(Of cSegment).ToList
            For Each oSegment As cSegment In oSegments
                Call oSegment.SetCave(oCurrentData.Cave, oCurrentData.Branch)
                If oSegment.Changed Then
                    Call oSegment.Save(False, SaveOptionsEnum.EventRaisingDisable Or SaveOptionsEnum.CaveBranchSplayAutoAssignmentDisable)
                    RaiseEvent OnReassigned(oSegment)
                End If
            Next
        End Sub

        Private Sub pReassignSplay(Station As String)
            'get all shots with this stations...
            Dim oSegments As List(Of cSegment) = oSurvey.Segments.Find(Station).Cast(Of cSegment).ToList
            'get all standard shots
            Dim oSameSegments As List(Of cSegment) = oSegments.Where(Function(oItem) Not oItem Is Me AndAlso Not oItem.Splay).ToList
            'if standard shots are all assigned to this cave and branch 
            If oSameSegments.Where(Function(oItem) oItem.Cave = oCurrentData.Cave AndAlso oItem.Branch = oCurrentData.Branch).Count = oSameSegments.Count Then
                'get all splay segments and set them to this cave and branch
                Dim oSplaySegments As List(Of cSegment) = oSegments.Where(Function(oitem) oitem.Splay).ToList
                For Each oSplaySegment As cSegment In oSplaySegments
                    Call oSplaySegment.SetCave(oCurrentData.Cave, oCurrentData.Branch)
                    If oSplaySegment.Changed Then
                        Call oSplaySegment.Save(False, SaveOptionsEnum.EventRaisingDisable Or SaveOptionsEnum.CaveBranchSplayAutoAssignmentDisable)
                        RaiseEvent OnReassigned(oSplaySegment)
                    End If
                Next
            End If
        End Sub

        Public Sub ResetChange()
            bChanged = False
            iInvalidated = cCalculate.InvalidateEnum.None
        End Sub

        Public ReadOnly Property Changed() As Boolean
            Get
                Return bChanged
            End Get
        End Property

        Friend ReadOnly Property Invalidated As cCalculate.InvalidateEnum
            Get
                Return iInvalidated
            End Get
        End Property

#Region "spatialdata"
        Public Property From() As String Implements cISegment.From
            Get
                Return oTempData.[From]
            End Get
            Set(ByVal value As String)
                Dim sValue As String = value.ToUpper.Trim
                If oTempData.[From] <> sValue Then
                    oTempData.[From] = sValue
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Virtual As Boolean Implements cISegment.Virtual
            Get
                Return oTempData.Virtual
            End Get
            Set(value As Boolean)
                If oTempData.Virtual <> value Then
                    oTempData.Virtual = value
                    If oTempData.Virtual Then
                        oTempData.Session = ""
                    End If
                    bChanged = True
                End If
            End Set
        End Property

        Public Property [To]() As String Implements cISegment.To
            Get
                Return oTempData.[To]
            End Get
            Set(ByVal value As String)
                Dim sValue As String = value.ToUpper.Trim
                If oTempData.[To] <> sValue Then
                    oTempData.[To] = sValue
                    bChanged = True
                End If
            End Set
        End Property

        'Public Property Inverted() As Boolean
        '    Get
        '        Return oTempData.Direction = cSurvey.DirectionEnum.Left
        '    End Get
        '    Set(ByVal value As Boolean)
        '        Dim iNewValue As cSurvey.DirectionEnum = If(value, cSurvey.DirectionEnum.Left, cSurvey.DirectionEnum.Right)
        '        If oTempData.Direction <> iNewValue Then
        '            oTempData.Direction = iNewValue
        '            bChanged = True
        '        End If
        '    End Set
        'End Property

        Public Property Distance() As Decimal
            Get
                Return oTempData.Distance
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Distance <> value Then
                    oTempData.Distance = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Bearing() As Decimal
            Get
                Return oTempData.Bearing
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Bearing <> value Then
                    oTempData.Bearing = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Inclination() As Decimal
            Get
                Return oTempData.Inclination
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Inclination <> value Then
                    oTempData.Inclination = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Function HaveLRUD() As Boolean
            Return oTempData.Left <> 0 OrElse oTempData.Right <> 0 OrElse oTempData.Up <> 0 OrElse oTempData.Down <> 0
        End Function

        Public Property Up() As Decimal
            Get
                Return oTempData.Up
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Up <> value Then
                    oTempData.Up = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Down() As Decimal
            Get
                Return oTempData.Down
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Down <> value Then
                    oTempData.Down = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Right() As Decimal
            Get
                Return oTempData.Right
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Right <> value Then
                    oTempData.Right = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Property Left() As Decimal
            Get
                Return oTempData.Left
            End Get
            Set(ByVal value As Decimal)
                If oTempData.Left <> value Then
                    oTempData.Left = value
                    bChanged = True
                End If
            End Set
        End Property

        Public Function GetSideMeasuresType() As SideMeasuresTypeEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.SideMeasuresType
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).SideMeasuresType
            End If
        End Function

        Public Function GetSideMeasuresReferTo() As SideMeasuresReferToEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.SideMeasuresReferTo
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).SideMeasuresReferTo
            End If
        End Function

        Public Function GetNordType() As NordTypeEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.NordType
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).NordType
            End If
        End Function

        Public Function GetBaseInclination() As Decimal
            Return modConversion.ConvertSegmentToBaseInclination(GetInclination, Me)
        End Function

        Public Function GetInclination() As Decimal
            Dim dInclination As Decimal = oCurrentData.Inclination
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                If oSurvey.Properties.InclinationDirection = MeasureDirectionEnum.Inverted Then
                    Return -1 * dInclination
                Else
                    Return dInclination
                End If
            Else
                If oSurvey.Properties.Sessions(oCurrentData.Session).InclinationDirection = MeasureDirectionEnum.Inverted Then
                    Return -1 * dInclination
                Else
                    Return dInclination
                End If
            End If
        End Function

        Public Function GetBaseDistance() As Decimal
            Return modConversion.ConvertSegmentToBaseDistance(GetDistance, Me)
        End Function

        Public Function GetDistance() As Decimal
            Return oTempData.Distance
        End Function

        Public Function GetBaseLeft() As Decimal
            Return modConversion.ConvertSegmentToBaseDistance(oTempData.Left, Me)
        End Function

        Public Function GetBaseRight() As Decimal
            Return modConversion.ConvertSegmentToBaseDistance(oTempData.Right, Me)
        End Function

        Public Function GetBaseUp() As Decimal
            Return modConversion.ConvertSegmentToBaseDistance(oTempData.Up, Me)
        End Function

        Public Function GetBaseDown() As Decimal
            Return modConversion.ConvertSegmentToBaseDistance(oTempData.Down, Me)
        End Function

        Public Function GetBaseBearing() As Decimal
            Return modConversion.ConvertSegmentToBaseBearing(GetBearing, Me)
        End Function

        Public Function GetBearing() As Decimal
            Dim dBearing As Decimal = oCurrentData.Bearing
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                If oSurvey.Properties.BearingDirection = MeasureDirectionEnum.Inverted Then
                    Return dBearing - 180
                Else
                    Return dBearing
                End If
            Else
                If oSurvey.Properties.Sessions(oCurrentData.Session).BearingDirection = MeasureDirectionEnum.Inverted Then
                    Return dBearing - 180
                Else
                    Return dBearing
                End If
            End If
        End Function

        Public Function GetBearingDirection() As MeasureDirectionEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.BearingDirection
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).BearingDirection
            End If
        End Function

        Public Function GetInclinationDirection() As MeasureDirectionEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.InclinationDirection
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).InclinationDirection
            End If
        End Function

        Public Function GetBearingType() As BearingTypeEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.BearingType
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).BearingType
            End If
        End Function

        Public Function GetDistanceType() As DistanceTypeEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.DistanceType
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).DistanceType
            End If
        End Function

        Public Function GetInclinationType() As InclinationTypeEnum
            If oCurrentData.Session = "" OrElse Not oSurvey.Properties.Sessions.Contains(oCurrentData.Session) Then
                Return oSurvey.Properties.InclinationType
            Else
                Return oSurvey.Properties.Sessions(oCurrentData.Session).InclinationType
            End If
        End Function

        Public Property Direction As cSurvey.DirectionEnum
            Get
                Return oTempData.Direction
            End Get
            Set(value As cSurvey.DirectionEnum)
                If value <> oTempData.Direction Then
                    oTempData.Direction = value
                    bChanged = True
                End If
            End Set
        End Property
#End Region

        Public Sub Reverse()
            With oTempData
                Dim sFrom As String = .[From]
                .[From] = .[To]
                .[To] = sFrom
                .Bearing = modPaint.NormalizeAngle(.Bearing - 180)
                .Inclination = - .Inclination
            End With
            bChanged = True
        End Sub

        Public Function ToCSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegment.ToCSV
            Return Chr(34) & [From] & Chr(34) & "," & Chr(34) & [To] & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Distance, "0.00", UseLocalFormat) & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Bearing, "0.00", UseLocalFormat) & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Inclination, "0.00", UseLocalFormat) & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Left, "0.00", UseLocalFormat) & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Right, "0.00", UseLocalFormat) & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Up, "0.00", UseLocalFormat) & Chr(34) & "," & Chr(34) & modNumbers.NumberToString(Down, "0.00", UseLocalFormat) & Chr(34)
        End Function

        Public Function ToTSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegment.ToTSV
            Return Chr(34) & [From] & Chr(34) & vbTab & Chr(34) & [To] & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Distance, "0.00", UseLocalFormat) & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Bearing, "0.00", UseLocalFormat) & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Inclination, "0.00", UseLocalFormat) & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Left, "0.00", UseLocalFormat) & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Right, "0.00", UseLocalFormat) & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Up, "0.00", UseLocalFormat) & Chr(34) & vbTab & Chr(34) & modNumbers.NumberToString(Down, "0.00", UseLocalFormat) & Chr(34)
        End Function

        Public Function GetFromTrigPoint() As cTrigPoint
            If oSurvey.TrigPoints.Contains(oCurrentData.From) Then
                Return oSurvey.TrigPoints(oCurrentData.From)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetToTrigPoint() As cTrigPoint
            If oSurvey.TrigPoints.Contains(oCurrentData.To) Then
                Return oSurvey.TrigPoints(oCurrentData.To)
            Else
                Return Nothing
            End If
        End Function

        Friend ReadOnly Property Type As cISegment.SegmentTypeEnum Implements cISegment.Type
            Get
                Return cISegment.SegmentTypeEnum.Segment
            End Get
        End Property

        Public ReadOnly Property ID As String Implements cISegment.ID
            Get
                Return sID
            End Get
        End Property

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Public Property PlanSplayBorderProjectionType As cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum Implements cIItemPlanSplayBorder.SplayBorderProjectionType
            Get
                Return iPlanSplayBorderProjectionType
            End Get
            Set(value As cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum)
                If iPlanSplayBorderProjectionType <> value Then
                    iPlanSplayBorderProjectionType = value
                    Call oSurvey.Plan.Plot.Caches.Invalidate()
                    iInvalidated = iInvalidated Or cCalculate.InvalidateEnum.OnlyPlanSplay
                    bChanged = True
                End If
            End Set
        End Property

        Public Property SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum Implements cISurfaceProfile.SurfaceProfileShow
            Get
                Return iSurfaceProfileShow
            End Get
            Set(value As cISurfaceProfile.SurfaceProfileShowEnum)
                iSurfaceProfileShow = value
            End Set
        End Property

        Public Function GetSurfaceProfileShow() As Boolean Implements cISurfaceProfile.GetSurfaceProfileShow
            If iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Default Then
                Return oSurvey.Properties.CaveInfos.GetSurfaceProfileShow(Me)
            Else
                Return iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Visible
            End If
        End Function

        Public ReadOnly Property FromSplays As cSegmentCollection
            Get
                Return oSurvey.Segments.GetSplaySegments(oCurrentData.From)
            End Get
        End Property

        Public ReadOnly Property ToSplays As cSegmentCollection
            Get
                Return oSurvey.Segments.GetSplaySegments(oCurrentData.To)
            End Get
        End Property
    End Class
End Namespace