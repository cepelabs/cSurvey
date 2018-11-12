Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cTrigPointSideMeasure
        Private oLeftRight As SortedList(Of String, cTrigPointLeftRightSideMeasure)
        Private oUpDown As SortedList(Of String, cTrigPointUpDownSideMeasure)

        Friend Sub New(ByVal Item As XmlElement)
            oUpDown = New SortedList(Of String, cTrigPointUpDownSideMeasure)
            oLeftRight = New SortedList(Of String, cTrigPointLeftRightSideMeasure)
            For Each oXMLLRItem As XmlElement In Item.Item("smlrs")
                Dim oLRItem As cTrigPointLeftRightSideMeasure = New cTrigPointLeftRightSideMeasure(oXMLLRItem)
                Call oLeftRight.Add(oLRItem.Connection, oLRItem)
            Next
            For Each oXMLUDItem As XmlElement In Item.Item("smuds")
                Dim oUDItem As cTrigPointUpDownSideMeasure = New cTrigPointUpDownSideMeasure(oXMLUDItem)
                Call oUpDown.Add(oUDItem.Connection, oUDItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigpointSideMeasure As XmlElement = Document.CreateElement("sm")
            Dim oXmlTrigpointSideMeasureLR As XmlElement = Document.CreateElement("smlrs")
            For Each oLRItem As cTrigPointLeftRightSideMeasure In oLeftRight.Values
                Call oLRItem.SaveTo(File, Document, oXmlTrigpointSideMeasureLR)
            Next
            Call oXmlTrigpointSideMeasure.AppendChild(oXmlTrigpointSideMeasureLR)
            Dim oXmlTrigpointSideMeasureUD As XmlElement = Document.CreateElement("smuds")
            For Each oUDItem As cTrigPointUpDownSideMeasure In oUpDown.Values
                Call oUDItem.SaveTo(File, Document, oXmlTrigpointSideMeasureUD)
            Next
            Call oXmlTrigpointSideMeasure.AppendChild(oXmlTrigpointSideMeasureUD)
            Call Parent.AppendChild(oXmlTrigpointSideMeasure)
            Return oXmlTrigpointSideMeasure
        End Function

        Friend Sub New()
            oUpDown = New SortedList(Of String, cTrigPointUpDownSideMeasure)
            oLeftRight = New SortedList(Of String, cTrigPointLeftRightSideMeasure)
        End Sub

        Friend Function AppendLeftRight(ByVal Connection As String, ByVal Left As Decimal, ByVal Right As Decimal, ByVal SideMeasureType As cSegment.SideMeasuresTypeEnum) As cTrigPointLeftRightSideMeasure
            If oLeftRight.ContainsKey(Connection) Then
                Call oLeftRight.Remove(Connection)
            End If
            Dim oSideMeasureItem As cTrigPointLeftRightSideMeasure = New cTrigPointLeftRightSideMeasure(Connection, Left, Right, SideMeasureType)
            Call oLeftRight.Add(Connection, oSideMeasureItem)
            Return oSideMeasureItem
        End Function

        Friend Function AppendUpDown(ByVal Connection As String, ByVal Up As Decimal, ByVal Down As Decimal) As cTrigPointUpDownSideMeasure
            If oUpDown.ContainsKey(Connection) Then
                Call oUpDown.Remove(Connection)
            End If
            Dim oSideMeasureItem As cTrigPointUpDownSideMeasure = New cTrigPointUpDownSideMeasure(Connection, Up, Down)
            Call oUpDown.Add(Connection, oSideMeasureItem)
            Return oSideMeasureItem
        End Function

        Public Function GetUpDown(ByVal Connection As String) As SizeD
            If oUpDown.ContainsKey(Connection) Then
                Return oUpDown(Connection).GetSize
            Else
                Return New SizeD(0, 0)
            End If
        End Function

        Public Function GetUpDown() As SizeD
            Dim sUp As Decimal = 0
            Dim sDown As Decimal = 0
            For Each oItem As cTrigPointUpDownSideMeasure In oUpDown.Values
                If oItem.Up > sUp Then sUp = oItem.Up
                If oItem.Down > sDown Then sDown = oItem.Down
            Next
            Return New SizeD(sUp, sDown)
        End Function

        Public Function GetLeftRight() As SizeD
            'ora come ora...senza specifiche...prendo il primo lr che trovo
            If oLeftRight.Count > 0 Then
                Return oLeftRight.Values(0).GetSize
            Else
                Return New SizeD(0, 0)
            End If
        End Function

        Public Function GetLeftRight(ByVal Connection As String) As SizeD
            If oLeftRight.ContainsKey(Connection) Then
                Return oLeftRight(Connection).GetSize
            Else
                Return New SizeD(0, 0)
            End If
        End Function
    End Class
End Namespace