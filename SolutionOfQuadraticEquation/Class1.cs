using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionOfQuadraticEquation
{
    public class QuadeaticEquationSolution
    {
        public static string parsing(string question)
        {
            string ans = question;
            string er = "error";
            string koefA, koefB;

            while (ans.IndexOf(' ') != -1)
            {
                ans = ans.Remove(ans.IndexOf(' '), 1);
            }

            if (ans.IndexOf("=0") != -1)
            {
                ans = ans.Remove(ans.IndexOf("=0"), 2);
            } else
            {
                return er;
            }

            for (int i = 1; i <= 2 && ans.IndexOf('+') != -1; i++)
            {
                int indplus = ans.IndexOf('+');
                if (ans[indplus] == ans.Length - 1 || (ans[indplus + 1] != '-' && ans[indplus + 1] > '9' && ans[indplus + 1] < '1'))
                {
                    return er;
                }
                ans = ans.Remove(ans.IndexOf('+'), 1);
            }

            int trypars;
            if(ans.IndexOf("x^2") != -1)
            {
                int indsqr = ans.IndexOf("x^2");
                if (Int32.TryParse( ans.Remove(indsqr, ans.Length - indsqr),out trypars) == false) {
                    return er;
                }
                koefA = ans.Remove(indsqr, ans.Length - indsqr);
                ans = ans.Remove(0, indsqr + 3);
            } else
            {
                return er;
            }

            if (ans.IndexOf("x") != -1)
            {
                int indx = ans.IndexOf("x");
                if (Int32.TryParse(ans.Remove(indx, ans.Length - indx), out trypars) == false)
                {
                    return er;
                }
                koefB = ans.Remove(indx, ans.Length - indx);
                ans = ans.Remove(0, indx + 1);
            }
            else
            {
                return er;
            }

            if(Int32.TryParse(ans, out trypars) == false)
            {
                return er;
            }

            ans = koefA + '#' + koefB + '#' + ans;
            return ans;
        }

        public static int[] parsToInt(string allkoef)
        {
            int[] koefs = new int[13];
            for (int i = 1; i <= 2; i++)
            {
                koefs[i] = Convert.ToInt32(allkoef.Remove(allkoef.IndexOf('#'), allkoef.Length - allkoef.IndexOf('#')));
                allkoef = allkoef.Remove(0, allkoef.IndexOf('#') + 1);
            }
            koefs[3] = Convert.ToInt32(allkoef);
            return koefs;
        }

        public static int discrimfind(int[] koefs)
        {

            int discrim;
            discrim = koefs[2] * koefs[2] - 4 * koefs[1] * koefs[3];
            return discrim;
        }

        public static bool discrimvaluation(int discrim)
        {
            if (discrim < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static double findFirstRoot(int[] koefs, int discrim)
        {
            return (Convert.ToDouble(-koefs[2]) + Math.Sqrt(Convert.ToDouble(discrim))) / Convert.ToDouble(2 * koefs[1]);
        }

        public static double findSecondRoot(int[] koefs, int discrim)
        {
            return (Convert.ToDouble(-koefs[2]) - Math.Sqrt(Convert.ToDouble(discrim))) / Convert.ToDouble(2 * koefs[1]);
        }

        public static string output(double firstRoot, double secondRoot)
        {
            return "first root is :" + Convert.ToString(firstRoot) + "; second root is :" + Convert.ToString(secondRoot);
        }
    }
}
