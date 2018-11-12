Imports System.Collections.ObjectModel

Public Class cCommandLineParameter
    Private sKey As String
    Private sValue As String

    Public ReadOnly Property Key() As String
        Get
            Key = sKey
        End Get
    End Property

    Public Property Value() As String
        Get
            Value = sValue
        End Get
        Set(ByVal Value As String)
            sValue = Value
        End Set
    End Property

    Friend Sub New(ByVal Key As String, Optional ByVal Value As String = "")
        sKey = Key
        sValue = Value
    End Sub
End Class

Public Class cCommandLineParameters
    Friend Class cCommandLineParametersBaseCollection
        Inherits KeyedCollection(Of String, cCommandLineParameter)

        Protected Overrides Function GetKeyForItem(ByVal item As cCommandLineParameter) As String
            Return item.Key
        End Function
    End Class

    Private oItems As cCommandLineParametersBaseCollection

    Public Function Add(ByVal Key As String, Optional ByVal Value As String = "") As cCommandLineParameter
        Dim sKey As String = Key.ToLower
        Dim oItem As cCommandLineParameter = New cCommandLineParameter(sKey, Value)
        If oItems.Contains(sKey) Then oItems.Remove(sKey)
        Call oItems.Add(oItem)
        Return oItem
    End Function

    Default Public ReadOnly Property Item(ByVal Index As Integer) As cCommandLineParameter
        Get
            Return oItems(Index)
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal Key As String) As cCommandLineParameter
        Get
            Dim sKey As String = Key.ToLower
            Return oItems(sKey)
        End Get
    End Property

    Public Sub Remove(ByVal Index As Integer)
        Call oItems.RemoveAt(Index)
    End Sub

    Public Sub Remove(ByVal Key As String)
        Call oItems.Remove(Key)
    End Sub

    Public Sub Remove(ByVal Item As cCommandLineParameter)
        Call oItems.Remove(Item)
    End Sub

    Public Sub New()
        oItems = New cCommandLineParametersBaseCollection
    End Sub

    Public Sub New(ByVal CommandLine As String)
        oItems = New cCommandLineParametersBaseCollection
        Call FromCommandLine(CommandLine)
    End Sub

    Private Sub Clear()
        Call oItems.Clear()
    End Sub

    Public Function Count() As Integer
        Return oItems.Count
    End Function

    Public Function Contains(ByVal Key As String) As Boolean
        Return oItems.Contains(Key)
    End Function

    Public Function Contains(ByVal Item As cCommandLineParameter) As Boolean
        Return oItems.Contains(Item)
    End Function

    Public Function GetValue(ByVal Key As String, Optional ByVal DefaultValue As String = "") As String
        Dim sKey As String = Key.ToLower
        If oItems.Contains(sKey) Then
            Return Item(sKey).Value
        Else
            Return DefaultValue
        End If
    End Function

    Public Sub FromCommandLine(ByVal CommandLine As String)
        Call oItems.Clear()
        Dim sTemp As String
        Dim sChar As String
        Dim sRes As String = ""
        Dim bOn As Boolean
        Dim sSeparator As Char = Chr(0)
        Dim sVirgolette As Char = Chr(34)
        sTemp = CommandLine
        sTemp = sTemp.Replace(sVirgolette & sVirgolette, vbNullChar)
        For Each sChar In sTemp.ToCharArray
            Select Case sChar
                Case sVirgolette
                    bOn = Not bOn
                    sChar = ""
                Case " "
                    If Not bOn Then
                        sChar = sSeparator
                    End If
                Case vbNullChar
                    sChar = sVirgolette
            End Select
            sRes = sRes & sChar
        Next

        For Each sParam As String In sRes.Split(sSeparator)
            Dim p As Integer = sParam.IndexOf("=")
            Dim sKey As String
            Dim sValue As String
            If p < 0 Then
                sKey = sParam
                sValue = ""
            Else
                sKey = sParam.Substring(0, p)
                sValue = sParam.Substring(p + 1)
            End If
            sKey = sKey.ToLower
            Call Add(sKey, sValue)
        Next
    End Sub

End Class
