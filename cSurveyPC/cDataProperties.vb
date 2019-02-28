Imports System.Xml
Imports System.Linq
Imports cSurveyPC.cSurvey.Scripting
Imports System.Collections.ObjectModel

Namespace cSurvey.Data
    Public Interface cIObjectDataProperties
        ReadOnly Property DataProperties As cDataProperties
    End Interface

    Public Class cDataProperties
        Implements IEnumerable

        Private WithEvents oDataFields As cDataFields
        Private oItems As Dictionary(Of String, Object)

        Friend Class cDataPropertiesEventArgs
            Private sName As String
            Private oValue As Object

            Public ReadOnly Property Name As String
                Get
                    Return sName
                End Get
            End Property

            Public ReadOnly Property Value As Object
                Get
                    Return oValue
                End Get
            End Property

            Friend Sub New(Name As String, Value As Object)
                sName = Name
                oValue = Value
            End Sub
        End Class

        Friend Event OnChange(Sender As cDataProperties, Args As cDataPropertiesEventArgs)

        Friend Function GetClass() As Object
            Dim oClass As Object = oDataFields.GetClass
            If Not oClass Is Nothing Then
                Call oClass.SetDataProperties(Me)
            End If
            Return oClass
        End Function

        Friend Sub CopyFrom(DataProperties As cDataProperties)
            If DataProperties.oDataFields Is oDataFields Then
                Call oItems.Clear()
                For Each oItem As KeyValuePair(Of String, Object) In DataProperties.oItems
                    Call oItems.Add(oItem.Key, oItem.Value)
                Next
            End If
        End Sub

        Public ReadOnly Property Fields As cDataFields
            Get
                Return oDataFields
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, Fields As cDataFields)
            oDataFields = Fields
            oItems = New Dictionary(Of String, Object)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Fields As cDataFields, ByVal Item As XmlElement)
            oDataFields = Fields
            oItems = New Dictionary(Of String, Object)
            If modXML.HasAttribute(Item, "fields") Then
                Dim oFields As List(Of String) = New List(Of String)(Strings.Split(Item.GetAttribute("fields"), "|"))
                Dim oValues As List(Of String) = New List(Of String)(Strings.Split(Item.InnerText, "|"))
                For i As Integer = 0 To oFields.Count - 1
                    Dim sField As String = oFields(i)
                    Dim sValue As String = oValues(i)
                    If sValue <> "" Then
                        Dim oValue As Object = oDataFields.Item(sField).StringToValue(sValue)
                        Call oItems.Add(sField, oValue)
                    End If
                Next
            Else
                Dim oValues As List(Of String) = New List(Of String)(Strings.Split(Item.InnerText, "|"))
                'Dim iIndex As Integer = 0
                For i As Integer = 0 To oValues.Count - 1
                    'For Each oDataField As cDataField In oDataFields
                    Dim sValue As String = oValues(i)
                    If sValue <> "" Then
                        Dim oDataField As cDataField = oDataFields(i)
                        Dim oValue As Object = oDataField.StringToValue(sValue)
                        Call oItems.Add(oDataField.Name, oValue)
                    End If
                    'iIndex += 1
                Next
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function SetValue(Name As String, Value As Object) As Boolean
            If oDataFields.Contains(Name) Then
                If oItems.ContainsKey(Name) Then
                    Dim oCurrentValue As Object = oItems(Name)
                    If oDataFields(Name).ValidateValue(Value) Then
                        If oCurrentValue <> Value Or Value Is Nothing Then
                            Call oItems.Remove(Name)
                            If Not Value Is Nothing Then
                                Call oItems.Add(Name, Value)
                            End If
                            RaiseEvent OnChange(Me, New cDataPropertiesEventArgs(Name, Value))
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        'qua va impostato l'ultimo errore di validazione
                        Return False
                    End If
                Else
                    If oDataFields(Name).ValidateValue(Value) Then
                        Call oItems.Add(Name, Value)
                        RaiseEvent OnChange(Me, New cDataPropertiesEventArgs(Name, Value))
                        Return True
                    Else
                        'qua va impostato l'ultimo errore di validazione
                        Return False
                    End If
                End If
            Else
                Return False
            End If
        End Function

        Public Function GetValue(Name As String, Optional DefaultValue As Object = Nothing) As Object
            If oItems.ContainsKey(Name) Then
                Return oItems(Name)
            Else
                Return DefaultValue
            End If
        End Function

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXMLDataRow As XmlElement = Document.CreateElement("datarow")
            If (Options And cSurvey.SaveOptionsEnum.ForClipboard) = cSurvey.SaveOptionsEnum.ForClipboard Then
                oXMLDataRow.SetAttribute("fields", Strings.Join(oDataFields.ToList.Select(Function(item) item.Name).ToArray, "|"))
            End If
            Dim oValues As List(Of String) = New List(Of String)
            For Each oDataField As cDataField In oDataFields
                Call oValues.Add(oDataField.ValueToString(GetValue(oDataField.Name)))
            Next
            oXMLDataRow.InnerText = Strings.Join(oValues.ToArray, "|")
            Call Parent.AppendChild(oXMLDataRow)
            Return oXMLDataRow
        End Function

        'Public ReadOnly Property Count As Integer
        '    Get
        '        Return oItems.Count
        '    End Get
        'End Property

        'Default Public ReadOnly Property Item(Name As String) As cDataProperty
        '    Get
        '        Return oItems(Name)
        '    End Get
        'End Property

        'Default Public ReadOnly Property Item(Index As Integer) As cDataProperty
        '    Get
        '        Return oItems(Index)
        '    End Get
        'End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Private Sub oDataFields_OnRemove(Sender As cDataFields, Args As cDataFields.cDataFieldsEventArgs) Handles oDataFields.OnRemove
            Dim sName As String = Args.DataField.Name
            If oItems.ContainsKey(sName) Then
                Call oItems.Remove(sName)
            End If
        End Sub

        Private Sub oDataFields_OnRename(Sender As cDataFields, Args As cDataFields.cDataFieldsRebindEventArgs) Handles oDataFields.OnRename
            Dim sOldName As String = Args.OldDataField.Name
            Dim sNewName As String = Args.NewDataField.Name
            If oItems.ContainsKey(sOldName) Then
                Call oItems.Add(sNewName, oItems(sOldName))
                Call oItems.Remove(sOldName)
            End If
        End Sub

        Private Sub oDataFields_OnRetype(Sender As cDataFields, Args As cDataFields.cDataFieldsRebindEventArgs) Handles oDataFields.OnRetype
            Dim sName As String = Args.OldDataField.Name
            If oItems.ContainsKey(sName) Then
                Dim oOldValue As Object = oItems(sName)
                Dim oNewValue As Object
                Call oItems.Remove(sName)
                If Args.NewDataField.ValidateValue(oOldValue, oNewValue) Then
                    Call oItems.Add(sName, oNewValue)
                End If
            End If
        End Sub
    End Class

    Friend Class cDataFieldsCollection
        Inherits KeyedCollection(Of String, cDataField)

        Protected Overrides Function GetKeyForItem(ByVal item As cDataField) As String
            Return item.Name
        End Function
    End Class

    Public Class cDataFields
        Implements IEnumerable

        Private oSurvey As cSurvey

        Public Enum TypeEnum
            [Text] = 0
            [Integer] = 1
            [Single] = 2
            [Double] = 3
            [Decimal] = 4
            [Date] = 5
            [Boolean] = 6
            [Color] = 7
            [Enum] = 8
        End Enum

        Friend Class cDataFieldsEventArgs
            Private oDataField As cDataField

            Public ReadOnly Property DataField As cDataField
                Get
                    Return oDataField
                End Get
            End Property

            Friend Sub New(DataField As cDataField)
                oDataField = DataField
            End Sub
        End Class

        Friend Event OnRemove(Sender As cDataFields, Args As cDataFieldsEventArgs)
        Friend Event OnAdd(Sender As cDataFields, Args As cDataFieldsEventArgs)

        Friend Class cDataFieldsRebindEventArgs
            Private oOldDataField As cDataField
            Private oNewDataField As cDataField

            Public ReadOnly Property NewDataField As cDataField
                Get
                    Return oNewDataField
                End Get
            End Property

            Public ReadOnly Property OldDataField As cDataField
                Get
                    Return oOldDataField
                End Get
            End Property

            Friend Sub New(OldDataField As cDataField, NewDataField As cDataField)
                oOldDataField = OldDataField
                oNewDataField = NewDataField
            End Sub
        End Class

        Friend Event OnRename(Sender As cDataFields, Args As cDataFieldsRebindEventArgs)
        Friend Event OnRetype(Sender As cDataFields, Args As cDataFieldsRebindEventArgs)

        Private oItems As cDataFieldsCollection

        Private sName As String

        Private oClass As cClass

        Friend Function GetClass() As Object
            If oClass Is Nothing Then
                Dim sCode As String = ""
                sCode = sCode & "private oDataProperties as cSurveyPC.cSurvey.Data.cDataProperties" & vbCrLf
                sCode = sCode & "public sub SetDataProperties(DataProperties as cSurveyPC.cSurvey.Data.cDataProperties)" & vbCrLf
                sCode = sCode & "oDataProperties=DataProperties" & vbCrLf
                sCode = sCode & "end sub" & vbCrLf & vbCrLf
                For Each oDataField As cDataField In oItems
                    sCode = sCode & oDataField.GetCodeDefinition & vbCrLf
                Next
                oClass = New cClass(oSurvey, "_dataproperties", sCode, LanguageEnum.VisualBasic)
            End If
            Return oClass.DefaultInstance
        End Function

        Friend Sub InvalidateClass()
            oClass = Nothing
        End Sub

        Public Function CanMergeWith(DataFields As cDataFields) As Boolean
            For Each oDataField As cDataField In DataFields
                If oItems.Contains(oDataField.Name) Then
                    'check if type is the same (casting is not supported, for now)
                    If oDataField.Type <> oItems(oDataField.Name).Type Then
                        Return False
                    End If
                End If
            Next
            Return True
        End Function

        Public Sub MergeWith(DataFields As cDataFields)
            Dim bInvalidateClass As Boolean = False
            For Each oDataField As cDataField In DataFields
                If Not oItems.Contains(oDataField.Name) Then
                    Dim oNewDataField As cDataField = New cDataField(oSurvey, oDataField.Name, oDataField.Type)
                    Call oNewDataField.CopyFrom(oDataField)
                    Call oItems.Add(oNewDataField)
                    bInvalidateClass = True
                End If
            Next
            If bInvalidateClass Then InvalidateClass()
        End Sub

        Public Function Contains(Item As cDataField) As Boolean
            Return oItems.Contains(Item)
        End Function

        Public Function Contains(Name As String) As Boolean
            Return oItems.Contains(Name)
        End Function

        Public Function Rename(Name As String, NewName As String) As cDataField
            If oItems.Contains(NewName) Then
                Return Nothing
            Else
                Dim oItem As cDataField = oItems(Name)
                Dim oNewItem As cDataField
                Select Case oItem.Type
                    Case TypeEnum.Enum
                        Dim oEnumNewItem As cEnumDataField = New cEnumDataField(oSurvey, NewName, oItem.Type)
                        For Each oValue As KeyValuePair(Of Integer, String) In DirectCast(oItem, cEnumDataField).Values
                            Call oEnumNewItem.Values.Add(oValue.Key, oValue.Value)
                        Next
                        oNewItem = oEnumNewItem
                    Case Else
                        oNewItem = New cDataField(oSurvey, NewName, oItem.Type)
                End Select
                oNewItem.Description = oItem.Description
                'oNewItem.DefaultValue = oItem.DefaultValue
                RaiseEvent OnRename(Me, New cDataFieldsRebindEventArgs(oItem, oNewItem))
                Call oItems.Remove(Name)
                Call oItems.Add(oNewItem)
                Call InvalidateClass()
                Return oNewItem
            End If
        End Function

        Public Function Retype(Name As String, NewType As cDataFields.TypeEnum) As cDataField
            Dim oItem As cDataField = oItems(Name)
            If oItem.Type = NewType Then
                Return Nothing
            Else
                Dim oNewItem As cDataField
                Select Case oItem.Type
                    Case TypeEnum.Enum
                        Dim oEnumNewItem As cEnumDataField = New cEnumDataField(oSurvey, Name, NewType)
                        oNewItem = oEnumNewItem
                    Case Else
                        oNewItem = New cDataField(oSurvey, Name, NewType)
                End Select
                oNewItem.Description = oItem.Description
                'oNewItem.DefaultValue = oItem.DefaultValue
                RaiseEvent OnRetype(Me, New cDataFieldsRebindEventArgs(oItem, oNewItem))
                Call oItems.Remove(Name)
                Call oItems.Add(oNewItem)
                Call InvalidateClass()
                Return oNewItem
            End If
        End Function

        Public Function Add(Name As String, Type As TypeEnum) As cDataField
            If oItems.Contains(Name) Then
                Return Nothing
            Else
                Dim oItem As cDataField
                Select Case Type
                    Case TypeEnum.Enum
                        oItem = New cEnumDataField(oSurvey, Name, Type)
                    Case Else
                        oItem = New cDataField(oSurvey, Name, Type)
                End Select
                Call oItems.Add(oItem)
                Call InvalidateClass()
                RaiseEvent OnAdd(Me, New cDataFieldsEventArgs(oItem))
                Return oItem
            End If
        End Function

        Public Sub Remove(Item As cDataField)
            If oItems.Contains(Item) Then
                Dim oItem As cDataField = Item
                RaiseEvent OnRemove(Me, New cDataFieldsEventArgs(oItem))
                Call oItems.Remove(oItem.Name)
                Call InvalidateClass()
            End If
        End Sub

        Public Sub Remove(Name As String)
            If oItems.Contains(Name) Then
                Dim oItem As cDataField = oItems(Name)
                RaiseEvent OnRemove(Me, New cDataFieldsEventArgs(oItem))
                Call oItems.Remove(Name)
                Call InvalidateClass()
            End If
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(Name As String) As cDataField
            Get
                Return oItems(Name)
            End Get
        End Property

        Default Public ReadOnly Property Item(Index As Integer) As cDataField
            Get
                Return oItems(Index)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Name As String)
            oSurvey = Survey
            sName = Name
            oItems = New cDataFieldsCollection
        End Sub

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            sName = Item.Name
            oItems = New cDataFieldsCollection
            For Each oChildItem As XmlElement In Item.ChildNodes
                Dim oField As cDataField
                Dim iType As cDataFields.TypeEnum = modXML.GetAttributeValue(oChildItem, "type", cDataFields.TypeEnum.Text)
                Select Case iType
                    Case TypeEnum.Enum
                        oField = New cEnumDataField(Survey, oChildItem)
                    Case Else
                        oField = New cDataField(Survey, oChildItem)
                End Select
                Call oItems.Add(oField)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLDataFields As XmlElement = Document.CreateElement(sName)
            For Each oField As cDataField In oItems
                Call oField.SaveTo(File, Document, oXMLDataFields)
            Next
            Call Parent.AppendChild(oXMLDataFields)
            Return oXMLDataFields
        End Function

        Public Function ToList() As List(Of cDataField)
            Return oItems.ToList
        End Function
    End Class

    Public Interface cIDataField
        ReadOnly Property Name As String
        ReadOnly Property Type As cDataFields.TypeEnum
    End Interface

    Public Class cEnumDataField
        Inherits cDataField

        Private oValues As Dictionary(Of Integer, String)

        Public Overrides Function ValidateValue(Value As Object, Optional ByRef ValidatedValue As Object = Nothing) As Boolean
            If MyBase.ValidateValue(Value, ValidatedValue) Then
                If ValidatedValue Is Nothing Then
                    Return True
                Else
                    If oValues.ContainsKey(ValidatedValue) Then
                        Return True
                    Else
                        ValidatedValue = Nothing
                        Return False
                    End If
                End If
            End If
        End Function

        Public ReadOnly Property Values As Dictionary(Of Integer, String)
            Get
                Return oValues
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            Call MyBase.New(Survey, Item)
            oValues = New Dictionary(Of Integer, String)
            Dim oXMLValues As XmlElement = Item.Item("values")
            For Each oXMLValue As XmlElement In oXMLValues.ChildNodes
                Dim iKey As Integer = oXMLValue.GetAttribute("k")
                Dim sValue As String = oXMLValue.GetAttribute("v")
                If sValue = "" Then sValue = "_"
                Call oValues.Add(iKey, sValue)
            Next
        End Sub

        Public Sub New(ByVal Survey As cSurvey, Name As String, Type As cDataFields.TypeEnum, Optional DefaultValue As Object = Nothing)
            Call MyBase.New(Survey, Name, Type, DefaultValue)
            oValues = New Dictionary(Of Integer, String)
        End Sub

        Friend Overrides Function SaveTo(File As Storage.cFile, Document As XmlDocument, Parent As XmlElement) As XmlElement
            Dim oXMLItem As XmlElement = MyBase.SaveTo(File, Document, Parent)
            Dim oXMLValues As XmlElement = Document.CreateElement("values")
            For Each oValue As KeyValuePair(Of Integer, String) In oValues
                Dim oXMLValue As XmlElement = Document.CreateElement("value")
                Call oXMLValue.SetAttribute("k", oValue.Key)
                Call oXMLValue.SetAttribute("v", oValue.Value)
                Call oXMLValues.AppendChild(oXMLValue)
            Next
            Call oXMLItem.AppendChild(oXMLValues)
            Return oXMLItem
        End Function

        Friend Overrides Function GetCodeDefinition()
            Dim sCode As String = ""
            Dim sBaseCode As String = MyBase.GetCodeDefinition
            sCode = sCode & "public enum " & MyBase.Name & "_enum" & vbCrLf
            For Each oValue As KeyValuePair(Of Integer, String) In oValues
                'sCode = sCode & "[Description(""" & oValue.Value & """)]" & vbCrLf
                sCode = sCode & "[" & oValue.Value.Replace(" ", "_") & "]=" & oValue.Key & vbCrLf
            Next
            sCode = sCode & "end enum" & vbCrLf
            sCode = sCode & sBaseCode
            Return sCode
        End Function
    End Class

    Public Class cDataField
        Implements cIDataField
        Private sName As String
        Private sCategory As String
        Private sDescription As String
        Private iType As cDataFields.TypeEnum

        Friend Overridable Function GetCodeDefinition()
            Dim sCode As String = ""
            Dim sTypename As String = GetTypeName()
            sCode = sCode & "<Category(""" & sCategory & """)> _" & vbCrLf
            sCode = sCode & "<DefaultValue(" & GetDefaultValueName() & ")> _" & vbCrLf
            sCode = sCode & "public property [" & sName & "] as " & sTypename & vbCrLf
            sCode = sCode & "get" & vbCrLf
            sCode = sCode & "return oDataProperties.GetValue(""" & sName & """)" & vbCrLf
            sCode = sCode & "end get" & vbCrLf
            sCode = sCode & "set (Value as " & sTypename & ")" & vbCrLf
            sCode = sCode & "call oDataProperties.SetValue(""" & sName & """,Value)" & vbCrLf
            sCode = sCode & "end set" & vbCrLf
            sCode = sCode & "end property" & vbCrLf
            Return sCode
        End Function

        Friend Function GetDefaultValueName() As String
            Return "DirectCast(Nothing, Object)"
        End Function

        Friend Function GetDefaultValue() As Object
            Return Nothing
        End Function

        Friend Shared Function ValidateValue(Type As cDataFields.TypeEnum, Value As Object, Optional ByRef ValidatedValue As Object = Nothing) As Boolean
            If Value Is Nothing Then
                ValidatedValue = Nothing
                Return True
            Else
                Try
                    Select Case Type
                        Case cDataFields.TypeEnum.Color
                            Dim oValue As Color = Value
                            ValidatedValue = oValue
                        Case cDataFields.TypeEnum.Single
                            Dim sValue As Single = Value
                            ValidatedValue = sValue
                        Case cDataFields.TypeEnum.Double
                            Dim dValue As Double = Value
                            ValidatedValue = dValue
                        Case cDataFields.TypeEnum.Integer
                            Dim iValue As Integer = Value
                            ValidatedValue = iValue
                        Case cDataFields.TypeEnum.Decimal
                            Dim dValue As Decimal = Value
                            ValidatedValue = dValue
                        Case cDataFields.TypeEnum.Date
                            Dim dValue As Date = Value
                            ValidatedValue = dValue
                        Case cDataFields.TypeEnum.Boolean
                            Dim bValue As Boolean = Value
                            ValidatedValue = bValue
                        Case cDataFields.TypeEnum.Enum
                            Dim iValue As Integer = Value
                            ValidatedValue = iValue
                        Case Else
                            Dim sValue As String = Value.ToString
                            ValidatedValue = sValue
                    End Select
                    Return True
                Catch ex As Exception
                    ValidatedValue = Nothing
                    Return False
                End Try
            End If
        End Function

        Public Overridable Function ValidateValue(Value As Object, Optional ByRef ValidatedValue As Object = Nothing) As Boolean
            If Value Is Nothing Then
                ValidatedValue = Nothing
                Return True
            Else
                Try
                    Select Case iType
                        Case cDataFields.TypeEnum.Color
                            Dim oValue As Color = Value
                            ValidatedValue = oValue
                        Case cDataFields.TypeEnum.Single
                            Dim sValue As Single = Value
                            ValidatedValue = sValue
                        Case cDataFields.TypeEnum.Double
                            Dim dValue As Double = Value
                            ValidatedValue = dValue
                        Case cDataFields.TypeEnum.Integer
                            Dim iValue As Integer = Value
                            ValidatedValue = iValue
                        Case cDataFields.TypeEnum.Decimal
                            Dim dValue As Decimal = Value
                            ValidatedValue = dValue
                        Case cDataFields.TypeEnum.Date
                            Dim dValue As Date = Value
                            ValidatedValue = dValue
                        Case cDataFields.TypeEnum.Boolean
                            Dim bValue As Boolean = Value
                            ValidatedValue = bValue
                        Case cDataFields.TypeEnum.Enum
                            Dim iValue As Integer = Value
                            ValidatedValue = iValue
                        Case Else
                            Dim sValue As String = Value.ToString
                            ValidatedValue = sValue
                    End Select
                    Return True
                Catch ex As Exception
                    ValidatedValue = Nothing
                    Return False
                End Try
            End If
        End Function

        Public ReadOnly Property Name As String Implements cIDataField.Name
            Get
                Return sName
            End Get
        End Property

        Public Property Category As String
            Get
                Return sCategory
            End Get
            Set(value As String)
                If value <> sCategory Then
                    sCategory = value
                End If
            End Set
        End Property

        Public Property Description As String
            Get
                Return sDescription
            End Get
            Set(value As String)
                sDescription = value
            End Set
        End Property

        Public ReadOnly Property Type As cDataFields.TypeEnum Implements cIDataField.Type
            Get
                Return iType
            End Get
        End Property

        Friend Shared Function GetTypeName(Type As cDataFields.TypeEnum, Optional Name As String = "enum") As String
            Select Case Type
                Case cDataFields.TypeEnum.Boolean
                    Return "boolean?"
                Case cDataFields.TypeEnum.Color
                    Return "System.Drawing.Color"
                Case cDataFields.TypeEnum.Date
                    Return "Date?"
                Case cDataFields.TypeEnum.Decimal
                    Return "Decimal?"
                Case cDataFields.TypeEnum.Double
                    Return "Double?"
                Case cDataFields.TypeEnum.Enum
                    Return Name & "_enum"
                Case cDataFields.TypeEnum.Integer
                    Return "Integer?"
                Case cDataFields.TypeEnum.Single
                    Return "Single?"
                Case cDataFields.TypeEnum.Text
                    Return "String"
            End Select
        End Function

        Friend Function GetTypeName() As String
            Return GetTypeName(iType, sName)
        End Function

        Public Sub CopyFrom(DataField As cDataField)
            sCategory = DataField.sCategory
            sDescription = DataField.Description
        End Sub

        Public Sub New(ByVal Survey As cSurvey, Name As String, Type As cDataFields.TypeEnum, Optional DefaultValue As Object = Nothing)
            sName = Name
            iType = Type
            sCategory = ""
            'oDefaultValue = DefaultValue
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            sName = Item.GetAttribute("name")
            iType = Item.GetAttribute("type")
            sDescription = modXML.GetAttributeValue(Item, "description", "")
            sCategory = modXML.GetAttributeValue(Item, "category", "")
            'oDefaultValue = StringToValue(modXML.GetAttributeValue(Item, "defaultvalue"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLDataField As XmlElement = Document.CreateElement("datafield")
            Call oXMLDataField.SetAttribute("name", sName)
            Call oXMLDataField.SetAttribute("type", iType)
            If sDescription <> "" Then
                Call oXMLDataField.SetAttribute("description", sDescription)
            End If
            If sCategory <> "" Then
                Call oXMLDataField.SetAttribute("category", sCategory)
            End If
            'If Not oDefaultValue Is Nothing Then
            '    Call oXMLDataField.SetAttribute("defaultvalue", ValueToString(oDefaultValue))
            'End If
            Call Parent.AppendChild(oXMLDataField)
            Return oXMLDataField
        End Function

        Friend Shared Function StringToValue(Type As cDataFields.TypeEnum, Value As String) As Object
            If Value = "" Then
                Return Nothing
            Else
                Select Case Type
                    Case cDataFields.TypeEnum.Color
                        Return Color.FromArgb(Value)
                    Case cDataFields.TypeEnum.Single
                        Return modNumbers.StringToSingle(Value)
                    Case cDataFields.TypeEnum.Double
                        Return modNumbers.StringToDouble(Value)
                    Case cDataFields.TypeEnum.Integer
                        Return CInt(Value)
                    Case cDataFields.TypeEnum.Decimal
                        Return CDec(modNumbers.StringToDecimal(Value))
                    Case cDataFields.TypeEnum.Date
                        Return CDate(Value)
                    Case cDataFields.TypeEnum.Boolean
                        Return CBool(Value)
                    Case cDataFields.TypeEnum.Enum
                        Return CInt(Value)
                    Case Else
                        Return Value
                End Select
            End If
        End Function

        Friend Shared Function ValueToString(Type As cDataFields.TypeEnum, Value As Object) As String
            If Value Is Nothing Then
                Return ""
            Else
                Select Case Type
                    Case cDataFields.TypeEnum.Date
                        Return DirectCast(Value, Date).ToString("O")
                    Case cDataFields.TypeEnum.Color
                        Return DirectCast(Value, Color).ToArgb
                    Case cDataFields.TypeEnum.Double, cDataFields.TypeEnum.Single, cDataFields.TypeEnum.Decimal
                        Return modNumbers.NumberToString(Value)
                    Case cDataFields.TypeEnum.Boolean
                        Return If(Value, "1", "0")
                    Case cDataFields.TypeEnum.Enum
                        If TypeOf Value Is Integer Then
                            Return DirectCast(Value, Integer)
                        Else
                            Return DirectCast(Value, [Enum]).ToString("D")
                        End If
                    Case Else
                        Return Value.ToString
                End Select
            End If
        End Function

        Friend Overridable Function StringToValue(Value As String) As Object
            Return StringToValue(iType, Value)
        End Function

        Friend Overridable Function ValueToString(Value As Object) As String
            Return ValueToString(iType, Value)
        End Function
    End Class
End Namespace