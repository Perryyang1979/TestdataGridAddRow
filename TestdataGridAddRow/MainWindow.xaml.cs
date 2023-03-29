using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static TestdataGridAddRow.MainWindow;

namespace TestdataGridAddRow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public ObservableCollection<Person> Persons { get; set; }
        private List<Person> _persons;
        public MainWindow()
        {
            InitializeComponent();
            

            _persons = new List<Person>();
            _persons.Add(new Person() { FirstName="Tom",LastName="Pett",MobileNumber="9876543"});
            _persons.Add(new Person() { FirstName = "Jack", LastName = "Jin", MobileNumber = "9876542" });
            _persons.Add(new Person() { FirstName = "Luo", LastName = "Luo", MobileNumber = "98763478" });

            Persons =new ObservableCollection<Person> (_persons);

            OnPropertyChanged(nameof(Persons));

            DataContext = this;

            CanUserAddRow = true;

            Persons.CollectionChanged += Persons_CollectionChanged;


        }

        private void Persons_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CanUserAddRow = CanUserAdd;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool CanUserAdd => Persons.Count < 6;

        private bool _canUserAddRow;
        public bool CanUserAddRow
        {
            get
            {
                return _canUserAddRow;
            }
            set
            {
                _canUserAddRow = value;

                OnPropertyChanged(nameof(CanUserAddRow));
            }
        }

        public class Person
        {
          
            public string FirstName { get;set; }    
            public string LastName { get;set; } = string.Empty;
            public string MobileNumber { get; set; }
        }
    }
}
