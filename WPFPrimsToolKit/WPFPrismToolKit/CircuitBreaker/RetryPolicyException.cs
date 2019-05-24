using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircuitBraker
{
    public class RetryPolicyException : Exception
    {
        public RetryPolicyException()
            : this( "" )
        {

        }

        public RetryPolicyException( string message )
            : base( message )
        {

        }
    }

    public class CircuitBreaker
    {
        
    }
}
