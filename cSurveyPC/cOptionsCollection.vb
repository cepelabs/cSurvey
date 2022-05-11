Imports cSurveyPC.cSurvey.Design.Items
Imports System.Xml

Namespace cSurvey.Design
    Public Class cOptionsCollection
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As Dictionary(Of String, cOptions)

        Friend Sub Append(Item As cOptions)
            If Not Item.Name.StartsWith("_") Then
                If Not oItems.ContainsKey(Item.Name) Then
                    Call oItems.Add(Item.Name, Item)
                End If
            End If
        End Sub

        Friend Sub Remove(Item As cOptions)
            If Not Item.Name.StartsWith("_") Then
                If oItems.ContainsKey(Item.Name) Then
                    Call oItems.Remove(Item.Name)
                End If
            End If
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cOptions)

            Call oItems.Add("_design.plan", New cOptionsDesign(oSurvey, "_design.plan"))
            Call oItems.Add("_design.profile", New cOptionsDesign(oSurvey, "_design.profile"))

            Call oItems.Add("_design.3d", New cOptions3D(oSurvey, "_design.3d"))

            Call oItems.Add("_viewer.plan", New cOptionsViewer(oSurvey, "_viewer.plan"))
            Call oItems.Add("_viewer.profile", New cOptionsViewer(oSurvey, "_viewer.profile"))

            Call oItems.Add("_preview.plan", New cOptionsPreview(oSurvey, "_preview.plan"))
            Call oItems.Add("_preview.profile", New cOptionsPreview(oSurvey, "_preview.profile"))

            Call oItems.Add("_export.plan", New cOptionsExport(oSurvey, "_export.plan"))
            Call oItems.Add("_export.profile", New cOptionsExport(oSurvey, "_export.profile"))
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Options As XmlElement)
            oSurvey = Survey
            oItems = New Dictionary(Of String, cOptions)

            Try
                Call oItems.Add("_design.plan", New cOptionsDesign(oSurvey, Options.Item("_design.plan")))
            Catch
                Call oItems.Add("_design.plan", New cOptionsDesign(oSurvey, "_design.plan"))
            End Try
            Try
                Call oItems.Add("_design.profile", New cOptionsDesign(oSurvey, Options.Item("_design.profile")))
            Catch
                Call oItems.Add("_design.profile", New cOptionsDesign(oSurvey, "_design.profile"))
            End Try

            Try
                Call oItems.Add("_design.3d", New cOptions3D(oSurvey, Options.Item("_design.3d")))
            Catch
                Call oItems.Add("_design.3d", New cOptions3D(oSurvey, "_design.3d"))
            End Try

            Try
                Call oItems.Add("_viewer.plan", New cOptionsViewer(oSurvey, Options.Item("_viewer.plan")))
            Catch
                Call oItems.Add("_viewer.plan", New cOptionsViewer(oSurvey, "_viewer.plan"))
            End Try
            Try
                Call oItems.Add("_viewer.profile", New cOptionsViewer(oSurvey, Options.Item("_viewer.profile")))
            Catch
                Call oItems.Add("_viewer.profile", New cOptionsViewer(oSurvey, "_viewer.profile"))
            End Try

            Try
                Call oItems.Add("_preview.plan", New cOptionsPreview(oSurvey, Options.Item("_preview.plan")))
            Catch
                Call oItems.Add("_preview.plan", New cOptionsPreview(oSurvey, "_preview.plan"))
            End Try
            Try
                Call oItems.Add("_preview.profile", New cOptionsPreview(oSurvey, Options.Item("_preview.profile")))
            Catch
                Call oItems.Add("_preview.profile", New cOptionsPreview(oSurvey, "_preview.profile"))
            End Try

            Try
                Call oItems.Add("_export.plan", New cOptionsExport(oSurvey, Options.Item("_export.plan")))
            Catch
                Call oItems.Add("_export.plan", New cOptionsExport(oSurvey, "_export.plan"))
            End Try
            Try
                Call oItems.Add("_export.profile", New cOptionsExport(oSurvey, Options.Item("_export.profile")))
            Catch
                Call oItems.Add("_export.profile", New cOptionsExport(oSurvey, "_export.profile"))
            End Try
        End Sub

        Default ReadOnly Property Item(ByVal Name As String) As cOptions
            Get
                Return oItems(Name)
            End Get
        End Property

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.Values.GetEnumerator
        End Function

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXMLOptions As XmlElement = Document.CreateElement("options")
            For Each oItem As cOptions In oItems.Values
                Call oItem.SaveTo(File, Document, oXMLOptions)
            Next
            Call Parent.AppendChild(oXMLOptions)
            Return oXMLOptions
        End Function
    End Class
End Namespace