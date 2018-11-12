Imports System.Xml
Imports cSurveyPC.cSurvey.cCaveInfoBranch
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Class cCaveInfo
        Implements cICaveInfoBranches
        Implements cICaveInfo

        Private oSurvey As cSurvey

        Private sID As String
        Private sName As String
        Private sDescription As String

        Private oColor As Color

        Private oBranches As cCaveInfoBranches

        Private oTranslations As cTranslations
        Private iDrawingZOrder As Integer

        Private iSurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum

        Private bLocked As Boolean

        Private sExtendStart As String
        Private iPriority As Integer?
        Private oParentConnection As cConnectionDef
        Private oConnection As cConnectionDef

        Public Function GetOriginColor(DefaultColor As Color) As Color Implements cICaveInfoBranches.GetOriginColor
            Dim oOrigin As cICaveInfoBranches = GetOrigin()
            If IsNothing(oOrigin) Then
                Return DefaultColor
            Else
                Dim oColor As Color = oOrigin.GetColor(DefaultColor)
                If modPaint.IsNullColor(oColor) Then
                    Return DefaultColor
                Else
                    Return oColor
                End If
            End If
        End Function

        Public Function GetOrigin() As cICaveInfoBranches Implements cICaveInfoBranches.GetOrigin
            Dim sReturnedExtendStart As String = sExtendStart
            If sReturnedExtendStart = "" Then
                Return Nothing
            Else
                Return Me
            End If
        End Function

        Public Function GetParentConnection() As cConnectionDef Implements cICaveInfoBranches.GetParentConnection
            Return oParentConnection
        End Function

        Public Function GetConnection() As cConnectionDef Implements cICaveInfoBranches.GetConnection
            Return oConnection
        End Function

        Public Property Connection As cConnectionDef Implements cICaveInfoBranches.Connection
            Get
                Return oConnection
            End Get
            Set(value As cConnectionDef)
                If value <> oConnection Then
                    oConnection = value
                    Call oSurvey.Invalidate(Calculate.cCalculate.InvalidateEnum.PartialCalculate)
                End If
            End Set
        End Property

        Public Property ParentConnection As cConnectionDef Implements cICaveInfoBranches.ParentConnection
            Get
                Return oParentConnection
            End Get
            Set(value As cConnectionDef)
                If value <> oParentConnection Then
                    oParentConnection = value
                    Call oSurvey.Invalidate(Calculate.cCalculate.InvalidateEnum.PartialCalculate)
                End If
            End Set
        End Property

        Public Property Priority As Integer? Implements cICaveInfoBranches.Priority
            Get
                Return iPriority
            End Get
            Set(value As Integer?)
                If Not value.Equals(iPriority) Then
                    iPriority = value
                    Call oSurvey.Invalidate(Calculate.cCalculate.InvalidateEnum.PartialCalculate)
                End If
            End Set
        End Property

        Public Property ExtendStart As String Implements cICaveInfoBranches.ExtendStart
            Get
                Return sExtendStart
            End Get
            Set(value As String)
                If value <> sExtendStart Then
                    sExtendStart = value
                    Call oSurvey.Invalidate(Calculate.cCalculate.InvalidateEnum.PartialCalculate)
                End If
            End Set
        End Property

        Public Function GetLocked() As Boolean Implements cICaveInfoBranches.GetLocked
            Return bLocked
        End Function

        Public Property Locked As Boolean Implements cICaveInfoBranches.Locked
            Get
                Return bLocked
            End Get
            Set(value As Boolean)
                bLocked = value
            End Set
        End Property

        Friend Sub CopyFrom(CaveInfo As cCaveInfo)
            sID = CaveInfo.sID
            sDescription = CaveInfo.sDescription
            sExtendStart = CaveInfo.sExtendStart
            oColor = CaveInfo.oColor
            oTranslations = New cTranslations(CaveInfo.oTranslations)
            iDrawingZOrder = CaveInfo.iDrawingZOrder
            sExtendStart = CaveInfo.sExtendStart
            iPriority = CaveInfo.iPriority
            Call oBranches.Clear()
            For Each oBranch As cCaveInfoBranch In CaveInfo.oBranches
                Dim oNewBranch As cCaveInfoBranch = oBranches.Add(oBranch.Name)
                Call oNewBranch.CopyFrom(oBranch)
            Next
            iSurfaceProfileShow = CaveInfo.iSurfaceProfileShow
            bLocked = CaveInfo.bLocked
        End Sub

        Friend Sub MergeWith(CaveInfo As cCaveInfo)
            If sID = "" Then sID = CaveInfo.sID
            If sDescription = "" Then sDescription = CaveInfo.sDescription
            If sExtendStart = "" Then sExtendStart = CaveInfo.sExtendStart
            If Not iPriority.HasValue Then iPriority = CaveInfo.iPriority
            For Each oBranch As cCaveInfoBranch In CaveInfo.oBranches
                If oBranches.Contains(oBranch.Name) Then
                    Call oBranches(oBranch.Name).MergeWith(oBranch)
                Else
                    Dim oNewBranch As cCaveInfoBranch = oBranches.Add(oBranch.Name)
                    Call oNewBranch.CopyFrom(oBranch)
                End If
            Next
        End Sub

        Public Property DrawingZOrder As Integer
            Get
                Return iDrawingZOrder
            End Get
            Set(value As Integer)
                iDrawingZOrder = value
            End Set
        End Property

        Public ReadOnly Property Parent As cCaveInfoBranch Implements cICaveInfoBranches.Parent
            Get
                Return Nothing
            End Get
        End Property

        Public Function GetPath(Direction As cICaveInfoBranches.PathDirectionEnum, Optional FormatFunction As cICaveInfoBranches.FormatDelegate = Nothing, Optional BranchSeparator As String = cCaveInfoBranches.sBranchSeparator, Optional NullName As String = "") As String Implements cICaveInfoBranches.GetPath
            If sName = "" AndAlso NullName <> "" Then
                Return NullName
            Else
                Return If(FormatFunction Is Nothing, sName, FormatFunction(sName))
            End If
        End Function

        Public Function Path() As String Implements cICaveInfoBranches.path
            Return sName
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal Name As String)
            oSurvey = Survey
            sName = Name
            sID = ""
            sDescription = ""
            oColor = Drawing.Color.Transparent

            oBranches = New cCaveInfoBranches(oSurvey, Name, Me, Nothing)
            oTranslations = New cTranslations

            iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Default

            sExtendStart = ""
            iPriority = Nothing
        End Sub

        Friend Sub SetName(ByVal Name As String)
            sName = Name
            Call oBranches.SetCave(sName)
        End Sub

        Public ReadOnly Property Translations As cTranslations Implements cICaveInfoBranches.Translations
            Get
                Return oTranslations
            End Get
        End Property

        Public Function GetTranslations() As cTranslations Implements cICaveInfoBranches.GetTranslations
            Return oTranslations.Clone
        End Function

        Public ReadOnly Property Branches As cCaveInfoBranches Implements cICaveInfoBranches.Branches
            Get
                Return oBranches
            End Get
        End Property

        Public ReadOnly Property Name() As String Implements cICaveInfo.Name, cICaveInfoBranches.Name
            Get
                Return sName
            End Get
        End Property

        Public Property Description As String Implements cICaveInfo.Description, cICaveInfoBranches.Description
            Get
                Return sDescription
            End Get
            Set(value As String)
                sDescription = value
            End Set
        End Property

        Public Property ID() As String Implements cICaveInfo.ID
            Get
                Return sID
            End Get
            Set(ByVal value As String)
                sID = value
            End Set
        End Property

        Public Function GetColor(ByVal DefaultColor As Color) As Color Implements cICaveInfoBranches.GetColor
            Dim oReturnedColor As Color = oColor
            If modPaint.IsNullColor(oReturnedColor) Then
                oReturnedColor = DefaultColor
            End If
            Return oReturnedColor
        End Function

        Public Function GetPriority() As Integer Implements cICaveInfoBranches.GetPriority
            Return iPriority.GetValueOrDefault(Integer.MinValue)
        End Function

        Public Function GetExtendStart() As String Implements cICaveInfoBranches.GetExtendStart
            Dim sReturnedExtendStart As String = "" & sExtendStart
            If sReturnedExtendStart = "" Then
                sReturnedExtendStart = oSurvey.Properties.Origin
            End If
            Return sReturnedExtendStart
        End Function

        Public Property Color() As Color Implements cICaveInfoBranches.Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                oColor = value
            End Set
        End Property

        Public ReadOnly Property ColorIsValid As Boolean Implements cICaveInfoBranches.ColorIsValid
            Get
                Return (oColor <> Drawing.Color.Transparent) And (Not oColor.IsEmpty) And (Not oColor.ToArgb = 0)
            End Get
        End Property

        Public Sub ResetColor() Implements cICaveInfoBranches.ResetColor
            oColor = Drawing.Color.Transparent
        End Sub

        Public Function GetBindedItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of cItem) Implements cICaveInfoBranches.GetBindedItems
            Return GetSegments.GetBindedItems(Design)
        End Function

        Public Function GetBindedItems() As List(Of cItem) Implements cICaveInfoBranches.GetBindedItems
            Return GetSegments.GetBindedItems
        End Function

        Public Function GetSegments(Mode As cOptions.HighlightModeEnum) As cISegmentCollection Implements cICaveInfoBranches.GetSegments
            Dim sCave As String = Cave.ToLower
            Dim oResult As cSegmentCollection = New cSegmentCollection(oSurvey)
            For Each oSegment As cSegment In oSurvey.Segments
                Select Case Mode
                    Case cOptions.HighlightModeEnum.Default, cOptions.HighlightModeEnum.Hierarchic
                        'see comment in ccaveinfobranch
                        If oSegment.Cave.ToLower = sCave Then
                            Call oResult.Append(oSegment)
                        End If
                    Case cOptions.HighlightModeEnum.ExactMatch
                        'always check cave/branch
                        If oSegment.Cave.ToLower = sCave AndAlso oSegment.Branch = "" Then
                            Call oResult.Append(oSegment)
                        End If
                End Select
            Next
            Return oResult
        End Function

        Public Function GetSegments() As cISegmentCollection Implements cICaveInfoBranches.GetSegments
            Dim sCave As String = Name.ToLower
            Dim oResult As cSegmentCollection = New cSegmentCollection(oSurvey)
            For Each oSegment As cSegment In oSurvey.Segments
                If oSegment.Cave.ToLower = sCave Then
                    Call oResult.Append(oSegment)
                End If
            Next
            Return oResult
        End Function

        'Public Function GetSegmentCount() As Integer Implements cICaveInfoBranches.GetSegmentCount
        '    Return GetSegments.Count
        'End Function

        Public Function GetItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of cItem) Implements cICaveInfoBranches.GetItems
            Dim sCave As String = Name.ToLower
            Dim oResult As List(Of cItem) = New List(Of cItem)
            If Design = cIDesign.cDesignTypeEnum.Plan Then
                For Each oItem As cItem In oSurvey.Plan.GetAllItems
                    If oItem.Cave.ToLower = sCave Then
                        Call oResult.Add(oItem)
                    End If
                Next
            End If
            If Design = cIDesign.cDesignTypeEnum.Profile Then
                For Each oItem As cItem In oSurvey.Profile.GetAllItems
                    If oItem.Cave.ToLower = sCave Then
                        Call oResult.Add(oItem)
                    End If
                Next
            End If
            Return oResult
        End Function

        Public Function GetItems() As List(Of cItem) Implements cICaveInfoBranches.GetItems
            Dim sCave As String = Name.ToLower
            Dim oResult As List(Of cItem) = New List(Of cItem)
            For Each oItem As cItem In oSurvey.Plan.GetAllItems
                If oItem.Cave.ToLower = sCave Then
                    Call oResult.Add(oItem)
                End If
            Next
            For Each oItem As cItem In oSurvey.Profile.GetAllItems
                If oItem.Cave.ToLower = sCave Then
                    Call oResult.Add(oItem)
                End If
            Next
            Return oResult
        End Function

        Public Function GetItemCount() As Integer Implements cICaveInfoBranches.GetItemCount
            Dim sCave As String = Name.ToLower
            Dim iCount As Integer = 0
            For Each oItem As cItem In oSurvey.Plan.GetAllItems
                If oItem.Cave.ToLower = sCave Then
                    iCount += 1
                End If
            Next
            For Each oItem As cItem In oSurvey.Profile.GetAllItems
                If oItem.Cave.ToLower = sCave Then
                    iCount += 1
                End If
            Next
            Return iCount
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal CaveInfo As XmlElement)
            oSurvey = Survey
            sID = modXML.GetAttributeValue(CaveInfo, "id", "")
            sName = modXML.GetAttributeValue(CaveInfo, "name", "")
            sDescription = modXML.GetAttributeValue(CaveInfo, "description", "")
            oColor = modXML.GetAttributeColor(CaveInfo, "color", Drawing.Color.Transparent)
            Try
                If modXML.ChildElementExist(CaveInfo, "branches") Then
                    oBranches = New cCaveInfoBranches(oSurvey, sName, Me, Nothing, CaveInfo.Item("branches"))
                Else
                    oBranches = New cCaveInfoBranches(oSurvey, sName, Me, Nothing)
                End If
            Catch
                oBranches = New cCaveInfoBranches(oSurvey, sName, Me, Nothing)
            End Try
            Try
                If modXML.ChildElementExist(CaveInfo, "translations") Then
                    oTranslations = New cTranslations(CaveInfo.Item("translations"))
                Else
                    oTranslations = New cTranslations
                End If
            Catch
                oTranslations = New cTranslations
            End Try
            iSurfaceProfileShow = modNumbers.StringToInteger(modXML.GetAttributeValue(CaveInfo, "surfaceprofileshow", 0))
            iDrawingZOrder = modXML.GetAttributeValue(CaveInfo, "drawingzorder", 0)
            bLocked = modXML.GetAttributeValue(CaveInfo, "locked", 0)

            sExtendStart = modXML.GetAttributeValue(CaveInfo, "extstart", "")
            iPriority = modXML.GetAttributeValue(CaveInfo, "pty", Nothing)
            If modXML.ChildElementExist(CaveInfo, "pcn") Then oParentConnection = New cConnectionDef(CaveInfo("pcn"))
            If modXML.ChildElementExist(CaveInfo, "cn") Then oConnection = New cConnectionDef(CaveInfo("cn"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement)
            Dim oXmlCaveInfo As XmlElement = Document.CreateElement("caveinfo")
            Call oXmlCaveInfo.SetAttribute("id", sID)
            Call oXmlCaveInfo.SetAttribute("name", sName)
            If sDescription <> "" Then Call oXmlCaveInfo.SetAttribute("description", sDescription)
            If oColor <> Drawing.Color.Transparent And Not oColor.IsEmpty Then Call oXmlCaveInfo.SetAttribute("color", oColor.ToArgb)
            If Not oTranslations.IsEmpty Then Call oTranslations.SaveTo(File, Document, oXmlCaveInfo)
            If iDrawingZOrder <> 0 Then Call oXmlCaveInfo.SetAttribute("drawingzorder", iDrawingZOrder)
            If iSurfaceProfileShow <> cISurfaceProfile.SurfaceProfileShowEnum.Default Then Call oXmlCaveInfo.SetAttribute("surfaceprofileshow", iSurfaceProfileShow.ToString("D"))
            If bLocked Then oXmlCaveInfo.SetAttribute("locked", "1")
            If sExtendStart <> "" Then oXmlCaveInfo.SetAttribute("extstart", sExtendStart)
            If iPriority.HasValue Then oXmlCaveInfo.SetAttribute("pty", iPriority.Value)
            If Not IsNothing(oParentConnection) Then oParentConnection.SaveTo(File, Document, oXmlCaveInfo, "pcn")
            If Not IsNothing(oConnection) Then oConnection.SaveTo(File, Document, oXmlCaveInfo, "cn")
            Call oBranches.SaveTo(File, Document, oXmlCaveInfo)
            Call Parent.AppendChild(oXmlCaveInfo)
            Return oXmlCaveInfo
        End Function

        Public Overrides Function ToString() As String
            Return sName
        End Function

        Public Property SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum Implements cICaveInfoBranches.SurfaceProfileShow
            Get
                Return iSurfaceProfileShow
            End Get
            Set(value As cISurfaceProfile.SurfaceProfileShowEnum)
                iSurfaceProfileShow = value
            End Set
        End Property

        Public ReadOnly Property Cave As String Implements cICaveInfoBranches.Cave
            Get
                Return sName
            End Get
        End Property

        Public Function GetSpeleometric() As Calculate.Plot.cSpeleometric Implements cICaveInfoBranches.GetSpeleometric
            Return oSurvey.Calculate.Speleometrics(sName, "")
        End Function

        Public Function GetSurfaceProfileShow() As Boolean Implements cICaveInfoBranches.GetSurfaceProfileShow
            If iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Default Then
                Return oSurvey.Properties.SurfaceProfileShow
            Else
                Return iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Visible
            End If
        End Function
    End Class
End Namespace