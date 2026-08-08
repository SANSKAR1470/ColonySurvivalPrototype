using System;
using System.IO;
using UnityEngine;

namespace ColonySurvival.Runtime
{
    public static class JSONLoader
    {
        public static T Load<T>(string fileName)
        {
            string path = Path.Combine(Application.streamingAssetsPath, fileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"JSON file not found: {path}");
            }

            string json = File.ReadAllText(path);

            T data = JsonUtility.FromJson<T>(json);

            if (data == null)
            {
                throw new Exception($"Failed to deserialize JSON: {fileName}");
            }

            return data;
        }
    }
}