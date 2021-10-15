using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.Commands;
using SimpleTraderApp.WPF.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTraderApp.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private IMajorIndexService _majorIndexService;
        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            this._majorIndexService = majorIndexService;
            _majorIndexService.SetApiKey(SecretManagerClass.mySettingConfiguration.FMPApiKey);
            LoadMajorIndexCommand = new LoadMajorInddexesCommand(this, majorIndexService);
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
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

         
        public ICommand LoadMajorIndexCommand { get; }
         
        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            MajorIndexListingViewModel majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);

            majorIndexViewModel.LoadMajorIndexCommand.Execute(null);

            return majorIndexViewModel;
        }

    }
}
