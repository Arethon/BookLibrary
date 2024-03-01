using CommunityToolkit.Mvvm.Input;
using P20_Shared_Library.Model;
using P20_Shared_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20_WPF_library.ViewModels
{
    public class NewBookWindowViewModel
    {
        public Book book { get; set; }
        private readonly IBooksService _booksService;

        public IRelayCommand CreateBookCommand => new AsyncRelayCommand(CreateBookExecute);

        private async Task CreateBookExecute()
        {
            await _booksService.CreateBookAsync(book);
        }

        public NewBookWindowViewModel(IBooksService booksService)
        {
            _booksService = booksService;
        }
    }
}
