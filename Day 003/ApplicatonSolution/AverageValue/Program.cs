namespace AverageValue
{
    internal class Program
    {
        static void GetAverage()
        {
            double sum = 0;
            int count = 0;
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
                    else if (num % 7 == 0)
                    {
                        sum += num;
                        count++;
                    }
                }
            }
            DisplayResult(sum / count);
        }

        static void DisplayResult(double avg)
        {
            Console.WriteLine($"The average of numbers divisible by 7 is {avg}");
        }
        static void Main(string[] args)
        {
            GetAverage();
        }
    }
}
