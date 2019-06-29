namespace Operations
{
    public interface IMathOperations
    {


        int CalculateArea(int firstNumber, int secondNumber);
        decimal CalculateArea(decimal firstNumber, decimal secondNumber, decimal thirdNumber);
        double CalculateArea(double firstNumber, double secondNumber, double thirdNumber);
    }
}