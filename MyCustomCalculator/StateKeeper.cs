// -------------------------------------------------------------------------------
// Copyright (c) 2024 Michael Kalkas
// Used for mentoring others.
// -------------------------------------------------------------------------------
namespace MyCustomCalculator
{
    public class StateKeeper
    {
        public enum State
        {
            FirstInput, FirstOperation, SecondInput, PerformCalculation, PerformOperationOnCurrentNumber
        }
        public StateKeeper()
        {
            this.CalculationState = State.FirstInput;
        }

        public State CalculationState { get; set; }
    }
}
