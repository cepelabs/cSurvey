Module modToolbars

    Public Sub LoadToolbarPosition(Container As ToolStripContainer, Toolbar As ToolStrip, Position As String)
        If Not (My.Computer.Keyboard.CtrlKeyDown And My.Computer.Keyboard.ShiftKeyDown) Then
            If Position <> "" Then
                Dim sPositions() As String = Position.Split(",")
                Dim sDock As String = sPositions(0)
                If sDock = "" Then
                    Toolbar.Parent = Nothing
                Else
                    Dim iDock As Windows.Forms.DockStyle = sDock
                    Select Case iDock
                        Case DockStyle.Top
                            Toolbar.Parent = Container.TopToolStripPanel
                        Case DockStyle.Left
                            Toolbar.Parent = Container.LeftToolStripPanel
                        Case DockStyle.Bottom
                            Toolbar.Parent = Container.BottomToolStripPanel
                        Case DockStyle.Right
                            Toolbar.Parent = Container.RightToolStripPanel
                    End Select
                End If
                Toolbar.Location = New Point(sPositions(1), sPositions(2))
            End If
        End If
    End Sub

    Public Function SaveToolbarPosition(Toolbar As ToolStrip) As String
        Dim sDock As String
        If Toolbar.Parent Is Nothing Then
            sDock = ""
        Else
            sDock = Toolbar.Parent.Dock.ToString("D")
        End If
        Return sDock & "," & modNumbers.NumberToString(Toolbar.Location.X, "0") & "," & modNumbers.NumberToString(Toolbar.Location.Y, "0")
    End Function

End Module
