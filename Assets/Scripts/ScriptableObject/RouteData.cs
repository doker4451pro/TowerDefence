using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways, CreateAssetMenu(fileName = "New RouteData", menuName = "Route Data", order = 52)]
public class RouteData : ScriptableObject//, IEnumerable
{
    [SerializeField]
    private List<Vector3> points;

    public Vector3 this[int index]
    {
        get => points[index];
    }

    //фабричный метод чтобы запретить изменения
    public static RouteData CreateInstance(List<Vector3> vectors) 
    {
        RouteData route = CreateInstance<RouteData>();
        route.points = vectors;
        return route;
    }
    public Vector3[] GetArrVectors() 
    {
        return points.ToArray();
    }
    public Vector3 Finsh 
    {
        get => points[points.Count - 1];
    }
    public Vector3 Start 
    {
        get => points[0];
    }
}
