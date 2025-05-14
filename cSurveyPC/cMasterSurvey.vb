Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView
Imports System.Xml
Imports cSurveyPC.cSurvey.cCaveInfos
Imports cSurveyPC.cSurvey.cSurvey
Imports cSurveyPC.cSurvey.Design.Items
Imports NAudio

Namespace cSurvey.Master
    Public Class cMasterSlave
        Private oSurvey As cSurvey
        Private oUsers As cUsers

        Private oLockInfos As cCaveAndBrancheLockInfos

        Private sMasterID As String
        Private bIsMaster As Boolean

        Private sUserID As String
        Private sSlaveID As String
        Private bIsSlave As Boolean
        Private dSlaveDate As Date

        Public Function IsLocked(Item As Design.cItem) As Boolean
            If bIsMaster OrElse bIsSlave Then
                Dim oCaveInfo As cICaveInfoBranches = Item.GetCaveInfo()
                If IsNothing(oCaveInfo) Then
                    Return False
                Else
                    Return oCaveInfo.GetLocked
                End If
            End If
        End Function
        Public Function IsLocked(Trigpoint As cTrigPoint) As Boolean
            If bIsMaster OrElse bIsSlave Then
                Dim oCaveInfos As HashSet(Of cICaveInfoBranches) = Trigpoint.GetCaveInfos
                If oCaveInfos.Count = 0 Then
                    Return False
                Else
                    Return oCaveInfos.FirstOrDefault(Function(oCaveInfo) oCaveInfo.GetLocked) IsNot Nothing
                End If
            End If
        End Function

        Public Function IsLocked(Segment As cISegment) As Boolean
            If bIsMaster OrElse bIsSlave Then
                Dim oCaveInfo As cICaveInfoBranches = Segment.GetCaveInfo
                If IsNothing(oCaveInfo) Then
                    Return False
                Else
                    Return oCaveInfo.GetLocked
                End If
            End If
        End Function

        Public Function IsMasterOrSlave() As Boolean
            Return bIsMaster OrElse bIsSlave
        End Function

        Friend Function SetAsMaster() As Boolean
            If sMasterID = "" Then
                sMasterID = Guid.NewGuid.ToString
                bIsMaster = True
                Call oSurvey.RaiseOnPropertiesChanged(OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.MasterSlaveSettings)
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Join the slave survey to master keeping it opening
        ''' </summary>
        ''' <param name="Filename"></param>
        Friend Sub PushSlave(Filename As String)

        End Sub

        ''' <summary>
        ''' Join the slave survey to master closing it and freeing locked caves and braches
        ''' </summary>
        ''' <param name="Filename"></param>
        Friend Sub CommitSlave(Filename As String)

        End Sub

        Friend Function CreateSlave(UserID As String, Filename As String) As Boolean

            If sMasterID <> "" And sSlaveID = "" Then
                'verifico che l'utente non sia gia stato slavizzato
                'se si ERRORE
                'se no
                'marco i rami che sono stati associati a questo utente come slavizzati
                'quindi creo un file slave con il marker dell'utente a cui è riservato

                If oUsers.Contains(UserID) Then
                    Dim oUser As cUser = oUsers(UserID)
                    If "" & oUser.LockID = "" Then
                        Dim sLockID As String = oUser.SetLockID
                        oLockInfos.SetLockID(sUserID, sLockID)
                        'TODO 
                        'save survey with user lockid as slave survey
                    Else
                        Throw New Exception("User already locked")
                    End If
                Else
                    Throw New Exception("User not found")
                End If


                'If oUsers.IsUsed(UserID) Then
                '    sUserID = UserID
                '    sSlaveID = Guid.NewGuid.ToString
                '    dSlaveDate = Now
                '    Call oSurvey.RaiseOnPropertiesChanged(OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.MasterSlaveSettings)
                '    Return True
                'Else
                '    Return False
                'End If
            Else
                Return False
            End If
        End Function

        Friend Function IsMaster() As Boolean
            Return bIsMaster
        End Function

        Friend Function IsSlave() As Boolean
            Return bIsMaster AndAlso bIsSlave
        End Function

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oUsers = New cUsers
            oLockInfos = New cCaveAndBrancheLockInfos
            sMasterID = ""
            bIsMaster = False
            sSlaveID = ""
            bIsSlave = False
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal MasterSlave As XmlElement)
            oSurvey = Survey
            sMasterID = modXML.GetAttributeValue(MasterSlave, "masterid", "")
            bIsMaster = sMasterID <> ""
            sSlaveID = modXML.GetAttributeValue(MasterSlave, "slaveid", "")
            If sSlaveID <> "" Then
                bIsSlave = True
                sUserID = modXML.GetAttributeValue(MasterSlave, "userid", "")
                dSlaveDate = modXML.GetAttributeValue(MasterSlave, "slavedate", Now)
            End If
            oUsers = New cUsers(MasterSlave.Item("users"))
            oLockInfos = New cCaveAndBrancheLockInfos(MasterSlave.Item("cavebrancheslockinfos"))
        End Sub

        Public ReadOnly Property Users As cUsers
            Get
                Return oUsers
            End Get
        End Property

        Public ReadOnly Property LockInfos As cCaveAndBrancheLockInfos
            Get
                Return oLockInfos
            End Get
        End Property


        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlMasterSlave As XmlElement = Document.CreateElement("masterslave")
            If sMasterID <> "" Then Call oXmlMasterSlave.SetAttribute("masterid", sMasterID)
            If sSlaveID <> "" Then
                Call oXmlMasterSlave.SetAttribute("slaveid", sSlaveID)
                Call oXmlMasterSlave.SetAttribute("userid", sUserID)
                Call oXmlMasterSlave.SetAttribute("slaveid", dSlaveDate.ToString("O"))
            End If
            Call oUsers.SaveTo(File, Document, oXmlMasterSlave)
            Call oLockInfos.SaveTo(File, Document, oXmlMasterSlave)
            Call Parent.AppendChild(oXmlMasterSlave)
            Return oXmlMasterSlave
        End Function
    End Class

    Public Class cCaveAndBrancheLockInfo
        Private sCave As String
        Private sBranch As String

        Private dDate As Date
        Private sAssignedBy As String
        Private sAssignedTo As String

        Private sLockID As String

        Public ReadOnly Property LockID As String
            Get
                Return sLockID
            End Get
        End Property
        Friend Sub SetLockID(LockID As String)
            sLockID = LockID
        End Sub

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

        Public ReadOnly Property [Date] As Date
            Get
                Return dDate
            End Get
        End Property

        Public ReadOnly Property AssignedBy As String
            Get
                Return sAssignedBy
            End Get
        End Property

        Public ReadOnly Property AssignedTo As String
            Get
                Return sAssignedTo
            End Get
        End Property

        Friend Sub New(CaveAndBranch As XmlElement)
            sCave = CaveAndBranch.GetAttribute("cave")
            sBranch = CaveAndBranch.GetAttribute("branch")
            dDate = CaveAndBranch.GetAttribute("date")
            sAssignedBy = CaveAndBranch.GetAttribute("assignedby")
            sAssignedTo = CaveAndBranch.GetAttribute("assignedto")
            sLockID = modXML.GetAttributeValue(CaveAndBranch, "lockid", "")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLCaveAndBranch As XmlElement = Document.CreateElement("caveandbranch")
            Call oXMLCaveAndBranch.SetAttribute("cave", sCave)
            Call oXMLCaveAndBranch.SetAttribute("branch", sBranch)
            Call oXMLCaveAndBranch.SetAttribute("date", dDate.ToString("O"))
            Call oXMLCaveAndBranch.SetAttribute("assignedby", sAssignedBy)
            Call oXMLCaveAndBranch.SetAttribute("assignedto", sAssignedTo)

            If sLockID <> "" Then Call oXMLCaveAndBranch.SetAttribute("lockid", sLockID)
            Call Parent.AppendChild(oXMLCaveAndBranch)
            Return oXMLCaveAndBranch
        End Function

        Public Sub New(Cave As String, Branch As String, [Date] As Date, AssignedBy As String, AssignedTo As String)
            sCave = Cave
            sBranch = Branch
            dDate = [Date]
            sAssignedBy = AssignedBy
            sAssignedTo = AssignedTo
            sLockID = ""
        End Sub
    End Class

    Public Class cCaveAndBrancheLockInfos
        Implements IEnumerable
        Implements IEnumerable(Of cCaveAndBrancheLockInfo)

        Private oItems As Dictionary(Of String, cCaveAndBrancheLockInfo)

        Friend Sub SetLockID(UserID As String, LockID As String)
            For Each oCaveAndBranch As cCaveAndBrancheLockInfo In oItems.Values
                If oCaveAndBranch.AssignedTo = UserID Then
                    Call oCaveAndBranch.SetLockID(LockID)
                End If
            Next
        End Sub
        Friend Sub New(CaveAndBranches As XmlElement)
            oItems = New Dictionary(Of String, cCaveAndBrancheLockInfo)
            For Each oXMLCaveAndBranch As XmlElement In CaveAndBranches.ChildNodes
                Dim oItem As cCaveAndBrancheLockInfo = New cCaveAndBrancheLockInfo(oXMLCaveAndBranch)
                Call oItems.Add(pGetKey(oItem.Cave, oItem.Branch), oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLCaveAndBranches As XmlElement = Document.CreateElement("cavebrancheslockinfos")
            For Each oItem As cCaveAndBrancheLockInfo In oItems.Values
                Call oItem.SaveTo(File, Document, oXMLCaveAndBranches)
            Next
            Call Parent.AppendChild(oXMLCaveAndBranches)
            Return oXMLCaveAndBranches
        End Function

        Friend Sub New()
            oItems = New Dictionary(Of String, cCaveAndBrancheLockInfo)
        End Sub

        Public Function IsLocked(Cave As cICaveInfoBranches) As Boolean
            Dim sKey As String = pGetKey(Cave.Cave, Cave.Path)
            Return oItems.ContainsKey(sKey)
        End Function

        Public Function IsLocked(Cave As String, Branch As String) As Boolean
            Dim sKey As String = pGetKey(Cave, Branch)
            Return oItems.ContainsKey(sKey)
        End Function

        Public Function GetLockInfo(Cave As cICaveInfoBranches) As cCaveAndBrancheLockInfo
            Dim sKey As String = pGetKey(Cave.Cave, Cave.Path)
            If oItems.ContainsKey(sKey) Then
                Return oItems(sKey)
            Else
                Return Nothing
            End If
        End Function

        Public Function Contains(Cave As cICaveInfoBranches) As Boolean
            Dim sKey As String = pGetKey(Cave.Cave, Cave.Path)
            Return oItems.ContainsKey(sKey)
        End Function

        Public Function Contains(Cave As String, Branch As String) As Boolean
            Return oItems.ContainsKey(pGetKey(Cave, Branch))
        End Function

        Public Function Count() As Integer
            Return oItems.Count
        End Function

        Default Public ReadOnly Property Item(Cave As cICaveInfoBranches) As cCaveAndBrancheLockInfo
            Get
                Dim sKey As String = pGetKey(Cave.Cave, Cave.Path)
                If oItems.ContainsKey(sKey) Then
                    Return oItems(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Default Public ReadOnly Property Item(Cave As String, Branch As String) As cCaveAndBrancheLockInfo
            Get
                Dim sKey As String = pGetKey(Cave, Branch)
                If oItems.ContainsKey(sKey) Then
                    Return oItems(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Friend Function Append(Cave As String, Branch As String, [Date] As Date, AssignedBy As String, AssignedTo As String) As cCaveAndBrancheLockInfo
            Dim oItem As cCaveAndBrancheLockInfo = New cCaveAndBrancheLockInfo(Cave, Branch, [Date], AssignedBy, AssignedTo)
            Call oItems.Add(pGetKey(Cave, Branch), oItem)
            Return oItem
        End Function

        Function pGetKey(Cave As String, Branch As String) As String
            Return Cave & "|" & Branch
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cCaveAndBrancheLockInfo) Implements IEnumerable(Of cCaveAndBrancheLockInfo).GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function
    End Class

    Public Class cUser
        Private sUserID As String

        Private sName As String
        Private sPassword As String
        Private iLevel As Integer

        Private sLockID As String

        Public ReadOnly Property LockID As String
            Get
                Return sLockID
            End Get
        End Property

        Friend Function SetLockID() As String
            sLockID = Guid.NewGuid.ToString
            Return sLockID
        End Function

        'Private oCavesAndBranches As cCaveAndBrancheLockInfos

        Friend Sub New(ByVal User As XmlElement)
            sUserID = User.GetAttribute("userid")
            sName = User.GetAttribute("name")
            sPassword = User.GetAttribute("pwd")
            iLevel = User.GetAttribute("level")
            sLockID = modXML.GetAttributeValue(User, "lockid", "")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLUser As XmlElement = Document.CreateElement("user")
            Call oXMLUser.SetAttribute("userid", sUserID)
            Call oXMLUser.SetAttribute("name", sName)
            Call oXMLUser.SetAttribute("password", sPassword)
            Call oXMLUser.SetAttribute("level", iLevel)

            Call Parent.AppendChild(oXMLUser)
            Return oXMLUser
        End Function

        Friend Sub New(UserID As String, Name As String, Password As String, Level As Integer)
            sUserID = UserID
            sName = Name
            sPassword = modMain.CalculateHash(Password)
            iLevel = Level

            sLockID = ""
        End Sub

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public Function ValidatePassword(Password As String) As Boolean
            Return sPassword = modMain.CalculateHash(Password)
        End Function

        Public ReadOnly Property UserID As String
            Get
                Return sUserID
            End Get
        End Property

        Public ReadOnly Property Level As Integer
            Get
                Return iLevel
            End Get
        End Property
    End Class

    Public Class cUsers
        Implements IEnumerable
        Implements IEnumerable(Of cUser)

        Private oItems As Dictionary(Of String, cUser)

        'Public Function GetCaveAndBranchLockInfo(Cave As String, Branch As String) As cCaveAndBrancheLockInfo
        '    For Each oUser As cUser In oItems.Values
        '        If oUser.CavesAndBranches.Contains(Cave, Branch) Then
        '            Return oUser.CavesAndBranches(Cave, Branch)
        '        End If
        '    Next
        '    Return Nothing
        'End Function

        Public Enum LevelEnum
            Administrator = 0
            User = 1
            Viewer = 2 'future use...
        End Enum

        Public Function ValidateUser(UserID As Integer, Password As String) As Boolean
            If oItems.ContainsKey(UserID) Then
                Return oItems(UserID).ValidatePassword(Password)
            Else
                Return False
            End If
        End Function

        Friend Function Append(UserID As String, Name As String, Password As String, Level As LevelEnum) As cUser
            If oItems.ContainsKey(UserID) Then
                Call oItems.Remove(UserID)
            End If
            Dim oItem As cUser = New cUser(UserID, Name, Password, Level)
            Call oItems.Add(oItem.UserID, oItem)
            Return oItem
        End Function

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLUsers As XmlElement = Document.CreateElement("users")
            For Each oItem As cUser In oItems.Values
                Call oItem.SaveTo(File, Document, oXMLUsers)
            Next
            Call Parent.AppendChild(oXMLUsers)
            Return oXMLUsers
        End Function

        Friend Sub New(ByVal Users As XmlElement)
            oItems = New Dictionary(Of String, cUser)(StringComparer.CurrentCultureIgnoreCase)
            For Each oXMLUser As XmlElement In Users.ChildNodes
                Dim oItem As cUser = New cUser(oXMLUser)
                Call oItems.Add(oItem.UserID, oItem)
            Next
        End Sub

        Friend Sub New()
            oItems = New Dictionary(Of String, cUser)(StringComparer.CurrentCultureIgnoreCase)
        End Sub

        'Friend Function IsUsed(UserID As String) As Boolean
        '    If oItems.ContainsKey(UserID) Then
        '        For Each oUser As cUser In oItems.Values
        '            If oUser.CavesAndBranches.Count > 0 Then
        '                Return True
        '            End If
        '        Next
        '    Else
        '        Return False
        '    End If
        'End Function

        Public Function Contains(UserID As String) As Boolean
            Return oItems.ContainsKey(UserID)
        End Function

        Public Function Count() As Integer
            Return oItems.Count
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Private Function cUser_GetEnumerator() As IEnumerator(Of cUser) Implements IEnumerable(Of cUser).GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Default Public ReadOnly Property Item(UserID As String) As cUser
            Get
                If oItems.ContainsKey(UserID) Then
                    Return oItems(UserID)
                Else
                    Return Nothing
                End If
            End Get
        End Property
    End Class
End Namespace
