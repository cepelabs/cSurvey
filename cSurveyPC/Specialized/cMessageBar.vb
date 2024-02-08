Public Class cMessageBar
    Public Enum ButtonStyleEnum
        Close = 0
        Custom = 1
    End Enum

    Private bAllowMessageClick As Boolean
    Private iButtonStyle As ButtonStyleEnum
    Private bAllowClose As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    Public ReadOnly Property CustomButtonImageOptions As DevExpress.XtraEditors.SimpleButtonImageOptions
        Get
            Return btnPopupCustom.ImageOptions
        End Get
    End Property

    Public Property CustomButtonTooltip As String
        Get
            Return btnPopupCustom.ToolTipTitle
        End Get
        Set(value As String)
            If btnPopupCustom.ToolTipTitle <> value Then
                btnPopupCustom.ToolTipTitle = value
            End If
        End Set
    End Property

    Public Property CustomButtonCaption As String
        Get
            Return btnPopupCustom.Text
        End Get
        Set(value As String)
            If btnPopupCustom.Text <> value Then
                btnPopupCustom.Text = value
            End If
        End Set
    End Property

    Public Property ButtonStyle As ButtonStyleEnum
        Get
            Return iButtonStyle
        End Get
        Set(value As ButtonStyleEnum)
            If iButtonStyle <> value Then
                iButtonStyle = value
                Select Case iButtonStyle
                    Case ButtonStyleEnum.Close
                        btnPopupClose.Visible = True
                        btnPopupCustom.Visible = False
                    Case ButtonStyleEnum.Custom
                        btnPopupClose.Visible = False
                        btnPopupCustom.Visible = True
                End Select
            End If
        End Set
    End Property

    Public Property AllowClose() As Boolean
        Get
            Return bAllowClose
        End Get
        Set(value As Boolean)
            If bAllowClose <> value Then
                bAllowClose = value
                btnPopupClose.Visible = bAllowClose
            End If
        End Set
    End Property

    Public Property AllowMessageClick() As Boolean
        Get
            Return bAllowMessageClick
        End Get
        Set(value As Boolean)
            If bAllowMessageClick <> value Then
                bAllowMessageClick = value
                If bAllowMessageClick Then
                    lblPopupWarning.Cursor = Cursors.Hand
                    picPopupWarning.Cursor = Cursors.Hand
                Else
                    lblPopupWarning.Cursor = Cursors.Default
                    picPopupWarning.Cursor = Cursors.Default
                End If
            End If
        End Set
    End Property

    Public Sub PopupHide()
        Me.Visible = False
    End Sub

    Public Property CaptionForecolor As Color
        Get
            Return lblPopupWarning.ForeColor
        End Get
        Set(value As Color)
            lblPopupWarning.ForeColor = value
        End Set
    End Property

    Public Sub PopupShow(ByVal Type As String, ByVal Text As String, Optional Details As String = "")
        Dim bShow As Boolean
        Select Case Type.ToLower
            Case "warping"
                picPopupWarning.SvgImage = My.Resources.warping
                Me.BackColor = Color.LightSalmon
                bShow = True
            Case "error"
                picPopupWarning.SvgImage = My.Resources.error2
                Me.BackColor = Color.PeachPuff
                bShow = True
            Case "warning"
                picPopupWarning.SvgImage = My.Resources.warning
                Me.BackColor = Color.LightYellow
                bShow = True
        End Select
        If bShow Then
            lblPopupWarning.Text = Text
            lblPopupWarning.ToolTip = Text & If(Details <> "", vbCrLf & Details, "")
            Visible = True
        End If
    End Sub

    Public Event OnCloseRequest(sender As Object, e As EventArgs)

    Private Sub btnPopupClose_Click(sender As Object, e As EventArgs) Handles btnPopupClose.Click
        RaiseEvent OnCloseRequest(sender, e)
    End Sub

    Public Event MessageClick(Sender As Object, e As EventArgs)

    Private Sub lblPopupWarning_Click(sender As Object, e As EventArgs) Handles lblPopupWarning.Click
        If bAllowMessageClick Then
            RaiseEvent MessageClick(sender, e)
        End If
    End Sub

    Private Sub cMessageBar_Click(Sender As Object, e As EventArgs) Handles Me.Click
        If bAllowMessageClick Then
            RaiseEvent MessageClick(Sender, e)
        End If
    End Sub

    Private Sub picPopupWarning_Click(sender As Object, e As EventArgs) Handles picPopupWarning.Click
        If bAllowMessageClick Then
            RaiseEvent MessageClick(sender, e)
        End If
    End Sub

    Public Event CustomButtonClick(Sender As Object, e As EventArgs)

    Private Sub btnPopupCustom_Click(sender As Object, e As EventArgs) Handles btnPopupCustom.Click
        RaiseEvent CustomButtonClick(sender, e)
    End Sub

    Public Event MessageLinkClick(Sender As Object, e As cInternalLinkEventArgs)

    Private Sub lblPopupWarning_HyperlinkClick(sender As Object, e As DevExpress.Utils.HyperlinkClickEventArgs) Handles lblPopupWarning.HyperlinkClick
        Dim sLink As String = e.Link
        If sLink.StartsWith("""") AndAlso sLink.EndsWith("""") Then
            sLink = sLink.Substring(1, sLink.Length - 2)
        End If
        RaiseEvent MessageLinkClick(Me, New cInternalLinkEventArgs(sLink))
    End Sub

    Private Sub cMessageBar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        btnPopupClose.Location = New Point(Width - btnPopupClose.Width, btnPopupClose.Top)
        btnPopupCustom.Location = New Point(Width - btnPopupCustom.Width - 4 * Me.CurrentAutoScaleDimensions.Height / 96.0F, btnPopupCustom.Top)
        lblPopupWarning.Size = New Size(Width - picPopupWarning.Width - btnPopupCustom.Width - 4 * Me.CurrentAutoScaleDimensions.Height / 96.0F, Height - 8 * Me.CurrentAutoScaleDimensions.Height / 96.0F)
        picPopupWarning.Size = New Size(picPopupWarning.Width, Height)
    End Sub
End Class

Public Class cInternalLinkEventArgs
    Inherits EventArgs

    Private sLink As String

    Public ReadOnly Property Link As String
        Get
            Return sLink
        End Get
    End Property

    Public Sub New(Link As String)
        sLink = Link
    End Sub
End Class
