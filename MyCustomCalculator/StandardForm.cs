using System;
using System.Collections.Generic;
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
        private bool lastOperationWasEquals = false;

        public StandardForm(CalculationStateFactory calculationStateFactory, OperationFactory operationFactory, StateKeeper keeper)
        {
            InitializeComponent();
            _calculationStateFactory = calculationStateFactory;
            _operationFactory = operationFactory;
            this._keeper = keeper;
        }

        public void NumberSelectedClick(object sender, EventArgs e)
        {
            if (CurrentCalculation.Text.Contains("="))
            {
                UpdateCurrentCalculationDisplay(string.Empty);
                UpdateNumberDisplay(string.Empty);
            }

            if (_keeper.CalculationState == StateKeeper.State.FirstOperation)
            {
                _keeper.CalculationState = StateKeeper.State.SecondInput;
                UpdateNumberDisplay("0");
            }

            if (_keeper.CalculationState == StateKeeper.State.FirstInput || _keeper.CalculationState == StateKeeper.State.SecondInput)
            {
                string stringToDisplay = string.Empty;

                if (sender.GetType() == typeof(Button))
                {
                    Button button = (Button)sender;
                    stringToDisplay = button.Text;
                }

                if (NumberDisplay.Text == "0")
                {
                    UpdateNumberDisplay(stringToDisplay);
                }
                else
                {
                    UpdateNumberDisplay(NumberDisplay.Text + stringToDisplay);
                }
            }
        }

        public void OperationClick(object sender, EventArgs e)
        {
            string operation = string.Empty;
            if (sender.GetType() == typeof(Button))
            {
                Button button = (Button)sender;
                operation = button.Text;
            }

            currentNumber = double.Parse(NumberDisplay.Text);
            if (_keeper.CalculationState == StateKeeper.State.FirstInput)
            {
                _keeper.CalculationState = StateKeeper.State.FirstOperation;
                UpdateCurrentCalculationDisplay(currentNumber + " " + operation);
                _calculationStateFactory.InsertFirstNumber(currentNumber);
                _calculationStateFactory.InsertOperation(operation);
            }
            else if (_keeper.CalculationState == StateKeeper.State.SecondInput)
            {
                _keeper.CalculationState = StateKeeper.State.PerformCalculation;
                _calculationStateFactory.InsertSecondNumber(currentNumber);
                PerformCalulationUpdate(operation);
            }
            /*
            string operation = "0";
            char[] charsToCheck = { '+', '-', 'X', '÷' };
            ProcessTextInput();
            if (CurrentCalculation.Text.Contains("="))
            {
                UpdateCurrentCalculationDisplay(NumberDisplay.Text);
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
                UpdateCurrentCalculationDisplay(NumberDisplay.Text + " " + operation);
                _calculationStateFactory.InsertOperation(operation);


            }
            string currentCalc = string.Empty;
            if (_keeper.CalculationState == StateKeeper.State.FirstInput)
            {
                if (string.IsNullOrEmpty(CurrentCalculation.Text))
                {
                    UpdateCurrentCalculationDisplay(currentNumber.ToString());
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
                //currentNumber = double.Parse(NumberDisplay.Text);
                if (_calculationStateFactory.CurrentOperation != string.Empty)
                {
                    _calculationStateFactory.InsertSecondNumber(double.Parse(NumberDisplay.Text));
                    UpdateCurrentCalculationDisplay(_calculationStateFactory.Result.ToString() + " " + operation);
                    UpdateNumberDisplay(_calculationStateFactory.Result.ToString());
                    currentCalc = CurrentCalculation.Text;
                    currentNumber = _calculationStateFactory.Result;
                    _calculationStateFactory.ResetState();
                    _calculationStateFactory.InsertFirstNumber(double.Parse(NumberDisplay.Text));
                    _calculationStateFactory.InsertOperation(operation);
                    _keeper.CalculationState = StateKeeper.State.FirstOperation;
                }
                //_calculationStateFactory.InsertOperation(operation);
                //_calculationStateFactory.InsertSecondNumber(currentNumber);
                //UpdateCurrentCalculationDisplay(CurrentCalculation.Text + " " + NumberDisplay.Text);
                //UpdateNumberDisplay(_calculationStateFactory.Result.ToString());
                //currentNumber = _calculationStateFactory.Result;
                if (!charsToCheck.Any(x => currentCalc.EndsWith(x.ToString())))
                {
                    currentCalc = currentCalc + " " + operation;
                }
                else
                {
                    currentCalc = _calculationStateFactory.FullCalculation;
                    ResetForNextNumber(currentCalc);
                    _calculationStateFactory.ResetState();
                    _calculationStateFactory.InsertFirstNumber(currentNumber);
                    _calculationStateFactory.InsertOperation(operation);
                }

                _keeper.CalculationState = StateKeeper.State.PerformCalculation;
                calculationsHistory.Add(currentCalc);
            }
            */
        }

        private void PerformCalulationUpdate(string operation)
        {
            if (_keeper.CalculationState == StateKeeper.State.PerformCalculation && operation != "=")
            {

                UpdateNumberDisplay(_calculationStateFactory.Result.ToString());
                currentNumber = _calculationStateFactory.Result;
                _calculationStateFactory.ResetState();
                _calculationStateFactory.InsertFirstNumber(currentNumber);
                _calculationStateFactory.InsertOperation(operation);
                _keeper.CalculationState = StateKeeper.State.FirstOperation;
                UpdateCurrentCalculationDisplay(_calculationStateFactory.FullCalculation);
            }

            if (_keeper.CalculationState == StateKeeper.State.PerformCalculation && operation == "=")
            {
                currentNumber = 0;
                _calculationStateFactory.InsertSecondNumber(double.Parse(NumberDisplay.Text));
                string currentCalc = _calculationStateFactory.FullCalculation;
                UpdateCurrentCalculationDisplay(_calculationStateFactory.FullCalculation + " =");
                UpdateNumberDisplay(_calculationStateFactory.Result.ToString());
                _keeper.CalculationState = StateKeeper.State.FirstInput;
            }
        }

        public void ChangeSignClick(object sender, EventArgs e)
        {
            if (currentNumber == double.Parse(NumberDisplay.Text))
            {
                currentNumber = currentNumber * -1;
            }
            else
            {
                currentNumber = double.Parse(NumberDisplay.Text) * -1;
            }
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

        public void UpdateCurrentCalculationDisplay(string stringToDisplay)
        {
            CurrentCalculation.Text = stringToDisplay;
        }

        private void Clear(object sender, EventArgs e)
        {
            addDecimalOnNextNumber = false;
            UpdateCurrentCalculationDisplay(string.Empty);
            UpdateNumberDisplay("0");
            currentNumber = 0;
            _calculationStateFactory.ResetState();
            _keeper.CalculationState = StateKeeper.State.FirstInput;
        }

        private void ClearEverything(object sender, EventArgs e)
        {
            addDecimalOnNextNumber = false;
            UpdateNumberDisplay("0");
            ResetForNextNumber(string.Empty);
            _calculationStateFactory.ResetState();
            _keeper.CalculationState = StateKeeper.State.FirstInput;
        }

        private void BackSpace(object sender, EventArgs e)
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
                UpdateNumberDisplay("0");
            }

            if (NumberDisplay.Text.StartsWith(".") && NumberDisplay.Text.Length > 1)
            {
                UpdateNumberDisplay("0" + NumberDisplay.Text);
            }

            if (NumberDisplay.Text.EndsWith(".") && NumberDisplay.Text.Length > 1)
            {
                UpdateNumberDisplay(NumberDisplay.Text + "0");
            }
        }

        private void ResetForNextNumber(string calculation)
        {
            currentNumber = 0;
            UpdateCurrentCalculationDisplay(calculation);
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (_keeper.CalculationState == StateKeeper.State.SecondInput)
            {
                _keeper.CalculationState = StateKeeper.State.PerformCalculation;
                PerformCalulationUpdate("=");
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
                    currentNumber = 0;
                    _calculationStateFactory.InsertSecondNumber(percentage);
                    UpdateNumberDisplay(percentage.ToString());

                }
            }
        }
    }
}
