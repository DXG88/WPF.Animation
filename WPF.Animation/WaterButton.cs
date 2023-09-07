using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF.Animation
{

    public class WaterButton : Button
    {
        static WaterButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WaterButton), new FrameworkPropertyMetadata(typeof(WaterButton)));
        }

        public WaterButton()
        {
            // Button的Click事件的处理方    MouseLeftButtonDown-》Click    e.Handler=true;
            // 隧道  冒泡
            this.PreviewMouseLeftButtonDown += WaterButton_MouseLeftButtonDown;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        private void WaterButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            var ellipse = this.GetTemplateChild("ellipse") as EllipseGeometry;
            //Template.FindName

            if (ellipse != null)
                ellipse.Center = point;

        }
    }
}
