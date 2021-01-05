using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour
{
    public Material mat;

    public string ID { get; set; }
    public float Height { get; set; }
    public List<Vector3> Coordinates { get; set; }

    public Vector3[] vertices;
    public int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        /*gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Coordinates = new List<Vector3>();
        Height = 4f;
        Coordinates.Add(new Vector3(-1, 0, 0));
        Coordinates.Add(new Vector3(1, 0, 0));
        Coordinates.Add(new Vector3(1, 0, 1));
        Coordinates.Add(new Vector3(-1, 0, 1));

        InitVertices();
        ShowVertices();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneratePolygonFromBuilding(Building building)
    {
        // Scale coordinates
        //Coordinates = building.GetPoints(true,5000);

        // Add offset to coordinates
        Coordinates = building.GetPointsWithOffset(844000,6519000);

        Height = building.GetHeight();
        ID = building.GetID();
        InitVertices();
        //ShowVertices();

        CreateTriangles();
        CreateMesh();
    }

    void CreateMesh()
    {
        gameObject.transform.name = ID;
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = mat;

        msh.RecalculateNormals();
    }
    void CreateTriangles()
    {
        triangles = new int[(Coordinates.Count * 6) + (Coordinates.Count * 6)];
        int k = 0;

        // Triangles faces haute et basse
        for (int j = 1; j <= Coordinates.Count; j++)
        {
            // Basse
            triangles[k] = 0;
            triangles[k + 1] = (j % Coordinates.Count) + 1;
            triangles[k + 2] = j;

            // Haute
            triangles[k + 3] = (Coordinates.Count + 1);
            triangles[k + 4] = (Coordinates.Count + 1) + j;
            triangles[k + 5] = (Coordinates.Count + 1) + (j % Coordinates.Count) + 1;

            k += 6;
        }

        // Triangles faces cotés
        for (int i = 1; i <= Coordinates.Count; i++)
        {
            triangles[k] = i;
            triangles[k + 1] = (Coordinates.Count + 1) + (i % Coordinates.Count) + 1;
            triangles[k + 2] = (Coordinates.Count + 1) + i;
            triangles[k + 3] = i;
            triangles[k + 4] = (i % Coordinates.Count) + 1;
            triangles[k + 5] = (Coordinates.Count + 1) + (i % Coordinates.Count) + 1;
            k += 6;
        }
    }
    void InitVertices()
    {
        vertices = new Vector3[2 * (Coordinates.Count + 1)];

        Vector3 center = GetMeridianCenter();
        vertices[0] = center;
        BuildMeridianVertices(1, 0);
        vertices[Coordinates.Count + 1] = center + new Vector3(0, Height, 0);
        BuildMeridianVertices(Coordinates.Count + 2, Height);
    }

    void BuildMeridianVertices(int i, float dtY)
    {
        for (int j = 0; j < Coordinates.Count; j++)
        {
            Vector3 coord = Coordinates[j] + new Vector3(0, dtY, 0);
            vertices[i + j] = coord;
        }
    }

    Vector3 GetMeridianCenter()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        foreach (Vector3 coord in Coordinates)
        {
            x += coord.x;
            y += coord.y;
            z += coord.z;
        }

        x /= Coordinates.Count;
        y /= Coordinates.Count;
        z /= Coordinates.Count;

        return new Vector3(x, y, z);
    }

    void ShowVertices()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Debug.Log(vertices[i]);
        }
    }
}
