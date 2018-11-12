Imports cSurveyPC.cSurvey
'Imports ProjNet.CoordinateSystems
'Imports ProjNet.CoordinateSystems.Transformations

Module modUTM
    Public Structure UTM
        Public Band As String
        Public Zone As Integer
        Public East As Decimal
        Public North As Decimal

        Public Shared Widening Operator CType(ByVal p As UTM) As PointD
            Return New PointD(p.East, p.North)
        End Operator

        Public Shared Widening Operator CType(ByVal p As UTM) As System.Drawing.PointF
            Return New PointF(p.East, p.North)
        End Operator

        Friend Sub New(UTM As UTM)
            Me.Band = UTM.Band
            Me.Zone = UTM.Zone
            Me.East = UTM.East
            Me.North = UTM.North
        End Sub

        Friend Sub New(UTM As GeoUtility.GeoSystem.UTM)
            Me.Band = UTM.Band
            Me.Zone = UTM.Zone
            Me.East = UTM.East
            Me.North = UTM.North
        End Sub

        Friend Sub New(Band As String, Zone As Integer, East As Decimal, North As Decimal)
            Me.Band = Band
            Me.Zone = Zone
            Me.East = East
            Me.North = North
        End Sub

        Friend Sub New(Coordinate As cCoordinate)
            If Coordinate.System = "WGS84/UTM" Then
                Me.Band = Coordinate.Band
                Me.Zone = Coordinate.Zone
                Me.East = Coordinate.X
                Me.North = Coordinate.Y
            Else
                Dim oUTM As UTM = modUTM.WGS84ToUTM(Coordinate)
                Me.Band = oUTM.Band
                Me.Zone = oUTM.Zone
                Me.East = oUTM.East
                Me.North = oUTM.North
            End If
        End Sub

        Friend Sub New(Coordinate As Calculate.cTrigPointCoordinate)
            Dim oUTM As UTM = modUTM.WGS84ToUTM(Coordinate)
            Me.Band = oUTM.Band
            Me.Zone = oUTM.Zone
            Me.East = oUTM.East
            Me.North = oUTM.North
        End Sub
    End Structure

    Public Structure WGS84
        Public Longitude As Decimal
        Public Latitude As Decimal

        Friend Sub New(Coordinate As cCoordinate)
            Me.Longitude = Coordinate.GetLongitude
            Me.Latitude = Coordinate.GetLatitude
        End Sub

        Friend Sub New(Coordinate As Calculate.cTrigPointCoordinate)
            Me.Longitude = Coordinate.Longitude
            Me.Latitude = Coordinate.Latitude
        End Sub

        Friend Sub New(WGS84 As WGS84)
            Me.Longitude = WGS84.Longitude
            Me.Latitude = WGS84.Latitude
        End Sub

        Friend Sub New(WGS84 As GeoUtility.GeoSystem.Geographic)
            Me.Longitude = WGS84.Longitude
            Me.Latitude = WGS84.Latitude
        End Sub

        Friend Sub New(ByVal Longitude As Decimal, Latitude As Decimal)
            Me.Longitude = Longitude
            Me.Latitude = Latitude
        End Sub
    End Structure

    Public Function GetUTMZone(ByVal Coordinate As cCoordinate) As Integer
        Return GetUTMZone(Coordinate.GetLongitude, Coordinate.GetLatitude)
    End Function

    Public Function GetUTMBand(ByVal Coordinate As cCoordinate) As String
        Return GetUTMBand(Coordinate.GetLongitude, Coordinate.GetLatitude)
    End Function

    Public Function GetUTMZone(ByVal Longitude As Decimal, ByVal Latitude As Decimal) As Integer
        Dim oGeo As GeoUtility.GeoSystem.Geographic = New GeoUtility.GeoSystem.Geographic(Longitude, Latitude, GeoUtility.GeoSystem.Helper.GeoDatum.WGS84)
        Dim oUtm As GeoUtility.GeoSystem.UTM = oGeo
        Return oUtm.Zone
    End Function

    Public Function WGS84ToUTM(WGS84 As WGS84) As UTM
        Return WGS84ToUTM(WGS84.Longitude, WGS84.Latitude)
    End Function

    Public Function WGS84ToUTM(ByVal Coordinate As cCoordinate) As UTM
        Return WGS84ToUTM(Coordinate.GetLongitude, Coordinate.GetLatitude)
    End Function

    Public Function WGS84ToUTM(ByVal Coordinate As Calculate.cTrigPointCoordinate) As UTM
        Return WGS84ToUTM(Coordinate.Longitude, Coordinate.Latitude)
    End Function

    Public Function WGS84ToUTM(ByVal Longitude As Decimal, ByVal Latitude As Decimal) As UTM
        Dim oGeo As GeoUtility.GeoSystem.Geographic = New GeoUtility.GeoSystem.Geographic(Longitude, Latitude, GeoUtility.GeoSystem.Helper.GeoDatum.WGS84)
        Dim oUtm As GeoUtility.GeoSystem.UTM = oGeo
        Return New UTM(oGeo)
        'Dim oFactory As CoordinateTransformationFactory = New CoordinateTransformationFactory
        'Dim iZone As String = GetUTMZone(Longitude, Latitude)
        'Dim sBand As String = GetUTMBand(Longitude, Latitude)
        'Dim oTrasform As ICoordinateTransformation = oFactory.CreateFromCoordinateSystems(GeographicCoordinateSystem.WGS84, ProjectedCoordinateSystem.WGS84_UTM(iZone, Latitude > 0))
        'Dim oSource As Double() = {Longitude, Latitude}
        'Dim oResult As Double() = oTrasform.MathTransform.Transform(oSource)
        'Return New UTM(sBand, iZone, oResult(0), oResult(1))
    End Function

    Public Function UTMToWGS84(Zone As Integer, Band As String, ByVal East As Decimal, ByVal North As Decimal) As WGS84
        'Dim oFactory As CoordinateTransformationFactory = New CoordinateTransformationFactory
        'Dim oTrasform As ICoordinateTransformation = oFactory.CreateFromCoordinateSystems(ProjectedCoordinateSystem.WGS84_UTM(Zone, North > 0), GeographicCoordinateSystem.WGS84)
        'Dim oSource As Double() = {East, North}
        'Dim oResult As Double() = oTrasform.MathTransform.Transform(oSource)
        'Return New WGS84(oResult(0), oResult(1))
        Dim oUtm As GeoUtility.GeoSystem.UTM = New GeoUtility.GeoSystem.UTM(Zone, Band, East, North)
        Dim oGeo As GeoUtility.GeoSystem.Geographic = oUtm
        Return New WGS84(oGeo)
    End Function

    Public Function UTMToWGS84(UTM As UTM) As WGS84
        Return UTMToWGS84(UTM.Zone, UTM.Band, UTM.East, UTM.North)
    End Function

    Public Function UTMToWGS84(ByVal Coordinate As cCoordinate) As WGS84
        Return UTMToWGS84(Coordinate.Zone, Coordinate.Band, Coordinate.x, Coordinate.y)
    End Function

    Public Function GetUTMBand(ByVal Longitude As Decimal, ByVal Latitude As Decimal) As String
        Dim oGeo As GeoUtility.GeoSystem.Geographic = New GeoUtility.GeoSystem.Geographic(Longitude, Latitude, GeoUtility.GeoSystem.Helper.GeoDatum.WGS84)
        Dim oUtm As GeoUtility.GeoSystem.UTM = oGeo
        Return oUtm.Band
    End Function

    Public Function GetCenterZoneDegrees(ByVal Zone As Integer) As Integer
        Dim iStart As Integer = -1 * (180 - 6 * (Zone - 1))
        'Dim iEnd As Integer = 180 - 6 * Fuse
        Return iStart + 3
    End Function

    Public Function GetMeridianConvergence(ByVal Coordinate As cCoordinate) As Decimal
        Return GetMeridianConvergence(Coordinate.GetLongitude, Coordinate.GetLatitude)
    End Function

    Public Function GetMeridianConvergence(ByVal Longitude As Decimal, ByVal Latitude As Decimal) As Decimal
        Return modPaint.RadiansToDegree(Math.Atan(Math.Sin(modPaint.DegreeToRadians(Latitude)) * Math.Tan(modPaint.DegreeToRadians(Longitude - GetCenterZoneDegrees(GetUTMZone(Longitude, Latitude))))))
    End Function

End Module

