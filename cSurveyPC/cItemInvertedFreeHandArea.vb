Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemInvertedFreeHandArea
        Inherits cItem
        Implements cIItemLine
        Implements cIItemMergeableArea

        Private iLineType As cIItemLine.LineTypeEnum
        Private iMergeMode As cIItemMergeableArea.MergeModeEnum

        Public Overrides ReadOnly Property CanBeHiddenInDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeHiddenInPreview As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeLocked As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeSendedToOtherDesign As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDeleted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub ReducePoints(Optional ByVal Factor As Single = 0.1) Implements cIItemLine.ReducePoints
            If MyBase.Points.Count > 2 Then
                Call modPaint.ReducePoints(MyBase.Points, Factor, iLineType)
            End If
        End Sub

        Public Overrides ReadOnly Property CanBeWarped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeMoved As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveCrossSection As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSplayBorder As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.AllPoints
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property HaveBrush As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HavePen As Boolean
            Get
                Return True
            End Get
        End Property

        Friend Overrides Sub Render(ByVal Graphics As System.Drawing.Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            Dim oCache As cDrawCache = MyBase.Caches(PaintOptions)
            With oCache
                If .Invalidated OrElse MyBase.HavePaintProblem Then
                    Call .Clear()
                    If MyBase.Points.Count > 1 Then
                        For Each oSequence As cSequence In MyBase.Points.GetSequences()
                            Using oPath As GraphicsPath = New GraphicsPath
                                If SequenceToPath(oSequence, iLineType, oPath) Then
                                    Call oSequence.GetPen(MyBase.Pen).Render(Graphics, PaintOptions, Options, Selected, oPath, oCache)
                                End If
                            End Using
                        Next
                    End If
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 1 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign AndAlso Not MyBase.HiddenInDesign) Then
                    MyBase.HavePaintProblem = Not MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options Or PaintOptionsEnum.IgnoreMaxDrawItemCount)
                    If PaintOptions.ShowSegmentBindings Then
                        Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                    End If
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.InvertedFreeHandArea, Category)
            iLineType = GetDefaultLineType(Survey, Category)
            AddHandler MyBase.Points.OnGetLineType, AddressOf oPoints_OnGetLineType
        End Sub

        Private Sub oPoints_OnGetLineType(sender As cPoints, ByRef LineType As Items.cIItemLine.LineTypeEnum)
            LineType = iLineType
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            iLineType = modXML.GetAttributeValue(item, "linetype", cIItemLine.LineTypeEnum.Undefined)
            iMergeMode = modXML.GetAttributeValue(item, "mergemode", cIItemMergeableArea.MergeModeEnum.Add)
            AddHandler MyBase.Points.OnGetLineType, AddressOf oPoints_OnGetLineType
        End Sub

        Public Property LineType() As cIItemLine.LineTypeEnum Implements cIItemLine.LineType
            Get
                Return iLineType
            End Get
            Set(ByVal value As cIItemLine.LineTypeEnum)
                If iLineType <> value Then
                    iLineType = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return Integer.MaxValue
            End Get
        End Property

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.SetAttribute("linetype", iLineType.ToString("D"))
            Call oItem.SetAttribute("mergemode", iMergeMode.ToString("D"))
            Return oItem
        End Function

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Call MyBase.Points.BeginUpdate()
            If Clear Then
                Call MyBase.Points.Clear()
            End If
            iLineType = Item.LineType
            For Each oPoint As cPoint In Item.Points
                Call MyBase.Points.Add(oPoint.Clone)
            Next
            Call MyBase.Points.EndUpdate()
            Return True
        End Function

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return True
            End Get
        End Property

        Public Property MergeMode As cIItemMergeableArea.MergeModeEnum Implements cIItemMergeableArea.MergeMode
            Get
                Return iMergeMode
            End Get
            Set(ByVal value As cIItemMergeableArea.MergeModeEnum)
                If iMergeMode <> value Then
                    iMergeMode = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

    End Class
End Namespace
