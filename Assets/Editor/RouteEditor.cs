using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RouteEditor : EditorWindow
{
    private List<Vector3> vector3s = new List<Vector3>();
    private string name;
    private int selectedAction = 0;
    [MenuItem("Project Tools/RouteCreater")]
    public static void ShowWindow()
    {
        GetWindow<RouteEditor>("Chose Prefab");
    }

    private void OnGUI()
    {

        name = EditorGUILayout.TextField("Name of Route", name);
        float width = position.width - 5;
        float height = 30;
        string[] actionLabels = new string[] { "None", "Create Route Point" };
        selectedAction = GUILayout.SelectionGrid(selectedAction, actionLabels, actionLabels.Length, GUILayout.Width(width), GUILayout.Height(height));
        for (int i = 0; i < vector3s.Count; i++)
        {
            vector3s[i]= EditorGUILayout.Vector3Field((i+1).ToString(), vector3s[i]);
        }

        if (GUILayout.Button("Create Route"))
        {
            var asset = RouteData.CreateInstance(vector3s);
            AssetDatabase.CreateAsset(asset, $"Assets/Scripts/ScriptableObject/RouteData/{name}.asset");
            SceneView.duringSceneGui -= OnScene;
            Close();
        }
    }


    void OnScene(SceneView sceneview)
    {
        Event e = Event.current;
        if (e.type == EventType.MouseUp)
        {
            Ray r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y));
            if (selectedAction == 1)
            {
                vector3s.Add(r.origin);
                this.Focus();
            }
        }
    }
    void OnEnable()
    {
        //нужно потому что иногда не подцепляется
        SceneView.duringSceneGui -= OnScene;
        SceneView.duringSceneGui += OnScene;
    }
}
