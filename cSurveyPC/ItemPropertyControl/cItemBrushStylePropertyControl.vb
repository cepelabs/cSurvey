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
    End Sub

    Private Sub cmdPropBrushReseed_Click(sender As Object, e As EventArgs) Handles cmdPropBrushReseed.Click
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo32"))
        Call Item.Brush.Seed.Reseed()
        Call MyBase.CommitUndoSnapshot()
        Call MyBase.PropertyChanged("BrushReseed")
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub pRefreshHeight()

        Dim bStyleVisible As Boolean
        Dim bPatternVisible As Boolean
        Dim bClipartVisible As Boolean
        Dim bTextureVisible As Boolean
        Dim bClipartSettingsVisible As Boolean
        Dim bClipartAndPatternSettingsVisible As Boolean
        Dim bAlternativeColorVisible As Boolean

        If Item.Brush.Type = cBrush.BrushTypeEnum.Custom Then
            Select Case Item.Brush.HatchType
                Case cBrush.HatchTypeEnum.Texture
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = True
                    bClipartSettingsVisible = False
                    bClipartAndPatternSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = True
                Case cBrush.HatchTypeEnum.Pattern
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = False
                    bClipartSettingsVisible = False
                    bClipartAndPatternSettingsVisible = True
                    bPatternVisible = True
                    bAlternativeColorVisible = True
                Case cBrush.HatchTypeEnum.Clipart
                    cmdPropBrushReseed.Visible = True

                    bStyleVisible = True
                    bClipartVisible = True
                    bTextureVisible = False
                    bClipartSettingsVisible = True
                    bClipartAndPatternSettingsVisible = True
                    bPatternVisible = False
                    bAlternativeColorVisible = True
                Case cBrush.HatchTypeEnum.Solid
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = False
                    bClipartSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = False
                Case Else
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = False
                    bClipartSettingsVisible = False
                    bClipartAndPatternSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = False
            End Select
        End If

        pnlBrushStyle.Visible = bStyleVisible
        pnlBrushAlternativeColor.Visible = bAlternativeColorVisible
        pnlBrushPattern.Visible = bPatternVisible
        pnlBrushClipart.Visible = bClipartVisible
        pnlBrushTexture.Visible = bTextureVisible
        pnlBrushClipartSettings.Visible = bClipartSettingsVisible
        pnlBrushClipartAnPatternSettings.Visible = bClipartAndPatternSettingsVisible = True

        Height = (45 + If(bStyleVisible, pnlBrushStyle.Height, 0) + If(bClipartVisible, pnlBrushClipart.Height, 0) + If(btexturevisible, pnlBrushTexture.Height, 0) + If(bClipartSettingsVisible, pnlBrushClipartSettings.Height, 0) + If(bPatternVisible, pnlBrushPattern.Height, 0) + If(bAlternativeColorVisible, pnlBrushAlternativeColor.Height, 0) + If(bClipartAndPatternSettingsVisible, pnlBrushClipartAnPatternSettings.Height, 0)) * CurrentAutoScaleDimensions.Height / 96.0F
    End Sub

    Private Sub cboPropBrushClipartPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushClipartPosition.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartPosition")
            Item.Brush.ClipartPosition = cboPropBrushClipartPosition.SelectedIndex
            Call MyBase.PropertyChanged("BrushClipartPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushPatternType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushPatternType.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternType")
            Item.Brush.PatternType = cboPropBrushPatternType.SelectedIndex
            Call MyBase.PropertyChanged("BrushPatternType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushClipartAngleMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushClipartAngleMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartAngleMode")
            Item.Brush.ClipartAngleMode = cboPropBrushClipartAngleMode.SelectedIndex
            Call MyBase.PropertyChanged("BrushClipartAngleMode")
            Call MyBase.MapInvalidate()
        End If

        txtPropBrushClipartAngle.Enabled = Item.Brush.ClipartAngleMode = cBrush.ClipartAngleModeEnum.Fixed
        lblPropBrushClipartAngle.Enabled = txtPropBrushClipartAngle.Enabled
    End Sub

    Private Sub txtPropBrushColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.Color")
            Item.Brush.Color = txtPropBrushColor.EditValue
            Call MyBase.PropertyChanged("BrushColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushPatternPen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushPatternPen.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternPenStyle")
            Item.Brush.PatternPenStyle = cboPropBrushPatternPen.SelectedIndex
            Call MyBase.PropertyChanged("BrushPatternPen")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushAlternativeBrushColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushAlternativeBrushColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartAlternativeColor")
            Item.Brush.ClipartAlternativeColor = txtPropBrushAlternativeBrushColor.EditValue
            Call MyBase.PropertyChanged("BrushAlternativeBrushColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cmdCompassBrowseClipart_Click(sender As Object, e As EventArgs) Handles cmdPropBrushBrowseClipart.Click
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("main.loadclipartdialog")
                .Filter = GetLocalizedString("main.filetypeSVG") & " (*.SVG)|*.SVG|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Try
                        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
                        Try
                            Dim oClipart As Drawings.cDrawClipArt = New Drawings.cDrawClipArt(.FileName)
                            Item.Brush.Clipart = oClipart
                            picPropBrushClipartImage.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile(.FileName)
                        Catch ex2 As Exception
                            Item.Brush.Clipart = Nothing
                            picPropBrushClipartImage.Image = Nothing
                        End Try
                        Call MyBase.CommitUndoSnapshot()
                        Call MyBase.PropertyChanged("BrushClipart")
                        Call MyBase.MapInvalidate()
                    Catch ex1 As Exception
                    End Try
                End If
            End With
        End Using
    End Sub

    Private Sub cboPropBrushPattern_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropBrushPattern.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
            If cBrush.IsUserBrushID(cboPropBrushPattern.EditValue) AndAlso Not oSurvey.Brushes.Contains(cboPropBrushPattern.EditValue) Then
                Call oSurvey.Brushes.Add(cboPropBrushPattern.GetUserBrush(cboPropBrushPattern.EditValue))
                Call cboPropBrushPattern.Rebind(oSurvey)
            End If
            Item.Brush.ID = cboPropBrushPattern.EditValue
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("BrushPattern")
            Call MyBase.MapInvalidate()
        End If


        If Item IsNot Nothing Then
            If Item.Brush.Type = cBrush.BrushTypeEnum.Custom Then
                cmdPropSave.Visible = True
                cmdPropBrushReseed.Enabled = True

                cboPropBrushHatch.SelectedIndex = Item.Brush.HatchType
                txtPropBrushColor.EditValue = Item.Brush.Color

                If Item.Brush.Clipart Is Nothing Then
                    picPropBrushClipartImage.SvgImage = Nothing
                Else
                    picPropBrushClipartImage.SvgImage = modDevExpress.SvgImageFromClipart(Item.Brush.Clipart)
                End If
                If Item.Brush.Texture Is Nothing Then
                    picPropBrushTextureImage.Image = Nothing
                Else
                    picPropBrushTextureImage.Image = Item.Brush.Texture
                End If

                txtPropBrushClipartDensity.Value = Item.Brush.ClipartDensity * 100.0F
                txtPropBrushClipartZoomFactor.Value = Item.Brush.ClipartZoomFactor * 1000.0F
                cboPropBrushClipartAngleMode.SelectedIndex = Item.Brush.ClipartAngleMode
                txtPropBrushClipartAngle.Value = Item.Brush.ClipartAngle
                cboPropBrushPatternType.SelectedIndex = Item.Brush.PatternType
                cboPropBrushPatternPen.SelectedIndex = Item.Brush.PatternPenStyle
                txtPropBrushAlternativeBrushColor.EditValue = Item.Brush.ClipartAlternativeColor
                cboPropBrushClipartPosition.SelectedIndex = Item.Brush.ClipartPosition
                txtPropBrushAlternativeBrushColor.EditValue = Item.Brush.ClipartAlternativeColor
                cboPropBrushClipartCrop.SelectedIndex = Item.Brush.ClipartCrop
            Else
                cmdPropSave.Visible = False
                cmdPropBrushReseed.Visible = Item.Brush.HatchType = cBrush.HatchTypeEnum.Clipart
            End If
            Call pRefreshHeight()
        End If
    End Sub

    Private Sub cboPropBrushClipartCrop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushClipartCrop.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartCrop")
            Item.Brush.ClipartCrop = cboPropBrushClipartCrop.SelectedIndex
            Call MyBase.PropertyChanged("BrushClipartCrop")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pSaveBrush(Filename As String, Brush As cCustomBrush)
        Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, Filename, cFile.FileOptionsEnum.EmbedResource)
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLRoot As XmlElement = oXML.CreateElement("cbrush")
            Call Brush.SaveTo(oFile, oXML, oXMLRoot)
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
            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savebrushalreadyexist"))
        Else
            Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savepentext"), GetLocalizedString("main.savepentitle"), "")
            If sName IsNot Nothing Then
                Dim bOk As Boolean = True
                If oSurvey.Brushes.Contains(oBrush) Then
                    bOk = cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savebrushoverwritetext"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savepentitle")) = MsgBoxResult.Yes
                End If
                If bOk Then
                    Using oNewBrush As cCustomBrush = oSurvey.Brushes.Add(oBrush, sName)
                        cboPropBrushPattern.Rebind(oSurvey)
                        cboPropBrushPattern.EditValue = oNewBrush.ID
                    End Using
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
                bOk = cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savebrushoverwritetext"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savebrushtitle")) = MsgBoxResult.Yes
            End If
            If bOk Then
                Using oNewBrush As cCustomBrush = cCustomBrush.CopyAsUser(oSurvey, oBrush.GetBaseBrush)
                    oNewBrush.Name = sName
                    Call pSaveBrush(sFilename, oNewBrush)
                    cboPropBrushPattern.Rebind(oSurvey)
                    cboPropBrushPattern.EditValue = oBrush.ID
                End Using
            End If
        End If
    End Sub

    Private Sub pExportToFile()
        Dim oBrush As cBrush = Item.Brush
        Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savebrushtext"), GetLocalizedString("main.savebrushtitle"), "")
        If sName IsNot Nothing Then
            Dim bOk As Boolean = True
            Dim oResult As cSurvey.UIHelpers.Dialogs.cSaveFileDialogResult = cSurvey.UIHelpers.Dialogs.SaveFileDialog(Nothing, sName, GetLocalizedString("main.filetypeBRUSHX") & " (*.BRUSHX)|*.BRUSHX", 1, GetLocalizedString("main.exportbrushdialog"))
            If oResult.DialogResult = DialogResult.OK Then
                Dim sFilename As String = oResult.Filename
                Call pSaveBrush(sFilename, oBrush.GetBaseBrush)
            End If
        End If
    End Sub

    Private Sub btnPropExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropExport.ItemClick
        Call pExportToFile()
    End Sub

    Private Sub txtPropBrushClipartZoomFactor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartZoomFactor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartZoomFactor")
            Item.Brush.ClipartZoomFactor = txtPropBrushClipartZoomFactor.Value / 1000.0F
            Call MyBase.PropertyChanged("BrushClipartZoomFactor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushClipartDensity_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartDensity.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartDensity")
            Item.Brush.ClipartDensity = txtPropBrushClipartDensity.Value / 100.0F
            Call MyBase.PropertyChanged("BrushClipartDensity")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushClipartAngle_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartAngle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartAngle")
            Item.Brush.ClipartAngle = txtPropBrushClipartAngle.Value
            Call MyBase.PropertyChanged("BrushClipartAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushHatch_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropBrushHatch.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
            Item.Brush.HatchType = cboPropBrushHatch.SelectedIndex
            If Item.Brush.HatchType = cBrush.HatchTypeEnum.Clipart Then
                Item.Brush.Clipart = modDevExpress.SvgImageToClipart(picPropBrushClipartImage.SvgImage)
            ElseIf Item.Brush.HatchType = cBrush.HatchTypeEnum.Texture Then
                Item.Brush.Texture = picPropBrushTextureImage.Image
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("BrushHatch")
            Call MyBase.MapInvalidate()
        End If

        Call pRefreshHeight()
    End Sub

    Private Sub cmdPropBrushBrowseTexture_Click(sender As Object, e As EventArgs) Handles cmdPropBrushBrowseTexture.Click
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("main.loadtexturedialog")
                .Filter = GetLocalizedString("main.filetypePNG") & " (*.PNG)|*.PNG|" & GetLocalizedString("main.filetypeBMP") & " (*.BMP)|*.BMP|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    'TODO: in undo support property of image/svg type
                    Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
                    Item.Brush.Texture = modPaint.SafeBitmapFromFileUnlocked(.FileName)
                    picPropBrushTextureImage.Image = Item.Brush.Texture
                    Call MyBase.CommitUndoSnapshot()
                    Call MyBase.PropertyChanged("BrushTexture")
                    Call MyBase.MapInvalidate()
                End If
            End With
        End Using
    End Sub
End Class
