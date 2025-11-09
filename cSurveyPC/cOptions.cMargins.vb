Imports System.Xml
Imports cSurveyPC.cSurvey.Design
Imports cSurveyPC.cSurvey.Design.Options.cGPSOptions
Imports cSurveyPC.cSurvey.Drawings

Namespace cSurvey.Design

    Public Class cSVGOptions
        Implements cIUIBaseInteractions

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Private bReuseClipart As Boolean
        Private bUseStyles As Boolean
        Friend Sub New()
            bReuseClipart = False
            bUseStyles = True
        End Sub
        Friend Sub New(ByVal GPSOptions As XmlElement)
            bReuseClipart = modXML.GetAttributeValue(GPSOptions, "reuseclipart", 0)
            bUseStyles = modXML.GetAttributeValue(GPSOptions, "usestyle", 1)
        End Sub

        Friend Function SaveTo(ByVal File As cFile, ByVal Document As XmlDocument, ByVal Parent As XmlElement, ByVal Name As String) As XmlElement
            Dim oXMLSVGOptions As XmlElement = Document.CreateElement(Name)
            If bReuseClipart Then Call oXMLSVGOptions.SetAttribute("reuseclipart", "1")
            If Not bUseStyles Then Call oXMLSVGOptions.SetAttribute("usestyle", "0")
            Call Parent.AppendChild(oXMLSVGOptions)
            Return oXMLSVGOptions
        End Function

        Public Property UseStyles As Boolean
            Get
                Return bUseStyles
            End Get
            Set(value As Boolean)
                If value <> bUseStyles Then
                    bUseStyles = value
                    Call PropertyChanged("UseStyles")
                End If
            End Set
        End Property

        Public Property ReuseClipart As Boolean
            Get
                Return bReuseClipart
            End Get
            Set(value As Boolean)
                If value <> bReuseClipart Then
                    bReuseClipart = value
                    Call PropertyChanged("ReuseClipart")
                End If
            End Set
        End Property

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub
    End Class
    Public Class cMargins
        Implements cIUIBaseInteractions
        Implements ICloneable

        Public Event OnPropertyChanged(sender As Object, e As PropertyChangeEventArgs) Implements cIUIBaseInteractions.OnPropertyChanged

        Public Sub PropertyChanged(Name As String) Implements cIUIBaseInteractions.PropertyChanged
            RaiseEvent OnPropertyChanged(Me, New PropertyChangeEventArgs(Name))
        End Sub

        Private iLeft As Integer
        Private iTop As Integer
        Private iRight As Integer
        Private iBottom As Integer

        Public Function ToMargin() As System.Drawing.Printing.Margins
            Return New System.Drawing.Printing.Margins(iLeft, iRight, iTop, iBottom)
        End Function

        Public Sub New(Margins As String)
            Dim sMarginsParts As String() = Margins.Split({";"c})
            iLeft = sMarginsParts(0)
            iRight = sMarginsParts(1)
            iTop = sMarginsParts(2)
            iBottom = sMarginsParts(3)
        End Sub

        Public Sub New(Left As Integer, Right As Integer, Top As Integer, Bottom As Integer)
            iLeft = Left
            iRight = Right
            iTop = Top
            iBottom = Bottom
        End Sub

        Public Shared Widening Operator CType(ByVal m As cMargins) As System.Drawing.Printing.Margins
            Return New System.Drawing.Printing.Margins(m.Left, m.Right, m.Top, m.Bottom)
        End Operator

        Public Shared Widening Operator CType(ByVal m As System.Drawing.Printing.Margins) As cMargins
            Return New cMargins(m.Left, m.Right, m.Top, m.Bottom)
        End Operator

        Public Shared Operator <>(m1 As cMargins, m2 As cMargins)
            Return m1.Left <> m2.Left OrElse m1.Right <> m2.Right OrElse m1.Top <> m2.Top OrElse m1.Bottom <> m2.Bottom
        End Operator

        Public Shared Operator =(m1 As cMargins, m2 As cMargins)
            Return m1.Left = m2.Left AndAlso m1.Right = m2.Right AndAlso m1.Top = m2.Top AndAlso m1.Bottom = m2.Bottom
        End Operator

        Public Property Bottom As Integer
            Get
                Return iBottom
            End Get
            Set(value As Integer)
                If iBottom <> value Then
                    iBottom = value
                    Call PropertyChanged("Bottom")
                End If
            End Set
        End Property

        Public Property Right As Integer
            Get
                Return iRight
            End Get
            Set(value As Integer)
                If iRight <> value Then
                    iRight = value
                    Call PropertyChanged("Right")
                End If
            End Set
        End Property

        Public Property Top As Integer
            Get
                Return iTop
            End Get
            Set(value As Integer)
                If iTop <> value Then
                    iTop = value
                    Call PropertyChanged("Top")
                End If
            End Set
        End Property

        Public Property Left As Integer
            Get
                Return iLeft
            End Get
            Set(value As Integer)
                If iLeft <> value Then
                    iLeft = value
                    Call PropertyChanged("Left")
                End If
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return iLeft & ";" & iRight & ";" & iTop & ";" & iBottom
        End Function

        Public Function Clone() As Object Implements ICloneable.Clone
            Return New cMargins(iLeft, iRight, iTop, iBottom)
        End Function
    End Class
End Namespace
