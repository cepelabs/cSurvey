Imports System.ComponentModel

Namespace cSurvey.UIHelpers

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

    Public Class cSegmentsBindingList
        Private oBindinglist As BindingList(Of cSegment)

        Private WithEvents oSegments As cSegments

        Public Sub New(Segments As cSegments)
            oBindinglist = New BindingList(Of cSegment)
            oSegments = Segments
            For Each oSegment As cSegment In oSegments
                Call oBindinglist.Add(oSegment)
            Next
        End Sub

        Public ReadOnly Property BindingList As BindingList(Of cSegment)
            Get
                Return oBindinglist
            End Get
        End Property

        Private Sub oSegments_OnClear(Sender As cSegments) Handles oSegments.OnClear
            Call oBindinglist.Clear()
        End Sub

        Private Sub oSegments_OnSegmentAppend(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentAppend
            Call oBindinglist.Add(e.Segment)
        End Sub

        Private Sub oSegments_OnSegmentInsert(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentInsert
            Call oBindinglist.Insert(e.Index, e.Segment)
        End Sub

        Private Sub oSegments_OnSegmentRemove(Sender As cSegments, e As cSegments.OnSegmentEventArgs) Handles oSegments.OnSegmentRemove
            Call oBindinglist.Remove(e.Segment)
        End Sub

        Private Sub oSegments_OnSegmentRemoveRange(Sender As cSegments, e As cSegments.OnSegmentsEventArgs) Handles oSegments.OnSegmentRemoveRange
            For Each iIndex As Integer In e.Indexes
                Call oBindinglist.RemoveAt(iIndex)
            Next
        End Sub

        Private Sub oSegments_OnSegmentMove(Sender As cSegments, e As cSegments.OnSegmentMoveEventArgs) Handles oSegments.OnSegmentMove
            Call oBindinglist.RemoveAt(e.OldIndex)
            Call oBindinglist.Insert(e.Index, e.Segment)
        End Sub
    End Class
End Namespace
