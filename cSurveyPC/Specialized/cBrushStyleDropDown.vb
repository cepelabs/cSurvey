Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cBrushStyleDropDown
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    Public Sub Rebind(Survey As cSurvey.cSurvey)
        oSurvey = Survey

        Call cboBrushStyle.Properties.Items.Clear()
        Call iml.Clear()

        pAppendItem(oSurvey.EditPaintObjects.Brushes.None)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.Solid)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.Sand)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.Pebbles)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.Flow)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.Water)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.NotStandardWater)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.SignSolid)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.SmallDebrits)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.BigDebrits)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.SnowOrIce)
        pAppendItem(oSurvey.EditPaintObjects.Brushes.FromCustom(Color.Black, GetLocalizedString("main.textpart41"), cBrush.HatchTypeEnum.None))
    End Sub

    'Public Sub Rebind(PaintOptions As cOptions)
    '    oPaintOptions = PaintOptions

    '    Call cboBrushStyle.Properties.Items.Clear()
    '    Call iml.Clear()

    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.None)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.Solid)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.Sand)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.Pebbles)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.Flow)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.Water)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.NotStandardWater)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.SignSolid)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.SmallDebrits)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.BigDebrits)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.SnowOrIce)
    '    pAppendItem(PaintOptions.Survey.EditPaintObjects.GenericBrushes.FromCustom(Color.Black, GetLocalizedString("main.textpart41"), cBrush.HatchTypeEnum.None))
    'End Sub

    Private Sub pAppendItem(Brush As cBrush)
        Dim oSVGImage As DevExpress.Utils.Svg.SvgImage = DevExpress.Utils.Svg.SvgImage.FromFile(IO.Path.Combine(modMain.GetApplicationPath, "Objects\Brushes\" & Brush.Type.ToString & ".svg"))
        Call iml.Add(oSVGImage)
        Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(Brush.Name, Brush.Type, iml.Count - 1)
        cboBrushStyle.Properties.Items.Add(oItem)

        'Using oImage As IO.MemoryStream = New IO.MemoryStream
        '    Using oDesignBrush As cBrush = New cBrush(oPaintOptions.Survey)
        '        oDesignBrush.CopyFrom(Brush)
        '        oDesignBrush.LocalLineWidth = 2
        '        oDesignBrush.LocalZoomFactor = 2
        '        Dim oXML As XmlDocument = oDesignBrush.GetThumbnailSVG(oPaintOptions, cItem.PaintOptionsEnum.None, cItem.SelectionModeEnum.None, 32, 32, Color.Black, Color.White)
        '        Call oXML.Save(oImage)
        '        'oXML.Save("d:\" & Brush.Type.ToString & ".svg")
        '        oImage.Position = 0
        '        Dim oSVGImage As DevExpress.Utils.Svg.SvgImage = DevExpress.Utils.Svg.SvgImage.FromStream(oImage)
        '        Call iml.Add(oSVGImage)
        '        Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(Brush.Name, Brush.Type, iml.Count - 1)
        '        cboBrushStyle.Properties.Items.Add(oItem)
        '    End Using
        'End Using
    End Sub

    Public Property EditValue As cBrush.BrushTypeEnum
        Get
            If cboBrushStyle.EditValue Is Nothing Then
                Return cBrush.BrushTypeEnum.None
            Else
                Return cboBrushStyle.EditValue
            End If
        End Get
        Set(value As cBrush.BrushTypeEnum)
            cboBrushStyle.EditValue = value
        End Set
    End Property

    'Private Sub cboFontStyleView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
    '    If e.IsGetData Then
    '        e.Value = DirectCast(e.Row, cItemFont).ToHTMLString(oPaintOptions)
    '    End If
    'End Sub

    'Private Sub cboFontStyle_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)
    '    If e.Value Is Nothing Then
    '        e.DisplayText = ""
    '    Else
    '        e.DisplayText = DirectCast(e.Value, cItemFont).ToHTMLString(oPaintOptions)
    '    End If
    'End Sub

    Private Sub cFontStyleDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboBrushStyle.Height Then
            MyBase.Height = cboBrushStyle.Height
        End If
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboBrushStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboBrushStyle.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub
End Class
