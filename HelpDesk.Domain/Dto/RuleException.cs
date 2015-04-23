using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Dto
{
    public class RuleException : Exception
    {
        public NameValueCollection Errors { get; private set; }

        public RuleException(string key, string value)
        {
            Errors = new NameValueCollection { { key, value } };
        }

        public RuleException(NameValueCollection errors)
        {
            Errors = errors;
        }


    }
}
