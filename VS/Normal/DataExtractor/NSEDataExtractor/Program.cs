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
            if (!Directory.Exists(Constants.ExcelFolderPath))
            {
                Directory.CreateDirectory(Constants.ExcelFolderPath);
            }

            Settings settings = JsonFileHelper.ConvertJsonStringToObject<Settings>(
                JsonFileHelper.ReadTheJsonFile($"{Constants.JsonFolderPath}{Constants.SettingFileName}"));

            var optionChainService = new OptionChainService();

            foreach (var symbol in settings!.Symbols)
            {
                try
                {
                    Thread.Sleep(10000);
                    var data = optionChainService.GetOptionChainData(symbol)?.Result;

                    if (data != null)
                    {
                        var filteredData = data.Filtered.Data
                            .Where(x => x.ExpiryDate == DateHelper.GetNextWeekday(DateTime.Now, DayOfWeek.Thursday).ToString("dd-MMM-yyyy"))
                            .ToList();
                        string fileName = $"{symbol}_{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xlsx";
                        string excelFilePath = $"{Constants.ExcelFolderPath}\\{fileName}";

                        List<CE> ceList = new List<CE>();
                        List<PE> peList = new List<PE>();

                        foreach (var item in filteredData)
                        {                            
                            ceList.Add(item.CE);
                            peList.Add(item.PE);
                        }
                        using (ExcelHelper excelHelper = new ExcelHelper(excelFilePath))
                        {
                            excelHelper.DataTableToExcel(ceList.ToDataTable<CE>(), nameof(CE), true);
                            excelHelper.DataTableToExcel(peList.ToDataTable<PE>(), nameof(PE), true);
                        }
                        using (ExcelHelper excelHelper = new ExcelHelper(excelFilePath))
                        {
                            excelHelper.DataTableToExcel(ceList.ToDataTable<CE>(), nameof(CE), true);
                            excelHelper.DataTableToExcel(peList.ToDataTable<PE>(), nameof(PE), true);
                        }
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
        Console.ReadLine();
    }

    public static void Get()
    {
        JsonFileHelper.SaveTheJsonFile(JsonFileHelper.CreateTheJsonFile(new Settings()
        {
            Symbols = Constants.Symbols
        }), $"{Constants.JsonFolderPath}{Constants.SettingFileName}");
    }
}