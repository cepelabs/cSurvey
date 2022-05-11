Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Calculate
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cSpeleometric
        Private oSurvey As cSurvey

        Private sCave As String
        Private sBranch As String

        Private sPlanimetricLength As Single
        Private sLength As Single
        Private sMeasuredLength As Single
        Private sExtension As Single

        Private iSegmentCount As Integer
        Private iExcludedSegmentCount As Integer

        Private sPositiveVerticalRange As Single?
        Private sNegativeVerticalRange As Single?
        Private sVerticalRange As Single

        Private sQuotaMax As Single?
        Private sQuotaMin As Single?

        Private oEntranceCoordinate As cTrigPointCoordinate
        Private sEntranceStation As String

        Public ReadOnly Property Cave As String
            Get
                Return sCave
            End Get
        End Property

        Public ReadOnly Property Branch As String
            Get
                Return sBranch
            End Get
        End Property

        Public ReadOnly Property EntranceCoordinate As cTrigPointCoordinate
            Get
                Return oEntranceCoordinate
            End Get
        End Property

        Public ReadOnly Property EntranceStation() As String
            Get
                Return sEntranceStation
            End Get
        End Property

        Public ReadOnly Property DefaultExtension As Single
            Get
                Return modConversion.ConvertBaseToDefaultDistance(sExtension, oSurvey)
            End Get
        End Property

        Public ReadOnly Property Extension As Single
            Get
                Return sExtension
            End Get
        End Property

        Public ReadOnly Property DefaultPositiveVerticalRange As Single?
            Get
                If sPositiveVerticalRange.HasValue Then
                    Return modConversion.ConvertBaseToDefaultDistance(sPositiveVerticalRange.Value, oSurvey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property PositiveVerticalRange As Single?
            Get
                Return sPositiveVerticalRange
            End Get
        End Property

        Public ReadOnly Property DefaultNegativeVerticalRange As Single?
            Get
                If sNegativeVerticalRange.HasValue Then
                    Return modConversion.ConvertBaseToDefaultDistance(sNegativeVerticalRange.Value, oSurvey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property NegativeVerticalRange As Single?
            Get
                Return sNegativeVerticalRange
            End Get
        End Property

        Public ReadOnly Property DefaultVerticalRange As Single
            Get
                Return modConversion.ConvertBaseToDefaultDistance(sVerticalRange, oSurvey)
            End Get
        End Property

        Public ReadOnly Property VerticalRange As Single
            Get
                Return sVerticalRange
            End Get
        End Property

        Public ReadOnly Property QuotaMin As Single?
            Get
                Return sQuotaMin
            End Get
        End Property

        Public ReadOnly Property QuotaMax As Single?
            Get
                Return sQuotaMax
            End Get
        End Property

        Public ReadOnly Property DefaultLength As Single
            Get
                Return modConversion.ConvertBaseToDefaultDistance(sLength, oSurvey)
            End Get
        End Property

        Public ReadOnly Property Length As Single
            Get
                Return sLength
            End Get
        End Property

        Public ReadOnly Property DefaultPlanimetricLength As Single
            Get
                Return modConversion.ConvertBaseToDefaultDistance(sPlanimetricLength, oSurvey)
            End Get
        End Property

        Public ReadOnly Property PlanimetricLength As Single
            Get
                Return sPlanimetricLength
            End Get
        End Property

        Public ReadOnly Property DefaultMeasuredLength As Single
            Get
                Return modConversion.ConvertBaseToDefaultDistance(sMeasuredLength, oSurvey)
            End Get
        End Property

        Public ReadOnly Property MeasuredLength As Single
            Get
                Return sMeasuredLength
            End Get
        End Property

        Public ReadOnly Property SegmentCount As Integer
            Get
                Return iSegmentCount
            End Get
        End Property

        Public ReadOnly Property ExcludedSegmentCount As Integer
            Get
                Return iExcludedSegmentCount
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, Cave As String, Branch As String, Length As Single, PlanimetricLength As Single, MeasuredLength As Single, Extension As Single, SegmentCount As Integer, ExcludedSegmentCount As Integer, QuotaMax As Single, QuotaMin As Single, VerticalRange As Single)
            oSurvey = Survey

            sCave = Cave
            sBranch = Branch

            Dim iDecimalPlace As Integer = 0

            sPlanimetricLength = modNumbers.MathRound(PlanimetricLength, iDecimalPlace)
            sLength = modNumbers.MathRound(Length, iDecimalPlace)
            sMeasuredLength = modNumbers.MathRound(MeasuredLength, iDecimalPlace)
            sExtension = modNumbers.MathRound(Extension, iDecimalPlace)

            iSegmentCount = SegmentCount
            iExcludedSegmentCount = ExcludedSegmentCount

            sPositiveVerticalRange = Nothing
            sNegativeVerticalRange = Nothing
            sVerticalRange = VerticalRange

            sQuotaMax = QuotaMax
            sQuotaMin = QuotaMin

            sEntranceStation = ""
            oEntranceCoordinate = Nothing
        End Sub

        Friend Sub New(Survey As cSurvey, Cave As String, Branch As String, Length As Single, PlanimetricLength As Single, MeasuredLength As Single, Extension As Single, SegmentCount As Integer, ExcludedSegmentCount As Integer, QuotaMax As Single, QuotaMin As Single, PositiveVerticalRange As Single, NegativeVerticalRange As Single, EntranceStation As String, EntranceCoordinate As cTrigPointCoordinate)
            oSurvey = Survey

            sCave = Cave
            sBranch = Branch

            Dim iDecimalPlace As Integer = 0

            sPlanimetricLength = modNumbers.MathRound(PlanimetricLength, iDecimalPlace)
            sLength = modNumbers.MathRound(Length, iDecimalPlace)
            sMeasuredLength = modNumbers.MathRound(MeasuredLength, iDecimalPlace)
            sExtension = modNumbers.MathRound(Extension, iDecimalPlace)

            iSegmentCount = SegmentCount
            iExcludedSegmentCount = ExcludedSegmentCount

            sPositiveVerticalRange = Math.Abs(modNumbers.MathRound(PositiveVerticalRange, iDecimalPlace))
            sNegativeVerticalRange = Math.Abs(modNumbers.MathRound(NegativeVerticalRange, iDecimalPlace))
            sVerticalRange = sPositiveVerticalRange + sNegativeVerticalRange

            sQuotaMax = QuotaMax
            sQuotaMin = QuotaMin

            sEntranceStation = EntranceStation
            oEntranceCoordinate = EntranceCoordinate
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSM As XmlElement = Document.CreateElement("sm")
            If sCave <> "" Then Call oXmlSM.SetAttribute("cave", sCave)
            If sBranch <> "" Then Call oXmlSM.SetAttribute("branch", sBranch)

            Call oXmlSM.SetAttribute("pl", modNumbers.NumberToString(sPlanimetricLength, "0.00"))
            Call oXmlSM.SetAttribute("l", modNumbers.NumberToString(sLength, "0.00"))
            Call oXmlSM.SetAttribute("ml", modNumbers.NumberToString(sMeasuredLength, "0.00"))
            Call oXmlSM.SetAttribute("e", modNumbers.NumberToString(sExtension, "0.00"))

            Call oXmlSM.SetAttribute("sc", modNumbers.NumberToString(iSegmentCount, "0"))
            Call oXmlSM.SetAttribute("xsc", modNumbers.NumberToString(iExcludedSegmentCount, "0"))

            If sPositiveVerticalRange.HasValue Then Call oXmlSM.SetAttribute("pvr", modNumbers.NumberToString(sPositiveVerticalRange.Value, "0.00"))
            If sNegativeVerticalRange.HasValue Then Call oXmlSM.SetAttribute("nvr", modNumbers.NumberToString(sNegativeVerticalRange.Value, "0.00"))

            If sQuotaMax.HasValue Then Call oXmlSM.SetAttribute("qmx", modNumbers.NumberToString(sQuotaMax.Value, "0.00"))
            If sQuotaMin.HasValue Then Call oXmlSM.SetAttribute("qmn", modNumbers.NumberToString(sQuotaMin.Value, "0.00"))

            If sEntranceStation <> "" Then Call oXmlSM.SetAttribute("es", sEntranceStation)
            If Not oEntranceCoordinate Is Nothing Then Call oEntranceCoordinate.SaveTo(File, Document, oXmlSM, "escoord")

            Call Parent.AppendChild(oXmlSM)
            Return oXmlSM
        End Function

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey

            sCave = modXML.GetAttributeValue(Item, "cave", "")
            sBranch = modXML.GetAttributeValue(Item, "branch", "")

            sPlanimetricLength = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "pl", 0))
            sLength = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "l", 0))
            sMeasuredLength = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "ml", 0))
            sExtension = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "e", 0))

            iSegmentCount = modNumbers.StringToInteger(modXML.GetAttributeValue(Item, "sc", 0))
            iExcludedSegmentCount = modNumbers.StringToInteger(modXML.GetAttributeValue(Item, "esc", 0))

            If modXML.HasAttribute(Item, "pvr") Then sPositiveVerticalRange = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "pvr", 0))
            If modXML.HasAttribute(Item, "nvr") Then sNegativeVerticalRange = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "nvr", 0))
            If sPositiveVerticalRange.HasValue AndAlso sNegativeVerticalRange.HasValue Then
                sVerticalRange = sPositiveVerticalRange.Value + sNegativeVerticalRange.Value
            Else
                sVerticalRange = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "vr", 0))
            End If

            If modXML.HasAttribute(Item, "qmx") Then sQuotaMax = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "qmx", 0))
            If modXML.HasAttribute(Item, "qmn") Then sQuotaMin = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "qmn", 0))

            sEntranceStation = modXML.GetAttributeValue(Item, "es", "")
            If modXML.ChildElementExist(Item, "escoord") Then oEntranceCoordinate = New cTrigPointCoordinate(Item.Item("escoord"))
        End Sub

    End Class
End Namespace
