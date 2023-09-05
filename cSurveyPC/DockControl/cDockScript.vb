Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Scripting

Friend Class cDockScript
    Private sFilename As String
    Private iFunctionLanguage As LanguageEnum

    Private oSurvey As cSurvey.cSurvey
    Private WithEvents oDebug As cScriptDebug

    'Friend Class cFormulaCodeRequestEventArgs
    '    Inherits EventArgs

    '    Public Sub New(Formula As String)
    '        Me.Formula = Formula
    '    End Sub

    '    Public Property Formula As String
    'End Class

    'Friend Event OnFormulaCodeRequest(Sender As Object, Formula As cFormulaCodeRequestEventArgs)

    Private Const iExtraLines As Integer = 7

    Public Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey, FunctionLanguage As LanguageEnum)
        oSurvey = Survey
        btnFunctionLanguage.EditValue = FunctionLanguage
        Enabled = True
    End Sub

    Friend ReadOnly Property Formula As String
        Get
            Return txtScript.Text
        End Get
    End Property

    Private Sub btnCheckQuerySintax_Click(sender As Object, e As EventArgs) Handles btnCheckQuerySintax.ItemClick
        Call pCheckSintax(QuietEnum.All)
    End Sub

    Private Function pGetScriptCode(Script As String) As String
        Dim sScript As String = ""
        Select Case iFunctionLanguage
            Case LanguageEnum.VisualBasic
                sScript = "public sub CustomCode(Survey as object, Debug as object)" & vbCrLf & Script & vbCrLf & "end sub"
            Case LanguageEnum.CSharp
                sScript = "public void CustomCode(object Survey, object Debug) {" & vbCrLf & Script & vbCrLf & "}"
        End Select
        Return sScript
    End Function

    Friend Enum QuietEnum
        Quiet = 0
        OnlyErrors = 1
        All = 2
    End Enum

    Private Function pCheckSintax(Optional Quiet As QuietEnum = QuietEnum.OnlyErrors) As Boolean
        Dim sScript As String = pGetScriptCode(txtScript.Text)
        Dim oScript As cScript = New cScript(oSurvey, sScript, iFunctionLanguage)
        If oScript.CompilerErrors.Count = 0 Then
            If Quiet = QuietEnum.All Then
                Call UIHelpers.Dialogs.Msgbox(GetLocalizedString("formulaeditor.warning1"), vbOKOnly Or MsgBoxStyle.Information, GetLocalizedString("formulaeditor.warningtitle"))
            End If
            Return True
        Else
            If Quiet = QuietEnum.OnlyErrors Or Quiet = QuietEnum.All Then
                Dim sMessage As String = GetLocalizedString("formulaeditor.warning2") & vbCrLf
                For Each oError As System.CodeDom.Compiler.CompilerError In oScript.CompilerErrors
                    sMessage = sMessage & " - " & oError.ErrorText & vbCrLf
                    Call oDebug.Print("> " & oError.Line - iExtraLines & "-" & oError.Column & ":" & oError.ErrorText)
                Next
                sMessage &= GetLocalizedString("formulaeditor.warning3")
                Call UIHelpers.Dialogs.Msgbox(sMessage, vbOKOnly Or MsgBoxStyle.Critical, GetLocalizedString("formulaeditor.warningtitle"))
            End If
            Return False
        End If
    End Function

    Private Sub btnCleanQuerySintax_Click(sender As Object, e As EventArgs) Handles btnCleanQuerySintax.ItemClick
        Call txtScript.Clear()
    End Sub

    Public Sub New() '(Survey As cSurvey.cSurvey, Formula As String, FunctionLanguage As LanguageEnum)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        cboFunctionLanguage.Items(0).Value = LanguageEnum.VisualBasic
        cboFunctionLanguage.Items(1).Value = LanguageEnum.CSharp

        txtDebug.Document.DefaultCharacterProperties.FontName = "Lucida Console"
        txtDebug.Document.DefaultCharacterProperties.FontSize = 8

        Enabled = False

        oDebug = New cScriptDebug()
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.ItemClick
        If pCheckSintax(QuietEnum.OnlyErrors) Then
            Call pControlsEnabled(False)
            Call bwScript.RunWorkerAsync(txtScript.Text)
        End If
    End Sub

    Private Sub pControlsEnabled(Enabled As Boolean)
        btnRun.Enabled = Enabled
        btnCheckQuerySintax.Enabled = Enabled
        btnCleanQuerySintax.Enabled = Enabled
    End Sub

    Private Sub bwScript_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwScript.DoWork
        Dim oScript As cScript = New cScript(oSurvey, pGetScriptCode(e.Argument), iFunctionLanguage)
        Call oScript.Eval("CustomCode", {oSurvey, oDebug})
        'For Each oError As System.CodeDom.Compiler.CompilerError In oScript.CompilerErrors
        '    'sMessage = sMessage & "Linea: " & oError.Line & " Colonna: " & oError.Column & " - " & oError.ErrorText & vbCrLf
        '    'sMessage = sMessage & " - " & oError.ErrorText & vbCrLf
        '    Call oDebug.Print("> " & oError.Line & "-" & oError.Column & ":" & oError.ErrorText)
        'Next
    End Sub

    Private Sub bwScript_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwScript.RunWorkerCompleted
        Call pControlsEnabled(True)
        Call oDebug.Print("> " & modMain.GetLocalizedString("script.executioncompleted"))
    End Sub

    Private Delegate Sub pPrintDelegate(Text As String)

    Private Sub pPrint(Text As String)
        Call txtDebug.Document.AppendText(Text)
        If Not Text.EndsWith(vbCrLf) Then Call txtDebug.Document.AppendText(vbCrLf)
        txtDebug.ScrollToCaret()
        'Call txtDebug.AppendText(Text & vbCrLf)
        'txtDebug.SelectionStart = txtDebug.TextLength
    End Sub

    Private Sub oDebug_OnPrint(Sender As Object, PrintEventArgs As cScriptDebug.cPrintEventArgs) Handles oDebug.OnPrint
        If InvokeRequired Then
            Call Invoke(New pPrintDelegate(AddressOf pPrint), {PrintEventArgs.Text})
        Else
            Call pPrint(PrintEventArgs.Text)
        End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.ItemClick
        Call pLoad("")
    End Sub

    Private Sub pLoad(Filename As String)
        If Filename = "" Then
            Using oOFD As OpenFileDialog = New OpenFileDialog
                With oOFD
                    .Filter = GetLocalizedString("script.filetypeCScriptX") & " (*.CScriptX)|*.CScriptX"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If

        If Filename <> "" Then
            Cursor = Cursors.WaitCursor

            sFilename = Filename

            Text = "Script - " & sFilename & ":"

            Dim oXML As XmlDocument = New XmlDocument
            Call oXML.Load(sFilename)
            Dim oXMLRoot As XmlElement = oXML.Item("cscript")
            iFunctionLanguage = oXMLRoot.GetAttribute("language")
            btnFunctionLanguage.EditValue = iFunctionLanguage
            txtScript.Text = oXMLRoot.InnerText
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub pSave(Filename As String)
        If Filename = "" Then
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .OverwritePrompt = True
                    .Filter = GetLocalizedString("script.filetypeCScriptX") & " (*.CScriptX)|*.CScriptX"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Filename = .FileName
                    End If
                End With
            End Using
        End If

        If Filename <> "" Then
            Cursor = Cursors.WaitCursor

            sFilename = Filename

            Text = "Script - " & sFilename & ":"

            Dim oXML As XmlDocument = New XmlDocument
            Dim oXMLRoot As XmlElement = oXML.CreateElement("cscript")
            Call oXMLRoot.SetAttribute("language", iFunctionLanguage.ToString("D"))
            oXMLRoot.InnerText = txtScript.Text
            Call oXML.AppendChild(oXMLRoot)
            Call oXML.Save(sFilename)

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub pNew()
        Call txtScript.Clear()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.ItemClick
        Call pNew()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.ItemClick
        Call pSave(sFilename)
    End Sub

    Private Sub btnSaveAs_Click(sender As Object, e As EventArgs) Handles btnSaveAs.ItemClick
        Call pSave("")
    End Sub

    Private Sub btnFunctionLanguage_EditValueChanged(sender As Object, e As EventArgs) Handles btnFunctionLanguage.EditValueChanged
        iFunctionLanguage = btnFunctionLanguage.EditValue
        Call modScript.ApplyFormat(txtScript, iFunctionLanguage)
    End Sub

    Private Sub txtDebug_DocumentLoaded(sender As Object, e As EventArgs) Handles txtDebug.DocumentLoaded
        txtDebug.Document.DefaultCharacterProperties.FontName = "Lucida Console"
        txtDebug.Document.DefaultCharacterProperties.FontSize = 8
    End Sub
End Class