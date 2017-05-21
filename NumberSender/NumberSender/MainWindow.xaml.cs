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

            int numType = -1;
            int numMin = -1;
            int numMax = -1;

            Int32.TryParse(s: TextBoxOfficeIdThread1.Text, result: out officeId);
            Int32.TryParse(s: TextBoxRandomMinThread1.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread1.Text, result: out rndMax);

            Int32.TryParse(s: TextBoxNumtypeThread1.Text, result: out numType);
            Int32.TryParse(s: TextBoxNumberMinThread1.Text, result: out numMin);
            Int32.TryParse(s: TextBoxNumberMaxThread1.Text, result: out numMax);

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

            if (numType < 0)
            {
                TextBoxNumtypeThread1.Background = Brushes.Red;
            }
            if (numMin < 0)
            {
                TextBoxNumberMinThread1.Background = Brushes.Red;
            }
            if (numMax <= numMin)
            {
                TextBoxNumberMaxThread1.Background = Brushes.Red;
            }

            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin && numType >= 0 && numMin >= 0 && numMax > numMin)
            {
                TextBoxOfficeIdThread1.Background = Brushes.Green;
                TextBoxRandomMinThread1.Background = Brushes.Green;
                TextBoxRandomMaxThread1.Background = Brushes.Green;
                TextBoxNumtypeThread1.Background = Brushes.Green;
                TextBoxNumberMinThread1.Background = Brushes.Green;
                TextBoxNumberMaxThread1.Background = Brushes.Green;
                ButtonStartThread1.IsEnabled = true;
                _vm.StartThread(
                    id: 1, 
                    officeId: officeId, 
                    rndMin: rndMin, 
                    rndMax: rndMax, 
                    numType: numType,
                    numMin: numMin,
                    numMax: numMax
                    );
            }
        }

        private void ButtonStartThread2_Click(object sender, RoutedEventArgs e)
        {
            int officeId = -1;
            int rndMin = -1;
            int rndMax = -1;

            int numType = -1;
            int numMin = -1;
            int numMax = -1;

            Int32.TryParse(s: TextBoxOfficeIdThread2.Text, result: out officeId);
            Int32.TryParse(s: TextBoxRandomMinThread2.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread2.Text, result: out rndMax);

            Int32.TryParse(s: TextBoxNumtypeThread2.Text, result: out numType);
            Int32.TryParse(s: TextBoxNumberMinThread2.Text, result: out numMin);
            Int32.TryParse(s: TextBoxNumberMaxThread2.Text, result: out numMax);

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

            if (numType < 0)
            {
                TextBoxNumtypeThread2.Background = Brushes.Red;
            }
            if (numMin < 0)
            {
                TextBoxNumberMinThread2.Background = Brushes.Red;
            }
            if (numMax <= numMin)
            {
                TextBoxNumberMaxThread2.Background = Brushes.Red;
            }

            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin && numType >= 0 && numMin >= 0 && numMax > numMin)
            {
                TextBoxOfficeIdThread2.Background = Brushes.Green;
                TextBoxRandomMinThread2.Background = Brushes.Green;
                TextBoxRandomMaxThread2.Background = Brushes.Green;
                TextBoxNumtypeThread2.Background = Brushes.Green;
                TextBoxNumberMinThread2.Background = Brushes.Green;
                TextBoxNumberMaxThread2.Background = Brushes.Green;
                ButtonStartThread2.IsEnabled = true;
                _vm.StartThread(
                    id: 2,
                    officeId: officeId,
                    rndMin: rndMin,
                    rndMax: rndMax,
                    numType: numType,
                    numMin: numMin,
                    numMax: numMax
                );
            }
        }

        private void ButtonStartThread3_Click(object sender, RoutedEventArgs e)
        {
            int officeId = -1;
            int rndMin = -1;
            int rndMax = -1;

            int numType = -1;
            int numMin = -1;
            int numMax = -1;

            Int32.TryParse(s: TextBoxOfficeIdThread3.Text, result: out officeId);
            Int32.TryParse(s: TextBoxRandomMinThread3.Text, result: out rndMin);
            Int32.TryParse(s: TextBoxRandomMaxThread3.Text, result: out rndMax);

            Int32.TryParse(s: TextBoxNumtypeThread3.Text, result: out numType);
            Int32.TryParse(s: TextBoxNumberMinThread3.Text, result: out numMin);
            Int32.TryParse(s: TextBoxNumberMaxThread3.Text, result: out numMax);

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

            if (numType < 0)
            {
                TextBoxNumtypeThread3.Background = Brushes.Red;
            }
            if (numMin < 0)
            {
                TextBoxNumberMinThread3.Background = Brushes.Red;
            }
            if (numMax <= numMin)
            {
                TextBoxNumberMaxThread3.Background = Brushes.Red;
            }

            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin && numType >= 0 && numMin >= 0 && numMax > numMin)
            {
                TextBoxOfficeIdThread3.Background = Brushes.Green;
                TextBoxRandomMinThread3.Background = Brushes.Green;
                TextBoxRandomMaxThread3.Background = Brushes.Green;
                TextBoxNumtypeThread3.Background = Brushes.Green;
                TextBoxNumberMinThread3.Background = Brushes.Green;
                TextBoxNumberMaxThread3.Background = Brushes.Green;
                ButtonStartThread3.IsEnabled = true;
                _vm.StartThread(
                    id: 3,
                    officeId: officeId,
                    rndMin: rndMin,
                    rndMax: rndMax,
                    numType: numType,
                    numMin: numMin,
                    numMax: numMax
                );
            }
        }

        private void ButtonStopThread1_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThread(id: 1);

            TextBoxOfficeIdThread1.Background = Brushes.White;
            TextBoxRandomMinThread1.Background = Brushes.White;
            TextBoxRandomMaxThread1.Background = Brushes.White;
            TextBoxNumtypeThread1.Background = Brushes.White;
            TextBoxNumberMinThread1.Background = Brushes.White;
            TextBoxNumberMaxThread1.Background = Brushes.White;
            ButtonStartThread1.IsEnabled = false;
        }

        private void ButtonStopThread2_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThread(id: 2);

            TextBoxOfficeIdThread2.Background = Brushes.White;
            TextBoxRandomMinThread2.Background = Brushes.White;
            TextBoxRandomMaxThread2.Background = Brushes.White;
            TextBoxNumtypeThread2.Background = Brushes.White;
            TextBoxNumberMinThread2.Background = Brushes.White;
            TextBoxNumberMaxThread2.Background = Brushes.White;
            ButtonStartThread2.IsEnabled = false;
        }

        private void ButtonStopThread3_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThread(id: 3);

            TextBoxOfficeIdThread3.Background = Brushes.White;
            TextBoxRandomMinThread3.Background = Brushes.White;
            TextBoxRandomMaxThread3.Background = Brushes.White;
            TextBoxNumtypeThread3.Background = Brushes.White;
            TextBoxNumberMinThread3.Background = Brushes.White;
            TextBoxNumberMaxThread3.Background = Brushes.White;
            ButtonStartThread3.IsEnabled = false;
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
                ButtonStartThread1T.IsEnabled = true;
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
                ButtonStartThread2T.IsEnabled = true;
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
                ButtonStartThread3T.IsEnabled = true;
                _vm.StartThreadT(id: 3, rndMin: rndMin, rndMax: rndMax);
            }
        }

        private void ButtonStopThread1T_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThreadT(id: 1);

            TextBoxRandomMinThread1T.Background = Brushes.White;
            TextBoxRandomMaxThread1T.Background = Brushes.White;
            ButtonStartThread1T.IsEnabled = false;
        }

        private void ButtonStopThread2T_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThreadT(id: 2);

            TextBoxRandomMinThread2T.Background = Brushes.White;
            TextBoxRandomMaxThread2T.Background = Brushes.White;
            ButtonStartThread2T.IsEnabled = false;
        }

        private void ButtonStopThread3T_Click(object sender, RoutedEventArgs e)
        {
            _vm.StopThreadT(id: 3);

            TextBoxRandomMinThread3T.Background = Brushes.White;
            TextBoxRandomMaxThread3T.Background = Brushes.White;
            ButtonStartThread3T.IsEnabled = false;
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
