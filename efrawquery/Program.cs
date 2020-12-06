using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace efrawquery
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample begin....");

            #region FromSqlRaw

            using (var context = new DBContext())
            {
                Console.WriteLine("FromSqlRaw output begins....");

                var blogs = context.Blogs
                    .FromSqlRaw("SELECT * FROM dbo.Blogs")
                    .ToList();

                foreach (Blog o in blogs)
                    Console.WriteLine("Blog id:" + o.BlogId + ", Blog Url: " + o.Url + ", Blog Rating: " + o.Rating);

            }
            #endregion

            #region FromSqlInterpolatedComposed
            using (var context = new DBContext())
            {
                var Name = "https://maheshk.net";

                Console.WriteLine("FromSqlInterpolated output begins.....");

                var blogs = context.Blogs
                    .FromSqlInterpolated($"SELECT * From Blogs Where url = {Name}")
                    //.OrderBy(b => b.Rating)
                    .ToList();

                foreach (Blog o in blogs)
                    Console.WriteLine("RESULT: Url: " + o.Url + ", Blog Rating: " + o.Rating);
            }
            #endregion

            Console.WriteLine("//End");
        }
    }
}
