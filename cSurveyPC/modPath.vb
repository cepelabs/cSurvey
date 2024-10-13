Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports ClipperLib

Module modPath
    'path1 intersect path2
    Public Function Intersect(Path1 As List(Of IntPoint), Path2 As List(Of IntPoint)) As Boolean
        Dim oClipper As Clipper = New Clipper
        Call oClipper.AddPolygon(Path1, PolyType.ptSubject)
        Call oClipper.AddPolygon(Path2, PolyType.ptClip)
        Dim oPaths As List(Of List(Of IntPoint)) = New List(Of List(Of IntPoint))
        Call oClipper.Execute(ClipType.ctIntersection, oPaths, PolyFillType.pftNonZero, PolyFillType.pftNonZero)
        Return oPaths.Count > 0
    End Function

    Public Function Intersect(Path1 As List(Of PointF), Path2 As List(Of PointF), Optional Accurancy As Single = 0.01) As Boolean
        Return modPath.Intersect(modClipper.ToIntPolygon(Path1, 1.0 / Accurancy), modClipper.ToIntPolygon(Path2, 1.0 / Accurancy))
    End Function

    Public Function Intersect(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 0.01) As Boolean
        Return modPath.Intersect(modClipper.GraphicsPathToIntPolygon(Path1, 1.0 / Accurancy), modClipper.GraphicsPathToIntPolygon(Path2, 1.0 / Accurancy))
    End Function

    'path1 contains path2
    Public Function Contains(Path1 As List(Of IntPoint), Path2 As List(Of IntPoint)) As Boolean
        Using oPath1 As GraphicsPath = New GraphicsPath
            Call oPath1.AddPolygon(Path1.Select(Function(oItem) New Point(oItem.X, oItem.Y)).ToArray)
            For Each oPath2Point As Point In Path2.Select(Function(oItem) New Point(oItem.X, oItem.Y))
                If Not oPath1.IsVisible(oPath2Point) Then
                    Return False
                End If
            Next
            Using oPath2 As GraphicsPath = New GraphicsPath
                Call oPath2.AddPolygon(Path2.Select(Function(oItem) New Point(oItem.X, oItem.Y)).ToArray)
                For Each oPath1Point As Point In Path1.Select(Function(oItem) New Point(oItem.X, oItem.Y))
                    If Not oPath2.IsVisible(oPath1Point) Then
                        Return False
                    End If
                Next
                Return True
            End Using
        End Using
    End Function

    Public Function Contains(Path1 As List(Of PointF), Path2 As List(Of PointF)) As Boolean
        Using oPath1 As GraphicsPath = New GraphicsPath
            Call oPath1.AddPolygon(Path1.ToArray)
            For Each oPath2Point As PointF In Path2
                If Not oPath1.IsVisible(oPath2Point) Then
                    Return False
                End If
            Next
            Using oPath2 As GraphicsPath = New GraphicsPath
                Call oPath2.AddPolygon(Path2.ToArray)
                For Each oPath1point As PointF In Path1
                    If Not oPath2.IsVisible(oPath1point) Then
                        Return False
                    End If
                Next
                Return True
            End Using
        End Using
    End Function

    Public Function Contains(Path1 As GraphicsPath, Path2 As GraphicsPath, Optional Accurancy As Single = 0.01) As Boolean
        Using oPath1 As GraphicsPath = Path1.Clone
            Call oPath1.Flatten(Nothing, Accurancy)
            Using oPath2 As GraphicsPath = Path1.Clone
                Call oPath2.Flatten(Nothing, Accurancy)
                For Each oPath2Point As PointF In oPath2.PathPoints
                    If Not Path1.IsVisible(oPath2Point) Then
                        Return False
                    End If
                Next
                For Each oPath1Point As PointF In oPath1.PathPoints
                    If Not Path2.IsVisible(oPath1Point) Then
                        Return False
                    End If
                Next
                Return True
            End Using
        End Using
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Sub WarpQ(Path As GraphicsPath, destPoints As PointF(), ByRef srcRect As RectangleF, Optional mode As WarpMode = WarpMode.Bilinear)
        'QWarper

        'This class implements a substitute for the GDI+ GraphicsPath:Warp() member function.

        'Advantages are:
        '1. it supports bilinear warp for paths having subpaths (GraphicsPathWarp() Is
        'very buggy in this respect);
        '2. it does Not 'flatten' the path before warping it (there is no need for it);
        '3. it Is considerably faster, i.e. 3 (perspective mode) to 7 (bilinear mode) times.

        'Usage:
        '- create a QWarper. The constructor parameters define the warping operation;
        '- use WarpPath() Or WarpPoints() to apply the warp.

        'Note that QWarper does Not support the 'three point warping' of GraphicsPath::Warp().
        'If you want this kind of warp, you'll have to calculate the fourth point explicitly
        'before construction.
        'Likewise, QWarper does Not support a matrix parameter to apply an extra affine
        'transformation along with the warp.

        '===============================
        'Version 1.0, August 24, 2003
        '(c) Sjaak Priester, Amsterdam
        'www.sjaakpriester.nl

        'Freeware. Use at your own risk. Comments welcome.

        Dim a0 As Single
        Dim a1 As Single
        Dim a2 As Single
        Dim a3 As Single

        Dim b0 As Single
        Dim b1 As Single
        Dim b2 As Single
        Dim b3 As Single

        Dim c0 As Single
        Dim c1 As Single

        Dim epsilon As Single = 1.0E-18F
        'oMode = mode
        Dim oCenter As PointF = modPaint.GetCenterPoint(srcRect)

        Using oM As Matrix = New Matrix
            ''translate so that srcRect Is centered at origin
            oM.Translate(-oCenter.X, -oCenter.Y, MatrixOrder.Append)

            ''Scale srcRect to square with sides 2.
            ''Corners are now (-1, -1), (1, -1), (1, 1), (-1, 1).
            ''These will be mapped to destPoints.
            oM.Scale(2.0F / srcRect.Width, 2.0F / srcRect.Height, MatrixOrder.Append)

            'In warping, we first apply an affine transformation, using mat.
            'Next, the result Is warped, using warping functions. Several factors
            'of these functions are pre-calculated in the constructor.

            If (mode = WarpMode.Perspective) Then
                'In perspective mode, the warping functions are:
                'x' = (a0 + a1 x + a2 y) / (c0 x + c1 y + 1)
                'y' = (b0 + b1 x + b2 y) / (c0 x + c1 y + 1)

                'The following calculates the factors a#, b# And c#.
                'The formula's are derived by:
                '1. substituting the corners of the normalized square for (x, y);
                '2. substituting the corresponding destPoints for (x', y');
                '3. solving the resulting set of eight equations, with the factors as unknowns.
                'It all amounts to a lot of old fashioned calculus by hand...

                'First a few intermediate values are calculated
                Dim px As Single = destPoints(0).X + destPoints(1).X - destPoints(2).X - destPoints(3).X
                Dim qx As Single = destPoints(0).X - destPoints(1).X + destPoints(2).X - destPoints(3).X
                Dim rx As Single = destPoints(0).X - destPoints(1).X - destPoints(2).X + destPoints(3).X

                Dim py As Single = destPoints(0).Y + destPoints(1).Y - destPoints(2).Y - destPoints(3).Y
                Dim qy As Single = destPoints(0).Y - destPoints(1).Y + destPoints(2).Y - destPoints(3).Y
                Dim ry As Single = destPoints(0).Y - destPoints(1).Y - destPoints(2).Y + destPoints(3).Y

                Dim num As Single = px * qy - qx * py

                'Avoid divide by zero
                If (Math.Abs(num) < epsilon OrElse Math.Abs(px) < epsilon) Then
                    Return
                    'Throw New OverflowException
                Else
                    'The final factors for the warping functions
                    c1 = (px * ry - rx * py) / num
                    c0 = (rx - qx * c1) / px

                    a1 = ((destPoints(0).X + destPoints(1).X) * c0 + (destPoints(0).X - destPoints(1).X) * (c1 - 1.0F)) / 2.0F
                    a0 = ((destPoints(1).X + destPoints(3).X) * (c0 + 1.0F) + (-destPoints(1).X + destPoints(3).X) * c1) / 2.0F - a1
                    a2 = ((-destPoints(2).X + destPoints(3).X) * c0 + (destPoints(2).X + destPoints(3).X) * (c1 + 1.0F)) / 2.0F - a0

                    b1 = ((destPoints(0).Y + destPoints(1).Y) * c0 + (destPoints(0).Y - destPoints(1).Y) * (c1 - 1.0F)) / 2.0F
                    b0 = ((destPoints(1).Y + destPoints(3).Y) * (c0 + 1.0F) + (-destPoints(1).Y + destPoints(3).Y) * c1) / 2.0F - b1
                    b2 = ((-destPoints(2).Y + destPoints(3).Y) * c0 + (destPoints(2).Y + destPoints(3).Y) * (c1 + 1.0F)) / 2.0F - b0
                End If
            Else
                'In bilinear mode, the warping functions are
                'x' = a0 + a1 x y + a2 x + a3 y
                'y' = b0 + b1 x y + b2 x + b3 y

                a0 = (destPoints(0).X + destPoints(1).X + destPoints(2).X + destPoints(3).X) / 4.0F
                a1 = (destPoints(0).X - destPoints(1).X - destPoints(2).X + destPoints(3).X) / 4.0F
                a2 = (-destPoints(0).X + destPoints(1).X - destPoints(2).X + destPoints(3).X) / 4.0F
                a3 = (-destPoints(0).X - destPoints(1).X + destPoints(2).X + destPoints(3).X) / 4.0F

                b0 = (destPoints(0).Y + destPoints(1).Y + destPoints(2).Y + destPoints(3).Y) / 4.0F
                b1 = (destPoints(0).Y - destPoints(1).Y - destPoints(2).Y + destPoints(3).Y) / 4.0F
                b2 = (-destPoints(0).Y + destPoints(1).Y - destPoints(2).Y + destPoints(3).Y) / 4.0F
                b3 = (-destPoints(0).Y - destPoints(1).Y + destPoints(2).Y + destPoints(3).Y) / 4.0F
            End If

            Dim pd As PathData = Path.PathData
            If pd.Points.Count = 0 Then
                Return
            Else
                Dim oPoints As PointF() = Path.PathPoints

                'Final warping Is in two loops:
                '1. apply affine transformation to the normalized square around the origin (identical
                '	in both modes);
                '2. apply warping functions, specific for each mode.
                'The fact that the warping functions are non-linear makes it impractical 
                'And uneconomical to combine the affine transformation And the warping functions
                'in one operation.

                Call oM.TransformPoints(oPoints)

                If mode = WarpMode.Perspective Then
                    For i As Integer = 0 To oPoints.Count - 1
                        Dim x As Single = oPoints(i).X
                        Dim y As Single = oPoints(i).Y
                        Dim num As Single = c0 * x + c1 * y + 1.0F
                        If (Math.Abs(num) < epsilon) Then
                            Throw New OverflowException
                        Else
                            oPoints(i).X = (a0 + a1 * x + a2 * y) / num
                            oPoints(i).Y = (b0 + b1 * x + b2 * y) / num
                        End If
                    Next
                Else
                    For i As Integer = 0 To oPoints.Count - 1
                        Dim x As Single = oPoints(i).X
                        Dim y As Single = oPoints(i).Y
                        Dim xy As Single = x * y
                        oPoints(i).X = a0 + a1 * xy + a2 * x + a3 * y
                        oPoints(i).Y = b0 + b1 * xy + b2 * x + b3 * y
                    Next
                End If

                Using oPath As GraphicsPath = New GraphicsPath(oPoints, pd.Types, Path.FillMode)
                    Dim oFM As FillMode = Path.FillMode
                    Path.Reset()
                    Path.FillMode = oFM
                    Call Path.AddPath(oPath, True)
                End Using
            End If
        End Using
    End Sub
End Module
