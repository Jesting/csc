using System;
namespace Lection19Program2.Model
{
	public class AuthorModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class BookModel
    {
        public string Author{ get; set; }
        public string Title { get; set; }
    }
}

