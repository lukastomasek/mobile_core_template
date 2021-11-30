using UnityEngine;
using System.IO;


namespace Mobile_Core
{
    public static class SaveManager
    {
        static string _directory = "/GameData/";
        static string _fileName = "MyData.txt";

        public static bool fileExist = false;


        public static void Save(SaveData data)
        {
            string dir = Application.persistentDataPath + _directory;

            if (!Directory.Exists(dir))
            {
                fileExist = true;
                Directory.CreateDirectory(dir);
            }

            var json = JsonUtility.ToJson(data, true);

            File.WriteAllText(dir + _fileName, json);

            //Debug.Log("<color=green> SAVING </color>");
        }

        public static SaveData Load()
        {
            var fullPath = Application.persistentDataPath + _directory + _fileName;

            SaveData data = new SaveData();

            if (File.Exists(fullPath))
            {
                var json = File.ReadAllText(fullPath);

                data = JsonUtility.FromJson<SaveData>(json);

                //Debug.Log("<color=green> LOADING </color>");


            }
            else
            {
                Debug.LogWarning($"{0}: File Does not exist, creating new save file: <b>{data} </b>. ");

                SaveData newFile = new SaveData();

                Save(newFile);
            }

            return data;
        }

        public static void ResetData()
        {
            var fullPath = Application.persistentDataPath + _directory + _fileName;

            SaveData data = new SaveData();

            if (Directory.Exists(fullPath))
            {
                var json = File.ReadAllText(fullPath);

                data = JsonUtility.FromJson<SaveData>(json);

                data.Reset();
            }
            else
            {
                Debug.LogWarning("{0}: No Data to reset!");
            }
        }
    }




}