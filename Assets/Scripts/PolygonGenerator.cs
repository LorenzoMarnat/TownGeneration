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
        //Building.SetDefaultHeightValues(20, 174);

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
                polygon.GeneratePolygonFromBuilding(building);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
