Imports cSurveyPC.cSurvey.Helper.Editor

Namespace cSurvey.Design.Items
    Public Class cItemMarker
        Inherits cItem

        Private oMarkedPoint As cMarkedDesktopPoint

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeLocked As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property MarkedPoint As cMarkedDesktopPoint
            Get
                Return oMarkedPoint
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Sub SetCave(Cave As String, Optional Branch As String = "", Optional BindSegment As Boolean = True)
            'do nothing
        End Sub

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.None
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(Item As cItemGeneric, Optional Clear As Boolean = False) As Boolean

        End Function

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 0
            End Get
        End Property

        Public Overrides Sub MoveBy(OffsetX As Single, OffsetY As Single)
            Call MyBase.MoveBy(OffsetX, OffsetY)
            Call oMarkedPoint.Move(MyBase.Points(0).Point)
        End Sub

        Public Overrides Sub MoveTo(X As Single, Y As Single)
            Call MyBase.MoveTo(X, Y)
            Call oMarkedPoint.Move(MyBase.Points(0).Point)
        End Sub

        Public Overrides Sub MoveBy(Size As SizeF)
            Call MyBase.MoveBy(Size)
            Call oMarkedPoint.Move(MyBase.Points(0).Point)
        End Sub

        Public Overrides Sub MoveTo(Point As PointF)
            Call MyBase.MoveTo(Point)
            Call oMarkedPoint.Move(MyBase.Points(0).Point)
        End Sub

        Friend Overrides Sub Paint(Graphics As System.Drawing.Graphics, PaintOptions As cOptionsCenterline, Options As cItem.PaintOptionsEnum, Selected As SelectionModeEnum)

        End Sub

        Friend Overrides Sub Render(Graphics As System.Drawing.Graphics, PaintOptions As cOptionsCenterline, Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)

        End Sub

        Friend Overrides Function ToSvg(PaintOptions As cOptionsCenterline, Options As cItem.SVGOptionsEnum) As System.Xml.XmlDocument
            Return Nothing
        End Function

        Friend Overrides Function ToSvgItem(SVG As System.Xml.XmlDocument, PaintOptions As cOptionsCenterline, Options As cItem.SVGOptionsEnum) As System.Xml.XmlElement
            Return Nothing
        End Function

        Public Overrides Function GetBounds() As RectangleF
            Dim oPoint As PointF = MyBase.Points(0).Point
            Dim sScale As Single
            Call oMarkedPoint.GetPaintInfo(sScale)
            Dim sSize As Single = 10 / sScale
            Return New RectangleF(oPoint.X - sSize / 2, oPoint.Y - sSize / 2, sSize, sSize)
        End Function

        Public Sub New(Survey As cSurvey, Design As cDesign, MarkedPoint As cMarkedDesktopPoint)
            Call MyBase.New(Survey, Design, Design.Layers(cLayers.LayerTypeEnum.Base), cIItem.cItemTypeEnum.Marker, cIItem.cItemCategoryEnum.None)
            oMarkedPoint = MarkedPoint
            Call MyBase.Points.Add(New cPoint(Survey, MarkedPoint.Point))
        End Sub
    End Class
End Namespace
