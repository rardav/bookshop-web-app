using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly StoreContext _context;
        public BookRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IReadOnlyList<Book>> GetBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Genre>> GetGenresAsync()
        {
            return await _context.Genres
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Publisher>> GetPublishersAsync()
        {
            return await _context.Publishers.ToListAsync();
        }
    }
}