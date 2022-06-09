Imports System.Xml
Imports cSurveyPC.cSurvey

Namespace cSurvey
    Public Class cDuplicatedLinkedSurveyException
        Inherits Exception

        Public Sub New(Filename As String, ID As String)
            MyBase.New(String.Format(modMain.GetLocalizedString("linkedsurveys.textpart3"), Filename, ID))
        End Sub
    End Class

    Public Class cLinkedSurvey
        Private oLinkedSurveys As cLinkedSurveys

        Private sFilename As String
        Private sNote As String
        Private oLinkedSurvey As cSurvey

        Private sParentID As String
        Private oParent As cLinkedSurvey

        Private oSelected As List(Of String)

        Public Function GetChildren() As List(Of cLinkedSurvey)
            Return oLinkedSurveys.Survey.LinkedSurveys.Where(Function(oitem) oitem.Parent Is Me).ToList
        End Function

        Public Function HasChildren() As Boolean
            Return oLinkedSurveys.Survey.LinkedSurveys.Where(Function(oitem) oitem.Parent Is Me).Count > 0
        End Function

        Public Function GetSelected(Context As String) As Boolean
            Return oSelected.Contains(Context.ToLower)
        End Function

        Public Sub SetSelected(Context As String, Selected As Boolean)
            Dim sContext As String = Context.ToLower
            If Selected Then
                If Not oSelected.Contains(sContext) Then
                    Call oSelected.Add(sContext)
                End If
            Else
                If oSelected.Contains(sContext) Then
                    oSelected.Remove(sContext)
                End If
            End If
        End Sub

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oLinkedSurveys.Survey
            End Get
        End Property

        Public Property Note As String
            Get
                Return sNote
            End Get
            Set(value As String)
                sNote = value
            End Set
        End Property

        Public ReadOnly Property Self() As cLinkedSurvey
            Get
                Return Me
            End Get
        End Property

        Public Function GetID() As String
            If IsValid() Then
                Return oLinkedSurvey.ID
            Else
                Return ""
            End If
        End Function

        Public Function GetName() As String
            If IsValid() Then
                Return oLinkedSurvey.Name
            Else
                Return "-"
            End If
        End Function

        Public Function GetFilename() As String
            Return IO.Path.GetFileName(sFilename)
        End Function

        Public Function GetFolder() As String
            Return IO.Path.GetDirectoryName(sFilename)
        End Function

        Friend Sub New(ByVal LinkedSurveys As cLinkedSurveys, ByVal Item As XmlElement)
            oLinkedSurveys = LinkedSurveys
            sFilename = Item.GetAttribute("f")
            sNote = modXML.GetAttributeValue(Item, "n", "")
            oSelected = New List(Of String)(modXML.GetAttributeValue(Item, "s", "").ToString.Split({"|"}, StringSplitOptions.RemoveEmptyEntries))
            sParentID = modXML.GetAttributeValue(Item, "p", "")
            Dim bRefreshOnLoad As Boolean
            Call oLinkedSurveys.Survey.RaiseOnLinkedSurveysLoad(Me, bRefreshOnLoad)
            If Not bRefreshOnLoad Then
                'if refreshonload is not enabled refresh only open csurvey file...if enabled refresh is done by parent
                Call pRefresh(False)
            End If
        End Sub

        Friend Sub New(ByVal LinkedSurveys As cLinkedSurveys, ByVal LinkedSurvey As cLinkedSurvey)
            oLinkedSurveys = LinkedSurveys
            sFilename = LinkedSurvey.sFilename
            sNote = LinkedSurvey.sNote
            oSelected = New List(Of String)(LinkedSurvey.oSelected)
            sParentID = ""
            oParent = LinkedSurvey.Parent
            Call pRefresh(True)
        End Sub

        Public ReadOnly Property Parent As cLinkedSurvey
            Get
                If sParentID <> "" Then
                    oParent = oLinkedSurveys.FirstOrDefault(Function(oitem) oitem.GetID = sParentID)
                    sParentID = ""
                End If
                Return oParent
            End Get
        End Property

        Private Sub pNew(LinkedSurveys As cLinkedSurveys, Filename As String, Parent As cLinkedSurvey)
            oLinkedSurveys = LinkedSurveys
            sFilename = Filename.ToLower    'tolower...path is not case sensitive and due to relative path management is better with no capital letter...
            sNote = ""
            oSelected = New List(Of String)
            sParentID = ""
            oParent = Parent
            Call pRefresh(True)
        End Sub

        Friend Sub New(LinkedSurveys As cLinkedSurveys, Filename As String, Parent As cLinkedSurvey)
            Call pNew(LinkedSurveys, Filename, Parent)
        End Sub

        Public Sub New(LinkedSurveys As cLinkedSurveys, Filename As String)
            Call pNew(LinkedSurveys, Filename, Nothing)
        End Sub

        Friend Sub Relink(Filename As String)
            If sFilename <> Filename Then
                sFilename = Filename
                Call pRefresh(True)
            End If
        End Sub

        Private Sub pRefresh(Recursive As Boolean)
            Try
                oLastException = Nothing
                If My.Computer.FileSystem.FileExists(sFilename) Then
                    oLinkedSurvey = New cSurvey
                    Dim oResult As cActionResult = oLinkedSurvey.Load(sFilename, cSurvey.LoadOptionsEnum.IsLinkedSurvey)
                    If Not oResult.Result Then
                        oLastException = oResult.Exception
                        oLinkedSurvey = Nothing
                    Else
                        Dim bIsDuplicated As Boolean = oLinkedSurveys.ContainsCopyOf(Me) ' Not oSurvey.LinkedSurveys.FirstOrDefault(Function(oitem) Not oitem Is Me AndAlso oitem.GetID = oLinkedSurvey.ID) Is Nothing
                        If bIsDuplicated Then
                            Call oLinkedSurveys.Survey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "Survey file """ & sFilename & """ is already linked")
                            oLastException = New cDuplicatedLinkedSurveyException(sFilename, oLinkedSurvey.ID)
                            oLinkedSurvey = Nothing
                        Else
                            'recheck child linkedsurvey
                            If Recursive Then Call oLinkedSurveys.RecursiveAdd(Me)
                        End If
                    End If
                Else
                    oLinkedSurvey = Nothing
                    oLastException = New System.IO.FileNotFoundException()
                End If
            Catch ex As Exception
                oLinkedSurvey = Nothing
                oLastException = ex
            End Try
        End Sub

        Public Sub Refresh()
            Call pRefresh(True)
        End Sub

        Private oLastException As Exception

        Public ReadOnly Property LastException As Exception
            Get
                Return oLastException
            End Get
        End Property

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property
        Public ReadOnly Property IsGeoreferenced As Boolean
            Get
                If IsValid Then
                    Return oLinkedSurvey.Properties.GPS.Enabled AndAlso oLinkedSurvey.Properties.GPS.GetRefPoint <> ""
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property IsUsable As Boolean
            Get
                Return IsValid AndAlso IsGeoreferenced
            End Get
        End Property

        Public ReadOnly Property IsValid As Boolean
            Get
                Return Not IsNothing(oLinkedSurvey)
            End Get
        End Property

        Public ReadOnly Property LinkedSurvey As cSurvey
            Get
                Return oLinkedSurvey
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXMLLinkedSurvey As XmlElement = Document.CreateElement("linkedsurvey")
            Call oXMLLinkedSurvey.SetAttribute("f", sFilename)
            If sNote <> "" Then oXMLLinkedSurvey.SetAttribute("n", sNote)
            If oSelected.Count > 0 Then oXMLLinkedSurvey.SetAttribute("s", String.Join("|", oSelected))
            If Not oParent Is Nothing Then oXMLLinkedSurvey.SetAttribute("p", oParent.GetID)
            Call Parent.AppendChild(oXMLLinkedSurvey)
            Return oXMLLinkedSurvey
        End Function

        Public Overrides Function ToString() As String
            Return "→ " & GetName() & " [" & sFilename & "]"
        End Function
    End Class

    Public Class cLinkedSurveys
        Implements IEnumerable
        Implements IEnumerable(Of cLinkedSurvey)

        Private oSurvey As cSurvey
        Private oItems As List(Of cLinkedSurvey)

        Public Function GetParents() As List(Of cLinkedSurvey)
            Return oItems.Where(Function(oitem) oitem.Parent Is Nothing).ToList
        End Function

        'Private Sub pBaseAdd(Item As cLinkedSurvey)
        '    Call oItems.Add(Item)
        '    If Item.Parent Is Nothing Then
        '        Call oParents.Add(Item)
        '    End If
        'End Sub

        'Private Sub pBaseRemove(Item As cLinkedSurvey)
        '    Call oItems.Remove(Item)
        '    Call oParents.Remove(Item)
        'End Sub

        Public Sub MergeWith(ByVal LinkedSurveys As cLinkedSurveys)
            If Not LinkedSurveys Is Me Then
                For Each oItem As cLinkedSurvey In LinkedSurveys
                    If Not IsNothing(oItem.LinkedSurvey) Then
                        If Contains(oItem.LinkedSurvey.ID) Then
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Warning, "Survey file """ & oItem.Filename & """ is already linked")
                        Else
                            Dim oNewItem As cLinkedSurvey = New cLinkedSurvey(Me, oItem)
                            Call oItems.Add(oNewItem)
                            Call RecursiveAdd(oNewItem)
                            Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "Survey file """ & oNewItem.Filename & """ successfully linked")
                        End If
                    End If
                Next
            End If
        End Sub

        Public Sub CopyFrom(ByVal LinkedSurveys As cLinkedSurveys)
            If Not LinkedSurveys Is Me Then
                Call oItems.Clear()
                For Each oItem As cLinkedSurvey In LinkedSurveys
                    Dim oNewItem As cLinkedSurvey = New cLinkedSurvey(Me, oItem)
                    Call oItems.Add(oNewItem)
                    Call RecursiveAdd(oNewItem)
                    Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "Survey file """ & oNewItem.Filename & """ successfully linked")
                Next
            End If
        End Sub

        Public Function GetUsable() As List(Of cLinkedSurvey)
            Return oItems.Where(Function(item) item.IsUsable).ToList
        End Function

        Public Function GetSelected(Context As String, Optional OnlyUsable As Boolean = True) As List(Of cLinkedSurvey)
            Return oItems.Where(Function(item) item.GetSelected(Context) AndAlso ((OnlyUsable AndAlso item.IsUsable) OrElse Not OnlyUsable)).ToList
        End Function

        Public ReadOnly Property Survey() As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cLinkedSurvey)
        End Sub

        'Private Function pExist(ID As String) As Boolean
        '    If oSurvey.ID = ID Then
        '        Return True
        '    Else
        '        For Each oItem As cLinkedSurvey In oItems
        '            If oItem.GetID = ID Then
        '                Return True
        '            End If
        '        Next
        '    End If
        '    Return False
        'End Function

        'Private Function pExist(Survey As cSurvey) As Boolean
        '    Return pExist(Survey.ID)
        'End Function

        Public Sub Remove(Item As cLinkedSurvey)
            If oItems.Contains(Item) AndAlso Item.Parent Is Nothing Then
                Call pRemove(Item)
                Call oSurvey.RaiseOnLinkedSurveysRefresh()
            End If
        End Sub

        Private Sub pRemove(Item As cLinkedSurvey)
            Call oItems.Remove(Item)
            For Each oItem As cLinkedSurvey In oItems.Where(Function(oChild) oChild.Parent Is Item).ToList
                Call oItems.Remove(oItem)
            Next
        End Sub

        Public Function GetByID(ID As String) As cLinkedSurvey
            Return oItems.FirstOrDefault(Function(oitem) oitem.GetID = ID)
        End Function

        Default Public ReadOnly Property Item(Index As Integer) As cLinkedSurvey
            Get
                Return oItems(Index)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Sub Clear()
            Call oItems.Clear()
        End Sub

        Public Sub Refresh()
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oItems.Count
            Dim iStep As Integer = 1 'If(iCount > 20, iCount \ 20, 1)
            For Each oItem As cLinkedSurvey In oItems.ToList
                iIndex += 1
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart1"), oItem.GetFilename), iIndex / iCount)
                Call oItem.Refresh()
            Next
            Call oSurvey.RaiseOnLinkedSurveysRefresh()
            Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub

        Public Function Contains(LinkedSurvey As cLinkedSurvey) As Boolean
            Return oItems.Contains(LinkedSurvey)
        End Function

        Public Function ContainsCopyOf(LinkedSurvey As cLinkedSurvey) As Boolean
            Dim oSearchIn As List(Of cLinkedSurvey) = New List(Of cLinkedSurvey)(oItems.Where(Function(oItem) Not oItem Is LinkedSurvey))
            If LinkedSurvey.GetID = "" Then
                Return oSearchIn.Select(Function(oitem) oitem.Filename.ToLower).Contains(LinkedSurvey.Filename.ToLower)
            Else
                Return oSearchIn.Select(Function(oitem) oitem.GetID).Contains(LinkedSurvey.GetID) OrElse oSearchIn.Select(Function(oitem) oitem.Filename.ToLower).Contains(LinkedSurvey.Filename.ToLower)
            End If
        End Function

        Public Function Contains(Survey As cSurvey) As Boolean
            Return Contains(Survey.ID)
        End Function

        Public Function Contains(ID As String) As Boolean
            Return oItems.Select(Function(oitem) oitem.GetID).Contains(ID)
        End Function

        Public Function ContainsFilename(Filename As String) As Boolean
            Return oItems.Select(Function(oitem) oitem.Filename.ToLower).Contains(Filename.ToLower)
        End Function

        Friend Sub RecursiveAdd(Parent As cLinkedSurvey)
            Dim bRecursiveLoad As Boolean
            Dim bPrioritizeChildren As Boolean
            Call oSurvey.RaiseOnLinkedSurveysAdd(Parent, bRecursiveLoad, bPrioritizeChildren)
            If bRecursiveLoad Then
                For Each oCurrentItem As cLinkedSurvey In Parent.GetChildren.ToList
                    Call oItems.Remove(oCurrentItem)
                Next
                For Each oLinkedsurvey As cLinkedSurvey In Parent.LinkedSurvey.LinkedSurveys
                    If bPrioritizeChildren Then
                        For Each oLinkedSurveyToRemove In oItems.Where(Function(oItem) oItem.Filename.ToLower = oLinkedsurvey.Filename.ToLower).ToList
                            Call oItems.Remove(oLinkedSurveyToRemove)
                        Next
                    End If
                    Call pAdd(Parent, oLinkedsurvey.Filename)
                Next
            End If
        End Sub

        Private Function pAdd(Parent As cLinkedSurvey, Filename As String) As cLinkedSurvey
            Dim oItem As cLinkedSurvey = New cLinkedSurvey(Me, Filename, Parent)
            If IsNothing(oItem.LinkedSurvey) Then
                'If Parent Is Nothing Then
                '    'show always error for 1 level linked surveys...
                Call oItems.Add(oItem)
                Return oItem
                'Else
                'Return Nothing
                'End If
            Else
                Call oItems.Add(oItem)
                Call RecursiveAdd(oItem)
                Call oSurvey.RaiseOnLogEvent(cSurvey.LogEntryType.Information, "Survey file """ & Filename & """ successfully linked")
                Return oItem
            End If
        End Function

        Public Function Add(Filename As String) As cLinkedSurvey
            Dim oItem As cLinkedSurvey = pAdd(Nothing, Filename)
            Call oSurvey.RaiseOnLinkedSurveysRefresh()
            Return oItem
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Items As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cLinkedSurvey)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Items.ChildNodes.Count
            Dim iStep As Integer = 1 'IIf(iCount > 20, iCount \ 20, 1)
            For Each oXMLItem As XmlElement In Items.ChildNodes
                iIndex += 1
                Dim sFilename As String = oXMLItem.GetAttribute("f")
                Dim sNewFilename = modWindow.RelativeToAbsolutePath(sFilename, IO.Path.GetDirectoryName(File.Filename))
                If My.Computer.FileSystem.FileExists(sNewFilename) Then
                    Call oXMLItem.SetAttribute("f", sNewFilename)
                End If
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart1"), IO.Path.GetFileName(sFilename)), iIndex / iCount)
                Dim oItem As cLinkedSurvey = New cLinkedSurvey(Me, oXMLItem)
                Call oItems.Add(oItem)

                Dim bRefreshOnLoad As Boolean
                Call oSurvey.RaiseOnLinkedSurveysLoad(oItem, bRefreshOnLoad)
                If bRefreshOnLoad Then
                    Call oItem.Refresh()
                End If
            Next
            Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItems As XmlElement = Document.CreateElement("linkedsurveys")
            For Each oItem As cLinkedSurvey In oItems
                Dim oXMLItem As XmlElement = oItem.SaveTo(File, Document, oXmlItems, Options)
                If File.Filename <> "" Then Call oXMLItem.SetAttribute("f", modWindow.AbsolutePathToRelative(oXMLItem.GetAttribute("f"), IO.Path.GetDirectoryName(File.Filename)))
            Next
            Call Parent.AppendChild(oXmlItems)
            Return oXmlItems
        End Function

        Public Function GetEnumerator() As IEnumerator(Of cLinkedSurvey) Implements IEnumerable(Of cLinkedSurvey).GetEnumerator
            Return oItems.GetEnumerator
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace