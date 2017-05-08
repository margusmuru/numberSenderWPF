using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NumberSender
{
    public class MainWindowVM : INotifyPropertyChanged
    {

        private string _str1 = "";
        private string _str2 = "";
        private string _str3 = "";

        public string str1
        {
            get { return _str1; }
            set { _str1 = value; OnPropertyChanged(nameof(str1)); }
            
        }

        public string str2
        {
            get { return _str2; }
            set { _str2 = value; OnPropertyChanged(nameof(str2)); }

        }

        public string str3
        {
            get { return _str3; }
            set { _str3 = value; OnPropertyChanged(nameof(str3)); }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
