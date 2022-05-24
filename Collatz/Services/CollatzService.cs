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

        public CollatzService(CollatzTree collatz)
        {
            _collatz = collatz;
        }






    }
}
