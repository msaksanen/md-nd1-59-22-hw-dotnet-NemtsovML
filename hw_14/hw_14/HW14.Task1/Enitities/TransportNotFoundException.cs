using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14.Task1.Enitities
{
    class TransportNotFoundException : Exception
    {
        public TransportNotFoundException() { }
        public TransportNotFoundException(string message) : base(message) { }
    }
}
