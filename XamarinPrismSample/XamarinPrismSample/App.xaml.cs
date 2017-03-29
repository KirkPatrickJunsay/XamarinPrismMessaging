using Prism.Unity;
using XamarinPrismSample.Views;

namespace XamarinPrismSample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Page1>();
            Container.RegisterTypeForNavigation<Page2>();
        }
    }
}
