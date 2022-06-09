Imports cSurveyPC.cSurvey.Design
Imports DevExpress.XtraGrid.Views.Base

Public Class cCrossSectionDropDown
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
        MyBase.Enabled = False
    End Sub

    Public Enum WorkmodeEnum
        View = 0    'show and allow selection of locked item
        Edit = 1    'hide locked item
    End Enum

    Private iWorkmode As WorkmodeEnum

    Public Property Workmode As WorkmodeEnum
        Get
            Return iWorkmode
        End Get
        Set(value As WorkmodeEnum)
            If value <> iWorkmode Then
                iWorkmode = value
                'Call Rebind(osurvey, False)
            End If
        End Set
    End Property

    Public Enum AllowLockedEnum
        [Default] = 0
        [True] = 1
        [False] = 2
    End Enum

    Private bAllowEmpty As Boolean

    Public Function Rebind(Survey As cSurvey.cSurvey, Design As cDesign, Cave As String, Branch As String, Reset As Boolean, Optional AllowEmpty As Boolean = True, Optional AllowLocked As AllowLockedEnum = AllowLockedEnum.True) As Boolean
        bAllowEmpty = AllowEmpty
        Dim oCurrentCrossSection As cDesignCrossSection = cboBindCrossSections.SelectedItem
        Call cboBindCrossSections.Properties.Items.Clear()

        If bAllowEmpty Then
            Call cboBindCrossSections.Properties.Items.Add(Survey.CrossSections.GetEmptyCrossSection)
        End If
        If Not IsNothing(Design) AndAlso Design.Type <= cIDesign.cDesignTypeEnum.Profile Then
            For Each oCrossSection As cDesignCrossSection In Survey.CrossSections.GetAllItems(Design.Type)
                If Cave = "" OrElse (oCrossSection.Cave = Cave AndAlso (Branch = "" OrElse oCrossSection.Branch = Branch)) Then
                    Call cboBindCrossSections.Properties.Items.Add(oCrossSection)
                End If
            Next
        End If
        If cboBindCrossSections.Properties.Items.Count > 0 Then
            Try
                If oCurrentCrossSection Is Nothing Then
                    cboBindCrossSections.SelectedIndex = 0
                Else
                    cboBindCrossSections.SelectedItem = oCurrentCrossSection
                End If
            Catch
                cboBindCrossSections.SelectedIndex = 0
            End Try
            cboBindCrossSections.Enabled = True
        Else
            cboBindCrossSections.Enabled = False
        End If

        Return cboBindCrossSections.Enabled
    End Function

    Public Property EditValue As cDesignCrossSection
        Get
            Return cboBindCrossSections.EditValue
        End Get
        Set(value As cDesignCrossSection)
            If bAllowEmpty Then
                If value Is Nothing Then
                    cboBindCrossSections.EditValue = cboBindCrossSections.Properties.Items(0)
                Else
                    cboBindCrossSections.EditValue = value
                End If
            Else
                If value IsNot Nothing Then
                    cboBindCrossSections.EditValue = value
                End If
            End If
        End Set
    End Property

    Public Function SetSelected(CrossSection As cDesignCrossSection) As Boolean
        EditValue = CrossSection
        Return True
    End Function

    Public Function GetSelected() As cDesignCrossSection
        Return EditValue
    End Function

    Public ReadOnly Property Count() As Integer
        Get
            Return cboBindCrossSections.Properties.Items.Count
        End Get
    End Property

    Private Sub cCaveDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboBindCrossSections.Height Then
            MyBase.Height = cboBindCrossSections.Height
        End If
    End Sub

    Public Event CustomRowFilter As RowFilterEventHandler

    Private Sub cboBindCrossSections_CustomRowFilter(sender As Object, e As RowFilterEventArgs)
        RaiseEvent CustomRowFilter(Me, e)
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboBindCrossSections_EditValueChanged(sender As Object, e As EventArgs) Handles cboBindCrossSections.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub
End Class
