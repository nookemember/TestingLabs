using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7Test.Models
{
    class Autorisation
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public Autorisation(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
