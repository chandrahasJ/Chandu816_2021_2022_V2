using System;
using System.Collections.Generic;
using System.Text;

namespace LambaExpressionExample102
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
    }
    public class BookRepo
    {
        public List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book(){ Id = 1, Title = "Learn C#", Price=999},
                new Book(){ Id = 2, Title = "Learn F#", Price=5100},
                new Book(){ Id = 3, Title = "Learn Java", Price=2000},
            };
        }
    }
}
