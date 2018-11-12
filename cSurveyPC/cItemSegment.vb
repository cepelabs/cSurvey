Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design.Items
    Public Class cItemSegment
        Inherits cItem
        Implements cIItemPlanSplayBorder
        Implements cIItemProfileSplayBorder
        Implements cIItemSegment

        Private oSegment As cSegment

        Public Overrides Property DesignAffinity As DesignAffinityEnum
            Get
                Return DesignAffinityEnum.Design
            End Get
            Set(ByVal value As DesignAffinityEnum)
                'readonly....
            End Set
        End Property

        Public Overrides Property HiddenInDesign As Boolean
            Get
                Return oSegment.HiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                oSegment.HiddenInDesign = value
            End Set
        End Property

        Public Overrides Property HiddenInPreview As Boolean
            Get
                Return oSegment.HiddenInPreview
            End Get
            Set(ByVal value As Boolean)
                oSegment.HiddenInPreview = value
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
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
            'do nothing...
        End Sub

        Public Overrides ReadOnly Property Cave As String
            Get
                Return oSegment.Cave
            End Get
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property Branch As String
            Get
                Return oSegment.Branch
            End Get
        End Property

        Public Property Segment As cSegment Implements cIItemSegment.Segment
            Get
                Return oSegment
            End Get
            Set(value As cSegment)
                If Not oSegment Is value Then
                    oSegment = value
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
                Return Not oSegment.Splay
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
            If oSegment Is Nothing Then
                Return New RectangleF
            Else
                If oSegment.Calibration Then
                    Return New RectangleF
                Else
                    If MyBase.Design.Type = cIDesign.cDesignTypeEnum.Plan Then
                        Dim oPoints() As PointF = oSegment.Data.Plan.GetVectorLine
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddLine(oPoints(0), oPoints(1))
                            Dim oRect As RectangleF = oPath.GetBounds
                            Return oRect
                        End Using
                    Else
                        Dim oPoints() As PointF = oSegment.Data.Profile.GetVectorLine
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddLine(oPoints(0), oPoints(1))
                            Dim oRect As RectangleF = oPath.GetBounds
                            Return oRect
                        End Using
                    End If
                End If
            End If
        End Function

        Public Sub New(Survey As cSurvey, Design As cDesign, Segment As cSegment)
            Call MyBase.New(Survey, Design, Design.Layers(cLayers.LayerTypeEnum.Base), cIItem.cItemTypeEnum.Segment, cIItem.cItemCategoryEnum.None)
            oSegment = Segment
        End Sub

        Public Property ProfileSplayBorderMaxAngleVariation As Single Implements cIItemProfileSplayBorder.SplayBorderMaxAngleVariation
            Get
                Return oSegment.ProfileSplayBorderMaxAngleVariation
            End Get
            Set(value As Single)
                If oSegment.ProfileSplayBorderMaxAngleVariation <> value Then
                    oSegment.ProfileSplayBorderMaxAngleVariation = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ProfileSplayBorderProjectionAngle As Integer Implements cIItemProfileSplayBorder.SplayBorderProjectionAngle
            Get
                Return oSegment.ProfileSplayBorderProjectionAngle
            End Get
            Set(value As Integer)
                If oSegment.ProfileSplayBorderProjectionAngle <> value Then
                    oSegment.ProfileSplayBorderProjectionAngle = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property PlanSplayBorderInclinationRange As SizeF Implements cIItemPlanSplayBorder.SplayBorderInclinationRange
            Get
                Return oSegment.PlanSplayBorderInclinationRange
            End Get
            Set(value As SizeF)
                If oSegment.PlanSplayBorderInclinationRange <> value Then
                    oSegment.PlanSplayBorderInclinationRange = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property PlanSplayBorderProjectionDeltaZ As Single Implements cIItemPlanSplayBorder.SplayBorderProjectionDeltaZ
            Get
                Return oSegment.PlanSplayBorderProjectionDeltaZ
            End Get
            Set(value As Single)
                If oSegment.PlanSplayBorderProjectionDeltaZ <> value Then
                    oSegment.PlanSplayBorderProjectionDeltaZ = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ProfileSplayBorderNegInclinationRange As SizeF Implements cIItemProfileSplayBorder.SplayBorderNegInclinationRange
            Get
                Return oSegment.ProfileSplayBorderNegInclinationRange
            End Get
            Set(value As SizeF)
                If oSegment.ProfileSplayBorderNegInclinationRange <> value Then
                    oSegment.ProfileSplayBorderNegInclinationRange = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property ProfileSplayBorderPosInclinationRange As SizeF Implements cIItemProfileSplayBorder.SplayBorderPosInclinationRange
            Get
                Return oSegment.ProfileSplayBorderPosInclinationRange
            End Get
            Set(value As SizeF)
                If oSegment.ProfileSplayBorderPosInclinationRange <> value Then
                    oSegment.ProfileSplayBorderPosInclinationRange = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property PlanSplayBorderMaxDeltaVariation As Single Implements cIItemPlanSplayBorder.SplayBorderMaxDeltaVariation
            Get
                Return oSegment.PlanSplayBorderMaxDeltaVariation
            End Get
            Set(value As Single)
                If oSegment.PlanSplayBorderMaxDeltaVariation <> value Then
                    oSegment.PlanSplayBorderMaxDeltaVariation = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Property PlanSplayBorderProjectionType As cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum Implements cIItemPlanSplayBorder.SplayBorderProjectionType
            Get
                Return oSegment.PlanSplayBorderProjectionType
            End Get
            Set(value As cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum)
                If oSegment.PlanSplayBorderProjectionType <> value Then
                    oSegment.PlanSplayBorderProjectionType = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property
    End Class
End Namespace