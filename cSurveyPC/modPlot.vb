Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Calculate

Module modPlot

    Public Function GetPlanSegmentTranslation(Survey As cSurvey.cSurvey, Segment As cSegment) As SizeF
        With Survey.Properties
            If Segment.Branch = "" Then
                If Segment.Cave = "" Then
                    Return New SizeF(0, 0)
                Else
                    If .CaveInfos.Contains(Segment.Cave) Then
                        With .CaveInfos(Segment.Cave)
                            Return .Translations.Plan.GetSize
                        End With
                    Else
                        Return New SizeF(0, 0)
                    End If
                End If
            Else
                If .CaveInfos.Contains(Segment.Cave) Then
                    With .CaveInfos(Segment.Cave)
                        Dim oSize As SizeF = .Translations.Plan.GetSize
                        If .Branches.Contains(Segment.Branch) Then
                            Return SizeF.Add(oSize, .Branches(Segment.Branch).GetTranslations.Plan.GetSize)
                        Else
                            Return New SizeF(0, 0)
                        End If
                    End With
                Else
                    Return New SizeF(0, 0)
                End If
            End If
        End With
    End Function

    Public Sub PlanTranslateAndComparePoint(Survey As cSurvey.cSurvey, Point As PointF, Segment As cISegment, Translation As Boolean, ByRef MinPoint As PointF, ByRef MaxPoint As PointF)
        If Translation Then
            Dim oTranslation As SizeF = GetPlanSegmentTranslation(Survey, Segment)
            Point = PointF.Add(Point, oTranslation)
        End If
        If Point.X < MinPoint.X Then MinPoint.X = Point.X
        If Point.Y < MinPoint.Y Then MinPoint.Y = Point.Y
        If Point.X > MaxPoint.X Then MaxPoint.X = Point.X
        If Point.Y > MaxPoint.Y Then MaxPoint.Y = Point.Y
    End Sub

    Public Sub ProfileTranslateAndComparePoint(Survey As cSurvey.cSurvey, Point As PointF, Segment As cISegment, Translation As Boolean, ByRef MinPoint As PointF, ByRef MaxPoint As PointF)
        If Translation Then
            Dim oTranslation As SizeF = GetProfileSegmentTranslation(Survey, Segment)
            Point = PointF.Add(Point, oTranslation)
        End If
        If Point.X < MinPoint.X Then MinPoint.X = Point.X
        If Point.Y < MinPoint.Y Then MinPoint.Y = Point.Y
        If Point.X > MaxPoint.X Then MaxPoint.X = Point.X
        If Point.Y > MaxPoint.Y Then MaxPoint.Y = Point.Y
    End Sub

    'Public Function GetProfileSegmentTranslation(Survey As cSurvey.cSurvey, Segment As cSegment) As cTranslation
    '    With Survey.Properties
    '        If Segment.Branch = "" Then
    '            If Segment.Cave = "" Then
    '                Return New cTranslation(cTranslation.cTranslationApplyToEnum.Profile, 0, 0, cTranslation.cTranslationPriorityEnum.Default, 0)
    '            Else
    '                If .CaveInfos.Contains(Segment.Cave) Then
    '                    With .CaveInfos(Segment.Cave)
    '                        Return .Translations.Profile
    '                    End With
    '                Else
    '                    Return New cTranslation(cTranslation.cTranslationApplyToEnum.Profile, 0, 0, cTranslation.cTranslationPriorityEnum.Default, 0)
    '                End If
    '            End If
    '        Else
    '            If .CaveInfos.Contains(Segment.Cave) Then
    '                With .CaveInfos(Segment.Cave)
    '                    Dim oTranslation As cTranslation = .Translations.Profile
    '                    If .Branches.Contains(Segment.Branch) Then
    '                        Return cTranslation.Add(oTranslation, .Branches(Segment.Branch).GetTranslations.Profile)
    '                    Else
    '                        Return New cTranslation(cTranslation.cTranslationApplyToEnum.Profile, 0, 0, cTranslation.cTranslationPriorityEnum.Default, 0)
    '                    End If
    '                End With
    '            Else
    '                Return New cTranslation(cTranslation.cTranslationApplyToEnum.Profile, 0, 0, cTranslation.cTranslationPriorityEnum.Default, 0)
    '            End If
    '        End If
    '    End With
    'End Function

    Public Function GetProfileSegmentTranslation(Survey As cSurvey.cSurvey, Segment As cSegment) As SizeF
        With Survey.Properties
            If Segment.Branch = "" Then
                If Segment.Cave = "" Then
                    Return New SizeF(0, 0)
                Else
                    If .CaveInfos.Contains(Segment.Cave) Then
                        With .CaveInfos(Segment.Cave)
                            Return .Translations.Profile.GetSize
                        End With
                    Else
                        Return New SizeF(0, 0)
                    End If
                End If
            Else
                If .CaveInfos.Contains(Segment.Cave) Then
                    With .CaveInfos(Segment.Cave)
                        Dim oSize As SizeF = .Translations.Profile.GetSize
                        If .Branches.Contains(Segment.Branch) Then
                            Return SizeF.Add(oSize, .Branches(Segment.Branch).GetTranslations.Profile.GetSize)
                        Else
                            Return New SizeF(0, 0)
                        End If
                    End With
                Else
                    Return New SizeF(0, 0)
                End If
            End If
        End With
    End Function

    Public Function GetPlanAreaLine(ByVal Segment As cSegment) As GraphicsPath
        With Segment.Data.Plan
            If .ToSidePointLeft <> .ToSidePointRight Then
                Dim oPath As GraphicsPath = New GraphicsPath
                Call oPath.AddLine(CType(.ToSidePointRight, PointF), CType(.ToSidePointLeft, PointF))
                Return oPath
            End If
        End With
        Return Nothing
    End Function

    Public Function GetPlanAreaPolygon(ByVal Segment As cSegment) As GraphicsPath
        With Segment.Data.Plan
            If .ToSidePointLeft <> .ToSidePointRight Or .FromSidePointRight <> .FromSidePointLeft Then
                Dim oPath As GraphicsPath = New GraphicsPath
                Dim oPointsColl As List(Of PointF) = New List(Of PointF)
                Dim oFSdx As PointF = .FromSidePointRight
                Dim oFSsx As PointF = .FromSidePointLeft
                Dim oTSdx As PointF = .ToSidePointRight
                Dim oTSsx As PointF = .ToSidePointLeft
                Dim sDir1 As Single = modPaint.GetBearing(oFSdx, oFSsx)
                Dim sDir2 As Single = modPaint.GetBearing(oTSdx, oTSsx)
                Dim sDiff As Single = Math.Abs(sDir1 - sDir2)
                If sDiff > 90 And sDiff < 270 Then
                    Call oPath.AddPolygon({oFSdx, oFSsx, oTSdx, oTSsx})
                Else
                    Call oPath.AddPolygon({oFSdx, oFSsx, oTSsx, oTSdx})
                End If
                Return oPath
            End If
        End With
        Return Nothing
    End Function

    Public Function GetProfileAreaLine(ByVal Segment As cSegment) As GraphicsPath ' As PointF()
        With Segment.Data.Profile
            If .ToSidePointDown <> .ToSidePointUp Then
                Dim oPath As GraphicsPath = New GraphicsPath
                Call oPath.AddLine(CType(.ToSidePointUp, PointF), CType(.ToSidePointDown, PointF))
                Return oPath
            End If
        End With
        Return Nothing
    End Function

    Public Function GetProfileAreaPolygon(ByVal Segment As cSegment) As GraphicsPath ' As PointF()
        With Segment.Data.Profile
            If .ToSidePointDown <> .ToSidePointUp Or .FromSidePointUp <> .FromSidePointDown Then
                Dim oPath As GraphicsPath = New GraphicsPath
                Dim oPointsColl As List(Of PointF) = New List(Of PointF)
                Dim oFSdx As PointF = .FromSidePointUp
                Dim oFSsx As PointF = .FromSidePointDown
                Dim oTSdx As PointF = .ToSidePointUp
                Dim oTSsx As PointF = .ToSidePointDown
                Call oPath.AddPolygon({oFSdx, oFSsx, oTSsx, oTSdx})
                Return oPath
            End If
        End With
        Return Nothing
    End Function
End Module
