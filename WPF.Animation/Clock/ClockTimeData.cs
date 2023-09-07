using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF.Animation.Annotations;

namespace WPF.Animation.Clock
{
    public class ClockTimeData : INotifyPropertyChanged
    {
        public ClockTimeData()
        {

        }

        double _second_indicate;
        public double second_indicate
        {
            set
            {
                _second_indicate = value;
                OnPropertyChanged(nameof(second_indicate));
            }
            get
            {
                return _second_indicate;
            }
        }

        double _minius_indicate;
        public double minius_indicate
        {
            set
            {
                _minius_indicate = value;
                OnPropertyChanged(nameof(minius_indicate));
            }
            get
            {
                return _minius_indicate;
            }

        }

        public double hours_indicate
        {
            set;
            get;
        }

        
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
