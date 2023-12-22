Imports System.Windows.Media.Media3D
Imports HelixToolkit.Wpf
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Accessibility
Imports DevExpress.Office.Utils
Imports System.Windows.Media
Imports DevExpress.Utils.Extensions
Imports System.Xml
Imports DevExpress.XtraCharts.Designer
Imports cSurveyPC.cSurvey.Design.Items

Public Class frmHolosItemEdit

    Private oSurvey As cSurvey.cSurvey
    Private WithEvents oHolosEdit As cHolosItemEdit
    Private bStarted As Boolean
    Private sFilename As String

    Public Sub New(Survey As cSurvey.cSurvey)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        oHolosEdit = New cHolosItemEdit
        h3D.Child = oHolosEdit
    End Sub

    Public Sub New(Survey As cSurvey.cSurvey, Item As cItemChunk3D)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oSurvey = Survey
        oHolosEdit = New cHolosItemEdit
        h3D.Child = oHolosEdit

        Text = modMain.GetLocalizedString("3ditemedit.editdialogtitle")

        bdisableEvent = True
        sFilename = ""
        Dim oGroup As ModelVisual3D = New ModelVisual3D
        oGroup.Content = Item.GetModel
        Viewport.Children.Add(oGroup)

        txtScale.EditValue = modNumbers.StringToDecimal(Item.ModelTransform.XScale)
        txtxrotate.EditValue = modNumbers.StringToDecimal(Item.ModelTransform.XRotate)
        txtyrotate.EditValue = modNumbers.StringToDecimal(Item.ModelTransform.YRotate)
        txtzrotate.EditValue = modNumbers.StringToDecimal(Item.ModelTransform.ZRotate)
        If Item.Stations.Station1.IsValid Then
            txtStation1.EditValue = Item.Stations.Station1.TrigPoint.Name
            txt1.EditValue = Item.Stations.Station1.Point.X & ";" & Item.Stations.Station1.Point.Y & ";" & Item.Stations.Station1.Point.Z
        End If
        If Item.Stations.Station2.IsValid Then
            txtStation2.EditValue = Item.Stations.Station2.TrigPoint.Name
            txt2.EditValue = Item.Stations.Station2.Point.X & ";" & Item.Stations.Station2.Point.Y & ";" & Item.Stations.Station2.Point.Z
        End If
        bdisableEvent = False

        bStarted = True

        Call pUpdateTransform()
        Call txt1_EditValueChanged(txt1, EventArgs.Empty)
        Call txt2_EditValueChanged(txt2, EventArgs.Empty)
    End Sub

    Friend Sub AddGroup(Filename As String, Group As ModelVisual3D)
        bStarted = True
        sFilename = Filename
        Viewport.Children.Add(Group)

        Dim sPresetFilename As String = IO.Path.Combine(IO.Path.GetDirectoryName(sFilename), IO.Path.GetFileNameWithoutExtension(sFilename) & ".3DChunckx")
        If My.Computer.FileSystem.FileExists(sPresetFilename) Then
            Call pPresetLoad(sPresetFilename)
        Else
            Call pUpdateTransform()
            Call pUpdatePositions()
        End If
    End Sub

    Friend ReadOnly Property Viewport As HelixViewport3D
        Get
            Return oHolosEdit.mainViewport
        End Get
    End Property

    Private Sub zrotate_EditValueChanged(sender As Object, e As EventArgs) Handles zrotate.EditValueChanged
        txtzrotate.EditValue = zrotate.EditValue
    End Sub

    Private Sub yrotate_EditValueChanged(sender As Object, e As EventArgs) Handles yrotate.EditValueChanged
        txtyrotate.EditValue = yrotate.EditValue
    End Sub

    Private Sub xrotate_EditValueChanged(sender As Object, e As EventArgs) Handles xrotate.EditValueChanged
        txtxrotate.EditValue = xrotate.EditValue
    End Sub

    Private Sub pUpdateTransform()
        If bStarted Then
            Dim oTransformGroup As Transform3DGroup = New Transform3DGroup()
            Call oTransformGroup.Children.Add(New ScaleTransform3D(txtScale.EditValue, txtScale.EditValue, txtScale.EditValue))
            Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(1, 0, 0), txtxrotate.EditValue)))
            Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 1, 0), txtyrotate.EditValue)))
            Call oTransformGroup.Children.Add(New RotateTransform3D(New Media.Media3D.AxisAngleRotation3D(New Media.Media3D.Vector3D(0, 0, 1), txtzrotate.EditValue)))
            'Call oTransformGroup.Children.Add(New TranslateTransform3D(0, 0, 0))
            Dim oGroup As ModelVisual3D = Viewport.Children(Viewport.Children.Count - 1)
            oGroup.Transform = oTransformGroup
        End If
    End Sub

    Private Sub txtxrotate_EditValueChanged(sender As Object, e As EventArgs) Handles txtxrotate.EditValueChanged
        xrotate.EditValue = txtxrotate.EditValue
        Call pUpdateTransform()
    End Sub

    Private Sub txtyrotate_EditValueChanged(sender As Object, e As EventArgs) Handles txtyrotate.EditValueChanged
        yrotate.EditValue = txtyrotate.EditValue
        Call pUpdateTransform()
    End Sub

    Private Sub txtzrotate_EditValueChanged(sender As Object, e As EventArgs) Handles txtzrotate.EditValueChanged
        zrotate.EditValue = txtzrotate.EditValue
        Call pUpdateTransform()
    End Sub

    Private Sub txtScale_EditValueChanged(sender As Object, e As EventArgs) Handles txtScale.EditValueChanged
        Call pUpdateTransform()
    End Sub

    Private Sub oHolosEdit_MouseDown(sender As Object, e As MouseButtonEventArgs) Handles oHolosEdit.MouseDown
        Call pUpdatePositions()
    End Sub

    Private Sub oHolosEdit_MouseMove(sender As Object, e As MouseEventArgs) Handles oHolosEdit.MouseMove
        Call pUpdatePositions()
    End Sub

    Private Sub oHolosEdit_MouseUp(sender As Object, e As MouseButtonEventArgs) Handles oHolosEdit.MouseUp
        Call pUpdatePositions()
    End Sub

    Private bdisableEvent As Boolean

    Private Sub pUpdatePositions()
        If bStarted Then
            bdisableEvent = True
            Dim oTrasformation As Transform3DGroup = New Transform3DGroup()
            Call oTrasformation.Children.Add(New ScaleTransform3D(txtScale.EditValue, txtScale.EditValue, txtScale.EditValue))

            Dim oCube1 As CubeVisual3D = Viewport.FindName("cube_station1")
            Dim oCube1Bound As Rect3D = oCube1.FindBounds(oCube1.Transform)
            Dim oCube1Center As Point3D = New Point3D(oCube1Bound.X + oCube1Bound.SizeX / 2.0F, oCube1Bound.Y + oCube1Bound.SizeY / 2.0F, oCube1Bound.Z + oCube1Bound.SizeZ / 2.0F)
            'oCube1Center = oTrasformation.Transform(oCube1Center)
            txt1.Text = Math.Round(oCube1Center.X / 2.0, 2) & ";" & Math.Round(oCube1Center.Y / 2.0, 2) & ";" & Math.Round(oCube1Center.Z / 2.0, 2)
            Dim oCube2 As CubeVisual3D = Viewport.FindName("cube_station2")
            Dim oCube2Bound As Rect3D = oCube2.FindBounds(oCube2.Transform)
            Dim oCube2Center As Point3D = New Point3D(oCube2Bound.X + oCube2Bound.SizeX / 2.0F, oCube2Bound.Y + oCube2Bound.SizeY / 2.0F, oCube2Bound.Z + oCube2Bound.SizeZ / 2.0F)
            'oCube2Center = oTrasformation.Transform(oCube2Center)
            txt2.Text = Math.Round(oCube2Center.X / 2.0, 2) & ";" & Math.Round(oCube2Center.Y / 2.0, 2) & ";" & Math.Round(oCube2Center.Z / 2.0, 2)
            bdisableEvent = False
        End If
    End Sub

    Public Class cModelEdit
        Private sStation1 As String
        Private sX1 As Single
        Private sY1 As Single
        Private sZ1 As Single

        Private sStation2 As String
        Private sX2 As Single
        Private sY2 As Single
        Private sZ2 As Single

        Private sScale As Single
        Private sRotateX As Single
        Private sRotateY As Single
        Private sRotateZ As Single

        Private oPoint1 As Point3D
        Private bPoint1 As Boolean
        Private oPoint2 As Point3D
        Private bPoint2 As Boolean

        Public ReadOnly Property Point2 As Point3D
            Get
                If Not bPoint2 Then
                    oPoint2 = New Point3D(sX2, sY2, sZ2)
                    bPoint2 = True
                End If
                Return oPoint2
            End Get
        End Property

        Public ReadOnly Property Point1 As Point3D
            Get
                If Not bPoint1 Then
                    oPoint1 = New Point3D(sX1, sY1, sZ1)
                    bPoint1 = True
                End If
                Return oPoint1
            End Get
        End Property

        Public ReadOnly Property RotateZ As Single
            Get
                Return sRotateZ
            End Get
        End Property

        Public ReadOnly Property RotateY As Single
            Get
                Return sRotateY
            End Get
        End Property

        Public ReadOnly Property RotateX As Single
            Get
                Return sRotateX
            End Get
        End Property

        Public ReadOnly Property Scale As Single
            Get
                Return sScale
            End Get
        End Property

        Public ReadOnly Property Z2 As Single
            Get
                Return sZ2
            End Get
        End Property

        Public ReadOnly Property Y2 As Single
            Get
                Return sY2
            End Get
        End Property

        Public ReadOnly Property X2 As Single
            Get
                Return sX2
            End Get
        End Property

        Public ReadOnly Property Station2 As String
            Get
                Return sStation2
            End Get
        End Property

        Public ReadOnly Property Z1 As Single
            Get
                Return sZ1
            End Get
        End Property

        Public ReadOnly Property Y1 As Single
            Get
                Return sY1
            End Get
        End Property

        Public ReadOnly Property X1 As Single
            Get
                Return sX1
            End Get
        End Property

        Public ReadOnly Property Station1 As String
            Get
                Return sStation1
            End Get
        End Property

        Public Sub New(Scale As Single, RotateX As Single, RotateY As Single, RotateZ As Single, Station1 As String, X1 As Single, Y1 As Single, Z1 As Single, Station2 As String, X2 As Single, Y2 As Single, Z2 As Single)
            sStation1 = Station1
            sX1 = X1
            sY1 = Y1
            sZ1 = Z1
            sStation2 = Station2
            sX2 = X2
            sY2 = Y2
            sZ2 = Z2
            sScale = Scale
            sRotateX = RotateX
            sRotateY = RotateY
            sRotateZ = RotateZ
        End Sub
    End Class

    Public ReadOnly Property Result() As cModelEdit
        Get
            Dim oCube1 As CubeVisual3D = Viewport.FindName("cube_station1")
            Dim oCube1Bound As Rect3D = oCube1.FindBounds(oCube1.Transform)
            Dim oCube1Center As Point3D = New Point3D(oCube1Bound.X + oCube1Bound.SizeX / 2.0F, oCube1Bound.Y + oCube1Bound.SizeY / 2.0F, oCube1Bound.Z + oCube1Bound.SizeZ / 2.0F)
            Dim oCube2 As CubeVisual3D = Viewport.FindName("cube_station2")
            Dim oCube2Bound As Rect3D = oCube2.FindBounds(oCube2.Transform)
            Dim oCube2Center As Point3D = New Point3D(oCube2Bound.X + oCube2Bound.SizeX / 2.0F, oCube2Bound.Y + oCube2Bound.SizeY / 2.0F, oCube2Bound.Z + oCube2Bound.SizeZ / 2.0F)

            Return New cModelEdit(txtScale.EditValue, txtxrotate.EditValue, txtyrotate.EditValue, txtzrotate.EditValue, txtStation1.EditValue, oCube1Bound.X / 2.0, oCube1Bound.Y / 2.0, oCube1Bound.Z / 2.0, txtStation2.EditValue, oCube2Bound.X / 2.0, oCube2Bound.Y / 2.0, oCube2Bound.Z / 2.0)
        End Get
    End Property

    Private Sub txtstation1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtStation1.ButtonClick
        Using frmTB As frmTrigpointBrowser = New frmTrigpointBrowser(oSurvey, txtStation1.EditValue, False)
            If frmTB.ShowDialog(Me) = vbOK Then
                txtStation1.EditValue = frmTB.SelectedItem
            End If
        End Using
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Dim sStation1 As String = "" & txtStation1.EditValue
        Dim sStation2 As String = "" & txtStation2.EditValue
        If sStation1 <> "" And sStation2 <> "" AndAlso sStation1 <> sStation2 Then
            DialogResult = DialogResult.OK
        Else
            DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub txtStation2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtStation2.ButtonClick
        Using frmTB As frmTrigpointBrowser = New frmTrigpointBrowser(oSurvey, txtStation2.EditValue, False)
            If frmTB.ShowDialog(Me) = vbOK Then
                txtStation2.EditValue = frmTB.SelectedItem
            End If
        End Using
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim oTrasformation As Transform3DGroup = New Transform3DGroup()
        Call oTrasformation.Children.Add(New ScaleTransform3D(txtScale.EditValue, txtScale.EditValue, txtScale.EditValue))

        Dim oCube1 As CubeVisual3D = Viewport.FindName("cube_station1")
        Dim oCube1Bound As Rect3D = oCube1.FindBounds(oCube1.Transform)
        Dim oCube1Center As Point3D = New Point3D(oCube1Bound.X + oCube1Bound.SizeX / 2.0F, oCube1Bound.Y + oCube1Bound.SizeY / 2.0F, oCube1Bound.Z + oCube1Bound.SizeZ / 2.0F)
        'oCube1Center = oTrasformation.Transform(oCube1Center)

        Dim oGroup As ModelVisual3D = Viewport.Children(Viewport.Children.Count - 1)
        Dim oGroupTransform As Transform3DGroup = oGroup.Transform
        oGroupTransform.Children.RemoveAt(4)
        If My.Computer.Keyboard.ShiftKeyDown Then
            oGroupTransform.Children.Add(New TranslateTransform3D(0, 0, 0))
        Else
            oGroupTransform.Children.Add(New TranslateTransform3D(-oCube1Center.X / 2.0, -oCube1Center.Y / 2.0, -oCube1Center.Z / 2.0))
        End If
    End Sub

    Private Sub txt1_EditValueChanged(sender As Object, e As EventArgs) Handles txt1.EditValueChanged
        If Not bdisableEvent Then
            Dim sValues As String() = txt1.EditValue.ToString.Split(";"c)
            Dim sX As Decimal = modNumbers.StringToDecimal(sValues(0))
            Dim sy As Decimal = modNumbers.StringToDecimal(sValues(1))
            Dim sz As Decimal = modNumbers.StringToDecimal(sValues(2))
            Dim oCube1Manupulator As CombinedManipulator = Viewport.FindName("cube_station1_manipulator")
            oCube1Manupulator.UnBind()
            Dim oCube1 As CubeVisual3D = Viewport.FindName("cube_station1")
            oCube1.Transform = New TranslateTransform3D(sX, sy, sz)
            oCube1Manupulator.Bind(oCube1)
        End If
    End Sub

    Private Sub txt2_EditValueChanged(sender As Object, e As EventArgs) Handles txt2.EditValueChanged
        If Not bdisableEvent Then
            Dim sValues As String() = txt2.EditValue.ToString.Split(";"c)
            Dim sX As Decimal = modNumbers.StringToDecimal(sValues(0))
            Dim sy As Decimal = modNumbers.StringToDecimal(sValues(1))
            Dim sz As Decimal = modNumbers.StringToDecimal(sValues(2))
            Dim oCube2Manupulator As CombinedManipulator = Viewport.FindName("cube_station2_manipulator")
            oCube2Manupulator.UnBind()
            Dim oCube2 As CubeVisual3D = Viewport.FindName("cube_station2")
            oCube2.Transform = New TranslateTransform3D(sX, sy, sz)
            oCube2Manupulator.Bind(oCube2)
        End If
    End Sub

    Private Sub btnLoadPreset_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnLoadPreset.ItemClick
        Dim oOFD As OpenFileDialog = New OpenFileDialog
        With oOFD
            .Title = GetLocalizedString("3ditemedit.loadpresetdialog")
            .Filter = GetLocalizedString("3ditemedit.filetype3DChunckPreset") & " (*.3DChunckx)|*.3DChunckx"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Call pPresetLoad(.FileName)
            End If
        End With
    End Sub

    Private Sub pPresetLoad(Filename As String)
        Dim oXML As XmlDocument = New XmlDocument
        oXML.Load(Filename)
        Dim oXMLRoot As XmlElement = oXML.DocumentElement
        txtScale.EditValue = modNumbers.StringToDecimal(oXMLRoot.GetAttribute("sc"))
        txtxrotate.EditValue = modNumbers.StringToDecimal(oXMLRoot.GetAttribute("xr"))
        txtyrotate.EditValue = modNumbers.StringToDecimal(oXMLRoot.GetAttribute("yr"))
        txtzrotate.EditValue = modNumbers.StringToDecimal(oXMLRoot.GetAttribute("zr"))
        Dim oXMLStation1 As XmlElement = oXMLRoot.Item("station1")
        txtStation1.EditValue = oXMLStation1.GetAttribute("s")
        txt1.EditValue = oXMLStation1.GetAttribute("l")
        Dim oXMLStation2 As XmlElement = oXMLRoot.Item("station2")
        txtStation2.EditValue = oXMLStation2.GetAttribute("s")
        txt2.EditValue = oXMLStation2.GetAttribute("l")

        Call pUpdateTransform()
        Call pUpdatePositions()
    End Sub

    Private Sub btnSavePreset_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSavePreset.ItemClick
        Dim oOFD As SaveFileDialog = New SaveFileDialog
        With oOFD
            .Title = GetLocalizedString("3ditemedit.savepresetdialog")
            .Filter = GetLocalizedString("3ditemedit.filetype3DChunckPreset") & " (*.3DChunckx)|*.3DChunckx"
            .FilterIndex = 1
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim oXML As XmlDocument = New XmlDocument
                Dim oXMLRoot As XmlElement = oXML.CreateElement("preset3d")
                Call oXMLRoot.SetAttribute("sc", modNumbers.NumberToString(txtScale.EditValue))
                Call oXMLRoot.SetAttribute("xr", modNumbers.NumberToString(txtxrotate.EditValue))
                Call oXMLRoot.SetAttribute("yr", modNumbers.NumberToString(txtyrotate.EditValue))
                Call oXMLRoot.SetAttribute("zr", modNumbers.NumberToString(txtzrotate.EditValue))
                Dim oXMLStation1 As XmlElement = oXML.CreateElement("station1")
                oXMLStation1.SetAttribute("s", txtStation1.EditValue)
                oXMLStation1.SetAttribute("l", txt1.EditValue)
                oXMLRoot.AppendChild(oXMLStation1)
                Dim oXMLStation2 As XmlElement = oXML.CreateElement("station2")
                oXMLStation2.SetAttribute("s", txtStation2.EditValue)
                oXMLStation2.SetAttribute("l", txt2.EditValue)
                oXMLRoot.AppendChild(oXMLStation2)
                oXML.AppendChild(oXMLRoot)
                oXML.Save(.FileName)
            End If
        End With
    End Sub
End Class