using SampleEFApp.Model;

namespace SampleEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dbEmployeeTrackerContext context = new dbEmployeeTrackerContext();

            // ADD
            Area area1 = new Area();
            area1.Area1 = "BLUE";
            area1.Zipcode = "12345";
            var id = context.Areas.Add(area1);
            context.SaveChanges();

            //// UPDATE
            var areas = context.Areas.ToList();
            //var area = areas.SingleOrDefault(a => a.Area1 == "AAAA");
            //area.Zipcode = "11111";
            //context.Areas.Update(area);
            //context.SaveChanges();

            ////// REMOVE
            //area = areas.SingleOrDefault(a => a.Area1 == "POPO");
            //context.Areas.Remove(area);
            //context.SaveChanges();


            // GET ALL
            areas = context.Areas.ToList();
            foreach (var a in areas)
            {
                Console.WriteLine(a.Area1 + " " + a.Zipcode);
            }
        }
    }
}
