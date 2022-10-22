using backend.Models;

namespace backend.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetBooks();

    }
}
