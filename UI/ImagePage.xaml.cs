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

namespace WPFDemo.UI
{
    /// <summary>
    /// Interaction logic for ImagePage.xaml
    /// </summary>
    public partial class ImagePage : Page {
        private bool IsDownInImage;
        private Point StartPoint;

        public ImagePage()
        {
            InitializeComponent();
        }

        private void ImageControl_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            IsDownInImage = true;
            StartPoint = e.GetPosition(PreImage);
        }

        private void ImageControl_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            IsDownInImage = false;
        }

        private void ImageControl_OnMouseMove(object sender, MouseEventArgs e) {
            if (IsDownInImage && e.LeftButton == MouseButtonState.Pressed) {
                Point endPoint = e.GetPosition(PreImage);
                if (PreImage.RenderTransform is TransformGroup transformGroup) {
                    if (transformGroup.Children[0] is TranslateTransform translateTransform) {
                        var x = endPoint.X - StartPoint.X;
                        var y = endPoint.Y - StartPoint.Y;
                        translateTransform.X = x;
                        translateTransform.Y = y;
                        // StartPoint = endPoint;
                    }

                }
            }
        }

        private void ImageControl_OnMouseWheel(object sender, MouseWheelEventArgs e) {
        }

        private void OpenBtn_OnClick(object sender, RoutedEventArgs e) {
        }
    }
}
