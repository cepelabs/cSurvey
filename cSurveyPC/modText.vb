Module modText
    Public Function GetNumber(ByVal Text As String) As Double
        Dim sTemp As String = Text
        sTemp = sTemp.Replace(",", "")
        sTemp = sTemp.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
        Try
            Return Double.Parse(sTemp)
        Catch
            Return 0
        End Try
    End Function

    Public Function AlignLeft(ByVal Text As String, ByVal Chars As Integer) As String
        Try
            Return Text & Space(Chars - Text.Length)
        Catch
            Return Space(Chars)
        End Try
    End Function

    Public Function AlignRight(ByVal Text As String, ByVal Chars As Integer) As String
        Try
            Return Space(Chars - Text.Length) & Text
        Catch
            Return Space(Chars)
        End Try
    End Function

    Public Function FormatNumber(ByVal Number As Integer, Optional ByVal Style As String = "") As String
        Dim sTemp As String = Strings.Format(Number, Style)
        sTemp = sTemp.Replace(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
        Return sTemp
    End Function

    Public Function FormatNumber(ByVal Number As Single, Optional ByVal Style As String = "") As String
        Dim sTemp As String = Strings.Format(Number, Style)
        sTemp = sTemp.Replace(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
        Return sTemp
    End Function

    Public Function FormatNumber(ByVal Number As Double, Optional ByVal Style As String = "") As String
        Dim sTemp As String = Strings.Format(Number, Style)
        sTemp = sTemp.Replace(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
        Return sTemp
    End Function

    Public Function FormatNumber(ByVal Number As Decimal, Optional ByVal Style As String = "") As String
        Dim sTemp As String = Strings.Format(Number, Style)
        sTemp = sTemp.Replace(Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator, ".")
        Return sTemp
    End Function
End Module
