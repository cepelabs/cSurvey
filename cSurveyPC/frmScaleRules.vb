Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Scale
Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Items

Friend Class frmScaleRules
    Private oSurvey As cSurvey.cSurvey
    Private iMode As EditStyleEnum
    Private oOptions As Design.cOptionsCenterline
    Private WithEvents oDesignProperties As cPropertiesCollection

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Try
            Call pSaveRule(DirectCast(tvScales.GetFocusedObject, UIHelpers.cScaleRulePlaceHolder))
        Catch
        End Try
        Call pAdd()
    End Sub

    Private Sub pAdd(Optional ByVal AsCopy As Boolean = False)
        Dim iScale As Integer
        Try
            iScale = btnAddScale.EditValue
            If iScale > 50000 Then
                btnAddScale.EditValue = 50000
                iScale = 50000
            End If
            If iScale < 5 Then
                btnAddScale.EditValue = 5
                iScale = 5
            End If
            Dim oRules As UIHelpers.cScaleRulescBindingList = tvScales.DataSource
            If oRules.ScaleExist(iScale) Then
                MsgBox(GetLocalizedString("scalerules.warning1"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, GetLocalizedString("scalerules.warningtitle"))
            Else
                Dim oItem As UIHelpers.cScaleRulePlaceHolder
                Dim oCurrentItem As UIHelpers.cScaleRulePlaceHolder = tvScales.GetFocusedObject
                If AsCopy And Not oCurrentItem Is Nothing Then
                    'copy current scalerule...
                    oItem = oRules.Add(iScale, oCurrentItem)
                Else
                    oItem = oRules.Add(iScale)
                End If
                'Dim oItem As ListViewItem = New ListViewItem
                'oItem.Name = iScale
                'oItem.Text = GetLocalizedString("scalerules.textpart1") & " 1:" & Strings.Format(iScale, "#,##0")
                'oItem.ImageIndex = 0
                'oItem.Tag = oScaleRule
                'Call oItem.SubItems.Add(Strings.Format(oScaleRule.Scale, "00000"))
                'Call lv.Items.Add(oItem)
                'oItem.Focused = True
                'oItem.Selected = True

                'oCurrentItem = oItem
                tvScales.SetFocusedObject(oItem)
                'Call pLoadRule(oItem)
            End If
        Catch ex As Exception
            Call MsgBox(GetLocalizedString("scalerules.warning2"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, GetLocalizedString("scalerules.warningtitle"))
        End Try
    End Sub

    Private Sub pLoadRule(ByVal Item As UIHelpers.cScaleRulePlaceHolder)
        Call ploadRule(Item.ScaleRule)
    End Sub

    Private Function pGetCheckbox(ChildControlName As String) As DevExpress.XtraEditors.CheckEdit
        Dim sChildControlName As String = ChildControlName.ToLower
        For Each oCheckBox As DevExpress.XtraEditors.CheckEdit In oCheckboxes
            If TypeOf oCheckBox.Tag Is List(Of String) Then
                If DirectCast(oCheckBox.Tag, List(Of String)).Contains(sChildControlName) Then
                    Return oCheckBox
                End If
            End If
        Next
    End Function

    Private Sub pSetDesignColorValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As Color, Control As PictureBox)
        Dim oCheckbox As DevExpress.XtraEditors.CheckEdit = pGetCheckbox(Control.Name)
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
        Dim oCheckbox As DevExpress.XtraEditors.CheckEdit = pGetCheckbox(Control.Name)
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
        Dim oCheckbox As DevExpress.XtraEditors.CheckEdit = pGetCheckbox(Control.Name)
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

    Private Sub pSetDesignNumericValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As Object, Control As DevExpress.XtraEditors.SpinEdit)
        Dim oCheckbox As DevExpress.XtraEditors.CheckEdit = pGetCheckbox(Control.Name)
        If DesignProperties.HasValue(Name) Then
            Control.EditValue = DesignProperties.GetValue(Name, DefaultValue)
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = True
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        Else
            Control.EditValue = DesignProperties.GetValue(Name, DefaultValue)
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = False
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub pSetDesignNumericValue(DesignProperties As cPropertiesCollection, Name As String, DefaultValue As Object, Control As NumericUpDown)
        Dim oCheckbox As DevExpress.XtraEditors.CheckEdit = pGetCheckbox(Control.Name)
        If DesignProperties.HasValue(Name) Then
            Control.Value = DesignProperties.GetValue(Name, DefaultValue)
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = True
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        Else
            Control.Value = DesignProperties.GetValue(Name, DefaultValue)
            If Not oCheckbox Is Nothing Then
                oCheckbox.Checked = False
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub pLoadRule(DesignProperties As cPropertiesCollection)
        'default came from designproperties parents...
        'at now (2021/12/05) the hierarchy is 
        '- survey property design
        '   - scale rule
        '       - profile specific rule
        'design
        Call pSetDesignNumericValue(DesignProperties, "BaseLineWidthScaleFactor", 0.01, txtBaseLineWidthScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseHeavyLinesScaleFactor", 8, txtBaseHeavyLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseMediumLinesScaleFactor", 3, txtBaseMediumLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseLightLinesScaleFactor", 1, txtBaseLightLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseUltraLightLinesScaleFactor", 0.3, txtBaseUltraLightLinesScaleFactor)
        Call pSetDesignNumericValue(DesignProperties, "BaseGeologyLinesScaleFactor", 0.3, txtBaseGeologyLinesScaleFactor)
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
        Call pSetDesignNumericValue(DesignProperties, "PlotSplayCrossScale", 1, txtPlotSplayCrossScale)

        If Not tabMain.Enabled Then tabMain.Enabled = True
    End Sub

    Private Sub ploadRule(ByVal ScaleRule As cIScaleRule)
        With ScaleRule
            txtScale.Value = .Scale

            Call tvCategoriesVisibility.Nodes.Clear()
            For Each iCategory As cIItem.cItemCategoryEnum In [Enum].GetValues(GetType(cIItem.cItemCategoryEnum))
                Dim oValues() As Object = {DirectCast(iCategory, Integer), iCategory.ToString, .Categories(iCategory)}
                Call tvCategoriesVisibility.Nodes.Add(oValues)
            Next
        End With
        Call pLoadRule(ScaleRule.DesignProperties)
    End Sub

    Private Sub pSaveRule(DesignProperties As cPropertiesCollection)
        With DesignProperties
            .Clear()

            If txtBaseLineWidthScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseLineWidthScaleFactor", txtBaseLineWidthScaleFactor.Value)
            If txtBaseHeavyLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseHeavyLinesScaleFactor", txtBaseHeavyLinesScaleFactor.Value)
            If txtBaseMediumLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseMediumLinesScaleFactor", txtBaseMediumLinesScaleFactor.Value)
            If txtBaseLightLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseLightLinesScaleFactor", txtBaseLightLinesScaleFactor.Value)
            If txtBaseUltraLightLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseUltraLightLinesScaleFactor", txtBaseUltraLightLinesScaleFactor.Value)
            If txtBaseGeologyLinesScaleFactor.Enabled Then Call DesignProperties.SetValue("BaseGeologyLinesScaleFactor", txtBaseGeologyLinesScaleFactor.Value)

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
            If txtPlotSplayCrossScale.Enabled Then Call DesignProperties.SetValue("PlotSplayCrossScale", txtPlotSplayCrossScale.Value)

            If txtPlotTextScaleFactor.Enabled Then Call DesignProperties.SetValue("PlotTextScaleFactor", txtPlotTextScaleFactor.Value)
            If txtPlotTextFont.Enabled Then Call DesignProperties.SetValue("PlotTextFont", txtPlotTextFont.Tag)
            If picPlotTextColor.Enabled Then Call DesignProperties.SetValue("PlotTextColor", picPlotTextColor.BackColor)

            If txtPlotNoteTextScaleFactor.Enabled Then Call DesignProperties.SetValue("PlotNoteTextScaleFactor", txtPlotNoteTextScaleFactor.Value)
            If txtPlotNoteTextFont.Enabled Then Call DesignProperties.SetValue("PlotNoteTextFont", txtPlotNoteTextFont.Tag)
            If picPlotNoteTextColor.Enabled Then Call DesignProperties.SetValue("PlotNoteTextColor", picPlotNoteTextColor.BackColor)
        End With
    End Sub

    Private Sub pSaveRule(Item As UIHelpers.cScaleRulePlaceHolder)
        If Not Item Is Nothing Then
            With Item.ScaleRule
                For Each oNode As DevExpress.XtraTreeList.Nodes.TreeListNode In tvCategoriesVisibility.Nodes
                    Dim iCategory As cIItem.cItemCategoryEnum = oNode.Item(0)
                    Dim bVisibility As Boolean = oNode.Item(2)
                    Call .Categories.SetVisibility(iCategory, bVisibility)
                Next
                Call pSaveRule(.DesignProperties)
            End With
        End If
    End Sub

    'Private Class cScaleRuleListViewComparer
    '    Implements IComparer
    '    Private iColumnIndex As Integer
    '    Private iSortOrder As SortOrder

    '    Public Sub New(ByVal ColumnIndex As Integer, ByVal SortOrder As SortOrder)
    '        iColumnIndex = 1
    '        iSortOrder = SortOrder.Ascending
    '    End Sub

    '    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
    '        Dim oItemX As ListViewItem = DirectCast(x, ListViewItem)
    '        Dim sX As String = oItemX.SubItems(iColumnIndex).Text
    '        Dim oItemY As ListViewItem = DirectCast(y, ListViewItem)
    '        Dim sY As String = oItemY.SubItems(iColumnIndex).Text
    '        Return String.Compare(sX, sY)
    '    End Function
    'End Class

    Public Enum EditStyleEnum
        ScaleRule = 0
        BaseRule = 1
    End Enum

    Public Sub New(ByVal Survey As cSurveyPC.cSurvey.cSurvey, Mode As EditStyleEnum, Optional Options As Design.cOptionsCenterline = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        iMode = Mode

        'create, for each label, a checkbox with same caption and posizion and hide label...
        'of course I can change every label but for now I prefer to leave the form as is and wait for future implementations...
        Call pLabelToCheckboxes(tabInfoDesign)
        Call pLabelToCheckboxes(tabInfoPlot)

        Select Case Mode
            Case EditStyleEnum.ScaleRule
                tvScales.DataSource = New UIHelpers.cScaleRulescBindingList(oSurvey)
            Case EditStyleEnum.BaseRule
                oOptions = Options
                Text = modMain.GetLocalizedString("scalerules.baseruletitle")
                oDesignProperties = New cPropertiesCollection(oSurvey)
                Call oDesignProperties.CopyFrom(oOptions.DesignProperties)

                tvScales.Visible = False
                Width -= tvScales.Width
                tabMain.Enabled = True
                'tabInfo.Location = New Point(12, tbMain.Height + 13)
                'tabInfo.Size = New Size(Me.ClientRectangle.Width - tabInfo.Location.X * 2, Me.ClientRectangle.Height - tabInfo.Location.Y - 12 - 32)
                btnAddScale.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnAddAsCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnRemove.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnRemoveAll.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                btnClear.Enabled = True
                btnExport.Enabled = True

                tabInfoMain.PageVisible = False
                tabInfoCategories.PageVisible = False
        End Select

        tabMain.SelectedTabPage = tabInfoMain

        Call pRefresh()
    End Sub

    Private bDisabledCheckChange As Boolean
    Private oCheckboxes As List(Of DevExpress.XtraEditors.CheckEdit) = New List(Of DevExpress.XtraEditors.CheckEdit)

    Private Sub pLabelToCheckboxes(ParentControl As Control)
        For Each oControl As Control In ParentControl.Controls
            If TypeOf oControl Is DevExpress.XtraEditors.LabelControl Then
                Dim oLabel As DevExpress.XtraEditors.LabelControl = oControl
                Dim oCheckbox As DevExpress.XtraEditors.CheckEdit = New DevExpress.XtraEditors.CheckEdit
                oCheckbox.Name = "chk" & oLabel.Name
                oCheckbox.Location = oLabel.Location
                oCheckbox.Properties.AutoWidth = True
                'oCheckbox.Size = oLabel.Size    'useful?
                oCheckbox.Text = oLabel.Text
                If Not IsNothing(oLabel.Tag) Then
                    oCheckbox.Tag = New List(Of String)(oLabel.Tag.ToString.ToLower.Split({";"c}))
                    AddHandler oCheckbox.CheckedChanged, AddressOf oCheckbox_checkchanged
                End If
                oLabel.Visible = False
                oCheckbox.Visible = True
                Call ParentControl.Controls.Add(oCheckbox)
                Call oCheckbox_checkchanged(oCheckbox, EventArgs.Empty)

                Call oCheckboxes.Add(oCheckbox)
            Else
                Call pLabelToCheckboxes(oControl)
            End If
        Next
    End Sub

    Private Sub oCheckbox_checkchanged(sender As Object, e As EventArgs)
        'If Not bDisabledCheckChange Then
        Dim oCheckBox As DevExpress.XtraEditors.CheckEdit = DirectCast(sender, DevExpress.XtraEditors.CheckEdit)
        Dim bEnabled As Boolean = oCheckBox.Checked
        Dim oChildControls As List(Of String) = oCheckBox.Tag
        If oChildControls IsNot Nothing Then
            For Each oChildControl As Control In oCheckBox.Parent.Controls
                If oChildControls.Contains(oChildControl.Name.ToLower) Then
                    oChildControl.Enabled = bEnabled
                End If
            Next
        End If
        'End If
    End Sub

    Private Sub pRefresh()
        Select Case iMode
            Case EditStyleEnum.BaseRule
                Call pLoadRule(oDesignProperties)
            Case EditStyleEnum.ScaleRule
                Call tvScales_FocusedNodeChanged(tvScales, New DevExpress.XtraTreeList.FocusedNodeChangedEventArgs(tvScales.FocusedNode, tvScales.FocusedNode))
                'Call lv.Items.Clear()
                'For Each oScaleRule As cScaleRule In oScaleRules
                '    Dim oItem As ListViewItem = New ListViewItem
                '    oItem.Name = oScaleRule.Scale
                '    oItem.Text = GetLocalizedString("scalerules.textpart1") & " 1:" & Strings.Format(oScaleRule.Scale, "#,##0")
                '    oItem.ImageIndex = 0
                '    oItem.Tag = oScaleRule
                '    Call oItem.SubItems.Add(Strings.Format(oScaleRule.Scale, "00000"))
                '    Call lv.Items.Add(oItem)
                'Next
                'If lv.Items.Count > 0 Then
                '    lv.Items(0).Selected = True
                'End If
                'Call lv_SelectedIndexChanged(lv, EventArgs.Empty)
        End Select
    End Sub

    Private Sub btnRemove_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemove.ItemClick
        DirectCast(tvScales.DataSource, UIHelpers.cScaleRulescBindingList).Remove(tvScales.GetFocusedObject.scale)
        'Try
        '    Dim oItem As ListViewItem = lv.SelectedItems(0)
        '    Dim iIndex As Integer = oItem.Index
        '    Dim oScaleRule As cScaleRule = oItem.Tag
        '    Call oScaleRules.Remove(oScaleRule)
        '    Call oItem.Remove()
        '    Try
        '        Dim iNewIndex As Integer
        '        If iIndex > 0 Then
        '            iNewIndex = iIndex - 1
        '        End If
        '        Dim oNewItem As ListViewItem = lv.Items(iNewIndex)
        '        oNewItem.Selected = True
        '        oNewItem.Focused = True
        '        Call pLoadRule(oNewItem.Tag)
        '    Catch
        '    End Try
        '    'Call lv_SelectedIndexChanged(lv, EventArgs.Empty)
        'Catch
        'End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Select Case iMode
            Case EditStyleEnum.BaseRule
                Call pSaveRule(oDesignProperties)
                Call oOptions.DesignProperties.CopyFrom(oDesignProperties)
                Call oSurvey.RaiseOnPropertiesChanged(cSurvey.cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.DefaultProperties)
            Case EditStyleEnum.ScaleRule
                Call pSaveRule(DirectCast(tvScales.GetFocusedObject, UIHelpers.cScaleRulePlaceHolder))
                DirectCast(tvScales.DataSource, UIHelpers.cScaleRulescBindingList).Save()
                'Call oSurvey.ScaleRules.CopyFrom(oScaleRules)
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
        Dim oItems As UIHelpers.cScaleRulescBindingList = tvScales.DataSource
        Dim oItem As UIHelpers.cScaleRulePlaceHolder = tvScales.GetFocusedObject
        If oItems.ScaleExist(iNewScale) Then
            If Not oItem Is oItems.GetRule(iNewScale) Then
                Call MsgBox(GetLocalizedString("scalerules.warning1"), MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, GetLocalizedString("scalerules.warningtitle"))
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnAddAsCopy_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddAsCopy.ItemClick
        Try
            Call pSaveRule(DirectCast(tvScales.GetFocusedObject, UIHelpers.cScaleRulePlaceHolder))
        Catch
        End Try
        Call pAdd(True)
    End Sub

    Private Sub btnRemoveAll_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRemoveAll.ItemClick
        If MsgBox(GetLocalizedString("scalerules.warning3"), MsgBoxStyle.YesNo Or MsgBoxStyle.Question, GetLocalizedString("scalerules.warningtitle")) = MsgBoxResult.Yes Then
            Call DirectCast(tvScales.DataSource, UIHelpers.cScaleRulescBindingList).Clear()
            'Call lv.Items.Clear()
            tabMain.Enabled = False
            'Call lv_SelectedIndexChanged(lv, EventArgs.Empty)
        End If
    End Sub

    Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
        Select Case iMode
            Case EditStyleEnum.BaseRule
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
                Using oSFD As SaveFileDialog = New SaveFileDialog
                    With oSFD
                        .Title = GetLocalizedString("scalerules.exportdialog")
                        .Filter = GetLocalizedString("scalerules.filetypeXML") & " (*.XML)|*.XML|" & GetLocalizedString("scalerules.filetypeALL") & " (*.*)|*.*"
                        .FilterIndex = 1
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            Dim oFile As cFile = New cFile
                            Dim oXML As XmlDocument = oFile.Document
                            Dim oXMLRoot As XmlElement = oXML.CreateElement("scalerules")
                            Dim oScaleRules As cScaleRules = DirectCast(tvScales.DataSource, UIHelpers.cScaleRulescBindingList).Scalerules
                            Call oScaleRules.SaveTo(oFile, oFile.Document, oXMLRoot)
                            Call oXML.AppendChild(oXMLRoot)
                            Call oFile.Document.Save(.FileName)
                        End If
                    End With
                End Using
        End Select
    End Sub

    Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
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
                                Dim oItems As UIHelpers.cScaleRulescBindingList = DirectCast(tvScales.DataSource, UIHelpers.cScaleRulescBindingList)
                                For Each oImportedScaleRule As cScaleRule In oImportedScaleRules
                                    If oItems.ScaleExist(oImportedScaleRule.Scale) Then
                                        Call oItems.Remove(oImportedScaleRule.Scale)
                                    End If
                                    Dim oItem As UIHelpers.cScaleRulePlaceHolder = oItems.Add(oImportedScaleRule.Scale)
                                    Call oItem.CopyFrom(oImportedScaleRule)
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

    Private Sub txtAddScale_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Call btnAdd.PerformClick()
        End If
    End Sub

    Private Sub btnClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClear.ItemClick
        Call pClearRule(tabMain.SelectedTabPage)
    End Sub

    Private Sub pClearRule(ParentControl As Control)
        For Each oControl As Control In ParentControl.Controls
            If TypeOf oControl Is DevExpress.XtraEditors.CheckEdit Then
                DirectCast(oControl, DevExpress.XtraEditors.CheckEdit).Checked = False
            Else
                Call pClearRule(oControl)
            End If
        Next
    End Sub

    Private Sub txtAddScale_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles txtAddScale.EditValueChanging
        btnAdd.Enabled = e.NewValue.trim <> ""
    End Sub

    Private Sub tvScales_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles tvScales.FocusedNodeChanged
        If e.OldNode IsNot Nothing Then
            Call pSaveRule(DirectCast(tvScales.GetRow(e.OldNode.Id), UIHelpers.cScaleRulePlaceHolder))
        End If
        If e.Node Is Nothing Then
            tabMain.Enabled = False
            btnAddAsCopy.Enabled = False
            btnRemove.Enabled = False
            btnClear.Enabled = False
            btnExport.Enabled = False
        Else
            Call pLoadRule(DirectCast(tvScales.GetRow(e.Node.Id), UIHelpers.cScaleRulePlaceHolder))
            btnAddAsCopy.Enabled = True
            btnRemove.Enabled = True
            btnClear.Enabled = True
            btnExport.Enabled = True
        End If
        btnRemoveAll.Enabled = tvScales.DataSource.count > 0
    End Sub

    Private Sub tabMain_TabIndexChanged(sender As Object, e As EventArgs) Handles tabMain.TabIndexChanged
        Dim bEnabled As Boolean = (tabMain.SelectedTabPage Is tabInfoDesign OrElse tabMain.SelectedTabPage Is tabInfoPlot)
        btnClear.Enabled = bEnabled
    End Sub

    Private Sub txtScale_ValueChanged(sender As Object, e As EventArgs) Handles txtScale.ValueChanged
        Dim oItem As UIHelpers.cScaleRulePlaceHolder = tvScales.GetFocusedObject
        If oItem IsNot Nothing Then
            Call oItem.SetScale(txtScale.Value)
            tvScales.RefreshFocusedObject
        End If
    End Sub

    Private Sub oDesignProperties_OnGetParent(sender As Object, e As cPropertiesCollection.cGetParentEventArgs) Handles oDesignProperties.OnGetParent
        e.Parent = oOptions.CurrentRule.DesignProperties
    End Sub
End Class