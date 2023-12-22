Imports System.Xml

Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Design.Items
Imports cSurveyPC.cSurvey.Helper.Editor.cUndo
Imports System.Windows.Input
Imports DevExpress.XtraRichEdit.Commands.Internal
Imports DevExpress.XtraRichEdit.API.Native

Namespace cSurvey.Helper.Editor
    Public Class cEnvironmentSettingsFolder
        Private sPath As String
        Private oValues As Dictionary(Of String, Object)

        Friend Class cEnvironmentSettingsFolderPropertyChangedEventArgs
            Private sPath As String
            Private sName As String

            Public ReadOnly Property Name As String
                Get
                    Return sName
                End Get
            End Property

            Public ReadOnly Property Path As String
                Get
                    Return sPath
                End Get
            End Property

            Public Sub New(Path As String, Name As String)
                sPath = Path
                sName = Name
            End Sub
        End Class

        Friend Event OnPropertyChanged(sender As Object, e As cEnvironmentSettingsFolderPropertyChangedEventArgs)

        Public Sub New(Path As String)
            sPath = Path
            oValues = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Sub New()
            sPath = ""
            oValues = New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oValues.Count
            End Get
        End Property

        Public Sub SetSettings(ParamArray Settings() As Object)
            For i As Integer = 0 To Settings.Count - 1 Step 2
                Dim sKey As String = Settings(i)
                Dim oValue As Object = Settings(i + 1)
                If oValues.ContainsKey(sKey) Then
                    Call oValues.Remove(sKey)
                End If
                Call oValues.Add(sKey, oValue)
            Next
            RaiseEvent OnPropertyChanged(Me, New cEnvironmentSettingsFolderPropertyChangedEventArgs(sPath, ""))
        End Sub

        Public Function DeleteSetting(Key As String) As Boolean
            If oValues.ContainsKey(Key) Then
                Call oValues.Remove(Key)
                RaiseEvent OnPropertyChanged(Me, New cEnvironmentSettingsFolderPropertyChangedEventArgs(sPath, Key))
                Return True
            Else
                Return False
            End If
        End Function

        Protected Friend ReadOnly Property Values As Dictionary(Of String, Object)
            Get
                Return oValues
            End Get
        End Property

        Public Function GetFolder(Key As String) As cEnvironmentSettingsFolder
            If oValues.ContainsKey(Key) Then
                If TypeOf oValues(Key) Is cEnvironmentSettingsFolder Then
                    Return oValues(Key)
                Else
                    Throw New InvalidCastException
                End If
            Else
                Dim oFolder As cEnvironmentSettingsFolder = New cEnvironmentSettingsFolder
                Call oValues.Add(Key, oFolder)
                Return oFolder
            End If
        End Function

        Public Function GetKeys() As String()
            Return oValues.Keys.ToArray
        End Function

        Public Sub SetSetting(Key As String, Value As Object)
            If oValues.ContainsKey(Key) Then Call oValues.Remove(Key)
            Call oValues.Add(Key, Value)
            RaiseEvent OnPropertyChanged(Me, New cEnvironmentSettingsFolderPropertyChangedEventArgs(sPath, Key))
        End Sub

        Public Sub SetSetting(Key As String, Value As Object, DefaultValue As Object)
            If oValues.ContainsKey(Key) Then Call oValues.Remove(Key)
            If Not Value.Equals(DefaultValue) Then
                Call oValues.Add(Key, Value)
            End If
            RaiseEvent OnPropertyChanged(Me, New cEnvironmentSettingsFolderPropertyChangedEventArgs(sPath, Key))
        End Sub

        Public Function Contains(Key As String) As Boolean
            Return oValues.ContainsKey(Key)
        End Function

        Public Function GetSetting(ByVal Key As String, Optional ByVal DefaultValue As Object = Nothing) As Object
            Try
                If oValues.ContainsKey(Key) Then
                    Return oValues(Key)
                Else
                    Return DefaultValue
                End If
            Catch
                Return DefaultValue
            End Try
        End Function
    End Class

    Public Class cEnvironmentSettings
        Inherits cEnvironmentSettingsFolder

        Public Delegate Sub OnPropertyChangedDelegate(Sender As Object, e As PropertyChangeEventArgs)
        Private oChangedDelegates As List(Of OnPropertyChangedDelegate)

        Private sRegistryKey As String

        Private Sub Base_OnPropertyChanged(sender As Object, e As cEnvironmentSettingsFolderPropertyChangedEventArgs)
            Call pRaiseOnPropertyChanged(e.Path, e.Name)
        End Sub

        Public Sub New()
            Call MyBase.New()
            AddHandler MyBase.OnPropertyChanged, AddressOf Base_OnPropertyChanged
            oChangedDelegates = New List(Of OnPropertyChangedDelegate)
        End Sub

        Public Sub New(RegistryKey As String)
            Call MyBase.New()
            sRegistryKey = RegistryKey
            oChangedDelegates = New List(Of OnPropertyChangedDelegate)
            Call pAddFolder(Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sRegistryKey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree), Me)
        End Sub

        Private Sub pAddFolder(SubKeyReg As Microsoft.Win32.RegistryKey, Settings As cEnvironmentSettingsFolder)
            Using SubKeyReg
                For Each sKey As String In SubKeyReg.GetValueNames
                    Dim oValue As Object = SubKeyReg.GetValue(sKey)
                    Call Settings.Values.Add(sKey, oValue)
                Next
                For Each sSubKey As String In SubKeyReg.GetSubKeyNames
                    Dim oSettings As cEnvironmentSettingsFolder = New cEnvironmentSettingsFolder
                    Call pAddFolder(SubKeyReg.OpenSubKey(sSubKey), oSettings)
                    If Settings.Contains(sSubKey) Then Settings.DeleteSetting(sSubKey)
                    Call Settings.Values.Add(sSubKey, oSettings)
                    AddHandler Settings.OnPropertyChanged, AddressOf Base_OnPropertyChanged
                Next
            End Using
        End Sub

        Public Sub pSave(SubKeyReg As Microsoft.Win32.RegistryKey, Settings As cEnvironmentSettingsFolder)
            Using SubKeyReg
                For Each sName As String In Settings.Values.Keys
                    Dim oValue As Object = Settings.Values(sName)
                    If TypeOf oValue Is cEnvironmentSettingsFolder Then
                        If oValue.count = 0 Then
                            Call SubKeyReg.DeleteSubKey(sName, False)
                        Else
                            Call pSave(SubKeyReg.CreateSubKey(sName, True), oValue)
                        End If
                    ElseIf TypeOf oValue Is Boolean Then
                        oValue = If(oValue, "1", "0")
                        Call SubKeyReg.SetValue(sName, oValue)
                    ElseIf TypeOf oValue Is Color Then
                        oValue = DirectCast(oValue, Color).ToArgb
                        Call SubKeyReg.SetValue(sName, oValue)
                    Else
                        Call SubKeyReg.SetValue(sName, oValue)
                    End If
                Next
            End Using
        End Sub

        Public Sub Save()
            If sRegistryKey IsNot Nothing Then
                Call pSave(Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sRegistryKey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree), Me)
            End If
        End Sub

        Public Sub Reset()
            Call MyBase.Values.Clear()
            If sRegistryKey IsNot Nothing Then
                Call pAddFolder(Microsoft.Win32.Registry.CurrentUser.CreateSubKey(sRegistryKey, Microsoft.Win32.RegistryKeyPermissionCheck.ReadSubTree), Me)
            End If
        End Sub

        Public Sub OnPropertyChangedAppend(OnPropertyChanged As OnPropertyChangedDelegate)
            Call oChangedDelegates.Add(OnPropertyChanged)
        End Sub

        Public Sub OnPropertyChangedRemove(OnPropertyChanged As OnPropertyChangedDelegate)
            Call oChangedDelegates.Remove(OnPropertyChanged)
        End Sub

        Private Sub pRaiseOnPropertyChanged(Path As String, Name As String)
            For Each oOnPropertyChanged As OnPropertyChangedDelegate In oChangedDelegates
                Call oOnPropertyChanged(Nothing, New PropertyChangeEventArgs(Path & "\" & Name))
            Next
        End Sub

        'Public Sub SetSettings(ParamArray Settings() As Object)
        '    For i As Integer = 0 To Settings.Count - 1 Step 2
        '        Dim sKey As String = Settings(i)
        '        Dim oValue As Object = Settings(i + 1)
        '        If MyBase.Values.ContainsKey(sKey) Then
        '            Call MyBase.Values.Remove(sKey)
        '        End If
        '        Call MyBase.Values.Add(sKey, oValue)
        '    Next
        '    Call pRaiseOnPropertyChanged("")
        'End Sub

        'Public Function DeleteSetting(Key As String) As Boolean
        '    If MyBase.Values.ContainsKey(Key) Then
        '        Call MyBase.Values.Remove(Key)
        '        Return True
        '    Else
        '        Return False
        '    End If
        'End Function

        'Public Sub SetSetting(Key As String, Value As Object)
        '    If oValues.ContainsKey(Key) Then Call oValues.Remove(Key)
        '    Call oValues.Add(Key, Value)
        '    Call pRaiseOnPropertyChanged(Key)
        'End Sub

        'Public Sub SetSetting(Key As String, Value As Object, DefaultValue As Object)
        '    If oValues.ContainsKey(Key) Then Call oValues.Remove(Key)
        '    If Value.Equals(DefaultValue) Then
        '        Call oValues.Add(Key, Value)
        '    End If
        '    Call pRaiseOnPropertyChanged(Key)
        'End Sub

        'Public Function Contains(Key As String) As Boolean
        '    Return oValues.ContainsKey(Key)
        'End Function

        'Public Function GetSetting(ByVal Key As String, Optional ByVal DefaultValue As Object = Nothing) As Object
        '    Try
        '        If oValues.ContainsKey(Key) Then
        '            Return oValues(Key)
        '        Else
        '            Return DefaultValue
        '        End If
        '    Catch
        '        Return DefaultValue
        '    End Try
        'End Function
    End Class

    Public Interface cIEditSelection
        ReadOnly Property CurrentSurvey As cSurvey

        ReadOnly Property CurrentTrigpoint As cTrigPoint
        ReadOnly Property CurrentSegment As cSegment
    End Interface

    Public Interface cIEditDesignSelection
        Inherits cIEditSelection

        'cave and branch are filtered by design...
        ReadOnly Property CurrentCave As String
        ReadOnly Property CurrentBranch As String

        ReadOnly Property CurrentLayer As Design.cLayer
        ReadOnly Property CurrentItem As Design.cItem
        ReadOnly Property CurrentItemPoint As Design.cPoint

        Function IsInEditing() As Boolean
    End Interface

    Friend Class cEditSelection
        Implements cIEditSelection

        Private ocurrentSurvey As cSurvey
        Private oCurrentSegment As cSegment
        Private oCurrentTrigpoint As cTrigPoint

        Public Sub New(CurrentSurvey As cSurvey, CurrentSegment As cSegment, CurrentTrigpoint As cTrigPoint)
            ocurrentSurvey = CurrentSurvey
            oCurrentSegment = CurrentSegment
            oCurrentTrigpoint = CurrentTrigpoint
        End Sub

        Public Sub New(Selection As cIEditSelection)
            ocurrentSurvey = Selection.CurrentSurvey
            oCurrentSegment = Selection.CurrentSegment
            oCurrentTrigpoint = Selection.CurrentTrigpoint
        End Sub

        Public ReadOnly Property CurrentSurvey As cSurvey Implements cIEditSelection.CurrentSurvey
            Get
                Return ocurrentSurvey
            End Get
        End Property

        Public ReadOnly Property CurrentTrigpoint As cTrigPoint Implements cIEditSelection.CurrentTrigpoint
            Get
                Return oCurrentTrigpoint
            End Get
        End Property

        Public ReadOnly Property CurrentSegment As cSegment Implements cIEditSelection.CurrentSegment
            Get
                Return oCurrentSegment
            End Get
        End Property
    End Class

    Friend Class cEditDesignSelection
        Inherits cEditSelection
        Implements cIEditDesignSelection

        Private sCurrentCave As String
        Private sCurrentBranch As String

        Private oCurrentLayer As cLayer
        Private oCurrentItem As cItem
        Private oCurrentItemPoint As cPoint

        Public Sub New(Selection As cIEditSelection, CurrentCave As String, CurrentBranch As String, Optional CurrentLayer As cLayer = Nothing, Optional CurrentItem As cItem = Nothing, Optional CurrentItemPoint As cPoint = Nothing)
            Call MyBase.New(Selection)

            sCurrentCave = CurrentCave
            sCurrentBranch = CurrentBranch

            oCurrentLayer = CurrentLayer
            oCurrentItem = CurrentItem
            oCurrentItemPoint = CurrentItemPoint
        End Sub

        Public Sub New(Selection As cIEditDesignSelection)
            Call MyBase.New(Selection)

            sCurrentCave = Selection.CurrentCave
            sCurrentBranch = Selection.CurrentBranch

            oCurrentLayer = Selection.CurrentLayer
            oCurrentItem = Selection.CurrentItem
            oCurrentItemPoint = Selection.CurrentItemPoint
        End Sub

        Public Sub New(CurrentSurvey As cSurvey, CurrentSegment As cSegment, CurrentTrigpoint As cTrigPoint, CurrentCave As String, CurrentBranch As String, Optional CurrentLayer As cLayer = Nothing, Optional CurrentItem As cItem = Nothing, Optional CurrentItemPoint As cPoint = Nothing)
            Call MyBase.New(CurrentSurvey, CurrentSegment, CurrentTrigpoint)

            sCurrentCave = "" & CurrentCave
            sCurrentBranch = "" & CurrentBranch

            oCurrentLayer = CurrentLayer
            oCurrentItem = CurrentItem
            oCurrentItemPoint = CurrentItemPoint
        End Sub

        Public ReadOnly Property CurrentCave As String Implements cIEditDesignSelection.CurrentCave
            Get
                Return sCurrentCave
            End Get
        End Property

        Public ReadOnly Property CurrentBranch As String Implements cIEditDesignSelection.CurrentBranch
            Get
                Return sCurrentBranch
            End Get
        End Property

        Public ReadOnly Property CurrentLayer As cLayer Implements cIEditDesignSelection.CurrentLayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public ReadOnly Property CurrentItem As cItem Implements cIEditDesignSelection.CurrentItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint As cPoint Implements cIEditDesignSelection.CurrentItemPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property

        Public Function IsInEditing() As Boolean Implements cIEditDesignSelection.IsInEditing
            Return False
        End Function
    End Class

    Friend Class cEmptyEditDesignSelection
        Inherits cEmptyEditSelection
        Implements cIEditDesignSelection

        Public ReadOnly Property CurrentLayer As cLayer Implements cIEditDesignSelection.CurrentLayer
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property CurrentItem As cItem Implements cIEditDesignSelection.CurrentItem
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint As cPoint Implements cIEditDesignSelection.CurrentItemPoint
            Get
                Return Nothing
            End Get
        End Property

        Public Function IsInEditing() As Boolean Implements cIEditDesignSelection.IsInEditing
            Return False
        End Function

        Public ReadOnly Property CurrentCave As String Implements cIEditDesignSelection.CurrentCave
            Get
                Return ""
            End Get
        End Property

        Public ReadOnly Property CurrentBranch As String Implements cIEditDesignSelection.CurrentBranch
            Get
                Return ""
            End Get
        End Property

        Overloads Shared Function Empty() As cEmptyEditDesignSelection
            Return New cEmptyEditDesignSelection
        End Function
    End Class

    Friend Class cEmptyEditSelection
        Implements cIEditSelection

        Public ReadOnly Property CurrentSurvey As cSurvey Implements cIEditSelection.CurrentSurvey
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property CurrentTrigpoint As cTrigPoint Implements cIEditSelection.CurrentTrigpoint
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property CurrentSegment As cSegment Implements cIEditSelection.CurrentSegment
            Get
                Return Nothing
            End Get
        End Property

        Shared Function Empty() As cEmptyEditSelection
            Return New cEmptyEditSelection
        End Function
    End Class

    Friend Class cEditTools
        Implements cIEditSelection

        Private oSurvey As cSurvey
        'Private WithEvents oUndo As cUndo
        Private WithEvents oUndo As cUndo

        Private oCurrentSegment As cSegment
        Private oSegments As UIHelpers.cSegmentsBindingList
        Private oCurrentSegments As cISegmentCollection
        Private oCurrentTrigpoint As cTrigPoint

        Private WithEvents oPlanTools As cEditDesignTools
        Private WithEvents oProfileTools As cEditDesignTools
        Private WithEvents oThreeDTools As cEditDesignTools

        Public Class cEditBaseToolsEventArgs
            Private oCurrentSegment As cSegment
            Private oCurrentTrigpoint As cTrigPoint

            Private oPreviousSegment As cSegment
            Private oPreviousTrigpoint As cTrigPoint

            Friend Sub New(ByVal Tool As cEditTools, PreviousSegment As cSegment, PreviousTrigpoint As cTrigPoint)
                oCurrentSegment = Tool.CurrentSegment
                oCurrentTrigpoint = Tool.CurrentTrigpoint
                oPreviousSegment = PreviousSegment
                oPreviousTrigpoint = PreviousTrigpoint
            End Sub

            Friend Sub New(ByVal CurrentSegment As cSegment, ByVal CurrentTrigpoint As cTrigPoint, PreviousSegment As cSegment, PreviousTrigpoint As cTrigPoint)
                oCurrentSegment = CurrentSegment
                oCurrentTrigpoint = CurrentTrigpoint
                oPreviousSegment = PreviousSegment
                oPreviousTrigpoint = PreviousTrigpoint
            End Sub

            Public ReadOnly Property CurrentSegment() As cSegment
                Get
                    Return oCurrentSegment
                End Get
            End Property

            Public ReadOnly Property CurrentTrigpoint() As cTrigPoint
                Get
                    Return oCurrentTrigpoint
                End Get
            End Property

            Public ReadOnly Property PreviousSegment() As cSegment
                Get
                    Return oPreviousSegment
                End Get
            End Property

            Public ReadOnly Property PreviousTrigpoint() As cTrigPoint
                Get
                    Return oPreviousTrigpoint
                End Get
            End Property
        End Class

        Public ReadOnly Property Segments As UIHelpers.cSegmentsBindingList
            Get
                Return oSegments
            End Get
        End Property

        Friend Event OnUndoChanged(sender As Object, e As EventArgs)
        Friend Event OnSegmentSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditBaseToolsEventArgs)
        Friend Event OnTrigPointSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditBaseToolsEventArgs)

        Public Function GetDesignTools(Item As cItem) As cEditDesignTools
            If Item.Design Is oPlanTools.Design Then
                Return oPlanTools
            ElseIf Item.Design Is oProfileTools.Design Then
                Return oProfileTools
            ElseIf item.Design Is oThreeDTools.Design Then
                Return oThreeDTools
            End If
        End Function

        Public Function GetDesignTools(Layer As cLayer) As cEditDesignTools
            If Layer.Design Is oPlanTools.Design Then
                Return oPlanTools
            ElseIf Layer.Design Is oProfileTools.Design Then
                Return oProfileTools
                '3d not supported...
            ElseIf Layer.Design Is oThreeDTools.Design Then
                Return oThreeDTools
            End If
        End Function

        Public Function GetDesignTools(Design As cDesign) As cEditDesignTools
            If Design Is oPlanTools.Design Then
                Return oPlanTools
            ElseIf Design Is oProfileTools.Design Then
                Return oProfileTools
            ElseIf Design Is oThreeDTools.Design Then
                Return oThreeDTools
            End If
        End Function

        Public ReadOnly Property [ThreeDTools] As cEditDesignTools
            Get
                Return oThreeDTools
            End Get
        End Property

        Public ReadOnly Property PlanTools As cEditDesignTools
            Get
                Return oPlanTools
            End Get
        End Property

        Public ReadOnly Property ProfileTools As cEditDesignTools
            Get
                Return oProfileTools
            End Get
        End Property

        Public Sub SelectTrigpoint(ByVal Trigpoint As cTrigPoint)
            If Not Trigpoint Is oCurrentTrigpoint Then
                Dim oPreviousTrigpoint As cTrigPoint = oCurrentTrigpoint
                oCurrentTrigpoint = Trigpoint
                Dim oArgs As cEditBaseToolsEventArgs = New cEditBaseToolsEventArgs(Me, Nothing, oPreviousTrigpoint)
                RaiseEvent OnTrigPointSelect(Me, oArgs)
            End If
        End Sub

        Public Sub SelectSegment(ByVal Segment As cSegment)
            If Not Segment Is oCurrentSegment Then
                Dim oPreviousSegment As cSegment = oCurrentSegment
                oCurrentSegment = Segment
                Dim oArgs As cEditBaseToolsEventArgs = New cEditBaseToolsEventArgs(Me, oPreviousSegment, Nothing)
                RaiseEvent OnSegmentSelect(Me, oArgs)
            End If
        End Sub

        Public ReadOnly Property Survey() As cSurvey Implements cIEditSelection.CurrentSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property CurrentTrigpoint() As cTrigPoint Implements cIEditSelection.CurrentTrigpoint
            Get
                Return oCurrentTrigpoint
            End Get
        End Property

        Public ReadOnly Property CurrentSegment() As cSegment Implements cIEditSelection.CurrentSegment
            Get
                Return oCurrentSegment
            End Get
        End Property

        Friend Overridable Sub Clear()
            oCurrentSegment = Nothing
            oCurrentTrigpoint = Nothing
        End Sub

        Public ReadOnly Property CurrentSegments() As cISegmentCollection
            Get
                Return oCurrentSegments
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oSegments = New UIHelpers.cSegmentsBindingList(oSurvey.Segments)
            oCurrentSegments = oSurvey.Segments

            'oUndo = New cUndo(oSurvey, Me)
            oUndo = New cUndo(oSurvey, Me)
            oPlanTools = New cEditDesignTools(Me, oSurvey.Plan)
            oProfileTools = New cEditDesignTools(Me, oSurvey.Profile)
            oThreeDTools = New cEditDesignTools(Me, oSurvey.ThreeD)
        End Sub

        Public ReadOnly Property Undo() As cUndo
            Get
                Return oUndo
            End Get
        End Property

        'Public ReadOnly Property Undo() As cUndo
        '    Get
        '        Return oUndo
        '    End Get
        'End Property

        Public Sub DeleteSegment(Segment As cSegment)
            If Not Segment Is Nothing Then
                'Call oUndo.Push("Elimina segmento", cUndo.ActionEnum.Delete, Segment)
                Call oSurvey.Segments.Remove(Segment)
                If Segment Is oCurrentSegment Then
                    Call SelectSegment(Nothing)
                End If
            End If
        End Sub

        Public Sub DeleteSegment()
            If Not oCurrentSegment Is Nothing Then
                'Call oUndo.Push("Elimina segmento", cUndo.ActionEnum.Delete, oCurrentSegment)
                Call oSurvey.Segments.Remove(oCurrentSegment)
            End If
        End Sub

        Friend Function PasteSegments(Optional ByVal Format As String = "", Optional ByVal InsertAt As Integer = -1, Optional CurrentSession As cSession = Nothing, Optional CurrentCave As cCaveInfo = Nothing, Optional CurrentBranch As cCaveInfoBranch = Nothing) As List(Of cSegment)
            Dim oPastedSegments As List(Of cSegment) = New List(Of cSegment)
            If InsertAt = -1 Then
                InsertAt = oSurvey.Segments.Count - 1
            End If
            Try
                If Clipboard.ContainsData("csurvey.segments") Then
                    Dim bCleanPastedStation As Boolean = My.Application.Settings.GetSetting("clipboard.cleanpastedstation", 0)
                    Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                        Dim oXML As XmlDocument = New XmlDocument
                        oXML.LoadXml(Clipboard.GetData("csurvey.segments"))
                        Dim oXMLParent As XmlElement = oXML.Item("parent")
                        Dim bIsSameSurvey As Boolean = oXMLParent.GetAttribute("_id") = oSurvey.ID
                        If Not bIsSameSurvey Then
                            Dim oPastedDataFields As Data.cDataFields = New Data.cDataFields(oSurvey, oXMLParent.Item("datatables").Item("segments"))
                            Call oSurvey.Properties.DataTables.Segments.MergeWith(oPastedDataFields)
                        End If
                        For Each oXMLItem As XmlElement In oXMLParent.Item("segments")
                            Dim oSegment As cSegment = New cSegment(oSurvey, oFile, oXMLItem)
                            If Not oSurvey.Segments.Find(oSegment.To, oSegment.From) Is Nothing And bCleanPastedStation Then
                                oSegment.From = ""
                                oSegment.To = ""
                            End If
                            If Not oSurvey.Properties.CaveInfos.Contains(oSegment.Cave) Then
                                Call oSegment.SetCave("", "")
                            Else
                                If Not oSurvey.Properties.CaveInfos(oSegment.Cave).Branches.Contains(oSegment.Branch) Then
                                    Call oSegment.SetCave(oSegment.Cave, "")
                                End If
                            End If
                            If bIsSameSurvey Then
                                If Not oSurvey.Properties.Sessions.Contains(oSegment.Session) Then
                                    Call oSegment.SetSession("")
                                End If
                            Else
                                Call oSegment.SetSession("")
                            End If
                            If InsertAt = -1 Then
                                Call oSurvey.Segments.Append(oSegment)
                            Else
                                Call oSurvey.Segments.Insert(InsertAt, oSegment)
                                InsertAt += 1
                            End If
                            Call oPastedSegments.Add(oSegment)
                        Next
                    End Using
                ElseIf Clipboard.ContainsText Then
                    Dim sLines() As Object = Strings.Split(Clipboard.GetText, vbCrLf)
                    For Each sLine As String In sLines
                        Dim sValues() As String = Strings.Split(sLine, vbTab)

                        Dim sDeformattedValues() As String = sValues.Clone
                        Dim iValueIndex As Integer = 0
                        For Each sValue As String In sValues
                            If sValue.StartsWith("""") Then
                                sValue = sValue.Substring(1)
                            End If
                            If sValue.EndsWith("""") Then
                                sValue = sValue.Substring(0, sValue.Length - 1)
                            End If
                            sDeformattedValues(iValueIndex) = sValue
                            iValueIndex += 1
                        Next

                        Dim oSegment As cSegment = New cSegment(oSurvey)
                        Call oSegment.SetCave(CurrentCave, CurrentBranch)
                        Call oSegment.SetSession(CurrentSession)
                        Dim iColumn As Integer = -1
                        iColumn = pFindNextValue(sDeformattedValues, iColumn)
                        If Not iColumn = -1 Then
                            Dim sFrom As String = sDeformattedValues(iColumn).Trim
                            iColumn = pFindNextValue(sDeformattedValues, iColumn)
                            If Not iColumn = -1 Then
                                Dim sTo As String = sDeformattedValues(iColumn).Trim

                                If sFrom <> "" Then
                                    If sTo = "" OrElse sTo = "*" OrElse sTo Like "*(*)" Then
                                        oSegment.From = sFrom
                                        oSegment.To = oSurvey.Segments.GetSplayName(sFrom)
                                        oSegment.Splay = True
                                    Else
                                        If oSurvey.Segments.Find(sFrom, sTo) Is Nothing Then
                                            oSegment.From = sFrom
                                            oSegment.To = sTo
                                        Else
                                            oSegment.From = ""
                                            oSegment.To = ""
                                        End If
                                    End If
                                Else
                                    oSegment.From = ""
                                    oSegment.To = ""
                                End If

                                iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                If Not iColumn = -1 Then
                                    Try : oSegment.Distance = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                    iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                    If Not iColumn = -1 Then
                                        Try : oSegment.Bearing = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                        iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                        If Not iColumn = -1 Then
                                            Try : oSegment.Inclination = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try

                                            iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                            If Not iColumn = -1 Then
                                                Try : oSegment.Left = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                                If Not iColumn = -1 Then
                                                    Try : oSegment.Right = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                    iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                                    If Not iColumn = -1 Then
                                                        Try : oSegment.Up = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                        iColumn = pFindNextValue(sDeformattedValues, iColumn)
                                                        If Not iColumn = -1 Then
                                                            Try : oSegment.Down = modNumbers.StringToDecimal(sDeformattedValues(iColumn)) : Catch : End Try
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                Call oSurvey.Segments.Insert(InsertAt, oSegment)
                            End If
                        End If
                        InsertAt += 1
                        Call oPastedSegments.Add(oSegment)
                    Next
                End If
            Catch ex As Exception

            End Try
            Return oPastedSegments
        End Function

        Private Function pFindNextValue(ByVal Values() As String, ByVal Index As Integer) As Integer
            If Index < Values.Length - 1 Then
                Index += 1
                Do
                    Dim sValue As String = Values(Index)
                    If sValue <> "" Then Return Index
                    Index += 1
                Loop While Index < Values.Length
                Return -1
            Else
                Return -1
            End If
        End Function

        Public Sub CopySegments(ByVal Segments As cSegmentCollection)
            Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                Dim oXML As XmlDocument = oFile.Document
                Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
                Call oXMLParent.SetAttribute("_id", oSurvey.ID)

                Dim oXMLDataTables As XmlElement = oXML.CreateElement("datatables")
                Call oSurvey.Properties.DataTables.Segments.SaveTo(oFile, oXML, oXMLDataTables)
                Call oXMLParent.AppendChild(oXMLDataTables)

                Dim oXMLSegments As XmlElement = oXML.CreateElement("segments")
                For Each oSegment As cSegment In Segments
                    Call oSegment.SaveTo(oFile, oXML, oXMLSegments, cSurvey.SaveOptionsEnum.ForClipboard)
                Next
                Call oXMLParent.AppendChild(oXMLSegments)

                Call oXML.AppendChild(oXMLParent)

                Dim oDataObject As DataObject = New DataObject
                Call oDataObject.SetData("csurvey.segments", oXML.InnerXml)

                Dim sExtFormats As String = My.Application.Settings.GetSetting("clipboard.segments.extformats", "")
                Dim bUseLocalFormat As Boolean = My.Application.Settings.GetSetting("clipboard.uselocalformat", False)
                If sExtFormats.Contains("csv") Then
                    Dim bBuffer() As Byte = System.Text.Encoding.UTF8.GetBytes(Segments.ToCSV(bUseLocalFormat))
                    Dim oMS As System.IO.MemoryStream = New System.IO.MemoryStream(bBuffer)
                    Call oDataObject.SetData(System.Windows.Forms.DataFormats.CommaSeparatedValue, oMS)
                    'Call oDataObject.SetText(Segments.ToCSV(bUseLocalFormat), TextDataFormat.CommaSeparatedValue)
                End If
                If sExtFormats.Contains("txt") Then
                    Call oDataObject.SetText(Segments.ToTSV(bUseLocalFormat), TextDataFormat.Text)
                End If
                Call Clipboard.SetDataObject(oDataObject)
            End Using
        End Sub

        Public Sub CutSegments(ByVal Segments As cSegmentCollection)
            Using oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
                Dim oXML As XmlDocument = oFile.Document
                Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
                Call oXMLParent.SetAttribute("_id", oSurvey.ID)
                For Each oSegment As cSegment In Segments
                    Call oSegment.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.ForClipboard)
                Next
                Call oXML.AppendChild(oXMLParent)

                Dim oDataObject As DataObject = New DataObject
                Call oDataObject.SetData("csurvey.segments", oXML.InnerXml)

                Dim sExtFormats As String = My.Application.Settings.GetSetting("clipboard.segments.extformats", "")
                Dim bUseLocalFormat As Boolean = My.Application.Settings.GetSetting("clipboard.uselocalformat", False)
                If sExtFormats.Contains("csv") Then
                    Dim bBuffer() As Byte = System.Text.Encoding.UTF8.GetBytes(Segments.ToCSV(bUseLocalFormat))
                    Dim oMS As System.IO.MemoryStream = New System.IO.MemoryStream(bBuffer)
                    Call oDataObject.SetData(System.Windows.Forms.DataFormats.CommaSeparatedValue, oMS)
                    'Call oDataObject.SetText(Segments.ToCSV(bUseLocalformat), TextDataFormat.CommaSeparatedValue)
                End If
                If sExtFormats.Contains("txt") Then
                    Call oDataObject.SetText(Segments.ToTSV(bUseLocalFormat), TextDataFormat.Text)
                End If
                Call Clipboard.SetDataObject(oDataObject)
                Call DeleteSegment()
            End Using
        End Sub

        Private Sub oUndo_OnChanged(sender As Object, e As EventArgs) Handles oUndo.OnChanged
            RaiseEvent OnUndoChanged(sender, e)
        End Sub
    End Class

    Friend Class cFilter
        Private oSurvey As cSurvey

        Private sName As String
        Private iCategory As cIItem.cItemCategoryEnum?
        Private oDataProperties As Data.cDataProperties

        Private sCave As String
        Private sBranch As String

        Private bReversed As Boolean

        Friend Function Apply(Item As cItem) As Boolean
            Dim bOk As Boolean = True
            If "" & sName <> "" Then
                bOk = bOk And Item.Name Like sName
            End If
            If iCategory.HasValue Then
                bOk = bOk And Item.Category = iCategory.Value
            End If
            If sCave <> "" Then
                bOk = bOk And Item.Cave.ToLower = sCave.ToLower
            End If
            If sBranch <> "" Then
                bOk = bOk And Item.Branch.ToLower = sBranch.ToLower
            End If
            For Each oField As Data.cDataField In oDataProperties.Fields
                Dim oValue As Object = oDataProperties.GetValue(oField.Name, Nothing)
                If Not oValue Is Nothing Then
                    If oField.Type = Data.cDataFields.TypeEnum.Text Then
                        Dim sItemValue As String = Item.DataProperties.GetValue(oField.Name, Nothing)
                        Dim sValue As String = oValue.ToString
                        bOk = bOk And (sItemValue Like sValue)
                    Else
                        Dim oItemValue As Object = Item.DataProperties.GetValue(oField.Name, Nothing)
                        bOk = bOk And oItemValue = oValue
                    End If
                End If
            Next
            If bReversed Then
                Return bOk
            Else
                Return Not bOk
            End If
        End Function

        Public Property Reversed As Boolean
            Get
                Return bReversed
            End Get
            Set(value As Boolean)
                If bReversed <> value Then
                    bReversed = value
                End If
            End Set
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                If sName <> value Then
                    sName = value
                End If
            End Set
        End Property

        Public Property Cave As String
            Get
                Return sCave
            End Get
            Set(value As String)
                If sCave <> value Then
                    sCave = value
                End If
            End Set
        End Property

        Public Property Branch As String
            Get
                Return sBranch
            End Get
            Set(value As String)
                If sBranch <> value Then
                    sBranch = value
                End If
            End Set
        End Property

        Public Property Category As cIItem.cItemCategoryEnum?
            Get
                Return iCategory
            End Get
            Set(value As cIItem.cItemCategoryEnum?)
                If iCategory <> value Then
                    iCategory = value
                End If
            End Set
        End Property

        Public ReadOnly Property DataProperties As Data.cDataProperties
            Get
                Return oDataProperties
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            sName = ""
            sCave = ""
            sBranch = ""
            oDataProperties = New Data.cDataProperties(oSurvey, oSurvey.Properties.DataTables.DesignItems)
        End Sub

        Public Function Clone() As cFilter
            Dim oFilter As cFilter = New cFilter(oSurvey)
            'oFilter.FilterType = iType
            oFilter.sName = sName
            oFilter.iCategory = iCategory
            oFilter.sCave = sCave
            oFilter.sBranch = sBranch
            oFilter.bReversed = bReversed
            Call oFilter.DataProperties.CopyFrom(oDataProperties)
            Return oFilter
        End Function

        Public Sub CopyFrom(Filter As cFilter)
            'iType = Filter.iType
            sName = Filter.sName
            iCategory = Filter.iCategory
            sCave = Filter.sCave
            sBranch = Filter.sBranch
            Call oDataProperties.CopyFrom(Filter.oDataProperties)
            bReversed = Filter.bReversed
        End Sub
    End Class

    Friend Class cPasteSpecialEventArgs
        Inherits EventArgs

        Private oBag As Object
        Private oLocation As PointF

        Private oItems As List(Of cItem)

        Public ReadOnly Property Bag As Object
            Get
                Return oBag
            End Get
        End Property

        Public ReadOnly Property Location As PointF
            Get
                Return oLocation
            End Get
        End Property

        Public ReadOnly Property Items As List(Of cItem)
            Get
                Return oItems
            End Get
        End Property

        Friend Sub New(ByVal Bag As Object, ByVal Location As PointF)
            oBag = Bag
            oLocation = Location
            oItems = New List(Of cItem)
        End Sub
    End Class

    Friend Class cEditDesignToolsEventArgs
        Inherits EventArgs

        Private oCurrentLayer As cLayer
        Private oCurrentItem As cItem
        Private oCurrentItemPoint As cPoint
        Private bIsNewItem As Boolean

        Friend Sub New(ByVal Tools As cEditDesignTools)
            oCurrentLayer = Tools.CurrentLayer
            oCurrentItem = Tools.CurrentItem
            oCurrentItemPoint = Tools.CurrentItemPoint
            bIsNewItem = Tools.IsNewItem
        End Sub

        Friend Sub New(ByVal CurrentLayer As cLayer, ByVal CurrentItem As cItem, ByVal CurrentItemPoint As cPoint, ByVal IsNewItem As Boolean)
            oCurrentLayer = CurrentLayer
            oCurrentItem = CurrentItem
            oCurrentItemPoint = CurrentItemPoint
            bIsNewItem = IsNewItem
        End Sub

        Public ReadOnly Property IsNewItem As Boolean
            Get
                Return bIsNewItem
            End Get
        End Property

        Public ReadOnly Property CurrentLayer() As cLayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public ReadOnly Property CurrentItem() As cItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint() As cPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property
    End Class

    Friend Class cCrossSectionSelectEventArgs
        Inherits EventArgs
    End Class

    Friend Class cCaveBranchSelectEventArgs
        Inherits EventArgs
    End Class

    Friend Class cChangeDesignEventArgs
        Inherits EventArgs

        Private oNewTools As cEditDesignTools

        Friend Sub New(NewTools As cEditDesignTools)
            oNewTools = NewTools
        End Sub

        Friend ReadOnly Property NewTool As cEditDesignTools
            Get
                Return oNewTools
            End Get
        End Property
    End Class

    Friend Class cFilterEventArgs
        Inherits EventArgs

        Private bRefresh As Boolean

        Friend Sub New(Refresh As Boolean)
            bRefresh = Refresh
        End Sub

        Public ReadOnly Property Refresh As Boolean
            Get
                Return bRefresh
            End Get
        End Property
    End Class

    Friend Class cMarkedDesktopPointMoveEventArgs
        Inherits cMarkedDesktopPoint.cMoveEventArgs

        Private oMarkedDesktopPoint As cMarkedDesktopPoint

        Public ReadOnly Property MarkedDesktopPoint As cMarkedDesktopPoint
            Get
                Return oMarkedDesktopPoint
            End Get
        End Property

        Public Sub New(MarkedDesktopPoint As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cMoveEventArgs)
            Call MyBase.New(Args.NewPoint)
            oMarkedDesktopPoint = MarkedDesktopPoint
        End Sub
    End Class

    Friend Class cMarkedDesktopPointPaintInfoEventArgs
        Inherits cMarkedDesktopPoint.cPaintInfoEventArgs

        Private oMarkedDesktopPoint As cMarkedDesktopPoint

        Public ReadOnly Property MarkedDesktopPoint As cMarkedDesktopPoint
            Get
                Return oMarkedDesktopPoint
            End Get
        End Property

        Public Sub New(MarkedDesktopPoint As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cPaintInfoEventArgs)
            MyBase.New()
            oMarkedDesktopPoint = MarkedDesktopPoint
        End Sub
    End Class

    Friend Class cEditDesignTools
        Implements cIEditDesignSelection

        Private oSurvey As cSurvey

        Private oParent As cEditTools
        Private oDesign As cDesign

        Public LastPoint As PointF
        Public CurrentPoint As PointF
        Public LastCenterPoint As PointF
        Public LastBounds As RectangleF
        Public LastAngle As Single
        Public LastAnchor As AnchorRectangleTypeEnum

        Private bIsNewItem As Boolean
        Private bStarted As Boolean

        Private bIsInPointEdit As Boolean
        Private bIsNewPoint As Boolean
        Private oNewPointRelative As cPoint
        Private bIsInEdit As Boolean
        Private bIsInCombine As Boolean

        Private oCurrentLayer As cLayer
        Private oCurrentItem As cItem
        Private oCurrentItemPoint As cPoint
        Private oLastItemPoint As cPoint

        Private sCurrentCave As String = ""
        Private sCurrentBranch As String = ""
        Private iCurrentBindDesignType As cItem.BindDesignTypeEnum
        Private sCurrentCrossSection As String = ""

        Private WithEvents oCurrentMarkedDesktopPoint As cMarkedDesktopPoint

        Private WithEvents oFilter As cFilter
        Private bIsFiltered As Boolean
        Private bFilterWhiteBoard As Boolean

        Friend Event OnFilterApplied(ByVal Sender As Object, ByVal ToolEventArgs As cFilterEventArgs)
        Friend Event OnFilterRemoved(ByVal Sender As Object, ByVal ToolEventArgs As cFilterEventArgs)

        Public ReadOnly Property Undo As cUndo
            Get
                Return oParent.Undo
            End Get
        End Property

        Public Overridable ReadOnly Property Design As cDesign
            Get
                Return oDesign
            End Get
        End Property

        'use this property in UI to bind a button for reversing filter
        Public Property FilterReversed As Boolean
            Get
                Return oFilter.Reversed
            End Get
            Set(value As Boolean)
                If value <> oFilter.Reversed Then
                    oFilter.Reversed = value
                    RaiseEvent OnFilterApplied(Me, New cFilterEventArgs(True))
                End If
            End Set
        End Property

        Public Property FilterWhiteBoard As Boolean
            Get
                Return bFilterWhiteBoard
            End Get
            Set(value As Boolean)
                If value <> bFilterWhiteBoard Then
                    bFilterWhiteBoard = value
                    RaiseEvent OnFilterApplied(Me, New cFilterEventArgs(True))
                End If
            End Set
        End Property

        Public Sub FilterApply(Optional Refresh As Boolean = True)
            bIsFiltered = True
            Threading.Tasks.Parallel.ForEach(Of cItem)(oDesign.GetAllItems, Sub(oItem)
                                                                                oItem.FilteredInDesign = Filter.Apply(oItem)
                                                                            End Sub)
            RaiseEvent OnFilterApplied(Me, New cFilterEventArgs(Refresh))
        End Sub

        Public Sub FilterRemove(Optional Refresh As Boolean = True)
            bIsFiltered = False
            Threading.Tasks.Parallel.ForEach(Of cItem)(oDesign.GetAllItems, Sub(oItem)
                                                                                oItem.FilteredInDesign = False
                                                                            End Sub)

            RaiseEvent OnFilterRemoved(Me, New cFilterEventArgs(Refresh))
        End Sub

        Public Sub FilterToggle()
            If bIsFiltered Then
                Call FilterRemove()
            Else
                Call FilterApply()
            End If
        End Sub

        Public ReadOnly Property IsFiltered As Boolean
            Get
                Return bIsFiltered
            End Get
        End Property

        Public ReadOnly Property Filter As cFilter
            Get
                Return oFilter
            End Get
        End Property

        Public ReadOnly Property CurrentMarkedDesktopPoint() As cMarkedDesktopPoint
            Get
                Return oCurrentMarkedDesktopPoint
            End Get
        End Property

        Public ReadOnly Property IsNewItem() As Boolean
            Get
                Return bIsNewItem
            End Get
        End Property

        Protected Sub SetCurrentItem(CurrentItem As cItem)
            oCurrentItem = CurrentItem
        End Sub

        Protected Sub RaiseOnItemDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
            RaiseEvent OnItemDelete(Sender, ToolEventArgs)
        End Sub

        Protected Sub RaiseOnItemDeleted(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
            RaiseEvent OnItemDeleted(Sender, ToolEventArgs)
        End Sub

        Friend Event OnRefreshDesign(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)

        Friend Event OnItemSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemCombine(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemDeleted(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemPointDelete(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemPointEdit(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemPointEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnItemEnd(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)
        Friend Event OnLayerSelect(ByVal Sender As Object, ByVal ToolEventArgs As cEditDesignToolsEventArgs)

        Friend Event OnLastPointChange(ByVal Sender As Object, ByVal ToolEventArgs As EventArgs)

        Friend Event OnChangeDesign(Sender As Object, ByVal ChangeDesignEventArgs As cChangeDesignEventArgs)

        Friend Event OnCaveBranchSelect(ByVal Sender As Object, ByVal ToolEventArgs As cCaveBranchSelectEventArgs)
        Friend Event OnCrossSectionSelect(ByVal Sender As Object, ByVal ToolEventArgs As cCrossSectionSelectEventArgs)

        Public Sub SelectLayer(ByVal Layer As cLayer)
            If IsNothing(Layer) OrElse (Layer.Design Is oDesign) Then
                If Not Layer Is oCurrentLayer Then
                    Call [EndItem](False)
                    oCurrentLayer = Layer
                    RaiseEvent OnLayerSelect(Me, New cEditDesignToolsEventArgs(Me))
                End If
            Else
                Dim oNewTools As cEditDesignTools = oParent.GetDesignTools(Layer)
                Call oNewTools.pRaiseOnChange()
                Call oNewTools.SelectLayer(Layer)
            End If
        End Sub

        Public Sub RefreshTools()
            If Not oCurrentItem Is Nothing Then
                LastCenterPoint = oCurrentItem.GetCenterPoint
                LastBounds = oCurrentItem.GetBounds
            End If
        End Sub

        Public Sub [SelectItem](ByVal Item As cItem)
            If IsNothing(Item) OrElse (Item.Design Is oDesign) Then
                Dim bOnlyRefresh As Boolean
                If oCurrentItem Is Item Then
                    If Not oCurrentItem Is Nothing Then
                        If oCurrentItem.HaveEditablePoints Then
                            bIsInPointEdit = Not bIsInPointEdit
                        Else
                            bIsInPointEdit = False
                        End If
                        bOnlyRefresh = bIsInPointEdit OrElse (Not bIsInPointEdit AndAlso oCurrentItemPoint Is Nothing)
                    Else
                        bIsInPointEdit = False
                    End If
                Else
                    Call [EndItem](False)
                    bIsInPointEdit = False
                    If Not Item Is Nothing AndAlso Not oCurrentLayer Is Item.Layer AndAlso Not Item.Layer Is Nothing Then
                        oCurrentLayer = Item.Layer
                        RaiseEvent OnLayerSelect(Me, New cEditDesignToolsEventArgs(Me))
                    End If
                    oCurrentItem = Item
                End If

                Call RefreshTools()
                bIsInEdit = False
                bIsInCombine = False
                bIsNewItem = False
                bStarted = False
                If bOnlyRefresh Then
                    RaiseEvent OnRefreshDesign(Me, New cEditDesignToolsEventArgs(Me))
                Else
                    RaiseEvent OnItemSelect(Me, New cEditDesignToolsEventArgs(Me))
                End If
            Else
                Dim oNewTools As cEditDesignTools = oParent.GetDesignTools(Item)
                Call oNewTools.pRaiseOnChange()
                Call oNewTools.[SelectItem](Item)
            End If
        End Sub

        Friend Sub ResetNewItem()
            bIsNewItem = False
        End Sub

        Private Sub pRaiseOnChange()
            RaiseEvent OnChangeDesign(Me, New cChangeDesignEventArgs(Me))
        End Sub

        Public Sub SelectBindDesignType(ByVal BindDesignType As cItem.BindDesignTypeEnum)
            If iCurrentBindDesignType <> BindDesignType Then
                iCurrentBindDesignType = BindDesignType
            End If
        End Sub

        Public Sub SelectCrossSection(CrossSection As cDesignCrossSection)
            Call SelectCrossSection(CrossSection.ID)
        End Sub

        Public Sub SelectCrossSection(CrossSection As String)
            If (CrossSection <> sCurrentCrossSection) Then
                sCurrentCrossSection = CrossSection
                RaiseEvent OnCrossSectionSelect(Me, New cCrossSectionSelectEventArgs)
            End If
        End Sub

        Public Sub [SelectCave](ByVal CaveBranch As cCaveInfoBranch)
            If CaveBranch Is Nothing Then
                Call SelectCave("", "")
            Else
                Call SelectCave(CaveBranch.Cave, CaveBranch.Path)
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As cCaveInfo)
            If Cave Is Nothing Then
                Call SelectCave("", "")
            Else
                Call SelectCave(Cave.Name, "")
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As cCaveInfo, Optional ByVal CaveBranch As cCaveInfoBranch = Nothing)
            If Cave Is Nothing Then
                Call SelectCave("")
            Else
                Call SelectCave(Cave.Name, If(CaveBranch Is Nothing, "", CaveBranch.Path))
            End If
        End Sub

        Public Sub [SelectCave](ByVal Cave As String, Optional ByVal CaveBranch As String = "")
            If (Cave <> sCurrentCave) OrElse (CaveBranch <> sCurrentBranch) Then
                sCurrentCave = Cave
                If sCurrentCave <> "" Then
                    sCurrentBranch = CaveBranch
                Else
                    sCurrentBranch = ""
                End If
                RaiseEvent OnCaveBranchSelect(Me, New cCaveBranchSelectEventArgs)
            End If
        End Sub

        Public Sub EditItem(ByVal Item As cItem, Optional ByVal IsNewItem As Boolean = False)
            Call [EndItem](False)
            oCurrentItem = Item
            If Not oCurrentLayer Is Item.Layer And Not Item.Layer Is Nothing Then
                oCurrentLayer = Item.Layer
                RaiseEvent OnLayerSelect(Me, New cEditDesignToolsEventArgs(Me))
            End If
            oCurrentItemPoint = Nothing
            bIsInEdit = True
            bIsInCombine = False
            If IsNewItem Then
                bIsNewItem = True
                bStarted = False
            Else
                bIsNewItem = False
                bStarted = False
            End If
            RaiseEvent OnItemEdit(Me, New cEditDesignToolsEventArgs(Me))
        End Sub

        Public Sub CombineItem(ByVal Item As cItem)
            Call [EndItem](False)
            oCurrentItem = Item
            oCurrentItemPoint = Nothing
            'bIsInEdit = False
            bIsInCombine = True
            'bIsNewItem = False
            'bStarted = False
            RaiseEvent OnItemCombine(Me, New cEditDesignToolsEventArgs(Me))
        End Sub

        Public Sub EndAndSelectItem()
            Dim oItem As cItem = oCurrentItem
            '-----------------------------------------------
            'END
            Call pEndItem()
            '-----------------------------------------------
            If Not oItem Is Nothing Then
                If Not oItem.Deleted Then
                    oCurrentItem = oItem
                    'Call SelectItem(oItem)
                    Call RefreshTools()
                    bIsInEdit = False
                    bIsInCombine = False
                    bIsNewItem = False
                    bStarted = False
                    RaiseEvent OnRefreshDesign(Me, New cEditDesignToolsEventArgs(Me))

                    'Call oParent.Undo.Push("Modifica oggetto", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                End If
            End If
        End Sub

        Private Function pItemFromStorage(XML As XmlDocument, Design As cDesign, PerformSelectItem As Boolean, Optional PerformEditItem As Boolean = True) As cItem
            Dim oPastedItem As cItem = Nothing
            Dim oXMLItem As XmlElement = XML.Item("parent").FirstChild
            Dim iType As cIItem.cItemTypeEnum = oXMLItem.GetAttribute("type")
            If iType = cIItem.cItemTypeEnum.Items Then
                Dim oItems As Items.cItemItems = New Items.cItemItems(oSurvey, oCurrentLayer.Design, oCurrentLayer, cIItem.cItemCategoryEnum.None)
                For Each oXmlSubItem As XmlElement In oXMLItem.Item("items")
                    Try
                        Dim iLayerType As cLayers.LayerTypeEnum = oXmlSubItem.GetAttribute("layer")
                        Dim oFile As cFile = New cFile(cFile.FileFormatEnum.CSX)
                        Dim oItem As cItem = Design.Layers(iLayerType).CreateItem(oFile, oXmlSubItem)
                        If PerformEditItem Then Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                        Call oItems.Add(oItem)
                        Call EndItem()
                    Catch ex As Exception
                        Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Error, "paste error: " & ex.Message)
                    End Try
                Next
                oPastedItem = oItems
                If PerformSelectItem Then
                    oCurrentItem = Nothing
                    Call SelectItem(oItems)
                End If
            Else
                Dim iLayerType As cLayers.LayerTypeEnum = oXMLItem.GetAttribute("layer")
                Dim oFile As cFile = New cFile(cFile.FileFormatEnum.CSX)
                Dim oItem As cItem = Design.Layers(iLayerType).CreateItem(oFile, oXMLItem)
                If oItem.Type = cIItem.cItemTypeEnum.CrossSection Then
                    Call oSurvey.CrossSections.Add(oItem)
                End If
                If PerformEditItem Then Call EditItem(oItem, True)
                Call EndItem()
                oPastedItem = oItem
                If PerformSelectItem Then
                    oCurrentItem = Nothing
                    Call SelectItem(oItem)
                End If
            End If
            Return oPastedItem
        End Function

        Public Enum PasteSpecialEnum
            None = 0
            Pen = 1
            Brush = 2
        End Enum

        Public Function PasteItem(Optional ByVal Format As String = "", Optional ByVal Location As PointF = Nothing, Optional Special As PasteSpecialEnum = PasteSpecialEnum.None) As cItem
            Dim oPastedItem As cItem = Nothing
            Try
                If Format = "" Then
                    If Clipboard.ContainsData("csurvey.item") Then
                        Dim oXML As XmlDocument = New XmlDocument
                        Call oXML.LoadXml(Clipboard.GetText)
                        If Special And PasteSpecialEnum.Pen Then
                            Dim oLastItem As cItem = oCurrentItem
                            oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, False, False)
                            Call oLastItem.Pen.CopyFrom(oPastedItem.Pen)
                            Call oPastedItem.Layer.Items.Remove(oPastedItem)
                            oPastedItem = oLastItem
                            Call SelectItem(oPastedItem)
                        ElseIf Special And PasteSpecialEnum.Brush Then
                            Dim oLastItem As cItem = oCurrentItem
                            oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, False, False)
                            Call oLastItem.Brush.CopyFrom(oPastedItem.Brush)
                            Call oPastedItem.Layer.Items.Remove(oPastedItem)
                            oPastedItem = oLastItem
                            Call SelectItem(oPastedItem)
                        Else
                            oPastedItem = pItemFromStorage(oXML, oCurrentLayer.Design, True)
                            If Not Location.IsEmpty Then Call oPastedItem.MoveTo(Location)
                            Call oPastedItem.SetCave(sCurrentCave, sCurrentBranch, False)
                            Call oPastedItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), True)
                            'Call SelectItem(oPastedItem)
                        End If
                    ElseIf Clipboard.ContainsData("image/svg+xml") Then
                        'si tratta di svg...
                        'tento la creazione di un oggetto GENERIC...
                        Dim sData As String = modSVG.GetSVGDataFromClipboard
                        Dim oItem As Items.cItemGeneric = oCurrentLayer.CreateGeneric(sCurrentCave, sCurrentBranch, sData, Items.cItemGeneric.cItemGenericDataFormatEnum.SVGData)
                        Call oItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), False)
                        Call oItem.MoveTo(Location)
                        Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                        Call EndItem()
                        oPastedItem = oItem
                        Call SelectItem(oPastedItem)
                    ElseIf Clipboard.ContainsImage Then
                        Dim oLayer As Layers.cLayerBase = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.Base)
                        Call SelectLayer(oLayer)
                        Dim oImage As Image = Clipboard.GetImage
                        If Not oImage Is Nothing Then
                            Dim oItem As Items.cItemImage = oLayer.CreateImage(sCurrentCave, sCurrentBranch, oImage)
                            Call oItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), False)
                            Call oItem.MoveTo(Location)
                            Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                            Call EndItem()
                            oPastedItem = oItem
                            Call SelectItem(oPastedItem)
                        End If
                    ElseIf Clipboard.ContainsText Then
                        Dim oLayer As Layers.cLayerSigns = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.Signs)
                        Call SelectLayer(oLayer)
                        Dim sText As String = Clipboard.GetText
                        sText = sText.Trim
                        If sText <> "" Then
                            Dim oItem As Items.cItemText = oLayer.CreateText(sCurrentCave, sCurrentBranch, sText)
                            Call oItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), False)
                            Call oItem.FixBound(True)
                            Call oItem.MoveTo(Location)
                            Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                            Call EndItem()
                            oPastedItem = oItem
                            Call SelectItem(oPastedItem)
                        End If
                    End If
                Else
                    Select Case Format
                        Case "rock", "concretion"
                            If Clipboard.ContainsData("image/svg+xml") Then
                                'si tratta di svg importato...
                                'tento la creazione di un oggetto GENERIC...
                                Dim sData As String = modSVG.GetSVGDataFromClipboard

                                Dim oLayerRocks As Layers.cLayerRocks = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.RocksAndConcretion)
                                Call SelectLayer(oLayerRocks)
                                Dim oItem As Items.cItemClipart = oLayerRocks.CreateRockFromClipart(sCurrentCave, sCurrentBranch, sData, cIItemClipartBase.cClipartDataFormatEnum.SVGData)
                                Call oItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), False)
                                Call oItem.FixBound(True)
                                Call oItem.MoveTo(Location)
                                Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                                Call EndItem()
                                oPastedItem = oItem
                                Call SelectItem(oItem)
                            End If
                        Case "text"
                            If Clipboard.ContainsText Then
                                Dim oLayerSigns As Layers.cLayerSigns = oCurrentLayer.Design.Layers(cLayers.LayerTypeEnum.Signs)
                                Call SelectLayer(oLayerSigns)
                                Dim sText As String = Clipboard.GetText.Trim
                                If sText <> "" Then
                                    Dim oItem As Items.cItemText = oLayerSigns.CreateText(sCurrentCave, sCurrentBranch, sText)
                                    Call oItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), False)
                                    Call oItem.FixBound(True)
                                    Call oItem.MoveTo(Location)
                                    Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                                    Call EndItem()
                                    oPastedItem = oItem
                                    Call SelectItem(oItem)
                                End If
                            End If
                        Case "generic"
                            If Clipboard.ContainsData("image/svg+xml") Then
                                'si tratta di svg importato...
                                'tento la creazione di un oggetto GENERIC...
                                Dim oOptions As Items.cItemGeneric.cItemGenericOptions = New Items.cItemGeneric.cItemGenericOptions(oSurvey)
                                Dim sData As String = modSVG.GetSVGDataFromClipboard
                                Dim oClipart As cDrawClipArt = New cDrawClipArt(sData)
                                Dim oItem As Items.cItemGeneric = oCurrentLayer.CreateGeneric(sCurrentCave, sCurrentBranch, oClipart, oOptions)
                                Call oItem.SetBindDesignType(iCurrentBindDesignType, oSurvey.CrossSections.GetBindItem(sCurrentCrossSection), False)
                                Call oItem.MoveTo(Location)
                                Call EditItem(oItem, True)  'simulo un edit cosi da scatenare l'undo e tutto il resto...
                                Call EndItem()
                                oPastedItem = oItem
                                Call SelectItem(oItem)
                            End If
                    End Select
                End If
            Catch ex As Exception

            End Try
            Return oPastedItem
        End Function

        Private Function pItemToStorage() As XmlDocument
            Dim oFile As cFile = New cFile(cFile.FileFormatEnum.CSX, "", cFile.FileOptionsEnum.EmbedResource)
            Dim oXML As XmlDocument = oFile.Document
            Dim oXMLParent As XmlElement = oXML.CreateElement("parent")
            Call oCurrentItem.SaveTo(oFile, oXML, oXMLParent, cSurvey.SaveOptionsEnum.Silent OrElse cSurvey.SaveOptionsEnum.ForClipboard)
            Call oXML.AppendChild(oXMLParent)
            Return oXML
        End Function

        Public Function CloneItem(Design As cDesign) As cItem
            Dim oXMl As XmlDocument = pItemToStorage()
            Return pItemFromStorage(oXMl, Design, False)
        End Function

        Public Sub CopyItem()
            Dim oXMl As XmlDocument = pItemToStorage()

            Dim oDataObject As DataObject = New DataObject
            Call oDataObject.SetText(oXMl.InnerXml)
            Call oDataObject.SetData("csurvey.item", oXMl.InnerXml)

            Dim sExtFormats As String = My.Application.Settings.GetSetting("clipboard.designitems.extformats", "")
            If sExtFormats.Contains("xml") Then
                Dim oXMLMS As IO.MemoryStream = New IO.MemoryStream
                Call oXMl.Save(oXMLMS)
                Call oDataObject.SetData("xml", oXMLMS)
            End If
            If sExtFormats.Contains("svg") Then
                Dim oSVGMS As IO.MemoryStream = New IO.MemoryStream
                Call oCurrentItem.ToSvg(oSurvey.Options("_design.plan"), cItem.SVGOptionsEnum.Images).Save(oSVGMS)
                Call oDataObject.SetData("image/svg+xml", oSVGMS)
            End If
            Call Clipboard.SetDataObject(oDataObject)
        End Sub

        Public Sub CutItem()
            Dim oXMl As XmlDocument = pItemToStorage()

            Dim oDataObject As DataObject = New DataObject
            Call oDataObject.SetText(oXMl.InnerXml)
            Call oDataObject.SetData("csurvey.item", oXMl.InnerXml)
            Dim sExtFormats As String = My.Application.Settings.GetSetting("clipboard.designitems.extformats", "")

            If sExtFormats.Contains("xml") Then
                Dim oXMLMS As IO.MemoryStream = New IO.MemoryStream
                Call oXMl.Save(oXMLMS)
                Call oDataObject.SetData("xml", oXMLMS)
            End If
            If sExtFormats.Contains("svg") Then
                Dim oSVGMS As IO.MemoryStream = New IO.MemoryStream
                Call oCurrentItem.ToSvg(oSurvey.Options("_design.plan"), cItem.SVGOptionsEnum.None).Save(oSVGMS)
                Call oDataObject.SetData("image/svg+xml", oSVGMS)
            End If
            Call Clipboard.SetDataObject(oDataObject)

            Call DeleteItem()
        End Sub

        Public Sub DeleteItemPoint()
            If oCurrentItem IsNot Nothing Then
                If oCurrentItem.Points.Count > 1 Then
                    Dim iPointIndex As Integer = oCurrentItem.Points.IndexOf(oCurrentItemPoint)
                    If oCurrentItem.Points.Remove(oCurrentItemPoint) Then
                        RaiseEvent OnItemPointDelete(Me, New cEditDesignToolsEventArgs(Me))
                        Dim iCount As Integer = oCurrentItem.Points.Count
                        If iCount > 0 Then
                            If iPointIndex >= iCount Then
                                Call EditPoint(oCurrentItem.Points(iCount - 1))
                            Else
                                Call EditPoint(oCurrentItem.Points(iPointIndex))
                            End If
                        Else
                            Call DeleteItem()
                        End If
                    End If
                Else
                    Call DeleteItem()
                End If
            End If
        End Sub

        Public Overridable Sub DeleteItem()
            If oCurrentItem IsNot Nothing Then
                If oCurrentItem.Type = cIItem.cItemTypeEnum.Items Then
                    Call oCurrentLayer.Items.Remove(oCurrentItem)
                    Dim oItems As cSurveyPC.cSurvey.Design.Items.cItemItems = oCurrentItem
                    For Each oItem As cItem In oItems
                        Call oCurrentLayer.Design.RemoveItem(oItem)
                    Next
                Else
                    Call oCurrentLayer.Items.Remove(oCurrentItem)
                End If
                RaiseEvent OnItemDelete(Me, New cEditDesignToolsEventArgs(Me))
                oCurrentItem = Nothing
                Call EndItem()
                Call SelectItem(Nothing)
                RaiseEvent OnItemDeleted(Me, New cEditDesignToolsEventArgs(Me))
            End If
        End Sub

        Public Sub CreateUndoSnapshot(Description As String, Item As cItem)
            oParent.Undo.CreateSnapshot(Description, {Item})
        End Sub

        Private Function pGetDesignType(Design As cDesign) As cUndo.cAreaEnum
            Select Case Design.Type
                Case cIDesign.cDesignTypeEnum.Plan
                    Return cUndo.cAreaEnum.DesignPlan
                Case cIDesign.cDesignTypeEnum.Profile
                    Return cUndo.cAreaEnum.DesignProfile
                Case cIDesign.cDesignTypeEnum.ThreeDModel
                    Return cAreaEnum.Design3D
            End Select
        End Function

        Public Sub CreateUndoSnapshot(Description As String, PropertyName As String)
            oParent.Undo.CreateSnapshot(Description, pGetDesignType(oDesign), PropertyName)
        End Sub

        Public Sub CreateUndoSnapshot(Description As String, BackupDelegate As cUndoItemBackupValueDelegate, RestoreDelegate As cUndoItemRestoreValueDelegate)
            oParent.Undo.CreateSnapshot(Description, pGetDesignType(oDesign), BackupDelegate, RestoreDelegate)
        End Sub

        Public Sub CreateUndoSnapshot(Description As String)
            oParent.Undo.CreateSnapshot(Description, pGetDesignType(oDesign))
        End Sub

        Public Sub BeginUndoSnapshot(Description As String, Items As IEnumerable(Of cItem))
            oParent.Undo.BeginSnapshot(Description, Items)
        End Sub

        Public Sub BeginUndoSnapshot(Description As String)
            oParent.Undo.BeginSnapshot(Description, pGetDesignType(oDesign))
        End Sub

        Public Sub CreateSelectionSnaphot()
            oParent.Undo.CreateSelectionSnapshot(pGetDesignType(oDesign))
        End Sub

        Public Sub CancelUndoSnapshot()
            Call oParent.Undo.CancelSnapshot()
        End Sub

        Public Sub CommitUndoSnapshot(Optional SkipIfNotBeginned As Boolean = False)
            If SkipIfNotBeginned Then
                If oParent.Undo.IsBeginned Then
                    Call oParent.Undo.CommitSnapshot()
                End If
            Else
                Call oParent.Undo.CommitSnapshot()
            End If
        End Sub

        Private Function pEndItem() As Boolean
            Dim bRaiseEvent As Boolean
            If Not oCurrentItem Is Nothing Then
                Call oCurrentItem.Points.CleanUp()
                Call oCurrentItem.BindSegments()
                bRaiseEvent = True
            End If
            bIsInEdit = False
            bIsInCombine = False
            bIsInPointEdit = False
            bStarted = False
            If bRaiseEvent Then
                RaiseEvent OnItemEnd(Me, New cEditDesignToolsEventArgs(oCurrentLayer, oCurrentItem, oCurrentItemPoint, bIsNewItem))
            End If
            bIsNewItem = False
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
            Return bRaiseEvent
        End Function

        Public Sub [EndItem](Optional ItemSelect As Boolean = True)
            If pEndItem() AndAlso ItemSelect Then
                RaiseEvent OnItemSelect(Me, New cEditDesignToolsEventArgs(Me))
            End If
        End Sub

        Public Sub EndPoint()
            If Not oCurrentItem Is Nothing Then
                If Not oCurrentItemPoint Is Nothing Then
                    'Call oSurvey.Undo.Push("Fine modifica punti", cUndo.ActionEnum.Update, oCurrentLayer, oCurrentItem, oCurrentLayer.Items.IndexOf(oCurrentItem))
                    RaiseEvent OnItemPointEnd(Me, New cEditDesignToolsEventArgs(oCurrentLayer, oCurrentItem, oCurrentItemPoint, bIsNewItem))
                    oCurrentItemPoint = Nothing
                End If
            End If
        End Sub

        Public Sub SelectLastPoint(Point As cPoint)
            If Not Point Is oLastItemPoint Then
                oLastItemPoint = Point
                RaiseEvent OnLastPointChange(Me, New EventArgs)
            End If
        End Sub

        Public Sub SelectPoint(ByVal Point As cPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cPoint = Nothing)
            Call EditPoint(Point, IsNewPoint, NewPointRelative)
        End Sub

        Public Sub EditPoint(ByVal Point As cPoint, Optional IsNewPoint As Boolean = False, Optional NewPointRelative As cPoint = Nothing)
            If Not oCurrentItem Is Nothing Then
                If Not oCurrentItemPoint Is Point Then
                    bIsNewPoint = IsNewPoint
                    If bIsNewPoint Then
                        oNewPointRelative = NewPointRelative
                    End If
                    oCurrentItemPoint = Point
                    RaiseEvent OnItemPointEdit(Me, New cEditDesignToolsEventArgs(Me))
                End If
            End If
        End Sub

        Public ReadOnly Property CurrentNewPointRelative As cPoint
            Get
                Return oNewPointRelative
            End Get
        End Property

        Public Sub StartEditItem()
            If bIsNewItem Then
                'bIsNewItem = False
                bStarted = True
            End If
        End Sub

        Public ReadOnly Property Started As Boolean
            Get
                Return bStarted
            End Get
        End Property

        Public ReadOnly Property IsInEdit() As Boolean
            Get
                Return bIsInEdit
            End Get
        End Property

        Public ReadOnly Property IsNewPoint() As Boolean
            Get
                Return bIsNewPoint AndAlso Not IsNothing(oCurrentItemPoint)
            End Get
        End Property

        Public ReadOnly Property IsInPointEdit() As Boolean
            Get
                Return bIsInPointEdit
            End Get
        End Property

        Public ReadOnly Property IsInCombine() As Boolean
            Get
                Return bIsInCombine
            End Get
        End Property

        Public Overridable ReadOnly Property CurrentLayer() As cLayer Implements cIEditDesignSelection.CurrentLayer
            Get
                Return oCurrentLayer
            End Get
        End Property

        Public Overridable ReadOnly Property CurrentItem() As cItem Implements cIEditDesignSelection.CurrentItem
            Get
                Return oCurrentItem
            End Get
        End Property

        Public ReadOnly Property IsLastPoint() As Boolean
            Get
                Return Not oLastItemPoint Is Nothing
            End Get
        End Property

        Public ReadOnly Property LastItemPoint() As cPoint
            Get
                Return oLastItemPoint
            End Get
        End Property

        Public ReadOnly Property CurrentItemPoint() As cPoint Implements cIEditDesignSelection.CurrentItemPoint
            Get
                Return oCurrentItemPoint
            End Get
        End Property

        Public ReadOnly Property CurrentCave() As String Implements cIEditDesignSelection.CurrentCave
            Get
                Return sCurrentCave
            End Get
        End Property

        Public ReadOnly Property CurrentBranch() As String Implements cIEditDesignSelection.CurrentBranch
            Get
                Return sCurrentBranch
            End Get
        End Property

        Public ReadOnly Property CurrentBindDesignType As cItem.BindDesignTypeEnum
            Get
                Return iCurrentBindDesignType
            End Get
        End Property

        Public ReadOnly Property CurrentCrossSection() As String
            Get
                Return sCurrentCrossSection
            End Get
        End Property

        Friend Sub Reset()
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
            bIsInEdit = False
            bIsInCombine = False
        End Sub

        Friend Sub Clear()
            oCurrentLayer = Nothing
            oCurrentItem = Nothing
            oCurrentItemPoint = Nothing
            bIsInEdit = False
            bIsInCombine = False
        End Sub

        Public ReadOnly Property Survey() As cSurvey Implements cIEditSelection.CurrentSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property CurrentTrigpoint As cTrigPoint Implements cIEditSelection.CurrentTrigpoint
            Get
                Return oParent.CurrentTrigpoint
            End Get
        End Property

        Public ReadOnly Property CurrentSegment As cSegment Implements cIEditSelection.CurrentSegment
            Get
                Return oParent.CurrentSegment
            End Get
        End Property

        Friend Sub New(Parent As cEditTools, Design As cIDesign)
            oParent = Parent
            oSurvey = oParent.Survey
            oDesign = Design

            oCurrentMarkedDesktopPoint = New cMarkedDesktopPoint()
            oFilter = New cFilter(oSurvey)
        End Sub

        Friend Event OnMarkedDesktopPointGetPaintInfo(Sender As cEditDesignTools, Args As cMarkedDesktopPointPaintInfoEventArgs)
        Friend Event OnMarkedDesktopPointMove(Sender As cEditDesignTools, Args As cMarkedDesktopPointMoveEventArgs)
        Friend Event OnMarkedDesktopPointSet(Sender As cEditDesignTools, Args As EventArgs)

        Private Sub oCurrentMarkedDesktopPoint_OnGetPaintInfo(Sender As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cPaintInfoEventArgs) Handles oCurrentMarkedDesktopPoint.OnGetPaintInfo
            Dim oArgs As cMarkedDesktopPointPaintInfoEventArgs = New cMarkedDesktopPointPaintInfoEventArgs(Sender, Args)
            RaiseEvent OnMarkedDesktopPointGetPaintInfo(Me, oArgs)
            Args.Scale = oArgs.Scale
        End Sub

        Private Sub oCurrentMarkedDesktopPoint_OnMove(Sender As cMarkedDesktopPoint, Args As cMarkedDesktopPoint.cMoveEventArgs) Handles oCurrentMarkedDesktopPoint.OnMove
            Dim oArgs As cMarkedDesktopPointMoveEventArgs = New cMarkedDesktopPointMoveEventArgs(Sender, Args)
            RaiseEvent OnMarkedDesktopPointMove(Me, oArgs)
        End Sub

        Private Sub oCurrentMarkedDesktopPoint_OnSet(Sender As cMarkedDesktopPoint, Args As EventArgs) Handles oCurrentMarkedDesktopPoint.OnSet
            RaiseEvent OnMarkedDesktopPointSet(Me, Args)
        End Sub

        Public Function IsInEditing() As Boolean Implements cIEditDesignSelection.IsInEditing
            Return IsInEdit OrElse IsInPointEdit OrElse Started
        End Function
    End Class

    Public Class cEditToolsBag
        Public Type As String
        Public Subtype As String

        Public Name As String
        Public Caption As String
        Public Image As String
        Public SvgImage As String
        Public ToolTip As String
        Public Style As Integer

        Public Layer As cLayers.LayerTypeEnum
        Public Category As cIItem.cItemCategoryEnum
        Public Cliparts As String

        Public Gallery As String

        Public Filename As String

        Public Text As String

        Public Method As String
        Public Parameters As String

        Public LineType As cIItemLine.LineTypeEnum

        Public AvaiableInPlan As Boolean
        Public AvaiableInProfile As Boolean

        Public Hidden As Boolean

        Enum ConvertToEnum
            None = 0
            AreaOrLines = 1
            Images = 2
        End Enum

        Public ConvertTo As ConvertToEnum

        Public Function GetInvokeParameters(ByVal ParamArray Values As Object()) As Object()
            Dim oParameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
            Dim oList As List(Of Object) = New List(Of Object)
            For iValueIndex As Integer = 0 To Values.Count - 1 Step 2
                Try
                    Dim sKey As String = Values(iValueIndex)
                    Dim oValue As Object = Values(iValueIndex + 1)
                    Call oParameters.Add(sKey, oValue)
                Catch
                End Try
            Next
            Dim sParameters() As String = Parameters.Split(",")
            For Each sParameter As String In sParameters
                sParameter = sParameter.Trim
                Try
                    Call oList.Add(oParameters(sParameter))
                Catch
                    Call oList.Add(Nothing)
                End Try
            Next
            Return oList.ToArray
        End Function

        Private Function pGetCaptionNode(Parent As XmlElement) As XmlElement
            Dim oNodes As XmlNodeList = Parent.SelectNodes("caption[@lang='" & My.Application.CurrentLanguage & "']")
            If oNodes.Count > 0 Then
                Return oNodes(0)
            Else
                Return Parent
            End If
        End Function

        Public Sub New(ByVal Tool As XmlElement)
            With Tool
                Type = .GetAttribute("type")
                Hidden = modXML.GetAttributeValue(Tool, "hidden", False)
                Select Case Type
                    Case "separator", "-"

                    Case "texteditor"
                        Dim oCaptionNode As XmlElement = pGetCaptionNode(Tool)
                        Caption = oCaptionNode.GetAttribute("caption")
                        ToolTip = oCaptionNode.GetAttribute("tooltip")

                        Name = .GetAttribute("name")
                        Image = .GetAttribute("image")
                        SvgImage = modXML.GetAttributeValue(Tool, "svgimage", "")
                        Style = .GetAttribute("style")

                        Layer = .GetAttribute("layer")

                        Method = .GetAttribute("method")
                        Parameters = .GetAttribute("parameters")

                    Case "gallery"
                        Subtype = .GetAttribute("subtype")

                        Dim oCaptionNode As XmlElement = pGetCaptionNode(Tool)
                        Caption = oCaptionNode.GetAttribute("caption")
                        ToolTip = oCaptionNode.GetAttribute("tooltip")

                        Name = .GetAttribute("name")
                        Image = .GetAttribute("image")
                        SvgImage = modXML.GetAttributeValue(Tool, "svgimage", "")
                        Style = .GetAttribute("style")

                        Layer = .GetAttribute("layer")
                        Category = .GetAttribute("category")
                        Cliparts = .GetAttribute("cliparts")

                        Gallery = .GetAttribute("gallery")

                        Method = .GetAttribute("method")
                        Parameters = .GetAttribute("parameters")
                    Case "clipart", "sign"
                        Dim oCaptionNode As XmlElement = pGetCaptionNode(Tool)
                        Caption = oCaptionNode.GetAttribute("caption")
                        ToolTip = oCaptionNode.GetAttribute("tooltip")

                        Name = .GetAttribute("name")
                        Image = .GetAttribute("image")
                        SvgImage = modXML.GetAttributeValue(Tool, "svgimage", "")
                        Style = .GetAttribute("style")

                        Layer = .GetAttribute("layer")

                        Filename = .GetAttribute("filename")

                        Method = .GetAttribute("method")
                        Parameters = .GetAttribute("parameters")
                    Case "text"
                        Dim oCaptionNode As XmlElement = pGetCaptionNode(Tool)
                        Caption = oCaptionNode.GetAttribute("caption")
                        ToolTip = oCaptionNode.GetAttribute("tooltip")

                        Name = .GetAttribute("name")
                        Image = .GetAttribute("image")
                        SvgImage = modXML.GetAttributeValue(Tool, "svgimage", "")
                        Style = .GetAttribute("style")

                        Layer = .GetAttribute("layer")

                        Text = .GetAttribute("text")

                        Method = .GetAttribute("method")
                        Parameters = .GetAttribute("parameters")
                    Case Else
                        Dim oCaptionNode As XmlElement = pGetCaptionNode(Tool)
                        Caption = oCaptionNode.GetAttribute("caption")
                        ToolTip = oCaptionNode.GetAttribute("tooltip")

                        Name = .GetAttribute("name")
                        Image = .GetAttribute("image")
                        SvgImage = modXML.GetAttributeValue(Tool, "svgimage", "")
                        Style = .GetAttribute("style")

                        LineType = modXML.GetAttributeValue(Tool, "linetype", -1)

                        Layer = .GetAttribute("layer")

                        Method = .GetAttribute("method")
                        Parameters = .GetAttribute("parameters")
                End Select

                ConvertTo = modXML.GetAttributeValue(Tool, "convertto", "0")

                Dim sDesign As String = modXML.GetAttributeValue(Tool, "design", "")
                If sDesign = "" Then
                    AvaiableInPlan = True
                    AvaiableInProfile = True
                Else
                    AvaiableInPlan = sDesign.Contains("plan")
                    AvaiableInProfile = sDesign.Contains("profile")
                End If
            End With
        End Sub
    End Class

    Public Class cConvertToToolsBag
        Public Type As String
        Public Name As String
        Public Caption As String
        Public Image As String
        Public SvgImage As String
        Public ToolTip As String
        Public Layer As cLayers.LayerTypeEnum

        Public Method As String
        Public Parameters As String

        Public Function GetInvokeParameters(ByVal ParamArray Values As Object()) As Object()
            Dim oParameters As Dictionary(Of String, Object) = New Dictionary(Of String, Object)
            Dim oList As List(Of Object) = New List(Of Object)
            For iValueIndex As Integer = 0 To Values.Count Step 2
                Try
                    Dim sKey As String = Values(iValueIndex)
                    Dim oValue As Object = Values(iValueIndex + 1)
                    Call oParameters.Add(sKey, oValue)
                Catch
                End Try
            Next
            Dim sParameters() As String = Parameters.Split(",")
            For Each sParameter As String In sParameters
                sParameter = sParameter.Trim
                Try
                    Call oList.Add(oParameters(sParameter))
                Catch
                    Call oList.Add(Nothing)
                End Try
            Next
            Return oList.ToArray
        End Function

        Public Sub New(ByVal Tool As XmlElement)
            With Tool
                Type = .GetAttribute("type")
                Select Case Type
                    Case "separator", "-"
                        'for compatibility...or future use
                    Case "clipartgallery", "signgallery", "gallery"
                        'for compatibility...not for future use
                    Case Else
                        Name = .GetAttribute("name")
                        Caption = .GetAttribute("caption")
                        Image = .GetAttribute("image")
                        SvgImage = modXML.GetAttributeValue(Tool, "svgimage", "")
                        ToolTip = .GetAttribute("tooltip")
                        Layer = .GetAttribute("layer")
                        Method = .GetAttribute("method")
                        Parameters = .GetAttribute("parameters")
                End Select
            End With
        End Sub
    End Class

    'Friend Class cEditDesignTools3D
    '    Inherits cEditDesignTools

    '    Public Shadows ReadOnly Property Design As cDesign3D
    '        Get
    '            Return MyBase.Design
    '        End Get
    '    End Property

    '    Public Overrides Sub DeleteItem()
    '        If MyBase.CurrentItem IsNot Nothing Then
    '            If MyBase.CurrentItem.Type = cIItem.cItemTypeEnum.Chunk3D Then
    '                Design.Layers.ChunkLayer.Items.Remove(DirectCast(MyBase.CurrentItem, cItemChunk3D))
    '            End If

    '            Call RaiseOnItemDelete(Me, New cEditDesignToolsEventArgs(Me))
    '            Call SetCurrentItem(Nothing)
    '            Call EndItem()
    '            Call SelectItem(Nothing)
    '            Call RaiseOnItemDeleted(Me, New cEditDesignToolsEventArgs(Me))
    '        End If
    '    End Sub

    '    Public Sub New(Parent As cEditTools, Design As cIDesign)
    '        MyBase.New(Parent, Design)
    '    End Sub
    'End Class
End Namespace
