Imports System.Xml
Imports cSurveyPC.cSurvey.cSurvey

Namespace cSurvey.Master
    Public Class cMasterSlave
        Private oSurvey As cSurvey
        Private oUsers As cUsers

        Private sMasterID As String

        Private sUserID As String
        Private sSlaveID As String
        Private dSlaveDate As Date

        Friend Function SetAsMaster() As Boolean
            If sMasterID = "" Then
                sMasterID = Guid.NewGuid.ToString
                Call oSurvey.RaiseOnPropertiesChanged(OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.MasterSlaveSettings)
                Return True
            Else
                Return False
            End If
        End Function

        Friend Function SetAsSlave(UserID As String) As Boolean
            If sMasterID <> "" And sSlaveID = "" Then
                If oUsers.IsUsed(UserID) Then
                    sUserID = UserID
                    sSlaveID = Guid.NewGuid.ToString
                    dSlaveDate = Now
                    Call oSurvey.RaiseOnPropertiesChanged(OnPropertiesChangedEventArgs.PropertiesChangeSourceEnum.MasterSlaveSettings)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function

        Friend Function IsMaster() As Boolean
            Return sMasterID <> "" AndAlso sSlaveID = ""
        End Function

        Friend Function IsSlave() As Boolean
            Return sMasterID <> "" AndAlso sSlaveID <> ""
        End Function

        Friend Sub New(Survey As cSurvey)
            oSurvey = Survey
            oUsers = New cUsers
            sMasterID = ""
            sSlaveID = ""
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As Storage.cFile, ByVal MasterSlave As XmlElement)
            oSurvey = Survey
            sMasterID = modXML.GetAttributeValue(MasterSlave, "masterid", "")
            sSlaveID = modXML.GetAttributeValue(MasterSlave, "slaveid", "")
            If sSlaveID <> "" Then
                sUserID = modXML.GetAttributeValue(MasterSlave, "userid", "")
                dSlaveDate = modXML.GetAttributeValue(MasterSlave, "slavedate", Now)
            End If
            oUsers = New cUsers(MasterSlave.Item("users"))
        End Sub

        Public ReadOnly Property Users As cUsers
            Get
                Return oUsers
            End Get
        End Property

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlMasterSlave As XmlElement = Document.CreateElement("masterslave")
            If sMasterID <> "" Then Call oXmlMasterSlave.SetAttribute("masterid", sMasterID)
            If sSlaveID <> "" Then
                Call oXmlMasterSlave.SetAttribute("slaveid", sSlaveID)
                Call oXmlMasterSlave.SetAttribute("userid", sUserID)
                Call oXmlMasterSlave.SetAttribute("slaveid", dSlaveDate.ToString("O"))
            End If
            Call oUsers.SaveTo(File, Document, oXmlMasterSlave)
            Call Parent.AppendChild(oXmlMasterSlave)
            Return oXmlMasterSlave
        End Function
    End Class

    Public Class cCaveAndBrancheLockInfo
        Private sCave As String
        Private sBranch As String

        Private dDate As Date
        Private sAssignedBy As String

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

        Friend Sub New(CaveAndBranch As XmlElement)
            sCave = CaveAndBranch.GetAttribute("cave")
            sBranch = CaveAndBranch.GetAttribute("branch")
            dDate = CaveAndBranch.GetAttribute("date")
            sAssignedBy = CaveAndBranch.GetAttribute("assignedby")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLCaveAndBranch As XmlElement = Document.CreateElement("caveandbranch")
            Call oXMLCaveAndBranch.SetAttribute("cave", sCave)
            Call oXMLCaveAndBranch.SetAttribute("branch", sBranch)
            Call oXMLCaveAndBranch.SetAttribute("date", dDate.ToString("O"))
            Call oXMLCaveAndBranch.SetAttribute("assignedby", sAssignedBy)
            Call Parent.AppendChild(oXMLCaveAndBranch)
            Return oXMLCaveAndBranch
        End Function

        Public Sub New(Cave As String, Branch As String, [Date] As Date, AssignedBy As String)
            sCave = Cave
            sBranch = Branch
            dDate = [Date]
            sAssignedBy = AssignedBy
        End Sub
    End Class

    Public Class cCaveAndBrancheLockInfos
        Implements IEnumerable
        Implements IEnumerable(Of cCaveAndBrancheLockInfo)

        Private oItems As Dictionary(Of String, cCaveAndBrancheLockInfo)

        Friend Sub New(CaveAndBranches As XmlElement)
            oItems = New Dictionary(Of String, cCaveAndBrancheLockInfo)
            For Each oXMLCaveAndBranch As XmlElement In CaveAndBranches.ChildNodes
                Dim oItem As cCaveAndBrancheLockInfo = New cCaveAndBrancheLockInfo(oXMLCaveAndBranch)
                Call oItems.Add(pGetKey(oItem.Cave, oItem.Branch), oItem)
            Next
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLCaveAndBranches As XmlElement = Document.CreateElement("cavesandbranches")
            For Each oItem As cCaveAndBrancheLockInfo In oItems.Values
                Call oItem.SaveTo(File, Document, oXMLCaveAndBranches)
            Next
            Call Parent.AppendChild(oXMLCaveAndBranches)
            Return oXMLCaveAndBranches
        End Function

        Friend Sub New()
            oItems = New Dictionary(Of String, cCaveAndBrancheLockInfo)
        End Sub

        Public Function Contains(Cave As String, Branch As String) As Boolean
            Return oItems.ContainsKey(pGetKey(Cave, Branch))
        End Function

        Public Function Count() As Integer
            Return oItems.Count
        End Function

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

        Friend Function Append(Cave As String, Branch As String, [Date] As Date, AssignedBy As String) As cCaveAndBrancheLockInfo
            Dim oItem As cCaveAndBrancheLockInfo = New cCaveAndBrancheLockInfo(Cave, Branch, [Date], AssignedBy)
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

        Private oCavesAndBranches As cCaveAndBrancheLockInfos

        Friend Sub New(ByVal User As XmlElement)
            sUserID = User.GetAttribute("userid")
            sName = User.GetAttribute("name")
            sPassword = User.GetAttribute("pwd")
            iLevel = User.GetAttribute("level")
            oCavesAndBranches = New cCaveAndBrancheLockInfos(User.Item("cavesandbranches"))
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLUser As XmlElement = Document.CreateElement("user")
            Call oXMLUser.SetAttribute("userid", sUserID)
            Call oXMLUser.SetAttribute("name", sName)
            Call oXMLUser.SetAttribute("password", spassword)
            Call oXMLUser.SetAttribute("level", iLevel)
            Call oCavesAndBranches.SaveTo(File, Document, oXMLUser)
            Call Parent.AppendChild(oXMLUser)
            Return oXMLUser
        End Function

        Friend Sub New(UserID As String, Name As String, Password As String, Level As Integer)
            sUserID = UserID
            sName = Name
            sPassword = modMain.CalculateHash(Password)
            iLevel = Level

            oCavesAndBranches = New cCaveAndBrancheLockInfos
        End Sub

        Public ReadOnly Property CavesAndBranches As cCaveAndBrancheLockInfos
            Get
                Return oCavesAndBranches
            End Get

        End Property

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

        Public Function GetCaveAndBranchLockInfo(Cave As String, Branch As String) As cCaveAndBrancheLockInfo
            For Each oUser As cUser In oItems.Values
                If oUser.CavesAndBranches.Contains(Cave, Branch) Then
                    Return oUser.CavesAndBranches(Cave, Branch)
                End If
            Next
            Return Nothing
        End Function

        Public Enum LevelEnum
            Administrator = 0
            User = 1
            Viewer = 2 'future use...
        End Enum

        Public Function ValidateUser(UserID As Integer, Password As String) As Boolean
            If oItems.ContainsKey(UserID) Then
                Return oItems(UserID).validatepassword(Password)
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

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
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

        Friend Function IsUsed(UserID As String) As Boolean
            If oItems.ContainsKey(UserID) Then
                For Each oUser As cUser In oItems.Values
                    If oUser.CavesAndBranches.Count > 0 Then
                        Return True
                    End If
                Next
            Else
                Return False
            End If
        End Function

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
