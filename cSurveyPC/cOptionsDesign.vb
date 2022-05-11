Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsDesign
        Inherits cOptions
        Implements cIOptionPrintAndExportArea
        Implements cIOptionLinkedSurveys

        Public Enum SplayEditModeEnum
            All = 0
            OnlyCurrentSegment = 1
        End Enum

        Public Enum DesignModeEnum
            Design = 0
            Preview = 1
        End Enum

        Private iDesignMode As DesignModeEnum
        Private iSplayEditMode As SplayEditModeEnum

        Public Enum UnselectedLevelDrawingModeEnum
            Wireframe = 0
            OnlyCaveBorders = 1
            None = 2
        End Enum

        Private iDrawPrintOrExportArea As cIOptionPrintAndExportArea.DesignStyleEnum
        Private bDrawPrintOrExportArea As Boolean
        Private iPrintOrExportProfileType As Integer
        Private iPrintOrExportProfileIndex As Integer
        Private WithEvents oPrintOrExportProfile As cIProfile

        Public Overrides Function GetCurrentDesignPropertiesValue(Name As String, DefaultValue As Object)
            Return GetOption.DesignProperties.GetValue(Name, CurrentRule.DesignProperties.GetValue(Name, MyBase.Survey.Properties.DesignProperties.GetValue(Name, DefaultValue)))
        End Function

        Public Overrides Function GetOption() As cIOptions Implements cIOptions.GetOption
            If bDrawPrintOrExportArea AndAlso Not IsNothing(oPrintOrExportProfile) Then
                Return oPrintOrExportProfile.Options
            Else
                Return Me
            End If
        End Function

        Public Overrides Property CurrentCaveVisibilityProfile As String
            Get
                If bDrawPrintOrExportArea AndAlso Not IsNothing(oPrintOrExportProfile) Then
                    Return oPrintOrExportProfile.Options.CurrentCaveVisibilityProfile
                Else
                    Return MyBase.CurrentCaveVisibilityProfile
                End If
            End Get
            Set(value As String)
                'readonly in this context
            End Set
        End Property

        Private Sub oPrintOrExportProfile_OnDelete(Sender As Object, e As EventArgs) Handles oPrintOrExportProfile.OnDelete
            bDrawPrintOrExportArea = False
            oPrintOrExportProfile = Nothing
            iPrintOrExportProfileIndex = -1
            iPrintOrExportProfileType = -1
        End Sub

        Public Function GetPrintOrExportProfile(CurrentDesign As cIDesign) As cIProfile Implements cIOptionPrintAndExportArea.GetPrintOrExportProfile
            If iPrintOrExportProfileIndex >= 0 Then
                Select Case iPrintOrExportProfileType
                    Case 0
                        oPrintOrExportProfile = MyBase.Survey.PreviewProfiles(iPrintOrExportProfileIndex)
                    Case 1
                        oPrintOrExportProfile = MyBase.Survey.ExportProfiles(iPrintOrExportProfileIndex)
                End Select
                iPrintOrExportProfileIndex = -1
                iPrintOrExportProfileType = -1
            End If
            If IsNothing(oPrintOrExportProfile) Then
                Return MyBase.Survey.PreviewProfiles.ToList.FirstOrDefault(Function(item) item.Design = CurrentDesign.Type)
            Else
                Return oPrintOrExportProfile
            End If
        End Function

        Public Sub SetPrintOrExportProfile(Value As cIProfile) Implements cIOptionPrintAndExportArea.SetPrintOrExportProfile
            oPrintOrExportProfile = Value
        End Sub

        Public Property DrawPrintOrExportAreaDesignStyle As cIOptionPrintAndExportArea.DesignStyleEnum Implements cIOptionPrintAndExportArea.DrawPrintOrExportAreaDesignStyle
            Get
                Return iDrawPrintOrExportArea
            End Get
            Set(value As cIOptionPrintAndExportArea.DesignStyleEnum)
                iDrawPrintOrExportArea = value
            End Set
        End Property

        Public Property DrawPrintOrExportArea As Boolean Implements cIOptionPrintAndExportArea.DrawPrintOrExportArea
            Get
                Return bDrawPrintOrExportArea
            End Get
            Set(value As Boolean)
                bDrawPrintOrExportArea = value
            End Set
        End Property

        Private iUnselectedLevelDrawingMode As UnselectedLevelDrawingModeEnum

        Public Overrides Property UseDrawingZOrder As Boolean
            Get
                Return False
            End Get
            Set(value As Boolean)
            End Set
        End Property

        Public Property UnselectedLevelDrawingMode As UnselectedLevelDrawingModeEnum
            Get
                Return iUnselectedLevelDrawingMode
            End Get
            Set(value As UnselectedLevelDrawingModeEnum)
                iUnselectedLevelDrawingMode = value
            End Set
        End Property

        Public Property SplayEditMode As SplayEditModeEnum
            Get
                Return iSplayEditMode
            End Get
            Set(ByVal value As SplayEditModeEnum)
                iSplayEditMode = value
            End Set
        End Property

        Public Property DesignMode As DesignModeEnum
            Get
                Return iDesignMode
            End Get
            Set(ByVal value As DesignModeEnum)
                iDesignMode = value
            End Set
        End Property

        Public Overrides Function GetParent() As cIProfile
            If bDrawPrintOrExportArea Then
                Return oPrintOrExportProfile
            End If
        End Function

        Friend Overrides Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Call oXMLOptions.SetAttribute("unselectedleveldrawingmode", iUnselectedLevelDrawingMode.ToString("D"))
            Call oXMLOptions.SetAttribute("splayeditmode", iSplayEditMode.ToString("D"))
            If bDrawPrintOrExportArea Then Call oXMLOptions.SetAttribute("printorexportarea", "1")
            If iDrawPrintOrExportArea <> cIOptionPrintAndExportArea.DesignStyleEnum.None Then Call oXMLOptions.SetAttribute("peads", iDrawPrintOrExportArea.ToString("D"))
            If Not IsNothing(oPrintOrExportProfile) Then
                If TypeOf oPrintOrExportProfile Is cPreviewProfile Then
                    Call oXMLOptions.SetAttribute("printorexportprofiletype", "0")
                    Call oXMLOptions.SetAttribute("printorexportprofileindex", MyBase.Survey.PreviewProfiles.IndexOf(oPrintOrExportProfile))
                ElseIf TypeOf oPrintOrExportProfile Is cExportProfile Then
                    Call oXMLOptions.SetAttribute("printorexportprofiletype", "1")
                    Call oXMLOptions.SetAttribute("printorexportprofileindex", MyBase.Survey.ExportProfiles.IndexOf(oPrintOrExportProfile))
                End If
            End If
            If bDrawLinkedSurveys Then Call oXMLOptions.SetAttribute("drawlinkedsurveys", "1")
            Return oXMLOptions
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            Call MyBase.New(Survey, Name, cIOptions.ModeEnum.Design)
            iPrintOrExportProfileType = -1
            iPrintOrExportProfileIndex = -1
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            Call MyBase.New(Survey, Options, cIOptions.ModeEnum.Design)
            Call Import(Options)
        End Sub

        Public Overrides Property DrawSketches As Boolean
            Get
                Return True
            End Get
            Set(value As Boolean)
                'nothing...is readonly
            End Set
        End Property

        Public Overrides Property DrawImages As Boolean
            Get
                Return True
            End Get
            Set(value As Boolean)
                'nothing...is readonly
            End Set
        End Property

        Public Overrides Property DrawTranslation As Boolean
            Get
                Return False
            End Get
            Set(value As Boolean)
                'nulla...è in sola lettura
            End Set
        End Property

        Private bDrawLinkedSurveys As Boolean

        Public Property DrawLinkedSurveys As Boolean Implements cIOptionLinkedSurveys.DrawLinkedSurveys
            Get
                Return bDrawLinkedSurveys
            End Get
            Set(value As Boolean)
                bDrawLinkedSurveys = value
            End Set
        End Property

        Public Overrides Sub Import(Options As XmlElement)
            Call MyBase.Import(Options)

            iUnselectedLevelDrawingMode = modXML.GetAttributeValue(Options, "unselectedleveldrawingmode", UnselectedLevelDrawingModeEnum.Wireframe)
            iSplayEditMode = modXML.GetAttributeValue(Options, "splayeditmode", SplayEditModeEnum.All)
            bDrawPrintOrExportArea = modXML.GetAttributeValue(Options, "printorexportarea", 0)
            iDrawPrintOrExportArea = modXML.GetAttributeValue(Options, "peads", cIOptionPrintAndExportArea.DesignStyleEnum.None)
            iPrintOrExportProfileType = modXML.GetAttributeValue(Options, "printorexportprofiletype", -1)
            iPrintOrExportProfileIndex = modXML.GetAttributeValue(Options, "printorexportprofileindex", -1)
            '---------------------
            bDrawLinkedSurveys = modXML.GetAttributeValue(Options, "drawlinkedsurveys", 0)
            '---------------------
            CompassStyle = CompassStyleEnum.Simple
            ScaleStyle = ScaleStyleEnum.Simple
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
