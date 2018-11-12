Imports System.Collections.ObjectModel

Namespace cResurvey

    Friend Class cOptions
        Public Enum CalculateModeEnum
            Full = 0
            OnlyPlan = 1
        End Enum

        Private iCalculateMode As CalculateModeEnum
        Private sNordCorrection As Single
        Private bSkipInvalidStation As Boolean
        Private bUseDropForInclination As Boolean

        Private bCalculateLRUD As Boolean
        Private iLRUDBorderWidth As Integer
        Private sLRMaxValue As Single
        Private sUDMaxValue As Single

        Friend Sub New(Optional CalculateMode As CalculateModeEnum = CalculateModeEnum.Full, Optional NordCorrection As Single = 0, Optional SkipInvalidStation As Boolean = True, Optional CalculateLRUD As Boolean = False, Optional LRUDBorderWidth As Integer = 3, Optional LRMaxValue As Single = 5, Optional UDMaxValue As Single = 10)
            iCalculateMode = CalculateMode
            sNordCorrection = NordCorrection
            bSkipInvalidStation = SkipInvalidStation
            bUseDropForInclination = False
            bCalculateLRUD = CalculateLRUD
            iLRUDBorderWidth = LRUDBorderWidth
            sLRMaxValue = LRMaxValue
            sUDMaxValue = UDMaxValue
        End Sub

        Public Sub CopyFrom(Options As cOptions)
            iCalculateMode = Options.iCalculateMode
            sNordCorrection = Options.sNordCorrection
            bSkipInvalidStation = Options.bSkipInvalidStation
            bUseDropForInclination = Options.bUseDropForInclination
            bCalculateLRUD = Options.bCalculateLRUD
            iLRUDBorderWidth = Options.iLRUDBorderWidth
            sLRMaxValue = Options.sLRMaxValue
            sUDMaxValue = Options.sUDMaxValue
        End Sub

        Public Property LRUDBorderWidth As Integer
            Get
                Return iLRUDBorderWidth
            End Get
            Set(value As Integer)
                iLRUDBorderWidth = value
            End Set
        End Property

        Public Property CalculateLRUD As Boolean
            Get
                Return bCalculateLRUD
            End Get
            Set(value As Boolean)
                bCalculateLRUD = value
            End Set
        End Property

        Public Property LRMaxValue As Single
            Get
                Return sLRMaxValue
            End Get
            Set(value As Single)
                sLRMaxValue = value
            End Set
        End Property

        Public Property UDMaxValue As Single
            Get
                Return sUDMaxValue
            End Get
            Set(value As Single)
                sUDMaxValue = value
            End Set
        End Property

        Public Property NordCorrection As Single
            Get
                Return sNordCorrection
            End Get
            Set(value As Single)
                sNordCorrection = value
            End Set
        End Property

        Public Property CalculateMode As CalculateModeEnum
            Get
                Return iCalculateMode
            End Get
            Set(value As CalculateModeEnum)
                iCalculateMode = value
            End Set
        End Property

        Public Property SkipInvalidStation As Boolean
            Get
                Return bSkipInvalidStation
            End Get
            Set(value As Boolean)
                bSkipInvalidStation = value
            End Set
        End Property

        Public Property UseDropForInclination As Boolean
            Get
                Return bUseDropForInclination
            End Get
            Set(value As Boolean)
                bUseDropForInclination = value
            End Set
        End Property
    End Class

    Friend Class cStation
        Public Name As String
        Public PlanPoint As Point
        Public ProfilePoint As Point
        Public PlanConnectedTo As String
        Public ProfileConnectedTo As String
        Public Type As String
        Public Scale As Single

        Public Row As DataGridViewRow
        Public PlanPlaceholder As cTrigpointPlaceholder
        Public ProfilePlaceholder As cTrigpointPlaceholder

        Friend Shared Function GetConnectedToCollection(ConnectedTo As String) As List(Of String)
            Return New List(Of String)(ConnectedTo.Split({";"}, StringSplitOptions.RemoveEmptyEntries))
        End Function

        Friend Shared Function SetConnectedToFromCollection(Coll As List(Of String)) As String
            If Coll.Count > 0 Then
                Return Strings.Join(Coll.ToArray, ";")
            Else
                Return ""
            End If
        End Function

        Public Sub New()
            Name = ""
            Type = ""
            PlanConnectedTo = ""
            ProfileConnectedTo = ""
            Scale = 1
        End Sub
    End Class

    Friend Class cShot
        Public [From] As String
        Public [To] As String
        Public Distance As Decimal
        Public Bearing As Decimal
        Public Inclination As Decimal

        Public Drop As Decimal
        Public PlanimetricDistance As Decimal

        Public Left As Decimal
        Public Right As Decimal
        Public Up As Decimal
        Public Down As Decimal

        Public ProfileProcessed As Boolean
        Public PlanProcessed As Boolean
    End Class

    Friend Class cShots
        Inherits KeyedCollection(Of String, cShot)

        Protected Overrides Function GetKeyForItem(ByVal item As cShot) As String
            Return item.From & vbTab & item.To
        End Function

        Public Shared Function GetKey([From] As String, [To] As String) As String
            Return [From] & vbTab & [To]
        End Function

        Public Shared Function GetKey(Shot As cShot) As String
            Return Shot.[From] & vbTab & Shot.[To]
        End Function

        Public Shared Function GetReversedKey([From] As String, [To] As String) As String
            Return [To] & vbTab & [From]
        End Function

        Public Shared Function GetReversedKey(Shot As cShot) As String
            Return Shot.[To] & vbTab & Shot.[From]
        End Function

        Public Function GetShot([From] As String, [To] As String) As cShot
            Dim sKey As String = GetKey([From], [To])
            If MyBase.Contains(sKey) Then
                Return MyBase.Item(sKey)
            Else
                sKey = GetKey([To], [From])
                If MyBase.Contains(sKey) Then
                    Return MyBase.Item(sKey)
                Else
                    Return Nothing
                End If
            End If
        End Function
    End Class

    Friend Class cTrigpointPlaceholder
        Private iProjection As Integer

        Private oPoint As Point
        Private sName As String

        Private oArea As Rectangle
        Private oHotSpot As Rectangle
        Private oConnections As List(Of cResurvey.cTrigpointPlaceholder)

        Public BackColor As Color
        Public Visible As Boolean

        Public ReadOnly Property Point As Point
            Get
                Return oPoint
            End Get
        End Property

        Public ReadOnly Property Name As String
            Get
                Return sName
            End Get
        End Property

        Public ReadOnly Property Area As Rectangle
            Get
                Return oArea
            End Get
        End Property

        Public ReadOnly Property HotSpot As Rectangle
            Get
                Return oHotSpot
            End Get
        End Property

        Public ReadOnly Property Connections As List(Of cResurvey.cTrigpointPlaceholder)
            Get
                Return oConnections
            End Get
        End Property

        Public ReadOnly Property Projection As Integer
            Get
                Return iProjection
            End Get
        End Property

        Public Sub New(Projection As Integer, Name As String, Point As PointF, Optional NameWidth As Integer = 0)
            iProjection = Projection
            Dim iSize As Integer = 8
            sName = Name
            oPoint = New Point(Point.X, Point.Y)
            oArea = New Rectangle(oPoint.X, oPoint.Y, iSize * 2, iSize * 2)
            oHotSpot = New Rectangle(oPoint.X, oPoint.Y, NameWidth + iSize * 2, iSize * 2)
            oConnections = New List(Of cResurvey.cTrigpointPlaceholder)
            Me.BackColor = Color.DimGray
            Me.Visible = True
        End Sub
    End Class
End Namespace