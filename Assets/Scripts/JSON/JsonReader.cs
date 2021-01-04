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
        RootObject r = ReadJsonFile(filePath);

        Debug.Log(JsonConvert.SerializeObject(r, Formatting.Indented));

        foreach(features f in r.features)
        {
            Debug.Log(f.GetPoints().Count);
        }
    }

    public RootObject ReadJsonFile(string path)
    {
        string json = File.ReadAllText(path);

        RootObject r = JsonConvert.DeserializeObject<RootObject>(json);

        return r;
    }
}
