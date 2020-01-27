Imports cSurveyPC.cSurvey.cSurvey
Imports System.Xml

Namespace cSurvey.Calculate.Plot
    Public Class cData
        Private oSourceData As cSpatialData
        Private oOldData As cSpatialData
        Private oData As cSpatialData

        Private oSegmentColor As Color
        Private oGroup As cSegmentGroup
        Private iOrdinalPosition As Integer

        Private oPlan As cPlanProjectedData
        Private oProfile As cProfileProjectedData

        Private oSubDatas As cSubDatas

        Private bIsInRing As Boolean

        Public Interface cIWarpingFactor
            ReadOnly Property DeltaSize As Single
            ReadOnly Property DeltaAngle As Single
            ReadOnly Property DeltaX As Single
            ReadOnly Property DeltaY As Single
            Function IsChanged() As Boolean
        End Interface

        Public Class cPlanWarpingFactor
            Implements cIWarpingFactor
            Private sDeltaSize As Single
            Private sDeltaX As Single
            Private sDeltaY As Single
            Private sDeltaAngle As Single

            Private sOldSize As Single
            Private sNewSize As Single
            Private sOldAngle As Single
            Private sNewAngle As Single
            Private oOldLocation As PointF
            Private oNewLocation As PointF

            Public Sub Translate(Size As SizeF)
                sDeltaX += Size.Width
                sDeltaY += Size.Height
                oNewLocation += Size
            End Sub

            Friend Function GetMatrix(OldPlanWarpingFactor As cPlanWarpingFactor) As Drawing2D.Matrix
                Dim oMatrix As Drawing2D.Matrix = New Drawing2D.Matrix
                Call oMatrix.Translate(-OldPlanWarpingFactor.OldLocation.X, -OldPlanWarpingFactor.OldLocation.Y, Drawing2D.MatrixOrder.Append)
                If sOldAngle <> 0 Then
                    Call oMatrix.Rotate(OldPlanWarpingFactor.OldAngle, Drawing2D.MatrixOrder.Append)
                End If
                Dim sDeltaSize As Single = sNewSize / OldPlanWarpingFactor.OldSize
                If sDeltaSize <> 1 Then
                    Call oMatrix.Scale(sDeltaSize, 1, Drawing2D.MatrixOrder.Append)
                End If
                If sNewAngle <> 0 Then
                    Call oMatrix.Rotate(-sNewAngle, Drawing2D.MatrixOrder.Append)
                End If
                Call oMatrix.Translate(oNewLocation.X, oNewLocation.Y, Drawing2D.MatrixOrder.Append)
                Return oMatrix
            End Function

            Friend Function GetMatrix() As Drawing2D.Matrix
                Dim oMatrix As Drawing2D.Matrix = New Drawing2D.Matrix
                Call oMatrix.Translate(-oOldLocation.X, -oOldLocation.Y, Drawing2D.MatrixOrder.Append)
                If sOldAngle <> 0 Then
                    Call oMatrix.Rotate(sOldAngle, Drawing2D.MatrixOrder.Append)
                End If
                If sDeltaSize <> 1 Then
                    Call oMatrix.Scale(sDeltaSize, 1, Drawing2D.MatrixOrder.Append)
                End If
                If sNewAngle <> 0 Then
                    Call oMatrix.Rotate(-sNewAngle, Drawing2D.MatrixOrder.Append)
                End If
                Call oMatrix.Translate(oNewLocation.X, oNewLocation.Y, Drawing2D.MatrixOrder.Append)
                Return oMatrix
            End Function

            Public ReadOnly Property DeltaSize As Single Implements cIWarpingFactor.DeltaSize
                Get
                    Return sDeltaSize
                End Get
            End Property

            Public ReadOnly Property DeltaAngle As Single Implements cIWarpingFactor.DeltaAngle
                Get
                    Return sDeltaAngle
                End Get
            End Property

            Public ReadOnly Property DeltaX As Single Implements cIWarpingFactor.DeltaX
                Get
                    Return sDeltaX
                End Get
            End Property

            Public ReadOnly Property DeltaY As Single Implements cIWarpingFactor.DeltaY
                Get
                    Return sDeltaY
                End Get
            End Property

            Public Function IsChanged() As Boolean Implements cIWarpingFactor.IsChanged
                Return sDeltaSize <> 1 OrElse sDeltaX <> 0 OrElse sDeltaY <> 0 OrElse sDeltaAngle <> 0
            End Function

            Public Sub New(OldSegment As cISegment, NewSegment As cISegment)
                Call pNew(OldSegment.Data.Plan.GetLine, NewSegment.Data.Plan.GetLine, OldSegment.Data.Data.Bearing, NewSegment.Data.Data.Bearing)
            End Sub

            Private Sub pNew(OldLine As PointF(), NewLine As PointF(), OldAngle As Single, NewAngle As Single)
                oOldLocation = OldLine(0)
                oNewLocation = NewLine(0)
                sNewSize = Math.Sqrt((oNewLocation.X - NewLine(1).X) ^ 2 + (oNewLocation.Y - NewLine(1).Y) ^ 2)
                sOldSize = Math.Sqrt((oOldLocation.X - OldLine(1).X) ^ 2 + (oOldLocation.Y - OldLine(1).Y) ^ 2)
                sDeltaX = Math.Round(oNewLocation.X - oOldLocation.X, 3)
                sDeltaY = Math.Round(oNewLocation.Y - oOldLocation.Y, 3)
                If sOldSize = 0 Then
                    sDeltaSize = 1
                Else
                    sDeltaSize = modNumbers.MathRound(sNewSize / sOldSize, 3)
                End If
                sOldAngle = Math.Round(OldAngle, 3)
                sNewAngle = Math.Round(NewAngle, 3)
                sDeltaAngle = sNewAngle - sOldAngle
            End Sub

            Public Sub New(OldLine As PointF(), NewLine As PointF(), OldAngle As Single, NewAngle As Single)
                Call pNew(OldLine, NewLine, OldAngle, NewAngle)
            End Sub

            Public ReadOnly Property OldSize As Single
                Get
                    Return sOldSize
                End Get
            End Property

            Public ReadOnly Property NewSize As Single
                Get
                    Return sNewSize
                End Get
            End Property

            Public ReadOnly Property OldAngle As Single
                Get
                    Return sOldAngle
                End Get
            End Property

            Public ReadOnly Property NewAngle As Single
                Get
                    Return sNewAngle
                End Get
            End Property

            Public ReadOnly Property OldLocation As PointF
                Get
                    Return oOldLocation
                End Get
            End Property

            Public ReadOnly Property NewLocation As PointF
                Get
                    Return oNewLocation
                End Get
            End Property
        End Class

        Public Class cProfileWarpingFactor
            Implements cIWarpingFactor
            Private sDeltaSize As Single
            Private sDeltaX As Single
            Private sDeltaY As Single
            Private sDeltaAngle As Single

            Private sOldSize As Single
            Private sNewSize As Single
            Private sOldAngle As Single
            Private sNewAngle As Single
            Private oOldLocation As PointF
            Private oNewLocation As PointF

            Public Sub Translate(Size As SizeF)
                sDeltaX += Size.Width
                sDeltaY += Size.Height
                oNewLocation += Size
            End Sub

            Public ReadOnly Property DeltaSize As Single Implements cIWarpingFactor.DeltaSize
                Get
                    Return sDeltaSize
                End Get
            End Property

            Public ReadOnly Property DeltaAngle As Single Implements cIWarpingFactor.DeltaAngle
                Get
                    Return sDeltaAngle
                End Get
            End Property

            Public ReadOnly Property DeltaX As Single Implements cIWarpingFactor.DeltaX
                Get
                    Return sDeltaX
                End Get
            End Property

            Public ReadOnly Property DeltaY As Single Implements cIWarpingFactor.DeltaY
                Get
                    Return sDeltaY
                End Get
            End Property

            Public Function IsChanged() As Boolean Implements cIWarpingFactor.IsChanged
                Return sDeltaSize <> 1 OrElse sDeltaX <> 0 OrElse sDeltaY <> 0 OrElse sDeltaAngle <> 0
            End Function

            Public Sub New(OldSegment As cISegment, NewSegment As cISegment)
                Call pNew(OldSegment.Data.Profile.GetLine, NewSegment.Data.Profile.GetLine, OldSegment.Data.Data.Inclination, NewSegment.Data.Data.Inclination, OldSegment.Data.Data.Reversed, NewSegment.Data.Data.Reversed)
            End Sub

            Public Sub New(OldLine As PointF(), NewLine As PointF(), OldAngle As Single, NewAngle As Single, OldReversed As Boolean, NewReversed As Boolean)
                Call pNew(OldLine, NewLine, OldAngle, NewAngle, OldReversed, NewReversed)
            End Sub

            Private Sub pNew(OldLine As PointF(), NewLine As PointF(), OldAngle As Single, NewAngle As Single, OldReversed As Boolean, NewReversed As Boolean)
                oOldLocation = OldLine(0)
                sNewSize = Math.Sqrt((NewLine(0).X - NewLine(1).X) ^ 2 + (NewLine(0).Y - NewLine(1).Y) ^ 2)
                sOldSize = Math.Sqrt((oOldLocation.X - OldLine(1).X) ^ 2 + (oOldLocation.Y - OldLine(1).Y) ^ 2)
                If sOldSize = 0 Then
                    sDeltaSize = 1
                Else
                    sDeltaSize = modNumbers.MathRound(sNewSize / sOldSize, 3)
                End If

                Dim sLineNewAngle As Single = modNumbers.MathRound(modPaint.GetBearing(NewLine(0), NewLine(1)), 4)
                Dim sLineOldAngle As Single = modNumbers.MathRound(modPaint.GetBearing(oOldLocation, OldLine(1)), 4)
                If Math.Abs(modNumbers.MathRound(sLineNewAngle - sLineOldAngle, 0)) = 180 Then
                    sDeltaX = Math.Round(NewLine(1).X - oOldLocation.X, 3)
                    sDeltaY = Math.Round(NewLine(1).Y - oOldLocation.Y, 3)
                    oNewLocation = NewLine(1)
                Else
                    sDeltaX = Math.Round(NewLine(0).X - oOldLocation.X, 3)
                    sDeltaY = Math.Round(NewLine(0).Y - oOldLocation.Y, 3)
                    oNewLocation = NewLine(0)
                End If

                sNewAngle = modPaint.NormalizeInclination(NewAngle)
                If NewReversed Then sNewAngle = -sNewAngle
                sOldAngle = modPaint.NormalizeInclination(OldAngle)
                If OldReversed Then sOldAngle = -sOldAngle
                sOldAngle = Math.Round(sOldAngle, 3)
                sNewAngle = Math.Round(sNewAngle, 3)
                sDeltaAngle = sNewAngle - sOldAngle
            End Sub

            Public ReadOnly Property OldSize As Single
                Get
                    Return sOldSize
                End Get
            End Property

            Public ReadOnly Property NewSize As Single
                Get
                    Return sNewSize
                End Get
            End Property

            Public ReadOnly Property OldAngle As Single
                Get
                    Return sOldAngle
                End Get
            End Property

            Public ReadOnly Property NewAngle As Single
                Get
                    Return sNewAngle
                End Get
            End Property

            Public ReadOnly Property OldLocation As PointF
                Get
                    Return oOldLocation
                End Get
            End Property

            Public ReadOnly Property NewLocation As PointF
                Get
                    Return oNewLocation
                End Get
            End Property
        End Class

        Private oPlanWarpingFactor As cPlanWarpingFactor
        Private oProfileWarpingFactor As cProfileWarpingFactor

        Friend Sub ResetWarpingFactor()
            oPlanWarpingFactor = Nothing
            oProfileWarpingFactor = Nothing
        End Sub

        Public ReadOnly Property PlanWarpingFactor() As cPlanWarpingFactor
            Get
                If IsNothing(oPlanWarpingFactor) Then
                    oPlanWarpingFactor = New cPlanWarpingFactor(oPlan.GetOldLine, oPlan.GetLine, oOldData.Bearing, oData.Bearing)
                End If
                Return oPlanWarpingFactor
            End Get
        End Property

        Public ReadOnly Property ProfileWarpingFactor() As cProfileWarpingFactor
            Get
                If IsNothing(oProfileWarpingFactor) Then
                    oProfileWarpingFactor = New cProfileWarpingFactor(oProfile.GetOldLine, oProfile.GetLine, oOldData.Inclination, oData.Inclination, oOldData.Reversed, oData.Reversed)
                End If
                Return oProfileWarpingFactor
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey, ByVal Item As XmlElement)
            oSourceData = New cSpatialData(Item.Item("srcdata"))
            oOldData = New cSpatialData(Item.Item("olddata"))
            oData = New cSpatialData(Item.Item("data"))

            oSegmentColor = modXML.GetAttributeColor(Item, "color", Color.Transparent)

            oPlan = New cPlanProjectedData(Survey, Item.Item("planpd"))
            oProfile = New cProfileProjectedData(Survey, Item.Item("profilepd"))

            oSubDatas = New cSubDatas(Me, Item.Item("sds"))

            bIsInRing = modXML.GetAttributeValue(Item, "ir", "0")
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlData As XmlElement = Document.CreateElement("data")
            Call oSourceData.SaveTo(File, Document, oXmlData, "srcdata")
            Call oOldData.SaveTo(File, Document, oXmlData, "olddata")
            Call oData.SaveTo(File, Document, oXmlData, "data")

            If oSegmentColor <> Drawing.Color.Transparent And Not oSegmentColor.IsEmpty Then
                Call oXmlData.SetAttribute("color", oSegmentColor.ToArgb)
            End If

            Call oPlan.SaveTo(File, Document, oXmlData)
            Call oProfile.SaveTo(File, Document, oXmlData)

            Call oSubDatas.SaveTo(File, Document, oXmlData)

            'If bChanged Then oXmlData.SetAttribute("c", "1")
            If bIsInRing Then oXmlData.SetAttribute("ir", "1")

            Call Parent.AppendChild(oXmlData)
            Return oXmlData
        End Function

        Public ReadOnly Property SubDatas As cSubDatas
            Get
                Return oSubDatas
            End Get
        End Property

        Friend Property Group As cSegmentGroup
            Get
                Return oGroup
            End Get
            Set(value As cSegmentGroup)
                oGroup = value
            End Set
        End Property

        Friend Property OrdinalPosition As Integer
            Get
                Return iOrdinalPosition
            End Get
            Set(value As Integer)
                iOrdinalPosition = value
            End Set
        End Property

        Friend Property SegmentColor As Color
            Get
                Return oSegmentColor
            End Get
            Set(value As Color)
                oSegmentColor = value
            End Set
        End Property

        Friend ReadOnly Property SourceData() As cSpatialData
            Get
                Return oSourceData
            End Get
        End Property

        Friend ReadOnly Property Data() As cSpatialData
            Get
                Return oData
            End Get
        End Property

        Friend ReadOnly Property OldData() As cSpatialData
            Get
                Return oOldData
            End Get
        End Property

        Friend Sub RenameFrom(ByVal NewName As String)
            Call oSourceData.RenameFrom(NewName)
            Call oData.RenameFrom(NewName)
            'renaming a station in subdata, substation keep original name...
            If oData.Reversed Then
                If oSubDatas.Count > 0 Then
                    Call oSubDatas(oSubDatas.Count - 1).RenameTo(NewName)
                End If
            Else
                If oSubDatas.Count > 0 Then
                    Call oSubDatas(0).RenameFrom(NewName)
                End If
            End If
            Call oOldData.RenameFrom(NewName)
        End Sub

        Friend Sub RenameTo(ByVal NewName As String)
            Call oSourceData.RenameTo(NewName)
            Call oData.RenameTo(NewName)
            'renaming a station in subdata, substation keep original name...
            If oData.Reversed Then
                If oSubDatas.Count > 0 Then
                    Call oSubDatas(0).RenameFrom(NewName)
                End If
            Else
                If oSubDatas.Count > 0 Then
                    Call oSubDatas(oSubDatas.Count - 1).RenameTo(NewName)
                End If
            End If
            Call oOldData.RenameTo(NewName)
        End Sub

        Public ReadOnly Property IsInRing() As Boolean
            Get
                Return bIsInRing
            End Get
        End Property

        Friend Sub SetFlag(IsInRing As Boolean)
            bIsInRing = IsInRing
        End Sub

        Friend Sub SetData(ByVal Distance As Decimal, ByVal Bearing As Decimal, ByVal Inclination As Decimal, ByVal Direction As cSurvey.DirectionEnum)
            Call oData.SetData(Distance, Inclination, Bearing, Direction)
        End Sub

        Friend Sub CloneData(ByVal Segment As cSegment)
            With Segment
                oSourceData.SetData(.[From], .[To], .GetDistance, .GetInclination, .GetBearing, .Direction, False)
            End With
            Call oData.SetData(oSourceData.From, oSourceData.To, oSourceData.Direction, oSourceData.Reversed)
        End Sub

        Friend Sub ReverseData(ByVal Segment As cSegment)
            With Segment
                oSourceData.SetData(.[To], .[From], .GetDistance, - .GetInclination, .GetBearing - 180, .Direction, True)
            End With
            Call oData.SetData(oSourceData.From, oSourceData.To, oSourceData.Direction, oSourceData.Reversed)
        End Sub

        Friend Sub BackupData()
            Call oOldData.SetData(oData.From, oData.To, oData.Distance, oData.Inclination, oData.Bearing, oData.Direction, oData.Reversed)
        End Sub

        Friend ReadOnly Property Plan As cPlanProjectedData
            Get
                Return oPlan
            End Get
        End Property

        Friend ReadOnly Property Profile As cProfileProjectedData
            Get
                Return oProfile
            End Get
        End Property

        Friend Sub New(ByVal Survey As cSurvey)
            oData = New cSpatialData
            oOldData = New cSpatialData
            oSourceData = New cSpatialData
            oPlan = New cPlanProjectedData(Survey)
            oProfile = New cProfileProjectedData(Survey)
            SegmentColor = Color.Transparent
            oSubDatas = New cSubDatas(Me)
        End Sub

        Public Enum UniformSubDataModeEnum
            Average = 0
            DevStd = 1
        End Enum

        Friend Sub UniformSubDataLRUD(Optional Factor As Single = 1.5, Optional Mode As UniformSubDataModeEnum = UniformSubDataModeEnum.DevStd)
            Dim sFromLeft As Single
            Dim sFromRight As Single
            Dim sToLeft As Single
            Dim sToRight As Single

            Dim sFromUp As Single
            Dim sFromDown As Single
            Dim sToUp As Single
            Dim sToDown As Single

            If Mode = UniformSubDataModeEnum.Average Then
                Dim sAvgLeft As Single
                Dim sAvgRight As Single
                Dim sAvgUp As Single
                Dim sAvgDown As Single

                Dim iCount As Integer

                For Each oSubData As cSubData In oSubDatas
                    sAvgLeft = sAvgLeft + oSubData.Plan.FromLeft
                    sAvgLeft = sAvgLeft + oSubData.Plan.ToLeft
                    sAvgRight = sAvgRight + oSubData.Plan.FromRight
                    sAvgRight = sAvgRight + oSubData.Plan.ToRight
                    sAvgUp = sAvgUp + oSubData.Profile.FromUp
                    sAvgUp = sAvgUp + oSubData.Profile.ToUp
                    sAvgDown = sAvgDown + oSubData.Profile.FromDown
                    sAvgDown = sAvgDown + oSubData.Profile.ToDown
                    iCount += 2
                Next
                sAvgLeft = (sAvgLeft / iCount) * Factor
                sAvgRight = (sAvgRight / iCount) * Factor
                sAvgUp = (sAvgUp / iCount) * Factor
                sAvgDown = (sAvgDown / iCount) * Factor

                For Each oSubData As cSubData In oSubDatas
                    If oSubData.Plan.FromLeft > sAvgLeft Then
                        sFromLeft = sAvgLeft
                    Else
                        sFromLeft = oSubData.Plan.FromLeft
                    End If
                    If oSubData.Plan.FromRight > sAvgRight Then
                        sFromRight = sAvgRight
                    Else
                        sFromRight = oSubData.Plan.FromRight
                    End If
                    If oSubData.Plan.ToLeft > sAvgLeft Then
                        sToLeft = sAvgLeft
                    Else
                        sToLeft = oSubData.Plan.ToLeft
                    End If
                    If oSubData.Plan.ToRight > sAvgRight Then
                        sToRight = sAvgRight
                    Else
                        sToRight = oSubData.Plan.ToRight
                    End If

                    If oSubData.Profile.FromUp > sAvgUp Then
                        sFromUp = sAvgUp
                    Else
                        sFromUp = oSubData.Profile.FromUp
                    End If
                    If oSubData.Profile.FromDown > sAvgDown Then
                        sFromDown = sAvgDown
                    Else
                        sFromDown = oSubData.Profile.FromDown
                    End If
                    If oSubData.Profile.ToUp > sAvgUp Then
                        sToUp = sAvgUp
                    Else
                        sToUp = oSubData.Profile.ToUp
                    End If
                    If oSubData.Profile.ToDown > sAvgDown Then
                        sToDown = sAvgDown
                    Else
                        sToDown = oSubData.Profile.ToDown
                    End If

                    Call oSubData.SetLRUD(sFromLeft, sFromRight, sFromUp, sFromDown, sToLeft, sToRight, sToUp, sToDown)
                Next
            Else
                Dim sAvgLeft As Single
                Dim sAvgRight As Single
                Dim sAvgUp As Single
                Dim sAvgDown As Single
                Dim iCount As Integer

                For Each oSubData As cSubData In oSubDatas
                    sAvgLeft = sAvgLeft + oSubData.Plan.FromLeft
                    sAvgLeft = sAvgLeft + oSubData.Plan.ToLeft
                    sAvgRight = sAvgRight + oSubData.Plan.FromRight
                    sAvgRight = sAvgRight + oSubData.Plan.ToRight
                    sAvgUp = sAvgUp + oSubData.Profile.FromUp
                    sAvgUp = sAvgUp + oSubData.Profile.ToUp
                    sAvgDown = sAvgDown + oSubData.Profile.FromDown
                    sAvgDown = sAvgDown + oSubData.Profile.ToDown
                    iCount += 2
                Next

                sAvgLeft = (sAvgLeft / iCount) * Factor
                sAvgRight = (sAvgRight / iCount) * Factor
                sAvgUp = (sAvgUp / iCount) * Factor
                sAvgDown = (sAvgDown / iCount) * Factor

                Dim sDevLeft As Single
                Dim sDevRight As Single
                Dim sDevUp As Single
                Dim sDevDown As Single

                For Each oSubData As cSubData In oSubDatas
                    sDevLeft = sDevLeft + (oSubData.Plan.FromLeft - sAvgLeft) ^ 2
                    sDevLeft = sDevLeft + (oSubData.Plan.ToLeft - sAvgLeft) ^ 2
                    sDevRight = sDevRight + (oSubData.Plan.FromRight - sAvgRight) ^ 2
                    sDevRight = sDevRight + (oSubData.Plan.ToRight - sAvgRight) ^ 2
                    sDevUp = sDevUp + (oSubData.Profile.FromUp - sAvgUp) ^ 2
                    sDevUp = sDevUp + (oSubData.Profile.ToUp - sAvgUp) ^ 2
                    sDevDown = sDevDown + (oSubData.Profile.FromDown - sAvgDown) ^ 2
                    sDevDown = sDevDown + (oSubData.Profile.ToDown - sAvgDown) ^ 2
                Next

                sDevLeft = Math.Sqrt(sDevLeft / iCount) * Factor
                sDevRight = Math.Sqrt(sDevRight / iCount) * Factor
                sDevUp = Math.Sqrt(sDevUp / iCount) * Factor
                sDevDown = Math.Sqrt(sDevDown / iCount) * Factor

                For Each oSubData As cSubData In oSubDatas
                    If (oSubData.Plan.FromLeft - sAvgLeft) > sDevLeft Then
                        sFromLeft = sAvgLeft
                    Else
                        sFromLeft = oSubData.Plan.FromLeft
                    End If
                    If (oSubData.Plan.FromRight - sAvgRight) > sDevRight Then
                        sFromRight = sAvgRight
                    Else
                        sFromRight = oSubData.Plan.FromRight
                    End If
                    If (oSubData.Plan.ToLeft - sAvgLeft) > sDevLeft Then
                        sToLeft = sAvgLeft
                    Else
                        sToLeft = oSubData.Plan.ToLeft
                    End If
                    If (oSubData.Plan.ToRight - sAvgRight) > sDevRight Then
                        sToRight = sAvgRight
                    Else
                        sToRight = oSubData.Plan.ToRight
                    End If

                    If (oSubData.Profile.FromUp - sAvgUp) > sDevUp Then
                        sFromUp = sAvgUp
                    Else
                        sFromUp = oSubData.Profile.FromUp
                    End If
                    If (oSubData.Profile.FromDown - sAvgDown) > sDevDown Then
                        sFromDown = sAvgDown
                    Else
                        sFromDown = oSubData.Profile.FromDown
                    End If
                    If (oSubData.Profile.ToUp - sAvgUp) > sDevUp Then
                        sToUp = sAvgUp
                    Else
                        sToUp = oSubData.Profile.ToUp
                    End If
                    If (oSubData.Profile.ToDown - sAvgDown) > sDevDown Then
                        sToDown = sAvgDown
                    Else
                        sToDown = oSubData.Profile.ToDown
                    End If

                    Call oSubData.SetLRUD(sFromLeft, sFromRight, sFromUp, sFromDown, sToLeft, sToRight, sToUp, sToDown)
                Next
            End If
        End Sub
    End Class
End Namespace
