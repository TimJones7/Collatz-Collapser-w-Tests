using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Collatz
{
    public class CollatzTree
    {
        //  This {tail}  might not even be necessary?
        public Number? bottom { get; set; }    //  which will be == 1 

        //  Keep track of numbers seen and what Number object it belongs to
        public SortedList<int, Number>? Numbers_Seen { get; set; }


        //  Do not init in Constructor... only create object when needed
        public DigitDistribution _distribution;

        //  Constructor auto-sets the bottom node
        //  and adds it to "seen" list
        public CollatzTree()
        {
            Numbers_Seen = new SortedList<int, Number>();
            bottom = new Number(1);
            bottom.stepsToOne = 0;
            Numbers_Seen.Add(1, bottom);

        }


        //  Method to check if path from x -> 1 exists, if not fill in
        private void checkNums(int x)
        {
            if (!Numbers_Seen.ContainsKey(x))
            {
                ChainCompleter_Process(x);
            }
        }

        //  Print numbers from {}
        //  If doesn't exist, fill in
        public void PrintFromNumber(int x)
        {
            //  Check if number has been seen.
            //  If not start process of adding numbers until we find one we've seen
            checkNums(x);
            fillSteps(x);
            //  The following code should only execute
            //  if the chain has been completed and exists
            //  from x -> 1 
            Number startingNum = Numbers_Seen[x];
            Number currentNum = startingNum;

            while (currentNum.Next_Number != null)
            {
                //Console.WriteLine($"Current number is: {currentNum.value}, with Leading # {currentNum.Leading_Digit}");
                Console.WriteLine($"Current number is: {currentNum.value}, Steps remaining = {currentNum.stepsToOne}");
                currentNum = currentNum.Next_Number;
            }

        }


        public void ChainCompleter_Process(int x)
        {
            Number newNumber = CreateNumber(x);
        }

        private Number CreateNumber(int x)
        {
            //  Entry needs created and then look to see if next number exists,
            //  if so, then set new number's next_number to the Number object
            //  that it is and set the next numbers from above/below value
            //  as the number we just created
            //  If the next number doesn't exist, we want to recurse until
            //  we arrive at a number that does exist
            Number newNum = new Number(x);

            //  Add number to Numbers_Seen list
            Numbers_Seen.Add(x, newNum);

            int next_Num = findNextNum(x);

            //  If we've not seen the next number, recursively create it
            if (!Numbers_Seen.ContainsKey(next_Num))
            {
                newNum.Next_Number = CreateNumber(next_Num);
            }
            //  If we have seen the next number, get that objext and set it equal to the proper one
            else if (Numbers_Seen.ContainsKey(next_Num))
            {
                newNum.Next_Number = Numbers_Seen[next_Num];
                //  This part only matters if we want to traverse away from 1
                if (x > next_Num)
                {
                    //  Every number as a num_From_Above
                    Numbers_Seen[next_Num].num_From_Above = newNum;
                }
                if (x < next_Num)
                {
                    //  Not every number as a num_From_Below
                    Numbers_Seen[next_Num].num_From_Below = newNum;
                }
            }
            return newNum;
        }

        private int findNextNum(int x)
        {
            if (x % 2 == 0)
            {
                return x / 2;
            }
            return (3 * x + 1);
        }

        //  Refactored, shouldn't double-count now.
        public void fillSteps(int x)
        {
            //  Check if number has been seen.
            //  If not, complete chain
            checkNums(x);

            //  Now we want to traverse the chain from x -> 1
            //  adding each Number to a list
            List<Number> path = new List<Number>();
            listBuilder(x, path);

            //  Loop backwards thru list
            //  Since '1' is set, we don't have to start at "bottom"
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
            //  recursively fill a list with objects looking to the next one 

            path.Add(Numbers_Seen[x]);
            //  After adding the object we want to see what the next number is
            //  if next number exists, we want to pass it in and call function again
            //  if not, we are done filling list.
            if (Numbers_Seen[x].Next_Number != null)
            {
                //  Get value is next number and the path object 
                listBuilder(Numbers_Seen[x].Next_Number.value, path);
            }
        }





        //  Find Least Common Ancestor
        public Number findCommonAncestor(int a, int b)
        {
            //  Make sure chains are complete
            checkNums(a);
            checkNums(b);
            fillSteps(a);
            fillSteps(b);

            //  Vars we need and init
            Number left = Numbers_Seen[a];
            Number right = Numbers_Seen[b];

            //  When looking at two paths, the LCA will have a 'steps to one' value less than the smallest number's steps-to-one value
            //  We need to start looking when the steps to one values are the same. 
            while(left.stepsToOne != right.stepsToOne)
            {
                // Get the bigger object and walk toward 1
                if(left.stepsToOne > right.stepsToOne)
                {
                    left = left.Next_Number;
                }
                if(right.stepsToOne > left.stepsToOne)
                {
                    right = right.Next_Number;
                }
            }

            //  At this point, both numbers should be the same steps from one
            //  While left and right are not the same number, step them both toward 1
            while(left.value != right.value)
            {
                left = left.Next_Number;
                right = right.Next_Number;
            }
            return left;
           
        }


        //  Creating the object we need only when we need it
        //  This will also prevent double-counting digits when traversing multiple paths
        public void printdistributionFrom(int x)
        {
            _distribution = new DigitDistribution();
            _distribution.getTallyFromNum(this, x);
            _distribution.printDistribution();
        }



    }
}
