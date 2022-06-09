Imports System.Xml

Namespace cSurvey
    Public Class cGrade
        Private oSurvey As cSurvey

        Private sID As String
        Private sDescription As String

        Private bDistanceEnabled As Boolean
        Private bBearingEnabled As Boolean
        Private bInclinationEnabled As Boolean
        Private bDepthEnabled As Boolean
        Private bXEnabled As Boolean
        Private bYEnabled As Boolean
        Private bZEnabled As Boolean

        Private sDistance As Single
        Private sBearing As Single
        Private sInclination As Single
        Private sDepth As Single
        Private sX As Single
        Private sY As Single
        Private sZ As Single

        Private iDistanceType As cSegment.DistanceTypeEnum
        Private iBearingType As cSegment.BearingTypeEnum
        Private iInclinationType As cSegment.InclinationTypeEnum
        Private iDepthType As cSegment.DistanceTypeEnum
        Private iXType As cSegment.DistanceTypeEnum
        Private iYType As cSegment.DistanceTypeEnum
        Private iZType As cSegment.DistanceTypeEnum

        Friend Sub CopyFrom(Grade As cGrade)
            bDistanceEnabled = Grade.bDistanceEnabled
            bBearingEnabled = Grade.bBearingEnabled
            bInclinationEnabled = Grade.bInclinationEnabled

            sDistance = Grade.sDistance
            sBearing = Grade.sBearing
            sInclination = Grade.sInclination
            sDepth = Grade.sDepth
            sX = Grade.sX
            sY = Grade.sY
            sZ = Grade.sZ

            iDistanceType = Grade.iDistanceType
            iBearingType = Grade.iBearingType
            iInclinationType = Grade.iInclinationType
            iDepthType = Grade.iDepthType
            iXType = Grade.iXType
            iYType = Grade.iYType
            iZType = Grade.iZType
        End Sub

        Friend Function CreateTherionGradeTextBlock() As String
            If IsEmpty() Then
                Return ""
            Else
                Dim sText As String = "grade " & sID & vbCrLf

                If bDistanceEnabled Then sText = sText & "length " & modNumbers.NumberToString(sDistance) & " " & GetTherionDistanceUnit(iDistanceType) & vbCrLf
                If bBearingEnabled Then sText = sText & "compass " & modNumbers.NumberToString(sBearing) & " " & GetTherionBearingUnit(iBearingType) & vbCrLf
                If bInclinationEnabled Then sText = sText & "clino " & modNumbers.NumberToString(sInclination) & " " & GetTherionInclinationUnit(iInclinationType) & vbCrLf
                If bDepthEnabled Then sText = sText & "depth " & modNumbers.NumberToString(sDepth) & " " & GetTherionDepthUnit(iDepthType) & vbCrLf
                If bXEnabled Then sText = sText & "x " & modNumbers.NumberToString(sX) & " " & GetTherionDistanceUnit(iXType) & vbCrLf
                If bYEnabled Then sText = sText & "y " & modNumbers.NumberToString(sY) & " " & GetTherionDistanceUnit(iYType) & vbCrLf
                If bZEnabled Then sText = sText & "z " & modNumbers.NumberToString(sZ) & " " & GetTherionDistanceUnit(iZType) & vbCrLf

                sText = sText & "endgrade"
                Return sText
            End If
        End Function

        Public Function IsEmpty() As Boolean
            Return Not (bDistanceEnabled OrElse bBearingEnabled OrElse bInclinationEnabled OrElse bDepthEnabled OrElse bXEnabled OrElse bYEnabled OrElse bZEnabled)
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

        Public Property XEnabled As Boolean
            Get
                Return bXEnabled
            End Get
            Set(value As Boolean)
                bXEnabled = value
            End Set
        End Property

        Public Property YEnabled As Boolean
            Get
                Return bYEnabled
            End Get
            Set(value As Boolean)
                bYEnabled = value
            End Set
        End Property

        Public Property ZEnabled As Boolean
            Get
                Return bZEnabled
            End Get
            Set(value As Boolean)
                bZEnabled = value
            End Set
        End Property

        Public Property DepthEnabled As Boolean
            Get
                Return bDepthEnabled
            End Get
            Set(value As Boolean)
                bDepthEnabled = value
            End Set
        End Property

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

        Public Property Z As Single
            Get
                Return sZ
            End Get
            Set(value As Single)
                sZ = value
            End Set
        End Property

        Public Property Y As Single
            Get
                Return sY
            End Get
            Set(value As Single)
                sY = value
            End Set
        End Property

        Public Property X As Single
            Get
                Return sX
            End Get
            Set(value As Single)
                sX = value
            End Set
        End Property

        Public Property Depth As Single
            Get
                Return sDepth
            End Get
            Set(value As Single)
                sDepth = value
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

        Public Property ZType As cSegment.DistanceTypeEnum
            Get
                Return iZType
            End Get
            Set(value As cSegment.DistanceTypeEnum)
                iZType = value
            End Set
        End Property

        Public Property YType As cSegment.DistanceTypeEnum
            Get
                Return iYType
            End Get
            Set(value As cSegment.DistanceTypeEnum)
                iYType = value
            End Set
        End Property

        Public Property XType As cSegment.DistanceTypeEnum
            Get
                Return iXType
            End Get
            Set(value As cSegment.DistanceTypeEnum)
                iXType = value
            End Set
        End Property

        Public Property DepthType As cSegment.DistanceTypeEnum
            Get
                Return iDepthType
            End Get
            Set(value As cSegment.DistanceTypeEnum)
                iDepthType = value
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
            If bDepthEnabled Then
                Call oXmlGrade.SetAttribute("depthenabled", "1")
                Call oXmlGrade.SetAttribute("depth", modNumbers.NumberToString(sDepth))
                If iDepthType <> cSegment.DistanceTypeEnum.Meters Then
                    Call oXmlGrade.SetAttribute("depthtype", iDepthType)
                End If
            End If
            If bXEnabled Then
                Call oXmlGrade.SetAttribute("xenabled", "1")
                Call oXmlGrade.SetAttribute("x", modNumbers.NumberToString(sX))
                If iXType <> cSegment.DistanceTypeEnum.Meters Then
                    Call oXmlGrade.SetAttribute("xtype", iXType)
                End If
            End If
            If bYEnabled Then
                Call oXmlGrade.SetAttribute("yenabled", "1")
                Call oXmlGrade.SetAttribute("y", modNumbers.NumberToString(sY))
                If iYType <> cSegment.DistanceTypeEnum.Meters Then
                    Call oXmlGrade.SetAttribute("distancetype", iYType)
                End If
            End If
            If bZEnabled Then
                Call oXmlGrade.SetAttribute("zenabled", "1")
                Call oXmlGrade.SetAttribute("z", modNumbers.NumberToString(sZ))
                If iZType <> cSegment.DistanceTypeEnum.Meters Then
                    Call oXmlGrade.SetAttribute("distancetype", iZType)
                End If
            End If

            Call Parent.AppendChild(oXmlGrade)
            Return oXmlGrade
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Grade As XmlElement)
            oSurvey = Survey
            sID = modXML.GetAttributeValue(Grade, "id")
            sDescription = modXML.GetAttributeValue(Grade, "description", "")

            bDistanceEnabled = modXML.GetAttributeValue(Grade, "distanceenabled")
            If bDistanceEnabled Then
                sDistance = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "distance"))
                iDistanceType = modXML.GetAttributeValue(Grade, "distancetype")
            End If
            bBearingEnabled = modXML.GetAttributeValue(Grade, "bearingenabled")
            If bBearingEnabled Then
                sBearing = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "bearing"))
                iBearingType = modXML.GetAttributeValue(Grade, "bearingtype")
            End If
            bInclinationEnabled = modXML.GetAttributeValue(Grade, "inclinationenabled")
            If bInclinationEnabled Then
                sInclination = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "inclination"))
                iInclinationType = modXML.GetAttributeValue(Grade, "inclinationtype")
            End If

            bDepthEnabled = modXML.GetAttributeValue(Grade, "depthenabled")
            If bDepthEnabled Then
                sDepth = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "depth"))
                iDepthType = modXML.GetAttributeValue(Grade, "depthtype")
            End If

            bXEnabled = modXML.GetAttributeValue(Grade, "xenabled")
            If bXEnabled Then
                sX = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "x"))
                iXType = modXML.GetAttributeValue(Grade, "xtype")
            End If
            bYEnabled = modXML.GetAttributeValue(Grade, "yenabled")
            If bYEnabled Then
                sY = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "y"))
                iYType = modXML.GetAttributeValue(Grade, "ytype")
            End If
            bZEnabled = modXML.GetAttributeValue(Grade, "zenabled")
            If bZEnabled Then
                sZ = modNumbers.StringToSingle(modXML.GetAttributeValue(Grade, "z"))
                iZType = modXML.GetAttributeValue(Grade, "ztype")
            End If
        End Sub

        Public Overrides Function ToString() As String
            Return If(sDescription = "", "[" & sID & "]", sDescription)
        End Function
    End Class
End Namespace