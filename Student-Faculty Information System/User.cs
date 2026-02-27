using System;
using System.Collections.Generic;
using System.Text;

namespace Mangment_System
{
    internal class User
    {
        public int UserID {  get; set; }
        public string Password { get; set; }
        public User(int id,string password) { 
            UserID = id;
            Password = password;
        }
    }
}
