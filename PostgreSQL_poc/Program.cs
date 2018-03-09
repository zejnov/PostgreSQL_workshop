using System;

namespace PostgreSQL_poc
{
    class Program
    {
        public DataGenerator DataGenerator = new DataGenerator();

        static void Main()
        {
            //new Program().GenerateData();
            new Fetch().FetchData();
        }

        private void GenerateData()
        {
            var blogg = DataGenerator.GenerateBlog();

            using (var db = new BloggingContext())
            {
                var timestamp = DateTime.UtcNow;
                
                for (int i = 0; i < 1000000; i++)
                {
                    db.Blogs.Add(DataGenerator.GenerateBlog());
                    if (i%100 == 0)
                    {
                        var count = db.SaveChanges();
                                        Console.WriteLine("{0} records saved to database", count);
                    }
                }
//                var count = db.SaveChanges();
//                Console.WriteLine("{0} records saved to database", count);

                var timespan = DateTime.UtcNow - timestamp;
                Console.WriteLine($"Done in {timespan.Hours}h {timespan.Minutes}m {timespan.Seconds}s");
                Console.ReadKey(false);
                
                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }

                Console.ReadKey(false);
            }
        }

        private void Example()
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }
            }
        }
    }
}
