using ShoppingModelLibrary;
using ShoppingDALLibrary;

namespace ShoppingApplication
{
    internal class Program
    {
        //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        //public delegate float calcDelFloat(float n1, float n2);//creating a type that refferes to a method
        public delegate T calcDel<T>(T n1, T n2);//creating a generic  type that refferes to a method
        void Calculate(calcDel<int> cal)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }
        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            //calcDel c1 = new calcDel(program.Add);
            //calcDel<int> c1 = new calcDel<int>(program.Add);//Generic type instantiation
            //calcDel<int> c1 = delegate (int num1, int num2)//You can do if you are alwayts going to use teh ref to use the method
            //{
            //    return (num1 + num2);
            //};
            //calcDel<int> c1 = (int num1, int num2) => (num1 + num2);
            //Func<int, int, int> c = (num1, num2) => (num1 + num2);
            //program.Calculate(c1);

            //IRepository<int, Customer> customerRepo = new CustomerRepository();
            //customerRepo.Add(new Customer { Id = 1, Name = "Ramu", Age = 23 });
            //customerRepo.Add(new Customer { Id = 2, Name = "Ramu", Age = 31 });
            //customerRepo.Add(new Customer { Id = 3, Name = "Komu", Age = 27 });
            //var customers = customerRepo.GetAll().ToList();
            //customers = customers.OrderBy(cust => cust.Name).ThenBy(cust => cust.Age).ToList();
            //foreach (var item in customers)
            //{
            //    Console.WriteLine(item);
            //}


            int[] numbers = { 89, 78, 23, 546, 787, 98, 11, 3 };

            int[] evenNumebrs = numbers.EvenCatch();
            foreach (int n in evenNumebrs)
                Console.WriteLine(n);
            //string message = "Hello World";
            //message = message.Reverse();
            //Console.WriteLine(message);
        }
    }

    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 == 0)
                    result.Add(num);
            return result.ToArray();
        }
    }
}

