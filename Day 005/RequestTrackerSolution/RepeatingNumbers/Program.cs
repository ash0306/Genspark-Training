namespace RepeatingNumbers
{
    internal class Program
    {
        static bool RepeatingCheck(int num)
        {
            int firstDigit = num / 100;
            int secondDigit = (num/10)%10;
            int thirdDigit = num % 10;

            if(firstDigit == secondDigit && thirdDigit == firstDigit)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int[] numbers = { 222, 523, 678, 777, 824, 999 };
            int count = 0;
            Console.WriteLine("The numbers are:");

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
                if (RepeatingCheck(number))
                {
                    count++;
                }
            }
            Console.WriteLine($"The count of numbers with repeating digits is {count}");
        }
    }
}
