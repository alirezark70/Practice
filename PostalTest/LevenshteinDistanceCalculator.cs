using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalTest
{
    public class LevenshteinDistanceCalculator
    {
        public static int Compute(string s1, string s2)
        {
            var matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                matrix[i, 0] = i;
            }

            for (int j = 0; j <= s2.Length; j++)
            {
                matrix[0, j] = j;
            }

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    var cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    matrix[i, j] = new[]
                    {
                    matrix[i - 1, j] + 1,      // حذف  
                    matrix[i, j - 1] + 1,      // درج  
                    matrix[i - 1, j - 1] + cost // جایگزینی  
                }.Min();
                }
            }

            return matrix[s1.Length, s2.Length];
        }

       
    }
}
