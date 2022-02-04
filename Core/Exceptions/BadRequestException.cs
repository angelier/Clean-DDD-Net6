using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Exceptions
{
    public class BadRequestException : BaseRequestException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}
