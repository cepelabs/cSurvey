Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cBrushSeed
        Private sBase As Single
        Private sIncrement As Single

        Private sCurrentBase As Single
        Private sCurrentIncrement As Single

        Friend Event OnReseed(ByVal Sender As cBrushSeed)

        Friend Sub New()
            Call Reseed()
        End Sub

        Public Sub CopyFrom(ByVal Seed As cBrushSeed)
            sBase = Seed.Base
            sIncrement = Seed.Increment
            Call Restart()
        End Sub

        Friend Sub New(ByVal Seed As cBrushSeed)
            sBase = Seed.Base
            sIncrement = Seed.Increment
            Call Restart()
        End Sub

        Friend Sub New(ByVal item As XmlElement)
            sBase = modNumbers.StringToSingle(item.GetAttribute("base"))
            sIncrement = modNumbers.StringToSingle(item.GetAttribute("increment"))
            Call restart()
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oItem As XmlElement = Document.CreateElement("seed")
            Call oItem.SetAttribute("base", modNumbers.NumberToString(sBase))
            Call oItem.SetAttribute("increment", modNumbers.NumberToString(sIncrement))
            Call Parent.AppendChild(oItem)
            Return oItem
        End Function

        Public Sub Reseed()
            sBase = modNumbers.GetRandom(0, 100) ' Rnd() * 100
            sIncrement = modNumbers.GetRandom(0, 30) ' Rnd() * 30
            Call Restart()
            RaiseEvent OnReseed(Me)
        End Sub

        Public Sub Restart()
            sCurrentBase = sBase
            sCurrentIncrement = sIncrement
        End Sub

        Public Function [Next]() As Single
            Dim sSeed As Single = Math.Abs(sCurrentBase) + sCurrentIncrement
            If sSeed >= 100 Then
                sSeed -= 100
                sCurrentIncrement = sCurrentIncrement + 3
                If sCurrentIncrement > 30 Then sCurrentIncrement -= 30
            End If
            Dim iSign As Integer = IIf(sSeed Mod 2, -1, 1)
            sCurrentBase = sSeed * iSign
            Return sCurrentBase
        End Function

        Public ReadOnly Property CurrentBase() As Single
            Get
                Return sCurrentBase
            End Get
        End Property

        Public ReadOnly Property CurrentIncrement As Single
            Get
                Return sCurrentIncrement
            End Get
        End Property

        Public ReadOnly Property Base() As Single
            Get
                Return sBase
            End Get
        End Property

        Public ReadOnly Property Increment As Single
            Get
                Return sIncrement
            End Get
        End Property

    End Class
End Namespace