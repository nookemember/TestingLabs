using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7Test.Models
{
    class Payment
    {
       
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        public Payment(string cardNumber, string fullName, string month, string year)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            Month = month;
            Year = year;
        }
    }
}
