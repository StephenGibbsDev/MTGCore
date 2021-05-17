using System;

namespace MTGCore.Services.Exceptions
{
    public class ManaSymbolFactoryException : Exception
    {
        public ManaSymbolFactoryException(string message) : base(message)
        {
        }
    }
}