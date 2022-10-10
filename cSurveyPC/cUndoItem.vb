'Imports System.Xml
'Imports cSurveyPC.cSurvey
'Imports cSurveyPC.cSurvey.Design
'Imports cSurveyPC.cSurvey.Design.Items
'Imports cSurveyPC.cSurvey.Helper.Editor

'Public Class cUndoItem
'    Private iAction As cUndo.ActionEnum
'    Private sDescription As String
'    Private dDateStamp As Date

'    Private oParent As Object
'    Private iSourceObjectType As cUndo.ObjectTypeEnum
'    Private oSourceData As XmlElement
'    Private iIndex As Integer
'    Private iOldIndex As Integer

'    Public ReadOnly Property Action As cUndo.ActionEnum
'        Get
'            Return iAction
'        End Get
'    End Property

'    Public ReadOnly Property Description As String
'        Get
'            Return sDescription
'        End Get
'    End Property

'    Public ReadOnly Property DateStamp As Date
'        Get
'            Return dDateStamp
'        End Get
'    End Property

'    Friend ReadOnly Property Parent As Object
'        Get
'            Return oParent
'        End Get
'    End Property

'    Friend ReadOnly Property SourceObjectType As cUndo.ObjectTypeEnum
'        Get
'            Return iSourceObjectType
'        End Get
'    End Property

'    Friend ReadOnly Property SourceData As XmlElement
'        Get
'            Return oSourceData
'        End Get
'    End Property

'    Friend ReadOnly Property Index As Integer
'        Get
'            Return iIndex
'        End Get
'    End Property

'    Friend ReadOnly Property OldIndex As Integer
'        Get
'            Return iOldIndex
'        End Get
'    End Property

'    Friend Sub New(Action As cUndo.ActionEnum, Description As String, Parent As Object, SourceObjectType As cUndo.ObjectTypeEnum, SourceData As XmlElement, Index As Integer, OldIndex As Integer)
'        iAction = Action
'        sDescription = Description
'        oParent = Parent
'        dDateStamp = Date.Now
'        iSourceObjectType = SourceObjectType
'        oSourceData = SourceData
'        iIndex = Index
'        iOldIndex = OldIndex
'    End Sub
'End Class
