using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SolutionOfQuadraticEquationTests
{
    [TestClass]
    public class QuadraticEquationTest
    {
        [TestMethod]
        public void stringEquation_oneStringWithThreeKoefficients()
        {
            string equation = "- 7 x^2 + -9x + 17 =0";
            string exist = "-7#-9#17";
            string result;

            QuadraticEquation act = new QuadraticEquation();
            result = QuadraticEquation.parsing(equals);

            Assert.AreEqual(result, exist);

        }

        [TestMethod]
        public void stringEquation_oneStringWithThreeKoefficients2()
        {
            string equation = "- 7 x^2 ++ -9x + 17 =0";
            string exist = "error;
            string result;

            QuadraticEquation act = new QuadraticEquation();
            result = QuadraticEquation.parsing(equals);

            Assert.AreEqual(result, exist);
        }

        [TestMethod]
        public void oneStringWithThreeKoefs_ThreeIntKoefs()
        {
            string roots = "-17#5#9";
            int[] exist = new int[13];
            int[] result = new int[13];
            exist[1] = 17;
            exist[2] = 5;
            exist[3] = 9;

            QuadraticEquation act = new QuadraticEquation();
            result = QuadraticEquation.parsToInt(roots);

            Assert.AreEqual(result, exist);
        }

        [TestMethod]
        public void treeIntKoefs_Diskrim()
        {
            int[] koefs = new int[13];
            koefs[1] = 5;
            koefs[2] = 7;
            koefs[3] = -9;
            int exist = 277;
            int disk;

            QuadraticEquation act = new QuadraticEquation();
            disk = QuadraticEquation.discrimfind(koefs);

            Assert.AreEqual(disk, exist);
        }

        [TestMethod]
        public void diskrim_diskrimShouldbepositive()
        {
            int[] koefs;
            koefs[1] = 5;
            koefs[2] = 1;
            koefs[3] = 3;
            bool exist = false;
            bool ans;

            QuadraticEquation act = new QuadraticEquation();
            ans = QuadraticEquation.discrimfind(koefs);

            Assert.AreEqual(ans, exist);
        }

        [TestMethod]
        public void discrimAndThreeKoefs_FirstRootShouldBeRight()
        {
            int[] koefs;
            koefs[1] = 5;
            koefs[2] = 10;
            koefs[3] = -7;
            int diskrim = 240;
            double exist = -8.4508;
            double ans;

            QuadraticEquation act = new QuadraticEquation();
            ans = QuadraticEquation.findFirstRoot(koefs, diskrim);

            Assert.AreEqual(ans, exist, 0.0001);
        }

        [TestMethod]
        public void discrimAndThreeKoefs_SecondRootShouldBeRight()
        {
            int[] koefs;
            koefs[1] = 5;
            koefs[2] = 10;
            koefs[3] = -7;
            int diskrim = 240;
            double exist = -11.5492;
            double ans;

            QuadraticEquation act = new QuadraticEquation();
            ans = QuadraticEquation.findSecondRoot(koefs, diskrim);

            Assert.AreEqual(ans, exist, 0.0001);
        }
    }
}
