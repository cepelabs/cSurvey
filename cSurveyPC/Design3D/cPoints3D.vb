Imports System.Xml

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Media.Media3D

Namespace cSurvey.Design.Design3D
    Public Class cPoints3D
        Implements IEnumerable
        Implements IEnumerable(Of cPoint3D)

        Private oSurvey As cSurvey
        Private oItem As cItem3D

        Private oPoints As List(Of cPoint3D)

        Private bChanged As Boolean

        Friend Event OnChanged(ByVal Sender As cPoints3D)


        Public Function Contains(Point As cPoint3D) As Boolean
            Return oPoints.Contains(Point)
        End Function

        Public ReadOnly Property First() As cPoint3D
            Get
                If oPoints.Count > 0 Then
                    Return oPoints(0)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public ReadOnly Property Last() As cPoint3D
            Get
                If oPoints.Count > 0 Then
                    Return oPoints(oPoints.Count - 1)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Function [Next](Point As cPoint3D) As cPoint3D
            If Point Is oPoints.Last Then
                Return Nothing
            Else
                Return oPoints(oPoints.IndexOf(Point) + 1)
            End If
        End Function

        Public Function [Previous](Point As cPoint3D) As cPoint3D
            If Point Is oPoints.First Then
                Return Nothing
            Else
                Return oPoints(oPoints.IndexOf(Point) - 1)
            End If
        End Function

        Public Function Remove(ByVal Point As cPoint3D) As Boolean
            oPoints.Remove(Point)
        End Function

        Public Function RemoveAt(ByVal Index As Integer) As Boolean
            If Index >= 0 And Index < oPoints.Count Then
                Return Remove(oPoints(Index))
            End If
        End Function

        Default Public ReadOnly Property Item(ByVal Index As Integer) As cPoint3D
            Get
                Return oPoints(Index)
            End Get
        End Property

        Public Sub Clear()
            Call oPoints.Clear()
        End Sub

        Public ReadOnly Property Count() As Integer
            Get
                Return oPoints.Count
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return oPoints.GetEnumerator
        End Function

        Public Function IndexOf(ByVal Point As cPoint3D) As Integer
            Return oPoints.IndexOf(Point)
        End Function

        Friend Sub New(ByVal Survey As cSurvey, Item As cItem3D)
            oSurvey = Survey
            oItem = Item
            oPoints = New List(Of cPoint3D)
        End Sub

        Friend Sub New(ByVal Survey As cSurvey, Item As cItem3D, ByVal Points As XmlElement)
            oSurvey = Survey
            oItem = Item
            oPoints = New List(Of cPoint3D)
            If Points.HasAttribute("data") Then
                Dim sData As String = Points.GetAttribute("data")
                If sData.Length > 0 Then
                    Dim sChar As Char
                    Dim iChar As Integer = 0
                    Dim sValue As String = ""

                    Dim sX As Single
                    Dim sY As Single
                    Dim sZ As Single

                    Do
                        sValue = ""
                        Do
                            sChar = sData(iChar)
                            If sChar <> " " Then
                                sValue = sValue & sChar
                            End If
                            iChar += 1
                        Loop Until sChar = " "
                        sX = modNumbers.StringToDecimal(sValue)

                        sValue = ""
                        Do
                            sChar = sData(iChar)
                            If sChar <> " " Then
                                sValue = sValue & sChar
                            End If
                            iChar += 1
                        Loop Until sChar = " "
                        sY = modNumbers.StringToDecimal(sValue)

                        sValue = ""
                        Do
                            sChar = sData(iChar)
                            If sChar <> " " Then
                                sValue = sValue & sChar
                            End If
                            iChar += 1
                        Loop Until sChar = " "
                        sZ = modNumbers.StringToDecimal(sValue)

                        If iChar < sData.Length Then
                            sChar = sData(iChar)
                            If Not Char.IsDigit(sChar) And sChar <> "-" Then
                                sValue = sChar
                                iChar += 1
                                Do
                                    sChar = sData(iChar)
                                    If sChar <> " " Then
                                        sValue = sValue & sChar
                                    End If
                                    iChar += 1
                                Loop Until sChar = " "
                            End If
                        End If

                        Dim oPoint As cPoint3D = New cPoint3D(oSurvey, New Point3D(sX, sY, sZ))
                        AddHandler oPoint.OnChanged, AddressOf oPoint_OnChanged
                        AddHandler oPoint.OnGetItem, AddressOf oPoint_OnGetItem
                        Call oPoints.Add(oPoint)
                    Loop Until iChar >= sData.Length
                    'Catch
                    'End Try
                End If
            Else
                'carico i dati nel formato 'vecchio'...
                For Each oXMLPoint As XmlElement In Points.ChildNodes
                    Dim oPoint As cPoint3D = New cPoint3D(Survey, oXMLPoint)
                    AddHandler oPoint.OnChanged, AddressOf oPoint_OnChanged
                    AddHandler oPoint.OnGetItem, AddressOf oPoint_OnGetItem
                    Call oPoints.Add(oPoint)
                Next
            End If
        End Sub

        Friend Overridable Function SaveTo(ByVal File As Storage.cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement) As XmlElement
            Dim oXmlPoints As XmlElement = Document.CreateElement("points")
            Dim sLastSegmentBinded As String = ""
            Dim bAppendSpace As Boolean = False
            Dim oPointData As System.Text.StringBuilder = New System.Text.StringBuilder
            For Each oPoint As cPoint3D In oPoints
                Call oPointData.Append(modNumbers.NumberToString(oPoint.X) & " ")
                Call oPointData.Append(modNumbers.NumberToString(oPoint.Y) & " ")
                Call oPointData.Append(modNumbers.NumberToString(oPoint.Z) & " ")
                If bAppendSpace Then
                    Call oPointData.Append(" ")
                    bAppendSpace = False
                End If
            Next
            Call oXmlPoints.SetAttribute("data", oPointData.ToString)

            Call Parent.AppendChild(oXmlPoints)
            Return oXmlPoints
        End Function

        Public Function GetPoints() As Point3D()
            Dim oPaintPoints(oPoints.Count - 1) As Point3D
            For i = 0 To oPoints.Count - 1
                oPaintPoints(i) = oPoints(i).Point
            Next
            Return oPaintPoints
        End Function

        Private Sub oPoint_OnGetItem(Sender As cPoint3D, ByRef Item As cItem3D)
            Item = oItem
        End Sub

        Private Sub oPoint_OnChanged(ByVal Sender As cPoint3D)
        End Sub

        Public Function ToArray() As cPoint3D()
            Return oPoints.ToArray
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of cPoint3D) Implements IEnumerable(Of cPoint3D).GetEnumerator
            Return oPoints.GetEnumerator
        End Function
    End Class
End Namespace