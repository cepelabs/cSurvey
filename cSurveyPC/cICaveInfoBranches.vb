Imports cSurveyPC.cSurvey.Design

Namespace cSurvey
    Public Interface cICaveInfoBranches
        Inherits cISurfaceProfile

        Enum PathDirectionEnum
            ParentToChild = 0
            ChildToParent = 1
        End Enum

        ReadOnly Property Parent As cCaveInfoBranch
        ReadOnly Property Branches As cCaveInfoBranches

        ReadOnly Property Cave() As String
        ReadOnly Property Name() As String
        Property Description As String
        Property Color() As Color
        ReadOnly Property ColorIsValid As Boolean
        Sub ResetColor()
        Function GetColor(ByVal DefaultColor As Color) As Color
        Property Locked As Boolean
        Function GetLocked() As Boolean

        Delegate Function FormatDelegate(Text As String) As String
        Function GetPath(Direction As PathDirectionEnum, Optional FormatFunction As FormatDelegate = Nothing, Optional BranchSeparator As String = cCaveInfoBranches.sBranchSeparator, Optional NullName As String = "") As String
        Function Path() As String

        'extendstart management
        Property ExtendStart As String
        Function GetExtendStart() As String
        Property Priority As Integer?
        Function GetPriority() As Integer
        Function GetOrigin() As cICaveInfoBranches
        Function GetOriginColor(DefaultColor As Color) As Color
        Property ParentConnection As cConnectionDef
        Function GetParentConnection() As cConnectionDef
        Property Connection As cConnectionDef
        Function GetConnection() As cConnectionDef

        'graphical object with at least one point connected to shots in this cave/branch
        Function GetBindedItems() As List(Of cItem)
        Function GetBindedItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of cItem)

        'graphical object in this cave/branch
        Function GetItems() As List(Of cItem)
        Function GetItems(Design As cSurveyPC.cSurvey.Design.cIDesign.cDesignTypeEnum) As List(Of cItem)
        Function GetItemCount() As Integer

        'shots with this cave/branch
        Function GetSegments() As cISegmentCollection
        Function GetSegments(Mode As cOptions.HighlightModeEnum) As cISegmentCollection

        'information data
        Function GetSpeleometric() As Calculate.Plot.cSpeleometric

        'translations
        ReadOnly Property Translations As cTranslations
        Function GetTranslations() As cTranslations
    End Interface
End Namespace
