 
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleTraderApp.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;

    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose()
        {

        }
    }
}
