Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Properties

Public Class frmParametersSegments
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptions)

    Private oOptions As cOptions
    Private oSurvey As cSurvey.cSurvey
    Private iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum

    Private bDisabledEvent As Boolean

    Public Sub New(ByVal Options As cOptions, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        oSurvey = oOptions.Survey
        iApplyTo = ApplyTo

        bDisabledEvent = True

        chkSurface.Checked = (oOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Surface) = cOptions.DrawSegmentsOptionsEnum.Surface
        chkDuplicate.Checked = (oOptions.DrawSegmentsOptions And cOptions.DrawSegmentsOptionsEnum.Duplicate) = cOptions.DrawSegmentsOptionsEnum.Duplicate
        cboSegmentsPaintStyle.SelectedIndex = oOptions.DrawStyle
        cboSplayStyle.SelectedIndex = oOptions.SplayStyle

        If iApplyTo = cIDesign.cDesignTypeEnum.Profile Then
            grpSurface.Enabled = True
            chkDesignSurfaceProfile.Checked = oOptions.DrawSurfaceProfile
        Else
            grpSurface.Enabled = False
        End If

        lvDesignPlotShowHLsDett.Items.Clear()
        For Each oDetail As cHighlightsDetail In oSurvey.Properties.HighlightsDetails
            Dim oItem As ListViewItem = New ListViewItem()
            oItem.Name = oDetail.ID
            oItem.Text = oDetail.Name
            oItem.Checked = oOptions.HighlightsOptions.Get(oDetail)
            Call lvDesignPlotShowHLsDett.Items.Add(oItem)
        Next

        bDisabledEvent = False
    End Sub

    Private Sub pSave()
        oOptions.DrawSegmentsOptions = cOptions.DrawSegmentsOptionsEnum.None
        oOptions.DrawStyle = cboSegmentsPaintStyle.SelectedIndex
        If chkSurface.Checked Then oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions Or cOptions.DrawSegmentsOptionsEnum.Surface
        If chkDuplicate.Checked Then oOptions.DrawSegmentsOptions = oOptions.DrawSegmentsOptions Or cOptions.DrawSegmentsOptionsEnum.Duplicate
        oOptions.DrawHighlights = chkShowHLs.Checked
        oOptions.SplayStyle = cboSplayStyle.SelectedIndex
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
        Call Dispose()
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
    End Sub

    Private Sub chkShowHLs_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowHLs.CheckedChanged
        lvDesignPlotShowHLsDett.Enabled = chkShowHLs.Checked
    End Sub

    Private Sub lvDesignPlotShowHLsDett_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvDesignPlotShowHLsDett.ItemCheck
        Call oOptions.HighlightsOptions.Set(lvDesignPlotShowHLsDett.Items(e.Index).Name, e.NewValue)
    End Sub

    Private Sub chkDesignSurfaceProfile_CheckedChanged(sender As Object, e As EventArgs) Handles chkDesignSurfaceProfile.CheckedChanged
        oOptions.DrawSurfaceProfile = chkDesignSurfaceProfile.Checked
    End Sub
End Class