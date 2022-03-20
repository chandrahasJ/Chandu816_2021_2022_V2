using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        List<string> threadLog = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            threadLog.Add($"1 MainWindow => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            threadLog.Add($"2 BtnDownload_Click => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
            //ConfigureAwait True means attach the task thread to same Thread
            string data =await GetDataFromInternet().ConfigureAwait(true);
            threadLog.Add($"4  Below Thread will be same thread as above");
            threadLog.Add($"5 BtnDownload_Click => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
            rtxtDownloadedData.Document.Blocks.Clear();
            rtxtDownloadedData.AppendText(data);
            threadLog.Add($"6 BtnDownload_Click => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
            string data2 = await GetDataFromInternetV2();
            threadLog.Add($"8 BtnDownload_Click => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");

            rtxtDownloadedData.Document.Blocks.Clear();
            rtxtDownloadedData.AppendText(data2);
            threadLog.Add($"10 BtnDownload_Click => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
        }
        private Task<string> GetDataFromInternet()
        {
            threadLog.Add($"3 GetDataFromInternet => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
            return client.GetStringAsync(txtURL.Text);                        
        }
        private async Task<string> GetDataFromInternetV2()
        {
            threadLog.Add($"7 GetDataFromInternet => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
            //ConfigureAwait false means task thread will be different thread
            var data = await client.GetStringAsync(txtURL.Text).ConfigureAwait(false);
            threadLog.Add($"8  Below Thread will be different");
            threadLog.Add($"9 GetDataFromInternet => Thread Id :> {Thread.CurrentThread.ManagedThreadId}");
            return data;
        }


        private void BtnShowLogs_Click(object sender, RoutedEventArgs e)
        {
            rTxtThreadData.Document.Blocks.Clear();
            rTxtThreadData.AppendText(FillThreadData());
        }

        public string FillThreadData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in threadLog)
            {
                stringBuilder.AppendLine(item);
            }
            return stringBuilder.ToString();
        }
    }
}
