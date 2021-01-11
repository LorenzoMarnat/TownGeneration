using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonGenerator : MonoBehaviour
{
    [SerializeField] List<string> files = null;
    [SerializeField] Transform polygonParent = null;
    [SerializeField] Polygon polygonPrefab = null;

    private List<RootObject> roots;

    // Start is called before the first frame update
    void Start()
    {
        // If no file is given, load test file
        if (files == null || files.Count == 0)
        {
            files = new List<string>();
            files[0] = "Test.json";
        }
        roots = new List<RootObject>();

        // Change default height and altitude, used when data is missing in file
        Building.SetDefaultHeightValues(20, 174);

        // Read every files in the list and create buildings
        foreach (string file in files)
        {
            RootObject rootObject = JsonReader.ReadJsonFile(file);
            roots.Add(rootObject);

            GeneratePolygonsFromRootObject(rootObject);
        }
    }

    // Create every building in the RootObject
    private void GeneratePolygonsFromRootObject(RootObject rootObject)
    {
        if (rootObject.features != null && rootObject.features.Count > 0)
        {
            foreach (Building building in rootObject.features)
            {
                Polygon polygon = Instantiate(polygonPrefab, polygonParent);

                // Create a gameObject from data in "building"
                Vector3 center = polygon.GeneratePolygonFromBuilding(building);
                RaycastHit hit;

                // Cast a ray down to match altitude with the terrain
                if (Physics.Raycast(center, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Map")))
                {
                    polygon.gameObject.transform.position += Vector3.down * hit.distance;
                }
                // Cast a ray up to match altitude with the terrain --> NOT WORKING
                /*else if (Physics.Raycast(center, Vector3.up, out hit, Mathf.Infinity, LayerMask.GetMask("Map")))
                    polygon.gameObject.transform.position += Vector3.up * (hit.distance + polygon.Height);*/

            }
        }
    }
}
