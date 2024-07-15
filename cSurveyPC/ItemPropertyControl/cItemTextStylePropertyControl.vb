Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Navigation
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Helper.Editor
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

    Public Sub Import(PaintOptions As cOptions)
        Rebind(Item, PaintOptions)
    End Sub

    Public Shadows Sub Rebind(Item As cItem, PaintOptions As cOptions)
        MyBase.Rebind(Item)

        If oPaintOptions IsNot PaintOptions Then
            oPaintOptions = PaintOptions
            Call cboPropTextStyle.Rebind(oPaintOptions)
        End If

        cboPropTextStyle.EditValue = Me.Item.Font.Type
        If Me.Item.Font.Type = cItemFont.FontTypeEnum.Custom Then
            Call cboPropTextStyle_EditValueChanged(cboPropTextStyle, EventArgs.Empty)
        End If
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

    Private Sub txtPropText_Validated(sender As Object, e As EventArgs) Handles txtPropText.Validated
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Text")
            Me.Item.Text = txtPropText.Text
            Call MyBase.PropertyChanged("Text")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropTextRotateMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextRotateMode.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemRotable).RotateMode), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemRotable).RotateMode = value))
            DirectCast(Me.Item, cIItemRotable).RotateMode = cboPropTextRotateMode.SelectedIndex
            Call MyBase.PropertyChanged("TextRotateMode")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropTextSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextSize.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemSizable).Size), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemSizable).Size = value))
            DirectCast(Me.Item, cIItemSizable).Size = cboPropTextSize.SelectedIndex
            Call MyBase.PropertyChanged("TextSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub optPropTextAlignLeft_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextAlignLeft.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextAlignLeft.Checked Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemLineableText).TextAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemLineableText).TextAlignment = value))
                DirectCast(Me.Item, cIItemLineableText).TextAlignment = cIItemLineableText.TextAlignmentEnum.Left
                Call MyBase.PropertyChanged("TextAlignLeft")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextAlignCenter_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextAlignCenter.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextAlignCenter.Checked Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemLineableText).TextAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemLineableText).TextAlignment = value))
                DirectCast(Me.Item, cIItemLineableText).TextAlignment = cIItemLineableText.TextAlignmentEnum.Center
                Call MyBase.PropertyChanged("TextAlignCenter")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextAlignRight_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextAlignRight.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextAlignRight.Checked Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemLineableText).TextAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemLineableText).TextAlignment = value))
                DirectCast(Me.Item, cIItemLineableText).TextAlignment = cIItemLineableText.TextAlignmentEnum.Right
                Call MyBase.PropertyChanged("TextAlignRight")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextVAlignTop_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextVAlignTop.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextVAlignTop.Checked Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = value))
                DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Top
                Call MyBase.PropertyChanged("TextVAlignTop")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextVAlignCenter_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextVAlignCenter.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextVAlignCenter.Checked Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = value))
                DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Middle
                Call MyBase.PropertyChanged("TextVAlignCenter")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub optPropTextVAlignBottom_CheckedChanged(sender As Object, e As EventArgs) Handles optPropTextVAlignBottom.CheckedChanged
        If Not DisabledObjectProperty() Then
            If optPropTextVAlignBottom.Checked Then
                Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), New cUndoItemBackupValueDelegate(Function(item As cItem) DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment), New cUndoItemRestoreValueDelegate(Sub(item As cItem, value As Object) DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = value))
                DirectCast(Me.Item, cIItemVerticalLineableText).TextVerticalAlignment = cIItemVerticalLineableText.TextVerticalAlignmentEnum.Bottom
                Call MyBase.PropertyChanged("TextVAlignBottom")
                Call MyBase.MapInvalidate()
            End If
        End If
    End Sub

    Private Sub cboPropTextStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPropTextStyle.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.Type")
            Item.Font.Type = cboPropTextStyle.EditValue
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
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.FontName")
            If cboPropTextFontChar.SelectedIndex = 0 Then
                Item.Font.FontName = ""
            Else
                Item.Font.FontName = cboPropTextFontChar.EditValue
            End If
            Call MyBase.PropertyChanged("TextFontChar")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropTextFontBold_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTextFontBold.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.FontBold")
            Item.Font.FontBold = chkPropTextFontBold.Checked
            Call MyBase.PropertyChanged("TextFontBold")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropTextFontItalic_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTextFontItalic.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.FontItalic")
            Item.Font.FontItalic = chkPropTextFontItalic.Checked
            Call MyBase.PropertyChanged("TextFontItalic")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkPropTextFontUnderline_CheckedChanged(sender As Object, e As EventArgs) Handles chkPropTextFontUnderline.CheckedChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.FontUnderline")
            Item.Font.FontUnderline = chkPropTextFontUnderline.Checked
            Call MyBase.PropertyChanged("TextFontUnderline")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub txtPropFontColor_EditValueChanged(sender As Object, e As EventArgs) Handles txtPropFontColor.EditValueChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.FontUnderline")
            Item.Font.Color = txtPropFontColor.EditValue
            Call MyBase.PropertyChanged("TextFontColor")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub cboPropTextFontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPropTextFontSize.SelectedIndexChanged
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot(modMain.GetLocalizedString("main.undo47"), "Font.FontSize")
            If cboPropTextFontSize.SelectedIndex = 0 Then
                Item.Font.FontSize = 0
            Else
                Item.Font.FontSize = cboPropTextFontSize.EditValue
            End If
            Call MyBase.PropertyChanged("TextFontSize")
            Call MyBase.MapInvalidate()
        End If
    End Sub

End Class
