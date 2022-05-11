Imports System.Xml
Imports cSurveyPC.cSurvey.Net
Imports System.Net
Imports System.IO
Imports cSurveyPC.cSurvey.CaveRegister

Public Class cCaveRegisterForm
    Private iCharWidth As Integer = 10
    Private iLabelColumnWidth As Integer = 110

    Private oSurvey As cSurvey.cSurvey

    Private Class cEnumComboItem
        Private sValue As String
        Private sDescription As String

        Public ReadOnly Property Value As String
            Get
                Return sValue
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return sDescription
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return sDescription
        End Function

        Public Sub New(Value As String, Description As String)
            sValue = Value
            If Value <> "" Then
                sDescription = Value & " - " & Description
            Else
                sDescription = Description
            End If
        End Sub
    End Class

    Private oEnumsForCombos As Dictionary(Of String, List(Of cEnumComboItem))

    Private oURI As Uri

    Private oSetting As cCaveRegisterSetting
    Private oSourceRegister As cCaveRegisterData
    Private oRegister As cCaveRegisterData

    Public ReadOnly Property Setting As cCaveRegisterSetting
        Get
            Return oSetting
        End Get
    End Property

    Public ReadOnly Property SourceData As cCaveRegisterData
        Get
            Return oSourceRegister
        End Get
    End Property

    Public ReadOnly Property Data As cCaveRegisterData
        Get
            Return oRegister
        End Get
    End Property

    Private Function pGetURLBase() As String
        Dim sURL As String = oURI.Scheme & Uri.SchemeDelimiter & oURI.Host & IIf(oURI.IsDefaultPort, "", ":" & oURI.Port)
        For i As Integer = 0 To oURI.Segments.Count - 1
            sURL = sURL & oURI.Segments(i)
        Next
        Return sURL
    End Function

    'Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
    '    Dim oXmlCaveInfos As XmlElement = Document.CreateElement("caveinfos")
    '    For Each oCaveInfo As cCaveInfo In oCaveInfos.Values
    '        Call oCaveInfo.SaveTo(File, Document, oXmlCaveInfos)
    '    Next
    '    Call Parent.AppendChild(oXmlCaveInfos)
    '    Return oXmlCaveInfos
    'End Function

    Public Sub New(Survey As cSurvey.cSurvey, Register As cCaveRegisterData)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        oSurvey = Survey
        oSourceRegister = Register
        oRegister = New cCaveRegisterData(oSurvey, oSourceRegister)
        oSetting = oRegister.GetSetting

        oURI = New Uri(oSetting.URL)

        oTempFiles = New List(Of String)

        Call pLoadWebData(Register.HasData)
    End Sub

    Private Function pAppendTable(ParentPath As String, ParentName As String, Parent As XmlElement, Records As XmlElement, IsRootTable As Boolean) As TableLayoutPanel
        Dim oCurrentRecordsTable As TableLayoutPanel = New TableLayoutPanel
        oCurrentRecordsTable.Margin = New Padding(0)
        oCurrentRecordsTable.RowCount = 0
        oCurrentRecordsTable.ColumnCount = 1
        oCurrentRecordsTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        If modMain.bIsInDebug Then oCurrentRecordsTable.BackColor = Color.Green ' ParentControl.BackColor
        oCurrentRecordsTable.AutoSize = True

        oCurrentRecordsTable.Tag = {ParentPath, ParentName, Records}
        '----------------------------------
        Dim oDefaultElements As XmlElement = Nothing
        For Each oChildElement As XmlElement In Parent.ChildNodes
            Dim sXCondition As String = modXML.GetAttributeValue(oChildElement, "xcondition", "")
            If sXCondition = "" Then
                oDefaultElements = oChildElement
            End If
        Next
        '----------------------------------
        Dim bRecordCount As Boolean
        Dim iRecordIndex As Integer
        For Each oRecord As XmlElement In Records.ChildNodes
            Call pAddElementTable(ParentName, ParentPath, oCurrentRecordsTable, Parent, oDefaultElements, iRecordIndex, bRecordCount, IsRootTable, Records, oRecord, False)
        Next

        If Not IsRootTable Then
            Call pAddAddRecordButton(ParentName, ParentPath, oCurrentRecordsTable, oDefaultElements, iRecordIndex, bRecordCount, IsRootTable, Records, Records.ParentNode.Item("template").Item("record"))
        End If

        oCurrentRecordsTable.Width = pGetTableWidth(oCurrentRecordsTable)
        oCurrentRecordsTable.Height = pGetTableHeight(oCurrentRecordsTable)

        Return oCurrentRecordsTable
    End Function

    Private Function pAddAddRecordButton(ParentName As String, ParentPath As String, CurrentRecordsTable As TableLayoutPanel, DefaultElements As XmlElement, ByRef RecordIndex As Integer, ByRef RecordCount As Boolean, IsRootTable As Boolean, Records As XmlElement, DefaultRecord As XmlElement) As Button
        Dim oRecordAdd As Button = New Button
        oRecordAdd.Name = "cmd_add_record" & RecordIndex
        oRecordAdd.Image = cSurveyPC.My.Resources.add
        oRecordAdd.UseVisualStyleBackColor = True
        'oRecordAdd.Text = "Aggiungi"
        'oRecordAdd.FlatStyle = FlatStyle.System
        oRecordAdd.Anchor = AnchorStyles.Left
        'oRecordAdd.TextAlign = ContentAlignment.MiddleCenter
        'oRecordAdd.Width = 80
        oRecordAdd.Width = 24
        oRecordAdd.Enabled = True
        oRecordAdd.Tag = {ParentName, ParentPath, DefaultElements, RecordIndex, IsRootTable, Records, DefaultRecord}
        AddHandler oRecordAdd.Click, AddressOf pRecordAdd
        CurrentRecordsTable.RowCount += 1
        CurrentRecordsTable.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Call CurrentRecordsTable.Controls.Add(oRecordAdd)
        Call CurrentRecordsTable.SetCellPosition(oRecordAdd, New TableLayoutPanelCellPosition(1, CurrentRecordsTable.RowCount - 1))
        Return oRecordAdd
    End Function

    Private Sub pAddElementTable(ParentName As String, ParentPath As String, CurrentRecordsTable As TableLayoutPanel, ParentElements As XmlElement, DefaultElements As XmlElement, ByRef RecordIndex As Integer, ByRef RecordCount As Boolean, IsRootTable As Boolean, Records As XmlElement, Record As XmlElement, IsNew As Boolean)
        RecordCount = False
        CurrentRecordsTable.RowCount += 1
        CurrentRecordsTable.RowStyles.Add(New RowStyle(SizeType.AutoSize))

        Dim oCurrentRecordTable As TableLayoutPanel = New TableLayoutPanel
        oCurrentRecordTable.Margin = New Padding(0)
        oCurrentRecordTable.ColumnCount = 3
        oCurrentRecordTable.RowCount = 0
        If IsRootTable Then
            oCurrentRecordTable.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 0))
            oCurrentRecordTable.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 0))
        Else
            oCurrentRecordTable.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 32))
            oCurrentRecordTable.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 32))
        End If
        oCurrentRecordTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        If modMain.bIsInDebug Then oCurrentRecordTable.BackColor = Color.Blue ' ParentControl.BackColor
        oCurrentRecordTable.AutoSize = True

        RecordIndex += 1

        '----------------------------------
        Dim oElements As XmlElement = Nothing
        If DefaultElements Is Nothing Then
            For Each oChildElement As XmlElement In ParentElements.ChildNodes
                Dim sXCondition As String = modXML.GetAttributeValue(oChildElement, "xcondition", "")
                If sXCondition <> "" Then
                    sXCondition = sXCondition.Replace("%PARENTPATH%", ParentPath)
                    sXCondition = sXCondition.Replace("%INDEX%", RecordIndex)
                    Dim oNodes As XmlNodeList = Record.OwnerDocument.SelectNodes(sXCondition)
                    If oNodes.Count > 0 Then
                        oElements = oChildElement
                    End If
                End If
                If Not oElements Is Nothing Then
                    'gli elements con xcondition che restituisce almeno un nodo sono disegnati...gli altri no
                    Exit For
                End If
            Next
            If oElements Is Nothing Then
                oElements = DefaultElements
            End If
        Else
            oElements = DefaultElements
        End If

        If Not oElements Is Nothing Then
            Call pAddValueTable(ParentName, ParentPath, oCurrentRecordTable, oElements, RecordCount, RecordIndex, IsRootTable, Records, Record)
        End If

        oCurrentRecordTable.Width = pGetTableWidth(oCurrentRecordTable)
        oCurrentRecordTable.Height = pGetTableHeight(oCurrentRecordTable)
        Call CurrentRecordsTable.Controls.Add(oCurrentRecordTable)
        Call CurrentRecordsTable.SetCellPosition(oCurrentRecordTable, New TableLayoutPanelCellPosition(0, CurrentRecordsTable.RowCount - 1))
    End Sub

    Private Function pGetBooleanValue(Record As XmlElement, XPath As String, DefaultValue As Boolean) As Boolean
        Dim oNode As XmlNode = Record.OwnerDocument.SelectSingleNode(XPath)
        If oNode Is Nothing Then
            Return DefaultValue
        Else
            Dim bResult As Boolean
            If Boolean.TryParse(oNode.InnerText, bResult) Then
                Return bResult
            Else
                Return DefaultValue
            End If
        End If
    End Function

    Private Function pGetDecimalValue(Record As XmlElement, XPath As String, DefaultValue As Decimal) As Decimal
        Dim oNode As XmlNode = Record.OwnerDocument.SelectSingleNode(XPath)
        If oNode Is Nothing Then
            Return DefaultValue
        Else
            Dim dResult As Decimal
            If Decimal.TryParse(oNode.InnerText, dResult) Then
                Return dResult
            Else
                Return DefaultValue
            End If
        End If
    End Function

    Private Function pGetDateValue(Record As XmlElement, XPath As String, DefaultValue As Date) As Date
        Dim oNode As XmlNode = Record.OwnerDocument.SelectSingleNode(XPath)
        If oNode Is Nothing Then
            Return DefaultValue
        Else
            Dim dResult As Date
            If Date.TryParse(oNode.InnerText, dResult) Then
                Return dResult
            Else
                Return DefaultValue
            End If
        End If
    End Function

    Private Function pGetIntegerValue(Record As XmlElement, XPath As String, DefaultValue As Integer) As Integer
        Dim oNode As XmlNode = Record.OwnerDocument.SelectSingleNode(XPath)
        If oNode Is Nothing Then
            Return DefaultValue
        Else
            Dim iResult As Integer
            If Integer.TryParse(oNode.InnerText, iResult) Then
                Return iResult
            Else
                Return DefaultValue
            End If
        End If
    End Function

    Private Function pGetTextValue(Record As XmlElement, XPath As String, DefaultValue As String) As String
        Dim oNode As XmlNode = Record.OwnerDocument.SelectSingleNode(XPath)
        If oNode Is Nothing Then
            Return DefaultValue
        Else
            Return oNode.InnerText
        End If
    End Function

    Private Sub pAddValueTable(ParentName As String, ParentPath As String, CurrentRecordTable As TableLayoutPanel, Elements As XmlElement, ByRef RecordCount As Boolean, RecordIndex As Integer, IsRootTable As Boolean, Records As XmlElement, Record As XmlElement)
        Dim bIsNew As Boolean = modXML.GetAttributeValue(Record, "_new", "0")
        Dim bIsDeleted As Boolean = modXML.GetAttributeValue(Record, "_deleted", "0")

        If Not bIsDeleted Then

            Dim oCurrentValueTable As TableLayoutPanel
            Dim iColumnCount As Integer

            '----------------------------------
            oCurrentValueTable = New TableLayoutPanel
            oCurrentValueTable.Margin = New Padding(0)
            oCurrentValueTable.ColumnCount = 0
            oCurrentValueTable.RowCount = 0
            If modMain.bIsInDebug Then oCurrentValueTable.BackColor = Color.Red
            oCurrentValueTable.AutoSize = True
            iColumnCount = 0
            '----------------------------------

            For Each oElement As XmlElement In Elements.ChildNodes
                If modXML.GetAttributeValue(oElement, "newrow", 1) = 1 Then
                    If iColumnCount > 0 Then
                        Call CurrentRecordTable.Controls.Add(oCurrentValueTable)
                        Call CurrentRecordTable.SetCellPosition(oCurrentValueTable, New TableLayoutPanelCellPosition(2, CurrentRecordTable.RowCount - 1))
                        oCurrentValueTable.Width = pGetTableWidth(oCurrentValueTable)
                        oCurrentValueTable.Height = pGetTableHeight(oCurrentValueTable)
                    End If

                    Dim bBeginGroup As Boolean = modXML.GetAttributeValue(oElement, "begingroup", "0")
                    If bBeginGroup Then
                        CurrentRecordTable.RowCount += 1
                        CurrentRecordTable.RowStyles.Add(New RowStyle(SizeType.AutoSize))

                        '----------------------------------
                        oCurrentValueTable = New TableLayoutPanel
                        oCurrentValueTable.Margin = New Padding(0)
                        oCurrentValueTable.ColumnCount = 1
                        oCurrentValueTable.RowCount = 0
                        If modMain.bIsInDebug Then oCurrentValueTable.BackColor = Color.Red ' oCurrentRecordsTable.BackColor
                        Call oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                        oCurrentValueTable.AutoSize = True
                        '----------------------------------
                        pAddValueRow(oCurrentValueTable, CurrentRecordTable)
                        Call CurrentRecordTable.Controls.Add(oCurrentValueTable)
                        Call CurrentRecordTable.SetCellPosition(oCurrentValueTable, New TableLayoutPanelCellPosition(2, CurrentRecordTable.RowCount - 1))
                        oCurrentValueTable.Width = pGetTableWidth(oCurrentValueTable)
                        oCurrentValueTable.Height = pGetTableHeight(oCurrentValueTable)
                    End If

                    CurrentRecordTable.RowCount += 1
                    CurrentRecordTable.RowStyles.Add(New RowStyle(SizeType.AutoSize))

                    If Not RecordCount And Not IsRootTable Then
                        Dim oRecordLabel As Label = New Label
                        oRecordLabel.Name = "lbl_record" & RecordIndex
                        oRecordLabel.Text = RecordIndex
                        oRecordLabel.Anchor = AnchorStyles.Left
                        oRecordLabel.TextAlign = ContentAlignment.MiddleLeft
                        oRecordLabel.Enabled = True
                        Call CurrentRecordTable.Controls.Add(oRecordLabel)
                        Call CurrentRecordTable.SetCellPosition(oRecordLabel, New TableLayoutPanelCellPosition(0, CurrentRecordTable.RowCount - 1))

                        Call pAddDeleteRecordButton(RecordIndex, CurrentRecordTable, {Records, Record})

                        RecordCount = True
                    End If

                    '----------------------------------
                    oCurrentValueTable = New TableLayoutPanel
                    oCurrentValueTable.Margin = New Padding(0)
                    oCurrentValueTable.ColumnCount = 0
                    oCurrentValueTable.RowCount = 0
                    If modMain.bIsInDebug Then oCurrentValueTable.BackColor = Color.Red ' oCurrentRecordsTable.BackColor
                    oCurrentValueTable.AutoSize = True
                    iColumnCount = 0
                    '----------------------------------
                End If

                Dim sName As String = modXML.GetAttributeValue(oElement, "name", "")
                sName = sName.Replace("%PARENTNAME%", ParentName)
                sName = sName.Replace("%INDEX%", RecordIndex)

                Dim sLabel As String = modXML.GetAttributeValue(oElement, "label", "")

                Dim sXPath As String = modXML.GetAttributeValue(oElement, "xpath", "")
                sXPath = sXPath.Replace("%PARENTPATH%", ParentPath)
                sXPath = sXPath.Replace("%INDEX%", RecordIndex)

                Dim sType As String = modXML.GetAttributeValue(oElement, "type", "string")
                Dim sSubType As String() = modXML.GetAttributeValue(oElement, "subtype", "").ToString.Split(":")
                Dim bCanBeNull As Boolean = modXML.GetAttributeValue(oElement, "null", "1")
                Dim iLength As Integer = modXML.GetAttributeValue(oElement, "length", 5)
                Dim bReadonly As Boolean = modXML.GetAttributeValue(oElement, "readonly", "0")
                Dim bEnabled As Boolean = modXML.GetAttributeValue(oElement, "enabled", "1")

                If sLabel <> "" Or iColumnCount = 0 Then
                    Dim oLabel As Label = New Label
                    oLabel.Name = "lbl_" & sName
                    oLabel.Text = sLabel
                    oLabel.Anchor = AnchorStyles.Left
                    oLabel.TextAlign = ContentAlignment.MiddleLeft
                    oLabel.Enabled = bEnabled
                    Call oCurrentValueTable.Controls.Add(oLabel)
                    iColumnCount += 1
                    If iColumnCount > oCurrentValueTable.ColumnCount Then
                        oCurrentValueTable.ColumnCount += 1
                        Call oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                        'oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, iLabelColumnWidth))
                    End If
                    oCurrentValueTable.SetCellPosition(oLabel, New TableLayoutPanelCellPosition(0, oCurrentValueTable.RowCount - 1))
                    oLabel.Dock = DockStyle.Fill
                End If

                If sSubType(0) = "enum" Then
                    Dim sDefaultValue As String = ""

                    Dim oControl As ComboBox = New ComboBox
                    oControl.Name = sName
                    oControl.Tag = sXPath
                    oControl.DropDownStyle = ComboBoxStyle.DropDownList
                    oControl.Width = iLength * iCharWidth
                    oControl.Anchor = AnchorStyles.Left
                    oControl.DropDownWidth = oControl.Width * 2
                    oControl.Enabled = Not bReadonly
                    AddHandler oControl.Validating, AddressOf pControlValidate
                    oCurrentValueTable.Enabled = bEnabled
                    Dim oList As List(Of cEnumComboItem) = New List(Of cEnumComboItem)
                    If bCanBeNull Then
                        Call oList.Add(New cEnumComboItem("", ""))
                    End If
                    Call oList.AddRange(oEnumsForCombos(sSubType(1)))
                    Call oControl.Items.AddRange(oList.ToArray)
                    If sXPath <> "" Then
                        Dim oValue As cEnumComboItem = oList.FirstOrDefault(Function(item) item.Value = pGetTextValue(Record, sXPath, sDefaultValue))
                        oControl.SelectedItem = oValue
                    End If
                    Call oCurrentValueTable.Controls.Add(oControl)
                    iColumnCount += 1
                    If iColumnCount > oCurrentValueTable.ColumnCount Then
                        oCurrentValueTable.ColumnCount += 1
                        oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                    End If
                    oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                Else
                    Select Case sType
                        Case "file"
                            Dim sFilter As String = modXML.GetAttributeValue(oElement, "filter", "Tutti file (*.*)|*.*")
                            Dim sURLBase As String = modXML.GetAttributeValue(oElement, "urlbase", "")
                            Dim sFilename As String = pGetTextValue(Record, sXPath, "")
                            Dim oData As Stream
                            If sFilename <> "" Then
                                oData = pGetWebFile(sURLBase & "/" & sFilename)
                            End If
                            Dim sSize As String() = modXML.GetAttributeValue(oElement, "size", "32;32").ToString.Split(";")

                            oCurrentValueTable.Enabled = bEnabled

                            Dim oImageControl As PictureBox = New PictureBox
                            'oImageControl.Tag = oData
                            oImageControl.Width = sSize(0)
                            oImageControl.Height = sSize(1)
                            oImageControl.SizeMode = PictureBoxSizeMode.CenterImage
                            oImageControl.Image = pGetFilePreview(sFilename)
                            Call oCurrentValueTable.Controls.Add(oImageControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oImageControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))

                            Dim oFilenamelabel As Label = New Label
                            oFilenamelabel.Name = sName
                            oFilenamelabel.Tag = {sXPath, sURLBase}
                            oFilenamelabel.Width = iLength * iCharWidth
                            oFilenamelabel.Anchor = AnchorStyles.Left
                            oFilenamelabel.TextAlign = ContentAlignment.MiddleLeft
                            oFilenamelabel.Text = sFilename
                            Call oCurrentValueTable.Controls.Add(oFilenamelabel)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oFilenamelabel, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))

                            Call pAddViewButton(sName, cSurveyPC.My.Resources.Resources.folder_explorer, RecordIndex, iColumnCount, oCurrentValueTable, {oImageControl, oFilenamelabel, sFilter})

                            If bIsNew Then
                                Call pAddBrowseButton(sName, RecordIndex, iColumnCount, oCurrentValueTable, {oImageControl, oFilenamelabel, sFilter})
                            End If
                        Case "image"
                            Dim sFilter As String = modXML.GetAttributeValue(oElement, "filter", "Tutte le immagini (*.jpeg;*.jpg;*.tiff;*.tif;*.png;*.gif;*.bmp)|*.jpeg;*.jpg;*.tiff;*.tif;*.png;*.gif;*.bmp")
                            Dim sURLBase As String = modXML.GetAttributeValue(oElement, "urlbase", "")
                            Dim sFilename As String = pGetTextValue(Record, sXPath, "")
                            Dim oData As Stream
                            If sFilename <> "" Then
                                oData = pGetWebFile(sURLBase & "/" & sFilename)
                            End If
                            Dim sSize As String() = modXML.GetAttributeValue(oElement, "size", "32;32").ToString.Split(";")

                            oCurrentValueTable.Enabled = bEnabled

                            Dim oImageControl As PictureBox = New PictureBox
                            'oImageControl.Tag = oData
                            oImageControl.Width = sSize(0)
                            oImageControl.Height = sSize(1)
                            oImageControl.SizeMode = PictureBoxSizeMode.CenterImage
                            oImageControl.Image = pGetFileThumbnail(sFilename, oData, oImageControl.Width, oImageControl.Height)
                            Call oCurrentValueTable.Controls.Add(oImageControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oImageControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))

                            Dim oFilenamelabel As Label = New Label
                            oFilenamelabel.Name = sName
                            oFilenamelabel.Tag = {sXPath, sURLBase}
                            oFilenamelabel.Width = iLength * iCharWidth
                            oFilenamelabel.Anchor = AnchorStyles.Left
                            oFilenamelabel.TextAlign = ContentAlignment.MiddleLeft
                            oFilenamelabel.Text = sFilename
                            Call oCurrentValueTable.Controls.Add(oFilenamelabel)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oFilenamelabel, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))

                            Call pAddViewButton(sName, cSurveyPC.My.Resources.Resources.folder_explorer, RecordIndex, iColumnCount, oCurrentValueTable, {oImageControl, oFilenamelabel, sFilter})

                            If bIsNew Then
                                Call pAddBrowseButton(sName, RecordIndex, iColumnCount, oCurrentValueTable, {oImageControl, oFilenamelabel, sFilter})
                            End If
                        Case "coordinate"
                            Dim sDefaultValue As String = ""

                            Dim oControl As TextBox = New TextBox
                            oControl.Name = sName
                            oControl.Tag = sXPath
                            oControl.Width = iLength * iCharWidth
                            oControl.ReadOnly = bReadonly
                            oControl.Anchor = AnchorStyles.Left
                            oControl.Text = pGetTextValue(Record, sXPath, sDefaultValue)
                            AddHandler oControl.Validating, AddressOf pControlValidate
                            oCurrentValueTable.Enabled = bEnabled
                            Call oCurrentValueTable.Controls.Add(oControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                        Case "boolean"
                            Dim bDefaultValue As Boolean

                            Dim oControl As CheckBox = New CheckBox
                            oControl.Name = sName
                            oControl.Tag = sXPath
                            oControl.Width = iLength * iCharWidth
                            oControl.Anchor = AnchorStyles.Left
                            oControl.Checked = pGetBooleanValue(Record, sXPath, bDefaultValue)
                            AddHandler oControl.Validating, AddressOf pControlValidate
                            oControl.Enabled = Not bReadonly
                            oCurrentValueTable.Enabled = bEnabled
                            Call oCurrentValueTable.Controls.Add(oControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                        Case "integer", "decimal", "double", "single", "float"
                            Dim iDefaultValue As Integer = 0

                            Dim iDecimal As Integer = modXML.GetAttributeValue(oElement, "decimal", "0")
                            Dim dMax As Decimal = modXML.GetAttributeValue(oElement, "max", Decimal.MaxValue)
                            Dim dMin As Decimal = modXML.GetAttributeValue(oElement, "min", Decimal.MinValue)

                            Dim oControl As NumericUpDown = New NumericUpDown
                            oControl.Name = sName
                            oControl.Tag = sXPath
                            oControl.Width = iLength * iCharWidth
                            oControl.Enabled = Not bReadonly
                            oControl.Anchor = AnchorStyles.Left
                            oControl.TextAlign = HorizontalAlignment.Right
                            oControl.DecimalPlaces = iDecimal
                            oControl.Minimum = dMin
                            oControl.Maximum = dMax
                            oControl.Increment = 10 ^ -iDecimal
                            Select Case sType
                                Case "decimal", "float", "single", "double"
                                    oControl.Value = pGetDecimalValue(Record, sXPath, iDefaultValue)
                                Case "integer"
                                    oControl.Value = pGetIntegerValue(Record, sXPath, iDefaultValue)
                            End Select
                            AddHandler oControl.Validating, AddressOf pControlValidate
                            oCurrentValueTable.Enabled = bEnabled
                            Call oCurrentValueTable.Controls.Add(oControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                        Case "date"
                            Dim dDefaultValue As Date = Nothing

                            Dim oControl As DateTimePicker = New DateTimePicker
                            oControl.Name = sName
                            oControl.Tag = sXPath
                            oControl.Width = iLength * iCharWidth
                            oControl.Anchor = AnchorStyles.Left
                            oControl.Enabled = Not bReadonly
                            oControl.ShowCheckBox = False
                            AddHandler oControl.Validating, AddressOf pControlValidate
                            oCurrentValueTable.Enabled = bEnabled
                            Dim oValue As Date
                            If Date.TryParse(pGetDateValue(Record, sXPath, dDefaultValue), oValue) Then
                                oControl.Checked = True
                                oControl.Value = oValue
                            Else
                                oControl.Checked = False
                            End If
                            Call oCurrentValueTable.Controls.Add(oControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                        Case "elements"
                            oCurrentValueTable.Enabled = bEnabled
                            Dim oChildRecords As XmlElement
                            If sXPath = "" Then
                                oChildRecords = Records
                            Else
                                oChildRecords = Record.OwnerDocument.SelectSingleNode(sXPath)
                            End If
                            Dim oControl As TableLayoutPanel = pAppendTable(sXPath, sName, oElement, oChildRecords, False)
                            Call oCurrentValueTable.Controls.Add(oControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                        Case Else
                            Dim sDefaultValue As String = ""

                            Dim oControl As TextBox = New TextBox
                            oControl.Name = sName
                            oControl.Tag = sXPath
                            oControl.Width = iLength * iCharWidth
                            oControl.ReadOnly = bReadonly
                            oControl.Anchor = AnchorStyles.Left
                            oControl.Text = pGetTextValue(Record, sXPath, sDefaultValue)
                            AddHandler oControl.Validating, AddressOf pControlValidate
                            oCurrentValueTable.Enabled = bEnabled
                            Call oCurrentValueTable.Controls.Add(oControl)
                            iColumnCount += 1
                            If iColumnCount > oCurrentValueTable.ColumnCount Then
                                oCurrentValueTable.ColumnCount += 1
                                oCurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                            End If
                            Call oCurrentValueTable.SetCellPosition(oControl, New TableLayoutPanelCellPosition(iColumnCount - 1, oCurrentValueTable.RowCount - 1))
                    End Select
                End If
            Next

            oCurrentValueTable.Width = pGetTableWidth(oCurrentValueTable)
            oCurrentValueTable.Height = pGetTableHeight(oCurrentValueTable)
            Call CurrentRecordTable.Controls.Add(oCurrentValueTable)
            Call CurrentRecordTable.SetCellPosition(oCurrentValueTable, New TableLayoutPanelCellPosition(2, CurrentRecordTable.RowCount - 1))
            Call pAddLineRow(CurrentRecordTable)
        End If
    End Sub

    'Private Function pGetParentCollection(Element As XmlElement) As Dictionary(Of String, XmlElement)
    '    Dim oCollection As Dictionary(Of String, XmlElement) = New Dictionary(Of String, XmlElement)
    '    For Each oChildElement As XmlElement In Element.ChildNodes
    '        Dim sXCondition As String = modXML.GetAttributeValue(oChildElement, "xcondition", "")
    '        Call oCollection.Add(sXCondition, oChildElement)
    '    Next
    '    Return oCollection
    'End Function

    Private Sub pRecordAdd(Sender As Object, e As EventArgs)
        'devo ricostruire il 'Record' xml dal defaultElements
        'accodo a records il record creato e carico il pezzo di form per quel record...
        'oRecordAdd.Tag = {ParentName, ParentPath, oDefaultElements, iRecordIndex, IsRootTable, Records }
        Cursor = Cursors.WaitCursor
        Dim oButton As Button = Sender
        Dim oParameters() As Object = oButton.Tag
        Dim oCurrentRecordsTable As TableLayoutPanel = oButton.Parent
        Dim sParentName As String = oParameters(0)
        Dim sParentPath As String = oParameters(1)
        Dim oElements As XmlElement = oParameters(2)
        Dim iRecordIndex As Integer = oParameters(3)
        Dim bRecordCount As Boolean
        Dim bIsRootTable As Boolean = oParameters(4)
        Dim oRecords As XmlElement = oParameters(5)
        Dim oDefaultRecord As XmlElement = oParameters(6)
        Dim oRecord As XmlElement = oDefaultRecord.Clone 'oRecords.OwnerDocument.CreateElement("record")
        Call oRecord.SetAttribute("_new", 1)
        Call oRecords.AppendChild(oRecord)
        oCurrentRecordsTable.RowCount -= 1
        Call oCurrentRecordsTable.Controls.Remove(oButton)
        Call pAddElementTable(sParentName, sParentPath, oCurrentRecordsTable, Nothing, oElements, iRecordIndex, bRecordCount, bIsRootTable, oRecords, oRecord, True)
        If Not bIsRootTable Then
            Call pAddAddRecordButton(sParentName, sParentPath, oCurrentRecordsTable, oElements, iRecordIndex, bRecordCount, bIsRootTable, oRecords, oDefaultRecord)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function pAddDeleteRecordButton(RecordIndex As Integer, CurrentRecordTable As TableLayoutPanel, Tag As Object) As Button
        Dim oRecordDelete As Button = New Button
        oRecordDelete.Name = "cmd_delete_record" & RecordIndex
        'oRecordDelete.Text = "Elimina"
        oRecordDelete.Image = cSurveyPC.My.Resources.cross
        oRecordDelete.UseVisualStyleBackColor = True
        'oRecordDelete.FlatStyle = FlatStyle.System
        'oRecordDelete.TextAlign = ContentAlignment.MiddleCenter
        'oRecordDelete.Width = 80
        oRecordDelete.Width = 24
        oRecordDelete.Enabled = True
        oRecordDelete.Tag = Tag
        AddHandler oRecordDelete.Click, AddressOf pRecordDelete
        Call CurrentRecordTable.Controls.Add(oRecordDelete)
        Call CurrentRecordTable.SetCellPosition(oRecordDelete, New TableLayoutPanelCellPosition(1, CurrentRecordTable.RowCount - 1))
        Return oRecordDelete
    End Function

    Private Function pAddBrowseButton(Name As String, RecordIndex As Integer, ByRef ColumnCount As Integer, CurrentValueTable As TableLayoutPanel, Tag As Object) As Button
        Dim oFilenameButton As Button = New Button
        oFilenameButton.Name = "cmd_" & Name & "_record" & RecordIndex & "_browse"
        oFilenameButton.Text = "..."
        oFilenameButton.UseVisualStyleBackColor = True
        'oFilenameButton.FlatStyle = FlatStyle.System
        oFilenameButton.Anchor = AnchorStyles.Left
        oFilenameButton.TextAlign = ContentAlignment.MiddleCenter
        oFilenameButton.Width = 24
        oFilenameButton.Enabled = True
        oFilenameButton.Tag = Tag
        AddHandler oFilenameButton.Click, AddressOf pRecordFileBrowse
        Call CurrentValueTable.Controls.Add(oFilenameButton)
        ColumnCount += 1
        If ColumnCount > CurrentValueTable.ColumnCount Then
            CurrentValueTable.ColumnCount += 1
            CurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        End If
        Call CurrentValueTable.SetCellPosition(oFilenameButton, New TableLayoutPanelCellPosition(ColumnCount - 1, CurrentValueTable.RowCount - 1))
        Return oFilenameButton
    End Function

    Private Function pAddViewButton(Name As String, Image As Image, RecordIndex As Integer, ByRef ColumnCount As Integer, CurrentValueTable As TableLayoutPanel, Tag As Object) As Button
        Dim oViewButton As Button = New Button
        oViewButton.Name = "cmd_" & Name & "_record" & RecordIndex & "_view"
        oViewButton.Image = Image
        oViewButton.UseVisualStyleBackColor = True
        oViewButton.Anchor = AnchorStyles.Left
        oViewButton.Width = 24
        oViewButton.Enabled = True
        oViewButton.Tag = Tag
        AddHandler oViewButton.Click, AddressOf pRecordFileView
        Call CurrentValueTable.Controls.Add(oViewButton)
        ColumnCount += 1
        If ColumnCount > CurrentValueTable.ColumnCount Then
            CurrentValueTable.ColumnCount += 1
            Call CurrentValueTable.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        End If
        Call CurrentValueTable.SetCellPosition(oViewButton, New TableLayoutPanelCellPosition(ColumnCount - 1, CurrentValueTable.RowCount - 1))
        Return oViewButton
    End Function

    Private Sub pControlValidate(Sender As Object, e As System.ComponentModel.CancelEventArgs)
        Dim sXPath As String = Sender.Tag
        Dim oXMLElement As XmlElement = oRegister.Data.SelectSingleNode(sXPath)
        Select Case TypeName(Sender).ToLower
            Case "datetimepicker"
                oXMLElement.InnerText = DirectCast(Sender, DateTimePicker).Value
            Case "checkbox"
                oXMLElement.InnerText = IIf(DirectCast(Sender, CheckBox).Checked, "1", "0")
            Case "numericupdown"
                oXMLElement.InnerText = modNumbers.NumberToString(DirectCast(Sender, NumericUpDown).Value, "")
            Case "combobox"
                oXMLElement.InnerText = DirectCast(Sender, ComboBox).SelectedItem.value
            Case Else
                oXMLElement.InnerText = DirectCast(Sender, TextBox).Text
        End Select
    End Sub

    Private oTempFiles As List(Of String)

    Private Sub pRecordFileView(Sender As Object, e As EventArgs)
        Dim oButton As Button = Sender
        Dim oButtonParameters() As Object = oButton.Tag
        Dim oImage As PictureBox = oButtonParameters(0)
        Dim oLabel As Label = oButtonParameters(1)
        Dim sFilter As String = oButtonParameters(2)
        Dim oParameters As Object = oLabel.Tag
        Dim sXPath As String = oParameters(0)
        Dim sURLBase As String = oParameters(1)

        Dim sFilename As String = oLabel.Text
        Dim oStream As MemoryStream = pGetWebFile(pGetCacheURL(sURLBase & "/" & sFilename))
        If oStream Is Nothing Then
            Call MsgBox("File non valido.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Critical, "Attenzione:")
        Else
            oStream.Position = 0
            Dim sTempFilename As String = Path.Combine(Path.GetTempPath, sFilename)
            'Dim sTempFilename As String = Path.Combine(Path.GetTempPath, Guid.NewGuid.ToString & "_" & sFilename)
            Dim bData(oStream.Length - 1) As Byte
            Call oStream.Read(bData, 0, oStream.Length)
            Call My.Computer.FileSystem.WriteAllBytes(sTempFilename, bData, False)
            Call Shell("explorer " & Chr(34) & sTempFilename & Chr(34), AppWinStyle.NormalFocus, False)

            'accodo il file tra quelli da eliminare sulla finalize...
            Call oTempFiles.Add(sTempFilename)
        End If
    End Sub

    Private Sub pRecordFileBrowse(Sender As Object, e As EventArgs)
        Dim oButton As Button = Sender
        Dim oButtonParameters() As Object = oButton.Tag
        Dim oImage As PictureBox = oButtonParameters(0)
        Dim oLabel As Label = oButtonParameters(1)
        Dim sFilter As String = oButtonParameters(2)
        Dim oParameters As Object = oLabel.Tag
        Dim sXPath As String = oParameters(0)
        Dim sURLBase As String = oParameters(1)
        Dim oOFD As OpenFileDialog = New OpenFileDialog
        With oOFD
            .Title = "Seleziona un file:"
            .Filter = sFilter
            .FilterIndex = 1
            '.FileName = oLabel.Tag
            If .ShowDialog = DialogResult.OK Then
                oLabel.Text = IO.Path.GetFileName(.FileName)
                Dim oXMLElement As XmlElement = oRegister.Data.SelectSingleNode(sXPath)
                oXMLElement.InnerText = oLabel.Text
                Dim oData As MemoryStream = pGetLocalFile(.FileName)
                oImage.Image = pGetFileThumbnail(.FileName, oData, oImage.Width, oImage.Height)
                oRegister.Files.Add(pGetCacheURL(sURLBase & "/" & Path.GetFileName(.FileName)), oData)
            End If
        End With
    End Sub

    Private Sub pRecordDelete(Sender As Object, e As EventArgs)
        If MsgBox("Eliminare il record corrente?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question, "Attenzione:") = MsgBoxResult.Ok Then
            Cursor = Cursors.WaitCursor
            Dim oButton As Button = Sender
            Dim oParameters() As Object = oButton.Tag
            Dim oRecords As XmlElement = oParameters(0)
            Dim oRecord As XmlElement = oParameters(1)
            Call oRecord.SetAttribute("_deleted", 1)
            oButton.Parent.Parent.Controls.Remove(oButton.Parent)
            Cursor = Cursors.Default
        End If
    End Sub

    'Private Function pToolbarAdd() As ToolStrip
    '    Dim oToolbar As ToolStrip = New ToolStrip
    '    oToolbar.ImageList = imlData
    '    oToolbar.GripStyle = ToolStripGripStyle.Hidden
    '    Dim oButtonAdd As ToolStripButton = New ToolStripButton("Aggiungi")
    '    oButtonAdd.ImageKey = "add"
    '    Call oToolbar.Items.Add(oButtonAdd)
    '    oToolbar.Dock = DockStyle.Top
    '    Return oToolbar
    'End Function

    Private Sub pAddEmptyRow(CurrentTable As TableLayoutPanel)
        CurrentTable.RowCount += 1
        Call CurrentTable.RowStyles.Add(New RowStyle(SizeType.AutoSize, 5))
    End Sub

    Private Sub pAddValueRow(CurrentTable As TableLayoutPanel, CurrentRecordTable As TableLayoutPanel)
        CurrentTable.RowCount += 1
        Call CurrentTable.RowStyles.Add(New RowStyle(SizeType.Absolute, 5))
        Dim oLinePanel0 As Panel = New Panel
        oLinePanel0.Size = New Size(pGetTableWidth(CurrentRecordTable), 1)
        oLinePanel0.BackColor = Color.DarkGray
        oLinePanel0.Margin = New Padding(0)
        oLinePanel0.Dock = DockStyle.Top
        Call CurrentTable.Controls.Add(oLinePanel0)
        Call CurrentTable.SetCellPosition(oLinePanel0, New TableLayoutPanelCellPosition(0, CurrentTable.RowCount - 1))
        'Dim oLinePanel1 As Panel = New Panel
        'oLinePanel1.Size = New Size(CurrentTable.GetColumnWidths(1), 1)
        'oLinePanel1.BackColor = Color.DarkGray
        'oLinePanel1.Margin = New Padding(0)
        'oLinePanel1.Dock = DockStyle.Top
        'Call CurrentTable.Controls.Add(oLinePanel1)
        'Call CurrentTable.SetCellPosition(oLinePanel1, New TableLayoutPanelCellPosition(1, CurrentTable.RowCount - 1))
    End Sub

    Private Sub pAddLineRow(CurrentTable As TableLayoutPanel)
        CurrentTable.RowCount += 1
        Call CurrentTable.RowStyles.Add(New RowStyle(SizeType.Absolute, 5))
        Dim oLinePanel0 As Panel = New Panel
        oLinePanel0.Size = New Size(CurrentTable.GetColumnWidths(0), 1)
        oLinePanel0.BackColor = Color.DarkGray
        oLinePanel0.Margin = New Padding(0)
        oLinePanel0.Dock = DockStyle.Top
        Call CurrentTable.Controls.Add(oLinePanel0)
        Call CurrentTable.SetCellPosition(oLinePanel0, New TableLayoutPanelCellPosition(0, CurrentTable.RowCount - 1))
        Call CurrentTable.SetColumnSpan(oLinePanel0, 3)
        'Dim oLinePanel1 As Panel = New Panel
        'oLinePanel1.Size = New Size(CurrentTable.GetColumnWidths(1), 1)
        'oLinePanel1.BackColor = Color.DarkGray
        'oLinePanel1.Margin = New Padding(0)
        'oLinePanel1.Dock = DockStyle.Top
        'Call CurrentTable.Controls.Add(oLinePanel1)
        'Call CurrentTable.SetCellPosition(oLinePanel1, New TableLayoutPanelCellPosition(1, CurrentTable.RowCount - 1))
    End Sub

    Private Function pGetTableWidth(Table As TableLayoutPanel) As Integer
        Dim iWidth As Integer = 0
        For iChildColumn As Integer = 0 To Table.ColumnCount - 1
            If Table.ColumnStyles(iChildColumn).SizeType = SizeType.Absolute Then
                iWidth += Table.ColumnStyles(iChildColumn).Width
            Else
                iWidth += Table.GetColumnWidths(iChildColumn)
            End If
        Next
        Return iWidth
    End Function

    Private Function pGetTableHeight(Table As TableLayoutPanel) As Integer
        Dim iHeight As Integer = 0
        For iChildRow As Integer = 0 To Table.RowCount - 1
            If Table.RowStyles(iChildRow).SizeType = SizeType.Absolute Then
                iHeight += Table.RowStyles(iChildRow).Height
            Else
                iHeight += Table.GetRowHeights(iChildRow)
            End If
        Next
        Return iHeight
    End Function

    Private Function pThumbnailCallback() As Boolean
        Return False
    End Function

    Private Function pGetLocalFile(Filename As String) As MemoryStream
        Dim oStream As MemoryStream = New MemoryStream(My.Computer.FileSystem.ReadAllBytes(Filename))
        oStream.Position = 0
        Return oStream
    End Function

    Private Function pGetCacheURL(URL As String) As String
        Return URL.Replace("/", "_").Replace("\", "_")
    End Function

    Private Function pGetWebFile(URL As String) As MemoryStream
        Dim sCacheURL As String = pGetCacheURL(URL)
        Dim oStream As MemoryStream = Nothing
        If oRegister.Files.ContainsKey(sCacheURL) Then
            oStream = oRegister.Files(sCacheURL)
            oStream.Position = 0
        Else
            Try
                Dim oWC As WebClient = New WebClient
                Dim sURL As String = pGetURLBase() & "/" & URL
                oStream = New MemoryStream(oWC.DownloadData(sURL))
                oStream.Position = 0
                Call oWC.Dispose()
                Call oRegister.Files.Add(sCacheURL, oStream)
            Catch ex As Exception
            End Try
        End If
        Return oStream
    End Function

    Private Function pGetFileThumbnail(Filename As String, Data As Stream, Width As Integer, Height As Integer) As Image
        If Data Is Nothing Then
            Return pGetFilePreview(Filename)
        Else
            Select Case Path.GetExtension(Filename).ToLower
                Case ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tif", ".tiff"
                    Try
                        Data.Position = 0
                        Return modPaint.GetImageThumbnail(Bitmap.FromStream(Data), Width, Height)
                    Catch ex As Exception
                        Return pGetFilePreview(Filename)
                    End Try
                Case Else
                    Return pGetFilePreview(Filename)
            End Select
        End If
    End Function

    Private Function pGetFilePreview(Filename As String) As Image
        Dim sExt As String = IO.Path.GetExtension(Filename).Replace(".", "")
        Dim sImageKey As String = "file_extension_" & sExt & ".png"
        If imlFile.Images.ContainsKey(sImageKey) Then
            Return imlFile.Images(sImageKey)
        Else
            Return imlFile.Images("page_white.png")
        End If
    End Function

    Public Sub [Get]()
        If MsgBox("Sovrascrivere i dati attualmente scaricati?", vbYesNo Or MsgBoxStyle.Critical, "Attenzione:") = MsgBoxResult.Yes Then
            Call pLoadWebData(False)
        End If
    End Sub

    Private Sub pLoadWebData(Offline As Boolean)
        Call tbTabs.TabPages.Clear()

        If Not Offline Then
            Call oRegister.Get()
        End If

        ' qua devo preparare le varie enums che poi andranno a riempire i vari combo...
        oEnumsForCombos = New Dictionary(Of String, List(Of cEnumComboItem))
        Dim oEnums As XmlElement = oRegister.Structure.Item("formstructure").Item("enums")
        For Each oEnum As XmlElement In oEnums.ChildNodes
            Dim sName As String = oEnum.GetAttribute("name")
            Dim oEnumForCombo As List(Of cEnumComboItem) = New List(Of cEnumComboItem)
            For Each oEnumItem As XmlElement In oEnum.ChildNodes
                Dim sValue As String = oEnumItem.GetAttribute("value")
                Dim sDescription As String = oEnumItem.InnerText
                Call oEnumForCombo.Add(New cEnumComboItem(sValue, sDescription))
            Next
            Call oEnumsForCombos.Add(sName, oEnumForCombo)
        Next
        Dim oRecords As Object = oRegister.Data.Item("form").Item("records")
        Dim oTabs As XmlElement = oRegister.Structure.Item("formstructure").Item("tabs")
        For Each oTab As XmlElement In oTabs.ChildNodes
            Dim sName As String = oTab.GetAttribute("name")
            Dim sLabel As String = oTab.GetAttribute("label")
            Dim oTabPage As TabPage = New TabPage(sLabel)
            oTabPage.Name = sLabel
            oTabPage.BackColor = Color.White ' Color.Transparent
            Call tbTabs.TabPages.Add(oTabPage)
            Dim oControl As TableLayoutPanel = pAppendTable("form", "", oTab, oRecords, True)
            oControl.AutoScroll = True
            Call oTabPage.Controls.Add(oControl)
            oControl.Dock = DockStyle.Fill
        Next
    End Sub

    Public Sub Save()
        Call oSourceRegister.CopyFrom(oRegister)
    End Sub

    Public Sub [Set]()
        Call oSourceRegister.CopyFrom(oRegister)
        'Call oRegister.Set()
    End Sub

    Protected Overrides Sub Finalize()
        For Each sTempFile In oTempFiles
            Try
                Call My.Computer.FileSystem.DeleteFile(sTempFile)
            Catch
            End Try
        Next
        MyBase.Finalize()
    End Sub
End Class
