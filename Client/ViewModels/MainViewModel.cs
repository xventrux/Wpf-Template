using System.Windows.Input;
using Wpf.Localization;
using Wpf.Localization.Interfaces;
using Wpf.Mvvm;
using Wpf.UI;

namespace Client.ViewModels
{
    public class MainViewModel : WindowViewModel
    {
        private readonly ILocalization _localization;
        private readonly IUserInterface _ui;

        public MainViewModel(ILocalization localization, IUserInterface ui)
        {
            _localization = localization;
            _ui = ui;

            Title = "Главное окно";

            ButtonCommand = new RelayCommand(ButtonCommandHandle);
            
        }

        public ICommand ButtonCommand { get; }

        private void ButtonCommandHandle()
        {
            _ui.Theme = _ui.Theme == ApplicationTheme.Dark ? ApplicationTheme.Light : ApplicationTheme.Dark;
            _localization.Lang = _localization.Lang == ApplicationLang.Rus ? ApplicationLang.Eng : ApplicationLang.Rus;
        }
    }
}
