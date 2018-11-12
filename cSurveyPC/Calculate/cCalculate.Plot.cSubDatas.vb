Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cSubDatas
        Implements IEnumerable

        Private oParent As cData
        Private oItems As List(Of cSubData)

        Friend Sub New(Parent As cData, ByVal Item As XmlElement)
            oParent = Parent
            oItems = New List(Of cSubData)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cSubData = New cSubData(oParent, oXMLItem)
                Call oItems.Add(oItem)
                Call oParent.Plan.SubDatas.Append(oItem.Plan)
                Call oParent.Profile.SubDatas.Append(oItem.Profile)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSDS As XmlElement = Document.CreateElement("sds")
            For Each oItem As cSubData In oItems
                Call oItem.SaveTo(File, Document, oXmlSDS)
            Next
            Call Parent.AppendChild(oXmlSDS)
            Return oXmlSDS
        End Function

        Friend Function Add([From] As String, [To] As String, Distance As Decimal)
            Dim oItem As cSubData = New cSubData(oParent, [From], [To], Distance, oParent.Plan.FromPoint, oParent.Plan.ToPoint, oParent.Profile.FromPoint, oParent.Profile.ToPoint)
            Call oItems.Add(oItem)
            Call oParent.Plan.SubDatas.Append(oItem.Plan)
            Call oParent.Profile.SubDatas.Append(oItem.Profile)
            Return oItem
        End Function

        Friend Function Add([From] As String, [To] As String, Distance As Decimal, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal)
            Dim oItem As cSubData = New cSubData(oParent, [From], [To], Distance, oParent.Plan.FromPoint, oParent.Plan.ToPoint, oParent.Profile.FromPoint, oParent.Profile.ToPoint, FromBearingLeft, FromBearingRight, ToBearingLeft, ToBearingRight)
            Call oItems.Add(oItem)
            Call oParent.Plan.SubDatas.Append(oItem.Plan)
            Call oParent.Profile.SubDatas.Append(oItem.Profile)
            Return oItem
        End Function

        Friend Function Add([From] As String, [To] As String, Distance As Decimal, PlanFromPoint As PointD, PlanToPoint As PointD, ProfileFromPoint As PointD, ProfileToPoint As PointD, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal) As cSubData
            Dim oItem As cSubData = New cSubData(oParent, [From], [To], Distance, PlanFromPoint, PlanToPoint, ProfileFromPoint, ProfileToPoint, FromBearingLeft, FromBearingRight, ToBearingLeft, ToBearingRight)
            Call oItems.Add(oItem)
            Call oParent.Plan.SubDatas.Append(oItem.Plan)
            Call oParent.Profile.SubDatas.Append(oItem.Profile)
            Return oItem
        End Function

        Friend Function Add([From] As String, [To] As String, Distance As Decimal, PlanFromPoint As PointD, PlanToPoint As PointD, ProfileFromPoint As PointD, ProfileToPoint As PointD, FromLeft As Decimal, FromRight As Decimal, FromUp As Decimal, FromDown As Decimal, ToLeft As Decimal, ToRight As Decimal, ToUp As Decimal, ToDown As Decimal, FromBearingLeft As Decimal, FromBearingRight As Decimal, ToBearingLeft As Decimal, ToBearingRight As Decimal) As cSubData
            Dim oItem As cSubData = New cSubData(oParent, [From], [To], Distance, PlanFromPoint, PlanToPoint, ProfileFromPoint, ProfileToPoint, FromBearingLeft, FromBearingRight, ToBearingLeft, ToBearingRight)
            Call oItems.Add(oItem)
            Call oParent.Plan.SubDatas.Append(oItem.Plan)
            Call oParent.Profile.SubDatas.Append(oItem.Profile)
            Return oItem
        End Function

        Friend Sub Clear()
            Call oItems.Clear()
            Call oParent.Plan.SubDatas.Clear()
            Call oParent.Profile.SubDatas.Clear()
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cSubData
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New(Parent As cData)
            oParent = Parent
            oItems = New List(Of cSubData)
        End Sub
    End Class
End Namespace