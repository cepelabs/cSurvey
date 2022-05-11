Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design

Friend Class cDockText
    Private bLoaded As Boolean

    Private oBag As Object

    Private sPath As String
    Private sName As String

    Public Class OnItemEventArgs
        Inherits EventArgs

        Private oBag As Object
        Private iType As cItemFont.FontTypeEnum
        Private sText As String
        Private iSize As Items.cIItemSizable.SizeEnum

        Public ReadOnly Property Bag As Object
            Get
                Return oBag
            End Get
        End Property

        Public ReadOnly Property Type As cItemFont.FontTypeEnum
            Get
                Return iType
            End Get
        End Property

        Public ReadOnly Property Text As String
            Get
                Return sText
            End Get
        End Property

        Public ReadOnly Property Size As Items.cIItemSizable.SizeEnum
            Get
                Return iSize
            End Get
        End Property

        Friend Sub New(ByVal Bag As Object, ByVal Text As String, ByVal Type As cItemFont.FontTypeEnum, ByVal Size As Items.cIItemSizable.SizeEnum)
            oBag = Bag
            sText = Text
            iType = Type
            iSize = Size
        End Sub
    End Class

    Friend Event OnItemCreate(ByVal Sender As Object, ByVal e As OnItemEventArgs)

    Private oDragItem As OnItemEventArgs
    Private oDragboxFromMouseDown As Rectangle
    Private oDragScreenOffset As Point

    Public Sub AddText(ByVal Bag As Object)
        oBag = Bag
    End Sub

    Private Sub txtText_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtText.DoubleClick
        Call pItemCreate()
    End Sub

    Private Sub txtText_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtText.MouseDown
        If Not My.Computer.Keyboard.CtrlKeyDown Then
            Try
                Dim sText As String = txtText.Text
                If sText <> "" Then
                    oDragItem = New OnItemEventArgs(oBag, sText, cboPropTextStyle.SelectedItem.type, cboPropTextSize.SelectedIndex)
                    Dim oDragSize As Size = SystemInformation.DragSize
                    oDragboxFromMouseDown = New Rectangle(New Point(e.X - (oDragSize.Width / 2), e.Y - (oDragSize.Height / 2)), oDragSize)
                Else
                    oDragboxFromMouseDown = Rectangle.Empty
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub txtText_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtText.MouseMove
        If Not My.Computer.Keyboard.CtrlKeyDown Then
            If ((e.Button And MouseButtons.Left) = MouseButtons.Left) Then
                If (Rectangle.op_Inequality(oDragboxFromMouseDown, Rectangle.Empty) And Not oDragboxFromMouseDown.Contains(e.X, e.Y)) Then
                    oDragScreenOffset = SystemInformation.WorkingArea.Location
                    Dim oDropEffect As DragDropEffects = txtText.DoDragDrop(oDragItem, DragDropEffects.Copy)
                End If
            End If
        End If
    End Sub

    Private Sub txtText_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtText.MouseUp
        oDragboxFromMouseDown = Rectangle.Empty
    End Sub

    Private Sub pItemCreate()
        Try
            Dim sText As String = txtText.Text
            Dim iType As cItemFont.FontTypeEnum = cboPropTextStyle.SelectedItem.type
            Dim iSize As Items.cIItemSizable.SizeEnum = cboPropTextSize.SelectedIndex
            RaiseEvent OnItemCreate(Me, New OnItemEventArgs(oBag, sText, iType, iSize))
        Catch
        End Try
    End Sub

    Public Sub SetSurvey(ByVal Survey As cSurveyPC.cSurvey.cSurvey)
        Call cboPropTextStyle.Items.Clear()
        Call cboPropTextStyle.Items.Add(Survey.EditPaintObjects.GenericFonts.Generic)
        Call cboPropTextStyle.Items.Add(Survey.EditPaintObjects.GenericFonts.Title)
        Call cboPropTextStyle.Items.Add(Survey.EditPaintObjects.GenericFonts.CaveName)
        Call cboPropTextStyle.Items.Add(Survey.EditPaintObjects.GenericFonts.CaveComplexName)
        Call cboPropTextStyle.Items.Add(Survey.EditPaintObjects.GenericFonts.TrigPoint)
        Call cboPropTextStyle.Items.Add(Survey.EditPaintObjects.GenericFonts.Note)

        cboPropTextStyle.SelectedIndex = 0
        cboPropTextSize.SelectedIndex = 0
    End Sub

    Private Sub cboPropTextStyle_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboPropTextStyle.DrawItem
        Try
            Dim oGr As Graphics = e.Graphics
            oGr.CompositingQuality = CompositingQuality.HighQuality
            oGr.InterpolationMode = InterpolationMode.HighQualityBicubic
            oGr.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
            Dim bSelected As Boolean = (e.State And DrawItemState.Selected) = DrawItemState.Selected
            If bSelected Then
                Call oGr.FillRectangle(SystemBrushes.Highlight, e.Bounds)
            Else
                Call oGr.FillRectangle(SystemBrushes.Window, e.Bounds)
            End If
            Dim oFont As cItemFont = cboPropTextStyle.Items(e.Index)
            Using oSampleFont As Font = oFont.GetSampleFont
                Dim oLabelRect As RectangleF = New RectangleF(e.Bounds.Left + 2, e.Bounds.Top, e.Bounds.Right - 2, e.Bounds.Height)
                Using oSF As StringFormat = New StringFormat
                    oSF.LineAlignment = StringAlignment.Center
                    oSF.Trimming = StringTrimming.EllipsisCharacter
                    oSF.FormatFlags = StringFormatFlags.NoWrap
                    If bSelected Then
                        Call oGr.DrawString(oFont.Name, oSampleFont, SystemBrushes.HighlightText, oLabelRect, oSF)
                    Else
                        Call oGr.DrawString(oFont.Name, oSampleFont, SystemBrushes.WindowText, oLabelRect, oSF)
                    End If
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub btnTextFromClipboard_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTextFromClipboard.ItemClick
        Try
            txtText.Text = Clipboard.GetText
        Catch
        End Try
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Call pItemCreate()
    End Sub
End Class