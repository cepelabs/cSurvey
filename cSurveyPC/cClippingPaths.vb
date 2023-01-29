Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cClippingPaths
        Implements IDisposable
        Implements IEnumerable

        Private oSurvey As cSurvey

        Public Enum ClipBorderEnum
            DontClipBorder = 0
            ClipBorder = 1
            Disable = 2
        End Enum

        Private iClipBorder As ClipBorderEnum

        Private oPaths As Dictionary(Of String, GraphicsPath)

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            iClipBorder = oSurvey.Properties.DesignProperties.GetValue("ClipBorder", My.Application.Settings.GetSetting("design.clipborder", ClipBorderEnum.ClipBorder))
            oPaths = New Dictionary(Of String, GraphicsPath)(System.StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Sub Clear()
            Call oPaths.Clear()
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oPaths.Count
            End Get
        End Property

        Friend Function GetClip(ByVal Graphics As Graphics, ByVal Layer As cLayer, ByVal Cave As String, ByVal Branch As String) As GraphicsPath
            If iClipBorder = ClipBorderEnum.Disable Then
                Return Nothing
            Else
                If Layer.Type >= cLayers.LayerTypeEnum.Borders Then
                    Return Nothing
                Else
                    Dim sKey As String = Cave & "/" & Branch
                    sKey = sKey.ToLower
                    If oPaths.ContainsKey(sKey) Then
                        Dim oClip As GraphicsPath = oPaths(sKey)
                        If oClip.PointCount = 0 Then
                            Return Nothing
                        Else
                            Return oClip
                        End If
                    Else
                        Return Nothing
                    End If
                End If
            End If
        End Function

        Public Function Contains(ByVal Cave As String, ByVal Branch As String) As Boolean
            Dim sKey As String = Cave & "/" & Branch
            Return oPaths.ContainsKey(sKey)
        End Function

        Default ReadOnly Property Item(ByVal Cave As String, ByVal Branch As String) As GraphicsPath
            Get
                Dim sKey As String = Cave & "/" & Branch
                If oPaths.ContainsKey(sKey) Then
                    Return oPaths(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            If oPaths.ContainsKey(sKey) Then
                Dim oCurrentGraphicsPath As GraphicsPath = oPaths(sKey)
                oCurrentGraphicsPath.AddPath(Path, False)
            End If
        End Sub

        Public Sub Intersect(Cave As String, Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentGraphicsPath As GraphicsPath
            If oPaths.ContainsKey(sKey) Then
                oCurrentGraphicsPath = oPaths(sKey)
                oCurrentGraphicsPath.AddPath(Path, False)
            Else
                oCurrentGraphicsPath = Path.Clone
                Call oPaths.Add(sKey, oCurrentGraphicsPath)
            End If
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentGraphicsPath As GraphicsPath
            If oPaths.ContainsKey(sKey) Then
                oCurrentGraphicsPath = oPaths(sKey)
                oCurrentGraphicsPath.AddPath(Path, False)
            Else
                oCurrentGraphicsPath = Path.Clone
                Call oPaths.Add(sKey, oCurrentGraphicsPath)
            End If
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oPaths.Values.GetEnumerator
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    For Each oGraphicsPath As GraphicsPath In oPaths.Values
                        Call oGraphicsPath.Dispose()
                    Next
                    Call oPaths.Clear()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Call Dispose(True)
            Call GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace