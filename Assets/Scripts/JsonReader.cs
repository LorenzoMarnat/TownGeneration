using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    [SerializeField] string filePath = "";
    // Start is called before the first frame update
    void Start()
    {
        string json = File.ReadAllText(filePath);

        try
        {
            RootObject r = JsonUtility.FromJson<RootObject>(json);
            Debug.Log(r.ToString());
        }
        catch(Exception)
        {
            Debug.Log("Error");
        }

    }
}
