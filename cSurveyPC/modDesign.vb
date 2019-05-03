Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Module modDesign

    Public Function GetIfItemMustBeDrawedByHiddenFlag(ByVal PaintOptions As cOptions, ByVal Item As cItem) As Boolean
        Dim oProfile As cIProfile = PaintOptions.GetParent
        If IsNothing(oProfile) OrElse (Not IsNothing(oProfile) AndAlso oProfile.Items.IsVisible(Item, True)) Then
            If PaintOptions.CurrentRule.Items.IsVisible(Item, PaintOptions.CurrentRule.Categories(Item.Category)) Then
                If PaintOptions.IsDesign Then
                    'in design layer visibility is taken from current survey...
                    Dim oLayer As cLayer = If(Item.Design.Type = cIDesign.cDesignTypeEnum.Plan, PaintOptions.Survey.Plan, PaintOptions.Survey.Profile).layers(Item.Layer.Type)
                    If oLayer.HiddenInDesign Then
                        'If Item.Layer.HiddenInDesign Then
                        Return False
                        Else
                            If Item.HiddenInDesign Then
                                Return False
                            Else
                                Return Not Item.FilteredInDesign And Not Item.HavePaintProblem
                            End If
                        End If
                    Else
                        If Item.Layer.HiddenInPreview Then
                        Return False
                    Else
                        If Item.HiddenInPreview Then
                            Return False
                        Else
                            Return True
                        End If
                    End If
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetIfSegmentMustBeDrawedByHiddenFlag(ByVal PaintOptions As cOptions, ByVal Segment As cSegment) As Boolean
        Return True
    End Function

    Public Function GetIfItemMustBeDrawedByCaveAndBranch(ByVal PaintOptions As cOptions, ByVal Item As cItem, ByVal CurrentCave As String, ByVal CurrentBranch As String) As Boolean
        If IsNothing(Item) Then
            Return False
        Else
            If PaintOptions.HighlightCurrentCave Then
                'solo nel caso in cui ho chiesto di evidenziare la grotta/ramo attivo...
                'If PaintOptions.CurrentRule.Categories(Item.Category) Then
                Select Case PaintOptions.HighlightMode
                    Case cOptions.HighlightModeEnum.Default
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra SOLO quel ramo
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Item.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Item.Cave.ToLower = CurrentCave.ToLower And Item.Branch.ToLower = CurrentBranch.ToLower
                        End If
                    Case cOptions.HighlightModeEnum.Hierarchic
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra gli oggetti di quel ramo e tutti gli oggetti figli di quel ramo 
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Item.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Item.Cave.ToLower = CurrentCave.ToLower And (Item.Branch & cCaveInfoBranches.sBranchSeparator).ToLower.StartsWith(CurrentBranch.ToLower)
                        End If
                    Case cOptions.HighlightModeEnum.ExactMatch
                        'confronta SEMPRE grotta/ramo richiesti con quelli dell'oggetto...utile per trovare oggetti orfani o oggetti ancora non collegati...
                        Return Item.Cave.ToLower = CurrentCave.ToLower And Item.Branch.ToLower = CurrentBranch.ToLower
                End Select
                'Else
                '    Return False
                'End If
            Else
                'Return PaintOptions.CurrentRule.Categories(Item.Category)
                Return True
            End If
        End If
    End Function

    Public Function GetIfSegmentMustBeDrawedByCaveAndBranch(ByVal PaintOptions As cOptions, ByVal Segment As cSegment, ByVal CurrentCave As String, ByVal CurrentBranch As String) As Boolean
        If IsNothing(Segment) Then
            Return False
        Else
            If PaintOptions.HighlightCurrentCave Then
                'solo nel caso in cui ho chiesto di evidenziare la grotta/ramo attivo...
                Select Case PaintOptions.HighlightMode
                    Case cOptions.HighlightModeEnum.Default
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra SOLO quel ramo
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Segment.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Segment.Cave.ToLower = CurrentCave.ToLower And Segment.Branch.ToLower = CurrentBranch.ToLower
                        End If
                    Case cOptions.HighlightModeEnum.Hierarchic
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra gli oggetti di quel ramo e tutti gli oggetti figli di quel ramo 
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Segment.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Segment.Cave.ToLower = CurrentCave.ToLower And (Segment.Branch & cCaveInfoBranches.sBranchSeparator).ToLower.StartsWith(CurrentBranch.ToLower)
                        End If
                    Case cOptions.HighlightModeEnum.ExactMatch
                        'confronta SEMPRE grotta/ramo richiesti con quelli dell'oggetto...utile per trovare oggetti orfani o oggetti ancora non collegati...
                        Return Segment.Cave.ToLower = CurrentCave.ToLower And Segment.Branch.ToLower = CurrentBranch.ToLower
                End Select
            Else
                Return True
            End If
        End If
    End Function


    '#Region "GetLRUDFromDesign"


    'Private Function GetCaveAndBranchList(Survey As cSurvey.cSurvey, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProjectedData, FromOrTo As GetDesignStationEnum) As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder)
    '    'CREO UN ELENCO DELLE GROTTE/RAMI DA DISEGNARE...dovrebbe essere elencato l'insieme grotte/ramo delle battute che partono dal caposaldo indicato...
    '    Dim oCaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder) = New Dictionary(Of String, cCaveBranchPlaceholder)
    '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '    Dim sKey As String = Segment.Cave & "|" & Segment.Branch
    '    Call oCaveAndBraches.Add(sKey, New modCaveAndBranch.cCaveBranchPlaceholder(Segment.Cave, Segment.Branch))
    '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '    Dim sStation As String
    '    If FromOrTo = GetDesignStationEnum.From Then
    '        sStation = SegmentData.From
    '    Else
    '        sStation = SegmentData.To
    '    End If
    '    If Survey.TrigPoints.Contains(sStation) Then
    '        Dim oSegments As cSegmentCollection = Survey.TrigPoints(sStation).GetSegments
    '        For Each oSegment As cSegment In oSegments
    '            sKey = oSegment.Cave & "|" & oSegment.Branch
    '            If Not oCaveAndBraches.ContainsKey(sKey) Then
    '                Call oCaveAndBraches.Add(sKey, New modCaveAndBranch.cCaveBranchPlaceholder(oSegment.Cave, oSegment.Branch))
    '            End If
    '        Next
    '    End If
    '    Return oCaveAndBraches
    'End Function

    'Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
    '    Dim oPoint As PointF
    '    If FromOrTo = GetDesignStationEnum.From Then
    '        oPoint = Segment.Data.Plan.FromPoint
    '    Else
    '        oPoint = Segment.Data.Plan.ToPoint
    '    End If
    '    Return GetFBFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    'End Function

    '    Friend Class cLRFromDesignCache
    '        Implements IDisposable

    '        Private oSurvey As cSurvey.cSurvey
    '        Private oPaintOptions As cOptions
    '        Private oSessions As SortedDictionary(Of String, cSession)

    '        Private oImage As Bitmap
    '        Private oImageBounds As Rectangle
    '        Private oGraphics As Graphics
    '        Private oClippingRegions As cClippingRegions

    '        Private oTraslation As SizeF
    '        Private sScale As Single

    '        Private bIsEmpty As Boolean

    '        Public Function GetVThreshold(Segment As cSegment) As Single
    '            Return oSessions(Segment.Session).GetVThreshold()
    '        End Function

    '        Public ReadOnly Property Traslation As SizeF
    '            Get
    '                Return oTraslation
    '            End Get
    '        End Property

    '        Public ReadOnly Property Scale As Single
    '            Get
    '                Return sScale
    '            End Get
    '        End Property

    '        Public Function Contains(X As Single, Y As Single) As Boolean
    '            Return oImageBounds.Contains(X, Y)
    '        End Function

    '        Public Function Contains(Point As PointF) As Boolean
    '            Return Contains(Point.X, Point.Y)
    '        End Function

    '        Public Sub SetPixel(X As Single, Y As Single, Color As Color)
    '            If oImageBounds.Contains(X, Y) Then
    '                Call oImage.SetPixel(X, Y, Color)
    '            End If
    '        End Sub

    '        Public Sub SetPixel(Point As PointF, Color As Color)
    '            Call SetPixel(Point.X, Point.Y, Color)
    '        End Sub

    '        Public Function GetPixel(X As Single, Y As Single) As Color
    '            If oImageBounds.Contains(X, Y) Then
    '                Return oImage.GetPixel(X, Y)
    '            Else
    '                Return Color.White
    '            End If
    '        End Function

    '        Public Function GetPixel(Point As PointF) As Color
    '            Return GetPixel(Point.X, Point.Y)
    '        End Function

    '        Public ReadOnly Property Image As Bitmap
    '            Get
    '                Return oImage
    '            End Get
    '        End Property

    '        Public Sub PrepareImage(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
    '            If Not bIsEmpty Then
    '                Call oGraphics.Clear(Color.White)
    '                Dim bDone As Boolean
    '                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
    '                    bDone = False
    '                    Dim sCave As String = oCaveBranchPlaceholder.Cave
    '                    Dim sBranch As String = oCaveBranchPlaceholder.Branch
    '                    Do
    '                        Dim oRegion As Region = oClippingRegions(sCave, sBranch)
    '                        If Not oRegion Is Nothing Then
    '                            If Not oRegion.IsEmpty(oGraphics) Then
    '                                Call oGraphics.FillRegion(Brushes.Black, oRegion)
    '                                bDone = True
    '                            End If
    '                        End If
    '                        If sBranch = "" Then
    '                            bDone = True
    '                        Else
    '                            If Not bDone Then
    '                                Dim oBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos(sCave).Branches(sBranch)
    '                                If IsNothing(oBranch) Then
    '                                    sBranch = ""
    '                                Else
    '                                    If IsNothing(oBranch.Parent) Then
    '                                        sBranch = ""
    '                                    Else
    '                                        sBranch = oBranch.Parent.Path
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    Loop Until bDone
    '                Next
    '            End If
    '        End Sub

    '        Public ReadOnly Property PaintOptions As cOptions
    '            Get
    '                Return oPaintOptions
    '            End Get
    '        End Property

    '        Public ReadOnly Property IsEmpty As Boolean
    '            Get
    '                Return bIsEmpty
    '            End Get
    '        End Property

    '        Public Sub New(Survey As cSurvey.cSurvey, Plan As cDesignPlan, PaintOptions As cOptions, Optional MaxSize As Integer = 2000)
    '            oSurvey = Survey
    '            oPaintOptions = PaintOptions

    '            oSessions = Survey.Properties.Sessions.GetWithEmpty()

    '            Dim oRealBounds As RectangleF = Plan.GetBounds(PaintOptions)
    '            If modPaint.IsRectangleEmpty(oRealBounds) Then
    '                bIsEmpty = True
    '            Else
    '                'sScale = 1
    '                If oRealBounds.Width > oRealBounds.Height Then
    '                    sScale = MaxSize / oRealBounds.Width
    '                Else
    '                    sScale = MaxSize / oRealBounds.Height
    '                End If
    '                oTraslation = New SizeF(-1 * oRealBounds.X, -1 * oRealBounds.Y)

    '                oImageBounds = New Rectangle(0, 0, oRealBounds.Width * sScale, oRealBounds.Height * sScale)
    '                oImage = New Bitmap(oImageBounds.Width, oImageBounds.Height)

    '                Using oMatrix As Matrix = New Matrix
    '                    Call oMatrix.Translate(oTraslation.Width, oTraslation.Height, MatrixOrder.Append)
    '                    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
    '                    oGraphics = Graphics.FromImage(oImage)
    '                    oGraphics.Transform = oMatrix

    '                    Dim oPaintOptions As cOptions = oSurvey.Options("_design.plan").DefaultOptions
    '                    oClippingRegions = Plan.GetCaveClippingRegions(oGraphics, oPaintOptions)
    '                End Using
    '            End If
    '        End Sub

    '#Region "IDisposable Support"
    '        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    '        ' IDisposable
    '        Protected Overridable Sub Dispose(disposing As Boolean)
    '            If Not Me.disposedValue Then
    '                If disposing Then
    '                    ' TODO: eliminare stato gestito (oggetti gestiti).
    '                    Call oClippingRegions.Dispose()
    '                    Call oGraphics.Dispose()
    '                    Call oImage.Dispose()
    '                End If
    '            End If
    '            Me.disposedValue = True
    '        End Sub

    '        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    '        Public Sub Dispose() Implements IDisposable.Dispose
    '            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
    '            Dispose(True)
    '            GC.SuppressFinalize(Me)
    '        End Sub
    '#End Region

    '    End Class

    'Friend Function GetFBFromDesign(Survey As cSurvey.cSurvey, Cache As cLRFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.cISegmentPlotSpatialData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '    Call Cache.PrepareImage(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

    '    Dim iMaxWidth As Integer = 200

    '    Dim sBearing As Single = SegmentData.Bearing
    '    Dim oBasePointF As PointF = PointF.Add(GenericPoint, Cache.Traslation)
    '    oBasePointF.X = oBasePointF.X * Cache.Scale
    '    oBasePointF.Y = oBasePointF.Y * Cache.Scale

    '    Dim oPoint As Point
    '    Dim oColor As Color
    '    Dim iD As Integer

    '    iD = 0
    '    Dim sFront As Single
    '    Do
    '        iD += 1
    '        Dim oDiff As SizeF = modPaint.Trigo(iD, sBearing)
    '        oPoint = Point.Truncate(PointF.Add(oBasePointF, oDiff))
    '        If Cache.Contains(oPoint) Then
    '            oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '            sFront = Math.Abs(iD / Cache.Scale)
    '        End If
    '    Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sFront < iMaxWidth)
    '    'Call Cache.SetPixel(oPoint.X, oPoint.Y, Color.Green)
    '    If (sFront >= iMaxWidth) Then
    '        sFront = 0
    '    End If

    '    iD = 0
    '    Dim sBehind As Single
    '    Do
    '        iD -= 1
    '        Dim oDiff As SizeF = modPaint.Trigo(iD, sBearing)
    '        oPoint = Point.Truncate(PointF.Add(oBasePointF, oDiff))
    '        If Cache.Contains(oPoint) Then
    '            oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '            sBehind = Math.Abs(iD / Cache.Scale)
    '        End If
    '    Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sBehind < iMaxWidth)
    '    'Call Cache.SetPixel(oPoint.X, oPoint.Y, Color.Green)
    '    If (sBehind >= iMaxWidth) Then
    '        sBehind = 0
    '    End If

    '    'Call Cache.SetPixel(oBasePointF.X, oBasePointF.Y, Color.Red)
    '    'Cache.Image.Save("d:\" & Segment.From & " " & Segment.To & " - " & Strings.Format(Now, "yyMMddHHmmss") & ".jpg")

    '    Return New SizeF(sFront, sBehind)
    'End Function

    'Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '    Dim oSurvey As cSurvey.cSurvey = Segment.Survey
    '    Dim oCache As cLRFromDesignCache = New cLRFromDesignCache(oSurvey, oSurvey.Plan, PaintOptions)
    '    Return GetFBFromDesign(oSurvey, oCache, Segment, Segment.Data.Data, GenericPoint, FromOrTo)
    'End Function

    'Public Function GetLRFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
    '    Dim oPoint As PointF
    '    If FromOrTo = GetDesignStationEnum.From Then
    '        oPoint = Segment.Data.Plan.FromPoint
    '    Else
    '        oPoint = Segment.Data.Plan.ToPoint
    '    End If
    '    Return GetLRFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    'End Function

    'Friend Function GetLRFromDesign(Survey As cSurvey.cSurvey, Cache As cLRFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIPlanProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '    If Cache.IsEmpty Then
    '        Return New SizeF(0, 0)
    '    Else
    '        Call Cache.PrepareImage(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

    '        Dim iMaxWidth As Integer = 200

    '        Dim dBearingLeft As Decimal
    '        Dim dBearingRight As Decimal

    '        If FromOrTo = GetDesignStationEnum.From Then
    '            dBearingLeft = SegmentData.FromBearingLeft
    '            dBearingRight = SegmentData.FromBearingRight
    '        Else
    '            dBearingLeft = SegmentData.ToBearingLeft
    '            dBearingRight = SegmentData.ToBearingRight
    '        End If

    '        ' Dim sBearing As Single = SegmentData.Bearing
    '        Dim oBasePointF As PointF = PointF.Add(GenericPoint, Cache.Traslation)
    '        oBasePointF.X = oBasePointF.X * Cache.Scale
    '        oBasePointF.Y = oBasePointF.Y * Cache.Scale

    '        Dim oPoint As Point
    '        Dim oColor As Color
    '        Dim iD As Integer

    '        iD = 0
    '        Dim sLeft As Single = 0
    '        Do
    '            Dim oDiff As SizeF = modPaint.Trigo(iD, dBearingLeft)
    '            oPoint = Point.Truncate(PointF.Add(oBasePointF, oDiff))
    '            If Cache.Contains(oPoint) Then
    '                oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '                sLeft = Math.Abs(iD / Cache.Scale)
    '            End If
    '            iD += 1
    '        Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sLeft < iMaxWidth)
    '        If (sLeft >= iMaxWidth) Then
    '            sLeft = 0
    '        End If

    '        iD = 0
    '        Dim sRight As Single = 0
    '        Do
    '            Dim oDiff As SizeF = modPaint.Trigo(iD, dBearingRight)
    '            oPoint = Point.Truncate(PointF.Add(oBasePointF, oDiff))
    '            If Cache.Contains(oPoint) Then
    '                oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '                sRight = Math.Abs(iD / Cache.Scale)
    '            End If
    '            iD += 1
    '        Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sRight < iMaxWidth)
    '        If (sRight >= iMaxWidth) Then
    '            sRight = 0
    '        End If

    '        Return New SizeF(sLeft, sRight)
    '    End If
    'End Function

    'Public Function GetLRFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '    Dim oSurvey As cSurvey.cSurvey = Segment.Survey
    '    Dim oCache As cLRFromDesignCache = New cLRFromDesignCache(oSurvey, oSurvey.Plan, PaintOptions)
    '    Return GetLRFromDesign(oSurvey, oCache, Segment, Segment.Data.Plan, GenericPoint, FromOrTo)
    'End Function

    '    Friend Class cUDFromDesignCache
    '        Implements IDisposable

    '        Private oSurvey As cSurvey.cSurvey
    '        Private oPaintOptions As cOptions

    '        Private oImage As Bitmap
    '        Private oImageBounds As Rectangle
    '        Private oGraphics As Graphics
    '        Private oClippingRegions As cClippingRegions

    '        Private oTraslation As SizeF
    '        Private sScale As Single

    '        Private bIsEmpty As Boolean

    '        Public ReadOnly Property Traslation As SizeF
    '            Get
    '                Return oTraslation
    '            End Get
    '        End Property

    '        Public ReadOnly Property Scale As Single
    '            Get
    '                Return sScale
    '            End Get
    '        End Property

    '        Public Function Contains(X As Single, Y As Single) As Boolean
    '            Return oImageBounds.Contains(X, Y)
    '        End Function

    '        Public Function Contains(Point As PointF) As Boolean
    '            Return Contains(Point.X, Point.Y)
    '        End Function

    '        Public Sub SetPixel(X As Single, Y As Single, Color As Color)
    '            If oImageBounds.Contains(X, Y) Then
    '                Call oImage.SetPixel(X, Y, Color)
    '            End If
    '        End Sub

    '        Public Sub SetPixel(Point As PointF, Color As Color)
    '            Call SetPixel(Point.X, Point.Y, Color)
    '        End Sub

    '        Public Function GetPixel(X As Single, Y As Single) As Color
    '            If oImageBounds.Contains(X, Y) Then
    '                Return oImage.GetPixel(X, Y)
    '            Else
    '                Return Color.White
    '            End If
    '        End Function

    '        Public Function GetPixel(Point As PointF) As Color
    '            Return GetPixel(Point.X, Point.Y)
    '        End Function

    '        Public ReadOnly Property Image As Bitmap
    '            Get
    '                Return oImage
    '            End Get
    '        End Property

    '        Public Sub PrepareImage(CaveAndBraches As Dictionary(Of String, modCaveAndBranch.cCaveBranchPlaceholder))
    '            If Not bIsEmpty Then
    '                Call oGraphics.Clear(Color.White)
    '                Dim bDone As Boolean
    '                For Each oCaveBranchPlaceholder As cCaveBranchPlaceholder In CaveAndBraches.Values
    '                    bDone = False
    '                    Dim sCave As String = oCaveBranchPlaceholder.Cave
    '                    Dim sBranch As String = oCaveBranchPlaceholder.Branch
    '                    Do
    '                        Dim oRegion As Region = oClippingRegions(oCaveBranchPlaceholder.Cave, sBranch)
    '                        If Not oRegion Is Nothing Then
    '                            If Not oRegion.IsEmpty(oGraphics) Then
    '                                Call oGraphics.FillRegion(Brushes.Black, oRegion)
    '                                bDone = True
    '                            End If
    '                        End If
    '                        If sBranch = "" Then
    '                            bDone = True
    '                        Else
    '                            If Not bDone Then
    '                                Dim oBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos(sCave).Branches(sBranch)
    '                                If IsNothing(oBranch) Then
    '                                    sBranch = ""
    '                                Else
    '                                    If IsNothing(oBranch.Parent) Then
    '                                        sBranch = ""
    '                                    Else
    '                                        sBranch = oBranch.Parent.Path
    '                                    End If
    '                                End If
    '                            End If
    '                        End If
    '                    Loop Until bDone
    '                Next
    '            End If
    '        End Sub

    '        Public ReadOnly Property PaintOptions As cOptions
    '            Get
    '                Return oPaintOptions
    '            End Get
    '        End Property

    '        Public ReadOnly Property IsEmpty As Boolean
    '            Get
    '                Return bIsEmpty
    '            End Get
    '        End Property

    '        Public Sub New(Survey As cSurvey.cSurvey, Profile As cDesignProfile, PaintOptions As cOptions, Optional MaxSize As Integer = 2000)
    '            oSurvey = Survey
    '            oPaintOptions = PaintOptions

    '            Dim oRealBounds As RectangleF = Profile.GetBounds(PaintOptions)
    '            If modPaint.IsRectangleEmpty(oRealBounds) Then
    '                bIsEmpty = True
    '            Else
    '                'sScale = 1
    '                If oRealBounds.Width > oRealBounds.Height Then
    '                    sScale = MaxSize / oRealBounds.Width
    '                Else
    '                    sScale = MaxSize / oRealBounds.Height
    '                End If
    '                oTraslation = New SizeF(-1 * oRealBounds.X, -1 * oRealBounds.Y)

    '                oImageBounds = New Rectangle(0, 0, oRealBounds.Width * sScale, oRealBounds.Height * sScale)
    '                oImage = New Bitmap(oImageBounds.Width, oImageBounds.Height)

    '                Using oMatrix As Matrix = New Matrix
    '                    Call oMatrix.Translate(oTraslation.Width, oTraslation.Height, MatrixOrder.Append)
    '                    Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
    '                    oGraphics = Graphics.FromImage(oImage)
    '                    oGraphics.Transform = oMatrix

    '                    Dim oPaintOptions As cOptions = oSurvey.Options("_design.profile").DefaultOptions
    '                    oClippingRegions = Profile.GetCaveClippingRegions(oGraphics, oPaintOptions)
    '                End Using
    '            End If
    '        End Sub

    '#Region "IDisposable Support"
    '        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

    '        ' IDisposable
    '        Protected Overridable Sub Dispose(disposing As Boolean)
    '            If Not Me.disposedValue Then
    '                If disposing Then
    '                    ' TODO: eliminare stato gestito (oggetti gestiti).
    '                    Call oClippingRegions.Dispose()
    '                    Call oGraphics.Dispose()
    '                    Call oImage.Dispose()
    '                End If
    '            End If
    '            Me.disposedValue = True
    '        End Sub

    '        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
    '        Public Sub Dispose() Implements IDisposable.Dispose
    '            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
    '            Dispose(True)
    '            GC.SuppressFinalize(Me)
    '        End Sub
    '#End Region

    '    End Class

    '    Public Function GetUDFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
    '        Dim oPoint As PointF
    '        If FromOrTo = GetDesignStationEnum.From Then
    '            oPoint = Segment.Data.Profile.FromPoint
    '        Else
    '            oPoint = Segment.Data.Profile.ToPoint
    '        End If
    '        Return GetUDFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    '    End Function

    '    Friend Function GetUDFromDesign(Survey As cSurvey.cSurvey, Cache As cUDFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cIProfileProjectedData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '        If Cache.IsEmpty Then
    '            Return New SizeF(0, 0)
    '        Else
    '            Call Cache.PrepareImage(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

    '            Dim iMaxWidth As Integer = 200

    '            Dim oBasePointF As PointF = PointF.Add(GenericPoint, Cache.Traslation)
    '            oBasePointF.X = oBasePointF.X * Cache.Scale
    '            oBasePointF.Y = oBasePointF.Y * Cache.Scale

    '            Dim oPoint As Point
    '            Dim oColor As Color
    '            Dim iD As Integer = 0

    '            Dim sUp As Single = 0
    '            Do
    '                oPoint = Point.Truncate(New PointF(oBasePointF.X, oBasePointF.Y + iD))
    '                If Cache.Contains(oPoint) Then
    '                    oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '                    sUp = Math.Abs(iD / Cache.Scale)
    '                End If
    '                iD -= 1
    '            Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sUp < iMaxWidth)
    '            If (sUp >= iMaxWidth) Then
    '                sUp = 0
    '            End If

    '            iD = 0
    '            Dim sDown As Single = 0
    '            Do
    '                oPoint = Point.Truncate(New PointF(oBasePointF.X, oBasePointF.Y + iD))
    '                If Cache.Contains(oPoint) Then
    '                    oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '                    sDown = Math.Abs(iD / Cache.Scale)
    '                End If
    '                iD += 1
    '            Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sDown < iMaxWidth)
    '            If (sDown >= iMaxWidth) Then
    '                sDown = 0
    '            End If

    '            Return New SizeF(sUp, sDown)
    '        End If
    '    End Function

    '    Public Function GetUDFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
    '        Dim oCache As cUDFromDesignCache = New cUDFromDesignCache(oSurvey, oSurvey.Profile, PaintOptions)
    '        Return GetUDFromDesign(oSurvey, oCache, Segment, Segment.Data.Profile, GenericPoint, FromOrTo)
    '    End Function

    '    Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, FromOrTo As GetDesignStationEnum) As SizeF
    '        Dim oPoint As PointF
    '        If FromOrTo = GetDesignStationEnum.From Then
    '            oPoint = Segment.Data.Profile.FromPoint
    '        Else
    '            oPoint = Segment.Data.Profile.ToPoint
    '        End If
    '        Return GetFBFromDesign(PaintOptions, Segment, oPoint, FromOrTo)
    '    End Function

    '    Friend Function GetFBFromDesign(Survey As cSurvey.cSurvey, Cache As cUDFromDesignCache, Segment As cSegment, SegmentData As cSurveyPC.cSurvey.Calculate.Plot.cISpatialData, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '        Call Cache.PrepareImage(GetCaveAndBranchList(Survey, Segment, SegmentData, FromOrTo))

    '        Dim iMaxWidth As Integer = 200

    '        Dim oBasePointF As PointF = PointF.Add(GenericPoint, Cache.Traslation)
    '        oBasePointF.X = oBasePointF.X * Cache.Scale
    '        oBasePointF.Y = oBasePointF.Y * Cache.Scale

    '        Dim oPoint As Point
    '        Dim oColor As Color
    '        Dim iD As Integer

    '        iD = 0
    '        Dim sUp As Single = 0
    '        Do
    '            oPoint = Point.Truncate(New PointF(oBasePointF.X + iD, oBasePointF.Y))
    '            If Cache.Contains(oPoint) Then
    '                oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '                sUp = Math.Abs(iD / Cache.Scale)
    '            End If
    '            iD -= 1
    '        Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sUp < iMaxWidth)
    '        If (sUp >= iMaxWidth) Then
    '            sUp = 0
    '        End If

    '        iD = 0
    '        Dim sDown As Single = 0
    '        Do
    '            oPoint = Point.Truncate(New PointF(oBasePointF.X + iD, oBasePointF.Y))
    '            If Cache.Contains(oPoint) Then
    '                oColor = Cache.GetPixel(oPoint.X, oPoint.Y)
    '                sDown = Math.Abs(iD / Cache.Scale)
    '            End If
    '            iD += 1
    '        Loop While oColor.R = 0 And Cache.Contains(oPoint) And (sDown < iMaxWidth)
    '        If (sDown >= iMaxWidth) Then
    '            sDown = 0
    '        End If

    '        Return New SizeF(sUp, sDown)
    '    End Function

    '    Public Function GetFBFromDesign(PaintOptions As cOptions, Segment As cSegment, GenericPoint As PointF, FromOrTo As GetDesignStationEnum) As SizeF
    '        Dim oSurvey As cSurvey.cSurvey = Segment.Survey
    '        Dim oCache As cUDFromDesignCache = New cUDFromDesignCache(oSurvey, oSurvey.Profile, PaintOptions)
    '        Return GetFBFromDesign(oSurvey, oCache, Segment, Segment.Data.Data, GenericPoint, FromOrTo)
    '    End Function

    '#End Region

End Module
