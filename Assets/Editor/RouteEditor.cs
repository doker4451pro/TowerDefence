using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouteEditor : EditorWindow
{
    private RouteData data;
    [MenuItem("Project Tools/Route/Create New Route")]
    public static void ShowWindow()
    {
        GetWindow<RouteEditor>("Chose Prefab");
    }

    private void OnGUI()
    {
        data.vector3s = new List<Vector3>();
        data.vector3s.Add(new Vector3(1, 2, 3));
        if (GUILayout.Button("OK"))
        {
            Close();
        }
    }
}
