using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonReader : MonoBehaviour
{
    [SerializeField] string filePath = "";
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(filePath);


        //RootObject r = JsonUtility.FromJson<RootObject>(json);

        RootObject r = JsonConvert.DeserializeObject<RootObject>(json);

        Debug.Log(JsonConvert.SerializeObject(r, Formatting.Indented));

        foreach(features f in r.features)
        {
            Debug.Log(f.GetPoints().Count);
        }
    }
}
