// -------------------------------------------------------------------------------
// Copyright (c) 2024 Michael Kalkas
// Used for mentoring others.
// -------------------------------------------------------------------------------
using System;

namespace MyCustomCalculator
{
    public class OperationFactory
    {

        public double Add(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public double Divide(double firstNumber, double secondNumber)
        {
            return firstNumber / secondNumber;
        }

        public double Square(double firstNumber)
        {
            return firstNumber * firstNumber;
        }

        public double Reciprical(double firstNumber)
        {
            return 1 / firstNumber;
        }

        public double SquareRoot(double number)
        {
            return Math.Sqrt(number);
        }

        public double Percent(double firstNumber, string operation, double secondNumber)
        {
            if (firstNumber == 0 || string.IsNullOrEmpty(operation) || secondNumber > 100) { return 0; }
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = firstNumber + (firstNumber * (secondNumber / 100));
                    break;
                case "-":
                    result = firstNumber - (firstNumber * (secondNumber / 100));
                    break;
                case "X":
                    result = firstNumber * (secondNumber / 100);
                    break;
                case "÷":
                    result = firstNumber / (secondNumber / 100);
                    break;
                default:
                    result = 0;
                    break;
            }

            return result;
        }
    }
}
