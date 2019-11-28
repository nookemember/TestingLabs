using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib
{
    public class Triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            return (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && c + b > a);
        }
    }
}
