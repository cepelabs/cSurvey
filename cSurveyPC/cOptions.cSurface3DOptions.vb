Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cSurface3DOptions
        Implements IEnumerable
        Implements cIUIBaseInteractions

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

        Friend Class cSurface3DOptionsBaseCollection
            Inherits KeyedCollection(Of String, cSurface3DOptionsItem)

            Protected Overrides Function GetKeyForItem(ByVal item As cSurface3DOptionsItem) As String
                Return item.ID
            End Function
        End Class

        Public Class cSurface3DOptionsElevationItem
            Inherits cSurface3DOptionsItem

            Private sAltitudeAmplification As Single

            Public Property AltitudeAmplification() As Single
                Get
                    Return sAltitudeAmplification
                End Get
                Set(value As Single)
                    If value >= 1 AndAlso sAltitudeAmplification <> value Then
                        sAltitudeAmplification = value
                    End If
                End Set
            End Property

            Friend Overrides Function Clone() As cSurface3DOptionsItem
                Dim oItem As cSurface3DOptionsElevationItem = New cSurface3DOptionsElevationItem(ID)
                oItem.Visible = MyBase.Visible
                oItem.Transparency = MyBase.Transparency
                oItem.AltitudeAmplification = sAltitudeAmplification
                Return oItem
            End Function

            Friend Sub New(ID As String)
                MyBase.New(ID)
                sAltitudeAmplification = 1
            End Sub

            Friend Sub New(Item As XmlElement)
                MyBase.New(Item)
                sAltitudeAmplification = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "altamp", "1"))
            End Sub

            Friend Shadows Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXMLSurfaceOptionsItem As XmlElement = MyBase.SaveTo(File, Document, Parent)
                If sAltitudeAmplification <> 1 Then Call oXMLSurfaceOptionsItem.SetAttribute("altamp", modNumbers.NumberToString(sAltitudeAmplification))
                Call Parent.AppendChild(oXMLSurfaceOptionsItem)
                Return oXMLSurfaceOptionsItem
            End Function
        End Class

        Public Class cSurface3DOptionsItem
            Inherits Options.cSurfaceBaseOptionsItem
            Implements Options.cISurfaceOptionsItem

            Private bVisible As Boolean
            Private sTransparency As Single

            Public Property Transparency As Single Implements cISurfaceOptionsItem.Transparency
                Get
                    Return sTransparency
                End Get
                Set(value As Single)
                    If value <> sTransparency Then
                        sTransparency = value
                    End If
                End Set
            End Property

            Public Property Visible As Boolean Implements cISurfaceOptionsItem.Visible
                Get
                    Return bVisible
                End Get
                Set(value As Boolean)
                    If value <> bVisible Then
                        bVisible = value
                    End If
                End Set
            End Property

            Friend Sub New(ID As String)
                MyBase.New(ID)
            End Sub

            Friend Sub New(Item As XmlElement)
                MyBase.New(Item)
                bVisible = modXML.GetAttributeValue(Item, "visible", 0)
                sTransparency = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "transparency", "0"))
            End Sub

            Friend Overridable Function Clone() As cSurface3DOptionsItem
                Dim oItem As cSurface3DOptionsItem = New cSurface3DOptionsItem(MyBase.ID)
                oItem.bVisible = bVisible
                oItem.sTransparency = sTransparency
                Return oItem
            End Function

            Friend Shadows Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXMLSurfaceOptionsItem As XmlElement = MyBase.SaveTo("surface3doptionsitem", File, Document, Parent)
                If bVisible Then Call oXMLSurfaceOptionsItem.SetAttribute("visible", "1")
                If sTransparency > 0 Then Call oXMLSurfaceOptionsItem.SetAttribute("transparency", modNumbers.NumberToString(sTransparency))
                Call Parent.AppendChild(oXMLSurfaceOptionsItem)
                Return oXMLSurfaceOptionsItem
            End Function
        End Class

        Private oSurvey As cSurvey

        Private bVisible As Boolean

        Private oElevation As cSurface3DOptionsElevationItem
        Private oItems As cSurface3DOptionsBaseCollection

        Public Property DrawSurface As Boolean
            Get
                Return bVisible
            End Get
            Set(value As Boolean)
                If value <> bVisible Then
                    bVisible = value
                    Call PropertyChanged("DrawSurface")
                End If
            End Set
        End Property

        Public Sub SetElevation(ID As String)
            If oSurvey.Surface.Contains(ID) Then
                If oElevation Is Nothing Then
                    oElevation = New cSurface3DOptionsElevationItem(ID)
                Else
                    Call oElevation.ChangeID(ID)
                End If
                Call PropertyChanged("Elevation")
            End If
        End Sub

        Public Sub SetElevation(SurfaceItem As Surface.cISurfaceItem)
            If oSurvey.Surface.Contains(SurfaceItem) Then
                oElevation = New cSurface3DOptionsElevationItem(SurfaceItem.ID)
                Call PropertyChanged("Elevation")
            End If
        End Sub

        Public Sub ResetElevation()
            Call oElevation.ChangeID("")
            Call PropertyChanged("Elevation")
        End Sub

        Public ReadOnly Property Elevation As cSurface3DOptionsElevationItem
            Get
                Return oElevation
            End Get
        End Property

        Public Sub Rebind()
            For i As Integer = oItems.Count - 1 To 0 Step -1
                Dim oItem As cSurface3DOptionsItem = oItems(i)
                If Not oSurvey.Surface.Contains(oItem.ID) Then
                    Call oItems.RemoveAt(i)
                End If
            Next
            Dim oSurfaceItems As List(Of Surface.cISurfaceItem) = New List(Of Surface.cISurfaceItem)
            For Each oSurfaceItem As Surface.cISurfaceItem In oSurvey.Surface.OrthoPhotos
                Call oSurfaceItems.Add(oSurfaceItem)
            Next
            For Each oSurfaceItem As Surface.cISurfaceItem In oSurvey.Surface.WMSs
                Call oSurfaceItems.Add(oSurfaceItem)
            Next
            For Each oSurfaceItem As Surface.cISurfaceItem In oSurfaceItems
                If Not oItems.Contains(oSurfaceItem.ID) Then
                    Dim oItem As cSurface3DOptionsItem = New cSurface3DOptionsItem(oSurfaceItem.ID)
                    Call oItems.Add(oItem)
                End If
            Next
        End Sub

        Public Function IndexOf(Item As cSurface3DOptionsItem) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Public Function MoveUp(Item As cSurface3DOptionsItem) As Boolean
            Dim iIndex As Integer = oItems.IndexOf(Item)
            If iIndex > 0 Then
                Call oItems.RemoveAt(iIndex)
                Call oItems.Insert(iIndex - 1, Item)
                Return True
            Else
                Return False
            End If
        End Function

        Public Function MoveDown(Item As cSurface3DOptionsItem) As Boolean
            Dim iIndex As Integer = oItems.IndexOf(Item)
            If iIndex < oItems.Count - 1 Then
                Call oItems.RemoveAt(iIndex)
                Call oItems.Insert(iIndex + 1, Item)
                Return True
            Else
                Return False
            End If
        End Function

        Default Public ReadOnly Property Item(Index As Integer) As cSurface3DOptionsItem
            Get
                If Index >= 0 AndAlso Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Default Public ReadOnly Property Item(ID As String) As cSurface3DOptionsItem
            Get
                If oItems.Contains(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Default Public ReadOnly Property Item(SurfaceItem As Surface.cISurfaceItem) As cSurface3DOptionsItem
            Get
                Return Item(SurfaceItem.ID)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Sub CopyFrom(ByVal SurfaceOptions As cSurface3DOptions)
            For Each oOldItem As cSurface3DOptionsItem In SurfaceOptions.oItems
                Dim oItem As cSurface3DOptionsItem = oOldItem.Clone
                Call oItems.Add(oItem.Clone)
            Next
            If SurfaceOptions.Elevation Is Nothing Then
                oElevation = New cSurface3DOptionsElevationItem("")
            Else
                oElevation = SurfaceOptions.Elevation.Clone
            End If
            bVisible = SurfaceOptions.bVisible
        End Sub

        Friend Function Clone() As cSurface3DOptions
            Return New cSurface3DOptions(Me)
        End Function

        Friend Sub New(ByVal SurfaceOptions As cSurface3DOptions)
            oSurvey = SurfaceOptions.oSurvey
            oItems = New cSurface3DOptionsBaseCollection
            Call CopyFrom(SurfaceOptions)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cSurface3DOptionsBaseCollection
            oElevation = New cSurface3DOptionsElevationItem("")
            bVisible = False
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub Import(ByVal SurfaceOptions As XmlElement)
            bVisible = modXML.GetAttributeValue(SurfaceOptions, "visible", 0)
            For Each oXMLChild As XmlElement In SurfaceOptions.SelectNodes("surface3doptionsitem")
                Dim oItem As cSurface3DOptionsItem = New cSurface3DOptionsItem(oXMLChild)
                Call oItems.Add(oItem)
            Next
            If modXML.ChildElementExist(SurfaceOptions, "elevation") Then
                oElevation = New cSurface3DOptionsElevationItem(SurfaceOptions.Item("elevation").FirstChild)
            Else
                oElevation = New cSurface3DOptionsElevationItem("")
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal SurfaceOptions As XmlElement)
            oSurvey = Survey
            oItems = New cSurface3DOptionsBaseCollection
            Call Import(SurfaceOptions)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLSurfaceOptions As XmlElement = Document.CreateElement("surface3doptions")
            If bVisible Then oXMLSurfaceOptions.SetAttribute("visible", 1)
            For Each oItem As cSurface3DOptionsItem In oItems
                Call oItem.SaveTo(File, Document, oXMLSurfaceOptions)
            Next

            If oElevation.ID <> "" Then
                Dim oXMLSurfaceOptionsElevation As XmlElement = Document.CreateElement("elevation")
                Call oElevation.SaveTo(File, Document, oXMLSurfaceOptionsElevation)
                Call oXMLSurfaceOptions.AppendChild(oXMLSurfaceOptionsElevation)
            End If

            Call Parent.AppendChild(oXMLSurfaceOptions)
            Return oXMLSurfaceOptions
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
