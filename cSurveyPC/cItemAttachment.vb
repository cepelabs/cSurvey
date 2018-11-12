Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemAttachment
        Inherits cItem
        Implements cIItemAttachment

        Private oSurvey As cSurvey

        Private WithEvents oAttachment As cAttachmentsLink

        Private oDataBounds As RectangleF

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

        Friend Sub GetScaleAndRotateFactors(PaintOptions As cOptions, ByRef Scale As Single, ByRef Angle As Single)
            Scale = GetAttachmentScaleFactor(PaintOptions)
        End Sub

        Public Overrides ReadOnly Property CanBeReduced As Boolean
            Get
                Return False
            End Get
        End Property

        Public Sub SetAttachment(Filename As String)
            oAttachment.PerformCleanUp()
            oAttachment = New cAttachmentsLink(oSurvey, Me, oSurvey.Attachments.Add(Filename))
        End Sub

        Public ReadOnly Property Attachment As cAttachmentsLink Implements cIItemAttachment.Attachment
            Get
                Return oAttachment
            End Get
        End Property

        Public Overrides ReadOnly Property HaveTransparency As Boolean
            Get
                Return False
            End Get
        End Property

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

        Public Overrides ReadOnly Property HaveSketch As Boolean
            Get
                Return False
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

        Public Overrides ReadOnly Property HaveQuota As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeConverted As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveSign As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveImage As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeClipped As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveText As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveLineType As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property HaveFont As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeRotated As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property BindMode As cItem.BindModeEnum
            Get
                Return BindModeEnum.CenterPoint
            End Get
        End Property

        Public Overrides ReadOnly Property HaveEditablePoints As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property MaxPointsCount As Integer
            Get
                Return 1
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeResized() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeDivided() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCombined() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeBinded() As Boolean
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
                Return False
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Filename As String)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Attachment, Category)
            oSurvey = Survey
            oAttachment = New cAttachmentsLink(oSurvey, Me, oSurvey.Attachments.Add(Filename))
            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cAttachmentLinks.cAttachmentDataFormatEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Attachment, Category)
            oSurvey = Survey
            Select Case DataFormat
                Case cAttachmentLinks.cAttachmentDataFormatEnum.File
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments.Add(Data), cAttachment))
                Case cAttachmentLinks.cAttachmentDataFormatEnum.Data
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments.Add("", Data), cAttachment))
                Case cAttachmentLinks.cAttachmentDataFormatEnum.Resource
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments(Data), cAttachment))
                Case Else
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments(Data), cAttachment))
            End Select
            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            With MyBase.Caches(PaintOptions)
                If .Invalidated Then
                    Call .Clear()
                    Using oPath As GraphicsPath = New GraphicsPath
                        Dim oPoint As PointF = MyBase.Points(0).Point
                        Dim oBounds As RectangleF = New RectangleF(oPoint.X - oDataBounds.Width / 2, oPoint.Y - oDataBounds.Height / 2, oDataBounds.Width, oDataBounds.Height)
                        Call oPath.AddRectangle(oBounds)
                        Call .Add(Drawings.cDrawCacheItem.cDrawCacheItemType.Border, oPath, Nothing, Nothing, Nothing)
                    End Using
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptions, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                Try
                    If Not PaintOptions.IsDesign Or (PaintOptions.IsDesign And Not MyBase.HiddenInDesign) Then
                        Dim oPoint As PointF = MyBase.Points(0).Point
                        Dim oBounds As RectangleF = New RectangleF(oPoint.X - oDataBounds.Width / 2, oPoint.Y - oDataBounds.Height / 2, oDataBounds.Width, oDataBounds.Height)
                        If (Options And PaintOptionsEnum.Wireframe) = PaintOptionsEnum.Wireframe Then
                            Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail(True), oBounds)
                        Else
                            Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail, oBounds)
                        End If
                        Call MyBase.Caches(PaintOptions).Paint(Graphics, PaintOptions, Options)
                        If PaintOptions.ShowSegmentBindings Then
                            Call modPaint.PaintPointToSegmentBindings(Graphics, MyBase.Survey, Me, Selected)
                        End If
                    End If
                Catch
                End Try
            End If
        End Sub

        Friend Sub FixBound(Optional ByVal ForceBound As Boolean = False)
            If MyBase.Points.Count > 1 Or ForceBound Then
                Dim oxPoints() As PointF = MyBase.Points.GetPoints()
                Dim oRect As RectangleF
                For Each oxPoint As PointF In oxPoints
                    If modPaint.IsRectangleEmpty(oRect) Then
                        oRect = New RectangleF(oxPoint.X, oxPoint.Y, 0, 0)
                    Else
                        oRect = RectangleF.Union(oRect, New RectangleF(oxPoint.X, oxPoint.Y, 0, 0))
                    End If
                Next
                Call MyBase.Points.BeginUpdate()
                Call MyBase.Points.Clear()
                Call MyBase.Points.AddFromPaintPoint(oRect.Left + oRect.Width / 2, oRect.Top + oRect.Height / 2)
                Call MyBase.Points.EndUpdate()
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            If modXML.ChildElementExist(item, "attachment") Then
                oAttachment = New cAttachmentsLink(oSurvey, Me, item.Item("attachment"))
            End If
            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oAttachment.SaveTo(File, Document, oItem)
            Return oItem
        End Function

        Private Sub pLoadData()
            'in future add support for attachment->image...
            oDataBounds = New RectangleF(0, 0, 1, 1)
        End Sub

        Friend Overrides Sub BindSegments()
            If MyBase.Cave = "" Then
                For Each oPoint As cPoint In MyBase.Points
                    oPoint.SegmentLocked = False
                    Call oPoint.BindSegment(Nothing)
                Next
            Else
                If MyBase.Points.Count > 0 Then
                    Dim oCenterPoint As PointF = GetCenterPoint()
                    Dim oSegment As cISegment = MyBase.Design.GetNearestSegment(MyBase.Cave, MyBase.Branch, MyBase.CrossSection, oCenterPoint.X, oCenterPoint.Y, MyBase.BindDesignType)
                    For Each oPoint As cPoint In MyBase.Points
                        If Not oPoint.SegmentLocked Then
                            Call oPoint.BindSegment(oSegment)
                        End If
                    Next
                End If
            End If
        End Sub

        Public Overrides Function GetBounds() As RectangleF
            If MyBase.Points.Count > 0 Then
                Dim oDesignBounds As RectangleF = MyBase.Caches.GetBounds
                If modPaint.IsRectangleEmpty(oDesignBounds) Then
                    Return MyBase.GetBounds()
                Else
                    Return oDesignBounds
                End If
            End If
        End Function

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlDocument
            Dim oSVG As XmlDocument = modSVG.CreateSVG
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions, Options))
            Return oSVG
        End Function

        Friend Overrides Function ToSvgItem(ByVal SVG As XmlDocument, ByVal PaintOptions As cOptions, ByVal Options As cItem.SVGOptionsEnum) As XmlElement
            Dim oMatrix As Matrix = New Matrix
            If PaintOptions.DrawTranslation Then
                Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
            End If
            Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, Options, oMatrix)
            Call oSVGItem.SetAttribute("name", MyBase.Name)
            Call modSVG.AppendItemStyle(SVG, oSVGItem, MyBase.Brush, MyBase.Pen)
            Call oMatrix.Dispose()
            Return oSVGItem
        End Function

        Public Overrides ReadOnly Property CanImportGeneric As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Function FromGeneric(ByVal Item As cItemGeneric, Optional ByVal Clear As Boolean = False) As Boolean
            Return False
        End Function
    End Class
End Namespace
