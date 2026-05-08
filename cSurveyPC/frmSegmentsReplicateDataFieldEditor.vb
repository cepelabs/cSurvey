Imports System.ComponentModel
Imports System.Threading
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Scale
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraLayout

Friend Class frmSegmentsReplicateDataFieldEditor

    Private iMode As Integer
    Private oItems As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)

    Public Shared Function GetValues(Items As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)) As Dictionary(Of String, Object)
        Dim oItems As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
        For Each oItem As UIHelpers.Reflection.cObjectPropertyBag In Items
            If oItem.Set Then
                oItems.Add(oItem.Name, oItem.Value)
            End If
        Next
        Return oItems
    End Function

    Public Shared Function GetItems(Mode As Integer, Values As Dictionary(Of String, Object)) As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)
        Dim oTmpItems As List(Of UIHelpers.Reflection.cObjectPropertyBag) = New List(Of UIHelpers.Reflection.cObjectPropertyBag)
        For Each oProperty As Reflection.PropertyInfo In GetType(cSegment).GetProperties()
            If oProperty.CustomAttributes.Count > 0 Then
                Dim oAttribute As Reflection.CustomAttributeData = oProperty.CustomAttributes.FirstOrDefault(Function(oCustomAttribute) oCustomAttribute.AttributeType.Name = "cReplicateDataAttribute")
                If oAttribute IsNot Nothing Then
                    oTmpItems.Add(New UIHelpers.Reflection.cObjectPropertyBag(oProperty, oAttribute.ConstructorArguments(1).Value))
                    If Values IsNot Nothing AndAlso Values.ContainsKey(oProperty.Name) Then
                        Select Case Mode
                            Case 0
                                oTmpItems.Last.Set = True
                                oTmpItems.Last.Value = Values(oProperty.Name)
                            Case 1
                                oTmpItems.Last.Set = Values(oProperty.Name)
                        End Select
                    End If
                End If
            End If
        Next
        Return New BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)(oTmpItems.OrderBy(Function(oItem) oItem.SetOrder).ToList)
    End Function

    Public Sub New(Mode As Integer, Optional Items As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag) = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        iMode = Mode
        Select Case imode
            Case 0  'replicate data 
            Case 1  'only check
                colPropertyValue.Visible = False
        End Select


        If Items Is Nothing Then
            oItems = GetItems(iMode, New Dictionary(Of String, Object))
        Else
            oItems = Items
        End If

        grdVisibility.DataSource = oItems

        Call pValidateOk()
    End Sub

    Public ReadOnly Property Items As BindingList(Of UIHelpers.Reflection.cObjectPropertyBag)
        Get
            Return oItems
        End Get
    End Property

    Private Sub grdPropertiesView_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles grdPropertiesView.CustomRowCellEdit
        If e.Column Is colPropertyValue Then
            Dim oItem As UIHelpers.Reflection.cObjectPropertyBag = grdPropertiesView.GetRow(e.RowHandle)
            If oItem.Property.PropertyType.Name.ToLower = "boolean" Then
                e.RepositoryItem = chkBooleanPropertySet
            ElseIf oItem.Property.PropertyType.Name.ToLower = "string" Then
                e.RepositoryItem = txtTextPropertySet
                'TODO: for numeric value change float settings from original type
            ElseIf oItem.Property.PropertyType.Name.ToLower = "integer" Then
                e.RepositoryItem = txtNumericPropertySet
            ElseIf oItem.Property.PropertyType.Name.ToLower = "long" Then
                e.RepositoryItem = txtNumericPropertySet
            ElseIf oItem.Property.PropertyType.Name.ToLower = "decimal" Then
                e.RepositoryItem = txtNumericPropertySet
            ElseIf oItem.Property.PropertyType.Name.ToLower = "single" Then
                e.RepositoryItem = txtNumericPropertySet
            ElseIf oItem.Property.PropertyType.Name.ToLower = "double" Then
                e.RepositoryItem = txtNumericPropertySet
                'TODO: enum
            End If
        End If
    End Sub

    Private Sub grdPropertiesView_HiddenEditor(sender As Object, e As EventArgs) Handles grdPropertiesView.HiddenEditor
    End Sub

    Private Sub pValidateOk()
        If oItems.Where(Function(oitem) oitem.Set).Count > 0 Then
            If iMode = 0 Then
                If oItems.Where(Function(oitem) oitem.Set AndAlso oitem.Value Is Nothing).Count = 0 Then
                    cmdOk.Enabled = True
                Else
                    cmdOk.Enabled = False
                End If
            Else
                cmdOk.Enabled = True
            End If
        Else
            cmdOk.Enabled = False
        End If
    End Sub

    Private Sub chkBooleanPropertySet_EditValueChanged(sender As Object, e As EventArgs) Handles chkBooleanPropertySet.EditValueChanged
        Call grdPropertiesView.PostEditor()
        Call pValidateOk()
    End Sub

End Class