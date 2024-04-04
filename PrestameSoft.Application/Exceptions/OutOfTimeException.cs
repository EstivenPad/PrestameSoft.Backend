using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestameSoft.Application.Exceptions
{
    public class OutOfTimeException : Exception
    {
        public OutOfTimeException() : base("Request can't be processed after 30 minutes")
        {
            
        }
    }
}
