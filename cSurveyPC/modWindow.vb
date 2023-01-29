Imports System.Runtime.InteropServices
Imports cSurveyPC.cSurvey.Helper.Editor

Module modWindow
    <DllImport("user32.dll")>
    Function GetAsyncKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    <DllImport("user32.dll")>
    Function GetKeyState(ByVal vKey As System.Windows.Forms.Keys) As Short
    End Function

    Public Sub SetSizeToSettings(Settings As cEnvironmentSettingsFolder, Name As String, Value As Size)
        Call Settings.SetSetting(Name, Value.Width & ";" & Value.Height)
    End Sub

    Public Function GetSizeFromSettings(Settings As cEnvironmentSettingsFolder, Value As String, DefaultValue As Size) As Size
        Dim sSize As String = "" & Settings.GetSetting(Value, Nothing)
        If sSize = "" Then
            Return DefaultValue
        Else
            Dim sSizeParts As String() = sSize.Split(";")
            Return New Drawing.Size(sSizeParts(0), sSizeParts(1))
        End If
    End Function

    Public Function RelativeToAbsolutePath(Filename As String, RelativePath As String) As String
        If RelativePath.Trim <> "" Then
            If Not RelativePath.EndsWith(IO.Path.DirectorySeparatorChar) Then RelativePath &= IO.Path.DirectorySeparatorChar
            Dim sAbsolutePath As String = IO.Path.Combine(RelativePath, Filename)
            Return IO.Path.GetFullPath((New Uri(sAbsolutePath)).LocalPath)
        Else
            Return Filename
        End If
    End Function

    Public Function IsPathFullyQualified(Path As String) As Boolean
        Dim sRoot As String = IO.Path.GetPathRoot(Path)
        Return sRoot.StartsWith("\\") OrElse sRoot.EndsWith("\")
    End Function

    Public Function AbsolutePathToRelative(Filename As String, RelativePath As String) As String
        Dim sFilename As String
        Dim sRelativePath As String = RelativePath.Trim
        If sRelativePath <> "" AndAlso IsPathFullyQualified(Filename) Then
            If Not sRelativePath.EndsWith(IO.Path.DirectorySeparatorChar) Then sRelativePath &= IO.Path.DirectorySeparatorChar
            Dim oFilename As Uri = New Uri(Filename.ToLower, UriKind.RelativeOrAbsolute)
            Dim oRelativePath As Uri = New Uri(sRelativePath.ToLower, UriKind.RelativeOrAbsolute)
            sFilename = Uri.UnescapeDataString(oRelativePath.MakeRelativeUri(oFilename).ToString.Replace("/", IO.Path.DirectorySeparatorChar))
        Else
            sFilename = Filename
        End If
        Return sFilename
    End Function

    Public Sub Fix(c As Control, Scale As SizeF)
        For Each child As Control In c.Controls
            If TypeOf child Is SplitContainer Then
                Dim sp As SplitContainer = DirectCast(child, SplitContainer)
                Fix(sp, Scale)
                Fix(sp.Panel1, Scale)
                Fix(sp.Panel2, Scale)
            Else
                Fix(child, Scale)
            End If
        Next
    End Sub

    Public Sub Fix(sp As SplitContainer, Scale As SizeF)
        ' Scale factor depends on orientation
        Dim sc As Single = If((sp.Orientation = Orientation.Vertical), Scale.Width, Scale.Height)
        If sp.FixedPanel = FixedPanel.Panel1 Then
            sp.SplitterDistance = CInt(Math.Round(CSng(sp.SplitterDistance) * sc))
        ElseIf sp.FixedPanel = FixedPanel.Panel2 Then
            Dim cs As Integer = If((sp.Orientation = Orientation.Vertical), sp.Panel2.ClientSize.Width, sp.Panel2.ClientSize.Height)
            Dim newcs As Integer = CInt(CSng(cs) * sc)
            sp.SplitterDistance -= (newcs - cs)
        End If
    End Sub

    'Public Sub ForceFont(Control As Control, Font As Font)
    '    For Each oControl As Control In Control.Controls
    '        Try
    '            oControl.Font = Font
    '        Catch
    '        End Try
    '        If oControl.HasChildren Then
    '            Call ForceFont(oControl, Font)
    '        End If
    '    Next
    'End Sub

    'Public Sub ForceFont(Form As Form)
    '    Dim oFont As Font = New Font("Tahoma", 11, GraphicsUnit.Pixel)
    '    Form.Font = oFont
    '    For Each oControl As Control In Form.Controls
    '        Try
    '            oControl.Font = oFont
    '        Catch
    '        End Try
    '        If oControl.HasChildren Then
    '            Call ForceFont(oControl, oFont)
    '        End If
    '    Next
    'End Sub

    Public Function WindowSettingsToString(ByVal Form As Form) As String
        Return Form.Location.X & "," & Form.Location.Y & "," & Form.Size.Width & "," & Form.Size.Height
    End Function

    Public Sub StringToWindowSettings(ByVal [String] As String, ByVal Form As Form)
        Dim sLocation As String = "" & [String]
        If sLocation <> "" Then
            Dim sItems() As String = Strings.Split(sLocation, ",")
            Dim oLocation As Point = New Point(sItems(0), sItems(1))
            Dim oSize As Size = New Size(sItems(2), sItems(3))
            Form.Location = oLocation
            Form.Size = oSize
        End If
    End Sub

    Public Function RectangleToString(ByVal Rectangle As Rectangle) As String
        Return Rectangle.Location.X & "," & Rectangle.Location.Y & "," & Rectangle.Size.Width & "," & Rectangle.Size.Height
    End Function

    Public Function StringToRectangle(ByVal [String] As String) As Rectangle
        Dim sItems() As String = Strings.Split([String], ",")
        Dim oLocation As Point = New Point(sItems(0), sItems(1))
        Dim oSize As Size = New Size(sItems(2), sItems(3))
        Dim oRectangle As Rectangle = New Rectangle(oLocation, oSize)
        Return oRectangle
    End Function

End Module
