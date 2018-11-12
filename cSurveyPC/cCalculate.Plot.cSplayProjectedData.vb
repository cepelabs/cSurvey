Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Friend Class cSplayProjectedData
        Private oParent As cIProjectedData
        Private sSegmentID As String
        Private sTo As String
        Private iFromPoint As cSplayProjectedDatas.SplayFromPointEnum
        Private oToPoint As PointD

        Friend Sub New(Parent As cIProjectedData, ByVal Item As XmlElement)
            oParent = Parent
            sSegmentID = Item.GetAttribute("sid")
            sTo = Item.GetAttribute("t")
            iFromPoint = modNumbers.StringToInteger(Item.GetAttribute("fp"))
            oToPoint = New PointD(modNumbers.StringToDecimal(Item.GetAttribute("x")), modNumbers.StringToDecimal(Item.GetAttribute("y")))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSPD As XmlElement = Document.CreateElement("spd")
            Call oXmlSPD.SetAttribute("sid", sSegmentID)
            Call oXmlSPD.SetAttribute("t", sTo)
            Call oXmlSPD.SetAttribute("fp", iFromPoint.ToString("D"))
            Call oXmlSPD.SetAttribute("x", modNumbers.NumberToString(oToPoint.X, ""))
            Call oXmlSPD.SetAttribute("y", modNumbers.NumberToString(oToPoint.Y, ""))
            Call Parent.AppendChild(oXmlSPD)
            Return oXmlSPD
        End Function

        Public ReadOnly Property Parent As cIProjectedData
            Get
                Return oParent
            End Get
        End Property

        Public ReadOnly Property [To] As String
            Get
                Return sto
            End Get
        End Property

        'Public ReadOnly Property GetSegment
        '    Get
        '        Return oSegment
        '    End Get
        'End Property

        Public ReadOnly Property FromPoint As PointD
            Get
                If iFromPoint = cSplayProjectedDatas.SplayFromPointEnum.From Then
                    Return oParent.FromPoint
                Else
                    Return oParent.ToPoint
                End If
            End Get
        End Property

        Public ReadOnly Property ToPoint As PointD
            Get
                Return oToPoint
            End Get
        End Property

        Friend Sub New(Parent As cIProjectedData, SegmentID As String, [To] As String, FromPoint As cSplayProjectedDatas.SplayFromPointEnum, ToPoint As PointD)
            oParent = Parent
            sSegmentID = SegmentID
            sTo = [To]
            iFromPoint = FromPoint
            oToPoint = ToPoint
        End Sub
    End Class

End Namespace
