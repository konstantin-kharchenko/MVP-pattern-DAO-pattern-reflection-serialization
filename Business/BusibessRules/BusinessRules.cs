using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusibessRules
{
    public abstract class BusinessRules
    {
        public string Property { get; set; }
        public string Error { get; set; }
        public BusinessRules(string Property)
        {
            this.Property = Property;
        }
        public abstract bool Validate(BusinessObject businessObject);

        protected object GetPropertyValue(BusinessObject businessObject)
        {
            return businessObject.GetType().GetProperty(Property).GetValue(businessObject, null);
        }
    }
}
