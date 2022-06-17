using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        #region VisibilityBlack
        private Visibility _VisibilityBlack;
        public Visibility VisibilityBlack
        {
            get => _VisibilityBlack;
            set
            {
                _VisibilityBlack = value;
                OnPropertyChanged();
            }
        }
        #endregion


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
                            var a = http.GetAsync("http://" + IPAddress + ":5000/api/Flats/" + FlatNumber).Result.Content.ReadAsStringAsync().Result;
                            if (a == "true")
                            {
                                VisibilityBlack = Visibility.Collapsed;
                            }
                            else if (a == "false")
                            {
                                VisibilityBlack = Visibility.Visible;
                            }

                        }
                    }
                    catch (Exception ex)
                    { }
                    Task.Delay(500).Wait();
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
