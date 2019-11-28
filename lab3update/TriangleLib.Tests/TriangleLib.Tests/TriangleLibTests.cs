using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleLib;

namespace TriangleLib.Tests
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        public void Isosceles_Triangle_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 8));
        }

        [TestMethod]
        public void Equilateral_Triangle_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 5, 5));
        }

        [TestMethod]
        public void Right_Triangle_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(3, 4, 5));
        }

        [TestMethod]
        public void Similar_Triangles_TrueReturned()
        {
            int side_a = 10, side_b = 12, side_c = 20, step = 5;
            const int TRIANGLES_NUMBER = 100;
            for (int i = 0; i < TRIANGLES_NUMBER; i++)
            {
                Assert.IsTrue(Triangle.IsTriangle(side_a, side_b, side_c));
                side_a += step; side_b += step; side_c += step;
            }
        }

        [TestMethod]
        public void Triangle_WithNullSides_FalseReturned()
        {
            Assert.IsFalse(Triangle.IsTriangle(0, 0, 0));
        }

        [TestMethod]
        public void Triangle_WithNegativeSides_FalseReturned()
        {
            Assert.IsFalse(Triangle.IsTriangle(-5, -5, 8));
        }

        [TestMethod]
        public void Miscellaneous_Triangle_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(7, 8, 14));
        }

        [TestMethod]
        public void Obtuse_Triangle_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(9, 5, 6));
        }

        [TestMethod]
        public void Acute_Triangle_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(5, 4, 4));
        }

        [TestMethod]
        public void Triangle_DifferentSides_TrueReturned()
        {
            Assert.IsTrue(Triangle.IsTriangle(15.9, 1, 15.99));
        }

    }
}
