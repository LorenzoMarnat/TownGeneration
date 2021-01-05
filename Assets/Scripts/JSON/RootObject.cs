using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class RootObject
{
    public string type { get; set; }
    public string name { get; set; }
    public List<Building> features { get; set; }
}
