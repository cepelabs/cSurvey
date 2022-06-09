Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Scripting

friend Class frmScriptFormulaEditor
    Private oSurvey As cSurvey.cSurvey
    Private iFunctionLanguage As LanguageEnum

    Public Class cFormulaCodeRequestEvent
        Inherits EventArgs

        Private oScriptBag As cScriptBag
        Private sFullCode As String

        Public Property FullCode As String
            Get
                Return sFullCode
            End Get
            Set(value As String)
                sFullCode = value
            End Set
        End Property

        Public Sub New(ScriptBag As cScriptBag)
            oScriptBag = ScriptBag
            sFullCode = ""
        End Sub

        Public Sub New(ByRef Code As String, Language As LanguageEnum, Unboxed As Boolean)
            oScriptBag = New cScriptBag(Code, Language, Unboxed)
            sFullCode = ""
        End Sub

        Public ReadOnly Property ScriptBag() As cScriptBag
            Get
                Return oScriptBag
            End Get
        End Property
    End Class

    Friend Event OnFormulaCodeRequest(Sender As Object, ByRef Args As cFormulaCodeRequestEvent)

    Friend Enum QuietEnum
        Quiet = 0
        OnlyErrors = 1
        All = 2
    End Enum

    Private Function pCheckSintax(Optional Quiet As QuietEnum = QuietEnum.OnlyErrors) As Boolean
        Dim sFormula As String = txtFormula.Text
        Dim bUnboxed As Boolean = btnUnboxed.Checked
        Dim oArgs As cFormulaCodeRequestEvent = New cFormulaCodeRequestEvent(sFormula, iFunctionLanguage, bUnboxed)
        RaiseEvent OnFormulaCodeRequest(Me, oArgs)
        Dim oScript As cScript = New cScript(oSurvey, oArgs.FullCode, iFunctionLanguage)
        If oScript.CompilerErrors.Count = 0 Then
            If Quiet = QuietEnum.All Then
                Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("formulaeditor.warning1"), vbOKOnly Or MsgBoxStyle.Information, GetLocalizedString("formulaeditor.warningtitle"))
            End If
            Return True
        Else
            If Quiet = QuietEnum.OnlyErrors Or Quiet = QuietEnum.All Then
                Dim sMessage As String = GetLocalizedString("formulaeditor.warning2") & vbCrLf
                For Each oError As System.CodeDom.Compiler.CompilerError In oScript.CompilerErrors
                    sMessage = sMessage & " - " & oError.ErrorText & vbCrLf
                Next
                sMessage = sMessage & GetLocalizedString("formulaeditor.warning3")
                Call cSurvey.UIHelpers.Dialogs.Msgbox(sMessage, vbOKOnly Or MsgBoxStyle.Critical, GetLocalizedString("formulaeditor.warningtitle"))
            End If
            Return False
        End If
    End Function

    Private Sub btnCleanQuerySintax_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function GetScriptBag() As cScriptBag
        Dim sText As String
        If sCacheText Is Nothing Then
            sText = txtFormula.Text
        Else
            sText = sCacheText
        End If
        Return New cScriptBag(sText, btnFunctionLanguage.EditValue, btnUnboxed.Checked)
    End Function

    Public Sub New(Survey As cSurvey.cSurvey, Script As cScriptBag)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        cboFunctionLanguage.Items(0).Value = LanguageEnum.VisualBasic
        cboFunctionLanguage.Items(1).Value = LanguageEnum.CSharp

        oSurvey = Survey

        bDisableChangeEvent = True
        iFunctionLanguage = Script.Language
        btnFunctionLanguage.EditValue = iFunctionLanguage
        txtFormula.Text = Script.Code
        btnUnboxed.Checked = Script.Unboxed
        btnUnboxed.Enabled = Not btnUnboxed.Checked
        bDisableChangeEvent = False
    End Sub

    Private bDisableChangeEvent As Boolean

    Public Sub New(Survey As cSurvey.cSurvey, FormulaText As String, FunctionLanguage As LanguageEnum, Unboxed As Boolean)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        bDisableChangeEvent = True
        iFunctionLanguage = FunctionLanguage
        btnFunctionLanguage.EditValue = FunctionLanguage
        txtFormula.Text = FormulaText
        btnUnboxed.Checked = Unboxed
        btnUnboxed.Enabled = Not btnUnboxed.Checked
        bDisableChangeEvent = False
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If pCheckSintax(QuietEnum.OnlyErrors) Then
            DialogResult = vbOK
            Call Close()
        End If
    End Sub

    Private sCacheText As String = Nothing

    Private Sub frmFormulaEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sCacheText = txtFormula.Text
    End Sub

    Private Sub btnUnboxed_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUnboxed.CheckedChanged
        If Not bDisableChangeEvent Then
            If btnUnboxed.Checked Then
                Dim sFormula As String = txtFormula.Text
                Dim oArgs As cFormulaCodeRequestEvent = New cFormulaCodeRequestEvent(sFormula, iFunctionLanguage, False)
                RaiseEvent OnFormulaCodeRequest(Me, oArgs)
                txtFormula.Text = oArgs.FullCode
                btnUnboxed.Enabled = False
            Else
                btnUnboxed.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnCheckQuerySintax_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCheckQuerySintax.ItemClick
        Call pCheckSintax(QuietEnum.All)
    End Sub

    Private Sub btnCleanQuerySintax_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCleanQuerySintax.ItemClick
        txtFormula.Text = ""
        btnUnboxed.Checked = False
    End Sub

    Private Sub btnFunctionLanguage_EditValueChanged(sender As Object, e As EventArgs) Handles btnFunctionLanguage.EditValueChanged
        iFunctionLanguage = btnFunctionLanguage.EditValue
        Call modScript.ApplyFormat(txtFormula, iFunctionLanguage)
    End Sub
End Class