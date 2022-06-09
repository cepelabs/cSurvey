Imports cSurveyPC.cSurvey

Public Class cCaveInfoBranchesCombobox

    Public Shadows Sub Rebind(CaveinfoBranch As cICaveInfoBranches, Reset As Boolean, Optional AllowEmpty As Boolean = True, Optional AllowLocked As AllowLockedEnum = AllowLockedEnum.True)
        Dim oEmptyCaveInfo As cCaveInfoBranch = CaveinfoBranch.Branches.GetEmptyCaveInfoBranch
        Call MyBase.CaveItems.Clear()
        If AllowEmpty Then MyBase.CaveItems.Add(oEmptyCaveInfo)
        Call pSubRebind(CaveinfoBranch.Branches, AllowLocked)
        Call MyBase.Rebind(Reset)
    End Sub

    Private Sub pSubRebind(CaveinfoBranch As cCaveInfoBranches, AllowLocked As AllowLockedEnum)
        For Each oCaveInfo As cCaveInfoBranch In CaveinfoBranch
            If oCaveInfo.GetLocked Then
                If AllowLocked = AllowLockedEnum.True Then
                    Call MyBase.CaveItems.Add(oCaveInfo)
                ElseIf AllowLocked = AllowLockedEnum.Default Then
                    If MyBase.Workmode = WorkmodeEnum.View Then
                        Call MyBase.CaveItems.Add(oCaveInfo)
                    End If
                End If
            Else
                Call MyBase.CaveItems.Add(oCaveInfo)
            End If
            Call pSubRebind(oCaveInfo.Branches, AllowLocked)
        Next
    End Sub

End Class
