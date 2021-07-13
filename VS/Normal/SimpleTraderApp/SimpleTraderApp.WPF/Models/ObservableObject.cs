using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SimpleTraderApp.WPF.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
