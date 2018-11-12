Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cGrid
    Inherits System.Windows.Forms.DataGridView

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

    Protected Overrides Function ProcessDataGridViewKey(ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean
        If (e.KeyData And Keys.KeyCode) = Keys.Enter Then
            e.SuppressKeyPress = True
            Call SendKeys.Send("{TAB}")
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function

    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Select Case (keyData And Keys.KeyCode)
            Case Keys.Return
                Call Me.CommitEdit(DataGridViewDataErrorContexts.Commit)
                If Me.Columns.Count > Me.CurrentCell.ColumnIndex - 1 Then
                    Try
                        Me.CurrentCell = Me.CurrentRow.Cells(Me.CurrentCell.ColumnIndex + 1)
                    Catch
                    End Try
                End If
                Exit Select
            Case Keys.Tab
                Call Me.CommitEdit(DataGridViewDataErrorContexts.Commit)
                Exit Select
        End Select

    End Function

    'Private Sub cGrid_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles Me.RowPostPaint
    '    Using b As SolidBrush = New SolidBrush(MyBase.RowHeadersDefaultCellStyle.ForeColor)
    '        e.Graphics.DrawString(e.RowIndex + 1.ToString(System.Globalization.CultureInfo.CurrentUICulture), MyBase.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 12, e.RowBounds.Location.Y + 4)
    '    End Using
    'End Sub

    Private Sub cGrid_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        If MyBase.IsCurrentCellInEditMode Then
            Call ProcessDialogKey(Keys.Enter)
        End If
    End Sub
End Class