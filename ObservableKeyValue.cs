using System.ComponentModel;

namespace Expanding_Langton_s_And {
    public class ObservableKeyValue : INotifyPropertyChanged
    {
        private SColor key;
        private bool value;

        public SColor Key
        {
            get => key;
            set
            {
                key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public bool Value
        {
            get => value;
            set
            {
                this.value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}