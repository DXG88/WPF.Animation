using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Threading;
using WPF.Animation.Annotations;

namespace WPF.Animation.Clock
{
    /// <summary>
    /// Clock.xaml 的交互逻辑
    /// </summary>
    public partial class PageClock : Page, INotifyPropertyChanged
    {
        public PageClock()
        {
            InitializeComponent();
            this.DataContext = this;

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += UpdateIndicate;
            timer.Start();
        }

        private void UpdateIndicate(object? sender, EventArgs e)
        {
            SecondIndicate = DateTime.Now.Second * 6.0;
            MinIndicate = DateTime.Now.Minute * 6.0 + DateTime.Now.Second / 60.0 * 6;
            double hour = DateTime.Now.Hour > 12 ? (DateTime.Now.Hour - 12) : DateTime.Now.Hour;
            HoursIndicate = hour * 30.0 + DateTime.Now.Minute / 60.0 * 30;
            //Thread.Sleep(200);
        }

        private double _secondIndicate;
        public double SecondIndicate
        {
            get => _secondIndicate;
            set
            {
                _secondIndicate = value;
                OnPropertyChanged(nameof(SecondIndicate));
            }
        }

        private double _minIndicate;
        public double MinIndicate
        {
            get => _minIndicate;
            set
            {
                _minIndicate = value;
                OnPropertyChanged(nameof(MinIndicate));
            }
        }

        private double _hoursIndicate;
        public double HoursIndicate
        {
            get => _hoursIndicate;
            set
            {
                _hoursIndicate = value;
                OnPropertyChanged(nameof(HoursIndicate));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

