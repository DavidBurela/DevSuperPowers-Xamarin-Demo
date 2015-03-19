using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DevSuperPowersDemo.Models;
using Xamarin.Forms;

namespace DevSuperPowersDemo.ViewModels
{
    public class BetterViewModel : INotifyPropertyChanged
    {
        private string _greeting;
        private int _widgetCount;
        private bool _isBusy;

        public string Greeting
        {
            get { return _greeting; }
            set
            {
                _greeting = value;
                OnPropertyChanged("Greeting");
            }
        }

        public string Name { get; set; }

        public int WidgetCount
        {
            get { return _widgetCount; }
            set
            {
                _widgetCount = value;
                OnPropertyChanged("WidgetCount");
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("NotIsBusy");
            }
        }

        public bool NotIsBusy
        {
            get { return !IsBusy; }
        }

        public ObservableCollection<Animal> Animals { get; set; }

        public ICommand SayHelloCommand { get; set; }
        public ICommand CreateWidgetCommand { get; set; }

        public BetterViewModel()
        {
            Greeting = "Welcome to Xamarin Forms from MVVM!";
            Name = "enter name";
            Animals = new ObservableCollection<Animal>
            {
                new Animal{Name = "Fluffy", Age = 2, Color = "White"},
                new Animal{Name = "Spot", Age = 4, Color = "Black & White"},
                new Animal{Name = "Rex", Age = 6, Color = "Red"}
            };

            SayHelloCommand = new Command(SayHello);
            CreateWidgetCommand = new Command(CreateWidget);
        }

        private async void CreateWidget()
        {
            // Create a widget. By calling the backend Widget web service
            IsBusy = true;
            await Task.Delay(2000);

            WidgetCount += 1;
            IsBusy = false;
        }

        public void SayHello()
        {
            Greeting = "Hello " + Name;
        }

        #region INPC
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
