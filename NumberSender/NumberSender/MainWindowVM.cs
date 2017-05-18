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
            set { _result1 = value; OnPropertyChanged(propertyName: nameof(Result1));}
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

        private int _officeId1;
        public int OfficeId1
        {
            get { return _officeId1; }
            set { _officeId1 = value; }
        }

        private int _officeId2;
        public int OfficeId2
        {
            get { return _officeId2; }
            set { _officeId2 = value; }
        }

        private int _officeId3;
        public int OfficeId3
        {
            get { return _officeId3; }
            set { _officeId3 = value; }
        }

        private int _rndStartThread1;
        public int RndStartThread1
        {
            get { return _rndStartThread1; }
            set { _rndStartThread1 = value; }
        }

        private int _rndStopThread1;
        public int RndStopThread1
        {
            get { return _rndStopThread1; }
            set { _rndStopThread1 = value; }
        }

        private int _rndStartThread2;
        public int RndStartThread2
        {
            get { return _rndStartThread2; }
            set { _rndStartThread2 = value; }
        }

        private int _rndStopThread2;
        public int RndStopThread2
        {
            get { return _rndStopThread2; }
            set { _rndStopThread2 = value; }
        }

        private int _rndStartThread3;
        public int RndStartThread3
        {
            get { return _rndStartThread3; }
            set { _rndStartThread3 = value; }
        }

        private int _rndStopThread3;
        public int RndStopThread3
        {
            get { return _rndStopThread3; }
            set { _rndStopThread3 = value; }
        }


        private Thread _thr1;
        private Thread _thr2;
        private Thread _thr3;


        public MainWindowVM(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void StartThread(int id)
        {
            switch (id)
            {
                case 1:
                    _mainWindow.ButtonStartThread1.IsEnabled = false;
                    ThreadClass threadClass1 = new ThreadClass(this, 1, _officeId1, RndStartThread1, RndStopThread1);
                    _thr1 = new Thread(threadClass1.postNumber);
                    _thr1.Start();
                    _mainWindow.TextBoxDisplayNumber1.Text = "S";
                    _mainWindow.TextBlockResult1.Text = "";
                    break;
                case 2:
                    ThreadClass threadClass2 = new ThreadClass(this, 2, _officeId2, RndStartThread2, RndStopThread2);
                    _thr1 = new Thread(threadClass2.postNumber);
                    _thr1.Start();
                    _mainWindow.TextBoxDisplayNumber2.Text = "S";
                    _mainWindow.TextBlockResult1.Text = "";
                    break;
                case 3:
                    ThreadClass threadClass3 = new ThreadClass(this, 3, _officeId2, RndStartThread3, RndStopThread3);
                    _thr1 = new Thread(threadClass3.postNumber);
                    _thr1.Start();
                    _mainWindow.TextBoxDisplayNumber3.Text = "S";
                    _mainWindow.TextBlockResult1.Text = "";
                    break;
            }
        }

        public void StopThread(int id)
        {
            switch (id)
            {
                case 1:
                    if (_thr1.IsAlive)
                    {
                        _thr1.Abort();
                        _mainWindow.ButtonStartThread1.IsEnabled = true;
                        _mainWindow.TextBoxDisplayNumber1.Text = "X";
                    }
                    break;
                case 2:
                    if (_thr2.IsAlive)
                    {
                        _thr2.Abort();
                        _mainWindow.TextBoxDisplayNumber2.Text = "X";
                    }
                    break;
                case 3:
                    if (_thr3.IsAlive)
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
                    Result2 = text;
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
