Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraTreeList

Friend Class cItemTextStylePropertyControl
    Private oPaintOptions As cOptions

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        Using oFonts As System.Drawing.Text.InstalledFontCollection = New System.Drawing.Text.InstalledFontCollection
            Call cboPropTextFontChar.Properties.Items.Add(GetLocalizedString("main.textpart40"))
            For Each oFontFamily As FontFamily In oFonts.Families
                Call cboPropTextFontChar.Properties.Items.Add(oFontFamily.Name)
            Next
        End Using
    End Sub

    Public Shadows ReadOnly Property Item As cIItemText
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Shadows Sub Rebind(Item As cItem, PaintOptions As cOptions)
        MyBase.Rebind(Item)

        If oPaintOptions IsNot PaintOptions Then
            oPaintOptions = PaintOptions
            Call cboPropTextStyle.Rebind(oPaintOptions)
        End If

        cboPropTextStyle.EditValue = Me.Item.Font.Type

        cboPropTextSize.SelectedIndex = DirectCast(Me.Item, cIItemSizable).Size
        If (Me.Item.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.Text) Then
            txtPropText.Text = Me.Item.Text
            txtPropText.Enabled = True
            lblPropText.Enabled = True
        Else
            txtPropText.Enabled = False
            lblPropText.Enabled = False
        End If
        If (Me.Item.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.Rotable) Then
            cboPropTextRotateMode.SelectedIndex = DirectCast(Me.Item, cIItemRotable).RotateMode
            cboPropTextRotateMode.Enabled = True
            lblPropTextRotateMode.Enabled = True
        Else
            cboPropTextRotateMode.Enabled = False
            lblPropTextRotateMode.Enabled = False
        End If
        If (Me.Item.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.Lineable) Then
            Dim oItemLineableText As cIItemLineableText = Me.Item
            optPropTextAlignLeft.Enabled = True
            optPropTextAlignCenter.Enabled = True
            optPropTextAlignRight.Enabled = True
            Select Case oItemLineableText.TextAlignment
                Case cIItemLineableText.TextAlignmentEnum.Left
                    optPropTextAlignLeft.Checked = True
                    optPropTextAlignCenter.Checked = False
                    optPropTextAlignRight.Checked = False
                Case cIItemLineableText.TextAlignmentEnum.Center
                    optPropTextAlignLeft.Checked = False
                    optPropTextAlignCenter.Checked = True
                    optPropTextAlignRight.Checked = False
                Case cIItemLineableText.TextAlignmentEnum.Right
                    optPropTextAlignLeft.Checked = False
                    optPropTextAlignCenter.Checked = False
                    optPropTextAlignRight.Checked = True
            End Select
        Else
            optPropTextAlignLeft.Checked = False
            optPropTextAlignCenter.Checked = False
            optPropTextAlignRight.Checked = False
            optPropTextAlignLeft.Enabled = False
            optPropTextAlignCenter.Enabled = False
            optPropTextAlignRight.Enabled = False
        End If
        If (Me.Item.AvaiableTextProperties And cIItemText.AvaiableTextPropertiesEnum.VerticalLineable) Then
            Dim oItemVerticalLineableText As cIItemVerticalLineableText = Me.Item
            optPropTextVAlignTop.Enabled = True
            optPropTextVAlignCenter.Enabled = True
            optPropTextVAlignBottom.Enabled = True
            Select Case oItemVerticalLineableText.TextVerticalAlignment
                Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                    optPropTextVAlignTop.Checked = True
                    optPropTextVAlignCenter.Checked = False
                    optPropTextVAlignBottom.Checked = False
                Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                    optPropTextVAlignTop.Checked = False
                    optPropTextVAlignCenter.Checked = True
                    optPropTextVAlignBottom.Checked = False
                Case cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                    optPropTextVAlignTop.Checked = False
                    optPropTextVAlignCenter.Checked = False
                    optPropTextVAlignBottom.Checked = True
            End Select
        Else
            optPropTextVAlignTop.Checked = False
            optPropTextVAlignCenter.Checked = False
            optPropTextVAlignBottom.Checked = False
            optPropTextVAlignTop.Enabled = False
            optPropTextVAlignCenter.Enabled = False
            optPropTextVAlignBottom.Enabled = False
        End If
    End Sub

    'Private Sub txtPropText_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtPropText.PreviewKeyDown
    '    If e.Control And e.KeyCode = Keys.Enter Then ' And Not e.Shift And Not e.Control And Not e.Alt Then
    '        Me.Item.Text = txtPropText.Text
    '        Call MyBase.TakeUndoSnapshot()
    '        Call MyBase.PropertyChanged("Text")
    '        Call MyBase.MapInvalidate()
    '    End If
    'End Sub

    Private Sub txtPropText_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropText.EditValueChanged
        If Not DisabledObjectProperty() Then
            Me.Item.Text = txtPropText.Text
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("Text")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropTextRotateMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextRotateMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            DirectCast(Me.Item, cIItemRotable).RotateMode = cboPropTextRotateMode.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextRotateMode")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropTextSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextSize.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            DirectCast(Me.Item, cIItemSizable).Size = cboPropTextSize.SelectedIndex
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub optPropTextAlignLeft_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextAlignLeft.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextAlignLeft.Checked Then
                DirectCast(Me.Item, cIItemLineableText).TextAlignment = cIItemLineableText.TextAlignmentEnum.Left
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("TextAlignLeft")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextAlignCenter_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextAlignCenter.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextAlignCenter.Checked Then
                DirectCast(Me.Item, cIItemLineableText).TextAlignment = cIItemLineableText.TextAlignmentEnum.Center
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("TextAlignCenter")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextAlignRight_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextAlignRight.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextAlignRight.Checked Then
                DirectCast(Me.Item, cIItemLineableText).TextAlignment = cIItemLineableText.TextAlignmentEnum.Right
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("TextAlignRight")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextVAlignTop_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextVAlignTop.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextVAlignTop.Checked Then
                DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("TextVAlignTop")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextVAlignCenter_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextVAlignCenter.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextVAlignCenter.Checked Then
                DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("TextVAlignCenter")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextVAlignBottom_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextVAlignBottom.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextVAlignBottom.Checked Then
                DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                Call MyBase.TakeUndoSnapshot()
                Call MyBase.PropertyChanged("TextVAlignBottom")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub cboPropTextStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropTextStyle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Item.Font.Type = cboPropTextStyle.EditValue
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextStyle")
            Call MyBase.MapInvalidate()
        End If

        If Item.Font.Type = cItemFont.FontTypeEnum.Custom Then
            If Me.Item.Font.FontName = "" Then
                cboPropTextFontChar.SelectedIndex = 0
            Else
                cboPropTextFontChar.EditValue = Me.Item.Font.FontName
            End If
            If Me.Item.Font.FontSize = 0 Then
                cboPropTextFontSize.SelectedIndex = 0
            Else
                cboPropTextFontSize.EditValue = Me.Item.Font.FontSize
            End If
            chkPropTextFontBold.Checked = Me.Item.Font.FontBold
            chkPropTextFontItalic.Checked = Me.Item.Font.FontItalic
            chkPropTextFontUnderline.Checked = Me.Item.Font.FontUnderline
            txtPropFontColor.EditValue = Me.Item.Font.Color

            Height = 302 * CurrentAutoScaleDimensions.Height / 96.0F
        Else
            Height = 214 * CurrentAutoScaleDimensions.Height / 96.0F
        End If
    End Sub

    Private Sub cboPropTextFontChar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextFontChar.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            If cboPropTextFontChar.SelectedIndex = 0 Then
                Item.Font.FontName = ""
            Else
                Item.Font.FontName = cboPropTextFontChar.EditValue
            End If
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextFontChar")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropTextFontBold_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTextFontBold.CheckedChanged
        If Not DisabledObjectProperty() Then
            Item.Font.FontBold = chkPropTextFontBold.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextFontBold")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropTextFontItalic_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTextFontItalic.CheckedChanged
        If Not DisabledObjectProperty() Then
            Item.Font.FontItalic = chkPropTextFontItalic.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextFontItalic")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropTextFontUnderline_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTextFontUnderline.CheckedChanged
        If Not DisabledObjectProperty() Then
            Item.Font.FontUnderline = chkPropTextFontUnderline.Checked
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextFontUnderline")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropFontColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropFontColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Item.Font.Color = txtPropFontColor.EditValue
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextFontColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropTextFontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextFontSize.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            If cboPropTextFontSize.SelectedIndex = 0 Then
                Item.Font.FontSize = 0
            Else
                Item.Font.FontSize = cboPropTextFontSize.EditValue
            End If
            Call MyBase.TakeUndoSnapshot()
            Call MyBase.PropertyChanged("TextFontSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub
End Class
