using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using P20_Shared_Library.Configuration;
using P20_Shared_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P20_Shared_Library.Services
{
    public class BookService : IBooksService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public BookService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }


        public async Task<ServiceResponse<Book>> CreateBookAsync(Book book)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BooksEndpoint.PostBook,book);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json);
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"book/{id}");
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(json);
            return result;
        }

        public async Task<ServiceResponse<List<Book>>> GetAllBooksAsync()
        {
            var response = await _httpClient.GetAsync(_appSettings.BooksEndpoint.GetBooks) ;
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
            return result;
        }

        public Task<ServiceResponse<List<Book>>> GetBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Book>>> UpdateBookAsync(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
