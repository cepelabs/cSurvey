Imports System.IO
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
        oItems = New cBrushesBaseCollection
    End Sub

    Public Sub Rebind(Survey As cSurvey.cSurvey)
        oSurvey = Survey

        cboBrushStyle.Properties.BeginUpdate()

        Dim sOldValue As String = cboBrushStyle.EditValue

        Call cboBrushStyle.Properties.Items.Clear()
        Call iml.Clear()

        pAppendItem(oSurvey.Brushes.None)
        pAppendItem(oSurvey.Brushes.Solid)
        pAppendItem(oSurvey.Brushes.Sand)
        pAppendItem(oSurvey.Brushes.Pebbles)
        pAppendItem(oSurvey.Brushes.Flow)
        pAppendItem(oSurvey.Brushes.Water)
        pAppendItem(oSurvey.Brushes.NotStandardWater)
        pAppendItem(oSurvey.Brushes.SignSolid)
        pAppendItem(oSurvey.Brushes.SmallDebrits)
        pAppendItem(oSurvey.Brushes.BigDebrits)
        pAppendItem(oSurvey.Brushes.SnowOrIce)

        For Each oBrush In oSurvey.Brushes
            Call pAppendItem(oBrush)
        Next

        Call oItems.Clear()
        For Each sFilename As String In My.Computer.FileSystem.GetFiles(modMain.GetUserApplicationPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.cbrush"})
            Dim oXml As XmlDocument = New XmlDocument
            oXml.Load(sFilename)
            Dim oBrush As cCustomBrush = New cCustomBrush(oSurvey, Nothing, oXml.DocumentElement.Item("brush"))
            If Not oSurvey.Brushes.Contains(oBrush) Then
                Call oItems.Add(oBrush)
                Call pAppendItem(oBrush, True)
            End If
        Next

        pAppendItem(oSurvey.Brushes.FromCustom(Color.Black, GetLocalizedString("main.textpart41"), cBrush.HatchTypeEnum.None))

        cboBrushStyle.EditValue = sOldValue

        cboBrushStyle.Properties.EndUpdate()
    End Sub

    Private oItems As cBrushesBaseCollection

    Public Function GetUserBrush(ID As String) As cCustomBrush
        Return oItems(ID)
    End Function

    Private Sub pAppendItem(Brush As cCustomBrush, Optional FromFile As Boolean = False)
        Dim oSVGImage As DevExpress.Utils.Svg.SvgImage
        If Brush.Type = cBrush.BrushTypeEnum.User Then
            Using oms As MemoryStream = New MemoryStream
                Brush.GetThumbnailSVG(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, iml.ImageSize.Width, iml.ImageSize.Height, If(FromFile, Color.DarkGray, Color.DarkRed), Color.White).Save(oms)
                Call oms.Seek(0, SeekOrigin.Begin)
                oSVGImage = DevExpress.Utils.Svg.SvgImage.FromStream(oms)
            End Using
        Else
            oSVGImage = DevExpress.Utils.Svg.SvgImage.FromFile(IO.Path.Combine(modMain.GetApplicationPath, "Objects\brushes\" & Brush.Type.ToString & ".svg"))
        End If
        Call iml.Add(oSVGImage)
        Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(Brush.Name, Brush.ID, iml.Count - 1)
        cboBrushStyle.Properties.Items.Add(oItem)
    End Sub

    Public Property EditValue As String
        Get
            If cboBrushStyle.EditValue Is Nothing Then
                Return "_" & cBrush.BrushTypeEnum.None.ToString("D")
            Else
                Return cboBrushStyle.EditValue
            End If
        End Get
        Set(value As String)
            cboBrushStyle.EditValue = value
        End Set
    End Property

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
