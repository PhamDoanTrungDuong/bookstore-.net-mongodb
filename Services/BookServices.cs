using System.Collections.Generic;
using BookStore.Config;
using BookStore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.Services
{
      public class BookServices
      {
            private readonly IMongoCollection<Book> _books;

            public BookServices(IOptions<DbConfig> bookStoreDbConfig)
            {
                var client = new MongoClient(bookStoreDbConfig.Value.Connection_String);
                var databse = client.GetDatabase(bookStoreDbConfig.Value.Database_Name);
                _books = databse.GetCollection<Book>(bookStoreDbConfig.Value.Books_Collection_Name);
            }

            public List<Book> GetBooks()
            {
                return _books.Find(book => true).ToList();
            }

            public ActionResult<Book> AddBook(Book book)
            {
                _books.InsertOne(book);
                return book;
            }

            public ActionResult<Book> GetBook(string id)
            {
                return _books.Find(x => x.Id == id).FirstOrDefault();
            }

            public void DeleteBook(string id)
            {
                _books.DeleteOne(x => x.Id == id);
            }

            public ActionResult<Book> UpdateBook(Book book)
            {
                GetBook(book.Id);
                _books.ReplaceOne(x => x.Id == book.Id, book);
                return book;
            }
      }
}