Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Interface cIPlanProjectedData
        Inherits cIProjectedData
        ReadOnly Property FromSidePointRight() As PointD
        ReadOnly Property FromSidePointLeft() As PointD
        ReadOnly Property ToSidePointRight() As PointD
        ReadOnly Property ToSidePointLeft() As PointD

        ReadOnly Property FromBearingLeft As Decimal
        ReadOnly Property FromBearingRight As Decimal
        ReadOnly Property ToBearingLeft As Decimal
        ReadOnly Property ToBearingRight As Decimal
    End Interface

    Friend Interface cIPlanProjectedDataWithSplay
        Inherits cIPlanProjectedData
        ReadOnly Property FromSplays As cSplayPlanProjectedDatas
        ReadOnly Property ToSplays As cSplayPlanProjectedDatas
        ReadOnly Property SubDatas As cPlanSubDatas
        Function GetProjectedDistance() As Decimal
    End Interface

    Friend Class cPlanProjectedData
        Implements cIPlanProjectedDataWithSplay
        Private oSurvey As cSurvey

        Private bChanged As Boolean

        Private sFrom As String
        Private sTo As String

        Private sOldFrom As String
        Private sOldTo As String

        Private oOldFromPoint As PointD
        Private oOldToPoint As PointD
        Private oOldFromSidePointRight As PointD
        Private dOldFromBearingRight As Decimal
        Private oOldFromSidePointLeft As PointD
        Private dOldFromBearingLeft As Decimal
        Private oOldToSidePointRight As PointD
        Private dOldToBearingRight As Decimal
        Private oOldToSidePointLeft As PointD
        Private dOldToBearingLeft As Decimal

        Private oFromPoint As PointD
        Private oToPoint As PointD

        Private oFromSidePointRight As PointD
        Private oFromSidePointLeft As PointD
        Private oToSidePointRight As PointD
        Private oToSidePointLeft As PointD

        Private dFromBearingRight As Decimal
        Private dFromBearingLeft As Decimal
        Private dToBearingRight As Decimal
        Private dToBearingLeft As Decimal

        Private bReversed As Boolean

        Private oFromSplays As cSplayPlanProjectedDatas
        Private oToSplays As cSplayPlanProjectedDatas

        Private oSubDatas As cPlanSubDatas

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey

            bChanged = modXML.GetAttributeValue(Item, "c", 0)
            '------------------------------------------------------------------------
            sOldFrom = Item.GetAttribute("of")
            sOldTo = Item.GetAttribute("ot")

            oOldFromPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofpy", 0)))
            oOldToPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otpy", 0)))

            oOldFromSidePointRight = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofsprx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofspry", 0)))
            oOldFromSidePointLeft = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofsplx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofsply", 0)))
            oOldToSidePointRight = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otsprx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otspry", 0)))
            oOldToSidePointLeft = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otsplx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otsply", 0)))

            dOldFromBearingRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofbr", 0))
            dOldFromBearingLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "ofbl", 0))
            dOldToBearingRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otbr", 0))
            dOldToBearingLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "otbl", 0))
            '------------------------------------------------------------------------
            sFrom = Item.GetAttribute("f")
            sTo = Item.GetAttribute("t")

            oFromPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fpy", 0)))
            oToPoint = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tpy", 0)))

            oFromSidePointRight = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fsprx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fspry", 0)))
            oFromSidePointLeft = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fsplx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fsply", 0)))
            oToSidePointRight = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tsprx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tspry", 0)))
            oToSidePointLeft = New PointD(modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tsplx", 0)), modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tsply", 0)))

            dFromBearingRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fbr", 0))
            dFromBearingLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "fbl", 0))
            dToBearingRight = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tbr", 0))
            dToBearingLeft = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "tbl", 0))
            '------------------------------------------------------------------------
            bReversed = modXML.GetAttributeValue(Item, "r", 0)
            oFromSplays = New cSplayPlanProjectedDatas(Survey, Me, Item.Item("fspds"))
            oToSplays = New cSplayPlanProjectedDatas(Survey, Me, Item.Item("tspds"))
            oSubDatas = New cPlanSubDatas()
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPlanPD As XmlElement = Document.CreateElement("planpd")
            '------------------------------------------------------------------------
            If bChanged Then oXmlPlanPD.SetAttribute("c", 1)
            '------------------------------------------------------------------------
            Call oXmlPlanPD.SetAttribute("of", sOldFrom)
            Call oXmlPlanPD.SetAttribute("ot", sOldTo)

            Call oXmlPlanPD.SetAttribute("ofpx", modNumbers.NumberToString(oOldFromPoint.X, ""))
            Call oXmlPlanPD.SetAttribute("ofpy", modNumbers.NumberToString(oOldFromPoint.Y, ""))
            Call oXmlPlanPD.SetAttribute("otpx", modNumbers.NumberToString(oOldToPoint.X, ""))
            Call oXmlPlanPD.SetAttribute("otpy", modNumbers.NumberToString(oOldToPoint.Y, ""))

            Call oXmlPlanPD.SetAttribute("ofsprx", modNumbers.NumberToString(oOldFromSidePointRight.X, ""))
            Call oXmlPlanPD.SetAttribute("ofspry", modNumbers.NumberToString(oOldFromSidePointRight.Y, ""))
            Call oXmlPlanPD.SetAttribute("ofsplx", modNumbers.NumberToString(oOldFromSidePointLeft.X, ""))
            Call oXmlPlanPD.SetAttribute("ofsply", modNumbers.NumberToString(oOldFromSidePointLeft.Y, ""))
            Call oXmlPlanPD.SetAttribute("otsprx", modNumbers.NumberToString(oOldToSidePointRight.X, ""))
            Call oXmlPlanPD.SetAttribute("otspry", modNumbers.NumberToString(oOldToSidePointRight.Y, ""))
            Call oXmlPlanPD.SetAttribute("otsplx", modNumbers.NumberToString(oOldToSidePointLeft.X, ""))
            Call oXmlPlanPD.SetAttribute("otsply", modNumbers.NumberToString(oOldToSidePointLeft.Y, ""))

            Call oXmlPlanPD.SetAttribute("ofbr", modNumbers.NumberToString(dOldFromBearingRight, ""))
            Call oXmlPlanPD.SetAttribute("ofbl", modNumbers.NumberToString(dOldFromBearingLeft, ""))
            Call oXmlPlanPD.SetAttribute("otbr", modNumbers.NumberToString(dOldToBearingRight, ""))
            Call oXmlPlanPD.SetAttribute("otbl", modNumbers.NumberToString(dOldToBearingLeft, ""))
            '------------------------------------------------------------------------

            Call oXmlPlanPD.SetAttribute("f", sFrom)
            Call oXmlPlanPD.SetAttribute("t", sTo)

            Call oXmlPlanPD.SetAttribute("fpx", modNumbers.NumberToString(oFromPoint.X, ""))
            Call oXmlPlanPD.SetAttribute("fpy", modNumbers.NumberToString(oFromPoint.Y, ""))
            Call oXmlPlanPD.SetAttribute("tpx", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlPlanPD.SetAttribute("tpy", modNumbers.NumberToString(oToPoint.Y, ""))

            Call oXmlPlanPD.SetAttribute("fsprx", modNumbers.NumberToString(oFromSidePointRight.X, ""))
            Call oXmlPlanPD.SetAttribute("fspry", modNumbers.NumberToString(oFromSidePointRight.Y, ""))
            Call oXmlPlanPD.SetAttribute("fsplx", modNumbers.NumberToString(oFromSidePointLeft.X, ""))
            Call oXmlPlanPD.SetAttribute("fsply", modNumbers.NumberToString(oFromSidePointLeft.Y, ""))
            Call oXmlPlanPD.SetAttribute("tsprx", modNumbers.NumberToString(oToSidePointRight.X, ""))
            Call oXmlPlanPD.SetAttribute("tspry", modNumbers.NumberToString(oToSidePointRight.Y, ""))
            Call oXmlPlanPD.SetAttribute("tsplx", modNumbers.NumberToString(oToSidePointLeft.X, ""))
            Call oXmlPlanPD.SetAttribute("tsply", modNumbers.NumberToString(oToSidePointLeft.Y, ""))

            Call oXmlPlanPD.SetAttribute("fbr", modNumbers.NumberToString(dFromBearingRight, ""))
            Call oXmlPlanPD.SetAttribute("fbl", modNumbers.NumberToString(dFromBearingLeft, ""))
            Call oXmlPlanPD.SetAttribute("tbr", modNumbers.NumberToString(dToBearingRight, ""))
            Call oXmlPlanPD.SetAttribute("tbl", modNumbers.NumberToString(dToBearingLeft, ""))
            '------------------------------------------------------------------------
            If bReversed Then oXmlPlanPD.SetAttribute("r", "1")
            Call oFromSplays.SaveTo(File, Document, oXmlPlanPD, "fspds")
            Call oToSplays.SaveTo(File, Document, oXmlPlanPD, "tspds")
            Call Parent.AppendChild(oXmlPlanPD)
            Return oXmlPlanPD
        End Function

        Private dProjectedDistance As Decimal?

        Public Function GetProjectedDistance() As Decimal Implements cIPlanProjectedDataWithSplay.GetProjectedDistance
            If dProjectedDistance.HasValue Then
                Return dProjectedDistance.Value
            Else
                dProjectedDistance = modPaint.DistancePointToPoint(oFromPoint, oToPoint)
                Return dProjectedDistance.Value
            End If
        End Function

        Public ReadOnly Property SubDatas As cPlanSubDatas Implements cIPlanProjectedDataWithSplay.SubDatas
            Get
                Return oSubDatas
            End Get
        End Property

        Public ReadOnly Property FromSplays As cSplayPlanProjectedDatas Implements cIPlanProjectedDataWithSplay.FromSplays
            Get
                Return oFromSplays
            End Get
        End Property

        Public ReadOnly Property ToSplays As cSplayPlanProjectedDatas Implements cIPlanProjectedDataWithSplay.ToSplays
            Get
                Return oToSplays
            End Get
        End Property

        Public ReadOnly Property [From] As String Implements cIPlanProjectedDataWithSplay.From
            Get
                Return sFrom
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cIPlanProjectedDataWithSplay.To
            Get
                Return sTo
            End Get
        End Property

        Public ReadOnly Property FromPoint() As PointD Implements cIPlanProjectedDataWithSplay.FromPoint
            Get
                Return oFromPoint
            End Get
        End Property

        Public ReadOnly Property ToPoint() As PointD Implements cIPlanProjectedDataWithSplay.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Public Function GetCenterPoint() As PointD Implements cIPlanProjectedDataWithSplay.GetCenterPoint
            Return New PointD(oFromPoint.X - (oFromPoint.X - oToPoint.X) / 2, oFromPoint.Y - (oFromPoint.Y - oToPoint.Y) / 2)
        End Function

        Public ReadOnly Property FromSidePointRight() As PointD Implements cIPlanProjectedDataWithSplay.FromSidePointRight
            Get
                Return oFromSidePointRight
            End Get
        End Property

        Public ReadOnly Property FromSidePointLeft() As PointD Implements cIPlanProjectedDataWithSplay.FromSidePointLeft
            Get
                Return oFromSidePointLeft
            End Get
        End Property

        Public ReadOnly Property ToSidePointRight() As PointD Implements cIPlanProjectedDataWithSplay.ToSidePointRight
            Get
                Return oToSidePointRight
            End Get
        End Property

        Public ReadOnly Property ToSidePointLeft() As PointD Implements cIPlanProjectedDataWithSplay.ToSidePointLeft
            Get
                Return oToSidePointLeft
            End Get
        End Property

        Public ReadOnly Property FromBearingRight As Decimal Implements cIPlanProjectedDataWithSplay.FromBearingRight
            Get
                Return dFromBearingRight
            End Get
        End Property

        Public ReadOnly Property FromBearingLeft As Decimal Implements cIPlanProjectedDataWithSplay.FromBearingLeft
            Get
                Return dFromBearingLeft
            End Get
        End Property

        Public ReadOnly Property ToBearingRight As Decimal Implements cIPlanProjectedDataWithSplay.ToBearingRight
            Get
                Return dToBearingRight
            End Get
        End Property

        Public ReadOnly Property ToBearingLeft As Decimal Implements cIPlanProjectedDataWithSplay.ToBearingLeft
            Get
                Return dToBearingLeft
            End Get
        End Property

        Friend Sub SetPoints([From] As String, [To] As String, ByVal FromPoint As PointD, ByVal ToPoint As PointD, Optional ByVal DisableBackup As Boolean = False)
            If Not DisableBackup AndAlso Not (oFromPoint.IsEmpty AndAlso oToPoint.IsEmpty ) Then
                'If Not DisableBackup AndAlso Not (oFromPoint.IsEmpty AndAlso oToPoint.IsEmpty AndAlso oFromSidePointRight.IsEmpty AndAlso oFromSidePointLeft.IsEmpty AndAlso oToSidePointRight.IsEmpty AndAlso oToSidePointLeft.IsEmpty) Then
                sOldFrom = sFrom
                    sOldTo = sTo
                oOldFromPoint = oFromPoint
                oOldToPoint = oToPoint
                'oOldFromSidePointRight = oFromSidePointRight
                'dOldFromBearingRight = dFromBearingRight
                'oOldFromSidePointLeft = oFromSidePointLeft
                'dOldFromBearingLeft = dFromBearingLeft
                'oOldToSidePointRight = oToSidePointRight
                'dOldToBearingRight = dToBearingRight
                'oOldToSidePointLeft = oToSidePointLeft
                'dOldToBearingLeft = dToBearingLeft
            End If

            sFrom = [From]
            sTo = [To]
            oFromPoint = FromPoint
            oToPoint = ToPoint
            dProjectedDistance = Nothing

            If sOldFrom = sTo And sOldTo = sFrom Then
                bChanged = bChanged OrElse oOldFromPoint <> oToPoint OrElse oOldToPoint <> oFromPoint
                bReversed = True
            Else
                bChanged = bChanged OrElse oOldFromPoint <> oFromPoint OrElse oOldToPoint <> oToPoint
                bReversed = False
            End If
        End Sub

        Friend Sub SetSidePoints(ByVal FromSidePointRight As PointD, FromBearingRight As Decimal, ByVal FromSidePointLeft As PointD, FromBearingLeft As Decimal, ByVal ToSidePointRight As PointD, ToBearingRight As Decimal, ByVal ToSidePointLeft As PointD, ToBearingLeft As Decimal, Optional ByVal DisableBackup As Boolean = False)
            If Not DisableBackup AndAlso Not (oFromSidePointRight.IsEmpty AndAlso oFromSidePointLeft.IsEmpty AndAlso oToSidePointRight.IsEmpty AndAlso oToSidePointLeft.IsEmpty) Then
                oOldFromSidePointRight = oFromSidePointRight
                dOldFromBearingRight = dFromBearingRight
                oOldFromSidePointLeft = oFromSidePointLeft
                dOldFromBearingLeft = dFromBearingLeft
                oOldToSidePointRight = oToSidePointRight
                dOldToBearingRight = dToBearingRight
                oOldToSidePointLeft = oToSidePointLeft
                dOldToBearingLeft = dToBearingLeft
            End If

            'side points are not managed for changed state...
            If oFromSidePointRight <> FromSidePointRight Then
                oFromSidePointRight = FromSidePointRight
            End If
            If dFromBearingRight <> FromBearingRight Then
                dFromBearingRight = FromBearingRight
            End If

            If oFromSidePointLeft <> FromSidePointLeft Then
                oFromSidePointLeft = FromSidePointLeft
            End If
            If dFromBearingLeft <> FromBearingLeft Then
                dFromBearingLeft = FromBearingLeft
            End If

            If oToSidePointRight <> ToSidePointRight Then
                oToSidePointRight = ToSidePointRight
            End If
            If dToBearingRight <> ToBearingRight Then
                dToBearingRight = ToBearingRight
            End If

            If oToSidePointLeft <> ToSidePointLeft Then
                oToSidePointLeft = ToSidePointLeft
            End If
            If dToBearingLeft <> ToBearingLeft Then
                dToBearingLeft = ToBearingLeft
            End If
        End Sub

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
            oPolygon(0) = oToSidePointLeft
            oPolygon(1) = oToSidePointRight
            oPolygon(2) = oFromSidePointLeft
            oPolygon(3) = oFromSidePointRight
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
            oPolygon(0) = oOldToSidePointLeft
            oPolygon(1) = oOldToSidePointRight
            oPolygon(2) = oOldFromSidePointLeft
            oPolygon(3) = oOldFromSidePointRight
            Return oPolygon
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey

            sFrom = ""
            sTo = ""
            sOldFrom = ""
            sOldTo = ""
            oFromSplays = New cSplayPlanProjectedDatas(oSurvey, Me)
            oToSplays = New cSplayPlanProjectedDatas(oSurvey, Me)
            oSubDatas = New cPlanSubDatas
        End Sub
    End Class
End Namespace
