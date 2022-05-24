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


        //public CollatzService(CollatzTree collatz)
        //{
        //    _collatz = collatz;
        //}

        // Newing up the object here, because I guess Dependency Injection in a console app is different from MVC?
        public CollatzService()
        {
            _collatz = new CollatzTree();
        }

        public Number Find_Least_Common_Ancestor(int a, int b)
        {
            return _collatz.findCommonAncestor(a, b);
        }

        public void Print_Distribution_From(int x)
        {
            _collatz.printdistributionFrom(x);
        }

        public void Print_From_Number(int x)
        {
            _collatz.PrintFromNumber(x);
        }
    }
}
