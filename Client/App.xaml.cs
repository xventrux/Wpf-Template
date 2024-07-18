using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Windows;
using Wpf.Localization;
using Wpf.Mvvm;
using Wpf.Navigation;
using Wpf.UI;

namespace Client;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;
    private readonly IStartup _startup;

    public App()
    {
        IServiceCollection services = new ServiceCollection();
        _startup = new Startup();
        
        _startup.ConfigureServices(services);

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        INavigationService navigationService = _serviceProvider.GetRequiredService<INavigationService>();
        navigationService.ShowWindow(_startup.GetStartWindowViewModelType());
    }
}

