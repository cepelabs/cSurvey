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
    Dim oClipartTriangleUpDown As cDrawClipArt
    Dim oClipartTriangleDownUp As cDrawClipArt
    Dim oClipartDoubleHalfArrow As cDrawClipArt
    Dim oClipartLeftHalfArrow As cDrawClipArt
    Dim oClipartRightHalfArrow As cDrawClipArt
    Dim oClipartDoubleArrow As cDrawClipArt
    Dim oClipartLeftArrow As cDrawClipArt
    Dim oClipartRightArrow As cDrawClipArt

    Dim oClipartSand As cDrawClipArt
    Dim oClipartPebbles1 As cDrawClipArt
    Dim oClipartDebrits1 As cDrawClipArt
    Dim oClipartDebrits2 As cDrawClipArt
    Dim oClipartFlow1 As cDrawClipArt

    Dim oClipartCompass As cDrawClipArt

    Private Sub pLoadClipart()
        If oClipartArrowUp Is Nothing Then oClipartArrowUp = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\arrowup.svg")
        If oClipartArrowDown Is Nothing Then oClipartArrowDown = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\arrowdown.svg")

        If oClipartTriangleUp Is Nothing Then oClipartTriangleUp = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\triangleup.svg")
        If oClipartTriangleDown Is Nothing Then oClipartTriangleDown = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\triangledown.svg")

        If oClipartShortDash Is Nothing Then oClipartShortDash = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\shortdash.svg")
        If oClipartDash Is Nothing Then oClipartDash = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\dash.svg")
        If oClipartLongDash Is Nothing Then oClipartLongDash = New cDrawClipArt(modMain.GetApplicationPath & "\objects\cliparts\pens\longdash.svg")

        If oClipartIce Is Nothing Then oClipartIce = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\ice.svg")

        If oClipartTriangleUpDown Is Nothing Then oClipartTriangleUpDown = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\triangleupdown.svg")
        If oClipartTriangleDownUp Is Nothing Then oClipartTriangleDownUp = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\triangledownup.svg")

        If oClipartDoubleHalfArrow Is Nothing Then oClipartDoubleHalfArrow = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\doublehalfarrow.svg")
        If oClipartLeftHalfArrow Is Nothing Then oClipartLeftHalfArrow = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\lefthalfarrow.svg")
        If oClipartRightHalfArrow Is Nothing Then oClipartRightHalfArrow = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\righthalfarrow.svg")
        If oClipartDoubleArrow Is Nothing Then oClipartDoubleArrow = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\doublearrow.svg")
        If oClipartLeftArrow Is Nothing Then oClipartLeftArrow = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\leftarrow.svg")
        If oClipartRightArrow Is Nothing Then oClipartRightArrow = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\pens\rightarrow.svg")

        If oClipartCompass Is Nothing Then oClipartCompass = New cDrawClipArt(My.Resources.clipart_defaultcompass_legacy)

        If oClipartSand Is Nothing Then oClipartSand = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\Sand.svg")

        If oClipartPebbles1 Is Nothing Then oClipartPebbles1 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\pebbles1.svg")

        If oClipartFlow1 Is Nothing Then oClipartFlow1 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\flow1.svg")

        If oClipartDebrits1 Is Nothing Then oClipartDebrits1 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\debrits1.svg")
        If oClipartDebrits2 Is Nothing Then oClipartDebrits2 = New cDrawClipArt(modMain.GetApplicationPath & "\Objects\Cliparts\Brushes\debrits2.svg")
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

    Public ReadOnly Property ClipartTriangleUpDown As cDrawClipArt
        Get
            If oClipartTriangleUpDown Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartTriangleUpDown
        End Get
    End Property

    Public ReadOnly Property ClipartTriangleDownUp As cDrawClipArt
        Get
            If oClipartTriangleDownUp Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartTriangleDownUp
        End Get
    End Property

    Public ReadOnly Property ClipartLeftHalfArrow As cDrawClipArt
        Get
            If oClipartLeftHalfArrow Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartLeftHalfArrow
        End Get
    End Property

    Public ReadOnly Property ClipartRightHalfArrow As cDrawClipArt
        Get
            If oClipartRightHalfArrow Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartRightHalfArrow
        End Get
    End Property

    Public ReadOnly Property ClipartDoubleHalfArrow As cDrawClipArt
        Get
            If oClipartDoubleHalfArrow Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartDoubleHalfArrow
        End Get
    End Property

    Public ReadOnly Property ClipartDoubleArrow As cDrawClipArt
        Get
            If oClipartDoubleArrow Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartDoubleArrow
        End Get
    End Property

    Public ReadOnly Property ClipartLeftArrow As cDrawClipArt
        Get
            If oClipartLeftArrow Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartLeftArrow
        End Get
    End Property

    Public ReadOnly Property ClipartRightArrow As cDrawClipArt
        Get
            If oClipartRightArrow Is Nothing Then
                Call pLoadClipart()
            End If
            Return oClipartRightArrow
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
