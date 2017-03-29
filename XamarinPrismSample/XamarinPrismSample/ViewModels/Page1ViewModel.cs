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
    public class Page1ViewModel : BindableBase, INavigationAware
    {
        INavigationService _navigationService;
        public DelegateCommand NavigateTo { get; private set; }
        public DelegateCommand NavigateMainPage { get; private set; }
        private string _name;

        public string Name
        {
            get{  return _name;}
            set{ SetProperty(ref _name, value);}
        }

        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set { SetProperty(ref _greeting, value); }
        }

        public Page1ViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            NavigateTo = new DelegateCommand(NavigateToNextPage);
            NavigateMainPage = new DelegateCommand(NavigateToMainPage);

            eventAggregator.GetEvent<SampleEvent>().Subscribe(UpdateGreeting);
        }

        public void UpdateGreeting(string param)
        {
            Greeting = param;
        }

        public void NavigateToNextPage()
        {
            _navigationService.NavigateAsync("Page2");
        }

        public void NavigateToMainPage()
        {
            _navigationService.NavigateAsync("MainPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("name"))
            {
                Name = (string)parameters["name"];
            }
        }
    }
}
