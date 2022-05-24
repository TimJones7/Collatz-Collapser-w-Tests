using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.CollatzTree
{
    public class Number
    {
        public int value { get; set; }
        public Number Next_Number { get; set; } //  if value == 1 then == null
        public Number? num_From_Below { get; set; }
        public Number? num_From_Above { get; set; }
        public int stepsToOne { get; set; }
        public int Leading_Digit { get; set; }
        public bool isPerfectSquare { get; set; }



        public Number(int x)
        {
            value = x;
            Leading_Digit = setLeadingDigit(x);
            isPerfectSquare = isNumberSquare(x);
        }
        private int setLeadingDigit(int x)
        {
            while (x >= 10)
            {
                x /= 10;
            }
            return x;
        }

        private bool isNumberSquare(int x)
        {
            double sRoot = Math.Sqrt(x);
            return ((sRoot * sRoot) == x);
        }

    }
}
