using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace HFlash.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }




        #region FlatNumber
        private string _FlatNumber;
        public string FlatNumber
        {
            get => _FlatNumber ?? "0";
            set
            {
                _FlatNumber = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region IPAddress
        private string _IPAddress;
        public string IPAddress
        {
            get => _IPAddress ?? "178.78.60.195";
            set
            {
                _IPAddress = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region NumberColor
        private int _NumberColor;
        public int NumberColor
        {
            get => _NumberColor;
            set
            {
                _NumberColor = value;
                switch (value)
                {
                    case 0:
                        BackgroundColor = new SolidColorBrush(Colors.Black);
                        break;
                    case 1:
                        BackgroundColor = new SolidColorBrush(Colors.White);
                        break;
                }
                OnPropertyChanged();
            }
        }
        #endregion

        #region BackgroundColor
        private SolidColorBrush _BackgroundColor;
        public SolidColorBrush BackgroundColor
        {
            get => _BackgroundColor;
            set
            {
                _BackgroundColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        //#region Command TryToConnect
        //private RelayCommand _TryToConnect;
        //public RelayCommand TryToConnect
        //{
        //    get
        //    {
        //        return _TryToConnect ??
        //        (_TryToConnect = new RelayCommand(obj =>
        //        {
        //            Task.Factory.StartNew(() =>
        //            {
        //                while (true)
        //                {
        //                    IsEnableElements = false;
        //                    try
        //                    {
        //                        string result = new HttpClient().GetAsync("http://" + IPAddress + ":5000/api/Flats/" + FlatNumber).Result.Content.ReadAsStringAsync().Result;
        //                        if (result.Equals("true"))
        //                        {
        //                            BackgroundColor = new SolidColorBrush(Colors.White);
        //                        }
        //                        else if (result.Equals("false"))
        //                        {
        //                            BackgroundColor = new SolidColorBrush(Colors.Black);
        //                        }
        //                    }
        //                    catch (WebException ex)
        //                    {
        //                        break;
        //                    }
        //                    Task.Delay(1000).Wait();
        //                }
        //            });
        //        }));
        //    }
        //}
        //#endregion

        public MainViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        using (HttpClient http = new HttpClient())
                        {
                            string result = http.GetAsync("http://" + IPAddress + ":5000/api/Flats/" + FlatNumber).Result.Content.ReadAsStringAsync().Result;
                            if (result.Equals("true"))
                            {
                                //BackgroundColor = new SolidColorBrush(Colors.White);
                                //SolidColorBrush br = new SolidColorBrush(Colors.Black);
                                NumberColor = 1;
                            }
                            else if (result.Equals("false"))
                            {
                                NumberColor = 0;

                                //BackgroundColor = new SolidColorBrush(Colors.Black);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //break;
                    }
                    Task.Delay(1000).Wait();
                }
            });
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
