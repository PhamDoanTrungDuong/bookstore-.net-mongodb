using System.Threading.Tasks;
using BookStore.Entities;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
      public class BookController : BaseController
      {
            private readonly BookServices _bookServices;
            public BookController(BookServices bookServices)
            {
                  _bookServices = bookServices;
            }

            [HttpGet]
            public ActionResult GetBooks()
            {
                return Ok(_bookServices.GetBooks());
            }

            [HttpGet("{id}", Name = "GetBook")]
            public ActionResult GetBook(string id)
            {
                return Ok(_bookServices.GetBook(id));
            }

            [HttpPost]
            public ActionResult AddBook(Book book)
            {
                  _bookServices.AddBook(book);
                  return CreatedAtRoute("GetBook", new { id = book.Id }, book);
            }

            [HttpDelete("{id}")]
            public ActionResult DeleteBook(string id)
            {
                  _bookServices.DeleteBook(id);
                  return NoContent();
            }

            [HttpPut]
            public ActionResult<Book> UpdateBook(Book book)
            {
                  return Ok(_bookServices.UpdateBook(book));
            }
      }
}