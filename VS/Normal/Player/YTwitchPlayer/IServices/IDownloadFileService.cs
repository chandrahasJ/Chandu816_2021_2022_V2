using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTwitchPlayer.IServices
{
    public interface IDownloadFileService
    {
        Task<string> DownloadFileAsync(string fileUrl, string fileName, IProgress<double> progress, CancellationToken token);
    }
}
