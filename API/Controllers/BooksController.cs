using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _booksRepo;
        private readonly IGenericRepository<Publisher> _publishersRepo;
        private readonly IGenericRepository<Genre> _genresRepo;
        private readonly IMapper _mapper;

        public BooksController(IGenericRepository<Book> booksRepo,
            IGenericRepository<Publisher> publishersRepo,
            IGenericRepository<Genre> genresRepo,
            IMapper mapper)
        {
            _booksRepo = booksRepo;
            _publishersRepo = publishersRepo;
            _genresRepo = genresRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BookToReturnDto>>> GetBooks()
        {
            var spec = new BooksWithAuxSpecification();
            var books = await _booksRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookToReturnDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookToReturnDto>> GetBook(int id)
        {
            var spec = new BooksWithAuxSpecification(id);
            var book = await _booksRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Book, BookToReturnDto>(book);
        }

        [HttpGet("publishers")]
        public async Task<ActionResult<IReadOnlyList<Publisher>>> GetPublishers() 
        {
            var publishers = await _publishersRepo.ListAllAsync();
            
            return Ok(publishers);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<IReadOnlyList<Genre>>> GetGenres()
        {
            var genres = await _genresRepo.ListAllAsync();
            
            return Ok(genres);
        }


    }
}