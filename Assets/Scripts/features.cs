using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class features
{
    public string type;
    public properties properties;

    public override string ToString()
    {
        return "Type " + type + " Properties " + properties.ToString();
    }
}
