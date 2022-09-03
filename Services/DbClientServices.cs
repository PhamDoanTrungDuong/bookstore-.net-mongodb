using BookStore.Config;
using BookStore.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.Services
{
      public class DbClientServices
      {
            private readonly IMongoCollection<Book> _books;
            public DbClientServices(IOptions<DbConfig> bookStoreDbConfig)
            {
                var client = new MongoClient(bookStoreDbConfig.Value.Connection_String);
                var databse = client.GetDatabase(bookStoreDbConfig.Value.Database_Name);
                _books = databse.GetCollection<Book>(bookStoreDbConfig.Value.Books_Collection_Name);
            }

            public IMongoCollection<Book> GetBooksCollection()
            {
                return _books;
            }
      }
}