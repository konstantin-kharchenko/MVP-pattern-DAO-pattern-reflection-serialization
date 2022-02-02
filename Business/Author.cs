using Business.BusibessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Author:BusinessObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Author()
        {
            AddRule(new IsNameFirstLetterUpperRule("Name"));//Название поля для проверки
            AddRule(new IsNameNullOrEmpty("Name"));
            AddRule(new NameWordsCountRule("Name"));
            AddRule(new ValidatNamePunctuation("Name"));
        }
    }
}
