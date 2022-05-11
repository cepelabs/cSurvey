Imports System.Xml

Namespace cSurvey
    Public Class cCoordinate
        Private sLat As String = ""
        Private sLong As String = ""
        Private sAlt As String = ""

        Private sX As String = ""
        Private sY As String = ""
        Private sBand As String = ""
        Private sZone As String = ""

        Private sLatValue As Decimal
        Private sLongValue As Decimal
        Private sAltValue As Decimal

        Private sFormat As String
        Private sSystem As String

        Private iFix As FixEnum

        Friend Event OnChange(ByVal Sender As cCoordinate)

        Private sLastError As String
        Private bLastError As Boolean

        Public Enum FixEnum
            [Default] = 0
            [Manual] = 1
        End Enum

        Public Sub Clear()
            sLastError = ""
            sLatValue = 0
            sLongValue = 0
            sAltValue = 0

            sLat = ""
            sLong = ""
            sAlt = ""

            sX = ""
            sY = ""
            sBand = ""
            sZone = ""

            iFix = FixEnum.Default

            sFormat = "dd mm ss.ss n"
            sSystem = "WGS84"

            RaiseEvent OnChange(Me)
        End Sub

        Public Property Fix As FixEnum
            Get
                Return iFix
            End Get
            Set(value As FixEnum)
                If ifix <> value Then
                    ifix = value
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public ReadOnly Property IsInError As Boolean
            Get
                Return bLastError
            End Get
        End Property

        Public ReadOnly Property LastError As String
            Get
                Return sLastError
            End Get
        End Property

        Private Sub pSetUserValues()
            If Not bLastError Then
                Select Case sSystem
                    Case "WGS84/UTM"
                        Dim oUTM As UTM = modUTM.WGS84ToUTM(sLongValue, sLatValue) 'New modUTM.UTM(sBand, sZone, sX, sY)
                        sX = Strings.Format(oUTM.East, "0.00")
                        sY = Strings.Format(oUTM.North, "0.00")
                        sBand = oUTM.Band
                        sZone = oUTM.Zone
                    Case Else
                        sLat = pSetLatitude()
                        sLong = pSetLongitude()
                End Select
                sAlt = pSetAltitude()
            End If
        End Sub

        Private Sub pSetLastError([Error] As String)
            sLastError = [Error]
            bLastError = True
        End Sub

        Private Sub pResetError()
            sLastError = ""
            bLastError = False
        End Sub

        Public Function Convert(System As String, Optional Format As String = "") As Boolean
            If sSystem <> System Then
                Select Case System
                    Case "WGS84/UTM"
                        Try
                            'Dim oUTM As UTM = modUTM.WGS84ToUTM(Me)
                            sSystem = System
                            Call pSetUserValues()
                        Catch ex As Exception
                            sLastError = ex.Message
                            Return False
                        End Try
                    Case Else
                        Try
                            'Dim oWGS84 As WGS84 = modUTM.UTMToWGS84(Me)
                            'sLat = oWGS84.Latitude
                            'sLong = oWGS84.Longitude
                            If Format <> "" Then
                                sFormat = Format
                            Else
                                sFormat = "dd mm ss.ss N"
                            End If
                            sSystem = System
                            Call pSetUserValues()
                        Catch ex As Exception
                            sLastError = ex.Message
                            Return False
                        End Try
                End Select
            End If
            Return True
        End Function

        Private Sub pSetInnerValues()
            If Not IsEmpty(False) Then
                Select Case sSystem
                    Case "WGS84/UTM"
                        Try
                            Dim iZone As Integer = Integer.Parse(sZone)
                            Dim dX As Decimal = modNumbers.FormatFromEdit(modNumbers.AnyDecimalSeparatorToPoint(sX), 2)
                            Dim dY As Decimal = modNumbers.FormatFromEdit(modNumbers.AnyDecimalSeparatorToPoint(sY), 2)
                            Dim oUTM As UTM = New UTM("" & sBand, iZone, dX, dY)
                            Dim oWGS84 As WGS84 = modUTM.UTMToWGS84(oUTM)
                            sLatValue = oWGS84.Latitude
                            sLongValue = oWGS84.Longitude
                            sAltValue = pGetAltitude()
                            Call pResetError()
                        Catch ex As Exception
                            Call pSetLastError(ex.Message)
                        End Try
                    Case Else
                        Try
                            sLatValue = pGetLatitude()
                            sLongValue = pGetLongitude()
                            sAltValue = pGetAltitude()
                            Call pResetError()
                        Catch ex As Exception
                            Call pSetLastError(ex.Message)
                        End Try
                End Select
                Call pSetUserValues()
            End If
        End Sub

        Public Function pSetAltitude() As String
            Return String.Format(sAltValue, "0")
        End Function

        Public Function pSetLongitude() As String
            Return pSetAngle(sLongValue, LatLongEnum.Longitude)
        End Function

        Public Function pSetLatitude() As String
            Return pSetAngle(sLatValue, LatLongEnum.Latitude)
        End Function

        Public Function GetAltitude() As Decimal
            Return sAltValue
        End Function

        Private Function pGetAltitude() As Decimal
            Dim sTemp As String = modNumbers.AnyDecimalSeparatorToPoint(sAlt.Trim)
            Return modNumbers.StringToDecimal(sTemp)
        End Function

        Public Function GetLongitude() As Decimal
            Return sLongValue
        End Function

        Private Function pGetLongitude() As Decimal
            Return pGetAngle(sLong, LatLongEnum.Longitude)
        End Function

        Private Function pRemoveChars(ByVal Value As String) As String
            Value = Value.Replace("°", " ")
            Value = Value.Replace("'", " ")
            Value = Value.Replace(Chr(34), " ")

            Value = Value.Replace("N", "")
            Value = Value.Replace("S", "")
            Value = Value.Replace("E", "")
            Value = Value.Replace("W", "")
            Return Value
        End Function

        Public Function GetLatitude() As Decimal
            Return sLatValue
        End Function

        Private Function pGetLatitude() As Decimal
            Return pGetAngle(sLat, LatLongEnum.Latitude)
        End Function

        Private Enum LatLongEnum
            Latitude = 0
            Longitude = 1
        End Enum

        Private Function pSetAngle(Value As Decimal, LatLong As LatLongEnum) As String
            Select Case sFormat.ToLower
                Case "dd.ddddddd n", "d.ddddddd n"
                    Dim sValue As String = Strings.Format(Math.Abs(Value), "0.0000000\°")
                    Dim sSign As String
                    If LatLong = LatLongEnum.Latitude Then
                        If Math.Sign(Value) < 0 Then
                            sSign = "S"
                        Else
                            sSign = "N"
                        End If
                    Else
                        If Math.Sign(Value) < 0 Then
                            sSign = "W"
                        Else
                            sSign = "E"
                        End If
                    End If
                    Return sValue & " " & sSign
                Case "dd mm.mmm n", "d m.mmm n"
                    Dim dValue As Decimal = Math.Abs(Value)
                    Dim dD As Decimal = dValue - (dValue Mod 1)
                    Dim dM As Decimal = (dValue Mod 1) * 60
                    Dim sValue As String = Strings.Format(dD, "0\°") & " " & Strings.Format(dM, "0.000\'")

                    Dim sSign As String
                    If LatLong = LatLongEnum.Latitude Then
                        If Math.Sign(Value) < 0 Then
                            sSign = "S"
                        Else
                            sSign = "N"
                        End If
                    Else
                        If Math.Sign(Value) < 0 Then
                            sSign = "W"
                        Else
                            sSign = "E"
                        End If
                    End If
                    Return sValue & " " & sSign
                Case "dd mm ss.ss n", "d m s.ss n"
                    Dim dValue As Decimal = Math.Abs(Value)
                    Dim dD As Decimal = dValue - (dValue Mod 1)
                    Dim dM As Decimal = (dValue Mod 1) * 60
                    Dim dS As Decimal = (dM Mod 1) * 60
                    dM = dM - (dM Mod 1)
                    Dim sValue As String = Strings.Format(dD, "0\°") & " " & Strings.Format(dM, "0\'") & " " & Strings.Format(dS, "0.000\""")

                    Dim sSign As String
                    If LatLong = LatLongEnum.Latitude Then
                        If Math.Sign(Value) < 0 Then
                            sSign = "S"
                        Else
                            sSign = "N"
                        End If
                    Else
                        If Math.Sign(Value) < 0 Then
                            sSign = "W"
                        Else
                            sSign = "E"
                        End If
                    End If
                    Return sValue & " " & sSign
            End Select
        End Function

        Private Function pGetAngle(Value As String, LatLong As LatLongEnum) As Decimal
            Select Case sFormat.ToLower
                Case "dd.ddddddd n", "d.ddddddd n"
                    Dim sTemp As String = modNumbers.AnyDecimalSeparatorToPoint(Value.Trim.ToUpper)
                    Dim sSig As Decimal
                    If LatLong = LatLongEnum.Latitude Then
                        If sTemp.EndsWith("S") Then
                            sSig = -1
                        Else
                            sSig = 1
                        End If
                    Else
                        If sTemp.EndsWith("W") Then
                            sSig = -1
                        Else
                            sSig = 1
                        End If
                    End If
                    sTemp = pRemoveChars(sTemp)
                    Dim sD As Decimal = modNumbers.StringToDecimal(sTemp)
                    Dim dValue As Decimal = sSig * sD
                    Return dValue
                Case "dd mm.mmm n", "d m.mmm n"
                    Dim sTemp As String = modNumbers.AnyDecimalSeparatorToPoint(Value.Trim.ToUpper)
                    Dim sSig As Decimal
                    If LatLong = LatLongEnum.Latitude Then
                        If sTemp.EndsWith("S") Then
                            sSig = -1
                        Else
                            sSig = 1
                        End If
                    Else
                        If sTemp.EndsWith("W") Then
                            sSig = -1
                        Else
                            sSig = 1
                        End If
                    End If
                    sTemp = pRemoveChars(sTemp)
                    Dim sParts() As String = sTemp.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                    If sParts.Length >= 2 Then
                        Dim sD As Decimal = modNumbers.StringToDecimal(sParts(0))
                        Dim sM As Decimal = modNumbers.StringToDecimal(sParts(1))
                        Dim dValue As Decimal = sSig * (sD + sM / 60)
                        Return dValue
                    Else
                        Return 0
                    End If
                Case "dd mm ss.sss n", "dd mm ss.ss n", "d m s.ss n"
                    Dim sTemp As String = modNumbers.AnyDecimalSeparatorToPoint(Value.Trim.ToUpper)
                    Dim sSig As Decimal
                    If LatLong = LatLongEnum.Latitude Then
                        If sTemp.EndsWith("S") Then
                            sSig = -1
                        Else
                            sSig = 1
                        End If
                    Else
                        If sTemp.EndsWith("W") Then
                            sSig = -1
                        Else
                            sSig = 1
                        End If
                    End If
                    sTemp = pRemoveChars(sTemp)
                    Dim sParts() As String = sTemp.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                    If sParts.Length >= 3 Then
                        Dim sD As Decimal = modNumbers.StringToDecimal(sParts(0))
                        Dim sM As Decimal = modNumbers.StringToDecimal(sParts(1))
                        Dim sS As Decimal = modNumbers.StringToDecimal(sParts(2))
                        Dim dValue As Decimal = sSig * (sD + sM / 60 + sS / 3600)
                        Return dValue
                    Else
                        Return 0
                    End If
            End Select
        End Function

        Public ReadOnly Property IsEmpty(Optional ByVal CheckAltitude As Boolean = False)
            Get
                Select Case sSystem
                    Case "WGS84/UTM"
                        If CheckAltitude Then
                            Return (sX = "" Or sY = "" Or sAlt = "")
                        Else
                            Return (sX = "" Or sY = "")
                        End If
                    Case Else
                        If CheckAltitude Then
                            Return (sLat = "" Or sLong = "" Or sAlt = "")
                        Else
                            Return (sLat = "" Or sLong = "")
                        End If
                End Select
            End Get
        End Property

        Public Property X() As String
            Get
                Return sX
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sX Then
                    sX = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Y() As String
            Get
                Return sY
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sY Then
                    sY = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Band() As String
            Get
                Return sBand
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sBand Then
                    sBand = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Zone() As String
            Get
                Return sZone
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sZone Then
                    sZone = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Latitude() As String
            Get
                Return sLat
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sLat Then
                    sLat = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Longitude() As String
            Get
                Return sLong
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sLong Then
                    sLong = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Altitude() As String
            Get
                Return sAlt
            End Get
            Set(ByVal value As String)
                value = value.Trim
                If value <> sAlt Then
                    sAlt = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property Format() As String
            Get
                Return sFormat
            End Get
            Set(ByVal value As String)
                If value <> sFormat Then
                    sFormat = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Public Property System() As String
            Get
                Return sSystem
            End Get
            Set(ByVal value As String)
                If value <> sSystem Then
                    sSystem = value
                    Call pSetInnerValues()
                    RaiseEvent OnChange(Me)
                End If
            End Set
        End Property

        Friend Sub New()
            sLat = ""
            sLong = ""
            sAlt = ""
            sFormat = "dd mm ss.ss n"
            sSystem = "WGS84"

            iFix = FixEnum.Default
        End Sub

        Friend Sub New(ByVal X As Decimal, ByVal Y As Decimal, ByVal Band As String, Zone As Integer, Altitude As Decimal)
            Dim oUTM As UTM = New UTM("" & Band, Zone, X, Y)

            Dim oWGS84 As WGS84 = modUTM.UTMToWGS84(oUTM)
            sLatValue = oWGS84.Latitude
            sLongValue = oWGS84.Longitude
            sAltValue = Altitude

            sFormat = ""
            sSystem = "WGS84/UTM"

            iFix = FixEnum.Default

            Call pSetUserValues()
        End Sub

        Friend Sub New(ByVal X As String, ByVal Y As String, ByVal Band As String, Zone As String, Altitude As String)
            sX = X
            sY = Y
            sBand = Band
            sZone = Zone

            sAlt = Altitude
            sFormat = ""
            sSystem = "WGS84/UTM"

            iFix = FixEnum.Default

            Call pSetInnerValues()
        End Sub

        Friend Sub New(ByVal Latitude As Decimal, ByVal Longitude As Decimal, ByVal Altitude As Decimal)
            sLatValue = Latitude
            sLongValue = Longitude

            sAltValue = Altitude
            sFormat = "dd.ddddddd n"
            sSystem = "WGS84"

            iFix = FixEnum.Default

            Call pSetUserValues()
        End Sub

        Friend Sub New(Latitude As String, Longitude As String, Altitude As String, Format As String)
            sLat = Latitude
            sLong = Longitude

            sAlt = Altitude
            sFormat = Format
            sSystem = "WGS84"

            iFix = FixEnum.Default

            Call pSetInnerValues()
        End Sub

        Friend Sub New(ByVal Coordinate As cCoordinate)
            sX = Coordinate.sX
            sY = Coordinate.sY
            sZone = Coordinate.sZone
            sBand = Coordinate.sBand
            sLat = Coordinate.sLat
            sLong = Coordinate.sLong
            sAlt = Coordinate.sAlt
            sFormat = Coordinate.sFormat
            sSystem = Coordinate.sSystem
            iFix = Coordinate.iFix
            Call pSetInnerValues()
        End Sub

        Friend Sub New(ByVal Coordinate As XmlElement)
            sLatValue = modNumbers.StringToDecimal(modXML.GetAttributeValue(Coordinate, "latv", 0))
            sLongValue = modNumbers.StringToDecimal(modXML.GetAttributeValue(Coordinate, "longv", 0))
            sAltValue = modNumbers.StringToDecimal(modXML.GetAttributeValue(Coordinate, "altv", 0))

            sSystem = modXML.GetAttributeValue(Coordinate, "geo", "WGS84")
            If sSystem = "" Then sSystem = "WGS84"
            Select Case sSystem
                Case "WGS84/UTM"
                    sX = modXML.GetAttributeValue(Coordinate, "x", "")
                    sY = modXML.GetAttributeValue(Coordinate, "y", "")
                    sBand = modXML.GetAttributeValue(Coordinate, "band", "")
                    sZone = modXML.GetAttributeValue(Coordinate, "zone", "")
                Case Else
                    sLat = modXML.GetAttributeValue(Coordinate, "lat", "")
                    sLong = modXML.GetAttributeValue(Coordinate, "long", "")
                    sFormat = modXML.GetAttributeValue(Coordinate, "format", "")
                    If sFormat = "" Then sFormat = "dd mm ss.ss N"
            End Select
            sAlt = modXML.GetAttributeValue(Coordinate, "alt", "")

            iFix = modXML.GetAttributeValue(Coordinate, "fix", "0")

            Call pSetInnerValues()
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCoordinate As XmlElement = Document.CreateElement("coordinate")
            Call oXmlCoordinate.SetAttribute("latv", modNumbers.NumberToString(sLatValue, DefaultCoordinateFormat))
            Call oXmlCoordinate.SetAttribute("longv", modNumbers.NumberToString(sLongValue, DefaultCoordinateFormat))
            Call oXmlCoordinate.SetAttribute("altv", modNumbers.NumberToString(sAltValue, "0.00"))

            If sSystem <> "WGS84" Then Call oXmlCoordinate.SetAttribute("geo", sSystem)
            Select Case sSystem
                Case "WGS84/UTM"
                    If sX <> "" Then Call oXmlCoordinate.SetAttribute("x", sX)
                    If sY <> "" Then Call oXmlCoordinate.SetAttribute("y", sY)
                    If sBand <> "" Then Call oXmlCoordinate.SetAttribute("band", sBand)
                    If sZone <> "" Then Call oXmlCoordinate.SetAttribute("zone", sZone)
                Case Else
                    If sLat <> "" Then Call oXmlCoordinate.SetAttribute("lat", sLat)
                    If sLong <> "" Then Call oXmlCoordinate.SetAttribute("long", sLong)
                    If sFormat <> "" Then Call oXmlCoordinate.SetAttribute("format", sFormat)
            End Select
            If sAlt <> "" Then Call oXmlCoordinate.SetAttribute("alt", sAlt)
            If iFix <> FixEnum.Default Then Call oXmlCoordinate.SetAttribute("fix", iFix.ToString("D"))

            Call Parent.AppendChild(oXmlCoordinate)
            Return oXmlCoordinate
        End Function

        Public Overrides Function ToString() As String
            Select Case sSystem
                Case "WGS84/UTM"
                    Return sX & " " & sY & " " & sBand & sZone & " " & sAlt
                Case Else
                    Return sLat & " " & sLong & " " & sAlt
            End Select
        End Function

        'Friend Sub CopyFrom(Coordinate As Calculate.cTrigPointCoordinate)
        '    sLatValue = Coordinate.Latitude
        '    sLongValue = Coordinate.Longitude
        '    sAltValue = Coordinate.Altitude
        '    Call pSetUserValues()
        '    RaiseEvent OnChange(Me)
        'End Sub

        Public Sub CopyFrom(Coordinate As cCoordinate)
            sLatValue = Coordinate.sLatValue
            sLongValue = Coordinate.sLongValue
            sAltValue = Coordinate.sAltValue

            sX = Coordinate.sX
            sY = Coordinate.sY
            sBand = Coordinate.sBand
            sZone = Coordinate.sZone

            sLat = Coordinate.sLat
            sLong = Coordinate.sLong

            sAlt = Coordinate.sAlt

            sFormat = Coordinate.sFormat
            sSystem = Coordinate.sSystem
            RaiseEvent OnChange(Me)
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace