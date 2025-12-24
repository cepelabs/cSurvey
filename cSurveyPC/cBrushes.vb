Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.ObjectModel

Namespace cSurvey.Design
    Public Class cBrushes
        Implements IEnumerable

        Public Event OnChanged(sender As Object, e As EventArgs)

        Private WithEvents oSurvey As cSurvey

        Private oBrushNone As cCustomBrush
        Private oBrushSolid As cCustomBrush
        Private oBrushWater As cCustomBrush
        Private oBrushWaterSolid As cCustomBrush
        Private oBrushSignSolid As cCustomBrush
        Private oBrushSand As cCustomBrush
        Private oBrushPebbles As cCustomBrush
        Private oBrushFlow As cCustomBrush
        Private oBrushSmallDebrits As cCustomBrush
        Private oBrushBigDebrits As cCustomBrush
        Private oBrushSnowOrIce As cCustomBrush

        Public ReadOnly Property None() As cCustomBrush
            Get
                If oBrushNone Is Nothing Then
                    oBrushNone = New cCustomBrush(oSurvey, GetLocalizedString("brushes.none"), cBrush.BrushTypeEnum.None, Color.Transparent, cBrush.HatchTypeEnum.None)
                End If
                Return oBrushNone
            End Get
        End Property

        Public ReadOnly Property SnowOrIce() As cCustomBrush
            Get
                If oBrushSnowOrIce Is Nothing Then
                    oBrushSnowOrIce = New cCustomBrush(oSurvey, GetLocalizedString("brushes.snoworice"), cBrush.BrushTypeEnum.SnowOrIce, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.Ice, 0.3, 0.02, Color.LightBlue, cBrush.ClipartAngleModeEnum.Fixed, 0, cBrush.ClipartCropEnum.Full, cBrush.ClipartPositionEnum.Fixed)
                End If
                Return oBrushSnowOrIce
            End Get
        End Property

        Public ReadOnly Property Solid() As cCustomBrush
            Get
                If oBrushSolid Is Nothing Then
                    oBrushSolid = New cCustomBrush(oSurvey, GetLocalizedString("brushes.solid"), cBrush.BrushTypeEnum.Solid, Color.White, cBrush.HatchTypeEnum.Solid)
                End If
                Return oBrushSolid
            End Get
        End Property

        Public ReadOnly Property Water() As cCustomBrush
            Get
                If oBrushWater Is Nothing Then
                    oBrushWater = New cCustomBrush(oSurvey, GetLocalizedString("brushes.water"), cBrush.BrushTypeEnum.Water, Color.Black, cBrush.HatchTypeEnum.Pattern)
                    oBrushWater.PatternType = cBrush.PatternTypeEnum.Lines
                    oBrushWater.PatternAngle = 45
                End If
                Return oBrushWater
            End Get
        End Property

        Public ReadOnly Property NotStandardWater() As cCustomBrush
            Get
                If oBrushWaterSolid Is Nothing Then
                    oBrushWaterSolid = New cCustomBrush(oSurvey, GetLocalizedString("brushes.notstandardwater"), cBrush.BrushTypeEnum.NotStandardWater, Color.LightSkyBlue, cBrush.HatchTypeEnum.Solid)
                End If
                Return oBrushWaterSolid
            End Get
        End Property

        Public ReadOnly Property SignSolid() As cCustomBrush
            Get
                If oBrushSignSolid Is Nothing Then
                    oBrushSignSolid = New cCustomBrush(oSurvey, GetLocalizedString("brushes.signsolid"), cBrush.BrushTypeEnum.SignSolid, Color.Black, cBrush.HatchTypeEnum.Solid)
                End If
                Return oBrushSignSolid
            End Get
        End Property

        Public ReadOnly Property Sand() As cCustomBrush
            Get
                If oBrushSand Is Nothing Then
                    oBrushSand = New cCustomBrush(oSurvey, GetLocalizedString("brushes.sand"), cBrush.BrushTypeEnum.Sand, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartSand, 0.5, 0.1, Color.SandyBrown, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.None)
                End If
                Return oBrushSand
            End Get
        End Property

        Public ReadOnly Property Pebbles() As cCustomBrush
            Get
                If oBrushPebbles Is Nothing Then
                    oBrushPebbles = New cCustomBrush(oSurvey, GetLocalizedString("brushes.pebbles"), cBrush.BrushTypeEnum.Pebbles, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartPebbles1, 0.6, 0.01, Color.Gray, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.Subitems)
                End If
                Return oBrushPebbles
            End Get
        End Property

        Public ReadOnly Property SmallDebrits() As cCustomBrush
            Get
                If oBrushSmallDebrits Is Nothing Then
                    oBrushSmallDebrits = New cCustomBrush(oSurvey, GetLocalizedString("brushes.smalldebrits"), cBrush.BrushTypeEnum.SmallDebrits, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartDebrits1, 0.9, 0.006, Color.LightGray, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.Subitems)
                End If
                Return oBrushSmallDebrits
            End Get
        End Property

        Public ReadOnly Property BigDebrits() As cCustomBrush
            Get
                If oBrushBigDebrits Is Nothing Then
                    oBrushBigDebrits = New cCustomBrush(oSurvey, GetLocalizedString("brushes.bigdebrits"), cBrush.BrushTypeEnum.BigDebrits, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartDebrits2, 2.6, 0.018, Color.LightGray, cBrush.ClipartAngleModeEnum.Random, 0, cBrush.ClipartCropEnum.Subitems)
                End If
                Return oBrushBigDebrits
            End Get
        End Property

        Public ReadOnly Property Flow() As cCustomBrush
            Get
                If oBrushFlow Is Nothing Then
                    oBrushFlow = New cCustomBrush(oSurvey, GetLocalizedString("brushes.flow"), cBrush.BrushTypeEnum.Flow, Color.Black, cBrush.HatchTypeEnum.Clipart, modPenClipart.ClipartFlow1, 0.6, 0.006, Color.WhiteSmoke, cBrush.ClipartAngleModeEnum.Fixed, 0, cBrush.ClipartCropEnum.Full)
                End If
                Return oBrushFlow
            End Get
        End Property

        Public Function FromCustom(ByVal Color As Color, Optional ByVal Name As String = "", Optional ByVal HatchStyle As cBrush.HatchTypeEnum = cBrush.HatchTypeEnum.None) As cCustomBrush
            Dim oBrush As cCustomBrush = New cCustomBrush(oSurvey, Name, cBrush.BrushTypeEnum.Custom, Color, HatchStyle)
            Return oBrush
        End Function
        Public Function FromName(ByVal Name As String) As cCustomBrush
            If Name Is Nothing Then
                Return Nothing
            Else
                Dim oFindItem As cCustomBrush = oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Name.ToLower)
                Return oFindItem
            End If
        End Function

        ''' <summary>
        ''' Get custom brush by id searching in standard brushes and in users brushes
        ''' </summary>
        ''' <param name="ID">Brush ID to be retrieved</param>
        ''' <returns></returns>
        Public Function FromID(ByVal ID As String) As cCustomBrush
            If ID Is Nothing Then
                Return Nothing
            Else
                If ID.StartsWith("_") Then
                    Dim iType As cBrush.BrushTypeEnum = Integer.Parse(ID.Substring(1))
                    Return FromType(iType)
                Else
                    Dim oFindItem As cCustomBrush = oItems.FirstOrDefault(Function(oItem) oItem.ID = ID)
                    If oFindItem IsNot Nothing Then
                        Return oFindItem
                    Else
                        Return Nothing
                    End If
                End If
            End If
        End Function
        Public Function FromType(ByVal Type As cBrush.BrushTypeEnum) As cCustomBrush
            Select Case Type
                Case cBrush.BrushTypeEnum.None
                    Return None
                Case cBrush.BrushTypeEnum.Water
                    Return Water
                Case cBrush.BrushTypeEnum.NotStandardWater
                    Return NotStandardWater
                Case cBrush.BrushTypeEnum.SignSolid
                    Return SignSolid
                Case cBrush.BrushTypeEnum.Solid
                    Return Solid
                Case cBrush.BrushTypeEnum.Sand
                    Return Sand
                Case cBrush.BrushTypeEnum.Pebbles
                    Return Pebbles
                Case cBrush.BrushTypeEnum.Flow
                    Return Flow
                Case cBrush.BrushTypeEnum.SmallDebrits
                    Return SmallDebrits
                Case cBrush.BrushTypeEnum.BigDebrits
                    Return BigDebrits
                Case cBrush.BrushTypeEnum.SnowOrIce
                    Return SnowOrIce

                Case Else
                    'is usefull?
                    Return New cCustomBrush(oSurvey)
            End Select
        End Function

        Friend Sub New(ByVal Survey As cSurvey, ByVal File As cFile, ByVal Brushes As XmlElement)
            oSurvey = Survey
            oItems = New List(Of cCustomBrush)
            Dim iIndex As Integer = 0
            Dim iCount As Integer = Brushes.ChildNodes.Count
            For Each oXMLBrush As XmlElement In Brushes.ChildNodes
                iIndex += 1
                Call oSurvey.RaiseOnProgressEvent("", cSurvey.OnProgressEventArgs.ProgressActionEnum.Progress, modMain.GetLocalizedString("brushes.load"), iIndex / iCount)
                Dim oItem As cCustomBrush = New cCustomBrush(oSurvey, File, oXMLBrush)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New List(Of cCustomBrush)
        End Sub

        Private oItems As List(Of cCustomBrush)

        Default Public ReadOnly Property Item(Index As Integer) As cCustomBrush
            Get
                Return oItems(Index)
            End Get
        End Property

        Default Public ReadOnly Property Item(ID As String) As cCustomBrush
            Get
                Return oItems.FirstOrDefault(Function(oItem) oItem.ID = ID)
            End Get
        End Property

        Friend Function Add(Custombrush As cCustomBrush) As Boolean
            If Custombrush.Type = cBrush.BrushTypeEnum.User Then
                Dim oExistingbrush As cCustomBrush = oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Custombrush.Name.ToLower)
                If oExistingbrush IsNot Nothing Then
                    oExistingbrush.CopyFrom(Custombrush)
                    Custombrush.ID = oExistingbrush.ID
                    Return True
                Else
                    If Not ContainsID(Custombrush.ID) Then
                        Call oItems.Add(Custombrush)
                        RaiseEvent OnChanged(Me, EventArgs.Empty)
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End Function
        Public ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Function Delete(ID As String) As Boolean
            If ContainsID(ID) Then
                Dim oCustombrush As cCustomBrush = Item(ID)
                oItems.Remove(oCustombrush)
                RaiseEvent OnChanged(Me, EventArgs.Empty)
                Return True
            Else
                Return False
            End If
        End Function

        Friend Function Delete(brush As cBrush) As Boolean
            If brush.Type = cBrush.BrushTypeEnum.User Then
                Dim oCustombrush As cCustomBrush = brush.GetBaseBrush
                If oItems.Contains(oCustombrush) Then
                    oItems.Remove(oCustombrush)
                    RaiseEvent OnChanged(Me, EventArgs.Empty)
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function

        Public Function Add(brush As cBrush, Name As String) As cCustomBrush
            If brush.Type = cBrush.BrushTypeEnum.Custom OrElse brush.Type = cBrush.BrushTypeEnum.User Then
                Dim oCustombrush As cCustomBrush
                If brush.Type = cBrush.BrushTypeEnum.User Then
                    oCustombrush = cCustomBrush.CopyAsUser(brush.Survey, brush.GetBaseBrush)
                Else
                    oCustombrush = brush.GetBaseBrush
                End If
                If oCustombrush.Name IsNot Nothing Then oCustombrush.Name = Name

                Dim oExistingbrush1 As cCustomBrush = oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Name.ToLower)
                If oExistingbrush1 IsNot Nothing Then
                    oExistingbrush1.CopyFrom(oCustombrush)
                    brush.ID = oExistingbrush1.ID
                    Return oExistingbrush1
                Else
                    Dim oNewbrush As cCustomBrush = cCustomBrush.CopyAsUser(oSurvey, oCustombrush)
                    Dim oExistingbrush2 As cCustomBrush = oItems.FirstOrDefault(Function(oItem) oItem.ID = oNewbrush.ID)
                    If oExistingbrush2 IsNot Nothing Then
                        oExistingbrush2.CopyFrom(oNewbrush)
                        brush.ID = oExistingbrush2.ID
                        Return oExistingbrush2
                    Else
                        Call oItems.Add(oNewbrush)
                        RaiseEvent OnChanged(Me, EventArgs.Empty)
                        Return oNewbrush
                    End If
                End If
            End If
        End Function
        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, Options As cSurvey.SaveOptionsEnum)
            Dim oXMLbrushes As XmlElement = Document.CreateElement("brushes")
            For Each oItem As cCustomBrush In oItems
                Call oItem.SaveTo(File, Document, oXMLbrushes)
            Next
            Call Parent.AppendChild(oXMLbrushes)
            Return oXMLbrushes
        End Function

        Friend Sub CleanUp()
            'TODO?
        End Sub

        Public Function ContainsName(Name As String) As Boolean
            Return oItems.FirstOrDefault(Function(oItem) oItem.Name.ToLower = Name.ToLower) IsNot Nothing
        End Function

        Public Function ContainsID(ID As String) As Boolean
            Return oItems.FirstOrDefault(Function(oItem) oItem.ID = ID) IsNot Nothing
        End Function

        Public Function Contains(IDorName As String) As Boolean
            If ContainsID(IDorName) Then
                Return True
            Else
                Return ContainsName(IDorName)
            End If
        End Function

        Public Function Contains(Brush As cBrush) As Boolean
            Return Contains(Brush.GetBaseBrush)
        End Function

        Public Function Contains(Brush As cCustomBrush) As Boolean
            Dim oBrush As cCustomBrush
            If Brush.Type = cBrush.BrushTypeEnum.User Then
                oBrush = Brush
            Else
                oBrush = cCustomBrush.CopyAsUser(oSurvey, Brush)
            End If
            If ContainsID(oBrush.ID) Then
                Return True
            Else
                Return ContainsName(oBrush.Name)
            End If
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class

    Friend Class cBrushesBaseCollection
        Inherits KeyedCollection(Of String, cCustomBrush)

        Public Sub New()
            Call MyBase.New(StringComparer.OrdinalIgnoreCase)
        End Sub

        Public Sub Rebind()
            MyBase.Dictionary.Clear()
            For Each oitem As cCustomBrush In MyBase.Items
                MyBase.Dictionary.Add(oitem.ID, oitem)
            Next
        End Sub

        Public Function ContainsKey(Key As String) As Boolean
            Return MyBase.FirstOrDefault(Function(oItem) oItem.ID = Key) IsNot Nothing
        End Function

        Public Function ContainsKey(item As cCustomBrush) As Boolean
            Return MyBase.FirstOrDefault(Function(oItem) oItem.ID = item.ID) IsNot Nothing
        End Function

        Protected Overrides Function GetKeyForItem(ByVal item As cCustomBrush) As String
            Return item.ID
        End Function
    End Class
End Namespace
