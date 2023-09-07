using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF.Animation.Clock
{
    /// <summary>
    /// ucClock.xaml 的交互逻辑
    /// </summary>
    public partial class ucClock : UserControl
    {

        private const double Radius = 180;
        private const double Center = 210;
        private readonly Point CenterPoint = new Point(Center, Center);

        public ucClock()
        {
            InitializeComponent();

            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        public void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            AdjustHands(now);
        }

        public void AdjustHands(DateTime time)
        {
            double hourAngle = (time.Hour % 12 + time.Minute / 60.0) * 30 - 90;
            double minuteAngle = time.Minute * 6 - 90;
            double secondAngle = time.Second * 6 - 90;

            SetHandPosition(hourAngle, Radius * 0.5, HourHand);
            SetHandPosition(minuteAngle, Radius * 0.75, MinuteHand);
            SetHandPosition(secondAngle, Radius, SecondHand);
        }

        private void SetHandPosition(double angle, double length, Line hand)
        {
            var position = PointOnCircle(length, angle, CenterPoint);
            hand.X1 = CenterPoint.X;
            hand.Y1 = CenterPoint.Y;
            hand.X2 = position.X;
            hand.Y2 = position.Y;
        }

        public Point PointOnCircle(double radius, double angleInDegrees, Point origin)
        {
            double x = radius * Math.Cos(angleInDegrees * Math.PI / 180F) + origin.X;
            double y = radius * Math.Sin(angleInDegrees * Math.PI / 180F) + origin.Y;

            return new Point(x, y);
        }
    }
}
