using System;

namespace Core
{
    public class Post : IEntity
    {
        public int id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime LastModified { get; set; }
    }
}
