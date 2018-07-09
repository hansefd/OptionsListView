using System.ComponentModel;
using System.Runtime.CompilerServices;
using Options.Core.Annotations;

namespace Options.Core
{
    public class Option : INotifyPropertyChanged
    {
        private bool _isSelected;

        public Option(string title, object tag = default(object))
        {
            Title = title;
            Tag   = tag;
        }

        public string Title { get; }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value) 
                    return;

                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public object Tag { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}