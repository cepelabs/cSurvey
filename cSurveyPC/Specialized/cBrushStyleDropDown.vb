Imports System.IO
Imports System.Xml
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraEditors.Controls

Public Class cBrushStyleDropDown
    Private oSurvey As cSurvey.cSurvey

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        oItems = New cBrushesBaseCollection
    End Sub

    Private Sub oBrushes_onchanged(sender As Object, e As EventArgs)
        Call Rebind(sender.Survey)
    End Sub

    Public Sub Rebind(Survey As cSurvey.cSurvey)
        Dim bAddHandler As Boolean
        If oSurvey IsNot Nothing AndAlso Survey IsNot oSurvey Then
            RemoveHandler oSurvey.Brushes.OnChanged, AddressOf oBrushes_onchanged
            bAddHandler = True
        ElseIf oSurvey Is Nothing Then
            bAddHandler = True
        End If

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

        'Call oItems.Clear()
        'For Each sFilename As String In My.Computer.FileSystem.GetFiles(modMain.GetUserApplicationPath, FileIO.SearchOption.SearchTopLevelOnly, {"*.cbrush"})
        '    Dim oBrush As cCustomBrush = New cCustomBrush(oSurvey, sFilename)
        '    If Not oSurvey.Brushes.Contains(oBrush) AndAlso Not oItems.ContainsKey(oBrush) Then
        '        Call oItems.Add(oBrush)
        '        Call pAppendItem(oBrush, True)
        '    End If
        'Next

        pAppendItem(oSurvey.Brushes.FromCustom(Color.Black, GetLocalizedString("main.textpart41"), cBrush.HatchTypeEnum.None))

        cboBrushStyle.EditValue = sOldValue

        cboBrushStyle.Properties.EndUpdate()

        If bAddHandler Then
            AddHandler oSurvey.Brushes.OnChanged, AddressOf oBrushes_onchanged
        End If
    End Sub

    Private oItems As cBrushesBaseCollection

    Public Function GetUserBrush(ID As String) As cCustomBrush
        Return oItems(ID)
    End Function

    Public Sub RefreshThumbnail()
        Dim oBrush As cCustomBrush = oSurvey.Brushes.FromID(cboBrushStyle.EditValue)
        If oBrush.Type = cBrush.BrushTypeEnum.User Then
            Dim iIndex As Integer = cboBrushStyle.SelectedIndex
            iml.RemoveAt(iIndex)
            iml.Insert(iIndex, pGetThumbnail(oBrush))
            Call cboBrushStyle.Refresh()
        End If
    End Sub

    Private Function pGetThumbnail(ByRef Brush As cCustomBrush) As DevExpress.Utils.Svg.SvgImage ', Optional FromFile As Boolean = False) As DevExpress.Utils.Svg.SvgImage
        If Brush.Type = cBrush.BrushTypeEnum.User Then
            Using oms As MemoryStream = New MemoryStream
                Brush.GetThumbnailSVG(oSurvey.Options.Item("_design.plan"), cItem.PaintOptionsEnum.FullLayerDraw, False, iml.ImageSize.Width, iml.ImageSize.Height, If(False, Color.DarkGray, Color.DarkRed), Color.White).Save(oms)
                Call oms.Seek(0, SeekOrigin.Begin)
                Return DevExpress.Utils.Svg.SvgImage.FromStream(oms)
            End Using
        Else
            Return DevExpress.Utils.Svg.SvgImage.FromFile(IO.Path.Combine(modMain.GetApplicationPath, "Objects\brushes\" & Brush.Type.ToString & ".svg")) '<image=#warning;size=16,16>
        End If
    End Function

    Private Sub pAppendItem(Brush As cCustomBrush) ', Optional FromFile As Boolean = False)
        Dim oSVGImage As DevExpress.Utils.Svg.SvgImage = pGetThumbnail(Brush)
        Dim bUser As Boolean = Brush.Type = cBrush.BrushTypeEnum.User
        Call iml.Add(oSVGImage)
        Dim oItem As DevExpress.XtraEditors.Controls.ImageComboBoxItem = New DevExpress.XtraEditors.Controls.ImageComboBoxItem(Brush.Name & If(bUser, " <image=user;size=16,16>", ""), Brush.ID, iml.Count - 1)
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

    Private Sub cboBrushStyle_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles cboBrushStyle.ButtonClick
        If e.Button.Index = 1 Then
            RaiseEvent OnGalleryButtonClick(Me, EventArgs.Empty)
        End If
    End Sub

    Public Event OnGalleryButtonClick(sender As Object, e As EventArgs)
End Class
