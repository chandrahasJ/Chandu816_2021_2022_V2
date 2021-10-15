using SimpleTraderApp.Domain.Models;
using SimpleTraderApp.Domain.Services;
using SimpleTraderApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTraderApp.WPF.Commands
{
    public class LoadMajorInddexesCommand : AsyncCommandBase
    {
        private readonly MajorIndexListingViewModel _majorIndexListingViewModel;
        private readonly IMajorIndexService _majorIndexService;

        public LoadMajorInddexesCommand(MajorIndexListingViewModel majorIndexListingViewModel,IMajorIndexService majorIndexService)
        {
            this._majorIndexListingViewModel = majorIndexListingViewModel;
            this._majorIndexService = majorIndexService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _majorIndexListingViewModel.IsLoading = true;

            await Task.WhenAll(LoadDowJones(), LoadNasdaq(), LoadSP500());

            _majorIndexListingViewModel.IsLoading = false;
        }

        private async Task LoadDowJones()
        {
            _majorIndexListingViewModel.DowJones = await _majorIndexService.GetMajorIndex(MajorIndexType.DowJones);
        }

        private async Task LoadNasdaq()
        {
            _majorIndexListingViewModel.Nasdaq = await _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq);
        }

        private async Task LoadSP500()
        {
            _majorIndexListingViewModel.SP500 = await _majorIndexService.GetMajorIndex(MajorIndexType.SP500);
        }
    }
}
