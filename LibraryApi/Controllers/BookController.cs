using LibraryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P20_Shared_Library;
using P20_Shared_Library.Model;
using P20_Shared_Library.Services;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly IBooksService _booksService;

        public BookController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {
            var results = await _booksService.GetAllBooksAsync();
            if (results.Success)
                return Ok(results);
            else
            {
                return StatusCode(500,$"Inernat server error {results.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Book>>> CreateBook([FromBody] Book newBook)
        {
            var results = await _booksService.CreateBookAsync(newBook);
            if (results.Success)
                return Ok(results);
            else
            {
                return StatusCode(500, $"Inernat server error {results.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBook([FromRoute]int id)
        {
            var results = await _booksService.DeleteBookAsync(id);
            if (results.Success)
                return Ok(results);
            else
            {
                return StatusCode(500, $"Inernat server error {results.Message}");
            }
        }
    }
}
