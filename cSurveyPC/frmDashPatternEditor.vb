Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items
Imports DevExpress.XtraBars
Imports DevExpress.XtraGauges.Core.Resources
Imports DevExpress.XtraGrid.Views.Base

Friend Class frmDashPatternEditor
    Public Shadows ReadOnly Property Item As cItem
        Get
            Return MyBase.Item
        End Get
    End Property

    Public Enum PenDashContextEnum
        MainPen = 0
        ClipartPen = 1
        DirectValue = 99
    End Enum

    Private iPenDashContext As PenDashContextEnum

    Public Delegate Sub ValueSetDelegate(Values() As Single)
    Private oValueSet As ValueSetDelegate

    Public Shadows Sub Rebind(Values As Single(), ValueSet As ValueSetDelegate)
        Call MyBase.Rebind(Item)

        iPenDashContext = PenDashContextEnum.DirectValue
        grdBlocks.DataSource = New UIHelpers.cDashPatternBindingList(Values)
        oValueSet = ValueSet
    End Sub

    Public Shadows Sub Rebind(Item As cItem, PenDashContext As PenDashContextEnum)
        Call MyBase.Rebind(Item)

        iPenDashContext = PenDashContext
        Select Case iPenDashContext
            Case PenDashContextEnum.MainPen
                grdBlocks.DataSource = New UIHelpers.cDashPatternBindingList(Item.Pen.StylePattern)
            Case PenDashContextEnum.ClipartPen
                grdBlocks.DataSource = New UIHelpers.cDashPatternBindingList(Item.Pen.ClipartStylePattern)
            Case PenDashContextEnum.DirectValue
                Throw New Exception("Context not valid")
        End Select
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Call DirectCast(grdBlocks.DataSource, UIHelpers.cDashPatternBindingList).Add()
        Call pApplyChanges
    End Sub

    Private Sub pApplyChanges()
        Select Case iPenDashContext
            Case PenDashContextEnum.MainPen
                MyBase.Item.Pen.StylePattern = DirectCast(grdBlocks.DataSource, UIHelpers.cDashPatternBindingList).GetValues
            Case PenDashContextEnum.ClipartPen
                MyBase.Item.Pen.ClipartStylePattern = DirectCast(grdBlocks.DataSource, UIHelpers.cDashPatternBindingList).GetValues
            Case PenDashContextEnum.DirectValue
                Call oValueSet(DirectCast(grdBlocks.DataSource, UIHelpers.cDashPatternBindingList).GetValues)
        End Select
        Call MyBase.MapInvalidate()
    End Sub

    Private Sub btnRemove_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnRemove.ItemClick
        Dim oItem As UIHelpers.cDashPatternBlock = grdViewBlocks.GetFocusedRow
        If oItem IsNot Nothing Then
            Call DirectCast(grdBlocks.DataSource, UIHelpers.cDashPatternBindingList).Remove(oItem)
            Call pApplyChanges()
        End If
    End Sub

    Private Sub grdViewBlocks_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles grdViewBlocks.FocusedRowChanged
        btnRemove.Enabled = grdViewBlocks.GetFocusedRow IsNot Nothing
    End Sub

    Private Sub grdViewBlocks_ValidateRow(sender As Object, e As ValidateRowEventArgs) Handles grdViewBlocks.ValidateRow
        Call pApplyChanges()
    End Sub
End Class