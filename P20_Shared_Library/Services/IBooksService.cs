using P20_Shared_Library.Model;

namespace P20_Shared_Library.Services
{
    public interface IBooksService
    {
        public Task<ServiceResponse<List<Book>>> GetAllBooksAsync();
        public Task<ServiceResponse<List<Book>>> GetBookAsync(int id);
        public Task<ServiceResponse<bool>> DeleteBookAsync(int id);
        public Task<ServiceResponse<Book>> CreateBookAsync(Book book);

        public Task<ServiceResponse<List<Book>>> UpdateBookAsync(Book book);

    }
}
