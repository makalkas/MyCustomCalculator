using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyCustomCalculator
{
    public partial class StandardForm : Form
    {
        private List<string> calculationsHistory = new List<string>();//Stores each calculation set for possible history integration.
        private double currentNumber = 0;
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

        }

        private void PerformCalulationUpdate(string operation)
        {
            if (_keeper.CalculationState == StateKeeper.State.PerformCalculation && operation != "=")
            {

                UpdateNumberDisplay(_calculationStateFactory.Result.ToString());
                currentNumber = _calculationStateFactory.Result;
                calculationsHistory.Add(_calculationStateFactory.FullCalculation);
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
                calculationsHistory.Add(_calculationStateFactory.FullCalculation);
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
            string[] operations = { "+", "-", "X", "÷", "=" };
            if (operations.Any(x => CurrentCalculation.Text.EndsWith(x)) && !NumberDisplay.Text.Contains("."))
            {
                UpdateNumberDisplay(NumberDisplay.Text + ".");
                _keeper.CalculationState = StateKeeper.State.SecondInput;
            }
            else if (!NumberDisplay.Text.Contains("."))
            {

                UpdateNumberDisplay(NumberDisplay.Text + ".");
            }
            else if (_keeper.CalculationState == StateKeeper.State.FirstOperation)
            {
                UpdateNumberDisplay("0.");
                _keeper.CalculationState = StateKeeper.State.SecondInput;
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
