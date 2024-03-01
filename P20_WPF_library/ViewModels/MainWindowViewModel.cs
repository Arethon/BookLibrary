using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P20_Shared_Library.Model;
using P20_Shared_Library.Services;
using P20_WPF_library.Views;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;


namespace P20_WPF_library.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly IBooksService _booksService;
        public ObservableCollection<Book> Books { get; set; } = new();
        public IRelayCommand GetAllBooksCommand => new AsyncRelayCommand(GetAllBooksCommandExecute);
        public IRelayCommand OpenEditBookWindowCommand => new RelayCommand<object>(OpenEditBookWindowExecute);
        public IRelayCommand OpenNewBookWindowCommand => new RelayCommand(OpenNewBookWindowExecute);

        public IRelayCommand DeleteBookCommand => new AsyncRelayCommand<object>(DeleteBookExecute);

        [ObservableProperty]
        private string results;
        private async Task DeleteBookExecute(object? bookObject)
        {
            var book = bookObject as Book;
            var result = await _booksService.DeleteBookAsync(book.Id);
            results += $"Delete book - {book.Title} ID: {book.Id} Success: {result.Success} \n";
            await GetAllBooksCommandExecute();
        }

        private readonly IServiceProvider _serviceProvider;
        [ObservableProperty]
        public bool isLoading;

        private void OpenEditBookWindowExecute(object bookObject)
        {
            BookWindowView bookWindow =_serviceProvider.GetService<BookWindowView>();
            var book = bookObject as Book;
            ((BookWindowViewModel)bookWindow.DataContext).book = book;   
            bookWindow.Show();
        }

        private void OpenNewBookWindowExecute()
        {
            NewBookWindowView bookWindow = _serviceProvider.GetService<NewBookWindowView>();
            Book book = new();
            ((NewBookWindowViewModel)bookWindow.DataContext).book = book;
            bookWindow.Show();
        }


        private async Task GetAllBooksCommandExecute()
        {
            Results += $"Get all books - Started \n";
            IsLoading = true;
            Books.Clear();
            var httpServiceResponse = await _booksService.GetAllBooksAsync();
            await Task.Delay(3000);
            if(httpServiceResponse.Success)
            {
                foreach (var book in httpServiceResponse.Data)
                {
                    Books.Add(book);
                }
            }
            else
            {
                Console.WriteLine($"Problem with HTTP - {httpServiceResponse.Message}");
            }
            IsLoading = false;
            Results += $"Get all books - Success: {httpServiceResponse.Success} \n";
        }

        public MainWindowViewModel(IBooksService booksService, IServiceProvider serviceProvider) 
        {
            _booksService = booksService;
            _serviceProvider = serviceProvider;
        }
    }
}


