Imports System.Globalization

Module modNumbers
    <Flags()> Public Enum CoordinateFormatEnum
        DecimalDegrees = 2
        DegreesMinutes = 1
        DegreesMinutesSeconds = 0
        Unsigned = &H10
        UnsignedMask = &HF0
        SignedMask = &HF
    End Enum

    Private sDoubleQuotes As String = Chr(34)

    Public Function MathRound(Number As Single, Decimals As Integer) As Single
        Return Math.Round(Number, Decimals, MidpointRounding.AwayFromZero)
    End Function

    Public Function MathRound(Number As Double, Decimals As Integer) As Double
        Return Math.Round(Number, Decimals, MidpointRounding.AwayFromZero)
    End Function

    Public Function MathRound(Number As Decimal, Decimals As Integer) As Decimal
        Return Math.Round(Number, Decimals, MidpointRounding.AwayFromZero)
    End Function

    Public Function NumberToString(ByVal Number As Single, Format As String, UseLocalFormat As Boolean) As String
        If Format <> "" Then
            If UseLocalFormat Then
                Return Number.ToString(Format, CultureInfo.CurrentCulture)
            Else
                Return Number.ToString(Format, CultureInfo.InvariantCulture)
            End If
        End If

        ' Formattazione standard veloce (senza zeri inutili)
        If UseLocalFormat Then
            Return Number.ToString("0.###", CultureInfo.CurrentCulture)
        Else
            Return Number.ToString("0.###", CultureInfo.InvariantCulture)
        End If

        'Dim sNumber As String
        'If Format <> "" Then
        '    sNumber = Strings.Format(Number, Format)
        'Else
        '    sNumber = Number
        'End If
        'If Not UseLocalFormat Then
        '    sNumber = sNumber.Replace(Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")
        'End If
        'Return sNumber
    End Function

    Public Function NumberToString(ByVal Number As Double, Format As String, UseLocalFormat As Boolean) As String
        If Format <> "" Then
            If UseLocalFormat Then
                Return Number.ToString(Format, CultureInfo.CurrentCulture)
            Else
                Return Number.ToString(Format, CultureInfo.InvariantCulture)
            End If
        End If

        ' Formattazione standard veloce (senza zeri inutili)
        If UseLocalFormat Then
            Return Number.ToString("0.###", CultureInfo.CurrentCulture)
        Else
            Return Number.ToString("0.###", CultureInfo.InvariantCulture)
        End If

        'Dim sNumber As String
        'If Format <> "" Then
        '    sNumber = Strings.Format(Number, Format)
        'Else
        '    sNumber = Number
        'End If
        'If Not UseLocalFormat Then
        '    sNumber = sNumber.Replace(Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")
        'End If
        'Return sNumber
    End Function

    Public Function NumberToString(ByVal Number As Decimal, Format As String, UseLocalFormat As Boolean) As String
        If Format <> "" Then
            If UseLocalFormat Then
                Return Number.ToString(Format, CultureInfo.CurrentCulture)
            Else
                Return Number.ToString(Format, CultureInfo.InvariantCulture)
            End If
        End If

        ' Formattazione standard veloce (senza zeri inutili)
        If UseLocalFormat Then
            Return Number.ToString("0.###", CultureInfo.CurrentCulture)
        Else
            Return Number.ToString("0.###", CultureInfo.InvariantCulture)
        End If

        'Dim sNumber As String
        'If Format <> "" Then
        '    sNumber = Strings.Format(Number, Format)
        'Else
        '    sNumber = Number
        'End If
        'If Not UseLocalFormat Then
        '    sNumber = sNumber.Replace(Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")
        'End If
        'Return sNumber
    End Function

    Public Function SizeFToString(Size As SizeF, Optional Format As String = "0.00") As String
        Return NumberToString(Size.Width, Format, False) & ";" & NumberToString(Size.Height, Format, False)
    End Function

    Public Function NumberToString(ByVal Number As Single, Optional Format As String = "0.00") As String
        Return NumberToString(Number, Format, False)
    End Function

    Public Function NumberToString(ByVal Number As Double, Optional Format As String = "0.00") As String
        Return NumberToString(Number, Format, False)
    End Function

    Public Function NumberToString(ByVal Number As Decimal, Optional Format As String = "0.00") As String
        Return NumberToString(Number, Format, False)
    End Function

    Public Function CurrentDecimalSeparatorToPoint(ByVal Number As String) As String
        Return Number.Replace(Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, ".")
    End Function

    Public Function AnyDecimalSeparatorToPoint(ByVal Number As String) As String
        Return CurrentDecimalSeparatorToPoint(Number).Replace(",", ".")
    End Function

    Public Function StringToDouble(ByVal [String] As Object) As Double
        If TypeOf [String] Is Double Then Return DirectCast([String], Double)
        If TypeOf [String] Is Single Then Return CDbl(DirectCast([String], Single))
        If TypeOf [String] Is Decimal Then Return CDbl(DirectCast([String], Decimal))
        If TypeOf [String] Is Integer Then Return CDbl(DirectCast([String], Integer))

        [String] = CStr([String])
        If String.IsNullOrWhiteSpace([String]) Then Return 0R
        Dim result As Double
        Return If(Double.TryParse([String], NumberStyles.Float, CultureInfo.InvariantCulture, result), result, 0R)

        'Dim sNumber As String = [String].Replace(".", Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
        'Dim dResult As Double
        'If Double.TryParse(sNumber, dResult) Then
        '    Return dResult
        'Else
        '    Return 0
        'End If
    End Function

    Public Function StringToSingle(ByVal [String] As Object) As Single
        If TypeOf [String] Is Single Then Return DirectCast([String], Single)
        If TypeOf [String] Is Double Then Return CSng(DirectCast([String], Double))
        If TypeOf [String] Is Decimal Then Return CSng(DirectCast([String], Decimal))
        If TypeOf [String] Is Integer Then Return CSng(DirectCast([String], Integer))

        [String] = CStr([String])
        If String.IsNullOrWhiteSpace([String]) Then Return 0R
        Dim result As Single
        Return If(Single.TryParse([String], NumberStyles.Float, CultureInfo.InvariantCulture, result), result, 0R)

        'Dim sNumber As String = [String].Replace(".", Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
        'Dim sResult As Single
        'If Single.TryParse(sNumber, sResult) Then
        '    Return sResult
        'Else
        '    Return 0
        'End If
    End Function

    Public Function StringToSizeF(ByVal [String] As String) As SizeF
        Try
            Dim sNumbers As String() = [String].Split(";")
            Return New SizeF(StringToSingle(sNumbers(0)), StringToSingle(sNumbers(1)))
        Catch
            Return New SizeF
        End Try
    End Function

    Public Function FieldUnformat(Data As String) As String
        Dim sData As String = Data.Trim
        If sData.StartsWith(sDoubleQuotes) And sData.EndsWith(sDoubleQuotes) Then
            Return sData.Substring(1, sData.Length - 2)
        Else
            Return sData
        End If
    End Function

    Public Function FieldFormat(Value As String) As String
        Dim sValue As String = Value.Trim
        Return sDoubleQuotes & sValue & sDoubleQuotes
    End Function

    Public Function StringToInteger(ByVal [String] As Object) As Integer
        If TypeOf [String] Is Integer Then Return DirectCast([String], Integer)
        If TypeOf [String] Is Single Then Return CInt(DirectCast([String], Integer))
        If TypeOf [String] Is Double Then Return CInt(DirectCast([String], Double))
        If TypeOf [String] Is Decimal Then Return CInt(DirectCast([String], Decimal))

        [String] = CStr([String])
        If String.IsNullOrWhiteSpace([String]) Then Return 0
        Dim value As Integer
        Return If(Integer.TryParse([String].Trim, NumberStyles.Integer, CultureInfo.InvariantCulture, value), value, 0)

        'Dim sNumber As String = [String].Replace(".", Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
        'Dim dResult As Integer
        'If Integer.TryParse(sNumber, dResult) Then
        '    Return dResult
        'Else
        '    Return 0
        'End If
    End Function

    Public Function ToDecimal(ByVal Value As Object) As Decimal
        Try
            Return Convert.ToDecimal(Value)
        Catch
            Return 0
        End Try
    End Function

    Public Function StringToDecimal(ByVal [String] As String) As Decimal
        Dim sNumber As String = [String].Replace(".", Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
        Dim dResult As Decimal
        If Decimal.TryParse(sNumber, dResult) Then
            Return dResult
        Else
            Return 0
        End If
    End Function

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Public Function FormatFromEdit(ByVal Value As Object, Optional ByVal Decimals As Integer = 2) As Decimal
        Try
            Dim sValue As String = Value
            sValue = sValue.Trim
            sValue = sValue.Replace(".", Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            If sValue.StartsWith(Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator) Then
                sValue = "0" & sValue
            End If
            Return modNumbers.MathRound(CDec(sValue), Decimals)
        Catch
            Return 0
        End Try
    End Function

    Public Function NumberToCoordinate(ByVal Value As Decimal, Optional ByVal Format As CoordinateFormatEnum = CoordinateFormatEnum.DegreesMinutesSeconds, Optional PositiveSignSimbol As String = "", Optional NegativeSignSimbol As String = "") As String
        Dim sSign As String = ""
        If Format And CoordinateFormatEnum.UnsignedMask Then
            'coordinate senza segno (ma con indicazione N/S, E/W
            Dim iSign As Integer = Math.Sign(Value)
            Value = Math.Abs(Value)
            If iSign >= 0 Then
                If PositiveSignSimbol = "" Then
                    sSign = "{+}"
                Else
                    sSign = PositiveSignSimbol
                End If
            Else
                If NegativeSignSimbol = "" Then
                    sSign = "{-}"
                Else
                    sSign = NegativeSignSimbol
                End If
            End If
        End If
        Select Case (Format And CoordinateFormatEnum.SignedMask)
            Case CoordinateFormatEnum.DecimalDegrees
                Return CurrentDecimalSeparatorToPoint(Strings.Format(Value, "00.00000000\°") & " " & sSign)
            Case CoordinateFormatEnum.DegreesMinutes
                Dim iGrade As Integer = Decimal.Truncate(Value)
                Dim dMinute As Decimal = 0.6 * ((Value Mod 1) * 100)
                Return CurrentDecimalSeparatorToPoint(Strings.Format(iGrade, "0\°") & " " & Strings.Format(dMinute, "00.00000\'") & " " & sSign)
            Case CoordinateFormatEnum.DegreesMinutesSeconds
                Dim iGrade As Integer = Decimal.Truncate(Value)
                Dim dMinute As Decimal = 0.6 * ((Value Mod 1) * 100)
                Dim iMinute As Integer = Decimal.Truncate(dMinute)
                Dim dSecond As Decimal = 60 * (dMinute - iMinute)
                Return CurrentDecimalSeparatorToPoint(Strings.Format(iGrade, "0\°") & " " & Strings.Format(iMinute, "00\'") & " " & Strings.Format(dSecond, "00.000\""") & " " & sSign)
        End Select
    End Function

    'Function StringToDecimal(sLineParts As String, p2 As Decimal) As Single
    '    Throw New NotImplementedException
    'End Function

End Module
