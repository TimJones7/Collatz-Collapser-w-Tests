using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Collatz
{
    public class CollatzTree
    {
        public Number? bottom { get; set; }    
        public SortedList<int, Number>? Numbers_Seen { get; set; }
        public DigitDistribution? _distribution;

        public CollatzTree()
        {
            Numbers_Seen = new SortedList<int, Number>();
            bottom = new Number(1);
            bottom.stepsToOne = 0;
            Numbers_Seen.Add(1, bottom);
        }

        private void if_Path_DoesntExist_Fill_In(int x)
        {
            if (!Numbers_Seen.ContainsKey(x))
            {
                Create_Global_Number_objs_To_Complete_Chain(x);
            }
        }

        public void PrintFromNumber(int x)
        {
            fillSteps(x);
            Number startingNum = Numbers_Seen[x];
            Number currentNum = startingNum;

            while (currentNum.Next_Number != null)
            {
                //Console.WriteLine($"Current number is: {currentNum.value}, with Leading # {currentNum.Leading_Digit}");
                Console.WriteLine($"Current number is: {currentNum.value}, Steps remaining = {currentNum.stepsToOne}");
                currentNum = currentNum.Next_Number;
            }

        }

        public void Create_Global_Number_objs_To_Complete_Chain(int x)
        {
            Number newNumber = CreateNumber(x);
        }

        private Number CreateNumber(int x)
        {
            Number newNum = new Number(x);
            Record_Number_As_Seen_Globally(x, newNum);
            newNum.Next_Number = Find_and_Set_Next_Number(x);
            return newNum;
        }

        private void Record_Number_As_Seen_Globally(int x, Number newNum)
        {
            Numbers_Seen.Add(x, newNum);
        }

        private Number Find_and_Set_Next_Number(int x)
        {
            int next_Num = findNextNum(x);
            Number next_Number = Set_Next_Number(next_Num);
            return next_Number;
        }
        

        private Number Set_Next_Number(int next_Num)
        {
            if (!Numbers_Seen.ContainsKey(next_Num))
            {
                return CreateNumber(next_Num);
            }
            return Numbers_Seen[next_Num];
        }

        
        private int findNextNum(int x)
        {
            if (x % 2 == 0)
            {
                return x / 2;
            }
            return (3 * x + 1);
        }

        
        public void fillSteps(int x)
        {
            if_Path_DoesntExist_Fill_In(x);

            List<Number> path = new List<Number>();
            listBuilder(x, path);

            Count_And_Fill_Steps_Remaining_For_Numbers(path);
        }

        private void Count_And_Fill_Steps_Remaining_For_Numbers(List<Number> path)
        {
            for (int i = path.Count - 2; i >= 0; i--)
            {
                if (path[i].stepsToOne == 0)
                {
                    path[i].stepsToOne = path[i + 1].stepsToOne + 1;
                }
            }
        }



        private void listBuilder(int x, List<Number> path)
        {
            path.Add(Numbers_Seen[x]);
            
            if (Numbers_Seen[x].Next_Number != null)
            {
                listBuilder(Numbers_Seen[x].Next_Number.value, path);
            }
        }

      
        public Number Find_Least_Common_Ancestor(int a, int b)
        {
            Ensure_Chains_Exist(a, b);
            (Number left, Number right) = Initialize_Variables(a, b);
            Number commonAncestor = Walk_To_Common_Ancestor(left, right);
            return commonAncestor;
        }

        private (Number, Number) Initialize_Variables(int a, int b) 
        {
            Number left = Get_Already_Seen_Number(a);
            Number right = Get_Already_Seen_Number(b);
            (left, right) = Set_Starting_Numbers(left, right);
            return (left, right);
        }
        
        private Number Get_Already_Seen_Number(int a)
        {
            return Numbers_Seen[a];
        }



        
        public void Print_Distribution_From_Number(int x)
        {
            _distribution = new DigitDistribution();
            _distribution.Get_Number_Distribution_of_Tree_From_Number(this, x);
            _distribution.printDistribution();
        }

        private void Ensure_Chains_Exist(int a, int b)
        {
            fillSteps(a);
            fillSteps(b);
        }

        private (Number,Number) Set_Starting_Numbers(Number left, Number right)
        {
            while (left.stepsToOne != right.stepsToOne)
            {
                // Get the bigger object and walk toward 1
                if (left.stepsToOne > right.stepsToOne)
                {
                    left = left.Next_Number;
                }
                if (right.stepsToOne > left.stepsToOne)
                {
                    right = right.Next_Number;
                }
            }
            return (left, right);
        }

        private Number Walk_To_Common_Ancestor(Number left, Number right)
        {
            while (left.value != right.value)
            {
                left = left.Next_Number;
                right = right.Next_Number;
            }
            return left;
        }
    }
}
