using System;

namespace MTGCore.Services.Exceptions
{
    public class DeckServiceException : Exception
    {
        public DeckServiceException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}