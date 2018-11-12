Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Surface

Imports System.Xml
Imports System.Text
Imports cSurveyPC.cSurvey.Scripting
Imports System.ComponentModel

Public Class frmSurface
    Private oSurvey As cSurvey.cSurvey
    Private oSurface As cSurface
    Private bDisableChangeEvent As Boolean

    Private oThumbSize As Size = New Size(64, 64)

    Public Sub New(Survey As cSurvey.cSurvey)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        bDisableChangeEvent = True
        oSurvey = Survey
        oSurface = New cSurface(oSurvey)
        Call oSurface.CopyFrom(oSurvey.Surface)

        lvElevations.TileSize = New Size(oThumbSize.Width * 2.5, oThumbSize.Height)
        For Each oElevation As cElevation In oSurface.Elevations
            Call imlElevations.Images.Add(oElevation.ID, oElevation.GetImage(oThumbSize))

            Dim oItem As ListViewItem = New ListViewItem
            oItem.Text = oElevation.Name '& vbCrLf & oElevation.XSize & " x " & oElevation.YSize & " m"
            'oItem.ToolTipText = oElevation.Name
            oItem.ImageKey = oElevation.ID
            oItem.Tag = oElevation
            Call lvElevations.Items.Add(oItem)
        Next
        If lvElevations.Items.Count > 0 Then
            With lvElevations.Items(0)
                Call .EnsureVisible()
                .Selected = True
                .Focused = True
            End With
        End If

        lvOrthoPhotos.TileSize = New Size(oThumbSize.Width * 2.5, oThumbSize.Height)
        For Each oOrthoPhoto As cOrthoPhoto In oSurface.OrthoPhotos
            Call imlOrthoPhotos.Images.Add(oOrthoPhoto.ID, oOrthoPhoto.GetImage(oThumbSize))
            Dim oItem As ListViewItem = New ListViewItem
            oItem.Text = oOrthoPhoto.Name '& vbCrLf & oOrthoPhoto.Photo.Width & " x " & oOrthoPhoto.Photo.Height & " px" & vbCrLf & oOrthoPhoto.XSize & " x " & oOrthoPhoto.YSize & " m"
            'oItem.ToolTipText = oOrthoPhoto.Name
            oItem.ImageKey = oOrthoPhoto.ID
            oItem.Tag = oOrthoPhoto
            Call lvOrthoPhotos.Items.Add(oItem)
        Next
        If lvOrthoPhotos.Items.Count > 0 Then
            With lvOrthoPhotos.Items(0)
                Call .EnsureVisible()
                .Selected = True
                .Focused = True
            End With
        End If

        For Each oWMS As cWMS In oSurface.WMSs
            Dim oItem As ListViewItem = New ListViewItem
            oItem.Text = oWMS.Name
            Call oItem.SubItems.Add(oWMS.URL)
            Call oItem.SubItems.Add(oWMS.Layer)
            oItem.ImageKey = "layer_wms"
            oItem.Tag = oWMS
            Call lvWMSs.Items.Add(oItem)
        Next
        If lvWMSs.Items.Count > 0 Then
            With lvWMSs.Items(0)
                Call .EnsureVisible()
                .Selected = True
                .Focused = True
            End With
        End If

        btnClear.Enabled = lvOrthoPhotos.Items.Count > 0 Or lvElevations.Items.Count > 0 Or lvWMSs.Items.Count > 0

        bDisableChangeEvent = False
        Call pShowInfo()

        If Not bIsInDebug Then tabMain.TabPages.Remove(tabShape)

        If oSurvey.Properties.GPS.Enabled Then
            Call pPopupHide()
        Else
            Call pPopupShow("warning", modMain.GetLocalizedString("surface.textpart10"), "")
        End If
    End Sub

    Private Sub pShowInfo()
        Cursor = Cursors.WaitCursor
        bDisableChangeEvent = True

        'elevazione...
        If lvElevations.SelectedItems.Count > 0 Then
            Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
            With oElevation
                If .IsEmpty Then
                    picElevationsPreview.Image = Nothing
                    txtElevationInformation.Text = GetLocalizedString("surface.textpart1")
                    'chkShowSurfaceIn3D.Enabled = False
                    cboColorSchema.Enabled = False
                    chkElevationDefault.Enabled = False
                Else
                    'chkShowSurfaceIn3D.Enabled = True
                    cboColorSchema.Enabled = True
                    chkElevationDefault.Enabled = True

                    picElevationsPreview.Image = .GetImage(picElevationsPreview.Size)
                    Dim oTL As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft)
                    Dim oTR As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopRight)
                    Dim oBL As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomLeft)
                    Dim oBR As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomRight)
                    Dim sText As String = ""
                    sText = sText & String.Format(GetLocalizedString("surface.textpart8"), modNumbers.NumberToCoordinate(oBL.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oBL.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart3"), .Columns, .Rows) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart4"), .XSize, .YSize) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart5"), modNumbers.MathRound(.Columns * .XSize, 0), modNumbers.MathRound(.Rows * .YSize, 0))
                    txtElevationInformation.Text = sText
                    'chkShowSurfaceIn3D.Checked = .ShowIn3D
                    cboColorSchema.SelectedIndex = .ColorSchema
                    chkElevationDefault.Checked = .Default
                End If
            End With
        Else
            picElevationsPreview.Image = Nothing
            txtElevationInformation.Text = GetLocalizedString("surface.textpart1")
            'chkShowSurfaceIn3D.Enabled = False
            cboColorSchema.Enabled = False
            chkElevationDefault.Enabled = False
        End If

        'ortofoto...
        If lvOrthoPhotos.SelectedItems.Count > 0 Then
            Dim oOrthoPhoto As cOrthoPhoto = lvOrthoPhotos.SelectedItems(0).Tag
            With oOrthoPhoto
                If .IsEmpty Then
                    picOrthoPhotoPreview.Image = Nothing
                    txtOrthoPhotoInformation.Text = GetLocalizedString("surface.textpart1")
                    'chkShowPhotoIn3D.Enabled = False
                    chkOrthoPhotoDefault.Enabled = False
                Else
                    picOrthoPhotoPreview.Image = .Photo
                    Dim oTL As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.TopLeft)
                    Dim oTR As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.TopRight)
                    Dim oBL As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.BottomLeft)
                    Dim oBR As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.BottomRight)
                    Dim sText As String = ""
                    sText = sText & String.Format(GetLocalizedString("surface.textpart6"), modNumbers.NumberToCoordinate(oTL.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oTL.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart7"), modNumbers.NumberToCoordinate(oTR.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oTR.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart8"), modNumbers.NumberToCoordinate(oBL.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oBL.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart9"), modNumbers.NumberToCoordinate(oBR.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oBR.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf

                    sText = sText & String.Format(GetLocalizedString("surface.textpart3"), .Photo.Width, .Photo.Height) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart4"), .XSize, .YSize) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart5"), modNumbers.MathRound(.Photo.Width * .XSize, 0), modNumbers.MathRound(.Photo.Height * .YSize, 0))
                    txtOrthoPhotoInformation.Text = sText
                    'chkShowPhotoIn3D.Enabled = True
                    'chkShowPhotoIn3D.Checked = .ShowIn3D
                    chkOrthoPhotoDefault.Enabled = True
                    chkOrthoPhotoDefault.Checked = .Default
                End If
            End With
        Else
            picOrthoPhotoPreview.Image = Nothing
            txtOrthoPhotoInformation.Text = GetLocalizedString("surface.textpart1")
            'chkShowPhotoIn3D.Enabled = False
            chkOrthoPhotoDefault.Enabled = False
        End If

        'wms....

        bDisableChangeEvent = False
        Cursor = Cursors.Default
    End Sub

    Private Function pClearAllEnabled() As Boolean
        Return lvOrthoPhotos.Items.Count > 0 Or lvElevations.Items.Count > 0 Or lvWMSs.Items.Count > 0
    End Function

    Private Sub pRemoveData()
        If Not IsNothing(lvElevations.FocusedItem) Then
            Dim oItem As ListViewItem = lvElevations.FocusedItem
            If MsgBox(GetLocalizedString("surface.warning1"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("surface.warningtitle")) = MsgBoxResult.Yes Then
                Dim oElevation As cElevation = oItem.Tag
                Call lvElevations.Items.Remove(oItem)
                Call imlElevations.Images.RemoveByKey(oElevation.ID)
                Call oSurface.Elevations.Remove(oElevation)
                btnClear.Enabled = pClearAllEnabled()
                Call pShowInfo()
            End If
        End If
    End Sub

    Private Sub pLoadElevationData()
        tabMain.SelectedTab = tabData
        Dim oOfd As OpenFileDialog = New OpenFileDialog
        With oOfd
            .Title = GetLocalizedString("surface.openelevationdialog")
            .Filter = GetLocalizedString("surface.filetypeASC") & " (*.ASC;*.TXT)|*.ASC;*.TXT"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim frmSIASCOptions As frmSurfaceImportASCOptions = New frmSurfaceImportASCOptions
                    Dim oOptions As Surface.cElevation.cElevationImportOptions = New Surface.cElevation.cElevationImportOptions
                    If frmSIASCOptions.ShowDialog = Windows.Forms.DialogResult.OK Then
                        oOptions.System = frmSIASCOptions.cboCoordinateSystem.SelectedIndex
                        Select Case DirectCast(frmSIASCOptions.cboCoordinateSystem.SelectedIndex, Surface.cElevation.cElevationImportOptions.CoordinateSystemEnum)
                            Case Surface.cElevation.cElevationImportOptions.CoordinateSystemEnum.UTMWGS84
                                Call oOptions.Parameters.Add("utmzone", frmSIASCOptions.cboUTMZone.Text)
                                Call oOptions.Parameters.Add("utmband", frmSIASCOptions.cboUTMBand.Text)
                        End Select

                        Dim oElevation As cElevation = oSurface.Elevations.Add(.FilterIndex - 1, .FileName, oOptions)
                        If Not oElevation Is Nothing Then
                            Call imlElevations.Images.Add(oElevation.ID, oElevation.GetImage(oThumbSize))
                            Dim oItem As ListViewItem = New ListViewItem
                            oItem.Text = oElevation.Name '& vbCrLf & oElevation.XSize & " x " & oElevation.YSize & " m"
                            oItem.ImageKey = oElevation.ID
                            oItem.Tag = oElevation
                            Call lvElevations.Items.Add(oItem)
                            Call oItem.EnsureVisible()
                            oItem.Focused = True
                            oItem.Selected = True
                            Call pShowInfo()
                        End If
                    End If
                Catch ex As Exception
                    Call MsgBox(String.Format(GetLocalizedString("surface.warning2"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
                End Try
            End If
        End With
    End Sub

    'Private Sub chkShowSurfaceIn3D_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowSurfaceIn3D.CheckedChanged
    '    If Not bDisableChangeEvent Then
    '        If lvElevations.SelectedItems.Count > 0 Then
    '            Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
    '            oElevation.ShowIn3D = chkShowSurfaceIn3D.Checked
    '            Call pShowInfo()
    '        End If
    '    End If
    'End Sub

    Private Sub cboColorSchema_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboColorSchema.SelectedIndexChanged
        If Not bDisableChangeEvent Then
            If lvElevations.SelectedItems.Count > 0 Then
                Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
                oElevation.ColorSchema = cboColorSchema.SelectedIndex
                Call imlElevations.Images.RemoveByKey(oElevation.ID)
                Call imlElevations.Images.Add(oElevation.ID, oElevation.GetImage(oThumbSize))
                Call pShowInfo()
            End If
        End If
    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        Call oSurvey.Surface.CopyFrom(oSurface)
    End Sub

    Private Sub pRemoveWMS()
        If Not IsNothing(lvWMSs.FocusedItem) Then
            Dim oItem As ListViewItem = lvWMSs.FocusedItem
            If MsgBox(GetLocalizedString("surface.warning3"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("surface.warningtitle")) = MsgBoxResult.Yes Then
                Dim oWMS As cWMS = oItem.Tag
                Call lvWMSs.Items.Remove(oItem)
                Call oSurface.WMSs.Remove(oWMS)
                btnClear.Enabled = pClearAllEnabled()
                Call pShowInfo()
            End If
        End If
    End Sub

    Private Sub pRemoveOrthoPhoto()
        If Not IsNothing(lvOrthoPhotos.FocusedItem) Then
            Dim oItem As ListViewItem = lvOrthoPhotos.FocusedItem
            If MsgBox(GetLocalizedString("surface.warning3"), MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, GetLocalizedString("surface.warningtitle")) = MsgBoxResult.Yes Then
                Dim oOrthoPhoto As cOrthoPhoto = oItem.Tag
                Call lvOrthoPhotos.Items.Remove(oItem)
                Call imlOrthoPhotos.Images.RemoveByKey(oOrthoPhoto.ID)
                Call oSurface.OrthoPhotos.Remove(oOrthoPhoto)
                btnClear.Enabled = pClearAllEnabled()
                Call pShowInfo()
            End If
        End If
    End Sub

    Private Sub pLoadWMS()
        tabMain.SelectedTab = tabWMS
        Dim frmSAWMS As frmSurfaceAddWMS = New frmSurfaceAddWMS
        If frmSAWMS.ShowDialog = Windows.Forms.DialogResult.OK Then
            With frmSAWMS
                Dim sName As String = .txtName.Text
                Dim sURL As String = .txtURL.Text
                Dim sLayer As String = .GetLayer()
                Dim sSRS As String = .getoverridesrs()
                Dim oWMS As cWMS = oSurface.WMSs.Add(cWMS.WMSDataTypeEnum.WMSDefaultType, sName, sURL, sLayer, sSRS, New cWMS.cWMSImportOptions)

                Dim oItem As ListViewItem = New ListViewItem
                oItem.Text = oWMS.Name '& vbCrLf & oOrthoPhoto.Photo.Width & " x " & oOrthoPhoto.Photo.Height & " px" & vbCrLf & oOrthoPhoto.XSize & " x " & oOrthoPhoto.YSize & " m"
                Call oItem.SubItems.Add(oWMS.URL)
                Call oItem.SubItems.Add(oWMS.Layer)
                oItem.ImageKey = "layer_wms"
                oItem.Tag = oWMS
                Call lvWMSs.Items.Add(oItem)
                Call oItem.EnsureVisible()
                oItem.Focused = True
                oItem.Selected = True
                Call pShowInfo()
            End With
        End If
    End Sub

    Private Sub pLoadOrthoPhoto()
        tabMain.SelectedTab = tabPhoto
        Dim oOfd As OpenFileDialog = New OpenFileDialog
        With oOfd
            .Title = GetLocalizedString("surface.openorthophotodialog")
            .Filter = GetLocalizedString("surface.filetypeIMAGES") & " (*.JPG;*.TIF;*.PNG)|*.JPG;*.TIF;*.PNG"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim frmSIASCOptions As frmSurfaceImportASCOptions = New frmSurfaceImportASCOptions
                    Dim oOptions As Surface.cOrthoPhoto.cOrthoPhotoImportOptions = New Surface.cOrthoPhoto.cOrthoPhotoImportOptions
                    If frmSIASCOptions.ShowDialog = Windows.Forms.DialogResult.OK Then
                        oOptions.System = frmSIASCOptions.cboCoordinateSystem.SelectedIndex
                        Select Case DirectCast(frmSIASCOptions.cboCoordinateSystem.SelectedIndex, Surface.cElevation.cElevationImportOptions.CoordinateSystemEnum)
                            Case Surface.cOrthoPhoto.cOrthoPhotoImportOptions.CoordinateSystemEnum.UTMWGS84
                                Call oOptions.Parameters.Add("utmzone", frmSIASCOptions.cboUTMZone.Text)
                                Call oOptions.Parameters.Add("utmband", frmSIASCOptions.cboUTMBand.Text)
                        End Select
                        Dim oOrthoPhoto As cOrthoPhoto = oSurface.OrthoPhotos.Add(.FilterIndex - 1, .FileName, oOptions)
                        If Not oOrthoPhoto Is Nothing Then
                            Call imlOrthoPhotos.Images.Add(oOrthoPhoto.ID, oOrthoPhoto.GetImage(oThumbSize))
                            Dim oItem As ListViewItem = New ListViewItem
                            oItem.Text = oOrthoPhoto.Name '& vbCrLf & oOrthoPhoto.Photo.Width & " x " & oOrthoPhoto.Photo.Height & " px" & vbCrLf & oOrthoPhoto.XSize & " x " & oOrthoPhoto.YSize & " m"
                            oItem.ImageKey = oOrthoPhoto.ID
                            oItem.Tag = oOrthoPhoto
                            Call lvOrthoPhotos.Items.Add(oItem)
                            Call oItem.EnsureVisible()
                            oItem.Focused = True
                            oItem.Selected = True
                            Call pShowInfo()
                        End If
                    End If
                Catch ex As Exception
                    Call MsgBox(String.Format(GetLocalizedString("surface.warning2"), ex.Message), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("surface.warningtitle"))
                End Try
            End If
        End With
    End Sub

    'Private Sub chkShowPhotoIn3D_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowPhotoIn3D.CheckedChanged
    '    If Not bDisableChangeEvent Then
    '        Try
    '            Dim oOrthoPhoto As cOrthoPhoto = lvOrthoPhotos.SelectedItems(0).Tag
    '            oOrthoPhoto.ShowIn3D = chkShowPhotoIn3D.Checked
    '        Catch
    '        End Try
    '        Call pShowInfo()
    '    End If
    'End Sub

    Private Sub lvOrthoPhotos_AfterLabelEdit(sender As Object, e As System.Windows.Forms.LabelEditEventArgs) Handles lvOrthoPhotos.AfterLabelEdit
        If Not bDisableChangeEvent Then
            Try
                Dim oOrthoPhoto As cOrthoPhoto = lvOrthoPhotos.SelectedItems(0).Tag
                oOrthoPhoto.Name = e.Label
            Catch
            End Try
            Call pShowInfo()
        End If
    End Sub

    Private Sub lvOrthoPhotos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvOrthoPhotos.SelectedIndexChanged
        btnRemove.Enabled = lvOrthoPhotos.SelectedItems.Count > 0
        btnClear.Enabled = pClearAllEnabled()
        Call pShowInfo()
    End Sub

    Private Sub lvElevations_AfterLabelEdit(sender As Object, e As System.Windows.Forms.LabelEditEventArgs) Handles lvElevations.AfterLabelEdit
        If Not bDisableChangeEvent Then
            Try
                Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
                oElevation.Name = e.Label
            Catch
            End Try
            Call pShowInfo()
        End If
    End Sub

    Private Sub lvElevations_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvElevations.SelectedIndexChanged
        btnRemove.Enabled = lvElevations.SelectedItems.Count > 0
        btnClear.Enabled = pClearAllEnabled()
        Call pShowInfo()
    End Sub

    Private Sub chkElevationDefault_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkElevationDefault.CheckedChanged
        If Not bDisableChangeEvent Then
            Try
                Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
                oElevation.Default = chkElevationDefault.Checked
            Catch
            End Try
            Call pShowInfo()
        End If
    End Sub

    Private Sub chkOrthoPhotoDefault_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOrthoPhotoDefault.CheckedChanged
        If Not bDisableChangeEvent Then
            Try
                Dim oOrthoPhoto As cOrthoPhoto = lvOrthoPhotos.SelectedItems(0).Tag
                oOrthoPhoto.Default = chkOrthoPhotoDefault.Checked
            Catch
            End Try
            Call pShowInfo()
        End If
    End Sub

    Private Sub pElevationsSavePreview()
        Try
            Dim oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .Title = GetLocalizedString("surface.saveelevationpreviewdialog")
                .Filter = GetLocalizedString("surface.filetypeJPG") & " (*.JPG)|*.JPG"
                .FilterIndex = 1
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Call picElevationsPreview.Image.Save(.FileName)
                End If
            End With
        Catch
        End Try
    End Sub

    Private Sub mnuElevationsPreviewElevationSavePreview_Click(sender As System.Object, e As System.EventArgs) Handles mnuElevationsPreviewElevationSavePreview.Click
        Call pElevationsSavePreview()
    End Sub

    Private Sub mnuElevationsPreview_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles mnuElevationsPreview.Opening
        mnuElevationsPreviewElevationSavePreview.Enabled = Not picElevationsPreview.Image Is Nothing
        mnuElevationsPreviewRemoveNODATA.Enabled = mnuElevationsPreviewElevationSavePreview.Enabled
        mnuElevationsPreviewExportData.Enabled = mnuElevationsPreviewElevationSavePreview.Enabled
        mnuElevationsPreviewExportData.Visible = modMain.bIsInDebug
        mnuElevationsPreviewElevationOrthoPhotoFromWMS.Enabled = lvWMSs.Items.Count
    End Sub

    Private Sub mnuElevationsPreviewExportData_Click(sender As System.Object, e As System.EventArgs) Handles mnuElevationsPreviewExportData.Click
        Try
            Dim oSFD As SaveFileDialog = New SaveFileDialog
            With oSFD
                .Title = GetLocalizedString("surface.exportelevationdatadialog")
                .Filter = GetLocalizedString("surface.filetypeHOLOS") & " (*.elevation.xml)|*.elevation.xml"
                .FilterIndex = 1
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Select Case .FilterIndex
                        Case 1
                            Dim oXML As XmlDocument = New XmlDocument
                            Dim oXMLRoot As XmlElement = oXML.CreateElement("holos")
                            Dim oXMLElevation As XmlElement = oXML.CreateElement("elevation")
                            Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
                            Dim oTopLeft As modUTM.UTM = modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.TopLeft))
                            Call oXMLElevation.SetAttribute("pos", modNumbers.NumberToString(oTopLeft.East) & ";" & modNumbers.NumberToString(oTopLeft.North) & ";0")
                            'Call oXMLElevation.SetAttribute("tr", modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.TopRight)).ToString)
                            'Call oXMLElevation.SetAttribute("bl", modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.BottomLeft)).ToString)
                            'Call oXMLElevation.SetAttribute("br", modUTM.WGS84ToUTM(oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.BottomRight)).ToString)
                            Call oXMLElevation.SetAttribute("rows", oElevation.Rows)
                            Call oXMLElevation.SetAttribute("cols", oElevation.Columns)
                            Call oXMLElevation.SetAttribute("sizex", modNumbers.NumberToString(oElevation.XSize))
                            Call oXMLElevation.SetAttribute("sizey", modNumbers.NumberToString(oElevation.YSize))
                            Call oXMLElevation.SetAttribute("nodatavalue", modNumbers.NumberToString(oElevation.NoDataValue))
                            Dim odata As StringBuilder = New StringBuilder
                            For iy As Integer = 0 To oElevation.Rows - 1
                                For ix As Integer = 0 To oElevation.Columns - 1
                                    Dim iAlt As Integer = oElevation.Data(iy, ix)   'arrotondata al metro!
                                    Call odata.Append(modNumbers.NumberToString(iAlt, "0") & " ")
                                Next
                                Call odata.Append(vbCrLf)
                            Next
                            oXMLElevation.InnerText = odata.ToString
                            Call oXMLRoot.AppendChild(oXMLElevation)
                            Call oXML.AppendChild(oXMLRoot)
                            Call oXML.Save(.FileName)
                    End Select
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnuElevationsPreviewRemoveNODATA_Click(sender As Object, e As EventArgs) Handles mnuElevationsPreviewRemoveNODATA.Click
        Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
        Call oElevation.RemoveNodata()
        Call pShowInfo()
    End Sub

    Private Sub btnElevationsRemoveData_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        If tabMain.SelectedTab Is tabData Then
            Call pRemoveData()
        End If
        If tabMain.SelectedTab Is tabPhoto Then
            Call pRemoveOrthoPhoto()
        End If
        If tabMain.SelectedTab Is tabWMS Then
            Call pRemoveWMS()
        End If
    End Sub

    Private Sub tabMain_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tabMain.SelectedIndexChanged
        If tabMain.SelectedTab Is tabData Then
            btnRemove.Enabled = lvElevations.SelectedItems.Count > 0
        End If
        If tabMain.SelectedTab Is tabPhoto Then
            btnRemove.Enabled = lvOrthoPhotos.SelectedItems.Count > 0
        End If
    End Sub

    Private Sub btnImportOrthoPhoto_Click(sender As System.Object, e As System.EventArgs) Handles btnImportOrthoPhoto.Click
        Call pLoadOrthoPhoto()
    End Sub

    Private Sub btnImportElevationData_Click(sender As System.Object, e As System.EventArgs) Handles btnImportElevationData.Click
        Call pLoadElevationData()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call oSurface.OrthoPhotos.Clear()
        Call oSurface.Elevations.Clear()
        Call oSurface.WMSs.Clear()

        Call lvOrthoPhotos.Items.Clear()
        Call lvElevations.Items.Clear()
        Call lvWMSs.Items.Clear()
        Call pShowInfo()

        btnClear.Enabled = pClearAllEnabled()
    End Sub

    Private Sub btnPopupClose_Click(sender As System.Object, e As System.EventArgs) Handles btnPopupClose.Click
        Call pPopupHide()
    End Sub

    Private Sub pPopupShow(ByVal Type As String, ByVal Text As String, Optional Details As String = "")
        With pnlPopup
            Dim bShow As Boolean
            Select Case Type.ToLower
                Case "error"
                    picPopupWarning.Image = imlPopup.Images("error")
                    .BackColor = Color.PeachPuff
                    bShow = True
                Case "warning"
                    picPopupWarning.Image = imlPopup.Images("warning")
                    .BackColor = Color.LightYellow
                    bShow = True
            End Select
            If bShow Then
                lblPopupWarning.Text = Text
                Call tipDefault.SetToolTip(lblPopupWarning, Text & IIf(Details <> "", vbCrLf & Details, ""))
                'tabMain.Location = New Point(12, 57)
                'tabMain.Size = New Size(622, 434)
                '.Dock = DockStyle.Top
                'Call .SendToBack()
                .Visible = True
            End If
        End With
    End Sub

    Private Sub pPopupHide()
        'tabMain.Location = New Point(12, 33)
        'tabMain.Size = New Size(622, 458)
        Call pnlPopup.Hide()
    End Sub

    Private Sub mnuImportShapeFile_Click(sender As Object, e As EventArgs) Handles mnuImportShapeFile.Click

    End Sub

    Private Sub mnuImportWMS_Click(sender As Object, e As EventArgs) Handles mnuImportWMS.Click
        Call pLoadWMS()
    End Sub

    Private Sub pEditWMS()
        If Not IsNothing(lvWMSs.FocusedItem) Then
            Dim oItem As ListViewItem = lvWMSs.FocusedItem
            Dim oWms As cWMS = oItem.Tag
            Dim frmSAWMS As frmSurfaceAddWMS = New frmSurfaceAddWMS(oWms.Name, oWms.URL, oWms.Layer, oWms.SRSOverride)
            If frmSAWMS.ShowDialog = Windows.Forms.DialogResult.OK Then
                With frmSAWMS
                    oWms.Name = .txtName.Text
                    oWms.URL = .txtURL.Text
                    oWms.Layer = .GetLayer

                    oItem.Text = oWms.Name
                    oItem.SubItems(1).Text = oWms.URL
                    oItem.SubItems(2).Text = oWms.Layer
                End With
            End If
        End If
    End Sub

    Private Sub lvWMSs_DoubleClick(sender As Object, e As EventArgs) Handles lvWMSs.DoubleClick
        Call pEditWMS()
    End Sub

    Private Sub lvWMSs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvWMSs.SelectedIndexChanged
        btnRemove.Enabled = lvWMSs.SelectedItems.Count > 0
        btnClear.Enabled = pClearAllEnabled()
        Call pShowInfo()
    End Sub

    Private Sub oOrthophotoFromWMS_click(Sender As Object, e As EventArgs)
        Dim oWMS As cWMS = Sender.tag
        Dim frmAOPWMS As frmSurfaceAddOrthoPhotoFromWMS = New frmSurfaceAddOrthoPhotoFromWMS(oWMS.Name)
        With frmAOPWMS
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim oBackground As Color = .picBackgroundColor.BackColor
                Dim iRatio As Integer = .txtRatio.Value
                Dim oElevation As cElevation = lvElevations.SelectedItems(0).Tag
                Dim oTL As cCoordinate = oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.TopLeft)
                Dim oBR As cCoordinate = oElevation.GetCoordinate(cElevation.GetCoordinateCornerEnum.BottomRight)
                Try
                    Dim oImage As Image = oWMS.GetImage(oTL, oBR, iRatio, oBackground)
                    Dim oOrthoPhoto As cOrthoPhoto = oSurface.OrthoPhotos.Add(oImage, oTL, iRatio, iRatio)
                    If Not oOrthoPhoto Is Nothing Then
                        oOrthoPhoto.Name = oWMS.Name
                        Call imlOrthoPhotos.Images.Add(oOrthoPhoto.ID, oOrthoPhoto.GetImage(oThumbSize))
                        Dim oItem As ListViewItem = New ListViewItem
                        oItem.Text = oOrthoPhoto.Name '& vbCrLf & oOrthoPhoto.Photo.Width & " x " & oOrthoPhoto.Photo.Height & " px" & vbCrLf & oOrthoPhoto.XSize & " x " & oOrthoPhoto.YSize & " m"
                        oItem.ImageKey = oOrthoPhoto.ID
                        oItem.Tag = oOrthoPhoto
                        Call lvOrthoPhotos.Items.Add(oItem)
                        Call oItem.EnsureVisible()
                        oItem.Focused = True
                        oItem.Selected = True
                        Call pShowInfo()
                    End If
                Catch ex As Exception
                    Call pPopupShow("warning", modMain.GetLocalizedString("surface.textpart11"), "")
                End Try
                Cursor = Cursors.Default
            End If
        End With
    End Sub

    Private Sub mnuElevationsPreviewElevationOrthoPhotoFromWMS_DropDownOpening(sender As Object, e As EventArgs) Handles mnuElevationsPreviewElevationOrthoPhotoFromWMS.DropDownOpening
        With mnuElevationsPreviewElevationOrthoPhotoFromWMS.DropDownItems
            .Clear()
            For Each oItem As ListViewItem In lvWMSs.Items
                Dim oMenuItem As ToolStripItem = .Add(oItem.Text)
                oMenuItem.Tag = oItem.Tag
                AddHandler oMenuItem.Click, AddressOf oOrthophotoFromWMS_click
            Next
        End With
    End Sub

    Private Shared Function pGetScriptCode(ScripBag As cScriptBag) As String
        Dim sFullCode As String = ""
        Select Case ScripBag.Language
            Case LanguageEnum.VisualBasic
                sFullCode = "public function FormulaApply(Row as integer,Col as integer,Data as decimal) as decimal" & vbCrLf & "return " & ScripBag.Code & vbCrLf & vbCrLf & "end function"
            Case LanguageEnum.CSharp
                sFullCode = "public bool FormulaApply(int Row, int Col, decimal Data) {" & vbCrLf & "return " & ScripBag.Code & vbCrLf & "}"
        End Select
        Return sFullCode
    End Function

    Private Sub frmF_OnFormulaCodeRequest(Sender As frmScriptFormulaEditor, ByRef Args As frmScriptFormulaEditor.cFormulaCodeRequestEvent)
        Try
            Args.FullCode = pGetScriptCode(Args.ScriptBag)
        Catch
        End Try
    End Sub

    Private Sub mnuWMSsDelete_Click(sender As Object, e As EventArgs) Handles mnuWMSsDelete.Click
        Call pRemoveWMS()
    End Sub

    Private Sub mnuWMSsEdit_Click(sender As Object, e As EventArgs) Handles mnuWMSsEdit.Click
        Call pEditWMS()
    End Sub

    Private Sub mnuElevationsDelete_Click(sender As Object, e As EventArgs) Handles mnuElevationsDelete.Click
        Call pRemoveData()
    End Sub

    Private Sub mnuElevations_Opening(sender As Object, e As CancelEventArgs) Handles mnuElevations.Opening
        mnuElevationsDelete.Enabled = Not IsNothing(lvElevations.FocusedItem)
    End Sub

    Private Sub mnuWMSs_Opening(sender As Object, e As CancelEventArgs) Handles mnuWMSs.Opening
        Dim bEnabled As Boolean = Not IsNothing(lvWMSs.FocusedItem)
        mnuWMSsEdit.Enabled = bEnabled
        mnuWMSsDelete.Enabled = bEnabled
    End Sub

    Private Sub mnuOrthophotosDelete_Click(sender As Object, e As EventArgs) Handles mnuOrthophotosDelete.Click
        Call pRemoveOrthoPhoto()
    End Sub

    Private Sub mnuOrthophotos_Opening(sender As Object, e As CancelEventArgs) Handles mnuOrthophotos.Opening
        mnuOrthophotosDelete.Enabled = Not IsNothing(lvOrthoPhotos.FocusedItem)
    End Sub
End Class