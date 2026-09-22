using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Exceptions
{
    public class UnauthorizedException:Exception
    {
        public UnauthorizedException(string errorMesg):base(errorMesg) { }
        
    }
}
