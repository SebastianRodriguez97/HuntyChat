using System;
using System.Net;

namespace Hunty.Chat.Transverse.Exceptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ApiException(HttpStatusCode httpStatusCode)
            => this.HttpStatusCode = httpStatusCode;

        public ApiException(HttpStatusCode httpStatusCode, string message) : base(message)
            => this.HttpStatusCode = httpStatusCode;

        public ApiException(HttpStatusCode httpStatusCode, string message, Exception exception) : base(message, exception)
            => this.HttpStatusCode = httpStatusCode;
    }
}