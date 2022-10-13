Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemPointLineTypePropertyControl2

    Friend Delegate Sub PointSequencesToDelegate(NewLineType As cIItemLine.LineTypeEnum)

    Private oSequencesTo As PointSequencesToDelegate

    Public Shadows Sub Rebind(Point As cPoint, SequencesTo As PointSequencesToDelegate)
        MyBase.Rebind(Point)

        oSequencesTo = SequencesTo

        Dim iLineType As Items.cIItemLine.LineTypeEnum
        With Point
            If .BeginSequence Then
                iLineType = .LineType
            Else
                Dim oSequence As cSequence = Point.GetSequence
                If oSequence Is Nothing Then
                    iLineType = cIItemLine.LineTypeEnum.Undefined
                Else
                    With oSequence.First
                        iLineType = .LineType
                    End With
                End If
            End If
            If iLineType = cIItemLine.LineTypeEnum.Splines Then
                chkStyleSpline.Checked = True
            ElseIf iLineType = cIItemLine.LineTypeEnum.Lines Then
                chkStyleStraightLine.Checked = True
            ElseIf iLineType = cIItemLine.LineTypeEnum.Beziers Then
                chkStyleBezier.Checked = True
            Else
                chkStyleAsParent.Checked = True
            End If
        End With
    End Sub

    Private Sub chkStyleAsParent_CheckedChanged(sender As Object, e As EventArgs) Handles chkStyleAsParent.CheckedChanged
        If Not DisabledObjectProperty Then
            If chkStyleAsParent.Checked Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo34"))
                Dim oItem As cIItemLine = Item
                Call oSequencesTo(oItem.LineType)
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineStyle")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkStyleStraightLine_CheckedChanged(sender As Object, e As EventArgs) Handles chkStyleStraightLine.CheckedChanged
        If Not DisabledObjectProperty Then
            If chkStyleStraightLine.Checked Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo34"))
                Call oSequencesTo(cIItemLine.LineTypeEnum.Lines)
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineStyle")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkStyleSpline_CheckedChanged(sender As Object, e As EventArgs) Handles chkStyleSpline.CheckedChanged
        If Not DisabledObjectProperty Then
            If chkStyleSpline.Checked Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo34"))
                Call oSequencesTo(cIItemLine.LineTypeEnum.Splines)
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineStyle")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkStyleBezier_CheckedChanged(sender As Object, e As EventArgs) Handles chkStyleBezier.CheckedChanged
        If Not DisabledObjectProperty Then
            If chkStyleBezier.Checked Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo34"))
                Call oSequencesTo(cIItemLine.LineTypeEnum.Beziers)
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineStyle")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub
End Class
