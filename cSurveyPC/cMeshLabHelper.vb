Imports System.Diagnostics
Imports System.IO

Public Class cMeshLabHelper

    Public Class cMeshLabParameters
        Private sPath As String

        Public Sub New(Path As String)
            sPath = Path
        End Sub

        Public ReadOnly Property Path As String
            Get
                Return sPath
            End Get
        End Property
    End Class

    Private Shared sDecimateScript As String = "import pymeshlab
    import sys

    def simplify_mesh(input_path, output_path, target_faces=10000):
    ms = pymeshlab.MeshSet()
    
    print(f""Caricamento modello {input_path}"")
    ms.load_new_mesh(input_path)
    
    print(f""Numero di facce iniziali {ms.current_mesh().face_number()}"")

    ms.apply_filter('simplification_quadric_edge_collapse_decimation', 
                    targetfacenum=target_faces,
                    preservenormal=True,
                    preservetopology=True,
                    preserveboundary=True,
                    preservetexture=True,
                    optimalplacement=True)

    print(f""Numero di facce finali {ms.current_mesh().face_number()}"")
    
    ms.save_current_mesh(output_path)
    print(f""Modello semplificato salvato in {output_path}"")

    if __name__ == '__main__':
    if len(sys.argv) < 3:
        print(""Utilizzo: python simplify_model.py input.obj output.obj [target_faces]"")
        sys.exit(1)

    input_file = sys.argv[1]
    output_file = sys.argv[2]
    faces = int(sys.argv[3]) if len(sys.argv) > 3 else 10000

    simplify_mesh(input_file, output_file, faces)
"


    Public Shared Sub DecimateModel(Survey As cSurvey.cSurvey, MeshLabParameters As cMeshLabParameters, Model As String, Ratio As Single, OutputModel As String)
        Dim sScriptPath As String = IO.Path.GetTempFileName & ".py"
        IO.File.WriteAllText(sScriptPath, sDecimateScript)
        Dim sModelPath As String = Model
        Dim sRatio As Single = Ratio
        Dim sOutputPath As String = OutputModel

        If Not File.Exists(MeshLabParameters.Path) Then
            MessageBox.Show("MeshLab non trovato nel percorso specificato.")
            Return
        End If
        If Not File.Exists(sScriptPath) Then
            MessageBox.Show("Script XML non trovato.")
            Return
        End If
        If Not File.Exists(sModelPath) Then
            MessageBox.Show("Il modello OBJ non esiste.")
            Return
        End If

        'python simplify_model.py input.obj output.obj 5000
        Dim args As String = """" & sScriptPath & """ """ & sModelPath & """ """ & sOutputPath & """ " & modNumbers.NumberToString(Ratio)
        Dim startInfo As New ProcessStartInfo With {
            .FileName = "python",
            .Arguments = args,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .CreateNoWindow = True
        }

        Dim process As New Process With {
            .StartInfo = startInfo
        }
        AddHandler process.OutputDataReceived, Sub(s, evt)
                                                   If Not String.IsNullOrEmpty(evt.Data) Then
                                                       'Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Information, evt.Data & Environment.NewLine)
                                                   End If
                                               End Sub

        AddHandler process.ErrorDataReceived, Sub(s, evt)
                                                  If Not String.IsNullOrEmpty(evt.Data) Then
                                                      'Invoke(CType(Sub() txtLog.AppendText("[ERROR] " & evt.Data & Environment.NewLine), MethodInvoker))
                                                      'survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Information, evt.Data & Environment.NewLine)
                                                  End If
                                              End Sub

        process.Start()
        process.BeginOutputReadLine()
        process.BeginErrorReadLine()
        process.WaitForExit()

        File.Delete(sScriptPath)
    End Sub

End Class
