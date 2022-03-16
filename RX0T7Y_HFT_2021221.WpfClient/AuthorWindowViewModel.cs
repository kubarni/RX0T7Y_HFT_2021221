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
    public class AuthorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }
        private Author selectedAuthor;

        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set 
            {
                if (value!=null)
                {
                    selectedAuthor = new Author()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        PlaceOfBirth = value.PlaceOfBirth,
                        PublisherId = value.PublisherId,
                        YearOfBirth = value.YearOfBirth
                    };
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public ICommand CreateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }
        public AuthorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Authors = new RestCollection<Author>("http://localhost:31278/", "author", "hub");
                CreateAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Add(new Author()
                    {
                        Name = SelectedAuthor.Name,
                        PublisherId = SelectedAuthor.PublisherId,
                        PlaceOfBirth = SelectedAuthor.PlaceOfBirth,
                        YearOfBirth = SelectedAuthor.YearOfBirth
                    });
                });

                UpdateAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Update(SelectedAuthor);
                });
                DeleteAuthorCommand = new RelayCommand(() =>
                {
                    Authors.Delete(SelectedAuthor.Id);
                },
                () =>
                {
                    return SelectedAuthor != null;
                });
                SelectedAuthor = new Author();
            }
        }
    }
}
