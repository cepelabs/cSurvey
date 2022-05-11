Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cTrigPointPoint
        Public Enum ProjectionEnum
            FromTop = 0
            FromRightSide = 1
            Perpendicular = 9
        End Enum

        Private dX As Decimal
        Private dY As Decimal
        Private dZ As Decimal
        Private dD As Decimal

        Public Overrides Function Equals(obj As Object) As Boolean
            Return obj.x = dX AndAlso obj.y = dY AndAlso obj.z = dZ AndAlso obj.d = dD
        End Function

        Friend Sub MoveTo(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal? = Nothing)
            dX = X
            dY = Y
            dZ = Z
            dD = D
        End Sub

        Friend Sub MoveBy(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0)
            dX += X
            dY += Y
            dZ += Z
            dD += D
        End Sub

        Friend Sub New(ByVal Item As XmlElement)
            dX = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "x", 0))
            dY = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "y", 0))
            dZ = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "z", 0))
            dD = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "d", 0))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            Dim oXmlTrigpointPoint As XmlElement = Document.CreateElement(Name)
            Call oXmlTrigpointPoint.SetAttribute("x", modNumbers.NumberToString(dX, ""))
            Call oXmlTrigpointPoint.SetAttribute("y", modNumbers.NumberToString(dY, ""))
            Call oXmlTrigpointPoint.SetAttribute("z", modNumbers.NumberToString(dZ, ""))
            Call oXmlTrigpointPoint.SetAttribute("d", modNumbers.NumberToString(dD, ""))
            Call Parent.AppendChild(oXmlTrigpointPoint)
            Return oXmlTrigpointPoint
        End Function

        Friend Sub New(ByVal Point As cTrigPointPoint)
            With Point
                dX = .X
                dY = .Y
                dZ = .Z
                dD = .D
            End With
        End Sub

        Friend Sub New(ByVal Point As cTrigPointPoint, ByVal D As Decimal)
            With Point
                dX = .X
                dY = .Y
                dZ = .Z
                dD = D
            End With
        End Sub

        Friend Sub New(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0)
            dX = X
            dY = Y
            dZ = Z
            dD = D
        End Sub

        Friend Sub New(ByVal Point As PointD, ByVal Z As Decimal, Optional ByVal D As Decimal = 0)
            With Point
                dX = .X
                dY = .Y
                dZ = Z
                dD = D
            End With
        End Sub

        Friend Sub New(ByVal Point As PointF, ByVal Z As Decimal, Optional ByVal D As Decimal = 0)
            With Point
                dX = .X
                dY = .Y
                dZ = Z
                dD = D
            End With
        End Sub

        Public ReadOnly Property X As Decimal
            Get
                Return dX
            End Get
        End Property

        Public ReadOnly Property Y As Decimal
            Get
                Return dY
            End Get
        End Property

        Public ReadOnly Property Z As Decimal
            Get
                Return dZ
            End Get
        End Property

        Public ReadOnly Property D As Decimal
            Get
                Return dD
            End Get
        End Property

        Public Function IsEmpty() As Boolean
            Return dX = 0 AndAlso dY = 0 AndAlso dZ = 0 AndAlso dD = 0
        End Function

        Public Function To2DPoint(ByVal Projection As ProjectionEnum) As PointD
            If Projection = ProjectionEnum.FromTop Then
                Return New PointD(dX, dY)
            ElseIf Projection = ProjectionEnum.FromRightSide Then
                Return New PointD(dY, dZ)
            ElseIf Projection = ProjectionEnum.Perpendicular Then
                Return New PointD(dD, dZ)
            End If
        End Function

        Public Overrides Function ToString() As String
            Return "{X=" & dX & ",Y=" & dY & ",Z=" & dZ & ",D=" & dD & "}"
        End Function
    End Class
End Namespace
