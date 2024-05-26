using Newtonsoft.Json;
using System;
using System.IO;

namespace LibSer
{
    public class SerDeser
    {
        public static T Deserialize<T>(string path)
        {
            string json = File.ReadAllText(path);
            T JJson = JsonConvert.DeserializeObject<T>(json);
            return JJson;
        }

        public static void Serialize<T>(T something, string path)
        {
            string json = JsonConvert.SerializeObject(something);
            File.WriteAllText(path, json);
        }
    }
}