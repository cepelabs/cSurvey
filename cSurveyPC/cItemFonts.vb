Imports cSurveyPC
Imports cSurveyPC.cSurvey

Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D

Namespace cSurvey.Design
    Public Class cItemFonts
        Private WithEvents oSurvey As cSurvey

        Private oFontNote As cItemFont
        Private oFontTrigPoint As cItemFont
        Private oFontCaveComplexName As cItemFont
        Private oFontCaveName As cItemFont
        Private oFontTitle As cItemFont
        Private oFontGeneric As cItemFont

        '---------------------------------------------------
        'note=sDefaultFontSize - 1
        'trigpoint=sDefaultFontSize
        'cavecomplexname=sDefaultFontSize + 3
        'cavename=sDefaultFontSize + 2
        'title=sDefaultFontSize + 1
        'generic=sDefaultFontSize
        '---------------------------------------------------

        Public ReadOnly Property Note() As cItemFont
            Get
                If oFontNote Is Nothing Then
                    oFontNote = New cItemFont(oSurvey, GetLocalizedString("itemfonts.note"), cItemFont.FontTypeEnum.Note, "", 0, Color.Black, False, False, False)
                End If
                Return oFontNote
            End Get
        End Property

        Public ReadOnly Property TrigPoint() As cItemFont
            Get
                If oFontTrigPoint Is Nothing Then
                    oFontTrigPoint = New cItemFont(oSurvey, GetLocalizedString("itemfonts.station"), cItemFont.FontTypeEnum.TrigPoint, "", 0, Color.Black, True, False, False)
                End If
                Return oFontTrigPoint
            End Get
        End Property

        Public ReadOnly Property CaveComplexName() As cItemFont
            Get
                If oFontCaveComplexName Is Nothing Then
                    oFontCaveComplexName = New cItemFont(oSurvey, GetLocalizedString("itemfonts.cavecomplexname"), cItemFont.FontTypeEnum.CaveComplexName, "", 0, Color.Black, True, False, False)
                End If
                Return oFontCaveComplexName
            End Get
        End Property

        Public ReadOnly Property CaveName() As cItemFont
            Get
                If oFontCaveName Is Nothing Then
                    oFontCaveName = New cItemFont(oSurvey, GetLocalizedString("itemfonts.cavename"), cItemFont.FontTypeEnum.CaveName, "", 0, Color.Black, True, False, False)
                End If
                Return oFontCaveName
            End Get
        End Property

        Public ReadOnly Property Title() As cItemFont
            Get
                If oFontTitle Is Nothing Then
                    oFontTitle = New cItemFont(oSurvey, GetLocalizedString("itemfonts.title"), cItemFont.FontTypeEnum.Title, "", 0, Color.Black, False, False, False)
                End If
                Return oFontTitle
            End Get
        End Property

        Public ReadOnly Property Generic() As cItemFont
            Get
                If oFontGeneric Is Nothing Then
                    oFontGeneric = New cItemFont(oSurvey, GetLocalizedString("itemfonts.generic"), cItemFont.FontTypeEnum.Generic, "", 0, Color.Black, False, False, False)
                End If
                Return oFontGeneric
            End Get
        End Property

        Public Function FromType(ByVal Type As cItemFont.FontTypeEnum) As cItemFont
            Select Case Type
                Case cItemFont.FontTypeEnum.Generic
                    Return Generic
                Case cItemFont.FontTypeEnum.Title
                    Return Title
                Case cItemFont.FontTypeEnum.CaveName
                    Return CaveName
                Case cItemFont.FontTypeEnum.CaveComplexName
                    Return CaveComplexName
                Case cItemFont.FontTypeEnum.TrigPoint
                    Return TrigPoint
                Case cItemFont.FontTypeEnum.Note
                    Return Note
                Case Else
                    Return New cItemFont(oSurvey)
            End Select
        End Function

        Public Function FromCustom(ByVal FontName As String, ByVal FontSize As Single, ByVal Color As Color, ByVal Bold As Boolean, ByVal Italic As Boolean, ByVal Underline As Boolean) As cItemFont
            Dim oFont As cItemFont = New cItemFont(oSurvey, GetLocalizedString("itemfonts.custom"), cItemFont.FontTypeEnum.Custom, FontName, FontSize, Color, Bold, Italic, Underline)
            Return oFont
        End Function

        Friend Sub New(ByVal Survey As cSurvey)
            oSurvey = Survey
        End Sub

    End Class
End Namespace

