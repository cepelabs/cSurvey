Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Scale
    ' public class cScaleRange
    'Private oSurvey As cSurvey
    'Private iMinScale As Nullable(Of Integer)
    'Private iMaxScale As Nullable(Of Integer)

    'Public Sub SetScaleRange(ByVal Min As Nullable(Of Integer), ByVal Max As Nullable(Of Integer))
    '    iMinScale = Min
    '    iMaxScale = Max
    'End Sub

    'Public Function IsInScaleRange(ByVal Scale As Integer) As Boolean
    '    Dim sMin As Integer
    '    If iMinScale.HasValue Then
    '        sMin = iMinScale.Value
    '    Else
    '        'sMin = oSurvey.scalerules(iCategory).min
    '    End If
    '    Dim sMax As Integer
    '    If iMaxScale.HasValue Then
    '        sMax = iMaxScale.Value
    '    Else
    '        'sMax = oSurvey.scalerules(iCategory).max
    '    End If
    '    Return Scale >= sMin And Scale <= sMax
    'End Function

    'Friend Sub New(ByVal Survey As cSurvey, ByVal Min As Nullable(Of Integer), ByVal Max As Nullable(Of Integer))
    '    oSurvey = Survey
    '    iMinScale = Min
    '    iMaxScale = Max
    'End Sub

    'Friend Sub New(ByVal Survey As cSurvey, ByVal ScaleRange As XmlElement)
    '    oSurvey = Survey
    '    Try : iMinScale = ScaleRange.GetAttribute("min") : Catch : End Try
    '    Try : iMaxScale = ScaleRange.GetAttribute("max") : Catch : End Try
    'End Sub
    'End Class

    Public Class cScaleRules
        Implements IEnumerable

        Private oSurvey As cSurvey

        Private oDefaultItem As cDefaultScaleRule
        Private oItems As SortedDictionary(Of Integer, cScaleRule)

        'Private iCurrentScale As Integer
        'Private oCurrentRule As cIScaleRule

        Public Sub Clear()
            Call oItems.Clear()
            'oCurrentRule = oDefaultItem
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oDefaultItem = New cDefaultScaleRule(oSurvey)
            oItems = New SortedDictionary(Of Integer, cScaleRule)
            'iCurrentScale = iDefaultDesignScale
            'oCurrentRule = Nothing
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal ScaleRules As XmlElement)
            oSurvey = Survey
            oDefaultItem = New cDefaultScaleRule(oSurvey)
            oItems = New SortedDictionary(Of Integer, cScaleRule)
            For Each oXMLItem As XmlElement In ScaleRules.ChildNodes
                Dim oItem As cScaleRule = New cScaleRule(oSurvey, oXMLItem)
                Call oItems.Add(oItem.Scale, oItem)
            Next
        End Sub

        Public Function Contains(ByVal ScaleRule As cScaleRule)
            Return oItems(ScaleRule.Scale) Is ScaleRule
        End Function

        Public Function Contains(ByVal Scale As Integer)
            Return oItems.ContainsKey(Scale)
        End Function

        Public Sub CopyFrom(ByVal ScaleRules As cScaleRules)
            Call oItems.Clear()
            For Each oItem As cScaleRule In ScaleRules
                Dim oNewItem As cScaleRule = New cScaleRule(oSurvey, oItem.Scale, oItem.Categories, oItem.DesignProperties)
                Call oItems.Add(oItem.Scale, oItem)
            Next
        End Sub

        Private Sub oScaleRule_OnScaleChange(ByVal Sender As cScaleRule, ByVal Args As cScaleRule.OnScaleChangeEventArgs)
            If oItems.ContainsKey(Args.NewScale) Then
                Args.Cancel = True
            Else
                Call oItems.Remove(Args.Scale)
                Call oItems.Add(Args.NewScale, Sender)
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function FindRule(ByVal Scale As Integer) As cIScaleRule
            Dim oItem As cIScaleRule
            Dim oNewItem As cIScaleRule
            Dim iIndex As Integer = 0
            Do
                If iIndex = 0 Then
                    oItem = oDefaultItem
                Else
                    oItem = oNewItem
                End If
                If iIndex >= oItems.Count Then Exit Do
                oNewItem = oItems.ElementAt(iIndex).Value
                iIndex += 1
            Loop While oNewItem.Scale <= Scale
            Return oItem
        End Function

        'Public Function CurrentRule() As cIScaleRule
        '    If oCurrentRule Is Nothing Then
        '        oCurrentRule = FindRule(iCurrentScale)
        '    End If
        '    Return oCurrentRule
        'End Function

        'Public Property CurrentScale As Integer
        '    Get
        '        Return iCurrentScale
        '    End Get
        '    Set(ByVal value As Integer)
        '        If (value >= 5 And value <= 50000) And (value <> iCurrentScale) Then
        '            iCurrentScale = value
        '            Dim oNewScaleRule As cIScaleRule = FindRule(iCurrentScale)
        '            If Not oCurrentRule Is oNewScaleRule Then
        '                oCurrentRule = oNewScaleRule
        '                Call oSurvey.RaiseOnPropertiesChanged(cSurvey.OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.Scale)
        '            End If
        '        End If
        '    End Set
        'End Property

        Public Function GetRule(ByVal Scale As Integer) As cIScaleRule
            If oItems.ContainsKey(Scale) Then
                Return oItems(Scale)
            Else
                Return Nothing
            End If
        End Function

        Public Function Add(ByVal Scale As Integer) As cScaleRule
            If oItems.ContainsKey(Scale) Then
                Call oItems.Remove(Scale)
            End If
            Dim oItem As cScaleRule = New cScaleRule(oSurvey, Scale)
            Call oItems.Add(Scale, oItem)
            Return oItem
        End Function

        Public Sub Remove(ByVal ScaleRule As cScaleRule)
            Try
                Call oItems.Remove(ScaleRule.Scale)
            Catch
            End Try
        End Sub

        Public Sub Remove(ByVal Index As Integer)
            Try
                Dim iScale As Integer = oItems.ElementAt(Index).Key
                Call oItems.Remove(iScale)
            Catch
            End Try
        End Sub

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cScaleRule
            Get
                Return oItems.ElementAt(Index).Value
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("scalerules")
            'Call oXmlItem.SetAttribute("currentscale", iCurrentScale)
            For Each oItem As cScaleRule In oItems.Values
                Call oItem.SaveTo(File, Document, oXmlItem)
            Next
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function
    End Class

    Public Interface cIScaleRule
        Property Scale As Integer
        ReadOnly Property Categories As cIScaleCategoriesVisibility
        ReadOnly Property DesignProperties As cPropertiesCollection
        ReadOnly Property Items As cVisibilityItems
    End Interface

    Public Class cDefaultScaleRule
        Implements cIScaleRule

        Private oSurvey As cSurvey
        Private oCategories As cDefaultScaleCategoriesVisibility
        Private oItems As cVisibilityItems

        Public ReadOnly Property Items As cVisibilityItems Implements cIScaleRule.Items
            Get
                Return oItems
            End Get
        End Property

        Public ReadOnly Property Categories As cIScaleCategoriesVisibility Implements cIScaleRule.Categories
            Get
                Return oCategories
            End Get
        End Property

        Public ReadOnly Property DesignProperties As cPropertiesCollection Implements cIScaleRule.DesignProperties
            Get
                Return oSurvey.Properties.DesignProperties
            End Get
        End Property

        Public Property Scale As Integer Implements cIScaleRule.Scale
            Get
                Return 0
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oCategories = New cDefaultScaleCategoriesVisibility
            oItems = New cVisibilityItems(oSurvey)
        End Sub
    End Class

    Public Interface cIScaleCategoriesVisibility
        Inherits IEnumerable
        Function SetVisibility(ByVal Category As cIItem.cItemCategoryEnum, ByVal Visibility As Boolean) As Boolean
        Default ReadOnly Property Visibility(ByVal Category As cIItem.cItemCategoryEnum) As Boolean
        Function ToArray() As KeyValuePair(Of cIItem.cItemCategoryEnum, Boolean)()
    End Interface

    Public Class cDefaultScaleCategoriesVisibility
        Implements cIScaleCategoriesVisibility
        Implements IEnumerable

        Private oCategories As Dictionary(Of cIItem.cItemCategoryEnum, Boolean)

        Default Public ReadOnly Property Visibility(ByVal Category As cIItem.cItemCategoryEnum) As Boolean Implements cIScaleCategoriesVisibility.Visibility
            Get
                Return True
            End Get
        End Property

        Public Function SetVisibility(ByVal Category As cIItem.cItemCategoryEnum, ByVal Visibility As Boolean) As Boolean Implements cIScaleCategoriesVisibility.SetVisibility
            Return False
        End Function

        Public Function ToArray() As System.Collections.Generic.KeyValuePair(Of cIItem.cItemCategoryEnum, Boolean)() Implements cIScaleCategoriesVisibility.ToArray
            Return oCategories.ToArray
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oCategories.GetEnumerator
        End Function

        Public Sub New()
            oCategories = New Dictionary(Of cIItem.cItemCategoryEnum, Boolean)
        End Sub
    End Class

    Public Class cScaleCategoriesVisibility
        Implements cIScaleCategoriesVisibility
        Implements IEnumerable

        Private oCategories As Dictionary(Of cIItem.cItemCategoryEnum, Boolean)

        Friend Sub New()
            oCategories = New Dictionary(Of cIItem.cItemCategoryEnum, Boolean)
        End Sub

        Friend Sub New(ByVal Categories As cIScaleCategoriesVisibility)
            oCategories = New Dictionary(Of cIItem.cItemCategoryEnum, Boolean)
            For Each oCategory As KeyValuePair(Of cIItem.cItemCategoryEnum, Boolean) In Categories
                Call oCategories.Add(oCategory.Key, oCategory.Value)
            Next
        End Sub

        Friend Sub New(ByVal Categories As XmlElement)
            oCategories = New Dictionary(Of cIItem.cItemCategoryEnum, Boolean)
            For Each oXMLCategory As XmlElement In Categories.ChildNodes
                Dim iCategory As cIItem.cItemCategoryEnum = oXMLCategory.GetAttribute("category")
                Dim bVisible As Boolean = oXMLCategory.GetAttribute("visible")
                Call oCategories.Add(iCategory, bVisible)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("categoriesvisibility")
            For Each oKeyValue As KeyValuePair(Of cIItem.cItemCategoryEnum, Boolean) In oCategories
                Dim iCategory As Integer = oKeyValue.Key
                Dim bVisible As Boolean = oKeyValue.Value
                Dim oXMLCategory As XmlElement = Document.CreateElement("category")
                Call oXMLCategory.SetAttribute("category", iCategory)
                Call oXMLCategory.SetAttribute("visible", IIf(bVisible, 1, 0))
                Call oXmlItem.AppendChild(oXMLCategory)
            Next
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public Function SetVisibility(ByVal Category As cIItem.cItemCategoryEnum, ByVal Visibility As Boolean) As Boolean Implements cIScaleCategoriesVisibility.SetVisibility
            If Visibility Then
                If oCategories.ContainsKey(Category) Then
                    Call oCategories.Remove(Category)
                End If
            Else
                If Not oCategories.ContainsKey(Category) Then
                    Call oCategories.Add(Category, False)
                End If
            End If
            Return True
        End Function

        Default Public ReadOnly Property Visibility(ByVal Category As cIItem.cItemCategoryEnum) As Boolean Implements cIScaleCategoriesVisibility.Visibility
            Get
                Return Not oCategories.ContainsKey(Category)
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oCategories.GetEnumerator
        End Function

        Public Function ToArray() As KeyValuePair(Of cIItem.cItemCategoryEnum, Boolean)() Implements cIScaleCategoriesVisibility.ToArray
            Return oCategories.ToArray()
        End Function
    End Class

    Public Class cScaleRule
        Implements cIScaleRule

        Friend Class OnScaleChangeEventArgs
            Private iScale As Integer
            Private iNewScale As Integer
            Private bCancel As Boolean

            Public ReadOnly Property Scale As Integer
                Get
                    Return iScale
                End Get
            End Property

            Public ReadOnly Property NewScale As Integer
                Get
                    Return iNewScale
                End Get
            End Property

            Public Property Cancel As Boolean
                Get
                    Return bCancel
                End Get
                Set(ByVal value As Boolean)
                    bCancel = value
                End Set
            End Property

            Friend Sub New(ByVal Scale As Integer, ByVal NewScale As Integer)
                iScale = Scale
                iNewScale = Scale
            End Sub
        End Class

        Private oSurvey As cSurvey
        Private iScale As Integer

        Private oCategories As cScaleCategoriesVisibility
        Private oDesignProperties As cPropertiesCollection

        Private oItems As cVisibilityItems

        Friend Event OnScaleChange(ByVal Sender As cIScaleRule, ByVal Args As OnScaleChangeEventArgs)

        Public ReadOnly Property Items As cVisibilityItems Implements cIScaleRule.Items
            Get
                Return oItems
            End Get
        End Property

        Public Property Scale As Integer Implements cIScaleRule.Scale
            Get
                Return iScale
            End Get
            Set(ByVal value As Integer)
                If iScale <> value Then
                    Dim bCancel As Boolean
                    Dim oArgs As OnScaleChangeEventArgs = New OnScaleChangeEventArgs(iScale, value)
                    RaiseEvent OnScaleChange(Me, oArgs)
                    If Not bCancel Then
                        iScale = value
                    End If
                End If
            End Set
        End Property

        Public Sub CopyFrom(ByVal ScaleRule As cScaleRule)
            oCategories = New cScaleCategoriesVisibility(ScaleRule.Categories)
            oDesignProperties = New cPropertiesCollection(oSurvey)
            If Not DesignProperties Is Nothing Then
                Call oDesignProperties.CopyFrom(ScaleRule.DesignProperties)
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Scale As Integer, Optional ByVal Categories As cScaleCategoriesVisibility = Nothing, Optional ByVal DesignProperties As cPropertiesCollection = Nothing)
            oSurvey = Survey
            iScale = Scale
            If Categories Is Nothing Then
                oCategories = New cScaleCategoriesVisibility()
            Else
                oCategories = New cScaleCategoriesVisibility(Categories)
            End If
            oDesignProperties = New cPropertiesCollection(oSurvey)
            If Not DesignProperties Is Nothing Then
                Call oDesignProperties.CopyFrom(DesignProperties)
            End If
            oItems = New cVisibilityItems(oSurvey)
        End Sub

        Public Overrides Function ToString() As String
            Return "Scale::1:" & iScale
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal ScaleRule As XmlElement)
            oSurvey = Survey
            iScale = ScaleRule.GetAttribute("scale")
            Try
                oCategories = New cScaleCategoriesVisibility(ScaleRule.Item("categoriesvisibility"))
            Catch
                oCategories = New cScaleCategoriesVisibility
            End Try
            Try
                oDesignProperties = New cPropertiesCollection(oSurvey, ScaleRule.Item("designproperties"))
            Catch
                oDesignProperties = New cPropertiesCollection(oSurvey)
            End Try
            Try
                oItems = New cVisibilityItems(oSurvey, ScaleRule.Item("vis"))
            Catch ex As Exception
                oItems = New cVisibilityItems(oSurvey)
            End Try
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlItem As XmlElement = Document.CreateElement("scalerule")
            Call oXmlItem.SetAttribute("scale", iScale)
            Call oCategories.SaveTo(File, Document, oXmlItem)
            Call oDesignProperties.SaveTo(File, Document, "designproperties", oXmlItem)
            Call oItems.SaveTo(File, Document, oXmlItem)
            Call Parent.AppendChild(oXmlItem)
            Return oXmlItem
        End Function

        Public ReadOnly Property Categories() As cIScaleCategoriesVisibility Implements cIScaleRule.Categories
            Get
                Return oCategories
            End Get
        End Property

        Public ReadOnly Property DesignProperties As cPropertiesCollection Implements cIScaleRule.DesignProperties
            Get
                Return oDesignProperties
            End Get
        End Property
    End Class
End Namespace