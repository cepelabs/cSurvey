Imports System.Xml
Imports System.IO

Module Module1
    Public sBaseVersion As String = "2"

    Public Function GetReleaseDate() As Date
        Dim oFi As FileInfo = New FileInfo(Path.Combine(Environment.CurrentDirectory, "csurveypc.exe"))
        Return oFi.LastWriteTime
    End Function

    Public Function GetReleaseVersion() As String
        Dim oFi As FileInfo = New FileInfo(Path.Combine(Environment.CurrentDirectory, "csurveypc.exe"))
        Dim dDate As Date = oFi.LastWriteTime
        Return sBaseVersion & "." & Strings.Format(dDate.Year - 2010, "0") & "." & Strings.Format(dDate.DayOfYear, "000") & Strings.Format((10 * (dDate.Hour * 60 + dDate.Minute) / 1440), "0")
    End Function

    Sub Main()
        Dim oXML As XmlDocument = New XmlDocument
        Dim oXMLRoot As XmlElement = oXML.CreateElement("csurvey")
        Call oXMLRoot.SetAttribute("version", GetReleaseVersion)
        Call oXMLRoot.SetAttribute("date", Strings.Format(GetReleaseDate, "yyyyMMddHHmm"))
        oXML.AppendChild(oXMLRoot)
        oXML.Save(Path.Combine(Environment.CurrentDirectory, "version.xml"))
    End Sub

End Module
