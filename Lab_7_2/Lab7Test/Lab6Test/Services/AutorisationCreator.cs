using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7Test.Models;

namespace Lab7Test.Services
{
    class AutorisationCreator
    {
        public static Autorisation WrongEmail()
        {
            return new Autorisation(TestDataReader.GetData("FakeEmail"), TestDataReader.GetData("Password"));
        }
        public static Autorisation RightParameters()
        {
            return new Autorisation(TestDataReader.GetData("Email"), TestDataReader.GetData("Password"));
        }
    }
}