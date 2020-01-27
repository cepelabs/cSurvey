
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey
    Public Class cSingsImportHelper
        Public Shared Function CreateIndex(Gallery As List(Of Object)) As Dictionary(Of cIItemSign.SignEnum, String)
            Dim oResults As Dictionary(Of cIItemSign.SignEnum, String) = New Dictionary(Of cIItemSign.SignEnum, String)
            For Each oTag In Gallery
                Dim sFilename As String = oTag(0)
                Dim oClipart As Drawings.cDrawClipArt = oTag(1)
                Dim iSign As cIItemSign.SignEnum = GetSignFromClipart(oClipart)
                If iSign <> cIItemSign.SignEnum.Undefined AndAlso Not oResults.ContainsKey(iSign) Then
                    Call oResults.Add(iSign, sFilename)
                End If
            Next
            Return oResults
        End Function

        Public Shared Function FindInIndex(Index As Dictionary(Of cIItemSign.SignEnum, Drawings.cDrawClipArt), Key As cIItemSign.SignEnum, Optional DefaultValue As Drawings.cDrawClipArt = Nothing) As Drawings.cDrawClipArt
            If Index.ContainsKey(Key) Then
                Return Index(Key)
            Else
                Return DefaultValue
            End If
        End Function

        Public Shared Function GetSignFromClipart(Clipart As Drawings.cDrawClipArt) As cIItemSign.SignEnum
            If Clipart.UserData.Contains("sign") Then
                Dim sSign As String = Clipart.UserData.GetValue("sign", "")
                If sSign = "" Then
                    Return cIItemSign.SignEnum.Undefined
                Else
                    Dim iSign As cIItemSign.SignEnum
                    If Integer.TryParse(sSign, iSign) Then
                        Return DirectCast([Enum].Parse(GetType(cIItemSign.SignEnum), iSign), cIItemSign.SignEnum)
                    Else
                        Return Design.Items.cIItemSign.SignEnum.Undefined
                    End If
                End If
            Else
                Return Design.Items.cIItemSign.SignEnum.Undefined
            End If
        End Function
    End Class
End Namespace
