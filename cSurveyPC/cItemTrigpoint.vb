Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Calculate
Imports cSurveyPC.cSurvey.Calculate.Plot

Namespace cSurvey.Design.Items
    Public Class cItemTrigpoint
        Inherits cItem
        Implements cIItemTrigpoint

        Private oTrigPoint As cTrigPoint

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

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return False
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

        Public Overrides ReadOnly Property Cave As String
            Get
                Return ""
            End Get
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property Branch As String
            Get
                Return ""
            End Get
        End Property

        Public Property Trigpoint As cTrigPoint Implements cIItemTrigpoint.Trigpoint
            Get
                Return oTrigPoint
            End Get
            Set(value As cTrigPoint)
                If Not oTrigPoint Is value Then
                    oTrigPoint = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
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
                Return False
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

        Friend Overrides Sub Paint(Graphics As System.Drawing.Graphics, PaintOptions As cOptions, Options As cItem.PaintOptionsEnum, Selected As SelectionModeEnum)

        End Sub

        Friend Overrides Sub Render(Graphics As System.Drawing.Graphics, PaintOptions As cOptions, Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)

        End Sub

        Friend Overrides Function ToSvg(PaintOptions As cOptions, Options As cItem.SVGOptionsEnum) As System.Xml.XmlDocument
            Return Nothing
        End Function

        Friend Overrides Function ToSvgItem(SVG As System.Xml.XmlDocument, PaintOptions As cOptions, Options As cItem.SVGOptionsEnum) As System.Xml.XmlElement
            Return Nothing
        End Function

        Public Overrides Function GetBounds() As RectangleF
            If oTrigPoint Is Nothing Then
                Return New RectangleF
            Else
                'ATTENZIONE! per ora questo codice va bene perché non considero la traslazioni...
                'in design csurvey non supporta transazione quindi ok...se si vuol far andare questo codice anche non in design
                'è necessario gestire le traslazioni in modo opportuno in fase di calcolo e non in fase di disegno...
                Dim oSegments As cSegmentCollection = oTrigPoint.GetSegments.GetSurveySegments
                If oSegments.Count > 0 Then
                    If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                        Dim oData As cPlanProjectedData = oSegments(0).Data.Plan
                        Dim oRect As RectangleF
                        If oData.From = oTrigPoint.Name Then
                            oRect = modPaint.GetRectanglefFomPoint(oData.FromPoint, 1)
                        Else
                            oRect = modPaint.GetRectanglefFomPoint(oData.ToPoint, 1)
                        End If
                        Return oRect
                    Else
                        Dim oData As cProfileProjectedData = oSegments(0).Data.Profile
                        Dim oRect As RectangleF
                        If oData.From = oTrigPoint.Name Then
                            oRect = modPaint.GetRectanglefFomPoint(oData.FromPoint, 1)
                        Else
                            oRect = modPaint.GetRectanglefFomPoint(oData.ToPoint, 1)
                        End If
                        Return oRect
                    End If
                Else
                    Return New RectangleF
                End If
            End If
        End Function

        Public Sub New(Survey As cSurvey, Design As cDesign, Trigpoint As cTrigPoint)
            Call MyBase.New(Survey, Design, Design.Layers(cLayers.LayerTypeEnum.Base), cIItem.cItemTypeEnum.trigpoint, cIItem.cItemCategoryEnum.None)
            oTrigPoint = Trigpoint
        End Sub

    End Class
End Namespace