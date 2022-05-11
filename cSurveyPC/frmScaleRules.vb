Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Scale
Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items

friend Class frmScaleRules
    Private oSurvey As cSurvey.cSurvey
    Private iMode As EditStyleEnum
    Private oOptions As Design.cOptions
    Private oDesignProperties As cPropertiesCollection
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
                    'copy current scalerule...
                    oScaleRule.CopyFrom(oCurrentItem.Tag)
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

    Private Sub pLoadRule(ByVal Item As ListViewItem)
        Dim oScaleRule As cScaleRule = Item.Tag
        Call ploadRule(oScaleRule)
    End Sub

    Private Function pGetCheckbox(ChildControlName As String) As CheckBox
        Dim sChildControlName As String = ChildControlName.ToLower
        For Each oCheckBox As CheckBox In oCheckboxes
            If TypeOf oCheckBox.Tag Is List(Of String) Then
                If DirectCast(oCheckBox.Tag, List(Of String)).Contains(sChildControlName) Then
                    Return oCheckBox
                End If
            End If
        Next
    End Function

    Private Sub pSetDesignColorValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As Color, Control As PictureBox)
        Dim oCheckbox As CheckBox = pGetCheckbox(Control.Name)
        If DesignProperties.HasValue(Name) Then
            Control.BackColor = DesignProperties.GetValue(Name, DefaultValue)
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = True
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        Else
            Control.BackColor = DefaultValue
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = False
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub pSetDesignComboValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As Integer, Delta As Integer, Control As ComboBox)
        Dim oCheckbox As CheckBox = pGetCheckbox(Control.Name)
        If DesignProperties.HasValue(Name) Then
            Control.SelectedIndex = DesignProperties.GetValue(Name, DefaultValue) + Delta
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = True
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        Else
            Control.SelectedIndex = DefaultValue + Delta
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = False
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub pSetDesignFontValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As cIFont, Control As TextBox)
        Dim oCheckbox As CheckBox = pGetCheckbox(Control.Name)
        If DesignProperties.HasValue(Name) Then
            Dim oTextFont As cIFont = DesignProperties.GetValue(Name, DefaultValue)
            Control.Tag = oTextFont
            Control.Text = oTextFont.ToString
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = True
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        Else
            Control.Tag = DefaultValue
            Control.Text = DefaultValue.ToString
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = False
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub pSetDesignNumericValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As Object, Control As NumericUpDown)
        Dim oCheckbox As CheckBox = pGetCheckbox(Control.Name)
        If DesignProperties.HasValue(Name) Then
            Control.Value = DesignProperties.GetValue(Name, DefaultValue)
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = True
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        Else
            Control.Value = DefaultValue
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = False
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub pLoadRule(DesignProperties As cPropertiesCollection)
        'todo: default values have to be readed from parent settings (if base rule, scale and properties, if scale rule, property)
        'design
        Call pSetDesignNumericValue(DesignProperties, "BaseLineWidthScaleFactor", 0.01, txtBaseLineWidthScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseHeavyLinesScaleFactor", 8, txtBaseHeavyLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseMediumLinesScaleFactor", 3, txtBaseMediumLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseLightLinesScaleFactor", 1, txtBaseLightLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseUltraLightLinesScaleFactor", 0.3, txtBaseUltraLightLinesScaleFactor)
        'clipart, simboli e testo
        Call pSetDesignNumericValue(DesignProperties, "DesignSoilScaleFactor", 1, txtDesignSoilScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignTextureScaleFactor", 0.2, txtDesignTextureScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignTerrainLevelScaleFactor", 1, txtDesignTerrainLevelScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignSignScaleFactor", 1, txtDesignSignScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignExtraScaleFactor", 1, txtDesignExtraScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignExtraTextScaleFactor", 1, txtDesignExtraTextScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignClipartScaleFactor", 1, txtDesignClipartScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignTextScaleFactor", 0.05, txtDesignTextScaleFactor)
        Call pSetDesignFontValue(DesignProperties, "DesignTextFont", modPaint.GetDefaultFont, txtDesignTextFont)

        Call pSetDesignNumericValue(DesignProperties, "DesignCrossSectionTextScaleFactor", 1, txtDesignCrossSectionTextScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignCrossSectionMarkerTextScaleFactor", 1, txtDesignCrossSectionMarkerTextScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "DesignCrossSectionMarkerArrowScaleFactor", 1, txtDesignCrossSectionMarkerArrowScaleFactor)

        Call pSetDesignNumericValue(DesignProperties, "PlotPointSize", 2, txtPlotPointSize)
        Call pSetDesignNumericValue(DesignProperties, "PlotSelectedPointSize", 8, txtPlotSelectedPointSize)
        Call pSetDesignComboValue(DesignProperties, "PlotPointSymbol", 7, -1, cboPlotPointSymbol)
        Call pSetDesignColorValue(DesignProperties, "PlotPointColor", Color.Red, picPlotPointColor)

        Call pSetDesignNumericValue(DesignProperties, "PlotPenWidth", 2, txtPlotPenWidth)
        Call pSetDesignNumericValue(DesignProperties, "PlotSelectedPenWidth", 8, txtPlotSelectedPenWidth)
        Call pSetDesignComboValue(DesignProperties, "PlotPenStyle", Design.cPen.PenStylesEnum.Dash, 0, cboPlotPenStyle)
        Call pSetDesignColorValue(DesignProperties, "PlotPenColor", Color.Black, picPlotPenColor)

        Call pSetDesignNumericValue(DesignProperties, "PlotTextScaleFactor", 1, txtPlotTextScaleFactor)
        Call pSetDesignFontValue(DesignProperties, "PlotTextFont", modPaint.GetDefaultFont, txtPlotTextFont)
        Call pSetDesignColorValue(DesignProperties, "PlotTextColor", Color.Black, picPlotTextColor)

        Call pSetDesignNumericValue(DesignProperties, "PlotNoteTextScaleFactor", 0.5, txtPlotNoteTextScaleFactor)
        Call pSetDesignFontValue(DesignProperties, "PlotNoteTextFont", modPaint.GetDefaultFont, txtPlotNoteTextFont)
        Call pSetDesignColorValue(DesignProperties, "PlotNoteTextColor", Color.Black, picPlotNoteTextColor)

        Call pSetDesignNumericValue(DesignProperties, "PlotTranslationLinePenWidth", 2, txtPlotTranslationLinePenWidth)
        Call pSetDesignComboValue(DesignProperties, "PlotTranslationLinePenStyle", Design.cPen.PenStylesEnum.Dot, 0, cboPlotTranslationLinePenStyle)
        Call pSetDesignColorValue(DesignProperties, "PlotTranslationLinePenColor", Color.Black, picPlotTranslationLinePenColor)

        Call pSetDesignNumericValue(DesignProperties, "PlotLRUDPenWidth", 0.8, txtPlotLRUDPenWidth)
        Call pSetDesignNumericValue(DesignProperties, "PlotLRUDSelectedPenWidth", 1.2, txtPlotLRUDSelectedPenWidth)
        Call pSetDesignComboValue(DesignProperties, "PlotLRUDPenStyle", Design.cPen.PenStylesEnum.Dot, 0, cboPlotLRUDPenStyle)

        Call pSetDesignNumericValue(DesignProperties, "PlotSplayPenWidth", 0.8, txtPlotSplayPenWidth)
        Call pSetDesignNumericValue(DesignProperties, "PlotSplaySelectedPenWidth", 1.2, txtPlotSplaySelectedPenWidth)
        Call pSetDesignComboValue(DesignProperties, "PlotSplayPenStyle", Design.cPen.PenStylesEnum.Dot, 0, cboPlotSplayPenStyle)

        'Else 
        ''design
        'txtBaseLineWidthScaleFactor.Value = .DesignProperties.GetValue("BaseLineWidthScaleFactor", 0.01)
        'txtBaseHeavyLinesScaleFactor.Value = .DesignProperties.GetValue("BaseHeavyLinesScaleFactor", 8)
        'txtBaseMediumLinesScaleFactor.Value = .DesignProperties.GetValue("BaseMediumLinesScaleFactor", 3)
        'txtBaseLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseLightLinesScaleFactor", 1)
        'txtBaseUltraLightLinesScaleFactor.Value = .DesignProperties.GetValue("BaseUltraLightLinesScaleFactor", 0.3)
        ''clipart, simboli e testo
        'txtDesignSoilScaleFactor.Value = .DesignProperties.GetValue("DesignSoilScaleFactor", 1)
        'txtDesignTextureScaleFactor.Value = .DesignProperties.GetValue("DesignTextureScaleFactor", 0.2)
        'txtDesignTerrainLevelScaleFactor.Value = .DesignProperties.GetValue("DesignTerrainLevelScaleFactor", 1)
        'txtDesignSignScaleFactor.Value = .DesignProperties.GetValue("DesignSignScaleFactor", 1)
        'txtDesignExtraScaleFactor.Value = .DesignProperties.GetValue("DesignExtraScaleFactor", 1)
        'txtDesignExtraTextScaleFactor.Value = .DesignProperties.GetValue("DesignExtraTextScaleFactor", 1)
        'txtDesignClipartScaleFactor.Value = .DesignProperties.GetValue("DesignClipartScaleFactor", 1)
        'txtDesignTextScaleFactor.Value = .DesignProperties.GetValue("DesignTextScaleFactor", 0.05)
        'Dim oDesignTextFont As cIFont = .DesignProperties.GetValue("DesignTextFont", modPaint.GetDefaultFont)
        'txtDesignTextFont.Tag = oDesignTextFont
        'txtDesignTextFont.Text = oDesignTextFont.ToString

        ''centerline
        'txtPlotPointSize.Value = .DesignProperties.GetValue("PlotPointSize", 2)
        'txtPlotSelectedPointSize.Value = .DesignProperties.GetValue("PlotSelectedPointSize", 8)
        'cboPlotPointSymbol.SelectedIndex = .DesignProperties.GetValue("PlotPointSymbol", 7) - 1
        'picPlotPointColor.BackColor = .DesignProperties.GetValue("PlotPointColor", Color.Red)

        'txtPlotPenWidth.Value = .DesignProperties.GetValue("PlotPenWidth", 2)
        'txtPlotSelectedPenWidth.Value = .DesignProperties.GetValue("PlotSelectedPenWidth", 8)
        'cboPlotPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotPenStyle", Design.cPen.PenStylesEnum.Dash)
        'picPlotPenColor.BackColor = .DesignProperties.GetValue("PlotPenColor", Color.Black)

        'txtPlotTextScaleFactor.Value = .DesignProperties.GetValue("PlotTextScaleFactor", 1)
        'Dim oPlotTextFont As cIFont = .DesignProperties.GetValue("PlotTextFont", modPaint.GetDefaultFont)
        'txtPlotTextFont.Tag = oPlotTextFont
        'txtPlotTextFont.Text = oPlotTextFont.ToString
        'picPlotTextColor.BackColor = .DesignProperties.GetValue("PlotTextColor", Color.Black)

        'txtPlotNoteTextScaleFactor.Value = .DesignProperties.GetValue("PlotNoteTextScaleFactor", 0.5)
        'Dim oPlotNoteTextFont As cIFont = .DesignProperties.GetValue("PlotNoteTextFont", modPaint.GetDefaultFont)
        'txtPlotNoteTextFont.Tag = oPlotNoteTextFont
        'txtPlotNoteTextFont.Text = oPlotNoteTextFont.ToString
        'picPlotNoteTextColor.BackColor = .DesignProperties.GetValue("PlotNoteTextColor", Color.Black)

        'txtPlotTranslationLinePenWidth.Value = .DesignProperties.GetValue("PlotTranslationLinePenWidth", 2)
        'cboPlotTranslationLinePenStyle.SelectedIndex = .DesignProperties.GetValue("PlotTranslationLinePenStyle", Design.cPen.PenStylesEnum.Dot)
        'picPlotTranslationLinePenColor.BackColor = .DesignProperties.GetValue("PlotTranslationLinePenColor", Color.Black)

        'txtPlotLRUDPenWidth.Value = .DesignProperties.GetValue("PlotLRUDPenWidth", 0.8)
        'txtPlotLRUDSelectedPenWidth.Value = .DesignProperties.GetValue("PlotLRUDSelectedPenWidth", 1.2)
        'cboPlotLRUDPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotLRUDPenStyle", Design.cPen.PenStylesEnum.Dot)

        'txtPlotSplayPenWidth.Value = .DesignProperties.GetValue("PlotSplayPenWidth", 0.8)
        'txtPlotSplaySelectedPenWidth.Value = .DesignProperties.GetValue("PlotSplaySelectedPenWidth", 1.2)
        'cboPlotSplayPenStyle.SelectedIndex = .DesignProperties.GetValue("PlotSplayPenStyle", Design.cPen.PenStylesEnum.Dot)

        If Not tabInfo.Enabled Then tabInfo.Enabled = True
    End Sub

    Private Sub ploadRule(ByVal ScaleRule As cIScaleRule)
        With ScaleRule
            txtScale.Value = .Scale

            Call grdCategoriesVisibility.Rows.Clear()
            For Each iCategory As cIItem.cItemCategoryEnum In [Enum].GetValues(GetType(cIItem.cItemCategoryEnum))
                Dim oValues() As Object = {DirectCast(iCategory, Integer), iCategory.ToString, .Categories(iCategory)}
                Call grdCategoriesVisibility.Rows.Add(oValues)
            Next
        End With
        Call pLoadRule(ScaleRule.DesignProperties)
    End Sub

    Private Sub pSaveRule(DesignProperties As cPropertiesCollection)
        With DesignProperties
            If txtBaseLineWidthScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseLineWidthScaleFactor", txtBaseLineWidthScaleFactor.Value)
            If txtBaseHeavyLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseHeavyLinesScaleFactor", txtBaseHeavyLinesScaleFactor.Value)
            If txtBaseMediumLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseMediumLinesScaleFactor", txtBaseMediumLinesScaleFactor.Value)
            If txtBaseLightLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseLightLinesScaleFactor", txtBaseLightLinesScaleFactor.Value)
            If txtBaseUltraLightLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseUltraLightLinesScaleFactor", txtBaseUltraLightLinesScaleFactor.Value)

            If txtDesignSoilScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignSoilScaleFactor", txtDesignSoilScaleFactor.Value)
            If txtDesignTextureScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignTextureScaleFactor", txtDesignTextureScaleFactor.Value)
            If txtDesignTerrainLevelScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignTerrainLevelScaleFactor", txtDesignTerrainLevelScaleFactor.Value)
            If txtDesignClipartScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignClipartScaleFactor", txtDesignClipartScaleFactor.Value)
            If txtDesignSignScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignSignScaleFactor", txtDesignSignScaleFactor.Value)
            If txtDesignExtraScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignExtraScaleFactor", txtDesignExtraScaleFactor.Value)
            If txtDesignExtraTextScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignExtraTextScaleFactor", txtDesignExtraTextScaleFactor.Value)
            If txtDesignTextScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignTextScaleFactor", txtDesignTextScaleFactor.Value)
            If txtDesignTextFont.Enabled Then Call DesignProperties.SetValue("DesignTextFont", txtDesignTextFont.Tag)

            If txtDesignCrossSectionTextScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignCrossSectionTextScaleFactor", txtDesignCrossSectionMarkerArrowScaleFactor.Value)
            If txtDesignCrossSectionMarkerTextScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignCrossSectionMarkerTextScaleFactor", txtDesignCrossSectionMarkerTextScaleFactor.Value)
            If txtDesignCrossSectionMarkerArrowScaleFactor.Enabled Then Call DesignProperties.SetValue("DesignCrossSectionMarkerArrowScaleFactor", txtDesignCrossSectionMarkerArrowScaleFactor.Value)

            If txtPlotPointSize.Enabled Then Call DesignProperties.SetValue("PlotPointSize", txtPlotPointSize.Value)
            If txtPlotSelectedPointSize.Enabled Then Call DesignProperties.SetValue("PlotSelectedPointSize", txtPlotSelectedPointSize.Value)
            If cboPlotPointSymbol.Enabled Then Call DesignProperties.SetValue("PlotPointSymbol", cboPlotPointSymbol.SelectedIndex + 1)
            If picPlotPointColor.Enabled Then Call DesignProperties.SetValue("PlotPointColor", picPlotPointColor.BackColor)

            If txtPlotPenWidth.Enabled Then Call DesignProperties.SetValue("PlotPenWidth", txtPlotPenWidth.Value)
            If txtPlotSelectedPenWidth.Enabled Then Call DesignProperties.SetValue("PlotSelectedPenWidth", txtPlotSelectedPenWidth.Value)
            If cboPlotPenStyle.Enabled Then Call DesignProperties.SetValue("PlotPenStyle", cboPlotPenStyle.SelectedIndex)
            If picPlotPenColor.Enabled Then Call DesignProperties.SetValue("PlotPenColor", picPlotPenColor.BackColor)

            If txtPlotTranslationLinePenWidth.Enabled Then Call DesignProperties.SetValue("PlotTranslationLinePenWidth", txtPlotTranslationLinePenWidth.Value)
            If cboPlotTranslationLinePenStyle.Enabled Then Call DesignProperties.SetValue("PlotTranslationLinePenStyle", cboPlotTranslationLinePenStyle.SelectedIndex)
            If picPlotTranslationLinePenColor.Enabled Then Call DesignProperties.SetValue("PlotTranslationLinePenColor", picPlotTranslationLinePenColor.BackColor)

            If txtPlotLRUDPenWidth.Enabled Then Call DesignProperties.SetValue("PlotLRUDPenWidth", txtPlotLRUDPenWidth.Value)
            If txtPlotLRUDSelectedPenWidth.Enabled Then Call DesignProperties.SetValue("PlotLRUDSelectedPenWidth", txtPlotLRUDSelectedPenWidth.Value)
            If cboPlotLRUDPenStyle.Enabled Then Call DesignProperties.SetValue("PlotLRUDPenStyle", cboPlotLRUDPenStyle.SelectedIndex)

            If txtPlotSplayPenWidth.Enabled Then Call DesignProperties.SetValue("PlotSplayPenWidth", txtPlotSplayPenWidth.Value)
            If txtPlotSplaySelectedPenWidth.Enabled Then Call DesignProperties.SetValue("PlotSplaySelectedPenWidth", txtPlotSplaySelectedPenWidth.Value)
            If cboPlotSplayPenStyle.Enabled Then Call DesignProperties.SetValue("PlotSplayPenStyle", cboPlotSplayPenStyle.SelectedIndex)

            If txtPlotTextScaleFactor.Enabled Then Call DesignProperties.SetValue("PlotTextScaleFactor", txtPlotTextScaleFactor.Value)
            If txtPlotTextFont.Enabled Then Call DesignProperties.SetValue("PlotTextFont", txtPlotTextFont.Tag)
            If picPlotTextColor.Enabled Then Call DesignProperties.SetValue("PlotTextColor", picPlotTextColor.BackColor)

            If txtPlotNoteTextScaleFactor.Enabled Then Call DesignProperties.SetValue("PlotNoteTextScaleFactor", txtPlotNoteTextScaleFactor.Value)
            If txtPlotNoteTextFont.Enabled Then Call DesignProperties.SetValue("PlotNoteTextFont", txtPlotNoteTextFont.Tag)
            If picPlotNoteTextColor.Enabled Then Call DesignProperties.SetValue("PlotNoteTextColor", picPlotNoteTextColor.BackColor)
        End With
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
                For Each oRow As DataGridViewRow In grdCategoriesVisibility.Rows
                    Dim iCategory As cIItem.cItemCategoryEnum = oRow.Cells(0).Value
                    Dim bVisibility As Boolean = oRow.Cells(2).Value
                    Call .Categories.SetVisibility(iCategory, bVisibility)
                Next
                Call pSaveRule(oScaleRule.DesignProperties)
            End With
        End If
    End Sub

    Private Class cScaleRuleListViewComparer
        Implements IComparer
        Private iColumnIndex As Integer
        Private iSortOrder As SortOrder

        Public Sub New(ByVal ColumnIndex As Integer, ByVal SortOrder As SortOrder)
            iColumnIndex = 1
            iSortOrder = SortOrder.Ascending
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Dim oItemX As ListViewItem = DirectCast(x, ListViewItem)
            Dim sX As String = oItemX.SubItems(iColumnIndex).Text
            Dim oItemY As ListViewItem = DirectCast(y, ListViewItem)
            Dim sY As String = oItemY.SubItems(iColumnIndex).Text
            Return String.Compare(sX, sY)
        End Function
    End Class

    Public Enum EditStyleEnum
        ScaleRule = 0
        BaseRule = 1
    End Enum

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Mode As EditStyleEnum, Optional Options As Design.cOptions = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        iMode = Mode
        Select Case Mode
            Case EditStyleEnum.ScaleRule
                oScaleRules = New cScaleRules(oSurvey)
                Call oScaleRules.CopyFrom(oSurvey.ScaleRules)
                lv.ListViewItemSorter = New cScaleRuleListViewComparer(1, SortOrder.Ascending)
            Case EditStyleEnum.BaseRule
                oOptions = Options
                Text = modMain.GetLocalizedString("scalerules.baseruletitle")
                oDesignProperties = New cPropertiesCollection(oSurvey)
                Call oDesignProperties.CopyFrom(oOptions.DesignProperties)

                lv.Visible = False
                'tbMain.Visible = False
                tabInfo.Location = New Point(12, tbMain.Height + 13)
                tabInfo.Size = New Size(Me.ClientRectangle.Width - tabInfo.Location.X * 2, Me.ClientRectangle.Height - tabInfo.Location.Y - 12 - 32)
                lblAddScale.Visible = False
                txtAddScale.Visible = False
                btnAdd.Visible = False
                btnAddAsCopy.Visible = False
                sep1.Visible = False
                btnRemove.Visible = False
                btnRemoveAll.Visible = False
                sep2.Visible = False

                Call tabInfo.TabPages.Remove(tabInfoMain)
                Call tabInfo.TabPages.Remove(tanInfoCategories)
        End Select

        'create, for each label, a checkbox with same caption and posizion and hide label...
        'of course I can change every label but for now I prefer to leave the form as is and wait for future implementations...
        Call pLabelToCheckboxes(tabInfODesign)
        Call pLabelToCheckboxes(tabInfoPlot)

        Call tabInfo_SelectedIndexChanged(tabInfo, EventArgs.Empty)

        Call pRefresh()
    End Sub

    Private bDisabledCheckChange As Boolean
    Private oCheckboxes As List(Of CheckBox) = New List(Of CheckBox)

    Private Sub pLabelToCheckboxes(ParentControl As Control)
        For Each oControl As Control In ParentControl.Controls
            If TypeOf oControl Is Label Then
                Dim oLabel As Label = oControl
                Dim oCheckbox As CheckBox = New CheckBox
                oCheckbox.Name = "chk" & oLabel.Name
                oCheckbox.Location = oLabel.Location
                'oCheckbox.Size = oLabel.Size    'useful?
                oCheckbox.AutoSize = True
                oCheckbox.Text = oLabel.Text
                If Not IsNothing(oLabel.Tag) Then
                    oCheckbox.Tag = New List(Of String)(oLabel.Tag.ToString.ToLower.Split({";"c}))
                    AddHandler oCheckbox.CheckedChanged, AddressOf oCheckbox_checkchanged
                End If
                oLabel.Visible = False
                oCheckbox.Visible = True
                Call ParentControl.Controls.Add(oCheckbox)

                Call oCheckboxes.Add(oCheckbox)
            Else
                Call pLabelToCheckboxes(oControl)
            End If
        Next
    End Sub

    Private Sub oCheckbox_checkchanged(sender As Object, e As EventArgs)
        If Not bDisabledCheckChange Then
            Dim oCheckBox As CheckBox = DirectCast(sender, CheckBox)
            Dim bEnabled As Boolean = oCheckBox.Checked
            Dim oChildControls As List(Of String) = oCheckBox.Tag
            For Each oChildControl As Control In oCheckBox.Parent.Controls
                If oChildControls.Contains(oChildControl.Name.ToLower) Then
                    oChildControl.Enabled = bEnabled
                End If
            Next
        End If
    End Sub

    Private Sub pRefresh()
        Select Case iMode
            Case EditStyleEnum.BaseRule
                Call pLoadRule(oDesignProperties)
            Case EditStyleEnum.ScaleRule
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
                Call lv_SelectedIndexChanged(lv, EventArgs.Empty)
        End Select
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
                Call pLoadRule(oNewItem.Tag)
            Catch
            End Try
            Call lv_SelectedIndexChanged(lv, EventArgs.Empty)
        Catch
        End Try
    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged
        Call pSaveRule(oCurrentItem)
        If lv.SelectedItems.Count > 0 Then
            oCurrentItem = lv.SelectedItems(0)
            Call pLoadRule(oCurrentItem)
            btnAddAsCopy.Enabled = True
            btnRemove.Enabled = True
            Call tabInfo_SelectedIndexChanged(tabInfo, EventArgs.Empty)
        Else
            tabInfo.Enabled = False
            btnAddAsCopy.Enabled = False
            btnRemove.Enabled = False
            btnClear.Enabled = False
        End If
        btnRemoveAll.Enabled = lv.Items.Count > 0
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Select Case iMode
            Case EditStyleEnum.BaseRule
                Call pSaveRule(oDesignProperties)
                Call oOptions.DesignProperties.CopyFrom(oDesignProperties)
                Call oSurvey.RaiseOnPropertiesChanged(cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.DefaultProperties)
            Case EditStyleEnum.ScaleRule
                Call pSaveRule(oCurrentItem)
                Call oSurvey.ScaleRules.CopyFrom(oScaleRules)
                Call oSurvey.RaiseOnPropertiesChanged(cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.ScaleProperties)
        End Select
        Call Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Private Sub cmdPlotTextFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTextFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtPlotTextFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtPlotTextFont.Tag = .CurrentFont
                    txtPlotTextFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
    End Sub

    Private Sub cmdDesignTextFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDesignTextFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtDesignTextFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtDesignTextFont.Tag = .CurrentFont
                    txtDesignTextFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
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
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotPenColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotPenColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub cmdPlotTextColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlotTextColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotTextColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotTextColor.BackColor = .Color
                End If
            End With
        End Using
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
            Call lv_SelectedIndexChanged(lv, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Select Case iMode
            Case EditStyleEnum.BaseRule
                'Call pSaveRule(oDesignProperties)
                Using oSFD As SaveFileDialog = New SaveFileDialog
                    With oSFD
                        .Title = GetLocalizedString("scalerules.exportdialog")
                        .Filter = GetLocalizedString("scalerules.filetypeXML") & " (*.XML)|*.XML|" & GetLocalizedString("scalerules.filetypeALL") & " (*.*)|*.*"
                        .FilterIndex = 1
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim oFile As cFile = New cFile
                            Dim oXML As XmlDocument = oFile.Document
                            Dim oXMLRoot As XmlElement = oXML.CreateElement("baserule")
                            Call oDesignProperties.SaveTo(oFile, oFile.Document, "designproperties", oXMLRoot)
                            Call oXML.AppendChild(oXMLRoot)
                            Call oFile.Document.Save(.FileName)
                        End If
                    End With
                End Using
            Case EditStyleEnum.ScaleRule
                'Call pSaveRule(oCurrentItem)
                Using oSFD As SaveFileDialog = New SaveFileDialog
                    With oSFD
                        .Title = GetLocalizedString("scalerules.exportdialog")
                        .Filter = GetLocalizedString("scalerules.filetypeXML") & " (*.XML)|*.XML|" & GetLocalizedString("scalerules.filetypeALL") & " (*.*)|*.*"
                        .FilterIndex = 1
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim oFile As cFile = New cFile
                            Dim oXML As XmlDocument = oFile.Document
                            Dim oXMLRoot As XmlElement = oXML.CreateElement("scalerules")
                            Call oScaleRules.SaveTo(oFile, oFile.Document, oXMLRoot)
                            Call oXML.AppendChild(oXMLRoot)
                            Call oFile.Document.Save(.FileName)
                        End If
                    End With
                End Using
        End Select
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Using oOFD As OpenFileDialog = New OpenFileDialog
            With oOFD
                .Title = GetLocalizedString("scalerules.importdialog")
                .Filter = GetLocalizedString("scalerules.filetypeXML") & " (*.XML)|*.XML|" & GetLocalizedString("scalerules.filetypeALL") & " (*.*)|*.*"
                .FilterIndex = 1
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Select Case iMode
                        Case EditStyleEnum.BaseRule
                            Try
                                Dim oXML As XmlDocument = New XmlDocument
                                Call oXML.Load(.FileName)
                                Dim oXMLRoot As XmlElement = oXML.ChildNodes(0)
                                Dim oXMLBaseRule As XmlElement = oXMLRoot.Item("baserule")
                                'todo
                                Call pRefresh()
                            Catch
                                Call MsgBox(GetLocalizedString("scalerules.warning4"), MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, GetLocalizedString("scalerules.warningtitle"))
                            End Try
                        Case EditStyleEnum.ScaleRule
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
                    End Select
                End If
            End With
        End Using
    End Sub

    Private Sub cmdPlotTranslationLinePenColor_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlotTranslationLinePenColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotTranslationLinePenColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotTranslationLinePenColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub cmdPlotNoteTextFont_Click(sender As Object, e As EventArgs) Handles cmdPlotNoteTextFont.Click
        Using oFD As frmFontDialog = New frmFontDialog(CType(txtPlotNoteTextFont.Tag, cIFont))
            With oFD
                If .ShowDialog = vbOK Then
                    txtPlotNoteTextFont.Tag = .CurrentFont
                    txtPlotNoteTextFont.Text = .CurrentFont.ToString
                End If
            End With
        End Using
    End Sub

    Private Sub cmdPlotNoteTextColor_Click(sender As Object, e As EventArgs) Handles cmdPlotNoteTextColor.Click
        Using oCD As ColorDialog = New ColorDialog
            With oCD
                .FullOpen = True
                .AnyColor = True
                .Color = picPlotNoteTextColor.BackColor
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    picPlotNoteTextColor.BackColor = .Color
                End If
            End With
        End Using
    End Sub

    Private Sub txtAddScale_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddScale.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call btnAdd.PerformClick()
        End If
    End Sub

    Private Sub tabInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabInfo.SelectedIndexChanged
        Dim bEnabled As Boolean = (tabInfo.SelectedTab Is tabInfODesign OrElse tabInfo.SelectedTab Is tabInfoPlot)
        btnClear.Enabled = bEnabled
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Call pClearRule(tabInfo.SelectedTab)
    End Sub

    Private Sub pClearRule(ParentControl As Control)
        For Each oControl As Control In ParentControl.Controls
            If TypeOf oControl Is CheckBox Then
                DirectCast(oControl, CheckBox).Checked = False
            Else
                Call pClearRule(oControl)
            End If
        Next
    End Sub
End Class