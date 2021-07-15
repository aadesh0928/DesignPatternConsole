using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book() {Title = "C#", Price = 23.8f },
                new Book() {Title = "ASP.Net Step by Step", Price = 223.8f },
                new Book() {Title = ".Net core web api", Price = 73.8f },
                new Book() {Title = "C# Advanced", Price = 233.8f }
            };
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
