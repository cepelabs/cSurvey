Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cSubData
        Implements cISpatialData

        Private oParent As cData

        Private [sFrom] As String
        Private [sTo] As String

        Private dDistance As Decimal

        Private oPlan As cPlanSubData
        Private oProfile As cProfileSubData

        Friend Sub New(Parent As cData, ByVal Item As XmlElement)
            oParent = Parent
            sFrom = Item.GetAttribute("sf")
            sTo = Item.GetAttribute("st")
            dDistance = modNumbers.StringToDecimal(modXML.GetAttributeValue(Item, "d", 0))
            oPlan = New cPlanSubData(Me, Item.Item("plansd"))
            oProfile = New cProfileSubData(Me, Item.Item("profilesd"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSD As XmlElement = Document.CreateElement("sd")
            Call oXmlSD.SetAttribute("sf", sFrom)
            Call oXmlSD.SetAttribute("st", sTo)
            Call oXmlSD.SetAttribute("d", modNumbers.NumberToString(dDistance, ""))
            Call oPlan.SaveTo(File, Document, oXmlSD)
            Call oProfile.SaveTo(File, Document, oXmlSD)
            Call Parent.AppendChild(oXmlSD)
            Return oXmlSD
        End Function

        Public ReadOnly Property Distance As Decimal Implements cISpatialData.Distance
            Get
                Return dDistance
            End Get
        End Property

        Public ReadOnly Property Inclination As Decimal Implements cISpatialData.Inclination
            Get
                Return oParent.SourceData.Inclination
            End Get
        End Property

        Public ReadOnly Property Bearing As Decimal Implements cISpatialData.Bearing
            Get
                Return oParent.SourceData.Bearing
            End Get
        End Property

        Public ReadOnly Property [To] As String Implements cISpatialData.To
            Get
                Return sTo
            End Get
        End Property

        Public ReadOnly Property From As String Implements cISpatialData.From
            Get
                Return sFrom
            End Get
        End Property

        Friend Sub RenameFrom(Newname As String)
            sFrom = Newname
        End Sub

        Friend Sub RenameTo(Newname As String)
            sTo = Newname
        End Sub

        Friend Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal, PlanFromPoint As PointD, PlanToPoint As PointD, ProfileFromPoint As PointD, ProfileToPoint As PointD)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            oPlan = New cPlanSubData(Me, PlanFromPoint, PlanToPoint)
            oProfile = New cProfileSubData(Me, ProfileFromPoint, ProfileToPoint)
        End Sub

        Friend Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal, PlanFromPoint As PointD, PlanToPoint As PointD, ProfileFromPoint As PointD, ProfileToPoint As PointD, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            oPlan = New cPlanSubData(Me, PlanFromPoint, PlanToPoint, 0, 0, 0, 0, FromBearingLeft, FromBearingRight, ToBearingLeft, ToBearingRight)
            oProfile = New cProfileSubData(Me, ProfileFromPoint, ProfileToPoint)
        End Sub

        Friend Sub New(Parent As cData, [From] As String, [To] As String, Distance As Decimal, PlanFromPoint As PointD, PlanToPoint As PointD, ProfileFromPoint As PointD, ProfileToPoint As PointD, FromLeft As Decimal, FromRight As Decimal, FromUp As Decimal, FromDown As Decimal, ToLeft As Decimal, ToRight As Decimal, ToUp As Decimal, ToDown As Decimal, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal)
            oParent = Parent
            sFrom = [From]
            sTo = [To]
            dDistance = Distance
            oPlan = New cPlanSubData(Me, PlanFromPoint, PlanToPoint, FromLeft, FromRight, ToLeft, ToRight, FromBearingLeft, FromBearingRight, ToBearingLeft, ToBearingRight)
            oProfile = New cProfileSubData(Me, ProfileFromPoint, ProfileToPoint, FromUp, FromDown, ToUp, ToDown)
        End Sub

        Public Sub SetLRUD(FromLeft As Decimal, FromRight As Decimal, FromUp As Decimal, FromDown As Decimal, ToLeft As Decimal, ToRight As Decimal, ToUp As Decimal, ToDown As Decimal)
            Call oPlan.SetLR(FromLeft, FromRight, ToLeft, ToRight)
            Call oProfile.SetUD(FromUp, FromDown, ToUp, ToDown)
        End Sub

        Public ReadOnly Property FromLeft As Decimal
            Get
                Return oPlan.FromLeft
            End Get
        End Property

        Public ReadOnly Property FromRight As Decimal
            Get
                Return oPlan.FromRight
            End Get
        End Property

        Public ReadOnly Property FromUp As Decimal
            Get
                Return oProfile.FromUp
            End Get
        End Property

        Public ReadOnly Property FromDown As Decimal
            Get
                Return oProfile.FromDown
            End Get
        End Property

        Public ReadOnly Property ToLeft As Decimal
            Get
                Return oPlan.ToLeft
            End Get
        End Property

        Public ReadOnly Property ToRight As Decimal
            Get
                Return oPlan.ToRight
            End Get
        End Property

        Public ReadOnly Property ToUp As Decimal
            Get
                Return oProfile.ToUp
            End Get
        End Property

        Public ReadOnly Property ToDown As Decimal
            Get
                Return oProfile.ToDown
            End Get
        End Property

        Public ReadOnly Property Plan As cPlanSubData
            Get
                Return oPlan
            End Get
        End Property

        Public ReadOnly Property Profile As cProfileSubData
            Get
                Return oProfile
            End Get
        End Property

        Public ReadOnly Property Reversed As Boolean Implements cISpatialData.Reversed
            Get
                Return oParent.SourceData.Reversed
            End Get
        End Property

        Public ReadOnly Property Direction As DirectionEnum Implements cISpatialData.Direction
            Get
                Return oParent.SourceData.Direction
            End Get
        End Property
    End Class
End Namespace
