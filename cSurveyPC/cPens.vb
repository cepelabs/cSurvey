﻿Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.ObjectModel
Imports System.IO

Namespace cSurvey.Design
    Public Class cPens
        Implements IEnumerable

        Public Event OnChanged(sender As Object, e As EventArgs)

        Private WithEvents oSurvey As cSurvey

        Private oPenNone As cCustomPen
        Private oPenGenericPen As cCustomPen
        Private oPenPresumedGenericPen As cCustomPen
        Private oPenCavePen As cCustomPen
        Private oPenPresumedCavePen As cCustomPen
        Private oPenTooNarrowCavePen As cCustomPen
        Private oPenUnderlyingCavePen As cCustomPen
        Private oPenPen As cCustomPen
        Private oPenPresumedPen As cCustomPen
        Private oPenTightPen As cCustomPen
        Private oPenPresumedTightPen As cCustomPen
        Private oPenGradientUpPen As cCustomPen
        Private oPenPresumedGradientUpPen As cCustomPen
        Private oPenGradientDownPen As cCustomPen
        Private oPenPresumedGradientDownPen As cCustomPen
        Private oPenCliffUpPen As cCustomPen
        Private oPenPresumedCliffUpPen As cCustomPen
        Private oPenCliffDownPen As cCustomPen
        Private oPenPresumedCliffDownPen As cCustomPen
        Private oPenOverhangUpPen As cCustomPen
        Private oPenPresumedOverhangUpPen As cCustomPen
        Private oPenOverhangDownPen As cCustomPen
        Private oPenPresumedOverhangDownPen As cCustomPen
        Private oPenMeanderPen As cCustomPen
        Private oPenPresumedMeanderPen As cCustomPen
        Private oPenIcePen As cCustomPen
        Private oPenPresumedIcePen As cCustomPen

        Private oPenGenericFault As cCustomPen
        Private oPenGenericPresumedFault As cCustomPen
        Private oPenNormalFault As cCustomPen
        Private oPenReverseFault As cCustomPen
        Private oPenVerticalFault As cCustomPen
        Private oPenStrikeFaultDx As cCustomPen
        Private oPenStrikeFaultSx As cCustomPen
        Private oPenStrikeFaultUnknown As cCustomPen
        Private oPenThrustTectonics As cCustomPen
        Private oPenAnticline As cCustomPen
        Private oPenSyncline As cCustomPen

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property SynclinePen() As cCustomPen
            Get
                If oPenSyncline Is Nothing Then
                    oPenSyncline = New cCustomPen(oSurvey, cPen.PenTypeEnum.SynclinePen, "", GetLocalizedString("pens.syncline"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.DownUpTriangle, 667, cPen.DecorationAlignmentEnum.Center, 0.5)
                    oPenSyncline.ClipartPenMode = cPen.ClipartPenModeEnum.Custom
                    oPenSyncline.ClipartPenStyle = cPen.PenStylesEnum.None
                End If
                Return oPenSyncline
            End Get
        End Property

        Public ReadOnly Property AnticlinePen() As cCustomPen
            Get
                If oPenAnticline Is Nothing Then
                    oPenAnticline = New cCustomPen(oSurvey, cPen.PenTypeEnum.AnticlinePen, "", GetLocalizedString("pens.anticline"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.UpDownTriangle, 667, cPen.DecorationAlignmentEnum.Center, 0.5)
                    oPenAnticline.ClipartPenMode = cPen.ClipartPenModeEnum.Custom
                    oPenAnticline.ClipartPenStyle = cPen.PenStylesEnum.None
                End If
                Return oPenAnticline
            End Get
        End Property

        Public ReadOnly Property GenericFaultPen() As cCustomPen
            Get
                If oPenGenericFault Is Nothing Then
                    oPenGenericFault = New cCustomPen(oSurvey, cPen.PenTypeEnum.GenericFaultPen, "", GetLocalizedString("pens.genericfaultpen"), Color.Red, 0)
                    oPenGenericFault.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenGenericFault.LineCap = cPen.PenLineCapEnum.Flat
                End If
                Return oPenGenericFault
            End Get
        End Property

        Public ReadOnly Property GenericPresumedFaultPen() As cCustomPen
            Get
                If oPenGenericPresumedFault Is Nothing Then
                    oPenGenericPresumedFault = New cCustomPen(oSurvey, cPen.PenTypeEnum.GenericPresumedFaultPen, "", GetLocalizedString("pens.genericpresumedfaultpen"), Color.Red, 0, cPen.PenStylesEnum.LargeDashSmallSpace)
                    oPenGenericPresumedFault.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenGenericPresumedFault.LineCap = cPen.PenLineCapEnum.Flat
                End If
                Return oPenGenericPresumedFault
            End Get
        End Property

        Public ReadOnly Property ReverseFaultPen() As cCustomPen
            Get
                If oPenReverseFault Is Nothing Then
                    oPenReverseFault = New cCustomPen(oSurvey, cPen.PenTypeEnum.ReverseFaultpen, "", GetLocalizedString("pens.reversefaultpen"), Color.Red, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 20000, cPen.DecorationAlignmentEnum.Outer, 2.5)
                    oPenReverseFault.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenReverseFault.LineCap = cPen.PenLineCapEnum.Flat
                    oPenReverseFault.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenReverseFault.ClipartPenLineCap = cPen.PenLineCapEnum.Flat
                    oPenReverseFault.ClipartPenMode = cPen.ClipartPenModeEnum.Custom
                    oPenReverseFault.ClipartPenWidth = 0
                    oPenReverseFault.ClipartPenColor = Color.Red
                End If
                Return oPenReverseFault
            End Get
        End Property

        Public ReadOnly Property StrikeFaultSxPen() As cCustomPen
            Get
                If oPenStrikeFaultSx Is Nothing Then
                    oPenStrikeFaultSx = New cCustomPen(oSurvey, cPen.PenTypeEnum.StrikeFaultSxPen, "", GetLocalizedString("pens.strikefaultsxpen"), Color.Red, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.LeftHalfArrow, 2000, cPen.DecorationAlignmentEnum.Outer, 1)
                    oPenStrikeFaultSx.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenStrikeFaultSx.LineCap = cPen.PenLineCapEnum.Flat
                    oPenStrikeFaultSx.DecorationDistancePercentage = 150
                    oPenStrikeFaultSx.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenStrikeFaultSx.ClipartPenLineCap = cPen.PenLineCapEnum.Squared
                    oPenStrikeFaultSx.ClipartPenMode = cPen.ClipartPenModeEnum.Custom
                    oPenStrikeFaultSx.ClipartPenWidth = 0
                    oPenStrikeFaultSx.ClipartPenColor = Color.Red
                    oPenStrikeFaultSx.ClipartBrushMode = cPen.ClipartBrushModeEnum.Custom
                    oPenStrikeFaultSx.ClipartBrushStyle = cPen.BrushStylesEnum.None
                End If
                Return oPenStrikeFaultSx
            End Get
        End Property

        Public ReadOnly Property StrikeFaultDxPen() As cCustomPen
            Get
                If oPenStrikeFaultDx Is Nothing Then
                    oPenStrikeFaultDx = New cCustomPen(oSurvey, cPen.PenTypeEnum.StrikeFaultDxPen, "", GetLocalizedString("pens.strikefaultdxpen"), Color.Red, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.RightHalfArrow, 2000, cPen.DecorationAlignmentEnum.Outer, 1)
                    oPenStrikeFaultDx.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenStrikeFaultDx.LineCap = cPen.PenLineCapEnum.Flat
                    oPenStrikeFaultDx.DecorationDistancePercentage = 150
                    oPenStrikeFaultDx.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenStrikeFaultDx.ClipartPenLineCap = cPen.PenLineCapEnum.Squared
                    oPenStrikeFaultDx.ClipartPenMode = cPen.ClipartPenModeEnum.Custom
                    oPenStrikeFaultDx.ClipartPenWidth = 0
                    oPenStrikeFaultDx.ClipartPenColor = Color.Red
                    oPenStrikeFaultDx.ClipartBrushMode = cPen.ClipartBrushModeEnum.Custom
                    oPenStrikeFaultDx.ClipartBrushStyle = cPen.BrushStylesEnum.None
                End If
                Return oPenStrikeFaultDx
            End Get
        End Property

        Public ReadOnly Property StrikeFaultUnknownPen() As cCustomPen
            Get
                If oPenStrikeFaultUnknown Is Nothing Then
                    oPenStrikeFaultUnknown = New cCustomPen(oSurvey, cPen.PenTypeEnum.StrikeFaultUnknownPen, "", GetLocalizedString("pens.strikefaultunknownpen"), Color.Red, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.DoubleHalfArrow, 2000, cPen.DecorationAlignmentEnum.Outer, 1)
                    oPenStrikeFaultUnknown.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenStrikeFaultUnknown.LineCap = cPen.PenLineCapEnum.Flat
                    oPenStrikeFaultUnknown.DecorationDistancePercentage = 150
                    oPenStrikeFaultUnknown.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenStrikeFaultUnknown.ClipartPenLineCap = cPen.PenLineCapEnum.Squared
                    oPenStrikeFaultUnknown.ClipartPenMode = cPen.ClipartPenModeEnum.Custom
                    oPenStrikeFaultUnknown.ClipartPenWidth = 0
                    oPenStrikeFaultUnknown.ClipartPenColor = Color.Red
                    oPenStrikeFaultUnknown.ClipartBrushMode = cPen.ClipartBrushModeEnum.Custom
                    oPenStrikeFaultUnknown.ClipartBrushStyle = cPen.BrushStylesEnum.None
                End If
                Return oPenStrikeFaultUnknown
            End Get
        End Property

        Public ReadOnly Property NormalFaultPen() As cCustomPen
            Get
                If oPenNormalFault Is Nothing Then
                    oPenNormalFault = New cCustomPen(oSurvey, cPen.PenTypeEnum.NormalFaultPen, "", GetLocalizedString("pens.normalfaultpen"), Color.Red, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 10000, cPen.DecorationAlignmentEnum.Outer, 2.5)
                    oPenNormalFault.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenNormalFault.LineCap = cPen.PenLineCapEnum.Flat
                End If
                Return oPenNormalFault
            End Get
        End Property

        Public ReadOnly Property VerticalFaultPen() As cCustomPen
            Get
                If oPenVerticalFault Is Nothing Then
                    oPenVerticalFault = New cCustomPen(oSurvey, cPen.PenTypeEnum.VerticalFaultPen, "", GetLocalizedString("pens.verticalfaultpen"), Color.Red, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 10000, cPen.DecorationAlignmentEnum.Center, 2.5)
                    oPenVerticalFault.LineJoin = cPen.PenLineJoinEnum.Mitered
                    oPenVerticalFault.LineCap = cPen.PenLineCapEnum.Flat
                End If
                Return oPenVerticalFault
            End Get
        End Property

        Public ReadOnly Property None() As cCustomPen
            Get
                If oPenNone Is Nothing Then
                    oPenNone = New cCustomPen(oSurvey, cPen.PenTypeEnum.None, "", GetLocalizedString("pens.none"), Color.Transparent, 0)
                End If
                Return oPenNone
            End Get
        End Property

        Public ReadOnly Property GenericPen() As cCustomPen
            Get
                If oPenGenericPen Is Nothing Then
                    oPenGenericPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.GenericPen, "", GetLocalizedString("pens.genericpen"), Color.Black, 0)
                End If
                Return oPenGenericPen
            End Get
        End Property

        Public ReadOnly Property PresumedGenericPen() As cCustomPen
            Get
                If oPenPresumedGenericPen Is Nothing Then
                    oPenPresumedGenericPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedGenericPen, "", GetLocalizedString("pens.presumedgenericpen"), Color.Black, 0, cPen.PenStylesEnum.Dash)
                End If
                Return oPenPresumedGenericPen
            End Get
        End Property

        Public ReadOnly Property CavePen() As cCustomPen
            Get
                If oPenCavePen Is Nothing Then
                    oPenCavePen = New cCustomPen(oSurvey, cPen.PenTypeEnum.CavePen, "", GetLocalizedString("pens.cavepen"), Color.Black, 0)
                End If
                Return oPenCavePen
            End Get
        End Property

        Public ReadOnly Property UnderlyingCavePen() As cCustomPen
            Get
                If oPenUnderlyingCavePen Is Nothing Then
                    oPenUnderlyingCavePen = New cCustomPen(oSurvey, cPen.PenTypeEnum.UnderlyingCavePen, "", GetLocalizedString("pens.underlyingcavepen"), Color.Black, 0, cPen.PenStylesEnum.LargeDashLargeSpace)
                End If
                Return oPenUnderlyingCavePen
            End Get
        End Property

        Public ReadOnly Property TooNarrowCavePen() As cCustomPen
            Get
                If oPenTooNarrowCavePen Is Nothing Then
                    oPenTooNarrowCavePen = New cCustomPen(oSurvey, cPen.PenTypeEnum.TooNarrowCavePen, "", GetLocalizedString("pens.toonarrowcavepen"), Color.Black, 0, cPen.PenStylesEnum.LargeDashMediumSpace)
                End If
                Return oPenTooNarrowCavePen
            End Get
        End Property

        Public ReadOnly Property PresumedCavePen() As cCustomPen
            Get
                If oPenPresumedCavePen Is Nothing Then
                    oPenPresumedCavePen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedCavePen, "", GetLocalizedString("pens.presumedcavepen"), Color.Black, 0, cPen.PenStylesEnum.LargeDashSmallSpace)
                End If
                Return oPenPresumedCavePen
            End Get
        End Property

        Public ReadOnly Property Pen() As cCustomPen
            Get
                If oPenPen Is Nothing Then
                    oPenPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.Pen, "", GetLocalizedString("pens.pen"), Color.Black, 0)
                End If
                Return oPenPen
            End Get
        End Property

        Public ReadOnly Property PresumedPen() As cCustomPen
            Get
                If oPenPresumedPen Is Nothing Then
                    oPenPresumedPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedPen, "", GetLocalizedString("pens.presumedpen"), Color.Black, 0, cPen.PenStylesEnum.Dash)
                End If
                Return oPenPresumedPen
            End Get
        End Property

        Public Function FromCustom(ByVal Color As Color, Optional ByVal Name As String = "", Optional ByVal Width As Integer = 0.1, Optional ByVal Style As cPen.PenStylesEnum = cPen.PenStylesEnum.Solid, Optional Clipart As Drawings.cDrawClipArt = Nothing, Optional ByVal DecorationStyle As cPen.DecorationStylesEnum = cPen.DecorationStylesEnum.None, Optional ByVal DecorationSpacePercentage As Single = 0, Optional ByVal DecorationAlignment As cPen.DecorationAlignmentEnum = cPen.DecorationStylesEnum.None) As cCustomPen
            Dim oPen As cCustomPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.Custom, "", Name, Color, Width, Style, Clipart, DecorationStyle, DecorationSpacePercentage, DecorationAlignment)
            Return oPen
        End Function

        Public ReadOnly Property TightPen() As cCustomPen
            Get
                If oPenTightPen Is Nothing Then
                    oPenTightPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.TightPen, "", GetLocalizedString("pens.tightpen"), Color.Black, 0, cPen.PenStylesEnum.Solid)
                End If
                Return oPenTightPen
            End Get
        End Property

        Public ReadOnly Property PresumedTightPen() As cCustomPen
            Get
                If oPenPresumedTightPen Is Nothing Then
                    oPenPresumedTightPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedTightPen, "", GetLocalizedString("pens.presumedtightpen"), Color.Black, 0, cPen.PenStylesEnum.Dash)
                End If
                Return oPenPresumedTightPen
            End Get
        End Property

        Public ReadOnly Property GradientUpPen() As cCustomPen
            Get
                If oPenGradientUpPen Is Nothing Then
                    oPenGradientUpPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.GradientUpPen, "", GetLocalizedString("pens.gradientuppen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.UpArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenGradientUpPen
            End Get
        End Property

        Public ReadOnly Property PresumedGradientUpPen() As cCustomPen
            Get
                If oPenPresumedGradientUpPen Is Nothing Then
                    oPenPresumedGradientUpPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedGradientUpPen, "", GetLocalizedString("pens.presumedgradientuppen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.UpArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenPresumedGradientUpPen
            End Get
        End Property

        Public ReadOnly Property GradientDownPen() As cCustomPen
            Get
                If oPenGradientDownPen Is Nothing Then
                    oPenGradientDownPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.GradientDownPen, "", GetLocalizedString("pens.gradientdownpen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.DownArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenGradientDownPen
            End Get
        End Property

        Public ReadOnly Property PresumedGradientDownPen() As cCustomPen
            Get
                If oPenPresumedGradientDownPen Is Nothing Then
                    oPenPresumedGradientDownPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedGradientDownPen, "", GetLocalizedString("pens.presumedgradientdownpen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.DownArrow, 5000, cPen.DecorationAlignmentEnum.Center, 1)
                End If
                Return oPenPresumedGradientDownPen
            End Get
        End Property

        Public ReadOnly Property CliffUpPen() As cCustomPen
            Get
                If oPenCliffUpPen Is Nothing Then
                    oPenCliffUpPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.CliffUpPen, "", GetLocalizedString("pens.cliffuppen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenCliffUpPen
            End Get
        End Property

        Public ReadOnly Property PresumedCliffUpPen() As cCustomPen
            Get
                If oPenPresumedCliffUpPen Is Nothing Then
                    oPenPresumedCliffUpPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedCliffUpPen, "", GetLocalizedString("pens.presumedcliffuppen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenPresumedCliffUpPen
            End Get
        End Property

        Public ReadOnly Property CliffDownPen() As cCustomPen
            Get
                If oPenCliffDownPen Is Nothing Then
                    oPenCliffDownPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.CliffDownPen, "", GetLocalizedString("pens.cliffdownpen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenCliffDownPen
            End Get
        End Property

        Public ReadOnly Property PresumedCliffDownPen() As cCustomPen
            Get
                If oPenPresumedCliffDownPen Is Nothing Then
                    oPenPresumedCliffDownPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedCliffDownPen, "", GetLocalizedString("pens.presumedcliffdownpen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenPresumedCliffDownPen
            End Get
        End Property

        Public ReadOnly Property OverhangUpPen() As cCustomPen
            Get
                If oPenOverhangUpPen Is Nothing Then
                    oPenOverhangUpPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.OverhangUpPen, "", GetLocalizedString("pens.overhanguppen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.UpTriangle, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenOverhangUpPen
            End Get
        End Property

        Public ReadOnly Property PresumedOverhangUpPen() As cCustomPen
            Get
                If oPenPresumedOverhangUpPen Is Nothing Then
                    oPenPresumedOverhangUpPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedOverhangUpPen, "", GetLocalizedString("pens.presumedoverhanguppen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.UpTriangle, 3000, cPen.DecorationAlignmentEnum.Outer, 1)
                End If
                Return oPenPresumedOverhangUpPen
            End Get
        End Property

        Public ReadOnly Property OverhangDownPen() As cCustomPen
            Get
                If oPenOverhangDownPen Is Nothing Then
                    oPenOverhangDownPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.OverhangDownPen, "", GetLocalizedString("pens.overhangdownpen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.DownTriangle, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenOverhangDownPen
            End Get
        End Property

        Public ReadOnly Property PresumedOverhangDownPen() As cCustomPen
            Get
                If oPenPresumedOverhangDownPen Is Nothing Then
                    oPenPresumedOverhangDownPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedOverhangDownPen, "", GetLocalizedString("pens.presumedoverhangdownpen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.DownTriangle, 3000, cPen.DecorationAlignmentEnum.Inner, 1)
                End If
                Return oPenPresumedOverhangDownPen
            End Get
        End Property

        Public ReadOnly Property MeanderPen() As cCustomPen
            Get
                If oPenMeanderPen Is Nothing Then
                    oPenMeanderPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.MeanderPen, "", GetLocalizedString("pens.meanderpen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenMeanderPen
            End Get
        End Property

        Public ReadOnly Property PresumedMeanderPen() As cCustomPen
            Get
                If oPenPresumedMeanderPen Is Nothing Then
                    oPenPresumedMeanderPen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedMeanderPen, "", GetLocalizedString("pens.presumedmeanderpen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Dash, 3000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenPresumedMeanderPen
            End Get
        End Property

        Public ReadOnly Property IcePen() As cCustomPen
            Get
                If oPenIcePen Is Nothing Then
                    oPenIcePen = New cCustomPen(oSurvey, cPen.PenTypeEnum.IcePen, "", GetLocalizedString("pens.icepen"), Color.Black, 0, cPen.PenStylesEnum.Solid, Nothing, cPen.DecorationStylesEnum.Ice, 1000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenIcePen
            End Get
        End Property

        Public ReadOnly Property PresumedIcePen() As cCustomPen
            Get
                If oPenPresumedIcePen Is Nothing Then
                    oPenPresumedIcePen = New cCustomPen(oSurvey, cPen.PenTypeEnum.PresumedIcePen, "", GetLocalizedString("pens.presumedicepen"), Color.Black, 0, cPen.PenStylesEnum.Dash, Nothing, cPen.DecorationStylesEnum.Ice, 1000, cPen.DecorationAlignmentEnum.Center, 2)
                End If
                Return oPenPresumedIcePen
            End Get
        End Property

        Public Function FromType(ByVal Type As cPen.PenTypeEnum) As cCustomPen
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

                Case cPen.PenTypeEnum.PresumedGenericPen
                    Return PresumedGenericPen
                Case cPen.PenTypeEnum.PresumedTightPen
                    Return PresumedTightPen

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

                Case cPen.PenTypeEnum.GenericFaultPen
                    Return GenericFaultPen
                Case cPen.PenTypeEnum.GenericPresumedFaultPen
                    Return GenericPresumedFaultPen
                Case cPen.PenTypeEnum.NormalFaultPen
                    Return NormalFaultPen
                Case cPen.PenTypeEnum.ReverseFaultpen
                    Return ReverseFaultPen
                Case cPen.PenTypeEnum.VerticalFaultPen
                    Return VerticalFaultPen
                Case cPen.PenTypeEnum.StrikeFaultSxPen
                    Return StrikeFaultSxPen
                Case cPen.PenTypeEnum.StrikeFaultDxPen
                    Return StrikeFaultDxPen
                Case cPen.PenTypeEnum.StrikeFaultUnknownPen
                    Return StrikeFaultUnknownPen

                Case cPen.PenTypeEnum.SynclinePen
                    Return SynclinePen
                Case cPen.PenTypeEnum.AnticlinePen
                    Return AnticlinePen

                Case Else
                    'is usefull?
                    Return New cCustomPen(oSurvey)
            End Select
        End Function

        Public Function FromName(ByVal Name As String) As cCustomPen
            If Name Is Nothing Then
                Return Nothing
            Else
                Dim oFindItem As cCustomPen = oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Name.ToLower)
                Return oFindItem
            End If
        End Function

        ''' <summary>
        ''' Get custom pen by id searching in standard pens and in users pen
        ''' </summary>
        ''' <param name="ID">Pen ID to be retrieved</param>
        ''' <returns></returns>
        Public Function FromID(ByVal ID As String) As cCustomPen
            If ID Is Nothing Then
                Return Nothing
            Else
                If ID.StartsWith("_") Then
                    Dim iType As cPen.PenTypeEnum = Integer.Parse(ID.Substring(1))
                    Return FromType(iType)
                Else
                    Dim oFindItem As cCustomPen = oItems.FirstOrDefault(Function(oItem) oItem.ID = ID)
                    If oFindItem IsNot Nothing Then
                        Return oFindItem
                    Else
                        Return Nothing
                    End If
                End If
            End If
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cCustomPen)
        End Sub

        Private oItems As List(Of cCustomPen)

        Default Public ReadOnly Property Item(Index As Integer) As cCustomPen
            Get
                Return oItems(Index)
            End Get
        End Property

        Default Public ReadOnly Property Item(ID As String) As cCustomPen
            Get
                Return oItems.FirstOrDefault(Function(oItem) oItem.ID = ID)
            End Get
        End Property

        Friend Function Add(CustomPen As cCustomPen) As Boolean
            If CustomPen.Type = cPen.PenTypeEnum.User Then
                Dim oExistingPen As cCustomPen = oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = CustomPen.Name.ToLower)
                If oExistingPen IsNot Nothing Then
                    oExistingPen.CopyFrom(CustomPen)
                    CustomPen.ID = oExistingPen.ID
                    Return True
                Else
                    If Not ContainsID(CustomPen.ID) Then
                        Call oItems.Add(CustomPen)
                        RaiseEvent OnChanged(Me, EventArgs.Empty)
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End Function

        Public Function Add(Pen As cPen, Name As String) As cCustomPen
            If Pen.Type = cPen.PenTypeEnum.Custom Then
                Dim oCustomPen As cCustomPen = Pen.GetBasePen
                If oCustomPen.Name IsNot Nothing Then oCustomPen.Name = Name

                Dim oExistingPen1 As cCustomPen = oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Name.ToLower)
                If oExistingPen1 IsNot Nothing Then
                    oExistingPen1.CopyFrom(oCustomPen)
                    Pen.ID = oExistingPen1.ID
                    Return oExistingPen1
                Else
                    Dim oNewPen As cCustomPen = cCustomPen.CopyAsUser(oSurvey, oCustomPen)
                    Dim oExistingPen2 As cCustomPen = oItems.FirstOrDefault(Function(oItem) oItem.ID = oNewPen.ID)
                    If oExistingPen2 IsNot Nothing Then
                        oExistingPen2.CopyFrom(oNewPen)
                        Pen.ID = oExistingPen2.ID
                        Return oExistingPen2
                    Else
                        Call oItems.Add(oNewPen)
                        RaiseEvent OnChanged(Me, EventArgs.Empty)
                        Return oNewPen
                    End If
                End If
            End If
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Pens As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cCustomPen)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Pens.ChildNodes.Count
            For Each oXMLPen As XmlElement In Pens.ChildNodes
                iIndex += 1
                Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("pens.load"), iIndex / iCount)
                Dim oItem As cCustomPen = New cCustomPen(oSurvey, oXMLPen)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXMLPens As XmlElement = Document.CreateElement("pens")
            For Each oItem As cCustomPen In oItems
                Call oItem.SaveTo(File, Document, oXMLPens)
            Next
            Call Parent.AppendChild(oXMLPens)
            Return oXMLPens
        End Function

        Friend Sub CleanUp()
            'TODO
        End Sub

        Friend Function Delete(ID As String) As Boolean
            If ContainsID(ID) Then
                Dim oCustomPen As cCustomPen = Item(ID)
                oItems.Remove(oCustomPen)
                RaiseEvent OnChanged(Me, EventArgs.Empty)
                Return True
            Else
                Return False
            End If
        End Function

        Friend Function Delete(Pen As cPen) As Boolean
            If Pen.Type = cPen.PenTypeEnum.User Then
                Dim oCustomPen As cCustomPen = Pen.GetBasePen
                If oItems.Contains(oCustomPen) Then
                    oItems.Remove(oCustomPen)
                    RaiseEvent OnChanged(Me, EventArgs.Empty)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function

        Public Function ContainsName(Name As String) As Boolean
            Return oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Name.ToLower) IsNot Nothing
        End Function

        Public Function ContainsID(ID As String) As Boolean
            Return oItems.FirstOrDefault(Function(oItem) oItem.ID = ID) IsNot Nothing
        End Function

        Public Function Contains(IDorName As String) As Boolean
            If ContainsID(IDorName) Then
                Return True
            Else
                Return ContainsName(IDorName)
            End If
        End Function

        Public Function Contains(Pen As cPen) As Boolean
            Return Contains(Pen.GetBasePen)
        End Function

        Public Function Contains(Pen As cCustomPen) As Boolean
            Dim oPen As cCustomPen
            If Pen.Type = cPen.PenTypeEnum.User Then
                oPen = Pen
            Else
                oPen = cCustomPen.CopyAsUser(oSurvey, Pen)
            End If
            If ContainsID(oPen.ID) Then
                Return True
            Else
                Return ContainsName(oPen.Name)
            End If
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class

    Friend Class cPensBaseCollection
        Inherits KeyedCollection(Of String, cCustomPen)

        Public Sub Rebind()
            MyBase.Dictionary.Clear()
            For Each oitem As cCustomPen In MyBase.Items
                MyBase.Dictionary.Add(oitem.ID, oitem)
            Next
        End Sub

        Protected Overrides Function GetKeyForItem(ByVal item As cCustomPen) As String
            Return item.ID
        End Function
    End Class
End Namespace