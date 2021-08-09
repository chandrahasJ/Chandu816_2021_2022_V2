using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleTraderApp.Domain.Exceptions
{
    public class UserNameNotFoundException : Exception
    {
        public string UserName { get; set; }
        public UserNameNotFoundException(string userName)
        {
            UserName = userName;
        }

        public UserNameNotFoundException(string message, string userName) : base(message)
        {
            UserName = userName;
        }

        public UserNameNotFoundException(string message, Exception innerException, string userName) : base(message, innerException)
        {
            UserName = userName;
        }
    }
}
