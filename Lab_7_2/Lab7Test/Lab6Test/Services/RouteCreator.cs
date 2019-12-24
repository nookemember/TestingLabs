using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab7Test.Models;

namespace Lab7Test.Services
{
    class RouteCreator
    {
        public static Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("DepartureCity"), TestDataReader.GetData("ArrivalCity"));
        }

        public static Route WithAllPropertiesJitomir()
        {
            return new Route(TestDataReader.GetData("ArrivalCity"), TestDataReader.GetData("DepartureCityJitomir"));
        }
    }
}
