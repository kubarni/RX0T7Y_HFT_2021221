using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using RX0T7Y_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RX0T7Y_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Book> Books { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set 
            {
                if (value!=null)
                {
                    selectedBook = new Book()
                    {
                        Name = value.Name,
                        Length = value.Length,
                        Price = value.Price,
                        Id=value.Id,
                        PublisherId=value.PublisherId,
                    };
                    OnPropertyChanged();
                    (DeleteBookCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand CreateBookCommand { get; set; }
        public ICommand DeleteBookCommand { get; set; }
        public ICommand UpdateBookCommand { get; set; }
        public ICommand AuthorEditorCommand { get; set; }
        public ICommand PublisherEditorCommand { get; set; }

        public MainWindowViewModel()
        {
            
            if (!IsInDesignMode)
            {
                Books = new RestCollection<Book>("http://localhost:31278/", "book", "hub");
                CreateBookCommand = new RelayCommand(() =>
                {
                    Books.Add(new Book()
                    {
                        Name = SelectedBook.Name,
                        PublisherId = SelectedBook.PublisherId,
                        Length = SelectedBook.Length,
                        Price = SelectedBook.Price
                    });
                });

                UpdateBookCommand = new RelayCommand(() => 
                {
                    Books.Update(SelectedBook);
                }
                );

                DeleteBookCommand = new RelayCommand(() =>
                {
                    Books.Delete(SelectedBook.Id);
                },
                () =>
                {
                    return SelectedBook != null;
                });
                SelectedBook = new Book();
                AuthorEditorCommand = new RelayCommand(() =>
                {
                    new AuthorEditor().ShowDialog();
                });
                PublisherEditorCommand = new RelayCommand(() =>
                {
                    new PublisherEditor().ShowDialog();
                });
            }
            
        }
    }
}
