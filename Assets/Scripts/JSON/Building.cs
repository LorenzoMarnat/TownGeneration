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
    private static bool stickToFloor = true;

    // Set default building's height and altitude
    // Those values are used when height or altitude is missing in the JSON file
    public static void SetDefaultHeightValues(float height, float z)
    {
        defaultHeight = height;
        defaultZValue = z;
        stickToFloor = false;
    }

    // Return all coordinates as a list of Vector3. If the list is not set yet, create it
    // Scale the coordinates by "divideBy" if "scalePoints" is set to true
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

    // Return all coordinates with specified offsets as a list of Vector3 . If the list is not set yet, create it
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

                            if(stickToFloor)
                                points.Add(new Vector3(f3[0] - offsetX, 0, f3[1] - offsetZ));
                            else
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
