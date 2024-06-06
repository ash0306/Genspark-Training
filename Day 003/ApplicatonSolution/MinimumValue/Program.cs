namespace MinimumValue
{
    internal class Program
    {
        static void DisplayResult(double maxValue)
        {
            Console.WriteLine($"The maximum value is {maxValue}");
        }
        static void FindMaxValue()
        {
            double maxValue = double.MinValue;
            bool end = false;
            Console.WriteLine("Enter your numbers one by one (to stop enter negative number): ");
            while (!end)
            {
                if (double.TryParse(Console.ReadLine(), out double num) != false)
                {
                    if (num < 0)
                    {
                        end = true;
                    }
                    else if (num > maxValue)
                    {
                        maxValue = num;
                    }
                }
            }
            DisplayResult(maxValue);
            
        }
        static void Main(string[] args)
        {
            FindMaxValue();
        }
    }
}
