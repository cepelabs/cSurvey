Imports System.Xml

Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cPoints
        Implements IEnumerable
        Implements IEnumerable(Of cPoint)

        Private oSurvey As cSurvey
        Private oItem As cItem

        Private oPoints As List(Of cPoint)

        Private bChanged As Boolean

        Private bStartSequence As Boolean
        Private oSequences As List(Of cSequence) ' cSequence

        Friend Event OnChanged(ByVal Sender As cPoints)
        Friend Event OnGetLineType(Sender As cPoints, ByRef LineType As Items.cIItemLine.LineTypeEnum)

        Public Function GetNearestPoint(PaintPoint As PointF) As cPoint
            Return oPoints.OrderBy(Function(oPoint) modPaint.DistancePointToPoint(oPoint.Point, PaintPoint)).FirstOrDefault()
        End Function

        Public Function GetUnjoined() As List(Of cPoint)
            Return oItem.Design.PointsJoins.RemoveJoined(oPoints)
        End Function

        Public Function Contains(Point As cPoint) As Boolean
            Return oPoints.Contains(Point)
        End Function

        Public ReadOnly Property First() As cPoint
            Get
                If oPoints.Count > 0 Then
                    Return oPoints(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Last() As cPoint
            Get
                If oPoints.Count > 0 Then
                    Return oPoints(oPoints.Count - 1)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function [Next](Point As cPoint) As cPoint
            If Point Is oPoints.Last Then
                Return Nothing
            Else
                Return oPoints(oPoints.IndexOf(Point) + 1)
            End If
        End Function

        Public Function [Previous](Point As cPoint) As cPoint
            If Point Is oPoints.First Then
                Return Nothing
            Else
                Return oPoints(oPoints.IndexOf(Point) - 1)
            End If
        End Function

        Public Sub StartSequence()
            bStartSequence = True
        End Sub

#Region "Add e Insert pubbliche"

        Public Function AddFromPaintPoint(ByVal PaintPoint As PointF) As cPoint
            Dim oPoint As cPoint = New cPoint(oSurvey, PaintPoint)
            Dim oNewPoint As cPoint = Add(New cPoint(oSurvey, oPoint))

            Dim oSequence As cSequence = GetSequence(oPoint)
            If Not oSequence Is Nothing Then
                Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(pGetOwnerLineType)
                If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                    oNewPoint = Add(New cPoint(oSurvey, New cPoint(oSurvey, New PointF(PaintPoint.X - 0.1, PaintPoint.Y))))
                    oNewPoint = Add(New cPoint(oSurvey, New cPoint(oSurvey, New PointF(PaintPoint.X + 0.1, PaintPoint.Y))))
                End If
            End If
            Return oNewPoint
        End Function

        Public Function AddFromPaintPoint(ByVal X As Single, ByVal Y As Single) As cPoint
            Dim oPoint As cPoint = New cPoint(oSurvey, New PointF(X, Y))
            Dim oNewPoint As cPoint = Add(New cPoint(oSurvey, oPoint))

            Dim oSequence As cSequence = GetSequence(oPoint)
            If Not oSequence Is Nothing Then
                Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(pGetOwnerLineType)
                If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                    oNewPoint = Add(New cPoint(oSurvey, New cPoint(oSurvey, New PointF(X - 0.1, Y))))
                    oNewPoint = Add(New cPoint(oSurvey, New cPoint(oSurvey, New PointF(X + 0.1, Y))))
                End If
            End If
            Return oNewPoint
        End Function

        Public Function InsertFromPaintPoint(ByVal Index As Integer, ByVal PaintPoint As PointF) As cPoint
            Dim oPoint As cPoint = New cPoint(oSurvey, PaintPoint)
            Dim oNewPoint As cPoint = Insert(Index, oPoint)

            Dim oSequence As cSequence = GetSequence(oPoint)
            If Not oSequence Is Nothing Then
                Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(pGetOwnerLineType)
                If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                    oNewPoint = Insert(Index + 1, New cPoint(oSurvey, New cPoint(oSurvey, New PointF(PaintPoint.X - 0.1, PaintPoint.Y))))
                    oNewPoint = Insert(Index + 1, New cPoint(oSurvey, New cPoint(oSurvey, New PointF(PaintPoint.X + 0.1, PaintPoint.Y))))
                End If
            End If
            Return oNewPoint
        End Function

        Public Function InsertFromPaintPoint(ByVal Index As Integer, ByVal X As Single, ByVal Y As Single) As cPoint
            Dim oPoint As cPoint = New cPoint(oSurvey, New PointF(X, Y))
            Dim oNewPoint As cPoint = Insert(Index, oPoint)

            Dim oSequence As cSequence = GetSequence(oPoint)
            If Not oSequence Is Nothing Then
                Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(pGetOwnerLineType)
                If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                    oNewPoint = Insert(Index + 1, New cPoint(oSurvey, New cPoint(oSurvey, New PointF(X - 0.1, Y))))
                    oNewPoint = Insert(Index + 1, New cPoint(oSurvey, New cPoint(oSurvey, New PointF(X + 0.1, Y))))
                End If
            End If
            Return oNewPoint
        End Function

#End Region

#Region "Add e Insert private"

        Friend Function Insert(ByVal Index As Integer, ByVal Point As cPoint) As cPoint
            If Index >= oPoints.Count Then
                Call pAdd(Point)
            Else
                Call pInsert(Index, Point)
            End If
            If bStartSequence Then
                Point.BeginSequence = True
                bStartSequence = False
            End If
            Call pBindPoints()
            Return Point
        End Function

        Friend Sub InsertRange(ByVal Index As Integer, ByVal Sequence As cSequence)
            If Index >= oPoints.Count AndAlso Index < 0 Then
                Call AddRange(Sequence)
            Else
                For Each oPoint As cPoint In Sequence
                    Call pInsert(Index, oPoint)
                    Index += 1
                Next
                Call pBindPoints()
            End If
        End Sub

        Friend Sub AddRange(ByVal Sequence As cSequence)
            For Each oPoint As cPoint In Sequence
                Call pAdd(oPoint)
            Next
            Call pBindPoints()
        End Sub

        Friend Sub AddRange(ByVal Points As List(Of cPoint))
            For Each oPoint As cPoint In Points
                Call pAdd(oPoint)
            Next
            Call pBindPoints()
        End Sub

        Friend Sub AddRange(ByVal Points As cPoints)
            For Each oPoint As cPoint In Points
                Call pAdd(oPoint)
            Next
            Call pBindPoints()
        End Sub

        Private Sub pInsert(Index As Integer, Point As cPoint)
            AddHandler Point.OnChanged, AddressOf oPoint_OnChanged
            AddHandler Point.OnGetType, AddressOf oPoint_OnGetType
            AddHandler Point.OnGetItem, AddressOf oPoint_OnGetItem
            AddHandler Point.OnGetNext, AddressOf oPoint_OnGetNext
            AddHandler Point.OnGetPrevious, AddressOf oPoint_OnGetPrevious
            Call oPoints.Insert(Index, Point)
        End Sub

        Private Sub pAdd(Point As cPoint)
            AddHandler Point.OnChanged, AddressOf oPoint_OnChanged
            AddHandler Point.OnGetType, AddressOf oPoint_OnGetType
            AddHandler Point.OnGetItem, AddressOf oPoint_OnGetItem
            AddHandler Point.OnGetNext, AddressOf oPoint_OnGetNext
            AddHandler Point.OnGetPrevious, AddressOf oPoint_OnGetPrevious
            Call oPoints.Add(Point)
        End Sub

        Friend Function Add(ByVal Point As cPoint) As cPoint
            Call pAdd(Point)
            If bStartSequence Then
                Point.BeginSequence = True
                bStartSequence = False
            End If
            Call pBindPoints()
            Return Point
        End Function
#End Region

        Private Function pGetOwnerLineType() As Items.cIItemLine.LineTypeEnum
            Dim iLineType As Items.cIItemLine.LineTypeEnum = Items.cIItemLine.LineTypeEnum.Undefined
            RaiseEvent OnGetLineType(Me, iLineType)
            Return iLineType
        End Function

        Public Function Remove(ByVal Point As cPoint) As Boolean
            Dim oSequence As cSequence = GetSequence(Point)
            If Not IsNothing(oSequence) Then
                Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(pGetOwnerLineType)
                If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                    'BEZIER
                    Dim iPointType As cPoint.PointTypeEnum = Point.Type
                    If (iPointType And cPoint.PointTypeEnum.ControlPoint) = cPoint.PointTypeEnum.ControlPoint Then
                        'è un controlpoint...non posso cancellarlo
                        Return False
                    Else
                        If oSequence.Count < 5 Then
                            Call DeleteSequence(oSequence)
                        Else
                            Dim iPointIndex As Integer = oPoints.IndexOf(Point)
                            If (iPointType And cPoint.PointTypeEnum.Last) = cPoint.PointTypeEnum.Last Then
                                'se il punto è l'ultmo di una sequenza cancello il punto e i due precedenti
                                Call oPoints.RemoveAt(iPointIndex)
                                Call oPoints.RemoveAt(iPointIndex - 1)
                                Call oPoints.RemoveAt(iPointIndex - 2)
                            ElseIf (iPointType And cPoint.PointTypeEnum.First) = cPoint.PointTypeEnum.First Then
                                'se il punto è il primo di una sequenza cancello il punto e 2 controlpoint successivi
                                Call oPoints.RemoveAt(iPointIndex)
                                Call oPoints.RemoveAt(iPointIndex)
                                Call oPoints.RemoveAt(iPointIndex)
                                'e riporto le proprietà del punto al primo successivo...
                                With oPoints(iPointIndex)
                                    .LineType = Point.LineType
                                    .Pen = Point.Pen
                                    .BeginSequence = True
                                End With
                            Else
                                'se il punto è al centro di una sequenza cancello il punto e i due controlpoint che fanno riferimento ad esso
                                Call oPoints.RemoveAt(iPointIndex + 1)
                                Call oPoints.RemoveAt(iPointIndex)
                                Call oPoints.RemoveAt(iPointIndex - 1)
                            End If
                        End If
                        Call pBindPoints()
                        Return True
                    End If
                Else
                    'RETTA O SPLINE 
                    If oPoints.Count < 3 Then
                        'se ho meno di 3 punti...cancello tutto.
                        'negli oggetti dove points non rappresenta un path non dovrei mai passare dalla remove...
                        Call oPoints.Clear()
                        Call pBindPoints()
                        Return True
                    Else
                        If oSequence.Count < 3 Then
                            Call DeleteSequence(oSequence)
                        Else
                            Dim iPointType As cPoint.PointTypeEnum = Point.Type
                            Dim iPointIndex As Integer = oPoints.IndexOf(Point)
                            Call oPoints.RemoveAt(iPointIndex)
                            If (iPointType And cPoint.PointTypeEnum.First) = cPoint.PointTypeEnum.First Then
                                'se il punto è il primo di una sequenza
                                'e riporto le proprietà del punto al primo successivo...
                                With oPoints(iPointIndex)
                                    .LineType = Point.LineType
                                    .Pen = Point.Pen
                                    .BeginSequence = True
                                End With
                            End If
                        End If
                        Call pBindPoints()
                        Return True
                    End If
                End If
            End If
        End Function

        Public Function RemoveAt(ByVal Index As Integer) As Boolean
            If Index >= 0 And Index < oPoints.Count Then
                Return Remove(oPoints(Index))
            End If
        End Function

        'Public Function RemoveAt(ByVal Index As Integer) As Boolean
        '    'If Index >= 0 And Index < oPoints.Count Then
        '    '    If oPoints(Index).Type <> cPoint.PointTypeEnum.ControlPoint Then
        '    '        Call oPoints.RemoveAt(Index)
        '    '        Call pBindPoints()
        '    '        Return True
        '    '    Else
        '    '        Return False
        '    '    End If
        '    'Else
        '    '    Return False
        '    'End If
        'End Function

        Public Function HitTest(ByVal Point As PointF, Optional ByVal Wide As Single = 2) As cPoint
            Return HitTest(Point.X, Point.Y, Wide)
        End Function

        Public Function HitTest(ByVal X As Single, ByVal Y As Single, Optional ByVal Wide As Single = 2) As cPoint
            Dim sHalfWide As Single = Wide / 2
            For Each oPoint As cPoint In oPoints
                If X >= oPoint.X - sHalfWide And X < oPoint.X + sHalfWide And Y > oPoint.Y - sHalfWide And Y < oPoint.Y + sHalfWide Then
                    Return oPoint
                End If
                'Dim oRect As RectangleF = New RectangleF(oPoint.X - sHalfWide, oPoint.Y - sHalfWide, Wide, Wide)
                'If oRect.Contains(X, Y) Then
                '    Return oPoint
                'End If
            Next
            Return Nothing
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cPoint
            Get
                Return oPoints(Index)
            End Get
        End Property

        Private Sub pCleanUpDuplicates()
            Dim oPointsToDelete As List(Of cPoint) = New List(Of cPoint)
            Dim oLastPoint As cPoint = Nothing
            Dim iDefaultLineType As Items.cIItemLine.LineTypeEnum = pGetOwnerLineType()
            Dim iLastLineType As Items.cIItemLine.LineTypeEnum = iDefaultLineType
            For Each oPoint As cPoint In oPoints
                If oPoint.BeginSequence Then
                    If oPoint.LineType = Items.cIItemLine.LineTypeEnum.Undefined Then
                        iLastLineType = iDefaultLineType
                    Else
                        iLastLineType = oPoint.LineType
                    End If
                End If
                If Not oLastPoint Is Nothing And iLastLineType <> Items.cIItemLine.LineTypeEnum.Beziers Then
                    If oPoint.X = oLastPoint.X And oPoint.Y = oLastPoint.Y And oPoint.BeginSequence = False Then
                        If Not oPointsToDelete.Contains(oPoint) Then
                            Call oPointsToDelete.Add(oPoint)
                        End If
                    End If
                End If
                oLastPoint = oPoint
            Next
            If oPointsToDelete.Count > 0 Then
                For Each oPoint As cPoint In oPointsToDelete
                    Call oPoints.Remove(oPoint)
                Next
                Call pBindPoints()
            End If
        End Sub

        Public Sub CleanUpEmptySequences()
            Dim iDefaultLineType As Items.cIItemLine.LineTypeEnum = pGetOwnerLineType()
            If iDefaultLineType <> Items.cIItemLine.LineTypeEnum.Undefined Then
                Dim oSequences As List(Of cSequence) = GetSequences()
                For Each oSequence As cSequence In oSequences
                    Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(iDefaultLineType)
                    If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                        If oSequence.Count < 4 Then
                            Call DeleteSequence(oSequence)
                        End If
                    ElseIf iLineType = Items.cIItemLine.LineTypeEnum.Splines Or iLineType = Items.cIItemLine.LineTypeEnum.Lines Then
                        If oSequence.Count < 2 Then
                            Call DeleteSequence(oSequence)
                        End If
                    End If
                Next
            End If
            'Dim oPointsToDelete As List(Of cPoint) = New List(Of cPoint)
            'Dim oLastPoint As cPoint = Nothing
            'For Each oPoint As cPoint In oPoints
            '    If Not oLastPoint Is Nothing Then
            '        If oLastPoint.BeginSequence And oPoint.BeginSequence Then
            '            If Not oPointsToDelete.Contains(oLastPoint) Then
            '                Call oPointsToDelete.Add(oLastPoint)
            '            End If
            '        End If
            '    End If
            '    oLastPoint = oPoint
            'Next
            'If oLastPoint.BeginSequence Then
            '    If Not oPointsToDelete.Contains(oLastPoint) Then
            '        Call oPointsToDelete.Add(oLastPoint)
            '    End If
            'End If
            'For Each oPoint As cPoint In oPointsToDelete
            '    Call oPoints.Remove(oPoint)
            'Next
        End Sub

        Public Sub CleanUp()
            If oPoints.Count > 0 Then
                Call pCleanUpDuplicates()
                Call CleanUpEmptySequences()
                Call pBindPoints()
            End If
        End Sub

        Private bInUpdate As Boolean

        Public Sub EndUpdate()
            If bInUpdate Then
                bInUpdate = False
                If bChanged Then RaiseEvent OnChanged(Me)
            End If
        End Sub

        Public Sub BeginUpdate()
            bInUpdate = True
        End Sub

        Public Sub Clear()
            Call oPoints.Clear()
            Call pBindPoints()
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return oPoints.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oPoints.GetEnumerator
        End Function

        Public Function IndexOf(ByVal Point As cPoint) As Integer
            Return oPoints.IndexOf(Point)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Item As cItem)
            oSurvey = Survey
            oItem = Item
            oPoints = New List(Of cPoint)
            pBindPoints()
        End Sub

        Friend Class cMeta
            Private sText As String
            Private iPointIndex As Integer?

            Public ReadOnly Property PointIndex As Integer?
                Get
                    Return iPointIndex
                End Get
            End Property

            Public ReadOnly Property Text As String
                Get
                    Return sText
                End Get
            End Property

            Public Sub New(Text As String, Optional PointIndex As Integer? = Nothing)
                stext = Text
                iPointIndex = PointIndex
            End Sub
        End Class

        Private oMetas As List(Of cMeta)

        Private Function pGetMetas() As List(Of cMeta)
            If IsNothing(oMetas) Then
                oMetas = New List(Of cMeta)
            End If
            Return oMetas
        End Function

        Friend Function Metas() As List(Of cMeta)
            Return oMetas
        End Function

        Public Sub Parse(Points As XmlElement)
            oPoints = New List(Of cPoint)
            If Points.HasAttribute("data") Then
                'data attribute is for 'new' survey...
                Dim sData As String = Points.GetAttribute("data")
                If sData.Length > 0 Then
                    Dim sChar As Char
                    Dim iChar As Integer = 0
                    Dim sValue As String = ""

                    If sData.StartsWith("#") Then
                        Do
                            sChar = sData(iChar)
                            If sChar <> "#" Then
                                sValue = sValue & sChar
                            End If
                            iChar += 1
                        Loop Until sChar = " "
                        Call pGetMetas.Add(New cMeta(sValue.Trim))
                    End If

                    sData = sData.Replace("NaN", "0")

                    Dim iPenChildNodeIndex As Integer = 0
                    Dim oPen As cPen = Nothing
                    Dim iLineType As Items.cIItemLine.LineTypeEnum

                    Dim sX As Single
                    Dim sY As Single
                    Dim bBeginSequence As Boolean = False
                    Dim bSegmentLocked As Boolean = False
                    Dim sBindedSegment As String = ""

                    Do
                        bBeginSequence = False
                        bSegmentLocked = False
                        sValue = ""
                        Do
                            sChar = sData(iChar)
                            If sChar <> " " Then
                                sValue = sValue & sChar
                            End If
                            iChar += 1
                        Loop Until sChar = " "
                        sX = modNumbers.StringToDecimal(sValue)

                        sValue = ""
                        Do
                            sChar = sData(iChar)
                            If sChar <> " " Then
                                sValue = sValue & sChar
                            End If
                            iChar += 1
                        Loop Until sChar = " "
                        sY = modNumbers.StringToDecimal(sValue)

                        If iChar < sData.Length Then
                            sChar = sData(iChar)
                            If Not Char.IsDigit(sChar) And sChar <> "-" Then
                                sValue = sChar
                                iChar += 1
                                Do
                                    sChar = sData(iChar)
                                    If sChar <> " " Then
                                        sValue = sValue & sChar
                                    End If
                                    iChar += 1
                                Loop Until sChar = " "
                                If sValue.StartsWith("B") Then
                                    bBeginSequence = True
                                    sValue = sValue.Remove(0, 1)
                                Else
                                    bBeginSequence = False
                                End If
                                If bBeginSequence Then
                                    If sValue.StartsWith("P") Then
                                        oPen = New cPen(oSurvey, Points.ChildNodes(iPenChildNodeIndex))
                                        sValue = sValue.Remove(0, 1)
                                        iPenChildNodeIndex += 1
                                    Else
                                        oPen = Nothing
                                    End If
                                End If
                                If bBeginSequence Then
                                    If sValue.StartsWith("T") Then
                                        sValue = sValue.Remove(0, 1)
                                        iLineType = Integer.Parse(sValue.First)
                                        sValue = sValue.Remove(0, 1)
                                    Else
                                        iLineType = Items.cIItemLine.LineTypeEnum.Undefined
                                    End If
                                End If
                                If sValue.StartsWith("L") Then
                                    bSegmentLocked = True
                                    sValue = sValue.Remove(0, 1)
                                Else
                                    bSegmentLocked = False
                                End If
                                If sValue.StartsWith("S") Then
                                    sValue = sValue.Remove(0, 1)
                                    If sValue <> "" Then
                                        sBindedSegment = sValue
                                    End If
                                Else
                                    sBindedSegment = ""
                                End If
                            End If
                        End If

                        Dim oPoint As cPoint = New cPoint(oSurvey, New PointF(sX, sY), bBeginSequence, oPen, iLineType, bSegmentLocked, sBindedSegment)

                        Call pAdd(oPoint)
                    Loop Until iChar >= sData.Length
                End If
            Else
                'load data in old format....
                For Each oXMLPoint As XmlElement In Points.ChildNodes
                    Dim oPoint As cPoint = New cPoint(oSurvey, oXMLPoint)
                    Call pAdd(oPoint)
                Next
            End If
            Call pBindPoints()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Item As cItem, ByVal Points As XmlElement)
            oSurvey = Survey
            oItem = Item
            Call Parse(Points)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPoints As XmlElement = Document.CreateElement("points")
            Dim sLastSegmentBinded As String = ""
            Dim bAppendSpace As Boolean = False
            Dim oPointData As System.Text.StringBuilder = New System.Text.StringBuilder
            For Each oPoint As cPoint In oPoints
                Call oPointData.Append(modNumbers.NumberToString(oPoint.X) & " ")
                Call oPointData.Append(modNumbers.NumberToString(oPoint.Y) & " ")
                If oPoint.BeginSequence Then
                    bAppendSpace = True
                    Call oPointData.Append("B")
                    If Not oPoint.Pen Is Nothing Then
                        Call oPointData.Append("P")
                        Call oPoint.Pen.SaveTo(File, Document, oXmlPoints)
                    End If
                    If oPoint.LineType <> Items.cIItemLine.LineTypeEnum.Undefined Then
                        Call oPointData.Append("T" & oPoint.LineType.ToString("D"))
                    End If
                End If
                If oPoint.SegmentLocked Then
                    bAppendSpace = True
                    Call oPointData.Append("L")
                End If
                If Not oPoint.BindedSegment Is Nothing Then
                    bAppendSpace = True
                    If sLastSegmentBinded = oPoint.BindedSegment.ID Then
                        Call oPointData.Append("S")
                    Else
                        sLastSegmentBinded = oPoint.BindedSegment.ID
                        Call oPointData.Append("S" & sLastSegmentBinded)
                    End If
                End If
                If bAppendSpace Then
                    Call oPointData.Append(" ")
                    bAppendSpace = False
                End If
            Next
            Call oXmlPoints.SetAttribute("data", oPointData.ToString)

            Call Parent.AppendChild(oXmlPoints)
            Return oXmlPoints
        End Function

        Public Function GetPoints() As PointF()
            Dim oPaintPoints(oPoints.Count - 1) As PointF
            For i = 0 To oPoints.Count - 1
                oPaintPoints(i) = oPoints(i).Point
            Next
            Return oPaintPoints
        End Function

        Friend Function GetSequences() As List(Of cSequence)
            If bChanged Then
                Dim oSequence As cSequence
                Dim bFirst As Boolean = True
                If oSequences Is Nothing Then
                    oSequences = New List(Of cSequence)
                Else
                    Call oSequences.Clear()
                End If
                For Each oPoint As cPoint In oPoints
                    If oPoint.BeginSequence Or bFirst Then
                        bFirst = False
                        oSequence = New cSequence(oPoint)
                        Call oSequences.Add(oSequence)
                    Else
                        Call oSequence.Append(oPoint)
                    End If
                Next
                bChanged = False
            End If
            Return oSequences
        End Function

        Friend Function GetSequencesByCaveAndBranch(Cave As String, Branch As String) As List(Of cSequence)
            Dim oSequence As cSequence
            Dim sCave As String = Cave.ToLower
            Dim sBranch As String = Branch.ToLower
            Dim bFirst As Boolean = True
            Dim oSequences As List(Of cSequence) = New List(Of cSequence)
            Dim oLastPen As cPen
            Dim iLastLineType As Items.cIItemLine.LineTypeEnum
            Dim oNewPoint As cPoint
            For Each oPoint As cPoint In oPoints
                If oPoint.BeginSequence Then
                    oLastPen = oPoint.Pen
                    iLastLineType = oPoint.LineType
                End If
                Dim oSegment As cSegment = oPoint.BindedSegment
                If Not oSegment Is Nothing Then
                    If oSegment.Cave.ToLower = sCave And oSegment.Branch.ToLower = sBranch Then
                        If oPoint.BeginSequence Or bFirst Then
                            bFirst = False
                            oNewPoint = oPoint.Clone
                            oSequence = New cSequence(oNewPoint)
                            oNewPoint.BeginSequence = True
                            oNewPoint.Pen = oLastPen
                            oNewPoint.LineType = iLastLineType
                            Call oSequences.Add(oSequence)
                        Else
                            oNewPoint = oPoint.Clone
                            Call oSequence.Append(oNewPoint)
                        End If
                    Else
                        If Not bFirst Then
                            oNewPoint = oPoint.Clone
                            Call oSequence.Append(oNewPoint)
                        End If
                        bFirst = True
                    End If
                End If
            Next
            Return oSequences
        End Function

        Public Sub DeleteSequence(Sequence As cSequence)
            For Each oPoint As cPoint In Sequence
                Call oPoints.Remove(oPoint)
            Next
            Call pBindPoints()
        End Sub

        Public Sub DeleteSequence(Point As cPoint)
            Dim iIndex As Integer = oPoints.IndexOf(Point)
            Do While Not oPoints(iIndex).BeginSequence And iIndex > 0
                iIndex -= 1
            Loop
            Do
                Call oPoints.RemoveAt(iIndex)
                If oPoints.Count = 0 Or iIndex >= oPoints.Count Then Exit Do
            Loop Until oPoints(iIndex).BeginSequence
            Call pBindPoints()
        End Sub

        Public Sub DivideSequence(ByVal Point As cPoint, Optional Join As Boolean = False)
            Dim iIndex As Integer = oPoints.IndexOf(Point)
            Dim oPoint As cPoint = New cPoint(oSurvey, Point.Point)
            Call pInsert(iIndex, oPoint)
            Point.BeginSequence = True
            If Join Then Point.Join(oPoint)
            Call pBindPoints()
        End Sub

        Public Function LastSequence() As cSequence
            Return GetSequences().Last
        End Function

        Public Function FirstSequence() As cSequence
            Return GetSequences().First
        End Function

        Public Function GetSequence(ByVal Point As cPoint) As cSequence
            Dim oSequences As List(Of cSequence) = GetSequences()
            For Each oSequence As cSequence In oSequences
                If oSequence.Contains(Point) Then
                    Return oSequence
                End If
            Next
            Return Nothing
        End Function

        Public Sub Revert()
            Dim oSequences As List(Of cSequence) = GetSequences()
            For Each oSequence As cSequence In oSequences
                Call oSequence.Reverse()
            Next
            Call BeginUpdate()
            Call oPoints.Clear()
            Call oSequences.Reverse()
            For Each oSequence As cSequence In oSequences
                Call AddRange(oSequence)
            Next
            Call pBindPoints()
            Call EndUpdate()
        End Sub

        Public Sub RevertSequence(ByVal Point As cPoint)
            Dim oSequences As List(Of cSequence) = GetSequences()
            For Each oSequence As cSequence In oSequences
                If oSequence.Contains(Point) Then
                    Call oSequence.Reverse()
                End If
            Next
            Call BeginUpdate()
            Call oPoints.Clear()
            For Each oSequence As cSequence In oSequences
                Call AddRange(oSequence)
            Next
            Call pBindPoints()
            Call EndUpdate()
        End Sub

        Public Sub CloseSequence(ByVal Point As cPoint)
            Dim bFoundedSequence As Boolean = False
            Dim oNextPoint As cPoint = Nothing
            Dim iIndex As Integer = 0
            For Each oPoint As cPoint In oPoints
                If bFoundedSequence And oPoint.BeginSequence Then
                    oNextPoint = oPoint
                    Exit For
                End If
                If oPoint Is Point Then
                    bFoundedSequence = True
                End If
                iIndex += 1
            Next
            If oNextPoint Is Nothing Then
                oNextPoint = oPoints(0)
            End If
            If bFoundedSequence Then
                Dim oPoint As cPoint = New cPoint(oSurvey, oNextPoint.X, oNextPoint.Y)
                Call pInsert(iIndex, oPoint)
                Call oPoint.Join(oNextPoint)
            End If
            Call pBindPoints()
        End Sub

        Public Function CombineSequences(Point As cPoint) As cPoint
            Dim oEditPoint As cPoint = Point
            Dim iType As cPoint.PointTypeEnum = oEditPoint.Type
            Dim oItem As Items.cIItemLine = Point.Item
            If Not (cPoint.IsFirstOfAll(iType) OrElse cPoint.IsLastOfAll(iType)) Then
                If cPoint.IsFirst(iType) Then
                    Dim oPreviousPoint As cPoint = oEditPoint.GetPrevious
                    If Not IsNothing(oPreviousPoint) Then
                        Call BeginUpdate()
                        Dim oSequence As cSequence = oEditPoint.GetSequence()
                        Dim oPreviousSequence As cSequence = oPreviousPoint.GetSequence()
                        Select Case oSequence.GetLineType(oItem.LineType)
                            Case Items.cIItemLine.LineTypeEnum.Lines
                                oPreviousSequence = pSequenceToLine(oItem.LineType, oPreviousSequence)
                            Case Items.cIItemLine.LineTypeEnum.Splines
                                oPreviousSequence = pSequenceToSpline(oItem.LineType, oPreviousSequence)
                            Case Items.cIItemLine.LineTypeEnum.Beziers
                                oPreviousSequence = pSequenceToBezier(oItem.LineType, oPreviousSequence)
                        End Select
                        oPreviousPoint = oEditPoint.GetPrevious
                        Dim oOldPen As cPen = oEditPoint.Pen
                        Dim oNewEditPoint As cPoint
                        If oEditPoint.Point.Equals(oPreviousPoint.Point) Then
                            oEditPoint.BeginSequence = False
                            oNewEditPoint = oEditPoint
                            Call Remove(oPreviousPoint)
                        Else
                            oNewEditPoint = New cPoint(oSurvey, modPaint.GetMediumPoint(oEditPoint.Point, oPreviousPoint.Point))
                            Call Insert(oEditPoint.GetIndex, oNewEditPoint)
                            oEditPoint.BeginSequence = False
                            Call Remove(oEditPoint)
                            Call Remove(oPreviousPoint)
                        End If
                        Dim oNewSequence As cSequence = oNewEditPoint.GetSequence
                        oNewSequence.First.Pen = oOldPen
                        Call EndUpdate()
                        Return oNewEditPoint
                    End If
                ElseIf cPoint.IsLast(iType) Then
                    Dim oNextPoint As cPoint = oEditPoint.GetNext
                    If Not IsNothing(oNextPoint) Then
                        Call BeginUpdate()
                        Dim oSequence As cSequence = oEditPoint.GetSequence()
                        Dim oNextSequence As cSequence = oNextPoint.GetSequence()
                        Select Case oSequence.GetLineType(oItem.LineType)
                            Case Items.cIItemLine.LineTypeEnum.Lines
                                oNextSequence = pSequenceToLine(oItem.LineType, oNextSequence)
                            Case Items.cIItemLine.LineTypeEnum.Splines
                                oNextSequence = pSequenceToSpline(oItem.LineType, oNextSequence)
                            Case Items.cIItemLine.LineTypeEnum.Beziers
                                oNextSequence = pSequenceToBezier(oItem.LineType, oNextSequence)
                        End Select
                        oNextPoint = oEditPoint.GetNext
                        Dim oOldPen As cPen = oEditPoint.Pen
                        Dim oNewEditPoint As cPoint
                        If oEditPoint.Point.Equals(oNextPoint.Point) Then
                            oNextPoint.BeginSequence = False
                            oNewEditPoint = oNextPoint
                            Call Remove(oEditPoint)
                        Else
                            oNewEditPoint = New cPoint(oSurvey, modPaint.GetMediumPoint(oEditPoint.Point, oNextPoint.Point))
                            Call Insert(oEditPoint.GetIndex, oNewEditPoint)
                            oNextPoint.BeginSequence = False
                            Call Remove(oNextPoint)
                            Call Remove(oEditPoint)
                        End If
                        Dim oNewSequence As cSequence = oNewEditPoint.GetSequence
                        oNewSequence.First.Pen = oOldPen
                        Call EndUpdate()
                        Return oNewEditPoint
                    End If
                End If
            End If
        End Function

        Private Function pSequenceToLine(LineType As Items.cIItemLine.LineTypeEnum, Sequence As cSequence) As cSequence
            Dim iIndex As Integer = oPoints.IndexOf(Sequence.First)
            Dim oNewSequence As cSequence = modPaint.ToStraightLine(oSurvey, Sequence, LineType)
            If oNewSequence Is Nothing Then
                Return Nothing
            Else
                'Call BeginUpdate()
                If oNewSequence.First.LineType = LineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
                Call InsertRange(iIndex, oNewSequence)
                Call DeleteSequence(Sequence)
                'Call EndUpdate()
                Return oNewSequence
            End If
        End Function

        Private Function pSequenceToSpline(LineType As Items.cIItemLine.LineTypeEnum, Sequence As cSequence) As cSequence
            Dim iIndex As Integer = oPoints.IndexOf(Sequence.First)
            Dim oNewSequence As cSequence = modPaint.ToSpline(oSurvey, Sequence, LineType)
            If oNewSequence Is Nothing Then
                Return Nothing
            Else
                'Call BeginUpdate()
                If oNewSequence.First.LineType = LineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
                Call InsertRange(iIndex, oNewSequence)
                Call DeleteSequence(Sequence)
                'Call EndUpdate()
                Return oNewSequence
            End If
        End Function

        Private Function pSequenceToBezier(LineType As Items.cIItemLine.LineTypeEnum, Sequence As cSequence) As cSequence
            Dim iIndex As Integer = oPoints.IndexOf(Sequence.First)
            Dim oNewSequence As cSequence = modPaint.ToBezier(oSurvey, Sequence, LineType)
            If oNewSequence Is Nothing Then
                Return Nothing
            Else
                'Call BeginUpdate()
                If oNewSequence.First.LineType = LineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
                Call InsertRange(iIndex, oNewSequence)
                Call DeleteSequence(Sequence)
                'Call EndUpdate()
                Return oNewSequence
            End If
        End Function

        'Private Function pSequenceToLine(Item As cItem, Sequence As cSequence) As cSequence
        '    Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(Item, Items.cIItemLine).LineType
        '    Dim iIndex As Integer = Item.Points.IndexOf(Sequence.First)
        '    Dim oNewSequence As cSequence = modPaint.ToStraightLine(oSurvey, Sequence, DirectCast(Item, Items.cIItemLine).LineType)
        '    If oNewSequence Is Nothing Then
        '        Return Nothing
        '    Else
        '        Call Item.Points.BeginUpdate()
        '        If oNewSequence.First.LineType = iLineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
        '        Call Item.Points.InsertRange(iIndex, oNewSequence)
        '        Call Item.Points.DeleteSequence(Sequence)
        '        Call Item.Points.EndUpdate()
        '        Return oNewSequence
        '    End If
        'End Function

        'Private Function pSequenceToSpline(Item As cItem, Sequence As cSequence) As cSequence
        '    Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(Item, Items.cIItemLine).LineType
        '    Dim iIndex As Integer = Item.Points.IndexOf(Sequence.First)
        '    Dim oNewSequence As cSequence = modPaint.ToSpline(oSurvey, Sequence, DirectCast(Item, Items.cIItemLine).LineType)
        '    If oNewSequence Is Nothing Then
        '        Return Nothing
        '    Else
        '        Call Item.Points.BeginUpdate()
        '        If oNewSequence.First.LineType = iLineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
        '        Call Item.Points.InsertRange(iIndex, oNewSequence)
        '        Call Item.Points.DeleteSequence(Sequence)
        '        Call Item.Points.EndUpdate()
        '        Return oNewSequence
        '    End If
        'End Function

        'Private Function pSequenceToBezier(Item As cItem, Sequence As cSequence) As cSequence
        '    Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(Item, Items.cIItemLine).LineType
        '    Dim iIndex As Integer = Item.Points.IndexOf(Sequence.First)
        '    Dim oNewSequence As cSequence = modPaint.ToBezier(oSurvey, Sequence, DirectCast(Item, Items.cIItemLine).LineType)
        '    If oNewSequence Is Nothing Then
        '        Return Nothing
        '    Else
        '        Call Item.Points.BeginUpdate()
        '        If oNewSequence.First.LineType = iLineType Then oNewSequence.First.LineType = Items.cIItemLine.LineTypeEnum.Undefined
        '        Call Item.Points.InsertRange(iIndex, oNewSequence)
        '        Call Item.Points.DeleteSequence(Sequence)
        '        Call Item.Points.EndUpdate()
        '        Return oNewSequence
        '    End If
        'End Function

        Public Sub CombineSequences()
            Call BeginUpdate()
            Dim oItem = oPoints.First.Item
            Dim oNewSequences As List(Of cSequence) = New List(Of cSequence)
            For Each oSequence As cSequence In GetSequences()
                Dim iLineType As Items.cIItemLine.LineTypeEnum = DirectCast(oItem, Items.cIItemLine).LineType
                Dim oNewSequence As cSequence = Nothing
                Select Case iLineType
                    Case Items.cIItemLine.LineTypeEnum.Lines
                        oNewSequence = pSequenceToLine(iLineType, oSequence)
                    Case Items.cIItemLine.LineTypeEnum.Splines
                        oNewSequence = pSequenceToSpline(iLineType, oSequence)
                    Case Items.cIItemLine.LineTypeEnum.Beziers
                        oNewSequence = pSequenceToBezier(iLineType, oSequence)
                End Select
                If IsNothing(oNewSequence) Then oNewSequence = oSequence
                Call oNewSequences.add(oNewSequence)
            Next
            Call oPoints.Clear()
            For Each oNewSequence As cSequence In oNewSequences
                Call AddRange(oNewSequence)
            Next
            Call pBindPoints()
            Call EndUpdate()
        End Sub

        Public Sub CloseSequences()
            Dim iSequenceCount As Integer = 0
            Dim oSequences() As cSequence
            Dim oSequence As cSequence
            Dim oNextSequence As cSequence
            Dim bFirst As Boolean = True
            For Each oPoint As cPoint In oPoints
                If oPoint.BeginSequence Or bFirst Then
                    bFirst = False
                    oSequence = New cSequence(oPoint)
                    ReDim Preserve oSequences(iSequenceCount)
                    oSequences(iSequenceCount) = oSequence
                    iSequenceCount += 1
                Else
                    Call oSequence.Append(oPoint)
                End If
            Next

            For iSequence As Integer = 0 To oSequences.Length - 1
                oSequence = oSequences(iSequence)
                If iSequence < oSequences.Length - 1 Then
                    oNextSequence = oSequences(iSequence + 1)
                Else
                    oNextSequence = oSequences(0)
                End If
                Dim oLastPoint As cPoint = oSequence.Last
                Dim oNextPoint As cPoint = oNextSequence.First
                Dim oPoint As cPoint = New cPoint(oSurvey, oNextPoint.X, oNextPoint.Y)
                AddHandler oPoint.OnChanged, AddressOf oPoint_OnChanged
                AddHandler oPoint.OnGetType, AddressOf oPoint_OnGetType
                AddHandler oPoint.OnGetItem, AddressOf oPoint_OnGetItem
                AddHandler oPoint.OnGetNext, AddressOf oPoint_OnGetNext
                AddHandler oPoint.OnGetPrevious, AddressOf oPoint_OnGetPrevious
                Dim iIndex As Integer = oPoints.IndexOf(oLastPoint)
                Call oPoints.Insert(iIndex + 1, oPoint)
                Call oPoint.Join(oNextPoint)
            Next
            Call pBindPoints()
        End Sub

        Public Sub ReorderSequences()
            Call BeginUpdate()

            Dim iSequenceCount As Integer = 0
            Dim oSequences() As cSequence
            Dim oSequence As cSequence
            Dim bFirst As Boolean = True
            For Each oPoint As cPoint In oPoints
                If oPoint.BeginSequence Or bFirst Then
                    bFirst = False
                    oSequence = New cSequence(oPoint)
                    ReDim Preserve oSequences(iSequenceCount)
                    oSequences(iSequenceCount) = oSequence
                    iSequenceCount += 1
                Else
                    Call oSequence.Append(oPoint)
                End If
            Next

            Dim oOldSequence As List(Of cSequence) = New List(Of cSequence)(oSequences)
            If oOldSequence.Count > 1 Then
                Dim oNewSequences As List(Of cSequence) = New List(Of cSequence)
                Dim oNextSequence As cSequence = Nothing
                Do
                    If oNextSequence Is Nothing Then
                        oSequence = oOldSequence(0)
                    Else
                        oSequence = oNextSequence
                    End If
                    Call oOldSequence.Remove(oSequence)
                    Call oNewSequences.Add(oSequence)

                    Dim sDist As Single = Single.MaxValue
                    Dim oPoint As PointF = oSequence.Last.Point

                    If oOldSequence.Count > 0 Then
                        For Each oSequenceToCheck As cSequence In oOldSequence
                            Dim sCheckDist As Single = modPaint.DistancePointToPoint(oPoint, oSequenceToCheck.First.Point)
                            If sCheckDist < sDist Then
                                sDist = sCheckDist
                                oNextSequence = oSequenceToCheck
                            End If
                            sCheckDist = modPaint.DistancePointToPoint(oPoint, oSequenceToCheck.Last.Point)
                            If sCheckDist < sDist Then
                                sDist = sCheckDist
                                Call oSequenceToCheck.Reverse()
                                oNextSequence = oSequenceToCheck
                            End If
                        Next
                    End If
                Loop While oOldSequence.Count

                Call oPoints.Clear()
                For Each oSequence In oNewSequences
                    For Each oPoint As cPoint In oSequence
                        Call pAdd(oPoint)
                    Next
                Next
            End If
            Call pBindPoints()
            Call EndUpdate()
        End Sub

        Private Sub pBindPoints()
            bChanged = True
            If Not bInUpdate Then RaiseEvent OnChanged(Me)
        End Sub

        Private Sub oPoint_OnGetItem(Sender As cPoint, ByRef Item As cItem)
            Item = oItem
        End Sub

        Private Sub oPoint_OnGetPrevious(Sender As cPoint, ByRef Point As cPoint)
            Dim iIndex As Integer = oPoints.IndexOf(Sender)
            If iIndex > 0 Then
                Point = oPoints(iIndex - 1)
            Else
                Point = Nothing
            End If
        End Sub

        Private Sub oPoint_OnGetNext(Sender As cPoint, ByRef Point As cPoint)
            Dim iIndex As Integer = oPoints.IndexOf(Sender)
            If iIndex < 0 Then
                Point = Nothing
            Else
                If iIndex < oPoints.Count - 1 Then
                    Point = oPoints(iIndex + 1)
                End If
            End If
        End Sub

        Private Sub oPoint_OnGetType(Sender As cPoint, ByRef Type As cPoint.PointTypeEnum)
            Dim oSequence As cSequence = GetSequence(Sender)
            If oSequence Is Nothing Then
                Type = cPoint.PointTypeEnum.MainPoint
            Else
                If oPoints.First Is Sender Then
                    Type = cPoint.PointTypeEnum.FirstOfAll
                ElseIf oPoints.Last Is Sender Then
                    Type = cPoint.PointTypeEnum.LastOfAll
                End If
                If oSequence.First Is Sender Then
                    Type = Type Or cPoint.PointTypeEnum.First
                ElseIf oSequence.Last Is Sender Then
                    Type = Type Or cPoint.PointTypeEnum.Last
                End If
                Dim iDefaultLineType As Items.cIItemLine.LineTypeEnum = pGetOwnerLineType()
                Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(iDefaultLineType)
                If iLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
                    If oSequence.IndexOf(Sender) Mod 3 = 0 Then
                        Type = Type Or cPoint.PointTypeEnum.MainPoint
                    Else
                        Type = Type Or cPoint.PointTypeEnum.ControlPoint
                    End If
                Else
                    Type = Type Or cPoint.PointTypeEnum.MainPoint
                End If
            End If
        End Sub

        Private Sub oPoint_OnChanged(ByVal Sender As cPoint)
            Call pBindPoints()
        End Sub

        Public Function ToArray() As cPoint()
            Return oPoints.ToArray
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cPoint) Implements IEnumerable(Of cPoint).GetEnumerator
            Return oPoints.GetEnumerator
        End Function
    End Class
End Namespace