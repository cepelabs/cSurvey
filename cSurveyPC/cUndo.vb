Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Runtime.Remoting.Messaging
Imports System.ServiceModel
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Helper.Editor.cUndo
Imports DevExpress.Charts.Native
Imports DevExpress.Office
Imports DevExpress.XtraCharts.Native.RangeDataBase
Imports DevExpress.XtraGauges.Core.Model
Imports DevExpress.XtraTreeList.Nodes.Operations
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Text

Namespace cSurvey.Helper.Editor
    'Friend Class cUndoItemBaseData(Of T)
    '    Private oData As T

    '    Public ReadOnly Property Data As T
    '        Get
    '            Return oData
    '        End Get
    '    End Property

    '    Public Sub New(Data As T)
    '        oData = Data
    '    End Sub
    'End Class

    Friend Class cUndoItemSelectionTrigpoint
        Private sTrigpoint As String
        Private oTrigpoints As cTrigPoints

        Public ReadOnly Property Trigpoints As cTrigPoints
            Get
                Return oTrigpoints
            End Get
        End Property

        Public ReadOnly Property Trigpoint As String
            Get
                Return sTrigpoint
            End Get
        End Property

        Public Sub New(Trigpoints As cTrigPoints, Trigpoint As String)
            oTrigpoints = Trigpoints
            sTrigpoint = sTrigpoint
        End Sub
    End Class

    Friend Class cUndoItemSelectionSegment
        Private iIndex As Integer
        Private oSegments As cSegments

        Public ReadOnly Property Segments As cSegments
            Get
                Return oSegments
            End Get
        End Property

        Public ReadOnly Property Index As Integer
            Get
                Return iIndex
            End Get
        End Property

        Public Sub New(Segments As cSegments, Index As Integer)
            oSegments = Segments
            iIndex = Index
        End Sub
    End Class

    Friend Class cUndoItemSelectionDesignData
        Private iIndex As Integer
        Private oLayer As cLayer

        Public ReadOnly Property Index As Integer
            Get
                Return iIndex
            End Get
        End Property

        Public Sub New(Index As Integer, Layer As cLayer)
            iIndex = Index
            oLayer = Layer
        End Sub

        Public ReadOnly Property Layer As cLayer
            Get
                Return oLayer
            End Get
        End Property
    End Class

    Friend Class cUndoItemDataTrigpointData
        Private oXMLElement As XmlElement
        Private sTrigpoint As String
        Private oTrigpoints As cTrigPoints

        Public ReadOnly Property XMLElement As XmlElement
            Get
                Return oXMLElement
            End Get
        End Property

        Public ReadOnly Property Trigpoint As String
            Get
                Return sTrigpoint
            End Get
        End Property

        Public Sub New(XMLElement As XmlElement, Trigpoint As String, Trigpoints As cTrigPoints)
            oXMLElement = XMLElement
            sTrigpoint = Trigpoint
            oTrigpoints = Trigpoints
        End Sub

        Public ReadOnly Property Trigpoints As cTrigPoints
            Get
                Return oTrigpoints
            End Get
        End Property
    End Class

    Friend Class cUndoItemDataSegmentData
        Private oXMLElement As XmlElement
        Private iIndex As Integer
        Private oSegments As cSegments

        Public ReadOnly Property XMLElement As XmlElement
            Get
                Return oXMLElement
            End Get
        End Property

        Public ReadOnly Property Index As Integer
            Get
                Return iIndex
            End Get
        End Property

        Public Sub New(XMLElement As XmlElement, Index As Integer, Segments As cSegments)
            oXMLElement = XMLElement
            iIndex = Index
            oSegments = Segments
        End Sub

        Public ReadOnly Property Segments As cSegments
            Get
                Return oSegments
            End Get
        End Property
    End Class

    Friend Class cUndoItemDataDesignData
        Private oXMLElement As XmlElement
        Private iIndex As Integer
        Private oLayer As cLayer

        Public ReadOnly Property XMLElement As XmlElement
            Get
                Return oXMLElement
            End Get
        End Property

        Public ReadOnly Property Index As Integer
            Get
                Return iIndex
            End Get
        End Property

        Public Sub New(XMLElement As XmlElement, Index As Integer, Layer As cLayer)
            oXMLElement = XMLElement
            iIndex = Index
            oLayer = Layer
        End Sub

        Public ReadOnly Property Layer As cLayer
            Get
                Return oLayer
            End Get
        End Property
    End Class

    Public Delegate Function cUndoItemBackupValueDelegate(Item As cItem)
    Public Delegate Sub cUndoItemRestoreValueDelegate(Item As cItem, Value As Object)

    Friend Class cUndoItemValueDesignPropertyData
        Private iIndex As Integer
        Private oLayer As cLayer

        Private oValue As Object

        Public Sub New(Value As Object, Index As Integer, Layer As cLayer)
            oValue = Value
            iIndex = Index
            oLayer = Layer
        End Sub

        Public ReadOnly Property Index As Integer
            Get
                Return iIndex
            End Get
        End Property

        Public ReadOnly Property Layer As cLayer
            Get
                Return oLayer
            End Get
        End Property

        Public ReadOnly Property Value As Object
            Get
                Return oValue
            End Get
        End Property
    End Class

    Public MustInherit Class cUndoItem
        Private oParent As cUndo

        Private sDescription As String
        Private dDateStamp As DateTime
        Private iArea As cAreaEnum

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum)
            oParent = Parent
            sDescription = Description
            dDateStamp = Date.Now
            iArea = Area
        End Sub

        Friend ReadOnly Property Parent As cUndo
            Get
                Return oParent
            End Get
        End Property

        Public ReadOnly Property DateStamp As DateTime
            Get
                Return dDateStamp
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return sDescription
            End Get
        End Property

        Public ReadOnly Property Area As cAreaEnum
            Get
                Return iArea
            End Get
        End Property

        Friend MustOverride Function Restore() As cUndoRestore
    End Class

    Public MustInherit Class cUndoItemSelection
        Inherits cUndoItem

        Public Sub New(Parent As cUndo, Description As String, Area As cAreaEnum)
            MyBase.New(Parent, Description, Area)
        End Sub
    End Class

    Public Class cUndoDataTrigpointSelection
        Inherits cUndoItemSelection

        Private oItem As cUndoItemSelectionTrigpoint

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Trigpoint As cTrigPoint)
            MyBase.New(Parent, Description, Area)
            oItem = New cUndoItemSelectionTrigpoint(Trigpoint.Survey.TrigPoints, Trigpoint.Name)
        End Sub

        Friend Overrides Function Restore() As cUndoRestore
            Return New cUndoRestoreDataTrigPoint(MyBase.Area, oItem.Trigpoints(oItem.Trigpoint))
        End Function
    End Class

    Public Class cUndoDataSegmentSelection
        Inherits cUndoItemSelection

        Private oItem As cUndoItemSelectionSegment

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Segment As cSegment)
            MyBase.New(Parent, Description, Area)
            oItem = New cUndoItemSelectionSegment(Segment.Survey.Segments, Segment.Index)
        End Sub

        Friend Overrides Function Restore() As cUndoRestore
            Return New cUndoRestoreDataSegment(MyBase.Area, oItem.Segments(oItem.Index))
        End Function
    End Class

    Public Class cUndoDesignItemSelection
        Inherits cUndoItemSelection

        Private oFirstItems As List(Of cUndoItemSelectionDesignData)

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cItem)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemSelectionDesignData)
            Call Append(Item)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cItem))
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemSelectionDesignData)
            Call Append(Items)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cItem))
            For Each oItem As cItem In Items
                Call Append(oItem)
            Next
        End Sub

        Friend Sub Append(Item As cItem)
            Call oFirstItems.Add(New cUndoItemSelectionDesignData(Item.Layer.Items.IndexOf(Item), Item.Layer))
        End Sub

        Friend Overrides Function Restore() As cUndoRestore
            Dim oRestore As cUndoRestoreDesign = New cUndoRestoreDesign(MyBase.Area)
            For Each oFirstItem As cUndoItemSelectionDesignData In oFirstItems
                Call oRestore.Items.Add(oFirstItem.Layer.Items(oFirstItem.Index))
            Next
            Return oRestore
        End Function
    End Class

    Public Class cUndoDesignItemDelegatedProperty
        Inherits cUndoItem

        Private oBackupDelegate As cUndoItemBackupValueDelegate
        Private oRestoreDelegate As cUndoItemRestoreValueDelegate

        Private oFirstItems As List(Of cUndoItemValueDesignPropertyData)

        Friend Overrides Function Restore() As cUndoRestore
            Dim oRestore As cUndoRestoreDesign = New cUndoRestoreDesign(MyBase.Area)
            For Each oFirstItem As cUndoItemValueDesignPropertyData In oFirstItems.OrderBy(Function(oItem) oItem.Index)
                Dim oItem As cItem = oFirstItem.Layer.Items(oFirstItem.Index)
                Call pSetData(oItem, oFirstItem)
                Call oRestore.Append(oItem)
            Next
            Return oRestore
        End Function

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate)
            MyBase.New(Parent, Description, Area)
            oBackupDelegate = BackupDelegate
            oRestoreDelegate = RestoreDelegate
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cItem, BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate)
            MyBase.New(Parent, Description, Area)
            oBackupDelegate = BackupDelegate
            oRestoreDelegate = RestoreDelegate
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
            Call Append(Item)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cItem), BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate)
            MyBase.New(Parent, Description, Area)
            oBackupDelegate = BackupDelegate
            oRestoreDelegate = RestoreDelegate
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
            Call Append(Items)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cItem), BackupDelegate As cUndoItemBackupValueDelegate)
            For Each oItem As cItem In Items
                Call Append(oItem)
            Next
        End Sub

        Friend Sub Append(Item As cItem)
            Call oFirstItems.Add(pGetData(Item))
        End Sub

        Private Function pGetData(Item As cItem) As cUndoItemValueDesignPropertyData
            Dim oValue As Object = oBackupDelegate(Item)
            Return New cUndoItemValueDesignPropertyData(oValue, Item.Layer.Items.IndexOf(Item), Item.Layer)
        End Function

        Private Sub pSetData(Item As cItem, Value As cUndoItemValueDesignPropertyData)
            Dim oValue As Object = Value.Value
            oRestoreDelegate(Item, oValue)
        End Sub
    End Class

    Public Class cUndoDesignItemProperty
        Inherits cUndoItem

        Private sPropertyName As String

        Private oFirstItems As List(Of cUndoItemValueDesignPropertyData)

        Friend Overrides Function Restore() As cUndoRestore
            Dim oRestore As cUndoRestoreDesign = New cUndoRestoreDesign(MyBase.Area)
            For Each oFirstItem As cUndoItemValueDesignPropertyData In oFirstItems.OrderBy(Function(oItem) oItem.Index)
                Dim oItem As cItem = oFirstItem.Layer.Items(oFirstItem.Index)
                Call pSetData(oItem, oFirstItem)
                Call oRestore.Append(oItem)
            Next
            Return oRestore
        End Function

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, PropertyName As String)
            MyBase.New(Parent, Description, Area)
            sPropertyName = PropertyName
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cItem, PropertyName As String)
            MyBase.New(Parent, Description, Area)
            sPropertyName = PropertyName
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
            Call Append(Item)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cItem), ItemType As Type, PropertyName As String)
            MyBase.New(Parent, Description, Area)
            sPropertyName = PropertyName
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
            Call Append(Items)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cItem))
            For Each oItem As cItem In Items
                Call Append(oItem)
            Next
        End Sub

        Friend Sub Append(Item As cItem)
            Call oFirstItems.Add(pGetData(Item))
        End Sub

        Private Function pGetData(Item As cItem) As cUndoItemValueDesignPropertyData
            Dim oBaseObject As Object = Item
            Dim sBasePropertyName As String
            If sPropertyName.Contains(".") Then
                Dim sPropertyNames As String() = sPropertyName.Split(".")
                For i As Integer = 0 To sPropertyNames.Count - 2
                    If sPropertyNames(i) Like "*(*)" Then
                        Dim p As Integer = sPropertyNames(i).IndexOf("("c)
                        Dim sCollectionPropertyName As String = sPropertyNames(i).Substring(0, p)
                        Dim sCollectionReference As String = sPropertyNames(i).Substring(p + 1).TrimEnd(")"c)
                        If IsNumeric(sCollectionReference) Then
                            oBaseObject = CallByName(oBaseObject, sCollectionPropertyName, CallType.Get, {Integer.Parse(sCollectionReference)})
                        Else
                            oBaseObject = CallByName(oBaseObject, sCollectionPropertyName, CallType.Get, {sCollectionReference})
                        End If
                    Else
                        oBaseObject = CallByName(oBaseObject, sPropertyNames(i), CallType.Get)
                    End If
                Next
                sBasePropertyName = sPropertyNames(sPropertyNames.Count - 1)
            Else
                sBasePropertyName = sPropertyName
            End If

            Dim oValue As Object = CallByName(oBaseObject, sBasePropertyName, CallType.Get)
            Return New cUndoItemValueDesignPropertyData(oValue, Item.Layer.Items.IndexOf(Item), Item.Layer)
        End Function

        Private Function pSetData(Item As cItem, Value As cUndoItemValueDesignPropertyData)
            Dim oValue As Object = Value.Value
            Dim oBaseObject As Object = Item
            Dim sBasePropertyName As String
            If sPropertyName.Contains(".") Then
                Dim sPropertyNames As String() = sPropertyName.Split(".")
                For i As Integer = 0 To sPropertyNames.Count - 2
                    If sPropertyNames(i) Like "*(*)" Then
                        Dim p As Integer = sPropertyNames(i).IndexOf("("c)
                        Dim sCollectionPropertyName As String = sPropertyNames(i).Substring(0, p)
                        Dim sCollectionReference As String = sPropertyNames(i).Substring(p + 1).TrimEnd(")"c)
                        If IsNumeric(sCollectionReference) Then
                            oBaseObject = CallByName(oBaseObject, sCollectionPropertyName, CallType.Get, {Integer.Parse(sCollectionReference)})
                        Else
                            oBaseObject = CallByName(oBaseObject, sCollectionPropertyName, CallType.Get, {sCollectionReference})
                        End If
                    Else
                        oBaseObject = CallByName(oBaseObject, sPropertyNames(i), CallType.Get)
                    End If
                Next
                sBasePropertyName = sPropertyNames(sPropertyNames.Count - 1)
            Else
                oBaseObject = Item
                sBasePropertyName = sPropertyName
            End If
            Return CallByName(oBaseObject, sBasePropertyName, CallType.Set, oValue)
        End Function
    End Class

    Public Class cUndoDesignItemNew
        Inherits cUndoItem

        Private oPreviousSelection As cUndoDesignItemSelection
        Private oLastItems As List(Of cUndoItemSelectionDesignData)

        Friend Overrides Function Restore() As cUndoRestore
            For Each oLastItem As cUndoItemSelectionDesignData In oLastItems
                Call oLastItem.Layer.Items.Remove(oLastItem.Index)
            Next
            If oPreviousSelection Is Nothing Then
                Dim oRestore As cUndoRestoreDesign = New cUndoRestoreDesign(MyBase.Area)
                Return oRestore
            Else
                Return oPreviousSelection.Restore
            End If
        End Function

        Friend Sub Commit(Items As IEnumerable(Of cItem))
            oLastItems = New List(Of cUndoItemSelectionDesignData)
            For Each oItem As cItem In Items
                Call oLastItems.Add(New cUndoItemSelectionDesignData(oItem.Layer.Items.IndexOf(oItem), oItem.Layer))
            Next
        End Sub

        Friend Sub Commit(Item As cItem)
            oLastItems = New List(Of cUndoItemSelectionDesignData)
            If Item IsNot Nothing Then
                Call oLastItems.Add(New cUndoItemSelectionDesignData(Item.Layer.Items.IndexOf(Item), Item.Layer))
            End If
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, PreviousSelection As cUndoDesignItemSelection)
            MyBase.New(Parent, Description, Area)
            oPreviousSelection = PreviousSelection
        End Sub
    End Class

    Public Class cUndoDesignItemEdit
        Inherits cUndoItem

        Private oFirstItems As List(Of cUndoItemDataDesignData)
        Private oLastItems As List(Of cUndoItemSelectionDesignData)

        Friend Overrides Function Restore() As cUndoRestore
            For Each oLastItem As cUndoItemSelectionDesignData In oLastItems
                oLastItem.Layer.Items.Remove(oLastItem.Index)
            Next
            Dim oRestore As cUndoRestoreDesign = New cUndoRestoreDesign(MyBase.Area)
            For Each oFirstItem As cUndoItemDataDesignData In oFirstItems.OrderBy(Function(oItem) oItem.Index)
                Dim oItem As cItem = pDeserializeItem(MyBase.Parent.File, oFirstItem)
                Call oRestore.Append(oItem)
            Next
            Return oRestore
        End Function

        Friend Sub Commit(Items As IEnumerable(Of cItem))
            oLastItems = New List(Of cUndoItemSelectionDesignData)
            For Each oItem As cItem In Items
                Call oLastItems.Add(New cUndoItemSelectionDesignData(oItem.Layer.Items.IndexOf(oItem), oItem.Layer))
            Next
        End Sub

        Friend Sub Commit(Item As cItem)
            oLastItems = New List(Of cUndoItemSelectionDesignData)
            If Item IsNot Nothing Then
                Call oLastItems.Add(New cUndoItemSelectionDesignData(Item.Layer.Items.IndexOf(Item), Item.Layer))
            End If
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataDesignData)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cItem)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataDesignData)
            Call Append(Item)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cItem))
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataDesignData)
            Call Append(Items)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cItem))
            For Each oItem As cItem In Items
                Call Append(oItem)
            Next
        End Sub

        Friend Sub Append(Item As cItem)
            Call oFirstItems.Add(pSerializeItem(MyBase.Parent.File, Item))
        End Sub

        Private Function pDeserializeItem(File As cFile, Item As cUndoItemDataDesignData) As cItem
            Dim oItem As cItem = Item.Layer.CreateItem(File, Item.XMLElement.Item("item"))
            Call oItem.Layer.Items.MoveTo(Item.Index, oItem)
            For Each oXMLJoinedPoint As XmlElement In Item.XMLElement.Item("jps")
                Dim sJoinedPointID As String = oXMLJoinedPoint.GetAttribute("id")

                Dim iJoinedPointPointIndex As Integer = oXMLJoinedPoint.GetAttribute("p")

                Dim oPoint As cPoint = oItem.Points(iJoinedPointPointIndex)
                Dim oPointJoin As cPointsJoin = oItem.Design.PointsJoins.Add(sJoinedPointID, oPoint)

                For Each oXMLOtherJoinedPoint As XmlElement In oXMLJoinedPoint.Item("ojp").ChildNodes
                    Dim iOtherJoinedPointPointIndex As Integer = oXMLOtherJoinedPoint.GetAttribute("p")
                    Dim iOtherJoinedPointItemIndex As Integer = oXMLOtherJoinedPoint.GetAttribute("i")
                    Dim iOtherJoinedPointLayerIndex As Integer = oXMLOtherJoinedPoint.GetAttribute("l")
                    oPointJoin.Append(oItem.Design.Layers(iOtherJoinedPointLayerIndex).Items(iOtherJoinedPointItemIndex).Points(iOtherJoinedPointPointIndex))
                Next
            Next
            Return oItem
        End Function

        Private Function pSerializeItem(File As cFile, Item As cItem) As cUndoItemDataDesignData
            Dim oXML As XmlDocument = File.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("i")
            Dim oXMLSourceData As XmlElement = oXML.CreateElement("d")
            Dim oXMLItem As XmlElement = Item.SaveTo(File, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
            oXMLSourceData.AppendChild(oXMLItem)
            Dim oXMLJoinedPoints As XmlElement = oXML.CreateElement("jps")
            For Each oPoint As cPoint In Item.Points.GetJoined()
                Dim oXMLJoinedPoint As XmlElement = oXML.CreateElement("jp")
                oXMLJoinedPoint.SetAttribute("id", oPoint.PointsJoin.ID)
                oXMLJoinedPoint.SetAttribute("p", oPoint.GetIndex())
                Dim oXMLOtherJoinedPoints As XmlElement = oXML.CreateElement("ojp")
                For Each oOtherPoint As cPoint In oPoint.PointsJoin
                    If oOtherPoint IsNot oPoint Then
                        Dim oXMLOtherJoinedPoint As XmlElement = oXML.CreateElement("jp")
                        Dim oLayer As cLayer = oOtherPoint.Item.Layer
                        Dim iItemIndex As Integer = oLayer.Items.IndexOf(oOtherPoint.Item)
                        Dim iPointIndex As Integer = oOtherPoint.Item.Points.IndexOf(oOtherPoint)
                        oXMLOtherJoinedPoint.SetAttribute("l", oLayer.Type.ToString("D"))
                        oXMLOtherJoinedPoint.SetAttribute("i", iItemIndex)
                        oXMLOtherJoinedPoint.SetAttribute("p", iPointIndex)
                        oXMLOtherJoinedPoints.AppendChild(oXMLOtherJoinedPoint)
                    End If
                Next
                oXMLJoinedPoint.AppendChild(oXMLOtherJoinedPoints)
                oXMLJoinedPoints.AppendChild(oXMLJoinedPoint)
            Next
            oXMLSourceData.AppendChild(oXMLJoinedPoints)

            If oXMLSourceData Is Nothing Then
                'TODO: why go here?! must investigate...
                Return New cUndoItemDataDesignData(Nothing, Item.Layer.Items.IndexOf(Item), Item.Layer)
            Else
                Return New cUndoItemDataDesignData(oXMLSourceData, Item.Layer.Items.IndexOf(Item), Item.Layer)
            End If
        End Function
    End Class

    Public Class cUndoDataTrigpointEdit
        Inherits cUndoItem

        Private oFirstItems As List(Of cUndoItemDataTrigpointData)
        Private oLastItems As List(Of cUndoItemSelectionTrigpoint)

        Friend Overrides Function Restore() As cUndoRestore
            For Each oLastItem As cUndoItemSelectionTrigpoint In oLastItems
                oLastItem.Trigpoints.Remove(oLastItem.Trigpoint)
            Next
            Dim oRestore As cUndoRestoreDataTrigPoint = New cUndoRestoreDataTrigPoint(MyBase.Area)
            For Each oFirstItem As cUndoItemDataTrigpointData In oFirstItems.OrderBy(Function(oItem) oItem.Trigpoint)
                Dim oItem As cTrigPoint = pDeserializeItem(MyBase.Parent.File, oFirstItem)
                Call oFirstItem.Trigpoints.Append(oItem)
                Call oRestore.Append(oItem)
            Next
            Return oRestore
        End Function

        Friend Sub Commit(Items As IEnumerable(Of cTrigPoint))
            oLastItems = New List(Of cUndoItemSelectionTrigpoint)
            For Each oItem As cTrigPoint In Items
                Call oLastItems.Add(New cUndoItemSelectionTrigpoint(oItem.Survey.TrigPoints, oItem.Index))
            Next
        End Sub

        Friend Sub Commit(Item As cTrigPoint)
            oLastItems = New List(Of cUndoItemSelectionTrigpoint)
            If Item IsNot Nothing Then
                Call oLastItems.Add(New cUndoItemSelectionTrigpoint(Item.Survey.TrigPoints, Item.Index))
            End If
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataTrigpointData)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cTrigPoint)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataTrigpointData)
            Call Append(Item)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cTrigPoint))
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataTrigpointData)
            Call Append(Items)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cTrigPoint))
            For Each oItem As cTrigPoint In Items
                Call Append(oItem)
            Next
        End Sub

        Friend Sub Append(Item As cTrigPoint)
            Call oFirstItems.Add(pSerializeItem(MyBase.Parent.File, Item))
        End Sub

        Private Function pDeserializeItem(File As cFile, Item As cUndoItemDataTrigpointData) As cTrigPoint
            Return Item.Trigpoints.Append(New cTrigPoint(Item.Trigpoints.Survey, Item.XMLElement))
        End Function

        Private Function pSerializeItem(File As cFile, Item As cTrigPoint) As cUndoItemDataTrigpointData
            Dim oXML As XmlDocument = File.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("i")
            Dim oXMLSourceData As XmlElement = Item.SaveTo(File, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
            If oXMLSourceData Is Nothing Then
                'TODO: why go here?! must investigate...
                Return New cUndoItemDataTrigpointData(Nothing, Item.Name, Item.Survey.TrigPoints)
            Else
                Return New cUndoItemDataTrigpointData(oXMLSourceData, Item.Name, Item.Survey.TrigPoints)
            End If
        End Function
    End Class

    Public Class cUndoDataSegmentEdit
        Inherits cUndoItem

        Private oFirstItems As List(Of cUndoItemDataSegmentData)
        Private oLastItems As List(Of cUndoItemSelectionSegment)

        Friend Overrides Function Restore() As cUndoRestore
            For Each oLastItem As cUndoItemSelectionSegment In oLastItems
                oLastItem.Segments.Remove(oLastItem.Index)
            Next
            Dim oRestore As cUndoRestoreDataSegment = New cUndoRestoreDataSegment(MyBase.Area)
            For Each oFirstItem As cUndoItemDataSegmentData In oFirstItems.OrderBy(Function(oItem) oItem.Index)
                Dim oItem As cSegment = pDeserializeItem(MyBase.Parent.File, oFirstItem)
                oFirstItem.Segments.Insert(oFirstItem.Index, oItem)
                Call oRestore.Append(oItem)
            Next
            Return oRestore
        End Function

        Friend Sub Commit(Items As IEnumerable(Of cSegment))
            oLastItems = New List(Of cUndoItemSelectionSegment)
            For Each oItem As cSegment In Items
                Call oLastItems.Add(New cUndoItemSelectionSegment(oItem.Survey.Segments, oItem.Index))
            Next
        End Sub

        Friend Sub Commit(Item As cSegment)
            oLastItems = New List(Of cUndoItemSelectionSegment)
            If Item IsNot Nothing Then
                Call oLastItems.Add(New cUndoItemSelectionSegment(Item.Survey.Segments, Item.Index))
            End If
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataSegmentData)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cSegment)
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataSegmentData)
            Call Append(Item)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cSegment))
            MyBase.New(Parent, Description, Area)
            oFirstItems = New List(Of cUndoItemDataSegmentData)
            Call Append(Items)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cSegment))
            For Each oItem As cSegment In Items
                Call Append(oItem)
            Next
        End Sub

        Friend Sub Append(Item As cSegment)
            Call oFirstItems.Add(pSerializeItem(MyBase.Parent.File, Item))
        End Sub

        Private Function pDeserializeItem(File As cFile, Item As cUndoItemDataSegmentData) As cSegment
            Return Item.Segments.Append(New cSegment(Item.Segments.Survey, File, Item.XMLElement))
        End Function

        Private Function pSerializeItem(File As cFile, Item As cSegment) As cUndoItemDataSegmentData
            Dim oXML As XmlDocument = File.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("i")
            Dim oXMLSourceData As XmlElement = Item.SaveTo(File, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
            If oXMLSourceData Is Nothing Then
                'TODO: why go here?! must investigate...
                Return New cUndoItemDataSegmentData(Nothing, Item.Index, Item.Survey.Segments)
            Else
                Return New cUndoItemDataSegmentData(oXMLSourceData, Item.Index, Item.Survey.Segments)
            End If
        End Function
    End Class

    Public MustInherit Class cUndoRestore
        Private iArea As cAreaEnum

        Public Sub New(Area As cAreaEnum)
            iArea = Area
        End Sub

        Public ReadOnly Property Area As cAreaEnum
            Get
                Return iArea
            End Get
        End Property
    End Class

    Public Class cUndoRestoreDataTrigPoint
        Inherits cUndoRestore

        Private oTrigpoint As cTrigPoint

        Public ReadOnly Property Trigpoint As cTrigPoint
            Get
                Return oTrigpoint
            End Get
        End Property

        Public Sub New(Area As cAreaEnum, Trigpoint As cTrigPoint)
            MyBase.New(Area)
            oTrigpoint = Trigpoint
        End Sub

        Public Sub New(Area As cAreaEnum)
            MyBase.New(Area)
        End Sub

        Public Sub Append(Trigpoint As cTrigPoint)
            oTrigpoint = Trigpoint
        End Sub
    End Class

    Public Class cUndoRestoreDataSegment
        Inherits cUndoRestore

        Private oSegment As cSegment

        Public ReadOnly Property Segment As cSegment
            Get
                Return oSegment
            End Get
        End Property

        Public Sub New(Area As cAreaEnum, Segment As cSegment)
            MyBase.New(Area)
            oSegment = Segment
        End Sub

        Public Sub New(Area As cAreaEnum)
            MyBase.New(Area)
        End Sub

        Public Sub Append(Segment As cSegment)
            oSegment = Segment
        End Sub
    End Class

    Public Class cUndoRestoreDesign
        Inherits cUndoRestore

        Private oItems As List(Of cItem)

        Public ReadOnly Property Items As List(Of cItem)
            Get
                Return oItems
            End Get
        End Property

        Public Sub New(Area As cAreaEnum, Items As IEnumerable(Of cItem))
            MyBase.New(Area)
            oItems = New List(Of cItem)({Items})
        End Sub

        Public Sub New(Area As cAreaEnum, Item As cItem)
            MyBase.New(Area)
            oItems = New List(Of cItem)({Item})
        End Sub

        Public Sub New(Area As cAreaEnum)
            MyBase.New(Area)
            oItems = New List(Of cItem)
        End Sub

        Public Sub Append(Item As cItem)
            Call oItems.Add(Item)
        End Sub

    End Class

    Public Delegate Function cUndoPropertyOwnerDelegate() As Object

    Public Class cUndo
        Implements IEnumerable

        Private oSurvey As cSurveyPC.cSurvey.cSurvey
        Private oParent As cEditTools
        Private oFile As cFile
        Private oItems As Stack(Of cUndoItem)

        Private Const iUndoMaxItems As Integer = 1024

        Friend Event OnChanged(sender As Object, e As EventArgs)

        'Public Enum cUndoActionEnum
        '    Add = 1
        '    Edit = 0
        '    Delete = 2
        'End Enum

        Public Enum cAreaEnum
            DesignPlan = 0
            DesignProfile = 1
            DataSegments = 2
            DataShots = 3
            Design3D = 4
            All = 99
        End Enum

        Private oCurrentUndoItem As cUndoItem

        Friend ReadOnly Property Parent As cEditTools
            Get
                Return oParent
            End Get
        End Property

        Public Sub Clear()
            oCurrentUndoItem = Nothing
            Call oItems.Clear()
        End Sub

        ''' <summary>
        ''' There is at least one undo action
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsUndoable As Boolean
            Get
                Return oItems.Count > 0
            End Get
        End Property

        ''' <summary>
        ''' Perform an undo action
        ''' </summary>
        Public Function RestoreSnapshot() As cUndoRestore
            If oItems.Count > 0 Then
                Dim oCurrentUndoItem As cUndoItem = oItems.Pop
                Return oCurrentUndoItem.Restore()
            End If
        End Function

        'Private oLastItem As Object
        Private sLastDescription As String = ""

        Private oLastSelectionItem As cUndoItemSelection

        Public Function CreateSelectionSnapshot(Area As cAreaEnum) As Boolean
            Dim oSelectionItem As cUndoItemSelection
            Select Case Area
                Case cAreaEnum.DesignPlan
                    Dim oItem As cItem = oParent.PlanTools.CurrentItem
                    If oItem IsNot Nothing Then
                        If TypeOf oItem Is cItemItems Then
                            oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, DirectCast(oItem, IEnumerable(Of cItem)))
                        Else
                            oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, oItem)
                        End If
                    End If
                Case cAreaEnum.DesignProfile
                    Dim oItem As cItem = oParent.ProfileTools.CurrentItem
                    If oItem IsNot Nothing Then
                        If TypeOf oItem Is cItemItems Then
                            oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, DirectCast(oItem, IEnumerable(Of cItem)))
                        Else
                            oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, oItem)
                        End If
                    End If
                Case cAreaEnum.DataSegments
                    Dim oSegment As cSegment = oParent.CurrentSegment
                    If oSegment IsNot Nothing Then
                        oSelectionItem = New cUndoDataSegmentSelection(Me, "Selection", Area, oSegment)
                    End If
                Case cAreaEnum.DataShots
                    Dim oTrigpoint As cTrigPoint = oParent.CurrentTrigpoint
                    If oTrigpoint IsNot Nothing Then
                        oSelectionItem = New cUndoDataTrigpointSelection(Me, "Selection", Area, oTrigpoint)
                    End If
                Case cAreaEnum.All
                    Throw New Exception("Unsupported")
            End Select
            If oSelectionItem Is Nothing Then
                Return False
            Else
                oLastSelectionItem = oSelectionItem
                Return True
            End If
        End Function

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Function CreateSnapshot(Description As String, Area As cAreaEnum, PropertyName As String) As Boolean
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        If oItem IsNot Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)), PropertyName)
                            Else
                                oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, oItem, PropertyName)
                            End If
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        If oItem IsNot Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)), PropertyName)
                            Else
                                oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, oItem, PropertyName)
                            End If
                        End If
                    Case cAreaEnum.DataSegments
                        Throw New Exception("Unsupported")
                    Case cAreaEnum.DataShots
                        Throw New Exception("Unsupported")
                    Case cAreaEnum.All
                        Throw New Exception("Unsupported")
                End Select
                If oCurrentUndoItem Is Nothing Then
                    Return False
                Else
                    Call oItems.Push(oCurrentUndoItem)
                    oCurrentUndoItem = Nothing
                    RaiseEvent OnChanged(Me, EventArgs.Empty)
                    Return True
                End If
            End If
        End Function

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Function CreateSnapshot(Description As String, Area As cAreaEnum, BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate) As Boolean
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        If oItem IsNot Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemDelegatedProperty(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)), BackupDelegate, RestoreDelegate)
                            Else
                                oCurrentUndoItem = New cUndoDesignItemDelegatedProperty(Me, Description, Area, oItem, BackupDelegate, RestoreDelegate)
                            End If
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        If oItem IsNot Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemDelegatedProperty(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)), BackupDelegate, RestoreDelegate)
                            Else
                                oCurrentUndoItem = New cUndoDesignItemDelegatedProperty(Me, Description, Area, oItem, BackupDelegate, RestoreDelegate)
                            End If
                        End If
                    Case cAreaEnum.DataSegments
                        Throw New Exception("Unsupported")
                    Case cAreaEnum.DataShots
                        Throw New Exception("Unsupported")
                    Case cAreaEnum.All
                        Throw New Exception("Unsupported")
                End Select
                If oCurrentUndoItem Is Nothing Then
                    Return False
                Else
                    Call oItems.Push(oCurrentUndoItem)
                    oCurrentUndoItem = Nothing
                    RaiseEvent OnChanged(Me, EventArgs.Empty)
                    Return True
                End If
            End If
        End Function

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Function CreateSnapshot(Description As String, Area As cAreaEnum) As Boolean
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        If oItem IsNot Nothing Then
                            oCurrentUndoItem = New cUndoDesignItemNew(Me, Description, Area, oLastSelectionItem)
                            If TypeOf oItem Is cItemItems Then
                                DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(oItem)
                            End If
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        If oItem IsNot Nothing Then
                            oCurrentUndoItem = New cUndoDesignItemNew(Me, Description, Area, oLastSelectionItem)
                            If TypeOf oItem Is cItemItems Then
                                DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(oItem)
                            End If
                        End If
                    Case cAreaEnum.DataSegments
                        'oCurrentUndoItem = New cUndoDataSegmentEdit(Me, Description, Area, oParent.CurrentSegment)
                    Case cAreaEnum.DataShots
                        'oCurrentUndoItem = New cUndoDatatrigpointEdit(Me, Description, Area, oParent.CurrentSegment)
                End Select
                If oCurrentUndoItem Is Nothing Then
                    Return False
                Else
                    Call oItems.Push(oCurrentUndoItem)
                    oCurrentUndoItem = Nothing
                    RaiseEvent OnChanged(Me, EventArgs.Empty)
                    Return True
                End If
            End If
        End Function

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Items">Items to be restored</param>
        Public Function CreateSnapshot(Description As String, Items As IEnumerable(Of cItem)) As Boolean
            If oCurrentUndoItem Is Nothing AndAlso Items.Count > 0 Then
                Dim iArea As cAreaEnum = If(Items(0).Design.Type = cIDesign.cDesignTypeEnum.Plan, cAreaEnum.DesignPlan, cAreaEnum.DesignProfile)
                oCurrentUndoItem = New cUndoDesignItemNew(Me, Description, iArea, oLastSelectionItem)
                DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(Items)
                Call oItems.Push(oCurrentUndoItem)
                oCurrentUndoItem = Nothing
                RaiseEvent OnChanged(Me, EventArgs.Empty)
                Return True
            End If
        End Function

        ''' <summary>
        ''' Start and undo snapshot with specific design items. Area will be taken from first item.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Items">Items to be restored</param>
        Public Function BeginSnapshot(Description As String, Items As IEnumerable(Of cItem)) As Boolean
            If oCurrentUndoItem Is Nothing AndAlso Items.Count > 0 Then
                Dim iArea As cAreaEnum = If(Items(0).Design.Type = cIDesign.cDesignTypeEnum.Plan, cAreaEnum.DesignPlan, cAreaEnum.DesignProfile)
                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, iArea, Items)
                'oLastItem = oItem
                sLastDescription = Description
                Return True
            End If
        End Function

        ''' <summary>
        ''' Start and undo snapshot with working area's selected item
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Function BeginSnapshot(Description As String, Area As cAreaEnum) As Boolean
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.Design3D
                        oItem = oParent.ThreeDTools.CurrentItem
                        If oItem IsNot Nothing Then
                            oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, oItem)
                        End If
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        If oItem IsNot Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, oItem)
                            End If
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        If oItem IsNot Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, oItem)
                            End If
                        End If
                    Case cAreaEnum.DataSegments
                        If oParent.CurrentSegment IsNot Nothing Then
                            oCurrentUndoItem = New cUndoDataSegmentEdit(Me, Description, Area, oParent.CurrentSegment)
                        End If
                    Case cAreaEnum.DataShots
                        If oParent.CurrentTrigpoint IsNot Nothing Then
                            oCurrentUndoItem = New cUndoDataTrigpointEdit(Me, Description, Area, oParent.CurrentTrigpoint)
                        End If
                End Select
                If oCurrentUndoItem IsNot Nothing Then
                    sLastDescription = Description
                    Return True
                End If
            End If
        End Function

        ''' <summary>
        ''' Add stations to current snapshot
        ''' </summary>
        ''' <param name="Items">Items to be added</param>
        Public Sub AppendSnapshot(Items As IEnumerable(Of cTrigPoint))
            If oCurrentUndoItem Is Nothing Then
                Throw New Exception("Append without begin")
            Else
                If TypeOf oCurrentUndoItem Is cUndoDataTrigpointEdit Then
                    DirectCast(oCurrentUndoItem, cUndoDataTrigpointEdit).Append(oItems)
                Else
                    Throw New Exception("Append not allowed for this kind of snapshot")
                End If
            End If
        End Sub

        ''' <summary>
        ''' Add segments to current snapshot
        ''' </summary>
        ''' <param name="Items">Items to be added</param>
        Public Sub AppendSnapshot(Items As IEnumerable(Of cSegment))
            If oCurrentUndoItem Is Nothing Then
                Throw New Exception("Append without begin")
            Else
                If TypeOf oCurrentUndoItem Is cUndoDataSegmentEdit Then
                    DirectCast(oCurrentUndoItem, cUndoDataSegmentEdit).Append(oItems)
                Else
                    Throw New Exception("Append not allowed for this kind of snapshot")
                End If
            End If
        End Sub

        ''' <summary>
        ''' Add items to current snapshot
        ''' </summary>
        ''' <param name="Items">Items to be added</param>
        Public Sub AppendSnapshot(Items As IEnumerable(Of cItem))
            If oCurrentUndoItem Is Nothing Then
                Throw New Exception("Append without begin")
            Else
                If TypeOf oCurrentUndoItem Is cUndoDesignItemEdit Then
                    DirectCast(oCurrentUndoItem, cUndoDesignItemEdit).Append(oItems)
                Else
                    Throw New Exception("Append not allowed for this kind of snapshot")
                End If
            End If
        End Sub

        Friend ReadOnly Property File As cFile
            Get
                Return oFile
            End Get
        End Property

        ''' <summary>
        ''' Return if there is a open snapshot or not
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsBeginned As Boolean
            Get
                Return oCurrentUndoItem IsNot Nothing
            End Get
        End Property

        ''' <summary>
        ''' Ends an undo snapshot in the current area and with the selected area's items
        ''' </summary>
        Public Sub CommitSnapshot()
            If oCurrentUndoItem Is Nothing Then
                Throw New Exception("Commit without begin")
            Else
                Dim oItem As cItem
                Select Case oCurrentUndoItem.Area
                    Case cAreaEnum.Design3D
                        If TypeOf oCurrentUndoItem Is cUndoDesignItemEdit Then
                            Dim oCurrentDesignUndoItem As cUndoDesignItemEdit = oCurrentUndoItem
                            oItem = oParent.PlanTools.CurrentItem
                            Call oCurrentDesignUndoItem.Commit(oItem)
                        End If
                    Case cAreaEnum.DesignPlan
                        If TypeOf oCurrentUndoItem Is cUndoDesignItemEdit Then
                            Dim oCurrentDesignUndoItem As cUndoDesignItemEdit = oCurrentUndoItem
                            oItem = oParent.PlanTools.CurrentItem
                            If TypeOf oItem Is cItemItems Then
                                Call oCurrentDesignUndoItem.Commit(DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                Call oCurrentDesignUndoItem.Commit(oItem)
                            End If
                        End If
                    Case cAreaEnum.DesignProfile
                        If TypeOf oCurrentUndoItem Is cUndoDesignItemEdit Then
                            Dim oCurrentDesignUndoItem As cUndoDesignItemEdit = oCurrentUndoItem
                            oItem = oParent.ProfileTools.CurrentItem
                            If TypeOf oItem Is cItemItems Then
                                Call oCurrentDesignUndoItem.Commit(DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                Call oCurrentDesignUndoItem.Commit(oItem)
                            End If
                        End If
                End Select
                'check if last snapshot is selection...if true delete it
                If oItems.Count > 0 AndAlso TypeOf oItems.First Is cUndoDesignItemSelection Then
                    Call oItems.Pop()
                End If
                Call oItems.Push(oCurrentUndoItem)
                oCurrentUndoItem = Nothing
                RaiseEvent OnChanged(Me, EventArgs.Empty)
            End If
        End Sub

        Public Sub RemoveSnapshot()
            Call oItems.Pop()
        End Sub

        ''' <summary>
        ''' Delete the current undo snapshot without saving it
        ''' </summary>
        Public Sub CancelSnapshot()
            oCurrentUndoItem = Nothing
        End Sub

        Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Parent As cEditTools)
            oSurvey = Survey
            oParent = Parent
            oItems = New Stack(Of cUndoItem)(iUndoMaxItems)
            oFile = New cFile()
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property
    End Class

    'Public Class cUndo
    '    Implements IEnumerable

    '    Private bSuspended As Boolean
    '    Private Const iUndoMaxItems As Integer = 1024

    '    Private oSurvey As cSurveyPC.cSurvey.cSurvey
    '    Private oParent As cEditTools
    '    Private oFile As cFile
    '    Private oItems As Stack(Of cUndoItem)

    '    Private sLastSourceData As String
    '    Private iLastAction As ActionEnum
    '    Private bFirstUndo As Boolean

    '    Friend Class cUndoEventArgs
    '        Private oItem As cUndoItem

    '        Public ReadOnly Property Item As cUndoItem
    '            Get
    '                Return oItem
    '            End Get
    '        End Property

    '        Public Sub New(Item As cUndoItem)
    '            oItem = Item
    '        End Sub
    '    End Class

    '    Friend Event OnCancel(Sender As cUndo, EventArgs As cUndoEventArgs)
    '    Friend Event OnPop(Sender As cUndo, EventArgs As cUndoEventArgs)
    '    Friend Event OnPush(Sender As cUndo, EventArgs As cUndoEventArgs)

    '    Public Enum ObjectTypeEnum
    '        Segment = 0
    '        Item = 1
    '    End Enum

    '    Public Enum ActionEnum
    '        None = 0
    '        Update = 1
    '        Insert = 2
    '        Delete = 3
    '        Move = 4
    '    End Enum

    '    Public Sub Push(ByVal Description As String, ByVal Action As ActionEnum, ByVal Segment As cSurveyPC.cSurvey.cSegment, Optional ByVal Index As Integer = 0, Optional ByVal OldIndex As Integer = 0)
    '        If Not bSuspended Then
    '            Dim oXML As XmlDocument = oFile.Document
    '            Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
    '            Dim oSourceData As XmlElement = Segment.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.ForClipboard)
    '            Dim sSourceData As String = oSourceData.OuterXml
    '            If sSourceData <> sLastSourceData Or iLastAction <> Action Then
    '                Dim oItem As cUndoItem = New cUndoItem(Action, Description, Nothing, ObjectTypeEnum.Segment, oSourceData, Index, OldIndex)
    '                bFirstUndo = True
    '                sLastSourceData = sSourceData
    '                iLastAction = Action
    '                Call oItems.Push(oItem)
    '                RaiseEvent OnPush(Me, New cUndoEventArgs(oItem))
    '            End If
    '        End If
    '    End Sub

    '    Public Sub Push(ByVal Description As String, ByVal Action As ActionEnum, ByVal Layer As cLayer, ByVal Item As cSurveyPC.cSurvey.Design.cItem, Optional ByVal Index As Integer = 0, Optional ByVal OldIndex As Integer = 0)
    '        If Not bSuspended Then
    '            Try
    '                Dim oXML As XmlDocument = oFile.Document
    '                Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
    '                Dim oSourceData As XmlElement = Item.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
    '                If Not oSourceData Is Nothing Then
    '                    Dim sSourceData As String = oSourceData.OuterXml
    '                    If sSourceData <> sLastSourceData Or iLastAction <> Action Then
    '                        Dim oItem As cUndoItem = New cUndoItem(Action, Description, Layer, ObjectTypeEnum.Item, oSourceData, Index, OldIndex)
    '                        bFirstUndo = True
    '                        sLastSourceData = sSourceData
    '                        iLastAction = Action
    '                        Call oItems.Push(oItem)
    '                        RaiseEvent OnPush(Me, New cUndoEventArgs(oItem))
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                Debug.Print("UNDO ERROR:" & ex.Message)
    '            End Try
    '        End If
    '    End Sub

    '    Public ReadOnly Property Item(Index As Integer) As cUndoItem
    '        Get
    '            Return oItems(Index)
    '        End Get
    '    End Property

    '    Public Function Peek() As cUndoItem
    '        Return oItems.Peek
    '    End Function

    '    Public ReadOnly Property Count As Integer
    '        Get
    '            Return oItems.Count
    '        End Get
    '    End Property

    '    Public Sub Pop()
    '        bSuspended = True
    '        If oItems.Count > 0 Then
    '            Dim oItem As cUndoItem = oItems.Pop()
    '            RaiseEvent OnPop(Me, New cUndoEventArgs(oItem))
    '            Select Case oItem.SourceObjectType
    '                Case ObjectTypeEnum.Segment
    '                    Select Case oItem.Action
    '                        Case ActionEnum.Update
    '                            Dim oCurrentSegment As cSegment = oSurvey.Segments(oItem.Index)
    '                            Call oSurvey.Segments.Remove(oCurrentSegment)
    '                            Dim oXMLItem As XmlElement = oItem.SourceData
    '                            Dim oSegment As cSegment = New cSegment(oSurvey, oFile, oXMLItem)
    '                            Call oSurvey.Segments.Append(oSegment)
    '                            Call oSurvey.Segments.MoveTo(oItem.Index, oSegment)
    '                            Call oParent.SelectSegment(oSegment)
    '                        Case ActionEnum.Insert
    '                            Call oSurvey.Segments.Remove(oItem.Index)
    '                        Case ActionEnum.Delete
    '                            Dim oXMLItem As XmlElement = oItem.SourceData
    '                            Dim oSegment As cSegment = New cSegment(oSurvey, oFile, oXMLItem)
    '                            Call oSurvey.Segments.Append(oSegment)
    '                            Call oSurvey.Segments.MoveTo(oItem.Index, oSegment)
    '                            Call oParent.SelectSegment(oSegment)
    '                        Case ActionEnum.Move
    '                            Call oSurvey.Segments.MoveTo(oItem.OldIndex, oSurvey.Segments(oItem.Index))
    '                    End Select
    '                Case ObjectTypeEnum.Item
    '                    Select Case oItem.Action
    '                        Case ActionEnum.Update
    '                            'ripristino l'oggetto come era prima della modifica...
    '                            Dim oLayer As cLayer = oItem.Parent
    '                            Dim oCurrentItem As cItem = oLayer.Items(oItem.Index)
    '                            Call oLayer.Items.Remove(oCurrentItem)
    '                            Dim oXMLItem As XmlElement = oItem.SourceData
    '                            Dim oDesignItem As cItem = oLayer.CreateItem(oFile, oXMLItem)
    '                            Call oLayer.Items.MoveTo(oItem.Index, oDesignItem)
    '                            Call oParent.GetDesignTools(oLayer).SelectItem(oDesignItem)
    '                        Case ActionEnum.Insert
    '                            Dim oLayer As cLayer = oItem.Parent
    '                            Call oLayer.Items.Remove(oItem.Index)
    '                        Case ActionEnum.Delete
    '                            Dim oLayer As cLayer = oItem.Parent
    '                            Dim oXMLItem As XmlElement = oItem.SourceData
    '                            Dim oDesignItem As cItem = oLayer.CreateItem(oFile, oXMLItem)
    '                            Call oLayer.Items.MoveTo(oItem.Index, oDesignItem)
    '                            Call oParent.GetDesignTools(oLayer).SelectItem(oDesignItem)
    '                        Case ActionEnum.Move
    '                            Dim oLayer As cLayer = oItem.Parent
    '                            Call oLayer.Items.MoveTo(oItem.OldIndex, oLayer.Items(oItem.Index))
    '                    End Select
    '            End Select
    '        End If
    '        bSuspended = False
    '    End Sub

    '    Public Sub Cancel()
    '        If oItems.Count > 0 Then
    '            Dim oItem As cUndoItem = oItems.Pop
    '            RaiseEvent OnCancel(Me, New cUndoEventArgs(oItem))
    '        End If
    '    End Sub

    '    Public ReadOnly Property IsUndoable As Boolean
    '        Get
    '            Return oItems.Count > 0
    '        End Get
    '    End Property

    '    Public Sub Clear()
    '        Call oItems.Clear()
    '    End Sub

    '    Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Parent As cEditTools)
    '        oSurvey = Survey
    '        oParent = Parent
    '        oItems = New Stack(Of cUndoItem)(iUndoMaxItems)
    '        oFile = New cFile()
    '    End Sub

    '    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
    '        Return oItems.GetEnumerator
    '    End Function
    'End Class
End Namespace
