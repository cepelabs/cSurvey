Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ClipperLib
Imports System.Runtime.CompilerServices

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
        Private oBaseMatrix As Matrix
        Private sScale As Single
        Private sAccurancy As Single
        Private oBaseIntPaths As List(Of List(Of IntPoint))

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

        Public ReadOnly Property IntPaths As List(Of List(Of IntPoint))
            Get
                Return oBaseIntPaths
            End Get
        End Property

        Public Sub New(Path As GraphicsPath, Optional Scale As Single = 1, Optional Accurancy As Single = 1)
            oClipper = New Clipper
            oBaseMatrix = New Matrix
            sScale = Scale
            sAccurancy = Accurancy
            Call oBaseMatrix.Scale(sScale, sScale)
            Using oBasePath As GraphicsPath = Path.Clone
                Call oBasePath.Flatten(oBaseMatrix, sAccurancy)
                oBaseIntPaths = cClipperHelper.GraphicsPathToIntPaths(oBasePath)
            End Using
        End Sub

        Public Function Contains(Graphics As Graphics, Path As GraphicsPath) As Boolean Implements cIRegion.Contains
            Using oPath As GraphicsPath = Path.Clone
                Call oPath.Flatten(oBaseMatrix, sAccurancy)
                Dim oIntPaths As List(Of List(Of IntPoint)) = cClipperHelper.GraphicsPathToIntPaths(oPath)
                Call oClipper.Clear()
                Call oClipper.AddPolygons(oBaseIntPaths, PolyType.ptClip)
                Call oClipper.AddPolygons(oIntPaths, PolyType.ptSubject)
                Dim oResultPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
                Call oClipper.Execute(ClipType.ctDifference, oResultPaths)
                Return oResultPaths.Count = 0
            End Using
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Call oBaseMatrix.Dispose()
                End If
                oBaseMatrix = Nothing
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