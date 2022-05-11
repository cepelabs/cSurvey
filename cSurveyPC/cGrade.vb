Imports System.Xml

Namespace cSurvey
    Public Class cGrade
        Private oSurvey As cSurvey

        Private sID As String
        Private sDescription As String

        Private bDistanceEnabled As Boolean
        Private bBearingEnabled As Boolean
        Private bInclinationEnabled As Boolean

        Private sDistance As Single
        Private sBearing As Single
        Private sInclination As Single

        Private iDistanceType As cSegment.DistanceTypeEnum
        Private iBearingType As cSegment.BearingTypeEnum
        Private iInclinationType As cSegment.InclinationTypeEnum

        Friend Sub CopyFrom(Grade As cGrade)
            bDistanceEnabled = Grade.bDistanceEnabled
            bBearingEnabled = Grade.bBearingEnabled
            bInclinationEnabled = Grade.bInclinationEnabled

            sDistance = Grade.sDistance
            sBearing = Grade.sBearing
            sInclination = Grade.sInclination

            iDistanceType = Grade.iDistanceType
            iBearingType = Grade.iBearingType
            iInclinationType = Grade.iInclinationType
        End Sub

        Friend Function CreateTherionGradeTextBlock() As String
            If IsEmpty() Then
                Return ""
            Else
                Dim sText As String = "grade " & sID & vbCrLf
                If bDistanceEnabled Then sText = sText & "length " & modNumbers.NumberToString(sDistance) & " " & GetTherionDistanceUnit(iDistanceType) & vbCrLf
                If bBearingEnabled Then sText = sText & "compass " & modNumbers.NumberToString(sBearing) & " " & GetTherionBearingUnit(iBearingType) & vbCrLf
                If bInclinationEnabled Then sText = sText & "clino " & modNumbers.NumberToString(sInclination) & " " & GetTherionInclinationUnit(iInclinationType) & vbCrLf
                sText = sText & "endgrade"
                Return sText
            End If
        End Function

        Public Function IsEmpty() As Boolean
            Return Not (bDistanceEnabled Or bBearingEnabled Or bInclinationEnabled)
        End Function

        Public Function IsUsed() As Boolean
            If oSurvey.Properties.Grade = sID Then
                Return True
            Else
                For Each oSession As cSession In oSurvey.Properties.Sessions
                    If oSession.Grade = sID Then
                        Return True
                    End If
                Next
            End If
        End Function

        Public Function GetUsingSessions() As List(Of cSession)
            Dim oSessions As List(Of cSession) = New List(Of cSession)
            For Each oSession As cSession In oSurvey.Properties.Sessions.GetWithEmpty.Values
                If oSession.Grade = sID Then
                    Call oSessions.Add(oSession)
                End If
            Next
            Return oSessions
        End Function

        Public Property InclinationEnabled As Boolean
            Get
                Return bInclinationEnabled
            End Get
            Set(value As Boolean)
                bInclinationEnabled = value
            End Set
        End Property

        Public Property DistanceEnabled As Boolean
            Get
                Return bDistanceEnabled
            End Get
            Set(value As Boolean)
                bDistanceEnabled = value
            End Set
        End Property

        Public Property BearingEnabled As Boolean
            Get
                Return bBearingEnabled
            End Get
            Set(value As Boolean)
                bBearingEnabled = value
            End Set
        End Property

        Public Property Description As String
            Get
                Return sDescription
            End Get
            Set(value As String)
                sDescription = value
            End Set
        End Property

        Public Property Distance As Single
            Get
                Return sDistance
            End Get
            Set(value As Single)
                sDistance = value
            End Set
        End Property

        Public Property Bearing As Single
            Get
                Return sBearing
            End Get
            Set(value As Single)
                sBearing = value
            End Set
        End Property

        Public Property Inclination As Single
            Get
                Return sInclination
            End Get
            Set(value As Single)
                sInclination = value
            End Set
        End Property

        Public Property DistanceType As cSegment.DistanceTypeEnum
            Get
                Return iDistanceType
            End Get
            Set(value As cSegment.DistanceTypeEnum)
                iDistanceType = value
            End Set
        End Property

        Public Property BearingType As cSegment.BearingTypeEnum
            Get
                Return iBearingType
            End Get
            Set(value As cSegment.BearingTypeEnum)
                iBearingType = value
            End Set
        End Property

        Public Property InclinationType As cSegment.InclinationTypeEnum
            Get
                Return iInclinationType
            End Get
            Set(value As cSegment.InclinationTypeEnum)
                iInclinationType = value
            End Set
        End Property

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, ID As String, Description As String)
            oSurvey = Survey
            sID = ID
            sDescription = Description
        End Sub

        Friend Sub New(Survey As cSurvey, Description As String)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            sDescription = Description
        End Sub

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            sID = Guid.NewGuid.ToString
            sDescription = ""
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlGrade As XmlElement = Document.CreateElement("grade")
            Call oXmlGrade.SetAttribute("id", sID)
            If sDescription <> "" Then Call oXmlGrade.SetAttribute("description", sDescription)
            If bDistanceEnabled Then
                Call oXmlGrade.SetAttribute("distanceenabled", "1")
                Call oXmlGrade.SetAttribute("distance", modNumbers.NumberToString(sDistance))
                If iDistanceType <> cSegment.DistanceTypeEnum.Meters Then
                    Call oXmlGrade.SetAttribute("distancetype", iDistanceType)
                End If
            End If
            If bBearingEnabled Then
                Call oXmlGrade.SetAttribute("bearingenabled", "1")
                Call oXmlGrade.SetAttribute("bearing", modNumbers.NumberToString(sBearing))
                If iBearingType <> cSegment.BearingTypeEnum.DecimalDegree Then
                    Call oXmlGrade.SetAttribute("bearingtype", iBearingType)
                End If
            End If
            If bInclinationEnabled Then
                Call oXmlGrade.SetAttribute("inclinationenabled", "1")
                Call oXmlGrade.SetAttribute("inclination", modNumbers.NumberToString(sInclination))
                If iInclinationType <> cSegment.InclinationTypeEnum.DecimalDegree Then
                    Call oXmlGrade.SetAttribute("inclinationtype", iInclinationType)
                End If
            End If
            Call Parent.AppendChild(oXmlGrade)
            Return oXmlGrade
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Grade As XmlElement)
            oSurvey = Survey
            sID = modXML.GetAttributeValue(Grade, "id")
            sDescription = modXML.GetAttributeValue(Grade, "description")
            bDistanceEnabled = modXML.GetAttributeValue(Grade, "distanceenabled")
            If bDistanceEnabled Then
                sDistance = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "distance"))
                iDistanceType = modXML.GetAttributeValue(Grade, "distancetype")
            End If
            BearingEnabled = modXML.GetAttributeValue(Grade, "bearingenabled")
            If BearingEnabled Then
                sBearing = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "bearing"))
                iBearingType = modXML.GetAttributeValue(Grade, "bearingtype")
            End If
            bInclinationEnabled = modXML.GetAttributeValue(Grade, "inclinationenabled")
            If bInclinationEnabled Then
                sInclination = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "inclination"))
                iInclinationType = modXML.GetAttributeValue(Grade, "inclinationtype")
            End If
        End Sub

        Public Overrides Function ToString() As String
            Return IIf(sDescription = "", "[" & sID & "]", sDescription)
        End Function
    End Class
End Namespace