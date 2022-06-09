Imports System.Xml
Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Class cCaveInfoBranch
        Implements cICaveInfoBranches

        Private oSurvey As cSurvey
        Private sCave As String
        Private oParent As cCaveInfoBranch

        Private sName As String
        Private oColor As Color
        Private sDescription As String

        Private oTranslations As cTranslations
        Private iDrawingZOrder As Integer

        Private iSurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum

        Private oCaveInfo As cCaveInfo
        Private oBranches As cCaveInfoBranches

        Private bLocked As Boolean

        Private sExtendStart As String
        Private iPriority As Integer?
        Private oParentConnection As cConnectionDef
        Private oConnection As cConnectionDef

        Public Function GetLocked() As Boolean Implements cICaveInfoBranches.GetLocked
            If oParent Is Nothing Then
                Return oCaveInfo.GetLocked
            Else
                Return oParent.GetLocked()
            End If
        End Function

        Public Function GetParentConnection() As cConnectionDef Implements cICaveInfoBranches.GetParentConnection
            If IsNothing(oParentConnection) Then
                If oParent Is Nothing Then
                    Return oCaveInfo.GetParentConnection
                Else
                    Return oParent.GetParentConnection
                End If
            Else
                Return oParentConnection
            End If
        End Function

        Public Function GetConnection() As cConnectionDef Implements cICaveInfoBranches.GetConnection
            If IsNothing(oConnection) Then
                If oParent Is Nothing Then
                    Return oCaveInfo.GetConnection
                Else
                    Return oParent.GetConnection
                End If
            Else
                Return oConnection
            End If
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

        Public Property Locked As Boolean Implements cICaveInfoBranches.Locked
            Get
                Return bLocked
            End Get
            Set(value As Boolean)
                bLocked = value
            End Set
        End Property

        Public Function GetSpeleometric() As Calculate.Plot.cSpeleometric Implements cICaveInfoBranches.GetSpeleometric
            Return oSurvey.Calculate.Speleometrics(sCave, Path)
        End Function

        Friend Sub CopyFrom(Branch As cICaveInfoBranches)
            sDescription = Branch.Description
            sExtendStart = Branch.ExtendStart
            iPriority = Branch.Priority
            oColor = Branch.Color
            oTranslations = New cTranslations(Branch.Translations)
            Call oBranches.Clear()
            For Each oBranch As cCaveInfoBranch In Branch.Branches
                Dim oNewBranch As cCaveInfoBranch = oBranches.Add(oBranch.Name)
                Call oNewBranch.CopyFrom(oBranch)
            Next
            iSurfaceProfileShow = Branch.SurfaceProfileShow
        End Sub

        Friend Sub MergeWith(Branch As cICaveInfoBranches)
            For Each oBranch As cCaveInfoBranch In Branch.Branches
                If oBranches.Contains(oBranch.Name) Then
                    Call oBranches(oBranch.Name).MergeWith(oBranch)
                Else
                    Dim oNewBranch As cCaveInfoBranch = oBranches.Add(oBranch.Name)
                    Call oNewBranch.CopyFrom(oBranch)
                End If
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Cave As String, CaveInfo As cCaveInfo, Parent As cCaveInfoBranch, ByVal Name As String)
            oSurvey = Survey
            sCave = Cave
            oCaveInfo = CaveInfo
            oParent = Parent

            sName = Name
            sDescription = ""
            oColor = Drawing.Color.Transparent
            oTranslations = New cTranslations

            iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Default

            sExtendStart = ""
            iPriority = Nothing

            oBranches = New cCaveInfoBranches(oSurvey, Cave, oCaveInfo, Me)
        End Sub

        Public ReadOnly Property ColorIsValid As Boolean Implements cICaveInfoBranches.ColorIsValid
            Get
                Return (oColor <> Drawing.Color.Transparent) And (Not oColor.IsEmpty) And (Not oColor.ToArgb = 0)
            End Get
        End Property

        Public Sub ResetColor() Implements cICaveInfoBranches.ResetColor
            oColor = Drawing.Color.Transparent
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Cave As String, CaveInfo As cCaveInfo, Parent As cCaveInfoBranch, ByVal CaveInfoBranch As XmlElement)
            oSurvey = Survey
            sCave = Cave
            oCaveInfo = CaveInfo
            oParent = Parent
            sName = modXML.GetAttributeValue(CaveInfoBranch, "name", "")
            If sName = "" Then
                sName = String.Format(modMain.GetLocalizedString("caveinfobranch.textpart1"), Guid.NewGuid.ToString)
            End If
            sDescription = modXML.GetAttributeValue(CaveInfoBranch, "description", "")
            oColor = modXML.GetAttributeColor(CaveInfoBranch, "color", Drawing.Color.Transparent)
            Try
                If modXML.ChildElementExist(CaveInfoBranch, "translations") Then
                    oTranslations = New cTranslations(CaveInfoBranch.Item("translations"))
                Else
                    oTranslations = New cTranslations
                End If
            Catch
                oTranslations = New cTranslations
            End Try
            iDrawingZOrder = modXML.GetAttributeValue(CaveInfoBranch, "drawingzorder", 0)
            Try
                oBranches = New cCaveInfoBranches(oSurvey, Cave, oCaveInfo, Me, CaveInfoBranch.Item("branches"))
            Catch
                oBranches = New cCaveInfoBranches(oSurvey, Cave, oCaveInfo, Me)
            End Try
            iSurfaceProfileShow = modNumbers.StringToInteger(modXML.GetAttributeValue(CaveInfoBranch, "surfaceprofileshow", 0))
            bLocked = modXML.GetAttributeValue(CaveInfoBranch, "locked", 0)

            sExtendStart = modXML.GetAttributeValue(CaveInfoBranch, "extstart", "")
            iPriority = modXML.GetAttributeValue(CaveInfoBranch, "pty", Nothing)
            If modXML.ChildElementExist(CaveInfoBranch, "pcn") Then oParentConnection = New cConnectionDef(CaveInfoBranch("pcn"))
            If modXML.ChildElementExist(CaveInfoBranch, "cn") Then oConnection = New cConnectionDef(CaveInfoBranch("cn"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlBranch As XmlElement = Document.CreateElement("branch")
            Call oXmlBranch.SetAttribute("name", sName)
            If sDescription <> "" Then Call oXmlBranch.SetAttribute("description", sDescription)
            If oColor <> Drawing.Color.Transparent And Not oColor.IsEmpty Then Call oXmlBranch.SetAttribute("color", oColor.ToArgb)
            If Not oTranslations.IsEmpty Then Call oTranslations.SaveTo(File, Document, oXmlBranch)
            If iDrawingZOrder <> 0 Then Call oXmlBranch.SetAttribute("drawingzorder", iDrawingZOrder)
            If iSurfaceProfileShow <> cISurfaceProfile.SurfaceProfileShowEnum.Default Then Call oXmlBranch.SetAttribute("surfaceprofileshow", iSurfaceProfileShow.ToString("D"))
            If bLocked Then oXmlBranch.SetAttribute("locked", "1")
            If sExtendStart <> "" Then oXmlBranch.SetAttribute("extstart", sExtendStart)
            If iPriority.HasValue Then oXmlBranch.SetAttribute("pty", iPriority.Value)
            If Not IsNothing(oParentConnection) Then oParentConnection.SaveTo(File, Document, oXmlBranch, "pcn")
            If Not IsNothing(oConnection) Then oConnection.SaveTo(File, Document, oXmlBranch, "cn")
            Call oBranches.SaveTo(File, Document, oXmlBranch)
            Call Parent.AppendChild(oXmlBranch)
            Return oXmlBranch
        End Function

        Public Property DrawingZOrder As Integer
            Get
                Return iDrawingZOrder
            End Get
            Set(value As Integer)
                iDrawingZOrder = value
            End Set
        End Property

        Friend Sub SetCaveName(ByVal Name As String)
            sCave = Name
            Call oBranches.SetCave(Name)
        End Sub

        Friend Sub SetName(ByVal Name As String)
            sName = Name
        End Sub

        Public ReadOnly Property Name() As String Implements cICaveInfoBranches.Name
            Get
                Return sName
            End Get
        End Property

        Public Property Description As String Implements cICaveInfoBranches.Description
            Get
                Return sDescription
            End Get
            Set(value As String)
                sDescription = value
            End Set
        End Property

        Public ReadOnly Property Branches As cCaveInfoBranches Implements cICaveInfoBranches.Branches
            Get
                Return oBranches
            End Get
        End Property

        Public Function GetCave() As cCaveInfo Implements cICaveInfoBranches.GetCave
            Return oCaveInfo
        End Function

        Public ReadOnly Property Cave() As String Implements cICaveInfoBranches.Cave
            Get
                Return sCave
            End Get
        End Property

        Public Function GetPath(Direction As cICaveInfoBranches.PathDirectionEnum, Optional FormatFunction As cICaveInfoBranches.FormatDelegate = Nothing, Optional BranchSeparator As String = cCaveInfoBranches.sBranchSeparator, Optional NullName As String = "") As String Implements cICaveInfoBranches.GetPath
            If oParent Is Nothing Then
                If sName = "" AndAlso NullName <> "" Then
                    Return NullName
                Else
                    Return If(FormatFunction Is Nothing, sName, FormatFunction(sName))
                End If
            Else
                If Direction = cICaveInfoBranches.PathDirectionEnum.ParentToChild Then
                    Return oParent.GetPath(Direction, FormatFunction, BranchSeparator) & BranchSeparator & If(sName = "" AndAlso NullName <> "", NullName, If(FormatFunction Is Nothing, sName, FormatFunction(sName)))
                Else
                    Return If(sName = "" AndAlso NullName <> "", NullName, If(FormatFunction Is Nothing, sName, FormatFunction(sName))) & BranchSeparator & oParent.GetPath(Direction, FormatFunction, BranchSeparator)
                End If
            End If
        End Function

        Public Function Path() As String Implements cICaveInfoBranches.Path
            If oParent Is Nothing Then
                Return sName
            Else
                Return oParent.Path() & cCaveInfoBranches.sBranchSeparator & sName
            End If
        End Function

        Public Function GetItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of cItem) Implements cICaveInfoBranches.GetItems
            Dim sCave As String = Cave.ToLower
            Dim sBranch As String = Path.ToLower
            Dim oResult As List(Of cItem) = New List(Of cItem)
            If Design = cIDesign.cDesignTypeEnum.Plan Then
                For Each oItem As cItem In oSurvey.Plan.GetAllItems
                    If oItem.Cave.ToLower = sCave And oItem.Branch.ToLower = sBranch Then
                        Call oResult.Add(oItem)
                    End If
                Next
            End If
            If Design = cIDesign.cDesignTypeEnum.Profile Then
                For Each oItem As cItem In oSurvey.Profile.GetAllItems
                    If oItem.Cave.ToLower = sCave And oItem.Branch.ToLower = sBranch Then
                        Call oResult.Add(oItem)
                    End If
                Next
            End If
            Return oResult
        End Function

        Public Function GetItems() As List(Of cItem) Implements cICaveInfoBranches.GetItems
            Dim sCave As String = Cave.ToLower
            Dim sBranch As String = Path.ToLower
            Dim oResult As List(Of cItem) = New List(Of cItem)
            For Each oItem As cItem In oSurvey.Plan.GetAllItems
                If oItem.Cave.ToLower = sCave And oItem.Branch.ToLower = sBranch Then
                    Call oResult.Add(oItem)
                End If
            Next
            For Each oItem As cItem In oSurvey.Profile.GetAllItems
                If oItem.Cave.ToLower = sCave And oItem.Branch.ToLower = sBranch Then
                    Call oResult.Add(oItem)
                End If
            Next
            Return oResult
        End Function

        Public Function GetBindedItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of cItem) Implements cICaveInfoBranches.GetBindedItems
            Return GetSegments.GetBindedItems(Design)
        End Function

        Public Function GetBindedItems() As List(Of cItem) Implements cICaveInfoBranches.GetBindedItems
            Return GetSegments.GetBindedItems
        End Function

        Public Function GetSegments(Mode As cOptionsDesign.HighlightModeEnum) As cISegmentCollection Implements cICaveInfoBranches.GetSegments
            Dim sCave As String = Cave.ToLower
            Dim sBranch As String = Path.ToLower
            Dim oResult As cSegmentCollection = New cSegmentCollection(oSurvey)
            For Each oSegment As cSegment In oSurvey.Segments
                Select Case Mode
                    Case cOptionsDesign.HighlightModeEnum.Default
                        'if is a cave, get all shot for this cave
                        'if is a branch, get all shot for this cave/branch but no children
                        If oSegment.Cave.ToLower = sCave OrElse (sBranch <> "" AndAlso oSegment.Branch.ToLower = sBranch) Then
                            Call oResult.Append(oSegment)
                        End If
                    Case cOptionsDesign.HighlightModeEnum.Hierarchic
                        'if is a cave, get all shot for this cave
                        'if is a branch, get all shot for this cave/branch and all children branch...
                        If oSegment.Cave.ToLower = sCave AndAlso (oSegment.Branch.ToLower = sBranch OrElse oSegment.Branch.ToLower.StartsWith(sBranch & cCaveInfoBranches.sBranchSeparator)) Then
                            Call oResult.Append(oSegment)
                        End If
                    Case cOptionsDesign.HighlightModeEnum.ExactMatch
                        'always check cave/branch
                        If oSegment.Cave.ToLower = sCave AndAlso (oSegment.Branch.ToLower = sBranch) Then
                            Call oResult.Append(oSegment)
                        End If
                End Select
            Next
            Return oResult
        End Function

        Public Function GetSegments() As cISegmentCollection Implements cICaveInfoBranches.GetSegments
            Dim sCave As String = Cave.ToLower
            Dim sBranch As String = Path.ToLower
            Dim oResult As cSegmentCollection = New cSegmentCollection(oSurvey)
            For Each oSegment As cSegment In oSurvey.Segments
                If oSegment.Cave.ToLower = sCave AndAlso (oSegment.Branch.ToLower = sBranch OrElse oSegment.Branch.ToLower.StartsWith(sBranch & cCaveInfoBranches.sBranchSeparator)) Then
                    Call oResult.Append(oSegment)
                End If
            Next
            Return oResult
        End Function

        'Public Function GetSegmentCount() As Integer Implements cICaveInfoBranches.GetSegmentCount
        '    Dim sCave As String = Cave.ToLower
        '    Dim sBranch As String = Path.ToLower
        '    Dim iCount As Integer = 0
        '    For Each oSegment As cSegment In oSurvey.Segments
        '        If oSegment.Cave.ToLower = sCave AndAlso (oSegment.Branch.ToLower = sBranch OrElse oSegment.Branch.ToLower.StartsWith(sBranch & cCaveInfoBranches.sBranchSeparator)) Then
        '            iCount += 1
        '        End If
        '    Next
        '    Return iCount
        'End Function

        Public Function GetItemCount() As Integer Implements cICaveInfoBranches.GetItemCount
            Dim sCave As String = Cave.ToLower
            Dim sBranch As String = Path.ToLower
            Dim iCount As Integer = 0
            For Each oItem As cItem In oSurvey.Plan.GetAllItems
                If oItem.Cave.ToLower = sCave And oItem.Branch.ToLower = sBranch Then
                    iCount += 1
                End If
            Next
            For Each oItem As cItem In oSurvey.Profile.GetAllItems
                If oItem.Cave.ToLower = sCave And oItem.Branch.ToLower = sBranch Then
                    iCount += 1
                End If
            Next
            Return iCount
        End Function

        Public Property Color() As Color Implements cICaveInfoBranches.Color
            Get
                Return oColor
            End Get
            Set(ByVal value As Color)
                oColor = value
            End Set
        End Property

        Public ReadOnly Property ToHTMLString() As String
            Get
                Return "<b><backcolor=" & ColorTranslator.ToHtml(GetColor(Color.Gray)) & ">  </backcolor></b>  " & Path()
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Path()
        End Function

        Public ReadOnly Property Translations As cTranslations Implements cICaveInfoBranches.Translations
            Get
                Return oTranslations
            End Get
        End Property

        Public Function GetTranslations() As cTranslations Implements cICaveInfoBranches.GetTranslations
            If oParent Is Nothing Then
                Return oTranslations.Clone
            Else
                Return oTranslations.Clone + oParent.GetTranslations
            End If
        End Function

        Public ReadOnly Property Parent As cCaveInfoBranch Implements cICaveInfoBranches.Parent
            Get
                Return oParent
            End Get
        End Property

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
                If oParent Is Nothing Then
                    Return oCaveInfo.GetOrigin
                Else
                    Return oParent.GetOrigin
                End If
            Else
                Return Me
            End If
        End Function

        Public Function GetPriority() As Integer Implements cICaveInfoBranches.GetPriority
            Dim iReturnedPriorty As Integer? = iPriority
            If iReturnedPriorty.HasValue Then
                Return iReturnedPriorty
            Else
                If oParent Is Nothing Then
                    iReturnedPriorty = oCaveInfo.GetPriority
                Else
                    iReturnedPriorty = oParent.GetPriority
                End If
                Return iReturnedPriorty
            End If
        End Function

        Public Function GetExtendStart() As String Implements cICaveInfoBranches.GetExtendStart
            Dim sReturnedExtendStart As String = sExtendStart
            If sReturnedExtendStart = "" Then
                If oParent Is Nothing Then
                    sReturnedExtendStart = oCaveInfo.GetExtendStart
                Else
                    sReturnedExtendStart = oParent.GetExtendStart
                End If
                Return sReturnedExtendStart
            Else
                Return sReturnedExtendStart
            End If
        End Function

        Public Function GetColor(ByVal DefaultColor As Color) As Color Implements cICaveInfoBranches.GetColor
            Dim oReturnedColor As Color = oColor
            Try
                If modPaint.IsNullColor(oReturnedColor) Then
                    If oParent Is Nothing Then
                        If oCaveInfo Is Nothing Then
                            Return DefaultColor
                        Else
                            oReturnedColor = oCaveInfo.GetColor(DefaultColor)
                        End If
                    Else
                        oReturnedColor = oParent.GetColor(DefaultColor)
                    End If
                    If modPaint.IsNullColor(oReturnedColor) Then
                        Return DefaultColor
                    Else
                        Return modPaint.DarkColor(oReturnedColor, 0.2)
                    End If
                Else
                    Return oReturnedColor
                End If
            Catch
                Return DefaultColor
            End Try
        End Function

        Public Property SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum Implements cICaveInfoBranches.SurfaceProfileShow
            Get
                Return iSurfaceProfileShow
            End Get
            Set(value As cISurfaceProfile.SurfaceProfileShowEnum)
                iSurfaceProfileShow = value
            End Set
        End Property

        Public Function GetSurfaceProfileShow() As Boolean Implements cICaveInfoBranches.GetSurfaceProfileShow
            If iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Default Then
                If oParent Is Nothing Then
                    Return oCaveInfo.GetSurfaceProfileShow
                Else
                    Return oParent.GetSurfaceProfileShow
                End If
            Else
                Return iSurfaceProfileShow = cISurfaceProfile.SurfaceProfileShowEnum.Visible
            End If
        End Function

        Public Function GetRoot() As cCaveInfo Implements cICaveInfoBranches.GetRoot
            Return oCaveInfo
        End Function

        Friend Shared Function EditToString(CaveEdit As cCaveInfoBranch) As String
            If CaveEdit Is Nothing Then
                Return ""
            Else
                Return CaveEdit.Path
            End If
        End Function
    End Class
End Namespace