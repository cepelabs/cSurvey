Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Friend Class frmParametersTranslations
    Private WithEvents oTransactionsBag As cTranslationsBag

    Private oOptions As Options.cTranslationsOptions
    Private iApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum

    Private bEventDisabled As Boolean

    Friend Class cTranslationsBagItem
        Inherits cSurvey.UIHelpers.cCaveBranchSelectorPlaceholder
        Implements cIUIBaseInteractions

        Private oTranslation As cTranslationBase

        Friend Sub New(CaveInfo As cICaveInfoBranches, Translation As cTranslationBase)
            MyBase.New(CaveInfo, modMain.GetLocalizedString("translations.originalposition"))
            oTranslation = Translation
        End Sub

        Public Property X As Single
            Get
                Return oTranslation.X
            End Get
            Set(ByVal value As Single)
                If oTranslation.X <> value Then
                    oTranslation.X = value
                    Call PropertyChanged("Y")
                End If
            End Set
        End Property

        Public Property Y As Single
            Get
                Return oTranslation.Y
            End Get
            Set(ByVal value As Single)
                If oTranslation.Y <> value Then
                    oTranslation.Y = value
                    Call PropertyChanged("Y")
                End If
            End Set
        End Property

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub
    End Class

    Friend Class cTranslationsBag
        Implements IEnumerable
        Implements cIUIBaseInteractions

        Private oOptions As Options.cTranslationsOptions
        Private oItems As List(Of cTranslationsBagItem)

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Friend Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, TranslationsOptions As Options.cTranslationsOptions, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)
            oItems = New List(Of cTranslationsBagItem)
            oOptions = TranslationsOptions

            Call Append(Nothing, TranslationsOptions.OriginalPositionTranslation)
            For Each oCaveInfo As cICaveInfoBranches In Survey.Properties.CaveInfos
                Dim oTranslation As cTranslation
                Select Case ApplyTo
                    Case cIDesign.cDesignTypeEnum.Profile
                        oTranslation = oCaveInfo.Translations.Profile
                    Case Else
                        oTranslation = oCaveInfo.Translations.Plan
                End Select
                Call Append(oCaveInfo, oTranslation)
                Call pAppendBranches(ApplyTo, oCaveInfo.Branches)
            Next
        End Sub

        Private Sub pAppendBranches(ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum, Branches As cCaveInfoBranches)
            Dim oTranslation As cTranslation
            For Each oCaveInfoBranch As cICaveInfoBranches In Branches
                Select Case ApplyTo
                    Case cIDesign.cDesignTypeEnum.Profile
                        oTranslation = oCaveInfoBranch.Translations.Profile
                    Case Else
                        oTranslation = oCaveInfoBranch.Translations.Plan
                End Select
                Call Append(oCaveInfoBranch, oTranslation)
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

        Private Sub oItem_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs)
            Call PropertyChanged("Item." & e.Name)
        End Sub

        Friend Function Append(CaveInfo As cICaveInfoBranches, Translation As cTranslationBase) ', Priority As cTranslation.cTranslationPriorityEnum, BreakPercentage As Single) As cTranslationsBagItem
            Dim oItem As cTranslationsBagItem = New cTranslationsBagItem(CaveInfo, Translation) ', Priority, BreakPercentage)
            AddHandler oItem.OnPropertyChanged, AddressOf oItem_OnPropertyChanged
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub
    End Class

    Public Sub New(ByVal Options As Options.cTranslationsOptions, ByVal ApplyTo As cSurvey.Design.cIDesign.cDesignTypeEnum)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        iApplyTo = ApplyTo

        bEventDisabled = True

        chkShowLine.Checked = oOptions.DrawTranslationsLine
        chkShowOriginalPosition.Checked = oOptions.DrawOriginalPosition
        chkShowOriginalPosition.Enabled = True
        txtTranslationsThreshold.Value = oOptions.TranslationsThreshold
        cboOriginalPositionColorMode.SelectedIndex = oOptions.OriginalPositionColorMode
        chkOriginalPositionColorGray.Checked = oOptions.OriginalPositionColorGray
        chkOriginalPositionOnlyTranslated.Checked = oOptions.OriginalPositionOnlyTranslated
        chkOriginalPositionOverDesign.Checked = oOptions.OriginalPositionOverDesign

        oTransactionsBag = New cTranslationsBag(oOptions.Survey, oOptions, ApplyTo)
        GridControl1.DataSource = oTransactionsBag
        'Call pTransactionsBagToGrid()

        bEventDisabled = False
    End Sub

    Private Sub chkShowOriginalPosition_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowOriginalPosition.CheckedChanged
        Dim bEnabled As Boolean = chkShowOriginalPosition.Checked
        lblOriginalPositionColorMode.Enabled = bEnabled
        cboOriginalPositionColorMode.Enabled = bEnabled
        chkOriginalPositionColorGray.Enabled = bEnabled
        chkOriginalPositionOnlyTranslated.Enabled = bEnabled
        chkOriginalPositionOverDesign.Enabled = bEnabled
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.DrawOriginalPosition = chkShowOriginalPosition.Checked
        End If
    End Sub

    Private Sub chkShowLine_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowLine.CheckedChanged
        Dim bEnabled As Boolean = chkShowLine.Checked
        lblTranslationsThreshold.Enabled = bEnabled
        txtTranslationsThreshold.Enabled = bEnabled
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.DrawTranslationsLine = chkShowLine.Checked
        End If
    End Sub

    Private Sub chkOriginalPositionColorGray_CheckedChanged(sender As Object, e As EventArgs) Handles chkOriginalPositionColorGray.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.OriginalPositionColorGray = chkOriginalPositionColorGray.Checked
        End If
    End Sub

    Private Sub oTransactionsBag_OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Handles oTransactionsBag.OnPropertyChanged
        Call oOptions.PropertyChanged(e.Name)
    End Sub

    Private Sub chkOriginalPositionOverDesign_CheckedChanged(sender As Object, e As EventArgs) Handles chkOriginalPositionOverDesign.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.OriginalPositionOverDesign = chkOriginalPositionOverDesign.Checked
        End If
    End Sub

    Private Sub chkOriginalPositionOnlyTranslated_CheckedChanged(sender As Object, e As EventArgs) Handles chkOriginalPositionOnlyTranslated.CheckedChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.OriginalPositionOnlyTranslated = chkOriginalPositionOnlyTranslated.Checked
        End If
    End Sub

    Private Sub txtTranslationsThreshold_EditValueChanged(sender As Object, e As EventArgs) Handles txtTranslationsThreshold.EditValueChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.TranslationsThreshold = txtTranslationsThreshold.Value
        End If
    End Sub

    Private Sub cboOriginalPositionColorMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOriginalPositionColorMode.SelectedIndexChanged
        If Not oOptions Is Nothing AndAlso Not bEventDisabled Then
            oOptions.OriginalPositionColorMode = cboOriginalPositionColorMode.SelectedIndex
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Dim oItem As cTranslationsBagItem = GridView1.GetRow(e.RowHandle)
        If Not oItem Is Nothing Then
            If e.Column Is colCaveBranchCaveColor Then
                If Not oItem.CaveInfo Is Nothing Then
                    e.Appearance.BackColor = oItem.CaveInfo.GetColor(Color.LightGray)
                End If
            ElseIf e.Column Is colCaveBranchBranchColor Then
                If oItem.CaveInfoBranch Is Nothing Then
                    If Not oItem.CaveInfo Is Nothing Then
                        e.Appearance.BackColor = oItem.CaveInfo.GetColor(Color.LightGray)
                    End If
                Else
                    e.Appearance.BackColor = oItem.CaveInfoBranch.GetColor(Color.LightGray)
                End If
            End If
        End If
    End Sub

    'Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GridView1.CustomUnboundColumnData
    '    If e.IsGetData Then
    '        If e.Column Is colCaveBranchCave Then
    '            If DirectCast(e.Row, cTranslationsBagItem).CaveInfo Is Nothing Then
    '                e.Value = "" 'modMain.GetLocalizedString("translations.originalposition")
    '            Else
    '                e.Value = DirectCast(e.Row, cTranslationsBagItem).Cave
    '            End If
    '        ElseIf e.Column Is colCaveBranchBranch Then
    '            If DirectCast(e.Row, cTranslationsBagItem).CaveInfoBranch Is Nothing Then
    '                e.Value = ""
    '            Else
    '                e.Value = DirectCast(e.Row, cTranslationsBagItem).Branch '.ToHTMLString
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub GridView1_CustomColumnDisplayText(sender As Object, e As CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
    '    If e.Column Is colCaveBranchCave Then
    '        If e.ListSourceRowIndex < 0 Then
    '            e.DisplayText = ""
    '        Else
    '            Dim oItem As cTranslationsBagItem = oTransactionsBag.Item(e.ListSourceRowIndex)
    '            If oItem.CaveInfo Is Nothing Then
    '                e.DisplayText = modMain.GetLocalizedString("translations.originalposition")
    '            Else
    '                e.DisplayText = oItem.CaveInfo.ToHTMLString
    '            End If
    '        End If
    '    ElseIf e.Column Is colCaveBranchBranch Then
    '        If e.ListSourceRowIndex < 0 Then
    '            e.DisplayText = ""
    '        Else
    '            Dim oItem As cTranslationsBagItem = oTransactionsBag.Item(e.ListSourceRowIndex)
    '            If oItem.CaveInfoBranch Is Nothing Then
    '                e.DisplayText = ""
    '            Else
    '                e.DisplayText = oItem.CaveInfoBranch.ToHTMLString
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
    '    Dim oTranslation As cTranslationsBagItem = GridView1.GetRow(e.RowHandle)
    '    If Not oTranslation Is Nothing Then
    '        If Not oTranslation.CaveInfo Is Nothing Then
    '            If e.Column Is colCaveBranchCave Then
    '                Dim oColor As Color = oTranslation.CaveInfo.GetColor(System.Drawing.Color.LightGray)
    '                If (oColor <> Color.Transparent) Then
    '                    e.Appearance.BackColor = modPaint.LightColor(oColor, 0.85)
    '                End If
    '            ElseIf e.Column Is colCaveBranchBranch Then
    '                Dim oColor As Color = oTranslation.CaveInfo.GetColor(System.Drawing.Color.LightGray)
    '                If (oColor <> Color.Transparent) Then
    '                    e.Appearance.BackColor = modPaint.LightColor(oColor, 0.85)
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub
End Class