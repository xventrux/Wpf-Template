using Client.Delegates;
using System.Security.AccessControl;
using System.Windows.Input;
using Wpf.Mvvm;
using Wpf.UI;

namespace Client.ViewModels
{
    public class MainViewModel : WindowViewModel
    {
        private readonly SetThemeDelegate _setTheme;
        private readonly GetThemeDelegate _getTheme;

        public MainViewModel(SetThemeDelegate setTheme, GetThemeDelegate getTheme)
        {
            _setTheme = setTheme;
            _getTheme = getTheme;

            Title = "Главное окно";

            SwitchThemeCommand = new RelayCommand(SwitchThemeCommandHandle);
            
        }

        public ICommand SwitchThemeCommand { get; }

        private void SwitchThemeCommandHandle()
        {
            _setTheme(_getTheme() == ApplicationTheme.Dark ? ApplicationTheme.Light : ApplicationTheme.Dark);
        }
    }
}
