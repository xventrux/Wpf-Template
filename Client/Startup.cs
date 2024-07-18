using Client.Delegates;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Wpf.Mvvm;
using Wpf.Navigation.Extensions;

namespace Client
{
    public class Startup : IStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddNavigationService();

            ConfigureWindows(services);
            ConfigureDelegates(services);
        }

        public Type GetStartWindowViewModelType()
        {
            return typeof(MainViewModel);
        }

        private void ConfigureWindows(IServiceCollection services)
        {
            services.AddWindow<MainWindow, MainViewModel>();
        }

        private void ConfigureDelegates(IServiceCollection services)
        {
            services.AddSingleton<SetThemeDelegate>(sp => theme =>
            {
                App.SetTheme(theme);
            });

            services.AddSingleton<GetThemeDelegate>(sp => () => App.GetTheme());
        }
    }
}
