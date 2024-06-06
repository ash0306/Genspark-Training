using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    
    internal class AsyncProgramming
    {
        //public int GetResultFromDatabaseServer()
        //{
        //    return new Random().Next();
        //}

        //public void Run()
        //{
        //    int number = GetResultFromDatabaseServer();
        //    Console.WriteLine("This is the random number from main" + new Random().Next());
        //    Console.WriteLine("This is the random number from server " + number);
        //}

        //async Task<int> GetResultFromDatabaseServer()
        //{
        //    Thread.Sleep(5000);
        //    return new Random().Next();
        //}

        //static async Task Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //    AsyncProgramming asyncProgramming = new AsyncProgramming();
        //    var number = asyncProgramming.GetResultFromDatabaseServer();
        //    Console.WriteLine("This is the random number from main" + new Random().Next());
        //    Console.WriteLine("This is the random number from server " + number);
        //    var number1 = await asyncProgramming.GetResultFromDatabaseServer();
        //    Console.WriteLine(number1);
        //}


        //void PrintNumbers()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
        //        Thread.Sleep(1000);
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    AsyncProgramming asyncProgramming = new AsyncProgramming();
        //    Thread t1 = new Thread(asyncProgramming.PrintNumbers);
        //    t1.Name = "You";
        //    Thread t2 = new Thread(asyncProgramming.PrintNumbers);
        //    t2.Name = "Me";
        //    t1.Start();
        //    t2.Start();
        //    Console.WriteLine("After the thread call");
        //}
    }
}
