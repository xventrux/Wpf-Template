using System.Windows;
using Wpf.UI;

namespace Client
{
    public class UI : IUserInterface
    {
        public ApplicationTheme Theme
        {
            get
            {
                ResourceDictionary oldDict = GetThemeDictionaries().First();

                if (oldDict != null)
                {
                    if (oldDict.Source.OriginalString.Contains("Light"))
                        return ApplicationTheme.Light;
                }
                return ApplicationTheme.Dark;
            }
            set
            {
                var resourcesTheme = new ResourceDictionary
                {
                    Source = new Uri($"pack://application:,,,/WPF.UI;component/{value}/{value}Theme.xaml", UriKind.Absolute)
                };

                List<ResourceDictionary> oldDicts = GetThemeDictionaries();
                foreach (var oldDict in oldDicts)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, resourcesTheme);
                }
            }
        }

        private List<ResourceDictionary> GetThemeDictionaries()
        {
            return (from d in Application.Current.Resources.MergedDictionaries
                    where d.Source != null && d.Source.OriginalString.StartsWith("pack://application:,,,/WPF.UI;")
                    && d.Source.OriginalString.Contains("Common") == false
                    select d).ToList();
        }
    }
}
