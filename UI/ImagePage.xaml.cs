using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace WPFDemo.UI {
    /// <summary>
    /// Interaction logic for ImagePage.xaml
    /// </summary>
    public partial class ImagePage : Page {
        private bool IsDownInImage;
        private Point StartPoint;
        private double mScaleValue = 1.0;

        public ImagePage() {
            InitializeComponent();
        }

        private void ImageControl_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            IsDownInImage = true;
            StartPoint = e.GetPosition(sender as UIElement);
        }

        private void ImageControl_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            IsDownInImage = false;
        }

        private void ImageControl_OnMouseMove(object sender, MouseEventArgs e) {
            if (IsDownInImage && e.LeftButton == MouseButtonState.Pressed) {
                Point endPoint = e.GetPosition(sender as UIElement);
                if (PreImage.RenderTransform is TransformGroup transformGroup) {
                    if (transformGroup.Children[0] is TranslateTransform translateTransform) {
                        var x = endPoint.X - StartPoint.X;
                        var y = endPoint.Y - StartPoint.Y;
                        translateTransform.X += x;
                        translateTransform.Y += y;
                        StartPoint = endPoint;
                    }
                }
            }
        }

        private void ImageControl_OnMouseWheel(object sender, MouseWheelEventArgs e) {
            if ((mScaleValue <= 1.0 && e.Delta < 0) || mScaleValue >= 2.0 && e.Delta > 0) {
                return;
            }

            if (PreImage.RenderTransform is TransformGroup transformGroup) {
                if (transformGroup.Children[1] is ScaleTransform scaleTransform) {
                    mScaleValue += e.Delta/1000.0;
                    if (mScaleValue < 1.0) {
                        mScaleValue = 1.0;
                    }

                    if (mScaleValue > 2.0) {
                        mScaleValue = 2.0;
                    }
                    Point point = e.GetPosition(sender as UIElement);
                    scaleTransform.CenterX = point.X;
                    scaleTransform.CenterY = point.Y;
                    scaleTransform.ScaleX = mScaleValue;
                    scaleTransform.ScaleY = mScaleValue;
                }
            }
        }

        private void OpenBtn_OnClick(object sender, RoutedEventArgs e) {
        }

        private void RestBtn_OnClick(object sender, RoutedEventArgs e) {
            if (PreImage.RenderTransform is TransformGroup transformGroup) {
                if (transformGroup.Children[0] is TranslateTransform translateTransform) {
                    translateTransform.X = 0;
                    translateTransform.Y = 0;
                    StartPoint = new Point(0, 0);
                }

                if (transformGroup.Children[1] is ScaleTransform scaleTransform) {
                    scaleTransform.ScaleX = 1;
                    scaleTransform.ScaleY = 1;
                }
            }
        }
    }
}