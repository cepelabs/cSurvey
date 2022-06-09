Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemPointNavigatorPropertyControl

    Public Shadows Sub Rebind(Point As cPoint)
        MyBase.Rebind(Point)

        txtPropPointType.Text = Point.Type.ToString
    End Sub

    Private Sub cmdPropParent_Click(sender As Object, e As EventArgs) Handles cmdPropParent.Click
        MyBase.DoCommand("endpointedit")
    End Sub

    Private Sub cmdPropNext_Click(sender As Object, e As EventArgs) Handles cmdPropNext.Click
        Call MyBase.DoCommand("pointmovenext")
    End Sub

    Private Sub cmdPropPrev_Click(sender As Object, e As EventArgs) Handles cmdPropPrev.Click
        Call MyBase.DoCommand("pointmoveprev")
    End Sub
End Class
