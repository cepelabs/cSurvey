Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Clipping
    Public Class cClippingClipperPaths
        Private oSurvey As cSurvey
        Private oClipper As Clipper


        Private oAddPaths As Dictionary(Of String, List(Of List(Of IntPoint)))
        Private oSubtractPaths As Dictionary(Of String, List(Of List(Of IntPoint)))

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oClipper = New Clipper
            oAddPaths = New Dictionary(Of String, List(Of List(Of IntPoint)))(System.StringComparer.OrdinalIgnoreCase)
            oSubtractPaths = New Dictionary(Of String, List(Of List(Of IntPoint)))(System.StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Sub Clear()
            Call oAddPaths.Clear()
            Call oSubtractPaths.Clear()
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Path As List(Of List(Of IntPoint)))
            Dim sKey As String = Cave & "/" & Branch
            If oAddPaths.ContainsKey(sKey) Then
                Dim oCurrentPath As List(Of List(Of IntPoint)) = oAddPaths(sKey)
                oClipper.AddPolygons(oCurrentPath, PolyType.ptSubject)
                oClipper.AddPolygons(Path, PolyType.ptClip)
                Dim oResultPath As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                oClipper.Execute(ClipType.ctUnion, oResultPath)
                oAddPaths.Remove(sKey)
                oAddPaths.Add(sKey, oResultPath)
            Else
                Call oAddPaths.Add(sKey, Path)
            End If
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oPath As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(Path)
            If oAddPaths.ContainsKey(sKey) Then
                Dim oCurrentPath As List(Of List(Of IntPoint)) = oAddPaths(sKey)
                oClipper.AddPolygons(oCurrentPath, PolyType.ptSubject)
                oClipper.AddPolygons(oPath, PolyType.ptClip)
                Dim oResultPath As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                oClipper.Execute(ClipType.ctUnion, oResultPath)
                oAddPaths.Remove(sKey)
                oAddPaths.Add(sKey, oResultPath)
            Else
                Call oAddPaths.Add(sKey, oPath)
            End If
        End Sub

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Path As List(Of List(Of IntPoint)))
            Dim sKey As String = Cave & "/" & Branch
            If oSubtractPaths.ContainsKey(sKey) Then
                Dim oCurrentPath As List(Of List(Of IntPoint)) = oSubtractPaths(sKey)
                oClipper.AddPolygons(oCurrentPath, PolyType.ptSubject)
                oClipper.AddPolygons(Path, PolyType.ptClip)
                Dim oResultPath As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                oClipper.Execute(ClipType.ctUnion, oResultPath)
                oSubtractPaths.Remove(sKey)
                oSubtractPaths.Add(sKey, oResultPath)
            Else
                Call oSubtractPaths.Add(sKey, Path)
            End If
        End Sub

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oPath As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(Path)
            If oSubtractPaths.ContainsKey(sKey) Then
                Dim oCurrentPath As List(Of List(Of IntPoint)) = oSubtractPaths(sKey)
                oClipper.AddPolygons(oCurrentPath, PolyType.ptSubject)
                oClipper.AddPolygons(oPath, PolyType.ptClip)
                Dim oResultPath As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                oClipper.Execute(ClipType.ctUnion, oResultPath)
                oSubtractPaths.Remove(sKey)
                oSubtractPaths.Add(sKey, oResultPath)
            Else
                Call oSubtractPaths.Add(sKey, oPath)
            End If
        End Sub

        Friend Function GetAddClip(ByVal Layer As cLayer, ByVal Cave As String, ByVal Branch As String) As List(Of List(Of IntPoint))
            Dim sKey As String = Cave & "/" & Branch
            sKey = sKey.ToLower
            If oAddPaths.ContainsKey(sKey) Then
                Dim oClip As List(Of List(Of IntPoint)) = oAddPaths(sKey)
                If oClip.Count = 0 Then
                    Return Nothing
                Else
                    Return oClip
                End If
            Else
                Return Nothing
            End If
        End Function

        Friend Function GetSubtractClip(ByVal Layer As cLayer, ByVal Cave As String, ByVal Branch As String) As List(Of List(Of IntPoint))
            Dim sKey As String = Cave & "/" & Branch
            sKey = sKey.ToLower
            If oSubtractPaths.ContainsKey(sKey) Then
                Dim oClip As List(Of List(Of IntPoint)) = oSubtractPaths(sKey)
                If oClip.Count = 0 Then
                    Return Nothing
                Else
                    Return oClip
                End If
            Else
                Return Nothing
            End If
        End Function
    End Class

    Public Class cClippingPaths
        Implements IDisposable
        'Implements IEnumerable

        Private oSurvey As cSurvey

        Public Enum ClipBorderEnum
            DontClipBorder = 0
            ClipBorder = 1
            Disable = 2
        End Enum

        Private iClipBorder As ClipBorderEnum

        Private oPaths As Dictionary(Of String, GraphicsPath)

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            iClipBorder = oSurvey.Properties.DesignProperties.GetValue("ClipBorder", My.Application.Settings.GetSetting("design.clipborder", ClipBorderEnum.ClipBorder))
            oPaths = New Dictionary(Of String, GraphicsPath)(System.StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Sub Clear()
            Call oPaths.Clear()
        End Sub

        'Public ReadOnly Property Count As Integer
        '    Get
        '        Return oPaths.Count
        '    End Get
        'End Property

        Friend Function GetClip(ByVal Graphics As Graphics, ByVal Layer As cLayer, ByVal Cave As String, ByVal Branch As String) As GraphicsPath
            If iClipBorder = ClipBorderEnum.Disable Then
                Return Nothing
            Else
                If Layer.Type >= cLayers.LayerTypeEnum.Borders Then
                    Return Nothing
                Else
                    Dim sKey As String = Cave & "/" & Branch
                    sKey = sKey.ToLower
                    If oPaths.ContainsKey(sKey) Then
                        Dim oClip As GraphicsPath = oPaths(sKey)
                        If oClip.PointCount = 0 Then
                            Return Nothing
                        Else
                            Return oClip
                        End If
                    Else
                        Return Nothing
                    End If
                End If
            End If
        End Function

        'Public Function Contains(ByVal Cave As String, ByVal Branch As String) As Boolean
        '    Dim sKey As String = Cave & "/" & Branch
        '    Return oPaths.ContainsKey(sKey)
        'End Function

        Default ReadOnly Property Item(ByVal Cave As String, ByVal Branch As String) As GraphicsPath
            Get
                Dim sKey As String = Cave & "/" & Branch
                If oPaths.ContainsKey(sKey) Then
                    Return oPaths(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            If oPaths.ContainsKey(sKey) Then
                Dim oCurrentGraphicsPath As GraphicsPath = oPaths(sKey)
                oCurrentGraphicsPath.AddPath(Path, False)
            End If
        End Sub

        Public Sub Intersect(Cave As String, Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentGraphicsPath As GraphicsPath
            If oPaths.ContainsKey(sKey) Then
                oCurrentGraphicsPath = oPaths(sKey)
                oCurrentGraphicsPath.AddPath(Path, False)
            Else
                oCurrentGraphicsPath = Path.Clone
                Call oPaths.Add(sKey, oCurrentGraphicsPath)
            End If
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentGraphicsPath As GraphicsPath
            If oPaths.ContainsKey(sKey) Then
                oCurrentGraphicsPath = oPaths(sKey)
                oCurrentGraphicsPath.AddPath(Path, False)
            Else
                oCurrentGraphicsPath = Path.Clone
                Call oPaths.Add(sKey, oCurrentGraphicsPath)
            End If
        End Sub

        'Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        '    Return oPaths.Values.GetEnumerator
        'End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    For Each oGraphicsPath As GraphicsPath In oPaths.Values
                        Call oGraphicsPath.Dispose()
                    Next
                    Call oPaths.Clear()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Call Dispose(True)
            Call GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class cClippingRegions
        Implements IDisposable
        'Implements IEnumerable

        Private oSurvey As cSurvey

        Public Enum ClipSoilEnum
            [DefaultOutsideBorder] = 0
            InsideBorder = 1
        End Enum

        Public Enum ClipBorderEnum
            DontClipBorder = 0
            ClipBorder = 1
            Disable = 2
        End Enum

        Private iClipSoil As ClipSoilEnum

        Private iClipBorder As ClipBorderEnum

        Private oRegions As Dictionary(Of String, Region)
        Private oInfiniteRegion As Region

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            iClipBorder = oSurvey.Properties.DesignProperties.GetValue("clipborder", My.Application.Settings.GetSetting("design.clipborder", ClipBorderEnum.ClipBorder))
            iClipSoil = oSurvey.Properties.DesignProperties.GetValue("clipsoil", My.Application.Settings.GetSetting("design.clipsoil", ClipSoilEnum.DefaultOutsideBorder))
            oRegions = New Dictionary(Of String, Region)(System.StringComparer.OrdinalIgnoreCase)
            oInfiniteRegion = New Region
            Call oInfiniteRegion.MakeInfinite()
        End Sub

        Public Sub Clear()
            Call oRegions.Clear()
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oRegions.Count
            End Get
        End Property

        Friend Function GetClip(ByVal Graphics As Graphics, ByVal Layer As cLayer, ByVal Item As cItem) As Region
            If iClipBorder = ClipBorderEnum.Disable Then
                Return oInfiniteRegion
            Else
                If Item.ClippingType = cItem.cItemClippingTypeEnum.Default Then
                    If (Item.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea AndAlso Layer.Type = cLayers.LayerTypeEnum.Borders) OrElse (Layer.Type > cLayers.LayerTypeEnum.Borders) OrElse (iClipBorder = ClipBorderEnum.DontClipBorder AndAlso Layer.Type = cLayers.LayerTypeEnum.Borders) Then
                        Return oInfiniteRegion
                    Else
                        Dim sKey As String = Item.Cave & "/" & Item.Branch
                        If oRegions.ContainsKey(sKey) Then
                            Dim oClip As Region = oRegions(sKey)
                            If oClip.IsEmpty(Graphics) Then
                                Return oInfiniteRegion
                            Else
                                If Item.Type = cIItem.cItemTypeEnum.FreeHandArea AndAlso Item.Category = cIItem.cItemCategoryEnum.Soil AndAlso Item.Design.Type = cIDesign.cDesignTypeEnum.Profile AndAlso iClipSoil = ClipSoilEnum.DefaultOutsideBorder Then
                                    Dim oInvertedClip As Region = oInfiniteRegion.Clone
                                    Call oInvertedClip.Exclude(oClip)
                                    Return oInvertedClip
                                Else
                                    Return oClip
                                End If
                            End If
                        Else
                            Return oInfiniteRegion
                        End If
                    End If
                Else
                    Select Case Item.ClippingType
                        Case cItem.cItemClippingTypeEnum.None
                            'senza clipping restituisco sempre TUTTO
                            Return oInfiniteRegion
                        Case cItem.cItemClippingTypeEnum.InsideBorder
                            Dim sKey As String = Item.Cave & "/" & Item.Branch
                            sKey = sKey.ToLower
                            If oRegions.ContainsKey(sKey) Then
                                Dim oClip As Region = oRegions(sKey)
                                If oClip.IsEmpty(Graphics) Then
                                    'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                    Return oInfiniteRegion
                                Else
                                    'restituisco l'area della grotta/ramo a cui l'oggetto appartiene
                                    Return oClip
                                End If
                            Else
                                'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                Return oInfiniteRegion
                            End If
                        Case cItem.cItemClippingTypeEnum.OutsideBorder
                            Dim sKey As String = Item.Cave & "/" & Item.Branch
                            sKey = sKey.ToLower
                            If oRegions.ContainsKey(sKey) Then
                                Dim oClip As Region = oRegions(sKey)
                                If oClip.IsEmpty(Graphics) Then
                                    'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                    Return oInfiniteRegion
                                Else
                                    Dim oInvertedClip As Region = oInfiniteRegion.Clone
                                    Call oInvertedClip.Exclude(oClip)
                                    Return oInvertedClip
                                End If
                            Else
                                'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                Return oInfiniteRegion
                            End If
                    End Select
                End If
            End If
        End Function

        Friend Function GetClip(ByVal Graphics As Graphics, ByVal Layer As cLayer, ByVal Cave As String, ByVal Branch As String) As Region
            If iClipBorder = ClipBorderEnum.Disable Then
                Return oInfiniteRegion
            Else
                If Layer.Type >= cLayers.LayerTypeEnum.Borders Then
                    Return oInfiniteRegion
                Else
                    Dim sKey As String = Cave & "/" & Branch
                    If oRegions.ContainsKey(sKey) Then
                        Dim oClip As Region = oRegions(sKey)
                        If oClip.IsEmpty(Graphics) Then
                            Return oInfiniteRegion
                        Else
                            Return oClip
                        End If
                    Else
                        Return oInfiniteRegion
                    End If
                End If
            End If
        End Function

        Public Function Contains(ByVal Cave As String, ByVal Branch As String) As Boolean
            Dim sKey As String = Cave & "/" & Branch
            Return oRegions.ContainsKey(sKey)
        End Function

        Default ReadOnly Property Item(ByVal Cave As String, ByVal Branch As String) As Region
            Get
                Dim sKey As String = Cave & "/" & Branch
                If oRegions.ContainsKey(sKey) Then
                    Return oRegions(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            If oRegions.ContainsKey(sKey) Then
                Dim oCurrentRegion As Region = oRegions(sKey)
                Call oCurrentRegion.Exclude(Path)
            End If
        End Sub

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Region As Region)
            Dim sKey As String = Cave & "/" & Branch
            If oRegions.ContainsKey(sKey) Then
                Dim oCurrentRegion As Region = oRegions(sKey)
                Call oCurrentRegion.Exclude(Region)
            End If
        End Sub

        Public Sub Intersect(Cave As String, Branch As String, ByVal Region As Region)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Intersect(Region)
        End Sub

        Public Sub Intersect(Cave As String, Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Intersect(Path)
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Union(Path)
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Region As Region)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Union(Region)
        End Sub

        'Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        '    Return oRegions.Values.GetEnumerator
        'End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    For Each oRegion As Region In oRegions.Values
                        Call oRegion.Dispose()
                    Next
                    Call oRegions.Clear()
                    Call oInfiniteRegion.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Call Dispose(True)
            Call GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace