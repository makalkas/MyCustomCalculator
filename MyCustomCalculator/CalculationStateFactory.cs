// -------------------------------------------------------------------------------
// Copyright (c) 2024 Michael Kalkas
// Used for mentoring others.
// -------------------------------------------------------------------------------

using MyCustomCalculator.Exceptions;

namespace MyCustomCalculator
{
    public class CalculationStateFactory
    {
        private double _firstNumber = 0;
        private double _secondNumber = 0;
        private string _operation = string.Empty;
        protected OperationFactory _operationFactory;

        public double Result { get; private set; }

        public string CurrentOperation { get; private set; } = string.Empty;
        public string FullCalculation { get; private set; }

        public double FirstNumber
        {
            get
            {
                return _firstNumber;
            }
            private set
            {
                _firstNumber = value;
            }
        }

        public double SecondNumber
        {
            get
            {
                return _secondNumber;
            }
            private set
            {
                _secondNumber = value;
            }
        }
        public CalculationStateFactory()
        {
            _operationFactory = new OperationFactory();
        }

        public void InsertFirstNumber(double firstNumber)
        {
            _firstNumber = firstNumber;
            UpdateFullCalculation();
        }

        public void InsertSecondNumber(double secondNumber)
        {
            if (!string.IsNullOrEmpty(_operation))
            {
                _secondNumber = secondNumber;
                RunCalculation();
            }
            else
            {
                throw new OperationIsNullException();
            }
        }

        public void InsertOperation(string operation)
        {
            _operation = operation;
            this.CurrentOperation = operation;
            UpdateFullCalculation();
        }

        public void ResetState()
        {
            _firstNumber = 0;
            _secondNumber = 0;
            _operation = string.Empty;
            this.FullCalculation = string.Empty;
        }

        private void RunCalculation()
        {
            if (_operation == "+")
            {
                this.Result = _operationFactory.Add(_firstNumber, _secondNumber);
            }
            if (_operation == "-")
            {
                this.Result = _operationFactory.Subtract(_firstNumber, _secondNumber);
            }
            if (_operation == "X")
            {
                this.Result = _operationFactory.Multiply(_firstNumber, _secondNumber);
            }
            if (_operation == "÷")
            {
                if (_firstNumber == 0 || _secondNumber == 0)
                {
                    if (_firstNumber == 0 && _secondNumber > 0)
                    {
                        this.Result = 0;
                    }
                    else if (_secondNumber == 0)
                    {
                        throw new DivideByZeroException();
                    }
                }
                else
                {
                    this.Result = _operationFactory.Divide(_firstNumber, _secondNumber);
                }
            }


            UpdateFullCalculation(true);
        }

        /// <summary>
        /// This method updates the calculation state.
        /// </summary>
        /// <param name="calculationFinished"></param>
        private void UpdateFullCalculation(bool calculationFinished = false)
        {
            if (!string.IsNullOrEmpty(_operation) && calculationFinished == true)
            {
                this.FullCalculation = _firstNumber + " " + _operation + " " + _secondNumber;
            }
            else if (string.IsNullOrEmpty(_operation))
            {
                this.FullCalculation = _firstNumber.ToString();
            }
            else if (!string.IsNullOrEmpty(_operation) && calculationFinished == false)
            {
                this.FullCalculation = _firstNumber.ToString() + " " + _operation;
            }
        }
    }
}
