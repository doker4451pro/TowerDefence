using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class RouteManager : MonoBehaviour
{


    public List<Vector3> mousePositionsWorld;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [CustomEditor(typeof(RouteManager))]
    public class MyTileEditor : Editor
    {
        void OnSceneGUI()
        {
            RouteManager obj = (RouteManager)target;

            if (Event.current.type == EventType.MouseDown)
            {
                Camera cam = SceneView.lastActiveSceneView.camera;

                Vector3 mousepos = Event.current.mousePosition;
                mousepos.z = -cam.worldToCameraMatrix.MultiplyPoint(obj.transform.position).z;
                mousepos.y = Screen.height - mousepos.y - 36.0f;
                mousepos = cam.ScreenToWorldPoint(mousepos);

                obj.mousePositionsWorld.Add(mousepos);
            }
        }



    }
}
