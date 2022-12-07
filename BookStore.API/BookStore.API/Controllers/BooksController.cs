using BookStore.API.Models;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;

        public BooksController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        // default route
        [HttpGet("")]
        public async Task<ActionResult<List<BookModel>>> GetAllBooks()
        {
            var books = await _bookRepo.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookModel>> GetBookById([FromRoute]int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]AddBookModel bookModel)
        {
            var id = await _bookRepo.AddNewBookAsync(bookModel);
            
            return CreatedAtAction(nameof(GetBookById), new {id = id, controller = "Books" }, id);
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdateBook([FromRoute]int id, [FromBody] AddBookModel bookModel)
        {
            await _bookRepo.UpdateBookAsync(id, bookModel);
            return true;
        }

        [HttpPatch("{id}")]
        public async Task<bool> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument bookModel)
        {
            await _bookRepo.UpdateBookPatchAsync(id, bookModel);
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteBookPatch([FromRoute] int id)
        {
            await _bookRepo.DeleteBookAsync(id);
            return true;
        }
    }
}
