﻿Imports System.Xml

Namespace cSurvey
    Public Class cCalibration
        Private sError As Single = 0F
        Private sErrorScale As Single = 1.0F

        Public Sub CopyFrom(Calibration As cCalibration)
            sError = Calibration.sError
            sErrorScale = Calibration.sErrorScale
        End Sub

        Friend Sub New(Calibration As cCalibration)
            Call CopyFrom(Calibration)
        End Sub

        Friend Sub New()
            sError = 0F
            sErrorScale = 1.0F
        End Sub

        Friend Sub New([Error] As Single, Optional ErrorScale As Single = 1.0F)
            sError = [Error]
            If ErrorScale <> 1.0F Then
                If ErrorScale = 0 Then
                    Throw New InvalidOperationException
                Else
                    sErrorScale = ErrorScale
                End If
            End If
        End Sub

        Friend Sub New(ByVal Calibration As XmlElement)
            sError = modNumbers.StringToSingle(modXML.GetAttributeValue(Calibration, "e", 0F))
            sErrorScale = modNumbers.StringToSingle(modXML.GetAttributeValue(Calibration, "es", 1.0F))
            If sErrorScale = 0F Then sErrorScale = 1.0F
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            If sError <> 0F OrElse sErrorScale <> 1.0F Then
                Dim oXmlCalibration As XmlElement = document.CreateElement(Name)
                If sError <> 0F Then oXmlCalibration.SetAttribute("e", modNumbers.NumberToString(sError))
                If sErrorScale <> 0F Then oXmlCalibration.SetAttribute("es", modNumbers.NumberToString(sErrorScale))
                Call Parent.AppendChild(oXmlCalibration)
                Return oXmlCalibration
            End If
        End Function

        Public Function IsUsed() As Boolean
            Return sError <> 0F OrElse sErrorScale <> 1.0F
        End Function

        Public Property ErrorScale As Single
            Get
                Return sErrorScale
            End Get
            Set(value As Single)
                If value = 0F Then
                    Throw New InvalidOperationException
                Else
                    sErrorScale = value
                End If
            End Set
        End Property

        Public Property [Error] As Single
            Get
                Return sError
            End Get
            Set(value As Single)
                sError = value
            End Set
        End Property
    End Class

    Public Class cSession
        Implements cIMeasure
        Implements cISurveyInfo

        Private oSurvey As cSurvey
        Private dDate As Date
        Private sDescription As String
        Private sClub As String
        Private sNote As String
        Private sTeam As String
        Private sDesigner As String
        Private oColor As Color

        Private iDataFormat As cSegment.DataFormatEnum
        Private iDistanceType As cSegment.DistanceTypeEnum
        Private iBearingType As cSegment.BearingTypeEnum
        Private iBearingDirection As cSegment.MeasureDirectionEnum
        Private iInclinationType As cSegment.InclinationTypeEnum
        Private iInclinationDirection As cSegment.MeasureDirectionEnum
        Private iDepthType As cSegment.DepthTypeEnum

        Private oDepthCalibration As cCalibration
        Private oDistanceCalibration As cCalibration
        Private oBearingCalibration As cCalibration
        Private oInclinationCalibration As cCalibration

        Private iNordType As cSegment.NordTypeEnum
        Private sDeclination As Single
        Private bDeclinationEnabled As Boolean

        Private iSideMeasuresType As cSegment.SideMeasuresTypeEnum
        Private iSideMeasuresReferTo As cSegment.SideMeasuresReferToEnum

        Private sVThreshold As Single
        Private bVThresholdEnabled As Boolean

        Private sGrade As String

        Public Function GetSegments() As cISegmentCollection
            Return oSurvey.Segments.GetSessionSegments(Me)
        End Function

        Public Function GetSegmentCount() As Integer
            Return GetSegments.Count
        End Function

        Public Function GetBindedItems() As List(Of Design.cItem)
            Return GetSegments.GetBindedItems()
        End Function

        Public Property BearingDirection As cSegment.MeasureDirectionEnum Implements cIMeasure.BearingDirection
            Get
                Return iBearingDirection
            End Get
            Set(value As cSegment.MeasureDirectionEnum)
                If iBearingDirection <> value Then
                    iBearingDirection = value
                End If
            End Set
        End Property

        Public Property InclinationDirection As cSegment.MeasureDirectionEnum Implements cIMeasure.InclinationDirection
            Get
                Return iInclinationDirection
            End Get
            Set(value As cSegment.MeasureDirectionEnum)
                If iInclinationDirection <> value Then
                    iInclinationDirection = value
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal [Date] As Date, ByVal Description As String, Session As cSession)
            oSurvey = Survey
            dDate = [Date]
            sDescription = Description
            CopyFrom(Session)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal [Date] As Date, ByVal Description As String)
            oSurvey = Survey
            dDate = [Date]
            sDescription = Description

            sClub = ""
            sTeam = ""
            sDesigner = ""
            sNote = ""
            oColor = Drawing.Color.Transparent

            iDataFormat = cSegment.DataFormatEnum.Normal
            iBearingType = cSegment.BearingTypeEnum.DecimalDegree
            iDistanceType = cSegment.DistanceTypeEnum.Meters
            iInclinationType = cSegment.InclinationTypeEnum.DecimalDegree
            iDepthType = cSegment.DepthTypeEnum.AbsoluteAtEnd

            oDepthCalibration = New cCalibration
            oDistanceCalibration = New cCalibration
            oBearingCalibration = New cCalibration
            oInclinationCalibration = New cCalibration

            sGrade = ""

            iNordType = cSegment.NordTypeEnum.Magnetic
            sDeclination = 0
            bDeclinationEnabled = False

            iSideMeasuresType = cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious
            iSideMeasuresReferTo = cSegment.SideMeasuresReferToEnum.EndPoint

            sVThreshold = 0
            bVThresholdEnabled = False

            sGrade = ""
        End Sub

        Public Overrides Function ToString() As String
            'dDate.ToString(Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern)
            Return If(dDate = #12:00:00 AM#, "", dDate.ToString(Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern) & " - ") & sDescription
            'Return IIf(dDate = #12:00:00 AM#, "", Strings.Format(dDate, "dd/MM/yyyy") & " - ") & sDescription
        End Function

        Public ReadOnly Property ID As String
            Get
                If dDate = #12:00:00 AM# Then
                    Return ""
                Else
                    Return Strings.Format(dDate, "yyyyMMdd") & "_" & sDescription.Replace(" ", "_").ToLower
                End If
            End Get
        End Property

        Public ReadOnly Property FormattedID As String
            Get
                Return Strings.Format(dDate, "dd-MM-yyyy") & " " & sDescription
            End Get
        End Property

        ''' <summary>
        ''' Se internal description.
        ''' Do not use it directly but use sessions.rename method.
        ''' </summary>
        ''' <param name="Description"></param>
        Friend Sub SetDescription(ByVal Description As String)
            sDescription = Description
        End Sub

        ''' <summary>
        ''' Set internal date.
        ''' Do not use it directly but use sessions.rename method.
        ''' </summary>
        ''' <param name="[Date]"></param>
        Friend Sub SetDate(ByVal [Date] As Date)
            dDate = [Date]
        End Sub

        Public Property DataFormat As cSegment.DataFormatEnum Implements cIMeasure.DataFormat
            Get
                Return iDataFormat
            End Get
            Set(value As cSegment.DataFormatEnum)
                iDataFormat = value
            End Set
        End Property

        Public Property BearingType() As cSegment.BearingTypeEnum Implements cIMeasure.BearingType
            Get
                Return iBearingType
            End Get
            Set(ByVal value As cSegment.BearingTypeEnum)
                iBearingType = value
            End Set
        End Property

        Public Property DistanceType() As cSegment.DistanceTypeEnum Implements cIMeasure.DistanceType
            Get
                Return iDistanceType
            End Get
            Set(ByVal value As cSegment.DistanceTypeEnum)
                iDistanceType = value
            End Set
        End Property

        Public Property InclinationType() As cSegment.InclinationTypeEnum Implements cIMeasure.InclinationType
            Get
                Return iInclinationType
            End Get
            Set(ByVal value As cSegment.InclinationTypeEnum)
                iInclinationType = value
            End Set
        End Property

        Public Property DepthType() As cSegment.DepthTypeEnum Implements cIMeasure.DepthType
            Get
                Return iDepthType
            End Get
            Set(ByVal value As cSegment.DepthTypeEnum)
                iDepthType = value
            End Set
        End Property

        Public Property NordType() As cSegment.NordTypeEnum Implements cIMeasure.NordType
            Get
                Return iNordType
            End Get
            Set(ByVal value As cSegment.NordTypeEnum)
                iNordType = value
            End Set
        End Property

        Public Property SideMeasuresType() As cSegment.SideMeasuresTypeEnum Implements cIMeasure.SideMeasuresType
            Get
                Return iSideMeasuresType
            End Get
            Set(ByVal value As cSegment.SideMeasuresTypeEnum)
                iSideMeasuresType = value
            End Set
        End Property

        Public Property SideMeasuresReferTo() As cSegment.SideMeasuresReferToEnum Implements cIMeasure.SideMeasuresReferTo
            Get
                Return iSideMeasuresReferTo
            End Get
            Set(ByVal value As cSegment.SideMeasuresReferToEnum)
                iSideMeasuresReferTo = value
            End Set
        End Property

        Public Property Note() As String Implements cISurveyInfo.Note
            Get
                Return sNote
            End Get
            Set(ByVal value As String)
                sNote = value
            End Set
        End Property

        Public Property Club() As String Implements cISurveyInfo.Club
            Get
                Return sClub
            End Get
            Set(ByVal value As String)
                sClub = value
            End Set
        End Property

        Public Property Team() As String Implements cISurveyInfo.Team
            Get
                Return sTeam
            End Get
            Set(ByVal value As String)
                sTeam = value
            End Set
        End Property

        Public Property Designer() As String Implements cISurveyInfo.Designer
            Get
                Return sDesigner
            End Get
            Set(ByVal value As String)
                sDesigner = value
            End Set
        End Property

        Public ReadOnly Property ToHTMLString() As String
            Get
                Return "<b><backcolor=" & ColorTranslator.ToHtml(Color) & ">  </backcolor></b>  <b>" & If(dDate.ToOADate = 0, "", dDate.ToString(Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern)) & "</b> " & sDescription
            End Get
        End Property

        Public Property Color As Color
            Get
                Return oColor
            End Get
            Set(value As Color)
                oColor = value
            End Set
        End Property

        Public ReadOnly Property Description() As String
            Get
                Return sDescription
            End Get
        End Property

        Public ReadOnly Property [Date]() As Date
            Get
                Return dDate
            End Get
        End Property

        Friend Sub CopyFrom(Session As cSession)
            sClub = Session.sClub
            sTeam = Session.sTeam
            sDesigner = Session.sDesigner
            sNote = Session.sNote

            iDistanceType = Session.iDistanceType
            iBearingType = Session.iBearingType
            iBearingDirection = Session.iBearingDirection
            iInclinationType = Session.iInclinationType
            iInclinationDirection = Session.iInclinationDirection
            iDepthType = Session.iDepthType

            oDepthCalibration = New cCalibration(Session.oDepthCalibration)
            oDistanceCalibration = New cCalibration(Session.oDistanceCalibration)
            oBearingCalibration = New cCalibration(Session.oBearingCalibration)
            oInclinationCalibration = New cCalibration(Session.oInclinationCalibration)

            iNordType = Session.iNordType
            sDeclination = Session.sDeclination
            bDeclinationEnabled = Session.bDeclinationEnabled

            iSideMeasuresType = Session.iSideMeasuresType
            iSideMeasuresReferTo = Session.iSideMeasuresReferTo

            sGrade = Session.sGrade
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Session As XmlElement)
            oSurvey = Survey
            Dim sDate As String = modXML.GetAttributeValue(Session, "date")
            'check some date from file generated by another software (like topodroid)
            If sDate Like "????.??.??" OrElse sDate Like "????-??-??" Then
                dDate = New Date(sDate.Substring(0, 4), sDate.Substring(5, 2), sDate.Substring(8, 2))
            Else
                dDate = Date.Parse(sDate)
            End If

            sDescription = modXML.GetAttributeValue(Session, "description", "")
            sClub = modXML.GetAttributeValue(Session, "club", "")
            sTeam = modXML.GetAttributeValue(Session, "team", "")
            sDesigner = modXML.GetAttributeValue(Session, "designer", "")
            oColor = modXML.GetAttributeColor(Session, "color", Drawing.Color.Transparent)

            sNote = modXML.GetAttributeValue(Session, "note", "")

            iDataFormat = modXML.GetAttributeValue(Session, "dataformat", cSegment.DataFormatEnum.Normal)
            iDistanceType = modXML.GetAttributeValue(Session, "distancetype", cSegment.DistanceTypeEnum.Meters)
            iBearingType = modXML.GetAttributeValue(Session, "bearingtype", cSegment.BearingTypeEnum.DecimalDegree)
            iBearingDirection = modXML.GetAttributeValue(Session, "bearingdirection", cSegment.MeasureDirectionEnum.Direct)
            iInclinationType = modXML.GetAttributeValue(Session, "inclinationtype", cSegment.InclinationTypeEnum.DecimalDegree)
            iInclinationDirection = modXML.GetAttributeValue(Session, "inclinationdirection", cSegment.MeasureDirectionEnum.Direct)
            iDepthType = modXML.GetAttributeValue(Session, "depthtype", cSegment.DepthTypeEnum.AbsoluteAtEnd)

            If modXML.ChildElementExist(Session, "depthcal") Then
                oDepthCalibration = New cCalibration(Session.Item("depthcal"))
            Else
                oDepthCalibration = New cCalibration
            End If
            If modXML.ChildElementExist(Session, "distancecal") Then
                oDistanceCalibration = New cCalibration(Session.Item("distancecal"))
            Else
                oDistanceCalibration = New cCalibration
            End If
            If modXML.ChildElementExist(Session, "bearingcal") Then
                oBearingCalibration = New cCalibration(Session.Item("bearingcal"))
            Else
                oBearingCalibration = New cCalibration
            End If
            If modXML.ChildElementExist(Session, "inclinationcal") Then
                oInclinationCalibration = New cCalibration(Session.Item("inclinationcal"))
            Else
                oInclinationCalibration = New cCalibration
            End If

            sGrade = modXML.GetAttributeValue(Session, "grade", "")

            iNordType = modXML.GetAttributeValue(Session, "nordtype")
            sDeclination = modNumbers.StringToDecimal(modXML.GetAttributeValue(Session, "declination", 0))
            bDeclinationEnabled = modXML.GetAttributeValue(Session, "declinationenabled")

            iSideMeasuresType = modXML.GetAttributeValue(Session, "sidemeasurestype", cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious)
            iSideMeasuresReferTo = modXML.GetAttributeValue(Session, "sidemeasuresreferto", cSegment.SideMeasuresReferToEnum.EndPoint)

            sVThreshold = modNumbers.StringToSingle(modXML.GetAttributeValue(Session, "vthreshold", 0))
            bVThresholdEnabled = modXML.GetAttributeValue(Session, "vthresholdenabled", False)
        End Sub

        Public ReadOnly Property BearingCalibration As cCalibration
            Get
                Return oBearingCalibration
            End Get
        End Property

        Public ReadOnly Property DistanceCalibration As cCalibration
            Get
                Return oDistanceCalibration
            End Get
        End Property

        Public ReadOnly Property InclinationCalibration As cCalibration
            Get
                Return oInclinationCalibration
            End Get
        End Property

        Public ReadOnly Property DepthCalibration As cCalibration
            Get
                Return oDepthCalibration
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSession As XmlElement = document.CreateElement("session")
            Call oXmlSession.SetAttribute("date", dDate.ToString("O"))
            Call oXmlSession.SetAttribute("description", sDescription)
            If oColor <> Drawing.Color.Transparent And Not oColor.IsEmpty Then Call oXmlSession.SetAttribute("color", oColor.ToArgb)

            If sClub <> "" Then
                Call oXmlSession.SetAttribute("club", sClub)
            End If
            If sTeam <> "" Then
                Call oXmlSession.SetAttribute("team", sTeam)
            End If
            If sDesigner <> "" Then
                Call oXmlSession.SetAttribute("designer", sDesigner)
            End If

            If sNote < "" Then
                Call oXmlSession.SetAttribute("note", sNote)
            End If

            If iDataFormat <> cSegment.DataFormatEnum.Normal Then
                Call oXmlSession.SetAttribute("dataformat", iDataFormat.ToString("D"))
            End If
            If iDistanceType <> cSegment.DistanceTypeEnum.Meters Then
                Call oXmlSession.SetAttribute("distancetype", iDistanceType.ToString("D"))
            End If
            If iBearingType <> cSegment.BearingTypeEnum.DecimalDegree Then
                Call oXmlSession.SetAttribute("bearingtype", iBearingType.ToString("D"))
            End If
            If iBearingDirection <> cSegment.MeasureDirectionEnum.Direct Then
                Call oXmlSession.SetAttribute("bearingdirection", iBearingDirection.ToString("D"))
            End If
            If iInclinationType <> cSegment.InclinationTypeEnum.DecimalDegree Then
                Call oXmlSession.SetAttribute("inclinationtype", iInclinationType.ToString("D"))
            End If
            If iInclinationDirection <> cSegment.MeasureDirectionEnum.Direct Then
                Call oXmlSession.SetAttribute("inclinationdirection", iInclinationDirection.ToString("D"))
            End If
            If iDepthType <> cSegment.DepthTypeEnum.AbsoluteAtBegin Then
                Call oXmlSession.SetAttribute("depthtype", iDepthType.ToString("D"))
            End If

            Call oDepthCalibration.SaveTo(File, document, oXmlSession, "depthcal")
            Call oDistanceCalibration.SaveTo(File, document, oXmlSession, "distancecal")
            Call oBearingCalibration.SaveTo(File, document, oXmlSession, "bearingcal")
            Call oInclinationCalibration.SaveTo(File, document, oXmlSession, "inclinationcal")

            If sGrade <> "" Then
                Call oXmlSession.SetAttribute("grade", sGrade)
            End If

            Call oXmlSession.SetAttribute("nordtype", iNordType)
            Call oXmlSession.SetAttribute("declinationenabled", IIf(bDeclinationEnabled, 1, 0))
            Call oXmlSession.SetAttribute("declination", modNumbers.NumberToString(sDeclination))
            'End If
            If iSideMeasuresType <> cSegment.SideMeasuresTypeEnum.PerpendicularToPrevious Then
                Call oXmlSession.SetAttribute("sidemeasurestype", iSideMeasuresType.ToString("D"))
            End If
            If iSideMeasuresReferTo <> cSegment.SideMeasuresReferToEnum.EndPoint Then
                Call oXmlSession.SetAttribute("sidemeasuresreferto", iSideMeasuresReferTo.ToString("D"))
            End If

            If sVThreshold <> 0 Then
                Call oXmlSession.SetAttribute("vthreshold", modNumbers.NumberToString(sVThreshold))
            End If
            If bVThresholdEnabled Then
                Call oXmlSession.SetAttribute("vthresholdenabled", "1")
            End If

            Call Parent.AppendChild(oXmlSession)
            Return oXmlSession
        End Function

        Public Property Grade() As String Implements cIMeasure.Grade
            Get
                Return sGrade
            End Get
            Set(ByVal Value As String)
                sGrade = Value
            End Set
        End Property

        Public Property DeclinationEnabled() As Boolean Implements cIMeasure.DeclinationEnabled
            Get
                Return bDeclinationEnabled
            End Get
            Set(ByVal Value As Boolean)
                bDeclinationEnabled = Value
            End Set
        End Property

        Public Function GetDeclination() As Single?
            If bDeclinationEnabled Then
                Return sDeclination
            Else
                With oSurvey.Properties
                    If .GlobalDeclinationEnabled Then
                        Return .GlobalDeclination
                    Else
                        Return Nothing
                    End If
                End With
            End If
        End Function

        Public Property Declination() As Single Implements cIMeasure.Declination
            Get
                Return sDeclination
            End Get
            Set(ByVal Value As Single)
                sDeclination = Value
            End Set
        End Property

        Public Property VThreshold() As Single Implements cIMeasure.VThreshold
            Get
                Return sVThreshold
            End Get
            Set(ByVal Value As Single)
                sVThreshold = Value
            End Set
        End Property

        Public Property VThresholdEnabled() As Boolean Implements cIMeasure.VThresholdEnabled
            Get
                Return bVThresholdEnabled
            End Get
            Set(ByVal Value As Boolean)
                bVThresholdEnabled = Value
            End Set
        End Property

        Public Function GetVThreshold() As Single
            If bVThresholdEnabled Then
                Return sVThreshold
            Else
                With oSurvey.Properties
                    If .GlobalVThresholdEnabled Then
                        Return .GlobalVThreshold
                    Else
                        Return 90.0F
                    End If
                End With
            End If
        End Function

        Friend Shared Function EditToString(Session As cSession) As String
            If Session Is Nothing Then
                Return ""
            Else
                Return Session.ID
            End If
        End Function
    End Class
End Namespace