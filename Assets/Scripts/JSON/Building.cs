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

    private static float defaultHeight = 20;
    private static float defaultZValue = 200;

    public static void SetDefaultHeightValues(float height, float z)
    {
        defaultHeight = height;
        defaultZValue = z;
    }
    public List<Vector3> GetPoints(bool scalePoints = false, float divideBy = 1)
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
                            if (f3[2] >= 9999)
                                f3[2] = defaultZValue;

                            if(scalePoints && divideBy != 0)
                                points.Add(new Vector3(f3[0] / divideBy, f3[2] / divideBy, f3[1] / divideBy));
                            else
                                points.Add(new Vector3(f3[0], f3[2], f3[1]));
                        }
                    }
        }
        return points;
    }
    public List<Vector3> GetPointsWithOffset(float offsetX, float offsetZ, float offsetY = 0)
    {
        if (points == null)
        {
            points = new List<Vector3>();

            foreach (List<List<List<float>>> f1 in geometry.coordinates)
                foreach (List<List<float>> f2 in f1)
                    foreach (List<float> f3 in f2)
                    {

                        if (f3.Count >= 3)
                        {
                            if (f3[2] >= 9999)
                                f3[2] = defaultZValue;

                            points.Add(new Vector3(f3[0]-offsetX, f3[2]-offsetY, f3[1]-offsetZ));
                        }
                    }
        }
        return points;
    }

    public float GetHeight()
    {
        if (properties.HAUTEUR <= 0)
            return defaultHeight;
        else
            return properties.HAUTEUR;
    }

    public string GetID()
    {
        return properties.ID;
    }
}
