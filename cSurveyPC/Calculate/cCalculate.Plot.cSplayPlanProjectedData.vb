Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSplayPlanProjectedData
        Implements cISplayProjectedData
        Private oParent As cIPlanProjectedData

        Private oSurvey As cSurvey

        Private sSegmentID As String
        Private oSegment As cSegment

        Private oToPoint As PointD
        Private oLeftPoint As PointD
        Private oRightPoint As PointD

        Private bInRange As Boolean

        Friend Function IsValid() As Boolean
            Return Not IsNothing(GetSplaySegment())
        End Function

        Friend Sub New(Parent As cIPlanProjectedData, Segment As cSegment, ToPoint As PointD, LeftPoint As PointD, RightPoint As PointD, InRange As Boolean)
            oParent = Parent
            oSegment = Segment
            sSegmentID = oSegment.ID
            oToPoint = ToPoint
            oLeftPoint = LeftPoint
            oRightPoint = RightPoint
            bInRange = InRange
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Parent As cIProjectedData, ByVal Item As XmlElement)
            oSurvey = Survey
            oParent = Parent
            sSegmentID = Item.GetAttribute("sid")

            'sTo = Item.GetAttribute("t")
            oToPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("x")), modNumbers.StringToDecimal(Item.GetAttribute("y")))
            If Item.HasAttribute("lx") Then
                oLeftPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("lx")), modNumbers.StringToDecimal(Item.GetAttribute("ly")))
            Else
                oLeftPoint = oToPoint
            End If
            If Item.HasAttribute("rx") Then
                oRightPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("rx")), modNumbers.StringToDecimal(Item.GetAttribute("ry")))
            Else
                oRightPoint = oToPoint
            End If

            bInRange = modXML.GetAttributeValue(Item, "ir", 1)
        End Sub

        Public Function GetSplaySegment() As cSegment Implements cISplayProjectedData.GetSplaySegment
            If IsNothing(oSegment) Then
                If oSurvey.Segments.Contains(sSegmentID) Then
                    oSegment = oSurvey.Segments(sSegmentID)
                End If
            End If
            Return oSegment
        End Function

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSPD As XmlElement = Document.CreateElement("spd")
            Call oXmlSPD.SetAttribute("sid", GetSplaySegment.ID)

            Call oXmlSPD.SetAttribute("x", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlSPD.SetAttribute("y", modNumbers.NumberToString(oToPoint.Y, ""))
            If oLeftPoint <> oToPoint Then
                Call oXmlSPD.SetAttribute("lx", modNumbers.NumberToString(oLeftPoint.X, ""))
                Call oXmlSPD.SetAttribute("ly", modNumbers.NumberToString(oLeftPoint.Y, ""))
            End If
            If oRightPoint <> oToPoint Then
                Call oXmlSPD.SetAttribute("rx", modNumbers.NumberToString(oRightPoint.X, ""))
                Call oXmlSPD.SetAttribute("ry", modNumbers.NumberToString(oRightPoint.Y, ""))
            End If

            'for now I save also data required in older version...this data are not used now
            Call oXmlSPD.SetAttribute("fp", "0")
            Call oXmlSPD.SetAttribute("t", [To])

            If Not bInRange Then Call oXmlSPD.SetAttribute("ir", "0")

            Call Parent.AppendChild(oXmlSPD)
            Return oXmlSPD
        End Function

        Public ReadOnly Property Parent As cIProjectedData Implements cISplayProjectedData.Parent
            Get
                Return oParent
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cISplayProjectedData.To
            Get
                Return GetSplaySegment.To
            End Get
        End Property

        Public ReadOnly Property ToPoint As PointD Implements cISplayProjectedData.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Public ReadOnly Property LeftPoint As PointD Implements cISplayProjectedData.LorUPoint
            Get
                Return oLeftPoint
            End Get
        End Property

        Public ReadOnly Property RightPoint As PointD Implements cISplayProjectedData.RorDPoint
            Get
                Return oRightPoint
            End Get
        End Property

        Public ReadOnly Property InRange As Boolean Implements cISplayProjectedData.InRange
            Get
                Return bInRange
            End Get
        End Property
    End Class
End Namespace
