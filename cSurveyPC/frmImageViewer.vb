Imports System.ComponentModel
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Public Class frmImageViewer
    Private oSurvey As cSurveyPC.cSurvey.cSurvey

    Private oList As List(Of Bitmap)

    Public Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'oList = New List(Of Bitmap)
        picImage.Location = New Point(0, 0)
    End Sub

    Protected Overrides Function GetPersistString() As String
        Return "imageviewer"
    End Function

    Public Sub Open(Item As cIItemImageBase)
        Call pImageDispose()
        picImage.Image = ImageExifRotate(Item.Image.Clone)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.Size = pnlContainer.Size
        tbMain.Enabled = True
    End Sub

    Public Sub SetSurvey(Survey As cSurveyPC.cSurvey.cSurvey)
        oSurvey = Survey
        'Call oList.Clear()
        Call pImageDispose()
        tbMain.Enabled = False
    End Sub

    Public Sub Open(Item As cAttachmentsLink)
        If Item.Attachment.GetCategory = FTTLib.FileCategory.Image Then
            Call pImageDispose()
            picImage.Image = ImageExifRotate(New Bitmap(New IO.MemoryStream(Item.Attachment.Data)))
            picImage.SizeMode = PictureBoxSizeMode.Zoom
            picImage.Size = pnlContainer.Size
            tbMain.Enabled = True
        End If
    End Sub

    Private Sub pImageDispose()
        If Not IsNothing(picImage.Image) Then
            Call picImage.Image.Dispose()
            picImage.Image = Nothing
        End If
    End Sub

    Private Sub frmImageViewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call pImageDispose
        'For Each oImage In oList
        '    Call oImage.Dispose()
        'Next
        'Call oList.Clear()
    End Sub

    Private Sub picImage_MouseWheel(sender As Object, e As MouseEventArgs) Handles picImage.MouseWheel
        Dim oNewSize As Size = New Size(picImage.Size.Width * (1 + (e.Delta / 1000)), picImage.Size.Height * (1 + (e.Delta / 1000)))
        If (oNewSize.Width > 320 AndAlso oNewSize.Height > 320) AndAlso (oNewSize.Width < 3840 AndAlso oNewSize.Height < 3840) Then
            picImage.Size = oNewSize
        End If
    End Sub

    Private Sub cmdExport_Click(sender As Object, e As EventArgs) Handles cmdExport.Click
        Using oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .Filter = GetLocalizedString("main.filetypeIMAGES") & " (*.JPG;*.PNG;*.TIF;*.BMP;*.GIF)|*.JPG;*.PNG;*.TIF;*.BMP;*.GIF"
                .FilterIndex = 1
                If .ShowDialog(Me) = DialogResult.OK Then
                    Dim iImageFormat As Imaging.ImageFormat = Imaging.ImageFormat.Jpeg
                    Select Case IO.Path.GetExtension(oSFD.FileName)
                        Case ".gif"
                            iImageFormat = Imaging.ImageFormat.Gif
                        Case ".bmp"
                            iImageFormat = Imaging.ImageFormat.Bmp
                        Case ".tif"
                            iImageFormat = Imaging.ImageFormat.Tiff
                        Case ".png"
                            iImageFormat = Imaging.ImageFormat.Png
                        Case ".jpg", ".jpeg"
                            iImageFormat = Imaging.ImageFormat.Jpeg
                    End Select
                    Call picImage.Image.Save(oSFD.FileName, iImageFormat)
                End If
            End With
        End Using
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

    Private Sub cmdRotateRight_Click(sender As Object, e As EventArgs) Handles cmdRotateRight.Click
        Call picImage.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        Call pImageRefresh()
    End Sub

    Private Sub cmdRotateLeft_Click(sender As Object, e As EventArgs) Handles cmdRotateLeft.Click
        Call picImage.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        Call pImageRefresh
    End Sub

    Private Sub pImageRefresh()
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.Size = picImage.Image.Size
        Call picImage.Refresh()
    End Sub

    Private Sub cmdFlipH_Click(sender As Object, e As EventArgs) Handles cmdFlipH.Click
        Call picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
        Call pImageRefresh()
    End Sub

    Private Sub cmdShapeV_Click(sender As Object, e As EventArgs) Handles cmdShapeV.Click
        Call picImage.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Call pImageRefresh()
    End Sub

    Private Sub cmdSizeToFit_Click(sender As Object, e As EventArgs) Handles cmdSizeToFit.Click
        picImage.Size = pnlContainer.Size
    End Sub

    Private Sub cmdZoomOriginalSize_Click(sender As Object, e As EventArgs) Handles cmdZoomOriginalSize.Click
        picImage.Size = picImage.Image.Size
    End Sub
End Class