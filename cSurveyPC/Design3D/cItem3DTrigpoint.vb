Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Calculate
Imports cSurveyPC.cSurvey.Calculate.Plot
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Design3D.Items
    Public Class cItem3DTrigpoint
        Inherits cItem3D
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

        Public Sub New(Survey As cSurvey, Design As cDesign3D, Trigpoint As cTrigPoint)
            Call MyBase.New(Survey, Design, Design.Layers(cILayer.LayerTypeEnum.Base), cIItem.cItemTypeEnum.Trigpoint, cIItem.cItemCategoryEnum.None)
            oTrigPoint = Trigpoint
        End Sub

    End Class
End Namespace