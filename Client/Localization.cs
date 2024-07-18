using System.Globalization;
using System.Windows;
using Wpf.Localization;
using Wpf.Localization.Interfaces;

namespace Client
{
    public class Localization : ILocalization
    {
        private List<CultureInfo> _languages = new List<CultureInfo>();

        public Localization()
        {
            InitLanguages();
        }

        public ApplicationLang Lang
        {
            get => Language.GetLang(_currentLanguage.Name);
            set
            {
                _currentLanguage = _languages.Where(x => x.Name == Language.GetLangKey(value)).SingleOrDefault() 
                    ?? _languages.First();
            }
        }

        private CultureInfo _currentLanguage
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                if (value == Thread.CurrentThread.CurrentUICulture) return;

                Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "en-US":
                        dict.Source = new Uri($"pack://application:,,,/WPF.Localization;component/Lang.en-US.xaml", UriKind.Absolute);
                        break;
                    default:
                        dict.Source = new Uri($"pack://application:,,,/WPF.Localization;component/Lang.ru-RU.xaml", UriKind.Absolute);
                        break;
                }

                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("pack://application:,,,/WPF.Localization;")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }
            }
        }

        public void AddCulter(string key)
        {
            _languages.Add(new CultureInfo(key));
        }

        private void InitLanguages()
        {
            foreach(ApplicationLang lang in Enum.GetValues(typeof(ApplicationLang)))
            {
                string key = Language.GetLangKey(lang);
                if(_languages.Any(x => x.Name == key) == false)
                    AddCulter(key);
            }
        }
    }
}
