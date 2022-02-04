using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Exceptions
{
    public class BaseRequestException : Exception
    {
        readonly HttpStatusCode HttpStatusCode;

        public int StatusCode { get => this.HttpStatusCode.GetHashCode(); }
        public override string Message { get; }

        public BaseRequestException(HttpStatusCode code, string message)
        {
            HttpStatusCode = code;
            Message = message ?? throw new ArgumentNullException("Message can't be null");
        }
    }
}
