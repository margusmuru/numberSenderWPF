using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NumberSender
{
    public class MainWindowVM : INotifyPropertyChanged
    {

        private string _str1 = "";
        private string _str2 = "";
        private string _str3 = "";

        public string Str1
        {
            get { return _str1; }
            set { _str1 = value; OnPropertyChanged(propertyName: nameof(Str1)); }
            
        }

        public string Str2
        {
            get { return _str2; }
            set { _str2 = value; OnPropertyChanged(propertyName: nameof(Str2)); }

        }

        public string Str3
        {
            get { return _str3; }
            set { _str3 = value; OnPropertyChanged(propertyName: nameof(Str3)); }

        }

        private Thread _thr1;
        private Thread _thr2;
        private Thread _thr3;


        public MainWindowVM()
        {
            ThreadClass threadClass1 = new ThreadClass(this, 1, 1);
            _thr1 = new Thread(threadClass1.postNumber);
            //_thr2 = new Thread(secondNumber);
            //_thr3 = new Thread(thirdNumber);
            _thr1.Start();
            //_thr2.Start();
            //_thr3.Start();
        }


        public void SetNumberValue(int id, string text)
        {
            switch (id)
            {
                case 1:
                    Str1 = text;
                    break;
                case 2:
                    Str2 = text;
                    break;
                case 3:
                    Str3 = text;
                    break;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
