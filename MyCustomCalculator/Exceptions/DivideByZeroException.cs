using System;

namespace MyCustomCalculator.Exceptions
{
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException() : base("Can not Divide by ZERO!") { }

        public DivideByZeroException(string message) : base(message) { }

        public DivideByZeroException(Exception innerException) : base("Can not Divide by ZERO!", innerException) { }

        public DivideByZeroException(string message, Exception innerException) : base(message, innerException) { }
    }
}
