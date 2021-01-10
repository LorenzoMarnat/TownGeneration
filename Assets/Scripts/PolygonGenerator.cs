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
        if(files == null || files.Count == 0)
        {
            files = new List<string>();
            files[0] = "Test.json";
        }
        roots = new List<RootObject>();

        Building.SetDefaultHeightValues(20, 174);

        foreach(string file in files)
        {
            RootObject rootObject = JsonReader.ReadJsonFile(file);
            roots.Add(rootObject);

            GeneratePolygonsFromRootObject(rootObject);
        }
    }

    private void GeneratePolygonsFromRootObject(RootObject rootObject)
    {
        if(rootObject.features != null && rootObject.features.Count > 0)
        {
            foreach(Building building in rootObject.features)
            {
                Polygon polygon = Instantiate(polygonPrefab, polygonParent);

                Vector3 center = polygon.GeneratePolygonFromBuilding(building);
                //Debug.Log(center);
                RaycastHit hit;

                if (Physics.Raycast(center, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Map")))
                {
                    polygon.gameObject.transform.position += Vector3.down * hit.distance;
                }
                else if(Physics.Raycast(center, Vector3.up, out hit, Mathf.Infinity, LayerMask.GetMask("Map")))
                    polygon.gameObject.transform.position += Vector3.up * (hit.distance + polygon.Height);
                //Debug.Log(polygon.gameObject.transform.position);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
