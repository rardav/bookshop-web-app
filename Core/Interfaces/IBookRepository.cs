using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IReadOnlyList<Book>> GetBooksAsync();
        Task<IReadOnlyList<Publisher>> GetPublishersAsync();
        Task<IReadOnlyList<Genre>> GetGenresAsync();
    }
}