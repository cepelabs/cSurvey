Imports System.Xml
Imports cSurveyPC.cSurvey

Namespace cSurvey
    Public Class cLinkedSurvey
        Private oSurvey As cSurvey

        Private sFilename As String
        Private sNote As String
        Private oLinkedSurvey As cSurvey

        Private oSelected As List(Of String)

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
                Return oSurvey
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

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            oSurvey = Survey
            sFilename = Item.GetAttribute("f")
            sNote = modXML.GetAttributeValue(Item, "n", "")
            oSelected = New List(Of String)(modXML.GetAttributeValue(Item, "s", "").ToString.Split({"|"}, StringSplitOptions.RemoveEmptyEntries))
            Call Refresh()
        End Sub

        Public Sub New(Survey As cSurvey, Filename As String)
            oSurvey = Survey

            sFilename = Filename.ToLower    'tolower...path is not case sensitive and due to relative path management is better with no capital letter...
            sNote = ""
            oSelected = New List(Of String)
            Call Refresh()
        End Sub

        Public Sub Refresh()
            Try
                oLastException = Nothing
                oLinkedSurvey = New cSurvey
                Dim oResult As cActionResult = oLinkedSurvey.Load(sFilename)
                If Not oResult.Result Then
                    oLastException = New Exception(oResult.ErrorMessage)
                    oLinkedSurvey = Nothing
                End If
            Catch ex As Exception
                oLinkedSurvey = Nothing
                oLastException = ex
            End Try
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

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXMLLinkedSurvey As XmlElement = Document.CreateElement("linkedsurvey")
            Call oXMLLinkedSurvey.SetAttribute("f", sFilename)
            If sNote <> "" Then oXMLLinkedSurvey.SetAttribute("n", sNote)
            If oSelected.Count > 0 Then oXMLLinkedSurvey.SetAttribute("s", String.Join("|", oSelected))
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

        Private Function pExist(ID As String) As Boolean
            If oSurvey.ID = ID Then
                Return True
            Else
                For Each oItem As cLinkedSurvey In oItems
                    If oItem.LinkedSurvey.ID = ID Then
                        Return True
                    End If
                Next
            End If
            Return False
        End Function

        Private Function pExist(Survey As cSurvey) As Boolean
            Return pExist(Survey.ID)
        End Function

        Public Sub Remove(Item As cLinkedSurvey)
            If oItems.Contains(Item) Then
                Call oItems.Remove(Item)
                Call oSurvey.RaiseOnLinkedSurveysRefresh()
            End If
        End Sub

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

        Public Sub Clean()
            Call oItems.Clear()
        End Sub

        Public Sub Refresh()
            Dim iIndex As Integer = 0
            Dim iCount As Integer = oItems.Count
            Dim iStep As Integer = 1 'IIf(iCount > 20, iCount \ 20, 1)
            For Each oItem As cLinkedSurvey In oItems
                iIndex += 1
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart1"), oItem.GetFilename), iIndex / iCount)
                Call oItem.Refresh()
            Next
            Call oSurvey.RaiseOnLinkedSurveysRefresh()
            Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub

        Public Function Add(Filename As String) As cLinkedSurvey
            Dim oItem As cLinkedSurvey = New cLinkedSurvey(oSurvey, Filename)
            If Not IsNothing(oItem.LinkedSurvey) Then
                If Not pExist(oItem.LinkedSurvey.ID) Then
                    Call oItems.Add(oItem)
                    Call oSurvey.RaiseOnLinkedSurveysAdd(oItem)
                    Return oItem
                End If
            End If
            Return Nothing
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal Items As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cLinkedSurvey)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Items.ChildNodes.Count
            Dim iStep As Integer = 1 'IIf(iCount > 20, iCount \ 20, 1)
            For Each oXMLItem As XmlElement In Items.ChildNodes
                iIndex += 1
                Dim sFilename As String = oXMLItem.GetAttribute("f")
                sFilename = modWindow.RelativeToPath(sFilename, IO.Path.GetDirectoryName(File.Filename))
                Call oXMLItem.SetAttribute("f", sFilename)
                If (iIndex Mod iStep) = 0 Then Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, String.Format(modMain.GetLocalizedString("linkedsurveys.textpart1"), IO.Path.GetFileName(sFilename)), iIndex / iCount)
                Dim oItem As cLinkedSurvey = New cLinkedSurvey(oSurvey, oXMLItem)
                Call oItems.Add(oItem)
            Next
            Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.End, "", 0)
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum) As XmlElement
            Dim oXmlItems As XmlElement = Document.CreateElement("linkedsurveys")
            For Each oItem As cLinkedSurvey In oItems
                Dim oXMLItem As XmlElement = oItem.SaveTo(File, Document, oXmlItems, Options)
                Call oXMLItem.SetAttribute("f", modWindow.PathToRelative(oXMLItem.GetAttribute("f"), IO.Path.GetDirectoryName(File.filename)))
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