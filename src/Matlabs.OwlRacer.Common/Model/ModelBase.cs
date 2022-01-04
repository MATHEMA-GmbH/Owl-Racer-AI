using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Matlabs.OwlRacer.Common.Model
{
    public abstract class ModelBase : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if(EqualityComparer<T>.Default.Equals(property, value)) { return; }

            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
            property = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
