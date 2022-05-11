Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cTrigPointConnections
        Implements IEnumerable

        Private oItems As Dictionary(Of String, cTrigPointConnection)

        Friend Sub Rename(OldName As String, NewName As String)
            If oItems.ContainsKey(OldName) Then
                Dim oItem As cTrigPointConnection = oItems(OldName)
                Call oItems.Remove(OldName)
                Call oItem.rename(NewName)
                Call oItems.Add(NewName, oItem)
            End If
        End Sub

        Public Function GetCenterlineShots() As List(Of String)
            Return oItems.Values.Where(Function(item) Not item.Splay AndAlso Not item.Equate).Select(Function(item) item.Name).ToList
        End Function

        Public Function GetSplayShots() As List(Of String)
            Return oItems.Values.Where(Function(item) item.Splay).Select(Function(item) item.Name).ToList
        End Function

        Public Function GetEquateShots() As List(Of String)
            Return oItems.Values.Where(Function(item) item.Equate).Select(Function(item) item.Name).ToList
        End Function

        Public Function Contains(Name As String) As Boolean
            Return oItems.ContainsKey(Name)
        End Function

        Friend Sub New(ByVal Item As XmlElement)
            oItems = New Dictionary(Of String, cTrigPointConnection)
            For Each oXMLItem As XmlElement In Item.ChildNodes
                Dim oItem As cTrigPointConnection = New cTrigPointConnection(oXMLItem)
                Call oItems.Add(oItem.Name, oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigpointConnections As XmlElement = Document.CreateElement("tcons")
            For Each oItem As cTrigPointConnection In oItems.Values
                Call oItem.SaveTo(File, Document, oXmlTrigpointConnections)
            Next
            Call Parent.AppendChild(oXmlTrigpointConnections)
            Return oXmlTrigpointConnections
        End Function

        Friend Sub New()
            oItems = New Dictionary(Of String, cTrigPointConnection)
        End Sub

        Friend Sub MoveBy(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal? = Nothing)
            For Each oConnection As cTrigPointConnection In oItems.Values
                Call oConnection.GetPoint.MoveBy(X, Y, Z, D)
            Next
        End Sub

        Friend Function SetPoint(ByVal Name As String, ByVal Point As cTrigPointPoint, Optional ByVal IfNotEmpty As Boolean = False) As cTrigPointPoint
            If oItems.ContainsKey(Name) Then
                Return oItems(Name).SetPoint(Point, IfNotEmpty)
            End If
        End Function

        Friend Function SetPoint(ByVal Name As String, ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0, Optional ByVal IfNotEmpty As Boolean = False) As cTrigPointPoint
            If oItems.ContainsKey(Name) Then
                Return oItems(Name).SetPoint(X, Y, Z, D, IfNotEmpty)
            End If
        End Function

        Friend Function AppendAsEquate(Name As String) As cTrigPointConnection
            If oItems.ContainsKey(Name) Then
                'check if exist a connection is of the same type, in case raise an error
                Return oItems(Name)
            Else
                Dim oConnection As cTrigPointConnection = New cTrigPointConnection(Name)
                Call oItems.Add(Name, oConnection)
                Return oConnection
            End If
        End Function

        Friend Function AppendAsShot(ByVal Name As String, ByVal Distance As Decimal, Optional Splay As Boolean = False) As cTrigPointConnection
            If oItems.ContainsKey(Name) Then
                'check if exist a connection is of the same type, in case raise an error
                Return oItems(Name)
            Else
                Dim oConnection As cTrigPointConnection = New cTrigPointConnection(Name, Distance, Splay)
                Call oItems.Add(Name, oConnection)
                Return oConnection
            End If
        End Function

        Public Function First(Optional ByVal NotEmpty As Boolean = False, Optional NotSplay As Boolean = False) As cTrigPointConnection
            Return oItems.Values.FirstOrDefault(Function(Item) ((Item.Splay AndAlso Not NotSplay) OrElse (Not Item.Splay)))
            'For Each oConnection As cTrigPointConnection In oItems.Values
            '    If ((oConnection.Splay AndAlso Not NotSplay) OrElse (Not oConnection.Splay)) Then
            '        Return oConnection
            '    End If
            'Next
            'Return Nothing
        End Function

        Public Function Last(Optional ByVal NotEmpty As Boolean = False, Optional NotSplay As Boolean = False) As cTrigPointConnection
            Return oItems.Values.LastOrDefault(Function(Item) ((Item.Splay AndAlso Not NotSplay) OrElse (Not Item.Splay)))
        End Function

        Friend Sub Clear()
            Call oItems.Clear()
        End Sub

        Default Public ReadOnly Property Item(ByVal Name As String) As cTrigPointConnection
            Get
                Return oItems(Name)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class
End Namespace
