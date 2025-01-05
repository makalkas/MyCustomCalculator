using System;

namespace MyCustomCalculator.Exceptions
{
    public class OperationIsNullException : Exception
    {
        public OperationIsNullException() : base("The Operation property in the CalculationStateFactory has not been updated.") { }

        public OperationIsNullException(string message) : base(message) { }

        public OperationIsNullException(Exception innerException) : base("The Operation property in the CalculationStateFactory has not been updated." +
            "Please see the Inner Exception for details.", innerException)
        { }

        public OperationIsNullException(string message, Exception innerException) : base(message, innerException) { }
    }
}
