Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cMinMaxs
        Private oSurvey As cSurvey

        Private oProperty As System.Reflection.PropertyInfo
        Private sMin As Single?
        Private sMax As Single?

        Private oItems As cTrigPoints
        Private oColors As List(Of Color)

        Public Sub Clear()
            sMin = Nothing
            sMax = Nothing
        End Sub

        Friend Sub New(Survey As cSurvey, [Property] As System.Reflection.PropertyInfo, Items As cTrigPoints)
            osurvey = Survey
            oProperty = [Property]
            sMin = Nothing
            sMax = Nothing
            oItems = Items
        End Sub

        Public Function getColorScale() As List(Of Color)
            If oColors Is Nothing Then
                oColors = modPaint.GetRainbowColors(50)
            End If
            Return oColors
        End Function

        Public Function GetScaleColor(Value As Single) As Color
            Return modPaint.GetColorInRainbow(Value, GetMin, GetMax, getColorScale, Color.Black)
        End Function

        Public Function GetMax() As Single
            If Not sMax.HasValue Then
                sMax = Single.MinValue
                For Each oItem As cTrigPoint In oItems
                    Dim sValue As Single = oProperty.GetValue(oItem.Point, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                    If sValue > sMax Then sMax = sValue
                Next
            End If
            Return sMax.Value
        End Function

        Public Function GetMin() As Single
            If Not sMin.HasValue Then
                sMin = Single.MaxValue
                For Each oItem As cTrigPoint In oItems
                    Dim sValue As Single = oProperty.GetValue(oItem.Point, Reflection.BindingFlags.GetProperty, Nothing, Nothing, Nothing)
                    If sValue < sMin Then sMin = sValue
                Next
                Return sMin
            End If
            Return sMin.Value
        End Function
    End Class

    Public Class cTrigPoints
        Implements IEnumerable
        Implements IEnumerable(Of cTrigPoint)

        Private oSurvey As cSurvey

        Private oItems As Dictionary(Of String, cTrigPoint)

        Private oZs As cMinMaxs

        Friend Sub New(Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cTrigPoint) '(StringComparer.OrdinalIgnoreCase)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cTrigPoint = New cTrigPoint(oXMLItem)
                Call oItems.Add(oItem.Name, oItem)
            Next
            'Dim oColors As List(Of Color) = modPaint.GetRainbowColors(100)
            oZs = New cMinMaxs(oSurvey, GetType(cTrigPointPoint).GetProperty("Z"), Me)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigpoints As XmlElement = Document.CreateElement("ts")
            For Each oItem As cTrigPoint In oItems.Values
                Call oItem.SaveTo(File, Document, oXmlTrigpoints)
            Next
            Call Parent.AppendChild(oXmlTrigpoints)
            Return oXmlTrigpoints
        End Function

        Public ReadOnly Property Zs As cMinMaxs
            Get
                Return oZs
            End Get
        End Property

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cTrigPoint)
            'Dim oColors As List(Of Color) = modPaint.GetRainbowColors(100)
            oZs = New cMinMaxs(oSurvey, GetType(cTrigPointPoint).GetProperty("Z"), Me)
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Sub Clear()
            Call oItems.Clear()
            Call oZs.Clear()
        End Sub

        Friend Function Append(ByVal Name As String) As cTrigPoint
            If oItems.ContainsKey(Name) Then
                Return oItems(Name)
            Else
                Dim oItem As cTrigPoint = New cTrigPoint(Name)
                Call oItems.Add(Name, oItem)
                Return oItem
            End If
        End Function

        Default Public ReadOnly Property Item(ByVal Trigpoint As cSurveyPC.cSurvey.cTrigPoint) As cTrigPoint
            Get
                Return oItems(Trigpoint.Name)
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Name As String) As cTrigPoint
            Get
                Return oItems(Name)
            End Get
        End Property

        Public Function Contains(ByVal Name As String) As Boolean
            Return oItems.ContainsKey(Name)
        End Function

        Public Function Contains(ByVal Trigpoint As cSurveyPC.cSurvey.cTrigPoint) As Boolean
            Return oItems.ContainsKey(Trigpoint.Name)
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Sub Reset()
            For Each oitem As cTrigPoint In oItems.Values
                oitem.Processed = False
            Next
        End Sub

        Friend Sub PlanRotate(Angle As Decimal)
            Dim oPoint As PointD
            Dim dAngle As Decimal = modPaint.DegreeToRadians(Angle)
            For Each oItem As cTrigPoint In oItems.Values
                oPoint = modPaint.RotatePointByRadians(oItem.Point.X, oItem.Point.Y, dAngle)
                Call oItem.MoveTo(oPoint.X, oPoint.Y, oItem.Point.Z, oItem.Point.D)
            Next
        End Sub

        Private Function cTrigPoint_GetEnumerator() As IEnumerator(Of cTrigPoint) Implements IEnumerable(Of cTrigPoint).GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class
End Namespace