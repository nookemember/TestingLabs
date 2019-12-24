using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7Test.Models;

namespace Lab7Test.Services
{
    class PaymentCreator
    {
        public static Payment AllCorrect()
        {
            return new Payment(TestDataReader.GetData("CardNumber"), TestDataReader.GetData("FullName"),TestDataReader.GetData("Month"), TestDataReader.GetData("Year"));
        }
        
    }
}