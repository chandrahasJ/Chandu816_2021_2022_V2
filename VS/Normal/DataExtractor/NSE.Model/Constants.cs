using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSE.Model
{
    public static class Constants
    {
        public static string ApiServiceURL = "https://www.nseindia.com/api/";
        public static string OptionChainQuery = "option-chain-indices?symbol={0}";
        public static string SettingFileName = $"NSE_Settings.json";
        public static string JsonFolderName = "SettingFiles";
        public static string JsonFolderPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + JsonFolderName + "\\";
        public static string ExcelFolderName = "ExcelFiles";
        public static string ExcelFolderPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + ExcelFolderName + "\\";
        public static List<string> Symbols = new List<string>()
        {
            "NIFTY",
            "FINNIFTY",
            "BANKNIFTY",
            "MIDCPBIFTY"
        };
    }
}
