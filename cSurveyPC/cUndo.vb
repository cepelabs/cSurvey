Imports System.IO
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

    Public Class cUndoDesignItemProperty
        Inherits cUndoItem

        Private sPropertyName As String

        Private oFirstItems As List(Of cUndoItemValueDesignPropertyData)

        Friend Overrides Function Restore() As cUndoRestore
            Dim oRestore As cUndoRestoreDesign = New cUndoRestoreDesign(MyBase.Area)
            For Each oFirstItem As cUndoItemValueDesignPropertyData In oFirstItems.OrderBy(Function(oItem) oItem.Index)
                Dim oItem As cItem = oFirstItem.Layer.Items(oFirstItem.Index)
                Call pSetData(oItem, sPropertyName, oFirstItem.Value)
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
            Call Append(Item, PropertyName)
        End Sub

        Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cItem), PropertyName As String)
            MyBase.New(Parent, Description, Area)
            sPropertyName = PropertyName
            oFirstItems = New List(Of cUndoItemValueDesignPropertyData)
            Call Append(Items, PropertyName)
        End Sub

        Friend Sub Append(Items As IEnumerable(Of cItem), PropertyName As String)
            For Each oItem As cItem In Items
                Call Append(oItem, PropertyName)
            Next
        End Sub

        Friend Sub Append(Item As cItem, PropertyName As String)
            Call oFirstItems.Add(pGetData(Item, PropertyName))
        End Sub

        Private Function pGetData(Item As cItem, PropertyName As String) As cUndoItemValueDesignPropertyData
            Dim oValue As Object = CallByName(Item, PropertyName, CallType.Get)
            Return New cUndoItemValueDesignPropertyData(oValue, Item.Layer.Items.IndexOf(Item), Item.Layer)
        End Function

        Private Function pSetData(Item As cItem, PropertyName As String, Value As cUndoItemValueDesignPropertyData)
            Dim oValue As Object = Value.Value
            Return CallByName(Item, PropertyName, CallType.Set, oValue)
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

        'Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Item As cItem)
        '    MyBase.New(Parent, Description, Area)
        '    oFirstItems = New List(Of cUndoItemSelectionDesignData)
        '    Call Append(Item)
        'End Sub

        'Friend Sub New(Parent As cUndo, Description As String, Area As cAreaEnum, Items As IEnumerable(Of cItem))
        '    MyBase.New(Parent, Description, Area)
        '    oFirstItems = New List(Of cUndoItemSelectionDesignData)
        '    Call Append(Items)
        'End Sub
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
                Call oItem.Layer.Items.MoveTo(oFirstItem.Index, oItem)
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
            Return Item.Layer.CreateItem(File, Item.XMLElement)
        End Function

        Private Function pSerializeItem(File As cFile, Item As cItem) As cUndoItemDataDesignData
            Dim oXML As XmlDocument = File.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("i")
            Dim oXMLSourceData As XmlElement = Item.SaveTo(File, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
            If oXMLSourceData Is Nothing Then
                'TODO: why go here?! must investigate...
                Return New cUndoItemDataDesignData(Nothing, Item.Layer.Items.IndexOf(Item), Item.Layer)
            Else
                Return New cUndoItemDataDesignData(oXMLSourceData, Item.Layer.Items.IndexOf(Item), Item.Layer)
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


    Public Class cUndo
        Implements IEnumerable

        Private oSurvey As cSurveyPC.cSurvey.cSurvey
        Private oParent As cEditTools
        Private oFile As cFile
        Private oItems As Stack(Of cUndoItem)

        Private Const iUndoMaxItems As Integer = 1024

        Friend Event OnChanged(sender As Object, e As EventArgs)

        Public Enum cUndoActionEnum
            Add = 1
            Edit = 0
            Delete = 2
        End Enum

        Public Enum cAreaEnum
            DesignPlan = 0
            DesignProfile = 1
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

        Public Sub CreateSelectionSnapshot(Area As cAreaEnum)
            Dim oSelectionItem As cUndoItemSelection
            Select Case Area
                Case cAreaEnum.DesignPlan
                    Dim oItem As cItem = oParent.PlanTools.CurrentItem
                    If TypeOf oItem Is cItemItems Then
                        oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, DirectCast(oItem, IEnumerable(Of cItem)))
                    Else
                        oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, oItem)
                    End If
                Case cAreaEnum.DesignProfile
                    Dim oItem As cItem = oParent.ProfileTools.CurrentItem
                    If TypeOf oItem Is cItemItems Then
                        oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, DirectCast(oItem, IEnumerable(Of cItem)))
                    Else
                        oSelectionItem = New cUndoDesignItemSelection(Me, "Selection", Area, oItem)
                    End If
            End Select
            oLastSelectionItem = oSelectionItem
        End Sub

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Sub CreateSnapshot(Description As String, Area As cAreaEnum, PropertyName As String)
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        If TypeOf oItem Is cItemItems Then
                            oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)), PropertyName)
                        Else
                            oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, oItem, PropertyName)
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        If TypeOf oItem Is cItemItems Then
                            oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)), PropertyName)
                        Else
                            oCurrentUndoItem = New cUndoDesignItemProperty(Me, Description, Area, oItem, PropertyName)
                        End If
                End Select
                Call oItems.Push(oCurrentUndoItem)
                oCurrentUndoItem = Nothing
                RaiseEvent OnChanged(Me, EventArgs.Empty)
            End If
        End Sub

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Sub CreateSnapshot(Description As String, Area As cAreaEnum)
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        oCurrentUndoItem = New cUndoDesignItemNew(Me, Description, Area, oLastSelectionItem)
                        If TypeOf oItem Is cItemItems Then
                            DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(DirectCast(oItem, IEnumerable(Of cItem)))
                        Else
                            DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(oItem)
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        oCurrentUndoItem = New cUndoDesignItemNew(Me, Description, Area, oLastSelectionItem)
                        If TypeOf oItem Is cItemItems Then
                            DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(DirectCast(oItem, IEnumerable(Of cItem)))
                        Else
                            DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(oItem)
                        End If
                End Select
                Call oItems.Push(oCurrentUndoItem)
                oCurrentUndoItem = Nothing
                RaiseEvent OnChanged(Me, EventArgs.Empty)
            End If
        End Sub

        ''' <summary>
        ''' Create an undo snapshot with not starting item and with working area's selected item as action's result. Usefull for item's creation.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Items">Items to be restored</param>
        Public Sub CreateSnapshot(Description As String, Items As IEnumerable(Of cItem))
            If oCurrentUndoItem Is Nothing AndAlso Items.Count > 0 Then
                Dim iArea As cAreaEnum = If(Items(0).Design.Type = cIDesign.cDesignTypeEnum.Plan, cAreaEnum.DesignPlan, cAreaEnum.DesignProfile)
                oCurrentUndoItem = New cUndoDesignItemNew(Me, Description, iArea, oLastSelectionItem)
                DirectCast(oCurrentUndoItem, cUndoDesignItemNew).Commit(Items)
                Call oItems.Push(oCurrentUndoItem)
                oCurrentUndoItem = Nothing
                RaiseEvent OnChanged(Me, EventArgs.Empty)
            End If
        End Sub

        ''' <summary>
        ''' Start and undo snapshot with specific design items. Area will be taken from first item.
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Items">Items to be restored</param>
        Public Sub BeginSnapshot(Description As String, Items As IEnumerable(Of cItem))
            If oCurrentUndoItem Is Nothing AndAlso Items.Count > 0 Then
                Dim iArea As cAreaEnum = If(Items(0).Design.Type = cIDesign.cDesignTypeEnum.Plan, cAreaEnum.DesignPlan, cAreaEnum.DesignProfile)
                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, iArea, Items)
                'oLastItem = oItem
                sLastDescription = Description
            End If
        End Sub

        ''' <summary>
        ''' Start and undo snapshot with working area's selected item
        ''' </summary>
        ''' <param name="Description">Action's description</param>
        ''' <param name="Area">Working area</param>
        Public Sub BeginSnapshot(Description As String, Area As cAreaEnum)
            If oCurrentUndoItem Is Nothing Then
                Dim oItem As cItem
                Select Case Area
                    Case cAreaEnum.DesignPlan
                        oItem = oParent.PlanTools.CurrentItem
                        If Not oItem Is Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, oItem)
                            End If
                        End If
                    Case cAreaEnum.DesignProfile
                        oItem = oParent.ProfileTools.CurrentItem
                        If Not oItem Is Nothing Then
                            If TypeOf oItem Is cItemItems Then
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, DirectCast(oItem, IEnumerable(Of cItem)))
                            Else
                                oCurrentUndoItem = New cUndoDesignItemEdit(Me, Description, Area, oItem)
                            End If
                        End If
                End Select
                sLastDescription = Description
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
