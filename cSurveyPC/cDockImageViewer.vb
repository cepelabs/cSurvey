Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cDockImageViewer
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private oList As List(Of Bitmap)

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        picImage.Location = New Point(0, 0)
        Call pEnabled(False)
    End Sub

    Public Sub Open(Item As cIItemImageBase)
        Call pDispose()
        picImage.Image = ImageExifRotate(Item.Image.Clone)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.Size = pnlContainer.Size
        Call pEnabled(True)
    End Sub

    Private Sub pEnabled(Enabled As Boolean)
        For Each oLInk As DevExpress.XtraBars.BarItemLink In barMain.ItemLinks
            oLInk.Item.Enabled = Enabled
        Next
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        'Call oList.Clear()
        Call pDispose()
        Call pEnabled(False)
    End Sub

    Public Sub Open(Item As cAttachmentsLink)
        If Item.Attachment.GetCategory = FTTLib.FileCategory.Image Then
            Call pDispose()
            picImage.Image = ImageExifRotate(New Bitmap(New IO.MemoryStream(Item.Attachment.Data)))
            picImage.SizeMode = PictureBoxSizeMode.Zoom
            picImage.Size = pnlContainer.Size
            Call pEnabled(True)
        End If
    End Sub

    Private Sub pDispose()
        If Not IsNothing(picImage.Image) Then
            Call picImage.Image.Dispose()
            picImage.Image = Nothing
        End If
    End Sub

    Private Sub picImage_MouseWheel(sender As Object, e As MouseEventArgs) Handles picImage.MouseWheel
        Dim oNewSize As Size = New Size(picImage.Size.Width * (1 + (e.Delta / 1000)), picImage.Size.Height * (1 + (e.Delta / 1000)))
        If (oNewSize.Width > 320 AndAlso oNewSize.Height > 320) AndAlso (oNewSize.Width < 3840 AndAlso oNewSize.Height < 3840) Then
            picImage.Size = oNewSize
        End If
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs)
        Call modPaint.ShowImageExportDialog(Me, picImage.Image)
    End Sub

    Private oPanPosition As Point

    Private Sub picImage_MouseMove(sender As Object, e As MouseEventArgs) Handles picImage.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Dim oTempPosition As Point = pPointToPoint(e.Location)
            Dim iDeltaX As Integer = oTempPosition.X - oPanPosition.X
            Dim iDeltaY As Integer = oTempPosition.Y - oPanPosition.Y
            Try : pnlContainer.HorizontalScroll.Value -= iDeltaX : Catch : End Try
            Try : pnlContainer.VerticalScroll.Value -= iDeltaY : Catch : End Try
            Debug.Print(iDeltaX & " - " & iDeltaY)
            oPanPosition = oTempPosition
        End If
    End Sub

    Private Function pPointToPoint(Point As Point) As Point
        Return pnlContainer.PointToClient(picImage.PointToScreen(Point))
    End Function

    Private Sub picImage_MouseDown(sender As Object, e As MouseEventArgs) Handles picImage.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            oPanPosition = pPointToPoint(e.Location)
            picImage.Cursor = Cursors.NoMove2D
        End If
    End Sub

    Private Sub picImage_MouseUp(sender As Object, e As MouseEventArgs) Handles picImage.MouseUp
        picImage.Cursor = Cursors.Default
    End Sub

    Private Sub cmdRotateRight_Click(sender As Object, e As EventArgs)
        Call picImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Call pImageRefresh()
    End Sub

    Private Sub cmdRotateLeft_Click(sender As Object, e As EventArgs)
        Call picImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        Call pImageRefresh()
    End Sub

    Private Sub pImageRefresh()
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.Size = picImage.Image.Size
        Call picImage.Refresh()
    End Sub

    Private Sub cmdFlipH_Click(sender As Object, e As EventArgs)
        Call picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
        Call pImageRefresh()
    End Sub

    Private Sub cmdShapeV_Click(sender As Object, e As EventArgs)
        Call picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Call pImageRefresh()
    End Sub

    Private Sub cmdSizeToFit_Click(sender As Object, e As EventArgs)
        picImage.Size = pnlContainer.Size
    End Sub

    Private Sub cmdZoomOriginalSize_Click(sender As Object, e As EventArgs)
        picImage.Size = picImage.Image.Size
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Call modPaint.ShowImageExportDialog(Me, picImage.Image)
    End Sub

    Private Sub btnZoomOriginalSize_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnZoomOriginalSize.ItemClick
        picImage.Size = picImage.Image.Size
    End Sub

    Private Sub btnSizeToFit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSizeToFit.ItemClick
        picImage.Size = pnlContainer.Size
    End Sub

    Private Sub btnRotateLeft_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRotateLeft.ItemClick
        Call picImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        Call pImageRefresh()
    End Sub

    Private Sub btnRotateRight_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRotateRight.ItemClick
        Call picImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Call pImageRefresh()
    End Sub

    Private Sub btnFlipH_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFlipH.ItemClick
        Call picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
        Call pImageRefresh()
    End Sub

    Private Sub btnFlipV_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnFlipV.ItemClick
        Call picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Call pImageRefresh()
    End Sub
End Class