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
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set { SetProperty(ref _greeting, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _buttonName = "CLICK ME";
        public string ButtonName
        {
            get { return _buttonName; }
            set { SetProperty(ref _buttonName, value); }
        }

        public DelegateCommand<string> ShowSomething { get; private set; }

        public DelegateCommand NavigateCommand { get; private set; }

        private void ShowHelloWorld(string param)
        {
            Greeting = "Hello World";
            ButtonName = param;
        }

        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ShowSomething = new DelegateCommand<string>(ShowHelloWorld, CanExecute).ObservesProperty(() => Name);
            NavigateCommand = new DelegateCommand(Navigate);
        }

        public void Navigate()
        {
            var param = new NavigationParameters();
            param.Add("name", Name);

            _navigationService.NavigateAsync("Page1",param);
        }

        public bool CanExecute(string param)
        {
            return (!string.IsNullOrEmpty(Name));
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
