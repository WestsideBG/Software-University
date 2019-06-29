namespace Operations
{
    public class MathOperations : IMathOperations
    {
        public int CalculateArea(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public decimal CalculateArea(decimal firstNumber, decimal secondNumber, decimal thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }

        public double CalculateArea(double firstNumber, double secondNumber, double thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }
    }
}