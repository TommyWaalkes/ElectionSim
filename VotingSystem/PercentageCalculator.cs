using System;
using System.Collections.Generic;
using System.Text;

namespace VotingSystem
{
    class PercentageCalculator
    {
        public static double TotalList(double[] nums)
        {
            double total = 0;
            foreach (double num in nums)
            {
                total += num;
            }
            return total;
        }

        public static List<double> NormalizePercentages(params double[] nums)
        {
            double total = TotalList(nums);
           
            List<double> output = new List<double>();
            foreach (double d in nums)
            {
                double op = (d / total) * 100;
                output.Add(op);
            }

            return output;
        }
    }
}