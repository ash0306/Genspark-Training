namespace CheckLogin
{
    internal class Program
    {
        static string GetString(string input)
        {
            string field;
            Console.WriteLine($"Enter the {input}:");
            field = Console.ReadLine() ?? "null";

            return field;
        }
        static void CheckUsername()
        {
            int attempt = 0;
            while (attempt < 3)
            {
                string username = GetString("username");
                if(username == "ABC") 
                {
                    CheckPassword();
                    return;
                }
                else
                {
                    attempt++;
                }
            }
            DisplayResult("username", "incorrect");
        }
        static void CheckPassword()
        {
            int attempt = 0;
            while (attempt < 3)
            {
                string password = GetString("password");
                if (password == "123")
                {
                    DisplayResult("username and password", "correct");
                    return;
                }
                else
                {
                    attempt++;
                }
            }
            DisplayResult("password", "incorrect");
        }
        static void DisplayResult(string field, string status)
        {
            Console.WriteLine($"You have entered {status} {field}");
        }
        static void Main(string[] args)
        {
            CheckUsername();
        }
    }
}
