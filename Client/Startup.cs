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

            services.AddWindow<MainWindow, MainViewModel>();
        }

        public Type GetStartWindowViewModelType()
        {
            return typeof(MainViewModel);
        }
    }
}
