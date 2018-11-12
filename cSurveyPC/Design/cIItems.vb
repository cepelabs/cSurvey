Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Public Interface cIItems
    Inherits IEnumerable

    ReadOnly Property First() As cIItem
    ReadOnly Property Last() As cIItem
    Function [Next](Item As cIItem) As cIItem
    Function [Previous](Item As cIItem) As cIItem
    ReadOnly Property Layer As cILayer
    Default ReadOnly Property Item(ByVal Index As Integer) As cIItem
    ReadOnly Property Count() As Integer
    Function IndexOf(ByVal Item As cIItem) As Integer
    Function GetByType(Type As cIItem.cItemTypeEnum) As List(Of cIItem)
    Function Contains(ByVal Item As cIItem) As Boolean
    Function ToList() As List(Of cIItem)
    Function ToArray() As cIItem()
    Sub SendToBottom(ByVal Item As cIItem)
    Sub BringToTop(ByVal Item As cIItem)
    Sub SendBehind(ByVal Item As cIItem)
    Sub BringAhead(ByVal Item As cIItem)
    Sub MoveTo(ByVal Index As Integer, ByVal Item As cIItem)
    Sub Clear()
End Interface
