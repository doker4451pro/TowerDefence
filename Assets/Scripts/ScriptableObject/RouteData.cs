using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways,CreateAssetMenu(fileName = "New RouteData", menuName = "Route Data", order = 52)]
public class RouteData : ScriptableObject
{
    [SerializeField]
    public List<Vector3> vector3s;
}
