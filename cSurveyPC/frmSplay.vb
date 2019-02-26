Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Public Class frmSplay
    Private oSurvey As cSurvey.cSurvey
    Private oDesign As cDesign

    Public Enum ContextEnum
        Data = 0
        Design = 1
    End Enum

    Private iContext As ContextEnum

    Friend Class ApplySplayPropertiesEventArgs
        Private oDesign As cDesign

        Private bApplyToPlan As Boolean
        Private bApplyToProfile As Boolean
        Private bApplyToCrossSection As Boolean

        Private bCrossSectionShowSplayBorder As Boolean
        Private bCrossSectionShowOnlyCutSplay As Boolean
        Private sCrossSectionSplayProjectionAngle As Single
        Private sCrossSectionSplayMaxVariationAngle As Single
        Private iCrossSectionSplayLineStyle As Integer
        Private bCrossSectionSplayText As Boolean

        Private sProfileSplayProjectionAngle As Single
        Private sProfileSplayMaxVariationAngle As Single
        Private oProfileSplayPosInclinationRange As SizeF
        Private oProfileSplayNegInclinationRange As SizeF

        Private iPlanSplayPlanProjectionType As Integer
        Private sPlanSplayPlanDeltaZ As Single
        Private sPlanSplayMaxVariationDelta As Single
        Private oPlanSplayInclinationRange As SizeF

        Public ReadOnly Property ProfileSplayPosInclinationRange As SizeF
            Get
                Return oProfileSplayPosInclinationRange
            End Get
        End Property

        Public ReadOnly Property ProfileSplayNegInclinationRange As SizeF
            Get
                Return oProfileSplayNegInclinationRange
            End Get
        End Property

        Public ReadOnly Property PlanSplayInclinationRange As SizeF
            Get
                Return oPlanSplayInclinationRange
            End Get
        End Property

        Public ReadOnly Property Design As cDesign
            Get
                Return oDesign
            End Get
        End Property

        Public ReadOnly Property ApplyToPlan As Boolean
            Get
                Return bApplyToPlan
            End Get
        End Property

        Public ReadOnly Property ApplyToProfile As Boolean
            Get
                Return bApplyToProfile
            End Get
        End Property

        Public ReadOnly Property ApplyToCrossSection As Boolean
            Get
                Return bApplyToCrossSection
            End Get
        End Property

        Public ReadOnly Property CrossSectionShowSplayBorder As Boolean
            Get
                Return bCrossSectionShowSplayBorder
            End Get
        End Property

        Public ReadOnly Property CrossSectionShowOnlyCutSplay As Boolean
            Get
                Return bCrossSectionShowOnlyCutSplay
            End Get
        End Property

        Public ReadOnly Property CrossSectionSplayProjectionAngle As Single
            Get
                Return sCrossSectionSplayProjectionAngle
            End Get
        End Property

        Public ReadOnly Property CrossSectionSplayMaxVariationAngle As Single
            Get
                Return sCrossSectionSplayMaxVariationAngle
            End Get
        End Property

        Public ReadOnly Property CrossSectionSplayLineStyle As Integer
            Get
                Return iCrossSectionSplayLineStyle
            End Get
        End Property

        Public ReadOnly Property CrossSectionSplayText As Boolean
            Get
                Return bCrossSectionSplayText
            End Get
        End Property

        Public ReadOnly Property ProfileSplayProjectionAngle As Single
            Get
                Return sProfileSplayProjectionAngle
            End Get
        End Property

        Public ReadOnly Property ProfileSplayMaxVariationAngle As Single
            Get
                Return sProfileSplayMaxVariationAngle
            End Get
        End Property

        Public ReadOnly Property PlanSplayPlanProjectionType As Integer
            Get
                Return iPlanSplayPlanProjectionType
            End Get
        End Property

        Public ReadOnly Property PlanSplayPlanDeltaZ As Single
            Get
                Return sPlanSplayPlanDeltaZ
            End Get
        End Property

        Public ReadOnly Property PlanSplayMaxVariationDelta As Single
            Get
                Return sPlanSplayMaxVariationDelta
            End Get
        End Property

        Public Sub New(Form As frmSplay)
            oDesign = Form.oDesign

            bApplyToPlan = Form.chkPlan.Checked
            bApplyToProfile = Form.chkProfile.Checked
            bApplyToCrossSection = Form.chkCrossSection.Checked

            bCrossSectionShowSplayBorder = Form.chkPropCrossSectionShowSplayBorder.Checked
            bCrossSectionShowOnlyCutSplay = Form.chkPropCrossSectionShowOnlyCutSplay.Checked
            sCrossSectionSplayProjectionAngle = Form.txtPropCrossSectionSplayProjectionAngle.Value
            sCrossSectionSplayMaxVariationAngle = Form.txtPropCrossSectionSplayMaxVariationAngle.Value
            iCrossSectionSplayLineStyle = Form.cboPropCrossSectionSplayLineStyle.SelectedIndex
            bCrossSectionSplayText = Form.chkPropCrossSectionSplayText.Checked

            sProfileSplayProjectionAngle = Form.txtPropProfileSplayProjectionAngle.Value
            sProfileSplayMaxVariationAngle = Form.txtPropProfileSplayMaxVariationAngle.Value
            oProfileSplayPosInclinationRange = New SizeF(Form.txtPropProfileSplayPosInclinationRangeMin.Value, Form.txtPropProfileSplayPosInclinationRangeMax.Value)
            oProfileSplayNegInclinationRange = New SizeF(Form.txtPropProfileSplayNegInclinationRangeMin.Value, Form.txtPropProfileSplayNegInclinationRangeMax.Value)

            iPlanSplayPlanProjectionType = Form.cboPropPlanSplayPlanProjectionType.SelectedIndex
            sPlanSplayPlanDeltaZ = Form.txtPropPlanSplayPlanDeltaZ.Value
            sPlanSplayMaxVariationDelta = Form.txtPropPlanSplayMaxVariationDelta.Value
            oPlanSplayInclinationRange = New SizeF(Form.txtPropPlanSplayInclinationRangeMin.Value, Form.txtPropPlanSplayInclinationRangeMax.Value)
        End Sub
    End Class

    Friend Event OnApply(ByVal Sender As Object, Args As ApplySplayPropertiesEventArgs) ' ByVal InfoBoxOptions As cOptionsPreview.cInfoBoxOptions)

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        RaiseEvent OnApply(Me, New ApplySplayPropertiesEventArgs(Me))
        Call Close()
    End Sub

    Private Sub pSetNumericUpDownValue(Item As NumericUpDown, Value As Integer, DefaultValue As Integer)
        If Value >= Item.Minimum AndAlso Value <= Item.Maximum Then
            Item.Value = Value
        Else
            Item.Value = DefaultValue
        End If
    End Sub

    Friend Sub New(Survey As cSurvey.cSurvey, Context As ContextEnum, Tools As Helper.Editor.cEditDesignTools)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        iContext = Context
        oDesign = Tools.Design
        If iContext = ContextEnum.Data Then
            Call TabMain.TabPages.Remove(TabPage3)
        Else
            If oDesign.Type = cIDesign.cDesignTypeEnum.Plan Then
                Call TabMain.TabPages.Remove(TabPage2)
                Call TabMain.TabPages.Remove(TabPage3)
            ElseIf oDesign.Type = cIDesign.cDesignTypeEnum.Profile Then
                Call TabMain.TabPages.Remove(TabPage1)
            End If
        End If

        Dim oSegment As cItemSegment
        If TypeOf Tools.CurrentItem Is cItemSegment Then
            oSegment = Tools.CurrentItem
        End If
        If IsNothing(oSegment) Then
            Try
                cboPropPlanSplayPlanProjectionType.SelectedIndex = cIItemPlanSplayBorder.PlanSplayBorderProjectionTypeEnum.All
                txtPropPlanSplayPlanDeltaZ.Value = 0
                txtPropPlanSplayMaxVariationDelta.Value = 0
                txtPropPlanSplayInclinationRangeMin.Value = modSegmentsTools.GetDefaultPlanSplayBorderInclinationRange.Width
                txtPropPlanSplayInclinationRangeMax.Value = modSegmentsTools.GetDefaultPlanSplayBorderInclinationRange.Height
            Catch ex As Exception
            End Try
        Else
            Try
                cboPropPlanSplayPlanProjectionType.SelectedIndex = oSegment.PlanSplayBorderProjectionType
                Call pSetNumericUpDownValue(txtPropPlanSplayPlanDeltaZ, oSegment.PlanSplayBorderProjectionDeltaZ, 0)
                Call pSetNumericUpDownValue(txtPropPlanSplayMaxVariationDelta, oSegment.PlanSplayBorderMaxDeltaVariation, 0)
                Call pSetNumericUpDownValue(txtPropPlanSplayInclinationRangeMin, oSegment.PlanSplayBorderInclinationRange.Width, -90)
                Call pSetNumericUpDownValue(txtPropPlanSplayInclinationRangeMax, oSegment.PlanSplayBorderInclinationRange.Height, 90)
            Catch ex As Exception
            End Try
        End If

        If IsNothing(oSegment) Then
            Try
                txtPropProfileSplayProjectionAngle.Value = 0
                txtPropProfileSplayMaxVariationAngle.Value = 0
                txtPropProfileSplayPosInclinationRangeMin.Value = modSegmentsTools.GetDefaultProfileSplayBorderPosInclinationRange.Width
                txtPropProfileSplayPosInclinationRangeMax.Value = modSegmentsTools.GetDefaultProfileSplayBorderPosInclinationRange.Height
                txtPropProfileSplayNegInclinationRangeMin.Value = modSegmentsTools.GetDefaultProfileSplayBorderNegInclinationRange.Width
                txtPropProfileSplayNegInclinationRangeMax.Value = modSegmentsTools.GetDefaultProfileSplayBorderNegInclinationRange.Height
            Catch ex As Exception
            End Try
        Else
            Try
                Call pSetNumericUpDownValue(txtPropProfileSplayProjectionAngle, oSegment.ProfileSplayBorderProjectionAngle, 0)
                Call pSetNumericUpDownValue(txtPropProfileSplayMaxVariationAngle, oSegment.ProfileSplayBorderMaxAngleVariation, 0)
                Call pSetNumericUpDownValue(txtPropProfileSplayPosInclinationRangeMin, oSegment.ProfileSplayBorderPosInclinationRange.Width, 0)
                Call pSetNumericUpDownValue(txtPropProfileSplayPosInclinationRangeMax, oSegment.ProfileSplayBorderPosInclinationRange.Height, 90)
                Call pSetNumericUpDownValue(txtPropProfileSplayNegInclinationRangeMin, oSegment.ProfileSplayBorderNegInclinationRange.Width, -90)
                Call pSetNumericUpDownValue(txtPropProfileSplayNegInclinationRangeMax, oSegment.ProfileSplayBorderNegInclinationRange.Height, 0)
            Catch ex As Exception
            End Try
        End If

        Dim oCrossSection As cItemCrossSection
        If TypeOf Tools.CurrentItem Is cItemCrossSection Then
            oCrossSection = Tools.CurrentItem
        End If
        If IsNothing(oCrossSection) Then
            Try
                txtPropCrossSectionSplayProjectionAngle.Value = 0
                cboPropCrossSectionSplayLineStyle.SelectedIndex = cOptions.SplayStyleEnum.PointsAndRays
                txtPropCrossSectionSplayMaxVariationAngle.Value = 20
                chkPropCrossSectionShowSplayBorder.Checked = False
                chkPropCrossSectionSplayText.Checked = False
            Catch ex As Exception
            End Try
        Else
            Try
                Call pSetNumericUpDownValue(txtPropCrossSectionSplayProjectionAngle, oCrossSection.SplayBorderProjectionAngle, 0)
                cboPropCrossSectionSplayLineStyle.SelectedIndex = oCrossSection.SplayBorderLineStyle
                Call pSetNumericUpDownValue(txtPropCrossSectionSplayMaxVariationAngle, oCrossSection.SplayBorderMaxAngleVariation, 0)
                chkPropCrossSectionShowSplayBorder.Checked = oCrossSection.ShowSplayBorder
                chkPropCrossSectionSplayText.Checked = oCrossSection.ShowSplayText
                TabMain.SelectedTab = TabPage3
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        RaiseEvent OnApply(Me, New ApplySplayPropertiesEventArgs(Me))
        Call Close()
    End Sub

    Private Sub chkPlan_CheckedChanged(sender As Object, e As EventArgs) Handles chkPlan.CheckedChanged
        pnlPlan.Enabled = chkPlan.Checked
    End Sub

    Private Sub chkProfile_CheckedChanged(sender As Object, e As EventArgs) Handles chkProfile.CheckedChanged
        pnlProfile.Enabled = chkProfile.Checked
    End Sub

    Private Sub cboPropPlanSplayPlanProjectionType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropPlanSplayPlanProjectionType.SelectedIndexChanged
        If cboPropPlanSplayPlanProjectionType.SelectedIndex > 0 Then
            lblPropPlanSplayPlanDeltaZ.Enabled = True
            txtPropPlanSplayPlanDeltaZ.Enabled = True
            lblPropPlanSplayMaxVariationDelta.Enabled = True
            txtPropPlanSplayMaxVariationDelta.Enabled = True
        Else
            lblPropPlanSplayPlanDeltaZ.Enabled = False
            txtPropPlanSplayPlanDeltaZ.Enabled = False
            lblPropPlanSplayMaxVariationDelta.Enabled = False
            txtPropPlanSplayMaxVariationDelta.Enabled = False
        End If
    End Sub

    Private Sub chkCrossSection_CheckedChanged(sender As Object, e As EventArgs) Handles chkCrossSection.CheckedChanged
        pnlCrosssection.Enabled = chkCrossSection.Checked
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        RaiseEvent OnApply(Me, New ApplySplayPropertiesEventArgs(Me))
    End Sub
End Class