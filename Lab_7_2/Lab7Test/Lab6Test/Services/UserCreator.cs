using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7Test.Models;

namespace Lab7Test.Services
{
    class UserCreator
    {
        public static User WrongEmail()
        {
            return new User(TestDataReader.GetData("FirstName"), TestDataReader.GetData("LastName"), TestDataReader.GetData("WrongEmail"), TestDataReader.GetData("PhoneNumber"));
        }
        public static User WrongNumber()
        {
            return new User(TestDataReader.GetData("FirstName"), TestDataReader.GetData("LastName"), TestDataReader.GetData("FakeEmail"), TestDataReader.GetData("WrongNumber"));
        }
        public static User CorrectParameters()
        {
            return new User(TestDataReader.GetData("FirstName"), TestDataReader.GetData("LastName"), TestDataReader.GetData("Email"), TestDataReader.GetData("PhoneNumber"));
        }
    }
}
