using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;

public class BVHImporter : EditorWindow
{

    public const string BLENDER_EXEC = @"D:\SteamLibrary\steamapps\common\Blender\blender.exe";
    public const string PHYTHON_CODE = @"import bpy;import sys;argv = sys.argv;argv = argv[argv.index(\""--\"") + 1:];bvh_in = argv[0];fbx_out = argv[0] + \"".fbx\"";objs = bpy.data.objects;bpy.ops.import_anim.bvh(filepath=bvh_in, filter_glob=\""*.bvh\"", global_scale=1, frame_start=1, use_fps_scale=False, use_cyclic=False, rotate_mode='NATIVE', axis_forward='-Z', axis_up='Y');objs.remove(objs[\""Cube\""], True);objs.remove(objs[\""Lamp\""], True);objs.remove(objs[\""Camera\""], True);bpy.ops.export_scene.fbx(filepath=fbx_out, axis_forward='-Z', axis_up='Y', use_anim=True, use_selection=True, use_default_take=False);";

    private static string currentPath;
    private static string destination;

    [MenuItem("Tools/Import BVH...")]
    static void ImportBVH()
    {
        string path = EditorUtility.OpenFilePanel("Select BVH file...", "", "bvh");
        if (path.Length != 0)
        {
            currentPath = path;
            string dest = EditorUtility.SaveFilePanel("Select destination...", Application.dataPath, Path.GetFileNameWithoutExtension(path), "fbx");
            if (dest.Length != 0)
            {
                if (dest.Contains(Application.dataPath))
                {
                    destination = "Assets" + dest.Split(new string[] { Application.dataPath }, System.StringSplitOptions.None)[1];
                }
                else
                {
                    EditorUtility.DisplayDialog("Error", "You must select a folder inside the Unity project.", "Close");
                    currentPath = string.Empty;
                    destination = string.Empty;
                    return;
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "You must select a valid destination folder inside the current project.", "Close");
                currentPath = string.Empty;
                destination = string.Empty;
                return;
            }
            string command = string.Format("-b --python-expr \"{0}\" -- \"{1}\"", PHYTHON_CODE, path);

            var processInfo = new ProcessStartInfo(BLENDER_EXEC, command);
            processInfo.CreateNoWindow = true;

            var process = Process.Start(processInfo);
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;
            process.WaitForExit();
            process.Close();
        }
        else
        {
            currentPath = string.Empty;
            destination = string.Empty;
        }
    }

    private static void Process_Exited(object sender, System.EventArgs e)
    {
        string newFile = string.Format(@"{0}\{1}.fbx", Path.GetDirectoryName(currentPath), Path.GetFileName(currentPath));
        if (File.Exists(newFile))
        {
            File.Copy(newFile, destination);
        }
        else
        {
            UnityEngine.Debug.LogError("Unable to create FBX file. Please check the source BVH and try again.");
            currentPath = string.Empty;
            destination = string.Empty;
        }


    }
}

