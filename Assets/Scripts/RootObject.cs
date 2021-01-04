using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class RootObject
{
    public string type;
    public string name;
    public List<features> features;

    public override string ToString()
    {
        string toReturn = "Type " + type + " Name " + name + " Nb features " + features.Count.ToString() + "\n";

        foreach(features f in features)
        {
            toReturn += f.ToString() + "\n";
        }

        return toReturn;
    }
}
