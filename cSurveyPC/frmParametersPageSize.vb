Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Properties
Imports DevExpress.XtraEditors.Controls

Friend Class frmParametersPageSize
    Private oOptions As cSurvey.Design.cOptionsExport
    Private oSurvey As cSurvey.cSurvey

    Private bDisabledEvent As Boolean

    Public Sub New(ByVal Options As cSurvey.Design.cOptionsExport)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oOptions = Options
        oSurvey = oOptions.Survey

        bDisabledEvent = True

        Dim oSize As SizeF = New SizeF(Options.ImageWidth, Options.ImageHeight)

        Dim oXml As XmlDocument = New XmlDocument
        Call oXml.Load(IO.Path.Combine(modMain.GetApplicationPath, "papersizes.xml"))
        For Each oXMLSize As XmlElement In oXml.DocumentElement.ChildNodes
            Dim sName As String = oXMLSize.GetAttribute("name")
            Dim oItemSize As SizeF = New SizeF(modNumbers.StringToDecimal(oXMLSize.GetAttribute("w")), modNumbers.StringToDecimal(oXMLSize.GetAttribute("h")))
            Dim oItem As ImageComboBoxItem = New ImageComboBoxItem({oItemSize, oXMLSize.GetAttribute("u")}, 0)
            oItem.Description = sName
            cboSize.Properties.Items.Add(oItem)
            If oItemSize = oSize Then
                cboSize.SelectedItem = oItem
                chkOrientationPortrait.Checked = True
            ElseIf oItemSize.Width = oSize.Height AndAlso oItemSize.Height = oSize.Width Then
                cboSize.SelectedItem = oItem
                chkOrientationLandscape.Checked = True
            End If
        Next
        If cboSize.SelectedItem Is Nothing Then
            cboSize.SelectedItem = cboSize.Properties.Items(0)
        End If

        bDisabledEvent = False
    End Sub

    Private Sub pSave()
        Dim oItem As ImageComboBoxItem = cboSize.SelectedItem
        Dim sW As Single = oItem.Value(0).width
        Dim sH As Single = oItem.Value(0).height
        If chkOrientationLandscape.Checked Then
            Dim sT As Single = sW
            sW = sH
            sH = sT
        End If
        oOptions.ImageWidth = sW
        oOptions.ImageHeight = sH
        oOptions.ImageUnit = oItem.Value(1)
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Call pSave()
        Call Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub
End Class