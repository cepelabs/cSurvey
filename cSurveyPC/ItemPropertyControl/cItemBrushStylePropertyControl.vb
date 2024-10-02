Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Navigation
Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.Data.Helpers
Imports DevExpress.XtraBars
Imports DevExpress.XtraTreeList
Imports DevExpress.XtraVerticalGrid.Events

Friend Class cItemBrushStylePropertyControl
    'Private oPaintOptions As cOptions
    Private oSurvey As cSurvey.cSurvey

    Private oPoint As cPoint

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent()
        cboPropBrushPatternType.Items.Clear()
        cboPropBrushPatternType.Items.AddRange(cPatternBrushHelper.GetGallery.Select(Function(oItem As Object) oItem).ToArray)
    End Sub

    Public Shadows Sub Rebind(Item As cItem, PaintOptions As cOptions)
        MyBase.Rebind(Item)

        If oSurvey IsNot Item.Survey Then
            oSurvey = Item.Survey
            Call cboPropBrushPattern.Rebind(oSurvey)
        End If

        If cboPropBrushPattern.EditValue = Item.Brush.ID AndAlso Item.Brush.Type = cBrush.BrushTypeEnum.Custom Then
            cboPropBrushPattern_EditValueChanged(cboPropBrushPattern, EventArgs.Empty)
        Else
            cboPropBrushPattern.EditValue = Item.Brush.ID
        End If
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
        Dim bPatternSettingsVisible As Boolean
        Dim bAlternativeColorVisible As Boolean
        Dim bBackgroundColorVisible As Boolean

        If Item.Brush.Type = cBrush.BrushTypeEnum.Custom Then
            Select Case Item.Brush.HatchType
                Case cBrush.HatchTypeEnum.Texture
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = True
                    bClipartSettingsVisible = False
                    bPatternSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = True
                    bBackgroundColorVisible = False
                Case cBrush.HatchTypeEnum.Pattern
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = False
                    bClipartSettingsVisible = False
                    bPatternSettingsVisible = True
                    bPatternVisible = True
                    bAlternativeColorVisible = True
                    bBackgroundColorVisible = True
                Case cBrush.HatchTypeEnum.Clipart
                    cmdPropBrushReseed.Visible = True

                    bStyleVisible = True
                    bClipartVisible = True
                    bTextureVisible = False
                    bClipartSettingsVisible = True
                    bPatternSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = True
                    bBackgroundColorVisible = True
                Case cBrush.HatchTypeEnum.Solid
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = False
                    bClipartSettingsVisible = False
                    bPatternSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = False
                    bBackgroundColorVisible = False
                Case Else
                    cmdPropBrushReseed.Visible = False

                    bStyleVisible = True
                    bClipartVisible = False
                    bTextureVisible = False
                    bClipartSettingsVisible = False
                    bPatternSettingsVisible = False
                    bPatternVisible = False
                    bAlternativeColorVisible = False
                    bBackgroundColorVisible = False
            End Select
        End If

        pnlBrushStyle.Visible = bStyleVisible
        pnlBrushAlternativeColor.Visible = bAlternativeColorVisible
        pnlBrushPattern.Visible = bPatternVisible
        pnlBrushClipart.Visible = bClipartVisible
        pnlBrushTexture.Visible = bTextureVisible
        pnlBrushClipartSettings.Visible = bClipartSettingsVisible
        pnlBrushPatternSettings.Visible = bPatternSettingsVisible
        pnlBrushBackgroundColor.Visible = bBackgroundColorVisible
        Height = (45 + If(bStyleVisible, pnlBrushStyle.Height, 0) + If(bClipartVisible, pnlBrushClipart.Height, 0) + If(bTextureVisible, pnlBrushTexture.Height, 0) + If(bClipartSettingsVisible, pnlBrushClipartSettings.Height, 0) + If(bPatternVisible, pnlBrushPattern.Height, 0) + If(bAlternativeColorVisible, pnlBrushAlternativeColor.Height, 0) + If(bBackgroundColorVisible, pnlBrushBackgroundColor.Height, 0) + If(bPatternSettingsVisible, pnlBrushPatternSettings.Height, 0)) * CurrentAutoScaleDimensions.Height / 96.0F
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
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternType")
            pGetCurrentPatternBrush.PatternType = cboPropBrushPatternType.SelectedItem.id
            Call MyBase.PropertyChanged("BrushPatternType")
            Call MyBase.MapInvalidate()

            Call pRefreshPatternProperties()
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
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternPenStyle")
            pGetCurrentPatternBrush.PatternPenStyle = cboPropBrushPatternPen.SelectedIndex
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

        Call pRefreshPatternProperties()
    End Sub

    Private Sub pRefreshPatternProperties()
        Dim bBackupDisabledObjectProperty As Boolean = MyBase.DisabledObjectProperty
        MyBase.DisabledObjectProperty = True
        If Item IsNot Nothing Then
            If Item.Brush.Type = cBrush.BrushTypeEnum.Custom Then
                btnPropCustomize.Enabled = False

                cmdPropSave.Visible = True
                cmdPropBrushReseed.Enabled = True

                cboPropBrushHatch.SelectedIndex = Item.Brush.HatchType
                txtPropBrushColor.EditValue = Item.Brush.Color
                txtPropBrushBackcolor.EditValue = Item.Brush.BackgroundColor

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

                txtPropBrushClipartDensity.Value = Item.Brush.ClipartDensity '* 100.0F
                txtPropBrushClipartZoomFactor.Value = Item.Brush.ClipartZoomFactor '* 1000.0F
                cboPropBrushClipartAngleMode.SelectedIndex = Item.Brush.ClipartAngleMode
                txtPropBrushClipartAngle.Value = Item.Brush.ClipartAngle

                cboPropBrushPatternType.SelectedItem = cPatternBrushHelper.GetGallery(pGetCurrentPatternBrush.PatternType)
                cboPropBrushPatternPen.SelectedIndex = pGetCurrentPatternBrush.PatternPenStyle
                txtPropBrushPatternDensity.Value = pGetCurrentPatternBrush.PatternDensity '* 100.0F
                cboPropBrushPatternAngleMode.SelectedIndex = pGetCurrentPatternBrush.PatternAngleMode
                txtPropBrushPatternAngle.Value = pGetCurrentPatternBrush.PatternAngle
                txtPropBrushPatternZoomFactor.Value = pGetCurrentPatternBrush.PatternZoomFactor '* 1000.0F
                txtPropBrushPatternDeltaX.Value = pGetCurrentPatternBrush.PatternDeltaX
                txtPropBrushPatternDeltaY.Value = pGetCurrentPatternBrush.PatternDeltaY
                prpPropBrushPatterParameters.SelectedObject = pGetCurrentPatternBrush.GetPatternInstance

                txtPropBrushAlternativeBrushColor.EditValue = Item.Brush.ClipartAlternativeColor
                cboPropBrushClipartPosition.SelectedIndex = Item.Brush.ClipartPosition
                txtPropBrushAlternativeBrushColor.EditValue = Item.Brush.ClipartAlternativeColor
                cboPropBrushClipartCrop.SelectedIndex = Item.Brush.ClipartCrop

                Call pBrushPatternRefresh()
            Else
                btnPropCustomize.Enabled = True

                cmdPropSave.Visible = False
                cmdPropBrushReseed.Visible = Item.Brush.HatchType = cBrush.HatchTypeEnum.Clipart
            End If
            Call pRefreshHeight()
        End If
        MyBase.DisabledObjectProperty = bBackupDisabledObjectProperty
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
        If oSurvey.Brushes.Contains(sHash) Then
            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savebrushalreadyexist"))
        Else
            Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savepentext"), GetLocalizedString("main.savepentitle"), "")
            If sName IsNot Nothing Then
                'Dim bOk As Boolean = True
                'If oSurvey.Brushes.Contains(oBrush) Then
                '    bOk = cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savebrushoverwritetext"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savepentitle")) = MsgBoxResult.Yes
                'End If
                'If bOk Then
                Using oNewBrush As cCustomBrush = oSurvey.Brushes.Add(oBrush, sName)
                    cboPropBrushPattern.Rebind(oSurvey)
                    cboPropBrushPattern.EditValue = oNewBrush.ID
                    MyBase.DoCommand("refreshbrushesandpens", {1, "brushes"})
                End Using
                'End If
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
                Using oNewBrush As cCustomBrush = oSurvey.Brushes.Add(oBrush, sName)
                    oNewBrush.Name = sName
                    Call pSaveBrush(sFilename, oNewBrush)
                    cboPropBrushPattern.Rebind(oSurvey)
                    cboPropBrushPattern.EditValue = oNewBrush.ID
                    MyBase.DoCommand("refreshbrushesandpens", {0, "brushes"})
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

    Private iCurrentPatternIndex As Integer

    Private Function pGetCurrentPatternBrush() As cIPatternBrush
        Return Item.Brush.PatternBrushes(iCurrentPatternIndex)
    End Function

    Private Sub pBrushPatternRefresh()
        Dim bEnabled As Boolean = Item.Brush.PatternBrushes.Count > 1
        btnPropPatternDelete.Enabled = bEnabled AndAlso iCurrentPatternIndex > 0
        btnPropPatternPrevious.Enabled = iCurrentPatternIndex > 0
        btnPropPatternNext.Enabled = iCurrentPatternIndex < Item.Brush.PatternBrushes.Count - 1
        btnPropPatternMoveDown.Enabled = iCurrentPatternIndex > 0
        btnPropPatternMoveUp.Enabled = iCurrentPatternIndex < Item.Brush.PatternBrushes.Count - 1
    End Sub

    Private Sub txtPropBrushPatternZoomFactor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushPatternZoomFactor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternZoomFactor")
            pGetCurrentPatternBrush.PatternZoomFactor = txtPropBrushPatternZoomFactor.Value '/ 1000.0F
            Call MyBase.PropertyChanged("BrushPatternZoomFactor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushClipartZoomFactor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartZoomFactor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartZoomFactor")
            Item.Brush.ClipartZoomFactor = txtPropBrushClipartZoomFactor.Value '/ 1000.0F
            Call MyBase.PropertyChanged("BrushClipartZoomFactor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushClipartDensity_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushClipartDensity.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.ClipartDensity")
            Item.Brush.ClipartDensity = txtPropBrushClipartDensity.Value '/ 100.0F
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

    Private Sub txtPropBrushPatternDensity_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushPatternDensity.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternDensity")
            pGetCurrentPatternBrush.PatternDensity = txtPropBrushPatternDensity.Value '/ 100.0F
            Call MyBase.PropertyChanged("BrushPatternDensity")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushPatternAngle_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushPatternAngle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternAngle")
            pGetCurrentPatternBrush.PatternAngle = txtPropBrushPatternAngle.Value
            Call MyBase.PropertyChanged("BrushPatternAngle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropBrushPatternngleMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropBrushPatternAngleMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternAngleMode")
            pGetCurrentPatternBrush.PatternAngleMode = cboPropBrushPatternAngleMode.SelectedIndex
            Call MyBase.PropertyChanged("BrushPatternAngleMode")
            Call MyBase.MapInvalidate()
        End If

        txtPropBrushPatternAngle.Enabled = pGetCurrentPatternBrush.PatternAngleMode = cBrush.PatternAngleModeEnum.Fixed
        lblPropBrushPatternAngle.Enabled = txtPropBrushPatternAngle.Enabled
    End Sub

    Private Sub pPatternAdd()
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
        Dim oPatterBrush As cPatternBrush = Item.Brush.PatternBrushes.Append()
        iCurrentPatternIndex = oPatterBrush.GetIndex
        Call pRefreshPatternProperties()
        Call MyBase.CommitUndoSnapshot()
        Call MyBase.PropertyChanged("BrushPatternAddPattern")
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub pPatternPrevious()
        If iCurrentPatternIndex > 0 Then
            iCurrentPatternIndex -= 1
            Call pRefreshPatternProperties()
        End If
    End Sub

    Private Sub pPatternNext()
        If iCurrentPatternIndex < Item.Brush.PatternBrushes.Count - 1 Then
            iCurrentPatternIndex += 1
            Call pRefreshPatternProperties()
        End If
    End Sub

    Private Sub pPatternDelete()
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
        Item.Brush.PatternBrushes.Remove(iCurrentPatternIndex)
        If iCurrentPatternIndex >= Item.Brush.PatternBrushes.Count Then
            iCurrentPatternIndex -= 1
        End If
        Call pRefreshPatternProperties()
        Call MyBase.CommitUndoSnapshot()
        Call MyBase.PropertyChanged("BrushPatternRemovePattern")
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdPropPatternDelete_Click(sender As Object, e As EventArgs)
        Call pPatternDelete()
    End Sub

    Private Sub txtPropBrushPatternDeltaY_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushPatternDeltaY.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternDeltaY")
            pGetCurrentPatternBrush.PatternDeltaY = txtPropBrushPatternDeltaY.Value
            Call MyBase.PropertyChanged("BrushPatternDeltaY")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropBrushPatternDeltaX_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushPatternDeltaX.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.PatternBrushes(" & iCurrentPatternIndex & ").PatternDeltaX")
            pGetCurrentPatternBrush.PatternDeltaX = txtPropBrushPatternDeltaX.Value
            Call MyBase.PropertyChanged("BrushPatternDeltaX")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pPatternMoveDown()
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
        Item.Brush.PatternBrushes.MoveTo(iCurrentPatternIndex - 1, pGetCurrentPatternBrush)
        iCurrentPatternIndex -= 1
        Call pRefreshPatternProperties()
        Call MyBase.CommitUndoSnapshot()
        Call MyBase.PropertyChanged("BrushPatternMovedDownPattern")
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub pPatternMoveUp()
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
        Item.Brush.PatternBrushes.MoveTo(iCurrentPatternIndex + 1, pGetCurrentPatternBrush)
        iCurrentPatternIndex += 1
        Call pRefreshPatternProperties()
        Call MyBase.CommitUndoSnapshot()
        Call MyBase.PropertyChanged("BrushPatternMovedUpPattern")
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdPropPatternMoveUp_Click(sender As Object, e As EventArgs)
        Call pPatternMoveUp()
    End Sub

    Private Sub prpPropBrushPatterParameters_CustomPropertyDescriptors(sender As Object, e As CustomPropertyDescriptorsEventArgs) Handles prpPropBrushPatterParameters.CustomPropertyDescriptors
        Dim oProperties As PropertyDescriptorCollection = e.Properties
        Dim oList As ArrayList = New ArrayList(oProperties)
        Dim oBase As cPatternBrushInstance = e.Source
        For Each oParameter In oBase.Base.Parameters
            Dim val1 As DynamicPropertyDescriptor = New DynamicPropertyDescriptor(oBase, oParameter.Name, oParameter.Caption, oParameter.GetRealType, Nothing)
            oList.Add(val1)
        Next
        Dim oResult As PropertyDescriptor() = New PropertyDescriptor(oList.Count - 1) {}
        oList.ToArray().CopyTo(oResult, 0)
        e.Properties = New PropertyDescriptorCollection(oResult)
    End Sub

    Private bEditStarted As Boolean

    Private Sub prpPropBrushPatterParameters_CellValueChanged(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles prpPropBrushPatterParameters.CellValueChanged
        If bEditStarted Then
            Call MyBase.CommitUndoSnapshot()
            bEditStarted = False
        End If
        Call MyBase.PropertyChanged("BrushPatternProperties")
        Call MyBase.MapInvalidate()

        bEditStarted = True
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
    End Sub

    Private Sub prpPropBrushPatterParameters_HiddenEditor(sender As Object, e As EventArgs) Handles prpPropBrushPatterParameters.HiddenEditor
        If bEditStarted Then
            Call MyBase.CancelUndoSnapshot()
        End If
    End Sub

    Private Sub prpPropBrushPatterParameters_ShownEditor(sender As Object, e As EventArgs) Handles prpPropBrushPatterParameters.ShownEditor
        bEditStarted = True
        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo33"))
    End Sub

    Private Sub btnPropPatternAdd_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropPatternAdd.ItemClick
        Call pPatternAdd()
    End Sub

    Private Sub btnPropPatternDelete_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropPatternDelete.ItemClick
        Call pPatternDelete()
    End Sub

    Private Sub btnPropPatternPrevious_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropPatternPrevious.ItemClick
        Call pPatternPrevious()
    End Sub

    Private Sub btnPropPatternNext_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropPatternNext.ItemClick
        Call pPatternNext()
    End Sub

    Private Sub btnPropPatternMoveDown_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropPatternMoveDown.ItemClick
        Call pPatternMoveDown()
    End Sub

    Private Sub btnPropPatternMoveUp_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropPatternMoveUp.ItemClick
        Call pPatternMoveUp()
    End Sub

    Private Sub txtPropBrushBackcolor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropBrushBackcolor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo33"), "Brush.BackgroundColor")
            Item.Brush.BackgroundColor = txtPropBrushBackcolor.EditValue
            Call MyBase.PropertyChanged("BrushPatternBackgroundColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub btnPropCustomize_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropCustomize.ItemClick
        cboPropBrushPattern.EditValue = "_99"
    End Sub

    Private Sub cboPropBrushPattern_OnGalleryButtonClick(sender As Object, e As EventArgs) Handles cboPropBrushPattern.OnGalleryButtonClick
        MyBase.DoCommand("brushesandpens")
    End Sub
End Class
