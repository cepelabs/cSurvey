Imports cSurveyPC.cSurvey

Public Class cCaveInfoCombobox
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
                Call Rebind(False)
            End If
        End Set
    End Property

    Private oItems As List(Of cICaveInfoBranches)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent()
        MyBase.DrawMode = DrawMode.OwnerDrawFixed
        MyBase.DropDownStyle =ComboBoxStyle.DropDownList 
        oItems = New List(Of cICaveInfoBranches)
    End Sub

    Public ReadOnly Property CaveItems As List(Of cICaveInfoBranches)
        Get
            Return oItems
        End Get
    End Property

    Public Enum AllowLockedEnum
        [Default] = 0
        [True] =1
        [False]=2
    End Enum

    Public Overridable Sub Rebind(Caveinfos As cSurvey.cCaveInfos, Reset As Boolean, Optional AllowEmpty As Boolean = True, Optional AllowLocked As AllowLockedEnum = AllowLockedEnum.True)
        Dim oEmptyCaveInfo As cCaveInfo = Caveinfos.GetEmptyCaveInfo
        Call oItems.Clear()
        If AllowEmpty Then Call oItems.Add(oEmptyCaveInfo)
        For Each oCaveInfo As cCaveInfo In Caveinfos
            If oCaveInfo.GetLocked Then
                If AllowLocked = AllowLockedEnum.True Then
                    Call oItems.Add(oCaveInfo)
                ElseIf AllowLocked = AllowLockedEnum.Default Then
                    If iWorkmode = WorkmodeEnum.View Then
                        Call oItems.Add(oCaveInfo)
                    End If
                End If
            Else
                Call oItems.Add(oCaveInfo)
            End If
        Next
        Call Rebind(Reset)
    End Sub

    Public Sub Rebind(Reset As Boolean)
        Dim oCurrentItem As cICaveInfoBranches = Nothing
        If Not Reset Then oCurrentItem = MyBase.SelectedItem
        Call MyBase.Items.Clear()
        For Each oItem As cICaveInfoBranches In oItems
            'If Not oItem.Locked OrElse (oItem.Locked AndAlso iWorkmode = WorkmodeEnum.View) Then
            Call MyBase.Items.Add(oItem)
            'End If
        Next
        If Not IsNothing(oCurrentItem) AndAlso MyBase.Items.Contains(oCurrentItem) Then
            MyBase.SelectedItem = oCurrentItem
        Else
            If MyBase.Items.Count > 0 Then
                MyBase.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cCaveInfoCombobox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles Me.DrawItem
        Try
            If e.Index >= 0 Then
                Dim bEnabled As Boolean = MyBase.Enabled
                Dim oGr As Graphics = e.Graphics
                'oGr.SmoothingMode = SmoothingMode.AntiAlias
                'oGr.CompositingQuality = CompositingQuality.HighQuality
                'oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
                'oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

                Dim oCaveInfo As cICaveInfoBranches = MyBase.Items(e.Index)
                Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
                Dim oRect As Rectangle = e.Bounds

                Call e.DrawBackground()

                Dim iHeight As Integer = oRect.Height / 2
                Dim oColorRect As Rectangle = New Rectangle(oRect.X + 2, oRect.Y + 2, iHeight - 4, oRect.Height - 4)
                If e.Index > 0 Then
                    Dim oColor As Color = oCaveInfo.GetColor(Color.LightGray)
                    If Not bEnabled Then
                        oColor = modPaint.LightColor(oColor, 0.5)
                    End If
                    Using oBrush As SolidBrush = New SolidBrush(oColor)
                        Call oGr.FillRectangle(oBrush, oColorRect)
                    End Using
                End If

                oRect.X = oRect.X + iHeight + 4

                Using oSF As StringFormat = New StringFormat
                    oSF.LineAlignment = StringAlignment.Center
                    oSF.Trimming = StringTrimming.EllipsisCharacter
                    If Not oCaveInfo.GetLocked AndAlso bEnabled Then
                        If bSelected Then
                            Call oGr.DrawString(oCaveInfo.ToString, MyBase.Font, SystemBrushes.HighlightText, oRect, oSF)
                        Else
                            Call oGr.DrawString(oCaveInfo.ToString, MyBase.Font, SystemBrushes.WindowText, oRect, oSF)
                        End If
                    Else
                        Call oGr.DrawString(oCaveInfo.ToString, MyBase.Font, SystemBrushes.GrayText, oRect, oSF)
                    End If
                End Using

                If Focused Then
                    Call e.DrawFocusRectangle()
                End If
            End If
        Catch
        End Try
    End Sub
End Class
