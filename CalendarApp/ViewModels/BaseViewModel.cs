using CalendarApp.Utils;
using System.ComponentModel;
using System.Windows;

namespace CalendarApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            navigation = Ioc.Get<NavigationService>();
        }

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected readonly NavigationService navigation;
    }
}
