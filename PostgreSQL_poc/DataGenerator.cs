using System;
using System.Collections.Generic;

namespace PostgreSQL_poc
{
    public class DataGenerator
    {
        private Random _random = new Random();
        
        
        public Blog GenerateBlog()
        {
            return new Blog()
            {
                CustomData = GetCustomData(),
                Posts = GeneratePost(),
                Url = GetBlogUrl()
            };
        }

        private List<Post> GeneratePost()
        {
            var postList = new List<Post>();
            var postCount = _random.Next(0, 22);

            for (var i = 0; i < postCount; i++)
            {
                postList.Add(new Post()
                {
                    Content = $"Some {_random.Next(0, 111)} tekst, with {_random.Next(0, 111)} number.",
                    Tags = $"[\"Tag_{_random.Next(0, 111)}\",\"Tag_{_random.Next(0, 111)}\"]",
                    Comments = GenerateComments()
                });
            }

            return postList;
        }

        private List<Comment> GenerateComments()
        {
            var commentList = new List<Comment>();
            var commentCount = _random.Next(0, 22);
            
            for (var i = 0; i < commentCount; i++)
            {
                commentList.Add(new Comment()
                {
                    DateTimeCreated = DateTime.UtcNow,
                    AuthorNickname = $"Author_{_random.Next(0,1234)}_{_random.Next(0,12)}",
                    Content = $"Comment_{_random.Next(0,1234)}_content_{_random.Next(0,12)}"
                });
            }
            return commentList;
        }

        private string GetBlogUrl()
        {
            var random = _random.Next(0, 111);
            return $"http://www.someblog-{random}/";
        }

        public string GetCustomData()
        {
            var sth = $"{{\"title\": \"{GetTitle()}\", \"genres\": [\"{GetGenre()}\", \"{GetGenre()}\"], \"authors\": [\"{GetAuthor()}\", \"{GetAuthor()}\"], \"published\": {GetBool()}}}";

            return sth;
        }

        private string GetBool()
        {
            var random = _random.Next(0, 1);
            return random == 0
                ? "false"
                : "true";
        }
        
        private string GetAuthor()
        {
            var random = _random.Next(0, 444);
            return $"Author_{random}";
        }
        
        private string GetTitle()
        {
            var random = _random.Next(0, Titles.Count);
            return Titles[random];
        }

        private string GetGenre()
        {
            var random = _random.Next(0, Genres.Count);
            return Genres[random];
        }
        
        private List<string> Genres => new List<string>()
        {
            "Science fiction", "Satire", "Drama", "Action", "Romance", "Mystery", "Horror"    
        };
        
        private List<string> Titles => new List<string>()
        {
            "That title", "Some title", "Other title", "Weird title", "Super blog", "Extra blog"
        };
    }
}