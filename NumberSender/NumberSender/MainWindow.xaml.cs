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
            Int32.TryParse(TextBoxOfficeIdThread1.Text, out officeId);
            Int32.TryParse(TextBoxRandomStartThread1.Text, out rndMin);
            Int32.TryParse(TextBoxRandomEndThread1.Text, out rndMax);
            if (officeId < 0)
            {
                TextBoxOfficeIdThread1.Background = Brushes.Red;
            }
            if (rndMin < 0)
            {
                TextBoxRandomStartThread1.Background = Brushes.Red;
            }
            if (rndMax <= rndMin)
            {
                TextBoxRandomEndThread1.Background = Brushes.Red;
            }
            if (officeId >= 0 && rndMin >= 0 && rndMax > rndMin)
            {
                _vm.StartThread(1);
            }
        }

        private void ButtonStopThread1_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
