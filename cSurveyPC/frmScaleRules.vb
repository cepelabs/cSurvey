Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Scale
Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items

Public Class frmScaleRules
    Private oSurvey As cSurvey.cSurvey
    Private oScaleRules As cScaleRules
    Private oCurrentItem As ListViewItem

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Call pSaveRule(oCurrentItem)
        Catch
        End Try
        Call pAdd()
    End Sub

    Private Sub pAdd(Optional ByVal AsCopy As Boolean = False)
        Dim iScale As Integer
        Try
            iScale = txtAddScale.Text
            If iScale > 50000 Then
                txtAddScale.Text = 50000
                iScale = 50000
            End If
            If iScale < 5 Then
                txtAddScale.Text = 5
                iScale = 5
            End If
            If oScaleRules.Contains(iScale) Then
                MsgBox(GetLocalizedString("scalerules.warning1"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, GetLocalizedString("scalerules.warningtitle"))
            Else
                Dim oScaleRule As cScaleRule = oScaleRules.Add(iScale)
                If AsCopy And Not oCurrentItem Is Nothing Then
                    'copio le impostazioni correnti...
                    oScaleRule.CopyFrom(oCurrentItem.Tag)
                Else
                    'copio la impostazioni grafiche di default...
                    Call oScaleRule.DesignProperties.CopyFrom(oSurvey.Properties.DesignProperties)
                End If
                Dim oItem As ListViewItem = New ListViewItem
                oItem.Name = iScale
                oItem.Text = GetLocalizedString("scalerules.textpart1") & " 1:" & Strings.Format(iScale, "#,##0")
                oItem.ImageIndex = 0
                oItem.Tag = oScaleRule
                Call oItem.SubItems.Add(Strings.Format(oScaleRule.Scale, "00000"))
                Call lv.Items.Add(oItem)
                oItem.Focused = True
                oItem.Selected = True

                oCurrentItem = oItem
                Call ploadRule(oCurrentItem)
            End If
        Catch
            Call MsgBox(GetLocalizedString("scalerules.warning2"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, GetLocalizedString("scalerules.warningtitle"))
        End Try
    End Sub

    Private Sub ploadRule(ByVal Item As ListViewItem)
        Dim oScaleRule As cScaleRule = Item.Tag
        With oScaleRule
            txtScale.Value = .Scale

            'design
            txtBaseLineWidthScaleFactor.Value = .DesignProperties.GetValue("BaseLineWidthScaleFactor", 0.01)
            txtBaseHeavyLinesScaleFactor.Value = .DesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
            txtBaseMediumLinesScaleFactor.Value = .DesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
            txtBaseLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
            txtBaseUltraLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
            'clipart, simboli e testo
            txtDesignSoilScaleFactor.Value = .DesignProperties.GetValue("DesignSoilScaleFactor", 1)
            txtDesignTextureScaleFactor.Value = .DesignProperties.GetValue("DesignTextureScaleFactor", 0.2)
            txtDesignTerrainLevelScaleFactor.Value = .DesignProperties.GetValue("DesignTerrainLevelScaleFactor", 1)
            txtDesignSignScaleFactor.Value = .DesignProperties.GetValue("DesignSignScaleFactor", 1)
            txtDesignExtraScaleFactor.Value = .DesignProperties.GetValue("DesignExtraScaleFactor", 1)
            txtDesignExtraTextScaleFactor.Value = .DesignProperties.GetValue("DesignExtraTextScaleFactor", 1)
            txtDesignClipartScaleFactor.Value = .DesignProperties.GetValue("DesignClipartScaleFactor", 1)
            txtDesignTextScaleFactor.Value = .DesignProperties.GetValue("DesignTextScaleFactor", 0.05)
            Dim oDesignTextFont As cIFont = .DesignProperties.GetValue("DesignTextFont", modPaint.GetDefaultFont)
            txtDesignTextFont.Tag = oDesignTextFont
            txtDesignTextFont.Text = oDesignTextFont.ToString

            'centerline
            txtPlotPointSize.Value = .DesignProperties.GetValue("PlotPointSize", 2)
            txtPlotSelectedPointSize.Value = .DesignProperties.GetValue("PlotSelectedPointSize", 8)
            cboPlotPointSymbol.SelectedIndex = .DesignProperties.GetValue("PlotPointSymbol", 7) - 1
            picPlotPointColor.BackColor = .DesignProperties.GetValue("PlotPointColor", Color.Red)

            txtPlotPenWidth.Value = .DesignProperties.GetValue("PlotPenWidth", 2)
            txtPlotSelectedPenWidth.Value = .DesignProperties.GetValue("PlotSelectedPenWidth", 8)
            cboPlotPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotPenStyle", Design.cPen.PenStylesEnum.Dash)
            picPlotPenColor.BackColor = .DesignProperties.GetValue("PlotPenColor", Color.Black)

            txtPlotTextScaleFactor.Value = .DesignProperties.GetValue("PlotTextScaleFactor", 1)
            Dim oPlotTextFont As cIFont = .DesignProperties.GetValue("PlotTextFont", modPaint.GetDefaultFont)
            txtPlotTextFont.Tag = oPlotTextFont
            txtPlotTextFont.Text = oPlotTextFont.ToString
            picPlotTextColor.BackColor = .DesignProperties.GetValue("PlotTextColor", Color.Black)

            txtPlotNoteTextScaleFactor.Value = .DesignProperties.GetValue("PlotNoteTextScaleFactor", 0.5)
            Dim oPlotNoteTextFont As cIFont = .DesignProperties.GetValue("PlotNoteTextFont", modPaint.GetDefaultFont)
            txtPlotNoteTextFont.Tag = oPlotNoteTextFont
            txtPlotNoteTextFont.Text = oPlotNoteTextFont.ToString
            picPlotNoteTextColor.BackColor = .DesignProperties.GetValue("PlotNoteTextColor", Color.Black)

            txtPlotTranslationLinePenWidth.Value = .DesignProperties.GetValue("PlotTranslationLinePenWidth", 2)
            cboPlotTranslationLinePenStyle.SelectedIndex = .DesignProperties.GetValue("PlotTranslationLinePenStyle", Design.cPen.PenStylesEnum.Dot)
            picPlotTranslationLinePenColor.BackColor = .DesignProperties.GetValue("PlotTranslationLinePenColor", Color.Black)

            txtPlotLRUDPenWidth.Value = .DesignProperties.GetValue("PlotLRUDPenWidth", 0.8)
            txtPlotLRUDSelectedPenWidth.Value = .DesignProperties.GetValue("PlotLRUDSelectedPenWidth", 1.2)
            cboPlotLRUDPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotLRUDPenStyle", Design.cPen.PenStylesEnum.Dot)

            txtPlotSplayPenWidth.Value = .DesignProperties.GetValue("PlotSplayPenWidth", 0.8)
            txtPlotSplaySelectedPenWidth.Value = .DesignProperties.GetValue("PlotSplaySelectedPenWidth", 1.2)
            cboPlotSplayPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotSplayPenStyle", Design.cPen.PenStylesEnum.Dot)

            chkPlotCenterlineVectors.Checked = .DesignProperties.GetValue("PlotCenterlineVector", 0)

            Call grdCategoriesVisibility.Rows.Clear()
            For Each iCategory As cIItem.cItemCategoryEnum In [Enum].GetValues(GetType(cIItem.cItemCategoryEnum))
                Dim oValues() As Object = {DirectCast(iCategory, Integer), iCategory.ToString, .Categories(iCategory)}
                Call grdCategoriesVisibility.Rows.Add(oValues)
            Next
        End With
        If Not tabInfo.Enabled Then tabInfo.Enabled = True
    End Sub

    Private Sub pSaveRule(ByVal Item As ListViewItem)
        If Not Item Is Nothing Then
            Dim oScaleRule As cScaleRule = Item.Tag
            With oScaleRule
                Dim iScale As Integer = txtScale.Value
                If .Scale <> iScale Then
                    .Scale = iScale
                    iScale = .Scale
                    Item.Text = GetLocalizedString("scalerules.textpart1") & " 1:" & Strings.Format(iScale, "#,##0")
                    Item.SubItems(1).Text = Strings.Format(iScale, "00000")
                    Call lv.Sort()
                End If

                Call .DesignProperties.SetValue("BaseLineWidthScaleFactor", txtBaseLineWidthScaleFactor.Value)
                Call .DesignProperties.SetValue("BaseHeavyLinesScaleFactor", txtBaseHeavyLinesScaleFactor.Value)
                Call .DesignProperties.SetValue("BaseMediumLinesScaleFactor", txtBaseMediumLinesScaleFactor.Value)
                Call .DesignProperties.SetValue("BaseLightLinesScaleFactor", txtBaseLightLinesScaleFactor.Value)
                Call .DesignProperties.SetValue("BaseUltraLightLinesScaleFactor", txtBaseUltraLightLinesScaleFactor.Value)

                Call .DesignProperties.SetValue("DesignSoilScaleFactor", txtDesignSoilScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignTextureScaleFactor", txtDesignTextureScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignTerrainLevelScaleFactor", txtDesignTerrainLevelScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignClipartScaleFactor", txtDesignClipartScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignSignScaleFactor", txtDesignSignScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignExtraScaleFactor", txtDesignExtraScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignExtraTextScaleFactor", txtDesignExtraTextScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignTextScaleFactor", txtDesignTextScaleFactor.Value)
                Call .DesignProperties.SetValue("DesignTextFont", txtDesignTextFont.Tag)

                Call .DesignProperties.SetValue("PlotPointSize", txtPlotPointSize.Value)
                Call .DesignProperties.SetValue("PlotSelectedPointSize", txtPlotSelectedPointSize.Value)
                Call .DesignProperties.SetValue("PlotPointSymbol", cboPlotPointSymbol.SelectedIndex + 1)
                Call .DesignProperties.SetValue("PlotPointColor", picPlotPointColor.BackColor)

                Call .DesignProperties.SetValue("PlotPenWidth", txtPlotPenWidth.Value)
                Call .DesignProperties.SetValue("PlotSelectedPenWidth", txtPlotSelectedPenWidth.Value)
                Call .DesignProperties.SetValue("PlotPenStyle", cboPlotPenStyle.SelectedIndex)
                Call .DesignProperties.SetValue("PlotPenColor", picPlotPenColor.BackColor)

                Call .DesignProperties.SetValue("PlotTranslationLinePenWidth", txtPlotTranslationLinePenWidth.Value)
                Call .DesignProperties.SetValue("PlotTranslationLinePenStyle", cboPlotTranslationLinePenStyle.SelectedIndex)
                Call .DesignProperties.SetValue("PlotTranslationLinePenColor", picPlotTranslationLinePenColor.BackColor)

                Call .DesignProperties.SetValue("PlotLRUDPenWidth", txtPlotLRUDPenWidth.Value)
                Call .DesignProperties.SetValue("PlotLRUDSelectedPenWidth", txtPlotLRUDSelectedPenWidth.Value)
                Call .DesignProperties.SetValue("PlotLRUDPenStyle", cboPlotLRUDPenStyle.SelectedIndex)

                Call .DesignProperties.SetValue("PlotSplayPenWidth", txtPlotSplayPenWidth.Value)
                Call .DesignProperties.SetValue("PlotSplaySelectedPenWidth", txtPlotSplaySelectedPenWidth.Value)
                Call .DesignProperties.SetValue("PlotSplayPenStyle", cboPlotSplayPenStyle.SelectedIndex)

                Call .DesignProperties.SetValue("PlotTextScaleFactor", txtPlotTextScaleFactor.Value)
                Call .DesignProperties.SetValue("PlotTextFont", txtPlotTextFont.Tag)
                Call .DesignProperties.SetValue("PlotTextColor", picPlotTextColor.BackColor)

                Call .DesignProperties.SetValue("PlotNoteTextScaleFactor", txtPlotNoteTextScaleFactor.Value)
                Call .DesignProperties.SetValue("PlotNoteTextFont", txtPlotNoteTextFont.Tag)
                Call .DesignProperties.SetValue("PlotNoteTextColor", picPlotNoteTextColor.BackColor)

                Call .DesignProperties.SetValue("PlotCenterlineVector", IIf(chkPlotCenterlineVectors.Checked, 1, 0))

                For Each oRow As DataGridViewRow In grdCategoriesVisibility.Rows
                    Dim iCategory As cIItem.cItemCategoryEnum = oRow.Cells(0).Value
                    Dim bVisibility As Boolean = oRow.Cells(2).Value
                    Call .Categories.SetVisibility(iCategory, bVisibility)
                Next
            End With
        End If
    End Sub

    Private Class cScaleRuleListViewComparer
        Implements IComparer
        Private iColumnIndex As Integer
        Private iSortOrder As SortOrder

        Public Sub New(ByVal ColumnIndex As Integer, ByVal SortOrder As SortOrder)
            iColumnIndex = 1
            iSortOrder = Windows.Forms.SortOrder.Ascending
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim oItemX As ListViewItem = DirectCast(x, ListViewItem)
            Dim sX As String = oItemX.SubItems(iColumnIndex).Text
            Dim oItemY As ListViewItem = DirectCast(y, ListViewItem)
            Dim sY As String = oItemY.SubItems(iColumnIndex).Text
            Return String.Compare(sX, sY)
        End Function
    End Class

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        On Error Resume Next
        oSurvey = Survey
        oScaleRules = New cScaleRules(oSurvey)
        Call oScaleRules.CopyFrom(oSurvey.ScaleRules)

        lv.ListViewItemSorter = New cScaleRuleListViewComparer(1, SortOrder.Ascending)

        Call pRefresh()
    End Sub

    Private Sub pRefresh()
        Call lv.Items.Clear()
        For Each oScaleRule As cScaleRule In oScaleRules
            Dim oItem As ListViewItem = New ListViewItem
            oItem.Name = oScaleRule.Scale
            oItem.Text = GetLocalizedString("scalerules.textpart1") & " 1:" & Strings.Format(oScaleRule.Scale, "#,##0")
            oItem.ImageIndex = 0
            oItem.Tag = oScaleRule
            Call oItem.SubItems.Add(Strings.Format(oScaleRule.Scale, "00000"))
            Call lv.Items.Add(oItem)
        Next
        If lv.Items.Count > 0 Then
            lv.Items(0).Selected = True
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            Dim oItem As ListViewItem = lv.SelectedItems(0)
            Dim iIndex As Integer = oItem.Index
            Dim oScaleRule As cScaleRule = oItem.Tag
            Call oScaleRules.Remove(oScaleRule)
            Call oItem.Remove()

            Try
                Dim iNewIndex As Integer
                If iIndex > 0 Then
                    iNewIndex = iIndex - 1
                End If
                Dim oNewItem As ListViewItem = lv.Items(iNewIndex)
                oNewItem.Selected = True
                oNewItem.Focused = True
                Call ploadRule(oNewItem.Tag)
            Catch
            End Try
        Catch
        End Try
    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        Call pSaveRule(oCurrentItem)
        If lv.SelectedItems.Count > 0 Then
            oCurrentItem = lv.SelectedItems(0)
            Call ploadRule(oCurrentItem)
        Else
            tabInfo.Enabled = False
        End If
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Call pSaveRule(oCurrentItem)
        Catch
        End Try
        Call oSurvey.ScaleRules.CopyFrom(oScaleRules)
        Call oSurvey.RaiseOnPropertiesChanged(cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.ScaleProperties)
        Call Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Private Sub cmdPlotTextFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTextFont.Click
        Dim oFD As frmFontDialog = New frmFontDialog(CType(txtPlotTextFont.Tag, cIFont))
        With oFD
            If .ShowDialog = vbOK Then
                txtPlotTextFont.Tag = .CurrentFont
                txtPlotTextFont.Text = .CurrentFont.ToString
            End If
        End With
    End Sub

    Private Sub cmdDesignTextFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesignTextFont.Click
        Dim oFD As frmFontDialog = New frmFontDialog(CType(txtDesignTextFont.Tag, cIFont))
        With oFD
            If .ShowDialog = vbOK Then
                txtDesignTextFont.Tag = .CurrentFont
                txtDesignTextFont.Text = .CurrentFont.ToString
            End If
        End With
    End Sub

    Private Sub cmdPlotPointColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotPointColor.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picPlotPointColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picPlotPointColor.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub cmdPlotPenColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotPenColor.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picPlotPenColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picPlotPenColor.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub cmdPlotTextColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTextColor.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picPlotTextColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picPlotTextColor.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub txtScale_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtScale.Validating
        Dim iNewScale As Integer = txtScale.Value
        If oScaleRules.Contains(iNewScale) Then
            If Not oCurrentItem.Tag Is oScaleRules.GetRule(iNewScale) Then
                Call MsgBox(GetLocalizedString("scalerules.warning1"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, GetLocalizedString("scalerules.warningtitle"))
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnAddAsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAsCopy.Click
        Try
            Call pSaveRule(oCurrentItem)
        Catch
        End Try
        Call pAdd(True)
    End Sub

    Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
        If MsgBox(GetLocalizedString("scalerules.warning3"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("scalerules.warningtitle")) = MsgBoxResult.Yes Then
            Call oScaleRules.Clear()
            Call lv.Items.Clear()
            tabInfo.Enabled = False
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Try
            Call pSaveRule(oCurrentItem)
        Catch
        End Try

        Dim oSFD As SaveFileDialog = New SaveFileDialog
        With oSFD
            .Title = GetLocalizedString("scalerules.exportdialog")
            .Filter = GetLocalizedString("scalerules.filetypeXML") & " (*.XML)|*.XML|" & GetLocalizedString("scalerules.filetypeALL") & " (*.*)|*.*"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim oFile As Storage.cFile = New Storage.cFile
                Dim oXML As XmlDocument = oFile.Document
                Dim oXMLRoot As XmlElement = oXML.CreateElement("scalerules")
                Call oScaleRules.SaveTo(oFile, oFile.Document, oXMLRoot)
                Call oXML.AppendChild(oXMLRoot)
                Call oFile.Document.Save(.FileName)
            End If
        End With
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim oOFD As OpenFileDialog = New OpenFileDialog
        With oOFD
            .Title = GetLocalizedString("scalerules.importdialog")
            .Filter = GetLocalizedString("scalerules.filetypeXML") & " (*.XML)|*.XML|" & GetLocalizedString("scalerules.filetypeALL") & " (*.*)|*.*"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    Dim oXML As XmlDocument = New XmlDocument
                    Call oXML.Load(.FileName)
                    Dim oXMLRoot As XmlElement = oXML.ChildNodes(0)
                    Dim oXMLScaleRules As XmlElement = oXMLRoot.Item("scalerules")
                    Dim oImportedScaleRules As cScaleRules = New cScaleRules(oSurvey, oXMLScaleRules)
                    For Each oImportedScaleRule As cScaleRule In oImportedScaleRules
                        If oScaleRules.Contains(oImportedScaleRule.Scale) Then
                            Call oScaleRules.Remove(oImportedScaleRule.Scale)
                        End If
                        Dim oScaleRule As cScaleRule = oScaleRules.Add(oImportedScaleRule.Scale)
                        Call oScaleRule.CopyFrom(oImportedScaleRule)
                    Next
                    Call pRefresh()
                Catch
                    Call MsgBox(GetLocalizedString("scalerules.warning4"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("scalerules.warningtitle"))
                End Try
            End If
        End With
    End Sub

    Private Sub cmdPlotTranslationLinePenColor_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlotTranslationLinePenColor.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picPlotTranslationLinePenColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picPlotTranslationLinePenColor.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub cmdPlotNoteTextFont_Click(sender As Object, e As EventArgs) Handles cmdPlotNoteTextFont.Click
        Dim oFD As frmFontDialog = New frmFontDialog(CType(txtPlotNoteTextFont.Tag, cIFont))
        With oFD
            If .ShowDialog = vbOK Then
                txtPlotNoteTextFont.Tag = .CurrentFont
                txtPlotNoteTextFont.Text = .CurrentFont.ToString
            End If
        End With
    End Sub

    Private Sub cmdPlotNoteTextColor_Click(sender As Object, e As EventArgs) Handles cmdPlotNoteTextColor.Click
        Dim oCD As ColorDialog = New ColorDialog
        With oCD
            .FullOpen = True
            .AnyColor = True
            .Color = picPlotNoteTextColor.BackColor
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                picPlotNoteTextColor.BackColor = .Color
            End If
        End With
    End Sub

    Private Sub txtAddScale_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddScale.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call btnAdd.PerformClick()
        End If
    End Sub


End Class