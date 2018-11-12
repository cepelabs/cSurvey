Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cPens
        Private WithEvents oSurvey As cSurvey

        'Private sHeavyPenWidth As Single '= 8
        'Private sMediumPenWidth As Single '= 3
        'Private sLightPenWidth As Single '= 1
        'Private sUltralightPenWidth As Single '= 0.3
        'Private sTightPenWidth As Single = 0

        Private oPenNone As cPen

        Private oPenGenericPen As cPen
        Private oPenPresumedGenericPen As cPen

        Private oPenCavePen As cPen
        Private oPenPresumedCavePen As cPen
        Private oPenTooNarrowCavePen As cPen
        Private oPenUnderlyingCavePen As cPen

        Private oPenPen As cPen
        Private oPenPresumedPen As cPen

        Private oPenTightPen As cPen
        Private oPenPresumedTightPen As cPen

        Private oPenGradientUpPen As cPen
        Private oPenPresumedGradientUpPen As cPen

        Private oPenGradientDownPen As cPen
        Private oPenPresumedGradientDownPen As cPen

        Private oPenCliffUpPen As cPen
        Private oPenPresumedCliffUpPen As cPen

        Private oPenCliffDownPen As cPen
        Private oPenPresumedCliffDownPen As cPen

        Private oPenOverhangUpPen As cPen
        Private oPenPresumedOverhangUpPen As cPen

        Private oPenOverhangDownPen As cPen
        Private oPenPresumedOverhangDownPen As cPen

        Private oPenMeanderPen As cPen
        Private oPenPresumedMeanderPen As cPen

        Private oPenIcePen As cPen
        Private oPenPresumedIcePen As cPen
        'none=0
        'GenericPen=sUltralightPenWidth
        'CavePen=sHeavyPenWidth
        'PresumedCavePen=sHeavyPenWidth
        'Pen=sMediumPenWidth
        'PresumedPen=sMediumPenWidth
        'TightPen=sTightPenWidth
        'GradientUpPen=sMediumPenWidth
        'GradientDownPen=sMediumPenWidth
        'CliffUpPen=sMediumPenWidth
        'CliffDownPen=sMediumPenWidth
        'OverhangUpPen=sMediumPenWidth
        'OverhangUpPen=sMediumPenWidth

        Public ReadOnly Property None() As cPen
            Get
                If oPenNone Is Nothing Then
                    oPenNone = New cPen(oSurvey, GetLocalizedString("pens.none"), cPen.PenTypeEnum.None, Color.Transparent, 0)
                End If
                Return oPenNone
            End Get
        End Property

        Public ReadOnly Property GenericPen() As cPen
            Get
                If oPenGenericPen Is Nothing Then
                    oPenGenericPen = New cPen(oSurvey, GetLocalizedString("pens.genericpen"), cPen.PenTypeEnum.GenericPen, Color.Black, 0)
                End If
                Return oPenGenericPen
            End Get
        End Property

        Public ReadOnly Property PresumedGenericPen() As cPen
            Get
                If oPenPresumedGenericPen Is Nothing Then
                    oPenPresumedGenericPen = New cPen(oSurvey, GetLocalizedString("pens.presumedgenericpen"), cPen.PenTypeEnum.PresumedGenericPen, Color.Black, 0, cPen.PenStylesEnum.Dash)
                End If
                Return oPenPresumedGenericPen
            End Get
        End Property

        Public ReadOnly Property CavePen() As cPen
            Get
                If oPenCavePen Is Nothing Then
                    oPenCavePen = New cPen(oSurvey, GetLocalizedString("pens.cavepen"), cPen.PenTypeEnum.CavePen, Color.Black, 0)
                End If
                Return oPenCavePen
            End Get
        End Property

        Public ReadOnly Property UnderlyingCavePen() As cPen
            Get
                If oPenUnderlyingCavePen Is Nothing Then
                    oPenUnderlyingCavePen = New cPen(oSurvey, GetLocalizedString("pens.underlyingcavepen"), cPen.PenTypeEnum.UnderlyingCavePen, Color.Black, 0, cPen.PenStylesEnum.LargeDashLargeSpace)
                End If
                Return oPenUnderlyingCavePen
            End Get
        End Property

        Public ReadOnly Property TooNarrowCavePen() As cPen
            Get
                If oPenTooNarrowCavePen Is Nothing Then
                    oPenTooNarrowCavePen = New cPen(oSurvey, GetLocalizedString("pens.toonarrowcavepen"), cPen.PenTypeEnum.TooNarrowCavePen, Color.Black, 0, cPen.PenStylesEnum.LargeDashMediumSpace)
                End If
                Return oPenTooNarrowCavePen
            End Get
        End Property

        Public ReadOnly Property PresumedCavePen() As cPen
            Get
                If oPenPresumedCavePen Is Nothing Then
                    oPenPresumedCavePen = New cPen(oSurvey, GetLocalizedString("pens.presumedcavepen"), cPen.PenTypeEnum.PresumedCavePen, Color.Black, 0, cPen.PenStylesEnum.LargeDashSmallSpace)
                End If
                Return oPenPresumedCavePen
            End Get
        End Property

        Public ReadOnly Property Pen() As cPen
            Get
                If oPenPen Is Nothing Then
                    oPenPen = New cPen(oSurvey, GetLocalizedString("pens.pen"), cPen.PenTypeEnum.Pen, Color.Black, 0)
                End If
                Return oPenPen
            End Get
        End Property

        Public ReadOnly Property PresumedPen() As cPen
            Get
                If oPenPresumedPen Is Nothing Then
                    oPenPresumedPen = New cPen(oSurvey, GetLocalizedString("pens.presumedpen"), cPen.PenTypeEnum.PresumedPen, Color.Black, 0, cPen.PenStylesEnum.Dash)
                End If
                Return oPenPresumedPen
            End Get
        End Property

        Public Function FromCustom(ByVal Color As Color, Optional ByVal Name As String = "", Optional ByVal Width As Integer = 0.1, Optional ByVal Style As cPen.PenStylesEnum = cPen.PenStylesEnum.Solid, Optional Clipart As Drawings.cDrawClipArt = Nothing, Optional ByVal DecorationStyle As cPen.DecorationStylesEnum = cPen.DecorationStylesEnum.None, Optional ByVal DecorationSpacePercentage As Single = 0, Optional ByVal DecorationAlignment As cPen.DecorationAlignmentEnum = cPen.DecorationStylesEnum.None) As cPen
            Dim oPen As cPen = New cPen(oSurvey, Name, cPen.PenTypeEnum.Custom, Color, Width, Style, Clipart, DecorationStyle, DecorationSpacePercentage, DecorationAlignment)
            Return oPen
        End Function

        Public ReadOnly Property TightPen() As cPen
            Get
                If oPenTightPen Is Nothing Then
                    oPenTightPen = New cPen(oSurvey, GetLocalizedString("pens.tightpen"), cPen.PenTypeEnum.TightPen, Color.Black, 0, cPen.PenStylesEnum.Solid)
                End If
                Return oPenTightPen
            End Get
        End Property

        Public ReadOnly Property PresumedTightPen() As cPen
            Get
                If oPenPresumedTightPen Is Nothing Then
                    oPenPresumedTightPen = New cPen(oSurvey, GetLocalizedString("pens.presumedtightpen"), cPen.PenTypeEnum.PresumedTightPen, Color.Black, 0, cPen.PenStylesEnum.Dash)
                End If
                Return oPenPresumedTightPen
            End Get
        End Property

        Public ReadOnly Property GradientUpPen() As cPen
            Get
                If oPenGradientUpPen Is Nothing Then
                    oPenGradientUpPen = New cPen(oSurvey, GetLocalizedString("pens.gradientuppen"), cPen.PenTypeEnum.GradientUpPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.UpArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenGradientUpPen
            End Get
        End Property

        Public ReadOnly Property PresumedGradientUpPen() As cPen
            Get
                If oPenPresumedGradientUpPen Is Nothing Then
                    oPenPresumedGradientUpPen = New cPen(oSurvey, GetLocalizedString("pens.presumedgradientuppen"), cPen.PenTypeEnum.PresumedGradientUpPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.UpArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenPresumedGradientUpPen
            End Get
        End Property

        Public ReadOnly Property GradientDownPen() As cPen
            Get
                If oPenGradientDownPen Is Nothing Then
                    oPenGradientDownPen = New cPen(oSurvey, GetLocalizedString("pens.gradientdownpen"), cPen.PenTypeEnum.GradientDownPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.DownArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenGradientDownPen
            End Get
        End Property

        Public ReadOnly Property PresumedGradientDownPen() As cPen
            Get
                If oPenPresumedGradientDownPen Is Nothing Then
                    oPenPresumedGradientDownPen = New cPen(oSurvey, GetLocalizedString("pens.presumedgradientdownpen"), cPen.PenTypeEnum.PresumedGradientDownPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.DownArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenPresumedGradientDownPen
            End Get
        End Property

        Public ReadOnly Property CliffUpPen() As cPen
            Get
                If oPenCliffUpPen Is Nothing Then
                    oPenCliffUpPen = New cPen(oSurvey, GetLocalizedString("pens.cliffuppen"), cPen.PenTypeEnum.CliffUpPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenCliffUpPen
            End Get
        End Property

        Public ReadOnly Property PresumedCliffUpPen() As cPen
            Get
                If oPenPresumedCliffUpPen Is Nothing Then
                    oPenPresumedCliffUpPen = New cPen(oSurvey, GetLocalizedString("pens.presumedcliffuppen"), cPen.PenTypeEnum.PresumedCliffUpPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenPresumedCliffUpPen
            End Get
        End Property

        Public ReadOnly Property CliffDownPen() As cPen
            Get
                If oPenCliffDownPen Is Nothing Then
                    oPenCliffDownPen = New cPen(oSurvey, GetLocalizedString("pens.cliffdownpen"), cPen.PenTypeEnum.CliffDownPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenCliffDownPen
            End Get
        End Property

        Public ReadOnly Property PresumedCliffDownPen() As cPen
            Get
                If oPenPresumedCliffDownPen Is Nothing Then
                    oPenPresumedCliffDownPen = New cPen(oSurvey, GetLocalizedString("pens.presumedcliffdownpen"), cPen.PenTypeEnum.PresumedCliffDownPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenPresumedCliffDownPen
            End Get
        End Property

        Public ReadOnly Property OverhangUpPen() As cPen
            Get
                If oPenOverhangUpPen Is Nothing Then
                    oPenOverhangUpPen = New cPen(oSurvey, GetLocalizedString("pens.overhanguppen"), cPen.PenTypeEnum.OverhangUpPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.UpTriangle, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenOverhangUpPen
            End Get
        End Property

        Public ReadOnly Property PresumedOverhangUpPen() As cPen
            Get
                If oPenPresumedOverhangUpPen Is Nothing Then
                    oPenPresumedOverhangUpPen = New cPen(oSurvey, GetLocalizedString("pens.presumedoverhanguppen"), cPen.PenTypeEnum.PresumedOverhangUpPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.UpTriangle, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenPresumedOverhangUpPen
            End Get
        End Property

        Public ReadOnly Property OverhangDownPen() As cPen
            Get
                If oPenOverhangDownPen Is Nothing Then
                    oPenOverhangDownPen = New cPen(oSurvey, GetLocalizedString("pens.overhangdownpen"), cPen.PenTypeEnum.OverhangDownPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.DownTriangle, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenOverhangDownPen
            End Get
        End Property

        Public ReadOnly Property PresumedOverhangDownPen() As cPen
            Get
                If oPenPresumedOverhangDownPen Is Nothing Then
                    oPenPresumedOverhangDownPen = New cPen(oSurvey, GetLocalizedString("pens.presumedoverhangdownpen"), cPen.PenTypeEnum.PresumedOverhangDownPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.DownTriangle, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenPresumedOverhangDownPen
            End Get
        End Property

        Public ReadOnly Property MeanderPen() As cPen
            Get
                If oPenMeanderPen Is Nothing Then
                    oPenMeanderPen = New cPen(oSurvey, GetLocalizedString("pens.meanderpen"), cPen.PenTypeEnum.MeanderPen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenMeanderPen
            End Get
        End Property

        Public ReadOnly Property PresumedMeanderPen() As cPen
            Get
                If oPenPresumedMeanderPen Is Nothing Then
                    oPenPresumedMeanderPen = New cPen(oSurvey, GetLocalizedString("pens.presumedmeanderpen"), cPen.PenTypeEnum.PresumedMeanderPen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenPresumedMeanderPen
            End Get
        End Property

        Public ReadOnly Property IcePen() As cPen
            Get
                If oPenIcePen Is Nothing Then
                    oPenIcePen = New cPen(oSurvey, GetLocalizedString("pens.icepen"), cPen.PenTypeEnum.IcePen, Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Ice, 1000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenIcePen
            End Get
        End Property

        Public ReadOnly Property PresumedIcePen() As cPen
            Get
                If oPenPresumedIcePen Is Nothing Then
                    oPenPresumedIcePen = New cPen(oSurvey, GetLocalizedString("pens.presumedicepen"), cPen.PenTypeEnum.PresumedIcePen, Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Ice, 1000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenPresumedIcePen
            End Get
        End Property

        Public Function FromType(ByVal Type As cPen.PenTypeEnum) As cPen
            Select Case Type
                Case cPen.PenTypeEnum.None
                    Return None
                Case cPen.PenTypeEnum.GenericPen
                    Return GenericPen

                Case cPen.PenTypeEnum.CavePen
                    Return CavePen
                Case cPen.PenTypeEnum.PresumedCavePen
                    Return PresumedCavePen
                Case cPen.PenTypeEnum.TooNarrowCavePen
                    Return TooNarrowCavePen
                Case cPen.PenTypeEnum.UnderlyingCavePen
                    Return UnderlyingCavePen

                Case cPen.PenTypeEnum.Pen
                    Return Pen
                Case cPen.PenTypeEnum.PresumedPen
                    Return PresumedPen

                Case cPen.PenTypeEnum.CliffUpPen
                    Return CliffUpPen
                Case cPen.PenTypeEnum.PresumedCliffUpPen
                    Return PresumedCliffUpPen

                Case cPen.PenTypeEnum.CliffDownPen
                    Return CliffDownPen
                Case cPen.PenTypeEnum.PresumedCliffDownPen
                    Return PresumedCliffDownPen

                Case cPen.PenTypeEnum.GradientDownPen
                    Return GradientDownPen
                Case cPen.PenTypeEnum.PresumedGradientDownPen
                    Return PresumedGradientDownPen

                Case cPen.PenTypeEnum.GradientUpPen
                    Return GradientUpPen
                Case cPen.PenTypeEnum.PresumedGradientUpPen
                    Return PresumedGradientUpPen

                Case cPen.PenTypeEnum.TightPen
                    Return TightPen
                Case cPen.PenTypeEnum.PresumedTightPen
                    Return PresumedTightPen

                Case cPen.PenTypeEnum.OverhangUpPen
                    Return OverhangUpPen
                Case cPen.PenTypeEnum.PresumedOverhangUpPen
                    Return PresumedOverhangUpPen

                Case cPen.PenTypeEnum.OverhangDownPen
                    Return OverhangDownPen
                Case cPen.PenTypeEnum.PresumedOverhangDownPen
                    Return PresumedOverhangDownPen

                Case cPen.PenTypeEnum.MeanderPen
                    Return MeanderPen
                Case cPen.PenTypeEnum.PresumedMeanderPen
                    Return PresumedMeanderPen

                Case cPen.PenTypeEnum.IcePen
                    Return IcePen
                Case cPen.PenTypeEnum.PresumedIcePen
                    Return PresumedIcePen

                Case Else
                    'inutile...?!?
                    Return New cPen(oSurvey)
            End Select
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
        End Sub

    End Class
End Namespace