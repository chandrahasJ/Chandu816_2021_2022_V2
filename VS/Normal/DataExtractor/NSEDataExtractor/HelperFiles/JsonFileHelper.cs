using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constants = NSE.Model.Constants;

namespace NSEDataExtractor.HelperFiles
{
    public static  class JsonFileHelper
    {
        private static string JsonFolderName = Constants.JsonFolderName;
        private static string JsonFolderPath = Constants.JsonFolderPath;

        static JsonFileHelper()
        {             
            if (!Directory.Exists(JsonFolderPath))
            {
                Directory.CreateDirectory(JsonFolderPath);
            }             
        }

        public static bool SaveTheJsonFile(string jsonData, string saveFilePath)
        {
            File.WriteAllText(saveFilePath, jsonData);
            return true;
        }

        public static string CreateTheJsonFile(object objectData)
        {
            string stringjson = "";
            if (objectData != null)
            {
                stringjson = JsonConvert.SerializeObject(objectData);
            }
            return stringjson;
        }

        public static T ConvertJsonStringToObject<T>(string jsonString) where T : class
        {
            T result = JsonConvert.DeserializeObject<T>(jsonString);
            return result;
        }

        public static string ReadTheJsonFile(string readFilePath)
        {
            return File.ReadAllText(readFilePath);
        }

        public static string GetLatestFile()
        {
            var directory = new DirectoryInfo(JsonFolderPath);
            return directory.GetFiles()
                             .OrderByDescending(f => f.LastWriteTime)
                             .FirstOrDefault()?.FullName.ToString();
        }
    }
}
