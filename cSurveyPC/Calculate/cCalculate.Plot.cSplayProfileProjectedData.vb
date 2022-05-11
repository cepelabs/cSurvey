Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSplayProfileProjectedData
        Implements cISplayProjectedData
        Private oParent As cIProfileProjectedData

        Private oSurvey As cSurvey

        Private sSegmentID As String
        Private oSegment As cSegment

        Private oToPoint As PointD
        Private oUpPoint As PointD
        Private oDownPoint As PointD

        Private bInRange As Boolean

        Friend Function IsValid() As Boolean
            Return Not IsNothing(GetSplaySegment())
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Parent As cIProjectedData, ByVal Item As XmlElement)
            oSurvey = Survey
            oParent = Parent
            sSegmentID = Item.GetAttribute("sid")

            'sTo = Item.GetAttribute("t")
            oToPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("x")), modNumbers.StringToDecimal(Item.GetAttribute("y")))
            If Item.HasAttribute("ux") Then
                oUpPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("ux")), modNumbers.StringToDecimal(Item.GetAttribute("uy")))
            Else
                oUpPoint = oToPoint
            End If
            If Item.HasAttribute("dx") Then
                oDownPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("dx")), modNumbers.StringToDecimal(Item.GetAttribute("dy")))
            Else
                oDownPoint = oToPoint
            End If

            bInRange = modXML.GetAttributeValue(Item, "ir", 1)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSPD As XmlElement = Document.CreateElement("spd")
            Call oXmlSPD.SetAttribute("sid", sSegmentID)

            Call oXmlSPD.SetAttribute("x", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlSPD.SetAttribute("y", modNumbers.NumberToString(oToPoint.Y, ""))
            If oUpPoint <> oToPoint Then
                Call oXmlSPD.SetAttribute("ux", modNumbers.NumberToString(oUpPoint.X, ""))
                Call oXmlSPD.SetAttribute("uy", modNumbers.NumberToString(oUpPoint.Y, ""))
            End If
            If oDownPoint <> oToPoint Then
                Call oXmlSPD.SetAttribute("dx", modNumbers.NumberToString(oDownPoint.X, ""))
                Call oXmlSPD.SetAttribute("dy", modNumbers.NumberToString(oDownPoint.Y, ""))
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

        Public Function GetSplaySegment() As cSegment Implements cISplayProjectedData.GetSplaySegment
            If IsNothing(oSegment) Then
                If oSurvey.Segments.Contains(sSegmentID) Then
                    oSegment = oSurvey.Segments(sSegmentID)
                End If
            End If
            Return oSegment
        End Function

        Public ReadOnly Property ToPoint As PointD Implements cISplayProjectedData.ToPoint
            Get
                Return oToPoint
            End Get
        End Property

        Public ReadOnly Property UpPoint As PointD Implements cISplayProjectedData.LorUPoint
            Get
                Return oUpPoint
            End Get
        End Property

        Public ReadOnly Property DownPoint As PointD Implements cISplayProjectedData.RorDPoint
            Get
                Return oDownPoint
            End Get
        End Property

        Friend Sub New(Parent As cIProfileProjectedData, Segment As cSegment, ToPoint As PointD, UpPoint As PointD, DownPoint As PointD, InRange As Boolean)
            oParent = Parent
            oSegment = Segment
            sSegmentID = oSegment.ID
            oToPoint = ToPoint
            oUpPoint = UpPoint
            oDownPoint = DownPoint
            bInRange = InRange
        End Sub

        Public ReadOnly Property InRange As Boolean Implements cISplayProjectedData.InRange
            Get
                Return bInRange
            End Get
        End Property
    End Class
End Namespace
