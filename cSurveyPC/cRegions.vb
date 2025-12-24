Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports ClipperLib
Imports ImageProcessor.Processors

Namespace cSurvey.Drawings.Regions

    Public Class cGDIRegion
        Implements IDisposable
        Implements cIRegion

        Private oBaseRegion As Region

        Public Sub New(Path As GraphicsPath)
            oBaseRegion = New Region(Path)
        End Sub

        Public Function Contains(Graphics As Graphics, Path As GraphicsPath) As Boolean Implements cIRegion.Contains
            Using oRegion As Region = oBaseRegion.Clone()
                Call oRegion.Complement(Path)
                Return oRegion.IsEmpty(Graphics)
            End Using
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Call oBaseRegion.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class cClipperRegion
        Implements IDisposable
        Implements cIRegion

        Private oClipper As Clipper
        'Private oBaseMatrix As Matrix
        Private sScale As Single
        Private sAccurancy As Single
        Private oBaseIntPaths As List(Of List(Of IntPoint))

        Private oBaseBoundingBox As RectangleF

        Public ReadOnly Property Scale As Single
            Get
                Return sScale
            End Get
        End Property

        Public ReadOnly Property Accurancy As Single
            Get
                Return sAccurancy
            End Get
        End Property

        Public Function GetPath() As GraphicsPath
            Return cClipperHelper.IntPathsToGraphicsPath(oBaseIntPaths, sScale)
        End Function

        Public ReadOnly Property IntPaths As List(Of List(Of IntPoint))
            Get
                Return oBaseIntPaths
            End Get
        End Property

        Public Sub New(Path As GraphicsPath, Optional Scale As Single = 1000.0F, Optional Accurancy As Single = 0.1F)
            oClipper = New Clipper
            'oBaseMatrix = New Matrix
            sScale = Scale
            sAccurancy = Accurancy
            'Call oBaseMatrix.Scale(sScale, sScale)
            Using oBasePath As GraphicsPath = Path.Clone
                'Call oBasePath.Flatten(oBaseMatrix, sAccurancy)
                oBaseBoundingBox = oBasePath.GetBounds()
                oBaseIntPaths = cClipperHelper.GraphicsPathToIntPaths(oBasePath, sScale, sAccurancy)
            End Using
        End Sub

        Public Function Union(Graphics As Graphics, Path As GraphicsPath) As Boolean
            Using oPath As GraphicsPath = Path.Clone
                'Call oPath.Flatten(oBaseMatrix, sAccurancy)
                Dim oIntPaths As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(oPath, sScale, sAccurancy)
                Call oClipper.Clear()
                Call oClipper.AddPolygons(oBaseIntPaths, PolyType.ptClip)
                Call oClipper.AddPolygons(oIntPaths, PolyType.ptSubject)
                Dim oResultPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                Dim bSuccess As Boolean = oClipper.Execute(ClipType.ctUnion, oResultPaths, PolyFillType.pftNonZero, PolyFillType.pftNonZero)
                If bSuccess Then
                    oBaseIntPaths = oResultPaths
                End If
                Return bSuccess
            End Using
        End Function

        Public Function Contains(Graphics As Graphics, Path As GraphicsPath) As Boolean Implements cIRegion.Contains
            Dim oPathBoundingBox As RectangleF = Path.GetBounds()
            If oPathBoundingBox.IntersectsWith(oBaseBoundingBox) Then
                Dim oIntPaths As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(Path, sScale, sAccurancy)
                Return IsCompletelyInside(oIntPaths, oBaseIntPaths)
                'Call oClipper.Clear()
                'Call oClipper.AddPolygons(oBaseIntPaths, PolyType.ptClip)
                'Call oClipper.AddPolygons(oIntPaths, PolyType.ptSubject)
                'Dim oResultPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                'Dim bSuccess As Boolean = oClipper.Execute(ClipType.ctDifference, oResultPaths)
                'Return bSuccess AndAlso oResultPaths.Count = 0
            Else
                Return False
            End If
        End Function

        Public Shared Function PointInPolygon(pt As IntPoint, poly As List(Of IntPoint)) As Integer
            ' Restituisce:
            '  0 → sul bordo
            '  1 → dentro
            ' -1 → fuori

            Dim result As Integer = 0
            Dim cnt As Integer = poly.Count
            Dim j As Integer = cnt - 1

            For i As Integer = 0 To cnt - 1
                Dim pi = poly(i)
                Dim pj = poly(j)

                ' Punto esattamente su un vertice
                If (pi.X = pt.X AndAlso pi.Y = pt.Y) Then
                    Return 0
                End If

                ' Test segmenti che intersecano la linea orizzontale
                Dim cond1 = (pi.Y > pt.Y) <> (pj.Y > pt.Y)
                If cond1 Then
                    Dim xIntersect As Long = pj.X + (pt.Y - pj.Y) * (pi.X - pj.X) / (pi.Y - pj.Y)

                    If xIntersect = pt.X Then
                        Return 0 ' punto sul bordo
                    End If

                    If xIntersect > pt.X Then
                        result = 1 - result
                    End If
                End If

                j = i
            Next

            If result <> 0 Then Return 1 Else Return -1
        End Function


        ' --- Funzione principale: verifica contenimento totale ---
        Public Shared Function IsCompletelyInside(
        subject As List(Of List(Of IntPoint)),
        container As List(Of List(Of IntPoint))
    ) As Boolean

            ' Usa il primo poligono come contenitore (tipico per GraphicPath)
            Dim cont As List(Of IntPoint) = container(0)

            ' Pre-compute bounding box del contenitore
            Dim minX = Long.MaxValue, minY = Long.MaxValue
            Dim maxX = Long.MinValue, maxY = Long.MinValue

            For Each p In cont
                If p.X < minX Then minX = p.X
                If p.X > maxX Then maxX = p.X
                If p.Y < minY Then minY = p.Y
                If p.Y > maxY Then maxY = p.Y
            Next

            ' --- TEST RAPIDO: se un singolo punto è fuori dalla BB → non contenuto ---
            For Each subPoly In subject
                For Each p In subPoly
                    If p.X < minX OrElse p.X > maxX OrElse p.Y < minY OrElse p.Y > maxY Then
                        Return False
                    End If
                Next
            Next

            ' --- TEST PUNTO-IN-POLIGONO completo ---
            For Each subPoly In subject
                For Each p In subPoly
                    Dim r = PointInPolygon(p, cont)
                    If r < 0 Then
                        Return False ' almeno un punto fuori
                    End If
                Next
            Next

            Return True
        End Function

        'Public Function Contains2(Graphics As Graphics, Path As GraphicsPath, ByRef ResultPath As GraphicsPath) As Boolean
        '    Dim oPathBoundingBox As RectangleF = Path.GetBounds()
        '    If oPathBoundingBox.IntersectsWith(oBaseBoundingBox) Then
        '        Dim oIntPaths As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(Path, sScale, sAccurancy)
        '        ResultPath = cClipperHelper.IntPathsToGraphicsPath(oIntPaths, sScale)
        '        Call oClipper.Clear()
        '        Return IsCompletelyInside(oIntPaths, oBaseIntPaths)
        '        Call oClipper.AddPolygons(oBaseIntPaths, PolyType.ptClip)
        '        Call oClipper.AddPolygons(oIntPaths, PolyType.ptSubject)
        '        Dim oResultPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        '        Dim bSuccess As Boolean = oClipper.Execute(ClipType.ctDifference, oResultPaths)
        '        Return bSuccess AndAlso oResultPaths.Count = 0
        '    Else
        '        Return False
        '    End If
        'End Function

        Public Function Intersect(Graphics As Graphics, Path As GraphicsPath) As Boolean
            Dim oIntPaths As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(Path, sScale, sAccurancy)
            Call oClipper.Clear()
            Call oClipper.AddPolygons(oBaseIntPaths, PolyType.ptClip)
            Call oClipper.AddPolygons(oIntPaths, PolyType.ptSubject)
            Dim oResultPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
            Dim bSuccess As Boolean = oClipper.Execute(ClipType.ctIntersection, oResultPaths, PolyFillType.pftNonZero, PolyFillType.pftNonZero)
            Return bSuccess AndAlso oResultPaths.Count > 0
            'End Using
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                'If disposing Then
                '    Call oBaseMatrix.Dispose()
                'End If
                'oBaseMatrix = Nothing
                oBaseIntPaths = Nothing
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace