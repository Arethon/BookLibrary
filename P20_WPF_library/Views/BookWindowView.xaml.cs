﻿using P20_WPF_library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace P20_WPF_library.Views
{
    /// <summary>
    /// Interaction logic for BookWindowView.xaml
    /// </summary>
    public partial class BookWindowView : Window
    {
        private readonly BookWindowViewModel _bookWindowViewModel;
        public BookWindowView(BookWindowViewModel bookWindowViewModel)
        {
            InitializeComponent();
            _bookWindowViewModel = bookWindowViewModel;
            DataContext = _bookWindowViewModel;
        }
    }
}
