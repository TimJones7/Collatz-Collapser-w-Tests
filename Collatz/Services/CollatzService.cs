using Collatz.Interfaces;
using Collatz.Collatz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Services
{
    public class CollatzService : ICollatzService
    {
        private readonly CollatzTree _collatz;

        public CollatzService()
        {
            _collatz = new CollatzTree();
        }

        public Number Find_Least_Common_Ancestor(int a, int b)
        {
            return _collatz.Find_Least_Common_Ancestor(a, b);
        }

        public void Print_Leading_Digit_Distribution_From(int x)
        {
            _collatz.Print_Distribution_From_Number(x);
        }

        public void Print_Collatz_Chain_From_Number(int x)
        {
            _collatz.PrintFromNumber(x);
        }
    }
}
