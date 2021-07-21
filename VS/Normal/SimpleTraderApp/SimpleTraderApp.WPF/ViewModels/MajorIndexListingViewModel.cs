﻿using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private IMajorIndexService _majorIndexService;
        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            this._majorIndexService = majorIndexService;
        }

        private MajorIndex _dowJones;
        public MajorIndex DowJones
        {
            get
            {
                return _dowJones;
            }
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex _nasdaq;
        public MajorIndex Nasdaq
        {
            get
            {
                return _nasdaq;
            }
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex _sp500;
        public MajorIndex SP500
        {
            get
            {
                return _sp500;
            }
            set
            {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

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

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

    }
}
