﻿Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public MustInherit Class cItem
        Implements cIItem

        Private Const dMaxSize As Single = 20000

        Public Enum cItemClippingTypeEnum As Integer
            [Default] = 0
            [None] = 1
            [InsideBorder] = 2
            [OutsideBorder] = 3
        End Enum

        Public Enum PaintOptionsEnum As Integer
            None = &H0
            Solid = &H1
            Wireframe = &H2
            Simple = &H3
            ShowPointToSegmentBindings = &H10
            FullLayerDraw = &H0
            SchematicLayerDraw = &H100
            IgnoreMaxDrawItemCount = &H1000
        End Enum

        <Flags()> Public Enum SVGOptionsEnum As Integer
            None = &H0
            Clipping = &H1
            ClipartBrushes = &H10
            Silent = &H1000
        End Enum

        Public Enum BindModeEnum As Integer
            AllPoints = 0
            CenterPoint = 1
            None = 2
            Special = 3
        End Enum

        Public Enum BindDesignTypeEnum As Integer
            MainDesign = &H0
            CrossSections = &H1
        End Enum

        Private oSurvey As cSurvey
        Private oDesign As cDesign
        Private oLayer As cLayer

        Private iType As cIItem.cItemTypeEnum
        Private iCategory As cIItem.cItemCategoryEnum

        Private sName As String
        Private sCave As String
        Private sBranch As String
        Private iBindDesignType As BindDesignTypeEnum

        Private WithEvents oBrush As cBrush
        Private WithEvents oPen As cPen

        Private WithEvents oPoints As cPoints

        Private bLocked As Boolean

        Private bHiddenInDesign As Boolean
        Private bHiddenInPreview As Boolean
        Private bFilteredInDesign As Boolean

        Private iClippingType As cItemClippingTypeEnum

        Private bDeleted As Boolean

        Private WithEvents oCaches As cDrawCaches

        Private bhavepaintproblem As Boolean

        Friend Property HavePaintProblem As Boolean
            Get
                Return bhavepaintproblem
            End Get
            Set(value As Boolean)
                bhavepaintproblem = value
            End Set
        End Property

        Friend Overridable Sub SetDeleted()
            bDeleted = True
        End Sub

        Private sTransparency As Single

        Private oThumbnailImage As Dictionary(Of String, Image)

        Private oDataProperties As Data.cDataProperties

        Public ReadOnly Property DataProperties As Data.cDataProperties
            Get
                Return oDataProperties
            End Get
        End Property

        Public Overridable Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer) As Image
            Return GetThumbnailImage(PaintOptions, Options, Selected, thumbHeight, thumbHeight, Color.Black, Color.White)
        End Function

        Public Overridable Function GetThumbnailImage(ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As cItem.SelectionModeEnum, ByVal thumbWidth As Integer, ByVal thumbHeight As Integer, ByVal ForeColor As Color, ByVal Backcolor As Color) As Image
            If oThumbnailImage Is Nothing Then oThumbnailImage = New Dictionary(Of String, Image)
            Dim sThumbKey As String = thumbWidth & "x" & thumbHeight
            Try
                If Not oThumbnailImage.ContainsKey(sThumbKey) Then
                    Dim oBounds As RectangleF = New RectangleF(0, 0, thumbWidth, thumbHeight)
                    Dim oImage As Image = New Bitmap(thumbWidth, thumbHeight)
                    Dim oGr As Graphics = Graphics.FromImage(oImage)
                    oGr.SmoothingMode = SmoothingMode.AntiAlias
                    oGr.CompositingQuality = CompositingQuality.HighQuality
                    oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                    Call oGr.Clear(Backcolor)
                    Dim sScale As Single
                    Call Render(oGr, PaintOptions, PaintOptionsEnum.None, Selected)
                    Dim oCurrentBounds As RectangleF = GetBounds()
                    Dim sScaleX As Single = oBounds.Width / oCurrentBounds.Width
                    Dim sScaleY As Single = oBounds.Height / oCurrentBounds.Height
                    If sScaleX > sScaleY Then sScale = sScaleY Else sScale = sScaleX
                    sScale = sScale * 0.95
                    Call oGr.TranslateTransform(-oCurrentBounds.X, -oCurrentBounds.Y, MatrixOrder.Append)
                    Call oGr.ScaleTransform(sScale, sScale, MatrixOrder.Append)
                    Dim sTranslateX As Single = (thumbWidth - oCurrentBounds.Width * sScale) / 2
                    Dim sTranslateY As Single = (thumbHeight - oCurrentBounds.Height * sScale) / 2
                    Call oGr.TranslateTransform(sTranslateX, sTranslateY, MatrixOrder.Append)
                    Call Paint(oGr, PaintOptions, cItem.PaintOptionsEnum.None, Selected)
                    Call oGr.Dispose()
                    oThumbnailImage.Add(sThumbKey, oImage)
                    Return oImage
                Else
                    Return oThumbnailImage(sThumbKey)
                End If
            Catch
            End Try
        End Function

        Public Overridable Property Transparency As Single
            Get
                Return sTransparency
            End Get
            Set(value As Single)
                If sTransparency <> value Then
                    sTransparency = value
                    If HavePen Then oPen.Invalidate()
                    If HaveBrush Then oBrush.Invalidate()
                    Call oCaches.Invalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Deleted As Boolean Implements cIItem.delete
            Get
                Return bDeleted
            End Get
        End Property

        Public Overridable Property HiddenInDesign As Boolean Implements cIItem.HiddenInDesign
            Get
                Return bHiddenInDesign
            End Get
            Set(ByVal value As Boolean)
                If bHiddenInDesign <> value Then
                    bHiddenInDesign = value
                End If
            End Set
        End Property

        Public Overridable Property FilteredInDesign As Boolean
            Get
                Return bFilteredInDesign
            End Get
            Set(ByVal value As Boolean)
                bFilteredInDesign = value
            End Set
        End Property

        Public Overridable Property HiddenInPreview As Boolean Implements cIItem.HiddenInPreview
            Get
                Return bHiddenInPreview
            End Get
            Set(ByVal value As Boolean)
                If bHiddenInPreview <> value Then
                    bHiddenInPreview = value
                End If
            End Set
        End Property

        Public ReadOnly Property Type() As cIItem.cItemTypeEnum Implements cIItem.Type
            Get
                Return iType
            End Get
        End Property

        Public ReadOnly Property Category() As cIItem.cItemCategoryEnum Implements cIItem.Category
            Get
                Return iCategory
            End Get
        End Property

        Public Overridable Property Locked() As Boolean
            Get
                Return bLocked
            End Get
            Set(ByVal value As Boolean)
                bLocked = value
            End Set
        End Property

        Public Property Name() As String Implements cIItem.Name
            Get
                Return sName
            End Get
            Set(ByVal value As String)
                sName = value
            End Set
        End Property

        Public ReadOnly Property Location() As PointF
            Get
                Return GetBounds.Location
            End Get
        End Property

        Public ReadOnly Property Size() As SizeF
            Get
                Return GetBounds.Size
            End Get
        End Property

        Public ReadOnly Property Brush() As cBrush
            Get
                Return oBrush
            End Get
        End Property

        Public ReadOnly Property Pen() As cPen
            Get
                Return oPen
            End Get
        End Property

        Friend MustOverride Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
        Friend MustOverride Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument

        Public Overridable Function GetCenterPoint() As PointF
            Return modPaint.GetCenterPoint(GetBounds)
        End Function

        Public Overridable Function IsBindedTo(ByVal Segment As cISegment) As Boolean
            If CanBeBinded Then
                For Each oPoint As cPoint In oPoints
                    If oPoint.BindedSegment Is Segment Then
                        Return True
                    End If
                Next
            Else
                Return False
            End If
        End Function

        Public Enum SelectionModeEnum
            None = 0
            Selected = 1
            InEdit = 2
        End Enum

        Friend MustOverride Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
        Friend MustOverride Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)

        Friend Overridable Sub Invalidate(PaintOptions As cOptions)
            Call oCaches.Invalidate(PaintOptions)
        End Sub

        Public MustOverride ReadOnly Property CanBeBinded() As Boolean
        Public MustOverride ReadOnly Property BindMode() As BindModeEnum
        Public MustOverride ReadOnly Property CanBeCombined() As Boolean
        Public MustOverride ReadOnly Property CanBeDivided() As Boolean
        Public MustOverride ReadOnly Property CanBeDeleted() As Boolean
        Public MustOverride ReadOnly Property CanBeMoved() As Boolean
        Public MustOverride ReadOnly Property CanBeResized() As Boolean
        Public MustOverride ReadOnly Property CanBeRotated() As Boolean
        Public MustOverride ReadOnly Property CanBeClipped() As Boolean
        Public MustOverride ReadOnly Property CanBeConverted As Boolean
        Public MustOverride ReadOnly Property CanBeWarped() As Boolean
        Public MustOverride ReadOnly Property CanBeLocked() As Boolean
        Public MustOverride ReadOnly Property CanBeSendedToOtherDesign() As Boolean
        Public MustOverride ReadOnly Property CanBeHiddenInDesign() As Boolean
        Public MustOverride ReadOnly Property CanBeHiddenInPreview() As Boolean

        Public MustOverride ReadOnly Property CanImportGeneric As Boolean
        Public MustOverride Function FromGeneric(ByVal Item As Items.cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean

        Public MustOverride ReadOnly Property HavePen As Boolean
        Public MustOverride ReadOnly Property HaveBrush As Boolean
        Public MustOverride ReadOnly Property HaveTransparency As Boolean

        Public MustOverride ReadOnly Property HaveEditablePoints As Boolean
        Public MustOverride ReadOnly Property HaveLineType As Boolean
        Public MustOverride ReadOnly Property HaveFont As Boolean
        Public MustOverride ReadOnly Property HaveText As Boolean
        Public MustOverride ReadOnly Property HaveSign As Boolean
        Public MustOverride ReadOnly Property HaveImage As Boolean
        Public MustOverride ReadOnly Property HaveSketch As Boolean
        Public MustOverride ReadOnly Property HaveCrossSection As Boolean
        Public MustOverride ReadOnly Property HaveSplayBorder As Boolean
        Public MustOverride ReadOnly Property HaveQuota As Boolean

        Public MustOverride ReadOnly Property MaxPointsCount() As Integer

        Public Overridable Function GetBounds() As RectangleF
            If oPoints.Count = 0 Then
                Return New RectangleF
            Else
                If oPoints.Count < 2 Then
                    Dim oPoint As PointF = oPoints.GetPoints(0)
                    Return modPaint.GetRectanglefFomPoint(oPoint, 0.2)
                Else
                    Using oPath As GraphicsPath = New GraphicsPath
                        If oPoints.Count < 3 Then
                            Dim oLinePoints As PointF() = oPoints.GetPoints
                            Call oPath.AddLine(oLinePoints(0), oLinePoints(1))
                        Else
                            Call oPath.AddPolygon(oPoints.GetPoints)
                        End If
                        Return oPath.GetBounds()
                    End Using
                End If
            End If
        End Function

        Public Function IsInvalidated(PaintOptions As cOptions) As Boolean
            If oCaches.Contains(PaintOptions) Then
                Return oCaches(PaintOptions).Invalidated
            Else
                Return True
            End If
        End Function

        Friend Overridable Function HitTest(PaintOptions As cOptions, ByVal X As Single, ByVal Y As Single, ByVal Wide As Single) As Boolean
            Return HitTest(PaintOptions, New PointF(X, Y), Wide)
        End Function

        Friend Function IsVisible(PaintOptions As cOptions) As Boolean
            If PaintOptions.IsDesign Then
                Return Not bHiddenInDesign
            Else
                If bHiddenInPreview Then
                    Return False
                Else
                    Select Case iType
                        Case cIItem.cItemTypeEnum.Image
                            Return PaintOptions.DrawImages
                        Case cIItem.cItemTypeEnum.Sketch
                            Return PaintOptions.DrawSketches
                        Case Else
                            Return True
                    End Select
                End If
            End If
        End Function

        Friend Overridable Function HitTest(PaintOptions As cOptions, ByVal Point As PointF, ByVal Wide As Single) As Boolean
            If IsVisible(PaintOptions) Then
                Dim oRect As RectangleF = GetBounds()
                If oRect.Width < 0.1 Or oRect.Height < 0.1 Then
                    Dim sHeight As Single
                    Dim sWidth As Single
                    If oRect.Width < 0.1 Then sWidth = 0.1
                    If oRect.Height < 0.1 Then sHeight = 0.1
                    Call oRect.Inflate(sWidth, sHeight)
                End If
                Return oRect.Contains(Point)
            Else
                Return False
            End If
        End Function

        Friend ReadOnly Property Caches As cDrawCaches
            Get
                Return oCaches
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Type As cIItem.cItemTypeEnum, ByVal Category As cIItem.cItemCategoryEnum)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer

            sName = ""

            sCave = ""
            sBranch = ""
            iBindDesignType = BindDesignTypeEnum.MainDesign

            iType = Type
            iCategory = Category
            bLocked = False
            oPen = New cPen(oSurvey)
            oBrush = New cBrush(oSurvey)

            oPoints = New cPoints(oSurvey, Me)

            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems)

            oCaches = New cDrawCaches
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal Item As XmlElement)
            oSurvey = Survey
            oDesign = Design
            oLayer = Layer

            iType = modXML.GetAttributeValue(Item, "type")
            iCategory = modXML.GetAttributeValue(Item, "category")

            sName = modXML.GetAttributeValue(Item, "name", "")
            sCave = modXML.GetAttributeValue(Item, "cave", "")
            sBranch = modXML.GetAttributeValue(Item, "branch", "")
            iBindDesignType = modXML.GetAttributeValue(Item, "binddesigntype", BindDesignTypeEnum.MainDesign)

            bHiddenInDesign = modXML.GetAttributeValue(Item, "hiddenindesign")
            bHiddenInPreview = modXML.GetAttributeValue(Item, "hiddeninpreview")
            bLocked = modXML.GetAttributeValue(Item, "locked")

            iClippingType = modXML.GetAttributeValue(Item, "clippingtype")

            If HavePen Then
                Dim oXMLPen As XmlElement = Item.SelectSingleNode("pen")
                If oXMLPen Is Nothing Then
                    oPen = New cPen(oSurvey)
                Else
                    oPen = New cPen(oSurvey, oXMLPen)
                End If
            End If
            If HaveBrush Then
                Dim oXmlBrush As XmlElement = Item.SelectSingleNode("brush")
                If oXmlBrush Is Nothing Then
                    oBrush = New cBrush(oSurvey)
                Else
                    oBrush = New cBrush(oSurvey, File, oXmlBrush)
                End If
            End If
            If HaveTransparency Then
                sTransparency = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "transparency", 0))
                If sTransparency > 1 Then
                    sTransparency = sTransparency / 255
                    If sTransparency > 1 Then
                        sTransparency = 0
                    End If
                End If
            End If

            oPoints = New cPoints(oSurvey, Me, Item.Item("points"))

            If modXML.ChildElementExist(Item, "datarow") Then
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems, Item.Item("datarow"))
            Else
                oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems)
            End If

            oCaches = New cDrawCaches
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("item")
            Call oXmlItem.SetAttribute("layer", oLayer.Type.ToString("D"))

            If sName <> "" Then Call oXmlItem.SetAttribute("name", sName)
            If sCave <> "" Then Call oXmlItem.SetAttribute("cave", sCave)
            If sBranch <> "" Then Call oXmlItem.SetAttribute("branch", sBranch)
            If iBindDesignType <> BindDesignTypeEnum.MainDesign Then Call oXmlItem.SetAttribute("binddesigntype", iBindDesignType.ToString("D"))

            Call oXmlItem.SetAttribute("type", iType.ToString("D"))
            Call oXmlItem.SetAttribute("category", iCategory.ToString("D"))

            If bHiddenInDesign Then Call oXmlItem.SetAttribute("hiddenindesign", "1")
            If bHiddenInPreview Then Call oXmlItem.SetAttribute("hiddeninpreview", "1")
            If bLocked Then Call oXmlItem.SetAttribute("locked", "1")
            If iClippingType <> cItemClippingTypeEnum.Default Then Call oXmlItem.SetAttribute("clippingtype", iClippingType.ToString("D"))

            If HavePen Then Call oPen.SaveTo(File, Document, oXmlItem)
            If HaveBrush Then Call oBrush.SaveTo(File, Document, oXmlItem)
            If HaveTransparency Then If sTransparency <> 0 Then Call oXmlItem.SetAttribute("transparency", modNumbers.NumberToString(sTransparency, "0.00"))

            Call oPoints.SaveTo(File, Document, oXmlItem)

            If oDataProperties.Count <> 0 Then Call oDataProperties.SaveTo(File, Document, oXmlItem)

            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Overridable Property ClippingType As cItemClippingTypeEnum
            Get
                Return iClippingType
            End Get
            Set(ByVal value As cItemClippingTypeEnum)
                If value <> iClippingType Then
                    iClippingType = value
                    Call pInvalidate()
                End If
            End Set
        End Property

        Public ReadOnly Property Points() As cPoints
            Get
                Return oPoints
            End Get
        End Property

        Friend Overridable Sub RenameCave(ByVal Cave As String, ByVal Branch As String)
            sCave = Cave
            sBranch = Branch
        End Sub

        Public Overridable Sub SetBindDesignType(ByVal BindDesignType As BindDesignTypeEnum, Optional ByVal BindSegment As Boolean = True)
            If CanBeBinded Then
                If iBindDesignType <> BindDesignType Then
                    iBindDesignType = BindDesignType
                    If BindSegment Then
                        Call BindSegments()
                    End If
                End If
            End If
        End Sub

        Public Overridable Sub SetCave(ByVal Cave As String, Optional ByVal Branch As String = "", Optional ByVal BindSegment As Boolean = True) Implements cIItem.SetCave
            Dim sNewCave As String = "" & Cave
            Dim sNewBranch As String = "" & Branch
            If (sNewCave <> sCave) Or (sNewBranch <> sBranch) Then
                sCave = sNewCave
                If sNewCave <> "" Then
                    sBranch = sNewBranch
                Else
                    sBranch = ""
                End If
                If BindSegment Then
                    Call BindSegments()
                End If
            End If
        End Sub

        Public Overridable ReadOnly Property Cave As String Implements cIItem.Cave
            Get
                Return sCave
            End Get
        End Property

        Public Overridable ReadOnly Property Branch As String Implements cIItem.Branch
            Get
                Return sBranch
            End Get
        End Property

        Public Overridable ReadOnly Property BindDesignType As BindDesignTypeEnum
            Get
                Return iBindDesignType
            End Get
        End Property

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property Design As cDesign
            Get
                Return oDesign
            End Get
        End Property

        Public ReadOnly Property Layer As cLayer
            Get
                Return oLayer
            End Get
        End Property

        Friend Overridable Sub UnbindSegments(Optional ForceUnlock As Boolean = False)
            sCave = ""
            Threading.Tasks.Parallel.ForEach(Of cPoint)(oPoints, Sub(oPoint)
                                                                     If oPoint.SegmentLocked Then
                                                                         If ForceUnlock Then
                                                                             oPoint.SegmentLocked = False
                                                                             Call oPoint.BindSegment(Nothing)
                                                                         End If
                                                                     Else
                                                                         Call oPoint.BindSegment(Nothing)
                                                                     End If
                                                                 End Sub)

            'For Each oPoint As cPoint In oPoints
            '    If oPoint.SegmentLocked Then
            '        If ForceUnlock Then
            '            oPoint.SegmentLocked = False
            '            Call oPoint.BindSegment(Nothing)
            '        End If
            '    Else
            '        Call oPoint.BindSegment(Nothing)
            '    End If
            'Next
        End Sub

        Friend Overridable Sub BindSegments()
            If sCave = "" Or Not CanBeBinded Then
                Threading.Tasks.Parallel.ForEach(Of cPoint)(oPoints, Sub(oPoint)
                                                                         oPoint.SegmentLocked = False
                                                                         Call oPoint.BindSegment(Nothing)
                                                                     End Sub)
                'For Each oPoint As cPoint In oPoints
                '    oPoint.SegmentLocked = False
                '    Call oPoint.BindSegment(Nothing)
                'Next
            Else
                If iBindDesignType = BindDesignTypeEnum.CrossSections Then
                    'for crosssection i found one nearest segment for all points...
                    Dim oNearestSegments As Dictionary(Of cISegment, Integer) = New Dictionary(Of cISegment, Integer)
                    For Each oPoint As cPoint In oPoints
                        If Not oPoint.SegmentLocked Then
                            Dim oSegment As cISegment = oDesign.GetNearestSegment(sCave, sBranch, oPoint.X, oPoint.Y, iBindDesignType)
                            If Not IsNothing(oSegment) Then
                                If oNearestSegments.ContainsKey(oSegment) Then
                                    Dim iValue As Integer = oNearestSegments(oSegment)
                                    oNearestSegments(oSegment) = iValue + 1
                                Else
                                    Call oNearestSegments.Add(oSegment, 1)
                                End If
                            End If
                        End If
                    Next
                    Dim oNearestSegment As cISegment = oNearestSegments.OrderBy(Of Integer)(Function(item) item.Value).LastOrDefault().Key
                    Threading.Tasks.Parallel.ForEach(Of cPoint)(oPoints, Sub(oPoint)
                                                                             If Not oPoint.SegmentLocked Then
                                                                                 Call oPoint.BindSegment(oNearestSegment)
                                                                             End If
                                                                         End Sub)
                Else
                    Threading.Tasks.Parallel.ForEach(Of cPoint)(oPoints, Sub(oPoint)
                                                                             If Not oPoint.SegmentLocked Then
                                                                                 Dim oSegment As cISegment = oDesign.GetNearestSegment(sCave, sBranch, oPoint.X, oPoint.Y, iBindDesignType)
                                                                                 Call oPoint.BindSegment(oSegment)
                                                                             End If
                                                                         End Sub)
                End If

                'For Each oPoint As cPoint In oPoints
                '    If Not oPoint.SegmentLocked Then
                '        Dim oSegment As cISegment = oDesign.GetNearestSegment(sCave, sBranch, oPoint.X, oPoint.Y, iBindDesignType)
                '        Call oPoint.BindSegment(oSegment)
                '    End If
                'Next
            End If
        End Sub

        Public Overridable Sub ResizeBy(ByVal ScaleWidth As Single, ByVal ScaleHeight As Single)
            If oPoints.Count > 0 Then
                Dim oBounds As RectangleF = GetBounds()
                Dim dScaleX As Single = ScaleWidth
                Dim dScaleY As Single = ScaleHeight
                If Not (modNumbers.MathRound(dScaleX, 7) = 1 And modNumbers.MathRound(dScaleY, 7) = 1) Then
                    Dim oNewBounds As RectangleF = modPaint.ScaleRectangle(oBounds, dScaleX, dScaleY)
                    If (Math.Abs(oNewBounds.Width) >= 0.1 And Math.Abs(oNewBounds.Height) >= 0.1) And (Math.Abs(oNewBounds.Width) <= dMaxSize And Math.Abs(oNewBounds.Height) <= dMaxSize) Then
                        Dim oLocation As PointF = oBounds.Location
                        Dim oxPoints() As PointF = oPoints.GetPoints()
                        Using oMatrix As Matrix = New Matrix
                            Call oMatrix.Translate(-oLocation.X, -oLocation.Y, MatrixOrder.Append)
                            Call oMatrix.Scale(dScaleX, dScaleY, MatrixOrder.Append)
                            Call oMatrix.Translate(oLocation.X, oLocation.Y, MatrixOrder.Append)
                            Call oMatrix.TransformPoints(oxPoints)
                            For i As Integer = 0 To oPoints.Count - 1
                                oPoints(i).MoveTo(oxPoints(i))
                            Next
                        End Using
                    End If
                End If
            End If
        End Sub

        Public Overridable Sub ResizeBy(ByVal Size As SizeF)
            Call ResizeBy(Size.Width, Size.Height)
        End Sub

        Public Overridable Sub ResizeTo(ByVal Width As Single, ByVal Height As Single)
            If oPoints.Count > 0 Then
                Dim oBounds As RectangleF = GetBounds()
                Dim dScaleX As Decimal = Width / oBounds.Width
                Dim dScaleY As Decimal = Height / oBounds.Height
                If Not (modNumbers.MathRound(dScaleX, 7) = 1 And modNumbers.MathRound(dScaleY, 7) = 1) Then
                    Call ResizeBy(dScaleX, dScaleY)
                    'Dim oNewBounds As RectangleF = modPaint.ScaleRectangle(oBounds, dScaleX, dScaleY)
                    'If (Math.Abs(oNewBounds.Width) >= 0.1 And Math.Abs(oNewBounds.Height) >= 0.1) And (Math.Abs(oNewBounds.Width) <= dMaxSize And Math.Abs(oNewBounds.Height) <= dMaxSize) Then
                    '    Dim oLocation As PointF = oBounds.Location
                    '    Dim oxPoints() As PointF = oPoints.GetPoints()
                    '    Dim oMatrix As Matrix = New Matrix
                    '    Call oMatrix.Translate(-oLocation.X, -oLocation.Y, MatrixOrder.Append)
                    '    Call oMatrix.Scale(dScaleX, dScaleY, MatrixOrder.Append)
                    '    Call oMatrix.Translate(oLocation.X, oLocation.Y, MatrixOrder.Append)
                    '    Call oMatrix.TransformPoints(oxPoints)
                    '    For i As Integer = 0 To oPoints.Count - 1
                    '        oPoints(i).MoveTo(oxPoints(i))
                    '    Next
                    '    Call oMatrix.Dispose()
                    'End If
                End If
            End If
        End Sub

        Public Overridable Sub ResizeTo(ByVal Size As SizeF)
            Call ResizeTo(Size.Width, Size.Height)
        End Sub

        Public Overridable Sub Rotate(ByVal Angle As Single)
            If Angle <> 0 Then
                If oPoints.Count > 0 Then
                    Dim oCenterPoint As PointF = GetCenterPoint()
                    Call RotateAt(oCenterPoint, Angle)
                End If
            End If
        End Sub

        Public Overridable Sub RotateAt(ByVal Center As PointF, ByVal Angle As Single)
            If Angle <> 0 Then
                If oPoints.Count > 0 Then
                    For Each oPoint In oPoints.GetUnjoined
                        Call oPoint.MoveTo(modPaint.RotatePointAt(Angle, Center, oPoint.Point))
                    Next
                    'Dim oxPoints() As PointF = oPoints.GetPoints()
                    'Dim oMatrix As Matrix = New Matrix
                    'Call oMatrix.RotateAt(Angle, Center)
                    'Call oMatrix.TransformPoints(oxPoints)
                    'For i As Integer = 0 To oPoints.Count - 1
                    '    oPoints(i).MoveTo(oxPoints(i))
                    'Next
                    'Call oMatrix.Dispose()
                End If
            End If
        End Sub

        Public Overridable Sub MoveTo(ByVal X As Single, ByVal Y As Single)
            If oPoints.Count > 0 Then
                Dim oRect As RectangleF = GetBounds()
                Dim oOffset As SizeF = New SizeF(X - oRect.X, Y - oRect.Y)
                If Not oOffset.IsEmpty Then
                    For Each oPoint As cPoint In oPoints.GetUnjoined
                        Call oPoint.MoveBy(oOffset)
                    Next
                End If
            End If
        End Sub

        Public Overridable Sub MoveTo(ByVal Point As PointF)
            Call MoveTo(Point.X, Point.Y)
        End Sub

        Public Overridable Sub MoveBy(ByVal OffsetX As Single, ByVal OffsetY As Single)
            If Not (OffsetX = 0 And OffsetY = 0) Then
                If oPoints.Count > 0 Then
                    Dim oOffset As SizeF = New SizeF(OffsetX, OffsetY)
                    For Each oPoint As cPoint In oPoints.GetUnjoined
                        Call oPoint.MoveBy(oOffset)
                    Next
                End If
            End If
        End Sub

        Public Overridable Sub MoveBy(ByVal Size As SizeF)
            Call MoveBy(Size.Width, Size.Height)
        End Sub

        Public Overridable Sub LockSegments()
            For Each oPoint As cPoint In oPoints
                oPoint.SegmentLocked = True
            Next
        End Sub

        Public Overridable Sub UnlockSegments()
            For Each oPoint As cPoint In oPoints
                oPoint.SegmentLocked = False
            Next
        End Sub

        Public MustOverride ReadOnly Property CanBeReduced() As Boolean

        Private Sub pInvalidate()
            Call Caches.Invalidate()
        End Sub

        Private Sub oBrush_OnChanged(ByVal Sender As cBrush) Handles oBrush.OnChanged
            Call pInvalidate()
        End Sub

        Private Sub oPen_OnChanged(ByVal Sender As cPen) Handles oPen.OnChanged
            Call pInvalidate()
        End Sub

        Private Sub oPoints_OnChanged(ByVal Sender As cPoints) Handles oPoints.OnChanged
            If oPoints.Count = 0 Then
                Call oLayer.Items.Remove(Me)
            Else
                Call pInvalidate()
            End If
        End Sub

        Private Sub oBrush_OnRender(sender As cBrush, RenderArgs As cBrush.cRenderArgs) Handles oBrush.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = sTransparency
            End If
        End Sub

        Private Sub oPen_OnRender(sender As cPen, RenderArgs As cPen.cRenderArgs) Handles oPen.OnRender
            If HaveTransparency Then
                RenderArgs.Transparency = sTransparency
            End If
        End Sub

        Private Sub oCaches_OnInvalidate(Sender As cDrawCaches) Handles oCaches.OnInvalidate
            oThumbnailImage = Nothing
        End Sub

        Public Overridable Function IsCombinable(ByVal Item As cItem) As Boolean
            If Item IsNot Me Then
                If oLayer.Items.Contains(Item) Then
                    If Item.GetType Is Me.GetType Then
                        If Item.CanBeCombined And Me.CanBeCombined Then
                            Return True
                        End If
                    End If
                End If
            End If
            Return False
        End Function

        Public Overridable Sub Combine(ByVal Item As cItem)
            If Item IsNot Me Then
                If oLayer.Items.Contains(Item) Then
                    If Item.GetType Is Me.GetType Then
                        If Item.CanBeCombined And Me.CanBeCombined Then
                            Dim bSetLineType As Boolean
                            Dim iSourceItemLineType As cIItemLine.LineTypeEnum
                            If Item.HaveLineType And Me.HaveLineType Then
                                Dim oSourceItem As cIItemLine = Item
                                Dim oDestItem As cIItemLine = Me
                                If oSourceItem.LineType <> oDestItem.LineType Then
                                    bSetLineType = True
                                    iSourceItemLineType = oSourceItem.LineType
                                End If
                            End If

                            Dim bSetPen As Boolean
                            Dim oItemPen As cPen
                            If Item.HavePen And Me.HaveLineType Then
                                If Not Item.Pen Is Me.Pen Then
                                    bSetPen = True
                                    oItemPen = Item.Pen
                                End If
                            End If

                            Dim bFirst As Boolean = True
                            For Each oPoint As cPoint In Item.Points
                                If bFirst Then
                                    oPoint.BeginSequence = True
                                    bFirst = False
                                End If
                                If bSetLineType And oPoint.LineType = cIItemLine.LineTypeEnum.Undefined Then
                                    oPoint.LineType = iSourceItemLineType
                                End If
                                If bSetPen And oPoint.Pen Is Nothing Then
                                    oPoint.Pen = oItemPen
                                End If
                                Call Me.Points.Add(oPoint)
                            Next
                            Call oLayer.Items.Remove(Item)
                        End If
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace