using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingoApp.Exceptions
{
    public class ForbiddenException : ApiBaseException
    {
        public ForbiddenException(string message) : base(message)
        {
            
        }
    }
}
