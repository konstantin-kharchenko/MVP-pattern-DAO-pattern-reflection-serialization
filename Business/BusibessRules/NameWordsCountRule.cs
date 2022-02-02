using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusibessRules
{
    class NameWordsCountRule : BusinessRules
    {
        public NameWordsCountRule(string propertyName)
           : base(propertyName)
        {

        }
        public override bool Validate(BusinessObject businessObject)
        {
            string opop = GetPropertyValue(businessObject).ToString();
            string[] subs = opop.Split(' ');
            if (subs.Length != 3)
            {
                Error = Source.ErrorStrings.String4;
                return false;
            }
            return true;
        }
    }
}
