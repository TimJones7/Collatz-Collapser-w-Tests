using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Collatz
{
    public class DigitDistribution
    {

        public int num_Ones { get; set; }
        public int num_Twos { get; set; }
        public int num_Threes { get; set; }
        public int num_Fours { get; set; }
        public int num_Fives { get; set; }
        public int num_Sixes { get; set; }
        public int num_Sevens { get; set; }
        public int num_Eights { get; set; }
        public int num_Nines { get; set; }



        public void printDistribution()
        {
            Console.WriteLine($"Numbers of 1's: {this.num_Ones}");
            Console.WriteLine($"Numbers of 2's: {this.num_Twos}");
            Console.WriteLine($"Numbers of 3's: {this.num_Threes}");
            Console.WriteLine($"Numbers of 4's: {this.num_Fours}");
            Console.WriteLine($"Numbers of 5's: {this.num_Fives}");
            Console.WriteLine($"Numbers of 6's: {this.num_Sixes}");
            Console.WriteLine($"Numbers of 7's: {this.num_Sevens}");
            Console.WriteLine($"Numbers of 8's: {this.num_Eights}");
            Console.WriteLine($"Numbers of 9's: {this.num_Nines}");
        }

        public void tallyDigits(Number num)
        {
            Number current = num;

            switch (num.Leading_Digit)
            {
                case 1:
                    num_Ones++;
                    break;
                case 2:
                    num_Twos++;
                    break;
                case 3:
                    num_Threes++;
                    break;
                case 4:
                    num_Fours++;
                    break;
                case 5:
                    num_Fives++;
                    break;
                case 6:
                    num_Sixes++;
                    break;
                case 7:
                    num_Sevens++;
                    break;
                case 8:
                    num_Eights++;
                    break;
                case 9:
                    num_Nines++;
                    break;
            }

            if (current.Next_Number != null)
            {
                tallyDigits(current.Next_Number);
            }
        }

        public void Get_Number_Distribution_of_Tree_From_Number(CollatzTree tree, int x)
        {
            bool have_we_seen_number = tree.Numbers_Seen.ContainsKey(x);
            if (!have_we_seen_number)
            {
                tree.Create_Global_Number_objs_To_Complete_Chain(x);
            }
            tallyDigits(tree.Numbers_Seen[x]);
        }

    }
}
