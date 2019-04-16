using UnityEngine;
using UnityEditor;

/// <summary>
/// Enables the use of #NAMESPACE# in the script templates
/// to automatically apply the namespace of the scripts
/// when the scripts are created.
/// </summary>
public class AddNameSpace : UnityEditor.AssetModificationProcessor {
    public static void OnWillCreateAsset(string path) {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        if(index < 0) return;
        string file = path.Substring(index);
        if(file != ".cs" && file != ".js" && file != ".boo") return;
        index = Application.dataPath.LastIndexOf("Assets");
        path = Application.dataPath.Substring(0, index) + path;
        file = System.IO.File.ReadAllText(path);

        string lastPart = path.Substring(path.IndexOf("_Scripts"));
        string _namespace = lastPart.Substring(0, lastPart.LastIndexOf('/'));
        _namespace = _namespace.Replace('/', '.').Replace("_Scripts", "CastOuts");
        file = file.Replace("#NAMESPACE#", _namespace);

        System.IO.File.WriteAllText(path, file);
        AssetDatabase.Refresh();
    }
}