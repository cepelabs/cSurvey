Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Storage

Namespace cResurvey
    Public Class cFile
        Implements IDisposable

        Private oStorage As cStorage
        Private oDocument As Xml.XmlDocument

        Public Enum FileFormatEnum
            Auto = -1
            CRSZ = 0
            CRSX = 1 'old format
        End Enum

        Public Enum FileOptionsEnum
            [Default] = 0
            [DontSaveBinary] = 1
            [EmbedResource] = 2
        End Enum

        Private sFilename As String
        Private iFileFormat As FileFormatEnum
        Private iOptions As FileOptionsEnum

        Public ReadOnly Property Filename As String
            Get
                Return sFilename
            End Get
        End Property

        Public Sub New(Optional ByVal FileFormat As FileFormatEnum = FileFormatEnum.Auto, Optional Filename As String = "", Optional ByVal Options As FileOptionsEnum = FileOptionsEnum.Default)
            sFilename = Filename
            If FileFormat = FileFormatEnum.Auto Then
                If IO.Path.GetExtension(sFilename).ToLower = ".crsx" Then
                    iFileFormat = FileFormatEnum.CRSX
                Else
                    iFileFormat = FileFormatEnum.CRSZ
                End If
            Else
                iFileFormat = FileFormat
            End If
            iOptions = Options
            Select Case iFileFormat
                Case FileFormatEnum.CRSX
                    oDocument = New Xml.XmlDocument
                Case FileFormatEnum.CRSZ
                    oStorage = New cStorage
                    oDocument = New Xml.XmlDocument
            End Select
        End Sub

        Public ReadOnly Property FileFormat As FileFormatEnum
            Get
                Return iFileFormat
            End Get
        End Property

        Public ReadOnly Property Options As FileOptionsEnum
            Get
                Return iOptions
            End Get
        End Property

        Public Sub New(ByVal Filename As String)
            sFilename = Filename
            If IO.Path.GetExtension(sFilename).ToLower = ".crsx" Then
                iFileFormat = FileFormatEnum.CRSX
                oStorage = Nothing
                oDocument = New Xml.XmlDocument
                Call oDocument.Load(Filename)
            Else
                iFileFormat = FileFormatEnum.CRSZ
                oStorage = New cStorage(sFilename)
                oDocument = New Xml.XmlDocument
                Dim oFile As cStorageItemFile = DirectCast(oStorage("_data.xml"), cStorageItemFile)
                oFile.Stream.Position = 0
                Call oDocument.Load(oFile.Stream)
            End If
        End Sub

        Public Sub Save()
            If sFilename <> "" Then
                Call SaveTo(sFilename)
            Else
                Throw New Exception("Filename is missing")
            End If
        End Sub

        Public Sub SaveTo(ByVal Filename As String)
            sFilename = Filename
            Select Case iFileFormat
                Case FileFormatEnum.CRSX
                    Call oDocument.Save(sFilename)
                Case FileFormatEnum.CRSZ
                    Dim oData As cStorageItemFile = oStorage.AddFile("_data.xml")
                    Call oDocument.Save(oData.Stream)
                    Call oStorage.SaveTo(sFilename)
            End Select
        End Sub

        Public Sub SaveTo(ByVal Stream As System.IO.Stream)
            Select Case iFileFormat
                Case FileFormatEnum.CRSX
                    Call oDocument.Save(Stream)
                Case FileFormatEnum.CRSZ
                    Dim oData As cStorageItemFile = oStorage.AddFile("_data.xml")
                    Call oDocument.Save(oData.Stream)
                    Call oStorage.SaveTo(Stream)
            End Select
        End Sub

        Public ReadOnly Property Data As cStorage
            Get
                Return oStorage
            End Get
        End Property

        Public ReadOnly Property Document As Xml.XmlDocument
            Get
                Return oDocument
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oStorage Is Nothing Then
                        Call oStorage.Dispose()
                        oStorage = Nothing
                    End If
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
        End Sub
#End Region
    End Class

    Friend Class cScale
        Private sPlanScale As Single
        Private sPlanScaleDistance As Single
        Private sProfileScale As Single = 1
        Private sProfileScaleDistance As Single

        Private bPlanError As Boolean
        Private bProfileError As Boolean
        Public ReadOnly Property PlanScaleDistance As Single
            Get
                Return sPlanScaleDistance
            End Get
        End Property

        Public ReadOnly Property PlanScale As Single
            Get
                Return sPlanScale
            End Get
        End Property
        Public ReadOnly Property ProfileScaleDistance As Single
            Get
                Return sProfileScaleDistance
            End Get
        End Property

        Public ReadOnly Property ProfileScale As Single
            Get
                Return sProfileScale
            End Get
        End Property
        Public ReadOnly Property PlanError As Boolean
            Get
                Return bPlanError
            End Get
        End Property
        Public ReadOnly Property ProfileError As Boolean
            Get
                Return bProfileError
            End Get
        End Property

        Public Sub New(PlanScale As Single, PlanScaleDistance As Single, PlanError As Boolean, ProfileScale As Single, ProfileScaleDistance As Single, ProfileError As Boolean)
            sPlanScale = PlanScale
            sPlanScaleDistance = PlanScaleDistance
            bPlanError = PlanError
            sProfileScale = ProfileScale
            sProfileScaleDistance = ProfileScaleDistance
            bProfileError = ProfileError
        End Sub
    End Class

    Friend Class cOptions
        Public Enum CalculateModeEnum
            Full = 0
            OnlyPlan = 1
        End Enum

        Public Enum ScaleTypeEnum
            DeltaX = 0
            DeltaY = 1
            Distance = 2
        End Enum

        Public Enum ProfileTypeEnum
            Extended = 0
            Projected = 1
        End Enum

        Public Enum LRUDStationEnum
            NotManaged = 0
            ToStation = 1
            FromStation = 2
        End Enum

        Private iCalculateMode As CalculateModeEnum
        Private iProfileType As ProfileTypeEnum
        Private sNordCorrection As Single
        Private bSkipInvalidStation As Boolean
        Private bUseDropForInclination As Boolean
        Private iPlanScaleType As ScaleTypeEnum
        Private iDropScaleType As ScaleTypeEnum
        Private iLRUDStation As LRUDStationEnum

        Private bCalculateLRUD As Boolean
        Private iLRUDBorderWidth As Integer
        Private sLRMaxValue As Single
        Private sUDMaxValue As Single

        Friend Sub New(Optional CalculateMode As CalculateModeEnum = CalculateModeEnum.Full, Optional NordCorrection As Single = 0, Optional SkipInvalidStation As Boolean = True, Optional CalculateLRUD As Boolean = False, Optional LRUDBorderWidth As Integer = 3, Optional LRMaxValue As Single = 5, Optional UDMaxValue As Single = 10, Optional PlanScaleType As ScaleTypeEnum = ScaleTypeEnum.DeltaX, Optional DropScaleType As ScaleTypeEnum = ScaleTypeEnum.DeltaY)
            iCalculateMode = CalculateMode
            sNordCorrection = NordCorrection
            bSkipInvalidStation = SkipInvalidStation
            bUseDropForInclination = False
            bCalculateLRUD = CalculateLRUD
            iLRUDBorderWidth = LRUDBorderWidth
            sLRMaxValue = LRMaxValue
            sUDMaxValue = UDMaxValue
            iPlanScaleType = PlanScaleType
            iDropScaleType = DropScaleType
        End Sub

        Public Sub CopyFrom(Options As cOptions)
            iCalculateMode = Options.iCalculateMode
            iProfileType = Options.ProfileType
            sNordCorrection = Options.sNordCorrection
            bSkipInvalidStation = Options.bSkipInvalidStation
            bUseDropForInclination = Options.bUseDropForInclination
            bCalculateLRUD = Options.bCalculateLRUD
            iLRUDBorderWidth = Options.iLRUDBorderWidth
            sLRMaxValue = Options.sLRMaxValue
            sUDMaxValue = Options.sUDMaxValue
            iPlanScaleType = Options.iPlanScaleType
            iDropScaleType = Options.iDropScaleType
            iLRUDStation = Options.iLRUDStation
        End Sub

        Public Property LRUDBorderWidth As Integer
            Get
                Return iLRUDBorderWidth
            End Get
            Set(value As Integer)
                iLRUDBorderWidth = value
            End Set
        End Property

        Public Property LRUDStation As LRUDStationEnum
            Get
                Return iLRUDStation
            End Get
            Set(value As LRUDStationEnum)
                iLRUDStation = value
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

        Public Property ProfileType As ProfileTypeEnum
            Get
                Return iProfileType
            End Get
            Set(value As ProfileTypeEnum)
                iProfileType = value
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

        Public Property PlanScaleType As ScaleTypeEnum
            Get
                Return iPlanScaleType
            End Get
            Set(value As ScaleTypeEnum)
                iPlanScaleType = value
            End Set
        End Property

        Public Property DropScaleType As ScaleTypeEnum
            Get
                Return iDropScaleType
            End Get
            Set(value As ScaleTypeEnum)
                iDropScaleType = value
            End Set
        End Property
    End Class

    Friend Class cLink
        Private sFrom As String
        Private sTo As String

        Private sLeft As Single
        Private sRight As Single
        Private sUp As Single
        Private sDown As Single

        Public Property Left As Single
            Get
                Return sLeft
            End Get
            Set(value As Single)
                sLeft = value
            End Set
        End Property

        Public Property Right As Single
            Get
                Return sRight
            End Get
            Set(value As Single)
                sRight = value
            End Set
        End Property

        Public Property Up As Single
            Get
                Return sUp
            End Get
            Set(value As Single)
                sUp = value
            End Set
        End Property

        Public Property Down As Single
            Get
                Return sDown
            End Get
            Set(value As Single)
                sDown = value
            End Set
        End Property

        Public Function IsTranslation() As Boolean
            Return sFrom.Replace(">", "") = sTo.Replace(">", "")
        End Function

        Friend Sub Change([From] As String, [To] As String)
            sFrom = [From]
            sTo = [To]
        End Sub

        Public ReadOnly Property [To] As String
            Get
                Return sTo
            End Get
        End Property

        Public ReadOnly Property [From] As String
            Get
                Return sFrom
            End Get
        End Property
    End Class

    Friend Class cLinks
        Inherits KeyedCollection(Of String, cLink)

        Protected Overrides Function GetKeyForItem(ByVal item As cLink) As String
            If item.From < item.To Then
                Return item.From & "->" & item.To
            Else
                Return item.To & "->" & item.From
            End If
        End Function
    End Class

    Friend Class cStations
        Inherits KeyedCollection(Of String, cStation)

        Protected Overrides Function GetKeyForItem(ByVal item As cStation) As String
            Return item.Name
        End Function
    End Class

    Friend Class cStation
        Private sName As String
        Private oPlanPoint As Point
        Private oProfilePoint As Point
        Private oPlanConnectedTo As HashSet(Of String)
        Private oProfileConnectedTo As HashSet(Of String)
        Private sType As String
        Private sScale As Single

        'Public Row As DataGridViewRow
        Public PlanPlaceholder As cTrigpointPlaceholder
        Public ProfilePlaceholder As cTrigpointPlaceholder

        Private bPlanVisible As Boolean
        Private bProfileVisible As Boolean

        Public Overrides Function ToString() As String
            Return sName
        End Function

        Public Property ProfileVisible As Boolean
            Get
                Return bProfileVisible
            End Get
            Set(value As Boolean)
                bProfileVisible = value
            End Set
        End Property

        Public Property PlanVisible As Boolean
            Get
                Return bPlanVisible
            End Get
            Set(value As Boolean)
                bPlanVisible = value
            End Set
        End Property

        Public Property PlanPoint As Point
            Get
                Return oPlanPoint
            End Get
            Set(value As Point)
                oPlanPoint = value
            End Set
        End Property

        Public Property ProfilePoint As Point
            Get
                Return oProfilePoint
            End Get
            Set(value As Point)
                oProfilePoint = value
            End Set
        End Property

        Public Property Scale As Single
            Get
                Return sScale
            End Get
            Set(value As Single)
                sScale = value
            End Set
        End Property

        Public Property Type As String
            Get
                Return sType
            End Get
            Set(value As String)
                sType = value
            End Set
        End Property

        Public ReadOnly Property ProfileConnectedTo As HashSet(Of String)
            Get
                Return oProfileConnectedTo
            End Get
        End Property

        Public ReadOnly Property PlanConnectedTo As HashSet(Of String)
            Get
                Return oPlanConnectedTo
            End Get
        End Property

        Public ReadOnly Property PlanConnectedToString() As String
            Get
                Return String.Join(";", oPlanConnectedTo)
            End Get
        End Property

        Public ReadOnly Property ProfileConnectedToString() As String
            Get
                Return String.Join(";", oProfileConnectedTo)
            End Get
        End Property

        Public Property Name As String
            Get
                Return sName
            End Get
            Set(value As String)
                sName = value
            End Set
        End Property

        'Friend Shared Function GetConnectedToCollection(ConnectedTo As String) As List(Of String)
        '    Return New List(Of String)(ConnectedTo.Split({";"}, StringSplitOptions.RemoveEmptyEntries))
        'End Function

        'Friend Shared Function SetConnectedToFromCollection(Coll As List(Of String)) As String
        '    If Coll.Count > 0 Then
        '        Return Strings.Join(Coll.ToArray, ";")
        '    Else
        '        Return ""
        '    End If
        'End Function

        Public Sub New()
            sName = ""
            sType = ""
            oPlanConnectedTo = New HashSet(Of String)
            oProfileConnectedTo = New HashSet(Of String)
            sScale = 1
            bPlanVisible = True
            bProfileVisible = True
        End Sub
    End Class

    Friend Class cShot
        Implements System.ComponentModel.INotifyPropertyChanged

        Public [sFrom] As String
        Public [sTo] As String

        Public ReadOnly Property Key As String
            Get
                Return cShots.GetKey(Me)
            End Get
        End Property

        Public Property [From] As String
            Get
                Return sFrom
            End Get
            Set(value As String)
                sFrom = value
            End Set
        End Property

        Public Property [To] As String
            Get
                Return sTo
            End Get
            Set(value As String)
                sTo = value
            End Set
        End Property

        Public Sub Restore(Shot As cShot)
            dUserLeft = Shot.UserLeft
            dUserRight = Shot.UserRight
            dUserUp = Shot.UserUp
            dUserDown = Shot.UserDown
        End Sub

        Private dDistance As Decimal
        Private dBearing As Decimal
        Private dInclination As Decimal

        Public Property Inclination As Decimal
            Get
                Return dInclination
            End Get
            Set(value As Decimal)
                dInclination = value
            End Set
        End Property

        Public Property Bearing As Decimal
            Get
                Return dBearing
            End Get
            Set(value As Decimal)
                dBearing = value
            End Set
        End Property

        Public Property Distance As Decimal
            Get
                Return dDistance
            End Get
            Set(value As Decimal)
                dDistance = value
            End Set
        End Property

        Private dDrop As Decimal
        Private dPlanimetricDistance As Decimal

        Public Property Drop As Decimal
            Get
                Return dDrop
            End Get
            Set(value As Decimal)
                dDrop = value
            End Set
        End Property

        Public Property PlanimetricDistance As Decimal
            Get
                Return dPlanimetricDistance
            End Get
            Set(value As Decimal)
                dPlanimetricDistance = value
            End Set
        End Property

        Private dUserLeft As Decimal?
        Private dUserRight As Decimal?
        Private dUserUp As Decimal?
        Private dUserDown As Decimal?

        Public Property EditUserUp() As Decimal?
            Get
                If dUserUp.HasValue Then
                    Return dUserUp.Value
                Else
                    Return dUp
                End If
            End Get
            Set(value As Decimal?)
                If value.HasValue Then
                    If value.Value <> dUserUp.GetValueOrDefault(0) Then
                        dUserUp = value.Value
                    End If
                Else
                    dUserUp = Nothing
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("edituserup"))
            End Set
        End Property

        Public Property EditUserDown() As Decimal?
            Get
                If dUserDown.HasValue Then
                    Return dUserDown.Value
                Else
                    Return dDown
                End If
            End Get
            Set(value As Decimal?)
                If value.HasValue Then
                    If value.Value <> dUserDown.GetValueOrDefault(0) Then
                        dUserDown = value.Value
                    End If
                Else
                    dUserDown = Nothing
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("edituserdown"))
            End Set
        End Property

        Public Property EditUserRight() As Decimal?
            Get
                If dUserRight.HasValue Then
                    Return dUserRight.Value
                Else
                    Return dRight
                End If
            End Get
            Set(value As Decimal?)
                If value.HasValue Then
                    If value.Value <> dUserRight.GetValueOrDefault(0) Then
                        dUserRight = value.Value
                    End If
                Else
                    dUserRight = Nothing
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("edituserright"))
            End Set
        End Property

        Public Property EditUserLeft() As Decimal?
            Get
                If dUserLeft.HasValue Then
                    Return dUserLeft.Value
                Else
                    Return dLeft
                End If
            End Get
            Set(value As Decimal?)
                If value.HasValue Then
                    If value.Value <> dUserLeft.GetValueOrDefault(0) Then
                        dUserLeft = value.Value
                    End If
                Else
                    dUserLeft = Nothing
                End If
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("edituserleft"))
            End Set
        End Property

        Public Property UserUp As Decimal?
            Get
                Return dUserUp
            End Get
            Set(value As Decimal?)
                dUserUp = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("userup"))
            End Set
        End Property

        Public Property UserDown As Decimal?
            Get
                Return dUserDown
            End Get
            Set(value As Decimal?)
                dUserDown = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("userdown"))
            End Set
        End Property

        Public Property UserRight As Decimal?
            Get
                Return dUserRight
            End Get
            Set(value As Decimal?)
                dUserRight = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("userright"))
            End Set
        End Property

        Public Property UserLeft As Decimal?
            Get
                Return dUserLeft
            End Get
            Set(value As Decimal?)
                dUserLeft = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("userleft"))
            End Set
        End Property

        Public ReadOnly Property GetLeft() As Decimal
            Get
                If dUserLeft.HasValue Then
                    Return dUserLeft.Value
                Else
                    Return dLeft
                End If
            End Get
        End Property

        Public ReadOnly Property GetRight() As Decimal
            Get
                If dUserRight.HasValue Then
                    Return dUserRight.Value
                Else
                    Return dRight
                End If
            End Get
        End Property

        Public ReadOnly Property GetUp() As Decimal
            Get
                If dUserUp.HasValue Then
                    Return dUserUp.Value
                Else
                    Return dUp
                End If
            End Get
        End Property

        Public ReadOnly Property GetDown() As Decimal
            Get
                If dUserDown.HasValue Then
                    Return dUserDown.Value
                Else
                    Return dDown
                End If
            End Get
        End Property

        Private dLeft As Decimal
        Private dRight As Decimal
        Private dUp As Decimal
        Private dDown As Decimal

        Public Property Up As Decimal
            Get
                Return dUp
            End Get
            Set(value As Decimal)
                dUp = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("up"))
            End Set
        End Property

        Public Property Down As Decimal
            Get
                Return dDown
            End Get
            Set(value As Decimal)
                dDown = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("down"))
            End Set
        End Property

        Public Property Right As Decimal
            Get
                Return dRight
            End Get
            Set(value As Decimal)
                dRight = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("right"))
            End Set
        End Property

        Public Property Left As Decimal
            Get
                Return dLeft
            End Get
            Set(value As Decimal)
                dLeft = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("left"))
            End Set
        End Property

        Public ProfileProcessed As Boolean
        Public PlanProcessed As Boolean
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Public Sub New()

        End Sub

        Public Sub New([From] As String, [To] As String)
            sFrom = [From]
            sTo = [To]
        End Sub
    End Class

    Friend Class cShots
        Inherits KeyedCollection(Of String, cShot)

        Public Overloads Function Contains(Line() As cTrigpointPlaceholder)
            Return MyBase.Contains(GetKey(Line(0).Name, Line(1).Name))
        End Function

        Default Public Overloads ReadOnly Property Item(Line() As cTrigpointPlaceholder) As cShot
            Get
                Return MyBase.Item(GetKey(Line(0).Name, Line(1).Name))
            End Get
        End Property

        Public Sub New()
            Call MyBase.New
        End Sub

        Public Sub New(Shots As cShots)
            Call MyBase.New
            For Each oShot As cShot In Shots
                Call MyBase.Add(oShot)
            Next
        End Sub

        Public Shared Function IsTranslation(Station As String) As Boolean
            Return Station.EndsWith(">")
        End Function

        Public Shared Function RealStation(Station As String) As String
            Return Station.Replace(">", "")
        End Function

        Public Shared Function GetKey([From] As String, [To] As String) As String
            If IsTranslation([From]) AndAlso IsTranslation([To]) Then
                Return ""
            Else
                Dim sFrom As String = RealStation(From)
                Dim sTo As String = RealStation([To])
                If sFrom = sTo Then
                    Return ""
                Else
                    If sFrom < sTo Then
                        Return sFrom & vbTab & sTo
                    Else
                        Return sTo & vbTab & sFrom
                    End If
                End If
            End If
        End Function

        Public Shared Function GetKey(ByVal item As cShot) As String
            Return GetKey(item.From, item.To)
        End Function

        Protected Overrides Function GetKeyForItem(ByVal item As cShot) As String
            Return GetKey(item.From, item.To)
        End Function

        Public Function GetShot([From] As String, [To] As String) As cShot
            Dim sKey As String = GetKey([From], [To])
            If MyBase.Contains(sKey) Then
                Return MyBase.Item(sKey)
            Else
                Return Nothing
            End If
        End Function
    End Class

    Friend Class cCacheItem
        Implements IDisposable

        Private sStation As String
        Private oShotPath As System.Drawing.Drawing2D.GraphicsPath
        Private oLRUDPath As System.Drawing.Drawing2D.GraphicsPath
        Private oLRUDAreaPath As System.Drawing.Drawing2D.GraphicsPath

        Public Sub New(Station As String, ShotPath As GraphicsPath, LRUDPath As System.Drawing.Drawing2D.GraphicsPath, LRUDAreaPath As System.Drawing.Drawing2D.GraphicsPath)
            sStation = Station
            oShotPath = ShotPath.Clone
            oLRUDPath = LRUDPath.Clone
            oLRUDAreaPath = LRUDAreaPath.Clone
        End Sub

        Public Sub New(Station As String, ShotPath As GraphicsPath)
            sStation = Station
            oShotPath = ShotPath.Clone
            oLRUDPath = Nothing
        End Sub

        Public Sub SetPath(ShotPath As GraphicsPath, LRUDPath As System.Drawing.Drawing2D.GraphicsPath, LRUDAreaPath As System.Drawing.Drawing2D.GraphicsPath)
            If Not ShotPath Is Nothing Then oShotPath = ShotPath.Clone
            If Not LRUDPath Is Nothing Then oLRUDPath = LRUDPath.Clone
            If Not LRUDAreaPath Is Nothing Then oLRUDAreaPath = LRUDAreaPath.Clone
        End Sub

        Public ReadOnly Property Station As String
            Get
                Return sStation
            End Get
        End Property

        Public ReadOnly Property LRUDPath As GraphicsPath
            Get
                Return oLRUDPath
            End Get
        End Property

        Public ReadOnly Property ShotPath As GraphicsPath
            Get
                Return oShotPath
            End Get
        End Property

        Public ReadOnly Property LRUDAreaPath As GraphicsPath
            Get
                Return oLRUDAreaPath
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oShotPath Is Nothing Then
                        Call oShotPath.Dispose()
                        oShotPath = Nothing
                    End If
                    If Not oLRUDPath Is Nothing Then
                        Call oLRUDPath.Dispose()
                        oLRUDPath = Nothing
                    End If
                End If
            End If
            disposedValue = True
        End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
        End Sub
#End Region
    End Class

    Friend Class cCache
        Implements IDisposable

        Private oPlanStationPath As GraphicsPath
        Private oPlanLabelPath As GraphicsPath

        Private oProfileStationPath As GraphicsPath
        Private oProfileLabelPath As GraphicsPath

        Private oLabel As GraphicsPath

        Private oPlanShots As Dictionary(Of String, cCacheItem)
        Private oProfileShots As Dictionary(Of String, cCacheItem)

        Public Shared Function GetPlanLineBound(Line As cResurvey.cTrigpointPlaceholder()) As RectangleF
            Using oPath As GraphicsPath = New GraphicsPath
                If Not Line(0).Cache.oPlanStationPath Is Nothing Then oPath.AddRectangle(Line(0).Cache.oPlanStationPath.GetBounds)
                'If Not Line(0).Cache.oPlanLRUDPath Is Nothing Then oPath.AddRectangle(Line(0).Cache.oPlanLRUDPath.GetBounds)
                If Not Line(1).Cache.oPlanStationPath Is Nothing Then oPath.AddRectangle(Line(1).Cache.oPlanStationPath.GetBounds)
                'If Not Line(1).Cache.oPlanLRUDPath Is Nothing Then oPath.AddRectangle(Line(1).Cache.oPlanLRUDPath.GetBounds)
                Return oPath.GetBounds
            End Using
        End Function

        Public Shared Function GetProfileLineBound(Line As cResurvey.cTrigpointPlaceholder()) As RectangleF
            Using oPath As GraphicsPath = New GraphicsPath
                If Not Line(0).Cache.oProfileStationPath Is Nothing Then oPath.AddRectangle(Line(0).Cache.oProfileStationPath.GetBounds)
                'If Not Line(0).Cache.oProfileLRUDPath Is Nothing Then oPath.AddRectangle(Line(0).Cache.oProfileLRUDPath.GetBounds)
                If Not Line(1).Cache.oProfileStationPath Is Nothing Then oPath.AddRectangle(Line(1).Cache.oProfileStationPath.GetBounds)
                'If Not Line(1).Cache.oProfileLRUDPath Is Nothing Then oPath.AddRectangle(Line(1).Cache.oProfileLRUDPath.GetBounds)
                Return oPath.GetBounds
            End Using
        End Function

        Public Sub New()
            oPlanShots = New Dictionary(Of String, cCacheItem)
            oProfileShots = New Dictionary(Of String, cCacheItem)
        End Sub

        Public Function AddProfileShot(Station As String, ShotPath As GraphicsPath) As cCacheItem
            If oProfileShots.ContainsKey(Station) Then oProfileShots.Remove(Station)
            Dim oItem As cCacheItem = New cCacheItem(Station, ShotPath)
            Call oProfileShots.Add(Station, oItem)
            Return oItem
        End Function

        Public Function AddPlanShot(Station As String, ShotPath As GraphicsPath) As cCacheItem
            If oPlanShots.ContainsKey(Station) Then oPlanShots.Remove(Station)
            Dim oItem As cCacheItem = New cCacheItem(Station, ShotPath)
            Call oPlanShots.Add(Station, oItem)
            Return oItem
        End Function

        Public ReadOnly Property ProfileShots As Dictionary(Of String, cCacheItem)
            Get
                Return oProfileShots
            End Get
        End Property

        Public ReadOnly Property PlanShots As Dictionary(Of String, cCacheItem)
            Get
                Return oPlanShots
            End Get
        End Property

        Public Sub SetLabelPath(Label As GraphicsPath)
            If Not Label Is Nothing Then oLabel = Label
        End Sub

        Public Sub SetPlanPath(PlanStationPath As GraphicsPath, PlanLabelPath As GraphicsPath)
            If Not PlanStationPath Is Nothing Then oPlanStationPath = PlanStationPath.Clone
            If Not PlanLabelPath Is Nothing Then oPlanLabelPath = PlanLabelPath.Clone
        End Sub

        Public Sub SetProfilePath(ProfileStationPath As GraphicsPath, ProfileLabelPath As GraphicsPath)
            If Not ProfileStationPath Is Nothing Then oProfileStationPath = ProfileStationPath.Clone
            If Not ProfileLabelPath Is Nothing Then oProfileLabelPath = ProfileLabelPath.Clone
        End Sub

        Public ReadOnly Property ProfileLabelPath As GraphicsPath
            Get
                Return oProfileLabelPath
            End Get
        End Property

        Public ReadOnly Property PlanLabelPath As GraphicsPath
            Get
                Return oPlanLabelPath
            End Get
        End Property

        Public ReadOnly Property PlanStationPath As GraphicsPath
            Get
                Return oPlanStationPath
            End Get
        End Property

        Public ReadOnly Property ProfileStationPath As GraphicsPath
            Get
                Return oProfileStationPath
            End Get
        End Property

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Not oPlanStationPath Is Nothing Then
                        oPlanStationPath.Dispose()
                        oPlanStationPath = Nothing
                    End If
                    If Not oPlanLabelPath Is Nothing Then
                        oPlanLabelPath.Dispose()
                        oPlanLabelPath = Nothing
                    End If

                    If Not oProfileStationPath Is Nothing Then
                        oProfileStationPath.Dispose()
                        oProfileStationPath = Nothing
                    End If
                    If Not oProfileLabelPath Is Nothing Then
                        oProfileLabelPath.Dispose()
                        oProfileLabelPath = Nothing
                    End If
                    For Each oItem As cCacheItem In oPlanShots.Values
                        Call oItem.Dispose()
                    Next
                    Call oPlanShots.Clear()
                    For Each oItem As cCacheItem In oProfileShots.Values
                        Call oItem.Dispose()
                    Next
                    Call oProfileShots.Clear()
                End If
            End If
            disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
        End Sub

#End Region
    End Class

    Friend Class cTrigpointPlaceholder
        Private iProjection As Integer

        Private oPoint As Point
        Private sName As String

        Private oArea As Rectangle
        Private oHotSpot As Rectangle
        'Private oConnections As List(Of cResurvey.cTrigpointPlaceholder)
        Private oCache As cCache

        Public BackColor As Color

        Friend ReadOnly Property Cache As cCache
            Get
                Return oCache
            End Get
        End Property

        Friend Sub MovePoint(X As Integer, Y As Integer)
            oPoint = oPoint + New Size(X, Y)
            oArea = New Rectangle(oPoint.X, oPoint.Y, oArea.Width, oArea.Height)
            oHotSpot = New Rectangle(oPoint.X, oPoint.Y, oHotSpot.Width, oHotSpot.Height)
            'oArea = New Rectangle(oPoint.X, oPoint.Y, iSize * 2, iSize * 2)
            'oHotSpot = New Rectangle(oPoint.X, oPoint.Y, NameWidth + iSize * 2, iSize * 2)
        End Sub

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

        'Public ReadOnly Property Connections As List(Of cResurvey.cTrigpointPlaceholder)
        '    Get
        '        Return oConnections
        '    End Get
        'End Property

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
            Me.BackColor = Color.DimGray
            oCache = New cCache
        End Sub
    End Class
End Namespace