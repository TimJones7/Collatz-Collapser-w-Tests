using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.CollatzTree
{
    public class CollatzTree
    {
        //  This {tail}  might not even be necessary?
        public Number? bottom { get; set; }    //  which will be == 1 

        //  Keep track of numbers seen and what Number object it belongs to
        public SortedList<int, Number>? Numbers_Seen { get; set; }

        public DigitDistribution _distribution;

        //  Constructor auto-sets the bottom node
        //  and adds it to "seen" list
        public CollatzTree()
        {
            Numbers_Seen = new SortedList<int, Number>();
            bottom = new Number(1);
            bottom.stepsToOne = 0;
            Numbers_Seen.Add(1, bottom);
            _distribution = new DigitDistribution();

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

        //  Create methods to fill in "steps to One" variable
        //  Have function take int argument
        //  Check for completed chain, if complete fill array with path
        //  Then traverse path from 1 -> x ++Steps each time 
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
                path[i].stepsToOne = path[i + 1].stepsToOne + 1;
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
            //  We need to keep track of all the numbers we have seen, 
            //  This way we can walk from each path to one and iterate
            //  each Number by one step each time and not worry about
            //  walking too far.
            SortedList<int, Number> nums_seen = new SortedList<int, Number>();

            //  Add initial values
            nums_seen.Add(a, left);
            nums_seen.Add(b, right);

            //  While each numbers next number value does not exist as a key in the 
            //  list then we need to go to the next number
            //  As soon as we reach a value whose next_number == a key that exists, we're done
            //  This only runs as long as both keys have not been seen
            while (!Numbers_Seen.ContainsKey(left.Next_Number.value) || !Numbers_Seen.ContainsKey(right.Next_Number.value))
            {
                //  set left and right to next number
                left = left.Next_Number;
                right = right.Next_Number;
                //  Add next numbers to 'seen' list
                nums_seen.Add(left.value, left);
                nums_seen.Add(right.value, right);
            }

            //  This part should only run if we arrive at a number we've seen
            //  At this point, left/right should have stopped walking whenever
            //  it reached the nearest common ancestor I think
            //  Now we need to get which one it is. 
            if (Numbers_Seen.ContainsKey(left.Next_Number.value))
            {
                return left.Next_Number;
            }
            if (Numbers_Seen.ContainsKey(right.Next_Number.value))
            {
                return right.Next_Number;
            }
            //  Making the function work, return bottom {1} if all else fails
            return bottom;
        }





    }
}
