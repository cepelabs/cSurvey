Imports System.Windows.Forms

Public Class cMousePointer
    Private oCurrentMousePointer As Cursor
    Private oMouseStack As Stack(Of Cursor)

    Public Sub New()
        oMouseStack = New Stack(Of Cursor)
        oCurrentMousePointer = Cursors.Default
    End Sub

    Public Sub Pop()
        Try
            Try
                oCurrentMousePointer = oMouseStack.Pop()
            Catch
                oCurrentMousePointer = Cursors.Default
            End Try
            Cursor.Current = oCurrentMousePointer
        Catch
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub Push(ByVal MousePointer As Cursor)
        Call oMouseStack.Push(oCurrentMousePointer)
        oCurrentMousePointer = MousePointer
        Cursor.Current = oCurrentMousePointer
    End Sub

    Public ReadOnly Property Value() As Cursor
        Get
            Return oCurrentMousePointer
        End Get
    End Property

    Public Sub Clear()
        Call oMouseStack.Clear()
        oCurrentMousePointer = Cursors.Default
        Cursor.Current = oCurrentMousePointer
    End Sub

End Class
