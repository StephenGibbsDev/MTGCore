using System;

namespace MTGCore.MtgClient.Api.Exceptions
{
    public class MtgClientException : Exception
    {
        public MtgClientException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}