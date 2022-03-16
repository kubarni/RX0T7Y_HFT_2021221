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
    public class PublisherWindowViewModel : ObservableRecipient
    {
        public RestCollection<Publisher> Publishers { get; set; }
        private Publisher selectedPublisher;

        public Publisher SelectedPublisher
        {
            get { return selectedPublisher; }
            set 
            {
                if (value != null)
                {
                    selectedPublisher = new Publisher()
                    {
                        Name = value.Name,
                        Headquarters = value.Headquarters,
                        Income = value.Income,
                        Books = value.Books,
                        Authors = value.Authors,
                        Id = value.Id 
                    };
                    OnPropertyChanged();
                    (DeletePublisherCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public ICommand CreatePublisherCommand { get; set; }
        public ICommand DeletePublisherCommand { get; set; }
        public ICommand UpdatePublisherCommand { get; set; }

        public PublisherWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Publishers = new RestCollection<Publisher>("http://localhost:31278/", "publisher", "hub");
                CreatePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Add(new Publisher()
                    {
                        Name = SelectedPublisher.Name,
                        Headquarters = SelectedPublisher.Headquarters,
                        Income = SelectedPublisher.Income
                        //Books = new HashSet<Book>(),
                        //Authors = new HashSet<Author>()
                    });
                });
                UpdatePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Update(SelectedPublisher);
                });
                DeletePublisherCommand = new RelayCommand(() =>
                {
                    Publishers.Delete(SelectedPublisher.Id);
                },
                () =>
                {
                    return SelectedPublisher != null;
                });
                SelectedPublisher = new Publisher();
            }
        }
    }
}
