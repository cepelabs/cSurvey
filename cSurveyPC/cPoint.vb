Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraLayout

Namespace cSurvey.Design
    Public Class cPointsJoins
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oDesign As cDesign
        Private oItems As Dictionary(Of String, cPointsJoin)

        Public Function RemoveJoined(Items As List(Of cItem)) As List(Of cPoint)
            Dim oResult As List(Of cPoint) = New List(Of cPoint)
            For Each oItem As cItem In Items
                Call oResult.AddRange(oItem.Points.ToArray)
            Next
            Return RemoveJoined(oResult)
        End Function

        Public Function ContainsKey(ID As String)
            Return oItems.ContainsKey(ID)
        End Function

        Friend Function Add(ID As String, Point As cPoint) As cPointsJoin
            If oItems.ContainsKey(ID) Then
                Dim oItem As cPointsJoin = oItems(ID)
                oItem.Append(Point)
                Return oItem
            Else
                Dim oItem As cPointsJoin = New cPointsJoin(oSurvey, Point)
                Call oItems.Add(oItem.ID, oItem)
                Return oItem
            End If
        End Function

        Public Function RemoveJoined(Points As List(Of cPoint)) As List(Of cPoint)
            Dim oResult As List(Of cPoint) = New List(Of cPoint)(Points)
            Dim oJoinedPoints As List(Of cPoint) = New List(Of cPoint)
            For Each oPoint As cPoint In Points
                If oPoint.IsJoined Then
                    If Not oJoinedPoints.Contains(oPoint) Then
                        Call oJoinedPoints.AddRange(oPoint.PointsJoin.JoinedTo(oPoint))
                    End If
                End If
            Next
            For Each oJoinedPoint As cPoint In oJoinedPoints
                Call oResult.Remove(oJoinedPoint)
            Next
            Return oResult
        End Function

        Friend Function Add(Point As cPoint) As cPointsJoin
            Dim oItem As cPointsJoin = New cPointsJoin(oSurvey, Point)
            Call oItems.Add(oItem.ID, oItem)
            Return oItem
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Sub Remove(Item As cPointsJoin)
            If oItems.ContainsKey(Item.ID) Then
                Call oItems.Remove(Item.ID)
            End If
        End Sub

        Friend Sub Remove(ID As String)
            If oItems.ContainsKey(ID) Then
                Call oItems.Remove(ID)
            End If
        End Sub

        Default Public ReadOnly Property Item(ID As String) As cPointsJoin
            Get
                If oItems.ContainsKey(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Design As cDesign
            Get
                Return oDesign
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, Design As cDesign, ByVal File As cFile, ByVal PointsJoins As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oItems = New Dictionary(Of String, cPointsJoin)
            For Each oXMLPointsJoin As XmlElement In PointsJoins.ChildNodes
                Dim oItem As cPointsJoin = New cPointsJoin(oSurvey, Design, File, oXMLPointsJoin)
                Call oItems.Add(oItem.ID, oItem)
            Next
        End Sub

        Public Sub New(Survey As cSurvey, Design As cDesign)
            oSurvey = Survey
            oDesign = Design
            oItems = New Dictionary(Of String, cPointsJoin)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("pointsjoins")
            For Each oItem As cPointsJoin In oItems.Values
                'salvo solo le join con 2 punti (in realtà dovrebbero essere tutte con punti>=2 o 0)...
                If oItem.Count > 1 Then
                    Call oItem.SaveTo(File, Document, oXmlItem)
                End If
            Next
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class

    Public Class cPointsJoin
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private sID As String

        Private oItems As List(Of cPoint)

        Friend Function ToArray(SourcePoint As cPoint) As cPoint()
            Dim oArray As List(Of cPoint) = New List(Of cPoint)(oItems)
            Call oArray.Remove(SourcePoint)
            Return oArray.ToArray
        End Function

        Friend Function ToArray() As cPoint()
            Return oItems.ToArray
        End Function

        Public Function IsEmpty() As Boolean
            Return oItems.Count < 2
        End Function

        Public Sub CleanUp()
            'remove not valid elements
            Dim oCleanedItems As List(Of cPoint) = New List(Of cPoint)(oItems)
            oCleanedItems = oCleanedItems.Where(Function(point) Not point Is Nothing).ToList()
            oCleanedItems = oCleanedItems.Where(Function(point) Not point.Item Is Nothing).ToList()
            oCleanedItems = oCleanedItems.Where(Function(point) point.Item.Points.Contains(point)).ToList()
            oItems = oCleanedItems
        End Sub

        Public Function GetPointRef(Point As cPoint) As String
            Dim oItem As cItem = Point.Item
            If oItem Is Nothing Then
                Return ""
            Else
                Dim oLayer As cLayer = oItem.Layer
                Dim iItemIndex As Integer = oLayer.Items.IndexOf(oItem)
                Dim iPointIndex As Integer = oItem.Points.IndexOf(Point)
                If iItemIndex >= 0 And iPointIndex >= 0 Then
                    Return oLayer.Type.ToString("D") & "," & iItemIndex & "," & iPointIndex
                Else
                    Return ""
                End If
            End If
        End Function

        Friend Sub New(Survey As cSurvey, Design As cDesign, ByVal File As cFile, ByVal Join As XmlElement)
            oSurvey = Survey
            sID = Join.GetAttribute("id")
            oItems = New List(Of cPoint)
            Dim sData As String = Join.GetAttribute("data")
            Dim sDataParts() As String = sData.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
            For Each sDataPart As String In sDataParts
                Dim sDataPartParts() As String = sDataPart.Split(",")

                Dim iLayerIndex As cLayers.LayerTypeEnum = sDataPartParts(0)
                Dim iItemIndex As Integer = sDataPartParts(1)
                Dim iPointIndex As Integer = sDataPartParts(2)

                If iItemIndex >= 0 AndAlso iItemIndex < Design.Layers(iLayerIndex).Items.Count Then
                    Dim oItem As cItem = Design.Layers(iLayerIndex).Items(iItemIndex)
                    If iPointIndex >= 0 AndAlso iPointIndex < oItem.Points.Count Then
                        Dim oPoint As cPoint = oItem.Points(iPointIndex)
                        Call oItems.Add(oPoint)
                        Call oPoint.SetJoin(Me)
                    End If
                End If
            Next
        End Sub

        Public Function JoinedTo(Point As cPoint) As List(Of cPoint)
            Dim oResult As List(Of cPoint) = New List(Of cPoint)
            If oItems.Contains(Point) Then
                Call oResult.AddRange(oItems)
                Call oResult.Remove(Point)
            End If
            Return oResult
        End Function

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Call CleanUp()
            Dim oXmlItem As XmlElement = Document.CreateElement("pointsjoin")
            Call oXmlItem.SetAttribute("id", sID)
            Dim sData As String = ""
            For Each oPoint As cPoint In oItems
                sData = sData & GetPointRef(oPoint) & " "
            Next
            Call oXmlItem.SetAttribute("data", sData)
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Friend Sub New(Survey As cSurvey, ID As String, CurrentPoint As cPoint)
            oSurvey = Survey
            sID = ID
            oItems = New List(Of cPoint)
            Call oItems.Add(CurrentPoint)
        End Sub

        Friend Sub New(Survey As cSurvey, CurrentPoint As cPoint)
            Me.New(Survey, Guid.NewGuid.ToString, CurrentPoint)
        End Sub

        Public Function Contains(Point As cPoint) As Boolean
            Return oItems.Contains(Point)
        End Function

        Friend Sub Append(NewPoint As cPoint)
            If Not oItems.Contains(NewPoint) Then
                If NewPoint.PointsJoin Is Nothing Then
                    If Not oItems.Contains(NewPoint) Then
                        Call oItems.Add(NewPoint)
                        Call NewPoint.SetJoin(Me)
                    End If
                Else
                    For Each oPoint As cPoint In NewPoint.PointsJoin
                        Call oItems.Add(oPoint)
                        Call oPoint.SetJoin(Me)
                    Next
                End If
            End If
        End Sub

        Friend Sub Clear()
            For Each oItem As cPoint In oItems
                Call oItem.SetJoin(Nothing)
            Next
            Call oItems.Clear()
        End Sub

        Friend Sub Remove(Point As cPoint)
            If oItems.Contains(Point) Then
                Call oItems.Remove(Point)
                Call Point.SetJoin(Nothing)
                'se la collection resta con un solo punto elimino anche quello...
                If oItems.Count = 1 Then
                    Dim oPoint As cPoint = oItems.First
                    Call oItems.Remove(oPoint)
                    Call oPoint.SetJoin(Nothing)
                End If
            End If
        End Sub

        Default Public ReadOnly Property Item(Index As Integer) As cPoint
            Get
                Return oItems(Index)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Sub CommitChange(Source As cPoint)
            For Each oPoint As cPoint In oItems
                If Not oPoint Is Source Then
                    Call oPoint.MoveToFromJoin(Source.Point)
                End If
            Next
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property
    End Class

    Public Class cPoint
        Private oSurvey As cSurvey

        Private oPoint As PointF
        Private WithEvents oPen As cPen
        Private iLineType As Items.cIItemLine.LineTypeEnum
        Private bBeginSequence As Boolean

        Private bSegmentLocked As Boolean
        Private sBindedSegment As String
        Private oBindedSegment As cISegment

        Private oItem As cItem
        Private oPointsJoin As cPointsJoin

        <Flags> Public Enum PointTypeEnum
            NoneOrError = &H0
            MainPoint = &H1
            ControlPoint = &H2
            BaseMask = &HF
            First = &H10
            Last = &H20
            FirstLastMask = &HF0
            FirstOfAll = &H100
            LastOfAll = &H200
            FirstLastOfAllMask = &HF00
        End Enum

        Friend Event OnGetNext(ByVal Sender As cPoint, ByRef Point As cPoint)
        Friend Event OnGetPrevious(ByVal Sender As cPoint, ByRef Point As cPoint)

        Friend Event OnChanged(ByVal Sender As cPoint)
        Friend Event OnGetType(ByVal Sender As cPoint, ByRef Type As PointTypeEnum)
        Friend Event OnGetItem(ByVal Sender As cPoint, ByRef Item As cItem)

        Friend Sub SetJoin(Join As cPointsJoin)
            oPointsJoin = Join
        End Sub

        Public Sub Unjoin(Optional All As Boolean = False)
            If All Then
                'scollega tutti i punti a cui questo è collegato...
                If Not oPointsJoin Is Nothing Then
                    Call oPointsJoin.Clear()
                End If
            Else
                'scollega questo punto dagli altri
                If Not oPointsJoin Is Nothing Then
                    Call oPointsJoin.Remove(Me)
                End If
            End If
        End Sub

        Public Sub Join(Point As cPoint)
            If Not IsNothing(Point) Then
                If IsNothing(oPointsJoin) Then
                    oPointsJoin = Item.Design.PointsJoins.Add(Me)
                End If
                Call oPointsJoin.Append(Point)
                Call oPointsJoin.CommitChange(Me)
            End If
        End Sub

        Public Function IsJoined() As Boolean
            Return Not (oPointsJoin Is Nothing) AndAlso oPointsJoin.Count > 1
        End Function

        Public ReadOnly Property PointsJoin As cPointsJoin
            Get
                Return oPointsJoin
            End Get
        End Property

        Public Function GetSequence() As cSequence
            If IsNothing(Item) Then
                Return Nothing
            Else
                Return Item.Points.GetSequence(Me)
            End If
        End Function

        Public Function GetIndex() As Integer
            If IsNothing(Item) Then
                Return -1
            Else
                Return Item.Points.IndexOf(Me)
            End If
        End Function

        Public ReadOnly Property Type() As PointTypeEnum
            Get
                Dim iType As PointTypeEnum
                RaiseEvent OnGetType(Me, iType)
                Return iType
            End Get
        End Property

        Public ReadOnly Property Item As cItem
            Get
                If oItem Is Nothing Then
                    RaiseEvent OnGetItem(Me, oItem)
                End If
                Return oItem
            End Get
        End Property

        Public ReadOnly Property X() As Single
            Get
                Return oPoint.X
            End Get
        End Property

        Public ReadOnly Property Y() As Single
            Get
                Return oPoint.Y
            End Get
        End Property

        Public Sub MoveBy(ByVal Size As SizeF)
            If Not Size.IsEmpty Then
                oPoint = PointF.Add(oPoint, Size)
                If Not oPointsJoin Is Nothing Then oPointsJoin.CommitChange(Me)
                RaiseEvent OnChanged(Me)
            End If
        End Sub

        Public Sub MoveBy(ByVal Point As PointF)
            Call MoveBy(New SizeF(Point.X, Point.Y))
        End Sub

        Public Sub MoveBy(ByVal OffsetX As Single, ByVal OffsetY As Single)
            Call MoveBy(New SizeF(OffsetX, OffsetY))
        End Sub

        Public Sub MoveTo(ByVal Point As PointF)
            If Point.X <> oPoint.X OrElse Point.Y <> oPoint.Y Then
                oPoint = New PointF(Point.X, Point.Y)
                If Not oPointsJoin Is Nothing Then oPointsJoin.CommitChange(Me)
                RaiseEvent OnChanged(Me)
            End If
        End Sub

        Friend Sub MoveToFromJoin(ByVal Point As PointF)
            If Point.X <> oPoint.X OrElse Point.Y <> oPoint.Y Then
                oPoint = New PointF(Point.X, Point.Y)
                RaiseEvent OnChanged(Me)
            End If
        End Sub

        Public Sub MoveTo(ByVal X As Single, ByVal Y As Single)
            Call MoveTo(New PointF(X, Y))
        End Sub

        Public Property Pen() As cPen
            Get
                Return oPen
            End Get
            Set(ByVal value As cPen)
                oPen = value
                RaiseEvent OnChanged(Me)
            End Set
        End Property

        Public Function GetNext() As cPoint
            Dim oPoint As cPoint
            RaiseEvent OnGetNext(Me, oPoint)
            Return oPoint
        End Function

        Public Function GetPrevious() As cPoint
            Dim oPoint As cPoint
            RaiseEvent OnGetPrevious(Me, oPoint)
            Return oPoint
        End Function

        Public Property BeginSequence() As Boolean
            Get
                Return bBeginSequence
            End Get
            Set(ByVal value As Boolean)
                If bBeginSequence <> value Then
                    bBeginSequence = value
                    RaiseEvent OnChanged(Me)
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return "{X=" & oPoint.X & ",Y=" & oPoint.Y & ",BeginSequence=" & bBeginSequence & ",BindendSegment=" & IIf(oBindedSegment Is Nothing, "", oBindedSegment.ToString) & ",SegmentLocked=" & bSegmentLocked & "}"
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal X As Single, ByVal Y As Single)
            oSurvey = Survey
            oPoint = New PointF(X, Y)
            iLineType = Items.cIItemLine.LineTypeEnum.Undefined
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As PointF)
            oSurvey = Survey
            oPoint = New PointF(Point.X, Point.Y)
            iLineType = Items.cIItemLine.LineTypeEnum.Undefined
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As cPoint)
            oSurvey = Survey
            oPoint = New PointF(Point.oPoint.X, Point.oPoint.Y)
            bBeginSequence = Point.bBeginSequence
            iLineType = Point.iLineType
            sBindedSegment = ""
            oBindedSegment = Point.oBindedSegment
            bSegmentLocked = Point.bSegmentLocked
            If Not Point.oPen Is Nothing Then
                oPen = New cPen(oSurvey, Point.oPen)
            End If
            If Not Point.oPointsJoin Is Nothing Then
                Call Point.oPointsJoin.Append(Me)
            End If
            'oItem = Point.Item
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As cPoint, ByVal BeginSequence As Boolean, ByVal Pen As cPen, LineType As Items.cIItemLine.LineTypeEnum, ByVal SegmentLocked As Boolean, ByVal BindedSegment As String)
            oSurvey = Survey
            oPoint = New PointF(Point.X, Point.Y)
            bBeginSequence = BeginSequence
            If bBeginSequence Then
                oPen = Pen
                iLineType = LineType
            Else
                iLineType = Items.cIItemLine.LineTypeEnum.Undefined
            End If
            bSegmentLocked = SegmentLocked
            sBindedSegment = BindedSegment
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Point As PointF, ByVal BeginSequence As Boolean, ByVal Pen As cPen, LineType As Items.cIItemLine.LineTypeEnum, ByVal SegmentLocked As Boolean, ByVal BindedSegment As String)
            oSurvey = Survey
            oPoint = Point
            bBeginSequence = BeginSequence
            If bBeginSequence Then
                oPen = Pen
                iLineType = LineType
            Else
                iLineType = Items.cIItemLine.LineTypeEnum.Undefined
            End If
            bSegmentLocked = SegmentLocked
            sBindedSegment = BindedSegment
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As XmlElement)
            oSurvey = Survey
            oPoint = New PointF(Point.GetAttribute("x"), Point.GetAttribute("y"))
            bBeginSequence = modXML.GetAttributeValue(Point, "beginsequence", False)
            If bBeginSequence Then
                Dim oXMLPen As XmlElement = Point.Item("pen")
                If Not oXMLPen Is Nothing Then
                    oPen = New cPen(oSurvey, oXMLPen)
                End If
                iLineType = modXML.GetAttributeValue(Point, "linetype", Items.cIItemLine.LineTypeEnum.Undefined)
            Else
                iLineType = Items.cIItemLine.LineTypeEnum.Undefined
            End If
            bSegmentLocked = modXML.GetAttributeValue(Point, "segmentlocked", False)
            Dim sBindedSegment As String = ""
            sBindedSegment = modXML.GetAttributeValue(Point, "bindedsegment", "")
            If IsNumeric(sBindedSegment) Then
                oBindedSegment = oSurvey.Segments(CType(sBindedSegment, Integer))
            Else
                oBindedSegment = oSurvey.GetSegment(sBindedSegment)
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPoint As XmlElement = Document.CreateElement("point")
            Call oXmlPoint.SetAttribute("x", Point.X)
            Call oXmlPoint.SetAttribute("y", Point.Y)
            If BeginSequence Then
                Call oXmlPoint.SetAttribute("beginsequence", IIf(bBeginSequence, 1, 0))
                If Not oPen Is Nothing Then
                    Call oPen.SaveTo(File, Document, oXmlPoint)
                End If
                If iLineType <> Items.cIItemLine.LineTypeEnum.Undefined Then
                    Call oXmlPoint.SetAttribute("linetype", iLineType.ToString("D"))
                End If
            End If
            If SegmentLocked Then
                Call oXmlPoint.SetAttribute("segmentlocked", IIf(bSegmentLocked, 1, 0))
            End If
            If Not oBindedSegment Is Nothing Then
                Call oXmlPoint.SetAttribute("bindedsegment", oBindedSegment.ID)
            End If
            Call Parent.AppendChild(oXmlPoint)
            Return oXmlPoint
        End Function

        Public Shared ReadOnly Property IsFirst(Type As PointTypeEnum) As Boolean
            Get
                Return (Type And PointTypeEnum.First) = PointTypeEnum.First
            End Get
        End Property

        Public Shared ReadOnly Property IsLast(Type As PointTypeEnum) As Boolean
            Get
                Return (Type And PointTypeEnum.Last) = PointTypeEnum.Last
            End Get
        End Property

        Public Shared ReadOnly Property IsFirstOfAll(Type As PointTypeEnum) As Boolean
            Get
                Return (Type And PointTypeEnum.FirstOfAll) = PointTypeEnum.FirstOfAll
            End Get
        End Property

        Public Shared ReadOnly Property IsLastOfAll(Type As PointTypeEnum) As Boolean
            Get
                Return (Type And PointTypeEnum.LastOfAll) = PointTypeEnum.LastOfAll
            End Get
        End Property

        Public Shared ReadOnly Property IsControlPoint(Type As PointTypeEnum) As Boolean
            Get
                Return (Type And PointTypeEnum.ControlPoint) = PointTypeEnum.ControlPoint
            End Get
        End Property

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Point() As PointF
            Get
                Return oPoint
            End Get
        End Property

        Friend Sub BindSegment(ByVal Segment As cISegment)
            If Not bSegmentLocked Then
                oBindedSegment = Segment
                sBindedSegment = ""
            End If
        End Sub

        Public Property SegmentLocked() As Boolean
            Get
                Return bSegmentLocked
            End Get
            Set(ByVal value As Boolean)
                bSegmentLocked = value
            End Set
        End Property

        Public Property LineType() As Items.cIItemLine.LineTypeEnum
            Get
                Return iLineType
            End Get
            Set(ByVal value As Items.cIItemLine.LineTypeEnum)
                If iLineType <> value Then
                    iLineType = value
                    RaiseEvent OnChanged(Me)
                End If
            End Set
        End Property

        Public ReadOnly Property BindedSegment() As cISegment
            Get
                If sBindedSegment <> "" Then
                    oBindedSegment = oSurvey.GetSegment(sBindedSegment)
                    sBindedSegment = ""
                End If
                Return oBindedSegment
            End Get
        End Property

        Public Function Clone() As cPoint
            Return New cPoint(oSurvey, Me)
        End Function

        Private Sub oPen_OnChanged(ByVal Sender As Object, e As EventArgs) Handles oPen.OnChanged
            RaiseEvent OnChanged(Me)
        End Sub
    End Class

    Public Class cFirstPoint
        Inherits cPoint

        Private oSurvey As cSurvey

        Private WithEvents oPen As cPen
        Private WithEvents oBrush As cBrush
        Private iLineType As Items.cIItemLine.LineTypeEnum

        Friend Shadows Event OnChanged(ByVal Sender As cPoint)

        Public Property Brush() As cBrush
            Get
                Return oBrush
            End Get
            Set(ByVal value As cBrush)
                oBrush = value
                RaiseEvent OnChanged(Me)
            End Set
        End Property

        Public Property Pen() As cPen
            Get
                Return oPen
            End Get
            Set(ByVal value As cPen)
                oPen = value
                RaiseEvent OnChanged(Me)
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal X As Single, ByVal Y As Single, ByVal Pen As cPen, Brush As cBrush, LineType As Items.cIItemLine.LineTypeEnum)
            MyBase.New(Survey, X, Y)
            If Not Pen Is Nothing Then
                oPen = New cPen(oSurvey, Pen)
            End If
            If Not Brush Is Nothing Then
                oBrush = New cBrush(oSurvey, Brush)
            End If
            iLineType = LineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As PointF, ByVal Pen As cPen, Brush As cBrush, LineType As Items.cIItemLine.LineTypeEnum)
            MyBase.New(Survey, Point)
            If Not Pen Is Nothing Then
                oPen = New cPen(oSurvey, Pen)
            End If
            If Not Brush Is Nothing Then
                oBrush = New cBrush(oSurvey, Brush)
            End If
            iLineType = LineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As cPoint, ByVal Pen As cPen, Brush As cBrush, LineType As Items.cIItemLine.LineTypeEnum)
            MyBase.New(Survey, Point)
            If Not Pen Is Nothing Then
                oPen = New cPen(oSurvey, Pen)
            End If
            If Not Brush Is Nothing Then
                oBrush = New cBrush(oSurvey, Brush)
            End If
            iLineType = LineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As cPoint, ByVal BeginSequence As Boolean, ByVal Pen As cPen, Brush As cBrush, LineType As Items.cIItemLine.LineTypeEnum, ByVal SegmentLocked As Boolean, ByVal BindedSegment As String)
            MyBase.New(Survey, Point)

            oPen = Pen
            oBrush = Brush
            iLineType = LineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Point As PointF, ByVal Pen As cPen, Brush As cBrush, LineType As Items.cIItemLine.LineTypeEnum, ByVal SegmentLocked As Boolean, ByVal BindedSegment As String)
            MyBase.New(Survey, Point)

            If Not Pen Is Nothing Then
                oPen = New cPen(oSurvey, Pen)
            End If
            If Not Brush Is Nothing Then
                oBrush = New cBrush(oSurvey, Brush)
            End If
            iLineType = LineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Point As XmlElement)
            MyBase.New(Survey, Point)

            Dim oXMLPen As XmlElement = Point.Item("pen")
            If Not oXMLPen Is Nothing Then
                oPen = New cPen(oSurvey, oXMLPen)
            End If
            Dim oXMLBrush As XmlElement = Point.Item("brush")
            If Not oXMLBrush Is Nothing Then
                oBrush = New cBrush(oSurvey, File, oXMLBrush)
            End If
            iLineType = modXML.GetAttributeValue(Point, "linetype", Items.cIItemLine.LineTypeEnum.Undefined)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Return MyBase.SaveTo(File, Document, Parent)
        End Function

        Private Sub oPen_OnChanged(ByVal Sender As Object, e As EventArgs) Handles oPen.OnChanged
            RaiseEvent OnChanged(Me)
        End Sub

        Private Sub oBrush_OnChanged(ByVal Sender As Object, e As EventArgs) Handles oBrush.OnChanged
            RaiseEvent OnChanged(Me)
        End Sub
    End Class
End Namespace