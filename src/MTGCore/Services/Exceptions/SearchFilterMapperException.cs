using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTGCore.Services.Exceptions
{
    public class SearchFilterMapperException : Exception
    {
        public SearchFilterMapperException(string message) : base(message)
        {
        }
    }
}
