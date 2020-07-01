using System;
using System.Net;


namespace Asset.Exceptions.UserAdmin
{
    public class BusinessException : Exception 
    {
        public string message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public BusinessException() : base()
        {
        }
        public BusinessException(string Message) : base(Message)
        {
            this.message = Message;
        }

        public BusinessException(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
            this.message = message;
        }
    }
}
