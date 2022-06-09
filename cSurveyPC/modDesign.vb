Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Module modDesign

    Public Function GetIfItemMustBeDrawedByHiddenFlag(ByVal PaintOptions As cOptionsCenterline, ByVal Item As cItem) As Boolean
        Dim oProfile As cIProfile = PaintOptions.GetParent
        If IsNothing(oProfile) OrElse (Not IsNothing(oProfile) AndAlso oProfile.Items.IsVisible(Item, True)) Then
            If PaintOptions.GetCurrentItems.IsVisible(Item, PaintOptions.GetCurrentCategories(Item.Category)) Then
                If (PaintOptions.DesignAffinity = cOptionsCenterline.DesignAffinityEnum.All) OrElse (PaintOptions.DesignAffinity = cOptionsCenterline.DesignAffinityEnum.Design AndAlso Item.DesignAffinity = cItem.DesignAffinityEnum.Design) OrElse (PaintOptions.DesignAffinity = cOptionsCenterline.DesignAffinityEnum.Extra AndAlso Item.DesignAffinity = cItem.DesignAffinityEnum.Extra) Then
                    If PaintOptions.IsDesign Then
                        'in design layer visibility is taken from current survey...
                        Dim oLayer As cLayer = If(Item.Design.Type = cIDesign.cDesignTypeEnum.Plan, PaintOptions.Survey.Plan, PaintOptions.Survey.Profile).layers(Item.Layer.Type)
                        If oLayer.HiddenInDesign Then
                            Return False
                        Else
                            If Item.HiddenInDesign Then
                                Return False
                            Else
                                Return Not Item.FilteredInDesign And Not Item.HavePaintProblem
                            End If
                        End If
                    Else
                        If Item.Layer.HiddenInPreview Then
                            Return False
                        Else
                            If Item.HiddenInPreview Then
                                Return False
                            Else
                                Return True
                            End If
                        End If
                    End If
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function GetIfSegmentMustBeDrawedByHiddenFlag(ByVal PaintOptions As cOptions, ByVal Segment As cSegment) As Boolean
        Return True
    End Function

    Public Function GetIfItemMustBeDrawedByCaveAndBranch(ByVal PaintOptions As cOptionsCenterline, ByVal Item As cItem, ByVal CurrentCave As String, ByVal CurrentBranch As String) As Boolean
        If IsNothing(Item) Then
            Return False
        Else
            If PaintOptions.HighlightCurrentCave Then
                'solo nel caso in cui ho chiesto di evidenziare la grotta/ramo attivo...
                'If PaintOptions.CurrentRule.Categories(Item.Category) Then
                Select Case PaintOptions.HighlightMode
                    Case cOptionsCenterline.HighlightModeEnum.Default
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra SOLO quel ramo
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Item.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Item.Cave.ToLower = CurrentCave.ToLower And Item.Branch.ToLower = CurrentBranch.ToLower
                        End If
                    Case cOptionsCenterline.HighlightModeEnum.Hierarchic
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra gli oggetti di quel ramo e tutti gli oggetti figli di quel ramo 
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Item.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Item.Cave.ToLower = CurrentCave.ToLower And (Item.Branch & cCaveInfoBranches.sBranchSeparator).ToLower.StartsWith(CurrentBranch.ToLower)
                        End If
                    Case cOptionsCenterline.HighlightModeEnum.ExactMatch
                        'confronta SEMPRE grotta/ramo richiesti con quelli dell'oggetto...utile per trovare oggetti orfani o oggetti ancora non collegati...
                        Return Item.Cave.ToLower = CurrentCave.ToLower And Item.Branch.ToLower = CurrentBranch.ToLower
                End Select
                'Else
                '    Return False
                'End If
            Else
                'Return PaintOptions.CurrentRule.Categories(Item.Category)
                Return True
            End If
        End If
    End Function

    Public Function GetIfSegmentMustBeDrawedByCaveAndBranch(ByVal PaintOptions As cOptionsCenterline, ByVal Segment As cSegment, ByVal CurrentCave As String, ByVal CurrentBranch As String) As Boolean
        If IsNothing(Segment) Then
            Return False
        Else
            If PaintOptions.HighlightCurrentCave Then
                'solo nel caso in cui ho chiesto di evidenziare la grotta/ramo attivo...
                Select Case PaintOptions.HighlightMode
                    Case cOptionsCenterline.HighlightModeEnum.Default
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra SOLO quel ramo
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Segment.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Segment.Cave.ToLower = CurrentCave.ToLower And Segment.Branch.ToLower = CurrentBranch.ToLower
                        End If
                    Case cOptionsCenterline.HighlightModeEnum.Hierarchic
                        'se impostata solo la grotta mostra tutti gli oggetti di quella grotta
                        'se impostata per ramo mostra gli oggetti di quel ramo e tutti gli oggetti figli di quel ramo 
                        If CurrentCave = "" And CurrentBranch = "" Then
                            Return True
                        ElseIf CurrentCave <> "" And CurrentBranch = "" Then
                            Return Segment.Cave.ToLower = CurrentCave.ToLower
                        Else
                            Return Segment.Cave.ToLower = CurrentCave.ToLower And (Segment.Branch & cCaveInfoBranches.sBranchSeparator).ToLower.StartsWith(CurrentBranch.ToLower)
                        End If
                    Case cOptionsCenterline.HighlightModeEnum.ExactMatch
                        'confronta SEMPRE grotta/ramo richiesti con quelli dell'oggetto...utile per trovare oggetti orfani o oggetti ancora non collegati...
                        Return Segment.Cave.ToLower = CurrentCave.ToLower And Segment.Branch.ToLower = CurrentBranch.ToLower
                End Select
            Else
                Return True
            End If
        End If
    End Function

End Module
