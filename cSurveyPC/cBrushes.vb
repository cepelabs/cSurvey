Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cBrushes
        Private WithEvents oSurvey As cSurvey

        Private oBrushNone As cBrush
        Private oBrushSolid As cBrush
        Private oBrushWater As cBrush
        Private oBrushWaterSolid As cBrush
        Private oBrushSignSolid As cBrush
        Private oBrushSand As cBrush
        Private oBrushPebbles As cBrush
        Private oBrushFlow As cBrush
        Private oBrushSmallDebrits As cBrush
        Private oBrushBigDebrits As cBrush
        Private oBrushSnowOrIce As cBrush

        Public ReadOnly Property None() As cBrush
            Get
                If oBrushNone Is Nothing Then
                    oBrushNone = New cBrush(oSurvey, GetLocalizedString("brushes.none"), cBrush.BrushTypeEnum.None, Color.Transparent, cBrush.HatchTypeEnum.None)
                End If
                Return oBrushNone
            End Get
        End Property

        Public ReadOnly Property SnowOrIce() As cBrush
            Get
                If oBrushSnowOrIce Is Nothing Then
                    oBrushSnowOrIce = New cBrush(oSurvey, GetLocalizedString("brushes.snoworice"), cBrush.BrushTypeEnum.SnowOrIce, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.Ice, 0.3, 0.02, Color.LightBlue, cBrush.ClipartAngleModeEnum.Fixed, 0, cBrush.ClipartCropEnum.Full, cBrush.ClipartPositionEnum.Fixed)
                End If
                Return oBrushSnowOrIce
            End Get
        End Property

        Public ReadOnly Property Solid() As cBrush
            Get
                If oBrushSolid Is Nothing Then
                    oBrushSolid = New cBrush(oSurvey, GetLocalizedString("brushes.solid"), cBrush.BrushTypeEnum.Solid, Color.White, cBrush.HatchTypeEnum.Solid)
                End If
                Return oBrushSolid
            End Get
        End Property

        Public ReadOnly Property Water() As cBrush
            Get
                If oBrushWater Is Nothing Then
                    oBrushWater = New cBrush(oSurvey, GetLocalizedString("brushes.water"), cBrush.BrushTypeEnum.Water, Color.Black, cBrush.HatchTypeEnum.Pattern, , 0.25, , Color.LightSkyBlue, cBrush.ClipartAngleModeEnum.Fixed, 45)
                End If
                Return oBrushWater
            End Get
        End Property

        Public ReadOnly Property NotStandardWater() As cBrush
            Get
                If oBrushWaterSolid Is Nothing Then
                    oBrushWaterSolid = New cBrush(oSurvey, GetLocalizedString("brushes.notstandardwater"), cBrush.BrushTypeEnum.NotStandardWater, Color.LightSkyBlue, cBrush.HatchTypeEnum.Solid)
                End If
                Return oBrushWaterSolid
            End Get
        End Property

        Public ReadOnly Property SignSolid() As cBrush
            Get
                If oBrushSignSolid Is Nothing Then
                    oBrushSignSolid = New cBrush(oSurvey, GetLocalizedString("brushes.signsolid"), cBrush.BrushTypeEnum.SignSolid, Color.Black, cBrush.HatchTypeEnum.Solid)
                End If
                Return oBrushSignSolid
            End Get
        End Property

        Public ReadOnly Property Sand() As cBrush
            Get
                If oBrushSand Is Nothing Then
                    oBrushSand = New cBrush(oSurvey, GetLocalizedString("brushes.sand"), cBrush.BrushTypeEnum.Sand, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartSand, 0.5, 0.1, Color.SandyBrown, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.None)
                End If
                Return oBrushSand
            End Get
        End Property

        Public ReadOnly Property Pebbles() As cBrush
            Get
                If oBrushPebbles Is Nothing Then
                    oBrushPebbles = New cBrush(oSurvey, GetLocalizedString("brushes.pebbles"), cBrush.BrushTypeEnum.Pebbles, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartPebbles1, 0.6, 0.01, Color.Gray, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.Subitems)
                End If
                Return oBrushPebbles
            End Get
        End Property

        Public ReadOnly Property SmallDebrits() As cBrush
            Get
                If oBrushSmallDebrits Is Nothing Then
                    oBrushSmallDebrits = New cBrush(oSurvey, GetLocalizedString("brushes.smalldebrits"), cBrush.BrushTypeEnum.SmallDebrits, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartDebrits1, 0.9, 0.006, Color.LightGray, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.Subitems)
                End If
                Return oBrushSmallDebrits
            End Get
        End Property

        Public ReadOnly Property BigDebrits() As cBrush
            Get
                If oBrushBigDebrits Is Nothing Then
                    oBrushBigDebrits = New cBrush(oSurvey, GetLocalizedString("brushes.bigdebrits"), cBrush.BrushTypeEnum.BigDebrits, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartDebrits2, 2.6, 0.018, Color.LightGray, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.Subitems)
                End If
                Return oBrushBigDebrits
            End Get
        End Property

        Public ReadOnly Property Flow() As cBrush
            Get
                If oBrushFlow Is Nothing Then
                    oBrushFlow = New cBrush(oSurvey, GetLocalizedString("brushes.flow"), cBrush.BrushTypeEnum.Flow, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartFlow1, 0.6, 0.006, Color.WhiteSmoke, cBrush.ClipartAngleModeEnum.Fixed, 0, cBrush.ClipartCropEnum.Full)
                End If
                Return oBrushFlow
            End Get
        End Property

        Public Function FromCustom(ByVal Color As Color, Optional ByVal Name As String = "", Optional ByVal HatchStyle As cBrush.HatchTypeEnum = cBrush.HatchTypeEnum.None) As cBrush
            Dim oBrush As cBrush = New cBrush(oSurvey, Name, cBrush.BrushTypeEnum.Custom, Color, HatchStyle)
            Return oBrush
        End Function

        Public Function FromType(ByVal Type As cBrush.BrushTypeEnum) As cBrush
            Select Case Type
                Case cBrush.BrushTypeEnum.None
                    Return None
                Case cBrush.BrushTypeEnum.Water
                    Return Water
                Case cBrush.BrushTypeEnum.NotStandardWater
                    Return NotStandardWater
                Case cBrush.BrushTypeEnum.SignSolid
                    Return SignSolid
                Case cBrush.BrushTypeEnum.Solid
                    Return Solid
                Case cBrush.BrushTypeEnum.Sand
                    Return Sand
                Case cBrush.BrushTypeEnum.Pebbles
                    Return Pebbles
                Case cBrush.BrushTypeEnum.Flow
                    Return Flow
                Case cBrush.BrushTypeEnum.SmallDebrits
                    Return SmallDebrits
                Case cBrush.BrushTypeEnum.BigDebrits
                    Return BigDebrits
                Case cBrush.BrushTypeEnum.SnowOrIce
                    Return SnowOrIce
                Case Else
                    'inutile...?!?
                    Return New cBrush(oSurvey)
            End Select
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
        End Sub

        Private Sub oSurvey_OnPropertiesChanged(ByVal Sender As cSurvey, ByVal Args As cSurvey.OnPropertiesChangedEventArgs) Handles oSurvey.OnPropertiesChanged

        End Sub
    End Class
End Namespace
