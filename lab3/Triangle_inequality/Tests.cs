using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle_inequality
{
    class Triangle_Tests
    {

        public bool TriangleCheck_5and3and6()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(5, 3, 6) == true)
            {
                Console.WriteLine("test 1 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 1 failed");
                complete = false;
            }

            return complete;

        }

        public bool TriangleCheck_10and0and10()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(10, 0, 10) == true)
            {
                Console.WriteLine("test 2 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 2 failed");
                complete = false;
            }

            return complete;

        }

        public bool TriangleCheck_0and10and10()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(0,10, 10) == true)
            {
                Console.WriteLine("test 3 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 3 failed");
                complete = false;
            }

            return complete;

        }

        public bool TriangleCheck_10and10and0()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(10, 10, 0) == true)
            {
                Console.WriteLine("test 4 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 4 failed");
                complete = false;
            }

            return complete;
        }


        public bool TriangleCheck_10and10and2()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(10, 10, 2) == true)
            {
                Console.WriteLine("test 5 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 5 failed");
                complete = false;
            }

            return complete;
        }

        public bool TriangleCheck_0and0and10()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(0, 0, 10) == true)
            {
                Console.WriteLine("test 6 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 6 failed");
                complete = false;
            }

            return complete;
        }

        public bool TriangleCheck_1and2and5()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(1, 2, 5) == true)
            {
                Console.WriteLine("test 7 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 7 failed");
                complete = false;
            }

            return complete;
        }


        public bool TriangleCheck_10andMinus3and8()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(10, -3, 8) == true)
            {
                Console.WriteLine("test 8 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 8 failed");
                complete = false;
            }

            return complete;
        }

        public bool TriangleCheck_5an5andMinus5()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(10, -3, 8) == true)
            {
                Console.WriteLine("test 9 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 9 failed");
                complete = false;
            }

            return complete;
        }

        public bool TriangleCheck_10dot5and10dot44and8dot2()
        {
            bool complete;
            triangle abc = new triangle();
            if (abc.triangleIsTrue(10.44, 10.5,8.2) == true)
            {
                Console.WriteLine("test 10 comlete");
                complete = true;
            }
            else
            {
                Console.WriteLine("test 10 failed");
                complete = false;
            }

            return complete;
        }





    }
}
