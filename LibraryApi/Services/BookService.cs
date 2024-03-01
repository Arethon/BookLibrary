using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using P20_Shared_Library;
using P20_Shared_Library.Model;
using P20_Shared_Library.Services;

namespace LibraryApi.Services
{
    public class BookService : IBooksService
    {
            private readonly LibraryContext _context;

            public BookService(LibraryContext libraryContext)
            {
                _context = libraryContext;
            }

            public async  Task<ServiceResponse<List<Book>>> GetAllBooksAsync()
            {
                var response = new ServiceResponse<List<Book>>();
                try
                {
                    response.Data = await _context.Books.ToListAsync();
                    response.Success = true;
                response.Message = "Book get successfully";
            }
                catch(Exception e)
                {
                response.Success = false;
                response.Message = $"All books get failed - {e.Message}";
            }
            return response;
            }

            public Book GetBookById(int id)
            {
                return _context.Books.FirstOrDefault(book => book.Id == id);
            }

            public void UpdateBook(Book book)
            {
                _context.Books.Update(book);
                _context.SaveChanges();
            }

            public void DeleteBook(int id)
            {

            }

        public Task<ServiceResponse<List<Book>>> GetBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            ServiceResponse<bool> response = new();
            var bookToDelete = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book book)
        {
            var response = new ServiceResponse<Book>();
            try
            {
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Message = "Book added successfully";
                response.Data = book;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = $"Error during adding book - {e.Message}";
            }
            return response;
        }

        public Task<ServiceResponse<List<Book>>> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
