namespace Wpf.Localization
{
    public class Language
    {
        private static Dictionary<string, ApplicationLang> keyValuePairs = new Dictionary<string, ApplicationLang>()
        {
            { Rus, ApplicationLang.Rus },
            { Eng, ApplicationLang.Eng },
        };

        public static string Rus => "ru-RU";
        public static string Eng => "en-US";

        public static string GetLangKey(ApplicationLang lang)
        {
            return keyValuePairs.Where(x => x.Value == lang).Single().Key;
        }

        public static ApplicationLang GetLang(string langStr)
        {
            ApplicationLang lang;
            bool isSuccess = keyValuePairs.TryGetValue(langStr, out lang);

            if(isSuccess)
                return lang;
            else 
                return ApplicationLang.Rus;
        }
    }
}
