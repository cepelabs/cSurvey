Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Interface cIProfileProjectedData
        Inherits cIProjectedData
        ReadOnly Property FromSidePointUp() As PointD
        ReadOnly Property FromSidePointDown() As PointD
        ReadOnly Property ToSidePointUp() As PointD
        ReadOnly Property ToSidePointDown() As PointD
        'ReadOnly Property Direction As DirectionEnum
    End Interface

    Friend Interface cIProfileProjectedDataWithSplay
        Inherits cIProfileProjectedData
        ReadOnly Property FromSplays As cSplayProfileProjectedDatas
        ReadOnly Property ToSplays As cSplayProfileProjectedDatas
        ReadOnly Property SubDatas As cProfileSubDatas
        ReadOnly Property SurfaceProfile As cSurfaceProfileProjectedData
        Function GetProjectedDistance() As Decimal
    End Interface

    Friend Class cProfileProjectedData
        Implements cIProfileProjectedDataWithSplay
        Private oSurvey As cSurvey

        Private bChanged As Boolean

        Private sFrom As String
        Private sTo As String

        Private sOldFrom As String
        Private sOldTo As String

        Private oOldFromPoint As PointD
        Private oOldToPoint As PointD
        Private oOldFromSidePointUp As PointD
        Private oOldFromSidePointDown As PointD
        Private oOldToSidePointUp As PointD
        Private oOldToSidePointDown As PointD

        Private oFromPoint As PointD
        Private oToPoint As PointD

        Private oFromSidePointUp As PointD
        Private oFromSidePointDown As PointD
        Private oToSidePointUp As PointD
        Private oToSidePointDown As PointD

        Private bReversed As Boolean

        Private oFromSplays As cSplayProfileProjectedDatas
        Private oToSplays As cSplayProfileProjectedDatas

        'Private iDirection As DirectionEnum

        Private oSurfaceProfile As cSurfaceProfileProjectedData

        Private oSubDatas As cProfileSubDatas

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey

            bChanged = modXML.GetAttributeValue(Item, "c", 0)
            '------------------------------------------------------------------------
            sOldFrom = Item.GetAttribute("of")
            sOldTo = Item.GetAttribute("ot")

            oOldFromPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofpy", 0)))
            oOldToPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otpy", 0)))

            oOldFromSidePointUp = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofspux", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofspuy", 0)))
            oOldFromSidePointDown = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofspdx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofspdy", 0)))
            oOldToSidePointUp = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otspux", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otspuy", 0)))
            oOldToSidePointDown = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otspdx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otspdy", 0)))
            '------------------------------------------------------------------------
            sFrom = Item.GetAttribute("f")
            sTo = Item.GetAttribute("t")

            oFromPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpy", 0)))
            oToPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpy", 0)))

            oFromSidePointUp = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspux", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspuy", 0)))
            oFromSidePointDown = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspdx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspdy", 0)))
            oToSidePointUp = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspux", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspuy", 0)))
            oToSidePointDown = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspdx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspdy", 0)))
            '------------------------------------------------------------------------
            bReversed = modXML.GetAttributeValue(Item, "r", 0)
            oFromSplays = New cSplayProfileProjectedDatas(Survey, Me, Item.Item("fspds"))
            oToSplays = New cSplayProfileProjectedDatas(Survey, Me, Item.Item("tspds"))
            'iDirection = modNumbers.StringToInteger(Item.GetAttribute("d"))
            oSurfaceProfile = New cSurfaceProfileProjectedData(Me, Item.Item("surfaceprofilepd"))
            oSubDatas = New cProfileSubDatas()
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlProfilePD As XmlElement = Document.CreateElement("profilepd")
            '------------------------------------------------------------------------
            If bChanged Then oXmlProfilePD.SetAttribute("c", 1)
            '------------------------------------------------------------------------
            Call oXmlProfilePD.SetAttribute("of", sOldFrom)
            Call oXmlProfilePD.SetAttribute("ot", sOldTo)

            Call oXmlProfilePD.SetAttribute("ofpx", modNumbers.NumberToString(oOldFromPoint.X, ""))
            Call oXmlProfilePD.SetAttribute("ofpy", modNumbers.NumberToString(oOldFromPoint.Y, ""))
            Call oXmlProfilePD.SetAttribute("otpx", modNumbers.NumberToString(oOldToPoint.X, ""))
            Call oXmlProfilePD.SetAttribute("otpy", modNumbers.NumberToString(oOldToPoint.Y, ""))

            Call oXmlProfilePD.SetAttribute("ofspux", modNumbers.NumberToString(oOldFromSidePointUp.X, ""))
            Call oXmlProfilePD.SetAttribute("ofspuy", modNumbers.NumberToString(oOldFromSidePointUp.Y, ""))
            Call oXmlProfilePD.SetAttribute("ofspdx", modNumbers.NumberToString(oOldFromSidePointDown.X, ""))
            Call oXmlProfilePD.SetAttribute("ofspdy", modNumbers.NumberToString(oOldFromSidePointDown.Y, ""))
            Call oXmlProfilePD.SetAttribute("otspux", modNumbers.NumberToString(oOldToSidePointUp.X, ""))
            Call oXmlProfilePD.SetAttribute("otspuy", modNumbers.NumberToString(oOldToSidePointUp.Y, ""))
            Call oXmlProfilePD.SetAttribute("otspdx", modNumbers.NumberToString(oOldToSidePointDown.X, ""))
            Call oXmlProfilePD.SetAttribute("otspdy", modNumbers.NumberToString(oOldToSidePointDown.Y, ""))
            '------------------------------------------------------------------------
            Call oXmlProfilePD.SetAttribute("f", sFrom)
            Call oXmlProfilePD.SetAttribute("t", sTo)

            Call oXmlProfilePD.SetAttribute("fpx", modNumbers.NumberToString(oFromPoint.X, ""))
            Call oXmlProfilePD.SetAttribute("fpy", modNumbers.NumberToString(oFromPoint.Y, ""))
            Call oXmlProfilePD.SetAttribute("tpx", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlProfilePD.SetAttribute("tpy", modNumbers.NumberToString(oToPoint.Y, ""))

            Call oXmlProfilePD.SetAttribute("fspux", modNumbers.NumberToString(oFromSidePointUp.X, ""))
            Call oXmlProfilePD.SetAttribute("fspuy", modNumbers.NumberToString(oFromSidePointUp.Y, ""))
            Call oXmlProfilePD.SetAttribute("fspdx", modNumbers.NumberToString(oFromSidePointDown.X, ""))
            Call oXmlProfilePD.SetAttribute("fspdy", modNumbers.NumberToString(oFromSidePointDown.Y, ""))
            Call oXmlProfilePD.SetAttribute("tspux", modNumbers.NumberToString(oToSidePointUp.X, ""))
            Call oXmlProfilePD.SetAttribute("tspuy", modNumbers.NumberToString(oToSidePointUp.Y, ""))
            Call oXmlProfilePD.SetAttribute("tspdx", modNumbers.NumberToString(oToSidePointDown.X, ""))
            Call oXmlProfilePD.SetAttribute("tspdy", modNumbers.NumberToString(oToSidePointDown.Y, ""))
            '------------------------------------------------------------------------
            If bReversed Then oXmlProfilePD.SetAttribute("r", "1")
            Call oFromSplays.SaveTo(File, Document, oXmlProfilePD, "fspds")
            Call oToSplays.SaveTo(File, Document, oXmlProfilePD, "tspds")
            'Call oXmlProfilePD.SetAttribute("d", iDirection.ToString("D"))
            Call oSurfaceProfile.SaveTo(File, Document, oXmlProfilePD)
            Call Parent.AppendChild(oXmlProfilePD)
            Return oXmlProfilePD
        End Function

        Public ReadOnly Property SubDatas As cProfileSubDatas Implements cIProfileProjectedDataWithSplay.SubDatas
            Get
                Return oSubDatas
            End Get
        End Property

        Public ReadOnly Property SurfaceProfile As cSurfaceProfileProjectedData Implements cIProfileProjectedDataWithSplay.SurfaceProfile
            Get
                Return oSurfaceProfile
            End Get
        End Property

        Public ReadOnly Property FromSplays As cSplayProfileProjectedDatas Implements cIProfileProjectedDataWithSplay.FromSplays
            Get
                Return oFromSplays
            End Get
        End Property

        Public ReadOnly Property ToSplays As cSplayProfileProjectedDatas Implements cIProfileProjectedDataWithSplay.ToSplays
            Get
                Return oToSplays
            End Get
        End Property

        Public ReadOnly Property [From] As String Implements cIProfileProjectedDataWithSplay.From
            Get
                Return sFrom
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cIProfileProjectedDataWithSplay.To
            Get
                Return sTo
            End Get
        End Property

        Public ReadOnly Property FromPoint() As PointD Implements cIProfileProjectedDataWithSplay.FromPoint
            Get
                Return oFromPoint
            End Get
        End Property

        Public ReadOnly Property ToPoint() As PointD Implements cIProfileProjectedDataWithSplay.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Public Function GetCenterPoint() As PointD Implements cIProfileProjectedDataWithSplay.GetCenterPoint
            Return New PointD(oFromPoint.X - (oFromPoint.X - oToPoint.X) / 2, oFromPoint.Y - (oFromPoint.Y - oToPoint.Y) / 2)
        End Function

        Public ReadOnly Property FromSidePointDown() As PointD Implements cIProfileProjectedDataWithSplay.FromSidePointDown
            Get
                Return oFromSidePointDown
            End Get
        End Property

        Public ReadOnly Property FromSidePointUp() As PointD Implements cIProfileProjectedDataWithSplay.FromSidePointUp
            Get
                Return oFromSidePointUp
            End Get
        End Property

        Public ReadOnly Property ToSidePointDown() As PointD Implements cIProfileProjectedDataWithSplay.ToSidePointDown
            Get
                Return oToSidePointDown
            End Get
        End Property

        Public ReadOnly Property ToSidePointUp() As PointD Implements cIProfileProjectedDataWithSplay.ToSidePointUp
            Get
                Return oToSidePointUp
            End Get
        End Property

        Friend Sub SetPoints([From] As String, [To] As String, ByVal FromPoint As PointD, ByVal ToPoint As PointD, Optional ByVal DisableBackup As Boolean = False)
            If Not DisableBackup And Not (oFromPoint.IsEmpty And oToPoint.IsEmpty) Then
                sOldFrom = sFrom
                sOldTo = sTo
                oOldFromPoint = oFromPoint
                oOldToPoint = oToPoint
            End If

            sFrom = [From]
            sTo = [To]
            oFromPoint = FromPoint
            oToPoint = ToPoint
            dProjectedDistance = Nothing

            If sOldFrom = sTo AndAlso sOldTo = sFrom Then
                bChanged = bChanged OrElse oOldFromPoint <> oToPoint OrElse oOldToPoint <> oFromPoint
                bReversed = True
            Else
                bChanged = bChanged OrElse oOldFromPoint <> oFromPoint OrElse oOldToPoint <> oToPoint
                bReversed = False
            End If

            'If bChanged Then Stop
        End Sub

        Friend Sub SetSidePoints(ByVal FromSidePointDown As PointD, ByVal FromSidePointUp As PointD, ByVal ToSidePointDown As PointD, ByVal ToSidePointUp As PointD, Optional ByVal DisableBackup As Boolean = False)
            If Not DisableBackup And Not (oFromSidePointDown.IsEmpty And oFromSidePointUp.IsEmpty And oToSidePointDown.IsEmpty And oToSidePointUp.IsEmpty) Then
                oOldFromSidePointDown = oFromSidePointDown
                oOldFromSidePointUp = oFromSidePointUp
                oOldToSidePointDown = oToSidePointDown
                oOldToSidePointUp = oToSidePointUp
            End If

            'side points are not managed for changed state...
            If oFromSidePointDown <> FromSidePointDown Then
                oFromSidePointDown = FromSidePointDown
            End If
            If oFromSidePointUp <> FromSidePointUp Then
                oFromSidePointUp = FromSidePointUp
            End If
            If oToSidePointDown <> ToSidePointDown Then
                oToSidePointDown = ToSidePointDown
            End If
            If oToSidePointUp <> ToSidePointUp Then
                oToSidePointUp = ToSidePointUp
            End If
        End Sub

        Private dProjectedDistance As Decimal?

        Public Function GetProjectedDistance() As Decimal Implements cIProfileProjectedDataWithSplay.GetProjectedDistance
            If dProjectedDistance.HasValue Then
                Return dProjectedDistance.Value
            Else
                dProjectedDistance = modPaint.DistancePointToPoint(oFromPoint, oToPoint)
            End If
        End Function

        Friend Overridable ReadOnly Property Changed() As Boolean
            Get
                Return bChanged
            End Get
        End Property

        Friend Overridable Sub ResetChange()
            bChanged = False
        End Sub

        Friend Function GetVectorLine() As PointF()
            Dim oPoints(1) As PointF
            oPoints(0) = oFromPoint
            oPoints(1) = oToPoint
            Return oPoints
        End Function

        Friend Function GetLine() As PointF()
            Dim oPoints(1) As PointF
            If bReversed Then
                oPoints(0) = oToPoint
                oPoints(1) = oFromPoint
            Else
                oPoints(0) = oFromPoint
                oPoints(1) = oToPoint
            End If
            Return oPoints
        End Function

        Friend Function GetPolygon() As PointF()
            Dim oPolygon(3) As PointF
            oPolygon(0) = oToSidePointUp
            oPolygon(1) = oToSidePointDown
            oPolygon(2) = oFromSidePointUp
            oPolygon(3) = oFromSidePointDown
            Return oPolygon
        End Function

        Friend Function GetOldLine() As PointF()
            Dim oPoints(1) As PointF
            oPoints(0) = oOldFromPoint
            oPoints(1) = oOldToPoint
            Return oPoints
        End Function

        Friend Function GetOldPolygon() As PointF()
            Dim oPolygon(3) As PointF
            oPolygon(0) = oOldToSidePointUp
            oPolygon(1) = oOldToSidePointDown
            oPolygon(2) = oOldFromSidePointUp
            oPolygon(3) = oOldFromSidePointDown
            Return oPolygon
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey

            sFrom = ""
            sTo = ""
            sOldFrom = ""
            sOldTo = ""
            oFromSplays = New cSplayProfileProjectedDatas(oSurvey, Me)
            oToSplays = New cSplayProfileProjectedDatas(oSurvey, Me)
            oSubDatas = New cProfileSubDatas()
            oSurfaceProfile = New cSurfaceProfileProjectedData(Me)
        End Sub
    End Class
End Namespace