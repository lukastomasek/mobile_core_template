using UnityEngine;
using System.IO;


namespace Mobile_Core
{
    public class SaveManager<T>
    {
        static string _directory = "/GameData/";
        static string _fileName = "MyData.txt";

        static bool _fileExist = false;


        public static void Save(T data)
        {
            string dir = Application.persistentDataPath + _directory;

            if (!Directory.Exists(dir))
            {
                _fileExist = true;
                Directory.CreateDirectory(dir);
            }

            var json = JsonUtility.ToJson(data, true);

            File.WriteAllText(dir + _fileName, json);
        }

        //public static T Load()
        //{
        //    string fullPath = Application.persistentDataPath + _directory + _fileName;

        //    T data;

        //    if (File.Exists(fullPath))
        //    {
        //        var json = File.ReadAllText(fullPath);

        //        data = JsonUtility.FromJson<T>(json);


        //    }
        //    else
        //    {
        //        Debug.LogWarning("Save File Doesn't Exist, {creating new fiel}");

        //        //data = "";

        //        //Save(data);
        //    }


        //    return data;

        //}

    }


}