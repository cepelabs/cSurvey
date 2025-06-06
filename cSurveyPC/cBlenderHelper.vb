Imports System.Diagnostics
Imports System.IO

Public Class cBlenderHelper

    Public Class cBlenderParameters
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

    Private Shared sDecimateScript As String = "import bpy
import sys

# Recupera gli argomenti dopo il separatore ""--""
args = sys.argv

input_path = args[args.index(""--"") + 1]
output_path = args[args.index(""--"") + 2]
ratio = float(args[args.index(""--"") + 3]) if len(args) > args.index(""--"") + 3 else 0.5

# Pulisce la scena
bpy.ops.object.select_all(action='SELECT')
bpy.ops.object.delete(use_global=False)

# Importa il modello OBJ
bpy.ops.wm.obj_import(filepath=input_path)

# Seleziona gli oggetti importati
objs = bpy.context.selected_objects
if not objs:
    print(""Errore: nessun oggetto importato."")
    sys.exit(1)

# Applica il modificatore Decimate
for obj in objs:
    if obj.type == 'MESH':
        bpy.context.view_layer.objects.active = obj
        mod = obj.modifiers.new(name=""Decimate"", type='DECIMATE')
        mod.ratio = ratio
        mod.use_collapse_triangulate = True
        bpy.ops.object.modifier_apply(modifier=mod.name)

# Esporta il modello ridotto
bpy.ops.wm.obj_export(filepath=output_path)
print(f""Esportazione completata: {output_path}"")
"


    Private Shared sMergeScript As String = "import bpy
import sys

# Recupera i parametri passati dopo il separatore ""--""
args = sys.argv
model1 = args[args.index(""--"") + 1]
model2 = args[args.index(""--"") + 2]
output = args[args.index(""--"") + 3]

# Pulisce la scena
bpy.ops.object.select_all(action='SELECT')
bpy.ops.object.delete(use_global=False)

# Importa i modelli
bpy.ops.import_scene.obj(filepath=model1)
bpy.ops.import_scene.obj(filepath=model2)

# Seleziona gli oggetti importati
objs = bpy.context.selected_objects
if len(objs) < 2:
    print(""Errore: non sono stati importati due oggetti."")
    sys.exit(1)

obj1, obj2 = objs[0], objs[1]

# Unione tramite operazione booleana
bpy.context.view_layer.objects.active = obj1
bool_mod = obj1.modifiers.new(name=""Boolean"", type='BOOLEAN')
bool_mod.operation = 'UNION'
bool_mod.object = obj2
bool_mod.solver = 'EXACT'
bpy.ops.object.modifier_apply(modifier=bool_mod.name)

# Rimozione delle parti interne con remesh
remesh = obj1.modifiers.new(name=""Remesh"", type='REMESH')
remesh.mode = 'VOXEL'
remesh.voxel_size = 0.05
remesh.use_remove_disconnected = True
bpy.ops.object.modifier_apply(modifier=remesh.name)

# Esporta l'oggetto risultante
bpy.ops.export_scene.obj(filepath=output)
print(f""Esportazione completata: {output}"")
"

    Public Shared Sub DecimateModel(Survey As cSurvey.cSurvey, BlenderParameters As cBlenderParameters, Model As String, Ratio As Single, OutputModel As String)
        'Dim blenderPath As String = "C:\Program Files\Blender Foundation\Blender 4.4\\blender.exe"
        Dim sScriptPath As String = IO.Path.GetTempFileName & ".py"
        IO.File.WriteAllText(sScriptPath, sDecimateScript)
        Dim sModelPath As String = Model
        Dim sRatio As Single = Ratio
        Dim sOutputPath As String = OutputModel

        If Not File.Exists(BlenderParameters.Path) Then
            MessageBox.Show("Blender non trovato nel percorso specificato.")
            Return
        End If
        If Not File.Exists(sScriptPath) Then
            MessageBox.Show("Script Python non trovato.")
            Return
        End If
        If Not File.Exists(sModelPath) Then
            MessageBox.Show("Il modello OBJ non esiste.")
            Return
        End If

        Dim args As String = "--background --python """ & sScriptPath & """ -- """ & sModelPath & """ """ & sOutputPath & """ " & modNumbers.NumberToString(sRatio)
        Dim startInfo As New ProcessStartInfo With {
            .FileName = BlenderParameters.Path,
            .Arguments = args,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .CreateNoWindow = True
        }

        Dim process As New Process With {
            .StartInfo = startInfo
        }
        Dim bDone As Boolean
        AddHandler process.OutputDataReceived, Sub(s, evt)
                                                   If Not String.IsNullOrEmpty(evt.Data) Then
                                                       'Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Information, evt.Data & Environment.NewLine)
                                                       If evt.Data.StartsWith("Esportazione completata") Then
                                                           bDone = True
                                                       End If
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

    Public Shared Sub MergeModel(Survey As cSurvey.cSurvey, BlenderParameters As cBlenderParameters, Model1 As String, Model2 As String, OutputModel As String)
        'Dim blenderPath As String = "C:\Program Files\Blender Foundation\Blender 4.4\\blender.exe"
        Dim sScriptPath As String = IO.Path.GetTempFileName & ".py"
        IO.File.WriteAllText(sScriptPath, sMergeScript)
        Dim sModel1Path As String = Model1
        Dim sModel2Path As String = Model2
        Dim sOutputPath As String = OutputModel

        If Not File.Exists(BlenderParameters.Path) Then
            MessageBox.Show("Blender non trovato nel percorso specificato.")
            Return
        End If
        If Not File.Exists(sScriptPath) Then
            MessageBox.Show("Script Python non trovato.")
            Return
        End If
        If Not File.Exists(sModel1Path) OrElse Not File.Exists(sModel2Path) Then
            MessageBox.Show("Uno dei modelli OBJ non esiste.")
            Return
        End If

        Dim args As String = "--background --python """ & sScriptPath & """ -- """ & sModel1Path & """ """ & sModel2Path & """ """ & sOutputPath & """"
        Dim startInfo As New ProcessStartInfo With {
            .FileName = BlenderParameters.Path,
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
                                                       Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Information, evt.Data & Environment.NewLine)
                                                   End If
                                               End Sub

        AddHandler process.ErrorDataReceived, Sub(s, evt)
                                                  If Not String.IsNullOrEmpty(evt.Data) Then
                                                      'Invoke(CType(Sub() txtLog.AppendText("[ERROR] " & evt.Data & Environment.NewLine), MethodInvoker))
                                                      Survey.RaiseOnLogEvent(cSurvey.cSurvey.LogEntryType.Information, evt.Data & Environment.NewLine)
                                                  End If
                                              End Sub

        process.Start()
        process.BeginOutputReadLine()
        process.BeginErrorReadLine()
        process.WaitForExit()

        File.Delete(sScriptPath)

        MessageBox.Show("Blender ha completato l'elaborazione.")
    End Sub
End Class
