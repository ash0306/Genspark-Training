namespace IdValidation
{
    internal class Program
    {
        static public string GetID()
        {
            string id = "";
            while (id.Length<16)
            {
                Console.WriteLine("Enter ID to be validated:");
                id = Console.ReadLine() ?? "";
                Console.WriteLine("Invalid entry. Please try again.");
            }

            return id;
        }

        static public bool Validate( string revId)
        {
            int total = 0;

            for(int i = 0; i < revId.Length; i++)
            {
                int digit = revId[i] - 48;
                if (i % 2 == 1)
                {
                    digit *= 2;

                    if (digit > 10)
                    {
                        digit -=9;
                    }
                    total += digit;
                }
                else
                {
                    total += digit;
                }
            }
            if (total%10 == 0)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string IdNum;
            IdNum = GetID();

            char[] charArray = IdNum.ToCharArray();
            Array.Reverse(charArray);

            string revId = new string(charArray);

            bool valid = Validate(revId);

            if(valid)
            {
                Console.WriteLine("This is a valid ID number!!");
            }
            else
            {
                Console.WriteLine("This is not a valid ID number!!");
            }
        }
    }
}
