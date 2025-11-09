Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports DevExpress.XtraBars.Alerter
Imports DevExpress.Utils.Svg
Imports DevExpress
Imports DevExpress.Utils.Drawing
Imports DevExpress.LookAndFeel

Namespace cSurvey.Design.Items
    Public Class cItemAttachment
        Inherits cItem
        Implements cIItemAttachment

        Private oSurvey As cSurvey

        Private WithEvents oAttachment As cAttachmentsLink

        Private oDataBounds As RectangleF

        Public Overrides ReadOnly Property HaveAffinity As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides ReadOnly Property CanBeCopied As Boolean
            Get
                Return True
            End Get
        End Property

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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum, ByVal Data As Object, ByVal DataFormat As cAttachmentsLinks.cAttachmentDataFormatEnum)
            Call MyBase.New(Survey, Design, Layer, cIItem.cItemTypeEnum.Attachment, Category)
            oSurvey = Survey
            Select Case DataFormat
                Case cAttachmentsLinks.cAttachmentDataFormatEnum.File
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments.Add(Data), cAttachment))
                Case cAttachmentsLinks.cAttachmentDataFormatEnum.Data
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments.Add("", Data), cAttachment))
                Case cAttachmentsLinks.cAttachmentDataFormatEnum.Resource
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments(Data), cAttachment))
                Case Else
                    oAttachment = New cAttachmentsLink(oSurvey, Me, DirectCast(oSurvey.Attachments(Data), cAttachment))
            End Select
            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Sub Render(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            With MyBase.Caches(PaintOptions)
                If .Invalidated Then
                    Call .Clear()
                    Using oPath As GraphicsPath = New GraphicsPath
                        Dim oPoint As PointF = MyBase.Points(0).Point
                        Dim oBounds As RectangleF = New RectangleF(oPoint.X - oDataBounds.Width / 2, oPoint.Y - oDataBounds.Height / 2, oDataBounds.Width, oDataBounds.Height)
                        'oBounds = modPaint.ScaleRectangle(oBounds, modPaint.sMeterToPixelScale * PaintOptions.CurrentScale)
                        Call oPath.AddRectangle(oBounds)
                        Call .Add(Drawings.cDrawCacheItem.cDrawCacheItemType.Border, oPath, Nothing, Nothing, Nothing)
                    End Using
                    Call .Rendered()
                End If
            End With
        End Sub

        Friend Overrides Sub Paint(ByVal Graphics As Graphics, ByVal PaintOptions As cOptionsCenterline, ByVal Options As cItem.PaintOptionsEnum, ByVal Selected As SelectionModeEnum)
            If MyBase.Points.Count > 0 Then
                Call Render(Graphics, PaintOptions, Options, Selected)
                Try
                    If Not PaintOptions.IsDesign OrElse (PaintOptions.IsDesign AndAlso Not MyBase.HiddenInDesign) Then

                        Dim oPoint As PointF = MyBase.Points(0).Point
                        Dim oBounds As RectangleF = New RectangleF(oPoint.X - oDataBounds.Width / 2, oPoint.Y - oDataBounds.Height / 2, oDataBounds.Width, oDataBounds.Height)
                        'oBounds = modPaint.ScaleRectangle(oBounds, modPaint.sMeterToPixelScale * PaintOptions.CurrentScale)
                        Using oPath As GraphicsPath = New GraphicsPath
                            Call oPath.AddLine(oBounds.Left, oBounds.Top, oBounds.Left, oBounds.Top + oBounds.Height \ 2)
                            Call oPath.AddArc(oBounds, 180, -90)
                            Call oPath.AddLine(oBounds.Left + oBounds.Width \ 2, oBounds.Bottom, oBounds.Left + oBounds.Width \ 2, oBounds.Bottom)

                            Call oPath.AddArc(oBounds.Left, oBounds.Top, oBounds.Width, oBounds.Height, 90, -180)
                            Call oPath.AddLine(oBounds.Left, oBounds.Top, oBounds.Left + oBounds.Width \ 2, oBounds.Top)
                            Call oPath.AddLine(oBounds.Left + oBounds.Width \ 2, oBounds.Top, oBounds.Left, oBounds.Top)

                            Dim oClipBounds As RectangleF = oBounds
                            oClipBounds.Inflate(-0.1, -0.1)
                            'oClipBounds.Inflate(-2 * modPaint.sMeterToPixelScale * PaintOptions.CurrentScale, -2 * modPaint.sMeterToPixelScale * PaintOptions.CurrentScale)
                            oPath.AddEllipse(oClipBounds)

                            Call Graphics.FillPath(Brushes.Gray, oPath)
                        End Using

                        Using oClipPath As GraphicsPath = New GraphicsPath
                            Dim oClipBounds As RectangleF = oBounds
                            'oClipBounds.Inflate(-2 * modPaint.sMeterToPixelScale * PaintOptions.CurrentScale, -2 * modPaint.sMeterToPixelScale * PaintOptions.CurrentScale)
                            oClipBounds.Inflate(-0.1, -0.1)
                            oClipPath.AddEllipse(oClipBounds)

                            Dim oState As GraphicsState = Graphics.Save
                            Call Graphics.SetClip(oClipPath)
                            Select Case oAttachment.Attachment.GetCategory
                                Case FTTLib.FileCategory.Audio
                                    Using oImage As Image = My.Resources.Electronics_Volume_colored.Render(Nothing)
                                        'Call Graphics.DrawImage(oImage, oBounds)
                                        modPaint.DrawFittedImage(Graphics, oImage, oClipBounds)
                                    End Using
                                Case FTTLib.FileCategory.Image
                                    If (Options And PaintOptionsEnum.Wireframe) = PaintOptionsEnum.Wireframe Then
                                        'Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail(True), oBounds)
                                        modPaint.DrawFittedImage(Graphics, oAttachment.Attachment.GetThumbnail(True), oClipBounds)
                                    Else
                                        'Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail, oBounds)
                                        modPaint.DrawFittedImage(Graphics, oAttachment.Attachment.GetThumbnail, oClipBounds)
                                    End If
                                Case Else
                                    Using oImage As Image = My.Resources.attachments.Render(Nothing)
                                        'Call Graphics.DrawImage(oImage, oBounds)
                                        modPaint.DrawFittedImage(Graphics, oImage, oClipBounds)
                                    End Using
                            End Select
                            Call Graphics.Restore(oState)
                        End Using

                        'Select Case oAttachment.Attachment.GetCategory
                        '    Case FTTLib.FileCategory.Audio
                        '        Using oImage As Image = My.Resources.Electronics_Volume_colored.Render(Nothing)
                        '            Call Graphics.DrawImage(oImage, oBounds)
                        '        End Using
                        '    Case FTTLib.FileCategory.Image
                        '        If (Options And PaintOptionsEnum.Wireframe) = PaintOptionsEnum.Wireframe Then
                        '            Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail(True), oBounds)
                        '        Else
                        '            Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail, oBounds)
                        '        End If
                        '    Case Else
                        '        Using oImage As Image = My.Resources.attachments.Render(Nothing)
                        '            Call Graphics.DrawImage(oImage, oBounds)
                        '        End Using
                        'End Select
                        'If (Options And PaintOptionsEnum.Wireframe) = PaintOptionsEnum.Wireframe Then
                        '    Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail(True), oBounds)
                        'Else
                        '    Call Graphics.DrawImage(oAttachment.Attachment.GetThumbnail, oBounds)
                        'End If

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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
            oSurvey = Survey
            If modXML.ChildElementExist(item, "attachment") Then
                oAttachment = New cAttachmentsLink(oSurvey, Me, item.Item("attachment"))
            End If
            Call pLoadData()
            Call FixBound()
        End Sub

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
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

        Friend Overrides Function ToSvg(ByVal PaintOptions As cOptionsCenterline, ByVal Options As cSVGWriter.SVGOptionsEnum) As cSVGWriter
            Dim oSVG As cSVGWriter = modSVG.CreateSVG(Options)
            Call modSVG.AppendItem(oSVG, Nothing, ToSvgItem(oSVG, PaintOptions))
            Return oSVG
        End Function

        Friend Overrides Function ToSvgItem(ByVal SVG As cSVGWriter, ByVal PaintOptions As cOptionsCenterline) As XmlElement
            Using oMatrix As Matrix = New Matrix
                If PaintOptions.DrawTranslation Then
                    Dim oTranslation As SizeF = MyBase.Design.GetItemTranslation(Me)
                    Call oMatrix.Translate(oTranslation.Width, oTranslation.Height)
                End If
                Dim oSVGItem As XmlElement = MyBase.Caches(PaintOptions).ToSvgItem(SVG, PaintOptions, oMatrix)
                If MyBase.Name <> "" Then Call oSVGItem.SetAttribute("name", MyBase.Name)
                Call modSVG.AppendItemStyle(SVG, oSVGItem, MyBase.Brush, MyBase.Pen)
                Return oSVGItem
            End Using
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
