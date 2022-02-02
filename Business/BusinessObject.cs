using Business.BusibessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessObject
    {
        List<BusinessRules> businessRules;
        List<string> errors = new List<string>();

        public BusinessObject()
        {
            businessRules = new List<BusinessRules>();
        }

        public List<string> Errors
        {
            get { return errors; }
        }

        protected void AddRule(BusinessRules rule)
        {
            businessRules.Add(rule);
        }
        public bool IsValid()
        {
            bool valid = true;

            errors.Clear();

            foreach (var rule in businessRules)
            {
                if (!rule.Validate(this))
                {
                    valid = false;
                    errors.Add(rule.Error);
                }
            }
            return valid;
        }
    }
}
