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
            cboPropPenPattern.EditValue = Item.Pen.ID
        Else
            Dim oPen As cPen = pGetPointPen()
            cboPropPenPattern.EditValue = oPen.ID
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
            If oPoint Is Nothing Then
                Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
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
                txtPropPenClipartPenWidth.EditValue = oPen.ClipartPenWidth
                txtPropPenClipartPenColor.EditValue = oPen.ClipartPenColor
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
                Dim bOk As Boolean = True
                If oSurvey.Pens.Contains(sName) Then
                    bOk = cSurvey.UIHelpers.Dialogs.Msgbox(GetLocalizedString("main.savepenoverwritetext"), MsgBoxStyle.YesNo Or MsgBoxStyle.Critical, GetLocalizedString("main.savepentitle")) = MsgBoxResult.Yes
                End If
                If bOk Then
                    Using oNewPen As cCustomPen = oSurvey.Pens.Add(oPen, sName)
                        cboPropPenPattern.Rebind(oSurvey)
                        cboPropPenPattern.EditValue = oNewPen.ID
                    End Using
                End If
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
            Else
                bStyleVisible = True
                bClipartVisible = False
                bClipartSettingsVisible = False
                bClipartSettingsPenVisible = False
            End If
        Else
            bStyleVisible = False
            bClipartVisible = False
            pnlPenClipartSettings.Visible = False
            bClipartSettingsPenVisible = False
        End If

        pnlPenStyle.Visible = bStyleVisible
        pnlPenClipart.Visible = bClipartVisible
        pnlPenClipartSettings.Visible = bClipartSettingsVisible
        pnlPenClipartSettingsPen.Visible = bClipartSettingsPenVisible

        Height = (45 + If(bStyleVisible, pnlPenStyle.Height, 0) + If(bClipartVisible, pnlPenClipart.Height, 0) + If(bClipartSettingsVisible, pnlPenClipartSettings.Height, 0) + If(bClipartSettingsPenVisible, pnlPenClipartSettingsPen.Height, 0)) * CurrentAutoScaleDimensions.Height / 96.0F
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
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.Style = pSelectedIndexToPenStyle(cboPropPenStyle)
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
            'Return iCount - 2
            Return iCount - 1
            'ElseIf PenStyle = cPen.PenStylesEnum.Custom Then
            '    Return iCount - 1
        Else
            Return PenStyle
        End If
    End Function

    Private Function pSelectedIndexToPenStyle(ComboBoxEdit As DevExpress.XtraEditors.ComboBoxEdit) As cPen.PenStylesEnum
        'for now custom pens are not managed
        Dim iCount As Integer = ComboBoxEdit.Properties.Items.Count
        Dim iSelected As Integer = ComboBoxEdit.SelectedIndex
        If iSelected < iCount - 1 Then
            Return iSelected
        Else
            Return cPen.PenStylesEnum.None
        End If
        'If iSelected < iCount - 2 Then
        '    Return iSelected
        'Else
        '    If iSelected = iCount - 1 Then
        '        Return cPen.PenStylesEnum.Custom
        '    Else
        '        Return cPen.PenStylesEnum.None
        '    End If
        'End If
    End Function

    Private Sub cboPropPenClipartPenStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropPenClipartPenStyle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.BeginUndoSnapshot(modMain.GetLocalizedString("main.undo39"))
            If oPoint Is Nothing Then
                Item.Pen.ClipartPenStyle = pSelectedIndexToPenStyle(cboPropPenClipartPenStyle)
            Else
                Call pObjectSetSequencePen()
                oPoint.Pen.ClipartPenStyle = pSelectedIndexToPenStyle(cboPropPenClipartPenStyle)
            End If
            Call MyBase.CommitUndoSnapshot()
            Call MyBase.PropertyChanged("ClipartPenStyle")
            Call MyBase.MapInvalidate()
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

End Class
