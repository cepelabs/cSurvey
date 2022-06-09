Imports cSurveyPC.cSurvey.Drawings
Imports cSurveyPC.cSurvey.Scale
Imports cSurveyPC.cSurvey.Design.Items

Imports System.Xml
Imports System.Collections.ObjectModel

Namespace cSurvey.Design.Options
    Public Class cSurfaceTherionOptions
        Implements cIUIBaseInteractions

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

        Public Class cSurfaceTherionOptionsItem
            Inherits Options.cSurfaceBaseOptionsItem

            Friend Sub New(ID As String)
                MyBase.New(ID)
            End Sub
            Friend Sub New(Item As XmlElement)
                MyBase.New(Item)
            End Sub

            Friend Overridable Function Clone() As cSurfaceTherionOptionsItem
                Dim oItem As cSurfaceTherionOptionsItem = New cSurfaceTherionOptionsItem(MyBase.ID)
                Return oItem
            End Function

            Friend Shadows Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
                Dim oXMLSurfaceOptionsItem As XmlElement = MyBase.SaveTo("surfaceTherionoptionsitem", File, Document, Parent)
                Call Parent.AppendChild(oXMLSurfaceOptionsItem)
                Return oXMLSurfaceOptionsItem
            End Function
        End Class

        Private oSurvey As cSurvey

        Private oElevation As cSurfaceTherionOptionsItem
        Private oOrthophoto As cSurfaceTherionOptionsItem

        Public ReadOnly Property DrawSurface As Boolean
            Get
                Return oElevation.ID <> ""
            End Get
        End Property

        Public Sub SetElevation(ID As String)
            If oSurvey.Surface.Contains(ID) Then
                If oElevation Is Nothing Then
                    oElevation = New cSurfaceTherionOptionsItem(ID)
                Else
                    Call oElevation.ChangeID(ID)
                End If
                Call PropertyChanged("Elevation")
            End If
        End Sub

        Public Sub SetElevation(SurfaceItem As Surface.cISurfaceItem)
            If oSurvey.Surface.Contains(SurfaceItem) Then
                oElevation = New cSurfaceTherionOptionsItem(SurfaceItem.ID)
                Call PropertyChanged("Elevation")
            End If
        End Sub

        Public Sub ResetElevation()
            Call oElevation.ChangeID("")
            Call PropertyChanged("Elevation")
        End Sub

        Public ReadOnly Property Elevation As cSurfaceTherionOptionsItem
            Get
                Return oElevation
            End Get
        End Property

        Public Sub SetOrthophoto(ID As String)
            If oSurvey.Surface.Contains(ID) Then
                If oOrthophoto Is Nothing Then
                    oOrthophoto = New cSurfaceTherionOptionsItem(ID)
                Else
                    Call oOrthophoto.ChangeID(ID)
                End If
                Call PropertyChanged("Orthophoto")
            End If
        End Sub

        Public Sub SetOrthophoto(SurfaceItem As Surface.cISurfaceItem)
            If oSurvey.Surface.Contains(SurfaceItem) Then
                oOrthophoto = New cSurfaceTherionOptionsItem(SurfaceItem.ID)
                Call PropertyChanged("Orthophoto")
            End If
        End Sub

        Public Sub ResetOrthophoto()
            Call oOrthophoto.ChangeID("")
            Call PropertyChanged("Orthophoto")
        End Sub

        Public ReadOnly Property Orthophoto As cSurfaceTherionOptionsItem
            Get
                Return oOrthophoto
            End Get
        End Property

        Public Sub Rebind()

        End Sub

        Friend Sub CopyFrom(ByVal SurfaceOptions As cSurfaceTherionOptions)
            If SurfaceOptions.Elevation Is Nothing Then
                oElevation = New cSurfaceTherionOptionsItem("")
            Else
                oElevation = SurfaceOptions.Elevation.Clone
            End If
            If SurfaceOptions.Orthophoto Is Nothing Then
                oOrthophoto = New cSurfaceTherionOptionsItem("")
            Else
                oOrthophoto = SurfaceOptions.Orthophoto.Clone
            End If
        End Sub

        Friend Function Clone() As cSurfaceTherionOptions
            Return New cSurfaceTherionOptions(Me)
        End Function

        Friend Sub New(ByVal SurfaceOptions As cSurfaceTherionOptions)
            oSurvey = SurfaceOptions.oSurvey
            Call CopyFrom(SurfaceOptions)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oElevation = New cSurfaceTherionOptionsItem("")
            oOrthophoto = New cSurfaceTherionOptionsItem("")
        End Sub

        Friend ReadOnly Property Survey As cSurvey
            Get
                Return oSurvey
            End Get
        End Property

        Friend Sub Import(ByVal SurfaceOptions As XmlElement)
            If modXML.ChildElementExist(SurfaceOptions, "elevation") Then
                oElevation = New cSurfaceTherionOptionsItem(SurfaceOptions.Item("elevation").FirstChild)
            Else
                oElevation = New cSurfaceTherionOptionsItem("")
            End If
            If modXML.ChildElementExist(SurfaceOptions, "orthophoto") Then
                oOrthophoto = New cSurfaceTherionOptionsItem(SurfaceOptions.Item("orthophoto").FirstChild)
            Else
                oOrthophoto = New cSurfaceTherionOptionsItem("")
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal SurfaceOptions As XmlElement)
            oSurvey = Survey
            Call Import(SurfaceOptions)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLSurfaceOptions As XmlElement = Document.CreateElement("surfacetherionoptions")

            If oElevation.ID <> "" Then
                Dim oXMLSurfaceOptionsElevation As XmlElement = Document.CreateElement("elevation")
                Call oElevation.SaveTo(File, Document, oXMLSurfaceOptionsElevation)
                Call oXMLSurfaceOptions.AppendChild(oXMLSurfaceOptionsElevation)
            End If

            If oOrthophoto.ID <> "" Then
                Dim oXMLSurfaceOptionsOrthophoto As XmlElement = Document.CreateElement("orthophoto")
                Call oOrthophoto.SaveTo(File, Document, oXMLSurfaceOptionsOrthophoto)
                Call oXMLSurfaceOptions.AppendChild(oXMLSurfaceOptionsOrthophoto)
            End If

            Call Parent.AppendChild(oXMLSurfaceOptions)
            Return oXMLSurfaceOptions
        End Function
    End Class
End Namespace
