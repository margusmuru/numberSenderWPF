using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;
using System.Net.Http;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace NumberSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static MainWindowVM _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainWindowVM(this);
            this.DataContext = _vm;
            
        }

        private void ButtonStartThread1_Click(object sender, RoutedEventArgs e)
        {
            int officeId = -1;
            int rndMin = -1;
            int rndMax = -1;
            Int32.TryParse(s: TextBoxOfficeIdThread1.Text, result: out officeId);
            Int32.TryParse(s: TextBoxRandomMinThread1.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread1.Text, result: out rndMax);
            if (officeId < 0)
            {
                TextBoxOfficeIdThread1.Background = Brushes.Red;
            }
            if (rndMin < 0)
            {
                TextBoxRandomMinThread1.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomMaxThread1.Background = Brushes.Red;
            }
            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin)
            {
                TextBoxOfficeIdThread1.Background = Brushes.Green;
                TextBoxRandomMinThread1.Background = Brushes.Green;
                TextBoxRandomMaxThread1.Background = Brushes.Green;
                _vm.StartThread(id: 1, officeId: officeId, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStartThread2_Click(object sender, RoutedEventArgs e)
        {
            int officeId = -1;
            int rndMin = -1;
            int rndMax = -1;
            Int32.TryParse(s: TextBoxOfficeIdThread2.Text, result: out officeId);
            Int32.TryParse(s: TextBoxRandomMinThread2.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread2.Text, result: out rndMax);
            if (officeId < 0)
            {
                TextBoxOfficeIdThread2.Background = Brushes.Red;
            }
            if (rndMin < 0)
            {
                TextBoxRandomMinThread2.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomMaxThread2.Background = Brushes.Red;
            }
            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin)
            {
                TextBoxOfficeIdThread2.Background = Brushes.Green;
                TextBoxRandomMinThread2.Background = Brushes.Green;
                TextBoxRandomMaxThread2.Background = Brushes.Green;
                _vm.StartThread(id: 2, officeId: officeId, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStartThread3_Click(object sender, RoutedEventArgs e)
        {
            int officeId = -1;
            int rndMin = -1;
            int rndMax = -1;
            Int32.TryParse(s: TextBoxOfficeIdThread3.Text, result: out officeId);
            Int32.TryParse(s: TextBoxRandomMinThread3.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread3.Text, result: out rndMax);
            if (officeId < 0)
            {
                TextBoxOfficeIdThread3.Background = Brushes.Red;
            }
            if (rndMin < 0)
            {
                TextBoxRandomMinThread3.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomMaxThread3.Background = Brushes.Red;
            }
            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin)
            {
                TextBoxOfficeIdThread3.Background = Brushes.Green;
                TextBoxRandomMinThread3.Background = Brushes.Green;
                TextBoxRandomMaxThread3.Background = Brushes.Green;
                _vm.StartThread(id: 3, officeId: officeId, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStopThread1_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThread(id: 1);

            TextBoxOfficeIdThread1.Background = Brushes.White;
            TextBoxRandomMinThread1.Background = Brushes.White;
            TextBoxRandomMaxThread1.Background = Brushes.White;
        }
        private void ButtonStopThread2_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThread(id: 2);

            TextBoxOfficeIdThread2.Background = Brushes.White;
            TextBoxRandomMinThread2.Background = Brushes.White;
            TextBoxRandomMaxThread2.Background = Brushes.White;
        }

        private void ButtonStopThread3_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThread(id: 3);

            TextBoxOfficeIdThread3.Background = Brushes.White;
            TextBoxRandomMinThread3.Background = Brushes.White;
            TextBoxRandomMaxThread3.Background = Brushes.White;
        }

        private void ButtonStartThread1T_Click(object sender, RoutedEventArgs e)
        {
            int rndMin = -1;
            int rndMax = -1;
            Int32.TryParse(s: TextBoxRandomMinThread1T.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread1T.Text, result: out rndMax);
            if (rndMin < 0)
            {
                TextBoxRandomMinThread1T.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomMaxThread1T.Background = Brushes.Red;
            }
            if (rndMin >= 0 && rndMax > rndMin)
            {
                TextBoxRandomMinThread1T.Background = Brushes.Green;
                TextBoxRandomMaxThread1T.Background = Brushes.Green;
                _vm.StartThreadT(id: 1, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStartThread2T_Click(object sender, RoutedEventArgs e)
        {
            int rndMin = -1;
            int rndMax = -1;
            Int32.TryParse(s: TextBoxRandomMinThread2T.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread2T.Text, result: out rndMax);
            if (rndMin < 0)
            {
                TextBoxRandomMinThread2T.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomMaxThread2T.Background = Brushes.Red;
            }
            if (rndMin >= 0 && rndMax > rndMin)
            {
                TextBoxRandomMinThread2T.Background = Brushes.Green;
                TextBoxRandomMaxThread2T.Background = Brushes.Green;
                _vm.StartThreadT(id: 2, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStartThread3T_Click(object sender, RoutedEventArgs e)
        {
            int rndMin = -1;
            int rndMax = -1;
            Int32.TryParse(s: TextBoxRandomMinThread3T.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread3T.Text, result: out rndMax);
            if (rndMin < 0)
            {
                TextBoxRandomMinThread3T.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomMaxThread3T.Background = Brushes.Red;
            }
            if (rndMin >= 0 && rndMax > rndMin)
            {
                TextBoxRandomMinThread3T.Background = Brushes.Green;
                TextBoxRandomMaxThread3T.Background = Brushes.Green;
                _vm.StartThreadT(id: 3, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStopThread1T_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThreadT(id: 1);

            TextBoxRandomMinThread1T.Background = Brushes.White;
            TextBoxRandomMaxThread1T.Background = Brushes.White;
        }

        private void ButtonStopThread2T_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThreadT(id: 2);

            TextBoxRandomMinThread2T.Background = Brushes.White;
            TextBoxRandomMaxThread2T.Background = Brushes.White;
        }

        private void ButtonStopThread3T_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThreadT(id: 3);

            TextBoxRandomMinThread3T.Background = Brushes.White;
            TextBoxRandomMaxThread3T.Background = Brushes.White;
        }

        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            string msg = "Kill all threads and exit?";
            MessageBoxResult result =
                MessageBox.Show(
                    messageBoxText: msg,
                    caption: "Confirm exit",
                    button: MessageBoxButton.YesNo,
                    icon: MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                // If user doesn't want to close, cancel closure
                e.Cancel = true;
            }
            else
            {
                _vm.StopThread(id: 1);
                _vm.StopThread(id: 2);
                _vm.StopThread(id: 3);
                _vm.StopThreadT(id: 1);
                _vm.StopThreadT(id: 2);
                _vm.StopThreadT(id: 3);
            }
        }

        private void ButtonDefaultUrl_Click(object sender, RoutedEventArgs e)
        {
            _vm.Url = "http://localhost:29594/api/takennumbers";
        }
    }
}
