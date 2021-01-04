using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class geometry
{
    public string type;
    public List<float> coordinates;
    //public string coordinates;

    public override string ToString()
    {
        string r = " Type " + type + " Coords : " + /*coordinates.Count.ToString() +*/  " End";
        /*foreach(Vector3 vec in coordinates)
        {
            r += vec.ToString() + " ";
        }*/
        return r;
    }
}
