Imports Microsoft.VisualBasic
Imports Microsoft.CSharp
Imports System
Imports System.Text
Imports System.CodeDom.Compiler
Imports System.Reflection
Imports System.IO
Imports System.Diagnostics

Namespace cSurvey.Scripting
    Public Enum LanguageEnum
        VisualBasic = 0
        CSharp = 1
    End Enum

    Public Class cClass
        Private oSurvey As cSurvey

        Private oCompilerErrors As CompilerErrorCollection
        Private oRuntimeError As Exception
        Private oAssembly As System.Reflection.Assembly
        Private oInstance As Object
        Private oType As Type

        Private sName As String
        Private sCode As String
        Private sFullCode As String

        Public ReadOnly Property RuntimeError() As Exception
            Get
                Return oRuntimeError
            End Get
        End Property

        Public ReadOnly Property Code() As String
            Get
                Return sCode
            End Get
        End Property

        Public ReadOnly Property FullCode() As String
            Get
                Return sFullCode
            End Get
        End Property

        Public ReadOnly Property CompilerErrors() As CompilerErrorCollection
            Get
                Return oCompilerErrors
            End Get
        End Property

        Friend Sub New(Survey As cSurvey, Name As String, ClassCode As String, Optional Language As LanguageEnum = LanguageEnum.VisualBasic)
            oSurvey = Survey

            oCompilerErrors = New CompilerErrorCollection
            sName = Name
            sCode = ClassCode

            Dim oCodeProvider As System.CodeDom.Compiler.CodeDomProvider
            Dim oCodeParameters As CompilerParameters = New CompilerParameters
            Dim oCodeResults As CompilerResults
            oCodeParameters.ReferencedAssemblies.Add("system.dll")
            oCodeParameters.ReferencedAssemblies.Add("system.xml.dll")
            oCodeParameters.ReferencedAssemblies.Add("system.data.dll")
            oCodeParameters.ReferencedAssemblies.Add("system.drawing.dll")
            Dim oCurrentAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Call oCodeParameters.ReferencedAssemblies.Add(oCurrentAssembly.Location)

            oCodeParameters.CompilerOptions = "/t:library"
            oCodeParameters.TreatWarningsAsErrors = False
            oCodeParameters.GenerateInMemory = True
            oCodeParameters.WarningLevel = 1

            Dim oSB As StringBuilder = New StringBuilder("")
            Select Case Language
                Case LanguageEnum.VisualBasic
                    oCodeProvider = New VBCodeProvider
                    Call oSB.Append("Imports System" & vbCrLf)
                    Call oSB.Append("Imports System.ComponentModel" & vbCrLf)
                    Call oSB.Append("Imports System.Xml" & vbCrLf)
                    Call oSB.Append("Imports System.Data" & vbCrLf)
                    Call oSB.Append("Imports System.Drawing" & vbCrLf)
                    Call oSB.Append("Imports cSurveyPC.cSurvey" & vbCrLf)
                    Call oSB.Append("Imports cSurveyPC.cSurvey.Scripting" & vbCrLf)
                    Call oSB.Append("Namespace cSurvey" & vbCrLf)
                    Call oSB.Append("Class " & sName & " " & vbCrLf)
                    Call oSB.Append("Dim Survey as cSurveyPC.cSurvey.cSurvey " & vbCrLf)
                    Call oSB.Append("Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)" & vbCrLf)
                    Call oSB.Append("   Me.Survey = Survey" & vbCrLf)
                    Call oSB.Append("End Sub" & vbCrLf)
                    Call oSB.Append(Code & vbCrLf)
                    Call oSB.Append("End Class " & vbCrLf)
                    Call oSB.Append("End Namespace" & vbCrLf)
                Case LanguageEnum.CSharp
                    oCodeProvider = New CSharpCodeProvider
                    Call oSB.Append("using System;" & vbCrLf)
                    Call oSB.Append("using System.ComponentModel;" & vbCrLf)
                    Call oSB.Append("using System.Xml;" & vbCrLf)
                    Call oSB.Append("using System.Data;" & vbCrLf)
                    Call oSB.Append("using System.Drawing;" & vbCrLf)
                    Call oSB.Append("using cSurveyPC.cSurvey;" & vbCrLf)
                    Call oSB.Append("using cSurveyPC.cSurvey.Scripting;" & vbCrLf)
                    Call oSB.Append("namespace cSurvey {" & vbCrLf)
                    Call oSB.Append("public class " & sName & " {" & vbCrLf)
                    Call oSB.Append("cSurveyPC.cSurvey.cSurvey Survey;" & vbCrLf)
                    Call oSB.Append("Public void SetSurvey(cSurveyPC.cSurvey.cSurvey Survey)" & vbCrLf)
                    Call oSB.Append("{" & vbCrLf)
                    Call oSB.Append("   base.Survey = Survey;" & vbCrLf)
                    Call oSB.Append("}" & vbCrLf)
                    Call oSB.Append(Code & vbCrLf)
                    Call oSB.Append("}" & vbCrLf)
                    Call oSB.Append("} " & vbCrLf)
            End Select
            Try
                sFullCode = oSB.ToString
                oCodeResults = oCodeProvider.CompileAssemblyFromSource(oCodeParameters, sFullCode)
                If oCodeResults.Errors.Count <> 0 Then
                    oCompilerErrors = oCodeResults.Errors
                Else
                    oAssembly = oCodeResults.CompiledAssembly
                    oInstance = oAssembly.CreateInstance("cSurvey." & sName)
                    oType = oInstance.GetType
                    Call oInstance.SetSurvey(oSurvey)
                End If
            Catch ex As Exception
                Call oCompilerErrors.Add(New CodeDom.Compiler.CompilerError("", 0, 0, "", ex.Message))
            End Try
        End Sub

        Public ReadOnly Property DefaultInstance As Object
            Get
                Return oInstance
            End Get
        End Property

        Public Function GetNewInstance() As Object
            Return oAssembly.CreateInstance("cSurvey." & sName)
        End Function
    End Class

    Public Class cScriptBag
        Private sCode As String
        Private iLanguage As LanguageEnum

        Private _unboxedprefix As String = ">"
        Private _cprefix As String = "c#>"
        Private _vbprefix As String = "vb#>"

        Private bUnboxed As Boolean

        Public Sub New(Code As String, Language As LanguageEnum, Optional Unboxed As Boolean = False)
            sCode = Code
            iLanguage = Language
            bUnboxed = Unboxed
        End Sub

        Public Sub New(Script As String, Optional DefaultLanguage As LanguageEnum = LanguageEnum.VisualBasic)
            If Script = "" Then
                sCode = ""
                iLanguage = DefaultLanguage
            Else
                If Script.StartsWith(_cprefix) Then
                    iLanguage = LanguageEnum.CSharp
                    sCode = Script.Substring(_cprefix.Length)
                    sCode = pUnboxCode(sCode)
                ElseIf Script.StartsWith(_vbprefix) Then
                    iLanguage = LanguageEnum.VisualBasic
                    sCode = Script.Substring(_vbprefix.Length)
                    sCode = pUnboxCode(sCode)
                End If
            End If
        End Sub

        Private Function pUnboxCode(Code As String) As String
            If Code.StartsWith(_unboxedprefix) Then
                bUnboxed = True
                Return Code.Substring(_unboxedprefix.Length)
            Else
                Return Code
            End If
        End Function

        Public Overrides Function ToString() As String
            If iLanguage = LanguageEnum.CSharp Then
                Return _cprefix & IIf(bUnboxed, _unboxedprefix, "") & sCode
            ElseIf iLanguage = LanguageEnum.VisualBasic Then
                Return _vbprefix & IIf(bUnboxed, _unboxedprefix, "") & sCode
            End If
        End Function

        Public Property Unboxed As Boolean
            Get
                Return bUnboxed
            End Get
            Set(value As Boolean)
                bUnboxed = value
            End Set
        End Property

        Public Property Code() As String
            Get
                Return sCode
            End Get
            Set(value As String)
                sCode = value
            End Set
        End Property

        Public Property Language As LanguageEnum
            Get
                Return iLanguage
            End Get
            Set(value As LanguageEnum)
                iLanguage = value
            End Set
        End Property
    End Class

    Public Class cScript
        Private oSurvey As cSurvey

        Private oCompilerErrors As CompilerErrorCollection
        Private oRuntimeError As Exception
        Private oAssembly As System.Reflection.Assembly
        Private oInstance As Object
        Private oType As Type

        Private sCode As String
        Private iLanguage As LanguageEnum

        Private sFullCode As String

        Public ReadOnly Property RuntimeError() As Exception
            Get
                Return oRuntimeError
            End Get
        End Property

        Public ReadOnly Property Code() As String
            Get
                Return sCode
            End Get
        End Property

        Public ReadOnly Property FullCode() As String
            Get
                Return sFullCode
            End Get
        End Property

        Public ReadOnly Property CompilerErrors() As CompilerErrorCollection
            Get
                Return oCompilerErrors
            End Get
        End Property

        Public Sub New(Survey As cSurvey, Code As String, Language As LanguageEnum)
            oSurvey = Survey
            Call pCodeInitialize(Code, Language)
        End Sub

        Public Sub New(Survey As cSurvey, Script As String)
            oSurvey = Survey
            Dim oScriptBag As cScriptBag = New cScriptBag(Script)
            Call pCodeInitialize(oScriptBag.Code, oScriptBag.Language)
        End Sub

        Private Sub pCodeInitialize(Code As String, Language As LanguageEnum)
            oCompilerErrors = New CompilerErrorCollection
            sCode = Code
            iLanguage = Language

            Dim oCodeProvider As System.CodeDom.Compiler.CodeDomProvider
            Dim oCodeParameters As CompilerParameters = New CompilerParameters
            Dim oCodeResults As CompilerResults
            Call oCodeParameters.ReferencedAssemblies.Add("system.dll")
            Call oCodeParameters.ReferencedAssemblies.Add("system.xml.dll")
            Call oCodeParameters.ReferencedAssemblies.Add("system.data.dll")
            Call oCodeParameters.ReferencedAssemblies.Add("system.drawing.dll")
            Dim oCurrentAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Call oCodeParameters.ReferencedAssemblies.Add(oCurrentAssembly.Location)

            oCodeParameters.CompilerOptions = "/t:library"
            oCodeParameters.TreatWarningsAsErrors = False
            oCodeParameters.IncludeDebugInformation = True
            oCodeParameters.GenerateInMemory = True
            oCodeParameters.WarningLevel = 1

            Dim oSB As StringBuilder = New StringBuilder("")
            Select Case iLanguage
                Case LanguageEnum.VisualBasic
                    oCodeProvider = New VBCodeProvider
                    Call oSB.Append("Imports System" & vbCrLf)
                    Call oSB.Append("Imports System.Xml" & vbCrLf)
                    Call oSB.Append("Imports System.Data" & vbCrLf)
                    Call oSB.Append("Imports System.Drawing" & vbCrLf)
                    Call oSB.Append("Imports cSurveyPC.cSurvey" & vbCrLf)
                    Call oSB.Append("Imports cSurveyPC.cSurvey.Properties" & vbCrLf)
                    Call oSB.Append("Namespace cSurvey" & vbCrLf)
                    Call oSB.Append("Class cScriptEvaluator " & vbCrLf)
                    Call oSB.Append("Dim Survey as cSurveyPC.cSurvey.cSurvey " & vbCrLf)
                    Call oSB.Append("Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)" & vbCrLf)
                    Call oSB.Append("   Me.Survey = Survey" & vbCrLf)
                    Call oSB.Append("End Sub" & vbCrLf)
                    Call oSB.Append(Code & vbCrLf)
                    Call oSB.Append("End Class " & vbCrLf)
                    Call oSB.Append("End Namespace" & vbCrLf)
                Case LanguageEnum.CSharp
                    oCodeProvider = New CSharpCodeProvider
                    Call oSB.Append("using System;" & vbCrLf)
                    Call oSB.Append("using System.Xml;" & vbCrLf)
                    Call oSB.Append("using System.Data;" & vbCrLf)
                    Call oSB.Append("using System.Drawing;" & vbCrLf)
                    Call oSB.Append("using cSurveyPC.cSurvey;" & vbCrLf)
                    Call oSB.Append("using cSurveyPC.cSurvey.Properties;" & vbCrLf)
                    Call oSB.Append("namespace cSurvey {" & vbCrLf)
                    Call oSB.Append("public class cScriptEvaluator {" & vbCrLf)
                    Call oSB.Append("cSurveyPC.cSurvey.cSurvey Survey;" & vbCrLf)
                    Call oSB.Append("public void SetSurvey(cSurveyPC.cSurvey.cSurvey Survey) {" & vbCrLf)
                    Call oSB.Append("   this.Survey = Survey;" & vbCrLf)
                    Call oSB.Append("}" & vbCrLf)
                    Call oSB.Append(Code & vbCrLf)
                    Call oSB.Append("}" & vbCrLf)
                    Call oSB.Append("} " & vbCrLf)
            End Select
            Try
                sFullCode = oSB.ToString
                oCodeResults = oCodeProvider.CompileAssemblyFromSource(oCodeParameters, sFullCode)
                If oCodeResults.Errors.Count <> 0 Then
                    oCompilerErrors = oCodeResults.Errors
                Else
                    oAssembly = oCodeResults.CompiledAssembly
                    oInstance = oAssembly.CreateInstance("cSurvey.cScriptEvaluator")
                    oType = oInstance.GetType
                    Call Eval("SetSurvey", {oSurvey})
                End If
            Catch ex As Exception
                Call oCompilerErrors.Add(New CodeDom.Compiler.CompilerError("", 0, 0, "", ex.Message))
            End Try
        End Sub

        Public Function Eval(FunctionName As String, FunctionParameters() As Object) As Object
            If oCompilerErrors.Count = 0 Then
                Try
                    Dim oMethodInfo As MethodInfo = oType.GetMethod(FunctionName)
                    Return oMethodInfo.Invoke(oInstance, FunctionParameters)
                Catch ex As Exception
                    oRuntimeError = ex
                    Return Nothing
                End Try
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace