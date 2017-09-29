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
    }
}
