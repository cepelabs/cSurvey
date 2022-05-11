Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports cSurveyPC.cSurvey.Drawings
Imports System.Collections.ObjectModel

Imports cSurveyPC.cSurvey.Design.Items

Namespace cSurvey.Design
    Friend Class cDesignSketchBaseCollection
        Inherits KeyedCollection(Of String, cDesignSketch)

        Protected Overrides Function GetKeyForItem(ByVal item As cDesignSketch) As String
            Return item.ID
        End Function
    End Class

    Friend Class cDesignSketchXVIReader
        Public Class cXVIStation
            Public Location As PointF
            Public Name As String
            Public Sub New(ByVal Name As String, ByVal Location As PointF)
                Me.Name = Name
                Me.Location = Location
            End Sub
        End Class

        Public Class cXVIStations
            Public Sub New()
                Stations = New SortedDictionary(Of String, cXVIStation)
            End Sub
            Public Stations As SortedDictionary(Of String, cXVIStation)
            'Public Stations As List(Of cXVIStation)
        End Class

        Public Class cXVIImage
            Public Location As PointF
            Public Image As Drawing.Image

            Public Sub New(ByVal Location As PointF, ByVal Image As Drawing.Image)
                Me.Location = Location
                Me.Image = Image
            End Sub
        End Class

        Public Class cXVIImages
            Public Sub New()
                Images = New List(Of cXVIImage)
            End Sub
            Public Images As List(Of cXVIImage)
        End Class

        Private oImages As cXVIImages
        Private oStations As cXVIStations

        Public Sub New(ByVal Survey As cSurvey, ByVal Filename As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing)
            Call Load(Filename, Dictionary)
        End Sub

        Public Sub Load(ByVal Filename As String, Optional ByVal Dictionary As IDictionary(Of String, String) = Nothing)
            Call Clear()
            '--------------------------------------------------------------------------------------
            Dim oSR As IO.StreamReader = My.Computer.FileSystem.OpenTextFileReader(Filename)
            Dim sDatas() As String = oSR.ReadToEnd.Replace(vbCrLf, " ").Replace("{", " { ").Replace("}", " } ").Split(" ")
            Call oSR.Close()
            Call oSR.Dispose()

            Dim iDataIndex As Integer = 0
            Dim sCurrentSet As String = ""

            Do
                Dim sData As String = pGetNextData(sDatas, iDataIndex)
                Select Case sData
                    Case "set"
                        sCurrentSet = pGetNextData(sDatas, iDataIndex)
                        Select Case sCurrentSet
                            Case "XVIgrids"
                            Case "XVIstations"
                                If pGetNextData(sDatas, iDataIndex) = "{" Then
                                    Do
                                        If pGetNextData(sDatas, iDataIndex) = "{" Then
                                            Dim x As Single = modNumbers.StringToSingle(pGetNextData(sDatas, iDataIndex))
                                            Dim y As Single = modNumbers.StringToSingle(pGetNextData(sDatas, iDataIndex))
                                            Dim sName As String = pGetNextData(sDatas, iDataIndex)
                                            If sName.Contains("@") Then
                                                sName = sName.Substring(0, sName.IndexOf("@"))
                                            End If
                                            sName = modExport.DictionaryTranslate(Dictionary, sName)
                                            Dim oStation As cXVIStation = New cXVIStation(sName, New PointF(x, y))
                                            If Not oStations.Stations.ContainsKey(sName) Then
                                                Call oStations.Stations.Add(sName, oStation)
                                            End If
                                            Call pGetNextData(sDatas, iDataIndex)
                                        Else
                                            Exit Do
                                        End If
                                    Loop
                                End If
                            Case "XVIimages"
                                If pGetNextData(sDatas, iDataIndex) = "{" Then
                                    Do
                                        If pGetNextData(sDatas, iDataIndex) = "{" Then
                                            Dim x As Single = modNumbers.StringToSingle(pGetNextData(sDatas, iDataIndex))
                                            Dim y As Single = modNumbers.StringToSingle(pGetNextData(sDatas, iDataIndex))
                                            If pGetNextData(sDatas, iDataIndex) = "{" Then
                                                Dim sImageData As System.Text.StringBuilder = New System.Text.StringBuilder
                                                Dim oImageData As Drawing.Bitmap
                                                Do
                                                    Dim sImageDataItem As String = pGetNextData(sDatas, iDataIndex)
                                                    If sImageDataItem = "}" Then
                                                        Dim bBuffer() As Byte = Convert.FromBase64String(sImageData.ToString)
                                                        oImageData = New Drawing.Bitmap(New MemoryStream(bBuffer))
                                                        Exit Do
                                                    Else
                                                        Call sImageData.Append(sImageDataItem)
                                                    End If
                                                Loop

                                                Dim oImage As cXVIImage = New cXVIImage(New PointF(x, y), oImageData)
                                                Call oImages.Images.Add(oImage)
                                                Call pGetNextData(sDatas, iDataIndex)
                                            End If
                                        Else
                                            Exit Do
                                        End If
                                    Loop
                                End If
                        End Select
                End Select
            Loop While iDataIndex <= sDatas.Length - 1
        End Sub

        Public ReadOnly Property Stations As cXVIStations
            Get
                Return oStations
            End Get
        End Property

        Public ReadOnly Property Images As cXVIImages
            Get
                Return oImages
            End Get
        End Property

        Public Sub Clear()
            oImages = New cXVIImages
            oStations = New cXVIStations
        End Sub

        Private Function pGetNextData(ByVal Data() As String, ByRef DataIndex As Integer) As String
            If DataIndex < Data.Length - 1 Then
                Do While DataIndex < Data.Length - 1
                    DataIndex += 1
                    Dim sData As String = Data(DataIndex)
                    If sData.Trim <> "" Then
                        Return sData
                    End If
                Loop
            Else
                DataIndex += 1
                Return ""
            End If
        End Function

        Public Function GetTransformation(ByVal XVIStation1 As cXVIStation, ByVal Point1 As PointF, ByVal XVIStation2 As cXVIStation, ByVal Point2 As PointF) As Matrix
            Return GetTransformation(XVIStation1.Location, Point1, XVIStation2.Location, Point2)
        End Function

        Public Function GetTransformation(ByVal XVIPoint1 As PointF, ByVal Point1 As PointF, ByVal XVIPoint2 As PointF, ByVal Point2 As PointF) As Matrix
            Dim oMatrix As Matrix = New Matrix
            Dim sDeltaX As Single = XVIPoint1.X - Point1.X
            Dim sDeltay As Single = XVIPoint1.Y - Point1.Y
            Dim sDeltaSize As Single = modPaint.DistancePointToPoint(Point1, Point2) / modPaint.DistancePointToPoint(XVIPoint1, XVIPoint2)
            Call oMatrix.Translate(sDeltaX, sDeltay, MatrixOrder.Append)
            Call oMatrix.Scale(sDeltaSize, sDeltaSize, MatrixOrder.Append)
            Return oMatrix
        End Function
    End Class

    Public Class cDesignSketches
        Implements IEnumerable

        Private oSurvey As cSurvey
        Private oItems As cDesignSketchBaseCollection

        Public Class cCorrection
            Private sScale As Single
            Private oTranslation As PointF

            Friend Sub New(ByVal Scale As Single, ByVal Translation As PointF)
                sScale = Scale
                oTranslation = Translation
            End Sub

            Friend Sub New(ByVal Scale As Single, ByVal TranslationX As Single, ByVal TranslationY As Single)
                sScale = Scale
                oTranslation = New PointF(TranslationX, TranslationY)
            End Sub

            Public ReadOnly Property Translation As PointF
                Get
                    Return oTranslation
                End Get
            End Property

            Public ReadOnly Property Scale As Single
                Get
                    Return sScale
                End Get
            End Property
        End Class

        Public Function GetCorrections(ByVal Type As cIDesign.cDesignTypeEnum) As cCorrection
            Select Case Type
                Case cIDesign.cDesignTypeEnum.Plan
                    Return New cCorrection(oSurvey.Properties.DesignProperties.GetValue("DesignSketchPlanCorrectionScale", 1), oSurvey.Properties.DesignProperties.GetValue("DesignSketchPlanCorrectionX", 0), oSurvey.Properties.DesignProperties.GetValue("DesignSketchPlanCorrectionY", 0))
                Case cIDesign.cDesignTypeEnum.Profile
                    Return New cCorrection(oSurvey.Properties.DesignProperties.GetValue("DesignSketchProfileScale", 1), oSurvey.Properties.DesignProperties.GetValue("DesignSketchProfileCorrectionX", 0), oSurvey.Properties.DesignProperties.GetValue("DesignSketchProfileCorrectionY", 0))
            End Select
        End Function

        Public ReadOnly Property Count As Integer
            Get
                Return oItems.Count
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cDesignSketch
            Get
                Return oItems(Index)
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal ID As String) As cDesignSketch
            Get
                Return oItems(ID)
            End Get
        End Property

        Public Function ToArray() As cDesignSketch()
            Return oItems.ToArray
        End Function

        Public Function Contains(ByVal Sketch As cItemSketch) As Boolean
            For Each oItem As cDesignSketch In oItems
                If oItem.Sketch Is Sketch Then
                    Return True
                End If
            Next
        End Function

        Public Function Find(ByVal Sketch As cItemSketch) As cDesignSketch
            For Each oItem As cDesignSketch In oItems
                If oItem.Sketch Is Sketch Then
                    Return oItem
                End If
            Next
        End Function

        Public Function Contains(ByVal ID As String) As Boolean
            Try
                Dim oItem As cDesignSketch = oItems(ID)
                Return True
            Catch
                Return False
            End Try
        End Function

        Public Function Contains(ByVal Sketch As cDesignSketch) As Boolean
            Return oItems.Contains(Sketch)
        End Function

        Friend Function Add(ByVal Sketch As cItemSketch) As cDesignSketch
            Dim oItem As cDesignSketch = New cDesignSketch(oSurvey, Sketch)
            Call oItems.Add(oItem)
            Return oItem
        End Function

        Public Sub Rebind(Optional ByVal RemoveOrphans As Boolean = True)
            Dim oDesignItems As List(Of cItem) = New List(Of cItem)
            Call oDesignItems.AddRange(oSurvey.Plan.GetAllItems())
            Call oDesignItems.AddRange(oSurvey.Profile.GetAllItems())

            'verifico gli elementi da eliminare e quelli già presenti nella collection
            Dim oItemsToCheck As List(Of cItemSketch) = New List(Of cItemSketch)
            Dim oItemsToDelete As List(Of cDesignSketch) = New List(Of cDesignSketch)
            For Each oItem As cDesignSketch In oItems
                If Not oDesignItems.Contains(oItem.Sketch) Then
                    Call oItemsToDelete.Add(oItem)
                Else
                    Call oItemsToCheck.Add(oItem.Sketch)
                End If
            Next
            'cerco gli elementi grafici NON già presenti nella collection (quelli da aggiungere)
            For Each oItem As cItem In oDesignItems
                If oItem.Type = cIItem.cItemTypeEnum.Sketch Then
                    If Not oItemsToCheck.Contains(oItem) Then
                        Call Add(oItem)
                    End If
                End If
            Next
            'elimino gli elementi che sono stati individuati come da cancellare
            If RemoveOrphans Then
                For Each oItemToDelete As cDesignSketch In oItemsToDelete
                    Call oItems.Remove(oItemToDelete)
                Next
            End If

            Call RebindSketches()
        End Sub

        Friend Sub RebindSketches()
            For Each oItem As cDesignSketch In oItems
                Call oItem.RebindSketch()
            Next
        End Sub

        Friend Sub CollectGarbage()
            Dim oItemsToDelete As List(Of cDesignSketch) = New List(Of cDesignSketch)
            For Each oItem As cDesignSketch In oItems
                If oItem.Sketch.Deleted Then
                    Call oItemsToDelete.Add(oItem)
                End If
            Next
            For Each oitem As cDesignSketch In oItemsToDelete
                Call oItems.Remove(oitem)
            Next
        End Sub

        Friend Sub Calculate(Optional ByVal PerformWarping As Boolean = True)
            Call CollectGarbage()
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, ByVal Sketches As XmlElement)
            oSurvey = Survey
            oItems = New cDesignSketchBaseCollection

            For Each oXMLItem As XmlElement In Sketches.ChildNodes
                Dim oSketch As cDesignSketch = New cDesignSketch(oSurvey, oXMLItem)
                Call oItems.Add(oSketch)
            Next
        End Sub

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
            oItems = New cDesignSketchBaseCollection
        End Sub

        Friend Overridable Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlCrossSections As XmlElement = Document.CreateElement("sketches")
            For Each oItem As cDesignSketch In oItems
                Call oItem.SaveTo(File, Document, oXmlCrossSections)
            Next
            Call Parent.AppendChild(oXmlCrossSections)
            Return oXmlCrossSections
        End Function

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oItems.GetEnumerator
        End Function
    End Class
End Namespace
