using CommunityToolkit.Mvvm.ComponentModel;
using P20_Shared_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P20_WPF_library.ViewModels
{
    public class BookWindowViewModel : ObservableObject
    {
        public Book book { get; set; }


    }
}
