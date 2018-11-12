Imports System.Drawing.Drawing2D

Namespace cSurvey.Drawings
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
End Namespace