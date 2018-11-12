Imports ScintillaNET

Module modScript
    Public Sub ApplyFormat(Editor As Scintilla, Language As cSurvey.Scripting.LanguageEnum)
        If Language = 0 Then
            Editor.StyleResetDefault()
            Editor.Styles(Style.Default).Font = "Lucida Console"
            Editor.Styles(Style.Default).Size = 10
            Editor.StyleClearAll()

            Editor.Styles(Style.Cpp.Default).ForeColor = Color.Silver
            Editor.Styles(Style.Cpp.Comment).ForeColor = Color.FromArgb(0, 128, 0)
            Editor.Styles(Style.Cpp.CommentLine).ForeColor = Color.FromArgb(0, 128, 0)
            Editor.Styles(Style.Cpp.CommentLineDoc).ForeColor = Color.FromArgb(128, 128, 128)
            Editor.Styles(Style.Cpp.Number).ForeColor = Color.Olive
            Editor.Styles(Style.Cpp.Word).ForeColor = Color.Blue
            Editor.Styles(Style.Cpp.Word2).ForeColor = Color.Blue
            Editor.Styles(Style.Cpp.String).ForeColor = Color.FromArgb(163, 21, 21)
            Editor.Styles(Style.Cpp.Character).ForeColor = Color.FromArgb(163, 21, 21)
            Editor.Styles(Style.Cpp.Verbatim).ForeColor = Color.FromArgb(163, 21, 21)
            Editor.Styles(Style.Cpp.StringEol).BackColor = Color.Pink
            Editor.Styles(Style.Cpp.Operator).ForeColor = Color.Purple
            Editor.Styles(Style.Cpp.Preprocessor).ForeColor = Color.Maroon
            Editor.Lexer = Lexer.Vb

            Editor.SetKeywords(0, "as in for each next do loop if then else end class interface delegate do event true false is namespace new object overrides private public protected readonly return try catch virtual while until sub function")
            Editor.SetKeywords(1, "boolean byte char class const decimal double enum double integer long single static string nothing")
        Else
            Editor.StyleResetDefault()
            Editor.Styles(Style.Default).Font = "Lucida Console"
            Editor.Styles(Style.Default).Size = 10
            Editor.StyleClearAll()

            Editor.Styles(Style.Cpp.Default).ForeColor = Color.Silver
            Editor.Styles(Style.Cpp.Comment).ForeColor = Color.FromArgb(0, 128, 0)
            Editor.Styles(Style.Cpp.CommentLine).ForeColor = Color.FromArgb(0, 128, 0)
            Editor.Styles(Style.Cpp.CommentLineDoc).ForeColor = Color.FromArgb(128, 128, 128)
            Editor.Styles(Style.Cpp.Number).ForeColor = Color.Olive
            Editor.Styles(Style.Cpp.Word).ForeColor = Color.Blue
            Editor.Styles(Style.Cpp.Word2).ForeColor = Color.Blue
            Editor.Styles(Style.Cpp.String).ForeColor = Color.FromArgb(163, 21, 21)
            Editor.Styles(Style.Cpp.Character).ForeColor = Color.FromArgb(163, 21, 21)
            Editor.Styles(Style.Cpp.Verbatim).ForeColor = Color.FromArgb(163, 21, 21)
            Editor.Styles(Style.Cpp.StringEol).BackColor = Color.Pink
            Editor.Styles(Style.Cpp.Operator).ForeColor = Color.Purple
            Editor.Styles(Style.Cpp.Preprocessor).ForeColor = Color.Maroon
            Editor.Lexer = Lexer.Cpp

            Editor.SetKeywords(0, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while")
            Editor.SetKeywords(1, "bool byte char class const decimal double enum float int long sbyte short static string struct uint ulong ushort void")
        End If
    End Sub
End Module
