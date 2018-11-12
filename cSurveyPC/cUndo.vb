Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Helper.Editor
    Public Class cUndo
        Implements IEnumerable

        Private bSuspended As Boolean
        Private Const iUndoMaxItems As Integer = 1024

        Private oSurvey As cSurveyPC.cSurvey.cSurvey
        Private oParent As cEditTools
        Private oFile As Storage.cFile
        Private oItems As Stack(Of cUndoItem)

        Private sLastSourceData As String
        Private iLastAction As ActionEnum
        Private bFirstUndo As Boolean

        Friend Class cUndoEventArgs
            Private oItem As cUndoItem

            Public ReadOnly Property Item As cUndoItem
                Get
                    Return oItem
                End Get
            End Property

            Public Sub New(Item As cUndoItem)
                oItem = Item
            End Sub
        End Class

        Friend Event OnCancel(Sender As cUndo, EventArgs As cUndoEventArgs)
        Friend Event OnPop(Sender As cUndo, EventArgs As cUndoEventArgs)
        Friend Event OnPush(Sender As cUndo, EventArgs As cUndoEventArgs)

        Public Enum ObjectTypeEnum
            Segment = 0
            Item = 1
        End Enum

        Public Enum ActionEnum
            None = 0
            Update = 1
            Insert = 2
            Delete = 3
            Move = 4
        End Enum

        Public Sub Push(ByVal Description As String, ByVal Action As ActionEnum, ByVal Segment As cSurveyPC.cSurvey.cSegment, Optional ByVal Index As Integer = 0, Optional ByVal OldIndex As Integer = 0)
            If Not bSuspended Then
                Dim oXML As XmlDocument = oFile.Document
                Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
                Dim oSourceData As XmlElement = Segment.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.ForClipboard)
                Dim sSourceData As String = oSourceData.OuterXml
                If sSourceData <> sLastSourceData Or iLastAction <> Action Then
                    Dim oItem As cUndoItem = New cUndoItem(Action, Description, Nothing, ObjectTypeEnum.Segment, oSourceData, Index, OldIndex)
                    bFirstUndo = True
                    sLastSourceData = sSourceData
                    iLastAction = Action
                    Call oItems.Push(oItem)
                    RaiseEvent OnPush(Me, New cUndoEventArgs(oItem))
                End If
            End If
        End Sub

        Public Sub Push(ByVal Description As String, ByVal Action As ActionEnum, ByVal Layer As cLayer, ByVal Item As cSurveyPC.cSurvey.Design.cItem, Optional ByVal Index As Integer = 0, Optional ByVal OldIndex As Integer = 0)
            If Not bSuspended Then
                Try
                    Dim oXML As XmlDocument = oFile.Document
                    Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
                    Dim oSourceData As XmlElement = Item.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent)
                    If Not oSourceData Is Nothing Then
                        Dim sSourceData As String = oSourceData.OuterXml
                        If sSourceData <> sLastSourceData Or iLastAction <> Action Then
                            Dim oItem As cUndoItem = New cUndoItem(Action, Description, Layer, ObjectTypeEnum.Item, oSourceData, Index, OldIndex)
                            bFirstUndo = True
                            sLastSourceData = sSourceData
                            iLastAction = Action
                            Call oItems.Push(oItem)
                            RaiseEvent OnPush(Me, New cUndoEventArgs(oItem))
                        End If
                    End If
                Catch ex As Exception
                    Debug.Print("UNDO ERROR:" & ex.Message)
                End Try
            End If
        End Sub

        Public ReadOnly Property Item(Index As Integer) As cUndoItem
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function Peek() As cUndoItem
            Return oItems.Peek
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Sub Pop()
            bSuspended = True
            If oItems.Count > 0 Then
                Dim oItem As cUndoItem = oItems.Pop()
                RaiseEvent OnPop(Me, New cUndoEventArgs(oItem))
                Select Case oItem.SourceObjectType
                    Case ObjectTypeEnum.Segment
                        Select Case oItem.Action
                            Case ActionEnum.Update
                                Dim oCurrentSegment As cSegment = oSurvey.Segments(oItem.Index)
                                Call oSurvey.Segments.Remove(oCurrentSegment)
                                Dim oXMLItem As XmlElement = oItem.SourceData
                                Dim oSegment As cSegment = New cSegment(oSurvey, oFile, oXMLItem)
                                Call oSurvey.Segments.Append(oSegment)
                                Call oSurvey.Segments.MoveTo(oItem.Index, oSegment)
                                Call oParent.SelectSegment(oSegment)
                            Case ActionEnum.Insert
                                Call oSurvey.Segments.Remove(oItem.Index)
                            Case ActionEnum.Delete
                                Dim oXMLItem As XmlElement = oItem.SourceData
                                Dim oSegment As cSegment = New cSegment(oSurvey, oFile, oXMLItem)
                                Call oSurvey.Segments.Append(oSegment)
                                Call oSurvey.Segments.MoveTo(oItem.Index, oSegment)
                                Call oParent.SelectSegment(oSegment)
                            Case ActionEnum.Move
                                Call oSurvey.Segments.MoveTo(oItem.OldIndex, oSurvey.Segments(oItem.Index))
                        End Select
                    Case ObjectTypeEnum.Item
                        Select Case oItem.Action
                            Case ActionEnum.Update
                                'ripristino l'oggetto come era prima della modifica...
                                Dim oLayer As cLayer = oItem.Parent
                                Dim oCurrentItem As cItem = oLayer.Items(oItem.Index)
                                Call oLayer.Items.Remove(oCurrentItem)
                                Dim oXMLItem As XmlElement = oItem.SourceData
                                Dim oDesignItem As cItem = oLayer.CreateItem(oFile, oXMLItem)
                                Call oLayer.Items.MoveTo(oItem.Index, oDesignItem)
                                Call oParent.GetDesignTools(oLayer).SelectItem(oDesignItem)
                            Case ActionEnum.Insert
                                Dim oLayer As cLayer = oItem.Parent
                                Call oLayer.Items.Remove(oItem.Index)
                            Case ActionEnum.Delete
                                Dim oLayer As cLayer = oItem.Parent
                                Dim oXMLItem As XmlElement = oItem.SourceData
                                Dim oDesignItem As cItem = oLayer.CreateItem(oFile, oXMLItem)
                                Call oLayer.Items.MoveTo(oItem.Index, oDesignItem)
                                Call oParent.GetDesignTools(oLayer).SelectItem(oDesignItem)
                            Case ActionEnum.Move
                                Dim oLayer As cLayer = oItem.Parent
                                Call oLayer.Items.MoveTo(oItem.OldIndex, oLayer.Items(oItem.Index))
                        End Select
                End Select
            End If
            bSuspended = False
        End Sub

        Public Sub Cancel()
            If oItems.Count > 0 Then
                Dim oItem As cUndoItem = oItems.Pop
                RaiseEvent OnCancel(Me, New cUndoEventArgs(oItem))
            End If
        End Sub

        Public ReadOnly Property IsUndoable As Boolean
            Get
                Return oItems.Count > 0
            End Get
        End Property

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Parent As cEditTools)
            oSurvey = Survey
            oParent = Parent
            oItems = New Stack(Of cUndoItem)(iUndoMaxItems)
            oFile = New Storage.cFile()
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
