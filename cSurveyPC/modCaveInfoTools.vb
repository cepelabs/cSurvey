Module modCaveInfoTools
    Public Sub CopyGridData(Rows As Object)
        Try
            Dim sText As String = ""
            Dim bFirst As Boolean = True
            For Each oRow As DataGridViewRow In Rows
                If bFirst Then
                    sText = "" & vbTab
                    For Each oCell As DataGridViewCell In oRow.Cells
                        sText = sText & oCell.OwningColumn.HeaderCell.Value & vbTab
                    Next
                    sText = sText & vbCrLf
                    bFirst = False
                End If
                sText = sText & oRow.HeaderCell.Value & vbTab
                For Each oCell As DataGridViewCell In oRow.Cells
                    sText = sText & oCell.FormattedValue & vbTab
                Next
                sText = sText & vbCrLf
            Next
            Call My.Computer.Clipboard.SetText(sText)
        Catch ex As Exception
        End Try
    End Sub
End Module
