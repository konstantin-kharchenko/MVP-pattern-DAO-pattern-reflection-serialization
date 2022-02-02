using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusibessRules
{
    public class ValidatNamePunctuation : BusinessRules
    {
        public ValidatNamePunctuation(string propertyName)
           : base(propertyName)
        {

        }
        public override bool Validate(BusinessObject businessObject)
        {
            string opop = GetPropertyValue(businessObject).ToString();
            if (opop.PunctuationMark())
            {
                Error = Source.ErrorStrings.String2;
                return false;
            }
            return true;
        }

    }
    public static class Help
    {
        public static bool PunctuationMark(this string name)
        {
            foreach (var r in name)
            {
                if (char.IsPunctuation(r)) return false;
            }
            return true;
        }
    }
}
