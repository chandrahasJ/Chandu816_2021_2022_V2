using DataExtractor.Services;
using log4net;
using MathNet.Numerics;
using NSE.Model;
using NSE.Model.Models;
using NSEDataExtractor;
using NSEDataExtractor.Extensions;
using NSEDataExtractor.HelperFiles;
using System.Data;
using System.Security;
using Constants = NSE.Model.Constants;

internal partial class Program
{
    static void Main(string[] args)
    {
        log4net.Config.XmlConfigurator.Configure();
        ILog log = LogManager.GetLogger(nameof(Program));

        // obtain logger instance        
        try
        {
            Console.WriteLine("Process Started");
            if (!Directory.Exists(Constants.ExcelFolderPath))
            {
                Directory.CreateDirectory(Constants.ExcelFolderPath);
            }

            Settings settings = GetSettingsFileData<Settings>();

            var optionChainService = new OptionChainService();

            foreach (var symbol in settings!.Symbols)
            {
                try
                {
                    Console.WriteLine("Process halted for 10 sec");
                    Thread.Sleep(10000);
                    Console.WriteLine($"Downloading Started.. {symbol}");
                    var data = optionChainService.GetOptionChainData(symbol)?.Result;

                    if (data != null)
                    {
                        var filteredData = data.Filtered.Data
                            .Where(x => x.ExpiryDate == DateHelper.GetNextWeekday(DateTime.Now, DayOfWeek.Thursday).ToString("dd-MMM-yyyy"))
                            .ToList();

                        Console.WriteLine($"Generate Excel Started.. {symbol}");
                        GenerateExcel(symbol, filteredData);    
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Internal Error  - {symbol}", ex);
                }
            }
        }
        catch (Exception ex)
        {
            log.Error("Outer Error DataExtractor", ex);
        }
       // Console.ReadLine();
    }

    private static Dictionary<string, DataTable> GenerateDictonary(List<Datum> filteredData)
    {
        List<CE> ceList = new List<CE>();
        List<PE> peList = new List<PE>();
        Dictionary<string, DataTable> dicSheetName_DataTable = new Dictionary<string, DataTable>();

        foreach (var item in filteredData)
        {
            ceList.Add(item.CE);
            peList.Add(item.PE);
        }
        dicSheetName_DataTable.Add(nameof(CE), ceList.ToDataTable<CE>());
        dicSheetName_DataTable.Add(nameof(PE), peList.ToDataTable<PE>());

        return dicSheetName_DataTable;
    }

    private static void GenerateExcel(string symbol, List<Datum> filteredData)
    {
        string fileName = $"{symbol}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xlsx";
        string excelFilePath = $"{Constants.ExcelFolderPath}\\{fileName}";
        Console.WriteLine($"Creating Excel for {symbol}");
        using (ExcelHelper excelHelper = new ExcelHelper(excelFilePath))
        {
            excelHelper.DataTablesToExcel(GenerateDictonary(filteredData), true);
        }
    }

    private static T GetSettingsFileData<T>() where T : class
    {
        return JsonFileHelper.ConvertJsonStringToObject<T>(
                JsonFileHelper.ReadTheJsonFile($"{Constants.JsonFolderPath}{Constants.SettingFileName}"));
    }
}