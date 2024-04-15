namespace LengthOfName
{
    internal class Program
    {
        static string GetName()
        {
            string name;
            Console.WriteLine("Enter a string:");
            name = Console.ReadLine() ?? "null";

            return name;
        }

        static void DisplayResult(int len)
        {
            Console.WriteLine($"The length is {len}");
        }

        static void LengthOfName()
        {
            string name;
            name = GetName();

            if (name == null)
            {
                Console.WriteLine("The name entered is invalid!");
            }
            else
            {
                DisplayResult(name.Length);
            }

        }
        static void Main(string[] args)
        {
            LengthOfName();
        }
    }
}
