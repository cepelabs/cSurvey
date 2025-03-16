Imports System.Windows.Controls
Imports System.Windows.Media.Media3D
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraCharts.Designer.Native
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows

Friend Class cItemChunk3DPropertyControl
    Private WithEvents oHolosView As cHolosItemView

    Public Shadows ReadOnly Property Item As cItemChunk3D
        Get
            Return MyBase.Item
        End Get
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        oHolosView = New cHolosItemView
        h3D.Child = oHolosView

        SimpleButton1.Visible = bIsInDebug
    End Sub

    Private Sub grdChunkInfo_CustomUnboundData(sender As Object, e As CustomDataEventArgs) Handles grdChunkInfo.CustomUnboundData
        If e.IsGetData Then
            Select Case e.RowProperties.FieldName.ToLower
                Case "basefilename"
                    e.Value = Item.ModelFiles.MainFile
                Case "station1"
                    If Item.Stations.Station1.IsValid Then
                        e.Value = Item.Stations.Station1.Name
                    Else
                        e.Value = ""
                    End If
                Case "station2"
                    If Item.Stations.Station2.IsValid Then
                        e.Value = Item.Stations.Station2.Name
                    Else
                        e.Value = ""
                    End If
                Case "transform", "transformrotate"
                    e.Value = ""
                Case "transformxrotate"
                    e.Value = Item.ModelTransform.XRotate
                Case "transformyrotate"
                    e.Value = Item.ModelTransform.YRotate
                Case "transformzrotate"
                    e.Value = Item.ModelTransform.ZRotate
                Case "transformxscale"
                    e.Value = Item.ModelTransform.XScale
                Case "transformyscale"
                    e.Value = Item.ModelTransform.YScale
                Case "transformzscale"
                    e.Value = Item.ModelTransform.ZScale
            End Select
        End If
    End Sub

    Private Sub pRefresh()
        grdChunkInfo.DataSource = New List(Of cItemChunk3D)({MyBase.Item})
    End Sub

    Private oGroup As ModelVisual3D

    Private Sub cmdPropModelLoad_Click(sender As Object, e As EventArgs) Handles cmdPropModelLoad.Click
        Cursor = Cursors.AppStarting
        cmdPropModelLoad.Visible = False
        If oGroup IsNot Nothing Then
            Call oHolosView.mainViewport.Children.Remove(oGroup)
        End If
        oGroup = New ModelVisual3D
        oGroup.Content = Item.LoadModel
        oHolosView.mainViewport.Children.Add(oGroup)
        Cursor = Cursors.Default
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        If Me.Item IsNot Item Then
            cmdPropModelLoad.Visible = True
            If oGroup IsNot Nothing Then
                Call oHolosView.mainViewport.Children.Remove(oGroup)
                oGroup = Nothing
            End If
        End If

        If grdChunkInfo.Rows.Count = 0 Then
            grdChunkInfo.Rows.Clear()

            Call grdChunkInfo.RowAdd("basefilename", GetLocalizedString("itemchunk.textpart3"), DevExpress.Data.UnboundColumnType.String)

            Call grdChunkInfo.RowAdd("station1", GetLocalizedString("itemchunk.textpart1"), DevExpress.Data.UnboundColumnType.String)
            Call grdChunkInfo.RowAdd("station2", GetLocalizedString("itemchunk.textpart2"), DevExpress.Data.UnboundColumnType.String)

            Dim oTransformRow As EditorRow = grdChunkInfo.RowAdd("transform", GetLocalizedString("itemchunk.textpart4"), DevExpress.Data.UnboundColumnType.String)
            Dim oTransformRowScale As EditorRow = grdChunkInfo.RowAdd(oTransformRow, "transformscale", GetLocalizedString("itemchunk.textpart9"), DevExpress.Data.UnboundColumnType.String)
            Call grdChunkInfo.RowAdd(oTransformRowScale, "transformxscale", GetLocalizedString("itemchunk.textpart6"), DevExpress.Data.UnboundColumnType.Decimal)
            Call grdChunkInfo.RowAdd(oTransformRowScale, "transformyscale", GetLocalizedString("itemchunk.textpart7"), DevExpress.Data.UnboundColumnType.Decimal)
            Call grdChunkInfo.RowAdd(oTransformRowScale, "transformzscale", GetLocalizedString("itemchunk.textpart8"), DevExpress.Data.UnboundColumnType.Decimal)
            Dim oTransformRowRotation As EditorRow = grdChunkInfo.RowAdd(oTransformRow, "transformrotate", GetLocalizedString("itemchunk.textpart5"), DevExpress.Data.UnboundColumnType.String)
            Call grdChunkInfo.RowAdd(oTransformRowRotation, "transformxrotate", GetLocalizedString("itemchunk.textpart6"), DevExpress.Data.UnboundColumnType.Decimal)
            Call grdChunkInfo.RowAdd(oTransformRowRotation, "transformyrotate", GetLocalizedString("itemchunk.textpart7"), DevExpress.Data.UnboundColumnType.Decimal)
            Call grdChunkInfo.RowAdd(oTransformRowRotation, "transformzrotate", GetLocalizedString("itemchunk.textpart8"), DevExpress.Data.UnboundColumnType.Decimal)
        End If

        Call pRefresh()
    End Sub

    Private Sub cmdPropModelEdit_Click(sender As Object, e As EventArgs) Handles cmdPropModelEdit.Click
        Using frmCE As frmHolosItemEdit = New frmHolosItemEdit(Item.Survey, Item)
            If frmCE.ShowDialog(Me) = DialogResult.OK Then
                Dim oModelEdit As frmHolosItemEdit.cModelEdit = frmCE.Result

                With Item.ModelTransform
                    .XScale = oModelEdit.Scale
                    .YScale = oModelEdit.Scale
                    .ZScale = oModelEdit.Scale

                    .XRotate = oModelEdit.RotateX
                    .YRotate = oModelEdit.RotateY
                    .ZRotate = oModelEdit.RotateZ
                End With

                With Item.Stations
                    .Station1.TrigPoint = Item.Survey.TrigPoints(oModelEdit.Station1)
                    .Station1.Point = oModelEdit.Point1
                    .Station2.TrigPoint = Item.Survey.TrigPoints(oModelEdit.Station2)
                    .Station2.Point = oModelEdit.Point2
                End With
            End If
        End Using
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Item.GetPlanImage()
    End Sub

    'Private Sub cItemChunk3DPropertyControl_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
    '    Call Item.GetPlanImage()
    'End Sub
End Class
