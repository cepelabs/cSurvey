Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Windows.Input
Imports System.Xml
Imports cSurveyPC.cSurvey.Design.Options
Imports cSurveyPC.cSurvey.Helper.Editor
Imports cSurveyPC.cSurvey.Surface
Imports DevExpress.Utils.Behaviors.Common
Imports DevExpress.Utils.CommonDialogs.Internal
Imports DevExpress.XtraEditors
Imports OfficeOpenXml.FormulaParsing.Excel.Functions.Text

Namespace cSurvey.UIHelpers

    Namespace Reflection
        <System.AttributeUsage(System.AttributeTargets.Property Or System.AttributeTargets.Struct)>
        Public Class cReplicateDataAttribute

            Inherits System.Attribute

            Public Enabled As Boolean
            Private iSetOrder

            Private ReadOnly Property SetOrder As Integer
                Get
                    Return iSetOrder
                End Get
            End Property

            Sub New(ByVal Enabled As Boolean, SetOrder As Integer)
                Me.Enabled = Enabled
                iSetOrder = SetOrder
            End Sub
        End Class

        Public Class cObjectPropertyBag
            Private oProperty As System.Reflection.PropertyInfo

            Private bSet As Boolean
            Private oValue As Object
            Private iSetOrder As Integer

            Public ReadOnly Property SetOrder As Integer
                Get
                    Return iSetOrder
                End Get
            End Property

            Public ReadOnly Property [Property] As System.Reflection.PropertyInfo
                Get
                    Return oProperty
                End Get
            End Property

            Public Property [Set] As Boolean
                Get
                    Return bSet
                End Get
                Set(value As Boolean)
                    bSet = value
                End Set
            End Property

            Public ReadOnly Property Name As String
                Get
                    Return oProperty.Name
                End Get
            End Property

            Public Property Value As Object
                Get
                    Return oValue
                End Get
                Set(value As Object)
                    oValue = value
                End Set
            End Property

            Public Sub New([Property] As System.Reflection.PropertyInfo, SetOrder As Integer)
                oProperty = [Property]
                iSetOrder = SetOrder
            End Sub
        End Class
    End Namespace


    Namespace Import
        Public Class cDestFields
            Inherits BindingList(Of cDestField)

            Public Sub MoveUp(Item As cDestField)
                Dim iIndex As Integer = MyBase.IndexOf(Item)
                If iIndex > 0 Then
                    Call MyBase.RemoveAt(iIndex)
                    Call MyBase.Insert(iIndex - 1, Item)
                End If
            End Sub

            Public Sub MoveDown(Item As cDestField)
                Dim iIndex As Integer = MyBase.IndexOf(Item)
                If iIndex >= 0 AndAlso iIndex < MyBase.Count - 1 Then
                    Call MyBase.RemoveAt(iIndex)
                    Call MyBase.Insert(iIndex + 1, Item)
                End If
            End Sub

            Public Shadows Function Add(Source As cSourceField, Type As cDestField.DestinationFieldTypeEnum, Optional Value As String = Nothing) As cDestField
                Dim oItem As cDestField = New cDestField(Me, Source, Type, Value)
                Call MyBase.Add(oItem)
                Return oItem
            End Function

            Public Function GetValue(Index As cSourceField.TextFieldIndexEnum, Sheet As OfficeOpenXml.ExcelWorksheet, Row As Integer, DefaultValue As Object) As Object
                Dim oItem As cDestField = Item(Index)
                If oItem Is Nothing Then
                    Return DefaultValue
                Else
                    If oItem.Type = cDestField.DestinationFieldTypeEnum.SourceFieldIndex Then
                        Dim iIndex As Integer
                        If Integer.TryParse(oItem.Value, iIndex) Then
                            Try
                                Dim oValue As Object = Sheet.Cells(Row, iIndex).Value
                                If IsNothing(oValue) Then
                                    Return DefaultValue
                                Else
                                    If Index >= cSourceField.TextFieldIndexEnum.Distance AndAlso Index <= cSourceField.TextFieldIndexEnum.Down Then
                                        oValue = modNumbers.StringToDecimal(oValue)
                                    End If
                                    Return oValue
                                End If
                            Catch
                                Return DefaultValue
                            End Try
                        Else
                            Return DefaultValue
                        End If
                    Else
                        Return oItem.Value
                    End If
                End If
            End Function
            Public Function GetValue(Index As cSourceField.TextFieldIndexEnum, LineParts() As String, DefaultValue As String) As String
                Dim oItem As cDestField = Item(Index)
                If oItem Is Nothing Then
                    Return DefaultValue
                Else
                    If oItem.Type = cDestField.DestinationFieldTypeEnum.SourceFieldIndex Then
                        Dim iIndex As Integer
                        If Integer.TryParse(oItem.Value, iIndex) Then
                            iIndex -= 1
                            If iIndex < LineParts.Count Then
                                Return LineParts(iIndex)
                            Else
                                Return DefaultValue
                            End If
                        Else
                            Return DefaultValue
                        End If
                    Else
                        Return oItem.Value
                    End If
                End If
            End Function

            Public Overloads Function ContainsKey(Index As cSourceField.TextFieldIndexEnum) As Boolean
                Return MyBase.FirstOrDefault(Function(oitem) oitem.Source.Index = Index) IsNot Nothing
            End Function

            Default Public Overloads ReadOnly Property Item(Index As cSourceField.TextFieldIndexEnum) As cDestField
                Get
                    Return MyBase.FirstOrDefault(Function(oitem) oitem.Source.Index = Index)
                End Get
            End Property

            Public Overrides Function ToString() As String
                Dim sText As String = ""
                For Each oItem As cDestField In Me
                    If sText <> "" Then sText = sText & ","
                    sText = sText & oItem.Source.Index & "|" & oItem.Type & "|" & oItem.Value
                Next
                Return sText
            End Function
        End Class

        Public Class cSourceFields
            Inherits BindingList(Of cSourceField)

            Private Sub pAdd(Index As cSourceField.TextFieldIndexEnum)
                Dim oItem As cSourceField = New cSourceField(Index)
                AddHandler oItem.OnGetName, AddressOf oItem_OnGetName
                Call MyBase.Add(oItem)
            End Sub

            Private Sub oItem_OnGetName(sender As Object, e As cSourceField.cGetNameEventArgs)
                RaiseEvent OnGetName(sender, e)
            End Sub

            Public Sub New()
                MyBase.New

                pAdd(cSourceField.TextFieldIndexEnum.From)
                pAdd(cSourceField.TextFieldIndexEnum.To)
                pAdd(cSourceField.TextFieldIndexEnum.Distance)
                pAdd(cSourceField.TextFieldIndexEnum.Direction)
                pAdd(cSourceField.TextFieldIndexEnum.Inclination)
                pAdd(cSourceField.TextFieldIndexEnum.Left)
                pAdd(cSourceField.TextFieldIndexEnum.Right)
                pAdd(cSourceField.TextFieldIndexEnum.Up)
                pAdd(cSourceField.TextFieldIndexEnum.Down)
                pAdd(cSourceField.TextFieldIndexEnum.Note)
                pAdd(cSourceField.TextFieldIndexEnum.CustomProperty)
                pAdd(cSourceField.TextFieldIndexEnum.Empty)
            End Sub

            Public Event OnGetName(sender As Object, e As cSourceField.cGetNameEventArgs)
        End Class
        Public Class cSourceField
            Public Index As TextFieldIndexEnum

            Public ReadOnly Property Name As String
                Get
                    Dim oArgs As cGetNameEventArgs = New cGetNameEventArgs
                    RaiseEvent OnGetName(Me, oArgs)
                    Return oArgs.Name
                End Get
            End Property

            Public Enum DataTypeFieldEnum
                Text = 0
                Numeric = 1
            End Enum
            Public Enum TextFieldIndexEnum
                [From] = 0
                [To] = 1
                [Distance] = 2
                [Direction] = 3
                [Inclination] = 4
                [Left] = 5
                [Right] = 6
                [Up] = 7
                [Down] = 8
                [Note] = 9
                [CustomProperty] = 98
                [Empty] = 99
            End Enum
            Public Overrides Function ToString() As String
                Return Name
            End Function

            Public Function GetDataType() As DataTypeFieldEnum
                Select Case Index
                    Case TextFieldIndexEnum.Note, TextFieldIndexEnum.To, TextFieldIndexEnum.From
                        Return DataTypeFieldEnum.Text
                    Case Else
                        Return DataTypeFieldEnum.Numeric
                End Select
            End Function

            Friend Sub New(Index As TextFieldIndexEnum)
                Me.Index = Index
            End Sub

            Public Class cGetNameEventArgs
                Inherits EventArgs

                Public Sub New()
                    Me.Name = ""
                End Sub

                Public Property Name As String
            End Class

            Public Event OnGetName(sender As Object, e As cGetNameEventArgs)
        End Class

        Public Class cDestField
            Private sName As String
            Private iType As DestinationFieldTypeEnum
            Private sValue As String
            Private oParent As cDestFields

            Public Enum DestinationFieldTypeEnum
                SourceFieldIndex = 0
                FixedValue = 1
            End Enum

            Private oSource As cSourceField
            Public Property Value As String
                Get
                    If iType = DestinationFieldTypeEnum.FixedValue Then
                        Return sValue
                    Else
                        Dim iIndex As Integer = 1
                        For Each oItem As cDestField In oParent
                            If oItem Is Me Then
                                Return iIndex
                            Else
                                If oItem.Type = DestinationFieldTypeEnum.SourceFieldIndex Then
                                    iIndex += 1
                                End If
                            End If
                        Next
                        Return -1
                    End If
                End Get
                Set(value As String)
                    If iType = DestinationFieldTypeEnum.FixedValue Then
                        If oSource.Index <> cSourceField.TextFieldIndexEnum.Empty Then
                            If sValue <> value Then
                                sValue = value
                                Call Validate()
                            End If
                        End If
                    End If
                End Set
            End Property

            Public Property Type As DestinationFieldTypeEnum
                Get
                    Return iType
                End Get
                Set(value As DestinationFieldTypeEnum)
                    If oSource.Index = cSourceField.TextFieldIndexEnum.Empty Then
                        iType = DestinationFieldTypeEnum.SourceFieldIndex
                    Else
                        If iType <> value Then
                            iType = value
                            Call Validate()
                        End If
                    End If
                End Set
            End Property

            Public ReadOnly Property IsInError As Boolean
                Get
                    Return bError
                End Get
            End Property

            Public ReadOnly Property ErrorText As String
                Get
                    Return sErrorText
                End Get
            End Property

            Private bError As Boolean
            Private sErrorText As String = ""

            Public Sub Validate()
                If iType = DestinationFieldTypeEnum.SourceFieldIndex Then
                    'index in v2 in automanaged...so validation in not really usefull
                    Dim iField As Integer
                    If Integer.TryParse(sValue, iField) Then
                        If iField < 0 Then
                            bError = True
                            sErrorText = GetLocalizedString("importgenericdata.warning1")
                        Else
                            bError = False
                            sErrorText = ""
                        End If
                    Else
                        bError = True
                        sErrorText = GetLocalizedString("importgenericdata.warning1")
                    End If
                Else
                    If oSource.GetDataType = cSourceField.DataTypeFieldEnum.Numeric Then
                        Dim dField As Decimal
                        If Decimal.TryParse(sValue, dField) Then
                            bError = False
                            sErrorText = ""
                        Else
                            bError = True
                            sErrorText = GetLocalizedString("importgenericdata.warning1")
                        End If
                    End If
                End If
            End Sub

            Public ReadOnly Property Source As cSourceField
                Get
                    Return oSource
                End Get
            End Property

            Public ReadOnly Property Name As String
                Get
                    Return oSource.Name
                End Get
            End Property

            Public Overrides Function ToString() As String
                Return oSource.Name
            End Function

            Public Sub New(Parent As cDestFields, Source As cSourceField, Type As DestinationFieldTypeEnum, Optional Value As String = Nothing)
                oParent = Parent
                oSource = Source
                iType = Type
                If iType = DestinationFieldTypeEnum.FixedValue Then
                    sValue = Value
                End If
            End Sub
        End Class
        Public Class cDestFieldComboItemType
            Private sText As String
            Private iIndex As cDestField.DestinationFieldTypeEnum

            Public ReadOnly Property Text As String
                Get
                    Return sText
                End Get
            End Property

            Public ReadOnly Property Index As cDestField.DestinationFieldTypeEnum
                Get
                    Return iIndex
                End Get
            End Property

            Public Sub New(Text As String, Index As cDestField.DestinationFieldTypeEnum)
                sText = Text
                iIndex = Index
            End Sub

            Public Overrides Function ToString() As String
                Return Text
            End Function
        End Class
    End Namespace

    Public Class Dialogs

        Public Class cFileDialogResult
            Private iDialogResult As DialogResult
            Private sFilename As String

            Public ReadOnly Property Filename As String
                Get
                    Return sFilename
                End Get
            End Property

            Public ReadOnly Property DialogResult As DialogResult
                Get
                    Return iDialogResult
                End Get
            End Property

            Public Sub New(DialogResult As DialogResult)
                iDialogResult = DialogResult
            End Sub

            Public Sub New(DialogResult As DialogResult, Filename As String)
                iDialogResult = DialogResult
                sFilename = Filename
            End Sub
        End Class

        Public Class cSaveFileDialogResult
            Inherits cFileDialogResult

            Public Sub New(DialogResult As DialogResult)
                MyBase.New(DialogResult)
            End Sub

            Public Sub New(DialogResult As DialogResult, Filename As String)
                MyBase.New(DialogResult, Filename)
            End Sub
        End Class

        Public Class cOpenFileDialogResult
            Inherits cFileDialogResult

            Public Sub New(DialogResult As DialogResult)
                MyBase.New(DialogResult)
            End Sub

            Public Sub New(DialogResult As DialogResult, Filename As String)
                MyBase.New(DialogResult, Filename)
            End Sub
        End Class

        Public Shared Function SaveFileDialog(InitialDirectory As String, Filename As String, Filter As String, FilterIndex As Integer, Optional Title As String = Nothing) As cSaveFileDialogResult
            Return SaveFileDialog(Nothing, InitialDirectory, Filename, Filter, FilterIndex, Title)
        End Function

        Public Shared Function SaveFileDialog(Owner As IWin32Window, InitialDirectory As String, Filename As String, Filter As String, FilterIndex As Integer, Optional Title As String = Nothing) As cSaveFileDialogResult
            Using osfd As SaveFileDialog = New SaveFileDialog
                With osfd
                    Dim sFilename As String = "" & Filename
                    Dim sInitialDirectory As String = "" & InitialDirectory
                    .RestoreDirectory = True
                    If sFilename <> "" Then
                        .InitialDirectory = IO.Path.GetDirectoryName(sFilename)
                        .FileName = IO.Path.GetFileName(sFilename)
                    ElseIf sInitialDirectory <> "" Then
                        .InitialDirectory = sInitialDirectory
                    End If
                    .Filter = Filter
                    .FilterIndex = FilterIndex
                    If Title IsNot Nothing Then .Title = Title
                    If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
                        Return New cSaveFileDialogResult(DialogResult.OK, .FileName)
                    Else
                        Return New cSaveFileDialogResult(DialogResult.Cancel)
                    End If
                End With
            End Using
        End Function

        Public Shared Function OpenFileDialog(InitialDirectory As String, Filename As String, Filter As String, FilterIndex As Integer, Optional Title As String = Nothing) As cOpenFileDialogResult
            Return OpenFileDialog(Nothing, InitialDirectory, Filename, Filter, FilterIndex, Title)
        End Function

        Public Shared Function OpenFileDialog(Owner As IWin32Window, InitialDirectory As String, Filename As String, Filter As String, FilterIndex As Integer, Optional Title As String = Nothing) As cOpenFileDialogResult
            Using osfd As OpenFileDialog = New OpenFileDialog
                With osfd
                    Dim sFilename As String = "" & Filename
                    Dim sInitialDirectory As String = "" & InitialDirectory
                    .RestoreDirectory = True
                    If sFilename <> "" Then
                        .InitialDirectory = IO.Path.GetDirectoryName(sFilename)
                        .FileName = IO.Path.GetFileName(sFilename)
                    ElseIf sInitialDirectory <> "" Then
                        .InitialDirectory = sInitialDirectory
                    End If
                    .Filter = Filter
                    .FilterIndex = FilterIndex
                    .CheckFileExists = True
                    .CheckPathExists = True
                    If Title IsNot Nothing Then .Title = Title
                    If .ShowDialog(Owner) = Windows.Forms.DialogResult.OK Then
                        Return New cOpenFileDialogResult(DialogResult.OK, .FileName)
                    Else
                        Return New cOpenFileDialogResult(DialogResult.Cancel)
                    End If
                End With
            End Using
        End Function

        Public Shared Function Msgbox(Prompt As String, Optional Buttons As MsgBoxStyle = MsgBoxStyle.ApplicationModal, Optional Title As String = Nothing) As MsgBoxResult
            Dim iButtons As MessageBoxButtons = Buttons And &HF
            Dim iIcon As MessageBoxIcon = Buttons And &HF0
            Dim iResult As DialogResult = XtraMessageBox.Show(Prompt, Title, iButtons, iIcon, DevExpress.Utils.DefaultBoolean.True)
            Return iResult
        End Function
        Public Shared Function Msgbox(Owner As IWin32Window, Prompt As String, Optional Buttons As MsgBoxStyle = MsgBoxStyle.ApplicationModal, Optional Title As String = Nothing) As MsgBoxResult
            Dim iButtons As MessageBoxButtons = Buttons And Not &HF0
            Dim iIcon As MessageBoxIcon = Buttons And &HF0
            Dim iResult As DialogResult = XtraMessageBox.Show(Owner, Prompt, Title, iButtons, iIcon, DevExpress.Utils.DefaultBoolean.True)
            Return iResult
        End Function

        Public Shared Function SaveImage(Owner As IWin32Window, Image As Image, Title As String, Filter As String) As DialogResult
            Using oSFD As SaveFileDialog = New SaveFileDialog
                With oSFD
                    .Title = Title
                    .Filter = Filter
                    .FilterIndex = 1
                    If .ShowDialog(Owner) = DialogResult.OK Then
                        Dim iImageFormat As Imaging.ImageFormat = Imaging.ImageFormat.Jpeg
                        Select Case IO.Path.GetExtension(oSFD.FileName)
                            Case ".gif"
                                iImageFormat = Imaging.ImageFormat.Gif
                            Case ".bmp"
                                iImageFormat = Imaging.ImageFormat.Bmp
                            Case ".tif"
                                iImageFormat = Imaging.ImageFormat.Tiff
                            Case ".png"
                                iImageFormat = Imaging.ImageFormat.Png
                            Case ".jpg", ".jpeg"
                                iImageFormat = Imaging.ImageFormat.Jpeg
                        End Select
                        Call Image.Save(oSFD.FileName, iImageFormat)
                        Return DialogResult.OK
                    Else
                        Return DialogResult.Cancel
                    End If
                End With
            End Using
        End Function

        Public Shared Function SaveImage(Owner As IWin32Window, Image As Image) As DialogResult
            Return SaveImage(Owner, Image, GetLocalizedString("main.saveimagetitle"), GetLocalizedString("main.filetypeIMAGES") & " (*.JPG;*.PNG;*.TIF;*.BMP;*.GIF)|*.JPG;*.PNG;*.TIF;*.BMP;*.GIF")
        End Function

        Public Shared Function TextInputBox(Owner As IWin32Window, Prompt As String, Title As String, Optional DefaultValue As String = Nothing)
            Dim oArgs As New XtraInputBoxArgs()
            oArgs.Owner = Owner
            oArgs.Caption = Title
            oArgs.Prompt = Prompt
            oArgs.DefaultButtonIndex = 0
            AddHandler oArgs.Showing, AddressOf oInputbox_Showing
            oArgs.DefaultResponse = DefaultValue
            Return XtraInputBox.Show(oArgs)
        End Function

        Private Shared Sub oInputbox_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
            e.Form.IconOptions.SvgImage = My.Resources.Actions_Question
        End Sub
    End Class

    Public Class cTrigpointByCaveBindinglist
        Inherits BindingList(Of cTrigpointByCavePlaceholder)

        Public Enum StyleEnum
            [Uniquelist] = 0
            [UniquelistWithCaveAndBranch] = 1
            [ByCaveBranch] = 2
        End Enum

        Private oUsed As List(Of cTrigpointByCavePlaceholder)

        Public Overloads Sub Clear()
            Call MyBase.Clear()
            Call oUsed.Clear()
        End Sub

        Public Sub UnuseAll()
            For Each oTrigpointPlaceHolder As cTrigpointByCavePlaceholder In oUsed
                Call MyBase.Add(oTrigpointPlaceHolder)
            Next
            Call oUsed.Clear()
        End Sub

        Public Sub Unuse(Trigpoint As cTrigPoint)
            Call Unuse(oUsed.Where(Function(oItem) oItem.Trigpoint Is Trigpoint).ToList)
        End Sub

        Public Sub Unuse(TrigpointPlaceHolders As List(Of cTrigpointByCavePlaceholder))
            For Each oTrigpointPlaceHolder As cTrigpointByCavePlaceholder In TrigpointPlaceHolders
                Call Unuse(oTrigpointPlaceHolder)
            Next
        End Sub
        Public Sub Unuse(TrigpointPlaceHolder As cTrigpointByCavePlaceholder)
            If TrigpointPlaceHolder IsNot Nothing Then
                If oUsed.Contains(TrigpointPlaceHolder) Then
                    Call oUsed.Remove(TrigpointPlaceHolder)
                    Call MyBase.Add(TrigpointPlaceHolder)
                End If
            End If
        End Sub

        Public Sub Use(Trigpoint As cTrigPoint)
            Call Use(Find(Trigpoint))
        End Sub

        Public Function Find(Trigpoint As cTrigPoint) As List(Of cTrigpointByCavePlaceholder)
            Return MyBase.Where(Function(oItem) oItem.Trigpoint Is Trigpoint).Union(oUsed.Where(Function(oItem) oItem.Trigpoint Is Trigpoint)).ToList
        End Function

        Public Function Find(Trigpoint As cTrigPoint, Used As Boolean) As List(Of cTrigpointByCavePlaceholder)
            If Used Then
                Return oUsed.Where(Function(oItem) oItem.Trigpoint Is Trigpoint).ToList
            Else
                Return MyBase.Where(Function(oItem) oItem.Trigpoint Is Trigpoint).ToList
            End If
        End Function

        Public Sub Use(TrigpointPlaceHolders As List(Of cTrigpointByCavePlaceholder))
            For Each oTrigpointPlaceHolder As cTrigpointByCavePlaceholder In TrigpointPlaceHolders
                Call Use(oTrigpointPlaceHolder)
            Next
        End Sub
        Public Sub Use(TrigpointPlaceHolder As cTrigpointByCavePlaceholder)
            If TrigpointPlaceHolder IsNot Nothing Then
                If MyBase.Contains(TrigpointPlaceHolder) Then
                    Call MyBase.Remove(TrigpointPlaceHolder)
                    Call oUsed.Add(TrigpointPlaceHolder)
                End If
            End If
        End Sub

        Private iStyle As StyleEnum

        Public ReadOnly Property Style As StyleEnum
            Get
                Return iStyle
            End Get
        End Property

        Public Overloads Function Contains(Trigpoint As cTrigPoint) As Boolean
            If MyBase.Any(Function(oItem) oItem.Trigpoint Is Trigpoint) Then
                Return True
            Else
                Return oUsed.Any(Function(oItem) oItem.Trigpoint Is Trigpoint)
            End If
        End Function

        Public Overloads Function Contains(Trigpoint As cTrigPoint, Used As Boolean) As Boolean
            If Used Then
                Return oUsed.Any(Function(oItem) oItem.Trigpoint Is Trigpoint)
            Else
                Return MyBase.Any(Function(oItem) oItem.Trigpoint Is Trigpoint)
            End If
        End Function

        Public Overloads Sub RemoveRange(Items As List(Of cTrigPoint))
            Items.ForEach(Sub(oTrigpoint)
                              Call Remove(oTrigpoint)
                          End Sub)
        End Sub

        Public Overloads Sub Remove(Item As cTrigPoint)
            Find(Item, False).ForEach(Sub(oPlaceholder)
                                          MyBase.Remove(oPlaceholder)
                                      End Sub)
            Find(Item, True).ForEach(Sub(oPlaceholder)
                                         Call oUsed.Remove(oPlaceholder)
                                     End Sub)
        End Sub

        Public Sub AddRange(Trigpoints As List(Of cTrigPoint), Used As Boolean)
            Call Trigpoints.ForEach(Sub(oTrigpoint) Add(oTrigpoint, Used))
        End Sub

        Public Sub UnuseRange(Trigpoints As List(Of cTrigPoint))
            Call Trigpoints.ForEach(Sub(oTrigpoint)
                                        If Contains(oTrigpoint, True) Then
                                            Call Unuse(oTrigpoint)
                                        End If
                                    End Sub)
        End Sub
        Public Sub UseRange(Trigpoints As List(Of cTrigPoint))
            Call Trigpoints.ForEach(Sub(oTrigpoint)
                                        If Contains(oTrigpoint, False) Then
                                            Call Use(oTrigpoint)
                                        End If
                                    End Sub)
        End Sub

        Public Shadows Sub Add(Trigpoint As cTrigPoint)
            Call Add(Trigpoint, False)
        End Sub

        Public Shadows Sub Add(Trigpoint As cTrigPoint, Used As Boolean)
            If Not Contains(Trigpoint) Then
                Select Case Style
                    Case StyleEnum.Uniquelist
                        Dim oPlaceholder As cTrigpointByCavePlaceholder = New cTrigpointByCavePlaceholder(Trigpoint, False)
                        If Used Then
                            Call oUsed.Add(oPlaceholder)
                        Else
                            Call MyBase.Add(oPlaceholder)
                        End If
                    Case StyleEnum.UniquelistWithCaveAndBranch
                        Dim oPlaceholder As cTrigpointByCavePlaceholder = New cTrigpointByCavePlaceholder(Trigpoint, True)
                        If Used Then
                            Call oUsed.Add(oPlaceholder)
                        Else
                            Call MyBase.Add(oPlaceholder)
                        End If
                    Case StyleEnum.ByCaveBranch
                        For Each oSourceCaveInfo As cICaveInfoBranches In Trigpoint.GetSegments.Cast(Of cSegment).Select(Function(oSegment) oSegment.GetCaveInfo).Distinct()
                            Dim oPlaceholder As cTrigpointByCavePlaceholder = New cTrigpointByCavePlaceholder(Trigpoint, oSourceCaveInfo)
                            If Used Then
                                Call oUsed.Add(oPlaceholder)
                            Else
                                Call MyBase.Add(oPlaceholder)
                            End If
                        Next
                End Select
            End If
        End Sub

        Public Sub New(Style As StyleEnum)
            oUsed = New List(Of cTrigpointByCavePlaceholder)
            iStyle = Style
        End Sub
    End Class

    Public Class cTrigpointByCavePlaceholder
        Private oTrigpoint As cTrigPoint
        Private sCave As String
        Private sCaveHTML As String

        Private sBranch As String
        Private sBranchHTML As String

        Private sCavesAndBranches As String
        Private sCavesAndBranchesHTML As String

        Private bSelected As Boolean

        Public ReadOnly Property IsSpecial As Boolean
            Get
                Return oTrigpoint.IsSpecial
            End Get
        End Property

        Public ReadOnly Property IsInExploration As Boolean
            Get
                Return oTrigpoint.IsInExploration
            End Get
        End Property

        Public ReadOnly Property Entrance As cTrigPoint.EntranceTypeEnum
            Get
                Return oTrigpoint.Entrance
            End Get
        End Property

        Public ReadOnly Property Splay As Boolean
            Get
                Return Not oTrigpoint.Data.IsSplay
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return oTrigpoint.Name
            End Get
        End Property

        Public ReadOnly Property Cave As String
            Get
                Return sCave
            End Get
        End Property

        Public ReadOnly Property Branch As String
            Get
                Return sBranch
            End Get
        End Property

        Public ReadOnly Property CavesAndBranches As String
            Get
                Return sCavesAndBranches
            End Get
        End Property
        Public ReadOnly Property CavesAndBranchesHTML As String
            Get
                Return sCavesAndBranchesHTML
            End Get
        End Property

        Public ReadOnly Property CaveHTML As String
            Get
                Return sCaveHTML
            End Get
        End Property

        Public ReadOnly Property BranchHTML As String
            Get
                Return sBranchHTML
            End Get
        End Property

        Public ReadOnly Property Trigpoint As cTrigPoint
            Get
                Return oTrigpoint
            End Get
        End Property

        Public Property Selected As Boolean
            Get
                Return bSelected
            End Get
            Set(value As Boolean)
                bSelected = value
            End Set
        End Property

        Public Sub New(Trigpoint As cTrigPoint, CaveAndBranches As Boolean)
            oTrigpoint = Trigpoint
            sCave = ""
            sCaveHTML = ""
            sBranch = ""
            sBranchHTML = ""
            If CaveAndBranches Then
                sCavesAndBranches = String.Join("; ", oTrigpoint.GetSegments.Select(Function(osegment)
                                                                                        Dim oCaveInfo As cICaveInfoBranches = osegment.GetCaveInfo
                                                                                        If oCaveInfo Is Nothing Then
                                                                                            Return ""
                                                                                        ElseIf TypeOf oCaveInfo Is cCaveInfo Then
                                                                                            Return DirectCast(oCaveInfo, cCaveInfo).Name
                                                                                        Else
                                                                                            Return DirectCast(oCaveInfo, cCaveInfoBranch).Path
                                                                                        End If
                                                                                    End Function).Distinct())
                sCavesAndBranchesHTML = String.Join("; ", oTrigpoint.GetSegments.Select(Function(osegment)
                                                                                            Dim oCaveInfo As cICaveInfoBranches = osegment.GetCaveInfo
                                                                                            If oCaveInfo Is Nothing Then
                                                                                                Return ""
                                                                                            ElseIf TypeOf oCaveInfo Is cCaveInfo Then
                                                                                                Return DirectCast(oCaveInfo, cCaveInfo).ToHTMLString
                                                                                            Else
                                                                                                Return DirectCast(oCaveInfo, cCaveInfoBranch).ToHTMLString
                                                                                            End If
                                                                                        End Function).Distinct())
            Else
                sCavesAndBranches = ""
                sCavesAndBranchesHTML = ""
            End If
        End Sub

        Public Sub New(Trigpoint As cTrigPoint)
            oTrigpoint = Trigpoint
            sCave = ""
            sCaveHTML = ""
            sBranch = ""
            sBranchHTML = ""
            sCavesAndBranches = ""
            sCavesAndBranchesHTML = ""
        End Sub

        Public Sub New(Trigpoint As cTrigPoint, CaveBranch As cICaveInfoBranches)
            oTrigpoint = Trigpoint
            If CaveBranch Is Nothing Then
                sCave = ""
                sBranch = ""
                sCaveHTML = ""
                sBranchHTML = ""
                sCavesAndBranches = ""
                sCavesAndBranchesHTML = ""
            Else
                If TypeOf CaveBranch Is cCaveInfo Then
                    With DirectCast(CaveBranch, cCaveInfo)
                        sCave = .Cave
                        sBranch = ""
                        sCaveHTML = .ToHTMLString
                        sBranchHTML = ""
                        sCavesAndBranches = ""
                        sCavesAndBranchesHTML = ""
                    End With
                Else
                    With DirectCast(CaveBranch, cCaveInfoBranch)
                        sCave = .Cave
                        sBranch = .Path
                        sCaveHTML = .GetCave().ToHTMLString()
                        sBranchHTML = .ToHTMLString
                        sCavesAndBranches = ""
                        sCavesAndBranchesHTML = ""
                    End With
                End If
            End If
        End Sub

        Public Overrides Function ToString() As String
            Return oTrigpoint.ToString
        End Function
    End Class

    Public Class cWMSPlaceHolder
        Private oWMS As cWMS

        Public ReadOnly Property WMS As cWMS
            Get
                Return oWMS
            End Get
        End Property

        Public ReadOnly Property IsValid As Boolean
            Get
                Return Not oWMS.IsEmpty
            End Get
        End Property

        Public Property SRSOverrides As String
            Get
                Return oWMS.SRSOverride
            End Get
            Set(value As String)
                If oWMS.SRSOverride <> value Then
                    oWMS.SRSOverride = value
                End If
            End Set
        End Property

        Public Property URL As String
            Get
                Return oWMS.URL
            End Get
            Set(value As String)
                If oWMS.URL <> value Then
                    oWMS.URL = value
                    oWMS.Layer = ""
                    oList = Nothing
                End If
            End Set
        End Property

        Public ReadOnly Property Layer As String
            Get
                Return oWMS.Layer
            End Get
        End Property

        Public Sub SetLayers(Layers As List(Of cWMSLayer))
            oList = Layers
            oWMS.Layer = String.Join(","c, oList.Where(Function(oItem) oItem.Selected).Select(Function(oitem) oitem.Name))
        End Sub

        Public Property Name As String
            Get
                Return oWMS.Name
            End Get
            Set(value As String)
                If oWMS.Name <> value Then
                    oWMS.Name = value
                End If
            End Set
        End Property

        Public ReadOnly Property ImageIndex As Integer
            Get
                Return 8
            End Get
        End Property

        Public Sub New(WMS As cWMS)
            oWMS = WMS
        End Sub

        Private oList As List(Of cWMSLayer)

        Public Function GetLayers() As List(Of cWMSLayer)
            If oList Is Nothing Then
                oList = New List(Of cWMSLayer)
                If oWMS.Layer.Trim <> "" Then
                    For Each sLayer As String In oWMS.Layer.Split(","c)
                        Call oList.Add(New cWMSLayer(sLayer, True))
                    Next
                End If
            End If
            Return oList
        End Function

        Public Function GetRefreshedLayers() As List(Of cWMSLayer)
            Dim sLayers As HashSet(Of String) = New HashSet(Of String)(oWMS.Layer.Split(","c))
            oList = New List(Of cWMSLayer)
            If modWMSManager.WMSDownloadLayerList(oWMS.URL, 1, oList) Then
                Call oList.ForEach(Sub(oItem)
                                       oItem.Selected = sLayers.Contains(oItem.Name)
                                   End Sub)
            End If
            Return oList
        End Function
    End Class

    Public Class cWMSsBindingList
        Inherits BindingList(Of cWMSPlaceHolder)

        Private oSurvey As cSurvey
        Private oWMSs As cWMSs

        Public Shadows Sub Clear()
            Call oWMSs.Clear()
            Call MyBase.Clear()
        End Sub

        Public Shadows Sub Remove(Item As cWMSPlaceHolder)
            Call oWMSs.Remove(Item.WMS)
            Call MyBase.Remove(Item)
        End Sub

        Public ReadOnly Property WMSs As cWMSs
            Get
                Return oWMSs
            End Get
        End Property

        Public Sub Save()
            Call oSurvey.Surface.WMSs.CopyFrom(oWMSs)
        End Sub

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oWMSs = New cWMSs(oSurvey)
            Call oWMSs.CopyFrom(Survey.Surface.WMSs)

            For Each oWMS As cWMS In oWMSs
                Call MyBase.Add(New cWMSPlaceHolder(oWMS))
            Next
        End Sub

        Public Shadows Function Add(Name As String) As cWMSPlaceHolder
            Dim oNewWMS As cWMS = oWMSs.Add()
            oNewWMS.Name = Name
            Dim oNewItem As cWMSPlaceHolder = New cWMSPlaceHolder(oNewWMS)
            Call MyBase.Add(oNewItem)
            Return oNewItem
        End Function
    End Class

    Public Class cOrthophotoPlaceHolder
        Private oOrthophoto As cOrthoPhoto

        Private oThumbnail As Image
        Private oImage As Image

        Public ReadOnly Property IsValid As Boolean
            Get
                Return Not oOrthophoto.IsEmpty
            End Get
        End Property

        Public Sub InvertColors()
            Call oOrthophoto.InvertColors()
            Call pRefreshImages()
        End Sub

        Public Property Name As String
            Get
                Return oOrthophoto.Name
            End Get
            Set(value As String)
                If oOrthophoto.Name <> value Then
                    oOrthophoto.Name = value
                End If
            End Set
        End Property

        Public ReadOnly Property Orthophoto As cOrthoPhoto
            Get
                Return oOrthophoto
            End Get
        End Property

        Public ReadOnly Property ImageIndex As Integer
            Get
                Return 9
            End Get
        End Property

        Public ReadOnly Property Information As String
            Get
                With oOrthophoto
                    Dim oTL As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.TopLeft)
                    Dim oTR As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.TopRight)
                    Dim oBL As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.BottomLeft)
                    Dim oBR As cCoordinate = .GetCoordinate(Surface.cOrthoPhoto.GetCoordinateCornerEnum.BottomRight)
                    Dim sText As String = ""
                    sText = sText & String.Format(GetLocalizedString("surface.textpart6"), modNumbers.NumberToCoordinate(oTL.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oTL.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart7"), modNumbers.NumberToCoordinate(oTR.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oTR.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart8"), modNumbers.NumberToCoordinate(oBL.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oBL.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart9"), modNumbers.NumberToCoordinate(oBR.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oBR.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf

                    sText = sText & String.Format(GetLocalizedString("surface.textpart3"), .Photo.Width, .Photo.Height) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart4"), .XSize, .YSize) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart5"), modNumbers.MathRound(.Photo.Width * .XSize, 0), modNumbers.MathRound(.Photo.Height * .YSize, 0))
                    Return sText
                End With
            End Get
        End Property

        Public ReadOnly Property Thumbnail As Image
            Get
                Return oThumbnail
            End Get
        End Property

        Public ReadOnly Property Image As Image
            Get
                Return oImage
            End Get
        End Property

        Public Sub New(Orthophoto As cOrthoPhoto)
            oOrthophoto = Orthophoto
            Call pRefreshImages()
        End Sub

        Private Sub pRefreshImages()
            oThumbnail = oOrthophoto.GetImage(32, 32)
            oImage = oOrthophoto.GetImage(640, 480)
        End Sub
    End Class

    Public Class cOrthophotosBindingList
        Inherits BindingList(Of cOrthophotoPlaceHolder)

        Private oSurvey As cSurvey
        Private oOrthophotos As cOrthoPhotos

        Public Shadows Sub Clear()
            Call oOrthophotos.Clear()
            Call MyBase.Clear()
        End Sub

        Public Shadows Sub Remove(Item As cOrthophotoPlaceHolder)
            Call oOrthophotos.Remove(Item.Orthophoto)
            Call MyBase.Remove(Item)
        End Sub

        Public ReadOnly Property Orthophotos As cOrthoPhotos
            Get
                Return oOrthophotos
            End Get
        End Property

        Public Sub Save()
            Call oSurvey.Surface.OrthoPhotos.CopyFrom(oOrthophotos)
        End Sub

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oOrthophotos = New cOrthoPhotos(oSurvey)
            Call oOrthophotos.CopyFrom(Survey.Surface.OrthoPhotos)

            For Each oOrthophoto As cOrthoPhoto In oOrthophotos
                Call MyBase.Add(New cOrthophotoPlaceHolder(oOrthophoto))
            Next
        End Sub

        Public Shadows Function Add(Image As Image, Name As String, Coordinate As cCoordinate, XSize As Single, YSize As Single) As cOrthophotoPlaceHolder
            Dim oNewOrthophoto As cOrthoPhoto = oOrthophotos.Add(Image, Name, Coordinate, XSize, YSize)
            Dim oNewItem As cOrthophotoPlaceHolder = New cOrthophotoPlaceHolder(oNewOrthophoto)
            Call MyBase.Add(oNewItem)
            Return oNewItem
        End Function

        Public Shadows Function Add(DataType As cOrthoPhoto.OrthoPhotoDataTypeEnum, Filename As String, Options As cOrthoPhoto.cOrthoPhotoImportOptions) As cOrthophotoPlaceHolder
            Dim oNewOrthophoto As cOrthoPhoto = oOrthophotos.Add(DataType, Filename, Options)
            Dim oNewItem As cOrthophotoPlaceHolder = New cOrthophotoPlaceHolder(oNewOrthophoto)
            Call MyBase.Add(oNewItem)
            Return oNewItem
        End Function

        Public Shadows Function Add(Orthophoto As cOrthophotoPlaceHolder, Percentage As Single) As cOrthophotoPlaceHolder
            Dim oOrthophoto As cOrthoPhoto = Orthophoto.Orthophoto
            Dim oNewOrthophoto As cOrthoPhoto = oOrthophotos.Add()
            Call oNewOrthophoto.CopyFrom(oOrthophoto.Reduce(Percentage))
            If Not oNewOrthophoto Is Nothing Then
                Dim oNewItem As cOrthophotoPlaceHolder = New cOrthophotoPlaceHolder(oNewOrthophoto)
                Call MyBase.Add(oNewItem)
                Return oNewItem
            End If
        End Function
    End Class

    Public Class cElevationPlaceHolder
        Private oElevation As cElevation

        Private oThumbnail As Image
        Private oImage As Image
        Public ReadOnly Property ImageIndex As Integer
            Get
                Return 11
            End Get
        End Property
        Public ReadOnly Property IsValid As Boolean
            Get
                Return Not oElevation.IsEmpty
            End Get
        End Property

        Public Sub RemoveNodata(Optional RemoveNoDataMode As cElevation.RemoveNodataModeEnum = cElevation.RemoveNodataModeEnum.ByAverage)
            Call oElevation.RemoveNodata(RemoveNoDataMode)
            Call pRefreshImages()
        End Sub

        Public ReadOnly Property Thumbnail As Image
            Get
                Return oThumbnail
            End Get
        End Property

        Public Property ColorSchema As cElevation.ColorSchemaEnum
            Get
                Return oElevation.ColorSchema
            End Get
            Set(value As cElevation.ColorSchemaEnum)
                If oElevation.ColorSchema <> value Then
                    oElevation.ColorSchema = value
                    Call pRefreshImages()
                End If
            End Set
        End Property

        Public ReadOnly Property Information As String
            Get
                With oElevation
                    Dim oTL As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopLeft)
                    Dim oTR As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.TopRight)
                    Dim oBL As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomLeft)
                    Dim oBR As cCoordinate = .GetCoordinate(Surface.cElevation.GetCoordinateCornerEnum.BottomRight)
                    Dim sText As String = ""
                    sText = sText & String.Format(GetLocalizedString("surface.textpart8"), modNumbers.NumberToCoordinate(oBL.GetLongitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "E", "W"), modNumbers.NumberToCoordinate(oBL.GetLatitude, CoordinateFormatEnum.DegreesMinutesSeconds Or CoordinateFormatEnum.Unsigned, "N", "S")) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart3"), .Columns, .Rows) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart4"), .XSize, .YSize) & vbCrLf
                    sText = sText & String.Format(GetLocalizedString("surface.textpart5"), modNumbers.MathRound(.Columns * .XSize, 0), modNumbers.MathRound(.Rows * .YSize, 0))
                    Return sText
                End With
            End Get
        End Property

        Public ReadOnly Property Image As Image
            Get
                Return oImage
            End Get
        End Property

        Public Property Name As String
            Get
                Return oElevation.Name
            End Get
            Set(value As String)
                If oElevation.Name <> value Then
                    oElevation.Name = value
                End If
            End Set
        End Property

        Public ReadOnly Property Elevation As cElevation
            Get
                Return oElevation
            End Get
        End Property

        Public Sub New(Elevation As cElevation)
            oElevation = Elevation
            Call pRefreshImages()
        End Sub

        Private Sub pRefreshImages()
            oThumbnail = oElevation.GetImage(32, 32)
            oImage = oElevation.GetImage(640, 480)
        End Sub
    End Class

    Public Class cElevationsBindingList
        Inherits BindingList(Of cElevationPlaceHolder)

        Private oSurvey As cSurvey
        Private oElevations As cElevations

        Public ReadOnly Property Elevations As cElevations
            Get
                Return oElevations
            End Get
        End Property

        Public Sub Save()
            Call oSurvey.Surface.Elevations.CopyFrom(oElevations)
        End Sub

        Public Shadows Sub Clear()
            Call oElevations.Clear()
            Call MyBase.Clear()
        End Sub

        Public Shadows Sub Remove(Item As cElevationPlaceHolder)
            Call oElevations.Remove(Item.Elevation)
            Call MyBase.Remove(Item)
        End Sub

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oElevations = New cElevations(oSurvey)
            Call oElevations.CopyFrom(Survey.Surface.Elevations)

            For Each oElevation As cElevation In oElevations
                Call MyBase.Add(New cElevationPlaceHolder(oElevation))
            Next
        End Sub

        Public Shadows Function Add(Name As String, Coordinate As cCoordinate, Rows As Integer, Columns As Integer, XSize As Single, YSize As Single, System As cSurface.CoordinateSystemEnum, Data As Single(,), ColorSchema As cElevation.ColorSchemaEnum) As cElevationPlaceHolder
            Dim oNewElevation As cElevation = oElevations.Add(Name, Coordinate, Rows, Columns, XSize, YSize, System, Data, ColorSchema)
            Dim oNewItem As cElevationPlaceHolder = New cElevationPlaceHolder(oNewElevation)
            Call MyBase.Add(oNewItem)
            Return oNewItem
        End Function

        Public Shadows Function Add(DataType As cElevation.ElevationDataTypeEnum, Filename As String, Options As cElevation.cElevationImportOptions) As cElevationPlaceHolder
            Dim oNewElevation As cElevation = oElevations.Add(DataType, Filename, Options)
            Dim oNewItem As cElevationPlaceHolder = New cElevationPlaceHolder(oNewElevation)
            Call MyBase.Add(oNewItem)
            Return oNewItem
        End Function

        Public Shadows Function Add(Elevation As cElevationPlaceHolder, Percentage As Single) As cElevationPlaceHolder
            Dim oElevation As cElevation = Elevation.Elevation
            Dim oNewElevation As cElevation = oElevations.Add()
            Call oNewElevation.CopyFrom(oElevation.Reduce(Percentage))
            If Not oNewElevation Is Nothing Then
                Dim oNewItem As cElevationPlaceHolder = New cElevationPlaceHolder(oNewElevation)
                Call MyBase.Add(oNewItem)
                Return oNewItem
            End If
        End Function
    End Class


    Public Class cCaveBranchSelectorList(Of T)
        Inherits List(Of cCaveBranchSelectorPlaceholder(Of T))

        Public Delegate Function GetValueDelegate(CaveInfo As cICaveInfoBranches) As T
        Public Delegate Sub SetValueDelegate(CaveInfo As cICaveInfoBranches, Value As T)

        Public Sub New(CaveInfos As cSurveyPC.cSurvey.cCaveInfos, GetValue As GetValueDelegate)
            'MyBase.Add(New cCaveBranchSelectorPlaceholder(Of T)(Nothing, EmptyCaveCaption, GetValue(Nothing)))
            For Each oCaveInfo As cICaveInfoBranches In CaveInfos
                MyBase.Add(New cCaveBranchSelectorPlaceholder(Of T)(oCaveInfo, "", GetValue(oCaveInfo)))
                Call pAppendBranches(oCaveInfo.Branches, "", GetValue)
            Next
        End Sub

        Public Sub New(CaveInfos As cSurveyPC.cSurvey.cCaveInfos, EmptyCaveCaption As String, GetValue As GetValueDelegate)
            MyBase.Add(New cCaveBranchSelectorPlaceholder(Of T)(Nothing, EmptyCaveCaption, GetValue(Nothing)))
            For Each oCaveInfo As cICaveInfoBranches In CaveInfos
                MyBase.Add(New cCaveBranchSelectorPlaceholder(Of T)(oCaveInfo, "", GetValue(oCaveInfo)))
                Call pAppendBranches(oCaveInfo.Branches, "", GetValue)
            Next
        End Sub

        Private Sub pAppendBranches(Branches As cCaveInfoBranches, EmptyCaveCaption As String, GetValue As GetValueDelegate)
            For Each oCaveInfoBranch As cICaveInfoBranches In Branches
                MyBase.Add(New cCaveBranchSelectorPlaceholder(Of T)(oCaveInfoBranch, EmptyCaveCaption, GetValue(oCaveInfoBranch)))
                Call pAppendBranches(oCaveInfoBranch.Branches, EmptyCaveCaption, GetValue)
            Next
        End Sub

        Public Sub Save(SetValue As SetValueDelegate)
            For Each oCaveInfoPlaceholder As cCaveBranchSelectorPlaceholder(Of T) In Me
                Call SetValue(oCaveInfoPlaceholder.BaseInfo, oCaveInfoPlaceholder.Value)
            Next
        End Sub
    End Class

    Public Class cCaveBranchSelectorPlaceholder(Of T)
        Inherits cCaveBranchSelectorPlaceholder

        Private oValue As T

        Public Property Value As T
            Get
                Return oValue
            End Get
            Set(value As T)
                oValue = value
            End Set
        End Property

        Public Sub New(CaveInfo As cICaveInfoBranches, EmptyCaveCaption As String, Value As T)
            MyBase.New(CaveInfo, EmptyCaveCaption)
            oValue = Value
        End Sub
    End Class

    Public Class cCaveBranchSelectorPlaceholder
        Private oCaveInfo As cICaveInfoBranches
        Private sEmptyCaveCaption As String

        Friend Sub New(CaveInfo As cICaveInfoBranches, EmptyCaveCaption As String)
            oCaveInfo = CaveInfo
            sEmptyCaveCaption = EmptyCaveCaption
        End Sub

        Public ReadOnly Property BaseInfo As cICaveInfoBranches
            Get
                Return oCaveInfo
            End Get
        End Property

        Public ReadOnly Property CaveInfo As cCaveInfo
            Get
                If oCaveInfo Is Nothing Then
                    Return Nothing
                Else
                    Return oCaveInfo.GetRoot
                End If
            End Get
        End Property

        Public ReadOnly Property CaveInfoBranch As cCaveInfoBranch
            Get
                If oCaveInfo Is Nothing Then
                    Return Nothing
                ElseIf TypeOf oCaveInfo Is cCaveInfo Then
                    Return Nothing
                Else
                    Return oCaveInfo
                End If
            End Get
        End Property

        Public ReadOnly Property Cave As String
            Get
                Return If(oCaveInfo Is Nothing, sEmptyCaveCaption, oCaveInfo.Cave)
            End Get
        End Property

        Public ReadOnly Property Branch As String
            Get
                Return If(oCaveInfo Is Nothing, "", If(TypeOf oCaveInfo Is cCaveInfo, "", oCaveInfo.Path))
            End Get
        End Property
    End Class

    Public Class cScaleVisibilityPlaceholder
        Private oScaleRule As Scale.cScaleRule
        Private sScale As String
        Private iVisibility As cVisibilityItems.VisibilityEnum

        Public ReadOnly Property [Type] As Integer
            Get
                Return 0
            End Get
        End Property

        Public ReadOnly Property ScaleRule As Scale.cScaleRule
            Get
                Return oScaleRule
            End Get
        End Property

        Public ReadOnly Property Scale As String
            Get
                Return sScale
            End Get
        End Property

        Public Property Visibility As cVisibilityItems.VisibilityEnum
            Get
                Return iVisibility
            End Get
            Set(value As cVisibilityItems.VisibilityEnum)
                iVisibility = value
            End Set
        End Property

        Public Sub New(ScaleRule As Scale.cScaleRule, Visibility As cVisibilityItems.VisibilityEnum)
            oScaleRule = ScaleRule
            sScale = "1:" & oScaleRule.Scale.ToString
            iVisibility = Visibility
        End Sub
    End Class

    Public Class cScaleVisibilityEditBindingList
        Inherits BindingList(Of cScaleVisibilityPlaceholder)

        Private oItem As Design.cItem

        Public Sub Save()
            For Each oScale As cScaleVisibilityPlaceholder In MyBase.Items
                Call oScale.ScaleRule.Items.SetVisibility(oItem, oScale.Visibility)
            Next
        End Sub

        Public Sub New(Item As Design.cItem)
            oItem = Item

            For Each oScaleRule As Scale.cScaleRule In oItem.Survey.ScaleRules
                MyBase.Add(New cScaleVisibilityPlaceholder(oScaleRule, oScaleRule.Items.GetVisibility(Item)))
            Next
        End Sub
    End Class

    Public Class cProfileVisibilityPlaceholder
        Private oProfile As cIProfile
        Private sName As String
        Private iVisibility As cVisibilityItems.VisibilityEnum

        Public ReadOnly Property Profile As cIProfile
            Get
                Return oProfile
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Enum ProfileTypeEnum
            Preview = 0
            Export = 1
        End Enum

        Public ReadOnly Property [Type] As ProfileTypeEnum
            Get
                Return If(TypeOf oProfile Is cPreviewProfile, ProfileTypeEnum.Preview, ProfileTypeEnum.Export)
            End Get
        End Property

        Public Property Visibility As cVisibilityItems.VisibilityEnum
            Get
                Return iVisibility
            End Get
            Set(value As cVisibilityItems.VisibilityEnum)
                iVisibility = value
            End Set
        End Property

        Public Sub New(Profile As cIProfile, Visibility As cVisibilityItems.VisibilityEnum)
            oProfile = Profile
            sName = oProfile.Name
            iVisibility = Visibility
        End Sub
    End Class

    Public Class cProfileVisibilityEditBindingList
        Inherits BindingList(Of cProfileVisibilityPlaceholder)

        Private oItem As Design.cItem

        Public Sub Save()
            For Each oProfile As cProfileVisibilityPlaceholder In MyBase.Items
                Call oProfile.Profile.Items.SetVisibility(oItem, oProfile.Visibility)
            Next
        End Sub

        Public Sub New(Item As Design.cItem)
            oItem = Item
            For Each oProfile As cIProfile In Item.Survey.PreviewProfiles.ToList.Where(Function(profile) profile.Design = Item.Design.Type)
                MyBase.Add(New cProfileVisibilityPlaceholder(oProfile, oProfile.Items.GetVisibility(Item)))
            Next
            For Each oProfile As cIProfile In Item.Survey.ExportProfiles.ToList.Where(Function(profile) profile.Design = Item.Design.Type)
                MyBase.Add(New cProfileVisibilityPlaceholder(oProfile, oProfile.Items.GetVisibility(Item)))
            Next
        End Sub
    End Class

    Public Class cRingPlaceholder
        Private oRing As cSurveyPC.cSurvey.Calculate.cRing

        Private oColor As Color
        Private bSelected As Boolean

        Public ReadOnly Property Ring As cSurveyPC.cSurvey.Calculate.cRing
            Get
                Return oRing
            End Get
        End Property

        Public ReadOnly Property FirstStation As String
            Get
                Return oRing.FirstStation
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oRing.Count
            End Get
        End Property

        Public ReadOnly Property [Error] As Decimal
            Get
                Return oRing.Error
            End Get
        End Property

        Public ReadOnly Property ErrorPercent As Decimal
            Get
                Return oRing.ErrorPercent
            End Get
        End Property

        Public ReadOnly Property Length As Decimal
            Get
                Return oRing.Length
            End Get
        End Property

        Public ReadOnly Property X As Decimal
            Get
                Return oRing.X
            End Get
        End Property

        Public ReadOnly Property Y As Decimal
            Get
                Return oRing.Y
            End Get
        End Property

        Public ReadOnly Property Z As Decimal
            Get
                Return oRing.Z
            End Get
        End Property

        Public Property Color As Color
            Get
                Return oColor
            End Get
            Set(value As Color)
                oColor = value
            End Set
        End Property

        Public Property Selected As Boolean
            Get
                Return bSelected
            End Get
            Set(value As Boolean)
                bSelected = value
            End Set
        End Property

        Public Sub New(Ring As cSurveyPC.cSurvey.Calculate.cRing)
            oRing = Ring
            oColor = oRing.Color
            bSelected = oRing.Selected
        End Sub

        Public Function IsChanged() As Boolean
            Return bSelected <> oRing.Selected OrElse oColor <> oRing.Color
        End Function
    End Class

    Public Class cRingsEditBindingList
        Inherits BindingList(Of cRingPlaceholder)

        Private oSurvey As cSurvey

        Public Sub InvertSelection()
            For Each oRing As cRingPlaceholder In MyBase.Items
                oRing.Selected = Not oRing.Selected
            Next
        End Sub

        Public Sub DeselectAll()
            For Each oRing As cRingPlaceholder In MyBase.Items
                oRing.Selected = False
            Next
        End Sub

        Public Sub SelectAll()
            For Each oRing As cRingPlaceholder In MyBase.Items
                oRing.Selected = True
            Next
        End Sub

        Public Sub Save()
            For Each oRing As cRingPlaceholder In MyBase.Items
                If oRing.IsChanged Then
                    oRing.Ring.Color = oRing.Color
                    oRing.Ring.Selected = oRing.Selected
                End If
            Next
        End Sub

        Public Sub New(Rings As cSurveyPC.cSurvey.Calculate.cRings)
            MyBase.New
            oSurvey = Rings.Survey
            For Each oRing As cSurveyPC.cSurvey.Calculate.cRing In Rings
                MyBase.Add(New cRingPlaceholder(oRing))
            Next
        End Sub
    End Class

    Public Class cSurveyPlaceholder
        Private bIsLinked As Boolean
        Private oLinkedSurvey As cLinkedSurvey
        Private oSurvey As cSurvey

        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Public ReadOnly Property LinkedSurvey As cLinkedSurvey
            Get
                Return oLinkedSurvey
            End Get
        End Property

        Public Function IsLinked() As Boolean
            Return Not IsNothing(oLinkedSurvey)
        End Function

        Public Function IsSystem() As Boolean
            Return oSurvey Is Nothing
        End Function

        Public Overrides Function ToString() As String
            If IsNothing(oSurvey) Then
                Return ""
            Else
                If IsNothing(oLinkedSurvey) Then
                    Return oSurvey.Name
                Else
                    Return oLinkedSurvey.ToString
                End If
            End If
        End Function

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
        End Sub

        Public Sub New(LinkedSurvey As cLinkedSurvey)
            oLinkedSurvey = LinkedSurvey
            oSurvey = oLinkedSurvey.LinkedSurvey
        End Sub

        Public Sub New()

        End Sub

        Public Shared Function Empty() As cSurveyPlaceholder
            Return New cSurveyPlaceholder()
        End Function
    End Class

    Public Class cStationValue
        Private oStation As cTrigPoint
        Private sValue As Single
        Private sFilename As String

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Public ReadOnly Property Value As Single
            Get
                Return sValue
            End Get
        End Property

        Public ReadOnly Property Station As cTrigPoint
            Get
                Return oStation
            End Get
        End Property

        Public Sub New(Station As cTrigPoint, Value As Single)
            sFilename = ""
            oStation = Station
            sValue = Value
        End Sub

        Public Sub New(Filename As String, Station As cTrigPoint, Value As Single)
            sFilename = Filename
            oStation = Station
            sValue = Value
        End Sub
    End Class

    Public Class cHighlightPlaceholder
        Inherits cEditPlaceHolder(Of Properties.cHighlightsDetail)
        Public Const Type As String = "highlight"

        Public Property ID As String
        Public Property Name As String
        Public Property Color As Color
        Public Property Size As Single
        Public Property Opacity As Byte
        Public Property ApplyTo As Properties.cHighlightsDetail.ApplyToEnum
        Public Property Condition As String = ""
        Public Property System As Boolean

        Public ReadOnly Property ImageIndex As Integer
            Get
                If MyBase.Deleted Then
                    Return 7
                Else
                    Return 6
                End If
            End Get
        End Property
    End Class

    Public Class cHighlightEditBindingList
        Inherits BindingList(Of cHighlightPlaceholder)

        Private oSurvey As cSurvey

        Public Overloads Function Remove(Item As cHighlightPlaceholder) As Boolean
            If Item.System Then
                Return False
            Else
                If oSurvey.Properties.HighlightsDetails.Contains(Item.Source) Then
                    Item.Deleted = True
                    Return False
                Else
                    Call MyBase.Remove(Item)
                    Return True
                End If
            End If
        End Function

        Public Sub Save()
            With oSurvey.Properties
                For Each oCI As cHighlightPlaceholder In MyBase.Items
                    If oCI.Deleted And Not oCI.Created Then
                        Call .HighlightsDetails.Remove(oCI.ID)
                    ElseIf oCI.Created Then
                        Dim oHighlight As Properties.cHighlightsDetail = .HighlightsDetails.Add(oCI.Name, oCI.ApplyTo, oCI.Condition)
                        oHighlight.Name = oCI.Name
                        oHighlight.Size = oCI.Size
                        oHighlight.Opacity = oCI.Opacity
                        oHighlight.Color = oCI.Color
                        oHighlight.ApplyTo = oCI.ApplyTo
                        oHighlight.Condition = oCI.Condition
                    Else
                        Dim oHighlight As Properties.cHighlightsDetail = oCI.Source
                        oHighlight.Name = oCI.Name
                        oHighlight.Size = oCI.Size
                        oHighlight.Opacity = oCI.Opacity
                        oHighlight.Color = oCI.Color
                        oHighlight.ApplyTo = oCI.ApplyTo
                        oHighlight.Condition = oCI.Condition
                    End If
                Next
            End With
        End Sub

        Public Overloads Function Add(ApplyTo As Properties.cHighlightsDetail.ApplyToEnum) As cHighlightPlaceholder
            Dim sID As String = Guid.NewGuid.ToString
            Dim sName As String = String.Format(modMain.GetLocalizedString("properties.textpart2"), MyBase.Count + 1)
            Dim oCI As cHighlightPlaceholder = New cHighlightPlaceholder
            oCI.ID = ""
            oCI.Name = sName
            oCI.Color = Color.Red
            oCI.Size = 10
            oCI.Opacity = 140
            oCI.Source = Nothing
            oCI.ApplyTo = ApplyTo
            oCI.System = False
            oCI.Created = True

            Call MyBase.Add(oCI)
            Return oCI
        End Function

        Public Sub New(Survey As cSurvey)
            MyBase.New

            oSurvey = Survey

            For Each oHighlight As Properties.cHighlightsDetail In oSurvey.Properties.HighlightsDetails
                Dim oCI As cHighlightPlaceholder = New cHighlightPlaceholder
                oCI.ID = oHighlight.ID
                oCI.Name = oHighlight.Name
                oCI.Color = oHighlight.Color
                oCI.Size = oHighlight.Size
                oCI.Opacity = oHighlight.Opacity
                oCI.ApplyTo = oHighlight.ApplyTo
                oCI.Condition = oHighlight.Condition
                oCI.System = oHighlight.System

                oCI.Source = oHighlight

                Call MyBase.Add(oCI)
            Next
        End Sub
    End Class

    Public Interface cICaveInfoBasePlaceHolder
        Property ID As String
        Property Name As String
        Property Color As Color
        Property Description As String
        Property SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum
        Property Locked As Boolean
        Property ExtendStart As String
        Property Priority As Integer?
        Property ParentConnection As cConnectionDef
        Property Connection As cConnectionDef
        Property Parent As cICaveInfoBasePlaceHolder
        ReadOnly Property Item As Object
        ReadOnly Property ImageIndex As Integer

        Property Created As Boolean
        Property Deleted As Boolean
        'ReadOnly Property Moved As Boolean

        Function GetSource() As Object

        Function GetPath() As String()
        Function GetOriginalPath() As String()

        Property Source As Object

        ReadOnly Property Type As String

        Sub Move(NewParent As cICaveInfoBasePlaceHolder)
    End Interface

    Public Class cCaveInfoBasePlaceHolder(Of T)
        Inherits cEditPlaceHolder(Of T)
        Implements cICaveInfoBasePlaceHolder

        Public Sub New(Parent As Object)
            Me.Parent = Parent
            oOriginalParent = Parent
        End Sub

        Property ID As String Implements cICaveInfoBasePlaceHolder.ID
        Property Name As String Implements cICaveInfoBasePlaceHolder.Name
        Property Color As Color Implements cICaveInfoBasePlaceHolder.Color
        Property Description As String Implements cICaveInfoBasePlaceHolder.Description
        Property SurfaceProfileShow As cISurfaceProfile.SurfaceProfileShowEnum Implements cICaveInfoBasePlaceHolder.SurfaceProfileShow
        Property Locked As Boolean Implements cICaveInfoBasePlaceHolder.Locked
        Property ExtendStart As String Implements cICaveInfoBasePlaceHolder.ExtendStart
        Property Priority As Integer? Implements cICaveInfoBasePlaceHolder.Priority
        Property ParentConnection As cConnectionDef Implements cICaveInfoBasePlaceHolder.ParentConnection
        Property Connection As cConnectionDef Implements cICaveInfoBasePlaceHolder.Connection
        Property Parent As cICaveInfoBasePlaceHolder Implements cICaveInfoBasePlaceHolder.Parent

        Public Shadows Property Created As Boolean Implements cICaveInfoBasePlaceHolder.Created
            Get
                Return MyBase.Created
            End Get
            Set(value As Boolean)
                MyBase.Created = value
            End Set
        End Property

        Public Shadows Property Deleted As Boolean Implements cICaveInfoBasePlaceHolder.Deleted
            Get
                Return MyBase.Deleted
            End Get
            Set(value As Boolean)
                MyBase.Deleted = value
            End Set
        End Property

        Public Shadows Property Source As Object Implements cICaveInfoBasePlaceHolder.Source
            Get
                Return MyBase.Source
            End Get
            Set(value As Object)
                MyBase.Source = value
            End Set
        End Property

        Function GetSource() As Object Implements cICaveInfoBasePlaceHolder.GetSource
            Return MyBase.Source
        End Function

        Public ReadOnly Property Item As Object Implements cICaveInfoBasePlaceHolder.Item
            Get
                Return Me
            End Get
        End Property

        Public ReadOnly Property ImageIndex As Integer Implements cICaveInfoBasePlaceHolder.ImageIndex
            Get
                If MyBase.Deleted Then
                    Return 7
                Else
                    Select Case Type
                        Case "cave"
                            If ExtendStart = "" Then
                                Return 1
                            Else
                                Return 2
                            End If
                        Case Else
                            If ExtendStart = "" Then
                                Return 4
                            Else
                                Return 5
                            End If
                    End Select
                End If
            End Get
        End Property

        Public ReadOnly Property Type As String Implements cICaveInfoBasePlaceHolder.Type
            Get
                If TypeOf MyBase.Source Is cCaveInfo Then
                    Return "cave"
                Else
                    Return "branch"
                End If
            End Get
        End Property

        'Private bMoved As Boolean
        Private oOriginalParent As Object
        'Private iOriginalPosition As Integer
        'Private sOriginaleCave As String
        'Private sOriginalBranch As String

        'Public ReadOnly Property Moved As Boolean Implements cICaveInfoBasePlaceHolder.Moved
        '    Get
        '        Return bMoved
        '    End Get
        'End Property

        Public Function GetPath() As String() Implements cICaveInfoBasePlaceHolder.GetPath
            If Parent Is Nothing Then
                Return {Name, ""}
            Else
                Dim oPath As String() = Parent.GetPath()
                Return {oPath(0), If(oPath(1) = "", Name, oPath(1) & cCaveInfoBranches.sBranchSeparator & Name)}
            End If
        End Function

        Public Function GetOriginalPath() As String() Implements cICaveInfoBasePlaceHolder.GetOriginalPath
            If oOriginalParent Is Nothing Then
                Return {Source.name, ""}
            Else
                Dim oPath As String() = oOriginalParent.GetOriginalPath()
                Return {oPath(0), If(oPath(1) = "", Source.name, oPath(1) & cCaveInfoBranches.sBranchSeparator & Source.name)}
            End If
        End Function


        Public Sub Move(NewParent As cICaveInfoBasePlaceHolder) Implements cICaveInfoBasePlaceHolder.Move
            If NewParent IsNot Parent Then
                Parent = NewParent
            End If
        End Sub


    End Class

        Public Class cCaveInfoPlaceHolder
        Inherits cCaveInfoBasePlaceHolder(Of cCaveInfo)

        Public Sub New()
            MyBase.New(Nothing)
        End Sub
    End Class

    Public Class cCaveInfoBranchPlaceHolder
        Inherits cCaveInfoBasePlaceHolder(Of cCaveInfoBranch)

        'Public Sub Move(SourceCollection As cCaveInfoBranchEditBindingList, SourceItem As cICaveInfoBasePlaceHolder, NewParent As cICaveInfoBasePlaceHolder, NewPosition As Integer)
        '    SourceItem.SetMoved(SourceItem.Parent, SourceCollection.IndexOf(SourceItem))
        '    SourceItem.Parent = NewParent
        '    SourceCollection.
        'End Sub

        'Public Sub CopyFrom(SourceCollection As cCaveInfoBranchEditBindingList, SourceItem As cICaveInfoBasePlaceHolder)
        '    MyBase.ID = SourceItem.ID
        '    MyBase.Name = SourceItem.Name
        '    MyBase.Color = SourceItem.Color
        '    MyBase.Description = SourceItem.Description
        '    MyBase.SurfaceProfileShow = SourceItem.SurfaceProfileShow
        '    MyBase.Locked = SourceItem.Locked
        '    MyBase.ExtendStart = SourceItem.ExtendStart
        '    MyBase.Priority = SourceItem.Priority
        '    MyBase.ParentConnection = SourceItem.ParentConnection
        '    MyBase.Connection = SourceItem.Connection

        '    For Each oChildItem As cICaveInfoBasePlaceHolder In SourceCollection.Where(Function(oItem) oItem.Parent Is SourceItem).ToList
        '        Dim oNewChildItem As cCaveInfoBranchPlaceHolder = New cCaveInfoBranchPlaceHolder(Me)
        '        oNewChildItem.CopyFrom(SourceCollection, oChildItem)
        '        SourceCollection.Add(oNewChildItem)
        '        Call SourceCollection.Remove(oChildItem)
        '    Next

        'End Sub

        Public Sub New(Parent As Object)
            MyBase.New(Parent)
        End Sub
    End Class

    Public Class cCaveInfoBranchEditBindingList
        Inherits BindingList(Of cICaveInfoBasePlaceHolder)

        Private oSurvey As cSurvey

        Public Sub Move(SourceItem As cICaveInfoBasePlaceHolder, NewPosition As Integer)
            MyBase.Remove(SourceItem)
            MyBase.Insert(NewPosition, SourceItem)
        End Sub

        Public Sub Move(SourceItem As cICaveInfoBasePlaceHolder, NewParent As cICaveInfoBasePlaceHolder, NewPosition As Integer)
            SourceItem.Move(NewParent)
            MyBase.Remove(SourceItem)
            MyBase.Insert(NewPosition, SourceItem)
        End Sub

        Private Function pGetRootItem(Item As cCaveInfoBranchPlaceHolder) As cCaveInfoPlaceHolder
            If TypeOf Item.Parent Is cCaveInfoPlaceHolder Then
                Return Item.Parent
            Else
                Return pGetRootItem(Item.Parent)
            End If
        End Function

        Private Sub pRecursiveRemove(Parent As Object)
            For Each oItemToRemove As cICaveInfoBasePlaceHolder In MyBase.Items.Where(Function(oitem) oitem.Parent Is Parent).ToList
                Call MyBase.Remove(oItemToRemove)
                Call pRecursiveRemove(oItemToRemove)
            Next
        End Sub

        Private Sub pRecursiveDelete(Parent As Object)
            For Each oItemToRemove As cICaveInfoBasePlaceHolder In MyBase.Items.Where(Function(oitem) oitem.Parent Is Parent).ToList
                Select Case oItemToRemove.Type
                    Case "cave"
                        Dim oCI As cCaveInfoPlaceHolder = oItemToRemove
                        oCI.Deleted = True
                    Case "branch"
                        Dim oCI As cCaveInfoBranchPlaceHolder = oItemToRemove
                        oCI.Deleted = True
                End Select
                Call pRecursiveDelete(oItemToRemove)
            Next
        End Sub

        Public Overloads Function Remove(Item As cICaveInfoBasePlaceHolder) As Boolean
            Select Case Item.Type
                Case "cave"
                    Dim oCI As cCaveInfoPlaceHolder = Item
                    If oSurvey.Properties.CaveInfos.Contains(oCI.Source) Then
                        oCI.Deleted = True
                        Call pRecursiveDelete(Item)
                        Return False
                    Else
                        Call MyBase.Remove(Item)
                        Call pRecursiveRemove(Item)
                        Return True
                    End If
                Case "branch"
                    Dim oCI As cCaveInfoPlaceHolder = pGetRootItem(Item)
                    Dim oCIB As cCaveInfoBranchPlaceHolder = Item
                    If oSurvey.Properties.CaveInfos.Contains(oCI.Source) Then
                        If oCI.Source.Branches.GetAllBranches.Values.Contains(oCIB.Source) Then
                            oCIB.Deleted = True
                            Call pRecursiveDelete(Item)
                            Return False
                        Else
                            Call MyBase.Remove(Item)
                            Call pRecursiveRemove(Item)
                            Return True
                        End If
                    Else
                        Call MyBase.Remove(Item)
                        Call pRecursiveRemove(Item)
                        Return True
                    End If
            End Select
        End Function

        Private Sub pCaveBranchesSave(Parent As cICaveInfoBasePlaceHolder, ParentBranches As cCaveInfoBranches)
            Dim iIndex As Integer = 0
            For Each oCIB As cICaveInfoBasePlaceHolder In MyBase.Items.Where(Function(oitem) oitem.Parent Is Parent).ToList
                If oCIB.Deleted And Not oCIB.Created Then
                    Call ParentBranches.Remove(oCIB.Name, True)
                ElseIf oCIB.Created Then
                    Dim oCaveInfoBranch As cCaveInfoBranch = ParentBranches.Add(oCIB.Name)
                    oCaveInfoBranch.Color = oCIB.Color
                    oCaveInfoBranch.Description = oCIB.Description
                    oCaveInfoBranch.SurfaceProfileShow = oCIB.SurfaceProfileShow
                    oCaveInfoBranch.Locked = oCIB.Locked
                    oCaveInfoBranch.ExtendStart = oCIB.ExtendStart
                    oCaveInfoBranch.Priority = oCIB.Priority
                    oCaveInfoBranch.ParentConnection = oCIB.ParentConnection
                    oCaveInfoBranch.Connection = oCIB.Connection
                    oCaveInfoBranch.SetOrdinalPosition(iIndex)
                    Dim oNewCIB As cCaveInfoBranchPlaceHolder = Add(Parent, oCaveInfoBranch)
                    MyBase.Remove(oNewCIB)
                    For Each oChildItem As cICaveInfoBasePlaceHolder In MyBase.Items.Where(Function(oitem) oitem.Parent Is oCIB).ToList
                        oChildItem.Parent = oNewCIB
                    Next
                    Dim iCIIndex As Integer = MyBase.IndexOf(oCIB)
                    MyBase.RemoveAt(iCIIndex)
                    MyBase.Insert(iCIIndex, oNewCIB)
                    oCIB = oNewCIB
                Else
                    Dim oCaveInfoBranch As cCaveInfoBranch = oCIB.Source
                    oCaveInfoBranch.Color = oCIB.Color
                    oCaveInfoBranch.Description = oCIB.Description
                    oCaveInfoBranch.SurfaceProfileShow = oCIB.SurfaceProfileShow
                    oCaveInfoBranch.Locked = oCIB.Locked
                    oCaveInfoBranch.ExtendStart = oCIB.ExtendStart
                    oCaveInfoBranch.Priority = oCIB.Priority
                    oCaveInfoBranch.ParentConnection = oCIB.ParentConnection
                    oCaveInfoBranch.Connection = oCIB.Connection
                    oCaveInfoBranch.SetOrdinalPosition(iIndex)
                    Dim sNewName As String = oCIB.Name
                    Dim sOldName As String = oCaveInfoBranch.Name
                    If sNewName.ToLower <> sOldName.ToLower Then
                        Call ParentBranches.Rename(sOldName, sNewName, False)
                    End If
                End If
                Call pCaveBranchesSave(oCIB, oCIB.Source.Branches)
                iIndex += 1
            Next
        End Sub

        Public Sub Save()
            With oSurvey.Properties
                For Each oCI As cICaveInfoBasePlaceHolder In MyBase.Items
                    Dim sNewPath As String() = oCI.GetPath
                    Dim sNewCave As String = sNewPath(0).ToLower
                    Dim sNewBranch As String = sNewPath(1).ToLower

                    Dim sPath As String() = oCI.GetOriginalPath
                    Dim sCave As String = sPath(0).ToLower
                    Dim sBranch As String = sPath(1).ToLower

                    If sNewCave <> sCave OrElse sNewBranch <> sBranch Then
                        If TypeOf oCI.Source Is cCaveInfo Then
                            .CaveInfos.Remove(oCI.Source.name)
                        ElseIf TypeOf oCI.Source Is cCaveInfoBranch Then
                            With DirectCast(oCI.Source, cCaveInfoBranch)
                                If .Parent Is Nothing Then
                                    .GetCave.Branches.Remove(oCI.Source.name)
                                Else
                                    .Parent.Branches.Remove(oCI.Source.name)
                                End If
                            End With
                        End If
                        oCI.Created = True
                        oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "Moving shots from " & sCave & cCaveInfoBranches.sBranchSeparator & sBranch & " to " & sNewCave & cCaveInfoBranches.sBranchSeparator & sNewBranch)
                        For Each oSegment As cSegment In oSurvey.Segments.GetCaveSegments(sCave, sBranch)
                            oSegment.RenameCave(sNewCave, sNewBranch)
                        Next
                        oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "Moving design items from " & sCave & cCaveInfoBranches.sBranchSeparator & sBranch & " to " & sNewCave & cCaveInfoBranches.sBranchSeparator & sNewBranch)
                        For Each oItem As Design.cItem In oSurvey.GetAllDesignItems()
                            If oItem.Cave.ToLower = sCave AndAlso oItem.Branch.ToLower = sBranch Then
                                oItem.RenameCave(sNewCave, sNewBranch)
                            End If
                        Next
                    End If
                Next

                Dim iIndex As Integer = 0
                For Each oCI As cICaveInfoBasePlaceHolder In MyBase.Items.Where(Function(oitem) oitem.Parent Is Nothing).ToList
                    If oCI.Deleted And Not oCI.Created Then
                        Call .CaveInfos.Remove(oCI.Name, True)
                    ElseIf oCI.Created Then
                        Dim oCaveInfo As cCaveInfo = .CaveInfos.Add(oCI.Name)
                        oCaveInfo.ID = oCI.ID
                        oCaveInfo.Color = oCI.Color
                        oCaveInfo.Description = oCI.Description
                        oCaveInfo.SurfaceProfileShow = oCI.SurfaceProfileShow
                        oCaveInfo.Locked = oCI.Locked
                        oCaveInfo.ExtendStart = oCI.ExtendStart
                        oCaveInfo.Priority = oCI.Priority
                        oCaveInfo.ParentConnection = oCI.ParentConnection
                        oCaveInfo.Connection = oCI.Connection
                        oCaveInfo.SetOrdinalPosition(iIndex)
                        Dim oNewCI As cCaveInfoPlaceHolder = Add(oCaveInfo)
                        MyBase.Remove(oNewCI)
                        For Each oChildItem As cICaveInfoBasePlaceHolder In MyBase.Items.Where(Function(oitem) oitem.Parent Is oCI).ToList
                            oChildItem.Parent = oNewCI
                        Next
                        Dim iCIIndex As Integer = MyBase.IndexOf(oCI)
                        MyBase.RemoveAt(iCIIndex)
                        MyBase.Insert(iCIIndex, oNewCI)
                        oCI = oNewCI
                    Else
                        oCI.Source.ID = oCI.ID
                        oCI.Source.Color = oCI.Color
                        oCI.Source.Description = oCI.Description
                        oCI.Source.SurfaceProfileShow = oCI.SurfaceProfileShow
                        oCI.Source.Locked = oCI.Locked
                        oCI.Source.ExtendStart = oCI.ExtendStart
                        oCI.Source.Priority = oCI.Priority
                        oCI.Source.ParentConnection = oCI.ParentConnection
                        oCI.Source.Connection = oCI.Connection
                        If TypeOf oCI.Source Is cCaveInfo Then
                            DirectCast(oCI.Source, cCaveInfo).SetOrdinalPosition(iIndex)
                        ElseIf TypeOf oCI.Source Is cCaveInfoBranch Then
                            DirectCast(oCI.Source, cCaveInfoBranch).SetOrdinalPosition(iIndex)
                        End If
                        Dim sNewName As String = oCI.Name
                        Dim sOldName As String = oCI.Source.Name
                        If sNewName.ToLower <> sOldName.ToLower Then
                            Call .CaveInfos.Rename(sOldName, sNewName, False)
                        End If
                    End If
                    Call pCaveBranchesSave(oCI, oCI.Source.Branches)
                    iIndex += 1
                Next

                'For Each oCI As cCaveInfoPlaceHolder In MyBase.Items.Where(Function(oitem) TypeOf oitem Is cCaveInfoPlaceHolder)
                '    If oCI.Deleted And Not oCI.Created Then
                '        Call .CaveInfos.Remove(oCI.Name, True)
                '    ElseIf oCI.Created Then
                '        Dim oCaveInfo As cCaveInfo = .CaveInfos.Add(oCI.Name)
                '        oCaveInfo.ID = oCI.ID
                '        oCaveInfo.Color = oCI.Color
                '        oCaveInfo.Description = oCI.Description
                '        oCaveInfo.SurfaceProfileShow = oCI.SurfaceProfileShow
                '        oCaveInfo.Locked = oCI.Locked
                '        oCaveInfo.ExtendStart = oCI.ExtendStart
                '        oCaveInfo.Priority = oCI.Priority
                '        oCaveInfo.ParentConnection = oCI.ParentConnection
                '        oCaveInfo.Connection = oCI.Connection
                '        oCI.Source = oCaveInfo
                '    Else
                '        oCI.Source.ID = oCI.ID
                '        oCI.Source.Color = oCI.Color
                '        oCI.Source.Description = oCI.Description
                '        oCI.Source.SurfaceProfileShow = oCI.SurfaceProfileShow
                '        oCI.Source.Locked = oCI.Locked
                '        oCI.Source.ExtendStart = oCI.ExtendStart
                '        oCI.Source.Priority = oCI.Priority
                '        oCI.Source.ParentConnection = oCI.ParentConnection
                '        oCI.Source.Connection = oCI.Connection
                '        Dim sNewName As String = oCI.Name
                '        Dim sOldName As String = oCI.Source.Name
                '        If sNewName.ToLower <> sOldName.ToLower Then
                '            Call .CaveInfos.Rename(sOldName, sNewName, True)
                '        End If
                '    End If
                '    Call pCaveBranchesSave(oCI, oCI.Source.Branches)
                'Next
            End With
        End Sub

        Public Function ContainsName(Name As String) As Boolean
            Return Not MyBase.FirstOrDefault(Function(oitem) oitem.Name = Name) Is Nothing
        End Function

        Private Function pAdd(CaveInfo As cCaveInfo) As cCaveInfoPlaceHolder
            Dim oCI As cCaveInfoPlaceHolder = New cCaveInfoPlaceHolder
            oCI.Description = CaveInfo.Description
            oCI.Name = CaveInfo.Name
            oCI.ID = CaveInfo.ID
            oCI.Color = CaveInfo.Color
            oCI.SurfaceProfileShow = CaveInfo.SurfaceProfileShow
            oCI.Locked = CaveInfo.Locked
            oCI.ExtendStart = CaveInfo.ExtendStart
            oCI.Priority = CaveInfo.Priority
            oCI.ParentConnection = CaveInfo.ParentConnection
            oCI.Connection = CaveInfo.Connection
            oCI.Source = CaveInfo
            MyBase.Add(oCI)
            Return oCI
        End Function

        Public Sub Move(Index As Integer, NewIndex As Integer)
            Dim oCI As cCaveInfoPlaceHolder = MyBase.Item(Index)
            MyBase.RemoveAt(Index)
            MyBase.Insert(NewIndex, oCI)
        End Sub

        Public Overloads Function Add(CaveInfo As cCaveInfo) As cCaveInfoPlaceHolder
            Dim oCI As cCaveInfoPlaceHolder = pAdd(CaveInfo)
            oCI.Created = True
            Return oCI
        End Function

        Private Function pAdd(Parent As cICaveInfoBasePlaceHolder, CaveInfoBranch As cCaveInfoBranch) As cCaveInfoBranchPlaceHolder
            Dim oCIB As cCaveInfoBranchPlaceHolder = New cCaveInfoBranchPlaceHolder(Parent)
            oCIB.Name = CaveInfoBranch.Name
            oCIB.Color = CaveInfoBranch.Color
            oCIB.Description = CaveInfoBranch.Description
            oCIB.SurfaceProfileShow = CaveInfoBranch.SurfaceProfileShow
            oCIB.Locked = CaveInfoBranch.Locked
            oCIB.ExtendStart = CaveInfoBranch.ExtendStart
            oCIB.Priority = CaveInfoBranch.Priority
            oCIB.ParentConnection = CaveInfoBranch.ParentConnection
            oCIB.Connection = CaveInfoBranch.Connection
            oCIB.Source = CaveInfoBranch
            MyBase.Add(oCIB)
            Return oCIB
        End Function

        Public Overloads Function Add(Parent As cICaveInfoBasePlaceHolder, CaveInfoBranch As cCaveInfoBranch) As cCaveInfoBranchPlaceHolder
            Dim oCIB As cCaveInfoBranchPlaceHolder = pAdd(Parent, CaveInfoBranch)
            oCIB.Created = True
            Return oCIB
        End Function

        Private Sub pCaveBranchesLoad(Parent As cICaveInfoBasePlaceHolder, ParentBranches As cCaveInfoBranches)
            For Each oCaveInfoBranch As cCaveInfoBranch In ParentBranches.ByOrdinalPosition
                Dim oCIB As cCaveInfoBranchPlaceHolder = pAdd(Parent, oCaveInfoBranch)
                Call pCaveBranchesLoad(oCIB, oCaveInfoBranch.Branches)
            Next
        End Sub

        Public Sub New(Survey As cSurvey)
            MyBase.New

            oSurvey = Survey

            For Each oCaveInfo As cCaveInfo In oSurvey.Properties.CaveInfos.ByOrdinalPosition
                Dim oCI As cCaveInfoPlaceHolder = pAdd(oCaveInfo)
                Call pCaveBranchesLoad(oCI, oCaveInfo.Branches)
            Next
        End Sub
    End Class

    Public MustInherit Class cEditPlaceHolder(Of SourceType)
        Public Source As SourceType
        Public Created As Boolean
        Public Deleted As Boolean
    End Class

    Public Class cDefaultSessionEditPlaceHolder
        Inherits cSessionEditPlaceHolder

        Private sType As String = "defaultsession"

        Public Sub New()
            MyBase.New
            MyBase.Description = modMain.GetLocalizedString("properties.textpart3")
        End Sub

        Public Overrides ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property

        Public Overrides ReadOnly Property FormattedID As String
            Get
                Return modMain.GetLocalizedString("properties.textpart3")
            End Get
        End Property
    End Class

    Public Class cSessionEditPlaceHolder
        Inherits cEditPlaceHolder(Of cSession)
        Private sType As String = "session"

        Public Overridable ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property

        Public Name As String

        Public ReadOnly Property ID As String
            Get
                Return Strings.Format([Date], "yyyyMMdd") & "_" & Description.Replace(" ", "_").ToLower
            End Get
        End Property

        Public Overridable ReadOnly Property FormattedID As String
            Get
                Return Strings.Format([Date], "dd-MM-yyyy") & " " & Description
            End Get
        End Property

        Public [Date] As Date
        Public Description As String
        Public Club As String
        Public Note As String
        Public Team As String
        Public Designer As String

        Public DataFormat As cSegment.DataFormatEnum
        Public DistanceType As cSegment.DistanceTypeEnum
        Public BearingType As cSegment.BearingTypeEnum
        Public BearingDirection As cSegment.MeasureDirectionEnum
        Public InclinationType As cSegment.InclinationTypeEnum
        Public InclinationDirection As cSegment.MeasureDirectionEnum
        Public DepthType As cSegment.DepthTypeEnum

        Public DepthCalibration As cCalibration
        Public DistanceCalibration As cCalibration
        Public BearingCalibration As cCalibration
        Public InclinationCalibration As cCalibration

        Public Grade As String

        Public NordType As cSegment.NordTypeEnum
        Public Declination As Single
        Public declinationenabled As Boolean

        Public SideMeasuresType As cSegment.SideMeasuresTypeEnum
        Public SideMeasuresReferTo As cSegment.SideMeasuresReferToEnum

        Public VThreshold As Integer
        Public VThresholdEnabled As Boolean

        Public Color As Color

        Public ReadOnly Property ImageIndex As Integer
            Get
                If MyBase.Deleted Then
                    Return 7
                Else
                    Return 0
                End If
            End Get
        End Property
    End Class

    Public Class cSessionsEditBindingList
        Inherits BindingList(Of cSessionEditPlaceHolder)

        Private oSurvey As cSurvey

        Public Sub Save()
            With oSurvey.Properties
                For Each oCI As cSessionEditPlaceHolder In MyBase.Items
                    If TypeOf oCI Is cDefaultSessionEditPlaceHolder Then
                        .DataFormat = oCI.DataFormat
                        .DistanceType = oCI.DistanceType
                        .BearingType = oCI.BearingType
                        .BearingDirection = oCI.BearingDirection
                        .InclinationType = oCI.InclinationType
                        .InclinationDirection = oCI.InclinationDirection
                        .DepthType = oCI.DepthType

                        .Grade = oCI.Grade

                        .NordType = oCI.NordType
                        .DeclinationEnabled = oCI.declinationenabled
                        .Declination = oCI.Declination

                        .SideMeasuresType = oCI.SideMeasuresType
                        .SideMeasuresReferTo = oCI.SideMeasuresReferTo

                        .VThresholdEnabled = oCI.VThresholdEnabled
                        .VThreshold = oCI.VThreshold
                    Else
                        If oCI.Deleted And Not oCI.Created Then
                            Call .Sessions.Remove(oCI.ID)
                        ElseIf oCI.Created Then
                            Dim oSession As cSession = .Sessions.Add(oCI.Date, oCI.Description)
                            oSession.Club = oCI.Club
                            oSession.Team = oCI.Team
                            oSession.Designer = oCI.Designer
                            oSession.Note = oCI.Note
                            oSession.Color = oCI.Color

                            oSession.DataFormat = oCI.DataFormat
                            oSession.DistanceType = oCI.DistanceType
                            oSession.BearingType = oCI.BearingType
                            oSession.BearingDirection = oCI.BearingDirection
                            oSession.InclinationType = oCI.InclinationType
                            oSession.InclinationDirection = oCI.InclinationDirection
                            oSession.DepthType = oCI.DepthType

                            oSession.DepthCalibration.CopyFrom(oCI.DepthCalibration)
                            oSession.DistanceCalibration.CopyFrom(oCI.DistanceCalibration)
                            oSession.BearingCalibration.CopyFrom(oCI.BearingCalibration)
                            oSession.InclinationCalibration.CopyFrom(oCI.InclinationCalibration)

                            oSession.Grade = oCI.Grade

                            oSession.NordType = oCI.NordType
                            oSession.Declination = oCI.Declination
                            oSession.DeclinationEnabled = oCI.declinationenabled

                            oSession.SideMeasuresType = oCI.SideMeasuresType
                            oSession.SideMeasuresReferTo = oCI.SideMeasuresReferTo

                            oSession.VThresholdEnabled = oCI.VThresholdEnabled
                            oSession.VThreshold = oCI.VThreshold
                        Else
                            Dim oSession As cSession = oCI.Source
                            Dim sNewID As String = oCI.ID
                            Dim sOldID As String = oCI.Source.ID
                            If sNewID.ToLower <> sOldID.ToLower Then
                                Call .Sessions.Rename(sOldID, oCI.Date, oCI.Description)
                            End If

                            oSession.Club = oCI.Club
                            oSession.Team = oCI.Team
                            oSession.Designer = oCI.Designer
                            oSession.Note = oCI.Note
                            oSession.Color = oCI.Color

                            oSession.DataFormat = oCI.DataFormat
                            oSession.DistanceType = oCI.DistanceType
                            oSession.BearingType = oCI.BearingType
                            oSession.BearingDirection = oCI.BearingDirection
                            oSession.InclinationType = oCI.InclinationType
                            oSession.InclinationDirection = oCI.InclinationDirection
                            oSession.DepthType = oCI.DepthType

                            oSession.DepthCalibration.CopyFrom(oCI.DepthCalibration)
                            oSession.DistanceCalibration.CopyFrom(oCI.DistanceCalibration)
                            oSession.BearingCalibration.CopyFrom(oCI.BearingCalibration)
                            oSession.InclinationCalibration.CopyFrom(oCI.InclinationCalibration)

                            oSession.Grade = oCI.Grade

                            oSession.NordType = oCI.NordType
                            oSession.Declination = oCI.Declination
                            oSession.DeclinationEnabled = oCI.declinationenabled

                            oSession.SideMeasuresType = oCI.SideMeasuresType
                            oSession.SideMeasuresReferTo = oCI.SideMeasuresReferTo

                            oSession.VThresholdEnabled = oCI.VThresholdEnabled
                            oSession.VThreshold = oCI.VThreshold
                        End If
                    End If
                Next
            End With
        End Sub

        Public Function ContainsID(ID As String) As Boolean
            Return Not MyBase.FirstOrDefault(Function(oitem) oitem.ID = ID) Is Nothing
        End Function

        Public Overloads Function Add() As cSessionEditPlaceHolder
            Dim sNewID As String
            Dim sNewDescriptionBase As String = modMain.GetLocalizedString("properties.textpart1")
            Dim iNewCount As Integer = 0
            Do
                iNewCount += 1
                sNewID = Strings.Format(Today, "yyyyMMdd") & "_" & (sNewDescriptionBase & " " & iNewCount).Replace(" ", "_").ToLower
            Loop While ContainsID(sNewID)
            Dim oSession As cSession = oSurvey.Properties.Sessions.GetEmptySession(Today, sNewDescriptionBase & " " & iNewCount)
            Dim oCI As cSessionEditPlaceHolder = pAdd(oSession)
            oCI.Created = True
            Return oCI
        End Function

        Public Overloads Function Remove(Item As cSessionEditPlaceHolder) As Boolean
            If oSurvey.Properties.Sessions.Contains(Item.Source) Then
                Item.Deleted = True
                Return False
            Else
                Call MyBase.Remove(Item)
                Return True
            End If
        End Function

        Private Function pAdd(Session As cSession) As cSessionEditPlaceHolder
            Dim oCI As cSessionEditPlaceHolder = New cSessionEditPlaceHolder
            oCI.Date = Session.Date
            oCI.Description = Session.Description
            oCI.Color = Session.Color

            oCI.Team = Session.Team
            oCI.Club = Session.Club
            oCI.Designer = Session.Designer
            oCI.Note = Session.Note

            oCI.DataFormat = Session.DataFormat
            oCI.DistanceType = Session.DistanceType
            oCI.BearingType = Session.BearingType
            oCI.BearingDirection = Session.BearingDirection
            oCI.InclinationType = Session.InclinationType
            oCI.InclinationDirection = Session.InclinationDirection
            oCI.DepthType = Session.DepthType

            oCI.DepthCalibration = New cCalibration(Session.DepthCalibration)
            oCI.DistanceCalibration = New cCalibration(Session.DistanceCalibration)
            oCI.BearingCalibration = New cCalibration(Session.BearingCalibration)
            oCI.InclinationCalibration = New cCalibration(Session.InclinationCalibration)

            oCI.Grade = Session.Grade

            oCI.NordType = Session.NordType
            oCI.Declination = Session.Declination
            oCI.declinationenabled = Session.DeclinationEnabled

            oCI.SideMeasuresType = Session.SideMeasuresType
            oCI.SideMeasuresReferTo = Session.SideMeasuresReferTo

            oCI.VThreshold = Session.VThreshold
            oCI.VThresholdEnabled = Session.VThresholdEnabled

            oCI.Source = Session

            MyBase.Add(oCI)

            Return oCI
        End Function

        Public Sub New(Survey As cSurvey)
            MyBase.New

            oSurvey = Survey

            Dim oDefaultCI As cDefaultSessionEditPlaceHolder = New cDefaultSessionEditPlaceHolder

            oDefaultCI.DataFormat = Survey.Properties.DataFormat
            oDefaultCI.DistanceType = Survey.Properties.DistanceType
            oDefaultCI.BearingType = Survey.Properties.BearingType
            oDefaultCI.BearingDirection = Survey.Properties.BearingDirection
            oDefaultCI.InclinationType = Survey.Properties.InclinationType
            oDefaultCI.InclinationDirection = Survey.Properties.InclinationDirection
            oDefaultCI.DepthType = Survey.Properties.DepthType

            oDefaultCI.Grade = Survey.Properties.Grade

            oDefaultCI.NordType = Survey.Properties.NordType
            oDefaultCI.Declination = Survey.Properties.Declination
            oDefaultCI.declinationenabled = Survey.Properties.DeclinationEnabled

            oDefaultCI.SideMeasuresType = Survey.Properties.SideMeasuresType
            oDefaultCI.SideMeasuresReferTo = Survey.Properties.SideMeasuresReferTo

            oDefaultCI.VThreshold = Survey.Properties.VThreshold
            oDefaultCI.VThresholdEnabled = Survey.Properties.VThresholdEnabled

            oDefaultCI.Source = Nothing

            MyBase.Add(oDefaultCI)

            For Each oSession As cSession In Survey.Properties.Sessions
                Call pAdd(oSession)
            Next
        End Sub
    End Class

    Public Class cDataFieldPlaceHolder
        Private sName As String
        Private iType As Data.cDataFields.TypeEnum
        Private sDescription As String
        Private sCategory As String
        Private sEnumValues As String

        Private oSource As Data.cDataField

        Public Created As Boolean
        Public Deleted As Boolean

        Public ReadOnly Property ImageIndex() As Integer
            Get
                If Deleted Then
                    Return 1
                Else
                    Return 0
                End If
            End Get
        End Property

        Public Property Type As Data.cDataFields.TypeEnum
            Get
                Return iType
            End Get
            Set(value As Data.cDataFields.TypeEnum)
                iType = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                sName = value
            End Set
        End Property

        Public ReadOnly Property Source As Data.cDataField
            Get
                Return oSource
            End Get
        End Property

        Public Property EnumValues As String
            Get
                Return sEnumValues
            End Get
            Set(value As String)
                sEnumValues = value
            End Set
        End Property

        Public Property Category As String
            Get
                Return sCategory
            End Get
            Set(value As String)
                sCategory = value
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

        Public Sub New(Name As String, Type As Data.cDataFields.TypeEnum)
            oSource = Nothing
            sName = Name
            iType = Type
            sDescription = ""
            sCategory = ""
            sEnumValues = ""
            Created = True
        End Sub

        Public Sub New(Source As Data.cDataField)
            oSource = Source
            sName = Source.Name
            iType = Source.Type
            sDescription = Source.Description
            sCategory = Source.Category
            Select Case iType
                Case Data.cDataFields.TypeEnum.Enum
                    Dim oEnumDataField As Data.cEnumDataField = Source
                    For Each sValue As String In oEnumDataField.Values.Values
                        If sEnumValues <> "" Then sEnumValues = sEnumValues & vbCrLf
                        sEnumValues = sEnumValues & sValue
                    Next
            End Select
        End Sub
    End Class

    Public Class cScaleRulePlaceHolder
        Private oScaleRule As Scale.cScaleRule

        Public Sub CopyFrom(ScaleRule As Scale.cScaleRule)
            Call oScaleRule.CopyFrom(ScaleRule)
        End Sub

        Public ReadOnly Property ImageIndex As Integer
            Get
                Return 0
            End Get
        End Property

        Public Function SetScale(Scale As Integer) As Boolean
            If oScaleRule.Scale <> Scale Then
                oScaleRule.Scale = Scale
                Return oScaleRule.Scale = Scale
            End If
        End Function

        Public ReadOnly Property ScaleText As String
            Get
                Return GetLocalizedString("scalerules.textpart1") & " 1:" & Strings.Format(Scale, "#,##0")
            End Get
        End Property

        Public ReadOnly Property Scale As Integer
            Get
                Return oScaleRule.Scale
            End Get
        End Property

        Public ReadOnly Property ScaleRule As Scale.cScaleRule
            Get
                Return oScaleRule
            End Get
        End Property

        Friend Sub New(ScaleRule As Scale.cScaleRule)
            oScaleRule = ScaleRule
        End Sub
    End Class

    Public Class cScaleRulescBindingList
        Inherits BindingList(Of cScaleRulePlaceHolder)
        Private oSurvey As cSurvey
        Private oScaleRules As Scale.cScaleRules

        Public ReadOnly Property Scalerules As Scale.cScaleRules
            Get
                Return oScaleRules
            End Get
        End Property

        Public Shadows Function Remove(Scale As Integer) As Boolean
            If oScaleRules.Contains(Scale) Then
                Dim oItem As cScaleRulePlaceHolder = MyBase.FirstOrDefault(Function(oScaleRule) oScaleRule.Scale = Scale)
                MyBase.Remove(oItem)
            End If
        End Function

        Public Shadows Function Add(Scale As Integer, Source As cScaleRulePlaceHolder) As cScaleRulePlaceHolder
            Dim oItem As cScaleRulePlaceHolder = New cScaleRulePlaceHolder(oScaleRules.Add(Scale))
            Call oItem.ScaleRule.CopyFrom(Source.ScaleRule)
            Call MyBase.Add(oItem)
            Return oItem
        End Function

        Public Shadows Function Add(Scale As Integer) As cScaleRulePlaceHolder
            Dim oItem As cScaleRulePlaceHolder = New cScaleRulePlaceHolder(oScaleRules.Add(Scale))
            Call MyBase.Add(oItem)
            Return oItem
        End Function

        Public Sub New(Survey As cSurvey)
            oSurvey = Survey
            oScaleRules = New Scale.cScaleRules(oSurvey)
            Call oScaleRules.CopyFrom(Survey.ScaleRules)

            For Each oScaleRule As Scale.cScaleRule In oScaleRules
                Call MyBase.Add(New cScaleRulePlaceHolder(oScaleRule))
            Next
        End Sub

        Public Function GetRule(Scale As Integer) As cScaleRulePlaceHolder
            Dim oScalerule As Scale.cScaleRule = oScaleRules.GetRule(Scale)
            Return MyBase.FirstOrDefault(Function(oitem) oitem.ScaleRule Is oScalerule)
        End Function

        Public Function ScaleExist(Scale As Integer) As Boolean
            Return oScaleRules.Contains(Scale)
        End Function

        Public Sub Save()
            oSurvey.ScaleRules.CopyFrom(oScaleRules)
        End Sub
    End Class

    Public Class cDataFieldsBindingList
        Inherits BindingList(Of cDataFieldPlaceHolder)
        Private oDataFields As Data.cDataFields

        Public Function FormatName(Name As String) As String
            Dim sName As String = Name.Trim
            sName = sName.Replace(" ", "_")
            Dim sNewName As String = ""
            For Each sChar As Char In sName
                If (sChar >= "A" And sChar <= "Z") OrElse (sChar >= "a" And sChar <= "z") OrElse (sChar >= "0" And sChar <= "9") OrElse (sChar = "_") Then
                    sNewName &= sChar
                End If
            Next
            Return sNewName
        End Function

        Public Sub Save()
            For Each oPH As cDataFieldPlaceHolder In Me
                If oPH.Deleted Then
                    If oDataFields.Contains(oPH.Source) Then
                        oDataFields.Remove(oPH.Source)
                    End If
                Else
                    If oPH.Created Then
                        Dim oDataField As Data.cDataField = oDataFields.Add(oPH.Name, oPH.Type)
                        oDataField.Description = oPH.Description
                        oDataField.Category = oPH.Category
                        Select Case oPH.Type
                            Case Data.cDataFields.TypeEnum.Enum
                                Dim oEnumDataField As Data.cEnumDataField = oDataField
                                Dim sLines() As String = Strings.Split(oPH.EnumValues, vbCrLf)
                                Dim iIndex As Integer = 0
                                For Each sLine As String In sLines
                                    Call oEnumDataField.Values.Add(iIndex, sLine)
                                    iIndex += 1
                                Next
                        End Select
                    Else
                        Dim oDataField As Data.cDataField = oPH.Source
                        If oDataField.Name <> oPH.Name Then
                            oDataField = oDataFields.Rename(oDataField.Name, oPH.Name)
                        End If
                        If oDataField.Type <> oPH.Type Then
                            oDataField = oDataFields.Retype(oDataField.Name, oPH.Type)
                        End If
                        oDataField.Description = oPH.Description
                        oDataField.Category = oPH.Category
                        Select Case oPH.Type
                            Case Data.cDataFields.TypeEnum.Enum
                                Dim oEnumDataField As Data.cEnumDataField = oDataField
                                Dim sLines() As String = Strings.Split(oPH.EnumValues, vbCrLf)
                                Dim iIndex As Integer = 0
                                Call oEnumDataField.Values.Clear()
                                For Each sLine As String In sLines
                                    Call oEnumDataField.Values.Add(iIndex, sLine)
                                    iIndex += 1
                                Next
                        End Select
                    End If
                End If
            Next
            Call oDataFields.InvalidateClass()
        End Sub

        Public Overloads Function Contains(Name As String) As Boolean
            Return Not MyBase.FirstOrDefault(Function(oitem) oitem.Name = Name) Is Nothing
        End Function

        Public Function GetFieldUniqueName() As String
            Dim oNames As List(Of String) = New List(Of String)(MyBase.Select(Function(oitem) oitem.Name).Distinct)
            Dim sBaseName As String = "field"
            Dim iIndex As Integer = 0
            Dim sName As String
            Do
                iIndex += 1
                sName = sBaseName & iIndex
            Loop While oNames.Contains(sName)
            Return sName
        End Function

        Public Shadows Function Add() As cDataFieldPlaceHolder
            Dim oItem As cDataFieldPlaceHolder = New cDataFieldPlaceHolder(GetFieldUniqueName, Data.cDataFields.TypeEnum.Text)
            Call MyBase.Add(oItem)
            Return oItem
        End Function

        Public Shadows Function Add(Name As String, Type As Data.cDataFields.TypeEnum)
            Dim oItem As cDataFieldPlaceHolder = New cDataFieldPlaceHolder(Name, Type)
            MyBase.Add(oItem)
            Return oItem
        End Function

        Public Shadows Function RemoveAt(index As Integer) As Boolean
            Dim oItem As cDataFieldPlaceHolder = MyBase.Items(index)
            Return Remove(oItem)
        End Function

        Public Shadows Function Remove(item As cDataFieldPlaceHolder) As Boolean
            If item.Source Is Nothing Then
                Call MyBase.Remove(item)
                Return True
            Else
                item.Deleted = True
                Return False
            End If
        End Function

        Public Sub New(DataFields As Data.cDataFields)
            oDataFields = DataFields

            For Each oDataField As Data.cDataField In DataFields
                Call MyBase.Add(New cDataFieldPlaceHolder(oDataField))
            Next
        End Sub
    End Class

    Public Class cLinkedSurveysBindingList
        Inherits BindingList(Of cLinkedSurvey)
        Private oLinkedSurveys As cLinkedSurveys

        Public ReadOnly Property LinkedSurveys As cLinkedSurveys
            Get
                Return oLinkedSurveys
            End Get
        End Property

        Public Sub New(LinkedSurveys As cLinkedSurveys)
            MyBase.New
            oLinkedSurveys = LinkedSurveys
            For Each oLinkedSurvey As cLinkedSurvey In oLinkedSurveys
                Call MyBase.Add(oLinkedSurvey)
            Next
        End Sub

        Public Sub Refresh()
            Call MyBase.Clear()
            For Each oLinkedSurvey As cLinkedSurvey In oLinkedSurveys
                Call MyBase.Add(oLinkedSurvey)
            Next
        End Sub
    End Class

    Public Class cAttachmentsBindingList
        Inherits BindingList(Of cAttachmentsLink)
        Private oAttachments As cAttachmentsLinks

        Public Overloads Function Add(Filename As String) As cAttachmentsLink
            Dim oAttachment As cAttachmentsLink = oAttachments.Add(Filename)
            Call MyBase.Add(oAttachment)
            Return oAttachment
        End Function

        Public Overloads Sub Remove(Attachment As cAttachmentsLink)
            MyBase.Remove(Attachment)
        End Sub

        Public Sub New(Attachments As cAttachmentsLinks)
            MyBase.New
            oAttachments = Attachments
            For Each oAttachment As cAttachmentsLink In Attachments
                Call MyBase.Add(oAttachment)
            Next
        End Sub
    End Class

    Public Class cValueItem(Of T)
        Private oValue As T

        Friend Sub New(Value As T)
            oValue = Value
        End Sub

        Public Property Value As T
            Get
                Return oValue
            End Get
            Set(value As T)
                oValue = value
            End Set
        End Property
    End Class

    Public Class cDescriptionValueItem(Of T)
        Inherits cValueItem(Of T)

        Private sDescription As String

        Friend Sub New(Description As String, Value As T)
            MyBase.New(Value)
            sDescription = Description
        End Sub

        Public ReadOnly Property Description As String
            Get
                Return sDescription
            End Get
        End Property
    End Class

    Public Class cKeyValueItem(Of K, T)
        Inherits cValueItem(Of T)

        Private oKey As K

        Friend Sub New(Key As K, Value As T)
            MyBase.New(Value)
            oKey = Key
        End Sub

        Public Property Key As K
            Get
                Return oKey
            End Get
            Set(value As K)
                oKey = value
            End Set
        End Property
    End Class

    Public Class cConnectionsBindingList
        Inherits BindingList(Of cDescriptionValueItem(Of Boolean))

        Public Overloads Sub Add(Description As String, Value As Boolean)
            Call MyBase.Add(New cDescriptionValueItem(Of Boolean)(Description, Value))
        End Sub

        Public Sub New(Connections As cSurveyPC.cSurvey.cConnections)
            MyBase.New
            For Each sStation As String In Connections
                Call MyBase.Add(New cDescriptionValueItem(Of Boolean)(sStation, Connections.Get(sStation)))
            Next
        End Sub

        Public Sub Save(Connections As cSurveyPC.cSurvey.cConnections)
            For Each oConnection As cDescriptionValueItem(Of Boolean) In Me
                Call Connections.Set(oConnection.Description, oConnection.Value)
            Next
        End Sub
    End Class

    Public Class cAliasBindingList
        Inherits BindingList(Of cValueItem(Of String))

        Public Overloads Sub Add(Value As String)
            Call MyBase.Add(New cValueItem(Of String)("" & Value))
        End Sub

        Public Sub New([Aliases] As cSurveyPC.cSurvey.cTrigPoint.cAliases)
            MyBase.New
            For Each sAlias In [Aliases]
                Call MyBase.Add(New cValueItem(Of String)(sAlias))
            Next
        End Sub

        Public Sub Save([Aliases] As cSurveyPC.cSurvey.cTrigPoint.cAliases)
            [Aliases].Clear()
            For Each oAlias As cValueItem(Of String) In Me
                If Not oAlias.Value Is Nothing AndAlso oAlias.Value <> "" Then
                    Call [Aliases].Add(oAlias.Value)
                End If
            Next
        End Sub
    End Class

    Public Class cSegmentPlaceholder
        Private iValidation As SegmentValidation
        Private oSegment As cSegment

        Private bCalculateException As Boolean
        Private sCalculateExceptionMessage As String

        Private bVisible As Boolean

        Public ReadOnly Property Visible As Boolean
            Get
                Return bVisible
            End Get
        End Property

        Friend Sub SetVisible(Visible As Boolean)
            bVisible = Visible
        End Sub

        Public ReadOnly Property CalculateException As Boolean
            Get
                Return bCalculateException
            End Get
        End Property

        Public ReadOnly Property CalculateExceptionMessage As String
            Get
                Return sCalculateExceptionMessage
            End Get
        End Property

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is cSegment Then
                Return oSegment Is obj
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Shared Widening Operator CType(ByVal SegmentPlaceholder As cSegmentPlaceholder) As cSegment
            Return SegmentPlaceholder.Segment
        End Operator
        Public Property ZSurvey As Boolean
            Get
                Return oSegment.ZSurvey
            End Get
            Set(value As Boolean)
                oSegment.ZSurvey = value
            End Set
        End Property

        Public Property Splay As Boolean
            Get
                Return oSegment.Splay
            End Get
            Set(value As Boolean)
                oSegment.Splay = value
            End Set
        End Property

        Public Property Unbindable As Boolean
            Get
                Return oSegment.Unbindable
            End Get
            Set(value As Boolean)
                oSegment.Unbindable = value
            End Set
        End Property

        Public Property Duplicate As Boolean
            Get
                Return oSegment.Duplicate
            End Get
            Set(value As Boolean)
                oSegment.Duplicate = value
            End Set
        End Property
        Public Property CutSplay As Boolean
            Get
                Return oSegment.Cut
            End Get
            Set(value As Boolean)
                oSegment.Cut = value
            End Set
        End Property

        Public Property Calibration As Boolean
            Get
                Return oSegment.Calibration
            End Get
            Set(value As Boolean)
                oSegment.Calibration = value
            End Set
        End Property

        Public Property Exclude As Boolean
            Get
                Return oSegment.Exclude
            End Get
            Set(value As Boolean)
                oSegment.Exclude = value
            End Set
        End Property

        Public Property Direction As cSurvey.DirectionEnum
            Get
                Return oSegment.Direction
            End Get
            Set(value As cSurvey.DirectionEnum)
                oSegment.Direction = value
            End Set
        End Property

        Public Property Left As Decimal
            Get
                Return oSegment.Left
            End Get
            Set(value As Decimal)
                oSegment.Left = value
            End Set
        End Property
        Public Property Right As Decimal
            Get
                Return oSegment.Right
            End Get
            Set(value As Decimal)
                oSegment.Right = value
            End Set
        End Property
        Public Property Up As Decimal
            Get
                Return oSegment.Up
            End Get
            Set(value As Decimal)
                oSegment.Up = value
            End Set
        End Property

        Public Property Down As Decimal
            Get
                Return oSegment.Down
            End Get
            Set(value As Decimal)
                oSegment.Down = value
            End Set
        End Property

        Public Property Inclination As Decimal
            Get
                Return oSegment.Inclination
            End Get
            Set(value As Decimal)
                oSegment.Inclination = value
            End Set
        End Property

        Public Property Bearing As Decimal
            Get
                Return oSegment.Bearing
            End Get
            Set(value As Decimal)
                oSegment.Bearing = value
            End Set
        End Property

        Public Property Distance As Decimal
            Get
                Return oSegment.Distance
            End Get
            Set(value As Decimal)
                oSegment.Distance = value
            End Set
        End Property

        Public Property [To] As String
            Get
                Return oSegment.To
            End Get
            Set(value As String)
                oSegment.To = value
            End Set
        End Property

        Public Property From As String
            Get
                Return oSegment.From
            End Get
            Set(value As String)
                oSegment.From = value
            End Set
        End Property

        Friend Sub New(Segment As cSegment)
            oSegment = Segment
            iValidation = SegmentValidation.None
            bVisible = True

            sCalculateExceptionMessage = ""
        End Sub

        Public ReadOnly Property Segment As cSegment
            Get
                Return oSegment
            End Get
        End Property

        <Flags> Public Enum SegmentValidation
            None = 0
            Invalid = 1
            SessionMissing = 2
            CaveMissing = 4
            Equate = 8
            SelfDefined = 16
        End Enum

        Friend Sub ResetVisible()
            bVisible = True
        End Sub

        Friend Sub ResetCalculateException()
            If bCalculateException Then
                bCalculateException = False
                sCalculateExceptionMessage = ""
            End If
        End Sub

        Friend Sub SetCalculateException(CalculateExceptionMessage As String)
            bCalculateException = True
            sCalculateExceptionMessage = CalculateExceptionMessage
        End Sub

        Friend Sub SetValidation(Validation As SegmentValidation)
            iValidation = Validation
        End Sub

        Public Sub ResetValidation()
            iValidation = SegmentValidation.None
        End Sub

        Public Sub AppendValidation(Validation As SegmentValidation)
            iValidation = iValidation Or Validation
        End Sub

        Public ReadOnly Property Validation As SegmentValidation
            Get
                Return iValidation
            End Get
        End Property
    End Class

    Public Class cISurfaceOptionsItemBindingList
        Inherits BindingList(Of cISurfaceOptionsItem)

        Public Sub New(SurfaceOptions As cSurface3DOptions)
            MyBase.New
            For Each oItem As cISurfaceOptionsItem In SurfaceOptions
                MyBase.Add(oItem)
            Next
        End Sub

        Public Sub New(SurfaceOptions As cSurfaceOptions)
            MyBase.New
            For Each oItem As cISurfaceOptionsItem In SurfaceOptions
                MyBase.Add(oItem)
            Next
        End Sub
    End Class

    Public Class cSegmentsBindingList
        Inherits BindingList(Of cSegmentPlaceholder)

        Private oIndex As Dictionary(Of cSegment, cSegmentPlaceholder)
        Private WithEvents oSegments As cSegments

        Public Sub New(Segments As cSegments)
            MyBase.New
            oIndex = New Dictionary(Of cSegment, cSegmentPlaceholder)
            oSegments = Segments
            For Each oSegment As cSegment In oSegments
                Dim oPlaceholder As cSegmentPlaceholder = New cSegmentPlaceholder(oSegment)
                Call MyBase.Add(oPlaceholder)
                Call oIndex.Add(oSegment, oPlaceholder)
                Call Validate(oPlaceholder)
            Next
        End Sub

        Private Sub oSegments_OnClear(Sender As cSegments) Handles oSegments.OnClear
            Call MyBase.Clear()
            Call oIndex.Clear()
        End Sub

        Private Sub oSegments_OnSegmentAppend(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentAppend
            Dim oPlaceholder As cSegmentPlaceholder = New cSegmentPlaceholder(e.Segment)
            Call MyBase.Add(oPlaceholder)
            Call oIndex.Add(e.Segment, oPlaceholder)
            Call oPlaceholder.SetVisible(True)
            Call Validate(oPlaceholder)
        End Sub

        Private Sub oSegments_OnSegmentInsert(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentInsert
            Dim oPlaceholder As cSegmentPlaceholder = New cSegmentPlaceholder(e.Segment)
            Call MyBase.Insert(e.Index, oPlaceholder)
            Call oIndex.Add(e.Segment, oPlaceholder)
            Call oPlaceholder.SetVisible(True)
            Call Validate(oPlaceholder)
        End Sub

        Public Function FindSegment(Segment As cSegment) As cSegmentPlaceholder
            Return oIndex(Segment)
            'Return MyBase.FirstOrDefault(Function(oItem) oItem.Segment Is Segment)
        End Function

        Private Sub oSegments_OnSegmentRemove(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentRemove
            Dim oPlaceholder As cSegmentPlaceholder = FindSegment(e.Segment)
            If oPlaceholder IsNot Nothing Then
                Call MyBase.Remove(oPlaceholder)
                Call oIndex.Remove(oPlaceholder.Segment)
            End If
        End Sub

        Private Sub oSegments_OnSegmentRemoveRange(Sender As cSegments, e As cSegments.OnSegmentsEventArgs) Handles oSegments.OnSegmentRemoveRange
            Dim oPlaceholders As List(Of cSegmentPlaceholder) = New List(Of cSegmentPlaceholder)
            For Each iIndex As Integer In e.Indexes
                oPlaceholders.Add(MyBase.Item(iIndex))
            Next
            For Each oPlaceholder As cSegmentPlaceholder In oPlaceholders
                Call MyBase.Remove(oPlaceholder)
                Call oIndex.Remove(oPlaceholder.Segment)
            Next
        End Sub

        Private Sub oSegments_OnSegmentMove(Sender As cSegments, e As cSegments.OnSegmentMoveEventArgs) Handles oSegments.OnSegmentMove
            Dim oSegmentPlaceholder As cSegmentPlaceholder = MyBase.Item(e.OldIndex)
            Call MyBase.RemoveAt(e.OldIndex)
            Call MyBase.Insert(e.Index, oSegmentPlaceholder)
        End Sub

        Private Sub oSegments_OnSegmentChange(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentChange
            Dim oPlaceholder As cSegmentPlaceholder = FindSegment(e.Segment)
            Call Validate(oPlaceholder)
        End Sub

        Public Sub Validate(Segment As cSegmentPlaceholder)
            If Segment IsNot Nothing Then
                Call Segment.ResetValidation()
                Dim oSegment As cSegment = Segment.Segment
                If oSegment.IsValid Then
                    Call Segment.AppendValidation(If(oSegment.IsEquate, cSegmentPlaceholder.SegmentValidation.Equate, cSegmentPlaceholder.SegmentValidation.None))
                    Call Segment.AppendValidation(If(oSegment.IsSelfDefined, cSegmentPlaceholder.SegmentValidation.SelfDefined, cSegmentPlaceholder.SegmentValidation.None))
                    Call Segment.AppendValidation(If(oSegment.Session = "" AndAlso Not oSegment.Virtual AndAlso Not oSegment.IsEquate, cSegmentPlaceholder.SegmentValidation.SessionMissing, cSegmentPlaceholder.SegmentValidation.None))
                    Call Segment.AppendValidation(If(oSegment.Cave = "", cSegmentPlaceholder.SegmentValidation.CaveMissing, cSegmentPlaceholder.SegmentValidation.None))
                Else
                    Call Segment.AppendValidation(cSegmentPlaceholder.SegmentValidation.Invalid)
                End If
            End If
        End Sub

        Public Sub ResetVisible()
            Threading.Tasks.Parallel.ForEach(Of cSegmentPlaceholder)(Me, Sub(oPlaceholder)
                                                                             Call oPlaceholder.ResetVisible()
                                                                         End Sub)
        End Sub

        Public Sub SetVisible(Segment As cSegment, Visible As Boolean)
            If oIndex.ContainsKey(Segment) Then
                Call oIndex(Segment).SetVisible(Visible)
            End If
        End Sub

        Public Sub ResetCalculateException()
            Threading.Tasks.Parallel.ForEach(Of cSegmentPlaceholder)(Me, Sub(oPlaceholder)
                                                                             Call oPlaceholder.ResetCalculateException()
                                                                         End Sub)
        End Sub

        Public Sub SetCalculateException(Segment As cSegment, Message As String)
            If oIndex.ContainsKey(Segment) Then
                Call oIndex(Segment).SetCalculateException(Message)
            End If
        End Sub

        Public Sub SetCalculateException(Segments As List(Of cSegment), Message As String)
            Threading.Tasks.Parallel.ForEach(Of cSegment)(Segments, Sub(oSegment)
                                                                        SetCalculateException(oSegment, Message)
                                                                    End Sub)
            'Call Segments.ForEach(Sub(oSegment) SetCalculateException(oSegment, Message))
        End Sub

        Private Sub oSegments_OnSegmentChangeRange(Sender As cSegments, e As cSegments.OnSegmentsEventArgs) Handles oSegments.OnSegmentChangeRange
            For Each oSegment As cSegment In e.Segments
                Dim oPlaceholder As cSegmentPlaceholder = FindSegment(oSegment)
                Call Validate(oPlaceholder)
            Next
        End Sub
    End Class

    Public Class cRecentsHelper
        Public Shared Function Load(RegistryKey As String, Button As DevExpress.XtraBars.BarButtonItem) As List(Of String)
            Dim oRecents As List(Of String) = New List(Of String)
            Dim oFolder As cEnvironmentSettingsFolder = My.Application.Settings.GetFolder(RegistryKey)
            For Each skey As String In oFolder.GetKeys
                Call oRecents.Add(oFolder.GetSetting(skey).ToString.ToLower)
            Next
            Call ButtonUpdate(oRecents, Button)
            Return oRecents
        End Function

        Public Shared Sub ButtonUpdate(Recents As List(Of String), Button As DevExpress.XtraBars.BarButtonItem)
            Button.ButtonStyle = If(Recents.Count > 0, DevExpress.XtraBars.BarButtonStyle.DropDown, DevExpress.XtraBars.BarButtonStyle.Default)
        End Sub

        Public Shared Sub RemoveFrom(Filename As String, RegistryKey As String, Recents As List(Of String), Button As DevExpress.XtraBars.BarButtonItem)
            Dim sFilename As String = Filename.ToLower
            Do While Recents.Contains(sFilename)
                Call Recents.Remove(sFilename)
            Loop
            Call pSave(Recents, RegistryKey)
            Call ButtonUpdate(Recents, Button)
        End Sub

        Private Shared Sub pSave(Recents As List(Of String), RegistryKey As String)
            Dim oFolder As cEnvironmentSettingsFolder = My.Application.Settings.GetFolder(RegistryKey)
            Dim iValueIndex As Integer = 0
            For Each sRecent As String In Recents
                oFolder.SetSetting(iValueIndex, sRecent)
                iValueIndex += 1
            Next
        End Sub

        Public Shared Sub AppendTo(Filename As String, RegistryKey As String, Recents As List(Of String), Button As DevExpress.XtraBars.BarButtonItem)
            Dim sFilename As String = Filename.ToLower
            Do While Recents.Contains(sFilename)
                Call Recents.Remove(sFilename)
            Loop
            Call Recents.Insert(0, sFilename)
            Do While Recents.Count > 10
                Call Recents.RemoveAt(10)
            Loop
            Call pSave(Recents, RegistryKey)
            Call ButtonUpdate(Recents, Button)
        End Sub
    End Class


    Public Class cGradePlaceHolder
        Inherits cEditPlaceHolder(Of cGrade)
        Private sType As String = "grade"

        Public Overridable ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property

        Private sID As String

        Public ReadOnly Property ID As String
            Get
                Return sID
            End Get
        End Property

        Private sDescription As String

        Public Property Description As String
            Get
                Return sDescription
            End Get
            Set(value As String)
                sDescription = value
            End Set
        End Property

        Public DistanceEnabled As Boolean
        Public BearingEnabled As Boolean
        Public InclinationEnabled As Boolean
        Public DepthEnabled As Boolean
        Public XEnabled As Boolean
        Public YEnabled As Boolean
        Public ZEnabled As Boolean

        Public Distance As Single
        Public Bearing As Single
        Public Inclination As Single
        Public Depth As Single
        Public X As Single
        Public Y As Single
        Public Z As Single

        Public BearingType As cSegment.BearingTypeEnum
        Public DistanceType As cSegment.DistanceTypeEnum
        Public InclinationType As cSegment.InclinationTypeEnum
        Public DepthType As cSegment.DistanceTypeEnum
        Public XType As cSegment.DistanceTypeEnum
        Public YType As cSegment.DistanceTypeEnum
        Public ZType As cSegment.DistanceTypeEnum

        Public Sub New()
            sID = Guid.NewGuid.ToString
            sDescription = ""
        End Sub
        Public Sub New(ID As String)
            sID = ID
            sDescription = ""
        End Sub

        Public ReadOnly Property ImageIndex As Integer
            Get
                If MyBase.Deleted Then
                    Return 7
                Else
                    Return 10
                End If
            End Get
        End Property
    End Class

    Public Class cGradeEditBindingList
        Inherits BindingList(Of cGradePlaceHolder)

        Private oSurvey As cSurvey

        Public Overloads Function Remove(Item As cGradePlaceHolder) As Boolean
            If oSurvey.Grades.Contains(Item.Source) Then
                Item.Deleted = True
                Return False
            Else
                Call MyBase.Remove(Item)
                Return True
            End If
        End Function

        Public Overloads ReadOnly Property Item(ID As String) As cGradePlaceHolder
            Get
                Return MyBase.FirstOrDefault(Function(oItem) oItem.ID = ID)
            End Get
        End Property

        Public Overloads Function IndexOf(ID As String) As Integer
            Dim oFoundedItem As cGradePlaceHolder = MyBase.FirstOrDefault(Function(oItem) oItem.ID = ID)
            If oFoundedItem Is Nothing Then
                Return -1
            Else
                Return MyBase.IndexOf(oFoundedItem)
            End If
        End Function

        Public Sub Save()
            With oSurvey.Grades
                For Each oCI As cGradePlaceHolder In MyBase.Items
                    If oCI.Deleted And Not oCI.Created Then
                        Call .Remove(oCI.ID)
                    ElseIf oCI.Created Then
                        Dim oGrade As cGrade = .Add(oCI.ID, oCI.Description)

                        oGrade.DistanceEnabled = oCI.DistanceEnabled
                        oGrade.DistanceType = oCI.DistanceType
                        oGrade.Distance = oCI.Distance

                        oGrade.BearingEnabled = oCI.BearingEnabled
                        oGrade.BearingType = oCI.BearingType
                        oGrade.Bearing = oCI.Bearing

                        oGrade.InclinationEnabled = oCI.InclinationEnabled
                        oGrade.InclinationType = oCI.InclinationType
                        oGrade.Inclination = oCI.Inclination

                        oGrade.DepthEnabled = oCI.DepthEnabled
                        oGrade.DepthType = oCI.DepthType
                        oGrade.Depth = oCI.Depth

                        oGrade.XEnabled = oCI.XEnabled
                        oGrade.XType = oCI.XType
                        oGrade.X = oCI.X

                        oGrade.YEnabled = oCI.YEnabled
                        oGrade.YType = oCI.YType
                        oGrade.Y = oCI.Y

                        oGrade.ZEnabled = oCI.ZEnabled
                        oGrade.ZType = oCI.ZType
                        oGrade.Z = oCI.Z
                    Else
                        Dim oGrade As cGrade = oCI.Source
                        oGrade.Description = oCI.Description

                        oGrade.DistanceEnabled = oCI.DistanceEnabled
                        oGrade.DistanceType = oCI.DistanceType
                        oGrade.Distance = oCI.Distance

                        oGrade.BearingEnabled = oCI.BearingEnabled
                        oGrade.BearingType = oCI.BearingType
                        oGrade.Bearing = oCI.Bearing

                        oGrade.InclinationEnabled = oCI.InclinationEnabled
                        oGrade.InclinationType = oCI.InclinationType
                        oGrade.Inclination = oCI.Inclination

                        oGrade.DepthEnabled = oCI.DepthEnabled
                        oGrade.DepthType = oCI.DepthType
                        oGrade.Depth = oCI.Depth

                        oGrade.XEnabled = oCI.XEnabled
                        oGrade.XType = oCI.XType
                        oGrade.X = oCI.X

                        oGrade.YEnabled = oCI.YEnabled
                        oGrade.YType = oCI.YType
                        oGrade.Y = oCI.Y

                        oGrade.ZEnabled = oCI.ZEnabled
                        oGrade.ZType = oCI.ZType
                        oGrade.Z = oCI.Z
                    End If
                Next
            End With
        End Sub

        Public Overloads Function Add() As cGradePlaceHolder
            Dim oCI As cGradePlaceHolder = New cGradePlaceHolder
            oCI.Description = ""

            oCI.Created = True

            Call MyBase.Add(oCI)
            Return oCI
        End Function

        Public Sub New(Survey As cSurvey)
            MyBase.New

            oSurvey = Survey

            For Each oGrade As cGrade In oSurvey.Grades
                Dim oCI As cGradePlaceHolder = New cGradePlaceHolder(oGrade.ID)
                oCI.Description = oGrade.Description

                oCI.DistanceEnabled = oGrade.DistanceEnabled
                oCI.Distance = oGrade.DistanceType
                oCI.Distance = oGrade.Distance

                oCI.BearingEnabled = oGrade.BearingEnabled
                oCI.Bearing = oGrade.BearingType
                oCI.Bearing = oGrade.Bearing

                oCI.InclinationEnabled = oGrade.InclinationEnabled
                oCI.Inclination = oGrade.InclinationType
                oCI.Inclination = oGrade.Inclination

                oCI.DepthEnabled = oGrade.DepthEnabled
                oCI.DepthType = oGrade.DepthType
                oCI.Depth = oGrade.Depth

                oCI.XEnabled = oGrade.XEnabled
                oCI.XType = oGrade.XType
                oCI.X = oGrade.X

                oCI.YEnabled = oGrade.YEnabled
                oCI.YType = oGrade.YType
                oCI.Y = oGrade.Y

                oCI.ZEnabled = oGrade.ZEnabled
                oCI.ZType = oGrade.ZType
                oCI.Z = oGrade.Z

                oCI.Source = oGrade

                Call MyBase.Add(oCI)
            Next
        End Sub
    End Class

    Friend Class cTemplatesBindingList
        Inherits BindingList(Of cTemplateEntry)

        Private sTemplatesPath As String

        Public ReadOnly Property TemplatePath As String
            Get
                Return sTemplatesPath
            End Get
        End Property

        Public Function GetDefaultTemplate(Template As cTemplateEntry) As cTemplateEntry
            If Template Is Nothing Then
                Return Me.GetDefaultTemplate
            Else
                Return Template
            End If
        End Function

        Public Function GetDefaultTemplate() As cTemplateEntry
            Return MyBase.FirstOrDefault(Function(oItem) oItem.Default)
        End Function

        Private Function pCheckFolder() As Boolean
            Try
                If My.Computer.FileSystem.DirectoryExists(sTemplatesPath) Then
                    Return True
                Else
                    Call My.Computer.FileSystem.CreateDirectory(sTemplatesPath)
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        Friend Sub SetDefault(Template As cTemplateEntry, Value As Boolean)
            If Value Then
                Dim oTemplate As cTemplateEntry = MyBase.FirstOrDefault(Function(oitem) oitem.Default AndAlso Not oitem Is Template)
                If Not oTemplate Is Nothing Then Call SetDefault(oTemplate, False)

                Dim sOldFilename As String = Template.File.FullName
                Dim sNewFilename As String = IO.Path.GetFileNameWithoutExtension(Template.File.Name) & ".default" & IO.Path.GetExtension(Template.File.Name)
                Dim sNewFullFilename As String = IO.Path.Combine(Template.File.DirectoryName, sNewFilename)
                My.Computer.FileSystem.RenameFile(sOldFilename, sNewFilename)

                Call Template.Rebind(sNewFullFilename)

                'Dim oNewTemplate As cTemplateEntry = New cTemplateEntry(Me, New IO.FileInfo(sNewFullFilename))
                'Dim iIndex As Integer = MyBase.IndexOf(Template)
                'Call MyBase.Remove(Template)
                'Call MyBase.Insert(iIndex, oNewTemplate)
            Else
                Dim sOldFilename As String = Template.File.FullName
                Dim sNewFilename As String = IO.Path.GetFileNameWithoutExtension(Template.File.Name).Replace(".default", "") & IO.Path.GetExtension(Template.File.Name)
                Dim sNewFullFilename As String = IO.Path.Combine(Template.File.DirectoryName, sNewFilename)
                My.Computer.FileSystem.RenameFile(sOldFilename, sNewFilename)

                Call Template.Rebind(sNewFullFilename)

                'Dim oNewTemplate As cTemplateEntry = New cTemplateEntry(Me, New IO.FileInfo(sNewFullFilename))
                'Dim iIndex As Integer = MyBase.IndexOf(Template)
                'Call MyBase.Remove(Template)
                'Call MyBase.Insert(iIndex, oNewTemplate)
            End If
        End Sub

        Public Sub New(TemplatesPath As String)
            MyBase.New
            sTemplatesPath = TemplatesPath
            Call Refresh()
        End Sub

        Public Sub Refresh()
            If pCheckFolder() Then
                MyBase.Clear()
                Dim oIndex As HashSet(Of String) = New HashSet(Of String)(System.StringComparer.OrdinalIgnoreCase)
                For Each oFile As FileInfo In My.Computer.FileSystem.GetDirectoryInfo(sTemplatesPath).GetFiles("*.csz")
                    If Not oIndex.Contains(oFile.Name) Then
                        Dim oTemplate As cTemplateEntry = New cTemplateEntry(Me, oFile)
                        Call MyBase.Add(oTemplate)
                        Call oIndex.Add(oFile.Name)
                    End If
                Next
                For Each oFile As FileInfo In My.Computer.FileSystem.GetDirectoryInfo(sTemplatesPath).GetFiles("*.csx")
                    If Not oIndex.Contains(oFile.Name) Then
                        Dim oTemplate As cTemplateEntry = New cTemplateEntry(Me, oFile)
                        Call MyBase.Add(oTemplate)
                        Call oIndex.Add(oFile.Name)
                    End If
                Next
            End If
        End Sub
    End Class

    Friend Class cTemplateEntry
        Private oParent As cTemplatesBindingList
        Private oFile As FileInfo
        Private sName As String
        Private bDefault As Boolean

        Public Property [Default] As Boolean
            Get
                Return bDefault
            End Get
            Set(value As Boolean)
                Call oParent.SetDefault(Me, value)
            End Set
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property File As FileInfo
            Get
                Return oFile
            End Get
        End Property

        Friend Sub Rebind(Filename As String)
            Call Rebind(New FileInfo(Filename))
        End Sub

        Friend Sub Rebind(File As FileInfo)
            oFile = File
            sName = IO.Path.GetFileNameWithoutExtension(File.Name)
            If sName.Contains(".default") Then
                bDefault = True
                sName = sName.Replace(".default", "")
            Else
                bDefault = False
            End If
        End Sub

        Friend Sub New(Parent As cTemplatesBindingList, Filename As String)
            oParent = Parent
            Call Rebind(Filename)
        End Sub

        Friend Sub New(Parent As cTemplatesBindingList, File As FileInfo)
            oParent = Parent
            Call Rebind(File)
        End Sub
    End Class

    Public Class cLinkedSurveyRelinkerPlaceholder
        Private oLinkedSurvey As cLinkedSurvey
        Private bSelected As Boolean

        Friend Sub New(LinkedSurvey As cLinkedSurvey, Selected As Boolean)
            oLinkedSurvey = LinkedSurvey
            bSelected = Selected
        End Sub

        Public ReadOnly Property LinkedSurvey As cLinkedSurvey
            Get
                Return oLinkedSurvey
            End Get
        End Property
        Public Property Selected As Boolean
            Get
                Return bSelected
            End Get
            Set(value As Boolean)
                bSelected = value
            End Set
        End Property
    End Class
    Public Class cLinkedSurveyRelinker
        Inherits BindingList(Of cLinkedSurveyRelinkerPlaceholder)

        Public Sub [Select](Items As List(Of cLinkedSurvey))
            Call DeselectAll()
            For Each oSelectItem As cLinkedSurvey In Items
                Dim oPlaceholder As cLinkedSurveyRelinkerPlaceholder = MyBase.FirstOrDefault(Function(oitem) oitem.LinkedSurvey Is oSelectItem)
                If oPlaceholder IsNot Nothing Then oPlaceholder.Selected = True
            Next
        End Sub

        Public Sub SelectAll()
            For Each oItem As cLinkedSurveyRelinkerPlaceholder In Me
                oItem.Selected = True
            Next
        End Sub

        Public Sub DeselectAll()
            For Each oItem As cLinkedSurveyRelinkerPlaceholder In Me
                oItem.Selected = False
            Next
        End Sub
        Public Function GetSelected() As List(Of cLinkedSurvey)
            Return MyBase.Where(Function(oitem) oitem.Selected).Select(Function(oitem) oitem.LinkedSurvey).ToList
        End Function
        'Default Public ReadOnly Property Item(Index As Integer) As cLinkedSurvey
        '    Get
        '        Return oItems(Index).LinkedSurvey
        '    End Get
        'End Property

        'Public ReadOnly Property Count As Integer
        '    Get
        '        Return oItems.Count
        '    End Get
        'End Property

        Public Sub New(Items As List(Of cLinkedSurvey))
            MyBase.New
            For Each oLinkedSurvey As cLinkedSurvey In Items
                Call MyBase.Add(New cLinkedSurveyRelinkerPlaceholder(oLinkedSurvey, False))
            Next
        End Sub

        Public Function [Get]() As List(Of cLinkedSurvey)
            Return MyBase.Select(Function(oitem) oitem.LinkedSurvey).ToList
        End Function
    End Class

    Public Class cDashPatternBindingList
        Inherits BindingList(Of cDashPatternBlock)

        Public Function GetValues() As Single()
            Return MyBase.Select(Function(oitem) oitem.Value).ToArray
        End Function

        Public Shadows Function Add() As cDashPatternBlock
            Dim oItem As cDashPatternBlock = New cDashPatternBlock
            Call MyBase.Add(oItem)
            Return oItem
        End Function

        Public Sub New(Values As Single())
            MyBase.New
            If Values IsNot Nothing Then
                For Each sValue As Single In Values
                    MyBase.Add(New cDashPatternBlock(sValue))
                Next
            End If
        End Sub

        Public Shared Function ValuesToString(Values As Single()) As String
            Return String.Join(" ", Values.Select(Function(sValue As Single) modNumbers.NumberToString(sValue)).ToArray)
        End Function

        Public Shared Function StringToValues(Value As String) As Single()
            If Value Is Nothing OrElse Value = "" Then
                Return New Single() {}
            Else
                Return Value.Split({" "c}, StringSplitOptions.RemoveEmptyEntries).Select(Function(sValue) modNumbers.StringToSingle(sValue)).ToArray
            End If
        End Function
    End Class

    Public Class cDashPatternBlock
        Private sValue As Single

        Public Sub New()
            sValue = 1.0F
        End Sub

        Public Sub New(Value As Single)
            sValue = Value
        End Sub

        Public Property Value As Single
            Get
                Return sValue
            End Get
            Set(value As Single)
                If sValue <> value AndAlso value > 0F Then
                    sValue = value
                End If
            End Set
        End Property

    End Class

    Public Class cNameAndValue
        Private sName As String
        Private oValue As Object
        Private oDefaultValue As Object

        Public ReadOnly Property DefaultValue As Object
            Get
                Return oDefaultValue
            End Get
        End Property

        Public Property Value As Object
            Get
                Return oValue
            End Get
            Set(value As Object)
                oValue = value
            End Set
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Sub Reset()
            oValue = oDefaultValue
        End Sub

        Public Sub New(Name As String, Value As Object, DefaultValue As Object)
            sName = Name
            oValue = Value
            oDefaultValue = DefaultValue
        End Sub

        Public Sub New(Name As String, Value As Object)
            sName = Name
            oValue = Value
        End Sub

        Public Sub New(Name As String)
            sName = Name
        End Sub
    End Class

    Public Class cTherionINISettings
        Inherits BindingList(Of cKeyValueItem(Of String, String))

        Private sTherionINIFilename As String

        Public Sub New(Settings As String)
            MyBase.New
            If Settings.Trim <> "" Then
                For Each sItem As String In Settings.Trim.Split({"|"c})
                    Dim sItemData As String() = sItem.Split({"="c})
                    Dim oItem As cKeyValueItem(Of String, String) = New cKeyValueItem(Of String, String)(sItemData(0), sItemData(1))
                    Call MyBase.Add(oItem)
                Next
            End If
            sTherionINIFilename = IO.Path.Combine(modMain.GetUserApplicationPath, "therion.ini")
            Call Invalidate()
        End Sub

        ''' <summary>
        ''' Rewrite therion.ini in csurvey application path
        ''' </summary>
        Public Sub Invalidate()
            Dim bFlagLoopClosure As Boolean
            Dim fi As FileInfo = New FileInfo(sTherionINIFilename)
            Using st As StreamWriter = fi.CreateText
                Call st.WriteLine("#therion.ini for cSurvey")
                Call st.WriteLine("#use settings inside cSurvey to change this file, do not change it directly")
                For Each oItem As cKeyValueItem(Of String, String) In MyBase.Items
                    Dim sKey As String = oItem.Key.Trim
                    Dim sValue As String = oItem.Value.Trim
                    If sKey <> "" AndAlso sValue <> "" Then
                        Call st.Write(sKey)
                        Call st.Write(" ")
                        Call st.WriteLine(sValue)
                        If Not bFlagLoopClosure AndAlso sKey = "loop-closure" Then bFlagLoopClosure = True
                    End If
                Next
                If Not bFlagLoopClosure Then
                    Call st.WriteLine("loop-closure therion")
                End If
                Call st.Close()
            End Using
        End Sub

        Public Overrides Function ToString() As String
            Return String.Join("|", MyBase.Items.Where(Function(oitem) oitem.Key.Trim <> "" AndAlso oitem.Value.Trim <> "").Select(Function(oItem) oItem.Key.Trim & "=" & oItem.Value.Trim))
        End Function

        Public Overloads Function Add() As cKeyValueItem(Of String, String)
            Dim oItem As cKeyValueItem(Of String, String) = New cKeyValueItem(Of String, String)("", "")
            Call MyBase.Add(oItem)
            Return oItem
        End Function

        Public Overloads Function Add(Key As String, Value As String) As cKeyValueItem(Of String, String)
            Dim oItem As cKeyValueItem(Of String, String) = New cKeyValueItem(Of String, String)(Key, Value)
            Call MyBase.Add(oItem)
            Return oItem
        End Function
    End Class

    Public MustInherit Class cHistoryItemBase
        Private sName As String
        Private sOrigin As String
        Private iSize As Integer
        Private dDateStamp As DateTime
        Private sUsername As String

        Public MustOverride ReadOnly Property ID As Object
        Public MustOverride ReadOnly Property ImageIndex As Integer
        Public MustOverride ReadOnly Property Group As String
        Public ReadOnly Property Size As Integer
            Get
                Return iSize
            End Get
        End Property
        Public ReadOnly Property DateStamp As DateTime
            Get
                Return dDateStamp
            End Get
        End Property
        Public ReadOnly Property Origin As String
            Get
                Return sOrigin
            End Get
        End Property

        Public ReadOnly Property Username As String
            Get
                Return sUsername
            End Get
        End Property
        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Sub New(Name As String, Origin As String, Size As Integer, DateStamp As DateTime, Username As String)
            sName = Name
            sOrigin = Origin
            iSize = Size
            dDateStamp = DateStamp
            sUsername = Username
        End Sub
    End Class

    Public Class cHistoryItemLocal
        Inherits cHistoryItemBase

        Friend Sub New(ID As String, Name As String, Origin As String, Size As Integer, DateStamp As DateTime, Username As String)
            MyBase.New(Name, Origin, Size, DateStamp, Username)
            sID = ID
        End Sub

        Public Overrides ReadOnly Property ImageIndex As Integer
            Get
                Return 0
            End Get
        End Property

        Public Overrides ReadOnly Property Group As String
            Get
                Return "local"
            End Get
        End Property

        Private sID As String

        Public Overrides ReadOnly Property ID As Object
            Get
                Return sID
            End Get
        End Property
        Public Shared Function Create(File As IO.FileInfo) As cHistoryItemLocal
            Dim sName As String
            Dim sOrigin As String
            Dim dDateStamp As DateTime
            Dim sUsername As String
            Dim sID As String = File.FullName
            Dim oDetailsFile As IO.FileInfo = My.Computer.FileSystem.GetFileInfo(IO.Path.Combine(File.DirectoryName, IO.Path.GetFileNameWithoutExtension(File.Name) & ".xml"))
            If oDetailsFile.Exists Then
                Dim oXML As XmlDocument = New XmlDocument
                oXML.Load(oDetailsFile.FullName)
                With oXML.Item("csurvey").Item("historydetails").Item("item")
                    sName = .GetAttribute("name")
                    sOrigin = .GetAttribute("origin")
                    dDateStamp = .GetAttribute("datestamp")
                    sUsername = .GetAttribute("username")
                End With
            Else
                sName = File.Name
                sOrigin = "N/D"
                dDateStamp = File.LastWriteTime
                sUsername = "N/D"
            End If
            Dim oItem As cHistoryItemLocal = New cHistoryItemLocal(sID, sName, sOrigin, File.Length, dDateStamp, sUsername)
            Return oItem
        End Function
    End Class

    Public Class cHistoryItemWeb
        Inherits cHistoryItemBase

        Friend Sub New(ID As Integer, Name As String, Origin As String, Size As Integer, DateStamp As DateTime, Username As String)
            MyBase.New(Name, Origin, Size, DateStamp, Username)
            iID = ID
        End Sub

        Public Overrides ReadOnly Property ImageIndex As Integer
            Get
                Return 1
            End Get
        End Property
        Public Overrides ReadOnly Property Group As String
            Get
                Return "web"
            End Get
        End Property

        Private iID As Integer

        Public Overrides ReadOnly Property ID As Object
            Get
                Return iID
            End Get
        End Property
        Public Shared Function Create(WebItem As Net.cNetHistorySet) As cHistoryItemWeb
            Dim iID As Integer = WebItem.ID
            Dim sName As String = WebItem.Name
            Dim sOrigin As String = WebItem.Origin
            Dim iSize As Integer = WebItem.Size
            Dim dDateStamp As DateTime = WebItem.DateStamp
            Dim sUsername As String = WebItem.Username
            Dim oItem As cHistoryItemWeb = New cHistoryItemWeb(iID, sName, sOrigin, iSize, dDateStamp, sUsername)
            Return oItem
        End Function
    End Class

    Public Class cHistoryItems
        Inherits BindingList(Of cHistoryItemBase)
    End Class

    Public Class cLogItems
        Inherits BindingList(Of cLogItem)
    End Class

    Public Class cLogItem
        Private sType As String
        Private sMessage As String
        Private dDateStamp As DateTime

        Public ReadOnly Property DateStamp As DateTime
            Get
                Return dDateStamp
            End Get
        End Property

        Public ReadOnly Property Message As String
            Get
                Return sMessage
            End Get
        End Property

        Public ReadOnly Property Type As String
            Get
                Return sType
            End Get
        End Property

        Public Sub New(Type As String, Message As String)
            sType = Type
            sMessage = Message
            dDateStamp = Now
        End Sub
    End Class

    Public Class cStateFlagStack
        Private iCount As Integer
        Private bValue As Boolean

        Public Shared Operator Not(ByVal p As cStateFlagStack) As Boolean
            Return Not p.Value
        End Operator

        Public Shared Widening Operator CType(ByVal p As cStateFlagStack) As Boolean
            Return p.Value
        End Operator

        Public Sub Push()
            iCount += 1
            If iCount > 0 Then
                bValue = True
            End If
        End Sub

        Public Sub Pop()
            If iCount > 0 Then
                iCount -= 1
            End If
            If iCount = 0 AndAlso bValue Then
                bValue = False
            End If
        End Sub

        Public Sub Reset()
            iCount = 0
            bValue = False
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return iCount
            End Get
        End Property

        Public ReadOnly Property Value As Boolean
            Get
                Return bValue
            End Get
        End Property
    End Class
End Namespace
