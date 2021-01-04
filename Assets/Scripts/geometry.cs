using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class geometry
{
    public string type { get; set; }
    public List<List<List<List<float>>>> coordinates { get; set; }
}
