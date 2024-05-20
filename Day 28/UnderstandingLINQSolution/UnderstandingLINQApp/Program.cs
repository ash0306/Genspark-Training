using UnderstandingLINQApp.Model;

namespace UnderstandingLINQApp
{
    internal class Program
    {
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId)
        //                .Select(t => new {
        //                    PublisherId = t.Key,
        //                    TitleCount = t.Count(),
        //                    Titles = t.Select(t => new
        //                    {
        //                        BookName = t.Title1,
        //                        BookPrice = t.Price
        //                    })
        //                });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.PublisherId);
        //        Console.WriteLine(" - " + book.TitleCount);
        //        foreach (var title in book.Titles)
        //        {
        //            Console.WriteLine("\t"+ title.BookName+" "+title.BookPrice);
        //        }
        //    }
        //}
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        void PrintSaleDetails()
        {
            pubsContext context = new pubsContext();
            var orders = context.Sales
                .GroupBy(s => s.TitleId, s => s, (tid, sale) => new
                {
                    Key = tid,
                    OrderDetails = sale.ToList()
                });

            var sales = context.Sales
                .GroupBy(s => s.TitleId)
                .Select(g => new
                {
                    TitleId = g.Key,
                    OrderDetails = g.Select(s => new
                    {
                        OrderId = s.OrdNum,
                        Quantity = s.Qty
                    })
                });
            foreach (var s in sales)
            {
                Console.WriteLine("Title is");
                Console.WriteLine(s.TitleId);
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Order details are ");
                foreach (var item in s.OrderDetails)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(item.OrderId);
                    Console.WriteLine(item.Quantity);
                    Console.WriteLine("------------------------------------");
                }
                Console.WriteLine("------------------------------------");
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintSaleDetails();
        }
        
    }
}
