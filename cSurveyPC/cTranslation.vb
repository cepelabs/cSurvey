Imports System.Drawing.Drawing2D
Imports System.Xml

Namespace cSurvey
    Public Class cTranslationBase
        Private sX As Decimal
        Private sY As Decimal

        Public Shared Widening Operator CType(ByVal p As PointD) As cTranslationBase
            Return New cTranslationBase(p.X, p.Y)
        End Operator

        Public Shared Widening Operator CType(ByVal p As PointF) As cTranslationBase
            Return New cTranslationBase(p.X, p.Y)
        End Operator

        Public Shared Widening Operator CType(ByVal p As Point) As cTranslationBase
            Return New cTranslationBase(p.X, p.Y)
        End Operator

        Public Shared Widening Operator CType(ByVal p As cTranslationBase) As System.Drawing.PointF
            Return New PointF(p.X, p.Y)
        End Operator

        Public Shared Widening Operator CType(ByVal p As cTranslationBase) As PointD
            Return New PointD(p.X, p.Y)
        End Operator

        Public Shared Widening Operator CType(ByVal p As cTranslationBase) As System.Drawing.Point
            Return New Point(p.X, p.Y)
        End Operator

        Public Function GetPoint() As PointD
            Return New PointD(sX, sY)
        End Function

        Public Function GetSize() As SizeD
            Return New SizeD(sX, sY)
        End Function

        Public Property X() As Decimal
            Get
                Return sX
            End Get
            Set(ByVal Value As Decimal)
                If sX <> Value Then
                    sX = Value
                End If
            End Set
        End Property

        Public Property Y() As Decimal
            Get
                Return sY
            End Get
            Set(ByVal Value As Decimal)
                If sY <> Value Then
                    sY = Value
                End If
            End Set
        End Property

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return (sX = 0) AndAlso (sY = 0)
            End Get
        End Property

        Public Function ApplyToPoint(ByVal Point As PointF) As PointF
            If IsEmpty Then
                Return Point
            Else
                Return New PointF(Point.X + sX, Point.Y + sY)
            End If
        End Function

        Friend Sub New(ByVal Translation As cTranslationBase)
            sX = Translation.sX
            sY = Translation.sY
        End Sub

        Friend Sub New(ByVal X As Decimal, ByVal Y As Decimal)
            sX = X
            sY = Y
        End Sub

        Friend Sub New(ByVal Translation As XmlElement)
            sX = Translation.GetAttribute("x")
            sY = Translation.GetAttribute("y")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Name As String) As XmlElement
            Dim oXmlTranslation As XmlElement = Document.CreateElement(Name)
            Call oXmlTranslation.SetAttribute("x", sX)
            Call oXmlTranslation.SetAttribute("y", sY)
            Call Parent.AppendChild(oXmlTranslation)
            Return oXmlTranslation
        End Function
    End Class

    Public Class cTranslation
        Inherits cTranslationBase

        Private iApplyTo As cTranslationApplyToEnum

        Private sX As Decimal
        Private sY As Decimal

        Public Enum cTranslationApplyToEnum
            Plan = 0
            Profile = 1
        End Enum

        Friend Sub New(ByVal Translation As cTranslation)
            Call MyBase.New(Translation)
            iApplyTo = Translation.iApplyTo
        End Sub

        Friend Sub New(ByVal ApplyTo As cTranslationApplyToEnum, ByVal X As Decimal, ByVal Y As Decimal)
            Call MyBase.New(X, Y)
            iApplyTo = ApplyTo
        End Sub

        Public ReadOnly Property ApplyTo() As cTranslationApplyToEnum
            Get
                Return iApplyTo
            End Get
        End Property

        Friend Sub New(ByVal Translation As XmlElement)
            Call MyBase.New(Translation)
            Select Case Translation.Name
                Case "plan"
                    iApplyTo = cTranslationApplyToEnum.Plan
                Case "profile"
                    iApplyTo = cTranslationApplyToEnum.Profile
            End Select
        End Sub

        Friend Overridable Shadows Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim sName As String = ""
            Select Case iApplyTo
                Case cTranslationApplyToEnum.Plan
                    sName = "plan"
                Case cTranslationApplyToEnum.Profile
                    sName = "profile"
            End Select
            Return MyBase.SaveTo(File, Document, Parent, sName)
        End Function
    End Class
End Namespace