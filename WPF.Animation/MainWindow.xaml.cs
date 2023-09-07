using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WPF.Animation.Clock;


namespace WPF.Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DemoButton_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.From = 100; // 起始值
            widthAnimation.To = 300; // 结束值
            widthAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // 动画长度

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(widthAnimation);

            Storyboard.SetTarget(widthAnimation, DemoButton);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath(Button.WidthProperty));

            storyboard.Begin();
        }
    }
}