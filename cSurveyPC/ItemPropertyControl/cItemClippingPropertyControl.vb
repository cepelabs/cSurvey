Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Friend Class cItemClippingPropertyControl
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() 
        For Each iClippingType As cItem.cItemClippingTypeEnum In [Enum].GetValues(GetType(cItem.cItemClippingTypeEnum))
            Dim iValue As Integer = iClippingType.ToString("D")
            DirectCast(Controls.Item("chkClippingType" & iValue), DevExpress.XtraEditors.CheckButton).ToolTip = modMain.GetLocalizedString("csurvey.clippingtypeenum." & iValue)
        Next
    End Sub

    Public Shadows Sub Rebind(Item As cItem)
        MyBase.Rebind(Item)

        DirectCast(Controls.Item("chkClippingType" & Item.ClippingType.ToString("D")), DevExpress.XtraEditors.CheckButton).Checked = True
    End Sub

    Private Sub pSetClippingType(Type As cItem.cItemClippingTypeEnum)
        If Not DisabledObjectProperty() Then
            Call MyBase.CreateUndoSnapshot("Clipping change", "ClippingType")
            Item.ClippingType = Type
            Call MyBase.PropertyChanged("ClippingType")
            Call MyBase.MapInvalidate()
        End If
    End Sub

    Private Sub chkClippingType0_CheckedChanged(sender As Object, e As EventArgs) Handles chkClippingType0.CheckedChanged
        Call pSetClippingType(cItem.cItemClippingTypeEnum.Default)
    End Sub

    Private Sub chkClippingType1_CheckedChanged(sender As Object, e As EventArgs) Handles chkClippingType1.CheckedChanged
        Call pSetClippingType(cItem.cItemClippingTypeEnum.None)
    End Sub

    Private Sub chkClippingType2_CheckedChanged(sender As Object, e As EventArgs) Handles chkClippingType2.CheckedChanged
        Call pSetClippingType(cItem.cItemClippingTypeEnum.InsideBorder)
    End Sub

    Private Sub chkClippingType3_CheckedChanged(sender As Object, e As EventArgs) Handles chkClippingType3.CheckedChanged
        Call pSetClippingType(cItem.cItemClippingTypeEnum.OutsideBorder)
    End Sub
End Class
