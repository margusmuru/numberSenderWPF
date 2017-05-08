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

namespace NumberSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thr1 = new Thread(firstNumber);
        Thread thr2 = new Thread(secondNumber);
        Thread thr3 = new Thread(thirdNumber);


        public static MainWindowVM _vm = new MainWindowVM();

        private static readonly HttpClient client = new HttpClient();

        private static TakenNumberController _takenNumber = new TakenNumberController();

        private static Dictionary<string, string> values1;

        private static Dictionary<string, string> values2;

        private static Dictionary<string, string> values3;



        public MainWindow()
        {
            InitializeComponent();
            thr1.Start();
            thr2.Start();
            thr3.Start();
            this.DataContext = _vm;
            
        }




        public static void firstNumber()
        {
            int i = 0;
            while (true)
            {
                if (i == 300)
                {
                    i = 0;
                }
                else
                {
                    i++;

                }
                Thread.Sleep(20000);
                _vm.str1 = i.ToString();
                Console.WriteLine(_vm.str1);
                values1 = new Dictionary<string, string>
                {
                    {"number", _vm.str1},
                    {"officeId", "1"},
                };
                _takenNumber.Post(values1);
            }

        }



        public static void secondNumber()
        {
            int i = 0;
            while (true)
            {
                if (i == 600)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
               
                Thread.Sleep(10000);
                _vm.str2 = i.ToString();
                Console.WriteLine(_vm.str2);
                values2 = new Dictionary<string, string>
                {
                    {"number", _vm.str2},
                    {"officeId", "2"},
                };
                _takenNumber.Post(values2);
            }

        }

        public static void thirdNumber()
        {
            int i = 0;
            while (true)
            {
                if (i == 100)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                Thread.Sleep(2000);
                _vm.str3 = i.ToString();
                Console.WriteLine(_vm.str3);
                values3 = new Dictionary<string, string>
                {
                    {"number", _vm.str3},
                    {"officeId", "3"},
                };
                _takenNumber.Post(values3);
            }

        }


    }
}
