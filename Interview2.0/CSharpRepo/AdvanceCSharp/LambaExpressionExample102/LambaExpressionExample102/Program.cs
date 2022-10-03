using System;

namespace LambaExpressionExample102
{
    class Program
    {
        static void Main(string[] args)
        {
            //Fill the books using DB or Json etc.
            //It returns Books
            var books = new BookRepo().GetBooks();

            //Normal way
            var results = books.FindAll(CostlyBooksMoreThan1000);
            foreach (var item in results)
                Console.Write($"{item.Title} \t\t");
            Console.WriteLine();

            //Using Lamba Expression - Output would be same.
            var lambaResult = books.FindAll(book => book.Price > 1000);
            foreach (var item in lambaResult)
                Console.Write($"{item.Title} \t\t");
            Console.WriteLine();
        }

        public static bool CostlyBooksMoreThan1000(Book book)
        {
            return book.Price > 1000;
        }
    }
}
