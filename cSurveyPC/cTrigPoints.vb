Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey
    Public Class cTrigPoints
        Implements IEnumerable
        Implements IEnumerable(Of cTrigPoint)
        Implements cITrigPointCollection

        Private oSurvey As cSurvey

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Class OnTrigpointEventArgs
            Inherits EventArgs

            Private oTrigpoint As cTrigPoint

            Public ReadOnly Property Trigpoint() As cTrigPoint
                Get
                    Return oTrigpoint
                End Get
            End Property

            Friend Sub New(ByVal Trigpoint As cTrigPoint)
                oTrigpoint = Trigpoint
            End Sub
        End Class

        Private oTrigPoints As SortedList(Of String, cTrigPoint)

        Friend Event OnTrigPointRebind(ByVal Sender As cTrigPoints, ByVal Args As OnTrigpointEventArgs)
        Friend Event OnTrigPointChange(ByVal Sender As cTrigPoints, ByVal Args As OnTrigpointEventArgs)

        Public ReadOnly Property Last() As cTrigPoint
            Get
                If oTrigPoints.Count > 0 Then
                    Return oTrigPoints.Last.Value
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property First() As cTrigPoint
            Get
                If oTrigPoints.Count > 0 Then
                    Return oTrigPoints.First.Value
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oTrigPoints = New SortedList(Of String, cTrigPoint) '(StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Function IndexOf(ByVal TrigPoint As cTrigPoint) As Integer
            Return oTrigPoints.IndexOfValue(TrigPoint)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal TrigPoints As XmlElement)
            oSurvey = Survey
            oTrigPoints = New SortedList(Of String, cTrigPoint) '(StringComparer.OrdinalIgnoreCase)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = TrigPoints.ChildNodes.Count
            Dim iStep As Integer = If(iCount > 20, iCount \ 20, 1)
            For Each oXmlTrigPoint As XmlElement In TrigPoints.ChildNodes
                iIndex += 1
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("load", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("trigpoints.load"), iIndex / iCount)
                Dim oItem As cTrigPoint = New cTrigPoint(oSurvey, oXmlTrigPoint)
                Call oTrigPoints.Add(oItem.Name, oItem)
                AddHandler oItem.OnChange, AddressOf oTrigPoint_OnChange
            Next
        End Sub

        Private Sub oTrigPoint_OnChange(ByVal Sender As cTrigPoint)
            RaiseEvent OnTrigPointChange(Me, New cTrigPoints.OnTrigpointEventArgs(Sender))
        End Sub

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cTrigPoint Implements cITrigPointCollection.Item
            Get
                Return oTrigPoints.ElementAt(Index).Value
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Name As String) As cTrigPoint Implements cITrigPointCollection.Item
            Get
                If oTrigPoints.ContainsKey(Name) Then
                    Return oTrigPoints(Name)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub Rebind(Optional ByVal RemoveOrphans As Boolean = False)
            Dim oTrigpointNames As SortedSet(Of String) = oSurvey.Segments.GetTrigPointsNames()
            'adding missing stations
            For Each sTrigPointName As String In oTrigpointNames
                If Not oTrigPoints.ContainsKey(sTrigPointName) Then
                    Call Add(sTrigPointName)
                End If
            Next
            'set not found station as orphan
            Dim sTrigPointsToRemove As List(Of String) = New List(Of String)
            For Each oTrigPoint As cTrigPoint In oTrigPoints.Values
                If Not oTrigpointNames.Contains(oTrigPoint.Name) And Not oTrigPoint.IsSystem Then
                    Call sTrigPointsToRemove.Add(oTrigPoint.Name)
                    Call oTrigPoint.Data.SetOrphan(True)
                Else
                    Call oTrigPoint.Data.SetOrphan(False)
                End If
            Next
            If RemoveOrphans Then
                'delete orphan stations
                For Each sTrigPointToRemove As String In sTrigPointsToRemove
                    Call oTrigPoints.Remove(sTrigPointToRemove)
                Next
                For Each oTrigPoint As cTrigPoint In oTrigPoints.Values
                    For Each sTrigPointToRemove As String In sTrigPointsToRemove
                        If oTrigPoint.Connections.Contains(sTrigPointToRemove) Then
                            Call oTrigPoint.Connections.Remove(sTrigPointToRemove)
                        End If
                    Next
                Next

                For Each oSketch As Design.cDesignSketch In oSurvey.Sketches
                    Call oSketch.Sketch.Stations.Rebind()
                Next
            End If

            For Each oTrigPoint As Calculate.cTrigPoint In oSurvey.Calculate.TrigPoints
                If oTrigPoint.Name <> "" Then
                    For Each oConnection As Calculate.cTrigPointConnection In oTrigPoint.Connections
                        If oTrigPoints.ContainsKey(oTrigPoint.Name) Then
                            Call oTrigPoints(oTrigPoint.Name).Connections.Rebind(oTrigPoint.Connections)
                        End If
                    Next
                End If
            Next

            RaiseEvent OnTrigPointRebind(Me, New OnTrigpointEventArgs(Nothing))
        End Sub

        Public Function Contains(ByVal TrigPoint As cTrigPoint) As Boolean Implements cITrigPointCollection.Contains
            Return oTrigPoints.ContainsValue(TrigPoint)
        End Function

        Public Function Contains(ByVal Name As String) As Boolean Implements cITrigPointCollection.Contains
            Return oTrigPoints.ContainsKey(Name)
        End Function

        Friend Function Add(ByVal Name As String, Optional ByVal X As Decimal = 0, Optional ByVal Y As Decimal = 0, Optional ByVal Z As Decimal = 0, Optional IsSystem As Boolean = False, Optional IsSplay As Boolean = False) As cTrigPoint
            If oTrigPoints.ContainsKey(Name) Then
                Return oTrigPoints(Name)
            Else
                Dim oItem As cTrigPoint = New cTrigPoint(oSurvey, Name, X, Y, Z, IsSystem)
                Call oTrigPoints.Add(Name, oItem)
                AddHandler oItem.OnChange, AddressOf oTrigPoint_OnChange
                Return oItem
            End If
        End Function

        Friend Sub Remove(ByVal Name As String)
            If oTrigPoints.ContainsKey(Name) Then
                Call oTrigPoints.Remove(Name)
            End If
        End Sub

        Friend Sub Clear()
            Call oTrigPoints.Clear()
        End Sub

        Public ReadOnly Property Count As Integer Implements cITrigPointCollection.Count
            Get
                Return oTrigPoints.Count
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXmlTrigPoints As XmlElement = Document.CreateElement("trigpoints")
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oTrigPoints.Count
            Dim iStep As Integer = If(iCount > 20, iCount \ 20, 1)
            For Each oTrigPoint As cTrigPoint In oTrigPoints.Values
                iIndex += 1
                If (Options And cSurvey.SaveOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("trigpoints.save"), iIndex / iCount)
                Call oTrigPoint.SaveTo(File, Document, oXmlTrigPoints, Options)
            Next
            Call Parent.AppendChild(oXmlTrigPoints)
            Return oXmlTrigPoints
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oTrigPoints.Values.GetEnumerator
        End Function

        Private Function cTrigpoint_GetEnumerator() As IEnumerator(Of cTrigPoint) Implements IEnumerable(Of cTrigPoint).GetEnumerator
            Return oTrigPoints.Values.GetEnumerator
        End Function

        Friend Sub RenameTrigPoint(ByVal OldName As String, ByVal NewName As String)
            OldName = OldName.ToUpper
            NewName = NewName.ToUpper
            If oTrigPoints.ContainsKey(OldName) AndAlso Not oTrigPoints.ContainsKey(NewName) Then
                Dim oItem As cTrigPoint = oTrigPoints(OldName)
                Call oItem.Rename(NewName)
                Call oTrigPoints.Remove(OldName)
                Call oTrigPoints.Add(NewName, oItem)

                'change connections
                Call oSurvey.Calculate.TrigPoints.Rename(OldName, NewName)
                For Each oTrigpoint As cTrigPoint In oTrigPoints.Values.Where(Function(item) item.Connections.Contains(OldName))
                    With oTrigpoint.Connections
                        Dim bIgnore As Boolean = .Get(OldName)
                        Call .Remove(OldName)
                        Call .[Set](NewName, bIgnore)
                    End With
                Next

                'change shots
                For Each oSegment As cSegment In oSurvey.Segments.ToList.Where(Function(item) item.[From] = OldName)
                    Call oSegment.RenameFrom(NewName)
                Next
                For Each oSegment As cSegment In oSurvey.Segments.ToList.Where(Function(item) item.[To] = OldName)
                    Call oSegment.RenameTo(NewName)
                Next

                'change graphical object with station references
                '- quote...
                For Each oItemQuota As cItemQuota In oSurvey.GetAllDesignItems.Where(Function(item) item.Type = Design.Items.cIItem.cItemTypeEnum.Quota)
                    If ("" & oItemQuota.QuotaRelativeTrigpoint).ToUpper = OldName Then oItemQuota.QuotaRelativeTrigpoint = NewName
                Next
                '- sketch: no...use station object

                'change origin and geopoint...in future change this property from string to station(trigpoint)
                If oSurvey.Properties.Origin.ToUpper = OldName Then oSurvey.Properties.RenameOrigin(NewName)
                If oSurvey.Properties.GPS.CustomRefPoint = OldName Then oSurvey.Properties.GPS.RenameCustomRefPoint(NewName)
                For Each oCaveBranch As cICaveInfoBranches In oSurvey.Properties.CaveInfos.GetAll
                    'Debug.Print(oCaveBranch.Cave & "|" & oCaveBranch.Path & "->" & oCaveBranch.ExtendStart)
                    If ("" & oCaveBranch.ExtendStart).ToUpper = OldName Then oCaveBranch.ExtendStart = NewName
                Next

                'invalidate data...
                Call oSurvey.Invalidate(Calculate.cCalculate.InvalidateEnum.FullCalculate)
            End If
        End Sub

        Public Function ToList() As List(Of cTrigPoint) Implements cITrigPointCollection.ToList
            Return oTrigPoints.Values.ToList
        End Function

        Public Function ToArray() As cTrigPoint() Implements cITrigPointCollection.ToArray
            Return oTrigPoints.Values.ToArray
        End Function

        Public Function GetOrigin() As cTrigPoint
            If oTrigPoints.ContainsKey(oSurvey.Properties.Origin) Then
                Return oTrigPoints(oSurvey.Properties.Origin)
            Else
                Return Nothing
            End If
        End Function

        Friend Function GetGPSBaseReferencePoint() As cTrigPoint
            If oSurvey.Properties.GPS.RefPointOnOrigin Then
                If oTrigPoints.ContainsKey(oSurvey.Properties.Origin) Then
                    Dim oTrigPoint As cTrigPoint = oTrigPoints(oSurvey.Properties.Origin)
                    If oTrigPoint.Coordinate.IsEmpty Then
                        Return Nothing
                    Else
                        Return oTrigPoint
                    End If
                Else
                    Return Nothing
                End If
            Else
                If oTrigPoints.ContainsKey(oSurvey.Properties.GPS.CustomRefPoint) Then
                    Dim oTrigPoint As cTrigPoint = oTrigPoints(oSurvey.Properties.GPS.CustomRefPoint)
                    If oTrigPoint.Coordinate.IsEmpty Then
                        Return Nothing
                    Else
                        Return oTrigPoint
                    End If
                Else
                    Return Nothing
                End If
            End If
        End Function

        Public Function GetGPSReferencedPoint() As cTrigPointCollection
            Return New cTrigPointCollection(oSurvey, oTrigPoints.Values.Where(Function(TrigPoint) Not TrigPoint.Coordinate.IsEmpty And Not TrigPoint.IsSystem).ToDictionary(Function(trigpoint) trigpoint.Name))
        End Function

        Public Function GetStations(Splay As Boolean) As cTrigPointCollection Implements cITrigPointCollection.getstations
            Return New cTrigPointCollection(oSurvey, oTrigPoints.Values.Where(Function(Trigpoint) Not Trigpoint.Data.IsCalibration AndAlso (Splay OrElse (Not Splay AndAlso Not Trigpoint.Data.IsSplay))).ToDictionary(Function(Trigpoint) Trigpoint.Name))
        End Function

        Public Function GetAllEntrances() As cTrigPointCollection Implements cITrigPointCollection.GetAllEntrances
            Return New cTrigPointCollection(oSurvey, oTrigPoints.Values.Where(Function(TrigPoint) TrigPoint.Entrance > cTrigPoint.EntranceTypeEnum.None And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide).ToDictionary(Function(trigpoint) trigpoint.Name))
        End Function

        Public Function GetEntrances(ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPointCollection Implements cITrigPointCollection.GetEntrances
            Return New cTrigPointCollection(oSurvey, oTrigPoints.Values.Where(Function(TrigPoint) TrigPoint.Entrance >= Entrance And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide).ToDictionary(Function(trigpoint) trigpoint.Name))
        End Function

        Public Function GetFirstEntrance(ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint Implements cITrigPointCollection.GetFirstEntrance
            Return oTrigPoints.Values.FirstOrDefault(Function(TrigPoint) TrigPoint.Entrance >= Entrance And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide)
        End Function

        Public Function GetCaveFirstEntrance(CaveInfo As cCaveInfo, ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint 'Implements cITrigPointCollection.GetCaveFirstEntrance
            Return GetCaveFirstEntrance(CaveInfo.Name, Entrance)
        End Function

        Public Function GetCaveAllEntrances(CaveInfo As cCaveInfo) As cTrigPointCollection 'Implements cITrigPointCollection.GetCaveAllEntrances
            Return GetCaveAllEntrances(CaveInfo.Name)
        End Function

        Public Function GetCaveAllEntrances(Cave As String) As cTrigPointCollection 'Implements cITrigPointCollection.GetCaveAllEntrances
            Return New cTrigPointCollection(oSurvey, oSurvey.Segments.GetCaveSegments(Cave).GetTrigPoints.ToList.Where(Function(TrigPoint) TrigPoint.Entrance > cTrigPoint.EntranceTypeEnum.None And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide).ToDictionary(Function(trigpoint) trigpoint.Name))
        End Function

        Public Function GetCaveFirstEntrance(Cave As String, ByVal Entrance As cTrigPoint.EntranceTypeEnum) As cTrigPoint 'Implements cITrigPointCollection.GetCaveFirstEntrance
            Return oSurvey.Segments.GetCaveSegments(Cave).GetTrigPoints.ToList.FirstOrDefault(Function(TrigPoint) TrigPoint.Entrance >= Entrance And TrigPoint.Entrance < cTrigPoint.EntranceTypeEnum.OutSide)
        End Function

        Public Function GetNames() As List(Of String) Implements cITrigPointCollection.GetNames
            Return New List(Of String)(oTrigPoints.Keys)
        End Function
    End Class
End Namespace

