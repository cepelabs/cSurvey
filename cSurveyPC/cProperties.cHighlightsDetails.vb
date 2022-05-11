Imports System.Xml
Imports cSurveyPC.cSurvey.Properties.cHighlightsDetail

Namespace cSurvey.Properties
    Public Class cHighlightsDetails
        Implements IEnumerable

        Private oSurvey As cSurvey

        Public Const RingKey As String = "_ring"
        Public Const EntranceKey As String = "_entrance"
        Public Const ExplorationKey As String = "_exploration"
        Public Const GPSDefaultFix As String = "_gpsdefaultfix"
        Public Const GPSManualFix As String = "_gpsmanualfix"
        Public Const ShotWithNote As String = "_shotwithnote"
        Public Const StationWithNote As String = "_stationwithnote"
        Public Const StationByAlt As String = "_stationbyalt"
        Public Const ShotByAlt As String = "_shotbyalt"

        Private oItems As Dictionary(Of String, cHighlightsDetail)

        Public Sub Clear()
            Call oItems.Clear()
            Call pAddDefaults()
        End Sub

        Private Sub pAddDefaults()
            If Not oItems.ContainsKey(RingKey) Then Call oItems.Add(RingKey, New cHighlightsDetail(oSurvey, RingKey, modMain.GetLocalizedString("properties.highlights.ringKey"), System.Drawing.Color.Blue, 1.665, 140, cHighlightsDetail.ApplyToEnum.Shots, "", True))
            If Not oItems.ContainsKey(EntranceKey) Then Call oItems.Add(EntranceKey, New cHighlightsDetail(oSurvey, EntranceKey, modMain.GetLocalizedString("properties.highlights.entranceKey"), System.Drawing.Color.Red, 10, 140, cHighlightsDetail.ApplyToEnum.Stations, "vb#>Details.Element.isentrance", True))
            If Not oItems.ContainsKey(ExplorationKey) Then Call oItems.Add(ExplorationKey, New cHighlightsDetail(oSurvey, ExplorationKey, modMain.GetLocalizedString("properties.highlights.explorationKey"), System.Drawing.Color.LightGreen, 10, 140, cHighlightsDetail.ApplyToEnum.Stations, "vb#>Details.Element.isinexploration", True))
            If Not oItems.ContainsKey(GPSDefaultFix) Then Call oItems.Add(GPSDefaultFix, New cHighlightsDetail(oSurvey, GPSDefaultFix, modMain.GetLocalizedString("properties.highlights.GPSDefaultFix"), System.Drawing.Color.DarkGreen, 10, 140, cHighlightsDetail.ApplyToEnum.Stations, "vb#>not Details.Element.coordinate.isempty andalso Details.Element.coordinate.fix=0", True))
            If Not oItems.ContainsKey(GPSManualFix) Then Call oItems.Add(GPSManualFix, New cHighlightsDetail(oSurvey, GPSManualFix, modMain.GetLocalizedString("properties.highlights.GPSManualFix"), System.Drawing.Color.DarkSeaGreen, 10, 140, cHighlightsDetail.ApplyToEnum.Stations, "vb#>not Details.Element.coordinate.isempty andalso Details.Element.coordinate.fix=1", True))
            If Not oItems.ContainsKey(ShotWithNote) Then Call oItems.Add(ShotWithNote, New cHighlightsDetail(oSurvey, ShotWithNote, modMain.GetLocalizedString("properties.highlights.shotWithNote"), System.Drawing.Color.Gold, 10, 140, cHighlightsDetail.ApplyToEnum.Stations, "vb#>Details.Element.note<>""""", True))
            If Not oItems.ContainsKey(StationWithNote) Then Call oItems.Add(StationWithNote, New cHighlightsDetail(oSurvey, StationWithNote, modMain.GetLocalizedString("properties.highlights.stationWithNote"), System.Drawing.Color.Gold, 10, 140, cHighlightsDetail.ApplyToEnum.Shots, "vb#>Details.Element.note<>""""", True))
            If Not oItems.ContainsKey(StationByAlt) Then Call oItems.Add(StationByAlt, New cHighlightsDetail(oSurvey, StationByAlt, modMain.GetLocalizedString("properties.highlights.stationByAlt"), System.Drawing.Color.Gray, 10, 140, cHighlightsDetail.ApplyToEnum.Stations, "vb#>>public function GetHighlight(Details as cStationHighlightDetails) as boolean" & vbCrLf & "Details.meters.color = Survey.calculate.trigpoints.zs.GetScaleColor(Survey.calculate.trigpoints(Details.element).point.z)" & vbCrLf & "Return True" & vbCrLf & "end function", True))
            If Not oItems.ContainsKey(ShotByAlt) Then Call oItems.Add(ShotByAlt, New cHighlightsDetail(oSurvey, ShotByAlt, modMain.GetLocalizedString("properties.highlights.shotByAlt"), System.Drawing.Color.Gray, 10, 140, cHighlightsDetail.ApplyToEnum.Shots, "vb#>>public function GetHighlight(Details as cShotHighlightDetails) as boolean" & vbCrLf & "Details.meters.colors = {Survey.calculate.trigpoints.zs.GetScaleColor(Survey.calculate.trigpoints(Details.element.getfromtrigpoint).point.z), Survey.calculate.trigpoints.zs.GetScaleColor(Survey.calculate.trigpoints(Details.element.gettotrigpoint).point.z)}" & vbCrLf & "Return True" & vbCrLf & "end function", True))
        End Sub

        Public Function Add(Item As cHighlightsDetail) As cHighlightsDetail
            Return Add(Item.Name, Item.Color, Item.Size, Item.Opacity, Item.ApplyTo, Item.Condition)
        End Function

        Public Function Add(Name As String, ApplyTo As ApplyToEnum, Condition As String) As cHighlightsDetail
            Return Add(Name, System.Drawing.Color.Red, 10, 140, ApplyTo, Condition)
        End Function

        Public Function Add(Name As String, Color As Color, Size As Single, Opacity As Byte, ApplyTo As ApplyToEnum, Condition As String) As cHighlightsDetail
            If Not oItems.ContainsKey(Name) Then
                Dim oItem As cHighlightsDetail = New cHighlightsDetail(oSurvey, Name, Color, Size, Opacity, ApplyTo, Condition, False)
                Call oItems.Add(oItem.ID, oItem)
                Return oItem
            Else
                Return Nothing
            End If
        End Function

        Public Sub Remove(ID As String)
            If oItems.ContainsKey(ID) AndAlso Not oItems(ID).System Then
                Call oItems.Remove(ID)
            End If
        End Sub

        Default Public ReadOnly Property Item(ID As String) As cHighlightsDetail
            Get
                If oItems.ContainsKey(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLHighlightsDetails As XmlElement = Document.CreateElement("hlsds")
            For Each oItem As cHighlightsDetail In oItems.Values
                'If Not oItem.System Then
                Call oItem.SaveTo(File, Document, oXMLHighlightsDetails)
                'End If
            Next
            Call Parent.AppendChild(oXMLHighlightsDetails)
            Return oXMLHighlightsDetails
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function Contains(ID As String)
            Return oItems.ContainsKey(ID)
        End Function

        Public Function Contains(Item As cHighlightsDetail)
            Return oItems.ContainsValue(Item)
        End Function

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cHighlightsDetail)(StringComparer.CurrentCultureIgnoreCase)
            Call pAddDefaults()
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal HLSDetails As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cHighlightsDetail)(StringComparer.CurrentCultureIgnoreCase)
            For Each oXMLItem As XmlElement In HLSDetails.ChildNodes
                Dim oItem As cHighlightsDetail = New cHighlightsDetail(oSurvey, oXMLItem)
                Call oItems.Add(oItem.ID, oItem)
            Next
            Call pAddDefaults()
        End Sub
    End Class
End Namespace
