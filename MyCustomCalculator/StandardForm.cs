using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyCustomCalculator
{
    public partial class StandardForm : Form
    {
        private List<string> calculationsHistory = new List<string>();
        private double currentNumber = 0;
        private bool addDecimalOnNextNumber = false;
        private CalculationStateFactory _calculationStateFactory;
        private OperationFactory _operationFactory;
        private readonly StateKeeper _keeper;

        public StandardForm(CalculationStateFactory calculationStateFactory, OperationFactory operationFactory, StateKeeper keeper)
        {
            InitializeComponent();
            _calculationStateFactory = calculationStateFactory;
            _operationFactory = operationFactory;
            this._keeper = keeper;
        }

        public void NumberSelectedClick(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button button = (Button)sender;

                if (_keeper.CalculationState == StateKeeper.State.PerformCalculation)
                {
                    _keeper.CalculationState = StateKeeper.State.FirstOperation;
                    _calculationStateFactory.InsertFirstNumber(double.Parse(NumberDisplay.Text));
                    NumberDisplay.Text = button.Text;
                    CurrentCalculation.Text = currentNumber + " " + _calculationStateFactory.CurrentOperation;
                    currentNumber = 0;
                }

                if (currentNumber == 0)
                {
                    currentNumber = double.Parse(button.Text);
                }
                else
                {
                    string number = currentNumber.ToString();
                    if (addDecimalOnNextNumber)
                    {
                        addDecimalOnNextNumber = false;
                        number = number + ".";
                    }

                    number = number + button.Text;
                    currentNumber = double.Parse(number);
                }



                if (_keeper.CalculationState == StateKeeper.State.FirstOperation)
                    _keeper.CalculationState = StateKeeper.State.SecondInput;

                UpdateNumberDisplay(currentNumber.ToString());
            }
        }

        public void OperationClick(object sender, EventArgs e)
        {
            string operation = "0";
            char[] charsToCheck = { '+', '-', 'X', '÷' };

            ProcessTextInput();

            if (CurrentCalculation.Text.Contains("="))
            {
                CurrentCalculation.Text = NumberDisplay.Text;
            }

            if (sender.GetType() == typeof(Button))
            {
                Button button = (Button)sender;
                operation = button.Text;
            }

            if (_keeper.CalculationState == StateKeeper.State.PerformCalculation)
            {
                _calculationStateFactory.ResetState();
                _calculationStateFactory.InsertFirstNumber(double.Parse(NumberDisplay.Text));
                CurrentCalculation.Text = NumberDisplay.Text + " " + operation;
                _calculationStateFactory.InsertOperation(operation);


            }

            string currentCalc = string.Empty;

            if (_keeper.CalculationState == StateKeeper.State.FirstInput)
            {
                if (string.IsNullOrEmpty(CurrentCalculation.Text))
                {
                    CurrentCalculation.Text = currentNumber.ToString();
                }

                currentCalc = CurrentCalculation.Text;

                _calculationStateFactory.InsertFirstNumber(currentNumber);
                _calculationStateFactory.InsertOperation(operation);
                currentCalc = currentCalc + " " + operation;
                ResetForNextNumber(currentCalc);

                _keeper.CalculationState = StateKeeper.State.FirstOperation;
            }



            if (_keeper.CalculationState == StateKeeper.State.SecondInput)
            {
                _calculationStateFactory.InsertOperation(operation);
                _calculationStateFactory.InsertSecondNumber(currentNumber);
                CurrentCalculation.Text = CurrentCalculation.Text + " " + NumberDisplay.Text;
                NumberDisplay.Text = _calculationStateFactory.Result.ToString();
                currentNumber = _calculationStateFactory.Result;
                if (!charsToCheck.Any(x => currentCalc.EndsWith(x.ToString())))
                {
                    currentCalc = currentCalc + " " + operation;
                }
                else
                {
                    currentCalc = currentNumber.ToString();
                    ResetForNextNumber(currentCalc);
                    _calculationStateFactory.ResetState();
                    _calculationStateFactory.InsertFirstNumber(currentNumber);
                    _calculationStateFactory.InsertOperation(operation);
                }

                _keeper.CalculationState = StateKeeper.State.PerformCalculation;
                calculationsHistory.Add(currentCalc);
            }

        }

        public void ChangeSignClick(object sender, EventArgs e)
        {
            currentNumber = currentNumber * -1;
            UpdateNumberDisplay(currentNumber.ToString());
        }

        public void AddDecimal(object sender, EventArgs e)
        {
            if (!currentNumber.ToString().Contains("."))
            {
                addDecimalOnNextNumber = true;
                UpdateNumberDisplay(currentNumber.ToString() + ".");
            }
        }

        public void UpdateNumberDisplay(string newNumber)
        {
            NumberDisplay.Text = newNumber;
        }

        public void Clear(object sender, EventArgs e)
        {
            addDecimalOnNextNumber = false;
            NumberDisplay.Text = "0";
            currentNumber = 0;
            _calculationStateFactory.ResetState();
            _keeper.CalculationState = StateKeeper.State.FirstInput;
        }

        public void ClearEverything(object sender, EventArgs e)
        {
            addDecimalOnNextNumber = false;
            NumberDisplay.Text = "0";
            currentNumber = 0;
            CurrentCalculation.Text = string.Empty;
            _calculationStateFactory.ResetState();
            _keeper.CalculationState = StateKeeper.State.FirstInput;
        }

        public void BackSpace(object sender, EventArgs e)
        {
            string display = NumberDisplay.Text;
            if (display == "0" || string.IsNullOrEmpty(display))
            {
                display = "0";
            }
            else
            {

                if (display.Length > 1 && display.Substring(display.Length - 2, 1) != ".")
                {
                    display = display.Substring(0, display.Length - 1);
                    UpdateNumberDisplay(display);
                    currentNumber = double.Parse(display);
                }
                else
                {
                    if (display.Length > 1 && display.Substring(display.Length - 2, 1) == ".")
                    {
                        display = display.Substring(0, display.Length - 1);
                        UpdateNumberDisplay(display);
                        addDecimalOnNextNumber = true;
                    }
                    else
                    {
                        display = "0";
                        UpdateNumberDisplay(display);
                    }
                }
            }
        }

        private void ProcessTextInput()
        {
            if (NumberDisplay.Text == ".")
            {
                NumberDisplay.Text = "0";
            }

            if (NumberDisplay.Text.StartsWith(".") && NumberDisplay.Text.Length > 1)
            {
                NumberDisplay.Text = "0" + NumberDisplay.Text;
            }

            if (NumberDisplay.Text.EndsWith(".") && NumberDisplay.Text.Length > 1)
            {
                NumberDisplay.Text = NumberDisplay.Text + "0";
            }
        }

        private void ResetForNextNumber(string calculation)
        {
            currentNumber = 0;
            CurrentCalculation.Text = calculation;
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (_keeper.CalculationState != StateKeeper.State.SecondInput && _keeper.CalculationState != StateKeeper.State.PerformCalculation) return;
            ProcessTextInput();

            string currentCalc = CurrentCalculation.Text + " " + NumberDisplay.Text + " =";
            CurrentCalculation.Text = currentCalc;
            if (!string.IsNullOrEmpty(_calculationStateFactory.CurrentOperation) && _calculationStateFactory.SecondNumber == 0)
            {
                _calculationStateFactory.InsertSecondNumber(currentNumber);
                NumberDisplay.Text = _calculationStateFactory.Result.ToString();
                currentNumber = _calculationStateFactory.Result;
                calculationsHistory.Add(currentCalc);
                _calculationStateFactory.ResetState();
                _calculationStateFactory.InsertFirstNumber(currentNumber);
                _keeper.CalculationState = StateKeeper.State.FirstInput;
            }

            if (_keeper.CalculationState == StateKeeper.State.SecondInput && _calculationStateFactory.SecondNumber != currentNumber)
            {
                _calculationStateFactory.InsertSecondNumber(currentNumber);
                NumberDisplay.Text = _calculationStateFactory.Result.ToString();
                currentNumber = double.Parse(NumberDisplay.Text);
                _calculationStateFactory.ResetState();
                _calculationStateFactory.InsertFirstNumber(currentNumber);
                _keeper.CalculationState = StateKeeper.State.PerformCalculation;
            }
        }

        private void SquaredButton_Click(object sender, EventArgs e)
        {
            ProcessTextInput();
            if (!string.IsNullOrEmpty(NumberDisplay.Text))
            {
                currentNumber = double.Parse(NumberDisplay.Text);

                currentNumber = _operationFactory.Square(currentNumber);
                _calculationStateFactory.InsertFirstNumber(currentNumber);

                UpdateNumberDisplay(currentNumber.ToString());
            }
        }

        private void RecipricalButton_Click(object sender, EventArgs e)
        {
            ProcessTextInput();
            if (!string.IsNullOrEmpty(NumberDisplay.Text))
            {
                currentNumber = double.Parse(NumberDisplay.Text);

                currentNumber = _operationFactory.Reciprical(currentNumber);
                _calculationStateFactory.InsertFirstNumber(currentNumber);

                UpdateNumberDisplay(currentNumber.ToString());
            }
        }

        private void SqrRootButton_Click(object sender, EventArgs e)
        {
            ProcessTextInput();
            if (!string.IsNullOrEmpty(NumberDisplay.Text))
            {
                currentNumber = double.Parse(NumberDisplay.Text);

                currentNumber = _operationFactory.SquareRoot(currentNumber);
                _calculationStateFactory.InsertFirstNumber(currentNumber);

                UpdateNumberDisplay(currentNumber.ToString());
            }
        }

        private void PercentBtn_Click(object sender, EventArgs e)
        {
            ProcessTextInput();

            if (_keeper.CalculationState == StateKeeper.State.SecondInput)
            {
                double secondNumber = double.Parse(NumberDisplay.Text);
                double percentage = 0;

                if (_calculationStateFactory.CurrentOperation == "X" || _calculationStateFactory.CurrentOperation == "÷")
                {
                    percentage = secondNumber / 100;
                    _calculationStateFactory.InsertSecondNumber(percentage);

                }
                //double result = _operationFactory.Percent(_calculationStateFactory.FirstNumber, _calculationStateFactory.CurrentOperation, secondNumber);
            }
        }
    }
}
