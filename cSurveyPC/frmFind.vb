Public Class frmFind

    Public Enum FindWhereEnum
        Segments = 0
        TrigPoints = 1
    End Enum

    Friend Class cFindEventArg
        Private sText As String
        Private bWholeWord As Boolean
        Private bUseJollyChars As Boolean
        Private iWhere As FindWhereEnum

        Private bCancel As Boolean

        Public Property Cancel As Boolean
            Get
                Return bCancel
            End Get
            Set(value As Boolean)
                bCancel = value
            End Set
        End Property

        Friend Sub New(ByVal Text As String, ByVal WholeWord As Boolean, ByVal UseJollyChars As Boolean, ByVal Where As findwhereenum)
            sText = Text
            bWholeWord = WholeWord
            bUseJollyChars = UseJollyChars
            iWhere = Where
        End Sub

        Public Property Text As String
            Get
                Return sText
            End Get
            Set(ByVal value As String)
                sText = value
            End Set
        End Property

        Public Property UseJollyChars As Boolean
            Get
                Return bUseJollyChars
            End Get
            Set(ByVal value As Boolean)
                bUseJollyChars = value
            End Set
        End Property

        Public Property WholeWord As Boolean
            Get
                Return bWholeWord
            End Get
            Set(ByVal value As Boolean)
                bWholeWord = value
            End Set
        End Property

        Public ReadOnly Property Where As findwhereenum
            Get
                Return iWhere
            End Get
        End Property
    End Class

    Friend Event OnFind(ByVal Sender As Object, ByVal e As cFindEventArg)

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim sText As String = cboFind.Text
        If cboFind.Items.Contains(sText) Then
            Call cboFind.Items.Remove(sText)
        End If
        Call cboFind.Items.Insert(0, sText)
        Dim oArgs As cFindEventArg = New cFindEventArg(cboFind.Text, chkFindWholeWord.Checked, chkFindJolly.Checked, cboFindWhere.SelectedIndex)
        RaiseEvent OnFind(Me, oArgs)
        If oArgs.Cancel Then
            Call cmdCancel.PerformClick()
        End If
    End Sub

    Private Sub chkFindWholeWord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFindWholeWord.CheckedChanged
        If chkFindWholeWord.Checked Then
            chkFindJolly.Checked = False
        End If
    End Sub

    Private Sub chkFindJolly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFindJolly.CheckedChanged
        If chkFindJolly.Checked Then
            chkFindWholeWord.Checked = False
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Call Close()
    End Sub

    Protected Overrides Function GetPersistString() As String
        Return "find"
    End Function
End Class