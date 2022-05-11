Imports System.Xml
Imports cSurveyPC.cSurvey.Calculate

Namespace cSurvey
    Public Class cConnections
        Implements IEnumerable

        Private oConnections As Dictionary(Of String, Boolean)

        Friend Class cConnectionsEventArgs
            Inherits EventArgs

            Private sTrigPoint As String

            Public ReadOnly Property TrigPoint As String
                Get
                    Return sTrigPoint
                End Get
            End Property

            Friend Sub New(ByVal TrigPoint As String)
                sTrigPoint = TrigPoint
            End Sub
        End Class

        Friend Class cGetOwnerEventArgs
            Inherits EventArgs

            Private sTrigPoint As String

            Public Property TrigPoint As String
                Get
                    Return sTrigPoint
                End Get
                Set(value As String)
                    sTrigPoint = value
                End Set
            End Property

            Friend Sub New()
                sTrigPoint = ""
            End Sub
        End Class

        Friend Event OnConnectionChanged(ByVal Sender As Object, ByVal Arg As cConnectionsEventArgs)
        Friend Event OnGetOwnerStation(ByVal Sender As Object, ByVal Arg As cGetOwnerEventArgs)

        Public Sub CopyFrom(Connections As cConnections)
            Call oConnections.Clear()
            For Each sStation As String In Connections
                Call oConnections.Add(sStation, Connections.[Get](sStation))
            Next
        End Sub

        Public Function Contains(Definition As cConnectionDef) As Boolean
            Dim oArgs As cGetOwnerEventArgs = New cGetOwnerEventArgs
            RaiseEvent OnGetOwnerStation(Me, oArgs)
            For Each sStation As String In oConnections.Keys
                If Definition.Station = oArgs.TrigPoint AndAlso Definition.FromStation = sStation Then
                    Return True
                End If
            Next
            Return False
        End Function

        Friend Sub Rebind(Connections As Calculate.cTrigPointConnections)
            Dim oCalculatedConnections As List(Of String) = Connections.GetCenterLineShots
            For Each sCalculatedConnection As String In oCalculatedConnections
                If Not oConnections.ContainsKey(sCalculatedConnection) Then
                    Call [Set](sCalculatedConnection, False)
                End If
            Next
            Dim oNamesToRemove As List(Of String) = New List(Of String)(oConnections.Keys.Where(Function(item) Not oCalculatedConnections.Contains(item)))
            For Each sNameToRemove As String In oNamesToRemove
                Call oConnections.Remove(sNameToRemove)
            Next
        End Sub

        Public Sub [Set](TrigPoint As String, Ignore As Boolean)
            If Not oConnections.ContainsKey(TrigPoint) Then
                Call Append(TrigPoint)
            End If
            If oConnections(TrigPoint) <> Ignore Then
                oConnections(TrigPoint) = Ignore
                RaiseEvent OnConnectionChanged(Me, New cConnectionsEventArgs(TrigPoint))
            End If
        End Sub

        Public Function [Get](TrigPoint As String) As Boolean
            If oConnections.ContainsKey(TrigPoint) Then
                Return oConnections(TrigPoint)
            Else
                Return False
            End If
        End Function

        Public ReadOnly Property Last() As String
            Get
                Return oConnections.Last.Key
            End Get
        End Property

        Public ReadOnly Property First() As String
            Get
                Return oConnections.First.Key
            End Get
        End Property

        Public Function IsCustomized() As Boolean
            Return oConnections.Values.FirstOrDefault(Function(oitem) oitem)
        End Function

        Public Function Contains(ByVal TrigPoint As String) As Boolean
            Return oConnections.ContainsKey(TrigPoint)
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oConnections.Keys.GetEnumerator
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oConnections.Count
            End Get
        End Property

        Friend Sub New(ByVal Connections As Dictionary(Of String, Boolean))
            oConnections = New Dictionary(Of String, Boolean)(Connections)
        End Sub

        Friend Sub Remove(TrigPoint As String)
            If oConnections.ContainsKey(TrigPoint) Then
                Call oConnections.Remove(TrigPoint)
            End If
        End Sub

        Friend Function Append(ByVal TrigPoint As String) As Boolean
            If Not oConnections.ContainsKey(TrigPoint) Then
                Call oConnections.Add(TrigPoint, False)
                Return True
            Else
                Return False
            End If
        End Function

        Friend Sub New(ByVal Connections As XmlElement)
            oConnections = New Dictionary(Of String, Boolean)
            Dim sValues As String = Connections.GetAttribute("v")
            For Each sValue As String In sValues.Split({";"}, StringSplitOptions.RemoveEmptyEntries)
                Dim sTrigPoint As String
                Dim bIgnore As Boolean
                If sValue <> "" Then
                    If sValue.StartsWith("!") Then
                        sTrigPoint = sValue.Substring(1)
                        bIgnore = True
                    Else
                        sTrigPoint = sValue
                        bIgnore = False
                    End If
                    Call oConnections.Add(sTrigPoint, bIgnore)
                End If
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlConnections As XmlElement = Document.CreateElement("connections")
            Call oXmlConnections.SetAttribute("v", ToString)
            Call Parent.AppendChild(oXmlConnections)
            Return oXmlConnections
        End Function

        Friend Sub New()
            oConnections = New Dictionary(Of String, Boolean)
        End Sub

        Public Overrides Function ToString() As String
            Dim oValues As List(Of String) = New List(Of String)
            For Each sTrigPoint As String In oConnections.Where(Function(item) item.Value).Select(Function(item) item.Key)
                Call oValues.Add("!" & sTrigPoint)
            Next
            Return Strings.Join(oValues.ToArray, ";")
        End Function
    End Class
End Namespace
