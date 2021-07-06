using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTraderApp.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string  Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
