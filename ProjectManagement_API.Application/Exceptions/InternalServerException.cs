using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_API.Application.Exceptions
{
    public class InternalServerException:Exception
    {
        public InternalServerException(string errrMesg):base(errrMesg)
        {
            
        }
    }
}
