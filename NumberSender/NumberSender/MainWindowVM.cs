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
        private readonly MainWindow _mainWindow;

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

        private string _result1;
        public string Result1
        {
            get { return _result1; }
            set
            {
                _result1 = value + _result1;
                OnPropertyChanged(propertyName: nameof(Result1));
            }
        }

        private string _result2;
        public string Result2
        {
            get { return _result2; }
            set { _result2 = value; OnPropertyChanged(propertyName: nameof(Result2)); }
        }

        private string _result3;
        public string Result3
        {
            get { return _result3; }
            set { _result3 = value; OnPropertyChanged(propertyName: nameof(Result3)); }
        }

        private string _sleepingThread1;
        public string SleepingThread1
        {
            get { return _sleepingThread1; }
            set { _sleepingThread1 = value; OnPropertyChanged(propertyName: nameof(SleepingThread1)); }
        }

        private string _sleepingThread2;
        public string SleepingThread2
        {
            get { return _sleepingThread2; }
            set { _sleepingThread2 = value; OnPropertyChanged(propertyName: nameof(SleepingThread2)); }
        }

        private string _sleepingThread3;
        public string SleepingThread3
        {
            get { return _sleepingThread3; }
            set { _sleepingThread3 = value; OnPropertyChanged(propertyName: nameof(SleepingThread3)); }
        }


        private Thread _thr1;
        private Thread _thr2;
        private Thread _thr3;


        public MainWindowVM(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

        }

        public void StartThread(int id, int officeId, int rndMin, int rndMax)
        {
            switch (id)
            {
                case 1:
                    _mainWindow.ButtonStartThread1.IsEnabled = false;
                    ThreadClass threadClass1 = new ThreadClass(vm: this, num: 1, office: officeId, rndStart: rndMin, rndStop: rndMax);
                    _thr1 = new Thread(start: threadClass1.PostNumber);
                    _thr1.Start();
                    _mainWindow.TextBoxDisplayNumber1.Text = "S";
                    break;
                case 2:
                    ThreadClass threadClass2 = new ThreadClass(vm: this, num: 2, office: officeId, rndStart: rndMin, rndStop: rndMax);
                    _thr1 = new Thread(start: threadClass2.PostNumber);
                    _thr1.Start();
                    _mainWindow.TextBoxDisplayNumber2.Text = "S";
                    break;
                case 3:
                    ThreadClass threadClass3 = new ThreadClass(vm: this, num: 3, office: officeId, rndStart: rndMin, rndStop: rndMax);
                    _thr1 = new Thread(start: threadClass3.PostNumber);
                    _thr1.Start();
                    _mainWindow.TextBoxDisplayNumber3.Text = "S";
                    break;
            }
        }

        public void StopThread(int id)
        {
            switch (id)
            {
                case 1:
                    if (_thr1 != null && _thr1.IsAlive)
                    {
                        _thr1.Abort();
                        _mainWindow.ButtonStartThread1.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber1.Text = "X";
                    }
                    break;
                case 2:
                    if (_thr2 != null && _thr2.IsAlive)
                    {
                        _thr2.Abort();
                        _mainWindow.TextBoxDisplayNumber2.Text = "X";
                    }
                    break;
                case 3:
                    if (_thr3 != null && _thr3.IsAlive)
                    {
                        _thr3.Abort();
                        _mainWindow.TextBoxDisplayNumber3.Text = "X";
                    }
                    break;
            }
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

        public void SetNumberResult(int id, string text)
        {
            switch (id)
            {
                case 1:
                    Result1 = text;
                    break;
                case 2:
                    Result2 = text;
                    break;
                case 3:
                    Result3 = text;
                    break;
            }
        }

        public void SetSleepingTime(int id, string text)
        {
            switch (id)
            {
                case 1:
                    SleepingThread1 = text;
                    break;
                case 2:
                    SleepingThread2 = text;
                    break;
                case 3:
                    SleepingThread3 = text;
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
