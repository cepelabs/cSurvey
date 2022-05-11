Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports System.IO
Imports System.Xml

Namespace cSurvey.Calculate
    Public Class cTrigPoint
        Private sName As String
        Private oConnections As cTrigPointConnections
        Private oPoint As cTrigPointPoint
        Private oCoordinate As cTrigPointCoordinate
        Private bProcessed As Boolean
        Private oSideMeasure As cTrigPointSideMeasure

        Friend Sub Rename(NewName As String)
            sName = NewName
        End Sub

        Friend Sub New(ByVal Name As String)
            sName = Name
            oConnections = New cTrigPointConnections
            oPoint = New cTrigPointPoint(0, 0, 0)
            oCoordinate = New cTrigPointCoordinate(0, 0, 0)
            oSideMeasure = New cTrigPointSideMeasure
        End Sub

        Friend Sub New(ByVal Item As XmlElement)
            sName = Item.GetAttribute("n")
            oConnections = New cTrigPointConnections(Item.Item("tcons"))
            oPoint = New cTrigPointPoint(Item.Item("p"))
            oCoordinate = New cTrigPointCoordinate(Item.Item("coord"))
            bProcessed = modXML.GetAttributeValue(Item, "prsd", 0)
            oSideMeasure = New cTrigPointSideMeasure(Item.Item("sm"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTrigpoint As XmlElement = Document.CreateElement("t")
            Call oXmlTrigpoint.SetAttribute("n", sName)
            Call oConnections.SaveTo(File, Document, oXmlTrigpoint)
            Call oPoint.SaveTo(File, Document, oXmlTrigpoint, "p")
            Call oCoordinate.SaveTo(File, Document, oXmlTrigpoint, "coord")
            If bProcessed Then oXmlTrigpoint.SetAttribute("prsd", "1")
            Call oSideMeasure.SaveTo(File, Document, oXmlTrigpoint)

            Call Parent.AppendChild(oXmlTrigpoint)
            Return oXmlTrigpoint
        End Function

        Friend Sub MoveTo(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0)
            Call oPoint.MoveTo(X, Y, Z, D)
        End Sub

        Friend Sub MoveBy(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0)
            Call oPoint.MoveBy(X, Y, Z, D)
        End Sub

        Public Overrides Function ToString() As String
            Return sName & " " & oPoint.ToString
        End Function

        Public ReadOnly Property SideMeasure() As cTrigPointSideMeasure
            Get
                Return oSideMeasure
            End Get
        End Property

        Friend Function GetPoints() As cTrigPointPoint()
            Dim oList As List(Of cTrigPointPoint) = New List(Of cTrigPointPoint)
            For Each oConnection As cTrigPointConnection In oConnections
                If Not oConnection.IsEmpty Then
                    Call oList.Add(oConnection.GetPoint)
                End If
            Next
            Return oList.ToArray
        End Function

        Friend Function SetPoint(ByVal X As Decimal, ByVal Y As Decimal, ByVal Z As Decimal, Optional ByVal D As Decimal = 0, Optional ByVal IfNotEmpty As Boolean = False) As cTrigPointPoint
            If (IfNotEmpty AndAlso oPoint.IsEmpty) OrElse (Not IfNotEmpty) Then
                oPoint = New cTrigPointPoint(X, Y, Z, D)
                Return oPoint
            End If
        End Function

        Friend Function SetPoint(ByVal Point As cTrigPointPoint, Optional ByVal IfNotEmpty As Boolean = False) As cTrigPointPoint
            If (IfNotEmpty AndAlso oPoint.IsEmpty) OrElse (Not IfNotEmpty) Then
                oPoint = New cTrigPointPoint(Point)
                Return oPoint
            End If
        End Function

        Friend Sub SetCoordinate(Coordinate As cCoordinate)
            oCoordinate = New cTrigPointCoordinate(Coordinate)
        End Sub

        Friend Sub SetCoordinate(Coordinate As cTrigPointCoordinate)
            oCoordinate = New cTrigPointCoordinate(Coordinate)
        End Sub

        Friend Sub SetCoordinate(ByVal Latitude As Decimal, Longitude As Decimal, Altitude As Decimal)
            oCoordinate = New cTrigPointCoordinate(Latitude, Longitude, Altitude)
        End Sub

        Public ReadOnly Property Coordinate() As cTrigPointCoordinate
            Get
                Return oCoordinate
            End Get
        End Property

        Public ReadOnly Property Point() As cTrigPointPoint
            Get
                Return oPoint
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Function HasNextPoints(ByVal [From] As String, Optional ByVal NotEmpty As Boolean = False, Optional NotSplay As Boolean = False) As Boolean
            For Each oConnection As cTrigPointConnection In oConnections
                If oConnection.Name <> [From] Then
                    If Not oConnection.Splay Then
                        Return True
                    End If
                End If
            Next
            If Not NotSplay Then
                For Each oConnection As cTrigPointConnection In oConnections
                    If oConnection.Name <> [From] Then
                        If oConnection.Splay Then
                            Return True
                        End If
                    End If
                Next
            End If
            Return False
        End Function

        Public Function GetNextPoints(ByVal [From] As String, Optional ByVal NotEmpty As Boolean = False, Optional NotSplay As Boolean = False) As String()
            Dim oPoints As List(Of String) = New List(Of String)
            For Each oConnection As cTrigPointConnection In oConnections
                If oConnection.Name <> [From] Then
                    If Not oConnection.Splay Then
                        Call oPoints.Add(oConnection.Name)
                    End If
                End If
            Next
            If Not NotSplay Then
                For Each oConnection As cTrigPointConnection In oConnections
                    If oConnection.Name <> [From] Then
                        If oConnection.Splay Then
                            Call oPoints.Add(oConnection.Name)
                        End If
                    End If
                Next
            End If
            Return oPoints.ToArray
        End Function

        Public ReadOnly Property Connections() As cTrigPointConnections
            Get
                Return oConnections
            End Get
        End Property

        Friend Property Processed() As Boolean
            Get
                Return bProcessed
            End Get
            Set(ByVal value As Boolean)
                bProcessed = value
            End Set
        End Property
    End Class
End Namespace