using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusibessRules
{
    public class IsNameFirstLetterUpperRule : BusinessRules
    {
        public IsNameFirstLetterUpperRule(string propertyName)
            : base(propertyName)
        {

        }
        public override bool Validate(BusinessObject businessObject)
        {
            string opop = GetPropertyValue(businessObject).ToString();
            if (char.IsUpper(opop[0]))
            {
                for (int i = 0; i < opop.Length; i++)
                {
                    if (opop[i] == ' ') if (!char.IsUpper(opop[i + 1])) { Error = Source.ErrorStrings.String3; return false; }
                }
            }
            else { Error = Source.ErrorStrings.String3; return false; }
            return true;
        }
    }
}
