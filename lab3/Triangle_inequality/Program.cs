using System;

namespace Triangle_inequality
{
   public class triangle
    {

        public double maxSide;

        public bool triangleIsTrue(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0)
            {
                maxSide = (a > b && a > c) ? a
                    : (b > a && b > c) ? b
                    : c;

                if (maxSide == a && a <= b + c || maxSide == b && b <= a + c || maxSide == c && c <= a + b)
                {
                    Console.WriteLine("Такой треугольник существует");
                }
            }
            else
            {
                Console.WriteLine("Такого треугольника не существует");
                return false;
            }
            return true;
        }
    }

    class Program
    {
       static void Main(string[] args)
        {
            Triangle_Tests test = new Triangle_Tests();
            test.TriangleCheck_5and3and6();
            test.TriangleCheck_10and0and10();
            test.TriangleCheck_0and10and10();
            test.TriangleCheck_10and10and0();
            test.TriangleCheck_10and10and2();
            test.TriangleCheck_0and0and10();
            test.TriangleCheck_1and2and5();
            test.TriangleCheck_10andMinus3and8();
            test.TriangleCheck_5an5andMinus5();
            test.TriangleCheck_10dot5and10dot44and8dot2();



        }
    }

}




