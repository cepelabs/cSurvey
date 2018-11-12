Imports System.Windows.Media.Media3D
Imports System.Xml
Imports cSurveyPC.cSurvey.Design3D

Namespace cSurvey.Design.Design3D
    Public Class cPoint3D
        Implements cIPoint
        Private oSurvey As cSurvey

        Private oItem As cItem3D
        Private oPoint As Point3D

        Friend Event OnChanged(ByVal Sender As cPoint3D)
        Friend Event OnGetItem(ByVal Sender As cPoint3D, ByRef Item As cItem3D)

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPoint As XmlElement = Document.CreateElement("point3d")
            Call oXmlPoint.SetAttribute("x", Point.X)
            Call oXmlPoint.SetAttribute("y", Point.Y)
            Call oXmlPoint.SetAttribute("z", Point.Z)
            Call Parent.AppendChild(oXmlPoint)
            Return oXmlPoint
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As XmlElement)
            oSurvey = Survey
            oPoint = New Point3D(Point.GetAttribute("x"), Point.GetAttribute("y"), Point.GetAttribute("z"))
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Point As Point3D)
            oSurvey = Survey
            oPoint = Point
        End Sub

        Public ReadOnly Property Point As Point3D
            Get
                Return oPoint
            End Get
        End Property

        Public ReadOnly Property Item As cIItem Implements cIPoint.Item
            Get
                If oItem Is Nothing Then
                    RaiseEvent OnGetItem(Me, oItem)
                End If
                Return oItem
            End Get
        End Property

        Public ReadOnly Property X() As Single
            Get
                Return oPoint.X
            End Get
        End Property

        Public ReadOnly Property Y() As Single
            Get
                Return oPoint.Y
            End Get
        End Property

        Public ReadOnly Property Z() As Single
            Get
                Return oPoint.Z
            End Get
        End Property

        Public ReadOnly Property Survey As cSurvey Implements cIPoint.Survey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Type As cIPoint.PointTypeEnum Implements cIPoint.Type
            Get
                Return itype
            End Get
        End Property
    End Class
End Namespace
