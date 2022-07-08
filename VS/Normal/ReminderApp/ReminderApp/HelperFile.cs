using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp
{
    public class HelperFile
    {
        public readonly string FolderName = "JsonFiles";
        public readonly string FolderPath;

        public HelperFile()
        {
            FolderPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + FolderName + "\\";
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }

        public bool SaveTheJsonFile(string jsonData, string saveFilePath)
        {            
            File.WriteAllText(saveFilePath, jsonData);
            return true;
        }

        public string CreateTheJsonFile(object objectData) 
        {
            string stringjson = "";
            if (objectData != null)
            {
                stringjson = JsonConvert.SerializeObject(objectData);
            }           
            return stringjson;
        }

        public T ConvertJsonStringToObject<T>(string jsonString) where  T :class
        {
            T result = JsonConvert.DeserializeObject<T>(jsonString);
            return result;
        }

        public string ReadTheJsonFile(string readFilePath)
        {
           return File.ReadAllText(readFilePath);
        }

        public string GetLatestFile()
        {
            var directory = new DirectoryInfo(FolderPath);
            return directory.GetFiles()
                             .OrderByDescending(f => f.LastWriteTime)
                             .First().FullName.ToString();
        }
    }
}
