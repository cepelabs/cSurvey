Imports cSurveyPC.cSurvey.Drawings

Imports System.Xml
Imports System.Drawing.Drawing2D
Imports System.IO
Imports cSurveyPC.cSurvey.Scripting
Imports System.Collections.ObjectModel
Imports System.Dynamic
Imports cSurveyPC.cSurvey.Design.cBrush

Namespace cSurvey.Design

    ''' <summary>
    ''' Patter brush parameter base class
    ''' </summary>
    Public MustInherit Class cPatternBrushParameterBase
        Private sName As String
        Private sCaption As String
        Private sTooltip As String
        Private sType As String

        Public MustOverride ReadOnly Property DefaultValue As Object

        Public ReadOnly Property Caption As String
            Get
                Return sCaption
            End Get
        End Property

        Public ReadOnly Property Tooltip As String
            Get
                Return sTooltip
            End Get
        End Property

        Public ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property

        Public Function GetRealType() As Type
            Select Case sType
                Case "boolean"
                    Return GetType(Boolean)
                Case "date"
                    Return GetType(Date)
                Case "double"
                    Return GetType(Double)
                Case "single"
                    Return GetType(Single)
                Case "integer"
                    Return GetType(Integer)
                Case "string"
                    Return GetType(String)
            End Select
        End Function

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Sub New(Name As String, Caption As String, Tooltip As String, Type As String)
            sName = Name
            sCaption = Caption
            sTooltip = Tooltip
            sType = Type
        End Sub
    End Class

    Public Class cPatternBrushParameterString
        Inherits cPatternBrushParameterBase

        Private sDefaultValue As String

        Public Overrides ReadOnly Property DefaultValue As Object
            Get
                Return sDefaultValue
            End Get
        End Property

        Public Sub New(Name As String, Caption As String, Tooltip As String, DefaultValue As String)
            MyBase.New(Name, Caption, Tooltip, "string")
            sDefaultValue = DefaultValue
        End Sub
    End Class

    Public Class cPatternBrushParameterBoolean
        Inherits cPatternBrushParameterBase

        Private bDefaultValue As Boolean

        Public Overrides ReadOnly Property DefaultValue As Object
            Get
                Return bDefaultValue
            End Get
        End Property

        Public Sub New(Name As String, Caption As String, Tooltip As String, DefaultValue As Boolean)
            MyBase.New(Name, Caption, Tooltip, "boolean")
            bDefaultValue = DefaultValue
        End Sub
    End Class

    Public Class cPatternBrushParameterSingle
        Inherits cPatternBrushParameterBase

        Private sDefaultValue As Single
        Private sMinValue As Single
        Private sMaxValue As Single

        Public ReadOnly Property MinValue As Single
            Get
                Return sMinValue
            End Get
        End Property

        Public ReadOnly Property MaxValue As Single
            Get
                Return sMaxValue
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultValue As Object
            Get
                Return sDefaultValue
            End Get
        End Property

        Public Sub New(Name As String, Caption As String, Tooltip As String, DefaultValue As Single, MinValue As Single, MaxValue As Single)
            MyBase.New(Name, Caption, Tooltip, "single")
            sDefaultValue = DefaultValue
            sMinValue = MinValue
            sMaxValue = MaxValue
        End Sub
    End Class

    Public Class cPatternBrushInstance
        Inherits Dynamic.DynamicObject

        Private oBase As cPatternBrushBase
        Private oParameterValues As Dictionary(Of String, Object)

        Friend Event OnChanged(sender As Object, e As EventArgs)

        Public Overrides Function TrySetMember(binder As SetMemberBinder, value As Object) As Boolean
            If oBase.Parameters.Contains(binder.Name) Then
                Call SetParameterValue(binder.Name, value)
                Return True
            End If
        End Function

        Public Overrides Function TryGetMember(binder As GetMemberBinder, ByRef result As Object) As Boolean
            If oParameterValues.ContainsKey(binder.Name) Then
                result = GetParameterValue(binder.Name)
                Return True
            ElseIf oBase.Parameters.Contains(binder.Name) Then
                result = oBase.Parameters(binder.Name).DefaultValue
                Return True
            End If
        End Function

        Public Overrides Function GetDynamicMemberNames() As IEnumerable(Of String)
            Return oBase.Parameters.Select(Function(oParameter) oParameter.Name)
        End Function

        Friend ReadOnly Property Base As cPatternBrushBase
            Get
                Return oBase
            End Get
        End Property

        Friend Function ParameterValues() As Dictionary(Of String, Object)
            Return oParameterValues
        End Function

        Public Function GetParameterValue(Name As String) As Object
            If oParameterValues.ContainsKey(Name) Then
                Return oParameterValues(Name)
            Else
                Return oBase.Parameters(Name).DefaultValue
            End If
        End Function

        Public Sub SetParameterValue(Name As String, Value As Object)
            If oParameterValues.ContainsKey(Name) Then
                Call oParameterValues.Remove(Name)
            End If
            Call oParameterValues.Add(Name, Value)
            RaiseEvent OnChanged(Me, EventArgs.Empty)
        End Sub

        Public Sub New(Instance As cPatternBrushInstance)
            oBase = Instance.oBase
            oParameterValues = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
            For Each sKey As String In Instance.ParameterValues.Keys
                Call oParameterValues.Add(sKey, Instance.ParameterValues(sKey))
            Next
        End Sub

        Public Sub New([ID] As Integer)
            oBase = cPatternBrushHelper.GetGallery(ID)
            oParameterValues = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Sub New(Base As cPatternBrushBase)
            oBase = Base
            oParameterValues = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
        End Sub
    End Class

    Public Class cPatternBrushPainter
        Implements IDisposable

        Private oBrush As cPatternBrush
        Private oBounds As RectangleF

        Private oPath As GraphicsPath
        Private disposedValue As Boolean

        Private bIsFilled As Boolean

        Public Property IsFilled As Boolean
            Get
                Return bIsFilled
            End Get
            Set(value As Boolean)
                bIsFilled = value
            End Set
        End Property

        Friend ReadOnly Property Path As GraphicsPath
            Get
                Return oPath
            End Get
        End Property

        Public ReadOnly Property Density() As Single
            Get
                Return oBrush.PatternDensity * oBrush.PatternZoomFactor
            End Get
        End Property

        Public ReadOnly Property DeltaX() As Single
            Get
                Return oBrush.PatternDeltaX * oBrush.PatternZoomFactor
            End Get
        End Property

        Public ReadOnly Property DeltaY() As Single
            Get
                Return oBrush.PatternDeltaY * oBrush.PatternZoomFactor
            End Get
        End Property

        Public ReadOnly Property ZoomFactor() As Single
            Get
                Return oBrush.PatternZoomFactor
            End Get
        End Property

        Public ReadOnly Property Parameters As Object
            Get
                Return oBrush.GetInstance
            End Get
        End Property

        Public ReadOnly Property Brush As cPatternBrush
            Get
                Return oBrush
            End Get
        End Property

        Public ReadOnly Property Bounds As RectangleF
            Get
                Return oBounds
            End Get
        End Property

        Public Sub AddRectangle(x As Single, y As Single, width As Single, height As Single)
            Call oPath.AddRectangle(New RectangleF(x, y, width, height))
        End Sub

        Public Sub AddRectangle(rect As RectangleF)
            Call oPath.AddRectangle(rect)
        End Sub

        Public Sub AddPie(x As Single, y As Single, width As Single, height As Single, startAngle As Single, sweepAngle As Single)
            Call oPath.AddPie(x, y, width, height, startAngle, sweepAngle)
        End Sub

        Public Sub AddPie(rect As RectangleF, startAngle As Single, sweepAngle As Single)
            Call AddPie(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle)
        End Sub

        Public Sub AddEllipse(x As Single, y As Single, width As Single, height As Single)
            Call oPath.AddEllipse(x, y, width, height)
        End Sub

        Public Sub AddEllipse(rect As RectangleF)
            Call oPath.AddEllipse(rect)
        End Sub

        Public Sub AddBeziers(points As PointF())
            Call oPath.AddBeziers(points)
        End Sub

        Public Sub AddBezier(pt1 As PointF, pt2 As PointF, pt3 As PointF, pt4 As PointF)
            Call oPath.AddBezier(pt1, pt2, pt3, pt4)
        End Sub

        Public Sub AddLines(points As PointF())
            Call oPath.AddLines(points)
        End Sub

        Public Sub AddLine(pt1 As PointF, pt2 As PointF)
            Call oPath.AddLine(pt1, pt2)
        End Sub

        Public Sub CloseFigure()
            Call oPath.CloseFigure()
        End Sub

        Public Sub StartFigure()
            Call oPath.StartFigure()
        End Sub

        Public Sub New(Brush As cPatternBrush, Bounds As RectangleF)
            oBrush = Brush
            oBounds = Bounds
            oPath = New GraphicsPath
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    Call oPath.Dispose()
                End If
                disposedValue = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class

    Public Class cPatternBrushParameterBaseCollection
        Inherits KeyedCollection(Of String, cPatternBrushParameterBase)

        Public Sub New()
            Call MyBase.New(StringComparer.OrdinalIgnoreCase)
        End Sub

        Protected Overrides Function GetKeyForItem(ByVal item As cPatternBrushParameterBase) As String
            Return item.Name
        End Function
    End Class

    ''' <summary>
    ''' Pattern brush from file with base code and parameters
    ''' </summary>
    Public Class cPatternBrushBase
        Private iID As Integer
        Private sName As String
        Private sCaption As String
        Private sTooltip As String
        Private oClass As Object
        Private oParameters As cPatternBrushParameterBaseCollection

        Friend Sub OnPaint(Painter As cPatternBrushPainter)
            Call oClass.DefaultInstance.onpaint(Painter)
        End Sub

        Public ReadOnly Property ID As Integer
            Get
                Return iID
            End Get
        End Property

        Public ReadOnly Property Parameters As cPatternBrushParameterBaseCollection
            Get
                Return oParameters
            End Get
        End Property

        Public ReadOnly Property Tooltip
            Get
                Return sTooltip
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return sCaption
        End Function

        Public ReadOnly Property Caption
            Get
                Return sCaption
            End Get
        End Property

        Public ReadOnly Property Name
            Get
                Return sName
            End Get
        End Property

        Friend Sub New(XMLPattern As XmlElement)
            iID = XMLPattern.GetAttribute("id")
            sName = XMLPattern.GetAttribute("name")
            Dim oLocalizedStrings As cLocalizedStrings = modXML.GetLocalizedStrings(XMLPattern)
            sCaption = oLocalizedStrings.Caption
            sTooltip = oLocalizedStrings.Tooltip
            oParameters = New cPatternBrushParameterBaseCollection
            If modXML.ChildElementExist(XMLPattern, "parameters") Then
                For Each oXmlParameter As XmlElement In XMLPattern.Item("parameters")
                    Dim oParameterLocalizedStrings As cLocalizedStrings = modXML.GetLocalizedStrings(oXmlParameter)
                    Dim sParameterCaption As String = oParameterLocalizedStrings.Caption
                    Dim sParameterTooltip As String = oParameterLocalizedStrings.Tooltip
                    Select Case oXmlParameter.GetAttribute("type")
                        Case "boolean"
                            Dim oParameter As cPatternBrushParameterBoolean = New cPatternBrushParameterBoolean(oXmlParameter.GetAttribute("name"), sParameterCaption, sParameterTooltip, oXmlParameter.GetAttribute("default"))
                            Call oParameters.Add(oParameter)
                        Case "single"
                            Dim oParameter As cPatternBrushParameterSingle = New cPatternBrushParameterSingle(oXmlParameter.GetAttribute("name"), sParameterCaption, sParameterTooltip, oXmlParameter.GetAttribute("default"), oXmlParameter.GetAttribute("min"), oXmlParameter.GetAttribute("max"))
                            Call oParameters.Add(oParameter)
                        Case "string"
                            Dim oParameter As cPatternBrushParameterString = New cPatternBrushParameterString(oXmlParameter.GetAttribute("name"), sParameterCaption, sParameterTooltip, oXmlParameter.GetAttribute("default"))
                            Call oParameters.Add(oParameter)
                    End Select
                Next
            End If
            Dim oXmlCode As XmlElement = XMLPattern("code")
            oClass = New cClass(Nothing, sName.Replace(" ", "_"), oXmlCode.InnerText, If(oXmlCode.GetAttribute("lang") = "vb#", LanguageEnum.VisualBasic, LanguageEnum.CSharp))
        End Sub
    End Class

    Public Class cPatternBrushBaseCollection
        Inherits KeyedCollection(Of Integer, cPatternBrushBase)

        Protected Overrides Function GetKeyForItem(ByVal item As cPatternBrushBase) As Integer
            Return item.ID
        End Function
    End Class

    ''' <summary>
    ''' Helper class for patter brush management
    ''' </summary>
    Public Class cPatternBrushHelper
        Private Shared oItems As cPatternBrushBaseCollection

        Public Shared Function GetGallery() As cPatternBrushBaseCollection
            If oItems Is Nothing Then
                oItems = New cPatternBrushBaseCollection
                For Each sFilename As String In My.Computer.FileSystem.GetFiles(IO.Path.Combine(IO.Path.Combine(modMain.GetApplicationPath, "objects"), "patterns"), FileIO.SearchOption.SearchTopLevelOnly, {"*.xml"})
                    Dim oXML As XmlDocument = New XmlDocument
                    oXML.Load(sFilename)
                    If oXML.DocumentElement.Name = "pattern" Then
                        Dim oPatternBrushBase = New cPatternBrushBase(oXML.DocumentElement)
                        Call oItems.Add(oPatternBrushBase)
                    Else
                        For Each oXMLPattern As XmlElement In oXML.DocumentElement.SelectNodes("pattern")
                            Dim oPatternBrushBase = New cPatternBrushBase(oXMLPattern)
                            Call oItems.Add(oPatternBrushBase)
                        Next
                    End If
                Next
            End If
            Return oItems
        End Function
    End Class

    Public Interface cIPatternBrush
        Property PatternType As cBrush.PatternTypeEnum
        Property PatternPenStyle As cPen.PenStylesEnum
        Property PatternAngleMode As cBrush.PatternAngleModeEnum
        Property PatternAngle As Single
        Property PatternDensity As Single
        Property PatternZoomFactor As Single

        Property PatternDeltaX As Single
        Property PatternDeltaY As Single

        Function GetPatternInstance() As Object
    End Interface

    Public Class cPatternBrushes
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private oItems As List(Of cPatternBrush)

        Friend Event OnInvalidate(Sender As Object, e As EventArgs)

        Public Function Count() As Integer
            Return oItems.Count
        End Function

        Public ReadOnly Property [Default] As cPatternBrush
            Get
                Return oItems(0)
            End Get
        End Property

        Friend Function Clone() As cPatternBrushes
            Dim oClone As cPatternBrushes = New cPatternBrushes(oSurvey)
            oClone.oItems.Clear()
            For Each oItem As cPatternBrush In oItems
                Dim oNewItem As cPatternBrush = oItem.Clone
                AddHandler oNewItem.OnGetIndex, AddressOf oClone.oItem_OnGetIndex
                AddHandler oNewItem.OnInvalidate, AddressOf oClone.oItem_OnInvalidate
                oClone.oItems.Add(oNewItem)
            Next
            Return oClone
        End Function

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cPatternBrush)
            Dim oItem As cPatternBrush = New cPatternBrush(oSurvey)
            Call oItems.Add(oItem)
            AddHandler oItem.OnGetIndex, AddressOf oItem_OnGetIndex
            AddHandler oItem.OnInvalidate, AddressOf oItem_OnInvalidate
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal item As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cPatternBrush)
            Dim oItem As cPatternBrush = New cPatternBrush(oSurvey, File, item)
            Call oItems.Add(oItem)
            AddHandler oItem.OnGetIndex, AddressOf oItem_OnGetIndex
            AddHandler oItem.OnInvalidate, AddressOf oItem_OnInvalidate
            If modXML.ChildElementExist(item, "patternbrushes") Then
                For Each oChildItem As XmlElement In item("patternbrushes").ChildNodes
                    oItem = New cPatternBrush(oSurvey, File, oChildItem)
                    Call oItems.Add(oItem)
                    AddHandler oItem.OnGetIndex, AddressOf oItem_OnGetIndex
                    AddHandler oItem.OnInvalidate, AddressOf oItem_OnInvalidate
                Next
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLItems As XmlElement
            Dim iIndex As Integer = 0
            For Each oItem As cPatternBrush In oItems
                Dim oXMLItem As XmlElement
                If iIndex = 0 Then
                    oXMLItem = Parent
                Else
                    If oXMLItems Is Nothing Then
                        oXMLItems = Document.CreateElement("patternbrushes")
                        Call Parent.AppendChild(oXMLItems)
                    End If
                    oXMLItem = Document.CreateElement("patternbrush")
                    Call oXMLItems.AppendChild(oXMLItem)
                End If
                Call oXMLItem.SetAttribute("patterntype", oItem.PatternType.ToString("D"))
                Call oXMLItem.SetAttribute("patternpenstyle", oItem.PatternPenStyle.ToString("D"))
                Call oXMLItem.SetAttribute("patterndensity", modNumbers.NumberToString(oItem.PatternDensity))
                Call oXMLItem.SetAttribute("patternzoomfactor", modNumbers.NumberToString(oItem.PatternZoomFactor, "0.0000"))
                Call oXMLItem.SetAttribute("patternanglemode", oItem.PatternAngleMode.ToString("D"))
                Call oXMLItem.SetAttribute("patternangle", modNumbers.NumberToString(oItem.PatternAngle))

                If oItem.PatternDeltaX <> 0 Then Call oXMLItem.SetAttribute("patterndx", modNumbers.NumberToString(oItem.PatternDeltaX))
                If oItem.PatternDeltaY <> 0 Then Call oXMLItem.SetAttribute("patterndy", modNumbers.NumberToString(oItem.PatternDeltaY))

                Dim oXmlParametersCollection As XmlElement = Document.CreateElement("parameters")
                Dim oParameterValues As Dictionary(Of String, Object) = oItem.GetParameterValues
                For Each sName As String In oParameterValues.Keys
                    Dim oValue As Object = oParameterValues(sName)
                    Dim sType As String = oValue.GetType.Name
                    Dim oXmlParameterCollectionItem As XmlElement = Document.CreateElement("item")
                    Call oXmlParameterCollectionItem.SetAttribute("name", sName)
                    Call oXmlParameterCollectionItem.SetAttribute("type", sType)
                    Select Case sType.ToLower
                        Case "color"
                            Dim oValueColor As Color = oValue
                            oXmlParameterCollectionItem.InnerText = oValueColor.ToArgb
                        Case "single", "double", "decimal"
                            oXmlParameterCollectionItem.InnerText = modNumbers.NumberToString(oValue, "")
                        Case Else
                            oXmlParameterCollectionItem.InnerText = oValue
                    End Select
                    Call oXmlParametersCollection.AppendChild(oXmlParameterCollectionItem)
                Next
                Call oXMLItem.AppendChild(oXmlParametersCollection)

                iIndex += 1
            Next
            Return oXMLItems
        End Function

        Default Public ReadOnly Property Item(Index As Integer) As cPatternBrush
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function Append() As cPatternBrush
            Dim oItem As cPatternBrush = New cPatternBrush(oSurvey)
            Call oItems.Add(oItem)
            AddHandler oItem.OnGetIndex, AddressOf oItem_OnGetIndex
            AddHandler oItem.OnInvalidate, AddressOf oItem_OnInvalidate
            RaiseEvent OnInvalidate(Me, EventArgs.Empty)
            Return oItem
        End Function

        Public Function Remove(Index As Integer) As Boolean
            If Index > 0 AndAlso Index < oItems.Count Then
                Dim oItem As cPatternBrush = oItems(Index)
                RemoveHandler oItem.OnGetIndex, AddressOf oItem_OnGetIndex
                RemoveHandler oItem.OnInvalidate, AddressOf oItem_OnInvalidate
                Call oItems.RemoveAt(Index)
                RaiseEvent OnInvalidate(Me, EventArgs.Empty)
                Return True
            Else
                Throw New IndexOutOfRangeException
            End If
        End Function

        Public Sub MoveTo(ByVal Index As Integer, ByVal PatternBrush As cPatternBrush)
            If oItems.Contains(PatternBrush) AndAlso oItems.IndexOf(PatternBrush) <> Index AndAlso Index >= 0 AndAlso Index < oItems.Count Then
                Call oItems.Remove(PatternBrush)
                Call oItems.Insert(Index, PatternBrush)
                RaiseEvent OnInvalidate(Me, EventArgs.Empty)
            End If
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function IndexOf(Item As cPatternBrush) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Private Sub oItem_OnGetIndex(Sender As Object, e As cPatternBrush.cGetIndexEventArgs)
            e.Index = oItems.IndexOf(Sender)
        End Sub

        Private Sub oItem_OnInvalidate(Sender As Object, e As EventArgs)
            RaiseEvent OnInvalidate(Me, e)
        End Sub
    End Class

    Public Class cPatternBrush
        Implements cIPatternBrush

        Private oSurvey As cSurvey

        Private iPatternType As cBrush.PatternTypeEnum
        Private iPatternPenStyle As cPen.PenStylesEnum
        Private iPatternAngleMode As cBrush.PatternAngleModeEnum
        Private sPatternAngle As Single
        Private sPatternDensity As Single
        Private sPatternZoomFactor As Single
        Private sPatternDeltaX As Single
        Private sPatternDeltaY As Single

        Private WithEvents oPatternBrushInstance As cPatternBrushInstance

        Friend Class cGetIndexEventArgs
            Inherits EventArgs

            Public Index As Integer
        End Class

        Friend Event OnGetIndex(Sender As Object, e As cGetIndexEventArgs)
        Friend Event OnInvalidate(Sender As Object, e As EventArgs)

        'Public Sub SetParameters(Parameters As Dictionary(Of String, Object))
        '    Call oPatternBrushInstance.FromDictionary(Parameters)
        'End Sub
        Friend Sub OnPaint(Painter As cPatternBrushPainter)
            oPatternBrushInstance.Base.OnPaint(Painter)
        End Sub

        Friend Function GetParameterValues() As Dictionary(Of String, Object)
            Return oPatternBrushInstance.ParameterValues
        End Function

        Public Sub SetParameterValue(Name As String, Value As Object)
            Call oPatternBrushInstance.SetParameterValue(Name, Value)
        End Sub

        Public Function GetParameterValue(Name As String) As Object
            Return oPatternBrushInstance.GetParameterValue(Name)
        End Function

        Public Function GetParameterDefinitions() As cPatternBrushParameterBaseCollection
            Return oPatternBrushInstance.Base.Parameters
        End Function

        Public Function GetParameterDefinition(Name As String) As cPatternBrushParameterBase
            Return oPatternBrushInstance.Base.Parameters(Name)
        End Function

        Public Function GetInstance() As Object Implements cIPatternBrush.GetPatternInstance
            Return oPatternBrushInstance
        End Function

        Public Function GetIndex() As Integer
            Dim oArgs As cGetIndexEventArgs = New cGetIndexEventArgs
            RaiseEvent OnGetIndex(Me, oArgs)
            Return oArgs.Index
        End Function

        Friend Function Clone() As cPatternBrush
            Dim oClone As cPatternBrush = New cPatternBrush(oSurvey)
            oClone.iPatternType = iPatternType
            oClone.iPatternPenStyle = iPatternPenStyle
            oClone.iPatternAngleMode = iPatternAngleMode
            oClone.sPatternAngle = sPatternAngle
            oClone.sPatternDensity = sPatternDensity
            oClone.sPatternZoomFactor = sPatternZoomFactor
            oClone.sPatternDeltaX = sPatternDeltaX
            oClone.sPatternDeltaY = sPatternDeltaY
            oClone.oPatternBrushInstance = New cPatternBrushInstance(oPatternBrushInstance)
            Return oClone
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey

            oPatternBrushInstance = New cPatternBrushInstance(iPatternType)

            If sPatternDensity <= 0 Then sPatternDensity = 1.0F
            If sPatternZoomFactor <= 0 Then sPatternZoomFactor = 1.0F

            Call Invalidate()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal item As XmlElement)
            oSurvey = Survey

            iPatternType = modXML.GetAttributeValue(item, "patterntype")
            oPatternBrushInstance = New cPatternBrushInstance(iPatternType)

            iPatternPenStyle = modXML.GetAttributeValue(item, "patternpenstyle")
            iPatternAngleMode = modXML.GetAttributeValue(item, "patternanglemode")
            sPatternDensity = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "patterndensity", modXML.GetAttributeValue(item, "clipartdensity")))
            sPatternZoomFactor = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "patternzoomfactor", 1.0F))
            sPatternAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "patternangle", modXML.GetAttributeValue(item, "clipartangle")))

            sPatternDeltaX = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "patterndx", 0F))
            sPatternDeltaY = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "patterndy", 0F))

            If sPatternDensity <= 0 Then sPatternDensity = 1.0F
            If sPatternZoomFactor <= 0 Then sPatternZoomFactor = 1.0F

            If modXML.ChildElementExist(item, "parameters") Then
                For Each oXMLItem As XmlElement In item("parameters").ChildNodes
                    Dim sName As String = oXMLItem.GetAttribute("name")
                    Dim sType As String = oXMLItem.GetAttribute("type")
                    Dim sValue As String = oXMLItem.InnerText
                    Dim oValue As Object
                    Select Case sType.ToLower
                        Case "color"
                            If IsNumeric(sValue) Then
                                oValue = Color.FromArgb(sValue)
                            Else
                                If sValue.StartsWith("#") Then
                                    oValue = ColorTranslator.FromHtml(sValue)
                                Else
                                    oValue = Color.FromName(sValue)
                                End If
                            End If
                        Case "single"
                            oValue = modNumbers.StringToSingle(sValue)
                            'Dim bScalable As String = If(oXMLItem.HasAttribute("scalable"), oXMLItem.GetAttribute("scalable"), True)
                            'If bScalable Then oValue = oValue * sPatternZoomFactor
                        Case "double"
                            oValue = modNumbers.StringToDouble(sValue)
                            'Dim bScalable As String = If(oXMLItem.HasAttribute("scalable"), oXMLItem.GetAttribute("scalable"), True)
                            'If bScalable Then oValue = oValue * sPatternZoomFactor
                        Case "integer"
                            oValue = CInt(sValue)
                            'Dim bScalable As String = If(oXMLItem.HasAttribute("scalable"), oXMLItem.GetAttribute("scalable"), True)
                            'If bScalable Then oValue = oValue * sPatternZoomFactor
                        Case "decimal"
                            oValue = CDec(modNumbers.StringToDecimal(sValue))
                            'Dim bScalable As String = If(oXMLItem.HasAttribute("scalable"), oXMLItem.GetAttribute("scalable"), True)
                            'If bScalable Then oValue = oValue * sPatternZoomFactor
                        Case "long"
                            oValue = CLng(sValue)
                            'Dim bScalable As String = If(oXMLItem.HasAttribute("scalable"), oXMLItem.GetAttribute("scalable"), True)
                            'If bScalable Then oValue = oValue * sPatternZoomFactor
                        Case Else
                            oValue = sValue
                    End Select
                    oPatternBrushInstance.SetParameterValue(sName, oValue)
                Next
            End If

            Call Invalidate()
        End Sub

        Public Sub Invalidate()
            RaiseEvent OnInvalidate(Me, EventArgs.Empty)
        End Sub

        Private Sub oPatternBrushInstance_OnChanged(sender As Object, e As EventArgs) Handles oPatternBrushInstance.OnChanged
            Call Invalidate()
        End Sub

        Public Property PatternDeltaX() As Single Implements cIPatternBrush.PatternDeltaX
            Get
                Return sPatternDeltaX
            End Get
            Set(ByVal value As Single)
                If sPatternDeltaX <> value Then
                    sPatternDeltaX = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternDeltaY() As Single Implements cIPatternBrush.PatternDeltaY
            Get
                Return sPatternDeltaY
            End Get
            Set(ByVal value As Single)
                If sPatternDeltaY <> value Then
                    sPatternDeltaY = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternZoomFactor() As Single Implements cIPatternBrush.PatternZoomFactor
            Get
                Return sPatternZoomFactor
            End Get
            Set(ByVal value As Single)
                If sPatternZoomFactor <> value And sPatternZoomFactor > 0 Then
                    sPatternZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternAngleMode() As cBrush.PatternAngleModeEnum Implements cIPatternBrush.PatternAngleMode
            Get
                Return iPatternAngleMode
            End Get
            Set(ByVal value As cBrush.PatternAngleModeEnum)
                If iPatternAngleMode <> value Then
                    iPatternAngleMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternDensity() As Single Implements cIPatternBrush.PatternDensity
            Get
                Return sPatternDensity
            End Get
            Set(ByVal value As Single)
                If sPatternDensity <> value Then
                    sPatternDensity = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternAngle() As Single Implements cIPatternBrush.PatternAngle
            Get
                Return sPatternAngle
            End Get
            Set(ByVal value As Single)
                If sPatternAngle <> value Then
                    sPatternAngle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternPenStyle() As cPen.PenStylesEnum Implements cIPatternBrush.PatternPenStyle
            Get
                Return iPatternPenStyle
            End Get
            Set(ByVal value As cPen.PenStylesEnum)
                If iPatternPenStyle <> value Then
                    iPatternPenStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternType() As cBrush.PatternTypeEnum Implements cIPatternBrush.PatternType
            Get
                Return iPatternType
            End Get
            Set(ByVal value As cBrush.PatternTypeEnum)
                If iPatternType <> value Then
                    iPatternType = value
                    oPatternBrushInstance = New cPatternBrushInstance(iPatternType)
                    Call Invalidate()
                End If
            End Set
        End Property
    End Class

    Public Class cCustomBrush
        Implements IDisposable
        Implements cIPatternBrush
        Implements cICustomPaintElement

        Private WithEvents oSurvey As cSurvey

        Private sID As String

        Private sFilename As String

        Private sName As String
        Private iType As cBrush.BrushTypeEnum

        Private iHatchType As cBrush.HatchTypeEnum

        Private oColor As Color
        Private oAlternativeColor As Color
        Private oBackgroundColor As Color

        Private oTexture As Image
        Private sTextureID As String
        Private iTextureWrapMode As System.Drawing.Drawing2D.WrapMode

        Private oClipart As cDrawClipArt
        Private sClipartDensity As Single
        Private sClipartZoomFactor As Single
        Private iClipartAngleMode As cBrush.ClipartAngleModeEnum
        Private sClipartAngle As Single
        Private iClipartCrop As cBrush.ClipartCropEnum
        Private iClipartPosition As cBrush.ClipartPositionEnum
        Private oClipartAlternativeColor As Color
        Private oClipartAlternativeBrush1 As SolidBrush
        Private oClipartAlternativeBrush2 As SolidBrush
        Private oTextureBrush As TextureBrush

        Private oPen As Pen
        Private oBrush As SolidBrush
        Private oBackgroundBrush As SolidBrush
        Private oSchematicBrush As HatchBrush

        Private WithEvents oPatternBrushes As cPatternBrushes

        Private oPatternPens As List(Of Pen)
        'Private iPatternType As cBrush.PatternTypeEnum
        'Private iPatternPenStyle As cPen.PenStylesEnum
        'Private iPatternAngleMode As cBrush.PatternAngleModeEnum
        'Private sPatternAngle As Single
        'Private sPatternDensity As Single
        'Private sPatternZoomFactor As Single

        Private sLocalLineWidth As Single
        Private sLocalZoomFactor As Single

        Private bInvalidated As Boolean

        Friend Event OnChanged(ByVal Sender As Object, e As EventArgs)

        Friend Event OnRender(sender As Object, RenderArgs As cBrush.cRenderEventArgs)

        Public Function GetThumbnailSVG(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As XmlDocument Implements cICustomPaintElement.GetThumbnailSVG
            Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
            Dim oSVG As XmlDocument = modSVG.CreateSVG("", New Size(thumbWidth, thumbHeight), SizeUnit.pixel, oBounds, SVGCreateFlagsEnum.None)
            Using oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Using oGr As Graphics = Graphics.FromImage(oImage)
                    Using oBackgroundBrush As SolidBrush = New SolidBrush(Backcolor)
                        Using oForegroundPen As Pen = New Pen(ForeColor, 1)
                            oForegroundPen.LineJoin = Drawing2D.LineJoin.Miter
                            Call oGr.FillRectangle(oBackgroundBrush, oBounds)
                            Dim sZoom As Single = 0.1F
                            Using oPath As GraphicsPath = New GraphicsPath
                                Dim oBrushRect As RectangleF = New RectangleF(oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
                                Call oPath.AddRectangle(oBrushRect)
                                Using oMatrix As Matrix = New Matrix
                                    Call oMatrix.Scale(sZoom, sZoom)
                                    Call oPath.Transform(oMatrix)
                                End Using
                                Call oGr.ScaleTransform(1.0F / sZoom, 1.0F / sZoom)
                                Using oCache As cDrawCache = New cDrawCache
                                    Using oMatrix As Matrix = New Matrix
                                        Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                                        oMatrix.Scale(10.0F, 10.0F)
                                        oCache.Trasform(oMatrix)
                                        Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)
                                        Call modSVG.AppendRectangle(oSVG, oSVG.DocumentElement, oBounds, oBackgroundBrush, Nothing)
                                        Call oSVG.DocumentElement.AppendChild(oCache.ToSvgItem(oSVG, PaintOptions, cItem.SVGOptionsEnum.ClipartBrushes))
                                        Call modSVG.AppendRectangle(oSVG, oSVG.DocumentElement, oBounds, Nothing, oForegroundPen)
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
            Return oSVG
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Try
                Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
                Dim oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                Using oGr As Graphics = Graphics.FromImage(oImage)
                    oGr.SmoothingMode = SmoothingMode.AntiAlias
                    oGr.CompositingQuality = CompositingQuality.HighQuality
                    oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    Using oBackBrush As SolidBrush = New SolidBrush(Backcolor)
                        Call oGr.FillRectangle(oBackBrush, oBounds)
                        Dim sZoom As Single = 0.1
                        Using oPath As GraphicsPath = New GraphicsPath
                            Dim oBrushRect As RectangleF = New RectangleF(oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height)
                            Call oPath.AddRectangle(oBrushRect)
                            Using oMatrix As Matrix = New Matrix
                                Call oMatrix.Scale(sZoom, sZoom)
                                Call oPath.Transform(oMatrix)
                            End Using
                            Call oGr.ScaleTransform(1 / sZoom, 1 / sZoom)
                            Using oCache As cDrawCache = New cDrawCache
                                Call Invalidate()
                                Call Render(oGr, PaintOptions, cItem.PaintOptionsEnum.None, False, oPath, oCache)
                                Call oCache.Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None)
                            End Using
                        End Using
                    End Using
                End Using
                Return oImage
            Catch
                Return Nothing
            End Try
        End Function

        Public ReadOnly Property IsWriteable As Boolean
            Get
                Return iType = cBrush.BrushTypeEnum.User OrElse iType = cBrush.BrushTypeEnum.Custom
            End Get
        End Property

        ''' <summary>
        ''' Get the user ID of this brush even if is not a user brush
        ''' </summary>
        ''' <returns></returns>
        Public Function GetID() As String
            If iType = BrushTypeEnum.User Then
                Return sID
            Else
                Return CalculateHash(Me)
            End If
        End Function

        Public Property ID As String Implements cICustomPaintElement.ID
            Get
                If iType = cBrush.BrushTypeEnum.User Then
                    Return sID
                Else
                    Return "_" & iType.ToString("D")
                End If
            End Get
            Set(value As String)
                If value Is Nothing Then
                    Throw New Exception("Brush ID cannot be Nothing")
                Else
                    If value.StartsWith("_") Then
                        Dim iType As cBrush.BrushTypeEnum = Integer.Parse(value.Substring(1))
                        sID = ""
                        CopyFrom(oSurvey.Brushes.FromType(iType))
                    Else
                        CopyFrom(oSurvey.Brushes(value))
                    End If
                End If
            End Set
        End Property


        ''' <summary>
        ''' Get filename if userbrush loaded from disk
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Filename() As String Implements cICustomPaintElement.filename
            Get
                Return sFilename
            End Get
        End Property

        Public Property Name() As String Implements cICustomPaintElement.Name
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                If sName <> value Then
                    'iType = cBrush.BrushTypeEnum.Custom
                    sName = value
                End If
            End Set
        End Property

        Friend Property LocalZoomFactor As Single
            Get
                Return sLocalZoomFactor
            End Get
            Set(ByVal value As Single)
                If sLocalZoomFactor <> value Then
                    sLocalZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend Property LocalLineWidth As Single
            Get
                Return sLocalLineWidth
            End Get
            Set(ByVal value As Single)
                If sLocalLineWidth <> value Then
                    sLocalLineWidth = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Sub CopyFrom(ByVal Brush As cCustomBrush)
            sName = Brush.sName

            iType = Brush.iType
            oColor = Brush.oColor
            oBackgroundColor = Brush.oBackgroundColor
            iHatchType = Brush.iHatchType

            If IsNothing(Brush.oClipart) Then
                oClipart = Nothing
            Else
                oClipart = Brush.oClipart.Clone
            End If
            sClipartDensity = Brush.sClipartDensity
            sClipartZoomFactor = Brush.sClipartZoomFactor
            iClipartAngleMode = Brush.iClipartAngleMode
            sClipartAngle = Brush.sClipartAngle
            iClipartCrop = Brush.iClipartCrop
            iClipartPosition = Brush.iClipartPosition
            oClipartAlternativeColor = Brush.oClipartAlternativeColor

            oTexture = Brush.oTexture
            iTextureWrapMode = Brush.iTextureWrapMode

            oPatternBrushes = If(Brush.oPatternBrushes Is Nothing, New cPatternBrushes(oSurvey), Brush.oPatternBrushes.Clone)
            'oPatternPen = Brush.oPatternPen
            'iPatternType = Brush.iPatternType
            'iPatternPenStyle = Brush.iPatternPenStyle
            'iPatternAngleMode = Brush.iPatternAngleMode
            'sPatternZoomFactor = Brush.sPatternZoomFactor

            sLocalLineWidth = Brush.sLocalLineWidth
            Call Invalidate()
        End Sub

        Public Property HatchType() As cBrush.HatchTypeEnum
            Get
                Return iHatchType
            End Get
            Set(ByVal value As cBrush.HatchTypeEnum)
                If iHatchType <> value Then
                    iHatchType = value
                    If iHatchType <> cBrush.HatchTypeEnum.Texture Then
                        oTexture = Nothing
                        sTextureID = ""
                    End If
                    If iHatchType <> cBrush.HatchTypeEnum.Clipart Then
                        oClipart = Nothing
                    End If
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend ReadOnly Property Pen As Pen
            Get
                Return oPen
            End Get
        End Property

        Friend ReadOnly Property Brush As Brush
            Get
                Return oBrush
            End Get
        End Property

        Public Function GetPatternInstance() As Object Implements cIPatternBrush.GetPatternInstance
            Return oPatternBrushes.Default.GetInstance
        End Function

        Public Property PatternPenStyle() As cPen.PenStylesEnum Implements cIPatternBrush.PatternPenStyle
            Get
                Return oPatternBrushes.Default.PatternPenStyle
            End Get
            Set(ByVal value As cPen.PenStylesEnum)
                oPatternBrushes.Default.PatternPenStyle = value
            End Set
        End Property

        Public Property PatternType() As cBrush.PatternTypeEnum Implements cIPatternBrush.PatternType
            Get
                Return oPatternBrushes.Default.PatternType
            End Get
            Set(ByVal value As cBrush.PatternTypeEnum)
                oPatternBrushes.Default.PatternType = value
            End Set
        End Property

        Public Property ClipartPosition() As cBrush.ClipartPositionEnum
            Get
                Return iClipartPosition
            End Get
            Set(ByVal value As cBrush.ClipartPositionEnum)
                If iClipartPosition <> value Then
                    iClipartPosition = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartCrop() As cBrush.ClipartCropEnum
            Get
                Return iClipartCrop
            End Get
            Set(ByVal value As cBrush.ClipartCropEnum)
                If iClipartCrop <> value Then
                    iClipartCrop = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternDeltaX() As Single Implements cIPatternBrush.PatternDeltaX
            Get
                Return oPatternBrushes.Default.PatternDeltaX
            End Get
            Set(ByVal value As Single)
                oPatternBrushes.Default.PatternDeltaX = value
            End Set
        End Property

        Public Property PatternDeltaY() As Single Implements cIPatternBrush.PatternDeltaY
            Get
                Return oPatternBrushes.Default.PatternDeltaY
            End Get
            Set(ByVal value As Single)
                oPatternBrushes.Default.PatternDeltaY = value
            End Set
        End Property

        Public Property PatternAngle() As Single Implements cIPatternBrush.PatternAngle
            Get
                Return oPatternBrushes.Default.PatternAngle
            End Get
            Set(ByVal value As Single)
                oPatternBrushes.Default.PatternAngle = value
            End Set
        End Property

        Public Property ClipartAngle() As Single
            Get
                Return sClipartAngle
            End Get
            Set(ByVal value As Single)
                If sClipartAngle <> value Then
                    sClipartAngle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property TextureWrapmode() As System.Drawing.Drawing2D.WrapMode
            Get
                Return iTextureWrapMode
            End Get
            Set(ByVal value As System.Drawing.Drawing2D.WrapMode)
                If iTextureWrapMode <> value Then
                    iTextureWrapMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAngleMode() As cBrush.ClipartAngleModeEnum
            Get
                Return iClipartAngleMode
            End Get
            Set(ByVal value As cBrush.ClipartAngleModeEnum)
                If iClipartAngleMode <> value Then
                    iClipartAngleMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternAngleMode() As cBrush.PatternAngleModeEnum Implements cIPatternBrush.PatternAngleMode
            Get
                Return oPatternBrushes.Default.PatternAngleMode
            End Get
            Set(ByVal value As cBrush.PatternAngleModeEnum)
                oPatternBrushes.Default.PatternAngle = value
            End Set
        End Property

        Public Property PatternDensity() As Single Implements cIPatternBrush.PatternDensity
            Get
                Return oPatternBrushes.Default.PatternDensity
            End Get
            Set(ByVal value As Single)
                oPatternBrushes.Default.PatternDensity = value
            End Set
        End Property

        Public Property ClipartDensity() As Single
            Get
                Return sClipartDensity
            End Get
            Set(ByVal value As Single)
                If sClipartDensity <> value And sClipartDensity > 0 Then
                    sClipartDensity = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartZoomFactor() As Single
            Get
                Return sClipartZoomFactor
            End Get
            Set(ByVal value As Single)
                If sClipartZoomFactor <> value And sClipartZoomFactor > 0 Then
                    sClipartZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternZoomFactor() As Single Implements cIPatternBrush.PatternZoomFactor
            Get
                Return oPatternBrushes.Default.PatternZoomFactor
            End Get
            Set(ByVal value As Single)
                oPatternBrushes.Default.PatternZoomFactor = value
            End Set
        End Property

        Public Property Texture() As Image
            Get
                Return oTexture
            End Get
            Set(ByVal Value As Image)
                If Not oTexture Is Value Then
                    sTextureID = Guid.NewGuid.ToString
                    oTexture = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Clipart() As cDrawClipArt
            Get
                Return oClipart
            End Get
            Set(ByVal Value As cDrawClipArt)
                If Not oClipart Is Value Then
                    oClipart = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Type() As cBrush.BrushTypeEnum
            Get
                Return iType
            End Get
            'Set(ByVal value As BrushTypeEnum)
            '    If iType <> value Then
            '        If iType <> BrushTypeEnum.Custom AndAlso value = BrushTypeEnum.Custom Then
            '            Call CopyFrom(oSurvey.EditPaintObjects.Brushes.FromType(iType))
            '        Else
            '            Call CopyFrom(oSurvey.EditPaintObjects.Brushes.FromType(value))
            '        End If
            '        iType = value
            '    End If
            'End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Brush As cCustomBrush)
            oSurvey = Survey
            Call CopyFrom(Brush)
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Type As cBrush.BrushTypeEnum)
            oSurvey = Survey
            Call CopyFrom(Survey.EditPaintObjects.Brushes.FromType(iType))
            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String, ByVal Type As cBrush.BrushTypeEnum, ByVal Color As Color, Optional ByVal HatchType As cBrush.HatchTypeEnum = cBrush.HatchTypeEnum.None, Optional ByVal Clipart As cDrawClipArt = Nothing, Optional ByVal ClipartDensity As Single = 1, Optional ByVal ClipartZoomFactor As Single = 1, Optional ClipartAlternativeColor As Color = Nothing, Optional ClipartAngleMode As cBrush.ClipartAngleModeEnum = cBrush.ClipartAngleModeEnum.Random, Optional ClipartAngle As Single = 0F, Optional ClipartCrop As cBrush.ClipartCropEnum = cBrush.ClipartCropEnum.Full, Optional ClipartPosition As cBrush.ClipartPositionEnum = cBrush.ClipartPositionEnum.Random)
            oSurvey = Survey

            sName = Name
            iType = Type
            oColor = Color
            iHatchType = HatchType

            oClipart = Clipart
            sClipartDensity = ClipartDensity
            If sClipartDensity <= 0 Then sClipartDensity = 1
            sClipartZoomFactor = ClipartZoomFactor
            If sClipartZoomFactor <= 0 Then sClipartZoomFactor = 1
            oClipartAlternativeColor = ClipartAlternativeColor
            iClipartAngleMode = ClipartAngleMode
            sClipartAngle = ClipartAngle
            iClipartCrop = ClipartCrop
            iClipartPosition = ClipartPosition

            oPatternBrushes = New cPatternBrushes(oSurvey)

            bInvalidated = True
        End Sub

        Public ReadOnly Property PatternBrushes As cPatternBrushes
            Get
                If oPatternBrushes Is Nothing Then
                    oPatternBrushes = New cPatternBrushes(oSurvey)
                End If
                Return oPatternBrushes
            End Get
        End Property

        Public Shared Function CalculateHash(Brush As cCustomBrush) As String
            Using oMs As MemoryStream = New MemoryStream
                Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                    Dim oXML As XmlDocument = oFile.Document
                    Dim oXMLRoot As XmlElement = oXML.CreateElement("cbrush")
                    Dim oXMLItem As XmlElement = Brush.SaveTo(oFile, oXML, oXMLRoot)
                    'hash is calculate without name and type
                    Call oXMLItem.RemoveAttribute("type")
                    Call oXMLItem.RemoveAttribute("name")
                    Call oXMLItem.RemoveAttribute("id")
                    Call oXMLRoot.AppendChild(oXMLItem)
                    Call oXML.AppendChild(oXMLRoot)
                    Call oFile.SaveTo(oMs)
                    Return modMain.CalculateHash(oMs)
                End Using
            End Using
        End Function

        Friend Shared Function CopyAsCustom(Survey As cSurvey, ByVal Brush As cCustomBrush) As cCustomBrush
            Dim oNewBrush As cCustomBrush = New cCustomBrush(Survey, Brush)
            oNewBrush.iType = cBrush.BrushTypeEnum.Custom
            oNewBrush.sID = ""
            Return oNewBrush
        End Function

        Friend Shared Function CopyAsUser(Survey As cSurvey, ByVal Brush As cCustomBrush) As cCustomBrush
            Dim oNewBrush As cCustomBrush = New cCustomBrush(Survey, Brush)
            oNewBrush.iType = cBrush.BrushTypeEnum.User
            oNewBrush.sID = CalculateHash(oNewBrush)
            Return oNewBrush
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey

            iType = cBrush.BrushTypeEnum.Custom
            oColor = Color.LightGray
            HatchType = cBrush.HatchTypeEnum.None

            sClipartDensity = 1.0F
            sClipartZoomFactor = 1.0F
            oClipartAlternativeColor = Nothing

            oPatternBrushes = New cPatternBrushes(oSurvey)

            bInvalidated = True
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Filename As String)
            Call Me.New(Survey, Nothing, modXML.FromFile(Filename).DocumentElement.Item("brush"))
            sFilename = Filename
            sName = IO.Path.GetFileNameWithoutExtension(sFilename)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal item As XmlElement)
            oSurvey = Survey
            iType = modXML.GetAttributeValue(item, "type", cBrush.BrushTypeEnum.Custom)
            If iType = cPen.PenTypeEnum.User Then
                sID = item.GetAttribute("id")
            End If

            sName = modXML.GetAttributeValue(item, "name", "")
            oColor = modXML.GetAttributeColor(item, "color", Color.Black)
            oBackgroundColor = modXML.GetAttributeColor(item, "backgroundcolor", Color.Transparent)
            iHatchType = modXML.GetAttributeValue(item, "hatchtype")

            If iHatchType = cBrush.HatchTypeEnum.Texture Then
                sTextureID = modXML.GetAttributeValue(item, "textureid", Guid.NewGuid.ToString)
                If sTextureID = "" Then sTextureID = Guid.NewGuid.ToString
                Dim iFileFormat As cFile.FileFormatEnum = If(File Is Nothing, cFile.FileFormatEnum.CSX, File.FileFormat)
                Select Case iFileFormat
                    Case cFile.FileFormatEnum.CSX
                        oTexture = modPaint.ByteArrayToBitmap(Convert.FromBase64String(modXML.GetAttributeValue(item, "texture")))
                    Case cFile.FileFormatEnum.CSZ
                        Dim sImagePath As String = modXML.GetAttributeValue(item, "texture")
                        oTexture = modPaint.ByteArrayToBitmap(DirectCast(File.Data(sImagePath), Storage.cStorageItemFile).Stream.ToArray)
                End Select
                iTextureWrapMode = modXML.GetAttributeValue(item, "texturewrapmode")
                oPatternBrushes = New cPatternBrushes(oSurvey)
            ElseIf iHatchType = cBrush.HatchTypeEnum.Clipart Then
                Dim oXMLClipart As XmlElement = item.Item("clipart")
                If oXMLClipart Is Nothing Then
                    oClipart = New cDrawClipArt()
                Else
                    oClipart = New cDrawClipArt(oXMLClipart)
                End If
                sClipartDensity = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartdensity"))
                sClipartZoomFactor = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartzoomfactor", 1.0F))
                iClipartAngleMode = modXML.GetAttributeValue(item, "clipartanglemode")
                If iClipartAngleMode = cBrush.ClipartAngleModeEnum.Fixed Then
                    sClipartAngle = modNumbers.StringToSingle(modXML.GetAttributeValue(item, "clipartangle"))
                End If
                iClipartCrop = modXML.GetAttributeValue(item, "clipartcrop")
                iClipartPosition = modXML.GetAttributeValue(item, "clipartposition")
                oPatternBrushes = New cPatternBrushes(oSurvey)
                oClipartAlternativeColor = modXML.GetAttributeColor(item, "clipartalternativecolor", Drawing.Color.Gray)
            ElseIf iHatchType = cBrush.HatchTypeEnum.Pattern Then
                oPatternBrushes = New cPatternBrushes(oSurvey, File, item)
                oClipartAlternativeColor = modXML.GetAttributeColor(item, "clipartalternativecolor", Drawing.Color.Gray)
            End If

            If sClipartDensity <= 0 Then sClipartDensity = 1.0F
            If sClipartZoomFactor <= 0 Then sClipartZoomFactor = 1.0F

            Call Invalidate()
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("brush")
            Call oItem.SetAttribute("type", iType)
            If iType = cPen.PenTypeEnum.User Then
                Call oItem.SetAttribute("id", sID)
            End If

            If sName <> "" Then
                Call oItem.SetAttribute("name", sName)
            End If
            Call oItem.SetAttribute("color", oColor.ToArgb)
            Call oItem.SetAttribute("backgroundcolor", oBackgroundColor.ToArgb)
            Call oItem.SetAttribute("hatchtype", iHatchType)

            If iHatchType = cBrush.HatchTypeEnum.Texture Then
                If Not oTexture Is Nothing Then
                    Call oItem.SetAttribute("textureid", sTextureID)
                    If Not (File.Options And cFile.FileOptionsEnum.DontSaveBinary) = cFile.FileOptionsEnum.DontSaveBinary Then
                        Dim iFileFormat As cFile.FileFormatEnum = If(File Is Nothing, cFile.FileFormatEnum.CSX, File.FileFormat)
                        Select Case iFileFormat
                            Case cFile.FileFormatEnum.CSX
                                Call oItem.SetAttribute("texture", Convert.ToBase64String(modPaint.BitmapToByteArray(oTexture, Drawing.Imaging.ImageFormat.Png)))
                            Case cFile.FileFormatEnum.CSZ
                                Dim sImagePath As String = "_data\texture\" & sTextureID & ".png"
                                Dim oImageStorage As Storage.cStorageItemFile = File.Data.AddFile(sImagePath)
                                Call oImageStorage.Write(modPaint.BitmapToByteArray(oTexture, Drawing.Imaging.ImageFormat.Png))
                                Call oItem.SetAttribute("texture", sImagePath)
                        End Select
                    End If
                End If
                Call oItem.SetAttribute("texturewrapmode", iTextureWrapMode.ToString("D"))
            ElseIf iHatchType = cBrush.HatchTypeEnum.Clipart Then
                If Not oClipart Is Nothing Then Call oClipart.SaveTo(File, Document, oItem)
                Call oItem.SetAttribute("clipartdensity", modNumbers.NumberToString(sClipartDensity))
                Call oItem.SetAttribute("clipartzoomfactor", modNumbers.NumberToString(sClipartZoomFactor, "0.0000"))
                Call oItem.SetAttribute("clipartanglemode", iClipartAngleMode.ToString("D"))
                If iClipartAngleMode = cBrush.ClipartAngleModeEnum.Fixed Then
                    Call oItem.SetAttribute("clipartangle", modNumbers.NumberToString(sClipartAngle))
                End If
                If iClipartCrop <> cBrush.ClipartCropEnum.None Then
                    Call oItem.SetAttribute("clipartcrop", iClipartCrop.ToString("D"))
                End If
                If iClipartPosition <> cBrush.ClipartPositionEnum.Random Then
                    Call oItem.SetAttribute("clipartposition", iClipartPosition.ToString("D"))
                End If
                Call oItem.SetAttribute("clipartalternativecolor", oClipartAlternativeColor.ToArgb)
            ElseIf iHatchType = cBrush.HatchTypeEnum.Pattern Then
                Call oPatternBrushes.SaveTo(File, Document, oItem)
                'Call oItem.SetAttribute("patterntype", iPatternType.ToString("D"))
                'Call oItem.SetAttribute("patternpenstyle", iPatternPenStyle.ToString("D"))
                'Call oItem.SetAttribute("patterndensity", modNumbers.NumberToString(sPatternDensity))
                'Call oItem.SetAttribute("patternzoomfactor", modNumbers.NumberToString(sPatternZoomFactor, "0.0000"))
                'Call oItem.SetAttribute("patternanglemode", iPatternAngleMode.ToString("D"))
                'Call oItem.SetAttribute("patternangle", modNumbers.NumberToString(sPatternAngle))

                Call oItem.SetAttribute("clipartalternativecolor", oClipartAlternativeColor.ToArgb)
            End If

            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Public Property AlternativeColor() As Color
            Get
                Return oAlternativeColor
            End Get
            Set(ByVal value As Color)
                If oAlternativeColor <> value Then
                    oAlternativeColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property BackgroundColor() As Color
            Get
                Return oBackgroundColor
            End Get
            Set(ByVal value As Color)
                If oBackgroundColor <> value Then
                    oBackgroundColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                If oColor <> value Then
                    oColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAlternativeColor() As Color
            Get
                Return oClipartAlternativeColor
            End Get
            Set(ByVal value As Color)
                If oClipartAlternativeColor <> value Then
                    oClipartAlternativeColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Friend Function GetPaintZoomFactor(PaintOptions As cOptionsCenterline) As Single
            Dim sZoomFactor As Single
            If sLocalZoomFactor = 0 Then
                Select Case iHatchType
                    Case cBrush.HatchTypeEnum.Texture
                        sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignTextureScaleFactor", 0.2)
                    Case cBrush.HatchTypeEnum.Clipart
                        sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignSoilScaleFactor", 1)
                    Case Else
                        sZoomFactor = PaintOptions.GetCurrentDesignPropertiesValue("DesignSoilScaleFactor", 1)
                End Select
            Else
                sZoomFactor = sLocalZoomFactor
            End If
            Return sZoomFactor
        End Function

        Friend Function GetPaintLineWidth(PaintOptions As cOptionsCenterline) As Single
            Dim sLineWidth As Single
            If sLocalLineWidth = 0 Then
                sLineWidth = PaintOptions.GetCurrentDesignPropertiesValue("BaseLineWidthScaleFactor", 0.01)
            Else
                sLineWidth = sLocalLineWidth
            End If
            Return sLineWidth
        End Function

        Friend Function GetPaintPenWidth(PaintOptions As cOptionsCenterline, BaseWidth As Single) As Single
            Dim sLineWidth As Single = GetPaintLineWidth(PaintOptions)
            Dim sPenWidth As Single = 0
            '20211014: due to a fix from microsoft pens with width <=1 are correctly scaled, before this fix pens with width<=1 or negative are not scaled
            If BaseWidth < 0 Then
                sPenWidth = BaseWidth
            ElseIf BaseWidth = 0 Then
                sPenWidth = PaintOptions.GetBrushPenDefaultWidth(iType) * sLineWidth
            Else
                sPenWidth = BaseWidth * sLineWidth
            End If
            Return sPenWidth
        End Function

        Private Sub pRender(ByVal PaintOptions As cOptionsCenterline)
            If iHatchType = cBrush.HatchTypeEnum.Solid OrElse iHatchType = cBrush.HatchTypeEnum.Clipart OrElse iHatchType = cBrush.HatchTypeEnum.Pattern OrElse iHatchType = cBrush.HatchTypeEnum.Texture Then
                Dim oPaintColor As Color = If(oAlternativeColor.IsEmpty, oColor, oAlternativeColor)

                oPen = New Pen(oPaintColor, GetPaintPenWidth(PaintOptions, 0))
                oBrush = New SolidBrush(oPaintColor)
                oSchematicBrush = New HatchBrush(HatchStyle.Percent10, oPaintColor, Color.White)
                oClipartAlternativeBrush1 = New SolidBrush(oClipartAlternativeColor)
                oClipartAlternativeBrush2 = New SolidBrush(Color.FromArgb(180, oClipartAlternativeColor))
                oBackgroundBrush = New SolidBrush(oBackgroundColor)
                If iHatchType = cBrush.HatchTypeEnum.Texture Then
                    If oTexture IsNot Nothing Then
                        Dim oRect As RectangleF = New RectangleF(0, 0, oTexture.Width, oTexture.Height)
                        oTextureBrush = New TextureBrush(oTexture, iTextureWrapMode, oRect)
                    End If
                End If

                If oPatternBrushes IsNot Nothing Then
                    oPatternPens = New List(Of Pen)
                    For Each oPatternBrush In oPatternBrushes
                        Dim oPatternPen As Pen = New Pen(oPaintColor, sLineWidth / 10.0F)
                        oPatternPen.SetLineCap(Drawing2D.LineCap.Round, Drawing2D.LineCap.Round, Drawing2D.DashCap.Round)
                        oPatternPen.LineJoin = Drawing2D.LineJoin.Round
                        Select Case oPatternBrush.PatternPenStyle
                            Case cPen.PenStylesEnum.Solid
                                oPatternPen.DashStyle = DashStyle.Solid
                            Case cPen.PenStylesEnum.Dot
                                oPatternPen.DashStyle = DashStyle.Dot
                            Case cPen.PenStylesEnum.Dash
                                oPatternPen.DashStyle = DashStyle.Dash
                            Case cPen.PenStylesEnum.DashDot
                                oPatternPen.DashStyle = DashStyle.DashDot
                        End Select
                        Call oPatternPens.Add(oPatternPen)
                    Next
                End If

                bInvalidated = False
            End If
        End Sub

        Private Sub pRenderTexture(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If PaintOptions.ShowAdvancedBrushes Then
                If Selected = cItem.SelectionModeEnum.InEdit Then
                    Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush2)
                Else
                    Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                    If oTexture IsNot Nothing Then
                        Call oTextureBrush.ResetTransform()
                        Call oTextureBrush.ScaleTransform(sZoomFactor, sZoomFactor)
                        Call Cache.AddFiller(Path, Nothing, Nothing, oTextureBrush)
                    End If
                End If
            Else
                Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush1)
            End If
        End Sub

        Private Function pCreateRegion(Path As GraphicsPath) As cIRegion
            If oSurvey.Properties.DesignProperties.GetValue("clippingforadvancedbrush", 0) = 0 Then
                Return New cGDIRegion(Path)
            Else
                Return New cClipperRegion(Path, 1000, 0.1)
            End If
        End Function

        Private Sub pRenderClipart(Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache, Seed As cBrushSeed)
            If PaintOptions.ShowAdvancedBrushes Then
                If Selected = cItem.SelectionModeEnum.InEdit Then
                    Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, Path, Nothing, Nothing, oClipartAlternativeBrush2)
                Else
                    If sClipartDensity > 0 AndAlso Not oClipart Is Nothing AndAlso Path.PointCount > 2 Then
                        Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                        Dim sCurrentDensity As Single = sClipartDensity * sZoomFactor
                        Call Cache.AddSetClip(Path)
                        If oBackgroundBrush.Color <> Color.Transparent Then Cache.AddFiller(Path,,, oBackgroundBrush)
                        Using oClipRegion As cIRegion = pCreateRegion(Path)
                            Using oPenPath As GraphicsPath = New GraphicsPath
                                Using oFillWhitePath As GraphicsPath = New GraphicsPath
                                    oFillWhitePath.FillMode = FillMode.Winding
                                    Using oFillPath As GraphicsPath = New GraphicsPath
                                        oFillPath.FillMode = FillMode.Winding

                                        If iClipartCrop = cBrush.ClipartCropEnum.Subitems Then
                                            Dim oBasePenPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oBaseFillWhitePathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oBaseFillPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)

                                            Dim oItemPenPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oItemFillWhitePathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)
                                            Dim oItemFillPathColl As List(Of GraphicsPath) = New List(Of GraphicsPath)

                                            Dim oPaths As cDrawPaths = oClipart.Paths
                                            For Each oDrawPath As cDrawPath In oPaths
                                                Dim oClipartPath As GraphicsPath = oDrawPath.Path
                                                If oClipartPath.PointCount > 1 Then
                                                    If oClipartPath.PointCount > 2 Then
                                                        Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                                                        If sFill <> "none" Then
                                                            Dim oColor As Color
                                                            If sFill = "" Then
                                                                oColor = Color.Transparent
                                                            Else
                                                                oColor = ColorTranslator.FromHtml(sFill)
                                                            End If
                                                            If oColor.ToArgb = Color.White.ToArgb Then
                                                                Call oBaseFillWhitePathColl.Add(oClipartPath)
                                                            Else
                                                                Call oBaseFillPathColl.Add(oClipartPath)
                                                            End If
                                                        End If
                                                    End If
                                                    Call oBasePenPathColl.Add(oClipartPath)
                                                End If
                                            Next

                                            Dim bBasePenPath As Boolean = oBasePenPathColl.Count > 0
                                            If bBasePenPath Then
                                                Dim bBaseFillWhitePath As Boolean = oBaseFillWhitePathColl.Count > 0
                                                Dim bBaseFillPath As Boolean = oBaseFillPathColl.Count > 0

                                                Dim oBounds As RectangleF = Path.GetBounds
                                                Dim oClipartBounds As RectangleF = oClipart.GetBounds
                                                Dim sLeft As Single = oBounds.Left - sCurrentDensity
                                                Dim sRight As Single = oBounds.Right + sCurrentDensity
                                                Call Seed.Restart()
                                                For x As Single = sLeft To sRight Step sCurrentDensity
                                                    Dim [sTop] As Single = oBounds.Top - sCurrentDensity * Math.Abs(Seed.CurrentBase) / 100 * 2
                                                    Dim sBottom As Single = oBounds.Bottom + sCurrentDensity * Math.Abs(Seed.CurrentBase) / 100 * 2
                                                    For y As Single = [sTop] To sBottom Step sCurrentDensity
                                                        Dim oPoint As PointF
                                                        If iClipartPosition = cBrush.ClipartPositionEnum.Fixed Then
                                                            oPoint = New PointF(x, y)
                                                        Else
                                                            Call Seed.Next()
                                                            Dim sSideFactor As Single = sCurrentDensity * Seed.CurrentBase / 200
                                                            oPoint = New PointF(x + sSideFactor, y)
                                                        End If

                                                        Using oMatrix As Matrix = New Matrix
                                                            Dim oCenterPoint As PointF = New PointF(oClipartBounds.Left + oClipartBounds.Width / 2, oClipartBounds.Top + oClipartBounds.Height / 2)
                                                            If iClipartAngleMode = cBrush.ClipartAngleModeEnum.Random Then
                                                                Call oMatrix.RotateAt(359 * Seed.CurrentBase / 100, oCenterPoint, MatrixOrder.Append)
                                                            Else
                                                                If sClipartAngle <> 0 Then
                                                                    Call oMatrix.RotateAt(sClipartAngle, oCenterPoint, MatrixOrder.Append)
                                                                End If
                                                            End If
                                                            Dim sTempZoomFactor As Single = sClipartZoomFactor * sZoomFactor
                                                            If sTempZoomFactor <> 1 Then
                                                                Call oMatrix.Scale(sTempZoomFactor, sTempZoomFactor, MatrixOrder.Append)
                                                            End If
                                                            Call oMatrix.Translate(oPoint.X, oPoint.Y, MatrixOrder.Append)

                                                            If bBaseFillWhitePath Then
                                                                Call oItemFillWhitePathColl.Clear()
                                                                For Each oPath As GraphicsPath In oBaseFillWhitePathColl
                                                                    Dim oNewPath As GraphicsPath = oPath.Clone
                                                                    Call oNewPath.Transform(oMatrix)
                                                                    Call oItemFillWhitePathColl.Add(oNewPath)
                                                                Next
                                                            End If

                                                            If bBaseFillPath Then
                                                                Call oItemFillPathColl.Clear()
                                                                For Each oPath As GraphicsPath In oBaseFillPathColl
                                                                    Dim oNewPath As GraphicsPath = oPath.Clone
                                                                    Call oNewPath.Transform(oMatrix)
                                                                    Call oItemFillPathColl.Add(oNewPath)
                                                                Next
                                                            End If

                                                            Call oItemPenPathColl.Clear()
                                                            For Each oPath As GraphicsPath In oBasePenPathColl
                                                                Dim oNewPath As GraphicsPath = oPath.Clone
                                                                Call oNewPath.Transform(oMatrix)
                                                                Call oItemPenPathColl.Add(oNewPath)
                                                            Next

                                                            For Each oPath As GraphicsPath In oItemFillWhitePathColl
                                                                Using oWidenedPath As GraphicsPath = oPath
                                                                    If oClipRegion.Contains(Graphics, oWidenedPath) Then
                                                                        Call Cache.AddFiller(oPath, Nothing, Nothing, Brushes.White)
                                                                    End If
                                                                End Using
                                                            Next

                                                            For Each oPath As GraphicsPath In oItemFillPathColl
                                                                'Try
                                                                Using oWidenedPath As GraphicsPath = oPath
                                                                    If oClipRegion.Contains(Graphics, oWidenedPath) Then
                                                                        Call Cache.AddFiller(oPath, Nothing, Nothing, oBrush)
                                                                    End If
                                                                End Using
                                                            Next

                                                            For Each oPath As GraphicsPath In oItemPenPathColl
                                                                Using oWidenedPath As GraphicsPath = oPath
                                                                    If oClipRegion.Contains(Graphics, oWidenedPath) Then
                                                                        Call Cache.AddFiller(oPath, oPen, Nothing)
                                                                    End If
                                                                End Using
                                                            Next

                                                        End Using

                                                        If Not PaintOptions.IsDesign AndAlso modMain.Is32Bit Then
                                                            Call GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced)
                                                        End If
                                                    Next
                                                Next
                                            End If
                                        Else
                                            Using oBasePenPath As GraphicsPath = New GraphicsPath
                                                Using oBaseFillWhitePath As GraphicsPath = New GraphicsPath
                                                    Using oBaseFillPath As GraphicsPath = New GraphicsPath

                                                        Dim oItemFillWhitePath As GraphicsPath = Nothing
                                                        Dim oItemFillPath As GraphicsPath = Nothing

                                                        Dim oPaths As cDrawPaths = oClipart.Paths
                                                        For Each oDrawPath As cDrawPath In oPaths
                                                            Dim oClipartPath As GraphicsPath = oDrawPath.Path
                                                            Dim sFill As String = oDrawPath.GetStyle("fill", "none")
                                                            If sFill <> "none" Then
                                                                Dim oColor As Color
                                                                If sFill = "" Then
                                                                    oColor = Color.Transparent
                                                                Else
                                                                    oColor = ColorTranslator.FromHtml(sFill)
                                                                End If
                                                                If oColor.ToArgb = Color.White.ToArgb Then
                                                                    Call oBaseFillWhitePath.AddPath(oClipartPath, False)
                                                                Else
                                                                    Call oBaseFillPath.AddPath(oClipartPath, False)
                                                                End If
                                                            End If
                                                            Call oBasePenPath.AddPath(oClipartPath, False)
                                                        Next

                                                        Dim bBasePenPath As Boolean = oBasePenPath.PointCount > 1
                                                        If bBasePenPath Then
                                                            Dim bBaseFillWhitePath As Boolean = oBaseFillWhitePath.PointCount > 1
                                                            Dim bBaseFillPath As Boolean = oBaseFillPath.PointCount > 1

                                                            Dim oBounds As RectangleF = Path.GetBounds
                                                            Dim oClipartBounds As RectangleF = oClipart.GetBounds
                                                            Dim sLeft As Single = oBounds.Left - sCurrentDensity
                                                            Dim sRight As Single = oBounds.Right + sCurrentDensity
                                                            Call Seed.Restart()
                                                            For x As Single = sLeft To sRight Step sCurrentDensity
                                                                Dim [sTop] As Single = oBounds.Top - sCurrentDensity * Math.Abs(Seed.CurrentBase) / 100 * 2
                                                                Dim sBottom As Single = oBounds.Bottom + sCurrentDensity * Math.Abs(Seed.CurrentBase) / 100 * 2
                                                                For y As Single = [sTop] To sBottom Step sCurrentDensity
                                                                    Dim oPoint As PointF
                                                                    If iClipartPosition = cBrush.ClipartPositionEnum.Fixed Then
                                                                        oPoint = New PointF(x, y)
                                                                    Else
                                                                        Call Seed.Next()
                                                                        Dim sSideFactor As Single = sCurrentDensity * Seed.CurrentBase / 200
                                                                        oPoint = New PointF(x + sSideFactor, y)
                                                                    End If

                                                                    Using oMatrix As Matrix = New Matrix
                                                                        Dim oCenterPoint As PointF = New PointF(oClipartBounds.Left + oClipartBounds.Width / 2, oClipartBounds.Top + oClipartBounds.Height / 2)
                                                                        If iClipartAngleMode = cBrush.ClipartAngleModeEnum.Random Then
                                                                            Call oMatrix.RotateAt(359 * Seed.CurrentBase / 100, oCenterPoint, MatrixOrder.Append)
                                                                        Else
                                                                            If sClipartAngle <> 0 Then
                                                                                Call oMatrix.RotateAt(sClipartAngle, oCenterPoint, MatrixOrder.Append)
                                                                            End If
                                                                        End If
                                                                        Dim sTempZoomFactor As Single = sClipartZoomFactor * sZoomFactor
                                                                        If sTempZoomFactor <> 1 Then
                                                                            Call oMatrix.Scale(sTempZoomFactor, sTempZoomFactor, MatrixOrder.Append)
                                                                        End If
                                                                        Call oMatrix.Translate(oPoint.X, oPoint.Y, MatrixOrder.Append)

                                                                        Using oItemPenPath As GraphicsPath = oBasePenPath.Clone
                                                                            Call oItemPenPath.Transform(oMatrix)

                                                                            Dim bDo As Boolean
                                                                            Using oWidenedPath As GraphicsPath = oItemPenPath.Clone
                                                                                oWidenedPath.Widen(oPen)
                                                                                If iClipartCrop = cBrush.ClipartCropEnum.Full Then
                                                                                    bDo = oClipRegion.Contains(Graphics, oWidenedPath)
                                                                                Else
                                                                                    bDo = True
                                                                                End If
                                                                            End Using
                                                                            If bDo Then
                                                                                If bBaseFillWhitePath Then
                                                                                    oItemFillWhitePath = oBaseFillWhitePath.Clone
                                                                                    Call oItemFillWhitePath.Transform(oMatrix)
                                                                                End If
                                                                                If bBaseFillPath Then
                                                                                    oItemFillPath = oBaseFillPath.Clone
                                                                                    Call oItemFillPath.Transform(oMatrix)
                                                                                End If

                                                                                If bBaseFillWhitePath Then
                                                                                    Call Cache.AddFiller(oItemFillWhitePath, Nothing, Nothing, Brushes.White)
                                                                                    Call oItemFillWhitePath.Dispose()
                                                                                End If
                                                                                If bBaseFillPath Then
                                                                                    Call Cache.AddFiller(oItemFillPath, Nothing, Nothing, oBrush)
                                                                                    Call oItemFillPath.Dispose()
                                                                                End If
                                                                                Call Cache.AddFiller(oItemPenPath, oPen, Nothing)
                                                                            End If
                                                                        End Using
                                                                    End Using
                                                                Next
                                                            Next
                                                            'If bBaseFillWhitePath Then Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, oFillWhitePath, Nothing, Nothing, Brushes.White)
                                                            'If bBaseFillPath Then Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, oFillPath, Nothing, Nothing, oBrush)
                                                            'Call Cache.Add(cDrawCacheItem.cDrawCacheItemType.Filler, oPenPath, oPen, Nothing)
                                                        End If
                                                    End Using
                                                End Using
                                            End Using
                                        End If
                                    End Using
                                End Using
                            End Using
                        End Using
                        Call Cache.AddResetclip()
                    End If
                End If
            Else
                Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush1)
            End If
        End Sub

        Private Sub pRenderPattern(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            If PaintOptions.ShowAdvancedBrushes Then
                If Selected = cItem.SelectionModeEnum.InEdit Then
                    Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush2)
                Else
                    Dim sZoomFactor As Single = GetPaintZoomFactor(PaintOptions)
                    If Path.PointCount > 2 Then
                        Call Cache.AddSetClip(Path)
                        If oBackgroundBrush.Color <> Color.Transparent Then Cache.AddFiller(Path,,, oBackgroundBrush)
                        Dim iPatternIndex As Integer
                        For Each oPatternBrush As cPatternBrush In oPatternBrushes
                            If oPatternBrush.PatternDensity > 0 Then
                                Dim oPatternPen As Pen = oPatternPens(iPatternIndex)
                                Dim sCurrentDensity As Single = oPatternBrush.PatternDensity * sZoomFactor
                                Dim sCurrentSize As Single = oPatternBrush.PatternZoomFactor * sZoomFactor 'sCurrentDensity * oPatternBrush.PatternZoomFactor
                                Dim oBounds As RectangleF = Path.GetBounds
                                Using oMatrix As Matrix = New Matrix
                                    Call oMatrix.RotateAt(oPatternBrush.PatternAngle, modPaint.GetCenterPoint(oBounds))
                                    Using oBoundPath As GraphicsPath = New GraphicsPath
                                        Call oBoundPath.AddRectangle(oBounds)
                                        Call oBoundPath.Transform(oMatrix)
                                        oBounds = oBoundPath.GetBounds
                                    End Using

                                    Using oPainter As cPatternBrushPainter = New cPatternBrushPainter(oPatternBrush, oBounds)
                                        oPatternBrush.OnPaint(oPainter)
                                        Call oPainter.Path.Transform(oMatrix)
                                        If oPainter.IsFilled Then
                                            Call Cache.AddFiller(oPainter.Path, oPatternPen, Nothing, New SolidBrush(oPatternPen.Color))
                                        Else
                                            Call Cache.AddFiller(oPainter.Path, oPatternPen, Nothing)
                                        End If
                                    End Using
                                End Using
                            End If
                            iPatternIndex += 1
                        Next
                        Call Cache.AddResetclip()
                    End If
                End If
            Else
                Call Cache.AddFiller(Path, Nothing, Nothing, oClipartAlternativeBrush1)
            End If
        End Sub

        Private Sub pRenderSolid(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            Call Cache.AddBorder(Path, Nothing, Nothing, oBrush)
        End Sub

        Friend Sub Render(Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache, Optional Seed As cBrushSeed = Nothing)
            If bInvalidated Then Call pRender(PaintOptions)
            If iType <> cBrush.BrushTypeEnum.None Then
                If Path.PointCount > 1 Then
                    Dim oRenderArgs As cBrush.cRenderEventArgs = New cBrush.cRenderEventArgs
                    RaiseEvent OnRender(Me, oRenderArgs)

                    Dim oBackupColors(7) As Color
                    If oRenderArgs.Transparency <> 0 Then
                        oBackupColors(0) = oPen.Color
                        oPen.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oPen.Color)

                        oBackupColors(1) = oBrush.Color
                        oBrush.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oBrush.Color)

                        oBackupColors(2) = oSchematicBrush.ForegroundColor
                        'oSchematicBrush.ForegroundColor =

                        oBackupColors(3) = oBackgroundBrush.Color
                        oBackgroundBrush.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oBackgroundBrush.Color)

                        oBackupColors(4) = oClipartAlternativeBrush1.Color
                        oClipartAlternativeBrush1.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oClipartAlternativeBrush1.Color)
                        oBackupColors(5) = oClipartAlternativeBrush2.Color
                        oClipartAlternativeBrush2.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oClipartAlternativeBrush2.Color)

                        oBackupColors(6) = oClipartAlternativeColor
                        oClipartAlternativeColor = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oClipartAlternativeColor)

                        If oPatternPens IsNot Nothing AndAlso oPatternPens.Count > 0 Then
                            oBackupColors(7) = oPatternPens(0).Color
                            For Each oPatternPen As Pen In oPatternPens
                                oPatternPen.Color = Color.FromArgb((1 - oRenderArgs.Transparency) * 255, oBackupColors(7))
                            Next
                        End If
                    End If

                    Select Case iHatchType
                        Case cBrush.HatchTypeEnum.None
                                'nulla...
                        Case cBrush.HatchTypeEnum.Solid
                            Call pRenderSolid(PaintOptions, Options, Selected, Path, Cache)
                        Case cBrush.HatchTypeEnum.Pattern
                            Call pRenderPattern(PaintOptions, Options, Selected, Path, Cache)
                        Case cBrush.HatchTypeEnum.Clipart
                            If Seed Is Nothing Then Seed = New cBrushSeed(0, 0)
                            Call pRenderClipart(Graphics, PaintOptions, Options, Selected, Path, Cache, Seed)
                        Case cBrush.HatchTypeEnum.Texture
                            Call pRenderTexture(PaintOptions, Options, Selected, Path, Cache)
                    End Select

                    If oRenderArgs.Transparency <> 0 Then
                        oPen.Color = oBackupColors(0)
                        oBrush.Color = oBackupColors(1)
                        'oSchematicBrush.ForegroundColor = oBackupColors(2)
                        oBackgroundBrush.Color = oBackupColors(3)
                        oClipartAlternativeBrush1.Color = oBackupColors(4)
                        oClipartAlternativeBrush2.Color = oBackupColors(5)
                        oClipartAlternativeColor = oBackupColors(6)
                        If oPatternPens IsNot Nothing Then
                            For Each oPatternPen As Pen In oPatternPens
                                oPatternPen.Color = oBackupColors(7)
                            Next
                        End If
                    End If
                End If
            End If
        End Sub

        Friend ReadOnly Property Invalidated As Boolean
            Get
                Return bInvalidated
            End Get
        End Property

        Private Sub oPatternBrushes_OnInvalidate(Sender As Object, e As EventArgs) Handles oPatternBrushes.OnInvalidate
            Call Invalidate()
        End Sub

        Friend Sub Invalidate()
            bInvalidated = True
            RaiseEvent OnChanged(Me, EventArgs.Empty)
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call Invalidate()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If oPen IsNot Nothing Then
                        Call oPen.Dispose()
                        oPen = Nothing
                    End If
                    If oPatternPens IsNot Nothing Then
                        For Each oPatternPen As Pen In oPatternPens
                            Call oPatternPen.Dispose()
                            oPatternPen = Nothing
                        Next
                        Call oPatternPens.Clear()
                    End If
                    If oBrush IsNot Nothing Then
                        Call oBrush.Dispose()
                        oBrush = Nothing
                    End If
                    If oSchematicBrush IsNot Nothing Then
                        Call oSchematicBrush.Dispose()
                        oSchematicBrush = Nothing
                    End If
                    If oBackgroundBrush IsNot Nothing Then
                        Call oBackgroundBrush.Dispose()
                        oBackgroundBrush = Nothing
                    End If
                    If oTexture IsNot Nothing Then
                        Call oTexture.Dispose()
                        oTexture = Nothing
                    End If
                    If oTextureBrush IsNot Nothing Then
                        Call oTextureBrush.Dispose()
                        oTextureBrush = Nothing
                    End If
                    If oClipartAlternativeBrush1 IsNot Nothing Then
                        Call oClipartAlternativeBrush1.Dispose()
                        oClipartAlternativeBrush1 = Nothing
                    End If
                    If oClipartAlternativeBrush2 IsNot Nothing Then
                        Call oClipartAlternativeBrush2.Dispose()
                        oClipartAlternativeBrush2 = Nothing
                    End If
                    If oSchematicBrush IsNot Nothing Then
                        Call oSchematicBrush.Dispose()
                        oSchematicBrush = Nothing
                    End If
                End If
            End If
            disposedValue = True
        End Sub

        ' Questo codice viene aggiunto da Visual Basic per implementare in modo corretto il criterio Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
        End Sub

#End Region
    End Class

    Public Class cBrush
        Implements IDisposable
        Implements cIPatternBrush

        Public Enum BrushTypeEnum
            None = 0

            Solid = 1
            Water = 2
            Sand = 3
            Pebbles = 4
            Flow = 5
            NotStandardWater = 6
            SignSolid = 7
            SmallDebrits = 8
            BigDebrits = 9
            SnowOrIce = 10

            User = 98
            Custom = 99
        End Enum

        Public Enum HatchTypeEnum
            None = 0
            Solid = 1
            Clipart = 2
            Pattern = 3
            Texture = 4
        End Enum

        Public Enum PatternTypeEnum
            Lines = 0
            CrossedLines = 1
        End Enum

        Public Enum PatternAngleModeEnum
            Fixed = 0
        End Enum

        Public Enum ClipartAngleModeEnum
            Random = 0
            Fixed = 1
        End Enum

        Public Enum ClipartCropEnum
            None = 0
            Full = 1
            Subitems = 2
        End Enum

        Public Enum ClipartPositionEnum
            Random = 0
            Fixed = 1
        End Enum

        Private WithEvents oSurvey As cSurvey

        Private WithEvents oSeed As cBrushSeed

        Friend Event OnChanged(ByVal Sender As Object, e As EventArgs)

        Private WithEvents oBaseBrush As cCustomBrush

        Friend Class cRenderEventArgs
            Inherits EventArgs
            Public Transparency As Single
        End Class
        Friend Event OnRender(sender As Object, RenderArgs As cRenderEventArgs)

        Public ReadOnly Property PatternBrushes As cPatternBrushes
            Get
                Return oBaseBrush.PatternBrushes
            End Get
        End Property

        Public Function GetThumbnailSVG(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As XmlDocument
            Return oBaseBrush.GetThumbnailSVG(PaintOptions, Options, cItem.SelectionModeEnum.Selected, thumbWidth, thumbHeight, ForeColor, Backcolor)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            Return oBaseBrush.GetThumbnailImage(PaintOptions, Options, Selected, thumbWidth, thumbHeight, ForeColor, Backcolor)
        End Function

        Public ReadOnly Property Name() As String
            Get
                Return oBaseBrush.Name
            End Get
        End Property

        ''' <summary>
        ''' Get the user ID of this brush
        ''' </summary>
        ''' <returns></returns>
        Public Function GetID() As String
            Return oBaseBrush.GetID
        End Function

        Public Shared Function IsUserBrushID(ID As String) As Boolean
            If ID Is Nothing OrElse ID = "" Then
                Return False
            Else
                Return Not ID.StartsWith("_")
            End If
        End Function

        Public Shared Function IsStandardBrushID(ID As String) As Boolean
            If ID Is Nothing OrElse ID = "" Then
                Return False
            Else
                Return ID.StartsWith("_")
            End If
        End Function

        Public Shared Function CalculateHash(Brush As cBrush) As String
            Using oMs As MemoryStream = New MemoryStream
                Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                    Dim oXML As XmlDocument = oFile.Document
                    Dim oXMLRoot As XmlElement = oXML.CreateElement("cbrush")
                    Dim oXMLItem As XmlElement = Brush.GetBaseBrush.SaveTo(oFile, oXML, oXMLRoot)
                    'hash is calculate without name and type
                    Call oXMLItem.RemoveAttribute("type")
                    Call oXMLItem.RemoveAttribute("name")
                    Call oXML.AppendChild(oXMLRoot)
                    Call oFile.SaveTo(oMs)
                    Return modMain.CalculateHash(oMs)
                End Using
            End Using
        End Function

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public Property ID As String
            Get
                Return oBaseBrush.ID
            End Get
            Set(value As String)
                If value <> oBaseBrush.ID Then
                    If value Is Nothing OrElse value = "" Then
                        Throw New Exception("Brush ID cannot be nothing or empty string")
                    Else
                        If value.StartsWith("_") Then
                            Dim iType As cBrush.BrushTypeEnum = Integer.Parse(value.Substring(1))
                            If iType = BrushTypeEnum.Custom Then
                                oBaseBrush = cCustomBrush.CopyAsCustom(oSurvey, oBaseBrush)
                                Call Invalidate()
                            ElseIf iType = BrushTypeEnum.User Then
                                Throw New Exception("Brush type cannot be directly set to user")
                            Else
                                oBaseBrush = oSurvey.Brushes.FromType(iType)
                                Call Invalidate()
                            End If
                        Else
                            oBaseBrush = oSurvey.Brushes.FromID(value)
                            Call Invalidate()
                        End If
                    End If
                End If
            End Set
        End Property

        Public Sub CopyFrom(ByVal Brush As cBrush)
            oBaseBrush = Brush.oBaseBrush
            Call oSeed.CopyFrom(Brush.oSeed)
            Call Invalidate()
        End Sub

        Friend Function GetBaseBrush() As cCustomBrush
            Return oBaseBrush
        End Function

        Public Property HatchType() As HatchTypeEnum
            Get
                Return oBaseBrush.HatchType
            End Get
            Set(ByVal value As HatchTypeEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.HatchType = value
                End If
            End Set
        End Property

        'Friend ReadOnly Property Pen As Pen
        '    Get
        '        Return oPen
        '    End Get
        'End Property

        'Friend ReadOnly Property Brush As Brush
        '    Get
        '        Return oBrush
        '    End Get
        'End Property

        Public Function GetPatternInstance() As Object Implements cIPatternBrush.GetPatternInstance
            Return oBaseBrush.GetPatternInstance
        End Function

        Public Property PatternPenStyle() As cPen.PenStylesEnum Implements cIPatternBrush.PatternPenStyle
            Get
                Return oBaseBrush.PatternPenStyle
            End Get
            Set(ByVal value As cPen.PenStylesEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternPenStyle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternType() As PatternTypeEnum Implements cIPatternBrush.PatternType
            Get
                Return oBaseBrush.PatternType
            End Get
            Set(ByVal value As PatternTypeEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternType = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartPosition() As ClipartPositionEnum
            Get
                Return oBaseBrush.ClipartPosition
            End Get
            Set(ByVal value As ClipartPositionEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartPosition = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartCrop() As ClipartCropEnum
            Get
                Return oBaseBrush.ClipartCrop
            End Get
            Set(ByVal value As ClipartCropEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartCrop = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternDeltaX() As Single Implements cIPatternBrush.PatternDeltaX
            Get
                Return oBaseBrush.PatternDeltaX
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternDeltaX = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternDeltaY() As Single Implements cIPatternBrush.PatternDeltaY
            Get
                Return oBaseBrush.PatternDeltaY
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternDeltaY = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternAngle() As Single Implements cIPatternBrush.PatternAngle
            Get
                Return oBaseBrush.PatternAngle
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternAngle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAngle() As Single
            Get
                Return oBaseBrush.ClipartAngle
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartAngle = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property TextureWrapmode() As System.Drawing.Drawing2D.WrapMode
            Get
                Return oBaseBrush.TextureWrapmode
            End Get
            Set(ByVal value As System.Drawing.Drawing2D.WrapMode)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.TextureWrapmode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternAngleMode() As PatternAngleModeEnum Implements cIPatternBrush.PatternAngleMode
            Get
                Return oBaseBrush.PatternAngleMode
            End Get
            Set(ByVal value As PatternAngleModeEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternAngleMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAngleMode() As ClipartAngleModeEnum
            Get
                Return oBaseBrush.ClipartAngleMode
            End Get
            Set(ByVal value As ClipartAngleModeEnum)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartAngleMode = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternDensity() As Single Implements cIPatternBrush.PatternDensity
            Get
                Return oBaseBrush.PatternDensity
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternDensity = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartDensity() As Single
            Get
                Return oBaseBrush.ClipartDensity
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartDensity = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartZoomFactor() As Single
            Get
                Return oBaseBrush.ClipartZoomFactor
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property PatternZoomFactor() As Single Implements cIPatternBrush.PatternZoomFactor
            Get
                Return oBaseBrush.PatternZoomFactor
            End Get
            Set(ByVal value As Single)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.PatternZoomFactor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Seed() As cBrushSeed
            Get
                Return oSeed
            End Get
        End Property

        Public Property Texture() As Image
            Get
                Return oBaseBrush.Texture
            End Get
            Set(ByVal Value As Image)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.Texture = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Clipart() As cDrawClipArt
            Get
                Return oBaseBrush.Clipart
            End Get
            Set(ByVal Value As cDrawClipArt)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.Clipart = Value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Type() As BrushTypeEnum
            Get
                Return oBaseBrush.Type
            End Get
            Set(ByVal value As BrushTypeEnum)
                If value <> Type Then
                    If value = BrushTypeEnum.User Then
                        'user brush cannot be created changing type
                        Throw New Exception("Brush type cannot be directly set to user")
                    Else
                        If value = BrushTypeEnum.Custom Then
                            'create a custom copy of the current brush 
                            oBaseBrush = cCustomBrush.CopyAsCustom(oSurvey, oBaseBrush)
                        Else
                            oBaseBrush = oSurvey.Brushes.FromType(value)
                        End If
                    End If
                End If
            End Set
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Brush As cBrush)
            oSurvey = Survey
            Call CopyFrom(Brush)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oSeed = New cBrushSeed
            oBaseBrush = New cCustomBrush(Survey)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal item As XmlElement)
            oSurvey = Survey

            If modXML.ChildElementExist(item, "seed") Then
                oSeed = New cBrushSeed(item.Item("seed"))
            Else
                oSeed = New cBrushSeed
            End If

            Dim iType As BrushTypeEnum = item.GetAttribute("type")
            If iType = BrushTypeEnum.Custom Then
                'custom pen are saved in line
                oBaseBrush = New cCustomBrush(oSurvey, File, item)
            Else
                If iType = BrushTypeEnum.User Then
                    'user pen are saved in pens collection
                    Dim sID As String = item.GetAttribute("id")
                    oBaseBrush = oSurvey.Brushes.FromID(sID)
                Else
                    oBaseBrush = oSurvey.Brushes.FromType(iType)
                End If
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement
            If oBaseBrush.Type = cBrush.BrushTypeEnum.Custom Then
                oItem = oBaseBrush.SaveTo(File, Document, Parent)
            Else
                oItem = Document.CreateElement("brush")
                Call oItem.SetAttribute("type", oBaseBrush.Type)
                If oBaseBrush.Type = cPen.PenTypeEnum.User Then
                    Call oItem.SetAttribute("id", oBaseBrush.ID)
                End If
                Parent.AppendChild(oItem)
            End If
            If oBaseBrush.HatchType = HatchTypeEnum.Clipart Then oSeed.SaveTo(File, Document, oItem)
            Return oItem
        End Function

        Public Property AlternativeColor() As Color
            Get
                Return oBaseBrush.AlternativeColor
            End Get
            Set(ByVal value As Color)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.AlternativeColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property Color() As Color
            Get
                Return oBaseBrush.Color
            End Get
            Set(ByVal value As Color)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.Color = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property BackgroundColor() As Color
            Get
                Return oBaseBrush.BackgroundColor
            End Get
            Set(ByVal value As Color)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.BackgroundColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Public Property ClipartAlternativeColor() As Color
            Get
                Return oBaseBrush.ClipartAlternativeColor
            End Get
            Set(ByVal value As Color)
                If oBaseBrush.IsWriteable Then
                    oBaseBrush.ClipartAlternativeColor = value
                    Call Invalidate()
                End If
            End Set
        End Property

        Private bIsRendering As Boolean

        Friend Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal Path As GraphicsPath, ByVal Cache As cDrawCache)
            bIsRendering = True
            Call oBaseBrush.Render(Graphics, PaintOptions, Options, Selected, Path, Cache, oSeed)
            bIsRendering = False
        End Sub

        Private Sub oBaseBrush_OnChanged(Sender As Object, e As EventArgs) Handles oBaseBrush.OnChanged
            RaiseEvent OnChanged(Me, e)
        End Sub

        Friend ReadOnly Property Invalidated As Boolean
            Get
                Return oBaseBrush.Invalidated
            End Get
        End Property

        Friend Sub Invalidate()
            Call oBaseBrush.Invalidate()
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged
            Call Invalidate()
        End Sub

        Private Sub oSeed_OnReseed(ByVal Sender As cBrushSeed) Handles oSeed.OnReseed
            Call Invalidate()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private Sub oBaseBrush_OnRender(sender As Object, RenderArgs As cBrush.cRenderEventArgs) Handles oBaseBrush.OnRender
            If bIsRendering Then
                RaiseEvent OnRender(Me, RenderArgs)
            End If
        End Sub

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oBaseBrush Is Nothing Then
                        Call oBaseBrush.Dispose()
                        oBaseBrush = Nothing
                    End If
                End If
            End If
            disposedValue = True
        End Sub

        ' Questo codice viene aggiunto da Visual Basic per implementare in modo corretto il criterio Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire sopra il codice di pulizia in Dispose(disposing As Boolean).
            Dispose(True)
        End Sub
#End Region
    End Class
End Namespace