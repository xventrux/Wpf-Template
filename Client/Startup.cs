using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Localization.Interfaces;
using Wpf.Mvvm;
using Wpf.Navigation.Extensions;
using Wpf.UI;

namespace Client
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNavigationService();

            services.AddSingleton<ILocalization, Localization>();
            services.AddSingleton<IUserInterface, UI>();

            ConfigureWindows(services);
        }

        public Type GetStartWindowViewModelType()
        {
            return typeof(MainViewModel);
        }

        private void ConfigureWindows(IServiceCollection services)
        {
            services.AddWindow<MainWindow, MainViewModel>();
        }
    }
}
