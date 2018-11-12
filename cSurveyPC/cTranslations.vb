Imports System.Xml

Namespace cSurvey
    Public Class cTranslations
        Private oPlan As cTranslation
        Private oProfile As cTranslation

        Public Function Clone() As cTranslations
            Return New cTranslations(Me)
        End Function

        Friend Sub New()
            oPlan = New cTranslation(cTranslation.cTranslationApplyToEnum.Plan, 0, 0)
            oProfile = New cTranslation(cTranslation.cTranslationApplyToEnum.Profile, 0, 0)
        End Sub

        Public Shared Function Add(Translations1 As cTranslations, Translations2 As cTranslations) As cTranslations
            Dim oTranslations As cTranslations = Translations1.Clone
            oTranslations.Plan.X += Translations2.Plan.X
            oTranslations.Plan.Y += Translations2.Plan.Y
            oTranslations.Profile.X += Translations2.Profile.X
            oTranslations.Profile.Y += Translations2.Profile.Y
            Return oTranslations
        End Function

        Public Shared Operator +(Translations1 As cTranslations, Translations2 As cTranslations) As cTranslations
            Return Add(Translations1, Translations2)
        End Operator

        Friend Sub New(ByVal Translations As cTranslations)
            oPlan = New cTranslation(Translations.Plan)
            oProfile = New cTranslation(Translations.Profile)
        End Sub

        Friend Sub New(ByVal Translations As XmlElement)
            If modXML.ChildElementExist(Translations, "plan") Then
                oPlan = New cTranslation(Translations.Item("plan"))
            Else
                oPlan = New cTranslation(cTranslation.cTranslationApplyToEnum.Plan, 0, 0)
            End If
            If modXML.ChildElementExist(Translations, "profile") Then
                oProfile = New cTranslation(Translations.Item("profile"))
            Else
                oProfile = New cTranslation(cTranslation.cTranslationApplyToEnum.Profile, 0, 0)
            End If
        End Sub

        Public ReadOnly Property Plan() As cTranslation
            Get
                Return oPlan
            End Get
        End Property

        Public ReadOnly Property Profile() As cTranslation
            Get
                Return oProfile
            End Get
        End Property

        Public ReadOnly Property IsEmpty() As Boolean
            Get
                Return Plan.IsEmpty And oProfile.IsEmpty
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlTranslations As XmlElement = Document.CreateElement("translations")
            Call oPlan.SaveTo(File, Document, oXmlTranslations)
            Call oProfile.SaveTo(File, Document, oXmlTranslations)
            Call Parent.AppendChild(oXmlTranslations)
            Return oXmlTranslations
        End Function
    End Class
End Namespace