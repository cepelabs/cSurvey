﻿Imports System.Xml
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Class cPreviewProfiles
        Implements cIProfiles
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As List(Of cPreviewProfile)

        Friend Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Try
                Dim oXmlItem As XmlElement = Document.CreateElement("previewprofiles")
                For Each oItem As cPreviewProfile In oItems
                    'If Not oItem.IsSystem Then
                    Call oItem.SaveTo(File, Document, oXmlItem)
                    'End If
                Next
                Call Parent.AppendChild(oXmlItem)
                Return oXmlItem
            Catch
                Return Nothing
            End Try
        End Function

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cPreviewProfile)
            Call oItems.Add(New cPreviewProfile(oSurvey, oSurvey.Options("_preview.plan"), cIDesign.cDesignTypeEnum.Plan))
            Call oItems.Add(New cPreviewProfile(oSurvey, oSurvey.Options("_preview.profile"), cIDesign.cDesignTypeEnum.Profile))
        End Sub

        Friend Sub New(Survey As cSurvey, ByVal File As Storage.cFile, Profiles As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cPreviewProfile)
            Dim bPlanExist As Boolean = False
            Dim bProfileExist As Boolean = False
            For Each oXMLProfile As XmlElement In Profiles.ChildNodes
                Dim oItem As cPreviewProfile = New cPreviewProfile(oSurvey, File, oXMLProfile)
                If oItem.IsSystem Then
                    If oItem.IsPlan Then
                        bPlanExist = True
                    Else
                        bProfileExist = True
                    End If
                End If
                Call oItems.Add(oItem)
            Next
            If Not bPlanExist Then Call oItems.Insert(0, New cPreviewProfile(oSurvey, oSurvey.Options("_preview.plan"), cIDesign.cDesignTypeEnum.Plan))
            If Not bProfileExist Then Call oItems.Insert(1, New cPreviewProfile(oSurvey, oSurvey.Options("_preview.profile"), cIDesign.cDesignTypeEnum.Profile))
        End Sub

        Public Function Add(Name As String, Design As cIDesign.cDesignTypeEnum) As cIProfile Implements cIProfiles.Add
            Dim oItem As cPreviewProfile = New cPreviewProfile(oSurvey, Name, Design)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Function AddAsCopy(Profile As cIProfile, Name As String) As cIProfile Implements cIProfiles.AddAsCopy
            Try
                Dim oXML As XmlDocument = New XmlDocument
                Dim oXMLRoot As XmlElement = oXML.CreateElement("root")
                Call DirectCast(Profile, cPreviewProfile).SaveTo(Nothing, oXML, oXMLRoot)
                Dim oItem As cPreviewProfile = New cPreviewProfile(oSurvey, Nothing, oXMLRoot.ChildNodes(0))
                oItem.Name = Name
                Call oItems.Add(oItem)
                Return oItem
            Catch
                Return Nothing
            End Try
        End Function

        Public Sub Clear() Implements cIProfiles.Clear
            Call oItems.Clear()
        End Sub

        Public Function Contains(Item As cIProfile) As Boolean Implements cIProfiles.Contains
            Return oItems.Contains(Item)
        End Function

        Public ReadOnly Property Count As Integer Implements cIProfiles.Count
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cIProfile Implements cIProfiles.Item
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Sub Remove(Item As cIProfile) Implements cIProfiles.Remove
            Item.ondeleting
            Call oItems.Remove(Item)
        End Sub

        Public Sub Remove(Index As Integer) Implements cIProfiles.Remove
            Dim oItem As cIProfile = oItems(Index)
            Call oItem.ondeleting
            Call oItems.Remove(oItem)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Public Function IndexOf(Item As cIProfile) As Integer Implements cIProfiles.IndexOf
            Return oItems.IndexOf(Item)
        End Function

        Public Function ToArray() As cIProfile() Implements cIProfiles.ToArray
            Return oItems.ToArray
        End Function

        Public Function ToList() As List(Of cIProfile) Implements cIProfiles.ToList
            Return oItems.Select(Function(item) DirectCast(item, cIProfile)).ToList
        End Function
    End Class

    Public Class cPreviewProfile
        Implements cIProfile

        Private oSurvey As cSurvey

        Private sName As String
        Private sNote As String
        Private iDesign As cIDesign.cDesignTypeEnum
        Private bIsSystem As Boolean
        Private WithEvents oOptions As cOptionsPreview

        Private oItems As cVisibilityItems

        Public Event OnDelete(Sender As Object, e As EventArgs) Implements cIProfile.OnDelete

        Friend Sub OnDeleting() Implements cIProfile.OnDeleting
            RaiseEvent OnDelete(Me, New EventArgs)
        End Sub

        Public Property Name As String Implements cIProfile.Name
            Get
                Return sName
            End Get
            Set(value As String)
                sName = value
            End Set
        End Property

        Public Property Note As String Implements cIProfile.Note
            Get
                Return sNote
            End Get
            Set(value As String)
                sNote = value
            End Set
        End Property

        Public ReadOnly Property Design As cIDesign.cDesignTypeEnum Implements cIProfile.Design
            Get
                Return iDesign
            End Get
        End Property

        Public ReadOnly Property IsSystem As Boolean Implements cIProfile.IsSystem
            Get
                Return bIsSystem
            End Get
        End Property

        Public ReadOnly Property Options As Design.cOptions Implements cIProfile.Options
            Get
                Return oOptions
            End Get
        End Property

        Private Sub oOptions_OnGetParent(Sender As Object, Args As cOptions.GetParentEventArgs) Handles oOptions.OnGetParent
            Args.Parent = Me
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Profile As XmlElement)
            oSurvey = Survey
            iDesign = Profile.GetAttribute("design")
            If modXML.GetAttributeValue(Profile, "s", 0) = 0 Then
                sName = Profile.GetAttribute("name")
                oOptions = New cOptionsPreview(oSurvey, Profile.Item("options"))
                bIsSystem = False
            Else
                Select Case iDesign
                    Case cIDesign.cDesignTypeEnum.Plan
                        sName = GetLocalizedString("exportprofile.textpart1")
                    Case cIDesign.cDesignTypeEnum.Profile
                        sName = GetLocalizedString("exportprofile.textpart2")
                End Select
                oOptions = oSurvey.Options(Profile.GetAttribute("so"))
                bIsSystem = True
            End If
            Try
                oItems = New cVisibilityItems(oSurvey, Profile.Item("vis"))
            Catch ex As Exception
                oItems = New cVisibilityItems(oSurvey)
            End Try
        End Sub

        Friend Sub New(Survey As cSurvey, [Options] As cOptionsPreview, Design As cIDesign.cDesignTypeEnum)
            oSurvey = Survey
            iDesign = Design
            Select Case iDesign
                Case cIDesign.cDesignTypeEnum.Plan
                    sName = GetLocalizedString("previewprofile.textpart1")
                Case cIDesign.cDesignTypeEnum.Profile
                    sName = GetLocalizedString("previewprofile.textpart2")
            End Select
            oOptions = [Options]
            oItems = New cVisibilityItems(oSurvey)
            bIsSystem = True
        End Sub

        Friend Sub New(Survey As cSurvey, Name As String, Design As cIDesign.cDesignTypeEnum)
            oSurvey = Survey
            sName = Name
            iDesign = Design
            Select Case iDesign
                Case cIDesign.cDesignTypeEnum.Plan
                    oOptions = New cOptionsPreview(oSurvey, "options")
                Case cIDesign.cDesignTypeEnum.Profile
                    oOptions = New cOptionsPreview(oSurvey, "options")
            End Select
            oItems = New cVisibilityItems(oSurvey)
            bIsSystem = False
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("profile")
            Call oXmlItem.SetAttribute("design", iDesign)
            If bIsSystem Then
                Call oXmlItem.SetAttribute("s", "1")
                Call oXmlItem.SetAttribute("so", Options.Name)
            Else
                Call oXmlItem.SetAttribute("name", sName)
                Dim oXMLOptions As XmlElement = oOptions.SaveTo(File, Document, oXmlItem)
                If oOptions.Name <> "options" Then
                    Call RenameElement(oXMLOptions, "options")
                End If
            End If
            If oItems.Count > 0 Then Call oItems.SaveTo(File, Document, oXmlItem)
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Function IsPlan() As Boolean Implements cIProfile.IsPlan
            Return iDesign = cIDesign.cDesignTypeEnum.Plan
        End Function

        Public Function IsProfile() As Boolean Implements cIProfile.IsProfile
            Return iDesign = cIDesign.cDesignTypeEnum.Profile
        End Function

        Public ReadOnly Property Items As cVisibilityItems Implements cIProfile.Items
            Get
                Return oItems
            End Get
        End Property
    End Class
End Namespace
