Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemLineTypePropertyControl2

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Friend Delegate Sub SequencesToDelegate(NewLineType As cIItemLine.LineTypeEnum, AlsoCustomized As Boolean)

    Private oSequencesTo As SequencesToDelegate

    Public Shadows Sub Rebind(Item As cItem, SequencesTo As SequencesToDelegate)
        MyBase.Rebind(Item)

        oSequencesTo = SequencesTo

        Dim oItem As cIItemLine = DirectCast(Item, cIItemLine)
        If oItem.LineType = cIItemLine.LineTypeEnum.Splines Then
            chkStyleSpline.Checked = True
        ElseIf oItem.LineType = cIItemLine.LineTypeEnum.Splines Then
            chkStyleStraightLine.Checked = True
        ElseIf oItem.LineType = cIItemLine.LineTypeEnum.Beziers Then
            chkStyleBezier.Checked = True
        End If
    End Sub

    Private Sub chkStyleStraightLine_CheckedChanged(sender As Object, e As EventArgs) Handles chkStyleStraightLine.CheckedChanged
        If Not DisabledObjectProperty Then
            If chkStyleStraightLine.Checked Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo34"))
                Call oSequencesTo(cIItemLine.LineTypeEnum.Lines, My.Computer.Keyboard.ShiftKeyDown)
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
                Call oSequencesTo(cIItemLine.LineTypeEnum.Splines, My.Computer.Keyboard.ShiftKeyDown)
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
                Call oSequencesTo(cIItemLine.LineTypeEnum.Beziers, My.Computer.Keyboard.ShiftKeyDown)
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineStyle")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub
End Class
