using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;

public class JsonReader
{
    public static RootObject ReadJsonFile(string path)
    {
        string json = File.ReadAllText(path);
        RootObject r = JsonConvert.DeserializeObject<RootObject>(json);

        return r;
    }
}
