Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Design

Public Class cFontStyleDropDown
    Private oPaintOptions As cOptions

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    Public Sub Rebind(PaintOptions As cOptions)
        oPaintOptions = PaintOptions

        Dim oFonts As List(Of cItemFont) = New List(Of cItemFont)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.Generic)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.Title)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.CaveName)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.CaveComplexName)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.TrigPoint)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.Note)
        Call oFonts.Add(oPaintOptions.Survey.EditPaintObjects.GenericFonts.FromCustom("", 0, Color.Black, False, False, False))
        cboFontStyle.Properties.DataSource = oFonts
    End Sub

    Public Property EditValue As cItemFont.FontTypeEnum
        Get
            If cboFontStyle.EditValue Is Nothing Then
                Return cItemFont.FontTypeEnum.Generic
            Else
                Return DirectCast(cboFontStyle.EditValue, cItemFont).Type
            End If
        End Get
        Set(value As cItemFont.FontTypeEnum)
            If cboFontStyle.Properties.DataSource IsNot Nothing Then
                For Each oFont As cItemFont In cboFontStyle.Properties.DataSource
                    If oFont.Type = value Then
                        cboFontStyle.EditValue = oFont
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

    Private Sub cboFontStyleView_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles cboFontStyleView.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = DirectCast(e.Row, cItemFont).ToHTMLString(oPaintOptions)
        End If
    End Sub

    Private Sub cboFontStyle_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles cboFontStyle.CustomDisplayText
        If e.Value Is Nothing Then
            e.DisplayText = ""
        Else
            e.DisplayText = DirectCast(e.Value, cItemFont).ToHTMLString(oPaintOptions)
        End If
    End Sub

    Private Sub cFontStyleDropDown_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If MyBase.Height <> cboFontStyle.Height Then
            MyBase.Height = cboFontStyle.Height
        End If
    End Sub

    Public Event EditValueChanged As EventHandler

    Private Sub cboFontStyle_EditValueChanged(sender As Object, e As EventArgs) Handles cboFontStyle.EditValueChanged
        RaiseEvent EditValueChanged(Me, e)
    End Sub
End Class
