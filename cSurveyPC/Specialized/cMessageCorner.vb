Public Class cMessageCorner
    Private bAllowClick As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Call DevExpress.Utils.WorkspaceManager.SetSerializationEnabled(Me, False)
    End Sub

    Public Property AllowClick() As Boolean
        Get
            Return bAllowClick
        End Get
        Set(value As Boolean)
            If bAllowClick <> value Then
                bAllowClick = value
                If bAllowClick Then
                    picPopupWarning.Cursor = Cursors.Hand
                Else
                    picPopupWarning.Cursor = Cursors.Default
                End If
            End If
        End Set
    End Property

    Public Sub PopupHide()
        Me.AllowClick = False
        Me.Visible = False
    End Sub

    Private sText As String

    Public ReadOnly Property Text As String
        Get
            Return sText
        End Get
    End Property

    Private sType As String

    Public ReadOnly Property Type As String
        Get
            Return sType
        End Get
    End Property

    Public Sub PopupShow(ByVal Type As String, ByVal Text As String, Optional AllowClick As Boolean = False)
        Dim bShow As Boolean
        sType = Type.ToLower
        sText = Text
        Me.AllowClick = AllowClick
        Select Case sType
            Case "error"
                picPopupWarning.SvgImage = My.Resources.error2
                Me.BackColor = Color.PeachPuff
                bShow = True
            Case "refreshwarning"
                picPopupWarning.SvgImage = My.Resources.refresh_warning
                Me.BackColor = Color.LightYellow
                bShow = True
            Case "warning"
                picPopupWarning.SvgImage = My.Resources.warning
                Me.BackColor = Color.LightYellow
                bShow = True
        End Select
        If bShow Then
            picPopupWarning.SuperTip = modDevExpress.CreateSuperTip("", Nothing, Nothing, sText, picPopupWarning.SvgImage, New Size(24, 24), "", Nothing, Nothing)
            Me.Visible = True
        End If
    End Sub

    Public Event MessageClick(Sender As Object, e As EventArgs)

    Private Sub cMessageBar_Click(Sender As Object, e As EventArgs) Handles Me.Click
        If bAllowClick Then
            RaiseEvent MessageClick(Sender, e)
        End If
    End Sub

    Private Sub picPopupWarning_Click(sender As Object, e As EventArgs) Handles picPopupWarning.Click
        If bAllowClick Then
            RaiseEvent MessageClick(sender, e)
        End If
    End Sub

    Private bFirst As Boolean = True

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

    Private Sub cMessageCorner_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Visible Then
            bfirst = False
            'Size = New Size(96 * Me.CurrentAutoScaleDimensions.Width / 96.0F, 96 * Me.CurrentAutoScaleDimensions.Height / 96.0F)
            Dim iSide As Integer = (picPopupWarning.Left + picPopupWarning.Width) * 2
            Size = New Size(iSide, iSide)
            Using oPath As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath
                Call oPath.AddPolygon({New Point(0, 0), New Point(Width, 0), New Point(0, Height), New Point(0, 0)})
                Me.Region = New Region(oPath)
            End Using
        End If
    End Sub

    Public Event CustomButtonClick(Sender As Object, e As EventArgs)

    Private Sub btnPopupCustom_Click(sender As Object, e As EventArgs) Handles btnPopupCustom.Click
        RaiseEvent CustomButtonClick(sender, e)
    End Sub

End Class
