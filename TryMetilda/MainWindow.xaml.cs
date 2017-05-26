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

namespace TryMetilda
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

        private void GoButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressButton.Visibility = Visibility.Visible;
            LongRunFunction();
            MessageBox.Show("Done!");
        }

        private void BusyButton_Click(object sender, RoutedEventArgs e)
        {
            BusyIndicator.IsBusy = true;
            LongRunFunction2();
        }

        private void LongRunFunction()
        {
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                Dispatcher.Invoke(() =>
                {
                    ProgressButton.Visibility = Visibility.Hidden;
                });
            });
        }

        private void LongRunFunction2()
        {
            Task.Run(() =>
            {
                System.Threading.Thread.Sleep(5000);
                Dispatcher.Invoke(() =>
                {
                    BusyIndicator.IsBusy = false;
                });
            });
        }
    }
}
