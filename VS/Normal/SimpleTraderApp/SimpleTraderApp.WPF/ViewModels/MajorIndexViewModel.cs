using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class MajorIndexViewModel
    {
        private IMajorIndexService _majorIndexService;
        public MajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            this._majorIndexService = majorIndexService;
        }

        public MajorIndex DowJones { get; set; }
        public MajorIndex Nasdaq { get; set; }
        public MajorIndex SP500 { get; set; }

        private void LoadMajorIndexes()
        {
            _majorIndexService.SetApiKey(SecretManagerClass.mySettingConfiguration.FMPApiKey);
             

            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    DowJones = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith((task) =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });

        }

        public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexViewModel majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

    }
}
