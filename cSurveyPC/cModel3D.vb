'Imports System.Xml
'Imports System.IO

'Namespace cSurvey.Model3D
'    Public Class cModel3D
'        Private oSurvey As cSurvey
'        Private WithEvents oItems As cItems3D

'        Friend Sub Calculate(Optional ByVal PerformWarping As Boolean = True)
'            For Each oItem As cItem3D In oItems
'                If oItem.Type = cIItem3D.cItem3DTypeEnum.ShotBinded Then
'                    'devo verificare la posizione reale dei capisaldi di riferimento 
'                    'e quelle degli stessi nel modello
'                    'e creare una trasformazione che permetta di cambiare i capisaldi nel modello in quelli reali...
'                End If
'            Next
'        End Sub

'        Public ReadOnly Property Items() As cItems3D
'            Get
'                Return oItems
'            End Get
'        End Property

'        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Model3D As XmlElement)
'            oSurvey = Survey
'            oItems = New cItems3D(oSurvey, Me, File, Model3D.Item("items"))
'        End Sub

'        Friend Sub New(ByVal Survey As cSurvey)
'            oSurvey = Survey
'            oItems = New cItems3D(oSurvey, Me)
'        End Sub

'        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
'            Dim oXmlModel3D As XmlElement = Document.CreateElement("model3d")
'            Call oItems.SaveTo(File, Document, oXmlModel3D, Options)
'            Call Parent.AppendChild(oXmlModel3D)
'            Return oXmlModel3D
'        End Function

'    End Class

'    Public Class cItems3D
'        Implements IEnumerable

'        Private oSurvey As cSurvey
'        Private oModel3D As cModel3D
'        Private oItems As List(Of cItem3D)

'        Public Sub Clear()
'            Call oItems.Clear()
'        End Sub

'        Public Function IndexOf(ByVal Item As cItem3D) As Integer
'            Return oItems.IndexOf(Item)
'        End Function

'        Public ReadOnly Property Count() As Integer
'            Get
'                Return oItems.Count
'            End Get
'        End Property

'        Default Public ReadOnly Property Item(Index As Integer) As cItem3D
'            Get
'                Return oItems(Index)
'            End Get
'        End Property

'        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
'            Dim oXmlItems As XmlElement = Document.CreateElement("items")
'            Dim iIndex As Integer = 0
'            Dim iCount As Integer = oItems.Count
'            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
'            For Each oItem As cItem3D In oItems
'                iIndex += 1
'                If (Options And cSurvey.SaveOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Salvataggio oggetti 3D...", iIndex / iCount)
'                Call oItem.SaveTo(File, Document, oXmlItems)
'            Next
'            Call Parent.AppendChild(oXmlItems)
'            Return oXmlItems
'        End Function

'        Friend Sub New(ByVal Survey As cSurvey, ByVal Model3D As cModel3D, ByVal File As cFile, ByVal Items As XmlElement)
'            oSurvey = Survey
'            oModel3D = Model3D
'            oSurvey = Survey
'            oItems = New List(Of cItem3D)
'            Dim iIndex As Integer = 0
'            Dim iCount As Integer = Items.ChildNodes.Count
'            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
'            For Each oXMLItem As XmlElement In Items.ChildNodes
'                iIndex += 1
'                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, "Caricamento oggetti 3D...", iIndex / iCount)
'                Dim oItem As cItem3D = Nothing
'                Select Case oXMLItem.GetAttribute("type")
'                    Case cIItem3D.cItem3DTypeEnum.ShotBinded
'                        oItem = New cShotBindedItem3D(oSurvey, File, oXMLItem)
'                End Select
'                If Not oItem Is Nothing Then
'                    Call oItems.Add(oItem)
'                End If
'            Next
'        End Sub

'        Public Function CreateShotBindedItem(Model As System.Windows.Media.Media3D.Model3D, Point1 As System.Windows.Media.Media3D.Point3D, Station1 As String, Point2 As System.Windows.Media.Media3D.Point3D, Station2 As String) As cShotBindedItem3D
'            Dim oItem As cShotBindedItem3D = New cShotBindedItem3D(oSurvey, Model, Point1, Station1, Point2, Station2)
'            Call oItems.Add(oItem)
'            Return oItem
'        End Function

'        Friend Sub New(ByVal Survey As cSurvey, ByVal Model3D As cModel3D)
'            oSurvey = Survey
'            oModel3D = Model3D
'            oItems = New List(Of cItem3D)
'        End Sub

'        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
'            Return oItems.GetEnumerator
'        End Function
'    End Class

'    Public Class cShotBindedItem3D
'        Inherits cItem3D

'        Public Overrides ReadOnly Property MaxPointsCount As Integer
'            Get
'                Return 3    'i punti devono essere 3...non meno, non di più...tipicamente sarenno 2 punti di poligonale e un punto splay...
'            End Get
'        End Property

'        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Item As XmlElement)
'            Call MyBase.New(Survey, File, Item)
'        End Sub

'        Friend Sub New(ByVal Survey As cSurvey, Model As System.Windows.Media.Media3D.Model3D, Point1 As System.Windows.Media.Media3D.Point3D, Station1 As String, Point2 As System.Windows.Media.Media3D.Point3D, Station2 As String)
'            Call MyBase.New(Survey, Model)
'            MyBase.Stations.Add(Point1, Survey.TrigPoints(Station1))
'            MyBase.Stations.Add(Point2, Survey.TrigPoints(Station2))
'        End Sub
'    End Class

'    Public MustInherit Class cItem3D
'        Implements cIItem3D

'        Private oSurvey As cSurvey
'        Private sName As String
'        Private iType As cIItem3D.cItem3DTypeEnum
'        Private oStations As cStations3D
'        Private oModel As System.Windows.Media.Media3D.Model3D
'        Private oTransform As System.Windows.Media.Media3D.Transform3D

'        Public Class cStation3D
'            Private oSurvey As cSurvey

'            Private oPoint As System.Windows.Media.Media3D.Point3D
'            Private sName As String

'            Public Function IsValid() As Boolean
'                Return oSurvey.TrigPoints.Contains(sName)
'            End Function

'            Public Function IsOrphan() As Boolean
'                If IsValid() Then
'                    Return GetTrigPoint.Data.IsOrphan
'                Else
'                    Return True
'                End If
'            End Function

'            Public Property Point As System.Windows.Media.Media3D.Point3D
'                Get
'                    Return oPoint
'                End Get
'                Set(ByVal value As System.Windows.Media.Media3D.Point3D)
'                    oPoint = value
'                End Set
'            End Property

'            Public ReadOnly Property Name As String
'                Get
'                    Return sName
'                End Get
'            End Property

'            Public Sub SetTrigPoint(Trigpoint As cTrigPoint)
'                sName = Trigpoint.Name
'            End Sub

'            Public Function GetTrigPoint() As cTrigPoint
'                Return oSurvey.TrigPoints(sName)
'            End Function

'            Friend Sub New(ByVal Survey As cSurvey, ByVal Point As System.Windows.Media.Media3D.Point3D, ByVal TrigPoint As cTrigPoint)
'                oSurvey = Survey
'                oPoint = Point
'                Call SetTrigPoint(TrigPoint)
'            End Sub

'            Friend Sub New(ByVal Survey As cSurvey, ByVal Station As XmlElement)
'                oSurvey = Survey
'                oPoint = New System.Windows.Media.Media3D.Point3D(Station.GetAttribute("x"), Station.GetAttribute("y"), Station.GetAttribute("z"))
'                sName = Station.GetAttribute("trigpoint")
'                'oDesignPoint = New PointF(Station.GetAttribute("designx"), Station.GetAttribute("designy"))
'            End Sub

'            Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
'                Dim oXmlStation As XmlElement = Document.CreateElement("station")
'                Call oXmlStation.SetAttribute("x", Point.X)
'                Call oXmlStation.SetAttribute("y", Point.Y)
'                Call oXmlStation.SetAttribute("z", Point.Z)
'                Call oXmlStation.SetAttribute("trigpoint", sName)
'                'Call oXmlStation.SetAttribute("designx", modNumbers.NumberToString(DesignPoint.X, "0.000"))
'                'Call oXmlStation.SetAttribute("designy", modNumbers.NumberToString(DesignPoint.Y, "0.000"))
'                Call Parent.AppendChild(oXmlStation)
'                Return oXmlStation
'            End Function
'        End Class

'        Public Class cStations3D
'            Implements IEnumerable
'            Private oSurvey As cSurvey

'            Private oItems As List(Of cStation3D)

'            Public Function Contains(Station As cStation3D) As Boolean
'                Return oItems.Contains(Station)
'            End Function

'            Public Sub Clear()
'                Call oItems.Clear()
'            End Sub

'            Public Sub Add(ByVal Point As System.Windows.Media.Media3D.Point3D, ByVal TrigPoint As cTrigPoint)
'                Dim oStation As cStation3D = New cStation3D(oSurvey, Point, TrigPoint)
'                Call oItems.Add(oStation)
'            End Sub

'            Public Sub Remove(ByVal index As Integer)
'                Call oItems.RemoveAt(index)
'            End Sub

'            Public Sub Remove(ByVal Item As cStation3D)
'                Call oItems.Remove(Item)
'            End Sub

'            Default Public ReadOnly Property Items(ByVal Index As Integer) As cStation3D
'                Get
'                    Return oItems(Index)
'                End Get
'            End Property

'            Public ReadOnly Property Count As Integer
'                Get
'                    Return oItems.Count
'                End Get
'            End Property

'            Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
'                Return oItems.GetEnumerator
'            End Function

'            Friend Sub New(ByVal Survey As cSurvey)
'                oSurvey = Survey
'                oItems = New List(Of cStation3D)
'            End Sub

'            Friend Sub New(ByVal Survey As cSurvey, ByVal Stations As XmlElement)
'                oSurvey = Survey
'                oItems = New List(Of cStation3D)
'                For Each oXMLStation As XmlElement In Stations.ChildNodes
'                    Dim oStation As cStation3D = New cStation3D(oSurvey, oXMLStation)
'                    Call oItems.Add(oStation)
'                Next
'            End Sub

'            Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
'                Dim oXmlStations As XmlElement = Document.CreateElement("stations")
'                For Each oStation As cStation3D In oItems
'                    Call oStation.SaveTo(File, Document, oXmlStations)
'                Next
'                Call Parent.AppendChild(oXmlStations)
'                Return oXmlStations
'            End Function
'        End Class

'        Public ReadOnly Property Model As System.Windows.Media.Media3D.Model3D
'            Get
'                Return oModel
'            End Get
'        End Property

'        Friend Sub SetTransform(Transform As System.Windows.Media.Media3D.Transform3D)
'            oTransform = Transform
'        End Sub

'        Public ReadOnly Property Transform As System.Windows.Media.Media3D.Transform3D
'            Get
'                Return oTransform
'            End Get
'        End Property

'        Public ReadOnly Property Stations() As cStations3D
'            Get
'                Return oStations
'            End Get
'        End Property

'        Public ReadOnly Property Location As System.Windows.Media.Media3D.Point3D
'            Get
'                Return oModel.Bounds.Location
'            End Get
'        End Property

'        Public ReadOnly Property Bounds() As System.Windows.Media.Media3D.Rect3D
'            Get
'                Return oModel.Bounds
'            End Get
'        End Property

'        Public MustOverride ReadOnly Property MaxPointsCount() As Integer

'        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Item As XmlElement)
'            oSurvey = Survey
'            sName = modXML.GetAttributeValue(Item, "name", "")
'            iType = modXML.GetAttributeValue(Item, "type")
'            oModel = Windows.Markup.XamlReader.Load(XmlReader.Create(New StringReader(modXML.GetAttributeValue(Item, "model"))))
'            oTransform = Windows.Markup.XamlReader.Load(XmlReader.Create(New StringReader(modXML.GetAttributeValue(Item, "transform"))))
'            Try
'                oStations = New cStations3D(Survey, Item.Item("stations"))
'            Catch
'                oStations = New cStations3D(Survey)
'            End Try
'        End Sub

'        Friend Sub New(ByVal Survey As cSurvey, Model As System.Windows.Media.Media3D.Model3D)
'            oSurvey = Survey
'            oModel = Model
'            oTransform = New System.Windows.Media.Media3D.ScaleTransform3D(1, 1, 1)
'            oStations = New cStations3D(Survey)
'        End Sub

'        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
'            Dim oXmlItem As XmlElement = Document.CreateElement("item")
'            If sName <> "" Then Call oXmlItem.SetAttribute("name", sName)
'            Call oXmlItem.SetAttribute("type", iType.ToString("D"))
'            Call oXmlItem.SetAttribute("model", Windows.Markup.XamlWriter.Save(oModel))
'            Call oXmlItem.SetAttribute("transform", Windows.Markup.XamlWriter.Save(oTransform))
'            Call oStations.SaveTo(File, Document, oXmlItem)
'            Call Parent.AppendChild(oXmlItem)
'            Return oXmlItem
'        End Function

'        Public Property Name As String Implements cIItem3D.Name

'        Public ReadOnly Property Type As cIItem3D.cItem3DTypeEnum Implements cIItem3D.Type
'            Get
'                Return iType
'            End Get
'        End Property
'    End Class
'End Namespace