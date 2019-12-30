using System.Windows;
using WPFDemo.StyleOrTemplate;

namespace WPFDemo {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void CustomStyle_OnClick(object sender, RoutedEventArgs e) {
            SliderWindow window = new SliderWindow();
            window.ShowDialog();
        }
    }
}
