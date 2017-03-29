using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPrismSample.Events;

namespace XamarinPrismSample.ViewModels
{
    public class Page2ViewModel : BindableBase
    {
        INavigationService _navigationService;
        public DelegateCommand NavigateBack { get; private set; }

        IEventAggregator _eventAggregator;

        public Page2ViewModel(INavigationService navigationService,IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            NavigateBack = new DelegateCommand(NavigatePreviousPage);
        }

        public void NavigatePreviousPage()
        {
            _eventAggregator.GetEvent<SampleEvent>().Publish("Something Happened");
            _navigationService.GoBackAsync();
        }
    }
}
