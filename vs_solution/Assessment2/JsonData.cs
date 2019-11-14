using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment2
{
    public static class JsonData
    {
        private static string clusterFolder = "C4Prog-2019S2-TDD";
        private static string dataFolder = "Data";

        public static void Save<T>(List<T> saveList)
        {
            // serialize JSON to a string and then write string to a file
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(GetFileNamePath(typeof(T).Name)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, saveList);
            }
        }

        public static List<T> Load<T>()
        {
            //// deserialize JSON directly from a file
            List<T> loadList = new List<T>();            
            string sFile = GetFileNamePath(typeof(T).Name);

            if (File.Exists(sFile))
            {
                using (StreamReader file = File.OpenText(sFile))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    loadList = (List<T>)serializer.Deserialize(file, typeof(List<T>));
                }
            }

            return loadList;
        }

        public static string GetFileNamePath(string fileName)
        {
            string sReturn = "";
            string companyDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + @clusterFolder + "\\" + dataFolder;

            try
            {
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(companyDirectoryPath))
                {
                    Directory.CreateDirectory(companyDirectoryPath);
                }

                sReturn = companyDirectoryPath + "\\" + fileName + ".json";

            }
            catch (IOException e)
            {
                //if (e.Source != null) Console.WriteLine("OOPS, We have a problem {0}", e.Source);
            }

            return sReturn;
        }
    }
}
