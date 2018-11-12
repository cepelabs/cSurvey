Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design.Items
    Public Class cItemInformationBoxText
        Inherits cItemText

        Public Overrides Property Text As String
            Get
                Return "" & MyBase.Survey.Properties.InfoBoxStructure
            End Get
            Set(value As String)
                If IsNothing(value) Then value = ""
                If MyBase.Survey.Properties.InfoBoxStructure <> value Then
                    MyBase.Survey.Properties.InfoBoxStructure = value
                    Call MyBase.Caches.Invalidate()
                End If
            End Set
        End Property

        Friend Overrides Function GetTextScaleFactor(PaintOptions As cOptions) As Single
            Dim sTextScaleFactor As Single = MyBase.GetTextScaleFactor(PaintOptions)
            Select Case MyBase.TextSize
                Case cIItemText.TextSizeEnum.Default
                    Return 1 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.VerySmall
                    Return 0.25 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Small
                    Return 0.5 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Medium
                    Return 1 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.Large
                    Return 2 * sTextScaleFactor
                Case cIItemText.TextSizeEnum.VeryLarge
                    Return 4 * sTextScaleFactor
            End Select
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal Category As cIItem.cItemCategoryEnum)
            Call MyBase.New(Survey, Design, Layer, Category, "")
            MyBase.DesignAffinity = DesignAffinityEnum.Extra
        End Sub

        Public Overrides ReadOnly Property Type() As cIItem.cItemTypeEnum
            Get
                Return cIItem.cItemTypeEnum.InformationBoxText
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Design As cDesign, ByVal Layer As cLayer, ByVal File As Storage.cFile, ByVal item As XmlElement)
            Call MyBase.New(Survey, Design, Layer, File, item)
        End Sub

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oItem As XmlElement = MyBase.SaveTo(File, Document, Parent, Options)
            Call oItem.RemoveAttribute("text")
            Return oItem
        End Function
    End Class

End Namespace
