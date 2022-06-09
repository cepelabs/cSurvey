Imports System.IO
Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cPenStyleDropDown
    'Private oPaintOptions As cOptions
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        oItems = New cPensBaseCollection
    End Sub

    Public Sub Rebind(Survey As cSurvey.cSurvey)
        oSurvey = Survey

        cboPenStyle.Properties.BeginUpdate()

        Dim sOldValue As String = cboPenStyle.EditValue

        Call cboPenStyle.Properties.Items.Clear()
        Call iml.Clear()

        pAppendItem(oSurvey.Pens.None)
        pAppendItem(oSurvey.Pens.CavePen)
        pAppendItem(oSurvey.Pens.PresumedCavePen)
        pAppendItem(oSurvey.Pens.TooNarrowCavePen)
        pAppendItem(oSurvey.Pens.UnderlyingCavePen)
        pAppendItem(oSurvey.Pens.Pen)
        pAppendItem(oSurvey.Pens.PresumedPen)
        pAppendItem(oSurvey.Pens.CliffUpPen)
        pAppendItem(oSurvey.Pens.PresumedCliffUpPen)
        pAppendItem(oSurvey.Pens.CliffDownPen)
        pAppendItem(oSurvey.Pens.PresumedCliffDownPen)
        pAppendItem(oSurvey.Pens.GradientUpPen)
        pAppendItem(oSurvey.Pens.PresumedGradientUpPen)
        pAppendItem(oSurvey.Pens.GradientDownPen)
        pAppendItem(oSurvey.Pens.PresumedGradientDownPen)
        pAppendItem(oSurvey.Pens.GenericPen)
        pAppendItem(oSurvey.Pens.PresumedGenericPen)
        pAppendItem(oSurvey.Pens.TightPen)
        pAppendItem(oSurvey.Pens.PresumedTightPen)
        pAppendItem(oSurvey.Pens.OverhangUpPen)
        pAppendItem(oSurvey.Pens.PresumedOverhangUpPen)
        pAppendItem(oSurvey.Pens.OverhangDownPen)
        pAppendItem(oSurvey.Pens.PresumedOverhangDownPen)
        pAppendItem(oSurvey.Pens.MeanderPen)
        pAppendItem(oSurvey.Pens.PresumedMeanderPen)
        pAppendItem(oSurvey.Pens.IcePen)
        pAppendItem(oSurvey.Pens.PresumedIcePen)

        For Each oPen In oSurvey.Pens
            Call pAppendItem(oPen)
        Next

        Call oItems.Clear()
        For Each sFilename As String In My.Computer.FileSystem.GetFiles(modMain.GetUserApplicationPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.cpen"})
            Dim oXml As XmlDocument = New XmlDocument
            oXml.Load(sFilename)
            Dim oPen As cCustomPen = New cCustomPen(oSurvey, oXml.DocumentElement.Item("pen"))
            If Not oSurvey.Pens.Contains(oPen) Then
                Call oItems.Add(oPen)
                Call pAppendItem(oPen, True)
            End If
        Next

        pAppendItem(oSurvey.Pens.FromCustom(Color.Black, GetLocalizedString("main.textpart41"), 1, cPen.PenStylesEnum.Solid))

        cboPenStyle.EditValue = sOldValue

        cboPenStyle.Properties.EndUpdate()
    End Sub

    Private oItems As cPensBaseCollection

    Public Function GetUserPen(ID As String) As cCustomPen
        Return oItems(ID)
    End Function

    Private Sub pAppendItem(Pen As cCustomPen, Optional FromFile As Boolean = False)
        Dim oSVGImage As DevExpress.Utils.Svg.SvgImage
        If Pen.Type = cPen.PenTypeEnum.User Then
            Using oms As MemoryStream = New MemoryStream
                Pen.GetThumbnailSVG(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, iml.ImageSize.Width, iml.ImageSize.Height, If(FromFile, Color.DarkGray, Color.DarkRed), Color.White).Save(oms)
                Call oms.Seek(0, SeekOrigin.Begin)
                oSVGImage = DevExpress.Utils.Svg.SvgImage.FromStream(oms)
            End Using
        Else
            oSVGImage = DevExpress.Utils.Svg.SvgImage.FromFile(IO.Path.Combine(modMain.GetApplicationPath, "Objects\Pens\" & Pen.Type.ToString & ".svg"))
        End If
        Call iml.Add(oSVGImage)
        Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(Pen.Name, Pen.ID, iml.Count - 1)
        cboPenStyle.Properties.Items.Add(oItem)

        'Using oImage As IO.MemoryStream = New IO.MemoryStream
        '    Using oDesignPen As cPen = New cPen(oPaintOptions.Survey)
        '        oDesignPen.CopyFrom(Pen)
        '        'oDesignPen.LocalLineWidth = 0.05
        '        'oDesignPen.LocalZoomFactor = 20
        '        oDesignPen.DecorationScale = 40
        '        oDesignPen.Width = oPaintOptions.GetPenDefaultWidth(Pen.Type) * 5
        '        Select Case oDesignPen.DecorationStyle
        '            Case cPen.DecorationStylesEnum.Dash
        '                oDesignPen.DecorationSpacePercentage = oDesignPen.DecorationSpacePercentage * oDesignPen.DecorationScale
        '        End Select
        '        Dim oXML As XmlDocument = oDesignPen.GetThumbnailSVG(oPaintOptions, cItem.PaintOptionsEnum.None, cItem.SelectionModeEnum.None, 32, 32, Color.Black, Color.White)
        '        oXML.Save("d:\" & Pen.Type.ToString & ".svg")
        '        'Call oDesignPen.GetThumbnailImage(oPaintOptions, cItem.PaintOptionsEnum.None, cItem.SelectionModeEnum.None, 32, 32, Color.Black, Color.White).Save("d:\" & oDesignPen.Type.ToString & ".png", Imaging.ImageFormat.Png)
        '        oXML.Save(oImage)
        '        oImage.Position = 0
        '        Dim oSVGImage As DevExpress.Utils.Svg.SvgImage = DevExpress.Utils.Svg.SvgImage.FromStream(oImage)
        '        Call iml.Add(oSVGImage)
        '        Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(Pen.Name, Pen.Type, iml.Count - 1)
        '        cboPenStyle.Properties.Items.Add(oItem)
        '    End Using
        'End Using
    End Sub

    'Public Property EditValue As cPen.PenTypeEnum
    '    Get
    '        If cboPenStyle.EditValue Is Nothing Then
    '            Return cPen.PenTypeEnum.GenericPen
    '        Else
    '            Return cboPenStyle.EditValue
    '        End If
    '    End Get
    '    Set(value As cPen.PenTypeEnum)
    '        cboPenStyle.EditValue = value
    '    End Set
    'End Property

    Public Property EditValue As String
        Get
            If cboPenStyle.EditValue Is Nothing Then
                Return "_" & cPen.PenTypeEnum.GenericPen.ToString("D")
            Else
                Return cboPenStyle.EditValue
            End If
        End Get
        Set(value As String)
            cboPenStyle.EditValue = value
        End Set
    End Property

    Private Sub cFontStyleDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboPenStyle.Height Then
            MyBase.Height = cboPenStyle.Height
        End If
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboPenStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboPenStyle.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub
End Class
