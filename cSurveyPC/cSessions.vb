Imports System.Xml

Namespace cSurvey
    Public Class cSessions
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oSessions As SortedDictionary(Of String, cSession)

        Public Function GetSession(Session As cISession) As cSession
            Return oSessions(Session)
        End Function

        Public Function GetSurveyYears() As List(Of Integer)
            Dim oYears As List(Of Integer) = New List(Of Integer)
            For Each oSession As cSession In oSessions.Values
                Dim iYear As Integer = oSession.Date.Year
                If Not oYears.Contains(iYear) Then
                    Call oYears.Add(iYear)
                End If
            Next
            Call oYears.Sort()
            Return oYears
        End Function

        Public Function GetColor(Segment As cSegment, ByVal DefaultColor As Color) As Color
            If oSessions.ContainsKey(Segment.Session) Then
                Return GetColor(Segment.Session, DefaultColor)
            Else
                Return DefaultColor
            End If
        End Function

        Public Function GetColor(ByVal Session As cSession, ByVal DefaultColor As Color) As Color
            Dim oColor As Color = Session.Color
            If modPaint.IsNullColor(oColor) Then
                Return DefaultColor
            Else
                Return oColor
            End If
        End Function

        Public Function GetColor(ByVal ID As String, ByVal DefaultColor As Color) As Color
            If oSessions.ContainsKey(ID) Then
                Return GetColor(oSessions(ID), DefaultColor)
            Else
                Return DefaultColor
            End If
        End Function

        Public Function GetUniqueID([Date] As Date, Description As String) As String
            Dim iCounter As Integer = 0
            Dim sResult As String
            If Contains([Date], Description) Then
                Do
                    iCounter += 1
                    sResult = Description & " " & iCounter
                Loop While Contains([Date], sResult)
                Return sResult
            Else
                Return Description
            End If
        End Function

        Public Function GetWithEmpty() As SortedDictionary(Of String, cSession)
            Dim oSessionsWithEmpty As SortedDictionary(Of String, cSession) = New SortedDictionary(Of String, cSession)(oSessions)
            Dim oSession As cSession = GetEmptySession()
            Call oSessionsWithEmpty.Add("", oSession)
            Return oSessionsWithEmpty
        End Function

        Public Function Rename(ByVal Session As cSession, ByVal NewDate As Date, ByVal NewDescription As String) As Boolean
            Return Rename(Session.ID, NewDate, NewDescription)
        End Function

        Public Function Rename(ByVal ID As String, ByVal NewDate As Date, ByVal NewDescription As String) As Boolean
            Dim sID As String = ID.ToLower
            Dim sNewID As String = GetID(NewDate, NewDescription)
            If oSessions.ContainsKey(sID) And Not oSessions.ContainsKey(sNewID) Then
                Dim oSession As cSession = oSessions(sID)
                Call oSessions.Remove(sID)
                Call oSession.SetDate(NewDate)
                Call oSession.SetDescription(NewDescription)
                Call oSessions.Add(sNewID, oSession)

                For Each oSegment As cSegment In oSurvey.Segments
                    If oSegment.Session = sID Then
                        Call oSegment.RenameSession(sNewID)
                    End If
                Next
                Return True
            Else
                Return False
            End If
        End Function

        Public Function Contains(ByVal [Date] As Date, ByVal Description As String) As Boolean
            Dim sID As String = GetID([Date], Description)
            Return oSessions.ContainsKey(sID)
        End Function

        Public Function Contains(ByVal ID As String)
            Dim sID As String = ID.ToLower
            Return oSessions.ContainsKey(sID)
        End Function

        Friend Function Contains(ByVal Item As cSession)
            Return oSessions.ContainsValue(Item)
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oSessions = New SortedDictionary(Of String, cSession)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oSessions.Values.GetEnumerator
        End Function

        Public Function GetID(ByVal [Date] As Date, ByVal Description As String) As String
            If [Date] = #12:00:00 AM# Then
                Return ""
            Else
                Return Strings.Format([Date], "yyyyMMdd") & "_" & Description.Replace(" ", "_").ToLower
            End If
        End Function

        Public ReadOnly Property Count() As Integer
            Get
                Return oSessions.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal [Date] As Date, ByVal Description As String) As cSession
            Get
                Dim sID As String = GetID([Date], Description)
                If oSessions.ContainsKey(sID) Then
                    Return oSessions(sID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal ID As String) As cSession
            Get
                Dim sID As String = ID.ToLower
                If oSessions.ContainsKey(sID) Then
                    Return oSessions(sID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function Add(ByVal [Date] As Date, ByVal Description As String) As cSession
            Dim oSession As cSession = New cSession(oSurvey, [Date], Description)
            Call oSessions.Add(oSession.ID, oSession)
            Return oSession
        End Function

        Public Sub Remove(ByVal ID As String)
            Dim sID As String = ID.ToLower
            If oSessions.ContainsKey(sID) Then
                Call oSessions.Remove(sID)
            End If
            For Each oSegment As cSegment In oSurvey.Segments
                If oSegment.Session.ToLower = sID Then Call oSegment.RenameSession("")
            Next
        End Sub

        Private oEmptySession As cSession

        Public ReadOnly Property EmptySession As cSession
            Get
                If oEmptySession Is Nothing Then
                    Dim oSession As cSession = New cSession(oSurvey, Nothing, "")
                    oSession.Team = oSurvey.Properties.Team
                    oSession.Club = oSurvey.Properties.Club
                    oSession.Designer = oSurvey.Properties.Designer

                    oSession.DataFormat = oSurvey.Properties.DataFormat
                    oSession.BearingType = oSurvey.Properties.BearingType
                    oSession.BearingDirection = oSurvey.Properties.BearingDirection
                    oSession.DistanceType = oSurvey.Properties.DistanceType
                    oSession.InclinationType = oSurvey.Properties.InclinationType
                    oSession.InclinationDirection = oSurvey.Properties.InclinationDirection

                    oSession.Grade = oSurvey.Properties.Grade

                    oSession.NordType = oSurvey.Properties.NordType
                    oSession.DeclinationEnabled = oSurvey.Properties.DeclinationEnabled
                    oSession.Declination = oSurvey.Properties.Declination

                    oSession.SideMeasuresType = oSurvey.Properties.SideMeasuresType
                    oSession.SideMeasuresReferTo = oSurvey.Properties.SideMeasuresReferTo

                    oEmptySession = oSession
                End If
                Return oEmptySession
            End Get
        End Property

        Friend Function GetEmptySession() As cSession
            Return EmptySession
        End Function

        Friend Function GetEmptySession(ByVal [Date] As Date, ByVal Description As String) As cSession
            Dim oSession As cSession = New cSession(oSurvey, [Date], Description)
            oSession.Team = oSurvey.Properties.Team
            oSession.Club = oSurvey.Properties.Club
            oSession.Designer = oSurvey.Properties.Designer

            oSession.DataFormat = oSurvey.Properties.DataFormat
            oSession.BearingType = oSurvey.Properties.BearingType
            oSession.BearingDirection = oSurvey.Properties.BearingDirection
            oSession.DistanceType = oSurvey.Properties.DistanceType
            oSession.InclinationType = oSurvey.Properties.InclinationType
            oSession.InclinationDirection = oSurvey.Properties.InclinationDirection

            oSession.Grade = oSurvey.Properties.Grade

            oSession.NordType = oSurvey.Properties.NordType
            oSession.DeclinationEnabled = oSurvey.Properties.DeclinationEnabled
            oSession.Declination = oSurvey.Properties.Declination

            oSession.SideMeasuresType = oSurvey.Properties.SideMeasuresType
            oSession.SideMeasuresReferTo = oSurvey.Properties.SideMeasuresReferTo
            Return oSession
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Sessions As XmlElement)
            oSurvey = Survey
            oSessions = New SortedDictionary(Of String, cSession)
            For Each oXmlSession As XmlElement In Sessions.ChildNodes
                Dim oSession As cSession = New cSession(oSurvey, oXmlSession)
                Call oSessions.Add(oSession.ID, oSession)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlSessions As XmlElement = document.CreateElement("sessions")
            For Each oSession As cSession In oSessions.Values
                Call oSession.SaveTo(File, document, oXmlSessions)
            Next
            Call Parent.AppendChild(oXmlSessions)
            Return oXmlSessions
        End Function

        Public Sub Clear()
            Call oSessions.Clear()
        End Sub

        Public ReadOnly Property FirstSession() As cSession
            Get
                If oSessions.Count > 0 Then
                    Return oSessions.First.Value
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property LastSession() As cSession
            Get
                If oSessions.Count > 0 Then
                    Return oSessions.Last.Value
                Else
                    Return Nothing
                End If
            End Get
        End Property
    End Class
End Namespace