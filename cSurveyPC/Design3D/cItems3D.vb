Imports System.Xml

Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design.Design3D
    Public Class cItems3D
        Implements IEnumerable(Of cItem3D)
        Private oSurvey As cSurvey
        Private oDesign As cDesign3D
        Private oLayer As cLayer3D

        Private oItems As List(Of cItem3D)

        Public ReadOnly Property First() As cItem3D
            Get
                If oItems.Count > 0 Then
                    Return oItems(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Last() As cItem3D
            Get
                If oItems.Count > 0 Then
                    Return oItems(oItems.Count - 1)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function [Next](Item As cItem3D) As cItem3D
            If Item Is oItems.Last Then
                Return Nothing
            Else
                Return oItems(oItems.IndexOf(Item) + 1)
            End If
        End Function

        Public Function [Previous](Item As cItem3D) As cItem3D
            If Item Is oItems.First Then
                Return Nothing
            Else
                Return oItems(oItems.IndexOf(Item) - 1)
            End If
        End Function

        Friend Sub Insert(ByVal Index As Integer, ByVal Item As cItem3D)
            Call oItems.Insert(Index, Item)
        End Sub

        Friend Sub Add(ByVal Item As cItem3D)
            Call oItems.Add(Item)
        End Sub

        Friend Sub AddRange(ByVal Items As IEnumerable(Of cItem3D))
            Call oItems.AddRange(Items)
        End Sub

        Friend ReadOnly Property Design As cDesign3D
            Get
                Return oDesign
            End Get
        End Property

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Layer As cLayer3D
            Get
                Return oLayer
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cItem3D
            Get
                If Index >= 0 And Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Friend Sub Remove(ByVal Item As cItem3D)
            If Not Item Is Nothing Then
                If oItems.Contains(Item) Then
                    Call Item.SetDeleted()
                    Call oItems.Remove(Item)
                End If
            End If
        End Sub

        Friend Sub Remove(ByVal Index As Integer)
            If Index >= 0 And Index < oItems.Count Then
                Dim oItem As cItem3D = oItems(Index)
                Call oItem.SetDeleted()
                Call oItems.RemoveAt(Index)
            End If
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function IndexOf(ByVal Item As cItem3D) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Public Function GetByType(Type As cIItem.cItemTypeEnum) As List(Of cItem3D)
            Return oItems.Where(Function(item) item.Type = Type).ToList
        End Function

        Public Function Contains(ByVal Item As cItem3D) As Boolean
            Return oItems.Contains(Item)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Layer As cLayer3D)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer
            oItems = New List(Of cItem3D)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Layer As cLayer3D, ByVal Items As List(Of cItem3D))
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer
            oItems = New List(Of cItem3D)(Items)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign3D, ByVal Layer As cLayer3D, ByVal File As Storage.cFile, ByVal Items As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer
            oItems = New List(Of cItem3D)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Items.ChildNodes.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oXMLItem As XmlElement In Items.ChildNodes
                iIndex += 1
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("items.textpart1"), iIndex / iCount)
                Dim oItem As cItem3D = Nothing
                Select Case oXMLItem.GetAttribute("type")

                End Select
                If Not oItem Is Nothing Then
                    Call oItems.Add(oItem)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItems As XmlElement = Document.CreateElement("items")
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oItems.Count
            Dim iStep As Integer = IIf(iCount > 20, iCount \ 20, 1)
            For Each oItem As cItem3D In oItems
                iIndex += 1
                If (Options And cSurvey.SaveOptionsEnum.Silent) = 0 Then If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("save", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("items.textpart2"), iIndex / iCount)
                Call oItem.SaveTo(File, Document, oXmlItems, Options)
            Next
            Call Parent.AppendChild(oXmlItems)
            Return oXmlItems
        End Function

        Public Function ToList() As List(Of cItem3D)
            Return oItems.ToList
        End Function

        Public Function ToArray() As cItem3D()
            Return oItems.ToArray
        End Function

        Public Sub SendToBottom(ByVal Item As cItem3D)
            If Contains(Item) Then
                Call oItems.Remove(Item)
                Call oItems.Insert(0, Item)
            End If
        End Sub

        Public Sub BringToTop(ByVal Item As cItem3D)
            If Contains(Item) Then
                Call oItems.Remove(Item)
                Call oItems.Add(Item)
            End If
        End Sub

        Public Sub SendBehind(ByVal Item As cItem3D)
            If Contains(Item) Then
                Dim iIndex As Integer = oItems.IndexOf(Item)
                If iIndex > 0 Then
                    Call oItems.Remove(Item)
                    Call oItems.Insert(iIndex - 1, Item)
                End If
            End If
        End Sub

        Public Sub BringAhead(ByVal Item As cItem3D)
            If Contains(Item) Then
                Dim iIndex As Integer = oItems.IndexOf(Item)
                If iIndex < oItems.Count - 1 Then
                    Call oItems.Remove(Item)
                    Call oItems.Insert(iIndex + 1, Item)
                End If
            End If
        End Sub

        Public Sub MoveTo(ByVal Index As Integer, ByVal Item As cItem3D)
            If oItems.Contains(Item) Then
                Dim iIndex As Integer = oItems.IndexOf(Item)
                If Index <> iIndex And Index >= 0 And Index < oItems.Count Then
                    Call oItems.Remove(Item)
                    Call oItems.Insert(Index, Item)
                End If
            End If
        End Sub

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cItem3D) Implements IEnumerable(Of cItem3D).GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace