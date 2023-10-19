using DevelopmentChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Toolkit
{
    public class LanguagesEnum
    {
        public List<Language> languages { get; }
        public LanguagesEnum()
        {
            languages = new List<Language>();
            languages.Add(new Language(Guid.Parse("90C3DBAB-D4FE-4ABC-A734-BFDBD380209C"), "Castellano", 1, "es-ES"));
            languages.Add(new Language(Guid.Parse("25D6FCE0-2C05-4E9E-9A9A-EB6243AB6B3A"), "Ingles", 2, "en-US"));
            languages.Add(new Language(Guid.Parse("D221401B-F0F5-43D6-A94B-AA4A2262668A"), "Italiano", 3, "it-IT"));
        }

        public class Language
        {
            public Guid Id { get; }
            public string Value { get; }
            public int IntId { get; }
            public string Culture { get; }
            public Language(Guid key, string value, int intId, string culture)
            {
                Id = key;
                IntId = intId;
                Value = value;
                Culture = culture;
            }
        }
    }
}
