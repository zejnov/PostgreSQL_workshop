using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PostgreSQL_poc
{
    public class Fetch
    {
        public void FetchData()
        {
            using (var db = new BloggingContext())
            {
                var comments = db.Comments
                    .Select(c => c.Post)
                    .Include(c => c.Blog)
                    //.Where(c => c.Blog.CustomData )
                    .FirstOrDefault();
                
                Console.WriteLine($"This is {comments?.Blog.Url}");
                Console.ReadKey(false);
            }

            
        }
    }
}