using SimpleTraderApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels.Factories
{
    public class MajorIndexListingViewModelFactory : ISimpleTraderViewModelFactory<MajorIndexListingViewModel>
    {
        private readonly IMajorIndexService _majorIndexService;

        public MajorIndexListingViewModelFactory(IMajorIndexService majorIndexService)
        {
            this._majorIndexService = majorIndexService;
        }

        public MajorIndexListingViewModel CreateViewModel()
        {
            return MajorIndexListingViewModel.LoadMajorIndexViewModel(_majorIndexService);
        }
    }
}
