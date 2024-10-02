Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraTreeList

Friend Class cItemPenStylePropertyControl
    'Private oPaintOptions As cOptions
    Private oSurvey As cSurvey.cSurvey

    Private oPoint As cPoint

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
    End Sub

    Public Shadows ReadOnly Property Item As cItem
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItem, Point As cPoint, PaintOptions As cOptions)
        MyBase.Rebind(Item)

        'If oPaintOptions IsNot PaintOptions Then
        '    oPaintOptions = PaintOptions
        '    Call cboPropPenPattern.Rebind(oPaintOptions)
        'End If
        If oSurvey IsNot Item.Survey Then
            oSurvey = Item.Survey
            Call cboPropPenPattern.Rebind(oSurvey)
        End If

        oPoint = pGetPoint(Point)

        If oPoint Is Nothing Then
            If cboPropPenPattern.EditValue = Item.Pen.ID Then
                cboPropPenPattern_EditValueChanged(cboPropPenPattern, EventArgs.Empty)
            Else
                cboPropPenPattern.EditValue = Item.Pen.ID
            End If
        Else
            Dim oPen As cPen = pGetPointPen()
            If cboPropPenPattern.EditValue = oPen.ID Then
                cboPropPenPattern_EditValueChanged(cboPropPenPattern, EventArgs.Empty)
            Else
                cboPropPenPattern.EditValue = oPen.ID
            End If
        End If
    End Sub

    Private Function pGetPointPen() As cPen
        Dim oPen As cPen
        If oPoint.BeginSequence Then
            oPen = oPoint.Pen
            If oPen Is Nothing Then oPen = Item.Pen
        Else
            Dim oSequence As cSequence = Item.Points.GetSequence(oPoint)
            If oSequence Is Nothing Then
                oPen = Item.Pen
            Else
                oPen = oPoint.Pen
                If oPen Is Nothing Then oPen = Item.Pen
            End If
        End If
        Return oPen
    End Function

    Private Sub cboPropPenPattern_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenPattern.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                If cPen.IsUserPenID(cboPropPenPattern.EditValue) AndAlso Not oSurvey.Pens.Contains(cboPropPenPattern.EditValue) Then
                    Call oSurvey.Pens.Add(cboPropPenPattern.GetUserPen(cboPropPenPattern.EditValue))
                    Call cboPropPenPattern.Rebind(oSurvey)
                End If
                Item.Pen.ID = cboPropPenPattern.EditValue
            Else
                Call pObjectSetSequencePen()
                If cPen.IsUserPenID(cboPropPenPattern.EditValue) AndAlso Not oSurvey.Pens.Contains(cboPropPenPattern.EditValue) Then
                    Call oSurvey.Pens.Add(cboPropPenPattern.GetUserPen(cboPropPenPattern.EditValue))
                    Call cboPropPenPattern.Rebind(oSurvey)
                End If
                oPoint.Pen.ID = cboPropPenPattern.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenPattern")
            Call MyBase.MapInvalidate()
        End If

        If Item IsNot Nothing Then
            Dim oPen As cPen
            If oPoint Is Nothing Then
                oPen = Item.Pen
            Else
                Call pObjectSetSequencePen()
                oPen = oPoint.Pen
            End If
            If oPen.Type = cPen.PenTypeEnum.Custom Then
                cmdPropSave.Visible = True
                txtPropPenWidth.Value = oPen.Width
                txtPropPenColor.EditValue = oPen.Color
                cboPropPenStyle.SelectedIndex = pPenStyleToSelectedIndex(cboPropPenStyle, oPen.Style)
                If oPen.LineJoin = cPen.PenLineJoinEnum.Rounded Then
                    chkPropPenLineJoin2.Checked = True
                ElseIf oPen.LineJoin = cPen.PenLineJoinEnum.Mitered Then
                    chkPropPenLineJoin0.Checked = True
                Else
                    chkPropPenLineJoin1.Checked = True
                End If
                If oPen.LineCap = cPen.PenLineCapEnum.Rounded Then
                    chkPropPenLineCap2.Checked = True
                ElseIf oPen.LineCap = cPen.PenLineCapEnum.Squared Then
                    chkPropPenLineCap1.Checked = True
                Else
                    chkPropPenLineCap0.Checked = True
                End If
                cmdDashStyle.Visible = oPen.Style = cPen.PenStylesEnum.Custom
                cboPropPenDecoration.SelectedIndex = oPen.DecorationStyle
                cboPropPenDecorationAlignment.SelectedIndex = oPen.DecorationAlignment
                cboPropPenDecorationPosition.SelectedIndex = oPen.DecorationPosition
                If oPen.Clipart Is Nothing OrElse oPen.Clipart.IsEmpty Then
                    picPropPenClipartImage.SvgImage = Nothing
                Else
                    picPropPenClipartImage.SvgImage = modDevExpress.SvgImageFromClipart(oPen.Clipart)
                End If
                Try : txtPropPenDecorationSpacePercentage.Value = oPen.DecorationSpacePercentage : Catch : End Try
                Try : txtPropPenDecorationScale.Value = oPen.DecorationScale : Catch : End Try

                cboPropPenClipartPenMode.SelectedIndex = oPen.ClipartPenMode

                cboPropPenClipartPenStyle.SelectedIndex = pPenStyleToSelectedIndex(cboPropPenClipartPenStyle, oPen.ClipartPenStyle)
                cmdClipartDashStyle.Visible = oPen.ClipartPenStyle = cPen.PenStylesEnum.Custom
                txtPropPenClipartPenWidth.EditValue = oPen.ClipartPenWidth
                txtPropPenClipartPenColor.EditValue = oPen.ClipartPenColor
                If oPen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Rounded Then
                    chkPropPenClipartPenLineJoin2.Checked = True
                ElseIf oPen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered Then
                    chkPropPenClipartPenLineJoin0.Checked = True
                Else
                    chkPropPenClipartPenLineJoin1.Checked = True
                End If
                If oPen.ClipartPenLineCap = cPen.PenLineCapEnum.Rounded Then
                    chkPropPenClipartPenLineCap2.Checked = True
                ElseIf oPen.ClipartPenLineCap = cPen.PenLineCapEnum.Squared Then
                    chkPropPenClipartPenLineCap1.Checked = True
                Else
                    chkPropPenClipartPenLineCap0.Checked = True
                End If

                cboPropPenClipartBrushMode.SelectedIndex = oPen.ClipartBrushMode
                cboPropPenClipartBrushStyle.SelectedIndex = pPenStyleToSelectedIndex(cboPropPenClipartBrushStyle, oPen.ClipartBrushStyle)
                txtPropPenClipartBrushColor.EditValue = oPen.ClipartBrushColor
            Else
                cmdPropSave.Visible = False
            End If
            Call pRefreshHeight()
        End If
    End Sub

    Private Function pGetPoint(Point As cPoint) As cPoint
        If Point Is Nothing Then
            Return Nothing
        Else
            Return Me.Item.Points.GetSequence(Point).First
        End If
    End Function

    Private Sub txtPropPenColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.Color = txtPropPenColor.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.Color = txtPropPenColor.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pObjectSetSequencePen()
        With oPoint
            If .Pen Is Nothing Then
                .Pen = New cPen(MyBase.Item.Survey, MyBase.Item.Pen)
            End If
        End With
    End Sub

    Private Function pGetPen() As cPen
        If oPoint Is Nothing Then
            Return Item.Pen
        Else
            Return pGetPointPen()
        End If
    End Function

    Private Sub pSavePen(Filename As String, Pen As cCustomPen)
        Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, Filename, cFile.FileOptionsEnum.EmbedResource)
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLRoot As XmlElement = oXML.CreateElement("cpen")
            Call Pen.SaveTo(oFile, oXML, oXMLRoot)
            oXML.AppendChild(oXMLRoot)
            oFile.Save()
        End Using
    End Sub

    Private Sub cmdPropPenSave_Click(sender As Object, e As EventArgs) Handles cmdPropSave.Click
        Call pSaveToSurvey()
    End Sub

    Private Sub btnPropSaveToSurvey_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropSaveToSurvey.ItemClick
        Call pSaveToSurvey()
    End Sub

    Private Sub btnPropSaveToFile_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropSaveToFile.ItemClick
        Call pSaveToFile()
    End Sub

    Private Sub pSaveToSurvey()
        Dim oPen As cPen = pGetPen()
        Dim sHash As String = cPen.CalculateHash(oPen)
        If oSurvey.Pens.Contains(sHash) Then
            Call cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savepenalreadyexist"))
        Else
            Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savepentext"), GetLocalizedString("main.savepentitle"), "")
            If sName IsNot Nothing Then
                'Dim bOk As Boolean = True
                'If oSurvey.Pens.Contains(sName) Then
                '    bOk = cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savepenoverwritetext"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savepentitle")) = MsgBoxResult.Yes
                'End If
                'If bOk Then
                Using oNewPen As cCustomPen = oSurvey.Pens.Add(oPen, sName)
                    cboPropPenPattern.Rebind(oSurvey)
                    cboPropPenPattern.EditValue = oNewPen.ID
                    MyBase.DoCommand("refreshbrushesandpens", {1, "pens"})
                End Using
                'End If
            End If
        End If
    End Sub

    Private Sub pSaveToFile()
        Dim oPen As cPen = pGetPen()
        Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savepentext"), GetLocalizedString("main.savepentitle"), "")
        If sName IsNot Nothing Then
            Dim bOk As Boolean = True
            Dim sFilename As String = IO.Path.Combine(modMain.GetUserApplicationPath, sName & ".cpen")
            If My.Computer.FileSystem.FileExists(sFilename) Then
                bOk = cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savepenoverwritetext"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savepentitle")) = MsgBoxResult.Yes
            End If
            If bOk Then
                Using oNewPen As cCustomPen = cCustomPen.CopyAsUser(oSurvey, oPen.GetBasePen)
                    oNewPen.Name = sName
                    Call pSavePen(sFilename, oNewPen)
                    cboPropPenPattern.Rebind(oSurvey)
                    cboPropPenPattern.EditValue = oPen.ID
                    MyBase.DoCommand("refreshbrushesandpens", {0, "pens"})
                End Using
            End If
        End If
    End Sub

    Private Sub pExportToFile()
        Dim oPen As cPen = pGetPen()
        Dim sName As String = cSurvey.UIHelpers.Dialogs.TextInputBox(Me, GetLocalizedString("main.savepentext"), GetLocalizedString("main.savepentitle"), "")
        If sName IsNot Nothing Then
            Dim bOk As Boolean = True
            Dim oResult As cSurvey.UIHelpers.Dialogs.cSaveFileDialogResult = cSurvey.UIHelpers.Dialogs.SaveFileDialog(Nothing, sName, GetLocalizedString("main.filetypePENX") & " (*.PENX)|*.PENX", 1, GetLocalizedString("main.exportpendialog"))
            If oResult.DialogResult = DialogResult.OK Then
                Dim sFilename As String = oResult.Filename
                Call pSavePen(sFilename, oPen.GetBasePen)
            End If
        End If
    End Sub

    Private Sub btnPropExport_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPropExport.ItemClick
        Call pExportToFile()
    End Sub

    Private Sub cmdPropPenBrowseClipart_Click(sender As Object, e As EventArgs) Handles cmdPropPenBrowseClipart.Click
        Using oOfd As OpenFileDialog = New OpenFileDialog
            With oOfd
                .Title = GetLocalizedString("main.loadclipartdialog")
                .Filter = GetLocalizedString("main.filetypeSVG") & " (*.SVG)|*.SVG|" & GetLocalizedString("main.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Try
                        Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                        Try
                            Dim oClipart As Drawings.cDrawClipArt = New Drawings.cDrawClipArt(.FileName)
                            If oPoint Is Nothing Then
                                Item.Pen.Clipart = oClipart
                            Else
                                Call pObjectSetSequencePen()
                                oPoint.Pen.Clipart = oClipart
                            End If
                            picPropPenClipartImage.SvgImage = modDevExpress.SvgImageFromClipart(oClipart)
                        Catch
                            If oPoint Is Nothing Then
                                Item.Pen.Clipart = Nothing
                            Else
                                Call pObjectSetSequencePen()
                                oPoint.Pen.Clipart = Nothing
                            End If
                            picPropPenClipartImage.Image = Nothing
                        End Try
                        Call MyBase.CommitUndoSnapshot()
                        Call MyBase.PropertyChanged("BrushClipart")
                        Call MyBase.MapInvalidate()
                    Catch
                    End Try
                End If
            End With
        End Using
    End Sub

    Private Sub cboPropPenDecoration_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenDecoration.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.DecorationStyle = cboPropPenDecoration.SelectedIndex
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.DecorationStyle = cboPropPenDecoration.SelectedIndex
            End If
            Call pRefreshHeight()
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenDecoration")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub pRefreshHeight()
        Dim oPen As cPen = pGetPen()

        Dim bStyleVisible As Boolean
        Dim bClipartVisible As Boolean
        Dim bClipartSettingsVisible As Boolean
        Dim bClipartSettingsPenVisible As Boolean
        Dim bClipartSettingsBrushVisible As Boolean

        If oPen.Type = cPen.PenTypeEnum.Custom Then
            If cboPropPenDecoration.SelectedIndex > 0 Then
                bStyleVisible = True
                If cboPropPenDecoration.SelectedIndex = cboPropPenDecoration.Properties.Items.Count - 1 Then
                    bClipartVisible = True
                Else
                    bClipartVisible = False
                End If
                bClipartSettingsVisible = True
                bClipartSettingsPenVisible = cboPropPenClipartPenMode.SelectedIndex = 1
                bClipartSettingsBrushVisible = cboPropPenClipartBrushMode.SelectedIndex = 1
            Else
                bStyleVisible = True
                bClipartVisible = False
                bClipartSettingsVisible = False
                bClipartSettingsPenVisible = False
                bClipartSettingsBrushVisible = False
            End If
        Else
            bStyleVisible = False
            bClipartVisible = False
            pnlPenClipartSettings.Visible = False
            pnlPenClipartSettings1.Visible = False
            bClipartSettingsPenVisible = False
            bClipartSettingsBrushVisible = False
        End If

        pnlPenStyle.Visible = bStyleVisible
        pnlPenClipart.Visible = bClipartVisible
        pnlPenClipartSettings.Visible = bClipartSettingsVisible
        pnlPenClipartSettings1.Visible = bClipartSettingsVisible
        pnlPenClipartSettingsPen.Visible = bClipartSettingsPenVisible
        pnlPenClipartSettingsBrush.Visible = bClipartSettingsBrushVisible

        Height = (45 + If(bStyleVisible, pnlPenStyle.Height, 0) + If(bClipartVisible, pnlPenClipart.Height, 0) + If(bClipartSettingsVisible, pnlPenClipartSettings.Height + pnlPenClipartSettings1.Height, 0) + If(bClipartSettingsPenVisible, pnlPenClipartSettingsPen.Height, 0) + If(bClipartSettingsBrushVisible, pnlPenClipartSettingsBrush.Height, 0)) * CurrentAutoScaleDimensions.Height / 96.0F
    End Sub

    Private Sub cmdPropPenCleanClipart_Click(sender As Object, e As EventArgs) Handles cmdPropPenCleanClipart.Click
        If oPoint Is Nothing Then
            Item.Pen.Clipart = Nothing
        Else
            Call pObjectSetSequencePen()
            oPoint.Pen.Clipart = Nothing
        End If
        picPropPenClipartImage.Image = Nothing
    End Sub

    Private Sub txtPropPenWidth_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenWidth.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.Width = txtPropPenWidth.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.Width = txtPropPenWidth.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenWidth")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropPenStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenStyle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.Style = pSelectedIndexToPenStyle(cboPropPenStyle)
                cmdDashStyle.Visible = Item.Pen.Style = cPen.PenStylesEnum.Custom
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.Style = pSelectedIndexToPenStyle(cboPropPenStyle)
                cmdDashStyle.Visible = oPoint.Pen.Style = cPen.PenStylesEnum.Custom
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenStyle")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropPenDecorationAlignment_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenDecorationAlignment.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.DecorationAlignment = cboPropPenDecorationAlignment.SelectedIndex
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.DecorationAlignment = cboPropPenDecorationAlignment.SelectedIndex
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenDecorationAlignment")
            Call MyBase.MapInvalidate()
        End If
        Dim bEnabled As Boolean
        If oPoint Is Nothing Then
            bEnabled = Item.Pen.DecorationAlignment <> cPen.DecorationAlignmentEnum.Center
        Else
            bEnabled = oPoint.Pen.DecorationAlignment <> cPen.DecorationAlignmentEnum.Center
        End If
        txtPropPenDecorationDistancePercentage.Enabled = bEnabled
        lblPropPenDecorationDistancePercentage.Enabled = bEnabled
    End Sub

    Private Sub txtPropPenDecorationDistancePercentage_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenDecorationDistancePercentage.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.DecorationDistancePercentage = txtPropPenDecorationDistancePercentage.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.DecorationDistancePercentage = txtPropPenDecorationDistancePercentage.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenDecorationDistancePercentage")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPenDecorationSpacePercentage_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenDecorationSpacePercentage.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.DecorationSpacePercentage = txtPropPenDecorationSpacePercentage.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.DecorationSpacePercentage = txtPropPenDecorationSpacePercentage.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenDecorationSpacePercentage")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPenDecorationScale_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenDecorationScale.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.DecorationScale = txtPropPenDecorationScale.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.DecorationScale = txtPropPenDecorationScale.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenDecorationSpacePercentage")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropPenClipartPenMode_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenClipartPenMode.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            Dim oPen As cPen
            If oPoint Is Nothing Then
                oPen = Item.Pen
            Else
                Call pObjectSetSequencePen()
                oPen = oPoint.Pen
            End If
            oPen.ClipartPenMode = cboPropPenClipartPenMode.SelectedIndex
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartPenMode")
            Call MyBase.MapInvalidate()
        End If
        Call pRefreshHeight()
    End Sub

    Private Sub txtPropPenClipartPenWidth_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenClipartPenWidth.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.ClipartPenWidth = txtPropPenClipartPenWidth.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.ClipartPenWidth = txtPropPenClipartPenWidth.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartPenWidth")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPenClipartBrushColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenClipartBrushColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.ClipartBrushColor = txtPropPenClipartBrushColor.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.ClipartBrushColor = txtPropPenClipartBrushColor.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartBrushColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropPenClipartPenColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropPenClipartPenColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.ClipartPenColor = txtPropPenClipartPenColor.EditValue
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.ClipartPenColor = txtPropPenClipartPenColor.EditValue
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartPenColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Function pPenStyleToSelectedIndex(ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit, PenStyle As cPen.PenStylesEnum) As Integer
        'for now custom pens are not managed
        Dim iCount As Integer = ComboBoxEdit.Properties.Items.Count
        If PenStyle = cPen.PenStylesEnum.None Then
            Return iCount - 2
        ElseIf PenStyle = cPen.PenStylesEnum.custom Then
            Return iCount - 1
        Else
            Return PenStyle
        End If
    End Function

    Private Function pBrushStyleToSelectedIndex(ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit, PenStyle As cPen.BrushStylesEnum) As Integer
        'for now custom brushes are not managed
        Dim iCount As Integer = ComboBoxEdit.Properties.Items.Count
        If PenStyle = cPen.BrushStylesEnum.None Then
            Return iCount - 1
        Else
            Return PenStyle
        End If
    End Function

    Private Function pSelectedIndexToBrushStyle(ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit) As cPen.BrushStylesEnum
        'for now custom brushes are not managed
        Dim iCount As Integer = ComboBoxEdit.Properties.Items.Count
        Dim iSelected As Integer = ComboBoxEdit.SelectedIndex
        If iSelected < iCount - 2 Then
            Return iSelected
        Else
            Return cPen.BrushStylesEnum.None
        End If
    End Function

    Private Function pSelectedIndexToPenStyle(ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit) As cPen.PenStylesEnum
        'for now custom pens are not managed
        Dim iCount As Integer = ComboBoxEdit.Properties.Items.Count
        Dim iSelected As Integer = ComboBoxEdit.SelectedIndex
        If iSelected < iCount - 2 Then
            Return iSelected
        ElseIf iSelected = iCount - 2 Then
            Return cPen.PenStylesEnum.None
        ElseIf iSelected = iCount - 1 Then
            Return cPen.PenStylesEnum.Custom
        End If
    End Function

    Private Sub cboPropPenClipartPenStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenClipartPenStyle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.ClipartPenStyle = pSelectedIndexToPenStyle(cboPropPenClipartPenStyle)
                cmdClipartDashStyle.Visible = Item.Pen.ClipartPenStyle = cPen.PenStylesEnum.Custom
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.ClipartPenStyle = pSelectedIndexToPenStyle(cboPropPenClipartPenStyle)
                cmdClipartDashStyle.Visible = Item.Pen.ClipartPenStyle = cPen.PenStylesEnum.Custom
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartPenStyle")
            Call MyBase.MapInvalidate()
        End If
        If pSelectedIndexToPenStyle(cboPropPenClipartPenStyle) = cPen.PenStylesEnum.None OrElse pSelectedIndexToPenStyle(cboPropPenClipartPenStyle) = cPen.PenStylesEnum.Custom Then
            lblPropPenClipartPenColor.Enabled = False
            txtPropPenClipartPenColor.Enabled = False
            lblPropPenClipartPenWidth.Enabled = False
            txtPropPenClipartPenWidth.Enabled = False
        Else
            lblPropPenClipartPenColor.Enabled = True
            txtPropPenClipartPenColor.Enabled = True
            lblPropPenClipartPenWidth.Enabled = True
            txtPropPenClipartPenWidth.Enabled = True
        End If
    End Sub

    Private Sub cboPropPenDecorationPosition_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenDecorationPosition.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.DecorationPosition = cboPropPenDecorationPosition.SelectedIndex
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.DecorationPosition = cboPropPenDecorationPosition.SelectedIndex
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("PenDecorationPosition")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropPenClipartBrushMode_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenClipartBrushMode.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            Dim oPen As cPen
            If oPoint Is Nothing Then
                oPen = Item.Pen
            Else
                Call pObjectSetSequencePen()
                oPen = oPoint.Pen
            End If
            oPen.ClipartBrushMode = cboPropPenClipartBrushMode.SelectedIndex
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartBrushMode")
            Call MyBase.MapInvalidate()
        End If
        Call pRefreshHeight()
    End Sub

    Private Sub cboPropPenClipartBrushStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenClipartBrushStyle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.ClipartBrushStyle = pSelectedIndexToBrushStyle(cboPropPenClipartBrushStyle)
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.ClipartBrushStyle = pSelectedIndexToBrushStyle(cboPropPenClipartBrushStyle)
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartBrushStyle")
            Call MyBase.MapInvalidate()
        End If
        If pSelectedIndexToBrushStyle(cboPropPenClipartBrushStyle) = cPen.BrushStylesEnum.None Then
            lblPropPenClipartBrushColor.Enabled = False
            txtPropPenClipartBrushColor.Enabled = False
        Else
            lblPropPenClipartBrushColor.Enabled = True
            txtPropPenClipartBrushColor.Enabled = True
        End If
    End Sub

    Private Sub oDashEditor_OnMapInvalidate(Sender As Object, e As EventArgs)
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub cmdDashStyle_Click(sender As Object, e As EventArgs) Handles cmdDashStyle.Click
        If Not DisabledObjectProperty() Then
            Dim oParameters As frmDashPatternEditor
            If pnlParameters.Controls.Count = 0 Then
                oParameters = New frmDashPatternEditor()
                pnlParameters.Controls.Add(oParameters)
                AddHandler oParameters.OnMapInvalidate, AddressOf oDashEditor_OnMapInvalidate
            Else
                oParameters = pnlParameters.Controls(0)
            End If
            flyParameters.OwnerControl = cmdDashStyle
            oParameters.Dock = DockStyle.None
            Call oParameters.Rebind(Me.Item, frmDashPatternEditor.PenDashContextEnum.MainPen)
            flyParameters.Size = oParameters.Size
            oParameters.Dock = DockStyle.Fill
            flyParameters.ShowBeakForm(True)
        End If
    End Sub

    Private Sub cmdClipartDashStyle_Click(sender As Object, e As EventArgs) Handles cmdClipartDashStyle.Click
        If Not DisabledObjectProperty() Then
            Dim oParameters As frmDashPatternEditor
            If pnlParameters.Controls.Count = 0 Then
                oParameters = New frmDashPatternEditor()
                pnlParameters.Controls.Add(oParameters)
                AddHandler oParameters.OnMapInvalidate, AddressOf oDashEditor_OnMapInvalidate
            Else
                oParameters = pnlParameters.Controls(0)
            End If
            flyParameters.OwnerControl = cmdClipartDashStyle
            oParameters.Dock = DockStyle.None
            Call oParameters.Rebind(Me.Item, frmDashPatternEditor.PenDashContextEnum.ClipartPen)
            flyParameters.Size = oParameters.Size
            oParameters.Dock = DockStyle.Fill
            flyParameters.ShowBeakForm(True)
        End If
    End Sub

    Private Sub chkPropPenLineJoin2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenLineJoin2.CheckedChanged
        If chkPropPenLineJoin2.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.LineJoin = cPen.PenLineJoinEnum.Rounded
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.LineJoin = cPen.PenLineJoinEnum.Rounded
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineJoin")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenLineJoin0_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenLineJoin0.CheckedChanged
        If chkPropPenLineJoin0.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.LineJoin = cPen.PenLineJoinEnum.Mitered
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.LineJoin = cPen.PenLineJoinEnum.Mitered
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineJoin")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenLineJoin1_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenLineJoin1.CheckedChanged
        If chkPropPenLineJoin1.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.LineJoin = cPen.PenLineJoinEnum.Bevelled
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.LineJoin = cPen.PenLineJoinEnum.Bevelled
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineJoin")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenLineCap2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenLineCap2.CheckedChanged
        If chkPropPenLineCap2.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.LineCap = cPen.PenLineCapEnum.Rounded
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.LineCap = cPen.PenLineCapEnum.Rounded
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineCap")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenLineCap1_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenLineCap1.CheckedChanged
        If chkPropPenLineCap1.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.LineCap = cPen.PenLineCapEnum.Squared
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.LineCap = cPen.PenLineCapEnum.Squared
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineCap")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenLineCap0_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenLineCap0.CheckedChanged
        If chkPropPenLineCap0.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.LineCap = cPen.PenLineCapEnum.Flat
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.LineCap = cPen.PenLineCapEnum.Flat
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("LineCap")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenClipartPenLineJoin2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenClipartPenLineJoin2.CheckedChanged
        If chkPropPenClipartPenLineJoin2.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Rounded
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Rounded
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("ClipartPenLineJoin")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenClipartPenLineJoin0_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenClipartPenLineJoin0.CheckedChanged
        If chkPropPenClipartPenLineJoin0.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Mitered
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("ClipartPenLineJoin")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenClipartPenLineJoin1_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenClipartPenLineJoin1.CheckedChanged
        If chkPropPenClipartPenLineJoin1.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Bevelled
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.ClipartPenLineJoin = cPen.PenLineJoinEnum.Bevelled
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("ClipartPenLineJoin")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenClipartPenLineCap2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenClipartPenLineCap2.CheckedChanged
        If chkPropPenClipartPenLineCap2.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.ClipartPenLineCap = cPen.PenLineCapEnum.Rounded
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.ClipartPenLineCap = cPen.PenLineCapEnum.Rounded
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("ClipartPenLineCap")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenClipartPenLineCap1_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenClipartPenLineCap1.CheckedChanged
        If chkPropPenClipartPenLineCap1.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.ClipartPenLineCap = cPen.PenLineCapEnum.Squared
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.ClipartPenLineCap = cPen.PenLineCapEnum.Squared
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("ClipartPenLineCap")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub chkPropPenClipartPenLineCap0_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropPenClipartPenLineCap0.CheckedChanged
        If chkPropPenClipartPenLineCap0.Checked Then
            If Not DisabledObjectProperty() Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
                If oPoint Is Nothing Then
                    Item.Pen.ClipartPenLineCap = cPen.PenLineCapEnum.Flat
                Else
                    Call pObjectSetSequencePen()
                    oPoint.Pen.ClipartPenLineCap = cPen.PenLineCapEnum.Flat
                End If
                Call MyBase.CommitUndoSnapshot()
                Call MyBase.PropertyChanged("ClipartPenLineCap")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub
End Class
