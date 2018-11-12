Imports System.Drawing.Drawing2D
Imports System.Xml

Namespace cSurvey
    Public Class cTranslation
        'Public Enum cTranslationPriorityEnum
        '    XY = 2
        '    YX = 1
        '    [Default] = 0
        'End Enum

        Private iApplyTo As cTranslationApplyToEnum
        Private sX As Decimal
        Private sY As Decimal
        'Private iPriority As cTranslationPriorityEnum
        'Private sBreakPercentage As Single

        Public Enum cTranslationApplyToEnum
            Plan = 0
            Profile = 1
        End Enum

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
                sX = Value
            End Set
        End Property

        Public Property Y() As Decimal
            Get
                Return sY
            End Get
            Set(ByVal Value As Decimal)
                sY = Value
            End Set
        End Property

        'Public Property Priority As cTranslationPriorityEnum
        '    Get
        '        Return iPriority
        '    End Get
        '    Set(value As cTranslationPriorityEnum)
        '        iPriority = value
        '    End Set
        'End Property

        'Public Property BreakPercentage As Single
        '    Get
        '        Return sBreakPercentage
        '    End Get
        '    Set(value As Single)
        '        sBreakPercentage = value
        '    End Set
        'End Property

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return (sX = 0) And (sY = 0)
            End Get
        End Property

        Public Function ApplyToPoint(ByVal Point As PointF) As PointF
            If IsEmpty Then
                Return Point
            Else
                Return New PointF(Point.X + sX, Point.Y + sY)
            End If
        End Function

        'Public Function GetPath(Point As PointF) As GraphicsPath
        '    Dim oPath As GraphicsPath = New GraphicsPath
        '    If iPriority = cTranslationPriorityEnum.YX Or iPriority = cTranslationPriorityEnum.Default Then
        '        If sBreakPercentage = 0 Then
        '            Dim oPoints() As PointF = {Point, New PointF(Point.X, Point.Y + sY), New PointF(Point.X + sX, Point.Y + sY)}
        '            Call oPath.AddLines(oPoints)
        '        Else
        '            Dim sDeltaY As Single = sY * (1 - sBreakPercentage)
        '            Dim oPoints() As PointF = {Point, New PointF(Point.X, Point.Y + sDeltaY), New PointF(Point.X + sX, Point.Y + sDeltaY), New PointF(Point.X + sX, Point.Y + sY)}
        '            Call oPath.AddLines(oPoints)
        '        End If
        '    Else
        '        If sBreakPercentage = 0 Then
        '            Dim oPoints() As PointF = {Point, New PointF(Point.X + sX, Point.Y), New PointF(Point.X + sX, Point.Y + sY)}
        '            Call oPath.AddLines(oPoints)
        '        Else
        '            Dim sDeltaX As Single = sX * (1 - sBreakPercentage)
        '            Dim oPoints() As PointF = {Point, New PointF(Point.X + sDeltaX, Point.Y), New PointF(Point.X + sDeltaX, Point.Y), New PointF(Point.X + sX, Point.Y + sY)}
        '            Call oPath.AddLines(oPoints)
        '        End If
        '    End If
        '    Return oPath
        'End Function

        'Public Shared Function Add(T1 As cTranslation, T2 As cTranslation) As cTranslation
        '    Return New cTranslation(T2.ApplyTo, T2.X + T1.X, T2.Y + T1.Y, IIf(T2.Priority = cTranslationPriorityEnum.Default, T1.Priority, T2.Priority), IIf(T2.BreakPercentage = 0, T1.BreakPercentage, T2.BreakPercentage))
        'End Function

        Friend Sub New(ByVal Translation As cTranslation)
            iApplyTo = Translation.iApplyTo
            sX = Translation.sX
            sY = Translation.sY
            'iPriority = Translation.iPriority
            'sBreakPercentage = Translation.sBreakPercentage
        End Sub

        Friend Sub New(ByVal ApplyTo As cTranslationApplyToEnum, ByVal X As Decimal, ByVal Y As Decimal) ', Optional Priority As cTranslationPriorityEnum = cTranslationPriorityEnum.Default, Optional BreakPercentage As Single = 0)
            iApplyTo = ApplyTo
            sX = X
            sY = Y
            'iPriority = Priority
            'sBreakPercentage = BreakPercentage
        End Sub

        Public ReadOnly Property ApplyTo() As cTranslationApplyToEnum
            Get
                Return iApplyTo
            End Get
        End Property

        Friend Sub New(ByVal Translation As XmlElement)
            Select Case Translation.Name
                Case "plan"
                    iApplyTo = cTranslationApplyToEnum.Plan
                Case "profile"
                    iApplyTo = cTranslationApplyToEnum.Profile
            End Select
            sX = Translation.GetAttribute("x")
            sY = Translation.GetAttribute("y")

            'iPriority = modNumbers.StringToInteger(modXML.GetAttributeValue(Translation, "p", 0))
            'sBreakPercentage = modNumbers.StringToSingle(modXML.GetAttributeValue(Translation, "bp", 0))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim sName As String = ""
            Select Case iApplyTo
                Case cTranslationApplyToEnum.Plan
                    sName = "plan"
                Case cTranslationApplyToEnum.Profile
                    sName = "profile"
            End Select
            Dim oXmlTranslation As XmlElement = Document.CreateElement(sName)
            Call oXmlTranslation.SetAttribute("x", sX)
            Call oXmlTranslation.SetAttribute("y", sY)

            'If iPriority <> 0 Then Call oXmlTranslation.SetAttribute("p", iPriority.ToString("D"))
            'If sBreakPercentage <> 0 Then Call oXmlTranslation.SetAttribute("bp", modNumbers.NumberToString(sBreakPercentage, "0.00"))

            Call Parent.AppendChild(oXmlTranslation)
            Return oXmlTranslation
        End Function
    End Class
End Namespace