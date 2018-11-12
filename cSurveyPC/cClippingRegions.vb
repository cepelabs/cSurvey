Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Public Class cClippingRegions
        Implements IDisposable
        Implements IEnumerable

        Private oSurvey As cSurvey

        Public Enum ClipBorderEnum
            DontClipBorder = 0
            ClipBorder = 1
            Disable = 2
        End Enum

        Private iClipBorder As ClipBorderEnum

        Private oRegions As Dictionary(Of String, Region)
        Private oInfiniteRegion As Region

        Public Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            iClipBorder = oSurvey.Properties.DesignProperties.GetValue("ClipBorder", oSurvey.GetGlobalSetting("design.clipborder", ClipBorderEnum.ClipBorder))
            oRegions = New Dictionary(Of String, Region)(System.StringComparer.OrdinalIgnoreCase)
            oInfiniteRegion = New Region
            Call oInfiniteRegion.MakeInfinite()
        End Sub

        Public Sub Clear()
            Call oRegions.Clear()
        End Sub

        Public ReadOnly Property Count As Integer
            Get
                Return oRegions.Count
            End Get
        End Property

        Friend Function GetClip(ByVal Graphics As Graphics, ByVal Layer As cLayer, ByVal Item As cItem) As Region
            If iClipBorder = ClipBorderEnum.Disable Then
                Return oInfiniteRegion
            Else
                If Item.ClippingType = cItem.cItemClippingTypeEnum.Default Then
                    If (Item.Type = cIItem.cItemTypeEnum.InvertedFreeHandArea AndAlso Layer.Type = cLayers.LayerTypeEnum.Borders) OrElse (Layer.Type > cLayers.LayerTypeEnum.Borders) OrElse (iClipBorder = ClipBorderEnum.DontClipBorder AndAlso Layer.Type = cLayers.LayerTypeEnum.Borders) Then
                        Return oInfiniteRegion
                    Else
                        Dim sKey As String = Item.Cave & "/" & Item.Branch
                        If oRegions.ContainsKey(sKey) Then
                            Dim oClip As Region = oRegions(sKey)
                            If oClip.IsEmpty(Graphics) Then
                                Return oInfiniteRegion
                            Else
                                If Item.Type = cIItem.cItemTypeEnum.FreeHandArea AndAlso Item.Category = cIItem.cItemCategoryEnum.Soil AndAlso Item.Design.Type = cIDesign.cDesignTypeEnum.Profile Then
                                    Dim oInvertedClip As Region = oInfiniteRegion.Clone
                                    Call oInvertedClip.Exclude(oClip)
                                    Return oInvertedClip
                                Else
                                    Return oClip
                                End If
                            End If
                        Else
                            Return oInfiniteRegion
                        End If
                    End If
                Else
                    Select Case Item.ClippingType
                        Case cItem.cItemClippingTypeEnum.None
                            'senza clipping restituisco sempre TUTTO
                            Return oInfiniteRegion
                        Case cItem.cItemClippingTypeEnum.InsideBorder
                            Dim sKey As String = Item.Cave & "/" & Item.Branch
                            sKey = sKey.ToLower
                            If oRegions.ContainsKey(sKey) Then
                                Dim oClip As Region = oRegions(sKey)
                                If oClip.IsEmpty(Graphics) Then
                                    'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                    Return oInfiniteRegion
                                Else
                                    'restituisco l'area della grotta/ramo a cui l'oggetto appartiene
                                    Return oClip
                                End If
                            Else
                                'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                Return oInfiniteRegion
                            End If
                        Case cItem.cItemClippingTypeEnum.OutsideBorder
                            Dim sKey As String = Item.Cave & "/" & Item.Branch
                            sKey = sKey.ToLower
                            If oRegions.ContainsKey(sKey) Then
                                Dim oClip As Region = oRegions(sKey)
                                If oClip.IsEmpty(Graphics) Then
                                    'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                    Return oInfiniteRegion
                                Else
                                    Dim oInvertedClip As Region = oInfiniteRegion.Clone
                                    Call oInvertedClip.Exclude(oClip)
                                    Return oInvertedClip
                                End If
                            Else
                                'in caso di clipping non individuabile...restituisco TUTTO (quindi niente clipping)
                                Return oInfiniteRegion
                            End If
                    End Select
                End If
            End If
        End Function

        Friend Function GetClip(ByVal Graphics As Graphics, ByVal Layer As cLayer, ByVal Cave As String, ByVal Branch As String) As Region
            If iClipBorder = ClipBorderEnum.Disable Then
                Return oInfiniteRegion
            Else
                If Layer.Type >= cLayers.LayerTypeEnum.Borders Then
                    Return oInfiniteRegion
                Else
                    Dim sKey As String = Cave & "/" & Branch
                    If oRegions.ContainsKey(sKey) Then
                        Dim oClip As Region = oRegions(sKey)
                        If oClip.IsEmpty(Graphics) Then
                            Return oInfiniteRegion
                        Else
                            Return oClip
                        End If
                    Else
                        Return oInfiniteRegion
                    End If
                End If
            End If
        End Function

        Public Function Contains(ByVal Cave As String, ByVal Branch As String) As Boolean
            Dim sKey As String = Cave & "/" & Branch
            Return oRegions.ContainsKey(sKey)
        End Function

        Default ReadOnly Property Item(ByVal Cave As String, ByVal Branch As String) As Region
            Get
                Dim sKey As String = Cave & "/" & Branch
                If oRegions.ContainsKey(sKey) Then
                    Return oRegions(sKey)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            If oRegions.ContainsKey(sKey) Then
                Dim oCurrentRegion As Region = oRegions(sKey)
                Call oCurrentRegion.Exclude(Path)
            End If
        End Sub

        Public Sub Exclude(ByVal Cave As String, ByVal Branch As String, ByVal Region As Region)
            Dim sKey As String = Cave & "/" & Branch
            If oRegions.ContainsKey(sKey) Then
                Dim oCurrentRegion As Region = oRegions(sKey)
                Call oCurrentRegion.Exclude(Region)
            End If
        End Sub

        Public Sub Intersect(Cave As String, Branch As String, ByVal Region As Region)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Intersect(Region)
        End Sub

        Public Sub Intersect(Cave As String, Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Intersect(Path)
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Path As GraphicsPath)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Union(Path)
        End Sub

        Public Sub Combine(ByVal Cave As String, ByVal Branch As String, ByVal Region As Region)
            Dim sKey As String = Cave & "/" & Branch
            Dim oCurrentRegion As Region
            If oRegions.ContainsKey(sKey) Then
                oCurrentRegion = oRegions(sKey)
            Else
                oCurrentRegion = New Region()
                Call oCurrentRegion.MakeEmpty()
                Call oRegions.Add(sKey, oCurrentRegion)
            End If
            Call oCurrentRegion.Union(Region)
        End Sub

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oRegions.Values.GetEnumerator
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' Per rilevare chiamate ridondanti

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    For Each oRegion As Region In oRegions.Values
                        Call oRegion.Dispose()
                    Next
                    Call oRegions.Clear()
                    Call oInfiniteRegion.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub

        ' Questo codice è aggiunto da Visual Basic per implementare in modo corretto il modello Disposable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Non modificare questo codice. Inserire il codice di pulizia in Dispose(disposing As Boolean).
            Call Dispose(True)
            Call GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class
End Namespace