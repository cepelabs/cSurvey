Imports cSurveyPC.cSurvey.Drawings

Module modPenClipart

    Dim oClipartArrowUp As cDrawClipArt
    Dim oClipartArrowDown As cDrawClipArt
    Dim oClipartShortDash As cDrawClipArt
    Dim oClipartDash As cDrawClipArt
    Dim oClipartLongDash As cDrawClipArt
    Dim oClipartTriangleUp As cDrawClipArt
    Dim oClipartTriangleDown As cDrawClipArt
    Dim oClipartIce As cDrawClipArt

    Dim oClipartSand As cDrawClipArt
    Dim oClipartPebbles1 As cDrawClipArt
    Dim oClipartDebrits1 As cDrawClipArt
    Dim oClipartDebrits2 As cDrawClipArt
    Dim oClipartFlow1 As cDrawClipArt

    Dim oClipartCompass As cDrawClipArt

    Private Sub pLoadClipart()
        oClipartArrowUp = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\arrowup.svg")
        oClipartArrowDown = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\arrowdown.svg")

        oClipartTriangleUp = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\triangleup.svg")
        oClipartTriangleDown = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\triangledown.svg")

        oClipartShortDash = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\shortdash.svg")
        oClipartDash = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\dash.svg")
        oClipartLongDash = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\longdash.svg")

        oClipartIce = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\ice.svg")

        oClipartCompass = New cDrawClipArt(My.Resources.default_compass_legacy)

        oClipartSand = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\Sand.svg")

        oClipartPebbles1 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\pebbles1.svg")

        oClipartFlow1 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\flow1.svg")

        oClipartDebrits1 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\debrits1.svg")
        oClipartDebrits2 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\debrits2.svg")
    End Sub

    Public ReadOnly Property ClipartIce As cDrawClipArt
        Get
            If oClipartIce Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartIce
        End Get
    End Property

    Public ReadOnly Property ClipartSand As cDrawClipArt
        Get
            If oClipartSand Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartSand
        End Get
    End Property

    Public ReadOnly Property ClipartDebrits1 As cDrawClipArt
        Get
            If oClipartDebrits1 Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartDebrits1
        End Get
    End Property

    Public ReadOnly Property ClipartDebrits2 As cDrawClipArt
        Get
            If oClipartDebrits2 Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartDebrits2
        End Get
    End Property

    Public ReadOnly Property ClipartFlow1 As cDrawClipArt
        Get
            If oClipartFlow1 Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartFlow1
        End Get
    End Property

    Public ReadOnly Property ClipartPebbles1 As cDrawClipArt
        Get
            If oClipartPebbles1 Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartPebbles1
        End Get
    End Property

    Public ReadOnly Property ClipartCompass As cDrawClipArt
        Get
            If oClipartCompass Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartCompass
        End Get
    End Property

    Public ReadOnly Property ClipartArrowUp As cDrawClipArt
        Get
            If oClipartArrowUp Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartArrowUp
        End Get
    End Property

    Public ReadOnly Property ClipartArrowDown As cDrawClipArt
        Get
            If oClipartArrowDown Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartArrowDown
        End Get
    End Property

    Public ReadOnly Property ClipartShortDash As cDrawClipArt
        Get
            If oClipartShortDash Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartShortDash
        End Get
    End Property

    Public ReadOnly Property ClipartTriangleUp As cDrawClipArt
        Get
            If oClipartTriangleUp Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartTriangleUp
        End Get
    End Property

    Public ReadOnly Property ClipartTriangleDown As cDrawClipArt
        Get
            If oClipartTriangleDown Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartTriangleDown
        End Get
    End Property

    Public ReadOnly Property ClipartDash As cDrawClipArt
        Get
            If oClipartDash Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartDash
        End Get
    End Property

    Public ReadOnly Property ClipartLongDash As cDrawClipArt
        Get
            If oClipartLongDash Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartLongDash
        End Get
    End Property

    Public ReadOnly Property Ice As cDrawClipArt
        Get
            If oClipartIce Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartIce
        End Get
    End Property
End Module
