Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Module modCaveAndBranch
    Friend Class cCaveBranchPlaceholder
        Public Cave As String
        Public Branch As String
        Public ZOrder As Integer

        Public Sub New(Cave As String, Branch As String, Optional ZOrder As Integer = 0)
            Me.Cave = Cave
            Me.Branch = Branch
            Me.ZOrder = ZOrder
        End Sub
    End Class

    Public Class cCaveBranchPlaceHolderComparer
        Implements IComparer(Of cCaveBranchPlaceholder)

        Public Function Compare(x As cCaveBranchPlaceholder, y As cCaveBranchPlaceholder) As Integer Implements System.Collections.Generic.IComparer(Of cCaveBranchPlaceholder).Compare
            If x Is Nothing AndAlso y Is Nothing Then
                Return 0
            ElseIf x Is Nothing AndAlso Not y Is Nothing Then
                Return -1
            ElseIf Not x Is Nothing AndAlso y Is Nothing Then
                Return 1
            Else
                If x.ZOrder > y.ZOrder Then
                    Return 1
                ElseIf x.ZOrder = y.ZOrder Then
                    Return 0
                Else
                    Return -1
                End If
            End If
        End Function
    End Class

    Public Sub AppendCaves(Survey As cSurvey.cSurvey, List As List(Of cCaveBranchPlaceholder))
        Call List.Add(New cCaveBranchPlaceholder("", "", -1))
        For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
            Call List.Add(New cCaveBranchPlaceholder(oCaveInfo.Name, "", oCaveInfo.DrawingZOrder))
            Call AppendBranches(oCaveInfo.Branches, List)
        Next
    End Sub

    Public Sub AppendBranches(Branches As cCaveInfoBranches, List As List(Of cCaveBranchPlaceholder))
        For Each oCaveInfoBranch As cCaveInfoBranch In Branches
            Call List.Add(New cCaveBranchPlaceholder(oCaveInfoBranch.Cave, oCaveInfoBranch.Path, oCaveInfoBranch.DrawingZOrder))
            Call AppendBranches(oCaveInfoBranch.Branches, List)
        Next
    End Sub
End Module
