using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(NavPointsMap))]
public class NavPointEditor : Editor
{
    private NavPointsMap navPointMap;

    public int mapSizeX = 5; // Default map size
    public int mapSizeY = 5; // Default map size
    public int pointCount = 25; // Default number of points
    public GameObject wallPrefab = null;

    private void OnEnable()
    {
        navPointMap = (NavPointsMap)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        mapSizeX = EditorGUILayout.IntField("Map Size X", mapSizeX);
        mapSizeY = EditorGUILayout.IntField("Map Size Y", mapSizeY);
        pointCount = EditorGUILayout.IntField("Point Count", pointCount);
        wallPrefab = EditorGUILayout.ObjectField(wallPrefab, typeof(GameObject), false) as GameObject;
        //serializedObject.FindProperty("mapSizeX").objectReferenceValue = EditorGUILayout.ObjectField(serializedObject.FindProperty("mapSizeX"));
        if (GUILayout.Button("Generate Nav Points"))
        {
            GenerateNavPoints();
        }
    }

    private void GenerateNavPoints()
    {
        navPointMap.ClarAllPoints();

        Transform parent = navPointMap.transform;
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(parent.GetChild(i).gameObject);
        }

        float area = mapSizeX * mapSizeY;
        float spacing = Mathf.Sqrt(area / pointCount);

        int pointsX = Mathf.FloorToInt(mapSizeX / spacing);
        int pointsY = Mathf.FloorToInt(mapSizeY / spacing);

        float offsetX = (pointsX - 1) * spacing * 0.5f;
        float offsetZ = (pointsY - 1) * spacing * 0.5f;

        for (int x = 0; x < pointsX; x++)
        {
            for (int z = 0; z < pointsY; z++)
            {

                /*NavPoint navPoint = new NavPoint();
                navPointMap.AddNavPoint(navPoint);*/

                GameObject navPointObj = new GameObject("NavPoint");
                var coll = navPointObj.AddComponent<SphereCollider>();
                coll.isTrigger = true;
                var navPoint = navPointObj.AddComponent<NavPoint>();
                
                navPointObj.transform.position = new Vector3(x * spacing - offsetX, z * spacing - offsetZ, 0);
                navPointObj.transform.parent = parent;

                navPoint.Initialize(x, z, false, navPointMap);
                navPointMap.AddNavPoint(navPoint);
            }
        }

        EditorUtility.SetDirty(navPointMap);
    }

}
