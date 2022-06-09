Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Design

Namespace cSurvey.Drawings
    Public Class cDrawUserdata
        Implements IEnumerable

        Private oData As Dictionary(Of String, String)

        Friend Sub New()
            oData = New Dictionary(Of String, String)
        End Sub

        Friend Sub LoadSVG(Element As XmlElement)
            Call oData.Clear()
            For Each oAttribute As XmlAttribute In Element.Attributes
                If oAttribute.Prefix = "csurvey" Then
                    If oAttribute.Value <> "" Then
                        Call oData.Add(oAttribute.LocalName, oAttribute.Value)
                    End If
                End If
            Next
        End Sub

        Public Sub Clear()
            Call oData.Clear()
        End Sub

        Public Function Contains(Key As String) As Boolean
            Return oData.ContainsKey(Key)
        End Function

        Public Sub SetTypedValue(Type As Data.cDataFields.TypeEnum, Key As String, Value As Object)
            If oData.ContainsKey(Key) Then
                Call oData.Remove(Key)
            End If
            Call oData.Add(Key, Data.cDataField.ValueToString(Type, Value))
        End Sub

        Public Function GetTypedValues(Type As Data.cDataFields.TypeEnum, KeyPattern As String) As List(Of KeyValuePair(Of String, String))
            Dim oResult As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
            For Each sKey As String In oData.Keys.Where(Function(okey) okey Like KeyPattern)
                Call oResult.Add(New KeyValuePair(Of String, String)(sKey, oData(sKey)))
            Next
            Return oResult
        End Function

        Public Function GetTypedValue(Type As Data.cDataFields.TypeEnum, Key As String, Optional DefaultValue As Object = Nothing) As String
            If oData.ContainsKey(Key) Then
                Dim sValue As String = oData(Key)
                Return Data.cDataField.StringToValue(Type, sValue)
            Else
                Return DefaultValue
            End If
        End Function

        Public Function SetValue(Key As String, Value As String)
            If oData.ContainsKey(Key) Then
                Call oData.Remove(Key)
            End If
            Call oData.Add(Key, Value)
        End Function

        Public Function GetValue(Key As String, Optional DefaultValue As String = Nothing) As String
            If oData.ContainsKey(Key) Then
                Return oData(Key)
            Else
                Return DefaultValue
            End If
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oData.Count
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oData.GetEnumerator
        End Function
    End Class

    Public Class cDrawClipArt
        Private oUserData As cDrawUserdata
        Private oStyles As cDrawStyles
        Private oPaths As cDrawPaths

        Private oRegion As Region

        Public Enum cDrawClipartDataFormatEnum
            SVGData = 0
            SVGFile = 1
        End Enum

        Private sData As String

        Public Function IsEmpty() As Boolean
            Return oPaths.Count = 0
        End Function

        Friend Function Clone() As cDrawClipArt
            Return New cDrawClipArt(Me)
        End Function

        Friend Sub New(Data As Byte())
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me)
            oPaths = New cDrawPaths(Me)
            Dim oXml As XmlDocument = New XmlDocument
            oXml.XmlResolver = Nothing
            oXml.Load(New IO.MemoryStream(Data))
            sData = oXml.InnerXml
            Call pLoadSVG(oXml)
        End Sub

        Friend Sub New(Stream As IO.Stream)
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me)
            oPaths = New cDrawPaths(Me)
            Dim oXml As XmlDocument = New XmlDocument
            oXml.XmlResolver = Nothing
            oXml.Load(Stream)
            sData = oXml.InnerXml
            Call pLoadSVG(oXml)
        End Sub

        Friend Sub New(ByVal Clipart As cDrawClipArt)
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me, Clipart.Styles)
            oPaths = New cDrawPaths(Me, Clipart.Paths)
            sData = Clipart.sData
        End Sub

        Public Function GetRegion() As Region
            Return oPaths.GetRegion
        End Function

        Public ReadOnly Property UserData As cDrawUserdata
            Get
                Return oUserData
            End Get
        End Property

        Friend Sub New()
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me)
            oPaths = New cDrawPaths(Me)
        End Sub

        Public Sub New(ByVal Filename As String)
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me)
            oPaths = New cDrawPaths(Me)
            Dim oXML As XmlDocument = New XmlDocument
            oXML.XmlResolver = Nothing
            Call oXML.Load(Filename)
            sData = oXML.OuterXml
            Call pLoadSVG(oXML)
        End Sub

        Public Sub New(ByVal XML As XmlDocument)
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me)
            oPaths = New cDrawPaths(Me)
            sData = XML.InnerXml
            Call pLoadSVG(XML)
        End Sub

        Friend Sub New(ByVal Clipart As XmlElement)
            oUserData = New cDrawUserdata
            oStyles = New cDrawStyles(Me)
            oPaths = New cDrawPaths(Me)
            sData = Clipart.GetAttribute("data")
            If sData <> "" Then
                Dim oXML As XmlDocument = New XmlDocument
                oXML.XmlResolver = Nothing
                Call oXML.LoadXml(sData)
                Call pLoadSVG(oXML)
            End If
        End Sub

        Friend ReadOnly Property Data As String
            Get
                Return sData
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oClipart As XmlElement = Document.CreateElement("clipart")
            Call oClipart.SetAttribute("data", sData)
            Call Parent.AppendChild(oClipart)
            Return oClipart
        End Function

        Public Sub Save(Stream As IO.Stream)
            Dim bBuffer As Byte() = System.Text.ASCIIEncoding.UTF8.GetBytes(sData)
            Call Stream.Write(bBuffer, 0, bBuffer.Count)
            Stream.Position = 0
        End Sub

        Private Sub pLoadSVG(ByVal XML As XmlDocument)
            Dim oXMLRoot As XmlElement = XML.Item("svg")
            Call pSVGLoadUserData(oXMLRoot)
            Call pSVGLoadStyle(oXMLRoot)
            Call pSVGLoadPath(oXMLRoot)
            'elimino un eventuale offset ....
            Dim oBounds As RectangleF = GetBounds()
            If oBounds.Left <> 0F OrElse oBounds.Top <> 0F Then
                Using oMatrix As Matrix = New Matrix
                    Call oMatrix.Translate(-oBounds.Left, -oBounds.Top)
                    Call Transform(oMatrix)
                End Using
            End If
        End Sub

        Private Sub pSVGLoadUserData(ByVal Parent As XmlElement)
            Call oUserData.LoadSVG(Parent)
        End Sub

        Private Sub pSVGLoadStyle(ByVal Parent As XmlElement)
            Dim oXMLDefs As XmlElement = Parent.Item("defs")
            If Not oXMLDefs Is Nothing Then
                Dim oXMLStyle As XmlElement = oXMLDefs.Item("style")
                If Not oXMLStyle Is Nothing Then
                    Dim sCSS As String = oXMLStyle.InnerText.Trim
                    Dim sCSSParts() As String = sCSS.Split("}")
                    For Each sCSSPart As String In sCSSParts
                        If sCSSPart.Length > 0 Then
                            Dim sCSSNameValues() As String = sCSSPart.Split("{")
                            Dim sClassName As String = sCSSNameValues(0).Trim
                            If sClassName.StartsWith(".") Then sClassName = sClassName.Substring(1)
                            Dim sClassValues As String = sCSSNameValues(1).Trim
                            Call oStyles.Append(sClassName, sClassValues)
                        End If
                    Next
                End If
            End If
        End Sub

        Private Function pProcessStyle(ParentClass As String, Item As XmlElement) As String
            Dim sClass As String = Item.GetAttribute("class")
            If sClass = "" Then
                If (Item.HasAttribute("fill") OrElse Item.HasAttribute("style")) Then
                    sClass = Guid.NewGuid.ToString
                    Dim sStyle As String = Item.GetAttribute("style")
                    Dim oStyle As cDrawStyle = oStyles.Append(sClass, sStyle)
                    If Item.HasAttribute("fill") Then Call oStyle.Add("fill", Item.GetAttribute("fill"))
                Else
                    sClass = ParentClass
                End If
            End If
            Return sClass
        End Function

        Public Shared Sub ProcessDataToPath(Data As String, Path As GraphicsPath)
            'curva...
            Dim bAbsolute As Boolean
            Dim iAction As Integer
            Dim bDecimal As Boolean

            Dim oStartPoint As PointF
            Dim oControlPoint As PointF
            Dim oPoint As PointF = New PointF
            Dim iCount As Integer = 0
            Dim sPath As String = Data & " "

            '* M = moveto
            '* L = lineto
            '* H = horizontal lineto
            '* V = vertical lineto
            '* C = curve
            '* S = curve (shorted)
            '* Q = quadratic Belzier curve
            '* T = end quadratic Belzier curveto
            '* A = elliptical Arc
            '* Z = closepath

            Dim i As Integer = 0
            Do While i < sPath.Length
                Dim sChar As Char = sPath.Chars(i)
                'Dim sValue As String = ""
                Select Case sChar
                    Case "q"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Dim oPoint2 As PointF = oPoint1
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oControlPoint = oPoint2
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "Q"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Dim oPoint2 As PointF = oPoint1
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oControlPoint = oPoint2
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "t"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            Dim oNewControlPoint As PointF = New PointF(oPoint.X + (oPoint.X - oControlPoint.X), oPoint.Y + (oPoint.Y - oControlPoint.Y))
                            Dim oPoint1 As PointF = oNewControlPoint
                            Dim oPoint2 As PointF = oNewControlPoint
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "T"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            Dim oNewControlPoint As PointF = New PointF(oPoint.X + (oPoint.X - oControlPoint.X), oPoint.Y + (oPoint.Y - oControlPoint.Y))
                            Dim oPoint1 As PointF = oNewControlPoint
                            Dim oPoint2 As PointF = oNewControlPoint
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "s"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            Dim oNewControlPoint As PointF = New PointF(oPoint.X + (oPoint.X - oControlPoint.X), oPoint.Y + (oPoint.Y - oControlPoint.Y))
                            Dim oPoint1 As PointF = oNewControlPoint
                            Dim oPoint2 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oControlPoint = oPoint2
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "S"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            Dim oNewControlPoint As PointF = New PointF(oPoint.X + (oPoint.X - oControlPoint.X), oPoint.Y + (oPoint.Y - oControlPoint.Y))
                            Dim oPoint1 As PointF = oNewControlPoint
                            Dim oPoint2 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oControlPoint = oPoint2
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "l"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "L"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "v"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = New PointF(oPoint.X, oPoint.Y + pSVGGetValue(sPath, i))
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "V"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = New PointF(oPoint.X, pSVGGetValue(sPath, i))
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "h"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = New PointF(oPoint.X + pSVGGetValue(sPath, i), oPoint.Y)
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "H"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = New PointF(pSVGGetValue(sPath, i), oPoint.Y)
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "m"
                        iAction = 0
                        bAbsolute = False
                        i += 1
                        oPoint = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                        Call Path.StartFigure()
                        oStartPoint = oPoint

                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "M"
                        iAction = 0
                        bAbsolute = True
                        i += 1
                        oPoint = pSVGGetPoint(sPath, i, 0, 0)
                        Call Path.StartFigure()
                        oStartPoint = oPoint

                        Do While i < sPath.Length
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do

                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Call Path.AddLine(oPoint, oPoint1)
                            oPoint = oPoint1

                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case "z", "Z"
                        oPoint = oStartPoint
                        iAction = 2
                        bDecimal = False
                        i += 1
                        Call Path.CloseFigure()

                    Case "c"
                        iAction = 1
                        bAbsolute = False
                        i += 1
                        Do While i < sPath.Length
                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Dim oPoint2 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, oPoint.X, oPoint.Y)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oControlPoint = oPoint2
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop
                    Case "C"
                        iAction = 1
                        bAbsolute = True
                        i += 1
                        Do While i < sPath.Length
                            Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Dim oPoint2 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Dim oPoint3 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                            Call Path.AddBezier(oPoint, oPoint1, oPoint2, oPoint3)
                            oControlPoint = oPoint2
                            oPoint = oPoint3
                            sChar = pSVGSkipSpaces(sPath, i)
                            If Char.IsLetter(sChar) Then Exit Do
                        Loop

                    Case Else
                        i += 1
                End Select
                If i >= sPath.Length Then Exit Do
            Loop
        End Sub


        Private Sub pSVGLoadPath(ByVal Parent As XmlElement)
            Dim oGroupTrasform As Matrix = pSVGGetTransform(Parent)

            Dim sParentClass As String = Parent.GetAttribute("class")
            If sParentClass = "" Then
                sParentClass = Guid.NewGuid.ToString
                Dim sParentStyle As String = Parent.GetAttribute("style")
                Dim oParentStyle As cDrawStyle = oStyles.Append(sParentClass, sParentStyle)
                If Parent.HasAttribute("fill") Then Call oParentStyle.Add("fill", Parent.GetAttribute("fill"))
            End If

            For Each oNote As XmlNode In Parent.ChildNodes
                If oNote.NodeType = XmlNodeType.Element Then
                    Dim oItem As XmlElement = oNote
                    Select Case oItem.Name
                        Case "text"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)

                            Dim sClass As String = oItem.GetAttribute("class")
                            If sClass = "" Then
                                sClass = Guid.NewGuid.ToString
                                Dim sStyle As String = oItem.GetAttribute("style")
                                Dim oStyle As cDrawStyle = oStyles.Append(sClass, sStyle)
                                If oItem.HasAttribute("fill") Then Call oStyle.Add("fill", oItem.GetAttribute("fill"))
                            End If

                            Dim sFontFamily As String = oItem.GetAttribute("font-family")
                            Dim oFontFamily As System.Drawing.FontFamily
                            Try
                                oFontFamily = New System.Drawing.FontFamily(sFontFamily)
                            Catch ex As Exception
                                Dim iDefaultFontFamily As System.Drawing.Text.GenericFontFamilies
                                Select Case sFontFamily.ToLower
                                    Case "sansserif", "sans-serif"
                                        iDefaultFontFamily = Text.GenericFontFamilies.SansSerif
                                    Case "serif"
                                        iDefaultFontFamily = Text.GenericFontFamilies.Serif
                                    Case "monospace"
                                        iDefaultFontFamily = Text.GenericFontFamilies.Monospace
                                End Select
                                oFontFamily = New System.Drawing.FontFamily(iDefaultFontFamily)
                            End Try
                            If oFontFamily Is Nothing Then
                                oFontFamily = New System.Drawing.FontFamily("Tahoma")
                            End If
                            Dim sFontSize As Single = modNumbers.StringToSingle(oItem.GetAttribute("font-size"))
                            Dim sFontWeight As String = oItem.GetAttribute("font-weight")
                            Dim iFontStyle As Integer
                            Dim sText As String = oItem.InnerText

                            Dim oCenter As PointF = New PointF(modNumbers.StringToSingle(oItem.GetAttribute("x")), modNumbers.StringToSingle(oItem.GetAttribute("y")))
                            Using oSF As StringFormat = New StringFormat
                                Call oPath.AddString(sText, oFontFamily, iFontStyle, sFontSize, oCenter, oSF)
                            End Using
                            Call oFontFamily.Dispose()
                            Dim oBounds As RectangleF = oPath.GetBounds
                            Dim sTextAnchor As String = oItem.GetAttribute("text-anchor")
                            Select Case sTextAnchor
                                Case "end"
                                    Using oMatrix As Matrix = New Matrix
                                        Call oMatrix.Translate(-oBounds.Width, -oBounds.Height)
                                        Call oPath.Transform(oMatrix)
                                    End Using
                                Case "middle"
                                        Using oMatrix As Matrix = New Matrix
                                            Call oMatrix.Translate(-oBounds.Width / 2, -oBounds.Height)
                                            Call oPath.Transform(oMatrix)
                                        End Using
                                        Case Else '"start" 'attenzione: ci sarebbe hinerit ma per ora non la gestisco
                                    Using oMatrix As Matrix = New Matrix
                                        Call oMatrix.Translate(0, -oBounds.Height)
                                        Call oPath.Transform(oMatrix)
                                    End Using
                            End Select

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If
                        Case "g" 'gruppo di oggetti
                            Call pSVGLoadPath(oItem)
                        Case "path"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)

                            Dim sClass As String = pProcessStyle(sParentClass, oItem)

                            Dim sPath As String = oItem.GetAttribute("d") & " "

                            Call ProcessDataToPath(sPath, oPath)

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If

                        Case "polyline"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)
                            Dim sClass As String = pProcessStyle(sParentClass, oItem)
                            Dim sPath As String = oItem.GetAttribute("points") & " "

                            Dim oPolygon As List(Of PointF) = New List(Of PointF)
                            Dim i As Integer = 0
                            Do While i < sPath.Length
                                Dim sChar As Char = sPath.Chars(i)
                                Do While i < sPath.Length
                                    Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                                    Call oPolygon.Add(oPoint1)
                                    sChar = pSVGSkipSpaces(sPath, i)
                                    If Char.IsLetter(sChar) Then Exit Do
                                Loop
                            Loop
                            Call oPath.AddLines(oPolygon.ToArray)

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If
                        Case "polygon"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)
                            Dim sClass As String = pProcessStyle(sParentClass, oItem)
                            Dim sPath As String = oItem.GetAttribute("points") & " "

                            Dim oPolygon As List(Of PointF) = New List(Of PointF)
                            Dim i As Integer = 0
                            Do While i < sPath.Length
                                Dim sChar As Char = sPath.Chars(i)
                                Dim sValue As String = ""

                                Do While i < sPath.Length
                                    Dim oPoint1 As PointF = pSVGGetPoint(sPath, i, 0, 0)
                                    Call oPolygon.Add(oPoint1)

                                    sChar = pSVGSkipSpaces(sPath, i)
                                    If Char.IsLetter(sChar) Then Exit Do
                                Loop
                            Loop

                            Call oPath.AddPolygon(oPolygon.ToArray)

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If
                        Case "line"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)
                            Dim sClass As String = pProcessStyle(sParentClass, oItem)

                            Call oPath.StartFigure()
                            Dim oFromPoint As PointF = New PointF(modNumbers.StringToSingle(oItem.GetAttribute("x1")), modNumbers.StringToSingle(oItem.GetAttribute("y1")))
                            Dim oToPoint As PointF = New PointF(modNumbers.StringToSingle(oItem.GetAttribute("x2")), modNumbers.StringToSingle(oItem.GetAttribute("y2")))
                            Call oPath.AddLine(oFromPoint, oToPoint)

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If
                        Case "circle"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)
                            Dim sClass As String = pProcessStyle(sParentClass, oItem)

                            Call oPath.StartFigure()
                            Dim oCenter As PointF = New PointF(modNumbers.StringToSingle(oItem.GetAttribute("cx")), modNumbers.StringToSingle(oItem.GetAttribute("cy")))
                            Dim sR As Single = modNumbers.StringToSingle(oItem.GetAttribute("r"))
                            oCenter.X -= sR
                            oCenter.Y -= sR
                            Call oPath.AddEllipse(oCenter.X, oCenter.Y, sR * 2.0F, sR * 2.0F)

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If
                        Case "rect"
                            Dim oPath As GraphicsPath = New GraphicsPath
                            Dim sID As String = pSVGGetID(oItem)
                            Dim sClass As String = pProcessStyle(sParentClass, oItem)

                            Call oPath.StartFigure()
                            Dim oRect As RectangleF = New RectangleF(modNumbers.StringToSingle(oItem.GetAttribute("x")), modNumbers.StringToSingle(oItem.GetAttribute("y")), modNumbers.StringToSingle(oItem.GetAttribute("width")), modNumbers.StringToSingle(oItem.GetAttribute("height")))
                            Call oPath.AddRectangle(oRect)

                            If oPath.PointCount > 0 Then
                                If Not oGroupTrasform Is Nothing Then
                                    Call oPath.Transform(oGroupTrasform)
                                End If
                                Using oTransform As Matrix = pSVGGetTransform(oItem)
                                    If Not oTransform Is Nothing Then
                                        Call oPath.Transform(oTransform)
                                    End If
                                End Using
                                Call oPaths.Append(oPath, sClass, sID)
                            End If
                    End Select
                End If
            Next

            If Not oGroupTrasform Is Nothing Then
                Call oGroupTrasform.Dispose()
            End If
        End Sub

        Private Shared Function pSVGGetTransform(ByVal Item As XmlElement) As Matrix
            Dim sTransform As String = Item.GetAttribute("transform")
            sTransform = sTransform.Trim
            If sTransform <> "" Then
                If sTransform Like "matrix(*)" Then
                    Dim s() As String = sTransform.Substring(7, sTransform.Length - 7 - 1).Split(",")
                    Return New Matrix(modNumbers.StringToSingle(s(0)), modNumbers.StringToSingle(s(1)), modNumbers.StringToSingle(s(2)), modNumbers.StringToSingle(s(3)), modNumbers.StringToSingle(s(4)), modNumbers.StringToSingle(s(5)))
                Else
                    Dim oMatrix As Matrix = New Matrix
                    Dim sParts() As String = sTransform.Split(" ")
                    For Each sPart As String In sParts
                        If sPart Like "translate(*)" Then
                            Dim s() As String = sPart.Substring(10, sPart.Length - 10 - 1).Split(",")
                            If s.Length = 1 Then
                                Call oMatrix.Translate(modNumbers.StringToSingle(s(0)), 0, MatrixOrder.Append)
                            Else
                                Call oMatrix.Translate(modNumbers.StringToSingle(s(0)), modNumbers.StringToSingle(s(1)), MatrixOrder.Append)
                            End If
                        ElseIf sPart Like "scale(*)" Then
                            Dim s() As String = sPart.Substring(6, sPart.Length - 6 - 1).Split(",")
                            If s.Length = 1 Then
                                Dim sScale As Single = modNumbers.StringToSingle(s(0))
                                Call oMatrix.Scale(sScale, sScale, MatrixOrder.Append)
                            Else
                                Dim sScaleX As Single = modNumbers.StringToSingle(s(0))
                                Dim sScaleY As Single = modNumbers.StringToSingle(s(1))
                                Call oMatrix.Scale(sScaleX, sScaleY, MatrixOrder.Append)
                            End If
                        ElseIf sPart Like "rotate(*)" Then
                            Dim s() As String = sPart.Substring(7, sPart.Length - 7 - 1).Split(",")
                            If s.Length = 1 Then
                                Dim sAngle As Single = modNumbers.StringToSingle(s(0))
                                Call oMatrix.Rotate(sAngle, MatrixOrder.Append)
                            Else
                                Dim oPoint As PointF = New PointF(modNumbers.StringToSingle(s(1)), modNumbers.StringToSingle(s(2)))
                                Dim sAngle As Single = modNumbers.StringToSingle(s(0))
                                Call oMatrix.RotateAt(sAngle, oPoint, MatrixOrder.Append)
                            End If
                        Else
                            'skew?
                        End If
                    Next
                    Return oMatrix
                End If
            Else
                Return Nothing
            End If
        End Function

        Private Shared Function pSVGGetID(ByVal Item As XmlElement) As String
            If Item.HasAttribute("id") Then
                Return Item.GetAttribute("id")
            Else
                Return ""
            End If
        End Function

        Private Shared Function pSVGSkipSpaces(ByVal Path As String, ByRef Index As Integer) As Char
            Dim sChar As Char
            Dim iIndex As Integer = Index
            Do While iIndex < Path.Length
                sChar = Path.Chars(iIndex)
                If sChar = " " OrElse sChar = "," OrElse sChar = vbLf OrElse sChar = vbCr OrElse sChar = vbTab Then
                    iIndex += 1
                Else
                    Exit Do
                End If
            Loop
            Index = iIndex
            Return sChar
        End Function

        Private Shared Function pSVGGetValue(ByVal Path As String, ByRef Index As Integer) As Single
            Dim oValue As Single
            'Dim bFlagDecimal As Boolean
            Dim iIndex As Integer = Index
            Dim sValue As String
            Call pSVGSkipSpaces(Path, iIndex)
            Dim iFirstIndex As Integer = iIndex
            sValue = ""
            Do While iIndex < Path.Length
                Dim sChar As Char = Path.Chars(iIndex)
                If Char.IsDigit(sChar) OrElse sChar = "." OrElse (sChar = "+" AndAlso iFirstIndex = iIndex) OrElse (sChar = "-" AndAlso iFirstIndex = iIndex) OrElse sChar = "e" Then
                    sValue = sValue & sChar
                    iIndex += 1
                    If sChar = "e" Then iFirstIndex = iIndex
                Else
                    Exit Do
                End If
            Loop
            oValue = StringToSingle(sValue)
            Index = iIndex
            Return oValue
        End Function

        Private Shared Function pSVGGetPoint(ByVal Path As String, ByRef Index As Integer, ByVal RelativeX As Single, ByVal RelativeY As Single) As PointF
            Dim oPoint As PointF = New PointF
            Dim iIndex As Integer = Index
            Dim sValue As String
            Call pSVGSkipSpaces(Path, iIndex)
            Dim iFirstIndex As Integer = iIndex
            sValue = ""
            Do While iIndex < Path.Length
                Dim sChar As Char = Path.Chars(iIndex)
                If Char.IsDigit(sChar) OrElse sChar = "." OrElse (sChar = "+" AndAlso iFirstIndex = iIndex) OrElse (sChar = "-" AndAlso iFirstIndex = iIndex) OrElse sChar = "e" Then
                    sValue = sValue & sChar
                    iIndex += 1
                    If sChar = "e" Then iFirstIndex = iIndex
                Else
                    Exit Do
                End If
            Loop
            oPoint.X = StringToSingle(sValue)
            Call pSVGSkipSpaces(Path, iIndex)
            iFirstIndex = iIndex
            sValue = ""
            Do While iIndex < Path.Length
                Dim sChar As Char = Path.Chars(iIndex)
                If Char.IsDigit(sChar) OrElse sChar = "." OrElse (sChar = "+" AndAlso iFirstIndex = iIndex) OrElse (sChar = "-" AndAlso iFirstIndex = iIndex) OrElse sChar = "e" Then
                    sValue = sValue & sChar
                    iIndex += 1
                    If sChar = "e" Then iFirstIndex = iIndex
                Else
                    Exit Do
                End If
            Loop
            oPoint.Y = StringToSingle(sValue)

            oPoint.X += RelativeX
            oPoint.Y += RelativeY
            Index = iIndex
            Return oPoint
        End Function

        Public Function GetBounds() As RectangleF
            Return oPaths.GetBounds
        End Function

        Public Sub Transform(ByVal Matrix As Matrix)
            For Each oPath As cDrawPath In oPaths
                Call oPath.Path.Transform(Matrix)
            Next
        End Sub

        Public Function TransformPaths(ByVal Matrix As Matrix) As cDrawPaths
            Dim oReturnPaths As cDrawPaths = New cDrawPaths(Me)
            For Each oPath As cDrawPath In oPaths
                Dim oTransformedPath As GraphicsPath = oPath.Path.Clone
                Call oTransformedPath.Transform(Matrix)
                Call oReturnPaths.Append(oTransformedPath, oPath.Class)
            Next
            Return oReturnPaths
        End Function

        Public Function ClonePaths() As cDrawPaths
            Dim oReturnPaths As cDrawPaths = New cDrawPaths(Me)
            For Each oPath As cDrawPath In oPaths
                Call oReturnPaths.Append(oPath.Path.Clone, oPath.Class)
            Next
            Return oReturnPaths
        End Function

        Public ReadOnly Property Styles() As cDrawStyles
            Get
                Return oStyles
            End Get
        End Property

        Public ReadOnly Property Paths() As cDrawPaths
            Get
                Return oPaths
            End Get
        End Property

        Public Function GetThumbnailImage(ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Dim oImage As Bitmap = New Bitmap(thumbWidth, thumbHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)
            Using oGraphics As Graphics = Graphics.FromImage(oImage)
                oGraphics.CompositingQuality = CompositingQuality.HighQuality
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias
                Dim oRect As RectangleF = GetBounds()
                Dim sDX As Single = oRect.Width / thumbWidth
                Dim sDY As Single = oRect.Height / thumbHeight
                Dim sD As Single = 1 / If(sDX > sDY, sDX, sDY)
                Call Paint(oGraphics, ForeColor, Backcolor, sD, New PointF((thumbWidth - oRect.Width * sD) / 2, (thumbHeight - oRect.Height * sD) / 2))
            End Using
            Return oImage
        End Function

        Public Sub Paint(ByVal Graphics As Graphics, ByVal ForeColor As Color, ByVal Backcolor As Color, ByVal Zoom As Single, ByVal Translate As PointF)
            Using oMatrix As Matrix = New Matrix
                If Zoom <> 1 Then
                    Call oMatrix.Scale(Zoom, Zoom, MatrixOrder.Append)
                End If
                Call oMatrix.Translate(Translate.X, Translate.Y, MatrixOrder.Append)
                Using oForePen As Pen = New Pen(ForeColor, cEditPaintObjects.FilettoPenWidth)
                    Using oForeBrush As SolidBrush = New SolidBrush(ForeColor)
                        Using oBackbrush As SolidBrush = New SolidBrush(Backcolor)
                            For Each oDrawPath As cDrawPath In oPaths
                                Using oClipartPath As GraphicsPath = oDrawPath.Path.Clone
                                    Call oClipartPath.Transform(oMatrix)
                                    Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                                    If sFill <> "none" Then
                                        Dim oColor As Color = Color.Transparent
                                        Try
                                            oColor = ColorTranslator.FromHtml(sFill)
                                        Catch
                                        End Try
                                        If oColor.ToArgb = Color.White.ToArgb Then
                                            Call Graphics.FillPath(oBackbrush, oClipartPath)
                                        Else
                                            Call Graphics.FillPath(oForeBrush, oClipartPath)
                                        End If
                                    End If
                                    Call Graphics.DrawPath(oForePen, oClipartPath)
                                End Using
                            Next
                        End Using
                    End Using
                End Using
            End Using
        End Sub
    End Class

    Public Class cDrawStyles
        Implements IEnumerable

        Private oClipart As cDrawClipArt
        Private oItems As Dictionary(Of String, cDrawStyle)

        Friend Sub New(ByVal Clipart As cDrawClipArt, ByVal Styles As cDrawStyles)
            oClipart = Clipart
            oItems = New Dictionary(Of String, cDrawStyle)
            For Each sKey As String In Styles.oItems.Keys
                Call oItems.Add(sKey, New cDrawStyle(Styles(sKey)))
            Next
        End Sub

        Friend Sub New(ByVal Clipart As cDrawClipArt)
            oClipart = Clipart
            oItems = New Dictionary(Of String, cDrawStyle)
        End Sub

        Public Function Append(ByVal Name As String, ByVal Values As String) As cDrawStyle
            Dim oStyle As cDrawStyle = New cDrawStyle(Name, Values)
            Call oItems.Add(Name, oStyle)
            Return oStyle
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Name As String) As cDrawStyle
            Get
                Return oItems(Name)
            End Get
        End Property

        Public Function Contains(Item As cDrawStyle) As Boolean
            Return oItems.ContainsValue(Item)
        End Function

        Public Function Contains(Name As String) As Boolean
            Return oItems.ContainsKey(Name)
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class

    Public Class cDrawStyle
        Private sName As String
        Private oItems As Dictionary(Of String, String)

        Public Sub Add(Key As String, Value As String)
            If Value <> "" Then
                If oItems.ContainsKey(Key) Then
                    Call oItems.Remove(Key)
                End If
                Call oItems.Add(Key, Value)
            End If
        End Sub

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Friend Sub New(DrawStyle As cDrawStyle)
            sName = DrawStyle.Name
            oItems = New Dictionary(Of String, String)
            For Each sKey As String In DrawStyle.oItems.Keys
                Call oItems.Add(sKey, DrawStyle.oItems(sKey))
            Next
        End Sub

        Friend Sub New(Name As String, ByVal Values As String)
            sName = Name
            oItems = New Dictionary(Of String, String)
            If Values.Trim <> "" Then
                Dim sValueItems() As String = Values.Split({";"c}, StringSplitOptions.RemoveEmptyEntries)
                For Each sValueItem As String In sValueItems
                    Dim sKeyValue() As String = sValueItem.Split(":")
                    Dim sKey As String = sKeyValue(0)
                    Dim sValue As String = sKeyValue(1)
                    Call oItems.Add(sKey, sValue)
                Next
            End If
        End Sub

        Public Function Contains(Name As String) As Boolean
            Return oItems.ContainsKey(Name)
        End Function

        Public Function GetStyle(ByVal Key As String, Optional ByVal DefaultValue As String = "") As String
            If oItems.ContainsKey(Key) Then
                Return oItems(Key)
            Else
                Return DefaultValue
            End If
        End Function
    End Class

    Public Class cDrawPaths
        Implements IEnumerable
        Implements IDisposable

        Private oClipart As cDrawClipArt
        Private oItems As List(Of cDrawPath)

        Friend Function GetRegion() As Region
            Dim oRegion As Region = New Region
            Call oRegion.MakeEmpty()
            For Each oItem As cDrawPath In oItems
                Call oRegion.Union(oItem.Path)
            Next
            Return oRegion
        End Function

        Friend Sub New(ByVal Clipart As cDrawClipArt, ByVal Paths As cDrawPaths)
            oClipart = Clipart
            oItems = New List(Of cDrawPath)
            For Each oitem As cDrawPath In Paths
                Call oItems.Add(New cDrawPath(Clipart, oitem))
            Next
        End Sub

        Friend Sub New(ByVal Clipart As cDrawClipArt)
            oClipart = Clipart
            oItems = New List(Of cDrawPath)
        End Sub

        Public Function GetBounds() As RectangleF
            'Dim oRect As RectangleF
            'If oItems.Count > 0 Then
            '    Using oFlatPath As GraphicsPath = oItems(0).Path.Clone
            '        Call oFlatPath.Flatten(Nothing, 0.0001F)
            '        oRect = oFlatPath.GetBounds
            '        For i As Integer = 1 To oItems.Count - 1
            '            Using oFlatNewPath As GraphicsPath = oItems(i).Path.Clone
            '                Call oFlatNewPath.Flatten(Nothing, 0.0001F)
            '                Dim oNewRect As RectangleF = oFlatNewPath.GetBounds()
            '                If Not modPaint.IsRectangleEmpty(oNewRect) Then
            '                    oRect = RectangleF.Union(oRect, oNewRect)
            '                End If
            '            End Using
            '        Next
            '    End Using
            'End If
            'Return oRect
            Dim oRect As RectangleF
            If oItems.Count > 0 Then
                oRect = oItems(0).Path.GetBounds
                For i As Integer = 1 To oItems.Count - 1
                    Dim oNewRect As RectangleF = oItems(i).Path.GetBounds()
                    If Not modPaint.IsRectangleEmpty(oNewRect) Then
                        oRect = RectangleF.Union(oRect, oNewRect)
                    End If
                Next
            End If
            Return oRect
        End Function


        Public Sub Warp(DestPoint As PointF(), SrcRect As RectangleF)
            For Each oPath As cDrawPath In oItems
                Call oPath.Path.WarpQ(DestPoint, SrcRect)
            Next
        End Sub

        'Public Sub Warp(DestPoint As PointF(), SrcRect As RectangleF)
        '    For Each oPath As cDrawPath In oItems
        '        Call oPath.Path.Warp(DestPoint, SrcRect)
        '    Next
        'End Sub

        Public Sub Transform(ByVal Matrix As Matrix)
            For Each oPath As cDrawPath In oItems
                Call oPath.Path.Transform(Matrix)
            Next
        End Sub

        Public Function Append(ByVal Path As GraphicsPath, ByVal [Class] As String) As cDrawPath
            Dim oPath As cDrawPath = New cDrawPath(oClipart, Path, [Class])
            Call oItems.Add(oPath)
            Return oPath
        End Function

        Public Function Append(ByVal Path As GraphicsPath, ByVal [Class] As String, ByVal ID As String) As cDrawPath
            Dim oPath As cDrawPath = New cDrawPath(oClipart, Path, [Class], ID)
            Call oItems.Add(oPath)
            Return oPath
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cDrawPath
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub Render(ByVal Item As cItem, ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Cache As cDrawCache)
            For Each oDrawPath As cDrawPath In oItems
                Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                If sFill <> "none" Then
                    Call Item.Brush.Render(Graphics, PaintOptions, Options, Selected, oDrawPath.Path, Cache)
                End If
                Call Item.Pen.Render(Graphics, PaintOptions, Options, Selected, oDrawPath.Path, Cache)
            Next
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    For Each oItem As cDrawPath In oItems
                        Call oItem.dispose
                    Next
                    Call oItems.Clear()
                    oClipart = Nothing
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
        End Sub
#End Region
    End Class

    Public Class cDrawPath
        Implements IDisposable

        Private sID As String

        Private oClipart As cDrawClipArt
        Private oPath As GraphicsPath

        Private sClass As String
        Private sClassNames() As String

        Public Property ID As String
            Get
                Return sID
            End Get
            Set(ByVal value As String)
                sID = value
            End Set
        End Property

        Friend Sub New(ByVal Clipart As cDrawClipArt, DrawPath As cDrawPath)
            oClipart = Clipart
            oPath = DrawPath.Path.Clone
            sClass = DrawPath.Class
            sClassNames = sClass.Split(" ")
            sID = DrawPath.ID
        End Sub

        Friend Sub New(ByVal Clipart As cDrawClipArt, ByVal Path As GraphicsPath, ByVal [Class] As String, ByVal ID As String)
            oClipart = Clipart
            oPath = Path
            sClass = [Class]
            sClassNames = sClass.Split(" ")
            sID = ID
        End Sub

        Friend Sub New(ByVal Clipart As cDrawClipArt, ByVal Path As GraphicsPath, ByVal [Class] As String)
            oClipart = Clipart
            oPath = Path
            sClass = [Class]
            sClassNames = sClass.Split(" ")
        End Sub

        Public ReadOnly Property Path() As GraphicsPath
            Get
                Return oPath
            End Get
        End Property

        Public ReadOnly Property [Class]() As String
            Get
                Return sClass
            End Get
        End Property

        Public Function GetStyle(ByVal Key As String, Optional ByVal DefaultValue As String = "") As String
            For Each sClassName As String In sClassNames
                If oClipart.Styles.Contains(sClassName) Then
                    With oClipart.Styles(sClassName)
                        If .Contains(Key) Then
                            Return .GetStyle(Key)
                        End If
                    End With
                End If
            Next
            Return DefaultValue
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not IsNothing(oPath) Then
                        oPath.Dispose()
                        oPath = Nothing
                    End If
                    oClipart = Nothing
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
        End Sub
#End Region
    End Class
End Namespace