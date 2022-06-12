Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraTreeList

Friend Class cItemBrushStylePropertyControl
    'Private oPaintOptions As cOptions
    Private oSurvey As cSurvey.cSurvey

    Private oPoint As cPoint

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows Sub Rebind(Item As cItem, PaintOptions As cOptions)
        MyBase.Rebind(Item)

        If oSurvey IsNot Item.Survey Then
            oSurvey = Item.Survey
            Call cboPropBrushPattern.Rebind(oSurvey)
        End If

        cboPropBrushPattern.EditValue = Item.Brush.ID

        cboPropBrushHatch.SelectedIndex = Item.Brush.HatchType
        txtPropBrushColor.Color = Item.Brush.Color
    End Sub

    Private Sub cmdPropBrushReseed_Click(sender As Object, e As EventArgs) Handles cmdPropBrushReseed.Click
        Call Item.Brush.Seed.Reseed()
        Call MyBase.TakeUndoSnapshot()
        Call MyBase.PropertyChanged("BrushReseed")
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cboPropBrushHatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushHatch.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.HatchType = cboPropBrushHatch.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushHatch")
            Call MyBase.MapInvalidate()
        End If

        Select Case Item.Brush.HatchType
            Case cBrush.HatchTypeEnum.Texture
                cmdPropBrushReseed.Visible = False

                cmdPropBrushBrowseClipart.Visible = True
                lblPropBrushClipartImage.Visible = True
                picPropBrushClipartImage.Visible = True
                cboPropBrushPatternType.Visible = False
                lblPropBrushPatternType.Visible = False
                cboPropBrushPatternPen.Visible = False
                lblPropBrushPatternPen.Visible = False
                lblPropBrushClipartZoomFactor.Visible = False
                txtPropBrushClipartZoomFactor.Visible = False
                lblPropBrushClipartCrop.Visible = False
                cboPropBrushClipartCrop.Visible = False
                lblPropBrushClipartDensity.Visible = False
                txtPropBrushClipartDensity.Visible = False
                lblPropBrushClipartAngleMode.Visible = False
                cboPropBrushClipartAngleMode.Visible = False
                txtPropBrushClipartAngle.Visible = False
                lblPropBrushClipartAngle.Visible = False
                lblPropBrushAlternativeBrushColor.Visible = True
                txtPropBrushAlternativeBrushColor.Visible = True
                txtPropBrushColor.Visible = False
                lblPropBrushColor.Visible = False
                lblPropBrushClipartPosition.Visible = False
                cboPropBrushClipartPosition.Visible = False

                cmdPropBrushBrowseClipart.Enabled = True
                txtPropBrushClipartDensity.Enabled = False
                txtPropBrushClipartZoomFactor.Enabled = False
                cboPropBrushClipartAngleMode.Enabled = False
                txtPropBrushClipartAngle.Enabled = False
                txtPropBrushAlternativeBrushColor.Enabled = True
                cboPropBrushClipartCrop.Enabled = False

            Case cBrush.HatchTypeEnum.Pattern
                cmdPropBrushReseed.Visible = False

                cmdPropBrushBrowseClipart.Visible = False
                lblPropBrushClipartImage.Visible = False
                picPropBrushClipartImage.Visible = False
                lblPropBrushClipartZoomFactor.Visible = False
                txtPropBrushClipartZoomFactor.Visible = False
                cboPropBrushPatternType.Visible = True
                lblPropBrushPatternType.Visible = True
                cboPropBrushPatternPen.Visible = True
                lblPropBrushPatternPen.Visible = True
                lblPropBrushClipartCrop.Visible = False
                cboPropBrushClipartCrop.Visible = False
                lblPropBrushClipartDensity.Visible = True
                txtPropBrushClipartDensity.Visible = True
                lblPropBrushClipartAngleMode.Visible = False
                cboPropBrushClipartAngleMode.Visible = False
                txtPropBrushClipartAngle.Visible = True
                lblPropBrushClipartAngle.Visible = True
                lblPropBrushAlternativeBrushColor.Visible = True
                txtPropBrushAlternativeBrushColor.Visible = True
                txtPropBrushColor.Visible = True
                lblPropBrushColor.Visible = True
                lblPropBrushClipartPosition.Visible = False
                cboPropBrushClipartPosition.Visible = False

                txtPropBrushClipartDensity.Enabled = True
                cboPropBrushClipartAngleMode.Enabled = True
                txtPropBrushClipartAngle.Enabled = True

                txtPropBrushClipartDensity.Value = Item.Brush.ClipartDensity * 100
                cboPropBrushClipartAngleMode.SelectedIndex = Item.Brush.ClipartAngleMode
                txtPropBrushClipartAngle.Value = Item.Brush.ClipartAngle
                cboPropBrushPatternType.SelectedIndex = Item.Brush.PatternType
                cboPropBrushPatternPen.SelectedIndex = Item.Brush.PatternPenStyle
                txtPropBrushAlternativeBrushColor.EditValue = Item.Brush.ClipartAlternativeColor
            Case cBrush.HatchTypeEnum.Clipart
                cmdPropBrushReseed.Visible = True

                cmdPropBrushBrowseClipart.Visible = True
                lblPropBrushClipartImage.Visible = True
                picPropBrushClipartImage.Visible = True
                cboPropBrushPatternType.Visible = False
                lblPropBrushPatternType.Visible = False
                cboPropBrushPatternPen.Visible = False
                lblPropBrushPatternPen.Visible = False
                lblPropBrushClipartZoomFactor.Visible = True
                txtPropBrushClipartZoomFactor.Visible = True
                lblPropBrushClipartCrop.Visible = True
                cboPropBrushClipartCrop.Visible = True
                lblPropBrushClipartDensity.Visible = True
                txtPropBrushClipartDensity.Visible = True
                lblPropBrushClipartAngleMode.Visible = True
                cboPropBrushClipartAngleMode.Visible = True
                txtPropBrushClipartAngle.Visible = True
                lblPropBrushClipartAngle.Visible = True
                lblPropBrushAlternativeBrushColor.Visible = True
                txtPropBrushAlternativeBrushColor.Visible = True
                txtPropBrushColor.Visible = True
                lblPropBrushColor.Visible = True
                lblPropBrushClipartPosition.Visible = True
                cboPropBrushClipartPosition.Visible = True

                cmdPropBrushBrowseClipart.Enabled = True
                txtPropBrushClipartDensity.Enabled = True
                txtPropBrushClipartZoomFactor.Enabled = True
                cboPropBrushClipartAngleMode.Enabled = True
                txtPropBrushAlternativeBrushColor.Enabled = True
                cboPropBrushClipartCrop.Enabled = True

                cmdPropBrushReseed.Enabled = Item.Brush.HatchType = cBrush.HatchTypeEnum.Clipart
                txtPropBrushClipartDensity.Value = Item.Brush.ClipartDensity * 100
                txtPropBrushClipartZoomFactor.Value = Item.Brush.ClipartZoomFactor * 1000
                cboPropBrushClipartAngleMode.SelectedIndex = Item.Brush.ClipartAngleMode
                txtPropBrushClipartAngle.Value = Item.Brush.ClipartAngle
                cboPropBrushClipartPosition.SelectedIndex = Item.Brush.ClipartPosition
                txtPropBrushAlternativeBrushColor.EditValue = Item.Brush.ClipartAlternativeColor
                cboPropBrushClipartCrop.SelectedIndex = Item.Brush.ClipartCrop
            Case cBrush.HatchTypeEnum.Solid
                cmdPropBrushReseed.Visible = False

                cmdPropBrushBrowseClipart.Visible = False
                lblPropBrushClipartImage.Visible = False
                picPropBrushClipartImage.Visible = False
                cboPropBrushPatternType.Visible = False
                lblPropBrushPatternType.Visible = False
                cboPropBrushPatternPen.Visible = False
                lblPropBrushPatternPen.Visible = False
                lblPropBrushClipartZoomFactor.Visible = False
                txtPropBrushClipartZoomFactor.Visible = False
                lblPropBrushClipartCrop.Visible = False
                cboPropBrushClipartCrop.Visible = False
                lblPropBrushClipartDensity.Visible = False
                txtPropBrushClipartDensity.Visible = False
                lblPropBrushClipartAngleMode.Visible = False
                cboPropBrushClipartAngleMode.Visible = False
                txtPropBrushClipartAngle.Visible = False
                lblPropBrushClipartAngle.Visible = False
                lblPropBrushAlternativeBrushColor.Visible = False
                txtPropBrushAlternativeBrushColor.Visible = False
                txtPropBrushColor.Visible = True
                lblPropBrushColor.Visible = True
                lblPropBrushClipartPosition.Visible = False
                cboPropBrushClipartPosition.Visible = False
            Case Else
                cmdPropBrushReseed.Visible = False

                cmdPropBrushBrowseClipart.Visible = False
                lblPropBrushClipartImage.Visible = False
                picPropBrushClipartImage.Visible = False
                cboPropBrushPatternType.Visible = False
                lblPropBrushPatternType.Visible = False
                cboPropBrushPatternPen.Visible = False
                lblPropBrushPatternPen.Visible = False
                lblPropBrushClipartZoomFactor.Visible = False
                txtPropBrushClipartZoomFactor.Visible = False
                lblPropBrushClipartCrop.Visible = False
                cboPropBrushClipartCrop.Visible = False
                lblPropBrushClipartDensity.Visible = False
                txtPropBrushClipartDensity.Visible = False
                lblPropBrushClipartAngleMode.Visible = False
                cboPropBrushClipartAngleMode.Visible = False
                txtPropBrushClipartAngle.Visible = False
                lblPropBrushClipartAngle.Visible = False
                lblPropBrushAlternativeBrushColor.Visible = False
                txtPropBrushAlternativeBrushColor.Visible = False
                txtPropBrushColor.Visible = False
                lblPropBrushColor.Visible = False
                lblPropBrushClipartPosition.Visible = False
                cboPropBrushClipartPosition.Visible = False

                cmdPropBrushBrowseClipart.Enabled = False
                txtPropBrushClipartDensity.Enabled = False
                txtPropBrushClipartZoomFactor.Enabled = False
                cboPropBrushClipartAngleMode.Enabled = False
                txtPropBrushAlternativeBrushColor.Enabled = False
                cboPropBrushClipartCrop.Enabled = False
        End Select
    End Sub

    Private Sub txtPropBrushClipartDensity_ValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartDensity.ValueChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartDensity = txtPropBrushClipartDensity.Value / 100
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushClipartDensity")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushClipartZoomFactor_ValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartZoomFactor.ValueChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartZoomFactor = txtPropBrushClipartZoomFactor.Value / 1000
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushClipartZoomFactor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushClipartPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushClipartPosition.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartPosition = cboPropBrushClipartPosition.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushClipartPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushPatternType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushPatternType.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.PatternType = cboPropBrushPatternType.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushPatternType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushClipartAngleMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushClipartAngleMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartAngleMode = cboPropBrushClipartAngleMode.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushClipartAngleMode")
            Call MyBase.MapInvalidate()
        End If

        txtPropBrushClipartAngle.Enabled = Item.Brush.ClipartAngleMode = cBrush.ClipartAngleModeEnum.Fixed
        lblPropBrushClipartAngle.Enabled = txtPropBrushClipartAngle.Enabled
    End Sub

    Private Sub txtPropBrushClipartAngle_ValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartAngle.ValueChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartAngle = txtPropBrushClipartAngle.Value
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushClipartAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.Color = txtPropBrushColor.EditValue
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushPatternPen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushPatternPen.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.PatternPenStyle = cboPropBrushPatternPen.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushPatternPen")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushAlternativeBrushColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushAlternativeBrushColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartAlternativeColor = txtPropBrushAlternativeBrushColor.EditValue
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushAlternativeBrushColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdCompassBrowseClipart_Click(sender As Object, e As EventArgs) Handles cmdPropBrushBrowseClipart.Click
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                If cboPropBrushHatch.SelectedIndex = cBrush.HatchTypeEnum.Texture Then
                    .Title = GetLocalizedString("main.loadtexturedialog")
                    .Filter = GetLocalizedString("main.filetypePNG") & " (*.PNG)|*.PNG|" & GetLocalizedString("main.filetypeBMP") & " (*.BMP)|*.BMP|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                    .FilterIndex = 1
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Item.Brush.Texture = modPaint.SafeBitmapFromFileUnlocked(.FileName)
                        picPropBrushClipartImage.Image = Item.Brush.Texture
                        Call MyBase.TakeUndoSnapshot()
                        Call MyBase.PropertyChanged("BrushClipart")
                        Call MyBase.MapInvalidate()
                    End If
                ElseIf cboPropBrushHatch.SelectedIndex = cBrush.HatchTypeEnum.Clipart Then
                    .Title = GetLocalizedString("main.loadclipartdialog")
                    .Filter = GetLocalizedString("main.filetypeSVG") & " (*.SVG)|*.SVG|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                    .FilterIndex = 1
                    If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Try
                            Try
                                Dim oClipart As Drawings.cDrawClipArt = New Drawings.cDrawClipArt(.FileName)
                                Item.Brush.Clipart = oClipart
                                picPropBrushClipartImage.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile(.FileName)
                            Catch
                                Item.Brush.Clipart = Nothing
                                picPropBrushClipartImage.Image = Nothing
                            End Try
                            Call MyBase.TakeUndoSnapshot()
                            Call MyBase.PropertyChanged("BrushClipart")
                            Call MyBase.MapInvalidate()
                        Catch
                        End Try
                    End If
                End If
            End With
        End Using
    End Sub

    Private Sub cboPropBrushPattern_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropBrushPattern.EditValueChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ID = cboPropBrushPattern.EditValue
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushPattern")
            Call MyBase.MapInvalidate()
        End If

        If Item IsNot Nothing Then
            If Item.Brush.Type = cBrush.BrushTypeEnum.Custom Then
                cmdPropSave.Visible = True
                cmdPropBrushBrowseClipart.Enabled = True
                cmdPropBrushReseed.Enabled = True
                txtPropBrushClipartDensity.Enabled = True
                txtPropBrushClipartZoomFactor.Enabled = True
                Select Case cboPropBrushHatch.SelectedIndex
                    Case cBrush.HatchTypeEnum.Clipart
                        If Item.Brush.Clipart Is Nothing Then
                            picPropBrushClipartImage.Image = Nothing
                        Else
                            picPropBrushClipartImage.Image = Item.Brush.Clipart.GetThumbnailImage(picPropBrushClipartImage.Width, picPropBrushClipartImage.Height)
                        End If
                    Case cBrush.HatchTypeEnum.Texture
                        If Item.Brush.Texture Is Nothing Then
                            picPropBrushClipartImage.Image = Nothing
                        Else
                            picPropBrushClipartImage.Image = Item.Brush.Texture
                        End If
                End Select

                Height = 238 * CurrentAutoScaleDimensions.Height / 96.0F
            Else
                cmdPropSave.Visible = False
                cmdPropBrushReseed.Visible = Item.Brush.HatchType = cBrush.HatchTypeEnum.Clipart
                Height = 45 * CurrentAutoScaleDimensions.Height / 96.0F
            End If
        End If
    End Sub

    Private Sub cboPropBrushClipartCrop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushClipartCrop.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Item.Brush.ClipartCrop = cboPropBrushClipartCrop.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("BrushClipartCrop")
            Call MyBase.MapInvalidate()
        End If
    End Sub
    Private Sub pSaveBrush(Filename As String, Brush As cBrush)
        Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, Filename, cFile.FileOptionsEnum.EmbedResource)
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLRoot As XmlElement = oXML.CreateElement("cbrush")
            Call Brush.GetBaseBrush.SaveTo(oFile, oXML, oXMLRoot)
            oXML.AppendChild(oXMLRoot)
            oFile.Save()
        End Using
    End Sub
    Private Sub btnPropSaveToSurvey_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropSaveToSurvey.ItemClick
        Call pSaveToSurvey()
    End Sub

    Private Sub btnPropSaveToFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropSaveToFile.ItemClick
        Call pSaveToFile()
    End Sub

    Private Sub pSaveToSurvey()
        Dim oBrush As cBrush = Item.Brush
        Dim sHash As String = cBrush.CalculateHash(oBrush)
        If oSurvey.Pens.Contains(sHash) Then
            Call cSurvey.UIHelpers.Dialogs.Msgbox("ALREADY EXIT")
        Else
            Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savepentext"), GetLocalizedString("main.savepentitle"), "")
            If sName IsNot Nothing Then
                Dim bOk As Boolean = True
                If oSurvey.Brushes.Contains(oBrush) Then
                    bOk = cSurvey.UIHelpers.Dialogs.Msgbox("OVERWRITE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savepentitle")) = MsgBoxResult.Yes
                End If
                If bOk Then
                    Dim oNewBrush As cCustomBrush = oSurvey.Brushes.Add(oBrush, sName)
                    cboPropBrushPattern.Rebind(oSurvey)
                    cboPropBrushPattern.EditValue = oNewBrush.ID
                End If
            End If
        End If
    End Sub

    Private Sub pSaveToFile()
        Dim oBrush As cBrush = Item.Brush
        Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savebrushtext"), GetLocalizedString("main.savebrushtitle"), "")
        If sName IsNot Nothing Then
            Dim bOk As Boolean = True
            Dim sFilename As String = IO.Path.Combine(modMain.GetUserApplicationPath, sName & ".cbrush")
            If My.Computer.FileSystem.FileExists(sFilename) Then
                bOk = cSurvey.UIHelpers.Dialogs.Msgbox("OVERWRITE?", MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savebrushtitle")) = MsgBoxResult.Yes
            End If
            If bOk Then
                Call pSaveBrush(sFilename, oBrush)
                cboPropBrushPattern.Rebind(oSurvey)
                cboPropBrushPattern.EditValue = oBrush.ID
            End If
        End If
        'End If
    End Sub

    Private Sub pExportToFile()
        Dim oBrush As cBrush = Item.Brush
        'Dim sHash As String = cPen.CalculateHash(oPen)
        'If oSurvey.Pens.Contains(sHash) Then
        '    Call cSurvey.UIHelpers.Dialogs.Msgbox("ALREADY EXIT")
        'Else
        Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savebrushtext"), GetLocalizedString("main.savebrushtitle"), "")
        If sName IsNot Nothing Then
            Dim bOk As Boolean = True
            Dim oResult As cSurvey.UIHelpers.Dialogs.cSaveFileDialogResult = cSurvey.UIHelpers.Dialogs.SaveFileDialog(Nothing, sName, GetLocalizedString("main.filetypeBRUSHX") & " (*.BRUSHX)|*.BRUSHX", 1, GetLocalizedString("main.exportbrushdialog"))
            If oResult.DialogResult = DialogResult.OK Then
                Dim sFilename As String = oResult.Filename
                Call pSaveBrush(sFilename, oBrush)
            End If
        End If
    End Sub

    Private Sub btnPropExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropExport.ItemClick
        Call pExportToFile()
    End Sub
End Class
