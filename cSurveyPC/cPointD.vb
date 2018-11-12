'implemento una struttura compatibile con point e pointF
'ma con tipo di dati decimal per aumentare la precisione del calcoli...o almeno quella è la mia speranza.

Public Structure PointD
    Public X As Decimal
    Public Y As Decimal

    Public Sub New(ByVal x As Decimal, ByVal y As Decimal)
        Me.X = x
        Me.Y = y
    End Sub

    Public Shared Widening Operator CType(ByVal p As PointF) As PointD
        Return New PointD(p.X, p.Y)
    End Operator

    Public Shared Widening Operator CType(ByVal p As Point) As PointD
        Return New PointD(p.X, p.Y)
    End Operator

    Public Shared Widening Operator CType(ByVal p As PointD) As System.Drawing.PointF
        Return New PointF(p.X, p.Y)
    End Operator

    Public Shared Widening Operator CType(ByVal p As PointD) As System.Drawing.Point
        Return New Point(p.X, p.Y)
    End Operator

    Public Shared Operator =(ByVal left As PointD, ByVal right As PointD) As Boolean
        Return (left.X = right.X) AndAlso (left.Y = right.Y)
    End Operator

    Public Shared Operator <>(ByVal left As PointD, ByVal right As PointD) As Boolean
        Return (left.X <> right.X) OrElse (left.Y <> right.Y)
    End Operator

    Public Shared Operator -(ByVal pt As PointD, ByVal sz As SizeD) As PointD
        pt.X = pt.X - sz.Width
        pt.Y = pt.Y - sz.Height
        Return pt
    End Operator

    Public Shared Operator -(ByVal pt As PointD, ByVal sz As System.Drawing.SizeF) As PointD
        pt.X = pt.X - sz.Width
        pt.Y = pt.Y - sz.Height
        Return pt
    End Operator

    Public Shared Operator -(ByVal pt As PointD, ByVal sz As System.Drawing.Size) As PointD
        pt.X = pt.X - sz.Width
        pt.Y = pt.Y - sz.Height
        Return pt
    End Operator

    Public Shared Operator +(ByVal pt As PointD, ByVal sz As SizeD) As PointD
        pt.X = pt.X + sz.Width
        pt.Y = pt.Y + sz.Height
        Return pt
    End Operator

    Public Shared Operator +(ByVal pt As PointD, ByVal sz As System.Drawing.SizeF) As PointD
        pt.X = pt.X + sz.Width
        pt.Y = pt.Y + sz.Height
        Return pt
    End Operator

    Public Shared Operator +(ByVal pt As PointD, ByVal sz As System.Drawing.Size) As PointD
        pt.X = pt.X + sz.Width
        pt.Y = pt.Y + sz.Height
        Return pt
    End Operator

    Public Shared Function Add(ByVal pt As PointD, ByVal sz As SizeD) As PointD
        pt.X = pt.X + sz.Width
        pt.Y = pt.Y + sz.Height
        Return pt
    End Function

    Public Shared Function Add(ByVal pt As PointD, ByVal sz As System.Drawing.SizeF) As PointD
        pt.X = pt.X + sz.Width
        pt.Y = pt.Y + sz.Height
        Return pt
    End Function

    Public Shared Function Add(ByVal pt As PointD, ByVal sz As System.Drawing.Size) As PointD
        pt.X = pt.X + sz.Width
        pt.Y = pt.Y + sz.Height
        Return pt
    End Function

    Public Shared Function Subtract(ByVal pt As PointD, ByVal sz As SizeD) As PointD
        pt.X = pt.X - sz.Width
        pt.Y = pt.Y - sz.Height
        Return pt
    End Function

    Public Shared Function Subtract(ByVal pt As PointD, ByVal sz As System.Drawing.SizeF) As PointD
        pt.X = pt.X - sz.Width
        pt.Y = pt.Y - sz.Height
        Return pt
    End Function

    Public Shared Function Subtract(ByVal pt As PointD, ByVal sz As System.Drawing.Size) As PointD
        pt.X = pt.X - sz.Width
        pt.Y = pt.Y - sz.Height
        Return pt
    End Function

    Public ReadOnly Property IsEmpty As Boolean
        Get
            Return X = 0 And Y = 0
        End Get
    End Property

End Structure

Public Structure SizeD
    Public Width As Decimal
    Public Height As Decimal

    Public Shared Narrowing Operator CType(ByVal size As SizeD) As PointD
        Return New PointD(size.Width, size.Height)
    End Operator

    Public Shared Narrowing Operator CType(ByVal size As SizeD) As PointF
        Return New PointD(size.Width, size.Height)
    End Operator

    Public Sub New(ByVal Width As Decimal, ByVal Height As Decimal)
        Me.Width = Width
        Me.Height = Height
    End Sub

    Public Shared Widening Operator CType(ByVal s As SizeF) As SizeD
        Return New SizeD(s.Width, s.Height)
    End Operator

    Public Shared Widening Operator CType(ByVal s As Size) As SizeD
        Return New SizeD(s.Width, s.Height)
    End Operator

    Public Shared Widening Operator CType(ByVal s As SizeD) As System.Drawing.SizeF
        Return New SizeF(s.Width, s.Height)
    End Operator

    Public Shared Widening Operator CType(ByVal s As SizeD) As System.Drawing.Size
        Return New Size(s.Width, s.Height)
    End Operator

    Public Shared Function Round(ByVal s As SizeD) As System.Drawing.Size
        Return New Size(s.Width, s.Height)
    End Function

    Public Shared Operator =(ByVal left As SizeD, ByVal right As SizeD) As Boolean
        Return (left.Width = right.Width) And (left.Height = right.Height)
    End Operator

    Public Shared Operator <>(ByVal left As SizeD, ByVal right As SizeD) As Boolean
        Return (left.Width <> right.Width) Or (left.Height <> right.Height)
    End Operator

    Public Shared Operator -(ByVal sz1 As SizeD, ByVal sz2 As SizeD) As SizeD
        sz1.Width = sz1.Width - sz2.Width
        sz1.Height = sz1.Height - sz2.Height
        Return sz1
    End Operator

    Public Shared Operator -(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.SizeF) As SizeD
        sz1.Width = sz1.Width - sz2.Width
        sz1.Height = sz1.Height - sz2.Height
        Return sz1
    End Operator

    Public Shared Operator -(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.Size) As SizeD
        sz1.Width = sz1.Width - sz2.Width
        sz1.Height = sz1.Height - sz2.Height
        Return sz1
    End Operator

    Public Shared Operator +(ByVal sz1 As SizeD, ByVal sz2 As SizeD) As SizeD
        sz1.Width = sz1.Width + sz2.Width
        sz1.Height = sz1.Height + sz2.Height
        Return sz1
    End Operator

    Public Shared Operator +(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.SizeF) As SizeD
        sz1.Width = sz1.Width + sz2.Width
        sz1.Height = sz1.Height + sz2.Height
        Return sz1
    End Operator

    Public Shared Operator +(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.Size) As SizeD
        sz1.Width = sz1.Width + sz2.Width
        sz1.Height = sz1.Height + sz2.Height
        Return sz1
    End Operator

    Public Shared Function Add(ByVal sz1 As SizeD, ByVal sz2 As SizeD) As SizeD
        sz1.Width = sz1.Width + sz2.Width
        sz1.Height = sz1.Height + sz2.Height
        Return sz1
    End Function

    Public Shared Function Add(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.SizeF) As SizeD
        sz1.Width = sz1.Width + sz2.Width
        sz1.Height = sz1.Height + sz2.Height
        Return sz1
    End Function

    Public Shared Function Add(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.Size) As SizeD
        sz1.Width = sz1.Width + sz2.Width
        sz1.Height = sz1.Height + sz2.Height
        Return sz1
    End Function

    Public Shared Function substract(ByVal sz1 As SizeD, ByVal sz2 As SizeD) As SizeD
        sz1.Width = sz1.Width - sz2.Width
        sz1.Height = sz1.Height - sz2.Height
        Return sz1
    End Function

    Public Shared Function substract(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.SizeF) As SizeD
        sz1.Width = sz1.Width - sz2.Width
        sz1.Height = sz1.Height - sz2.Height
        Return sz1
    End Function

    Public Shared Function substract(ByVal sz1 As SizeD, ByVal sz2 As System.Drawing.Size) As SizeD
        sz1.Width = sz1.Width - sz2.Width
        sz1.Height = sz1.Height - sz2.Height
        Return sz1
    End Function

    Public ReadOnly Property IsEmpty As Boolean
        Get
            Return Width = 0 And Height = 0
        End Get
    End Property
End Structure