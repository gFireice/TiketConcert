using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketConcert.Class
{
    public class Filter : INotifyPropertyChanged
    {
        private static string _textFilter;
        public static string TextFilter
        {
            get => _textFilter;
            set
            {
                if (_textFilter != value)
                {
                    _textFilter = value;
                    OnStaticPropertyChanged(nameof(TextFilter));
                }
            }
        }

        public static event PropertyChangedEventHandler StaticPropertyChanged;

        private static void OnStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
