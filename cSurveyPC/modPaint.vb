Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Drawing.Imaging

Imports cSurveyPC.cSurvey.Helper.Editor
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Drawings
Imports System.IO
Imports System.Runtime.CompilerServices

Module modPaint
    Public Const sLineWidth As Single = 0.01
    Public Const sDefaultSplineTension As Single = 0.5
    Public Const iDefaultDesignScale As Integer = 250

    Public Enum AnchorRectangleTypeEnum
        None = &H0

        StartPoint = &H1
        EndPoint = &H2
        SpecialPoint = &H3
        GenericPoint = &H4
        BezierControlPoint = &H5

        FirstOfAllPoint = &H1000
        LastOfAllPoint = &H2000
        AllMask = &HF000

        TypeMask = &HFF
        JoinedPoint = &H100
        JoinedMask = &HF00

        TopLeftCorner = &H16
        TopRightCorner = &H17
        BottomLeftCorner = &H18
        BottomRightCorner = &H19
        CenterPoint = &H20
        LockedTopLeftCorner = &H21
        UnmovableTopLeftCorner = &H22
        ExtraTopLeftCorner = &H23

        LeftMiddle = &H30
        TopMiddle = &H31
        RightMiddle = &H32
        BottomMiddle = &H33

        Rotator = &H40
        CenterOfRotation = &H41

        LastPoint = &H98
        NewPoint = &H99
    End Enum

    Friend Class cHitTestResult
        Public Enum ObjectTypeEnum
            Outside = 0
            None = 1
            AnchorRectangle = 2
            Point = 3
        End Enum

        Public ObjectType As ObjectTypeEnum
        Public ObjectAnchorRectangleType As AnchorRectangleTypeEnum
        Public ObjectRectagle As RectangleF
        Public [Object] As Object

        Friend Sub New()
        End Sub
    End Class

    Public Enum OneOfNinePolygonEnum
        Center = 0
        Left = 1
        Top = 2
        Right = 3
        Bottom = 4
        LeftTop = 5
        RightTop = 6
        BottomRight = 7
        BottomLeft = 8
    End Enum

    Private sDefaultFontName As String = "Tahoma"
    Private sDefaultFontSize As Single = 8
    Private oDefaultFont As cFont

    Public Sub SafeBitmapSaveToStream(Bitmap As Bitmap, Stream As Stream, format As ImageFormat)
        Try
            Call Bitmap.Save(Stream, format)
        Catch ex As Exception
            Using oBitmap As Bitmap = New Bitmap(Bitmap)
                Call oBitmap.Save(Stream, format)
            End Using
        End Try
    End Sub

    'Public Function BitmapFromFileUnlocked(Bytes As Byte()) As Bitmap
    '    Return New Bitmap(New MemoryStream(Bytes))
    'End Function

    'Public Function BitmapFromFileUnlocked(Filename As String) As Bitmap
    '    Return New Bitmap(New MemoryStream(My.Computer.FileSystem.ReadAllBytes(Filename)))
    'End Function

    Public Function SafeBitmapFromFileUnlocked(Filename As String) As Bitmap
        'safebitmapfromfile have to unlock the file but I use this function cause I have no time to test if this is right or not...
        Using oMs As MemoryStream = New MemoryStream(My.Computer.FileSystem.ReadAllBytes(Filename))
            Using oBitmap As Bitmap = Bitmap.FromStream(oMs)
                Return New Bitmap(oBitmap)
            End Using
        End Using
    End Function

    Public Function SafeBitmapFromFile(Filename As String) As Bitmap
        Using oBitmap As Bitmap = Bitmap.FromFile(Filename)
            Return New Bitmap(oBitmap)
        End Using
    End Function

    Public Function SafeBitmapFromStream(Stream As Stream) As Bitmap
        Using oBitmap As Bitmap = Bitmap.FromStream(Stream)
            Return New Bitmap(oBitmap)
        End Using
    End Function

    Public Function PenStylePatternToString(Pattern As Single()) As String
        Dim sTemp As String = ""
        For Each sValue As Single In Pattern
            sTemp = sTemp & modNumbers.NumberToString(sValue) & " "
        Next
        Return sTemp
    End Function

    Public Function StringToPenStylePattern(Text As String) As Single()
        Dim sValues As String() = Text.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Return sValues.Cast(Of Single)()
    End Function

    Public Function GetAngleDiff(Angle1 As Single, Angle2 As Single, CounterClockwise As Boolean) As Single
        If CounterClockwise Then
            If Angle1 < Angle2 Then
                Return Angle2 - Angle1
            Else
                Return 360 - Angle2 + Angle1
            End If
        Else
            If Angle1 < Angle2 Then
                Return Angle2 - Angle1
            Else
                Return 360 - Angle1 + Angle2
            End If
        End If
    End Function

    Public Function GetDefaultFont() As cFont
        If oDefaultFont Is Nothing Then
            Using oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Cepelabs\cSurvey", Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree)
                oDefaultFont = New cFont(Nothing, oReg.GetValue("design.defaultfont.name", sDefaultFontName), modNumbers.StringToSingle(oReg.GetValue("design.defaultfont.size", sDefaultFontSize)), Color.Black, oReg.GetValue("design.defaultfont.bold", 0), oReg.GetValue("design.defaultfont.italic", 0), oReg.GetValue("design.defaultfont.underline", 0))
                Call oReg.Close()
            End Using
        End If
        Return oDefaultFont
    End Function

    Public Function FullScaleRectangle(Rectangle As RectangleF, Scale As Single) As RectangleF
        Return FullScaleRectangle(Rectangle, Scale, Scale)
    End Function

    Public Function FullScaleRectangle(Rectangle As RectangleF, ScaleX As Single, ScaleY As Single) As RectangleF
        Return New RectangleF(Rectangle.X * ScaleX, Rectangle.Y * ScaleY, Rectangle.Width * ScaleX, Rectangle.Height * ScaleY)
    End Function

    Public Function ScaleRectangle(Rectangle As RectangleF, Scale As Single) As RectangleF
        Return ScaleRectangle(Rectangle, Scale, Scale)
    End Function

    Public Function ScaleRectangle(Rectangle As RectangleF, ScaleX As Single, ScaleY As Single) As RectangleF
        Return New RectangleF(Rectangle.X, Rectangle.Y, Rectangle.Width * ScaleX, Rectangle.Height * ScaleY)
    End Function

    Public Function ProximityPoint(Point1 As PointF, Point2 As PointF, Range As Single) As Boolean
        Dim sDistance As Single = DistancePointToPoint(Point1, Point2)
        Return sDistance <= Range
    End Function

    Public Function GetNormalizedBisection(Angle1 As Decimal, Angle2 As Decimal) As Decimal
        Dim dAngle As Decimal = NormalizeAngle(Angle2 - Angle1)
        If dAngle > 180 Then
            Return (dAngle / 2) + 90 + Angle1
        Else
            Return (dAngle / 2) - 90 + Angle1
        End If
    End Function

    Public Function GetNormalizedBisection(Angle1 As Single, Angle2 As Single) As Single
        Dim sAngle As Single = NormalizeAngle(Angle2 - Angle1)
        If sAngle > 180 Then
            Return (sAngle / 2) + 90 + Angle1
        Else
            Return (sAngle / 2) - 90 + Angle1
        End If
    End Function

    Public Function GrayScaleImage(Image As Image) As Image
        Try
            Dim cm As ColorMatrix = New ColorMatrix(New Single()() {New Single() {0.299, 0.299, 0.299, 0, 0}, New Single() {0.587, 0.587, 0.587, 0, 0}, New Single() {0.114, 0.114, 0.114, 0, 0}, New Single() {0, 0, 0, 1, 0}, New Single() {0, 0, 0, 0, 1}})
            Dim oNewImage As Bitmap = New Bitmap(Image)
            Using oCurrentImageAttribute As ImageAttributes = New ImageAttributes
                Dim oRect As Rectangle = New Rectangle(0, 0, oNewImage.Width, oNewImage.Height)
                Using oGraphics As Graphics = Graphics.FromImage(oNewImage)
                    Call oCurrentImageAttribute.SetColorMatrix(cm)
                    Call oGraphics.DrawImage(oNewImage, oRect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel, oCurrentImageAttribute)
                End Using
                Return oNewImage
            End Using
        Catch
        End Try
    End Function

    Public Function ScaleImage(Image As Image, Size As Size, Backcolor As Color) As Image
        Dim oBounds As RectangleF = New RectangleF(0, 0, Image.Width, Image.Height)
        Dim oScaledBounds As RectangleF = New RectangleF(0, 0, Size.Width, Size.Height)
        Dim sScale As Single = ScaleToFit(oBounds, oScaledBounds)
        Dim oScaledSize As Size = New Size(oBounds.Width / sScale, oBounds.Height / sScale)
        Dim oImage As Bitmap = New Bitmap(Image, oScaledSize)
        Using oGr As Graphics = Graphics.FromImage(oImage)
            Call oGr.Clear(Backcolor)
            Call DrawScaledImage(oGr, Image, New RectangleF(0, 0, oScaledSize.Width, oScaledSize.Height))
        End Using
        Return oImage
    End Function

    Public Sub DrawStretchedImage(Graphics As Graphics, Image As Image, Bounds As RectangleF, ImageAttributes As System.Drawing.Imaging.ImageAttributes)
        Dim oPoints(2) As PointF
        oPoints(0) = Bounds.Location
        oPoints(1) = New PointF(Bounds.Right, Bounds.Top)
        oPoints(2) = New PointF(Bounds.Left, Bounds.Bottom)
        Dim oSourceRect As RectangleF = Image.GetBounds(System.Drawing.GraphicsUnit.Pixel)
        Call Graphics.DrawImage(Image, oPoints, oSourceRect, GraphicsUnit.Pixel, ImageAttributes)
    End Sub

    Public Sub DrawScaledImage(Graphics As Graphics, Image As Image, Bounds As RectangleF, ImageAttributes As System.Drawing.Imaging.ImageAttributes)
        Dim sSrcWidth As Single = Image.Width
        Dim sSrcHeight As Single = Image.Height
        Dim sDestWidth As Single = Bounds.Width
        Dim sDestHeight As Single = Bounds.Height

        Dim sDeltaX As Single = sSrcWidth / sDestWidth
        Dim sDeltaY As Single = sSrcHeight / sDestHeight
        Dim sDelta As Single = IIf(sDeltaX > sDeltaY, sDeltaX, sDeltaY)

        Dim sWidth As Single = sSrcWidth / sDelta
        Dim sHeight As Single = sSrcHeight / sDelta

        Dim oRect As RectangleF = New RectangleF(Bounds.Left + (Bounds.Width - sWidth) / 2, Bounds.Top + (Bounds.Height - sHeight) / 2, sWidth, sHeight)

        Dim oPoints(2) As PointF
        oPoints(0) = oRect.Location
        oPoints(1) = New PointF(oRect.Right, oRect.Top)
        oPoints(2) = New PointF(oRect.Left, oRect.Bottom)
        Dim oSourceRect As RectangleF = Image.GetBounds(System.Drawing.GraphicsUnit.Pixel)

        Call Graphics.DrawImage(Image, oPoints, oSourceRect, GraphicsUnit.Pixel, ImageAttributes)
    End Sub

    Public Sub DrawScaledImage(Graphics As Graphics, Image As Image, Bounds As RectangleF)
        Dim sSrcWidth As Single = Image.Width
        Dim sSrcHeight As Single = Image.Height
        Dim sDestWidth As Single = Bounds.Width
        Dim sDestHeight As Single = Bounds.Height

        Dim sDeltaX As Single = sSrcWidth / sDestWidth
        Dim sDeltaY As Single = sSrcHeight / sDestHeight
        Dim sDelta As Single = IIf(sDeltaX > sDeltaY, sDeltaX, sDeltaY)

        Dim sWidth As Single = sSrcWidth / sDelta
        Dim sHeight As Single = sSrcHeight / sDelta

        Dim oRect As RectangleF = New RectangleF(Bounds.Left + (Bounds.Width - sWidth) / 2, Bounds.Top + (Bounds.Height - sHeight) / 2, sWidth, sHeight)
        Call Graphics.DrawImage(Image, oRect)
    End Sub

    Public Function GetBisection(Angle1 As Single, Angle2 As Single) As Single
        Dim sAngle As Single
        Dim sDiff As Single
        If Angle2 > Angle1 Then
            sDiff = Angle2 - Angle1
            If sDiff <= 180 Then
                sAngle = Angle2 - sDiff / 2
            Else
                sAngle = Angle2 + sDiff / 2
            End If
        Else
            sDiff = Angle1 - Angle2
            If sDiff <= 180 Then
                sAngle = Angle1 - sDiff / 2
            Else
                sAngle = Angle1 + sDiff / 2
            End If
        End If
        Return sAngle
    End Function

    Public Function GetNormalizedBisection(Angle1 As Integer, Angle2 As Integer) As Integer
        Dim iAngle As Integer
        Dim iDiff As Integer
        If Angle2 > Angle1 Then
            iDiff = Angle2 - Angle1
            If iDiff <= 180 Then
                iAngle = Angle2 - iDiff / 2
                iAngle = iAngle + 90
            Else
                iAngle = Angle2 + iDiff / 2
                iAngle = iAngle - 90
            End If
        Else
            iDiff = Angle1 - Angle2
            If iDiff <= 180 Then
                iAngle = Angle1 - iDiff / 2
                iAngle = iAngle - 90
            Else
                iAngle = Angle1 + iDiff / 2
                iAngle = iAngle + 90
            End If
        End If
        Return iAngle
    End Function

    Public Function GetBisection(Angle1 As Integer, Angle2 As Integer) As Integer
        Dim iAngle As Integer
        Dim iDiff As Integer
        If Angle2 > Angle1 Then
            iDiff = Angle2 - Angle1
            If iDiff <= 180 Then
                iAngle = Angle2 - iDiff / 2
            Else
                iAngle = Angle2 + iDiff / 2
            End If
        Else
            iDiff = Angle1 - Angle2
            If iDiff <= 180 Then
                iAngle = Angle1 - iDiff / 2
            Else
                iAngle = Angle1 + iDiff / 2
            End If
        End If
        Return iAngle
    End Function

    Public Function IsAngleBetween(Angle As Integer, [From] As Integer, [To] As Integer) As Boolean
        Dim sFrom As Integer = NormalizeAngle([From])
        Dim sTo As Integer = NormalizeAngle([To])
        If sFrom = sTo Then
            Return True
        Else
            If sFrom < sTo Then
                Return Angle >= sFrom AndAlso Angle <= sTo
            Else
                Return (Angle >= sFrom AndAlso Angle < 360) OrElse (Angle >= 0 AndAlso Angle <= sTo)
            End If
        End If
    End Function

    Public Function IsAngleBetween(Angle As Single, [From] As Single, [To] As Single) As Boolean
        Dim sFrom As Single = NormalizeAngle([From])
        Dim sTo As Single = NormalizeAngle([To])
        If sFrom = sTo Then
            Return True
        Else
            If sFrom < sTo Then
                Return Angle >= sFrom AndAlso Angle <= sTo
            Else
                Return (Angle >= sFrom AndAlso Angle < 360) OrElse (Angle >= 0 AndAlso Angle <= sTo)
            End If
        End If
    End Function

    Private Function pToStraightLineGetSourcePoint(Sequence As cSequence, NewPoint As cPoint) As cPoint
        Dim sMinDistance As Single = Single.MaxValue
        Dim oSourcePoint As cPoint = Nothing
        For Each oPoint As cPoint In Sequence
            Dim sDistance As Single = DistancePointToPoint(oPoint.Point, NewPoint.Point)
            If sDistance < sMinDistance Then
                sMinDistance = sDistance
                oSourcePoint = oPoint
            End If
        Next
        Return oSourcePoint
    End Function

    'Public Function ToSpline(Survey As cSurvey.cSurvey, Item As cItem, Optional Flatness As Single = 0.1) As List(Of cSequence)
    '    If Item.HaveLineType Then
    '        Dim oSequences As List(Of cSequence) = Item.Points.GetSequences
    '        Dim oNewSequences As List(Of cSequence) = New List(Of cSequence)
    '        Dim iDefaultLineType As Object = DirectCast(Item, cSurvey.Design.Items.cIItemLine).LineType
    '        For Each oSequence As cSequence In oSequences
    '            Dim oNewSequence As cSequence = ToSpline(Survey, oSequence, iDefaultLineType, Flatness)
    '            Call oNewSequences.Add(oNewSequence)
    '        Next
    '        Return oNewSequences
    '    Else
    '        Return Nothing
    '    End If
    'End Function

    Public Function ToSpline(Survey As cSurvey.cSurvey, Sequence As cSequence, DefaultLineType As Items.cIItemLine.LineTypeEnum, Optional Flatness As Single = 0.1) As cSequence
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Sequence.GetLineType(DefaultLineType)
        If iLineType = cIItemLine.LineTypeEnum.Splines Then
            Return Sequence
        Else
            If Sequence.GetLineType(DefaultLineType) = cIItemLine.LineTypeEnum.Lines Then
                Sequence.First.LineType = cIItemLine.LineTypeEnum.Splines
                Return Sequence
            Else
                Dim oSequence As cSequence = ToStraightLine(Survey, Sequence, DefaultLineType, Flatness)
                oSequence.First.LineType = cIItemLine.LineTypeEnum.Splines
                Return oSequence
            End If
        End If
    End Function

    'Public Function ToStraightLine(Survey As cSurvey.cSurvey, Item As cItem, Optional Flatness As Single = 0.25) As List(Of cSequence)
    '    If Item.HaveLineType Then
    '        Dim oSequences As List(Of cSequence) = Item.Points.GetSequences
    '        Dim oNewSequences As List(Of cSequence) = New List(Of cSequence)
    '        Dim iDefaultLineType As Object = DirectCast(Item, cSurvey.Design.Items.cIItemLine).LineType
    '        For Each oSequence As cSequence In oSequences
    '            Dim oNewSequence As cSequence = ToStraightLine(Survey, oSequence, iDefaultLineType, Flatness)
    '            Call oNewSequences.Add(oNewSequence)
    '        Next
    '        Return oNewSequences
    '    Else
    '        Return Nothing
    '    End If
    'End Function
    Public Function ToStraightLinePoints(Survey As cSurvey.cSurvey, Sequence As cSequence, DefaultLineType As Items.cIItemLine.LineTypeEnum, Optional Flatness As Single = 0.1) As List(Of PointF)
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Sequence.GetLineType(DefaultLineType)
        If iLineType = cIItemLine.LineTypeEnum.Lines Then
            Return New List(Of PointF)(Sequence.GetPoints)
        Else
            Dim oNewSequence As cSequence = Nothing
            Dim oSequencePoints() As PointF = Sequence.GetPoints
            If oSequencePoints.Length > 1 Then
                Using oPath As GraphicsPath = New GraphicsPath
                    Select Case iLineType
                        Case Items.cIItemLine.LineTypeEnum.Beziers
                            Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                        Case Items.cIItemLine.LineTypeEnum.Splines
                            Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                    End Select
                    Call oPath.Flatten(Nothing, Flatness)
                    Return New List(Of PointF)(oPath.PathPoints)
                End Using
            Else
                Return New List(Of PointF)
            End If
        End If
    End Function

    Public Function ToStraightLineForced(Survey As cSurvey.cSurvey, Sequence As cSequence, DefaultLineType As Items.cIItemLine.LineTypeEnum, Optional Flatness As Single = 0.1) As cSequence
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Sequence.GetLineType(DefaultLineType)
        If iLineType = cIItemLine.LineTypeEnum.Lines Then
            Return Sequence
        Else
            Dim oNewSequence As cSequence = Nothing
            Dim oSequencePoints() As PointF = Sequence.GetPoints
            If oSequencePoints.Length > 1 Then
                Dim oPath As GraphicsPath = New GraphicsPath
                Select Case iLineType
                    Case Items.cIItemLine.LineTypeEnum.Beziers
                        Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                    Case Items.cIItemLine.LineTypeEnum.Splines
                        Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                End Select
                Call oPath.Flatten(Nothing, Flatness)

                For Each oPoint As PointF In oPath.PathPoints
                    If oNewSequence Is Nothing Then
                        Dim oFirstPoint As cPoint = New cPoint(Survey, oPoint)
                        oFirstPoint.BeginSequence = True
                        oFirstPoint.LineType = Items.cIItemLine.LineTypeEnum.Lines
                        Dim oSourcePoint As cPoint = pToStraightLineGetSourcePoint(Sequence, oFirstPoint)
                        oFirstPoint.Pen = oSourcePoint.Pen
                        Call oFirstPoint.BindSegment(oSourcePoint.BindedSegment)
                        oNewSequence = New cSequence(oFirstPoint)
                    Else
                        Dim oNextPoint As cPoint = New cPoint(Survey, oPoint)
                        Call oNewSequence.Append(oNextPoint)
                        Dim oSourcePoint As cPoint = pToStraightLineGetSourcePoint(Sequence, oNextPoint)
                        oNextPoint.Pen = oSourcePoint.Pen
                        Call oNextPoint.BindSegment(oSourcePoint.BindedSegment)
                    End If
                Next
                Return oNewSequence
            Else
                Return Sequence
            End If
        End If
    End Function

    Public Function ToStraightLine(Survey As cSurvey.cSurvey, Sequence As cSequence, DefaultLineType As Items.cIItemLine.LineTypeEnum, Optional Flatness As Single = 0.1) As cSequence
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Sequence.GetLineType(DefaultLineType)
        If iLineType = cIItemLine.LineTypeEnum.Lines Then
            Return Sequence
        ElseIf iLineType = cIItemLine.LineTypeEnum.Splines Then
            Sequence.First.LineType = cIItemLine.LineTypeEnum.Lines
            Return Sequence
        Else
            Dim oNewSequence As cSequence = Nothing
            Dim oSequencePoints() As PointF = Sequence.GetPoints
            If oSequencePoints.Length > 1 Then
                Dim oPath As GraphicsPath = New GraphicsPath
                Select Case iLineType
                    Case Items.cIItemLine.LineTypeEnum.Beziers
                        Call modPaint.PointsToBeziers(oSequencePoints, oPath)
                    Case Items.cIItemLine.LineTypeEnum.Splines
                        Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
                End Select
                Call oPath.Flatten(Nothing, Flatness)

                For Each oPoint As PointF In oPath.PathPoints
                    If oNewSequence Is Nothing Then
                        Dim oFirstPoint As cPoint = New cPoint(Survey, oPoint)
                        oFirstPoint.BeginSequence = True
                        oFirstPoint.LineType = Items.cIItemLine.LineTypeEnum.Lines
                        Dim oSourcePoint As cPoint = pToStraightLineGetSourcePoint(Sequence, oFirstPoint)
                        oFirstPoint.Pen = oSourcePoint.Pen
                        Call oFirstPoint.BindSegment(oSourcePoint.BindedSegment)
                        oNewSequence = New cSequence(oFirstPoint)
                    Else
                        Dim oNextPoint As cPoint = New cPoint(Survey, oPoint)
                        Call oNewSequence.Append(oNextPoint)
                        Dim oSourcePoint As cPoint = pToStraightLineGetSourcePoint(Sequence, oNextPoint)
                        oNextPoint.Pen = oSourcePoint.Pen
                        Call oNextPoint.BindSegment(oSourcePoint.BindedSegment)
                    End If
                Next
                Return oNewSequence
            Else
                Return Sequence
            End If
        End If
    End Function

    Public Function ToBezier(Survey As cSurvey.cSurvey, Sequence As cSequence, DefaultLineType As Items.cIItemLine.LineTypeEnum) As cSequence
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Sequence.GetLineType(DefaultLineType)
        If iLineType = cIItemLine.LineTypeEnum.Beziers Then
            Return Sequence
        Else
            If Sequence.GetLineType(DefaultLineType) = Items.cIItemLine.LineTypeEnum.Lines Then
                Sequence = ToSpline(Survey, Sequence, 0.1)
            End If

            Dim oNewSequence As cSequence
            Dim sTension As Single = 0.5
            Dim A As Single = sTension / 0.5 * 0.175
            Dim pt, pt_before, pt_after, pt_after2, Di, DiPlus1 As PointF
            Dim p1, p2, p3, p4 As PointF
            For i As Integer = 0 To Sequence.Count - 2
                pt_before = Sequence(Math.Max(i - 1, 0)).Point
                pt = Sequence(i).Point
                pt_after = Sequence(i + 1).Point
                pt_after2 = Sequence(Math.Min(i + 2, Sequence.Count - 1)).Point

                p1 = Sequence(i).Point
                p4 = Sequence(i + 1).Point

                Di.X = pt_after.X - pt_before.X
                Di.Y = pt_after.Y - pt_before.Y
                p2.X = pt.X + A * Di.X
                p2.Y = pt.Y + A * Di.Y

                DiPlus1.X = pt_after2.X - p1.X 'Sequence(i).Point.X
                DiPlus1.Y = pt_after2.Y - p1.Y 'Sequence(i).Point.Y
                p3.X = pt_after.X - A * DiPlus1.X
                p3.Y = pt_after.Y - A * DiPlus1.Y

                If oNewSequence Is Nothing Then
                    Dim oFirstPoint As cPoint = New cPoint(Survey, Sequence(i))
                    oFirstPoint.BeginSequence = True
                    oFirstPoint.LineType = Items.cIItemLine.LineTypeEnum.Beziers
                    oNewSequence = New cSequence(oFirstPoint)
                    Call oNewSequence.Append(New cPoint(Survey, p2))
                    Call oNewSequence.Append(New cPoint(Survey, p3))
                Else
                    Call oNewSequence.Append(New cPoint(Survey, Sequence(i)))
                    Call oNewSequence.Append(New cPoint(Survey, p2))
                    Call oNewSequence.Append(New cPoint(Survey, p3))
                End If
            Next
            If Not oNewSequence Is Nothing Then Call oNewSequence.Append(New cPoint(Survey, Sequence.Last))
            Return oNewSequence
        End If
    End Function

    Public Function GetRectanglefFomPoint(Point As PointF, Size As Single) As RectangleF
        Dim sHalfSize As Single = Size / 2
        Return New RectangleF(Point.X - sHalfSize, Point.Y - sHalfSize, Size, Size)
    End Function

    Public Function GetMediumPoint(Point1 As PointF, Point2 As PointF) As PointF
        Return New PointF((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2)
    End Function

    Public Function GetMediumPoint(Point1 As Point, Point2 As Point) As Point
        Return New Point((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2)
    End Function

    Public Function NormalizeInclination(Degree As Decimal) As Decimal
        If Degree >= -90 AndAlso Degree <= 90 Then
            Return Degree
        Else
            If Degree < 0 Then
                Return -1 * (180 + Degree)
            Else
                Return 180 - Degree
            End If
        End If
    End Function

    Public Function NormalizeAngle(ByVal Degree As Decimal) As Decimal
        Degree = Degree Mod 360
        If Degree < 0 Then
            Return Degree + 360
        Else
            Return Degree
        End If
    End Function

    Public Function NormalizeAngle(ByVal Degree As Double) As Double
        Degree = Degree Mod 360
        If Degree < 0 Then
            Return Degree + 360
        Else
            Return Degree
        End If
    End Function

    Public Function NormalizeAngle(ByVal Degree As Single) As Single
        Degree = Degree Mod 360
        If Degree < 0 Then
            Return Degree + 360
        Else
            Return Degree
        End If
    End Function

    Public Function AddAngle(ByVal Degree As Decimal, ByVal Value As Decimal) As Decimal
        Return NormalizeAngle(Degree + Value)
    End Function

    Public Function AddAngle(ByVal Degree As Double, ByVal Value As Double) As Double
        Return NormalizeAngle(Degree + Value)
    End Function

    Public Function AddAngle(ByVal Degree As Single, ByVal Value As Single) As Single
        Return NormalizeAngle(Degree + Value)
    End Function

    Public Function IsRectangleEmpty(ByVal Rectangle As RectangleF) As Boolean
        Return (Rectangle.Left = 0 AndAlso Rectangle.Top = 0 AndAlso Rectangle.Height = 0 AndAlso Rectangle.Width = 0) 'orelse (Single.IsNaN(Rectangle.Left) orelse Single.IsNaN(Rectangle.Top) orelse Single.IsNaN(Rectangle.Height) orelse Single.IsNaN(Rectangle.Width))
    End Function

    Public Function IsRectangleEmpty(ByVal Rectangle As Rectangle) As Boolean
        Return (Rectangle.Left = 0 AndAlso Rectangle.Top = 0 AndAlso Rectangle.Height = 0 AndAlso Rectangle.Width = 0)
    End Function

    Public Function ScaleToFit(Rectangle1 As Rectangle, rectangle2 As Rectangle) As Integer
        Return Math.Min(Rectangle1.Width / rectangle2.Width, Rectangle1.Height / rectangle2.Height)
    End Function

    Public Function ScaleToFit(Rectangle1 As RectangleF, rectangle2 As RectangleF) As Single
        Return Math.Min(Rectangle1.Width / rectangle2.Width, Rectangle1.Height / rectangle2.Height)
    End Function

    'Public Sub xConvertSequences(Item As cItem, Optional Flatness As Single = 0.1)
    '    If Item.Points.Count > 0 Then
    '        Dim oNewPoints As List(Of cPoint) = New List(Of cPoint)
    '        For Each oSequence As cSequence In Item.Points.GetSequences
    '            Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(DirectCast(Item, Items.cIItemLine).LineType)
    '            If iLineType >= Items.cIItemLine.LineTypeEnum.Splines Then
    '                Dim oConvertedPoints() As PointF = modPaint.ConvertSequence(oSequence, iLineType, Items.cIItemLine.LineTypeEnum.Splines, Flatness)
    '                Dim bFirst As Boolean = True
    '                For Each oConvertedPoint As PointF In oConvertedPoints
    '                    Dim oPoint As cPoint = New cPoint(Item.Survey, oConvertedPoint)
    '                    If bFirst Then
    '                        oPoint.BeginSequence = True
    '                        oPoint.LineType = Items.cIItemLine.LineTypeEnum.Splines
    '                        bFirst = False
    '                    End If
    '                    Call oNewPoints.Add(oPoint)
    '                Next
    '            Else
    '                For Each oPoint As cPoint In oSequence
    '                    Call oNewPoints.Add(oPoint)
    '                Next
    '            End If
    '        Next
    '        Call Item.Points.Clear()
    '        For Each oPoint As cPoint In oNewPoints
    '            Call Item.Points.Add(oPoint)
    '        Next
    '    End If
    'End Sub

    'Public Function xConvertSequence(Sequence As cSequence, FromLineType As Items.cIItemLine.LineTypeEnum, ToLineType As Items.cIItemLine.LineTypeEnum, Flatness As Single) As PointF()
    '    If FromLineType = Items.cIItemLine.LineTypeEnum.Beziers Then
    '        Dim oPath As GraphicsPath = New GraphicsPath
    '        Dim oSequencePoints As PointF() = Sequence.GetPoints
    '        Select Case Sequence.GetLineType(FromLineType)
    '            Case Items.cIItemLine.LineTypeEnum.Beziers
    '                Call modPaint.PointsToBeziers(oSequencePoints, oPath)
    '            Case Items.cIItemLine.LineTypeEnum.Splines
    '                Call oPath.AddCurve(oSequencePoints, sDefaultSplineTension)
    '            Case Else
    '                Call oPath.AddLines(oSequencePoints)
    '        End Select
    '        Call oPath.Flatten(Nothing, Flatness)
    '        Return oPath.PathPoints
    '    End If
    'End Function

    Public Function ReverseAngle(ByVal Degree As Decimal) As Decimal
        If Degree > 180 Then
            Return Degree - 180
        Else
            Return Degree + 180
        End If
    End Function

    Public Function ReverseAngle(ByVal Degree As Double) As Double
        If Degree > 180 Then
            Return Degree - 180
        Else
            Return Degree + 180
        End If
    End Function

    Public Function ReverseAngle(ByVal Degree As Single) As Single
        If Degree > 180 Then
            Return Degree - 180
        Else
            Return Degree + 180
        End If
    End Function

    Public Function DegreeToRadians(ByVal Degree As Double) As Double
        Return Math.PI * Degree / 180
    End Function

    Public Function RadiansToDegree(ByVal Radiant As Double) As Double
        Return Radiant * 180 / Math.PI
    End Function

    Public Function DegreeToRadians(ByVal Degree As Single) As Single
        Return Math.PI * Degree / 180
    End Function

    Public Function RadiansToDegree(ByVal Radiant As Single) As Single
        Return Radiant * 180 / Math.PI
    End Function

    Public Function DegreeToRadians(ByVal Degree As Decimal) As Decimal
        Return Math.PI * Degree / 180
    End Function

    Public Function RadiansToDegree(ByVal Radiant As Decimal) As Decimal
        Return Radiant * 180 / Math.PI
    End Function

    Public Function GetZoomFactor(ByVal graphics As Graphics, ByVal Scale As Decimal) As Decimal
        Select Case graphics.PageUnit
            Case GraphicsUnit.Millimeter
                Return 1.0 / Scale
            Case GraphicsUnit.Pixel
                Return graphics.DpiX / (Scale * 0.0254)
            Case Else   'display...
                'there is no way to detect if graphics is in a printer or screen/image context so I use dpi to dectect this and scale all correctly
                If graphics.DpiX = 96 Then
                    Return graphics.DpiX / (Scale * 0.0254)
                Else
                    Return 1 / (Scale * 0.000254)
                End If
        End Select
    End Function

    Public Function GetScaleFactor(ByVal Graphics As Graphics, ByVal Zoom As Decimal) As Integer
        Dim dScale As Decimal
        Select Case Graphics.PageUnit
            Case GraphicsUnit.Millimeter
                dScale = 1 / Zoom
            Case GraphicsUnit.Pixel
                dScale = Graphics.DpiX / (Zoom * 0.0254)
            Case Else   'display...
                'there is no way to detect if graphics is in a printer or screen/image context so I use dpi to dectect this and scale all correctly
                If Graphics.DpiX = 96 Then
                    dScale = Graphics.DpiX / (Zoom * 0.0254)
                Else
                    dScale = 1 / (Zoom * 0.000254)
                End If
        End Select
        Return Math.Round(dScale, 0)
    End Function

    Public Function MillimetersToPixel(ByVal DPI As Single, ByVal Millimeters As Single) As Single
        Return DPI * Millimeters / 25.4
    End Function

    Public Function PixelToMillimeters(ByVal DPI As Single, ByVal Pixels As Single) As Single
        Return (DPI / 25.4) * Pixels
    End Function

    Public Function PixelToMillimetersX(ByVal graphics As Graphics, ByVal Pixels As Single) As Single
        Return (graphics.DpiX / 25.4) * Pixels
    End Function

    Public Function PixelToMillimetersY(ByVal graphics As Graphics, ByVal Pixels As Single) As Single
        Return (graphics.DpiY / 25.4) * Pixels
    End Function

    Public Sub PointsToBeziers(ByVal Points() As PointF, ByVal Item As Drawings.cDrawCacheItem)
        If Points.Count > 3 Then
            For i As Integer = 0 To Points.Count - 4 Step 3
                Call Item.AddBezier(Points(i), Points(i + 1), Points(i + 2), Points(i + 3))
            Next
        End If
    End Sub

    Public Sub PointsToBeziers(ByVal Points() As PointF, ByVal Path As GraphicsPath)
        If Points.Count > 3 Then
            For i As Integer = 0 To Points.Count - 4 Step 3
                Call Path.AddBezier(Points(i), Points(i + 1), Points(i + 2), Points(i + 3))
            Next
        End If
    End Sub

    Public Function ToPaintPoint(ByVal Point As PointF, ByVal Zoom As Single, ByVal Translation As PointF) As PointF
        Return New PointF((Point.X * Zoom) + Translation.X, (Point.Y * Zoom) + Translation.Y)
    End Function

    Public Function FromPaintPoint(ByVal Point As PointF, ByVal Zoom As Single, ByVal Translation As PointF) As PointF
        Return New PointF((Point.X - Translation.X) / Zoom, (Point.Y - Translation.Y) / Zoom)
    End Function

    Public Function FromPaintRectangle(ByVal Rectangle As RectangleF, ByVal Zoom As Single, ByVal Translation As PointF) As RectangleF
        Return New RectangleF((Rectangle.X - Translation.X) / Zoom, (Rectangle.Y - Translation.Y) / Zoom, Rectangle.Width / Zoom, Rectangle.Height / Zoom)
    End Function

    'Public Function ToPaintPoints(ByVal Points() As PointF) As PointF()
    '    Dim oPoints() As PointF = Points.Clone
    '    For i As Integer = 0 To oPoints.Length - 1
    '        oPoints(i) = New PointF((oPoints(i).X * Zoom) + Translation.X, (oPoints(i).Y * Zoom) + Translation.Y)
    '    Next
    '    Return oPoints
    'End Function

    'Public Function FromPaintPoints(ByVal Points() As PointF) As PointF()
    '    Dim oPoints() As PointF = Points.Clone
    '    For i As Integer = 0 To oPoints.Length - 1
    '        oPoints(i) = New PointF((oPoints(i).X - Translation.X) / Zoom, (oPoints(i).Y - Translation.Y) / Zoom)
    '    Next
    '    Return oPoints
    'End Function

    'Public Function ToPaintPointX(ByVal X As Single) As Single
    '    Return (X * Zoom) + Translation.X
    'End Function

    'Public Function ToPaintPointY(ByVal Y As Single) As Single
    '    Return (Y * Zoom) + Translation.Y
    'End Function

    Public Function ToPaintSize(ByVal Size As SizeF, ByVal Zoom As Single, ByVal Translation As PointF) As SizeF
        Return New SizeF((Size.Width * Zoom), (Size.Height * Zoom))
    End Function

    Public Function ToPaintSize(ByVal Width As Single, ByVal Height As Single, ByVal Zoom As Single, ByVal Translation As PointF) As SizeF
        Return New SizeF((Width * Zoom), (Height * Zoom))
    End Function

    Public Function FromPaintSize(ByVal Size As SizeF, ByVal Zoom As Single, ByVal Translation As PointF) As SizeF
        Return New SizeF((Size.Width / Zoom), (Size.Height / Zoom))
    End Function

    Public Function FromPaintSize(ByVal Width As Single, ByVal Height As Single, ByVal Zoom As Single, ByVal Translation As PointF) As SizeF
        Return New SizeF((Width / Zoom), (Height / Zoom))
    End Function

    'Public Function GetBearing(ByVal p0 As PointF, ByVal p1 As PointF) As Decimal
    '    Dim sBearing As Decimal
    '    If p0.Y = p1.Y Then
    '        If p0.X < p1.X Then
    '            sBearing = 90 '270
    '        Else
    '            sBearing = 270 '90
    '        End If
    '    Else
    '        sBearing = modnumbers.mathround(modPaint.GetAngleBetweenSegment(p0, New PointF(p0.X, p1.Y), p0, p1), 2)
    '        If p0.Y > p1.Y Then
    '            If p0.X > p1.X Then
    '                sBearing = 360 - sBearing
    '            Else
    '                'sBearing = 180 + sBearing
    '            End If
    '        Else
    '            If p0.X < p1.X Then
    '                sBearing = 180 - sBearing
    '            Else
    '                sBearing = 180 + sBearing
    '            End If
    '        End If
    '    End If
    '    Return sBearing
    'End Function
    Public Function GetInclination(ByVal p0 As PointD, ByVal p1 As PointD) As Decimal
        Dim dDirection As Decimal
        Dim dBearing As Decimal = GetBearing(p0, p1)
        If dBearing >= 0 AndAlso dBearing <= 180 Then
            dBearing -= 90
            dDirection = dBearing * -1
        Else
            dBearing -= 270
            dDirection = dBearing
        End If
        Return dDirection
    End Function

    Public Function GetInclination(ByVal p0 As PointF, ByVal p1 As PointF) As Single
        Dim sDirection As Single
        Dim sBearing As Single = GetBearing(p0, p1)
        If sBearing >= 0 AndAlso sBearing <= 180 Then
            sBearing -= 90
            sDirection = sBearing * -1
        Else
            sBearing -= 270
            sDirection = sBearing
        End If
        Return sDirection
    End Function

    Public Function GetInclination(ByVal p0 As Point, ByVal p1 As Point) As Integer
        Dim iDirection As Integer
        Dim iBearing As Integer = GetBearing(p0, p1)
        If iBearing >= 0 AndAlso iBearing <= 180 Then
            iBearing -= 90
            iDirection = iBearing * -1
        Else
            iBearing -= 270
            iDirection = iBearing
        End If
        Return iDirection
    End Function

    Public Function GetBearing(ByVal p0 As Point, ByVal p1 As Point) As Integer
        Dim iBearing As Integer
        If p0.Y = p1.Y Then
            If p0.X < p1.X Then
                iBearing = 90 '270
            Else
                iBearing = 270 '90
            End If
        Else
            iBearing = modPaint.GetAngleBetweenSegment(p0, New Point(p0.X, p1.Y), p0, p1)
            If p0.Y > p1.Y Then
                If p0.X > p1.X Then
                    iBearing = 360 - iBearing
                Else
                    'sBearing = 180 + sBearing
                End If
            Else
                If p0.X < p1.X Then
                    iBearing = 180 - iBearing
                Else
                    iBearing = 180 + iBearing
                End If
            End If
        End If
        Return iBearing
    End Function

    Public Function InclinationIsInRange(Angle As Decimal, Min As Decimal, Max As Decimal) As Boolean
        If Min < Max Then
            Return Min <= Angle And Angle <= Max
        Else
            Return Max <= Angle And Angle <= Min
        End If
    End Function

    Public Function BearingIsInRange(Angle As Decimal, Min As Decimal, Max As Decimal) As Boolean
        Return AngleIsInRange(Angle, Min, Max)
    End Function

    Public Function AngleIsInRange(Angle As Decimal, Min As Decimal, Max As Decimal) As Boolean
        Dim dMin As Decimal = modPaint.NormalizeAngle(Min)
        Dim dMax As Decimal = modPaint.NormalizeAngle(Max)
        If dMin < dMax Then
            Return dMin <= Angle And Angle <= dMax
        Else
            Return (dMin <= Angle And Angle < 360) Or (0 <= Angle And Angle <= dMax)
        End If
    End Function

    Public Function GetBearing(ByVal p0 As PointD, ByVal p1 As PointD) As Decimal
        Dim sBearing As Decimal
        If p0.Y = p1.Y Then
            If p0.X < p1.X Then
                sBearing = 90 '270
            Else
                sBearing = 270 '90
            End If
        Else
            sBearing = modPaint.GetAngleBetweenSegment(p0, New PointD(p0.X, p1.Y), p0, p1)
            If p0.Y > p1.Y Then
                If p0.X > p1.X Then
                    sBearing = 360 - sBearing
                Else
                    'sBearing = 180 + sBearing
                End If
            Else
                If p0.X < p1.X Then
                    sBearing = 180 - sBearing
                Else
                    sBearing = 180 + sBearing
                End If
            End If
        End If
        Return sBearing
    End Function

    Public Function GetBearing(ByVal p0 As PointF, ByVal p1 As PointF) As Single
        Dim sBearing As Single
        If p0.Y = p1.Y Then
            If p0.X < p1.X Then
                sBearing = 90 '270
            Else
                sBearing = 270 '90
            End If
        Else
            'sBearing = modnumbers.mathround(modPaint.GetAngleBetweenSegment(p0, New PointF(p0.X, p1.Y), p0, p1), 2)
            sBearing = modPaint.GetAngleBetweenSegment(p0, New PointF(p0.X, p1.Y), p0, p1)
            If p0.Y > p1.Y Then
                If p0.X > p1.X Then
                    sBearing = 360 - sBearing
                Else
                    'sBearing = 180 + sBearing
                End If
            Else
                If p0.X < p1.X Then
                    'sBearing = 180 + sBearing
                    sBearing = 180 - sBearing
                Else
                    'sBearing = 180 - sBearing
                    sBearing = 180 + sBearing
                End If
            End If
        End If
        Return sBearing
    End Function

    Public Function Trigo(ByVal Ipotenusa As Single, ByVal Angle As Single) As SizeF
        Dim sAngle As Single = NormalizeAngle(Angle)
        Dim c1 As Single
        Dim c2 As Single

        If sAngle = 0 Then
            c1 = Ipotenusa
            c2 = 0
            Return New SizeF(c2, -c1)
        ElseIf sAngle > 0 AndAlso sAngle < 90 Then
            sAngle = DegreeToRadians(Angle)
            c1 = Ipotenusa * Math.Cos(sAngle)
            c2 = Ipotenusa * Math.Sin(sAngle)
            Return New SizeF(c2, -c1)
        ElseIf sAngle = 90 Then
            c1 = 0
            c2 = Ipotenusa
            Return New SizeF(c2, c1)
        ElseIf sAngle > 90 AndAlso sAngle < 180 Then
            sAngle = DegreeToRadians(Angle - 90)
            c1 = Ipotenusa * Math.Sin(sAngle)
            c2 = Ipotenusa * Math.Cos(sAngle)
            Return New SizeF(c2, c1)
        ElseIf sAngle = 180 Then
            c1 = Ipotenusa
            c2 = 0
            Return New SizeF(c2, c1)
        ElseIf sAngle > 180 AndAlso sAngle < 270 Then
            sAngle = DegreeToRadians(Angle - 180)
            c1 = Ipotenusa * Math.Cos(sAngle)
            c2 = Ipotenusa * Math.Sin(sAngle)
            Return New SizeF(-c2, c1)
        ElseIf sAngle = 270 Then
            c1 = 0
            c2 = Ipotenusa
            Return New SizeF(-c2, c1)
        ElseIf sAngle > 270 AndAlso sAngle < 360 Then
            sAngle = DegreeToRadians(Angle - 270)
            c1 = Ipotenusa * Math.Sin(sAngle)
            c2 = Ipotenusa * Math.Cos(sAngle)
            Return New SizeF(-c2, -c1)
        End If

        If sAngle = 0 Then
            c1 = 0
            c2 = Ipotenusa
        ElseIf sAngle = 180 Then
            c1 = Ipotenusa
            c2 = 0
        ElseIf sAngle > 180 Then
            sAngle -= 180
            sAngle = DegreeToRadians(Angle)
            c1 = Ipotenusa * Math.Cos(sAngle)
            c2 = Ipotenusa * Math.Sin(sAngle)
        Else
            sAngle = DegreeToRadians(Angle)
            c1 = Ipotenusa * Math.Sin(sAngle)
            c2 = Ipotenusa * Math.Cos(sAngle)
        End If
        Return New SizeF(c2, c1)
    End Function

    Public Function RotatePointAt(ByVal Angle As Decimal, ByVal Center As PointD, ByVal Point As PointD) As PointD
        Dim dAngle As Decimal = DegreeToRadians(Angle)
        Return New PointD(Math.Cos(dAngle) * (Point.X - Center.X) - Math.Sin(dAngle) * (Point.Y - Center.Y) + Center.X, Math.Sin(dAngle) * (Point.X - Center.X) + Math.Cos(dAngle) * (Point.Y - Center.Y) + Center.Y)
    End Function

    Public Function RotatePointAt(ByVal Angle As Single, ByVal Center As PointF, ByVal Point As PointF) As PointF
        Dim sAngle As Single = DegreeToRadians(Angle)
        Return New PointF(Math.Cos(sAngle) * (Point.X - Center.X) - Math.Sin(sAngle) * (Point.Y - Center.Y) + Center.X, Math.Sin(sAngle) * (Point.X - Center.X) + Math.Cos(sAngle) * (Point.Y - Center.Y) + Center.Y)
    End Function

    Public Function RotatePointByRadians(X As Decimal, Y As Decimal, Angle As Decimal) As PointD
        Return New PointD(X * Math.Cos(Angle) - Y * Math.Sin(Angle), X * Math.Sin(Angle) + Y * Math.Cos(Angle))
    End Function

    Public Function RotatePointByRadians(X As Single, Y As Single, Angle As Single) As PointF
        Return New PointF(X * Math.Cos(Angle) - Y * Math.Sin(Angle), X * Math.Sin(Angle) + Y * Math.Cos(Angle))
    End Function

    Public Function RotatePointByRadians(Point As PointF, Angle As Single) As PointF
        Return RotatePointByRadians(Point.X, Point.Y, Angle)
    End Function

    Public Function RotatePointByRadians(Point As PointD, Angle As Decimal) As PointD
        Return RotatePointByRadians(Point.X, Point.Y, Angle)
    End Function

    Public Function RotatePoint(X As Decimal, Y As Decimal, Angle As Decimal) As PointD
        Dim dAngle As Decimal = DegreeToRadians(Angle)
        Return New PointD(X * Math.Cos(dAngle) - Y * Math.Sin(dAngle), X * Math.Sin(dAngle) + Y * Math.Cos(dAngle))
    End Function

    Public Function RotatePoint(X As Single, Y As Single, Angle As Single) As PointF
        Dim sAngle As Single = DegreeToRadians(Angle)
        Return New PointF(X * Math.Cos(sAngle) - Y * Math.Sin(sAngle), X * Math.Sin(sAngle) + Y * Math.Cos(sAngle))
    End Function

    Public Function RotatePoint(X As Integer, Y As Integer, Angle As Single) As Point
        Dim sAngle As Single = DegreeToRadians(Angle)
        Return New Point(X * Math.Cos(sAngle) - Y * Math.Sin(sAngle), X * Math.Sin(sAngle) + Y * Math.Cos(sAngle))
    End Function

    Public Function RotatePoint(Point As Point, Angle As Single) As Point
        Return RotatePoint(Point.X, Point.Y, Angle)
    End Function

    Public Function RotatePoint(Point As PointF, Angle As Single) As PointF
        Return RotatePoint(Point.X, Point.Y, Angle)
    End Function

    Public Function RotatePoint(Point As PointD, Angle As Decimal) As PointD
        Return RotatePoint(Point.X, Point.Y, Angle)
    End Function

    Public Function Trigo(ByVal Ipotenusa As Decimal, ByVal Angle As Decimal) As SizeD
        Dim sAngle As Decimal = NormalizeAngle(Angle)
        Dim c1 As Decimal
        Dim c2 As Decimal

        If sAngle = 0 Then
            c1 = Ipotenusa
            c2 = 0
            Return New SizeD(c2, -c1)
        ElseIf sAngle > 0 AndAlso sAngle < 90 Then
            sAngle = DegreeToRadians(Angle)
            c1 = Ipotenusa * Math.Cos(sAngle)
            c2 = Ipotenusa * Math.Sin(sAngle)
            Return New SizeD(c2, -c1)
        ElseIf sAngle = 90 Then
            c1 = 0
            c2 = Ipotenusa
            Return New SizeD(c2, c1)
        ElseIf sAngle > 90 AndAlso sAngle < 180 Then
            sAngle = DegreeToRadians(Angle - 90)
            c1 = Ipotenusa * Math.Sin(sAngle)
            c2 = Ipotenusa * Math.Cos(sAngle)
            Return New SizeF(c2, c1)
        ElseIf sAngle = 180 Then
            c1 = Ipotenusa
            c2 = 0
            Return New SizeD(c2, c1)
        ElseIf sAngle > 180 AndAlso sAngle < 270 Then
            sAngle = DegreeToRadians(Angle - 180)
            c1 = Ipotenusa * Math.Cos(sAngle)
            c2 = Ipotenusa * Math.Sin(sAngle)
            Return New SizeD(-c2, c1)
        ElseIf sAngle = 270 Then
            c1 = 0
            c2 = Ipotenusa
            Return New SizeD(-c2, c1)
        ElseIf sAngle > 270 AndAlso sAngle < 360 Then
            sAngle = DegreeToRadians(Angle - 270)
            c1 = Ipotenusa * Math.Sin(sAngle)
            c2 = Ipotenusa * Math.Cos(sAngle)
            Return New SizeD(-c2, -c1)
        End If

        'If sAngle = 0 Then
        '    c1 = 0
        '    c2 = Ipotenusa
        'ElseIf sAngle = 180 Then
        '    c1 = Ipotenusa
        '    c2 = 0
        'ElseIf sAngle > 180 Then
        '    sAngle -= 180
        '    sAngle = DegreeToRadians(Angle)
        '    c1 = Ipotenusa * Math.Cos(sAngle)
        '    c2 = Ipotenusa * Math.Sin(sAngle)
        'Else
        '    sAngle = DegreeToRadians(Angle)
        '    c1 = Ipotenusa * Math.Sin(sAngle)
        '    c2 = Ipotenusa * Math.Cos(sAngle)
        'End If
        'Return New SizeD(c2, c1)
    End Function

    Public Function DistancePointToPoint(ByVal p0 As Point, ByVal p1 As Point, Optional ByRef near_x As Integer = 0, Optional ByRef near_y As Integer = 0) As Integer
        Dim dx As Integer
        Dim dy As Integer
        dx = p0.X - p1.X
        dy = p0.Y - p1.Y
        near_x = p1.X
        near_y = p1.Y
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

    Public Function DistancePointToPoint(ByVal p0 As PointD, ByVal p1 As PointD, Optional ByRef near_x As Decimal = 0, Optional ByRef near_y As Decimal = 0) As Decimal
        Dim dx As Decimal
        Dim dy As Decimal
        dx = p0.X - p1.X
        dy = p0.Y - p1.Y
        near_x = p1.X
        near_y = p1.Y
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

    Public Function DistancePointToPoint(ByVal p0 As PointF, ByVal p1 As PointF, Optional ByRef near_x As Single = 0, Optional ByRef near_y As Single = 0) As Single
        Dim dx As Single
        Dim dy As Single
        dx = p0.X - p1.X
        dy = p0.Y - p1.Y
        near_x = p1.X
        near_y = p1.Y
        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

    Public Function DistancePointToSegment(ByVal p0 As PointF, ByVal p1 As PointF, ByVal p2 As PointF, Optional ByRef near_x As Single = 0, Optional ByRef near_y As Single = 0) As Single
        Dim dx As Single
        Dim dy As Single
        Dim t As Single

        dx = p2.X - p1.X
        dy = p2.Y - p1.Y
        If dx = 0 AndAlso dy = 0 Then
            ' It's a point not a line segment.
            dx = p0.X - p1.X
            dy = p0.Y - p1.Y
            near_x = p1.X
            near_y = p1.Y
            Return Math.Sqrt(dx * dx + dy * dy)
        End If

        ' Calculate the t that minimizes the distance.
        t = ((p0.X - p1.X) * dx + (p0.Y - p1.Y) * dy) / (dx * dx + dy * dy)

        ' See if this represents one of the segment's
        ' end points orelse a point in the middle.
        If t < 0 Then
            dx = p0.X - p1.X
            dy = p0.Y - p1.Y
            near_x = p1.X
            near_y = p1.Y
        ElseIf t > 1 Then
            dx = p0.X - p2.X
            dy = p0.Y - p2.Y
            near_x = p2.X
            near_y = p2.Y
        Else
            near_x = p1.X + t * dx
            near_y = p1.Y + t * dy
            dx = p0.X - near_x
            dy = p0.Y - near_y
        End If

        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

    Public Function DistancePointToSegment(ByVal p0 As PointD, ByVal p1 As PointD, ByVal p2 As PointD, Optional ByRef near_x As Decimal = 0, Optional ByRef near_y As Decimal = 0) As Decimal
        Dim dx As Decimal
        Dim dy As Decimal
        Dim t As Decimal

        dx = p2.X - p1.X
        dy = p2.Y - p1.Y
        If dx = 0 AndAlso dy = 0 Then
            ' It's a point not a line segment.
            dx = p0.X - p1.X
            dy = p0.Y - p1.Y
            near_x = p1.X
            near_y = p1.Y
            Return Math.Sqrt(dx * dx + dy * dy)
        End If

        ' Calculate the t that minimizes the distance.
        t = ((p0.X - p1.X) * dx + (p0.Y - p1.Y) * dy) / (dx * dx + dy * dy)

        ' See if this represents one of the segment's
        ' end points orelse a point in the middle.
        If t < 0 Then
            dx = p0.X - p1.X
            dy = p0.Y - p1.Y
            near_x = p1.X
            near_y = p1.Y
        ElseIf t > 1 Then
            dx = p0.X - p2.X
            dy = p0.Y - p2.Y
            near_x = p2.X
            near_y = p2.Y
        Else
            near_x = p1.X + t * dx
            near_y = p1.Y + t * dy
            dx = p0.X - near_x
            dy = p0.Y - near_y
        End If

        Return Math.Sqrt(dx * dx + dy * dy)
    End Function

    Public Function SegmentsIntersect(ByVal Point11 As PointF, ByVal Point12 As PointF, ByVal Point21 As PointF, ByVal Point22 As PointF) As Boolean
        Dim dx1 As Single = Point12.X - Point11.X
        Dim dy1 As Single = Point12.Y - Point11.Y
        Dim dx2 As Single = Point22.X - Point21.X
        Dim dy2 As Single = Point22.Y - Point21.Y

        If (dx2 * dy1 - dy2 * dx1) = 0 Then
            ' The segments are parallel.
            Return False
        End If

        Dim s As Single = (dx1 * (Point22.Y - Point11.Y) + dy1 * (Point11.X - Point21.X)) / (dx2 * dy1 - dy2 * dx1)
        Dim t As Single = (dx2 * (Point11.Y - Point22.Y) + dy2 * (Point21.X - Point11.X)) / (dy2 * dx1 - dx2 * dy1)
        Return (s >= 0# And s <= 1.0# And t >= 0# And t <= 1.0#)

        ' If it exists, the point of intersection is:
        ' (x1 + t * dx, y1 + t * dy)
    End Function

    Public Function FindSegmentIntersection(ByVal Point11 As PointF, ByVal Point12 As PointF, ByVal Point21 As PointF, ByVal Point22 As PointF, ByRef Intersect As Boolean) As PointF
        Dim dx1 As Single = Point12.X - Point11.X
        Dim dy1 As Single = Point12.Y - Point11.Y
        Dim dx2 As Single = Point22.X - Point21.X
        Dim dy2 As Single = Point22.Y - Point21.Y
        Dim d As Single = (dy1 * dx2 - dx1 * dy2)
        Dim t1 As Single = ((Point11.X - Point21.X) * dy2 + (Point21.Y - Point11.Y) * dx2) / d
        If Single.IsInfinity(t1) Then
            Intersect = False
            Return Nothing
        Else
            Dim t2 As Single = ((Point21.X - Point11.X) * dy1 + (Point11.Y - Point21.Y) * dx1) / -d
            If ((t1 >= 0) AndAlso (t1 <= 1) AndAlso (t2 >= 0) AndAlso (t2 <= 1)) Then
                Intersect = True
                Return New PointF(Point11.X + dx1 * t1, Point11.Y + dy1 * t1)
            Else
                Intersect = False
                Return Nothing
            End If
        End If
    End Function

    Public Function FindLineIntersection(ByVal Point11 As PointF, ByVal Point12 As PointF, ByVal Point21 As PointF, ByVal Point22 As PointF, ByRef AreParallel As Boolean) As PointF
        Dim dx1 As Single = Point12.X - Point11.X
        Dim dy1 As Single = Point12.Y - Point11.Y
        Dim dx2 As Single = Point22.X - Point21.X
        Dim dy2 As Single = Point22.Y - Point21.Y
        Dim d As Single = (dy1 * dx2 - dx1 * dy2)
        Dim t1 As Single = ((Point11.X - Point21.X) * dy2 + (Point21.Y - Point11.Y) * dx2) / d
        If Single.IsInfinity(t1) Then
            AreParallel = True
            Return Nothing
        Else
            't2 = ((Point21.X - Point11.X) * dy1 + (Point11.Y - Point21.Y) * dx1) / -d
            AreParallel = False
            Return New PointF(Point11.X + dx1 * t1, Point11.Y + dy1 * t1)
        End If
    End Function

    Public Function GetFormattedTrigpointText(Survey As cSurvey.cSurvey, TextStructure As cITextStructure, Trigpoint As cTrigPoint) As String
        Return pGetFormattedTrigpointText(Survey, Trigpoint, TextStructure.TrigPointStructure)
    End Function

    Public Function GetFormattedSpecialTrigpointText(Survey As cSurvey.cSurvey, TextStructure As cITextStructure, Trigpoint As cTrigPoint) As String
        Return pGetFormattedTrigpointText(Survey, Trigpoint, TextStructure.SpecialTrigPointStructure)
    End Function

    Private Function pGetFormattedTrigpointText(Survey As cSurvey.cSurvey, Trigpoint As cTrigPoint, Text As String)
        If Text <> "" Then
            Text = ReplaceStationTags(Survey, Trigpoint, Text)
            Text = modPaint.ReplaceGlobalTags(Survey, Text)
            Return Text
        Else
            Return Trigpoint.Name
        End If
    End Function

    Private Sub pNamesCollectionMerge(Names As List(Of String), NewNames As String)
        Dim oNewNames As List(Of String) = New List(Of String)(NewNames.Split({";"}, StringSplitOptions.RemoveEmptyEntries))
        Call Names.Union(oNewNames)
    End Sub

    Public Function ImageExifRotate(Image As Image) As Image
        Dim oProperties As PropertyItem() = Image.PropertyItems
        Dim iRotate As RotateFlipType
        For Each p As PropertyItem In oProperties
            If p.Id = 274 Then
                Select Case BitConverter.ToInt16(p.Value, 0)
                    Case 1
                        iRotate = RotateFlipType.RotateNoneFlipNone
                    Case 3
                        iRotate = RotateFlipType.Rotate180FlipNone
                    Case 6
                        iRotate = RotateFlipType.Rotate90FlipNone
                    Case 8
                        iRotate = RotateFlipType.Rotate270FlipNone
                End Select
            End If
        Next
        If iRotate <> RotateFlipType.RotateNoneFlipNone Then
            Call Image.RotateFlip(iRotate)
        End If
        Return Image
    End Function

    Public Function ReplaceItemTags(Survey As cSurvey.cSurvey, Item As cItem, Text As String) As String
        Text = ReplaceGlobalTags(Survey, Text)
        Text = Text.Replace("%CAVE%", Item.Cave)
        Text = Text.Replace("%BRANCH%", Item.Branch)

        Text = Text.Replace("%C%", Item.Layer.Items.Count)
        Text = Text.Replace("%I%", Item.Layer.Items.IndexOf(Item))

        Return Text.Trim
    End Function

    Public Function ReplaceStationTags(Survey As cSurvey.cSurvey, Trigpoint As cTrigPoint, Text As String) As String
        Dim oProperties As cProperties = Survey.Properties

        Text = Text.Replace("%NAME%", Trigpoint.Name)
        If Trigpoint.Aliases.Count > 0 Then
            Text = Text.Replace("%FIRSTALIAS%", Trigpoint.Aliases(0))
        Else
            Text = Text.Replace("%FIRSTALIAS%", "")
        End If
        Text = Text.Replace("%NOTE%", Trigpoint.Note)

        Text = Text.Replace("%CAVEID%", oProperties.ID)
        Text = Text.Replace("%CAVENAME%", oProperties.Name)

        If Trigpoint.Coordinate.IsEmpty Then
            Text = Text.Replace("%GEOPOS%", "")
            Text = Text.Replace("%GEOPOSLAT%", "")
            Text = Text.Replace("%GEOPOSLONG%", "")
            Text = Text.Replace("%GEOPOSALT%", "")
        Else
            With Trigpoint
                Text = Text.Replace("%GEOPOS%", modNumbers.NumberToCoordinate(.Coordinate.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "N", "S") & " " & modNumbers.NumberToCoordinate(.Coordinate.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSLAT%", modNumbers.NumberToCoordinate(.Coordinate.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "N", "S"))
                Text = Text.Replace("%GEOPOSLONG%", modNumbers.NumberToCoordinate(.Coordinate.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSALT%", modNumbers.NumberToString(.Coordinate.GetAltitude, "0"))
            End With
        End If

        Dim oCalculatedTrigpoint As Calculate.cTrigPoint = Survey.Calculate.TrigPoints(Trigpoint)
        If oCalculatedTrigpoint.Coordinate.IsEmpty Then
            Text = Text.Replace("%GEOPOSCALC%", "")
            Text = Text.Replace("%GEOPOSLATCALC%", "")
            Text = Text.Replace("%GEOPOSLONGCALC%", "")
            Text = Text.Replace("%GEOPOSLONCALC%", "")
            Text = Text.Replace("%GEOPOSALTCALC%", "")
            Text = Text.Replace("%TOSURFACEV%", "N/D")
            Text = Text.Replace("%SURFACEV%", "N/D")
        Else
            With oCalculatedTrigpoint
                Text = Text.Replace("%GEOPOSCALC%", modNumbers.NumberToCoordinate(.Coordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "N", "S") & " " & modNumbers.NumberToCoordinate(.Coordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSLATCALC%", modNumbers.NumberToCoordinate(.Coordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "N", "S"))
                Text = Text.Replace("%GEOPOSLONGCALC%", modNumbers.NumberToCoordinate(.Coordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSLONCALC%", modNumbers.NumberToCoordinate(.Coordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds OrElse CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSALTCALC%", modNumbers.NumberToString(.Coordinate.Altitude, "0"))

                If Survey.Properties.SurfaceProfileElevation Is Nothing Then
                    Text = Text.Replace("%TOSURFACEV%", "N/D")
                    Text = Text.Replace("%SURFACEV%", "N/D")
                Else
                    Dim sSurfaceV As Single = Survey.Properties.SurfaceProfileElevation.GetElevation(Trigpoint)
                    If sSurfaceV = Survey.Properties.SurfaceProfileElevation.NoDataValue Then
                        Text = Text.Replace("%SURFACEV%", "#")
                        Text = Text.Replace("%TOSURFACEV%", "#")
                    Else
                        Text = Text.Replace("%SURFACEV%", modNumbers.NumberToString(sSurfaceV, "0"))
                        Text = Text.Replace("%TOSURFACEV%", modNumbers.NumberToString(sSurfaceV - .Coordinate.Altitude, "0"))
                    End If
                End If
            End With
        End If

        Text = Text.Replace("%BR%", vbCrLf)
        Text = Text.Replace("%TAB%", vbTab)

        Return Text.Trim
    End Function

    Public Function ReplaceGlobalTags(Survey As cSurvey.cSurvey, Text As String) As String
        Dim oProperties As cProperties = Survey.Properties
        Text = Text.Replace("%ID%", oProperties.ID)
        Text = Text.Replace("%NAME%", oProperties.Name)
        Text = Text.Replace("%DESCRIPTION%", oProperties.Description)
        Text = Text.Replace("%AUTHOR%", oProperties.Author)

        Text = Text.Replace("%CLUB%", oProperties.Club)
        Text = Text.Replace("%TEAM%", oProperties.Team)
        Text = Text.Replace("%DESIGNER%", oProperties.Designer)

        Text = Text.Replace("%NOTE%", oProperties.Note)

        Text = Text.Replace("%GA%", oProperties.DefGrade & oProperties.DefAccuracy)

        Dim oSessionsClub As List(Of String) = New List(Of String)
        Call pNamesCollectionMerge(oSessionsClub, oProperties.Club)
        Dim oSessionsTeam As List(Of String) = New List(Of String)
        Call pNamesCollectionMerge(oSessionsTeam, oProperties.Team)
        Dim oSessionsDesigner As List(Of String) = New List(Of String)
        Call pNamesCollectionMerge(oSessionsDesigner, oProperties.Designer)

        Dim iIndex As Integer = 0
        For Each oSession As cSession In Survey.Properties.Sessions
            iIndex += 1
            Text = Text.Replace("%SESSIONDATE(" & iIndex & ")%", oSession.Date)
            Text = Text.Replace("%SESSIONYEAR(" & iIndex & ")%", oSession.Date.Year)
            Text = Text.Replace("%SESSIONCLUB(" & iIndex & ")%", oSession.Club)
            Call pNamesCollectionMerge(oSessionsClub, oSession.Club)
            Text = Text.Replace("%SESSIONTEAM(" & iIndex & ")%", oSession.Team)
            Call pNamesCollectionMerge(oSessionsTeam, oSession.Team)
            Text = Text.Replace("%SESSIONDESIGNER(" & iIndex & ")%", oSession.Designer)
            Call pNamesCollectionMerge(oSessionsDesigner, oSession.Designer)
            Text = Text.Replace("%SESSIONNOTE(" & iIndex & ")%", oSession.Note)
        Next
        Text = Text.Replace("%SESSIONCLUB(*)%", Strings.Join(oSessionsClub.ToArray, ", "))
        Text = Text.Replace("%SESSIONTEAM(*)%", Strings.Join(oSessionsTeam.ToArray, ", "))
        Text = Text.Replace("%SESSIONDESIGNER(*)%", Strings.Join(oSessionsDesigner.ToArray, ", "))

        If oProperties.Sessions.FirstSession Is Nothing Then
            Text = Text.Replace("%YEARRANGE%", "")
        Else
            If oProperties.Sessions.Count = 1 Then
                Text = Text.Replace("%YEARRANGE%", oProperties.Sessions.FirstSession.Date.Year)
            Else
                Text = Text.Replace("%YEARRANGE%", oProperties.Sessions.FirstSession.Date.Year & " - " & oProperties.Sessions.LastSession.Date.Year)
            End If
        End If

        If oProperties.Sessions.FirstSession Is Nothing Then
            Text = Text.Replace("%FIRSTSESSIONDATE%", "")
            Text = Text.Replace("%FIRSTSESSIONYEAR%", "")
            Text = Text.Replace("%FIRSTSESSIONCLUB%", "")
            Text = Text.Replace("%FIRSTSESSIONTEAM%", "")
            Text = Text.Replace("%FIRSTSESSIONDESIGNER%", "")
            Text = Text.Replace("%FIRSTSESSIONNOTE%", "")
        Else
            Text = Text.Replace("%FIRSTSESSIONDATE%", oProperties.Sessions.FirstSession.Date)
            Text = Text.Replace("%FIRSTSESSIONYEAR%", oProperties.Sessions.FirstSession.Date.Year)
            Text = Text.Replace("%FIRSTSESSIONCLUB%", oProperties.Sessions.FirstSession.Club)
            Text = Text.Replace("%FIRSTSESSIONTEAM%", oProperties.Sessions.FirstSession.Team)
            Text = Text.Replace("%FIRSTSESSIONDESIGNER%", oProperties.Sessions.FirstSession.Designer)
            Text = Text.Replace("%FIRSTSESSIONNOTE%", oProperties.Sessions.FirstSession.Note)
        End If

        If oProperties.Sessions.LastSession Is Nothing Then
            Text = Text.Replace("%LASTSESSIONDATE%", "")
            Text = Text.Replace("%LASTSESSIONYEAR%", "")
            Text = Text.Replace("%LASTSESSIONCLUB%", "")
            Text = Text.Replace("%LASTSESSIONTEAM%", "")
            Text = Text.Replace("%LASTSESSIONDESIGNER%", "")
            Text = Text.Replace("%LASTSESSIONNOTE%", "")
        Else
            Text = Text.Replace("%LASTSESSIONDATE%", oProperties.Sessions.LastSession.Date)
            Text = Text.Replace("%LASTSESSIONYEAR%", oProperties.Sessions.LastSession.Date.Year)
            Text = Text.Replace("%LASTSESSIONCLUB%", oProperties.Sessions.LastSession.Club)
            Text = Text.Replace("%LASTSESSIONTEAM%", oProperties.Sessions.LastSession.Team)
            Text = Text.Replace("%LASTSESSIONDESIGNER%", oProperties.Sessions.FirstSession.Designer)
            Text = Text.Replace("%LASTSESSIONNOTE%", oProperties.Sessions.LastSession.Note)
        End If

        Dim sDistanceSimbol As String = cSegment.GetDistanceSimbol(Survey.Properties.DistanceType)
        Dim iDistanceDecimalPlace As Integer = modConversion.GetDistanceTypeDecimalPlaces(Survey.Properties.DistanceType)

        Dim oGPSRef As cTrigPoint = Survey.TrigPoints.GetGPSBaseReferencePoint
        If oGPSRef Is Nothing OrElse Not Survey.Calculate.TrigPoints.Contains(oGPSRef.Name) Then
            Text = Text.Replace("%GEOPOS%", "")
            Text = Text.Replace("%GEOPOSLAT%", "")
            Text = Text.Replace("%GEOPOSLONG%", "")
            Text = Text.Replace("%GEOPOSLON%", "")
            Text = Text.Replace("%GEOPOSALT%", "")

            Text = Text.Replace("%GEOPOSUTM%", "")
            Text = Text.Replace("%GEOPOSUTMX%", "")
            Text = Text.Replace("%GEOPOSUTMY%", "")
            Text = Text.Replace("%GEOPOSUTMBAND%", "")
            Text = Text.Replace("%GEOPOSUTMZONE%", "")
        Else
            Dim oEntranceCoordinate As Calculate.cTrigPointCoordinate = Survey.Calculate.TrigPoints(oGPSRef.Name).Coordinate
            Text = Text.Replace("%GEOPOS%", modNumbers.NumberToCoordinate(oEntranceCoordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S") & " " & modNumbers.NumberToCoordinate(oEntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
            Text = Text.Replace("%GEOPOSLAT%", modNumbers.NumberToCoordinate(oEntranceCoordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S"))
            Text = Text.Replace("%GEOPOSLONG%", modNumbers.NumberToCoordinate(oEntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
            Text = Text.Replace("%GEOPOSLON%", modNumbers.NumberToCoordinate(oEntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
            Text = Text.Replace("%GEOPOSALT%", modNumbers.MathRound(oEntranceCoordinate.Altitude, iDistanceDecimalPlace) & " " & sDistanceSimbol)

            If Text.Contains("%GEOPOSUTM") Then
                Dim oEntranceCoordinateUTM As modUTM.UTM = modUTM.WGS84ToUTM(oEntranceCoordinate)
                Text = Text.Replace("%GEOPOSUTM%", Strings.Format(oEntranceCoordinateUTM.East, "0") & " " & Strings.Format(oEntranceCoordinateUTM.North, "0") & " " & oEntranceCoordinateUTM.Zone & oEntranceCoordinateUTM.Band)
                Text = Text.Replace("%GEOPOSUTMX%", Strings.Format(oEntranceCoordinateUTM.East, "0"))
                Text = Text.Replace("%GEOPOSUTMY%", Strings.Format(oEntranceCoordinateUTM.North, "0"))
                Text = Text.Replace("%GEOPOSUTMBAND%", oEntranceCoordinateUTM.Band)
                Text = Text.Replace("%GEOPOSUTMZONE%", oEntranceCoordinateUTM.Zone)
            End If
        End If

        Text = Text.Replace("%BR%", vbCrLf)
        Text = Text.Replace("%TAB%", vbTab)

        For Each oSpeleometric As Calculate.Plot.cSpeleometric In Survey.Calculate.Speleometrics
            Dim sPath As String
            If oSpeleometric.Branch = "" Then
                sPath = oSpeleometric.Cave
            Else
                sPath = oSpeleometric.Cave & "," & oSpeleometric.Branch
            End If
            If Survey.Properties.CaveInfos.Contains(oSpeleometric.Cave) Then
                With Survey.Properties.CaveInfos(oSpeleometric.Cave)
                    Text = Text.Replace("%NAME(" & sPath & ")%", .Name)
                    Text = Text.Replace("%ID(" & sPath & ")%", .ID)
                    Text = Text.Replace("%DESCRIPTION(" & sPath & ")%", .Description)
                End With
            End If

            Dim sDefaultLength As String = modNumbers.MathRound(oSpeleometric.DefaultLength, iDistanceDecimalPlace)
            Text = Text.Replace("%SVILTOT(" & sPath & ")%", sDefaultLength & " " & sDistanceSimbol)
            Text = Text.Replace("%LEN(" & sPath & ")%", sDefaultLength & " " & sDistanceSimbol)

            Dim sDefaultPlanimetricLength As String = modNumbers.MathRound(oSpeleometric.DefaultPlanimetricLength, iDistanceDecimalPlace)
            Text = Text.Replace("%SVILPLAN(" & sPath & ")%", sDefaultPlanimetricLength & " " & sDistanceSimbol)
            Text = Text.Replace("%PLANLEN(" & sPath & ")%", sDefaultPlanimetricLength & " " & sDistanceSimbol)
             
            Dim sDefaultPositiveVerticalRange As String = modNumbers.MathRound(oSpeleometric.DefaultPositiveVerticalRange.GetValueOrDefault(0), iDistanceDecimalPlace)
            Text = Text.Replace("%DISPOS(" & sPath & ")%", sDefaultPositiveVerticalRange & " " & sDistanceSimbol)
            Text = Text.Replace("%PVRNG(" & sPath & ")%", sDefaultPositiveVerticalRange & " " & sDistanceSimbol)

            Dim sDefaultNegativeVerticalRange As String = modNumbers.MathRound(oSpeleometric.DefaultNegativeVerticalRange.GetValueOrDefault(0), iDistanceDecimalPlace)
            Text = Text.Replace("%DISNEG(" & sPath & ")%", sDefaultNegativeVerticalRange & " " & sDistanceSimbol)
            Text = Text.Replace("%NVRNG(" & sPath & ")%", sDefaultNegativeVerticalRange & " " & sDistanceSimbol)

            Dim sVerticalRange As String = modNumbers.MathRound(oSpeleometric.VerticalRange, iDistanceDecimalPlace)
            Text = Text.Replace("%DIS(" & sPath & ")%", sVerticalRange & " " & sDistanceSimbol)
            Text = Text.Replace("%DISTOT(" & sPath & ")%", sVerticalRange & " " & sDistanceSimbol)
            Text = Text.Replace("%VRNG(" & sPath & ")%", sVerticalRange & " " & sDistanceSimbol)

            Dim sSegmentCount As String = oSpeleometric.SegmentCount
            Text = Text.Replace("%SEGCOUNT(" & sPath & ")%", sSegmentCount)
            Dim sExcludedSegmentCount As String = oSpeleometric.ExcludedSegmentCount
            Text = Text.Replace("%EXSEGCOUNT(" & sPath & ")%", sExcludedSegmentCount)

            If oSpeleometric.EntranceCoordinate Is Nothing Then
                Text = Text.Replace("%GEOPOS(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSLAT(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSLONG(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSLON(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSALT(" & sPath & ")%", "")

                Text = Text.Replace("%GEOPOSUTM(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSUTMX(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSUTMY(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSUTMBAND(" & sPath & ")%", "")
                Text = Text.Replace("%GEOPOSUTMZONE(" & sPath & ")%", "")
            Else
                Text = Text.Replace("%GEOPOS(" & sPath & ")%", modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S") & " " & modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSLAT(" & sPath & ")%", modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Latitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S"))
                Text = Text.Replace("%GEOPOSLONG(" & sPath & ")%", modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSLON(" & sPath & ")%", modNumbers.NumberToCoordinate(oSpeleometric.EntranceCoordinate.Longitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"))
                Text = Text.Replace("%GEOPOSALT(" & sPath & ")%", modNumbers.MathRound(oSpeleometric.EntranceCoordinate.Altitude, iDistanceDecimalPlace) & " " & sDistanceSimbol)

                If Text.Contains("%GEOPOSUTM") Then
                    Dim oEntranceCoordinateUTM As modUTM.UTM = modUTM.WGS84ToUTM(oSpeleometric.EntranceCoordinate)
                    Text = Text.Replace("%GEOPOSUTM(" & sPath & ")%", oEntranceCoordinateUTM.Zone & oEntranceCoordinateUTM.Band & " " & Strings.Format(oEntranceCoordinateUTM.East, "0") & " " & Strings.Format(oEntranceCoordinateUTM.North, "0"))
                    Text = Text.Replace("%GEOPOSUTMX(" & sPath & ")%", Strings.Format(oEntranceCoordinateUTM.East, "0"))
                    Text = Text.Replace("%GEOPOSUTMY(" & sPath & ")%", Strings.Format(oEntranceCoordinateUTM.North, "0"))
                    Text = Text.Replace("%GEOPOSUTMBAND(" & sPath & ")%", oEntranceCoordinateUTM.Band)
                    Text = Text.Replace("%GEOPOSUTMZONE(" & sPath & ")%", oEntranceCoordinateUTM.Zone)
                End If
            End If
        Next

        Return Text.Trim
    End Function

    Public Function GetFormattedInfoBoxText(Survey As cSurvey.cSurvey, TextStructure As cITextStructure) As String
        If TextStructure.InfoBoxStructure <> "" Then
            Dim sTemp As String = TextStructure.InfoBoxStructure
            Return ReplaceGlobalTags(Survey, sTemp)
        Else
            Return ""
        End If
    End Function

    Public Function GetCenterPoint(Point1 As PointD, Point2 As PointD) As PointD
        Return New PointD((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2)
    End Function

    Public Function GetCenterPoint(Point1 As Point, Point2 As Point) As Point
        Return New Point((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2)
    End Function

    Public Function GetCenterPoint(Point1 As PointF, Point2 As PointF) As PointF
        Return New PointF((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2)
    End Function

    Public Function GetCenterPoint(Rectangle As RectangleF) As PointF
        Return New PointF(Rectangle.Location.X + Rectangle.Size.Width / 2, Rectangle.Location.Y + Rectangle.Size.Height / 2)
    End Function

    Public Function GetCenterPoint(Rectangle As Rectangle) As Point
        Return New Point(Rectangle.Location.X + Rectangle.Size.Width / 2, Rectangle.Location.Y + Rectangle.Size.Height / 2)
    End Function

    Public Function TransparentColor(ByVal color As Color, ByVal Alpha As Integer) As Color
        Return Color.FromArgb(Alpha, color)
    End Function

    Public Function GrayColor(Color As Color) As Color
        Dim r As Integer = Color.R
        Dim g As Integer = Color.G
        Dim b As Integer = Color.B
        Dim m As Integer = (r + g + b) / 3
        Return Color.FromArgb(Color.A, m, m, m)
    End Function

    Public Function LightColor(ByVal Color As Color, ByVal Percentage As Single) As Color
        Dim r As Integer = Color.R
        Dim g As Integer = Color.G
        Dim b As Integer = Color.B
        Dim dr As Integer = (255 - r) * Percentage
        Dim dg As Integer = (255 - g) * Percentage
        Dim db As Integer = (255 - b) * Percentage
        r = r + dr : If r > 255 Then r = 255
        g = g + dg : If g > 255 Then g = 255
        b = b + db : If b > 255 Then b = 255
        Return Color.FromArgb(Color.A, r, g, b)
    End Function

    Public Function DarkColor(ByVal Color As Color, ByVal Percentage As Single) As Color
        Dim r As Integer = Color.R
        Dim g As Integer = Color.G
        Dim b As Integer = Color.B
        Dim dr As Integer = r * Percentage
        Dim dg As Integer = g * Percentage
        Dim db As Integer = b * Percentage
        r = r + dr : If r > 255 Then r = 255
        g = g + dg : If g > 255 Then g = 255
        b = b + db : If b > 255 Then b = 255
        Return Color.FromArgb(Color.A, r, g, b)
    End Function

    Public Sub Testalt()
        Dim oPoint0 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(0, 0, 0)
        Dim oPoint1 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(10, 0, 10)
        Dim oPoint2 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(0, -10, 1)
        Dim oPoint3 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(10, -10, 20)

        Dim oPoint As PointF = New PointF(5, -5)

        Debug.Print(GetAltitude({oPoint0, oPoint1, oPoint2, oPoint3}, oPoint))
    End Sub

    Public Function GetAltitude(Quad As Single(), QuadSizeX As Single, QuadSizeY As Single, Point As PointF) As Single
        'quad=tl,tr,bl,br
        'point0-point1=line
        Dim oPoint0 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(0, 0, Quad(0))
        Dim oPoint1 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(QuadSizeX, 0, Quad(1))
        Dim oPoint2 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(0, QuadSizeY, Quad(2))
        Dim oPoint3 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(QuadSizeX, QuadSizeY, Quad(3))
        Return GetAltitude({oPoint0, oPoint1, oPoint2, oPoint3}, Point)
    End Function

    Public Function GetAltitude(Quad As Single(), QuadSize As Single, Point As PointF) As Single
        'quad=tl,tr,bl,br
        'point0-point1=line
        Dim oPoint0 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(0, 0, Quad(0))
        Dim oPoint1 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(QuadSize, 0, Quad(1))
        Dim oPoint2 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(0, QuadSize, Quad(2))
        Dim oPoint3 As Windows.Media.Media3D.Point3D = New Windows.Media.Media3D.Point3D(QuadSize, QuadSize, Quad(3))
        Return GetAltitude({oPoint0, oPoint1, oPoint2, oPoint3}, Point)
    End Function

    Public Function GetAltitude(Quad As Windows.Media.Media3D.Point3D(), Point As PointF) As Single
        'quad=tl,tr,bl,br
        'point0-point1=line
        Dim oPointTL As PointF = New PointF(Quad(0).X, Quad(0).Z)
        Dim oPointTR As PointF = New PointF(Quad(1).X, Quad(1).Z)
        Dim sPercentT As Single = (Point.X - Quad(0).X) / (Quad(1).X - Quad(0).X)
        Dim oPointT As PointF = PointOnLineByPercentage(oPointTL, oPointTR, sPercentT)

        Dim oPointBL As PointF = New PointF(Quad(2).X, Quad(2).Z)
        Dim oPointBR As PointF = New PointF(Quad(3).X, Quad(3).Z)
        Dim sPercentB As Single = (Point.X - Quad(2).X) / (Quad(3).X - Quad(2).X)
        Dim oPointB As PointF = PointOnLineByPercentage(oPointBL, oPointBR, sPercentB)

        Dim sPercentRes As Single = (Point.Y - Quad(0).Y) / (Quad(2).Y - Quad(0).Y)
        Dim oPointTRes As PointF = New PointF(Quad(0).Y, oPointT.Y)
        Dim oPointBRes As PointF = New PointF(Quad(2).Y, oPointB.Y)
        Dim oPointRes As PointF = PointOnLineByPercentage(oPointTRes, oPointBRes, sPercentRes)

        Return oPointRes.Y
    End Function

    'Public Function RectanglePointToPolygon(ByVal Rectangle As RectangleF, ByVal SourcePoint As PointF, ByVal Polygon() As PointF) As PointF
    '    Dim bAreParallel As Boolean
    '    Dim oPointA As PointF = Rectangle.Location
    '    Dim oPointB As PointF = New PointF(Rectangle.Right, Rectangle.Top)
    '    Dim oPointC As PointF = New PointF(Rectangle.Right, Rectangle.Bottom)
    '    Dim oPointD As PointF = New PointF(Rectangle.Left, Rectangle.Bottom)
    '    'Debug.Print("SourcePoint.X:" & SourcePoint.X & " - SourcePoint.Y:" & SourcePoint.Y)
    '    'Debug.Print("Rect:" & Rectangle.ToString)
    '    Dim dX As Single = (SourcePoint.X - oPointD.X) / (oPointC.X - oPointD.X)
    '    Dim dY As Single = (SourcePoint.Y - oPointB.Y) / (oPointC.Y - oPointB.Y)
    '    'Debug.Print("dX:" & dX & " - dY:" & dY)
    '    Dim oPoint0 As PointF = Polygon(0)
    '    Dim oPoint1 As PointF = Polygon(1)
    '    Dim oPoint2 As PointF = Polygon(2)
    '    Dim oPoint3 As PointF = Polygon(3)

    '    Dim oPointM As PointF = New PointF(oPoint0.X + IIf(oPoint1.X > oPoint0.X, (oPoint1.X - oPoint0.X), -(oPoint1.X - oPoint0.X)) * dX, oPoint0.Y + IIf(oPoint1.Y - oPoint0.Y, (oPoint1.Y - oPoint0.Y), -(oPoint1.Y - oPoint0.Y)) * dX)
    '    Dim oPointN As PointF = New PointF(oPoint3.X + IIf(oPoint2.X > oPoint3.X, (oPoint2.X - oPoint3.X), -(oPoint2.X - oPoint3.X)) * dX, oPoint3.Y + IIf(oPoint3.Y > oPoint2.Y, -(oPoint3.Y - oPoint2.Y), -(oPoint3.Y - oPoint2.Y)) * dX)
    '    Dim oPointJ As PointF = New PointF(oPoint0.X + IIf(oPoint3.X > oPoint0.X, (oPoint3.X - oPoint0.X), (oPoint3.X - oPoint0.X)) * dY, oPoint0.Y + IIf(oPoint3.Y > oPoint0.Y, (oPoint3.Y - oPoint0.Y), -(oPoint3.Y - oPoint0.Y)) * dY)
    '    Dim oPointP As PointF = New PointF(oPoint1.X + IIf(oPoint2.X > oPoint1.X, (oPoint2.X - oPoint1.X), (oPoint2.X - oPoint1.X)) * dY, oPoint1.Y + IIf(oPoint2.Y > oPoint1.Y, (oPoint2.Y - oPoint1.Y), -(oPoint2.Y - oPoint1.Y)) * dY)

    '    'pDrawPoint(Graphics, "M", modPaint.ToPaintPoint(oPointM,  ), Pens.DarkGreen, 1)
    '    'pDrawPoint(Graphics, "N", modPaint.ToPaintPoint(oPointN,  ), Pens.DarkGreen, 1)
    '    'pDrawPoint(Graphics, "J", modPaint.ToPaintPoint(oPointJ,  ), Pens.DarkGreen, 1)
    '    'pDrawPoint(Graphics, "P", modPaint.ToPaintPoint(oPointP,  ), Pens.DarkGreen, 1)

    '    Dim oPointX As PointF = FindLineIntersection(oPointM, oPointN, oPointJ, oPointP, bAreParallel)
    '    If bAreParallel Then
    '        'se sono parallele...
    '        'DA FARE
    '    End If
    '    Return oPointX
    'End Function

    'Public Function PolygonPointToRectangle(ByVal Polygon As PointF(), ByVal SourcePoint As PointF) As PointF
    '    Dim bAreParallel As Boolean
    '    Dim oPointN As PointF = FindLineIntersection(Polygon(0), Polygon(2), Polygon(1), Polygon(3), bAreParallel)
    '    If bAreParallel Then
    '        'se sono parallele...
    '        oPointN = FindLineIntersection(Polygon(0), Polygon(1), SourcePoint, New PointF(SourcePoint.X, SourcePoint.Y - 100), bAreParallel)
    '    End If
    '    Dim oPointO As PointF = FindLineIntersection(Polygon(0), Polygon(1), Polygon(2), Polygon(3), bAreParallel)
    '    If bAreParallel Then
    '        'se sono parallele...
    '        oPointO = FindLineIntersection(Polygon(0), Polygon(2), SourcePoint, New PointF(SourcePoint.X - 100, SourcePoint.Y), bAreParallel)
    '    End If
    '    Dim opointJP As PointF = FindLineIntersection(Polygon(0), Polygon(1), SourcePoint, oPointN, bAreParallel)
    '    Dim oPointKP As PointF = FindLineIntersection(Polygon(2), Polygon(3), SourcePoint, oPointN, bAreParallel)
    '    Dim oPointLP As PointF = FindLineIntersection(Polygon(0), Polygon(2), SourcePoint, oPointO, bAreParallel)
    '    Dim oPointMP As PointF = FindLineIntersection(Polygon(1), Polygon(3), SourcePoint, oPointO, bAreParallel)

    '    Dim oPath As GraphicsPath = New GraphicsPath
    '    oPath.AddLine(New PointF(0, 0), Polygon(0))
    '    oPath.AddLine(New PointF(0, 0), Polygon(1))
    '    oPath.AddLine(New PointF(0, 0), Polygon(2))
    '    oPath.AddLine(New PointF(0, 0), Polygon(3))
    '    Dim oOutRect As RectangleF = oPath.GetBounds
    '    Call oOutRect.Offset(-oOutRect.Location.X, -oOutRect.Location.Y)

    '    Dim oP0Point As PointF = New PointF
    '    oP0Point.Y = oOutRect.Bottom * (opointJP.Y - SourcePoint.Y) / ((opointJP.Y - SourcePoint.Y) + (SourcePoint.Y - oPointKP.Y))
    '    oP0Point.X = oOutRect.Right * (oPointLP.X - SourcePoint.X) / ((oPointLP.X - SourcePoint.X) + (SourcePoint.X - oPointMP.X))

    '    'oP0Point.Y = oOutRect.Bottom * (opointJP.Y - SourcePoint.Y) / ((opointJP.Y - SourcePoint.Y) + (oPointKP.Y - SourcePoint.Y))
    '    'oP0Point.X = oOutRect.Right * (oPointLP.X - SourcePoint.X) / ((oPointLP.X - SourcePoint.X) + (oPointMP.X - SourcePoint.X))

    '    Return oP0Point
    'End Function

    Public Function QuadToPolygon(ByVal Points() As PointF) As PointF()
        'Dim oPoints(3) As PointF
        'oPoints(0) = Points(0)
        'oPoints(1) = Points(1)
        'oPoints(2) = Points(3)
        'oPoints(3) = Points(2)
        'Return oPoints
        Return {Points(0), Points(1), Points(3), Points(2)}
    End Function

    Public Function PolygonToQuad(ByVal Points() As PointF) As PointF()
        'Dim oPoints(3) As PointF  
        'oPoints(0) = Points(0)
        'oPoints(1) = Points(1)
        'oPoints(3) = Points(2)
        'oPoints(2) = Points(3)
        'Return oPoints
        Return {Points(0), Points(1), Points(3), Points(2)}
    End Function

    Public Function PointsInPolygon(Points As List(Of PointF), Polygon As List(Of PointF)) As Boolean
        For Each oPoint As PointF In Points
            If Not PointInPolygon(oPoint, Polygon) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function RectangleIntersectRectangle(Rect1 As RectangleF, Rect2 As RectangleF) As Boolean
        Dim oRect1 As Windows.Rect = New Windows.Rect(Rect1.X, Rect1.Y, Rect1.Width, Rect1.Height)
        Dim oRect2 As Windows.Rect = New Windows.Rect(Rect2.X, Rect2.Y, Rect2.Width, Rect2.Height)
        Return oRect1.IntersectsWith(oRect2)
    End Function

    Public Function PointsInPolygon(Points As List(Of PointD), Polygon As List(Of PointD)) As Boolean
        For Each oPoint As PointD In Points
            If Not PointInPolygon(oPoint, Polygon) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function PointInPolygon(ByVal Point As PointD, ByVal Polygon As List(Of PointD)) As Boolean
        Return PointInPolygon(Point, Polygon.ToArray)
    End Function

    Public Function PointInPolygon(ByVal Point As PointF, ByVal Polygon As List(Of PointF)) As Boolean
        Return PointInPolygon(Point, Polygon.ToArray)
    End Function

    Public Function PointInPolygon(ByVal Point As PointD, ByVal Polygon As PointD()) As Boolean
        Dim bIn As Boolean = False
        Dim iNumberOfPoints As Integer = Polygon.Count
        Dim i As Integer = 0
        Dim j As Integer = iNumberOfPoints - 1
        Do While i < iNumberOfPoints
            If (((Polygon(i).Y <= Point.Y) AndAlso (Point.Y < Polygon(j).Y)) OrElse ((Polygon(j).Y <= Point.Y) AndAlso (Point.Y < Polygon(i).Y))) AndAlso (Point.X < (Polygon(j).X - Polygon(i).X) * (Point.Y - Polygon(i).Y) / (Polygon(j).Y - Polygon(i).Y) + Polygon(i).X) Then
                bIn = Not bIn
            End If
            j = i
            i += 1
        Loop
        Return bIn
    End Function

    Public Function PointInPolygon(ByVal Point As PointF, ByVal Polygon() As PointF) As Boolean
        Dim bIn As Boolean = False
        Dim iNumberOfPoints As Integer = Polygon.Length
        Dim i As Integer = 0
        Dim j As Integer = iNumberOfPoints - 1
        Do While i < iNumberOfPoints
            If (((Polygon(i).Y <= Point.Y) AndAlso (Point.Y < Polygon(j).Y)) OrElse ((Polygon(j).Y <= Point.Y) AndAlso (Point.Y < Polygon(i).Y))) AndAlso (Point.X < (Polygon(j).X - Polygon(i).X) * (Point.Y - Polygon(i).Y) / (Polygon(j).Y - Polygon(i).Y) + Polygon(i).X) Then
                bIn = Not bIn
            End If
            j = i
            i += 1
        Loop
        Return bIn
    End Function

    Public Function PolygonExpand(ByVal Polygon() As PointF, ByVal Bearing As Integer, ByVal Offset As Single) As PointF()
        Select Case Bearing
            Case 0
                Polygon(3) = PointOnLineByX(Polygon(3), Polygon(0), Offset)
                Polygon(2) = PointOnLineByX(Polygon(2), Polygon(1), Offset)
            Case 1
                Polygon(0) = PointOnLineByY(Polygon(0), Polygon(3), Offset)
                Polygon(1) = PointOnLineByY(Polygon(1), Polygon(2), Offset)

            Case 2
                Polygon(0) = PointOnLineByX(Polygon(0), Polygon(1), Offset)
                Polygon(3) = PointOnLineByX(Polygon(3), Polygon(2), Offset)
            Case 4
                Polygon(1) = PointOnLineByX(Polygon(1), Polygon(0), Offset)
                Polygon(2) = PointOnLineByX(Polygon(2), Polygon(3), Offset)
            Case 5
                Polygon(2) = PointOnLineByY(Polygon(2), Polygon(1), Offset)
                Polygon(3) = PointOnLineByY(Polygon(3), Polygon(0), Offset)
        End Select
        Return Polygon
    End Function

    Private Function pGetOneOfNinePolygon(ByVal Polygon() As PointF, ByVal WitchOne As OneOfNinePolygonEnum, ByVal WideBy As Single) As PointF()
        Dim oCenterPoints() As PointF = Polygon  'QuadToPolygon(Polygon)

        Dim oLeftPoints(3) As PointF
        oLeftPoints(1) = Polygon(0)
        oLeftPoints(2) = Polygon(3)
        oLeftPoints(0) = RotatePointAt(90.0F, oLeftPoints(1), oLeftPoints(2))
        oLeftPoints(3) = RotatePointAt(90.0F, oLeftPoints(0), oLeftPoints(1))
        oLeftPoints = PolygonExpand(oLeftPoints, 2, -WideBy)

        Dim oTopPoints(3) As PointF
        oTopPoints(3) = Polygon(0)
        oTopPoints(2) = Polygon(1)
        oTopPoints(0) = RotatePointAt(-90.0F, oTopPoints(3), oTopPoints(2))
        oTopPoints(1) = RotatePointAt(-90.0F, oTopPoints(0), oTopPoints(3))
        oTopPoints = PolygonExpand(oTopPoints, 1, -WideBy)

        Dim oRightPoints(3) As PointF
        oRightPoints(0) = Polygon(1)
        oRightPoints(3) = Polygon(2)
        oRightPoints(1) = RotatePointAt(-90.0F, oRightPoints(0), oRightPoints(3))
        oRightPoints(2) = RotatePointAt(-90.0F, oRightPoints(1), oRightPoints(0))
        oRightPoints = PolygonExpand(oRightPoints, 4, WideBy)

        Dim oBottomPoints(3) As PointF
        oBottomPoints(0) = Polygon(3)
        oBottomPoints(1) = Polygon(2)
        oBottomPoints(3) = RotatePointAt(90.0F, oBottomPoints(0), oBottomPoints(1))
        oBottomPoints(2) = RotatePointAt(90.0F, oBottomPoints(3), oBottomPoints(0))
        oBottomPoints = PolygonExpand(oBottomPoints, 5, WideBy)

        Dim oLeftTopPoints(3) As PointF
        oLeftTopPoints(1) = oTopPoints(0)
        oLeftTopPoints(2) = oTopPoints(3)
        oLeftTopPoints(3) = oLeftPoints(0)
        oLeftTopPoints(0) = New PointF(oLeftTopPoints(3).X, oLeftTopPoints(1).Y)

        Dim oRightTopPoints(3) As PointF
        oRightTopPoints(0) = oTopPoints(1)
        oRightTopPoints(2) = oRightPoints(1)
        oRightTopPoints(3) = oTopPoints(2)
        oRightTopPoints(1) = New PointF(oRightTopPoints(2).X, oRightTopPoints(0).Y)

        Dim oBottomLeftPoints(3) As PointF
        oBottomLeftPoints(0) = oLeftPoints(3)
        oBottomLeftPoints(1) = oLeftPoints(2)
        oBottomLeftPoints(2) = oBottomPoints(3)
        oBottomLeftPoints(3) = New PointF(oBottomLeftPoints(0).X, oBottomLeftPoints(2).Y)

        Dim oBottomRightPoints(3) As PointF
        oBottomRightPoints(0) = oBottomPoints(1)
        oBottomRightPoints(1) = oRightPoints(2)
        oBottomRightPoints(3) = oBottomPoints(2)
        oBottomRightPoints(2) = New PointF(oBottomRightPoints(1).X, oBottomRightPoints(3).Y)

        Select Case WitchOne
            Case OneOfNinePolygonEnum.Center
                Return oCenterPoints
            Case OneOfNinePolygonEnum.Left
                Return oLeftPoints
            Case OneOfNinePolygonEnum.Top
                Return oTopPoints
            Case OneOfNinePolygonEnum.Right
                Return oRightPoints
            Case OneOfNinePolygonEnum.Bottom
                Return oBottomPoints
            Case OneOfNinePolygonEnum.LeftTop
                Return oLeftTopPoints
            Case OneOfNinePolygonEnum.RightTop
                Return oRightTopPoints
            Case OneOfNinePolygonEnum.BottomLeft
                Return oBottomLeftPoints
            Case OneOfNinePolygonEnum.BottomRight
                Return oBottomRightPoints
        End Select
    End Function

    Private Function pFindOneOfNinePolygon(ByVal Polygon() As PointF, ByVal Point As PointF, ByVal WideBy As Single, ByRef ResultPolygon() As PointF) As OneOfNinePolygonEnum
        Dim oCenterPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.Center, WideBy)
        If PointInPolygon(Point, oCenterPoints) Then
            ResultPolygon = oCenterPoints
            Return OneOfNinePolygonEnum.Center
        End If

        Dim oLeftPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.Left, WideBy)
        If PointInPolygon(Point, oLeftPoints) Then
            ResultPolygon = oLeftPoints
            Return OneOfNinePolygonEnum.Left
        End If

        Dim oTopPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.Top, WideBy)
        If PointInPolygon(Point, oTopPoints) Then
            ResultPolygon = oTopPoints
            Return OneOfNinePolygonEnum.Top
        End If

        Dim oRightPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.Right, WideBy)
        If PointInPolygon(Point, oRightPoints) Then
            ResultPolygon = oRightPoints
            Return OneOfNinePolygonEnum.Right
        End If

        Dim oBottomPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.Bottom, WideBy)
        If PointInPolygon(Point, oBottomPoints) Then
            ResultPolygon = oBottomPoints
            Return OneOfNinePolygonEnum.Bottom
        End If

        Dim oLeftTopPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.LeftTop, WideBy)
        If PointInPolygon(Point, oLeftTopPoints) Then
            ResultPolygon = oLeftTopPoints
            Return OneOfNinePolygonEnum.LeftTop
        End If

        Dim oRightTopPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.RightTop, WideBy)
        If PointInPolygon(Point, oRightTopPoints) Then
            ResultPolygon = oRightTopPoints
            Return OneOfNinePolygonEnum.RightTop
        End If

        Dim oBottomLeftPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.BottomLeft, WideBy)
        If PointInPolygon(Point, oBottomLeftPoints) Then
            ResultPolygon = oBottomLeftPoints
            Return OneOfNinePolygonEnum.BottomLeft
        End If

        Dim oBottomRightPoints() As PointF = pGetOneOfNinePolygon(Polygon, OneOfNinePolygonEnum.BottomRight, WideBy)
        If PointInPolygon(Point, oBottomRightPoints) Then
            ResultPolygon = oBottomRightPoints
            Return OneOfNinePolygonEnum.BottomRight
        End If
    End Function

    Public Function PointOnLineByY(ByVal Point1 As PointF, ByVal Point2 As PointF, ByVal OffsetY As Single) As PointF
        Dim y As Single = Point1.Y + OffsetY
        Dim dX As Single = Point2.X - Point1.X
        Dim dY As Single = Point2.Y - Point1.Y
        Dim m As Single = dX / dY
        Return New PointF(Point1.X + (y - Point1.Y) * m, y)
    End Function

    Public Function PointOnLineByX(ByVal Point1 As PointF, ByVal Point2 As PointF, ByVal OffsetX As Single) As PointF
        Dim x As Single = Point1.X + OffsetX
        Dim dX As Single = Point2.X - Point1.X
        Dim dY As Single = Point2.Y - Point1.Y
        Dim m As Single = dY / dX
        Return New PointF(x, Point1.Y + (x - Point1.X) * m)
    End Function

    Public Function PointOnLineByPercentage(ByVal Point1 As PointF, ByVal Point2 As PointF, ByVal Percent As Single) As PointF
        Dim dX As Single = (Point2.X - Point1.X) * Percent
        Dim dY As Single = (Point2.Y - Point1.Y) * Percent
        Return New PointF(Point1.X + dX, Point1.Y + dY)
    End Function

    'Public Function GetAngle(ByVal point1 As PointF, ByVal point2 As PointF, ByVal point3 As PointF) As Single
    '    Dim side_a As Single = Math.Sqrt((point2.X - point3.X) ^ 2 + (point2.Y - point3.Y) ^ 2)
    '    Dim side_b As Single = Math.Sqrt((point1.X - point3.X) ^ 2 + (point1.Y - point3.Y) ^ 2)
    '    Dim side_c As Single = Math.Sqrt((point1.X - point2.X) ^ 2 + (point1.Y - point2.Y) ^ 2)
    '    GetAngle = RadiantToDegree(Math.Acos((side_b ^ 2 - side_a ^ 2 - side_c ^ 2) / (-2 * side_a * side_c)))
    'End Function

    'Public Function GetAngleBetweenSegment(ByVal point11 As PointF, ByVal point12 As PointF, ByVal point21 As PointF, ByVal point22 As PointF) As Single
    '    Dim bParallel As Boolean
    '    Dim oPoint3 As PointF = modPaint.FindLineIntersection(point11, point12, point21, point22, bParallel)
    '    If Not bParallel Then
    '        Return GetAngle(oPoint3, point12, point22)
    '    Else
    '        Return 0
    '    End If
    'End Function
    Public Function GetAngleBetweenSegment(ByVal p1 As Point, ByVal p2 As Point, ByVal p3 As Point, ByVal p4 As Point) As Integer
        Dim a As Integer = p1.X - p2.X
        Dim b As Integer = p1.Y - p2.Y
        Dim c As Integer = p3.X - p4.X
        Dim d As Integer = p3.Y - p4.Y

        Dim smag_v1 As Single = Math.Sqrt(a * a + b * b)
        Dim smag_v2 As Single = Math.Sqrt(c * c + d * d)

        Dim scos_angle As Single = (a * c + b * d) / (smag_v1 * smag_v2)
        Dim sangle As Single = Math.Acos(scos_angle)
        sangle = sangle * 180.0 / Math.PI

        Return sangle
    End Function

    Public Function GetAngleBetweenSegment(ByVal p1 As PointF, ByVal p2 As PointF, ByVal p3 As PointF, ByVal p4 As PointF) As Single
        Dim a As Single = p1.X - p2.X
        Dim b As Single = p1.Y - p2.Y
        Dim c As Single = p3.X - p4.X
        Dim d As Single = p3.Y - p4.Y

        Dim smag_v1 As Single = Math.Sqrt(a * a + b * b)
        Dim smag_v2 As Single = Math.Sqrt(c * c + d * d)

        Dim scos_angle As Single = (a * c + b * d) / (smag_v1 * smag_v2)
        Dim sangle As Single = Math.Acos(scos_angle)
        sangle = sangle * 180.0 / Math.PI

        Return sangle
    End Function

    Public Function GetAngleBetweenSegment(ByVal p1 As PointD, ByVal p2 As PointD, ByVal p3 As PointD, ByVal p4 As PointD) As Decimal
        Dim a As Decimal = p1.X - p2.X
        Dim b As Decimal = p1.Y - p2.Y
        Dim c As Decimal = p3.X - p4.X
        Dim d As Decimal = p3.Y - p4.Y
        Dim sMag_v1 As Decimal = Math.Sqrt(a * a + b * b)
        Dim sMag_v2 As Decimal = Math.Sqrt(c * c + d * d)
        Dim dCos_angle As Decimal = (a * c + b * d) / (sMag_v1 * sMag_v2)
        Dim dAngle As Decimal = Math.Acos(dCos_angle)
        dAngle = dAngle * 180D / Math.PI
        Return dAngle
    End Function

    'Public Function GetAngleBetweenSegment(ByVal p1 As PointF, ByVal p2 As PointF, ByVal p3 As PointF, ByVal p4 As PointF) As Decimal
    '    Dim a As Decimal = p1.X - p2.X
    '    Dim b As Decimal = p1.Y - p2.Y
    '    Dim c As Decimal = p3.X - p4.X
    '    Dim d As Decimal = p3.Y - p4.Y

    '    Dim smag_v1 As Decimal = Math.Sqrt(a * a + b * b)
    '    Dim smag_v2 As Decimal = Math.Sqrt(c * c + d * d)

    '    Dim scos_angle As Decimal = (a * c + b * d) / (smag_v1 * smag_v2)
    '    Dim sangle As Decimal = Math.Acos(scos_angle)
    '    sangle = sangle * 180.0 / Math.PI

    '    Return sangle
    'End Function

    Public Function GetPaintAnchor(ByVal Point As PointF, ByVal Padding As Single) As RectangleF
        Dim sPadding As Single = Padding
        Dim sHalfPadding As Single = sPadding / 2
        Return New RectangleF(Point.X - sHalfPadding, Point.Y - sHalfPadding, sPadding, sPadding)
    End Function

    Friend Function ObjectHitTest(PaintOptions As cOptions, ByVal Point As PointF, ByVal Tools As cEditDesignTools, ByVal Zoom As Single) As cHitTestResult
        Return ObjectHitTest(PaintOptions, Point.X, Point.Y, Tools, Zoom)
    End Function

    Friend Function ObjectHitTest(PaintOptions As cOptions, ByVal X As Single, ByVal Y As Single, ByVal Tools As cEditDesignTools, ByVal Zoom As Single) As cHitTestResult
        Dim sAnchorBaseScale As Single = AnchorsScale * modControls.SystemDPIRatio
        Dim oHitTestResult As cHitTestResult = New cHitTestResult
        Dim oItem As cItem = Tools.CurrentItem
        If oItem Is Nothing Then
            Return oHitTestResult
        Else
            Dim oBounds As RectangleF = oItem.GetBounds
            Dim oHitRect As RectangleF

            If oItem.HaveEditablePoints AndAlso Tools.IsInPointEdit Then
                If Tools.IsNewPoint Then
                    oHitRect = modPaint.GetPaintAnchor(Tools.CurrentItemPoint.Point, sAnchorBaseScale * 7 / Zoom)
                    If oHitRect.Contains(X, Y) Then
                        oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.Point
                        oHitTestResult.Object = Tools.CurrentItemPoint
                        oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.NewPoint
                        oHitTestResult.ObjectRectagle = oHitRect
                        Return oHitTestResult
                    End If
                End If
                For Each oPoint As cPoint In oItem.Points
                    oHitRect = modPaint.GetPaintAnchor(oPoint.Point, sAnchorBaseScale * 4 / Zoom)
                    If oHitRect.Contains(X, Y) Then
                        oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.Point
                        oHitTestResult.Object = oPoint
                        oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.GenericPoint
                        oHitTestResult.ObjectRectagle = oHitRect
                        Return oHitTestResult
                    End If
                Next
            End If

            If oItem.CanBeResized AndAlso Not Tools.IsInPointEdit Then
                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.Right, oBounds.Y), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.TopRightCorner
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If

                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.X, oBounds.Bottom), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.BottomLeftCorner
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If

                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.Right, oBounds.Bottom), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.BottomRightCorner
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If

                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.X + oBounds.Width / 2, oBounds.Y), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.TopMiddle
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If

                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.X, oBounds.Y + oBounds.Height / 2), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.LeftMiddle
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If

                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.Right, oBounds.Y + oBounds.Height / 2), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.RightMiddle
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If

                oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.X + oBounds.Width / 2, oBounds.Bottom), sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.BottomMiddle
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If
            End If

            If oItem.CanBeRotated Then
                Dim oRotatorPoint As PointF = New PointF(Tools.LastCenterPoint.X, Tools.LastCenterPoint.Y - Tools.LastBounds.Height / 2 - 20 / Zoom)
                If Tools.LastAngle <> 0 Then
                    'Dim oCenterPoint As PointF = New PointF(oBounds.X + oBounds.Width / 2, oBounds.Y + oBounds.Height / 2)
                    Dim oPoints(0) As PointF
                    oPoints(0) = oRotatorPoint
                    Dim oMatrix As Matrix = New Matrix
                    Call oMatrix.RotateAt(Tools.LastAngle, Tools.LastCenterPoint)
                    Call oMatrix.TransformPoints(oPoints)
                    oRotatorPoint = oPoints(0)
                End If
                oHitRect = modPaint.GetPaintAnchor(oRotatorPoint, sAnchorBaseScale * 8 / Zoom)
                If oHitRect.Contains(X, Y) Then
                    oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                    oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.Rotator
                    oHitTestResult.ObjectRectagle = oHitRect
                    Return oHitTestResult
                End If
            End If

            oHitRect = modPaint.GetPaintAnchor(New PointF(oBounds.X, oBounds.Y), sAnchorBaseScale * 8 / Zoom)
            If oHitRect.Contains(X, Y) Then
                oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.AnchorRectangle
                oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.TopLeftCorner
                oHitTestResult.ObjectRectagle = oHitRect
                Return oHitTestResult
            End If

            If oBounds.Contains(X, Y) Then
                oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.None
                oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.None
                oHitTestResult.ObjectRectagle = oHitRect
                Return oHitTestResult
            End If

            oHitTestResult.Object = Nothing
            oHitTestResult.ObjectType = cHitTestResult.ObjectTypeEnum.Outside
            oHitTestResult.ObjectAnchorRectangleType = AnchorRectangleTypeEnum.None
            oHitTestResult.ObjectRectagle = Nothing
            Return oHitTestResult
        End If
    End Function

    'Friend Sub RenderPointToSegmentBindings(ByVal Cache As cSurvey.Drawings.cDrawCache, ByVal Survey As cSurvey.cSurvey, ByVal Item As cItem)
    '    'disegno una linea tra ogni punto e il segmento della poligonale associato
    '    Dim oSegmentPen As Pen
    '    Dim oSegmentLockedPen As Pen
    '    'If Selected Then
    '    '    oSegmentLockedPen = Survey.EditPaintObjects.SelectedSegmentLockedPen
    '    '    oSegmentPen = Survey.EditPaintObjects.SelectedSegmentUnlockedPen
    '    'Else
    '    oSegmentLockedPen = Survey.EditPaintObjects.SegmentLockedPen
    '    oSegmentPen = Survey.EditPaintObjects.SegmentUnlockedPen
    '    'End If
    '    With Cache
    '        Select Case Item.BindMode
    '            Case cItem.BindModeEnum.AllPoints
    '                For Each oPoint As cPoint In Item.Points
    '                    If Not oPoint.BindedSegment Is Nothing Then
    '                        Dim oCacheItem As Drawings.cDrawCacheItem = .Add
    '                        If oPoint.SegmentLocked Then
    '                            Call oCacheItem.SetPen(oSegmentLockedPen)
    '                            Call oCacheItem.AddLine(oPoint.Point, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
    '                        Else
    '                            Call oCacheItem.SetPen(oSegmentLockedPen)
    '                            Call oCacheItem.AddLine(oPoint.Point, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
    '                        End If
    '                    End If
    '                Next
    '            Case cItem.BindModeEnum.CenterPoint
    '                Dim oPoint As cPoint = Item.Points(0)
    '                Dim oBindedPoint As PointF = Item.GetCenterPoint
    '                If Not oPoint.BindedSegment Is Nothing Then
    '                    Dim oCacheItem As Drawings.cDrawCacheItem = .Add
    '                    If oPoint.SegmentLocked Then
    '                        Call oCacheItem.SetPen(oSegmentLockedPen)
    '                        Call oCacheItem.AddLine(oBindedPoint, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
    '                    Else
    '                        Call oCacheItem.SetPen(oSegmentLockedPen)
    '                        Call oCacheItem.AddLine(oBindedPoint, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
    '                    End If
    '                End If
    '        End Select
    '    End With
    'End Sub

    Public sPointSize As Single = 0.3
    Public sCutPointSize As Single = 0.2
    Public sSidePointSize As Single = 0.15

    Friend Sub PaintStationSplays(ByVal PaintOptions As cOptions, Cache As Drawings.cDrawCache, ByVal CurrentSegment As cISegment, Segment As cISegment, StationPoint As PointF, Color As Color, TranslationMatrix As Matrix, LorUPrefix As String, RorDPrefix As String, Splays As IEnumerable(Of Calculate.Plot.cISplayProjectedData))
        If PaintOptions.SplayStyle = cOptions.SplayStyleEnum.Points OrElse PaintOptions.SplayStyle = cOptions.SplayStyleEnum.PointsAndRays Then
            Using oPath As GraphicsPath = New GraphicsPath
                For Each oItem As Calculate.Plot.cISplayProjectedData In Splays
                    Dim oPoint As PointF = oItem.ToPoint
                    Call modPaint.PathAddCrossFromPoint(oPath, oPoint, sPointSize)

                    If PaintOptions.ShowSplayText Then
                        Dim oCacheItem As Drawings.cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                        oCacheItem.SetBrush(PaintOptions.DrawingObjects.SplayBrush)
                        oCacheItem.AddString(oItem.To, PaintOptions.DrawingObjects.SplayFont, oPoint)
                        Call oCacheItem.Transform(TranslationMatrix)
                    End If

                    If PaintOptions.DrawLRUD Then
                        Dim oLeftPoint As PointF = oItem.LorUPoint
                        If oLeftPoint <> oPoint Then
                            Call modPaint.PathAddCrossFromPoint(oPath, oLeftPoint, sSidePointSize)
                            If PaintOptions.ShowSplayText Then
                                Dim oCacheItem As Drawings.cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                oCacheItem.SetBrush(PaintOptions.DrawingObjects.SplayBrush)
                                oCacheItem.AddString(oItem.To & LorUPrefix, PaintOptions.DrawingObjects.SplayFont, oLeftPoint)
                                Call oCacheItem.Transform(TranslationMatrix)
                            End If
                        End If

                        Dim oRightPoint As PointF = oItem.RorDPoint
                        If oRightPoint <> oPoint Then
                            Call modPaint.PathAddCrossFromPoint(oPath, oRightPoint, sSidePointSize)
                            If PaintOptions.ShowSplayText Then
                                Dim oCacheItem As Drawings.cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                                oCacheItem.SetBrush(PaintOptions.DrawingObjects.SplayBrush)
                                oCacheItem.AddString(oItem.To & RorDPrefix, PaintOptions.DrawingObjects.SplayFont, oRightPoint)
                                Call oCacheItem.Transform(TranslationMatrix)
                            End If
                        End If
                    End If
                Next

                Dim oCacheCrossItem As Drawings.cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                If CurrentSegment Is Segment Then
                    PaintOptions.DrawingObjects.SplaySelectedPen.Color = Color
                    Call oCacheCrossItem.SetPen(PaintOptions.DrawingObjects.SplaySelectedPen)
                    Call oCacheCrossItem.AddPath(oPath)
                Else
                    PaintOptions.DrawingObjects.SplayPen.Color = Color
                    Call oCacheCrossItem.SetPen(PaintOptions.DrawingObjects.SplayPen)
                    Call oCacheCrossItem.AddPath(oPath)
                End If
                Call oCacheCrossItem.Transform(TranslationMatrix)
            End Using
        ElseIf PaintOptions.SplayStyle = cOptions.SplayStyleEnum.Rays Then
            Using oPath As GraphicsPath = New GraphicsPath
                For Each oItem As Calculate.Plot.cISplayProjectedData In Splays
                    Dim oPoint As PointF = oItem.ToPoint
                    If PaintOptions.ShowSplayText Then
                        Dim oCacheItem As Drawings.cDrawCacheItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                        oCacheItem.SetBrush(PaintOptions.DrawingObjects.SplayBrush)
                        oCacheItem.AddString(oItem.To, PaintOptions.DrawingObjects.SplayFont, oPoint)
                        Call oCacheItem.Transform(TranslationMatrix)
                    End If
                Next
            End Using
        End If

        If PaintOptions.SplayStyle = cOptions.SplayStyleEnum.PointsAndRays OrElse PaintOptions.SplayStyle = cOptions.SplayStyleEnum.Rays Then
            Using oRayPath As GraphicsPath = New GraphicsPath
                For Each oItem As Calculate.Plot.cISplayProjectedData In Splays
                    Dim oPoint As PointF = oItem.ToPoint
                    Call oRayPath.StartFigure()
                    Call oRayPath.AddLine(StationPoint, oPoint)

                    If PaintOptions.DrawLRUD Then
                        Dim oLeftPoint As PointF = oItem.LorUPoint
                        If oLeftPoint <> oPoint Then
                            Call oRayPath.StartFigure()
                            Call oRayPath.AddLine(oPoint, oLeftPoint)
                        End If

                        Dim oRightPoint As PointF = oItem.RorDPoint
                        If oRightPoint <> oPoint Then
                            Call oRayPath.StartFigure()
                            Call oRayPath.AddLine(oPoint, oRightPoint)
                        End If
                    End If
                Next
                Dim oCacheRayItem = Cache.Add(cDrawCacheItem.cDrawCacheItemType.Border)
                If CurrentSegment Is Segment Then
                    PaintOptions.DrawingObjects.SplaySelectedPen.Color = Color
                    Call oCacheRayItem.SetPen(PaintOptions.DrawingObjects.SplaySelectedPen)
                    Call oCacheRayItem.AddPath(oRayPath)
                Else
                    PaintOptions.DrawingObjects.SplayPen.Color = Color
                    Call oCacheRayItem.SetPen(PaintOptions.DrawingObjects.SplayPen)
                    Call oCacheRayItem.AddPath(oRayPath)
                End If
                Call oCacheRayItem.Transform(TranslationMatrix)
            End Using
        End If
    End Sub

    Friend Sub PaintPointToSegmentBindings(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, ByVal Item As cItem, ByVal Selected As Boolean)
        'disegno una linea tra ogni punto e il segmento della poligonale associato
        Dim oSegmentPen As Pen
        Dim oSegmentLockedPen As Pen
        If Selected Then
            oSegmentLockedPen = Survey.EditPaintObjects.SelectedSegmentLockedPen
            oSegmentPen = Survey.EditPaintObjects.SelectedSegmentUnlockedPen
        Else
            oSegmentLockedPen = Survey.EditPaintObjects.SegmentLockedPen
            oSegmentPen = Survey.EditPaintObjects.SegmentUnlockedPen
        End If
        Select Case Item.BindMode
            Case cItem.BindModeEnum.AllPoints
                For Each oPoint As cPoint In Item.Points
                    If Not oPoint.BindedSegment Is Nothing Then
                        If oPoint.SegmentLocked Then
                            Call Graphics.DrawLine(oSegmentLockedPen, oPoint.Point, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
                        Else
                            Call Graphics.DrawLine(oSegmentPen, oPoint.Point, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
                        End If
                    End If
                Next
            Case cItem.BindModeEnum.CenterPoint
                Dim oPoint As cPoint = Item.Points(0)
                Dim oBindedPoint As PointF = Item.GetCenterPoint
                If Not oPoint.BindedSegment Is Nothing Then
                    If oPoint.SegmentLocked Then
                        Call Graphics.DrawLine(oSegmentLockedPen, oBindedPoint, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
                    Else
                        Call Graphics.DrawLine(oSegmentPen, oBindedPoint, Item.Design.GetSegmentPointData(oPoint.BindedSegment).GetCenterPoint)
                    End If
                End If
        End Select
    End Sub

    Public Sub PaintSelection(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Survey As cSurvey.cSurvey, ByVal Item As cItem, ByVal Zoom As Single)
        Try
            Dim oBounds As RectangleF = Item.GetBounds
            Call Graphics.DrawRectangle(Survey.EditPaintObjects.SelectedBoundsPen, oBounds.X, oBounds.Y, oBounds.Width, oBounds.Height)
        Catch
        End Try
    End Sub

    Friend Sub PaintLastPoint(graphics As Graphics, ByVal Survey As cSurvey.cSurvey, Point As cPoint, Zoom As Single, Translation As PointF)
        Call PaintAnchorRectangle(graphics, Point.Point, AnchorRectangleTypeEnum.LastPoint, Survey, Zoom)
    End Sub

    Friend Sub PaintNewPoint(graphics As Graphics, ByVal Survey As cSurvey.cSurvey, Point As cPoint, Zoom As Single, Translation As PointF)
        Call PaintAnchorRectangle(graphics, Point.Point, AnchorRectangleTypeEnum.NewPoint, Survey, Zoom)
    End Sub

    Friend Sub PaintCurrentMarkedDesktopPoint(graphics As Graphics, ByVal Survey As cSurvey.cSurvey, MarkedDesktopPoint As cMarkedDesktopPoint, ByVal Zoom As Single)
        If MarkedDesktopPoint.IsSet Then
            Dim oPoint As PointF = MarkedDesktopPoint.Point
            Dim oPaintRect As RectangleF
            oPaintRect = modPaint.GetPaintAnchor(oPoint, AnchorsScale * 5 / Zoom)
            Call graphics.FillEllipse(Survey.EditPaintObjects.MarkedPointBrush, oPaintRect)
            Call graphics.DrawEllipse(Survey.EditPaintObjects.MarkedPointPen, oPaintRect)
            oPaintRect = modPaint.GetPaintAnchor(oPoint, AnchorsScale * 9 / Zoom)
            Call graphics.DrawEllipse(Survey.EditPaintObjects.MarkedPointPen, oPaintRect)
        End If
    End Sub

    Public AnchorsScale As Single

    Friend Sub PaintAnchorRectangle(ByVal Graphics As Graphics, ByVal Point As PointF, ByVal Type As AnchorRectangleTypeEnum, ByVal Survey As cSurvey.cSurvey, ByVal Zoom As Single)
        Try
            Dim sAnchorBaseScale As Single = AnchorsScale * modControls.SystemDPIRatio
            Dim oPaintRect As RectangleF

            If (Type And AnchorRectangleTypeEnum.AllMask) Then
                oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 7 / Zoom)
                Graphics.FillEllipse(Survey.EditPaintObjects.StartPointBrush, oPaintRect)
            End If

            Select Case (Type And AnchorRectangleTypeEnum.TypeMask)
                Case AnchorRectangleTypeEnum.BezierControlPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 4 / Zoom)
                    Graphics.FillRectangle(Survey.EditPaintObjects.BezierControlPointBrush, oPaintRect)
                    Graphics.DrawRectangle(Survey.EditPaintObjects.BezierControlPointPen, oPaintRect.X, oPaintRect.Y, oPaintRect.Width, oPaintRect.Height)
                Case AnchorRectangleTypeEnum.GenericPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 4 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.GenericPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.GenericPointPen, oPaintRect)
                Case AnchorRectangleTypeEnum.EndPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 4 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.EndPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.EndPointPen, oPaintRect)
                Case AnchorRectangleTypeEnum.StartPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 4 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.StartPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.StartPointPen, oPaintRect)

                Case AnchorRectangleTypeEnum.SpecialPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 7 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.SpecialPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.SpecialPointPen, oPaintRect)

                Case AnchorRectangleTypeEnum.LastPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 8 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.LastPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.LastPointPen, oPaintRect)

                Case AnchorRectangleTypeEnum.NewPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 8 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.NewPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.NewPointPen, oPaintRect)

                Case AnchorRectangleTypeEnum.Rotator
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 7 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.RotatorBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.RotatorPen, oPaintRect)

                'Case AnchorRectangleTypeEnum.CenterOfRotation
                '    oPaintRect = modPaint.GetPaintAnchor(Point, 4 / Zoom)
                '    Graphics.FillEllipse(Survey.EditPaintObjects.RotatorBrush, oPaintRect)
                '    Graphics.DrawEllipse(Survey.EditPaintObjects.RotatorPen, oPaintRect)

                Case AnchorRectangleTypeEnum.TopLeftCorner
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 8 / Zoom)
                    Graphics.FillRectangle(Survey.EditPaintObjects.TopLeftCornerBrush, oPaintRect)
                'Graphics.DrawRectangle(oPen, oPaintRect.X, oPaintRect.Y, oPaintRect.Width, oPaintRect.Height)

                Case AnchorRectangleTypeEnum.ExtraTopLeftCorner
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 12 / Zoom)
                    Graphics.FillRectangle(Survey.EditPaintObjects.SelectedBoundsExtraBrush, oPaintRect)

                Case AnchorRectangleTypeEnum.LockedTopLeftCorner
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 8 / Zoom)
                    Graphics.FillRectangle(Survey.EditPaintObjects.LockedTopLeftCornerBrush, oPaintRect)

                Case AnchorRectangleTypeEnum.UnmovableTopLeftCorner
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 8 / Zoom)
                    Graphics.FillRectangle(Survey.EditPaintObjects.UnmovableTopLeftCornerBrush, oPaintRect)

                Case AnchorRectangleTypeEnum.CenterOfRotation
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 4 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.CenterOfRotationPointBrush, oPaintRect)
                    Graphics.DrawEllipse(Survey.EditPaintObjects.CenterOfRotationPointPen, oPaintRect)

                Case AnchorRectangleTypeEnum.CenterPoint
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 4 / Zoom)
                    Graphics.FillEllipse(Survey.EditPaintObjects.CenterPointBrush, oPaintRect)
                Case Else
                    oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 8 / Zoom)
                    Graphics.FillRectangle(Survey.EditPaintObjects.OtherPointBrush, oPaintRect)
            End Select

            If (Type And AnchorRectangleTypeEnum.JoinedMask) Then
                oPaintRect = modPaint.GetPaintAnchor(Point, sAnchorBaseScale * 10 / Zoom)
                Graphics.DrawEllipse(Survey.EditPaintObjects.GenericPointPen, oPaintRect)
            End If
        Catch
        End Try
    End Sub

    Public Function AdjustBoundsRectangle(ByVal Bounds As RectangleF) As RectangleF
        If Single.IsInfinity(Bounds.X) OrElse Single.IsNaN(Bounds.X) Then
            Bounds.X = 0
        End If
        If Single.IsInfinity(Bounds.Y) OrElse Single.IsNaN(Bounds.Y) Then
            Bounds.Y = 0
        End If
        If Single.IsNaN(Bounds.Height) OrElse Bounds.Height = 0 Then
            Bounds.Height = 0.01
        End If
        If Single.IsNaN(Bounds.Width) OrElse Bounds.Width = 0 Then
            Bounds.Width = 0.01
        End If
        Return Bounds
    End Function

    Public Sub PaintSelectionTools(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Survey As cSurvey.cSurvey, ByVal Item As cItem, ByVal Tools As cEditDesignTools, ByVal Zoom As Single)
        Dim oBounds As RectangleF = Item.GetBounds
        If Tools.LastCenterPoint.IsEmpty Then
            If Item.Points.Count > 0 Then
                Tools.LastCenterPoint = Item.GetCenterPoint ' PointF.Add(oBounds.Location, New SizeF(oBounds.Width / 2, oBounds.Height / 2))
            End If
        End If
        If Item.DesignAffinity = cItem.DesignAffinityEnum.Extra Then
            'Dim sAnchorBaseScale As Single = AnchorsScale * modControls.SystemDPIRatio
            'Dim oAffinityPoly As PointF() = {New PointF(oBounds.X, oBounds.Y), New PointF(oBounds.X + (sAnchorBaseScale * 5 * 4 / Zoom), oBounds.Y), New PointF(oBounds.X, oBounds.Y + (sAnchorBaseScale * 5 * 4 / Zoom)), New PointF(oBounds.X, oBounds.Y)}
            'Call Graphics.FillPolygon(Survey.EditPaintObjects.SelectedBoundsExtraBrush, oAffinityPoly)
            Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X, oBounds.Y), AnchorRectangleTypeEnum.ExtraTopLeftCorner, Survey, Zoom)
        End If
        If Item.Locked Then
            Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X, oBounds.Y), AnchorRectangleTypeEnum.LockedTopLeftCorner, Survey, Zoom)
        Else
            If Item.CanBeMoved Then
                Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X, oBounds.Y), AnchorRectangleTypeEnum.TopLeftCorner, Survey, Zoom)
                If Item.CanBeResized AndAlso Not Tools.IsInPointEdit Then
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X, oBounds.Bottom), AnchorRectangleTypeEnum.TopRightCorner, Survey, Zoom)
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.Right, oBounds.Y), AnchorRectangleTypeEnum.BottomLeftCorner, Survey, Zoom)
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.Right, oBounds.Bottom), AnchorRectangleTypeEnum.BottomRightCorner, Survey, Zoom)
                End If

                If Item.CanBeRotated Then
                    Dim oRotatorPoint As PointF = New PointF(Tools.LastCenterPoint.X, Tools.LastCenterPoint.Y - Tools.LastBounds.Height / 2 - 20 / Zoom)
                    If Tools.LastAngle <> 0 Then
                        oRotatorPoint = modPaint.RotatePointAt(Tools.LastAngle, Tools.LastCenterPoint, oRotatorPoint)
                    End If
                    Call PaintAnchorRectangle(Graphics, oRotatorPoint, AnchorRectangleTypeEnum.Rotator, Survey, Zoom)
                    Call PaintAnchorRectangle(Graphics, Tools.LastCenterPoint, AnchorRectangleTypeEnum.CenterOfRotation, Survey, Zoom)
                End If

                If Item.CanBeResized AndAlso Not Tools.IsInPointEdit Then
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X + oBounds.Width / 2, oBounds.Y), AnchorRectangleTypeEnum.TopMiddle, Survey, Zoom)
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X, oBounds.Y + oBounds.Height / 2), AnchorRectangleTypeEnum.LeftMiddle, Survey, Zoom)
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.Right, oBounds.Y + oBounds.Height / 2), AnchorRectangleTypeEnum.RightMiddle, Survey, Zoom)
                    Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X + oBounds.Width / 2, oBounds.Bottom), AnchorRectangleTypeEnum.BottomMiddle, Survey, Zoom)
                End If
            Else
                Call PaintAnchorRectangle(Graphics, New PointF(oBounds.X, oBounds.Y), AnchorRectangleTypeEnum.UnmovableTopLeftCorner, Survey, Zoom)
            End If
        End If

        If Item.HaveEditablePoints AndAlso Tools.IsInPointEdit Then
            Dim bCurrentHaveLineType As Boolean = Item.HaveLineType
            Dim iCurrentLineType As Items.cIItemLine.LineTypeEnum
            Dim iSequencePointCount As Integer
            Dim oPrevPoint As cPoint
            For Each oPoint As cPoint In Item.Points
                Dim oPaintPoint As PointF = oPoint.Point()
                Dim iJoined As AnchorRectangleTypeEnum = IIf(oPoint.IsJoined, AnchorRectangleTypeEnum.JoinedPoint, AnchorRectangleTypeEnum.None)
                Dim iFirstOrLastAll As AnchorRectangleTypeEnum
                If (oPoint.Type And cPoint.PointTypeEnum.FirstOfAll) = cPoint.PointTypeEnum.FirstOfAll Then
                    iFirstOrLastAll = AnchorRectangleTypeEnum.FirstOfAllPoint
                    'ElseIf (oPoint.Type And cPoint.PointTypeEnum.LastOfAll) = cPoint.PointTypeEnum.LastOfAll Then
                    '    iFirstOrLastAll = AnchorRectangleTypeEnum.LastOfAllPoint
                Else
                    iFirstOrLastAll = AnchorRectangleTypeEnum.None
                End If

                If oPoint.BeginSequence Then
                    iSequencePointCount = 0
                    If oPoint Is Tools.CurrentItemPoint Then
                        Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.SpecialPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                    Else
                        Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.StartPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                    End If
                    If bCurrentHaveLineType Then
                        iCurrentLineType = oPoint.LineType
                        If iCurrentLineType = Items.cIItemLine.LineTypeEnum.Undefined Then
                            iCurrentLineType = DirectCast(Item, Items.cIItemLine).LineType
                        End If
                    End If
                Else
                    If iCurrentLineType = Items.cIItemLine.LineTypeEnum.Beziers AndAlso bCurrentHaveLineType Then
                        Select Case (iSequencePointCount) Mod 3
                            Case 1
                                If oPoint Is Tools.CurrentItemPoint Then
                                    Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.SpecialPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                                Else
                                    Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.BezierControlPoint Or iFirstOrLastAll, Survey, Zoom)
                                End If
                                If Not oPrevPoint Is Nothing Then
                                    Call Graphics.DrawLine(Survey.EditPaintObjects.BezierControlLinePen, oPaintPoint, oPrevPoint.Point)
                                End If
                            Case 2
                                If oPoint Is Tools.CurrentItemPoint Then
                                    Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.SpecialPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                                Else
                                    Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.BezierControlPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                                End If
                                Dim oNextPoint As cPoint = Item.Points.Next(oPoint)
                                If Not oNextPoint Is Nothing Then
                                    Call Graphics.DrawLine(Survey.EditPaintObjects.BezierControlLinePen, oPaintPoint, oNextPoint.Point)
                                End If
                            Case Else
                                If oPoint Is Tools.CurrentItemPoint Then
                                    Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.SpecialPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                                Else
                                    Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.GenericPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                                End If
                        End Select
                    Else
                        If oPoint Is Tools.CurrentItemPoint Then
                            Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.SpecialPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                        Else
                            Call PaintAnchorRectangle(Graphics, oPaintPoint, AnchorRectangleTypeEnum.GenericPoint Or iJoined Or iFirstOrLastAll, Survey, Zoom)
                        End If
                    End If
                    'End If
                End If
                iSequencePointCount += 1
                oPrevPoint = oPoint
            Next
        End If
    End Sub

    'Public Sub MapDrawNearestStations(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, Trigpoint As cTrigPoint, Stations As List(Of frmMain.cDistance))
    '    Try
    '        If Not IsNothing(Stations) Then
    '            Using oBrush As SolidBrush = New SolidBrush(Color.FromArgb(200, Color.Green))
    '                Dim oCenterPoint As Point = Survey.Calculate.TrigPoints(Trigpoint).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop)
    '                For Each oStation As frmMain.cDistance In Stations
    '                    If Survey.Calculate.TrigPoints.Contains(oStation.Station) Then
    '                        Dim sDistance As Single = oStation.Distance
    '                        Dim oStationPoint As Point = Survey.Calculate.TrigPoints(oStation.Station).Point.To2DPoint(Calculate.cTrigPointPoint.ProjectionEnum.FromTop)
    '                        Dim sDirection As Single = modPaint.GetBearing(oCenterPoint, oStationPoint) - 90
    '                        Dim oRect As Rectangle = New Rectangle(oCenterPoint.X - sDistance, oCenterPoint.Y - sDistance, sDistance * 2, sDistance * 2)
    '                        Graphics.FillPie(oBrush, oRect, sDirection - 1, 2)
    '                    End If
    '                Next
    '        End Using
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Public Sub MapDrawAxis(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey)
        Try
            Dim oRect As RectangleF = Graphics.VisibleClipBounds
            Dim oAxisPen As Pen = Survey.EditPaintObjects.AxisPen
            Call Graphics.DrawLine(oAxisPen, 0, oRect.Top, 0, oRect.Bottom)
            Call Graphics.DrawLine(oAxisPen, oRect.Left, 0, oRect.Right, 0)
        Catch
        End Try
    End Sub

    Public Sub MapDrawMetricGrid(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, Design As cDesign, Segment As cSegment, Trigpoint As cTrigPoint, PaintZoom As Single, PaintTranslation As PointF)
        Try
            Dim oState As GraphicsState = Graphics.Save

            Dim oCenter As PointF
            If Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                'oCenter = modPaint.GetCenterPoint(Segment.Data.Plan.FromPoint, Segment.Data.Plan.ToPoint)
                If Trigpoint.Name = Segment.Data.Plan.From Then
                    oCenter = Segment.Data.Plan.FromPoint
                Else
                    oCenter = Segment.Data.Plan.ToPoint
                End If
                Call Graphics.TranslateTransform(oCenter.X, oCenter.Y, MatrixOrder.Prepend)
                Call Graphics.RotateTransform(Segment.Data.Data.Bearing, MatrixOrder.Prepend)
            Else
                If Trigpoint.Name = Segment.Data.Profile.From Then
                    oCenter = Segment.Data.Profile.FromPoint
                Else
                    oCenter = Segment.Data.Profile.ToPoint
                End If
                Dim sAngle As Single = modPaint.GetBearing(Segment.Data.Profile.FromPoint, Segment.Data.Profile.ToPoint)
                Call Graphics.TranslateTransform(oCenter.X, oCenter.Y, MatrixOrder.Prepend)
                Call Graphics.RotateTransform(sAngle, MatrixOrder.Prepend)
            End If

            Using oMainGridPath As GraphicsPath = New GraphicsPath
                Using oDetailedGridPath As GraphicsPath = New GraphicsPath
                    Dim bDrawDetailedGrid As Boolean = PaintZoom >= 10

                    Dim iGridStep As Integer = 1
                    If PaintZoom >= 10 Then
                        iGridStep = 1
                    ElseIf PaintZoom < 10 AndAlso PaintZoom >= 5 Then
                        iGridStep = 2
                    ElseIf PaintZoom < 5 AndAlso PaintZoom >= 2 Then
                        iGridStep = 5
                    ElseIf PaintZoom < 2 AndAlso PaintZoom >= 1 Then
                        iGridStep = 10
                    ElseIf PaintZoom < 1 AndAlso PaintZoom >= 0.5 Then
                        iGridStep = 50
                    Else
                        iGridStep = 100
                    End If

                    Dim oBounds As RectangleF = Graphics.VisibleClipBounds

                    Dim iStart As Integer
                    Dim iEnd As Integer

                    iStart = oBounds.Left
                    If iStart Mod iGridStep <> 0 Then
                        iStart = iStart - (iStart Mod iGridStep)
                    End If
                    iEnd = oBounds.Right
                    For x As Single = iStart To iEnd Step iGridStep
                        'Call Graphics.DrawLine(oGridPen, x, oBounds.Top, x, oBounds.Bottom)
                        Call oMainGridPath.StartFigure()
                        Call oMainGridPath.AddLine(x, oBounds.Top, x, oBounds.Bottom)
                    Next

                    iStart = oBounds.Top
                    If iStart Mod iGridStep <> 0 Then
                        iStart = iStart - (iStart Mod iGridStep)
                    End If
                    iEnd = oBounds.Bottom
                    For y As Single = iStart To iEnd Step iGridStep
                        'Call Graphics.DrawLine(oGridPen, oBounds.Left, y, oBounds.Right, y)
                        Call oMainGridPath.StartFigure()
                        Call oMainGridPath.AddLine(oBounds.Left, y, oBounds.Right, y)
                    Next

                    '------------------------------------------------------------------------------------------------
                    If bDrawDetailedGrid Then
                        Dim sDetailedGridStep As Single
                        If PaintZoom >= 50 Then
                            sDetailedGridStep = iGridStep / 10
                        Else
                            sDetailedGridStep = iGridStep / 2
                        End If

                        Dim sDistance As Single
                        If Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                            sDistance = Segment.Data.Plan.GetProjectedDistance
                        Else
                            sDistance = Segment.Data.Profile.GetProjectedDistance
                        End If

                        Dim oDetailedGridBound As RectangleF = New RectangleF(-sDistance * 2, -sDistance * 2, sDistance * 4, sDistance * 4)
                        Dim sStart As Single
                        Dim sEnd As Single
                        sStart = oDetailedGridBound.Left
                        If sStart Mod sDetailedGridStep <> 0 Then
                            sStart = sStart - (sStart Mod sDetailedGridStep)
                        End If
                        sEnd = oDetailedGridBound.Right
                        For x As Single = sStart To sEnd Step sDetailedGridStep
                            Call oDetailedGridPath.StartFigure()
                            Call oDetailedGridPath.AddLine(x, oDetailedGridBound.Top, x, oDetailedGridBound.Bottom)
                        Next

                        sStart = oDetailedGridBound.Top
                        If sStart Mod sDetailedGridStep <> 0 Then
                            sStart = sStart - (sStart Mod sDetailedGridStep)
                        End If
                        sEnd = oDetailedGridBound.Bottom
                        For y As Single = sStart To sEnd Step sDetailedGridStep
                            Call oDetailedGridPath.StartFigure()
                            Call oDetailedGridPath.AddLine(oDetailedGridBound.Left, y, oDetailedGridBound.Right, y)
                        Next
                    End If
                    '------------------------------------------------------------------------------------------------

                    Call Graphics.DrawPath(Survey.EditPaintObjects.GridPen, oMainGridPath)
                    Call Graphics.DrawPath(Survey.EditPaintObjects.DetailedGridPen, oDetailedGridPath)
                End Using
            End Using

            Call Graphics.Restore(oState)
        Catch
        End Try
    End Sub

    'Public Sub MapDrawOrthoPhoto(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, PaintZoom As Single)
    '    Try
    '        With Survey.Surface.OrthoPhotos
    '            If Not .IsDefaultEmpty Then
    '                Dim oOrthoPhoto As Surface.cOrthoPhoto = .Default
    '                Dim iGridStepX As Integer = oOrthoPhoto.XSize
    '                Dim iGridStepY As Integer = oOrthoPhoto.YSize
    '                Dim oBounds As RectangleF = Graphics.VisibleClipBounds

    '                Dim sLeft As Single = oOrthoPhoto.GetTLTrigpoint.X
    '                Dim [sTop] As Single = oOrthoPhoto.GetTLTrigpoint.Y
    '                Dim sWidth As Single = oOrthoPhoto.Photo.Width * iGridStepX
    '                Dim sHeight As Single = oOrthoPhoto.Photo.Height * iGridStepY
    '                Dim oRect As RectangleF = New RectangleF(sLeft, [sTop], sWidth, sHeight)
    '                Call Graphics.DrawImage(oOrthoPhoto.Photo, oRect)
    '            End If
    '        End With
    '    Catch
    '    End Try
    'End Sub

    Public Sub MapDrawElevationGrid(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, PaintZoom As Single)
        Try
            With Survey.Surface.Elevations
                If Not .IsDefaultEmpty Then
                    Dim oElevation As Surface.cElevation = .Default
                    Dim iGridStepX As Integer = oElevation.XSize
                    Dim iGridStepY As Integer = oElevation.YSize
                    Using oGridPen As Pen = Survey.EditPaintObjects.GridPen
                        Dim oBounds As RectangleF = Graphics.VisibleClipBounds

                        Dim iXStart As Integer
                        Dim iXEnd As Integer
                        Dim iYStart As Integer
                        Dim iYEnd As Integer

                        iXStart = oBounds.Left
                        If iXStart Mod iGridStepX <> 0 Then
                            iXStart = iXStart - (iXStart Mod iGridStepX)
                        End If
                        iXEnd = oBounds.Right
                        iYStart = oBounds.Top
                        If iYStart Mod iGridStepY <> 0 Then
                            iYStart = iYStart - (iYStart Mod iGridStepY)
                        End If
                        iYEnd = oBounds.Bottom

                        Dim oRange As SizeF = oElevation.GetHeightRange
                        For y As Single = iYStart To iYEnd Step iGridStepY
                            For x As Single = iXStart To iXEnd Step iGridStepX
                                Dim sHeight As Single = oElevation.GetElevation(x, y)
                                If sHeight <> Surface.cElevation.NoDataValue Then
                                    Dim iGrayScale As Integer = 255 - (255 * ((sHeight - oRange.Width) / (oRange.Height - oRange.Width)))
                                    oGridPen.Color = Color.FromArgb(255, iGrayScale, iGrayScale, iGrayScale)
                                    Call Graphics.DrawLine(oGridPen, x - 1, y, x + 1, y)
                                    Call Graphics.DrawLine(oGridPen, x, y - 1, x, y + 1)
                                End If
                            Next
                        Next
                    End Using
                End If
            End With
        Catch
        End Try
    End Sub

    Public Sub MapDrawMetricGrid(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, PaintZoom As Single)
        Try
            Dim iGridStep As Integer = 1
            If PaintZoom >= 10 Then
                iGridStep = 1
            ElseIf PaintZoom < 10 AndAlso PaintZoom >= 5 Then
                iGridStep = 2
            ElseIf PaintZoom < 5 AndAlso PaintZoom >= 2 Then
                iGridStep = 5
            ElseIf PaintZoom < 2 AndAlso PaintZoom >= 1 Then
                iGridStep = 10
            ElseIf PaintZoom < 1 AndAlso PaintZoom >= 0.5 Then
                iGridStep = 50
            Else
                iGridStep = 100
            End If
            Dim oGridPen As Pen = Survey.EditPaintObjects.GridPen
            Dim oBounds As RectangleF = Graphics.VisibleClipBounds

            Dim iStart As Integer
            Dim iEnd As Integer

            iStart = oBounds.Left
            If iStart Mod iGridStep <> 0 Then
                iStart = iStart - (iStart Mod iGridStep)
            End If
            iEnd = oBounds.Right
            For x As Single = iStart To iEnd Step iGridStep
                Call Graphics.DrawLine(oGridPen, x, oBounds.Top, x, oBounds.Bottom)
            Next

            iStart = oBounds.Top
            If iStart Mod iGridStep <> 0 Then
                iStart = iStart - (iStart Mod iGridStep)
            End If
            iEnd = oBounds.Bottom
            For y As Single = iStart To iEnd Step iGridStep
                Call Graphics.DrawLine(oGridPen, oBounds.Left, y, oBounds.Right, y)
            Next
        Catch
        End Try
    End Sub

    Public Sub MapDrawOrthophoto(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, Orthophoto As Surface.cOrthoPhoto, Options As cSurfaceOptions.cSurfaceOptionsItem)
        Try
            With Orthophoto
                If Not .IsEmpty Then
                    Dim oImage As Image = .Photo
                    Dim oImageBounds As RectangleF = New RectangleF(.GetTLPoint.X, .GetTLPoint.Y, .Photo.Width * .XSize, .Photo.Height * .YSize)
                    Call DrawImageWithTransparency(Graphics, oImage, oImageBounds, Options.Transparency)
                    Graphics.DrawRectangle(New Pen(Brushes.DimGray, -1), oImageBounds.Left, oImageBounds.Top, oImageBounds.Width, oImageBounds.Height)
                End If
            End With
        Catch ex As Exception
            Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "orthophoto paint error: " & ex.Message)
        End Try
    End Sub

    Public Sub MapDrawElevation(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, Elevation As Surface.cElevation, Options As cSurfaceOptions.cSurfaceOptionsItem)
        Try
            With Elevation
                If Not .IsEmpty Then
                    Dim oImage As Image = .GetImage(.Columns, .Rows)
                    Dim oImageBounds As RectangleF = New RectangleF(.GetTLPoint.X, .GetTLPoint.Y, .Columns * .XSize, .Rows * .YSize)
                    Call DrawImageWithTransparency(Graphics, oImage, oImageBounds, Options.Transparency)
                    Graphics.DrawRectangle(New Pen(Brushes.DimGray, -1), oImageBounds.Left, oImageBounds.Top, oImageBounds.Width, oImageBounds.Height)
                End If
            End With
        Catch ex As Exception
            Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "elevation paint error: " & ex.Message)
        End Try
    End Sub

    Public Function GetSurfaceImage(Survey As cSurvey.cSurvey, SurfaceOptions As cSurface3DOptions, TextureLOD As Single) As Image
        Dim oElevation As Surface.cElevation = DirectCast(Survey.Surface(SurfaceOptions.Elevation.ID), Surface.cElevation)

        Dim sFactor As Single = TextureLOD
        Dim sWidth As Single = oElevation.Width / sFactor
        Dim sHeight As Single = oElevation.Height / sFactor
        Dim iWidth As Integer = sWidth
        Dim iHeight As Integer = sHeight
        Dim oImage As Bitmap = New Bitmap(iWidth, iHeight)
        Using oGraphics As Graphics = Graphics.FromImage(oImage)
            Call oGraphics.Clear(Color.White)

            Dim oBaseCoordiante As cCoordinate = oElevation.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft)
            Dim oUTMBaseCoordinate As UTM = New modUTM.UTM(oBaseCoordiante)
            Dim dBaseX As Double = oUTMBaseCoordinate.East
            Dim dBaseY As Double = oUTMBaseCoordinate.North

            For Each oSurfaceItem As cSurface3DOptions.cSurface3DOptionsItem In SurfaceOptions
                If oSurfaceItem.Visible Then
                    Dim oItem As Surface.cISurfaceItem = Survey.Surface(oSurfaceItem.ID)
                    If TypeOf oItem Is Surface.cOrthoPhoto Then
                        Dim oOrthoPhoto As Surface.cOrthoPhoto = oItem
                        Dim oCoordinate As UTM = New modUTM.UTM(oOrthoPhoto.GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft))
                        Dim dX As Double = (oCoordinate.East - dBaseX) / sFactor
                        Dim dY As Double = -(oCoordinate.North - dBaseY) / sFactor
                        Dim dWidth As Double = oOrthoPhoto.Width / sFactor
                        Dim dHeight As Double = oOrthoPhoto.Height / sFactor
                        Call modPaint.DrawImageWithTransparency(oGraphics, oOrthoPhoto.Photo, New RectangleF(dX, dY, dWidth, dHeight), oSurfaceItem.Transparency)
                    Else
                        Dim oWMS As Surface.cWMS = oItem
                        Dim oCoordinate As Calculate.cTrigPointCoordinate = New Calculate.cTrigPointCoordinate(oBaseCoordiante)
                        Call modPaint.MapDrawWMS(oGraphics, Survey, oWMS, oSurfaceItem, oCoordinate, TextureLOD)
                    End If
                End If
            Next
        End Using
        Call oImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Return oImage
    End Function

    Public Function GetImageThumbnail(Image As Image, Width As Integer, Height As Integer) As Image
        Dim oThumbImage As Image = New Bitmap(Width, Height)
        Using oGr As Graphics = Graphics.FromImage(oThumbImage)
            Call oGr.Clear(Color.Transparent)
            Call modPaint.DrawScaledImage(oGr, Image, New RectangleF(0, 0, Width, Height))
        End Using
        Return oThumbImage
    End Function

    Public Sub DrawImageWithTransparency(Graphics As Graphics, Image As Bitmap, Bounds As RectangleF, Transparency As Single)
        If Transparency > 0 Then
            Dim oCM As ColorMatrix = New ColorMatrix
            Using oIA As ImageAttributes = New ImageAttributes()
                oCM.Matrix33 = Transparency ' (255 - Transparency) / 255
                Call oIA.SetColorMatrix(oCM)
                Call Graphics.DrawImage(Image, {New PointF(Bounds.Left, Bounds.Top), New PointF(Bounds.Right, Bounds.Top), New PointF(Bounds.Left, Bounds.Bottom)}, New RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel, oIA)
            End Using
        Else
            Call Graphics.DrawImage(Image, Bounds)
        End If
    End Sub

    Public Sub MapDrawWMS(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, WMS As Surface.cWMS, Options As cSurface3DOptions.cSurface3DOptionsItem, OriginCoordinate As Calculate.cTrigPointCoordinate, TextureLOD As Single)
        Dim sOrigin As String = Survey.Properties.Origin
        If Survey.Calculate.TrigPoints.Contains(sOrigin) AndAlso Not Survey.Calculate.TrigPoints(Survey.Properties.Origin).Coordinate Is Nothing AndAlso Not WMS.IsEmpty Then
            Dim oBounds As RectangleF = Graphics.VisibleClipBounds
            Dim oBLPoint As PointF = New PointF(oBounds.Left * TextureLOD, -1 * oBounds.Bottom * TextureLOD)
            Dim oTRPoint As PointF = New PointF(oBounds.Right * TextureLOD, -1 * oBounds.Top * TextureLOD)

            Dim dMC As Single = Survey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians
            oBLPoint = modPaint.RotatePointByRadians(oBLPoint, dMC)
            oTRPoint = modPaint.RotatePointByRadians(oTRPoint, dMC)
            Dim oUTM As modUTM.UTM = modUTM.WGS84ToUTM(OriginCoordinate)

            Dim sStep As Integer = 200

            oBLPoint.X = ((oBLPoint.X) \ sStep) * sStep
            oBLPoint.Y = ((oBLPoint.Y) \ sStep) * sStep
            oTRPoint.X = ((oTRPoint.X) \ sStep) * sStep
            oTRPoint.Y = ((oTRPoint.Y) \ sStep) * sStep

            Dim dX1 As Decimal = oUTM.East + oBLPoint.X
            Dim dX2 As Decimal = oUTM.East + oTRPoint.X
            Dim dY1 As Decimal = oUTM.North + oBLPoint.Y
            Dim dY2 As Decimal = oUTM.North + oTRPoint.Y
            Dim dWidth As Decimal = sStep 'oBounds.Width
            Dim dHeight As Decimal = sStep 'oBounds.Height

            Dim iSystem As Integer = modWMSManager.GetSystemFromUTM(WMS, oUTM)
            Dim sFilename As String = WMS.ID & "_%SYSTEM%_%X1%_%Y1%_%X2%_%Y2%"
            'Dim sURL As String = modWMSManager.FormatURL(WMS.URL, "CRS:84&LAYERS=" & WMS.Layer & "&PROJECTION=EPSG%3A4326&FORMAT=image/png&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A%SYSTEM%&BBOX=%X1%,%Y1%,%X2%,%Y2%&WIDTH=%WIDTH%&HEIGHT=%HEIGHT%")
            Dim sURL As String = modWMSManager.FormatURL(WMS.URL, "LAYERS=" & WMS.Layer & "&PROJECTION=EPSG%3A4326&FORMAT=image/png&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A%SYSTEM%&CRS=EPSG%3A%SYSTEM%&BBOX=%X1%,%Y1%,%X2%,%Y2%&WIDTH=%WIDTH%&HEIGHT=%HEIGHT%")

            Dim iIndex As Integer = 0
            Dim iCount As Integer = ((((dY2 + sStep) - (dY1 - sStep)) / sStep) + 1) * ((((dX2 + sStep) - (dX1 - sStep)) / sStep) + 1)

            'resetto eventuali code di download in corso...
            Call modWMSManager.WMSDownloadFileReset()

            Call Survey.RaiseOnProgressEvent("wms.compose", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, String.Format(modMain.GetLocalizedString("main.textpart86"), WMS.Name), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
            For dY As Decimal = dY1 - sStep To dY2 + sStep Step sStep
                For dX As Decimal = dX1 - sStep To dX2 + sStep Step sStep
                    If iIndex Mod 20 = 0 Then Call Survey.RaiseOnProgressEvent("wms.compose", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("main.textpart86"), WMS.Name), iIndex / iCount, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImagePaint)
                    Try
                        Dim oImage As Bitmap = modWMSManager.WMSLoadTileAsync(Survey, WMS.Name, sFilename, sURL, iSystem, dX, dY, dX + sStep, dY + sStep, sStep, sStep, False)
                        Dim oImageBounds As RectangleF = New RectangleF((dX - oUTM.East) / TextureLOD, (-1 * (dY - oUTM.North + sStep)) / TextureLOD, (sStep + 1) / TextureLOD, (sStep + 1) / TextureLOD)
                        Call DrawImageWithTransparency(Graphics, oImage, oImageBounds, Options.Transparency)
                    Catch ex As Exception
                        Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "wms compose error: " & ex.Message, True)
                    End Try
                    iIndex += 1
                Next
            Next
            Call Survey.RaiseOnProgressEvent("wms.compose", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            'avvio il download se c'è qualcosa in coda...
            Call modWMSManager.WMSDownloadTileAsync()
        End If
    End Sub

    Public Sub MapDrawWMS(ByVal Graphics As Graphics, ByVal Survey As cSurvey.cSurvey, WMS As Surface.cWMS, Options As cSurfaceOptions.cSurfaceOptionsItem)
        Dim sOrigin As String = Survey.Properties.Origin
        If Survey.Calculate.TrigPoints.Contains(sOrigin) AndAlso Not Survey.Calculate.TrigPoints(Survey.Properties.Origin).Coordinate Is Nothing AndAlso Not WMS.IsEmpty Then
            Dim oBounds As RectangleF = Graphics.VisibleClipBounds
            Dim oBLPoint As PointF = New PointF(oBounds.Left, -1 * oBounds.Bottom)
            Dim oTRPoint As PointF = New PointF(oBounds.Right, -1 * oBounds.Top)

            Dim dMC As Single = Survey.Calculate.GeoMagDeclinationData.MeridianConvergenceRadians
            oBLPoint = modPaint.RotatePointByRadians(oBLPoint, dMC)
            oTRPoint = modPaint.RotatePointByRadians(oTRPoint, dMC)
            Dim oOriginCoordinate As Calculate.cTrigPointCoordinate = Survey.Calculate.TrigPoints(Survey.Properties.Origin).Coordinate
            Dim oUTM As modUTM.UTM = modUTM.WGS84ToUTM(oOriginCoordinate)

            Dim sStep As Integer = 200

            oBLPoint.X = ((oBLPoint.X) \ sStep) * sStep
            oBLPoint.Y = ((oBLPoint.Y) \ sStep) * sStep
            oTRPoint.X = ((oTRPoint.X) \ sStep) * sStep
            oTRPoint.Y = ((oTRPoint.Y) \ sStep) * sStep

            Dim dX1 As Decimal = oUTM.East + oBLPoint.X
            Dim dX2 As Decimal = oUTM.East + oTRPoint.X
            Dim dY1 As Decimal = oUTM.North + oBLPoint.Y
            Dim dY2 As Decimal = oUTM.North + oTRPoint.Y
            Dim dWidth As Decimal = sStep 'oBounds.Width
            Dim dHeight As Decimal = sStep 'oBounds.Height

            Dim iSystem As Integer = modWMSManager.GetSystemFromUTM(WMS, oUTM)
            Dim sFilename As String = WMS.ID & "_%SYSTEM%_%X1%_%Y1%_%X2%_%Y2%"
            'Dim sURL As String = modWMSManager.FormatURL(WMS.URL, "CRS:84&LAYERS=" & WMS.Layer & "&PROJECTION=EPSG%3A4326&FORMAT=image/png&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A%SYSTEM%&BBOX=%X1%,%Y1%,%X2%,%Y2%&WIDTH=%WIDTH%&HEIGHT=%HEIGHT%")
            Dim sURL As String = modWMSManager.FormatURL(WMS.URL, "LAYERS=" & WMS.Layer & "&PROJECTION=EPSG%3A4326&FORMAT=image/png&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetMap&STYLES=&SRS=EPSG%3A%SYSTEM%&CRS=EPSG%3A%SYSTEM%&BBOX=%X1%,%Y1%,%X2%,%Y2%&WIDTH=%WIDTH%&HEIGHT=%HEIGHT%")

            Dim iIndex As Integer = 0
            Dim iCount As Integer = ((((dY2 + sStep) - (dY1 - sStep)) / sStep) + 1) * ((((dX2 + sStep) - (dX1 - sStep)) / sStep) + 1)

            ''resetto eventuali code di download in corso...
            'Call modWMSManager.WMSDownloadFileReset()

            Call Survey.RaiseOnProgressEvent("wms.compose", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Begin, String.Format(modMain.GetLocalizedString("main.textpart86"), WMS.Name), 0, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageDownload)
            For dY As Decimal = dY1 - sStep To dY2 + sStep Step sStep
                For dX As Decimal = dX1 - sStep To dX2 + sStep Step sStep
                    If iIndex Mod 20 = 0 Then Call Survey.RaiseOnProgressEvent("wms.compose", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("main.textpart86"), WMS.Name), iIndex / iCount, cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ShowPercentage Or cSurvey.cSurvey.OnProgressEventArgs.ProgressOptionsEnum.ImageDownload)
                    Try
                        Dim oImage As Bitmap = modWMSManager.WMSLoadTileAsync(Survey, WMS.Name, sFilename, sURL, iSystem, dX, dY, dX + sStep, dY + sStep, sStep, sStep, False)
                        Dim oImageBounds As RectangleF = New RectangleF(dX - oUTM.East, -1 * (dY - oUTM.North + sStep), sStep + 1, sStep + 1)
                        Call DrawImageWithTransparency(Graphics, oImage, oImageBounds, Options.Transparency)
                    Catch ex As Exception
                        Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "wms compose error: " & ex.Message, True)
                    End Try
                    iIndex += 1
                Next
            Next
            Call Survey.RaiseOnProgressEvent("wms.compose", cSurvey.cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)

            'avvio il download se c'è qualcosa in coda...
            Call modWMSManager.WMSDownloadTileAsync()
        End If
    End Sub

    Public Function FindPaperSize(PrinterSettings As Printing.PrinterSettings, ByVal PaperSize As String) As Printing.PaperSize
        For Each oPaperSize As Printing.PaperSize In PrinterSettings.PaperSizes
            If oPaperSize.PaperName = PaperSize Then
                Return oPaperSize
            End If
        Next
        Return PrinterSettings.DefaultPageSettings.PaperSize
    End Function

    Public Function AdjustBounds(ByVal Rect As RectangleF, Optional MinSize As Integer = 1) As RectangleF
        If Rect.Width < MinSize Then
            Rect.Width = MinSize
        End If
        If Rect.Height < MinSize Then
            Rect.Height = MinSize
        End If
        Return Rect
    End Function

    Private oPs As Printing.PrinterSettings

    Public Sub MapDrawPrintOrExportArea(ByVal Graphics As Graphics, PaintOptions As cOptions, ByVal Survey As cSurvey.cSurvey, ByVal CurrentDesign As cDesign, ByVal PaintZoom As Single)
        Dim bDraw As Boolean
        Dim iDesignStyle As cIOptionPrintAndExportArea.DesignStyleEnum
        Dim oProfile As cIProfile
        If TypeOf PaintOptions Is cIOptionPrintAndExportArea Then
            Dim oPaintOptions As cIOptionPrintAndExportArea = PaintOptions
            bDraw = oPaintOptions.DrawPrintOrExportArea
            iDesignStyle = oPaintOptions.DrawPrintOrExportAreaDesignStyle
            oProfile = oPaintOptions.GetPrintOrExportProfile(CurrentDesign)
        Else
            bDraw = True
            oProfile = PaintOptions.GetParent
        End If

        If bDraw Then
            Try
                If TypeOf oProfile Is cPreviewProfile Then
                    Dim oPreviewOptions As cSurvey.Design.cOptionsPreview = oProfile.Options  'Survey.PreviewProfiles.Item(0).Options
                    If IsNothing(oPs) Then oPs = New Printing.PrinterSettings
                    If oPs.PrinterName <> oPreviewOptions.PrinterName Then oPs.PrinterName = oPreviewOptions.PrinterName
                    oPs.DefaultPageSettings.PaperSize = FindPaperSize(oPs, oPreviewOptions.PageFormat)
                    oPs.DefaultPageSettings.Landscape = oPreviewOptions.PageLandscape
                    oPs.DefaultPageSettings.Margins = oPreviewOptions.PageMargins
                    Dim oPageRect As RectangleF = oPs.DefaultPageSettings.Bounds
                    Dim oPageWithMarginRect As RectangleF = New RectangleF(oPageRect.Left + oPs.DefaultPageSettings.Margins.Left, oPageRect.Top + oPs.DefaultPageSettings.Margins.Top, oPageRect.Width - oPs.DefaultPageSettings.Margins.Left - oPs.DefaultPageSettings.Margins.Right, oPageRect.Height - oPs.DefaultPageSettings.Margins.Top - oPs.DefaultPageSettings.Margins.Bottom)

                    Dim oRect As RectangleF = CurrentDesign.GetDesignVisibleBounds(oPreviewOptions)
                    oRect = AdjustBounds(oRect, 1)

                    Dim sMaxZoom As Single = modPaint.GetZoomFactor(Graphics, 10)
                    Dim sMinZoom As Single = modPaint.GetZoomFactor(Graphics, 50000)

                    Dim sPaintZoom As Single = 0
                    If oPreviewOptions.ScaleMode = cIOptionsPreview.ScaleModeEnum.sAutomatic Then
                        Dim sDesignWidth As Single = oRect.Size.Width
                        Dim sDesignHeight As Single = oRect.Size.Height
                        Dim sPageWidth As Single = oPageWithMarginRect.Size.Width '* 0.000254
                        Dim sPageHeight As Single = oPageWithMarginRect.Size.Height '* 0.000254
                        Dim sDeltaX As Single = sPageWidth / sDesignWidth
                        Dim sDeltaY As Single = sPageHeight / sDesignHeight
                        Dim sDelta As Single = IIf(sDeltaX < sDeltaY, sDeltaX, sDeltaY)
                        If Single.IsInfinity(sDelta) Then sDelta = 100
                        sPaintZoom = sDelta * 0.9
                        If sPaintZoom < sMinZoom Then sPaintZoom = sMinZoom
                        If sPaintZoom > sMaxZoom Then sPaintZoom = sMaxZoom
                        oPreviewOptions.CurrentScale = modPaint.GetScaleFactor(Graphics, sPaintZoom)
                    Else
                        Dim iFactor As Integer = oPreviewOptions.Scale
                        oPreviewOptions.CurrentScale = iFactor
                        sPaintZoom = modPaint.GetZoomFactor(Graphics, iFactor)
                    End If

                    oPageRect = modPaint.FullScaleRectangle(oPageRect, 1 / sPaintZoom, 1 / sPaintZoom)
                    oPageWithMarginRect = modPaint.FullScaleRectangle(oPageWithMarginRect, 1 / sPaintZoom, 1 / sPaintZoom)
                    Using oMatrix = New Matrix()
                        Call oMatrix.Translate(-1 * (-oRect.Left + oPageRect.Left + (oPageRect.Width - (oRect.Width)) / 2), -1 * (-oRect.Top + oPageRect.Top + (oPageRect.Height - (oRect.Height)) / 2))
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddRectangle(oPageRect)
                            Call oPath.Transform(oMatrix)
                            Call Graphics.DrawPath(PaintOptions.PaintObjects.PrintOrExportBounds, oPath)
                        End Using
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddRectangle(oPageWithMarginRect)
                            Call oPath.Transform(oMatrix)
                            Call Graphics.DrawPath(PaintOptions.PaintObjects.PrintOrExportMarginsBounds, oPath)
                        End Using
                    End Using

                    If iDesignStyle = cIOptionPrintAndExportArea.DesignStyleEnum.Schematics Then
                        If CurrentDesign.Type = cIDesign.cDesignTypeEnum.Plan Then
                            Call Survey.Plan.Paint(Graphics, oPreviewOptions, cDrawOptions.Schematic, Helper.Editor.cEmptyEditDesignSelection.Empty)
                        ElseIf CurrentDesign.Type = cIDesign.cDesignTypeEnum.Profile Then
                            Call Survey.Profile.Paint(Graphics, oPreviewOptions, cDrawOptions.Schematic, Helper.Editor.cEmptyEditDesignSelection.Empty)
                        End If
                    End If
                ElseIf TypeOf oProfile Is cExportProfile Then
                    Dim oExportOptions As cSurvey.Design.cOptionsExport = oProfile.Options
                    Dim oPageRect As RectangleF = New RectangleF(0, 0, oExportOptions.ImageWidth, oExportOptions.ImageHeight)
                    Dim oPageWithMarginRect As RectangleF = New RectangleF(oPageRect.Left + oExportOptions.Margins.Left, oPageRect.Top + oExportOptions.Margins.Top, oPageRect.Width - oExportOptions.Margins.Left - oExportOptions.Margins.Right, oPageRect.Height - oExportOptions.Margins.Top - oExportOptions.Margins.Bottom)

                    Dim oRect As RectangleF = CurrentDesign.GetDesignVisibleBounds(oExportOptions)
                    oRect = AdjustBounds(oRect, 1)

                    Dim sMaxZoom As Single = modPaint.GetZoomFactor(Graphics, 10)
                    Dim sMinZoom As Single = modPaint.GetZoomFactor(Graphics, 50000)

                    Dim sPaintZoom As Single = 0
                    If oExportOptions.ScaleMode = cIOptionsPreview.ScaleModeEnum.sAutomatic Then
                        Dim sDesignWidth As Single = oRect.Size.Width
                        Dim sDesignHeight As Single = oRect.Size.Height
                        Dim sPageWidth As Single = oPageWithMarginRect.Size.Width '* 0.000254
                        Dim sPageHeight As Single = oPageWithMarginRect.Size.Height '* 0.000254
                        Dim sDeltaX As Single = sPageWidth / sDesignWidth
                        Dim sDeltaY As Single = sPageHeight / sDesignHeight
                        Dim sDelta As Single = IIf(sDeltaX < sDeltaY, sDeltaX, sDeltaY)
                        If Single.IsInfinity(sDelta) Then sDelta = 100
                        sPaintZoom = sDelta
                        If sPaintZoom < sMinZoom Then sPaintZoom = sMinZoom
                        If sPaintZoom > sMaxZoom Then sPaintZoom = sMaxZoom
                        oExportOptions.CurrentScale = modPaint.GetScaleFactor(Graphics, sPaintZoom)
                    Else
                        Dim iFactor As Integer = oExportOptions.Scale
                        oExportOptions.CurrentScale = iFactor
                        'zoom factor from graphics...export use a standard graphics to get output
                        sPaintZoom = modPaint.GetZoomFactor(Graphics, iFactor)
                    End If

                    oPageRect = modPaint.FullScaleRectangle(oPageRect, 1 / sPaintZoom, 1 / sPaintZoom)
                    oPageWithMarginRect = modPaint.FullScaleRectangle(oPageWithMarginRect, 1 / sPaintZoom, 1 / sPaintZoom)
                    Using oMatrix = New Matrix()
                        Call oMatrix.Translate(-1 * (-oRect.Left + oPageRect.Left + (oPageRect.Width - (oRect.Width)) / 2), -1 * (-oRect.Top + oPageRect.Top + (oPageRect.Height - (oRect.Height)) / 2))
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddRectangle(oPageRect)
                            Call oPath.Transform(oMatrix)
                            Call Graphics.DrawPath(PaintOptions.PaintObjects.PrintOrExportBounds, oPath)
                        End Using
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddRectangle(oPageWithMarginRect)
                            Call oPath.Transform(oMatrix)
                            Call Graphics.DrawPath(PaintOptions.PaintObjects.PrintOrExportMarginsBounds, oPath)
                        End Using
                    End Using

                    If iDesignStyle = cIOptionPrintAndExportArea.DesignStyleEnum.Schematics Then
                        If CurrentDesign.Type = cIDesign.cDesignTypeEnum.Plan Then
                            Call Survey.Plan.Paint(Graphics, oExportOptions, cDrawOptions.Schematic, Helper.Editor.cEmptyEditDesignSelection.Empty)
                        ElseIf CurrentDesign.Type = cIDesign.cDesignTypeEnum.Profile Then
                            Call Survey.Profile.Paint(Graphics, oExportOptions, cDrawOptions.Schematic, Helper.Editor.cEmptyEditDesignSelection.Empty)
                        End If
                    End If
                End If
            Catch ex As Exception
                Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "print area drawing error: " & ex.Message)
            End Try
        End If
    End Sub

    Public Sub MapDrawRulers(ByVal Graphics As Graphics, PaintOptions As cOptions, ByVal Survey As cSurvey.cSurvey, Tools As cEditDesignTools, ByVal DrawRulesStyle As frmMain.RulersStyleEnum, ByVal PaintZoom As Single)
        Try
            Dim sDPIRatio As Single = Graphics.DpiX / 96.0F
            Using oFont As Font = New Font(Survey.EditPaintObjects.RulersFont.FontFamily, 6 / (PaintZoom * sDPIRatio))
                Using oSF As StringFormat = New StringFormat
                    oSF.Alignment = StringAlignment.Far
                    oSF.LineAlignment = StringAlignment.Near
                    oSF.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap

                    Dim oFontSize As SizeF = Graphics.MeasureString("00000", oFont)
                    Dim sfontWidth As Single = oFontSize.Width * PaintZoom
                    Dim sfontHeight As Single = oFontSize.Height * PaintZoom

                    Dim oBounds As RectangleF = Graphics.VisibleClipBounds
                    Dim iStart As Single
                    Dim iEnd As Single

                    Dim sStepCaption As Single
                    Dim sStepInterval As Single
                    If PaintZoom >= 10 Then
                        sStepInterval = 1
                    ElseIf PaintZoom < 10 AndAlso PaintZoom >= 5 Then
                        sStepInterval = 2
                    ElseIf PaintZoom < 5 AndAlso PaintZoom >= 2 Then
                        sStepInterval = 5
                    ElseIf PaintZoom < 2 AndAlso PaintZoom >= 1 Then
                        sStepInterval = 10
                    ElseIf PaintZoom < 1 AndAlso PaintZoom >= 0.5 Then
                        sStepInterval = 50
                    ElseIf PaintZoom < 0.5 AndAlso PaintZoom >= 0.1 Then
                        sStepInterval = 100
                    Else
                        sStepInterval = 500
                    End If
                    sStepCaption = sStepInterval

                    Dim oHRect As RectangleF = New RectangleF(oBounds.Left, oBounds.Bottom - (8 + sfontWidth) / PaintZoom, oBounds.Width - ((8 + sfontWidth) / PaintZoom), (8 + sfontWidth) / PaintZoom)
                    Dim oVRect As RectangleF = New RectangleF(oBounds.Right - (8 + sfontWidth) / PaintZoom, oBounds.Top, (8 + sfontWidth) / PaintZoom, oBounds.Height - ((8 + sfontWidth) / PaintZoom))
                    Dim oXRect As RectangleF = New RectangleF(oBounds.Right - (8 + sfontWidth) / PaintZoom, oBounds.Bottom - (8 + sfontWidth) / PaintZoom, (8 + sfontWidth) / PaintZoom, (8 + sfontWidth) / PaintZoom)

                    If DrawRulesStyle = frmMain.RulersStyleEnum.Advanced Then
                        Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersBackgroundBrush, oHRect)
                        Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersBackgroundBrush, oVRect)
                        Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersBackgroundBrush, oXRect)

                        Dim oUsedBounds As RectangleF = Tools.Design.GetVisibleBounds(PaintOptions)
                        If Not IsRectangleEmpty(oUsedBounds) Then
                            Dim oHUsedRect As RectangleF = New RectangleF(oUsedBounds.Left, oBounds.Bottom - (8 + sfontWidth) / PaintZoom, oUsedBounds.Width, (8 + sfontWidth) / PaintZoom)
                            Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersUsedBackgroundBrush, oHUsedRect)
                            Dim oVUsedRect As RectangleF = New RectangleF(oBounds.Right - (8 + sfontWidth) / PaintZoom, oUsedBounds.Top, (8 + sfontWidth) / PaintZoom, oUsedBounds.Height)
                            Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersUsedBackgroundBrush, oVUsedRect)

                            If PaintOptions.HighlightCurrentCave Then
                                Dim oCurrentBounds As RectangleF = Tools.Design.GetVisibleCaveBounds(PaintOptions, Tools.CurrentCave, Tools.CurrentBranch, True)
                                If Not IsRectangleEmpty(oCurrentBounds) Then
                                    Dim oHCurrentRect As RectangleF = New RectangleF(oCurrentBounds.Left, oBounds.Bottom - (8 + sfontWidth) / PaintZoom, oCurrentBounds.Width, (8 + sfontWidth) / PaintZoom)
                                    Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersCurrentBackgroundBrush, oHCurrentRect)

                                    Dim oVCurrentRect As RectangleF = New RectangleF(oBounds.Right - (8 + sfontWidth) / PaintZoom, oCurrentBounds.Top, (8 + sfontWidth) / PaintZoom, oCurrentBounds.Height)
                                    Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersCurrentBackgroundBrush, oVCurrentRect)
                                End If
                            End If

                            Dim oCurrentItem As cItem = Tools.CurrentItem
                            If Not IsNothing(oCurrentItem) Then
                                Dim oItemBounds As RectangleF = oCurrentItem.GetBounds()
                                If Not IsRectangleEmpty(oItemBounds) Then
                                    Using oItemSF As StringFormat = New StringFormat
                                        Dim oHCurrentRect As RectangleF = New RectangleF(oItemBounds.Left, oBounds.Bottom - (8 + sfontWidth) / PaintZoom - 2 / PaintZoom, oItemBounds.Width, 2 / PaintZoom)
                                        Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersCurrentItemBackgroundBrush, oHCurrentRect)

                                        oItemSF.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap
                                        Dim sLeft As String = String.Format("← {0:0.00}", oItemBounds.Left)
                                        Dim sWidth As String = String.Format("↔ {0:0.00}", oItemBounds.Width)
                                        Dim sRight As String = String.Format("{0:0.00} →", oItemBounds.Right)
                                        Dim oFontItemVWidth As Single = Graphics.MeasureString(sWidth, oFont).Width * 4
                                        If oItemBounds.Width > oFontItemVWidth Then
                                            oItemSF.Alignment = StringAlignment.Near
                                            Call Graphics.DrawString(sLeft, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oItemBounds.Left, oBounds.Bottom - (8 + sfontWidth) / PaintZoom - 12 / PaintZoom), oItemSF)
                                        End If
                                        oItemSF.Alignment = StringAlignment.Center
                                        Call Graphics.DrawString(sWidth, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oItemBounds.Left + oItemBounds.Width / 2, oBounds.Bottom - (8 + sfontWidth) / PaintZoom - 12 / PaintZoom), oItemSF)
                                        If oItemBounds.Width > oFontItemVWidth Then
                                            oItemSF.Alignment = StringAlignment.Far
                                            Call Graphics.DrawString(sRight, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oItemBounds.Right, oBounds.Bottom - (8 + sfontWidth) / PaintZoom - 12 / PaintZoom), oItemSF)
                                        End If
                                        Dim oVCurrentRect As RectangleF = New RectangleF(oBounds.Right - (8 + sfontWidth) / PaintZoom - 2 / PaintZoom, oItemBounds.Top, 2 / PaintZoom, oItemBounds.Height)
                                        Call Graphics.FillRectangle(Survey.EditPaintObjects.RulersCurrentItemBackgroundBrush, oVCurrentRect)

                                        oItemSF.FormatFlags = oItemSF.FormatFlags Or StringFormatFlags.DirectionVertical
                                        oItemSF.LineAlignment = StringAlignment.Far
                                        Dim [sTop] As String = String.Format("← {0:0.00}", oItemBounds.Top)
                                        Dim sHeight As String = String.Format("↔ {0:0.00}", oItemBounds.Height)
                                        Dim sBottom As String = String.Format("{0:0.00} →", oItemBounds.Bottom)
                                        Dim oFontItemHWidth As Single = Graphics.MeasureString(sHeight, oFont).Width * 4
                                        If oItemBounds.Height > oFontItemHWidth Then
                                            oItemSF.Alignment = StringAlignment.Near
                                            Call Graphics.DrawString([sTop], oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oBounds.Right - (8 + sfontWidth) / PaintZoom - 2 / PaintZoom, oItemBounds.Top), oItemSF)
                                        End If
                                        oItemSF.Alignment = StringAlignment.Center
                                        Call Graphics.DrawString(sHeight, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oBounds.Right - (8 + sfontWidth) / PaintZoom - 2 / PaintZoom, oItemBounds.Top + oItemBounds.Height / 2), oItemSF)
                                        If oItemBounds.Height > oFontItemHWidth Then
                                            oItemSF.Alignment = StringAlignment.Far
                                            Call Graphics.DrawString(sBottom, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oBounds.Right - (8 + sfontWidth) / PaintZoom - 2 / PaintZoom, oItemBounds.Bottom), oItemSF)
                                        End If
                                    End Using
                                End If
                            End If
                        End If
                    End If

                    Dim sScaledFontHeight As Single = sfontHeight / PaintZoom

                    oSF.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap Or StringFormatFlags.DirectionVertical
                    iStart = oBounds.Left
                    If iStart Mod sStepInterval <> 0 Then
                        iStart = iStart - (iStart Mod sStepInterval)
                    End If
                    iEnd = oHRect.Right
                    For sX As Single = iStart To iEnd Step sStepInterval / 2 '0.5
                        If (sX Mod sStepCaption) = 0 Then
                            Dim sXCaption As String = sX
                            If sX > 0 Then sXCaption = "+" & sXCaption
                            Call Graphics.DrawString(sXCaption, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(sX - sScaledFontHeight / 2, oBounds.Bottom - 8 / PaintZoom), oSF)
                            Call Graphics.DrawLine(Survey.EditPaintObjects.RulersUnitPen, New PointF(sX, oBounds.Bottom - 8 / PaintZoom), New PointF(sX, oBounds.Bottom))
                        Else
                            Call Graphics.DrawLine(Survey.EditPaintObjects.RulersDecimalPen, New PointF(sX, oBounds.Bottom - 5 / PaintZoom), New PointF(sX, oBounds.Bottom))
                        End If
                    Next

                    oSF.FormatFlags = StringFormatFlags.NoClip Or StringFormatFlags.NoWrap
                    iStart = oBounds.Top
                    If iStart Mod sStepInterval <> 0 Then
                        iStart = iStart - (iStart Mod sStepInterval)
                    End If
                    iEnd = oVRect.Bottom
                    For sY As Single = iStart To iEnd Step sStepInterval / 2
                        If (sY Mod sStepCaption) = 0 Then
                            Dim sYCaption As String = sY * -1
                            If sY < 0 Then sYCaption = "+" & sYCaption
                            Call Graphics.DrawString(sYCaption, oFont, Survey.EditPaintObjects.RulersFontUnitBrush, New PointF(oBounds.Right - 8 / PaintZoom, sY - sScaledFontHeight / 2), oSF)
                            Call Graphics.DrawLine(Survey.EditPaintObjects.RulersUnitPen, New PointF(oBounds.Right - 8 / PaintZoom, sY), New PointF(oBounds.Right, sY))
                        Else
                            Call Graphics.DrawLine(Survey.EditPaintObjects.RulersDecimalPen, New PointF(oBounds.Right - 5 / PaintZoom, sY), New PointF(oBounds.Right, sY))
                        End If
                    Next

                End Using
            End Using
        Catch ex As Exception
            Call Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Error, "rulers drawing error: " & ex.Message)
        End Try
    End Sub

    Public Function IsNullColor(Color As Color) As Boolean
        Return ((Color.IsEmpty) OrElse (Color = Color.Transparent) OrElse (Color.ToArgb = 0))
    End Function

    Public Sub ReducePoints(Sequence As cSequence, Delta As Single, LineType As cSurvey.Design.Items.cIItemLine.LineTypeEnum)
        'Ramer–Douglas–Peucker...only for managed use (sequence have to be added as points)
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Sequence.GetLineType(LineType)
        Dim oMarkedPoints As List(Of cPoint) = New List(Of cPoint)
        Call pReducePoints(Sequence, Delta, iLineType, oMarkedPoints)
        Dim oOrderedPoints As List(Of cPoint) = New List(Of cPoint)
        For Each oPoint As cPoint In Sequence
            If oMarkedPoints.Contains(oPoint) Then
                Call oOrderedPoints.Add(oPoint)
            End If
        Next
        Call Sequence.Clear()
        Call Sequence.AppendRange(oOrderedPoints)
    End Sub

    Public Sub ReducePoints(Points As cPoints, Delta As Single, LineType As cSurvey.Design.Items.cIItemLine.LineTypeEnum)
        'Ramer–Douglas–Peucker
        Dim oMarkedPoints As List(Of cPoint) = New List(Of cPoint)
        Dim oSequences As List(Of cSequence) = Points.GetSequences()
        For Each oSequence As cSequence In oSequences
            Dim iLineType As Items.cIItemLine.LineTypeEnum = oSequence.GetLineType(LineType)
            Call pReducePoints(oSequence, Delta, iLineType, oMarkedPoints)
        Next
        Dim oOrderedPoints As List(Of cPoint) = New List(Of cPoint)
        For Each oPoint As cPoint In Points
            If oMarkedPoints.Contains(oPoint) Then
                Call oOrderedPoints.Add(oPoint)
            End If
        Next
        Call Points.BeginUpdate()
        Call Points.Clear()
        Call Points.AddRange(oOrderedPoints)
        Call Points.EndUpdate()
    End Sub

    Private Function pGetNextMarkedPoint(Points As cSequence, MarkedPoints As List(Of cPoint), Point As cPoint, PointsToProcess As List(Of cPoint)) As cPoint
        If Point Is Nothing Then
            Return Points.First
        Else
            Dim iIndex As Integer = Points.IndexOf(Point) + 1
            For i As Integer = iIndex To Points.Count - 1
                Dim oPoint As cPoint = Points(i)
                If MarkedPoints.Contains(oPoint) Then
                    Return oPoint
                Else
                    Call PointsToProcess.Add(oPoint)
                End If
            Next
            Return Points.Last
        End If
    End Function

    Private Sub pReducePoints(Points As cSequence, Delta As Single, LineType As cSurvey.Design.Items.cIItemLine.LineTypeEnum, MarkedPoints As List(Of cPoint))
        Dim bDone As Boolean = True
        Dim iLineType As Items.cIItemLine.LineTypeEnum = Points.GetLineType(LineType)
        If iLineType = Items.cIItemLine.LineTypeEnum.Lines OrElse iLineType = Items.cIItemLine.LineTypeEnum.Splines Then
            Do
                bDone = True
                Dim oPreviousMarkedPoint As cPoint = Points.First
                If Not MarkedPoints.Contains(oPreviousMarkedPoint) Then Call MarkedPoints.Add(oPreviousMarkedPoint)
                Dim sMaxDelta As Single = 0
                Dim oMaxPoint As cPoint
                Do
                    Dim oPointsToProcess As List(Of cPoint) = New List(Of cPoint)
                    Dim oFirstPoint As cPoint = oPreviousMarkedPoint
                    Dim oLastPoint As cPoint = pGetNextMarkedPoint(Points, MarkedPoints, oFirstPoint, oPointsToProcess)
                    For Each oPoint As cPoint In oPointsToProcess
                        Dim sTmpDelta As Single = modPaint.DistancePointToSegment(oPoint.Point, oFirstPoint.Point, oLastPoint.Point)
                        If sTmpDelta > sMaxDelta Then
                            sMaxDelta = sTmpDelta
                            oMaxPoint = oPoint
                        End If
                    Next
                    If sMaxDelta > Delta Then
                        If Not MarkedPoints.Contains(oMaxPoint) Then
                            Call MarkedPoints.Add(oMaxPoint)
                            bDone = False
                        End If
                    End If
                    oPreviousMarkedPoint = oLastPoint
                Loop Until oPreviousMarkedPoint Is Points.Last
                If Not MarkedPoints.Contains(oPreviousMarkedPoint) Then MarkedPoints.Add(oPreviousMarkedPoint)
            Loop Until bDone
        Else
            'per le bezier la procedura dovrà essere diversa...per ora viene disattivata...
            For Each oPoint As cPoint In Points
                Call MarkedPoints.Add(oPoint)
            Next
        End If
    End Sub

    Public Sub SizeToGrid(ByRef Size As Size, GridSnap As Single)
        Size.Width = MathRound(Size.Width / GridSnap, 0) * GridSnap
        Size.Height = MathRound(Size.Height / GridSnap, 0) * GridSnap
    End Sub

    Public Sub SizeToGrid(ByRef Size As SizeD, GridSnap As Single)
        Size.Width = MathRound(Size.Width / GridSnap, 0) * GridSnap
        Size.Height = MathRound(Size.Height / GridSnap, 0) * GridSnap
    End Sub

    Public Sub SizeToGrid(ByRef Size As SizeF, GridSnap As Single)
        Size.Width = MathRound(Size.Width / GridSnap, 0) * GridSnap
        Size.Height = MathRound(Size.Height / GridSnap, 0) * GridSnap
    End Sub

    Public Sub PointToGrid(ByRef Point As Point, GridSnap As Single)
        Point.X = MathRound(Point.X / GridSnap, 0) * GridSnap
        Point.Y = MathRound(Point.Y / GridSnap, 0) * GridSnap
    End Sub

    Public Sub PointToGrid(ByRef Point As PointD, GridSnap As Single)
        Point.X = MathRound(Point.X / GridSnap, 0) * GridSnap
        Point.Y = MathRound(Point.Y / GridSnap, 0) * GridSnap
    End Sub

    Public Sub PointToGrid(ByRef Point As PointF, GridSnap As Single)
        Point.X = MathRound(Point.X / GridSnap, 0) * GridSnap
        Point.Y = MathRound(Point.Y / GridSnap, 0) * GridSnap
    End Sub

    Public Sub PointSnap(ByRef Point As PointF, Tools As cEditDesignTools, SnapToPoint As Integer, ByRef LastItemPoint As cPoint, ByVal Zoom As Single, ByVal Translation As PointF)
        If Tools.IsLastPoint Then
            Point = Tools.LastItemPoint.Point
            If SnapToPoint > 1 Then
                LastItemPoint = Tools.LastItemPoint
            End If
        End If
    End Sub

    Public Function GetBitmapData(ByVal Bitmap As Bitmap) As Byte()
        Dim bounds As Rectangle = New Rectangle(0, 0, Bitmap.Width, Bitmap.Height)
        Dim oBitmapData As Drawing.Imaging.BitmapData = Bitmap.LockBits(bounds, Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
        Dim iSize As Integer = oBitmapData.Stride * oBitmapData.Height
        Dim oValues(iSize) As Byte
        Call System.Runtime.InteropServices.Marshal.Copy(oBitmapData.Scan0, oValues, 0, iSize)
        Call Bitmap.UnlockBits(oBitmapData)
        Return oValues
    End Function

    Public Function GetSurfaceElevation(Survey As cSurvey.cSurvey, Trigpoint As cTrigPoint) As Single?
        If Survey.Properties.SurfaceProfileElevation Is Nothing Then
            Return Nothing
        Else
            With Survey.Properties.SurfaceProfileElevation
                Dim sElevation As Single = .GetElevation(Trigpoint)
                If sElevation = .NoDataValue Then
                    Return Nothing
                Else
                    Return sElevation
                End If
            End With
        End If
    End Function

    Public Function GetSurfaceDistance(Survey As cSurvey.cSurvey, Trigpoint As cTrigPoint) As Single?
        If Survey.Properties.SurfaceProfileElevation Is Nothing Then
            Return Nothing
        Else
            With Survey.Properties.SurfaceProfileElevation
                Dim sElevation As Single = .GetElevation(Trigpoint)
                If sElevation = .NoDataValue Then
                    Return Nothing
                Else
                    Return sElevation - Survey.Calculate.TrigPoints(Trigpoint).Coordinate.Altitude
                End If
            End With
        End If
    End Function

    Public Function GetColorInRainbow(Value As Single, Min As Single, Max As Single, Rainbow As List(Of Color), DefaultColor As Color) As Color
        If Min = Max Then
            Return DefaultColor
        Else
            Dim iCount As Integer = Rainbow.Count
            Dim iIndex As Integer = ((Value - Min) / (Max - Min)) * iCount
            If iIndex >= 0 And iIndex < iCount Then
                Return Rainbow(iIndex)
            Else
                Return DefaultColor
            End If
        End If
    End Function

    Public Function GetRainbowColors(Count As Integer) As List(Of Color)
        Dim oRainbow As New List(Of Color)(Count)
        Dim p As Double = 360.0 / Convert.ToDouble(Count)
        For n As Integer = 0 To Count - 1
            Call oRainbow.Add(HsvToRgb(n * p, 1.0, 1.0))
        Next
        Return oRainbow
    End Function

    Public Function Rgb(r As Double, g As Double, b As Double) As Color
        Return Color.FromArgb(255, Convert.ToByte(r * 255.0), Convert.ToByte(g * 255.0), Convert.ToByte(b * 255.0))
    End Function

    Public Function HsvToRgb(h As Double, s As Double, v As Double) As Color
        Dim hi As Integer = Convert.ToInt32(Math.Floor(h / 60.0)) Mod 6
        Dim f As Double = (h / 60.0) - Math.Floor(h / 60.0)

        Dim p As Double = v * (1.0 - s)
        Dim q As Double = v * (1.0 - (f * s))
        Dim t As Double = v * (1.0 - ((1.0 - f) * s))

        Dim oColor As Color
        Select Case hi
            Case 0
                oColor = Rgb(v, t, p)
                Exit Select
            Case 1
                oColor = Rgb(q, v, p)
                Exit Select
            Case 2
                oColor = Rgb(p, v, t)
                Exit Select
            Case 3
                oColor = Rgb(p, q, v)
                Exit Select
            Case 4
                oColor = Rgb(t, p, v)
                Exit Select
            Case 5
                oColor = Rgb(v, p, q)
                Exit Select
            Case Else
                oColor = Color.FromArgb(&HFF, &H0, &H0, &H0)
                Exit Select
        End Select
        Return oColor
    End Function

    Public Function SequenceToPath(Sequence As cSequence, DefaultLineType As cIItemLine.LineTypeEnum, ByRef Path As GraphicsPath) As Boolean
        Dim oSequencePoints() As PointF = Sequence.GetPoints
        If oSequencePoints.Length > 1 Then
            If IsNothing(Path) Then Path = New GraphicsPath
            Select Case Sequence.GetLineType(DefaultLineType)
                'Case cIItemLine.LineTypeEnum.ClosedBeziers
                '    Call modPaint.PointsToBeziers(oSequencePoints, Path)
                '    Call Path.CloseFigure()
                Case cIItemLine.LineTypeEnum.Beziers
                    Call modPaint.PointsToBeziers(oSequencePoints, Path)
                'Case cIItemLine.LineTypeEnum.ClosedSplines
                '    Call Path.AddClosedCurve(oSequencePoints, sDefaultSplineTension)
                Case cIItemLine.LineTypeEnum.Splines
                    Call Path.AddCurve(oSequencePoints, sDefaultSplineTension)
                    'Case cIItemLine.LineTypeEnum.closedLines
                    '    Call Path.AddLines(oSequencePoints)
                    '    Call Path.CloseFigure()
                Case Else
                    Call Path.AddLines(oSequencePoints)
            End Select
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ComparePoint(Point1 As PointD, point2 As PointD, Optional [Decimal] As Integer = 2) As Boolean
        Return Math.Round(Point1.X, [Decimal]) = Math.Round(point2.X, [Decimal]) AndAlso Math.Round(Point1.Y, [Decimal]) = Math.Round(point2.Y, [Decimal])
    End Function

    Public Function ComparePoint(Point1 As PointF, point2 As PointF, Optional [Decimal] As Integer = 2) As Boolean
        Return Math.Round(Point1.X, [Decimal]) = Math.Round(point2.X, [Decimal]) AndAlso Math.Round(Point1.Y, [Decimal]) = Math.Round(point2.Y, [Decimal])
    End Function

    Public Function WidenSequence(Item As cItem, Point As cPoint, Width As Single, Optional ReductionDelta As Single = -1) As cSequence
        Dim oPoints As cPoints = Item.Points
        If oPoints.Count > 0 Then
            Dim oSequence As cSequence = oPoints.GetSequence(Point)
            Dim iLineType As cIItemLine.LineTypeEnum = oSequence.GetLineType(DirectCast(Item, cIItemLine).LineType)
            Dim oSurvey As cSurvey.cSurvey = oPoints(0).Survey
            Dim oNewSequence As cSequence = New cSequence()
            Dim oPath As GraphicsPath
            If modPaint.SequenceToPath(oSequence, iLineType, oPath) Then
                Using oPen As Pen = New Pen(Brushes.Black, Width / 2)
                    Call oPath.Widen(oPen, Nothing, ReductionDelta)
                    For Each oPoint As PointF In oPath.PathPoints
                        Call oNewSequence.Append(New cPoint(oSurvey, oPoint))
                    Next
                End Using
            End If
            If ReductionDelta > 0 Then ReducePoints(oNewSequence, ReductionDelta, iLineType)
            Return oNewSequence
        Else
            Return Nothing
        End If
    End Function

    Public Sub PathAddCircleFromPoint(Path As GraphicsPath, Point As PointF, Radius As Single)
        Call Path.StartFigure()
        Call Path.AddEllipse(Point.X - Radius, Point.Y - Radius, Radius * 2, Radius * 2)
    End Sub

    Public Sub PathAddSquareFromPoint(Path As GraphicsPath, Point As PointF, Size As Single)
        Call Path.StartFigure()
        Call Path.AddPolygon({New PointF(Point.X - Size, Point.Y - Size), New PointF(Point.X + Size, Point.Y - Size), New PointF(Point.X + Size, Point.Y + Size), New PointF(Point.X - Size, Point.Y + Size)})
        Call Path.CloseFigure()
    End Sub

    Public Sub PathAddCrossFromPoint(Path As GraphicsPath, Point As PointF, Size As Single)
        Call Path.StartFigure()
        Call Path.AddLine(Point, New PointF(Point.X - Size, Point.Y))
        Call Path.AddLine(Point, New PointF(Point.X + Size, Point.Y))
        Call Path.AddLine(Point, New PointF(Point.X, Point.Y - Size))
        Call Path.AddLine(Point, New PointF(Point.X, Point.Y + Size))
    End Sub

    Public Function GetImageEncoder(ByVal Format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        Dim codec As ImageCodecInfo
        For Each codec In codecs
            If codec.FormatID = Format.Guid Then
                Return codec
            End If
        Next codec
        Return Nothing
    End Function
End Module