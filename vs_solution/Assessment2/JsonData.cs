using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment2
{
    public static class JsonData
    {

        private static string companyFileName = "Vehicles.json";
        private static string clusterFolder = "C4Prog-2019S2-TDD";
        private static string companyFolder = "Data";

        public static void SaveCompany<T>(/*List<CompanyClass> companyList*/List<T> saveList)
        {
            // serialize JSON to a string and then write string to a file

            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(GetFileNamePath()))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, saveList);
            }
        }

        public static List<T> LoadCompanies<T>()
        {
            //List<CompanyClass> companyList = new List<CompanyClass>();
            List<T> loadList = new List<T>();
            //// deserialize JSON directly from a file
            if (File.Exists(GetFileNamePath()))
            {
                using (StreamReader file = File.OpenText(GetFileNamePath()))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    loadList = (List<T>)serializer.Deserialize(file, typeof(List<T>));
                }
            }
            //else
            //{
            //    companyList.Add(new CompanyClass(1, "Sample Company", "Sample Address", " Sampe City", "Sample Contact", "0123123456", "WA", "6000", "Australia", "sample@email.com", "www.google.com", DateTime.Now));
            //}

            //return companyList;
            return loadList;
        }

        public static string GetFileNamePath()
        {
            string sReturn = "";
            string companyDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + @clusterFolder + "\\" + @companyFolder;

            try
            {
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(companyDirectoryPath))
                {
                    Directory.CreateDirectory(companyDirectoryPath);
                }

                sReturn = companyDirectoryPath + "\\" + companyFileName;

            }
            catch (IOException e)
            {
                //if (e.Source != null) Console.WriteLine("OOPS, We have a problem {0}", e.Source);
            }

            return sReturn;
        }
    }
}
