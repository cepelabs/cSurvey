<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cNumericUpDown
    Inherits NumericUpDown

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    End Sub

    Private Sub cNumericUpDown_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "." And Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator <> "." Then
            SendKeys.Send("{DEL}" & Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator)
            e.Handled = True
        End If
    End Sub
End Class
