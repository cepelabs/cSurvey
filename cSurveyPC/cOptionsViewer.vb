Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsViewer
        Inherits cOptions
        'Implements cIOptionPrintAndExportArea

        'Private bDrawPrintOrExportArea As Boolean
        'Private iPrintOrExportProfileType As Integer
        'Private iPrintOrExportProfileIndex As Integer
        'Private WithEvents oPrintOrExportProfile As cIProfile

        'Public Overrides Function GetOption() As cIOptions Implements cIOptions.GetOption
        '    If bDrawPrintOrExportArea AndAlso Not IsNothing(oPrintOrExportProfile) Then
        '        Return oPrintOrExportProfile.Options
        '    Else
        '        Return Me
        '    End If
        'End Function

        'Public Overrides Property CurrentCaveVisibilityProfile As String
        '    Get
        '        If bDrawPrintOrExportArea AndAlso Not IsNothing(oPrintOrExportProfile) Then
        '            Return oPrintOrExportProfile.Options.CurrentCaveVisibilityProfile
        '        Else
        '            Return MyBase.CurrentCaveVisibilityProfile
        '        End If
        '    End Get
        '    Set(value As String)
        '        MyBase.CurrentCaveVisibilityProfile = value
        '    End Set
        'End Property

        'Public Function GetPrintOrExportProfile(CurrentDesign As cIDesign) As cIProfile Implements cIOptionPrintAndExportArea.GetPrintOrExportProfile
        '    If iPrintOrExportProfileIndex >= 0 Then
        '        Select Case iPrintOrExportProfileType
        '            Case 0
        '                oPrintOrExportProfile = MyBase.Survey.PreviewProfiles(iPrintOrExportProfileIndex)
        '            Case 1
        '                oPrintOrExportProfile = MyBase.Survey.ExportProfiles(iPrintOrExportProfileIndex)
        '        End Select
        '        iPrintOrExportProfileIndex = -1
        '        iPrintOrExportProfileType = -1
        '    End If
        '    If IsNothing(oPrintOrExportProfile) Then
        '        oPrintOrExportProfile = MyBase.Survey.PreviewProfiles.ToList.FirstOrDefault(Function(item) item.Design = CurrentDesign.Type)
        '    End If
        '    Return oPrintOrExportProfile
        'End Function

        'Public Sub SetPrintOrExportProfile(Value As cIProfile) Implements cIOptionPrintAndExportArea.SetPrintOrExportProfile
        '    oPrintOrExportProfile = Value
        'End Sub

        'Public Property DrawPrintOrExportArea As Boolean Implements cIOptionPrintAndExportArea.DrawPrintOrExportArea
        '    Get
        '        Return bDrawPrintOrExportArea
        '    End Get
        '    Set(value As Boolean)
        '        bDrawPrintOrExportArea = value
        '    End Set
        'End Property

        Friend Overrides Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            'If bDrawPrintOrExportArea Then Call oXMLOptions.SetAttribute("printorexportarea", "1")
            'If Not IsNothing(oPrintOrExportProfile) Then
            '    If TypeOf oPrintOrExportProfile Is cPreviewProfile Then
            '        Call oXMLOptions.SetAttribute("printorexportprofiletype", "0")
            '        Call oXMLOptions.SetAttribute("printorexportprofileindex", MyBase.Survey.PreviewProfiles.IndexOf(oPrintOrExportProfile))
            '    ElseIf TypeOf oPrintOrExportProfile Is cExportProfile Then
            '        Call oXMLOptions.SetAttribute("printorexportprofiletype", "1")
            '        Call oXMLOptions.SetAttribute("printorexportprofileindex", MyBase.Survey.ExportProfiles.IndexOf(oPrintOrExportProfile))
            '    End If
            'End If
            Return oXMLOptions
        End Function

        'Public Overrides Function GetParent() As cIProfile
        '    If bDrawPrintOrExportArea Then
        '        Return oPrintOrExportProfile
        '    End If
        'End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Viewer)
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Viewer)
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub

        Public Overrides Sub Import(Options As XmlElement)
            Call MyBase.Import(Options)

            'bDrawPrintOrExportArea = modXML.GetAttributeValue(Options, "printorexportarea", 0)
            'iPrintOrExportProfileType = modXML.GetAttributeValue(Options, "printorexportprofiletype", -1)
            'iPrintOrExportProfileIndex = modXML.GetAttributeValue(Options, "printorexportprofileindex", -1)
            '---------------------
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub

        'Private Sub oPrintOrExportProfile_OnDelete(Sender As Object, e As EventArgs) Handles oPrintOrExportProfile.OnDelete
        '    bDrawPrintOrExportArea = False
        '    oPrintOrExportProfile = Nothing
        'End Sub
    End Class
End Namespace