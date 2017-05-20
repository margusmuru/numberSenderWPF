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

        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                OnPropertyChanged(propertyName: nameof(Url));
            }
        }

        public string Str1
        {
            get => _str1;
            set { _str1 = value; OnPropertyChanged(propertyName: nameof(Str1)); } 
        }

        public string Str2
        {
            get => _str2;
            set { _str2 = value; OnPropertyChanged(propertyName: nameof(Str2)); }
        }

        public string Str3
        {
            get => _str3;
            set { _str3 = value; OnPropertyChanged(propertyName: nameof(Str3)); }
        }

        private string _str1T = "";
        private string _str2T = "";
        private string _str3T = "";

        public string Str1T
        {
            get => _str1T;
            set { _str1T = value; OnPropertyChanged(propertyName: nameof(Str1T)); }
        }

        public string Str2T
        {
            get => _str2T;
            set { _str2T = value; OnPropertyChanged(propertyName: nameof(Str2T)); }
        }

        public string Str3T
        {
            get => _str3T;
            set { _str3T = value; OnPropertyChanged(propertyName: nameof(Str3T)); }
        }

        private string _result1;
        public string Result1
        {
            get => _result1;
            set
            {
                _result1 = value + _result1;
                OnPropertyChanged(propertyName: nameof(Result1));
            }
        }

        private string _result2;
        public string Result2
        {
            get => _result2;
            set {
                _result2 = value + _result2;
                OnPropertyChanged(propertyName: nameof(Result2));
            }
        }

        private string _result3;
        public string Result3
        {
            get => _result3;
            set
            {
                _result3 = value + _result3;
                OnPropertyChanged(propertyName: nameof(Result3));
            }
        }

        private string _sleepingThread1;
        public string SleepingThread1
        {
            get => _sleepingThread1;
            set { _sleepingThread1 = value; OnPropertyChanged(propertyName: nameof(SleepingThread1)); }
        }

        private string _sleepingThread2;
        public string SleepingThread2
        {
            get => _sleepingThread2;
            set { _sleepingThread2 = value; OnPropertyChanged(propertyName: nameof(SleepingThread2)); }
        }

        private string _sleepingThread3;
        public string SleepingThread3
        {
            get => _sleepingThread3;
            set { _sleepingThread3 = value; OnPropertyChanged(propertyName: nameof(SleepingThread3)); }
        }

        private string _sleepingThread1T;
        public string SleepingThread1T
        {
            get => _sleepingThread1T;
            set { _sleepingThread1T = value; OnPropertyChanged(propertyName: nameof(SleepingThread1T)); }
        }

        private string _sleepingThread2T;
        public string SleepingThread2T
        {
            get => _sleepingThread2T;
            set { _sleepingThread2T = value; OnPropertyChanged(propertyName: nameof(SleepingThread2T)); }
        }

        private string _sleepingThread3T;
        public string SleepingThread3T
        {
            get => _sleepingThread3T;
            set { _sleepingThread3T = value; OnPropertyChanged(propertyName: nameof(SleepingThread3T)); }
        }


        private Thread _thr1;
        private Thread _thr2;
        private Thread _thr3;
        private Thread _thr1T;
        private Thread _thr2T;
        private Thread _thr3T;

        public List<TakenNumberDTO> Thread1Dtos;
        public List<TakenNumberDTO> Thread2Dtos;
        public List<TakenNumberDTO> Thread3Dtos;

        public MainWindowVM(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            Thread1Dtos = new List<TakenNumberDTO>();
            Thread2Dtos = new List<TakenNumberDTO>();
            Thread3Dtos = new List<TakenNumberDTO>();
            Url = "http://localhost:29594/api/takennumbers";
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
                    _mainWindow.ButtonStartThread2.IsEnabled = false;
                    ThreadClass threadClass2 = new ThreadClass(vm: this, num: 2, office: officeId, rndStart: rndMin, rndStop: rndMax);
                    _thr2 = new Thread(start: threadClass2.PostNumber);
                    _thr2.Start();
                    _mainWindow.TextBoxDisplayNumber2.Text = "S";
                    break;
                case 3:
                    _mainWindow.ButtonStartThread3.IsEnabled = false;
                    ThreadClass threadClass3 = new ThreadClass(vm: this, num: 3, office: officeId, rndStart: rndMin, rndStop: rndMax);
                    _thr3 = new Thread(start: threadClass3.PostNumber);
                    _thr3.Start();
                    _mainWindow.TextBoxDisplayNumber3.Text = "S";
                    break;
            }
        }

        public void StartThreadT(int id, int rndMin, int rndMax)
        {
            switch (id)
            {
                case 1:
                    _mainWindow.ButtonStartThread1T.IsEnabled = false;
                    ThreadClassT threadClass1T = new ThreadClassT(vm: this, threadNum: 1, rndMin: rndMin, rndMax: rndMax);
                    _thr1T = new Thread(start: threadClass1T.PostNumber);
                    _thr1T.Start();
                    _mainWindow.TextBoxDisplayNumber1T.Text = "S";
                    break;
                case 2:
                    _mainWindow.ButtonStartThread2T.IsEnabled = false;
                    ThreadClassT threadClass2T = new ThreadClassT(vm: this, threadNum: 2, rndMin: rndMin, rndMax: rndMax);
                    _thr2T = new Thread(start: threadClass2T.PostNumber);
                    _thr2T.Start();
                    _mainWindow.TextBoxDisplayNumber2T.Text = "S";
                    break;
                case 3:
                    _mainWindow.ButtonStartThread3T.IsEnabled = false;
                    ThreadClassT threadClass3T = new ThreadClassT(vm: this, threadNum: 3, rndMin: rndMin, rndMax: rndMax);
                    _thr3T = new Thread(start: threadClass3T.PostNumber);
                    _thr3T.Start();
                    _mainWindow.TextBoxDisplayNumber3T.Text = "S";
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
                        SleepingThread1 = "";
                        _mainWindow.ButtonStartThread1.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber1.Text = "X";
                    }
                    break;
                case 2:
                    if (_thr2 != null && _thr2.IsAlive)
                    {
                        _thr2.Abort();
                        SleepingThread2 = "";
                        _mainWindow.ButtonStartThread2.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber2.Text = "X";
                    }
                    break;
                case 3:
                    if (_thr3 != null && _thr3.IsAlive)
                    {
                        _thr3.Abort();
                        SleepingThread3 = "";
                        _mainWindow.ButtonStartThread3.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber3.Text = "X";
                    }
                    break;
            }
        }

        public void StopThreadT(int id)
        {
            switch (id)
            {
                case 1:
                    if (_thr1T != null && _thr1T.IsAlive)
                    {
                        _thr1T.Abort();
                        SleepingThread1T = "";
                        _mainWindow.ButtonStartThread1T.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber1T.Text = "X";
                    }
                    break;
                case 2:
                    if (_thr2T != null && _thr2T.IsAlive)
                    {
                        _thr2T.Abort();
                        SleepingThread2T = "";
                        _mainWindow.ButtonStartThread2T.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber2T.Text = "X";
                    }
                    break;
                case 3:
                    if (_thr3T != null && _thr3T.IsAlive)
                    {
                        _thr3T.Abort();
                        SleepingThread3T = "";
                        _mainWindow.ButtonStartThread3T.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber3T.Text = "X";
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

        public void SetNumberValueT(int id, string text)
        {
            switch (id)
            {
                case 1:
                    Str1T = text;
                    break;
                case 2:
                    Str2T = text;
                    break;
                case 3:
                    Str3T = text;
                    break;
            }
        }

        public void SetNumberResult(int id, string text, TakenNumberDTO dto)
        {
            switch (id)
            {
                case 1:
                    Result1 = text;
                    if (dto != null)
                    {
                        Thread1Dtos.Add(item: dto);
                    }
                    break;
                case 2:
                    Result2 = text;
                    if (dto != null)
                    {
                        Thread2Dtos.Add(item: dto);
                    }
                    break;
                case 3:
                    Result3 = text;
                    if (dto != null)
                    {
                        Thread3Dtos.Add(item: dto);
                    }
                    break;
            }
        }

        public void SetNumberResultT(int id, string text)
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

        public void SetSleepingTimeT(int id, string text)
        {
            switch (id)
            {
                case 1:
                    SleepingThread1T = text;
                    break;
                case 2:
                    SleepingThread2T = text;
                    break;
                case 3:
                    SleepingThread3T = text;
                    break;
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(sender: this, e: new PropertyChangedEventArgs(propertyName: propertyName));
        }
    }
}
