Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Design3D.Items
    Public Class cItem3DSegment
        Inherits cItem3D
        Implements cIItemSegment

        Private oSegment As cSegment

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

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Sub SetCave(Cave As String, Optional Branch As String = "", Optional BindSegment As Boolean = True)
            'Call oSegment.SetCave(Cave, Branch, BindSegment)
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
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeBinded As Boolean
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

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 0
            End Get
        End Property

        Public Sub New(Survey As cSurvey, Design As cDesign3D, Segment As cSegment)
            Call MyBase.New(Survey, Design, Design.Layers(cILayer.LayerTypeEnum.Base), cIItem.cItemTypeEnum.Segment, cIItem.cItemCategoryEnum.None)
            oSegment = Segment
        End Sub
    End Class
End Namespace