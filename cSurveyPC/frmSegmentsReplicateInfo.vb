Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Scripting
Imports DevExpress.XtraRichEdit.Design.Internal

Friend Class frmSegmentsReplicateInfo
    Private oSurvey As cSurvey.cSurvey
    Private oSession As cSession
    Private oCave As cCaveInfo
    Private oCaveBranch As cCaveInfoBranch

    Private oScriptBag As cScriptBag

    Public ReadOnly Property ScriptBag As cScriptBag
        Get
            Return oScriptBag
        End Get
    End Property

    Public ReadOnly Property PropertiesBag As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)
        Get
            Return oPropertiesBag
        End Get
    End Property

    Private Sub chkSession_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSession.CheckedChanged
        Call pValidateOk()
    End Sub

    Private Sub pValidateOk()
        cmdOk.Enabled = chkSession.Checked OrElse chkCave.Checked OrElse chkFormula.Checked OrElse chkDirection.Checked OrElse chkOtherProperties.Checked
    End Sub

    Private Sub chkCave_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCave.CheckedChanged
        Call pValidateOk()
    End Sub

    'Private Sub cboCaveList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    chkCave.Checked = True
    '    Call pFillCaveBranchList(CType(cboCaveList.SelectedItem, cCaveInfo))
    'End Sub

    'Private Sub pFillCaveList()
    '    Dim oEmptyCaveInfo As cCaveInfo = oSurvey.Properties.CaveInfos.GetEmptyCaveInfo

    '    Dim oCaveList As cCaveInfo = cboCaveList.SelectedItem
    '    Call cboCaveList.Items.Clear()
    '    Call cboCaveList.Items.Add(oEmptyCaveInfo)

    '    For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos
    '        Call cboCaveList.Items.Add(oCaveInfo)
    '    Next

    '    Try
    '        If oCaveList Is Nothing Then
    '            cboCaveList.SelectedIndex = 0
    '        Else
    '            cboCaveList.SelectedItem = oCaveList
    '        End If
    '    Catch
    '        cboCaveList.SelectedIndex = 0
    '    End Try

    '    Call pFillCaveBranchList(CType(cboCaveList.SelectedItem, cCaveInfo))
    'End Sub

    'Private Sub pFillCaveBranchList(ByVal Cave As cCaveInfo)
    '    Dim sCave As String = ""
    '    If Not Cave Is Nothing Then
    '        sCave = "" & Cave.Name
    '    End If
    '    Call pFillCaveBranchList(sCave)
    'End Sub

    'Private Sub pFillCaveBranchList(ByVal Cave As String)
    '    Try
    '        Dim oEmptyCaveInfoBranch As cCaveInfoBranch = oSurvey.Properties.CaveInfos.GetEmptyCaveInfoBranch(Cave)
    '        If Cave = "" Then
    '            Call cboCaveBranchList.Items.Clear()
    '            Call cboCaveBranchList.Items.Add(oEmptyCaveInfoBranch)
    '            cboCaveBranchList.Enabled = False
    '        Else
    '            Dim oCurrentBranch As cCaveInfoBranch = cboCaveBranchList.SelectedItem
    '            Call cboCaveBranchList.Items.Clear()
    '            Call cboCaveBranchList.Items.Add(oEmptyCaveInfoBranch)
    '            For Each oBranch As cCaveInfoBranch In oSurvey.Properties.CaveInfos(Cave).Branches.GetAllBranches.Values
    '                Call cboCaveBranchList.Items.Add(oBranch)
    '            Next

    '            If cboCaveBranchList.Items.Count > 0 Then
    '                Try
    '                    If oCurrentBranch Is Nothing Then
    '                        cboCaveBranchList.SelectedIndex = 0
    '                    Else
    '                        cboCaveBranchList.SelectedItem = oCurrentBranch
    '                    End If
    '                Catch
    '                    cboCaveBranchList.SelectedIndex = 0
    '                End Try
    '                cboCaveBranchList.Enabled = True
    '            Else
    '                cboCaveBranchList.Enabled = False
    '            End If
    '        End If
    '    Catch
    '    End Try
    'End Sub

    Public Sub New(Survey As cSurveyPC.cSurvey.cSurvey, Optional Session As cSession = Nothing, Optional Cave As cCaveInfo = Nothing, Optional CaveBranch As cCaveInfoBranch = Nothing, Optional Direction As cSurvey.cSurvey.DirectionEnum = cSurvey.cSurvey.DirectionEnum.Right, Optional Rows As Integer = 1, Optional FunctionLanguage As LanguageEnum = LanguageEnum.VisualBasic)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oSession = Session
        oCave = Cave
        oCaveBranch = CaveBranch

        cboDirection.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(modMain.GetLocalizedString("csurvey.directionenum." & cSurvey.cSurvey.DirectionEnum.Right.ToString("D")), cSurvey.cSurvey.DirectionEnum.Right, 11))
        cboDirection.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(modMain.GetLocalizedString("csurvey.directionenum." & cSurvey.cSurvey.DirectionEnum.Left.ToString("D")), cSurvey.cSurvey.DirectionEnum.Left, 10))
        cboDirection.Properties.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(modMain.GetLocalizedString("csurvey.directionenum." & cSurvey.cSurvey.DirectionEnum.Vertical.ToString("D")), cSurvey.cSurvey.DirectionEnum.Vertical, 12))

        cboCaveList.Rebind(oSurvey, False)
        cboCaveList.EditValue = oCave
        cboCaveBranchList.EditValue = oCaveBranch

        cboSessionList.Rebind(oSurvey, False)
        cboSessionList.EditValue = oSession

        cboDirection.SelectedIndex = Direction

        If Rows > 0 Then
            cboReplicateTo.SelectedIndex = 3
        End If

        chkSession.Checked = cboSessionList.Text <> ""
        chkCave.Checked = cboCaveList.Text <> ""

        oScriptBag = New cScriptBag("", FunctionLanguage, False)
    End Sub

    'Private Sub pFillSessionList()
    '    Dim oEmptySession As cSession = oSurvey.Properties.Sessions.GetEmptySession
    '    Dim oPropSession As cSession = cboSessionList.SelectedItem
    '    Call cboSessionList.Items.Clear()
    '    Call cboSessionList.Items.Add(oEmptySession)

    '    For Each oSession As cSession In oSurvey.Properties.Sessions
    '        Call cboSessionList.Items.Add(oSession)
    '    Next
    '    Try
    '        If oPropSession Is Nothing Then
    '            cboSessionList.SelectedIndex = 0
    '        Else
    '            cboSessionList.SelectedItem = oPropSession
    '        End If
    '    Catch
    '        cboSessionList.SelectedIndex = 0
    '    End Try
    'End Sub

    'Private Sub cboSessionList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '    chkSession.Checked = True
    'End Sub

    'Private Sub cboCaveBranchList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
    '    chkCave.Checked = True
    'End Sub

    Private Sub chkFormula_CheckedChanged(sender As Object, e As EventArgs) Handles chkFormula.CheckedChanged
        'cmdEditFormula.Enabled = chkFormula.Checked
        Call pValidateOk()
    End Sub

    Private Sub cmdEditFormula_Click(sender As Object, e As EventArgs) Handles cmdEditFormula.Click
        Using frmSRF As frmScriptFormulaEditor = New frmScriptFormulaEditor(oSurvey, oScriptBag)
            AddHandler frmSRF.OnFormulaCodeRequest, AddressOf frmSRF_OnFormulaCodeRequest
            If frmSRF.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                oScriptBag = frmSRF.GetScriptBag()
                chkFormula.Checked = True
            End If
            RemoveHandler frmSRF.OnFormulaCodeRequest, AddressOf frmSRF_OnFormulaCodeRequest
        End Using
    End Sub

    Public Function GetScript() As cScript
        If Not oScriptBag.Unboxed Then
            oScriptBag.Code = GetFormulaCode(oScriptBag)
            oScriptBag.Unboxed = False
        End If
        Return New Scripting.cScript(oSurvey, oScriptBag.Code, oScriptBag.Language)
    End Function

    Private Sub frmSRF_OnFormulaCodeRequest(Sender As Object, ByRef Args As frmScriptFormulaEditor.cFormulaCodeRequestEvent)
        Args.FullCode = GetFormulaCode(Args.ScriptBag)
    End Sub

    Friend Function GetFormulaCode(ScriptBag As cScriptBag) As String
        'Dim sFormulaCode As String = ""
        'Dim sLocalFormula As String = ""
        'If Formula Is Nothing Then
        '    sLocalFormula = sFormula
        'Else
        '    sLocalFormula = Formula
        'End If
        If ScriptBag.Unboxed Then
            Return ScriptBag.Code
        Else
            Dim sFullCode As String = ""
            Select Case ScriptBag.Language
                Case LanguageEnum.VisualBasic
                    sFullCode = "public sub ReplicateFormula(CurrentSegment as object)" & vbCrLf & vbTab & ScriptBag.Code & vbCrLf & "CurrentSegment.Save" & vbCrLf & "end sub"
                Case LanguageEnum.CSharp
                    sFullCode = "public void ReplicateFormula(cSegment CurrentSegment) {" & vbCrLf & vbTab & ScriptBag.Code & vbCrLf & "CurrentSegment.Save();" & vbCrLf & "}"
            End Select
            Return sFullCode
        End If
    End Function

    Private Sub chkDirection_CheckedChanged(sender As Object, e As EventArgs) Handles chkDirection.CheckedChanged
        Call pValidateOk()
    End Sub

    Private Sub cboCaveList_EditValueChanged(sender As Object, e As EventArgs) Handles cboCaveList.EditValueChanged
        chkCave.Checked = True
        cboCaveBranchList.Rebind(oSurvey, cboCaveList)
    End Sub

    Private Sub cboSessionList_EditValueChanged(sender As Object, e As EventArgs) Handles cboSessionList.EditValueChanged
        chkSession.Checked = True
    End Sub

    Private Sub cboCaveBranchList_EditValueChanged(sender As Object, e As EventArgs) Handles cboCaveBranchList.EditValueChanged
        chkCave.Checked = True
    End Sub

    Private oPropertiesBag As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)

    Private Sub cmdEditOtherProperties_Click(sender As Object, e As EventArgs) Handles cmdEditOtherProperties.Click
        Using frmR As frmSegmentsReplicateDataFieldEditor = New frmSegmentsReplicateDataFieldEditor(oPropertiesBag)
            If frmR.ShowDialog(Me) = DialogResult.OK Then
                oPropertiesBag = frmR.Items
                chkOtherProperties.Checked = True
            End If
        End Using
    End Sub

    Private Sub chkOtherProperties_CheckedChanged(sender As Object, e As EventArgs) Handles chkOtherProperties.CheckedChanged
        Call pValidateOk()
    End Sub
End Class