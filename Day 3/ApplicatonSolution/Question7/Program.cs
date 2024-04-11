namespace Question7
{
    internal class Program
    {
        static string GetString()
        {
            string input;
            Console.WriteLine($"Enter the string:");
            input = Console.ReadLine() ?? "null";

            return input;
        }

        static int CheckVowels( string word)
        {
            int count = 0;

            foreach (var letter in word.ToLower())
            {
                if ("aeiou".Contains(letter))
                {
                    count++;
                }
            }
            return count;
        }
        static void SeperateWords()
        {
            int minVowels = int.MaxValue;
            string input;
            int len;
            input = GetString();

            string[] words = input.Split(',');
            int[] vowelCount = new int[words.Length];

            for (int i = 0; i<words.Length; i++)
            {
                vowelCount[i] = CheckVowels(words[i]);
                if(minVowels > vowelCount[i])
                {
                    minVowels = vowelCount[i];
                }
            }

            Console.WriteLine("The number of words are "+ words.Length);
            Console.WriteLine("The word with least number of vowels:");
            for(int i = 0; i<words.Length; i++)
            {
                if (vowelCount[i] == minVowels)
                {
                    Console.WriteLine(words[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            SeperateWords();
        }
    }
}
