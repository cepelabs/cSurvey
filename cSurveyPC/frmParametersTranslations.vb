Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class frmParametersTranslations
    Friend Event OnChangeOptions(ByVal Sender As Object, ByVal Options As cOptions)

    Private oTransactionsBag As cTranslationsBag

    Private oOptions As cOptions
    Private oSurvey As cSurvey.cSurvey
    Private iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum

    Private bDisabledEvent As Boolean

    Friend Class cTranslationsBagItem
        Private sCave As String
        Private sBranch As String
        Private sX As Single
        Private sY As Single

        Friend Sub New(ByVal Cave As String, ByVal Branch As String, ByVal X As Single, ByVal Y As Single)
            sCave = Cave
            sBranch = Branch
            sX = X
            sY = Y
        End Sub

        Public ReadOnly Property Cave As String
            Get
                Return sCave
            End Get
        End Property

        Public ReadOnly Property Branch As String
            Get
                Return sBranch
            End Get
        End Property

        'Public Property BreakPercentage As Single
        '    Get
        '        Return sBreakPercentage
        '    End Get
        '    Set(value As Single)
        '        sBreakPercentage = value
        '    End Set
        'End Property

        'Public Property Priority As cTranslation.cTranslationPriorityEnum
        '    Get
        '        Return iPriority
        '    End Get
        '    Set(value As cTranslation.cTranslationPriorityEnum)
        '        iPriority = value
        '    End Set
        'End Property

        Public Property X As Single
            Get
                Return sX
            End Get
            Set(ByVal value As Single)
                sX = value
            End Set
        End Property

        Public Property Y As Single
            Get
                Return sY
            End Get
            Set(ByVal value As Single)
                sY = value
            End Set
        End Property
    End Class

    Friend Class cTranslationsBag
        Implements IEnumerable

        Private oItems As List(Of cTranslationsBagItem)

        Public Sub Apply(ByVal Survey As cSurvey.cSurvey, TranslationsOptions As Options.cTranslationsOptions, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)
            For Each oItem As cTranslationsBagItem In oItems
                Dim sCave As String = oItem.Cave
                Dim sBranch As String = oItem.Branch
                Dim sX As Single = oItem.X
                Dim sY As Single = oItem.Y
                Try
                    If sCave = "" Then
                        TranslationsOptions.OriginalPositionTranslation.X = sX
                        TranslationsOptions.OriginalPositionTranslation.Y = sY
                    Else
                        If sBranch = "" Then
                            Dim oCaveInfo As cCaveInfo = Survey.Properties.CaveInfos(sCave)
                            Dim oTranslation As cTranslation
                            Select Case ApplyTo
                                Case cIDesign.cDesignTypeEnum.Profile
                                    oTranslation = oCaveInfo.Translations.Profile
                                Case Else
                                    oTranslation = oCaveInfo.Translations.Plan
                            End Select
                            oTranslation.X = sX
                            oTranslation.Y = sY
                        Else
                            Dim oCaveInfoBranch As cCaveInfoBranch = Survey.Properties.CaveInfos(sCave).Branches(sBranch)
                            Dim oTranslation As cTranslation
                            Select Case ApplyTo
                                Case cIDesign.cDesignTypeEnum.Profile
                                    oTranslation = oCaveInfoBranch.Translations.Profile
                                Case Else
                                    oTranslation = oCaveInfoBranch.Translations.Plan
                            End Select
                            oTranslation.X = sX
                            oTranslation.Y = sY
                        End If
                    End If
                Catch
                End Try
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, TranslationsOptions As Options.cTranslationsOptions, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)
            oItems = New List(Of cTranslationsBagItem)
            For Each oCaveInfo As cCaveInfo In Survey.Properties.CaveInfos
                Dim oTranslation As cTranslation
                Select Case ApplyTo
                    Case cIDesign.cDesignTypeEnum.Profile
                        oTranslation = oCaveInfo.Translations.Profile
                    Case Else
                        oTranslation = oCaveInfo.Translations.Plan
                End Select
                Call Append(oCaveInfo.Name, "", oTranslation.X, oTranslation.Y) ', oTranslation.Priority, oTranslation.BreakPercentage)
                Call pAppendBranches(ApplyTo, oCaveInfo.Branches)
            Next
            Call Append("", "", TranslationsOptions.OriginalPositionTranslation.X, TranslationsOptions.OriginalPositionTranslation.Y)
        End Sub

        Private Sub pAppendBranches(ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum, Branches As cCaveInfoBranches)
            Dim oTranslation As cTranslation
            For Each oCaveInfoBranch As cCaveInfoBranch In Branches
                Select Case ApplyTo
                    Case cIDesign.cDesignTypeEnum.Profile
                        oTranslation = oCaveInfoBranch.Translations.Profile
                    Case Else
                        oTranslation = oCaveInfoBranch.Translations.Plan
                End Select
                Call Append(oCaveInfoBranch.Cave, oCaveInfoBranch.Path, oTranslation.X, oTranslation.Y) ', oTranslation.Priority, oTranslation.BreakPercentage)
                Call pAppendBranches(ApplyTo, oCaveInfoBranch.Branches)
            Next
        End Sub

        Friend Sub New()
            oItems = New List(Of cTranslationsBagItem)
        End Sub

        Public ReadOnly Property Item(ByVal Index As Integer) As cTranslationsBagItem
            Get
                Return oItems(Index)
            End Get
        End Property

        Public ReadOnly Property Count() As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Function Append(ByVal Cave As String, ByVal Branch As String, ByVal X As Single, ByVal Y As Single) ', Priority As cTranslation.cTranslationPriorityEnum, BreakPercentage As Single) As cTranslationsBagItem
            Dim oItem As cTranslationsBagItem = New cTranslationsBagItem(Cave, Branch, X, Y) ', Priority, BreakPercentage)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class

    Public Sub New(ByVal Options As cOptions, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        oSurvey = oOptions.Survey
        iApplyTo = ApplyTo

        chkShowLine.Checked = oOptions.TranslationsOptions.DrawTranslationsLine
        chkShowOriginalPosition.Checked = oOptions.TranslationsOptions.DrawOriginalPosition
        chkShowOriginalPosition.Enabled = True
        txtTranslationsThreshold.Value = oOptions.TranslationsOptions.TranslationsThreshold
        cboOriginalPositionColorMode.SelectedIndex = oOptions.TranslationsOptions.OriginalPositionColorMode
        chkOriginalPositionColorGray.Checked = oOptions.TranslationsOptions.OriginalPositionColorGray
        chkOriginalPositionOnlyTranslated.Checked = oOptions.TranslationsOptions.OriginalPositionOnlyTranslated
        chkOriginalPositionOverDesign.Checked = oOptions.TranslationsOptions.OriginalPositionOverDesign

        bDisabledEvent = True
        oTransactionsBag = New cTranslationsBag(oOptions.Survey, Options.TranslationsOptions, ApplyTo)

        'Dim oComboColumn As DataGridViewComboBoxColumn = grdTraslations.Columns(4)
        'oComboColumn.Items.Add(New KeyValuePair(Of cTranslation.cTranslationPriorityEnum, String)(cTranslation.cTranslationPriorityEnum.Default, "Non definito"))
        'oComboColumn.Items.Add(New KeyValuePair(Of cTranslation.cTranslationPriorityEnum, String)(cTranslation.cTranslationPriorityEnum.YX, "Prima Y poi X"))
        'oComboColumn.Items.Add(New KeyValuePair(Of cTranslation.cTranslationPriorityEnum, String)(cTranslation.cTranslationPriorityEnum.XY, "Prima X poi Y"))
        'oComboColumn.DisplayMember = "Value"
        'oComboColumn.ValueMember = "Key"

        Call pTransactionsBagToGrid()

        'Dim oTranslationTrigPoints As cTranslatedTrigPoints = New cTranslatedTrigPoints
        'If iApplyTo = cIDesign.cDesignTypeEnum.Profile Then
        '    For Each oSegment As cSegment In oSurvey.Segments
        '        If Not oSegment.Splay Then
        '            With oSegment.Data
        '                Dim oTranslation As SizeF = modPlot.GetProfileSegmentTranslation(oSurvey, oSegment)
        '                If oTranslation.IsEmpty Then
        '                    Call oTranslationTrigPoints.Add(.Data.From, .Profile.FromPoint)
        '                    Call oTranslationTrigPoints.Add(.Data.To, .Profile.ToPoint)
        '                Else
        '                    Call oTranslationTrigPoints.Add(.Data.From, PointF.Add(.Profile.FromPoint, oTranslation))
        '                    Call oTranslationTrigPoints.Add(.Data.To, PointF.Add(.Profile.ToPoint, oTranslation))
        '                End If
        '            End With
        '        End If
        '    Next
        'Else
        '    For Each oSegment As cSegment In oSurvey.Segments
        '        If Not oSegment.Splay Then
        '            With oSegment.Data
        '                Dim oTranslation As SizeF = modPlot.GetPlanSegmentTranslation(oSurvey, oSegment)
        '                If oTranslation.IsEmpty Then
        '                    Call oTranslationTrigPoints.Add(.Data.From, .Plan.FromPoint)
        '                    Call oTranslationTrigPoints.Add(.Data.To, .Plan.ToPoint)
        '                Else
        '                    Call oTranslationTrigPoints.Add(.Data.From, PointF.Add(.Plan.FromPoint, oTranslation))
        '                    Call oTranslationTrigPoints.Add(.Data.To, PointF.Add(.Plan.ToPoint, oTranslation))
        '                End If
        '            End With
        '        End If
        '    Next
        'End If
        'For Each oTranslationTrigPoint As cTranslatedTrigPoint In oTranslationTrigPoints
        '    If oTranslationTrigPoint.Count > 1 Then
        '        Dim oData(3) As Object
        '        oData(0) = True
        '        oData(1) = oTranslationTrigPoint.Name
        '        oData(2) = 1
        '        oData(3) = oTranslationTrigPoint.ToString
        '        grdStations.Rows.Add(oData)
        '    End If
        'Next

        bDisabledEvent = False
    End Sub

    Private Sub pTransactionsBagToGrid()
        For Each oItem As cTranslationsBagItem In oTransactionsBag
            Dim oRow(3) As Object
            If oItem.Cave = "" AndAlso oItem.Branch = "" Then
                oRow(0) = modMain.GetLocalizedString("translations.originalposition")
                oRow(1) = ""
            Else
                oRow(0) = oItem.Cave
                oRow(1) = oItem.Branch
            End If
            oRow(2) = oItem.X
            oRow(3) = oItem.Y
            Dim iRow As Integer = grdTraslations.Rows.Add(oRow)
            grdTraslations.Rows(iRow).Tag = oItem
        Next
    End Sub

    Private Sub pGridToTransactionsBag()
        For Each oRow As DataGridViewRow In grdTraslations.Rows
            Dim oItem As cTranslationsBagItem = oRow.Tag
            oItem.X = oRow.Cells(2).Value
            oItem.Y = oRow.Cells(3).Value
        Next
    End Sub

    Private Sub cmdApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApply.Click
        Call pSave()
        RaiseEvent OnChangeOptions(Me, oOptions)
    End Sub

    Private Sub pSave()
        oOptions.TranslationsOptions.DrawTranslationsLine = chkShowLine.Checked
        oOptions.TranslationsOptions.TranslationsThreshold = txtTranslationsThreshold.Value
        oOptions.TranslationsOptions.DrawOriginalPosition = chkShowOriginalPosition.Checked
        oOptions.TranslationsOptions.OriginalPositionColorMode = cboOriginalPositionColorMode.SelectedIndex
        oOptions.TranslationsOptions.OriginalPositionColorGray = chkOriginalPositionColorGray.Checked
        oOptions.TranslationsOptions.OriginalPositionOnlyTranslated = chkOriginalPositionOnlyTranslated.Checked
        oOptions.TranslationsOptions.OriginalPositionOverDesign = chkOriginalPositionOverDesign.Checked

        Call pGridToTransactionsBag()
        Call oTransactionsBag.Apply(oOptions.Survey, oOptions.TranslationsOptions, iApplyTo)
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

    Private Sub chkShowOriginalPosition_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowOriginalPosition.CheckedChanged
        Dim bEnabled As Boolean = chkShowOriginalPosition.Checked
        lblOriginalPositionColorMode.Enabled = bEnabled
        cboOriginalPositionColorMode.Enabled = bEnabled
        chkOriginalPositionColorGray.Enabled = bEnabled
        chkOriginalPositionOnlyTranslated.Enabled = bEnabled
        chkOriginalPositionOverDesign.Enabled = bEnabled
    End Sub

    Private Sub pGridRemoveFilter()
        For Each oRow As DataGridViewRow In grdTraslations.Rows
            oRow.Visible = True
        Next
    End Sub

    Private Sub pGridFilter(Filter As String)
        Dim sFilter As String = "*" & Filter.ToLower & "*"
        Dim bShow As Boolean
        For Each oRow As DataGridViewRow In grdTraslations.Rows
            bShow = False
            For Each oCell As DataGridViewCell In oRow.Cells
                If oCell.Value.ToString.ToLower Like sFilter Then
                    bShow = True
                    Exit For
                End If
            Next
            oRow.Visible = bShow
        Next
    End Sub

    Private Sub txtTraslationsGridFilterBy_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTraslationsGridFilterBy.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim sFilter As String = txtTraslationsGridFilterBy.Text.Trim
            If sFilter <> "" Then
                Call pGridFilter(sFilter)
            End If
        End If
    End Sub

    Private Sub mnuTraslationsGridRemoveFilter_Click(sender As Object, e As EventArgs) Handles mnuTraslationsGridRemoveFilter.Click
        Call pGridRemoveFilter()
    End Sub

    Private Sub chkShowLine_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowLine.CheckedChanged
        Dim bEnabled As Boolean = chkShowLine.Checked
        lblTranslationsThreshold.Enabled = benabled
        txtTranslationsThreshold.Enabled = benabled
    End Sub
End Class