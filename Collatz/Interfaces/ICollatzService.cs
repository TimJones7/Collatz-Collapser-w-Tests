using Collatz.Collatz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collatz.Interfaces
{
    public interface ICollatzService
    {
        void Print_Collatz_Chain_From_Number(int x);
        Number Find_Least_Common_Ancestor(int a, int b);
        void Print_Leading_Digit_Distribution_From(int x);
    }
}
