using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Toolkit
{
    public class SingletonLists
    {
        public List<LanguagesEnum.Language> languages = new List<LanguagesEnum.Language>();
        private static SingletonLists instance;
        private SingletonLists()
        {
            var languagesList = new LanguagesEnum();
            languages = languagesList.languages;
        }
        public static SingletonLists GetInstance()
        {
            if (instance == null)
            {
                instance = new SingletonLists();
            }
            return instance;
        }
    }
}
