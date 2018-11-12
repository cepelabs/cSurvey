Imports System.Xml
Imports cSurveyPC.cSurvey
Imports System.Collections.ObjectModel

Namespace cSurvey
    Friend Class cSegmentBaseCollection
        Inherits KeyedCollection(Of String, cISegment)

        Protected Overrides Function GetKeyForItem(ByVal item As cISegment) As String
            Return item.ID
        End Function
    End Class

    Public Class cSegmentCollection
        Implements IEnumerable
        Implements cISegmentCollection

        Private oSurvey As cSurvey

        Private oSegments As cSegmentBaseCollection

        Public Function Find(ByVal Text As String) As cISegmentCollection Implements cISegmentCollection.Find
            Dim sText As String = Text.ToUpper
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(Segment) Segment.From Like sText Or Segment.To Like sText))
        End Function

        Public Function cISegment_GetEnumerator() As IEnumerator(Of cISegment) Implements cISegmentCollection.GetEnumerator
            Return oSegments.GetEnumerator
        End Function

        Public Function GetCalibrationSegments() As cSegmentCollection Implements cISegmentCollection.GetCalibrationSegments
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item) item.Calibration))
        End Function

        Public Function GetSurveySegments() As cSegmentCollection Implements cISegmentCollection.GetSurveySegments
            Return New cSegmentCollection(oSurvey, oSegments.Where(Function(item) Not item.Calibration))
        End Function

        Public Function Intersect(Segments As cISegmentCollection) As cISegmentCollection Implements cISegmentCollection.Intersect
            Return New cSegmentCollection(oSurvey, oSegments.Intersect(Segments))
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oSegments = New cSegmentBaseCollection
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Segments As IEnumerable(Of cISegment))
            oSurvey = Survey
            oSegments = New cSegmentBaseCollection
            Call AppendRange(Segments)
        End Sub

        Friend Sub AppendRange(ByVal Segments As IEnumerable(Of cISegment))
            For Each oSegment As cISegment In Segments
                Call oSegments.Add(oSegment)
            Next
        End Sub

        Friend Sub Append(ByVal Segment As cISegment)
            Call oSegments.Add(Segment)
        End Sub

        Public ReadOnly Property Count() As Integer Implements cISegmentCollection.Count
            Get
                Return oSegments.Count
            End Get
        End Property

        Public Function GetVisibleSegments(PaintOptions As Design.cOptions) As cSegmentCollection Implements cISegmentCollection.GetVisibleSegments
            Return modSegmentsTools.GetVisibleSegments(oSurvey, oSegments, PaintOptions)
        End Function

        Public Function GetVisibleCaveSegments(PaintOptions As Design.cOptions, ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection Implements cISegmentCollection.GetVisibleCaveSegments
            Return modSegmentsTools.GetVisibleCaveSegments(oSurvey, oSegments, PaintOptions, Cave, Branch)
        End Function

        Public Function GetCaveSegments(ByVal Cave As String, Optional ByVal Branch As String = "") As cSegmentCollection Implements cISegmentCollection.GetCaveSegments
            Return modSegmentsTools.GetCaveSegments(oSurvey, Me, Cave, Branch)
        End Function

        Public Function GetCaveSegments(ByVal CaveInfoBranch As cCaveInfoBranch) As cSegmentCollection Implements cISegmentCollection.GetCaveSegments
            Return modSegmentsTools.GetCaveSegments(oSurvey, Me, CaveInfoBranch)
        End Function

        Public Function GetCaveSegments(ByVal CaveInfo As cCaveInfo) As cSegmentCollection Implements cISegmentCollection.GetCaveSegments
            Return modSegmentsTools.GetCaveSegments(oSurvey, Me, CaveInfo)
        End Function

        Public Function GetSessionSegments(ByVal SessionID As String, Optional Flags As cISegmentCollection.SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection Implements cISegmentCollection.GetSessionSegments
            Return modSegmentsTools.GetSessionSegments(oSurvey, Me, SessionID, Flags)
        End Function

        Public Function GetSessionSegments(ByVal Session As cSession, Optional Flags As cISegmentCollection.SessionSegmentsFlagEnum = cISegmentCollection.SessionSegmentsFlagEnum.SurveyShots) As cSegmentCollection Implements cISegmentCollection.GetSessionSegments
            Return modSegmentsTools.GetSessionSegments(oSurvey, Me, Session, Flags)
        End Function

        Public Function GetBindedItems() As List(Of Design.cItem) Implements cISegmentCollection.GetBindedItems
            Return modSegmentsTools.GetBindedItems(oSurvey, Me)
        End Function

        Public Function GetBindedItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of Design.cItem) Implements cISegmentCollection.GetBindedItems
            Return modSegmentsTools.GetBindedItems(oSurvey, Me, Design)
        End Function

        Public Function GetBindedSegments() As cSegmentCollection Implements cISegmentCollection.GetBindedSegments
            Return modSegmentsTools.GetBindedSegments(oSurvey, Me)
        End Function

        Public Function GetBindedSegments(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As cSegmentCollection Implements cISegmentCollection.GetBindedSegments
            Return modSegmentsTools.GetBindedSegments(oSurvey, Me, Design)
        End Function

        Public Function GetTrigPoints() As cITrigPointCollection Implements cISegmentCollection.GetTrigPoints
            Dim sName As String
            Dim oTrigPoints As cTrigPointCollection = New cTrigPointCollection(oSurvey)
            For Each oSegment As cISegment In oSegments
                sName = oSegment.From.ToUpper
                If Not oTrigPoints.Contains(sName) And oSurvey.TrigPoints.Contains(sName) Then
                    Call oTrigPoints.Append(oSurvey.TrigPoints(sName))
                End If
                sName = oSegment.To.ToUpper
                If Not oTrigPoints.Contains(sName) And oSurvey.TrigPoints.Contains(sName) Then
                    Call oTrigPoints.Append(oSurvey.TrigPoints(sName))
                End If
            Next
            Return oTrigPoints
        End Function

        Friend Function GetTrigPointsNames() As SortedSet(Of String) Implements cISegmentCollection.GetTrigpointsNames
            Dim oTable As SortedSet(Of String) = New SortedSet(Of String)
            Dim sName As String
            For Each oSegment As cSegment In oSegments
                If oSegment.IsValid Then
                    sName = oSegment.From
                    If sName <> "" Then
                        If Not oTable.Contains(sName) Then
                            Call oTable.Add(sName)
                        End If
                    End If
                    sName = oSegment.To
                    If sName <> "" Then
                        If Not oTable.Contains(sName) Then
                            Call oTable.Add(sName)
                        End If
                    End If
                End If
            Next
            Return oTable
        End Function

        Public Function IndexOf(ByVal ID As String) As Integer Implements cISegmentCollection.IndexOf
            Try
                Dim oSegment As cISegment = oSegments(ID)
                Return oSegments.IndexOf(oSegment)
            Catch
                Return -1
            End Try
        End Function

        Public Function IndexOf(ByVal Segment As cISegment) As Integer Implements cISegmentCollection.IndexOf
            Return oSegments.IndexOf(Segment)
        End Function

        Public Function Contains(ByVal Segment As cISegment) As Boolean Implements cISegmentCollection.Contains
            Return oSegments.Contains(Segment)
        End Function

        Public Function Contains(ByVal ID As String) As Boolean Implements cISegmentCollection.Contains
            Return oSegments.Contains(ID)
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cISegment Implements cISegmentCollection.Item
            Get
                Return oSegments(Index)
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal ID As String) As cISegment Implements cISegmentCollection.Item
            Get
                Return oSegments(ID)
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oSegments.GetEnumerator
        End Function

        Public Function ToCSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegmentCollection.ToCSV
            Dim sSb As String = ""
            For Each oSegment As cISegment In oSegments
                sSb &= oSegment.ToCSV(UseLocalFormat) & vbCrLf
            Next
            Return sSb
        End Function

        Public Function ToTSV(Optional UseLocalFormat As Boolean = False) As String Implements cISegmentCollection.ToTSV
            Dim sSb As String = ""
            For Each oSegment As cISegment In oSegments
                sSb &= oSegment.ToTSV(UseLocalFormat) & vbCrLf
            Next
            Return sSb
        End Function

        Public Function ToArray() As cISegment() Implements cISegmentCollection.ToArray
            Return oSegments.ToArray
        End Function

        Public Function ToList() As List(Of cISegment) Implements cISegmentCollection.ToList
            Return oSegments.ToList
        End Function

        Public Function ToSegments() As List(Of cSegment)
            Return New List(Of cSegment)(oSegments.Cast(Of cSegment))
        End Function

        Public Function GetSessions() As List(Of cSession) Implements cISegmentCollection.GetSessions
            Dim oEmptySession As cSession = oSurvey.Properties.Sessions.GetEmptySession
            Dim oSessions As List(Of String) = New List(Of String)
            For Each oSegment As cSegment In oSegments
                If Not oSessions.Contains(oSegment.Session) Then
                    Call oSessions.Add(oSegment.Session)
                End If
            Next
            Return oSessions.Select(Function(sSession) If(sSession = "", oEmptySession, oSurvey.Properties.Sessions(sSession))).ToList
        End Function
    End Class
End Namespace