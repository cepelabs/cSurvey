Imports DevExpress.Office.Utils
Imports DevExpress.Utils.Html

Friend NotInheritable Class frmAbout

    'Private Const sCopyrights As String = "" &
    '    "Therion" & vbCrLf &
    '    "{0} Stacho Mudrák, Martin Budaj" & vbCrLf &
    '    "http://therion.speleo.sk" & vbCrLf &
    '    "" & vbCrLf &
    '    "{1} vbAccelerator" & vbCrLf &
    '    "http://vbaccelerator.com" & vbCrLf &
    '    "" & vbCrLf &
    '    "GeoUtility Library" & vbCrLf &
    '    "© Copyright 1989, 1991 Free Software Foundation, Inc." & vbCrLf &
    '    "59 Temple Place, Suite 330, Boston, MA 02111-1307 USA" & vbCrLf &
    '    "http://geoutility.codeplex.com" & vbCrLf &
    '    "" & vbCrLf &
    '    "DotNetZip Library" & vbCrLf &
    '    "http://dotnetzip.codeplex.com" & vbCrLf &
    '    "" & vbCrLf &
    '    "Icon set" & vbCrLf &
    '    "© Copyright 2011 FatCow Web Hosting. All rights reserved." & vbCrLf &
    '    "http://www.fatcow.com/free-icons" & vbCrLf &
    '    "" & vbCrLf &
    '    "Diacritics " & vbCrLf &
    '    "© 2015 Thomas Galliker" & vbCrLf &
    '    "https://github.com/thomasgalliker/Diacritics.NET" &
    '    "" & vbCrLf

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Text = String.Format(GetLocalizedString("about.infoabout.textpart1"), ApplicationTitle)

        htmlMainInfo.HtmlTemplate.Template = htmlMainInfo.HtmlTemplate.Template.Replace("%PRODUCTNAME%", My.Application.Info.ProductName)
        htmlMainInfo.HtmlTemplate.Template = htmlMainInfo.HtmlTemplate.Template.Replace("%COPYRIGHT%", My.Application.Info.Copyright)

        htmlMainInfo.HtmlTemplate.Template = htmlMainInfo.HtmlTemplate.Template.Replace("%TEXTPART7%", modMain.GetLocalizedString("about.infoabout.textpart7"))
        htmlMainInfo.HtmlTemplate.Template = htmlMainInfo.HtmlTemplate.Template.Replace("%TEXTPART8%", modMain.GetLocalizedString("about.infoabout.textpart8"))
        htmlMainInfo.HtmlTemplate.Template = htmlMainInfo.HtmlTemplate.Template.Replace("%TEXTPART9%", modMain.GetLocalizedString("about.infoabout.textpart9"))
        htmlMainInfo.HtmlTemplate.Template = htmlMainInfo.HtmlTemplate.Template.Replace("%TEXTPART10%", modMain.GetLocalizedString("about.infoabout.textpart10"))

        Dim oProcess As Process = Process.GetCurrentProcess()
        Dim sMemoryUsage As String = GetLocalizedString("about.infoabout.textpart2") & ": Working Set: " & oProcess.WorkingSet64 / 1024 & " Kb" ', Totale: " & GC.GetTotalMemory(True) / 1024 & " Kb"
        lblInfo.Text = String.Format(GetLocalizedString("about.infoabout.textpart3"), modMain.GetPackageVersion, modMain.GetReleaseDate.ToString("d")) & vbCrLf & sMemoryUsage & vbCrLf & IIf(Environment.Is64BitOperatingSystem, GetLocalizedString("about.infoabout.textpart4a"), GetLocalizedString("about.infoabout.textpart4b")) & " - " & IIf(Environment.Is64BitProcess, "cSurvey 64 bit", "cSurvey 32 bit") & vbCrLf

        htmlMainInfo.DataContext = New cAboutSource()
    End Sub

    Private Class cAboutSource
        Public ReadOnly Property fsrer As Image
            Get
                Return My.Resources.about_fsrer
            End Get
        End Property

        Public ReadOnly Property devexpress As Image
            Get
                Return My.Resources.about_devexpress
            End Get
        End Property

        Public ReadOnly Property csd As Image
            Get
                Return My.Resources.about_csd
            End Get
        End Property

        Public ReadOnly Property bolognaspeleologica As Image
            Get
                Return My.Resources.about_bolognaspeleologica
            End Get
        End Property

        Public ReadOnly Property gsbusb As Image
            Get
                Return My.Resources.about_gsbusb
            End Get
        End Property
    End Class

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Me.Close()
    End Sub

    'Private Sub lnkContact_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Shell("explorer mailto:info@csurvey.it")
    'End Sub

    'Private Sub lnkGreetings0_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Shell("explorer http://www.fsrer.it")
    'End Sub

    'Private Sub lnkGreetings1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Shell("explorer http://www.bolognaspeleologia.it")
    'End Sub

    'Private Sub lnkGreetings2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Shell("explorer http://www.gsb-usb.it")
    'End Sub

    Private Sub htmlCopyright_ElementMouseClick(sender As Object, e As DxHtmlElementMouseEventArgs) Handles htmlCopyright.ElementMouseClick
        If e.TagName = "a" Then
            Shell("explorer " & e.ElementId.Substring(4))
        End If
    End Sub

    Private Sub htmlLicence_ElementMouseClick(sender As Object, e As DxHtmlElementMouseEventArgs) Handles htmlLicence.ElementMouseClick
        If e.TagName = "a" Then
            Shell("explorer " & e.ElementId.Substring(4))
        End If
    End Sub

    Private Sub htmlMainInfo_ElementMouseClick(sender As Object, e As DxHtmlElementMouseEventArgs) Handles htmlMainInfo.ElementMouseClick
        If e.TagName = "a" Then
            Shell("explorer " & e.ElementId.Substring(4))
        End If
    End Sub
End Class
