Imports System.Windows.Controls
Imports System.Windows.Media.Media3D
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraCharts.Designer.Native
Imports DevExpress.XtraVerticalGrid.Events
Imports DevExpress.XtraVerticalGrid.Rows

Friend Class cItemChunk3DPropertyControl
    Private oItem As cItemChunk3D

    Private WithEvents oHolosView As cHolosItemView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        oHolosView = New cHolosItemView
        h3D.Child = oHolosView

    End Sub

    Private Sub grdChunkInfo_CustomUnboundData(sender As Object, e As CustomDataEventArgs) Handles grdChunkInfo.CustomUnboundData
        If e.IsGetData Then
            Select Case e.RowProperties.FieldName.ToLower
                Case "basefilename"
                    e.Value = oItem.ModelFiles.MainFile
                Case "station1"
                    If oItem.Stations.Station1.IsValid Then
                        e.Value = oItem.Stations.Station1.Name
                    Else
                        e.Value = ""
                    End If
                Case "station2"
                    If oItem.Stations.Station2.IsValid Then
                        e.Value = oItem.Stations.Station2.Name
                    Else
                        e.Value = ""
                    End If
                Case "transform", "transformrotate"
                    e.Value = ""
                Case "transformxrotate"
                    e.Value = oItem.ModelTransform.XRotate
                Case "transformyrotate"
                    e.Value = oItem.ModelTransform.YRotate
                Case "transformzrotate"
                    e.Value = oItem.ModelTransform.ZRotate
                Case "transformxscale"
                    e.Value = oItem.ModelTransform.XScale
                Case "transformyscale"
                    e.Value = oItem.ModelTransform.YScale
                Case "transformzscale"
                    e.Value = oItem.ModelTransform.ZScale
            End Select
        End If
    End Sub

    Private Sub pRefresh()
        grdChunkInfo.DataSource = New List(Of cItemChunk3D)({MyBase.Item})
    End Sub

    Private oGroup As ModelVisual3D

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        oItem = Item

        If oGroup IsNot Nothing Then
            Call oHolosView.mainViewport.Children.Remove(oGroup)
        End If
        oGroup = New ModelVisual3D
        oGroup.Content = oItem.GetModel
        oHolosView.mainViewport.Children.Add(oGroup)

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
        Using frmCE As frmHolosItemEdit = New frmHolosItemEdit(oItem.Survey, oItem)
            If frmCE.ShowDialog(Me) = DialogResult.OK Then
                Dim oModelEdit As frmHolosItemEdit.cModelEdit = frmCE.Result

                With oItem.ModelTransform
                    .XScale = oModelEdit.Scale
                    .YScale = oModelEdit.Scale
                    .ZScale = oModelEdit.Scale

                    .XRotate = oModelEdit.RotateX
                    .YRotate = oModelEdit.RotateY
                    .ZRotate = oModelEdit.RotateZ
                End With

                With oItem.Stations
                    .Station1.TrigPoint = oItem.Survey.TrigPoints(oModelEdit.Station1)
                    .Station1.Point = oModelEdit.Point1
                    .Station2.TrigPoint = oItem.Survey.TrigPoints(oModelEdit.Station2)
                    .Station2.Point = oModelEdit.Point2
                End With
            End If
        End Using
    End Sub
End Class
