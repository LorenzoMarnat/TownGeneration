using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Building
{
    public string type { get; set; }
    public properties properties { get; set; }
    public geometry geometry { get; set; }

    private List<Vector3> points;

    public List<Vector3> GetPoints()
    {
        if(points == null)
        {
            points = new List<Vector3>();

            foreach(List<List<List<float>>> f1 in geometry.coordinates)
                foreach(List<List<float>> f2 in f1)
                    foreach(List<float> f3 in f2)
                    {
                        if(f3.Count >= 3)
                        {
                            points.Add(new Vector3(f3[0], f3[1], f3[2]));
                        }
                    }
        }
        return points;
    }

    public float GetHeight()
    {
        return properties.HAUTEUR;
    }

    public string GetID()
    {
        return properties.ID;
    }
}
