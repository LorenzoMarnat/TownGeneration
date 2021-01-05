using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour
{
    public Material mat;

    public string ID { get; set; }
    public float Height { get; set; }
    public List<Vector3> Coordinates { get; set; }

    private Vector3[] vertices;
    private int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Coordinates = new List<Vector3>();
        Height = 4f;
        Coordinates.Add(new Vector3(-1, 0, 0));
        Coordinates.Add(new Vector3(1, 0, 0));
        Coordinates.Add(new Vector3(1, 0, 1));
        Coordinates.Add(new Vector3(-1, 0, 1));

        InitVertices();
        ShowVertices();
    }

    // Update is called once per frame
    void Update()
    {
        
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
