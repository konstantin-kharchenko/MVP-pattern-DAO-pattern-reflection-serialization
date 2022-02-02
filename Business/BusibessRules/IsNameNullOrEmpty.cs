using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusibessRules
{
    public class IsNameNullOrEmpty : BusinessRules
    {
        public IsNameNullOrEmpty(string propertyName)
           : base(propertyName)
        {

        }
        public override bool Validate(BusinessObject businessObject)
        {
            string opop = GetPropertyValue(businessObject).ToString();
            if (string.IsNullOrEmpty(opop)) { Error = Source.ErrorStrings.String1; return false; }
            return true;
        }
    }
}
