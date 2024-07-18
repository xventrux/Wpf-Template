using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
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

    private static ApplicationTheme s_currentTheme;

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

        SetTheme(ApplicationTheme.Dark);

        INavigationService navigationService = _serviceProvider.GetRequiredService<INavigationService>();
        navigationService.ShowWindow(_startup.GetStartWindowViewModelType());
    }

    public static void SetTheme(ApplicationTheme theme)
    {
        var resourcesTheme = new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,/WPF.UI;component/{theme}/{theme}Theme.xaml", UriKind.Absolute)
        };
        
        var resourcesCommonStyles = new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,/WPF.UI;component/Common/Styles.xaml", UriKind.Absolute),
        };

        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourcesTheme);
        Application.Current.Resources.MergedDictionaries.Add(resourcesCommonStyles);

        s_currentTheme = theme;
    }

    public static ApplicationTheme GetTheme() => s_currentTheme;
}

