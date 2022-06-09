Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cSurfaceOptions
        Implements IEnumerable
        Implements cIUIBaseInteractions

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

        Friend Class cSurfaceOptionsBaseCollection
            Inherits KeyedCollection(Of String, cSurfaceOptionsItem)

            Protected Overrides Function GetKeyForItem(ByVal item As cSurfaceOptionsItem) As String
                Return item.ID
            End Function
        End Class

        Public Class cSurfaceOptionsItem
            Inherits cSurfaceBaseOptionsItem
            Implements cISurfaceOptionsItem

            Private bVisible As Boolean
            Private sMinScale As Single?
            Private sMaxScale As Single?
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

            Public Property MinScale As Single?
                Get
                    Return sMinScale
                End Get
                Set(value As Single?)
                    sMinScale = value
                End Set
            End Property

            Public Property MaxScale As Single?
                Get
                    Return sMaxScale
                End Get
                Set(value As Single?)
                    sMaxScale = value
                End Set
            End Property

            Friend Sub New(ID As String)
                MyBase.New(ID)
            End Sub

            Friend Sub New(Item As XmlElement)
                MyBase.New(Item)
                bVisible = Item.GetAttribute("visible")
                sTransparency = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "transparency", "0"))
                If Item.HasAttribute("minscale") Then sMinScale = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "minscale", "0"))
                If Item.HasAttribute("maxscale") Then sMaxScale = modNumbers.StringToSingle(modXML.GetAttributeValue(Item, "maxscale", "0"))
            End Sub

            Friend Function Clone() As cSurfaceOptionsItem
                Dim oItem As cSurfaceOptionsItem = New cSurfaceOptionsItem(MyBase.ID)
                oItem.bVisible = bVisible
                oItem.sTransparency = sTransparency
                oItem.sMinScale = sMinScale
                oItem.sMaxScale = sMaxScale
                Return oItem
            End Function

            Friend Shadows Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXMLSurfaceOptionsItem As XmlElement = MyBase.SaveTo("surfaceoptionsitem", File, Document, Parent)
                Call oXMLSurfaceOptionsItem.SetAttribute("visible", If(bVisible, "1", "0"))
                If sTransparency > 0 Then Call oXMLSurfaceOptionsItem.SetAttribute("transparency", modNumbers.NumberToString(sTransparency))
                If sMinScale.HasValue Then Call oXMLSurfaceOptionsItem.SetAttribute("minscale", modNumbers.NumberToString(sMinScale.Value, "0"))
                If sMaxScale.HasValue Then Call oXMLSurfaceOptionsItem.SetAttribute("maxscale", modNumbers.NumberToString(sMaxScale.Value, "0"))
                Call Parent.AppendChild(oXMLSurfaceOptionsItem)
                Return oXMLSurfaceOptionsItem
            End Function
        End Class

        Private oSurvey As cSurvey

        Private bVisible As Boolean

        Private oItems As cSurfaceOptionsBaseCollection

        Public Property DrawSurface As Boolean
            Get
                Return bVisible
            End Get
            Set(value As Boolean)
                If bVisible <> value Then
                    bVisible = value
                    Call PropertyChanged("DrawSurface")
                End If
            End Set
        End Property

        Public Sub Rebind()
            For i As Integer = oItems.Count - 1 To 0 Step -1
                Dim oItem As cSurfaceOptionsItem = oItems(i)
                If Not oSurvey.Surface.Contains(oItem.ID) Then
                    Call oItems.RemoveAt(i)
                End If
            Next
            For Each oSurfaceItem As Surface.cISurfaceItem In oSurvey.Surface
                If Not oItems.Contains(oSurfaceItem.ID) Then
                    Dim oItem As cSurfaceOptionsItem = New cSurfaceOptionsItem(oSurfaceItem.ID)
                    Call oItems.Add(oItem)
                End If
            Next
        End Sub

        Public Function MoveUp(Item As cSurfaceOptionsItem) As Boolean
            Dim iIndex As Integer = oItems.IndexOf(Item)
            If iIndex > 0 Then
                Call oItems.RemoveAt(iIndex)
                Call oItems.Insert(iIndex - 1, Item)
                Return True
            Else
                Return False
            End If
        End Function

        Public Function MoveDown(Item As cSurfaceOptionsItem) As Boolean
            Dim iIndex As Integer = oItems.IndexOf(Item)
            If iIndex < oItems.Count - 1 Then
                Call oItems.RemoveAt(iIndex)
                Call oItems.Insert(iIndex + 1, Item)
                Return True
            Else
                Return False
            End If
        End Function

        Default Public ReadOnly Property Item(Index As Integer) As cSurfaceOptionsItem
            Get
                If Index >= 0 And Index < oItems.Count Then
                    Return oItems(Index)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Default Public ReadOnly Property Item(ID As String) As cSurfaceOptionsItem
            Get
                If oItems.Contains(ID) Then
                    Return oItems(ID)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function IndexOf(Item As cSurfaceOptionsItem) As Integer
            Return oItems.IndexOf(Item)
        End Function

        Default Public ReadOnly Property Item(SurfaceItem As Surface.cISurfaceItem) As cSurfaceOptionsItem
            Get
                Return Item(SurfaceItem.ID)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Friend Sub CopyFrom(ByVal SurfaceOptions As cSurfaceOptions)
            For Each oOldItem As cSurfaceOptionsItem In SurfaceOptions.oItems
                Dim oItem As cSurfaceOptionsItem = oOldItem.Clone
                Call oItems.Add(oItem.Clone)
            Next
            bVisible = SurfaceOptions.bVisible
        End Sub

        Friend Function Clone() As cSurfaceOptions
            Return New cSurfaceOptions(Me)
        End Function

        Friend Sub New(ByVal SurfaceOptions As cSurfaceOptions)
            oSurvey = SurfaceOptions.oSurvey
            oItems = New cSurfaceOptionsBaseCollection
            Call CopyFrom(SurfaceOptions)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cSurfaceOptionsBaseCollection
            bVisible = False
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub Import(ByVal SurfaceOptions As XmlElement)
            bVisible = modXML.GetAttributeValue(SurfaceOptions, "visible", 0)
            For Each oXMLChild As XmlElement In SurfaceOptions.ChildNodes
                Dim oItem As cSurfaceOptionsItem = New cSurfaceOptionsItem(oXMLChild)
                Call oItems.Add(oItem)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal SurfaceOptions As XmlElement)
            oSurvey = Survey
            oItems = New cSurfaceOptionsBaseCollection
            Call Import(SurfaceOptions)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLSurfaceOptions As XmlElement = Document.CreateElement("surfaceoptions")
            If bVisible Then oXMLSurfaceOptions.SetAttribute("visible", 1)
            For Each oItem As cSurfaceOptionsItem In oItems
                Call oItem.SaveTo(File, Document, oXMLSurfaceOptions)
            Next
            Call Parent.AppendChild(oXMLSurfaceOptions)
            Return oXMLSurfaceOptions
        End Function

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
