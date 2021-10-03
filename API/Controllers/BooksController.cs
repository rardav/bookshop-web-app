using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public BooksController(IBookRepository repo)
        {
           _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _repo.GetBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _repo.GetBookByIdAsync(id);
        }

        [HttpGet("publishers")]
        public async Task<ActionResult<IReadOnlyList<Publisher>>> GetPublishers() 
        {
            var publishers = await _repo.GetPublishersAsync();
            
            return Ok(publishers);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<IReadOnlyList<Genre>>> GetGenres()
        {
            var genres = await _repo.GetGenresAsync();
            
            return Ok(genres);
        }


    }
}